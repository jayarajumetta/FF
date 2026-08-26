#!/usr/bin/env python3
from __future__ import annotations
import hashlib,json,os,shutil,zipfile,datetime
from pathlib import Path
ROOT=Path('/mnt/data/FF-bop-complete-e2e-v58')
MNT=Path('/mnt/data')
OUT=MNT/'FF-bop-complete-e2e-v58.zip'
MAPOUT=MNT/'FF-bop-v58-generated-mappings.zip'

def status(name):
 p=MNT/name
 if not p.exists():return None
 try:return int(p.read_text().strip())
 except:return p.read_text().strip()
def sha(p):
 h=hashlib.sha256()
 with open(p,'rb') as f:
  for b in iter(lambda:f.read(1024*1024),b''):h.update(b)
 return h.hexdigest()
def size_tree(p):return sum(x.stat().st_size for x in p.rglob('*') if x.is_file()) if p.exists() else 0

def load(p,default=None):
 try:return json.loads(Path(p).read_text())
 except:return default
verify=load(ROOT/'reports/v58-verification.json',{}) or {}
full=load(ROOT/'reports/full-export-validation.json',{}) or {}
status_candidates={p.name:status(p.name) for p in MNT.glob('v58-*.status')}
# use newest semantic statuses when present
critical=[]
if not verify.get('passed'):critical.append('v58 verification report did not pass')
if not full.get('passed'):critical.append('full export validation did not pass')
for name in ['v58-tests-r9.status','v58-verify-final.status','v58-v57-regression-tests.status']:
 v=status(name)
 if v not in (0,None):critical.append(f'{name}={v}')
for name in ['CL-DC','PL-DC','CL-EQ']:
 vals=[status(f'v58-{name}-convert-r9.status'),status(f'v58-{name}-convert-final.status')]
 vals=[v for v in vals if v is not None]
 if vals and vals[-1]!=0:critical.append(f'{name} final conversion status={vals[-1]}')
manifest={
 'version':'58.0.0','generatedAt':datetime.datetime.now(datetime.timezone.utc).isoformat(),
 'passed':not critical,'critical':critical,'verification':verify.get('counts'),
 'fullExportPassed':full.get('passed'),'statuses':status_candidates,
 'validationExportBytes':size_tree(ROOT/'validation-exports'),
}
(ROOT/'reports/v58-release-manifest.json').write_text(json.dumps(manifest,indent=2))
if critical:
 (ROOT/'reports/RELEASE-BLOCKERS.json').write_text(json.dumps(manifest,indent=2))
 for p in [OUT,MAPOUT,MNT/'FF-bop-complete-e2e-v58.zip.sha256',MNT/'FF-bop-v58-generated-mappings.zip.sha256']:
  p.unlink(missing_ok=True)
 print(json.dumps(manifest,indent=2));raise SystemExit(2)
(ROOT/'reports/RELEASE-BLOCKERS.json').unlink(missing_ok=True)
# Remove build-only bulk and caches from source archive, never source or evidence reports.
for p in ROOT.rglob('__pycache__'):
 if p.is_dir():shutil.rmtree(p,ignore_errors=True)
for name in ['node_modules','.git','.pytest_cache']:
 p=ROOT/name
 if p.exists():shutil.rmtree(p,ignore_errors=True)
# File inventory before zipping.
exclude_parts={'node_modules','.git','__pycache__'}
files=[]
for p in ROOT.rglob('*'):
 if not p.is_file() or any(part in exclude_parts for part in p.parts):continue
 rel=p.relative_to(ROOT)
 files.append({'path':str(rel).replace(os.sep,'/'),'bytes':p.stat().st_size,'sha256':sha(p)})
(ROOT/'reports/v58-file-inventory.json').write_text(json.dumps({'version':'58.0.0','files':files},indent=2))
# Main package includes everything, including generated cross-checks.
with zipfile.ZipFile(OUT,'w',zipfile.ZIP_DEFLATED,compresslevel=9,allowZip64=True) as z:
 for p in ROOT.rglob('*'):
  if not p.is_file() or any(part in exclude_parts for part in p.parts):continue
  z.write(p,Path(ROOT.name)/p.relative_to(ROOT))
# Supplemental mapping-only archive makes it easy to inspect every testcase without the source tree.
if (ROOT/'validation-exports').exists():
 with zipfile.ZipFile(MAPOUT,'w',zipfile.ZIP_DEFLATED,compresslevel=9,allowZip64=True) as z:
  for p in (ROOT/'validation-exports').rglob('*'):
   if p.is_file():z.write(p,Path('v58-generated-mappings')/p.relative_to(ROOT/'validation-exports'))
# Integrity test.
with zipfile.ZipFile(OUT) as z:
 bad=z.testzip()
 if bad:raise RuntimeError(f'Corrupt main ZIP member: {bad}')
if MAPOUT.exists():
 with zipfile.ZipFile(MAPOUT) as z:
  bad=z.testzip()
  if bad:raise RuntimeError(f'Corrupt mapping ZIP member: {bad}')
(MNT/'FF-bop-complete-e2e-v58.zip.sha256').write_text(f'{sha(OUT)}  {OUT.name}\n')
if MAPOUT.exists():(MNT/'FF-bop-v58-generated-mappings.zip.sha256').write_text(f'{sha(MAPOUT)}  {MAPOUT.name}\n')
manifest.update({'mainZip':{'path':str(OUT),'bytes':OUT.stat().st_size,'sha256':sha(OUT)},'mappingZip':({'path':str(MAPOUT),'bytes':MAPOUT.stat().st_size,'sha256':sha(MAPOUT)} if MAPOUT.exists() else None)})
(ROOT/'reports/v58-release-manifest.json').write_text(json.dumps(manifest,indent=2))
print(json.dumps(manifest,indent=2))
