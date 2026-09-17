using System.Text.Json;
using DataPool.Configuration;
using DataPool.Models;
using DataPool.Security;
using DataPool.Services;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class DataPoolRuntimeTests
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
    public void RuntimeDefaultsToLoopbackAndRemoteExposureFailsClosed()
    {
        var defaults = new DataPoolRuntimeOptions();
        var insecureRemote = new DataPoolRuntimeOptions
        {
            ListenUrl = "http://0.0.0.0:5100",
            ApiKey = "configured-but-not-https"
        };
        var unauthenticatedRemote = new DataPoolRuntimeOptions
        {
            ListenUrl = "https://0.0.0.0:5100"
        };
        var unexpandedSecret = new DataPoolRuntimeOptions
        {
            ListenUrl = "https://0.0.0.0:5100",
            ApiKey = "$(DATAPOOL_API_KEY)"
        };

        Assert.Multiple(() =>
        {
            Assert.That(defaults.ListenUrl, Is.EqualTo("http://127.0.0.1:5100"));
            Assert.That(defaults.ApiKey, Is.Empty);
            Assert.That(() => defaults.Validate(), Throws.Nothing);
            Assert.That(
                () => insecureRemote.Validate(),
                Throws.InvalidOperationException.With.Message.Contains("HTTPS"));
            Assert.That(
                () => unauthenticatedRemote.Validate(),
                Throws.InvalidOperationException.With.Message.Contains("DATAPOOL_API_KEY"));
            Assert.That(
                () => unexpandedSecret.Validate(),
                Throws.InvalidOperationException.With.Message.Contains("DATAPOOL_API_KEY"));
        });
    }

    [Test]
    public async Task RequestGuardEnforcesAuthenticationButKeepsHealthMinimalAndPublic()
    {
        var options = new DataPoolRuntimeOptions
        {
            ListenUrl = "https://0.0.0.0:5100",
            ApiKey = "sensitive-runtime-key"
        };
        var nextCalls = 0;
        var middleware = new DataPoolRequestGuardMiddleware(
            _ =>
            {
                nextCalls++;
                return Task.CompletedTask;
            },
            options);

        var missingKey = Context("/api/quotes");
        await middleware.InvokeAsync(missingKey);

        var valid = Context("/api/quotes");
        valid.Request.Headers[DataPoolRequestGuardMiddleware.ApiKeyHeader] =
            "sensitive-runtime-key";
        await middleware.InvokeAsync(valid);

        var health = Context("/health");
        await middleware.InvokeAsync(health);

        Assert.Multiple(() =>
        {
            Assert.That(missingKey.Response.StatusCode, Is.EqualTo(StatusCodes.Status401Unauthorized));
            Assert.That(nextCalls, Is.EqualTo(2));
            Assert.That(valid.Response.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
            Assert.That(health.Response.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
        });
    }

    [Test]
    public async Task RequestGuardRejectsOversizedPayloads()
    {
        var middleware = new DataPoolRequestGuardMiddleware(
            _ => throw new AssertionException("Oversized request must not continue."),
            new DataPoolRuntimeOptions
            {
                MaxRequestBodyBytes = 1024
            });
        var context = Context("/api/quotes");
        context.Request.ContentLength = 1025;

        await middleware.InvokeAsync(context);

        Assert.That(
            context.Response.StatusCode,
            Is.EqualTo(StatusCodes.Status413PayloadTooLarge));
    }

    [Test]
    public void CorruptJsonIsReportedAndPreserved()
    {
        var path = DataPath();
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, "{not-json");
        var service = new DataPoolService(path);

        var exception = Assert.Throws<DataPoolStorageException>(
            () => service.GetAll());

        Assert.Multiple(() =>
        {
            Assert.That(exception!.InnerException, Is.TypeOf<System.Text.Json.JsonException>());
            Assert.That(exception!.Message, Does.Contain("malformed JSON"));
            Assert.That(exception.Message, Does.Not.Contain(path));
            Assert.That(File.ReadAllText(path), Is.EqualTo("{not-json"));
        });
    }

    [Test]
    public void InvalidStoredRecordIsReportedAsStorageFailure()
    {
        var path = DataPath();
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(
            path,
            """
            [{"id":"","transaction":"Quote","status":"available","createdAt":"2026-01-02T03:04:05Z"}]
            """);
        var service = new DataPoolService(path);

        Assert.That(
            () => service.GetAll(),
            Throws.TypeOf<DataPoolStorageException>()
                .With.Message.Contains("invalid identifier"));
    }

    [Test]
    public void DuplicateStoredIdentifiersAreReportedAsStorageFailure()
    {
        var path = DataPath();
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(
            path,
            """
            [
              {"id":"Q-100","transaction":"Quote","status":"available","createdAt":"2026-01-02T03:04:05Z"},
              {"id":"q-100","transaction":"Quote","status":"available","createdAt":"2026-01-02T03:04:05Z"}
            ]
            """);
        var service = new DataPoolService(path);

        Assert.That(
            () => service.GetAll(),
            Throws.TypeOf<DataPoolStorageException>()
                .With.Message.Contains("duplicate quote identifiers"));
    }

    [Test]
    public void InvalidInputAndStateTransitionsFailExplicitly()
    {
        var service = new DataPoolService(DataPath());

        Assert.Multiple(() =>
        {
            Assert.That(
                () => service.Add(Record(new string('Q', 129))),
                Throws.TypeOf<DataPoolValidationException>());
            Assert.That(
                () => service.CleanupOldRecords(-1, 1),
                Throws.TypeOf<DataPoolValidationException>());
        });

        service.Add(Record("Q-100"));

        Assert.Multiple(() =>
        {
            Assert.That(
                () => service.Consume("Q-100", "consumer-1"),
                Throws.TypeOf<DataPoolConflictException>());
            Assert.That(
                () => service.Release("Q-100"),
                Throws.TypeOf<DataPoolConflictException>());
        });
    }

    [Test]
    public void ConcurrentPersistenceAndClaimAreSerialized()
    {
        var path = DataPath();
        var first = new DataPoolService(path);
        var second = new DataPoolService(path);

        Parallel.For(
            0,
            20,
            index => (index % 2 == 0 ? first : second).Add(Record($"Q-{index:000}")));

        var claimResults = new List<string>();
        Parallel.Invoke(
            () => CaptureClaim(first, "consumer-1", claimResults),
            () => CaptureClaim(second, "consumer-2", claimResults));

        var stored = first.GetAll();
        Assert.Multiple(() =>
        {
            Assert.That(stored, Has.Count.EqualTo(20));
            Assert.That(stored.Select(record => record.Id), Is.Unique);
            Assert.That(claimResults.Count(result => result == "claimed"), Is.EqualTo(1));
            Assert.That(claimResults.Count(result => result == "conflict"), Is.EqualTo(1));
            Assert.That(stored.Single(record => record.Id == "Q-000").Status, Is.EqualTo("claimed"));
        });
    }

    [Test]
    public void ClaimConsumeReleaseEnforceActorIdentity()
    {
        var service = new DataPoolService(DataPath());
        service.Add(Record("Q-100"));
        service.Claim("Q-100", "consumer-1");

        Assert.That(
            () => service.Consume("Q-100", "consumer-2"),
            Throws.TypeOf<DataPoolConflictException>()
                .With.Message.Contains("identity that claimed"));

        var released = service.Release("Q-100");
        var claimedAgain = service.Claim("Q-100", "consumer-2");
        var consumed = service.Consume("Q-100", "consumer-2");
        var backup = JsonSerializer.Deserialize<List<QuoteRecord>>(
            File.ReadAllText($"{DataPath()}.bak"));

        Assert.Multiple(() =>
        {
            Assert.That(released.Status, Is.EqualTo("available"));
            Assert.That(claimedAgain.ClaimedBy, Is.EqualTo("consumer-2"));
            Assert.That(consumed.Status, Is.EqualTo("consumed"));
            Assert.That(consumed.ConsumedBy, Is.EqualTo("consumer-2"));
            Assert.That(backup, Is.Not.Null.And.Not.Empty);
        });
    }

    private string DataPath() => Path.Combine(_temporaryRoot, "quotes.json");

    private static DefaultHttpContext Context(string path)
    {
        var context = new DefaultHttpContext();
        context.Request.Path = path;
        context.Response.Body = new MemoryStream();
        return context;
    }

    private static QuoteRecord Record(string id) =>
        new()
        {
            Id = id,
            Transaction = "Quote",
            Status = "available",
            CreatedAt = DateTime.UtcNow
        };

    private static void CaptureClaim(
        DataPoolService service,
        string actor,
        ICollection<string> results)
    {
        try
        {
            service.Claim("Q-000", actor);
            lock (results)
                results.Add("claimed");
        }
        catch (DataPoolConflictException)
        {
            lock (results)
                results.Add("conflict");
        }
    }
}
