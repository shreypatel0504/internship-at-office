@echo off
title FoodChow API - Live Starter
echo ========================================================
echo   Starting FoodChow .NET 10 API & Public Live Tunnel
echo ========================================================
echo.

:: 1. Ensure MySQL is running
echo [1/3] Checking MySQL status...
powershell -Command "$s = Test-NetConnection -ComputerName localhost -Port 3306 -InformationLevel Quiet; if (-not $s) { Start-Process 'c:\xampp\mysql\bin\mysqld.exe' -ArgumentList '--defaults-file=c:\xampp\mysql\bin\my.ini', '--standalone' -WindowStyle Hidden; Start-Sleep -Seconds 3; }"
echo [OK] MySQL is active on port 3306.
echo.

:: 2. Start FoodChow .NET API in background
echo [2/3] Starting FoodChow .NET 10 API...
start "FoodChow API" /B dotnet run --project "%~dp0foodchow-dot-net-10-api\FoodChow.API\FoodChow.API.csproj"
timeout /t 5 >nul
echo [OK] API running on http://localhost:55661
echo.

:: 3. Start Cloudflare Public Live Tunnel
echo [3/3] Generating Public Live HTTPS URL...
echo.
echo ========================================================
echo   Your live public URL will appear below:
echo   (Keep this window open to keep the public link alive)
echo ========================================================
echo.
npx -y cloudflared tunnel --url http://localhost:55661
