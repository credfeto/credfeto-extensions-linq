# credfeto-extensions-linq
<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
[![All Contributors](https://img.shields.io/badge/all_contributors-1-orange.svg?style=flat-square)](#contributors-)
<!-- ALL-CONTRIBUTORS-BADGE:END -->

C# LINQ Extension methods

## Build Status

| Branch  | Status                                                                                                                                                                                                                                                |
|---------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| main    | [![Build: Pre-Release](https://github.com/credfeto/credfeto-extensions-linq/actions/workflows/build-and-publish-pre-release.yml/badge.svg)](https://github.com/credfeto/credfeto-extensions-linq/actions/workflows/build-and-publish-pre-release.yml) |
| release | [![Build: Release](https://github.com/credfeto/credfeto-extensions-linq/actions/workflows/build-and-publish-release.yml/badge.svg)](https://github.com/credfeto/credfeto-extensions-linq/actions/workflows/build-and-publish-release.yml)             |

## Changelog

View [changelog](CHANGELOG.md)

## Benchmarks

### EnumerableExtensions.RemoveNulls

| Method                      |       Mean |    Error |   StdDev |     Median |        Min |        Max | Allocated |
|-----------------------------|-----------:|---------:|---------:|-----------:|-----------:|-----------:|----------:|
| RemoveNullsClassProduction  |   570.0 us | 10.96 us | 15.01 us |   569.7 us |   541.6 us |   598.7 us |      49 B |
| RemoveNullsClassLoop        |   860.7 us | 16.31 us | 16.01 us |   855.9 us |   846.3 us |   898.9 us |      89 B |
| RemoveNullsClassLinq        |   525.9 us | 10.40 us | 17.66 us |   527.6 us |   490.2 us |   559.4 us |      49 B |
| RemoveNullsClassLinqItem    |   519.3 us | 10.34 us | 15.48 us |   515.2 us |   498.6 us |   558.2 us |      49 B |
| RemoveNullsStructProduction |   711.8 us | 11.07 us |  9.81 us |   711.3 us |   695.0 us |   732.0 us |      89 B |
| RemoveNullsStructLoop       |   673.3 us | 12.35 us | 10.95 us |   670.2 us |   661.0 us |   697.7 us |      89 B |
| RemoveNullsStructLinq       | 1,207.6 us | 32.86 us | 96.90 us | 1,249.2 us | 1,038.2 us | 1,432.5 us |     105 B |
| RemoveNullsStructLinqItem   | 1,262.3 us | 15.75 us | 13.15 us | 1,260.0 us | 1,240.5 us | 1,293.7 us |     105 B |

// * Warnings *
MultimodalDistribution
EnumerableRemoveNullsBenchmark.RemoveNullsStructLinq: Default -> It seems that the distribution can have several modes (
mValue = 2.89)

// * Hints *
Outliers
EnumerableRemoveNullsBenchmark.RemoveNullsClassProduction: Default -> 1 outlier was removed (636.74 us)
EnumerableRemoveNullsBenchmark.RemoveNullsClassLoop: Default -> 1 outlier was removed (961.02 us)
EnumerableRemoveNullsBenchmark.RemoveNullsClassLinq: Default -> 1 outlier was removed (574.63 us)
EnumerableRemoveNullsBenchmark.RemoveNullsClassLinqItem: Default -> 2 outliers were removed (573.86 us, 695.18 us)
EnumerableRemoveNullsBenchmark.RemoveNullsStructProduction: Default -> 1 outlier was removed (751.60 us)
EnumerableRemoveNullsBenchmark.RemoveNullsStructLoop: Default -> 1 outlier was removed (742.21 us)
EnumerableRemoveNullsBenchmark.RemoveNullsStructLinqItem: Default -> 2 outliers were removed (1.34 ms, 1.45 ms)

// * Legends *
Mean      : Arithmetic mean of all measurements
Error     : Half of 99.9% confidence interval
StdDev    : Standard deviation of all measurements
Median    : Value separating the higher half of all measurements (50th percentile)
Min       : Minimum
Max       : Maximum
Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
1 us      : 1 Microsecond (0.000001 sec)

// * Diagnostic Output - MemoryDiagnoser *

// ***** BenchmarkRunner: End *****

Notes

* RemoveNullsClassProduction and RemoveNullsClassLinqItem are the same implementation, just in different assemblies
* RemoveNullsStructProduction and RemoveNullsStructLoop are the same implementation, just in different assemblies

## Contributors

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tbody>
    <tr>
      <td align="center" valign="top" width="14.28%"><a href="https://github.com/cestrand"><img src="https://avatars.githubusercontent.com/u/6875883?v=4?s=100" width="100px;" alt="Marcin Kolenda"/><br /><sub><b>Marcin Kolenda</b></sub></a><br /><a href="https://github.com/credfeto/credfeto-extensions-linq/commits?author=cestrand" title="Code">💻</a></td>
    </tr>
  </tbody>
</table>

<!-- markdownlint-restore -->
<!-- prettier-ignore-end -->

<!-- ALL-CONTRIBUTORS-LIST:END -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->

<!-- markdownlint-restore -->
<!-- prettier-ignore-end -->

<!-- ALL-CONTRIBUTORS-LIST:END -->