using System;

namespace PartyFinder.Domain.Services.Interfaces;

public interface IBlobStorageService
{
    Task UploadCsvAsync(string containerName, string blobName, Stream csvStream);
}
