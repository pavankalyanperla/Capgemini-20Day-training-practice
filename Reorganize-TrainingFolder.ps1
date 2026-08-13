<#
    Reorganize-TrainingFolder.ps1

    Reorganizes "Capgemini 20 Day training" into a Week-N/Day-NN structure.

    REVIEW BEFORE RUNNING. Nothing here deletes anything - folders are only
    moved (Move-Item) or created (New-Item). Source folders that are emptied
    by a content-move (Day_01 .. Day_07) are left behind as empty folders;
    they are NOT auto-deleted. An optional cleanup step is commented out at
    the bottom if you want to remove them afterwards.

    Usage:
        .\Reorganize-TrainingFolder.ps1            # performs the moves
        .\Reorganize-TrainingFolder.ps1 -DryRun     # preview only, moves nothing

    NOT moved by this script (left at root, on purpose):
        - "Topbrain Tasks"      (contains dated subfolders spanning many days)
        - "HackerRank Questions" (contains dated subfolders spanning many days)
#>

param(
    [switch]$DryRun
)

$Root = 'C:\Users\Pavan\OneDrive\Desktop\Capgemini 20 Day training'

if (-not (Test-Path $Root)) {
    throw "Root folder not found: $Root"
}

Set-Location $Root

# ---------------------------------------------------------------------------
# Helper functions
# ---------------------------------------------------------------------------

function New-DirIfMissing {
    param([string]$Path)
    if (-not (Test-Path $Path)) {
        if ($DryRun) {
            Write-Host "[DryRun] Would create directory: $Path" -ForegroundColor Cyan
        } else {
            New-Item -ItemType Directory -Path $Path -Force | Out-Null
            Write-Host "Created: $Path" -ForegroundColor Green
        }
    }
}

# Moves the CONTENTS of $SourceDir into $DestDir (flattens - source folder itself is left behind, empty)
function Move-FolderContents {
    param([string]$SourceDir, [string]$DestDir)

    if (-not (Test-Path $SourceDir)) {
        Write-Host "SKIP (source not found): $SourceDir" -ForegroundColor Yellow
        return
    }

    $items = Get-ChildItem -Path $SourceDir -Force
    if ($items.Count -eq 0) {
        Write-Host "SKIP (empty): $SourceDir" -ForegroundColor DarkGray
        return
    }

    foreach ($item in $items) {
        $destPath = Join-Path $DestDir $item.Name
        if (Test-Path $destPath) {
            Write-Warning "Destination already exists, skipping: $destPath"
            continue
        }
        if ($DryRun) {
            Write-Host "[DryRun] Would move: $($item.FullName) -> $DestDir" -ForegroundColor Cyan
        } else {
            Move-Item -Path $item.FullName -Destination $DestDir -Force
            Write-Host "Moved: $($item.FullName) -> $DestDir" -ForegroundColor Green
        }
    }
}

# Moves an entire folder AS A SUBFOLDER into $DestParent (e.g. Day1Task1 -> Week-1/Day-01/Day1Task1)
function Move-FolderAsSubfolder {
    param([string]$SourcePath, [string]$DestParent)

    if (-not (Test-Path $SourcePath)) {
        Write-Host "SKIP (source not found): $SourcePath" -ForegroundColor Yellow
        return
    }

    $name = Split-Path $SourcePath -Leaf
    $destPath = Join-Path $DestParent $name
    if (Test-Path $destPath) {
        Write-Warning "Destination already exists, skipping: $destPath"
        return
    }

    if ($DryRun) {
        Write-Host "[DryRun] Would move: $SourcePath -> $DestParent" -ForegroundColor Cyan
    } else {
        Move-Item -Path $SourcePath -Destination $DestParent -Force
        Write-Host "Moved: $SourcePath -> $DestParent" -ForegroundColor Green
    }
}

# ---------------------------------------------------------------------------
# STEP 1 - Create Week/Day folder structure
# ---------------------------------------------------------------------------

Write-Host "`n=== STEP 1: Creating Week/Day folder structure ===" -ForegroundColor Magenta

$WeekMap = @{
    'Week-1' = 1..6
    'Week-2' = 7..12
    'Week-3' = 13..18
    'Week-4' = 19..20
}

