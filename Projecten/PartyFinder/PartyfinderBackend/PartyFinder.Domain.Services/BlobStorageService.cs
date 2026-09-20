using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using PartyFinder.Domain.Services.Interfaces;

namespace PartyFinder.Domain.Services;

public class BlobStorageService(BlobServiceClient blobServiceClient) : IBlobStorageService
{
    public async Task UploadCsvAsync(string containerName, string blobName, Stream csvStream)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync();
        var blobClient = containerClient.GetBlobClient(blobName);
        csvStream.Position = 0;
        await blobClient.UploadAsync(csvStream, overwrite: true);
    }
}
