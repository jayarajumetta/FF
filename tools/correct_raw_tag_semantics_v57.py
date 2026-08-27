#!/usr/bin/env python3
"""v57 source-backed HTML tag semantic corrections for CL|DC.

Rules:
- Never infer DuckCreekId as a browser attribute.
- If every raw CL|DC ModuleAttribute whose field exactly matches a generated Button accessible name is Tag=A,
  emit Link semantics instead of Button semantics. This is tag evidence, not DuckCreekId use.
- Repair two v56/v57 migration aliases where an OK page property had been associated to the page H2 GUID rather
  than the physical OK ModuleAttribute GUID. Both corrected controls are reused across page repositories and stay
  canonical through CanonicalDuckCreekLocatorFactory.
"""
from pathlib import Path
import collections, json, re
ROOT=Path(__file__).resolve().parents[1]
LOC=ROOT/'tests/CommercialLines.DuckCreek.Tests/Pages/Locators'
RAW=json.loads((ROOT/'Artifacts/ToscaLocatorPropertyCatalog.v54.raw.json').read_text())
CL=[r for r in RAW if (r.get('sourceFile') or '').startswith('CL-DC')]

def norm_field(v:str)->str:
    return re.sub(r'\s+',' ',(v or '').strip()).rstrip('*').strip().casefold()
field_index=collections.defaultdict(list)
for r in CL: field_index[norm_field(r.get('field',''))].append(r)

# Wrong migrated physical identity -> exact raw OK physical identity.
remaps={
 '3a13d49c-172d-ec14-3103-6676dfe3cb12': {
   'new':'3a13d49c-172d-87fd-649f-1d8b0fc57589', 'module':'Risk - Accounts Receivable', 'field':'OK'},
 '3a13d49c-172d-3339-ea9c-c6753cbee168': {
   'new':'3a13d49c-172d-73c0-91ea-b7991fa97b13', 'module':'Risk - Bailees Customers', 'field':'OK'},
}
changes=[]

# Repair GUID comments/canonical references on the page properties.
for p in LOC.glob('*.cs'):
    if p.name=='CanonicalDuckCreekLocatorFactory.cs': continue
    text=p.read_text()
    original=text
    for old,info in remaps.items():
        if old not in text: continue
        text=text.replace(old,info['new'])
        # The raw comment must describe the actual physical OK ModuleAttribute after the remap.
        text=re.sub(
            rf'// v57 raw Tosca: [^\n]*?\| guid={re.escape(info["new"])} \| strategy=retained-semantic',
            f'// v57 raw Tosca: {info["module"]} | {info["field"]} | guid={info["new"]} | strategy=role-link',
            text)
        changes.append({'kind':'physical-guid-remap','file':p.name,'oldGuid':old,'newGuid':info['new'],'module':info['module'],'field':'OK'})
    # Any generated role=Button whose exact accessible name has raw CL|DC field evidence and every such
    # source record is Tag=A is safe to represent as a link. Keep no generated DuckCreekId dependency.
    line_re=re.compile(r'(?P<prefix>public ILocator (?P<prop>\w+) => .*?GetByRole\()AriaRole\.Button(?P<suffix>, new\(\) \{ Name = "(?P<name>[^"]+)"[^\n]*;)',re.M)
    def repl(m):
        matches=field_index.get(norm_field(m.group('name')),[])
        tags={((r.get('properties') or {}).get('Tag') or '').upper() for r in matches}
        if not matches or tags!={'A'}: return m.group(0)
        changes.append({
            'kind':'raw-tag-A-link','file':p.name,'property':m.group('prop'),'accessibleName':m.group('name'),
            'rawMatchCount':len(matches),'rawGuids':sorted({r['moduleAttributeGuid'] for r in matches}),
            'rawModules':sorted({r.get('module','') for r in matches})})
        return m.group('prefix')+'AriaRole.Link'+m.group('suffix')
    text=line_re.sub(repl,text)
    if text!=original: p.write_text(text)

# Repair the canonical registry entries themselves: use the physical OK GUID and Link semantics.
factory=LOC/'CanonicalDuckCreekLocatorFactory.cs'
text=factory.read_text(); original=text
for old,info in remaps.items():
    new=info['new']
    pattern=rf'^\s*"{re.escape(old)}"\s*=>.*$'
    replacement=f'        "{new}" => page.GetByRole(AriaRole.Link, new() {{ Name = "OK", Exact = true }}), // {info["module"]} | OK'
    text,n=re.subn(pattern,replacement,text,flags=re.M)
    if n!=1: raise SystemExit(f'Expected exactly one canonical entry for {old}; got {n}')
if text!=original: factory.write_text(text)

# Recompute the canonical-reuse audit from the actual v57 raw GUID comments.
records=[]
for p in LOC.glob('*.cs'):
    if p.name=='CanonicalDuckCreekLocatorFactory.cs': continue
    lines=p.read_text().splitlines()
    for i,line in enumerate(lines):
        m=re.search(r'guid=([0-9a-f-]{36})\s*\|',line,re.I)
        if not m: continue
        guid=m.group(1).lower(); prop=''; expr=''
        for j in range(i+1,min(i+8,len(lines))):
            mm=re.search(r'public ILocator (\w+)\s*=>\s*(.*)',lines[j])
            if mm: prop=mm.group(1); expr=mm.group(2); break
        records.append((guid,p.name,prop,expr))
counts=collections.Counter(r[0] for r in records)
repeated={g for g,n in counts.items() if n>1}
factory_text=factory.read_text()
factory_guids=set(re.findall(r'^\s*"([0-9a-f-]{36})"\s*=>',factory_text,re.M|re.I))
factory_guids={g.lower() for g in factory_guids}
not_canonical=[{'guid':g,'file':f,'property':prop} for g,f,prop,expr in records if g in repeated and 'CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid' not in expr]
missing_factory=sorted(repeated-factory_guids); extra_factory=sorted(factory_guids-repeated)
pages_by_guid=collections.defaultdict(set)
for g,f,_,_ in records: pages_by_guid[g].add(f)
canon={
 'repeatedPhysicalGuids':len(repeated),'canonicalFactoryEntries':len(factory_guids),
 'propertyReferences':sum(counts[g] for g in repeated),'crossPageGuids':sum(1 for g in repeated if len(pages_by_guid[g])>1),
 'missingFactoryGuids':missing_factory,'extraFactoryGuids':extra_factory,'repeatedReferencesNotUsingFactory':not_canonical,
}
(ROOT/'Artifacts/V57CanonicalLocatorReuse.json').write_text(json.dumps(canon,indent=2)+'\n')
report={'status':'PASS' if not missing_factory and not extra_factory and not not_canonical else 'FAIL','changes':changes,'changedCount':len(changes),'canonicalReuse':canon}
(ROOT/'Artifacts/V57RawTagSemanticCorrections.json').write_text(json.dumps(report,indent=2)+'\n')
print(json.dumps({'status':report['status'],'changedCount':len(changes),'kindCounts':dict(collections.Counter(c['kind'] for c in changes)),'canonicalReuse':canon},indent=2))
if report['status']!='PASS': raise SystemExit(1)
