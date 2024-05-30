using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;
using Backend.Core.Interfaces.UrlTypeValidator;
using FluentValidation;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.Validators;

public class CreateLessonValidator : AbstractValidator<CreateLessonDto>
{
    public CreateLessonValidator(IUrlTypeCorrectValidator validator)
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
            .Must((entity, value, context) => validator.Valid(value, UrlTypes.Video, required: true))
            .WithMessage("Некоректний формат");
    }
}