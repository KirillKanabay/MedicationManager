using System;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Factories;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.Providers
{
    public class ProviderSelectableItemViewModel : BaseSelectableTableItemViewModel, IModelBasedViewModel<ProviderModel>
    {
        private readonly ProviderDialogFactory _providerDialogFactory;
        private readonly IProviderService _providerService;

        public ProviderSelectableItemViewModel(ProviderDialogFactory providerDialogFactory, IProviderService providerService)
        {
            _providerDialogFactory = providerDialogFactory ?? throw new ArgumentNullException(nameof(providerDialogFactory));
            _providerService = providerService ?? throw new ArgumentNullException(nameof(providerService));
        }

        public EventHandler DeletionCompleted;
        public ProviderModel Model { get; private set; }

        public override TaskBasedCommand EditItemCommand => new(OpenEditorDialog);
        public override TaskBasedCommand DeleteItemCommand => new(DeleteItem);

        public void Bind(ProviderModel model)
        {
            Model = model;
        }

        private async Task OpenEditorDialog()
        {
            var dialog = _providerDialogFactory.CreateProviderEditor(Model);

            await DialogHost.Show(dialog, HostRoots.DialogRoot);
        }

        private async Task DeleteItem()
        {
            var dialog = _providerDialogFactory.CreateProviderDeletionDialog(Model, DeleteItemCallback);

            await DialogHost.Show(dialog, HostRoots.DialogRoot);
        }

        private async Task DeleteItemCallback()
        {
            await _providerService.DeleteAsync(Model.Id);
            OnDeletionCompleted();
        }

        protected virtual void OnDeletionCompleted()
        {
            DeletionCompleted.Invoke(this, EventArgs.Empty);
        }
    }
}
