using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesAndEvents
{
    public static class LINQExtensions
    {
        public static IEnumerable<T> WhereNot<T>(
            this IEnumerable<T> collection, 
            Func<T, bool> predicate)
        {
            var filteredCollection = new List<T>();
            foreach (var element in collection)
            {
                var isConditionFullFilled = predicate(element);
                if (!isConditionFullFilled)
                {
                    filteredCollection.Add(element);
                }
            }

            return filteredCollection;
        }

        public static TSelector Max<TSource, TSelector>(
            this IEnumerable<TSource> collection, Func<TSource, TSelector> selectFromSource)
            where TSelector : IComparable
        {
            if (collection == null)
            {
                throw new ArgumentNullException("The collection is empty!");
            }

            var maxSelectedValue = selectFromSource(collection.First());
            foreach (var element in collection)
            {
                var selectedValue = selectFromSource(element);
                if (selectedValue.CompareTo(maxSelectedValue) > 0)
                {
                    maxSelectedValue = selectedValue;
                }
            }

            return maxSelectedValue;
        }
    }
}
