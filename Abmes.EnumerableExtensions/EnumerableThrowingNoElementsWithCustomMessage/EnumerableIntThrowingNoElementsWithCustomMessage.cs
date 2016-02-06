using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abmes.EnumerableExtensions.EnumerableThrowingNoElementsWithCustomMessage
{
    public interface IEnumerableIntThrowingNoElementsWithCustomMessage : IEnumerableThrowingNoElementsWithCustomMessage<int>
    {
        int Max();
        int Min();
        double Average();
    }

    class EnumerableIntThrowingNoElementsWithCustomMessage : EnumerableThrowingNoElementsWithCustomMessage<int>, IEnumerableIntThrowingNoElementsWithCustomMessage
    {
        public EnumerableIntThrowingNoElementsWithCustomMessage(IEnumerable<int> source, string messageWhenNoElements)
            : base(source, messageWhenNoElements)
        {
        }

        public int Max() => ExecWithNoElementsMessage(() => _source.Max());
        public int Min() => ExecWithNoElementsMessage(() => _source.Min());
        public double Average() => ExecWithNoElementsMessage(() => _source.Average());
    }
}
