using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "BAP Expanded")]
public sealed class BAPExpandedSteps
{
    private readonly ScenarioContext _scenario;
    public BAPExpandedSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I start a new quote$")]
    [When(@"^I start a new quote$")]
    [Then(@"^I start a new quote$")]
    public async Task StartANewQuoteAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNewQuoteAsync();
        await page.EnterEffectiveDateAsync(data.Resolve("{{data:effectivedate_94}}"));
        await page.PressEffectiveDateAsync("Tab");
        await Task.Delay(2000);
        await page.EnterProductSequentiallyAsync("Carrier  CommercialAuto  Pages   US   (9.23.0.0)");
        await Task.Delay(1000);
        await page.PressProductAsync("Enter");
        await page.PressProductAsync("Tab");
        await Task.Delay(2000);
        await page.EnterProducerSequentiallyAsync("HERALD BENNETT2");
        await page.PressProducerAsync("Tab");
        await Task.Delay(2000);
        await page.WaitForStartAsync("Visible");
        await page.ClickStartAsync();

    }

    [Given(@"^I enter individual client information$")]
    [When(@"^I enter individual client information$")]
    [Then(@"^I enter individual client information$")]
    public async Task EnterIndividualClientInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("LastName_0040", "^[a-z]{4}$");
        data.GenerateRandom("PrimaryPhone_0041", "[0-9]{10}");
        data.GenerateRandom("InsuredSSN", "125[0-9]{6}");
        data.GenerateRandom("AuditTelephone_0048", "[0-9]{10}");
        data.GenerateRandom("InspectionTelephone_0048", "[0-9]{10}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.SetQuickQuoteAsync(data.Resolve("{{data:quick_quote_1}}"));
        await page.WaitForUnderwritingInfoAsync("Exists");
        await page.EnterInsuredTypeAsync(data.Resolve("{{data:insured_type_3}}"));
        await page.EnterEntityTypeAsync(data.Resolve("{{data:entity_type_13}}"));
        await page.WaitForFirstNameAsync("Visible");
        await page.EnterFirstNameAsync(data.Resolve("{{data:first_name_7}}"));
        await page.EnterMiddleNameAsync(data.Resolve("{{data:middle_name_8}}"));
        await page.EnterLastNameAsync(data.Resolve("{{runtime:LastName_0040}}"));
        await page.EnterDOBAsync(data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        if (data.Condition("State!=\"CA\""))
        {
            await page.EnterGenderAsync(data.Resolve("{{data:gender_11}}"));
        }
        await page.EnterPrimaryPhoneAsync(data.Resolve("{{runtime:PrimaryPhone_0041}}"));
        await page.EnterAddressAsync(data.Resolve("{{data:address1_15}}"));
        await page.EnterNamedInsuredZipCodeAsync(data.Resolve("{{data:zipcode_16}}"));
        await page.PauseAsync(1000);
        await page.ClickClientSearchAsync();
        await page.PauseAsync(2000);
        await page.ClickOKAsync();
        await page.PauseAsync(1000);
        await page.WaitForOrderSSNAsync("Exists");
        await page.ClickOrderSSNAsync();
        await page.WaitForNamedInsuredIndividualEnterSSNAsync("Exists");
        await page.EnterNamedInsuredIndividualEnterSSNAsync(data.Resolve("{{runtime:InsuredSSN}}"));
        data.Set("Last4SSN", data.Get("InsuredSSN").Length >= 4 ? data.Get("InsuredSSN")[^4..] : data.Get("InsuredSSN"));
        await page.PressNamedInsuredIndividualEnterSSNAsync("Doubleclick");
        await page.ClickVerifyAsync();
        await page.WaitForVerifyAsync("Absent");
        await page.WaitForSocialSecurityAsync("Equal");
        await page.VerifySocialSecurityAsync(data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await page.WaitForPleaseVerifySSNAsync("Absent");
        await page.EnterNameOfAuditContactAsync(data.Resolve("{{data:name_of_audit_contact_33}}"));
        await page.EnterAuditTelephoneAsync(data.Resolve("{{runtime:AuditTelephone_0048}}"));
        await page.EnterNameOfInspectionContactAsync(data.Resolve("{{data:name_of_inspection_contact_35}}"));
        await page.EnterInspectionTelephoneAsync(data.Resolve("{{runtime:InspectionTelephone_0048}}"));
        await page.EnterInsuredEMailAddressAsync(data.Resolve("{{data:insured_e_mail_address_37}}"));
        await page.EnterWebsiteAddressAsync(data.Resolve("{{data:website_address_38}}"));


    }

    [Given(@"^I add Third Party Designee$")]
    [When(@"^I add Third Party Designee$")]
    [Then(@"^I add Third Party Designee$")]
    public async Task AddThirdPartyDesigneeAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("AdditionalOtherInterestInputLastName_0055", "^[a-z]{15}$");

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyAddClientAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.WaitForThirdPartyDesigneeAsync("Exists");
        await page.ClickThirdPartyDesigneeAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddThirdPartyAsync();
        await page.WaitForThirdPartyDesigneeFirstNameAsync("Exists");
        await page.EnterThirdPartyDesigneeFirstNameAsync(data.Resolve("{{data:additionalotherinterestinput_firstname_52}}"));
        await page.WaitForThirdPartyDesigneeLastNameAsync("Exists");
        await page.EnterThirdPartyDesigneeLastNameAsync(data.Resolve("{{runtime:AdditionalOtherInterestInputLastName_0055}}"));
        if (await page.IsThirdPartyDesigneeBusinessNameVisibleAsync())
        {
            await page.EnterThirdPartyDesigneeBusinessNameAsync("Sample Business Name");
        }
        await page.EnterThirdPartyDesigneeAddressAsync(data.Resolve("{{data:additionalotherinterestinput_address1_55}}"));
        await page.EnterThirdPartyDesigneeZipCodeAsync(data.Resolve("{{data:zip_code_56}}"));
        await page.ClickOKAsync();
        await page.PauseAsync(2000);

    }

    [Given(@"^I add Additional Named Insured$")]
    [When(@"^I add Additional Named Insured$")]
    [Then(@"^I add Additional Named Insured$")]
    public async Task AddAdditionalNamedInsuredAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("AdditionalInsuredLastName_0062", "^[a-z]{15}$");
        data.GenerateRandom("InsuredSSN", "025[0-9]{6}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyAddClientAsync("Absent", "");
        await page.WaitForAdditionalNamedInsuredAsync("Exists");
        await page.ClickAdditionalNamedInsuredAsync();
        await page.WaitForAdditionalNamedInsuredHeadingAsync("Exists");
        await page.ClickAddNamedInsuredIndividualAsync();
        await page.WaitForAdditionalInsuredFirstNameAsync("Exists");
        await page.EnterAdditionalInsuredFirstNameAsync(data.Resolve("{{runtime:AdditionalInsuredLastName_0062}}"));
        await page.EnterAdditionalInsuredLastNameAsync(data.Resolve("{{data:additional_insured_first_name_65}}"));
        await page.EnterAdditionalInsuredMiddleNameAsync(data.Resolve("{{data:additional_insured_middle_name_66}}"));
        await page.ClickAdditionalInsuredIndividualDetailAsync();
        await page.WaitForAdditionalInsuredIndividualAddressAsync("Exists");
        await page.EnterAdditionalInsuredIndividualAddressAsync(data.Resolve("{{data:address_1_70}}"));
        await page.EnterAdditionalInsuredIndividualZipCodeAsync(data.Resolve("{{data:zip_code_71}}"));
        await page.EnterAdditionalInsuredIndividualDateOfBirthAsync(data.Resolve("{{data:date_of_birth_72}}"));
        await page.PauseAsync(1000);
        await page.ClickClientSearchAsync();
        await page.PauseAsync(1000);
        await page.ClickOKAsync();
        await page.PauseAsync(1000);
        await page.ClickOrderSSNAsync();
        await page.WaitForSSNWasNotReturnedAsync("Exists");
        await page.EnterAddAssociatedClientEnterSSNAsync(data.Resolve("{{runtime:InsuredSSN}}"));
        await page.PressAddAssociatedClientEnterSSNAsync("Tab");
        await page.ClickVerifyAsync();
        await page.WaitForPleaseVerifySSNAsync("Absent");
        await page.ClickOKAsync();
        await page.PauseAsync(2000);
        await page.ClickReturnToClientAsync();
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.PauseAsync(1000);
        await page.WaitForNamedInsuredInformationHeadingAsync("Exists");
        await page.ClickPolicyInfoAsync();
        await page.PauseAsync(2000);
        await page.EnterPolicyInfoRequiredAndOptionalFieldsEffectiveDateAsync(data.Resolve("{{data:effectivedate_94}}"));
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_95}}"));
        await page.PauseAsync(1000);
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_97}}"));
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_101}}"));
        await page.WaitForDescriptionOfSpecifiedOperationAsync("Visible");
        await page.EnterDescriptionOfSpecifiedOperationAsync(data.BuildQuoteDescription());
        data.Set("QuoteDescription", await page.CaptureDescriptionOfSpecifiedOperationAsync("value"));

    }

    [Given(@"^I complete Business Auto policy\-specific fields$")]
    [When(@"^I complete Business Auto policy\-specific fields$")]
    [Then(@"^I complete Business Auto policy\-specific fields$")]
    public async Task CompleteBusinessAutoPolicySpecificFieldsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new DiscountsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyBAPSpecificFieldsOKAsync("Absent", "");
        await page.EnterNAICSCodeSearchValueAsync(data.Resolve("{{data:naics_code_search_value_122}}"));
        await page.PauseAsync(1000);
        await page.EnterNAICSCodeSearchResultsAsync(data.Resolve("{{data:naics_code_search_results_124}}"));
        await page.PauseAsync(1000);
        if (data.Condition("State != \"NY\""))
        {
            await page.EnterAccountCreditAsync(data.Resolve("{{data:account_credit_126}}"));
        }
        await page.PauseAsync(1000);
        await page.WaitForBAPSpecificFieldsOKAsync("Exists");
        await page.ClickBAPSpecificFieldsOKAsync();
        await page.WaitForBAPSpecificFieldsOKAsync("Absent");
        await page.PauseAsync(1000);

    }

    [Given(@"^I run insurance score$")]
    [When(@"^I run insurance score$")]
    [Then(@"^I run insurance score$")]
    public async Task RunInsuranceScoreAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (await page.IsInsuranceScoreVisibleAsync())
        {
            await page.ClickInsuranceScoreAsync();
            await page.PauseAsync(2000);
        }

    }

    [Given(@"^I complete underwriting information from the policy information screen$")]
    [When(@"^I complete underwriting information from the policy information screen$")]
    [Then(@"^I complete underwriting information from the policy information screen$")]
    public async Task CompleteUnderwritingInformationFromThePolicyInformationScreenAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickEnterPriorLossInformationAsync();
        await page.WaitForLossExperienceHeadingAsync("Exists");
        await page.SetNoKnownLossesAsync(data.Resolve("{{data:no_known_losses_144}}"));
        await page.VerifyNoKnownLossesAsync(data.Resolve("{{data:expected_no_known_losses_value_145}}"), "value");
        await page.PauseAsync(1000);
        await page.ClickInsuranceHistoryAsync();
        await page.WaitForIsThereAPriorCarrierAsync("Exists");
        await page.EnterIsThereAPriorCarrierAsync(data.Resolve("{{data:is_there_a_prior_carrier_149}}"));
        await page.EnterCarrierAsync(data.Resolve("{{data:carrier_152}}"));
        await page.EnterPolicyNumberAsync(data.Resolve("{{data:policy_number_153}}"));
        await page.EnterPolicyTypeAsync(data.Resolve("{{data:policy_type_154}}"));
        await page.EnterEffectiveDateAsync(data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await page.EnterExpirationDateAsync(data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await page.EnterModificationFactorAsync(data.Resolve("{{data:modificationfactor_157}}"));
        await page.EnterTotalPremiumAsync(data.Resolve("{{data:total_premium_158}}"));
        await page.ClickOtherInsuranceHistoryOKAsync();
        await page.WaitForDetailAsync("Exists");
        await page.ClickReturnToQuoteAsync();

    }

    [Given(@"^I navigate to policy coverages$")]
    [When(@"^I navigate to policy coverages$")]
    [Then(@"^I navigate to policy coverages$")]
    public async Task NavigateToPolicyCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("State == \"ID\""))
        {
            await page.EnterRiskDefaultsLiabilityLimitAsync("$1,000,000");
            await page.PressRiskDefaultsLiabilityLimitAsync("Tab");
        }

        if (data.Condition("State == \"VA\""))
        {
            await page.EnterRiskDefaultsIncomeLossBenefitsAsync("Yes");
            await page.PressRiskDefaultsIncomeLossBenefitsAsync("Tab");
            await page.EnterRiskDefaultsTowingAsync("$100");
            await page.PressRiskDefaultsTowingAsync("Tab");
        }

        await page.WaitForPolicyCovgerageAsync("Exists");
        await page.ClickPolicyCovgerageAsync();
        await page.PauseAsync(2000);
        await page.EnterTrailerInterchangeCompDeductibleAsync(data.Resolve("{{data:trailer_interchange_comp_deductible_166}}"));
        await page.EnterTrailerInterchangeCollisionDeductibleAsync(data.Resolve("{{data:trailer_interchange_collision_deductible_167}}"));
       await page.WaitForSignsHeadingAsync("Exists");

    }

    [Given(@"^I complete cT StraightThrough Liability Limit to 1M$")]
    [When(@"^I complete cT StraightThrough Liability Limit to 1M$")]
    [Then(@"^I complete cT StraightThrough Liability Limit to 1M$")]
    public async Task CompleteCTStraightThroughLiabilityLimitTo1MAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        if (data.Condition("State == \"CT\""))
        {
            await page.EnterLiabilityLimitAsync("$100,000");
        }

    }

    [Given(@"^I add NonOwnership Liability$")]
    [When(@"^I add NonOwnership Liability$")]
    [Then(@"^I add NonOwnership Liability$")]
    public async Task AddNonOwnershipLiabilityAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.PauseAsync(2000);
        await page.ClickPolicyCovgerageAsync();
        await page.EnterNonOwnedAutoAsync(data.Resolve("{{data:non_owned_auto_172}}"));
        await page.PauseAsync(2000);
        await page.EnterOfEmployeesAsync(data.Resolve("{{data:of_employees_174}}"));
        await page.EnterOfPartnersAsync(data.Resolve("{{data:of_partners_175}}"));
        await page.EnterExtendedEmployeeCoverageAsync(data.Resolve("{{data:extended_employee_coverage_176}}"));
        await page.PauseAsync(1000);

    }

    [Given(@"^I add Business Interruption$")]
    [When(@"^I add Business Interruption$")]
    [Then(@"^I add Business Interruption$")]
    public async Task AddBusinessInterruptionAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());


        await page.PauseAsync(2000);
        await page.ClickPolicyCovgerageAsync();
        await page.EnterBusinessInterruptionEndorsementSequentiallyAsync(data.Resolve("{{data:business_interruption_endorsement_180}}"));
        await page.PressBusinessInterruptionEndorsementAsync("Tab");
        await page.PauseAsync(2000);
        await page.ClickBusinessInterruptionDetailAsync();
        await page.PauseAsync(2000);
        await page.ClickOptionACheckBoxAsync();
        await page.WaitForOptionAScheduleButtonAsync("Exists");
        await page.EnterDescriptionOfBusinessActivitesSequentiallyAsync(data.Resolve("{{data:description_of_business_activites_187}}"));
        await page.PressDescriptionOfBusinessActivitesAsync("Tab");
        await page.ClickOptionAScheduleButtonAsync();
        await page.PauseAsync(2000);
        await page.ClickAddOptionAAsync();
        await page.EnterBusinessInterruptionLimitOfInsuranceSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_business_interruption_limit_of_insurance_192}}"));
        await page.PressBusinessInterruptionLimitOfInsuranceAsync("Tab");
        await page.EnterBusinessInterruptionDescriptionOfScheduledPropertySequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_business_interruption_description_of_scheduledproperty_194}}"));
        await page.PressBusinessInterruptionDescriptionOfScheduledPropertyAsync("Tab");
        await page.PauseAsync(2000);
        await page.ClickOptionAPopupOKAsync();
        await page.PauseAsync(1000);
        await page.ClickOKAsync();
        await page.PauseAsync(2000);

    }

    [Given(@"^I complete required location information$")]
    [When(@"^I complete required location information$")]
    [Then(@"^I complete required location information$")]
    public async Task CompleteRequiredLocationInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForWCNavigationLinksLocationAsync("Exists");
        await page.ClickWCNavigationLinksLocationAsync();

    }

    [Given(@"^I add UM/UIM Coverage$")]
    [When(@"^I add UM/UIM Coverage$")]
    [Then(@"^I add UM/UIM Coverage$")]
    public async Task AddUMUIMCoverageAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickStateDetailsAsync();
        await page.WaitForSelectAsync("Exists");
        await page.ClickSelectAsync();
        await page.WaitForOKAsync("Visible");
        await page.WaitForSignsHeadingAsync("Exists");
        if (data.Condition("'UM Type Default' != NULL"))
        {
            await page.EnterUMTypeDefaultSelectionsAsync(data.Resolve("{{data:um_type_default_selections_211}}"));
        }
        if (data.Condition("'UMBI Limit' != NULL AND 'UM Type Default' != \"UMBIPD CSL\""))
        {
            await page.EnterUMBILimitAsync(data.Resolve("{{data:umbi_limit_212}}"));
        }
        if (await page.IsUIMCSLLimitVisibleAsync())
        {
            await page.EnterUIMCSLLimitAsync(data.Resolve("{{data:umbi_limit_212}}"));
        }
        if (data.Condition("State == \"MD\"") && await page.IsPIPWaiverVisibleAsync())
        {
            await page.EnterPIPWaiverAsync("Yes");
            await page.PressPIPWaiverAsync("Tab");
            if (await page.IsPIPLimitVisibleAsync())
            {
                await page.EnterPIPLimitAsync("10000");
                await page.PressPIPLimitAsync("Tab");
            }
        }
        if (data.Condition("State == \"PA\""))
        {
            if (await page.IsPIPAdditionalCombinationLimitVisibleAsync())
            {
                await page.EnterPIPAdditionalCombinationLimitAsync("50,000/2,500/10,000");
                await page.PressPIPAdditionalCombinationLimitAsync("Tab");
            }
            if (await page.IsPIPExtraordinaryMedicalLimitVisibleAsync())
            {
                await page.EnterPIPExtraordinaryMedicalLimitAsync("1000000");
                await page.PressPIPExtraordinaryMedicalLimitAsync("Tab");
            }
        }
        if (await page.IsUMPDLimitVisibleAsync())
        {
            var umpdLimitValue = data.Condition("State == \"RI\"") ? "25000" : "100000";
            await page.EnterUMPDLimitAsync(umpdLimitValue);
            await page.PressUMPDLimitAsync("Tab");
        }
        if (await page.IsPIPAdditionalLimitVisibleAsync())
        {
            string? pipAdditionalLimitValue = null;
            if (data.Condition("State == \"DE\""))
            {
                pipAdditionalLimitValue = "70000";
            }
            else if (data.Condition("State == \"KY\" OR State == \"MN\" OR State == \"ND\""))
            {
                pipAdditionalLimitValue = "Option 1";
            }
            else if (data.Condition("State == \"KS\""))
            {
                pipAdditionalLimitValue = "Option 2";
            }
            else if (data.Condition("State == \"NY\""))
            {
                pipAdditionalLimitValue = "Option A";
            }

            if (pipAdditionalLimitValue != null)
            {
                await page.EnterPIPAdditionalLimitAsync(pipAdditionalLimitValue);
                await page.PressPIPAdditionalLimitAsync("Tab");
            }
        }
        if (await page.IsPIPDeductibleVisibleAsync())
        {
            string? pipDeductibleValue = null;
            if (data.Condition("State == \"DE\" OR State == \"NJ\" OR State == \"OR\""))
            {
                pipDeductibleValue = "250";
            }
            else if (data.Condition("State == \"KY\""))
            {
                pipDeductibleValue = "500";
            }
            else if (data.Condition("State == \"MN\""))
            {
                pipDeductibleValue = "Combined";
            }
            else if (data.Condition("State == \"NY\""))
            {
                pipDeductibleValue = "100";
            }

            if (pipDeductibleValue != null)
            {
                await page.EnterPIPDeductibleAsync(pipDeductibleValue);
                await page.PressPIPDeductibleAsync("Tab");
            }
        }
        if (await page.IsPIPAdditionalAccidentalDeathLimitVisibleAsync())
        {
            await page.EnterPIPAdditionalAccidentalDeathLimitAsync("3000");
            await page.PressPIPAdditionalAccidentalDeathLimitAsync("Tab");
        }
        if (data.Condition("State == \"KS\" OR State == \"KY\" OR State == \"ND\" OR State == \"NY\" OR State == \"OR\" OR State == \"PA\"") && await page.IsBroadenedPIPVisibleAsync())
        {
            await page.EnterBroadenedPIPAsync("Yes");
            await page.PressBroadenedPIPAsync("Tab");
            if (await page.IsBroadenedPIPFirstNameVisibleAsync())
            {
                await page.EnterBroadenedPIPFirstNameAsync("JACOB");
            }
            if (await page.IsBroadenedPIPLastNameVisibleAsync())
            {
                await page.EnterBroadenedPIPLastNameAsync("JONES");
            }
        }
        await page.VerifyOKAsync("Exists", "");
        await page.PauseAsync(1000);
        await page.ClickOKAsync();

    }

    [Given(@"^I add Policy Level Coverages$")]
    [When(@"^I add Policy Level Coverages$")]
    [Then(@"^I add Policy Level Coverages$")]
    public async Task AddPolicyLevelCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickStateDetailsAsync();
        await page.WaitForSelectAsync("Exists");
        await page.ClickSelectAsync();
        await page.WaitForSelectAsync("Absent");
        await page.WaitForOKAsync("Visible");
        
        if (!data.Condition("State == \"CA\""))
        {
            await page.ClickHiredAutoLiabilityAsync();
            await page.ClickPrimaryLiabilityIfAnyAsync();
            await page.ClickExcessLiabilityIfAnyAsync();
            await page.ClickEmployeeHiredAutosCheckBoxAsync();
            await page.ClickVolunteerHiredAutosCheckBoxAsync();
        }

        if (data.Condition("State == \"CA\""))
        {
            await page.ClickHiredAutoLiabilityAsync();
            await page.ClickEmployeeHiredAutosCheckBoxAsync();
            await page.ClickVolunteerHiredAutosCheckBoxAsync();

            if (await page.IsCostOfHirePrimaryVisibleAsync())
            {
                await page.EnterCostOfHirePrimaryAsync("250");
            }
            if (await page.IsCostOfHireExcessVisibleAsync())
            {
                await page.EnterCostOfHireExcessAsync("500");
            }
        }

        await page.PauseAsync(1000);
        await page.ClickDriveOtherCarAsync();
        await page.ClickComprehensiveAsync();
        await page.WaitForStateDetailsDriveOtherCarOTCDeductibleAsync("Exists");
        await page.ClickCollisionAsync();
        await page.WaitForCollisionDeductibleAsync("Exists");
        await page.EnterStateDetailsDriveOtherCarLastNameAsync(data.Resolve("{{data:last_name_236}}"));
        await page.EnterStateDetailsDriveOtherCarFirstNameAsync(data.Resolve("{{data:first_name_237}}"));
        await page.PauseAsync(1000);
        await page.ClickHiredAutoPhysicalDamageWithoutDriverAsync();
        if (data.Condition("State == \"CA\""))
        {
            await page.EnterStateDetailsHiredAutoPDWithoutDriverOTCDeductibleAsync("50");
            await page.EnterHiredAutoCollisionDeductibleAsync("$500");
            if (await page.IsCostOfHirePhysicalDamageVisibleAsync())
            {
                await page.EnterCostOfHirePhysicalDamageAsync("$500");
            }
        }
        else
        {
            await page.EnterStateDetailsHiredAutoPDWithoutDriverOTCDeductibleAsync(data.Resolve("{{data:otc_deductible_240}}"));
            await page.ClickStateDetailsHiredAutoPDWithoutDriverIfAnyFieldAsync();
            await page.EnterHiredAutoCollisionDeductibleAsync(data.Resolve("{{data:collision_deductible_242}}"));
            await page.ClickStateDetailsHiredAutoPDWithoutDriverIfAnyAsync();
        }
     
        await page.PauseAsync(1000);
        await page.ClickHiredAutoPhysicalDamageWithDriverAsync();
        if (data.Condition("State == \"CA\""))
        {
            await page.EnterStateDetailsHiredAutoPhysicalDamageWithDriverOTCDeductibleAsync("$50");
            await page.EnterHiredAutoCollisionDeductibleWithDriverAsync("$100");
            if (await page.IsCostOfHireWithDriverVisibleAsync())
            {
                await page.EnterCostOfHireWithDriverAsync("$1000");
            }
        }
        else
        {
            await page.EnterStateDetailsHiredAutoPhysicalDamageWithDriverOTCDeductibleAsync(data.Resolve("{{data:otc_deductible_246}}"));
            await page.ClickStateDetailsHiredAutoPhysicalDamageWithDriverIfAnyFieldAsync();
            await page.ClickStateDetailsHiredAutoPhysicalDamageWithDriverIfAnyAsync();
            await page.EnterHiredAutoCollisionDeductibleWithDriverAsync(data.Resolve("{{data:collision_deductible_248}}"));
        }
        await page.EnterVehicleInformationAsync(data.Resolve("{{data:vehicle_information_250}}"));
        await page.PauseAsync(1000);
        await page.ClickOKAsync();
        await page.WaitForSelectAsync("Visible");

    }

    [Given(@"^I add a Risk$")]
    [When(@"^I add a Risk$")]
    [Then(@"^I add a Risk$")]
    public async Task AddARiskAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.PauseAsync(1000);
        //1.Private Passenger
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_264}}"));
        await page.WaitForVehicleTypeAsync("Exists");
        await page.ClickAddRiskAtThisLocationAsync();
        if (data.Condition("VIN != NULL"))
        {
            await page.WaitForVINAsync("Visible");
        }
        if (data.Condition("Year != NULL"))
        {
            await page.EnterYearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
            await page.EnterMakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
            await page.EnterModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterVINAsync(data.Resolve("{{data:vin_275}}"));
        }
        if (data.Condition("Snowplow != NULL") && await page.IsThisVehicleUsedInSnowPlowOperationsVisibleAsync())
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_278}}"));
        }
        if (await page.IsCollisionCoverageVisibleAsync())
        {
            await page.EnterCollisionCoverageAsync("Yes");
        }

        if (await page.IsAutoLoanCoverageVisibleAsync())
        {
            await page.EnterAutoLoanCoverageAsync("Yes");
            await page.PressAutoLoanCoverageAsync("Tab");
        }
        await page.ClickOKAsync();
        await page.PauseAsync(1000);
        await page.WaitForRiskPageVisibleAsync();

        await page.PauseAsync(1000);
        //2.Truck

        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_300}}"));

        await page.ClickAddRiskAtThisLocationAsync();

        if (data.Condition("VIN != NULL"))
        {
            await page.WaitForVINAsync("Visible");
        }
        if (data.Condition("Year != NULL"))
        {
            await page.EnterYearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
            await page.EnterMakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
            await page.EnterModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterVINAsync(data.Resolve("{{data:vin_309}}"));
        }

        if (data.Condition("Snowplow != NULL") && await page.IsThisVehicleUsedInSnowPlowOperationsVisibleAsync())
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_312}}"));
        }

        if (data.Condition("'OTC Causes of Loss' != NULL") && await page.IsOTCCausesOfLossVisibleAsync())
        {
            await page.EnterOTCCausesOfLossAsync(data.Resolve("{{data:otc_causes_of_loss_316}}"));
        }
        await page.VerifyCollisionCoverageAsync("Exists", "");
        if (await page.IsCollisionCoverageVisibleAsync())
        {
            await page.EnterCollisionCoverageAsync("Yes");
        }

        await page.ClickOKAsync();
        await page.PauseAsync(1000);
        await page.WaitForRiskPageVisibleAsync();
        //3. Truck Tractor

        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_335}}"));

        await page.ClickAddRiskAtThisLocationAsync();

        if (data.Condition("VIN != NULL"))
        {
            await page.WaitForVINAsync("Visible");
        }
        if (data.Condition("Year != NULL"))
        {
            await page.EnterYearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
            await page.EnterMakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
            await page.EnterModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterVINAsync(data.Resolve("{{data:vin_344}}"));
        }

        if (data.Condition("Snowplow != NULL") && await page.IsThisVehicleUsedInSnowPlowOperationsVisibleAsync())
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_347}}"));
        }
        if (data.Condition("GCW != NULL") && await page.IsGCWVisibleAsync())
        {
            await page.EnterGCWAsync(data.Resolve("{{data:gcw_349}}"));
        }

        if (await page.IsCollisionCoverageVisibleAsync())
        {
            await page.EnterCollisionCoverageAsync("Yes");
        }

        await page.ClickOKAsync();
        await page.PauseAsync(1000);
        await page.WaitForRiskPageVisibleAsync();

        //4. Semitrailer

        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_369}}"));

        await page.ClickAddRiskAtThisLocationAsync();

        if (data.Condition("VIN != NULL"))
        {
            await page.WaitForVINAsync("Visible");
        }
        if (data.Condition("Year != NULL"))
        {
            await page.EnterYearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
            await page.EnterMakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
            await page.EnterModelAsync("");
        }
        if (data.Condition("'Value Basis' != NULL") && await page.IsValueBasisVisibleAsync())
        {
            await page.EnterValueBasisAsync(data.Resolve("{{data:value_basis_377}}"));
        }
        if (data.Condition("'Original Cost New' != NULL") && await page.IsOriginalCostNewVisibleAsync())
        {
            await page.EnterOriginalCostNewAsync(data.Resolve("{{data:original_cost_new_378}}"));
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterVINAsync(data.Resolve("{{data:vin_380}}"));
        }
        if (await page.IsVehicleValueEstimateVisibleAsync())
        {
            await page.EnterVehicleValueEstimateAsync("100000");
        }

        if (data.Condition("Snowplow != NULL") && await page.IsThisVehicleUsedInSnowPlowOperationsVisibleAsync())
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_383}}"));
        }
        if (data.Condition("'Used as Showroom' != NULL") && await page.IsUsedAsShowroomVisibleAsync())
        {
            await page.EnterUsedAsShowroomAsync(data.Resolve("{{data:used_as_showroom_385}}"));
        }

        if (data.Condition("'2nd Class Category' != NULL") && await page.IsN2ndClassCategoryVisibleAsync())
        {
            await page.EnterN2ndClassCategoryAsync(data.Resolve("{{data:2nd_class_category_389}}"));
        }
        if (data.Condition("'2nd Class Code' != NULL") && await page.IsN2ndClassCodeVisibleAsync())
        {
            await page.EnterN2ndClassCodeAsync(data.Resolve("{{data:2nd_class_code_390}}"));
        }
        if (await page.IsCollisionCoverageVisibleAsync())
        {
            await page.EnterCollisionCoverageAsync("Yes");
        }

        await page.ClickOKAsync();
        await page.PauseAsync(1000);
        await page.WaitForRiskPageVisibleAsync();

        //5. Funeral Directors 
        if (data.Condition("State != \"AL\" AND State != \"AZ\" AND State != \"LA\" AND State != \"MO\" AND State != \"MT\" AND State != \"NV\" AND State != \"PA\" AND State != \"SD\" AND State != \"TX\" AND State != \"VA\""))
        {
            await page.EnterVehicleTypeAsync("Funeral Directors");

            await page.ClickAddRiskAtThisLocationAsync();

            if (data.Condition("VIN != NULL"))
            {
                await page.WaitForVINAsync("Visible");
            }
            if (data.Condition("Year != NULL"))
            {
                await page.EnterYearAsync("");
            }
            if (data.Condition("Make != NULL"))
            {
                await page.EnterMakeAsync("");
            }
            if (data.Condition("Model != NULL"))
            {
                await page.EnterModelAsync("");
            }
            if (data.Condition("VIN != NULL"))
            {
                await page.EnterVINAsync("SCAZV19C2WCH98143");
            }
            if (data.Condition("'Value Basis' != NULL") && await page.IsValueBasisVisibleAsync())
            {
                await page.EnterValueBasisAsync("ACV");
            }
            if (data.Condition("'Original Cost New' != NULL") && await page.IsOriginalCostNewVisibleAsync())
            {
                await page.EnterOriginalCostNewAsync("100,000");
            }
            if (await page.IsCollisionCoverageVisibleAsync())
            {
                await page.EnterCollisionCoverageAsync("Yes");
            }

            await page.ClickOKAsync();
            await page.PauseAsync(1000);
        }

        //6. Garagekeepers
        if (data.Condition("State != \"AL\" AND State != \"AZ\" AND State != \"LA\" AND State != \"MO\" AND State != \"MT\" AND State != \"NV\" AND State != \"PA\" AND State != \"SD\" AND State != \"TX\""))
        {
            await page.EnterVehicleTypeAsync("Garagekeepers");

            await page.ClickAddRiskAtThisLocationAsync();

            await page.ClickOKAsync();
            await page.PauseAsync(1000);

            await page.WaitForRiskPageVisibleAsync();
        }

        //7. Golf Carts/Low Speed Vehicles
        if (data.Condition("State != \"LA\" AND State != \"MO\" AND State != \"MT\" AND State != \"PA\" AND State != \"SD\" AND State != \"TX\" AND State != \"VA\""))
        {
            await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_409}}"));

            await page.ClickAddRiskAtThisLocationAsync();

            if (data.Condition("VIN != NULL"))
            {
                await page.WaitForVINAsync("Visible");
            }
            if (data.Condition("VIN != NULL"))
            {
                await page.EnterVINAsync(data.Resolve("{{data:vin_420}}"));
            }
            if (data.Condition("Year != NULL"))
            {
                await page.EnterYearAsync(data.Resolve("{{data:year_414}}"));
            }
            if (data.Condition("Make != NULL"))
            {
                await page.EnterMakeAsync(data.Resolve("{{data:make_415}}"));
            }
            if (data.Condition("Model != NULL"))
            {
                await page.EnterModelAsync(data.Resolve("{{data:model_416}}"));
            }
            if (data.Condition("'Body Style' != NULL") && await page.IsBodyStyleVisibleAsync())
            {
                await page.EnterBodyStyleAsync(data.Resolve("{{data:body_style_417}}"));
            }
            if (data.Condition("'Stated Amount' != NULL") && await page.IsStatedAmountVisibleAsync())
            {
                await page.EnterStatedAmountAsync(data.Resolve("{{data:stated_amount_418}}"));
            }

            if (data.Condition("Snowplow != NULL") && await page.IsThisVehicleUsedInSnowPlowOperationsVisibleAsync())
            {
                await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_423}}"));
            }
            if (data.Condition("'Engine Size' != NULL") && await page.IsEngineSizeCcVisibleAsync())
            {
                await page.EnterEngineSizeCcAsync(data.Resolve("{{data:engine_size_cc_425}}"));
            }

            if (await page.IsCollisionCoverageVisibleAsync())
            {
                await page.EnterCollisionCoverageAsync("Yes");
            }

            await page.ClickOKAsync();
            await page.PauseAsync(1000);
            await page.WaitForRiskPageVisibleAsync();
        }

        //8. Mobile Home
        if (data.Condition("State != \"PA\" AND State != \"TX\""))
        {
            await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_447}}"));

            await page.ClickAddRiskAtThisLocationAsync();
            await page.WaitForSignsHeadingAsync("Exists");
            if (data.Condition("VIN != NULL"))
            {
                await page.WaitForVINAsync("Visible");
            }
            if (data.Condition("VIN != NULL"))
            {
                await page.EnterVINAsync(data.Resolve("{{data:vin_458}}"));
            }
            if (data.Condition("Year != NULL"))
            {
                await page.EnterYearAsync(data.Resolve("{{data:year_452}}"));
            }
            if (data.Condition("Make != NULL"))
            {
                await page.EnterMakeAsync(data.Resolve("{{data:make_453}}"));
            }
            if (data.Condition("Model != NULL"))
            {
                await page.EnterModelAsync(data.Resolve("{{data:model_454}}"));
            }
            if (data.Condition("'Body Style' != NULL") && await page.IsBodyStyleVisibleAsync())
            {
                await page.EnterBodyStyleAsync(data.Resolve("{{data:body_style_455}}"));
            }
            if (data.Condition("'Stated Amount' != NULL") && await page.IsStatedAmountVisibleAsync())
            {
                await page.EnterStatedAmountAsync(data.Resolve("{{data:stated_amount_456}}"));
            }


            if (data.Condition("Snowplow != NULL") && await page.IsThisVehicleUsedInSnowPlowOperationsVisibleAsync())
            {
                await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_461}}"));
            }

            if (await page.IsCollisionCoverageVisibleAsync())
            {
                await page.EnterCollisionCoverageAsync("Yes");
            }

            await page.ClickOKAsync();
            await page.WaitForRiskPageVisibleAsync();
        }

        //9. Mobile Home ContentsOTC
        if (data.Condition("State != \"AL\" AND State != \"AZ\" AND State != \"LA\" AND State != \"MO\" AND State != \"MT\" AND State != \"NV\" AND State != \"PA\" AND State != \"SD\" AND State != \"VA\""))
        {
            await page.EnterVehicleTypeAsync("Mobile Home Contents");
            await page.ClickAddRiskAtThisLocationAsync();

            await page.PauseAsync(1000);

            if (data.Condition("VIN != NULL"))
            {
                await page.WaitForVINAsync("Visible");
            }
            if (data.Condition("VIN != NULL"))
            {
                await page.EnterVINAsync("ContentsVIN1234");
            }
            if (data.Condition("Year != NULL"))
            {
                await page.EnterYearAsync("1979");
            }
            if (data.Condition("Make != NULL"))
            {
                await page.EnterMakeAsync("Make");
            }
            if (data.Condition("Model != NULL"))
            {
                await page.EnterModelAsync("Model");
            }
            if (data.Condition("'Body Style' != NULL") && await page.IsBodyStyleVisibleAsync())
            {
                await page.EnterBodyStyleAsync("Body Style");
            }
            if (data.Condition("'Stated Amount' != NULL") && await page.IsStatedAmountVisibleAsync())
            {
                await page.EnterStatedAmountAsync("100000");
            }

            if (data.Condition("'OTC Causes of Loss' != NULL") && await page.IsOTCCausesOfLossVisibleAsync())
            {
                await page.EnterOTCCausesOfLossAsync("Fire & Theft");
            }

            await page.ClickOKAsync();
            await page.WaitForRiskPageVisibleAsync();
        }

        //10. Mobile/Farm Equipment
        if (data.Condition("State != \"AL\" AND State != \"AZ\" AND State != \"LA\" AND State != \"MO\" AND State != \"MT\" AND State != \"NV\" AND State != \"PA\" AND State != \"SD\" AND State != \"TX\" AND State != \"VA\""))
        {
            await page.EnterVehicleTypeAsync("Mobile/Farm Equipment");
            await page.ClickAddRiskAtThisLocationAsync();

            await page.PauseAsync(1000);

            if (data.Condition("VIN != NULL"))
            {
                await page.WaitForVINAsync("Visible");
            }
            if (data.Condition("VIN != NULL"))
            {
                await page.EnterVINAsync("MobileFarmVIN1234");
            }
            if (data.Condition("Year != NULL"))
            {
                await page.EnterYearAsync("1979");
            }
            if (data.Condition("Make != NULL"))
            {
                await page.EnterMakeAsync("Make");
            }
            if (data.Condition("Model != NULL"))
            {
                await page.EnterModelAsync("Model");
            }
            if (data.Condition("'Body Style' != NULL") && await page.IsBodyStyleVisibleAsync())
            {
                await page.EnterBodyStyleAsync("Body Style");
            }
            if (data.Condition("'Stated Amount' != NULL") && await page.IsStatedAmountVisibleAsync())
            {
                await page.EnterStatedAmountAsync("100000");
            }
            await page.WaitForSpecialOrMobileEquipmentGroupTypeAsync("Visible");
            await page.EnterSpecialOrMobileEquipmentGroupTypeAsync("Farm Equip");

            await page.ClickOKAsync();
            await page.WaitForRiskPageVisibleAsync();
        }

        //11.Public Vehicle
        if (data.Condition("State != \"AL\" AND State != \"AZ\" AND State != \"LA\" AND State != \"MO\" AND State != \"MT\" AND State != \"NV\" AND State != \"PA\" AND State != \"SD\" AND State != \"TX\" AND State != \"VA\""))
        {
            await page.EnterVehicleTypeAsync("Public Vehicle");
            await page.ClickAddRiskAtThisLocationAsync();

            await page.PauseAsync(1000);

            if (data.Condition("VIN != NULL"))
            {
                await page.WaitForVINAsync("Visible");
            }
            if (data.Condition("VIN != NULL"))
            {
                await page.EnterVINAsync("PublicVIN1234");
            }
            if (data.Condition("Year != NULL"))
            {
                await page.EnterYearAsync("1979");
            }
            if (data.Condition("Make != NULL"))
            {
                await page.EnterMakeAsync("Make");
            }
            if (data.Condition("Model != NULL"))
            {
                await page.EnterModelAsync("Model");
            }
            if (data.Condition("'Body Style' != NULL") && await page.IsBodyStyleVisibleAsync())
            {
                await page.EnterBodyStyleAsync("Body Style");
            }
            if (data.Condition("'Original Cost New' != NULL") && await page.IsOriginalCostNewVisibleAsync())
            {
                await page.EnterOriginalCostNewAsync(data.Resolve("{{data:original_cost_new_378}}"));
            }
            await page.WaitForPublicGroupTypeAsync("Visible");
            await page.EnterPublicGroupTypeAsync("Van Pools");
            await page.WaitForPublicTypeAsync("Visible");
            await page.EnterPublicTypeAsync("Employer Furnished");

            await page.ClickOKAsync();
            await page.WaitForRiskPageVisibleAsync();
        }

        //12. Registration Plates
        if (data.Condition("State != \"AL\" AND State != \"AZ\" AND State != \"LA\" AND State != \"MO\" AND State != \"MT\" AND State != \"NV\" AND State != \"PA\" AND State != \"SD\" AND State != \"TX\""))
        {
            await page.EnterVehicleTypeAsync("Registration Plates");
            await page.ClickAddRiskAtThisLocationAsync();
            await page.PauseAsync(2000);

            await page.ClickOKAsync();
            await page.WaitForRiskPageVisibleAsync();
        }

        //13. Snowmobile
        if (data.Condition("State != \"AL\" AND State != \"AZ\" AND State != \"LA\" AND State != \"MO\" AND State != \"MT\" AND State != \"NV\" AND State != \"PA\" AND State != \"SD\" AND State != \"TX\""))
        {
            await page.EnterVehicleTypeAsync("Snowmobile");
            await page.ClickAddRiskAtThisLocationAsync();

            if (data.Condition("VIN != NULL"))
            {
                await page.WaitForVINAsync("Visible");
            }
            if (data.Condition("VIN != NULL"))
            {
                await page.EnterVINAsync("2BPS226713V001095");
            }
            if (data.Condition("Year != NULL"))
            {
                await page.EnterYearAsync("1979");
            }
            if (data.Condition("Make != NULL"))
            {
                await page.EnterMakeAsync("Make");
            }
            if (data.Condition("Model != NULL"))
            {
                await page.EnterModelAsync("Model");
            }
            if (data.Condition("'Body Style' != NULL") && await page.IsBodyStyleVisibleAsync())
            {
                await page.EnterBodyStyleAsync("Body Style");
            }
            if (data.Condition("'Stated Amount' != NULL") && await page.IsStatedAmountVisibleAsync())
            {
                await page.EnterStatedAmountAsync("100000");
            }

            await page.ClickOKAsync();
            await page.WaitForRiskPageVisibleAsync();
        }

        //14. Suspended Vehicle
        if (data.Condition("State != \"AL\" AND State != \"AZ\" AND State != \"LA\" AND State != \"MO\" AND State != \"MT\" AND State != \"NV\" AND State != \"PA\" AND State != \"SD\" AND State != \"TX\" AND State != \"VA\""))
        {
            await page.EnterVehicleTypeAsync("Truck");
            await page.ClickAddRiskAtThisLocationAsync();

            if (data.Condition("VIN != NULL"))
            {
                await page.WaitForVINAsync("Visible");
            }
            if (data.Condition("VIN != NULL"))
            {
                await page.EnterVINAsync("5TFTX4GN7EX032539");
            }

            if (data.Condition("Snowplow != NULL") && await page.IsThisVehicleUsedInSnowPlowOperationsVisibleAsync())
            {
                await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_278}}"));
            }
            await page.WaitForAcceptLiabilityCoverageAsync("Visible");
            await page.EnterAcceptLiabilityCoverageAsync("No");

            await page.ClickOKAsync();
            await page.WaitForRiskPageVisibleAsync();
        }

        //15. Mobile Home ContentsOTC
        if (data.Condition("State != \"AL\" AND State != \"AZ\" AND State != \"LA\" AND State != \"MO\" AND State != \"MT\" AND State != \"NV\" AND State != \"PA\" AND State != \"SD\" AND State != \"VA\""))
        {
            await page.EnterVehicleTypeAsync("Mobile Home Contents");
            await page.ClickAddRiskAtThisLocationAsync();

            if (data.Condition("VIN != NULL"))
            {
                await page.WaitForVINAsync("Visible");
            }
            if (data.Condition("VIN != NULL"))
            {
                await page.EnterVINAsync("ContentsVIN1234");
            }
            if (data.Condition("Year != NULL"))
            {
                await page.EnterYearAsync("1979");
            }
            if (data.Condition("Make != NULL"))
            {
                await page.EnterMakeAsync("Make");
            }
            if (data.Condition("Model != NULL"))
            {
                await page.EnterModelAsync("Model");
            }
            if (data.Condition("'Body Style' != NULL") && await page.IsBodyStyleVisibleAsync())
            {
                await page.EnterBodyStyleAsync("Body Style");
            }
            if (data.Condition("'Original Cost New' != NULL") && await page.IsOriginalCostNewVisibleAsync())
            {
                await page.EnterOriginalCostNewAsync(data.Resolve("{{data:original_cost_new_378}}"));
            }

            if (data.Condition("'OTC Causes of Loss' != NULL") && await page.IsOTCCausesOfLossVisibleAsync())
            {
                await page.EnterOTCCausesOfLossAsync("Fire & Theft");
            }
            await page.ClickOKAsync();
            await page.WaitForRiskPageVisibleAsync();
        }

    }

    [Given(@"^I add Risk Level Interest$")]
    [When(@"^I add Risk Level Interest$")]
    [Then(@"^I add Risk Level Interest$")]
    public async Task AddRiskLevelInterestAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickRiskScheduleAsync();
  
        await page.WaitForRiskSchedulePageTitleAsync("Exists");
        await page.ClickPrivatePassengerVehicleDetailAsync();
    
        await page.EnterHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:hired_auto_ext_addl_insured_480}}"));
       
        await page.WaitForHiredAutoOKAsync("Exists");
        await page.EnterHiredAutoOKAsync(data.Resolve("{{data:hired_auto_form_483}}"));
        await page.PressHiredAutoOKAsync("Tab");

        await page.ClickOKAsync();
        await page.WaitForRiskSchedulePageTitleAsync("Exists");
 
        await page.ClickRiskScheduleAsync();
    
        await page.ClickTruckVehicleDetailAsync();

        await page.EnterHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:hired_auto_ext_addl_insured_494}}"));
       

        await page.EnterHiredAutoOKAsync(data.Resolve("{{data:hired_auto_form_497}}"));
        await page.PressHiredAutoOKAsync("Tab");
        
        await page.ClickOKAsync();
        await page.WaitForRiskSchedulePageTitleAsync("Exists");
   
        await page.ClickRiskScheduleAsync();

        await page.ClickTruckTractorVehicleDetailAsync();
   
        await page.EnterHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:hired_auto_ext_addl_insured_508}}"));
    
        await page.EnterHiredAutoOKAsync(data.Resolve("{{data:hired_auto_form_511}}"));
        await page.PressHiredAutoOKAsync("Tab");
 
        if (data.Condition("'Last Name' != NULL"))
        {
            await page.EnterHiredAutoCA2001LastNameAsync(data.Resolve("{{data:hiredauto_ca2001_last_name_514}}"));
        }
        if (data.Condition("'Zip Code' != NULL"))
        {
            await page.EnterHiredAutoCA2001ZipCodeAsync(data.Resolve("{{data:hiredauto_ca2001_zipcode_516}}"));
        }
        if (data.Condition("'First Name' != NULL"))
        {
            await page.ClickHiredAutoOKAsync();
        }
        if (data.Condition("'First Name' != NULL"))
        {
            await page.EnterHiredAutoCA2001FirstNameAsync(data.Resolve("{{data:hiredauto_ca2001_first_name_518}}"));
        }
        if (data.Condition("'Address 1' != NULL"))
        {
            await page.EnterHiredAutoCA2001AddressAsync(data.Resolve("{{data:hiredauto_ca2001_address1_519}}"));
            await page.PauseAsync(2000);
            await page.ClickHiredAutoCA2001OKAsync();
        }
        await page.ClickOKAsync();
        await page.WaitForRiskSchedulePageTitleAsync("Exists");

    }

    [Given(@"^I verify Risk Level Coverages$")]
    [When(@"^I verify Risk Level Coverages$")]
    [Then(@"^I verify Risk Level Coverages$")]
    public async Task VerifyRiskLevelCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForRiskSchedulePageTitleAsync("Exists");
        await page.ClickPrivatePassengerVehicleDetailAsync();
        if (data.Condition("'Accept UM' != NULL"))
        {
            await page.VerifyAcceptUMAsync("Yes", "InnerText");
        }
        await page.ClickOKAsync();
        await page.WaitForRiskPageVisibleAsync();
        await page.PauseAsync(1000);

    }

    [Given(@"^I add Risk Level Coverages$")]
    [When(@"^I add Risk Level Coverages$")]
    [Then(@"^I add Risk Level Coverages$")]
    public async Task AddRiskLevelCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

      
        await page.WaitForRiskSchedulePageTitleAsync("Exists");
        await page.ClickPrivatePassengerVehicleDetailAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        if (await page.IsLoanLeaseGapVisibleAsync())
        {
            await page.EnterLoanLeaseGapAsync(data.Resolve("{{data:loan_lease_gap_551}}"));
        }
        if (await page.IsTapesCoverageVisibleAsync())
        {
            await page.EnterTapesCoverageAsync(data.Resolve("{{data:tapes_coverage_537}}"));
        }
        if (await page.IsAudioVisualVisibleAsync())
        {
            await page.EnterAudioVisualAsync(data.Resolve("{{data:audio_visual_538}}"));
            await page.PressAudioVisualAsync("Tab");
        }
        if (await page.IsAudioVisualVisibleAsync())
        {
            for (var attempt = 0; attempt < 3 && !await page.IsAVCostNewVisibleAsync(); attempt++)
            {
                await page.EnterAudioVisualAsync(data.Resolve("{{data:audio_visual_538}}"));
                await page.PressAudioVisualAsync("Tab");
                await page.PauseAsync(500);
            }
            await page.EnterAVCostNewAsync(data.Resolve("{{data:av_cost_new_539}}"));
            await page.PressAVCostNewAsync("Tab");
        }
        if (await page.IsTowingVisibleAsync())
        {
            await page.EnterTowingAsync("50");
            await page.PressTowingAsync("Tab");
        }
        if (await page.IsVehicleRentalReimbursementVisibleAsync())
        {
            await page.EnterVehicleRentalReimbursementAsync("Yes");
            await page.PressVehicleRentalReimbursementAsync("Tab");
        }

        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForRiskPageVisibleAsync();
        await page.PauseAsync(1000);
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickTruckVehicleDetailAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        if (await page.IsLoanLeaseGapVisibleAsync())
        {
            await page.EnterLoanLeaseGapAsync(data.Resolve("{{data:loan_lease_gap_551}}"));
        }
        if (await page.IsTapesCoverageVisibleAsync())
        {
            await page.EnterTapesCoverageAsync(data.Resolve("{{data:tapes_coverage_552}}"));
        }
        if (await page.IsAudioVisualVisibleAsync())
        {
            await page.EnterAudioVisualAsync(data.Resolve("{{data:audio_visual_553}}"));
            await page.PressAudioVisualAsync("Tab");
        }
        if (await page.IsAudioVisualVisibleAsync())
        {
            for (var attempt = 0; attempt < 3 && !await page.IsAVCostNewVisibleAsync(); attempt++)
            {
                await page.EnterAudioVisualAsync(data.Resolve("{{data:audio_visual_553}}"));
                await page.PressAudioVisualAsync("Tab");
                await page.PauseAsync(500);
            }
            await page.EnterAVCostNewAsync(data.Resolve("{{data:av_cost_new_554}}"));
            await page.PressAVCostNewAsync("Tab");
        }
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForRiskPageVisibleAsync();
        await page.PauseAsync(1000);
        await page.ClickSemitrailerVehicleDetailAsync();
        await page.EnterSeasonalProduceTrailersAsync(data.Resolve("{{data:seasonal_produce_trailers_565}}"));
        await page.WaitForCoverageBeginDateAsync("Exists");
        await page.EnterCoverageEndDateAsync(data.Resolve("{DATE[09-05-2026][+6M][MM-dd-yyyy]}"));
        await page.EnterProduceCarriedAsync(data.Resolve("{{data:produce_carried_568}}"));
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForRiskPageVisibleAsync();
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete driver information$")]
    [When(@"^I complete driver information$")]
    [Then(@"^I complete driver information$")]
    public async Task CompleteDriverInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickDriverScheduleAsync();
        await page.PauseAsync(500);
        await page.WaitForSignsHeadingAsync("Exists");
        await page.PauseAsync(500);
        await page.ClickAddDriverAsync();
        await page.PauseAsync(500);
        await page.EnterFirstNameSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_first_name_579}}"));
        //await page.PressFirstNameAsync("Tab");
        await page.PauseAsync(500);
        await page.EnterLastNameSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_last_name_580}}"));
        //await page.PressLastNameAsync("Tab");
        await page.PauseAsync(500);
        await page.EnterDateOfBirthSequentiallyAsync(data.Resolve("{DATE[09-05-2026][-40y][MM-dd-yyyy]}"));
        //await page.PressDateOfBirthAsync("Tab");
        await page.PauseAsync(500);
        await page.EnterStateLicensedSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_state_licensed_582}}"));
        //await page.PressStateLicensedAsync("Tab");
        await page.PauseAsync(500);
        await page.EnterSexSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_sex_584}}"));
        await page.PressSexAsync("Tab");
        await page.PauseAsync(500);
        await page.EnterMaritalStatusSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_marital_status_585}}"));
        await page.PressMaritalStatusAsync("Tab");
        await page.PauseAsync(500);
        await page.EnterYearLicensedSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_year_licensed_586}}"));
        await page.PressYearLicensedAsync("Tab");
        await page.PauseAsync(500);
        await page.EnterDateOfHireSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_date_of_hire_587}}"));
        await page.PressDateOfHireAsync("Tab");
        await page.PauseAsync(500);
        if (await page.DoYouHaveACDLLicenseExistsAsync())
        {
            await page.EnterDoYouHaveACDLLicenseSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_do_you_have_a_cdl_license_588}}"));
            await page.PressDoYouHaveACDLLicenseAsync("Tab");
        }
        await page.PauseAsync(1000);
        await page.ClickOKAsync();
        await page.PauseAsync(1000);

    }

    [Given(@"^I verify Mandatory Endorsements$")]
    [When(@"^I verify Mandatory Endorsements$")]
    [Then(@"^I verify Mandatory Endorsements$")]
    public async Task VerifyMandatoryEndorsementsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        //await page.WaitForEndorsementsPageVisibleAsync();
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        //await page.VerifyFirstEndorsementScheduleRowAsync("__BLANK__", "InnerText");
        if (await page.IsCA2394EndorsementFormNameVisibleAsync())
        {
            await page.VerifyCA2394EndorsementFormNameAsync("Silica or Silica-Related Dust Exclusion", "InnerText");
        }
        //await page.VerifyFirstEndorsementTableRowAsync("__BLANK__", "InnerText");

    }

    [Given(@"^I add endorsement$")]
    [When(@"^I add endorsement$")]
    [Then(@"^I add endorsement$")]
    public async Task AddEndorsementAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_615}}"));
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForEndorsementsPageVisibleAsync();
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_634}}"));
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForEndorsementsPageVisibleAsync();
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_654}}"));
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForEndorsementsPageVisibleAsync();
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_676}}"));
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForClickAddExcludedDriverAsync("Visible");
        await page.ClickClickAddExcludedDriverAsync();
        await page.WaitForAddDriverNameVisibleAsync();
        await page.EnterAddDriverNameAsync("Steve Wozniak");
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForEndorsementsPageVisibleAsync();
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        //await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_695}}"));
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_696}}"));
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForCA9948ClassesOfCommoditiesTransportedVisibleAsync();
        await page.EnterCA9948ClassesOfCommoditiesTransportedSequentiallyAsync("Commodity Type I");
        await page.PressCA9948ClassesOfCommoditiesTransportedAsync("Tab");
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForEndorsementsPageVisibleAsync();
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_715}}"));
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForEndorsementsPageVisibleAsync();
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_736}}"));
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.PauseAsync(1000);
        //if (await page.IsTrailerInterchangeEnterDaysInsuredVisibleAsync())
        //{
        await page.WaitForTrailerInterchangeEnterDaysInsuredVisibleAsync();
        await page.EnterTrailerInterchangeEnterDaysInsuredAsync(data.Resolve("{{data:iframe_duck_creek_policy_trailer_interchange_enter_days_insured_730}}"));
        //}
        //if (await page.IsTrailerInterchangeEnterOfTrailersVisibleAsync())
        //{
        await page.PauseAsync(1000);
        await page.WaitForTrailerInterchangeEnterOfTrailersVisibleAsync();
        await page.EnterTrailerInterchangeEnterOfTrailersAsync(data.Resolve("{{data:iframe_duck_creek_policy_trailer_interchange_enter_of_trailers_731}}"));
        //}
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
       
        await page.WaitForEndorsementsPageVisibleAsync();
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
       
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_756}}"));
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.PauseAsync(2000);

        await page.WaitForCA9940YearVisibleAsync();
        if (await page.IsCA9940YearVisibleAsync())
        {
            await page.EnterCA9940YearSequentiallyAsync("2018");
        }

        await page.WaitForCA9940MakeVisibleAsync();
        if (await page.IsCA9940MakeVisibleAsync())
        {
            await page.EnterCA9940MakeSequentiallyAsync("Sub");
        }

        await page.WaitForCA9940ModelVisibleAsync();
        if (await page.IsCA9940ModelVisibleAsync())
        {
            await page.EnterCA9940ModelSequentiallyAsync("Forester");
        }

        await page.WaitForCA9940VINVisibleAsync();
        if (await page.IsCA9940VINVisibleAsync())
        {
            await page.EnterCA9940VINSequentiallyAsync("JF2SJABC4JH524145");
        }

        await page.WaitForCA9940ContractProvisionsVisibleAsync();
        await page.EnterCA9940ContractProvisionsSequentiallyAsync("Option 1");
        await page.PressCA9940ContractProvisionsAsync("Tab");
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.WaitForEndorsementsPageVisibleAsync();
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_775}}"));
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync("[CA2317] Truckers Uniform Intermodal Interchange Endorsement Form UIIE-1");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();


    }

    [Given(@"^I add Addl Interest$")]
    [When(@"^I add Addl Interest$")]
    [Then(@"^I add Addl Interest$")]
    public async Task AddAddlInterestAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickAdditionalInterestsAsync();
        await page.WaitForAddOtherInterestVisibleAsync();
        await page.ClickAddOtherInterestAsync();
        await page.EnterTypeOfInterestSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_type_of_interest_785}}"));
        await page.PressTypeOfInterestAsync("Tab");
        if (data.Condition("'First Name' != NULL"))
        {
            await page.EnterAdditionalOtherInterestFirstNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_first_name_788}}"));
        }
        if (data.Condition("'Last Name' != NULL"))
        {
            await page.EnterAdditionalOtherInterestLastNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_last_name_789}}"));
        }
        if (await page.IsAdditionalOtherInterestBusinessNameVisibleAsync())
        {
            await page.EnterAdditionalOtherInterestBusinessNameAsync("Sample Business Name");
        }
        if (data.Condition("Address != NULL"))
        {
            await page.EnterAdditionalOtherInterestAddressAsync(data.Resolve("{{data:iframe_duck_creek_policy_address_1_790}}"));
        }
        if (data.Condition("ZIP != NULL"))
        {
            await page.EnterAdditionalOtherInterestZipCodeAsync(data.Resolve("{{data:iframe_duck_creek_policy_zip_code_791}}"));
        }

        await page.ClickOKAsync();
        await page.WaitForAddOtherInterestVisibleAsync();
        await page.ClickAdditionalInterestsAsync();
        await page.WaitForAddOtherInterestVisibleAsync();
        await page.ClickAddOtherInterestAsync();
        await page.EnterTypeOfInterestSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_type_of_interest_801}}"));
        await page.PressTypeOfInterestAsync("Tab");
        if (data.Condition("'First Name' != NULL"))
        {
            await page.EnterAdditionalOtherInterestFirstNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_first_name_804}}"));
        }
        if (data.Condition("'Last Name' != NULL"))
        {
            await page.EnterAdditionalOtherInterestLastNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_last_name_805}}"));
        }
        if (await page.IsAdditionalOtherInterestBusinessNameVisibleAsync())
        {
            await page.EnterAdditionalOtherInterestBusinessNameAsync("Sample Business Name");
        }
        if (data.Condition("Address != NULL"))
        {
            await page.EnterAdditionalOtherInterestAddressAsync(data.Resolve("{{data:iframe_duck_creek_policy_address_1_806}}"));
        }
        if (data.Condition("ZIP != NULL"))
        {
            await page.EnterAdditionalOtherInterestZipCodeAsync(data.Resolve("{{data:iframe_duck_creek_policy_zip_code_807}}"));
        }
        if (await page.IsIFRAMEDuckCreekPolicyVehicleAssociationVisibleAsync())
        {
            await page.SelectFirstIFRAMEDuckCreekPolicyVehicleAssociationOptionAsync();
        }
        await page.ClickOKAsync();
        await page.ClickAdditionalInterestsAsync();
        await page.WaitForAddOtherInterestVisibleAsync();
        await page.ClickAddOtherInterestAsync();
        await page.EnterTypeOfInterestSequentiallyAsync(data.Resolve("{{data:iframe_duck_creek_policy_type_of_interest_820}}"));
        await page.PressTypeOfInterestAsync("Tab");
        if (data.Condition("'First Name' != NULL"))
        {
            await page.EnterAdditionalOtherInterestFirstNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_first_name_823}}"));
        }
        if (data.Condition("'Last Name' != NULL"))
        {
            await page.EnterAdditionalOtherInterestLastNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_last_name_824}}"));
        }
        if (await page.IsAdditionalOtherInterestBusinessNameVisibleAsync())
        {
            await page.EnterAdditionalOtherInterestBusinessNameAsync("Sample Business Name");
        }
        if (data.Condition("Address != NULL"))
        {
            await page.EnterAdditionalOtherInterestAddressAsync(data.Resolve("{{data:iframe_duck_creek_policy_address_1_825}}"));
        }
        if (data.Condition("ZIP != NULL"))
        {
            await page.EnterAdditionalOtherInterestZipCodeAsync(data.Resolve("{{data:iframe_duck_creek_policy_zip_code_826}}"));
        }
        if (await page.IsIFRAMEDuckCreekPolicyVehicleAssociationVisibleAsync())
        {
            await page.SelectFirstIFRAMEDuckCreekPolicyVehicleAssociationOptionAsync();
        }
        await page.ClickOKAsync();

    }

    [Given(@"^I complete required underwriting question information$")]
    [When(@"^I complete required underwriting question information$")]
    [Then(@"^I complete required underwriting question information$")]
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickUWQuestionsAsync();
        await page.ClickUpdateAnswersButtonAsync();
        await page.EnterAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync(data.Resolve("{{data:are_there_any_commercial_vehicles_owned_by_the_applicant_not_insured_on_the_policy_837}}"));
        await page.EnterAnyPersonalAutoPolicyListingNameInsuredAsync(data.Resolve("{{data:anypersonalautopolicylistingnameinsured_839}}"));
        await page.EnterAnyVehicleCoveredRegisteredInNotPrimaryStateAsync(data.Resolve("{{data:anyvehiclecoveredregisteredinnotprimarystate_840}}"));
        await page.EnterBorrowingHiringOrLeasingWithinYearAsync(data.Resolve("{{data:borrowinghiringorleasingwithinyear_841}}"));
        if (await page.IsHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringVisibleAsync())
        {
            await page.EnterHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync(data.Resolve("{{data:has_any_applicant_been_convicted_of_a_felony_or_been_involved_in_any_incidents_or_claims_relating_to_sexual_abuse_or_molestation_allegations_discrimination_arson_fraud_bribery_or_negligent_hiring_845}}"));
        }

    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.PauseAsync(1000);
        await page.ClickNavigationBillingAsync();
        await page.PauseAsync(4000);
        await page.WaitForBillingAsync("Exists");
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_848}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_851}}"));
        await page.WaitForEasyPayAsync("Exists");
        await page.EnterEasyPayAsync(data.Resolve("{{data:easy_pay_855}}"));
        await page.PauseAsync(1000);

    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNotepadAsync();
        await page.ClickAddNotesRemarksAsync();
        await page.EnterTextBoxAsync(data.Resolve("Test {B[Product (LOB)]}"));
        await page.ClickOKAsync();

    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForSubmissionAsync("Visible");
        await page.ClickSubmissionAsync();
        await page.PauseAsync(4000);
        if (await page.IsThisCoverageBoundExistsAsync())
        {
            await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_866}}"));
        }
        if (await page.OrderAuditExistsAsync())
        {
            await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_868}}"));
        }
        await page.PauseAsync(1000);

    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.PauseAsync(4000);
        if (await page.IsThisCoverageBoundExistsAsync())
        {
            await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_866}}"));
        }
        await page.ClickCompleteApplicationAsync();
        await page.WaitForStoplightProcessingCompleteMessageAsync("Visible");
        await page.ClickStoplightWaitingWindowCloseButtonAsync();
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.EnterSessionIDAsync(data.Resolve("{B[SessionId]}"));
        await page.VerifyStatusCodeAsync(data.Resolve("{{data:expected_statuscode_value_914}}"), "value");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

    }

    [Given(@"^I complete save for Later/Return to Admin$")]
    [When(@"^I complete save for Later/Return to Admin$")]
    [Then(@"^I complete save for Later/Return to Admin$")]
    public async Task CompleteSaveForLaterReturnToAdminAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifySaveForLaterAsync("Exists", "");
        await page.ClickSaveForLaterAsync();
        await page.WaitForSaveForLaterOKAsync("Exists");
        await page.ClickSaveForLaterOKAsync();
        await page.VerifyReturnToAdminAsync("Exists", "");
        await page.ClickReturnToAdminAsync();
        await page.WaitForReturnToAdminAsync("Absent");

    }

}
