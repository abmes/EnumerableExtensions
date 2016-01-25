using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abmes.EnumerableExtensions
{
    public class ElementWithPositionalContext<T>
    {
        public int Index { get; private set; }
        public T Previous { get; private set; }
        public T Current { get; private set; }
        public T Next { get; private set; }
        public bool IsFirst { get; private set; }
        public bool IsLast { get; private set; }

        public ElementWithPositionalContext(int index, T previous, T current, T next, bool isFirst, bool isLast)
        {
            Index = index;
            Previous = previous;
            Current = current;
            Next = next;
            IsFirst = isFirst;
            IsLast = isLast;
        }
    }
}
