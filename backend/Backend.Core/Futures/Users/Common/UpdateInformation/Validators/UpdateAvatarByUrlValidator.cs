using System.Globalization;
using System.Net;
using Backend.Core.Futures.Users.Common.UpdateInformation.DTOs.Requests;
using Backend.Core.Interfaces.UrlTypeValidator;
using FluentValidation;

namespace Backend.Core.Futures.Users.Common.UpdateInformation.Validators;

public class UpdateAvatarByUrlValidator : AbstractValidator<UpdateAvatarByUrlDto>
{
    public UpdateAvatarByUrlValidator(IUrlTypeCorrectValidator validator)
    {
        RuleFor(o => o.AvatarUrl)
            .Must((entity, value, context) => validator.Valid(value, UrlTypes.Image, required: false))
            .WithMessage("Некоректне зображення");
    }
}