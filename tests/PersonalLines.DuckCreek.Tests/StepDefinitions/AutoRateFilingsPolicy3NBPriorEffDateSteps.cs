using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.PLDC.Pages;

namespace InsuranceAutomation.PLDC.StepDefinitions;

[Binding, Scope(Feature = "Auto Rate Filings Policy 3 NB Prior Eff Date")]
public sealed class AutoRateFilingsPolicy3NBPriorEffDateSteps
{
    private readonly ScenarioContext _scenario;
    public AutoRateFilingsPolicy3NBPriorEffDateSteps(ScenarioContext scenario) => _scenario = scenario;

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

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForLblClientInfoAsync("Exists");
        await page.VerifyLblClientInfoAsync(data.Resolve("{{data:expected_lbl_client_info_5}}"), "");
        await page.EnterTxtFirstAsync(data.Get("AL_ClientData.First Name"));
        await page.EnterTxtLastAsync(data.Get("AL_ClientData.Last Name"));
        await page.WaitForAddEditAdditionalInterestFirstMortgageeSearchAsync("Exists");
        await page.ClickAddEditAdditionalInterestFirstMortgageeSearchAsync();
        await page.WaitForBtnCreateNewClientAsync("Exists");
        await page.ClickBtnCreateNewClientAsync();
        await page.ClickPricingDetailsNextAsync();
        data.Set("StateName", data.Resolve("{{data:statename}}"));
        data.Set("State", data.Resolve("{{data:state}}"));
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
        await page.WaitForEnterALocationAsync("Visible");
        await page.EnterEnterALocationAsync(data.Get("AL_ClientData.Street Address"));
        await page.WaitForOwnerAddressLine2Async("Visible");
        await page.EnterOwnerAddressLine2Async(data.Get("AL_ClientData.Apartment"));
        await page.SelectStateAsync(data.Resolve("{{data:statename}}"));
        await page.WaitForOwnerAddressCityNewAsync("Visible");
        await page.EnterOwnerAddressCityNewAsync(data.Get("AL_ClientData.City"));
        await page.WaitForOwnerAddressZipAsync("Visible");
        await page.EnterOwnerAddressZipAsync(data.Get("AL_ClientData.ZIP"));
        await page.WaitForYesAtLeast90DaysAsync("Visible");
        await page.ClickYesAtLeast90DaysAsync();
        await page.SelectYesClientResidesAsync("");
        await page.ClickAccountDetailsNextAsync();
        data.Set("EffectiveDate", "{Date[{DATE}][][MM/dd/yyyy]}");
    }

    [Given(@"^I start the policy proposal$")]
    [When(@"^I start the policy proposal$")]
    [Then(@"^I start the policy proposal$")]
    public async Task StartThePolicyProposalAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForPersonalAutoAsync("Visible");
        await page.ClickPersonalAutoAsync();
        await page.EnterEffectiveDateAsync(data.Resolve("{{data:Effective Date}}"));
        await page.EnterAgentCodeAsync(data.Resolve("{{data:agentcode_42}}"));
        await page.SelectStateNameAsync(data.Resolve("{{data:statename}}"));
        await page.SelectWritingCompanyAsync("");
        await page.EnterWritingCompanyAsync(data.Resolve("{{data:writingcompany_49}}"));
        await page.WaitForSameAsMailingAddressAsync("True");
        await page.ClickSameAsMailingAddressAsync();
        await page.WaitForStartQuoteAsync("Visible");
        await page.WaitForStartQuoteAsync("True");
        await page.ClickStartQuoteAsync();

        if (await page.IsPROCEEDPresentAsync())
        {
            await page.VerifyPROCEEDAsync("Exists", "");
            await page.ClickCONFIRMAsync();
            await page.PauseAsync(5000);
            //await page.EnterSSNAsync("444103367");
            //await page.ClickCONFIRMAsync();
        }

        if (await page.IsSSNPresentAsync())
        {
            await page.EnterSSNAsync(data.Resolve("{{data:AL_ClientData.SSN}}"));
            await page.ClickCONFIRMAsync();
        }

        if (await page.IsCONFIRMPresentAsync())
        {
            await page.ClickEditAsync();
            await page.EnterSSNAsync(data.Resolve("{{data:AL_ClientData.SSN}}"));
            await page.VerifyProposalStartProceedSSNSUBMITAsync("Exists", "");
            await page.ClickProposalStartProceedSSNSUBMITAsync();
            await page.PauseAsync(5000);
        }
        if (await page.IsUSEEXISTINGACCOUNTPresentAsync())
        {
            await page.ClickUSEEXISTINGACCOUNTAsync();
            await page.PauseAsync(5000);
        }

        if (await page.IsCREATENEWACCOUNTPresentAsync())
        {
            await page.ClickCREATENEWACCOUNTAsync();
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
        await page.ApprovePolicyLevel9BAsync(data.GetRequired("QuoteNumber"), data.Resolve("{{data:txt_underwriting_notes_631}}"));

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

        // Field-level orchestration derived from the canonical Tosca method sequence.
        if (await page.IsGenderPresentAsync())
        {
            await page.ClickGenderMaleAsync();
        }
        if (await page.IsMaritalStatusSinglePresentAsync())
        {
            await page.ClickMaritalStatusSingleAsync();
        }

        await page.ClickPrimaryNamedInsuredAsync();
        await page.ClickOperatorStatusAssignedAsync();
        await page.EnterDriverSLicenseNumberAsync(data.Resolve("{{data:driver_s_license_number_169}}"));
        await page.EnterYrsLicensedCurrentStateAsync(data.Resolve("{{data:yrs_licensed_current_state_172}}"));
        await page.EnterMonthsLicensedCurrentStateAsync(data.Resolve("{{data:months_licensed_current_state_174}}"));
        if (data.Condition("'State' == \"TX\""))
        {
            await page.EnterDaysOperatedUninsuredAsync(data.Resolve("{{data:daysoperateduninsured_175}}"));
        }
        if (data.Condition("'State' == \"CA\""))
        {
            await page.EnterYrsLicensedAllStatesAsync(data.Resolve("{{data:yrslicensed_all_states_177}}"));

        }
        if (data.Condition("'State' == \"CA\""))
        {
            await page.EnterAllStatesTimeLicensedMonthsAsync(data.Resolve("{{data:months_licensed_all_states_178}}"));
        }


        if (await page.IsFinancialResponsibilityNoPresentAsync())
        {
            await page.ClickFinancialResponsibilityNoAsync();
        }

        if (await page.IsNoNeedWasNotLicensedPresentAsync())
        {
            await page.ClickNoNeedWasNotLicensedAsync();
        }


        if (await page.IsInsuredWithANPriorLabelPresentAsync())
        {
            await page.ClickInsuredWithANPriorNoChipAsync();
        }

        await page.ClickSaveAndContinue9CB7AAsync();


        if (await page.IsCONTINUED555DPresentAsync())
        {
            await page.ClickCONTINUED555DAsync();
        }

    }

    [Given(@"^I review household\-driver prefill results$")]
    [When(@"^I review household\-driver prefill results$")]
    [Then(@"^I review household\-driver prefill results$")]
    public async Task ReviewHouseholdDriverPrefillResultsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SocialSecurityPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        //await page.ClickPrefillDriverSNavAsync();
        if (await page.IsReasonForNotIncludingThisIndividualPresentAsync())
        {
            for (var row = 0; await page.IsReasonForNotIncludingThisIndividualPresentAsync(row); row++)
            {
                await page.SelectReasonForNotIncludingThisIndividualAsync(row, "Never resided in the household and doesn't regularly use or have access to policy vehicle(s)");
            }
        }
        
        if (await page.IsSaveAndContinuePresentAsync())
        {
            await page.ClickSaveAndContinueAsync();
        }

    }

    [Given(@"^I complete vehicle Summary Automobile Rate Filing$")]
    [When(@"^I complete vehicle Summary Automobile Rate Filing$")]
    [Then(@"^I complete vehicle Summary Automobile Rate Filing$")]
    public async Task CompleteVehicleSummaryAutomobileRateFilingAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        var navigationPage = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());


        // Field-level orchestration derived from the canonical Tosca method sequence.
        //await navigationPage.WaitForVehicleInformationHeaderAsync("Visible");
        if (await page.IsAdditionalVehiclePresentAsync())
        {
            await page.ClickAdditionalVehicleAsync();
            await page.ClickAutoVehiclePrefillSelectionNextAsync();
        }
        else if (await page.IsSelectVehiclesToBeCoveredHeaderPresentAsync())
        {
            if (await page.IsMoreOptionsDropdownLabelPresentAsync())
            {
                await page.ClickMoreOptionsDropdownLabelAsync();
                if (await page.IsAdditionalVehicleSMenuItemPresentAsync())
                {
                    await page.ClickAdditionalVehicleSMenuItemAsync();
                    await page.ClickAutoVehiclePrefillSelectionNextAsync();
                }

            }
        }

        //Verhicle 1
        await page.EnterVIN06D01Async(data.Resolve("{{data:txt_vin_214}}"));
        await page.ClickVehicleNB1Async();
        await page.ClickVehicleTypeAutomobileAsync();


        //if (await page.IsUsedInTravellingOrPermanentResidenceNoPresentAsync())
        //{
        //    await page.ClickUsedInTravellingOrPermanentResidenceNoAsync();
        //}

        await page.ClickVehicleOwnedOrFinancedOwnAsync();

        if (await page.IsCONTINUED555DPresentAsync())
        {
            await page.ClickCONTINUED555DAsync();
        }
        //if (data.Condition("State == \"AL\" || State == \"AR\" || State == \"AZ\" || State == \"CO\" || State == \"IA\""))
        //{
        //    await page.ClickCustomizedEquipmentNoAsync();
        //}
        //if (data.Condition("State == \"AL\" || State == \"AR\" || State == \"AZ\" || State == \"CO\" || State == \"IA\""))
        //{
        //    await page.ClickPleasureWorkUseAsync();
        //}
        await page.ClickCustomizedEquipmentNoAsync();

        if (data.Condition("State != \"CA\""))
        {
            await page.ClickPleasureWorkUseAsync();
        }


        //if (data.Condition("State == \"OK\""))
        //{
        //            //await page.SelectNativeAmericanRegisterNOAsync("");
        //}
        //if (data.Condition("State != \"AZ\" AND State != \"MD\" AND State != \"OH\" AND State != \"CA\" AND State != \"VA\" AND State != \"WI\" AND State != \"UT\""))
        //{
        //    if (await page.IsAntiTheftYesPresentAsync())
        //    {
        //        await page.SelectAntiTheftYesAsync("");
        //    }
        //    if (await page.IsAntiTheftCategory1PresentAsync())
        //    {
        //        await page.ClickAntiTheftCategory1Async();
        //    }
        //    if (await page.IsActiveDisablingDeviceAndWindowGlassEtchingPresentAsync())
        //    {
        //        await page.ClickActiveDisablingDeviceAndWindowGlassEtchingAsync();
        //    }
        //}
        if (data.Condition("State == \"NY\""))
        {
            if (await page.IsVehicleUsedForBusinessNoPresentAsync())
            {
                await page.ClickVehicleUsedForBusinessNoAsync();
            }
            if (await page.IsHowManyDaysPerWeek1PresentAsync())
            {
                await page.ClickHowManyDaysPerWeek1Async();
            }
            if (await page.IsHowManyMilesPerDayOneWayPresentAsync())
            {
                await page.EnterHowManyMilesPerDayOneWayAsync("10");
            }
            if (await page.IsHowManyAnnualMilesDrivenOutsidePresentAsync())
            {
                await page.EnterHowManyAnnualMilesDrivenOutsideAsync("3500");
            }
        }
        if (data.Condition("State == \"KS\""))
        {
            if (await page.IsVehicleUsedForBusinessNoPresentAsync())
            {
                await page.ClickVehicleUsedForBusinessNoAsync();
            }
            if (await page.IsHowManyDaysPerWeek1PresentAsync())
            {
                await page.ClickHowManyDaysPerWeek1Async();
            }
            if (await page.IsHowManyMilesPerDayOneWayPresentAsync())
            {
                await page.EnterHowManyMilesPerDayOneWayAsync("10");
            }
            if (await page.IsHowManyAnnualMilesDrivenOutsidePresentAsync())
            {
                await page.EnterHowManyAnnualMilesDrivenOutsideAsync("3500");
            }
        }

        if (data.Condition("(State == \"NY\" OR State == \"VT\")"))
        {
            await page.ClickActiveDisablingDeviceAsync();
        }

        if (data.Condition("State == \"CA\""))
        {
            await page.ClickPleasureCANYFFCICAsync();
        }



        await page.EnterPurchaseDateBB8AFAsync(data.Resolve("{{data:txt_purchase_date_237}}"));
        await page.EnterOdometer3843FAsync(data.Resolve("{{data:txt_odometer_239}}"));
        await Task.Delay(3000);
        if (await page.IsAnnualMileage12A49PresentAsync())
        {
            await page.EnterAnnualMileage12A49Async(data.Resolve("{{data:ny_ffcic_total_annual_miles_229}}"));
        }
        await page.ClickSaveContinue2E7CDAsync();

        //Verhicle 2
        if (await page.IsOptOutPresentAsync())
        {
            await page.ClickOptOutAsync();
        }

        await page.ClickAddVehicleAsync();

        await page.EnterVIN0A17CAsync(data.Resolve("{{data:vin_243}}"));
        await page.ClickVeh1Async();
        await page.ClickVehicleTypeMoreOptionsAsync();
        await page.ClickCollectorCarAsync();
        await page.ClickVehicleMoreOptionsAsync();
        await page.ClickClassicAsync();
        await page.EnterAgreedValue8E288Async(data.Resolve("{{data:agreed_value_250}}"));
        await page.ClickVehicleOwnedOrFinancedOwnAgreedValueAsync();


        if (await page.IsCONTINUED555DPresentAsync())
        {
            await page.ClickCONTINUED555DAsync();
        }
        
        if (data.Condition("State != \"KS\""))
        {
            await page.ClickRestrictedUseAsync();
        }
        await page.EnterAppraisalDate8A115Async(data.Resolve("{{data:appraisal_date_255}}"));
        if (await page.IsOdometerRows0PresentAsync())
        {
            await page.EnterOdometerRows0Async(data.Resolve("{{data:odometer_274}}"));
        }
        if (await page.IsTotalAnnualMileagePresentAsync())
        {
            await page.EnterTotalAnnualMileageAsync(data.Resolve("{{data:total_annual_mileage_257}}"));
        }
        
        await page.ClickSaveContinue86B78Async();

        await page.ClickAddVehicleAsync();

        //Verhicle 3
        await page.EnterVIN0A17CAsync(data.Resolve("{{data:vin_261}}"));
        await page.ClickVeh3Async();
        await page.ClickVehicleTypeMoreOptionsAsync();
        await page.ClickCollectorCarAsync();
        await page.ClickModernClassicAsync();
        await page.EnterAgreedValue8E288Async(data.Resolve("{{data:agreed_value_267}}"));
        await page.ClickOwnB8575Async();
        if (await page.IsCONTINUED555DPresentAsync())
        {
            await page.ClickCONTINUED555DAsync();
        }
        
        if (data.Condition("State != \"KS\""))
        {
            await page.ClickRestrictedUseAsync();
        }
        await page.EnterAppraisalDate8A115Async(data.Resolve("{{data:appraisal_date_272}}"));
        if (await page.IsOdometerRows0PresentAsync())
        {
            await page.EnterOdometerRows0Async(data.Resolve("{{data:odometer_287}}"));
        }
        if (await page.IsTotalAnnualMileagePresentAsync())
        {
            await page.EnterTotalAnnualMileageAsync(data.Resolve("{{data:total_annual_mileage_276}}"));
        }
        await page.ClickSaveContinue86B78Async();

        if (await page.IsCONTINUED555DPresentAsync())
        {
            await page.ClickCONTINUED555DAsync();
        }
       
        await page.ClickPricingDetailsNextAsync();
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
        if (await page.IsCONTINUED555DPresentAsync())
        {
            await page.ClickCONTINUED555DAsync();
        }

        await page.WaitForDriverAssignmentHeaderAsync("Visible");
        await Task.Delay(6000);

        await page.ClickSelectAVehicleToassignDriverAsync();
        await page.ClickDriver1PrincipalOccasionalAsync();
        await page.ClickMultipleDriverAssignmentNextAsync();

    }

    [Given(@"^I complete multiple Driver Assignment$")]
    [When(@"^I complete multiple Driver Assignment$")]
    [Then(@"^I complete multiple Driver Assignment$")]
    public async Task CompleteMultipleDriverAssignmentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new DriversPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (await page.IsCONTINUED555DPresentAsync())
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

        // Field-level orchestration derived from the canonical Tosca method sequence.
        await page.WaitForClaimsViolationsHeaderAsync("Visible");
        var requiredClaimEdits = await page.GetRequiredClaimEditIdsAsync();
        data.Set("ClaimsRequiringEditCount", requiredClaimEdits.Count.ToString());
        foreach (var editButtonTestId in requiredClaimEdits)
        {
            await page.CompleteRequiredClaimEditAsync(editButtonTestId);
        }

        await page.VerifyNoClaimsRequireEditAsync();
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
        await page.WaitForDiscountsAdjustmentsHeaderAsync("Visible");
        await Task.Delay(6000);

        if (data.Condition("State == \"MD\" OR State == \"NJ\""))
        {
            await page.ClickResidentiaProperty1Async();

        }

        if (data.Condition("State == \"NJ\""))
        {
            await page.ClickN1500030000Async();
        }
        data.Set("Commercial Auto", data.Get("Commercial Auto"));
        data.Set("Special Farm Package", data.Get("Special Farm Package"));
        data.Set("Safe Cycle Discount", data.Get("Safe Cycle Discount"));
        data.Set("Rider Group Discount", data.Get("Rider Group Discount"));

        //if (data.Condition("State == \"AL\" || State == \"AR\" || State == \"AZ\" || State == \"CO\" || State == \"IA\""))
        //{
        //    await page.ClickSetOnAsync();
        //    await Task.Delay(5000);
        //}

        await page.ClickSetOnAsync();


        if (await page.IsCommercialAutoOverridePresentAsync())
        {
            await page.ClickCommercialAutoOverrideOnAsync();
        }

        if (await page.IsSpecialFarmPackageOverridePresentAsync())
        {
            await page.ClickSpecialFarmPackageOverrideOnAsync();
        }

        if (data.Condition("State == \"DE\""))
        {
            await page.ClickDefensiveDriverCourseBasicAsync();
        }

        await page.ClickDiscountNEWNextAsync();

        data.Set("Supplemental UM/UIM Opt In", data.Get("Supplemental UM/UIM Opt In"));

    }

    [Given(@"^I complete coverages$")]
    [When(@"^I complete coverages$")]
    [Then(@"^I complete coverages$")]
    public async Task CompleteCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        // Field-level orchestration derived from the canonical Tosca method sequence.
        //await page.ClickCoveragesTabAsync();
        await page.WaitForCoveragesHeaderAsync("Visible");

        if (data.Condition("PolicyCovOption == \"OPTION 1\""))
        {
            await page.SetOption1Async(data.Resolve("{{data:option_1_331}}"));
        }
        if (data.Condition("PolicyCovOption == \"OPTION 2\""))
        {
            await page.ClickOprion2Async();
        }
        if (data.Condition("PolicyCovOption == \"OPTION 3\""))
        {
            await page.SetOption3Async(data.Resolve("{{data:option_3_333}}"));
        }
        await page.WaitForCoveragesHeaderAsync("Visible");
        await page.ClickV1CompDed500Async();
        await page.ClickV1CollDed500Async();
        await page.ClickV2CompDed500Async();
        await page.ClickV2CollDed500Async();
        await page.ClickV3CompDed500Async();
        await page.ClickV3CollDed500Async();
        await page.ClickCoveragesNewNextAsync();
        await Task.Delay(4000);
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
        var navigationPage = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await navigationPage.WaitForAdditionalCoveragesHeaderAsync("Visible");
        if (data.Condition("State == \"AR\""))
        {
            await page.ClickIncomeLossNoCoverageChipAsync();
        }

        if (await page.IsLossOfIncomeCoverageHeaderAsync())
        {
            await page.ClickLossOfIncomeCoverageAsync();
        }
        if (data.Condition("State != \"CA\""))
        {
            await page.ClickAccidentalDeathNoCoverageChipAsync();
        }
        if (data.Condition("State == \"GA\""))
        {
            await page.ClickUMPD10000Async();
            await page.ClickUIMPD1000Async();

            await page.ClickTheftDeductibleV1Async();
            await page.ClickTheftDeductibleNoCoverageV2Async();
            await page.ClickTheftDeductibleV3Async();
        }
        await Task.Delay(3000);
        if (await page.IsPIPHeaderPresentAsync())
        {
            await page.ClickPIPBasic15000Async();
            await page.ClickPIPDeductableAsync();
        }

        if (data.Condition("State == \"AR\""))
        {
            await page.ClickUMPDCoverageNoCoverageForAllRowsAsync();
        }
        await page.ClickV1RoadsideAssistanceNoCoverageAsync();
        await page.ClickV2RoadsideAssistanceNoCoverageAsync();
        await page.ClickV3RoadsideAssistanceNoCoverageAsync();
        await page.ClickCoveragesNextAsync();


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
                    await page.ClickHouseholdMembersAge65OrReceivingPensionAsync();
        }
        if (data.Condition("'PIP Limit' != NULL"))
        {
                    await page.ClickPIPLimitAsync();
        }
        if (data.Condition("'PIP Deductible' != NULL"))
        {
                    await page.ClickPIPDeductibleAsync();
        }
        if (data.Condition("'Additional PIP' != NULL"))
        {
                    await page.ClickAdditionalPIPAsync();
        }
        if (data.Condition("'PIP Stacking' != NULL"))
        {
                    await page.ClickPIPStackingAsync();
        }
        if (data.Condition("'Extra PIP Option' != NULL"))
        {
                    await page.SelectExtraPIPOptionAsync("");
        }
        if (data.Condition("'Auto Health Insurer' != NULL"))
        {
                    await page.ClickAutoHealthInsurerAsync();
        }
        if (data.Condition("'Medical Expense Elimination' != NULL"))
        {
                    await page.ClickMedicalExpenseEliminationAsync();
        }
        if (data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
                    await page.SelectWorkLossNoAsync("");
        }
        if (data.Condition("'Broadened PIP' != NULL"))
        {
                    await page.ClickBroadenedPIPAsync();
        }
        if (data.Condition("'Additional Death Benefit' != NULL"))
        {
                    await page.ClickAdditionalDeathBenefitAsync();
        }
        if (data.Condition("'Waiver of Income Loss' != NULL"))
        {
                    await page.ClickWaiverOfIncomeLossAsync();
        }
        data.Set("UMPD/UIMPD_V1", data.Get("UMPD/UIMPD_V1"));
        data.Set("UMPD Coverage_V1", data.Get("UMPD Coverage_V1"));
        data.Set("UIMPD Coverage_V1", data.Get("UIMPD Coverage_V1"));
        data.Set("Rental Reimbursement Coverage_V1", data.Get("Rental Reimbursement Coverage_V1"));
        data.Set("Theft Deductible_V1", data.Get("Theft Deductible_V1"));
        data.Set("Roadside Assistance Coverage_V1", data.Resolve("{{data:roadside_assistance_coverage_v1}}"));
        data.Set("UMPD/UIMPD_V2", data.Get("UMPD/UIMPD_V2"));
        data.Set("UMPD Coverage_V2", data.Get("UMPD Coverage_V2"));
        data.Set("UIMPD Coverage_V2", data.Get("UIMPD Coverage_V2"));
        data.Set("Rental Reimbursement Coverage_V2", data.Get("Rental Reimbursement Coverage_V2"));
        data.Set("Theft Deductible_V2", data.Get("Theft Deductible_V2"));
        data.Set("Roadside Assistance Coverage_V2", data.Resolve("{{data:roadside_assistance_coverage_v2}}"));
        data.Set("UMPD/UIMPD_V3", data.Get("UMPD/UIMPD_V3"));
        data.Set("UMPD Coverage_V3", data.Get("UMPD Coverage_V3"));
        data.Set("UIMPD Coverage_V3", data.Get("UIMPD Coverage_V3"));
        data.Set("Rental Reimbursement Coverage_V3", data.Get("Rental Reimbursement Coverage_V3"));
        data.Set("Theft Deductible_V3", data.Get("Theft Deductible_V3"));
        data.Set("Roadside Assistance Coverage_V3", data.Resolve("{{data:roadside_assistance_coverage_v3}}"));
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
                    await page.ClickUMPDCoverageVehicle1Async();
                    await page.PressUMPDCoverageVehicle1Async("Click");
                    await page.PressUMPDCoverageVehicle1Async("scroll[2]");
        }
        if (data.Condition("'UMPD Coverage_V1' == \"MORE OPTIONS\""))
        {
                    await page.SelectUMPDMoreOptionsCoveragesAsync("");
        }
        if (data.Condition("'UIMPD Coverage_V1' != NULL"))
        {
                    await page.ClickUIMPDCoverageV1Async();
        }
        if (data.Condition("'Rental Reimbursement Coverage_V1' != NULL"))
        {
                    await page.ClickRentalReimbursementCoverageV1Async();
                    await page.PressRentalReimbursementCoverageV1Async("Click");
                    await page.PressRentalReimbursementCoverageV1Async("scroll[4]");
        }
        if (data.Condition("'Theft Deductible_V1' != NULL"))
        {
                    await page.ClickTheftDeductibleV1Async();
        }
        if (data.Condition("'Roadside Assistance Coverage_V1' != NULL AND NOT(State == \"NY\")"))
        {
                    await page.ClickRoadsideAssistanceCoverageV1Async();
                    await page.PressRoadsideAssistanceCoverageV1Async("Click");
                    await page.PressRoadsideAssistanceCoverageV1Async("Scroll[2]");
        }
        if (data.Condition("'UMPD/UIMPD_V2' != NULL"))
        {
                    await page.ClickUMPDUIMPDV2Async();
        }
        if (data.Condition("'UMPD Coverage_V2' != NULL"))
        {
                    await page.ClickUMPDCoverageVehicle2Async();
        }
        if (data.Condition("'UMPD Coverage_V2' == \"MORE OPTIONS\""))
        {
                    await page.SelectUMPDMoreOptionsCoveragesAsync("");
        }
        if (data.Condition("'UIMPD Coverage_V2' != NULL"))
        {
                    await page.ClickUIMPDCoverageV2Async();
        }
        if (data.Condition("'Rental Reimbursement Coverage_V2' != NULL"))
        {
                    await page.ClickRentalReimbursementCoverageV2Async();
                    await page.PressRentalReimbursementCoverageV2Async("Click");
                    await page.PressRentalReimbursementCoverageV2Async("scroll[4]");
        }
        if (data.Condition("'Theft Deductible_V2' != NULL"))
        {
                    await page.ClickTheftDeductibleV2Async();
        }
        if (data.Condition("'Roadside Assistance Coverage_V2' != NULL"))
        {
                    await page.ClickRoadsideAssistanceCoverageV2Async();
                    await page.PressRoadsideAssistanceCoverageV2Async("Click");
                    await page.PressRoadsideAssistanceCoverageV2Async("scroll[2]");
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

    }

    [Given(@"^I complete auto AddlCov Next$")]
    [When(@"^I complete auto AddlCov Next$")]
    [Then(@"^I complete auto AddlCov Next$")]
    public async Task CompleteAutoAddlCovNextAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickAdditionalCoveragesNextNewNextAsync();

    }

    [Given(@"^I complete pricing and verify the premium$")]
    [When(@"^I complete pricing and verify the premium$")]
    [Then(@"^I complete pricing and verify the premium$")]
    public async Task CompletePricingAndVerifyThePremiumAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForHeaderPricingDetailsAsync();
        await page.ClickPricingDetailsNewNextAsync();

    }

    [Given(@"^I complete underwriting Page Auto$")]
    [When(@"^I complete underwriting Page Auto$")]
    [Then(@"^I complete underwriting Page Auto$")]
    public async Task CompleteUnderwritingPageAutoAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForHeaderUnderwritingAsync("Exists");
        if (await page.IsNo77DAEPresentAsync())
        {
            await page.ClickNo77DAEAsync();
        }
        if (await page.IsAreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructurePresentAsync())
        {
            await page.WaitForAreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructureAsync("Visible");
            await page.ClickVehiclesKeptEnclosedYesAsync();
        }
        if (await page.IsWhoWillCompleteInspectionHeaderPresentAsync())
        {
            await page.ClickCompleteInspectionAgentAsync();
        }
        await page.ClickUnderwritingUnderwritingNextNextAsync();

    }

    [Given(@"^I complete additional Interest Page$")]
    [When(@"^I complete additional Interest Page$")]
    [Then(@"^I complete additional Interest Page$")]
    public async Task CompleteAdditionalInterestPageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new AdditionalInterestsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.WaitAdditionalInterestHeaderAsync("Visible");
        await page.ClickAdditionalInterestNextAsync();
    }

    [Given(@"^I configure direct\-pay billing$")]
    [When(@"^I configure direct\-pay billing$")]
    [Then(@"^I configure direct\-pay billing$")]
    public async Task ConfigureDirectPayBillingAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await Task.Delay(6000);
        await page.WaitForHdrBillingAsync("Visible");
        await page.ClickCreateNewBillingAccountAsync();
        await page.WaitForPrimaryAccountHolderNameAsync("Visible");
        await Task.Delay(6000);
        await page.ClickPrimaryAccountHolderNameAsync();
        await Task.Delay(4000);
        
        await page.WaitForDirectBillAsync("Visible");
        await page.ClickDirectBillAsync();
        
        await page.WaitForN1PaymentAsync("Visible");
        await Task.Delay(4000);
        await page.ClickN1PaymentAsync();
        await page.WaitForPaymentDueDateAsync("Visible");
        await Task.Delay(4000);
        await page.EnterPaymentDueDateAsync(data.Resolve("{{data:txt_paymentduedate_575}}"));
        await page.WaitForRdBtnFullBalanceAsync("Visible");
        await Task.Delay(5000);
        await page.ClickRdBtnFullBalanceAsync();
        await page.WaitForCHECKAsync("Visible");
        await Task.Delay(4000);
        await page.ClickCHECKAsync();
        await page.WaitForCheckNumberAsync("Visible");
        await Task.Delay(4000);
        await page.EnterCheckNumberAsync(data.Resolve("{{data:txt_check_number_578}}"));
        await Task.Delay(4000);
        await page.ClickBillingNEXTAsync();
        await Task.Delay(8000);

    }

    [Given(@"^I complete the Level 9 underwriting bypass$")]
    [When(@"^I complete the Level 9 underwriting bypass$")]
    [Then(@"^I complete the Level 9 underwriting bypass$")]
    public async Task CompleteTheLevel9UnderwritingBypassAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (await page.IsCorrectionNeededStep1PresentAsync())
        {
                    await page.VerifyCorrectionNeededStep1Async("Exists", "");
        }
        if (await page.IsSaveExit1PresentAsync())
        {
                    await page.ClickSaveExit1Async();
        }

    }

    [Given(@"^I open the configured policy application for openurl$")]
    [When(@"^I open the configured policy application for openurl$")]
    [Then(@"^I open the configured policy application for openurl$")]
    public async Task OpenTheConfiguredPolicyApplicationForOpenurlAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
    }

    [Given(@"^I approve the underwriting referral in Express$")]
    [When(@"^I approve the underwriting referral in Express$")]
    [Then(@"^I approve the underwriting referral in Express$")]
    public async Task ApproveTheUnderwritingReferralInExpressAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (await page.IsLblLoginIDPresentAsync())
        {
                    await page.VerifyLblLoginIDAsync("Visible", "");
        }
        if (await page.IsTxtLoginID1PresentAsync())
        {
                    await page.WaitForTxtLoginID1Async("Exists");
        }
        await page.EnterTxtLoginID1Async(data.Resolve("{{data:txt_login_id_1_585}}"));
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
                    await page.SetChkBoxBypassLevel9RulesAsync(data.Resolve("{{data:chkbox_bypass_level_9_rules_596}}"));
        }
        await page.ClickBypassLevel9Comments1Async();
        await page.EnterBypassLevel9Comments1Async(data.Resolve("{{data:bypass_level_9_comments_1_598}}"));
        await page.ClickLnkHomeAsync();
        if (await page.IsChkBoxBypassLevel9RulesPresentAsync())
        {
                    await page.VerifyChkBoxBypassLevel9RulesAsync("True", "Enabled");
        }
        if (await page.IsChkBoxBypassLevel9RulesPresentAsync())
        {
                    await page.SetChkBoxBypassLevel9RulesAsync(data.Resolve("{{data:chkbox_bypass_level_9_rules_602}}"));
        }
        await page.ClickBypassLevel9Comments1Async();
        await page.EnterBypassLevel9Comments1Async(data.Resolve("{{data:bypass_level_9_comments_1_604}}"));
        await page.ClickLnkHomeAsync();
    }

    [Given(@"^I complete the Level 9 underwriting bypass for txt quote policy search$")]
    [When(@"^I complete the Level 9 underwriting bypass for txt quote policy search$")]
    [Then(@"^I complete the Level 9 underwriting bypass for txt quote policy search$")]
    public async Task CompleteTheLevel9UnderwritingBypassForTxtQuotePolicySearchAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (await page.IsQuotePolicySearchPresentAsync())
        {
                    await page.EnterQuotePolicySearchAsync(data.Resolve("{{data:txt_quote_policy_search_608}}"));
                    await page.PressQuotePolicySearchAsync("CTRL+A");
        }
        await page.EnterQuotePolicySearchAsync(data.Resolve("{{runtime:QuoteNumber}}"));
        await page.ClickNewQuoteSearchAsync();
        if (await page.IsDIVSubmissionPresentAsync())
        {
                    await page.ClickDIVSubmissionAsync();
        }

    }

    [Given(@"^I complete submission underwriting comments and review$")]
    [When(@"^I complete submission underwriting comments and review$")]
    [Then(@"^I complete submission underwriting comments and review$")]
    public async Task CompleteSubmissionUnderwritingCommentsAndReviewAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await page.WaitForSubmissionReadyAsync();
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

    [Given(@"^I open the configured policy application for 15 submission$")]
    [When(@"^I open the configured policy application for 15 submission$")]
    [Then(@"^I open the configured policy application for 15 submission$")]
    public async Task OpenTheConfiguredPolicyApplicationFor15SubmissionAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());
        await this.OpenTheConfiguredPolicyApplicationAsync();
    }

    [Given(@"^I complete the Express underwriting review$")]
    [When(@"^I complete the Express underwriting review$")]
    [Then(@"^I complete the Express underwriting review$")]
    public async Task CompleteTheExpressUnderwritingReviewAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ApproveUnderWriterTextAsync(data.GetRequired("QuoteNumber"), data.Resolve("{{data:txt_underwriting_notes_631}}"));

    }

    [Given(@"^I recall the quote in ExpertQuote$")]
    [When(@"^I recall the quote in ExpertQuote$")]
    [Then(@"^I recall the quote in ExpertQuote$")]
    public async Task RecallTheQuoteInExpertQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (await page.IsQuotePolicySearchPresentAsync())
        {
                    await page.EnterQuotePolicySearchAsync(data.Resolve("{{data:txt_quote_policy_search_636}}"));
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

    }

    [Given(@"^I transmit the policy$")]
    [When(@"^I transmit the policy$")]
    [Then(@"^I transmit the policy$")]
    public async Task TransmitThePolicyAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

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

        await page.WaitForTransmitConfirmationAsync("Exists");
        await page.WaitForGeneratedPolicyNumberAsync();
    }

}
