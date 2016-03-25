using System;
using System.Collections.Generic;

namespace DelegatesАndEvents
{
    public static class LINQExtensions
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            foreach (var element in collection)
            {
                var isConditionFulfilled = condition(element);
                if (isConditionFulfilled)
                {
                    return element;
                }
            }

            return default(T);
        }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var resultCollection = new List<T>();
            foreach (var element in collection)
            {
                var isConditionFulfilled = predicate(element);
                if (isConditionFulfilled)
                {
                    resultCollection.Add(element);
                }
                else
                {
                    break;
                }
            }

            return resultCollection;
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var element in collection)
            {
                action(element);
            }
        }
    }
}
