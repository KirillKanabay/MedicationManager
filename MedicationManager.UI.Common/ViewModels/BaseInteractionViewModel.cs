using System.Windows;

namespace MedicationManager.UI.Common.ViewModels
{
    public abstract class BaseInteractionViewModel : BaseViewModel
    {
        private Visibility _loaderVisibility = Visibility.Collapsed;

        public Visibility LoaderVisibility
        {
            get => _loaderVisibility;
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged(nameof(_loaderVisibility));
            }
        }
    }
}
