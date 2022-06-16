using System;
using MedicationManager.UI.Common;
using MedicationManager.UI.Common.Dialogs.DialogControl;
using MedicationManager.UI.Common.Dialogs.Factories;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.ViewModels.Stocks.Deliveries;
using MedicationManager.UI.Core.ViewModels.Stocks.WriteOffs;

namespace MedicationManager.UI.Core.Factories
{
    public class StockDialogFactory : DialogAbstractFactory
    {
        private readonly ViewModelLocator _viewModelLocator;

        public StockDialogFactory(ViewModelLocator viewModelLocator)
        {
            _viewModelLocator = viewModelLocator;
        }

        public DialogControlView CreateDeliveryCreator(IImportObserverViewModel observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException();
            }

            var vm = _viewModelLocator.Resolve<DeliveryCreatorViewModel>();

            vm.ImportCompleted += observer.ImportCompletedHandler;

            return CreateDialogControlView(vm);
        }

        public DialogControlView CreateWriteOffCreator(IImportObserverViewModel observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException();
            }

            var vm = _viewModelLocator.Resolve<WriteOffCreatorViewModel>();

            vm.ImportCompleted += observer.ImportCompletedHandler;

            return CreateDialogControlView(vm);
        }
    }
}
