using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.BusinessLogic.Providers.Dtos;
using MedicationManager.UI.Common.Immutable;

namespace MedicationManager.UI.Core.ViewModels.Providers
{
    public class ProviderCreatorViewModel : ProviderImportViewModelBase
    {
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;
        private readonly ISnackbarMessageQueue _snackbarMessageQueue;

        public ProviderCreatorViewModel(IProviderService providerService, IMapper mapper, ISnackbarMessageQueue snackbarMessageQueue)
        {
            _providerService = providerService;
            _mapper = mapper;
            _snackbarMessageQueue = snackbarMessageQueue;
        }

        public override string Title => "Создание поставщика";

        protected override async Task SaveModel()
        {
            LoaderVisibility = Visibility.Visible;

            var dto = _mapper.Map<ProviderDto>(Model);

            await _providerService.AddAsync(dto);

            _snackbarMessageQueue.Enqueue(SnackbarConstants.ProviderCreatedMessage, SnackbarConstants.CloseSnackbarName, () => {});

            await base.SaveModel();
        }
    }
}
