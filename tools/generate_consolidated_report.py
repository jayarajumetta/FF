#!/usr/bin/env python3
"""Generate a Robot Framework-inspired consolidated report from scenario-result.json evidence.

The C# ScenarioReport writes one scenario-result.json after each ReqnRoll scenario. This tool
combines every result found below one evidence root, resolves each Gherkin step to its scoped
C# ReqnRoll binding where possible, and writes report.html, log.html, output.xml and summary.json.
"""
from __future__ import annotations

import argparse
import datetime as dt
import html
import json
import re
import sys
import xml.etree.ElementTree as ET
from collections import defaultdict
from dataclasses import dataclass
from pathlib import Path
from typing import Any, Iterable


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


def _decode_csharp_string(prefix: str, value: str) -> str:
    if prefix == '@':
        return value.replace('""', '"')
    try:
        return bytes(value, "utf-8").decode("unicode_escape")
    except UnicodeDecodeError:
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
    class_re = re.compile(r'\bclass\s+(\w+)')
    scope_re = re.compile(r'Scope\s*\(\s*Feature\s*=\s*"([^"]+)"')
    method_re = re.compile(r'^\s*public\s+(?:async\s+)?(?:Task(?:<[^>]+>)?|void|[\w?.<>]+)\s+(\w+)\s*\(')

    for path in sorted(source_root.glob("tests/*/StepDefinitions/*.cs")):
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
                for pattern, attr_line in pending:
                    bindings.append(Binding(
                        feature=feature_scope,
                        pattern=pattern,
                        class_name=class_name,
                        method_name=method.group(1),
                        source_file=str(path.relative_to(source_root)).replace("\\", "/"),
                        line=attr_line,
                        regex=_compile_binding(pattern),
                    ))
                pending.clear()
            elif line.strip() and not line.lstrip().startswith("[") and not line.lstrip().startswith("//"):
                # A non-attribute declaration before a method means the pending block is unrelated.
                if pending and not line.strip().startswith(("[", "#")):
                    pending.clear()
    return bindings


def resolve_binding(bindings: list[Binding], feature: str, step: str) -> tuple[str, str, int, str]:
    candidates = [b for b in bindings if (not b.feature or b.feature.casefold() == feature.casefold()) and b.regex and b.regex.fullmatch(step)]
    if not candidates:
        return "Unresolved", "", 0, "No scoped ReqnRoll binding matched this executed step."
    scoped = [b for b in candidates if b.feature]
    chosen = (scoped or candidates)[0]
    note = "" if len(candidates) == 1 else f"Resolved from {len(candidates)} candidates using feature scope."
    return chosen.display, chosen.source_file, chosen.line, note


def load_results(evidence_root: Path) -> list[dict[str, Any]]:
    results: list[dict[str, Any]] = []
    for path in sorted(evidence_root.rglob("scenario-result.json")):
        try:
            item = json.loads(path.read_text(encoding="utf-8"))
            item["_resultFile"] = str(path)
            item["_artifactDir"] = str(path.parent)
            results.append(item)
        except (OSError, json.JSONDecodeError) as exc:
            results.append({
                "feature": "Report ingestion",
                "scenario": path.name,
                "status": "FAIL",
                "durationMilliseconds": 0,
                "steps": [{"order": 1, "text": "Read scenario-result.json", "status": "FAIL", "durationMilliseconds": 0, "error": str(exc)}],
                "_resultFile": str(path),
                "_artifactDir": str(path.parent),
            })
    return results


def enrich(results: list[dict[str, Any]], bindings: list[Binding]) -> None:
    for result in results:
        feature = str(result.get("feature", "Unknown feature"))
        for step in result.get("steps", []) or []:
            text = str(step.get("text", ""))
            display, source, line, note = resolve_binding(bindings, feature, text)
            step["binding"] = display
            step["bindingSource"] = source
            step["bindingLine"] = line
            step["bindingResolution"] = note


def status(value: Any) -> str:
    return "PASS" if str(value).upper() in {"PASS", "PASSED", "SUCCESS", "SUCCEEDED"} else "FAIL"


def duration_ms(item: dict[str, Any]) -> float:
    try:
        return float(item.get("durationMilliseconds", 0) or 0)
    except (TypeError, ValueError):
        return 0.0


