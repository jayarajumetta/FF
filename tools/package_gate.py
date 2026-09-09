#!/usr/bin/env python3
"""Static quality gate for the CLDC/CLEQ/PLDC ReqnRoll solution.

The gate validates contracts that do not require the customer applications: C# structural
integrity, ReqnRoll binding coverage, direct shared-state test data, external override limits,
locator references, pipeline syntax, and consolidated-report generation. A real dotnet build
and browser execution remain authoritative in the client environment.
"""
from __future__ import annotations

import argparse
import ast
import collections
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
except ImportError:
    yaml = None

sys.dont_write_bytecode = True
ROOT = Path(__file__).resolve().parents[1]
ERRORS: list[str] = []
WARNINGS: list[str] = []
STATS: dict[str, Any] = {}
APPS = [
    "CommercialLines.DuckCreek.Tests",
    "CommercialLines.ExpertQuote.Tests",
    "PersonalLines.DuckCreek.Tests",
]
JUNK_DIRS = {".vs", "bin", "obj", "__pycache__", ".idea"}
ALLOWED_EXTERNAL_KEYS = {"url", "username", "password"}
FORBIDDEN_DATA_KEYS = {
    "_meta", "_canonical", "_rawTosca", "sourceSha256", "sourceRevision",
    "sourceTruth", "sourceFile", "derivedFrom", "sourceSentence", "sourceStep",
}


def fail(message: str) -> None:
    ERRORS.append(message)


def warn(message: str) -> None:
    WARNINGS.append(message)


def csharp_balance(text: str) -> tuple[int, int, int]:
    braces = parens = brackets = 0
    index = 0
    state = "code"
    raw_quotes = 0
    while index < len(text):
        current = text[index]
        following = text[index + 1] if index + 1 < len(text) else ""
        if state == "code":
            if current == "/" and following == "/":
                state = "line"; index += 2; continue
            if current == "/" and following == "*":
                state = "block"; index += 2; continue
            if current == "@" and following == '"':
                state = "verbatim"; index += 2; continue
            if text.startswith('"""', index):
                raw_quotes = 3
                while index + raw_quotes < len(text) and text[index + raw_quotes] == '"':
                    raw_quotes += 1
                state = "raw"; index += raw_quotes; continue
            if current == '"':
                state = "string"; index += 1; continue
            if current == "'":
                state = "char"; index += 1; continue
            if current == "{": braces += 1
            elif current == "}": braces -= 1
            elif current == "(": parens += 1
            elif current == ")": parens -= 1
            elif current == "[": brackets += 1
            elif current == "]": brackets -= 1
            if min(braces, parens, brackets) < 0:
                return braces, parens, brackets
            index += 1; continue
        if state == "line":
            if current == "\n": state = "code"
            index += 1; continue
        if state == "block":
            if current == "*" and following == "/": state = "code"; index += 2; continue
            index += 1; continue
        if state == "string":
            if current == "\\": index += 2; continue
            if current == '"': state = "code"
            index += 1; continue
        if state == "verbatim":
            if current == '"' and following == '"': index += 2; continue
            if current == '"': state = "code"
            index += 1; continue
        if state == "raw":
            if text.startswith('"' * raw_quotes, index): state = "code"; index += raw_quotes; continue
            index += 1; continue
        if state == "char":
            if current == "\\": index += 2; continue
            if current == "'": state = "code"
            index += 1; continue
    return braces, parens, brackets


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
    previous_step: str | None = None
    adjacent_duplicates: list[str] = []
    for line in path.read_text(encoding="utf-8-sig", errors="ignore").splitlines():
        stripped = line.strip()
        if stripped.startswith("Feature:"):
            feature = stripped.split(":", 1)[1].strip()
        match = re.match(r"^(Given|When|Then|And|But)\s+(.+)$", stripped)
        if match:
            step = match.group(2).strip()
            steps.append(step)
            if previous_step == step:
                adjacent_duplicates.append(step)
            previous_step = step
        elif stripped and not stripped.startswith(("#", "@")):
            previous_step = None
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
        "duplicateAdjacentSteps": adjacent_duplicates,
    }


