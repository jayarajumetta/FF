#!/usr/bin/env python3
"""Create a self-contained Robot Framework-style consolidated execution report.

Input contract
--------------
The insurance automation framework writes one ``scenario-result.json`` in every
scenario evidence directory.  This utility recursively discovers those files,
resolves executed Gherkin steps to scoped ReqnRoll bindings, and writes the same
four outputs used by the existing pipeline:

* report.html  - portable, self-contained run report with embedded failed-test
                 screenshots, execution logs, resolved data and browser errors;
* log.html     - compact flat log retained for backward compatibility;
* output.xml   - Robot-compatible machine-readable XML;
* summary.json - run totals for pipelines and mail tooling.

The existing command line remains valid.  No third-party Python package is
required.
"""
from __future__ import annotations

import argparse
import base64
import datetime as dt
import hashlib
import html
import json
import mimetypes
import os
import re
import sys
import urllib.parse
import xml.etree.ElementTree as ET
from collections import Counter, defaultdict
from dataclasses import dataclass
from pathlib import Path
from typing import Any, Iterable, Sequence


PASS_VALUES = {"PASS", "PASSED", "SUCCESS", "SUCCEEDED", "OK"}
SKIP_VALUES = {"SKIP", "SKIPPED", "IGNORED", "PENDING", "NOTRUN", "NOT RUN"}
FAIL_VALUES = {"FAIL", "FAILED", "ERROR", "BROKEN", "ABORTED", "CANCELLED", "CANCELED"}
IMAGE_SUFFIXES = {".png", ".jpg", ".jpeg", ".webp", ".gif"}
SENSITIVE_KEY = re.compile(r"(?:password|passwd|pwd|secret|token|authorization|api[_ -]?key|client[_ -]?secret)", re.IGNORECASE)
STATE_PATTERN = re.compile(r"(?:state\s*code|statecode|state)[_\s:=\-]+[\"']?([A-Z]{2})\b", re.IGNORECASE)
LOB_PATTERN = re.compile(r"\b(BAP|GL|IM|WC|CP|CPP|UMB|BOP|SFP|RV|CYCLE|AUTO)\b", re.IGNORECASE)


@dataclass(frozen=True)
class Binding:
    feature: str
    pattern: str
    class_name: str
    method_name: str
    source_file: str
    line: int
    regex: re.Pattern[str] | None

    @property
    def display(self) -> str:
        return f"{self.class_name}.{self.method_name}"


@dataclass(frozen=True)
class EmbeddedFile:
    path: Path
    href: str
    size_bytes: int
    embedded: bool
    data_uri: str = ""
    reason: str = ""


@dataclass(frozen=True)
class ReportLimits:
    max_log_bytes: int = 2 * 1024 * 1024
    max_image_bytes: int = 12 * 1024 * 1024
    max_images_per_scenario: int = 20
    max_raw_json_bytes: int = 512 * 1024


# ---------------------------------------------------------------------------
# ReqnRoll binding discovery
# ---------------------------------------------------------------------------

def _decode_csharp_string(prefix: str, value: str) -> str:
    if prefix == "@":
        return value.replace('""', '"')
    try:
        return bytes(value, "utf-8").decode("unicode_escape")
    except (UnicodeDecodeError, ValueError):
        return value


def _cucumber_to_regex(pattern: str) -> str:
    tokens = re.split(r"(\{string\}|\{int\}|\{float\}|\{word\})", pattern)
    parts: list[str] = []
    for token in tokens:
        if token == "{string}":
            parts.append(r'["\'].*?["\']')
        elif token == "{int}":
            parts.append(r"-?\d+")
        elif token == "{float}":
            parts.append(r"-?(?:\d+(?:\.\d+)?|\.\d+)")
        elif token == "{word}":
            parts.append(r"\S+")
        else:
            parts.append(re.escape(token))
    return "^" + "".join(parts) + "$"


def _compile_binding(pattern: str) -> re.Pattern[str] | None:
    source = pattern if pattern.startswith("^") else _cucumber_to_regex(pattern)
    try:
        return re.compile(source, re.IGNORECASE)
    except re.error:
        return None


def discover_bindings(source_root: Path) -> list[Binding]:
    bindings: list[Binding] = []
    attr_re = re.compile(r'^\s*\[(Given|When|Then)\((@?)["](.*)["]\)\]\s*$')
    class_re = re.compile(r"\bclass\s+(\w+)")
    scope_re = re.compile(r'Scope\s*\(\s*Feature\s*=\s*"([^"]+)"')
    method_re = re.compile(r"^\s*public\s+(?:async\s+)?(?:Task(?:<[^>]+>)?|void|[\w?.<>]+)\s+(\w+)\s*\(")

    patterns = (
        "tests/*/StepDefinitions/*.cs",
        "tests/*/Steps/*.cs",
        "**/StepDefinitions/*.cs",
    )
    seen_paths: set[Path] = set()
    for pattern in patterns:
        for path in sorted(source_root.glob(pattern)):
            resolved = path.resolve()
            if resolved in seen_paths or any(part in {"bin", "obj", ".git"} for part in path.parts):
                continue
            seen_paths.add(resolved)
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
            class_name = path.stem
            feature_scope = ""
            pending: list[tuple[str, int]] = []
            for number, line in enumerate(lines, 1):
                scope = scope_re.search(line)
                if scope:
                    feature_scope = scope.group(1).strip()
                cls = class_re.search(line)
                if cls:
                    class_name = cls.group(1)
                attr = attr_re.match(line)
                if attr:
                    pending.append((_decode_csharp_string(attr.group(2), attr.group(3)), number))
                    continue
                method = method_re.match(line)
                if method and pending:
                    for binding_pattern, attr_line in pending:
                        try:
                            source_file = str(path.relative_to(source_root)).replace("\\", "/")
                        except ValueError:
                            source_file = str(path).replace("\\", "/")
                        bindings.append(
                            Binding(
                                feature=feature_scope,
                                pattern=binding_pattern,
                                class_name=class_name,
                                method_name=method.group(1),
                                source_file=source_file,
                                line=attr_line,
                                regex=_compile_binding(binding_pattern),
                            )
                        )
                    pending.clear()
                elif line.strip() and not line.lstrip().startswith(("[", "//", "#")):
                    pending.clear()
    return bindings


def resolve_binding(bindings: Sequence[Binding], feature: str, step: str) -> tuple[str, str, int, str]:
    candidates = [
        binding
        for binding in bindings
        if (not binding.feature or binding.feature.casefold() == feature.casefold())
        and binding.regex
        and binding.regex.fullmatch(step)
    ]
    if not candidates:
        return "Unresolved", "", 0, "No scoped ReqnRoll binding matched this executed step."
    scoped = [binding for binding in candidates if binding.feature]
    chosen = (scoped or candidates)[0]
    note = "" if len(candidates) == 1 else f"Resolved from {len(candidates)} candidates using feature scope."
    return chosen.display, chosen.source_file, chosen.line, note


# ---------------------------------------------------------------------------
# Result ingestion and enrichment
# ---------------------------------------------------------------------------

def load_results(evidence_root: Path) -> list[dict[str, Any]]:
    results: list[dict[str, Any]] = []
    for path in sorted(evidence_root.rglob("scenario-result.json")):
        try:
            item = json.loads(path.read_text(encoding="utf-8"))
            if not isinstance(item, dict):
                raise ValueError("The JSON root must be an object.")
            item["_resultFile"] = str(path.resolve())
            item["_artifactDir"] = str(path.parent.resolve())
            results.append(item)
        except (OSError, json.JSONDecodeError, ValueError) as exc:
            results.append(
                {
                    "feature": "Report ingestion",
                    "scenario": str(path),
                    "status": "FAIL",
                    "durationMilliseconds": 0,
                    "steps": [
                        {
                            "order": 1,
                            "text": "Read scenario-result.json",
                            "status": "FAIL",
                            "durationMilliseconds": 0,
                            "error": str(exc),
                        }
                    ],
                    "_resultFile": str(path.resolve()),
                    "_artifactDir": str(path.parent.resolve()),
                }
            )
    return results


def enrich(results: list[dict[str, Any]], bindings: Sequence[Binding]) -> None:
    for result in results:
        feature = str(result.get("feature") or "Unknown feature")
        for step in result.get("steps", []) or []:
            if not isinstance(step, dict):
                continue
            text = str(step.get("text") or "")
            display, source, line, note = resolve_binding(bindings, feature, text)
            step["binding"] = display
            step["bindingSource"] = source
            step["bindingLine"] = line
            step["bindingResolution"] = note
        result["_status"] = normalize_status(result.get("status"))
        result["_application"] = infer_application(result)
        result["_stateCode"] = infer_state(result)
        result["_lob"] = infer_lob(result)
        result["_tags"] = infer_tags(result)


def normalize_status(value: Any) -> str:
    normalized = str(value or "").strip().upper()
    if normalized in PASS_VALUES:
        return "PASS"
    if normalized in SKIP_VALUES:
        return "SKIP"
    if normalized in FAIL_VALUES:
        return "FAIL"
    return "FAIL" if normalized else "UNKNOWN"


def status(value: Any) -> str:
    """Preserve the original machine-output contract: non-pass means FAIL."""
    return "PASS" if normalize_status(value) == "PASS" else "FAIL"


def duration_ms(item: dict[str, Any]) -> float:
    try:
        return max(0.0, float(item.get("durationMilliseconds", 0) or 0))
    except (TypeError, ValueError):
        return 0.0


def fmt_duration(ms: float) -> str:
    seconds = max(0.0, ms / 1000.0)
    if seconds < 1:
        return f"{ms:.0f} ms"
    if seconds < 60:
        return f"{seconds:.2f} s"
    minutes, seconds_remainder = divmod(seconds, 60)
    if minutes < 60:
        return f"{int(minutes):02d}:{seconds_remainder:05.2f}"
    hours, minutes_remainder = divmod(minutes, 60)
    return f"{int(hours):02d}:{int(minutes_remainder):02d}:{seconds_remainder:05.2f}"


def fmt_bytes(size: int) -> str:
    units = ("B", "KB", "MB", "GB")
    value = float(max(0, size))
    for unit in units:
        if value < 1024 or unit == units[-1]:
            return f"{value:.0f} {unit}" if unit == "B" else f"{value:.1f} {unit}"
        value /= 1024
    return f"{size} B"


