namespace Msal_Demo
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Identity.Client;

    public static class Program
    {
        private const string ClientId = "1c95b984-a22c-48f6-8719-a47cfe64df3e";
        private const string TenantId = "88b8f98f-7115-4b66-a465-4567c3c88230";

        public static async Task Main(string[] args)
        {
            IPublicClientApplication app = CreateClientApplication();

            string[] scopes = { "user.read" };

            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

            Console.WriteLine($"Token:\t{result.AccessToken}");
        }

        public static IPublicClientApplication CreateClientApplication()
            => PublicClientApplicationBuilder
                .Create(ClientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, TenantId)
                .WithRedirectUri("http://localhost")
                .Build();
    }
}
