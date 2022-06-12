using System;
using System.Collections.ObjectModel;
using AutoMapper;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.UI.Common;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Factories;

namespace MedicationManager.UI.Core.ViewModels.ProviderProducts
{
    public class ProviderProductsControlViewModel : BaseViewModel
    {
        private readonly ProviderDialogFactory _providerDialogFactory;
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;
        private readonly ViewModelLocator _viewModelLocator;

        public ProviderProductsControlViewModel(ProviderDialogFactory providerDialogFactory, IProviderService providerService, IMapper mapper, ViewModelLocator viewModelLocator)
        {
            _providerDialogFactory = providerDialogFactory ?? throw new ArgumentNullException(nameof(providerDialogFactory));
            _providerService = providerService ?? throw new ArgumentNullException(nameof(providerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _viewModelLocator = viewModelLocator ?? throw new ArgumentNullException(nameof(viewModelLocator));
        }

        public ObservableCollection<>
    }
}
