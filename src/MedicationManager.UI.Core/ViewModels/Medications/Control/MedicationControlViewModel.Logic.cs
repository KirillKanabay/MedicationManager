using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.Common.Extensions;
using MedicationManager.UI.Common;
using MedicationManager.UI.Core.Models;

namespace MedicationManager.UI.Core.ViewModels.Medications.Control
{
    public partial class MedicationControlViewModel
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

        private async Task GetMedications()
        {
            var dtos = await _medicationService.ListAll();
            
            var medicationViewModels = dtos.Select(dto =>
            {
                var viewModel = _viewModelLocator.Resolve<MedicationSelectableItemViewModel>();
                viewModel.Model = _mapper.Map<MedicationSelectableItemModel>(dto);

                return viewModel;
            }).ToList();

            Medications.Assign(medicationViewModels);
        }
    }
}