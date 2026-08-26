#!/usr/bin/env python3
import argparse, gzip, hashlib, json, os, re, sys
from pathlib import Path

FLOW_MAP = {
 'CommercialLines.ExpertQuote.Tests': {
  'raw_key':'CLEQ','source_file':'CL_EQ_TestCases_Staging_Area_Pre_Production.tsu',
  'features':{
   '02_EQ_BOP_Basic_Policy_AL.feature':('EQ | BOP | Basic Policy','TemplateInstance of EQ | BOP | Basic Policy'),
   '03_EQ_BOP_Smoke_Test_MO.feature':('EQ | BOP | Smoke Test','TemplateInstance of EQ | BOP | Smoke Test'),
   '04_EQ_SFP_Smoke_Test_MN.feature':('EQ | SFP | Smoke Test','TemplateInstance of EQ | SFP | Smoke Test'),
   '05_EQ_SFP_Basic_Policy_AL.feature':('EQ | SFP | Basic Policy','TemplateInstance of EQ | SFP | Basic Policy'),
   '06_EQ_SFP_Country_Estate_Policy_AL.feature':('EQ | SFP | Country Estate Policy','TemplateInstance of EQ | SFP | Country Estate'),
  }},
 'CommercialLines.DuckCreek.Tests': {
  'raw_key':'CLDC','source_file':'CL-DC TestCases Staging Area.tsu',
  'features':{
   '001_BAP_Basic_Policy_AL.feature':('BAP | Basic Policy','TemplateInstance of BAP | Basic Policy'),
   '002_BAP_Expanded_AL.feature':('BAP | Expanded','TemplateInstance of BAP | Expanded'),
   '003_CPP_Basic_Policy_AZ.feature':('CPP | Basic Policy','TemplateInstance of CPP | Basic Policy'),
   '004_CP_Basic_Policy_AZ.feature':('CP | Basic Policy','TemplateInstance of CP | Basic Policy'),
   '005_GL_Basic_Policy_AZ.feature':('GL | Basic Policy','TemplateInstance of GL | Basic Policy'),
   '006_GL_OCP_Policy_AZ.feature':('GL | OCP Policy','TemplateInstance of GL | OCP Policy'),
   '007_IM_Basic_Policy_AZ.feature':('IM | Basic Policy','TemplateInstance of IM | Basic Policy'),
   '008_UMB_Basic_Policy_AL.feature':('UMB | Basic Policy','Template Instance - UMB | Basic Policy'),
   '009_UMB_Expanded_AL.feature':('UMB | Expanded','TemplateInstance of UMB | Expanded'),
   '010_WC_Basic_Policy_AL.feature':('WC | Basic Policy','TemplateInstance of WC | Basic Policy'),
   '011_WC_Expanded_AL.feature':('WC |Expanded','TemplateInstance of WC | StraightThrough'),
   '012_BAP_Smoke_Test_AL.feature':('BAP | Smoke Test','TemplateInstance of BAP | Smoke Test'),
   '013_CP_Smoke_Test_AZ.feature':('CP | Smoke Test','TemplateInstance of CP | Smoke Test'),
   '014_GL_Smoke_Test_AZ.feature':('GL | Smoke Test','TemplateInstance of GL | Smoke Test'),
   '015_IM_Smoke_Test_AZ.feature':('IM | Smoke Test','TemplateInstance of IM | Smoke Test'),
   '016_WC_Smoke_Test_AL.feature':('WC | Smoke Test','TemplateInstance of WC | Smoke Test'),
   '017_CPP_Smoke_Test_AZ.feature':('CPP | Smoke Test','TemplateInstance of CPP | Smoke Test'),
   '018_UMB_Smoke_Test_AL.feature':('UMB | Smoke Test','TemplateInstance of UMB | Smoke Test'),
  }},
 'PersonalLines.DuckCreek.Tests': {
  'raw_key':'PLDC','source_file':'PL_DC_TestCases_Production.tsu',
  'features':{
   '181_Auto_Rate_Filings_Policy_1_NB_AL.feature':('Auto Rate Filings Policy 1 NB','TemplateInstance of Auto Rate Filings Policy 1 NB'),
   '182_Auto_Rate_Filings_Policy_3_NB_Prior_Eff_Date_AL.feature':('Auto Rate Filings Policy 3 NB_Prior Eff Date','TemplateInstance of Auto Rate Filings Policy 3 NB_Prior Eff Date'),
   '183_Auto_Rate_Filings_Common_Policy_NB_AL.feature':('Auto Rate Filings Common Policy NB','TemplateInstance of Auto Rate Filings Common Policy NB'),
   '184_Auto_Rate_Filings_Common_Policy_NB_Prior_Eff_Date_AL.feature':('Auto Rate Filings Common Policy NB_Prior Eff Date','TemplateInstance of Auto Rate Filings Common Policy NB_Prior Eff Date'),
   '185_Cycle_Rate_Filings_Policy_1_NB_1_AL.feature':('Cycle Rate Filings Policy 1 NB_1','TemplateInstance of Cycle Rate Filings Policy 1 NB_1'),
   '186_Cycle_Rate_Filings_Policy_3_NB_Prior_Eff_Date_AL.feature':('Cycle Rate Filings Policy 3 NB_Prior Eff Date','TemplateInstance of Cycle Rate Filings Policy 3 NB_Prior Eff Date'),
   '211_Smoke_Test_Auto_AL.feature':('Smoke Test Auto','TemplateInstance of Smoke Test Auto'),
   '212_Smoke_Test_Cycle_AL.feature':('Smoke Test Cycle','TemplateInstance of Smoke Test Cycle'),
   '215_Smoke_Test_RV_AL.feature':('Smoke Test RV','TemplateInstance of Smoke Test RV'),
  }}
}

