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

$apiProcess = $null
$launchedApi = $false
try {
	$ready = $false
	try {
		$response = Invoke-WebRequest -Uri $apiUrl -UseBasicParsing -TimeoutSec 2
		$ready = $response.StatusCode -eq 200 -and $response.Content.Contains('id="loginSection"')
	} catch {
		$ready = $false
	}

	if (-not $ready) {
		$apiProcess = Start-Process -FilePath $iisExpress -ArgumentList @('/path:"' + $apiPath + '"','/port:59539','/systray:false') -WorkingDirectory $apiPath -PassThru
		$launchedApi = $true
		$deadline = (Get-Date).AddSeconds(30)
		while ((Get-Date) -lt $deadline) {
			if ($apiProcess.HasExited) { throw 'IIS Express se cerró antes de iniciar la API.' }
			try {
				$response = Invoke-WebRequest -Uri $apiUrl -UseBasicParsing -TimeoutSec 2
				if ($response.StatusCode -eq 200 -and $response.Content.Contains('id="loginSection"')) { $ready = $true; break }
			} catch { Start-Sleep -Milliseconds 500 }
		}
	}

	if (-not $ready) { throw "La API de ElAmparo-Local no respondió en $apiUrl" }
	Write-Host "API activa en $apiUrl" -ForegroundColor Green
	Start-Process $apiUrl
	Write-Host 'Presione Ctrl+C para cerrar este lanzador.'
	while ($true) {
		Start-Sleep -Seconds 1
		if ($launchedApi -and $apiProcess.HasExited) { throw 'IIS Express se cerró inesperadamente.' }
	}
}
finally {
	if ($launchedApi -and $apiProcess -and -not $apiProcess.HasExited) { $apiProcess.Kill(); $apiProcess.WaitForExit() }
}
