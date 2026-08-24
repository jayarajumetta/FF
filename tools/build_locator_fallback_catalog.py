#!/usr/bin/env python3
from __future__ import annotations
import json, re, os, glob, html
from pathlib import Path
from collections import defaultdict, Counter

ROOT = Path(__file__).resolve().parents[1]
SOURCE = ROOT / 'Artifacts' / 'ToscaLocatorPropertyCatalog.v52.json'
if not SOURCE.exists(): SOURCE = ROOT / 'Artifacts' / 'ToscaLocatorPropertyCatalog.json'
OUT_DIR = ROOT / 'Artifacts' / 'LocatorFallbackCatalogs'

APPLICATIONS = {
    'CommercialLines.ExpertQuote': {
        'project': 'CommercialLines.ExpertQuote.Tests',
        'source_prefixes': ('CL_EQ','38668CB4-6566-434E-90C3-2681457CA59BCL-EQ Total'),
    },
    'CommercialLines.DuckCreek': {
        'project': 'CommercialLines.DuckCreek.Tests',
        'source_prefixes': ('CL-DC',),
    },
    'PersonalLines.DuckCreek': {
        'project': 'PersonalLines.DuckCreek.Tests',
        'source_prefixes': ('PL_DC',),
    },
}

TYPE_SUFFIX_RE = re.compile(r'(button|textbox|container|label|link|checkbox|radiobutton|combobox|editablecombobox|genericgui|listitem|listbox|cell|table|image|htmlframe)$', re.I)
HEX_SUFFIX_RE = re.compile(r'(?<=[A-Za-z])(?:[0-9A-F]{5,8})$')
PUBLIC_LOCATOR_RE = re.compile(r'public\s+ILocator\s+(\w+)\s*=>\s*(.*?);', re.S)

GENERIC_WORDS = {
    'button','container','label','link','textbox','checkbox','radiobutton','combobox','genericgui',
    'value','result','title','body','true','false','yes','no','row','cell','table','control','field','item'
}


def norm(s: str | None) -> str:
    return re.sub(r'[^A-Za-z0-9]+', '', s or '').lower()


def clean_control_name(name: str) -> str:
    # Generated page controls frequently carry a 5-8 hex disambiguation suffix.
    # Strip only that suffix; do not alter meaningful numeric names such as N1Day.
    return HEX_SUFFIX_RE.sub('', name)


def strip_type(s: str | None) -> str:
    return TYPE_SUFFIX_RE.sub('', norm(s))


def humanize_identifier(name: str) -> str:
    name = clean_control_name(name)
    name = re.sub(r'([a-z0-9])([A-Z])', r'\1 \2', name)
    name = re.sub(r'[_|]+', ' ', name)
    return re.sub(r'\s+', ' ', name).strip()


def clean_source_text(field: str, business_type: str) -> str:
    text = field or ''
    # Remove a trailing Tosca business-type token from the display name when present.
    for suffix in (' RadioButton',' CheckBox',' ComboBox',' EditableComboBox',' TextBox',' Button',' Link',' Label',' Container',' GenericGUI',' ListItem',' ListBox',' Cell',' Table'):
        if text.lower().endswith(suffix.lower()):
            text = text[:-len(suffix)]
            break
    return re.sub(r'\s+', ' ', text).strip(' _-|')


def _csharp_unescape(value: str) -> str:
    return value.replace('\\"','"').replace('\\\\','\\')

def parse_primary(expr: str) -> list[dict]:
    clues: list[dict] = []
    lit = r'((?:\\.|[^"\\])*)'
    patterns = [
        ('testid', rf'GetByTestId\("{lit}"\)'),
        ('label', rf'GetByLabel\("{lit}"'),
        ('placeholder', rf'GetByPlaceholder\("{lit}"'),
        ('text', rf'GetByText\("{lit}"'),
        ('title', rf'GetByTitle\("{lit}"'),
        ('css', rf'Locator\("{lit}"\)'),
    ]
    for kind, pat in patterns:
        for m in re.finditer(pat, expr):
            clues.append({'strategy':kind,'value':_csharp_unescape(m.group(1))})
    role_pat=rf'GetByRole\(AriaRole\.(\w+),\s*new\(\)\s*\{{\s*Name\s*=\s*"{lit}"'
    for m in re.finditer(role_pat,expr):
        clues.append({'strategy':'role','role':m.group(1).lower(),'value':_csharp_unescape(m.group(2))})
    has_pat=rf'HasText\s*=\s*"{lit}"'
    for m in re.finditer(has_pat,expr):
        clues.append({'strategy':'hastext','value':_csharp_unescape(m.group(1))})
    return clues

