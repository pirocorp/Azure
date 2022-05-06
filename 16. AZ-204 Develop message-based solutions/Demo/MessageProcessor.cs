namespace Demo
{
    using Azure.Messaging.ServiceBus;

    public class MessageProcessor : IDisposable, IAsyncDisposable
    {
        private readonly ServiceBusProcessor processor;

        public MessageProcessor(ServiceBusClient client, string queueName)
        {
            this.processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());
        }

        public event Func<ProcessMessageEventArgs, Task> ProcessMessageAsync
        {
            add => this.processor.ProcessMessageAsync += value;

            remove => this.processor.ProcessMessageAsync -= value;
        }

        public event Func<ProcessErrorEventArgs, Task> ProcessErrorAsync
        {
            add => this.processor.ProcessErrorAsync += value;

            remove => this.processor.ProcessErrorAsync -= value;
        }

        public async Task StartProcessingAsync() => await this.processor.StartProcessingAsync();

        public async Task StopProcessingAsync() => await this.processor.StopProcessingAsync();

        public void Dispose()
            => this.processor.DisposeAsync().GetAwaiter().GetResult();

        public async ValueTask DisposeAsync()
            => await this.processor.DisposeAsync();
    }
}
