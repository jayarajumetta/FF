import json
from pathlib import Path
import tempfile
import unittest

from basic_scenario_data import cleanup, validate_repository


class BasicScenarioDataTests(unittest.TestCase):
    def setUp(self):
        self.temporary = tempfile.TemporaryDirectory()
        self.root = Path(self.temporary.name)
        self.project = self.root / "tests" / "Example.Tests"
        self.basic = self.project / "TestData" / "Scenarios" / "Basic"
        self.layered = self.project / "TestData" / "Layered"
        self.steps = self.project / "StepDefinitions"
        self.basic.mkdir(parents=True)
        self.layered.mkdir(parents=True)
        self.steps.mkdir(parents=True)
        (self.root / "src" / "InsuranceAutomation.Core").mkdir(parents=True)
        (self.steps / "BasicSteps.cs").write_text(
            'data.GetCanonicalFieldRequired("Address 1"); data.Get("Canonical Alias");', encoding="utf-8"
        )
        self.source = self.basic / "001_basic_policy_al.json"
        self.source.write_text(json.dumps({
            "_meta": {"source": "test"},
            "application": {"url": "https://example.test"},
            "dimensions": {"stateCode": "AL"},
            "values": {"Existing": "ordinary", "Conflict": "ordinary wins"},
            "random": {},
            "external": {},
            "_canonical": {"fields": [
                {"field": "Address 1", "value": "100 Main"},
                {"field": "Canonical Alias", "value": "promoted"},
                {"field": "Conflict", "businessName": "Existing", "value": "canonical loses"},
                {"field": "Unused", "value": "removed"},
            ]},
            "_rawTosca": {"large": "metadata"},
        }, indent=2) + "\n", encoding="utf-8")
        (self.layered / "manifest.json").write_text(json.dumps({
            "entries": {
                self.source.name: {
                    "baseFile": "Layered/Missing/Base.json",
                    "overridesFile": "Layered/Missing/StateOverrides.json",
                    "overrideKey": self.source.name,
                },
                "other.json": {"baseFile": "Layered/Other/Base.json"},
            }
        }, indent=2) + "\n", encoding="utf-8")

    def tearDown(self):
        self.temporary.cleanup()

    def test_cleanup_promotes_referenced_fields_and_removes_only_basic_manifest_entry(self):
        changed = cleanup(self.root)
        self.assertEqual(2, changed)
        document = json.loads(self.source.read_text(encoding="utf-8"))
        self.assertNotIn("_canonical", document)
        self.assertNotIn("_rawTosca", document)
        self.assertEqual("100 Main", document["values"]["Address 1"])
        self.assertEqual("promoted", document["values"]["Canonical Alias"])
        self.assertEqual("ordinary", document["values"]["Existing"])
        self.assertEqual("ordinary wins", document["values"]["Conflict"])
        self.assertNotIn("Unused", document["values"])
        entries = json.loads((self.layered / "manifest.json").read_text(encoding="utf-8"))["entries"]
        self.assertNotIn(self.source.name, entries)
        self.assertIn("other.json", entries)
        self.assertEqual(1, validate_repository(self.root))
        self.assertEqual(0, cleanup(self.root))

    def test_cleanup_preserves_runtime_last_value_for_duplicate_keys(self):
        text = self.source.read_text(encoding="utf-8")
        text = text.replace('"Existing": "ordinary",', '"Existing": "first", "Existing": "ordinary",')
        self.source.write_text(text, encoding="utf-8")

        cleanup(self.root)

        document = json.loads(self.source.read_text(encoding="utf-8"))
        self.assertEqual("ordinary", document["values"]["Existing"])

    def test_cleanup_removes_basic_exclusive_layer(self):
        layer = self.project / "TestData" / "Layered" / "Missing" / "Base.json"
        layer.parent.mkdir(parents=True)
        layer.write_text("{}", encoding="utf-8")

        cleanup(self.root)

        self.assertFalse(layer.exists())
        manifest = json.loads((self.layered / "manifest.json").read_text(encoding="utf-8"))
        self.assertNotIn(self.source.name, manifest["entries"])

    def test_cleanup_refuses_to_remove_layer_shared_with_non_basic_scenario(self):
        layer = self.project / "TestData" / "Layered" / "Missing" / "Base.json"
        layer.parent.mkdir(parents=True)
        layer.write_text("{}", encoding="utf-8")
        manifest_path = self.layered / "manifest.json"
        manifest = json.loads(manifest_path.read_text(encoding="utf-8"))
        manifest["entries"]["other.json"]["baseFile"] = "Layered/Missing/Base.json"
        manifest_path.write_text(json.dumps(manifest, indent=2) + "\n", encoding="utf-8")
        before = self.source.read_bytes()

        with self.assertRaisesRegex(ValueError, "shared with a non-Basic scenario"):
            cleanup(self.root)

        self.assertEqual(before, self.source.read_bytes())
        self.assertTrue(layer.exists())


if __name__ == "__main__":
    unittest.main()
