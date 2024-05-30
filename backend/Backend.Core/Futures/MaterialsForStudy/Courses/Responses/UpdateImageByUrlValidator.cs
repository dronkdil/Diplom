using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
using Backend.Core.Interfaces.UrlTypeValidator;
using FluentValidation;

namespace Backend.Core.Futures.MaterialsForStudy.Courses.Responses;

public class UpdateImageByUrlValidator : AbstractValidator<UpdateImageByUrlDto>
{
    public UpdateImageByUrlValidator(IUrlTypeCorrectValidator validator)
    {
        RuleFor(o => o.ImageUrl)
            .Must((entity, value, context) => validator.Valid(value, UrlTypes.Image, required: true))
            .WithMessage("Некоректне зображення");
    }
}