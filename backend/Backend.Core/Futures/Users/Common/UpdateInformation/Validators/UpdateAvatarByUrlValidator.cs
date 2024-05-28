using System.Globalization;
using System.Net;
using Backend.Core.Futures.Users.Common.UpdateInformation.DTOs.Requests;
using FluentValidation;

namespace Backend.Core.Futures.Users.Common.UpdateInformation.Validators;

public class UpdateAvatarByUrlValidator : AbstractValidator<UpdateAvatarByUrlDto>
{
    public UpdateAvatarByUrlValidator()
    {
        RuleFor(o => o.AvatarUrl)
            .Must((entity, value, context) => IsImageUrl(value))
            .WithMessage("Некоректне зображення");
    }
    
    private static bool IsImageUrl(string? url)
    {
        if (string.IsNullOrEmpty(url))
            return true;

        try
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";
            using var response = request.GetResponse();
            return response.ContentType.ToLower(CultureInfo.InvariantCulture)
                .StartsWith("image/");
        }
        catch
        {
            return false;
        }
    }
}