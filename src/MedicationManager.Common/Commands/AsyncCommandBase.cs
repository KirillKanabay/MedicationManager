using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicationManager.Common.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        private readonly Action<Exception> _onException;
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
            _onException = onException;
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
                _onException?.Invoke(e);
            }
            finally
            {
                IsExecuting = false;
            }
        }

        protected abstract Task ExecuteAsync(object parameter);
    }
}
