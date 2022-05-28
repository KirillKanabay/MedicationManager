using MedicationManager.Common.BusinessLogic;

namespace MedicationManager.BusinessLogic.Medications.Dtos
{
    public class MedicationListItemDto : BaseDto
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
    }
}
