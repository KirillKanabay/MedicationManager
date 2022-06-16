using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentValidation;
using MedicationManager.UI.Common.Models;
using MedicationManager.UI.Core.Validators.Providers;

namespace MedicationManager.UI.Core.Models.Providers
{
    public class ProviderModel : BaseValidatableModel
    {
        private string _id;
        private string _companyName;
        private string _director;
        private string _address;
        private List<ProviderProductModel> _availableMedications;

        protected override IValidationContext ValidationContext => new ValidationContext<ProviderModel>(this);

        public ProviderModel() : base(new ProviderModelValidator())
        {
        }

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string CompanyName
        {
            get => _companyName;
            set
            {
                _companyName = value;
                OnPropertyChanged(nameof(CompanyName));
            }
        }

        public string Director
        {
            get => _director;
            set
            {
                _director = value;
                OnPropertyChanged(nameof(Director));
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public List<ProviderProductModel> AvailableMedications
        {
            get => _availableMedications;
            set
            {
                _availableMedications = value;
                OnPropertyChanged(nameof(AvailableMedications));
            }
        }

        public override string ToString()
        {
            return CompanyName;
        }
    }
}
