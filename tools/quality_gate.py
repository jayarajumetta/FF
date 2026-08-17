import pathlib,re,json,sys
r=pathlib.Path(__file__).resolve().parents[1]; errs=[]
features=list(r.glob('tests/*/Features/*.feature'));
if len(features)!=32: errs.append(f'Expected 32 features, found {len(features)}')
for f in features:
 t=f.read_text();
 if 'TBox ' in t or 'force-close browser' in t or 'EdgePreferences' in t: errs.append(f'Technical leakage in {f.name}')
 if 'Scenario Outline:' not in t or 'Examples:' not in t: errs.append(f'Missing outline/examples: {f.name}')
for p in r.rglob('*.json'):
 try: json.load(open(p))
 except Exception as e: errs.append(f'Bad JSON {p}: {e}')
for p in r.rglob('*Steps.cs'):
 t=p.read_text();
 if '^(.*)$' in t: errs.append(f'Catch-all binding in {p}')
print(json.dumps({'errors':errs,'featureCount':len(features)},indent=2));sys.exit(1 if errs else 0)
