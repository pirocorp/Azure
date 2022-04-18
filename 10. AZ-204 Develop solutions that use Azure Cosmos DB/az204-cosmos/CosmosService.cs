namespace az204_cosmos
{
    using System.Threading.Tasks;

    using Microsoft.Azure.Cosmos;

    public class CosmosService
    {
        // The names of the database and container we will create
        private const string ContainerId = "az204Container";
        private const string DatabaseId = "az204Database";

        // Replace <documentEndpoint> with the information created earlier
        private const string EndpointUri = "https://zrz-cosmos.documents.azure.com:443/";

        // Set variable to the Primary Key from earlier.
        private const string PrimaryKey = "wJV3wDKqiztorii4pEle4EeOLnbifERYEata9ixcRtVMUq3WuA11U8ByUjYCrbt1RE5gpLy9RigIcBWvkFt2mQ==";

        // The Cosmos client instance
        private readonly CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create.
        private Container container;

        public CosmosService()
        {
            // Create a new instance of the Cosmos Client
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
        }

        public async Task<string> CreateDatabaseAsync(string databaseId = DatabaseId)
        {
            // Create a new database using the cosmosClient
            this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);

            return $"Created Database: {this.database.Id}\n";
        }

        public async Task<string> CreateContainerAsync(string containerId = ContainerId)
        {
            // Create a new container
            this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/LastName");

            return $"Created Container: {this.container.Id}\n";
        }
    }
}
