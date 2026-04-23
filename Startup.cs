
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Playwright_POC.Configuration;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Models;
using Playwright_POC.Pages;
using Playwright_POC.Pages.ExpertQuotePages;
using Playwright_POC.Services;
using Playwright_POC.Clients;
using Playwright_POC.Pages.ExpressPages;
using System;
using System.IO;
using System.Net.Http;

namespace Playwright_POC
{
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
            services.AddSingleton<TestContext>();

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

            // Page objects and other services
            services.AddSingleton<ApiHeaders>();
            services.AddTransient<ScenarioContextData>();
            services.AddSingleton<AccountOwnerInfoPage>();
            services.AddSingleton<PA_AddAdditionalInterestPage>();
            services.AddSingleton<PA_AddDriverInfoPage>();
            services.AddSingleton<PA_AddVehicleInfoPage>();
            services.AddSingleton<BillingPage>();
            services.AddSingleton<ClientSearchPage>();
            services.AddSingleton<PA_DiscountsPage>();
            services.AddSingleton<ExpertQuoteLoginPage>();
            services.AddSingleton<NewClientPage>();
            services.AddSingleton<PA_PolicyCoveragesPage>();
            services.AddSingleton<PreQualificationPage>();
            services.AddSingleton<PA_PricingDetailsPage>();
            services.AddSingleton<QuoteDetailsPage>();
            services.AddSingleton<PA_AdditionalCoveragesPage>();
            services.AddSingleton<SFP_EditLocationPage>();
            services.AddSingleton<ExpressLoginPage>();

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
