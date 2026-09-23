using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using NUnit.Framework;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.QuoteHandoffs;
using PnCTestAutomation.Products;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public sealed class SgsScenarioDataTests
{
    private const string CleqSmoke = @"TestData\Scenarios\Smoke\03_eq_bop_smoke_test_al.json";
    private const string PldcSmoke = @"TestData\Scenarios\Smoke\211_smoke_test_auto_az_ang.json";

    [Test]
    public void ReviewedBopInputsUseApprovedScenarioDateAndPreserveSourcePayload()
    {
        var context = new ScenarioContextData();
        var root = Path.Combine(FindRepositoryRoot(), "Resources");
        var path = Path.Combine(root, "SGS", "CommercialLines.ExpertQuote", CleqSmoke);
        var before = SHA256.HashData(File.ReadAllBytes(path));
        var data = new SgsScenarioData(context, new ScenarioQuoteHandoff(context), new SgsScenarioDataOptions
        {
            ResourcesRootPath = root,
            TimeProvider = new FixedTimeProvider()
        });
        ExpertQuoteBopSmokeInputs.Load(data, context, ExpertQuoteBopSmokeInputs.Profile, ExpertQuoteBopSmokeInputs.ExternalProfile);
        Assert.Multiple(() =>
        {
            Assert.That(context.Policy.EffectiveDate, Is.EqualTo("09/22/2026"));
            Assert.That(context.Client.FirstName, Does.Match("^BOP [a-z]{3}$"));
            Assert.That(context.Client.LastName, Does.Match("^Smoke[a-z]{4}$"));
            Assert.That(data.GenerateRandom("FirstName"), Is.EqualTo(context.Client.FirstName));
            Assert.That(context.Client.Email, Does.Match("^test@[a-z]{4}\\.com$"));
            Assert.That(context.Client.SSN, Does.Match("^025[0-9]{6}$"));
            Assert.That(context.Client.Phone, Does.Match("^\\(3[0-9]{2}\\) [0-9]{3}-[0-9]{4}$"));
            Assert.That(context.Address.State, Is.EqualTo("Alabama"));
            Assert.That(context.Client.MiddleName, Is.Empty);
            Assert.That(SHA256.HashData(File.ReadAllBytes(path)), Is.EqualTo(before));
        });
    }

    [TestCase("([a-z]+)+")]
    [TestCase("[a-z]{0}")]
    [TestCase("[a-z]{129}")]
    [TestCase("[a-z]{999999999}")]
    [TestCase("[^a-z]{3}")]
    [TestCase("PLACEHOLDER.*")]
    public void UnsupportedSourceRandomPatternsFailWithoutFallback(string pattern)
    {
        using var fixture = new DataFixture();
        fixture.Add("profile.json", JsonSerializer.Serialize(new
        {
            values = new { state = "AL" },
            random = new { FirstName = new { pattern } }
        }));
        var data = fixture.Load();
        Assert.Throws<SgsScenarioDataException>(() => data.GenerateRandom("FirstName"));
    }

    [Test]
    public void SourceGenerationCannotInventQuotesOrReplaceOwnedIdentity()
    {
        using var fixture = new DataFixture();
        fixture.Add("profile.json", """
            {"values":{},"random":{"FirstName":{"pattern":"BOP [a-z]{3}"},"QuoteNumber":{"pattern":"[0-9]{8}"}}}
            """);
        var context = new ScenarioContextData { ClientFirstName = "Already owned" };
        var data = fixture.Load(context);
        Assert.Throws<SgsScenarioDataException>(() => data.GenerateRandom("FirstName"));
        Assert.Throws<SgsScenarioDataException>(() => data.GenerateRandom("QuoteNumber"));
        Assert.That(context.ClientFirstName, Is.EqualTo("Already owned"));
        Assert.That(context.QuoteNumber, Is.Null.Or.Empty);
    }

    [Test]
    public void SourceRandomValuesAreReusedButCannotRegenerateIdentityAfterReload()
    {
        using var fixture = new DataFixture();
        fixture.Add("profile.json", """
            {"values":{},"random":{"FirstName":{"pattern":"BOP [a-z]{3}"},"OwnerPhone":{"pattern":"3[0-9]{9}"}}}
            """);
        var first = new ScenarioContextData();
        var second = new ScenarioContextData();
        var data = fixture.Load(first);
        var other = fixture.Load(second);
        var generated = data.GenerateRandom("FirstName");
        Assert.That(data.GenerateRandom("firstname"), Is.EqualTo(generated));
        Assert.That(second.ClientFirstName, Is.Null.Or.Empty);
        Assert.That(other.GenerateRandom("OwnerPhone"), Does.Match("^3[0-9]{9}$"));
        Assert.That(first.ClientPhoneNumber, Is.Null.Or.Empty);
        data.Load(new("CLEQ", @"TestData\profile.json"));
        Assert.Throws<SgsScenarioDataException>(() => data.GenerateRandom("FirstName"));
        Assert.That(first.ClientFirstName, Is.EqualTo(generated));
    }

    [TestCase("Username")]
    [TestCase("Password")]
    [TestCase("QuoteNumber")]
    [TestCase("ProposalNumber")]
    [TestCase("MissingName")]
    public void SourceGenerationRejectsCredentialsAuthoritativeIdentitiesAndAbsentDeclarations(string name)
    {
        using var fixture = new DataFixture();
        fixture.Add("profile.json", """{"values":{},"random":{}}""");
        Assert.Throws<SgsScenarioDataException>(() => fixture.Load().GenerateRandom(name));
    }

    [Test]
    public void RealCleqAlSmokeUsesImportedInputsNotProvenance()
    {
        var context = new ScenarioContextData();
        var data = RealAdapter(context);
        data.Load(new SgsScenarioDataRequest("CLEQ", CleqSmoke, "AL", @"TestData\ExternalDataOverrides.json"));
        Assert.DoesNotThrow(() => data.ValidateRequiredInputs(
        [
            "values.customer_dateofbirth", "values.street_address_18", "values.city_20",
            "values.state_21", "values.zip_22", "values.individual_31",
            "values.individual_dba", "values.effective_date", "values.new_account_address",
            "values.agentpc", "values.prequalification_51", "values.prequalification_64"
        ]));
        Assert.Multiple(() =>
        {
            Assert.That(data.GetRequired("values.state"), Is.EqualTo("AL"));
            Assert.That(data.GetRequired("dimensions.state"), Is.EqualTo("Alabama"));
            Assert.That(data.GetRequired("values.effective_date"), Is.EqualTo("03-01-2025"));
            Assert.That(context.SgsData.IsLoaded, Is.True);
            Assert.That(context.SgsData.ProductCode, Is.EqualTo("CLEQ"));
            Assert.That(context.SgsData.StateVariant, Is.EqualTo("AL"));
            Assert.That(data.TryGetOptional("EffDate", out var absent), Is.False);
            Assert.That(absent, Is.Null);
            Assert.Throws<SgsScenarioDataException>(() => data.GetRequired("state"));
            Assert.Throws<SgsScenarioDataException>(() => data.GetRequired("application.password"));
        });
    }

    [TestCase(@"TestData\Scenarios\Smoke\211_smoke_test_auto_az_ang.json", "AZ ANG", "AZ")]
    [TestCase(@"TestData\Scenarios\Smoke\211_smoke_test_auto_az_anp.json", "AZ ANP", "AZ")]
    [TestCase(@"TestData\Scenarios\181_auto_rate_filings_policy_1_nb_az_ang.json", "AZ ANG", "AZ")]
    public void RealPlVariantsRetainBusinessStateAndReuseIdentity(string profile, string variant, string state)
    {
        var context = new ScenarioContextData();
        var data = RealAdapter(context);
        data.Load(new SgsScenarioDataRequest("PLDC", profile, variant));
        Assert.DoesNotThrow(() => data.ValidateRequiredInputs(
        [
            "values.First Name", "values.Last Name", "values.DOB", "values.SSN",
            "values.txt_best_phone_account_owner_18", "values.txt_email_account_owner_19"
        ]));
        Assert.Multiple(() =>
        {
            Assert.That(data.GetRequired("values.state"), Is.EqualTo(state));
            Assert.That(context.SgsData.StateVariant, Is.EqualTo(variant));
            Assert.That(data.GetRequired("values.First Name") == context.ClientFirstName, Is.True);
            Assert.That(data.GetRequired("values.Last Name") == context.ClientLastName, Is.True);
            Assert.That(data.GetRequired("values.DOB") == context.ClientDOB, Is.True);
            Assert.That(data.GetRequired("values.SSN") == context.SSN, Is.True);
        });
    }

    [Test]
    public void RealPlExternalPlaceholdersDoNotSilentlyFallBackToProfile()
    {
        var data = RealAdapter(new ScenarioContextData());
        data.Load(new SgsScenarioDataRequest("PLDC", PldcSmoke, "AZ ANG", @"TestData\ExternalDataOverrides.json"));
        Assert.DoesNotThrow(() => data.ValidateRequiredInputs(["dimensions.stateCode", "dimensions.productCode"]));
        Assert.Throws<SgsScenarioDataException>(() => data.GetRequired("values.State Abbreviation"));
    }

    [Test]
    public void RealCldcProfileIsProductScoped()
    {
        var data = RealAdapter(new ScenarioContextData());
        data.Load(new SgsScenarioDataRequest("CLDC", @"TestData\Scenarios\Smoke\012_bap_smoke_test_al.json", "AL"));
        Assert.That(data.GetRequired("values.state"), Is.EqualTo("AL"));
    }

    [TestCase(@"TestData\Scenarios\Smoke\03_eq_bop_smoke_test_al.json")]
    [TestCase(@"tests\CommercialLines.ExpertQuote.Tests\TestData\Scenarios\Smoke\03_eq_bop_smoke_test_al.json")]
    [TestCase(@"Resources\SGS\CommercialLines.ExpertQuote\TestData\Scenarios\Smoke\03_eq_bop_smoke_test_al.json")]
    public void ExplicitSourceAndDestinationRelativePathsResolveToSameProduct(string path)
    {
        var data = RealAdapter(new ScenarioContextData());
        data.Load(new SgsScenarioDataRequest("CLEQ", path, "AL"));
        Assert.That(data.GetRequired("values.state"), Is.EqualTo("AL"));
    }

    [Test]
    public void VerifiedLayersStatePatchExternalPatchAndRuntimeOverridesHaveExplicitPrecedence()
    {
        using var fixture = new DataFixture();
        fixture.Add("profile.json", """
            {
              "values": {
                "winner": "profile", "profileOnly": "preserved",
                "nested": { "keep": "retained", "remove": "obsolete", "change": "base" },
                "array": [1, 2], "obsolete": "delete"
              }
            }
            """);
        fixture.Add("layer.json", """{"values":{"winner":"layer","layerOnly":"retained","nested":{"change":"layer"}}}""");
        fixture.Add("states.json", """
            {"overrides":{"AL":{"dimensions":{"stateVariant":"AL"},"values":{"winner":"state","stateOnly":"retained"}}}}
            """);
        fixture.Add("external.json", """
            {"values":{"winner":{"value":"external","replaceRequired":true,"note":"test wrapper"},
              "externalOnly":"retained","nested":{"remove":null,"change":"external"},"array":[3],"obsolete":null}}
            """);
        var overrides = new Dictionary<string, string?> { ["winner"] = "runtime", ["runtimeOnly"] = "{{data:profileOnly}}" };
        var data = fixture.Adapter();
        var request = new SgsScenarioDataRequest("CLEQ", @"TestData\profile.json");
        data.Load(request);
        Assert.That(data.GetRequired("winner"), Is.EqualTo("profile"));
        request = request with { LayerPaths = [@"TestData\layer.json"] };
        data.Load(request);
        Assert.That(data.GetRequired("winner"), Is.EqualTo("layer"));
        request = request with { StateVariant = "AL", StateOverridesPath = @"TestData\states.json" };
        data.Load(request);
        Assert.That(data.GetRequired("winner"), Is.EqualTo("state"));
        request = request with { ExternalDataPath = @"TestData\external.json" };
        data.Load(request);
        Assert.That(data.GetRequired("winner"), Is.EqualTo("external"));
        data.Load(new SgsScenarioDataRequest("CLEQ", @"TestData\profile.json", "AL", @"TestData\external.json", overrides)
        {
            LayerPaths = [@"TestData\layer.json"],
            StateOverridesPath = @"TestData\states.json"
        });
        overrides["winner"] = "caller mutation must not alter loaded input";

        Assert.Multiple(() =>
        {
            Assert.That(data.GetRequired("winner"), Is.EqualTo("runtime"));
            Assert.That(data.GetRequired("profileOnly"), Is.EqualTo("preserved"));
            Assert.That(data.GetRequired("layerOnly"), Is.EqualTo("retained"));
            Assert.That(data.GetRequired("stateOnly"), Is.EqualTo("retained"));
            Assert.That(data.GetRequired("externalOnly"), Is.EqualTo("retained"));
            Assert.That(data.GetRequired("runtimeOnly"), Is.EqualTo("preserved"));
            Assert.That(data.GetRequired("values.nested.keep"), Is.EqualTo("retained"));
            Assert.That(data.GetRequired("values.nested.change"), Is.EqualTo("external"));
            Assert.That(data.TryGetOptional("values.nested.remove", out _), Is.False);
            Assert.That(data.TryGetOptional("obsolete", out _), Is.False);
            Assert.Throws<SgsScenarioDataException>(() => data.GetRequired("array"));
        });
    }

    [Test]
    public void MergePatchReplacesNonObjectsAndRuntimeNullDeletesAnInput()
    {
        using var fixture = new DataFixture();
        fixture.Add("profile.json", """{"values":{"node":"before","remove":"before","flag":true,"count":0}}""");
        fixture.Add("external.json", """{"values":{"node":{"child":"after"}}}""");
        var data = fixture.Adapter();
        data.Load(new SgsScenarioDataRequest("CLEQ", @"TestData\profile.json",
            ExternalDataPath: @"TestData\external.json",
            RuntimeOverrides: new Dictionary<string, string?> { ["remove"] = null }));
        Assert.Multiple(() =>
        {
            Assert.That(data.GetRequired("node.child"), Is.EqualTo("after"));
            Assert.That(data.GetRequired("count"), Is.EqualTo("0"));
            Assert.That(data.GetRequired("flag"), Is.EqualTo("true"));
            Assert.That(data.TryGetOptional("node", out _), Is.False);
            Assert.That(data.TryGetOptional("remove", out _), Is.False);
        });
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\"\"")]
    [TestCase("SYNTHETIC_REPLACE_ME")]
    [TestCase("PLACEHOLDER")]
    [TestCase("REPLACE_ME")]
    [TestCase("TODO")]
    [TestCase("<stateVariant>")]
    [TestCase("prefix-SYNTHETIC_REPLACE_ME-suffix")]
    public void OnlyUsedValuesAreValidatedButInvalidPresentValuesNeverBecomeOptionalSuccess(string invalid)
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new Dictionary<string, object?> { ["unused"] = invalid, ["approved"] = "usable", ["nullValue"] = null });
        var data = fixture.Load();
        Assert.Multiple(() =>
        {
            Assert.That(data.GetRequired("approved"), Is.EqualTo("usable"));
            Assert.That(data.TryGetOptional("absent", out var optional), Is.False);
            Assert.That(optional, Is.Null);
            Assert.Throws<SgsScenarioDataException>(() => data.ValidateRequiredInputs(["unused"]));
            Assert.Throws<SgsScenarioDataException>(() => data.TryGetOptional("unused", out _));
            Assert.Throws<SgsScenarioDataException>(() => data.GetRequired("nullValue"));
            Assert.Throws<SgsScenarioDataException>(() => data.GetRequired("missing"));
            Assert.Throws<SgsScenarioDataException>(() => data.ResolveRequired(invalid));
        });
    }

    [Test]
    public void AmbiguousLeafAliasesRequireExplicitQualifiedPathsEvenWhenValuesMatch()
    {
        using var fixture = new DataFixture();
        fixture.Add("profile.json", """
            {"dimensions":{"state":"AL"},"values":{"state":"AL","insured":{"city":"same"},"risk":{"city":"same"}}}
            """);
        var data = fixture.Load();
        Assert.Multiple(() =>
        {
            Assert.Throws<SgsScenarioDataException>(() => data.GetRequired("city"));
            Assert.Throws<SgsScenarioDataException>(() => data.TryGetOptional("state", out _));
            Assert.That(data.GetRequired("values.insured.city"), Is.EqualTo("same"));
            Assert.That(data.GetRequired("values.risk.city"), Is.EqualTo("same"));
            Assert.That(data.GetRequired("dimensions.state"), Is.EqualTo("AL"));
        });
    }

    [TestCase("""{"values":{"a.b":"one","a":{"b":"two"}}}""")]
    [TestCase("""{"values":{"a.b":"one","a":"two"}}""")]
    [TestCase("""{"values":{"key":"one","KEY":"two"}}""")]
    [TestCase("""{"values":{"dimensions.state":"one"},"dimensions":{"state":"AL"}}""")]
    public void StructuralKeyCollisionsAreRejectedAtLoad(string json)
    {
        using var fixture = new DataFixture();
        fixture.Add("profile.json", json);
        Assert.Throws<SgsScenarioDataException>(() => fixture.Load());
    }

    [Test]
    public void RuntimeOverrideAliasesCannotCollideOrChooseAmbiguousInputs()
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { key = "before" });
        var data = fixture.Adapter();
        Assert.Throws<SgsScenarioDataException>(() => data.Load(new SgsScenarioDataRequest(
            "CLEQ", @"TestData\profile.json", RuntimeOverrides: new Dictionary<string, string?>
            {
                ["key"] = "one",
                ["values.key"] = "two"
            })));
    }

    [Test]
    public void ExpressionsResolveNestedDataBuffersEnvironmentAndSourceTextFunctions()
    {
        using var fixture = new DataFixture();
        var environmentName = "PNC_SGS_TEST_" + Guid.NewGuid().ToString("N");
        fixture.AddValues(new { value = "retained", link = "{{data:value}}", decorated = "{STRINGTOUPPER[{{external:link}}]}" });
        var data = fixture.Load();
        data.CaptureBuffer("QNum", "sample)");
        Environment.SetEnvironmentVariable(environmentName, "external-test-value");
        try
        {
            Assert.Multiple(() =>
            {
                Assert.That(data.GetRequired("decorated"), Is.EqualTo("RETAINED"));
                Assert.That(data.ResolveRequired("{PL[value]}"), Is.EqualTo("retained"));
                Assert.That(data.ResolveRequired("{STRINGTOUPPER[{B[QNum]}]}"), Is.EqualTo("SAMPLE)"));
                Assert.That(data.ResolveRequired("{STRINGREPLACE[{B[QNum]}][\"\\)\"][\"\"]}"), Is.EqualTo("sample"));
                Assert.That(data.ResolveRequired("{{buffer:QNum}}"), Is.EqualTo("sample)"));
                Assert.That(data.ResolveRequired("{{env:" + environmentName + "}}") == "external-test-value", Is.True);
            });
            Environment.SetEnvironmentVariable(environmentName, null);
            Assert.Throws<SgsScenarioDataException>(() => data.ResolveRequired("{{env:" + environmentName + "}}"));
        }
        finally
        {
            Environment.SetEnvironmentVariable(environmentName, null);
        }
    }

    [TestCase("{DATE[][+2d][MM/dd/yyyy]}", "09/24/2026")]
    [TestCase("{DATE[01-31-2026][1m][MM-dd-yyyy]}", "02-28-2026")]
    [TestCase("{DATE[2024-02-29][1y][yyyy-MM-dd]}", "2025-02-28")]
    [TestCase("{DATE[][][]}", "09-22-2026")]
    [TestCase("{STRINGTOUPPER[{STRINGREPLACE['ab]c']['b']['x']}]}", "AX]C")]
    public void DateAndTextOperationsAreDeterministicAndUseExplicitSourceSemantics(string expression, string expected)
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { approved = "usable" });
        var data = fixture.Load();
        Assert.That(data.ResolveRequired(expression), Is.EqualTo(expected));
    }

    [TestCase("{{data:absent}}")]
    [TestCase("{{env:INVALID-NAME}}")]
    [TestCase("{{unknown:key}}")]
    [TestCase("{{randomRegex}}")]
    [TestCase("{RANDOMREGEX[abc]}")]
    [TestCase("{STRINGREPLACE[a][][]}")]
    [TestCase("{DATE[not-a-date][1d][MM/dd/yyyy]}")]
    [TestCase("{DATE[][invalid][MM/dd/yyyy]}")]
    [TestCase("{DATE[][2147483648d][MM/dd/yyyy]}")]
    [TestCase("{DATE[][2147483647y][MM/dd/yyyy]}")]
    [TestCase("{DATE[][][invalid-format]}")]
    [TestCase("{STRINGTOUPPER[abc]")]
    [TestCase("{{data:key")]
    [TestCase("literal}")]
    [TestCase("{B[missing]}")]
    public void UnsupportedInvalidAndUnresolvedExpressionsFailClosed(string expression)
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { approved = "usable", unused = expression });
        var data = fixture.Load();
        Assert.That(data.GetRequired("approved"), Is.EqualTo("usable"));
        Assert.Throws<SgsScenarioDataException>(() => data.GetRequired("unused"));
    }

    [Test]
    public void CyclicDataReferencesAndExpansionLimitsFailExplicitly()
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { first = "{{data:second}}", second = "{{data:VALUES.FIRST}}", large = new string('x', 65537) });
        var data = fixture.Load();
        Assert.Multiple(() =>
        {
            Assert.Throws<SgsScenarioDataException>(() => data.GetRequired("first"));
            Assert.Throws<SgsScenarioDataException>(() => data.GetRequired("large"));
            Assert.Throws<SgsScenarioDataException>(() => data.ResolveRequired(
                string.Concat(Enumerable.Repeat("{STRINGTOUPPER[", 260)) + "x" +
                string.Concat(Enumerable.Repeat("]}", 260))));
            Assert.Throws<SgsScenarioDataException>(() => data.ResolveRequired(
                "{STRINGREPLACE[" + new string('x', 1000) + "][x][" + new string('y', 1000) + "]}"));
        });
    }

    [Test]
    public void ExistingRuntimeIdentityIsTheOnlyIdentityOwnerAndIsResolvedOnce()
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new
        {
            first = "{{firstName}}",
            again = "{{male}}",
            identity = "{{firstName}} {{lastName}} {{middleInitial}} {{randomDOB}} {{randomPhone}} {{randomEmail}} {{randomSSN}}"
        });
        var context = new ScenarioContextData();
        var data = fixture.Load(context);
        var resolved = data.GetRequired("identity");
        var original = RandomGenerators.ResolveRuntimeTokens(
            "{{firstName}} {{lastName}} {{middleInitial}} {{randomDOB}} {{randomPhone}} {{randomEmail}} {{randomSSN}}", context);
        Assert.Multiple(() =>
        {
            Assert.That(resolved == original, Is.True, "The adapter must use the injected PnC identity.");
            Assert.That(data.GetRequired("identity") == resolved, Is.True);
            Assert.That(data.GetRequired("first") == data.GetRequired("again"), Is.True);
            Assert.That(data.ResolveRequired("{{runtime:FirstName}}") == context.ClientFirstName, Is.True);
            Assert.That(data.ResolveRequired("{B[LastName]}") == context.ClientLastName, Is.True);
            Assert.That(data.GetRequiredBuffer("OwnerEmail") == context.ClientEmail, Is.True);
        });
    }

    [Test]
    public void CapturesAreOwnedByTheInjectedContextAndDomainQuoteHandoff()
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { approved = "usable" });
        var context = new ScenarioContextData();
        var handoff = new RecordingQuoteHandoff(context);
        var data = fixture.Adapter(context, handoff);
        data.Load(new SgsScenarioDataRequest("CLEQ", @"TestData\profile.json"));
        data.CaptureBuffer("Quote_Num", "test-quote-1");
        data.CaptureBuffer("Quote_NameNum", "test label 1");
        data.CaptureBuffer("EffDate", "09-23-2026");
        data.CaptureBuffer("First Name", "ScenarioIdentity");
        var otherServiceForSameContext = fixture.Adapter(context, handoff);

        Assert.Multiple(() =>
        {
            Assert.That(handoff.PublishCount, Is.EqualTo(1));
            Assert.That(context.QuoteNumber == "test-quote-1", Is.True);
            Assert.That(otherServiceForSameContext.GetRequiredBuffer("QuoteNumber") == context.QuoteNumber, Is.True);
            Assert.That(otherServiceForSameContext.GetRequiredBuffer("Quote_NameNum") == "test label 1", Is.True);
            Assert.That(context.EffectiveDate, Is.EqualTo("09-23-2026"));
            Assert.That(data.ResolveRequired("{{firstName}}") == context.ClientFirstName, Is.True);
        });
        context.QuoteNumber = "test-quote-updated-by-domain";
        Assert.That(data.ResolveRequired("{B[Quote_Num]}") == context.QuoteNumber, Is.True);
        Assert.That(data.GetRequiredBuffer("ProposalNumber") == context.QuoteNumber, Is.True);
    }

    [Test]
    public void QuoteIdentityCannotBeInjectedAsAnInputOverrideOrReturnedBlank()
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { approved = "usable" });
        var data = fixture.Load();
        Assert.Multiple(() =>
        {
            Assert.Throws<SgsScenarioDataException>(() => data.GetRequiredBuffer("QuoteNumber"));
            Assert.Throws<SgsScenarioDataException>(() => data.CaptureBuffer("QuoteNumber", ""));
            Assert.Throws<SgsScenarioDataException>(() => data.CaptureBuffer("QuoteNumber", new string('q', 129)));
            Assert.Throws<SgsScenarioDataException>(() => data.Load(new SgsScenarioDataRequest(
                "CLEQ", @"TestData\profile.json",
                RuntimeOverrides: new Dictionary<string, string?> { ["values.Quote_Num"] = "test-quote" })));
        });
    }

    [Test]
    public void SeparateScenariosDoNotShareInputsCapturesOrRuntimeIdentity()
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { first = "{{firstName}}", input = "base" });
        var firstContext = new ScenarioContextData { ClientFirstName = "ScenarioOne" };
        var secondContext = new ScenarioContextData { ClientFirstName = "ScenarioTwo" };
        var first = fixture.Load(firstContext);
        first.CaptureBuffer("screen", "first-screen");
        first.CaptureBuffer("QuoteNumber", "first-quote");
        var second = fixture.Load(secondContext);

        Assert.Multiple(() =>
        {
            Assert.That(firstContext.SgsData, Is.Not.SameAs(secondContext.SgsData));
            Assert.That(first.GetRequired("first") == "ScenarioOne", Is.True);
            Assert.That(second.GetRequired("first") == "ScenarioTwo", Is.True);
            Assert.Throws<SgsScenarioDataException>(() => second.GetRequiredBuffer("screen"));
            Assert.Throws<SgsScenarioDataException>(() => second.GetRequiredBuffer("QuoteNumber"));
        });
    }

    [Test]
    public void ReloadAndFailedLoadNeverExposePreviousInputsOrCaptureBuffers()
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { first = "{{firstName}}" });
        var context = new ScenarioContextData();
        var data = fixture.Load(context);
        var first = data.GetRequired("first");
        data.CaptureBuffer("screen", "captured");
        data.Load(new SgsScenarioDataRequest("CLEQ", @"TestData\profile.json"));
        Assert.That(data.GetRequired("first") == first, Is.True);
        Assert.Throws<SgsScenarioDataException>(() => data.GetRequiredBuffer("screen"));
        fixture.ReplaceUnrecordedBytes("profile.json", """{"values":{"first":"stale"}}""");
        Assert.Throws<SgsScenarioDataException>(() => data.Load(new SgsScenarioDataRequest("CLEQ", @"TestData\profile.json")));
        Assert.That(context.SgsData.IsLoaded, Is.False);
        Assert.Throws<SgsScenarioDataException>(() => data.GetRequired("first"));
    }

    [TestCase("wrong")]
    [TestCase("cleq")]
    [TestCase("CLEQ ")]
    public void UnknownProductCannotFallBackToAnotherProduct(string product)
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { approved = "usable" });
        Assert.Throws<SgsScenarioDataException>(() => fixture.Adapter().Load(new SgsScenarioDataRequest(product, @"TestData\profile.json")));
    }

    [TestCase(@"..\TestData\profile.json")]
    [TestCase(@"TestData\..\profile.json")]
    [TestCase(@"TestData\\profile.json")]
    [TestCase(@"C:\TestData\profile.json")]
    [TestCase(@"C:TestData\profile.json")]
    [TestCase(@"\\server\share\profile.json")]
    [TestCase(@"\TestData\profile.json")]
    [TestCase(@"TestData\profile.json:stream")]
    [TestCase(@"TestData\CON.json")]
    [TestCase(@"TestData\profile.json.")]
    [TestCase(@"TestData\profile.json ")]
    [TestCase(@"tests\PersonalLines.DuckCreek.Tests\TestData\profile.json")]
    [TestCase(@"Resources\SGS\PersonalLines.DuckCreek\TestData\profile.json")]
    [TestCase(@"TestData\not-recorded.json")]
    [TestCase(@"TestData\profile.txt")]
    public void TraversalAbsoluteCrossProductAndUnrecordedPathsAreRejected(string path)
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { approved = "usable" });
        Assert.Throws<SgsScenarioDataException>(() => fixture.Adapter().Load(new SgsScenarioDataRequest("CLEQ", path)));
    }

    [Test]
    public void EveryRequestedExternalAndLayerFileMustBeRecordedAndCurrent()
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { approved = "usable" });
        fixture.Add("external.json", """{"values":{"approved":"external"}}""");
        fixture.ReplaceUnrecordedBytes("external.json", """{"values":{"approved":"unreviewed"}}""");
        var data = fixture.Adapter();
        Assert.Multiple(() =>
        {
            Assert.Throws<SgsScenarioDataException>(() => data.Load(new SgsScenarioDataRequest(
                "CLEQ", @"TestData\profile.json", ExternalDataPath: @"TestData\external.json")));
            Assert.Throws<SgsScenarioDataException>(() => data.Load(new SgsScenarioDataRequest(
                "CLEQ", @"TestData\profile.json")
            { LayerPaths = [@"TestData\external.json"] }));
            Assert.Throws<SgsScenarioDataException>(() => data.Load(new SgsScenarioDataRequest(
                "CLEQ", @"TestData\profile.json", ExternalDataPath: @"TestData\missing.json")));
        });
    }

    [Test]
    public void RawImportedHashNotSemanticJsonOrOriginalSourceHashControlsIntegrity()
    {
        using var fixture = new DataFixture();
        fixture.Add("profile.json", """{"values":{"approved":"usable"}}""");
        Assert.DoesNotThrow(() => fixture.Load());
        fixture.ReplaceUnrecordedBytes("profile.json", """{"values":{"approved":"usable" }}""");
        Assert.Throws<SgsScenarioDataException>(() => fixture.Load());
    }

    [Test]
    public void LegacyLayeredManifestsAreNotSilentlyReconstructedOrIgnored()
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { approved = "usable" });
        fixture.Add("manifest.json", """{"schemaVersion":"1.0-layered-runtime","entries":{}}""");
        Assert.Throws<SgsScenarioDataException>(() => fixture.Adapter().Load(new SgsScenarioDataRequest(
            "CLEQ", @"TestData\profile.json")
        { LayerPaths = [@"TestData\manifest.json"] }));
    }

    [TestCase("duplicate")]
    [TestCase("wrong-product")]
    [TestCase("wrong-destination")]
    [TestCase("wrong-size")]
    [TestCase("invalid-hash")]
    [TestCase("wrong-version")]
    public void InvalidOrAmbiguousInventoryCannotAuthorizeAProfile(string defect)
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { approved = "usable" });
        var path = Path.Combine(fixture.ResourcesRoot, "Contracts", "sgs-data-inventory.json");
        var inventory = JsonNode.Parse(File.ReadAllText(path))!.AsObject();
        var entries = inventory["files"]!.AsArray();
        var entry = entries[0]!.AsObject();
        switch (defect)
        {
            case "duplicate": entries.Add(entry.DeepClone()); break;
            case "wrong-product": entry["sourceProject"] = "PersonalLines.DuckCreek.Tests"; break;
            case "wrong-destination": entry["destinationPath"] = "Resources/SGS/PersonalLines.DuckCreek/TestData/profile.json"; break;
            case "wrong-size": entry["importedSize"] = 1; break;
            case "invalid-hash": entry["importedSha256"] = "invalid"; break;
            case "wrong-version": inventory["version"] = 2; break;
            default: throw new ArgumentException("Unknown test defect.");
        }
        File.WriteAllText(path, inventory.ToJsonString());
        Assert.Throws<SgsScenarioDataException>(() => fixture.Load());
    }

    [Test]
    public void ARecordedFileMustStillExist()
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { approved = "usable" });
        File.Delete(fixture.ProfilePath);
        Assert.Throws<SgsScenarioDataException>(() => fixture.Load());
    }

    [Test]
    public void ARequestedStateVariantAndOverrideMustActuallyExistAndMatch()
    {
        using var fixture = new DataFixture();
        fixture.Add("profile.json", """{"dimensions":{"stateVariant":"AL"},"values":{"approved":"usable"}}""");
        fixture.Add("states.json", """{"overrides":{"AL":{"values":{"approved":"state"}}}}""");
        var data = fixture.Adapter();
        Assert.Multiple(() =>
        {
            Assert.Throws<SgsScenarioDataException>(() => data.Load(new SgsScenarioDataRequest("CLEQ", @"TestData\profile.json", "AZ")));
            Assert.Throws<SgsScenarioDataException>(() => data.Load(new SgsScenarioDataRequest(
                "CLEQ", @"TestData\profile.json", "AZ")
            { StateOverridesPath = @"TestData\states.json" }));
        });
    }

    [Test]
    public void CredentialValuesAreExternalNotCapturedAndErrorsNeverEchoPayloads()
    {
        using var fixture = new DataFixture();
        const string sentinel = "unit-test-only-redaction-sentinel";
        fixture.AddValues(new { approved = "usable", password = "" });
        var data = fixture.Load();
        var overrideError = Assert.Throws<SgsScenarioDataException>(() => data.Load(new SgsScenarioDataRequest(
            "CLEQ", @"TestData\profile.json", RuntimeOverrides: new Dictionary<string, string?> { ["password"] = sentinel })));
        Assert.That(overrideError!.ToString().Contains(sentinel, StringComparison.Ordinal), Is.False);

        data = fixture.Load();
        var captureError = Assert.Throws<SgsScenarioDataException>(() => data.CaptureBuffer("password", sentinel));
        Assert.That(captureError!.ToString().Contains(sentinel, StringComparison.Ordinal), Is.False);
        fixture.Add("malformed.json", "{\"values\":{\"x\":\"" + sentinel + "\"");
        var parseError = Assert.Throws<SgsScenarioDataException>(() => data.Load(new SgsScenarioDataRequest("CLEQ", @"TestData\malformed.json")));
        Assert.That(parseError!.ToString().Contains(sentinel, StringComparison.Ordinal), Is.False);
    }

    [Test]
    public void CredentialEnvironmentReferencesAreResolvedWithoutCachingTheirValues()
    {
        using var fixture = new DataFixture();
        var name = "PNC_SGS_TEST_" + Guid.NewGuid().ToString("N");
        fixture.AddValues(new { password = "{{env:" + name + "}}" });
        var data = fixture.Load();
        try
        {
            Environment.SetEnvironmentVariable(name, "first-test-only-value");
            Assert.That(data.GetRequired("password") == "first-test-only-value", Is.True);
            Environment.SetEnvironmentVariable(name, "second-test-only-value");
            Assert.That(data.GetRequired("password") == "second-test-only-value", Is.True);
            Environment.SetEnvironmentVariable(name, null);
            Assert.Throws<SgsScenarioDataException>(() => data.GetRequired("password"));
        }
        finally
        {
            Environment.SetEnvironmentVariable(name, null);
        }
    }

    [TestCase("SYNTHETIC_REPLACE_ME")]
    [TestCase("PLACEHOLDER")]
    [TestCase("<external-required>")]
    public void CredentialPlaceholdersCannotBeImportedAsLiteralCredentialValues(string placeholder)
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { password = placeholder });
        var error = Assert.Throws<SgsScenarioDataException>(() => fixture.Load());
        Assert.That(error!.ToString().Contains(placeholder, StringComparison.Ordinal), Is.False);
    }

    [TestCase(false)]
    [TestCase(true)]
    public void ResourceRootIsExplicitAndReparsePointsCannotEscapeIt(bool linkedAncestor)
    {
        using var fixture = new DataFixture();
        fixture.AddValues(new { approved = "usable" });
        var relativeRoot = new SgsScenarioData(new ScenarioContextData(), new ScenarioQuoteHandoff(new ScenarioContextData()),
            new SgsScenarioDataOptions { ResourcesRootPath = "Resources" });
        Assert.Throws<SgsScenarioDataException>(() => relativeRoot.Load(new SgsScenarioDataRequest("CLEQ", @"TestData\profile.json")));

        var dataDirectory = linkedAncestor
            ? Path.Combine(fixture.ResourcesRoot, "linked-parent")
            : Path.GetDirectoryName(fixture.ProfilePath)!;
        var target = linkedAncestor
            ? Path.GetDirectoryName(fixture.ResourcesRoot)!
            : dataDirectory + "-target";
        if (!linkedAncestor)
            Directory.Move(dataDirectory, target);
        if (OperatingSystem.IsWindows())
        {
            using var process = Process.Start(new ProcessStartInfo
            {
                FileName = Environment.GetEnvironmentVariable("ComSpec") ?? "cmd.exe",
                Arguments = $"/c mklink /J \"{dataDirectory}\" \"{target}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            })!;
            Assert.That(process.WaitForExit(10000), Is.True, "The test junction command must finish.");
            Assert.That(process.ExitCode, Is.Zero, "The test junction must be created.");
        }
        else
        {
            Directory.CreateSymbolicLink(dataDirectory, target);
        }
        try
        {
            var context = new ScenarioContextData();
            var data = new SgsScenarioData(context, new ScenarioQuoteHandoff(context), new SgsScenarioDataOptions
            {
                ResourcesRootPath = linkedAncestor ? Path.Combine(dataDirectory, "Resources") : fixture.ResourcesRoot
            });
            Assert.Throws<SgsScenarioDataException>(() => data.Load(new SgsScenarioDataRequest("CLEQ", @"TestData\profile.json")));
        }
        finally
        {
            Directory.Delete(dataDirectory);
        }
    }

    private static SgsScenarioData RealAdapter(ScenarioContextData context) =>
        new(context, new ScenarioQuoteHandoff(context), new SgsScenarioDataOptions
        {
            ResourcesRootPath = Path.Combine(FindRepositoryRoot(), "Resources")
        });

    private static string FindRepositoryRoot()
    {
        var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
        while (directory is not null)
        {
            if (File.Exists(Path.Combine(directory.FullName, "TestAutomation.csproj")))
                return directory.FullName;
            directory = directory.Parent;
        }
        throw new DirectoryNotFoundException("The test repository root is unavailable.");
    }

    private sealed class DataFixture : IDisposable
    {
        private readonly List<object> _entries = [];
        private readonly string _directory = Path.Combine(Path.GetTempPath(), "pnc-sgs-data-" + Guid.NewGuid().ToString("N"));
        internal string ResourcesRoot => Path.Combine(_directory, "Resources");
        internal string ProfilePath => Path.Combine(ResourcesRoot, "SGS", "CommercialLines.ExpertQuote", "TestData", "profile.json");

        internal void AddValues(object values) => Add("profile.json", JsonSerializer.Serialize(new { values }));

        internal void Add(string filename, string json)
        {
            var bytes = Encoding.UTF8.GetBytes(json);
            var destination = Path.Combine(ResourcesRoot, "SGS", "CommercialLines.ExpertQuote", "TestData", filename);
            Directory.CreateDirectory(Path.GetDirectoryName(destination)!);
            File.WriteAllBytes(destination, bytes);
            _entries.Add(new
            {
                sourceProject = "CommercialLines.ExpertQuote.Tests",
                sourceRelativePath = "tests/CommercialLines.ExpertQuote.Tests/TestData/" + filename.Replace('\\', '/'),
                destinationPath = "Resources/SGS/CommercialLines.ExpertQuote/TestData/" + filename.Replace('\\', '/'),
                kind = "scenario-data",
                sourceSha256 = new string('0', 64),
                importedSha256 = Convert.ToHexString(SHA256.HashData(bytes)),
                importedSize = bytes.Length
            });
            var contracts = Path.Combine(ResourcesRoot, "Contracts");
            Directory.CreateDirectory(contracts);
            File.WriteAllText(Path.Combine(contracts, "sgs-data-inventory.json"), JsonSerializer.Serialize(new
            {
                version = 1,
                sourceCommit = "ecd9019ab991028341ad76de11cff06aa43cb32f",
                files = _entries
            }));
        }

        internal void ReplaceUnrecordedBytes(string filename, string json) =>
            File.WriteAllText(Path.Combine(ResourcesRoot, "SGS", "CommercialLines.ExpertQuote", "TestData", filename), json);

        internal SgsScenarioData Adapter(ScenarioContextData? context = null, IQuoteHandoff? handoff = null)
        {
            context ??= new ScenarioContextData();
            return new SgsScenarioData(context, handoff ?? new ScenarioQuoteHandoff(context), new SgsScenarioDataOptions
            {
                ResourcesRootPath = ResourcesRoot,
                TimeProvider = new FixedTimeProvider()
            });
        }

        internal SgsScenarioData Load(ScenarioContextData? context = null)
        {
            var adapter = Adapter(context);
            adapter.Load(new SgsScenarioDataRequest("CLEQ", @"TestData\profile.json"));
            return adapter;
        }

        public void Dispose()
        {
            if (Directory.Exists(_directory))
                Directory.Delete(_directory, recursive: true);
        }
    }

    private sealed class FixedTimeProvider : TimeProvider
    {
        public override DateTimeOffset GetUtcNow() => new(2026, 9, 22, 12, 0, 0, TimeSpan.Zero);
        public override TimeZoneInfo LocalTimeZone => TimeZoneInfo.Utc;
    }

    private sealed class RecordingQuoteHandoff(ScenarioContextData context) : IQuoteHandoff
    {
        private readonly ScenarioQuoteHandoff _inner = new(context);
        internal int PublishCount { get; private set; }

        public void Publish(string quoteNumber)
        {
            PublishCount++;
            _inner.Publish(quoteNumber);
        }

        public bool TryGet(out QuoteReference? quote) => _inner.TryGet(out quote);
        public QuoteReference Require(string consumer) => _inner.Require(consumer);
    }
}
