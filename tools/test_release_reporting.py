"""Offline release handoff regressions; no browser or Azure credentials required."""
import contextlib
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
        self.assertEqual(5, console.getvalue().count("##vso[task.uploadfile]"))
        archives = list(self.root.rglob("FinalConsolidatedReport.zip"))
        self.assertEqual(1, len(archives))
        with zipfile.ZipFile(archives[0]) as zipped:
            summary = json.loads(zipped.read("ConsolidatedReport/summary.json"))
            self.assertEqual(2, summary["total"])
            self.assertEqual(3, sum(n.endswith("scenario-result.json") for n in zipped.namelist()))
        self.assertNotIn("test-only-token", console.getvalue())

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
        for environment in pipeline["environments"]:
            execution, aggregate = environment["deployPhases"]
            self.assertEqual("Run automation on Windows agent", execution["name"])
            self.assertEqual("none", aggregate["deploymentInput"]["parallelExecution"]["parallelExecutionType"])
            self.assertEqual("always()", aggregate["deploymentInput"]["condition"])
            self.assertTrue(aggregate["deploymentInput"]["enableAccessToken"])
            self.assertLess(execution["rank"], aggregate["rank"])
            prepare = next(t for t in execution["workflowTasks"] if t["refName"].endswith("_Prepare"))
            self.assertEqual("$(StageResultsDirectory)", prepare["environment"]["STAGERESULTSDIRECTORY"])
            self.assertEqual("$(test.RunId)", prepare["environment"]["ONDEMAND_TEST_RUN_ID"])
            publisher = execution["workflowTasks"][-1]
            self.assertIn(".FullName publish", publisher["inputs"]["script"])
            self.assertEqual("always()", publisher["condition"])
            self.assertFalse(publisher["continueOnError"])
            collector = aggregate["workflowTasks"][-1]
            self.assertIn(".FullName collect", collector["inputs"]["script"])
            self.assertEqual("$(System.AccessToken)", collector["environment"]["SYSTEM_ACCESSTOKEN"])
            self.assertFalse(collector["continueOnError"])
            self.assertNotIn("exit 0", collector["inputs"]["script"])


if __name__ == "__main__":
    unittest.main()
