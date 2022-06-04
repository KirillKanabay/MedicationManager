using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

namespace MedicationManager.UI.Core.ViewModels.Providers
{
    public class ProviderControlViewModel : BaseViewModel, IImportObserverViewModel
    {
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;
        private readonly ViewModelLocator _viewModelLocator;
        private readonly ProviderDialogFactory _providerDialogFactory;

        public ProviderControlViewModel(IProviderService providerService, IMapper mapper, ViewModelLocator viewModelLocator, ISnackbarMessageQueue messageQueue, ProviderDialogFactory providerDialogFactory)
        {
            _providerService = providerService ?? throw new ArgumentNullException(nameof(providerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _viewModelLocator = viewModelLocator ?? throw new ArgumentNullException(nameof(viewModelLocator));
            
            MessageQueue = messageQueue;
            _providerDialogFactory = providerDialogFactory;
            Filter = new ProviderFilterModel();
            Providers = new ObservableCollection<ProviderSelectableItemViewModel>();
        }

        public ISnackbarMessageQueue MessageQueue { get; }
        public ProviderFilterModel Filter { get; }
        public ObservableCollection<ProviderSelectableItemViewModel> Providers { get; }

        public TaskBasedCommand OnLoadCommand => new(GetProviders);
        public TaskBasedCommand GetItemsCollection => new(GetProviders);
        public TaskBasedCommand OpenCreatorDialogCommand => new(OpenCreatorDialog);
        public TaskBasedCommand FilterItemsCommand => new(FilterProviders);

        public async void ImportCompletedHandler(object? sender, EventArgs e)
        {
            await GetProviders();
        }

        private async Task GetProviders()
        {
            var dtos = await _providerService.ListAllAsync();

            var providerViewModels = dtos.Select(CreateItemViewModel).ToList();

            Providers.Assign(providerViewModels);
        }

        private async Task FilterProviders()
        {
            var filterDto = _mapper.Map<ProviderFilterDto>(Filter);

            var dtos = await _providerService.ListAsync(filterDto);

            var providerViewModels = dtos.Select(dto =>
            {
                var model = _mapper.Map<ProviderModel>(dto);
                var viewModel = _viewModelLocator.Resolve<ProviderSelectableItemViewModel, ProviderModel>(model);

                return viewModel;
            }).ToList();

            Providers.Assign(providerViewModels);
        }

        private async Task OpenCreatorDialog()
        {
            var dialog = _providerDialogFactory.CreateProviderCreator(this);

            await DialogHost.Show(dialog, HostRoots.DialogRoot);
        }

        private ProviderSelectableItemViewModel CreateItemViewModel(ProviderDto dto)
        {
            var model = _mapper.Map<ProviderModel>(dto);
            var viewModel = _viewModelLocator.Resolve<ProviderSelectableItemViewModel, ProviderModel>(model);

            viewModel.DeletionCompleted += ItemDeletedHandler;

            return viewModel;
        }

        private async void ItemDeletedHandler(object? sender, EventArgs e)
        {
            await GetProviders();

            MessageQueue.Enqueue(SnackbarConstants.ProviderDeletedMessage, SnackbarConstants.CloseSnackbarName, () => { });
        }
    }
}
