using System;
using MedicationManager.BusinessLogic.Medications.Dtos;

namespace MedicationManager.BusinessLogic.Stock.Dtos
{
    public class BaseStockDto
    {
        public DateTime Date { get; set; }
        public string MedicationId { get; set; }
        public int Count { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal TotalPrice { get; set; }

        public MedicationDto Medication { get; set; }
    }
}
