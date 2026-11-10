"""Clean and validate standalone Basic scenario data.

Run with --apply to promote required canonical fields, remove source metadata,
and remove dead Basic layered-manifest entries. Without --apply, validates only.
"""
from __future__ import annotations

import argparse
import copy
import json
import re
from pathlib import Path
from typing import Any

from pldc_smoke_data import serialized

REMOVED_KEYS = {"_canonical", "_rawTosca"}
CALL_PATTERN = re.compile(
    r"\b(?:GetCanonicalField(?:Required)?|GetRequired|Get)\s*\(\s*\"([^\"\r\n]+)\""
)


def load(path: Path) -> dict[str, Any]:
    result = json.loads(path.read_text(encoding="utf-8-sig"))
    if not isinstance(result, dict):
        raise ValueError(f"Expected a JSON object: {path.name}")
    return result


def basic_sources(root: Path) -> list[Path]:
    return sorted(root.glob("tests/*/TestData/Scenarios/Basic/*.json"))


def referenced_keys(root: Path, project: Path) -> set[str]:
    keys: set[str] = set()
    for base in (project, root / "src" / "InsuranceAutomation.Core"):
        for path in base.rglob("*.cs"):
            if "obj" in path.parts or "bin" in path.parts:
                continue
            keys.update(match.casefold() for match in CALL_PATTERN.findall(path.read_text(encoding="utf-8-sig")))
    return keys


def canonical_values(document: dict[str, Any]) -> dict[str, str]:
    result: dict[str, str] = {}
    canonical = document.get("_canonical", {})
    fields = canonical.get("fields", []) if isinstance(canonical, dict) else []
    if not isinstance(fields, list):
        return result
    for field in fields:
        if not isinstance(field, dict):
            continue
        value = field.get("value", "")
        if not isinstance(value, str):
            continue
        for name in (field.get("field"), field.get("businessName")):
            if isinstance(name, str) and name.strip():
                result.setdefault(name, value)
    return result


def clean_document(document: dict[str, Any], required: set[str]) -> dict[str, Any]:
    result = {key: copy.deepcopy(value) for key, value in document.items() if key not in REMOVED_KEYS}
    values = result.get("values")
    if not isinstance(values, dict):
        values = {}
    existing = {key.casefold(): key for key in values}
    for name, value in canonical_values(document).items():
        folded = name.casefold()
        if folded not in required or folded in existing:
            continue
        values[name] = value
        existing[folded] = name
    result["values"] = values
    return result


def validate_document(document: dict[str, Any]) -> list[str]:
    errors: list[str] = []
    metadata = sorted(REMOVED_KEYS.intersection(document))
    if metadata:
        errors.append(f"metadata sections remain: {metadata}")
    for section in ("application", "dimensions", "values", "random", "external"):
        if not isinstance(document.get(section), dict):
            errors.append(f"missing object section: {section}")
    return errors


def basic_manifest_entries(manifest: dict[str, Any]) -> dict[str, Any]:
    entries = manifest.get("entries", {})
    if not isinstance(entries, dict):
        raise ValueError("Layered manifest entries must be an object")
    return {name: entry for name, entry in entries.items() if "basic_policy" in name.casefold()}


def cleanup(root: Path) -> int:
    planned: dict[Path, bytes] = {}
    removals: set[Path] = set()
    projects: dict[Path, set[str]] = {}
    for source in basic_sources(root):
        project = next(parent.parent for parent in source.parents if parent.name == "TestData")
        required = projects.setdefault(project, referenced_keys(root, project))
        original = load(source)
        cleaned = clean_document(original, required)
        if REMOVED_KEYS.intersection(cleaned):
            raise ValueError(f"Metadata cleanup failed: {source}")
        if cleaned != original:
            planned[source] = serialized(source, cleaned)

    for project in projects:
        manifest_path = project / "TestData" / "Layered" / "manifest.json"
        manifest = load(manifest_path)
        updated = copy.deepcopy(manifest)
        entries = updated.get("entries", {})
        basic = basic_manifest_entries(manifest)
        non_basic = {name: entry for name, entry in entries.items() if name not in basic}
        non_basic_layers = {
            entry.get(key, "")
            for entry in non_basic.values() if isinstance(entry, dict)
            for key in ("baseFile", "overridesFile")
        }
        for name, entry in basic.items():
            for key in ("baseFile", "overridesFile"):
                relative = entry.get(key, "") if isinstance(entry, dict) else ""
                if relative in non_basic_layers:
                    raise ValueError(f"Basic layer is shared with a non-Basic scenario: {relative}")
                layer = project / "TestData" / relative
                if relative and layer.exists():
                    removals.add(layer)
            entries.pop(name, None)
        if updated != manifest:
            planned[manifest_path] = serialized(manifest_path, updated)

    originals = {path: path.read_bytes() for path in planned.keys() | removals}
    try:
        for path, content in planned.items():
            path.write_bytes(content)
        for path in removals:
            path.unlink()
    except OSError:
        for path, content in originals.items():
            path.parent.mkdir(parents=True, exist_ok=True)
            path.write_bytes(content)
        raise
    return len(planned) + len(removals)


def validate_repository(root: Path) -> int:
    projects: dict[Path, set[str]] = {}
    count = 0
    for source in basic_sources(root):
        project = next(parent.parent for parent in source.parents if parent.name == "TestData")
        required = projects.setdefault(project, referenced_keys(root, project))
        document = load(source)
        errors = validate_document(document)
        if errors:
            raise ValueError(f"{source.name}: {'; '.join(errors)}")
        count += 1
    for project in projects:
        manifest = load(project / "TestData" / "Layered" / "manifest.json")
        remaining = sorted(basic_manifest_entries(manifest))
        if remaining:
            raise ValueError(f"{project.name}: unused Basic layered entries remain: {remaining[:10]}")
    if not count:
        raise ValueError("No Basic scenario data found")
    return count


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--apply", action="store_true", help="Apply the scoped Basic data cleanup")
    args = parser.parse_args()
    root = Path(__file__).resolve().parents[1]
    if args.apply:
        print(f"Changed JSON files: {cleanup(root)}")
    print(f"Validated standalone Basic scenarios: {validate_repository(root)}")


if __name__ == "__main__":
    main()
