namespace MessagePublisher
{
    using System;
    using System.Threading.Tasks;

    using Azure.Messaging.ServiceBus;

    public static class Program
    {
        private const string StorageConnectionString = "Endpoint=sb://sbnamespacezrz.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=h8JH0hPpHZGTTw+Qeu+UDaXZGWsRp4PZ4WEZa4imr4s=";

        private const string QueueName = "messagequeue";

        private const int NumOfMessages = 3;

        private static readonly ServiceBusClient Client;

        private static readonly ServiceBusSender Sender;

        static Program()
        {
            Client = new ServiceBusClient(StorageConnectionString);
            Sender = Client.CreateSender(QueueName);  
        }

        public static async Task Main()
        {
            using var messageBatch = await Sender.CreateMessageBatchAsync();

            for (var i = 1; i <= NumOfMessages; i++)
            {
                if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
                {
                    throw new Exception($"The message {i} is too large to fit in the batch.");
                }
            }

            try
            {
                await Sender.SendMessagesAsync(messageBatch);
                Console.WriteLine($"A batch of {NumOfMessages} messages has been published to the queue.");
            }
            finally
            {
                await Sender.DisposeAsync();
                await Client.DisposeAsync();
            }
        }
    }
}
