using System.Collections.ObjectModel;
using System.Diagnostics;
using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.Common.UI.Commands;
using MedicationManager.Common.UI.ViewModels;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public partial class MedicationControlViewModel : BaseViewModel
    {
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;

        public MedicationControlViewModel(IMedicationService medicationService, IMapper mapper)
        {
            _medicationService = medicationService;
            _mapper = mapper;

            Medications = new ObservableCollection<MedicationSelectableItemViewModel>();
        }

        public ObservableCollection<MedicationSelectableItemViewModel> Medications { get; private set; }

        public TaskBasedCommand OnLoadCommand => new(GetItemsCollection);
        public TaskBasedCommand GetItemsCollection => new(GetMedications, _ => Debug.Write(_.Message));
    }
}
