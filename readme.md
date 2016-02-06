Abmes.EnumerableExtensions
==========================
[![abmes MyGet Build Status](https://www.myget.org/BuildSource/Badge/abmes?identifier=4802f8fc-236a-4916-9428-06f61dba32ca)](https://www.myget.org/)

This package contains extension methods for enumerables: [NuGet link](https://www.nuget.org/packages/Abmes.EnumerableExtensions/)

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

WithExceptionMessageWhenNoElements
----------------------------------

This is an extension method for changing the default message of the exception thrown by some methods of the IEnumerable like Single, First and others when the sequence contains no elements.

The original messages of the thrown InvalidOperationException are
* Sequence contains no elements
* Sequence contains no matching element
* Sequence contains more than one matching element

The extension method wraps the call and if such an InvalidOperationException (with one of the above messages) is thrown it creates and throws a new InvalidOperationException with the specified message and sets the InnerException to the original InvalidOperationException.

Sample usage:
```c#
public Address GetCustomerFirstMainAddress(IEnumerable<Address> customerAddresses) =>
    customerAddresses
        .Where(a => a.IsMain)
        .WithExceptionMessageWhenNoElements("The customer does not have a main address")
        .First();
```
