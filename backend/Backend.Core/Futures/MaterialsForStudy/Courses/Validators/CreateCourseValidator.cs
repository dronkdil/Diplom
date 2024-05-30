using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
using Backend.Core.Interfaces.UrlTypeValidator;
using Backend.Domain.Constants.Validation;
using FluentValidation;

namespace Backend.Core.Futures.MaterialsForStudy.Courses.Validators;

public class CreateCourseValidator : AbstractValidator<CreateCourseDto>
{
    public CreateCourseValidator(IUrlTypeCorrectValidator validator)
    {
        RuleFor(o => o.Title)
            .MinimumLength(1)
            .WithMessage("Назва обов'язкова");
        
        RuleFor(o => o.LimitOfStudents)
            .GreaterThanOrEqualTo(CourseValidationConstants.MinLimitOfStudents)
            .WithMessage($"Мінімальне значення: {CourseValidationConstants.MinLimitOfStudents}");
        
        RuleFor(o => o.ImageUrl)
            .Must((entity, value, context) => validator.Valid(value, UrlTypes.Image, required: true))
            .WithMessage("Некоректне зображення");
    }
}