from pathlib import Path
import json,sys,xml.etree.ElementTree as ET
root=Path(__file__).resolve().parents[1]
errors=[]
report=json.loads((root/"Reports/STATIC-COMPILER-CONTRACT-V35.json").read_text())
for d in ("BOP_EQ","PL_DC"):
    base=report["baselineCompilerContracts"][d]["staticCompilerContract"]["errors"]
    sanity=report["combinedSanity"][d]["errors"]
    errors += [f"{d} v34 compiler contract: {x}" for x in base]
    errors += [f"{d} combined sanity: {x}" for x in sanity]
for p in root.rglob("*.json"):
    try: json.loads(p.read_text(encoding="utf-8"))
    except Exception as e: errors.append(f"Invalid JSON {p.relative_to(root)}: {e}")
for p in root.rglob("*.csproj"):
    try: ET.parse(p)
    except Exception as e: errors.append(f"Invalid project XML {p.relative_to(root)}: {e}")
if not (root/"ClientAutomation.sln").exists(): errors.append("ClientAutomation.sln missing")
if errors:
    print("QUALITY GATE FAILED")
    for e in errors: print(" -",e)
    sys.exit(1)
print("QUALITY GATE PASSED")
print("Both domain compiler contracts remain zero-error and the combined repository sanity checks pass.")