def css_attrs(css: str) -> list[tuple[str,str]]:
    return [(a.lower(),v) for a,v in re.findall(r"\[([\w-]+)=['\"]([^'\"]+)['\"]\]", css)]


def source_attr_name(css_name: str) -> str | None:
    return {
        'id':'Id', 'name':'Name', 'duckcreekid':'DuckCreekId', 'data-duckcreekid':'DuckCreekId',
        'data-testid':'attributes_data-testid', 'data-test-id':'attributes_data-testid'
    }.get(css_name.lower())


def wildcard_css(tag: str | None, attr: str, value: str) -> str:
    t = (tag or '').lower()
    if not t or not re.fullmatch(r'[a-z][a-z0-9-]*', t):
        t = '*'
    esc = value.replace('\\','\\\\').replace('"','\\"')
    # Tosca wildcard semantics are translated to a conservative CSS attribute pattern.
    if '*' not in value:
        return f'{t}[{attr}="{esc}"]'
    starts = value.startswith('*'); ends = value.endswith('*')
    core = value.strip('*').replace('\\','\\\\').replace('"','\\"')
    if not core:
        return f'{t}[{attr}]'
    if starts and ends: op='*='
    elif starts: op='$='
    elif ends: op='^='
    else: op='*='
    return f'{t}[{attr}{op}"{core}"]'


def parse_numeric_index(properties: dict) -> tuple[str,int]:
    raw = str(properties.get('ConstraintIndex','')).strip()
    # only literal source indices are safe; Tosca buffer expressions are not guessed.
    if not re.fullmatch(r'\d+', raw):
        return ('unique',0)
    one = int(raw)
    if one <= 0: return ('unique',0)
    zero = one - 1
    return ('first',0) if zero == 0 else ('nth',zero)


def parse_relative_anchor(relative_xml: str) -> dict | None:
    if not relative_xml or '<RelativeId>' not in relative_xml:
        return None
    # The catalog stores RelativeId as XML text. We only compile the safe subset:
    # target uses context of an ancestor/related ModuleAttribute and the source explicitly
    # says Descendants. Relative coordinates/directions are not translated into guesses.
    if 'Descendants' not in relative_xml or '<UseContextOfTargetControl>true</UseContextOfTargetControl>' not in relative_xml:
        return None
    def pair(key: str) -> str | None:
        m = re.search(rf'<Key>{re.escape(key)}</Key>\s*<Value>(.*?)</Value>', relative_xml, re.S|re.I)
        return html.unescape(m.group(1).strip()) if m else None
    anchor_id = pair('Id')
    anchor_text = pair('InnerText')
    if anchor_id:
        return {'strategy':'id','value':anchor_id,'text':anchor_text or ''}
    return None


def role_for_business_type(business_type: str, tag: str | None) -> str | None:
    bt = (business_type or '').strip().lower()
    tag = (tag or '').strip().lower()
    if bt == 'button' or tag == 'button': return 'button'
    if bt == 'link' or tag == 'a': return 'link'
    if bt == 'radiobutton': return 'radio'
    if bt == 'checkbox': return 'checkbox'
    if bt in ('combobox','editablecombobox') or tag in ('select','mat-select'): return 'combobox'
    if bt == 'textbox' or tag in ('input','textarea'): return 'textbox'
    if bt == 'listitem': return 'option'
    if tag in ('h1','h2','h3','h4','h5','h6'): return 'heading'
    return None


def candidate_signature(c: dict) -> str:
    return '|'.join(str(c.get(k,'')).lower() for k in ('strategy','value','role','anchorStrategy','anchorValue','pick','index','exact','hasText'))


