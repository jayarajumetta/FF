#!/usr/bin/env python3
from pathlib import Path
import hashlib,json,re,sys,xml.etree.ElementTree as ET
ROOT=Path(__file__).resolve().parents[1]
errors=[]; warnings=[]; checks={}
def req(name, ok, msg):
    checks[name]=bool(ok)
    if not ok: errors.append(msg)
def text(rel): return (ROOT/rel).read_text(encoding='utf-8',errors='ignore')
def sha(rel): return hashlib.sha256((ROOT/rel).read_bytes()).hexdigest()

# Raw source contract / scope.
rc=json.loads(text('Artifacts/V54RawToscaContract.json'))
req('raw-contract-pass',rc.get('status')=='PASS','v54 raw Tosca contract is not PASS')
req('features-32',rc.get('features')==32,'feature count is not 32')
req('examples-1074',rc.get('examples')==1074 and rc.get('rawConcreteExamplesMatched')==1074,'raw concrete example match is not 1074/1074')

# Application-isolated fallback catalogs and v57 CLDC hierarchy.
prefix={'CommercialLines.ExpertQuote':'CL_EQ','CommercialLines.DuckCreek':'CL-DC','PersonalLines.DuckCreek':'PL_DC'}
fc={}; cross={}; duck={}; fieldref={}
for app,pre in prefix.items():
    d=json.loads(text(f'Artifacts/LocatorFallbackCatalogs/{app}.json'))
    req(f'{app}-catalog-v57',d.get('version')=='57.0',f'{app} fallback catalog is not version 57.0')
    cross[app]=[]; duck[app]=0; fieldref[app]=0; fc[app]=0
    for ctl in d.get('controls',[]):
        for c in ctl.get('candidates',[]):
            sf=c.get('sourceFile','')
            if sf and not sf.startswith(pre): cross[app].append((ctl.get('page'),ctl.get('control'),sf))
            if (c.get('strategy') or '').lower()=='duckcreekid': duck[app]+=1
            if (c.get('strategy') or '').lower()=='fieldref': fieldref[app]+=1
            if c.get('frameValue'): fc[app]+=1
    req(f'{app}-isolation',len(cross[app])==0,f'{app} fallback has {len(cross[app])} cross-application candidates')
req('cldc-no-duckcreekid-fallback',duck['CommercialLines.DuckCreek']==0,f'CL|DC fallback contains {duck["CommercialLines.DuckCreek"]} DuckCreekId candidates')
req('cldc-fieldref-fallback',fieldref['CommercialLines.DuckCreek']>0,'CL|DC has no unique-fieldref fallback candidates')
req('cldc-frame-candidates',fc['CommercialLines.DuckCreek']>0,'CL|DC has no raw frame hint candidates')

cl_catalog=json.loads(text('Artifacts/LocatorFallbackCatalogs/CommercialLines.DuckCreek.json'))
expected_ok_guids={'RiskAccountsReceivableOK':'3a13d49c-172d-87fd-649f-1d8b0fc57589','RiskBaileesCustomersOK':'3a13d49c-172d-73c0-91ea-b7991fa97b13'}
for ctl,expected_guid in expected_ok_guids.items():
    rows=[x for x in cl_catalog.get('controls',[]) if x.get('control')==ctl]
    req(f'cldc-{ctl}-fallback-physical-guid',bool(rows) and all(x.get('moduleAttributeGuid')==expected_guid for x in rows),f'{ctl} fallback is not bound to the physical raw OK GUID')
    req(f'cldc-{ctl}-fallback-link',bool(rows) and all(any(c.get('strategy')=='role' and c.get('role')=='link' and c.get('value')=='OK' for c in x.get('candidates',[])) or bool(x.get('aliasOf')) for x in rows),f'{ctl} fallback does not preserve raw <a> link semantics')

cl_locator_dir=ROOT/'tests/CommercialLines.DuckCreek.Tests/Pages/Locators'
clloc='\n'.join(p.read_text(errors='ignore') for p in cl_locator_dir.glob('*.cs'))
req('cldc-no-duckcreekid-primary',not re.search(r'duckcreekid|duck-creek-id',clloc,re.I),'CL|DC primary locator code still contains DuckCreekId')
req('cldc-label-associated','ByAssociatedLabel' in clloc,'CL|DC has no associated-label locator use')


