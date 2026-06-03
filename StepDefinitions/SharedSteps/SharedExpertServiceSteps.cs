using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;



[Binding]
public class SharedExpertServiceSteps
{
    private readonly PlaywrightContext _context;
    private readonly ScenarioContextData _contextData;
    private readonly CredentialsConfig _credentials;
    private readonly IConfiguration _configuration;

    public SharedExpertServiceSteps(PlaywrightContext context, ScenarioContextData contextData, CredentialsConfig credentials, IConfiguration configuration)
    {
        _context = context;
        _contextData = contextData;
        _credentials = credentials;
        _configuration = configuration;

    }

    [StepDefinition("I navigate to the Expert Service login page")]
    public async Task NavigateToExpertServiceLoginPage()
    {
        // Page is already initialized in TestHooks
        var url = _configuration["Playwright:ExpertService"];
        await _context.Page.GotoAsync(url);

        // Use Playwright Expect instead of NUnit Assert
        await Expect(_context.Page).Not.ToHaveURLAsync("about:blank");
    }

    [StepDefinition("I log in with valid Expert Service credentials")]
    public async Task EnterExpertServiceCredentialsAndLogin()
    {
        string username = _credentials.Username;
        string password = _credentials.Password;

        var loginPage = new ExpertQuoteLoginPage(_context.Page);
        await loginPage.LoginAsync(username, password);

        // Wait for login to complete and assert dashboard is visible (once locators are available)
        //Assert.That(await );
    }
}
