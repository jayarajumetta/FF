import copy
import json
import tempfile
import unittest
from pathlib import Path

from pldc_smoke_data import (
    PROJECT, VALUE_KEYS, cleanup, is_metadata_cleaned_smoke, is_standalone_smoke,
    load, merge_patch, prune_document, validate_repository, validate_standalone,
)


class SmokeDataTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.root = Path(self.temp.name)
        self.data = self.root / "tests" / PROJECT / "TestData"
        self.document = {
            "_meta": {"note": "retain this"},
            "application": {"url": "https://example.test", "username": "user", "password": "password"},
            "dimensions": {"stateCode": "AL"},
            "values": {**{key: "test" for key in VALUE_KEYS}, "Unused": "remove"},
            "random": {"UnusedRandom": {"pattern": "[0-9]"}},
            "external": {"keep": "unchanged"},
            "_canonical": {"fields": [{"field": "City", "value": "fallback"}]},
            "_rawTosca": {"keepOnlyForWyoming": True},
        }
        self.names = ["211_smoke_test_auto_al.json", "211_smoke_test_auto_wy.json", "181_auto_rate_filings_policy_1_nb_al.json"]
        self.write("Layered/Smoke/Base.json", self.document)
        self.write("Layered/Smoke/StateOverrides.json", {"overrides": {name: {} for name in self.names}})
        entries = {}
        for name in self.names:
            self.write("Scenarios/" + name, self.document)
            entries[name] = {"baseFile": "Layered/Smoke/Base.json", "overridesFile": "Layered/Smoke/StateOverrides.json", "overrideKey": name, "sourceSha256": "unchanged"}
        self.write("Layered/manifest.json", {"schemaVersion": "test", "entries": entries})

    def write(self, relative, document):
        path = self.data / relative
        path.parent.mkdir(parents=True, exist_ok=True)
        path.write_text(json.dumps(document, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
        return path

    def snapshot(self):
        return {p: p.read_bytes() for p in self.data.rglob("*.json")}

    def test_scope_is_project_and_family_specific(self):
        for name in ("211_smoke_test_auto_al.json", "212_smoke_test_cycle_az_ang.json", "215_smoke_test_rv_wi.json", "211_smoke_test_auto_wy.json"):
            self.assertTrue(is_standalone_smoke(PROJECT, name))
            self.assertTrue(is_metadata_cleaned_smoke(PROJECT, name))
            self.assertFalse(is_standalone_smoke("CommercialLines.DuckCreek.Tests", name))
        for name in ("181_auto_rate_filings_policy_1_nb_al.json", "211_smoke_test_cycle_al.json"):
            self.assertFalse(is_standalone_smoke(PROJECT, name))

    def test_cleanup_preserves_values_and_unrelated_files(self):
        before = self.snapshot()
        manifest = load(self.data / "Layered/manifest.json")
        self.assertEqual(3, cleanup(self.root))
        target = self.data / "Scenarios" / self.names[0]
        self.assertEqual(prune_document(self.names[0], self.document), load(target))
        expected = copy.deepcopy(manifest)
        del expected["entries"][self.names[0]]
        del expected["entries"][self.names[1]]
        self.assertEqual(expected, load(self.data / "Layered/manifest.json"))
        wyoming = self.data / "Scenarios" / self.names[1]
        for path, content in before.items():
            if path not in (target, wyoming, self.data / "Layered/manifest.json"):
                self.assertEqual(content, path.read_bytes(), str(path))
        self.assertEqual(2, validate_repository(self.root))

    def test_cleanup_is_idempotent(self):
        cleanup(self.root)
        before = self.snapshot()
        self.assertEqual(0, cleanup(self.root))
        self.assertEqual(before, self.snapshot())

    def test_preflight_failure_does_not_write_any_files(self):
        broken = copy.deepcopy(self.document)
        del broken["values"]["City"]
        self.write("Scenarios/215_smoke_test_rv_al.json", broken)
        before = self.snapshot()
        with self.assertRaisesRegex(ValueError, "Missing string test value: City"):
            cleanup(self.root)
        self.assertEqual(before, self.snapshot())

    def test_unexpected_layered_difference_is_rejected(self):
        changed = copy.deepcopy(self.document)
        changed["values"]["City"] = "different"
        self.write("Scenarios/" + self.names[0], changed)
        before = self.snapshot()
        with self.assertRaisesRegex(ValueError, "Unexpected standalone/layered"):
            cleanup(self.root)
        self.assertEqual(before, self.snapshot())

    def test_wisconsin_spelling_correction_is_preserved(self):
        name = "215_smoke_test_rv_wi.json"
        original = copy.deepcopy(self.document)
        original["values"].update(statename="WISCONSIN", state_44="WISCONSIN")
        self.write("Scenarios/" + name, original)
        overrides = load(self.data / "Layered/Smoke/StateOverrides.json")
        overrides["overrides"][name] = {"values": {"statename": "WISCONSON", "state_44": "WISCONSON"}}
        self.write("Layered/Smoke/StateOverrides.json", overrides)
        manifest = load(self.data / "Layered/manifest.json")
        manifest["entries"][name] = dict(manifest["entries"][self.names[0]], overrideKey=name)
        self.write("Layered/manifest.json", manifest)
        cleanup(self.root)
        self.assertEqual("WISCONSIN", load(self.data / "Scenarios" / name)["values"]["state_44"])

    def test_validation_rejects_metadata_and_layered_routing(self):
        self.assertTrue(validate_standalone(self.document))
        self.write("Scenarios/" + self.names[0], prune_document(self.names[0], self.document))
        with self.assertRaisesRegex(ValueError, "still routes through layered data"):
            validate_repository(self.root)

    def test_wyoming_missing_values_are_normalized(self):
        name = "211_smoke_test_auto_wy.json"
        original = copy.deepcopy(self.document)
        for key in ("First Name", "Last Name", "DOB", "SSN", "Street Address", "Apartment", "City", "ZIP", "State Abbreviation"):
            original["values"].pop(key, None)
        cleaned = prune_document(name, original)
        self.assertEqual("WY", cleaned["values"]["State Abbreviation"])
        self.assertEqual("CASPER", cleaned["values"]["City"])
        self.assertNotIn("_canonical", cleaned)
        self.assertEqual({}, cleaned["external"])

    def test_new_jersey_zip_keeps_leading_zero(self):
        name = "211_smoke_test_auto_nj.json"
        original = copy.deepcopy(self.document)
        original["values"].update({"State Abbreviation": "NJ", "ZIP": "8054"})
        cleaned = prune_document(name, original)
        self.assertEqual("08054", cleaned["values"]["ZIP"])

    def test_connecticut_writing_company_matches_rendered_option(self):
        name = "211_smoke_test_auto_ct.json"
        original = copy.deepcopy(self.document)
        original["values"].update({"State Abbreviation": "CT", "writingcompany_48": "Farm Family Casualty Insurance Co."})
        cleaned = prune_document(name, original)
        self.assertEqual("American National Property And Casualty Co.", cleaned["values"]["writingcompany_48"])

    def test_duplicate_json_keys_are_rejected(self):
        path = self.data / "duplicate.json"
        path.write_text('{"values": {}, "values": {}}', encoding="utf-8")
        with self.assertRaisesRegex(ValueError, "Duplicate JSON key"):
            load(path)

    def test_merge_patch_matches_runtime_null_and_array_semantics(self):
        original = {"values": {"keep": "yes", "remove": "old"}, "array": [1, 2]}
        patch = {"values": {"remove": None}, "array": [3]}
        self.assertEqual({"values": {"keep": "yes"}, "array": [3]}, merge_patch(original, patch))
        self.assertEqual("old", original["values"]["remove"])

    def test_cleanup_preserves_bom_and_crlf(self):
        path = self.data / "Scenarios" / self.names[0]
        path.write_bytes((json.dumps(self.document, indent=2).replace("\n", "\r\n") + "\r\n").encode("utf-8-sig"))
        cleanup(self.root)
        result = path.read_bytes()
        self.assertTrue(result.startswith(b"\xef\xbb\xbf"))
        self.assertNotIn(b"\n", result.replace(b"\r\n", b""))
        self.assertEqual(prune_document(self.names[0], self.document), load(path))


if __name__ == "__main__":
    unittest.main()
