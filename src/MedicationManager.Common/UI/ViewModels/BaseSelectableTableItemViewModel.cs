using MedicationManager.Common.UI.Commands;

namespace MedicationManager.Common.UI.ViewModels
{
    public abstract class BaseSelectableTableItemViewModel : BaseViewModel
    {
        private bool _isSelected;
        
        public abstract TaskBasedCommand RemoveItemCommand { get; }
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