def fmt_duration(ms: float) -> str:
    if ms < 1000:
        return f"{ms:.0f} ms"
    if ms < 60000:
        return f"{ms/1000:.2f} s"
    return f"{ms/60000:.2f} min"


def esc(value: Any) -> str:
    return html.escape(str(value if value is not None else ""))


def artifact_link(result: dict[str, Any], key: str, label: str, output_dir: Path) -> str:
    value = (result.get("artifacts") or {}).get(key, "")
    if not value:
        return ""
    target = Path(result.get("_artifactDir", "")) / value
    try:
        rel = target.resolve().relative_to(output_dir.resolve())
        href = str(rel).replace("\\", "/")
    except ValueError:
        href = target.resolve().as_uri() if target.exists() else str(target).replace("\\", "/")
    return f'<a href="{esc(href)}">{esc(label)}</a>'


def write_report(results: list[dict[str, Any]], output_dir: Path, generated: str) -> dict[str, Any]:
    output_dir.mkdir(parents=True, exist_ok=True)
    total = len(results)
    passed = sum(status(r.get("status")) == "PASS" for r in results)
    failed = total - passed
    total_ms = sum(duration_ms(r) for r in results)
    overall = "PASS" if total > 0 and failed == 0 else "FAIL"
    by_feature: dict[str, list[dict[str, Any]]] = defaultdict(list)
    for result in results:
        by_feature[str(result.get("feature", "Unknown feature"))].append(result)

    feature_rows = []
    detail_blocks = []
    for feature, scenarios in sorted(by_feature.items()):
        fp = sum(status(x.get("status")) == "PASS" for x in scenarios)
        ff = len(scenarios) - fp
        feature_rows.append(f"<tr><td>{esc(feature)}</td><td>{len(scenarios)}</td><td class='pass-text'>{fp}</td><td class='fail-text'>{ff}</td><td>{fmt_duration(sum(duration_ms(x) for x in scenarios))}</td></tr>")
        scenario_html = []
        for result in sorted(scenarios, key=lambda x: (status(x.get("status")) != "FAIL", str(x.get("scenario", "")))):
            st = status(result.get("status"))
            links = " &nbsp; ".join(x for x in [
                artifact_link(result, "report", "individual report", output_dir),
                artifact_link(result, "log", "execution log", output_dir),
                artifact_link(result, "trace", "trace", output_dir),
                artifact_link(result, "video", "video", output_dir),
                artifact_link(result, "har", "HAR", output_dir),
                artifact_link(result, "evidenceBundle", "bundle", output_dir),
            ] if x)
            step_rows = []
            for step in result.get("steps", []) or []:
                ss = status(step.get("status"))
                binding = esc(step.get("binding", "Unresolved"))
                source = step.get("bindingSource", "")
                line = step.get("bindingLine", 0)
                source_html = f"<div class='source'>{esc(source)}:{line}</div>" if source else ""
                evidence = ""
                screenshot = step.get("screenshot", "")
                if screenshot:
                    target = Path(result.get("_artifactDir", "")) / str(screenshot)
                    evidence = f'<a href="{esc(str(target).replace(chr(92), "/"))}">screenshot</a>'
                error = "<br>".join(esc(x) for x in [step.get("error", ""), step.get("consoleErrors", ""), step.get("networkErrors", "")] if x)
                step_rows.append(
                    f"<tr class='{ss.lower()}'><td>{step.get('order','')}</td><td>{esc(step.get('text',''))}</td>"
                    f"<td><strong>{binding}</strong>{source_html}</td><td>{ss}</td><td>{fmt_duration(duration_ms(step))}</td><td>{error}</td><td>{evidence}</td></tr>"
                )
            scenario_html.append(f"""
            <details class='scenario {st.lower()}' {'open' if st == 'FAIL' else ''}>
              <summary><span class='badge {st.lower()}'>{st}</span> {esc(result.get('scenario','Unknown scenario'))} <span class='duration'>{fmt_duration(duration_ms(result))}</span></summary>
              <div class='scenario-meta'>{links or 'No finalized artifact links recorded.'}</div>
              <table><thead><tr><th>#</th><th>Gherkin step</th><th>C# step definition</th><th>Status</th><th>Duration</th><th>Error / browser evidence</th><th>Evidence</th></tr></thead><tbody>{''.join(step_rows)}</tbody></table>
            </details>""")
        detail_blocks.append(f"<section><h2>{esc(feature)}</h2>{''.join(scenario_html)}</section>")

    if not results:
        detail_blocks.append("<section><h2>No scenario results found</h2><p>The report generator completed, but no scenario-result.json files existed below the supplied evidence root.</p></section>")

    pct = (passed / total * 100) if total else 0
    document = f"""<!doctype html>
<html><head><meta charset='utf-8'><title>Consolidated Test Report</title>
<style>
:root{{--pass:#00a65a;--fail:#d73925;--ink:#222;--muted:#667;--line:#d6d9df;--head:#2f4050;--panel:#f5f7fa}}
*{{box-sizing:border-box}}body{{font-family:Arial,Helvetica,sans-serif;margin:0;color:var(--ink);background:white;font-size:13px}}
header{{background:var(--head);color:white;padding:20px 28px;border-bottom:6px solid {'var(--pass)' if overall=='PASS' else 'var(--fail)'}}}
header h1{{margin:0 0 5px;font-size:26px}}header .sub{{color:#dbe3ec}}
main{{padding:22px 28px}}.cards{{display:flex;gap:12px;flex-wrap:wrap;margin-bottom:20px}}.card{{min-width:150px;border:1px solid var(--line);padding:14px;background:var(--panel)}}.card strong{{display:block;font-size:25px}}.overall-pass{{color:var(--pass)}}.overall-fail{{color:var(--fail)}}
table{{width:100%;border-collapse:collapse;margin:8px 0 18px}}th{{background:#e7eaee;text-align:left}}th,td{{border:1px solid var(--line);padding:7px;vertical-align:top}}tr.fail{{background:#fff0ef}}tr.pass{{background:#f4fff8}}.pass-text{{color:var(--pass);font-weight:bold}}.fail-text{{color:var(--fail);font-weight:bold}}
details.scenario{{border:1px solid var(--line);margin:8px 0 14px}}details.scenario summary{{cursor:pointer;padding:10px;background:#f3f5f7;font-weight:bold}}details.fail summary{{border-left:6px solid var(--fail)}}details.pass summary{{border-left:6px solid var(--pass)}}.badge{{display:inline-block;padding:2px 7px;color:#fff;font-size:11px;margin-right:6px}}.badge.pass{{background:var(--pass)}}.badge.fail{{background:var(--fail)}}.duration{{float:right;color:var(--muted);font-weight:normal}}.scenario-meta{{padding:8px 12px;color:var(--muted)}}.source{{font-size:10px;color:var(--muted);margin-top:3px;word-break:break-all}}h2{{border-bottom:1px solid var(--line);padding-bottom:5px;margin-top:26px}}a{{color:#1f5f99}}
</style></head><body>
<header><h1>TEST EXECUTION REPORT</h1><div class='sub'>Robot Framework-inspired consolidated ReqnRoll / NUnit report &middot; Generated {esc(generated)}</div></header>
<main><div class='cards'>
<div class='card'><span>Overall</span><strong class='overall-{overall.lower()}'>{overall}</strong></div>
<div class='card'><span>Total tests</span><strong>{total}</strong></div>
<div class='card'><span>Passed</span><strong class='overall-pass'>{passed}</strong></div>
<div class='card'><span>Failed</span><strong class='overall-fail'>{failed}</strong></div>
<div class='card'><span>Pass rate</span><strong>{pct:.1f}%</strong></div>
<div class='card'><span>Duration</span><strong>{fmt_duration(total_ms)}</strong></div>
</div>
<h2>Feature summary</h2><table><thead><tr><th>Feature</th><th>Total</th><th>Passed</th><th>Failed</th><th>Duration</th></tr></thead><tbody>{''.join(feature_rows)}</tbody></table>
{''.join(detail_blocks)}</main></body></html>"""
    (output_dir / "report.html").write_text(document, encoding="utf-8")

    log_rows = []
    for result in sorted(results, key=lambda x: (str(x.get("feature", "")), str(x.get("scenario", "")))):
        for step in result.get("steps", []) or []:
            log_rows.append(f"<tr class='{status(step.get('status')).lower()}'><td>{esc(result.get('feature'))}</td><td>{esc(result.get('scenario'))}</td><td>{esc(step.get('text'))}</td><td>{esc(step.get('binding'))}</td><td>{status(step.get('status'))}</td><td>{fmt_duration(duration_ms(step))}</td><td>{esc(step.get('error',''))}</td></tr>")
    log_html = f"<!doctype html><html><head><meta charset='utf-8'><title>Execution Log</title><style>body{{font-family:Arial;margin:20px}}table{{border-collapse:collapse;width:100%;font-size:12px}}th,td{{border:1px solid #bbb;padding:6px;vertical-align:top}}th{{background:#2f4050;color:white}}.fail{{background:#fff0ef}}.pass{{background:#f4fff8}}</style></head><body><h1>Execution Log</h1><p>Generated {esc(generated)}</p><table><thead><tr><th>Feature</th><th>Scenario</th><th>Step</th><th>Binding</th><th>Status</th><th>Duration</th><th>Error</th></tr></thead><tbody>{''.join(log_rows)}</tbody></table></body></html>"
    (output_dir / "log.html").write_text(log_html, encoding="utf-8")

    summary = {
        "schemaVersion": "1.0",
        "generatedAtUtc": generated,
        "status": overall,
        "total": total,
        "passed": passed,
        "failed": failed,
        "passRate": round(pct, 3),
        "durationMilliseconds": round(total_ms, 3),
        "features": {feature: {"total": len(items), "passed": sum(status(x.get("status")) == "PASS" for x in items), "failed": sum(status(x.get("status")) == "FAIL" for x in items)} for feature, items in sorted(by_feature.items())},
    }
    (output_dir / "summary.json").write_text(json.dumps(summary, indent=2) + "\n", encoding="utf-8")
    return summary