RAW_FILES = {
 'CLEQ':['CL_EQ_TestCases_Staging_Area_Pre_Production.tsu','CL_EQ_reusable_steps_Production.tsu','CL_EQ_Modules_Production.tsu','CL_EQ_TestCaseDesign_Staging_Area_Pre_Production.tsu'],
 'CLDC':['CL-DC TestCases Staging Area.tsu','CL-DC Modules Production.tsu','CL-DC TestCaseDesign Staging Area.tsu'],
 'PLDC':['PL_DC_TestCases_Production.tsu','PL_DC_Library.tsu','PL_DC_Modules_Production.tsu','PL_DC_TestCaseDesign_Production.tsu'],
}

def sha256(p):
 h=hashlib.sha256()
 with open(p,'rb') as f:
  for b in iter(lambda:f.read(1024*1024),b''):h.update(b)
 return h.hexdigest()

def load_union(folder,key):
 idx={}; files=[]
 for name in RAW_FILES[key]:
  p=Path(folder)/name
  if not p.exists(): raise FileNotFoundError(p)
  with gzip.open(p,'rt',encoding='utf-8') as f:d=json.load(f)
  for e in d.get('Entities',[]): idx[e['Surrogate']]=e
  files.append({'name':name,'sha256':sha256(p),'entities':len(d.get('Entities',[]))})
 return idx,files

def attr(e,k,default=''): return e.get('Attributes',{}).get(k,default)
def disabled(e): return bool(str(attr(e,'DisabledDescription','')).strip())
def ename(e): return attr(e,'Name','')
def norm(v): return re.sub(r'[^A-Z0-9]+',' ',v.upper()).strip()

def children(e):
 a=e.get('Assocs',{})
 if e.get('ObjectClass')=='TestStepFolderReference': return list(a.get('ReusedItem',[]))
 if e.get('ObjectClass')=='TestCaseControlFlowItem': return list(a.get('ControlFlowFolders',[]))+list(a.get('Items',[]))
 return list(a.get('Items',[]))

def expand(idx,g,stack=(),path=(),stats=None):
 if stats is None:stats={'xsteps':0,'xvalues':0,'refs':[]}
 e=idx.get(g)
 if not e or disabled(e) or g in stack:return stats
 cls=e.get('ObjectClass'); p=path+(ename(e) or cls,)
 if cls=='TestStepFolderReference':
  reused=[idx[x] for x in e.get('Assocs',{}).get('ReusedItem',[]) if x in idx]
  stats['refs'].append({'guid':g,'path':' > '.join(p),'reused':[ename(x) for x in reused],'disabled':False})
 if cls=='XTestStep':
  stats['xsteps']+=1
  for vg in e.get('Assocs',{}).get('TestStepValues',[]):
   ve=idx.get(vg)
   if ve and not disabled(ve): stats['xvalues']+=1
  return stats
 for c in children(e): expand(idx,c,stack+(g,),p,stats)
 return stats

def feature_examples(path):
 lines=Path(path).read_text(encoding='utf-8').splitlines(); rows=[]; header=None; in_ex=False
 for line in lines:
  s=line.strip()
  if s.startswith('Examples:'): in_ex=True; header=None; continue
  if in_ex and s.startswith('|'):
   vals=[x.strip() for x in s.strip('|').split('|')]
   if header is None: header=vals
   else: rows.append(dict(zip(header,vals)))
  elif in_ex and s and not s.startswith('#') and not s.startswith('|'):
   if rows: in_ex=False
 steps=[]
 for line in lines:
  m=re.match(r'^\s*(Given|When|Then|And|But)\s+(.+?)\s*$',line)
  if m: steps.append(m.group(2))
 return rows,steps

