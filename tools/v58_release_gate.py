#!/usr/bin/env python3
from pathlib import Path
import re, json, hashlib, sys, xml.etree.ElementTree as ET
ROOT=Path(__file__).resolve().parents[1]
BASE=Path('/mnt/data/v58_before')
errors=[]; warnings=[]; checks={}; metrics={}
def req(name,ok,msg):
    checks[name]=bool(ok)
    if not ok: errors.append(msg)
def txt(rel): return (ROOT/rel).read_text(encoding='utf-8',errors='ignore')

def locator_props():
    out={}
    for f in (ROOT/'tests/CommercialLines.DuckCreek.Tests/Pages/Locators').glob('*Locators.cs'):
        if f.name=='CanonicalDuckCreekLocatorFactory.cs': continue
        page=f.stem.removesuffix('Locators')
        props=[]
        for m in re.finditer(r'public\s+ILocator\s+(\w+)\s*=>\s*(.*?);\s*$',f.read_text(),re.M):
            props.append((m.group(1),re.sub(r'\s+',' ',m.group(2).strip())))
        out[page]=props
    return out
props=locator_props(); allprops={(p,n) for p,rows in props.items() for n,e in rows}
metrics['cldcLocatorProperties']=len(allprops)

# one physical/control expression -> one property in each page catalog
loc_dups=[]
for page,rows in props.items():
    by={}
    for n,e in rows: by.setdefault(e,[]).append(n)
    loc_dups += [(page,e,names) for e,names in by.items() if len(names)>1]
req('no-duplicate-locator-expressions',not loc_dups,f'{len(loc_dups)} duplicate locator expressions remain: {loc_dups[:5]}')

# The same raw Tosca ModuleAttribute GUID may not surface under two final control APIs on one page.
guid_owners={}
guid_dups=[]
for page,rows in props.items():
    loc_file=ROOT/f'tests/CommercialLines.DuckCreek.Tests/Pages/Locators/{page}Locators.cs'
    if not loc_file.exists():
        continue
    for m in re.finditer(r'public\s+ILocator\s+(\w+)\s*=>\s*CanonicalDuckCreekLocatorFactory\.ByModuleAttributeGuid\(_page,\s*"([^"]+)"\)',loc_file.read_text()):
        guid_owners.setdefault((page,m.group(2)),[]).append(m.group(1))
for (page,guid),names in guid_owners.items():
    if len(names)>1:
        guid_dups.append((page,guid,names))
req('one-page-control-per-moduleattribute-guid',not guid_dups,f'raw ModuleAttribute GUID exposed by multiple page controls: {guid_dups[:10]}')
metrics['duplicateModuleAttributeGuids']=len(guid_dups)

# generated/numeric API names
bad_loc=[]
for page,rows in props.items():
    for n,e in rows:
        if re.search(r'[0-9A-F]{5,}$',n) or re.search(r'\d$',n): bad_loc.append((page,n))
req('no-generated-or-positional-locator-suffixes',not bad_loc,f'locator names still end in generated/positional suffixes: {bad_loc[:10]}')

page_methods={}; bad_methods=[]; dup_methods=[]; missing_prop_refs=[]
for f in (ROOT/'tests/CommercialLines.DuckCreek.Tests/Pages').glob('*Page.cs'):
    page=f.stem.removesuffix('Page'); s=f.read_text()
    methods=re.findall(r'public\s+(?:async\s+)?Task(?:<[^>]+>)?\s+(\w+)\s*\(',s)
    page_methods[page]=set(methods)
    seen=set()
    for m in methods:
        if m in seen: dup_methods.append((page,m))
        seen.add(m)
        base=m[:-5] if m.endswith('Async') else m
        if re.search(r'[0-9A-F]{5,}$',base) or re.search(r'\d$',base): bad_methods.append((page,m))
    known={n for n,e in props.get(page,[])}
    for m in re.finditer(r'_locators\.(\w+)',s):
        if m.group(1) not in known: missing_prop_refs.append((page,m.group(1)))
