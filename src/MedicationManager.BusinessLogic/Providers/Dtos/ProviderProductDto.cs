using MedicationManager.BusinessLogic.Medications.Dtos;

namespace MedicationManager.BusinessLogic.Providers.Dtos
{
    public class ProviderProductDto
    {
        public MedicationDto Medication { get; set; }
        public decimal Price { get; set; }
    }
}
