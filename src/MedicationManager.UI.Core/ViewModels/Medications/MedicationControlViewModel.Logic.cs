using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.Common.Extensions;

namespace MedicationManager.UI.Core.ViewModels.Medications
{
    public partial class MedicationControlViewModel
    {
        private async Task GetMedications()
        {
            var dtos = await _medicationService.ListAll();
            var medications = _mapper.Map<List<MedicationSelectableItemViewModel>>(dtos);

            Medications.Assign(medications);
        }
    }
}