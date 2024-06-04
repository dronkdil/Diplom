using System.Text.RegularExpressions;
using Backend.Core.Interfaces.YoutubeLink;

namespace Backend.Infrastructure.Implementations.YoutubeLink;

public class YoutubeLinkParser : IYoutubeLinkParser
{
    private const string YoutubeLinkRegex = "(?:.+?)?(?:\\/v\\/|watch\\/|\\?v=|\\&v=|youtu\\.be\\/|\\/v=|^youtu\\.be\\/)([a-zA-Z0-9_-]{11})+";
    private static readonly Regex RegexExtractId = new Regex(YoutubeLinkRegex, RegexOptions.Compiled);
    
    public string GetVideoId(string link)
    {
        var regRes = RegexExtractId.Match(link);
        return regRes.Success ? regRes.Groups[1].Value : throw new ArgumentException($"{nameof(link)} incorrect format");
    }
}