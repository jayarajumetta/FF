from pathlib import Path
import re
ROOT=Path(__file__).resolve().parents[1]

def strip_strings(line:str)->str:
    out=[]; i=0; quote=None; verb=False
    while i<len(line):
        c=line[i]
        if quote is None:
            if c=='@' and i+1<len(line) and line[i+1]=='"': quote='"'; verb=True; out.extend('  '); i+=2; continue
            if c in ('"',"'"): quote=c; verb=False; out.append(' '); i+=1; continue
            out.append(c); i+=1; continue
        if verb and quote=='"':
            if c=='"' and i+1<len(line) and line[i+1]=='"': out.extend('  '); i+=2; continue
            if c=='"': quote=None; verb=False
            out.append(' '); i+=1; continue
        if c=='\\' and i+1<len(line): out.extend('  '); i+=2; continue
        if c==quote: quote=None
        out.append(' '); i+=1
    return ''.join(out)

for f in (ROOT/'tests/CommercialLines.DuckCreek.Tests/StepDefinitions').glob('*.cs'):
    lines=f.read_text().splitlines(); depth=0; out=[]
    for original in lines:
        stripped=original.strip()
        if not stripped:
            out.append(''); continue
        code=strip_strings(stripped)
        leading_closes=0
        for ch in code:
            if ch=='}': leading_closes+=1
            elif ch.isspace(): continue
            else: break
        indent=max(0,depth-leading_closes)
        out.append('    '*indent+stripped)
        opens=code.count('{'); closes=code.count('}')
        depth=max(0,depth+opens-closes)
    f.write_text('\n'.join(out).rstrip()+'\n')
