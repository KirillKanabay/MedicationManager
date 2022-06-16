using System.Collections.Generic;

namespace MedicationManager.BusinessLogic.Providers.Dtos
{
    public class ProviderFilterDto
    {
        public List<string> Id { get; set; }
        public string CompanyName { get; set; } 
    }
}
