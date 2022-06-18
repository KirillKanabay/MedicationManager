using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.BusinessLogic.Stock.Contracts;
using MedicationManager.BusinessLogic.Stock.Dtos;
using MedicationManager.Infrastructure.Extensions;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Core.Models.Providers;
using MedicationManager.UI.Core.Models.Stock;

namespace MedicationManager.UI.Core.ViewModels.Stocks.Deliveries
{
    public class DeliveryCreatorViewModel : BaseStockCreatorViewModel<DeliveryModel, DeliveryDto>
    {
        private readonly IProviderService _providerService;
        private readonly IProviderProductService _providerProductService;

        private ProviderProductModel _selectedProduct;

        public DeliveryCreatorViewModel(IDeliveryService service, IMapper mapper, ISnackbarMessageQueue messageQueue, IProviderService providerService, IProviderProductService providerProductService) : base(service, mapper, messageQueue)
        {
            _providerService = providerService;
            _providerProductService = providerProductService;
            
            Providers = new ObservableCollection<ProviderModel>();
            Products = new ObservableCollection<ProviderProductModel>();
        }

        public override string Title => "Регистрация поставки";
        protected override string CreatedMessage => SnackbarConstants.DeliveryCreatedMessage;

        public ObservableCollection<ProviderModel> Providers { get; }
        public ObservableCollection<ProviderProductModel> Products { get; }
        
        public TaskBasedCommand OnProviderSelection => new(LoadProducts);
        
        protected override async Task LoadHandler()
        {
            var dtos = await _providerService.ListAllAsync();
            var models = Mapper.Map<List<ProviderModel>>(dtos);

            Providers.Assign(models);
        }

        private async Task LoadProducts()
        {
            Model.Medication = null;

            if (Model.Provider != null)
            {
                var dtos = await _providerProductService.GetProviderProducts(Model.Provider.Id);
                var models = Mapper.Map<List<ProviderProductModel>>(dtos);
                Products.Assign(models);
            }
            else
            {
                Products.Assign(new List<ProviderProductModel>());
            }
        }

        protected override async Task SaveModel()
        {
            LoaderVisibility = Visibility.Visible;

            var dto = Mapper.Map<DeliveryDto>(Model);

            dto.ProviderId = dto.Provider.Id;
            dto.MedicationId = dto.Medication.Id;
            dto.PricePerItem = Model.SelectedProduct.Price;

            await Service.AddAsync(dto);

            MessageQueue.Enqueue(CreatedMessage, SnackbarConstants.CloseSnackbarName, () => { });
            
            DialogHost.Close(HostRoots.DialogRoot);

            OnImportCompleted();
            LoaderVisibility = Visibility.Collapsed;
        }
    }
}