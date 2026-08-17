from pathlib import Path
import re,json,sys,xml.etree.ElementTree as ET
root=Path(__file__).resolve().parents[1]
errors=[]; warnings=[]

# Lexical scrubber, preserves newlines and delimiters outside strings/comments.
def scrub(text):
    out=[]; i=0; n=len(text); state='code'; quote=''; raw_quotes=0
    while i<n:
        c=text[i]; nxt=text[i+1] if i+1<n else ''
        if state=='code':
            if c=='/' and nxt=='/': state='line_comment'; out.extend('  '); i+=2; continue
            if c=='/' and nxt=='*': state='block_comment'; out.extend('  '); i+=2; continue
            # raw/interpolated raw string starts ($$""" etc)
            m=re.match(r'\$*"{3,}', text[i:])
            if m:
                raw_quotes=m.group(0).count('"'); state='raw'; out.extend(' '*len(m.group(0))); i+=len(m.group(0)); continue
            if c=='@' and nxt=='"': state='verbatim'; out.extend('  '); i+=2; continue
            if c=='$' and nxt=='"': state='string'; quote='"'; out.extend('  '); i+=2; continue
            if c=='"': state='string'; quote='"'; out.append(' '); i+=1; continue
            if c=="'": state='char'; quote="'"; out.append(' '); i+=1; continue
            out.append(c); i+=1; continue
        if state=='line_comment':
            if c=='\n': state='code'; out.append('\n')
            else: out.append(' ')
            i+=1; continue
        if state=='block_comment':
            if c=='*' and nxt=='/': out.extend('  '); i+=2; state='code'; continue
            out.append('\n' if c=='\n' else ' '); i+=1; continue
        if state=='verbatim':
            if c=='"' and nxt=='"': out.extend('  '); i+=2; continue
            if c=='"': out.append(' '); i+=1; state='code'; continue
            out.append('\n' if c=='\n' else ' '); i+=1; continue
        if state=='raw':
            if text.startswith('"'*raw_quotes,i): out.extend(' '*raw_quotes); i+=raw_quotes; state='code'; continue
            out.append('\n' if c=='\n' else ' '); i+=1; continue
        if state in ('string','char'):
            if c=='\\': out.extend('  ' if i+1<n else ' '); i+=2; continue
            if c==quote: out.append(' '); i+=1; state='code'; continue
            out.append('\n' if c=='\n' else ' '); i+=1; continue
    return ''.join(out),state

# Features
features=list(root.glob('tests/*/Features/*.feature')); example_rows=0
if len(features)!=32: errors.append(f'Expected 32 features, got {len(features)}')
for f in features:
    text=f.read_text(encoding='utf-8')
    for required in ['Background:','Given I open a browser session','Scenario Outline:','Examples:','externalDataFile']:
        if required not in text: errors.append(f'{required} missing: {f.name}')
    if '@canonical_simple_v39' in text or 'opt-in with COPILOT_SELF_HEAL' in text: errors.append(f'Old v43 metadata: {f.name}')
    for b in text.split('Examples:')[1:]:
        rows=[]
        for line in b.splitlines()[1:]:
            if line.strip().startswith('|'): rows.append(line.strip())
            elif rows: break
        if not rows: continue
        counts=[len([x for x in r.strip('|').split('|')]) for r in rows]
        if len(set(counts))!=1: errors.append(f'Malformed Examples table {f.name}: {counts[:5]}')
        example_rows += len(rows)-1
        header=[x.strip() for x in rows[0].strip('|').split('|')]
        for row in rows[1:]:
            vals=[x.strip() for x in row.strip('|').split('|')]
            d=dict(zip(header,vals))
            for key in ('dataFile','externalDataFile'):
                p=f.parent.parent/Path(d.get(key,''))
                if not p.exists(): errors.append(f'Missing {key} {d.get(key)} in {f.name}')

# JSON/XML
for p in root.rglob('*.json'):
    try: json.loads(p.read_text(encoding='utf-8'))
    except Exception as e: errors.append(f'Bad JSON {p.relative_to(root)}: {e}')
for p in [*root.rglob('*.csproj'),root/'Directory.Build.props']:
    try: ET.parse(p)
    except Exception as e: errors.append(f'Bad XML {p.relative_to(root)}: {e}')

# C# lexical / delimiter and field identifiers
for p in root.rglob('*.cs'):
    t=p.read_text(encoding='utf-8'); clean,state=scrub(t)
    if state!='code': errors.append(f'Unclosed lexical construct ({state}) in {p.relative_to(root)}')
    for a,b,label in [('{','}','brace'),('(',')','paren'),('[',']','bracket')]:
        depth=0
        for ch in clean:
            if ch==a: depth+=1
            elif ch==b:
                depth-=1
                if depth<0: errors.append(f'Extra closing {label} in {p.relative_to(root)}'); break
        if depth!=0: errors.append(f'Unbalanced {label} ({depth}) in {p.relative_to(root)}')
    ids=set(re.findall(r'(?<![A-Za-z0-9])(_[A-Za-z][A-Za-z0-9_]*)',clean))
    declared=set(re.findall(r'\b(?:private|protected|internal|public)\s+(?:static\s+)?(?:readonly\s+)?[\w<>,?.\[\]\s]+?\s+(_[A-Za-z][A-Za-z0-9_]*)\s*(?:[;=])',clean))
    missing=sorted(ids-declared)
    if missing: errors.append(f'Undeclared field(s) in {p.relative_to(root)}: {missing}')

