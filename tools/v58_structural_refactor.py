from __future__ import annotations
import json, re
from pathlib import Path
from collections import defaultdict, Counter

ROOT = Path(__file__).resolve().parents[1]
LOC_ROOT = ROOT / 'tests/CommercialLines.DuckCreek.Tests/Pages/Locators'
PAGE_ROOT = ROOT / 'tests/CommercialLines.DuckCreek.Tests/Pages'
STEP_ROOT = ROOT / 'tests/CommercialLines.DuckCreek.Tests/StepDefinitions'
ART = ROOT / 'Artifacts'

PROP_RE = re.compile(r'^\s*public\s+ILocator\s+(\w+)\s*=>\s*(.+);\s*$')
HEX_TAIL_RE = re.compile(r'^(.*?)([0-9A-F]{5})$')
ROLE_NAME_RE = re.compile(r'Name\s*=\s*"([^"]+)"')
FIELDREF_RE = re.compile(r'\[(?:data-)?fieldref=\\?"([^"\\]+)')

FEATURE_LOB = {
    'BAPBasicPolicySteps.cs': 'BAP',
    'BAPExpandedSteps.cs': 'BAP',
    'CPPBasicPolicySteps.cs': 'CPP',
    'CPBasicPolicySteps.cs': 'CP',
    'GLBasicPolicySteps.cs': 'GL',
    'GLOCPPolicySteps.cs': 'GL OCP',
    'IMBasicPolicySteps.cs': 'IM',
    'UMBBasicPolicySteps.cs': 'UMB',
    'UMBExpandedSteps.cs': 'UMB',
    'WCBasicPolicySteps.cs': 'WC',
    'WCExpandedSteps.cs': 'Carrier  WorkersCompensation  Pages   US   (9.8.0.0)',
    'BAPSmokeTestSteps.cs': 'BAP',
    'CPSmokeTestSteps.cs': 'CP',
    'GLSmokeTestSteps.cs': 'GL',
    'IMSmokeTestSteps.cs': 'IM',
    'WCSmokeTestSteps.cs': 'WC',
    'CPPSmokeTestSteps.cs': 'CPP',
    'UMBSmokeTestSteps.cs': 'UMB',
}

ORDINAL_WORDS = ['Primary', 'Secondary', 'Alternate', 'Additional', 'Supplemental', 'Related', 'Associated', 'Contextual']


def normalize_expr(expr: str) -> str:
    return re.sub(r'\s+', ' ', expr.strip())


def strip_generated_suffix(name: str) -> str:
    m = HEX_TAIL_RE.match(name)
    if not m:
        return name
    tail = m.group(2)
    if not any(ch.isdigit() for ch in tail):
        return name
    return m.group(1)


def pascal(text: str) -> str:
    text = text.replace('&', ' And ')
    tokens = re.findall(r'[A-Za-z0-9]+', text)
    if not tokens:
        return 'Control'
    out = ''.join(t if (t.isupper() and len(t) <= 8) else t[:1].upper() + t[1:] for t in tokens)
    if out and out[0].isdigit():
        out = 'Control' + out
    return out or 'Control'


def context_name(source: str) -> str:
    parts = [p.strip() for p in source.split('|') if p.strip()]
    generic = {'client', 'common', 'main', 'page', 'common navigation links', 'navigation links'}
    parts = [p for p in parts if p.lower() not in generic]
    if not parts:
        if 'navigation' in source.lower():
            return 'Navigation'
        return ''
    chosen = parts[-2:]
    return pascal(' '.join(chosen))


def raw_control_from_comments(comments: list[str]) -> str:
    for c in comments:
        if c.startswith('v57 raw Tosca:'):
            body = c.split(':', 1)[1]
            body = body.split('| guid=', 1)[0]
            parts = [p.strip() for p in body.split('|')]
            if parts:
                value = parts[-1]
                if value:
                    return value
    return ''


