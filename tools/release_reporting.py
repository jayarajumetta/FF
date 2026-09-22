"""Transport release evidence between agents using release task attachments (stdlib only)."""
from __future__ import annotations

import argparse
import hashlib
import json
import os
from pathlib import Path
import re
import shutil
import sys
import tempfile
import time
import urllib.error
import urllib.parse
import urllib.request
import zipfile
from generate_consolidated_report import exclude_video, video_policy, normalize_status, redact_sensitive_text

MANIFEST_TYPE = "InsuranceAutomation.EvidenceManifest"
CHUNK_TYPE = "InsuranceAutomation.EvidenceChunk"
CHUNK_BYTES = 64 * 1024 * 1024
RESULT_DIRECTORIES = ("Artifacts", "Runner", "NUnit", "NUnitWork")
VIDEO_SUFFIXES = {".webm", ".mp4", ".m4v", ".mov", ".avi", ".mkv", ".wmv", ".mpeg", ".mpg", ".ogv"}
REPORT_LOG_BYTES = 64 * 1024
RESULT_FIELDS = "schemaVersion executionId testFullName attemptNumber maxAttempts feature scenario status startedAtUtc completedAtUtc durationMilliseconds tags application app project stateCode state_code state StateCode State lob data stepDataScope".split()
STEP_FIELDS = "order text status durationMilliseconds data error consoleErrors networkErrors binding bindingSource bindingLine bindingCaptured bindingResolution actions".split()
VERIFICATION_FIELDS = "businessStep page control property expected error".split()


def report_record(path: Path) -> dict:
    result = json.loads(path.read_text(encoding="utf-8-sig"))
    if not isinstance(result, dict):
        raise ValueError(f"Scenario result must be an object: {path}")
    record = {key: result[key] for key in RESULT_FIELDS if key in result}
    for field, keys in (("steps", STEP_FIELDS), ("deferredVerifications", VERIFICATION_FIELDS)):
        record[field] = [{key: item[key] for key in keys if key in item} for item in result.get(field, []) or []]
    if normalize_status(result.get("status")) == "FAIL":
        log_name = (result.get("artifacts") or {}).get("log") or "execution.log"
        log = path.parent / log_name
        if not log.resolve().is_relative_to(path.parent.resolve()) or log.is_symlink():
            raise ValueError(f"Execution log must stay within the scenario directory: {path}")
        if log.is_file():
            size = log.stat().st_size
            with log.open("rb") as stream:
                raw = stream.read(REPORT_LOG_BYTES)
                if size > REPORT_LOG_BYTES:
                    head = REPORT_LOG_BYTES // 3
                    stream.seek(-(REPORT_LOG_BYTES - head), os.SEEK_END)
                    raw = raw[:head] + b"\n... LOG MIDDLE OMITTED ...\n" + stream.read(REPORT_LOG_BYTES - head)
            record["executionLog"] = {"text": redact_sensitive_text(raw.decode("utf-8-sig", errors="replace")),
                                      "originalBytes": size, "truncated": size > REPORT_LOG_BYTES}
    return record


def evidence_outcomes(root: Path) -> tuple[dict, dict]:
    directories, videos = {}, {}
    for path in root.rglob("scenario-result.json"):
        result = json.loads(path.read_text(encoding="utf-8-sig"))
        status = str(result.get("status", ""))
        directories[path.parent] = status
        for video in path.parent.rglob("*"):
            if video.suffix.lower() in VIDEO_SUFFIXES:
                videos.setdefault(video.name, set()).add(status)
    return directories, videos


