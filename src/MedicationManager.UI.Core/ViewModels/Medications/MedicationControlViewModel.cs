using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.Common.Extensions;
using MedicationManager.UI.Common;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Factories;
using MedicationManager.UI.Core.Models;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public class MedicationControlViewModel : BaseViewModel, IImportObserverViewModel
    {
        private readonly MedicationDialogFactory _medicationDialogFactory;
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;
        private readonly ViewModelLocator _viewModelLocator;

        public MedicationControlViewModel(IMedicationService medicationService, IMapper mapper, ViewModelLocator viewModelLocator, MedicationDialogFactory medicationDialogFactory)
        {
            _medicationService = medicationService;
            _mapper = mapper;
            _viewModelLocator = viewModelLocator;
            _medicationDialogFactory = medicationDialogFactory;

            Medications = new ObservableCollection<MedicationSelectableItemViewModel>();
            Filter = new MedicationFilterModel();
        }

        public ObservableCollection<MedicationSelectableItemViewModel> Medications { get; }
        public MedicationFilterModel Filter { get; }

        public TaskBasedCommand OnLoadCommand => new(GetMedications);
        public TaskBasedCommand GetItemsCollection => new(GetMedications);
        public TaskBasedCommand OpenCreatorDialogCommand => new(OpenCreatorDialog);
        public TaskBasedCommand FilterItemsCommand => new(FilterMedications);
        
        private async Task GetMedications()
        {
            var dtos = await _medicationService.ListAllAsync();

            var medicationViewModels = dtos.Select(dto =>
            {
                var model = _mapper.Map<MedicationModel>(dto);
                var viewModel = _viewModelLocator.Resolve<MedicationSelectableItemViewModel, MedicationModel>(model);

                return viewModel;
            }).ToList();

            Medications.Assign(medicationViewModels);
        }

        private async Task FilterMedications()
        {
            var filterDto = _mapper.Map<MedicationFilterDto>(Filter);

            var dtos = await _medicationService.ListAsync(filterDto);

            var medicationViewModels = dtos.Select(dto =>
            {
                var model = _mapper.Map<MedicationModel>(dto);
                var viewModel = _viewModelLocator.Resolve<MedicationSelectableItemViewModel, MedicationModel>(model);

                return viewModel;
            }).ToList();

            Medications.Assign(medicationViewModels);
        }

        private async Task OpenCreatorDialog()
        {
            var dialog = _medicationDialogFactory.CreateMedicationCreator(this);

            await DialogHost.Show(dialog, HostRoots.DialogRoot);
        }

        public async void ImportCompletedHandler(object? sender, EventArgs e)
        {
            await GetMedications();
        }
    }
}
