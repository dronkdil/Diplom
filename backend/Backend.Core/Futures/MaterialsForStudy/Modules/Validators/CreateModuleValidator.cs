using Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Requests;
using FluentValidation;

namespace Backend.Core.Futures.MaterialsForStudy.Modules.Validators;

public class CreateModuleValidator : AbstractValidator<CreateModuleDto>
{
    public CreateModuleValidator()
    {
        RuleFor(o => o.Title)
            .NotEmpty()
            .WithMessage("Назва обо'язкова");
        
        RuleFor(o => o.Description)
            .NotEmpty()
            .WithMessage("Опис обо'язковий");
    }
}