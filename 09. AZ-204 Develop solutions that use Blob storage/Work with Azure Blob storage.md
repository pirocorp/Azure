# Azure Blob storage client library

The Azure Storage client libraries for .NET offer a convenient interface for making calls to Azure Storage. The latest version of the Azure Storage client library is version 12.x. Microsoft recommends using version 12.x for new applications.

Below are the classes in the Azure.Storage.Blobs namespace and their purpose:

| Class               	| Description                                                                                                                                                                    	|
|---------------------	|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	|
| BlobClient          	| The BlobClient allows you to manipulate Azure Storage blobs.                                                                                                                   	|
| BlobClientOptions   	| Provides the client configuration options for connecting to Azure Blob Storage.                                                                                                	|
| BlobContainerClient 	| The BlobContainerClient allows you to manipulate Azure Storage containers and their blobs.                                                                                     	|
| BlobServiceClient   	| The BlobServiceClient allows you to manipulate Azure Storage service resources and blob containers. The storage account provides the top-level namespace for the Blob service. 	|
| BlobUriBuilder      	| The BlobUriBuilder class provides a convenient way to modify the contents of a Uri instance to point to different Azure Storage resources like an account, container, or blob. 	|


# Create Blob storage resources by using the .NET client library

This exercise uses the Azure Blob storage client library to show you how to perform the following actions on Azure Blob storage in a console app:

- Create a container
- Upload blobs to a container
- List the blobs in a container
- Download blobs
- Delete a container


## Prerequisites

