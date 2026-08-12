from pathlib import Path
import json, re, sys

root = Path(__file__).resolve().parents[1]
errors = []

# Features must stay business-readable and all visible steps must have a binding phrase.
feature_phrases = set()
for path in (root / "Features").rglob("*.feature"):
    text = path.read_text(encoding="utf-8")
    for bad in ("ObjectClass", "Surrogate", "execute Tosca", "execute test case", "execute module"):
        if bad.lower() in text.lower():
            errors.append(f"{path}: source/migration terminology leaked: {bad}")
    for line in text.splitlines():
        m = re.match(r"^\s*(?:Given|When|Then|And)\s+(I .+)$", line)
        if m:
            feature_phrases.add(m.group(1))

bindings = "\n".join(
    p.read_text(encoding="utf-8")
    for p in (root / "StepDefinitions").rglob("*.cs")
)

for phrase in sorted(feature_phrases):
    if f'"{phrase}"' not in bindings:
        errors.append(f"Missing StepDefinition binding: {phrase}")

# Data JSON must remain flat strings and must not contain duplicate state aliases.
for path in (root / "TestData").glob("*.json"):
    obj = json.loads(path.read_text(encoding="utf-8"))
    if not isinstance(obj, dict):
        errors.append(f"{path}: expected flat JSON object")
        continue
    for k, v in obj.items():
        if not isinstance(v, str):
            errors.append(f"{path}: value for {k!r} is not a string")
    aliases = [k for k in ("State", "State Abbv", "State Abbreviation") if k in obj]
    if aliases:
        errors.append(f"{path}: non-canonical state aliases remain: {aliases}")

# Locator classes: no unresolved selectors. XPath is allowed only when annotated REVIEW.
for path in (root / "Pages" / "PageLocators").glob("*.cs"):
    text = path.read_text(encoding="utf-8")
    if "UNRESOLVED:" in text:
        errors.append(f"{path}: unresolved locator")
    lines = text.splitlines()
    for i, line in enumerate(lines):
        if ' = "xpath=' in line or re.search(r' = "//', line):
            previous = lines[i-1] if i else ""
            if "REVIEW:" not in previous:
                errors.append(f"{path}: XPath locator missing REVIEW annotation")

# Required audit artifacts.
for required in (
    root / "Reports" / "EXECUTABLE-LEAF-ACCOUNTING-V28.json",
    root / "Reports" / "LOCATOR-CONFIDENCE-V28.json",
    root / "Integration" / "data-ownership.json",
    root / "Integration" / "runtime-data-flow-v28.json",
    root / "Integration" / "semantic-visibility-policy.json",
):
    if not required.exists():
        errors.append(f"Missing quality artifact: {required}")

if errors:
    print("QUALITY GATE FAILED")
    for error in errors:
        print(" -", error)
    sys.exit(1)

print("QUALITY GATE PASSED")
print(f"Business feature phrases: {len(feature_phrases)}")
