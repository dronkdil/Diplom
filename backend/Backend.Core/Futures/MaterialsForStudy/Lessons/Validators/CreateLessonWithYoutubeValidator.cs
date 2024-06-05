using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;
using FluentValidation;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.Validators;

public class CreateLessonWithYoutubeValidator : AbstractValidator<CreateLessonWithYoutubeDto>
{
    public CreateLessonWithYoutubeValidator()
    {
        RuleFor(o => o.Title)
            .NotEmpty()
            .WithMessage("Назва обов'язкова");
        
        RuleFor(o => o.Description)
            .NotEmpty()
            .WithMessage("Опис обов'язковий");
        
        RuleFor(o => o.YoutubeLink)
            .NotEmpty()
            .WithMessage("Відео обов'язкове")
            .Must((entity, value, context) => IsValidYoutubeLink(value))
            .WithMessage("Некоректний формат youtube");
    }

    // TODO: create a class to validate and parse youtube link
    private static readonly string[] ValidAuthorities = { "youtube.com", "www.youtube.com", "youtu.be", "www.youtu.be" };
    
    private bool IsValidYoutubeLink(string link)
    {
        try
        {
            var authority = new UriBuilder(new Uri(link)).Uri.Authority.ToLower();
            return ValidAuthorities.Contains(authority);
        }
        catch
        {
            return false;
        }
    }
}