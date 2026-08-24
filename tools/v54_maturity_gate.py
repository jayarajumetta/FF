#!/usr/bin/env python3
import json,re,sys,glob
from pathlib import Path
ROOT=Path(sys.argv[1] if len(sys.argv)>1 else '.').resolve()
errors=[]; warnings=[]

def require(cond,msg):
 if not cond: errors.append(msg)

def text(p):return (ROOT/p).read_text(encoding='utf-8',errors='ignore')
# Raw contract must be raw-only and complete.
rc=json.loads(text('Artifacts/V54RawToscaContract.json'))
require(rc.get('status')=='PASS','V54 raw Tosca contract is not PASS')
require(rc.get('sourceTruth')=='RAW_TOSCA_ONLY','Source truth is not RAW_TOSCA_ONLY')
require(rc.get('manualCsvXlsxHtmlUsed') is False,'Manual artifacts are marked as generation inputs')
require(rc.get('features')==32,'Expected 32 raw-validated Features')
require(rc.get('examples')==1074 and rc.get('rawConcreteExamplesMatched')==1074,'Expected 1074/1074 raw concrete examples matched')
# All Features advertise raw source and manual-artifact exclusion.
features=list(ROOT.glob('tests/*/Features/*.feature'))
for p in features:
 s=p.read_text(encoding='utf-8')
 require('v54 RAW TOSCA SOURCE:' in s,f'{p}: missing raw source header')
 require('manual CSV/XLSX/HTML are NOT generation or ordering inputs' in s,f'{p}: missing raw-only authority marker')
# CLDC authentication cleanup from raw graph.
for f in (ROOT/'tests/CommercialLines.DuckCreek.Tests/Features').glob('*.feature'):
 s=f.read_text(encoding='utf-8')
 require(s.count('I sign in to Commercial Lines Duck Creek using configured credentials')==1,f'{f.name}: initial sign-in must appear exactly once')
 for leaked in ['I complete restart Edge Popup','I sign in to Duck Creek for logged in user','I sign in to Duck Creek for username']:
  require(leaked not in s,f'{f.name}: reusable login internal leaked: {leaked}')
# Core waits / verify / failure behavior.
ui=text('src/InsuranceAutomation.Core/UiActions.cs')
for token in ['PrepareForActionAsync','WaitForPageReadyBestEffortAsync','VerifyTimeoutMs','ElementReadyTimeoutMs','DEFERRED VERIFY FAILURE','ShouldDeferVerification','DeterministicLocatorFallbackResolver']:
 require(token in ui,f'UiActions missing v54 wait/verify token: {token}')
resolver=text('src/InsuranceAutomation.Core/DeterministicLocatorFallbackResolver.cs')
require('FallbackCandidateTimeoutMs' in resolver,'Fallback resolver missing bounded candidate wait')
require('CountAsync() == 0' not in ui[ui.find('public async Task VerifyAsync'):ui.find('public Task<string> CaptureAsync')], 'VerifyAsync contains premature CountAsync()==0 check')
require('post-action DOM extraction/consolidation' in ui and 'CaptureDomAfterActions' not in ui[ui.find('private async Task ExecuteAsync'):], 'Post-action DOM capture appears active')
# Fallback maturity / typed sidecars.
fc=json.loads(text('Artifacts/LocatorFallbackCatalogs/LocatorFallbackCoverage.json'))
for app,v in fc.get('applications',{}).items(): require(v.get('canonicalFallbackCoverage',0)>=0.95,f'{app}: fallback maturity below 95%')
require(fc.get('overallCanonicalFallbackCoverage',0)>=0.95,'Overall fallback maturity below 95%')
fb=list(ROOT.glob('tests/*/Pages/FallbackLocators/*.cs'))
require(len(fb)>=54,f'Expected >=54 typed fallback/provider files, found {len(fb)}')
for hook in ROOT.glob('tests/*/Hooks/TestHooks.cs'):
 s=hook.read_text(encoding='utf-8')
 require('fallbackProvider' in s and 'new UiActions' in s,f'{hook}: application fallback provider not injected')
# Evidence / VS Test Explorer integration.
pub=text('src/InsuranceAutomation.NUnit/NUnitEvidencePublisher.cs'); fin=text('src/InsuranceAutomation.NUnit/NUnitScenarioEvidenceFinalizer.cs')
for token in ['TestContext.CurrentContext.WorkDirectory','TestContext.AddTestAttachment','RegisterStartMarker','File.Copy']:
 require(token in pub,f'NUnit evidence publisher missing: {token}')
for token in ['CaptureScreenshotAsync("scenario-final.png")','await browser.CloseAsync(logger)','NUnitEvidencePublisher.Publish','Assert.Fail']:
 require(token in fin,f'Evidence finalizer missing: {token}')
