using System;
using MedicationManager.BusinessLogic.Medications.Dtos;

namespace MedicationManager.BusinessLogic.Stock.Dtos
{
    public class BaseStockDto
    {
        public DateTime Date { get; set; }
        public string MedicationId { get; set; }
        public int Count { get; set; }
        public int PricePerItem { get; set; }
        public int TotalPrice { get; set; }

        public MedicationDto Medication { get; set; }
    }
}
