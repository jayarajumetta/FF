from pathlib import Path
import json,re,sys
root=Path(__file__).resolve().parents[1]
smoke=root/'tests/CommercialLines.DuckCreek.Tests/TestData/Smoke'
features=root/'tests/CommercialLines.DuckCreek.Tests/Features'
scenarios=root/'tests/CommercialLines.DuckCreek.Tests/TestData/Scenarios'
report=json.loads((root/'Artifacts/V60SmokeDataConsolidation.json').read_text())
expected={'BAP':44,'CP':16,'GL':16,'IM':16,'WC':34,'CPP':16,'UMB':44}
feature_map={'BAP':'012_BAP_Smoke_Test_AL.feature','CP':'013_CP_Smoke_Test_AZ.feature','GL':'014_GL_Smoke_Test_AZ.feature','IM':'015_IM_Smoke_Test_AZ.feature','WC':'016_WC_Smoke_Test_AL.feature','CPP':'017_CPP_Smoke_Test_AZ.feature','UMB':'018_UMB_Smoke_Test_AL.feature'}
checks={}
checks['base_files']={lob:(smoke/f'{lob}.json').exists() for lob in expected}
checks['state_override_file']=(smoke/'StateOverrides.json').exists()
checks['old_full_smoke_files_remaining']=len([p for p in scenarios.glob('01[2-8]_*.json') if json.loads(p.read_text()).get('dimensions',{}).get('transaction')=='Smoke Test'])
rows={}
for lob,fn in feature_map.items():
 t=(features/fn).read_text()
 rows[lob]=len(re.findall(r'^\s*\|\s*[A-Z]{2}\s*\|\s*[^|]+\|\s*$',t,re.M))
checks['feature_state_rows']=rows
checks['feature_rows_match']=all(rows[k]==v for k,v in expected.items())
checks['total_smoke_variants']=sum(rows.values())
checks['no_datafile_column']=all('dataFile' not in (features/fn).read_text() for fn in feature_map.values())
checks['layered_binding']='LoadSmokeScenarioData' in (root/'tests/CommercialLines.DuckCreek.Tests/StepDefinitions/ApplicationSteps.cs').read_text()
checks['layered_loader']='public void LoadSmoke(' in (root/'src/InsuranceAutomation.Core/ScenarioData.cs').read_text()
checks['equivalence_mismatches']=report['equivalence']['mismatches']
checks['equivalence_value_comparisons']=report['equivalence']['valueComparisons']
checks['runtime_file_count']=report['runtimeDataFootprint']['v60SmokeFiles']
checks['runtime_reduction_percent']=report['runtimeDataFootprint']['reductionPercent']
checks['source_lineage_files']=len(list((root/'Artifacts/V60SmokeSourceLineage').glob('*.json')))
over=json.loads((smoke/'StateOverrides.json').read_text()).get('overrides',{})
checks['state_override_entries']=sum(len(v) for v in over.values())
status=(all(checks['base_files'].values()) and checks['state_override_file'] and checks['old_full_smoke_files_remaining']==0 and checks['feature_rows_match'] and checks['total_smoke_variants']==186 and checks['no_datafile_column'] and checks['layered_binding'] and checks['layered_loader'] and checks['equivalence_mismatches']==0 and checks['runtime_file_count']==8 and checks['source_lineage_files']==7)
out={'release':'v60-cldc-smoke-layered-data','status':'PASS' if status else 'FAIL','checks':checks}
print(json.dumps(out,indent=2))
sys.exit(0 if status else 1)