def source_from_comments(comments: list[str]) -> str:
    for c in comments:
        if c.startswith('Source modules:'):
            return c.split(':', 1)[1].split('| confidence=', 1)[0].strip()
    return ''


def semantic_from_expr(expr: str) -> str:
    m = ROLE_NAME_RE.search(expr)
    if m:
        return m.group(1)
    m = FIELDREF_RE.search(expr)
    if m:
        value = m.group(1)
        return value.split('.')[-1].split(':')[-1]
    return ''


def expression_kind(expr: str) -> str:
    if 'AriaRole.Link' in expr: return 'Link'
    if 'AriaRole.Button' in expr: return 'Button'
    if 'AriaRole.Textbox' in expr or 'input' in expr.lower() or 'textarea' in expr.lower(): return 'Field'
    if 'AriaRole.Checkbox' in expr: return 'Checkbox'
    if 'AriaRole.Heading' in expr or 'pageTitle' in expr or 'pageTop' in expr: return 'Heading'
    return 'Control'


def clean_business_name(value: str) -> str:
    value = value.replace('*', ' ').strip()
    value = re.sub(r'\s+', ' ', value)
    return pascal(value)


def parse_locator_file(path: Path):
    records = []
    comments: list[str] = []
    for line in path.read_text(encoding='utf-8').splitlines():
        st = line.strip()
        if st.startswith('//'):
            comments.append(st[2:].strip())
            continue
        m = PROP_RE.match(line)
        if m:
            name, expr = m.group(1), m.group(2).strip()
            records.append({
                'name': name,
                'expr': expr,
                'norm': normalize_expr(expr),
                'comments': comments[:],
                'source': source_from_comments(comments),
                'rawControl': raw_control_from_comments(comments),
            })
            comments.clear()
        elif st:
            comments.clear()
    return records


def choose_group_base(group: list[dict]) -> str:
    clean_existing = [r['name'] for r in group if strip_generated_suffix(r['name']) == r['name']]
    if clean_existing:
        return min(clean_existing, key=lambda x: (len(x), x.lower()))
    semantic = semantic_from_expr(group[0]['expr'])
    if semantic:
        return clean_business_name(semantic)
    raw = [clean_business_name(r['rawControl']) for r in group if r['rawControl']]
    raw = [x for x in raw if x and x != 'Control']
    if raw and len(set(raw)) == 1:
        return raw[0]
    bases = [strip_generated_suffix(r['name']) for r in group]
    if bases:
        return clean_business_name(Counter(bases).most_common(1)[0][0])
    return 'Control'


def unique_group_names(groups: list[list[dict]]) -> list[str]:
    bases = [choose_group_base(g) for g in groups]
    result: list[str] = []
    used: set[str] = set()
    for idx, (group, base) in enumerate(zip(groups, bases)):
        candidate = base
        if candidate in used or bases.count(base) > 1:
            source_contexts = [context_name(r['source']) for r in group if r['source']]
            source_contexts = [x for x in source_contexts if x]
            ctx = min(source_contexts, key=len) if source_contexts else ''
            if ctx and not candidate.lower().startswith(ctx.lower()):
                candidate = ctx + candidate
        if candidate in used:
            kind = expression_kind(group[0]['expr'])
            if not candidate.lower().endswith(kind.lower()):
                candidate += kind
        if candidate in used:
            for word in ORDINAL_WORDS:
                option = word + base
                if option not in used:
                    candidate = option
                    break
        if candidate in used:
            raise RuntimeError(f'Unable to assign nonnumeric canonical name for {group[0]["expr"]}')
        used.add(candidate)
        result.append(candidate)
    return result


