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
| RemoveNullsClassProduction  |   752.8 us | 25.83 us | 75.74 us |   781.7 us |   588.6 us |   880.8 us |    904 KB |
| RemoveNullsClassLoop        | 1,302.9 us | 25.02 us | 27.81 us | 1,295.8 us | 1,251.7 us | 1,358.3 us | 904.04 KB |
| RemoveNullsClassLinq        |   751.0 us | 15.01 us | 14.04 us |   748.3 us |   733.7 us |   771.9 us | 904.07 KB |
| RemoveNullsClassLinqItem    |   743.3 us | 14.83 us | 17.08 us |   740.4 us |   713.1 us |   778.8 us | 904.16 KB |
| RemoveNullsStructProduction |   852.8 us | 16.86 us | 18.04 us |   848.8 us |   815.3 us |   896.1 us | 452.39 KB |
| RemoveNullsStructLoop       |   787.1 us | 22.86 us | 65.59 us |   815.4 us |   656.3 us |   862.0 us |  452.4 KB |
| RemoveNullsStructLinq       | 1,086.2 us | 33.06 us | 97.47 us | 1,123.2 us |   912.3 us | 1,338.8 us | 452.15 KB |
| RemoveNullsStructLinqItem   | 1,090.4 us | 27.79 us | 80.17 us | 1,123.2 us |   915.4 us | 1,183.7 us | 452.17 KB |

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