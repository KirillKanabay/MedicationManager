using FluentValidation;
using MedicationManager.UI.Common.Models;
using MedicationManager.UI.Core.Models.Medications;
using MedicationManager.UI.Core.Validators.Providers;

namespace MedicationManager.UI.Core.Models.Providers
{
    public class ProviderProductModel : BaseValidatableModel
    {
        private decimal _price;
        private MedicationModel _medication;
        protected override IValidationContext ValidationContext => new ValidationContext<ProviderProductModel>(this);
        
        public ProviderProductModel() : base(new ProviderProductModelValidator())
        {
        }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public MedicationModel Medication
        {
            get => _medication;
            set
            {
                _medication = value;
                OnPropertyChanged(nameof(Medication));
            }
        }
    }
}
