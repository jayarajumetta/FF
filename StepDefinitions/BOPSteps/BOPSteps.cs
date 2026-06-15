using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages;
using PnCTestAutomation.Pages.ExpertQuotePages;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


[Binding]

public class BOPSteps
{

    private readonly PlaywrightContext _context;
    private readonly ScenarioContextData _contextData;

    public BOPSteps(PlaywrightContext context, ScenarioContextData contextData)
    {
        _context = context;
        _contextData = contextData;
    }

    [When("user selects Business Owners and inputs Quote Details")]
    public async Task SelectBusinessOwnersAndInputQuoteDetails(Table table)
    {
        TableMappingHelpers.BOPQuoteDetailsFields(table, _contextData);

        var proposalDetailsPage = new QuoteDetailsPage(_context.Page);

        await proposalDetailsPage.WaitForProposalPageLoadAsync();
        await proposalDetailsPage.SelectBusinessOwnerProductAsync();
        await proposalDetailsPage.EnterQuoteDetailsAsync(_contextData);
        await proposalDetailsPage.SelectBusinessEntityAsync(_contextData);
        await proposalDetailsPage.SelectLessorsRiskExposureAsync(_contextData);
        await proposalDetailsPage.SelectRatingStateAsync(_contextData);
        await proposalDetailsPage.SelectRiskAddressAsync(_contextData);
        await proposalDetailsPage.ClickStartQuoteAsync();
        await proposalDetailsPage.HandleSSNPopupsAsync(_contextData);
        await proposalDetailsPage.HandleClientExistsPopupAsync();
    }

    [When("user selects class codes and continues")]
    public async Task UserSelectesClassCodesAndContinues(Table table)
    {
        TableMappingHelpers.BOPPreQualificationFields(table, _contextData);

        var preQualificationPage = new PreQualificationPage(_context.Page);

        await preQualificationPage.SearchAddClassCodeAsync(_contextData);
        await preQualificationPage.TogglePrimaryOccupancySliderAsync();
        await preQualificationPage.SelectIndustryClassCodeRestrictionsAsync(_contextData);
        await preQualificationPage.ClickNextAsync();
    }

    [When("user Enters Primary Insured Information for BOP and continues")]
    public async Task UserEntersPrimaryInsuredInformationAndContinues(Table table)
    {
        // Map table data to context data and steps needed
    }

}