foreach ($week in $WeekMap.Keys | Sort-Object) {
    $weekPath = Join-Path $Root $week
    New-DirIfMissing -Path $weekPath
    foreach ($dayNum in $WeekMap[$week]) {
        $dayFolder = 'Day-{0:D2}' -f $dayNum
        New-DirIfMissing -Path (Join-Path $weekPath $dayFolder)
    }
}

# ---------------------------------------------------------------------------
# STEP 2 - Move Day_NN contents into matching Week-X/Day-NN
# ---------------------------------------------------------------------------

Write-Host "`n=== STEP 2: Moving Day_NN contents into Week/Day folders ===" -ForegroundColor Magenta

$DayNNMap = @{
    'Day_01' = 'Week-1\Day-01'
    'Day_02' = 'Week-1\Day-02'
    'Day_03' = 'Week-1\Day-03'
    'Day_04' = 'Week-1\Day-04'
    'Day_05' = 'Week-1\Day-05'
    'Day_06' = 'Week-1\Day-06'
    'Day_07' = 'Week-2\Day-07'
    'Day_08' = 'Week-2\Day-08'
    'Day_09' = 'Week-2\Day-09'
    'Day_10' = 'Week-2\Day-10'
    'Day_11' = 'Week-2\Day-11'
    'Day_12' = 'Week-2\Day-12'
    'Day_13' = 'Week-3\Day-13'
    'Day_14' = 'Week-3\Day-14'
    'Day_15' = 'Week-3\Day-15'
    'Day_16' = 'Week-3\Day-16'
    'Day_17' = 'Week-3\Day-17'
    'Day_18' = 'Week-3\Day-18'
    'Day_19' = 'Week-4\Day-19'
    'Day_20' = 'Week-4\Day-20'
}

foreach ($src in $DayNNMap.Keys | Sort-Object) {
    $sourcePath = Join-Path $Root $src
    $destPath = Join-Path $Root $DayNNMap[$src]
    Move-FolderContents -SourceDir $sourcePath -DestDir $destPath
}

# ---------------------------------------------------------------------------
# STEP 3 - Move named task folders into the correct day (moved as subfolders)
# ---------------------------------------------------------------------------

Write-Host "`n=== STEP 3: Moving named task folders into matching Day folders ===" -ForegroundColor Magenta

# Day 1 items (created 28-Jul, same day as Day_01)
$Day01Items = @('Day1Task1', 'Day1Task2', 'Day1Task3', 'ECommerceOrderMgmtSys')
foreach ($folder in $Day01Items) {
    Move-FolderAsSubfolder -SourcePath (Join-Path $Root $folder) -DestParent (Join-Path $Root 'Week-1\Day-01')
}

# Day 2 items (created 29-Jul, same day as Day_02)
$Day02Items = @('Day2BrowserHistMgmtStack', 'Day2CustomerSupportMgmtSys', 'Day2HospitalQueueManagement')
foreach ($folder in $Day02Items) {
    Move-FolderAsSubfolder -SourcePath (Join-Path $Root $folder) -DestParent (Join-Path $Root 'Week-1\Day-02')
}

# NOTE: "Topbrain Tasks" and "HackerRank Questions" are intentionally left
# at the root. Both contain subfolders dated across many different training
# days, so moving either into a single Day folder would misrepresent the
# timeline. Revisit manually if you want them split by subfolder date.

Write-Host "`n=== Done ===" -ForegroundColor Magenta
if ($DryRun) {
    Write-Host "This was a DRY RUN - nothing was actually moved or created. Re-run without -DryRun to apply." -ForegroundColor Cyan
}

# ---------------------------------------------------------------------------
# OPTIONAL CLEANUP (commented out) - remove now-empty Day_NN source folders
# ---------------------------------------------------------------------------
# foreach ($src in $DayNNMap.Keys) {
#     $sourcePath = Join-Path $Root $src
#     if ((Test-Path $sourcePath) -and (Get-ChildItem -Path $sourcePath -Force | Measure-Object).Count -eq 0) {
#         Remove-Item -Path $sourcePath -Force
#         Write-Host "Removed empty folder: $sourcePath" -ForegroundColor DarkGray
#     }
# }
