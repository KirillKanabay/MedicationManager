using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.BusinessLogic.Medications.Dtos;

namespace MedicationManager.BusinessLogic.Providers.Contracts
{
    public interface IProviderService
    {
        Task<List<MedicationDto>> ListAsync(MedicationFilterDto filter);
        Task<List<MedicationDto>> ListAllAsync();
        Task<MedicationDto> GetByIdAsync(string id);
        Task UpdateAsync(MedicationDto dto);
        Task AddAsync(MedicationDto dto);
        Task DeleteAsync(string id);
    }
}