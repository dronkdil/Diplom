using System.Globalization;
using Backend.Core.Futures.Authentication.DTOs;
using Backend.Core.Gateways;
using Backend.Domain.Constants;
using FluentValidation;

namespace Backend.Core.Futures.Authentication.Validators;

public class RegistrationValidator : AbstractValidator<RegistrationStudentDto>
{
    public RegistrationValidator(IUserGateway userGateway)
    {
        RuleFor(o => o.Email)
            .EmailAddress()
            .WithMessage("Пошта не коректна")
            .MustAsync(async (entity, value, c) => await userGateway.IsExistsByEmailAsync(value) == false)
            .WithMessage("Така пошта вже використовується");

        RuleFor(o => o.Password)
            .MinimumLength(AuthenticationConstants.MinPasswordLength)
            .WithMessage($"Пароль має мати мінімум {AuthenticationConstants.MinPasswordLength} символів");

        RuleFor(o => o.Birthday)
            .Must((entity, value, context) => DateTime.ParseExact(value, "dd.MM.yyyy", CultureInfo.CurrentCulture) < DateTime.Now.AddYears(-AuthenticationConstants.MinYears))
            .WithMessage($"Вам має бути більше {AuthenticationConstants.MinYears} років");

        RuleFor(o => o.EducationalStatus)
            .MinimumLength(1)
            .WithMessage("Ваш освітній статус є обов'язковим полем");
        
        RuleFor(o => o.FirstName)
            .MinimumLength(1)
            .WithMessage("Ім'я є обов'язковим полем");
    }
}