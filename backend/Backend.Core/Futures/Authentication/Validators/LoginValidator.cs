using Backend.Core.Futures.Authentication.DTOs;
using FluentValidation;

namespace Backend.Core.Futures.Authentication.Validators;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(o => o.Email)
            .EmailAddress()
            .WithMessage("Почта не коректна");

        RuleFor(o => o.Password)
            .MinimumLength(6)
            .WithMessage("Пароль має мати мінімум 6 символів");
    }
}