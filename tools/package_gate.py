#!/usr/bin/env python3
"""Static client-package quality gate for the CLDC/CLEQ/PLDC ReqnRoll solution.

The authoritative .NET compilation and browser execution run in Azure DevOps or a client
workstation with .NET 8 and application access. This gate validates all source contracts that
can be proven without those external dependencies: feature/binding coverage, locator references,
layered test-data reconstruction, protected CLDC Smoke/NUnit checksums, YAML/JSON/XML syntax,
and consolidated-report generation.
"""
from __future__ import annotations

import ast
import collections
import hashlib
import importlib.util
import json
import re
import shutil
import subprocess
import sys
import tempfile
import xml.etree.ElementTree as ET
from pathlib import Path
from typing import Any

try:
    import yaml  # type: ignore
except ImportError:  # Azure build installs PyYAML below if required.
    yaml = None

sys.dont_write_bytecode = True
ROOT = Path(__file__).resolve().parents[1]
VALIDATION_DIR = ROOT / "Artifacts" / "Validation"
ERRORS: list[str] = []
WARNINGS: list[str] = []
STATS: dict[str, Any] = {}
APPS = [
    "CommercialLines.DuckCreek.Tests",
    "CommercialLines.ExpertQuote.Tests",
    "PersonalLines.DuckCreek.Tests",
]
JUNK_DIRS = {".vs", "bin", "obj", "__pycache__", ".idea"}


def fail(message: str) -> None:
    ERRORS.append(message)


def warn(message: str) -> None:
    WARNINGS.append(message)


def sha256(path: Path) -> str:
    digest = hashlib.sha256()
    with path.open("rb") as stream:
        for chunk in iter(lambda: stream.read(1024 * 1024), b""):
            digest.update(chunk)
    return digest.hexdigest()


def csharp_balance(text: str) -> tuple[int, int, int]:
    """Balance {}, (), [] while ignoring ordinary/verbatim strings, chars and comments."""
    braces = parens = brackets = 0
    i = 0
    state = "code"
    raw_quotes = 0
    while i < len(text):
        c = text[i]
        n = text[i + 1] if i + 1 < len(text) else ""
        if state == "code":
            if c == "/" and n == "/":
                state = "line"; i += 2; continue
            if c == "/" and n == "*":
                state = "block"; i += 2; continue
            if c == "@" and n == '"':
                state = "verbatim"; i += 2; continue
            if text.startswith('"""', i):
                raw_quotes = 3
                while i + raw_quotes < len(text) and text[i + raw_quotes] == '"':
                    raw_quotes += 1
                state = "raw"; i += raw_quotes; continue
            if c == '"':
                state = "string"; i += 1; continue
            if c == "'":
                state = "char"; i += 1; continue
            if c == "{": braces += 1
            elif c == "}": braces -= 1
            elif c == "(": parens += 1
            elif c == ")": parens -= 1
            elif c == "[": brackets += 1
            elif c == "]": brackets -= 1
            if min(braces, parens, brackets) < 0:
                return braces, parens, brackets
            i += 1; continue
        if state == "line":
            if c == "\n": state = "code"
            i += 1; continue
        if state == "block":
            if c == "*" and n == "/": state = "code"; i += 2; continue
            i += 1; continue
        if state == "string":
            if c == "\\": i += 2; continue
            if c == '"': state = "code"
            i += 1; continue
        if state == "verbatim":
            if c == '"' and n == '"': i += 2; continue
            if c == '"': state = "code"
            i += 1; continue
        if state == "raw":
            if text.startswith('"' * raw_quotes, i):
                state = "code"; i += raw_quotes; continue
            i += 1; continue
        if state == "char":
            if c == "\\": i += 2; continue
            if c == "'": state = "code"
            i += 1; continue
    return braces, parens, brackets


def json_merge_patch(target: Any, patch: Any) -> Any:
    if not isinstance(patch, dict):
        return patch
    result = dict(target) if isinstance(target, dict) else {}
    for key, value in patch.items():
        if value is None:
            result.pop(key, None)
        else:
            result[key] = json_merge_patch(result.get(key), value)
    return result


