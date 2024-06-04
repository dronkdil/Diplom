using Azure.Storage.Blobs;
using Backend.Core.Interfaces.BlobStorage;
using Backend.Domain.Constants;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Implementations.BlobStorage;

public class BlobStorage : IBlobStorage
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobStorage(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }
    
    public async Task<string> UploadAsync(BlobContainers container, IFormFile file)
    {
        var blobClient = GetContainer(container).GetBlobClient(file.FileName);
        await blobClient.UploadAsync(file.OpenReadStream(), true);
        return file.FileName;
    }

    public async Task<BlobFile> DownloadAsync(BlobContainers container, string fileName)
    {
        var blobClient = GetContainer(container).GetBlobClient(fileName);
        var memoryStream = new MemoryStream();
        await blobClient.DownloadToAsync(memoryStream);
        memoryStream.Position = 0;
        var contentType = (await blobClient.GetPropertiesAsync()).Value.ContentType;
        return new BlobFile
        {
            MemoryStream = memoryStream,
            ContentType = contentType,
            FileName = fileName
        };
    }

    private BlobContainerClient GetContainer(BlobContainers containerEnum)
    {
        var container = _blobServiceClient.GetBlobContainerClient(containerEnum.ToString());
        container.CreateIfNotExists();
        return container;
    }
}