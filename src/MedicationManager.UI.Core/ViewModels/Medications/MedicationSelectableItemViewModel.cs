using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Factories;
using MedicationManager.UI.Core.Models;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public class MedicationSelectableItemViewModel : BaseSelectableTableItemViewModel, 
        IModelBasedViewModel<MedicationModel>

    {
        private readonly MedicationDialogFactory _medicationDialogFactory;

        public MedicationSelectableItemViewModel(MedicationDialogFactory medicationDialogFactory)
        {
            _medicationDialogFactory = medicationDialogFactory;
        }
        
        public MedicationModel Model { get; private set; }

        public override TaskBasedCommand RemoveItemCommand { get; }
        public override TaskBasedCommand EditItemCommand => new(OpenEditorDialog);

        private async Task OpenEditorDialog()
        {
            var dialog = _medicationDialogFactory.CreateMedicationEditor(Model);

            await DialogHost.Show(dialog, HostRoots.DialogRoot);
        }

        public void Bind(MedicationModel model)
        {
            Model = model;
        }
    }
}