def primary_signatures(clues: list[dict]) -> set[str]:
    sigs=set()
    for c in clues:
        strategy=c['strategy']; val=c.get('value','')
        if strategy=='css':
            # Keep raw css signature and normalized direct-attribute equivalents.
            sigs.add(f'css|{val.lower()}')
            for attr,av in css_attrs(val):
                mapped={'id':'id','name':'name','duckcreekid':'duckcreekid','data-duckcreekid':'duckcreekid','data-testid':'testid','data-test-id':'testid'}.get(attr)
                if mapped: sigs.add(f'{mapped}|{av.lower()}')
        elif strategy=='role': sigs.add(f'role|{val.lower()}|{c.get("role","").lower()}')
        elif strategy not in ('hastext',): sigs.add(f'{strategy}|{val.lower()}')
    return sigs


def is_equivalent_to_primary(c: dict, psigs: set[str]) -> bool:
    strat=c.get('strategy','').lower(); val=str(c.get('value','')).lower(); role=str(c.get('role','')).lower()
    if f'{strat}|{val}' in psigs or f'{strat}|{val}|{role}' in psigs:
        # A source-backed HasText/anchor/index makes it materially more specific than the primary.
        return not (c.get('hasText') or c.get('anchorStrategy') or c.get('pick') not in ('',None,'unique'))
    return False


class EvidenceIndex:
    def __init__(self, entries: list[dict]):
        self.entries=entries
        self.by_field=defaultdict(set)
        self.by_strip_field=defaultdict(set)
        self.by_prop=defaultdict(lambda: defaultdict(set))
        self.by_module=defaultdict(set)
        self.field_keys=[]
        for i,e in enumerate(entries):
            f=norm(e.get('field')); sf=strip_type(e.get('field'))
            if f: self.by_field[f].add(i)
            if sf: self.by_strip_field[sf].add(i)
            nm=norm(e.get('module'))
            if nm: self.by_module[nm].add(i)
            p=e.get('properties') or {}
            for k in ('Id','attributes_id','Name','DuckCreekId','attributes_data-testid'):
                v=str(p.get(k,'')).strip()
                if v: self.by_prop[k][v].add(i)
        self.field_keys=list(self.by_field.keys())

    def candidate_ids(self, page: str, control: str, clues: list[dict], module_hint: str = '') -> set[int]:
        ids=set(); c=clean_control_name(control); nc=norm(c); sc=strip_type(c)
        ids |= self.by_field.get(nc,set()); ids |= self.by_strip_field.get(sc,set())
        mh=norm(module_hint)
        if mh:
            ids |= self.by_module.get(mh,set())
        for clue in clues:
            st=clue['strategy']; v=clue.get('value','')
            if st=='testid': ids |= self.by_prop['attributes_data-testid'].get(v,set())
            elif st=='css':
                for attr,av in css_attrs(v):
                    sn=source_attr_name(attr)
                    if sn:
                        ids |= self.by_prop[sn].get(av,set())
                        if sn=='Id': ids |= self.by_prop['attributes_id'].get(av,set())
            elif st in ('text','label','role','placeholder','title','hastext'):
                nv=norm(v)
                ids |= self.by_field.get(nv,set()); ids |= self.by_strip_field.get(strip_type(v),set())
        # Fuzzy only when exact/property evidence was weak. This is bounded by distinct field names,
        # not all 30k catalog rows.
        if len(ids)<3 and len(nc)>=5:
            for fk in self.field_keys:
                if len(fk)>=5 and (fk in nc or nc in fk): ids |= self.by_field[fk]
        return ids


