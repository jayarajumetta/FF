using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Configuration;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Locators;
using Playwright_POC.Pages;
using Playwright_POC.Pages.ExpertQuotePages;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TestAutomation.Pages.ExpertQuotePages;
using static System.Net.Mime.MediaTypeNames;
using ReqContext = Playwright_POC.Context.TestContext;


[Binding]

public class SFPSteps
{
    private readonly ReqContext _context;
    private readonly ScenarioContextData _contextData;
    private readonly CredentialsConfig _credentials;
    private readonly IConfiguration _configuration;
    private readonly ScenarioContext _scenarioContext;


    public SFPSteps(ReqContext context, ScenarioContext scenarioContext, CredentialsConfig credentials, IConfiguration configuration)
    {
        _context = context;
        _scenarioContext = scenarioContext;
        _contextData = _scenarioContext["ContextData"] as ScenarioContextData;
        _credentials = credentials;
        _configuration = configuration;
    }


    [When("user selects Special Farm Package and inputs Quote Details")]
    public async Task SelectSpecialFarmPackageAndInputQuoteDetails(Table table)
    {
        TableMappingHelpers.BOPQuoteDetailsFields(table, _contextData);
        var proposalDetailsPage = new QuoteDetailsPage(_context.Page);
        await proposalDetailsPage.WaitForProposalPageLoadAsync();
        await proposalDetailsPage.SelectSpecialFarmPackageProductAsync();
        await proposalDetailsPage.EnterSFPQuoteDetailsAsync(_contextData);
        await proposalDetailsPage.SelectRatingStateAsync(_contextData);
        await proposalDetailsPage.SelectRiskAddressAsync(_contextData);
        await proposalDetailsPage.ClickStartQuoteAsync();
        await proposalDetailsPage.HandleSSNPopupsAsync(_contextData);
        await proposalDetailsPage.HandleClientExistsPopupAsync();
        Console.WriteLine($"Client {_contextData.ClientFirstName}");
    }

    [When("user enters SFP policy details and clicks Next button")]
    public async Task UserEntersSFPPolicyDetailsAndClicksNext(Table table)
    {
        TableMappingHelpers.SFPPolicyDataFields(table, _contextData);
        var sfpPolicyDetailsPage = new PolicyDetailsPage(_context.Page);
        await sfpPolicyDetailsPage.SelectPrimaryFarmType(_contextData.PrimaryFarmType);
        await sfpPolicyDetailsPage.SelectLivestockType(_contextData.LivestockType);
        await sfpPolicyDetailsPage.EnterGrossFarmIncome(_contextData.GrossFarmIncome);
        await sfpPolicyDetailsPage.SelectGrowIndustrialHemp(_contextData.GrowIndustrialHemp);
        await Helpers.ClickNextAsync(_context.Page);
        Console.WriteLine($"Client {_contextData.ClientFirstName}");
    }

    [When("user Validates Primary Insured Information for SFP and continues")]
    public async Task UserValidatesPrimaryInsuredInformationForSFPAndContinues()
    {
        var primaryInsuredPage = new PrimaryInsuredPage(_context.Page);
        await primaryInsuredPage.ValidatePrimaryInsuredDetailsAsync(_contextData);
        await Helpers.WaitForSpinnerToClearAsync(_context.Page);
        await Helpers.ClickSaveAsync(_context.Page);
    }

    [When("user answers UW Questions and continues")]
    public async Task UserAnswersUWQuestionsAndContinues(Table table)
    {

        var states = TableMappingHelpers.MapYesNoTableToBool(table);

        var primaryInsuredPage = new PrimaryInsuredPage(_context.Page);
        await primaryInsuredPage.AnswerUwQuestionsAsync(states, clickNext: true);


    }

    [When("user enters Claims and Prior Insurance Information and continues")]
    public async Task UserEntersClaimsAndPriorInsuranceInformationAndContinues(Table table)
    {
        var claimsViolationsPage = new ClaimsViolationsPage(_context.Page);
        TableMappingHelpers.ClaimsAndPriorInsuranceFields(table, _contextData);
        await claimsViolationsPage.SetExposuresInsuredAN90DaysAsync(_contextData.PriorFFANPolicy);
        await claimsViolationsPage.EnterYearsInBusinessAsync(_contextData.YearsInBusiness);
        await Helpers.ClickNextAsync(_context.Page);
    }


    [When("user validates Client Details and continues")]
    public async Task UserValidatesClientDetailsAndContinues()
    {
        var clientDetailsPage = new ClientDetailsPage(_context.Page);
        await clientDetailsPage.VerifyClientName(_contextData.ClientFirstName, _contextData.ClientLastName);
        await clientDetailsPage.VerifyClientStreetAddress(_contextData.StreetAddress);
        //await clientDetailsPage.VerifyClientPhone(_contextData.ClientPhoneNumber);
        await Helpers.ClickNextAsync(_context.Page);
    }

    [When("user Adds Narrative and continues")]
    public async Task UserAddsNarrativeAndContinues(Table table)
    {
        var narrativePage = new NarrativePage(_context.Page);
        TableMappingHelpers.NarrativeFields(table, _contextData);
        await narrativePage.ClickAddNarrativeButtonAsync();
        await narrativePage.EnterNarrativeAndClickSaveAsync(_contextData.Narrative);
        await Helpers.ClickNextAsync(_context.Page);
    }

    [When("user selects Policy Wide or Division Specific Coverages and continues")]
    public async Task UserselectsPolicyWideDivisionSpecificCoveragesAndContinues(Table table)
    {
        var coverageCatalogPage = new PolicyWideDivisionSpecificCoveragePage(_context.Page);
        await coverageCatalogPage.ApplySelectionsAndAddCoveragesAsync(table);
        await Helpers.ClickNextAsync(_context.Page);
    }

    [When("user provides location information and continues")]
    public async Task UserProvidesLocationInformationAndContinues(Table table)
    {
        TableMappingHelpers.LocationInformationFields(table, _contextData);

        var locationPage = new LocationPage(_context.Page, _contextData);
        await locationPage.EnterLocationInformationAsync();
        await locationPage.SelectWindHailDeductibleAsync(_contextData.WindHailDeductible);

        await Helpers.ClickSaveAsync(_context.Page);
    }
}