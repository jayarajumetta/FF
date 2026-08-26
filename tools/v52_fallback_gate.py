#!/usr/bin/env python3
from __future__ import annotations
import json, re, sys, xml.etree.ElementTree as ET
from pathlib import Path
try:
    import yaml
except Exception:
    yaml=None

ROOT=Path(__file__).resolve().parents[1]
errors=[]; warnings=[]

def load(p):
    return json.loads((ROOT/p).read_text(encoding='utf-8'))

def balanced_csharp(path:Path):
    text=path.read_text(encoding='utf-8',errors='ignore'); i=0; state='code'; stack=[]; pairs={')':'(',']':'[','}':'{'}
    while i<len(text):
        c=text[i]; n=text[i+1] if i+1<len(text) else ''
        if state=='code':
            if c=='/' and n=='/': state='line'; i+=2; continue
            if c=='/' and n=='*': state='block'; i+=2; continue
            if c=='@' and n=='"': state='verbatim'; i+=2; continue
            if c=='"': state='string'; i+=1; continue
            if c=="'": state='char'; i+=1; continue
            if c in '([{': stack.append((c,i))
            elif c in pairs:
                if not stack or stack[-1][0]!=pairs[c]: return False,f'unbalanced {c} at {i}'
                stack.pop()
            i+=1; continue
        if state=='line':
            if c=='\n': state='code'
            i+=1; continue
        if state=='block':
            if c=='*' and n=='/': state='code'; i+=2
            else: i+=1
            continue
        if state=='string':
            if c=='\\': i+=2; continue
            if c=='"': state='code'
            i+=1; continue
        if state=='char':
            if c=='\\': i+=2; continue
            if c=="'": state='code'
            i+=1; continue
        if state=='verbatim':
            if c=='"' and n=='"': i+=2; continue
            if c=='"': state='code'
            i+=1; continue
    if state in {'block','string','char','verbatim'}: return False,f'unterminated {state}'
    if stack: return False,f'unclosed {stack[-1][0]} at {stack[-1][1]}'
    return True,''

# source-order contract
source=load('Artifacts/V52SourceOrderContract.json')
for k in ('featureSequenceGate','stepDefinitionOrderGate','clDcCompletenessGate','overallGate'):
    if source.get(k)!='PASS': errors.append(f'source contract {k}={source.get(k)}')
if source.get('featuresCompared')!=32 or source.get('exactFeatureSequences')!=32: errors.append('source order not 32/32')

# fallback coverage
cov=load('Artifacts/LocatorFallbackCatalogs/LocatorFallbackCoverage.json')
apps=cov.get('applications',{})
expected_apps=('CommercialLines.ExpertQuote','CommercialLines.DuckCreek','PersonalLines.DuckCreek')
for app in expected_apps:
    row=apps.get(app)
    if not row: errors.append(f'missing fallback catalog coverage: {app}'); continue
    if row.get('canonicalFallbackCoverage',0)<0.95: errors.append(f'{app} fallback coverage below 95%: {row.get("canonicalFallbackCoverage")}')
    if row.get('canonicalTwoPlusCoverage',0)<0.95: errors.append(f'{app} two-plus fallback coverage below 95%: {row.get("canonicalTwoPlusCoverage")}')
if cov.get('overallCanonicalFallbackCoverage',0)<0.95: errors.append('overall fallback coverage below 95%')
if cov.get('sourceLocatorPropertyRows',0)<30000: errors.append('enriched Tosca locator source catalog unexpectedly small')
strategies=cov.get('candidateStrategyCounts',{})
for s in ('css','role','duckcreekid','text','id','testid','name','label','xpath'):
    if strategies.get(s,0)<=0: errors.append(f'missing derived strategy {s}')

merge=load('Artifacts/V52ToscaLocatorCatalogMerge.json')
if merge.get('finalRows')!=32603 or merge.get('baseRows')!=29791: warnings.append(f'catalog row counts changed: {merge.get("baseRows")}->{merge.get("finalRows")}')

