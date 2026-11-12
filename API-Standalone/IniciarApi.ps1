$ErrorActionPreference = 'Stop'
$apiPath = Join-Path $PSScriptRoot 'API'
$apiUrl = 'http://localhost:59539/'

$iisCandidates = @(
	(Join-Path ${env:ProgramW6432} 'IIS Express\iisexpress.exe'),
	(Join-Path $env:ProgramFiles 'IIS Express\iisexpress.exe'),
	(Join-Path ${env:ProgramFiles(x86)} 'IIS Express\iisexpress.exe')
)
$iisExpress = $iisCandidates | Where-Object { $_ -and (Test-Path $_) } | Select-Object -First 1
if (-not $iisExpress) { throw 'No se encontró IIS Express.' }
if (-not (Test-Path (Join-Path $apiPath 'Web.config'))) { throw "No se encontró la API en $apiPath" }

$apiProcess = Start-Process -FilePath $iisExpress -ArgumentList @('/path:"' + $apiPath + '"', '/port:59539', '/systray:false') -WorkingDirectory $apiPath -PassThru
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
	if (-not $ready) { throw "La API no respondió en $apiUrl" }
	Write-Host "API activa en $apiUrl" -ForegroundColor Green
	Write-Host 'Presione Ctrl+C para detener la API.'
	while ($true) { Start-Sleep -Seconds 1 }
}
finally {
	if ($apiProcess -and -not $apiProcess.HasExited) { $apiProcess.Kill(); $apiProcess.WaitForExit() }
}
