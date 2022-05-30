using MedicationManager.UI.Common.Models;

namespace MedicationManager.UI.Core.Models
{
    public class MedicationModel : BaseModel
    {
        private string _id;
        private string _name;
        private string _description;
        private string _manufacturer;
        private bool _receiptRequired;
        private decimal _price;

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
