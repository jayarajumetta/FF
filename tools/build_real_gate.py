from pathlib import Path
import json, datetime, hashlib
root=Path('/mnt/data/FF-bop-complete-e2e-v58')
inputs=[('CL-DC','/mnt/data/CL-DC.zip'),('PL-DC','/mnt/data/PL_DC.zip'),('CL-EQ','/mnt/data/CL_EQ.zip')]
probe={}
pp=root/'reports/raw-export-probe.json'
if pp.exists():
 try: probe={Path(e['path']).name:e for e in json.loads(pp.read_text()).get('exports',[])}
 except: pass
exports=[]; critical=[]
for name,source in inputs:
 out=root/'validation-exports'/name
 metrics_path=out/'mapping-metrics.json'
 audit_path=out/'reports/v58-mapping-audit.json'
 entry={'name':name,'source':source,'sourceExists':Path(source).exists(),'outputExists':out.exists(),'metricsPath':str(metrics_path.relative_to(root)) if metrics_path.exists() else None}
 if metrics_path.exists():
  try: entry['metrics']=json.loads(metrics_path.read_text())
  except Exception as e: entry['metricsError']=str(e)
 if audit_path.exists():
  try:
   a=json.loads(audit_path.read_text()); entry['audit']=a.get('audit',{}); entry['sourceDecode']=a.get('source',{})
  except Exception as e: entry['auditError']=str(e)
 p=probe.get(Path(source).name)
 if p: entry['rawProbe']=p['stats']; entry['rawDocuments']=len(p.get('documents',[])); entry['rawWarnings']=p.get('warnings',[])
 m=entry.get('metrics',{})
 if not metrics_path.exists(): critical.append(f'{name}: mapping metrics missing')
 elif m.get('entities',0)<=0: critical.append(f'{name}: no entities reconstructed')
 elif m.get('testCases',0)<=0: critical.append(f'{name}: no test cases reconstructed')
 elif m.get('actions',0)<=0: critical.append(f'{name}: no actions reconstructed')
 elif m.get('controls',0)<=0: critical.append(f'{name}: no controls reconstructed')
 elif m.get('locators',0)<=0: critical.append(f'{name}: no locators reconstructed')
 audit_metrics=(entry.get('audit') or {}).get('metrics',{})
 if audit_metrics.get('errors',0)>0: critical.append(f"{name}: {audit_metrics.get('errors')} mapping audit errors")
 entry['gatePassed']=not any(x.startswith(name+':') for x in critical)
 exports.append(entry)
# Independent export identity gate.
hashes=[]
for _,source in inputs:
 if Path(source).exists(): hashes.append(hashlib.sha256(Path(source).read_bytes()).hexdigest())
if len(set(hashes))!=len(hashes): critical.append('Export hashes are not all distinct')
status_files={}
for p in Path('/mnt/data').glob('v58-*.status'):
 status_files[p.name]=p.read_text().strip()
report={'version':'58.0.0','generatedAt':datetime.datetime.now(datetime.timezone.utc).isoformat(),'passed':not critical,'criticalIssues':critical,'statusFiles':status_files,'exports':exports}
(root/'reports/full-export-validation.json').write_text(json.dumps(report,indent=2))
(root/'reports/full-export-validation.md').write_text('# v58 Full Export Validation\n\n'+('**PASS**' if report['passed'] else '**FAIL**')+'\n\n'+('\n'.join(f'- {x}' for x in critical) if critical else '- All three exports produced native entity graphs, test cases, ordered actions, controls and locator registries.'))
Path('/mnt/data/V58_REAL_GATE_PASS' if report['passed'] else '/mnt/data/V58_REAL_GATE_FAIL').touch()
print(json.dumps(report,indent=2))
