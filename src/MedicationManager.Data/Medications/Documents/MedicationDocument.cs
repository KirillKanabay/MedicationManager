using System.Collections.Generic;
using MedicationManager.Common.Data.Documents;

namespace MedicationManager.Data.Medications.Documents
{
    public class MedicationDocument : DocumentBase
    {
        public string Name { get; set; }
        public int CountInStock { get; set; }
        public List<string> Analogues { get; set; }
    }
}
