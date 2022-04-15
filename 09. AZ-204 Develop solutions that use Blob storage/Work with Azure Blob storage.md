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




