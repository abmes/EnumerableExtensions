using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abmes.EnumerableExtensions
{
    public static class EnumerableExtensions
    {
        private static IEnumerable<ElementWithContext<T>> GetEnumerableWithContext<T>(IEnumerable<T> source)
        {
            if (source.Any())
            {
                T previous = default(T);
                T current = source.FirstOrDefault();
                int index = 0;
                bool isFirst = true;

                foreach (T next in source.Skip(1))
                {
                    yield return new ElementWithContext<T>(current, previous, next, index, isFirst, false);
                    previous = current;
                    current = next;
                    isFirst = false;
                    index++;
                }

                yield return new ElementWithContext<T>(current, previous, default(T), index, false, true);
            }
        }

        public static IEnumerable<ElementWithContext<T>> WithContext<T>(this List<T> source) => GetEnumerableWithContext(source);
        public static IEnumerable<ElementWithContext<T>> WithContext<T>(this T[] source) => GetEnumerableWithContext(source);
    }
}
