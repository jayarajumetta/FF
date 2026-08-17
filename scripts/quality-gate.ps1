python tools/quality_gate.py
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
dotnet build ToscaCanonicalSimple.sln --configuration Release