def write_robot_xml(results: list[dict[str, Any]], output_dir: Path, generated: str) -> None:
    robot = ET.Element("robot", {"generator": "InsuranceAutomation consolidated reporter", "generated": generated, "schemaversion": "5"})
    suite = ET.SubElement(robot, "suite", {"id": "s1", "name": "Insurance Automation", "source": "ReqnRoll/NUnit"})
    for index, result in enumerate(results, 1):
        test = ET.SubElement(suite, "test", {"id": f"s1-t{index}", "name": str(result.get("scenario", "Unknown scenario")), "line": "0"})
        ET.SubElement(test, "tag").text = str(result.get("feature", "Unknown feature"))
        for step in result.get("steps", []) or []:
            kw = ET.SubElement(test, "kw", {"name": str(step.get("text", "")), "owner": str(step.get("binding", "Unresolved"))})
            msg = ET.SubElement(kw, "msg", {"level": "INFO", "time": generated})
            msg.text = str(step.get("bindingSource", "")) + ((":" + str(step.get("bindingLine"))) if step.get("bindingLine") else "")
            ET.SubElement(kw, "status", {"status": status(step.get("status")), "start": generated, "elapsed": f"{duration_ms(step)/1000:.6f}"})
        ET.SubElement(test, "status", {"status": status(result.get("status")), "start": str(result.get("startedAtUtc", generated)), "elapsed": f"{duration_ms(result)/1000:.6f}"})
    stats = ET.SubElement(robot, "statistics")
    total = ET.SubElement(stats, "total")
    passed = sum(status(x.get("status")) == "PASS" for x in results)
    ET.SubElement(total, "stat", {"pass": str(passed), "fail": str(len(results) - passed), "skip": "0"}).text = "All Tests"
    ET.ElementTree(robot).write(output_dir / "output.xml", encoding="utf-8", xml_declaration=True)


def main(argv: Iterable[str] | None = None) -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--evidence-root", required=True, type=Path)
    parser.add_argument("--source-root", required=True, type=Path)
    parser.add_argument("--output-dir", required=True, type=Path)
    parser.add_argument("--fail-on-empty", action="store_true")
    args = parser.parse_args(argv)
    generated = dt.datetime.now(dt.timezone.utc).isoformat()
    results = load_results(args.evidence_root)
    bindings = discover_bindings(args.source_root)
    enrich(results, bindings)
    summary = write_report(results, args.output_dir, generated)
    write_robot_xml(results, args.output_dir, generated)
    print(json.dumps({**summary, "bindingsDiscovered": len(bindings), "outputDirectory": str(args.output_dir)}, indent=2))
    return 2 if args.fail_on_empty and not results else 0


if __name__ == "__main__":
    raise SystemExit(main())
