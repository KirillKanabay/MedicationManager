using System.Collections.Generic;
using MedicationManager.Common.BusinessLogic;

namespace MedicationManager.BusinessLogic.Providers.Dtos
{
    public class ProviderDto : BaseDto
    {
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public string Address { get; set; }
        public List<string> AvailableMedications { get; set; }
    }
}