def evidence_score(e: dict, page: str, control: str, clues: list[dict], module_hint: str = '') -> int:
    field=e.get('field',''); module=e.get('module',''); desc=e.get('description',''); props=e.get('properties') or {}
    c=clean_control_name(control)
    nc,nf,np,nm,nd=norm(c),norm(field),norm(page),norm(module),norm(desc)
    score=0
    if nf==nc: score+=150
    elif nf and nc and (nf in nc or nc in nf): score+=55
    sf,sc=strip_type(field),strip_type(c)
    if sf and sf==sc: score+=90
    if np and np in nm: score+=28
    mh=norm(module_hint)
    if mh and nm==mh: score+=180
    elif mh and (mh in nm or nm in mh): score+=95
    # Page names are deliberately generic (Proposal/Navigation/etc). Require control evidence too;
    # page match is only a ranking boost.
    for clue in clues:
        st=clue['strategy']; val=clue.get('value',''); nv=norm(val)
        if st=='css':
            for attr,av in css_attrs(val):
                sn=source_attr_name(attr)
                if sn and (str(props.get(sn,''))==av or (sn=='Id' and str(props.get('attributes_id',''))==av)): score+=220
        elif st=='testid' and props.get('attributes_data-testid')==val: score+=220
        elif st=='role':
            if nf==nv or nd==nv: score+=90
            elif nv and nf and (nv in nf or nf in nv): score+=35
            role=role_for_business_type(e.get('businessType',''),props.get('Tag'))
            if role and role==clue.get('role'): score+=25
        elif st in ('text','label','placeholder','title','hastext'):
            if nf==nv or nd==nv: score+=90
            elif nv and nf and (nv in nf or nf in nv): score+=35
    for k,w in [('Id',16),('attributes_id',16),('DuckCreekId',16),('Name',13),('attributes_data-testid',13),('InnerText',7),('Label',7),('AssociatedLabel',5),('ConstraintIndex',4),('RelativeId',4),('XPath',3),('ClassName',2)]:
        if props.get(k): score+=w
    return score


