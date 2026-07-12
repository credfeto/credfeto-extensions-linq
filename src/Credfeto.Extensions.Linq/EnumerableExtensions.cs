using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Credfeto.Extensions.Linq.Helpers;

namespace Credfeto.Extensions.Linq;

public static class EnumerableExtensions
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TItemType> RemoveNulls<TItemType>(this IEnumerable<TItemType?> source)
        where TItemType : class
    {
        ArgumentNullException.ThrowIfNull(source);

        return from item in source
            where Item.Exists(item)
            select item;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TItemType> RemoveNulls<TItemType>(this IEnumerable<TItemType?> source)
        where TItemType : struct
    {
        ArgumentNullException.ThrowIfNull(source);

        return RemoveNullsIterator(source);
    }

    [Pure]
    [SuppressMessage(
        category: "SonarAnalyzer.CSharp",
        checkId: "S3267:Loops should be simplified with LINQ",
        Justification = "For performance reasons"
    )]
    private static IEnumerable<TItemType> RemoveNullsIterator<TItemType>(IEnumerable<TItemType?> source)
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
        ArgumentNullException.ThrowIfNull(enumeration);
        ArgumentNullException.ThrowIfNull(action);

        if (enumeration is List<T> list)
        {
            list.ForEach(action);
        }
        else if (enumeration is T[] array)
        {
            ForEach(source: array, action: action);
        }
        else
        {
            ForEachEnumerable(enumeration: enumeration, action: action);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [OverloadResolutionPriority(1)]
    public static void ForEach<T>(this in ReadOnlySpan<T> source, Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        ref T searchSpace = ref MemoryMarshal.GetReference(source);

        for (int index = 0; index < source.Length; ++index)
        {
            T item = Unsafe.Add(source: ref searchSpace, elementOffset: index);
            action(item);
        }
    }

    private static void ForEachEnumerable<T>(IEnumerable<T> enumeration, Action<T> action)
    {
        foreach (T item in enumeration)
        {
            action(item);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TValue? FirstOrNull<TValue>(this IEnumerable<TValue> list, Func<TValue, bool> predicate)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(predicate);

        foreach (TValue item in list)
        {
            if (predicate(item))
            {
                return item;
            }
        }

        return null;
    }
}
