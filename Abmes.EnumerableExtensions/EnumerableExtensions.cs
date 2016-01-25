using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abmes.EnumerableExtensions
{
    public static class EnumerableExtensions
    {
        private static IEnumerable<ElementWithPositionalContext<T>> GetEnumerableWithPositionalContext<T>(IEnumerable<T> source)
        {
            if (source.Any())
            {
                T previous = default(T);
                T current = source.FirstOrDefault();
                int index = 0;
                bool isFirst = true;

                foreach (T next in source.Skip(1))
                {
                    yield return new ElementWithPositionalContext<T>(index, previous, current, next, isFirst, false);
                    previous = current;
                    current = next;
                    isFirst = false;
                    index++;
                }

                yield return new ElementWithPositionalContext<T>(index, previous, current, default(T), false, true);
            }
        }

        public static IEnumerable<ElementWithPositionalContext<T>> WithPositionalContext<T>(this List<T> source) => GetEnumerableWithPositionalContext(source);
        public static IEnumerable<ElementWithPositionalContext<T>> WithPositionalContext<T>(this T[] source) => GetEnumerableWithPositionalContext(source);
    }
}
