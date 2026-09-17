using System.Text.Json;
using NUnit.Framework;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.QuoteHandoffs;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class QuoteHandoffTests
{
    private string _temporaryRoot = null!;

    [SetUp]
    public void SetUp()
    {
        _temporaryRoot = Path.Combine(
            Path.GetTempPath(),
            "PnCTestAutomation.Tests",
            Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_temporaryRoot);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_temporaryRoot))
            Directory.Delete(_temporaryRoot, recursive: true);
    }

    [Test]
    public void ScenarioHandoffsRemainIsolated()
    {
        var firstState = new ScenarioContextData();
        var secondState = new ScenarioContextData();
        var first = new ScenarioQuoteHandoff(firstState);
        var second = new ScenarioQuoteHandoff(secondState);

        first.Publish("Q-100");

        Assert.Multiple(() =>
        {
            Assert.That(first.Require("first consumer").QuoteNumber, Is.EqualTo("Q-100"));
            Assert.That(second.TryGet(out _), Is.False);
            Assert.That(secondState.QuoteNumber, Is.Null.Or.Empty);
        });
    }

    [Test]
    public void ScenarioHandoffDoesNotReadLegacyGlobalFiles()
    {
        File.WriteAllText(Path.Combine(_temporaryRoot, "QuoteNumber.txt"), "STALE-QUOTE");
        var handoff = new ScenarioQuoteHandoff(new ScenarioContextData());

        Assert.That(
            () => handoff.Require("quote search"),
            Throws.InvalidOperationException.With.Message.Contains(
                "No quote has been captured for the current scenario"));
    }

    [Test]
    public async Task CrossProcessHandoffRequiresExactIdentity()
    {
        var now = new DateTimeOffset(2026, 1, 2, 3, 4, 5, TimeSpan.Zero);
        var store = new FileQuoteHandoffStore(_temporaryRoot, () => now);
        await store.PublishAsync(CreateEnvelope(now));

        var mismatch = Assert.ThrowsAsync<InvalidDataException>(
            async () => await store.ReadAsync(
                CreateRequest() with { ConsumerId = "different-consumer" }));
        var missingRun = Assert.ThrowsAsync<FileNotFoundException>(
            async () => await store.ReadAsync(
                CreateRequest() with { RunId = "different-run" }));
        var file = Directory.GetFiles(
            _temporaryRoot,
            "*.json",
            SearchOption.AllDirectories).Single();
        var payload = await File.ReadAllTextAsync(file);
        await File.WriteAllTextAsync(
            file,
            payload.Replace("\"runId\": \"run-1\"", "\"runId\": \"different-run\"", StringComparison.Ordinal));
        var runMismatch = Assert.ThrowsAsync<InvalidDataException>(
            async () => await store.ReadAsync(CreateRequest()));

        Assert.Multiple(() =>
        {
            Assert.That(mismatch!.Message, Does.Contain("identity does not match"));
            Assert.That(missingRun!.Message, Does.Contain("does not exist"));
            Assert.That(runMismatch!.Message, Does.Contain("identity does not match"));
        });
    }

    [Test]
    public async Task CrossProcessHandoffRejectsStaleAndUnsupportedPayloads()
    {
        var created = new DateTimeOffset(2026, 1, 2, 3, 4, 5, TimeSpan.Zero);
        var store = new FileQuoteHandoffStore(
            _temporaryRoot,
            () => created.AddHours(2));
        await store.PublishAsync(CreateEnvelope(created));

        var stale = Assert.ThrowsAsync<InvalidDataException>(
            async () => await store.ReadAsync(CreateRequest()));

        var file = Directory.GetFiles(
            _temporaryRoot,
            "*.json",
            SearchOption.AllDirectories).Single();
        var json = await File.ReadAllTextAsync(file);
        await File.WriteAllTextAsync(
            file,
            json.Replace("\"version\": 1", "\"version\": 99", StringComparison.Ordinal));
        var version = Assert.ThrowsAsync<InvalidDataException>(
            async () => await store.ReadAsync(
                CreateRequest() with { MaximumAge = TimeSpan.FromDays(1) }));

        Assert.Multiple(() =>
        {
            Assert.That(stale!.Message, Does.Contain("stale"));
            Assert.That(version!.Message, Does.Contain("Unsupported"));
        });
    }

    [Test]
    public async Task CrossProcessWritesUseVersionedStructuredJsonAndAtomicReplacement()
    {
        var now = new DateTimeOffset(2026, 1, 2, 3, 4, 5, TimeSpan.Zero);
        var store = new FileQuoteHandoffStore(_temporaryRoot, () => now);
        await store.PublishAsync(CreateEnvelope(now));
        await store.PublishAsync(
            CreateEnvelope(now.AddMinutes(1)) with
            {
                Quote = QuoteReference.Create("Q-200")
            });

        var files = Directory.GetFiles(
            _temporaryRoot,
            "*",
            SearchOption.AllDirectories);
        var payload = await File.ReadAllTextAsync(files.Single());
        using var document = JsonDocument.Parse(payload);

        Assert.Multiple(() =>
        {
            Assert.That(files.Single(), Does.EndWith(".quote-handoff.v1.json"));
            Assert.That(payload, Does.Not.Contain("QuoteNumber.txt"));
            Assert.That(
                document.RootElement.GetProperty("quote").GetProperty("quoteNumber").GetString(),
                Is.EqualTo("Q-200"));
            Assert.That(document.RootElement.GetProperty("runId").GetString(), Is.EqualTo("run-1"));
            Assert.That(document.RootElement.GetProperty("scenarioId").GetString(), Is.EqualTo("scenario-1"));
        });
    }

    private static QuoteHandoffEnvelope CreateEnvelope(DateTimeOffset createdAt) =>
        new(
            FileQuoteHandoffStore.CurrentVersion,
            "run-1",
            "scenario-1",
            "producer-1",
            "consumer-1",
            QuoteReference.Create("Q-100"),
            createdAt);

    private static QuoteHandoffRequest CreateRequest() =>
        new(
            "run-1",
            "scenario-1",
            "producer-1",
            "consumer-1",
            TimeSpan.FromHours(1));
}