- An Azure account with an active subscription. If you don't already have one, you can sign up for a free trial at [Build in the cloud with an Azure free account](https://azure.com/free).
- Visual Studio Code: You can install it from [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/).
- Azure CLI: You can install the Azure CLI from [How to install the Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli).
- The .NET Core 3.1 SDK, or .NET 5.0 SDK. You can install from [Download .NET](https://dotnet.microsoft.com/download).


## Setting up

Perform the following actions to prepare Azure, and your local environment, for the exercise.

Start Visual Studio Code and open a terminal window by selecting Terminal from the top application bar, then selecting New Terminal.

![image](https://user-images.githubusercontent.com/34960418/163569812-bcbda5e1-e8ec-4a89-af73-c0be188d92c6.png)


Login to Azure by using the command below. A browser window should open letting you choose which account to login with.

```bash
az login
```

![image](https://user-images.githubusercontent.com/34960418/163569950-ab8f7834-e70c-4946-a939-c171684873b0.png)


Create a resource group for the resources needed for this exercise. Replace ```<myLocation>``` with a region near you.

```bash
az group create --location <myLocation> --name az204-blob-rg
```

![image](https://user-images.githubusercontent.com/34960418/163570065-9dfe2e5b-67b2-4f02-97e5-ed65ac039f8c.png)


Create a storage account. We need a storage account created to use in the application. Replace ```<myLocation>``` with the same region you used for the resource group. Replace ```<myStorageAcct>``` with a unique name.

```bash
az storage account create --resource-group az204-blob-rg --name <myStorageAcct> --location <myLocation> --sku Standard_LRS
```

![image](https://user-images.githubusercontent.com/34960418/163570310-cbefc221-c78a-4f25-8eb7-45ea05cb1622.png)


Get credentials for the storage account.

Navigate to the **[Azure portal](https://portal.azure.com/)**. Locate the storage account created. Select **Access keys** in the **Security + networking** section of the navigation pane. Here, you can view your account access keys and the complete connection string for each key.

![image](https://user-images.githubusercontent.com/34960418/163570619-7218c371-cd23-4db8-9bc2-07faa3913a4f.png)


Find the **Connection string** value under **key1**, and select the **Copy** button to copy the connection string. You will add the connection string value to the code in the next section.

![image](https://user-images.githubusercontent.com/34960418/163570799-13f6b391-5f6e-4b89-86d2-97c7b8e8fe8e.png)


In the **Data storage** section select **Containers**. Leave the windows open so you can view changes made to the storage as you progress through the exercise.

![image](https://user-images.githubusercontent.com/34960418/163571074-9e010558-257d-43b5-b45c-9e43fa1e9f65.png)


## Prepare the .NET project

In this section we'll create project named **az204-blob** and install the Azure Blob Storage client library.

In the terminal or with Visual Studio create Console App, use the dotnet new command to create a new console app. 

Inside the ```az204-blob``` folder, create another folder named ```data```. This is where the blob data files will be created and stored.

Install the Azure Blob Storage client library for .NET package ```Azure.Storage.Blobs```;

Open the ```Program.cs``` file in your editor, and replace the contents with the following code.

```csharp
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace az204_blob
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Azure Blob Storage exercise\n");

            // Run the examples asynchronously, wait for the results before proceeding
            ProcessAsync().GetAwaiter().GetResult();

            Console.WriteLine("Press enter to exit the sample application.");
            Console.ReadLine();

        }

        private static async Task ProcessAsync()
        {
            // Copy the connection string from the portal in the variable below.
            string storageConnectionString = "CONNECTION STRING";

            // Create a client that can authenticate with a connection string
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageConnectionString);

            // EXAMPLE CODE STARTS BELOW HERE


        }
    }
}
```

Set the storageConnectionString variable to the value you copied from the portal.

![image](https://user-images.githubusercontent.com/34960418/163580556-77d726ea-b403-434f-80d7-2504dbce8207.png)


## Build the full app

For each of the following sections below you'll find a brief description of the action being taken as well as the code snippet you'll add to the project. Each new snippet is appended to the one before it, and we'll build and run the console app at the end.

For each example below copy the code and append it to the previous snippet in the example code section of the Program.cs file.


### Create a container

To create the container first create an instance of the **BlobServiceClient** class, then call the **CreateBlobContainerAsync** method to create the container in your storage account. A GUID value is appended to the container name to ensure that it is unique. The **CreateBlobContainerAsync** method will fail if the container already exists.

```csharp
//Create a unique name for the container
string containerName = "wtblob" + Guid.NewGuid().ToString();

// Create the container and return a container client object
BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
Console.WriteLine("A container named '" + containerName + "' has been created. " +
    "\nTake a minute and verify in the portal." + 
    "\nNext a file will be created and uploaded to the container.");
Console.WriteLine("Press 'Enter' to continue.");
Console.ReadLine();
```

### Upload blobs to a container

The following code snippet gets a reference to a **BlobClient** object by calling the **GetBlobClient** method on the container created in the previous section. It then uploads the selected local file to the blob by calling the **UploadAsync** method. This method creates the blob if it doesn't already exist, and overwrites it if it does.

```csharp
// Create a local file in the ./data/ directory for uploading and downloading
string localPath = "./data/";
string fileName = "wtfile" + Guid.NewGuid().ToString() + ".txt";
string localFilePath = Path.Combine(localPath, fileName);

// Write text to the file
await File.WriteAllTextAsync(localFilePath, "Hello, World!");

// Get a reference to the blob
BlobClient blobClient = containerClient.GetBlobClient(fileName);

Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

// Open the file and upload its data
using FileStream uploadFileStream = File.OpenRead(localFilePath);
await blobClient.UploadAsync(uploadFileStream, true);
uploadFileStream.Close();

Console.WriteLine("\nThe file was uploaded. We'll verify by listing" + 
        " the blobs next.");
Console.WriteLine("Press 'Enter' to continue.");
Console.ReadLine();
```


### List the blobs in a container

List the blobs in the container by using the **GetBlobsAsync** method. In this case, only one blob has been added to the container, so the listing operation returns just that one blob.

```csharp
// List blobs in the container
Console.WriteLine("Listing blobs...");
await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
{
    Console.WriteLine("\t" + blobItem.Name);
}

Console.WriteLine("\nYou can also verify by looking inside the " + 
        "container in the portal." +
        "\nNext the blob will be downloaded with an altered file name.");
Console.WriteLine("Press 'Enter' to continue.");
Console.ReadLine();
```


### Download blobs

Download the blob created previously to your local file system by using the **DownloadAsync** method. The example code adds a suffix of "DOWNLOADED" to the blob name so that you can see both files in local file system.


```csharp
// Download the blob to a local file
// Append the string "DOWNLOADED" before the .txt extension 
string downloadFilePath = localFilePath.Replace(".txt", "DOWNLOADED.txt");

Console.WriteLine("\nDownloading blob to\n\t{0}\n", downloadFilePath);

// Download the blob's contents and save it to a file
BlobDownloadInfo download = await blobClient.DownloadAsync();

using (FileStream downloadFileStream = File.OpenWrite(downloadFilePath))
{
    await download.Content.CopyToAsync(downloadFileStream);
    downloadFileStream.Close();
}
Console.WriteLine("\nLocate the local file to verify it was downloaded.");
Console.WriteLine("The next step is to delete the container and local files.");
Console.WriteLine("Press 'Enter' to continue.");
Console.ReadLine();
```

### Delete a container

The following code cleans up the resources the app created by deleting the entire container using **DeleteAsync**. It also deletes the local files created by the app.

```csharp
// Delete the container and clean up local files created
Console.WriteLine("\n\nDeleting blob container...");
await containerClient.DeleteAsync();

Console.WriteLine("Deleting the local source and downloaded files...");
File.Delete(localFilePath);
File.Delete(downloadFilePath);

Console.WriteLine("Finished cleaning up.");
```


## Run the code

Now that the app is complete it's time to build and run it. Ensure you are in your application directory and run the following commands:

```bash
dotnet build
dotnet run
```

There are many prompts in the app to allow you to take the time to see what's happening in the portal after each step.

![image](https://user-images.githubusercontent.com/34960418/163586019-21ebbe34-5877-4267-be56-20019788ca94.png)


## Manage container properties and metadata by using .NET

Blob containers support system properties and user-defined metadata, in addition to the data they contain.

- **System properties**: System properties exist on each Blob storage resource. Some of them can be read or set, while others are read-only. Under the covers, some system properties correspond to certain standard HTTP headers. The Azure Storage client library for .NET maintains these properties for you.

- **User-defined metadata**: User-defined metadata consists of one or more name-value pairs that you specify for a Blob storage resource. You can use metadata to store additional values with the resource. Metadata values are for your own purposes only, and do not affect how the resource behaves.

Metadata name/value pairs are valid HTTP headers, and so should adhere to all restrictions governing HTTP headers. Metadata names must be valid HTTP header names and valid C# identifiers, may contain only ASCII characters, and should be treated as case-insensitive. Metadata values containing non-ASCII characters should be Base64-encoded or URL-encoded.


### Retrieve container properties

To retrieve container properties, call one of the following methods of the BlobContainerClient class:

- GetProperties
- GetPropertiesAsync

The following code example fetches a container's system properties and writes some property values to a console window:


```csharp
private static async Task ReadContainerPropertiesAsync(BlobContainerClient container)
{
    try
    {
        // Fetch some container properties and write out their values.
        var properties = await container.GetPropertiesAsync();
        Console.WriteLine($"Properties for container {container.Uri}");
        Console.WriteLine($"Public access level: {properties.Value.PublicAccess}");
        Console.WriteLine($"Last modified time in UTC: {properties.Value.LastModified}");
    }
    catch (RequestFailedException e)
    {
        Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
}
```

### Set and retrieve metadata

You can specify metadata as one or more name-value pairs on a blob or container resource. To set metadata, add name-value pairs to an IDictionary object, and then call one of the following methods of the BlobContainerClient class to write the values:

- SetMetadata
- SetMetadataAsync

The name of your metadata must conform to the naming conventions for C# identifiers. Metadata names preserve the case with which they were created, but are case-insensitive when set or read. If two or more metadata headers with the same name are submitted for a resource, Blob storage comma-separates and concatenates the two values and return HTTP response code 200 (OK).

The following code example sets metadata on a container.


```csharp
public static async Task AddContainerMetadataAsync(BlobContainerClient container)
{
    try
    {
        IDictionary<string, string> metadata =
           new Dictionary<string, string>();

        // Add some metadata to the container.
        metadata.Add("docType", "textDocuments");
        metadata.Add("category", "guidance");

        // Set the container's metadata.
        await container.SetMetadataAsync(metadata);
    }
    catch (RequestFailedException e)
    {
        Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
}
```

The GetProperties and GetPropertiesAsync methods are used to retrieve metadata in addition to properties as shown earlier.

The following code example retrieves metadata from a container.


```csharp
public static async Task ReadContainerMetadataAsync(BlobContainerClient container)
{
    try
    {
        var properties = await container.GetPropertiesAsync();

        // Enumerate the container's metadata.
        Console.WriteLine("Container metadata:");
        foreach (var metadataItem in properties.Value.Metadata)
        {
            Console.WriteLine($"\tKey: {metadataItem.Key}");
            Console.WriteLine($"\tValue: {metadataItem.Value}");
        }
    }
    catch (RequestFailedException e)
    {
        Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
}
```


## Run the code

Now that the app is complete it's time to build and run it. Ensure you are in your application directory and run the following commands:

```bash
dotnet build
dotnet run
```

There are many prompts in the app to allow you to take the time to see what's happening in the portal after each step.


# Clean up other resources

The app deleted the resources it created. You can delete all of the resources created for this exercise by using the command below. You will need to confirm that you want to delete the resources.

```bash
az group delete --name az204-blob-rg --no-wait
```