def write_filtered_file(archive, path, name, policy, outcome, video_outcomes, depth=0):
    if path.suffix.lower() in VIDEO_SUFFIXES:
        outcomes = {outcome} if outcome else video_outcomes.get(path.name, {""})
        if all(exclude_video(policy, status) for status in outcomes):
            return
    if path.suffix.lower() == ".zip" and any(policy) and zipfile.is_zipfile(path):
        if depth >= 8:
            raise ValueError("Evidence ZIP nesting exceeds supported depth")
        with tempfile.TemporaryDirectory(prefix="video-filter-") as temporary:
            filtered = Path(temporary) / "filtered.zip"
            with zipfile.ZipFile(path) as source, zipfile.ZipFile(filtered, "w", zipfile.ZIP_DEFLATED) as target:
                statuses = {}
                for entry in source.infolist():
                    if entry.filename.endswith("scenario-result.json"):
                        result = json.loads(source.read(entry).decode("utf-8-sig"))
                        statuses[Path(entry.filename).parent] = str(result.get("status", ""))
                for index, entry in enumerate(source.infolist()):
                    if entry.is_dir():
                        continue
                    relative = Path(entry.filename)
                    status = next((statuses[parent] for parent in relative.parents if parent in statuses), outcome)
                    member = Path(temporary) / f"member-{index}" / relative.name
                    member.parent.mkdir()
                    with source.open(entry) as stream, member.open("wb") as output:
                        shutil.copyfileobj(stream, output)
                    write_filtered_file(target, member, entry.filename, policy, status, video_outcomes, depth + 1)
                    member.unlink()
            archive.write(filtered, name)
    else:
        archive.write(path, name)


def required(name: str) -> str:
    value = os.environ.get(name, "").strip()
    if not value or "$(" in value:
        raise ValueError(f"Required pipeline variable is missing: {name}")
    return value


def scope() -> dict:
    if os.environ.get("EVIDENCE_TRANSPORT") == "pipeline":
        return {"buildId": required("BUILD_BUILDID"), "stageKey": required("STAGEKEY"),
                "stageAttempt": required("SYSTEM_STAGEATTEMPT")}
    return {key: required(env) for key, env in (
        ("releaseId", "RELEASE_RELEASEID"),
        ("environmentId", "RELEASE_ENVIRONMENTID"),
        ("deploymentId", "RELEASE_DEPLOYMENTID"),
    )}


def digest(path: Path) -> str:
    result = hashlib.sha256()
    with path.open("rb") as stream:
        for block in iter(lambda: stream.read(1024 * 1024), b""):
            result.update(block)
    return result.hexdigest()


def command_escape(value: str) -> str:
    return value.replace("%", "%AZP25").replace("\r", "%0D").replace("\n", "%0A").replace(";", "%3B").replace("]", "%5D")


def attach(path: Path, kind: str, name: str | None = None) -> None:
    if not path.is_file():
        raise FileNotFoundError(path)
    print(f"Publishing {path.name} ({path.stat().st_size} bytes)", flush=True)
    if kind == "file":
        print(f"##vso[task.uploadfile]{command_escape(str(path.resolve()))}", flush=True)
    else:
        print(f"##vso[task.addattachment type={kind};name={command_escape(name or path.name)};]{command_escape(str(path.resolve()))}", flush=True)


