@echo off
title Auto Push to MAIN

cd /d "C:\Users\Shivaar\source\repos\Shiv0130\C-Sharp"

echo ============================
echo   PUSHING TO MAIN BRANCH
echo ============================

:: Ensure we're on main
git checkout main

:: Pull latest
git pull origin main

:: Add everything
git add .

:: Check if changes exist
git diff --cached --quiet
if %errorlevel%==0 (
    echo No changes to push ✅
    pause
    exit /b
)

:: Auto commit
set msg=Auto commit on %date% %time%
git commit -m "%msg%"

:: Push
git push origin main

echo.
echo SUCCESS 🚀 Everything is on GitHub (main branch)
pause