using System;
using System.Runtime.CompilerServices;

namespace Credfeto.Extensions.Linq;

public static class SpanExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Aggregate<T>(this in ReadOnlySpan<T> states, T seed, Func<T, T, T> func)
        where T : notnull
    {
        T max = seed;

        foreach (T next in states)
        {
            max = func(arg1: max, arg2: next);
        }

        return max;
    }
}