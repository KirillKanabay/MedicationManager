using MedicationManager.Data.Common.Documents;

namespace MedicationManager.Data.Providers.Documents
{
    public class ProviderProductDocument : DocumentBase
    {
        public string MedicationId { get; set; }
        public decimal Price { get; set; }
    }
}