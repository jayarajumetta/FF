using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using NUnit.Framework;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Integrations;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;
using Reqnroll;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class ApiAuthenticationTests
{
    [Test]
    public async Task TypedTokenIsPropagatedToScenarioApiRequests()
    {
        const string tokenValue = "token-value-that-must-not-be-logged";
        var tokenHandler = new StubHttpMessageHandler(_ =>
            JsonResponse(HttpStatusCode.OK, """
                {"access_token":"token-value-that-must-not-be-logged","expires_in":300,"token_type":"Bearer"}
                """));
        var secretProvider = new StubSecretProvider("client-secret");
        var tokenProvider = new AccessTokenProvider(
            new HttpClient(tokenHandler),
            ValidOAuthConfig(),
            secretProvider);

        AuthenticationHeaderValue? authorization = null;
        string? requestJson = null;
        var apiHandler = new StubHttpMessageHandler(request =>
        {
            authorization = request.Headers.Authorization;
            requestJson = request.Content!.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonResponse(HttpStatusCode.OK, """{"firstName":"Ada","lastName":"Lovelace"}""");
        });
        var apiService = CreateApiService(apiHandler);

        var token = await tokenProvider.GetAccessTokenAsync();
        apiService.SetAccessToken(token);
        var response = await apiService.PostJsonAsync<ClientSearchRequest, ClientSearchResponse>(
            "apmi/mlsearch/search",
            new ClientSearchRequest
            {
                FirstName = "Ada",
                LastName = "Lovelace",
                DateOfBirth = "12/10/1815",
                EmailAddress = "ada@example.test",
                PhoneNumber = "5555550100"
            });

        using var requestDocument = JsonDocument.Parse(requestJson!);
        var requestRoot = requestDocument.RootElement;
        Assert.Multiple(() =>
        {
            Assert.That(secretProvider.RequestedSecretId, Is.EqualTo("oauth-secret-id"));
            Assert.That(token.Value, Is.EqualTo(tokenValue));
            Assert.That(token.ToString(), Does.Not.Contain(tokenValue));
            Assert.That(authorization?.Scheme, Is.EqualTo("Bearer"));
            Assert.That(authorization?.Parameter, Is.EqualTo(tokenValue));
            Assert.That(response.FirstName, Is.EqualTo("Ada"));
            Assert.That(requestRoot.GetProperty("exactSearch").GetBoolean(), Is.False);
            Assert.That(requestRoot.GetProperty("includePhoneticMatch").GetBoolean(), Is.True);
            Assert.That(requestRoot.GetProperty("includeAgentGrants").GetBoolean(), Is.True);
            Assert.That(
                requestRoot.GetProperty("emailAddress").GetString(),
                Is.EqualTo("ada@example.test"));
        });
    }

    [Test]
    public void MissingOAuthConfigurationFailsBeforeSecretRetrieval()
    {
        var secretProvider = new StubSecretProvider("client-secret");
        var provider = new AccessTokenProvider(
            new HttpClient(new StubHttpMessageHandler(_ =>
                throw new AssertionException("HTTP must not be called."))),
            new OAuthConfig(),
            secretProvider);

        var exception = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await provider.GetAccessTokenAsync());

        Assert.Multiple(() =>
        {
            Assert.That(exception!.Message, Does.Contain("OAuthConfig:TokenUrl"));
            Assert.That(secretProvider.RequestedSecretId, Is.Null);
        });
    }

    [Test]
    public void NonHttpsAuthenticationEndpointsAreRejected()
    {
        var oauth = ValidOAuthConfig();
        oauth.TokenUrl = "http://identity.example.test/token";
        var ping = ValidPingConfig();
        ping.SecretEndpoint = "not-a-uri";

        Assert.Multiple(() =>
        {
            Assert.That(
                () => oauth.ValidateClientCredentials(),
                Throws.InvalidOperationException.With.Message.Contains("absolute HTTPS URI"));
            Assert.That(
                () => ping.Validate(),
                Throws.InvalidOperationException.With.Message.Contains("absolute HTTPS URI"));
            Assert.That(
                () => new ApiClientConfig().Validate(),
                Throws.InvalidOperationException.With.Message.Contains("ApiClient:BaseUrl"));
        });
    }

    [Test]
    public void OAuthFailureDoesNotExposeClientSecretOrResponseBody()
    {
        const string sensitiveBody = "sensitive-oauth-response";
        var provider = new AccessTokenProvider(
            new HttpClient(new StubHttpMessageHandler(_ =>
                JsonResponse(HttpStatusCode.Unauthorized, sensitiveBody))),
            ValidOAuthConfig(),
            new StubSecretProvider("sensitive-client-secret"));

        var exception = Assert.ThrowsAsync<AuthenticationFlowException>(
            async () => await provider.GetAccessTokenAsync());

        Assert.Multiple(() =>
        {
            Assert.That(exception!.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(exception.ToString(), Does.Not.Contain(sensitiveBody));
            Assert.That(exception.ToString(), Does.Not.Contain("sensitive-client-secret"));
        });
    }

    [Test]
    public void PingFailureDoesNotExposeCredentialsOrResponseBody()
    {
        const string sensitiveBody = "sensitive-provider-response";
        var handler = new StubHttpMessageHandler(request =>
        {
            if (request.Method == HttpMethod.Post)
            {
                return JsonResponse(HttpStatusCode.OK, """{"access_token":"bootstrap-token"}""");
            }

            return JsonResponse(HttpStatusCode.InternalServerError, sensitiveBody);
        });
        var config = ValidPingConfig();
        var provider = new PingSecretProvider(new HttpClient(handler), config);

        var exception = Assert.ThrowsAsync<AuthenticationFlowException>(
            async () => await provider.GetSecretAsync("oauth-secret-id"));

        Assert.Multiple(() =>
        {
            Assert.That(exception!.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(exception.ToString(), Does.Not.Contain(sensitiveBody));
            Assert.That(exception.ToString(), Does.Not.Contain(config.BootstrapClientSecret));
            Assert.That(exception.ToString(), Does.Not.Contain("bootstrap-token"));
        });
    }

    [Test]
    public void NonSuccessApiResponseFailsWithoutExposingResponseBody()
    {
        const string sensitiveBody = "upstream-sensitive-response";
        var service = CreateAuthenticatedApiService(
            new StubHttpMessageHandler(_ =>
                JsonResponse(HttpStatusCode.BadRequest, sensitiveBody)));

        var exception = Assert.ThrowsAsync<ApiRequestException>(
            async () => await service.PostJsonAsync<object, ClientSearchResponse>(
                "search",
                new { }));

        Assert.Multiple(() =>
        {
            Assert.That(exception!.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(exception.ToString(), Does.Not.Contain(sensitiveBody));
            Assert.That(exception.Message, Does.Contain("HTTP 400"));
        });
    }

    [Test]
    public void SuccessfulNonJsonResponseFailsExplicitly()
    {
        var service = CreateAuthenticatedApiService(
            new StubHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("<html>login</html>", Encoding.UTF8, "text/html")
                }));

        var exception = Assert.ThrowsAsync<ApiRequestException>(
            async () => await service.PostJsonAsync<object, ClientSearchResponse>(
                "search",
                new { }));

        Assert.That(exception!.Message, Does.Contain("unsupported content type 'text/html'"));
    }

    [Test]
    public void MalformedOrIncompatibleJsonFailsExplicitly()
    {
        var service = CreateAuthenticatedApiService(
            new StubHttpMessageHandler(_ =>
                JsonResponse(HttpStatusCode.OK, """{"count":"not-a-number"}""")));

        var exception = Assert.ThrowsAsync<ApiRequestException>(
            async () => await service.PostJsonAsync<object, CountResponse>(
                "search",
                new { }));

        Assert.That(exception!.Message, Does.Contain("malformed or incompatible JSON"));
    }

    [Test]
    public async Task TransientRetriesUseTheSingleApiServicePath()
    {
        var attempts = 0;
        var handler = new StubHttpMessageHandler(_ =>
        {
            attempts++;
            return attempts == 1
                ? JsonResponse(HttpStatusCode.ServiceUnavailable, """{"error":"temporary"}""")
                : JsonResponse(HttpStatusCode.OK, """{"count":2}""");
        });
        var service = CreateAuthenticatedApiService(handler, maxAttempts: 2);

        var response = await service.PostJsonAsync<object, CountResponse>(
            "search",
            new { },
            ApiRetryMode.IdempotentTransient);

        Assert.Multiple(() =>
        {
            Assert.That(attempts, Is.EqualTo(2));
            Assert.That(response.Count, Is.EqualTo(2));
        });
    }

    [Test]
    public void ApiStepAssertionsPropagateToTheScenario()
    {
        var steps = new ApiSteps(new StubApiService(
            new ClientSearchResponse
            {
                FirstName = "Different",
                LastName = "Person"
            }));
        var table = new Table(
            "FirstName",
            "LastName",
            "DOB",
            "Email",
            "PhoneNumber");
        table.AddRow(
            "Ada",
            "Lovelace",
            "12/10/1815",
            "ada@example.test",
            "5555550100");

        Assert.ThrowsAsync<MultipleAssertException>(
            async () => await steps.SearchNewOrExistingClient(table));
    }

    [Test]
    public void ApiStepRequestErrorsPropagateToTheScenario()
    {
        var expected = new ApiRequestException("safe failure", HttpStatusCode.BadGateway);
        var steps = new ApiSteps(new ThrowingApiService(expected));
        var table = new Table(
            "FirstName",
            "LastName",
            "DOB",
            "Email",
            "PhoneNumber");
        table.AddRow("Ada", "Lovelace", "", "", "");

        var actual = Assert.ThrowsAsync<ApiRequestException>(
            async () => await steps.SearchNewOrExistingClient(table));

        Assert.That(actual, Is.SameAs(expected));
    }

    private static OAuthConfig ValidOAuthConfig() => new()
    {
        TokenUrl = "https://identity.example.test/token",
        ClientId = "client-id",
        PingSecretId = "oauth-secret-id"
    };

    private static PingSecretConfig ValidPingConfig() => new()
    {
        TokenEndpoint = "https://identity.example.test/token",
        SecretEndpoint = "https://secrets.example.test/secrets",
        BootstrapClientId = "bootstrap-id",
        BootstrapClientSecret = "bootstrap-secret"
    };

    private static ApiService CreateAuthenticatedApiService(
        HttpMessageHandler handler,
        int maxAttempts = 1)
    {
        var service = CreateApiService(handler, maxAttempts);
        service.SetAccessToken(new AccessToken("scenario-token", DateTimeOffset.UtcNow.AddMinutes(5)));
        return service;
    }

    private static ApiService CreateApiService(
        HttpMessageHandler handler,
        int maxAttempts = 1)
    {
        var client = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.example.test/")
        };
        return new ApiService(
            client,
            new ApiClientConfig
            {
                BaseUrl = client.BaseAddress.AbsoluteUri,
                MaxTransientAttempts = maxAttempts,
                RetryDelayMilliseconds = 0
            });
    }

    private static HttpResponseMessage JsonResponse(
        HttpStatusCode statusCode,
        string content) =>
        new(statusCode)
        {
            Content = new StringContent(content, Encoding.UTF8, "application/json")
        };

    private sealed class CountResponse
    {
        public int Count { get; init; }
    }

    private sealed class StubSecretProvider : IPingSecretProvider
    {
        private readonly string _secret;

        public StubSecretProvider(string secret)
        {
            _secret = secret;
        }

        public string? RequestedSecretId { get; private set; }

        public Task<string> GetSecretAsync(
            string secretId,
            CancellationToken cancellationToken = default)
        {
            RequestedSecretId = secretId;
            return Task.FromResult(_secret);
        }
    }

    private sealed class StubApiService : IApiService
    {
        private readonly ClientSearchResponse _response;

        public StubApiService(ClientSearchResponse response)
        {
            _response = response;
        }

        public bool HasAccessToken => true;

        public void SetAccessToken(AccessToken accessToken)
        {
        }

        public Task<TResponse> PostJsonAsync<TRequest, TResponse>(
            string endpoint,
            TRequest request,
            ApiRetryMode retryMode = ApiRetryMode.None,
            CancellationToken cancellationToken = default) =>
            Task.FromResult((TResponse)(object)_response);
    }

    private sealed class ThrowingApiService : IApiService
    {
        private readonly ApiRequestException _exception;

        public ThrowingApiService(ApiRequestException exception)
        {
            _exception = exception;
        }

        public bool HasAccessToken => true;

        public void SetAccessToken(AccessToken accessToken)
        {
        }

        public Task<TResponse> PostJsonAsync<TRequest, TResponse>(
            string endpoint,
            TRequest request,
            ApiRetryMode retryMode = ApiRetryMode.None,
            CancellationToken cancellationToken = default) =>
            Task.FromException<TResponse>(_exception);
    }

    private sealed class StubHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _handler;

        public StubHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> handler)
        {
            _handler = handler;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken) =>
            Task.FromResult(_handler(request));
    }
}
