using AutoMapper;
using MedicationManager.BusinessLogic.Providers.Dtos;
using MedicationManager.UI.Core.Models.Providers;

namespace MedicationManager.UI.Core.Mappings
{
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<ProviderDto, ProviderModel>().ReverseMap();
            CreateMap<ProviderModel, ProviderModel>();
            CreateMap<ProviderProductDto, ProviderProductModel>().ReverseMap();

            CreateMap<ProviderFilterModel, ProviderFilterDto>().ReverseMap();
            CreateMap<ProviderProductFilterModel, ProviderProductFilterDto>();
        }
    }
}
