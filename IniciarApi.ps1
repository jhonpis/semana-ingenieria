$ErrorActionPreference = 'Stop'
$apiPath = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..\ElAmparo\API'))
$apiUrl = 'http://localhost:59539/'

if (-not (Test-Path (Join-Path $apiPath 'Web.config'))) {
	throw "No se encontró la API en: $apiPath"
}

$iisCandidates = @(
	(Join-Path ${env:ProgramW6432} 'IIS Express\iisexpress.exe'),
	(Join-Path $env:ProgramFiles 'IIS Express\iisexpress.exe'),
	(Join-Path ${env:ProgramFiles(x86)} 'IIS Express\iisexpress.exe')
)

$visualStudioRoot = Join-Path $env:ProgramFiles 'Microsoft Visual Studio'
if (Test-Path $visualStudioRoot) {
	$iisCandidates += Get-ChildItem $visualStudioRoot -Directory -ErrorAction SilentlyContinue |
		ForEach-Object { Get-ChildItem $_.FullName -Directory -ErrorAction SilentlyContinue } |
		ForEach-Object { Join-Path $_.FullName 'Common7\IDE\IISExpress\iisexpress.exe' }
}

$iisExpress = $iisCandidates | Where-Object { $_ -and (Test-Path $_) } | Select-Object -First 1
if (-not $iisExpress) {
	throw 'No se encontró IIS Express. Instálelo desde Visual Studio Installer.'
}

$apiProcess = Get-Process iisexpress -ErrorAction SilentlyContinue | Select-Object -First 1
$launchedApi = $false

try {
	$ready = $false
	try {
		$response = Invoke-WebRequest -Uri $apiUrl -UseBasicParsing -TimeoutSec 2
		$ready = $response.StatusCode -eq 200 -and $response.Content.Contains('Sociedad Protectora de Animales El Amparo')
	}
	catch {
		$ready = $false
	}

	if (-not $ready) {
		Write-Host "Iniciando API desde $apiPath ..."
		$apiProcess = Start-Process -FilePath $iisExpress -ArgumentList @('/path:' + $apiPath, '/port:59539', '/systray:false') -WorkingDirectory $apiPath -PassThru
		$launchedApi = $true

		$deadline = (Get-Date).AddSeconds(30)
		while ((Get-Date) -lt $deadline) {
			if ($apiProcess.HasExited) {
				throw 'IIS Express se cerró antes de que la API estuviera disponible.'
			}

			try {
				$response = Invoke-WebRequest -Uri $apiUrl -UseBasicParsing -TimeoutSec 2
				if ($response.StatusCode -eq 200 -and $response.Content.Contains('Sociedad Protectora de Animales El Amparo')) {
					$ready = $true
					break
				}
			}
			catch {
				Start-Sleep -Milliseconds 500
			}
		}

		if (-not $ready) {
			throw "La API no respondió correctamente en $apiUrl"
		}
	}

	Write-Host ''
	Write-Host 'API de El Amparo ejecutándose correctamente.' -ForegroundColor Green
	Write-Host "URL: $apiUrl"
	Write-Host 'Presione Ctrl+C para detenerla.'
	while ($true) {
		Start-Sleep -Seconds 1
		if ($launchedApi -and $apiProcess.HasExited) {
			throw 'El proceso de IIS Express se cerró inesperadamente.'
		}
	}
}
finally {
	if ($launchedApi -and $apiProcess -and -not $apiProcess.HasExited) {
		$apiProcess.Kill()
		$apiProcess.WaitForExit()
	}
}
