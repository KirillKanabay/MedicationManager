using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.BusinessLogic.Medications.Dtos;

namespace MedicationManager.BusinessLogic.Medications.Contracts
{
    public interface IMedicationService
    {
        Task<List<MedicationListItemDto>> ListAll();
        Task<MedicationDto> GetById(string id);
        Task Update(MedicationDto dto);
    }
}
