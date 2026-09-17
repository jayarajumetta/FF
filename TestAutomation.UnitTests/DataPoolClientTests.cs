using System.Net;
using NUnit.Framework;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.DataPool;
using PnCTestAutomation.Models;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class DataPoolClientTests
{
    [Test]
    public async Task OptionalPersistenceReturnsVisibleUnavailableOutcome()
    {
        var client = new DataPoolClient(
            new HttpClient(new ThrowingHandler("sensitive-upstream-detail")),
            LocalConfig(required: false));

        var result = await client.PersistAsync(Record());

        Assert.Multiple(() =>
        {
            Assert.That(result.Status, Is.EqualTo(DataPoolPersistenceStatus.Unavailable));
            Assert.That(result.Succeeded, Is.False);
            Assert.That(result.Message, Does.Contain("unavailable"));
            Assert.That(result.Message, Does.Not.Contain("sensitive-upstream-detail"));
        });
    }

    [Test]
    public void RequiredPersistenceFailsWithoutLeakingTransportDetails()
    {
        var client = new DataPoolClient(
            new HttpClient(new ThrowingHandler("sensitive-upstream-detail")),
            LocalConfig(required: true));

        var exception = Assert.ThrowsAsync<DataPoolPersistenceException>(
            async () => await client.PersistAsync(Record()));

        Assert.Multiple(() =>
        {
            Assert.That(exception!.Message, Does.Contain("unavailable"));
            Assert.That(exception.Message, Does.Not.Contain("sensitive-upstream-detail"));
            Assert.That(exception.InnerException, Is.TypeOf<HttpRequestException>());
        });
    }

    [Test]
    public async Task OptionalUnconfiguredPersistenceIsNotReportedAsSuccess()
    {
        var client = new UnavailableDataPoolClient(
            new DataPoolClientConfig { Required = false });

        var result = await client.PersistAsync(Record());

        Assert.Multiple(() =>
        {
            Assert.That(result.Status, Is.EqualTo(DataPoolPersistenceStatus.NotConfigured));
            Assert.That(result.Succeeded, Is.False);
            Assert.That(result.Message, Does.Contain("not configured"));
        });
    }

    [Test]
    public async Task PersistenceAddsConfiguredAuthenticationWithoutExposingIt()
    {
        const string apiKey = "sensitive-datapool-key";
        string? observedKey = null;
        var handler = new StubHandler(request =>
        {
            observedKey = request.Headers.GetValues(DataPoolClient.ApiKeyHeader).Single();
            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent("sensitive-response-body")
            };
        });
        var client = new DataPoolClient(
            new HttpClient(handler),
            new DataPoolClientConfig
            {
                BaseUrl = "https://datapool.example.test/",
                ApiKey = apiKey,
                Required = false
            });

        var result = await client.PersistAsync(Record());

        Assert.Multiple(() =>
        {
            Assert.That(observedKey, Is.EqualTo(apiKey));
            Assert.That(result.Status, Is.EqualTo(DataPoolPersistenceStatus.Rejected));
            Assert.That(result.Message, Does.Not.Contain(apiKey));
            Assert.That(result.Message, Does.Not.Contain("sensitive-response-body"));
        });
    }

    [Test]
    public void RemoteClientConfigurationFailsClosed()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
                () => new DataPoolClientConfig
                {
                    BaseUrl = "http://datapool.example.test/"
                }.Validate(),
                Throws.InvalidOperationException.With.Message.Contains("HTTPS"));
            Assert.That(
                () => new DataPoolClientConfig
                {
                    BaseUrl = "https://datapool.example.test/"
                }.Validate(),
                Throws.InvalidOperationException.With.Message.Contains("DATAPOOL_API_KEY"));
            Assert.That(
                () => new DataPoolClientConfig
                {
                    BaseUrl = "https://datapool.example.test/",
                    ApiKey = "$(DATAPOOL_API_KEY)"
                }.Validate(),
                Throws.InvalidOperationException.With.Message.Contains("DATAPOOL_API_KEY"));
            Assert.That(
                () => new DataPoolClientConfig
                {
                    BaseUrl = "https://datapool.example.test/",
                    ApiKey = "externally-supplied"
                }.Validate(),
                Throws.Nothing);
        });
    }

    private static DataPoolClientConfig LocalConfig(bool required) =>
        new()
        {
            BaseUrl = "http://127.0.0.1:5100/",
            Required = required
        };

    private static QuoteRecord Record() =>
        new()
        {
            Id = "Q-100",
            Transaction = "Quote",
            Status = "available"
        };

    private sealed class StubHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _respond;

        public StubHandler(Func<HttpRequestMessage, HttpResponseMessage> respond)
        {
            _respond = respond;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken) =>
            Task.FromResult(_respond(request));
    }

    private sealed class ThrowingHandler : HttpMessageHandler
    {
        private readonly string _message;

        public ThrowingHandler(string message)
        {
            _message = message;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken) =>
            throw new HttpRequestException(_message);
    }
}
