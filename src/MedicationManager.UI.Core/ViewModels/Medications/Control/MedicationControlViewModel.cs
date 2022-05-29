using System.Collections.ObjectModel;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.ViewModels;

namespace MedicationManager.UI.Core.ViewModels.Medications.Control
{
    public partial class MedicationControlViewModel : BaseViewModel
    {
        public ObservableCollection<MedicationSelectableItemViewModel> Medications { get; private set; }

        public TaskBasedCommand OnLoadCommand => new(GetItemsCollection);
        public TaskBasedCommand GetItemsCollection => new(GetMedications);
    }
}
