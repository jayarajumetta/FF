#!/usr/bin/env python3
from __future__ import annotations
import argparse, hashlib, json, re, sys
from pathlib import Path
from bs4 import BeautifulSoup

STEP_RE = re.compile(r'^\s*(Given|When|Then|And|But)\s+(.+?)\s*$')
SOURCE_SUMMARY_RE = re.compile(r'^Step\s+\d+\s*:\s*(?:Given|When|Then|And|But)\s+(.+)$', re.I)
FEATURE_SCOPE_RE = re.compile(r'\[Binding,\s*Scope\(Feature\s*=\s*"([^"]+)"\)\]')
BINDING_RE = re.compile(r'\[(?:Given|When|Then)\(@"((?:[^"]|"")*)"\)\]')
METHOD_RE = re.compile(r'public\s+(?:async\s+)?Task(?:<[^>]+>)?\s+(\w+)\s*\(')

IGNORE_GENERATED = (
    re.compile(r'^I open a browser session$', re.I),
    re.compile(r'^test data .+ are loaded$', re.I),
)

def sha256(path: Path) -> str:
    h=hashlib.sha256()
    with path.open('rb') as f:
        for chunk in iter(lambda:f.read(1024*1024), b''): h.update(chunk)
    return h.hexdigest()

def norm(s: str) -> str:
    return re.sub(r'\s+', ' ', s.strip())

def feature_steps(path: Path) -> list[str]:
    out=[]
    for line in path.read_text(errors='ignore').splitlines():
        m=STEP_RE.match(line)
        if not m: continue
        text=norm(m.group(2))
        if any(p.match(text) for p in IGNORE_GENERATED): continue
        out.append(text)
    return out

def parse_source(html: Path):
    soup=BeautifulSoup(html.read_text(errors='ignore'),'html.parser')
    result={}
    for card in soup.select('section.feature-card'):
        fs=card.select_one('summary.feature-summary')
        if not fs: continue
        direct=' '.join(str(x).strip() for x in fs.contents if isinstance(x,str) and str(x).strip())
        raw=norm(direct or fs.get_text(' ',strip=True))
        m=re.search(r'Feature:\s*(.+)$', raw)
        if not m: continue
        name=norm(m.group(1))
        steps=[]; action_counts=[]
        for sb in card.select('details.step-block'):
            ss=sb.select_one('summary.step-summary')
            if not ss: continue
            sm=SOURCE_SUMMARY_RE.match(norm(ss.get_text(' ',strip=True)))
            if not sm: continue
            steps.append(norm(sm.group(1)))
            action_counts.append(len(sb.select('div.actions tbody tr')))
        result[name]={'steps':steps,'actionCounts':action_counts,'sourceBusinessActions':sum(action_counts)}
    return result

def parse_scoped_bindings(root: Path):
    classes={}
    for p in root.glob('tests/**/StepDefinitions/*.cs'):
        text=p.read_text(errors='ignore')
        sm=FEATURE_SCOPE_RE.search(text)
        if not sm: continue
        feature=sm.group(1)
        rows=[]
        lines=text.splitlines()
        pending=[]
        for i,line in enumerate(lines,1):
            bm=BINDING_RE.search(line)
            if bm:
                pending.append(bm.group(1).replace('""','"'))
                continue
            mm=METHOD_RE.search(line)
            if mm and pending:
                # Three attributes are normally emitted for one business text. Keep unique patterns only.
                for pattern in dict.fromkeys(pending): rows.append({'pattern':pattern,'method':mm.group(1),'line':i})
                pending=[]
            elif line.strip() and not line.lstrip().startswith('[') and pending and ('public ' not in line):
                # tolerate XML/comments/attributes but avoid carrying a binding into a later method
                pass
        classes[feature]={'file':str(p.relative_to(root)),'bindings':rows}
    return classes

def binding_for(step: str, info):
    hits=[]
    for b in info.get('bindings',[]):
        try:
            if re.fullmatch(b['pattern'],step): hits.append(b)
        except re.error:
            # Generated bindings are almost always literal anchored regexes; conservative fallback.
            literal=b['pattern']
            if literal.startswith('^'): literal=literal[1:]
            if literal.endswith('$'): literal=literal[:-1]
            literal=re.sub(r'\\([\-()&.+?])',r'\1',literal)
            if literal==step: hits.append(b)
    # three Given/When/Then attrs share one method; de-duplicate method/line
    uniq={(h['method'],h['line']):h for h in hits}
    return list(uniq.values())

