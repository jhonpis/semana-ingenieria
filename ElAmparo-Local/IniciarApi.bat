@echo off
powershell.exe -NoProfile -ExecutionPolicy Bypass -File "%~dp0IniciarApi.ps1"
if errorlevel 1 (
	echo.
	echo La API no pudo iniciarse.
	pause
)
