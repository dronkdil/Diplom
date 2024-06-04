namespace Backend.Core.Interfaces.YoutubeLink;

public interface IYoutubeLinkParser
{
    string GetVideoId(string link);
}