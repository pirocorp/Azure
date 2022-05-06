namespace Demo
{
    using Azure.Messaging.ServiceBus;

    public sealed class MessageSender : IDisposable, IAsyncDisposable
    {
        private readonly ServiceBusSender sender;

        public MessageSender(ServiceBusClient client, string queueName)
        {
            this.sender = client.CreateSender(queueName);
        }

        public async Task SendMessagesAsync(params ServiceBusMessage[] messages)
            => await this.SendMessagesAsync(messages.AsEnumerable());

        public async Task SendMessagesAsync(IEnumerable<ServiceBusMessage> messages)
        {
            // create a batch 
            using var messageBatch = await this.sender.CreateMessageBatchAsync();

            foreach (var message in messages)
            {
                // try adding a message to the batch
                if (!messageBatch.TryAddMessage(message))
                {
                    // if an exception occurs
                    throw new Exception($"Exception in message ID: {message.MessageId} has occurred.");
                }
            }

            // Use the producer client to send the batch of messages to the Service Bus queue
            await this.sender.SendMessagesAsync(messageBatch);
        }

        public void Dispose()
            => this.sender.DisposeAsync().GetAwaiter().GetResult();

        public async ValueTask DisposeAsync()
            => await this.sender.DisposeAsync();
    }
}
