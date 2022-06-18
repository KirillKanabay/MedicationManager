using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Stock.Contracts;
using MedicationManager.BusinessLogic.Stock.Dtos;
using MedicationManager.Infrastructure.Extensions;
using MedicationManager.UI.Common.Commands;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Core.Models.Medications;
using MedicationManager.UI.Core.Models.Stock;

namespace MedicationManager.UI.Core.ViewModels.Stocks.WriteOffs
{
    public class WriteOffCreatorViewModel : BaseStockCreatorViewModel<WriteOffModel, WriteOffDto>
    {
        private readonly IMedicationService _medicationService;

        public WriteOffCreatorViewModel(IWriteOffService service, IMapper mapper, ISnackbarMessageQueue messageQueue, IMedicationService medicationService) : base(service, mapper, messageQueue)
        {
            _medicationService = medicationService;

            Products = new ObservableCollection<MedicationModel>();
        }

        public override string Title => "Регистрация списаний";
        protected override string CreatedMessage => SnackbarConstants.WriteOffCreatedMessage;

        public ObservableCollection<MedicationModel> Products { get; }

        public DelegateCommand OnProductSelection => new(ProductSelectionHandler);

        private void ProductSelectionHandler(object param)
        {
            Model.Count = 0;
            Model.PricePerItem = 0;
        }

        protected override async Task LoadHandler()
        {
            var dtos = await _medicationService.ListAllAsync();
            var models = Mapper.Map<List<MedicationModel>>(dtos);

            Products.Assign(models);
        }

        protected override async Task SaveModel()
        {
            LoaderVisibility = Visibility.Visible;

            var dto = Mapper.Map<WriteOffDto>(Model);

            dto.MedicationId = dto.Medication.Id;

            await Service.AddAsync(dto);

            MessageQueue.Enqueue(CreatedMessage, SnackbarConstants.CloseSnackbarName, () => { });

            DialogHost.Close(HostRoots.DialogRoot);

            OnImportCompleted();
            LoaderVisibility = Visibility.Collapsed;
        }
    }
}