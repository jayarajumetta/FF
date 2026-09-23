using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.BusinessOutcomes;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Context;
using PnCTestAutomation.Controls;
using PnCTestAutomation.DataPool;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Integrations;
using PnCTestAutomation.Models;
using PnCTestAutomation.Pages;
using PnCTestAutomation.Pages.ExpertQuotePages;
using PnCTestAutomation.Products;
using PnCTestAutomation.QuoteHandoffs;
using PnCTestAutomation.Reporting;
using PnCTestAutomation.Services;
using PnCTestAutomation.Clients;
using PnCTestAutomation.TestPlans;
using Reqnroll;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PnCTestAutomation
{
    // This is a DI composition root for a NUnit/Reqnroll test runner, not a web application.
    // Only ConfigureServices() is invoked via [ScenarioDependencies]. There is no ASP.NET Core
    // HTTP pipeline, no Kestrel host, and no HTTP responses. HSTS (CWE-346) does not apply.
    [SuppressMessage("Security", "CWE-346",
        Justification = "Not a web application. This class is a Reqnroll DI composition root. " +
                        "No HTTP server or pipeline exists; HSTS is inapplicable.")]
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            var env = Environment.GetEnvironmentVariable("TEST_ENVIRONMENT") ?? "QA";
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(configPath)
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory, $"appsettings.{env}.json"), optional: true)
                .AddEnvironmentVariables()
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IProductModule, SfpProductModule>();
            services.AddSingleton<IProductModule, ExpertQuoteBopSmokeModule>();
            services.AddSingleton<IProductModuleRegistry, ProductModuleRegistry>();
            services.AddSingleton(_ =>
                SgsExecutionCatalog.Load(Path.Combine(AppContext.BaseDirectory, "Resources")));

            var credentials = configuration.GetSection("Credentials").Get<CredentialsConfig>();
            if (credentials != null)
            {
                credentials.Username =
                    GetEnvironmentValue("EQ_USERNAME", credentials.Username);
                credentials.Password =
                    GetEnvironmentValue("EQ_PASSWORD", credentials.Password);
                services.AddSingleton(credentials);
            }

            var expressCreds = configuration.GetSection("QAExpressCreds").Get<ExpressCredentialsConfig>();
            if (expressCreds != null)
            {
                expressCreds.Username =
                    GetEnvironmentValue("EXPRESS_USERNAME", expressCreds.Username);
                expressCreds.Password =
                    GetEnvironmentValue("EXPRESS_PASSWORD", expressCreds.Password);
                services.AddSingleton(expressCreds);
            }

            var oauthConfig = configuration.GetSection("OAuthConfig").Get<OAuthConfig>()
                              ?? new OAuthConfig();
            OverrideFromEnvironment(oauthConfig);
            services.AddSingleton(oauthConfig);

            var pingSecretConfig = configuration.GetSection("PingSecret").Get<PingSecretConfig>()
                                   ?? new PingSecretConfig();
            OverrideFromEnvironment(pingSecretConfig);
            services.AddSingleton(pingSecretConfig);

            var apiClientConfig = configuration.GetSection("ApiClient").Get<ApiClientConfig>()
                                  ?? new ApiClientConfig();
            OverrideFromEnvironment(apiClientConfig);
            services.AddSingleton(apiClientConfig);

            var dataPoolConfig = configuration.GetSection("DataPool").Get<DataPoolClientConfig>()
                                 ?? new DataPoolClientConfig();
            OverrideFromEnvironment(dataPoolConfig);
            dataPoolConfig.Validate();
            services.AddSingleton(dataPoolConfig);

            var artifactOptions = configuration.GetSection("Artifacts").Get<ArtifactOptions>()
                                  ?? new ArtifactOptions();
            artifactOptions.RootPath = GetEnvironmentValue(
                "TEST_ARTIFACT_ROOT",
                artifactOptions.RootPath);
            artifactOptions.ProfileName = GetEnvironmentValue(
                "TEST_ARTIFACT_PROFILE",
                artifactOptions.ProfileName);
            artifactOptions.Validate();
            services.AddSingleton(artifactOptions);

            var businessOutcomeOptions = configuration
                .GetSection("BusinessOutcomes")
                .Get<BusinessOutcomeOptions>()
                ?? new BusinessOutcomeOptions();
            businessOutcomeOptions.ProfilePath = GetEnvironmentValue(
                "TEST_OUTCOME_PROFILE_PATH",
                businessOutcomeOptions.ProfilePath);
            businessOutcomeOptions.Validate();
            services.AddSingleton(businessOutcomeOptions);
            services.AddSingleton<IExpectedOutcomeProfileProvider,
                ExpectedOutcomeProfileProvider>();

            services.AddSingleton<BrowserFactory>();
            services.AddSingleton<PlaywrightContext>();

            services.AddHttpClient("PingSecret");
            services.AddHttpClient("OAuthToken");
            services.AddHttpClient("ScenarioApi", client =>
            {
                if (Uri.TryCreate(apiClientConfig.BaseUrl, UriKind.Absolute, out var baseUri))
                {
                    client.BaseAddress = baseUri;
                    client.DefaultRequestHeaders.Referrer =
                        new Uri(
                            $"{baseUri.GetLeftPart(UriPartial.Authority)}/expertquote/");
                    client.DefaultRequestHeaders.TryAddWithoutValidation(
                        "Origin",
                        baseUri.GetLeftPart(UriPartial.Authority));
                }

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation(
                    "User-Agent",
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) " +
                    "AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 " +
                    "Safari/537.36 Edg/142.0.0.0");
            });

            services.AddScoped<IPingSecretProvider>(provider =>
                new PingSecretProvider(
                    provider.GetRequiredService<IHttpClientFactory>()
                        .CreateClient("PingSecret"),
                    pingSecretConfig));
            services.AddScoped<IAccessTokenProvider>(provider =>
                new AccessTokenProvider(
                    provider.GetRequiredService<IHttpClientFactory>()
                        .CreateClient("OAuthToken"),
                    oauthConfig,
                    provider.GetRequiredService<IPingSecretProvider>()));
            services.AddScoped<IApiService>(provider =>
                new ApiService(
                    provider.GetRequiredService<IHttpClientFactory>()
                        .CreateClient("ScenarioApi"),
                    apiClientConfig));

            if (!string.IsNullOrWhiteSpace(dataPoolConfig.BaseUrl))
            {
                services.AddHttpClient<IDataPoolClient, DataPoolClient>(c =>
                    c.BaseAddress = new Uri(dataPoolConfig.BaseUrl));
            }
            else
            {
                services.AddSingleton<IDataPoolClient, UnavailableDataPoolClient>();
            }

            // Scenario-scoped NavigationService (resolved in step constructors)
            services.AddScoped<NavigationService>();

            // One ScenarioContextData per scenario, shared by every binding that touches it.
            // Some step classes inject it; others read ScenarioContext["ContextData"]. Both routes
            // have to return the same object, otherwise data written through one is invisible to
            // the other. TestHooks seeds the entry in [BeforeScenario] and this factory hands back
            // that same instance instead of minting a new one.
            services.AddTransient(provider =>
            {
                var scenarioContext = provider.GetRequiredService<ScenarioContext>();
                if (scenarioContext.ContainsKey(ScenarioContextData.ContextKey) &&
                    scenarioContext[ScenarioContextData.ContextKey] is ScenarioContextData existing)
                {
                    return existing;
                }

                var created = new ScenarioContextData();
                scenarioContext[ScenarioContextData.ContextKey] = created;
                return created;
            });
            services.AddScoped<IQuoteHandoff, ScenarioQuoteHandoff>();
            services.AddScoped<ISgsScenarioData, SgsScenarioData>();
            services.AddScoped<ScenarioReportPrivacy>();
            services.AddScoped(provider =>
                provider.GetRequiredService<ScenarioReportPrivacy>().CreateRedactor());
            services.AddScoped<ScenarioReportRecorder>();
            services.AddScoped<IArtifactContext>(provider =>
            {
                var scenarioContext = provider.GetRequiredService<ScenarioContext>();
                var scenarioId = NUnit.Framework.TestContext.CurrentContext.Test.ID;
                if (string.IsNullOrWhiteSpace(scenarioId))
                    scenarioId = scenarioContext.ScenarioInfo.Title;
                var automationId = ScenarioAutomationIdentity.Resolve(
                    scenarioContext.ScenarioInfo.Tags ?? [],
                    provider.GetRequiredService<FeatureContext>().FeatureInfo.Tags ?? [],
                    ScenarioAutomationIdentity.ResolveQualifier(
                        (scenarioContext.ScenarioInfo.Tags ?? [])
                            .Concat(provider.GetRequiredService<FeatureContext>().FeatureInfo.Tags ?? []),
                        scenarioContext.ScenarioInfo.Arguments));
                var testIdentity = automationId == null
                    ? null
                    : NUnit.Framework.TestContext.CurrentContext.Test.Name;

                return new ArtifactContext(
                    artifactOptions,
                    ArtifactRunIdentity.Current,
                    scenarioId,
                    automationId: automationId,
                    testIdentity: testIdentity);
            });
            services.AddScoped<IArtifactCaptureService, ArtifactCaptureService>();
            services.AddScoped<IControlEvidenceSink,
                ArtifactControlEvidenceSink>();
            services.AddScoped<ISemanticControlActions>(provider =>
                new SemanticControlActions(
                    provider.GetRequiredService<IControlEvidenceSink>()));
            services.AddScoped<IBusinessOutcomeContext, BusinessOutcomeContext>();
            services.AddScoped<IBusinessOutcomeVerifier, BusinessOutcomeVerifier>();
            // ── Forms Checking services ──
            var formsConfig = configuration.GetSection("DuckCreekForms").Get<DuckCreekFormsConfig>();
            if (formsConfig != null)
            {
                formsConfig.Username =
                    GetEnvironmentValue("DUCKCREEK_USERNAME", formsConfig.Username);
                formsConfig.Password =
                    GetEnvironmentValue("DUCKCREEK_PASSWORD", formsConfig.Password);
                formsConfig.CLASUsername =
                    GetEnvironmentValue("CLAS_USERNAME", formsConfig.CLASUsername);
                formsConfig.CLASPassword =
                    GetEnvironmentValue("CLAS_PASSWORD", formsConfig.CLASPassword);

                // Swap in Dev CLAS/server URLs when running against the Dev environment
                var envSetting = configuration["Environment"] ?? "QA";
                if (envSetting.Equals("Dev", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(formsConfig.CLASBaseUrlDev))
                        formsConfig.CLASBaseUrl = formsConfig.CLASBaseUrlDev;
                    if (!string.IsNullOrEmpty(formsConfig.ServerBaseUrlDev))
                        formsConfig.ServerBaseUrl = formsConfig.ServerBaseUrlDev;
                }

                services.AddSingleton(formsConfig);
            }
            else
            {
                // Provide a default so DI doesn't fail when config section is missing
                services.AddSingleton(new DuckCreekFormsConfig());
            }

            services.AddScoped<IFormsSessionProvider, SessionService>();
            services.AddScoped<IFormsValidationService, FormsValidationService>();
            services.AddScoped<IFormsEvidenceWriter, FormsEvidenceWriter>();
            services.AddScoped<IFormsOrchestrationService, FormsOrchestrationService>();
            services.AddHttpClient<IFormsApiClient, DuckCreekFormsClient>();
        }

        private static void OverrideFromEnvironment(OAuthConfig config)
        {
            config.TokenUrl = GetEnvironmentValue("OAUTH_TOKEN_URL", config.TokenUrl);
            config.ClientId = GetEnvironmentValue("OAUTH_CLIENT_ID", config.ClientId);
            config.PingSecretId = GetEnvironmentValue("PING_SECRET_ID", config.PingSecretId);
        }

        private static void OverrideFromEnvironment(PingSecretConfig config)
        {
            config.TokenEndpoint =
                GetEnvironmentValue("PING_TOKEN_ENDPOINT", config.TokenEndpoint);
            config.SecretEndpoint =
                GetEnvironmentValue("PING_SECRET_ENDPOINT", config.SecretEndpoint);
            config.BootstrapClientId =
                GetEnvironmentValue("PING_BOOTSTRAP_CLIENT_ID", config.BootstrapClientId);
            config.BootstrapClientSecret =
                GetEnvironmentValue("PING_BOOTSTRAP_CLIENT_SECRET", config.BootstrapClientSecret);
        }

        private static void OverrideFromEnvironment(ApiClientConfig config)
        {
            config.BaseUrl =
                GetEnvironmentValue("EXPERT_QUOTE_API_BASE_URL", config.BaseUrl);
        }

        private static void OverrideFromEnvironment(DataPoolClientConfig config)
        {
            config.BaseUrl = GetEnvironmentValue("DATAPOOL_BASE_URL", config.BaseUrl);
            config.ApiKey = GetEnvironmentValue("DATAPOOL_API_KEY", config.ApiKey);

            if (bool.TryParse(
                    Environment.GetEnvironmentVariable("DATAPOOL_REQUIRED"),
                    out var required))
            {
                config.Required = required;
            }

            if (bool.TryParse(
                    Environment.GetEnvironmentVariable("DATAPOOL_AUTO_START"),
                    out var autoStart))
            {
                config.AutoStart = autoStart;
            }
        }

        private static string GetEnvironmentValue(string name, string configuredValue) =>
            Environment.GetEnvironmentVariable(name) is { Length: > 0 } value
                ? value
                : configuredValue;
    }
}