def esc(value: Any, quote: bool = True) -> str:
    return html.escape(str(value if value is not None else ""), quote=quote)


def redact_sensitive_text(value: Any) -> str:
    """Mask credentials while keeping ordinary test data visible in the report."""
    text = str(value if value is not None else "")
    pattern = re.compile(
        r"(?i)\b(password|passwd|pwd|secret|token|authorization|api[_ -]?key|client[_ -]?secret)"
        r"(\s*[:=]\s*)([\"']?)([^,;\s\"']+)([\"']?)"
    )
    return pattern.sub(lambda match: f"{match.group(1)}{match.group(2)}••••••••", text)


def redact_json(value: Any) -> Any:
    if isinstance(value, dict):
        return {
            str(key): ("••••••••" if SENSITIVE_KEY.search(str(key)) else redact_json(item))
            for key, item in value.items()
        }
    if isinstance(value, list):
        return [redact_json(item) for item in value]
    if isinstance(value, str):
        return redact_sensitive_text(value)
    return value


def slug(value: str, prefix: str = "id") -> str:
    digest = hashlib.sha1(value.encode("utf-8", errors="ignore")).hexdigest()[:10]
    readable = re.sub(r"[^A-Za-z0-9_-]+", "-", value).strip("-")[:42] or prefix
    return f"{readable}-{digest}"


def parse_iso(value: Any) -> dt.datetime | None:
    text = str(value or "").strip()
    if not text:
        return None
    try:
        parsed = dt.datetime.fromisoformat(text.replace("Z", "+00:00"))
        if parsed.tzinfo is None:
            parsed = parsed.replace(tzinfo=dt.timezone.utc)
        return parsed.astimezone(dt.timezone.utc)
    except ValueError:
        return None


def fmt_timestamp(value: Any) -> str:
    parsed = parse_iso(value)
    if not parsed:
        return str(value or "Not recorded")
    return parsed.strftime("%Y-%m-%d %H:%M:%S.%f")[:-3] + " UTC"


def run_window(results: Sequence[dict[str, Any]]) -> tuple[dt.datetime | None, dt.datetime | None, float]:
    starts = [item for result in results if (item := parse_iso(result.get("startedAtUtc")))]
    ends = [item for result in results if (item := parse_iso(result.get("completedAtUtc")))]
    start = min(starts) if starts else None
    end = max(ends) if ends else None
    wall_ms = max(0.0, (end - start).total_seconds() * 1000) if start and end else 0.0
    return start, end, wall_ms


def _all_text(result: dict[str, Any]) -> str:
    chunks = [
        str(result.get("feature") or ""),
        str(result.get("scenario") or ""),
        str(result.get("_resultFile") or ""),
        json.dumps(result.get("tags") or [], ensure_ascii=False),
    ]
    for step in result.get("steps", []) or []:
        if isinstance(step, dict):
            chunks.extend(str(step.get(key) or "") for key in ("text", "data", "error"))
    return "\n".join(chunks)


def infer_application(result: dict[str, Any]) -> str:
    explicit = result.get("application") or result.get("app") or result.get("project")
    if explicit:
        return str(explicit)
    text = _all_text(result).casefold()
    if "commerciallines.expertquote" in text or "expertquote" in text or "cleq" in text:
        return "CLEQ"
    if "personallines.duckcreek" in text or "personal lines" in text or "pldc" in text:
        return "PLDC"
    if "commerciallines.duckcreek" in text or "commercial lines" in text or "cldc" in text:
        return "CLDC"
    return "Unspecified"


def infer_state(result: dict[str, Any]) -> str:
    for key in ("stateCode", "state_code", "state", "StateCode", "State"):
        value = str(result.get(key) or "").strip().upper()
        if re.fullmatch(r"[A-Z]{2}", value):
            return value
    text = _all_text(result)
    matches = STATE_PATTERN.findall(text)
    if matches:
        return matches[0].upper()
    # Avoid guessing a state from arbitrary two-letter repository path segments
    # (for example, the "DC" in Pnc_DC_TestAutomation).  Scenario names that
    # explicitly end in a state code are accepted; otherwise the report shows —.
    scenario = str(result.get("scenario") or "").strip()
    state_match = re.search(r"(?:^|[_\-\s])([A-Z]{2})$", scenario)
    if state_match:
        return state_match.group(1).upper()
    return "—"


def infer_lob(result: dict[str, Any]) -> str:
    explicit = result.get("lob") or result.get("productCode") or result.get("product_code")
    if explicit:
        return str(explicit).upper()
    match = LOB_PATTERN.search(_all_text(result))
    return match.group(1).upper() if match else "—"


def infer_tags(result: dict[str, Any]) -> list[str]:
    values: list[str] = []
    raw = result.get("tags") or result.get("Tags") or []
    if isinstance(raw, str):
        values.extend(token.strip(" @") for token in re.split(r"[,;\s]+", raw) if token.strip(" @"))
    elif isinstance(raw, list):
        values.extend(str(token).strip(" @") for token in raw if str(token).strip(" @"))
    for value in (result.get("_application"), result.get("_lob"), result.get("_stateCode")):
        if value and value != "—" and value != "Unspecified":
            values.append(str(value))
    deduped: list[str] = []
    seen: set[str] = set()
    for value in values:
        key = value.casefold()
        if key not in seen:
            seen.add(key)
            deduped.append(value)
    return deduped


# ---------------------------------------------------------------------------
# Artifact handling and embedding
# ---------------------------------------------------------------------------

def resolve_path(result: dict[str, Any], value: Any) -> Path | None:
    text = str(value or "").strip()
    if not text:
        return None
    if text.startswith("file:"):
        parsed = urllib.parse.urlparse(text)
        text = urllib.parse.unquote(parsed.path)
        if os.name == "nt" and re.match(r"^/[A-Za-z]:", text):
            text = text[1:]
    candidate = Path(text)
    if candidate.is_absolute():
        return candidate
    artifact_dir = Path(str(result.get("_artifactDir") or "."))
    return (artifact_dir / candidate).resolve()


def path_href(path: Path, output_dir: Path) -> str:
    try:
        relative = os.path.relpath(str(path), str(output_dir))
        return urllib.parse.quote(relative.replace("\\", "/"), safe="/:._-~")
    except (OSError, ValueError):
        try:
            return path.resolve().as_uri()
        except ValueError:
            return urllib.parse.quote(str(path).replace("\\", "/"), safe="/:._-~")


def embed_image(path: Path, output_dir: Path, max_bytes: int) -> EmbeddedFile:
    href = path_href(path, output_dir)
    if not path.exists() or not path.is_file():
        return EmbeddedFile(path, href, 0, False, reason="File not found")
    try:
        size = path.stat().st_size
        if size > max_bytes:
            return EmbeddedFile(path, href, size, False, reason=f"Image exceeds the {fmt_bytes(max_bytes)} embed limit")
        mime = mimetypes.guess_type(path.name)[0] or "image/png"
        payload = base64.b64encode(path.read_bytes()).decode("ascii")
        return EmbeddedFile(path, href, size, True, data_uri=f"data:{mime};base64,{payload}")
    except OSError as exc:
        return EmbeddedFile(path, href, 0, False, reason=str(exc))


def read_text_file(path: Path, max_bytes: int) -> tuple[str, bool, int, str]:
    """Return text, truncated, original size, error."""
    if not path.exists() or not path.is_file():
        return "", False, 0, "File not found"
    try:
        size = path.stat().st_size
        raw = path.read_bytes()
    except OSError as exc:
        return "", False, 0, str(exc)

    truncated = len(raw) > max_bytes
    if truncated:
        head_size = max_bytes // 3
        tail_size = max_bytes - head_size
        raw = raw[:head_size] + b"\n\n... REPORT EMBED OMITTED MIDDLE OF LARGE LOG ...\n\n" + raw[-tail_size:]
    for encoding in ("utf-8-sig", "utf-16", "cp1252", "latin-1"):
        try:
            return raw.decode(encoding), truncated, size, ""
        except UnicodeDecodeError:
            continue
    return raw.decode("utf-8", errors="replace"), truncated, size, ""


def artifact_path(result: dict[str, Any], key: str) -> Path | None:
    return resolve_path(result, (result.get("artifacts") or {}).get(key, ""))


def artifact_link(result: dict[str, Any], key: str, label: str, output_dir: Path, css_class: str = "") -> str:
    target = artifact_path(result, key)
    if not target:
        return ""
    exists = target.exists()
    size = target.stat().st_size if exists and target.is_file() else 0
    state = "" if exists else " missing"
    title = f"{target} ({fmt_bytes(size)})" if exists else f"Missing: {target}"
    icon = {
        "report": "▤",
        "log": "≡",
        "trace": "⌁",
        "video": "▶",
        "har": "⇄",
        "evidenceBundle": "▣",
    }.get(key, "↗")
    return (
        f'<a class="artifact-link {esc(css_class)}{state}" href="{esc(path_href(target, output_dir))}" '
        f'title="{esc(title)}" target="_blank" rel="noopener">'
        f'<span aria-hidden="true">{icon}</span> {esc(label)}'
        f'{f" <small>{esc(fmt_bytes(size))}</small>" if size else ""}</a>'
    )


def collect_screenshot_candidates(result: dict[str, Any]) -> list[tuple[str, Path]]:
    candidates: list[tuple[str, Path]] = []
    for step in result.get("steps", []) or []:
        if not isinstance(step, dict):
            continue
        target = resolve_path(result, step.get("screenshot"))
        if target:
            candidates.append((f"Step {step.get('order', '')}: {step.get('text', '')}", target))
    for index, item in enumerate(result.get("deferredVerifications", []) or [], 1):
        if not isinstance(item, dict):
            continue
        target = resolve_path(result, item.get("screenshot"))
        if target:
            label = item.get("businessStep") or f"Deferred verification {index}"
            candidates.append((str(label), target))

    # The JSON is authoritative.  When a failed run did not persist a screenshot
    # path, recover image evidence from the scenario directory without requiring a
    # C# hook change.
    if normalize_status(result.get("status")) == "FAIL":
        root = Path(str(result.get("_artifactDir") or "."))
        if root.exists():
            try:
                for path in sorted(root.rglob("*")):
                    if path.is_file() and path.suffix.casefold() in IMAGE_SUFFIXES and "consolidated" not in {part.casefold() for part in path.parts}:
                        candidates.append((path.stem.replace("_", " "), path.resolve()))
            except OSError:
                pass

    deduped: list[tuple[str, Path]] = []
    seen: set[str] = set()
    for label, path in candidates:
        key = os.path.normcase(str(path.resolve()))
        if key not in seen:
            seen.add(key)
            deduped.append((label, path.resolve()))
    return deduped


