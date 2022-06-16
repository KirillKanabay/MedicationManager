using System;
using System.Threading.Tasks;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Stock.Contracts;
using MedicationManager.BusinessLogic.Stock.Dtos;
using MedicationManager.UI.Common;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Common.ViewModels;
using MedicationManager.UI.Core.Factories;
using MedicationManager.UI.Core.Models.Stock;

namespace MedicationManager.UI.Core.ViewModels.Stocks.WriteOffs
{
    public class WriteOffControlViewModel : BaseStockControlViewModel<WriteOffModel, WriteOffDto>
    {
        public WriteOffControlViewModel(StockDialogFactory dialogFactory, IMapper mapper, ViewModelLocator viewModelLocator, ISnackbarMessageQueue messageQueue, IWriteOffService service) : base(dialogFactory, mapper, viewModelLocator, messageQueue, service)
        {
        }

        protected override async Task OpenCreatorDialog()
        {
            var dialog = DialogFactory.CreateWriteOffCreator(this);

            await DialogHost.Show(dialog, HostRoots.DialogRoot);
        }
    }
}