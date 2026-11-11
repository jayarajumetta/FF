using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages;
using InsuranceAutomation.PLDC.Pages.Locators;

using Microsoft.Playwright;
using Reqnroll;

using static InsuranceAutomation.Core.ExecutionIntent;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InsuranceAutomation.PLDC.StepDefinitions;

[Binding, Scope(Feature = "Cycle Rate Filings Policy 1 NB 1")]
public sealed class CycleRateFilingsPolicy1NB1Steps
{
    private readonly ScenarioContext _scenario;
    public CycleRateFilingsPolicy1NB1Steps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I start New Quote$")]
    [When(@"^I start New Quote$")]
    [Then(@"^I start New Quote$")]
    public async Task StartNewQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForNewQuoteAsync("Exists");
        await page.VerifyNewQuoteAsync(data.Resolve("{{data:expected_btn_new_quote_2}}"), "");
        await page.ClickNewQuoteAsync();
    }

    [Given(@"^I select or create the policy client$")]
    [When(@"^I select or create the policy client$")]
    [Then(@"^I select or create the policy client$")]
    public async Task SelectOrCreateThePolicyClientAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        data.GenerateRandom("LastName_0098", "^[a-z]{7}$");
        data.GenerateRandom("FirstName_0098", "^[a-z]{4}$");
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForLblClientInfoAsync("Exists");
        await page.VerifyLblClientInfoAsync(data.Resolve("{{data:expected_lbl_client_info_5}}"), "");
        await page.EnterTxtFirstAsync(data.Resolve("{{data:AL_ClientData.First Name}}"));
        await page.EnterTxtLastAsync(data.Resolve("{{data:AL_ClientData.Last Name}}"));
        await page.WaitForAddEditAdditionalInterestFirstMortgageeSearchAsync("Exists");
        await page.ClickAddEditAdditionalInterestFirstMortgageeSearchAsync();
        await page.WaitForBtnCreateNewClientAsync("Exists");
        await page.ClickBtnCreateNewClientAsync();
        await page.ClickPricingDetailsNextAsync();
        data.Set("StateName", data.Resolve("{{data:statename}}"));
        data.Set("State", data.Get("State Abbreviation"));

    }

    [Given(@"^I enter account details$")]
    [When(@"^I enter account details$")]
    [Then(@"^I enter account details$")]
    public async Task EnterAccountDetailsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForAccountInformationAsync("Exists");
        await page.EnterDOBAsync(data.Get("AL_ClientData.DOB"));
        await page.EnterBestPhoneAccountOwnerAsync(data.Resolve("{{data:txt_best_phone_account_owner_18}}"));
        await page.EnterEmailAccountOwnerAsync(data.Resolve("{{data:txt_email_account_owner_19}}"));
        await page.ClickSingleAsync();

        await page.EnterEnterALocationAsync(data.Get("AL_ClientData.Street Address"));
        await page.EnterOwnerAddressLine2Async(data.Get("AL_ClientData.Apartment"));
        await page.EnterOwnerAddressCityNewAsync(data.Get("AL_ClientData.City"));
        await page.SelectStateAsync(data.Get("statename"));
        await page.EnterOwnerAddressZipAsync(data.Get("AL_ClientData.ZIP"));
        //await page.WaitForSatelliteAsync("Visible");
        await page.WaitForYesAtLeast90DaysAsync("Visible");
        await page.SelectYesAtLeast90DaysAsync("");
        await page.WaitForIsTheAccountAddressAlsoWhereTheClientResidesAsync("Exists");
        await page.WaitForYesClientResidesAsync("Visible");
        await page.SelectYesClientResidesAsync("");
        await page.ClickAccountDetailsNextAsync();
    }

    [Given(@"^I start the policy proposal$")]
    [When(@"^I start the policy proposal$")]
    [Then(@"^I start the policy proposal$")]
    public async Task StartThePolicyProposalAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.ClickMotorcycleAsync();
        await page.EnterEffectiveDateAsync(page.GetTodayEffectiveDate());
        await page.EnterAgentCodeAsync(data.Resolve("{{data:agentcode_42}}"));
        await page.SelectStateAsync("");
        await page.EnterStateAsync(data.Resolve("{{data:statename}}"));
        await page.SelectWritingCompanyAsync("");
        await page.EnterWritingCompanyAsync(data.Resolve("{{data:writingcompany_49}}"));
        await page.WaitForSameAsMailingAddressAsync("True");
        await page.ClickSameAsMailingAddressAsync();

        if (data.Resolve("{{data:state_variant}}") is ("GA" or "NY" or "KY"))
        {
            await page.WaitForCountyYesAsync("Exists");
            await page.SelectCountyYesAsync("");
        }

        if (data.Resolve("{{data:state_variant}}") is ("GA" or "NY"))
        {
            await page.EnterCountyComboBoxAsync(data.Get("County Name"));
        }

        await page.WaitForStartQuoteAsync("True");
        await page.ClickStartQuoteAsync();
        await page.PauseAsync(15000);

        if (await page.IsPROCEEDPresentAsync())
        {
            await page.VerifyPROCEEDAsync("Exists", "");
            await page.ClickCONFIRMAsync();
            await page.PauseAsync(5000);
        }
        await page.PauseAsync(10000);

        if (await page.IsSSNPresentAsync())
        {
            await page.WaitForSSNAsync("Exists");
            await page.VerifyProposalStartProceedSSNSUBMITAsync("Exists", "");
            await page.EnterSSNAsync(data.Get("AL_ClientData.SSN"));
            await page.ClickProposalStartProceedSSNSUBMITAsync();
            await page.PauseAsync(5000);
        }
        await page.PauseAsync(10000);

        if (await page.IsCONFIRMPresentAsync())
        {
            await page.VerifyCONFIRMAsync("Exists", "");
            await page.ClickCONFIRMEditAsync();
            await page.VerifyProposalStartProceedSSNSUBMITAsync("Exists", "");
            await page.EnterSSNAsync(data.Get("AL_ClientData.SSN"));
            await page.ClickProposalStartProceedSSNSUBMITAsync();
            await page.PauseAsync(5000);
        }
        await page.PauseAsync(10000);
        if (await page.IsCREATENEWACCOUNTPresentAsync())
        {
            await page.ClickCREATENEWACCOUNTAsync();
            await page.PauseAsync(5000);
        }
    }

    [Given(@"^I complete prequalification$")]
    [When(@"^I complete prequalification$")]
    [Then(@"^I complete prequalification$")]
    public async Task CompletePrequalificationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForChkBoxCheckBoxNoneOfTheAboveAsync("Exists");
        await page.ClickChkBoxCheckBoxNoneOfTheAboveAsync();
        await page.ClickPreQualificationNextAsync();
    }

    [Given(@"^I capture the proposal number$")]
    [When(@"^I capture the proposal number$")]
    [Then(@"^I capture the proposal number$")]
    public async Task CaptureTheProposalNumberAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.WaitForCaptureQuoteNumberAsync("Exists");
        data.Set("QuoteNumber2", await page.CaptureQNumAsync("InnerText"));
        var quoteNumber = data.Get("QuoteNumber2").ReplaceLineEndings(string.Empty);
        var lastName = data.Get("AL_ClientData.Last Name");
        if (!string.IsNullOrWhiteSpace(lastName))
        {
            quoteNumber = quoteNumber.Replace(lastName, string.Empty, StringComparison.OrdinalIgnoreCase);
        }
        data.Set("QuoteNumber", quoteNumber.Trim());

    }

    [Given(@"^I complete driver information$")]
    [When(@"^I complete driver information$")]
    [Then(@"^I complete driver information$")]
    public async Task CompleteDriverInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new DriversPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsIneligibleQuotePresentAsync())
        {
            await page.VerifyIneligibleQuoteAsync("Visible", "");
            await page.ClickCloseQuoteAsync();
            await this.OpenTheConfiguredPolicyApplicationAsync();
            await this.ApproveLevel9BAsync();
            await this.CompleteDriverInformationForTxtQuotePolicySearchAsync();
        }
        //await page.ClickCLOSEQUOTEAsync();

    }

    [Given(@"^I open the configured policy application$")]
    [When(@"^I open the configured policy application$")]
    [Then(@"^I open the configured policy application$")]
    public async Task OpenTheConfiguredPolicyApplicationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var browser = _scenario.Get<BrowserSession>();
        var previousPage = browser.Page;
        await browser.SwitchToNewPageAsync(async () =>
        {
            await previousPage.Context.NewPageAsync();
        });
        await previousPage.CloseAsync();

        var page = new PolicyWorkflowPage(browser, _scenario.Get<UiActions>());
        await page.NavigateAsync(data.Resolve("{{data:application_url}}"));
        await SignInToPolicyApplicationIfRequiredAsync();
    }

    private async Task SignInToPolicyApplicationIfRequiredAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.WaitForLoginOrPolicySearchAsync();
        if (await page.IsPolicyLoginIdVisibleAsync())
        {
            var password = Environment.GetEnvironmentVariable("PL_DC_PASSWORD");
            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidOperationException("Set PL_DC_PASSWORD before signing in to the policy application.");

            await page.EnterPolicyLoginIdAsync(data.GetRequired("txt_login_id_1_76"));
            await page.EnterPolicyLoginPasswordAsync("e}E~M+Km3#JRcJwyx7bN$CYaq");
            await page.ClickPolicyLoginSubmitAsync();
        }
        await page.WaitForPolicySearchAsync();
    }

    [Given(@"^I approve Level 9B$")]
    [When(@"^I approve Level 9B$")]
    [Then(@"^I approve Level 9B$")]
    public async Task ApproveLevel9BAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await SignInToPolicyApplicationIfRequiredAsync();
        await page.ApprovePolicyLevel9BAsync(data.GetRequired("QuoteNumber"), data.Resolve("{{data:txt_underwriting_notes_546}}"));

    }

    [Given(@"^I complete driver information for txt quote policy search$")]
    [When(@"^I complete driver information for txt quote policy search$")]
    [Then(@"^I complete driver information for txt quote policy search$")]
    public async Task CompleteDriverInformationForTxtQuotePolicySearchAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var applicationUrl = data.GetRequired("url");
        var quoteNumber = data.GetRequired("QuoteNumber");
        var browser = _scenario.Get<BrowserSession>();

        var previousPage = browser.Page;
        await browser.SwitchToNewPageAsync(async () =>
        {
            await previousPage.Context.NewPageAsync();
        });
        await previousPage.CloseAsync();
        var applicationPage = new ApplicationPage(browser, _scenario.Get<UiActions>());
        await applicationPage.NavigateAsync(applicationUrl);
        if (await applicationPage.IsSignInRequiredAsync())
        {
            var username = Environment.GetEnvironmentVariable("PL_DC_USERNAME");
            var password = Environment.GetEnvironmentVariable("PL_DC_PASSWORD");
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new InvalidOperationException("Set PL_DC_USERNAME and PL_DC_PASSWORD before signing in to ExpertQuote.");

            await applicationPage.SignInAsync(username, password);
        }
        await applicationPage.SearchQuoteAsync(quoteNumber);
        await Task.Delay(5000);
        var page = new UnderwritingPage(browser, _scenario.Get<UiActions>());
        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsPreQualificationNextPresentAsync())
        {
                    await page.ClickPreQualificationNextAsync();
        }

    }

    [Given(@"^I complete driver information for existing client 1$")]
    [When(@"^I complete driver information for existing client 1$")]
    [Then(@"^I complete driver information for existing client 1$")]
    public async Task CompleteDriverInformationForExistingClient1Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new DriversPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.ClickExistingClient1Async();
        await page.ClickDriverInformationNextAsync();
        //await page.PressDriverInformationNextAsync("Click");
    }

    [Given(@"^I review the driver information summary$")]
    [When(@"^I review the driver information summary$")]
    [Then(@"^I review the driver information summary$")]
    public async Task ReviewTheDriverInformationSummaryAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.WaitForDriverSummaryHeaderAsync("Exists");
        await Task.Delay(4000);
        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsGenderMalePresentAsync())
        {
            await page.ClickGenderMaleAsync();
        }
        //if (await page.IsSinglePresentAsync())
        //{
        //            await page.VerifySingleAsync("Exists", "");
        //}
        //if (await page.IsMaritalStatusSinglePresentAsync())
        //{
        //            await page.ClickMaritalStatusSingleAsync();
        //}
        //if (data.Condition("'Marital Status' != \"Married\""))
        //{
        //            await page.SelectMarriedAsync("");
        //}
        //if (data.Condition("'Marital Status' != \"Divorced\""))
        //{
        //            await page.ClickDivorcedAsync();
        //}
        //if (data.Condition("'Marital Status' == \"Single\""))
        //{
        //            await page.ClickSingleAsync();
        //}
        //if (data.Condition("'Marital Status' == \"Married\""))
        //{
        //            await page.SelectMarriedAsync("");
        //}
        //if (data.Condition("'Marital Status' == \"Divorced\""))
        //{
        //            await page.ClickDivorcedAsync();
        //}

        if (data.Resolve("{{data:state}}") == "MD" || data.Resolve("{{data:state}}") == "NJ")
        {
            if (await page.IsHighSchoolDiplomaOrGEDPresentAsync())
            {
                await page.VerifyHighSchoolDiplomaOrGEDAsync("True", "Enabled");
            }
            if (await page.IsMDNJEducationLevelUnknownPresentAsync())
            {
                await page.ClickMDNJEducationLevelUnknownAsync();
            }
            if (data.Condition("MD_NJ_EducationLevel == \"Unknown\""))
            {
                await page.SelectUnknownNoHighSchoolDiplomaOrGEDAsync("");
            }
            if (data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
            {
                await page.SelectUnknownNoHighSchoolDiplomaOrGEDAsync("");
            }
            if (data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
            {
                await page.ClickHighSchoolDiplomaOrGEDAsync();
            }
            if (data.Condition("MD_NJ_EducationLevel == \"Trade\""))
            {
                await page.SelectUnknownNoHighSchoolDiplomaOrGEDAsync("");
            }
            //if (data.Condition("MD_NJ_EducationLevel == \"Trade\""))
            //{
            //    await page.ClickVocationalOrTradeSchoolDegreeAsync();
            //}
            if (data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
            {
                await page.SelectUnknownNoHighSchoolDiplomaOrGEDAsync("");
            }
            if (data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
            {
                await page.SelectMoreOptionsEduAsync("");
            }
            if (data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
            {
                await page.WaitForSomeCollegeAsync("Visible");
            }
            if (data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
            {
                await page.ClickSomeCollegeAsync();
            }
            if (data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
            {
                await page.WaitForCurrentlyInCollegeAsync("Visible");
            }
            if (data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
            {
                await page.ClickCurrentlyInCollegeAsync();
            }
            if (data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
            {
                await page.WaitForCollegeDegreeGraduateWorkAsync("Visible");
            }
            if (data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
            {
                await page.ClickCollegeDegreeGraduateWorkAsync();
            }
            if (data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
            {
                await page.WaitForGraduateDegreeJDMastersAsync("Visible");
            }
            if (data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
            {
                await page.ClickGraduateDegreeJDMastersAsync();
            }
            if (data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
            {
                await page.WaitForPostGraduateDegreeMedicalDegreePhDEdDEtcAsync("Visible");
            }
            if (data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
            {
                await page.ClickPostGraduateDegreeMedicalDegreePhDEdDEtcAsync();
            }
        }
        //if (data.Condition("If options for Relationship to Account Owner are enabled > Condition verify relationship spouse button exist; 'Policy Type' != \"Cycle\""))
        //{
        //    await page.VerifySpouseAsync("Exists", "");
        //}
        //await page.ClickAccountOwnerAsync();
        //if (data.Condition("If options for Relationship to Account Owner are enabled > Then Relationship for account owner exist; 'Policy Type' != \"Cycle\""))
        //{
        //            await page.SelectRelationshipToAccountOwnerNULLAsync(data.Resolve("{{data:select_relationship_to_account_owner_null_122}}"));
        //}
        //if (data.Condition("'Relationship to Account Owner' != NULL"))
        //{
        //            await page.ClickAccountOwnerAsync();
        //}
        //if (data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Condition Check if Relationship is account owner; 'Policy Type' != \"Cycle\""))
        //{
        //            await page.VerifyAccountOwnerReadOnlyAsync("Exists", "");
        //}
        //if (data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Then Relationship is account owner; 'Policy Type' != \"Cycle\""))
        //{
        //            await page.VerifyAccountOwnerReadOnlyAsync("Exists", "");
        //}
        //if (data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Else Make script fail due to Relationship other than account owner; 'Policy Type' != \"Cycle\""))
        //{
        //            await page.ClickAccountOwnerAsync();
        //            await page.PressAccountOwnerAsync("Click");
        //            await page.PressAccountOwnerAsync("scroll[2]");
        //}
        //if (data.Condition("'Policy Type' == \"Cycle\""))
        //{
        //            await page.WaitForIsThisDriverANamedInsuredAsync("Visible");
        //}
        //if (data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        //{
        //            await page.ClickPrimaryNamedInsuredAsync();
        //            await page.PressPrimaryNamedInsuredAsync("scroll[2]");
        //}
        //if (data.Condition("'Named Insured?' == \"NamedIns\""))
        //{
        //            await page.ClickNamedInsuredAsync();
        //            await page.PressNamedInsuredAsync("scroll[2]");
        //}
        //if (data.Condition("'Named Insured?' == \"NotNamedIns\""))
        //{
        //            await page.ClickNotANamedInsuredAsync();
        //            await page.PressNotANamedInsuredAsync("scroll[2]");
        //}
        //if (data.Condition("'Operator Status' == \"Assigned\""))
        //{
        //            await page.ClickRelatedAsync();
        //            await page.PressRelatedAsync("scroll[2]");
        //}
        if (data.Condition("'Operator Status' == \"Assigned\""))
        {
            await page.ClickAssignedAsync();
            await page.ClickFinancialResponsibiltySR44NoAsync();
        }
        if (data.Condition("'Operator Status' == \"Related\""))
        {
            await page.ClickAssignedAsync();
        }
        await page.EnterDriverSLicenseNumberAsync(data.Resolve("{{data:driver_s_license_number_169}}"));
        if (data.Condition("'State' == \"TX\""))
        {
            await page.EnterDaysOperatedUninsuredAsync(data.Resolve("{{data:daysoperateduninsured_175}}"));
        }
        //if (data.Condition("'State' == \"CA\""))
        //{
        //    await page.EnterYrsLicensedAllStatesAsync(data.Resolve("{{data:yrslicensed_all_states_176}}"));
        //}
        if (data.Condition("'State' == \"CA\""))
        {
            await page.EnterYrsLicensedAllStatesAsync(data.Resolve("{{data:yrslicensed_all_states_177}}"));
        }
        await page.EnterYrsLicensedCurrentStateAsync(data.Resolve("{{data:yrs_licensed_current_state_172}}"));
        //await page.PressYrsLicensedCurrentStateAsync("CTRL+A");
        //await page.EnterYrsLicensedCurrentStateAsync(data.Resolve("{{data:yrs_licensed_current_state_172}}"));
        //await page.EnterMonthsLicensedCurrentStateAsync(data.Resolve("{{data:months_licensed_current_state_173}}"));
        //await page.PressMonthsLicensedCurrentStateAsync("CTRL+A");
        await page.EnterMonthsLicensedCurrentStateAsync(data.Resolve("{{data:months_licensed_current_state_174}}"));
        //if (data.Condition("'Operator Status' == \"Related\""))
        //{
        //            await page.ClickRelatedAsync();
        //            await page.PressRelatedAsync("scroll[2]");
        //}
        //if (data.Condition("'Operator Status' == \"NoCycleLicense\""))
        //{
        //            await page.ClickAssignedAsync();
        //            await page.PressAssignedAsync("scroll[2]");
        //}
        //if (data.Condition("'Operator Status' == \"NoCycleLicense\""))
        //{
        //            await page.SelectNoCycleLicenseAsync("");
        //}
        //if (data.Condition("'Operator Status' != \"Assigned\" AND 'Operator Status' != \"NoCycleLicense\" AND 'Operator Status' != \"Related\""))
        //{
        //            await page.ClickAssignedAsync();
        //            await page.PressAssignedAsync("scroll[2]");
        //}
        //if (data.Condition("'Operator Status' == \"Military\""))
        //{
        //            await page.ClickMilitaryAsync();
        //}
        //if (data.Condition("'Operator Status' == \"Missionary\""))
        //{
        //            await page.ClickMissionaryAsync();
        //}
        //if (data.Condition("'Operator Status' == \"NonDriver\""))
        //{
        //            await page.SelectNonDriverAsync("");
        //}
        //if (data.Condition("'Operator Status' == \"OtherIns\""))
        //{
        //            await page.ClickOtherInsuranceAsync();
        //}
        //if (data.Condition("'Operator Status' == \"NonDriver\""))
        //{
        //            await page.WaitForNonDriverReasonAsync("Visible");
        //}
        //if (data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        //{
        //            await page.EnterCycleNonDriverComboBoxAsync(data.Resolve("{{data:cyclenondriver_combobox_143}}"));
        //}
        //if (data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        //{
        //            await page.EnterCycleNonDriverComboBoxAsync(data.Resolve("{{data:cyclenondriver_combobox_144}}"));
        //}
        //if (data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        //{
        //            await page.EnterCycleNonDriverComboBoxAsync(data.Resolve("{{data:cyclenondriver_combobox_145}}"));
        //}
        //if (data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        //{
        //            await page.EnterCycleNonDriverComboBoxAsync(data.Resolve("{{data:cyclenondriver_combobox_146}}"));
        //}
        //if (data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        //{
        //            await page.EnterCycleNonDriverComboBoxAsync(data.Resolve("{{data:cyclenondriver_combobox_147}}"));
        //}
        //if (data.Condition("'Policy Type' != \"Cycle\""))
        //{
        //            await page.WaitForIsThisDriverANamedInsuredAsync("Visible");
        //}
        if (data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        {
            await page.ClickPrimaryNamedInsuredAsync();
            //await page.PressPrimaryNamedInsuredAsync("scroll[2]");
        }
        if (data.Condition("'Named Insured?' == \"NamedIns\""))
        {
            await page.ClickNamedInsuredAsync();
            await page.PressNamedInsuredAsync("scroll[2]");
        }
        if (data.Condition("'Named Insured?' == \"NotNamedIns\""))
        {
            await page.ClickNotANamedInsuredAsync();
            await page.PressNotANamedInsuredAsync("scroll[2]");
        }
        //if (data.Condition("'Operator Status' != \"Assigned\""))
        //{
        //            await page.ClickAssignedAsync();
        //            await page.PressAssignedAsync("scroll[2]");
        //}
        //if (data.Condition("'Operator Status' != \"NonDriver\""))
        //{
        //            await page.ClickNonDriverAsync();
        //            await page.PressNonDriverAsync("scroll[2]");
        //}
        //if (data.Condition("'Operator Status' != \"Related\""))
        //{
        //            await page.ClickRelatedAsync();
        //}
        //if (data.Condition("'Operator Status' == \"Assigned\""))
        //{
        //            await page.ClickAssignedAsync();
        //}
        //if (data.Condition("'Operator Status' == \"Related\""))
        //{
        //            await page.ClickRelatedAsync();
        //}
        //if (data.Condition("'Operator Status' == \"Military\""))
        //{
        //            await page.ClickMilitaryAsync();
        //}
        //if (data.Condition("'Operator Status' == \"Missionary\""))
        //{
        //            await page.ClickMissionaryAsync();
        //}
        //if (data.Condition("'Operator Status' == \"OtherIns\""))
        //{
        //            await page.ClickOtherInsuranceAsync();
        //}
        //if (data.Condition("'Operator Status' == \"Roomate\""))
        //{
        //            await page.ClickRoommateAsync();
        //}
        //if (data.Condition("'Operator Status' == \"NonDriver\""))
        //{
        //            await page.WaitForNonDriverReasonAsync("Visible");
        //}
        //if (data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        //{
        //            await page.ClickNeverLicensedAsync();
        //}
        //if (data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        //{
        //            await page.ClickUnderageAsync();
        //}
        //if (data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        //{
        //            await page.ClickMedicalConditionAsync();
        //}
        //if (data.Condition("'If NonDriver: Reason' != \"NeverLicensed\" AND 'If NonDriver: Reason' != \"Underage\" AND 'If NonDriver: Reason' != \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        //{
        //            await page.SelectMoreOptionsNonDriverAsync("");
        //}
        //if (data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        //{
        //            await page.ClickSurrenderedAsync();
        //}
        //if (data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        //{
        //            await page.ClickPermitDriverAsync();
        //}
        //if (data.Condition("'State Licensed(XX)' != NULL"))
        //{
        //            await page.EnterLicenseStateAsync(data.Get("AL_ClientData.State"));
        //}
        //if (data.Condition("'Drivers License #' != NULL"))
        //{
        //            await page.EnterDriverSLicenseNumberAsync(data.Resolve("{{data:driver_s_license_number_169}}"));
        //            await page.PressDriverSLicenseNumberAsync("CTRL+A");
        //}
        //if (data.Condition("'Drivers License #' != NULL"))
        //{
        //            await page.EnterDriverSLicenseNumberAsync(data.Get("AL_ClientData.DL Number"));
        //}
        //await page.EnterYrsLicensedCurrentStateAsync(data.Resolve("{{data:yrs_licensed_current_state_171}}"));
        //await page.PressYrsLicensedCurrentStateAsync("CTRL+A");
        //await page.EnterYrsLicensedCurrentStateAsync(data.Resolve("{{data:yrs_licensed_current_state_172}}"));
        //await page.EnterMonthsLicensedCurrentStateAsync(data.Resolve("{{data:months_licensed_current_state_173}}"));
        //await page.PressMonthsLicensedCurrentStateAsync("CTRL+A");
        //await page.EnterMonthsLicensedCurrentStateAsync(data.Resolve("{{data:months_licensed_current_state_174}}"));
        //if (data.Condition("'State' == \"TX\""))
        //{
        //            await page.EnterDaysOperatedUninsuredAsync(data.Resolve("{{data:daysoperateduninsured_175}}"));
        //}
        //if (data.Condition("'State' == \"CA\""))
        //{
        //            await page.EnterYrsLicensedAllStatesAsync(data.Resolve("{{data:yrslicensed_all_states_176}}"));
        //            await page.PressYrsLicensedAllStatesAsync("CTRL+A");
        //}
        //if (data.Condition("'State' == \"CA\""))
        //{
        //            await page.EnterYrsLicensedAllStatesAsync(data.Resolve("{{data:yrslicensed_all_states_177}}"));
        //}
        //if (data.Condition("'Operator Status' == \"Assigned\""))
        //{
        //            await page.ClickNoD053AAsync();
        //            await page.PressNoD053AAsync("Click");
        //            await page.PressNoD053AAsync("Scroll[2]");
        //}
        //if (await page.IsWasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbovePresentAsync())
        //{
        //            await page.VerifyWasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAboveAsync("Exists", "");
        //await page.SelectNoPreviouslyInsuredAsync("");
        //}
        //if (await page.IsNoPreviouslyInsuredPresentAsync())
        //{
        //            await page.SelectNoPreviouslyInsuredAsync("");
        //}
        await Task.Delay(4000);

        if (await page.IsClinetInsuredANAsync())
        {
            await page.ClickClientInsuredNoAsync();
        }
        if (await page.IsPriorCarrierNamePresentAsync())
        {
            await page.VerifyPriorCarrierNameAsync("Exists", "");
            await page.ClickSaveAndContinue9CB7AAsync();
            
        }
        else if(await page.IsNoNeedWasNotLicensedPresentAsync())
        {
            await page.ClickNoNeedWasNotLicensedAsync();
            await page.ClickSaveAndContinue9CB7AAsync();
            
        }
        else
        {
            await page.ClickSaveAndContinue9CB7AAsync();
            
            //await page.PressNoNeedWasNotLicensedAsync("End");
            //await page.PressNoNeedWasNotLicensedAsync("Click");
            //await page.ClickSaveAndContinue9CB7AAsync();
        }

        
        await Task.Delay(10000);
        if (await page.IsUnderWriterRulesAsync())
        {
            await page.ClickCONTINUEF07C7Async();
        }

        //if (await page.IsSaveAndContinue9CB7APresentAsync())
        //{
        //            await page.ClickSaveAndContinue9CB7AAsync();
        //}
        //if (await page.IsNoNeedWasNotLicensedPresentAsync())
        //{
        //            await page.VerifyNoNeedWasNotLicensedAsync("Visible", "");
        //}
        //if (await page.IsNoNeedWasNotLicensedPresentAsync())
        //{
        //            await page.ClickNoNeedWasNotLicensedAsync();
        //            await page.PressNoNeedWasNotLicensedAsync("End");
        //            await page.PressNoNeedWasNotLicensedAsync("Click");
        //}
        //await page.ClickSaveAndContinue9CB7AAsync();
        if (data.Resolve("{{data:statecode}}") is ("MD" or "NJ"))
        {
            // write for education
        }
        //if (await page.IsSaveAndContinue9CB7APresentAsync())
        //{
        //    await page.ClickSaveAndContinue9CB7AAsync();
        //    await Task.Delay(10000);
        //    if(await page.IsUnderWriterRulesAsync())
        //    {
        //        await page.ClickCONTINUEF07C7Async();
        //    }

        //}
        //if (await page.IsCONTINUED555DPresentAsync())
        //{
        //    await page.WaitForCONTINUED555DAsync("Exists");
        //}
        //if (await page.IsCONTINUED555DPresentAsync())
        //{
        //    await page.ClickCONTINUED555DAsync();
        //}
    }

    [Given(@"^I review household\-driver prefill results$")]
    [When(@"^I review household\-driver prefill results$")]
    [Then(@"^I review household\-driver prefill results$")]
    public async Task ReviewHouseholdDriverPrefillResultsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SocialSecurityPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.WaitForPrefilledDriversAsync("Visible");

        // Field-level orchestration derived from the canonical Tosca method sequence.
        
            await page.WaitForPrefilledDriversAsync("Visible");
            await Task.Delay(7000);
            if (await page.IsPrefilledDriversRequiredAsync())
            {
                //await page.WaitForPrefilledDriversAsync("Visible");
                var prefillReasonDropdownCount = await page.GetPrefillReasonDropdownCountAsync();
                data.Set("PrefillReasonDropdownCount", prefillReasonDropdownCount.ToString());
                if (prefillReasonDropdownCount > 0)
                {
                    await page.SelectFirstReasonForAllPrefillDriversAsync();
                }
            }
            else if (await page.IsUnselectedClientSuggestionsPresentAsync())
            {
                await page.VerifyUnselectedClientSuggestionsAsync("Exists", "");
                
            }

        await page.ClickSaveAndContinueAsync();
        await Task.Delay(4000);
            if (await page.IsUnderWriterRulesAsync())
            {
                await page.ClickCONTINUEF07C7Async();
            }
    }

    [Given(@"^I complete vehicle Summary 1st Cycle Summary$")]
    [When(@"^I complete vehicle Summary 1st Cycle Summary$")]
    [Then(@"^I complete vehicle Summary 1st Cycle Summary$")]
    public async Task CompleteVehicleSummary1stCycleSummaryAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.


        if (await page.IsAdditionalVehiclePresentAsync())
        {
            //await page.WaitForSelectVehicleAsync("Visible");
            await page.ClickAdditionalVehicleSF5D93Async();
            await page.ClickCyclePreFillSelectionNextAsync();

        }
        await page.WaitForVIN8EE56Async("Visible");
        await page.EnterVIN8EE56Async(data.Resolve("{{data:vin_201}}"));
        await page.WaitForPleaseSelectTheVehicleCD741Async("Visible");
        
        await page.ClickCycle1C1864Async();
        await page.WaitForSelectVehicleAsync("Visible");
        await page.ClickMotorCycleAsync();
        if (data.Condition("'Primary Use' == \"Pleasure Use\""))
        {
                    await page.ClickPleasureUseAsync();
        }

        else if (data.Condition("'Primary Use' == \"Not Pleasure Use\""))
        {
                    await page.SelectNotPleasureUseAsync("");
        }
        else if (data.Condition("'Primary Use' == \"Under Construction\""))
        {
                    await page.ClickUnderConstructionAsync();
                    await page.EnterCurrentValueAsync(data.Get("Current Value(UnderConstruction)"));
        }
        if (data.Condition("'Loan/Leased/Own' == \"Loan\""))
        {
                    await page.ClickLoanED36CAsync();
        }
        else if (data.Condition("'Loan/Leased/Own' == \"Leased\""))
        {
                    await page.ClickLeased87268Async();
        }
        else if (data.Condition("'Loan/Leased/Own' == \"Own\""))
        {
                    await page.ClickOwnD044EAsync();
            await Task.Delay(5000);
            if (await page.IsLblOwnedPopupPresentAsync())
            {
                await page.VerifyLblOwnedPopupAsync("Visible", "");
                await page.ClickCONTINUEF07C7Async();
            }
        }
        if (data.Condition("State == \"OK\""))
        {
                    await page.SelectNoRegisteredFedTribeAsync("");
        }
        await page.WaitForDoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications051FDAsync("Visible");
        if (data.Condition("'NonFactory Mods?' == \"Yes\""))
        {
                    await page.SelectYesAsync("");
            await page.EnterDescriptionOfModsAsync(data.Resolve("{{data:description_of_mods_216}}"));
        }
        else
        {
                    await page.SelectNoD9E4DAsync("");
        }
        if (data.Condition("State == \"NY\" OR State == \"NJ\" OR State == \"CA\""))
        {
                    await page.EnterAnnualMileage12A49Async(data.Resolve("{{data:annual_mileage_218}}"));
        }


        await page.EnterEngineCCAsync(data.Resolve("{{data:Engine CC}}"));
        await page.WaitForSaveAndContinue8EF26Async("Visible");
        await page.ClickSaveAndContinue8EF26Async();

    }

    [Given(@"^I complete vehicle Summary Add Cycle/Next$")]
    [When(@"^I complete vehicle Summary Add Cycle/Next$")]
    [Then(@"^I complete vehicle Summary Add Cycle/Next$")]
    public async Task CompleteVehicleSummaryAddCycleNextAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await Task.Delay(7000);
        var data1 = data.Get("Additional Drivers?");
        await page.WaitForAdditionalVehicleAsync("Visible");
        await page.ClickAddAdditionalVehicleAsync();
    }

    [Given(@"^I complete vehicle Summary Vintage Cycle$")]
    [When(@"^I complete vehicle Summary Vintage Cycle$")]
    [Then(@"^I complete vehicle Summary Vintage Cycle$")]
    public async Task CompleteVehicleSummaryVintageCycleAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForCycleVINAsync("True");
        await page.EnterCycleVINAsync(data.Resolve("{{data:cycle_vin_223}}"));

        await Task.Delay(5000);
        if(await page.IsleaseSelectTheVehicleCD741Async())
        {
            await page.WaitForPleaseSelectTheVehicleCD741Async("Visible");

            await page.ClickCycle1C1864Async();
        }
        
        await page.WaitForSelectVehicleAsync("Visible");
        await page.ClickVintageAsync();
        if (data.Condition("'Loan/Leased/Own' == \"Loan\""))
        {
                    await page.ClickLoan49242Async();
        }
        if (data.Condition("'Loan/Leased/Own' == \"Leased\""))
        {
                    await page.ClickLeased26B32Async();
        }
        if (data.Condition("'Loan/Leased/Own' == \"Own\""))
        {
            await page.ClickOwnD044EAsync();
            await Task.Delay(5000);
            if (await page.IsLblOwnedPopupPresentAsync())
            {
                await page.VerifyLblOwnedPopupAsync("Visible", "");
                await page.ClickCONTINUEF07C7Async();
            }
        }
        await page.WaitForRestrictedUseAsync("Visible");
        await page.ClickRestrictedUseAsync();
        await page.WaitForDoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications051FDAsync("Visible");
        if (data.Condition("'NonFactory Mods?' == \"Yes\""))
        {
            await page.SelectYesAsync("");
            await page.EnterDescriptionOfModsAsync(data.Resolve("{{data:description_of_mods_216}}"));
        }
        else
        {
            await page.SelectNoD9E4DAsync("");
        }
        await page.EnterAgreedValueF302BAsync(data.Resolve("{{data:agreed_value_235}}"));
        await page.EnterAppraisalDateD909CAsync(data.Resolve("{{data:appraisal_date_236}}"));
        await page.EnterEngineCCAsync(data.Resolve("{{data:Engine CC}}"));
        if (data.Condition("State == \"NY\" OR State == \"NJ\" OR State == \"CA\""))
        {
            await page.EnterAnnualMileage51344Async(data.Resolve("{{data:annual_mileage_218}}"));
        }

        await page.WaitForSaveAndContinue8EF26Async("Visible");
        await page.ClickSaveAndContinue8EF26Async();

        //if (await page.IsLblOwnedPopupPresentAsync())
        //{
        //            await page.VerifyLblOwnedPopupAsync("Visible", "");
        //}
        //if (await page.IsCONTINUEF07C7PresentAsync())
        //{
        //            await page.ClickCONTINUEF07C7Async();
        //}

    }

    [Given(@"^I complete vehicle Summary Add Cycle/Next for add additional vehicle$")]
    [When(@"^I complete vehicle Summary Add Cycle/Next for add additional vehicle$")]
    [Then(@"^I complete vehicle Summary Add Cycle/Next for add additional vehicle$")]
    public async Task CompleteVehicleSummaryAddCycleNextForAddAdditionalVehicleAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("'Additional Cycle?' == \"Yes\""))
        {
                    await page.ClickAddAdditionalVehicleAsync();
        }
        if (data.Condition("'Additional Cycle?' == \"No\""))
        {
                    await page.ClickAddCycleNextNextAsync();
        }
        data.Set("Driver 1 Vehicle", data.Resolve("{{data:driver_1_vehicle}}"));
        data.Set("Driver 1 Principal Occasional", data.Resolve("{{data:driver_1_principal_occasional}}"));
        data.Set("Driver 2 Vehicle", data.Get("Driver 2 Vehicle"));
        data.Set("Driver 2 Principal Occasional", data.Get("Driver 2 Principal Occasional"));
        data.Set("Driver 3 Vehicle", data.Get("Driver 3 Vehicle"));
        data.Set("Driver 3 Principal Occasional", data.Get("Driver 3 Principal Occasional"));
        data.Set("Driver 4 Vehicle", data.Get("Driver 4 Vehicle"));
        data.Set("Driver 4 Principal Occasional", data.Get("Driver 4 Principal Occasional"));
        data.Set("Driver 5 Vehicle", data.Get("Driver 5 Vehicle"));
        data.Set("Driver 5 Principal Occasional", data.Get("Driver 5 Principal Occasional"));

    }

    [Given(@"^I complete driver Assignment$")]
    [When(@"^I complete driver Assignment$")]
    [Then(@"^I complete driver Assignment$")]
    public async Task CompleteDriverAssignmentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new DriversPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("'Driver 1 Vehicle' != NULL"))
        {
                    await page.ClickDriver1VehicleAsync();
        }
        if (data.Condition("'Driver 1 Principal Occasional' != NULL"))
        {
                    await page.ClickDriver1PrincipalOccasionalAsync();
        }
        if (data.Condition("'Driver 2 Vehicle' != NULL"))
        {
                    await page.ClickDriver2VehicleAsync();
                    await page.PressDriver2VehicleAsync("Scroll[1]");
                    await page.PressDriver2VehicleAsync("Click");
        }
        if (data.Condition("'Driver 2 Principal Occasional' != NULL"))
        {
                    await page.ClickDriver2PrincipalOccasionalAsync();
                    await page.PressDriver2PrincipalOccasionalAsync("Scroll[1]");
                    await page.PressDriver2PrincipalOccasionalAsync("Click");
        }
        if (data.Condition("'Driver 3 Vehicle' != NULL"))
        {
                    await page.ClickDriver3VehicleAsync();
                    await page.PressDriver3VehicleAsync("Scroll[1]");
                    await page.PressDriver3VehicleAsync("Click");
        }
        if (data.Condition("'Driver 3 Principal Occasional' != NULL"))
        {
                    await page.ClickDriver3PrincipalOccasionalAsync();
                    await page.PressDriver3PrincipalOccasionalAsync("Scroll[1]");
                    await page.PressDriver3PrincipalOccasionalAsync("Click");
        }
        if (data.Condition("'Driver 4 Vehicle' != NULL"))
        {
                    await page.ClickDriver4VehicleAsync();
                    await page.PressDriver4VehicleAsync("Scroll[1]");
                    await page.PressDriver4VehicleAsync("Click");
        }
        if (data.Condition("'Driver 4 Principal Occasional' != NULL"))
        {
                    await page.ClickDriver4PrincipalOccasionalAsync();
                    await page.PressDriver4PrincipalOccasionalAsync("Scroll[1]");
                    await page.PressDriver4PrincipalOccasionalAsync("Click");
        }
        if (data.Condition("'Driver 5 Vehicle' != NULL"))
        {
                    await page.ClickDriver5VehicleAsync();
                    await page.PressDriver5VehicleAsync("Scroll[1]");
                    await page.PressDriver5VehicleAsync("Click");
        }
        if (data.Condition("'Driver 5 Principal Occasional' != NULL"))
        {
                    await page.ClickDriver5PrincipalOccasionalAsync();
                    await page.PressDriver5PrincipalOccasionalAsync("Scroll[1]");
                    await page.PressDriver5PrincipalOccasionalAsync("Click");
        }
        await page.ClickMultipleDriverAssignmentNextAsync();

    }

    [Given(@"^I complete multiple Driver Assignment$")]
    [When(@"^I complete multiple Driver Assignment$")]
    [Then(@"^I complete multiple Driver Assignment$")]
    public async Task CompleteMultipleDriverAssignmentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new DriversPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if(await page.IsCONTINUED555DPresentAsync())
        {
            await page.ClickCONTINUED555DAsync();
        }

    }

    [Given(@"^I complete claims/Violations$")]
    [When(@"^I complete claims/Violations$")]
    [Then(@"^I complete claims/Violations$")]
    public async Task CompleteClaimsViolationsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.WaitForClaimsViolationsHeaderAsync("Visible");
    }

    [Given(@"^I complete editClaimsViolations$")]
    [When(@"^I complete editClaimsViolations$")]
    [Then(@"^I complete editClaimsViolations$")]
    public async Task CompleteEditClaimsViolationsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await Task.Delay(5000);
        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForClaimsViolationsHeaderAsync("Visible");

        var requiredClaimEdits = await page.GetRequiredClaimEditIdsAsync();
        data.Set("ClaimsRequiringEditCount", requiredClaimEdits.Count.ToString());
        foreach (var editButtonTestId in requiredClaimEdits)
        {
            await page.CompleteRequiredClaimEditAsync(editButtonTestId);
        }
        await page.VerifyNoClaimsRequireEditAsync();
        if (await page.IsComboBoxPresentAsync())
        {
                    await page.EnterComboBoxAsync(data.Resolve("{{data:combobox_278}}"));
        }
        //await page.SelectClaimViolationDoesNotApplyAsync("");
        //await page.ClickClaimViolationSaveAndContinueAsync();
        if (await page.IsCONTINUEDoesnTApplyPresentAsync())
        {
                    await page.VerifyCONTINUEDoesnTApplyAsync("Exists", "");
        }
        if (await page.IsCONTINUEDoesnTApplyPresentAsync())
        {
                    await page.ClickCONTINUEDoesnTApplyAsync();
        }

        var requiredViolationEdits = await page.GetRequiredViolationEditIdsAsync();
        data.Set("ViolationsRequiringEditCount", requiredViolationEdits.Count.ToString());
        foreach (var editButtonTestId in requiredViolationEdits)
        {
            await page.CompleteRequiredViolationEditAsync(editButtonTestId, data.Resolve("{{data:combobox_329}}"));
        }

        await page.VerifyNoViolationsRequireEditAsync();
        await page.ClickClaimsViolationNEWNextAsync();

    }

    [Given(@"^I complete discount 1$")]
    [When(@"^I complete discount 1$")]
    [Then(@"^I complete discount 1$")]
    public async Task CompleteDiscount1Async()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new DiscountsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("State == \"MD\" OR State == \"NJ\""))
        {
                    await page.ClickResidentiaProperty1Async();
            if (data.Condition("State == \"MD\""))
            {
                await page.ClickRBodyInjurelessthanor30k60kAsync();
            }

            if (data.Condition("State == \"NJ\""))
            {
                await page.ClickN1500030000Async();
            }
            //await page.PressResidentiaProperty1Async("end");
            //await page.PressResidentiaProperty1Async("scroll[-2]");
            //await page.PressResidentiaProperty1Async("Click");
        }
        
        data.Set("Commercial Auto", data.Get("Commercial Auto"));
        data.Set("Special Farm Package", data.Get("Special Farm Package"));
        data.Set("Safe Cycle Discount", data.Resolve("{{data:safe_cycle_discount}}"));
        data.Set("Rider Group Discount", data.Get("Rider Group Discount"));
        if (data.Condition("'Multi-Car Discount' !=NULL"))
        {
                    await page.VerifyMultiCarDiscountAsync("Exists", "");
        }
        //await page.SetOnAsync(data.Resolve("{{data:multi_car_discount_on_294}}"));
        if (data.Condition("'Rider Group Discount' != NULL"))
        {
                    await page.ClickRiderGroupDiscountAsync();
        }
        if (data.Condition("'Commercial Auto' != NULL"))
        {
                    await page.VerifyCommercialAutoAsync("Exists", "");
        }
        //await page.SetOnAsync(data.Resolve("{{data:commercial_auto_on_297}}"));
        if (data.Condition("'Special Farm Package' != NULL"))
        {
                    await page.VerifySpecialFarmPackageAsync("Exists", "");
        }
       // await page.SetOnAsync(data.Resolve("{{data:special_farm_package_on_299}}"));
        if (data.Condition("'Safe Cycle Discount' != NULL"))
        {
                    await page.ClickSafeCycleDiscountAsync();
            await page.EnterSafeCycleDiscountDateAsync(data.Resolve("{{data:safe_cycle_discount_date_301}}"));
        }
        if (data.Condition("State == \"DE\""))
        {
                    await page.SelectNoDefensiveDriverDiscountAsync("");
        }
        await page.WaitForDiscountNEWNextAsync("Visible");
        await page.ClickDiscountNEWNextAsync();
        if (await page.IsLoadingPresentAsync())
        {
                    await page.VerifyLoadingAsync("Exists", "");
        }
        if (await page.IsLoadingPresentAsync())
        {
        }
        //data.Set("Supplemental UM/UIM Opt In", data.Get("Supplemental UM/UIM Opt In"));

    }

    [Given(@"^I complete coverages$")]
    [When(@"^I complete coverages$")]
    [Then(@"^I complete coverages$")]
    public async Task CompleteCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("PolicyCovOption == \"OPTION 1\""))
        {
                    await page.SetOption1Async(data.Resolve("{{data:option_1_331}}"));
        }
        if (data.Condition("PolicyCovOption == \"OPTION 2\""))
        {
                    await page.SetOption2Async(data.Resolve("{{data:option_2_332}}"));
        }
        if (data.Condition("PolicyCovOption == \"OPTION 3\""))
        {
                    await page.SetOption3Async(data.Resolve("{{data:option_3_333}}"));
        }
        if (data.Condition("PolicyCovOption == \"OPTION 1\"") &&
            (data.Condition("CovOptUninsured != NULL") || data.Condition("'Supplemental UM/UIM Opt In' != NULL")))
        {
                    await page.ClickEDITCOVERAGEOpt1Async();
        }
        if (data.Condition("PolicyCovOption == \"OPTION 2\"") &&
            (data.Condition("CovOptUninsured != NULL") || data.Condition("'Supplemental UM/UIM Opt In' != NULL")))
        {
                    await page.ClickEDITCOVERAGEOpt2Async();
        }
        if (data.Condition("PolicyCovOption == \"OPTION 3\"") &&
            (data.Condition("CovOptUninsured != NULL") || data.Condition("'Supplemental UM/UIM Opt In' != NULL")))
        {
                    await page.ClickEDITCOVERAGEOpt3Async();
        }
        if (data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
                    await page.WaitForSupplementalUMUIMOptInAsync("Exists");
        }
        if (data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
                    await page.ClickSupplementalUMUIMOptInAsync();
        }
        if (data.Condition("'Supplemental UM/UIM Opt In' == \"Yes\""))
        {
                    await page.ClickSupplementalUMUIMCovAsync();
        }
        if (data.Condition("CovOptUninsured != NULL"))
        {
                    await page.WaitForUMCoverageAsync("Exists");
        }
        if (data.Condition("CovOptUninsured != NULL"))
        {
                    await page.ClickUMCoverageAsync();
        }
        if (data.Condition("CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL"))
        {
                    await page.ClickSaveAndContinueAsync();
        }
        //await page.PressOption3Async("scroll[5]");
        if (data.Condition("V1_CompCollOnly == \"Yes\""))
        {
                    await page.SelectV1CompCollOnlyYESAsync("");
        }
        if (data.Condition("'V1_Comprehensive Only' != NULL"))
        {
                    await page.WaitForV1ComprehensiveOnlyAsync("Visible");
        }
        if (data.Condition("'V1_Comprehensive Only' != NULL"))
        {
                    await page.SetV1ComprehensiveOnlyAsync(data.Resolve("{{data:v1_comprehensive_only_347}}"));
        }
        if (data.Condition("'V1_ Comprehensive And Collision Only' != NULL"))
        {
                    await page.ClickV1ComprehensiveAndCollisionOnlyAsync();
        }
        //if (data.Condition("V1_CompDed != NULL"))
        //{
        //            await page.VerifyV1ComprehensiveDeductibleAsync("Visible", "");
        //}
        if (data.Condition("V1_CompDed != NULL"))
        {
                    await page.ClickV1CompDedAsync();
        }
        if (data.Condition("V1_CompDedMoreOpt != NULL"))
        {
                    await page.ClickV1CompDedMoreOptAsync();
        }
        if (data.Condition("V1_CollDed != NULL AND V1_CompDed != \"NoCoverage\""))
        {
                    await page.ClickV1CollDedAsync();
        }
        if (data.Condition("V1_CollDedMoreOpt != NULL"))
        {
                    await page.ClickV1CollDedMoreOptAsync();
        }
        //await page.PressOption3Async("scroll[8]");
        if (data.Condition("V2_CompCollOnly == \"Yes\""))
        {
                    await page.SelectV2CompCollOnlyYESAsync("");
        }
        if (data.Condition("'V2_Comprehensive Only' != NULL"))
        {
                    await page.WaitForV2ComprehensiveOnlyAsync("Visible");
        }
        if (data.Condition("'V2_Comprehensive Only' != NULL"))
        {
                    await page.SetV2ComprehensiveOnlyAsync(data.Resolve("{{data:v2_comprehensive_only_357}}"));
        }
        if (data.Condition("'V2_ Comprehensive And Collision Only' != NULL"))
        {
                    await page.ClickV2ComprehensiveAndCollisionOnlyAsync();
        }
        if (data.Condition("V2_CompDed != NULL"))
        {
                    await page.VerifyV2ComprehensiveDeductibleAsync("Visible", "");
        }
        if (data.Condition("V2_CompDed != NULL"))
        {
                    await page.ClickV2CompDedAsync();
        }
        if (data.Condition("V2_CompDedMoreOpt != NULL"))
        {
                    await page.ClickV2CompDedMoreOptAsync();
        }
        if (data.Condition("V2_CollDed != NULL"))
        {
                    await page.ClickV2CollDedAsync();
        }
        if (data.Condition("V2_CollDedMoreOpt != NULL"))
        {
                    await page.ClickV2CollDedMoreOptAsync();
        }
        //await page.PressCoveragesNewNextAsync("end");
        //await page.PressCoveragesNewNextAsync("scroll[-4]");
        if (data.Condition("V3_CompCollOnly == \"Yes\""))
        {
                    await page.SelectV3CompCollOnlyYESAsync("");
        }
        if (data.Condition("'V3_Comprehensive Only' != NULL"))
        {
                    await page.WaitForV3ComprehensiveOnlyAsync("Visible");
        }
        if (data.Condition("'V3_Comprehensive Only' != NULL"))
        {
                    await page.SetV3ComprehensiveOnlyAsync(data.Resolve("{{data:v3_comprehensive_only_367}}"));
        }
        if (data.Condition("'V3_ Comprehensive And Collision Only' != NULL"))
        {
                    await page.ClickV3ComprehensiveAndCollisionOnlyAsync();
        }
        if (data.Condition("V3_CompDed != NULL"))
        {
                    await page.VerifyV3ComprehensiveDeductibleAsync("Visible", "");
        }
        if (data.Condition("V3_CompDed != NULL"))
        {
                    await page.ClickV3CompDedAsync();
        }
        if (data.Condition("V3_CompDedMoreOpt != NULL"))
        {
                    await page.ClickV3CompDedMoreOptAsync();
        }
        if (data.Condition("V3_CollDed != NULL"))
        {
                    await page.ClickV3CollDedAsync();
        }
        if (data.Condition("V3_CollDedMoreOpt != NULL"))
        {
                    await page.ClickV3CollDedMoreOptAsync();
        }
        //await page.PressCoveragesNewNextAsync("end");
        if (data.Condition("V4_CompCollOnly == \"Yes\""))
        {
                    await page.SelectV4CompCollOnlyYESAsync("");
        }
        if (data.Condition("'V4_Comprehensive Only' != NULL"))
        {
                    await page.WaitForV4ComprehensiveOnlyAsync("Visible");
        }
        if (data.Condition("'V4_Comprehensive Only' != NULL"))
        {
                    await page.SetV4ComprehensiveOnlyAsync(data.Resolve("{{data:v4_comprehensive_only_377}}"));
        }
        if (data.Condition("'V4_ Comprehensive And Collision Only' != NULL"))
        {
                    await page.ClickV4ComprehensiveAndCollisionOnlyAsync();
        }
        if (data.Condition("V4_CompDed != NULL"))
        {
                    await page.VerifyV4ComprehensiveDeductibleAsync("Visible", "");
        }
        if (data.Condition("V4_CompDed != NULL"))
        {
                    await page.ClickV4CompDedAsync();
        }
        if (data.Condition("V4_CompDedMoreOpt != NULL"))
        {
                    await page.ClickV4CompDedMoreOptAsync();
        }
        if (data.Condition("V4_CollDed != NULL"))
        {
                    await page.ClickV4CollDedAsync();
        }
        if (data.Condition("V4_CollDedMoreOpt != NULL"))
        {
                    await page.ClickV4CollDedMoreOptAsync();
        }
        await page.ClickCoveragesNewNextAsync();
        data.Set("Tort Option", data.Get("Tort Option"));
        data.Set("Income Loss Coverage", data.Get("Income Loss Coverage"));
        data.Set("AD&D Coverage", data.Resolve("{{data:ad_d_coverage}}"));
        data.Set("Inc Liab Claims Fam Mem", data.Get("Inc Liab Claims Fam Mem"));
        data.Set("Extraordinary Medical Benefit", data.Get("Extraordinary Medical Benefit"));

    }

    [Given(@"^I complete auto AddlCov policy coveragess$")]
    [When(@"^I complete auto AddlCov policy coveragess$")]
    [Then(@"^I complete auto AddlCov policy coveragess$")]
    public async Task CompleteAutoAddlCovPolicyCoveragessAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForH1AdditionalCoveragesAsync("Visible");
        if (data.Condition("'Tort Option' != NULL"))
        {
            if (await page.IsTortOptionPresentAsync())
            {
                await page.ClickTortOptionAsync();
                await page.PressTortOptionAsync("home");
            }
        }
        if (data.Condition("'Income Loss Coverage' != NULL"))
        {
                    await page.ClickIncomeLossCoverageAsync();
                    //await page.PressIncomeLossCoverageAsync("Home");
        }
        if (data.Condition("UMPD != NULL"))
        {
            if(data.Resolve("{{data:state_variant}}") == "GA")
            {
                await page.ClickUMPDA1000000sync();
            }
            else
            {
                await page.ClickUMPDAsync();
            }
        }
        if (data.Condition("UIMPD != NULL"))
        {

            if (data.Resolve("{{data:state_variant}}") == "GA")
            {
                await page.ClickUIMPD1000Async();
            }
            else
            {
                await page.ClickUIMPDAsync();
            }
        }
        //if (data.Condition("'AD&D Coverage' != NULL AND State != \"AL\" AND State != \"MD\""))
        //{
        //    await page.WaitForADDCoverageAsync("True");
        //}
        if (data.Condition("'AD&D Coverage' != NULL AND State != \"AL\" AND State != \"MD\""))
        {
            await Task.Delay(3000);
            if(await page.IsADDCoveragesAsync())
            {
                await page.ClickADDCoverageAsync();
            }
        }
        if (data.Condition("'AD&D_Driver1' != NULL"))
        {
                    await page.ClickADDDriver1Async();
        }
        if (data.Condition("'AD&D_Driver2' != NULL"))
        {
                    await page.ClickADDDriver2Async();
        }
        if (data.Condition("'AD&D_Driver3' != NULL"))
        {
                    await page.ClickADDDriver3Async();
        }
        if (data.Condition("'AD&D_Driver4' != NULL"))
        {
                    await page.ClickADDDriver4Async();
        }
        if (data.Condition("'AD&D_Driver5' != NULL"))
        {
                    await page.ClickADDDriver5Async();
        }
        if (data.Condition("'Loss of Income Coverage_Driver1' != NULL"))
        {
                    await page.SetLossOfIncomeDriver1Async(data.Resolve("{{data:loss_of_income_driver1_404}}"));
        }
        if (data.Condition("'Loss of Income Coverage_Driver2' != NULL"))
        {
                    await page.SetLossOfIncomeDriver2Async(data.Resolve("{{data:loss_of_income_driver2_405}}"));
        }
        if (data.Condition("'Loss of Income Coverage_Driver3' != NULL"))
        {
                    await page.SetLossOfIncomeDriver3Async(data.Resolve("{{data:loss_of_income_driver3_406}}"));
        }
        if (data.Condition("'Loss of Income Coverage_Driver4' != NULL"))
        {
                    await page.SetLossOfIncomeDriver4Async(data.Resolve("{{data:loss_of_income_driver4_407}}"));
        }
        if (data.Condition("'Loss of Income Coverage_Driver5' != NULL"))
        {
                    await page.SetLossOfIncomeDriver5Async(data.Resolve("{{data:loss_of_income_driver5_408}}"));
        }
        if (data.Condition("'Total Disability Coverage_Driver1' != NULL"))
        {
                    await page.ClickTotalDisabilityCoverageDriver1Async();
        }
        if (data.Condition("'Inc Liab Claims Fam Mem' != NULL"))
        {
                    await page.ClickIncLiabilityClaimsOfFamilyMembersAsync();
        }
        if (data.Condition("'Extraordinary Medical Benefit' != NULL"))
        {
                    await page.ClickExtraordinaryMedicalBenefitAsync();
        }
        if (data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
                    await page.SelectWorkLossNoAsync("");
        }
        data.Set("All HH Members 65 or Pension", data.Get("All HH Members 65 or Pension"));
        data.Set("PIP Limit", data.Get("PIP Limit"));
        data.Set("PIP Deductible", data.Get("PIP Deductible"));
        data.Set("Additional PIP", data.Get("Additional PIP"));
        data.Set("PIP Stacking", data.Get("PIP Stacking"));
        data.Set("Extra PIP Option", data.Get("Extra PIP Option"));
        data.Set("Auto Health Insurer", data.Get("Auto Health Insurer"));
        data.Set("Medical Expense Elimination", data.Get("Medical Expense Elimination"));
        data.Set("Broadened PIP", data.Get("Broadened PIP"));
        data.Set("Additional Death Benefit", data.Get("Additional Death Benefit"));
        data.Set("Waiver of Income Loss", data.Get("Waiver of Income Loss"));

    }

    [Given(@"^I complete auto AddlCov PIP$")]
    [When(@"^I complete auto AddlCov PIP$")]
    [Then(@"^I complete auto AddlCov PIP$")]
    public async Task CompleteAutoAddlCovPIPAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("'All HH Members 65 or Pension' != NULL"))
        {
            if (await page.IsHouseholdMembersAge65OrReceivingPensionPresentAsync())
            {
                await page.ClickHouseholdMembersAge65OrReceivingPensionAsync();
            }
        }
        if (data.Condition("'PIP Limit' != NULL"))
        {
            if (await page.IsPIPLimitPresentAsync())
            {
                await page.ClickPIPLimitAsync();
                await Task.Delay(5000);
            }
        }
        if (data.Condition("'PIP Deductible' != NULL"))
        {
            if (await page.IsPIPDeductiblePresentAsync())
            {
                await page.ClickPIPDeductibleAsync();
            }
        }
        if (data.Condition("'Additional PIP' != NULL"))
        {
            if (await page.IsAdditionalPIPPresentAsync())
            {
                await page.ClickAdditionalPIPAsync();
            }
        }
        if (data.Condition("'PIP Stacking' != NULL"))
        {
            if (await page.IsPIPStackingPresentAsync())
            {
                await page.ClickPIPStackingAsync();
            }
        }
        if (data.Condition("'Extra PIP Option' != NULL"))
        {
            if (await page.IsExtraPIPOptionPresentAsync())
            {
                await page.SelectExtraPIPOptionAsync("");
            }
        }
        if (data.Condition("'Auto Health Insurer' != NULL"))
        {
            if (await page.IsAutoHealthInsurerPresentAsync())
            {
                await page.ClickAutoHealthInsurerAsync();
            }
        }
        if (data.Condition("'Medical Expense Elimination' != NULL"))
        {
            if (await page.IsMedicalExpenseEliminationPresentAsync())
            {
                await page.ClickMedicalExpenseEliminationAsync();
            }
        }
        if (data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
            if (await page.IsWorkLossNoPresentAsync())
            {
                await page.SelectWorkLossNoAsync("");
            }
        }
        if (data.Condition("'Broadened PIP' != NULL"))
        {
            if (await page.IsBroadenedPIPPresentAsync())
            {
                await page.ClickBroadenedPIPAsync();
            }
        }
        if (data.Condition("'Additional Death Benefit' != NULL"))
        {
            if (await page.IsAdditionalDeathBenefitPresentAsync())
            {
                await page.ClickAdditionalDeathBenefitAsync();
            }
        }
        if (data.Condition("'Waiver of Income Loss' != NULL"))
        {
            if (await page.IsWaiverOfIncomeLossPresentAsync())
            {
                await page.ClickWaiverOfIncomeLossAsync();
            }
        }
        data.Set("UMPD/UIMPD_V1", data.Get("UMPD/UIMPD_V1"));
        data.Set("UMPD Coverage_V1", data.Get("UMPD Coverage_V1"));
        data.Set("UIMPD Coverage_V1", data.Get("UIMPD Coverage_V1"));
        data.Set("Rental Reimbursement Coverage_V1", data.Resolve("{{data:rental_reimbursement_coverage_v1}}"));
        data.Set("Theft Deductible_V1", data.Get("Theft Deductible_V1"));
        data.Set("Roadside Assistance Coverage_V1", data.Resolve("{{data:roadside_assistance_coverage_v1}}"));
        data.Set("UMPD/UIMPD_V2", data.Get("UMPD/UIMPD_V2"));
        data.Set("UMPD Coverage_V2", data.Get("UMPD Coverage_V2"));
        data.Set("UIMPD Coverage_V2", data.Get("UIMPD Coverage_V2"));
        data.Set("Rental Reimbursement Coverage_V2", data.Resolve("{{data:rental_reimbursement_coverage_v2}}"));
        data.Set("Theft Deductible_V2", data.Get("Theft Deductible_V2"));
        data.Set("Roadside Assistance Coverage_V2", data.Resolve("{{data:roadside_assistance_coverage_v2}}"));
        data.Set("UMPD/UIMPD_V3", data.Get("UMPD/UIMPD_V3"));
        data.Set("UMPD Coverage_V3", data.Get("UMPD Coverage_V3"));
        data.Set("UIMPD Coverage_V3", data.Get("UIMPD Coverage_V3"));
        data.Set("Rental Reimbursement Coverage_V3", data.Get("Rental Reimbursement Coverage_V3"));
        data.Set("Theft Deductible_V3", data.Get("Theft Deductible_V3"));
        data.Set("Roadside Assistance Coverage_V3", data.Get("Roadside Assistance Coverage_V3"));
        data.Set("UMPD/UIMPD_V4", data.Get("UMPD/UIMPD_V4"));
        data.Set("UMPD Coverage_V4", data.Get("UMPD Coverage_V4"));
        data.Set("UIMPD Coverage_V4", data.Get("UIMPD Coverage_V4"));
        data.Set("Rental Reimbursement Coverage_V4", data.Get("Rental Reimbursement Coverage_V4"));
        data.Set("Theft Deductible_V4", data.Get("Theft Deductible_V4"));
        data.Set("Roadside Assistance Coverage_V4", data.Get("Roadside Assistance Coverage_V4"));
        data.Set("Cycle Accessories_V3", data.Get("Cycle Accessories_V3"));
        data.Set("Original Parts_V3", data.Get("Original Parts_V3"));
        data.Set("Cycle Accessories_V4", data.Get("Cycle Accessories_V4"));
        data.Set("Original Parts_V4", data.Get("Original Parts_V4"));

    }

    [Given(@"^I complete auto AddlCov Vehicle Coverages$")]
    [When(@"^I complete auto AddlCov Vehicle Coverages$")]
    [Then(@"^I complete auto AddlCov Vehicle Coverages$")]
    public async Task CompleteAutoAddlCovVehicleCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (data.Condition("'UMPD/UIMPD_V1' != NULL"))
        {
                    await page.ClickUMPDUIMPDV1Async();
        }
        if (data.Condition("'UMPD Coverage_V1' != NULL"))
        {
            if (data.Condition("State == \"MD\""))
            {
                await page.SelectUMPDVehicle1OneHundredThousandAsync();
            }
            else
            {
                    await page.ClickUMPDCoverageVehicle1Async();
                    //await page.PressUMPDCoverageVehicle1Async("Click");
                    //await page.PressUMPDCoverageVehicle1Async("scroll[2]");
            }
        }
        //if (data.Condition("State != \"MD\" AND 'UMPD Coverage_V1' == \"MORE OPTIONS\""))
        //{
        //            await page.SelectUMPDMoreOptionsCoveragesAsync("");
        //}
        if (data.Condition("'UIMPD Coverage_V1' != NULL"))
        {
                    await page.ClickUIMPDCoverageV1Async();
        }
        if (data.Condition("'Rental Reimbursement Coverage_V1' != NULL AND NOT(State == \"AR\")"))
        {
                    await page.ClickRentalReimbursementCoverageV1Async();
                    //await page.PressRentalReimbursementCoverageV1Async("Click");
                    //await page.PressRentalReimbursementCoverageV1Async("scroll[4]");
        }
        if (data.Condition("'Theft Deductible_V1' != NULL"))
        {
                    await page.ClickTheftDeductibleV1Async();
        }
        if (data.Condition("'Roadside Assistance Coverage_V1' != NULL AND NOT(State == \"NY\")"))
        {
                    await page.ClickRoadsideAssistanceCoverageV1Async();
                    //await page.PressRoadsideAssistanceCoverageV1Async("Click");
                    //await page.PressRoadsideAssistanceCoverageV1Async("Scroll[2]");
        }
        if (data.Condition("'UMPD/UIMPD_V2' != NULL"))
        {
                    await page.ClickUMPDUIMPDV2Async();
        }
        if (data.Condition("'UMPD Coverage_V2' != NULL"))
        {
            if (data.Condition("State == \"MD\""))
            {
                await page.SelectUMPDVehicle2OneHundredThousandAsync();
            }
            else
            {
                    await page.ClickUMPDCoverageVehicle2Async();
            }
        }
        //if (data.Condition("State != \"MD\" AND 'UMPD Coverage_V2' == \"MORE OPTIONS\""))
        //{
        //            await page.SelectUMPDMoreOptionsCoveragesAsync("");
        //}
        if (data.Condition("'UIMPD Coverage_V2' != NULL"))
        {
                    await page.ClickUIMPDCoverageV2Async();
        }
        if (data.Condition("'Rental Reimbursement Coverage_V2' != NULL AND NOT(State == \"AR\")"))
        {
                    await page.ClickRentalReimbursementCoverageV2Async();
                    //await page.PressRentalReimbursementCoverageV2Async("Click");
                    //await page.PressRentalReimbursementCoverageV2Async("scroll[4]");
        }
        if (data.Condition("'Theft Deductible_V2' != NULL"))
        {
                    await page.ClickTheftDeductibleV2Async();
        }
        if (data.Condition("'Roadside Assistance Coverage_V2' != NULL"))
        {
                    await page.ClickRoadsideAssistanceCoverageV2Async();
                    //await page.PressRoadsideAssistanceCoverageV2Async("Click");
                    //await page.PressRoadsideAssistanceCoverageV2Async("scroll[2]");
        }
        if (data.Condition("'Towing and Labor' != NULL"))
        {
                    await page.SelectNoCoverageV1TowingAsync("");
        }
        if (data.Condition("'UMPD/UIMPD_V3' != NULL"))
        {
                    await page.ClickUMPDUIMPDV3Async();
        }
        if (data.Condition("'UMPD Coverage_V3' != NULL"))
        {
                    await page.ClickUMPDCoverageVehicle3Async();
        }
        if (data.Condition("'UMPD Coverage_V3' == \"MORE OPTIONS\""))
        {
                    await page.SelectUMPDMoreOptionsCoveragesAsync("");
        }
        if (data.Condition("'UIMPD Coverage_V3' != NULL"))
        {
                    await page.ClickUIMPDCoverageV3Async();
        }
        if (data.Condition("'Rental Reimbursement Coverage_V3' != NULL"))
        {
                    await page.ClickRentalReimbursementCoverageV3Async();
                    await page.PressRentalReimbursementCoverageV3Async("Click");
                    await page.PressRentalReimbursementCoverageV3Async("scroll[4]");
        }
        if (data.Condition("'Theft Deductible_V3' != NULL"))
        {
                    await page.ClickTheftDeductibleV3Async();
        }
        if (data.Condition("'Roadside Assistance Coverage_V3' != NULL AND NOT(State == \"NY\")"))
        {
                    await page.ClickRoadsideAssistanceCoverageV3Async();
                    await page.PressRoadsideAssistanceCoverageV3Async("Click");
                    await page.PressRoadsideAssistanceCoverageV3Async("scroll[2]");
        }
        if (data.Condition("'Cycle Accessories_V3' != NULL"))
        {
                    await page.ClickCycleAccessoriesV3Async();
        }
        if (data.Condition("'Original Parts_V3' != NULL"))
        {
                    await page.ClickOriginalPartsV3Async();
        }
        if (data.Condition("'UMPD/UIMPD_V4' != NULL"))
        {
                    await page.ClickUMPDUIMPDV4Async();
        }
        if (data.Condition("'UMPD Coverage_V4' != NULL"))
        {
                    await page.ClickUMPDCoverageVehicle4Async();
        }
        if (data.Condition("'UMPD Coverage_V4' == \"MORE OPTIONS\""))
        {
                    await page.SelectUMPDMoreOptionsCoveragesAsync("");
        }
        if (data.Condition("'UIMPD Coverage_V4' != NULL"))
        {
                    await page.ClickUIMPDCoverageV4Async();
        }
        if (data.Condition("'Rental Reimbursement Coverage_V4' != NULL"))
        {
                    await page.ClickRentalReimbursementCoverageV4Async();
                    await page.PressRentalReimbursementCoverageV4Async("Click");
                    await page.PressRentalReimbursementCoverageV4Async("end");
        }
        if (data.Condition("'Theft Deductible_V4' != NULL"))
        {
                    await page.ClickTheftDeductibleV4Async();
        }
        if (data.Condition("'Roadside Assistance Coverage_V4' != NULL AND NOT(State == \"NY\")"))
        {
                    await page.ClickRoadsideAssistanceCoverageV4Async();
        }
        if (data.Condition("'Cycle Accessories_V4' != NULL"))
        {
                    await page.ClickCycleAccessoriesV4Async();
        }
        if (data.Condition("'Original Parts_V4' != NULL"))
        {
                    await page.ClickOriginalPartsV4Async();
        }
        await Task.Delay(7000);

    }

    [Given(@"^I complete auto AddlCov Next$")]
    [When(@"^I complete auto AddlCov Next$")]
    [Then(@"^I complete auto AddlCov Next$")]
    public async Task CompleteAutoAddlCovNextAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForAdditionalCoveragesNextNewNextAsync("Visible");
        await page.ClickAdditionalCoveragesNextNewNextAsync();
        await Task.Delay(17000);
    }

    [Given(@"^I complete pricing and verify the premium$")]
    [When(@"^I complete pricing and verify the premium$")]
    [Then(@"^I complete pricing and verify the premium$")]
    public async Task CompletePricingAndVerifyThePremiumAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForHeaderPricingDetailsAsync();
        await page.ClickPricingDetailsNewNextAsync();

    }

    [Given(@"^I complete underwriting Page Cycle$")]
    [When(@"^I complete underwriting Page Cycle$")]
    [Then(@"^I complete underwriting Page Cycle$")]
    public async Task CompleteUnderwritingPageCycleAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForHaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelonyAsync("Exists");
        await page.SelectNo43938Async("");
        await page.WaitForIsAnyVintageCycleGaragedInADifferentLocationAsync("Exists");
        await page.SelectNo1Async("");
        await page.ClickCycleUnderwritingNextAsync();

    }

    [Given(@"^I complete additional Interest Page$")]
    [When(@"^I complete additional Interest Page$")]
    [Then(@"^I complete additional Interest Page$")]
    public async Task CompleteAdditionalInterestPageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new AdditionalInterestsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForAdditionalInterestNextAsync("Exists");
        await page.ClickAdditionalInterestNextAsync();
        //await page.VerifyEQCommonLoadingIndicatorWaitAsync("Exists", "");

    }

    [Given(@"^I configure direct\-pay billing$")]
    [When(@"^I configure direct\-pay billing$")]
    [Then(@"^I configure direct\-pay billing$")]
    public async Task ConfigureDirectPayBillingAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForHdrBillingAsync("Visible");
        await page.ClickCreateNewBillingAccountAsync();
        await Task.Delay(2000);

        await page.ClickPrimaryAccountHolderNameAsync();
        await page.ClickDirectBillAsync();
        await Task.Delay(2000);
        await page.WaitForN1PaymentAsync("Visible");
        await page.ClickN1PaymentAsync();
        await Task.Delay(2000);

        await page.EnterPaymentDueDateAsync(data.Resolve("{{data:txt_paymentduedate_522}}"));
        await Task.Delay(2000);

        await page.WaitRdBtnFullBalanceAsync("Visible");
        await page.ClickRdBtnFullBalanceAsync();
        await Task.Delay(2000);

        await page.WaitForCHECKAsyncAsync("Visible");
        await page.ClickCHECKAsync();
        await Task.Delay(2000);

        await page.EnterCheckNumberAsync(data.Resolve("{{data:txt_check_number_525}}"));
        await Task.Delay(2000);
        await page.ClickBillingNEXTAsync();
    }

    [Given(@"^I complete submission underwriting comments and review$")]
    [When(@"^I complete submission underwriting comments and review$")]
    [Then(@"^I complete submission underwriting comments and review$")]
    public async Task CompleteSubmissionUnderwritingCommentsAndReviewAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await Task.Delay(25000);
        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForSubmission1Async("Exists");
        //if (await page.IsCommentsPresentAsync())
        //{
        //            await page.VerifyCommentsAsync("Exists", "");
        //}
        //if (await page.IsCommentsPresentAsync())
        //{
        //            await page.VerifyCommentsAsync("Exists", "");
        //}
        var agentCommentCount = await page.FillAllAgentCommentsAsync("test");
        data.Set("AgentCommentFieldCount", agentCommentCount.ToString());
        if (await page.IsReferUWPresentAsync())
        {
                    await page.VerifyReferUWAsync("Visible", "");
        }
        if (await page.IsReferUWPresentAsync())
        {
                    await page.ClickReferUWAsync();
                    await page.ClickSaveExit1Async();
            await this.OpenTheConfiguredPolicyApplicationAsync();
            await this.CompleteTheExpressUnderwritingReviewAsync();
            await this.CompleteDriverInformationForTxtQuotePolicySearchAsync();
            await Task.Delay(4000);
        }
    }

    [Given(@"^I open the configured policy application for openurl$")]
    [When(@"^I open the configured policy application for openurl$")]
    [Then(@"^I open the configured policy application for openurl$")]
    public async Task OpenTheConfiguredPolicyApplicationForOpenurlAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        // Source conditional not executed because no deterministic data/DOM condition was available: If Referral Button > Then
        if (false)
        {
                    await page.NavigateAsync(data.Resolve("{{data:application_url}}"));
        }

        await this.OpenTheConfiguredPolicyApplicationAsync();

    }

    [Given(@"^I complete the Express underwriting review$")]
    [When(@"^I complete the Express underwriting review$")]
    [Then(@"^I complete the Express underwriting review$")]
    public async Task CompleteTheExpressUnderwritingReviewAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ApproveUnderWriterTextAsync(data.GetRequired("QuoteNumber"), data.Resolve("{{data:txt_underwriting_notes_546}}"));
        // Field-level orchestration derived from the canonical Tosca method sequence.
        //if (await page.IsLblLoginIDPresentAsync())
        //{
        //            await page.VerifyLblLoginIDAsync("Visible", "");
        //}
        //if (await page.IsTxtLoginID1PresentAsync())
        //{
        //            await page.WaitForTxtLoginID1Async("Exists");
        //}
        //await page.EnterTxtLoginID1Async(data.Resolve("{{data:txt_login_id_1_537}}"));
        //await page.EnterPasswordAsync(data.Resolve("{{env:PL_DC_PASSWORD}}"));
        //await page.ClickLnkLOGINAsync();
        //if (await page.IsTxtSearchTypePresentAsync())
        //{
        //            await page.WaitForTxtSearchTypeAsync("Visible");
        //}
        //await page.EnterTxtSearchTextAsync(data.Resolve("{{runtime:QuoteNumber}}"));
        //await page.ClickAddEditAdditionalInterestFirstMortgageeSearchAsync();
        //if (await page.IsPolicyQuotePresentAsync())
        //{
        //            await page.ClickPolicyQuoteAsync();
        //}
        //if (await page.IsLnkPricingPresentAsync())
        //{
        //            await page.ClickLnkPricingAsync();
        //}
        //if (await page.IsTxtUnderwritingNotesPresentAsync())
        //{
        //            await page.WaitForTxtUnderwritingNotesAsync("True");
        //}
        //await page.EnterTxtUnderwritingNotesAsync(data.Resolve("{{data:txt_underwriting_notes_546}}"));
        //await page.WaitForBtnApproveAsync("Visible");
        //await page.ClickBtnApproveAsync();
        //await page.ClickLnkHomeAsync();

    }

    [Given(@"^I recall the quote in ExpertQuote$")]
    [When(@"^I recall the quote in ExpertQuote$")]
    [Then(@"^I recall the quote in ExpertQuote$")]
    public async Task RecallTheQuoteInExpertQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsQuotePolicySearchPresentAsync())
        {
                    await page.EnterQuotePolicySearchAsync(data.Resolve("{{data:txt_quote_policy_search_551}}"));
                    await page.PressQuotePolicySearchAsync("CTRL+A");
        }
        await page.EnterQuotePolicySearchAsync(data.Resolve("{{runtime:QuoteNumber}}"));
        await page.ClickNewQuoteSearchAsync();
        if (await page.IsDIVSubmissionPresentAsync())
        {
                    await page.ClickDIVSubmissionAsync();
        }

    }

    [Given(@"^I complete the Level 9 underwriting bypass$")]
    [When(@"^I complete the Level 9 underwriting bypass$")]
    [Then(@"^I complete the Level 9 underwriting bypass$")]
    public async Task CompleteTheLevel9UnderwritingBypassAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsCorrectionNeededStep1PresentAsync())
        {
                    await page.VerifyCorrectionNeededStep1Async("Exists", "");
        }
        if (await page.IsSaveExit1PresentAsync())
        {
                    await page.ClickSaveExit1Async();
        }

    }

    [Given(@"^I open the configured policy application for approve in express ui$")]
    [When(@"^I open the configured policy application for approve in express ui$")]
    [Then(@"^I open the configured policy application for approve in express ui$")]
    public async Task OpenTheConfiguredPolicyApplicationForApproveInExpressUiAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        // Source conditional not executed because no deterministic data/DOM condition was available: If Correction Needed > Then go to Express to bypass L9
        if (false)
        {
                    await page.NavigateAsync(data.Resolve("{{data:application_url}}"));
        }

    }

    [Given(@"^I approve the underwriting referral in Express$")]
    [When(@"^I approve the underwriting referral in Express$")]
    [Then(@"^I approve the underwriting referral in Express$")]
    public async Task ApproveTheUnderwritingReferralInExpressAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsLblLoginIDPresentAsync())
        {
                    await page.VerifyLblLoginIDAsync("Visible", "");
        }
        if (await page.IsTxtLoginID1PresentAsync())
        {
                    await page.WaitForTxtLoginID1Async("Exists");
        }
        await page.EnterTxtLoginID1Async(data.Resolve("{{data:txt_login_id_1_560}}"));
        await page.EnterPasswordAsync(data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await page.ClickLnkLOGINAsync();
        if (await page.IsTxtSearchTypePresentAsync())
        {
                    await page.WaitForTxtSearchTypeAsync("Visible");
        }
        await page.EnterTxtSearchTextAsync(data.Resolve("{{runtime:QuoteNumber}}"));
        await page.ClickAddEditAdditionalInterestFirstMortgageeSearchAsync();
        if (await page.IsPolicyQuotePresentAsync())
        {
                    await page.ClickPolicyQuoteAsync();
        }
        if (data.Condition("MotorCycle != NULL"))
        {
                    await page.ClickLnkMotorcycleAsync();
        }
        if (data.Condition("PersonalAuto != NULL"))
        {
                    await page.ClickLnkPersonalAutoAsync();
        }
        if (data.Condition("RV != NULL"))
        {
                    await page.ClickLnkRVAsync();
        }
        if (await page.IsLnkPricingPresentAsync())
        {
                    await page.ClickLnkPricingAsync();
        }
        if (await page.IsChkBoxBypassLevel9RulesPresentAsync())
        {
                    await page.SetChkBoxBypassLevel9RulesAsync(data.Resolve("{{data:chkbox_bypass_level_9_rules_571}}"));
        }
        await page.ClickBypassLevel9Comments1Async();
        await page.EnterBypassLevel9Comments1Async(data.Resolve("{{data:bypass_level_9_comments_1_573}}"));
        await page.ClickLnkHomeAsync();
        if (await page.IsChkBoxBypassLevel9RulesPresentAsync())
        {
                    await page.VerifyChkBoxBypassLevel9RulesAsync("True", "Enabled");
        }
        if (await page.IsChkBoxBypassLevel9RulesPresentAsync())
        {
                    await page.SetChkBoxBypassLevel9RulesAsync(data.Resolve("{{data:chkbox_bypass_level_9_rules_577}}"));
        }
        await page.ClickBypassLevel9Comments1Async();
        await page.EnterBypassLevel9Comments1Async(data.Resolve("{{data:bypass_level_9_comments_1_579}}"));
        await page.ClickLnkHomeAsync();

    }

    [Given(@"^I complete the Level 9 underwriting bypass for txt quote policy search$")]
    [When(@"^I complete the Level 9 underwriting bypass for txt quote policy search$")]
    [Then(@"^I complete the Level 9 underwriting bypass for txt quote policy search$")]
    public async Task CompleteTheLevel9UnderwritingBypassForTxtQuotePolicySearchAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsQuotePolicySearchPresentAsync())
        {
                    await page.EnterQuotePolicySearchAsync(data.Resolve("{{data:txt_quote_policy_search_583}}"));
                    await page.PressQuotePolicySearchAsync("CTRL+A");
        }
        await page.EnterQuotePolicySearchAsync(data.Resolve("{{runtime:QuoteNumber}}"));
        await page.ClickNewQuoteSearchAsync();
        if (await page.IsDIVSubmissionPresentAsync())
        {
                    await page.ClickDIVSubmissionAsync();
        }

    }

    [Given(@"^I complete the submission checklist$")]
    [When(@"^I complete the submission checklist$")]
    [Then(@"^I complete the submission checklist$")]
    public async Task CompleteTheSubmissionChecklistAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        var browser = _scenario.Get<BrowserSession>();
        await page.ClickSubmissionLinkAsync();
        await Task.Delay(5000);
        await browser.SwitchToNewPageAsync(async () =>
        {
            await page.ClickChecklist1Async();

        });
        await Task.Delay(15000);
        var checklistPage = new ChecklistPage(browser, _scenario.Get<UiActions>());
        await checklistPage.WaitForCurrentItemsVisibleAsync();
        await Task.Delay(2000);
        await checklistPage.ClickFirstChecklistItemAsync();
        await Task.Delay(2000);
        while (await checklistPage.IsAddNotePresentAsync())
        {
            await Task.Delay(2000);
            await checklistPage.EnterNoteAsync("TestChecklistforUW");
            await Task.Delay(2000);
            if (await checklistPage.IsValidFileTypesVisibleAsync())
            {
               var documentFilePath = Path.Combine(
                    AppContext.BaseDirectory,
                    "TestData", "Assets", "Test.png");
                await checklistPage.DragAndDropDocumentAsync(documentFilePath);
                await Task.Delay(6000);
            }
        }
        await Task.Delay(2000);
        await checklistPage.WaitForCurrentItemsVisibleAsync();
        await Task.Delay(2000);

        // Always attempt to return to the original DuckCreek window and dismiss the
        // "Checklist Opened" modal, even if a checklist action above failed, so the
        // outer scenario is not left stuck on the checklist popup.
        await Task.Delay(8000);
        await browser.SwitchToFirstPageAsync();
        await Task.Delay(5000);
        await page.ClickChecklistOpenedOKAsync();
        await Task.Delay(7000);
        //await Task.Delay(2000);
        //await page.ClickAutoCycleRVApplicationAsync();
        //await page.ClickDIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync();
        //await page.EnterCaptionAsync(data.Resolve("{{data:caption_591}}"));
        //await page.EnterFilePathAsync(data.Resolve("{{data:filepath_592}}"));
        //await page.EnterButtonAsync(data.Resolve("{{data:button_593}}"));
        //await page.ClickDIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync();
        //await page.EnterCaptionAsync(data.Resolve("{{data:caption_595}}"));
        //await page.EnterFilePathAsync(data.Resolve("{{data:filepath_596}}"));
        //await page.EnterButtonAsync(data.Resolve("{{data:button_597}}"));
        //if (await page.IsChecklist1PresentAsync())
        //{
        //            await page.VerifyChecklist1Async("Exists", "");
        //}
        //if (await page.IsChecklist1PresentAsync())
        //{
        //            await page.VerifyChecklist1Async("Exists", "");
        //}
        //if (await page.IsAutoCycleRVApplicationPresentAsync())
        //{
        //            await page.ClickAutoCycleRVApplicationAsync();
        //}
        //await page.ClickDIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync();
        //if (await page.IsCaptionPresentAsync())
        //{
        //            await page.EnterCaptionAsync(data.Resolve("{{data:caption_602}}"));
        //}
        //await page.EnterFilePathAsync(data.Resolve("{{data:filepath_603}}"));
        //await page.EnterButtonAsync(data.Resolve("{{data:button_604}}"));
        //if (await page.IsDIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerPresentAsync())
        //{
        //            await page.ClickDIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync();
        //}
        //if (await page.IsCaptionPresentAsync())
        //{
        //            await page.EnterCaptionAsync(data.Resolve("{{data:caption_606}}"));
        //}
        //await page.EnterFilePathAsync(data.Resolve("{{data:filepath_607}}"));
        //await page.EnterButtonAsync(data.Resolve("{{data:button_608}}"));
        //await page.VerifyEQCommonLoadingIndicatorWaitAsync("Exists", "");
        //await page.ClickChecklistCloseOkAsync();

    }

    [Given(@"^I transmit the policy$")]
    [When(@"^I transmit the policy$")]
    [Then(@"^I transmit the policy$")]
    public async Task TransmitThePolicyAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForTransmitAsync();
        await page.ClickTransmitAsync();

    }

    [Given(@"^I verify policy transmission confirmation$")]
    [When(@"^I verify policy transmission confirmation$")]
    [Then(@"^I verify policy transmission confirmation$")]
    public async Task VerifyPolicyTransmissionConfirmationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.EnterTransmitConfirmationAsync("{DATE}");

    }

}
