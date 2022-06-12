using System.Collections.Generic;
using MedicationManager.BusinessLogic.Common;

namespace MedicationManager.BusinessLogic.Providers.Dtos
{
    public class ProviderDto : BaseDto
    {
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public string Address { get; set; }
        public List<ProviderProductDto> Products { get; set; }
    }
}
