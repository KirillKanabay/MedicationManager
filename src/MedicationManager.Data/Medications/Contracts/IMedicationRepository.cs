using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.Data.Medications.Documents;
using MedicationManager.Data.Medications.Filters;

namespace MedicationManager.Data.Medications.Contracts
{
    public interface IMedicationRepository
    {
        public Task<List<MedicationDocument>> GetAllMedicationsAsync();
        public Task<List<MedicationDocument>> GetMedicationsAsync(MedicationFilter filter);
        public Task<MedicationDocument> GetByIdAsync(string id);
        public Task UpdateAsync(MedicationDocument document);
    }
}
