using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abmes.EnumerableExtensions
{
    public class ElementWithContext<T>
    {
        public T Previous { get; private set; }
        public T Next { get; private set; }
        public T Current { get; private set; }
        public int Index { get; private set; }
        public bool IsFirst { get; private set; }
        public bool IsLast { get; private set; }

        public ElementWithContext(T current, T previous, T next, int index, bool isFirst, bool isLast)
        {
            Current = current;
            Previous = previous;
            Next = next;
            Index = index;
            IsFirst = isFirst;
            IsLast = isLast;
        }
    }
}