def build_candidates(e: dict, match_score: int, page: str, control: str) -> list[dict]:
    p=e.get('properties') or {}; tag=str(p.get('Tag','')).strip(); bt=e.get('businessType','') or ''
    source_text=clean_source_text(e.get('field','') or '',bt)
    inner_text=str(p.get('InnerText','')).strip()
    source_label=str(p.get('Label','')).strip()
    associated_label=str(p.get('AssociatedLabel','')).strip()
    pick,index=parse_numeric_index(p)
    # Mapping confidence must be strong before a source locator is exposed at runtime.
    mapping_factor=max(0.70,min(1.0,match_score/180.0))
    common={
        'pick':pick,'index':index,'exact':True,'hasText':'','anchorStrategy':'','anchorValue':'',
        'expectedTag':tag.lower(), 'businessType':bt,
        'sourceFile':e.get('sourceFile',''),'sourceModule':e.get('module',''),'sourceField':e.get('field',''),
        'matchScore':match_score,
    }
    out=[]
    def add(strategy,value,base,source_property,reason,role='',has_text='',anchor=None,exact=True):
        if not value: return
        c=dict(common); c.update({
            'strategy':strategy,'value':value,'role':role,'exact':exact,'sourceProperty':source_property,
            'confidence':round(base*mapping_factor,4),'reason':reason,'hasText':has_text or ''
        })
        if anchor:
            c['anchorStrategy']=anchor.get('strategy',''); c['anchorValue']=anchor.get('value','')
        out.append(c)
    # Technical IDs - highest-confidence source evidence.
    for prop,strategy,base,attr in [
        ('Id','id',0.995,'id'),('attributes_id','id',0.992,'id'),('DuckCreekId','duckcreekid',0.995,'duckcreekid'),
        ('Name','name',0.975,'name'),('attributes_data-testid','testid',0.965,'data-testid')]:
        val=str(p.get(prop,'')).strip()
        if not val: continue
        if '*' in val:
            add('css',wildcard_css(tag,attr,val),base-0.025,prop,f'Tosca {prop} wildcard translated to CSS attribute pattern.')
        else:
            # When one source attribute intentionally identifies a group (chip wrappers are a common
            # example), retain source business text as a deterministic filter.
            use_text = source_text if prop in ('attributes_data-testid','Name') and source_text and len(source_text)<=120 else ''
            add(strategy,val,base,prop,f'Direct Tosca ModuleAttribute {prop}.',has_text=use_text)
            if use_text:
                add(strategy,val,base-0.015,prop,f'Direct Tosca {prop} without text filter; accepted only if unique.',has_text='')
    # Multiple source attributes can be combined into an even stricter CSS selector.
    attrs=[]
    for prop,attr in [('Id','id'),('attributes_id','id'),('Name','name'),('DuckCreekId','duckcreekid'),('attributes_data-testid','data-testid')]:
        val=str(p.get(prop,'')).strip()
        if val and '*' not in val: attrs.append((attr,val,prop))
    if len(attrs)>=2:
        t=tag.lower() if re.fullmatch(r'[A-Za-z][A-Za-z0-9-]*',tag or '') else '*'
        selector=t+''.join(f'[{a}="{v.replace(chr(34),chr(92)+chr(34))}"]' for a,v,_ in attrs)
        add('css',selector,0.997,'+'.join(x[2] for x in attrs),'Combined Tosca technical attributes.')
    # Role/accessibility candidate derived from Tosca control business type and field name.
    role=role_for_business_type(bt,tag)
    accessible_text = source_label or (inner_text if len(inner_text)<=120 else '') or source_text
    if role and accessible_text and norm(accessible_text) not in GENERIC_WORDS and len(accessible_text)<=120:
        add('role',accessible_text,0.93,'BusinessType+Field','Tosca BusinessType converted to Playwright role plus source field text.',role=role)
    # Exact source text is useful for links/buttons/labels and chip-like containers; uniqueness is validated live.
    display_text = inner_text or source_text
    if display_text and len(display_text)<=120 and norm(display_text) not in GENERIC_WORDS and (bt in ('Button','Link','Label','ListItem','Container','RadioButton','CheckBox','GenericGUI') or tag.upper() in ('A','BUTTON','LABEL','SPAN','DIV','H1','H2','H3','H4','H5','H6')):
        add('text',display_text,0.86,'Field','Exact source field display text; live uniqueness required.')
    # Tag + source text/label is a distinct deterministic backup for source controls that
    # have no technical ID (headings and status containers are common in ExpertQuote).
    tag_text = inner_text or source_text
    if tag and re.fullmatch(r'[A-Za-z][A-Za-z0-9-]*',tag) and tag_text and len(tag_text)<=120 and norm(tag_text) not in GENERIC_WORDS:
        add('css',tag.lower(),0.89,'Tag+Text','Tosca Tag constrained by source text; live uniqueness required.',has_text=tag_text)
    if source_label and len(source_label)<=120 and norm(source_label) not in GENERIC_WORDS:
        add('label',source_label,0.91,'Label','Tosca self-healing Label evidence.')
    if associated_label and len(associated_label)<=120 and not associated_label.startswith('<'):
        add('label',associated_label,0.87,'AssociatedLabel','Tosca associated-label evidence.')
    # Class is lower confidence but still source-authored and can be highly useful on stable legacy controls.
    cls=str(p.get('ClassName','')).strip()
    if cls and len(cls)<=180 and not any(x in cls for x in ('ng-star-inserted','cdk-focused','mat-focused')):
        t=tag.lower() if re.fullmatch(r'[A-Za-z][A-Za-z0-9-]*',tag or '') else '*'
        esc=cls.replace('\\','\\\\').replace('"','\\"')
        add('css',f'{t}[class="{esc}"]',0.82,'ClassName','Exact Tosca ClassName + tag; accepted only when unique/actionable.')
    # Source XPath is last deterministic resort. It is never synthesized.
    xp=str(p.get('XPath','')).strip().strip('"')
    if xp:
        add('xpath',xp,0.79,'XPath','Exact Tosca source XPath; last-resort deterministic candidate.')
    # Safe subset of Tosca RelativeId: anchored descendant target.
    anchor=parse_relative_anchor(str(p.get('RelativeId','')))
    if anchor and tag and re.fullmatch(r'[A-Za-z][A-Za-z0-9-]*',tag):
        add('css',tag.lower(),0.84,'RelativeId','Tosca RelativeId descendant anchored by source Id.',anchor=anchor,has_text=source_text if source_text and len(source_text)<=120 else '')
    return out


