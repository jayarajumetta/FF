#!/usr/bin/env bash
set -euo pipefail
ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
SUITE="${1:-all}"
case "$SUITE" in
  smoke) FILTER='TestCategory=smoke' ;;
  regression) FILTER='TestCategory=regression' ;;
  cl-dc) FILTER='TestCategory=CL_DC' ;;
  cl-eq) FILTER='TestCategory=CL_EQ' ;;
  pl-dc) FILTER='TestCategory=PL_DC' ;;
  rate-filings) FILTER='TestCategory=rate_filings' ;;
  all) FILTER='' ;;
  *) echo "Unknown suite: $SUITE" >&2; exit 2 ;;
esac
args=(dotnet test "$ROOT/ToscaArtifactAutomation.sln" -c Release --logger 'trx;LogFileName=results.trx')
if [[ -n "$FILTER" ]]; then args+=(--filter "$FILTER"); fi
"${args[@]}"
