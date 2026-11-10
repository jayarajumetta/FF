import json
from pathlib import Path
import re
import shutil
import subprocess
import tempfile
import unittest


ROOT = Path(__file__).resolve().parents[1]


class BasicLayoutTests(unittest.TestCase):
    def test_basic_features_have_application_lob_and_suite_tags(self):
        applications = {
            "CommercialLines.DuckCreek.Tests": ("CLDC", "cldc"),
            "CommercialLines.ExpertQuote.Tests": ("CL_EQ", "cleq"),
            "PersonalLines.DuckCreek.Tests": ("PL_DC", "pldc"),
        }
        features = list(ROOT.glob("tests/*/Features/Basic/*.feature"))
        self.assertTrue(features)
        for feature in features:
            with self.subTest(feature=feature.relative_to(ROOT)):
                project = next(parent.parent for parent in feature.parents if parent.name == "Features")
                app_tag, app_prefix = applications[project.name]
                lob_match = re.search(r"(?:^|_)([A-Z]+)_Basic_", feature.stem)
                self.assertIsNotNone(lob_match, feature.name)
                lob = lob_match.group(1)
                header = feature.read_text(encoding="utf-8-sig").split("Feature:", 1)[0]
                tags = re.findall(r"@(\w+)", header)
                required = {app_tag, lob, "basic", f"{lob.lower()}_basic", f"{app_prefix}_basic"}
                self.assertTrue(required.issubset(tags), f"Missing tags: {sorted(required - set(tags))}")
                self.assertEqual(len(tags), len(set(tags)), "Duplicate feature tags")

    def test_basic_features_and_scenarios_use_matching_category_folders(self):
        features = [path for path in ROOT.glob("tests/*/Features/**/*.feature")
                    if "basic" in path.name.lower()]
        self.assertTrue(features)
        for feature in features:
            with self.subTest(feature=feature.relative_to(ROOT)):
                self.assertEqual("Basic", feature.parent.name)
                project = next(parent.parent for parent in feature.parents if parent.name == "Features")
                references = re.findall(r'TestData/Scenarios/[^\s|"\']+\.json', feature.read_text(encoding="utf-8-sig"))
                self.assertTrue(references)
                for reference in references:
                    self.assertTrue(reference.startswith("TestData/Scenarios/Basic/"), reference)
                    self.assertTrue((project / reference).is_file(), reference)

        scenarios = [path for path in ROOT.glob("tests/*/TestData/Scenarios/**/*.json")
                     if "basic" in path.name.lower()]
        self.assertTrue(scenarios)
        for scenario in scenarios:
            with self.subTest(scenario=scenario.relative_to(ROOT)):
                self.assertEqual("Basic", scenario.parent.name)
                self.assertEqual("Scenarios", scenario.parent.parent.name)
                document = json.loads(scenario.read_text(encoding="utf-8-sig"))
                self.assertNotIn("_canonical", document)
                self.assertNotIn("_rawTosca", document)
                for section in ("application", "dimensions", "values", "random", "external"):
                    self.assertIsInstance(document.get(section), dict)

    def test_basic_sources_do_not_route_through_layered_manifests(self):
        for manifest_path in ROOT.glob("tests/*/TestData/Layered/manifest.json"):
            manifest = json.loads(manifest_path.read_text(encoding="utf-8-sig"))
            basic_entries = [name for name in manifest["entries"] if "basic_policy" in name.lower()]
            self.assertEqual([], basic_entries, manifest_path.relative_to(ROOT))

    @unittest.skipUnless(shutil.which("powershell.exe"), "Windows PowerShell is required")
    def test_bap_maintenance_scripts_use_basic_without_touching_other_folders(self):
        scripts = ROOT / "tests/CommercialLines.DuckCreek.Tests/TestData/Scenarios"
        fixtures = {
            "Fix-BapPremiumAsterisk.ps1": {"expected_premium_value_233": "*$1,890.00"},
            "Fix-BapPremiumDollarSign.ps1": {"expected_full_term_premium_value_280": "$2,183.00"},
        }
        for script, values in fixtures.items():
            with self.subTest(script=script), tempfile.TemporaryDirectory() as temporary:
                root = Path(temporary)
                shutil.copy2(scripts / script, root / script)
                original = json.dumps({"values": values})
                name = "001_bap_basic_policy_al.json"
                for category in ("Basic", "Smoke"):
                    (root / category).mkdir()
                    (root / category / name).write_text(original, encoding="utf-8")
                (root / name).write_text(original, encoding="utf-8")
                result = subprocess.run(
                    ["powershell.exe", "-NoProfile", "-ExecutionPolicy", "Bypass", "-File", str(root / script)],
                    text=True, capture_output=True, timeout=30,
                )
                self.assertEqual(0, result.returncode, result.stdout + result.stderr)
                updated = json.loads((root / "Basic" / name).read_text(encoding="utf-8-sig"))
                for field, value in values.items():
                    self.assertEqual(value[1:], updated["values"][field])
                self.assertEqual(original, (root / "Smoke" / name).read_text(encoding="utf-8"))
                self.assertEqual(original, (root / name).read_text(encoding="utf-8"))


if __name__ == "__main__":
    unittest.main()
