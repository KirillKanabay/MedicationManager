using System;
using System.Threading.Tasks;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.BusinessLogic.Providers.Dtos;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Factories;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.ProviderProducts
{
    public class ProviderProductSelectableItemViewModel : BaseSelectableTableItemViewModel, IModelBasedViewModel<ProviderProductModel>
    {
        public event EventHandler ProductDeleted;

        public ProviderProductModel Model { get; private set; }

        private readonly ProviderDialogFactory _dialogFactory;
        private readonly IProviderProductService _providerProductService;
        private readonly IMapper _mapper;

        public ProviderProductSelectableItemViewModel(IProviderProductService providerProductService, ProviderDialogFactory dialogFactory, IMapper mapper)
        {
            _providerProductService = providerProductService ?? throw new ArgumentNullException(nameof(providerProductService));
            _dialogFactory = dialogFactory ?? throw new ArgumentNullException(nameof(dialogFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override TaskBasedCommand DeleteItemCommand => new(DeleteItem);
        public override TaskBasedCommand EditItemCommand => new(EditItem);

        private async Task DeleteItem()
        {
            var dialog = _dialogFactory.CreateProviderProductDeletionDialog(Model, DeleteItemCallback);

            await DialogHost.Show(dialog, HostRoots.DialogRoot);
        }

        private async Task EditItem()
        {
            var dialog = _dialogFactory.CreateProviderProductEditor(Model);

            await DialogHost.Show(dialog, HostRoots.DialogRoot);
        }

        private async Task DeleteItemCallback()
        {
            var dto = _mapper.Map<ProviderProductDto>(Model);
            await _providerProductService.DeleteProduct(dto);
            
            OnProductDeleted();
        }

        public void Bind(ProviderProductModel model)
        {
            Model = model;
        }

        protected virtual void OnProductDeleted()
        {
            ProductDeleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
