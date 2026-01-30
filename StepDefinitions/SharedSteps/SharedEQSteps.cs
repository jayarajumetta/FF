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

public class SharedEQSteps
{
    private readonly ReqContext _context;
    private readonly ScenarioContextData _contextData;
    private readonly CredentialsConfig _credentials;
    private readonly IConfiguration _configuration;
    private Table _table;

    public SharedEQSteps(ReqContext context, ScenarioContextData contextData, CredentialsConfig credentials, IConfiguration configuration)
    {
        _context = context;
        _contextData = contextData;
        _credentials = credentials;
        _configuration = configuration;
    }


    [When("I enter valid credentials and Click LogIn")]
    public async Task WhenIEnterValidCredentials()
    {
        string username = _credentials.Username;
        string password = _credentials.Password;

        var loginPage = new ExpertQuoteLoginPage(_context.Page);
        await loginPage.LoginAsync(username, password);

        // Wait for login to complete and assert dashboard is visible
        Assert.That(await loginPage.IsDashboardVisibleAsync(), Is.True);
    }



    [Then("user enters a name in the search field and clicks search")]
    public async Task ThenUserEntersANameInTheSearchField(Table table)
    {
        TableMappingHelpers.ClientSearchFields(table, _contextData);

        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";
        var clientSearchPage = new ClientSearchPage(_context.Page);

        await clientSearchPage.EnterNameAndSearchAsync(name);

        string clientName = $"{_contextData.ClientLastName}, {_contextData.ClientFirstName}";
        string tableSelector = "table";

        // Uncomment if you want to use the assertion
        // await clientSearchPage.AssertNameNotInTableAsync(tableSelector, clientName);
    }

    [Then("user enters a Random Name in the search field and clicks search")]

