using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Context;
using PnCTestAutomation.DataPool;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Models;
using PnCTestAutomation.Pages;
using PnCTestAutomation.Pages.ExpertQuotePages;
using PnCTestAutomation.Services;
using PnCTestAutomation.Clients;
using Reqnroll;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;

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
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            var credentials = configuration.GetSection("Credentials").Get<CredentialsConfig>();
            if (credentials != null) services.AddSingleton(credentials);

            var expressCreds = configuration.GetSection("QAExpressCreds").Get<ExpressCredentialsConfig>();
            if (expressCreds != null) services.AddSingleton(expressCreds);

            var oauthConfig = configuration.GetSection("OAuthConfig").Get<OAuthConfig>();
            if (oauthConfig != null) services.AddSingleton(oauthConfig);

            services.AddSingleton<BrowserFactory>();
            services.AddSingleton<PlaywrightContext>();

            services.AddSingleton<PingSecretProvider>(provider =>
                new PingSecretProvider(
                    new HttpClient(),
                    "https://ssoqa.anico.com/as/token.oauth2",
                    "https://ssoqa.anico.com/secrets",
                    Environment.GetEnvironmentVariable("PING_BOOTSTRAP_CLIENT_ID"),
                    Environment.GetEnvironmentVariable("PING_BOOTSTRAP_CLIENT_SECRET")
                ));

            services.AddHttpClient<IApiService, ApiService>();

            // DataPool client — optional; silently no-ops if DataPool:BaseUrl is absent.
            var dataPoolUrl = configuration["DataPool:BaseUrl"];
            if (!string.IsNullOrWhiteSpace(dataPoolUrl))
            {
                services.AddHttpClient<IDataPoolClient, DataPoolClient>(c =>
                    c.BaseAddress = new Uri(dataPoolUrl));
            }
            else
            {
                // Register a no-op so dependants resolve without error when DataPool is not running.
                services.AddSingleton<IDataPoolClient, NullDataPoolClient>();
            }

            // Scenario-scoped NavigationService (resolved in step constructors)
            services.AddScoped<NavigationService>();

            services.AddSingleton<ApiHeaders>();

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

            // ── Forms Checking services ──
            var formsConfig = configuration.GetSection("DuckCreekForms").Get<DuckCreekFormsConfig>();
            if (formsConfig != null)
            {
                // Allow env-var override for the password so it's not committed to source control
                var envPassword = Environment.GetEnvironmentVariable("DUCKCREEK_PASSWORD");
                if (!string.IsNullOrEmpty(envPassword))
                    formsConfig.Password = envPassword;

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

            services.AddScoped<SessionService>();
            services.AddScoped<FormsValidationService>();
            services.AddHttpClient<DuckCreekFormsClient>();
        }
    }
}
