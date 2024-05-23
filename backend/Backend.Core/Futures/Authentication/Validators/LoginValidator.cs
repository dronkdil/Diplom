using Backend.Core.Futures.Authentication.DTOs;
using Backend.Domain.Constants;
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
            .MinimumLength(AuthenticationConstants.MinPasswordLength)
            .WithMessage($"Пароль має мати мінімум {AuthenticationConstants.MinPasswordLength} символів");
    }
}