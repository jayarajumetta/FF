from __future__ import annotations
from pathlib import Path
import collections
import hashlib
import json
import re
import sys
import xml.etree.ElementTree as ET

ROOT = Path(__file__).resolve().parents[1]
ERRORS: list[str] = []
STATS: dict[str, object] = {}
APPS = [
    "CommercialLines.DuckCreek.Tests",
    "CommercialLines.ExpertQuote.Tests",
    "PersonalLines.DuckCreek.Tests",
]


def error(message: str) -> None:
    ERRORS.append(message)


def csharp_balance(text: str) -> tuple[int, int, int]:
    """Balance {}, (), [] while ignoring strings, chars and comments."""
    braces = parens = brackets = 0
    i = 0
    state = "code"
    while i < len(text):
        c = text[i]
        n = text[i + 1] if i + 1 < len(text) else ""
        if state == "code":
            if c == '/' and n == '/': state = "line"; i += 2; continue
            if c == '/' and n == '*': state = "block"; i += 2; continue
            if c == '@' and n == '"': state = "verbatim"; i += 2; continue
            if c == '"': state = "string"; i += 1; continue
            if c == "'": state = "char"; i += 1; continue
            if c == '{': braces += 1
            elif c == '}': braces -= 1
            elif c == '(': parens += 1
            elif c == ')': parens -= 1
            elif c == '[': brackets += 1
            elif c == ']': brackets -= 1
            if braces < 0 or parens < 0 or brackets < 0:
                return braces, parens, brackets
            i += 1; continue
        if state == "line":
            if c == '\n': state = "code"
            i += 1; continue
        if state == "block":
            if c == '*' and n == '/': state = "code"; i += 2; continue
            i += 1; continue
        if state == "string":
            if c == '\\': i += 2; continue
            if c == '"': state = "code"
            i += 1; continue
        if state == "verbatim":
            if c == '"' and n == '"': i += 2; continue
            if c == '"': state = "code"
            i += 1; continue
        if state == "char":
            if c == '\\': i += 2; continue
            if c == "'": state = "code"
            i += 1; continue
    return braces, parens, brackets


# Package shape
features = list(ROOT.glob("tests/*/Features/*.feature"))
STATS["featureCount"] = len(features)
if len(features) != 32:
    error(f"Expected 32 feature files, found {len(features)}")

# JSON validity
json_count = 0
for p in ROOT.rglob("*.json"):
    json_count += 1
    try:
        json.loads(p.read_text(encoding="utf-8"))
    except Exception as ex:
        error(f"Invalid JSON {p.relative_to(ROOT)}: {ex}")
STATS["jsonCount"] = json_count

# Project XML validity
for p in ROOT.rglob("*.csproj"):
    try:
        ET.parse(p)
    except Exception as ex:
        error(f"Invalid project XML {p.relative_to(ROOT)}: {ex}")

# C# delimiter integrity and catch-all bindings
cs_files = list(ROOT.rglob("*.cs"))
for p in cs_files:
    text = p.read_text(encoding="utf-8", errors="ignore")
    b, pa, br = csharp_balance(text)
    if (b, pa, br) != (0, 0, 0):
        error(f"C# delimiter imbalance {p.relative_to(ROOT)}: braces={b} parens={pa} brackets={br}")
    if p.name.endswith("Steps.cs") and "^(.*)$" in text:
        error(f"Catch-all ReqnRoll binding in {p.relative_to(ROOT)}")
STATS["csharpFiles"] = len(cs_files)

