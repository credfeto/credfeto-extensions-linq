using System.Collections.Generic;
using System.Linq;

namespace Credfeto.Extensions.Linq;

public static class EnumerableExtensions
{
    public static IEnumerable<TItemType> RemoveNulls<TItemType>(this IEnumerable<TItemType?> source)
        where TItemType : class
    {
        return from TItemType? item in source
               where item is not null
               select item;
    }

    public static IEnumerable<TItemType> RemoveNulls<TItemType>(this IEnumerable<TItemType?> source)
        where TItemType : struct
    {
        return from TItemType? item in source
               where item.HasValue
               select item.Value;
    }
}