using System;
using System.Threading.Tasks;
using System.Windows;
using MaterialDesignThemes.Wpf;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.ProviderProducts
{
    public abstract class ProviderProductImportViewModelBase : BaseInteractionViewModel
    {
        private ProviderProductModel _model;

        public event EventHandler ImportCompleted;

        protected ProviderProductImportViewModelBase()
        {
            _model = new ProviderProductModel();
        }

        public abstract string Title { get; }
        public abstract bool ProductEditAllowed { get; }

        public ProviderProductModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

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