using MedicationManager.BusinessLogic.Common;

namespace MedicationManager.BusinessLogic.Medications.Dtos
{
    public class MedicationDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public bool ReceiptRequired { get; set; }
        public int Count { get; set; }

        public override int GetHashCode()
        {
            return (Name?.GetHashCode() ?? 0 + Manufacturer?.GetHashCode() ?? 0);
        }
    }
}
