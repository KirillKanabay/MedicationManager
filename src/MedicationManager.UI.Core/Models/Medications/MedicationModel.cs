using FluentValidation;
using MedicationManager.UI.Common.Models;
using MedicationManager.UI.Core.Validators;

namespace MedicationManager.UI.Core.Models.Medications
{
    public class MedicationModel : BaseValidatableModel
    {
        private string _id;
        private string _name;
        private string _description;
        private string _manufacturer;
        private bool _receiptRequired;
        private int _count;
        protected override IValidationContext ValidationContext => new ValidationContext<MedicationModel>(this);

        public MedicationModel() : base(new MedicationModelValidator())
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

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(value));
            }
        }

        public string Manufacturer
        {
            get => _manufacturer;
            set
            {
                _manufacturer = value;
                OnPropertyChanged(nameof(_manufacturer));
            }
        }

        public bool ReceiptRequired
        {
            get => _receiptRequired;
            set
            {
                _receiptRequired = value;
                OnPropertyChanged(nameof(ReceiptRequired));
            }
        }

        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public override string ToString() => Name;
    }
}