def rebuild_locators():
    property_map: dict[str, dict[str, str]] = {}
    audit = {}
    for path in sorted(LOC_ROOT.glob('*Locators.cs')):
        if path.name == 'CanonicalDuckCreekLocatorFactory.cs':
            continue
        records = parse_locator_file(path)
        grouped: dict[str, list[dict]] = defaultdict(list)
        order: list[str] = []
        for rec in records:
            if rec['norm'] not in grouped:
                order.append(rec['norm'])
            grouped[rec['norm']].append(rec)
        groups = [grouped[k] for k in order]
        names = unique_group_names(groups)
        mapping: dict[str, str] = {}
        for group, name in zip(groups, names):
            for rec in group:
                mapping[rec['name']] = name
        property_map[path.stem.replace('Locators', '')] = mapping
        namespace = re.search(r'namespace\s+([^;]+);', path.read_text()).group(1)
        cls = path.stem
        lines = ['using Microsoft.Playwright;', '', f'namespace {namespace};', '', f'public sealed class {cls}', '{', '    private readonly IPage _page;', f'    public {cls}(IPage page) => _page = page;', '']
        for i, (group, name) in enumerate(zip(groups, names)):
            lines.append(f'    public ILocator {name} => {group[0]["expr"]};')
            if i != len(groups) - 1:
                lines.append('')
        lines.extend(['}', ''])
        path.write_text('\n'.join(lines), encoding='utf-8')
        audit[path.name] = {
            'before': len(records),
            'after': len(groups),
            'removedDuplicateDefinitions': len(records) - len(groups),
            'renamed': sum(1 for k, v in mapping.items() if k != v),
            'mapping': mapping,
        }
    return property_map, audit


def page_key(path: Path) -> str:
    return path.stem.replace('Page', '')


def split_public_blocks(text: str):
    lines = text.splitlines(keepends=True)
    starts = [i for i, line in enumerate(lines) if re.match(r'^    public\s+', line)]
    if not starts:
        return text, []
    prefix = ''.join(lines[:starts[0]])
    blocks = []
    for idx, st in enumerate(starts):
        end = starts[idx + 1] if idx + 1 < len(starts) else len(lines) - 1
        blocks.append(''.join(lines[st:end]))
    suffix = lines[-1] if lines and lines[-1].strip() == '}' else ''
    return prefix, blocks, suffix


def refactor_pages(property_map):
    method_map: dict[str, dict[str, str]] = {}
    audit = {}
    for path in sorted(PAGE_ROOT.glob('*Page.cs')):
        key = page_key(path)
        mapping = property_map.get(key)
        if not mapping:
            continue
        text = path.read_text(encoding='utf-8')
        for old in sorted(mapping, key=len, reverse=True):
            new = mapping[old]
            text = text.replace(f'_locators.{old}', f'_locators.{new}')
            text = text.replace(f'new ControlIntent("{key}", "{old}")', f'new ControlIntent("{key}", "{new}")')
        local_methods = {}
        method_names = re.findall(r'public\s+(?:async\s+)?Task(?:<[^>]+>)?\s+(\w+)\s*\(', text)
        for method in sorted(set(method_names), key=len, reverse=True):
            new_method = method
            for old in sorted(mapping, key=len, reverse=True):
                if old in new_method:
                    new_method = new_method.replace(old, mapping[old])
            if new_method != method:
                local_methods[method] = new_method
        for old, new in sorted(local_methods.items(), key=lambda kv: len(kv[0]), reverse=True):
            text = re.sub(rf'\b{re.escape(old)}\b', new, text)

        prefix, blocks, suffix = split_public_blocks(text)
        if blocks:
            seen = set(); kept=[]; removed=0
            for block in blocks:
                m = re.search(r'public\s+(?:async\s+)?Task(?:<[^>]+>)?\s+(\w+)\s*\(([^)]*)\)', block, re.S)
                if not m:
                    kept.append(block); continue
                sig = (m.group(1), re.sub(r'\s+', ' ', m.group(2).strip()))
                if sig in seen:
                    removed += 1
                    continue
                seen.add(sig); kept.append(block)
            text = prefix + ''.join(kept) + suffix
        else:
            removed = 0
        text = remove_comment_lines(text)
        path.write_text(text.rstrip() + '\n', encoding='utf-8')
        method_map[key] = local_methods
        audit[path.name] = {'renamedMethods': len(local_methods), 'removedDuplicateMethods': removed, 'mapping': local_methods}
    return method_map, audit


