using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abmes.EnumerableExtensions.EnumerableThrowingNoElementsWithCustomMessage
{
    public interface IEnumerableDecimalThrowingNoElementsWithCustomMessage : IEnumerableThrowingNoElementsWithCustomMessage<decimal>
    {
        decimal Max();
        decimal Min();
        decimal Average();
    }

    class EnumerableDecimalThrowingNoElementsWithCustomMessage : EnumerableThrowingNoElementsWithCustomMessage<decimal>, IEnumerableDecimalThrowingNoElementsWithCustomMessage
    {
        public EnumerableDecimalThrowingNoElementsWithCustomMessage(IEnumerable<decimal> source, string messageWhenNoElements)
            : base(source, messageWhenNoElements)
        {
        }

        public decimal Max() => ExecWithNoElementsMessage(() => _source.Max());
        public decimal Min() => ExecWithNoElementsMessage(() => _source.Min());
        public decimal Average() => ExecWithNoElementsMessage(() => _source.Average());
    }
}
