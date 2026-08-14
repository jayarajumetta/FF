#!/usr/bin/env python3
from __future__ import annotations
import json, re, sys, xml.etree.ElementTree as ET
from pathlib import Path

root=Path(sys.argv[1] if len(sys.argv)>1 else '.').resolve()
errors=[]; warnings=[]

def error(msg): errors.append(msg)
def warn(msg): warnings.append(msg)

def read_json(path):
    try: return json.loads(path.read_text(encoding='utf-8'))
    except Exception as ex: error(f'JSON parse failed: {path}: {ex}'); return None

for p in root.rglob('*.json'): read_json(p)
for p in root.rglob('*.csproj'):
    try: ET.parse(p)
    except Exception as ex: error(f'Project XML parse failed: {p}: {ex}')
try: ET.parse(root/'client.runsettings')
except Exception as ex: error(f'Runsettings XML parse failed: {ex}')

features=sorted(root.glob('tests/*/Features/*.feature'))
if len(features)!=32: error(f'Expected 32 generated Features, found {len(features)}.')
feature_names=[]; feature_steps={}
for p in features:
    text=p.read_text(encoding='utf-8')
    m=re.search(r'^\s*Feature:\s*(.+)$',text,re.M)
    if not m: error(f'Missing Feature title: {p}'); continue
    name=m.group(1).strip(); feature_names.append(name)
    if 'Scenario Outline:' not in text or 'Examples:' not in text: error(f'Feature is not data-driven Scenario Outline: {p}')
    steps=[]
    for line in text.splitlines():
        sm=re.match(r'^\s*(Given|When|Then|And|But)\s+(.+)$',line)
        if sm: steps.append(sm.group(2).strip())
    feature_steps[name]=steps
if len(feature_names)!=len(set(feature_names)): error('Duplicate Feature titles detected.')

# C# lexical balance and duplicate types.
def strip_csharp(text):
    out=[]; i=0; state='code'
    while i<len(text):
        if state=='code':
            if text.startswith('//',i): state='line'; i+=2; out.append('  '); continue
            if text.startswith('/*',i): state='block'; i+=2; out.append('  '); continue
            if text.startswith('@"',i): state='verbatim'; i+=2; out.append('  '); continue
            if text[i]=='"': state='string'; i+=1; out.append(' '); continue
            if text[i]=="'": state='char'; i+=1; out.append(' '); continue
            out.append(text[i]); i+=1
        elif state=='line':
            if text[i]=='\n': state='code'; out.append('\n')
            else: out.append(' ')
            i+=1
        elif state=='block':
            if text.startswith('*/',i): state='code'; out.append('  '); i+=2
            else: out.append('\n' if text[i]=='\n' else ' '); i+=1
        elif state=='string':
            if text[i]=='\\': out.append('  '); i+=2
            elif text[i]=='"': state='code'; out.append(' '); i+=1
            else: out.append('\n' if text[i]=='\n' else ' '); i+=1
        elif state=='verbatim':
            if text.startswith('""',i): out.append('  '); i+=2
            elif text[i]=='"': state='code'; out.append(' '); i+=1
            else: out.append('\n' if text[i]=='\n' else ' '); i+=1
        elif state=='char':
            if text[i]=='\\': out.append('  '); i+=2
            elif text[i]=="'": state='code'; out.append(' '); i+=1
            else: out.append(' '); i+=1
    return ''.join(out),state

types_by_project={}
for project in [root/'src'/'ToscaArtifactAutomation.Core',*root.glob('tests/*.Tests')]:
    if not project.exists(): continue
    names=[]
    for p in project.rglob('*.cs'):
        text=p.read_text(encoding='utf-8')
        clean,state=strip_csharp(text)
        if state!='code': error(f'Unterminated C# lexical construct in {p}: {state}')
        for left,right in [('(',')'),('{','}'),('[',']')]:
            if clean.count(left)!=clean.count(right): error(f'Unbalanced {left}{right} in {p}: {clean.count(left)} vs {clean.count(right)}')
        names += re.findall(r'\b(?:class|record|interface|enum)\s+(\w+)',clean)
    dup=sorted({n for n in names if names.count(n)>1})
    if dup: error(f'Duplicate C# type names in {project.name}: {dup[:20]}')
    types_by_project[project.name]=len(names)

