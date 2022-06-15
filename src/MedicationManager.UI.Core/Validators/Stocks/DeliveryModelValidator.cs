using FluentValidation;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Core.Models.Stock;

namespace MedicationManager.UI.Core.Validators.Stocks
{
    public class DeliveryModelValidator : AbstractValidator<DeliveryModel>
    {
        public DeliveryModelValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage(ValidationErrors.Stocks.EmptyDate);

            RuleFor(x => x.Provider)
                .NotEmpty()
                .WithMessage(ValidationErrors.EmptyField);

            RuleFor(x => x.Medication)
                .NotEmpty()
                .WithMessage(ValidationErrors.EmptyField);

            RuleFor(x => x.Count)
                .GreaterThan(0)
                .WithMessage(ValidationErrors.Stocks.InvalidCount);
        }
    }
}