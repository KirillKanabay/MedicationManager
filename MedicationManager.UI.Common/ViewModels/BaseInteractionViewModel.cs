using System;
using System.Threading.Tasks;

namespace MedicationManager.UI.Common.ViewModels
{
    public abstract class BaseInteractionViewModel : BaseViewModel
    {
        private bool _loaderVisibility;

        public bool LoaderVisibility
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
