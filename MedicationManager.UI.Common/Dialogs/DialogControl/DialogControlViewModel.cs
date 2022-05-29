using MedicationManager.UI.Common.ViewModels;

namespace MedicationManager.UI.Common.Dialogs.DialogControl
{
    public class DialogControlViewModel : BaseViewModel
    {
        private readonly BaseViewModel? _boundViewModel;

        public BaseViewModel BoundViewModel
        {
            get => _boundViewModel ?? new EmptyViewModel();
            init
            {
                _boundViewModel = value;
                OnPropertyChanged(nameof(BoundViewModel));
            }
        }

        public DialogControlViewModel() { }

        public DialogControlViewModel(BaseViewModel viewModel)
        {
            BoundViewModel = viewModel;
        }
    }
}