using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Dtos;
using MedicationManager.UI.Core.ViewModels.Medications;

namespace MedicationManager.UI.Core.Mappings
{
    public class MedicationProfile : Profile
    {
        public MedicationProfile()
        {
            CreateMap<MedicationListItemDto, MedicationSelectableItemViewModel>();
        }
    }
}
