Abmes.EnumerableExtensions
==========================
[![abmes MyGet Build Status](https://www.myget.org/BuildSource/Badge/abmes?identifier=4802f8fc-236a-4916-9428-06f61dba32ca)](https://www.myget.org/)

This package contains extension methods for enumerables

WithPositionalContext extension
-------------------------------

This is an extension method for adding positional context to the elements of an ICollection.

It maps each element to an ElementWithPositionalContext which has details about its position - Index, Previous, Current and Next element as well as IsFirst and IsLast flags.

The extension is based on [this blogpost](http://www.siepman.nl/blog/post/2015/02/09/Add-context-to-IEnumerable-elements.aspx) by Alex Siepman

Sample usage:
```c#
public IEnumerable<int> GetLocalMaxima(ICollection<int> items) =>
    items.WithPositionalContext().Where(x => (x.Previous < x.Current) && (x.Current > x.Next)).Select(x => x.Current);
```
