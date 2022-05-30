using System;
using MedicationManager.UI.Common;
using MedicationManager.UI.Common.Dialogs.DialogControl;
using MedicationManager.UI.Common.Dialogs.Factories;
using MedicationManager.UI.Common.ViewModels;
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

        public DialogControlView CreateMedicationCreator(IImportObserverViewModel observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException();
            }
            var vm = _viewModelLocator.Resolve<MedicationCreatorViewModel>();
            
            vm.ImportCompleted += observer.ImportCompletedHandler;

            return CreateDialogControlView(vm);
        }

        public DialogControlView CreateMedicationEditor(MedicationModel model)
        {
            var vm = _viewModelLocator.Resolve<MedicationEditorViewModel>();

            vm.Bind(model); 

            return CreateDialogControlView(vm);
        }
    }
}