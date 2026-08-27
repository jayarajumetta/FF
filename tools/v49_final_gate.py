#!/usr/bin/env python3
from pathlib import Path
import json,re,sys,xml.etree.ElementTree as ET
root=Path(__file__).resolve().parents[1]
errors=[]
# Source/order contract
p=root/'Artifacts/V49SourceOrderContract.json'
if not p.exists(): errors.append('V49SourceOrderContract.json missing')
else:
 d=json.loads(p.read_text())
 if d.get('overallGate')!='PASS': errors.append('V49 source/order contract is not PASS')
 if d.get('featuresCompared')!=32 or d.get('exactFeatureSequences')!=32: errors.append('32/32 feature exact-sequence gate not satisfied')
# feature/example counts
features=list(root.glob('tests/*/Features/*.feature')); examples=0
for f in features:
 text=f.read_text(errors='ignore')
 for block in text.split('Examples:')[1:]:
  rows=[]
  for line in block.splitlines()[1:]:
   if line.strip().startswith('|'): rows.append(line)
   elif rows: break
  if rows: examples += len(rows)-1
if len(features)!=32: errors.append(f'Expected 32 features; got {len(features)}')
if examples!=1074: errors.append(f'Expected 1074 example rows; got {examples}')
# JSON/XML validity
json_count=0
for q in root.rglob('*.json'):
 try: json.loads(q.read_text(encoding='utf-8')); json_count+=1
 except Exception as e: errors.append(f'Bad JSON {q.relative_to(root)}: {e}')
for q in [*root.rglob('*.csproj'),root/'Directory.Build.props']:
 try: ET.parse(q)
 except Exception as e: errors.append(f'Bad XML {q.relative_to(root)}: {e}')
# Correct binding escaping
bad=[]
for q in root.glob('tests/**/StepDefinitions/*.cs'):
 for n,line in enumerate(q.read_text(errors='ignore').splitlines(),1):
  if re.search(r'\[(Given|When|Then)\(@"',line) and re.search(r'\\\\[\-\[\]\(\)&]',line): bad.append(f'{q.relative_to(root)}:{n}')
if bad: errors.append(f'Over-escaped ReqnRoll binding punctuation remains: {bad[:10]}')
# Locator collision and maturity checks
dup=[]; testid_calls=0; locator_files=0
for q in root.glob('tests/**/*Locators.cs'):
 locator_files+=1; vals=re.findall(r'GetByTestId\("([^"]+)"',q.read_text(errors='ignore')); testid_calls+=len(vals)
 seen=set(); ds=set()
 for v in vals:
  if v in seen: ds.add(v)
  seen.add(v)
 if ds: dup.append({'file':str(q.relative_to(root)),'values':sorted(ds)})
if dup: errors.append(f'Same-page duplicate GetByTestId locators: {dup[:5]}')
# Core capability contracts
core=(root/'src/InsuranceAutomation.Core')
ui=(core/'UiActions.cs').read_text(); dom=(core/'DomEvidenceCollector.cs').read_text(); heal=(core/'LlmLocatorHealer.cs').read_text(); lr=(core/'LocatorResolution.cs').read_text()
required_ui=['NativeSelect','MaterialSelect','Autocomplete','RadioGroup','ChipGroup','Checkbox','DatePicker','TableGrid','Dialog','Tabs','ExpansionPanel','Strict component collision','retry only the failed action']
for token in required_ui:
 if token not in ui: errors.append(f'UiActions missing capability token: {token}')
for token in ['master-page-dom.html','controls.json','locator-history.json','SeenCount','StableKey','observations']:
 if token not in dom: errors.append(f'DOM memory missing: {token}')
for fn in ['ILocatorHealingProvider.cs','OpenAiCompatibleLocatorHealingProvider.cs','GitHubCopilotLocatorHealingProvider.cs','LocatorHealingProviderFactory.cs']:
 if not (core/fn).exists(): errors.append(f'Healing provider abstraction missing {fn}')
if 'LocatorHealingProviderFactory.Create' not in heal: errors.append('Healer does not route through provider factory')
for token in ['"placeholder"=>','AnchorStrategy','LocatorPick.Nth']:
 if token not in lr: errors.append(f'LocatorResolution missing {token}')
# inherited source trace gate
v46=json.loads((root/'Artifacts/V46FinalValidation.json').read_text())
if v46.get('status')!='PASS' or v46.get('contracts',{}).get('referenceErrors')!=0: errors.append('Inherited v46 source trace/reference gate is not PASS')
# project reference gate from v48 plus current quality gate artifact assumptions
result={
 'release':'v49-source-ordered-locator-mature',
 'status':'PASS' if not errors else 'FAIL',
 'scope':{'features':len(features),'exampleRows':examples,'locatorFiles':locator_files,'getByTestIdCalls':testid_calls},
 'sourceOrder':{'exactFeatures':32 if not errors or (p.exists() and json.loads(p.read_text()).get('exactFeatureSequences')==32) else None,
                'sourceReferenceGate':json.loads(p.read_text()).get('overallGate') if p.exists() else 'MISSING'},
 'componentSemantics':['native-select','mat-select/mat-option','autocomplete','radio','chip-group','checkbox','date-picker','table/grid','dialog','tabs','expansion-panel'],
 'healingProviders':['openai-compatible','github-copilot'],
 'persistentDomMemory':True,
 'samePageDuplicateTestIds':len(dup),
 'jsonFilesValidated':json_count,
 'dotnetBuild':{'performed':False,'reason':'dotnet executable is not installed in this generation environment; scripts/setup and CI remain the compiler gate.'},
 'errors':errors
}
(root/'Artifacts/V49FinalValidation.json').write_text(json.dumps(result,indent=2))
print(json.dumps(result,indent=2))
sys.exit(1 if errors else 0)
