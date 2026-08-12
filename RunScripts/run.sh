#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")/.."
DOMAIN="${1:-all}"; FILTER="${2:-}"
case "$DOMAIN" in
bop-eq) TARGET="src/BOP.EQ.Tests/ClientAutomation.BOPEQ.Tests.csproj";;
pl-dc) TARGET="src/PL.DC.Tests/ClientAutomation.PLDC.Tests.csproj";;
all) TARGET="ClientAutomation.sln";;
*) echo "Usage: $0 [all|bop-eq|pl-dc] [filter]" >&2; exit 2;;
esac
ARGS=(test "$TARGET" --settings client.runsettings)
[[ -z "$FILTER" ]] || ARGS+=(--filter "$FILTER")
dotnet "${ARGS[@]}"