def find_execution_log(result: dict[str, Any]) -> Path | None:
    explicit = artifact_path(result, "log")
    if explicit and explicit.exists():
        return explicit
    root = Path(str(result.get("_artifactDir") or "."))
    if not root.exists():
        return None
    preferred_names = ("execution.log", "execution.txt", "test.log", "log.txt")
    for name in preferred_names:
        path = root / name
        if path.exists() and path.is_file():
            return path.resolve()
    try:
        logs = sorted((path for path in root.glob("*.log") if path.is_file()), key=lambda path: path.stat().st_mtime, reverse=True)
        return logs[0].resolve() if logs else None
    except OSError:
        return None


def split_data(data: Any) -> list[tuple[str, str]]:
    if isinstance(data, dict):
        pairs = []
        for key, value in data.items():
            rendered = "••••••••" if SENSITIVE_KEY.search(str(key)) else str(value)
            pairs.append((str(key), rendered))
        return pairs
    if isinstance(data, list):
        return [(str(index + 1), str(value)) for index, value in enumerate(data)]
    text = str(data or "").strip()
    if not text:
        return []
    pairs: list[tuple[str, str]] = []
    for token in re.split(r";\s*(?=[^;=]+(?:=|:))", text):
        token = token.strip()
        if not token:
            continue
        if "=" in token:
            key, value = token.split("=", 1)
        elif ":" in token:
            key, value = token.split(":", 1)
        else:
            key, value = "Value", token
        key = key.strip()
        value = value.strip()
        if SENSITIVE_KEY.search(key):
            value = "••••••••"
        pairs.append((key or "Value", value))
    return pairs


def render_data(data: Any) -> str:
    pairs = split_data(data)
    if not pairs:
        return '<span class="muted">No resolved data recorded.</span>'
    rows = "".join(
        f'<tr><th scope="row">{esc(key)}</th><td>{esc(value)}</td></tr>'
        for key, value in pairs
    )
    return f'<table class="data-table"><tbody>{rows}</tbody></table>'


def render_text_panel(title: str, value: Any, css_class: str = "") -> str:
    text = str(value or "").strip()
    if not text:
        return ""
    return (
        f'<details class="diagnostic {esc(css_class)}" open>'
        f'<summary>{esc(title)}</summary><pre>{esc(text)}</pre></details>'
    )


# ---------------------------------------------------------------------------
# HTML rendering
# ---------------------------------------------------------------------------

def render_screenshot_gallery(
    result: dict[str, Any], output_dir: Path, limits: ReportLimits
) -> tuple[str, int, int]:
    candidates = collect_screenshot_candidates(result)
    if not candidates:
        return '<p class="muted">No screenshot evidence was recorded for this scenario.</p>', 0, 0

    cards: list[str] = []
    embedded_count = 0
    total_count = len(candidates)
    for label, path in candidates[: limits.max_images_per_scenario]:
        image = embed_image(path, output_dir, limits.max_image_bytes)
        caption = f"{label} · {path.name} · {fmt_bytes(image.size_bytes)}"
        if image.embedded:
            embedded_count += 1
            cards.append(
                '<figure class="evidence-image">'
                f'<button type="button" class="image-button" data-lightbox="true" '
                f'data-lightbox-caption="{esc(caption)}" aria-label="Open {esc(caption)}">'
                f'<img loading="lazy" src="{esc(image.data_uri)}" alt="{esc(label)}"></button>'
                f'<figcaption>{esc(caption)}</figcaption></figure>'
            )
        else:
            cards.append(
                '<div class="evidence-missing">'
                f'<strong>{esc(label)}</strong><br>{esc(image.reason)}<br>'
                f'<a href="{esc(image.href)}" target="_blank" rel="noopener">Open original file</a>'
                '</div>'
            )
    omitted = total_count - len(cards)
    note = f'<p class="notice">{omitted} additional image(s) were not embedded because the per-scenario limit is {limits.max_images_per_scenario}.</p>' if omitted else ""
    return f'<div class="evidence-gallery">{"".join(cards)}</div>{note}', embedded_count, total_count


def render_failure_evidence(result: dict[str, Any], output_dir: Path, limits: ReportLimits) -> str:
    if normalize_status(result.get("status")) != "FAIL":
        return ""

    gallery, embedded_count, total_images = render_screenshot_gallery(result, output_dir, limits)
    log_path = find_execution_log(result)
    log_html = '<p class="muted">No execution log file was found in this scenario evidence directory.</p>'
    if log_path:
        text, truncated, size, error = read_text_file(log_path, limits.max_log_bytes)
        if error:
            log_html = f'<p class="evidence-error">Execution log could not be read: {esc(error)}</p>'
        else:
            truncation = f' · embedded first/last {fmt_bytes(limits.max_log_bytes)}' if truncated else ""
            log_html = (
                f'<div class="embedded-file-meta"><strong>{esc(log_path.name)}</strong> · {esc(fmt_bytes(size))}{esc(truncation)} '
                f'· <a href="{esc(path_href(log_path, output_dir))}" target="_blank" rel="noopener">open original</a></div>'
                f'<pre class="embedded-log">{esc(redact_sensitive_text(text))}</pre>'
            )

    raw_json_path = Path(str(result.get("_resultFile") or ""))
    raw_json_html = ""
    if raw_json_path.exists():
        text, truncated, size, error = read_text_file(raw_json_path, limits.max_raw_json_bytes)
        if not error:
            try:
                parsed = json.loads(text) if not truncated else None
                if parsed is not None:
                    text = json.dumps(redact_json(parsed), indent=2, ensure_ascii=False)
                else:
                    text = redact_sensitive_text(text)
            except json.JSONDecodeError:
                text = redact_sensitive_text(text)
            raw_json_html = (
                f'<details class="raw-json"><summary>Raw scenario-result.json · {esc(fmt_bytes(size))}'
                f'{" · truncated" if truncated else ""}</summary><pre>{esc(text)}</pre></details>'
            )

    return f"""
    <section class="failure-evidence">
      <div class="section-title-row">
        <h4>Failure evidence</h4>
        <span class="evidence-count">{embedded_count}/{total_images} screenshots embedded</span>
      </div>
      <div class="evidence-tabs" role="tablist" aria-label="Failure evidence">
        <button type="button" class="evidence-tab active" data-evidence-tab="screenshots">Screenshots</button>
        <button type="button" class="evidence-tab" data-evidence-tab="execution-log">Execution log</button>
        <button type="button" class="evidence-tab" data-evidence-tab="raw-result">Raw result</button>
      </div>
      <div class="evidence-pane active" data-evidence-pane="screenshots">{gallery}</div>
      <div class="evidence-pane" data-evidence-pane="execution-log">{log_html}</div>
      <div class="evidence-pane" data-evidence-pane="raw-result">{raw_json_html or '<p class="muted">Raw scenario JSON is unavailable.</p>'}</div>
    </section>
    """


def render_deferred_verifications(result: dict[str, Any], output_dir: Path, limits: ReportLimits) -> str:
    items = [item for item in (result.get("deferredVerifications", []) or []) if isinstance(item, dict)]
    if not items:
        return ""
    rows: list[str] = []
    for index, item in enumerate(items, 1):
        screenshot_html = ""
        path = resolve_path(result, item.get("screenshot"))
        if path:
            embedded = embed_image(path, output_dir, limits.max_image_bytes)
            if embedded.embedded:
                screenshot_html = f'<a href="{esc(embedded.href)}" target="_blank" rel="noopener">Open screenshot · embedded below</a>'
            else:
                screenshot_html = f'<a href="{esc(embedded.href)}" target="_blank" rel="noopener">Open screenshot</a>'
        rows.append(
            f'<tr class="FAIL"><td>{index}</td><td>{esc(item.get("businessStep"))}</td>'
            f'<td>{esc(item.get("page"))}.{esc(item.get("control"))}</td>'
            f'<td>{esc(item.get("property"))}</td><td>{esc(item.get("expected"))}</td>'
            f'<td><pre class="cell-pre">{esc(item.get("error"))}</pre></td><td>{screenshot_html}</td></tr>'
        )
    return f"""
    <details class="deferred-block" open>
      <summary><span class="status-pill FAIL">FAIL</span> Deferred verification failures ({len(items)})</summary>
      <p class="small muted">Execution continued after the configured wait so later business and browser evidence could still be collected. NUnit fails the scenario after evidence publication.</p>
      <div class="table-scroll"><table class="detail-table"><thead><tr><th>#</th><th>Business step</th><th>Page.Control</th><th>Property</th><th>Expected</th><th>Error</th><th>Evidence</th></tr></thead><tbody>{''.join(rows)}</tbody></table></div>
    </details>
    """


