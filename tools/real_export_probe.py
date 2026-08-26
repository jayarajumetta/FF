#!/usr/bin/env python3
from __future__ import annotations
import base64, collections, gzip, hashlib, io, json, re, sys, zipfile
from pathlib import Path
from xml.etree import ElementTree as ET

GUID_RE=re.compile(r'\{?[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}\}?')

def sha(p):
 h=hashlib.sha256();
 with open(p,'rb') as f:
  for b in iter(lambda:f.read(1024*1024),b''): h.update(b)
 return h.hexdigest()

def kind(buf):
 if buf[:4]==b'PK\x03\x04': return 'zip'
 if buf[:2]==b'\x1f\x8b': return 'gzip'
 s=buf.lstrip()[:1]
 if s in (b'{',b'['): return 'json'
 if s==b'<': return 'xml'
 return 'text'

def decode(name,buf,out,warnings,depth=0,seen=None):
 if seen is None: seen=set()
 if depth>14: warnings.append(f'max depth:{name}'); return
 sig=hashlib.sha256(buf).hexdigest(); key=(sig,name.split('!')[-1])
 if key in seen:return
 seen.add(key); k=kind(buf)
 try:
  if k=='zip':
   with zipfile.ZipFile(io.BytesIO(buf)) as z:
    for n in z.namelist():
     if not n.endswith('/'): decode(name+'!'+n,z.read(n),out,warnings,depth+1,seen)
   return
  if k=='gzip': decode(name+'!gunzip',gzip.decompress(buf),out,warnings,depth+1,seen); return
  text=buf.decode('utf-8-sig',errors='replace').strip()
  if k=='json':
   obj=json.loads(text); out.append((name,'json',obj,len(buf),sig))
   # Decode only transport-looking nested strings.
   stack=[obj]; budget=0
   while stack and budget<10000:
    v=stack.pop()
    if isinstance(v,dict): stack.extend(v.values())
    elif isinstance(v,list): stack.extend(v)
    elif isinstance(v,str):
     c=''.join(v.split())
     if len(c)>=40 and (c.startswith('H4sI') or c.startswith('UEsDB')):
      try: decode(name+f'!embedded-{budget}',base64.b64decode(c),out,warnings,depth+1,seen); budget+=1
      except Exception: pass
   return
  if k=='xml':
   root=ET.fromstring(text); out.append((name,'xml',root,len(buf),sig)); return
  # Some exports have a transport prefix.
  for i,m in enumerate(re.finditer(r'(?:H4sI|UEsDB)[A-Za-z0-9+/=]{32,}',text)):
   try: decode(name+f'!text-embedded-{i}',base64.b64decode(m.group()),out,warnings,depth+1,seen)
   except Exception: pass
  out.append((name,'text',text[:2_000_000],len(buf),sig))
 except Exception as e: warnings.append(f'{name}:{type(e).__name__}:{e}')

def scalar(v): return isinstance(v,(str,int,float,bool)) or v is None

def walk_json(obj, stats, path='$'):
 if isinstance(obj,dict):
  stats['objects']+=1
  keys=list(obj); stats['keys'].update(keys)
  norm={re.sub(r'[^a-z0-9]','',str(k).lower()):v for k,v in obj.items()}
  typ=next((norm[k] for k in ('$type','type','objecttype','nodetype','class','kind','entitytype') if k in norm and scalar(norm[k])),None)
  # normalized $type becomes type
  if typ is None: typ=norm.get('type')
  name=next((norm[k] for k in ('name','displayname','caption','title','label','technicalname') if k in norm and scalar(norm[k])),None)
  ids=[]
  for k in ('guid','uniqueid','id','nodeid','objectid','entityid'):
   if k in norm and scalar(norm[k]): ids+=GUID_RE.findall(str(norm[k])) or [str(norm[k])]
  if typ is not None: stats['types'][str(typ)]+=1
  if name is not None and len(str(name))<300: stats['names'][str(name)]+=1
  if ids: stats['identified_objects']+=1
  combined=(str(typ or '')+' '+str(name or '')).lower()
  if 'testcase' in combined and not any(x in combined for x in ('folder','design','instance','template','execution','value')): stats['testcases']+=1
  if 'module' in combined and not any(x in combined for x in ('attribute','control','folder','parameter')): stats['modules']+=1
  if any(x in combined for x in ('moduleattribute','modulecontrol','guicontrol','htmlcontrol')) or any(k in norm for k in ('fieldref','xpath','cssselector','controltype')):
   stats['controls']+=1
  if 'fieldref' in norm or 'fieldreference' in norm or 'dcfieldref' in norm: stats['fieldrefs']+=1
  if any(k in norm for k in ('actionmode','action','operation','teststepvalue','input')) or 'teststep' in combined: stats['action_candidates']+=1
  for k,v in obj.items(): walk_json(v,stats,path+'.'+str(k))
 elif isinstance(obj,list):
  stats['arrays']+=1
  for i,v in enumerate(obj): walk_json(v,stats,f'{path}[{i}]')

def walk_xml(root,stats):
 for el in root.iter():
  stats['objects']+=1; stats['types'][el.tag]+=1; stats['keys'].update(el.attrib.keys())
  combined=(el.tag+' '+el.attrib.get('Type','')+' '+el.attrib.get('Name','')).lower()
  if 'testcase' in combined and not any(x in combined for x in ('folder','design','instance','template','execution','value')): stats['testcases']+=1
  if 'module' in combined and not any(x in combined for x in ('attribute','control','folder','parameter')): stats['modules']+=1
  if any(x in combined for x in ('moduleattribute','modulecontrol','guicontrol','htmlcontrol')): stats['controls']+=1
  if any(k.lower()=='fieldref' for k in el.attrib): stats['fieldrefs']+=1
  if any(k.lower() in ('actionmode','action','operation','input') for k in el.attrib) or 'teststep' in combined: stats['action_candidates']+=1

def probe(p):
 docs=[]; warnings=[]; data=Path(p).read_bytes(); decode(Path(p).name,data,docs,warnings)
 stats={'objects':0,'arrays':0,'identified_objects':0,'testcases':0,'modules':0,'controls':0,'fieldrefs':0,'action_candidates':0,'keys':collections.Counter(),'types':collections.Counter(),'names':collections.Counter()}
 docmeta=[]
 for name,k,obj,size,sig in docs:
  docmeta.append({'name':name,'kind':k,'bytes':size,'sha256':sig})
  if k=='json':walk_json(obj,stats)
  elif k=='xml':walk_xml(obj,stats)
 result={k:v for k,v in stats.items() if k not in ('keys','types','names')}
 result.update({'top_keys':stats['keys'].most_common(100),'top_types':stats['types'].most_common(100),'top_names':stats['names'].most_common(100)})
 return {'path':str(p),'sha256':sha(p),'bytes':Path(p).stat().st_size,'documents':docmeta,'warnings':warnings,'stats':result}

def main():
 root=Path(__file__).resolve().parents[1]; out=root/'reports'/'raw-export-probe.json'; out.parent.mkdir(exist_ok=True)
 paths=[Path(x) for x in sys.argv[1:]] or [Path('/mnt/data/CL-DC.zip'),Path('/mnt/data/PL_DC.zip'),Path('/mnt/data/CL_EQ.zip')]
 payload={'generatedAt':__import__('datetime').datetime.now(__import__('datetime').timezone.utc).isoformat(),'exports':[probe(p) for p in paths]}
 out.write_text(json.dumps(payload,indent=2),encoding='utf-8')
 print(json.dumps({e['path']:e['stats'] for e in payload['exports']},indent=2))
if __name__=='__main__':main()
