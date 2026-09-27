# switch-tfm.ps1
# Retarget every .csproj under this folder: net8.0 / net9.0 / net10.0
# Also retargets Microsoft.AspNetCore.* and Microsoft.EntityFrameworkCore.* package majors.
#
# Usage:
#   powershell -ExecutionPolicy Bypass -File .\switch-tfm.ps1 8
#   powershell -ExecutionPolicy Bypass -File .\switch-tfm.ps1 9
#   powershell -ExecutionPolicy Bypass -File .\switch-tfm.ps1 10
#
# Then open the .sln. Do NOT open Visual Studio first.

param(
    [Parameter(Mandatory = $true)]
    [ValidateSet("8", "9", "10")]
    [string]$Major
)

$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $MyInvocation.MyCommand.Path
if (-not $root) { $root = Get-Location }

$tfm = "net$Major.0"
$pkgMajor = $Major

Write-Host "Root: $root"
Write-Host "Target: $tfm"
Write-Host ""

$csprojs = Get-ChildItem -Path $root -Filter *.csproj -Recurse -File |
    Where-Object { $_.FullName -notmatch '\\(bin|obj|\.vs)\\' }

if (-not $csprojs) {
    Write-Host "No .csproj files found under $root"
    exit 1
}

foreach ($file in $csprojs) {
    $text = Get-Content -Raw -Path $file.FullName
    $orig = $text

    $text = [regex]::Replace($text, '<TargetFramework>net\d+\.0</TargetFramework>', "<TargetFramework>$tfm</TargetFramework>")
    $text = [regex]::Replace($text, '<TargetFrameworks>.*?</TargetFrameworks>', "<TargetFramework>$tfm</TargetFramework>")

    $text = [regex]::Replace(
        $text,
        '(Include="Microsoft\.(AspNetCore|EntityFrameworkCore)[^"]*"\s+Version=")\d+\.',
        { param($m) $m.Groups[1].Value + $pkgMajor + "." }
    )
    $text = [regex]::Replace(
        $text,
        '(Include="Microsoft\.VisualStudio\.Web\.CodeGeneration\.Design"\s+Version=")\d+\.',
        { param($m) $m.Groups[1].Value + $pkgMajor + "." }
    )

    if ($text -ne $orig) {
        Set-Content -Path $file.FullName -Value $text -NoNewline
        Write-Host "UPDATED  $($file.FullName.Substring($root.Length))"
    } else {
        Write-Host "skip     $($file.FullName.Substring($root.Length))"
    }
}

$globalJson = Join-Path $root "global.json"
@"
{
  "sdk": {
    "version": "$Major.0.100",
    "rollForward": "latestFeature",
    "allowPrerelease": false
  }
}
"@ | Set-Content -Path $globalJson -Encoding utf8

Write-Host ""
Write-Host "Wrote $globalJson"
Write-Host "Next: dotnet restore   then open the .sln"