def parse_locator_file(path: Path) -> tuple[str,dict[str,dict]]:
    page=path.name.replace('Locators.cs','')
    text=path.read_text(encoding='utf-8',errors='ignore')
    props={}
    last_end=0
    for m in PUBLIC_LOCATOR_RE.finditer(text):
        name,expr=m.group(1),m.group(2).strip()
        prefix=text[last_end:m.start()]
        module_hint=''
        mm=list(re.finditer(r'//\s*Source modules:\s*(.*?)\s*\|\s*confidence=',prefix))
        if mm: module_hint=mm[-1].group(1).strip()
        alias_match=re.fullmatch(r'(\w+)',expr)
        props[name]={'name':name,'expr':expr,'aliasOf':alias_match.group(1) if alias_match else '', 'clues':parse_primary(expr), 'moduleHint':module_hint}
        last_end=m.end()
    # Resolve aliases to primary clues while preserving alias name as a separate runtime key.
    for name,p in props.items():
        seen=set(); cur=p
        while cur.get('aliasOf') and cur['aliasOf'] in props and cur['aliasOf'] not in seen:
            seen.add(cur['aliasOf']); cur=props[cur['aliasOf']]
        if not p['clues'] and cur is not p:
            p['clues']=cur['clues']
            if not p.get('moduleHint'): p['moduleHint']=cur.get('moduleHint','')
            p['canonicalControl']=cur['name']
        else:
            p['canonicalControl']=name
    return page,props



def parse_control_intent_aliases(project: str) -> list[tuple[str,str,str]]:
    """Return (Page, semantic ControlIntent control, locator property) mappings from Page methods.
    This preserves the clean semantic name used by UiActions while reusing the candidate set compiled
    for the concrete PageLocator property passed into that action.
    """
    out=[]
    page_dir=ROOT/'tests'/project/'Pages'
    call_re=re.compile(r'_ui\.\w+Async\(\s*_locators\.(\w+)(?:(?!;).){0,1600}?new\s+ControlIntent\(\s*"([^"]+)"\s*,\s*"([^"]+)"\s*\)', re.S)
    for path in page_dir.glob('*.cs'):
        text=path.read_text(encoding='utf-8',errors='ignore')
        for m in call_re.finditer(text):
            locator_prop,page,control=m.group(1),m.group(2),m.group(3)
            out.append((page,control,locator_prop))
    return list(dict.fromkeys(out))