req('no-duplicate-page-methods',not dup_methods,f'duplicate page methods remain: {dup_methods[:10]}')
req('no-generated-or-positional-page-method-suffixes',not bad_methods,f'page method names still end in generated/positional suffixes: {bad_methods[:10]}')
req('page-method-locator-refs-valid',not missing_prop_refs,f'page methods reference missing locators: {missing_prop_refs[:10]}')

# No two Page APIs should perform the same UI operation against the same canonical locator.
duplicate_action_methods=[]
for f in (ROOT/'tests/CommercialLines.DuckCreek.Tests/Pages').glob('*Page.cs'):
    by={}
    for m in re.finditer(r'public\s+Task(?:<[^>]+>)?\s+(\w+)\s*\([^)]*\)\s*=>\s*(.*?);',f.read_text(),re.S):
        hit=re.search(r'_ui\.(\w+)\s*\(\s*_locators\.(\w+)',m.group(2))
        if hit:
            by.setdefault(hit.groups(),[]).append(m.group(1))
    duplicate_action_methods += [(f.stem,op,control,names) for (op,control),names in by.items() if len(names)>1]
req('no-duplicate-page-action-methods',not duplicate_action_methods,f'duplicate Page action APIs remain: {duplicate_action_methods[:10]}')
metrics['duplicatePageActionMethods']=len(duplicate_action_methods)

# Generated pages/steps intentionally carry no migration/comment text.
comment_lines=[]
for base in [ROOT/'tests/CommercialLines.DuckCreek.Tests/Pages',ROOT/'tests/CommercialLines.DuckCreek.Tests/StepDefinitions']:
    for f in base.rglob('*.cs'):
        for i,l in enumerate(f.read_text().splitlines(),1):
            if l.lstrip().startswith('//') or l.lstrip().startswith('/*') or l.lstrip().startswith('///'):
                comment_lines.append((str(f.relative_to(ROOT)),i))
req('cldc-generated-code-no-comments',not comment_lines,f'generated CLDC page/step comments remain: {comment_lines[:10]}')

# Step -> Page API reference resolution by current local page type.
step_missing=[]; step_calls=0
for f in (ROOT/'tests/CommercialLines.DuckCreek.Tests/StepDefinitions').glob('*.cs'):
    current=None
    for i,l in enumerate(f.read_text().splitlines(),1):
        pm=re.search(r'var\s+page\s*=\s*new\s+(\w+)Page\s*\(',l)
        if pm: current=pm.group(1)
        cm=re.search(r'\bpage\.(\w+)\s*\(',l)
        if cm and current:
            step_calls+=1
            if cm.group(1) not in page_methods.get(current,set()): step_missing.append((f.name,i,current,cm.group(1)))
metrics['resolvedPageCalls']=step_calls
req('step-page-method-references-valid',not step_missing,f'StepDefinitions call missing Page methods: {step_missing[:12]}')

steps='\n'.join(f.read_text() for f in (ROOT/'tests/CommercialLines.DuckCreek.Tests/StepDefinitions').glob('*.cs'))
req('no-redundant-entity-click','ClickEntityTypeAsync' not in steps and 'ClickEntityTypeAsync' not in txt('tests/CommercialLines.DuckCreek.Tests/Pages/ClientSearchPage.cs'),'redundant EntityType click remains')
req('no-press-click',not re.search(r'Press\w*Async\("CLICK"\)',steps,re.I),'Press...(\"CLICK\") remains')
req('no-outer-product-lob-conditions',not re.search(r'data\.Condition\([^\n]*(?:Product \(LOB\)|Product:\*)',steps,re.I),'outer Product/LOB conditions remain in CLDC steps')
metrics['remainingCppLobConditions']=len(re.findall(r'data\.Condition\([^\n]*CPP LOB',steps,re.I))

# Exact adjacent duplicate actions.
adj=[]
for f in (ROOT/'tests/CommercialLines.DuckCreek.Tests/StepDefinitions').glob('*.cs'):
    lines=[x.strip() for x in f.read_text().splitlines() if x.strip()]
    for a,b in zip(lines,lines[1:]):
        if a.startswith('await page.') and a==b and not re.match(r'await page\.(?:Pause|Note)Async\(',a): adj.append((f.name,a))
