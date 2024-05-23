using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
using FluentValidation;

namespace Backend.Core.Futures.MaterialsForStudy.Courses.Validators;

public class CreateCourseValidator : AbstractValidator<CreateCourseDto>
{
    public CreateCourseValidator()
    {
        RuleFor(o => o.Title)
            .MinimumLength(1)
            .WithMessage("Назва обов'язкова");
    }
}