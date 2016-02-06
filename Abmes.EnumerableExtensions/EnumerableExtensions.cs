using Abmes.EnumerableExtensions.EnumerableThrowingNoElementsWithCustomMessage;
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

        public static IEnumerable<ElementWithPositionalContext<T>> WithPositionalContext<T>(this ICollection<T> source) =>
            GetEnumerableWithPositionalContext(source);

        public static IEnumerableThrowingNoElementsWithCustomMessage<TSource> WithExceptionMessageWhenNoElements<TSource>(this IEnumerable<TSource> source, string messageWhenNoElements) =>
            new EnumerableThrowingNoElementsWithCustomMessage<TSource>(source, messageWhenNoElements);

        public static IEnumerableIntThrowingNoElementsWithCustomMessage WithExceptionMessageWhenNoElements(this IEnumerable<int> source, string messageWhenNoElements) =>
            new EnumerableIntThrowingNoElementsWithCustomMessage(source, messageWhenNoElements);

        public static IEnumerableLongThrowingNoElementsWithCustomMessage WithExceptionMessageWhenNoElements(this IEnumerable<long> source, string messageWhenNoElements) =>
            new EnumerableLongThrowingNoElementsWithCustomMessage(source, messageWhenNoElements);

        public static IEnumerableFloatThrowingNoElementsWithCustomMessage WithExceptionMessageWhenNoElements(this IEnumerable<float> source, string messageWhenNoElements) =>
            new EnumerableFloatThrowingNoElementsWithCustomMessage(source, messageWhenNoElements);

        public static IEnumerableDoubleThrowingNoElementsWithCustomMessage WithExceptionMessageWhenNoElements(this IEnumerable<double> source, string messageWhenNoElements) =>
            new EnumerableDoubleThrowingNoElementsWithCustomMessage(source, messageWhenNoElements);

        public static IEnumerableDecimalThrowingNoElementsWithCustomMessage WithExceptionMessageWhenNoElements(this IEnumerable<decimal> source, string messageWhenNoElements) =>
            new EnumerableDecimalThrowingNoElementsWithCustomMessage(source, messageWhenNoElements);
    }
}
