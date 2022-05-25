using System.Collections.Generic;
using System.Linq;

namespace MedicationManager.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsPresent<T>(this IEnumerable<T> enumerable)
        {
            return enumerable?.Any() ?? false;
        }
    }
}
