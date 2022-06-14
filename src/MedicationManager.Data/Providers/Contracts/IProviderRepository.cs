using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.Data.Providers.Documents;
using MedicationManager.Data.Providers.Filters;

namespace MedicationManager.Data.Providers.Contracts
{
    public interface IProviderRepository
    {
        Task<List<ProviderDocument>> GetAllProvidersAsync();
        Task<List<ProviderDocument>> GetProvidersAsync(ProviderFilter filter);
        Task<ProviderDocument> GetByIdAsync(string id, bool unSafe = false);
        Task UpdateAsync(ProviderDocument document);
        Task AddAsync(ProviderDocument document);
        Task DeleteAsync(string id);
    }
}