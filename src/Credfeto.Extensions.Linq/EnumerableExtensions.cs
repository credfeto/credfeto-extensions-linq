using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using Credfeto.Extensions.Linq.Helpers;

namespace Credfeto.Extensions.Linq;

public static class EnumerableExtensions
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TItemType> RemoveNulls<TItemType>(this IEnumerable<TItemType?> source)
        where TItemType : class
    {
        return from item in source where Item.Exists(item) select item;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage(
        category: "SonarAnalyzer.CSharp",
        checkId: "S3267:Loops should be simplified with LINQ",
        Justification = "For performance reasons"
    )]
    public static IEnumerable<TItemType> RemoveNulls<TItemType>(this IEnumerable<TItemType?> source)
        where TItemType : struct
    {
        foreach (TItemType? item in source)
        {
            if (Item.Exists(item))
            {
                yield return item.Value;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
    {
        foreach (T item in enumeration)
        {
            action(item);
        }
    }
}
