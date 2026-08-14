$ErrorActionPreference = "Stop"
dotnet restore ./ToscaModernized.sln
dotnet build ./ToscaModernized.sln -c Release --no-restore
python ./tools/validate_framework.py
