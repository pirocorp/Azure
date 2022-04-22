namespace Graph
{
    using Azure.Identity;

    using Microsoft.Graph;

    public static class Program
    {
        private const string ClientId = "1c95b984-a22c-48f6-8719-a47cfe64df3e";
        private const string TenantId = "88b8f98f-7115-4b66-a465-4567c3c88230";

        public static async Task Main(string[] args)
        {
            var graphClient = CreateGraphServiceClient();

            await RetrieveEntity(graphClient);
            await RetrieveListOfEntities(graphClient);
            await DeleteEntity(graphClient);
            await CreateEntity(graphClient);
        }

        private static GraphServiceClient CreateGraphServiceClient()
        {
            var authProvider = new DeviceCodeCredential(new DeviceCodeCredentialOptions()
            {
                ClientId = ClientId,
                TenantId = TenantId
            });

            var scopes = new[] { "User.Read" };

            var graphClient = new GraphServiceClient(authProvider, scopes);
            return graphClient;
        }

        private static async Task RetrieveEntity(GraphServiceClient graphClient)
        {
            // GET https://graph.microsoft.com/v1.0/me

            var user = await graphClient.Me
                .Request()
                .GetAsync();

            Console.WriteLine($"Retrieving entity user: Id: {user.Id}");
            Console.WriteLine();
        }

        private static async Task RetrieveListOfEntities(GraphServiceClient graphClient)
        {
            var messages = await graphClient.Me.Messages
                .Request()
                .Select(m => new {
                    m.Subject,
                    m.Sender
                })
                // .Filter("<filter condition>")
                .OrderBy("receivedDateTime")
                .GetAsync();

            Console.WriteLine($"Retrieving messages:");

            foreach (var message in messages)
            {
                Console.WriteLine($"| ID: {message.Id} Content: {message.Body.Content}");
                Console.WriteLine($"|");
            }

            Console.WriteLine();
        }

        private static async Task DeleteEntity(GraphServiceClient graphClient, string messageId = "AQMkAGUy...")
        {
            // DELETE https://graph.microsoft.com/v1.0/me/messages/{message-id}

            await graphClient.Me.Messages[messageId]
                .Request()
                .DeleteAsync();
        }

        private static async Task CreateEntity(GraphServiceClient graphClient)
        {
            // POST https://graph.microsoft.com/v1.0/me/calendars

            var calendar = new Calendar
            {
                Name = "Volunteer"
            };

            var newCalendar = await graphClient.Me.Calendars
                .Request()
                .AddAsync(calendar);
        }
    }
}
