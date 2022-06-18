using System;
using FluentValidation;
using MedicationManager.UI.Common.Models;
using MedicationManager.UI.Core.Models.Medications;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.Models.Stock
{
    public abstract class BaseStockModel : BaseValidatableModel
    {
        private ProviderProductModel _selectedProduct;
        private DateTime? _date;
        private string _medicationId;
        private int _count;
        private decimal _pricePerItem;
        private decimal _totalPrice;

        protected BaseStockModel(IValidator validator) : base(validator)
        {
        }

        public DateTime? Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string MedicationId
        {
            get => _medicationId;
            set
            {
                _medicationId = value;
                OnPropertyChanged(nameof(MedicationId));
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

        public decimal PricePerItem
        {
            get => _pricePerItem;
            set
            {
                _pricePerItem = value;
                OnPropertyChanged(nameof(PricePerItem));
            }
        }

        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public MedicationModel? Medication { get; set; }

        public ProviderProductModel SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                Medication = _selectedProduct?.Medication;
            }
        }
    }
}
