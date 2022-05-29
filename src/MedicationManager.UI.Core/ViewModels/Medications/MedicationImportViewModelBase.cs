using MedicationManager.UI.Common.ViewModels;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public abstract class MedicationImportViewModelBase : BaseInteractionViewModel
    {
        private string _name;
        private string _description;
        private string _manufacturer;
        private bool _receiptRequired;
        private decimal _price;

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

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
    }
}
