$credOutput = "protocol=https`nhost=dev.azure.com`n" | git credential fill 2>$null
$pwLine = ($credOutput | Where-Object { $_ -match '^password=' }) -replace '^password=',''
$encoded = [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes(":$pwLine"))
$headers = @{
    Authorization  = "Basic $encoded"
    'Content-Type' = 'application/json'
}
$body = ConvertTo-Json @{
    title         = "Merge Development into main - daily schedule triggers + all current changes"
    description   = "Merges all changes from the Development branch into main. Includes the addition of two daily schedule triggers on the sfp-smoke-vm.yml pipeline (10:00 PM CST and 5:00 AM CST)."
    sourceRefName = "refs/heads/Development"
    targetRefName = "refs/heads/main"
}
$uri = "https://dev.azure.com/ANCollection/PnC%20Test%20Automation/_apis/git/repositories/PnC-TestAutomation/pullrequests?api-version=7.1"
try {
    $r = Invoke-RestMethod -Uri $uri -Method Post -Headers $headers -Body $body -ErrorAction Stop
    Write-Host "SUCCESS — PR $($r.pullRequestId)"
    Write-Host "URL: https://dev.azure.com/ANCollection/PnC%20Test%20Automation/_git/PnC-TestAutomation/pullrequest/$($r.pullRequestId)"
    $r | ConvertTo-Json -Depth 3
} catch {
    Write-Host "ERROR: $($_.Exception.Message)"
    try {
        $stream = $_.Exception.Response.GetResponseStream()
        $reader = New-Object System.IO.StreamReader($stream)
        Write-Host "BODY: $($reader.ReadToEnd())"
    } catch {}
}