def get_property_case_insensitive(mapping: dict[str, Any], name: str) -> Any:
    for key, value in mapping.items():
        if key.lower() == name.lower():
            return value
    return None


def merge_flow(document: dict[str, Any], feature: str) -> dict[str, str]:
    """Apply the same direct-data precedence as ScenarioData using case-insensitive keys."""
    effective: dict[str, tuple[str, str]] = {}

    def add(section: Any) -> None:
        if not isinstance(section, dict):
            return
        for key, value in section.items():
            effective[key.lower()] = (key, "" if value is None else str(value))

    for section_name in ("application", "dimensions", "values"):
        add(document.get(section_name))

    flows = document.get("flows")
    flow = get_property_case_insensitive(flows, feature) if isinstance(flows, dict) else None
    if not isinstance(flow, dict):
        raise KeyError(feature)
    for section_name in ("application", "dimensions", "values"):
        add(flow.get(section_name))

    state = document.get("state") if isinstance(document.get("state"), dict) else {}
    state_defaults = {
        "stateCode": get_property_case_insensitive(state, "code") or get_property_case_insensitive(state, "stateCode") or "",
        "stateName": get_property_case_insensitive(state, "name") or get_property_case_insensitive(state, "stateName") or "",
        "stateVariant": get_property_case_insensitive(state, "variant") or get_property_case_insensitive(state, "stateVariant") or "",
    }
    for key, value in state_defaults.items():
        effective.setdefault(key.lower(), (key, str(value)))

    return {key: value for key, value in effective.values()}


def case_insensitive_duplicates(mapping: Any) -> list[str]:
    if not isinstance(mapping, dict):
        return []
    seen: dict[str, str] = {}
    duplicates: list[str] = []
    for key in mapping:
        lowered = key.lower()
        if lowered in seen:
            duplicates.append(f"{seen[lowered]} / {key}")
        else:
            seen[lowered] = key
    return duplicates


def recursive_keys(value: Any) -> set[str]:
    result: set[str] = set()
    if isinstance(value, dict):
        for key, nested in value.items():
            result.add(key)
            result.update(recursive_keys(nested))
    elif isinstance(value, list):
        for nested in value:
            result.update(recursive_keys(nested))
    return result


def parse_timeout_value(value: Any) -> bool:
    if isinstance(value, int):
        return value > 0
    if isinstance(value, float):
        return value > 0
    return bool(re.fullmatch(r"\s*\d+(?:\.\d+)?\s*(?:ms|s|m)?\s*", str(value), flags=re.I))


def discover_scoped_step_files(app_root: Path) -> dict[str, Path]:
    result: dict[str, Path] = {}
    for path in (app_root / "StepDefinitions").glob("*.cs"):
        text = path.read_text(encoding="utf-8-sig", errors="ignore")
        for feature in re.findall(r'Scope\s*\(\s*Feature\s*=\s*"([^"]+)"\s*\)', text):
            if feature in result:
                fail(f"{app_root.name}: duplicate scoped step-definition class for '{feature}'")
            result[feature] = path
    return result


for cache in list(ROOT.rglob("__pycache__")):
    shutil.rmtree(cache, ignore_errors=True)

# Repository and syntax checks.
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

json_files = [path for path in ROOT.rglob("*.json") if not any(part in JUNK_DIRS for part in path.parts)]
for path in json_files:
    try:
        json.loads(path.read_text(encoding="utf-8-sig"))
    except Exception as exc:
        fail(f"Invalid JSON {path.relative_to(ROOT)}: {exc}")
STATS["jsonCount"] = len(json_files)

