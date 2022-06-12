using MedicationManager.BusinessLogic.Medications.Dtos;

namespace MedicationManager.BusinessLogic.Providers.Dtos
{
    public class ProviderProductDto
    {
        public string MedicationId { get; set; }
        public decimal Price { get; set; }

        public MedicationDto Medication { get; set; }
    }
}
