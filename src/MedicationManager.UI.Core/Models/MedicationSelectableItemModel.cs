using MedicationManager.UI.Common.Models;

namespace MedicationManager.UI.Core.Models
{
    public class MedicationSelectableItemModel : BaseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
    }
}
