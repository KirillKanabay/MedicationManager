using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.BusinessLogic.Medications.Dtos;

namespace MedicationManager.BusinessLogic.Medications.Contracts
{
    public interface IMedicationService
    {
        Task<List<MedicationDto>> ListAsync(MedicationFilterDto filter);
        Task<List<MedicationDto>> ListAllAsync();
        Task<MedicationDto> GetByIdAsync(string id);
        Task UpdateAsync(MedicationDto dto);
        Task AddAsync(MedicationDto dto);
        Task DeleteAsync(string id);
        Task AddCountAsync(string id, int count);
        Task SubtractCountAsync(string id, int count);
        internal Task<MedicationDto> GetByIdUnsafeAsync(string id);
    }
}
