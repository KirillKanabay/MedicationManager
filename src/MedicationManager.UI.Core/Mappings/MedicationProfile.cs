using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.UI.Core.Models;
using MedicationManager.UI.Core.Models.Medications;

namespace MedicationManager.UI.Core.Mappings
{
    public class MedicationProfile : Profile
    {
        public MedicationProfile()
        {
            CreateMap<MedicationDto, MedicationModel>().ReverseMap();
            CreateMap<MedicationModel, MedicationModel>().ReverseMap();

            CreateMap<MedicationFilterModel, MedicationFilterDto>().ReverseMap();
        }
    }
}