def pack(results: Path, output: Path, identity: dict, position: int, total: int, chunk_bytes: int = CHUNK_BYTES,
         policy: tuple[bool, bool] | None = None) -> Path:
    if not 1 <= position <= total:
        raise ValueError("Invalid System.JobPositionInPhase / System.TotalJobsInPhase")
    if chunk_bytes < 1:
        raise ValueError("Chunk size must be positive")
    if not results.is_dir():
        raise FileNotFoundError(f"Test results directory not found: {results}")
    output.mkdir(parents=True, exist_ok=False)
    archive = output / f"agent-{position}.zip"
    count = 0
    with zipfile.ZipFile(archive, "w", zipfile.ZIP_DEFLATED, allowZip64=True) as zipped:
        evidence = results / "Artifacts"
        if evidence.is_symlink() or not evidence.resolve().is_relative_to(results.resolve()):
            raise ValueError(f"Evidence links outside the source are not supported: {evidence}")
        for path in sorted(evidence.rglob("scenario-result.json")):
            if path.is_symlink() or not path.resolve().is_relative_to(evidence.resolve()):
                raise ValueError(f"Evidence links outside the source are not supported: {path}")
            zipped.writestr(path.relative_to(results).as_posix(), json.dumps(report_record(path), ensure_ascii=False))
            count += 1
    parts = []
    with archive.open("rb") as source:
        index = 0
        while block := source.read(chunk_bytes):
            name = f"agent-{position}-{index:05d}.part"
            part = output / name
            part.write_bytes(block)
            parts.append({"name": name, "bytes": len(block), "sha256": digest(part)})
            index += 1
    manifest = {
        "schemaVersion": 2, **identity, "position": position, "totalJobs": total,
        "scenarioCount": count, "archiveSha256": digest(archive), "parts": parts,
    }
    path = output / f"agent-{position}.json"
    path.write_text(json.dumps(manifest, indent=2), encoding="utf-8")
    return path


def publish() -> None:
    results = Path(required("TEST_RESULTS_ROOT")).resolve()
    output = Path(tempfile.mkdtemp(prefix="release-evidence-", dir=required("AGENT_TEMPDIRECTORY"))) / "handoff"
    manifest_path = pack(results, output, scope(), int(required("SYSTEM_JOBPOSITIONINPHASE")), int(required("SYSTEM_TOTALJOBSINPHASE")))
    manifest = json.loads(manifest_path.read_text(encoding="utf-8"))
    print(f"Evidence root: {results / 'Artifacts'}; shard {manifest['position']}/{manifest['totalJobs']}; scenarios/attempts: {manifest['scenarioCount']}", flush=True)
    (output / f"agent-{manifest['position']}.zip").unlink()
    if os.environ.get("EVIDENCE_TRANSPORT") == "pipeline":
        print(f"##vso[task.setvariable variable=EVIDENCE_HANDOFF]{command_escape(str(output))}", flush=True)
        return
    for part in manifest["parts"]:
        attach(output / part["name"], CHUNK_TYPE)
    attach(manifest_path, MANIFEST_TYPE)


class NoRedirect(urllib.request.HTTPRedirectHandler):
    def redirect_request(self, req, fp, code, msg, headers, newurl):
        raise ValueError("Unexpected redirect from Azure DevOps; check the collection URL")


class ReleaseApi:
    def __init__(self, collection: str, project: str, token: str):
        url = urllib.parse.urlsplit(collection)
        if url.scheme != "https":
            raise ValueError("Release API requires an HTTPS collection URL")
        host = url.netloc
        if host == "dev.azure.com":
            host = "vsrm.dev.azure.com"
        elif host.endswith(".visualstudio.com") and not host.endswith(".vsrm.visualstudio.com"):
            host = host.removesuffix(".visualstudio.com") + ".vsrm.visualstudio.com"
        self.root = urllib.parse.urlunsplit((url.scheme, host, url.path.rstrip("/") + "/" + urllib.parse.quote(project, safe="") + "/_apis/release/", "", ""))
        self.token = token
        self.opener = urllib.request.build_opener(NoRedirect())

    def get(self, route: str, output: Path | None = None):
        request = urllib.request.Request(self.root + route, headers={"Authorization": "Bearer " + self.token})
        for attempt in range(4):
            try:
                with self.opener.open(request, timeout=120) as response:
                    continuation = response.headers.get("x-ms-continuationtoken")
                    if output is not None:
                        with output.open("wb") as stream:
                            shutil.copyfileobj(response, stream)
                        return None, continuation
                    return json.load(response), continuation
            except urllib.error.HTTPError as error:
                if error.code not in (429, 500, 502, 503, 504) or attempt == 3:
                    raise RuntimeError(f"Release API HTTP {error.code}; verify OAuth access and View releases permission") from None
                time.sleep(2 ** attempt)

    def attachments(self, prefix: str, plan: str, kind: str) -> list[dict]:
        route = prefix + f"/plan/{urllib.parse.quote(plan, safe='')}/attachments/{kind}?api-version=7.1"
        result = []
        token = None
        while True:
            page, token = self.get(route + ("&continuationToken=" + urllib.parse.quote(token, safe="") if token else ""))
            result.extend(page["value"])
            if not token:
                return result

    def download(self, prefix: str, item: dict, output: Path) -> None:
        fields = {key: urllib.parse.quote(str(item[key]), safe="") for key in ("timelineId", "recordId", "type", "name")}
        route = prefix + "/timelines/{timelineId}/records/{recordId}/attachments/{type}/{name}?api-version=4.1-preview.1".format(**fields)
        self.get(route, output)