for path in ROOT.rglob("*.csproj"):
    try:
        ET.parse(path)
    except Exception as exc:
        fail(f"Invalid project XML {path.relative_to(ROOT)}: {exc}")

cs_files = [path for path in ROOT.rglob("*.cs") if not any(part in JUNK_DIRS for part in path.parts)]
for path in cs_files:
    text = path.read_text(encoding="utf-8-sig", errors="ignore")
    balance = csharp_balance(text)
    if balance != (0, 0, 0):
        fail(f"C# delimiter imbalance {path.relative_to(ROOT)}: {balance}")
    if path.name.endswith("Steps.cs") and "^(.*)$" in text:
        fail(f"Catch-all ReqnRoll binding found in {path.relative_to(ROOT)}")
STATS["csharpFiles"] = len(cs_files)

# Binding discovery and feature checks.
try:
    reporter = load_reporter()
    bindings = reporter.discover_bindings(ROOT)
    STATS["reqnrollBindings"] = len(bindings)
except Exception as exc:
    reporter = None
    bindings = []
    fail(f"Consolidated reporter/binding discovery failed: {exc}")

feature_stats: dict[str, Any] = {}
all_feature_rows = 0
unresolved_steps: list[str] = []
data_stats: dict[str, Any] = {}
path_ownership: dict[tuple[str, str, str], set[str]] = collections.defaultdict(set)

