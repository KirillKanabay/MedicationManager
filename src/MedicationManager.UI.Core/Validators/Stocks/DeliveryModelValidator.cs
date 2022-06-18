using System;
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
                .WithMessage(ValidationErrors.Stocks.EmptyDate)
                .Must(CheckDateForFuture)
                .WithMessage(ValidationErrors.FutureDate);

            RuleFor(x => x.Provider)
                .NotNull()
                .WithMessage(ValidationErrors.ComboBoxEmptyValue);

            RuleFor(x => x.Medication)
                .NotNull()
                .WithMessage(ValidationErrors.EmptyField);

            RuleFor(x => x.SelectedProduct)
                .NotNull()
                .WithMessage(ValidationErrors.ComboBoxEmptyValue);

            RuleFor(x => x.Count)
                .GreaterThan(0)
                .WithMessage(ValidationErrors.Stocks.InvalidCount);
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
    }
}