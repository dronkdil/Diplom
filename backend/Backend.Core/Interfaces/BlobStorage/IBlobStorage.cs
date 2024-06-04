using Backend.Domain.Constants;
using Microsoft.AspNetCore.Http;

namespace Backend.Core.Interfaces.BlobStorage;

public interface IBlobStorage
{
    Task<string> UploadAsync(BlobContainers container, IFormFile file);
    Task<BlobFile> DownloadAsync(BlobContainers container, string fileName);
}