# Cross-check generated CL|DC primary expressions directly against raw Tosca ModuleAttribute semantics.
raw_catalog=json.loads(text('Artifacts/ToscaLocatorPropertyCatalog.v54.raw.json'))
raw_cldc=[r for r in raw_catalog if (r.get('sourceFile') or '').startswith('CL-DC')]
raw_by_guid={}
fieldref_guid_sets={}
for r in raw_cldc:
    guid=(r.get('moduleAttributeGuid') or '').lower()
    if guid: raw_by_guid[guid]=r
    props=r.get('properties') or {}
    fref=props.get('attributes_fieldref') or props.get('fieldref') or props.get('FieldRef')
    if fref and guid: fieldref_guid_sets.setdefault(fref,set()).add(guid)
factory_for_audit=text('tests/CommercialLines.DuckCreek.Tests/Pages/Locators/CanonicalDuckCreekLocatorFactory.cs')
factory_expr={m.group(1).lower():m.group(2).strip() for m in re.finditer(r'^\s*"([0-9a-f-]{36})"\s*=>\s*(.*?),\s*//',factory_for_audit,re.M|re.I)}
raw_generated=[]
for p in cl_locator_dir.glob('*.cs'):
    if p.name=='CanonicalDuckCreekLocatorFactory.cs': continue
    lines=p.read_text(encoding='utf-8',errors='ignore').splitlines()
    for i,line in enumerate(lines):
        m=re.search(r'guid=([0-9a-f-]{36})\s*\|',line,re.I)
        if not m: continue
        guid=m.group(1).lower(); expr=''
        for j in range(i+1,min(i+8,len(lines))):
            if 'public ILocator ' not in lines[j]: continue
            expr=lines[j].strip()
            k=j
            while ';' not in expr and k+1<len(lines):
                k+=1; expr+=' '+lines[k].strip()
            break
        if 'CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid' in expr:
            expr=factory_expr.get(guid,expr)
        raw_generated.append((str(p.relative_to(ROOT)),i+1,guid,expr))
raw_tag_a_button=[]; raw_form_getbytext=[]; raw_form_getbylabel=[]; raw_undefined_id=[]; raw_unique_fieldref_not_primary=[]; raw_unique_fieldref_guids=set()
form_business_types={'textbox','combobox','editablecombobox','checkbox','radiobutton'}
for rel,line,guid,expr in raw_generated:
    raw=raw_by_guid.get(guid)
    if not raw: continue
    props=raw.get('properties') or {}; tag=(props.get('Tag') or '').upper(); business=(raw.get('businessType') or '').lower()
    if tag=='A' and 'AriaRole.Button' in expr: raw_tag_a_button.append((rel,line,guid,raw.get('field')))
    is_form=tag in {'INPUT','SELECT','TEXTAREA'} or business in form_business_types
    if is_form and 'GetByText(' in expr: raw_form_getbytext.append((rel,line,guid,raw.get('field')))
    if is_form and 'GetByLabel(' in expr: raw_form_getbylabel.append((rel,line,guid,raw.get('field')))
    if re.search(r'\[id=\\?"undefined|\bid\s*=\s*["\']?undefined',expr,re.I): raw_undefined_id.append((rel,line,guid,raw.get('field')))
    fref=props.get('attributes_fieldref') or props.get('fieldref') or props.get('FieldRef')
    if fref and len(fieldref_guid_sets.get(fref,set()))==1:
        raw_unique_fieldref_guids.add(guid)
        if f'fieldref=\\"{fref}\\"' not in expr and f'fieldref="{fref}"' not in expr:
            raw_unique_fieldref_not_primary.append((rel,line,guid,raw.get('field'),fref))
