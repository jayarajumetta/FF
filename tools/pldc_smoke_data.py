"""Standalone PLDC smoke data cleanup and validation.

Run with --apply for the scoped cleanup, or without arguments to validate.
No browser execution or third-party packages are required.
"""
from __future__ import annotations

import argparse
import copy
import json
import re
from pathlib import Path
from typing import Any

PROJECT = "PersonalLines.DuckCreek.Tests"
REMOVED_KEYS = {"_canonical", "_rawTosca"}
SMOKE_NAME = re.compile(r"(?:211_smoke_test_auto|212_smoke_test_cycle|215_smoke_test_rv)_[a-z]{2}(?:_[a-z]+)?\.json")
VALUE_KEYS = {
    "First Name", "Last Name", "DOB", "SSN", "Street Address", "Apartment",
    "City", "ZIP", "State Abbreviation", "expected_btn_new_quote_2",
    "expected_lbl_client_info_5", "statename", "txt_best_phone_account_owner_18",
    "txt_email_account_owner_19", "agentcode_40", "state_44", "writingcompany_48",
    "county_combobox_52", "county_combobox_53", "state", "statecode", "state_name",
    "state_variant",
}
WYOMING_VALUES = {
    "First Name": "JOHN",
    "Last Name": "DOE",
    "DOB": "01/01/1970",
    "SSN": "125000001",
    "Street Address": "100 East B Street",
    "Apartment": "",
    "City": "CASPER",
    "ZIP": "82601",
    "State Abbreviation": "WY",
}
NORMALIZED_VALUES = {
    "CT": {
        "writingcompany_48": "American National Property And Casualty Co.",
    },
    "NJ": {
        "ZIP": "08054",
    },
}


def is_standalone_smoke(project: str, name: str) -> bool:
    return project == PROJECT and SMOKE_NAME.fullmatch(name) is not None


def is_metadata_cleaned_smoke(project: str, name: str) -> bool:
    return is_standalone_smoke(project, name)


def unique_object(pairs: list[tuple[str, Any]]) -> dict[str, Any]:
    result: dict[str, Any] = {}
    for key, value in pairs:
        if key in result:
            raise ValueError(f"Duplicate JSON key: {key}")
        result[key] = value
    return result


def load(path: Path) -> dict[str, Any]:
    result = json.loads(path.read_text(encoding="utf-8-sig"), object_pairs_hook=unique_object)
    if not isinstance(result, dict):
        raise ValueError(f"Expected a JSON object: {path.name}")
    return result


def prune_document(name: str, document: dict[str, Any]) -> dict[str, Any]:
    result = {key: copy.deepcopy(value) for key, value in document.items() if key not in REMOVED_KEYS}
    values = result.get("values")
    if not isinstance(values, dict):
        values = {}
    if name.endswith("_wy.json"):
        values = {**WYOMING_VALUES, **values}
    state_abbreviation = values.get("State Abbreviation")
    if state_abbreviation in NORMALIZED_VALUES:
        values = {**values, **NORMALIZED_VALUES[state_abbreviation]}
    result["values"] = {key: values[key] for key in sorted(VALUE_KEYS) if key in values}
    result["external"] = {}
    result["random"] = {}
    return result


def without_metadata(document: dict[str, Any]) -> dict[str, Any]:
    return prune_document("", document)


def contains_unresolved_placeholder(value: Any) -> bool:
    if isinstance(value, str):
        return "{TDS[" in value or value == "SYNTHETIC_REPLACE_ME"
    if isinstance(value, dict):
        return any(contains_unresolved_placeholder(item) for item in value.values())
    if isinstance(value, list):
        return any(contains_unresolved_placeholder(item) for item in value)
    return False


def validate_standalone(document: dict[str, Any], require_metadata_cleanup: bool = True) -> list[str]:
    errors = []
    if require_metadata_cleanup and REMOVED_KEYS.intersection(document):
        errors.append("Standalone smoke data still contains Tosca metadata sections")
    for section in ("application", "dimensions", "values", "random"):
        if not isinstance(document.get(section), dict):
            errors.append(f"Missing object section: {section}")
    values = document.get("values", {})
    if require_metadata_cleanup and isinstance(values, dict):
        extras = sorted(set(values) - VALUE_KEYS)
        for key in extras:
            errors.append(f"Unreferenced test value remains: {key}")
        for key in sorted(VALUE_KEYS):
            if key not in values or not isinstance(values[key], str):
                errors.append(f"Missing string test value: {key}")
        if contains_unresolved_placeholder(values):
            errors.append("Referenced values contain unresolved TDS or synthetic placeholders")
    if require_metadata_cleanup and document.get("external") not in ({}, None):
        errors.append("Scenario-local external data is not used by the loader and should be empty")
    if require_metadata_cleanup and document.get("random") not in ({}, None):
        errors.append("Unused random data remains in smoke scenario")
    application = document.get("application", {})
    if isinstance(application, dict):
        for key in ("url", "username", "password"):
            if not isinstance(application.get(key), str):
                errors.append(f"Missing application setting: {key}")
    return errors