# Random ownership
page_random=[]
for p in root.glob('tests/*/Pages/*.cs'):
    tx=p.read_text(encoding='utf-8')
    if '_data.Random(' in tx or 'GenerateRandom(' in tx: page_random.append(str(p.relative_to(root)))
if page_random: errors.append(f'Random generation remains in pages: {page_random[:5]}')
random_calls=sum(p.read_text(encoding='utf-8').count('GenerateRandom(') for p in root.glob('tests/*/StepDefinitions/*.cs'))
if random_calls!=137: errors.append(f'Expected 137 StepDefinition random generators, got {random_calls}')

# Method parser per class
def methods(t):
    return set(re.findall(r'public\s+(?:async\s+)?(?:Task(?:<[^>]+>)?|ValueTask(?:<[^>]+>)?|void|string|bool|ILocator)\s+(\w+)\s*\(',t))

# Step method chunks basic balanced using scrub indexes not exact; regex method boundary and brace scan original.
def method_chunks(t):
    pat=re.compile(r'(?m)^\s*public\s+(?:async\s+)?Task(?:<[^>]+>)?\s+(\w+)\s*\([^)]*\)\s*\{')
    result=[]
    for m in pat.finditer(t):
        start=t.find('{',m.end()-1); depth=0; i=start; clean,_=scrub(t[start:])
        # use scrub substring index same length
        for j,ch in enumerate(clean):
            if ch=='{': depth+=1
            elif ch=='}':
                depth-=1
                if depth==0:
                    result.append((m.group(1),t[start:start+j+1])); break
    return result

for project in root.glob('tests/*'):
    page_methods={}
    for p in project.glob('Pages/*.cs'):
        mt=re.search(r'public sealed class\s+(\w+)',p.read_text(encoding='utf-8'))
        if mt: page_methods[mt.group(1)]=methods(p.read_text(encoding='utf-8'))
    for s in project.glob('StepDefinitions/*.cs'):
        t=s.read_text(encoding='utf-8')
        for sm,ch in method_chunks(t):
            local={m.group(1):m.group(2) for m in re.finditer(r'var\s+(\w+)\s*=\s*new\s+(\w+)\s*\(',ch)}
            for m in re.finditer(r'await\s+(\w+)\.(\w+)\s*\(',ch):
                var,meth=m.groups()
                if var not in local: continue
                cls=local[var]
                if cls not in page_methods: errors.append(f'Missing Page class {cls}: {s.relative_to(root)}::{sm}')
                elif meth not in page_methods[cls]: errors.append(f'Missing PageMethod {cls}.{meth}: {s.relative_to(root)}::{sm}')

    locators={}
    for lp in project.glob('Pages/Locators/*.cs'):
        txt=lp.read_text(encoding='utf-8'); cm=re.search(r'public sealed class\s+(\w+)',txt)
        if cm: locators[cm.group(1)]=set(re.findall(r'public\s+ILocator\s+(\w+)\s*(?:=>|\{)',txt))
    for p in project.glob('Pages/*.cs'):
        if p.name=='ApplicationPage.cs': continue
        txt=p.read_text(encoding='utf-8'); cm=re.search(r'_locators\s*=\s*new\s+(\w+)\s*\(',txt)
        if not cm: continue
        cls=cm.group(1); known=locators.get(cls,set()); refs=set(re.findall(r'_locators\.(\w+)',txt)); missing=refs-known
        if missing: errors.append(f'Missing locators in {p.relative_to(root)}: {sorted(missing)[:15]}')

# Legacy compile blockers
for bad in ['PageUiActions','SelfHealingLocatorResolver','FrameworkSettings','GitHub.Copilot.SDK']:
    hits=[]
    for p in [*root.rglob('*.cs'),*root.rglob('*.csproj')]:
        if bad in p.read_text(encoding='utf-8'): hits.append(str(p.relative_to(root)))
    if hits: errors.append(f'Legacy dependency {bad}: {hits[:5]}')

# Specific critical architecture checks
appsteps=list(root.glob('tests/*/StepDefinitions/ApplicationSteps.cs'))
if len(appsteps)!=3: errors.append('Expected 3 ApplicationSteps.cs')
for p in appsteps:
    t=p.read_text(encoding='utf-8')
    for sig in ['OpenBrowserSessionAsync','LoadScenarioData','OpenApplicationAsync','SignInAsync']:
        if sig not in t: errors.append(f'{sig} missing: {p.relative_to(root)}')
for p in root.glob('tests/*/Hooks/TestHooks.cs'):
    t=p.read_text(encoding='utf-8')
    if '.OpenAsync(' in t: errors.append(f'Hook still launches browser: {p.relative_to(root)}')

report={'version':'44.2-simple-executable','errors':errors,'warnings':warnings,'counts':{
    'features':len(features),'examples':example_rows,'stepDefRandomCalls':random_calls,
    'csharpFiles':len(list(root.rglob('*.cs'))),'pageFiles':len(list(root.glob('tests/*/Pages/*.cs'))),
    'locatorFiles':len(list(root.glob('tests/*/Pages/Locators/*.cs'))),
}}
(root/'Artifacts/V44DeepValidation.json').write_text(json.dumps(report,indent=2),encoding='utf-8')
print(json.dumps(report,indent=2))
sys.exit(1 if errors else 0)
