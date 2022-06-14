using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.BusinessLogic.Providers.Dtos;
using MedicationManager.Infrastructure.Extensions;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Models.Medications;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.ViewModels.ProviderProducts
{
    public class ProviderProductCreatorViewModel : ProviderProductImportViewModelBase, IModelBasedViewModel<ProviderProductModel>
    {
        private readonly IProviderProductService _providerProductService;
        private readonly IMapper _mapper;
        private readonly ISnackbarMessageQueue _snackbarMessageQueue;

        public ProviderProductCreatorViewModel(IProviderProductService providerProductService, IMapper mapper, ISnackbarMessageQueue snackbarMessageQueue)
        {
            _providerProductService = providerProductService ?? throw new ArgumentNullException(nameof(providerProductService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _snackbarMessageQueue = snackbarMessageQueue ?? throw new ArgumentNullException(nameof(snackbarMessageQueue));

            Medications = new ObservableCollection<MedicationModel>();
        }

        public override string Title => "Создание товара поставщика";
        public override bool ProductEditAllowed => true;
        public ObservableCollection<MedicationModel> Medications { get; }


        public TaskBasedCommand OnLoadCommand => new(LoadMedications);

        private async Task LoadMedications()
        {
            var dtos = await _providerProductService.GetAvailableMedications(Model.ProviderId);
            var medications = _mapper.Map<List<MedicationModel>>(dtos);

            Medications.Assign(medications);
        }

        protected override async Task SaveModel()
        {
            LoaderVisibility = Visibility.Visible;

            var dto = _mapper.Map<ProviderProductDto>(Model);

            await _providerProductService.AddProduct(dto);

            _snackbarMessageQueue.Enqueue(SnackbarConstants.MedicationCreatedMessage, SnackbarConstants.CloseSnackbarName, () => { });

            await base.SaveModel();
        }

        public void Bind(ProviderProductModel model)
        {
            Model = model;
        }
    }
}