def render_step(result: dict[str, Any], step: dict[str, Any], output_dir: Path, limits: ReportLimits) -> str:
    step_status = normalize_status(step.get("status"))
    order = step.get("order", "")
    text = str(step.get("text") or "Unnamed step")
    binding = str(step.get("binding") or "Unresolved")
    source = str(step.get("bindingSource") or "")
    line = step.get("bindingLine") or 0
    resolution = str(step.get("bindingResolution") or "")
    source_html = (
        f'<div class="binding-source">{esc(source)}:{esc(line)}</div>' if source else '<div class="binding-source unresolved">No source match</div>'
    )
    resolution_html = f'<div class="binding-note">{esc(resolution)}</div>' if resolution else ""
    diagnostics = "".join(
        panel
        for panel in (
            render_text_panel("Test failure", step.get("error"), "error"),
            render_text_panel("Console / page errors", step.get("consoleErrors"), "console"),
            render_text_panel("Network errors", step.get("networkErrors"), "network"),
        )
        if panel
    )
    screenshot_html = ""
    screenshot_path = resolve_path(result, step.get("screenshot"))
    if screenshot_path:
        embedded = embed_image(screenshot_path, output_dir, limits.max_image_bytes)
        if embedded.embedded and normalize_status(result.get("status")) == "FAIL":
            screenshot_html = f'<a href="{esc(embedded.href)}" target="_blank" rel="noopener">Open screenshot · embedded in Failure evidence</a>'
        else:
            screenshot_html = f'<a href="{esc(embedded.href)}" target="_blank" rel="noopener">Open screenshot</a>'

    open_attribute = " open" if step_status == "FAIL" else ""
    return f"""
    <details class="step-row {step_status}"{open_attribute}>
      <summary>
        <span class="step-order">{esc(order)}</span>
        <span class="step-kind">KEYWORD</span>
        <span class="step-name">{esc(text)}</span>
        <span class="step-duration">{esc(fmt_duration(duration_ms(step)))}</span>
        <span class="status-pill {step_status}">{step_status}</span>
      </summary>
      <div class="step-body">
        <div class="step-grid">
          <div><div class="field-label">C# step definition</div><strong>{esc(binding)}</strong>{source_html}{resolution_html}</div>
          <div><div class="field-label">Resolved test data</div>{render_data(step.get('data'))}</div>
          <div><div class="field-label">Step screenshot</div>{screenshot_html or '<span class="muted">Not recorded</span>'}</div>
        </div>
        {diagnostics or '<p class="muted no-diagnostics">No error, console or network diagnostics were recorded for this step.</p>'}
      </div>
    </details>
    """


def render_artifact_strip(result: dict[str, Any], output_dir: Path) -> str:
    links = [
        artifact_link(result, "report", "Individual report", output_dir),
        artifact_link(result, "log", "Execution log", output_dir),
        artifact_link(result, "trace", "Playwright trace", output_dir),
        artifact_link(result, "video", "Video", output_dir),
        artifact_link(result, "har", "HAR", output_dir),
        artifact_link(result, "evidenceBundle", "Evidence bundle", output_dir),
    ]
    links = [link for link in links if link]
    return '<div class="artifact-strip">' + ("".join(links) if links else '<span class="muted">No finalized artifact links were recorded.</span>') + "</div>"


def render_video(result: dict[str, Any], output_dir: Path) -> str:
    path = artifact_path(result, "video")
    if not path or not path.exists():
        return ""
    href = path_href(path, output_dir)
    return f"""
    <details class="video-block">
      <summary>Recorded execution video · {esc(fmt_bytes(path.stat().st_size))}</summary>
      <video controls preload="metadata" src="{esc(href)}">Your browser cannot play this video. <a href="{esc(href)}">Open the file</a>.</video>
    </details>
    """


def render_scenario(result: dict[str, Any], output_dir: Path, limits: ReportLimits, ordinal: int) -> str:
    scenario_status = normalize_status(result.get("status"))
    feature = str(result.get("feature") or "Unknown feature")
    scenario = str(result.get("scenario") or "Unknown scenario")
    state_code = str(result.get("_stateCode") or "—")
    application = str(result.get("_application") or "Unspecified")
    lob = str(result.get("_lob") or "—")
    tags = [str(tag) for tag in result.get("_tags", [])]
    scenario_id = slug(f"{ordinal}-{feature}-{scenario}", "scenario")
    search_text = " ".join([feature, scenario, scenario_status, application, state_code, lob, *tags]).casefold()
    tag_html = "".join(f'<span class="tag">{esc(tag)}</span>' for tag in tags)
    steps = [step for step in (result.get("steps", []) or []) if isinstance(step, dict)]
    passed_steps = sum(normalize_status(step.get("status")) == "PASS" for step in steps)
    failed_steps = sum(normalize_status(step.get("status")) == "FAIL" for step in steps)
    skipped_steps = sum(normalize_status(step.get("status")) == "SKIP" for step in steps)
    step_html = "".join(render_step(result, step, output_dir, limits) for step in steps)
    if not step_html:
        step_html = '<p class="notice">No executed business steps were recorded in scenario-result.json.</p>'

    open_attribute = " open" if scenario_status == "FAIL" else ""
    result_file = Path(str(result.get("_resultFile") or ""))
    result_href = path_href(result_file, output_dir) if result_file else ""
    result_source = (
        f'<a href="{esc(result_href)}" target="_blank" rel="noopener">{esc(result_file.name)}</a>'
        if result_file and result_file.exists()
        else esc(result_file)
    )
    return f"""
    <article class="scenario-card {scenario_status}" id="{esc(scenario_id)}"
      data-status="{esc(scenario_status)}" data-feature="{esc(feature)}" data-state="{esc(state_code)}"
      data-application="{esc(application)}" data-lob="{esc(lob)}" data-search="{esc(search_text)}">
      <details class="scenario-details"{open_attribute}>
        <summary>
          <span class="scenario-index">{ordinal:03d}</span>
          <span class="test-label">TEST</span>
          <span class="scenario-title">{esc(scenario)}</span>
          <span class="scenario-context">{esc(application)} · {esc(lob)} · {esc(state_code)}</span>
          <span class="scenario-duration">{esc(fmt_duration(duration_ms(result)))}</span>
          <span class="status-pill {scenario_status}">{scenario_status}</span>
        </summary>
        <div class="scenario-content">
          <div class="scenario-meta-grid">
            <div><span class="field-label">Feature / suite</span><strong>{esc(feature)}</strong></div>
            <div><span class="field-label">Start</span>{esc(fmt_timestamp(result.get('startedAtUtc')))}</div>
            <div><span class="field-label">End</span>{esc(fmt_timestamp(result.get('completedAtUtc')))}</div>
            <div><span class="field-label">Steps</span>{len(steps)} total · <span class="pass-text">{passed_steps} passed</span> · <span class="fail-text">{failed_steps} failed</span> · {skipped_steps} skipped</div>
            <div class="meta-wide"><span class="field-label">Tags</span>{tag_html or '<span class="muted">No tags inferred</span>'}</div>
            <div class="meta-wide"><span class="field-label">Scenario result source</span>{result_source}</div>
          </div>
          {render_artifact_strip(result, output_dir)}
          {render_deferred_verifications(result, output_dir, limits)}
          <div class="steps-heading"><h4>Execution steps</h4><span>{len(steps)} keyword(s)</span></div>
          <div class="step-list">{step_html}</div>
          {render_failure_evidence(result, output_dir, limits)}
          {render_video(result, output_dir)}
        </div>
      </details>
    </article>
    """


def render_stat_rows(counter: Counter[str], status_by_group: dict[str, Counter[str]], duration_by_group: dict[str, float], group_type: str) -> str:
    rows: list[str] = []
    for name, total in sorted(counter.items(), key=lambda item: (-item[1], item[0].casefold())):
        counts = status_by_group[name]
        pass_count = counts.get("PASS", 0)
        fail_count = counts.get("FAIL", 0)
        skip_count = counts.get("SKIP", 0)
        rate = (pass_count / total * 100) if total else 0.0
        rows.append(
            f'<tr class="click-filter" data-filter-type="{esc(group_type)}" data-filter-value="{esc(name)}" title="Click to filter details">'
            f'<td><a href="#test-details">{esc(name)}</a></td><td>{total}</td><td class="pass-text">{pass_count}</td>'
            f'<td class="fail-text">{fail_count}</td><td>{skip_count}</td><td>{esc(fmt_duration(duration_by_group.get(name, 0)))}</td>'
            f'<td><div class="mini-bar"><span class="pass-segment" style="width:{rate:.3f}%"></span></div><small>{rate:.1f}%</small></td></tr>'
        )
    return "".join(rows)


def count_groups(results: Sequence[dict[str, Any]], key: str) -> tuple[Counter[str], dict[str, Counter[str]], dict[str, float]]:
    totals: Counter[str] = Counter()
    statuses: dict[str, Counter[str]] = defaultdict(Counter)
    durations: dict[str, float] = defaultdict(float)
    for result in results:
        name = str(result.get(key) or "—")
        totals[name] += 1
        statuses[name][normalize_status(result.get("status"))] += 1
        durations[name] += duration_ms(result)
    return totals, statuses, durations


def render_statistics_table(title: str, rows: str, first_header: str) -> str:
    if not rows:
        return ""
    return f"""
    <section class="statistics-panel">
      <h3>{esc(title)}</h3>
      <div class="table-scroll"><table class="statistics-table"><thead><tr><th>{esc(first_header)}</th><th>Total</th><th>Pass</th><th>Fail</th><th>Skip</th><th>Elapsed</th><th>Pass rate</th></tr></thead><tbody>{rows}</tbody></table></div>
    </section>
    """


def render_flat_log(results: Sequence[dict[str, Any]]) -> str:
    blocks: list[str] = []
    for result_index, result in enumerate(results, 1):
        scenario_status = normalize_status(result.get("status"))
        feature = str(result.get("feature") or "Unknown feature")
        scenario = str(result.get("scenario") or "Unknown scenario")
        steps = [step for step in (result.get("steps", []) or []) if isinstance(step, dict)]
        step_blocks: list[str] = []
        for step in steps:
            step_status = normalize_status(step.get("status"))
            diagnostics = "\n\n".join(
                text for text in [str(step.get("error") or ""), str(step.get("consoleErrors") or ""), str(step.get("networkErrors") or "")] if text.strip()
            )
            step_blocks.append(
                f'<details class="log-step {step_status}" {"open" if step_status == "FAIL" else ""}>'
                f'<summary><span class="step-kind">KEYWORD</span> {esc(step.get("text"))}'
                f'<span class="step-duration">{esc(fmt_duration(duration_ms(step)))}</span><span class="status-pill {step_status}">{step_status}</span></summary>'
                f'<div class="log-step-body"><div><strong>Binding:</strong> {esc(step.get("binding"))}</div>'
                f'<div><strong>Source:</strong> {esc(step.get("bindingSource"))}:{esc(step.get("bindingLine"))}</div>'
                f'{render_data(step.get("data"))}'
                f'{f"<pre>{esc(diagnostics)}</pre>" if diagnostics else ""}</div></details>'
            )
        blocks.append(
            f'<section class="log-suite" data-status="{esc(scenario_status)}" data-search="{esc((feature + " " + scenario).casefold())}">'
            f'<details {"open" if scenario_status == "FAIL" else ""}><summary><span class="test-label">TEST</span> '
            f'{esc(feature)} / {esc(scenario)}<span class="step-duration">{esc(fmt_duration(duration_ms(result)))}</span>'
            f'<span class="status-pill {scenario_status}">{scenario_status}</span></summary>'
            f'<div class="log-scenario-meta">Start / End: {esc(fmt_timestamp(result.get("startedAtUtc")))} / {esc(fmt_timestamp(result.get("completedAtUtc")))}</div>'
            f'{"".join(step_blocks) or "<p class=\"muted\">No step records.</p>"}</details></section>'
        )
    return "".join(blocks) or '<p class="notice">No scenario results were discovered.</p>'


