using AutoMapper;
using MedicationManager.BusinessLogic.Stock.Dtos;
using MedicationManager.UI.Core.Models.Stock;

namespace MedicationManager.UI.Core.Mappings
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<DeliveryModel, DeliveryDto>()
                .ReverseMap();

            CreateMap<WriteOffModel, WriteOffDto>()
                .ReverseMap();

            CreateMap<BaseStockDto, BaseStockModel>()
                .ReverseMap();
        }
    }
}