def execution_scope(release: dict, identity: dict) -> tuple[str, str]:
    environment = next((e for e in release["environments"] if str(e["id"]) == identity["environmentId"]), None)
    if not environment:
        raise ValueError("Current environment not found in release metadata")
    deployment = next((d for d in environment.get("deploySteps", []) if str(d["deploymentId"]) == identity["deploymentId"]), None)
    if not deployment:
        raise ValueError("Current deployment attempt not found; refusing to use evidence from an older deployment")
    phases = [p for p in deployment.get("releaseDeployPhases", []) if p["name"] == "Run automation on Windows agent"]
    if len(phases) != 1 or not phases[0].get("runPlanId"):
        raise ValueError("Execution phase runPlanId not found in release metadata")
    return str(deployment["attempt"]), str(phases[0]["runPlanId"])


def validate_manifests(manifests: list[dict], identity: dict) -> int:
    if not manifests:
        raise ValueError("No agent manifests were uploaded; no consolidated report can be produced")
    total = manifests[0]["totalJobs"]
    if type(total) is not int or total < 1:
        raise ValueError("Invalid total job count")
    positions = []
    for manifest in manifests:
        if manifest.get("schemaVersion") != 2 or any(manifest.get(k) != v for k, v in identity.items()):
            raise ValueError("Evidence belongs to a different release/environment/deployment or schema")
        if manifest["totalJobs"] != total or type(manifest["position"]) is not int:
            raise ValueError("Inconsistent shard identity")
        positions.append(manifest["position"])
    if sorted(positions) != list(range(1, total + 1)):
        raise ValueError(f"Incomplete or duplicate agent evidence: expected positions 1..{total}, received {sorted(positions)}")
    return total


def unpack(manifest: dict, parts: Path, target: Path) -> None:
    archive = parts / f"agent-{manifest['position']}.zip"
    if not manifest["parts"]:
        raise ValueError("Archive has no chunks")
    with archive.open("wb") as combined:
        for index, info in enumerate(manifest["parts"]):
            expected = f"agent-{manifest['position']}-{index:05d}.part"
            if info["name"] != expected:
                raise ValueError("Unexpected chunk name/order")
            path = parts / expected
            if path.stat().st_size != info["bytes"] or digest(path) != info["sha256"]:
                raise ValueError(f"Evidence chunk checksum/size mismatch: {expected}")
            with path.open("rb") as source:
                shutil.copyfileobj(source, combined)
    if digest(archive) != manifest["archiveSha256"]:
        raise ValueError("Combined evidence archive checksum mismatch")
    target.mkdir(parents=True, exist_ok=False)
    with zipfile.ZipFile(archive) as zipped:
        seen = set()
        for item in zipped.infolist():
            relative = Path(item.filename)
            destination = (target / relative).resolve()
            if (not item.filename.startswith("Artifacts/") or relative.name != "scenario-result.json" or "\\" in item.filename or ":" in item.filename
                    or ".." in relative.parts or not destination.is_relative_to(target.resolve())
                    or (item.external_attr >> 16) & 0o170000 == 0o120000
                    or item.filename.casefold() in seen):
                raise ValueError(f"Unsafe/duplicate evidence archive member: {item.filename}")
            seen.add(item.filename.casefold())
            zipped.extract(item, target)
    count = sum(1 for _ in (target / "Artifacts").rglob("scenario-result.json"))
    if count != manifest["scenarioCount"]:
        raise ValueError("Extracted scenario count does not match agent manifest")


