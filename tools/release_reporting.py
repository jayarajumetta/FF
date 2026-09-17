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

MANIFEST_TYPE = "InsuranceAutomation.EvidenceManifest"
CHUNK_TYPE = "InsuranceAutomation.EvidenceChunk"
CHUNK_BYTES = 64 * 1024 * 1024


def required(name: str) -> str:
    value = os.environ.get(name, "").strip()
    if not value or "$(" in value:
        raise ValueError(f"Required pipeline variable is missing: {name}")
    return value


def scope() -> dict:
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


def pack(results: Path, output: Path, identity: dict, position: int, total: int, chunk_bytes: int = CHUNK_BYTES) -> Path:
    if not 1 <= position <= total:
        raise ValueError("Invalid System.JobPositionInPhase / System.TotalJobsInPhase")
    if not results.is_dir():
        raise FileNotFoundError(f"Test results directory not found: {results}")
    evidence = results / "Artifacts"
    output.mkdir(parents=True, exist_ok=False)
    archive = output / f"agent-{position}.zip"
    count = 0
    with zipfile.ZipFile(archive, "w", zipfile.ZIP_DEFLATED, allowZip64=True) as zipped:
        for path in sorted(evidence.rglob("*")) if evidence.exists() else []:
            if path.is_symlink() or not path.resolve().is_relative_to(evidence.resolve()):
                raise ValueError(f"Evidence links outside the source are not supported: {path}")
            if path.is_file():
                zipped.write(path, path.relative_to(results).as_posix())
                count += path.name == "scenario-result.json"
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
        "schemaVersion": 1, **identity, "position": position, "totalJobs": total,
        "scenarioCount": count, "archiveSha256": digest(archive), "parts": parts,
    }
    path = output / f"agent-{position}.json"
    path.write_text(json.dumps(manifest, indent=2), encoding="utf-8")
    archive.unlink()
    return path


def publish() -> None:
    results = Path(required("TEST_RESULTS_ROOT")).resolve()
    output = Path(tempfile.mkdtemp(prefix="release-evidence-", dir=required("AGENT_TEMPDIRECTORY"))) / "handoff"
    manifest_path = pack(results, output, scope(), int(required("SYSTEM_JOBPOSITIONINPHASE")), int(required("SYSTEM_TOTALJOBSINPHASE")))
    manifest = json.loads(manifest_path.read_text(encoding="utf-8"))
    print(f"Evidence root: {results / 'Artifacts'}; shard {manifest['position']}/{manifest['totalJobs']}; scenarios/attempts: {manifest['scenarioCount']}", flush=True)
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
        if manifest.get("schemaVersion") != 1 or any(manifest.get(k) != v for k, v in identity.items()):
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
            if (not item.filename.startswith("Artifacts/") or "\\" in item.filename or ":" in item.filename
                    or ".." in relative.parts or not destination.is_relative_to(target.resolve())
                    or (item.external_attr >> 16) & 0o170000 == 0o120000
                    or item.filename.casefold() in seen):
                raise ValueError(f"Unsafe/duplicate evidence archive member: {item.filename}")
            seen.add(item.filename.casefold())
            zipped.extract(item, target)
    count = sum(1 for _ in target.rglob("scenario-result.json"))
    if count != manifest["scenarioCount"]:
        raise ValueError("Extracted scenario count does not match agent manifest")


def generate(evidence: Path, bundle: Path, source: Path) -> Path:
    import generate_consolidated_report as generator

    report = bundle / "ConsolidatedReport"
    if generator.main(["--evidence-root", str(evidence), "--source-root", str(source), "--output-dir", str(report), "--fail-on-empty"]) != 0:
        raise ValueError("No completed scenario evidence found; consolidated report generation failed")
    for name in ("report.html", "log.html", "summary.json", "output.xml"):
        if not (report / name).is_file():
            raise FileNotFoundError(f"Expected report output missing: {name}")
    archive = bundle.parent / "FinalConsolidatedReport.zip"
    with zipfile.ZipFile(archive, "w", zipfile.ZIP_DEFLATED, allowZip64=True) as zipped:
        for path in sorted(bundle.rglob("*")):
            if path.is_file():
                zipped.write(path, path.relative_to(bundle).as_posix())
    return archive


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
    archive = generate(evidence, bundle, Path(__file__).resolve().parent.parent)
    report = bundle / "ConsolidatedReport"
    summary = work / "report-summary.md"
    summary.write_text(f"# Consolidated test report\n\nRelease {identity['releaseId']}, environment {identity['environmentId']}, deployment {identity['deploymentId']}.\n\nCollected all **{total}** agent shards. Download `FinalConsolidatedReport.zip` from this task's logs/attachments, extract it, and open `ConsolidatedReport/report.html`. Keep the adjacent `Artifacts` folder for linked videos/traces.\n", encoding="utf-8")
    print(f"##vso[task.uploadsummary]{command_escape(str(summary))}", flush=True)
    for name in ("report.html", "log.html", "summary.json", "output.xml"):
        attach(report / name, "file")
    attach(archive, "file")


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("mode", choices=["publish", "collect"])
    args = parser.parse_args()
    try:
        publish() if args.mode == "publish" else collect()
        return 0
    except Exception as error:
        print(f"##vso[task.logissue type=error;]{command_escape(str(error))}", flush=True)
        return 1


if __name__ == "__main__":
    sys.exit(main())
