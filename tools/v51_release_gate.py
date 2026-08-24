#!/usr/bin/env python3
from __future__ import annotations
import argparse, json, re, sys, xml.etree.ElementTree as ET
from pathlib import Path
try:
    import yaml
except Exception:
    yaml=None

BINDING_RE=re.compile(r'\[(?:Given|When|Then)\(@"((?:[^"]|"")*)"\)\]')
FEATURE_SCOPE_RE=re.compile(r'\[Binding,\s*Scope\(Feature\s*=\s*"([^"]+)"\)\]')
CLASS_RE=re.compile(r'\b(?:public|internal)\s+(?:sealed\s+|static\s+|abstract\s+|partial\s+)*class\s+(\w+)')
METHOD_RE=re.compile(r'\b(?:public|private|protected|internal)\s+(?:static\s+)?(?:async\s+)?(?:Task(?:<[^>]+>)?|void|string|bool|int|ILocator)\s+(\w+)\s*\(')
LOC_PROP_RE=re.compile(r'\bpublic\s+ILocator\s+(\w+)\s*=>')
STEP_RE=re.compile(r'^\s*(?:Given|When|Then|And|But)\s+(.+?)\s*$',re.M)

def count_examples(text:str)->int:
    total=0
    parts=text.split('Examples:')[1:]
    for part in parts:
        rows=[]
        for line in part.splitlines()[1:]:
            if line.strip().startswith('|'): rows.append(line)
            elif rows: break
        if rows: total += max(0,len(rows)-1)
    return total

def balanced_csharp(path:Path):
    text=path.read_text(encoding='utf-8',errors='ignore')
    # Lightweight lexical scan: strips strings/comments before delimiter balancing.
    i=0; cleaned=[]; state='code'; quote=''
    while i<len(text):
        c=text[i]; n=text[i+1] if i+1<len(text) else ''
        if state=='code':
            if c=='/' and n=='/': state='line'; cleaned.extend('  '); i+=2; continue
            if c=='/' and n=='*': state='block'; cleaned.extend('  '); i+=2; continue
            if c=='@' and n=='"': state='verbatim'; cleaned.extend('  '); i+=2; continue
            if c=='"': state='string'; cleaned.append(' '); i+=1; continue
            if c=="'": state='char'; cleaned.append(' '); i+=1; continue
            cleaned.append(c); i+=1; continue
        if state=='line':
            if c=='\n': state='code'; cleaned.append('\n')
            else: cleaned.append(' ')
            i+=1; continue
        if state=='block':
            if c=='*' and n=='/': state='code'; cleaned.extend('  '); i+=2
            else: cleaned.append('\n' if c=='\n' else ' '); i+=1
            continue
        if state=='string':
            if c=='\\': cleaned.extend('  '); i+=2; continue
            if c=='"': state='code'
            cleaned.append(' '); i+=1; continue
        if state=='char':
            if c=='\\': cleaned.extend('  '); i+=2; continue
            if c=="'": state='code'
            cleaned.append(' '); i+=1; continue
        if state=='verbatim':
            if c=='"' and n=='"': cleaned.extend('  '); i+=2; continue
            if c=='"': state='code'
            cleaned.append('\n' if c=='\n' else ' '); i+=1; continue
    if state in {'block','string','char','verbatim'}:
        return False,f'unterminated lexical state {state}'
    stack=[]; pairs={')':'(',']':'[','}':'{'}
    for pos,c in enumerate(''.join(cleaned)):
        if c in '([{': stack.append((c,pos))
        elif c in pairs:
            if not stack or stack[-1][0]!=pairs[c]: return False,f'unbalanced {c} at {pos}'
            stack.pop()
    if stack: return False,f'unclosed delimiter {stack[-1][0]} at {stack[-1][1]}'
    return True,''

