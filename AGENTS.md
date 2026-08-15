# AGENTS.md

## Cloud VM notes

### What this project is
RatioMaster is a single **standalone Windows desktop app** (.NET Framework 4.7.2, WinForms).
It fakes upload/download stats reported to BitTorrent trackers (it does not run a real torrent
client). There is no backend, database, or long-running service — "running" the product means
launching `RatioMaster/bin/RatioMaster.exe`. See `README.md`.

Maintainer: **FastLife** (`FastyRepos/FastRatioMaster`). No third-party updater libraries.

### Toolchain (already installed in the VM image)
Built on Linux with **Mono**: `mono` 6.12 + `msbuild` 16.10 (official mono-project apt repo)
and `libgdiplus` (WinForms/GDI+). These are baked into the VM. The only NuGet dependency is
`Microsoft.NETFramework.ReferenceAssemblies` (build-time targeting pack, so machines without
the .NET 4.7.2 Developer Pack can still compile). Restore is required before build.

### Restore / build / run
- Restore: `msbuild RatioMaster.sln /t:restore /p:RestorePackagesConfig=true`
- Build (Release, mirrors `make.bat`): `msbuild RatioMaster.sln /t:Rebuild /p:DebugType=None /p:Configuration=Release`
  Output: `RatioMaster/bin/RatioMaster.exe`
- Run on Windows: double-click / run `RatioMaster.exe` (needs .NET Framework 4.7.2+).
- Run on Linux (best-effort GUI under Mono): `DISPLAY=:1 mono RatioMaster/bin/RatioMaster.exe`
- No separate linter or test suite; compiler warnings act as lint.
  CI (`.github/workflows/auto-build.yml`) builds on `windows-2022` for `main` (push/PR) and `workflow_dispatch`.

### Local helpers
- `AppInfo.cs` — app name/title, About, site link, “no auto-update” message
- `SingleInstance.cs` — named mutex so only one instance runs

### Core engine without GUI
`RatioMaster/BitTorrent/*` + `TorrentClientFactory` + `RandomStringGenerator` can be compiled with
`mcs` into a headless harness under Mono to exercise announce/spoof logic without WinForms.
