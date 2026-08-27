from pathlib import Path
import json,re,collections,xml.etree.ElementTree as ET
ROOT=Path(__file__).resolve().parents[1]
raw=json.load(open(ROOT/'Artifacts/ToscaLocatorPropertyCatalog.v54.raw.json'))
cl=[r for r in raw if r['sourceFile']=='CL-DC Modules Production.tsu']
by_guid={r['moduleAttributeGuid']:r for r in cl}
fr_guids=collections.defaultdict(set)
for r in cl:
 v=(r['properties'].get('attributes_fieldref') or '').strip()
 if v: fr_guids[v].add(r['moduleAttributeGuid'])
unique_fr={v for v,g in fr_guids.items() if len(g)==1}

# EQ and PL fallback catalogs remain application-isolated and are intentionally not regenerated here.
# v57 changes their shared runtime behavior through Core; this tool rebuilds only CL|DC from exact raw evidence.
catdir=ROOT/'Artifacts/LocatorFallbackCatalogs'
for app in ['CommercialLines.ExpertQuote','PersonalLines.DuckCreek']:
    dst=catdir/f'{app}.json'
    if not dst.exists():
        raise FileNotFoundError(f'Required isolated fallback catalog is missing: {dst}')

# Frame evidence is copied only from candidates that agree on the exact raw source module+field.
old=json.load(open(catdir/'CommercialLines.DuckCreek.json'))
frame_map=collections.defaultdict(list)
for ctl in old.get('controls',[]):
 for c in ctl.get('candidates',[]):
  fs=(c.get('frameStrategy') or '').strip(); fv=(c.get('frameValue') or '').strip()
  key=(c.get('sourceModule',''),c.get('sourceField',''))
  if fs and fv and (fs,fv) not in frame_map[key]: frame_map[key].append((fs,fv,c.get('frameField',''),c.get('frameSourceProperty','')))

def stable_id(v):
 v=(v or '').strip()
 return bool(v and v.lower() not in {'undefined','null','none','0'} and not re.fullmatch(r'ext-element-\d+',v,re.I))
def css_escape(v): return v.replace('\\','\\\\').replace('"','\\"')
def rel_label(xml):
 if not xml or not xml.lstrip().startswith('<'): return ''
 try:
  root=ET.fromstring(xml)
  vals={}
  for kv in root.findall('.//KeyValuePair'):
   k=kv.findtext('Key') or ''; v=kv.findtext('Value') or ''
   if k and v: vals[k]=v
  return (vals.get('AssociatedLabel') or vals.get('InnerText') or '').strip()
 except Exception: return ''
def role_for(r):
 p=r['properties']; tag=(p.get('Tag') or '').upper(); bt=(r.get('businessType') or '').lower()
 if tag=='A': return 'link'
 if tag=='BUTTON': return 'button'
 if tag=='SELECT' or bt in {'combobox','dropdown'}: return 'combobox'
 if tag in {'INPUT','TEXTAREA'} and bt=='textbox': return 'textbox'
 if tag=='INPUT' and bt in {'checkbox','checkbutton'}: return 'checkbox'
 if tag=='INPUT' and bt in {'radio','radiobutton'}: return 'radio'
 return ''
def candidate(r,strategy,value,source_prop,confidence,reason,**kw):
 p=r['properties']; base={
  'pick':'unique','index':0,'exact':True,'hasText':'','anchorStrategy':'','anchorValue':'',
  'expectedTag':(p.get('Tag') or '').lower(),'businessType':r.get('businessType',''),
  'sourceFile':r['sourceFile'],'sourceModule':r['module'],'sourceField':r['field'],'moduleAttributeGuid':r['moduleAttributeGuid'],
  'matchScore':1000,'strategy':strategy,'value':value,'role':'','sourceProperty':source_prop,
  'confidence':confidence,'reason':reason,'frameStrategy':'','frameValue':'','frameField':'','frameSourceProperty':''}
 base.update(kw); return base