for app_name in APPS:
    app_root = ROOT / "tests" / app_name
    test_data = app_root / "TestData"
    scoped = discover_scoped_step_files(app_root)

    for obsolete in (test_data / "Layered", test_data / "Scenarios"):
        if obsolete.exists():
            fail(f"{app_name}: obsolete test-data directory still exists: {obsolete.relative_to(ROOT)}")
    for obsolete_name in ("Base.json", "StateOverrides.json", "manifest.json"):
        matches = list(test_data.rglob(obsolete_name))
        if matches:
            fail(f"{app_name}: obsolete {obsolete_name} files remain: {[str(p.relative_to(ROOT)) for p in matches[:10]]}")

    external_path = test_data / "ExternalDataOverrides.json"
    try:
        external = json.loads(external_path.read_text(encoding="utf-8-sig"))
        application = external.get("application", {})
        if not isinstance(application, dict):
            fail(f"{app_name}: external application overrides must be an object")
        else:
            unknown = set(application) - ALLOWED_EXTERNAL_KEYS
            if unknown:
                fail(f"{app_name}: disallowed external override keys: {sorted(unknown)}")
            missing = ALLOWED_EXTERNAL_KEYS - set(application)
            if missing:
                fail(f"{app_name}: external override file is missing: {sorted(missing)}")
        top_unknown = {key for key in external if not key.startswith("_") and key != "application"}
        if top_unknown:
            fail(f"{app_name}: disallowed top-level external override sections: {sorted(top_unknown)}")
    except Exception as exc:
        fail(f"{app_name}: cannot validate ExternalDataOverrides.json: {exc}")

    timeout_path = test_data / "StepTimeouts.json"
    try:
        timeout_config = json.loads(timeout_path.read_text(encoding="utf-8-sig"))
        feature_timeouts = timeout_config.get("features", {})
        if not isinstance(feature_timeouts, dict):
            fail(f"{app_name}: StepTimeouts.features must be an object")
        else:
            for feature_name, timeout_map in feature_timeouts.items():
                if feature_name.startswith("_"):
                    continue
                if feature_name != "*" and feature_name not in scoped:
                    fail(f"{app_name}: StepTimeouts contains unknown feature '{feature_name}'")
                if not isinstance(timeout_map, dict):
                    fail(f"{app_name}: StepTimeouts entry '{feature_name}' must be an object")
                    continue
                candidate = timeout_map.get("steps", timeout_map)
                if not isinstance(candidate, dict):
                    fail(f"{app_name}: StepTimeouts steps for '{feature_name}' must be an object")
                    continue
                for step, timeout in candidate.items():
                    if step.startswith("_"):
                        continue
                    if not parse_timeout_value(timeout):
                        fail(f"{app_name}: invalid timeout for '{feature_name}' / '{step}': {timeout}")
    except Exception as exc:
        fail(f"{app_name}: cannot validate StepTimeouts.json: {exc}")

    direct_files = sorted(
        path for category in ("Smoke", "Basic", "Extended")
        for path in (test_data / category).glob("*.json")
    )
    referenced_files: set[Path] = set()
    app_rows = 0
    app_flows: set[str] = set()

    for feature_path in sorted((app_root / "Features").glob("*.feature")):
        parsed = parse_feature(feature_path)
        feature = parsed["feature"]
        if feature not in scoped:
            fail(f"{app_name}: no scoped binding class found for feature '{feature}'")
        if parsed["duplicateAdjacentSteps"]:
            fail(f"{feature_path.name}: exact adjacent duplicate Gherkin steps {parsed['duplicateAdjacentSteps']}")
        rows = parsed["rows"] + parsed["commentedRows"]
        app_rows += len(rows)
        all_feature_rows += len(rows)
        feature_stats[feature_path.name] = {
            "activeRows": len(parsed["rows"]),
            "commentedRows": len(parsed["commentedRows"]),
        }

        if reporter is not None:
            substitutions = parsed["rows"][0] if parsed["rows"] else (parsed["commentedRows"][0] if parsed["commentedRows"] else {})
            for raw_step in parsed["steps"]:
                executed = re.sub(r"<([^>]+)>", lambda match: substitutions.get(match.group(1), match.group(0)), raw_step)
                display, _, _, _ = reporter.resolve_binding(bindings, feature, executed)
                if display == "Unresolved":
                    unresolved_steps.append(f"{feature_path.name}: {executed}")

        expected_category = "Smoke" if "smoke" in feature.lower() else ("Extended" if "expanded" in feature.lower() or "extended" in feature.lower() else "Basic")
        for row in rows:
            relative = row.get("dataFile", "")
            if not relative.startswith(f"TestData/{expected_category}/"):
                fail(f"{feature_path.name}: expected {expected_category} direct data path, found '{relative}'")
                continue
            candidate = app_root / relative
            referenced_files.add(candidate)
            if not candidate.exists():
                fail(f"{feature_path.name}: referenced test data is missing: {relative}")
                continue
            state_variant = row.get("stateVariant", "")
            path_ownership[(app_name, expected_category, state_variant)].add(relative)
            try:
                document = json.loads(candidate.read_text(encoding="utf-8-sig"))
                relative_candidate = candidate.relative_to(ROOT)
                if document.get("schemaVersion") != "2.0-direct-state":
                    fail(f"{relative_candidate}: unexpected schemaVersion")

                allowed_root = {"schemaVersion", "state", "values", "random", "flows"}
                unknown_root = sorted(set(document) - allowed_root)
                if unknown_root:
                    fail(f"{relative_candidate}: unsupported top-level sections: {unknown_root}")

                all_keys = recursive_keys(document)
                forbidden = sorted(all_keys & FORBIDDEN_DATA_KEYS)
                if forbidden:
                    fail(f"{relative_candidate}: historical/source lineage keys remain: {forbidden}")

                state = document.get("state")
                if not isinstance(state, dict) or set(state) != {"code", "name", "variant"}:
                    fail(f"{relative_candidate}: state must contain only code, name and variant")
                    state = state if isinstance(state, dict) else {}
                if str(state.get("code", "")).upper() != row.get("stateCode", "").upper():
                    fail(f"{relative_candidate}: state.code does not match feature row")
                if str(state.get("name", "")).strip().casefold() != row.get("stateName", "").strip().casefold():
                    fail(f"{relative_candidate}: state.name does not match feature row")
                if str(state.get("variant", "")).upper() != state_variant.upper():
                    fail(f"{relative_candidate}: state.variant does not match feature row")

                flows = document.get("flows")
                if not isinstance(flows, dict) or not flows:
                    fail(f"{relative_candidate}: flows must be a non-empty object")
                    continue
                flow = get_property_case_insensitive(flows, feature)
                if not isinstance(flow, dict):
                    fail(f"{relative_candidate}: flow '{feature}' is missing")
                    continue
                app_flows.add(feature)

                unknown_flow = sorted(set(flow) - {"values", "random"})
                if unknown_flow:
                    fail(f"{relative_candidate} / {feature}: unsupported flow sections: {unknown_flow}")

                root_values = document.get("values", {}) if isinstance(document.get("values"), dict) else {}
                root_random = document.get("random", {}) if isinstance(document.get("random"), dict) else {}
                flow_values = flow.get("values", {}) if isinstance(flow.get("values"), dict) else {}
                flow_random = flow.get("random", {}) if isinstance(flow.get("random"), dict) else {}

                for label, mapping in (("root values", root_values), ("root random", root_random),
                                       ("flow values", flow_values), ("flow random", flow_random)):
                    duplicates = case_insensitive_duplicates(mapping)
                    if duplicates:
                        fail(f"{relative_candidate} / {feature}: case-insensitive duplicates in {label}: {duplicates[:20]}")

                overlap_values = sorted(set(key.casefold() for key in root_values) & set(key.casefold() for key in flow_values))
                overlap_random = sorted(set(key.casefold() for key in root_random) & set(key.casefold() for key in flow_random))
                if overlap_values:
                    fail(f"{relative_candidate} / {feature}: duplicate root/flow value keys: {overlap_values[:20]}")
                if overlap_random:
                    fail(f"{relative_candidate} / {feature}: duplicate root/flow random keys: {overlap_random[:20]}")

                environment_like = sorted(
                    key for key in list(root_values) + list(flow_values)
                    if key.casefold() in ALLOWED_EXTERNAL_KEYS
                )
                if environment_like:
                    fail(f"{relative_candidate} / {feature}: external-only keys found in business data: {environment_like}")

                merged = merge_flow(document, feature)
                for required_key in ("stateCode", "stateName", "stateVariant"):
                    if not any(key.casefold() == required_key.casefold() for key in merged):
                        fail(f"{relative_candidate} / {feature}: effective data is missing {required_key}")
            except Exception as exc:
                fail(f"{candidate.relative_to(ROOT)}: direct-state validation failed: {exc}")

    unreferenced = [path for path in direct_files if path not in referenced_files]
    if unreferenced:
        fail(f"{app_name}: unreferenced direct state files: {[str(path.relative_to(ROOT)) for path in unreferenced[:20]]}")

    data_stats[app_name] = {
        "scenarioRows": app_rows,
        "directStateFiles": len(direct_files),
        "flows": len(app_flows),
        "bytes": sum(path.stat().st_size for path in direct_files),
    }

