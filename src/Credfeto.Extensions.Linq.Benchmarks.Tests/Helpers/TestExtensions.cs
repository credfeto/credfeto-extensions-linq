using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Credfeto.Extensions.Linq.Benchmarks.Helpers;

internal static class TestExtensions
{
    private static void TestActionObjectItem<T>(this T value)
        where T : class
    {
        // Deliberately blank
    }

    private static void TestActionStructItem<T>(this T value)
        where T : struct
    {
        // Deliberately blank
    }

    public static void TestEnumerableObjectAction<T>(this IEnumerable<T> value)
        where T : class
    {
        foreach (T item in value)
        {
            item.TestActionObjectItem();
        }
    }

    public static void TestEnumerableStructAction<T>(this IEnumerable<T> value)
        where T : struct
    {
        foreach (T item in value)
        {
            item.TestActionStructItem();
        }
    }
}
