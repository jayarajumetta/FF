dotnet restore
dotnet build -c Release
pwsh bin/Release/net8.0/playwright.ps1 install --with-deps chromium