req('no-adjacent-duplicate-page-actions',not adj,f'adjacent duplicate page actions remain: {adj[:10]}')

# Feature source is untouched by v58.
feat_mismatch=[]; feat_count=0
for f in (ROOT/'tests/CommercialLines.DuckCreek.Tests/Features').glob('*.feature'):
    feat_count+=1; bf=BASE/f.relative_to(ROOT)
    if not bf.exists() or f.read_bytes()!=bf.read_bytes(): feat_mismatch.append(f.name)
metrics['cldcFeatures']=feat_count
req('cldc-feature-source-identical-to-v57',feat_count==18 and not feat_mismatch,f'CLDC feature source changed: {feat_mismatch}')

# Fallback catalog must track exact final control names, no obsolete aliases, and preserve v57 isolation.
cat=json.loads(txt('Artifacts/LocatorFallbackCatalogs/CommercialLines.DuckCreek.json'))
catkeys={(c.get('page',''),c.get('control','')) for c in cat.get('controls',[])}
req('fallback-catalog-final-keys',catkeys==allprops,f'fallback catalog/control API mismatch: catalogOnly={list(catkeys-allprops)[:5]} propsOnly={list(allprops-catkeys)[:5]}')
req('fallback-catalog-v58',cat.get('version')=='v58','CLDC fallback catalog is not v58')
raw_duck=sum(1 for c in cat.get('controls',[]) for x in c.get('candidates',[]) if (x.get('strategy') or '').lower()=='duckcreekid')
fieldref=sum(1 for c in cat.get('controls',[]) for x in c.get('candidates',[]) if (x.get('strategy') or '').lower()=='fieldref')
cross=[(c.get('page'),c.get('control'),x.get('sourceFile')) for c in cat.get('controls',[]) for x in c.get('candidates',[]) if x.get('sourceFile') and not x.get('sourceFile').startswith('CL-DC')]
metrics['fieldrefFallbackCandidates']=fieldref; metrics['duckCreekIdFallbackCandidates']=raw_duck
req('cldc-no-duckcreekid-fallback',raw_duck==0,f'{raw_duck} DuckCreekId fallback candidates remain')
req('cldc-has-raw-fieldref-fallbacks',fieldref>0,'no raw fieldref fallback candidates remain')
req('cldc-fallback-app-isolated',not cross,f'cross-app CLDC fallbacks: {cross[:5]}')
addr=[c for c in cat.get('controls',[]) if c.get('page')=='ClientSearch' and c.get('control')=='Address']
req('clientsearch-address-no-cross-module-fallback',len(addr)==1 and not addr[0].get('candidates') and addr[0].get('runtimeDiscoveryRequired') is True,'ClientSearch Address still carries the wrong CM66 raw fallback')

# ClientSearch source seeds and runtime technical promotion hierarchy.
cl=txt('tests/CommercialLines.DuckCreek.Tests/Pages/Locators/ClientSearchLocators.cs')
req('clientsearch-address-semantic-seed','public ILocator Address => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address1", Exact = true });' in cl,'ClientSearch Address is not using its own semantic seed')
req('clientsearch-address-no-cm66-guid','3a13d49c-172d-b5bb-ae1c-348164b75bbb' not in cl,'ClientSearch still references CM66 Address GUID')
rr=txt('tests/CommercialLines.DuckCreek.Tests/Runtime/DuckCreekRuntimeLocatorResolver.cs')
sequence=['new LocatorRecipe("fieldref"','new LocatorRecipe("id"','new LocatorRecipe("name"','new LocatorRecipe("test-id"','new LocatorRecipe("label-associated-control"','new LocatorRecipe("aria-label"','new LocatorRecipe("link-text"']
pos=[rr.find(x) for x in sequence]
req('runtime-technical-locator-hierarchy',all(x>=0 for x in pos) and pos==sorted(pos),f'runtime locator hierarchy incorrect: {list(zip(sequence,pos))}')
for token in ['directFieldref','ancestorFieldref','data-testid','identity.Label','_cache[key] = recipe','runtime-locators.jsonl','IsUniqueVisibleAsync']:
    req('runtime-resolver-'+re.sub(r'\W+','-',token).strip('-'),token in rr,f'runtime resolver missing {token}')

