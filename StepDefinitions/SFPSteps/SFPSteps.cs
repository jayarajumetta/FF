using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Configuration;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
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
        var sfpPolicyDetailsPage = new SFP_PolicyDetailsPage(_context.Page);
        await sfpPolicyDetailsPage.SelectPrimaryFarmType(_contextData.PrimaryFarmType);
        await sfpPolicyDetailsPage.SelectLivestockType(_contextData.LivestockType);
        await sfpPolicyDetailsPage.EnterGrossFarmIncome(_contextData.GrossFarmIncome);
        await sfpPolicyDetailsPage.SelectGrowIndustrialHemp(_contextData.GrowIndustrialHemp);
        await sfpPolicyDetailsPage.ClickNextAsync();
        Console.WriteLine($"Client {_contextData.ClientFirstName}");
    }

    [When("user Validates Primary Insured Information for SFP and continues")]
    public async Task UserValidatesPrimaryInsuredInformationForSFPAndContinues()
    {
        var primaryInsuredPage = new PrimaryInsuredPage(_context.Page);
        await primaryInsuredPage.ValidatePrimaryInsuredDetailsAsync(_contextData);
        await primaryInsuredPage.WaitForSpinnerAsync();
        await _context.Page.GetByTestId("fields.data_Actions.save").ClickAsync();
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
        var claimsPriorInsurancePage = new ClaimsPriorInsurancePage(_context.Page);
        TableMappingHelpers.ClaimsAndPriorInsuranceFields(table, _contextData);
        await claimsPriorInsurancePage.SetExposuresInsuredAN90DaysAsync(_contextData.PriorFFANPolicy);
        await claimsPriorInsurancePage.EnterYearsInBusinessAsync(_contextData.YearsInBusiness);
        await claimsPriorInsurancePage.ClickNextAsync();
    }


    [When("user validates Client Details and continues")]
    public async Task UserValidatesClientDetailsAndContinues()
    {
        var clientDetailsPage = new SFP_ClientDetailsPage(_context.Page);
        await clientDetailsPage.VerifyClientNameAsync(_contextData.ClientFirstName, _contextData.ClientLastName);
        await clientDetailsPage.VerifyClientStreetAddressAsync(_contextData.StreetAddress);
        //await clientDetailsPage.VerifyClientPhoneAsync(_contextData.ClientPhoneNumber);
        await clientDetailsPage.ClickNextAsync();
    }
}