using AutoMapper;
using MedicationManager.BusinessLogic.Providers.Dtos;
using MedicationManager.Data.Providers.Documents;
using MedicationManager.Data.Providers.Filters;

namespace MedicationManager.BusinessLogic.Providers.Mappings
{
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<ProviderDocument, ProviderDto>().ReverseMap();
            CreateMap<ProviderProductDocument, ProviderProductDto>()
                .ForMember(x => x.Medication, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<ProviderFilter, ProviderFilterDto>()
                .ReverseMap();
        }
    }
}
