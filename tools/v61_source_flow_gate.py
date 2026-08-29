from pathlib import Path
import re,sys
root=Path(__file__).resolve().parents[1]
errors=[]
smokes=list((root/'tests/CommercialLines.DuckCreek.Tests/StepDefinitions').glob('*SmokeTestSteps.cs'))
for p in smokes:
 t=p.read_text()
 for required in ['EnterEffectiveDateAsync','EnterProductAsync','ClickStartAsync']:
  if required not in t: errors.append(f'{p.name}: missing {required}')
 if p.name != 'WCSmokeTestSteps.cs' and 'EnterDOBAsync' not in t: errors.append(f'{p.name}: missing DOB')
 if p.name != 'WCSmokeTestSteps.cs' and 'EnterInsuredAndEntityTypeAsync' not in t: errors.append(f'{p.name}: missing dependent InsuredType/EntityType flow')
 if 'BuildQuoteDescription()' not in t: errors.append(f'{p.name}: missing dynamic quote description')
print(f'v61 source-flow gate: smoke files={len(smokes)} errors={len(errors)}')
for e in errors: print('ERROR',e)
sys.exit(1 if errors else 0)
