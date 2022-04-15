﻿namespace Az204_blob
{
    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;

    using System;
    using System.Threading.Tasks;

    public static class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("Azure Blob Storage exercise\n");

            // Run the examples asynchronously, wait for the results before proceeding
            await ProcessAsync();

            Console.WriteLine("Press enter to exit the sample application.");
            Console.ReadLine();
        }

        private static async Task ProcessAsync()
        {
            // Copy the connection string from the portal in the variable below.
            const string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=zrzstorageaccaunt;AccountKey=ZPXYiv4EWGtWu0FyqdNPBj04d1h2nZST5L7MXS3KPTJ5xOKbU1N2MMcGLNdrSqqsvR/DYdCUFSrxm+4l2uTOhA==;EndpointSuffix=core.windows.net";

            // Create a client that can authenticate with a connection string
            var blobServiceClient = new BlobServiceClient(storageConnectionString);

            // EXAMPLE CODE STARTS BELOW HERE

            //Create a unique name for the container
            var containerName = "wtblob" + Guid.NewGuid();

            var localFile = CreateLocalFile();
            
            await CreateContainer(blobServiceClient, containerName);
            await UploadBlobToContainer(blobServiceClient, containerName, localFile);
            await ListBlobsInContainer(blobServiceClient, containerName);
            await DownloadBlob(blobServiceClient, containerName, localFile);
            await DeleteContainer(blobServiceClient, containerName, localFile);
        }

        private static (string FileName, string FilePath) CreateLocalFile()
        {
            // Create a local file in the ./data/ directory for uploading and downloading
            const string localPath = "./data/";
            var fileName = "wtfile" + Guid.NewGuid() + ".txt";
            var localFilePath = Path.Combine(localPath, fileName);

            return (fileName, localFilePath);
        }

        private static string GenerateDownloadFilePath (string filePath) 
            => filePath.Replace(".txt", "DOWNLOADED.txt"); // Append the string "DOWNLOADED" before the .txt extension 

        private static async Task CreateContainer(BlobServiceClient blobServiceClient, string containerName)
        {
            // Create the container and return a container client object
            BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);

            Console.WriteLine("A container named '" + containerName + "' has been created. " +
                              "\nTake a minute and verify in the portal." + 
                              "\nNext a file will be created and uploaded to the container.");

            Console.WriteLine("Press 'Enter' to continue.");
            Console.ReadLine();
        }

        private static async Task UploadBlobToContainer(
            BlobServiceClient blobServiceClient, 
            string containerName, 
            (string FileName, string FilePath) file)
        {
            var (fileName, filePath) = file;

            // Write text to the file
            await File.WriteAllTextAsync(filePath, "Hello, World!");

            // Get a reference to the container client
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Get a reference to the blob
            var blobClient = containerClient.GetBlobClient(fileName);

            Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

            // Open the file and upload its data

            await using (var uploadFileStream = File.OpenRead(filePath))
            {
                await blobClient.UploadAsync(uploadFileStream, true);
                uploadFileStream.Close();
            }

            Console.WriteLine("\nThe file was uploaded. We'll verify by listing the blobs next.");
            Console.WriteLine("Press 'Enter' to continue.");
            Console.ReadLine();
        }

        private static async Task ListBlobsInContainer(BlobServiceClient blobServiceClient, string containerName)
        {
            // Get a reference to the container client
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // List blobs in the container
            Console.WriteLine("Listing blobs...");

            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                Console.WriteLine("\t" + blobItem.Name);
            }

            Console.WriteLine("\nYou can also verify by looking inside the " + 
                              "container in the portal." +
                              "\nNext the blob will be downloaded with an altered file name.");

            Console.WriteLine("Press 'Enter' to continue.");
            Console.ReadLine();
        }

        private static async Task DownloadBlob(
            BlobServiceClient blobServiceClient, 
            string containerName, 
            (string FileName, string FilePath) file)
        {
            // Download the blob to a local file
            var (fileName, filePath) = file;

            var downloadFilePath = GenerateDownloadFilePath(filePath);

            Console.WriteLine("\nDownloading blob to\n\t{0}\n", downloadFilePath);

            // Download the blob's contents and save it to a file
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            BlobDownloadInfo download = await blobClient.DownloadAsync();

            await using (var downloadFileStream = File.OpenWrite(downloadFilePath))
            {
                await download.Content.CopyToAsync(downloadFileStream);
                downloadFileStream.Close();
            }

            Console.WriteLine("\nLocate the local file to verify it was downloaded.");
            Console.WriteLine("The next step is to delete the container and local files.");
            Console.WriteLine("Press 'Enter' to continue.");
            Console.ReadLine();
        }

        private static async Task DeleteContainer(
            BlobServiceClient blobServiceClient, 
            string containerName, 
            (string FileName, string FilePath) file)
        {
            // Get a reference to the container client
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Delete the container and clean up local files created
            Console.WriteLine("\n\nDeleting blob container...");
            await containerClient.DeleteAsync();

            var (_, filePath) = file;
            var downloadFilePath = GenerateDownloadFilePath(filePath);

            Console.WriteLine("Deleting the local source and downloaded files...");
            File.Delete(filePath);
            File.Delete(downloadFilePath);

            Console.WriteLine("Finished cleaning up.");
        }
    }
}