def build_application(application: str, cfg: dict, all_source: list[dict]) -> dict:
    entries=[e for e in all_source if any((e.get('sourceFile') or '').startswith(p) for p in cfg['source_prefixes'])]
    idx=EvidenceIndex(entries)
    project_dir=ROOT/'tests'/cfg['project']/'Pages'/'Locators'
    controls=[]; aliases=0
    for path in sorted(project_dir.glob('*Locators.cs')):
        page,props=parse_locator_file(path)
        for name,pdef in props.items():
            if pdef['aliasOf']: aliases+=1
            ids=idx.candidate_ids(page,name,pdef['clues'],pdef.get('moduleHint',''))
            ranked=[]
            for i in ids:
                e=entries[i]; score=evidence_score(e,page,name,pdef['clues'],pdef.get('moduleHint',''))
                if score>=78: ranked.append((score,e))
            ranked.sort(key=lambda x:(x[0],len((x[1].get('properties') or {}))),reverse=True)
            # Keep all high-signal evidence rows, but cap near-duplicate module snapshots.
            evidence_rows=[]; seen_e=set()
            for score,e in ranked[:30]:
                sig=(e.get('module'),e.get('field'),e.get('businessType'),tuple(sorted((e.get('properties') or {}).items())))
                if sig in seen_e: continue
                seen_e.add(sig); evidence_rows.append((score,e))
                if len(evidence_rows)>=14: break
            psigs=primary_signatures(pdef['clues'])
            candidates=[]; seen_c=set()
            for score,e in evidence_rows:
                for c in build_candidates(e,score,page,name):
                    if c['confidence']<0.60: continue
                    if is_equivalent_to_primary(c,psigs): continue
                    sig=candidate_signature(c)
                    if sig in seen_c: continue
                    seen_c.add(sig); candidates.append(c)
            candidates.sort(key=lambda c:(c['confidence'],c['matchScore'],c['strategy'] not in ('xpath','text')),reverse=True)
            candidates=candidates[:40]
            controls.append({
                'page':page,'control':name,'canonicalControl':pdef.get('canonicalControl',name),'aliasOf':pdef.get('aliasOf',''),
                'primaryClues':pdef['clues'],'moduleHint':pdef.get('moduleHint',''),'sourceEvidenceCount':len(evidence_rows),'candidates':candidates,
            })
    # Add semantic ControlIntent aliases used by Page methods. Example: the Page locator property
    # may be SubmitAngular while the action intent is SocialSecurity.Submit. Runtime lookup is by
    # semantic Page.Control, so the sidecar must retain that mapping rather than forcing Page methods
    # to expose implementation-oriented locator property names.
    by_locator={(c['page'].lower(),c['control'].lower()):c for c in controls}
    existing={(c['page'].lower(),c['control'].lower()) for c in controls}
    intent_aliases=0
    for page,semantic,locator_prop in parse_control_intent_aliases(cfg['project']):
        key=(page.lower(),semantic.lower())
        if key in existing: continue
        src=by_locator.get((page.lower(),locator_prop.lower()))
        if not src: continue
        controls.append({
            'page':page,'control':semantic,'canonicalControl':src.get('canonicalControl') or locator_prop,
            'aliasOf':locator_prop,'primaryClues':src.get('primaryClues',[]),'moduleHint':src.get('moduleHint',''),
            'sourceEvidenceCount':src.get('sourceEvidenceCount',0),'candidates':src.get('candidates',[])
        })
        existing.add(key); intent_aliases+=1

    aliases += intent_aliases
    canonical=[c for c in controls if not c['aliasOf']]
    with1=sum(bool(c['candidates']) for c in canonical); with2=sum(len(c['candidates'])>=2 for c in canonical)
    all_with1=sum(bool(c['candidates']) for c in controls)
    return {
        'version':'52.0','application':application,'sourceCatalogEntries':len(entries),
        'pageLocatorProperties':len(controls),'aliases':aliases,'canonicalControls':len(canonical),
        'canonicalControlsWithFallback':with1,'canonicalControlsWithTwoOrMoreFallbacks':with2,
        'canonicalFallbackCoverage':round(with1/max(1,len(canonical)),6),
        'canonicalTwoPlusCoverage':round(with2/max(1,len(canonical)),6),
        'allPropertyFallbackCoverage':round(all_with1/max(1,len(controls)),6),
        'controls':controls,
    }


def main():
    all_source=json.loads(SOURCE.read_text(encoding='utf-8'))
    OUT_DIR.mkdir(parents=True,exist_ok=True)
    summary={'version':'52.0','sourceLocatorPropertyRows':len(all_source),'applications':{},'candidateStrategyCounts':{},'sourcePropertyCounts':{}}
    strat=Counter(); props=Counter()
    for app,cfg in APPLICATIONS.items():
        result=build_application(app,cfg,all_source)
        (OUT_DIR/f'{app}.json').write_text(json.dumps(result,indent=2),encoding='utf-8')
        summary['applications'][app]={k:result[k] for k in ('sourceCatalogEntries','pageLocatorProperties','aliases','canonicalControls','canonicalControlsWithFallback','canonicalControlsWithTwoOrMoreFallbacks','canonicalFallbackCoverage','canonicalTwoPlusCoverage','allPropertyFallbackCoverage')}
        for ctl in result['controls']:
            for c in ctl['candidates']:
                strat[c['strategy']]+=1; props[c['sourceProperty']]+=1
    summary['candidateStrategyCounts']=dict(strat.most_common())
    summary['sourcePropertyCounts']=dict(props.most_common())
    # Weighted maturity across canonical controls.
    total=sum(v['canonicalControls'] for v in summary['applications'].values())
    covered=sum(v['canonicalControlsWithFallback'] for v in summary['applications'].values())
    two=sum(v['canonicalControlsWithTwoOrMoreFallbacks'] for v in summary['applications'].values())
    summary['overallCanonicalFallbackCoverage']=round(covered/max(1,total),6)
    summary['overallCanonicalTwoPlusCoverage']=round(two/max(1,total),6)
    (OUT_DIR/'LocatorFallbackCoverage.json').write_text(json.dumps(summary,indent=2),encoding='utf-8')
    print(json.dumps(summary,indent=2))

if __name__=='__main__': main()
