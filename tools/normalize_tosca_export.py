#!/usr/bin/env python3
"""Normalize opaque Tosca ZIP/TSU/GZip exports into a GUID-linked JSON entity graph.

This is an optional transport fallback. The Playwright runtime and mapping remain TypeScript.
No executable action is invented here; the normalizer only preserves source entities, scalar
properties, explicit relationships, inheritance and discovery order.
"""
from __future__ import annotations
import argparse, base64, gzip, hashlib, io, json, re, zipfile
from pathlib import Path
from xml.etree import ElementTree as ET

GUID_RE=re.compile(r'\{?[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}\}?')
ID_KEYS=('guid','uniqueid','id','nodeid','objectid','entityid','xid')
TYPE_KEYS=('type','$type','objecttype','nodetype','nodeclass','class','kind','entitytype','itemtype','typename')
NAME_KEYS=('name','displayname','caption','title','label','technicalname','objectname','longname','shortname')
PARENT_KEYS=('parentid','parentguid','parentuniqueid','parentnodeid','parent','ownerid','ownerguid','containerid','containerguid')
DERIVED_KEYS=('derivedfrom','derivedfromid','derivedfromguid','derivedobject','baseid','baseguid','prototypeid','prototypeguid')
REL_RE=re.compile(r'guid|ref|reference|parent|owner|module|testcase|derived|base|prototype|target|child|children|items|nodes|members|steps|content|contained',re.I)
STRONG_RE=re.compile(r'tosca|testcase|teststep|module|control|attribute|reusable|execution|condition|folder|instance|class|sheet',re.I)

def norm(s): return re.sub(r'[^a-z0-9]','',str(s).lower())
def canon(v):
 m=GUID_RE.search(str(v)); return (m.group(0) if m else str(v)).strip('{}').strip().lower()
def scalar(v): return v is None or isinstance(v,(str,int,float,bool))
def first(record,keys):
 wanted={norm(k) for k in keys}
 for k,v in record.items():
  if norm(k) in wanted and scalar(v) and str(v).strip(): return str(v).strip()
 return None

def xml_to_obj(el):
 obj=dict(el.attrib); obj['_tag']=el.tag
 text=(el.text or '').strip()
 if text: obj['_text']=text
 grouped={}
 for c in list(el): grouped.setdefault(c.tag,[]).append(xml_to_obj(c))
 for k,vals in grouped.items(): obj[k]=vals[0] if len(vals)==1 else vals
 return obj

def decode(name,buf,out,warnings,depth=0,seen=None):
 if seen is None: seen=set()
 if depth>16: warnings.append(f'max-depth:{name}'); return
 sig=hashlib.sha256(buf).hexdigest(); key=(sig,name.split('!')[-1])
 if key in seen:return
 seen.add(key)
 try:
  if buf[:4]==b'PK\x03\x04':
   with zipfile.ZipFile(io.BytesIO(buf)) as z:
    for n in z.namelist():
     if not n.endswith('/'): decode(name+'!'+n,z.read(n),out,warnings,depth+1,seen)
   return
  if buf[:2]==b'\x1f\x8b': decode(name+'!gunzip',gzip.decompress(buf),out,warnings,depth+1,seen);return
  text=buf.decode('utf-8-sig',errors='replace').strip()
  if not text:return
  if text[:1] in '{[':
   obj=json.loads(text);out.append((name,obj));
   stack=[obj];i=0
   while stack and i<10000:
    v=stack.pop()
    if isinstance(v,dict):stack.extend(v.values())
    elif isinstance(v,list):stack.extend(v)
    elif isinstance(v,str):
     c=''.join(v.split())
     if len(c)>40 and (c.startswith('H4sI') or c.startswith('UEsDB')):
      try:decode(name+f'!embedded-{i}',base64.b64decode(c),out,warnings,depth+1,seen);i+=1
      except:pass
   return
  if text.startswith('<'):
   out.append((name,xml_to_obj(ET.fromstring(text))));return
  for i,m in enumerate(re.finditer(r'(?:H4sI|UEsDB)[A-Za-z0-9+/=]{32,}',text)):
   try:decode(name+f'!embedded-text-{i}',base64.b64decode(m.group()),out,warnings,depth+1,seen)
   except:pass
 except Exception as e:warnings.append(f'{name}:{type(e).__name__}:{e}')

def flatten(record,depth=0,prefix='',out=None):
 if out is None:out={}
 if depth>3:return out
 for k,v in record.items():
  key=f'{prefix}.{k}' if prefix else str(k)
  if scalar(v):
   out[str(k)] = v
   if prefix: out[key]=v
  elif isinstance(v,list):
   if all(scalar(x) for x in v):out[str(k)]=v
   for item in v:
    if isinstance(item,dict):
     n=first(item,('name','key','property','attribute','parameter'))
     val=first(item,('value','text','content','data'))
     if n and val is not None:out[n]=val
     flatten(item,depth+1,key,out)
  elif isinstance(v,dict):
   n=first(v,('name','key','property','attribute','parameter'))
   val=first(v,('value','text','content','data'))
   if n and val is not None:out[n]=val
   flatten(v,depth+1,key,out)
 return out