def load_reporter():
    path = ROOT / "tools" / "generate_consolidated_report.py"
    spec = importlib.util.spec_from_file_location("insurance_consolidated_report", path)
    if spec is None or spec.loader is None:
        raise RuntimeError(f"Could not load {path}")
    module = importlib.util.module_from_spec(spec)
    sys.modules[spec.name] = module
    spec.loader.exec_module(module)
    return module


def parse_feature(path: Path) -> dict[str, Any]:
    feature = ""
    steps: list[str] = []
    headers: list[str] | None = None
    rows: list[dict[str, str]] = []
    commented_rows: list[dict[str, str]] = []
    in_examples = False
    adjacent: str | None = None
    duplicate_adjacent: list[str] = []
    for line in path.read_text(encoding="utf-8", errors="ignore").splitlines():
        stripped = line.strip()
        if stripped.startswith("Feature:"):
            feature = stripped.split(":", 1)[1].strip()
        match = re.match(r"^(Given|When|Then|And|But)\s+(.+)$", stripped)
        if match:
            step = match.group(2).strip()
            steps.append(step)
            if adjacent == step:
                duplicate_adjacent.append(step)
            adjacent = step
        elif stripped and not stripped.startswith(("#", "@")):
            adjacent = None
        if stripped == "Examples:":
            in_examples = True
            headers = None
            continue
        if not in_examples:
            continue
        row_text = stripped
        commented = False
        if row_text.startswith("#"):
            row_text = row_text[1:].strip()
            commented = True
        if not row_text.startswith("|"):
            continue
        cells = [cell.strip() for cell in row_text.strip("|").split("|")]
        if headers is None:
            headers = cells
            continue
        record = dict(zip(headers, cells))
        (commented_rows if commented else rows).append(record)
    return {
        "feature": feature,
        "steps": steps,
        "rows": rows,
        "commentedRows": commented_rows,
        "duplicateAdjacentSteps": duplicate_adjacent,
    }


# Remove Python byte-code caches before evaluating/package source. The gate imports the
# report generator, so this keeps repeated local and pipeline runs idempotent.
for cache in list(ROOT.rglob("__pycache__")):
    shutil.rmtree(cache, ignore_errors=True)

# Repository shape and excluded build artefacts.
junk = sorted(
    str(path.relative_to(ROOT)).replace("\\", "/")
    for path in ROOT.rglob("*")
    if path.is_dir() and path.name in JUNK_DIRS
)
if junk:
    fail(f"Build/editor cache directories are present: {junk[:20]}")

features = sorted(ROOT.glob("tests/*/Features/*.feature"))
STATS["featureCount"] = len(features)
if len(features) != 32:
    fail(f"Expected 32 feature files, found {len(features)}")

# JSON and project XML syntax.
json_files = [path for path in ROOT.rglob("*.json") if not any(part in JUNK_DIRS for part in path.parts)]
for path in json_files:
    try:
        json.loads(path.read_text(encoding="utf-8"))
    except Exception as exc:
        fail(f"Invalid JSON {path.relative_to(ROOT)}: {exc}")
STATS["jsonCount"] = len(json_files)

for path in ROOT.rglob("*.csproj"):
    try:
        ET.parse(path)
    except Exception as exc:
        fail(f"Invalid project XML {path.relative_to(ROOT)}: {exc}")

# C# structural integrity.
cs_files = [path for path in ROOT.rglob("*.cs") if not any(part in JUNK_DIRS for part in path.parts)]
for path in cs_files:
    text = path.read_text(encoding="utf-8", errors="ignore")
    balance = csharp_balance(text)
    if balance != (0, 0, 0):
        fail(f"C# delimiter imbalance {path.relative_to(ROOT)}: {balance}")
    if path.name.endswith("Steps.cs") and "^(.*)$" in text:
        fail(f"Catch-all ReqnRoll binding found in {path.relative_to(ROOT)}")
STATS["csharpFiles"] = len(cs_files)