def base_candidates(r):
 p=r['properties']; out=[]
 fr=(p.get('attributes_fieldref') or '').strip()
 if fr and fr in unique_fr: out.append(candidate(r,'fieldref',fr,'attributes_fieldref',1.0,'Unique raw Tosca fieldref for this physical ModuleAttribute.'))
 rid=(p.get('Id') or p.get('attributes_id') or '').strip()
 if stable_id(rid): out.append(candidate(r,'id',rid,'Id',.98,'Stable raw HTML id from the exact Tosca ModuleAttribute.'))
 name=(p.get('Name') or '').strip()
 if name and not name.startswith('<'): out.append(candidate(r,'name',name,'Name',.96,'Raw HTML name from the exact Tosca ModuleAttribute.'))
 aid=(p.get('AutomationId') or '').strip()
 if aid: out.append(candidate(r,'automationid',aid,'AutomationId',.95,'Application-supported AutomationId from raw Tosca.'))
 label=(p.get('Label') or '').strip()
 relative=rel_label(p.get('RelativeId',''))
 form=(p.get('Tag') or '').upper() in {'INPUT','SELECT','TEXTAREA'} or (r.get('businessType') or '').lower() in {'textbox','combobox','checkbox','radiobutton','radio','dropdown'}
 if form and label: out.append(candidate(r,'associatedlabel',label,'Label',.93,'Resolve raw label to its associated actual form control.'))
 if form and relative and relative.lower()!=label.lower(): out.append(candidate(r,'associatedlabel',relative,'RelativeId.Label',.91,'Raw Tosca relative label relationship resolved to its actual form control.'))
 role=role_for(r); accessible=(p.get('InnerText') or label or r['field']).strip()
 if role and accessible:
  out.append(candidate(r,'role',accessible,'Tag+AccessibleName',.88 if role in {'textbox','combobox'} else .92,
                       f'Raw tag supports DOM role {role}; accessible name comes from exact source evidence.',role=role))
 # parent/component relationship: source tag + stable class, still uniqueness-probed before action.
 cls=(p.get('ClassName') or '').strip()
 tag=(p.get('Tag') or '').strip().lower()
 if tag and cls:
  classes=[x for x in re.split(r'\s+',cls) if x and re.fullmatch(r'[A-Za-z_][A-Za-z0-9_-]*',x)]
  if classes:
   sel=tag+''.join('.'+x for x in classes[:4])
   out.append(candidate(r,'css',sel,'Tag+ClassName',.72,'Source-backed component relationship; runtime uniqueness is mandatory.'))
 inner=(p.get('InnerText') or '').strip()
 if tag and inner and not role:
  out.append(candidate(r,'css',tag,'Tag+InnerText',.68,'Source-backed tag/text relationship; runtime uniqueness is mandatory.',hasText=inner))
 ci=(p.get('ConstraintIndex') or '').strip()
 if tag and ci.isdigit():
  idx=max(0,int(ci)-1)
  out.append(candidate(r,'css',tag,'ConstraintIndex',.55,'Source-backed occurrence/index; last-resort only.',pick='nth',index=idx))
 # Never emit raw DuckCreekId in CL|DC v57.
 return out

def with_frame(cands,r):
 hints=frame_map.get((r['module'],r['field']),[])
 if not hints: return cands
 # One candidate carries one raw frame hint. Resolver itself always tries frame -> document and caches actual success.
 fs,fv,ff,fp=hints[0]
 for c in cands:
  c['frameStrategy']=fs; c['frameValue']=fv; c['frameField']=ff; c['frameSourceProperty']=fp
 return cands

# Parse v57 exact raw GUID comments.
raw_comment=re.compile(r'//\s*v57 raw Tosca: .*?\|\s*guid=([0-9a-f-]+)\s*\|\s*strategy=([^\n]+)',re.I)
prop_re=re.compile(r'(?P<comments>(?:\s*//[^\n]*\n)*)\s*public\s+ILocator\s+(?P<name>\w+)\s*=>',re.S)
controls=[]; raw_mapped=0; frame_controls=0; guid_owners={}; cross_page=collections.defaultdict(list)
for p in sorted((ROOT/'tests/CommercialLines.DuckCreek.Tests/Pages/Locators').glob('*Locators.cs')):
 page=p.stem.replace('Locators',''); text=p.read_text()
 for m in prop_re.finditer(text):
  name=m.group('name'); rm=raw_comment.search(m.group('comments')); row=None
  if rm: row=by_guid.get(rm.group(1).lower()) or by_guid.get(rm.group(1))
  cands=[]; guid=''
  if row:
   guid=row['moduleAttributeGuid']; raw_mapped+=1; cands=with_frame(base_candidates(row),row)
   if any(x.get('frameValue') for x in cands): frame_controls+=1
   cross_page[guid].append((page,name))
  # Hard reviewed CL|DC login contract when raw export omitted the login module detail.
  if page=='Login' and name in {'UserName','Password','Login'}:
   if name=='UserName': cands=[{'pick':'unique','index':0,'exact':True,'hasText':'','anchorStrategy':'','anchorValue':'','expectedTag':'input','businessType':'TextBox','sourceFile':'CL-DC Modules Production.tsu','sourceModule':'Login','sourceField':'UserName','moduleAttributeGuid':'reviewed-login-username','matchScore':1000,'strategy':'id','value':'username-inputEl','role':'','sourceProperty':'RawHtmlId','confidence':1.0,'reason':'Reviewed CL|DC login raw HTML id.','frameStrategy':'','frameValue':'','frameField':'','frameSourceProperty':''}]
   elif name=='Password': cands=[dict(cands[0]) if cands else {'pick':'unique','index':0,'exact':True,'hasText':'','anchorStrategy':'','anchorValue':'','expectedTag':'input','businessType':'TextBox','sourceFile':'CL-DC Modules Production.tsu','sourceModule':'Login','sourceField':'Password','moduleAttributeGuid':'reviewed-login-password','matchScore':1000,'strategy':'id','value':'password-inputEl','role':'','sourceProperty':'RawHtmlId','confidence':1.0,'reason':'Reviewed CL|DC login raw HTML id.','frameStrategy':'','frameValue':'','frameField':'','frameSourceProperty':''}]
   else: cands=[{'pick':'unique','index':0,'exact':True,'hasText':'','anchorStrategy':'','anchorValue':'','expectedTag':'a','businessType':'Button','sourceFile':'CL-DC Modules Production.tsu','sourceModule':'Login','sourceField':'Login','moduleAttributeGuid':'reviewed-login-link','matchScore':1000,'strategy':'role','value':'Login','role':'link','sourceProperty':'RawTag+A11yName','confidence':1.0,'reason':'Reviewed CL|DC login is an <a>, so link semantics are used.','frameStrategy':'','frameValue':'','frameField':'','frameSourceProperty':''}]
  # De-dupe signature while preserving hierarchy order.
  seen=set(); ded=[]
  for c in cands:
   sig=(c['strategy'],c['value'],c.get('role',''),c.get('hasText',''),c.get('pick',''),c.get('index',0),c.get('frameStrategy',''),c.get('frameValue',''))
   if sig not in seen: seen.add(sig); ded.append(c)
  controls.append({'page':page,'control':name,'canonicalControl':name,'aliasOf':'','primaryClues':[],'moduleHint':row['module'] if row else '',
                   'sourceEvidenceCount':1 if row else 0,'moduleAttributeGuid':guid,'candidates':ded})

