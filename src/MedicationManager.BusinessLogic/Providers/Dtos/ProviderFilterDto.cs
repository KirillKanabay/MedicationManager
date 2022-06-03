using System.Collections.Generic;

namespace MedicationManager.BusinessLogic.Providers.Dtos
{
    public class ProviderFilterDto
    {
        public List<string> Id { get; set; }
        public List<string> CompanyName { get; set; } 
    }
}
