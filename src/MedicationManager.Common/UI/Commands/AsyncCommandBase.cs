using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicationManager.Common.UI.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        protected readonly Action<Exception> OnException;
        private bool _isExecuting;

        public event EventHandler CanExecuteChanged;

        public bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        protected AsyncCommandBase(Action<Exception> onException)
        {
            OnException = onException;
        }

        public bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        public async void Execute(object parameter)
        {
            IsExecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception e)
            {
                OnException?.Invoke(e);
            }
            finally
            {
                IsExecuting = false;
            }
        }

        protected abstract Task ExecuteAsync(object parameter);
    }
}