for owner, paths in path_ownership.items():
    if len(paths) != 1:
        fail(f"State data is not shared for {owner}: {sorted(paths)}")

if unresolved_steps:
    fail(f"Feature steps without a scoped/global ReqnRoll binding: {unresolved_steps[:40]}")
STATS["featureExamples"] = feature_stats
STATS["scenarioRows"] = all_feature_rows
STATS["directStateData"] = data_stats

# Runtime data contracts.
scenario_data_text = (ROOT / "src" / "InsuranceAutomation.Core" / "ScenarioData.cs").read_text(encoding="utf-8-sig")
for forbidden in ("OpenScenarioDocument", "ApplyMergePatch", '"Layered"', "GetCanonicalField", "_rawTosca", "_canonical"):
    if forbidden in scenario_data_text:
        fail(f"ScenarioData still contains obsolete contract token: {forbidden}")
for required in ("PopulateSelectedFlow", "PopulateStateDefaults", "AllowedExternalKeys", "LoadStepTimeouts", "GetStepTimeoutMs"):
    if required not in scenario_data_text:
        fail(f"ScenarioData is missing required lean-data contract: {required}")

timeout_context = ROOT / "src" / "InsuranceAutomation.Core" / "StepTimeoutContext.cs"
if not timeout_context.exists():
    fail("StepTimeoutContext.cs is missing")
