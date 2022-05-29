using MedicationManager.UI.Common.Dialogs.DialogControl;
using MedicationManager.UI.Common.ViewModels;

namespace MedicationManager.UI.Common.Dialogs.Factories
{
    public abstract class DialogAbstractFactory
    {
        protected virtual DialogControlView CreateDialogControlView<TViewModel>(TViewModel viewModel)
            where TViewModel : BaseViewModel
        {
            var dialog = new DialogControlView
            {
                DataContext = new DialogControlViewModel(viewModel)
            };

            return dialog;
        }
    }
}