using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.Data.Medications.Documents;
using MedicationManager.Data.Medications.Filters;

namespace MedicationManager.BusinessLogic.Medications.Mappings
{
    public class MedicationProfile : Profile
    {
        public MedicationProfile()
        {
            CreateMap<MedicationDocument, MedicationDto>().ReverseMap();

            CreateMap<MedicationFilterDto, MedicationFilter>().ReverseMap();
        }
    }
}