# Canonical reuse inside a Page is keyed by physical moduleAttributeGuid only, never by coincident selector text.
by_page_guid={}
for ctl in controls:
 guid=ctl.get('moduleAttributeGuid')
 if not guid: continue
 key=(ctl['page'],guid)
 if key in by_page_guid:
  owner=by_page_guid[key]
  ctl['canonicalControl']=owner; ctl['aliasOf']=owner; ctl['candidates']=[]
 else: by_page_guid[key]=ctl['control']

canonical=[c for c in controls if not c['aliasOf']]
withfb=[c for c in canonical if c['candidates']]
catalog={
 'version':'57.0','application':'CommercialLines.DuckCreek','sourceCatalogEntries':len(cl),'pageLocatorProperties':len(controls),
 'aliases':sum(bool(c['aliasOf']) for c in controls),'canonicalControls':len(canonical),'canonicalControlsWithFallback':len(withfb),
 'canonicalControlsWithTwoOrMoreFallbacks':sum(len(c['candidates'])>=2 for c in canonical),
 'canonicalFallbackCoverage':round(len(withfb)/len(canonical),6) if canonical else 0,
 'canonicalTwoPlusCoverage':round(sum(len(c['candidates'])>=2 for c in canonical)/len(canonical),6) if canonical else 0,
 'allPropertyFallbackCoverage':round(sum(bool(c['candidates']) or bool(c['aliasOf']) for c in controls)/len(controls),6) if controls else 0,
 'locatorPriority':['unique fieldref','stable raw HTML id','stable name','application-supported AutomationId/test id','label -> associated actual control','DOM-supported role + accessible name','parent/sibling/component relationship','source-backed occurrence/index'],
 'frameResolution':'Raw HtmlFrame is a hint: brief frame probe -> frame if present, otherwise top document -> cache successful Page.Control scope.',
 'duckCreekIdPolicy':'Raw DuckCreekId is never emitted for CL|DC v57 unless future browser evidence explicitly proves the frontend attribute exists.',
 'controls':controls,
 'frameAwareCandidates':sum(sum(bool(x.get('frameValue')) for x in c['candidates']) for c in controls)
}
(catdir/'CommercialLines.DuckCreek.json').write_text(json.dumps(catalog,indent=2)+"\n")
report={'rawMappedControls':raw_mapped,'controls':len(controls),'canonicalAliases':catalog['aliases'],'canonicalWithFallback':len(withfb),'coverage':catalog['canonicalFallbackCoverage'],'frameMappedControls':frame_controls,
        'fieldrefCandidates':sum(sum(x['strategy']=='fieldref' for x in c['candidates']) for c in controls),
        'duckCreekIdCandidates':sum(sum(x['strategy'].lower()=='duckcreekid' for x in c['candidates']) for c in controls),
        'crossPageSamePhysicalGuid':{g:v for g,v in cross_page.items() if len(set(x[0] for x in v))>1}}
(ROOT/'Artifacts/V57ExactFallbackCatalogReport.json').write_text(json.dumps(report,indent=2)+"\n")
print(json.dumps({k:(len(v) if isinstance(v,dict) else v) for k,v in report.items()},indent=2))