else:
    timeout_text = timeout_context.read_text(encoding="utf-8-sig")
    for required in ("AsyncLocal", "CurrentTimeoutMs", "Resolve", "Push"):
        if required not in timeout_text:
            fail(f"StepTimeoutContext is missing: {required}")

for app_name in APPS:
    hooks = (ROOT / "tests" / app_name / "Hooks" / "TestHooks.cs").read_text(encoding="utf-8-sig")
    application_steps = (ROOT / "tests" / app_name / "StepDefinitions" / "ApplicationSteps.cs").read_text(encoding="utf-8-sig")
    for token in ("GetStepTimeoutMs", "StepTimeoutContext.Push", "ApplyStepTimeout"):
        if token not in hooks:
            fail(f"{app_name}: timeout propagation hook is missing {token}")
    if "_feature.FeatureInfo.Title" not in application_steps or ".Load(scenarioPath, externalPath, _feature.FeatureInfo.Title)" not in application_steps:
        fail(f"{app_name}: ApplicationSteps does not select the feature flow")

ui_actions = (ROOT / "src" / "InsuranceAutomation.Core" / "UiActions.cs").read_text(encoding="utf-8-sig")
for required in ("StepTimeoutContext.Resolve(_config.Browser.ActionTimeoutMs)", "PageReadyTimeoutMs", "ElementReadyTimeoutMs", "VerifyTimeoutMs", "DropdownOptionTimeoutMs"):
    if required not in ui_actions:
        fail(f"UiActions is missing timeout propagation contract: {required}")

# Direct Playwright timeout options outside UiActions must also respect the current business-step timeout.
explicit_timeout_pattern = re.compile(r"\bTimeout\s*=\s*(?:[0-9][0-9_]*|_config\.)")
for path in cs_files:
    text = path.read_text(encoding="utf-8-sig", errors="ignore")
    for line_number, line in enumerate(text.splitlines(), start=1):
        if explicit_timeout_pattern.search(line) and "StepTimeoutContext.Resolve" not in line:
            fail(f"{path.relative_to(ROOT)}:{line_number}: explicit Playwright timeout bypasses StepTimeoutContext: {line.strip()}")

for path in (
    ROOT / "tests" / "CommercialLines.ExpertQuote.Tests" / "Pages" / "ApplicationPage.cs",
    ROOT / "tests" / "CommercialLines.DuckCreek.Tests" / "Runtime" / "DuckCreekFrameScopeResolver.cs",
):
    text = path.read_text(encoding="utf-8-sig", errors="ignore")
    if "StepTimeoutContext.Resolve" not in text:
        fail(f"{path.relative_to(ROOT)}: direct waits do not inherit the business-step timeout")

