using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MedicationManager.Infrastructure.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> observableCollection, IEnumerable<T> items)
        {
            if (observableCollection == null)
            {
                throw new ArgumentNullException(nameof(observableCollection));
            }

            foreach (var item in items)
            {
                observableCollection.Add(item);
            }
        }

        /// <summary>
        /// Clear items in collection and assign new items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="observableCollection"></param>
        /// <param name="items"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Assign<T>(this ObservableCollection<T> observableCollection, IEnumerable<T> items)
        {
            if (observableCollection == null)
            {
                throw new ArgumentNullException(nameof(observableCollection));
            }
            
            observableCollection.Clear();
            observableCollection.AddRange(items);
        }
    }
}
