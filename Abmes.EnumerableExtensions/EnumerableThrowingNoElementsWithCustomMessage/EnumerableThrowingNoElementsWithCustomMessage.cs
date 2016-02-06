using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abmes.EnumerableExtensions.EnumerableThrowingNoElementsWithCustomMessage
{
    public interface IEnumerableThrowingNoElementsWithCustomMessage<TSource>
    {
        TSource Aggregate(Func<TSource, TSource, TSource> func);

        TSource Single();
        TSource Single(Func<TSource, bool> predicate);

        TSource SingleOrDefault();
        TSource SingleOrDefault(Func<TSource, bool> predicate);

        TSource First();
        TSource First(Func<TSource, bool> predicate);

        TSource Last();
        TSource Last(Func<TSource, bool> predicate);

        int Max(Func<TSource, int> selector);
        long Max(Func<TSource, long> selector);
        float Max(Func<TSource, float> selector);
        double Max(Func<TSource, double> selector);
        decimal Max(Func<TSource, decimal> selector);

        int Min(Func<TSource, int> selector);
        long Min(Func<TSource, long> selector);
        float Min(Func<TSource, float> selector);
        double Min(Func<TSource, double> selector);
        decimal Min(Func<TSource, decimal> selector);

        double Average(Func<TSource, int> selector);
        double Average(Func<TSource, long> selector);
        float Average(Func<TSource, float> selector);
        double Average(Func<TSource, double> selector);
        decimal Average(Func<TSource, decimal> selector);
    }

    class EnumerableThrowingNoElementsWithCustomMessage<TSource> : IEnumerableThrowingNoElementsWithCustomMessage<TSource>
    {
        private readonly IEnumerable<string> _noElementsExceptionMessages = new[]
        {
            "Sequence contains no elements",
            "Sequence contains no matching element",
            "Sequence contains more than one matching element"
        };

        protected readonly IEnumerable<TSource> _source;
        private readonly string _messageWhenNoElements;

        public EnumerableThrowingNoElementsWithCustomMessage(IEnumerable<TSource> source, string messageWhenNoElements)
        {
            _source = source;
            _messageWhenNoElements = messageWhenNoElements;
        }

        protected T ExecWithNoElementsMessage<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (InvalidOperationException e) when (_noElementsExceptionMessages.Contains(e.Message))
            {
                throw new InvalidOperationException(_messageWhenNoElements, e);
            }
        }

        public TSource Aggregate(Func<TSource, TSource, TSource> func) => ExecWithNoElementsMessage(() => _source.Aggregate(func));

        public TSource Single() => ExecWithNoElementsMessage(() => _source.Single());
        public TSource Single(Func<TSource, bool> predicate) => ExecWithNoElementsMessage(() => _source.Single(predicate));

        public TSource SingleOrDefault() => ExecWithNoElementsMessage(() => _source.SingleOrDefault());
        public TSource SingleOrDefault(Func<TSource, bool> predicate) => ExecWithNoElementsMessage(() => _source.SingleOrDefault(predicate));

        public TSource First() => ExecWithNoElementsMessage(() => _source.First());
        public TSource First(Func<TSource, bool> predicate) => ExecWithNoElementsMessage(() => _source.First(predicate));

        public TSource Last() => ExecWithNoElementsMessage(() => _source.Last());
        public TSource Last(Func<TSource, bool> predicate) => ExecWithNoElementsMessage(() => _source.Last(predicate));

        public int Max(Func<TSource, int> selector) => ExecWithNoElementsMessage(() => _source.Max(selector));
        public long Max(Func<TSource, long> selector) => ExecWithNoElementsMessage(() => _source.Max(selector));
        public float Max(Func<TSource, float> selector) => ExecWithNoElementsMessage(() => _source.Max(selector));
        public double Max(Func<TSource, double> selector) => ExecWithNoElementsMessage(() => _source.Max(selector));
        public decimal Max(Func<TSource, decimal> selector) => ExecWithNoElementsMessage(() => _source.Max(selector));

        public int Min(Func<TSource, int> selector) => ExecWithNoElementsMessage(() => _source.Min(selector));
        public long Min(Func<TSource, long> selector) => ExecWithNoElementsMessage(() => _source.Min(selector));
        public float Min(Func<TSource, float> selector) => ExecWithNoElementsMessage(() => _source.Min(selector));
        public double Min(Func<TSource, double> selector) => ExecWithNoElementsMessage(() => _source.Min(selector));
        public decimal Min(Func<TSource, decimal> selector) => ExecWithNoElementsMessage(() => _source.Min(selector));

        public double Average(Func<TSource, int> selector) => ExecWithNoElementsMessage(() => _source.Average(selector));
        public double Average(Func<TSource, long> selector) => ExecWithNoElementsMessage(() => _source.Average(selector));
        public float Average(Func<TSource, float> selector) => ExecWithNoElementsMessage(() => _source.Average(selector));
        public double Average(Func<TSource, double> selector) => ExecWithNoElementsMessage(() => _source.Average(selector));
        public decimal Average(Func<TSource, decimal> selector) => ExecWithNoElementsMessage(() => _source.Average(selector));
    }
}
