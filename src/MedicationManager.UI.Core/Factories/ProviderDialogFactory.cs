using System;
using System.Threading.Tasks;
using MedicationManager.UI.Common;
using MedicationManager.UI.Common.Dialogs.ConfirmDialog;
using MedicationManager.UI.Common.Dialogs.DialogControl;
using MedicationManager.UI.Common.Dialogs.Factories;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models.Providers;
using MedicationManager.UI.Core.ViewModels.ProviderProducts;
using MedicationManager.UI.Core.ViewModels.Providers;

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
        
        public DialogControlView CreateProviderEditor(ProviderModel model)
        {
            var vm = _viewModelLocator.Resolve<ProviderEditorViewModel, ProviderModel>(model);

            vm.Bind(model);

            return CreateDialogControlView(vm);
        }

        public ConfirmDialogView CreateProviderDeletionDialog(ProviderModel model, Func<Task> deletionCallback)
        {
            var vm = new ConfirmDialogViewModel(deletionCallback)
            {
                Title = UiConstants.Providers.DeletionDialogTitle,
                Message = $"{UiConstants.Providers.DeletionDialogMessage}{model.CompanyName}"
            };

            return CreateConfirmDialogView(vm);
        }

        public DialogControlView CreateProviderProductCreator(IImportObserverViewModel observer, ProviderProductModel productModel)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer));
            }

            if (productModel == null)
            {
                throw new ArgumentNullException(nameof(productModel));
            }

            var vm = _viewModelLocator.Resolve<ProviderProductCreatorViewModel, ProviderProductModel>(productModel);

            vm.ImportCompleted += observer.ImportCompletedHandler;

            return CreateDialogControlView(vm);
        }
        
        public ConfirmDialogView CreateProviderProductDeletionDialog(ProviderProductModel model, Func<Task> deletionCallback)
        {
            var vm = new ConfirmDialogViewModel(deletionCallback)
            {
                Title = UiConstants.ProviderProducts.DeletionDialogTile,
                Message = $"{UiConstants.ProviderProducts.DeletionDialogMessage}{model.Medication?.Name ?? UiConstants.UnknownEntity}"
            };

            return CreateConfirmDialogView(vm);
        }

        public DialogControlView CreateProviderProductEditor(ProviderProductModel model)
        {
            var vm = _viewModelLocator.Resolve<ProviderProductEditorViewModel, ProviderProductModel>(model);

            vm.Bind(model);
            
            return CreateDialogControlView(vm);
        }
    }
}
