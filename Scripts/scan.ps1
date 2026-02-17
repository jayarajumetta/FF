# Locator Scanner - attaches to Chrome on port 9222
# Usage: .\Scripts\scan.ps1
# Prerequisite: Chrome must be running with --remote-debugging-port=9222

$cdp = (Invoke-RestMethod -Uri "http://localhost:9222/json/version").webSocketDebuggerUrl

@"
<?xml version="1.0" encoding="utf-8"?>
<RunSettings>
  <TestRunParameters>
    <Parameter name="CDP" value="$cdp" />
  </TestRunParameters>
</RunSettings>
"@ | Out-File -Encoding utf8 "$PSScriptRoot\..\scan.runsettings"

dotnet test "$PSScriptRoot\..\TestAutomation.csproj" --filter "Category=Tools" --settings "$PSScriptRoot\..\scan.runsettings"
