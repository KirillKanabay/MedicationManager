using System;
using System.Threading.Tasks;
using System.Windows;
using MaterialDesignThemes.Wpf;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.Providers
{
    public abstract class ProviderImportViewModelBase : BaseInteractionViewModel
    {
        private ProviderModel _model;

        public event EventHandler ImportCompleted;

        protected ProviderImportViewModelBase()
        {
            _model = new ProviderModel();
        }

        public abstract string Title { get; }

        public ProviderModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public bool SaveButtonIsEnabled => !Model?.IsValid ?? false;

        public virtual TaskBasedCommand SaveItemCommand => new(SaveModel);

        protected virtual Task SaveModel()
        {
            OnImportCompleted();

            LoaderVisibility = Visibility.Collapsed;

            DialogHost.Close(HostRoots.DialogRoot);

            return Task.CompletedTask;
        }

        protected virtual void OnImportCompleted()
        {
            ImportCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}