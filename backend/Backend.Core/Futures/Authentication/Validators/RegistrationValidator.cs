using Backend.Domain.DTOs;
using FluentValidation;

namespace Backend.Core.Futures.Authentication.Validators;

public class RegistrationValidator : AbstractValidator<RegistrationStudentDto>
{
    public RegistrationValidator()
    {
        RuleFor(o => o.Email)
            .EmailAddress()
            .WithMessage("Пошта не коректна")
            .MustAsync(async (entity, value, c) =>
            {
                // return (await dataContext.SupplierSettings.AnyAsync(o => o.PublicName.ToLower() == value.ToLower(), cancellationToken: c)) == false;
                return true;
            })
            .WithMessage("Така пошта вже використовується");

        RuleFor(o => o.Password)
            .MinimumLength(6)
            .WithMessage("Пароль має мати мінімум 6 символів");

        RuleFor(o => o.Birthday)
            .Must((entity, value, context) => value < DateTime.Now.AddYears(-10))
            .WithMessage("Вам має бути більше 10 років");
        
        RuleFor(o => o.EducationalStatus)
            .MinimumLength(1)
            .WithMessage("Ваш освітній статус є обов'язковим полем")
            .MaximumLength(100)
            .WithMessage("Максимум 100 символів");
        
        RuleFor(o => o.FirstName)
            .MinimumLength(1)
            .WithMessage("Ім'я є обов'язковим полем");
    }
}