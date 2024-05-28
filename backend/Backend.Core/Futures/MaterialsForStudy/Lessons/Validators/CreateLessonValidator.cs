using System.Globalization;
using System.Net;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;
using FluentValidation;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.Validators;

public class CreateLessonValidator : AbstractValidator<CreateLessonDto>
{
    public CreateLessonValidator()
    {
        RuleFor(o => o.Title)
            .NotEmpty()
            .WithMessage("Назва обов'язкова");
        
        RuleFor(o => o.Description)
            .NotEmpty()
            .WithMessage("Опис обов'язковий");
        
        RuleFor(o => o.VideoUrl)
            .NotEmpty()
            .WithMessage("Відео обов'язкове")
            .Must((_, value, _) => IsVideoUrl(value))
            .WithMessage("Некоректний формат");
    }
    
    private static bool IsVideoUrl(string url)
    {
        try
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";
            using var response = request.GetResponse();
            return response.ContentType.ToLower(CultureInfo.InvariantCulture)
                .StartsWith("video/");
        }
        catch
        {
            return false;
        }
    }
}