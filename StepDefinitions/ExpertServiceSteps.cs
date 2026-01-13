using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Configuration;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Locators;
using Playwright_POC.Pages;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ReqContext = Playwright_POC.Context.TestContext;



[Binding]
public class ExpertServiceSteps
{
    private readonly ReqContext _context;
    private readonly ScenarioContextData _contextData;
    private readonly CredentialsConfig _credentials;
    private readonly IConfiguration _configuration;
    private Table _table;


    public ExpertServiceSteps(ReqContext context, ScenarioContextData contextData, CredentialsConfig credentials, IConfiguration configuration)
    {
        _context = context;
        _contextData = contextData;
        _credentials = credentials;
        _configuration = configuration;

    }

    [Given("I navigate to the Expert Service login page")]
    public async Task GivenINavigateToLoginPage()
    {
        // Page is already initialized in TestHooks
        var url = _configuration["Playwright:ExpertService"];
        await _context.Page.GotoAsync(url);
        Assert.That(_context.Page, Is.Not.Null, "Page was not initialized in TestHooks.");
    }

    [When("I log in with valid Expert Service credentials")]
    public async Task WhenIEnterValidCredentials()
    {
    string username = _credentials.Username;
    string password = _credentials.Password;

    var loginPage = new ExpertQuoteLoginPage(_context.Page);
    await loginPage.LoginAsync(username, password);

    // Wait for login to complete and assert dashboard is visible (once locators are available)
    //Assert.That(await );
    }
}