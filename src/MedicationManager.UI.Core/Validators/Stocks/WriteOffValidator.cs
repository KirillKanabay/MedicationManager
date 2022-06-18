using System;
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
                .WithMessage(ValidationErrors.Stocks.EmptyDate)
                .Must(CheckDateForFuture)
                .WithMessage(ValidationErrors.FutureDate);
            
            RuleFor(x => x.Medication)
                .NotEmpty()
                .WithMessage(ValidationErrors.ComboBoxEmptyValue);

            RuleFor(x => x.Count)
                .GreaterThan(0)
                .WithMessage(ValidationErrors.Stocks.InvalidCount)
                .Must(CheckWriteOffCount)
                .WithMessage(ValidationErrors.Stocks.UnavailableCount);

            RuleFor(x => x.PricePerItem)
                .GreaterThan(0)
                .WithMessage(ValidationErrors.Stocks.InvalidPrice);
        }

        private bool CheckDateForFuture(DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return false;
            }

            var todayDate = DateTime.Today;
            var date = dateTime.Value.Date;

            return date <= todayDate;
        }

        private bool CheckWriteOffCount(WriteOffModel model, int count)
        {
            if (model.Medication is null)
            {
                return false;
            }

            return model.Medication.Count >= count;
        }
    }
}