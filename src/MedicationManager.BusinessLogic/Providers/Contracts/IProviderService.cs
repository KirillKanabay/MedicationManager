using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.BusinessLogic.Providers.Dtos;

namespace MedicationManager.BusinessLogic.Providers.Contracts
{
    public interface IProviderService
    {
        Task<List<ProviderDto>> ListAsync(ProviderFilterDto filter);
        Task<List<ProviderDto>> ListAllAsync();
        Task<ProviderDto> GetByIdAsync(string id);
        Task UpdateAsync(ProviderDto dto);
        Task AddAsync(ProviderDto dto);
        Task DeleteAsync(string id);

        internal Task<ProviderDto> GetByIdUnsafeAsync(string id);
    }
}