# Generated binding manifest is authoritative and independently reconciled to Feature order.
binding_manifest=read_json(root/'Artifacts'/'BindingManifest.json') or []
by_feature={x['feature']:x for x in binding_manifest}
for feature,steps in feature_steps.items():
    item=by_feature.get(feature)
    if not item: error(f'Missing binding manifest entry for Feature: {feature}'); continue
    expected=item['allSteps']
    if steps!=expected: error(f'Feature/binding sequence mismatch for {feature}. Feature={len(steps)}, manifest={len(expected)}')
    if len(item['stageMethods']) != len(item['stagePhrases']): error(f'Stage method count mismatch for {feature}.')
if len(by_feature)!=len(feature_steps): error('Binding manifest contains a different number of Features than generated Features.')

# StepDefinition -> PageMethod contract.
for item in binding_manifest:
    step_file=root/item['stepDefinitionFile']; page_file=root/item['pageMethodFile']
    if not step_file.exists(): error(f'Missing StepDefinition file: {step_file}'); continue
    if not page_file.exists(): error(f'Missing PageMethod file: {page_file}'); continue
    st=step_file.read_text(encoding='utf-8'); pg=page_file.read_text(encoding='utf-8')
    call_positions=[]
    for method in item['stageMethods']:
        call=f'_flow.{method}Async()'
        pos=st.find(call)
        if pos<0: error(f'StepDefinition does not call PageMethod {method} for {item["feature"]}')
        call_positions.append(pos)
        if f'{method}Async(' not in pg: error(f'PageMethod {method} does not exist for {item["feature"]}')
    if call_positions != sorted(call_positions): error(f'StepDefinition PageMethod calls are out of Feature order for {item["feature"]}')

manifest=read_json(root/'Artifacts'/'CanonicalMappingManifest.json') or []
ids=[x['actionId'] for x in manifest]
if len(ids)!=len(set(ids)): error('Duplicate canonical action IDs detected.')
for feature,items in __import__('itertools').groupby(sorted(manifest,key=lambda x:(x['feature'],x['sequence'])),lambda x:x['feature']):
    seq=[x['sequence'] for x in items]
    if seq!=sorted(seq) or len(seq)!=len(set(seq)): error(f'Non-unique or unordered canonical sequence for {feature}.')
if any(x['operation']=='SystemAction' for x in manifest): error('System/TBox operation leaked into a business PageMethod map.')
if any(x['operation']=='SourceInstruction' for x in manifest): error('Unclassified generic SourceInstruction remains in a generated business map.')


# v38 semantic action contract.
allowed_operations={'Navigate','Authenticate','Constraint','Input','SmartSet','Click','Select','Press','Wait','Verify','Capture','SetRuntime','GenerateRandom','Evaluate','ExternalValue','ExternalInput'}
required_target={'Authenticate','Constraint','Input','SmartSet','Click','Select','Verify','Capture','ExternalInput'}
for x in manifest:
    op=x.get('operation',''); target=x.get('target',''); source=x.get('sourceSentence',''); expected=x.get('expectedExpression','')
    if op not in allowed_operations: error(f'Unsupported canonical operation {op}: {x.get("actionId")}')
    if op in required_target and not target: error(f'Missing target for {op}: {x.get("actionId")}')
    if op in {'Verify','Constraint'} and not expected: error(f'Missing expected contract for {op}: {x.get("actionId")}')
    if op=='Authenticate' and target not in {'CL_EQ','CL_DC','PL_DC'}: error(f'Invalid authentication profile {target}: {x.get("actionId")}')
    if op=='Wait' and not target and int(x.get('timeoutMs') or 0)<=0: error(f'Wait has neither target nor duration: {x.get("actionId")}')
    if op=='Input' and 'identifying constraint' in source.lower(): error(f'Tosca constraint compiled as Input: {x.get("actionId")}')
    if op=='Verify' and re.match(r'(?i)^(?:i\s+)?(?:enter|use|set|keep|leave|click|select|answer|activate|open|press)\b',source): error(f'Action sentence compiled as Verify: {x.get("actionId")}')
    if re.search(r'\{(?:TAB|CLICK|SENDKEYS|SCROLL|ENTER|SHIFTTAB)',target,re.I): error(f'Steering command leaked into locator target: {x.get("actionId")} / {target}')
    if '{REGEX[' in expected: error(f'Raw Tosca REGEX expression remains: {x.get("actionId")}')
    if re.search(r'(?i)\b(?:YDH040|FFQA00[89]|Anico456)\b',source) or re.search(r'[A-Za-z0-9+/=]{80,}',source): error(f'Credential data leaked into canonical evidence: {x.get("actionId")}')

