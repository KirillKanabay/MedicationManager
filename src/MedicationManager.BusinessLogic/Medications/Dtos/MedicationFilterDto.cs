using System.Collections.Generic;

namespace MedicationManager.BusinessLogic.Medications.Dtos
{
    public class MedicationFilterDto
    {
        public List<string> Id { get; set; }
        public string Name { get; set; }
    }
}