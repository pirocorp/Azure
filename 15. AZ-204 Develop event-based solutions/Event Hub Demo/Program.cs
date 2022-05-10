namespace EventHubDemo
{
    using System.Text;
    using Azure.Messaging.EventHubs;
    using Azure.Messaging.EventHubs.Consumer;
    using Azure.Messaging.EventHubs.Processor;
    using Azure.Messaging.EventHubs.Producer;
    using Azure.Storage.Blobs;

    public static class Program
    {
        private const string EventHubConnectionString = "Endpoint=sb://zrz-az204-eh.servicebus.windows.net/;SharedAccessKeyName=demo;SharedAccessKey=mdLnFlZx4W7/wwKpmBARSUdeXtFHagQB6wEghi6cCOU=;EntityPath=event-hub";

        private const string EventHubName = "event-hub";

        private const string StorageAccountConnectionString =
            "DefaultEndpointsProtocol=https;AccountName=zrzstorage;AccountKey=ag/whzrT7QR5scajVFZjMnypaZfbXrAhn/H6Y5lH+XwymPBSBmn9HRoA7V2bvRfMgYRbWmIt8BLTIebZmf8P6g==;EndpointSuffix=core.windows.net";

        private const string BlobContainerName = "event-hub-blob";

        public static async Task Main()
        {
            await InspectEventHub();
            //await PublishEventsToEventHub();
            await ReadEventsFromEventHub();
            await ReadEventsFromEventHubPartition();
            await ProcessEventsWithEventProcessorClient();
        }

        private static async Task InspectEventHub()
        {
            string[] partitionIds;

            await using (var producer = new EventHubProducerClient(EventHubConnectionString, EventHubName))
            {
                partitionIds = await producer.GetPartitionIdsAsync();
            }

            Console.WriteLine("Partition Ids");

            foreach (var t in partitionIds)
            {
                Console.WriteLine($"Partition Id: {t}");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static async Task PublishEventsToEventHub()
        {
            var events = new List<EventData>()
            {
                new(new BinaryData("First")), 
                new(new BinaryData("Second"))
            };

            var count = 0;

            await using (var producer = new EventHubProducerClient(EventHubConnectionString, EventHubName))
            {
                using var eventBatch = await producer.CreateBatchAsync();

                count = events.Count(eventData => eventBatch.TryAdd(eventData));

                await producer.SendAsync(eventBatch);
            }

            Console.WriteLine($"Successfully added events: {count}");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static async Task ReadEventsFromEventHub()
        {
            Console.WriteLine("Read Events From Event Hub");

            const string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            await using (var consumer = new EventHubConsumerClient(consumerGroup, EventHubConnectionString, EventHubName))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(10));

                try
                {
                    await foreach (var receivedEvent in consumer.ReadEventsAsync(cancellationSource.Token))
                    {
                        // At this point, the loop will wait for events to be available in the Event Hub. When an event
                        // is available, the loop will iterate with the event that was received. Because we did not
                        // specify a maximum wait time, the loop will wait forever unless cancellation is requested using
                        // the cancellation token.

                        Console.WriteLine($"Event Partition: {receivedEvent.Partition?.PartitionId}, Data: {Encoding.UTF8.GetString(receivedEvent.Data?.Body.ToArray() ?? Array.Empty<byte>())}");
                    }
                }
                catch (TaskCanceledException)
                {
                    Console.WriteLine("Stop listening for events");
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static async Task ReadEventsFromEventHubPartition()
        {
            Console.WriteLine("Read Events From Event Hub Partition");

            string partitionId;

            await using (var producer = new EventHubProducerClient(EventHubConnectionString, EventHubName))
            {
                partitionId = (await producer.GetPartitionIdsAsync()).First();
            }

            const string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            await using (var consumer = new EventHubConsumerClient(consumerGroup, EventHubConnectionString, EventHubName))
            {
                var startingPosition = EventPosition.Earliest;

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(10));

                try
                {
                    await foreach (var receivedEvent in consumer.ReadEventsFromPartitionAsync(partitionId, startingPosition, cancellationSource.Token))
                    {
                        // At this point, the loop will wait for events to be available in the partition.  When an event
                        // is available, the loop will iterate with the event that was received.  Because we did not
                        // specify a maximum wait time, the loop will wait forever unless cancellation is requested using
                        // the cancellation token.

                        Console.WriteLine($"Event Partition: {receivedEvent.Partition?.PartitionId}, Data: {Encoding.UTF8.GetString(receivedEvent.Data?.Body.ToArray() ?? Array.Empty<byte>())}");
                    }
                }
                catch (TaskCanceledException)
                {
                    Console.WriteLine("Stop listening for events");
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static async Task ProcessEventsWithEventProcessorClient()
        {
            Console.WriteLine("Process Events With Event Processor Client");

            var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(10));

            Task ProcessEventHandler(ProcessEventArgs eventArgs)
            {
                Console.WriteLine($"Event Partition: {eventArgs.Partition?.PartitionId}, Data: {Encoding.UTF8.GetString(eventArgs.Data?.Body.ToArray() ?? Array.Empty<byte>())}");
                
                return Task.CompletedTask;
            }

            Task ProcessErrorHandler(ProcessErrorEventArgs eventArgs) => Task.CompletedTask;

            const string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            var storageClient = new BlobContainerClient(StorageAccountConnectionString, BlobContainerName);
            var processor = new EventProcessorClient(storageClient, consumerGroup, EventHubConnectionString, EventHubName);

            processor.ProcessEventAsync += ProcessEventHandler;
            processor.ProcessErrorAsync += ProcessErrorHandler;

            await processor.StartProcessingAsync(CancellationToken.None);

            try
            {
                // The processor performs its work in the background; block until cancellation
                // to allow processing to take place.

                await Task.Delay(Timeout.Infinite, cancellationSource.Token);
            }
            catch (TaskCanceledException)
            {
                // This is expected when the delay is canceled.
            }

            try
            {
                await processor.StopProcessingAsync(CancellationToken.None);
            }
            finally
            {
                // To prevent leaks, the handlers should be removed when processing is complete.

                processor.ProcessEventAsync -= ProcessEventHandler;
                processor.ProcessErrorAsync -= ProcessErrorHandler;
            }

            Console.WriteLine("Press any key to close the program");
            Console.ReadKey();
        }
    }
}