REPORT_CSS = r"""
:root {
  --pass: #238636;
  --pass-soft: #eaf7ec;
  --fail: #c62828;
  --fail-soft: #fff0f0;
  --skip: #9a6700;
  --skip-soft: #fff8d8;
  --unknown: #59636e;
  --ink: #17191c;
  --muted: #5f6b76;
  --line: #c9ced4;
  --line-dark: #9aa1a9;
  --panel: #ffffff;
  --canvas: #f5f6f7;
  --robot-green: #98ee98;
  --robot-red: #ffb1ae;
  --black: #050505;
  --link: #0066cc;
  --shadow: 0 8px 26px rgba(31, 35, 40, .09);
}
* { box-sizing: border-box; }
html { scroll-behavior: smooth; }
body { margin: 0; color: var(--ink); background: var(--canvas); font-family: Arial, Helvetica, sans-serif; font-size: 13px; }
a { color: var(--link); text-decoration: none; }
a:hover { text-decoration: underline; }
button, input, select { font: inherit; }
button { cursor: pointer; }
.report-shell { min-height: 100vh; }
.robot-banner { position: relative; padding: 22px 24px 18px; border-bottom: 1px solid #7f8a94; background: var(--robot-green); }
.robot-banner.FAIL { background: var(--robot-red); }
.robot-banner.SKIP, .robot-banner.UNKNOWN { background: var(--skip-soft); }
.robot-banner h1 { margin: 0 0 10px; font-size: 27px; line-height: 1.1; }
.robot-banner .generated { position: absolute; right: 330px; top: 18px; text-align: right; line-height: 1.35; }
.robot-tabs { position: absolute; top: 0; right: 0; display: flex; }
.robot-tabs button { min-width: 152px; padding: 8px 18px; border: 0; border-left: 1px solid #333; color: #fff; background: var(--black); font-weight: 800; letter-spacing: 1px; }
.robot-tabs button.active { background: #252525; box-shadow: inset 0 -4px 0 #fff; }
.banner-summary { max-width: 980px; display: grid; grid-template-columns: 145px 1fr; gap: 5px 10px; }
.banner-summary dt { font-weight: 700; }
.banner-summary dd { margin: 0; min-width: 0; word-break: break-word; }
.main-content { padding: 20px 24px 42px; }
.view { display: none; }
.view.active { display: block; }
.section-heading { display: flex; align-items: end; justify-content: space-between; gap: 12px; margin: 0 0 10px; }
h2 { margin: 20px 0 10px; font-size: 21px; }
h3 { margin: 0 0 8px; font-size: 16px; }
h4 { margin: 0; font-size: 15px; }
.cards { display: grid; grid-template-columns: repeat(6, minmax(125px, 1fr)); gap: 10px; margin: 12px 0 18px; }
.card { border: 1px solid var(--line); background: var(--panel); padding: 12px 14px; box-shadow: 0 1px 2px rgba(31,35,40,.04); }
.card span { display: block; color: var(--muted); font-size: 11px; text-transform: uppercase; letter-spacing: .05em; }
.card strong { display: block; margin-top: 4px; font-size: 24px; line-height: 1; }
.pass-text { color: var(--pass); font-weight: 700; }
.fail-text { color: var(--fail); font-weight: 700; }
.skip-text { color: var(--skip); font-weight: 700; }
.overall-bar { height: 18px; display: flex; overflow: hidden; border: 1px solid var(--line-dark); background: #fff; }
.overall-bar span { display: block; min-width: 0; }
.overall-bar .pass { background: var(--pass); }
.overall-bar .fail { background: var(--fail); }
.overall-bar .skip { background: var(--skip); }
.overall-bar-legend { display: flex; gap: 16px; margin: 5px 0 18px; color: var(--muted); }
.legend-swatch { width: 9px; height: 9px; display: inline-block; margin-right: 4px; }
.statistics-grid { display: grid; grid-template-columns: repeat(2, minmax(0, 1fr)); gap: 14px; align-items: start; }
.statistics-panel { border: 1px solid var(--line); background: var(--panel); padding: 10px; }
.table-scroll { overflow-x: auto; }
table { width: 100%; border-collapse: collapse; }
th, td { padding: 6px 8px; border: 1px solid var(--line); text-align: left; vertical-align: top; }
thead th { position: sticky; top: 0; z-index: 1; background: #e6e8ea; color: #111; font-weight: 700; }
.statistics-table td:not(:first-child), .statistics-table th:not(:first-child) { text-align: center; white-space: nowrap; }
.statistics-table tr:hover { background: #f0f6ff; }
.statistics-table .click-filter { cursor: pointer; }
.mini-bar { display: inline-block; width: 110px; height: 11px; margin-right: 6px; vertical-align: middle; border: 1px solid #b5bac1; background: #fff; }
.mini-bar .pass-segment { display: block; height: 100%; background: #8bc34a; }
.toolbar { position: sticky; top: 0; z-index: 20; display: flex; flex-wrap: wrap; gap: 8px; align-items: center; padding: 10px; margin: 14px 0 10px; border: 1px solid var(--line-dark); background: rgba(255,255,255,.97); box-shadow: var(--shadow); }
.toolbar input, .toolbar select { padding: 7px 8px; border: 1px solid var(--line-dark); background: #fff; }
.toolbar input { flex: 2 1 280px; min-width: 220px; }
.toolbar select { flex: 1 1 118px; min-width: 105px; }
.toolbar button { flex: 0 0 auto; padding: 7px 10px; border: 1px solid var(--line-dark); background: #f0f1f2; white-space: nowrap; }
.toolbar button:hover { background: #e4e6e8; }
.visible-count { color: var(--muted); white-space: nowrap; text-align: right; }
.feature-group { margin: 12px 0 18px; }
.feature-group > details { border: 1px solid var(--line-dark); background: #fff; }
.feature-group > details > summary { display: flex; align-items: center; gap: 8px; padding: 8px 10px; background: #dfe2e5; font-weight: 800; cursor: pointer; }
.feature-group .feature-counts { margin-left: auto; color: var(--muted); font-weight: 400; }
.scenario-list { padding: 8px; }
.scenario-card { margin: 7px 0; border: 1px solid var(--line); background: #fff; }
.scenario-card.hidden, .feature-group.hidden, .log-suite.hidden { display: none; }
.scenario-details > summary { display: grid; grid-template-columns: 42px 52px minmax(260px, 1fr) minmax(150px, auto) 95px 64px; align-items: center; gap: 8px; padding: 8px 10px; cursor: pointer; background: #f7f7f7; border-left: 7px solid var(--unknown); list-style-position: inside; }
.scenario-card.PASS .scenario-details > summary { border-left-color: var(--pass); }
.scenario-card.FAIL .scenario-details > summary { border-left-color: var(--fail); background: var(--fail-soft); }
.scenario-card.SKIP .scenario-details > summary { border-left-color: var(--skip); background: var(--skip-soft); }
.scenario-index { color: var(--muted); font-family: Consolas, monospace; }
.test-label, .step-kind { display: inline-block; padding: 2px 5px; color: #fff; background: #d13f0b; font-size: 10px; font-weight: 800; line-height: 1.25; }
.step-kind { background: #70a538; color: #071400; }
.scenario-title { font-weight: 800; }
.scenario-context { color: var(--muted); font-size: 11px; text-align: right; }
.scenario-duration, .step-duration { color: var(--muted); font-variant-numeric: tabular-nums; text-align: right; }
.status-pill { display: inline-block; min-width: 48px; padding: 2px 6px; color: #fff; text-align: center; font-size: 10px; font-weight: 800; border-radius: 2px; }
.status-pill.PASS { background: var(--pass); }
.status-pill.FAIL { background: var(--fail); }
.status-pill.SKIP { background: var(--skip); }
.status-pill.UNKNOWN { background: var(--unknown); }
.scenario-content { padding: 12px; }
.scenario-meta-grid { display: grid; grid-template-columns: repeat(4, minmax(0, 1fr)); gap: 9px; margin-bottom: 10px; }
.scenario-meta-grid > div { padding: 8px; border: 1px solid #e1e4e8; background: #fbfbfc; min-width: 0; word-break: break-word; }
.scenario-meta-grid .meta-wide { grid-column: span 2; }
.field-label { display: block; margin-bottom: 3px; color: var(--muted); font-size: 10px; font-weight: 700; text-transform: uppercase; letter-spacing: .04em; }
.tag { display: inline-block; margin: 1px 4px 1px 0; padding: 2px 6px; border: 1px solid #b7c9db; background: #eaf3fb; color: #194d78; font-size: 10px; border-radius: 10px; }
.artifact-strip { display: flex; flex-wrap: wrap; gap: 6px; margin: 8px 0 12px; }
.artifact-link { display: inline-flex; gap: 4px; align-items: center; padding: 5px 8px; border: 1px solid #b9c4cf; background: #edf4fb; border-radius: 2px; }
.artifact-link small { color: var(--muted); }
.artifact-link.missing { border-color: #e1b9b9; background: #fff1f1; color: #9b2c2c; text-decoration: line-through; }
.steps-heading, .section-title-row { display: flex; align-items: center; justify-content: space-between; gap: 12px; margin: 14px 0 6px; }
.steps-heading span, .evidence-count { color: var(--muted); }
.step-list { border: 1px solid var(--line); }
.step-row { border-bottom: 1px solid var(--line); background: #fff; }
.step-row:last-child { border-bottom: 0; }
.step-row > summary { display: grid; grid-template-columns: 38px 64px minmax(260px, 1fr) 95px 60px; gap: 7px; align-items: center; padding: 7px 8px; cursor: pointer; list-style-position: inside; }
.step-row.FAIL > summary { background: var(--fail-soft); }
.step-row.SKIP > summary { background: var(--skip-soft); }
.step-order { color: var(--muted); font-family: Consolas, monospace; }
.step-name { font-weight: 700; }
.step-body { padding: 10px 12px 12px 36px; border-top: 1px dashed var(--line); background: #fcfcfd; }
.step-grid { display: grid; grid-template-columns: 1fr 1.5fr 130px; gap: 10px; }
.step-grid > div { min-width: 0; padding: 8px; border: 1px solid #e0e3e6; background: #fff; overflow-wrap: anywhere; }
.binding-source, .binding-note { margin-top: 3px; color: var(--muted); font-family: Consolas, monospace; font-size: 10px; }
.binding-source.unresolved { color: var(--fail); }
.data-table th { width: 34%; background: #f2f3f5; font-weight: 700; }
.data-table td, .data-table th { padding: 4px 6px; font-size: 11px; word-break: break-word; }
.diagnostic { margin: 8px 0 0; border: 1px solid #d7a8a8; background: #fff7f7; }
.diagnostic > summary { padding: 6px 8px; color: #7f1d1d; font-weight: 700; cursor: pointer; }
pre { margin: 0; padding: 9px; white-space: pre-wrap; word-break: break-word; overflow-wrap: anywhere; font-family: Consolas, Menlo, monospace; font-size: 11px; line-height: 1.42; background: #f7f7f8; }
.no-diagnostics { margin: 8px 0 0; }
.thumb-button, .image-button { padding: 0; border: 0; background: transparent; }
.thumb-button img { max-width: 110px; max-height: 76px; object-fit: contain; border: 1px solid var(--line); }
.failure-evidence { margin-top: 16px; padding: 12px; border: 2px solid var(--fail); background: #fff; }
.evidence-tabs { display: flex; gap: 0; margin: 8px 0 0; border-bottom: 1px solid var(--line-dark); }
.evidence-tab { padding: 7px 12px; border: 1px solid var(--line-dark); border-bottom: 0; margin-right: -1px; background: #eceeef; font-weight: 700; }
.evidence-tab.active { background: #fff; transform: translateY(1px); }
.evidence-pane { display: none; padding: 10px 0 0; }
.evidence-pane.active { display: block; }
.evidence-gallery { display: grid; grid-template-columns: repeat(auto-fill, minmax(270px, 1fr)); gap: 10px; }
.evidence-image { margin: 0; border: 1px solid var(--line); background: #f7f8f9; }
.evidence-image img { display: block; width: 100%; max-height: 320px; object-fit: contain; background: #111; }
.evidence-image figcaption { padding: 7px; font-size: 11px; overflow-wrap: anywhere; }
.evidence-missing { padding: 12px; border: 1px dashed var(--fail); background: var(--fail-soft); }
.embedded-file-meta { padding: 6px 8px; border: 1px solid var(--line); border-bottom: 0; background: #eceff2; }
.embedded-log { max-height: 560px; overflow: auto; border: 1px solid var(--line); background: #101418; color: #e7edf3; }
.raw-json > summary, .video-block > summary, .deferred-block > summary { padding: 7px 9px; cursor: pointer; font-weight: 700; background: #eef0f2; border: 1px solid var(--line); }
.raw-json pre { max-height: 520px; overflow: auto; border: 1px solid var(--line); border-top: 0; }
.deferred-block { margin: 10px 0; border: 1px solid var(--fail); }
.deferred-block > p, .deferred-block > .table-scroll { margin: 8px; }
.cell-pre { padding: 0; background: transparent; }
.video-block { margin-top: 10px; }
.video-block video { width: min(100%, 1000px); max-height: 560px; display: block; margin: 8px auto 0; background: #111; }
.notice { padding: 9px; border: 1px solid #d9c783; background: #fff9df; }
.evidence-error { padding: 9px; border: 1px solid var(--fail); background: var(--fail-soft); }
.muted { color: var(--muted); }
.small { font-size: 11px; }
.log-toolbar { display: flex; gap: 8px; margin: 12px 0; }
.log-toolbar input, .log-toolbar select { padding: 7px 8px; border: 1px solid var(--line-dark); }
.log-toolbar input { min-width: 320px; }
.log-suite { margin: 7px 0; border: 1px solid var(--line); background: #fff; }
.log-suite > details > summary { padding: 8px 10px; background: #eceeef; font-weight: 700; cursor: pointer; }
.log-suite .status-pill, .log-step .status-pill { float: right; margin-left: 8px; }
.log-suite .step-duration, .log-step .step-duration { float: right; margin-left: 12px; }
.log-scenario-meta { padding: 7px 10px; color: var(--muted); border-top: 1px solid var(--line); }
.log-step { margin: 0 10px; border-top: 1px dashed var(--line); }
.log-step > summary { padding: 7px 6px; cursor: pointer; }
.log-step.FAIL > summary { background: var(--fail-soft); }
.log-step-body { padding: 8px 16px 10px; }
.lightbox { position: fixed; inset: 0; z-index: 9999; display: none; align-items: center; justify-content: center; padding: 24px; background: rgba(0,0,0,.88); }
.lightbox.open { display: flex; }
.lightbox-inner { max-width: 96vw; max-height: 94vh; display: grid; grid-template-rows: auto 1fr auto; gap: 8px; }
.lightbox-close { justify-self: end; width: 38px; height: 38px; border: 1px solid #fff; background: #111; color: #fff; font-size: 25px; }
.lightbox img { max-width: 94vw; max-height: 82vh; object-fit: contain; background: #111; }
.lightbox-caption { color: #fff; text-align: center; }
@media (max-width: 1120px) {
  .robot-banner .generated { position: static; text-align: left; margin: 8px 0 10px; }
  .cards { grid-template-columns: repeat(3, 1fr); }
  .statistics-grid { grid-template-columns: 1fr; }
  .scenario-meta-grid { grid-template-columns: repeat(2, minmax(0,1fr)); }
  .scenario-details > summary { grid-template-columns: 34px 46px minmax(200px,1fr) 80px 58px; }
  .scenario-context { display: none; }
  .step-grid { grid-template-columns: 1fr; }
}
@media (max-width: 700px) {
  .robot-banner { padding: 70px 14px 14px; }
  .robot-banner .generated { position: static; text-align: left; margin-bottom: 10px; }
  .robot-tabs { left: 0; right: auto; width: 100%; }
  .robot-tabs button { flex: 1; min-width: 0; }
  .main-content { padding: 12px; }
  .cards { grid-template-columns: repeat(2, 1fr); }
  .banner-summary { grid-template-columns: 110px 1fr; }
  .toolbar { position: static; display: grid; grid-template-columns: 1fr; }
  .toolbar input, .toolbar select, .toolbar button { width: 100%; min-width: 0; }
  .scenario-details > summary { grid-template-columns: 34px 44px minmax(130px,1fr) 52px; }
  .scenario-index, .scenario-duration { display: none; }
  .scenario-meta-grid { grid-template-columns: 1fr; }
  .scenario-meta-grid .meta-wide { grid-column: span 1; }
  .step-row > summary { grid-template-columns: 50px minmax(130px,1fr) 50px; }
  .step-order, .step-duration { display: none; }
  .step-body { padding-left: 8px; }
}
@media print {
  @page { size: A4 landscape; margin: 10mm; }
  body { background: #fff; font-size: 11px; }
  .robot-banner { padding: 16px 18px; }
  .robot-banner h1 { font-size: 24px; }
  .robot-banner .generated { position: static; margin: 6px 0 10px; text-align: left; }
  .banner-summary { max-width: none; grid-template-columns: 120px 1fr; }
  .robot-tabs, .toolbar, .log-toolbar, .lightbox { display: none !important; }
  .main-content { padding: 14px 18px; }
  .view { display: block !important; }
  #log-view { page-break-before: always; }
  .cards { grid-template-columns: repeat(3, 1fr); }
  .statistics-grid { grid-template-columns: 1fr; }
  .statistics-panel { break-inside: avoid; }
  .scenario-details, .feature-group > details, .step-row, .log-suite > details, .log-step { display: block; }
  details > * { display: block; }
  .scenario-details > summary { grid-template-columns: 36px 48px minmax(240px, 1fr) 180px 80px 58px; }
  .scenario-meta-grid { grid-template-columns: repeat(2, minmax(0,1fr)); }
  .step-grid { grid-template-columns: 1fr 1.35fr 120px; }
  .scenario-card, .step-row, .evidence-image { break-inside: avoid; }
  .failure-evidence { break-inside: auto; }
  .evidence-gallery { display: block; }
  .evidence-image { margin: 0 0 10px; }
  .evidence-image img { max-height: 420px; }
}
"""