# runtime ordering and retry-only-failed-action
ui=(ROOT/'src/InsuranceAutomation.Core/UiActions.cs').read_text(errors='ignore')
required_ui=['DeterministicLocatorFallbackResolver','_fallback.TryExecuteAsync(intent, action, operation, ex)','_healer.TryHealAsync(locator, intent, action, ex)','Intentionally no post-action DOM extraction/consolidation']
for t in required_ui:
    if t not in ui: errors.append(f'UiActions missing runtime contract: {t}')
first=ui.find('_fallback.TryExecuteAsync(intent, action, operation, ex)'); second=ui.find('_healer.TryHealAsync(locator, intent, action, ex)',first)
if first<0 or second<0 or first>second: errors.append('recovery order is not deterministic fallback before LLM')
resolver=(ROOT/'src/InsuranceAutomation.Core/DeterministicLocatorFallbackResolver.cs').read_text(errors='ignore')
for t in ['foreach (var candidate in candidates)','await operation(locator)','await locator.CountAsync()','await locator.IsVisibleAsync()','await locator.IsEditableAsync()','LOCATOR FALLBACK SUCCESS','RecordLocatorFallback']:
    if t not in resolver: errors.append(f'deterministic resolver missing: {t}')
if '.First' in resolver or '.Nth(' in resolver: errors.append('resolver itself makes an arbitrary First/Nth choice')

# report trace
report=(ROOT/'src/InsuranceAutomation.Core/ScenarioReport.cs').read_text(errors='ignore')
for t in ['Locator fallback trace','Locator recovery','Tosca source','RecordLocatorFallback']:
    if t not in report: errors.append(f'HTML report missing fallback trace contract: {t}')

# hook application scoping and no after-step fallback
hook_apps={
 'CommercialLines.ExpertQuote.Tests':'CommercialLines.ExpertQuote',
 'CommercialLines.DuckCreek.Tests':'CommercialLines.DuckCreek',
 'PersonalLines.DuckCreek.Tests':'PersonalLines.DuckCreek'}
for proj,app in hook_apps.items():
    p=ROOT/'tests'/proj/'Hooks/TestHooks.cs'; t=p.read_text(errors='ignore')
    if f'new UiActions(browser, config, logger, report, "{app}")' not in t: errors.append(f'{proj} does not scope fallback catalog to application')
    after=t[t.find('[AfterStep]'):t.find('[AfterScenario') if '[AfterScenario' in t else len(t)]
    if 'Fallback' in after or 'TryExecute' in after: errors.append(f'{proj} incorrectly performs locator recovery in AfterStep')

# config policy
cfg=load('config/framework.json')
lf=cfg.get('locatorFallback',{})
if not lf.get('enabled'): errors.append('locatorFallback disabled')
if lf.get('maxCandidatesPerFailure',0)<10: errors.append('fallback candidate cap too low')
if not lf.get('logEveryAttempt'): errors.append('fallback attempts not logged')
if cfg.get('selfHeal',{}).get('captureDomAfterActions') is not False: errors.append('post-action DOM capture must remain false')
if cfg.get('selfHeal',{}).get('locatorCatalogFile')!='Artifacts/ToscaLocatorPropertyCatalog.v52.json': errors.append('LLM evidence does not use enriched v52 catalog')

# catalog files parse and metadata/candidate cap
catalog_stats={}
for app in expected_apps:
    p=ROOT/'Artifacts/LocatorFallbackCatalogs'/f'{app}.json'; data=json.loads(p.read_text())
    controls=data.get('controls',[]); maxc=max((len(x.get('candidates',[])) for x in controls),default=0)
    if maxc>40: errors.append(f'{app} catalog candidate count exceeds 40: {maxc}')
    catalog_stats[app]={'controls':len(controls),'maxCandidatesOnControl':maxc,'coverage':data.get('canonicalFallbackCoverage')}

# 32 features / 1074 examples
features=list(ROOT.glob('tests/*/Features/*.feature'))
def count_examples(txt):
    total=0
    for part in txt.split('Examples:')[1:]:
        rows=[]
        for line in part.splitlines()[1:]:
            if line.strip().startswith('|'): rows.append(line)
            elif rows: break
        if rows: total+=max(0,len(rows)-1)
    return total
