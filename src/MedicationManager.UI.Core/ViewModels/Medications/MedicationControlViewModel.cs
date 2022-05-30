using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.Common.Extensions;
using MedicationManager.UI.Common;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public class MedicationControlViewModel : BaseViewModel
    {
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;
        private readonly ViewModelLocator _viewModelLocator;

        public MedicationControlViewModel(IMedicationService medicationService, IMapper mapper, ViewModelLocator viewModelLocator)
        {
            _medicationService = medicationService;
            _mapper = mapper;
            _viewModelLocator = viewModelLocator;

            Medications = new ObservableCollection<MedicationSelectableItemViewModel>();
        }

        public ObservableCollection<MedicationSelectableItemViewModel> Medications { get; }

        public TaskBasedCommand OnLoadCommand => new(GetMedications);
        public TaskBasedCommand GetItemsCollection => new(GetMedications);

        private async Task GetMedications()
        {
            var dtos = await _medicationService.ListAll();

            var medicationViewModels = dtos.Select(dto =>
            {
                var model = _mapper.Map<MedicationSelectableItemModel>(dto);
                var viewModel = _viewModelLocator.Resolve<MedicationSelectableItemViewModel, MedicationSelectableItemModel>(model);

                return viewModel;
            }).ToList();

            Medications.Assign(medicationViewModels);
        }
    }
}