# Parse features, verify all referenced data and resolve every active scenario's steps.
try:
    reporter = load_reporter()
    bindings = reporter.discover_bindings(ROOT)
    STATS["reqnrollBindings"] = len(bindings)
except Exception as exc:
    reporter = None
    bindings = []
    fail(f"Consolidated reporter/binding discovery failed: {exc}")

feature_stats: dict[str, Any] = {}
missing_data: list[str] = []
unresolved_steps: list[str] = []
for path in features:
    parsed = parse_feature(path)
    app_root = path.parents[1]
    active_rows = parsed["rows"]
    commented_rows = parsed["commentedRows"]
    feature_stats[path.name] = {
        "activeRows": len(active_rows),
        "commentedRows": len(commented_rows),
    }
    if parsed["duplicateAdjacentSteps"]:
        fail(f"{path.name}: exact adjacent duplicate Gherkin steps {parsed['duplicateAdjacentSteps']}")
    for row in active_rows + commented_rows:
        for key, value in row.items():
            if key.lower().endswith("file") and value.startswith("TestData/"):
                candidate = app_root / value
                if not candidate.exists():
                    missing_data.append(f"{path.name}: {value}")
    if reporter is not None:
        substitutions = active_rows[0] if active_rows else {}
        for raw_step in parsed["steps"]:
            executed = re.sub(r"<([^>]+)>", lambda m: substitutions.get(m.group(1), m.group(0)), raw_step)
            display, _, _, _ = reporter.resolve_binding(bindings, parsed["feature"], executed)
            if display == "Unresolved":
                unresolved_steps.append(f"{path.name}: {executed}")
if missing_data:
    fail(f"Feature example data files are missing: {missing_data[:30]}")
if unresolved_steps:
    fail(f"Feature steps without a scoped/global ReqnRoll binding: {unresolved_steps[:30]}")
STATS["featureExamples"] = feature_stats
STATS["featureStepsResolved"] = sum(len(parse_feature(path)["steps"]) for path in features)

# Intentionally commented CLDC Smoke rows remain protected as requested.
cldc_smoke = [parse_feature(path) for path in features if "CommercialLines.DuckCreek.Tests" in str(path) and "Smoke" in path.name]
cldc_smoke_active = sum(len(item["rows"]) for item in cldc_smoke)
cldc_smoke_commented = sum(len(item["commentedRows"]) for item in cldc_smoke)
STATS["cldcSmoke"] = {
    "features": len(cldc_smoke),
    "activeExamples": cldc_smoke_active,
    "commentedExamples": cldc_smoke_commented,
    "availableVariants": cldc_smoke_active + cldc_smoke_commented,
}
if (len(cldc_smoke), cldc_smoke_active, cldc_smoke_commented) != (7, 7, 179):
    fail(f"Protected CLDC Smoke matrix changed: expected 7 features / 7 active / 179 commented, found {len(cldc_smoke)} / {cldc_smoke_active} / {cldc_smoke_commented}")

# Full EQ Smoke state matrices.
def active_codes(feature_name: str) -> list[str]:
    path = next((item for item in features if item.name == feature_name), None)
    if path is None:
        return []
    return [row.get("stateCode", "") for row in parse_feature(path)["rows"]]

bop_codes = active_codes("03_EQ_BOP_Smoke_Test_MO.feature")
sfp_codes = active_codes("04_EQ_SFP_Smoke_Test_MN.feature")
STATS["eqSmoke"] = {"BOP": len(bop_codes), "SFP": len(sfp_codes)}
if len(bop_codes) != 45 or len(set(bop_codes)) != 45:
    fail(f"EQ BOP Smoke must contain 45 unique active state examples; found {len(bop_codes)}/{len(set(bop_codes))}")
if len(sfp_codes) != 35 or len(set(sfp_codes)) != 35:
    fail(f"EQ SFP Smoke must contain 35 unique active state examples; found {len(sfp_codes)}/{len(set(sfp_codes))}")

lineage_path = VALIDATION_DIR / "eq-smoke-state-lineage.json"
if not lineage_path.exists():
    fail("EQ Smoke state-lineage manifest is missing")