examples=sum(count_examples(p.read_text(errors='ignore')) for p in features)
if len(features)!=32: errors.append(f'feature count {len(features)} !=32')
if examples!=1074: errors.append(f'example count {examples} !=1074')

# C#/JSON/XML/YAML structural gates
cs=list(ROOT.rglob('*.cs')); lexical=[]
for p in cs:
    ok,msg=balanced_csharp(p)
    if not ok: lexical.append(f'{p.relative_to(ROOT)}: {msg}')
if lexical: errors.append(f'C# lexical issues: {lexical[:20]}')
json_count=0
for p in ROOT.rglob('*.json'):
    try: json.loads(p.read_text(encoding='utf-8')); json_count+=1
    except Exception as e: errors.append(f'bad JSON {p.relative_to(ROOT)}: {e}')
for p in [*ROOT.rglob('*.csproj'),ROOT/'Directory.Build.props']:
    if p.exists():
        try: ET.parse(p)
        except Exception as e: errors.append(f'bad XML {p.relative_to(ROOT)}: {e}')
if yaml:
    for p in ROOT.glob('.azuredevops/*.yml'):
        try: yaml.safe_load(p.read_text())
        except Exception as e: errors.append(f'bad YAML {p.relative_to(ROOT)}: {e}')

# ADO split pipeline remains
build=(ROOT/'.azuredevops/build-test-artifact.yml').read_text(errors='ignore')
execute=(ROOT/'.azuredevops/execute-test-artifact.yml').read_text(errors='ignore')
for t in ['UseDotNet@2','dotnet restore','dotnet build','PublishPipelineArtifact@1','v52_fallback_gate.py']:
    if t not in build: errors.append(f'build pipeline missing {t}')
for stage in ('AllCases','SingleTestPlanCase','TestSuite'):
    if re.search(rf'^-?\s*stage:\s*{stage}\b',execute,re.M) is None: errors.append(f'execution pipeline missing stage {stage}')
if re.search(r'dotnet\s+build|command:\s*build',execute,re.I): errors.append('execution pipeline rebuilds code')
for t in ['VSTest@3','publishRunAttachments: true']:
    if t not in execute: errors.append(f'execution pipeline missing {t}')

result={
 'release':'v52-deterministic-tosca-locator-fallback',
 'status':'PASS' if not errors else 'FAIL',
 'scope':{'features':len(features),'exampleRows':examples,'csharpFiles':len(cs),'jsonFiles':json_count},
 'sourceOrder':{'featuresCompared':source.get('featuresCompared'),'exactFeatureSequences':source.get('exactFeatureSequences'),'overallGate':source.get('overallGate')},
 'locatorFallback':{
   'sourcePropertyRows':cov.get('sourceLocatorPropertyRows'),
   'overallCanonicalFallbackCoverage':cov.get('overallCanonicalFallbackCoverage'),
   'overallCanonicalTwoPlusCoverage':cov.get('overallCanonicalTwoPlusCoverage'),
   'applications':apps,
   'candidateStrategyCounts':strategies,
   'catalogStats':catalog_stats,
   'retryScope':'same failed Page action only',
   'recoveryLocation':'UiActions before AfterStep final-failure evidence',
   'llmPosition':'after deterministic Tosca fallbacks are exhausted'
 },
 'evidence':{'htmlFallbackTrace':True,'executionLogTrace':True,'testResultAttachmentsPreserved':True,'postActionDomCapture':False},
 'azureDevOps':{'splitBuildExecutePipelines':True,'executionStages':['AllCases','SingleTestPlanCase','TestSuite'],'executionRebuildsCode':False},
 'dotnetBuildInGenerationEnvironment':{'performed':False,'reason':'dotnet/csc/msbuild executables are unavailable; build pipeline/target VDI is the compiler/runtime gate.'},
 'warnings':warnings,'errors':errors
}
(ROOT/'Artifacts/V52FinalValidation.json').write_text(json.dumps(result,indent=2),encoding='utf-8')
print(json.dumps(result,indent=2))
sys.exit(1 if errors else 0)