def main():
    ap=argparse.ArgumentParser()
    ap.add_argument('--root',required=True,type=Path)
    ap.add_argument('--source-html',required=True,type=Path)
    ap.add_argument('--out',required=True,type=Path)
    args=ap.parse_args()
    root=args.root.resolve(); src=args.source_html.resolve()
    source=parse_source(src)
    scoped=parse_scoped_bindings(root)
    generated={}
    for f in root.glob('tests/**/*.feature'):
        txt=f.read_text(errors='ignore')
        fm=re.search(r'^Feature:\s*(.+)$',txt,re.M)
        if fm: generated[norm(fm.group(1))]={'file':str(f.relative_to(root)),'steps':feature_steps(f)}

    rows=[]; all_ok=True; cldc_missing=[]; binding_missing=[]; binding_ambiguous=[]; declaration_order=[]
    for name,s in source.items():
        g=generated.get(name)
        if not g:
            rows.append({'feature':name,'exactSequence':False,'reason':'generated feature missing'}); all_ok=False; continue
        exact=s['steps']==g['steps']
        row={'feature':name,'featureFile':g['file'],'sourceSteps':len(s['steps']),'generatedSteps':len(g['steps']),
             'sourceBusinessActions':s['sourceBusinessActions'],'exactSequence':exact}
        if not exact:
            first=None
            for i,(a,b) in enumerate(zip(s['steps'],g['steps'])):
                if a!=b: first={'index':i+1,'source':a,'generated':b}; break
            if first is None and len(s['steps'])!=len(g['steps']): first={'index':min(len(s['steps']),len(g['steps']))+1,'source':'<end>' if len(s['steps'])<len(g['steps']) else s['steps'][len(g['steps'])],'generated':'<end>' if len(g['steps'])<len(s['steps']) else g['steps'][len(s['steps'])]}
            row['firstMismatch']=first; all_ok=False
        # Feature-scoped step definitions intentionally exclude shared open/sign-in bindings.
        info=scoped.get(name,{'bindings':[]})
        scoped_hits=[]
        for pos,step in enumerate(g['steps'],1):
            hits=binding_for(step,info)
            if len(hits)==1: scoped_hits.append((pos,step,hits[0]))
            elif len(hits)>1: binding_ambiguous.append({'feature':name,'step':step,'methods':[h['method'] for h in hits]}); all_ok=False
            else:
                # shared application/auth orchestration is expected for these business steps
                if re.search(r'open the configured|sign in to',step,re.I): continue
                binding_missing.append({'feature':name,'step':step}); all_ok=False
                if 'Duck Creek' in name or name.startswith(('BAP','CPP','CP ','GL ','IM ','UMB ','WC ','Smoke Test Auto','Smoke Test Cycle','Smoke Test RV')):
                    cldc_missing.append({'feature':name,'step':step})
        lines=[x[2]['line'] for x in scoped_hits]
        ordered=all(a<=b for a,b in zip(lines,lines[1:]))
        declaration_order.append({'feature':name,'resolvedFeatureScopedSteps':len(lines),'declarationOrderMatchesFeatureOrder':ordered})
        if not ordered: all_ok=False
        rows.append(row)

    # Same-page duplicate test-id audit.
    duplicate_testids=[]; total_testid=0; locator_files=0
    for p in root.glob('tests/**/*Locators.cs'):
        locator_files+=1; vals=re.findall(r'GetByTestId\("([^"]+)"',p.read_text(errors='ignore')); total_testid+=len(vals)
        dup=sorted({v for v in vals if vals.count(v)>1})
        if dup: duplicate_testids.append({'file':str(p.relative_to(root)),'values':dup}); all_ok=False

    result={
      'release':'v49-source-ordered-locator-mature',
      'sourceReference':{'name':src.name,'sha256':sha256(src)},
      'featuresExpected':32,'featuresCompared':len(rows),'exactFeatureSequences':sum(1 for x in rows if x.get('exactSequence')),
      'featureSequenceGate':'PASS' if len(rows)==32 and all(x.get('exactSequence') for x in rows) else 'FAIL',
      'stepDefinitionBindingMissing':binding_missing,
      'stepDefinitionBindingAmbiguous':binding_ambiguous,
      'stepDefinitionDeclarationOrder':declaration_order,
      'stepDefinitionOrderGate':'PASS' if not binding_missing and not binding_ambiguous and all(x['declarationOrderMatchesFeatureOrder'] for x in declaration_order) else 'FAIL',
      'clDcMissingBusinessSteps':cldc_missing,
      'clDcCompletenessGate':'PASS' if not cldc_missing else 'FAIL',
      'locatorAudit':{'locatorFiles':locator_files,'getByTestIdCalls':total_testid,'samePageDuplicateTestIds':duplicate_testids,
                      'samePageTestIdGate':'PASS' if not duplicate_testids else 'FAIL'},
      'features':rows,
    }
    result['overallGate']='PASS' if result['featureSequenceGate']=='PASS' and result['stepDefinitionOrderGate']=='PASS' and result['clDcCompletenessGate']=='PASS' and result['locatorAudit']['samePageTestIdGate']=='PASS' else 'FAIL'
    args.out.parent.mkdir(parents=True,exist_ok=True); args.out.write_text(json.dumps(result,indent=2))
    print(json.dumps({k:result[k] for k in ['featuresCompared','exactFeatureSequences','featureSequenceGate','stepDefinitionOrderGate','clDcCompletenessGate','overallGate']},indent=2))
    return 0 if result['overallGate']=='PASS' else 1

if __name__=='__main__': raise SystemExit(main())
