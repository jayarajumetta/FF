using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "BAP Expanded")]
public sealed class BAPExpandedSteps
{
    private readonly ScenarioContext _scenario;
    public BAPExpandedSteps(ScenarioContext scenario) => _scenario = scenario;

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
        await page.ClickClientSearchAsync();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
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
        await page.VerifyNamedInsuredZipCodeAsync("[0-9]{5}-[0-9]{4}", "Regex:value");

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
        await page.ClickAddClientAsync();
        await page.PauseAsync(1000);
        await page.ClickThirdPartyDesigneeAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddThirdPartyAsync();
        await page.WaitForAdditionalOtherInterestInputFirstNameAsync("Exists");
        await page.EnterAdditionalOtherInterestInputFirstNameAsync(data.Resolve("{{data:additionalotherinterestinput_firstname_52}}"));
        await page.WaitForAdditionalOtherInterestInputLastNameAsync("Exists");
        await page.EnterAdditionalOtherInterestInputLastNameAsync(data.Resolve("{{runtime:AdditionalOtherInterestInputLastName_0055}}"));
        await page.EnterAdditionalOtherInterestAddressAsync(data.Resolve("{{data:additionalotherinterestinput_address1_55}}"));
        await page.EnterThirdPartyDesigneeZipCodeAsync(data.Resolve("{{data:zip_code_56}}"));
        await page.ClickOKAsync();
        await page.WaitForAddClientAsync("Exists");

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
        await page.ClickAddClientAsync();
        await page.ClickAdditionalNamedInsuredAsync();
        await page.WaitForAdditionalNamedInsuredHeadingAsync("Exists");
        await page.ClickAddNamedInsuredIndividualAsync();
        await page.WaitForAdditionalInsuredFirstNameAsync("Exists");
        await page.EnterAdditionalInsuredFirstNameAsync(data.Resolve("{{runtime:AdditionalInsuredLastName_0062}}"));
        await page.EnterAdditionalInsuredFirstNameAsync(data.Resolve("{{data:additional_insured_first_name_65}}"));
        await page.EnterAdditionalInsuredMiddleNameAsync(data.Resolve("{{data:additional_insured_middle_name_66}}"));
        await page.ClickAdditionalInsuredIndividualDetailAsync();
        await page.WaitForAdditionalInsuredIndividualAddressAsync("Exists");
        await page.EnterAdditionalInsuredIndividualAddressAsync(data.Resolve("{{data:address_1_70}}"));
        await page.EnterAdditionalInsuredIndividualZipCodeAsync(data.Resolve("{{data:zip_code_71}}"));
        await page.EnterAdditionalInsuredIndividualDateOfBirthAsync(data.Resolve("{{data:date_of_birth_72}}"));
        await page.ClickClientSearchAsync();
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.ClickOrderSSNAsync();
        await page.WaitForSSNWasNotReturnedAsync("Exists");
        await page.EnterAddAssociatedClientEnterSSNAsync(data.Resolve("{{runtime:InsuredSSN}}"));
        await page.WaitForAddAssociatedClientEnterSSNAsync("Exists");
        await page.PressAddAssociatedClientEnterSSNAsync("Doubleclick");
        await page.ClickVerifyAsync();
        await page.WaitForVerifyAsync("Absent");
        await page.WaitForPleaseVerifySSNAsync("Absent");
        await page.ClickOKAsync();
        await page.WaitForReturnToClientAsync("Exists");
        await page.ClickReturnToClientAsync();
        await page.WaitForAddClientAsync("Exists");
        await page.EnterTitleAsync(data.Resolve("{{data:title_88}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_89}}"));
        await page.VerifyResultAsync(data.Resolve("{{data:expected_result_value_90}}"), "value");

    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickPolicyInfoAsync();
        await page.WaitForPolicyInfoHeaderAsync("Exists");
        await page.PauseAsync(1000);
        await page.EnterPolicyInfoRequiredAndOptionalFieldsEffectiveDateAsync(data.Resolve("{{data:effectivedate_94}}"));
        await page.EnterYearsInBusinessAsync(data.Resolve("{{data:years_in_business_95}}"));
        await page.PauseAsync(1000);
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_97}}"));
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_101}}"));
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_103}}"));
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_104}}"));
        await page.PressPrimaryRatingStateAsync("Down");
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_106}}"));
        await page.EnterPrimaryRatingStateAsync(data.Resolve("{{data:primaryratingstate_107}}"));
        await page.PressPrimaryRatingStateAsync("Down");
        await page.PauseAsync(1000);
        await page.WaitForPrimaryRatingStateAsync("Exists");
        await page.EnterWereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90DaysAsync(data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_111}}"));
        await page.VerifyPriorAmericanNationalPolicyAsync("Absent", "");
        await page.VerifyWhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNationalAsync("Absent", "");
        await page.VerifyIsThisPolicyBeingFullyCancelledAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.WaitForPolicyInfoHeaderAsync("Visible");
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

        await page.VerifyTheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESSAsync("Exists", "");
        await page.ClickInsuranceScoreConsentAsync();
        await page.WaitForAcceptAsync("Exists");
        await page.ClickAcceptAsync();
        await page.WaitForInsuranceScoreAsync("Exists");
        await page.ClickInsuranceScoreAsync();
        await page.VerifyReferenceNumberAsync(data.Resolve("{{data:expected_reference_number_innertext_139}}"), "InnerText");
        await page.PauseAsync(1000);
        await page.PauseAsync(1000);

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
        await page.WaitForClientAsync("Exists");

    }

    [Given(@"^I navigate to policy coverages$")]
    [When(@"^I navigate to policy coverages$")]
    [Then(@"^I navigate to policy coverages$")]
    public async Task NavigateToPolicyCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.WaitForPolicyCovgerageAsync("Exists");
        await page.ClickPolicyCovgerageAsync();
        await page.WaitForSignsHeadingAsync("Exists");
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

        await page.VerifyCTStraightThroughLiabilityLimitTo1MAsync("Exists", "");

    }

    [Given(@"^I add NonOwnership Liability$")]
    [When(@"^I add NonOwnership Liability$")]
    [Then(@"^I add NonOwnership Liability$")]
    public async Task AddNonOwnershipLiabilityAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifySignsHeadingAsync("Absent", "");
        await page.ClickPolicyCovgerageAsync();
        await page.EnterNonOwnedAutoAsync(data.Resolve("{{data:non_owned_auto_172}}"));
        await page.WaitForOfEmployeesAsync("Exists");
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

        await page.VerifySignsHeadingAsync("Absent", "");
        await page.ClickPolicyCovgerageAsync();
        await page.EnterBusinessInterruptionEndorsementAsync(data.Resolve("{{data:business_interruption_endorsement_180}}"));
        await page.WaitForLocationDetailAsync("Exists");
        await page.ClickLocationDetailAsync();
        await page.WaitForOptionAAsync("Exists");
        await page.ClickOptionACheckBoxAsync();
        await page.WaitForOptionAScheduleButtonAsync("Exists");
        await page.EnterDescriptionOfBusinessActivitesAsync(data.Resolve("{{data:description_of_business_activites_187}}"));
        await page.ClickOptionAScheduleButtonAsync();
        await page.WaitForOptionAAsync("Exists");
        await page.ClickAddOptionAAsync();
        await page.WaitForBusinessInterruptionLimitOfInsuranceAsync("Exists");
        await page.EnterBusinessInterruptionLimitOfInsuranceAsync(data.Resolve("{{data:iframe_duck_creek_policy_business_interruption_limit_of_insurance_192}}"));
        await page.EnterBusinessInterruptionDescriptionOfScheduledPropertyAsync(data.Resolve("{{data:iframe_duck_creek_policy_business_interruption_description_of_scheduledproperty_194}}"));
        await page.ClickOKAsync();
        await page.PauseAsync(1000);
        await page.VerifyAdditionalInterestsScheduleIFRAMEAsync("Exists", "");
        await page.WaitForAdditionalInterestsScheduleIFRAMEAsync("Absent");
        await page.ClickOKAsync();
        await page.WaitForSignsHeadingAsync("Exists");

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
        await page.WaitForLocationAsync("Exists");
        await page.VerifyLocationZipCodeAsync("[0-9]{5}-[0-9]{4}", "Regex:value");

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
        await page.WaitForSelectAsync("Absent");
        await page.WaitForOKAsync("Visible");
        await page.WaitForSignsHeadingAsync("Exists");
        if (data.Condition("'UM Type Default' != NULL"))
        {
            await page.EnterUMTypeDefaultSelectionsAsync(data.Resolve("{{data:um_type_default_selections_211}}"));
            await page.PressUMTypeDefaultSelectionsAsync("RETURN");
        }
        if (data.Condition("'UMBI Limit' != NULL AND 'UM Type Default' != \"UMBIPD CSL\""))
        {
            await page.EnterUMBILimitAsync(data.Resolve("{{data:umbi_limit_212}}"));
        }
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifyOKAsync("Exists", "");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.ClickOKAsync();
        await page.WaitForSelectAsync("Exists");

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
        await page.ClickHiredAutoLiabilityAsync();
        await page.ClickPrimaryLiabilityIfAnyAsync();
        await page.ClickExcessLiabilityIfAnyAsync();
        await page.ClickEmployeeHiredAutosCheckBoxAsync();
        await page.ClickVolunteerHiredAutosCheckBoxAsync();
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
        await page.EnterStateDetailsHiredAutoPDWithoutDriverOTCDeductibleAsync(data.Resolve("{{data:otc_deductible_240}}"));
        await page.ClickStateDetailsHiredAutoPDWithoutDriverIfAnyFieldAsync();
        await page.EnterHiredAutoCollisionDeductibleAsync(data.Resolve("{{data:collision_deductible_242}}"));
        await page.ClickStateDetailsHiredAutoPDWithoutDriverIfAnyAsync();
        await page.PauseAsync(1000);
        await page.ClickHiredAutoPhysicalDamageWithDriverAsync();
        await page.EnterStateDetailsHiredAutoPDWithoutDriverOTCDeductibleAsync(data.Resolve("{{data:otc_deductible_246}}"));
        await page.ClickStateDetailsHiredAutoPhysicalDamageWithDriverIfAnyFieldAsync();
        await page.EnterHiredAutoCollisionDeductibleAsync(data.Resolve("{{data:collision_deductible_248}}"));
        await page.ClickStateDetailsHiredAutoPhysicalDamageWithDriverIfAnyAsync();
        await page.EnterVehicleInformationAsync(data.Resolve("{{data:vehicle_information_250}}"));
        await page.PauseAsync(1000);
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Exists", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.WaitForSelectAsync("Visible");

    }

    [Given(@"^I add a Risk$")]
    [When(@"^I add a Risk$")]
    [Then(@"^I add a Risk$")]
    public async Task AddARiskAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_264}}"));
        await page.WaitForVehicleTypeAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_266}}"));
        await page.VerifyVehicleTypeAsync(data.Resolve("{{data:expected_vehicle_type_value_267}}"), "value");
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForSignsHeadingAsync("Exists");
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
        if (data.Condition("Snowplow != NULL"))
        {
            await page.VerifyIsThisVehicleUsedInSnowPlowOperationsAsync("Exists", "");
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_278}}"));
        }
        if (data.Condition("GCW != NULL"))
        {
            await page.EnterGCWAsync("");
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync("");
        }
        await page.VerifyCollisionCoverageAsync("Exists", "");
        if (data.Condition("'Collision Coverage' == NULL"))
        {
            await page.EnterCollisionCoverageAsync(data.Resolve("{{data:collision_coverage_286}}"));
        }
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_298}}"));
        await page.WaitForVehicleTypeAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_300}}"));
        await page.VerifyVehicleTypeAsync(data.Resolve("{{data:expected_vehicle_type_value_301}}"), "value");
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForSignsHeadingAsync("Exists");
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
        if (data.Condition("Snowplow != NULL"))
        {
            await page.VerifyIsThisVehicleUsedInSnowPlowOperationsAsync("Exists", "");
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_312}}"));
        }
        if (data.Condition("GCW != NULL"))
        {
            await page.EnterGCWAsync("");
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_315}}"));
        }
        if (data.Condition("'OTC Causes of Loss' != NULL"))
        {
            await page.EnterOTCCausesOfLossAsync(data.Resolve("{{data:otc_causes_of_loss_316}}"));
        }
        await page.VerifyCollisionCoverageAsync("Exists", "");
        if (data.Condition("'Collision Coverage' == NULL"))
        {
            await page.EnterCollisionCoverageAsync(data.Resolve("{{data:collision_coverage_321}}"));
        }
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_333}}"));
        await page.WaitForVehicleTypeAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_335}}"));
        await page.VerifyVehicleTypeAsync(data.Resolve("{{data:expected_vehicle_type_value_336}}"), "value");
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForSignsHeadingAsync("Exists");
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
        if (data.Condition("Snowplow != NULL"))
        {
            await page.VerifyIsThisVehicleUsedInSnowPlowOperationsAsync("Exists", "");
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_347}}"));
        }
        if (data.Condition("GCW != NULL"))
        {
            await page.EnterGCWAsync(data.Resolve("{{data:gcw_349}}"));
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync("");
        }
        await page.VerifyCollisionCoverageAsync("Exists", "");
        if (data.Condition("'Collision Coverage' == NULL"))
        {
            await page.EnterCollisionCoverageAsync(data.Resolve("{{data:collision_coverage_355}}"));
        }
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_367}}"));
        await page.WaitForVehicleTypeAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_369}}"));
        await page.VerifyVehicleTypeAsync(data.Resolve("{{data:expected_vehicle_type_value_370}}"), "value");
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForSignsHeadingAsync("Exists");
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
        if (data.Condition("'Value Basis' != NULL"))
        {
            await page.EnterValueBasisAsync(data.Resolve("{{data:value_basis_377}}"));
        }
        if (data.Condition("'Original Cost New' != NULL"))
        {
            await page.EnterOriginalCostNewAsync(data.Resolve("{{data:original_cost_new_378}}"));
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterVINAsync(data.Resolve("{{data:vin_380}}"));
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.VerifyIsThisVehicleUsedInSnowPlowOperationsAsync("Exists", "");
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_383}}"));
        }
        if (data.Condition("'Used as Showroom' != NULL"))
        {
            await page.EnterUsedAsShowroomAsync(data.Resolve("{{data:used_as_showroom_385}}"));
        }
        if (data.Condition("'Used as Showroom' != NULL"))
        {
            await page.EnterUsedAsShowroomAsync(data.Resolve("{{data:used_as_showroom_386}}"));
        }
        if (data.Condition("GCW != NULL"))
        {
            await page.EnterGCWAsync("");
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync("");
        }
        if (data.Condition("'2nd Class Category' != NULL"))
        {
            await page.EnterN2ndClassCategoryAsync(data.Resolve("{{data:2nd_class_category_389}}"));
        }
        if (data.Condition("'2nd Class Code' != NULL"))
        {
            await page.EnterN2ndClassCodeAsync(data.Resolve("{{data:2nd_class_code_390}}"));
        }
        await page.VerifyCollisionCoverageAsync("Exists", "");
        if (data.Condition("'Collision Coverage' == NULL"))
        {
            await page.EnterCollisionCoverageAsync(data.Resolve("{{data:collision_coverage_395}}"));
        }
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_407}}"));
        await page.WaitForVehicleTypeAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_409}}"));
        await page.VerifyVehicleTypeAsync(data.Resolve("{{data:expected_vehicle_type_value_410}}"), "value");
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        if (data.Condition("VIN != NULL"))
        {
            await page.WaitForVINAsync("Visible");
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
        if (data.Condition("'Body Style' != NULL"))
        {
            await page.EnterBodyStyleAsync(data.Resolve("{{data:body_style_417}}"));
        }
        if (data.Condition("'Stated Amount' != NULL"))
        {
            await page.EnterStatedAmountAsync(data.Resolve("{{data:stated_amount_418}}"));
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterVINAsync(data.Resolve("{{data:vin_420}}"));
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.VerifyIsThisVehicleUsedInSnowPlowOperationsAsync("Exists", "");
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_423}}"));
        }
        if (data.Condition("'Engine Size' != NULL"))
        {
            await page.EnterEngineSizeCcAsync(data.Resolve("{{data:engine_size_cc_425}}"));
        }
        if (data.Condition("'Engine Size' != NULL"))
        {
            await page.EnterEngineSizeCcAsync(data.Resolve("{{data:engine_size_cc_426}}"));
        }
        if (data.Condition("GCW != NULL"))
        {
            await page.EnterGCWAsync("");
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync("");
        }
        await page.VerifyCollisionCoverageAsync("Exists", "");
        if (data.Condition("'Collision Coverage' == NULL"))
        {
            await page.EnterCollisionCoverageAsync(data.Resolve("{{data:collision_coverage_433}}"));
        }
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.WaitForRiskScheduleAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForShowAllLocationsAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_445}}"));
        await page.WaitForVehicleTypeAsync("Exists");
        await page.EnterVehicleTypeAsync(data.Resolve("{{data:vehicle_type_447}}"));
        await page.VerifyVehicleTypeAsync(data.Resolve("{{data:expected_vehicle_type_value_448}}"), "value");
        await page.ClickAddRiskAtThisLocationAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        if (data.Condition("VIN != NULL"))
        {
            await page.WaitForVINAsync("Visible");
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
        if (data.Condition("'Body Style' != NULL"))
        {
            await page.EnterBodyStyleAsync(data.Resolve("{{data:body_style_455}}"));
        }
        if (data.Condition("'Stated Amount' != NULL"))
        {
            await page.EnterStatedAmountAsync(data.Resolve("{{data:stated_amount_456}}"));
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterVINAsync(data.Resolve("{{data:vin_458}}"));
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.VerifyIsThisVehicleUsedInSnowPlowOperationsAsync("Exists", "");
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync(data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_461}}"));
        }
        if (data.Condition("GCW != NULL"))
        {
            await page.EnterGCWAsync("");
        }
        if (data.Condition("Snowplow != NULL"))
        {
            await page.EnterIsThisVehicleUsedInSnowPlowOperationsAsync("");
        }
        await page.VerifyCollisionCoverageAsync("Exists", "");
        if (data.Condition("'Collision Coverage' == NULL"))
        {
            await page.EnterCollisionCoverageAsync(data.Resolve("{{data:collision_coverage_469}}"));
        }
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);

    }

    [Given(@"^I add Risk Level Interest$")]
    [When(@"^I add Risk Level Interest$")]
    [Then(@"^I add Risk Level Interest$")]
    public async Task AddRiskLevelInterestAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickRiskScheduleAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifyCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_476}}"), "InnerText");
        await page.ClickLocationDetailAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:hired_auto_ext_addl_insured_480}}"));
        await page.VerifyHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:expected_hired_auto_ext_addl_insured_value_481}}"), "value");
        await page.WaitForHiredAutoOKAsync("Exists");
        await page.EnterHiredAutoOKAsync(data.Resolve("{{data:hired_auto_form_483}}"));
        await page.WaitForHiredAutoOKAsync("NotEqual");
        await page.WaitForHiredAutoOKAsync("Absent");
        await page.ClickOKAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifyCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_490}}"), "InnerText");
        await page.ClickLocationDetailAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:hired_auto_ext_addl_insured_494}}"));
        await page.VerifyHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:expected_hired_auto_ext_addl_insured_value_495}}"), "value");
        await page.WaitForHiredAutoOKAsync("Exists");
        await page.EnterHiredAutoOKAsync(data.Resolve("{{data:hired_auto_form_497}}"));
        await page.WaitForHiredAutoOKAsync("NotEqual");
        await page.WaitForHiredAutoOKAsync("Absent");
        await page.ClickOKAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickRiskScheduleAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifyCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_504}}"), "InnerText");
        await page.ClickLocationDetailAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:hired_auto_ext_addl_insured_508}}"));
        await page.VerifyHiredAutoExtAddlInsuredAsync(data.Resolve("{{data:expected_hired_auto_ext_addl_insured_value_509}}"), "value");
        await page.WaitForHiredAutoOKAsync("Exists");
        await page.EnterHiredAutoOKAsync(data.Resolve("{{data:hired_auto_form_511}}"));
        await page.WaitForHiredAutoOKAsync("NotEqual");
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
        }
        await page.WaitForHiredAutoOKAsync("Absent");
        await page.ClickOKAsync();
        await page.WaitForSignsHeadingAsync("Exists");

    }

    [Given(@"^I verify Risk Level Coverages$")]
    [When(@"^I verify Risk Level Coverages$")]
    [Then(@"^I verify Risk Level Coverages$")]
    public async Task VerifyRiskLevelCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_523}}"), "InnerText");
        await page.ClickLocationDetailAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        if (data.Condition("'Accept UM' != NULL"))
        {
            await page.VerifyAcceptUMAsync(data.Resolve("{{data:expected_accept_um_innertext_527}}"), "InnerText");
        }
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);

    }

    [Given(@"^I add Risk Level Coverages$")]
    [When(@"^I add Risk Level Coverages$")]
    [Then(@"^I add Risk Level Coverages$")]
    public async Task AddRiskLevelCoveragesAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_532}}"), "InnerText");
        await page.ClickLocationDetailAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        if (data.Condition("'Loan/Lease Gap' != NULL"))
        {
            await page.EnterLoanLeaseGapAsync(data.Resolve("{{data:loan_lease_gap_536}}"));
        }
        if (data.Condition("'Tapes Coverage' != NULL"))
        {
            await page.EnterTapesCoverageAsync(data.Resolve("{{data:tapes_coverage_537}}"));
        }
        if (data.Condition("'Audio Visual' != NULL"))
        {
            await page.EnterAudioVisualAsync(data.Resolve("{{data:audio_visual_538}}"));
        }
        if (data.Condition("'Audio Visual' != NULL"))
        {
            await page.EnterAVCostNewAsync(data.Resolve("{{data:av_cost_new_539}}"));
        }
        if (data.Condition("Towing != NULL && 'Vehicle Type' == \"Private Passenger\""))
        {
            await page.EnterTowingAsync("");
        }
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifyCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_547}}"), "InnerText");
        await page.ClickLocationDetailAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        if (data.Condition("'Loan/Lease Gap' != NULL"))
        {
            await page.EnterLoanLeaseGapAsync(data.Resolve("{{data:loan_lease_gap_551}}"));
        }
        if (data.Condition("'Tapes Coverage' != NULL"))
        {
            await page.EnterTapesCoverageAsync(data.Resolve("{{data:tapes_coverage_552}}"));
        }
        if (data.Condition("'Audio Visual' != NULL"))
        {
            await page.EnterAudioVisualAsync(data.Resolve("{{data:audio_visual_553}}"));
        }
        if (data.Condition("'Audio Visual' != NULL"))
        {
            await page.EnterAVCostNewAsync(data.Resolve("{{data:av_cost_new_554}}"));
        }
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifyCG2007AddLInsuredEngineersArchitectsTypeAsync(data.Resolve("{{data:constraint_vehicle_schedule_1_type_561}}"), "InnerText");
        await page.ClickLocationDetailAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.EnterSeasonalProduceTrailersAsync(data.Resolve("{{data:seasonal_produce_trailers_565}}"));
        await page.WaitForCoverageBeginDateAsync("Exists");
        await page.EnterCoverageEndDateAsync(data.Resolve("{DATE[09-05-2026][+6M][MM-dd-yyyy]}"));
        await page.EnterProduceCarriedAsync(data.Resolve("{{data:produce_carried_568}}"));
        await page.WaitForOKAsync("Exists");
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.PauseAsync(1000);
        await page.WaitForSignsHeadingAsync("Exists");

    }

    [Given(@"^I complete driver information$")]
    [When(@"^I complete driver information$")]
    [Then(@"^I complete driver information$")]
    public async Task CompleteDriverInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickDriverScheduleAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickAddDriverAsync();
        await page.WaitForOptionAAsync("Exists");
        await page.EnterFirstNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_first_name_579}}"));
        await page.EnterLastNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_last_name_580}}"));
        await page.EnterDateOfBirthAsync(data.Resolve("{DATE[09-05-2026][-40y][MM-dd-yyyy]}"));
        await page.EnterStateLicensedAsync(data.Resolve("{{data:iframe_duck_creek_policy_state_licensed_582}}"));
        await page.VerifyDriversLicenseNumberAsync(data.Resolve("{{data:expected_iframe_duck_creek_policy_drivers_license_number_innertext_583}}"), "InnerText");
        await page.EnterSexAsync(data.Resolve("{{data:iframe_duck_creek_policy_sex_584}}"));
        await page.EnterMaritalStatusAsync(data.Resolve("{{data:iframe_duck_creek_policy_marital_status_585}}"));
        await page.EnterYearLicensedAsync(data.Resolve("{{data:iframe_duck_creek_policy_year_licensed_586}}"));
        await page.EnterDateOfHireAsync(data.Resolve("{{data:iframe_duck_creek_policy_date_of_hire_587}}"));
        await page.EnterDoYouHaveACDLLicenseAsync(data.Resolve("{{data:iframe_duck_creek_policy_do_you_have_a_cdl_license_588}}"));
        await page.ClickOKAsync();
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");
        await page.WaitForDriverDetailIFRAMEAsync("Absent");
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.WaitForLoadingMessageAsync("Absent");

    }

    [Given(@"^I verify Mandatory Endorsements$")]
    [When(@"^I verify Mandatory Endorsements$")]
    [Then(@"^I verify Mandatory Endorsements$")]
    public async Task VerifyMandatoryEndorsementsAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifyFirstEndorsementScheduleRowAsync("__BLANK__", "InnerText");
        if (data.Condition("'Endorsement Type' ==\"[CA2394] Silica or Silica-Related Dust Exclusion\""))
        {
            await page.VerifyFirstEndorsementScheduleRowAsync(data.Resolve("{{data:expected_endorsement_schedule_row_1_innertext_598}}"), "InnerText");
        }
        await page.VerifyFirstEndorsementTableRowAsync("__BLANK__", "InnerText");
        if (data.Condition("'Endorsement Type' ==\"[CA2394] Silica or Silica-Related Dust Exclusion\""))
        {
            await page.VerifySecondEndorsementTableRowAsync(data.Resolve("{{data:expected_endorsement_table_row_2_innertext_600}}"), "InnerText");
        }

    }

    [Given(@"^I add endorsement$")]
    [When(@"^I add endorsement$")]
    [Then(@"^I add endorsement$")]
    public async Task AddEndorsementAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifySignsHeadingAsync("Absent", "");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOptionAAsync("Exists");
        if (data.Condition("Year != NULL"))
        {
            await page.EnterCA9940YearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
            await page.EnterCA9940MakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
            await page.EnterCA9940ModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterCA9940VINAsync("");
        }
        await page.WaitForOKAsync("Exists");
        await page.WaitForBAPEndorsementsEndorsementTypeAsync("Exists");
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_614}}"));
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_615}}"));
        await page.ClickOKAsync();
        await page.VerifyBAPEndorsementsIFRAMEAsync("Exists", "");
        await page.WaitForBAPEndorsementsIFRAMEAsync("Absent");
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOptionAAsync("Exists");
        if (data.Condition("Year != NULL"))
        {
            await page.EnterCA9940YearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
            await page.EnterCA9940MakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
            await page.EnterCA9940ModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterCA9940VINAsync("");
        }
        await page.WaitForOKAsync("Exists");
        await page.WaitForBAPEndorsementsEndorsementTypeAsync("Exists");
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_633}}"));
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_634}}"));
        await page.ClickOKAsync();
        await page.VerifyBAPEndorsementsIFRAMEAsync("Exists", "");
        await page.WaitForBAPEndorsementsIFRAMEAsync("Absent");
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOptionAAsync("Exists");
        if (data.Condition("'Endorsement Type' == \"[CA2325] Leased Workers Coverage\""))
        {
            await page.WaitForCA2325LeasedWorkersCoverageAsync("Exists");
        }
        if (data.Condition("Year != NULL"))
        {
            await page.EnterCA9940YearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
            await page.EnterCA9940MakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
            await page.EnterCA9940ModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterCA9940VINAsync("");
        }
        await page.WaitForOKAsync("Exists");
        await page.WaitForBAPEndorsementsEndorsementTypeAsync("Exists");
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_653}}"));
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_654}}"));
        await page.ClickOKAsync();
        await page.VerifyBAPEndorsementsIFRAMEAsync("Exists", "");
        await page.WaitForBAPEndorsementsIFRAMEAsync("Absent");
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOptionAAsync("Exists");
        if (data.Condition("'Add Excluded Driver' != NULL"))
        {
            await page.WaitForClickAddExcludedDriverAsync("Exists");
        }
        if (data.Condition("'Add Excluded Driver' != NULL"))
        {
            await page.ClickClickAddExcludedDriverAsync();
        }
        if (data.Condition("'Driver Name' != NULL"))
        {
            await page.EnterAddDriverNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_add_driver_name_667}}"));
        }
        if (data.Condition("Year != NULL"))
        {
            await page.EnterCA9940YearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
            await page.EnterCA9940MakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
            await page.EnterCA9940ModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterCA9940VINAsync("");
        }
        await page.WaitForOKAsync("Exists");
        await page.WaitForBAPEndorsementsEndorsementTypeAsync("Exists");
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_675}}"));
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_676}}"));
        await page.ClickOKAsync();
        await page.VerifyBAPEndorsementsIFRAMEAsync("Exists", "");
        await page.WaitForBAPEndorsementsIFRAMEAsync("Absent");
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOptionAAsync("Exists");
        if (data.Condition("Year != NULL"))
        {
            await page.EnterCA9940YearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
            await page.EnterCA9940MakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
            await page.EnterCA9940ModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterCA9940VINAsync("");
        }
        if (data.Condition("'Commodities Transported' != NULL"))
        {
            await page.EnterCA9948ClassesOfCommoditiesTransportedAsync(data.Resolve("{{data:iframe_duck_creek_policy_ca9948_classes_of_commodities_transported_691}}"));
        }
        await page.WaitForOKAsync("Exists");
        await page.WaitForBAPEndorsementsEndorsementTypeAsync("Exists");
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_695}}"));
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_696}}"));
        await page.ClickOKAsync();
        await page.VerifyBAPEndorsementsIFRAMEAsync("Exists", "");
        await page.WaitForBAPEndorsementsIFRAMEAsync("Absent");
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOptionAAsync("Exists");
        if (data.Condition("Year != NULL"))
        {
            await page.EnterCA9940YearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
            await page.EnterCA9940MakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
            await page.EnterCA9940ModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterCA9940VINAsync("");
        }
        await page.WaitForOKAsync("Exists");
        await page.WaitForBAPEndorsementsEndorsementTypeAsync("Exists");
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_714}}"));
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_715}}"));
        await page.ClickOKAsync();
        await page.VerifyBAPEndorsementsIFRAMEAsync("Exists", "");
        await page.WaitForBAPEndorsementsIFRAMEAsync("Absent");
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOptionAAsync("Exists");
        if (data.Condition("Year != NULL"))
        {
            await page.EnterCA9940YearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
            await page.EnterCA9940MakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
            await page.EnterCA9940ModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterCA9940VINAsync("");
        }
        if (data.Condition("'Endorsement Type' ==\"Trailer Interchange Coverage\""))
        {
            await page.EnterTrailerInterchangeEnterDaysInsuredAsync(data.Resolve("{{data:iframe_duck_creek_policy_trailer_interchange_enter_days_insured_730}}"));
        }
        if (data.Condition("'Endorsement Type' ==\"Trailer Interchange Coverage\""))
        {
            await page.EnterTrailerInterchangeEnterOfTrailersAsync(data.Resolve("{{data:iframe_duck_creek_policy_trailer_interchange_enter_of_trailers_731}}"));
        }
        await page.WaitForOKAsync("Exists");
        await page.WaitForBAPEndorsementsEndorsementTypeAsync("Exists");
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_735}}"));
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_736}}"));
        await page.ClickOKAsync();
        await page.VerifyBAPEndorsementsIFRAMEAsync("Exists", "");
        await page.WaitForBAPEndorsementsIFRAMEAsync("Absent");
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOptionAAsync("Exists");
        if (data.Condition("Year != NULL"))
        {
            await page.EnterCA9940YearAsync(data.Resolve("{{data:iframe_duck_creek_policy_ca9940_year_747}}"));
        }
        if (data.Condition("Make != NULL"))
        {
            await page.EnterCA9940MakeAsync(data.Resolve("{{data:iframe_duck_creek_policy_ca9940_make_748}}"));
        }
        if (data.Condition("Model != NULL"))
        {
            await page.EnterCA9940ModelAsync(data.Resolve("{{data:iframe_duck_creek_policy_ca9940_model_749}}"));
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterCA9940VINAsync(data.Resolve("{{data:iframe_duck_creek_policy_ca_9940_vin_750}}"));
        }
        if (data.Condition("'Contract Provisions' != NULL"))
        {
            await page.EnterCA9940ContractProvisionsAsync(data.Resolve("{{data:iframe_duck_creek_policy_ca9940_contract_provisions_751}}"));
        }
        await page.WaitForOKAsync("Exists");
        await page.WaitForBAPEndorsementsEndorsementTypeAsync("Exists");
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_755}}"));
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_756}}"));
        await page.ClickOKAsync();
        await page.VerifyBAPEndorsementsIFRAMEAsync("Exists", "");
        await page.WaitForBAPEndorsementsIFRAMEAsync("Absent");
        await page.WaitForSignsHeadingAsync("Exists");
        await page.VerifySignsHeadingAsync("Absent", "");
        await page.ClickWCNavigationLinksEndorsementsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.WaitForClickAddEndorsementAsync("Visible");
        await page.ClickClickAddEndorsementAsync();
        await page.WaitForOptionAAsync("Exists");
        if (data.Condition("Year != NULL"))
        {
            await page.EnterCA9940YearAsync("");
        }
        if (data.Condition("Make != NULL"))
        {
            await page.EnterCA9940MakeAsync("");
        }
        if (data.Condition("Model != NULL"))
        {
            await page.EnterCA9940ModelAsync("");
        }
        if (data.Condition("VIN != NULL"))
        {
            await page.EnterCA9940VINAsync("");
        }
        await page.WaitForOKAsync("Exists");
        await page.WaitForBAPEndorsementsEndorsementTypeAsync("Exists");
        await page.ClickBAPEndorsementsEndorsementTypeAsync();
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_774}}"));
        await page.EnterBAPEndorsementsEndorsementTypeAsync(data.Resolve("{{data:endorsement_type_775}}"));
        await page.ClickOKAsync();
        await page.VerifyBAPEndorsementsIFRAMEAsync("Exists", "");
        await page.WaitForBAPEndorsementsIFRAMEAsync("Absent");
        await page.WaitForSignsHeadingAsync("Exists");

    }

    [Given(@"^I add Addl Interest$")]
    [When(@"^I add Addl Interest$")]
    [Then(@"^I add Addl Interest$")]
    public async Task AddAddlInterestAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyAdditionalInterestsScheduleAddlInterestsAsync("Absent", "");
        await page.ClickAdditionalInterestsAsync();
        await page.WaitForAdditionalInterestsScheduleAddlInterestsAsync("Exists");
        await page.ClickAddOtherInterestAsync();
        await page.WaitForTypeOfInterestAsync("Exists");
        await page.EnterTypeOfInterestAsync(data.Resolve("{{data:iframe_duck_creek_policy_type_of_interest_785}}"));
        await page.WaitForFirstNameAsync("Exists");
        if (data.Condition("'First Name' != NULL"))
        {
            await page.EnterFirstNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_first_name_788}}"));
        }
        if (data.Condition("'Last Name' != NULL"))
        {
            await page.EnterLastNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_last_name_789}}"));
        }
        if (data.Condition("Address != NULL"))
        {
            await page.EnterAddressAsync(data.Resolve("{{data:iframe_duck_creek_policy_address_1_790}}"));
        }
        if (data.Condition("ZIP != NULL"))
        {
            await page.EnterLocationZipCodeAsync(data.Resolve("{{data:iframe_duck_creek_policy_zip_code_791}}"));
        }
        await page.WaitForStateAsync("Visible");
        await page.ClickOKAsync();
        await page.WaitForAdditionalInterestsScheduleAddlInterestsAsync("Exists");
        await page.WaitForAdditionalInterestsScheduleIFRAMEAsync("Absent");
        await page.VerifyAdditionalInterestsScheduleAddlInterestsAsync("Absent", "");
        await page.ClickAdditionalInterestsAsync();
        await page.WaitForAdditionalInterestsScheduleAddlInterestsAsync("Exists");
        await page.ClickAddOtherInterestAsync();
        await page.WaitForTypeOfInterestAsync("Exists");
        await page.EnterTypeOfInterestAsync(data.Resolve("{{data:iframe_duck_creek_policy_type_of_interest_801}}"));
        await page.WaitForFirstNameAsync("Exists");
        if (data.Condition("'First Name' != NULL"))
        {
            await page.EnterFirstNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_first_name_804}}"));
        }
        if (data.Condition("'Last Name' != NULL"))
        {
            await page.EnterLastNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_last_name_805}}"));
        }
        if (data.Condition("Address != NULL"))
        {
            await page.EnterAddressAsync(data.Resolve("{{data:iframe_duck_creek_policy_address_1_806}}"));
        }
        if (data.Condition("ZIP != NULL"))
        {
            await page.EnterLocationZipCodeAsync(data.Resolve("{{data:iframe_duck_creek_policy_zip_code_807}}"));
        }
        await page.WaitForStateAsync("Visible");
        if (data.Condition("'Vehicle Association' != NULL"))
        {
            await page.ClickIFRAMEDuckCreekPolicyVehicleAssociationAsync();
        }
        if (data.Condition("'Vehicle Association' != NULL"))
        {
            await page.ClickIFRAMEDuckCreekPolicyVehicleAssociationAsync();
            await page.PressIFRAMEDuckCreekPolicyVehicleAssociationAsync("DOUBLECLICK");
            await page.PressIFRAMEDuckCreekPolicyVehicleAssociationAsync("DOWN");
            await page.PressIFRAMEDuckCreekPolicyVehicleAssociationAsync("Enter");
        }
        if (data.Condition("'Vehicle Association' != NULL"))
        {
            await page.WaitForIFRAMEDuckCreekPolicyVehicleAssociationAsync("NotEqual");
        }
        await page.ClickOKAsync();
        await page.WaitForAdditionalInterestsScheduleAddlInterestsAsync("Exists");
        await page.WaitForAdditionalInterestsScheduleIFRAMEAsync("Absent");
        await page.VerifyAdditionalInterestsScheduleAddlInterestsAsync("Absent", "");
        await page.ClickAdditionalInterestsAsync();
        await page.WaitForAdditionalInterestsScheduleAddlInterestsAsync("Exists");
        await page.ClickAddOtherInterestAsync();
        await page.WaitForTypeOfInterestAsync("Exists");
        await page.EnterTypeOfInterestAsync(data.Resolve("{{data:iframe_duck_creek_policy_type_of_interest_820}}"));
        await page.WaitForFirstNameAsync("Exists");
        if (data.Condition("'First Name' != NULL"))
        {
            await page.EnterFirstNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_first_name_823}}"));
        }
        if (data.Condition("'Last Name' != NULL"))
        {
            await page.EnterLastNameAsync(data.Resolve("{{data:iframe_duck_creek_policy_last_name_824}}"));
        }
        if (data.Condition("Address != NULL"))
        {
            await page.EnterAddressAsync(data.Resolve("{{data:iframe_duck_creek_policy_address_1_825}}"));
        }
        if (data.Condition("ZIP != NULL"))
        {
            await page.EnterLocationZipCodeAsync(data.Resolve("{{data:iframe_duck_creek_policy_zip_code_826}}"));
        }
        await page.WaitForStateAsync("Visible");
        if (data.Condition("'Vehicle Association' != NULL"))
        {
            await page.ClickIFRAMEDuckCreekPolicyVehicleAssociationAsync();
        }
        if (data.Condition("'Vehicle Association' != NULL"))
        {
            await page.ClickIFRAMEDuckCreekPolicyVehicleAssociationAsync();
            await page.PressIFRAMEDuckCreekPolicyVehicleAssociationAsync("DOUBLECLICK");
            await page.PressIFRAMEDuckCreekPolicyVehicleAssociationAsync("DOWN");
            await page.PressIFRAMEDuckCreekPolicyVehicleAssociationAsync("Enter");
        }
        if (data.Condition("'Vehicle Association' != NULL"))
        {
            await page.WaitForIFRAMEDuckCreekPolicyVehicleAssociationAsync("NotEqual");
        }
        await page.ClickOKAsync();
        await page.WaitForAdditionalInterestsScheduleAddlInterestsAsync("Exists");
        await page.WaitForAdditionalInterestsScheduleIFRAMEAsync("Absent");

    }

    [Given(@"^I complete required underwriting question information$")]
    [When(@"^I complete required underwriting question information$")]
    [Then(@"^I complete required underwriting question information$")]
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickUWQuestionsAsync();
        await page.WaitForSignsHeadingAsync("Exists");
        await page.ClickUpdateAnswersButtonAsync();
        await page.EnterAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync(data.Resolve("{{data:are_there_any_commercial_vehicles_owned_by_the_applicant_not_insured_on_the_policy_837}}"));
        await page.WaitForAreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicyAsync("Equal");
        await page.EnterAnyPersonalAutoPolicyListingNameInsuredAsync(data.Resolve("{{data:anypersonalautopolicylistingnameinsured_839}}"));
        await page.EnterAnyVehicleCoveredRegisteredInNotPrimaryStateAsync(data.Resolve("{{data:anyvehiclecoveredregisteredinnotprimarystate_840}}"));
        await page.EnterBorrowingHiringOrLeasingWithinYearAsync(data.Resolve("{{data:borrowinghiringorleasingwithinyear_841}}"));
        await page.WaitForBorrowingHiringOrLeasingWithinYearAsync("Equal");
        await page.WaitForAnyVehicleCoveredRegisteredInNotPrimaryStateAsync("Equal");
        await page.VerifyHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync("Exists", "");
        await page.EnterHasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiringAsync(data.Resolve("{{data:has_any_applicant_been_convicted_of_a_felony_or_been_involved_in_any_incidents_or_claims_relating_to_sexual_abuse_or_molestation_allegations_discrimination_arson_fraud_bribery_or_negligent_hiring_845}}"));

    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.ClickNavigationBillingAsync();
        await page.WaitForBillingAsync("Exists");
        await page.EnterBillTypeAsync(data.Resolve("{{data:bill_type_848}}"));
        await page.WaitForBillTypeAsync("Equal");
        await page.EnterPayPlanAsync(data.Resolve("{{data:pay_plan_851}}"));
        await page.WaitForPayPlanAsync("Equal");
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
        await page.WaitForNotepadHeadingAsync("Exists");
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
        await page.WaitForSubmissionHeadingAsync("Exists");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_866}}"));
        await page.VerifyOrderAuditAsync("Exists", "");
        await page.EnterOrderAuditAsync(data.Resolve("{{data:order_audit_868}}"));
        await page.VerifySubmissionHeadingAsync("Absent", "");
        await page.ClickSubmissionAsync();
        await page.PauseAsync(1000);
        await page.WaitForSubmissionHeadingAsync("Exists");
        await page.PauseAsync(1000);

    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var data = _scenario.Get<ScenarioData>();

        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>());

        await page.VerifyIsThisCoverageBoundAsync("Exists", "");
        await page.VerifyIsThisCoverageBoundAsync(data.Resolve("{{data:expected_is_this_coverage_bound_value_876}}"), "Value");
        await page.EnterIsThisCoverageBoundAsync(data.Resolve("{{data:is_this_coverage_bound_877}}"));
        await page.ClickCompleteApplicationAsync();
        await page.VerifyStoplightWaitingWindowCloseAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.VerifyStoplightWaitingWindowErrorAsync("Exists", "");
        await page.ClickStoplightWaitingWindowFirstCloseButtonOnErrorAsync();
        await page.PauseAsync(1000);
        await page.ClickCompleteApplicationAsync();
        await page.PauseAsync(1000);
        await page.ClickStoplightWaitingWindowCloseAsync();
        await page.WaitForStoplightWaitingWindowAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifyLoadingMessageAsync("Visible", "");
        await page.PauseAsync(1000);
        await page.VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync("Exists", "");
        await page.ClickCompleteApplicationAsync();
        await page.VerifyStoplightWaitingWindowCloseAsync("Absent", "");
        await page.PauseAsync(1000);
        await page.VerifyStoplightWaitingWindowErrorAsync("Exists", "");
        await page.ClickStoplightWaitingWindowFirstCloseButtonOnErrorAsync();
        await page.PauseAsync(1000);
        await page.ClickCompleteApplicationAsync();
        await page.PauseAsync(1000);
        await page.ClickStoplightWaitingWindowCloseAsync();
        await page.WaitForStoplightWaitingWindowAsync("Absent");
        await page.PauseAsync(1000);
        await page.VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync("Absent", "");
        await page.EnterTitleAsync(data.Resolve("{{data:title_909}}"));
        await page.EnterJavaScriptAsync(data.Resolve("{{data:javascript_910}}"));
        data.Set("SessionId", await page.CaptureResultAsync("value"));

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
