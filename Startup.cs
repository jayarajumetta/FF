using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Models;
using PnCTestAutomation.Pages;
using PnCTestAutomation.Pages.ExpertQuotePages;
using PnCTestAutomation.Services;
using PnCTestAutomation.Clients;
using PnCTestAutomation.Pages.ExpressPages;
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

            // Scenario-scoped NavigationService (resolved in step constructors)
            services.AddScoped<NavigationService>();

            // ⚠️ CRITICAL: Page objects MUST be Transient, never Singleton
            // Singleton = all scenarios share the same page object instance = state bleed between tests ❌
            // Transient = each step/scenario gets a fresh page object = clean isolated tests ✅
            // This prevents cross-scenario contamination and flaky tests from leftover state.
            services.AddSingleton<ApiHeaders>();
            services.AddTransient<ScenarioContextData>();
            services.AddTransient<AccountOwnerInfoPage>();
            services.AddTransient<PA_AddAdditionalInterestPage>();
            services.AddTransient<PA_AddDriverInfoPage>();
            services.AddTransient<PA_AddVehicleInfoPage>();
            services.AddTransient<BillingPage>();
            services.AddTransient<ClientSearchPage>();
            services.AddTransient<PA_DiscountsPage>();
            services.AddTransient<ExpertQuoteLoginPage>();
            services.AddTransient<NewClientPage>();
            services.AddTransient<PA_PolicyCoveragesPage>();
            services.AddTransient<PreQualificationPage>();
            services.AddTransient<PA_PricingDetailsPage>();
            services.AddTransient<QuoteDetailsPage>();
            services.AddTransient<PA_AdditionalCoveragesPage>();
            services.AddTransient<SFP_EditLocationPage>();
            services.AddTransient<ExpressLoginPage>();

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
