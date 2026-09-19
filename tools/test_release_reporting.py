"""Offline release handoff regressions; no browser or Azure credentials required."""
import contextlib
import hashlib
import io
import json
import os
from pathlib import Path
import shutil
import subprocess
import tempfile
import unittest
from unittest.mock import patch
import zipfile

import release_reporting as reporting

ROOT = Path(__file__).resolve().parent.parent
IDENTITY = {"releaseId": "51", "environmentId": "62", "deploymentId": "73"}


class ReleaseReportingTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.root = Path(self.temp.name)

    def evidence(self, name, attempts=("PASS",)):
        results = self.root / name
        for number, status in enumerate(attempts, 1):
            directory = results / "Artifacts" / "CommercialLines.DuckCreek.Tests" / f"case-{number}"
            directory.mkdir(parents=True)
            (directory / "scenario-result.json").write_text(json.dumps({
                "feature": "GL smoke", "scenario": name, "status": status,
                "executionId": name, "testFullName": f"Example.{name}",
                "attemptNumber": number, "maxAttempts": len(attempts),
                "durationMilliseconds": 100, "steps": [],
                "artifacts": {"trace": "trace.zip"},
            }), encoding="utf-8")
            (directory / "trace.zip").write_bytes(b"trace fixture")
        return results

    def test_video_policy_defaults_and_boolean_validation(self):
        from generate_consolidated_report import video_policy, exclude_video
        self.assertEqual((True, True), video_policy(self.root))
        config = self.root / "config"
        config.mkdir()
        (config / "framework.json").write_text(json.dumps({"reporting": {"excludeVideos": False}}))
        self.assertEqual((False, True), video_policy(self.root))
        self.assertTrue(exclude_video((True, False), "FAIL"))
        self.assertTrue(exclude_video((False, True), "PASS"))
        self.assertFalse(exclude_video((False, True), "FAIL"))
        (config / "framework.json").write_text(json.dumps({"reporting": {"excludeVideos": "false"}}))
        with self.assertRaisesRegex(ValueError, "must be booleans"):
            video_policy(self.root)

    def test_video_exclusion_archive_and_report_matrix(self):
        import generate_consolidated_report as generator
        for policy, retained in (((True, True), ()), ((True, False), ()),
                                 ((False, True), (1,)), ((False, False), (1, 2))):
            with self.subTest(policy=policy):
                name = f"video-{policy[0]}-{policy[1]}"
                results = self.evidence(name, ("FAIL", "PASS"))
                for number in (1, 2):
                    directory = results / "Artifacts" / "CommercialLines.DuckCreek.Tests" / f"case-{number}"
                    video = directory / f"attempt-{number}.webm"
                    video.write_bytes(b"video fixture")
                    (directory / "execution.log").write_text("compressed log\n" * 100)
                    result_path = directory / "scenario-result.json"
                    result = json.loads(result_path.read_text())
                    result["artifacts"]["video"] = video.name
                    result_path.write_text(json.dumps(result))
                    nested = io.BytesIO()
                    with zipfile.ZipFile(nested, "w") as archive:
                        archive.writestr(video.name, b"nested video")
                        archive.writestr("execution.log", "nested log")
                    with zipfile.ZipFile(directory / "evidence-bundle.zip", "w") as archive:
                        archive.writestr("nested.zip", nested.getvalue())
                    runner = results / "Runner" / str(number)
                    runner.mkdir(parents=True)
                    shutil.copyfile(video, runner / video.name)
                output = self.root / name / "handoff"
                manifest = json.loads(reporting.pack(results, output, IDENTITY, 1, 1, policy=policy).read_text())
                with zipfile.ZipFile(output / "agent-1.zip") as archive:
                    videos = [n for n in archive.namelist() if n.endswith(".webm")]
                    self.assertEqual(2 * len(retained), len(videos))
                    for number in (1, 2):
                        prefix = f"Artifacts/CommercialLines.DuckCreek.Tests/case-{number}/"
                        self.assertEqual(zipfile.ZIP_DEFLATED, archive.getinfo(prefix + "execution.log").compress_type)
                        with zipfile.ZipFile(io.BytesIO(archive.read(prefix + "evidence-bundle.zip"))) as bundle:
                            with zipfile.ZipFile(io.BytesIO(bundle.read("nested.zip"))) as nested_zip:
                                self.assertEqual(number in retained, f"attempt-{number}.webm" in nested_zip.namelist())
                                self.assertIn("execution.log", nested_zip.namelist())
                self.assertEqual(2, manifest["scenarioCount"])
                final_archive = self.root / (name + "-final.zip")
                with patch.object(reporting, "video_policy", return_value=policy):
                    reporting.archive_bundle(results / "Artifacts", final_archive)
                with zipfile.ZipFile(final_archive) as archive:
                    self.assertEqual(len(retained), sum(n.endswith(".webm") for n in archive.namelist()))
                    self.assertEqual(2, sum(n.endswith("execution.log") for n in archive.namelist()))
                source = self.root / (name + "-source")
                (source / "config").mkdir(parents=True)
                (source / "config/framework.json").write_text(json.dumps({"reporting": {
                    "excludeVideos": policy[0], "excludePassedVideos": policy[1]}}))
                report = self.root / (name + "-report")
                with contextlib.redirect_stdout(io.StringIO()):
                    generator.main(["--evidence-root", str(results / "Artifacts"), "--source-root", str(source), "--output-dir", str(report)])
                html = (report / "report.html").read_text(encoding="utf-8")
                self.assertEqual(len(retained), html.count("<video controls"))
                for number in (1, 2):
                    self.assertTrue((results / "Artifacts" / "CommercialLines.DuckCreek.Tests" / f"case-{number}" / f"attempt-{number}.webm").exists())

    def manifest(self, position, total, attempts=("PASS",)):
        results = self.evidence(f"agent{position}", attempts)
        output = self.root / f"parts-{position}"
        path = reporting.pack(results, output, IDENTITY, position, total, chunk_bytes=80)
        return json.loads(path.read_text()), output

    def test_single_agent_pack_roundtrip_and_portable_report(self):
        manifest, parts = self.manifest(1, 1, ("FAIL", "PASS"))
        self.assertGreater(len(manifest["parts"]), 1)
        self.assertEqual(1, reporting.validate_manifests([manifest], IDENTITY))
        bundle = self.root / "bundle"
        evidence = bundle / "Artifacts"
        reporting.unpack(manifest, parts, evidence / "agent-1")
        with contextlib.redirect_stdout(io.StringIO()):
            archive = reporting.generate(evidence, bundle, ROOT)
        with zipfile.ZipFile(archive) as zipped:
            self.assertIn("ConsolidatedReport/report.html", zipped.namelist())
            self.assertEqual(2, sum(p.endswith("scenario-result.json") for p in zipped.namelist()))
            self.assertEqual(2, sum(p.endswith("trace.zip") for p in zipped.namelist()))
            report_html = zipped.read("ConsolidatedReport/report.html").decode("utf-8")
            self.assertIn("../Artifacts/agent-1/Artifacts/CommercialLines.DuckCreek.Tests/case-1/trace.zip", report_html)
            summary = json.loads(zipped.read("ConsolidatedReport/summary.json"))
        self.assertEqual(1, summary["total"])

    def test_report_ignores_runner_attachment_copies_but_archives_them(self):
        results = self.evidence("copied", ("FAIL", "PASS"))
        original = results / "Artifacts" / "CommercialLines.DuckCreek.Tests" / "case-1"
        for name in ("Runner", "NUnit", "NUnitWork"):
            shutil.copytree(original, results / name / "attachments" / "case-1")
        parts = self.root / "parts"
        manifest = json.loads(reporting.pack(results, parts, IDENTITY, 1, 1).read_text())
        self.assertEqual(2, manifest["scenarioCount"])
        bundle = self.root / "bundle"
        evidence = bundle / "Artifacts"
        reporting.unpack(manifest, parts, evidence / "agent-1")
        with contextlib.redirect_stdout(io.StringIO()):
            archive = reporting.generate(evidence, bundle, ROOT)
        with zipfile.ZipFile(archive) as zipped:
            self.assertEqual(5, sum(n.endswith("scenario-result.json") for n in zipped.namelist()))
            summary = json.loads(zipped.read("ConsolidatedReport/summary.json"))
            self.assertEqual(1, summary["total"])
            self.assertIn("../Artifacts/agent-1/Artifacts/CommercialLines.DuckCreek.Tests/case-1/trace.zip",
                          zipped.read("ConsolidatedReport/report.html").decode())

    def test_report_rejects_duplicate_canonical_attempts_with_paths(self):
        results = self.evidence("conflict")
        original = results / "Artifacts" / "CommercialLines.DuckCreek.Tests" / "case-1"
        shutil.copytree(original, original.parent / "conflicting-copy")
        parts = self.root / "parts"
        manifest = json.loads(reporting.pack(results, parts, IDENTITY, 1, 1).read_text())
        bundle = self.root / "bundle"
        evidence = bundle / "Artifacts"
        reporting.unpack(manifest, parts, evidence / "agent-1")
        with self.assertRaises(ValueError) as error:
            reporting.generate(evidence, bundle, ROOT)
        self.assertIn("Duplicate attempt numbers", str(error.exception))
        self.assertIn("conflicting-copy", str(error.exception))
        self.assertIn("case-1", str(error.exception))

    def test_report_handles_empty_agent_and_populated_agent(self):
        bundle = self.root / "bundle"
        evidence = bundle / "Artifacts"
        for position, attempts in ((1, ()), (2, ("FAIL", "PASS"))):
            results = self.root / f"results-{position}"
            if attempts:
                results = self.evidence(f"results-{position}", attempts)
            else:
                results.mkdir()
            parts = self.root / f"parts-{position}"
            manifest = json.loads(reporting.pack(results, parts, IDENTITY, position, 2).read_text())
            reporting.unpack(manifest, parts, evidence / f"agent-{position}")
        with contextlib.redirect_stdout(io.StringIO()):
            archive = reporting.generate(evidence, bundle, ROOT)
        with zipfile.ZipFile(archive) as zipped:
            self.assertEqual(1, json.loads(zipped.read("ConsolidatedReport/summary.json"))["total"])

    def test_report_generator_rejects_overlapping_and_external_roots(self):
        import generate_consolidated_report as generator
        evidence = self.evidence("roots")
        args = ["--evidence-root", str(evidence), "--source-root", str(ROOT),
                "--output-dir", str(self.root / "report")]
        for roots in ((evidence, evidence / "Artifacts"), (self.root,)):
            with self.subTest(roots=roots), contextlib.redirect_stderr(io.StringIO()), self.assertRaises(SystemExit):
                generator.main(args + [value for root in roots for value in ("--scenario-root", str(root))])

    def test_missing_duplicate_and_wrong_deployment_shards_fail(self):
        first, _ = self.manifest(1, 2)
        second, _ = self.manifest(2, 2)
        self.assertEqual(2, reporting.validate_manifests([second, first], IDENTITY))
        for manifests in ([], [first], [first, first]):
            with self.assertRaises(ValueError):
                reporting.validate_manifests(manifests, IDENTITY)
        second["deploymentId"] = "older-run"
        with self.assertRaisesRegex(ValueError, "different release"):
            reporting.validate_manifests([first, second], IDENTITY)

    def test_corrupt_chunk_fails(self):
        manifest, parts = self.manifest(1, 1)
        (parts / manifest["parts"][0]["name"]).write_bytes(b"broken")
        with self.assertRaisesRegex(ValueError, "checksum/size"):
            reporting.unpack(manifest, parts, self.root / "unpacked")

    def test_raw_results_are_preserved_across_agents(self):
        results = self.evidence("raw")
        for name in ("Runner", "NUnit", "NUnitWork"):
            (results / name).mkdir()
            (results / name / "result.xml").write_text("<results />", encoding="utf-8")
        parts = self.root / "parts"
        manifest = json.loads(reporting.pack(results, parts, IDENTITY, 1, 1).read_text())
        target = self.root / "unpacked"
        reporting.unpack(manifest, parts, target)
        for name in ("Runner", "NUnit", "NUnitWork"):
            self.assertEqual("<results />", (target / name / "result.xml").read_text())

    @unittest.skipUnless(shutil.which("powershell.exe"), "Windows PowerShell is required")
    def test_entrypoint_rejects_tampered_runtime_and_wrong_configuration(self):
        download = self.root / "downloads"
        package = download / "_FF_CI" / "testpackage"
        self.fake_package(package)
        (package / "tools" / "release_reporting.py").write_text("# altered", encoding="utf-8")
        result = self.bootstrap(download)
        self.assertNotEqual(0, result.returncode)
        self.assertIn("Runtime checksum mismatch", result.stderr)
        self.assertNotIn("PREPARATION_EXECUTED", result.stdout)
        self.fake_package(package)
        info_path = package / "package-info.json"
        info = json.loads(info_path.read_text())
        info["buildConfiguration"] = "Debug"
        info_path.write_text(json.dumps(info), encoding="utf-8")
        result = self.bootstrap(download)
        self.assertNotEqual(0, result.returncode)
        self.assertIn("BuildConfiguration must match", result.stderr)

    def test_missing_chunk_fails(self):
        manifest, parts = self.manifest(1, 1)
        (parts / manifest["parts"][0]["name"]).unlink()
        with self.assertRaises(FileNotFoundError):
            reporting.unpack(manifest, parts, self.root / "unpacked")

    def test_idle_agent_is_counted_but_empty_run_fails(self):
        results = self.root / "empty"
        results.mkdir()
        parts = self.root / "parts"
        path = reporting.pack(results, parts, IDENTITY, 1, 1)
        manifest = json.loads(path.read_text())
        self.assertEqual(0, manifest["scenarioCount"])
        self.assertEqual(1, reporting.validate_manifests([manifest], IDENTITY))
        bundle = self.root / "bundle"
        evidence = bundle / "Artifacts"
        reporting.unpack(manifest, parts, evidence / "agent-1")
        with contextlib.redirect_stdout(io.StringIO()), self.assertRaisesRegex(ValueError, "No completed scenario"):
            reporting.generate(evidence, bundle, ROOT)

    def test_zip_traversal_is_rejected_even_with_valid_hash(self):
        parts = self.root / "parts"
        parts.mkdir()
        chunk = parts / "agent-1-00000.part"
        with zipfile.ZipFile(chunk, "w") as zipped:
            zipped.writestr("Artifacts/../../outside.txt", "unsafe")
        manifest = {"position": 1, "scenarioCount": 0, "archiveSha256": reporting.digest(chunk), "parts": [
            {"name": chunk.name, "bytes": chunk.stat().st_size, "sha256": reporting.digest(chunk)}
        ]}
        with self.assertRaisesRegex(ValueError, "Unsafe"):
            reporting.unpack(manifest, parts, self.root / "unpacked")
        self.assertFalse((self.root / "outside.txt").exists())

    def test_metadata_scopes_to_current_deployment_and_execution_phase(self):
        release = self.release_metadata()
        self.assertEqual(("2", "execution-plan"), reporting.execution_scope(release, IDENTITY))
        with self.assertRaisesRegex(ValueError, "Current deployment"):
            reporting.execution_scope(release, {**IDENTITY, "deploymentId": "wrong"})

    @staticmethod
    def release_metadata():
        return {"environments": [{"id": 62, "deploySteps": [
            {"deploymentId": 72, "attempt": 1, "releaseDeployPhases": []},
            {"deploymentId": 73, "attempt": 2, "releaseDeployPhases": [
                {"name": "Run automation on Windows agent", "runPlanId": "execution-plan"},
                {"name": "Collect all agents and publish one consolidated report", "runPlanId": "report-plan"},
            ]},
        ]}]}

    def test_multi_agent_collector_downloads_and_publishes_one_zip(self):
        sources = {}
        for position in (1, 2):
            _, parts = self.manifest(position, 2, ("FAIL", "PASS") if position == 1 else ("FAIL",))
            for path in parts.iterdir():
                sources[path.name] = path
        downloads = []
        release = self.release_metadata()

        class FakeApi:
            def get(self, route):
                return release, None

            def attachments(self, prefix, plan, kind):
                if not prefix.endswith("/environments/62/attempts/2") or plan != "execution-plan":
                    raise AssertionError("Collector used wrong deployment scope")
                suffix = ".json" if kind == reporting.MANIFEST_TYPE else ".part"
                return [{"name": n} for n in sources if n.endswith(suffix)]

            def download(self, prefix, item, target):
                downloads.append(item["name"])
                shutil.copyfile(sources[item["name"]], target)

        environment = {
            "RELEASE_RELEASEID": "51", "RELEASE_ENVIRONMENTID": "62", "RELEASE_DEPLOYMENTID": "73",
            "SYSTEM_COLLECTIONURI": "https://dev.azure.com/example/", "SYSTEM_TEAMPROJECTID": "project",
            "SYSTEM_ACCESSTOKEN": "test-only-token", "AGENT_TEMPDIRECTORY": str(self.root),
        }
        console = io.StringIO()
        with patch.dict(os.environ, environment), patch.object(reporting, "ReleaseApi", return_value=FakeApi()), contextlib.redirect_stdout(console):
            reporting.collect()
        self.assertIn("agent-1.json", downloads)
        self.assertIn("agent-2.json", downloads)
        self.assertIn("Verified 2 agent(s), 3 scenario attempts", console.getvalue())
        self.assertEqual(6, console.getvalue().count("##vso[task.uploadfile]"))
        archives = list(self.root.rglob("FinalConsolidatedReport.zip"))
        self.assertEqual(1, len(archives))
        with zipfile.ZipFile(archives[0]) as zipped:
            summary = json.loads(zipped.read("ConsolidatedReport/summary.json"))
            self.assertEqual(2, summary["total"])
            self.assertEqual(3, sum(n.endswith("scenario-result.json") for n in zipped.namelist()))
        self.assertNotIn("test-only-token", console.getvalue())

    def pipeline_fixture(self, total=2):
        incoming = self.root / "downloaded"
        incoming.mkdir()
        identity = {"buildId": "101", "stageKey": "Assembly", "stageAttempt": "2"}
        for position in range(1, total + 1):
            results = self.evidence(f"worker-{position}")
            (results / "Runner").mkdir()
            (results / "Runner" / "result.trx").write_text(f"shard {position}")
            reporting.pack(results, incoming / f"evidence-Assembly-{position}-2", identity, position, total)
            shutil.rmtree(results)
        return {
            "BUILD_BUILDID": "101", "SYSTEM_STAGEATTEMPT": "2", "EVIDENCE_TRANSPORT": "pipeline",
            "EVIDENCE_DOWNLOAD_ROOT": str(incoming), "REPORT_OUTPUT_ROOT": str(self.root / "reports"),
            "EXPECTED_EVIDENCE": json.dumps({"Assembly": total}), "AGENT_TEMPDIRECTORY": str(self.root),
        }

    def test_pipeline_collect_survives_execution_workspace_cleanup(self):
        environment = self.pipeline_fixture()
        with patch.dict(os.environ, environment), contextlib.redirect_stdout(io.StringIO()):
            reporting.collect_pipeline()
        output = Path(environment["REPORT_OUTPUT_ROOT"])
        self.assertTrue((output / "RawTestResults.zip").is_file())
        with zipfile.ZipFile(output / "FinalConsolidatedReport.zip") as archive:
            self.assertEqual(2, sum(n.endswith("result.trx") for n in archive.namelist()))
            self.assertEqual(2, sum(n.endswith("scenario-result.json") for n in archive.namelist()))
            self.assertEqual(2, sum(n.endswith("trace.zip") for n in archive.namelist()))
            self.assertIn("ConsolidatedReport/report.html", archive.namelist())

    def test_pipeline_missing_shard_fails_but_preserves_raw_downloads(self):
        environment = self.pipeline_fixture()
        shutil.rmtree(Path(environment["EVIDENCE_DOWNLOAD_ROOT"]) / "evidence-Assembly-2-2")
        with patch.dict(os.environ, environment), self.assertRaisesRegex(ValueError, "Missing agent evidence"):
            reporting.collect_pipeline()
        output = Path(environment["REPORT_OUTPUT_ROOT"])
        self.assertTrue((output / "RawTestResults.zip").is_file())
        self.assertFalse((output / "FinalConsolidatedReport.zip").exists())

    def test_pipeline_rejects_stale_attempt_and_keeps_raw_results(self):
        environment = self.pipeline_fixture(1)
        path = Path(environment["EVIDENCE_DOWNLOAD_ROOT"]) / "evidence-Assembly-1-2" / "agent-1.json"
        manifest = json.loads(path.read_text())
        manifest["stageAttempt"] = "1"
        path.write_text(json.dumps(manifest))
        with patch.dict(os.environ, environment), self.assertRaisesRegex(ValueError, "different release"):
            reporting.collect_pipeline()
        self.assertTrue((Path(environment["REPORT_OUTPUT_ROOT"]) / "RawTestResults.zip").exists())

    def test_pipeline_report_failure_keeps_raw_results(self):
        environment = self.pipeline_fixture(1)
        with patch.dict(os.environ, environment), patch.object(reporting, "generate", side_effect=ValueError("report failed")):
            with self.assertRaisesRegex(ValueError, "report failed"):
                reporting.collect_pipeline()
        self.assertTrue((Path(environment["REPORT_OUTPUT_ROOT"]) / "RawTestResults.zip").exists())

    def test_pipeline_rejects_unexpected_duplicate_artifact(self):
        environment = self.pipeline_fixture(1)
        incoming = Path(environment["EVIDENCE_DOWNLOAD_ROOT"])
        shutil.copytree(incoming / "evidence-Assembly-1-2", incoming / "duplicate")
        with patch.dict(os.environ, environment), self.assertRaisesRegex(ValueError, "Unexpected or missing evidence"):
            reporting.collect_pipeline()
        self.assertFalse((Path(environment["REPORT_OUTPUT_ROOT"]) / "FinalConsolidatedReport.zip").exists())

    def test_classic_publish_uploads_raw_zip_before_manifest(self):
        results = self.evidence("classic-publish")
        environment = {"EVIDENCE_TRANSPORT": "", "RELEASE_RELEASEID": "51", "RELEASE_ENVIRONMENTID": "62",
                       "RELEASE_DEPLOYMENTID": "73", "TEST_RESULTS_ROOT": str(results),
                       "AGENT_TEMPDIRECTORY": str(self.root), "SYSTEM_JOBPOSITIONINPHASE": "1", "SYSTEM_TOTALJOBSINPHASE": "2"}
        with patch.dict(os.environ, environment), patch.object(reporting, "attach") as attach, contextlib.redirect_stdout(io.StringIO()):
            reporting.publish()
        first, last = attach.call_args_list[0], attach.call_args_list[-1]
        self.assertEqual("agent-1.zip", first.args[0].name)
        self.assertEqual("file", first.args[1])
        self.assertEqual(reporting.MANIFEST_TYPE, last.args[1])

    def test_pipeline_publish_exposes_handoff_and_downloadable_zip(self):
        results = self.evidence("publish")
        environment = {"EVIDENCE_TRANSPORT": "pipeline", "BUILD_BUILDID": "101", "STAGEKEY": "Assembly",
                       "SYSTEM_STAGEATTEMPT": "1", "TEST_RESULTS_ROOT": str(results),
                       "AGENT_TEMPDIRECTORY": str(self.root), "SYSTEM_JOBPOSITIONINPHASE": "1", "SYSTEM_TOTALJOBSINPHASE": "2"}
        console = io.StringIO()
        with patch.dict(os.environ, environment), contextlib.redirect_stdout(console):
            reporting.publish()
        self.assertIn("task.setvariable variable=EVIDENCE_HANDOFF", console.getvalue())
        self.assertNotIn("task.addattachment", console.getvalue())
        self.assertEqual(1, len(list(self.root.rglob("agent-1.zip"))))

    def test_yaml_pipeline_contract(self):
        pipeline = (ROOT / "azure-pipelines-cd.yml").read_text()
        execution = (ROOT / "pipelines/templates/execute-tests.yml").read_text()
        collector = (ROOT / "pipelines/templates/collect-results.yml").read_text()
        download = (ROOT / "pipelines/templates/download-testpackage.yml").read_text()
        for text in (pipeline, execution, collector, download):
            self.assertNotIn("checkout: self", text)
            self.assertNotIn("buildVersionToDownload: latest", text)
            self.assertNotIn("continueOnError: true", text)
        self.assertIn("DownloadBuildArtifacts@1", download)
        self.assertIn("buildVersionToDownload: specific", download)
        self.assertIn("parallel: ${{ parameters.agents }}", execution)
        self.assertIn("dependsOn: ValidateInput", execution)
        self.assertIn("distributionBatchType: basedOnTestCases", execution)
        self.assertIn("arguments: '-Mode Publish'", execution)
        self.assertIn("$(System.JobPositionInPhase)-$(System.StageAttempt)", execution)
        self.assertNotIn("PublishTestResults@2", execution)
        self.assertIn("dependsOn: ${{ parameters.dependencies }}", collector)
        self.assertIn("arguments: '-Mode Collect'", collector)
        self.assertIn("targetPath: '$(REPORT_OUTPUT_ROOT)'", collector)

    def test_release_api_routes_and_pagination(self):
        api = reporting.ReleaseApi("https://dev.azure.com/org/", "project", "unused")
        self.assertEqual("https://vsrm.dev.azure.com/org/project/_apis/release/", api.root)
        with patch.object(api, "get", side_effect=[({"value": [{"name": "a"}]}, "page 2"), ({"value": [{"name": "b"}]}, None)]) as get:
            items = api.attachments("releases/51/environments/62/attempts/2", "plan", reporting.MANIFEST_TYPE)
            self.assertEqual(2, len(items))
            self.assertIn("continuationToken=page%202", get.call_args.args[0])
        with patch.object(api, "get") as get:
            api.download("releases/51/environments/62/attempts/2", {
                "timelineId": "timeline", "recordId": "record", "type": reporting.CHUNK_TYPE, "name": "agent-1-00000.part",
            }, self.root / "download")
            self.assertIn("/timelines/timeline/records/record/attachments/", get.call_args.args[0])

    @unittest.skipUnless(shutil.which("powershell.exe"), "Windows PowerShell is required for package preparation")
    def test_preparation_preserves_config_and_isolates_agent_results(self):
        source = self.root / "package source"
        scripts = source / "scripts"
        scripts.mkdir(parents=True)
        shutil.copyfile(ROOT / "scripts" / "Prepare-ReleaseTestPackage.ps1", scripts / "Prepare-ReleaseTestPackage.ps1")
        (source / "config").mkdir()
        shutil.copyfile(ROOT / "config" / "framework.json", source / "config" / "framework.json")
        for project in ("InsuranceAutomation.Core", "CommercialLines.DuckCreek.Tests", "CommercialLines.ExpertQuote.Tests", "PersonalLines.DuckCreek.Tests"):
            directory = source / "bin" / project / "Release" / "net8.0"
            directory.mkdir(parents=True)
            (directory / f"{project}.dll").touch()
            (directory / "Microsoft.Playwright.dll").touch()
            (directory / "playwright.ps1").write_text("$global:LASTEXITCODE = 0", encoding="utf-8")
        wrapper = scripts / "test-prepare.ps1"
        wrapper.write_text("function robocopy { param($source, $destination) Copy-Item -Path (Join-Path $source '*') -Destination $destination -Recurse -Force; $global:LASTEXITCODE = 0 }\n& (Join-Path $PSScriptRoot 'Prepare-ReleaseTestPackage.ps1')\n", encoding="utf-8")
        env = {**os.environ, "BUILDCONFIGURATION": "Release", "HEADLESS": "true", "STAGEKEY": "TestPlan",
               "STAGERESULTSDIRECTORY": "TestResults/TestPlan", "PLAYWRIGHTBROWSER": "chromium",
               "RELEASE_RELEASEID": "51", "RELEASE_ENVIRONMENTID": "62", "RELEASE_DEPLOYMENTID": "73",
               "AGENT_TEMPDIRECTORY": str(self.root), "ONDEMAND_TEST_RUN_ID": "$(test.RunId)", "MANUALTESTRUNID": "456"}
        roots = []
        for _ in range(2):
            result = subprocess.run(["powershell.exe", "-NoProfile", "-ExecutionPolicy", "Bypass", "-File", str(wrapper)], env=env, text=True, capture_output=True, timeout=30)
            self.assertEqual(0, result.returncode, result.stdout + result.stderr)
            self.assertIn("##vso[task.setvariable variable=TCM_TEST_RUN_ID]456", result.stdout)
            prefix = "##vso[task.setvariable variable=TEST_PACKAGE_ROOT]"
            package = Path(next(line[len(prefix):] for line in result.stdout.splitlines() if line.startswith(prefix)))
            roots.append(package)
            config = json.loads((package / "config" / "framework.json").read_text(encoding="utf-8-sig"))
            original = json.loads((source / "config" / "framework.json").read_text(encoding="utf-8-sig"))
            self.assertEqual(original["execution"], config["execution"])
            self.assertEqual(original["reporting"]["attachPassedEvidenceToTestResult"], config["reporting"]["attachPassedEvidenceToTestResult"])
            self.assertTrue((package / "TestResults" / "TestPlan" / "Artifacts").is_dir())
        self.assertNotEqual(*roots)

        env.update(EVIDENCE_TRANSPORT="pipeline", BUILD_BUILDID="101", STAGEKEY="SingleCase",
                   STAGERESULTSDIRECTORY="TestResults/SingleCase")
        for name in ("RELEASE_RELEASEID", "RELEASE_ENVIRONMENTID", "RELEASE_DEPLOYMENTID"):
            env.pop(name, None)
        result = subprocess.run(["powershell.exe", "-NoProfile", "-ExecutionPolicy", "Bypass", "-File", str(wrapper)], env=env, text=True, capture_output=True, timeout=30)
        self.assertEqual(0, result.returncode, result.stdout + result.stderr)
        self.assertIn("build-101", result.stdout)
        self.assertNotIn("variable=TCM_TEST_RUN_ID", result.stdout)

    def bootstrap(self, download):
        pipeline = json.loads((ROOT / "azure_pipelines_release_pipeline.json").read_text(encoding="utf-8-sig"))
        paths = [next(t for t in e["deployPhases"][0]["workflowTasks"] if t["refName"].endswith("_Prepare"))["inputs"]["filePath"] for e in pipeline["environments"]]
        self.assertEqual(1, len(set(paths)), "Preparation paths must stay consistent across execution modes")
        script = Path(paths[0].replace("$(System.DefaultWorkingDirectory)", str(download)))
        env = {**os.environ, "SYSTEM_DEFAULTWORKINGDIRECTORY": str(download),
               "BUILDCONFIGURATION": "Release",
               "RELEASE_ARTIFACTS__FF_CI_BUILDID": "12345", "RELEASE_ARTIFACTS__FF_CI_SECRET": "do-not-log-this"}
        return subprocess.run(["powershell.exe", "-NoProfile", "-ExecutionPolicy", "Bypass", "-File", str(script), "-Mode", "Prepare"], env=env, text=True, capture_output=True, timeout=30)

    def fake_package(self, directory):
        for name in ("scripts", "bin", "config", "tools", "src", "tests"):
            (directory / name).mkdir(parents=True, exist_ok=True)
        (directory / "scripts" / "Prepare-ReleaseTestPackage.ps1").write_text("Write-Host 'PREPARATION_EXECUTED'", encoding="utf-8")
        (directory / "tools" / "release_reporting.py").write_text("# fixture", encoding="utf-8")
        (directory / "tools" / "generate_consolidated_report.py").write_text("# fixture", encoding="utf-8")
        (directory / "config" / "framework.json").write_text("{}", encoding="utf-8")
        shutil.copyfile(ROOT / "scripts" / "Invoke-ReleaseStage.ps1", directory / "scripts" / "Invoke-ReleaseStage.ps1")
        runtime = ("scripts/Invoke-ReleaseStage.ps1", "scripts/Prepare-ReleaseTestPackage.ps1", "tools/release_reporting.py", "tools/generate_consolidated_report.py", "config/framework.json")
        (directory / "package-info.json").write_text(json.dumps({
            "schemaVersion": 2, "buildConfiguration": "Release", "buildId": "12345", "buildNumber": "ci-12345",
            "sourceBranch": "refs/heads/sgs/develop", "sourceVersion": "abc123", "requiredFiles": list(runtime),
            "runtimeHashes": {name: hashlib.sha256((directory / name).read_bytes()).hexdigest() for name in runtime},
        }), encoding="utf-8")

    @unittest.skipUnless(shutil.which("powershell.exe"), "Windows PowerShell is required for the bootstrap")
    def test_bootstrap_rejects_missing_explicit_package(self):
        download = self.root / "downloads"
        download.mkdir()
        result = self.bootstrap(download)
        self.assertNotEqual(0, result.returncode)
        self.assertNotIn("do-not-log-this", result.stdout + result.stderr)
        self.assertIn("Invoke-ReleaseStage.ps1", result.stdout + result.stderr)

    @unittest.skipUnless(shutil.which("powershell.exe"), "Windows PowerShell is required for the bootstrap")
    def test_bootstrap_ignores_unrelated_artifact_sources(self):
        download = self.root / "downloads"
        self.fake_package(download / "_FF_CI" / "testpackage")
        self.fake_package(download / "_OtherCI" / "testpackage")
        result = self.bootstrap(download)
        self.assertEqual(0, result.returncode, result.stdout + result.stderr)
        self.assertEqual(1, result.stdout.count("PREPARATION_EXECUTED"))

    @unittest.skipUnless(shutil.which("powershell.exe"), "Windows PowerShell is required for the bootstrap")
    def test_bootstrap_invokes_one_nested_package_and_logs_provenance(self):
        download = self.root / "downloads"
        package = download / "_FF_CI" / "testpackage"
        self.fake_package(package)
        result = self.bootstrap(download)
        self.assertEqual(0, result.returncode, result.stdout + result.stderr)
        self.assertIn("Package build: 12345", result.stdout)
        self.assertIn("commit: abc123", result.stdout)
        self.assertIn("PREPARATION_EXECUTED", result.stdout)

    @unittest.skipUnless(shutil.which("powershell.exe"), "Windows PowerShell is required for the bootstrap")
    def test_bootstrap_rejects_missing_reporting_dependencies(self):
        download = self.root / "downloads"
        package = download / "_FF_CI" / "testpackage"
        self.fake_package(package)
        (package / "tools" / "release_reporting.py").unlink()
        result = self.bootstrap(download)
        self.assertNotEqual(0, result.returncode)
        self.assertIn("Incomplete testpackage", result.stderr)
        self.assertIn("tools/release_reporting.py", result.stderr)
        self.assertNotIn("PREPARATION_EXECUTED", result.stdout)

    @unittest.skipUnless(shutil.which("powershell.exe"), "Windows PowerShell is required for CI packaging")
    def test_ci_packaging_cleans_stale_outputs_and_rejects_missing_script(self):
        source = self.root / "CI source"
        staging = self.root / "CI staging"
        self.fake_package(source)
        for project in ("InsuranceAutomation.Core", "CommercialLines.DuckCreek.Tests", "CommercialLines.ExpertQuote.Tests", "PersonalLines.DuckCreek.Tests"):
            directory = source / "bin" / project / "Release" / "net8.0"
            directory.mkdir(parents=True)
            (directory / f"{project}.dll").touch()
            if project.endswith("Tests"):
                for name in (f"{project}.deps.json", f"{project}.runtimeconfig.json", "playwright.ps1", "Microsoft.Playwright.dll", "NUnit3.TestAdapter.dll", "reqnroll.json"):
                    (directory / name).touch()
                source_data = source / "tests" / project / "TestData"
                source_data.mkdir(parents=True)
                (source_data / "fixture.json").write_text("{}", encoding="utf-8")
        command = ["powershell.exe", "-NoProfile", "-ExecutionPolicy", "Bypass", "-File", str(ROOT / "scripts" / "Build-TestPackage.ps1"), "-SourceRoot", str(source), "-StagingDirectory", str(staging)]
        env = {**os.environ, "BUILD_BUILDID": "54321", "BUILD_BUILDNUMBER": "ci-54321", "BUILD_SOURCEBRANCH": "refs/heads/sgs/develop", "BUILD_SOURCEVERSION": "def456"}
        package = staging / "testpackage"
        for _ in range(2):
            stale = package / "stale" / "scripts"
            stale.mkdir(parents=True)
            (stale / "Prepare-ReleaseTestPackage.ps1").touch()
            result = subprocess.run(command, env=env, text=True, capture_output=True, timeout=30)
            self.assertEqual(0, result.returncode, result.stdout + result.stderr)
            self.assertEqual(1, len(list(package.rglob("Prepare-ReleaseTestPackage.ps1"))))
            info = json.loads((package / "package-info.json").read_text(encoding="utf-8-sig"))
            self.assertEqual("54321", info["buildId"])
            self.assertEqual("def456", info["sourceVersion"])
            self.assertEqual(2, info["schemaVersion"])
            self.assertEqual("Release", info["buildConfiguration"])
            for project in ("CommercialLines.DuckCreek.Tests", "CommercialLines.ExpertQuote.Tests", "PersonalLines.DuckCreek.Tests"):
                self.assertTrue((package / "bin" / project / "Release" / "net8.0" / "TestData" / "fixture.json").is_file())
            for relative, checksum in info["runtimeHashes"].items():
                self.assertEqual(checksum.lower(), hashlib.sha256((package / relative).read_bytes()).hexdigest())
        (source / "scripts" / "Prepare-ReleaseTestPackage.ps1").unlink()
        result = subprocess.run(command, env=env, text=True, capture_output=True, timeout=30)
        self.assertNotEqual(0, result.returncode)
        self.assertIn("Cannot publish an incomplete testpackage", result.stderr)
        self.assertTrue((package / "package-info.json").exists(), "Preflight failure must not destroy an existing package")

    @unittest.skipUnless(shutil.which("powershell.exe"), "Windows PowerShell is required for preflight")
    def test_classic_inline_preflight_checks_selected_build_and_missing_files(self):
        pipeline = json.loads((ROOT / "azure_pipelines_release_pipeline.json").read_text(encoding="utf-8-sig"))
        scripts = [phase["workflowTasks"][0]["inputs"]["script"]
                   for environment in pipeline["environments"] for phase in environment["deployPhases"]]
        self.assertEqual(1, len(set(scripts)), "Every phase must enforce the same package contract")
        wrapper = self.root / "preflight.ps1"
        wrapper.write_text(scripts[0], encoding="utf-8")
        download = self.root / "downloads"
        package = download / "_FF_CI" / "testpackage"
        self.fake_package(package)
        env = {**os.environ, "SYSTEM_DEFAULTWORKINGDIRECTORY": str(download),
               "SELECTED_CI_BUILD_ID": "12345", "BUILDCONFIGURATION": "Release"}

        def run():
            return subprocess.run(["powershell.exe", "-NoProfile", "-ExecutionPolicy", "Bypass", "-File", str(wrapper)],
                                  env=env, text=True, capture_output=True, timeout=30)

        result = run()
        self.assertEqual(0, result.returncode, result.stdout + result.stderr)
        self.assertIn("Validated CI build 12345", result.stdout)
        env["SELECTED_CI_BUILD_ID"] = "54321"
        result = run()
        self.assertNotEqual(0, result.returncode)
        self.assertIn("Package build ID differs", result.stderr)
        env["SELECTED_CI_BUILD_ID"] = "$(Release.Artifacts._FF_CI.BuildId)"
        result = run()
        self.assertNotEqual(0, result.returncode)
        self.assertIn("not linked to a build", result.stderr)
        env["SELECTED_CI_BUILD_ID"] = "12345"
        env["BUILDCONFIGURATION"] = "Debug"
        result = run()
        self.assertNotEqual(0, result.returncode)
        self.assertIn("BuildConfiguration must match", result.stderr)
        env["BUILDCONFIGURATION"] = "Release"
        (package / "scripts" / "Invoke-ReleaseStage.ps1").unlink()
        result = run()
        self.assertNotEqual(0, result.returncode)
        self.assertIn("Missing CI package file", result.stderr)

    def test_pipeline_contract(self):
        def unique_keys(pairs):
            result = {}
            for key, value in pairs:
                self.assertNotIn(key, result, f"Duplicate JSON property: {key}")
                result[key] = value
            return result

        pipeline = json.loads((ROOT / "azure_pipelines_release_pipeline.json").read_text(encoding="utf-8-sig"), object_pairs_hook=unique_keys)
        self.assertEqual("TestCategory=gl_smoke_test", pipeline["variables"]["AssemblyTestFilter"]["value"])
        self.assertEqual(3, len(pipeline["environments"]))
        references = []
        for environment in pipeline["environments"]:
            execution, aggregate = environment["deployPhases"]
            for phase in (execution, aggregate):
                deployment = phase["deploymentInput"]
                self.assertNotIn("agentSpecification", deployment)
                self.assertIn("Agent.OS -equals Windows_NT", deployment["demands"])
                self.assertEqual(10, deployment["jobCancelTimeoutInMinutes"])
                self.assertFalse(deployment["skipArtifactsDownload"])
                self.assertEqual("_FF_CI", deployment["artifactsDownloadInput"]["downloadInputs"][0]["alias"])
                preflight = phase["workflowTasks"][0]
                self.assertTrue(preflight["refName"].endswith("Preflight"))
                self.assertEqual("inline", preflight["inputs"]["targetType"])
                self.assertEqual("succeeded()", preflight["condition"])
                self.assertFalse(preflight["continueOnError"])
                self.assertEqual("$(Release.Artifacts._FF_CI.BuildId)", preflight["environment"]["SELECTED_CI_BUILD_ID"])
                for task in phase["workflowTasks"]:
                    references.append(task["refName"])
                    if task["refName"].startswith("UsePython_"):
                        self.assertEqual("true", task["inputs"]["disableDownloadFromRegistry"])
                        self.assertEqual("succeeded()", task["condition"])
                        self.assertEqual({}, task["environment"])
            self.assertEqual("Run automation on Windows agent", execution["name"])
            self.assertEqual("succeeded()", execution["deploymentInput"]["condition"])
            self.assertEqual("none", aggregate["deploymentInput"]["parallelExecution"]["parallelExecutionType"])
            self.assertEqual("succeededOrFailed()", aggregate["deploymentInput"]["condition"])
            self.assertTrue(aggregate["deploymentInput"]["enableAccessToken"])
            self.assertLess(execution["rank"], aggregate["rank"])
            prepare = next(t for t in execution["workflowTasks"] if t["refName"].endswith("_Prepare"))
            self.assertEqual("$(StageResultsDirectory)", prepare["environment"]["STAGERESULTSDIRECTORY"])
            self.assertEqual("$(test.RunId)", prepare["environment"]["ONDEMAND_TEST_RUN_ID"])
            publisher = execution["workflowTasks"][-1]
            self.assertEqual("-Mode Publish", publisher["inputs"]["arguments"])
            self.assertEqual("always()", publisher["condition"])
            self.assertFalse(publisher["continueOnError"])
            collector = aggregate["workflowTasks"][-1]
            self.assertEqual("succeeded()", collector["condition"])
            self.assertFalse(collector["alwaysRun"])
            self.assertEqual("-Mode Collect", collector["inputs"]["arguments"])
            self.assertEqual("$(System.AccessToken)", collector["environment"]["SYSTEM_ACCESSTOKEN"])
            self.assertFalse(collector["continueOnError"])
            self.assertEqual(2, execution["deploymentInput"]["parallelExecution"]["maxNumberOfAgents"])
            for task in (prepare, publisher, collector):
                self.assertEqual("classic", task["environment"]["EVIDENCE_TRANSPORT"])
                self.assertEqual("$(BuildConfiguration)", task["environment"]["BUILDCONFIGURATION"])
                self.assertEqual(0, task["retryCountOnTaskFailure"])
                self.assertEqual("filePath", task["inputs"]["targetType"])
                self.assertEqual("$(System.DefaultWorkingDirectory)\\_FF_CI\\testpackage\\scripts\\Invoke-ReleaseStage.ps1", task["inputs"]["filePath"])
                self.assertNotIn("script", task["inputs"])
            vstest = next(t for t in execution["workflowTasks"] if t["refName"].startswith("VSTest_"))
            self.assertEqual("basedOnTestCases", vstest["inputs"]["distributionBatchType"])
            self.assertEqual("autoBatchSize", vstest["inputs"]["batchingBasedOnAgentsOption"])
            self.assertEqual("false", vstest["inputs"]["dontDistribute"])
            self.assertEqual("false", vstest["inputs"]["uiTests"])
        self.assertEqual(len(references), len(set(references)))


if __name__ == "__main__":
    unittest.main()
