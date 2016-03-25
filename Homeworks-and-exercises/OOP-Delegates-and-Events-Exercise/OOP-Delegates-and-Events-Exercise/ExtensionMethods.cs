using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Delegates_and_Events_Exercise
{
    public static class ExtensionMethods
    {
        //Predicates
        public static T FirstOrDef<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            foreach (var element in collection)
            {
                bool isConditionMatched = condition(element);
                if (isConditionMatched)
                {
                    return element;
                }
            }

            return default(T);
        }

        //Func
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var resultCollection = new List<T>();
            
            while (true)
            {
                foreach (var element in collection)
                {
                    if (predicate(element))
                    {
                        resultCollection.Add(element);
                    }
                    else
                    {
                        break;
                    }
                }
                break;
            }

            return resultCollection;
        }

        //Action
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var element in collection)
            {
                action(element);
            }
        }
    }
}