REPORT_JS = r"""
(function () {
  'use strict';
  const byId = (id) => document.getElementById(id);
  const all = (selector, root) => Array.from((root || document).querySelectorAll(selector));

  function setView(name) {
    all('.view').forEach((view) => view.classList.toggle('active', view.id === name + '-view'));
    all('.robot-tabs button').forEach((button) => button.classList.toggle('active', button.dataset.view === name));
    history.replaceState(null, '', name === 'report' ? '#report' : '#log');
  }

  all('.robot-tabs button').forEach((button) => button.addEventListener('click', () => setView(button.dataset.view)));
  if (location.hash === '#log') setView('log');

  const controls = {
    search: byId('filter-search'),
    status: byId('filter-status'),
    feature: byId('filter-feature'),
    application: byId('filter-application'),
    state: byId('filter-state'),
    lob: byId('filter-lob')
  };

  function applyFilters() {
    const query = (controls.search.value || '').trim().toLowerCase();
    let visible = 0;
    all('.scenario-card').forEach((card) => {
      const matches = (!query || (card.dataset.search || '').includes(query))
        && (!controls.status.value || card.dataset.status === controls.status.value)
        && (!controls.feature.value || card.dataset.feature === controls.feature.value)
        && (!controls.application.value || card.dataset.application === controls.application.value)
        && (!controls.state.value || card.dataset.state === controls.state.value)
        && (!controls.lob.value || card.dataset.lob === controls.lob.value);
      card.classList.toggle('hidden', !matches);
      if (matches) visible += 1;
    });
    all('.feature-group').forEach((group) => {
      const anyVisible = all('.scenario-card:not(.hidden)', group).length > 0;
      group.classList.toggle('hidden', !anyVisible);
    });
    byId('visible-count').textContent = visible + ' of ' + all('.scenario-card').length + ' tests';
  }

  Object.values(controls).forEach((control) => control.addEventListener(control.tagName === 'INPUT' ? 'input' : 'change', applyFilters));
  byId('clear-filters').addEventListener('click', () => {
    Object.values(controls).forEach((control) => { control.value = ''; });
    applyFilters();
  });
  byId('failures-only').addEventListener('click', () => {
    controls.status.value = controls.status.value === 'FAIL' ? '' : 'FAIL';
    applyFilters();
  });
  byId('expand-visible').addEventListener('click', () => {
    all('.scenario-card:not(.hidden) > details, .feature-group:not(.hidden) > details').forEach((node) => { node.open = true; });
  });
  byId('collapse-all').addEventListener('click', () => {
    all('.scenario-card > details').forEach((node) => { node.open = false; });
  });

  all('.click-filter').forEach((row) => row.addEventListener('click', () => {
    const type = row.dataset.filterType;
    const value = row.dataset.filterValue;
    const target = type === 'feature' ? controls.feature
      : type === 'application' ? controls.application
      : type === 'state' ? controls.state
      : type === 'lob' ? controls.lob : null;
    if (target) {
      target.value = value;
      applyFilters();
      byId('test-details').scrollIntoView({behavior: 'smooth'});
    }
  }));

  all('.failure-evidence').forEach((section) => {
    all('.evidence-tab', section).forEach((tab) => tab.addEventListener('click', () => {
      const name = tab.dataset.evidenceTab;
      all('.evidence-tab', section).forEach((item) => item.classList.toggle('active', item === tab));
      all('.evidence-pane', section).forEach((pane) => pane.classList.toggle('active', pane.dataset.evidencePane === name));
    }));
  });

  const lightbox = byId('lightbox');
  const lightboxImage = byId('lightbox-image');
  const lightboxCaption = byId('lightbox-caption');
  function closeLightbox() {
    lightbox.classList.remove('open');
    lightbox.setAttribute('aria-hidden', 'true');
    lightboxImage.src = '';
  }
  all('[data-lightbox]').forEach((button) => button.addEventListener('click', () => {
    const image = button.querySelector('img');
    lightboxImage.src = image ? image.src : '';
    lightboxCaption.textContent = button.dataset.lightboxCaption || '';
    lightbox.classList.add('open');
    lightbox.setAttribute('aria-hidden', 'false');
    byId('lightbox-close').focus();
  }));
  byId('lightbox-close').addEventListener('click', closeLightbox);
  lightbox.addEventListener('click', (event) => { if (event.target === lightbox) closeLightbox(); });
  document.addEventListener('keydown', (event) => { if (event.key === 'Escape') closeLightbox(); });

  const logSearch = byId('log-search');
  const logStatus = byId('log-status');
  function filterLog() {
    const query = (logSearch.value || '').trim().toLowerCase();
    all('.log-suite').forEach((block) => {
      const matches = (!query || (block.dataset.search || '').includes(query))
        && (!logStatus.value || block.dataset.status === logStatus.value);
      block.classList.toggle('hidden', !matches);
    });
  }
  logSearch.addEventListener('input', filterLog);
  logStatus.addEventListener('change', filterLog);

  applyFilters();
})();
"""