# Locator class/member integrity.
locator_stats: dict[str, Any] = {}
for app_name in APPS:
    app_root = ROOT / "tests" / app_name
    classes: dict[str, set[str]] = {}
    member_count = 0
    for path in (app_root / "Pages" / "Locators").glob("*.cs"):
        text = path.read_text(encoding="utf-8-sig", errors="ignore")
        class_match = re.search(r"\bclass\s+(\w+Locators)\b", text)
        if not class_match:
            fail(f"{app_name}/{path.name}: locator class declaration not found")
            continue
        members = re.findall(r"public\s+ILocator\s+(\w+)\s*(?:=>|\{|\()", text)
        duplicates = [name for name, count in collections.Counter(members).items() if count > 1]
        if duplicates:
            fail(f"{app_name}/{path.name}: duplicate locator members {duplicates}")
        classes[class_match.group(1)] = set(members)
        member_count += len(members)
        if 'Locator("")' in text or "Locator(string.Empty)" in text:
            fail(f"{app_name}/{path.name}: empty locator")
    missing_refs: list[str] = []
    for page in (app_root / "Pages").glob("*Page.cs"):
        text = page.read_text(encoding="utf-8-sig", errors="ignore")
        fields = {variable: class_name for class_name, variable in re.findall(r"private\s+readonly\s+(\w+Locators)\s+(\w+)\s*;", text)}
        for variable, class_name in fields.items():
            if class_name not in classes:
                missing_refs.append(f"{page.name}:{class_name}")
                continue
            for member in re.findall(rf"\b{re.escape(variable)}\.(\w+)", text):
                if member not in classes[class_name]:
                    missing_refs.append(f"{page.name}:{variable}.{member}->{class_name}")
    if missing_refs:
        fail(f"{app_name}: page references missing locator members {missing_refs[:30]}")
    locator_stats[app_name] = {"members": member_count, "missingPageReferences": len(missing_refs)}
STATS["locators"] = locator_stats

# Azure YAML and aliases.
yaml_paths = [ROOT / ".azuredevops" / "build.yml", ROOT / ".azuredevops" / "release.yml"]
for path in yaml_paths:
    if not path.exists():
        fail(f"Azure pipeline missing: {path.relative_to(ROOT)}")
    elif yaml is None:
        warn("PyYAML is unavailable; Azure YAML parse was skipped")
    else:
        try:
            yaml.safe_load(path.read_text(encoding="utf-8-sig"))
        except Exception as exc:
            fail(f"Invalid Azure YAML {path.relative_to(ROOT)}: {exc}")
for alias, source in ((ROOT / "azure-pipelines-ci.yml", yaml_paths[0]), (ROOT / "azure-pipelines-cd.yml", yaml_paths[1])):
    if not alias.exists():
        fail(f"Root pipeline alias missing: {alias.name}")
    elif source.exists() and alias.read_bytes() != source.read_bytes():
        fail(f"Root pipeline alias is out of sync: {alias.name}")

# Reporter syntax and functional self-test.
for script in (ROOT / "tools" / "generate_consolidated_report.py", ROOT / "tools" / "send_consolidated_report.py", ROOT / "tools" / "package_gate.py"):
    try:
        ast.parse(script.read_text(encoding="utf-8-sig"), filename=str(script))
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
        for name in ("report.html", "log.html", "output.xml", "summary.json"):
            path = output / name
            if not path.exists() or path.stat().st_size == 0:
                fail(f"Consolidated reporter did not create {name}")
        if (output / "output.xml").exists():
            try:
                ET.parse(output / "output.xml")
            except Exception as exc:
                fail(f"Consolidated Robot-style XML is invalid: {exc}")

for cache in list(ROOT.rglob("__pycache__")):
    shutil.rmtree(cache, ignore_errors=True)

result = {
    "status": "PASS" if not ERRORS else "FAIL",
    "errors": ERRORS,
    "warnings": WARNINGS,
    "stats": STATS,
    "limitations": [
        "The environment used for this static gate does not contain the .NET 8 SDK, so the authoritative dotnet restore/build/test must run in Visual Studio or Azure DevOps.",
        "Live CLDC/CLEQ/PLDC DOM execution requires the customer environment and credentials.",
    ],
}

parser = argparse.ArgumentParser(add_help=False)
parser.add_argument("--json-out")
args, _ = parser.parse_known_args()
if args.json_out:
    output_path = Path(args.json_out)
    output_path.parent.mkdir(parents=True, exist_ok=True)
    output_path.write_text(json.dumps(result, indent=2) + "\n", encoding="utf-8")
print(json.dumps(result, indent=2))
raise SystemExit(1 if ERRORS else 0)
