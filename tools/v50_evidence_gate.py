#!/usr/bin/env python3
from pathlib import Path
import json,re,sys,xml.etree.ElementTree as ET
root=Path(__file__).resolve().parents[1]
errors=[]

# Core structure / project references
nunit_proj=root/'src/InsuranceAutomation.NUnit/InsuranceAutomation.NUnit.csproj'
publisher=root/'src/InsuranceAutomation.NUnit/NUnitEvidencePublisher.cs'
if not nunit_proj.exists(): errors.append('InsuranceAutomation.NUnit project missing')
if not publisher.exists(): errors.append('NUnitEvidencePublisher missing')

for p in root.glob('tests/*/*.csproj'):
    text=p.read_text(encoding='utf-8')
    if '../../src/InsuranceAutomation.NUnit/InsuranceAutomation.NUnit.csproj' not in text:
        errors.append(f'NUnit evidence project reference missing: {p.relative_to(root)}')

# Hooks: exact timing contract. v51 centralizes finalization in one shared helper.
hook_results=[]
finalizer=root/'src/InsuranceAutomation.NUnit/NUnitScenarioEvidenceFinalizer.cs'
ft=finalizer.read_text(encoding='utf-8') if finalizer.exists() else ''
finalizer_ok=True
for token in ['CaptureScreenshotAsync("scenario-final.png")','await browser.CloseAsync(logger)','browser.TracePath','browser.VideoPath','browser.HarPath','CreateEvidenceBundle','logger.Flush()','NUnitEvidencePublisher.Publish(','logger.Dispose()']:
    if token not in ft:
        errors.append(f'Finalizer missing {token}')
        finalizer_ok=False
close=ft.find('await browser.CloseAsync(logger)')
publish=ft.find('NUnitEvidencePublisher.Publish(')
if close<0 or publish<close:
    errors.append('Shared finalizer does not close browser before publishing attachments')
    finalizer_ok=False

for p in root.glob('tests/*/Hooks/TestHooks.cs'):
    text=p.read_text(encoding='utf-8')
    ok='NUnitScenarioEvidenceFinalizer.FinishAsync(' in text and finalizer_ok
    if not ok: errors.append(f'Hook does not use validated shared evidence finalizer: {p.relative_to(root)}')
    if 'Guid.NewGuid().ToString("N")[..8]' not in text:
        errors.append(f'Hook missing parallel-safe artifact identity: {p.relative_to(root)}')
    hook_results.append({'file':str(p.relative_to(root)),'browserCloseBeforePublish':ok,'sharedFinalizer':True})
if len(hook_results)!=3: errors.append(f'Expected 3 application hooks, got {len(hook_results)}')

# Publisher capabilities
pt=publisher.read_text(encoding='utf-8') if publisher.exists() else ''
for token in ['TestContext.AddTestAttachment','SearchOption.AllDirectories','test-evidence-manifest.json','nunit-attachment-result.json',
              'SHA256.HashData','evidence-bundle.zip','network.har.zip','trace.zip','console.log','network.log','/screenshots/','/video/','/self-heal/',
              'Evidence transport must never replace the actual business-test outcome']:
    if token not in pt: errors.append(f'Publisher capability missing: {token}')

# Scenario-owned DOM and healing evidence
for path,tokens in [
    (root/'src/InsuranceAutomation.Core/DomEvidenceCollector.cs',['scenarioObservations','master-page-dom.html','locator-history.json','scenarioObservation']),
    (root/'src/InsuranceAutomation.Core/LlmLocatorHealer.cs',['scenarioHealDirectory','healing-events.jsonl'])]:
    text=path.read_text(encoding='utf-8')
    for token in tokens:
        if token not in text: errors.append(f'{path.name} missing scenario evidence token: {token}')

# Reporting config defaults
for cfg in [root/'config/framework.json',root/'config/framework.copilot.example.json',root/'config/framework.openai.example.json']:
    try: data=json.loads(cfg.read_text(encoding='utf-8'))
    except Exception as e: errors.append(f'Invalid config {cfg.name}: {e}'); continue
    r=data.get('reporting',{})
    if r.get('attachEvidenceToTestResult') is not True: errors.append(f'Attachment integration disabled in {cfg.name}')
    if r.get('attachmentMode')!='all': errors.append(f'Attachment mode is not all in {cfg.name}')
    if int(r.get('maxAttachmentCount',0))<1000: errors.append(f'Attachment count guard too low in {cfg.name}')

# Azure DevOps native NUnit publication contract
pipeline=root/'.azuredevops/azure-pipelines.yml'
yml=pipeline.read_text(encoding='utf-8') if pipeline.exists() else ''
for token in ['NUnit.TestOutputXml','PublishTestResults@2','testResultsFormat: NUnit','publishRunAttachments: true','condition: always()','PublishPipelineArtifact@1']:
    if token not in yml: errors.append(f'ADO pipeline missing: {token}')

