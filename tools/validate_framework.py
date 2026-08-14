#!/usr/bin/env python3
from pathlib import Path
import json, re, sys

root = Path(__file__).resolve().parents[1]
features = sorted(root.glob('tests/ToscaModernized.Tests/Features/**/*.feature'))
plans = sorted(root.glob('tests/ToscaModernized.Tests/Plans/**/*.plan.json'))
data = sorted(root.glob('tests/ToscaModernized.Tests/TestData/**/*.data.json'))
assert len(features) == len(plans) == len(data) == 248, (len(features), len(plans), len(data))
index = json.loads((root / 'tests/ToscaModernized.Tests/Plans/PlanIndex.json').read_text())
assert len(index['entries']) == 248
plan_by_feature = {}
for p in plans:
    obj = json.loads(p.read_text())
    key = (obj['featureTitle'], obj['scenarioTitle'])
    assert key not in plan_by_feature
    plan_by_feature[key] = obj
for f in features:
    text = f.read_text()
    feature = re.search(r'^\s*Feature:\s*(.+)$', text, re.M).group(1).strip()
    scenario = re.search(r'^\s*Scenario(?: Outline)?:\s*(.+)$', text, re.M).group(1).strip()
    plan = plan_by_feature[(feature, scenario)]
    scenario_block = text[re.search(r'^\s*Scenario(?: Outline)?:', text, re.M).start():]
    steps = [m.group(2).strip() for m in re.finditer(r'^\s*(Given|When|Then|And|But|\*)\s+(.+?)\s*$', scenario_block, re.M)]
    expected = [x['gherkinText'] for x in plan['scenarioInstructions']]
    assert steps == expected, f'{f}: feature/plan order mismatch'
for path in root.rglob('*.json'):
    json.loads(path.read_text())
print('Static framework validation passed:', len(features), 'features')
