$ErrorActionPreference = 'Stop'
$root = $PSScriptRoot
$apiPath = Join-Path $root 'API'
$desktopExe = Join-Path $root 'Escritorio\bin\Debug\el amparo.exe'
$apiUrl = 'http://localhost:59539/'
$iis = @(
	(Join-Path ${env:ProgramW6432} 'IIS Express\iisexpress.exe'),
	(Join-Path $env:ProgramFiles 'IIS Express\iisexpress.exe'),
	(Join-Path ${env:ProgramFiles(x86)} 'IIS Express\iisexpress.exe')
) | Where-Object { $_ -and (Test-Path $_) } | Select-Object -First 1
if (-not $iis) { throw 'No se encontró IIS Express.' }
if (-not (Test-Path $desktopExe)) { throw 'Compile la solución en Debug antes de ejecutar este archivo.' }

$apiProcess = Start-Process -FilePath $iis -ArgumentList @('/path:"' + $apiPath + '"','/port:59539','/systray:false') -WorkingDirectory $apiPath -PassThru
try {
	$ready = $false
	$deadline = (Get-Date).AddSeconds(30)
	while ((Get-Date) -lt $deadline) {
		if ($apiProcess.HasExited) { throw 'IIS Express se cerró antes de iniciar la API.' }
		try {
			$response = Invoke-WebRequest -Uri $apiUrl -UseBasicParsing -TimeoutSec 2
			if ($response.StatusCode -eq 200 -and $response.Content.Contains('Sociedad Protectora de Animales El Amparo')) { $ready = $true; break }
		} catch { Start-Sleep -Milliseconds 500 }
	}
	if (-not $ready) { throw 'La API no respondió correctamente.' }
	Write-Host 'API iniciada. Abriendo login y formularios...' -ForegroundColor Green
	$desktop = Start-Process -FilePath $desktopExe -WorkingDirectory (Join-Path $root 'Escritorio') -Wait -PassThru
	exit $desktop.ExitCode
}
finally {
	if ($apiProcess -and -not $apiProcess.HasExited) { $apiProcess.Kill(); $apiProcess.WaitForExit() }
}