runsettings=text('Tosca.runsettings'); props=text('Directory.Build.props')
require('<WorkDirectory>TestResults\\NUnitWork</WorkDirectory>' in runsettings,'NUnit WorkDirectory missing from Tosca.runsettings')
require('RunSettingsFilePath' in props,'Visual Studio RunSettingsFilePath is not wired')
# Browser evidence capture.
br=text('src/InsuranceAutomation.Core/BrowserSession.cs')
for token in ['RecordHarPath','RecordVideoDir','Tracing.StartAsync','page.Console','page.Request','page.Response','page.RequestFailed','console.log','network.log']:
 require(token in br,f'BrowserSession missing evidence capability: {token}')
# HTML reporting.
rp=text('src/InsuranceAutomation.Core/ScenarioReport.cs')
for token in ['Locator fallback trace','Deferred verification results','Console/Page errors','Network errors','evidence bundle']:
 require(token in rp,f'HTML report missing: {token}')
# EQ raw account/address order regression guard across all EQ scenario StepDefinitions.
for p in (ROOT/'tests/CommercialLines.ExpertQuote.Tests/StepDefinitions').glob('*.cs'):
 s=p.read_text(encoding='utf-8')
 if 'VerifyMapAsync' not in s: continue
 pos=[s.find(x) for x in ['EnterStreetAddressAsync','EnterCityAsync','SelectStateAsync','EnterZipAsync','VerifyMapAsync','VerifySatelliteAsync']]
 if all(x>=0 for x in pos): require(pos==sorted(pos),f'{p.name}: address/map/satellite order regressed')
# JSON integrity + raw lineage on all scenario data.
json_count=0; scenario_count=0
for p in ROOT.rglob('*.json'):
 try:d=json.loads(p.read_text(encoding='utf-8'))
 except Exception as e: errors.append(f'JSON parse error {p}: {e}');continue
 json_count+=1
 if '/TestData/Scenarios/' in str(p).replace('\\','/'):
  scenario_count+=1; require(d.get('_meta',{}).get('sourceTruth')=='RAW_TOSCA',f'{p}: scenario data not marked RAW_TOSCA'); require(d.get('_rawTosca',{}).get('concreteTestCaseGuid'),f'{p}: missing raw concrete Tosca GUID')
require(scenario_count==1074,f'Expected 1074 scenario JSON files, found {scenario_count}')
# C# source sanity. A real compiler is intentionally delegated to the build pipeline; here we
# reject known generation defects without trying to parse modern C# raw/interpolated string syntax.
cs_files=list(ROOT.rglob('*.cs'))
for p in cs_files:
 s=p.read_text(encoding='utf-8',errors='ignore')
 require('\u0000' not in s,f'{p}: NUL character in C# source')
 require('<<<<<<<' not in s and '>>>>>>>' not in s,f'{p}: merge-conflict marker in C# source')
 require('NotImplementedException' not in s,f'{p}: NotImplementedException remains in generated test source')
# ADO contracts retained.
build=text('.azuredevops/build-test-artifact.yml'); exe=text('.azuredevops/execute-test-artifact.yml')
for token in ['dotnet restore','dotnet build','PublishPipelineArtifact@1']:
 require(token in build,f'Build pipeline missing: {token}')
for stage in ['AllCases','SingleTestPlanCase','TestSuite']:
 require(re.search(rf'-\s*stage:\s*{stage}\b',exe) is not None,f'Execution pipeline missing stage {stage}')
require('dotnet build' not in exe,'Execution pipeline must consume artifact without rebuilding')
report={'release':'v54-raw-tosca-mature','status':'PASS' if not errors else 'FAIL','rawSourceTruth':'PASS' if rc.get('status')=='PASS' else 'FAIL','features':len(features),'examples':rc.get('examples'),'rawExamplesMatched':rc.get('rawConcreteExamplesMatched'),'fallbackOverall':fc.get('overallCanonicalFallbackCoverage'),'typedFallbackFiles':len(fb),'scenarioDataFiles':scenario_count,'csharpFiles':len(cs_files),'jsonFiles':json_count,'visualStudioEvidenceStaging':True,'defaultWaits':True,'deferredVerifications':True,'manualGenerationInputs':False,'dotnetBuildPerformed':False,'dotnetBuildReason':'dotnet/csc/msbuild unavailable in generation environment; Azure build pipeline/Visual Studio is the compiler gate.','warnings':warnings,'errors':errors}
(ROOT/'Artifacts/V54FinalValidation.json').write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8')
print(json.dumps(report,indent=2))
raise SystemExit(0 if not errors else 1)