# Highlight contract.
ui=txt('src/InsuranceAutomation.Core/UiActions.cs'); hi=txt('src/InsuranceAutomation.Core/InteractionHighlighter.cs'); cfg=json.loads(txt('config/framework.json'))
req('highlight-enabled-config',cfg['browser'].get('highlightInteractions') is True and 0 < int(cfg['browser'].get('highlightDurationMs',0)) <= 500,'interaction highlighting config is not enabled/bounded')
req('highlight-wired-to-ui','InteractionHighlighter.PulseAsync' in ui and 'ShouldHighlight(action)' in ui,'UiActions does not invoke temporary highlighting')
req('highlight-restores-style','outlineOffset = state.outlineOffset' in hi and 'delete el[key]' in hi,'highlighter does not restore element styles')

# Evidence must remain bound to the exact NUnit test context captured at BeforeScenario.
hook=txt('tests/CommercialLines.DuckCreek.Tests/Hooks/TestHooks.cs'); evc=txt('src/InsuranceAutomation.NUnit/NUnitTestEvidenceContext.cs'); pub=txt('src/InsuranceAutomation.NUnit/NUnitEvidencePublisher.cs'); fin=txt('src/InsuranceAutomation.NUnit/NUnitScenarioEvidenceFinalizer.cs')
for token in ['NUnitTestEvidenceContext.Capture','_scenario.Set(testEvidenceContext)','_scenario.Get<NUnitTestEvidenceContext>()']:
    req('nunit-context-'+re.sub(r'\W+','-',token).strip('-'),token in hook,f'CLDC hook missing {token}')
for token in ['TestContext.CurrentContext.Test.ID','TestContext.CurrentContext.Test.FullName','TestResults", "TestEvidence']:
    req('nunit-evidence-context-'+re.sub(r'\W+','-',token).strip('-'),token in evc,f'NUnit evidence context missing {token}')
req('evidence-close-before-publish',fin.find('await browser.CloseAsync(logger)') < fin.find('NUnitEvidencePublisher.Publish'),'evidence is published before browser/context close')
for token in ['File.Copy(sourceFile, stagedFile, true)','File.Exists(stagedFile)','File.Open(stagedFile','TestContext.AddTestAttachment(stagedFile','runtime-locators.jsonl','sameTestContext']:
    req('evidence-'+re.sub(r'\W+','-',token).strip('-'),token in pub,f'evidence publisher missing {token}')
req('direct-nunit-attachment','NUnitEvidenceAttachment.AddTestAttachment' not in pub and 'TestContext.AddTestAttachment(stagedFile' in pub,'publisher still routes through detached/sample attachment wrapper')

all_hooks=[]
for hp in sorted((ROOT/'tests').glob('*/Hooks/TestHooks.cs')):
    hs=hp.read_text()
    all_hooks.append((str(hp.relative_to(ROOT)), 'NUnitTestEvidenceContext.Capture' in hs and '_scenario.Set(testEvidenceContext)' in hs and '_scenario.Get<NUnitTestEvidenceContext>()' in hs))
req('all-apps-capture-exact-nunit-test-context',len(all_hooks)==3 and all(ok for _,ok in all_hooks),f'one or more application hooks do not preserve exact NUnit scenario/test identity: {all_hooks}')
metrics['applicationHooksWithExactNUnitEvidenceContext']=sum(1 for _,ok in all_hooks if ok)

# Existing dropdown runtime and v57 console/HAR contract remain.
comp=txt('src/InsuranceAutomation.Core/ComponentAwareControlActions.cs')
for token in ['exactMatches =','PartialScore','CanCommitWithEnterAsync','EvaluateAllAsync<OptionSnapshot[]>']:
    req('dropdown-'+re.sub(r'\W+','-',token).strip('-'),token in comp,f'dropdown algorithm missing {token}')
