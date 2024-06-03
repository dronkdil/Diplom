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
            .Must((entity, value, context) => value.StartsWith("https://www.youtube.com/"))
            .WithMessage("Некоректний формат");
    }
}