def select_options(values: Iterable[str], selected_label: str) -> str:
    unique = sorted({str(value) for value in values if str(value)}, key=str.casefold)
    return f'<option value="">All {esc(selected_label)}</option>' + "".join(
        f'<option value="{esc(value)}">{esc(value)}</option>' for value in unique
    )


def write_report(
    results: list[dict[str, Any]],
    output_dir: Path,
    generated: str,
    evidence_root: Path,
    source_root: Path,
    limits: ReportLimits,
) -> dict[str, Any]:
    output_dir.mkdir(parents=True, exist_ok=True)
    total = len(results)
    counts = Counter(normalize_status(result.get("status")) for result in results)
    passed = counts.get("PASS", 0)
    failed = counts.get("FAIL", 0)
    skipped = counts.get("SKIP", 0)
    unknown = counts.get("UNKNOWN", 0)
    total_ms = sum(duration_ms(result) for result in results)
    overall = "PASS" if total > 0 and failed == 0 and unknown == 0 else ("UNKNOWN" if total == 0 else "FAIL")
    pass_rate = (passed / total * 100.0) if total else 0.0
    fail_rate = (failed / total * 100.0) if total else 0.0
    skip_rate = ((skipped + unknown) / total * 100.0) if total else 0.0
    start, end, wall_ms = run_window(results)

    by_feature: dict[str, list[dict[str, Any]]] = defaultdict(list)
    for result in results:
        by_feature[str(result.get("feature") or "Unknown feature")].append(result)

    ordered_results = sorted(
        results,
        key=lambda result: (
            {"FAIL": 0, "UNKNOWN": 1, "SKIP": 2, "PASS": 3}.get(normalize_status(result.get("status")), 4),
            str(result.get("feature") or "").casefold(),
            str(result.get("scenario") or "").casefold(),
        ),
    )
    ordinal_by_id = {id(result): index for index, result in enumerate(ordered_results, 1)}

    feature_groups: list[str] = []
    for feature, scenarios in sorted(by_feature.items(), key=lambda item: item[0].casefold()):
        feature_counts = Counter(normalize_status(item.get("status")) for item in scenarios)
        feature_status = "FAIL" if feature_counts.get("FAIL", 0) else ("SKIP" if feature_counts.get("SKIP", 0) else "PASS")
        rendered = "".join(
            render_scenario(result, output_dir, limits, ordinal_by_id[id(result)])
            for result in sorted(
                scenarios,
                key=lambda result: (
                    normalize_status(result.get("status")) != "FAIL",
                    str(result.get("scenario") or "").casefold(),
                ),
            )
        )
        feature_groups.append(
            f'<section class="feature-group" data-feature="{esc(feature)}"><details open><summary>'
            f'<span class="status-pill {feature_status}">{feature_status}</span> SUITE {esc(feature)}'
            f'<span class="feature-counts">{len(scenarios)} tests · {feature_counts.get("PASS",0)} passed · '
            f'{feature_counts.get("FAIL",0)} failed · {esc(fmt_duration(sum(duration_ms(item) for item in scenarios)))}</span>'
            f'</summary><div class="scenario-list">{rendered}</div></details></section>'
        )

    feature_totals, feature_statuses, feature_durations = count_groups(results, "feature")
    app_totals, app_statuses, app_durations = count_groups(results, "_application")
    state_totals, state_statuses, state_durations = count_groups(results, "_stateCode")
    lob_totals, lob_statuses, lob_durations = count_groups(results, "_lob")

    statistics_html = "".join(
        [
            render_statistics_table("Statistics by feature", render_stat_rows(feature_totals, feature_statuses, feature_durations, "feature"), "Feature"),
            render_statistics_table("Statistics by application", render_stat_rows(app_totals, app_statuses, app_durations, "application"), "Application"),
            render_statistics_table("Statistics by state", render_stat_rows(state_totals, state_statuses, state_durations, "state"), "State"),
            render_statistics_table("Statistics by LOB", render_stat_rows(lob_totals, lob_statuses, lob_durations, "lob"), "LOB"),
        ]
    )

    report_body = "".join(feature_groups) if feature_groups else '<p class="notice">No scenario-result.json files were found below the supplied evidence root.</p>'
    flat_log = render_flat_log(ordered_results)

    generated_text = fmt_timestamp(generated)
    start_text = start.strftime("%Y-%m-%d %H:%M:%S.%f")[:-3] + " UTC" if start else "Not recorded"
    end_text = end.strftime("%Y-%m-%d %H:%M:%S.%f")[:-3] + " UTC" if end else "Not recorded"
    source_text = str(source_root.resolve())
    evidence_text = str(evidence_root.resolve())

    cards = f"""
      <div class="card"><span>Overall</span><strong class="{'pass-text' if overall == 'PASS' else 'fail-text'}">{overall}</strong></div>
      <div class="card"><span>Total tests</span><strong>{total}</strong></div>
      <div class="card"><span>Passed</span><strong class="pass-text">{passed}</strong></div>
      <div class="card"><span>Failed</span><strong class="fail-text">{failed}</strong></div>
      <div class="card"><span>Skipped / unknown</span><strong class="skip-text">{skipped + unknown}</strong></div>
      <div class="card"><span>Pass rate</span><strong>{pass_rate:.1f}%</strong></div>
      <div class="card"><span>Scenario time</span><strong>{esc(fmt_duration(total_ms))}</strong></div>
      <div class="card"><span>Wall time</span><strong>{esc(fmt_duration(wall_ms))}</strong></div>
      <div class="card"><span>Features</span><strong>{len(by_feature)}</strong></div>
      <div class="card"><span>Applications</span><strong>{len(app_totals)}</strong></div>
      <div class="card"><span>States</span><strong>{len([key for key in state_totals if key != '—'])}</strong></div>
      <div class="card"><span>Bindings</span><strong>{sum(1 for result in results for step in (result.get('steps',[]) or []) if isinstance(step,dict) and step.get('binding') != 'Unresolved')}</strong></div>
    """

    html_document = f"""<!doctype html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Insurance Automation Execution Report</title>
  <style>{REPORT_CSS}</style>
</head>
<body>
<div class="report-shell">
  <header class="robot-banner {overall}">
    <div class="robot-tabs" role="tablist" aria-label="Report views">
      <button type="button" class="active" data-view="report">REPORT</button>
      <button type="button" data-view="log">LOG</button>
    </div>
    <h1>Insurance Automation Execution Report</h1>
    <div class="generated"><strong>Generated</strong><br>{esc(generated_text)}</div>
    <dl class="banner-summary">
      <dt>Status:</dt><dd><strong>{esc(overall)}</strong> · {passed} passed, {failed} failed, {skipped} skipped, {unknown} unknown</dd>
      <dt>Start time:</dt><dd>{esc(start_text)}</dd>
      <dt>End time:</dt><dd>{esc(end_text)}</dd>
      <dt>Elapsed:</dt><dd>{esc(fmt_duration(wall_ms))} wall time · {esc(fmt_duration(total_ms))} accumulated scenario time</dd>
      <dt>Evidence root:</dt><dd>{esc(evidence_text)}</dd>
      <dt>Source root:</dt><dd>{esc(source_text)}</dd>
    </dl>
  </header>

  <main class="main-content">
    <section id="report-view" class="view active">
      <h2>Summary information</h2>
      <div class="cards">{cards}</div>
      <div class="overall-bar" aria-label="Pass fail distribution">
        <span class="pass" style="width:{pass_rate:.4f}%"></span>
        <span class="fail" style="width:{fail_rate:.4f}%"></span>
        <span class="skip" style="width:{skip_rate:.4f}%"></span>
      </div>
      <div class="overall-bar-legend">
        <span><i class="legend-swatch" style="background:var(--pass)"></i>Pass {passed}</span>
        <span><i class="legend-swatch" style="background:var(--fail)"></i>Fail {failed}</span>
        <span><i class="legend-swatch" style="background:var(--skip)"></i>Skip/unknown {skipped + unknown}</span>
      </div>

      <h2>Test statistics</h2>
      <div class="statistics-grid">{statistics_html}</div>

      <section id="test-details">
        <div class="section-heading"><h2>Test details</h2><span class="muted">Failed tests are expanded and shown first inside each suite.</span></div>
        <div class="toolbar" aria-label="Test filters">
          <input id="filter-search" type="search" placeholder="Search scenario, feature, state, LOB or tag…" aria-label="Search tests">
          <select id="filter-status" aria-label="Filter by status">{select_options([normalize_status(r.get('status')) for r in results], 'statuses')}</select>
          <select id="filter-feature" aria-label="Filter by feature">{select_options([str(r.get('feature') or 'Unknown feature') for r in results], 'features')}</select>
          <select id="filter-application" aria-label="Filter by application">{select_options([str(r.get('_application') or 'Unspecified') for r in results], 'applications')}</select>
          <select id="filter-state" aria-label="Filter by state">{select_options([str(r.get('_stateCode') or '—') for r in results], 'states')}</select>
          <select id="filter-lob" aria-label="Filter by LOB">{select_options([str(r.get('_lob') or '—') for r in results], 'LOBs')}</select>
          <button id="failures-only" type="button">Failures only</button>
          <button id="expand-visible" type="button">Expand visible</button>
          <button id="collapse-all" type="button">Collapse all</button>
          <button id="clear-filters" type="button">Clear</button>
          <span id="visible-count" class="visible-count"></span>
        </div>
        {report_body}
      </section>
    </section>

    <section id="log-view" class="view">
      <div class="section-heading"><h2>Test execution log</h2><span class="muted">Feature → scenario → executed ReqnRoll keyword</span></div>
      <div class="log-toolbar">
        <input id="log-search" type="search" placeholder="Search feature or scenario…" aria-label="Search log">
        <select id="log-status" aria-label="Filter log by status">{select_options([normalize_status(r.get('status')) for r in results], 'statuses')}</select>
      </div>
      {flat_log}
    </section>
  </main>
</div>

<div id="lightbox" class="lightbox" aria-hidden="true" role="dialog" aria-modal="true" aria-label="Screenshot preview">
  <div class="lightbox-inner">
    <button id="lightbox-close" class="lightbox-close" type="button" aria-label="Close screenshot">×</button>
    <img id="lightbox-image" alt="Expanded screenshot evidence">
    <div id="lightbox-caption" class="lightbox-caption"></div>
  </div>
</div>
<script>{REPORT_JS}</script>
</body>
</html>
"""
    (output_dir / "report.html").write_text(html_document, encoding="utf-8")

    # Preserve the existing standalone log.html output.  Rich Robot-style log
    # navigation is additionally embedded in report.html, but no downstream
    # consumer of log.html, summary.json or output.xml needs to change.
    log_rows: list[str] = []
    for result in sorted(results, key=lambda item: (str(item.get("feature", "")), str(item.get("scenario", "")))):
        for step in result.get("steps", []) or []:
            if not isinstance(step, dict):
                continue
            log_rows.append(
                f"<tr class='{status(step.get('status')).lower()}'><td>{esc(result.get('feature'))}</td>"
                f"<td>{esc(result.get('scenario'))}</td><td>{esc(step.get('text'))}</td>"
                f"<td>{esc(step.get('binding'))}</td><td>{status(step.get('status'))}</td>"
                f"<td>{fmt_duration(duration_ms(step))}</td><td>{esc(step.get('error',''))}</td></tr>"
            )
    log_html = (
        "<!doctype html><html><head><meta charset='utf-8'><title>Execution Log</title>"
        "<style>body{font-family:Arial;margin:20px}table{border-collapse:collapse;width:100%;font-size:12px}"
        "th,td{border:1px solid #bbb;padding:6px;vertical-align:top}th{background:#2f4050;color:white}"
        ".fail{background:#fff0ef}.pass{background:#f4fff8}</style></head><body>"
        f"<h1>Execution Log</h1><p>Generated {esc(generated)}</p>"
        "<table><thead><tr><th>Feature</th><th>Scenario</th><th>Step</th><th>Binding</th>"
        f"<th>Status</th><th>Duration</th><th>Error</th></tr></thead><tbody>{''.join(log_rows)}</tbody></table>"
        "</body></html>"
    )
    (output_dir / "log.html").write_text(log_html, encoding="utf-8")

    # Preserve the original summary.json schema and keys.
    summary = {
        "schemaVersion": "1.0",
        "generatedAtUtc": generated,
        "status": overall,
        "total": total,
        "passed": passed,
        "failed": total - passed,
        "passRate": round(pass_rate, 3),
        "durationMilliseconds": round(total_ms, 3),
        "features": {
            feature: {
                "total": len(items),
                "passed": sum(status(item.get("status")) == "PASS" for item in items),
                "failed": sum(status(item.get("status")) == "FAIL" for item in items),
            }
            for feature, items in sorted(by_feature.items())
        },
    }
    (output_dir / "summary.json").write_text(json.dumps(summary, indent=2) + "\n", encoding="utf-8")
    return summary


