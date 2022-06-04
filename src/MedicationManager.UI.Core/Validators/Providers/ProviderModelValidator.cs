using FluentValidation;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.Validators.Providers
{
    public class ProviderModelValidator : AbstractValidator<ProviderModel>
    {
        public ProviderModelValidator()
        {
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage(ValidationErrors.EmptyField);

            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage(ValidationErrors.EmptyField);

            RuleFor(x => x.Director)
                .NotEmpty()
                .WithMessage(ValidationErrors.EmptyField);
        }
    }
}