req('cldc-raw-tag-a-never-button',not raw_tag_a_button,f'{len(raw_tag_a_button)} raw Tag=A controls are emitted as buttons: {raw_tag_a_button[:5]}')
req('cldc-raw-form-never-getbytext',not raw_form_getbytext,f'{len(raw_form_getbytext)} raw form controls use GetByText: {raw_form_getbytext[:5]}')
req('cldc-raw-form-never-direct-getbylabel',not raw_form_getbylabel,f'{len(raw_form_getbylabel)} raw form controls use direct GetByLabel instead of associated-control resolution: {raw_form_getbylabel[:5]}')
req('cldc-no-undefined-html-id',not raw_undefined_id,f'{len(raw_undefined_id)} raw-backed CL|DC primary locators contain undefined ids: {raw_undefined_id[:5]}')
req('cldc-all-generated-unique-fieldrefs-primary',not raw_unique_fieldref_not_primary,f'{len(raw_unique_fieldref_not_primary)} generated controls with unique raw fieldref do not use fieldref as primary: {raw_unique_fieldref_not_primary[:5]}')
req('cldc-unique-fieldref-guid-count-51',len(raw_unique_fieldref_guids)==51,f'Expected 51 generated unique-fieldref physical controls; found {len(raw_unique_fieldref_guids)}')

# Global raw field/tag contract: any remaining generated Button name that exists in raw CL|DC must not contradict Tag=A.
remaining_button_raw_conflicts=[]
for p in cl_locator_dir.glob('*.cs'):
    if p.name=='CanonicalDuckCreekLocatorFactory.cs': continue
    for line_no,line in enumerate(p.read_text(encoding='utf-8',errors='ignore').splitlines(),1):
        m=re.search(r'GetByRole\(AriaRole\.Button, new\(\) \{ Name = "([^"]+)"',line)
        if not m: continue
        target=re.sub(r'\s+',' ',m.group(1).strip()).rstrip('*').strip().casefold()
        matches=[r for r in raw_cldc if re.sub(r'\s+',' ',(r.get('field') or '').strip()).rstrip('*').strip().casefold()==target]
        tags={((r.get('properties') or {}).get('Tag') or '').upper() for r in matches}
        if matches and tags=={'A'}: remaining_button_raw_conflicts.append((str(p.relative_to(ROOT)),line_no,m.group(1),len(matches)))
req('cldc-no-button-role-when-raw-field-tag-a',not remaining_button_raw_conflicts,f'Generated Button role remains despite unanimous raw Tag=A evidence: {remaining_button_raw_conflicts[:5]}')
semcorr=json.loads(text('Artifacts/V57RawTagSemanticCorrections.json'))
req('cldc-raw-tag-semantic-correction-pass',semcorr.get('status')=='PASS','raw tag semantic correction audit is not PASS')
req('cldc-raw-tag-a-links-corrected',sum(1 for c in semcorr.get('changes',[]) if c.get('kind')=='raw-tag-A-link')>=45,'expected raw Tag=A link corrections are missing')
req('cldc-ok-physical-guid-remaps',sum(1 for c in semcorr.get('changes',[]) if c.get('kind')=='physical-guid-remap')>=4,'the two reused CL|DC OK controls were not remapped across both page repositories')

# Login contracts.
cllogin=text('tests/CommercialLines.DuckCreek.Tests/Pages/Locators/LoginLocators.cs')
for token in ['[id=\\"username-inputEl\\"]','[id=\\"password-inputEl\\"]','AriaRole.Link','Name = "Login"']:
    req('cl-login-'+re.sub(r'\W+','-',token).strip('-'),token in cllogin,f'CL|DC login missing {token}')
protected=json.loads(text('Artifacts/V57ProtectedBaselineHashes.json'))
for rel,info in protected['files'].items(): req('protected-'+Path(rel).name,sha(rel)==info['v56Sha256'],f'Protected v56 file changed: {rel}')
pllogin=text('tests/PersonalLines.DuckCreek.Tests/Pages/Locators/LoginLocators.cs')
for token in ['a[id=\\"signInBtn\\"]','[id=\\"username\\"]','[id=\\"password\\"]']:
    req('pl-login-'+re.sub(r'\W+','-',token).strip('-'),token in pllogin,f'PL|DC raw-supported login locator missing {token}')