req('dropdown-no-tab','PressAsync("Tab")' not in comp and 'PressAsync("TAB")' not in comp,'dropdown component navigation still uses Tab')
req('dropdown-fast-timeout',0 < cfg['waits']['dropdownOptionTimeoutMs'] <= 1500,'dropdown option timeout exceeds v57 fast bound')
req('har-disabled',cfg['browser'].get('har') is False,'HAR is enabled')
req('console-network-disabled',cfg['reporting'].get('includeConsoleErrors') is False and cfg['reporting'].get('includeNetworkErrors') is False,'console/network collection is enabled')

# Login remains v57 contract.
login=txt('tests/CommercialLines.DuckCreek.Tests/Pages/Locators/LoginLocators.cs')
req('cldc-login-raw-ids','username-inputEl' in login and 'password-inputEl' in login,'CLDC login raw ids changed')
req('cldc-login-link','AriaRole.Link' in login and 'Name = "Login"' in login,'CLDC login link semantics changed')

# Lightweight C# lexical structure and config integrity.
def scrub_csharp(t):
    t=re.sub(r'//.*?$|/\*.*?\*/','',t,flags=re.M|re.S)
    t=re.sub(r'@"(?:""|[^"])*"|""".*?"""|"(?:\\.|[^"\\])*"|\'(?:\\.|[^\'\\])\'','',t,flags=re.S)
    return t
brace=[]
# Validate files changed by v58. Untouched v57 files can contain raw/interpolated literals that the lightweight scrubber cannot parse safely.
for f in ROOT.rglob('*.cs'):
    bf=BASE/f.relative_to(ROOT)
    changed=(not bf.exists()) or f.read_bytes()!=bf.read_bytes()
    if not changed:
        continue
    t=scrub_csharp(f.read_text(errors='ignore'))
    if t.count('{')!=t.count('}'):
        brace.append((str(f.relative_to(ROOT)),t.count('{'),t.count('}')))
req('csharp-brace-balance',not brace,f'C# brace mismatches in v58-changed files: {brace[:10]}')
for f in ROOT.rglob('*.json'):
    try: json.loads(f.read_text())
    except Exception as e: errors.append(f'JSON parse {f.relative_to(ROOT)}: {e}')
for f in list(ROOT.rglob('*.csproj'))+list(ROOT.rglob('*.runsettings')):
    try: ET.parse(f)
    except Exception as e: errors.append(f'XML parse {f.relative_to(ROOT)}: {e}')
for f in (ROOT/'tools').glob('*.py'):
    try: compile(f.read_text(),str(f),'exec')
    except Exception as e: errors.append(f'Python syntax {f.name}: {e}')

# Quantify duplicate reduction from actual v57/v58 generated API, not the older report regex.
def count_base_props(base):
    n=0
    for f in (base/'tests/CommercialLines.DuckCreek.Tests/Pages/Locators').glob('*Locators.cs'):
        if f.name=='CanonicalDuckCreekLocatorFactory.cs': continue
        n+=len(re.findall(r'public\s+ILocator\s+\w+\s*=>',f.read_text()))
    return n
metrics['v57LocatorProperties']=count_base_props(BASE)
metrics['v58LocatorProperties']=count_base_props(ROOT)
metrics['locatorPropertiesRemoved']=metrics['v57LocatorProperties']-metrics['v58LocatorProperties']
metrics['cldcPageMethods']=sum(len(x) for x in page_methods.values())
metrics['generatedCommentLines']=len(comment_lines)

report={
 'release':'v58-fieldref-canonical-runtime-evidence',
 'status':'PASS' if not errors else 'FAIL',
 'metrics':metrics,
 'checks':checks,
 'errors':errors,
 'warnings':warnings,
 'dotnetBuildPerformed':False,
 'dotnetBuildStatus':'NOT_RUN_SDK_UNAVAILABLE',
 'dotnetBuildReason':'dotnet/csc/mcs are not installed in this packaging environment; clean Azure DevOps/Visual Studio .NET 8 build and representative CLDC runtime execution remain mandatory.'
}
out=ROOT/'Artifacts/V58ReleaseValidation.json'; out.write_text(json.dumps(report,indent=2)+'\n')
print(json.dumps(report,indent=2))
sys.exit(0 if not errors else 1)