def merge_patch(target: Any, patch: Any) -> Any:
    if not isinstance(patch, dict):
        return copy.deepcopy(patch)
    result = copy.deepcopy(target) if isinstance(target, dict) else {}
    for key, value in patch.items():
        if value is None:
            result.pop(key, None)
        else:
            result[key] = merge_patch(result.get(key), value)
    return result


def serialized(path: Path, document: dict[str, Any]) -> bytes:
    original = path.read_bytes()
    newline = "\r\n" if b"\r\n" in original else "\n"
    text = json.dumps(document, ensure_ascii=False, indent=2) + "\n"
    text = text.replace("\n", newline)
    result = text.encode("utf-8-sig" if original.startswith(b"\xef\xbb\xbf") else "utf-8")
    if json.loads(result) != document:
        raise ValueError(f"JSON round-trip failed: {path.name}")
    return result


def cleanup(root: Path) -> int:
    data_root = root / "tests" / PROJECT / "TestData"
    manifest_path = data_root / "Layered" / "manifest.json"
    manifest = load(manifest_path)
    updated_manifest = copy.deepcopy(manifest)
    entries = updated_manifest["entries"]
    planned: dict[Path, bytes] = {}
    for source in sorted((data_root / "Scenarios").glob("*.json")):
        if not is_standalone_smoke(PROJECT, source.name):
            continue
        original = load(source)
        should_clean = is_metadata_cleaned_smoke(PROJECT, source.name)
        cleaned = prune_document(source.name, original) if should_clean else original
        errors = validate_standalone(cleaned, require_metadata_cleanup=should_clean)
        if errors:
            raise ValueError(f"{source.name}: {'; '.join(errors)}")
        entry = entries.pop(source.name, None)
        if entry is not None:
            base = load(data_root / entry["baseFile"])
            overrides = load(data_root / entry["overridesFile"])["overrides"]
            effective = merge_patch(base, overrides[entry["overrideKey"]])
            if should_clean:
                effective = prune_document(source.name, effective)
            if source.name == "215_smoke_test_rv_wi.json":
                for key in ("statename", "state_44"):
                    if effective.get("values", {}).get(key) == "WISCONSON" and cleaned["values"].get(key) == "WISCONSIN":
                        effective["values"][key] = "WISCONSIN"
            if effective != cleaned:
                raise ValueError(f"Unexpected standalone/layered data difference: {source.name}")
        if cleaned != original:
            planned[source] = serialized(source, cleaned)
    if updated_manifest != manifest:
        planned[manifest_path] = serialized(manifest_path, updated_manifest)
    # Preflight all files before writing; restore original bytes if any write fails.
    originals = {path: path.read_bytes() for path in planned}
    try:
        for path, content in planned.items():
            path.write_bytes(content)
    except OSError:
        for path, content in originals.items():
            path.write_bytes(content)
        raise
    return len(planned)


def validate_repository(root: Path) -> int:
    data_root = root / "tests" / PROJECT / "TestData"
    entries = load(data_root / "Layered" / "manifest.json")["entries"]
    count = 0
    for source in sorted((data_root / "Scenarios").glob("*.json")):
        if not is_standalone_smoke(PROJECT, source.name):
            continue
        errors = validate_standalone(
            load(source),
            require_metadata_cleanup=is_metadata_cleaned_smoke(PROJECT, source.name),
        )
        if source.name in entries:
            errors.append("Standalone smoke scenario still routes through layered data")
        if errors:
            raise ValueError(f"{source.name}: {'; '.join(errors)}")
        count += 1
    if not count:
        raise ValueError("No standalone PLDC smoke scenarios found")
    return count


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--apply", action="store_true", help="Remove scoped metadata and layered manifest entries")
    args = parser.parse_args()
    root = Path(__file__).resolve().parents[1]
    if args.apply:
        print(f"Changed JSON files: {cleanup(root)}")
    print(f"Validated standalone PLDC smoke scenarios: {validate_repository(root)}")


if __name__ == "__main__":
    main()