def remove_comment_lines(text: str) -> str:
    lines = []
    in_xml = False
    for line in text.splitlines():
        st = line.strip()
        if st.startswith('//'):
            continue
        lines.append(line.rstrip())
    text = '\n'.join(lines)
    text = re.sub(r'\n{3,}', '\n\n', text)
    return text + ('\n' if not text.endswith('\n') else '')


def tri_not(v):
    return {'T':'F','F':'T','U':'U'}[v]

def tri_and(a,b):
    if a=='F' or b=='F': return 'F'
    if a=='T' and b=='T': return 'T'
    return 'U'

def tri_or(a,b):
    if a=='T' or b=='T': return 'T'
    if a=='F' and b=='F': return 'F'
    return 'U'


def eval_lob_condition(expr: str, lob: str):
    original = expr
    def repl(m):
        op=m.group(1); expected=m.group(2)
        eq=lob.lower()==expected.lower()
        return ' T ' if (eq if op=='==' else not eq) else ' F '
    expr = re.sub(r"['\"]Product \(LOB\)['\"]\s*(==|!=)\s*['\"](.*?)['\"]", repl, expr, flags=re.I)
    if 'Product (LOB)' in expr:
        return None
    expr = expr.replace('||',' OR ').replace('&&',' AND ')
    expr = re.sub(r'\bNOT\s*\(', ' NOT (', expr, flags=re.I)
    expr = re.sub(r"(?:['\"][^'\"]+['\"]|[A-Za-z][A-Za-z0-9 _().:*#/-]*)\s*(?:==|!=)\s*(?:['\"][^'\"]*['\"]|NULL)", ' U ', expr, flags=re.I)
    tokens = re.findall(r'\bT\b|\bF\b|\bU\b|\bAND\b|\bOR\b|\bNOT\b|[()]', expr, flags=re.I)
    if not tokens:
        return None
    pos=0
    def parse_or():
        nonlocal pos
        v=parse_and()
        while pos<len(tokens) and tokens[pos].upper()=='OR':
            pos+=1; v=tri_or(v,parse_and())
        return v
    def parse_and():
        nonlocal pos
        v=parse_unary()
        while pos<len(tokens) and tokens[pos].upper()=='AND':
            pos+=1; v=tri_and(v,parse_unary())
        return v
    def parse_unary():
        nonlocal pos
        if pos>=len(tokens): return 'U'
        tok=tokens[pos].upper()
        if tok=='NOT': pos+=1; return tri_not(parse_unary())
        if tok=='(':
            pos+=1; v=parse_or()
            if pos<len(tokens) and tokens[pos]==')': pos+=1
            return v
        pos+=1
        return tok if tok in ('T','F','U') else 'U'
    try:
        value=parse_or()
        return True if value=='T' else False if value=='F' else None
    except Exception:
        return None


def find_matching_brace(lines, open_index):
    depth=0
    for i in range(open_index, len(lines)):
        depth += lines[i].count('{')
        depth -= lines[i].count('}')
        if depth==0:
            return i
    raise RuntimeError('unbalanced braces')


