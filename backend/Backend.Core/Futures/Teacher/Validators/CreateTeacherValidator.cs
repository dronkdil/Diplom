using System.Data;
using Backend.Core.Futures.Teacher.DTOs;
using Backend.Core.Gateways;
using FluentValidation;

namespace Backend.Core.Futures.Teacher.Validators;

public class CreateTeacherValidator : AbstractValidator<CreateTeacherDto>
{
    public CreateTeacherValidator(IUserGateway userGateway)
    {
        RuleFor(o => o.Email)
            .EmailAddress()
            .WithMessage("Пошта некоректна")
            .MustAsync(async (entity, value, context) => await userGateway.IsExistsByEmailAsync(value) == false)
            .WithMessage("Пошта вже занята");
    }
}