using System;
using System.Threading.Tasks;

namespace MedicationManager.Common.UI.Commands
{
    public class TaskBasedCommand : AsyncCommandBase
    {
        protected readonly Func<Task> Callback;
        
        public TaskBasedCommand(Func<Task> callback, Action<Exception> onException = null) : base(onException)
        {
            Callback = callback ?? throw new ArgumentNullException(nameof(callback));
        }

        public TaskBasedCommand(TaskBasedCommand command) : base(command?.OnException)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            Callback = command.Callback;
        }

        protected override Task ExecuteAsync(object parameter) => Callback();
    }

    public class TaskBasedCommand<TParam> : AsyncCommandBase
    {
        protected readonly Func<TParam, Task> Callback;

        public TaskBasedCommand(Func<TParam, Task> callback, Action<Exception> onException = null) : base(onException)
        {
            Callback = callback;
        }

        protected override Task ExecuteAsync(object parameter) => Callback((TParam)parameter);
    }
}