def specialize_lob(lines: list[str], lob: str):
    changed_true=changed_false=0
    i=0
    while i < len(lines)-1:
        m=re.match(r'^(\s*)if\s*\(data\.Condition\("(.*)"\)\)\s*$', lines[i])
        if not m or 'Product (LOB)' not in m.group(2):
            i+=1; continue
        if i+1>=len(lines) or lines[i+1].strip()!='{':
            i+=1; continue
        expr=m.group(2).replace('\\"','"').replace('\\\\','\\')
        result=eval_lob_condition(expr,lob)
        if result is None:
            i+=1; continue
        end=find_matching_brace(lines,i+1)
        body=lines[i+2:end]
        if result:
            base_indent=len(m.group(1))
            # remove one indentation level from body when possible
            normalized=[]
            for line in body:
                if line.startswith(m.group(1)+'    '): line=line[4:]
                normalized.append(line)
            lines[i:end+1]=normalized
            changed_true+=1
            continue
        lines[i:end+1]=[]
        changed_false+=1
    return lines, changed_true, changed_false


def remove_empty_condition_blocks(lines: list[str]):
    removed=0; i=0
    while i<len(lines)-2:
        if re.match(r'^\s*if\s*\(data\.Condition\(',lines[i]) and lines[i+1].strip()=='{':
            end=find_matching_brace(lines,i+1)
            if all(not x.strip() for x in lines[i+2:end]):
                del lines[i:end+1]; removed+=1; continue
        i+=1
    return lines, removed


def remove_redundant_entity_click_and_reorder(text: str):
    removed=0; moved=0
    # Process method-like blocks conservatively.
    lines=text.splitlines()
    starts=[i for i,l in enumerate(lines) if re.match(r'^    public\s+async\s+Task\s+\w+\(',l)]
    bounds=[]
    for n,st in enumerate(starts):
        en=starts[n+1] if n+1<len(starts) else len(lines)
        bounds.append((st,en))
    # reverse so indices remain stable
    for st,en in reversed(bounds):
        block=lines[st:en]
        if not any('EnterEntityTypeAsync(' in l for l in block):
            continue
        filtered=[]
        for l in block:
            if re.match(r'^\s*await page\.ClickEntityTypeAsync\(\);\s*$',l):
                removed+=1; continue
            filtered.append(l)
        block=filtered
        # Move top-level EntityType set directly after top-level InsuredType set.
        insured=next((i for i,l in enumerate(block) if re.match(r'^        await page\.EnterInsuredTypeAsync\(',l)),None)
        entity=next((i for i,l in enumerate(block) if re.match(r'^        await page\.EnterEntityTypeAsync\(',l)),None)
        if insured is not None and entity is not None and entity>insured+1:
            line=block.pop(entity); block.insert(insured+1,line); moved+=1
        lines[st:en]=block
    return '\n'.join(lines)+'\n', removed, moved


def remove_redundant_fill_clicks(text: str):
    lines=text.splitlines(); removed=0
    last_enter={}
    out=[]
    for line in lines:
        em=re.match(r'^(\s*)await page\.Enter([A-Za-z0-9_]+)Async\(',line)
        if em:
            last_enter[em.group(2)]=len(out)
        cm=re.match(r'^(\s*)await page\.Click([A-Za-z0-9_]+)Async\(\);\s*$',line)
        if cm and cm.group(2) in last_enter and len(out)-last_enter[cm.group(2)] <= 4:
            removed+=1; continue
        if line.strip() and not line.strip().startswith('if') and line.strip() not in ('{','}'):
            # keep recent map only for a short local window
            for k in list(last_enter):
                if len(out)-last_enter[k] > 4: last_enter.pop(k,None)
        out.append(line)
    return '\n'.join(out)+'\n', removed