# Raw tag A must not be emitted as Button for reviewed/generated v57 CL locator metadata.
req('cldc-login-link-not-button','AriaRole.Button' not in '\n'.join(x for x in cllogin.splitlines() if 'Login =>' in x),'CL|DC Login is still emitted as button')
promo=json.loads(text('Artifacts/V57PrimaryLocatorPromotion.json'))
req('primary-promotion-report',promo.get('resolvedRawIdentity',0)>0,'v57 raw primary promotion report is empty')
canon=json.loads(text('Artifacts/V57CanonicalLocatorReuse.json'))
factory=text('tests/CommercialLines.DuckCreek.Tests/Pages/Locators/CanonicalDuckCreekLocatorFactory.cs')
guids=re.findall(r'^\s*"([0-9a-f-]{36})"\s*=>',factory,re.M|re.I)
req('canonical-factory-count',len(guids)==canon.get('canonicalFactoryEntries')==canon.get('repeatedPhysicalGuids'),'canonical factory count does not match repeated physical GUID audit')
req('canonical-factory-unique',len(guids)==len(set(g.lower() for g in guids)),'canonical factory defines a repeated Tosca GUID more than once')
req('canonical-reuse-references',factory.count('=>')-1>=canon.get('canonicalFactoryEntries',0),'canonical factory entries are incomplete')
req('canonical-no-missing-factory-guids',not canon.get('missingFactoryGuids'),'repeated physical Tosca GUIDs are missing from canonical factory')
req('canonical-no-extra-factory-guids',not canon.get('extraFactoryGuids'),'canonical factory contains GUIDs that are not physically repeated')
req('canonical-all-repeated-refs-use-factory',not canon.get('repeatedReferencesNotUsingFactory'),'a repeated physical Tosca ModuleAttribute is defined outside the canonical factory')

# Frame contract: hint -> brief probe -> document fallback -> cache successful Page.Control scope.
lr=text('src/InsuranceAutomation.Core/LocatorResolution.cs'); fb=text('src/InsuranceAutomation.Core/DeterministicLocatorFallbackResolver.cs'); ui=text('src/InsuranceAutomation.Core/UiActions.cs')
req('build-top-document','public static ILocator Build(IPage page' in lr and 'FrameLocator' not in lr[lr.index('public static ILocator Build(IPage page'):lr.index('public static ILocator BuildInFrame')],'LocatorResolution.Build unexpectedly forces a frame')
for token in ['BuildInFrame','FrameExistsAsync','TryExecuteFrameHintFirstAsync','SuccessfulScopeCache','ScopeKey(ControlIntent intent)','yield return ScopeKind.Frame;\n        yield return ScopeKind.Document']:
    req('frame-'+re.sub(r'\W+','-',token).strip('-'),token in lr+fb,f'frame runtime contract missing {token}')
req('scope-cache-not-action','private string ScopeKey(ControlIntent intent)' in fb and '|{action}' not in fb[fb.index('private string ScopeKey'):fb.index('private static bool IsRecoverable')],'successful frame/document scope cache is still action-specific')
req('frame-probe-deduped-per-action','FrameExistsOncePerActionAsync' in fb and fb.count('new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase)') >= 4 and fb.count('FrameExistsOncePerActionAsync(candidate, frameProbe)') >= 4,'a frame-capable action path can repeat the same absent-frame probe for multiple candidates')

# Dropdown contract and timing.
comp=text('src/InsuranceAutomation.Core/ComponentAwareControlActions.cs'); cfg=json.loads(text('config/framework.json'))
for token in ['TrySelectNativeAsync','ChooseOptionIndex','PartialScore','EvaluateAllAsync<OptionSnapshot[]>','CanCommitWithEnterAsync','aria-controls','aria-owns']:
    req('dropdown-'+re.sub(r'\W+','-',token).strip('-'),token in comp,f'dropdown semantic kernel missing {token}')
req('dropdown-no-tab','PressAsync("Tab")' not in comp and 'PressAsync("TAB")' not in comp,'dropdown component kernel uses Tab')
req('dropdown-exact-before-partial',comp.index('exactMatches =') < comp.index('var ranked ='),'dropdown option matching does not evaluate exact match before partial ranking')
req('dropdown-browser-js-valid','((HTMLElement)' not in comp,'dropdown/control browser-evaluated JavaScript contains a TypeScript-only HTMLElement cast')
req('dropdown-fast-timeout',0 < cfg['waits']['dropdownOptionTimeoutMs'] <= 1500,f'dropdown option timeout is not bounded <=1500ms: {cfg["waits"].get("dropdownOptionTimeoutMs")}')
req('dropdown-fast-poll',25 <= cfg['waits']['dropdownPollIntervalMs'] <= 100,f'dropdown poll interval not in 25..100ms: {cfg["waits"].get("dropdownPollIntervalMs")}')
req('frame-probe-fast',0 < cfg['waits']['frameProbeTimeoutMs'] <= 1000,f'frame probe is not brief <=1000ms: {cfg["waits"].get("frameProbeTimeoutMs")}')

