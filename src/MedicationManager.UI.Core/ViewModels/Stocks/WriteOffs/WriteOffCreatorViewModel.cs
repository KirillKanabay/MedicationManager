using System.Threading.Tasks;
using AutoMapper;
using MaterialDesignThemes.Wpf;
using MedicationManager.BusinessLogic.Stock.Contracts;
using MedicationManager.BusinessLogic.Stock.Dtos;
using MedicationManager.UI.Common.Immutable;
using MedicationManager.UI.Core.Models.Stock;

namespace MedicationManager.UI.Core.ViewModels.Stocks.WriteOffs
{
    public class WriteOffCreatorViewModel : BaseStockCreatorViewModel<WriteOffModel, WriteOffDto>
    {
        public WriteOffCreatorViewModel(IStockService<WriteOffDto> service, IMapper mapper, ISnackbarMessageQueue messageQueue) : base(service, mapper, messageQueue)
        {
        }

        public override string Title => "Регистрация списаний";
        protected override string CreatedMessage => SnackbarConstants.WriteOffCreatedMessage;

        protected override Task LoadHandler()
        {
            throw new System.NotImplementedException();
        }
    }
}