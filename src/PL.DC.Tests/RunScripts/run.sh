#!/usr/bin/env bash
set -euo pipefail
FILTER=${1:-}
if [[ -n "$FILTER" ]]; then dotnet test -c Release --no-build --logger 'trx;LogFileName=results.trx' --filter "$FILTER"; else dotnet test -c Release --no-build --logger 'trx;LogFileName=results.trx'; fi
