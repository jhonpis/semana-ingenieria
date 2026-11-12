$ErrorActionPreference = 'Stop'
$desktopExe = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..\bin\Debug\el amparo.exe'))
if (-not (Test-Path $desktopExe)) { throw 'Compile la solución en Debug antes de ejecutar este archivo.' }

Start-Process -FilePath $desktopExe -WorkingDirectory (Split-Path $desktopExe)
