using System.Collections.Generic;
using MedicationManager.Common.Data.Documents;

namespace MedicationManager.Data.Providers.Documents
{
    public class ProviderDocument : DocumentBase
    {
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public string Address { get; set; }
        public List<string> AvailableMedications { get; set; }
    }
}