def refactor_steps(method_map):
    audit={}
    all_method_map={}
    for page, mp in method_map.items(): all_method_map.update(mp)
    for path in sorted(STEP_ROOT.glob('*.cs')):
        text=path.read_text(encoding='utf-8')
        for old,new in sorted(all_method_map.items(), key=lambda kv:len(kv[0]), reverse=True):
            text=re.sub(rf'(?<=\.){re.escape(old)}(?=\()',new,text)
        text=remove_comment_lines(text)
        entity_removed=entity_moved=fill_click_removed=0
        if 'ClientSearchPage' in text:
            text,entity_removed,entity_moved=remove_redundant_entity_click_and_reorder(text)
            text,fill_click_removed=remove_redundant_fill_clicks(text)
        lines=text.splitlines()
        true_count=false_count=0
        lob=FEATURE_LOB.get(path.name)
        if lob:
            lines,true_count,false_count=specialize_lob(lines,lob)
        lines,empty_removed=remove_empty_condition_blocks(lines)
        # ScenarioData.Load primes these aliases now.
        lines=[l for l in lines if 'data.Set("Product (LOB)"' not in l and 'data.Set("State", data.Resolve("{{data:state}}"))' not in l]
        text='\n'.join(lines)
        text=re.sub(r'\n{3,}','\n\n',text).rstrip()+'\n'
        path.write_text(text,encoding='utf-8')
        audit[path.name]={
            'lobSpecializedTrue':true_count,
            'lobSpecializedFalse':false_count,
            'emptyConditionsRemoved':empty_removed,
            'redundantEntityClicksRemoved':entity_removed,
            'entitySetsMovedNextToInsuredType':entity_moved,
            'redundantFillClicksRemoved':fill_click_removed,
        }
    return audit


def scan_generated_suffixes():
    issues=[]
    for path in list(LOC_ROOT.glob('*Locators.cs'))+list(PAGE_ROOT.glob('*Page.cs')):
        if path.name=='CanonicalDuckCreekLocatorFactory.cs': continue
        text=path.read_text()
        for m in re.finditer(r'\b(?:public\s+ILocator\s+|public\s+(?:async\s+)?Task(?:<[^>]+>)?\s+)(\w+)',text):
            name=m.group(1)
            if HEX_TAIL_RE.match(name) and any(c.isdigit() for c in name[-5:]):
                issues.append({'file':str(path.relative_to(ROOT)),'name':name})
    return issues


def main():
    property_map, locator_audit = rebuild_locators()
    method_map, page_audit = refactor_pages(property_map)
    step_audit = refactor_steps(method_map)
    issues=scan_generated_suffixes()
    report={
        'version':'v58',
        'locatorFiles':locator_audit,
        'pageFiles':page_audit,
        'stepFiles':step_audit,
        'generatedSuffixIssues':issues,
        'summary':{
            'locatorDefinitionsBefore':sum(x['before'] for x in locator_audit.values()),
            'locatorDefinitionsAfter':sum(x['after'] for x in locator_audit.values()),
            'duplicateLocatorDefinitionsRemoved':sum(x['removedDuplicateDefinitions'] for x in locator_audit.values()),
            'locatorNamesChanged':sum(x['renamed'] for x in locator_audit.values()),
            'pageMethodsRenamed':sum(x['renamedMethods'] for x in page_audit.values()),
            'duplicatePageMethodsRemoved':sum(x['removedDuplicateMethods'] for x in page_audit.values()),
            'lobConditionBlocksInlined':sum(x['lobSpecializedTrue'] for x in step_audit.values()),
            'lobConditionBlocksRemoved':sum(x['lobSpecializedFalse'] for x in step_audit.values()),
            'emptyConditionBlocksRemoved':sum(x['emptyConditionsRemoved'] for x in step_audit.values()),
            'redundantEntityClicksRemoved':sum(x['redundantEntityClicksRemoved'] for x in step_audit.values()),
            'entitySetsMoved':sum(x['entitySetsMovedNextToInsuredType'] for x in step_audit.values()),
            'redundantFillClicksRemoved':sum(x['redundantFillClicksRemoved'] for x in step_audit.values()),
            'generatedSuffixIssueCount':len(issues),
        }
    }
    (ART/'V58StructuralRefactor.json').write_text(json.dumps(report,indent=2)+'\n')
    print(json.dumps(report['summary'],indent=2))
    if issues:
        print('Generated suffix issues:',issues[:20])

if __name__=='__main__':
    main()
