[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string[]]$TargetPaths
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$removedCount = 0
$missingCount = 0

foreach ($targetPath in $TargetPaths) {
    if ([string]::IsNullOrWhiteSpace($targetPath)) {
        continue
    }

    $resolvedPath = [System.IO.Path]::GetFullPath($targetPath)

    if (-not (Test-Path -LiteralPath $resolvedPath)) {
        Write-Host "[cleanup] Skipped missing path: $resolvedPath"
        $missingCount++
        continue
    }

    try {
        Remove-Item -LiteralPath $resolvedPath -Recurse -Force -ErrorAction Stop
        Write-Host "[cleanup] Removed: $resolvedPath"
        $removedCount++
    }
    catch {
        Write-Warning "[cleanup] Failed to remove ${resolvedPath}: $($_.Exception.Message)"
        throw
    }
}

Write-Host "[cleanup] Completed. Removed=$removedCount Missing=$missingCount"
