namespace Backend.Core.Interfaces.BlobStorage;

public class BlobFile
{
    public MemoryStream MemoryStream { get; set; } = null!;
    public string? ContentType { get; set; }
    public string FileName { get; set; } = null!;
}