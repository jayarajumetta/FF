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
using ReqContext = Playwright_POC.Context.TestContext;


[Binding]

public class SFPSteps
{

    private readonly ReqContext _context;
    private readonly ScenarioContextData _contextData;
    private readonly CredentialsConfig _credentials;
    private readonly IConfiguration _configuration;
    private Table _table;


    public SFPSteps(ReqContext context, ScenarioContextData contextData, CredentialsConfig credentials, IConfiguration configuration)
    {
        _context = context;
        _contextData = contextData;
        _credentials = credentials;
        _configuration = configuration;

    }


    [Then("user selects Special Farm Package and inputs Quote Details")]
    public async Task SelectSpecialFarmPackageAndInputQuoteDetails(Table table)
    {
        TableMappingHelpers.BOPQuoteDetailsFields(table, _contextData);
        var proposalDetailsPage = new QuoteDetailsPage(_context.Page);
        await proposalDetailsPage.WaitForProposalPageLoadAsync();
        await proposalDetailsPage.SelectSpecialFarmPackageProductAsync();
        await proposalDetailsPage.CheckSpecialFarmPackageSelected();
        await proposalDetailsPage.EnterSFPQuoteDetailsAsync(_contextData);
        await proposalDetailsPage.SelectRatingStateAsync(_contextData);
        await proposalDetailsPage.SelectRiskAddressAsync(_contextData);
        await proposalDetailsPage.ClickStartQuoteAsync();
        await proposalDetailsPage.HandleSSNPopupsAsync(_contextData);
        await proposalDetailsPage.HandleClientExistsPopupAsync();
    }

    [Then("user enters SFP policy details and clicks Next button")]
    public async Task UserEntersSFPPolicyDetailsAndClicksNext(Table table)
    {
        TableMappingHelpers.SFPPolicyDataFields(table, _contextData);
        var sfpPolicyDetailsPage = new PolicyDetailsPage(_context.Page);
        await sfpPolicyDetailsPage.SelectPrimaryFarmType(_contextData.PrimaryFarmType);
        await sfpPolicyDetailsPage.SelectLivestockType(_contextData.LivestockType);
        await sfpPolicyDetailsPage.EnterGrossFarmIncome(_contextData.GrossFarmIncome);
        await sfpPolicyDetailsPage.SelectGrowIndustrialHemp(_contextData.GrowIndustrialHemp);
        await GlobalLocators.NextButton(_context.Page).ClickAsync();


    }
}