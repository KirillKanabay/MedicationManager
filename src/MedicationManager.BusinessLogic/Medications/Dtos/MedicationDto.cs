using MedicationManager.Common.BusinessLogic;

namespace MedicationManager.BusinessLogic.Medications.Dtos
{
    public class MedicationDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public bool ReceiptRequired { get; set; }
        public decimal Price { get; set; }
    }
}