# Locator repository integrity for all applications
locator_summary = {}
for app in APPS:
    app_root = ROOT / "tests" / app
    locator_dir = app_root / "Pages" / "Locators"
    defined: set[str] = set()
    factory_methods: set[str] = set()
    prop_count = 0
    expr_count = 0
    file_hashes: dict[str, list[str]] = collections.defaultdict(list)
    for p in locator_dir.glob("*.cs"):
        text = p.read_text(encoding="utf-8", errors="ignore")
        file_hashes[hashlib.sha256(p.read_bytes()).hexdigest()].append(p.name)
        pairs = re.findall(r"public\s+ILocator\s+(\w+)\s*=>\s*(.*?);", text, re.S)
        names = [n for n, _ in pairs]
        defined.update(names)
        factory_methods.update(re.findall(r"public\s+ILocator\s+(\w+)\s*\(", text))
        prop_count += len(pairs)
        duplicate_names = [n for n, c in collections.Counter(names).items() if c > 1]
        if duplicate_names:
            error(f"{app}/{p.name}: duplicate locator names {duplicate_names}")
        expressions = [re.sub(r"\s+", " ", e.strip()) for _, e in pairs]
        duplicates = [e for e, c in collections.Counter(expressions).items() if c > 1]
        expr_count += len(expressions)
        if duplicates:
            error(f"{app}/{p.name}: {len(duplicates)} duplicate locator expressions")
        aliases = [(a, b) for a, b in re.findall(r"public\s+ILocator\s+(\w+)\s*=>\s*(\w+)\s*;", text) if a != b and b in defined]
        if aliases:
            error(f"{app}/{p.name}: simple locator aliases remain {aliases[:5]}")
        if 'Locator("")' in text or "Locator(string.Empty)" in text or "undefined" in text.lower():
            error(f"{app}/{p.name}: empty/undefined locator detected")
    duplicate_files = [v for v in file_hashes.values() if len(v) > 1]
    if duplicate_files:
        error(f"{app}: byte-identical locator files {duplicate_files}")
    # Resolve every Page locator field against its declared locator class. Do not use an app-wide
    # union: that can hide compile errors when a member exists in a different locator class.
    locator_classes: dict[str, set[str]] = {}
    for locator_file in locator_dir.glob("*.cs"):
        locator_text = locator_file.read_text(encoding="utf-8", errors="ignore")
        class_match = re.search(r"public\s+sealed\s+class\s+(\w+Locators)", locator_text)
        if not class_match:
            continue
        members = set(re.findall(r"public\s+ILocator\s+(\w+)\s*(?:=>|\{|\()", locator_text))
        locator_classes[class_match.group(1)] = members

    missing_occurrences: list[str] = []
    for page_file in (app_root / "Pages").glob("*Page.cs"):
        page_text = page_file.read_text(encoding="utf-8", errors="ignore")
        fields = {
            variable: class_name
            for class_name, variable in re.findall(
                r"private\s+readonly\s+(\w+Locators)\s+(\w+)\s*;", page_text
            )
        }
        for variable, class_name in fields.items():
            members = locator_classes.get(class_name)
            if members is None:
                error(f"{app}/{page_file.name}: locator class {class_name} was not found")
                continue
            refs = re.findall(rf"{re.escape(variable)}\.(\w+)", page_text)
            for ref in refs:
                if ref not in members:
                    missing_occurrences.append(f"{page_file.name}:{variable}.{ref}->{class_name}")
    if missing_occurrences:
        error(f"{app}: Page references missing locator members {missing_occurrences[:20]}")
    locator_summary[app] = {
        "properties": prop_count,
        "expressions": expr_count,
        "missingReferences": len(missing_occurrences),
    }
STATS["locators"] = locator_summary

# CLDC technical locator contract
cldc_loc = ROOT / "tests" / "CommercialLines.DuckCreek.Tests" / "Pages" / "Locators"
cldc_text = "\n".join(p.read_text(encoding="utf-8", errors="ignore") for p in cldc_loc.glob("*.cs"))
if "CanonicalDuckCreek" in cldc_text:
    error("CLDC canonical locator indirection remains")
if "GetByRole(AriaRole.Textbox" in cldc_text:
    error("CLDC role+textbox locator remains")
proposal = (cldc_loc / "ProposalLocators.cs").read_text(encoding="utf-8")
for selector in [
    'input[fieldref=\\"PolicyInput.EffectiveDate\\"]',
    'input[fieldref=\\"data.VersionIDPages\\"]',
]:
    if selector not in proposal:
        error(f"CLDC Proposal missing technical selector {selector}")
