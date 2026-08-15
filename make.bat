@echo off
setlocal

FOR /F "tokens=* USEBACKQ" %%F IN (`"%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe" -latest -prerelease -products * -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe`) DO (
SET msbuild="%%F"
)

if not defined msbuild (
  echo MSBuild not found. Install Visual Studio Build Tools.
  goto error
)

ECHO %msbuild%

%msbuild% RatioMaster.sln /t:restore /p:RestorePackagesConfig=true
if errorlevel 1 goto error

%msbuild% RatioMaster.sln /t:Rebuild /p:DebugType=None /p:Configuration=Release
if errorlevel 1 goto error

echo.
echo Build OK: RatioMaster\bin\RatioMaster.exe
goto exit

:error
echo.
echo Build failed.
pause
:exit
