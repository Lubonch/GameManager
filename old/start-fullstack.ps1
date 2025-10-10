param(
    [switch]$NoWait
)

Write-Host "🚀 Starting Game Manager Full Stack Application..." -ForegroundColor Green
Write-Host ""

# Function to start a process in background
function Start-BackgroundProcess {
    param(
        [string]$Name,
        [string]$Command,
        [string]$WorkingDirectory = $null
    )

    Write-Host "Starting $Name..." -ForegroundColor Yellow

    $startInfo = New-Object System.Diagnostics.ProcessStartInfo
    $startInfo.FileName = "cmd.exe"
    $startInfo.Arguments = "/c $Command"
    if ($WorkingDirectory) {
        $startInfo.WorkingDirectory = $WorkingDirectory
    }
    $startInfo.UseShellExecute = $true
    $startInfo.WindowStyle = [System.Diagnostics.ProcessWindowStyle]::Normal

    $process = New-Object System.Diagnostics.Process
    $process.StartInfo = $startInfo
    $process.Start() | Out-Null

    Write-Host "$Name started successfully!" -ForegroundColor Green
}

# Start .NET API Backend
Start-BackgroundProcess -Name ".NET API Backend" -Command "dotnet run --project GameManagerWebAPI.csproj"

# Wait a moment for the API to start
Start-Sleep -Seconds 3

# Start Angular Frontend
Start-BackgroundProcess -Name "Angular Frontend" -Command "npm start"

Write-Host ""
Write-Host "🎯 Both applications are starting..." -ForegroundColor Cyan
Write-Host "📡 Backend API: http://localhost:5142" -ForegroundColor Blue
Write-Host "🌐 Frontend App: http://localhost:4200" -ForegroundColor Blue
Write-Host ""
Write-Host "💡 Tip: You can access the API documentation at http://localhost:5142/swagger" -ForegroundColor Magenta
Write-Host ""

if (-not $NoWait) {
    Write-Host "Press any key to exit..." -ForegroundColor Yellow
    $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
}
