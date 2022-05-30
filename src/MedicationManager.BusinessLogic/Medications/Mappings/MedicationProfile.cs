using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.Common.BusinessLogic;
using MedicationManager.Common.Data.Documents;
using MedicationManager.Data.Medications.Documents;

namespace MedicationManager.BusinessLogic.Medications.Mappings
{
    public class MedicationProfile : Profile
    {
        public MedicationProfile()
        {
            CreateMap<MedicationDocument, MedicationDto>().ReverseMap();
            CreateMap<DocumentBase, BaseDto>();
        }
    }
}
