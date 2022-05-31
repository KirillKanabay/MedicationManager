using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.Data.Medications.Documents;
using MedicationManager.Data.Medications.Filters;

namespace MedicationManager.Data.Medications.Contracts
{
    public interface IMedicationRepository
    {
        Task<List<MedicationDocument>> GetAllMedicationsAsync();
        Task<List<MedicationDocument>> GetMedicationsAsync(MedicationFilter filter);
        Task<MedicationDocument> GetByIdAsync(string id);
        Task UpdateAsync(MedicationDocument document);
        Task AddAsync(MedicationDocument document);
        Task DeleteAsync(string id);
    }
}
