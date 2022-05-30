using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.Data.Medications.Contracts;
using MedicationManager.Data.Medications.Documents;

namespace MedicationManager.BusinessLogic.Medications.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _medicationRepository;
        private readonly IMapper _mapper;

        public MedicationService(IMedicationRepository medicationRepository, IMapper mapper)
        {
            _medicationRepository = medicationRepository;
            _mapper = mapper;
        }

        public async Task<List<MedicationListItemDto>> ListAll()
        {
            var medications = await _medicationRepository.GetAllMedicationsAsync();

            var dtos = _mapper.Map<List<MedicationListItemDto>>(medications);

            return dtos;
        }

        public async Task<MedicationDto> GetById(string id)
        {
            var medication = await _medicationRepository.GetByIdAsync(id);

            var dto = _mapper.Map<MedicationDto>(medication);

            return dto;
        }

        public async Task Update(MedicationDto dto)
        {
            var medication = _mapper.Map<MedicationDocument>(dto);

            await _medicationRepository.UpdateAsync(medication);
        }
    }
}
