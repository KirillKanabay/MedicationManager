using MedicationManager.Common.UI.Commands;
using MedicationManager.Common.UI.ViewModels;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public partial class MedicationSelectableItemViewModel : BaseSelectableTableItemViewModel
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }

        public override TaskBasedCommand RemoveItemCommand { get; }
        public override TaskBasedCommand EditItemCommand { get; }
    }
}
