using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.UI.Core.Models;

namespace MedicationManager.UI.Core.Mappings
{
    public class MedicationProfile : Profile
    {
        public MedicationProfile()
        {
            CreateMap<MedicationListItemDto, MedicationSelectableItemModel>();
        }
    }
}
