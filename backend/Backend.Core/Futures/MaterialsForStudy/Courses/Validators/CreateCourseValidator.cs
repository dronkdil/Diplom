using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
using Backend.Domain.Constants.Validation;
using FluentValidation;

namespace Backend.Core.Futures.MaterialsForStudy.Courses.Validators;

public class CreateCourseValidator : AbstractValidator<CreateCourseDto>
{
    public CreateCourseValidator()
    {
        RuleFor(o => o.Title)
            .MinimumLength(1)
            .WithMessage("Назва обов'язкова");
        
        RuleFor(o => o.LimitOfStudents)
            .GreaterThan(CourseValidationConstants.MinLimitOfStudents)
            .WithMessage($"Мінімальне значення: {CourseValidationConstants.MinLimitOfStudents}");
    }
}