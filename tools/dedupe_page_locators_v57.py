#!/usr/bin/env python3
import re
from pathlib import Path
ROOT=Path(__file__).resolve().parents[1]
pat=re.compile(r'(public\s+ILocator\s+(\w+)\s*=>\s*)(.*?)(;)',re.S)
total=0
for p in ROOT.glob('tests/*/Pages/Locators/*Locators.cs'):
 text=p.read_text(); seen={}
 def repl(m):
  global total
  name=m.group(2); expr=' '.join(m.group(3).split())
  technical=any(x in expr for x in ('[id=','duckcreekid','fieldref','GetByTestId(','[name='))
  if technical and expr in seen:
   total+=1
   return f'// v57 canonical alias: same physical raw-Tosca control as {seen[expr]}\n    '+m.group(1)+seen[expr]+m.group(4)
  if technical:seen[expr]=name
  return m.group(0)
 new=pat.sub(repl,text)
 if new!=text:p.write_text(new)
print({'technicalLocatorAliasesCreated':total})
