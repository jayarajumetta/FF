#!/usr/bin/env bash
set -euo pipefail
dotnet test ./tests/ToscaModernized.Tests/ToscaModernized.Tests.csproj -c Release --logger 'trx;LogFileName=tosca-modernized.trx' -- NUnit.NumberOfTestWorkers=1