def archive_bundle(bundle: Path, archive: Path) -> Path:
    policy = video_policy(Path(__file__).resolve().parent.parent)
    directories, videos = evidence_outcomes(bundle)
    with zipfile.ZipFile(archive, "w", zipfile.ZIP_DEFLATED, allowZip64=True) as zipped:
        for path in sorted(bundle.rglob("*")):
            if path.is_file():
                outcome = next((directories[parent] for parent in path.parents if parent in directories), "")
                write_filtered_file(zipped, path, path.relative_to(bundle).as_posix(), policy, outcome, videos)
    return archive


def collect_pipeline() -> None:
    incoming = Path(required("EVIDENCE_DOWNLOAD_ROOT"))
    output = Path(required("REPORT_OUTPUT_ROOT"))
    output.mkdir(parents=True, exist_ok=True)
    work = Path(tempfile.mkdtemp(prefix="pipeline-report-", dir=required("AGENT_TEMPDIRECTORY")))
    bundle = work / "bundle"
    evidence = bundle / "Artifacts"
    expected = json.loads(required("EXPECTED_EVIDENCE"))
    if not isinstance(expected, dict) or not expected or any(
        stage not in ("Assembly", "Suite", "SingleCase") or type(total) is not int or total < 1
        for stage, total in expected.items()
    ):
        raise ValueError("Expected evidence must specify selected modes with positive shard counts")
    all_manifests = []
    attempt = required("SYSTEM_STAGEATTEMPT")
    for stage, total in expected.items():
        manifests = []
        for position in range(1, total + 1):
            parts = incoming / f"evidence-{stage}-{position}-{attempt}"
            path = parts / f"agent-{position}.json"
            if not path.is_file():
                raise ValueError(f"Missing agent evidence: {stage} shard {position}/{total}")
            manifest = json.loads(path.read_text(encoding="utf-8"))
            if manifest["position"] != position or manifest["totalJobs"] != total:
                raise ValueError(f"Unexpected shard identity: {stage} shard {position}/{total}")
            manifests.append(manifest)
        identity = {"buildId": required("BUILD_BUILDID"), "stageKey": stage,
                    "stageAttempt": required("SYSTEM_STAGEATTEMPT")}
        validate_manifests(manifests, identity)
        for manifest in manifests:
            position = manifest["position"]
            unpack(manifest, incoming / f"evidence-{stage}-{position}-{attempt}", evidence / stage / f"agent-{position}")
        all_manifests.extend(manifests)
    actual = {p.name for p in incoming.iterdir() if p.is_dir()}
    expected_names = {f"evidence-{stage}-{p}-{attempt}" for stage, total in expected.items() for p in range(1, total + 1)}
    if actual != expected_names:
        raise ValueError("Unexpected or missing evidence artifacts; refusing an ambiguous report")
    (bundle / "collection-manifest.json").write_text(json.dumps(all_manifests, indent=2), encoding="utf-8")
    report = generate(evidence, bundle, Path(__file__).resolve().parent.parent)
    shutil.copyfile(report, output / "report.html")
    print(f"Verified {len(all_manifests)} shards; standalone report: {output / 'report.html'}", flush=True)