def set_header(path,source_file,tc,ti,tc_guid,ti_guid):
 p=Path(path); lines=p.read_text(encoding='utf-8').splitlines()
 i=0
 while i<len(lines) and (not lines[i].strip() or lines[i].lstrip().startswith('#')):i+=1
 hdr=[
  f'# v54 RAW TOSCA SOURCE: {source_file}',
  f'# Raw TestCase: {tc} [{tc_guid}]',
  f'# Raw TemplateInstance: {ti} [{ti_guid}]',
  '# Source truth: raw .tsu object graph only; manual CSV/XLSX/HTML are NOT generation or ordering inputs.',
 ]
 p.write_text('\n'.join(hdr+['']+lines[i:])+'\n',encoding='utf-8')

def auth_profile(refs):
 enabled=[r for r in refs if not r['disabled']]
 def has(rx):return any(re.search(rx, r['path']+' | '+' | '.join(r['reused']), re.I) for r in enabled)
 post_logout=any('POST CONDITION' in r['path'].upper() and any('Common|General|Logout'.lower() in x.lower() for x in r['reused']) for r in enabled)
 initial_login=any('PRECONDITION' in r['path'].upper() and any('Log In to DuckCreek'.lower() in x.lower() for x in r['reused']) for r in enabled)
 extra_login=[r for r in enabled if any('Log In to DuckCreek'.lower() in x.lower() for x in r['reused']) and 'PRECONDITION' not in r['path'].upper()]
 return {
  'initialLogin':initial_login,'postConditionLogout':post_logout,
  'uwDirectorTransition':has(r'Log In as UW Director'),
  'agentTransition':has(r'Log back in as Agent'),
  'extraEnabledLoginRefs':[{'guid':r['guid'],'path':r['path'],'reused':r['reused']} for r in extra_login],
 }

