@echo off
echo Starting Game Manager Full Stack Application...
echo.

echo Starting .NET API Backend...
start "GameManager API" cmd /k "dotnet run --project GameManagerWebAPI.csproj"

timeout /t 3 /nobreak > nul

echo Starting Angular Frontend...
start "GameManager Frontend" cmd /k "npm start"

echo.
echo Both applications are starting...
echo - Backend API: http://localhost:5142
echo - Frontend App: http://localhost:4200
echo.
echo Press any key to close this window...
pause > nul
