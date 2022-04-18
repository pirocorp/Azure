# Explore Microsoft .NET SDK v3 for Azure Cosmos DB

This unit focuses on version 3 of the .NET SDK. (Microsoft.Azure.Cosmos NuGet package.) If you're familiar with the previous version of the .NET SDK, you may be used to the terms collection and document.

The [azure-cosmos-dotnet-v3](https://github.com/Azure/azure-cosmos-dotnet-v3/tree/master/Microsoft.Azure.Cosmos.Samples/Usage) GitHub repository includes the latest .NET sample solutions. You use these solutions to perform CRUD (create, read, update, and delete) and other common operations on Azure Cosmos DB resources.

Because Azure Cosmos DB supports multiple API models, version 3 of the .NET SDK uses the generic terms "container" and "item". A container can be a collection, graph, or table. An item can be a document, edge/vertex, or row, and is the content inside a container.

Below are examples showing some of the key operations you should be familiar with. For more examples please visit the GitHub link above. The examples below all use the async version of the methods.


# CosmosClient

Creates a new CosmosClient with a connection string. CosmosClient is thread-safe. Its recommended to maintain a single instance of CosmosClient per lifetime of the application which enables efficient connection management and performance.


```csharp
CosmosClient client = new CosmosClient(endpoint, key);
```


# Database examples

## Create a database

The CosmosClient.CreateDatabaseIfNotExistsAsync checks if a database exists, and if it doesn't, creates it. Only the database id is used to verify if there is an existing database.

```csharp
// An object containing relevant information about the response
DatabaseResponse databaseResponse = await client.CreateDatabaseIfNotExistsAsync(databaseId, 10000);
```


## Read a database by ID

Reads a database from the Azure Cosmos service as an asynchronous operation.

```csharp
DatabaseResponse readResponse = await database.ReadAsync();
```


## Delete a database

Delete a Database as an asynchronous operation.

```csharp
await database.DeleteAsync();
```


# Container examples

## Create a container

The Database.CreateContainerIfNotExistsAsync method checks if a container exists, and if it doesn't, it creates it. Only the container id is used to verify if there is an existing container.

```csharp
// Set throughput to the minimum value of 400 RU/s
ContainerResponse simpleContainer = await database.CreateContainerIfNotExistsAsync(
    id: containerId,
    partitionKeyPath: partitionKey,
    throughput: 400);
```


## Get a container by ID

```csharp
Container container = database.GetContainer(containerId);
ContainerProperties containerProperties = await container.ReadContainerAsync();
```


## Delete a container

Delete a Container as an asynchronous operation.

```csharp
await database.GetContainer(containerId).DeleteContainerAsync();
```


# Item examples

## Create an item

Use the Container.CreateItemAsync method to create an item. The method requires a JSON serializable object that must contain an id property, and a partitionKey.

```csharp
ItemResponse<SalesOrder> response = await container.CreateItemAsync(salesOrder, new PartitionKey(salesOrder.AccountNumber));
```

## Read an item

Use the Container.ReadItemAsync method to read an item. The method requires type to serialize the item to along with an id property, and a partitionKey.

```csharp
string id = "[id]";
string accountNumber = "[partition-key]";
ItemResponse<SalesOrder> response = await container.ReadItemAsync(id, new PartitionKey(accountNumber));
```

## Query an item

The Container.GetItemQueryIterator method creates a query for items under a container in an Azure Cosmos database using a SQL statement with parameterized values. It returns a FeedIterator.

```csharp
QueryDefinition query = new QueryDefinition(
    "select * from sales s where s.AccountNumber = @AccountInput ")
    .WithParameter("@AccountInput", "Account1");

FeedIterator<SalesOrder> resultSet = container.GetItemQueryIterator<SalesOrder>(
    query,
    requestOptions: new QueryRequestOptions()
    {
        PartitionKey = new PartitionKey("Account1"),
        MaxItemCount = 1
    });
```

## Additional resources

- The [azure-cosmos-dotnet-v3](https://github.com/Azure/azure-cosmos-dotnet-v3/tree/master/Microsoft.Azure.Cosmos.Samples/Usage) GitHub repository includes the latest .NET sample solutions to perform CRUD and other common operations on Azure Cosmos DB resources.



- Visit this article [Azure Cosmos DB.NET V3 SDK (Microsoft.Azure.Cosmos) examples for the SQL API](https://docs.microsoft.com/en-us/azure/cosmos-db/sql-api-dotnet-v3sdk-samples) for direct links to specific examples in the GitHub repository.


# Create resources by using the Microsoft .NET SDK v3

## Connecting to Azure

Log in to Azure by using the command below. A browser window should open letting you choose which account to log in with.

```bash
az login
```

![image](https://user-images.githubusercontent.com/34960418/163834158-be661df0-5db4-42c8-a0ff-d40e29c86cc2.png)


## Create resources in Azure

Create a resource group for the resources needed for this exercise. Replace ```<myLocation>``` with a region near you.
    
```bash
az group create --location <myLocation> --name az204-cosmos-rg
```

![image](https://user-images.githubusercontent.com/34960418/163835848-aa30addc-0c86-4e97-8393-fb2a8ab4c92b.png)


Create the Azure Cosmos DB account. Replace ```<myCosmosDBacct>``` with a unique name to identify your Azure Cosmos account. The name can only contain lowercase letters, numbers, and the hyphen (-) character. It must be between 3-31 characters in length. This command will take a few minutes to complete.
    
```bash
az cosmosdb create --name <myCosmosDBacct> --resource-group az204-cosmos-rg
```

Record the documentEndpoint shown in the JSON response, it will be used below.

![image](https://user-images.githubusercontent.com/34960418/163836680-b124ff27-6bc3-4b11-bcc5-6bfb45bf9205.png)


Retrieve the primary key for the account by using the command below. Record the **primaryMasterKey** from the command results it will be used in the code below.

```bash
# Retrieve the primary key
az cosmosdb keys list --name <myCosmosDBacct> --resource-group az204-cosmos-rg
```

![image](https://user-images.githubusercontent.com/34960418/163837062-5cf51bc1-b32b-4c82-8078-0fdb356e675f.png)


## Set up the console application

Create C# Console App with VS Code or VS


## Build the console app

## Add packages and using statements

```bash
dotnet add package Microsoft.Azure.Cosmos
```


## Add using statements to include Microsoft.Azure.Cosmos and to enable async operations.

```csharp
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
```


## Add code to connect to an Azure Cosmos DB account

Replace the entire class Program with the code snippet below. The code snippet adds constants and variables into the class and adds some error checking. Be sure to replace the placeholder values for EndpointUri and PrimaryKey following the directions in the code comments.

```csharp
public class Program
{
    // Replace <documentEndpoint> with the information created earlier
    private static readonly string EndpointUri = "<documentEndpoint>";

    // Set variable to the Primary Key from earlier.
    private static readonly string PrimaryKey = "<your primary key>";

    // The Cosmos client instance
    private CosmosClient cosmosClient;

    // The database we will create
    private Database database;

    // The container we will create.
    private Container container;

    // The names of the database and container we will create
    private string databaseId = "az204Database";
    private string containerId = "az204Container";

    public static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("Beginning operations...\n");
            Program p = new Program();
            await p.CosmosAsync();

        }
        catch (CosmosException de)
        {
            Exception baseException = de.GetBaseException();
            Console.WriteLine("{0} error occurred: {1}", de.StatusCode, de);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e);
        }
        finally
        {
            Console.WriteLine("End of program, press any key to exit.");
            Console.ReadKey();
        }
    }
}
```

Below the Main method, add a new asynchronous task called CosmosAsync, which instantiates our new CosmosClient.

```csharp
public async Task CosmosAsync()
{
    // Create a new instance of the Cosmos Client
    this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
}
```


## Create a database

Copy and paste the CreateDatabaseAsync method after the CosmosAsync method. CreateDatabaseAsync creates a new database with ID az204Database if it doesn't already exist.


```csharp
private async Task CreateDatabaseAsync()
{
    // Create a new database using the cosmosClient
    this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
    Console.WriteLine("Created Database: {0}\n", this.database.Id);
}
```

Add the code below at the end of the CosmosAsync method, it calls the CreateDatabaseAsync method you just added.

```csharp
// Runs the CreateDatabaseAsync method
    await this.CreateDatabaseAsync();
```


## Create a container

Copy and paste the CreateContainerAsync method below the CreateDatabaseAsync method.

```csharp
private async Task CreateContainerAsync()
{
    // Create a new container
    this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/LastName");
    Console.WriteLine("Created Container: {0}\n", this.container.Id);
}
```

Copy and paste the code below where you instantiated the CosmosClient to call the CreateContainer method you just added.

```csharp
// Run the CreateContainerAsync method
await this.CreateContainerAsync();
```


## Run the application

Save your work and, in a terminal in VS Code, run the dotnet run command. The console will display the following messages.

```bash
dotnet run
```

![image](https://user-images.githubusercontent.com/34960418/163841175-eac7985f-d764-4344-9006-999513840d0c.png)


You can verify the results by opening the Azure portal, navigating to your Azure Cosmos DB resource, and use the Data Explorer to view the database and container.

![image](https://user-images.githubusercontent.com/34960418/163841291-0595b01d-43a0-4e33-87b9-6cf5dd54f847.png)


## Clean up Azure resources

```bash
az group delete --name az204-cosmos-rg --no-wait
```