if 'GetByRole(AriaRole.Link, new() { Name = "Start", Exact = true })' not in proposal:
    error("CLDC Proposal Start must use raw Tag=A link semantics, not inferred fieldref")

# Dropdown and verification contracts
component_actions = (ROOT / "src" / "InsuranceAutomation.Core" / "ComponentAwareControlActions.cs").read_text(encoding="utf-8")
for token in ["TrySelectNativeAsync", "TryChooseRenderedOptionAsync", "CanCommitWithEnterAsync", 'PressAsync("Enter")']:
    if token not in component_actions:
        error(f"Dropdown contract missing {token}")
ui_actions = (ROOT / "src" / "InsuranceAutomation.Core" / "UiActions.cs").read_text(encoding="utf-8")
for token in ['propertySpec.StartsWith("Regex:"', 'propertySpec.StartsWith("NotEqual:"', "captureProperty = captureProperty[6..]", "captureProperty = captureProperty[9..]"]:
    if token not in ui_actions:
        error(f"Verification property-mode contract missing {token}")

# Smoke description capture/verification before sign-out
smoke_features = list((ROOT / "tests" / "CommercialLines.DuckCreek.Tests" / "Features").glob("*Smoke*.feature"))
smoke_steps = list((ROOT / "tests" / "CommercialLines.DuckCreek.Tests" / "StepDefinitions").glob("*SmokeTestSteps.cs"))
if len(smoke_features) != 7 or len(smoke_steps) != 7:
    error(f"Expected 7 CLDC smoke features/step files, found {len(smoke_features)}/{len(smoke_steps)}")
smoke_rows = 0
for p in smoke_features:
    text = p.read_text(encoding="utf-8")
    verify = text.find("I navigate to Policy Info and Verify Desc")
    signout = text.find("I sign out of the application for logged in user")
    if verify < 0 or signout < 0 or verify > signout:
        error(f"{p.name}: description verification must be present before sign-out")
    in_examples = False; header_seen = False
    for line in text.splitlines():
        s = line.strip()
        if s == "Examples:": in_examples = True; header_seen = False; continue
        if in_examples and s.startswith("|"):
            if not header_seen: header_seen = True
            else: smoke_rows += 1
        elif in_examples and s and not s.startswith("#"):
            in_examples = False
for p in smoke_steps:
    text = p.read_text(encoding="utf-8")
    for token in ["BuildQuoteDescription()", "CaptureDescriptionOfSpecifiedOperationAsync", "VerifyDescriptionOfSpecifiedOperationAsync"]:
        if token not in text:
            error(f"{p.name}: missing description contract {token}")
if smoke_rows != 186:
    error(f"Expected 186 CLDC smoke state variants, found {smoke_rows}")
STATS["cldcSmokeVariants"] = smoke_rows

# Test-data table references and state dimensions
example_rows = 0
referenced_data: set[Path] = set()
for app in APPS:
    app_root = ROOT / "tests" / app
    for feature in (app_root / "Features").glob("*.feature"):
        header = None
        for line in feature.read_text(encoding="utf-8").splitlines():
            s = line.strip()
            if not s.startswith("|"):
                continue
            cells = [c.strip() for c in s.strip("|").split("|")]
            low = [c.lower() for c in cells]
            if "datafile" in low:
                header = low
                continue
            if header is None or len(cells) != len(header):
                continue
            row = dict(zip(header, cells)); example_rows += 1
            data_file = row.get("datafile", "")
            if not data_file:
                continue
            path = app_root / data_file
            referenced_data.add(path.resolve())
            if not path.exists():
                error(f"{feature.name}: missing data file {data_file}")
                continue
            obj = json.loads(path.read_text(encoding="utf-8"))
            dims = obj.get("dimensions", {})
            checks = [
                ("stateCode", row.get("statecode", ""), str(dims.get("stateCode", ""))),
                ("stateVariant", row.get("statevariant", ""), str(dims.get("stateVariant", ""))),
                ("stateName", row.get("statename", ""), str(dims.get("state", ""))),
            ]
            for label, expected, actual in checks:
                if expected and actual and expected.casefold() != actual.casefold():
                    error(f"{feature.name}/{data_file}: {label} row='{expected}' json='{actual}'")
