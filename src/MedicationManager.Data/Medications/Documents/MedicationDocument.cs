using MedicationManager.Data.Common.Documents;

namespace MedicationManager.Data.Medications.Documents
{
    public class MedicationDocument : DocumentBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public bool ReceiptRequired { get; set; }
        public decimal Price { get; set; }
    }
}
