using System;
using System.Threading.Tasks;
using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public class MedicationEditorViewModel : BaseInteractionViewModel, IModelBasedViewModel<MedicationImportModel>
    {
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;

        public MedicationEditorViewModel(IMedicationService medicationService, IMapper mapper)
        {
            _medicationService = medicationService;
            _mapper = mapper;
        }

        public string Id { get; set; }

        private MedicationImportModel _model;
        public MedicationImportModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public TaskBasedCommand OnLoadedCommand => new(GetModel);
        public TaskBasedCommand SaveItemCommand => new(SaveModel);

        private async Task GetModel()
        {
            if (Id == null)
            {
                throw new ArgumentNullException();
            }

            var dto = await _medicationService.GetById(Id);

            if (dto == null)
            {
                throw new NullReferenceException($"Медикамент с Id:{Id} не найден");
            }

            var model = _mapper.Map<MedicationImportModel>(dto);
            model.Id = Id;

            Bind(model);
        }

        private async Task SaveModel()
        {
            var dto = _mapper.Map<MedicationDto>(_model);
            await _medicationService.Update(dto);
        }

        public void Bind(MedicationImportModel model)
        {
            Model = model;
        }
    }
}