def infer_type(hint,path,record,props):
 t=first(record,TYPE_KEYS) or first(props,TYPE_KEYS)
 if t:return t
 tag=record.get('_tag')
 if tag and tag not in ('#document','Object','Entity','Item','Node'):return str(tag)
 h=(hint or '')+' '+path
 rules=[('teststepvalues','TestStepValue'),('teststeps','TestStep'),('testcases','TestCase'),('moduleattributes','ModuleAttribute'),('modulecontrols','ModuleControl'),('modules','Module'),('instances','Instance'),('reusable','ReusableBlock'),('conditions','Condition')]
 nh=norm(h)
 for needle,value in rules:
  if needle in nh:return value
 return str(hint or 'Unknown')

def refs(record):
 out={}
 def collect(v,depth=0):
  found=[]
  if depth>3:return found
  if scalar(v):found.extend(canon(x) for x in GUID_RE.findall(str(v)))
  elif isinstance(v,list):
   for x in v:found.extend(collect(x,depth+1))
  elif isinstance(v,dict):
   for x in v.values():found.extend(collect(x,depth+1))
  return list(dict.fromkeys(found))
 for k,v in record.items():
  if REL_RE.search(str(k)):
   ids=collect(v)
   if ids:out[str(k)]=ids
 return out

def normalize(docs):
 entities=[];byid={};ordinal=0
 def visit(v,path='$',parent=None,hint=None):
  nonlocal ordinal
  if isinstance(v,list):
   for i,x in enumerate(v):visit(x,f'{path}[{i}]',parent,hint)
   return
  if not isinstance(v,dict):return
  props=flatten(v)
  path_guids=GUID_RE.findall(path)
  rid=first(v,ID_KEYS) or first(props,ID_KEYS) or (path_guids[-1] if path_guids else None)
  typ=infer_type(hint,path,v,props)
  name=first(v,NAME_KEYS) or first(props,NAME_KEYS) or str(v.get('_text') or typ)
  strong=bool(rid and (GUID_RE.search(str(rid)) or STRONG_RE.search(typ))) or bool(STRONG_RE.search(typ) and name)
  current=parent
  if strong:
   eid=canon(rid) if rid else 'synthetic-'+hashlib.sha1(f'{path}:{typ}:{name}'.encode()).hexdigest()[:20]
   parent_raw=first(v,PARENT_KEYS) or first(props,PARENT_KEYS)
   derived=first(v,DERIVED_KEYS) or first(props,DERIVED_KEYS)
   r=refs(v)
   entity={'Id':eid,'Type':typ,'Name':name,'Position':ordinal,'SourcePath':path,'Properties':[{'Name':str(k),'Value':x if scalar(x) else json.dumps(x,default=str)} for k,x in props.items()]}
   ordinal+=1
   if parent_raw:entity['ParentId']=canon(parent_raw)
   elif parent:entity['ParentId']=parent
   if derived:entity['DerivedFrom']=canon(derived)
   for k,ids in r.items():entity[k]=ids
   if eid in byid:
    # Preserve first source order and merge missing evidence.
    old=byid[eid]; existing={p['Name'] for p in old.get('Properties',[])}
    old['Properties'].extend(p for p in entity['Properties'] if p['Name'] not in existing)
    for k,val in entity.items():
     if k not in old or not old[k]:old[k]=val
   else:byid[eid]=entity;entities.append(entity)
   current=eid
  for k,x in v.items():
   if scalar(x):continue
   visit(x,f'{path}.{k}',current,str(k))
 for name,obj in docs:visit(obj,'$',None,name)
 # Infer relationships represented by GUID arrays.
 for e in entities:
  for k,v in list(e.items()):
   nk=norm(k)
   if not isinstance(v,list):continue
   ids=[canon(x) for x in v if canon(x) in byid and canon(x)!=e['Id']]
   if any(x in nk for x in ('parent','owner','container')) and ids and not e.get('ParentId'):e['ParentId']=ids[0]
   if any(x in nk for x in ('child','children','items','nodes','members','steps','content','contained')):
    for cid in ids:
     if not byid[cid].get('ParentId'):byid[cid]['ParentId']=e['Id']
 return entities

def main():
 ap=argparse.ArgumentParser();ap.add_argument('--input',required=True);ap.add_argument('--output',required=True);args=ap.parse_args()
 p=Path(args.input);docs=[];warnings=[];decode(p.name,p.read_bytes(),docs,warnings)
 entities=normalize(docs)
 payload={'NormalizedBy':'Tosca-to-Playwright v58 transport fallback','Source':str(p),'SourceSha256':hashlib.sha256(p.read_bytes()).hexdigest(),'Warnings':warnings,'Entities':entities}
 out=Path(args.output);out.parent.mkdir(parents=True,exist_ok=True);out.write_text(json.dumps(payload,ensure_ascii=False),encoding='utf-8')
 print(json.dumps({'documents':len(docs),'entities':len(entities),'warnings':len(warnings),'output':str(out)}))
if __name__=='__main__':main()