STATS["dataFileExampleRows"] = example_rows

# All scenario data is referenced; CLDC layered smoke files are runtime-referenced by convention.
for app in APPS:
    app_root = ROOT / "tests" / app
    runtime_referenced = set(referenced_data)
    if app == "CommercialLines.DuckCreek.Tests":
        runtime_referenced.update(p.resolve() for p in (app_root / "TestData" / "Smoke").glob("*.json"))
        runtime_referenced.add((app_root / "TestData" / "ExternalDataOverrides.json").resolve())
    else:
        ext = app_root / "TestData" / "ExternalDataOverrides.json"
        if ext.exists(): runtime_referenced.add(ext.resolve())
    all_data = list((app_root / "TestData").rglob("*.json"))
    orphan = [p for p in all_data if p.resolve() not in runtime_referenced]
    if orphan:
        error(f"{app}: unreferenced runtime test-data files: {[str(p.relative_to(app_root)) for p in orphan[:10]]}")
    hashes: dict[str, list[Path]] = collections.defaultdict(list)
    for p in all_data:
        hashes[hashlib.sha256(p.read_bytes()).hexdigest()].append(p)
    duplicate_groups = [g for g in hashes.values() if len(g) > 1]
    if duplicate_groups:
        error(f"{app}: exact duplicate test-data files detected ({len(duplicate_groups)} groups)")

# No credentials in source
secret_patterns = [
    re.compile(r'\bpassword\s*=\s*"[^"\r\n]+"', re.I),
    re.compile(r'\busername\s*=\s*"[^"\r\n]+"', re.I),
]
for p in list(ROOT.rglob("*.cs")) + list(ROOT.rglob("*.ps1")) + list(ROOT.rglob("*.yml")):
    text = p.read_text(encoding="utf-8", errors="ignore")
    if p.name == "credentials.example.ps1":
        continue
    for pattern in secret_patterns:
        if pattern.search(text):
            error(f"Possible hardcoded credential in {p.relative_to(ROOT)}")
            break

# Client package must not contain release-history clutter.
for forbidden in ["Artifacts", "generated", "docs"]:
    if (ROOT / forbidden).exists():
        error(f"Client package contains non-runtime folder: {forbidden}")
versioned_readmes = list(ROOT.glob("README_V*.md")) + list(ROOT.glob("README_FINAL.md"))
if versioned_readmes:
    error(f"Client package contains historical README files: {[p.name for p in versioned_readmes]}")

# V65 Duck Creek DOM evidence contract
if re.search(r'\ba\[fieldref=', cldc_text):
    error("CLDC action/link locator still infers fieldref from DuckCreekId")
if re.search(r'\bdiv\[fieldref=', cldc_text):
    error("CLDC display DIV locator still infers fieldref from DuckCreekId")
for match in re.finditer(r'(?:input|textarea|select)\[fieldref=\\"([^\"]+)\\"', cldc_text):
    if "." not in match.group(1):
        error(f"CLDC input fieldref is not a technical data-binding identifier: {match.group(1)}")
if re.search(r'\[id=\\"f_[^\"]+-inputEl\\"\]|\[id=\\"ext-element-\d+\\"\]', cldc_text):
    error("CLDC generated ExtJS/runtime id remains as a technical locator")
login = (cldc_loc / "LoginLocators.cs").read_text(encoding="utf-8")
if 'GetByRole(AriaRole.Link, new() { Name = "Login", Exact = true })' not in login:
    error("CLDC Login must use raw Tag=A link semantics")
if 'username-inputEl' not in login or 'password-inputEl' not in login:
    error("CLDC login username/password stable raw HTML ids are missing")