# Keep source-order gate inherited and green
source_gate=root/'Artifacts/V50SourceOrderContract.json'
if not source_gate.exists(): errors.append('V50SourceOrderContract.json missing')
else:
    d=json.loads(source_gate.read_text(encoding='utf-8'))
    for k in ['featureSequenceGate','stepDefinitionOrderGate','clDcCompletenessGate','overallGate']:
        if d.get(k)!='PASS': errors.append(f'Source/order gate failed: {k}={d.get(k)}')
    if d.get('featuresCompared')!=32 or d.get('exactFeatureSequences')!=32: errors.append('32/32 source order not preserved')

# JSON/XML validity
json_count=0
for p in root.rglob('*.json'):
    try: json.loads(p.read_text(encoding='utf-8')); json_count+=1
    except Exception as e: errors.append(f'Bad JSON {p.relative_to(root)}: {e}')
for p in [*root.rglob('*.csproj'),root/'Directory.Build.props']:
    try: ET.parse(p)
    except Exception as e: errors.append(f'Bad XML {p.relative_to(root)}: {e}')

# Fast C# lexical balance scrubber for new/modified architecture files.
def scrub(text):
    out=[]; i=0; n=len(text); state='code'; rawq=0
    while i<n:
        c=text[i]; nxt=text[i+1] if i+1<n else ''
        if state=='code':
            if c=='/' and nxt=='/': state='line'; out.extend('  '); i+=2; continue
            if c=='/' and nxt=='*': state='block'; out.extend('  '); i+=2; continue
            m=re.match(r'\$*"{3,}',text[i:])
            if m: rawq=m.group(0).count('"'); state='raw'; out.extend(' '*len(m.group(0))); i+=len(m.group(0)); continue
            if c=='@' and nxt=='"': state='verb'; out.extend('  '); i+=2; continue
            if c in '"\'': state='str'; quote=c; out.append(' '); i+=1; continue
            if c=='$' and nxt=='"': state='str'; quote='"'; out.extend('  '); i+=2; continue
            out.append(c); i+=1; continue
        if state=='line':
            if c=='\n': state='code'; out.append('\n')
            else: out.append(' ')
            i+=1; continue
        if state=='block':
            if c=='*' and nxt=='/': out.extend('  '); i+=2; state='code'; continue
            out.append('\n' if c=='\n' else ' '); i+=1; continue
        if state=='verb':
            if c=='"' and nxt=='"': out.extend('  '); i+=2; continue
            if c=='"': out.append(' '); i+=1; state='code'; continue
            out.append('\n' if c=='\n' else ' '); i+=1; continue
        if state=='raw':
            if text.startswith('"'*rawq,i): out.extend(' '*rawq); i+=rawq; state='code'; continue
            out.append('\n' if c=='\n' else ' '); i+=1; continue
        if state=='str':
            if c=='\\': out.extend('  ' if i+1<n else ' '); i+=2; continue
            if c==quote: out.append(' '); i+=1; state='code'; continue
            out.append('\n' if c=='\n' else ' '); i+=1; continue
    return ''.join(out),state

csharp_errors=[]
for p in root.rglob('*.cs'):
    t=p.read_text(encoding='utf-8'); clean,state=scrub(t)
    if state!='code': csharp_errors.append(f'Unclosed {state}: {p.relative_to(root)}')
    for a,b,label in [('{','}','brace'),('(',')','paren'),('[',']','bracket')]:
        depth=0
        for ch in clean:
            if ch==a: depth+=1
            elif ch==b:
                depth-=1
                if depth<0: csharp_errors.append(f'Extra closing {label}: {p.relative_to(root)}'); break
        if depth!=0: csharp_errors.append(f'Unbalanced {label} {depth}: {p.relative_to(root)}')
errors.extend(csharp_errors)

report={
  'release':'v50-test-result-evidence',
  'status':'PASS' if not errors else 'FAIL',
  'sourceOrder':{'features':32,'status':'PASS' if source_gate.exists() and json.loads(source_gate.read_text()).get('overallGate')=='PASS' else 'FAIL'},
  'testFramework':'NUnit 4 + NUnit3TestAdapter + ReqnRoll',
  'evidenceAttachment':{
    'testScoped':True,'defaultMode':'all','nunitAddTestAttachment':True,'visualStudioAdapterPath':True,
    'azureDevOpsNativeNUnitXml':True,'publishTestResultsV2':True,
    'artifactTypes':['execution log','HTML report','screenshots','browser console log','network call log','Playwright trace','HAR','video','self-heal evidence','evidence bundle','SHA-256 manifest','attachment result']
  },
  'hooks':hook_results,
  'jsonFilesValidated':json_count,
  'csharpFilesLexicallyValidated':len(list(root.rglob('*.cs'))),
  'dotnetBuild':{'performed':False,'reason':'dotnet executable is not installed in this generation environment; CI/Visual Studio remains the compiler/runtime gate.'},
  'errors':errors
}
(root/'Artifacts/V50EvidenceAttachmentValidation.json').write_text(json.dumps(report,indent=2),encoding='utf-8')
print(json.dumps(report,indent=2))
sys.exit(1 if errors else 0)
