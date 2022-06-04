using System;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.Providers
{
    public class ProviderSelectableItemViewModel : BaseSelectableTableItemViewModel, IModelBasedViewModel<ProviderModel>
    {
        public override TaskBasedCommand DeleteItemCommand { get; }
        public override TaskBasedCommand EditItemCommand { get; }

        public EventHandler DeletionCompleted;
        public ProviderModel Model { get; private set; }
        
        public void Bind(ProviderModel model)
        {
            Model = model;
        }

        private async Task OpenEditorDialog()
        {
            //await DialogHost.Show(, HostRoots.DialogRoot)
        }

        private async Task DeleteItem()
        {
            //await DialogHost.Show(, HostRoots.DialogRoot)
        }

        private async Task DeleteItemCallback()
        {
            OnDeletionCompleted();
        }

        protected virtual void OnDeletionCompleted()
        {
            DeletionCompleted.Invoke(this, EventArgs.Empty);
        }
    }
}