else:
    lineage = json.loads(lineage_path.read_text(encoding="utf-8"))
    for flow, expected_codes in (("BOP", bop_codes), ("SFP", sfp_codes)):
        entries = lineage.get("flows", {}).get(flow, {}).get("entries", [])
        lineage_codes = [entry.get("stateCode", "") for entry in entries]
        if set(lineage_codes) != set(expected_codes):
            fail(f"EQ {flow} lineage does not match the feature state matrix")
        for entry in entries:
            data_path = ROOT / "tests" / "CommercialLines.ExpertQuote.Tests" / entry.get("dataFile", "")
            if not data_path.exists():
                fail(f"EQ {flow} lineage data file missing: {entry.get('dataFile')}")
            elif sha256(data_path) != entry.get("sha256"):
                fail(f"EQ {flow} lineage checksum mismatch: {entry.get('dataFile')}")
            donor = entry.get("stateDonor", "")
            if donor and not (data_path.parent / donor).exists():
                fail(f"EQ {flow} Tosca donor missing: {donor}")

# Layered data must reconstruct every original scenario exactly.
layered_stats: dict[str, Any] = {}
for app in APPS:
    app_root = ROOT / "tests" / app
    scenario_dir = app_root / "TestData" / "Scenarios"
    layered_root = app_root / "TestData" / "Layered"
    manifest_path = layered_root / "manifest.json"
    scenarios = sorted(scenario_dir.glob("*.json"))
    if not manifest_path.exists():
        fail(f"{app}: layered-data manifest is missing")
        continue
    manifest = json.loads(manifest_path.read_text(encoding="utf-8"))
    entries = manifest.get("entries", {})
    if set(entries) != {path.name for path in scenarios}:
        missing = sorted({path.name for path in scenarios} - set(entries))
        extra = sorted(set(entries) - {path.name for path in scenarios})
        fail(f"{app}: layered manifest/source mismatch; missing={missing[:10]} extra={extra[:10]}")
    reconstructed = 0
    for source in scenarios:
        entry = entries.get(source.name)
        if not isinstance(entry, dict):
            continue
        base_path = app_root / "TestData" / entry.get("baseFile", "")
        overrides_path = app_root / "TestData" / entry.get("overridesFile", "")
        key = entry.get("overrideKey", "")
        if not base_path.exists() or not overrides_path.exists():
            fail(f"{app}: layered files missing for {source.name}")
            continue
        base = json.loads(base_path.read_text(encoding="utf-8"))
        override_root = json.loads(overrides_path.read_text(encoding="utf-8"))
        patch = override_root.get("overrides", {}).get(key, object())
        if patch.__class__ is object:
            fail(f"{app}: override key missing for {source.name}: {key}")
            continue
        merged = json_merge_patch(base, patch)
        original = json.loads(source.read_text(encoding="utf-8"))
        if merged != original:
            fail(f"{app}: layered reconstruction differs from {source.name}")
            continue
        if entry.get("sourceSha256") != sha256(source):
            fail(f"{app}: source checksum mismatch in layered manifest for {source.name}")
            continue
        reconstructed += 1
    layered_stats[app] = {"scenarioRecords": len(scenarios), "reconstructedExactly": reconstructed}
STATS["layeredTestData"] = layered_stats

scenario_data = (ROOT / "src" / "InsuranceAutomation.Core" / "ScenarioData.cs").read_text(encoding="utf-8")
for token in ["OpenScenarioDocument", "ApplyMergePatch", 'Path.Combine(testDataRoot, "Layered", "manifest.json")']:
    if token not in scenario_data:
        fail(f"Layered runtime loader is missing contract: {token}")

# Protected CLDC Smoke and NUnit evidence implementation checksums.
protected_path = VALIDATION_DIR / "uploaded-protected-baseline.sha256.json"
protected_ok = 0
if not protected_path.exists():
    fail("Protected baseline checksum manifest is missing")
