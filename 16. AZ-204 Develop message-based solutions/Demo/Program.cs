namespace Demo
{
    using System.Threading.Tasks;

    using Azure.Messaging.ServiceBus;

    public static class Program
    {
        // number of messages to be sent to the queue
        private const int NumOfMessages = 3;

        // connection string to your Service Bus namespace
        private const string ConnectionString = "Endpoint=sb://az204svcbus1045925035.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=M/ripqe5kT7qMek+5/u6kGvfaTD0OsLozEAsmKrEp/8=";

        // name of your Service Bus topic
        private const string QueueName = "az204-queue";

        // the client that owns the connection and can be used to create senders and receivers
        private static ServiceBusClient client;

        public static async Task Main()
        {
            // Create the clients that we'll use for sending and processing messages.
            client = new ServiceBusClient(ConnectionString);

            try
            {
                await SendBatchOfMessages(NumOfMessages);
                await ReceiveMessage();
            }
            finally
            {
                await client.DisposeAsync();
            }

            Console.WriteLine("Press any key to close application.");
            Console.ReadKey();
        }

        private static async Task SendBatchOfMessages(int count)
        {
            var messages = new List<ServiceBusMessage>();

            for (var i = 1; i <= count; i++)
            {
                messages.Add(new ServiceBusMessage($"Message {i}"));
            }

            var sender = new MessageSender(client, QueueName);

            try
            {
                // Use the producer client to send the batch of messages to the Service Bus queue
                await sender.SendMessagesAsync(messages);
                Console.WriteLine($"A batch of {count} messages has been published to the queue.");
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up.
                await sender.DisposeAsync();
            }

            Console.WriteLine("Press any key to read messages from Service Bus");
            Console.ReadKey();
        }

        private static async Task ReceiveMessage()
        {
            // create a processor that we can use to process the messages
            var processor = new MessageProcessor(client, QueueName);

            try
            {
                // add handler to process messages
                processor.ProcessMessageAsync += MessageHandler;

                // add handler to process any errors
                processor.ProcessErrorAsync += ErrorHandler;

                // start processing 
                await processor.StartProcessingAsync();

                Console.WriteLine("Wait for a minute and then press any key to end the processing");
                Console.ReadKey();

                // stop processing 
                Console.WriteLine("\nStopping the receiver...");
                await processor.StopProcessingAsync();
                Console.WriteLine("Stopped receiving messages");
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up.
                await processor.DisposeAsync();
            }
        }

        // handle received messages
        private static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body}");

            // complete the message. messages is deleted from the queue. 
            await args.CompleteMessageAsync(args.Message);
        }

        // handle any errors when receiving messages
        private static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}
