using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abmes.EnumerableExtensions.EnumerableThrowingNoElementsWithCustomMessage
{
    public interface IEnumerableFloatThrowingNoElementsWithCustomMessage : IEnumerableThrowingNoElementsWithCustomMessage<float>
    {
        float Max();
        float Min();
        float Average();
    }

    class EnumerableFloatThrowingNoElementsWithCustomMessage : EnumerableThrowingNoElementsWithCustomMessage<float>, IEnumerableFloatThrowingNoElementsWithCustomMessage
    {
        public EnumerableFloatThrowingNoElementsWithCustomMessage(IEnumerable<float> source, string messageWhenNoElements)
            : base(source, messageWhenNoElements)
        {
        }

        public float Max() => ExecWithNoElementsMessage(() => _source.Max());
        public float Min() => ExecWithNoElementsMessage(() => _source.Min());
        public float Average() => ExecWithNoElementsMessage(() => _source.Average());
    }
}
