using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.BusinessLogic.Providers.Dtos;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.Providers
{
    public class ProviderEditorViewModel : ProviderImportViewModelBase, IModelBasedViewModel<ProviderModel>
    {
        private readonly IMapper _mapper;
        private readonly IProviderService _providerService;
        private readonly ISnackbarMessageQueue _snackbarMessageQueue;

        private ProviderModel _originalModel;

        public ProviderEditorViewModel(IMapper mapper, IProviderService providerService, ISnackbarMessageQueue snackbarMessageQueue)
        {
            _mapper = mapper;
            _providerService = providerService;
            _snackbarMessageQueue = snackbarMessageQueue;
        }

        public override string Title => "Редактирование поставщика";
        
        protected override async Task SaveModel()
        {
            LoaderVisibility = Visibility.Visible;

            var dto = _mapper.Map<ProviderDto>(Model);
            await _providerService.UpdateAsync(dto);

            _mapper.Map(Model, _originalModel);
            _snackbarMessageQueue.Enqueue(SnackbarConstants.ProviderEditedMessage, SnackbarConstants.CloseSnackbarName, () => { });

            await base.SaveModel();
        }

        public void Bind(ProviderModel model)
        {
            _originalModel = model;

            Model = _mapper.Map<ProviderModel>(model);
        }
    }
}