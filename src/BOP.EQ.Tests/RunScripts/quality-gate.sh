#!/usr/bin/env bash
set -euo pipefail
python3 - <<'PY2'
import json
r=json.load(open('Reports/business-feature-quality-v24.json'))
assert not r['missingBindings'], r['missingBindings']
print('v24 business Feature quality gate passed.')
PY2