# Keyboard and duplicate state actions.
steps=list(ROOT.glob('tests/*/StepDefinitions/*.cs')); allsteps='\n'.join(p.read_text(errors='ignore') for p in steps)
req('no-press-click',not re.search(r'Press[A-Za-z0-9_]*Async\("CLICK"\)|\.PressAsync\("CLICK"\)',allsteps+ui),'PressAsync("CLICK") / generated Press...("CLICK") remains')
# Feature source baseline: v57 runtime hardening must not mutate the v56 Gherkin files.
feature_base=json.loads(text('Artifacts/V57FeatureBaselineHashes.json')); feature_mism=[]
for rel,info in feature_base.get('files',{}).items():
    p=ROOT/rel
    if not p.exists() or hashlib.sha256(p.read_bytes()).hexdigest()!=info.get('v56Sha256'): feature_mism.append(rel)
req('feature-source-v56-exact',not feature_mism and len(feature_base.get('files',{}))==32,f'feature source changed from v56 in {len(feature_mism)} files: {feature_mism[:5]}')

# source sequence baseline for conditions
base=json.loads(text('Artifacts/V57ConditionSourceOrderBaseline.json')); mism=[]
cond_re=re.compile(r'data\.Condition\((?:[^"\\]|\\.|"(?:\\.|[^"\\])*")*?\)')
for rel,info in base['files'].items():
    conds=[m.group(0) for m in cond_re.finditer(text(rel))]
    seq=hashlib.sha256('\n'.join(conds).encode()).hexdigest()
    if len(conds)!=info['count'] or seq!=info['sequenceSha256']: mism.append(rel)
req('condition-source-order',not mism,f'condition expression/order changed in {len(mism)} files: {mism[:5]}')
dups=[]
for p in steps:
    lines=p.read_text(errors='ignore').splitlines()
    for i,line in enumerate(lines):
        s=line.strip()
        if not s.startswith('await ') or 'PauseAsync' in s or 'NoteAsync' in s: continue
        j=i+1
        while j<len(lines) and (not lines[j].strip() or lines[j].lstrip().startswith('//')): j+=1
        if j<len(lines) and lines[j].strip()==s: dups.append((str(p.relative_to(ROOT)),i+1,s))
req('no-adjacent-duplicate-state-actions',not dups,f'{len(dups)} exact adjacent duplicate state actions remain')

# Page consistency.
pagefiles=[p for p in ROOT.glob('tests/*/Pages/*.cs')]
bad_page=[]
for p in pagefiles:
    t=p.read_text(errors='ignore')
    # Ignore comments; page instance access should use _page where an IPage is owned directly.
    stripped=re.sub(r'//.*?$|/\*.*?\*/','',t,flags=re.M|re.S)
    if re.search(r'(?<![_A-Za-z0-9])page\.',stripped): bad_page.append(str(p.relative_to(ROOT)))
req('page-consistent-_page',not bad_page,f'Page classes still use bare page.: {bad_page[:8]}')
req('locator-no-Page-dot',not re.search(r'=>\s*Page\.',clloc),'CL|DC locator repositories use Page. rather than _page')