# ---------------------------------------------------------------------------
# Robot-compatible XML output
# ---------------------------------------------------------------------------

def write_robot_xml(results: Sequence[dict[str, Any]], output_dir: Path, generated: str) -> None:
    robot = ET.Element(
        "robot",
        {"generator": "InsuranceAutomation consolidated reporter", "generated": generated, "schemaversion": "5"},
    )
    suite = ET.SubElement(robot, "suite", {"id": "s1", "name": "Insurance Automation", "source": "ReqnRoll/NUnit"})
    for index, result in enumerate(results, 1):
        test = ET.SubElement(
            suite,
            "test",
            {"id": f"s1-t{index}", "name": str(result.get("scenario", "Unknown scenario")), "line": "0"},
        )
        ET.SubElement(test, "tag").text = str(result.get("feature", "Unknown feature"))
        for step in result.get("steps", []) or []:
            if not isinstance(step, dict):
                continue
            keyword = ET.SubElement(
                test,
                "kw",
                {"name": str(step.get("text", "")), "owner": str(step.get("binding", "Unresolved"))},
            )
            message = ET.SubElement(keyword, "msg", {"level": "INFO", "time": generated})
            message.text = str(step.get("bindingSource", "")) + ((":" + str(step.get("bindingLine"))) if step.get("bindingLine") else "")
            ET.SubElement(
                keyword,
                "status",
                {"status": status(step.get("status")), "start": generated, "elapsed": f"{duration_ms(step)/1000:.6f}"},
            )
        ET.SubElement(
            test,
            "status",
            {
                "status": status(result.get("status")),
                "start": str(result.get("startedAtUtc", generated)),
                "elapsed": f"{duration_ms(result)/1000:.6f}",
            },
        )
    statistics = ET.SubElement(robot, "statistics")
    total_node = ET.SubElement(statistics, "total")
    passed = sum(status(item.get("status")) == "PASS" for item in results)
    ET.SubElement(
        total_node,
        "stat",
        {"pass": str(passed), "fail": str(len(results) - passed), "skip": "0"},
    ).text = "All Tests"
    ET.ElementTree(robot).write(output_dir / "output.xml", encoding="utf-8", xml_declaration=True)


# ---------------------------------------------------------------------------
# CLI
# ---------------------------------------------------------------------------

def main(argv: Iterable[str] | None = None) -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--evidence-root", required=True, type=Path)
    parser.add_argument("--source-root", required=True, type=Path)
    parser.add_argument("--output-dir", required=True, type=Path)
    parser.add_argument("--fail-on-empty", action="store_true")
    parser.add_argument("--max-log-mb", type=float, default=2.0, help="Maximum execution-log text embedded per failed scenario (default: 2 MB).")
    parser.add_argument("--max-image-mb", type=float, default=12.0, help="Maximum size of each base64-embedded image (default: 12 MB).")
    parser.add_argument("--max-images-per-scenario", type=int, default=20, help="Maximum embedded screenshots per scenario (default: 20).")
    args = parser.parse_args(argv)

    if not args.evidence_root.exists():
        parser.error(f"Evidence root does not exist: {args.evidence_root}")
    if not args.source_root.exists():
        parser.error(f"Source root does not exist: {args.source_root}")
    if args.max_log_mb <= 0 or args.max_image_mb <= 0 or args.max_images_per_scenario <= 0:
        parser.error("Embed limits must be greater than zero.")

    generated = dt.datetime.now(dt.timezone.utc).isoformat()
    results = load_results(args.evidence_root)
    bindings = discover_bindings(args.source_root)
    enrich(results, bindings)
    limits = ReportLimits(
        max_log_bytes=int(args.max_log_mb * 1024 * 1024),
        max_image_bytes=int(args.max_image_mb * 1024 * 1024),
        max_images_per_scenario=args.max_images_per_scenario,
    )
    summary = write_report(
        results,
        args.output_dir,
        generated,
        args.evidence_root,
        args.source_root,
        limits,
    )
    write_robot_xml(results, args.output_dir, generated)
    print(
        json.dumps(
            {
                **summary,
                "bindingsDiscovered": len(bindings),
                "outputDirectory": str(args.output_dir),
            },
            indent=2,
        )
    )
    return 2 if args.fail_on_empty and not results else 0


if __name__ == "__main__":
    raise SystemExit(main())
