namespace MessageReader
{
    using Azure.Messaging.ServiceBus;

    public static class Program
    {
        private const string StorageConnectionString = "Endpoint=sb://sbnamespacezrz.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=h8JH0hPpHZGTTw+Qeu+UDaXZGWsRp4PZ4WEZa4imr4s=";
        private const string QueueName = "messagequeue";
        private static readonly ServiceBusClient Client;
        private static readonly ServiceBusProcessor Processor;

        static Program()
        {
            Client = new ServiceBusClient(StorageConnectionString);
            Processor = Client.CreateProcessor(QueueName, new ServiceBusProcessorOptions());
        }

        public static async Task Main()
        {
            try
            {
                Processor.ProcessMessageAsync += MessageHandler;
                Processor.ProcessErrorAsync += ErrorHandler;

                await Processor.StartProcessingAsync();

                Console.WriteLine("Wait for a minute and then press any key to end the processing");
                Console.ReadKey();
                Console.WriteLine("\nStopping the receiver...");

                await Processor.StopProcessingAsync();

                Console.WriteLine("Stopped receiving messages");
            }
            finally
            {
                await Processor.DisposeAsync();
                await Client.DisposeAsync();
            }
        }

        private static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            var body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body}");

            await args.CompleteMessageAsync(args.Message);
        }

        private static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());

            return Task.CompletedTask;
        }
    }
}
