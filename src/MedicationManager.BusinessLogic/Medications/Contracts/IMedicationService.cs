using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.BusinessLogic.Medications.Dtos;

namespace MedicationManager.BusinessLogic.Medications.Contracts
{
    public interface IMedicationService
    {
        Task<List<MedicationListItemDto>> ListAllAsync();
        Task<MedicationDto> GetByIdAsync(string id);
        Task UpdateAsync(MedicationDto dto);
        Task AddAsync(MedicationDto dto);
    }
}