# V66 CLDC direct input/checkbox fieldref contract
cldc_project_text = "\n".join(
    p.read_text(encoding="utf-8", errors="ignore")
    for p in (ROOT / "tests" / "CommercialLines.DuckCreek.Tests").rglob("*.cs")
)
if "InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel" in cldc_project_text:
    error("CLDC still delegates control construction to LocatorResolution.ByAssociatedLabel")
if "data-fieldref" in cldc_project_text:
    error("CLDC still contains unsupported data-fieldref alternatives")
if re.search(r'Locator\("\[fieldref=', cldc_text):
    error("CLDC generic fieldref selector remains without an actual element tag")
client_search = (cldc_loc / "ClientSearchLocators.cs").read_text(encoding="utf-8")
required_client_fieldrefs = {
    "NamedInsuredIndividualEnterSSN": "AccountSSNRetrievalInput.SSNInput",
    "AddAssociatedClientEnterSSN": "AssociatedClientSSNRetrievalInput.SSNInput",
    "QuickQuote": "PolicyOutputNonShredded.QuoteQuick",
}
for control, fieldref in required_client_fieldrefs.items():
    expected = f'public ILocator {control} => _page.Locator("input[fieldref=\\"{fieldref}\\"]")'
    if expected not in client_search:
        error(f"CLDC ClientSearch {control} is not a direct input fieldref locator")
role_checkbox_names = re.findall(
    r'public\s+ILocator\s+(\w+)\s*=>\s*_page\.GetByRole\(AriaRole\.Checkbox',
    cldc_text,
)
if role_checkbox_names != ["NoKnownLosses", "NoKnownLosses"]:
    error(f"Unexpected CLDC role checkbox locators remain: {role_checkbox_names}")
coverages = (cldc_loc / "CoveragesLocators.cs").read_text(encoding="utf-8")
if 'public ILocator PolicyCoverage => _page.Locator("input[fieldref=\\"PropertyPolicyInput.PolicyCoverage\\"]")' not in coverages:
    error("CLDC Coverages.PolicyCoverage is not mapped to PropertyPolicyInput.PolicyCoverage")
navigation = (cldc_loc / "NavigationLocators.cs").read_text(encoding="utf-8")
required_navigation_fieldrefs = [
    "RiskDriveOtherCarIteratorInput.FirstName",
    "RiskDriveOtherCarIteratorInput.LastName",
    "UmbrellaCommercialAutoInput.EffectiveDate",
    "UmbrellaGeneralLiabilityInput.ExpirationDate",
    "UmbrellaCommercialAutoInput.PolicyNumber",
    "UmbrellaGeneralLiabilityInput.PolicyNumber",
    "UmbrellaGeneralLiabilityInputPremiums.TotalSubjectPremium",
    "UmbrellaSFP10LiabilityInput.LiabilityLimit",
]
for fieldref in required_navigation_fieldrefs:
    if f'input[fieldref=\\"{fieldref}\\"]' not in navigation:
        error(f"CLDC Navigation missing context-specific input fieldref {fieldref}")
for fieldref in [
    "AssociatedClientInput.FirstName",
    "AssociatedClientInput.MiddleName",
    "AssociatedClientInput.LastName",
    "AssociatedClientInput.Address1",
    "AssociatedClientInput.ZipCode",
    "AssociatedClientInput.Gender",
]:
    if f'input[fieldref=\\"{fieldref}\\"]' not in client_search:
        error(f"CLDC ClientSearch multi-context fieldref missing {fieldref}")

STATS["cldcFieldrefLocators"] = {
    "directInput": len(re.findall(r'input\[fieldref=\\"', cldc_text)),
    "directTextarea": len(re.findall(r'textarea\[fieldref=\\"', cldc_text)),
    "fieldrefLabelRelationships": len(re.findall(r'public\s+ILocator\s+\w+\s*=>\s*_page\.Locator\("xpath=.*?@fieldref=', cldc_text)),
    "roleCheckboxesWithoutRawFieldref": len(role_checkbox_names),
}

result = {"status": "PASS" if not ERRORS else "FAIL", "errors": ERRORS, "stats": STATS}
print(json.dumps(result, indent=2))
sys.exit(1 if ERRORS else 0)
