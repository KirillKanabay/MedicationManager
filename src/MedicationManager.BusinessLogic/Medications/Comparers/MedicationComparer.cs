using System.Collections.Generic;
using MedicationManager.BusinessLogic.Medications.Dtos;

namespace MedicationManager.BusinessLogic.Medications.Comparers
{
    public class MedicationComparer : IEqualityComparer<MedicationDto>
    {
        public bool Equals(MedicationDto x, MedicationDto y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id;
        }

        public int GetHashCode(MedicationDto obj)
        {
            return (obj.Id != null ? obj.Id.GetHashCode() : 0);
        }
    }
}
