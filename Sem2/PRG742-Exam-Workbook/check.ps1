# Run your auto-checks and see a score per question (Windows PowerShell / PowerShell 7).
# Usage:   .\check.ps1          or   .\check.ps1 Q2_1   (to see only one question)
param([string]$Filter = "")
Set-Location $PSScriptRoot
$extra = @()
if ($Filter) { $extra = @("--filter", "FullyQualifiedName~$Filter") }

$out = dotnet test HospitalApp.Tests --nologo --logger "console;verbosity=normal" @extra 2>&1 | ForEach-Object { "$_" }

if (-not ($out | Where-Object { $_ -match '^\s+(Passed|Failed) ' })) {
    $out | Where-Object { $_ -match 'error' } | Sort-Object -Unique | Select-Object -First 30
    Write-Host "`nThe project did not build. Fix the red errors above first." -ForegroundColor Red
    exit 1
}

$marks = [ordered]@{ Q1_1=5; Q1_2=5; Q1_3=5; Q1_4=5; Q2_1=15; Q2_2=15; Q3_1=20; Q3_2=15; Q3_3=15 }
$title = @{
  Q1_1="Q1.1 REST and HTTP methods"; Q1_2="Q1.2 EF Core migrations"; Q1_3="Q1.3 ViewBag vs TempData"; Q1_4="Q1.4 Data annotations";
  Q2_1="Q2.1 Patient model"; Q2_2="Q2.2 DbContext + Fluent API"; Q3_1="Q3.1 Controller + TempData";
  Q3_2="Q3.2 Create view + dropdown"; Q3_3="Q3.3 Index view + loop"; B1="B1 ERD (bonus)"; B2="B2 Seeding (bonus)";
  B3="B3 Include (bonus)"; B4="B4 Async (bonus)"; B5="B5 Edit/Delete (bonus)"; B6="B6 @if in a view (bonus)"; B7="B7 Migrations (bonus)"
}
$order = @("Q1_1","Q1_2","Q1_3","Q1_4","Q2_1","Q2_2","Q3_1","Q3_2","Q3_3","B1","B2","B3","B4","B5","B6","B7")
$tot = @{}; $pass = @{}; $fails = @{}; $seen = @{}
$ptag = $null; $pname = ""; $pmsg = ""; $expect = 0
function Flush {
    if ($script:ptag) {
        $m = if ($script:pmsg) { $script:pmsg } else { "(see the test name)" }
        $key = "$($script:ptag)|$m"
        if (-not $script:seen.ContainsKey($key)) {
            $script:seen[$key] = $true
            $script:fails[$script:ptag] += "      x $($script:pname)"
            $script:fails[$script:ptag] += "        -> $m"
        }
    }
    $script:ptag = $null; $script:pname = ""; $script:pmsg = ""; $script:expect = 0
}
foreach ($line in $out) {
    if ($line -match '^\s+(Passed|Failed) ') {
        Flush
        $status = $Matches[1]
        if ($line -match '(Q\d_\d|B\d)_') {
            $tag = $Matches[1]
            if (-not $tot.ContainsKey($tag)) { $tot[$tag] = 0; $pass[$tag] = 0; $fails[$tag] = @() }
            $tot[$tag]++
            if ($status -eq 'Passed') { $pass[$tag]++ }
            else {
                $name = ($line -replace '^\s+Failed\s+', '') -replace ' \[[0-9<].*$', '' -replace '^.*Tests\.', ''
                $ptag = $tag; $pname = $name; $expect = 1
            }
        }
    }
    elseif ($line -match 'Error Message:') { if ($expect -eq 1) { $expect = 2 } }
    elseif ($line -match 'Stack Trace:') { if ($expect -eq 2) { $expect = 0 } }
    elseif ($expect -eq 2 -and $line -match '\S') { $pmsg = ($line -replace '^\s*(>> )?', ''); $expect = 0 }
}
Flush

$gotMarks = 0; $totalMarks = 0
Write-Host ""
Write-Host "  PRG742 workbook: your score so far"
Write-Host "  ----------------------------------------------------------"
foreach ($t in $order) {
    if (-not $tot.ContainsKey($t)) { continue }
    $p = $pass[$t]; $n = $tot[$t]
    $filled = [math]::Floor($p * 10 / $n)
    $bar = ('#' * $filled) + ('.' * (10 - $filled))
    if ($marks.Contains($t)) {
        $got = [int][math]::Round($p / $n * $marks[$t], [MidpointRounding]::AwayFromZero)
        $gotMarks += $got; $totalMarks += $marks[$t]; $ms = ("{0,2}/{1,2} marks" -f $got, $marks[$t])
    } else { $ms = "   bonus   " }
    $color = if ($p -eq $n) { "Green" } elseif ($p -eq 0) { "Red" } else { "Yellow" }
    Write-Host ("  {0,-30} [{1}] {2,2}/{3,-2} checks  {4}" -f $title[$t], $bar, $p, $n, $ms) -ForegroundColor $color
}
Write-Host "  ----------------------------------------------------------"
Write-Host "  Paper total (rough, from auto-checks): $gotMarks / $totalMarks`n"
$any = $false
foreach ($t in $order) {
    if ($fails.ContainsKey($t) -and $fails[$t].Count -gt 0) {
        if (-not $any) { Write-Host "  Still to fix:"; $any = $true }
        Write-Host "    $($title[$t])"
        $fails[$t] | ForEach-Object { Write-Host $_ }
    }
}
if (-not $any) { Write-Host "  Everything is green. Now go and read the rubric for the theory with fresh eyes." }
Write-Host ""
