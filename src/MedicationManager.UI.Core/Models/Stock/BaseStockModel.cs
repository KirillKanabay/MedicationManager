using System;
using FluentValidation;
using MedicationManager.UI.Common.Models;
using MedicationManager.UI.Core.Models.Medications;

namespace MedicationManager.UI.Core.Models.Stock
{
    public abstract class BaseStockModel : BaseValidatableModel
    {
        protected BaseStockModel(IValidator validator) : base(validator)
        {
        }

        public DateTime? Date { get; set; }
        public string MedicationId { get; set; }
        public int Count { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal TotalPrice { get; set; }

        public MedicationModel? Medication { get; set; }
    }
}
