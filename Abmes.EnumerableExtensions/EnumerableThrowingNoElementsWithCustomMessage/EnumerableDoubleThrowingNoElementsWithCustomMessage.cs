using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abmes.EnumerableExtensions.EnumerableThrowingNoElementsWithCustomMessage
{
    public interface IEnumerableDoubleThrowingNoElementsWithCustomMessage : IEnumerableThrowingNoElementsWithCustomMessage<double>
    {
        double Max();
        double Min();
        double Average();
    }

    class EnumerableDoubleThrowingNoElementsWithCustomMessage : EnumerableThrowingNoElementsWithCustomMessage<double>, IEnumerableDoubleThrowingNoElementsWithCustomMessage
    {
        public EnumerableDoubleThrowingNoElementsWithCustomMessage(IEnumerable<double> source, string messageWhenNoElements)
            : base(source, messageWhenNoElements)
        {
        }

        public double Max() => ExecWithNoElementsMessage(() => _source.Max());
        public double Min() => ExecWithNoElementsMessage(() => _source.Min());
        public double Average() => ExecWithNoElementsMessage(() => _source.Average());
    }
}
