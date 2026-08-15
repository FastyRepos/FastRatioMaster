# RatioMaster

[![Last commit](https://img.shields.io/github/last-commit/FastyRepos/FastRatioMaster?style=for-the-badge&color=00AD00)](https://github.com/FastyRepos/FastRatioMaster)

## About

RatioMaster is a small standalone Windows application which fakes upload and download stats of a torrent to almost all BitTorrent trackers.

This means that it does NOT rely on your BitTorrent client (uTorrent, Azureus, BitComet, ABC, etc.) and it will NOT download/upload the files on a torrent — it only fakes download/upload stats.

RatioMaster has hardcoded emulations for commonly used BitTorrent clients: uTorrent, BitComet, Azureus, ABC, BitLord, BTuga, BitTornado, Burst, BitTyrant, BitSpirit.

## What will it look like?

[<img src="preview.png" alt="RatioMaster preview" width="300"/>](preview.png)

## Download

Published builds (when available) are on this repository’s [releases](https://github.com/FastyRepos/FastRatioMaster/releases) page.

## Development

See `AGENTS.md` for Cloud/agent notes.

### Prerequisites (`make.bat`)

- Windows
- [Visual Studio Build Tools 2022](https://visualstudio.microsoft.com/visual-cpp-build-tools/) (or full Visual Studio) with **MSBuild**. Workload: **.NET desktop build tools**
- Internet on the first restore (NuGet pulls `Microsoft.NETFramework.ReferenceAssemblies.net472` from nuget.org)

The .NET 4.7.2 Developer Pack is **not** required to compile. `nuget.exe` is not required either (`msbuild /t:restore` handles it).

To **run** `RatioMaster.exe`: .NET Framework 4.7.2+ (included on current Windows 10/11). Close the app before rebuilding, or the copy to `bin\` will fail.

Then, from the repo root:

```bat
make.bat
```

Or:

```bat
msbuild RatioMaster.sln /t:restore /p:RestorePackagesConfig=true
msbuild RatioMaster.sln /t:Rebuild /p:Configuration=Release
```

Output: `RatioMaster\bin\RatioMaster.exe`

## How can I help improve it?

Feedback and contributions are welcome. Open an issue or pull request on
[FastyRepos/FastRatioMaster](https://github.com/FastyRepos/FastRatioMaster).

## Warranty

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
