using MedicationManager.UI.Common;
using MedicationManager.UI.Common.Dialogs.DialogControl;
using MedicationManager.UI.Common.Dialogs.Factories;
using MedicationManager.UI.Core.Models;
using MedicationManager.UI.Core.ViewModels.Medications;

namespace MedicationManager.UI.Core.Factories
{
    public class MedicationDialogFactory : DialogAbstractFactory
    {
        private readonly ViewModelLocator _viewModelLocator;

        public MedicationDialogFactory(ViewModelLocator viewModelLocator)
        {
            _viewModelLocator = viewModelLocator;
        }

        public DialogControlView CreateMedicationCreator()
        {
            var vm = _viewModelLocator.Resolve<MedicationCreatorViewModel>();

            return CreateDialogControlView(vm);
        }

        public DialogControlView CreateMedicationEditor(string id)
        {
            var vm = _viewModelLocator.Resolve<MedicationEditorViewModel>();
            
            vm.Id = id;

            return CreateDialogControlView(vm);
        }
    }
}