else:
    protected = json.loads(protected_path.read_text(encoding="utf-8"))
    for relative, expected in protected.items():
        path = ROOT / relative
        if not path.exists():
            fail(f"Protected file missing: {relative}")
        elif sha256(path) != expected:
            fail(f"Protected file changed: {relative}")
        else:
            protected_ok += 1
    STATS["protectedFiles"] = {"expected": len(protected), "verified": protected_ok}

# Locator class/member integrity and EQ Angular locator rules.
locator_stats: dict[str, Any] = {}
for app in APPS:
    app_root = ROOT / "tests" / app
    locator_dir = app_root / "Pages" / "Locators"
    classes: dict[str, set[str]] = {}
    properties = 0
    for path in locator_dir.glob("*.cs"):
        text = path.read_text(encoding="utf-8", errors="ignore")
        class_match = re.search(r"\bclass\s+(\w+Locators)\b", text)
        if not class_match:
            fail(f"{app}/{path.name}: locator class declaration not found")
            continue
        members = re.findall(r"public\s+ILocator\s+(\w+)\s*(?:=>|\{|\()", text)
        duplicates = [name for name, count in collections.Counter(members).items() if count > 1]
        if duplicates:
            fail(f"{app}/{path.name}: duplicate locator members {duplicates}")
        classes[class_match.group(1)] = set(members)
        properties += len(members)
        if 'Locator("")' in text or "Locator(string.Empty)" in text:
            fail(f"{app}/{path.name}: empty locator")
        malformed = [
            r'id=\\"\\"', r'name=\\"\\"', r'data-testid=\\"\\"', r'formcontrolname=\\"\\"',
            r'id=\\"\\\\\\"', r'name=\\"\\\\\\"',
        ]
        if any(re.search(pattern, text) for pattern in malformed):
            fail(f"{app}/{path.name}: malformed quoted selector")
    missing_refs: list[str] = []
    for page in (app_root / "Pages").glob("*Page.cs"):
        text = page.read_text(encoding="utf-8", errors="ignore")
        fields = {variable: class_name for class_name, variable in re.findall(r"private\s+readonly\s+(\w+Locators)\s+(\w+)\s*;", text)}
        for variable, class_name in fields.items():
            if class_name not in classes:
                missing_refs.append(f"{page.name}:{class_name}")
                continue
            for member in re.findall(rf"\b{re.escape(variable)}\.(\w+)", text):
                if member not in classes[class_name]:
                    missing_refs.append(f"{page.name}:{variable}.{member}->{class_name}")
    if missing_refs:
        fail(f"{app}: page references missing locator members {missing_refs[:30]}")
    locator_stats[app] = {"members": properties, "missingPageReferences": len(missing_refs)}
STATS["locators"] = locator_stats

eq_locator_text = "\n".join(
    path.read_text(encoding="utf-8", errors="ignore")
    for path in (ROOT / "tests" / "CommercialLines.ExpertQuote.Tests" / "Pages" / "Locators").glob("*.cs")
)
for forbidden in ["duckcreekid", "data-duckcreekid", "fieldref="]:
    if forbidden in eq_locator_text.lower():
        fail(f"ExpertQuote locator repository contains forbidden Duck Creek selector token: {forbidden}")
for required in ["GetByTestId", "[id=", "GetByRole", ":has-text"]:
    if required not in eq_locator_text:
        warn(f"ExpertQuote locator repository does not contain expected Angular/stable selector style: {required}")

# Azure YAML syntax and root aliases.
yaml_paths = [ROOT / ".azuredevops" / "build.yml", ROOT / ".azuredevops" / "release.yml"]
for path in yaml_paths:
    if not path.exists():
        fail(f"Azure pipeline missing: {path.relative_to(ROOT)}")
    elif yaml is None:
        warn("PyYAML is unavailable; Azure YAML parse was skipped")
    else:
        try:
            yaml.safe_load(path.read_text(encoding="utf-8"))
        except Exception as exc:
            fail(f"Invalid Azure YAML {path.relative_to(ROOT)}: {exc}")
