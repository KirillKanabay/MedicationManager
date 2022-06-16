using System;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.BusinessLogic.Providers.Dtos;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.ProviderProducts
{
    public class ProviderProductEditorViewModel : ProviderProductImportViewModelBase, IModelBasedViewModel<ProviderProductModel>
    {
        private readonly IProviderProductService _providerProductService;
        private readonly IMapper _mapper;
        private readonly ISnackbarMessageQueue _snackbarMessageQueue;

        private ProviderProductModel _originalModel;

        public ProviderProductEditorViewModel(IProviderProductService providerProductService, IMapper mapper, ISnackbarMessageQueue snackbarMessageQueue)
        {
            _providerProductService = providerProductService ?? throw new ArgumentNullException(nameof(providerProductService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _snackbarMessageQueue = snackbarMessageQueue ?? throw new ArgumentNullException(nameof(snackbarMessageQueue));
        }

        public override string Title => "Редактирование товара поставщика";
        public override bool ProductEditAllowed => false;

        protected override async Task SaveModel()
        {
            LoaderVisibility = Visibility.Visible;

            var dto = _mapper.Map<ProviderProductDto>(Model);
            await _providerProductService.UpdateProduct(dto);

            _mapper.Map(Model, _originalModel);
            _snackbarMessageQueue.Enqueue(SnackbarConstants.ProviderProductEditedMessage, SnackbarConstants.CloseSnackbarName, () => { });

            await base.SaveModel();
        }

        public void Bind(ProviderProductModel model)
        {
            _originalModel = model;

            Model = _mapper.Map<ProviderProductModel>(model);
        }
    }
}