    public async Task ThenUserEntersARandomNameInTheSearchField(Table table)
    {
        // Keep current mapping to _contextData
        TableMappingHelpers.ClientSearchFields(table, _contextData);

        // Replace tokens with generated values
        // Supports: {{male}}, {{female}} for first names; {{random}} for last names
        if (string.Equals(_contextData.ClientFirstName, "{{male}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientFirstName = RandomGenerators.GenerateRandomFirstName();

        if (string.Equals(_contextData.ClientFirstName, "{{female}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientFirstName = RandomGenerators.GenerateRandomFemaleFirstName();

        if (string.Equals(_contextData.ClientLastName, "{{random}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientLastName = RandomGenerators.GenerateRandomLastName();

        // Build full name and perform the search
        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";
        var clientSearchPage = new ClientSearchPage(_context.Page);

        await clientSearchPage.EnterNameAndSearchAsync(name);

        // Keep follow-on format for assertions
        string clientName = $"{_contextData.ClientLastName}, {_contextData.ClientFirstName}";


    }


    [Then("user clicks New Quote button")]
    public async Task ThenUserClicksNewQuoteButton()
    {
        await ClientSearchLocators.NewQuoteButton(_context.Page).ClickAsync();
    }



    [Then("user enters client information and clicks search")]
    public async Task AndUserEntersClientInformationAndClicksSearch(Table table)
    {
        TableMappingHelpers.NewExistingClientFields(table, _contextData);

        // Replace tokens with generated values
        // Supports: {{randomDOB}} for DOB (21-65 years old), {{randomPhone}} for phone, {{randomEmail}} for email
        if (string.Equals(_contextData.ClientDOB, "{{randomDOB}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientDOB = RandomGenerators.GenerateRandomDOB();

        if (string.Equals(_contextData.ClientPhoneNumber, "{{randomPhone}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientPhoneNumber = RandomGenerators.GenerateRandomPhoneNumber();

        if (string.Equals(_contextData.ClientEmail, "{{randomEmail}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientEmail = RandomGenerators.GenerateRandomEmail(_contextData.ClientFirstName, _contextData.ClientLastName);

        var newClientPage = new NewClientPage(_context.Page);

        await newClientPage.WaitForFirstNameInputAsync();
        await newClientPage.FillFirstNameAsync(_contextData.ClientFirstName);
        await newClientPage.FillLastNameAsync(_contextData.ClientLastName);
        await newClientPage.FillDOBAsync(_contextData.ClientDOB);
        await newClientPage.FillBestPhoneAsync(_contextData.ClientPhoneNumber);
        await newClientPage.FillEmailAsync(_contextData.ClientEmail);
        await newClientPage.ClickSearchAsync();
        await newClientPage.WaitForNextButtonAsync();
    }


    [Then("user selects Create New Client and clicks the Next button")]
    public async Task UserCreatesNewClientAndClicksNext()
    {
        await NewExistingClientSearchLocators.CreateNewClientButton(_context.Page).ClickAsync();
        await GlobalLocators.NextButton(_context.Page).ClickAsync();

        //Wait for the next page to load
        await _context.Page.WaitForLoadStateAsync(LoadState.Load);
        await _context.Page.WaitForSelectorAsync(AccountInformationConstLocators.PageHeader(_context.Page).ToString(), new() { Timeout = 10000 });
    }


    [Then("user enters account owner information and clicks Next")]
    public async Task EnterAccountOwnerInfo(Table table)
    {
        TableMappingHelpers.AccountOwnerFields(table, _contextData);

        var accountInformationPage = new AccountOwnerInfoPage(_context.Page);

        // Modular, explicit calls for each logical segment:
        await accountInformationPage.WaitForPageReadyAsync();
        await accountInformationPage.ValidateAndFillNameFieldsAsync(_contextData);
        await accountInformationPage.ValidateAndFillContactFieldsAsync(_contextData);
        await accountInformationPage.SelectMaritalStatusAsync(_contextData.MaritalStatus);
        await accountInformationPage.FillAddressFieldsAsync(_contextData);
        await accountInformationPage.WaitForAddressDetailsAsync();
        await accountInformationPage.AnswerMailAndResidenceQuestionsAsync(_contextData);
        await accountInformationPage.ClickNextAsync();
    }

    [Then("user enters Pre-Qualification information and continues")]
    public async Task WhenUserEntersPreQualificationInfoAndContinuesAsync(Table table)
    {
        TableMappingHelpers.PreQualificationFields(table, _contextData);

        var preQualificationPage = new PreQualificationPage(_context.Page);
        await preQualificationPage.EnterPreQualificationInfoAndContinueAsync(_contextData.EligibilityRestrictions);
    }

    [Then("user selects Primary Insured and continues")]
    public async Task UserSelectsPrimaryInsuredAsync()
    {
        var primaryInsuredPage = new PrimaryInsuredPage(_context.Page);
        await primaryInsuredPage.SelectExistingClientAsPrimaryInsuredAsync(_contextData);
    }



    [Then("user creates a new Billing Account and Submits payment")]
    public async Task UserCreatesBillingAccountAndSubmitsPaymentAsync(Table table)
    {
        TableMappingHelpers.BillingAccountFields(table, _contextData);

        var billingPage = new BillingPage(_context.Page);
        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";

        await billingPage.ClickCreateNewBillingAccountAsync();
        await billingPage.SelectPrimaryPayerAsync(name);
        await billingPage.SelectPaymentTypeAsync(_contextData.PaymentType);
        await billingPage.WaitForPaymentPlanAsync(_contextData.PaymentPlan);
        await billingPage.SelectPaymentPlanAsync(_contextData.PaymentPlan);
        await billingPage.WaitForPaymentDueDateInputAsync();
        await billingPage.EnterPaymentDueDateAsync(_contextData.PaymentDueDate);
        await billingPage.SelectPaymentAmountAsync(_contextData.PaymentAmount);
        await billingPage.SelectPaymentMethodAsync(_contextData.PaymentMethod);
        await billingPage.EnterCheckNumberAsync(_contextData.CheckNumber);
        await billingPage.SelectPaperlessCommunicationAsync(_contextData.Paperless);
        await billingPage.ClickNextAsync();
        billingPage.DisplayQuoteNumber(_contextData.QuoteNumber);
        System.IO.File.WriteAllText("QuoteNumber.txt", _contextData.QuoteNumber ?? "");
    }

}