def main():
 ap=argparse.ArgumentParser(); ap.add_argument('--root',default='.'); ap.add_argument('--cleq-dir');ap.add_argument('--cldc-dir');ap.add_argument('--pldc-dir');ap.add_argument('--write',action='store_true')
 a=ap.parse_args(); root=Path(a.root).resolve()
 rawdirs={'CLEQ':a.cleq_dir,'CLDC':a.cldc_dir,'PLDC':a.pldc_dir}
 if not all(rawdirs.values()):
  print('Raw Tosca directories are required for v54 cross-validation.',file=sys.stderr);return 2
 unions={}; source_manifest={}
 for key,folder in rawdirs.items():
  idx,files=load_union(folder,key);unions[key]=idx;source_manifest[key]={'folder':str(Path(folder).resolve()),'files':files,'unionEntities':len(idx)}
 errors=[]; flows=[]; total_examples=0; concrete_matched=0
 for project,spec in FLOW_MAP.items():
  idx=unions[spec['raw_key']]
  by_tc={ename(e):e for e in idx.values() if e.get('ObjectClass')=='TestCase'}
  by_ti={ename(e):e for e in idx.values() if e.get('ObjectClass')=='TestCaseTemplateInstance'}
  for fname,(tcname,tiname) in spec['features'].items():
   fpath=root/'tests'/project/'Features'/fname
   if not fpath.exists(): errors.append(f'Missing feature {fpath}');continue
   tc=by_tc.get(tcname);ti=by_ti.get(tiname)
   if tc is None: errors.append(f'Raw TestCase missing: {tcname}');continue
   if ti is None: errors.append(f'Raw TemplateInstance missing: {tiname}');continue
   rows,steps=feature_examples(fpath); total_examples+=len(rows)
   concrete=[idx[g] for g in ti.get('Assocs',{}).get('Items',[]) if g in idx and idx[g].get('ObjectClass')=='TestCase']
   cmap={norm(ename(c)):c for c in concrete}
   if len(rows)!=len(concrete): errors.append(f'{fname}: feature examples={len(rows)} raw concrete={len(concrete)}')
   matches=[]
   for row in rows:
    variant=row.get('stateVariant') or row.get('stateCode') or ''
    c=cmap.get(norm(variant))
    if not c:
     errors.append(f'{fname}: example variant {variant!r} absent from raw TemplateInstance');continue
    concrete_matched+=1; matches.append((row,c))
    if a.write:
     datafile=row.get('dataFile','')
     if datafile:
      jp=root/'tests'/project/datafile
      if jp.exists():
       d=json.load(open(jp,encoding='utf-8')); d.setdefault('_meta',{})['sourceTruth']='RAW_TOSCA';d['_meta']['manualArtifactsUsed']=False
       d['_rawTosca']={'application':spec['raw_key'],'sourceFile':spec['source_file'],'testCaseName':tcname,'testCaseGuid':tc['Surrogate'],'templateInstanceName':tiname,'templateInstanceGuid':ti['Surrogate'],'concreteTestCaseName':ename(c),'concreteTestCaseGuid':c['Surrogate'],'derivedFrom':c.get('Assocs',{}).get('DerivedFrom',[]),'orderAuthority':'XTestStep/XTestStepValue association order'}
       with open(jp,'w',encoding='utf-8') as out: json.dump(d,out,indent=2,ensure_ascii=False);out.write('\n')
   st={'xsteps':0,'xvalues':0,'refs':[]}
   for g in tc.get('Assocs',{}).get('Items',[]):expand(idx,g,(),(),st)
   apf=auth_profile(st['refs']) if spec['raw_key']=='CLDC' else None
   if apf:
    signins=sum(1 for s in steps if s.lower()=='i sign in to commercial lines duck creek using configured credentials')
    signouts=sum(1 for s in steps if s.lower().startswith('i sign out of the application'))
    if signins!=1: errors.append(f'{fname}: expected one clean generated initial sign-in, got {signins}')
    if signouts!=(1 if apf['postConditionLogout'] else 0): errors.append(f'{fname}: generated sign-out count {signouts} != raw post-condition logout {apf["postConditionLogout"]}')
    forbidden=['restart Edge Popup','sign in to Duck Creek for logged in user','sign in to Duck Creek for username']
    for x in forbidden:
     if any(x.lower() in s.lower() for s in steps):errors.append(f'{fname}: reusable login internal leaked into Feature: {x}')
    if apf['uwDirectorTransition'] and not any('switch to UW Director' in s for s in steps):errors.append(f'{fname}: raw UW Director transition missing from Feature')
    if apf['agentTransition'] and not any('switch back to Agent' in s for s in steps):errors.append(f'{fname}: raw Agent transition missing from Feature')
    extra=apf['extraEnabledLoginRefs']
    if extra and not apf['uwDirectorTransition'] and not apf['agentTransition']:
     # CP Basic is a true second enabled Common login; represent it once as business session refresh.
     if tcname=='CP | Basic Policy' and not any('refresh the authenticated Duck Creek session' in s for s in steps):errors.append(f'{fname}: raw second login not represented as a clean session refresh')
   if a.write:set_header(fpath,spec['source_file'],tcname,tiname,tc['Surrogate'],ti['Surrogate'])
   flows.append({'project':project,'featureFile':fname,'rawTestCase':tcname,'testCaseGuid':tc['Surrogate'],'rawTemplateInstance':tiname,'templateInstanceGuid':ti['Surrogate'],'rawConcreteCases':len(concrete),'featureExamples':len(rows),'rawExpandedXTestSteps':st['xsteps'],'rawExpandedXTestStepValues':st['xvalues'],'enabledReusableReferences':len(st['refs']),'authProfile':apf})
 # generic cleanliness
 allfeatures=list(root.glob('tests/*/Features/*.feature'))
 if len(allfeatures)!=32:errors.append(f'Expected 32 generated Features, found {len(allfeatures)}')
 if total_examples!=1074:errors.append(f'Expected 1074 generated examples, found {total_examples}')
 qg=os.system(f'python "{root}/tools/quality_gate.py" "{root}" >/tmp/v54_qg.txt')
 if qg!=0: errors.append('Existing Feature/binding quality_gate.py failed: '+Path('/tmp/v54_qg.txt').read_text(errors='ignore')[:1000])
 report={'release':'v54-raw-tosca-source-truth','status':'PASS' if not errors else 'FAIL','sourceTruth':'RAW_TOSCA_ONLY','manualCsvXlsxHtmlUsed':False,'features':len(allfeatures),'examples':total_examples,'rawConcreteExamplesMatched':concrete_matched,'rawSources':source_manifest,'flows':flows,'errors':errors}
 if a.write:
  art=root/'Artifacts';art.mkdir(exist_ok=True)
  with open(art/'V54RawToscaContract.json','w',encoding='utf-8') as f:json.dump(report,f,indent=2);f.write('\n')
  with open(art/'RawToscaSourceManifest.json','w',encoding='utf-8') as f:json.dump(source_manifest,f,indent=2);f.write('\n')
 print(json.dumps({k:report[k] for k in ['release','status','sourceTruth','manualCsvXlsxHtmlUsed','features','examples','rawConcreteExamplesMatched','errors']},indent=2))
 return 0 if not errors else 1
if __name__=='__main__':raise SystemExit(main())
