using MedicationManager.UI.Common.Commands;

namespace MedicationManager.UI.Common.ViewModels
{
    public abstract class BaseSelectableTableItemViewModel : BaseViewModel
    {
        private bool _isSelected;
        
        public abstract TaskBasedCommand DeleteItemCommand { get; }
        public abstract TaskBasedCommand EditItemCommand { get; }

        public virtual bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }
}
