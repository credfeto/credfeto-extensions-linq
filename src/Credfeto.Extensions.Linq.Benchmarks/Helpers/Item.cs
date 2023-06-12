using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Credfeto.Extensions.Linq.Benchmarks.Helpers;

internal static class Item
{
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Exists<TItemType>([NotNullWhen(true)] TItemType? item)
        where TItemType : class
    {
        return item is not null;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Exists<TItemType>([NotNullWhen(true)] TItemType? item)
        where TItemType : struct
    {
        return item.HasValue;
    }
}