using System.Collections.Generic;
using System.Linq;

namespace MedicationManager.Infrastructure.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsPresent<T>(this IEnumerable<T> enumerable)
        {
            return enumerable?.Any() ?? false;
        }

        public static bool IsNullOrWhitespace(this IEnumerable<string> enumerable)
        {
            return enumerable?.All(x => x.IsNullOrWhitespace()) ?? true;
        }
    }
}
