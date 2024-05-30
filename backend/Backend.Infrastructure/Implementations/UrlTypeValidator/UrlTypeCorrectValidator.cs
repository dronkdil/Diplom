using System.Globalization;
using System.Net;
using Backend.Core.Interfaces.UrlTypeValidator;

namespace Backend.Infrastructure.Implementations.UrlTypeValidator;

public class UrlTypeCorrectValidator : IUrlTypeCorrectValidator
{
    public bool Valid(string url, UrlTypes type, bool required)
    {
        var typeModificator = type switch
        {
            UrlTypes.Video => "video/",
            UrlTypes.Image => "image/",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
        
        if (string.IsNullOrEmpty(url))
            return !required;

        try
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";
            using var response = request.GetResponse();
            return response.ContentType.ToLower(CultureInfo.InvariantCulture)
                .StartsWith(typeModificator);
        }
        catch
        {
            return false;
        }
    }
}