namespace Backend.Core.Interfaces.UrlTypeValidator;

public enum UrlTypes
{
    Video,
    Image
}

public interface IUrlTypeCorrectValidator
{
    bool Valid(string url, UrlTypes type, bool required);
}