@echo off
REM Lecturer VS 2026 / .NET 10 ONLY. Do not use on campus labs.
cd /d "%~dp0"
echo Switching ALL .csproj under this folder to net10.0 ...
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0switch-tfm.ps1" 10
if errorlevel 1 pause & exit /b 1
echo.
echo Restoring packages...
dotnet restore
echo.
echo DONE. Now open the .sln.
pause
