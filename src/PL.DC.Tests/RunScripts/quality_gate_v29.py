from pathlib import Path
import json, re, sys

root = Path(__file__).resolve().parents[1]
errors = []

audit_path = root / "Reports" / "ASSUMPTION-AND-MISSING-LOGIC-AUDIT-V29.json"
if not audit_path.exists():
    errors.append("Missing assumption/missing-logic audit report")
else:
    audit = json.loads(audit_path.read_text(encoding="utf-8"))
    if audit["result"]["blockingIssues"] != 0:
        errors.append(f"Blocking audit issues: {audit['result']['blockingIssues']}")

required = [
    root / "Integration" / "assumption-register-v29.json",
    root / "Reports" / "EXECUTABLE-LEAF-ACCOUNTING-V28.json",
    root / "Reports" / "LOCATOR-CONFIDENCE-V28.json",
    root / "Integration" / "data-ownership.json",
    root / "Integration" / "runtime-data-flow-v28.json",
    root / "Docs" / "ARCHITECTURE.html",
]
for path in required:
    if not path.exists():
        errors.append(f"Missing required artifact: {path.relative_to(root)}")

# Re-run minimal feature/binding scan in case files changed after audit.
bindings = "\n".join(p.read_text(encoding="utf-8") for p in (root / "StepDefinitions").rglob("*.cs"))
for feature in (root / "Features").rglob("*.feature"):
    text = feature.read_text(encoding="utf-8")
    for leak in ("ObjectClass", "Surrogate", "XTestStep", "ActionMode", "execute module", "execute test case"):
        if leak.lower() in text.lower():
            errors.append(f"{feature.relative_to(root)} leaks source term {leak}")
    for line in text.splitlines():
        m = re.match(r"^\s*(?:Given|When|Then|And)\s+(I .+)$", line)
        if m and f'"{m.group(1)}"' not in bindings:
            errors.append(f"Missing binding for: {m.group(1)}")

if errors:
    print("QUALITY GATE FAILED")
    for error in errors:
        print(" -", error)
    sys.exit(1)

print("QUALITY GATE PASSED")
