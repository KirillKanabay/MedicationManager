using MedicationManager.BusinessLogic.Medications.Contracts;

namespace MedicationManager.UI.Core.ViewModels.Medications.Creator
{
    public partial class MedicationCreatorViewModel
    {
        private readonly IMedicationService _medicationService;
        
        public MedicationCreatorViewModel(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }


    }
}