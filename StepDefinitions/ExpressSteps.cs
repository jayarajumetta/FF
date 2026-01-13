
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Configuration;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;
using Reqnroll;
using System;
using System.Threading.Tasks;
using TestAutomation.Pages.ExpressPages;
using ReqContext = Playwright_POC.Context.TestContext;

[Binding]
public class ExpressSteps
{
    private readonly ReqContext _context;
    private readonly ExpressCredentialsConfig _expressCreds;
    private readonly IConfiguration _configuration;
    private readonly ScenarioContextData _contextData;
    private Table _table;

    public ExpressSteps(ReqContext context,
                        ExpressCredentialsConfig expressCreds,
                        IConfiguration configuration,
                        ScenarioContextData contextData)
    {
        _context = context;
        _expressCreds = expressCreds;
        _configuration = configuration;
        _contextData = contextData;
    }

    
    [Then("user enters QAExpress credentials and Clicks LogIn")]
    public async Task WhenIEnterQAExpressCredentialsAndClickLogIn()
    {
        var expressUrl = _configuration["Playwright:QAExpress"];
        await _context.Page.GotoAsync(expressUrl, new() {  WaitUntil = WaitUntilState.NetworkIdle});

        var loginPage = new ExpressLoginPage(_context.Page);
        string username = _expressCreds.Username;
        string password = _expressCreds.Password;

        await loginPage.ExpressLoginAsync(username, password);

        _contextData.QuoteNumber = System.IO.File.ReadAllText("QuoteNumber.txt");
        Console.WriteLine($"Quote Number: {_contextData.QuoteNumber}");
        Assert.That(await loginPage.IsDefaultViewModelVisibleAsync(), Is.True, "Default View Model is not visible after login.");
    }
    [Then("user selects search type from dropdown and enters quote number and clicks search")]
    public async Task ThenUserEntersQuoteNumberAndClicksSearch(Table table)
    {
        TableMappingHelpers.SearchExpress(table, _contextData);
        var searchType = _contextData.SearchType;
        var quoteNumber = _contextData.QuoteNumber; 
        var home = new ExpressHomePage(_context.Page);
        Console.WriteLine($"Search Type: {searchType}, Quote Number: {quoteNumber}");
        await home.SelectSearchTypeAsync(searchType);
        await home.EnterQuoteNumber(quoteNumber);
        await home.ClickSearchButtonAsync();
    }
}
