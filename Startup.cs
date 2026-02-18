
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Playwright_POC.Configuration;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Models;
using Playwright_POC.Pages;
using Playwright_POC.Services;
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
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(configPath)
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
            services.AddSingleton<AddAdditionalInterestPage>();
            services.AddSingleton<AddDriverInfoPage>();
            services.AddSingleton<AddVehicleInfoPage>();
            services.AddSingleton<BillingPage>();
            services.AddSingleton<ClientSearchPage>();
            services.AddSingleton<DiscountsPage>();
            services.AddSingleton<ExpertQuoteLoginPage>();
            services.AddSingleton<NewClientPage>();
            services.AddSingleton<PolicyCoveragesPage>();
            services.AddSingleton<PreQualificationPage>();
            services.AddSingleton<PricingDetailsPage>();
            services.AddSingleton<QuoteDetailsPage>();
            services.AddSingleton<AdditionalCoveragesPage>();
            services.AddSingleton<ExpressLoginPage>();
        }
    }
}
