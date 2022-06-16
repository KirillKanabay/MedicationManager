using AutoMapper;
using MedicationManager.BusinessLogic.Stock.Dtos;
using MedicationManager.Data.Stocks.Documents;

namespace MedicationManager.BusinessLogic.Stock.Mappings
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<DeliveryDocument, DeliveryDto>()
                .ReverseMap();

            CreateMap<WriteOffDocument, WriteOffDto>()
                .ReverseMap();

            CreateMap<BaseStockDto, BaseStockDocument>()
                .ReverseMap();
        }
    }
}
