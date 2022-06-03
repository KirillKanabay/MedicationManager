using System;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;

namespace MedicationManager.UI.Common.Dialogs.ConfirmDialog
{
    public class ConfirmDialogViewModel : BaseViewModel
    {
        private string _title;
        private string _message;
        
        private readonly Func<Task> _confirmCallback;

        public ConfirmDialogViewModel()
        {
            
        }

        public ConfirmDialogViewModel(Func<Task> confirmCallback)
        {
            _confirmCallback = confirmCallback;
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public DelegateCommand CloseModalCommand => new(CloseModal);
        public TaskBasedCommand ConfirmModalCommand => new(ConfirmModal);

        private void CloseModal(object param)
        {
            DialogHost.Close(HostRoots.DialogRoot);
        }

        private async Task ConfirmModal()
        {
            await _confirmCallback.Invoke();

            DialogHost.Close(HostRoots.DialogRoot);
        }
    }
}
