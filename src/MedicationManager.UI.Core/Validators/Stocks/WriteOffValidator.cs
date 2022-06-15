using FluentValidation;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Core.Models.Stock;

namespace MedicationManager.UI.Core.Validators.Stocks
{
    public class WriteOffValidator : AbstractValidator<WriteOffModel>
    {
        public WriteOffValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage(ValidationErrors.Stocks.EmptyDate);
            
            RuleFor(x => x.Medication)
                .NotEmpty()
                .WithMessage(ValidationErrors.EmptyField);

            RuleFor(x => x.Count)
                .GreaterThan(0)
                .WithMessage(ValidationErrors.Stocks.InvalidCount);

            RuleFor(x => x.PricePerItem)
                .GreaterThan(0)
                .WithMessage(ValidationErrors.Stocks.InvalidPrice);
        }
    }
}