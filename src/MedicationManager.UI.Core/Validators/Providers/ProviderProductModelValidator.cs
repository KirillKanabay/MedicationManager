using FluentValidation;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.Validators.Providers
{
    public class ProviderProductModelValidator : AbstractValidator<ProviderProductModel>
    {
        public ProviderProductModelValidator()
        {
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage(ValidationErrors.Providers.InvalidPrice);

            RuleFor(x => x.Medication)
                .NotNull()
                .WithMessage(ValidationErrors.Providers.ProductIsNull);
        }
    }
}
