using System.Threading.Tasks;
using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Medications.Dtos;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public class MedicationCreatorViewModel : MedicationImportViewModelBase
    {
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;

        public MedicationCreatorViewModel(IMedicationService medicationService, IMapper mapper)
        {
            _medicationService = medicationService;
            _mapper = mapper;
        }

        public override string Title => "Создание медикамента";

        protected override async Task SaveModel()
        {
            var dto = _mapper.Map<MedicationDto>(Model);

            await _medicationService.AddAsync(dto);

            await base.SaveModel();
        }
    }
}
