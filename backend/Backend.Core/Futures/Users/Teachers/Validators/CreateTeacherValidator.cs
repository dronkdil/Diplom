using Backend.Core.Futures.Users.Teachers.DTOs;
using Backend.Core.Gateways;
using Backend.Domain.Constants;
using FluentValidation;

namespace Backend.Core.Futures.Users.Teachers.Validators;

public class CreateTeacherValidator : AbstractValidator<CreateTeacherDto>
{
    public CreateTeacherValidator(IUserGateway userGateway)
    {
        RuleFor(o => o.Email)
            .EmailAddress()
            .WithMessage("Пошта некоректна")
            .MustAsync(async (entity, value, context) => await userGateway.IsExistsByEmailAsync(value) == false)
            .WithMessage("Пошта вже занята");
        
        RuleFor(o => o.Password)
            .MinimumLength(AuthenticationConstants.MinPasswordLength)
            .WithMessage($"Пароль має мати мінімум {AuthenticationConstants.MinPasswordLength} символів");
    }
}