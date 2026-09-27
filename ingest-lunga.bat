@echo off
setlocal
REM Use this when Mr Lunga emails / Moodle-drops a ZIP that was built on net10.
REM 1. Extract the zip to a folder.
REM 2. Run this bat. Paste the extracted folder path.
REM 3. Scripts are copied IN that folder, then retargeted to net8 (lab) by default.

echo.
echo === Lunga zip ingest ===
echo Extract the zip FIRST. Then paste the full folder path.
echo Example: C:\Users\You\Downloads\PRO742_Relationships
echo.
set /p TARGET=Extracted folder: 

if not exist "%TARGET%" (
  echo Folder not found: %TARGET%
  pause
  exit /b 1
)

echo Copying switch scripts into that folder...
copy /Y "%~dp0switch-tfm.ps1" "%TARGET%\switch-tfm.ps1" >nul
copy /Y "%~dp0to-net8.bat"     "%TARGET%\to-net8.bat"     >nul
copy /Y "%~dp0to-net9.bat"     "%TARGET%\to-net9.bat"     >nul
copy /Y "%~dp0to-net10.bat"    "%TARGET%\to-net10.bat"    >nul

echo.
echo Which machine are you on?
echo   8 = campus lab
echo   9 = your laptop
echo   10 = Lunga demo machine
set /p MAJOR=Major [8/9/10] (default 8): 
if "%MAJOR%"=="" set MAJOR=8

powershell -NoProfile -ExecutionPolicy Bypass -File "%TARGET%\switch-tfm.ps1" %MAJOR%
if errorlevel 1 pause & exit /b 1

echo Restoring inside the extracted project...
pushd "%TARGET%"
dotnet restore
popd

echo.
echo DONE. Open the .sln that lives INSIDE:
echo   %TARGET%
echo Do not open Visual Studio before this script finishes.
pause