core_action=(root/'src'/'ToscaArtifactAutomation.Core'/'Canonical'/'CanonicalAction.cs').read_text(encoding='utf-8')
core_executor=(root/'src'/'ToscaArtifactAutomation.Core'/'Canonical'/'CanonicalActionExecutor.cs').read_text(encoding='utf-8')
for op in ('Authenticate','Constraint'):
    if op not in core_action: error(f'CanonicalOperation.{op} is missing from the Core enum.')
    if f'case CanonicalOperation.{op}:' not in core_executor: error(f'CanonicalOperation.{op} is missing from the executor.')
condition_review=read_json(root/'Artifacts'/'UnresolvedConditionReview.json') or {}
if condition_review.get('count',0) != len(condition_review.get('items',[])): error('Unresolved-condition review count is inconsistent.')

# Data reference contract.
inventory=read_json(root/'Artifacts'/'FeatureInventory.json') or []
inv_by_flow={x['flow'].lower():x for x in inventory}
for project in root.glob('tests/*.Tests'):
    data_docs={p.stem:read_json(p) for p in (project/'TestData'/'Scenarios').glob('*.json')}
    for p,d in data_docs.items():
        if d is None: continue
        if 'values' not in d or 'random' not in d or 'dimensions' not in d: error(f'Incomplete scenario data structure: {p}')
for x in manifest:
    for expr in (x.get('valueExpression',''),):
        for key in re.findall(r'\{\{data:([^}]+)\}\}',expr):
            # data key existence is checked against every document for the corresponding flow through flow slug.
            inv=inv_by_flow.get(x['flow'].lower())
            if inv:
                data_stem=re.sub(r'[^a-z0-9]+','_',inv['sourceFile'].rsplit('.',1)[0].lower()).strip('_')
                candidates=list(root.glob(f'tests/*.Tests/TestData/Scenarios/{data_stem}.json'))
                if candidates:
                    doc=read_json(candidates[0]) or {}
                    if key not in doc.get('values',{}): error(f'Missing data key {key} for action {x["actionId"]}')
                else: error(f'Missing scenario data document for flow {x["flow"]}')

# Security and anti-regression checks.
for p in root.rglob('*'):
    if not p.is_file() or p.suffix.lower() in {'.zip','.png','.mp4','.webm'}: continue
    text=p.read_text(encoding='utf-8',errors='ignore')
    if re.search(r'(?i)\{AES\[|\{CP\[',text): error(f'Credential/protected source payload leaked into {p}')
    if re.search(r'\[(Given|When|Then)\(@?"\^\(\.\*\)\$"\)\]',text): error(f'Catch-all ReqnRoll binding detected in {p}')
    if p.suffix=='.feature' and re.search(r'\{(?:PL|XL|TDS)\[',text,re.I): error(f'Raw Tosca data expression leaked into business Feature {p}')

locator_counts={}
for p in root.glob('tests/*.Tests/Locators/locator-catalog.json'):
    doc=read_json(p) or {}; defs=doc.get('definitions',[]); locator_counts[p.parent.parent.name]=len(defs)
    ids=[x.get('id') for x in defs]
    if len(ids)!=len(set(ids)): error(f'Duplicate locator IDs in {p}')
    for d in defs:
        if any(mark in (d.get('module','').lower()) for mark in ('tbox set buffer','tbox partial buffer','tbox wait','tbox start program','take screenshot')):
            error(f'System module leaked into locator catalog: {d.get("module")} / {d.get("name")}')

report={'passed':not errors,'errors':errors,'warnings':warnings,'featureCount':len(features),'canonicalActionCount':len(manifest),'typedAuthenticationActionCount':sum(1 for x in manifest if x.get('operation')=='Authenticate'),'typedConstraintActionCount':sum(1 for x in manifest if x.get('operation')=='Constraint'),'unresolvedConditionReviewCount':condition_review.get('count',0),'typeCounts':types_by_project,'locatorCounts':locator_counts}
out=root/'artifacts'/'RuntimeQualityGateReport.json'; out.parent.mkdir(parents=True,exist_ok=True); out.write_text(json.dumps(report,indent=2)+'\n')
print(json.dumps(report,indent=2))
if errors: sys.exit(1)
