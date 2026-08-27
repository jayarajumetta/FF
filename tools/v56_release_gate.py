#!/usr/bin/env python3
import json,re,sys,xml.etree.ElementTree as ET
from pathlib import Path
ROOT=Path(__file__).resolve().parents[1]; errors=[]; warnings=[]
def req(x,msg):
 if not x:errors.append(msg)
features=list(ROOT.glob('tests/*/Features/*.feature')); scenarios=list(ROOT.glob('tests/*/TestData/Scenarios/*.json')); cs=list(ROOT.rglob('*.cs'))
examples=sum(sum(1 for l in p.read_text(errors='ignore').splitlines() if re.match(r'^\s*\|\s*[^-]',l)) - sum(1 for l in p.read_text(errors='ignore').splitlines() if re.match(r'^\s*\|\s*(State|state|Test|Scenario|Data)',l)) for p in [])
# authoritative raw contract produced by v54 raw-only gate
rc=json.loads((ROOT/'Artifacts/V54RawToscaContract.json').read_text());req(rc.get('status')=='PASS','raw Tosca contract failed');req(rc.get('features')==32,'feature count !=32');req(rc.get('examples')==1074,'examples !=1074');req(rc.get('rawConcreteExamplesMatched')==1074,'raw examples not 1074/1074')
# frames
fr=json.loads((ROOT/'Artifacts/ToscaFrameContexts.v56.json').read_text());apps={}
for r in fr:apps.setdefault(r['application'],0);apps[r['application']]+=1
req(apps.get('CommercialLines.DuckCreek',0)>0,'CLDC raw frames missing');req(apps.get('CommercialLines.ExpertQuote',0)>0,'CLEQ raw frames missing');req(apps.get('PersonalLines.DuckCreek',0)==0,'PLDC frame context was invented despite no raw HtmlFrame evidence')
# catalogs + isolation + frame candidates
prefix={'CommercialLines.DuckCreek':'CL-DC','CommercialLines.ExpertQuote':'CL_EQ','PersonalLines.DuckCreek':'PL_DC'}; frame_candidates={}
for app,pre in prefix.items():
 d=json.loads((ROOT/'Artifacts/LocatorFallbackCatalogs'/f'{app}.json').read_text()); bad=0;fc=0
 for c in d['controls']:
  for x in c.get('candidates',[]):
   if not x.get('sourceFile','').startswith(pre):bad+=1
   if x.get('frameValue'):fc+=1
 req(bad==0,f'{app} fallback has {bad} cross-application candidates');frame_candidates[app]=fc
req(frame_candidates['CommercialLines.DuckCreek']>0,'CLDC frame-aware fallback candidates missing');req(frame_candidates['CommercialLines.ExpertQuote']>0,'CLEQ frame-aware fallback candidates missing')
# conditions and keyboard
allsteps='\n'.join(p.read_text(errors='ignore') for p in ROOT.glob('tests/*/StepDefinitions/*.cs'))
req('Condition("\\\\"' not in allsteps,'double-escaped condition remains');req(not re.search(r'await\s+page\.Press\w+Async\("(?:TAB|Tab|tab|\\{TAB\\})"\)',allsteps),'live focus-navigation Tab remains in StepDefinitions')
# core contracts
ui=(ROOT/'src/InsuranceAutomation.Core/UiActions.cs').read_text();lr=(ROOT/'src/InsuranceAutomation.Core/LocatorResolution.cs').read_text();fb=(ROOT/'src/InsuranceAutomation.Core/LocatorFallbackCatalog.cs').read_text();comp=(ROOT/'src/InsuranceAutomation.Core/ComponentAwareControlActions.cs').read_text();ev=(ROOT/'src/InsuranceAutomation.NUnit/NUnitEvidenceAttachment.cs').read_text()
for token in ['FrameExecutionContext','PreferredFrame','KEYBOARD STEERING SUPPRESSED','ComponentAwareControlActions.SelectOrFillAsync']:req(token in ui,f'UiActions missing {token}')
for token in ['IFrameLocator','FrameLocator','FrameStrategy','FrameValue']:req(token in lr+fb,f'frame contract missing {token}')
req('fieldref' in comp,'component metadata does not inspect fieldref');req('TestContext.AddTestAttachment' in ev and 'File.Open(staged' in ev,'persistent NUnit evidence contract missing')
# waits
cfg=json.loads((ROOT/'config/framework.json').read_text());req(cfg['browser']['actionTimeoutMs']<=15000,'action timeout >15s');req(cfg['waits']['pageReadyTimeoutMs']<=15000,'page wait >15s');req(cfg['waits']['elementReadyTimeoutMs']<=15000,'element wait >15s');req(cfg['waits']['verifyTimeoutMs']<=15000,'verify wait >15s')
# JSON/XML parse
for p in ROOT.rglob('*.json'):
 try:json.loads(p.read_text())
 except Exception as e:errors.append(f'json {p.relative_to(ROOT)}: {e}')
for p in list(ROOT.rglob('*.csproj'))+list(ROOT.rglob('*.runsettings')):
 try:ET.parse(p)
 except Exception as e:errors.append(f'xml {p.relative_to(ROOT)}: {e}')
# basic C# delimiter scan after strings/comments removed
strpat=re.compile(r'@?"(?:""|\\.|[^"\\])*"|\'(?:\\.|[^\'\\])\'|//.*?$|/\*.*?\*/',re.S|re.M)
for p in cs:
 t=strpat.sub('',p.read_text(errors='ignore'))
 if t.count('{')!=t.count('}'):errors.append(f'brace mismatch {p.relative_to(ROOT)}')
report={'release':'v56-frame-aware-raw-tosca','status':'PASS' if not errors else 'FAIL','rawSourceTruth':'RAW_TOSCA_ONLY','features':rc.get('features'),'examples':rc.get('examples'),'rawConcreteExamplesMatched':rc.get('rawConcreteExamplesMatched'),'frameScopedRawControls':apps,'frameAwareFallbackCandidates':frame_candidates,'liveTabSteering':0,'applicationFallbackIsolation':not any('cross-application' in e for e in errors),'waits':cfg['waits'],'csharpFiles':len(cs),'errors':errors,'warnings':warnings,'dotnetBuildPerformed':False,'dotnetBuildReason':'dotnet/csc/msbuild unavailable in generation environment; Azure/Visual Studio remains compiler/runtime gate.'}
out=ROOT/'Artifacts/V56ReleaseValidation.json';out.write_text(json.dumps(report,indent=2));print(json.dumps(report,indent=2));sys.exit(0 if not errors else 1)
