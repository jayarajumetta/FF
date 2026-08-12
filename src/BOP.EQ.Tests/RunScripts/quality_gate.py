from pathlib import Path
import sys,re,json
root=Path(sys.argv[1]); errors=[]
for p in (root/'Features').glob('*.feature'):
 t=p.read_text();
 if 'ObjectClass' in t or 'Surrogate' in t: errors.append(f'source leakage: {p.name}')
 lines=t.splitlines()
 for i,l in enumerate(lines):
  if l.strip()=='Examples:' and i+1<len(lines):
   h=[x.strip() for x in lines[i+1].strip().strip('|').split('|')]
   if len(h)!=len(set(h)): errors.append(f'duplicate example header: {p.name}: {h}')
   semantic=[]
   for x in h:
    n=re.sub(r'[^a-z0-9]','',x.lower())
    if n in {'state','stateabbv','stateabbreviation','statecode'}: n='stateCode'
    if n in {'address','address1'}: n='address'
    semantic.append(n)
   if len(semantic)!=len(set(semantic)): errors.append(f'duplicate semantic dimension: {p.name}: {h}')
for report in ['semantic-examples-quality.json','feature-to-page-flow.json','page-quality.json']:
 p=root/'Reports'/report
 if not p.exists(): errors.append(f'missing report: {report}')
 else: json.loads(p.read_text())
flow=json.loads((root/'Reports/feature-to-page-flow.json').read_text())
if flow['missingBindings']: errors.append(f"missing feature bindings: {len(flow['missingBindings'])}")
pq=json.loads((root/'Reports/page-quality.json').read_text())
if pq['unresolvedLocators']: errors.append(f"unresolved locators: {len(pq['unresolvedLocators'])}")
if errors:
 print('\n'.join(errors)); raise SystemExit(1)
print('Quality gate passed: semantic Examples, bindings, locators, and reports are valid.')


# v27 recursive coverage
from pathlib import Path as _P
import json as _J
_r=_P(__file__).resolve().parents[1]
_c=_J.loads((_r/'Reports'/'EFFECTIVE-MODULE-FIELD-COVERAGE.json').read_text())
if _c.get('misses'): raise SystemExit(f"Recursive effective-module coverage misses: {len(_c['misses'])}")
for _n in ['RECURSIVE-OBJECTCLASS-COVERAGE.json','RECURSIVE-BLOCK-COVERAGE.json','FEATURE-NESTED-CONTEXT.json']:
    if not (_r/'Reports'/_n).exists(): raise SystemExit(f"Missing recursive coverage report: {_n}")
print('v27 recursive coverage: PASS')
