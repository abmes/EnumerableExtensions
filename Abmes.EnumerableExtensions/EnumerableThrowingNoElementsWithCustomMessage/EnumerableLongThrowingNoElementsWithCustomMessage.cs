using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abmes.EnumerableExtensions.EnumerableThrowingNoElementsWithCustomMessage
{
    public interface IEnumerableLongThrowingNoElementsWithCustomMessage : IEnumerableThrowingNoElementsWithCustomMessage<long>
    {
        long Max();
        long Min();
        double Average();
    }

    class EnumerableLongThrowingNoElementsWithCustomMessage : EnumerableThrowingNoElementsWithCustomMessage<long>, IEnumerableLongThrowingNoElementsWithCustomMessage
    {
        public EnumerableLongThrowingNoElementsWithCustomMessage(IEnumerable<long> source, string messageWhenNoElements)
            : base(source, messageWhenNoElements)
        {
        }

        public long Max() => ExecWithNoElementsMessage(() => _source.Max());
        public long Min() => ExecWithNoElementsMessage(() => _source.Min());
        public double Average() => ExecWithNoElementsMessage(() => _source.Average());
    }
}
