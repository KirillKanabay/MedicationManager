using System.Collections.Generic;
using MedicationManager.BusinessLogic.Providers.Dtos;

namespace MedicationManager.BusinessLogic.Providers.Comparers
{
    public class ProviderProductComparer : IEqualityComparer<ProviderProductDto>
    {
        public bool Equals(ProviderProductDto x, ProviderProductDto y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            
            return Equals(x.Medication, y.Medication);
        }

        public int GetHashCode(ProviderProductDto obj)
        {
            return (obj.Medication != null ? obj.Medication.GetHashCode() : 0);
        }
    }
}
