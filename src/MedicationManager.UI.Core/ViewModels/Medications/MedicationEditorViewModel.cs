using System;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public class MedicationEditorViewModel : MedicationImportViewModelBase, IModelBasedViewModel<MedicationModel>
    {
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;
        private readonly ISnackbarMessageQueue _snackbarMessageQueue;
        private MedicationModel _originalModel;

        public MedicationEditorViewModel(IMedicationService medicationService, IMapper mapper, ISnackbarMessageQueue snackbarMessageQueue)
        {
            _medicationService = medicationService;
            _mapper = mapper;
            _snackbarMessageQueue = snackbarMessageQueue;
        }

        public override string Title => "Редактирование медикамента";

        protected override async Task SaveModel()
        {
            LoaderVisibility = Visibility.Visible;

            var dto = _mapper.Map<MedicationDto>(Model);
            await _medicationService.UpdateAsync(dto);

            _mapper.Map(Model, _originalModel);
            _snackbarMessageQueue.Enqueue(SnackbarConstants.MedicationEditedMessage, SnackbarConstants.CloseSnackbarName, ()=>{});
            
            await base.SaveModel();
        }

        public void Bind(MedicationModel model)
        {
            _originalModel = model;
            
            Model = _mapper.Map<MedicationModel>(model);
        }
    }
}