def generate(evidence: Path, bundle: Path, source: Path) -> Path:
    import generate_consolidated_report as generator

    report = bundle / "ConsolidatedReport"
    scenario_roots = sorted(root for pattern in ("agent-*/Artifacts", "*/agent-*/Artifacts")
                            for root in evidence.glob(pattern) if root.is_dir())
    if not scenario_roots:
        raise ValueError("No completed scenario evidence found; no canonical agent Artifacts directories")
    arguments = ["--evidence-root", str(evidence), "--source-root", str(source), "--output-dir", str(report), "--fail-on-empty", "--summary-only"]
    for root in scenario_roots:
        arguments.extend(["--scenario-root", str(root)])
    print(f"Generating standalone report from {len(scenario_roots)} canonical scenario directories; media and runner attachments are excluded.", flush=True)
    if generator.main(arguments) != 0:
        raise ValueError("No completed scenario evidence found; consolidated report generation failed")
    if not (report / "report.html").is_file():
        raise FileNotFoundError("Expected report output missing: report.html")
    return report / "report.html"


def collect() -> None:
    identity = scope()
    api = ReleaseApi(required("SYSTEM_COLLECTIONURI"), required("SYSTEM_TEAMPROJECTID"), required("SYSTEM_ACCESSTOKEN"))
    release_route = f"releases/{identity['releaseId']}"
    release, _ = api.get(release_route + "?api-version=7.1")
    attempt, plan = execution_scope(release, identity)
    prefix = release_route + f"/environments/{identity['environmentId']}/attempts/{attempt}"
    work = Path(tempfile.mkdtemp(prefix="release-report-", dir=required("AGENT_TEMPDIRECTORY")))
    downloads = work / "downloads"
    downloads.mkdir()
    manifests = []
    for retry in range(6):
        manifests = []
        for item in api.attachments(prefix, plan, MANIFEST_TYPE):
            if not re.fullmatch(r"agent-[1-9][0-9]*\.json", item["name"]):
                raise ValueError("Unexpected manifest attachment name")
            path = downloads / item["name"]
            api.download(prefix, item, path)
            manifests.append(json.loads(path.read_text(encoding="utf-8")))
        try:
            total = validate_manifests(manifests, identity)
            break
        except ValueError:
            if retry == 5:
                raise
            print("Waiting for all agent manifests to become available...", flush=True)
            time.sleep(5)
    chunks = {}
    for item in api.attachments(prefix, plan, CHUNK_TYPE):
        if item["name"] in chunks:
            raise ValueError("Duplicate evidence chunk from repeated jobs; refusing an ambiguous report")
        chunks[item["name"]] = item
    bundle = work / "bundle"
    evidence = bundle / "Artifacts"
    evidence.mkdir(parents=True)
    for manifest in sorted(manifests, key=lambda m: m["position"]):
        for info in manifest["parts"]:
            if not re.fullmatch(r"agent-[1-9][0-9]*-[0-9]{5}\.part", info["name"]):
                raise ValueError("Unexpected evidence chunk filename")
            if info["name"] not in chunks:
                raise ValueError(f"Evidence chunk missing: {info['name']}")
            api.download(prefix, chunks[info["name"]], downloads / info["name"])
        unpack(manifest, downloads, evidence / f"agent-{manifest['position']}")
    (bundle / "collection-manifest.json").write_text(json.dumps(manifests, indent=2), encoding="utf-8")
    print(f"Verified {total} agent(s), {sum(m['scenarioCount'] for m in manifests)} scenario attempts for deployment {identity['deploymentId']}", flush=True)
    report = generate(evidence, bundle, Path(__file__).resolve().parent.parent)
    attach(report, "file")


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("mode", choices=["publish", "collect"])
    args = parser.parse_args()
    try:
        if args.mode == "publish":
            publish()
        elif os.environ.get("EVIDENCE_TRANSPORT") == "pipeline":
            collect_pipeline()
        else:
            collect()
        return 0
    except Exception as error:
        print(f"##vso[task.logissue type=error;]{command_escape(str(error))}", flush=True)
        return 1


if __name__ == "__main__":
    sys.exit(main())
