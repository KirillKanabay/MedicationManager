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
    public class MedicationEditorViewModel : MedicationImportViewModelBase, IModelBasedViewModel<MedicationImportModel>
    {
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;

        public MedicationEditorViewModel(IMedicationService medicationService, IMapper mapper)
        {
            _medicationService = medicationService;
            _mapper = mapper;
        }

        public string Id { get; set; }

        public TaskBasedCommand OnLoadedCommand => new(GetModel);

        private async Task GetModel()
        {
            if (Id == null)
            {
                throw new ArgumentNullException();
            }

            var dto = await _medicationService.GetByIdAsync(Id);

            if (dto == null)
            {
                throw new NullReferenceException($"Медикамент с Id:{Id} не найден");
            }

            var model = _mapper.Map<MedicationImportModel>(dto);
            model.Id = Id;

            Bind(model);
        }

        protected override async Task SaveModel()
        {
            var dto = _mapper.Map<MedicationDto>(Model);
            await _medicationService.UpdateAsync(dto);
        }

        public void Bind(MedicationImportModel model)
        {
            Model = model;
        }
    }
}