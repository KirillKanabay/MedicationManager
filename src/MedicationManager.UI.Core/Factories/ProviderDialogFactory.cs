using System;
using System.Threading.Tasks;
using MedicationManager.UI.Common;
using MedicationManager.UI.Common.Dialogs.ConfirmDialog;
using MedicationManager.UI.Common.Dialogs.DialogControl;
using MedicationManager.UI.Common.Dialogs.Factories;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models.Medications;
using MedicationManager.UI.Core.Models.Providers;
using MedicationManager.UI.Core.ViewModels.Medications;
using MedicationManager.UI.Core.ViewModels.Providers;
using MedicationManager.UI.Core.ViewModels.Providers.Import.Creator;

namespace MedicationManager.UI.Core.Factories
{
    public class ProviderDialogFactory : DialogAbstractFactory
    {
        private readonly ViewModelLocator _viewModelLocator;

        public ProviderDialogFactory(ViewModelLocator viewModelLocator)
        {
            _viewModelLocator = viewModelLocator;
        }

        public DialogControlView CreateProviderCreator(IImportObserverViewModel observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException();
            }

            var vm = _viewModelLocator.Resolve<ProviderCreatorViewModel>();

            vm.ImportCompleted += observer.ImportCompletedHandler;

            return CreateDialogControlView(vm);
        }

        public DialogControlView CreateProviderConcreteProductCreator(ProviderProductCreatorViewModel creatorVm)
        {
            if (creatorVm == null)
            {
                throw new ArgumentNullException(nameof(creatorVm));
            }

            var vm = _viewModelLocator.Resolve<ProviderConcreteProductCreatorViewModel>();

            vm.ProductCreated += creatorVm.OnProductCreated;

            return CreateDialogControlView(vm);
        }

        public DialogControlView CreateMedicationEditor(ProviderModel model)
        {
            var vm = _viewModelLocator.Resolve<ProviderEditorViewModel>();

            vm.Bind(model);

            return CreateDialogControlView(vm);
        }

        public ConfirmDialogView CreateMedicationDeletionDialog(MedicationModel model, Func<Task> deletionCallback)
        {
            var vm = new ConfirmDialogViewModel(deletionCallback)
            {
                Title = UiConstants.Medications.DeletionDialogTitle,
                Message = $"{UiConstants.Medications.DeletionDialogMessage}{model.Name}"
            };

            return CreateConfirmDialogView(vm);
        }
    }
}
