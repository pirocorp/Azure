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
- Visual Studio Code: You can install it from [Visual Studio Code](https://code.visualstudio.com/).
- Azure CLI: You can install the Azure CLI from [How to install the Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli).
- The .NET Core 3.1 SDK, or .NET 5.0 SDK. You can install from [Download .NET](https://dotnet.microsoft.com/download).


## Setting up

Perform the following actions to prepare Azure, and your local environment, for the exercise.

