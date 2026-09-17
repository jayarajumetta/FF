
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages;
using Reqnroll;
using System;
using System.Threading.Tasks;
using PnCTestAutomation.Pages.ExpressPages;
using PnCTestAutomation.QuoteHandoffs;
using static Microsoft.Playwright.Assertions;

[Binding]
public class SharedExpressSteps
{
    private readonly PlaywrightContext _context;
    private readonly ExpressCredentialsConfig _expressCreds;
    private readonly IConfiguration _configuration;
    private readonly ScenarioContextData _contextData;
    private readonly IQuoteHandoff _quoteHandoff;

    public SharedExpressSteps(PlaywrightContext context,
                        ExpressCredentialsConfig expressCreds,
                        IConfiguration configuration,
                        ScenarioContextData contextData,
                        IQuoteHandoff quoteHandoff)
    {
        _context = context;
        _expressCreds = expressCreds;
        _configuration = configuration;
        _contextData = contextData;
        _quoteHandoff = quoteHandoff;
    }


    [StepDefinition("user enters QAExpress credentials and Clicks LogIn")]
    public async Task EnterQAExpressCredentialsAndLogin()
    {
        var expressUrl = _configuration["Playwright:QAExpress"];
        await _context.Page.GotoAsync(expressUrl, new() { WaitUntil = WaitUntilState.NetworkIdle });

        var loginPage = new ExpressLoginPage(_context.Page);
        string username = _expressCreds.Username;
        string password = _expressCreds.Password;

        await loginPage.ExpressLoginAsync(username, password);

        _quoteHandoff.Require(nameof(EnterQAExpressCredentialsAndLogin));

        // Use Playwright Expect for visibility assertion with auto-retry
        await Expect(loginPage.DefaultViewModelElement).ToBeVisibleAsync();
    }
    [StepDefinition("user selects search type from dropdown and enters quote number and clicks search")]
    public async Task UserSelectsSearchTypeAndEntersQuoteNumber(Table table)
    {
        TableMappingHelpers.SearchExpress(table, _contextData);
        var searchType = _contextData.SearchType;
        var quoteNumber = _quoteHandoff
            .Require(nameof(UserSelectsSearchTypeAndEntersQuoteNumber))
            .QuoteNumber;
        var home = new ExpressHomePage(_context.Page);
        Console.WriteLine($"Search Type: {searchType}, Quote Number: {quoteNumber}");
        await home.SelectSearchTypeAsync(searchType);
        await home.EnterQuoteNumber(quoteNumber);
        await home.ClickSearchButtonAsync();
    }
}
