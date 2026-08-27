#!/usr/bin/env python3
from pathlib import Path
import re, json
ROOT=Path(__file__).resolve().parents[1]
files=sorted(ROOT.glob('tests/*/StepDefinitions/*.cs'))
removed=[]
for p in files:
    lines=p.read_text(encoding='utf-8',errors='ignore').splitlines()
    out=[]; i=0
    while i<len(lines):
        line=lines[i]
        s=line.strip()
        if s.startswith('await ') and 'PauseAsync' not in s and 'NoteAsync' not in s:
            # collapse a contiguous logical run of exactly identical state actions, allowing only blank/comment lines between.
            # Comments are retained once in source position; no if/else/condition line may be crossed.
            j=i+1; bridge=[]
            while j<len(lines) and (not lines[j].strip() or lines[j].lstrip().startswith('//')):
                bridge.append(lines[j]); j+=1
            if j<len(lines) and lines[j].strip()==s:
                out.append(line)
                out.extend(bridge)
                removed.append({'file':str(p.relative_to(ROOT)).replace('\\','/'),'line':j+1,'action':s})
                i=j+1
                # additional identical copies will be handled by comparing to the last emitted action via another local loop
                while i<len(lines):
                    k=i; between=[]
                    while k<len(lines) and (not lines[k].strip() or lines[k].lstrip().startswith('//')):
                        between.append(lines[k]); k+=1
                    if k<len(lines) and lines[k].strip()==s:
                        out.extend(between)
                        removed.append({'file':str(p.relative_to(ROOT)).replace('\\','/'),'line':k+1,'action':s})
                        i=k+1
                        continue
                    break
                continue
        out.append(line); i+=1
    p.write_text('\n'.join(out)+'\n',encoding='utf-8')
report={'version':'57.0','rule':'Remove only exact repeated state actions when no condition/if/else/business statement occurs between them. PauseAsync and NoteAsync are intentionally excluded.','removedCount':len(removed),'removed':removed}
(ROOT/'Artifacts/V57DuplicateStateActionCleanup.json').write_text(json.dumps(report,indent=2),encoding='utf-8')
print(json.dumps({'removedCount':len(removed)},indent=2))
