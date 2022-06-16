using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.BusinessLogic.Providers.Dtos;
using MedicationManager.Infrastructure.Extensions;
using MedicationManager.UI.Common;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Factories;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.ProviderProducts
{
    public class ProviderProductControlViewModel : BaseViewModel, IImportObserverViewModel
    {
        private readonly ProviderDialogFactory _providerDialogFactory;
        private readonly IProviderService _providerService;
        private readonly IProviderProductService _providerProductService;
        private readonly IMapper _mapper;
        private readonly ViewModelLocator _viewModelLocator;

        private ProviderModel? _providerModel;
        private Visibility _productsVisibility = Visibility.Collapsed;

        public ProviderProductControlViewModel(ProviderDialogFactory providerDialogFactory, IProviderService providerService, IMapper mapper, ViewModelLocator viewModelLocator, ISnackbarMessageQueue messageQueue, IProviderProductService providerProductService)
        {
            _providerDialogFactory = providerDialogFactory ?? throw new ArgumentNullException(nameof(providerDialogFactory));
            _providerService = providerService ?? throw new ArgumentNullException(nameof(providerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _viewModelLocator = viewModelLocator ?? throw new ArgumentNullException(nameof(viewModelLocator));
            _providerProductService = providerProductService ?? throw new ArgumentNullException(nameof(providerProductService));
            MessageQueue = messageQueue ?? throw new ArgumentNullException(nameof(messageQueue));

            Products = new ObservableCollection<ProviderProductSelectableItemViewModel>();
            Providers = new ObservableCollection<ProviderModel>();
            Filter = new ProviderProductFilterModel();
        }

        public ObservableCollection<ProviderProductSelectableItemViewModel> Products { get; }
        public ObservableCollection<ProviderModel> Providers { get; }

        public ProviderModel? SelectedProvider
        {
            get => _providerModel;
            set
            {
                _providerModel = value;
                OnPropertyChanged(nameof(SelectedProvider));
            }
        }

        public Visibility ProductsVisibility
        {
            get => _productsVisibility;
            set
            {
                _productsVisibility = value;
                OnPropertyChanged(nameof(ProductsVisibility));
            }
        }

        public ProviderProductFilterModel Filter { get; }
        public ISnackbarMessageQueue MessageQueue { get; }

        public TaskBasedCommand OnLoadCommand => new(GetProviders);
        public TaskBasedCommand OpenCreatorDialogCommand => new(OpenCreatorDialog);
        public TaskBasedCommand FilterItemsCommand => new(FilterProducts);
        public TaskBasedCommand OnProviderChanged => new(OnProviderChangedHandler);

        public async void ImportCompletedHandler(object? sender, EventArgs e)
        {
            await GetProviderProducts();
        }

        private async Task OnProviderChangedHandler()
        {
            if (SelectedProvider == null)
            {
                Products.Assign(new List<ProviderProductSelectableItemViewModel>());
                Filter.Name = String.Empty;
                ProductsVisibility = Visibility.Collapsed;
            }
            ProductsVisibility = Visibility.Visible;

            await GetProviderProducts();
        }

        private async Task GetProviders()
        {
            var dtos = await _providerService.ListAllAsync();

            var providerModels = _mapper.Map<List<ProviderModel>>(dtos);

            Providers.Assign(providerModels);
        }

        private async Task GetProviderProducts()
        {
            if (_providerModel == null)
            {
                return;
            }

            var dtos = await _providerProductService.GetProviderProducts(_providerModel.Id);
            var models = dtos.Select(CreateItemViewModel).ToList();

            Products.Assign(models);
        }

        private async Task FilterProducts()
        {
            
            if (_providerModel == null)
            {
                return;
            }

            var filterDto = _mapper.Map<ProviderProductFilterDto>(Filter);

            var dtos = await _providerProductService.GetProviderProducts(_providerModel.Id, filterDto);

            var productViewModels = dtos.Select(CreateItemViewModel).ToList();

            Products.Assign(productViewModels);
        }

        private async Task OpenCreatorDialog()
        {
            if (_providerModel == null)
            {
                return;
            }

            var dialog = _providerDialogFactory.CreateProviderProductCreator
            (
                this, 
                new ProviderProductModel { ProviderId = _providerModel.Id }
            );

            await DialogHost.Show(dialog, HostRoots.DialogRoot);
        }

        private ProviderProductSelectableItemViewModel CreateItemViewModel(ProviderProductDto dto)
        {
            var model = _mapper.Map<ProviderProductModel>(dto);
            var viewModel = _viewModelLocator.Resolve<ProviderProductSelectableItemViewModel, ProviderProductModel>(model);

            viewModel.ProductDeleted += ItemDeletedHandler;

            return viewModel;
        }

        private async void ItemDeletedHandler(object? sender, EventArgs e)
        {
            await GetProviderProducts();

            MessageQueue.Enqueue(SnackbarConstants.MedicationDeletedMessage, SnackbarConstants.CloseSnackbarName, () => { });
        }
    }
}