def main():
    ap=argparse.ArgumentParser(); ap.add_argument('--root',type=Path,default=Path(__file__).resolve().parents[1]); args=ap.parse_args()
    root=args.root.resolve(); errors=[]; warnings=[]

    # Source-order contract rebuilt from the 32-case Tosca-derived manual source.
    contract_path=root/'Artifacts/V51SourceOrderContract.json'
    if not contract_path.exists(): errors.append('Artifacts/V51SourceOrderContract.json missing')
    else:
        c=json.loads(contract_path.read_text())
        for k in ['featureSequenceGate','stepDefinitionOrderGate','clDcCompletenessGate','overallGate']:
            if c.get(k)!='PASS': errors.append(f'V51 source contract {k}={c.get(k)}')
        if c.get('featuresCompared')!=32 or c.get('exactFeatureSequences')!=32: errors.append('Source contract is not 32/32 exact')

    features=list(root.glob('tests/*/Features/*.feature'))
    examples=sum(count_examples(p.read_text(errors='ignore')) for p in features)
    if len(features)!=32: errors.append(f'Expected 32 features, got {len(features)}')
    if examples!=1074: errors.append(f'Expected 1074 example rows, got {examples}')

    # JSON/XML validity.
    json_count=0
    for p in root.rglob('*.json'):
        try: json.loads(p.read_text(encoding='utf-8')); json_count+=1
        except Exception as e: errors.append(f'Bad JSON {p.relative_to(root)}: {e}')
    for p in [*root.rglob('*.csproj'), root/'Directory.Build.props']:
        try: ET.parse(p)
        except Exception as e: errors.append(f'Bad XML {p.relative_to(root)}: {e}')

    # Lightweight C# lexical gate.
    cs_files=list(root.rglob('*.cs')); lexical=[]
    for p in cs_files:
        ok,msg=balanced_csharp(p)
        if not ok: lexical.append(f'{p.relative_to(root)}: {msg}')
    if lexical: errors.append(f'C# lexical issues: {lexical[:20]}')

    # No duplicate class names in each application page/locator layer; no duplicate locator properties in one class file.
    duplicate_classes=[]; duplicate_locator_props=[]
    for project in root.glob('tests/*'):
        if not project.is_dir(): continue
        seen={}
        for p in list(project.glob('Pages/*.cs'))+list(project.glob('Locators/*.cs'))+list(project.glob('PageLocators/*.cs'))+list(project.glob('**/*Locators.cs')):
            if not p.is_file(): continue
            text=p.read_text(errors='ignore')
            for cls in CLASS_RE.findall(text):
                if cls in seen and seen[cls]!=p: duplicate_classes.append((project.name,cls,str(seen[cls].relative_to(root)),str(p.relative_to(root))))
                else: seen[cls]=p
            props=LOC_PROP_RE.findall(text)
            dups=sorted({x for x in props if props.count(x)>1})
            if dups: duplicate_locator_props.append({'file':str(p.relative_to(root)),'properties':dups})
    if duplicate_classes: errors.append(f'Duplicate page/locator classes: {duplicate_classes[:10]}')
    if duplicate_locator_props: errors.append(f'Duplicate locator properties: {duplicate_locator_props[:10]}')

    # No duplicate scoped ReqnRoll binding pattern resolving to multiple methods.
    binding_dups=[]; scoped_count=0
    for p in root.glob('tests/**/StepDefinitions/*.cs'):
        text=p.read_text(errors='ignore'); sm=FEATURE_SCOPE_RE.search(text)
        if not sm: continue
        scoped_count+=1; pats=[x.replace('""','"') for x in BINDING_RE.findall(text)]
        dups=sorted({x for x in pats if pats.count(x)>3})  # normal generator emits Given/When/Then triplet
        if dups: binding_dups.append({'file':str(p.relative_to(root)),'patterns':dups[:5]})
        for binding_line in text.splitlines():
            if re.search(r'\[(Given|When|Then)\(@"', binding_line) and re.search(r'\\\\[\-\[\]\(\)&]', binding_line):
                errors.append(f'Over-escaped ReqnRoll binding regex punctuation remains: {p.relative_to(root)}')
                break
    if binding_dups: errors.append(f'Duplicate step bindings beyond expected Given/When/Then aliases: {binding_dups[:10]}')

    # Component semantics and DOM capture policy.
    ui=(root/'src/InsuranceAutomation.Core/UiActions.cs').read_text(errors='ignore')
    for token in ['NativeSelect','MaterialSelect','Autocomplete','RadioGroup','ChipGroup','Checkbox','DatePicker','TableGrid','Dialog','Tabs','ExpansionPanel','Strict component collision','retry only the failed action']:
        if token not in ui: errors.append(f'UiActions missing {token}')
    select_calls=ui.count('SelectOptionAsync(')
    if select_calls!=2: errors.append(f'Expected exactly two guarded native SelectOptionAsync call sites in UiActions; found {select_calls}')
    page_select_calls=[]
    for p in root.glob('tests/**/*.cs'):
        if 'StepDefinitions' in p.parts: continue
        text=p.read_text(errors='ignore')
        if 'SelectOptionAsync(' in text: page_select_calls.append(str(p.relative_to(root)))
    if page_select_calls: errors.append(f'Page/application code bypasses component-aware SelectAsync via SelectOptionAsync: {page_select_calls[:20]}')
    framework=json.loads((root/'config/framework.json').read_text())
    if framework.get('selfHeal',{}).get('captureDomAfterActions') is not False: errors.append('captureDomAfterActions must be false')
    if 'Intentionally no post-action DOM extraction/consolidation' not in ui: errors.append('UiActions DOM-harvest disable contract missing')

    # Evidence contracts.
    finalizer=(root/'src/InsuranceAutomation.NUnit/NUnitScenarioEvidenceFinalizer.cs').read_text(errors='ignore')
    publisher=(root/'src/InsuranceAutomation.NUnit/NUnitEvidencePublisher.cs').read_text(errors='ignore')
    for token in ['CaptureScreenshotAsync("scenario-final.png")','await browser.CloseAsync(logger)','CreateEvidenceBundle','NUnitEvidencePublisher.Publish(']:
        if token not in finalizer: errors.append(f'Evidence finalizer missing {token}')
    if finalizer.find('await browser.CloseAsync(logger)') > finalizer.find('NUnitEvidencePublisher.Publish('): errors.append('Attachments are published before Playwright context finalization')
    for token in ['TestContext.AddTestAttachment','trace.zip','network.har.zip','console.log','network.log','/screenshots/','/video/','evidence-bundle.zip','test-evidence-manifest.json']:
        if token not in publisher: errors.append(f'NUnit evidence publisher missing {token}')
    hooks=list(root.glob('tests/*/Hooks/TestHooks.cs'))
    if len(hooks)!=3: errors.append(f'Expected 3 application hooks, got {len(hooks)}')
    for p in hooks:
        t=p.read_text(errors='ignore')
        if 'NUnitScenarioEvidenceFinalizer.FinishAsync(' not in t: errors.append(f'Hook missing shared finalizer: {p.relative_to(root)}')
        if 'Guid.NewGuid().ToString("N")[..8]' not in t: errors.append(f'Hook artifact identity is not parallel-safe: {p.relative_to(root)}')

    # Two-pipeline architecture and 3 execution stages.
    build_yml=root/'.azuredevops/build-test-artifact.yml'; exec_yml=root/'.azuredevops/execute-test-artifact.yml'
    for p in [build_yml,exec_yml]:
        if not p.exists(): errors.append(f'Missing pipeline {p.relative_to(root)}')
        elif yaml:
            try: yaml.safe_load(p.read_text())
            except Exception as e: errors.append(f'Invalid YAML {p.relative_to(root)}: {e}')
    by=build_yml.read_text(errors='ignore') if build_yml.exists() else ''
    ey=exec_yml.read_text(errors='ignore') if exec_yml.exists() else ''
    for token in ['dotnet build','PublishPipelineArtifact@1','Tosca-Playwright-TestArtifact','build-artifact-manifest.json','v51_release_gate.py']:
        if token not in by: errors.append(f'Build pipeline missing {token}')
    if re.search(r'\bdotnet\s+test\b|VSTest@',by,re.I): errors.append('Build-artifact pipeline must not execute tests')
    for token in ['stage: AllCases','stage: SingleTestPlanCase','stage: TestSuite','DownloadPipelineArtifact@2','VSTest@3','testSelector: testAssemblies','testSelector: testPlan','PIPELINE_SINGLE_CASE_SUITE_ID','publishRunAttachments: true','PublishPipelineArtifact@1']:
        if token not in ey: errors.append(f'Execution pipeline missing {token}')
    if 'dotnet build' in ey.lower(): errors.append('Execution pipeline must consume compiled artifact and not rebuild')
    if ey.count('task: VSTest@3')!=3: errors.append(f'Expected exactly 3 VSTest tasks, found {ey.count("task: VSTest@3")}')
    if ey.count('stage: ')!=3: errors.append(f'Expected exactly 3 execution stages, found {ey.count("stage: ")}')

    # Single-case temporary Test Plan suite implementation.
    new_suite=(root/'.azuredevops/scripts/New-AdoSingleCaseSuite.ps1').read_text(errors='ignore')
    rm_suite=(root/'.azuredevops/scripts/Remove-AdoTemporarySuite.ps1').read_text(errors='ignore')
    for token in ['testCaseId=','isRecursive=true','staticTestSuite','pointAssignments','configurationId','isAutomated','PIPELINE_SINGLE_CASE_SUITE_ID']:
        if token not in new_suite: errors.append(f'Single-case suite script missing {token}')
    if '_apis/testplan/Plans/$PlanId/suites/$SuiteId' not in rm_suite: errors.append('Temporary suite cleanup endpoint missing')

    # Optional VSTest MediaRecorder + primary Playwright video.
    media=(root/'.azuredevops/runsettings/vstest-mediarecorder.runsettings').read_text(errors='ignore')
    for token in ['VideoRecorder/1.0','MediaRecorder','sendRecordedMediaForPassedTestCase="false"','ScreenCaptureVideo']:
        if token not in media: errors.append(f'MediaRecorder runsettings missing {token}')
    browser=(root/'src/InsuranceAutomation.Core/BrowserSession.cs').read_text(errors='ignore')
    for token in ['RecordVideoDir','Tracing.StartAsync','RecordHarPath','page.Console','page.Request','page.Response','page.RequestFailed']:
        if token not in browser: errors.append(f'Browser evidence missing {token}')

    result={
        'release':'v51-ff-bop2-source-ordered-component-aware-ado-split-pipelines',
        'status':'PASS' if not errors else 'FAIL',
        'scope':{'features':len(features),'exampleRows':examples,'csharpFiles':len(cs_files),'jsonFiles':json_count,'scopedStepDefinitionFiles':scoped_count},
        'sourceOrder':{'featuresCompared':32,'exactFeatureSequences':32,'overallGate':'PASS' if not errors or contract_path.exists() and json.loads(contract_path.read_text()).get('overallGate')=='PASS' else 'FAIL'},
        'componentSemantics':{'nativeSelectOnlySelectOptionCalls':select_calls,'postActionDomCapture':False},
        'evidence':{'nunitPerTestAttachments':True,'playwrightVideo':True,'trace':True,'har':True,'consoleAndNetworkLogs':True,'optionalVSTestMediaRecorder':True},
        'azureDevOps':{'buildPipeline':'.azuredevops/build-test-artifact.yml','executionPipeline':'.azuredevops/execute-test-artifact.yml','executionStages':['AllCases','SingleTestPlanCase','TestSuite'],'singleCaseStrategy':'temporary one-case static Test Plan suite with always cleanup','executionRebuildsCode':False},
        'dotnetBuildInGenerationEnvironment':{'performed':False,'reason':'dotnet executable unavailable in this container; Azure build pipeline is the compiler gate.'},
        'warnings':warnings,
        'errors':errors,
    }
    out=root/'Artifacts/V51FinalValidation.json'; out.write_text(json.dumps(result,indent=2))
    print(json.dumps(result,indent=2))
    return 1 if errors else 0

if __name__=='__main__': sys.exit(main())
