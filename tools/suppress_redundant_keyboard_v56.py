#!/usr/bin/env python3
import re
from pathlib import Path
ROOT=Path(__file__).resolve().parents[1]
enter=re.compile(r'await\s+page\.Enter(\w+)Async\('); press=re.compile(r'await\s+page\.Press(\w+)Async\("([^"]+)"\)'); action=re.compile(r'await\s+page\.(?:Enter|Click|Verify|WaitFor|Select|Capture|Press)(\w+)Async')
removed=0; files=0
for p in ROOT.glob('tests/*/StepDefinitions/*.cs'):
 lines=p.read_text().splitlines(); out=[]; last_enter=None; last_press=None; changed=False
 for line in lines:
  em=enter.search(line)
  pm=press.search(line)
  if pm:
   ctl,key=pm.group(1),pm.group(2).strip().lower().replace('post:','').replace('pre:','')
   # Semantic fill/select now commits/blurs; raw Tosca keyboard steering on the same just-set control is redundant.
   if last_enter==ctl and key in ('click','enter','tab','{tab}','{enter}'):
    out.append(re.match(r'\s*',line).group(0)+f'// v56 suppressed redundant Tosca keyboard steering: {ctl} {pm.group(2)}')
    removed+=1;changed=True;continue
   if last_press==(ctl,key):
    out.append(re.match(r'\s*',line).group(0)+f'// v56 suppressed duplicate keyboard steering: {ctl} {pm.group(2)}')
    removed+=1;changed=True;continue
   last_press=(ctl,key); out.append(line); continue
  am=action.search(line)
  if em: last_enter=em.group(1); last_press=None
  elif am: last_enter=None; last_press=None
  # comments/conditions/data lines do not clear a just-entered control
  out.append(line)
 if changed:p.write_text('\n'.join(out)+'\n');files+=1
print({'filesChanged':files,'suppressed':removed})