# Evidence: real files, after close/finalization, copied/read-checked before NUnit registration.
bs=text('src/InsuranceAutomation.Core/BrowserSession.cs'); ep=text('src/InsuranceAutomation.NUnit/NUnitEvidencePublisher.cs'); ea=text('src/InsuranceAutomation.NUnit/NUnitEvidenceAttachment.cs'); ef=text('src/InsuranceAutomation.NUnit/NUnitScenarioEvidenceFinalizer.cs')
req('har-config-disabled',cfg['browser'].get('har') is False,'framework.json HAR is enabled')
req('console-disabled',cfg['reporting'].get('includeConsoleErrors') is False and cfg['reporting'].get('includeNetworkErrors') is False,'console/network error collection flags are enabled')
req('har-runtime-disabled','const bool harCollectionEnabledV57 = false' in bs,'HAR runtime disable guard missing')
req('wire-evidence-not-invoked',not re.search(r'^\s*WireEvidence\(',bs,re.M),'WireEvidence is actively invoked')
req('wire-evidence-retained','private void WireEvidence' in bs,'console/network implementation was removed instead of disabled')
req('close-before-video-path',bs.index('await _context.CloseAsync()') < bs.index('await video.PathAsync()'),'video path is resolved before context close')
req('close-before-publish',ef.index('await browser.CloseAsync(logger)') < ef.index('NUnitEvidencePublisher.Publish'),'NUnit evidence publishes before Playwright context close')
for token in ['"report.html", "execution.log"','required-finalized-evidence-missing::screenshot','required-finalized-evidence-missing::video','File.Copy(sourceFile, stagedFile, true)','File.Exists(stagedFile)','File.Open(stagedFile','NUnitEvidenceAttachment.AddTestAttachment(stagedFile']:
    req('evidence-'+re.sub(r'\W+','-',token).strip('-'),token in ep,f'evidence publisher missing {token}')
req('attachment-read-before-register',ea.index('File.Open(staged') < ea.index('TestContext.AddTestAttachment'),'NUnitEvidenceAttachment registers before readability check')
req('no-dummy-marker','RegisterStartMarker' not in '\n'.join(p.read_text(errors='ignore') for p in ROOT.rglob('*.cs')),'dummy/sample marker attachment code remains')

# JSON/XML integrity and lightweight C# structure validation.
for p in ROOT.rglob('*.json'):
    try: json.loads(p.read_text(encoding='utf-8'))
    except Exception as e: errors.append(f'JSON parse {p.relative_to(ROOT)}: {e}')
for p in list(ROOT.rglob('*.csproj'))+list(ROOT.rglob('*.runsettings')):
    try: ET.parse(p)
    except Exception as e: errors.append(f'XML parse {p.relative_to(ROOT)}: {e}')
cs=list(ROOT.rglob('*.cs')); strpat=re.compile(r'@?"(?:""|\\.|[^"\\])*"|\'(?:\\.|[^\'\\])\'|//.*?$|/\*.*?\*/',re.S|re.M)
for p in cs:
    t=strpat.sub('',p.read_text(errors='ignore'))
    if t.count('{')!=t.count('}'): errors.append(f'C# brace mismatch {p.relative_to(ROOT)}')

# Python utility syntax.
try:
    for p in ROOT.glob('tools/*.py'):
        compile(p.read_text(encoding='utf-8'), str(p), 'exec')
except Exception as e: errors.append(f'Python utility compile: {e}')

report={
 'release':'v57-runtime-contract-hardening','status':'PASS' if not errors else 'FAIL','rawSourceTruth':'RAW_TOSCA_ONLY',
 'features':rc.get('features'),'examples':rc.get('examples'),'rawConcreteExamplesMatched':rc.get('rawConcreteExamplesMatched'),
 'conditionBaselineFiles':base.get('totalFiles'),'conditionBaselineExpressions':base.get('totalConditions'),
 'cldcUniqueFieldrefFallbackCandidates':fieldref['CommercialLines.DuckCreek'],'cldcGeneratedUniqueFieldrefPhysicalControls':len(raw_unique_fieldref_guids),'cldcDuckCreekIdFallbackCandidates':duck['CommercialLines.DuckCreek'],
 'frameAwareFallbackCandidates':fc,'canonicalReuse':canon,'waits':cfg.get('waits',{}),'checks':checks,
 'csharpFiles':len(cs),'errors':errors,'warnings':warnings,
 'dotnetBuildPerformed':False,'dotnetBuildStatus':'NOT_RUN_SDK_UNAVAILABLE','dotnetBuildReason':'dotnet/csc/msbuild are unavailable in the packaging environment. Official .NET 8 SDK binary retrieval was attempted but container download/network resolution was unavailable; Azure/Visual Studio dotnet build remains the mandatory compiler/runtime gate.'
}
out=ROOT/'Artifacts/V57ReleaseValidation.json'; out.write_text(json.dumps(report,indent=2)+'\n')
print(json.dumps(report,indent=2)); sys.exit(0 if not errors else 1)
