using System;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Factories;
using MedicationManager.UI.Core.Models;
using MedicationManager.UI.Core.Models.Medications;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public class MedicationSelectableItemViewModel : BaseSelectableTableItemViewModel, IModelBasedViewModel<MedicationModel>

    {
        private readonly MedicationDialogFactory _medicationDialogFactory;
        private readonly IMedicationService _medicationService;

        public MedicationSelectableItemViewModel(MedicationDialogFactory medicationDialogFactory, IMedicationService medicationService)
        {
            _medicationDialogFactory = medicationDialogFactory;
            _medicationService = medicationService;
        }

        public event EventHandler DeletionCompleted;
        public MedicationModel Model { get; private set; }

        public override TaskBasedCommand DeleteItemCommand => new(DeleteItem);
        public override TaskBasedCommand EditItemCommand => new(OpenEditorDialog);

        public void Bind(MedicationModel model)
        {
            Model = model;
        }
        
        private async Task OpenEditorDialog()
        {
            var dialog = _medicationDialogFactory.CreateMedicationEditor(Model);

            await DialogHost.Show(dialog, HostRoots.DialogRoot);
        }

        private async Task DeleteItem()
        {
            var dialog = _medicationDialogFactory.CreateMedicationDeletionDialog(Model, DeleteItemCallback);

            await DialogHost.Show(dialog, HostRoots.DialogRoot);
        }

        private async Task DeleteItemCallback()
        {
            await _medicationService.DeleteAsync(Model.Id);
            OnDeletionCompleted();
        }

        protected virtual void OnDeletionCompleted()
        {
            DeletionCompleted.Invoke(this, EventArgs.Empty);
        }
    }
}