for alias, source in [
    (ROOT / "azure-pipelines-ci.yml", yaml_paths[0]),
    (ROOT / "azure-pipelines-cd.yml", yaml_paths[1]),
]:
    if not alias.exists():
        fail(f"Root pipeline alias missing: {alias.name}")
    elif source.exists() and alias.read_bytes() != source.read_bytes():
        fail(f"Root pipeline alias is out of sync: {alias.name}")
release_text = yaml_paths[1].read_text(encoding="utf-8") if yaml_paths[1].exists() else ""
for token in ["ConsolidatedReportAndEmail", "generate_consolidated_report.py", "send_consolidated_report.py", "consolidated-test-report"]:
    if token not in release_text:
        fail(f"Azure release pipeline missing consolidated-report contract: {token}")

# Consolidated reporter syntax and functional self-test.
for script in [ROOT / "tools" / "generate_consolidated_report.py", ROOT / "tools" / "send_consolidated_report.py"]:
    try:
        ast.parse(script.read_text(encoding="utf-8"), filename=str(script))
    except SyntaxError as exc:
        fail(f"Python syntax failed for {script.relative_to(ROOT)}: {exc}")

with tempfile.TemporaryDirectory(prefix="insurance-report-gate-") as temporary:
    temp = Path(temporary)
    evidence = temp / "evidence" / "case"
    output = temp / "output"
    evidence.mkdir(parents=True)
    sample = {
        "feature": "BAP Basic Policy",
        "scenario": "Package gate reporter self-test",
        "status": "PASS",
        "durationMilliseconds": 125.0,
        "steps": [{
            "order": 1,
            "text": "I enter individual client information",
            "status": "PASS",
            "durationMilliseconds": 125.0,
            "data": "",
            "error": "",
            "consoleErrors": "",
            "networkErrors": "",
            "screenshot": "",
        }],
        "artifacts": {},
    }
    (evidence / "scenario-result.json").write_text(json.dumps(sample), encoding="utf-8")
    run = subprocess.run([
        sys.executable,
        str(ROOT / "tools" / "generate_consolidated_report.py"),
        "--evidence-root", str(temp / "evidence"),
        "--source-root", str(ROOT),
        "--output-dir", str(output),
        "--fail-on-empty",
    ], capture_output=True, text=True)
    if run.returncode:
        fail(f"Consolidated reporter self-test failed: {run.stderr.strip() or run.stdout.strip()}")
    else:
        required_outputs = [output / name for name in ("report.html", "log.html", "output.xml", "summary.json")]
        for path in required_outputs:
            if not path.exists() or path.stat().st_size == 0:
                fail(f"Consolidated reporter did not create {path.name}")
        try:
            ET.parse(output / "output.xml")
        except Exception as exc:
            fail(f"Consolidated Robot-style XML is invalid: {exc}")
        if (output / "summary.json").exists():
            summary = json.loads((output / "summary.json").read_text(encoding="utf-8"))
            if summary.get("total") != 1 or summary.get("passed") != 1:
                fail("Consolidated reporter summary self-test totals are incorrect")
        if (output / "log.html").exists() and "BAPBasicPolicySteps.EnterIndividualClientInformationAsync" not in (output / "log.html").read_text(encoding="utf-8"):
            fail("Consolidated reporter did not resolve the feature-scoped C# step definition")

for cache in list(ROOT.rglob("__pycache__")):
    shutil.rmtree(cache, ignore_errors=True)

result = {
    "status": "PASS" if not ERRORS else "FAIL",
    "errors": ERRORS,
    "warnings": WARNINGS,
    "stats": STATS,
    "limitations": [
        "This static gate does not replace dotnet restore/build/test.",
        "Live CLDC/CLEQ/PLDC DOM execution requires the customer environment and credentials.",
    ],
}
VALIDATION_DIR.mkdir(parents=True, exist_ok=True)
(VALIDATION_DIR / "package-gate-result.json").write_text(json.dumps(result, indent=2) + "\n", encoding="utf-8")
print(json.dumps(result, indent=2))
raise SystemExit(1 if ERRORS else 0)
