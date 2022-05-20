namespace EventPublisher
{
    using System;
    using System.Threading.Tasks;

    using Azure;
    using Azure.Messaging.EventGrid;

    public static class Program
    {
        private const string TopicEndpoint = "https://hrtopiczrz.eastus-1.eventgrid.azure.net/api/events";

        private const string TopicKey = "3nsDwGTK5GZArwSCEPxWD/FzZDmgWwrywHXoiZy0RrE=";

        public static async Task Main()
        {
            var endpoint = new Uri(TopicEndpoint);
            var credential = new AzureKeyCredential(TopicKey);

            var client = new EventGridPublisherClient(endpoint, credential);

            var firstEvent = new EventGridEvent(
                subject: $"New Employee: Alba Sutton",
                eventType: "Employees.Registration.New",
                dataVersion: "1.0",
                data: new
                {
                    FullName = "Alba Sutton",
                    Address = "4567 Pine Avenue, Edison, WA 97202"
                }
            );

            var secondEvent = new EventGridEvent(
                subject: $"New Employee: Alexandre Doyon",
                eventType: "Employees.Registration.New",
                dataVersion: "1.0",
                data: new
                {
                    FullName = "Alexandre Doyon",
                    Address = "456 College Street, Bow, WA 98107"
                }
            );


            await client.SendEventAsync(firstEvent);
            Console.WriteLine("First event published");

            await client.SendEventAsync(secondEvent);
            Console.WriteLine("Second event published");
        }
    }
}
