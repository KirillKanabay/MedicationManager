using FluentValidation;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Core.Models;
using MedicationManager.UI.Core.Models.Medications;

namespace MedicationManager.UI.Core.Validators
{
    public class MedicationModelValidator : AbstractValidator<MedicationModel>
    {
        public MedicationModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ValidationErrors.EmptyField);

            RuleFor(x => x.Manufacturer)
                .NotEmpty()
                .WithMessage(ValidationErrors.EmptyField);
        }
    }
}
