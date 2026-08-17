using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class NavigationPage
{
    private readonly NavigationLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public NavigationPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new NavigationLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete required billing information
    public async Task CompleteRequiredBillingInformationAsync()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0053_f7819aAsync
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0054_f7819aAsync
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_35}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_38}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_42}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0055_f7819aAsync
        await Task.Delay(1000);
    }

    // Business step: I navigate to Underwriting Info Screen
    public async Task NavigateToUnderwritingInfoScreenAsync()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToUnderwritingInfoScreen_0066_f7819aAsync
        await _ui.ClickAsync(_locators.UnderwritingInfo);
        // UnderwritingInfoOtherInsuranceHistory_b78753Page.AddPriorCarriorDetailsOnLossInformationScreen_0067_f7819aAsync
        await _ui.WaitAsync(_locators.IsThereAPriorCarrier, "Exists");
        await _ui.FillAsync(_locators.IsThereAPriorCarrier, _data.Resolve("{{data:is_there_a_prior_carrier_83}}"));
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Tab");
        await _ui.ClickAsync(_locators.AddPriorCarrier);
        await _ui.WaitAsync(_locators.Carrier, "Exists");
        await _ui.FillAsync(_locators.Carrier, _data.Resolve("{{data:carrier_86}}"));
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.FillAsync(_locators.PolicyNumberBA28E, _data.Resolve("{{data:policy_number_87}}"));
        await _ui.PressAsync(_locators.PolicyNumberBA28E, "Tab");
        await _ui.FillAsync(_locators.PolicyType, _data.Resolve("{{data:policy_type_88}}"));
        await _ui.PressAsync(_locators.PolicyType, "Tab");
        await _ui.FillAsync(_locators.EffectiveDateB557F, _data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDateB557F, "Tab");
        await _ui.FillAsync(_locators.ExpirationDate34EAC, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate34EAC, "Tab");
        await _ui.FillAsync(_locators.ModificationFactor, _data.Resolve("{{data:modificationfactor_91}}"));
        await _ui.PressAsync(_locators.ModificationFactor, "Tab");
        await _ui.FillAsync(_locators.TotalPremium, _data.Resolve("{{data:total_premium_92}}"));
        await _ui.PressAsync(_locators.TotalPremium, "Tab");
        await _ui.ClickAsync(_locators.OtherInsuranceHistoryOK);
        await _ui.WaitAsync(_locators.Detail0F8C6, "Exists");
        // UnderwritingInfoLossExperience_54b758Page.IndicateNoKnownLossesOnLossExperienceScreen_0068_f7819aAsync
        await _ui.ClickAsync(_locators.LossExperience);
        await _ui.WaitAsync(_locators.NoKnownLosses, "Exists");
        await _ui.SmartSetAsync(_locators.NoKnownLosses, _data.Resolve("{{data:no_known_losses_97}}"));
        await _ui.PressAsync(_locators.NoKnownLosses, "Tab");
        // CommonNavigationLinks_dba56bPage.ClickReturnToQuote_0069_f7819aAsync
        await _ui.ClickAsync(_locators.ReturnToQuote);
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0070_f7819aAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_99}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_100}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_101}}"), "value");
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0071_f7819aAsync
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0072_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0073_f7819aAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0074_f7819aAsync
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_105}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_106}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0075_f7819aAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0076_f7819aAsync
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_108}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_112}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0077_f7819aAsync
        _data.Set("StateIsKansas", _data.Resolve("Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0078_f7819aAsync
        if (_data.Condition("'Product (LOB)' == \"UMB\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_114}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_115}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0079_f7819aAsync
        _data.Set("StateIsVirginia", _data.Resolve("Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0080_f7819aAsync
        if (_data.Condition("'Product (LOB)' == \"UMB\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_117}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"UMB\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_118}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0081_f7819aAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0082_f7819aAsync
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_122}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0083_f7819aAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0084_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AL UMB StraightThrough {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I complete required policy covg information
    public async Task CompleteRequiredPolicyCovgInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToPolicyCovgScreen_0087_f7819aAsync
        await _ui.ClickAsync(_locators.PolicyCovg35BE4);
        // PolicyCovg_0dff37Page.CompleteRequiredFieldsVerificationSteps_0088_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        if (_data.Condition("'Umb Limit' != \"$1,000,000\""))
        {
            await _ui.FillAsync(_locators.UmbrellaLimit, _data.Resolve("{{data:umbrella_limit_134}}"));
            await _ui.PressAsync(_locators.UmbrellaLimit, "CLICK");
            await _ui.PressAsync(_locators.UmbrellaLimit, "Enter");
            await _ui.PressAsync(_locators.UmbrellaLimit, "Tab");
        }
        if (_data.Condition("'Umb Limit' == \"Over $15M\""))
        {
            await _ui.FillAsync(_locators.RequestedUmbrellaLimit, _data.Resolve("{{data:requested_umbrella_limit_135}}"));
            await _ui.PressAsync(_locators.RequestedUmbrellaLimit, "Enter");
            await _ui.PressAsync(_locators.RequestedUmbrellaLimit, "Tab");
        }
        if (_data.Condition("'Excluded Liability' != \"CU2186\""))
        {
            await _ui.FillAsync(_locators.ExcludedLiabilityConfidentialInformation, _data.Resolve("{{data:excluded_liability_confidential_information_136}}"));
            await _ui.PressAsync(_locators.ExcludedLiabilityConfidentialInformation, "CLICK");
            await _ui.PressAsync(_locators.ExcludedLiabilityConfidentialInformation, "Enter");
            await _ui.PressAsync(_locators.ExcludedLiabilityConfidentialInformation, "Tab");
            await _ui.PressAsync(_locators.ExcludedLiabilityConfidentialInformation, "Tab");
            await _ui.PressAsync(_locators.ExcludedLiabilityConfidentialInformation, "Tab");
        }
        if (_data.Condition("'Excluded Liability' != \"CU2186\""))
        {
            await _ui.WaitAsync(_locators.ExcludedLiabilityConfidentialInformation, "NotEqual");
        }
        if (_data.Condition("'Products - Aggregate Limit' != \"Umbrella Policy Limit\""))
        {
            await _ui.FillAsync(_locators.ProductsCompletedOperationsAggregateLimit, _data.Resolve("{{data:products_completed_operations_aggregate_limit_138}}"));
            await _ui.PressAsync(_locators.ProductsCompletedOperationsAggregateLimit, "Tab");
            await _ui.PressAsync(_locators.ProductsCompletedOperationsAggregateLimit, "Tab");
        }
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0089_f7819aAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0090_f7819aAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required location information
    public async Task CompleteRequiredLocationInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToLocationScreen_0116_f7819aAsync
        await _ui.ClickAsync(_locators.LocationE16BC);
        // Location_d219c6Page.ClickOKAndWaitForDetailButton_0117_f7819aAsync
        await _ui.WaitAsync(_locators.Location82D95, "Visible");
        await _ui.VerifyAsync(_locators.ZipCodeD2DBA, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        await _ui.ClickAsync(_locators.LocationOK);
        await _ui.WaitAsync(_locators.Detail33F0D, "Visible");
    }

    // Business step: I complete required commercial auto information
    public async Task CompleteRequiredCommercialAutoInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToCommercialAutoScreen_0118_f7819aAsync
        await _ui.ClickAsync(_locators.CommercialAuto);
        // CommercialAuto_c0e96dPage.FillOutCommercialAutoFields_0119_f7819aAsync
        await _ui.WaitAsync(_locators.CommercialAutoDetail, "Visible");
        await _ui.FillAsync(_locators.PolicyNumber461C7, _data.Resolve("{{data:policy_number_183}}"));
        await _ui.PressAsync(_locators.PolicyNumber461C7, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber461C7, "Tab");
        if (_data.Condition("'BAP Policy Number' != \"BAPPOL#\""))
        {
            await _ui.ClickAsync(_locators.ImportPolicyDataButton89922);
        }
        await _ui.WaitAsync(_locators.EffectiveDate68A1B, "NotEqual");
        await _ui.WaitAsync(_locators.StoplightMessageTotalSubjectPremium, "Absent");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0121_f7819aAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0122_f7819aAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required general liability information
    public async Task CompleteRequiredGeneralLiabilityInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToGeneralLiabScreen_0123_f7819aAsync
        await _ui.WaitAsync(_locators.GeneralLiab, "Visible");
        await _ui.PressAsync(_locators.GeneralLiab, "PRE:TAB");
        await _ui.PressAsync(_locators.GeneralLiab, "Tab");
        await _ui.ClickAsync(_locators.GeneralLiab);
        // GeneralLiability_9f087aPage.FillOutGeneralLiabilityFields_0124_f7819aAsync
        await _ui.WaitAsync(_locators.GeneralLiability, "Visible");
        await _ui.FillAsync(_locators.PolicyNumberFDF5C, _data.Resolve("{{data:policy_number_193}}"));
        await _ui.PressAsync(_locators.PolicyNumberFDF5C, "Tab");
        await _ui.PressAsync(_locators.PolicyNumberFDF5C, "Tab");
        if (_data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
            await _ui.FillAsync(_locators.EffectiveDateB3600, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
            await _ui.PressAsync(_locators.EffectiveDateB3600, "Tab");
        }
        await _ui.WaitAsync(_locators.EffectiveDateB3600, "NotEqual");
        if (_data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
            await _ui.FillAsync(_locators.ExpirationDateB437C, _data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            await _ui.PressAsync(_locators.ExpirationDateB437C, "Tab");
        }
        if (_data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
            await _ui.FillAsync(_locators.CGLLimits, _data.Resolve("{{data:cgl_limits_197}}"));
            await _ui.PressAsync(_locators.CGLLimits, "CLICK");
            await _ui.PressAsync(_locators.CGLLimits, "Enter");
            await _ui.PressAsync(_locators.CGLLimits, "Tab");
        }
        if (_data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
            await _ui.FillAsync(_locators.TotalSubjectPremium19B44, _data.Resolve("{{data:total_subject_premium_198}}"));
            await _ui.PressAsync(_locators.TotalSubjectPremium19B44, "Tab");
        }
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0126_f7819aAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0127_f7819aAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required sfp 10 information
    public async Task CompleteRequiredSfp10InformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToSFP10LiabilityFarmScreen_0136_f7819aAsync
        await _ui.ClickAsync(_locators.SFP10LiabilityFarm);
        // SFP10LiabilityFarm_203e45Page.FillOutSFP10LiabilityFarmFields_0137_f7819aAsync
        await _ui.WaitAsync(_locators.SFP10LiabilityFarmHeading, "Visible");
        await _ui.FillAsync(_locators.PolicyNumber78B85, _data.Resolve("{{data:policy_number_211}}"));
        await _ui.PressAsync(_locators.PolicyNumber78B85, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber78B85, "Tab");
        await _ui.FillAsync(_locators.EffectiveDate0E335, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDate0E335, "Tab");
        await _ui.WaitAsync(_locators.EffectiveDate0E335, "NotEqual");
        await _ui.FillAsync(_locators.ExpirationDate664A1, _data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate664A1, "Tab");
        await _ui.FillAsync(_locators.LiabilityLimit56E57, _data.Resolve("{{data:liability_limit_215}}"));
        await _ui.PressAsync(_locators.LiabilityLimit56E57, "CLICK");
        await _ui.PressAsync(_locators.LiabilityLimit56E57, "Enter");
        await _ui.PressAsync(_locators.LiabilityLimit56E57, "Tab");
        await _ui.FillAsync(_locators.TotalSubjectPremiumAF452, _data.Resolve("{{data:total_subject_premium_216}}"));
        await _ui.PressAsync(_locators.TotalSubjectPremiumAF452, "Tab");
    }

    // Business step: I complete required employers liability information
    public async Task CompleteRequiredEmployersLiabilityInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToEmployersLiabilityScreen_0141_f7819aAsync
        await _ui.WaitAsync(_locators.EmployersLiab, "Visible");
        await _ui.PressAsync(_locators.EmployersLiab, "PRE:TAB");
        await _ui.PressAsync(_locators.EmployersLiab, "Tab");
        await _ui.ClickAsync(_locators.EmployersLiab);
        // EmployersLiability_1f4f10Page.EmployersLiability_0142_f7819aAsync
        await _ui.FillAsync(_locators.PolicyNumber6566F, _data.Resolve("{{data:policy_number_220}}"));
        await _ui.PressAsync(_locators.PolicyNumber6566F, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber6566F, "Tab");
        if (_data.Condition("'WC Policy Number' != \"WCPOL#\""))
        {
            await _ui.ClickAsync(_locators.ImportPolicyDataButtonEF44C);
        }
        await _ui.WaitAsync(_locators.EffectiveDate6CF3D, "NotEqual");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0143_f7819aAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0144_f7819aAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required motorcycle liability information
    public async Task CompleteRequiredMotorcycleLiabilityInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToMotocycleScreen_0147_f7819aAsync
        await _ui.WaitAsync(_locators.MotorcycleLiability, "Visible");
        await _ui.PressAsync(_locators.MotorcycleLiability, "PRE:TAB");
        await _ui.PressAsync(_locators.MotorcycleLiability, "Tab");
        await _ui.ClickAsync(_locators.MotorcycleLiability);
        // MotorcycleLiability_dfd193Page.FillOutMotorcycleLiabilityFields_0148_f7819aAsync
        await _ui.FillAsync(_locators.PolicyNumber6566F, _data.Resolve("{{data:policy_number_236}}"));
        await _ui.PressAsync(_locators.PolicyNumber6566F, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber6566F, "Tab");
        await _ui.FillAsync(_locators.EffectiveDate6CF3D, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDate6CF3D, "Tab");
        await _ui.WaitAsync(_locators.EffectiveDate6CF3D, "NotEqual");
        await _ui.FillAsync(_locators.ExpirationDate82561, _data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate82561, "Tab");
        if (_data.Condition("'Motocycle Libaility Limit' != NULL"))
        {
            await _ui.FillAsync(_locators.LiabilityLimit1AE2B, _data.Resolve("{{data:liability_limit_240}}"));
            await _ui.PressAsync(_locators.LiabilityLimit1AE2B, "Tab");
        }
        await _ui.FillAsync(_locators.TotalSubjectPremiumE8AF0, _data.Resolve("{{data:total_subject_premium_241}}"));
        await _ui.PressAsync(_locators.TotalSubjectPremiumE8AF0, "Tab");
    }

    // Business step: I complete required rental owners liability information
    public async Task CompleteRequiredRentalOwnersLiabilityInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToRentalOwnersLiabilityScreen_0151_f7819aAsync
        await _ui.WaitAsync(_locators.RentalOwnersLiability, "Visible");
        await _ui.PressAsync(_locators.RentalOwnersLiability, "PRE:TAB");
        await _ui.PressAsync(_locators.RentalOwnersLiability, "Tab");
        await _ui.ClickAsync(_locators.RentalOwnersLiability);
        // RentalOwnersLiability_3a246bPage.FillOutRentalOwnersLiabilityFields_0152_f7819aAsync
        await _ui.FillAsync(_locators.PolicyNumber6566F, _data.Resolve("{{data:policy_number_255}}"));
        await _ui.PressAsync(_locators.PolicyNumber6566F, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber6566F, "Tab");
        await _ui.FillAsync(_locators.EffectiveDate6CF3D, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDate6CF3D, "Tab");
        await _ui.WaitAsync(_locators.EffectiveDate6CF3D, "NotEqual");
        await _ui.FillAsync(_locators.ExpirationDate82561, _data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate82561, "Tab");
        await _ui.FillAsync(_locators.LiabilityLimit1AE2B, _data.Resolve("{{data:liability_limit_259}}"));
        await _ui.PressAsync(_locators.LiabilityLimit1AE2B, "Tab");
    }

    // Business step: I complete required cpp information
    public async Task CompleteRequiredCppInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToCPPLiabilityScreen_0153_f7819aAsync
        await _ui.WaitAsync(_locators.CPPLiability, "Visible");
        await _ui.PressAsync(_locators.CPPLiability, "PRE:TAB");
        await _ui.PressAsync(_locators.CPPLiability, "Tab");
        await _ui.ClickAsync(_locators.CPPLiability);
        // CommercialPackagePolicy_827cc1Page.FillOutCPPLiabilityFields_0154_f7819aAsync
        await _ui.FillAsync(_locators.PolicyNumber6566F, _data.Resolve("{{data:policy_number_263}}"));
        await _ui.PressAsync(_locators.PolicyNumber6566F, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber6566F, "Tab");
        if (_data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
            await _ui.FillAsync(_locators.EffectiveDate6CF3D, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
            await _ui.PressAsync(_locators.EffectiveDate6CF3D, "Tab");
        }
        await _ui.WaitAsync(_locators.EffectiveDate6CF3D, "NotEqual");
        if (_data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
            await _ui.FillAsync(_locators.ExpirationDate82561, _data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            await _ui.PressAsync(_locators.ExpirationDate82561, "Tab");
        }
        if (_data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
            await _ui.FillAsync(_locators.LiabilityLimit1AE2B, _data.Resolve("{{data:liability_limit_267}}"));
            await _ui.PressAsync(_locators.LiabilityLimit1AE2B, "CLICK");
            await _ui.PressAsync(_locators.LiabilityLimit1AE2B, "Enter");
            await _ui.PressAsync(_locators.LiabilityLimit1AE2B, "Tab");
        }
        if (_data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
            await _ui.FillAsync(_locators.TotalSubjectPremiumE8AF0, _data.Resolve("{{data:total_subject_premium_268}}"));
            await _ui.PressAsync(_locators.TotalSubjectPremiumE8AF0, "Tab");
        }
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0155_f7819aAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0156_f7819aAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required endorsement information
    public async Task CompleteRequiredEndorsementInformationAsync()
    {
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0161_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0162_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0163_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0208_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0209_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0210_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // CU0400CoverageForInjuryToLeasedWorkers_0ad435Page.VerifyIfValueEqualsSelect_0218_f7819aAsync
        await _ui.VerifyAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:expected_select_endorsement_value_300}}"), "Value");
        // CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_885163Page.CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_0220_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_301}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement04BD0);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // CU2114AmendmentOfLiquorLiabilityExclusionExceptionForScheduledPremisesOrActivities_53fee9Page.CU2114AmendmentOfLiquorLiabilityExclusionExceptionForScheduledPremisesOrActivities_0222_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_305}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement34EE3);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.FillAsync(_locators.IFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivities, _data.Resolve("{{data:iframe_duck_creek_policy_description_of_premises_or_activities_308}}"));
        await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivities, "Tab");
        await _ui.ClickAsync(_locators.OK);
        // UC0272WaiverOfSubrogation_f430d0Page.WaitOnEndorsementType_0253_f7819aAsync
        await _ui.WaitAsync(_locators.SelectEndorsement0EAB0, "Exists");
        // TBoxWait_7ea9e1Page.WaitForEndorsementToBeCompleted_0254_f7819aAsync
        await Task.Delay(1000);
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0255_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0256_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0257_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0302_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0303_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0304_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // CU0400CoverageForInjuryToLeasedWorkers_0ad435Page.VerifyIfValueEqualsSelect_0312_f7819aAsync
        await _ui.VerifyAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:expected_select_endorsement_value_322}}"), "Value");
        // CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_885163Page.CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_0314_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_323}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement04BD0);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // CU2173ExclusionUnmannedAircraftCoverageBOnly_b77f17Page.CU2173ExclusionUnmannedAircraftCoverageBOnly_0324_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_327}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement34EE3);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // UC0272WaiverOfSubrogation_f430d0Page.WaitOnEndorsementType_0347_f7819aAsync
        await _ui.WaitAsync(_locators.SelectEndorsement0EAB0, "Exists");
        // TBoxWait_7ea9e1Page.WaitForEndorsementToBeCompleted_0348_f7819aAsync
        await Task.Delay(1000);
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0349_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0350_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0351_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // CU0400CoverageForInjuryToLeasedWorkers_0ad435Page.VerifyIfValueEqualsSelect_0359_f7819aAsync
        await _ui.VerifyAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:expected_select_endorsement_value_338}}"), "Value");
        // CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_885163Page.CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_0361_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_339}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement04BD0);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // CU2216UndergroundResourcesAndEquipmentCoverage_bcd304Page.CU2216UndergroundResourcesAndEquipmentCoverage_0372_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_343}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement34EE3);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.FillAsync(_locators.AggregateLimit, _data.Resolve("{{data:iframe_duck_creek_policy_aggregate_limit_346}}"));
        await _ui.PressAsync(_locators.AggregateLimit, "Tab");
        await _ui.ClickAsync(_locators.OK);
        // UC0272WaiverOfSubrogation_f430d0Page.WaitOnEndorsementType_0394_f7819aAsync
        await _ui.WaitAsync(_locators.SelectEndorsement0EAB0, "Exists");
        // TBoxWait_7ea9e1Page.WaitForEndorsementToBeCompleted_0395_f7819aAsync
        await Task.Delay(1000);
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0396_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0397_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0398_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // CU0400CoverageForInjuryToLeasedWorkers_0ad435Page.VerifyIfValueEqualsSelect_0406_f7819aAsync
        await _ui.VerifyAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:expected_select_endorsement_value_355}}"), "Value");
        // CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_885163Page.CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_0408_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_356}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement04BD0);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // UC0201AutoOwnerAndOrOperatorExclusion_ff9098Page.UC0201AutoOwnerAndOrOperatorExclusion_0424_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_360}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement34EE3);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.FillAsync(_locators.IFRAMEDuckCreekPolicyExcludedDriver, _data.Resolve("{{data:iframe_duck_creek_policy_excluded_driver_363}}"));
        await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyExcludedDriver, "Tab");
        await _ui.ClickAsync(_locators.OK);
        // UC0272WaiverOfSubrogation_f430d0Page.WaitOnEndorsementType_0441_f7819aAsync
        await _ui.WaitAsync(_locators.SelectEndorsement0EAB0, "Exists");
        // TBoxWait_7ea9e1Page.WaitForEndorsementToBeCompleted_0442_f7819aAsync
        await Task.Delay(1000);
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0443_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0444_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0445_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0490_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0491_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0492_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0537_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0538_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0539_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // CU0400CoverageForInjuryToLeasedWorkers_0ad435Page.VerifyIfValueEqualsSelect_0547_f7819aAsync
        await _ui.VerifyAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:expected_select_endorsement_value_382}}"), "Value");
        // CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_885163Page.CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_0549_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_383}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement04BD0);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // UC0272WaiverOfSubrogation_f430d0Page.UC0272WaiverOfSubrogation_0571_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_387}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement34EE3);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // UC0272WaiverOfSubrogation_f430d0Page.WaitOnEndorsementType_0582_f7819aAsync
        await _ui.WaitAsync(_locators.SelectEndorsement0EAB0, "Exists");
        // TBoxWait_7ea9e1Page.WaitForEndorsementToBeCompleted_0583_f7819aAsync
        await Task.Delay(1000);
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0584_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0585_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0586_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // CU0400CoverageForInjuryToLeasedWorkers_0ad435Page.VerifyIfValueEqualsSelect_0594_f7819aAsync
        await _ui.VerifyAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:expected_select_endorsement_value_398}}"), "Value");
        // CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_885163Page.CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_0596_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_399}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement04BD0);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // UC0274AmendmentOfOtherInsuranceConditionPrimaryAndNonContributory_0c510bPage.UC0274AmendmentOfOtherInsuranceConditionPrimaryAndNonContributory_0619_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_403}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement34EE3);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // UC0272WaiverOfSubrogation_f430d0Page.WaitOnEndorsementType_0629_f7819aAsync
        await _ui.WaitAsync(_locators.SelectEndorsement0EAB0, "Exists");
        // TBoxWait_7ea9e1Page.WaitForEndorsementToBeCompleted_0630_f7819aAsync
        await Task.Delay(1000);
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0631_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0632_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0633_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // CU0400CoverageForInjuryToLeasedWorkers_0ad435Page.VerifyIfValueEqualsSelect_0641_f7819aAsync
        await _ui.VerifyAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:expected_select_endorsement_value_414}}"), "Value");
        // CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_885163Page.CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_0643_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_415}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement04BD0);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // UC1100ExclusionAllHazardsInConnectionWithDesignatedFarmLocation_1916dfPage.UC1100ExclusionAllHazardsInConnectionWithDesignatedFarmLocation_0672_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_419}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement34EE3);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.FillAsync(_locators.IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationS, _data.Resolve("{{data:iframe_duck_creek_policy_address_es_or_description_s_of_designated_farm_location_s_422}}"));
        await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationS, "Tab");
        await _ui.ClickAsync(_locators.OK);
        // UC0272WaiverOfSubrogation_f430d0Page.WaitOnEndorsementType_0676_f7819aAsync
        await _ui.WaitAsync(_locators.SelectEndorsement0EAB0, "Exists");
        // TBoxWait_7ea9e1Page.WaitForEndorsementToBeCompleted_0677_f7819aAsync
        await Task.Delay(1000);
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0678_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0679_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0680_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // CU0400CoverageForInjuryToLeasedWorkers_0ad435Page.VerifyIfValueEqualsSelect_0688_f7819aAsync
        await _ui.VerifyAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:expected_select_endorsement_value_431}}"), "Value");
        // CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_885163Page.CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_0690_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_432}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement04BD0);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // UC1101ExclusionForDesignatedActivitiesOrServices_a4522aPage.UC1101ExclusionForDesignatedActivitiesOrServices_0720_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement63E0E, _data.Resolve("{{data:select_endorsement_436}}"));
        await _ui.PressAsync(_locators.SelectEndorsement63E0E, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement63E0E, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement63E0E, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsementD15B0);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.FillAsync(_locators.NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices, _data.Resolve("{{data:iframe_duck_creek_policy_name_s_or_description_s_and_date_s_of_designated_activities_or_services_439}}"));
        await _ui.PressAsync(_locators.NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices, "Tab");
        await _ui.ClickAsync(_locators.OK);
        // UC0272WaiverOfSubrogation_f430d0Page.WaitOnEndorsementType_0723_f7819aAsync
        await _ui.WaitAsync(_locators.SelectEndorsement0EAB0, "Exists");
        // TBoxWait_7ea9e1Page.WaitForEndorsementToBeCompleted_0724_f7819aAsync
        await Task.Delay(1000);
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0725_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0726_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0727_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // CU0400CoverageForInjuryToLeasedWorkers_0ad435Page.VerifyIfValueEqualsSelect_0735_f7819aAsync
        await _ui.VerifyAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:expected_select_endorsement_value_448}}"), "Value");
        // CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_885163Page.CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_0737_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_449}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement04BD0);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // UC1102ExclusionForDesignatedAnimals_887cefPage.UC1102ExclusionForDesignatedAnimals_0768_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_453}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement34EE3);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.FillAsync(_locators.IFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalS, _data.Resolve("{{data:iframe_duck_creek_policy_name_s_or_description_s_of_designated_animal_s_456}}"));
        await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalS, "Tab");
        await _ui.ClickAsync(_locators.OK);
        // UC0272WaiverOfSubrogation_f430d0Page.WaitOnEndorsementType_0770_f7819aAsync
        await _ui.WaitAsync(_locators.SelectEndorsement0EAB0, "Exists");
        // TBoxWait_7ea9e1Page.WaitForEndorsementToBeCompleted_0771_f7819aAsync
        await Task.Delay(1000);
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0772_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0773_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0774_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // CU0400CoverageForInjuryToLeasedWorkers_0ad435Page.VerifyIfValueEqualsSelect_0782_f7819aAsync
        await _ui.VerifyAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:expected_select_endorsement_value_465}}"), "Value");
        // CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_885163Page.CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_0784_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_466}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement04BD0);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // UC1103ExclusionForDesignatedPremises_ca9da6Page.UC1103ExclusionForDesignatedPremises_0816_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_470}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement34EE3);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.FillAsync(_locators.IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremises, _data.Resolve("{{data:iframe_duck_creek_policy_address_es_or_description_s_of_designated_premises_473}}"));
        await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremises, "Tab");
        await _ui.ClickAsync(_locators.OK);
        // UC0272WaiverOfSubrogation_f430d0Page.WaitOnEndorsementType_0817_f7819aAsync
        await _ui.WaitAsync(_locators.SelectEndorsement0EAB0, "Exists");
        // TBoxWait_7ea9e1Page.WaitForEndorsementToBeCompleted_0818_f7819aAsync
        await Task.Delay(1000);
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0819_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0820_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0821_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0866_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0867_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0868_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0913_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0914_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0915_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0960_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0961_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0962_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_1007_f7819aAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_1008_f7819aAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_1009_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
        // CU0400CoverageForInjuryToLeasedWorkers_0ad435Page.VerifyIfValueEqualsSelect_1017_f7819aAsync
        await _ui.VerifyAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:expected_select_endorsement_value_502}}"), "Value");
        // CU0400CoverageForInjuryToLeasedWorkers_0ad435Page.CU0400CoverageForInjuryToLeasedWorkers_1018_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_503}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement34EE3);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_885163Page.CU0206UtahChangesNoticeOfCancellationForPrivateInvestigatorAgencies_1019_f7819aAsync
        await _ui.FillAsync(_locators.SelectEndorsement0EAB0, _data.Resolve("{{data:select_endorsement_507}}"));
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "CLICK");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Enter");
        await _ui.PressAsync(_locators.SelectEndorsement0EAB0, "Tab");
        await _ui.ClickAsync(_locators.AddEndorsement04BD0);
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.OK);
        // UC0272WaiverOfSubrogation_f430d0Page.WaitOnEndorsementType_1052_f7819aAsync
        await _ui.WaitAsync(_locators.SelectEndorsement0EAB0, "Exists");
        // TBoxWait_7ea9e1Page.WaitForEndorsementToBeCompleted_1053_f7819aAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required underwriting question information
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToUWQuestionsUmbrella_1059_f7819aAsync
        await _ui.ClickAsync(_locators.UWQuestionsUmbrella9F47E);
        await _ui.PressAsync(_locators.UWQuestionsUmbrella9F47E, "LongClick");
        // UWQuestionsUmbrella_783ea2Page.WaitOnUWQuestionsHeadingAndFillOutRequiredFields_1060_f7819aAsync
        await _ui.WaitAsync(_locators.UWQuestionsUmbrellaFF014, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswersB41BE);
        await _ui.WaitAsync(_locators.HaveYouHadAnyLiabilityLossesInTheLast5YearsOnAnyPrimaryOrExcessPolicy, "Equal");
        await _ui.FillAsync(_locators.PleaseProvideWebsiteAddressEs, _data.Resolve("{{data:please_provide_website_address_es_525}}"));
    }

    // Business step: I complete required billing information for billing
    public async Task CompleteRequiredBillingInformationForBillingAsync()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_1061_f7819aAsync
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_1062_f7819aAsync
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_528}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_531}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_535}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_1063_f7819aAsync
        await Task.Delay(1000);
    }

    // Business step: I add notepad comment
    public async Task AddNotepadCommentAsync()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToNotePadScreen_1064_f7819aAsync
        await _ui.ClickAsync(_locators.Notepad);
        // NotePad_055c33Page.AddNotesRemarksToNotePad_1065_f7819aAsync
        await _ui.WaitAsync(_locators.NotepadHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNotesRemarks);
        await _ui.FillAsync(_locators.TextBox, _data.Resolve("Test {B[Product (LOB)]}"));
        await _ui.ClickAsync(_locators.NotePadOK);
    }

    // Business step: I complete required submission information
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_1066_f7819aAsync
        await _ui.WaitAsync(_locators.Submission, "Visible");
        await _ui.ClickAsync(_locators.Submission);
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutRequiredFields_1067_f7819aAsync
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_546}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "CLICK");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.OrderAudit_1068_f7819aAsync
        await _ui.VerifyAsync(_locators.OrderAudit, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutOrderAudit_1069_f7819aAsync
        await _ui.FillAsync(_locators.OrderAudit, _data.Resolve("{{data:order_audit_548}}"));
        await _ui.PressAsync(_locators.OrderAudit, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeSubmissionScreenHeaderExists_1070_f7819aAsync
        await _ui.VerifyAsync(_locators.SubmissionHeading, _data.Resolve("Absent"), "");
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_1071_f7819aAsync
        await _ui.PressAsync(_locators.Submission, "PRE:TAB");
        await _ui.PressAsync(_locators.Submission, "Tab");
        await _ui.ClickAsync(_locators.Submission);
        // TBoxWait_7ea9e1Page.WaitForSynchronization_1072_f7819aAsync
        await Task.Delay(1000);
        // SubmissionRequiredAndOptionalFields_4090a9Page.WaitOnSubmissionScreenToLoad_1073_f7819aAsync
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        // TBoxWait_7ea9e1Page.N500msWaitForSyncing_1074_f7819aAsync
        await Task.Delay(1000);
    }

    // Business step: I complete Underwriting Info from Client Screen
    public async Task CompleteUnderwritingInfoFromClientScreenAsync()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToUnderwritingInfoScreen_0051_515771Async
        await _ui.ClickAsync(_locators.UnderwritingInfo);
        // UnderwritingInfoGeneralUWQuestions_3222c4Page.UnderwritingInfoGeneralUWQuestions_0052_515771Async
        await _ui.WaitAsync(_locators.GeneralUWQuestions, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswers9CB86);
        // UnderwritingInfoOtherInsuranceHistory_b78753Page.AddPriorCarriorDetailsOnLossInformationScreen_0053_515771Async
        await _ui.ClickAsync(_locators.InsuranceHistory);
        await _ui.WaitAsync(_locators.IsThereAPriorCarrier, "Exists");
        await _ui.FillAsync(_locators.IsThereAPriorCarrier, _data.Resolve("{{data:is_there_a_prior_carrier_50}}"));
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Tab");
        await _ui.WaitAsync(_locators.Carrier, "Exists");
        await _ui.FillAsync(_locators.Carrier, _data.Resolve("{{data:carrier_52}}"));
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.FillAsync(_locators.PolicyNumberBA28E, _data.Resolve("{{data:policy_number_53}}"));
        await _ui.PressAsync(_locators.PolicyNumberBA28E, "Tab");
        await _ui.FillAsync(_locators.PolicyType, _data.Resolve("{{data:policy_type_54}}"));
        await _ui.PressAsync(_locators.PolicyType, "Tab");
        await _ui.FillAsync(_locators.EffectiveDateB557F, _data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDateB557F, "Tab");
        await _ui.FillAsync(_locators.ExpirationDate34EAC, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate34EAC, "Tab");
        await _ui.FillAsync(_locators.ModificationFactor, _data.Resolve("{{data:modificationfactor_57}}"));
        await _ui.PressAsync(_locators.ModificationFactor, "Tab");
        await _ui.FillAsync(_locators.TotalPremium, _data.Resolve("{{data:total_premium_58}}"));
        await _ui.PressAsync(_locators.TotalPremium, "Tab");
        await _ui.ClickAsync(_locators.OtherInsuranceHistoryOK);
        await _ui.WaitAsync(_locators.Detail0F8C6, "Exists");
        // UnderwritingInfoLossExperience_54b758Page.IndicateNoKnownLossesOnLossExperienceScreen_0054_515771Async
        await _ui.ClickAsync(_locators.LossExperience);
        await _ui.WaitAsync(_locators.NoKnownLosses, "Exists");
        await _ui.SmartSetAsync(_locators.NoKnownLosses, _data.Resolve("{{data:no_known_losses_63}}"));
        await _ui.PressAsync(_locators.NoKnownLosses, "Tab");
        // CommonNavigationLinks_dba56bPage.ClickReturnToQuote_0055_515771Async
        await _ui.ClickAsync(_locators.ReturnToQuote);
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0056_515771Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_65}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_66}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_67}}"), "value");
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync2()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0057_515771Async
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0058_515771Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0059_515771Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0060_515771Async
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_71}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_72}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0061_515771Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0062_515771Async
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_74}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_78}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0063_515771Async
        _data.Set("StateIsKansas", _data.Resolve("Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'"));
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0065_515771Async
        _data.Set("StateIsVirginia", _data.Resolve("Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0066_515771Async
        if (_data.Condition("'Product (LOB)' == \"GL\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_81}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"GL\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_82}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0067_515771Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0068_515771Async
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_86}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0069_515771Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0070_515771Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AZ GL Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I complete CGL Fields
    public async Task CompleteCGLFieldsAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToPolicyCoverageScreen_0073_515771Async
        await _ui.ClickAsync(_locators.PolicyCovg50C98);
        // PolicyCovgGL_e538c3Page.PolicyCovgGL_0074_515771Async
        await _ui.WaitAsync(_locators.PolicyCovg6B651, "Exists");
        if (_data.Condition("'Coverage Form' != NULL"))
        {
            await _ui.FillAsync(_locators.CoverageForm3B382, _data.Resolve("{{data:coverage_form_98}}"));
            await _ui.PressAsync(_locators.CoverageForm3B382, "CLICK");
            await _ui.PressAsync(_locators.CoverageForm3B382, "Enter");
            await _ui.PressAsync(_locators.CoverageForm3B382, "Tab");
        }
        if (_data.Condition("'Occurence Limit' != NULL"))
        {
            await _ui.FillAsync(_locators.OccurenceLimit, _data.Resolve("{{data:occurence_limit_99}}"));
            await _ui.PressAsync(_locators.OccurenceLimit, "CLICK");
            await _ui.PressAsync(_locators.OccurenceLimit, "Enter");
            await _ui.PressAsync(_locators.OccurenceLimit, "Tab");
        }
        if (_data.Condition("'Aggregate Limit' != NULL"))
        {
            await _ui.FillAsync(_locators.AggregateLimit, _data.Resolve("{{data:aggregate_limit_100}}"));
            await _ui.PressAsync(_locators.AggregateLimit, "CLICK");
            await _ui.PressAsync(_locators.AggregateLimit, "Enter");
            await _ui.PressAsync(_locators.AggregateLimit, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.ProductsAggLimit, _data.Resolve("{{data:products_agg_limit_101}}"));
            await _ui.PressAsync(_locators.ProductsAggLimit, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.DedType, _data.Resolve("{{data:ded_type_102}}"));
            await _ui.PressAsync(_locators.DedType, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.DeductibleBasis, _data.Resolve("{{data:deductible_basis_103}}"));
            await _ui.PressAsync(_locators.DeductibleBasis, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.PremOpDed, _data.Resolve("{{data:premop_ded_104}}"));
            await _ui.PressAsync(_locators.PremOpDed, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.PremOpPDDed, _data.Resolve(""));
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
            await _ui.SmartSetAsync(_locators.SplitBIDed, _data.Resolve("{{data:split_bi_ded_106}}"));
            await _ui.PressAsync(_locators.SplitBIDed, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.SplitPDDed, _data.Resolve(""));
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.ProdBIDed, _data.Resolve("{{data:prod_bi_ded_108}}"));
            await _ui.PressAsync(_locators.ProdBIDed, "CLICK");
            await _ui.PressAsync(_locators.ProdBIDed, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.ProdPDDed, _data.Resolve(""));
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.FireDamage, _data.Resolve("{{data:fire_damage_110}}"));
            await _ui.PressAsync(_locators.FireDamage, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.Medical, _data.Resolve("{{data:medical_111}}"));
            await _ui.PressAsync(_locators.Medical, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.PersAdvInj, _data.Resolve("{{data:pers_adv_inj_112}}"));
            await _ui.PressAsync(_locators.PersAdvInj, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, _data.Resolve("{{data:is_the_insured_engaged_in_any_snow_or_ice_removal_operations_113}}"));
            await _ui.PressAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, "CLICK");
            await _ui.PressAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, "Enter");
            await _ui.PressAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, "Tab");
        }
        if (_data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.OfFullTimeEmployees, _data.Resolve("{{data:of_full_time_employees_114}}"));
            await _ui.PressAsync(_locators.OfFullTimeEmployees, "Tab");
        }
        if (_data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\") ||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.OfPartTimeEmployees, _data.Resolve("{{data:of_part_time_employees_115}}"));
            await _ui.PressAsync(_locators.OfPartTimeEmployees, "Tab");
        }
        if (_data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\") ||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.OfSeasonalTemporaryEmployees, _data.Resolve("{{data:of_seasonal_temporary_employees_116}}"));
            await _ui.PressAsync(_locators.OfSeasonalTemporaryEmployees, "Tab");
        }
        if (_data.Condition("'Coverage Form' != NULL"))
        {
            await _ui.WaitAsync(_locators.CoverageForm3B382, "Equal");
        }
    }

    // Business step: I add Class
    public async Task AddClassAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToCGLScreen_0075_515771Async
        await _ui.ClickAsync(_locators.CGL08901);
        // CGLMainPage_efe3a4Page.CGLMainPage_0076_515771Async
        await _ui.WaitAsync(_locators.CGLBA8E8, "Exists");
        await _ui.ClickAsync(_locators.AddClassB04B6);
        // CGLAddClass_42221ePage.CGLAddClass_0077_515771Async
        await _ui.FillAsync(_locators.SearchResults5209C, _data.Resolve("{{data:search_results_121}}"));
        await _ui.PressAsync(_locators.SearchResults5209C, "Tab");
        await _ui.ClickAsync(_locators.AddClassOK);
        // CGLMainPage_efe3a4Page.CGLAddClassExposure_0078_515771Async
        await _ui.FillAsync(_locators.Exposure, _data.Resolve("{{data:exposure_123}}"));
        await _ui.PressAsync(_locators.Exposure, "Tab");
        await _ui.ClickAsync(_locators.MainPageOK);
    }

    // Business step: I add \[CG0435\] Employee Benefits Liability Endorsement
    public async Task AddCG0435EmployeeBenefitsLiabilityEndorsementAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToEndorsementsScreen_0079_515771Async
        if (_data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
            await _ui.ClickAsync(_locators.Endorsements7572E);
        }
        // EndorsementsMain_a2a05aPage.EndorsementsMain_0080_515771Async
        await _ui.WaitAsync(_locators.Endorsements9626E, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsementA9973);
        // CG0435EmployeeBenefitsLiability_f2059fPage.AddCG0435EmployeeBenefitsLiabilityEndorsement_0081_515771Async
        await _ui.FillAsync(_locators.EndorsementTypeA2928, _data.Resolve("{{data:endorsement_type_128}}"));
        await _ui.PressAsync(_locators.EndorsementTypeA2928, "Tab");
        await _ui.FillAsync(_locators.NumberOfEmployees, _data.Resolve("{{data:number_of_employees_129}}"));
        await _ui.PressAsync(_locators.NumberOfEmployees, "Tab");
        await _ui.ClickAsync(_locators.CG0435EmployeeBenefitsLiabilityOK);
    }

    // Business step: I add \[CG2142\] Exclusion \- Explosion, Collapse and Underground Property Damage Hazard \(Specified Operations\)
    public async Task AddCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToEndorsementsScreen_0082_515771Async
        if (_data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
            await _ui.ClickAsync(_locators.Endorsements7572E);
        }
        // EndorsementsMain_a2a05aPage.EndorsementsMain_0083_515771Async
        await _ui.WaitAsync(_locators.Endorsements9626E, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsementA9973);
        // CG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperations_00e769Page.AddCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsEndorsement_0084_515771Async
        await _ui.FillAsync(_locators.EndorsementTypeB210C, _data.Resolve("{{data:endorsement_type_134}}"));
        await _ui.PressAsync(_locators.EndorsementTypeB210C, "Tab");
        await _ui.SmartSetAsync(_locators.ExcludeExplosionHazard, _data.Resolve("{{data:exclude_explosion_hazard_135}}"));
        await _ui.PressAsync(_locators.ExcludeExplosionHazard, "Tab");
        await _ui.SmartSetAsync(_locators.ExcludeCollapseHazard, _data.Resolve("{{data:exclude_collapse_hazard_136}}"));
        await _ui.PressAsync(_locators.ExcludeCollapseHazard, "Tab");
        await _ui.SmartSetAsync(_locators.ExcludeUndergroundPropertyDamageHazard, _data.Resolve("{{data:exclude_underground_property_damage_hazard_137}}"));
        await _ui.PressAsync(_locators.ExcludeUndergroundPropertyDamageHazard, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfOperationS, _data.Resolve("{{data:description_of_operation_s_138}}"));
        await _ui.PressAsync(_locators.DescriptionOfOperationS, "Tab");
        if (_data.Condition("State != \"VA\""))
        {
            await _ui.ClickAsync(_locators.CG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsOK);
        }
    }

    // Business step: I add \[CG 2149\] Total Pollution Exclusion Endorsement
    public async Task AddCG2149TotalPollutionExclusionEndorsementAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToEndorsementsScreen_0085_515771Async
        if (_data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
            await _ui.ClickAsync(_locators.Endorsements7572E);
        }
        // EndorsementsMain_a2a05aPage.EndorsementsMain_0086_515771Async
        await _ui.WaitAsync(_locators.Endorsements9626E, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsementA9973);
        // CG2149TotalPollutionExclusionEndorsement_500b4fPage.AddCG2149TotalPollutionExclusionEndorsement_0087_515771Async
        await _ui.FillAsync(_locators.EndorsementTypeD83A4, _data.Resolve("{{data:endorsement_type_143}}"));
        await _ui.PressAsync(_locators.EndorsementTypeD83A4, "Tab");
        await _ui.ClickAsync(_locators.CG2149TotalPollutionExclusionEndorsementOK);
    }

    // Business step: I add Addl Interest \[CG2007\] \- Engineers
    public async Task AddAddlInterestCG2007EngineersAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToAddlInterestsScreen_0090_515771Async
        await _ui.ClickAsync(_locators.AddlInterestsE39FC);
        // AddlInterestsMain_75443cPage.SelectAddlInterestsButton_0091_515771Async
        await _ui.WaitAsync(_locators.AddlInterestsA10A4, "Exists");
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // CG2007AddLInsuredEngineersArchitects_cacd4ePage.AddCG2007AddLInsuredEngineersArchitects_0092_515771Async
        if (_data.Condition("Type != NULL"))
        {
            await _ui.WaitAsync(_locators.TypeD0639, "Exists");
        }
        await _ui.ClickAsync(_locators.CG2007AddLInsuredEngineersArchitectsOK);
        if (_data.Condition("Type != NULL"))
        {
            await _ui.ClickAsync(_locators.TypeD0639);
        }
        if (_data.Condition("Type != NULL"))
        {
            await _ui.FillAsync(_locators.TypeD0639, _data.Resolve("{{data:type_159}}"));
            await _ui.PressAsync(_locators.TypeD0639, "Enter");
            await _ui.PressAsync(_locators.TypeD0639, "Tab");
        }
    }

    // Business step: I add Addl Interest \[CG2020\] Add'l Insured\-Charitable Institution
    public async Task AddAddlInterestCG2020AddLInsuredCharitableInstitutionAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToAddlInterestsScreen_0093_515771Async
        await _ui.ClickAsync(_locators.AddlInterestsE39FC);
        // AddlInterestsMain_75443cPage.SelectAddlInterestsButton_0094_515771Async
        await _ui.WaitAsync(_locators.AddlInterestsA10A4, "Exists");
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // CG2020AddLInsuredCharitableInstitution_e6edeePage.AddCG2020AddLInsuredCharitableInstitution_0095_515771Async
        if (_data.Condition("Type != NULL"))
        {
            await _ui.FillAsync(_locators.TypeA75B5, _data.Resolve("{{data:type_163}}"));
            await _ui.PressAsync(_locators.TypeA75B5, "Tab");
        }
        if (_data.Condition("'Type of License' != NULL"))
        {
            await _ui.FillAsync(_locators.TypeOfLicense, _data.Resolve("{{data:type_of_license_164}}"));
            await _ui.PressAsync(_locators.TypeOfLicense, "Tab");
            await _ui.PressAsync(_locators.TypeOfLicense, "CLICK");
            await _ui.PressAsync(_locators.TypeOfLicense, "Tab");
        }
        await _ui.ClickAsync(_locators.CG2020AddLInsuredCharitableInstitutionOK);
    }

    // Business step: I add Addl Interest \[CG2023\] Add'l Insured\-Executors
    public async Task AddAddlInterestCG2023AddLInsuredExecutorsAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToAddlInterestsScreen_0096_515771Async
        await _ui.ClickAsync(_locators.AddlInterestsE39FC);
        // AddlInterestsMain_75443cPage.SelectAddlInterestsButton_0097_515771Async
        await _ui.WaitAsync(_locators.AddlInterestsA10A4, "Exists");
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // CG2023AddLInsuredExecutors_a048ecPage.AddCG2023AddLInsuredExecutors_0098_515771Async
        if (_data.Condition("Type != NULL"))
        {
            await _ui.FillAsync(_locators.TypeD972C, _data.Resolve("{{data:type_169}}"));
            await _ui.PressAsync(_locators.TypeD972C, "Tab");
        }
        await _ui.ClickAsync(_locators.OK);
    }

    // Business step: I add Addl Interest \[CG2025\] Add'l Insured\-Executive Officers
    public async Task AddAddlInterestCG2025AddLInsuredExecutiveOfficersAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToAddlInterestsScreen_0099_515771Async
        await _ui.ClickAsync(_locators.AddlInterestsE39FC);
        // AddlInterestsMain_75443cPage.SelectAddlInterestsButton_0100_515771Async
        await _ui.WaitAsync(_locators.AddlInterestsA10A4, "Exists");
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // CG2025AddLInsuredExecutiveOfficers_fa3c1aPage.AddCG2025AddLInsuredExecutiveOfficers_0101_515771Async
        if (_data.Condition("Type != NULL"))
        {
            await _ui.FillAsync(_locators.TypeD972C, _data.Resolve("{{data:type_174}}"));
            await _ui.PressAsync(_locators.TypeD972C, "Tab");
        }
        await _ui.ClickAsync(_locators.OK);
    }

    // Business step: I add Addl Interest \[CG2034\] Add'l Insured\-Leased Equipment Automatic
    public async Task AddAddlInterestCG2034AddLInsuredLeasedEquipmentAutomaticAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToAddlInterestsScreen_0102_515771Async
        await _ui.ClickAsync(_locators.AddlInterestsE39FC);
        // AddlInterestsMain_75443cPage.SelectAddlInterestsButton_0103_515771Async
        await _ui.WaitAsync(_locators.AddlInterestsA10A4, "Exists");
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // CG2034AddLInsuredLeasedEquipmentAutomatic_7d6157Page.AddCG2034AddLInsuredLeasedEquipmentAutomatic_0104_515771Async
        if (_data.Condition("Type != NULL"))
        {
            await _ui.FillAsync(_locators.TypeD972C, _data.Resolve("{{data:type_179}}"));
            await _ui.PressAsync(_locators.TypeD972C, "Tab");
        }
        if (_data.Condition("'Type of Equipment' != NULL"))
        {
            await _ui.FillAsync(_locators.TypeOfEquipment, _data.Resolve("{{data:type_of_equipment_180}}"));
            await _ui.PressAsync(_locators.TypeOfEquipment, "CLICK");
            await _ui.PressAsync(_locators.TypeOfEquipment, "Tab");
        }
        await _ui.ClickAsync(_locators.OK);
    }

    // Business step: I add notepad comment
    public async Task AddNotepadCommentAsync2()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToNotePadScreen_0105_515771Async
        await _ui.ClickAsync(_locators.Notepad);
        // NotePad_055c33Page.AddNotesRemarksToNotePad_0106_515771Async
        await _ui.WaitAsync(_locators.NotepadHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNotesRemarks);
        await _ui.FillAsync(_locators.TextBox, _data.Resolve("Test {B[Product (LOB)]}"));
        await _ui.ClickAsync(_locators.NotePadOK);
    }

    // Business step: I answer GL UW Questions OR \& WA
    public async Task AnswerGLUWQuestionsORWAAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToGLUWQuestions_0107_515771Async
        await _ui.ClickAsync(_locators.GLUWQuestions);
        // GeneralLiabilityInformation_459030Page.AnswerGeneralLiabilityInformationQuestions_0108_515771Async
        await _ui.WaitAsync(_locators.GeneralLiabilityInformation, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswersFB765);
        await _ui.FillAsync(_locators.DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy, _data.Resolve("{{data:describe_all_hold_harmless_agreements_and_please_provide_a_copy_190}}"));
        await _ui.PressAsync(_locators.DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy, "Tab");
        await _ui.PressAsync(_locators.DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy, "Tab");
        await _ui.ClickAsync(_locators.GeneralLiabilityInformationOK);
        // GLNavigationLinks_6f2588Page.NavigateToGLUWQuestions_0109_515771Async
        await _ui.ClickAsync(_locators.GLUWQuestions);
        // GeneralLiabilityInformation_459030Page.WaitForGeneralLiabilityScreenToLoad_0110_515771Async
        await _ui.WaitAsync(_locators.GeneralLiabilityInformation, "Exists");
        // ProductsCompletedOps_e712ddPage.AnswerProductsCompletedOpsQuestion_0111_515771Async
        await _ui.ClickAsync(_locators.ProductsCompletedOpsButton);
        await _ui.WaitAsync(_locators.ProductsCompletedOps, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswers69564);
        await _ui.ClickAsync(_locators.ProductsCompletedOpsOK);
    }

    // Business step: I complete required billing information
    public async Task CompleteRequiredBillingInformationAsync2()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0112_515771Async
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0113_515771Async
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_200}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_203}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_207}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0114_515771Async
        await Task.Delay(1000);
    }

    // Business step: I complete required submission information
    public async Task CompleteRequiredSubmissionInformationAsync2()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0115_515771Async
        await _ui.WaitAsync(_locators.Submission, "Visible");
        await _ui.ClickAsync(_locators.Submission);
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutRequiredFields_0116_515771Async
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_213}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "CLICK");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.OrderAudit_0117_515771Async
        await _ui.VerifyAsync(_locators.OrderAudit, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutOrderAudit_0118_515771Async
        await _ui.FillAsync(_locators.OrderAudit, _data.Resolve("{{data:order_audit_215}}"));
        await _ui.PressAsync(_locators.OrderAudit, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeSubmissionScreenHeaderExists_0119_515771Async
        await _ui.VerifyAsync(_locators.SubmissionHeading, _data.Resolve("Absent"), "");
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0120_515771Async
        await _ui.PressAsync(_locators.Submission, "PRE:TAB");
        await _ui.PressAsync(_locators.Submission, "Tab");
        await _ui.ClickAsync(_locators.Submission);
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0121_515771Async
        await Task.Delay(1000);
        // SubmissionRequiredAndOptionalFields_4090a9Page.WaitOnSubmissionScreenToLoad_0122_515771Async
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        // TBoxWait_7ea9e1Page.N500msWaitForSyncing_0123_515771Async
        await Task.Delay(1000);
    }

    // Business step: I complete Underwriting Info from Client Screen
    public async Task CompleteUnderwritingInfoFromClientScreenAsync2()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToUnderwritingInfoScreen_0051_d65717Async
        await _ui.ClickAsync(_locators.UnderwritingInfo);
        // UnderwritingInfoGeneralUWQuestions_3222c4Page.UnderwritingInfoGeneralUWQuestions_0052_d65717Async
        await _ui.WaitAsync(_locators.GeneralUWQuestions, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswers9CB86);
        // UnderwritingInfoOtherInsuranceHistory_b78753Page.AddPriorCarriorDetailsOnLossInformationScreen_0053_d65717Async
        await _ui.ClickAsync(_locators.InsuranceHistory);
        await _ui.WaitAsync(_locators.IsThereAPriorCarrier, "Exists");
        await _ui.FillAsync(_locators.IsThereAPriorCarrier, _data.Resolve("{{data:is_there_a_prior_carrier_50}}"));
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Tab");
        await _ui.WaitAsync(_locators.Carrier, "Exists");
        await _ui.FillAsync(_locators.Carrier, _data.Resolve("{{data:carrier_52}}"));
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.FillAsync(_locators.PolicyNumberBA28E, _data.Resolve("{{data:policy_number_53}}"));
        await _ui.PressAsync(_locators.PolicyNumberBA28E, "Tab");
        await _ui.FillAsync(_locators.PolicyType, _data.Resolve("{{data:policy_type_54}}"));
        await _ui.PressAsync(_locators.PolicyType, "Tab");
        await _ui.FillAsync(_locators.EffectiveDateB557F, _data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDateB557F, "Tab");
        await _ui.FillAsync(_locators.ExpirationDate34EAC, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate34EAC, "Tab");
        await _ui.FillAsync(_locators.ModificationFactor, _data.Resolve("{{data:modificationfactor_57}}"));
        await _ui.PressAsync(_locators.ModificationFactor, "Tab");
        await _ui.FillAsync(_locators.TotalPremium, _data.Resolve("{{data:total_premium_58}}"));
        await _ui.PressAsync(_locators.TotalPremium, "Tab");
        await _ui.ClickAsync(_locators.OtherInsuranceHistoryOK);
        await _ui.WaitAsync(_locators.Detail0F8C6, "Exists");
        // UnderwritingInfoLossExperience_54b758Page.IndicateNoKnownLossesOnLossExperienceScreen_0054_d65717Async
        await _ui.ClickAsync(_locators.LossExperience);
        await _ui.WaitAsync(_locators.NoKnownLosses, "Exists");
        await _ui.SmartSetAsync(_locators.NoKnownLosses, _data.Resolve("{{data:no_known_losses_63}}"));
        await _ui.PressAsync(_locators.NoKnownLosses, "Tab");
        // CommonNavigationLinks_dba56bPage.ClickReturnToQuote_0055_d65717Async
        await _ui.ClickAsync(_locators.ReturnToQuote);
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0056_d65717Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_65}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_66}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_67}}"), "value");
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync3()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0057_d65717Async
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0058_d65717Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0059_d65717Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0060_d65717Async
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_71}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0061_d65717Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0062_d65717Async
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_73}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_77}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0063_d65717Async
        _data.Set("StateIsKansas", _data.Resolve("Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'"));
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0065_d65717Async
        _data.Set("StateIsVirginia", _data.Resolve("Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0066_d65717Async
        if (_data.Condition("'Product (LOB)' == \"GL OCP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_80}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"GL OCP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_81}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0067_d65717Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0068_d65717Async
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_85}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        if (_data.Condition("'Product (LOB)' == \"SFP\"||'Product (LOB)' == \"GL OCP\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_89}}"));
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0069_d65717Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0070_d65717Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AZ GL OCP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I complete OCP Fields
    public async Task CompleteOCPFieldsAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToPolicyCoverageScreen_0073_d65717Async
        await _ui.ClickAsync(_locators.PolicyCovg50C98);
        // PolicyCovgGL_e538c3Page.PolicyCovgOCP_0074_d65717Async
        await _ui.WaitAsync(_locators.PolicyCovg6B651, "Exists");
        if (_data.Condition("'Coverage Form' != NULL"))
        {
            await _ui.FillAsync(_locators.CoverageForm3B382, _data.Resolve("{{data:coverage_form_98}}"));
            await _ui.PressAsync(_locators.CoverageForm3B382, "CLICK");
            await _ui.PressAsync(_locators.CoverageForm3B382, "Enter");
            await _ui.PressAsync(_locators.CoverageForm3B382, "Tab");
        }
        if (_data.Condition("'Occurence Limit' != NULL"))
        {
            await _ui.FillAsync(_locators.OccurenceLimit, _data.Resolve("{{data:occurence_limit_99}}"));
            await _ui.PressAsync(_locators.OccurenceLimit, "CLICK");
            await _ui.PressAsync(_locators.OccurenceLimit, "Enter");
            await _ui.PressAsync(_locators.OccurenceLimit, "Tab");
        }
        if (_data.Condition("'Aggregate Limit' != NULL"))
        {
            await _ui.FillAsync(_locators.AggregateLimit, _data.Resolve("{{data:aggregate_limit_100}}"));
            await _ui.PressAsync(_locators.AggregateLimit, "CLICK");
            await _ui.PressAsync(_locators.AggregateLimit, "Enter");
            await _ui.PressAsync(_locators.AggregateLimit, "Tab");
        }
        if (_data.Condition("(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.OfFullTimeEmployees, _data.Resolve(""));
        }
        if (_data.Condition("(State == \"NJ\")||(State == \"WV\")||(State == \"MA\") ||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.OfPartTimeEmployees, _data.Resolve(""));
        }
        if (_data.Condition("(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\") ||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
            await _ui.FillAsync(_locators.OfSeasonalTemporaryEmployees, _data.Resolve(""));
        }
        if (_data.Condition("'Coverage Form' != NULL"))
        {
            await _ui.WaitAsync(_locators.CoverageForm3B382, "Equal");
        }
    }

    // Business step: I complete OCP Risk Fields
    public async Task CompleteOCPRiskFieldsAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToOCPScreen_0075_d65717Async
        await _ui.ClickAsync(_locators.OCP);
        // GLOCPRisk_e6cba8Page.GLOCPRisk_0076_d65717Async
        await _ui.WaitAsync(_locators.RiskHeading, "Exists");
        await _ui.FillAsync(_locators.Type885AA, _data.Resolve("{{data:type_107}}"));
        await _ui.PressAsync(_locators.Type885AA, "CLICK");
        await _ui.PressAsync(_locators.Type885AA, "Enter");
        await _ui.PressAsync(_locators.Type885AA, "Tab");
        await _ui.FillAsync(_locators.ClassCode, _data.Resolve("{{data:class_code_108}}"));
        await _ui.PressAsync(_locators.ClassCode, "CLICK");
        await _ui.PressAsync(_locators.ClassCode, "Tab");
        await _ui.PressAsync(_locators.ClassCode, "Tab");
        await _ui.FillAsync(_locators.State16B92, _data.Resolve("{{data:state_109}}"));
        await _ui.PressAsync(_locators.State16B92, "Tab");
        await _ui.PressAsync(_locators.State16B92, "Tab");
        await _ui.FillAsync(_locators.TotalCostOfWork, _data.Resolve("{{data:total_cost_of_work_110}}"));
        await _ui.PressAsync(_locators.TotalCostOfWork, "Tab");
        await _ui.PressAsync(_locators.TotalCostOfWork, "Tab");
        await _ui.FillAsync(_locators.LocationOfCoveredOperations, _data.Resolve("{{data:location_of_covered_operations_111}}"));
        await _ui.PressAsync(_locators.LocationOfCoveredOperations, "Tab");
        await _ui.PressAsync(_locators.LocationOfCoveredOperations, "Tab");
        await _ui.FillAsync(_locators.PolicyHolderName, _data.Resolve("{{data:policy_holder_name_112}}"));
        await _ui.PressAsync(_locators.PolicyHolderName, "Tab");
        await _ui.PressAsync(_locators.PolicyHolderName, "Tab");
        await _ui.FillAsync(_locators.Address1BE797, _data.Resolve("{{data:address_1_113}}"));
        await _ui.PressAsync(_locators.Address1BE797, "Tab");
        await _ui.PressAsync(_locators.Address1BE797, "Tab");
        await _ui.FillAsync(_locators.ZipCodeC7591, _data.Resolve("{{data:zip_code_114}}"));
        await _ui.PressAsync(_locators.ZipCodeC7591, "Tab");
        await _ui.PressAsync(_locators.ZipCodeC7591, "CLICK");
        await _ui.PressAsync(_locators.ZipCodeC7591, "Tab");
        // CommonNavigationLinks_dba56bPage.SelectNextButton_0077_d65717Async
        await _ui.ClickAsync(_locators.CommonNavigationLinksNext);
        // GLNavigationLinks_6f2588Page.NavigateToOCPScreen_0078_d65717Async
        await _ui.ClickAsync(_locators.OCP);
        // GLOCPRisk_e6cba8Page.GLOCPRisk_0079_d65717Async
        await _ui.WaitAsync(_locators.RiskHeading, "Exists");
        await _ui.FillAsync(_locators.Type885AA, _data.Resolve("{{data:type_118}}"));
        await _ui.PressAsync(_locators.Type885AA, "CLICK");
        await _ui.PressAsync(_locators.Type885AA, "Enter");
        await _ui.PressAsync(_locators.Type885AA, "Tab");
        await _ui.FillAsync(_locators.ClassCode, _data.Resolve("{{data:class_code_119}}"));
        await _ui.PressAsync(_locators.ClassCode, "CLICK");
        await _ui.PressAsync(_locators.ClassCode, "Tab");
        await _ui.PressAsync(_locators.ClassCode, "Tab");
        await _ui.FillAsync(_locators.State16B92, _data.Resolve("{{data:state_120}}"));
        await _ui.PressAsync(_locators.State16B92, "Tab");
        await _ui.PressAsync(_locators.State16B92, "Tab");
        await _ui.FillAsync(_locators.TotalCostOfWork, _data.Resolve(""));
        await _ui.FillAsync(_locators.LocationOfCoveredOperations, _data.Resolve("{{data:location_of_covered_operations_122}}"));
        await _ui.PressAsync(_locators.LocationOfCoveredOperations, "Tab");
        await _ui.PressAsync(_locators.LocationOfCoveredOperations, "Tab");
        await _ui.FillAsync(_locators.PolicyHolderName, _data.Resolve("{{data:policy_holder_name_123}}"));
        await _ui.PressAsync(_locators.PolicyHolderName, "Tab");
        await _ui.PressAsync(_locators.PolicyHolderName, "Tab");
        await _ui.FillAsync(_locators.Address1BE797, _data.Resolve("{{data:address_1_124}}"));
        await _ui.PressAsync(_locators.Address1BE797, "Tab");
        await _ui.PressAsync(_locators.Address1BE797, "Tab");
        await _ui.FillAsync(_locators.ZipCodeC7591, _data.Resolve("{{data:zip_code_125}}"));
        await _ui.PressAsync(_locators.ZipCodeC7591, "Tab");
        await _ui.PressAsync(_locators.ZipCodeC7591, "CLICK");
        await _ui.PressAsync(_locators.ZipCodeC7591, "Tab");
        // CommonNavigationLinks_dba56bPage.SelectNextButton_0080_d65717Async
        await _ui.ClickAsync(_locators.CommonNavigationLinksNext);
        // GLNavigationLinks_6f2588Page.NavigateToOCPScreen_0081_d65717Async
        await _ui.ClickAsync(_locators.OCP);
        // GLOCPRisk_e6cba8Page.GLOCPRisk_0082_d65717Async
        await _ui.WaitAsync(_locators.RiskHeading, "Exists");
        await _ui.FillAsync(_locators.Type885AA, _data.Resolve("{{data:type_129}}"));
        await _ui.PressAsync(_locators.Type885AA, "CLICK");
        await _ui.PressAsync(_locators.Type885AA, "Enter");
        await _ui.PressAsync(_locators.Type885AA, "Tab");
        await _ui.FillAsync(_locators.ClassCode, _data.Resolve("{{data:class_code_130}}"));
        await _ui.PressAsync(_locators.ClassCode, "CLICK");
        await _ui.PressAsync(_locators.ClassCode, "Tab");
        await _ui.PressAsync(_locators.ClassCode, "Tab");
        await _ui.FillAsync(_locators.State16B92, _data.Resolve("{{data:state_131}}"));
        await _ui.PressAsync(_locators.State16B92, "Tab");
        await _ui.PressAsync(_locators.State16B92, "Tab");
        await _ui.FillAsync(_locators.TotalCostOfWork, _data.Resolve(""));
        await _ui.FillAsync(_locators.LocationOfCoveredOperations, _data.Resolve("{{data:location_of_covered_operations_133}}"));
        await _ui.PressAsync(_locators.LocationOfCoveredOperations, "Tab");
        await _ui.PressAsync(_locators.LocationOfCoveredOperations, "Tab");
        await _ui.FillAsync(_locators.PolicyHolderName, _data.Resolve("{{data:policy_holder_name_134}}"));
        await _ui.PressAsync(_locators.PolicyHolderName, "Tab");
        await _ui.PressAsync(_locators.PolicyHolderName, "Tab");
        await _ui.FillAsync(_locators.Address1BE797, _data.Resolve("{{data:address_1_135}}"));
        await _ui.PressAsync(_locators.Address1BE797, "Tab");
        await _ui.PressAsync(_locators.Address1BE797, "Tab");
        await _ui.FillAsync(_locators.ZipCodeC7591, _data.Resolve("{{data:zip_code_136}}"));
        await _ui.PressAsync(_locators.ZipCodeC7591, "Tab");
        await _ui.PressAsync(_locators.ZipCodeC7591, "CLICK");
        await _ui.PressAsync(_locators.ZipCodeC7591, "Tab");
        // CommonNavigationLinks_dba56bPage.SelectNextButton_0083_d65717Async
        await _ui.ClickAsync(_locators.CommonNavigationLinksNext);
    }

    // Business step: I complete \[CG0424\] Coverage for Injury to Leased Workers
    public async Task CompleteCG0424CoverageForInjuryToLeasedWorkersAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToEndorsementsScreen_0084_d65717Async
        await _ui.ClickAsync(_locators.Endorsements7572E);
        // EndorsementsMain_a2a05aPage.EndorsementsMain_0085_d65717Async
        await _ui.WaitAsync(_locators.Endorsements9626E, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsementA9973);
        // CG0424CoverageForInjuryToLeasedWorkers_e1a960Page.CG0424CoverageForInjuryToLeasedWorkers_0086_d65717Async
        if (_data.Condition("'Endorsement Type' != NULL"))
        {
            await _ui.FillAsync(_locators.EndorsementTypeCE99F, _data.Resolve("{{data:endorsement_type_141}}"));
            await _ui.PressAsync(_locators.EndorsementTypeCE99F, "Tab");
            await _ui.PressAsync(_locators.EndorsementTypeCE99F, "Tab");
        }
        await _ui.FillAsync(_locators.WhyIsThisCoverageDesired, _data.Resolve("{{data:why_is_this_coverage_desired_142}}"));
        await _ui.PressAsync(_locators.WhyIsThisCoverageDesired, "Tab");
        await _ui.PressAsync(_locators.WhyIsThisCoverageDesired, "Tab");
        await _ui.ClickAsync(_locators.CG0424CoverageForInjuryToLeasedWorkersOK);
    }

    // Business step: I complete \[CG2401\] Non\-Binding Arbitration
    public async Task CompleteCG2401NonBindingArbitrationAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToEndorsementsScreen_0087_d65717Async
        await _ui.ClickAsync(_locators.Endorsements7572E);
        // EndorsementsMain_a2a05aPage.EndorsementsMain_0088_d65717Async
        await _ui.WaitAsync(_locators.Endorsements9626E, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsementA9973);
        // CG2401NonBindingArbitration_265bcaPage.CG2401NonBindingArbitration_0089_d65717Async
        if (_data.Condition("'Endorsement Type' != NULL"))
        {
            await _ui.FillAsync(_locators.EndorsementType3503E, _data.Resolve("{{data:endorsement_type_147}}"));
            await _ui.PressAsync(_locators.EndorsementType3503E, "Tab");
            await _ui.PressAsync(_locators.EndorsementType3503E, "Tab");
        }
        await _ui.ClickAsync(_locators.CG2401NonBindingArbitrationOK);
    }

    // Business step: I complete \[CG2812\] Pesticide or Herbicide Applicator Coverage
    public async Task CompleteCG2812PesticideOrHerbicideApplicatorCoverageAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToEndorsementsScreen_0090_d65717Async
        await _ui.ClickAsync(_locators.Endorsements7572E);
        // EndorsementsMain_a2a05aPage.EndorsementsMain_0091_d65717Async
        await _ui.WaitAsync(_locators.Endorsements9626E, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsementA9973);
        // CG2812PesticideOrHerbicideApplicatorCoverage_284620Page.CG2812PesticideOrHerbicideApplicatorCoverage_0092_d65717Async
        if (_data.Condition("'Endorsement Type' != NULL"))
        {
            await _ui.FillAsync(_locators.EndorsementTypeC75E4, _data.Resolve("{{data:endorsement_type_152}}"));
            await _ui.PressAsync(_locators.EndorsementTypeC75E4, "Tab");
            await _ui.PressAsync(_locators.EndorsementTypeC75E4, "Tab");
        }
        await _ui.FillAsync(_locators.DescriptionOfOperations, _data.Resolve("{{data:description_of_operations_153}}"));
        await _ui.PressAsync(_locators.DescriptionOfOperations, "Tab");
        await _ui.PressAsync(_locators.DescriptionOfOperations, "Tab");
        await _ui.ClickAsync(_locators.CG2812PesticideOrHerbicideApplicatorCoverageOK);
    }

    // Business step: I complete \[CG 20 31\] Add'l Insured\-Engineers, Architects OCP
    public async Task CompleteCG2031AddLInsuredEngineersArchitectsOCPAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToAddlInterestsScreen_0096_d65717Async
        await _ui.ClickAsync(_locators.AddlInterestsE39FC);
        // AddlInterestsMain_75443cPage.AddlInterestsMain_0097_d65717Async
        await _ui.WaitAsync(_locators.AddlInterestsA10A4, "Exists");
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // CG2031AddLInsuredEngineersArchitectsOCP_c1610bPage.CG2031AddLInsuredEngineersArchitectsOCP_0098_d65717Async
        await _ui.FillAsync(_locators.TypeD972C, _data.Resolve("{{data:type_163}}"));
        await _ui.PressAsync(_locators.TypeD972C, "Tab");
        await _ui.PressAsync(_locators.TypeD972C, "Tab");
        await _ui.ClickAsync(_locators.OK);
    }

    // Business step: I complete \[CG 29 35\] Add'l Insured\-State or Political \(Permits\)
    public async Task CompleteCG2935AddLInsuredStateOrPoliticalPermitsAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToAddlInterestsScreen_0099_d65717Async
        await _ui.ClickAsync(_locators.AddlInterestsE39FC);
        // AddlInterestsMain_75443cPage.AddlInterestsMain_0100_d65717Async
        await _ui.WaitAsync(_locators.AddlInterestsA10A4, "Exists");
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // CG2935AddLInsuredStateOrPoliticalPermits_932a9ePage.CG2935AddLInsuredStateOrPoliticalPermits_0101_d65717Async
        await _ui.FillAsync(_locators.TypeCDE3B, _data.Resolve("{{data:type_168}}"));
        await _ui.PressAsync(_locators.TypeCDE3B, "Tab");
        await _ui.PressAsync(_locators.TypeCDE3B, "Tab");
        await _ui.FillAsync(_locators.StateOrPoliticalSubdivision, _data.Resolve("{{data:state_or_political_subdivision_169}}"));
        await _ui.PressAsync(_locators.StateOrPoliticalSubdivision, "Tab");
        await _ui.PressAsync(_locators.StateOrPoliticalSubdivision, "Tab");
        await _ui.FillAsync(_locators.Address19B8B5, _data.Resolve("{{data:address_1_170}}"));
        await _ui.PressAsync(_locators.Address19B8B5, "Tab");
        await _ui.PressAsync(_locators.Address19B8B5, "Tab");
        await _ui.FillAsync(_locators.ZipCodeC048F, _data.Resolve("{{data:zip_code_171}}"));
        await _ui.PressAsync(_locators.ZipCodeC048F, "Tab");
        await _ui.PressAsync(_locators.ZipCodeC048F, "Tab");
        await _ui.ClickAsync(_locators.CG2935AddLInsuredStateOrPoliticalPermitsOK);
    }

    // Business step: I complete \[FG0013\] \- Automatic Additional Insured \- Specific
    public async Task CompleteFG0013AutomaticAdditionalInsuredSpecificAsync()
    {
        // GLNavigationLinks_6f2588Page.NavigateToAddlInterestsScreen_0102_d65717Async
        await _ui.ClickAsync(_locators.AddlInterestsE39FC);
        // AddlInterestsMain_75443cPage.AddlInterestsMain_0103_d65717Async
        await _ui.WaitAsync(_locators.AddlInterestsA10A4, "Exists");
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // FG0013AutomaticAdditionalInsuredSpecificRelationship_31a5ffPage.FG0013AutomaticAdditionalInsuredSpecificRelationship_0104_d65717Async
        await _ui.FillAsync(_locators.Type56F72, _data.Resolve("{{data:type_176}}"));
        await _ui.PressAsync(_locators.Type56F72, "Tab");
        await _ui.PressAsync(_locators.Type56F72, "Tab");
        await _ui.FillAsync(_locators.DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy, _data.Resolve("{{data:does_the_insured_ever_enter_into_contracts_for_tasks_not_contemplated_in_the_current_liability_classifications_on_the_policy_177}}"));
        await _ui.PressAsync(_locators.DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy, "Tab");
        await _ui.PressAsync(_locators.DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy, "Tab");
        await _ui.FillAsync(_locators.IfYesExplain, _data.Resolve("{{data:if_yes_explain_178}}"));
        await _ui.PressAsync(_locators.IfYesExplain, "Tab");
        await _ui.PressAsync(_locators.IfYesExplain, "Tab");
        await _ui.FillAsync(_locators.DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement, _data.Resolve("{{data:does_the_insured_applicant_request_additional_insured_status_without_a_written_contract_requirement_179}}"));
        await _ui.PressAsync(_locators.DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement, "Tab");
        await _ui.PressAsync(_locators.DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement, "Tab");
        await _ui.FillAsync(_locators.DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs, _data.Resolve("{{data:does_the_insured_enter_into_contracts_involving_commercial_snow_removal_including_snow_removal_from_residential_roofs_180}}"));
        await _ui.PressAsync(_locators.DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs, "Tab");
        await _ui.PressAsync(_locators.DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs, "Tab");
        await _ui.ClickAsync(_locators.FG0013AutomaticAdditionalInsuredSpecificRelationshipOK);
    }

    // Business step: I answer GL UW Questions OR \& WA
    public async Task AnswerGLUWQuestionsORWAAsync2()
    {
        // GLNavigationLinks_6f2588Page.NavigateToGLUWQuestions_0105_d65717Async
        await _ui.ClickAsync(_locators.GLUWQuestions);
        // GeneralLiabilityInformation_459030Page.AnswerGeneralLiabilityInformationQuestions_0106_d65717Async
        await _ui.WaitAsync(_locators.GeneralLiabilityInformation, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswersFB765);
        await _ui.FillAsync(_locators.DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy, _data.Resolve("{{data:describe_all_hold_harmless_agreements_and_please_provide_a_copy_185}}"));
        await _ui.PressAsync(_locators.DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy, "Tab");
        await _ui.PressAsync(_locators.DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy, "Tab");
        await _ui.ClickAsync(_locators.GeneralLiabilityInformationOK);
        // GLNavigationLinks_6f2588Page.NavigateToGLUWQuestions_0107_d65717Async
        await _ui.ClickAsync(_locators.GLUWQuestions);
        // GeneralLiabilityInformation_459030Page.WaitForGeneralLiabilityScreenToLoad_0108_d65717Async
        await _ui.WaitAsync(_locators.GeneralLiabilityInformation, "Exists");
        // ProductsCompletedOps_e712ddPage.AnswerProductsCompletedOpsQuestion_0109_d65717Async
        await _ui.ClickAsync(_locators.ProductsCompletedOpsButton);
        await _ui.WaitAsync(_locators.ProductsCompletedOps, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswers69564);
        await _ui.ClickAsync(_locators.ProductsCompletedOpsOK);
    }

    // Business step: I complete required billing information
    public async Task CompleteRequiredBillingInformationAsync3()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0110_d65717Async
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0111_d65717Async
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_195}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_198}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_202}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0112_d65717Async
        await Task.Delay(1000);
    }

    // Business step: I add notepad comment
    public async Task AddNotepadCommentAsync3()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToNotePadScreen_0113_d65717Async
        await _ui.ClickAsync(_locators.Notepad);
        // NotePad_055c33Page.AddNotesRemarksToNotePad_0114_d65717Async
        await _ui.WaitAsync(_locators.NotepadHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNotesRemarks);
        await _ui.FillAsync(_locators.TextBox, _data.Resolve("Test {B[Product (LOB)]}"));
        await _ui.ClickAsync(_locators.NotePadOK);
    }

    // Business step: I complete required submission information
    public async Task CompleteRequiredSubmissionInformationAsync3()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0115_d65717Async
        await _ui.WaitAsync(_locators.Submission, "Visible");
        await _ui.ClickAsync(_locators.Submission);
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutRequiredFields_0116_d65717Async
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_213}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "CLICK");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.OrderAudit_0117_d65717Async
        await _ui.VerifyAsync(_locators.OrderAudit, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutOrderAudit_0118_d65717Async
        await _ui.FillAsync(_locators.OrderAudit, _data.Resolve("{{data:order_audit_215}}"));
        await _ui.PressAsync(_locators.OrderAudit, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeSubmissionScreenHeaderExists_0119_d65717Async
        await _ui.VerifyAsync(_locators.SubmissionHeading, _data.Resolve("Absent"), "");
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0120_d65717Async
        await _ui.PressAsync(_locators.Submission, "PRE:TAB");
        await _ui.PressAsync(_locators.Submission, "Tab");
        await _ui.ClickAsync(_locators.Submission);
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0121_d65717Async
        await Task.Delay(1000);
        // SubmissionRequiredAndOptionalFields_4090a9Page.WaitOnSubmissionScreenToLoad_0122_d65717Async
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        // TBoxWait_7ea9e1Page.N500msWaitForSyncing_0123_d65717Async
        await Task.Delay(1000);
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync4()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0079_d344b2Async
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0080_d344b2Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0081_d344b2Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0082_d344b2Async
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_100}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_101}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0083_d344b2Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0084_d344b2Async
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_103}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_107}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0085_d344b2Async
        _data.Set("StateIsKansas", _data.Resolve("Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'"));
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0087_d344b2Async
        _data.Set("StateIsVirginia", _data.Resolve("Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'"));
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0089_d344b2Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0090_d344b2Async
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_113}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0091_d344b2Async
        await Task.Delay(1000);
    }

    // Business step: I navigate to Policy Info and Verify Desc
    public async Task NavigateToPolicyInfoAndVerifyDescAsync()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfo_0130_d344b2Async
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.PolicyInfoVerifyDescriptionOfSpecifiedOperation_0131_d344b2Async
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{B[QuoteDescription]}"), "value");
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync5()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0079_a1ba9cAsync
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0080_a1ba9cAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0081_a1ba9cAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0082_a1ba9cAsync
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_100}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_101}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0083_a1ba9cAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0084_a1ba9cAsync
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_103}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_107}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0085_a1ba9cAsync
        _data.Set("StateIsKansas", _data.Resolve("Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0086_a1ba9cAsync
        if (_data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_109}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_110}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0087_a1ba9cAsync
        _data.Set("StateIsVirginia", _data.Resolve("Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0088_a1ba9cAsync
        if (_data.Condition("'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_112}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_113}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0089_a1ba9cAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0090_a1ba9cAsync
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_117}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0091_a1ba9cAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0092_a1ba9cAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AL BAP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0095_a1ba9cAsync
        await Task.Delay(1000);
    }

    // Business step: I navigate to Policy Info and Verify Desc
    public async Task NavigateToPolicyInfoAndVerifyDescAsync2()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfo_0147_a1ba9cAsync
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.PolicyInfoVerifyDescriptionOfSpecifiedOperation_0148_a1ba9cAsync
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{B[QuoteDescription]}"), "value");
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync6()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0052_f90f36Async
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0053_f90f36Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0054_f90f36Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0055_f90f36Async
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_51}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_52}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0056_f90f36Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0057_f90f36Async
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_54}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_58}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0058_f90f36Async
        _data.Set("StateIsKansas", _data.Resolve("Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0059_f90f36Async
        if (_data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_60}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_61}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0060_f90f36Async
        _data.Set("StateIsVirginia", _data.Resolve("Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0061_f90f36Async
        if (_data.Condition("'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_63}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_64}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0062_f90f36Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0063_f90f36Async
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_68}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0064_f90f36Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0065_f90f36Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AL BAP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I navigate to policy coverages
    public async Task NavigateToPolicyCoveragesAsync()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToPolicyCoverage_0094_f90f36Async
        await _ui.WaitAsync(_locators.PolicyCovgerage, "Exists");
        await _ui.ClickAsync(_locators.PolicyCovgerage);
        // PolicyCoverageLimits_bce0bdPage.AddCoverages_0095_f90f36Async
        await _ui.WaitAsync(_locators.PolicyCovg26786, "Exists");
        await _ui.FillAsync(_locators.TrailerInterchangeCompDeductible, _data.Resolve("{{data:trailer_interchange_comp_deductible_123}}"));
        await _ui.PressAsync(_locators.TrailerInterchangeCompDeductible, "Click");
        await _ui.PressAsync(_locators.TrailerInterchangeCompDeductible, "Enter");
        await _ui.PressAsync(_locators.TrailerInterchangeCompDeductible, "Tab");
        await _ui.FillAsync(_locators.TrailerInterchangeCollisionDeductible, _data.Resolve("{{data:trailer_interchange_collision_deductible_124}}"));
        await _ui.PressAsync(_locators.TrailerInterchangeCollisionDeductible, "Click");
        await _ui.PressAsync(_locators.TrailerInterchangeCollisionDeductible, "Enter");
        await _ui.PressAsync(_locators.TrailerInterchangeCollisionDeductible, "Tab");
        // PolicyCoverageLimits_bce0bdPage.WaitForSynchronization_0096_f90f36Async
        await _ui.WaitAsync(_locators.PolicyCovg26786, "Exists");
    }

    // Business step: I complete required location information
    public async Task CompleteRequiredLocationInformationAsync2()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToLocation_0097_f90f36Async
        await _ui.WaitAsync(_locators.LocationA1D91, "Exists");
        await _ui.ClickAsync(_locators.LocationA1D91);
        // Location_d219c6Page.WaitForSynchronization_0098_f90f36Async
        await _ui.WaitAsync(_locators.Location82D95, "Exists");
        await _ui.VerifyAsync(_locators.ZipCodeD2DBA, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
    }

    // Business step: I navigate to state details
    public async Task NavigateToStateDetailsAsync()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToStateDetails_0099_f90f36Async
        await _ui.WaitAsync(_locators.StateDetails33183, "Exists");
        await _ui.ClickAsync(_locators.StateDetails33183);
        await _ui.WaitAsync(_locators.StateDetailsDetail, "Exists");
        await _ui.ClickAsync(_locators.StateDetailsDetail);
        // StateDetailsUMUIM_f65252Page.WaitForSynchronization_0100_f90f36Async
        await _ui.WaitAsync(_locators.StateDetails72631, "Exists");
        // StateDetailsUMUIM_f65252Page.ConfirmChanges_0101_f90f36Async
        await _ui.ClickAsync(_locators.UMUIMOK);
        // BAPNavigationLinks_e0270bPage.WaitForSynchronization_0102_f90f36Async
        await _ui.WaitAsync(_locators.StateDetailsDetail, "Exists");
    }

    // Business step: I complete vehicle information
    public async Task CompleteVehicleInformationAsync()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToRiskSchedule_0103_f90f36Async
        await _ui.WaitAsync(_locators.RiskSchedule, "Exists");
        await _ui.ClickAsync(_locators.RiskSchedule);
        // RiskAggregate_e66594Page.WaitForSynchronization_0104_f90f36Async
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // RiskAggregate_e66594Page.AddAPPT_0105_f90f36Async
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_140}}"));
        await _ui.ClickAsync(_locators.AddRiskAtThisLocation);
        // RiskScheduleVehicleInformation_e69550Page.FillOutVehicleInformationPPT_0106_f90f36Async
        await _ui.WaitAsync(_locators.VIN, "Exists");
        await _ui.PressAsync(_locators.VIN, "PRE:TAB");
        await _ui.PressAsync(_locators.VIN, "Tab");
        await _ui.PressAsync(_locators.VIN, "Tab");
        await _ui.FillAsync(_locators.VIN, _data.Resolve("{{data:vin_144}}"));
        await _ui.PressAsync(_locators.VIN, "Tab");
        await _ui.PressAsync(_locators.VIN, "Tab");
        await _ui.PressAsync(_locators.VIN, "Tab");
        // RiskSchedulePhysicalDamage_c46a6aPage.FillOutPhysicalDamage_0109_f90f36Async
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // RiskAggregate_e66594Page.WaitForSynchronization_0110_f90f36Async
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // RiskAggregate_e66594Page.AddATruck_0111_f90f36Async
        await _ui.WaitAsync(_locators.ShowAllLocations, "Exists");
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_148}}"));
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.ClickAsync(_locators.AddRiskAtThisLocation);
        // RiskScheduleVehicleInformation_e69550Page.FillOutVehicleInformationTruck_0112_f90f36Async
        await _ui.WaitAsync(_locators.VIN, "Exists");
        await _ui.PressAsync(_locators.VIN, "PRE:TAB");
        await _ui.PressAsync(_locators.VIN, "Tab");
        await _ui.PressAsync(_locators.VIN, "Tab");
        await _ui.FillAsync(_locators.VIN, _data.Resolve("{{data:vin_152}}"));
        await _ui.PressAsync(_locators.VIN, "Tab");
        await _ui.PressAsync(_locators.VIN, "Tab");
        // RiskScheduleRiskSpecific_88fa13Page.RiskSpecific_0113_f90f36Async
        await _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_153}}"));
        await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
        await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
        await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
        // RiskSchedulePhysicalDamage_c46a6aPage.FillOutPhysicalDamage_0116_f90f36Async
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // RiskAggregate_e66594Page.WaitForSynchronization_0117_f90f36Async
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
    }

    // Business step: I complete driver information
    public async Task CompleteDriverInformationAsync()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToDriverSchedule_0118_f90f36Async
        await _ui.ClickAsync(_locators.DriverSchedule161DF);
        // DriverSchedule_d9e336Page.ClickAddADriver_0119_f90f36Async
        await _ui.WaitAsync(_locators.DriverSchedule79DC6, "Exists");
        await _ui.ClickAsync(_locators.AddDriver);
        // DriverDetail_d9a072Page.EnterDriverInfo_0120_f90f36Async
        await _ui.WaitAsync(_locators.DriverDetail, "Exists");
        await _ui.FillAsync(_locators.FirstName813D1, _data.Resolve("{{data:iframe_duck_creek_policy_first_name_160}}"));
        await _ui.PressAsync(_locators.FirstName813D1, "Tab");
        await _ui.PressAsync(_locators.FirstName813D1, "Tab");
        await _ui.PressAsync(_locators.FirstName813D1, "Tab");
        await _ui.FillAsync(_locators.LastName34FF6, _data.Resolve("{{data:iframe_duck_creek_policy_last_name_161}}"));
        await _ui.PressAsync(_locators.LastName34FF6, "Tab");
        await _ui.PressAsync(_locators.LastName34FF6, "Tab");
        await _ui.PressAsync(_locators.LastName34FF6, "Tab");
        await _ui.FillAsync(_locators.DateOfBirth, _data.Resolve("{DATE[09-05-2026][-40y][MM-dd-yyyy]}"));
        await _ui.PressAsync(_locators.DateOfBirth, "Tab");
        await _ui.PressAsync(_locators.DateOfBirth, "Tab");
        await _ui.PressAsync(_locators.DateOfBirth, "Tab");
        await _ui.FillAsync(_locators.StateLicensed, _data.Resolve("{{data:iframe_duck_creek_policy_state_licensed_163}}"));
        await _ui.PressAsync(_locators.StateLicensed, "Tab");
        await _ui.PressAsync(_locators.StateLicensed, "Tab");
        await _ui.PressAsync(_locators.StateLicensed, "Tab");
        await _ui.VerifyAsync(_locators.DriversLicenseNumber, _data.Resolve("{{data:expected_iframe_duck_creek_policy_drivers_license_number_innertext_164}}"), "InnerText");
        await _ui.FillAsync(_locators.Sex, _data.Resolve("{{data:iframe_duck_creek_policy_sex_165}}"));
        await _ui.PressAsync(_locators.Sex, "Tab");
        await _ui.FillAsync(_locators.MaritalStatus, _data.Resolve("{{data:iframe_duck_creek_policy_marital_status_166}}"));
        await _ui.PressAsync(_locators.MaritalStatus, "Tab");
        await _ui.PressAsync(_locators.MaritalStatus, "Tab");
        await _ui.FillAsync(_locators.YearLicensed, _data.Resolve("{{data:iframe_duck_creek_policy_year_licensed_167}}"));
        await _ui.PressAsync(_locators.YearLicensed, "Tab");
        await _ui.PressAsync(_locators.YearLicensed, "Tab");
        await _ui.FillAsync(_locators.DateOfHire, _data.Resolve("{{data:iframe_duck_creek_policy_date_of_hire_168}}"));
        await _ui.PressAsync(_locators.DateOfHire, "Tab");
        await _ui.PressAsync(_locators.DateOfHire, "Tab");
        await _ui.FillAsync(_locators.DoYouHaveACDLLicense, _data.Resolve("{{data:iframe_duck_creek_policy_do_you_have_a_cdl_license_169}}"));
        await _ui.PressAsync(_locators.DoYouHaveACDLLicense, "Tab");
        await _ui.ClickAsync(_locators.OK);
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0121_f90f36Async
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0122_f90f36Async
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // DriverDetail_d9a072Page.WaitForIFRAMEToClose_0123_f90f36Async
        await _ui.WaitAsync(_locators.IFRAME6D695, "Absent");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0124_f90f36Async
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0125_f90f36Async
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
    }

    // Business step: I complete required endorsement information
    public async Task CompleteRequiredEndorsementInformationAsync2()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToEndorsements_0126_f90f36Async
        await _ui.WaitAsync(_locators.EndorsementsC27F0, "Exists");
        await _ui.ClickAsync(_locators.EndorsementsC27F0);
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0127_f90f36Async
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
    }

    // Business step: I add endorsement
    public async Task AddEndorsementAsync()
    {
        // BAPEndorsementSchedule_7d25f7Page.CheckIfOnEndorsements_0129_f90f36Async
        await _ui.VerifyAsync(_locators.EndorsementsHeadingA3D50, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToEndorsements_0130_f90f36Async
        await _ui.ClickAsync(_locators.EndorsementsC27F0);
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0131_f90f36Async
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsements_bdb4d0Page.EnterRequiredEndorsementInfo_0132_f90f36Async
        await _ui.WaitAsync(_locators.ClickAddEndorsement, "Visible");
        await _ui.ClickAsync(_locators.ClickAddEndorsement);
        await _ui.WaitAsync(_locators.EndorsementDetail, "Exists");
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Year, _data.Resolve(""));
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Make, _data.Resolve(""));
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Model, _data.Resolve(""));
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940VIN, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.WaitAsync(_locators.EndorsementType624AD, "Exists");
        await _ui.ClickAsync(_locators.EndorsementType624AD);
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_192}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_193}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Click");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Enter");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        // BAPEndorsements_bdb4d0Page.ConfirmAddition_0133_f90f36Async
        await _ui.ClickAsync(_locators.OK);
        // BAPEndorsements_bdb4d0Page.CheckIfIFRAMEIsOpen_0134_f90f36Async
        await _ui.VerifyAsync(_locators.IFRAMEF0A48, _data.Resolve("Exists"), "");
        // BAPEndorsements_bdb4d0Page.WaitForIFRAMEToClose_0135_f90f36Async
        await _ui.WaitAsync(_locators.IFRAMEF0A48, "Absent");
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0136_f90f36Async
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
    }

    // Business step: I complete required underwriting question information
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync2()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToUWQuestions_0139_f90f36Async
        await _ui.ClickAsync(_locators.UWQuestions368CC);
        // UnderwritingQuestions_49c7c2Page.WaitForSynchronization_0140_f90f36Async
        await _ui.WaitAsync(_locators.UWQuestionsF3D9F, "Exists");
        // UnderwritingQuestions_49c7c2Page.FillOutUnderwritingQuestions_0141_f90f36Async
        await _ui.ClickAsync(_locators.UpdateAnswersButton);
        await _ui.PressAsync(_locators.UpdateAnswersButton, "Tab");
        await _ui.PressAsync(_locators.UpdateAnswersButton, "Tab");
        await _ui.FillAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, _data.Resolve("{{data:are_there_any_commercial_vehicles_owned_by_the_applicant_not_insured_on_the_policy_204}}"));
        await _ui.PressAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, "Tab");
        await _ui.PressAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, "Tab");
        await _ui.PressAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, "Tab");
        await _ui.WaitAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, "Equal");
        await _ui.FillAsync(_locators.AnyPersonalAutoPolicyListingNameInsured, _data.Resolve("{{data:anypersonalautopolicylistingnameinsured_206}}"));
        await _ui.PressAsync(_locators.AnyPersonalAutoPolicyListingNameInsured, "Tab");
        await _ui.PressAsync(_locators.AnyPersonalAutoPolicyListingNameInsured, "Tab");
        await _ui.PressAsync(_locators.AnyPersonalAutoPolicyListingNameInsured, "Tab");
        await _ui.FillAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, _data.Resolve("{{data:anyvehiclecoveredregisteredinnotprimarystate_207}}"));
        await _ui.PressAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, "Tab");
        await _ui.PressAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, "Tab");
        await _ui.PressAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, "Tab");
        await _ui.FillAsync(_locators.BorrowingHiringOrLeasingWithinYear, _data.Resolve("{{data:borrowinghiringorleasingwithinyear_208}}"));
        await _ui.PressAsync(_locators.BorrowingHiringOrLeasingWithinYear, "Tab");
        await _ui.PressAsync(_locators.BorrowingHiringOrLeasingWithinYear, "Tab");
        await _ui.PressAsync(_locators.BorrowingHiringOrLeasingWithinYear, "Tab");
        await _ui.PressAsync(_locators.BorrowingHiringOrLeasingWithinYear, "Tab");
        await _ui.PressAsync(_locators.BorrowingHiringOrLeasingWithinYear, "Tab");
        await _ui.WaitAsync(_locators.BorrowingHiringOrLeasingWithinYear, "Equal");
        await _ui.WaitAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, "Equal");
        // UnderwritingQuestions_49c7c2Page.CheckForAnyFeloniesQuestion_0142_f90f36Async
        await _ui.VerifyAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, _data.Resolve("Exists"), "");
        // UnderwritingQuestions_49c7c2Page.FillOutAnyFeloniesQuestion_0143_f90f36Async
        await _ui.FillAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, _data.Resolve("{{data:has_any_applicant_been_convicted_of_a_felony_or_been_involved_in_any_incidents_or_claims_relating_to_sexual_abuse_or_molestation_allegations_discrimination_arson_fraud_bribery_or_negligent_hiring_212}}"));
        await _ui.PressAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, "Tab");
        await _ui.PressAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, "Tab");
        await _ui.PressAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, "Tab");
    }

    // Business step: I complete required billing information
    public async Task CompleteRequiredBillingInformationAsync4()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0144_f90f36Async
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0145_f90f36Async
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_215}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_218}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_222}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0146_f90f36Async
        await Task.Delay(1000);
    }

    // Business step: I add notepad comment
    public async Task AddNotepadCommentAsync4()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToNotePadScreen_0147_f90f36Async
        await _ui.ClickAsync(_locators.Notepad);
        // NotePad_055c33Page.AddNotesRemarksToNotePad_0148_f90f36Async
        await _ui.WaitAsync(_locators.NotepadHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNotesRemarks);
        await _ui.FillAsync(_locators.TextBox, _data.Resolve("Test {B[Product (LOB)]}"));
        await _ui.ClickAsync(_locators.NotePadOK);
    }

    // Business step: I verify premium
    public async Task VerifyPremiumAsync()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToPricing_0149_f90f36Async
        await _ui.WaitAsync(_locators.PricingF3185, "Exists");
        await _ui.ClickAsync(_locators.PricingF3185);
        // Pricing_a0d9bbPage.WaitForSynchronization_0150_f90f36Async
        await _ui.WaitAsync(_locators.PricingHeading, "Exists");
        // Pricing_a0d9bbPage.VerifyPremiumAmount_0151_f90f36Async
        await _ui.VerifyAsync(_locators.Premium, _data.Resolve("{{data:expected_premium_value_233}}"), "value");
    }

    // Business step: I complete required submission information
    public async Task CompleteRequiredSubmissionInformationAsync4()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0152_f90f36Async
        await _ui.WaitAsync(_locators.Submission, "Visible");
        await _ui.ClickAsync(_locators.Submission);
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutRequiredFields_0153_f90f36Async
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_237}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "CLICK");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.OrderAudit_0154_f90f36Async
        await _ui.VerifyAsync(_locators.OrderAudit, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutOrderAudit_0155_f90f36Async
        await _ui.FillAsync(_locators.OrderAudit, _data.Resolve("{{data:order_audit_239}}"));
        await _ui.PressAsync(_locators.OrderAudit, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeSubmissionScreenHeaderExists_0156_f90f36Async
        await _ui.VerifyAsync(_locators.SubmissionHeading, _data.Resolve("Absent"), "");
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0157_f90f36Async
        await _ui.PressAsync(_locators.Submission, "PRE:TAB");
        await _ui.PressAsync(_locators.Submission, "Tab");
        await _ui.ClickAsync(_locators.Submission);
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0158_f90f36Async
        await Task.Delay(1000);
        // SubmissionRequiredAndOptionalFields_4090a9Page.WaitOnSubmissionScreenToLoad_0159_f90f36Async
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        // TBoxWait_7ea9e1Page.N500msWaitForSyncing_0160_f90f36Async
        await Task.Delay(1000);
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync7()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0079_85cb3fAsync
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0080_85cb3fAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0081_85cb3fAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0082_85cb3fAsync
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_98}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_99}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0083_85cb3fAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0084_85cb3fAsync
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_101}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_105}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0085_85cb3fAsync
        _data.Set("StateIsKansas", _data.Resolve("Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0086_85cb3fAsync
        if (_data.Condition("'Product (LOB)' == \"UMB\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_107}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_108}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0087_85cb3fAsync
        _data.Set("StateIsVirginia", _data.Resolve("Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0088_85cb3fAsync
        if (_data.Condition("'Product (LOB)' == \"UMB\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_110}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"UMB\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_111}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0089_85cb3fAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0090_85cb3fAsync
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_115}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0091_85cb3fAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0092_85cb3fAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AL UMB Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I complete required billing information
    public async Task CompleteRequiredBillingInformationAsync5()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0094_c839dfAsync
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0095_c839dfAsync
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_86}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_89}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_93}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0096_c839dfAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync8()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0108_c839dfAsync
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0109_c839dfAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0110_c839dfAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0111_c839dfAsync
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_138}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0112_c839dfAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0113_c839dfAsync
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_140}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_141}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0114_c839dfAsync
        _data.Set("StateIsKansas", _data.Resolve("Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"));
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0116_c839dfAsync
        _data.Set("StateIsVirginia", _data.Resolve("Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"));
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0118_c839dfAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0119_c839dfAsync
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_145}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0120_c839dfAsync
        await Task.Delay(1000);
    }

    // Business step: I navigate to Policy Info and Verify Desc
    public async Task NavigateToPolicyInfoAndVerifyDescAsync3()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfo_0158_c839dfAsync
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.PolicyInfoVerifyDescriptionOfSpecifiedOperation_0159_c839dfAsync
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{B[QuoteDescription]}"), "value");
    }

    // Business step: I complete required billing information
    public async Task CompleteRequiredBillingInformationAsync6()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0053_aad19bAsync
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0054_aad19bAsync
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_37}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_40}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_44}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0055_aad19bAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync9()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0066_aad19bAsync
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0067_aad19bAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0068_aad19bAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0069_aad19bAsync
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_86}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_87}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0070_aad19bAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0071_aad19bAsync
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_89}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_93}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0072_aad19bAsync
        _data.Set("StateIsKansas", _data.Resolve("Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'"));
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0074_aad19bAsync
        _data.Set("StateIsVirginia", _data.Resolve("Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'"));
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0076_aad19bAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0077_aad19bAsync
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_99}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0078_aad19bAsync
        await Task.Delay(1000);
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0079_aad19bAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_104}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_105}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_106}}"), "value");
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0080_aad19bAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AZ CPP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0083_aad19bAsync
        await Task.Delay(1000);
    }

    // Business step: I complete CP Fields for location
    public async Task CompleteCPFieldsForLocationAsync()
    {
        // CPNavigationLinks_d0fcc0Page.NavigateToLocationScreen_0106_aad19bAsync
        await _ui.ClickAsync(_locators.LocationB7B1D);
        // Location_d219c6Page.FillOutCPLocationFieldsFtFromHydrant_0107_aad19bAsync
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.FillAsync(_locators.FeetFromHydrant, _data.Resolve("{{data:feet_from_hydrant_138}}"));
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Enter");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0108_aad19bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0109_aad19bAsync
        await Task.Delay(1000);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0110_aad19bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0111_aad19bAsync
        await Task.Delay(1000);
        // Location_d219c6Page.FillOutCPLocationFieldsMilesFromFD_0112_aad19bAsync
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.FillAsync(_locators.MilesFromFireDepartment, _data.Resolve("{{data:miles_from_fire_department_144}}"));
        await _ui.PressAsync(_locators.MilesFromFireDepartment, "Tab");
        await _ui.PressAsync(_locators.MilesFromFireDepartment, "Tab");
        await _ui.PressAsync(_locators.MilesFromFireDepartment, "Tab");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0113_aad19bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0114_aad19bAsync
        await Task.Delay(1000);
        // Location_d219c6Page.VerifyFtFromHydrant_0115_aad19bAsync
        await _ui.VerifyAsync(_locators.FeetFromHydrant, _data.Resolve("{{data:expected_feet_from_hydrant_value_147}}"), "NotEqual:Value");
        // Location_d219c6Page.FillOutCPLocationFieldsFtFromHydrant_0116_aad19bAsync
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.FillAsync(_locators.FeetFromHydrant, _data.Resolve("{{data:feet_from_hydrant_149}}"));
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Enter");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0117_aad19bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0118_aad19bAsync
        await Task.Delay(1000);
        // Location_d219c6Page.FillOutCPLocationFieldsCallISOAndSelectPPC_0119_aad19bAsync
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.ClickAsync(_locators.CallISO);
        await _ui.ClickAsync(_locators.SelectPPC);
        await _ui.ClickAsync(_locators.Select);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0120_aad19bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0121_aad19bAsync
        await Task.Delay(1000);
        // Location_d219c6Page.VerifyFtFromHydrant_0122_aad19bAsync
        await _ui.VerifyAsync(_locators.FeetFromHydrant, _data.Resolve("{{data:expected_feet_from_hydrant_value_158}}"), "NotEqual:Value");
        // Location_d219c6Page.FillOutCPLocationFieldsFtFromHydrant_0123_aad19bAsync
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.FillAsync(_locators.FeetFromHydrant, _data.Resolve("{{data:feet_from_hydrant_160}}"));
        await _ui.PressAsync(_locators.FeetFromHydrant, "CLICK");
        await _ui.PressAsync(_locators.FeetFromHydrant, "CLICK");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Enter");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Enter");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0124_aad19bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0125_aad19bAsync
        await Task.Delay(1000);
        // Location_d219c6Page.ClickOKOnCPLocationFieldsCallISOAndSelectPPC_0126_aad19bAsync
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.ClickAsync(_locators.LocationOK);
    }

    // Business step: I complete CP Fields for building
    public async Task CompleteCPFieldsForBuildingAsync()
    {
        // CPNavigationLinks_d0fcc0Page.NavigateToBuildingScreen_0127_aad19bAsync
        await _ui.ClickAsync(_locators.Building87910);
        // BuildingMain_d5e89aPage.BuildingAddBuilding_0128_aad19bAsync
        await _ui.WaitAsync(_locators.Building8205F, "Exists");
        await _ui.ClickAsync(_locators.AddBuilding);
        // BuildingMain_d5e89aPage.BuildingSelectBuildingDetail_0129_aad19bAsync
        await _ui.WaitAsync(_locators.Building8205F, "Exists");
        await _ui.ClickAsync(_locators.Detail10932);
        // BuildingDetail_497f3cPage.BuildingFillInBuildingDetailFields_0130_aad19bAsync
        if (_data.Condition("Construction != NULL"))
        {
            await _ui.FillAsync(_locators.Construction39800, _data.Resolve("{{data:construction_170}}"));
            await _ui.PressAsync(_locators.Construction39800, "Tab");
            await _ui.PressAsync(_locators.Construction39800, "Tab");
        }
        if (_data.Condition("'Year Built' != NULL"))
        {
            await _ui.FillAsync(_locators.YearBuilt, _data.Resolve("{{data:year_built_171}}"));
            await _ui.PressAsync(_locators.YearBuilt, "Tab");
            await _ui.PressAsync(_locators.YearBuilt, "Tab");
        }
        if (_data.Condition("'Square Feet' != NULL"))
        {
            await _ui.FillAsync(_locators.SquareFeet, _data.Resolve("{{data:square_feet_172}}"));
            await _ui.PressAsync(_locators.SquareFeet, "Tab");
            await _ui.PressAsync(_locators.SquareFeet, "Tab");
        }
        if (_data.Condition("Stories != NULL"))
        {
            await _ui.FillAsync(_locators.Stories, _data.Resolve("{{data:stories_173}}"));
            await _ui.PressAsync(_locators.Stories, "Tab");
            await _ui.PressAsync(_locators.Stories, "Tab");
        }
        if (_data.Condition("Interest != NULL"))
        {
            await _ui.FillAsync(_locators.Interest, _data.Resolve("{{data:interest_174}}"));
            await _ui.PressAsync(_locators.Interest, "Tab");
            await _ui.PressAsync(_locators.Interest, "Tab");
        }
        if (_data.Condition("'Roof Type' != NULL"))
        {
            await _ui.FillAsync(_locators.RoofType, _data.Resolve("{{data:roof_type_175}}"));
            await _ui.PressAsync(_locators.RoofType, "Tab");
            await _ui.PressAsync(_locators.RoofType, "Tab");
        }
        if (_data.Condition("Deductible != NULL"))
        {
            await _ui.FillAsync(_locators.Deductible592D9, _data.Resolve("{{data:deductible_176}}"));
            await _ui.PressAsync(_locators.Deductible592D9, "Tab");
            await _ui.PressAsync(_locators.Deductible592D9, "Tab");
            await _ui.PressAsync(_locators.Deductible592D9, "CLICK");
            await _ui.PressAsync(_locators.Deductible592D9, "CLICK");
            await _ui.PressAsync(_locators.Deductible592D9, "Tab");
        }
        if (_data.Condition("'Deductible Increased Theft' != NULL"))
        {
            await _ui.FillAsync(_locators.DeductibleIncreasedTheft99E5F, _data.Resolve("{{data:deductible_increased_theft_177}}"));
            await _ui.PressAsync(_locators.DeductibleIncreasedTheft99E5F, "Tab");
            await _ui.PressAsync(_locators.DeductibleIncreasedTheft99E5F, "Tab");
        }
        if (_data.Condition("'Deductible Wind Hail' != NULL"))
        {
            await _ui.FillAsync(_locators.DeductibleWindHail911AF, _data.Resolve("{{data:deductible_wind_hail_178}}"));
            await _ui.PressAsync(_locators.DeductibleWindHail911AF, "Tab");
            await _ui.PressAsync(_locators.DeductibleWindHail911AF, "Tab");
        }
        if (_data.Condition("'BG2 Symbol' != NULL"))
        {
            await _ui.FillAsync(_locators.BG2Symbol, _data.Resolve("{{data:bg2_symbol_179}}"));
            await _ui.PressAsync(_locators.BG2Symbol, "Tab");
            await _ui.PressAsync(_locators.BG2Symbol, "Tab");
        }
        if (_data.Condition("'BG2 Symbol Prefix' != NULL"))
        {
            await _ui.FillAsync(_locators.BG2SymbolPrefix, _data.Resolve("{{data:bg2_symbol_prefix_180}}"));
            await _ui.PressAsync(_locators.BG2SymbolPrefix, "CLICK");
            await _ui.PressAsync(_locators.BG2SymbolPrefix, "Tab");
        }
        if (_data.Condition("'Is the building cooled?' != NULL"))
        {
            await _ui.FillAsync(_locators.IsTheBuildingCooled, _data.Resolve("{{data:is_the_building_cooled_181}}"));
            await _ui.PressAsync(_locators.IsTheBuildingCooled, "Tab");
            await _ui.PressAsync(_locators.IsTheBuildingCooled, "Tab");
        }
        if (_data.Condition("'Is the building heated with a Solid Fuel Heating Device?' != NULL"))
        {
            await _ui.FillAsync(_locators.IsTheBuildingHeatedWithASolidFuelHeatingDevice, _data.Resolve("{{data:is_the_building_heated_with_a_solid_fuel_heating_device_182}}"));
            await _ui.PressAsync(_locators.IsTheBuildingHeatedWithASolidFuelHeatingDevice, "Tab");
            await _ui.PressAsync(_locators.IsTheBuildingHeatedWithASolidFuelHeatingDevice, "CLICK");
            await _ui.PressAsync(_locators.IsTheBuildingHeatedWithASolidFuelHeatingDevice, "Tab");
        }
        if (_data.Condition("'Provide a List of Surrounding Exposure/Other Occupancies within 100 ft (Including North, East, South, and West)' != NULL"))
        {
            await _ui.FillAsync(_locators.ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest, _data.Resolve("{{data:provide_a_list_of_surrounding_exposure_other_occupancies_within_100_ft_including_north_east_south_and_west_183}}"));
            await _ui.PressAsync(_locators.ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest, "Tab");
            await _ui.PressAsync(_locators.ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest, "CLICK");
            await _ui.PressAsync(_locators.ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest, "Tab");
        }
        if (_data.Condition("'Eligible For Enhanced Wind Rating Program' != NULL"))
        {
            await _ui.FillAsync(_locators.EligibleForEnhancedWindRatingProgram, _data.Resolve("{{data:eligible_for_enhanced_wind_rating_program_184}}"));
            await _ui.PressAsync(_locators.EligibleForEnhancedWindRatingProgram, "Tab");
            await _ui.PressAsync(_locators.EligibleForEnhancedWindRatingProgram, "Tab");
        }
        await _ui.ClickAsync(_locators.BuildingDetailOK);
    }

    // Business step: I add a Rating Group
    public async Task AddARatingGroupAsync()
    {
        // CPNavigationLinks_d0fcc0Page.NavigateToRatingGroupsScreen_0131_aad19bAsync
        await _ui.ClickAsync(_locators.RatingGroups46191);
        // RatingGroups_62db8dPage.AddRatingGroups_0132_aad19bAsync
        await _ui.WaitAsync(_locators.RatingGroups46DD2, "Exists");
        if (_data.Condition("Description != NULL"))
        {
            await _ui.FillAsync(_locators.Description8A08D, _data.Resolve("{{data:description_188}}"));
            await _ui.PressAsync(_locators.Description8A08D, "Tab");
            await _ui.PressAsync(_locators.Description8A08D, "Tab");
        }
        if (_data.Condition("'Risk Type' != NULL"))
        {
            await _ui.FillAsync(_locators.RiskType, _data.Resolve("{{data:risk_type_189}}"));
            await _ui.PressAsync(_locators.RiskType, "Tab");
            await _ui.PressAsync(_locators.RiskType, "Tab");
        }
        if (_data.Condition("Coinsurance != NULL"))
        {
            await _ui.FillAsync(_locators.Coinsurance6348B, _data.Resolve("{{data:coinsurance_190}}"));
            await _ui.PressAsync(_locators.Coinsurance6348B, "Tab");
            await _ui.PressAsync(_locators.Coinsurance6348B, "Tab");
        }
        if (_data.Condition("Deductible != NULL"))
        {
            await _ui.FillAsync(_locators.Deductible01AB9, _data.Resolve("{{data:deductible_191}}"));
            await _ui.PressAsync(_locators.Deductible01AB9, "Tab");
            await _ui.PressAsync(_locators.Deductible01AB9, "Tab");
        }
        if (_data.Condition("'Deductible Increased Theft' != NULL"))
        {
            await _ui.FillAsync(_locators.DeductibleIncreasedTheftF76DB, _data.Resolve("{{data:deductible_increased_theft_192}}"));
            await _ui.PressAsync(_locators.DeductibleIncreasedTheftF76DB, "Tab");
            await _ui.PressAsync(_locators.DeductibleIncreasedTheftF76DB, "Tab");
        }
        if (_data.Condition("'Deductible Wind Hail' != NULL"))
        {
            await _ui.FillAsync(_locators.DeductibleWindHailAB1C3, _data.Resolve("{{data:deductible_wind_hail_193}}"));
            await _ui.PressAsync(_locators.DeductibleWindHailAB1C3, "Tab");
            await _ui.PressAsync(_locators.DeductibleWindHailAB1C3, "Tab");
        }
        if (_data.Condition("'Cause Of Loss' != NULL"))
        {
            await _ui.FillAsync(_locators.CauseOfLoss, _data.Resolve("{{data:cause_of_loss_194}}"));
            await _ui.PressAsync(_locators.CauseOfLoss, "Tab");
            await _ui.PressAsync(_locators.CauseOfLoss, "Tab");
        }
        if (_data.Condition("Valuation != NULL"))
        {
            await _ui.FillAsync(_locators.Valuation, _data.Resolve("{{data:valuation_195}}"));
            await _ui.PressAsync(_locators.Valuation, "Tab");
            await _ui.PressAsync(_locators.Valuation, "Tab");
        }
        await _ui.ClickAsync(_locators.AddGroup);
    }

    // Business step: I complete Structure Questions
    public async Task CompleteStructureQuestionsAsync()
    {
        // CPNavigationLinks_d0fcc0Page.NavigateToPropertyScreen_0133_aad19bAsync
        await _ui.ClickAsync(_locators.Property);
        // PropertyMain_a49a9ePage.FillOutMainPropertyQuestions_0134_aad19bAsync
        if (_data.Condition("'Increased Pollutant Cleanup' != NULL"))
        {
            await _ui.FillAsync(_locators.IncreasedPollutantCleanup, _data.Resolve("{{data:increased_pollutant_cleanup_198}}"));
            await _ui.PressAsync(_locators.IncreasedPollutantCleanup, "Tab");
            await _ui.PressAsync(_locators.IncreasedPollutantCleanup, "Tab");
        }
        if (_data.Condition("'Debris Removal Additional' != NULL"))
        {
            await _ui.FillAsync(_locators.DebrisRemovalAdditional, _data.Resolve("{{data:debris_removal_additional_199}}"));
            await _ui.PressAsync(_locators.DebrisRemovalAdditional, "Tab");
            await _ui.PressAsync(_locators.DebrisRemovalAdditional, "Tab");
        }
        if (_data.Condition("'Debris Removal Additional Limit' != NULL"))
        {
            await _ui.FillAsync(_locators.DebrisRemovalAdditionalLimit, _data.Resolve("{{data:debris_removal_additional_limit_200}}"));
            await _ui.PressAsync(_locators.DebrisRemovalAdditionalLimit, "Tab");
            await _ui.PressAsync(_locators.DebrisRemovalAdditionalLimit, "Tab");
        }
        if (_data.Condition("'Vacant Building' != NULL"))
        {
            await _ui.FillAsync(_locators.VacantBuilding, _data.Resolve("{{data:vacant_building_201}}"));
            await _ui.PressAsync(_locators.VacantBuilding, "Tab");
            await _ui.PressAsync(_locators.VacantBuilding, "Tab");
        }
        if (_data.Condition("'% Occupied' != NULL"))
        {
            await _ui.FillAsync(_locators.Occupied, _data.Resolve("{{data:occupied_202}}"));
            await _ui.PressAsync(_locators.Occupied, "Tab");
            await _ui.PressAsync(_locators.Occupied, "Tab");
        }
        if (_data.Condition("'Pier Or Wharf' != NULL"))
        {
            await _ui.FillAsync(_locators.PierOrWharf, _data.Resolve("{{data:pier_or_wharf_203}}"));
            await _ui.PressAsync(_locators.PierOrWharf, "Tab");
            await _ui.PressAsync(_locators.PierOrWharf, "Tab");
        }
        if (_data.Condition("'Pier Or Wharf Construction' != NULL"))
        {
            await _ui.FillAsync(_locators.PierOrWharfConstruction, _data.Resolve("{{data:pier_or_wharf_construction_204}}"));
            await _ui.PressAsync(_locators.PierOrWharfConstruction, "Tab");
            await _ui.PressAsync(_locators.PierOrWharfConstruction, "Tab");
        }
        if (_data.Condition("'Pier Or Wharf Cause Of Loss' != NULL"))
        {
            await _ui.FillAsync(_locators.PierOrWharfCauseOfLoss, _data.Resolve("{{data:pier_or_wharf_cause_of_loss_205}}"));
            await _ui.PressAsync(_locators.PierOrWharfCauseOfLoss, "Tab");
            await _ui.PressAsync(_locators.PierOrWharfCauseOfLoss, "Tab");
            await _ui.PressAsync(_locators.PierOrWharfCauseOfLoss, "Tab");
        }
        if (_data.Condition("'Pier Or Wharf COL Options' != NULL"))
        {
            await _ui.FillAsync(_locators.PierOrWharfCOLOptions, _data.Resolve("{{data:pier_or_wharf_col_options_206}}"));
            await _ui.PressAsync(_locators.PierOrWharfCOLOptions, "Tab");
            await _ui.PressAsync(_locators.PierOrWharfCOLOptions, "CLICK");
            await _ui.PressAsync(_locators.PierOrWharfCOLOptions, "Tab");
        }
        if (_data.Condition("'Vacancy Permit' != NULL"))
        {
            await _ui.FillAsync(_locators.VacancyPermit, _data.Resolve("{{data:vacancy_permit_207}}"));
            await _ui.PressAsync(_locators.VacancyPermit, "Tab");
            await _ui.PressAsync(_locators.VacancyPermit, "Tab");
        }
        if (_data.Condition("'Pier Or Wharf COL Options' != NULL"))
        {
            await _ui.WaitAsync(_locators.PierOrWharfCOLOptions, "Exists");
        }
        // PropertyAddClass_ed4d5dPage.PropertyAddClass_0135_aad19bAsync
        await _ui.ClickAsync(_locators.AddClassDCD8F);
        if (_data.Condition("(State !=\"OR\")||(State!=\"WA\")||(State!=\"VT\")"))
        {
            await _ui.FillAsync(_locators.SearchValue54F3C, _data.Resolve("{{data:search_value_210}}"));
            await _ui.PressAsync(_locators.SearchValue54F3C, "CLICK");
            await _ui.PressAsync(_locators.SearchValue54F3C, "Tab");
            await _ui.PressAsync(_locators.SearchValue54F3C, "Tab");
        }
        if (_data.Condition("(State !=\"OR\")||(State!=\"WA\")||(State!=\"VT\")"))
        {
            await _ui.FillAsync(_locators.SearchResultsD0AA8, _data.Resolve("{{data:search_results_211}}"));
            await _ui.PressAsync(_locators.SearchResultsD0AA8, "CLICK");
            await _ui.PressAsync(_locators.SearchResultsD0AA8, "Enter");
            await _ui.PressAsync(_locators.SearchResultsD0AA8, "Tab");
            await _ui.PressAsync(_locators.SearchResultsD0AA8, "Tab");
        }
        await _ui.FillAsync(_locators.OccupancyType, _data.Resolve("{{data:occupancy_type_212}}"));
        await _ui.PressAsync(_locators.OccupancyType, "CLICK");
        await _ui.PressAsync(_locators.OccupancyType, "Tab");
        if (_data.Condition("(State ==\"OR\")||(State==\"WA\")"))
        {
            await _ui.FillAsync(_locators.SearchResultsD0AA8, _data.Resolve(""));
        }
        await _ui.ClickAsync(_locators.PropertyAddClassOK);
        await _ui.FillAsync(_locators.BuildingRatingGroup, _data.Resolve("{{data:building_rating_group_215}}"));
        await _ui.PressAsync(_locators.BuildingRatingGroup, "Tab");
        await _ui.PressAsync(_locators.BuildingRatingGroup, "CLICK");
        await _ui.PressAsync(_locators.BuildingRatingGroup, "Tab");
        await _ui.FillAsync(_locators.BuildingLimit, _data.Resolve("{{data:building_limit_216}}"));
        await _ui.PressAsync(_locators.BuildingLimit, "Tab");
        await _ui.PressAsync(_locators.BuildingLimit, "Tab");
        await _ui.FillAsync(_locators.PersonalPropertyRatingGroup, _data.Resolve("{{data:personal_property_rating_group_217}}"));
        await _ui.PressAsync(_locators.PersonalPropertyRatingGroup, "Tab");
        await _ui.PressAsync(_locators.PersonalPropertyRatingGroup, "Tab");
        await _ui.FillAsync(_locators.PersonalPropertyLimit, _data.Resolve("{{data:personal_property_limit_218}}"));
        await _ui.PressAsync(_locators.PersonalPropertyLimit, "Tab");
        await _ui.PressAsync(_locators.PersonalPropertyLimit, "Tab");
        await _ui.FillAsync(_locators.PropertyOfOthersRatingGroup, _data.Resolve("{{data:property_of_others_rating_group_219}}"));
        await _ui.PressAsync(_locators.PropertyOfOthersRatingGroup, "Tab");
        await _ui.PressAsync(_locators.PropertyOfOthersRatingGroup, "Tab");
        await _ui.PressAsync(_locators.PropertyOfOthersRatingGroup, "Tab");
        await _ui.FillAsync(_locators.PropertyOfOthersLimit, _data.Resolve("{{data:property_of_others_limit_220}}"));
        await _ui.PressAsync(_locators.PropertyOfOthersLimit, "Tab");
        await _ui.PressAsync(_locators.PropertyOfOthersLimit, "Tab");
        if (_data.Condition("(State ==\"OR\")||(State==\"WA\")"))
        {
            await _ui.FillAsync(_locators.SearchValue54F3C, _data.Resolve("{{data:search_value_221}}"));
            await _ui.PressAsync(_locators.SearchValue54F3C, "CLICK");
            await _ui.PressAsync(_locators.SearchValue54F3C, "Tab");
            await _ui.PressAsync(_locators.SearchValue54F3C, "Tab");
        }
        // PropertyEnterBuildingRCT_b0af04Page.PropertyEnterBuildingRCT_0136_aad19bAsync
        await _ui.ClickAsync(_locators.Detail7F662);
        await _ui.FillAsync(_locators.EstimatorType, _data.Resolve("{{data:estimator_type_223}}"));
        await _ui.PressAsync(_locators.EstimatorType, "Tab");
        await _ui.PressAsync(_locators.EstimatorType, "Tab");
        await _ui.FillAsync(_locators.ValuationType, _data.Resolve("{{data:valuation_type_224}}"));
        await _ui.PressAsync(_locators.ValuationType, "Tab");
        await _ui.PressAsync(_locators.ValuationType, "Tab");
        await _ui.ClickAsync(_locators.CreateValuation);
        await _ui.ClickAsync(_locators.GetCalculatedValue);
        await _ui.ClickAsync(_locators.PropertyEnterBuildingRCTOK);
    }

    // Business step: I complete Property UW Questions
    public async Task CompletePropertyUWQuestionsAsync()
    {
        // CPNavigationLinks_d0fcc0Page.NavigateToPropertyUWQuestions_0143_aad19bAsync
        await _ui.ClickAsync(_locators.PropertyUWQuestions8452C);
        // PropertyUWQuestions_8f0a46Page.UpdateAnswersForPropertyUWQuestions_0144_aad19bAsync
        await _ui.WaitAsync(_locators.PropertyUWQuestions790F2, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswers99D68);
        await _ui.PressAsync(_locators.UpdateAnswers99D68, "Tab");
        await _ui.PressAsync(_locators.UpdateAnswers99D68, "Tab");
        await _ui.PressAsync(_locators.UpdateAnswers99D68, "Tab");
        await _ui.PressAsync(_locators.UpdateAnswers99D68, "Tab");
    }

    // Business step: I select GL Detail
    public async Task SelectGLDetailAsync()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfo_0147_aad19bAsync
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoCPPSpecificFields_d2689aPage.PolicyInfoCPPSpecificFields_0148_aad19bAsync
        if (_data.Condition("'CPP LOB' == \"GL\""))
        {
            await _ui.ClickAsync(_locators.GLDetail);
        }
    }

    // Business step: I add Class
    public async Task AddClassAsync2()
    {
        // GLNavigationLinks_6f2588Page.NavigateToCGLScreen_0151_aad19bAsync
        await _ui.ClickAsync(_locators.CGL08901);
        // CGLMainPage_efe3a4Page.CGLMainPage_0152_aad19bAsync
        await _ui.WaitAsync(_locators.CGLBA8E8, "Exists");
        await _ui.ClickAsync(_locators.AddClassB04B6);
        // CGLAddClass_42221ePage.CGLAddClass_0153_aad19bAsync
        await _ui.FillAsync(_locators.SearchResults5209C, _data.Resolve("{{data:search_results_280}}"));
        await _ui.PressAsync(_locators.SearchResults5209C, "Tab");
        await _ui.ClickAsync(_locators.AddClassOK);
        // CGLMainPage_efe3a4Page.CGLAddClassExposure_0154_aad19bAsync
        await _ui.FillAsync(_locators.Exposure, _data.Resolve("{{data:exposure_282}}"));
        await _ui.PressAsync(_locators.Exposure, "Tab");
        await _ui.ClickAsync(_locators.MainPageOK);
    }

    // Business step: I add \[CG0435\] Employee Benefits Liability Endorsement
    public async Task AddCG0435EmployeeBenefitsLiabilityEndorsementAsync2()
    {
        // GLNavigationLinks_6f2588Page.NavigateToEndorsementsScreen_0155_aad19bAsync
        if (_data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
            await _ui.ClickAsync(_locators.Endorsements7572E);
        }
        // EndorsementsMain_a2a05aPage.EndorsementsMain_0156_aad19bAsync
        await _ui.WaitAsync(_locators.Endorsements9626E, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsementA9973);
        // CG0435EmployeeBenefitsLiability_f2059fPage.AddCG0435EmployeeBenefitsLiabilityEndorsement_0157_aad19bAsync
        await _ui.FillAsync(_locators.EndorsementTypeA2928, _data.Resolve("{{data:endorsement_type_287}}"));
        await _ui.PressAsync(_locators.EndorsementTypeA2928, "Tab");
        await _ui.FillAsync(_locators.NumberOfEmployees, _data.Resolve("{{data:number_of_employees_288}}"));
        await _ui.PressAsync(_locators.NumberOfEmployees, "Tab");
        await _ui.ClickAsync(_locators.CG0435EmployeeBenefitsLiabilityOK);
    }

    // Business step: I add \[CG2142\] Exclusion \- Explosion, Collapse and Underground Property Damage Hazard \(Specified Operations\)
    public async Task AddCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsAsync2()
    {
        // GLNavigationLinks_6f2588Page.NavigateToEndorsementsScreen_0158_aad19bAsync
        if (_data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
            await _ui.ClickAsync(_locators.Endorsements7572E);
        }
        // EndorsementsMain_a2a05aPage.EndorsementsMain_0159_aad19bAsync
        await _ui.WaitAsync(_locators.Endorsements9626E, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsementA9973);
        // CG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperations_00e769Page.AddCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsEndorsement_0160_aad19bAsync
        await _ui.FillAsync(_locators.EndorsementTypeB210C, _data.Resolve("{{data:endorsement_type_293}}"));
        await _ui.PressAsync(_locators.EndorsementTypeB210C, "Tab");
        await _ui.SmartSetAsync(_locators.ExcludeExplosionHazard, _data.Resolve("{{data:exclude_explosion_hazard_294}}"));
        await _ui.PressAsync(_locators.ExcludeExplosionHazard, "Tab");
        await _ui.SmartSetAsync(_locators.ExcludeCollapseHazard, _data.Resolve("{{data:exclude_collapse_hazard_295}}"));
        await _ui.PressAsync(_locators.ExcludeCollapseHazard, "Tab");
        await _ui.SmartSetAsync(_locators.ExcludeUndergroundPropertyDamageHazard, _data.Resolve("{{data:exclude_underground_property_damage_hazard_296}}"));
        await _ui.PressAsync(_locators.ExcludeUndergroundPropertyDamageHazard, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfOperationS, _data.Resolve("{{data:description_of_operation_s_297}}"));
        await _ui.PressAsync(_locators.DescriptionOfOperationS, "Tab");
        if (_data.Condition("State != \"VA\""))
        {
            await _ui.ClickAsync(_locators.CG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsOK);
        }
        if (_data.Condition("State == \"VA\""))
        {
            await _ui.ClickAsync(_locators.CG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsOK);
        }
    }

    // Business step: I add \[CG 2149\] Total Pollution Exclusion Endorsement
    public async Task AddCG2149TotalPollutionExclusionEndorsementAsync2()
    {
        // GLNavigationLinks_6f2588Page.NavigateToEndorsementsScreen_0161_aad19bAsync
        if (_data.Condition("'Navigate to Endorsements Screen first time' != NULL"))
        {
            await _ui.ClickAsync(_locators.Endorsements7572E);
        }
        // EndorsementsMain_a2a05aPage.EndorsementsMain_0162_aad19bAsync
        await _ui.WaitAsync(_locators.Endorsements9626E, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsementA9973);
        // CG2149TotalPollutionExclusionEndorsement_500b4fPage.AddCG2149TotalPollutionExclusionEndorsement_0163_aad19bAsync
        await _ui.FillAsync(_locators.EndorsementTypeD83A4, _data.Resolve("{{data:endorsement_type_303}}"));
        await _ui.PressAsync(_locators.EndorsementTypeD83A4, "Tab");
        await _ui.ClickAsync(_locators.CG2149TotalPollutionExclusionEndorsementOK);
    }

    // Business step: I add Addl Interest \[CG2007\] \- Engineers
    public async Task AddAddlInterestCG2007EngineersAsync2()
    {
        // GLNavigationLinks_6f2588Page.NavigateToAddlInterestsScreen_0166_aad19bAsync
        await _ui.ClickAsync(_locators.AddlInterestsE39FC);
        // AddlInterestsMain_75443cPage.SelectAddlInterestsButton_0167_aad19bAsync
        await _ui.WaitAsync(_locators.AddlInterestsA10A4, "Exists");
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // CG2007AddLInsuredEngineersArchitects_cacd4ePage.AddCG2007AddLInsuredEngineersArchitects_0168_aad19bAsync
        if (_data.Condition("Type != NULL"))
        {
            await _ui.WaitAsync(_locators.TypeD0639, "Exists");
        }
        await _ui.ClickAsync(_locators.CG2007AddLInsuredEngineersArchitectsOK);
        if (_data.Condition("Type != NULL"))
        {
            await _ui.ClickAsync(_locators.TypeD0639);
        }
        if (_data.Condition("Type != NULL"))
        {
            await _ui.FillAsync(_locators.TypeD0639, _data.Resolve("{{data:type_319}}"));
            await _ui.PressAsync(_locators.TypeD0639, "Enter");
            await _ui.PressAsync(_locators.TypeD0639, "Tab");
        }
    }

    // Business step: I add Addl Interest \[CG2020\] Add'l Insured\-Charitable Institution
    public async Task AddAddlInterestCG2020AddLInsuredCharitableInstitutionAsync2()
    {
        // GLNavigationLinks_6f2588Page.NavigateToAddlInterestsScreen_0169_aad19bAsync
        await _ui.ClickAsync(_locators.AddlInterestsE39FC);
        // AddlInterestsMain_75443cPage.SelectAddlInterestsButton_0170_aad19bAsync
        await _ui.WaitAsync(_locators.AddlInterestsA10A4, "Exists");
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // CG2020AddLInsuredCharitableInstitution_e6edeePage.AddCG2020AddLInsuredCharitableInstitution_0171_aad19bAsync
        if (_data.Condition("Type != NULL"))
        {
            await _ui.FillAsync(_locators.TypeA75B5, _data.Resolve("{{data:type_323}}"));
            await _ui.PressAsync(_locators.TypeA75B5, "Tab");
        }
        if (_data.Condition("'Type of License' != NULL"))
        {
            await _ui.FillAsync(_locators.TypeOfLicense, _data.Resolve("{{data:type_of_license_324}}"));
            await _ui.PressAsync(_locators.TypeOfLicense, "Tab");
            await _ui.PressAsync(_locators.TypeOfLicense, "CLICK");
            await _ui.PressAsync(_locators.TypeOfLicense, "Tab");
        }
        await _ui.ClickAsync(_locators.CG2020AddLInsuredCharitableInstitutionOK);
    }

    // Business step: I add Addl Interest \[CG2023\] Add'l Insured\-Executors
    public async Task AddAddlInterestCG2023AddLInsuredExecutorsAsync2()
    {
        // GLNavigationLinks_6f2588Page.NavigateToAddlInterestsScreen_0172_aad19bAsync
        await _ui.ClickAsync(_locators.AddlInterestsE39FC);
        // AddlInterestsMain_75443cPage.SelectAddlInterestsButton_0173_aad19bAsync
        await _ui.WaitAsync(_locators.AddlInterestsA10A4, "Exists");
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // CG2023AddLInsuredExecutors_a048ecPage.AddCG2023AddLInsuredExecutors_0174_aad19bAsync
        if (_data.Condition("Type != NULL"))
        {
            await _ui.FillAsync(_locators.TypeD972C, _data.Resolve("{{data:type_329}}"));
            await _ui.PressAsync(_locators.TypeD972C, "Tab");
        }
        await _ui.ClickAsync(_locators.OK);
    }

    // Business step: I add Addl Interest \[CG2025\] Add'l Insured\-Executive Officers
    public async Task AddAddlInterestCG2025AddLInsuredExecutiveOfficersAsync2()
    {
        // GLNavigationLinks_6f2588Page.NavigateToAddlInterestsScreen_0175_aad19bAsync
        await _ui.ClickAsync(_locators.AddlInterestsE39FC);
        // AddlInterestsMain_75443cPage.SelectAddlInterestsButton_0176_aad19bAsync
        await _ui.WaitAsync(_locators.AddlInterestsA10A4, "Exists");
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // CG2025AddLInsuredExecutiveOfficers_fa3c1aPage.AddCG2025AddLInsuredExecutiveOfficers_0177_aad19bAsync
        if (_data.Condition("Type != NULL"))
        {
            await _ui.FillAsync(_locators.TypeD972C, _data.Resolve("{{data:type_334}}"));
            await _ui.PressAsync(_locators.TypeD972C, "Tab");
        }
        await _ui.ClickAsync(_locators.OK);
    }

    // Business step: I add Addl Interest \[CG2034\] Add'l Insured\-Leased Equipment Automatic
    public async Task AddAddlInterestCG2034AddLInsuredLeasedEquipmentAutomaticAsync2()
    {
        // GLNavigationLinks_6f2588Page.NavigateToAddlInterestsScreen_0178_aad19bAsync
        await _ui.ClickAsync(_locators.AddlInterestsE39FC);
        // AddlInterestsMain_75443cPage.SelectAddlInterestsButton_0179_aad19bAsync
        await _ui.WaitAsync(_locators.AddlInterestsA10A4, "Exists");
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // CG2034AddLInsuredLeasedEquipmentAutomatic_7d6157Page.AddCG2034AddLInsuredLeasedEquipmentAutomatic_0180_aad19bAsync
        if (_data.Condition("Type != NULL"))
        {
            await _ui.FillAsync(_locators.TypeD972C, _data.Resolve("{{data:type_339}}"));
            await _ui.PressAsync(_locators.TypeD972C, "Tab");
        }
        if (_data.Condition("'Type of Equipment' != NULL"))
        {
            await _ui.FillAsync(_locators.TypeOfEquipment, _data.Resolve("{{data:type_of_equipment_340}}"));
            await _ui.PressAsync(_locators.TypeOfEquipment, "CLICK");
            await _ui.PressAsync(_locators.TypeOfEquipment, "Tab");
        }
        await _ui.ClickAsync(_locators.OK);
    }

    // Business step: I answer GL UW Questions OR \& WA
    public async Task AnswerGLUWQuestionsORWAAsync3()
    {
        // GLNavigationLinks_6f2588Page.NavigateToGLUWQuestions_0181_aad19bAsync
        await _ui.ClickAsync(_locators.GLUWQuestions);
        // GeneralLiabilityInformation_459030Page.AnswerGeneralLiabilityInformationQuestions_0182_aad19bAsync
        await _ui.WaitAsync(_locators.GeneralLiabilityInformation, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswersFB765);
        await _ui.FillAsync(_locators.DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy, _data.Resolve("{{data:describe_all_hold_harmless_agreements_and_please_provide_a_copy_345}}"));
        await _ui.PressAsync(_locators.DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy, "Tab");
        await _ui.PressAsync(_locators.DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy, "Tab");
        await _ui.ClickAsync(_locators.GeneralLiabilityInformationOK);
        // GLNavigationLinks_6f2588Page.NavigateToGLUWQuestions_0183_aad19bAsync
        await _ui.ClickAsync(_locators.GLUWQuestions);
        // GeneralLiabilityInformation_459030Page.WaitForGeneralLiabilityScreenToLoad_0184_aad19bAsync
        await _ui.WaitAsync(_locators.GeneralLiabilityInformation, "Exists");
        // ProductsCompletedOps_e712ddPage.AnswerProductsCompletedOpsQuestion_0185_aad19bAsync
        await _ui.ClickAsync(_locators.ProductsCompletedOpsButton);
        await _ui.WaitAsync(_locators.ProductsCompletedOps, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswers69564);
        await _ui.ClickAsync(_locators.ProductsCompletedOpsOK);
    }

    // Business step: I add Bailees Customers Coverage
    public async Task AddBaileesCustomersCoverageAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToPolicyCovgScreen_0191_aad19bAsync
        await _ui.ClickAsync(_locators.PolicyCovgED95C);
        // PolicyCovgMain_ddd7eePage.PolicyCovgMain_0192_aad19bAsync
        await _ui.WaitAsync(_locators.PolicyCovgF9E58, "Exists");
        await _ui.FillAsync(_locators.CoverageFormToBeAdded, _data.Resolve("{{data:coverage_form_to_be_added_365}}"));
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Enter");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.ClickAsync(_locators.AddCoverageForm);
        // PolicyCovgBaileesCutomers_36b666Page.AddPolicyCovgBaileesCustomers_0193_aad19bAsync
        await _ui.WaitAsync(_locators.CoverageFormDisplay6F446, "Exists");
        await _ui.PressAsync(_locators.Description43F2D, "PRE:TAB");
        await _ui.PressAsync(_locators.Description43F2D, "Tab");
        await _ui.FillAsync(_locators.Description43F2D, _data.Resolve("{{data:description_369}}"));
        await _ui.PressAsync(_locators.Description43F2D, "CLICK");
        await _ui.PressAsync(_locators.Description43F2D, "Enter");
        await _ui.PressAsync(_locators.Description43F2D, "Tab");
        await _ui.FillAsync(_locators.PropertyInTransit710FF, _data.Resolve("{{data:property_in_transit_370}}"));
        await _ui.PressAsync(_locators.PropertyInTransit710FF, "Tab");
        await _ui.PressAsync(_locators.PropertyInTransit710FF, "Tab");
        await _ui.ClickAsync(_locators.PropertyAwayFromYourPremisesSchedule);
        // PolicyCovgBaileesPropertyAwayFromYourPremises_15f47ePage.PolicyCovgBaileesPropertyAwayFromYourPremises_0194_aad19bAsync
        await _ui.ClickAsync(_locators.AddPremises);
        await _ui.FillAsync(_locators.AddressStreetCityStateZip, _data.Resolve("{{data:address_street_city_state_zip_373}}"));
        await _ui.PressAsync(_locators.AddressStreetCityStateZip, "CLICK");
        await _ui.PressAsync(_locators.AddressStreetCityStateZip, "Tab");
        await _ui.FillAsync(_locators.Limit46632, _data.Resolve("{{data:limit_374}}"));
        await _ui.PressAsync(_locators.Limit46632, "Tab");
        await _ui.PressAsync(_locators.Limit46632, "Tab");
        await _ui.ClickAsync(_locators.PolicyCovgBaileesPropertyAwayFromYourPremisesOK);
        // PolicyCovgBaileesCutomers_36b666Page.PolicyCovgBaileesCutomersSelectOKToCompleteCoverage_0195_aad19bAsync
        await _ui.WaitAsync(_locators.CoverageFormDisplay6F446, "Exists");
        await _ui.ClickAsync(_locators.PolicyCovgBaileesCutomersOK);
    }

    // Business step: I add Computer Systems
    public async Task AddComputerSystemsAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToPolicyCovgScreen_0196_aad19bAsync
        await _ui.ClickAsync(_locators.PolicyCovgED95C);
        // PolicyCovgMain_ddd7eePage.PolicyCovgMain_0197_aad19bAsync
        await _ui.WaitAsync(_locators.PolicyCovgF9E58, "Exists");
        await _ui.FillAsync(_locators.CoverageFormToBeAdded, _data.Resolve("{{data:coverage_form_to_be_added_380}}"));
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Enter");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.ClickAsync(_locators.AddCoverageForm);
        // PolicyCovgComputerSystems_963e4ePage.PolicyCovgComputerSystems_0198_aad19bAsync
        await _ui.WaitAsync(_locators.CoverageFormDisplay2ECD4, "Exists");
        await _ui.PressAsync(_locators.Description58EC2, "PRE:TAB");
        await _ui.PressAsync(_locators.Description58EC2, "Tab");
        await _ui.FillAsync(_locators.Description58EC2, _data.Resolve("{{data:description_384}}"));
        await _ui.PressAsync(_locators.Description58EC2, "CLICK");
        await _ui.PressAsync(_locators.Description58EC2, "Enter");
        await _ui.PressAsync(_locators.Description58EC2, "Tab");
        await _ui.FillAsync(_locators.DeductibleC91E9, _data.Resolve("{{data:deductible_385}}"));
        await _ui.PressAsync(_locators.DeductibleC91E9, "Tab");
        await _ui.PressAsync(_locators.DeductibleC91E9, "Tab");
        await _ui.FillAsync(_locators.Coinsurance01AB1, _data.Resolve("{{data:coinsurance_386}}"));
        await _ui.PressAsync(_locators.Coinsurance01AB1, "Tab");
        await _ui.PressAsync(_locators.Coinsurance01AB1, "Tab");
        await _ui.FillAsync(_locators.PropertyInTransit6E905, _data.Resolve("{{data:property_in_transit_387}}"));
        await _ui.PressAsync(_locators.PropertyInTransit6E905, "Tab");
        await _ui.PressAsync(_locators.PropertyInTransit6E905, "Tab");
        await _ui.FillAsync(_locators.UnnamedPremises, _data.Resolve("{{data:unnamed_premises_388}}"));
        await _ui.PressAsync(_locators.UnnamedPremises, "Tab");
        await _ui.PressAsync(_locators.UnnamedPremises, "Tab");
        await _ui.FillAsync(_locators.PersonalPortableComputers, _data.Resolve("{{data:personal_portable_computers_389}}"));
        await _ui.PressAsync(_locators.PersonalPortableComputers, "Tab");
        await _ui.PressAsync(_locators.PersonalPortableComputers, "Tab");
        await _ui.FillAsync(_locators.ExtraExpense, _data.Resolve("{{data:extra_expense_390}}"));
        await _ui.PressAsync(_locators.ExtraExpense, "Tab");
        await _ui.PressAsync(_locators.ExtraExpense, "Tab");
        await _ui.FillAsync(_locators.VirusHarmfulCodeOrSimilarInstruction, _data.Resolve("{{data:virus_harmful_code_or_similar_instruction_391}}"));
        await _ui.PressAsync(_locators.VirusHarmfulCodeOrSimilarInstruction, "Tab");
        await _ui.PressAsync(_locators.VirusHarmfulCodeOrSimilarInstruction, "Tab");
        await _ui.ClickAsync(_locators.PolicyCovgComputerSystemsOK);
    }

    // Business step: I add Contractors Equipment
    public async Task AddContractorsEquipmentAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToPolicyCovgScreen_0199_aad19bAsync
        await _ui.ClickAsync(_locators.PolicyCovgED95C);
        // PolicyCovgMain_ddd7eePage.PolicyCovgMain_0200_aad19bAsync
        await _ui.WaitAsync(_locators.PolicyCovgF9E58, "Exists");
        await _ui.FillAsync(_locators.CoverageFormToBeAdded, _data.Resolve("{{data:coverage_form_to_be_added_395}}"));
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Enter");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.ClickAsync(_locators.AddCoverageForm);
        // PolicyCovgContractorsEquipment_9bad08Page.AddPolicyCovgContractorsEquipment_0201_aad19bAsync
        await _ui.WaitAsync(_locators.CoverageFormDisplayD1A9B, "Exists");
        await _ui.PressAsync(_locators.Description03789, "PRE:TAB");
        await _ui.PressAsync(_locators.Description03789, "Tab");
        await _ui.FillAsync(_locators.Description03789, _data.Resolve("{{data:description_399}}"));
        await _ui.PressAsync(_locators.Description03789, "Tab");
        await _ui.PressAsync(_locators.Description03789, "CLICK");
        await _ui.PressAsync(_locators.Description03789, "Tab");
        await _ui.FillAsync(_locators.CoinsuranceC9726, _data.Resolve("{{data:coinsurance_400}}"));
        await _ui.PressAsync(_locators.CoinsuranceC9726, "Tab");
        await _ui.PressAsync(_locators.CoinsuranceC9726, "CLICK");
        await _ui.PressAsync(_locators.CoinsuranceC9726, "Tab");
        await _ui.FillAsync(_locators.DeductibleC227C, _data.Resolve("{{data:deductible_401}}"));
        await _ui.PressAsync(_locators.DeductibleC227C, "Tab");
        await _ui.PressAsync(_locators.DeductibleC227C, "CLICK");
        await _ui.PressAsync(_locators.DeductibleC227C, "Tab");
        await _ui.FillAsync(_locators.BoomDeductible, _data.Resolve("{{data:boom_deductible_402}}"));
        await _ui.PressAsync(_locators.BoomDeductible, "Tab");
        await _ui.PressAsync(_locators.BoomDeductible, "CLICK");
        await _ui.PressAsync(_locators.BoomDeductible, "Tab");
        await _ui.FillAsync(_locators.TypeOfContractor, _data.Resolve("{{data:type_of_contractor_403}}"));
        await _ui.PressAsync(_locators.TypeOfContractor, "Tab");
        await _ui.PressAsync(_locators.TypeOfContractor, "CLICK");
        await _ui.PressAsync(_locators.TypeOfContractor, "Tab");
        await _ui.FillAsync(_locators.ScheduledCoverage, _data.Resolve("{{data:scheduled_coverage_404}}"));
        await _ui.PressAsync(_locators.ScheduledCoverage, "Tab");
        await _ui.PressAsync(_locators.ScheduledCoverage, "CLICK");
        await _ui.PressAsync(_locators.ScheduledCoverage, "Tab");
        await _ui.FillAsync(_locators.RentedEquipmentExpense, _data.Resolve("{{data:rented_equipment_expense_405}}"));
        await _ui.PressAsync(_locators.RentedEquipmentExpense, "Tab");
        await _ui.PressAsync(_locators.RentedEquipmentExpense, "CLICK");
        await _ui.PressAsync(_locators.RentedEquipmentExpense, "Tab");
        await _ui.FillAsync(_locators.ToolsAndClothingBelongingToYourEmployees, _data.Resolve("{{data:tools_and_clothing_belonging_to_your_employees_406}}"));
        await _ui.PressAsync(_locators.ToolsAndClothingBelongingToYourEmployees, "Tab");
        await _ui.PressAsync(_locators.ToolsAndClothingBelongingToYourEmployees, "CLICK");
        await _ui.PressAsync(_locators.ToolsAndClothingBelongingToYourEmployees, "Tab");
        await _ui.FillAsync(_locators.MiscItemsBlanketCoverage, _data.Resolve("{{data:misc_items_blanket_coverage_407}}"));
        await _ui.PressAsync(_locators.MiscItemsBlanketCoverage, "Tab");
        await _ui.PressAsync(_locators.MiscItemsBlanketCoverage, "CLICK");
        await _ui.PressAsync(_locators.MiscItemsBlanketCoverage, "Tab");
        await _ui.FillAsync(_locators.RentalReimbursement, _data.Resolve("{{data:rental_reimbursement_408}}"));
        await _ui.PressAsync(_locators.RentalReimbursement, "Tab");
        await _ui.PressAsync(_locators.RentalReimbursement, "CLICK");
        await _ui.PressAsync(_locators.RentalReimbursement, "Tab");
        await _ui.FillAsync(_locators.HiredEquipment, _data.Resolve("{{data:hired_equipment_409}}"));
        await _ui.PressAsync(_locators.HiredEquipment, "Tab");
        await _ui.PressAsync(_locators.HiredEquipment, "CLICK");
        await _ui.PressAsync(_locators.HiredEquipment, "Tab");
        await _ui.ClickAsync(_locators.PolicyCovgContractorsEquipmentOK);
    }

    // Business step: I add Motor Truck Cargo
    public async Task AddMotorTruckCargoAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToPolicyCovgScreen_0202_aad19bAsync
        await _ui.ClickAsync(_locators.PolicyCovgED95C);
        // PolicyCovgMain_ddd7eePage.PolicyCovgMain_0203_aad19bAsync
        await _ui.WaitAsync(_locators.PolicyCovgF9E58, "Exists");
        await _ui.FillAsync(_locators.CoverageFormToBeAdded, _data.Resolve("{{data:coverage_form_to_be_added_413}}"));
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Enter");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.ClickAsync(_locators.AddCoverageForm);
        // PolicyCovgMotorTruckCargo_0d23c6Page.PolicyCovgMotorTruckCargo_0204_aad19bAsync
        await _ui.WaitAsync(_locators.CoverageFormDisplayB69C2, "Exists");
        await _ui.PressAsync(_locators.DescriptionF8E60, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionF8E60, "Tab");
        await _ui.FillAsync(_locators.DescriptionF8E60, _data.Resolve("{{data:description_417}}"));
        await _ui.PressAsync(_locators.DescriptionF8E60, "Tab");
        await _ui.PressAsync(_locators.DescriptionF8E60, "CLICK");
        await _ui.PressAsync(_locators.DescriptionF8E60, "Enter");
        await _ui.PressAsync(_locators.DescriptionF8E60, "Tab");
        await _ui.FillAsync(_locators.CoverageType, _data.Resolve("{{data:coverage_type_418}}"));
        await _ui.PressAsync(_locators.CoverageType, "Tab");
        await _ui.PressAsync(_locators.CoverageType, "Tab");
        await _ui.PressAsync(_locators.CoverageType, "Tab");
        await _ui.FillAsync(_locators.CoveredPropertyConsistingPrincipallyOf, _data.Resolve("{{data:covered_property_consisting_principally_of_419}}"));
        await _ui.PressAsync(_locators.CoveredPropertyConsistingPrincipallyOf, "Tab");
        await _ui.PressAsync(_locators.CoveredPropertyConsistingPrincipallyOf, "Tab");
        await _ui.FillAsync(_locators.Deductible320C9, _data.Resolve("{{data:deductible_420}}"));
        await _ui.PressAsync(_locators.Deductible320C9, "Tab");
        await _ui.PressAsync(_locators.Deductible320C9, "Tab");
        await _ui.FillAsync(_locators.PerVehicleLimit, _data.Resolve("{{data:per_vehicle_limit_421}}"));
        await _ui.PressAsync(_locators.PerVehicleLimit, "Tab");
        await _ui.PressAsync(_locators.PerVehicleLimit, "Tab");
        await _ui.FillAsync(_locators.GroupClass, _data.Resolve("{{data:group_class_422}}"));
        await _ui.PressAsync(_locators.GroupClass, "Tab");
        await _ui.PressAsync(_locators.GroupClass, "Tab");
        await _ui.FillAsync(_locators.NumberOfVehicles, _data.Resolve("{{data:number_of_vehicles_423}}"));
        await _ui.PressAsync(_locators.NumberOfVehicles, "Tab");
        await _ui.PressAsync(_locators.NumberOfVehicles, "Tab");
        await _ui.FillAsync(_locators.UnnamedTerminalsLimit, _data.Resolve("{{data:unnamed_terminals_limit_424}}"));
        await _ui.PressAsync(_locators.UnnamedTerminalsLimit, "Tab");
        await _ui.PressAsync(_locators.UnnamedTerminalsLimit, "Tab");
        await _ui.ClickAsync(_locators.PolicyCovgMotorTruckCargoOK);
    }

    // Business step: I add Signs
    public async Task AddSignsAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToPolicyCovgScreen_0205_aad19bAsync
        await _ui.ClickAsync(_locators.PolicyCovgED95C);
        // PolicyCovgMain_ddd7eePage.PolicyCovgMain_0206_aad19bAsync
        await _ui.WaitAsync(_locators.PolicyCovgF9E58, "Exists");
        await _ui.FillAsync(_locators.CoverageFormToBeAdded, _data.Resolve("{{data:coverage_form_to_be_added_428}}"));
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Enter");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.ClickAsync(_locators.AddCoverageForm);
        // PolicyCovgSigns_aa9a0ePage.PolicyCovgSigns_0207_aad19bAsync
        await _ui.WaitAsync(_locators.CoverageFormDisplayC10BA, "Exists");
        await _ui.PressAsync(_locators.DescriptionBE47E, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionBE47E, "Tab");
        await _ui.FillAsync(_locators.DescriptionBE47E, _data.Resolve("{{data:description_432}}"));
        await _ui.PressAsync(_locators.DescriptionBE47E, "Tab");
        await _ui.PressAsync(_locators.DescriptionBE47E, "CLICK");
        await _ui.PressAsync(_locators.DescriptionBE47E, "Enter");
        await _ui.PressAsync(_locators.DescriptionBE47E, "Tab");
        await _ui.VerifyAsync(_locators.CoverageFormA7F96, _data.Resolve("Exists"), "");
        await _ui.FillAsync(_locators.N5Deductible, _data.Resolve("{{data:5_deductible_434}}"));
        await _ui.PressAsync(_locators.N5Deductible, "Tab");
        await _ui.PressAsync(_locators.N5Deductible, "Tab");
        await _ui.ClickAsync(_locators.PolicyCovgSignsOK);
        // TBoxWait_7ea9e1Page.WaitForPriorScreenToUpdate_0208_aad19bAsync
        await Task.Delay(1000);
    }

    // Business step: I add Accounts Receivable
    public async Task AddAccountsReceivableAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToRiskScreen_0209_aad19bAsync
        await _ui.ClickAsync(_locators.Risk5D6FA);
        // RiskMain_2f5e40Page.RiskMain_0210_aad19bAsync
        await _ui.WaitAsync(_locators.Risk873E7, "Exists");
        await _ui.FillAsync(_locators.CoverageFormCFDD1, _data.Resolve("{{data:coverage_form_439}}"));
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.ClickAsync(_locators.Add);
        // RiskAccountsReceivable_1ef8eePage.RiskAccountsReceivable_0211_aad19bAsync
        await _ui.WaitAsync(_locators.AccountsReceivableHeading, "Exists");
        await _ui.PressAsync(_locators.SearchValue79E46, "PRE:TAB");
        await _ui.PressAsync(_locators.SearchValue79E46, "Tab");
        await _ui.FillAsync(_locators.SearchValue79E46, _data.Resolve("{{data:search_value_443}}"));
        await _ui.PressAsync(_locators.SearchValue79E46, "Tab");
        await _ui.PressAsync(_locators.SearchValue79E46, "CLICK");
        await _ui.PressAsync(_locators.SearchValue79E46, "Tab");
        await _ui.FillAsync(_locators.SearchResultEAFB8, _data.Resolve("{{data:search_result_444}}"));
        await _ui.PressAsync(_locators.SearchResultEAFB8, "Tab");
        await _ui.PressAsync(_locators.SearchResultEAFB8, "CLICK");
        await _ui.PressAsync(_locators.SearchResultEAFB8, "Enter");
        await _ui.PressAsync(_locators.SearchResultEAFB8, "Tab");
        await _ui.FillAsync(_locators.ConstructionFB8D9, _data.Resolve("{{data:construction_445}}"));
        await _ui.PressAsync(_locators.ConstructionFB8D9, "Tab");
        await _ui.PressAsync(_locators.ConstructionFB8D9, "CLICK");
        await _ui.PressAsync(_locators.ConstructionFB8D9, "Tab");
        await _ui.FillAsync(_locators.PremisesType, _data.Resolve("{{data:premises_type_446}}"));
        await _ui.PressAsync(_locators.PremisesType, "Tab");
        await _ui.PressAsync(_locators.PremisesType, "CLICK");
        await _ui.PressAsync(_locators.PremisesType, "Tab");
        await _ui.FillAsync(_locators.DuplicatedRecords, _data.Resolve("{{data:duplicated_records_447}}"));
        await _ui.PressAsync(_locators.DuplicatedRecords, "Tab");
        await _ui.PressAsync(_locators.DuplicatedRecords, "CLICK");
        await _ui.PressAsync(_locators.DuplicatedRecords, "Tab");
        await _ui.FillAsync(_locators.ClassificationOfRisk, _data.Resolve("{{data:classification_of_risk_448}}"));
        await _ui.PressAsync(_locators.ClassificationOfRisk, "Tab");
        await _ui.PressAsync(_locators.ClassificationOfRisk, "CLICK");
        await _ui.PressAsync(_locators.ClassificationOfRisk, "Tab");
        await _ui.ClickAsync(_locators.RiskAccountsReceivableOK);
    }

    // Business step: I add Bailees Customers
    public async Task AddBaileesCustomersAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToRiskScreen_0217_aad19bAsync
        await _ui.ClickAsync(_locators.Risk5D6FA);
        // RiskMain_2f5e40Page.RiskMain_0218_aad19bAsync
        await _ui.WaitAsync(_locators.Risk873E7, "Exists");
        await _ui.FillAsync(_locators.CoverageFormCFDD1, _data.Resolve("{{data:coverage_form_460}}"));
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.ClickAsync(_locators.Add);
        // RiskBaileesCustomers_a875f1Page.RiskBaileesCustomers_0219_aad19bAsync
        await _ui.WaitAsync(_locators.BaileesCustomersHeading, "Exists");
        await _ui.FillAsync(_locators.Deductible59155, _data.Resolve("{{data:deductible_463}}"));
        await _ui.PressAsync(_locators.Deductible59155, "Tab");
        await _ui.PressAsync(_locators.Deductible59155, "CLICK");
        await _ui.PressAsync(_locators.Deductible59155, "Tab");
        await _ui.PressAsync(_locators.SearchValueCA6A6, "PRE:TAB");
        await _ui.PressAsync(_locators.SearchValueCA6A6, "Tab");
        await _ui.FillAsync(_locators.SearchValueCA6A6, _data.Resolve("{{data:search_value_465}}"));
        await _ui.PressAsync(_locators.SearchValueCA6A6, "CLICK");
        await _ui.PressAsync(_locators.SearchValueCA6A6, "Tab");
        await _ui.PressAsync(_locators.SearchValueCA6A6, "Tab");
        await _ui.FillAsync(_locators.SearchResultA1BFB, _data.Resolve("{{data:search_result_466}}"));
        await _ui.PressAsync(_locators.SearchResultA1BFB, "Tab");
        await _ui.PressAsync(_locators.SearchResultA1BFB, "CLICK");
        await _ui.PressAsync(_locators.SearchResultA1BFB, "Enter");
        await _ui.PressAsync(_locators.SearchResultA1BFB, "Tab");
        await _ui.FillAsync(_locators.ConstructionCD2DE, _data.Resolve("{{data:construction_467}}"));
        await _ui.PressAsync(_locators.ConstructionCD2DE, "Tab");
        await _ui.PressAsync(_locators.ConstructionCD2DE, "CLICK");
        await _ui.PressAsync(_locators.ConstructionCD2DE, "Tab");
        await _ui.FillAsync(_locators.AnnualGrossReceipts, _data.Resolve("{{data:annual_gross_receipts_468}}"));
        await _ui.PressAsync(_locators.AnnualGrossReceipts, "Tab");
        await _ui.PressAsync(_locators.AnnualGrossReceipts, "CLICK");
        await _ui.PressAsync(_locators.AnnualGrossReceipts, "Tab");
        await _ui.FillAsync(_locators.AverageNumberOfDaysService, _data.Resolve("{{data:average_number_of_days_service_469}}"));
        await _ui.PressAsync(_locators.AverageNumberOfDaysService, "Tab");
        await _ui.PressAsync(_locators.AverageNumberOfDaysService, "CLICK");
        await _ui.PressAsync(_locators.AverageNumberOfDaysService, "Tab");
        await _ui.FillAsync(_locators.AverageNumberOfWorkingDays, _data.Resolve("{{data:average_number_of_working_days_470}}"));
        await _ui.PressAsync(_locators.AverageNumberOfWorkingDays, "Tab");
        await _ui.PressAsync(_locators.AverageNumberOfWorkingDays, "CLICK");
        await _ui.PressAsync(_locators.AverageNumberOfWorkingDays, "Tab");
        await _ui.FillAsync(_locators.AverageServiceCharge, _data.Resolve("{{data:average_service_charge_471}}"));
        await _ui.PressAsync(_locators.AverageServiceCharge, "Tab");
        await _ui.PressAsync(_locators.AverageServiceCharge, "CLICK");
        await _ui.PressAsync(_locators.AverageServiceCharge, "Tab");
        await _ui.FillAsync(_locators.AverageValuePerOrder, _data.Resolve("{{data:average_value_per_order_472}}"));
        await _ui.PressAsync(_locators.AverageValuePerOrder, "Tab");
        await _ui.PressAsync(_locators.AverageValuePerOrder, "CLICK");
        await _ui.PressAsync(_locators.AverageValuePerOrder, "Tab");
        await _ui.FillAsync(_locators.LimitE32DC, _data.Resolve("{{data:limit_473}}"));
        await _ui.PressAsync(_locators.LimitE32DC, "Tab");
        await _ui.PressAsync(_locators.LimitE32DC, "CLICK");
        await _ui.PressAsync(_locators.LimitE32DC, "Tab");
        await _ui.FillAsync(_locators.Earthquake, _data.Resolve("{{data:earthquake_474}}"));
        await _ui.PressAsync(_locators.Earthquake, "Tab");
        await _ui.PressAsync(_locators.Earthquake, "CLICK");
        await _ui.PressAsync(_locators.Earthquake, "Tab");
        await _ui.FillAsync(_locators.StorageLimit, _data.Resolve("{{data:storage_limit_475}}"));
        await _ui.PressAsync(_locators.StorageLimit, "Tab");
        await _ui.PressAsync(_locators.StorageLimit, "CLICK");
        await _ui.PressAsync(_locators.StorageLimit, "Tab");
        await _ui.ClickAsync(_locators.RiskBaileesCustomersOK);
    }

    // Business step: I add Computer Systems for risk
    public async Task AddComputerSystemsForRiskAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToRiskScreen_0225_aad19bAsync
        await _ui.ClickAsync(_locators.Risk5D6FA);
        // RiskMain_2f5e40Page.RiskMain_0226_aad19bAsync
        await _ui.WaitAsync(_locators.Risk873E7, "Exists");
        await _ui.FillAsync(_locators.CoverageFormCFDD1, _data.Resolve("{{data:coverage_form_486}}"));
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.ClickAsync(_locators.Add);
        // RiskComputerSystems_7b4caaPage.RiskComputerEquipment_0227_aad19bAsync
        await _ui.FillAsync(_locators.ComputerEquipment, _data.Resolve("{{data:computer_equipment_488}}"));
        await _ui.PressAsync(_locators.ComputerEquipment, "Tab");
        await _ui.PressAsync(_locators.ComputerEquipment, "CLICK");
        await _ui.PressAsync(_locators.ComputerEquipment, "Tab");
        await _ui.FillAsync(_locators.DataAndMedia, _data.Resolve("{{data:data_and_media_489}}"));
        await _ui.PressAsync(_locators.DataAndMedia, "Tab");
        await _ui.PressAsync(_locators.DataAndMedia, "CLICK");
        await _ui.PressAsync(_locators.DataAndMedia, "Tab");
        await _ui.PressAsync(_locators.SearchValue9FCD1, "PRE:TAB");
        await _ui.PressAsync(_locators.SearchValue9FCD1, "Tab");
        await _ui.FillAsync(_locators.SearchValue9FCD1, _data.Resolve("{{data:search_value_491}}"));
        await _ui.PressAsync(_locators.SearchValue9FCD1, "CLICK");
        await _ui.PressAsync(_locators.SearchValue9FCD1, "Tab");
        await _ui.PressAsync(_locators.SearchValue9FCD1, "Tab");
        await _ui.FillAsync(_locators.SearchResult4E620, _data.Resolve("{{data:search_result_492}}"));
        await _ui.PressAsync(_locators.SearchResult4E620, "Tab");
        await _ui.PressAsync(_locators.SearchResult4E620, "Click");
        await _ui.PressAsync(_locators.SearchResult4E620, "Enter");
        await _ui.PressAsync(_locators.SearchResult4E620, "Tab");
        await _ui.PressAsync(_locators.SearchResult4E620, "Tab");
        await _ui.PressAsync(_locators.SearchResult4E620, "Tab");
        await _ui.FillAsync(_locators.ConstructionCode, _data.Resolve("{{data:construction_code_493}}"));
        await _ui.PressAsync(_locators.ConstructionCode, "Tab");
        await _ui.PressAsync(_locators.ConstructionCode, "CLICK");
        await _ui.PressAsync(_locators.ConstructionCode, "Tab");
        await _ui.ClickAsync(_locators.RiskComputerSystemsOK);
    }

    // Business step: I add Signs for risk
    public async Task AddSignsForRiskAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToRiskScreen_0233_aad19bAsync
        await _ui.ClickAsync(_locators.Risk5D6FA);
        // RiskMain_2f5e40Page.RiskMain_0234_aad19bAsync
        await _ui.WaitAsync(_locators.Risk873E7, "Exists");
        await _ui.FillAsync(_locators.CoverageFormCFDD1, _data.Resolve("{{data:coverage_form_504}}"));
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.ClickAsync(_locators.Add);
        // RiskSigns_af05f3Page.RiskSigns_0235_aad19bAsync
        await _ui.WaitAsync(_locators.SignsHeading, "Exists");
        await _ui.FillAsync(_locators.LimitOfInsurance, _data.Resolve("{{data:limit_of_insurance_507}}"));
        await _ui.PressAsync(_locators.LimitOfInsurance, "Tab");
        await _ui.PressAsync(_locators.LimitOfInsurance, "CLICK");
        await _ui.PressAsync(_locators.LimitOfInsurance, "Tab");
        await _ui.FillAsync(_locators.SignLocation, _data.Resolve("{{data:sign_location_508}}"));
        await _ui.PressAsync(_locators.SignLocation, "Tab");
        await _ui.PressAsync(_locators.SignLocation, "CLICK");
        await _ui.PressAsync(_locators.SignLocation, "Tab");
        await _ui.FillAsync(_locators.TypeB082D, _data.Resolve("{{data:type_509}}"));
        await _ui.PressAsync(_locators.TypeB082D, "Tab");
        await _ui.PressAsync(_locators.TypeB082D, "CLICK");
        await _ui.PressAsync(_locators.TypeB082D, "Tab");
        await _ui.FillAsync(_locators.Lettering, _data.Resolve("{{data:lettering_510}}"));
        await _ui.PressAsync(_locators.Lettering, "Tab");
        await _ui.PressAsync(_locators.Lettering, "CLICK");
        await _ui.PressAsync(_locators.Lettering, "Tab");
        await _ui.ClickAsync(_locators.RiskSignsOK);
    }

    // Business step: I add CM 66 01 Exclude Named Customer
    public async Task AddCM6601ExcludeNamedCustomerAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToEndorsementScreen_0236_aad19bAsync
        await _ui.ClickAsync(_locators.Endorsement);
        // EndorsementMain_0e2165Page.EndorsementMain_0237_aad19bAsync
        await _ui.WaitAsync(_locators.EndorsementHeading, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsement48A9E);
        await _ui.FillAsync(_locators.Type715D6, _data.Resolve("{{data:type_515}}"));
        await _ui.PressAsync(_locators.Type715D6, "CLICK");
        await _ui.PressAsync(_locators.Type715D6, "Tab");
        // EndorsementCM6601ExcludeNamedCustomer_1ccfdfPage.EndorsementCM6601ExcludeNamedCustomer_0238_aad19bAsync
        await _ui.PressAsync(_locators.Names, "PRE:TAB");
        await _ui.PressAsync(_locators.Names, "Tab");
        await _ui.FillAsync(_locators.Names, _data.Resolve("{{data:names_517}}"));
        await _ui.PressAsync(_locators.Names, "CLICK");
        await _ui.PressAsync(_locators.Names, "Tab");
        await _ui.PressAsync(_locators.Address, "PRE:TAB");
        await _ui.PressAsync(_locators.Address, "Tab");
        await _ui.FillAsync(_locators.Address, _data.Resolve("{{data:address_519}}"));
        await _ui.PressAsync(_locators.Address, "CLICK");
        await _ui.PressAsync(_locators.Address, "Tab");
        await _ui.ClickAsync(_locators.EndorsementCM6601ExcludeNamedCustomerOK);
    }

    // Business step: I add IF 00 02 Waterborne Equipment
    public async Task AddIF0002WaterborneEquipmentAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToEndorsementScreen_0239_aad19bAsync
        await _ui.ClickAsync(_locators.Endorsement);
        // EndorsementMain_0e2165Page.EndorsementMain_0240_aad19bAsync
        await _ui.WaitAsync(_locators.EndorsementHeading, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsement48A9E);
        await _ui.FillAsync(_locators.Type715D6, _data.Resolve("{{data:type_524}}"));
        await _ui.PressAsync(_locators.Type715D6, "Tab");
        await _ui.PressAsync(_locators.Type715D6, "Tab");
        // EndorsementIF0002WaterborneEquipment_eac821Page.EndorsementIF0002WaterborneEquipment_0241_aad19bAsync
        await _ui.FillAsync(_locators.Limit887C5, _data.Resolve("{{data:limit_525}}"));
        await _ui.PressAsync(_locators.Limit887C5, "Tab");
        await _ui.FillAsync(_locators.Deductible0CC0A, _data.Resolve("{{data:deductible_526}}"));
        await _ui.PressAsync(_locators.Deductible0CC0A, "Tab");
        await _ui.ClickAsync(_locators.EndorsementIF0002WaterborneEquipmentOK);
    }

    // Business step: I complete Accounts Receivable Questions
    public async Task CompleteAccountsReceivableQuestionsAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToSpecificUnderwritingQuestions_0242_aad19bAsync
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestions);
        // IMNavigationLinks_7abd8aPage.NavigateToAccountsReceivableUWQuestions_0243_aad19bAsync
        await _ui.ClickAsync(_locators.AccountsReceivableUWQuestions);
        // SpecificUnderwritingQuestionsAccountsReceivable_3d457ePage.SpecificUnderwritingQuestionsAccountsReceivable_0244_aad19bAsync
        await _ui.WaitAsync(_locators.AccountsReceivableHeading, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswersD8A16);
        await _ui.FillAsync(_locators.WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored, _data.Resolve("{{data:what_is_the_construction_of_the_premises_where_the_receivables_are_stored_532}}"));
        await _ui.PressAsync(_locators.WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored, "Tab");
        await _ui.PressAsync(_locators.WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored, "CLICK");
        await _ui.PressAsync(_locators.WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored, "Tab");
        await _ui.PressAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, "PRE:TAB");
        await _ui.PressAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, "Tab");
        await _ui.FillAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, _data.Resolve("{{data:what_safeguards_are_in_place_for_receivables_to_protect_against_damage_or_theft_534}}"));
        await _ui.PressAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, "Tab");
        await _ui.PressAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, "CLICK");
        await _ui.PressAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, "Tab");
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsAccountsReceivableOK);
    }

    // Business step: I complete Bailees Customers Questions
    public async Task CompleteBaileesCustomersQuestionsAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToSpecificUnderwritingQuestions_0245_aad19bAsync
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestions);
        // IMNavigationLinks_7abd8aPage.NavigateToBaileesCustomersUWQuestions_0246_aad19bAsync
        await _ui.ClickAsync(_locators.BaileesCustomerUWQuestions);
        // SpecificUnderwritingQuestionsBaileesCustomer_5a687aPage.SpecificUnderwritingQuestionsBaileesCustomer_0247_aad19bAsync
        await _ui.WaitAsync(_locators.BaileesCustomerHeading, "Exists");
        await _ui.FillAsync(_locators.DryCleaning, _data.Resolve("{{data:dry_cleaning_539}}"));
        await _ui.PressAsync(_locators.DryCleaning, "Tab");
        await _ui.PressAsync(_locators.DryCleaning, "CLICK");
        await _ui.PressAsync(_locators.DryCleaning, "Tab");
        await _ui.FillAsync(_locators.Laundry, _data.Resolve("{{data:laundry_540}}"));
        await _ui.PressAsync(_locators.Laundry, "Tab");
        await _ui.PressAsync(_locators.Laundry, "CLICK");
        await _ui.PressAsync(_locators.Laundry, "Tab");
        await _ui.FillAsync(_locators.N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises, _data.Resolve("{{data:2_indicate_the_age_type_of_construction_and_protection_class_of_the_premises_541}}"));
        await _ui.PressAsync(_locators.N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises, "Tab");
        await _ui.PressAsync(_locators.N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises, "CLICK");
        await _ui.PressAsync(_locators.N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises, "Tab");
        await _ui.FillAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, _data.Resolve("{{data:3_what_is_the_percentage_of_annual_gross_receipts_derived_from_service_or_repair_542}}"));
        await _ui.PressAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, "Tab");
        await _ui.PressAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, "Tab");
        await _ui.PressAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, "CLICK");
        await _ui.PressAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, "CLICK");
        await _ui.PressAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, "Tab");
        await _ui.FillAsync(_locators.N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated, _data.Resolve("{{data:4_what_method_do_you_use_for_keeping_records_of_property_in_your_care_and_how_often_are_the_records_updated_543}}"));
        await _ui.PressAsync(_locators.N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated, "Tab");
        await _ui.PressAsync(_locators.N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated, "CLICK");
        await _ui.PressAsync(_locators.N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated, "Tab");
        await _ui.FillAsync(_locators.N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained, _data.Resolve("{{data:5_are_recognized_approved_central_station_burglar_alarms_installed_and_maintained_544}}"));
        await _ui.PressAsync(_locators.N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained, "Tab");
        await _ui.PressAsync(_locators.N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained, "CLICK");
        await _ui.PressAsync(_locators.N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained, "Tab");
        await _ui.FillAsync(_locators.N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied, _data.Resolve("{{data:6_are_all_storage_areas_locked_at_all_times_when_unoccupied_545}}"));
        await _ui.PressAsync(_locators.N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied, "Tab");
        await _ui.PressAsync(_locators.N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied, "CLICK");
        await _ui.PressAsync(_locators.N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied, "Tab");
        await _ui.FillAsync(_locators.N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises, _data.Resolve("{{data:7_are_there_any_hazardous_or_flammable_materials_used_or_stored_on_the_premises_546}}"));
        await _ui.PressAsync(_locators.N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises, "Tab");
        await _ui.PressAsync(_locators.N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises, "CLICK");
        await _ui.PressAsync(_locators.N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises, "Tab");
        await _ui.FillAsync(_locators.AWhatIsThePublicProtectionClassRating, _data.Resolve("{{data:a_what_is_the_public_protection_class_rating_547}}"));
        await _ui.PressAsync(_locators.AWhatIsThePublicProtectionClassRating, "Tab");
        await _ui.PressAsync(_locators.AWhatIsThePublicProtectionClassRating, "Tab");
        await _ui.PressAsync(_locators.AWhatIsThePublicProtectionClassRating, "CLICK");
        await _ui.PressAsync(_locators.AWhatIsThePublicProtectionClassRating, "CLICK");
        await _ui.PressAsync(_locators.AWhatIsThePublicProtectionClassRating, "Tab");
        await _ui.FillAsync(_locators.BAreThereAnyPrivateProtectionImprovements, _data.Resolve("{{data:b_are_there_any_private_protection_improvements_548}}"));
        await _ui.PressAsync(_locators.BAreThereAnyPrivateProtectionImprovements, "Tab");
        await _ui.PressAsync(_locators.BAreThereAnyPrivateProtectionImprovements, "CLICK");
        await _ui.PressAsync(_locators.BAreThereAnyPrivateProtectionImprovements, "Tab");
        await _ui.FillAsync(_locators.CWhatIsTheDistanceInFeetToTheNearestHydrant, _data.Resolve("{{data:c_what_is_the_distance_in_feet_to_the_nearest_hydrant_549}}"));
        await _ui.PressAsync(_locators.CWhatIsTheDistanceInFeetToTheNearestHydrant, "Tab");
        await _ui.PressAsync(_locators.CWhatIsTheDistanceInFeetToTheNearestHydrant, "CLICK");
        await _ui.PressAsync(_locators.CWhatIsTheDistanceInFeetToTheNearestHydrant, "Tab");
        await _ui.FillAsync(_locators.DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, _data.Resolve("{{data:d_what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_550}}"));
        await _ui.PressAsync(_locators.DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "Tab");
        await _ui.PressAsync(_locators.DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "CLICK");
        await _ui.PressAsync(_locators.DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "Tab");
        await _ui.FillAsync(_locators.EAreNoSmokingRulesPostedAndEnforced, _data.Resolve("{{data:e_are_no_smoking_rules_posted_and_enforced_551}}"));
        await _ui.PressAsync(_locators.EAreNoSmokingRulesPostedAndEnforced, "Tab");
        await _ui.PressAsync(_locators.EAreNoSmokingRulesPostedAndEnforced, "CLICK");
        await _ui.PressAsync(_locators.EAreNoSmokingRulesPostedAndEnforced, "Tab");
        await _ui.FillAsync(_locators.N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem, _data.Resolve("{{data:9_are_the_premises_or_any_portion_of_the_premises_equipped_with_a_sprinkler_system_552}}"));
        await _ui.PressAsync(_locators.N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem, "Tab");
        await _ui.PressAsync(_locators.N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem, "CLICK");
        await _ui.PressAsync(_locators.N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem, "Tab");
        await _ui.FillAsync(_locators.N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms, _data.Resolve("{{data:10_are_the_premises_equipped_with_a_recognized_approved_central_station_fire_alarm_fire_extinguishers_or_smoke_alarms_553}}"));
        await _ui.PressAsync(_locators.N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms, "Tab");
        await _ui.PressAsync(_locators.N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms, "CLICK");
        await _ui.PressAsync(_locators.N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms, "Tab");
        await _ui.FillAsync(_locators.N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit, _data.Resolve("{{data:11_what_is_the_procedure_for_transporting_property_include_the_transit_methods_used_and_the_protection_class_provided_while_in_transit_554}}"));
        await _ui.PressAsync(_locators.N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit, "Tab");
        await _ui.PressAsync(_locators.N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit, "CLICK");
        await _ui.PressAsync(_locators.N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit, "Tab");
        await _ui.FillAsync(_locators.N12AreDriversMVRsReviewedOnARegularBasisAndMaintained, _data.Resolve("{{data:12_are_drivers_mvrs_reviewed_on_a_regular_basis_and_maintained_555}}"));
        await _ui.PressAsync(_locators.N12AreDriversMVRsReviewedOnARegularBasisAndMaintained, "Tab");
        await _ui.PressAsync(_locators.N12AreDriversMVRsReviewedOnARegularBasisAndMaintained, "CLICK");
        await _ui.PressAsync(_locators.N12AreDriversMVRsReviewedOnARegularBasisAndMaintained, "Tab");
        await _ui.FillAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, _data.Resolve("{{data:13_what_types_of_vehicles_do_you_operate_and_what_protective_devices_are_on_each_vehicle_556}}"));
        await _ui.PressAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, "Tab");
        await _ui.PressAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, "Tab");
        await _ui.PressAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, "CLICK");
        await _ui.PressAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, "CLICK");
        await _ui.PressAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, "Tab");
        await _ui.FillAsync(_locators.N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage, _data.Resolve("{{data:14_what_is_your_procedure_for_protecting_small_items_from_breakage_or_disappearance_while_in_storage_557}}"));
        await _ui.PressAsync(_locators.N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage, "Tab");
        await _ui.PressAsync(_locators.N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage, "CLICK");
        await _ui.PressAsync(_locators.N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage, "Tab");
        await _ui.FillAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, _data.Resolve("{{data:15_what_measures_does_the_insured_take_to_protect_customer_s_property_against_theft_558}}"));
        await _ui.PressAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, "Tab");
        await _ui.PressAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, "Tab");
        await _ui.PressAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, "CLICK");
        await _ui.PressAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, "CLICK");
        await _ui.PressAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, "Tab");
        await _ui.FillAsync(_locators.N16DoesTheRiskUseReleaseForms, _data.Resolve("{{data:16_does_the_risk_use_release_forms_559}}"));
        await _ui.PressAsync(_locators.N16DoesTheRiskUseReleaseForms, "Tab");
        await _ui.PressAsync(_locators.N16DoesTheRiskUseReleaseForms, "CLICK");
        await _ui.PressAsync(_locators.N16DoesTheRiskUseReleaseForms, "Tab");
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsBaileesCustomerOK);
    }

    // Business step: I complete Computer Systems Questions
    public async Task CompleteComputerSystemsQuestionsAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToSpecificUnderwritingQuestions_0248_aad19bAsync
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestions);
        // IMNavigationLinks_7abd8aPage.NavigateToComputerSystemsUWQuestions_0249_aad19bAsync
        await _ui.ClickAsync(_locators.ComputerSystemsUWQuestions);
        // SpecificUnderwritingQuestionsComputerSystems_61d932Page.SpecificUnderwritingQuestionsComputerSystems_0250_aad19bAsync
        await _ui.ClickAsync(_locators.UpdateAnswers3DDA2);
        await _ui.PressAsync(_locators.UpdateAnswers3DDA2, "Tab");
        await _ui.PressAsync(_locators.UpdateAnswers3DDA2, "Click");
        await _ui.FillAsync(_locators.WhatIsTheProcedureForTransportingTheComputerEquipment, _data.Resolve("{{data:what_is_the_procedure_for_transporting_the_computer_equipment_564}}"));
        await _ui.PressAsync(_locators.WhatIsTheProcedureForTransportingTheComputerEquipment, "Tab");
        await _ui.PressAsync(_locators.WhatIsTheProcedureForTransportingTheComputerEquipment, "CLICK");
        await _ui.PressAsync(_locators.WhatIsTheProcedureForTransportingTheComputerEquipment, "Tab");
        await _ui.FillAsync(_locators.IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated, _data.Resolve("{{data:indicate_the_building_s_age_type_of_construction_and_protection_class_and_other_tenants_in_the_building_s_where_the_computer_equipment_is_located_565}}"));
        await _ui.PressAsync(_locators.IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated, "Tab");
        await _ui.PressAsync(_locators.IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated, "CLICK");
        await _ui.PressAsync(_locators.IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated, "Tab");
        await _ui.FillAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, _data.Resolve("{{data:what_are_the_procedures_and_methods_for_keeping_the_edp_areas_secured_566}}"));
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, "Tab");
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, "Tab");
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, "CLICK");
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, "CLICK");
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, "Tab");
        await _ui.FillAsync(_locators.WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage, _data.Resolve("{{data:what_are_the_procedures_and_schedule_for_backing_up_the_media_and_data_and_their_storage_567}}"));
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage, "Tab");
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage, "CLICK");
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage, "Tab");
        await _ui.FillAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, _data.Resolve("{{data:provide_information_regarding_antivirus_methods_and_copyright_protection_of_data_and_media_568}}"));
        await _ui.PressAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, "Tab");
        await _ui.PressAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, "Tab");
        await _ui.PressAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, "CLICK");
        await _ui.PressAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, "CLICK");
        await _ui.PressAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, "Tab");
        await _ui.FillAsync(_locators.WhatIsThePublicProtectionClassRating, _data.Resolve("{{data:what_is_the_public_protection_class_rating_569}}"));
        await _ui.PressAsync(_locators.WhatIsThePublicProtectionClassRating, "Tab");
        await _ui.PressAsync(_locators.WhatIsThePublicProtectionClassRating, "Tab");
        await _ui.PressAsync(_locators.WhatIsThePublicProtectionClassRating, "CLICK");
        await _ui.PressAsync(_locators.WhatIsThePublicProtectionClassRating, "CLICK");
        await _ui.PressAsync(_locators.WhatIsThePublicProtectionClassRating, "CLICK");
        await _ui.PressAsync(_locators.WhatIsThePublicProtectionClassRating, "Tab");
        await _ui.FillAsync(_locators.WhatIsTheDistanceInFeetToTheNearestFireHydrant, _data.Resolve("{{data:what_is_the_distance_in_feet_to_the_nearest_fire_hydrant_570}}"));
        await _ui.PressAsync(_locators.WhatIsTheDistanceInFeetToTheNearestFireHydrant, "Tab");
        await _ui.PressAsync(_locators.WhatIsTheDistanceInFeetToTheNearestFireHydrant, "CLICK");
        await _ui.PressAsync(_locators.WhatIsTheDistanceInFeetToTheNearestFireHydrant, "CLICK");
        await _ui.PressAsync(_locators.WhatIsTheDistanceInFeetToTheNearestFireHydrant, "Tab");
        await _ui.FillAsync(_locators.WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, _data.Resolve("{{data:what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_571}}"));
        await _ui.PressAsync(_locators.WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "Tab");
        await _ui.PressAsync(_locators.WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "CLICK");
        await _ui.PressAsync(_locators.WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "CLICK");
        await _ui.PressAsync(_locators.WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "Tab");
        await _ui.FillAsync(_locators.UninterruptiblePowerSource, _data.Resolve("{{data:uninterruptible_power_source_572}}"));
        await _ui.PressAsync(_locators.UninterruptiblePowerSource, "Tab");
        await _ui.PressAsync(_locators.UninterruptiblePowerSource, "CLICK");
        await _ui.PressAsync(_locators.UninterruptiblePowerSource, "Tab");
        await _ui.FillAsync(_locators.LineConditioner, _data.Resolve("{{data:line_conditioner_573}}"));
        await _ui.PressAsync(_locators.LineConditioner, "Tab");
        await _ui.PressAsync(_locators.LineConditioner, "CLICK");
        await _ui.PressAsync(_locators.LineConditioner, "Tab");
        await _ui.FillAsync(_locators.PowerSuppressorVoltageRegulator, _data.Resolve("{{data:power_suppressor_voltage_regulator_574}}"));
        await _ui.PressAsync(_locators.PowerSuppressorVoltageRegulator, "Tab");
        await _ui.PressAsync(_locators.PowerSuppressorVoltageRegulator, "CLICK");
        await _ui.PressAsync(_locators.PowerSuppressorVoltageRegulator, "Tab");
        await _ui.FillAsync(_locators.DedicatedLine, _data.Resolve("{{data:dedicated_line_575}}"));
        await _ui.PressAsync(_locators.DedicatedLine, "Tab");
        await _ui.PressAsync(_locators.DedicatedLine, "CLICK");
        await _ui.PressAsync(_locators.DedicatedLine, "Tab");
        await _ui.FillAsync(_locators.HowOftenIsDataBackedUp, _data.Resolve("{{data:how_often_is_data_backed_up_576}}"));
        await _ui.PressAsync(_locators.HowOftenIsDataBackedUp, "Tab");
        await _ui.PressAsync(_locators.HowOftenIsDataBackedUp, "CLICK");
        await _ui.PressAsync(_locators.HowOftenIsDataBackedUp, "Tab");
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsComputerSystemsOK);
    }

    // Business step: I complete Contractors Equipment Questions
    public async Task CompleteContractorsEquipmentQuestionsAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToSpecificUnderwritingQuestions_0251_aad19bAsync
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestions);
        // IMNavigationLinks_7abd8aPage.NavigateToComputerSystemsUWQuestions_0252_aad19bAsync
        await _ui.ClickAsync(_locators.ContractorsEquipmentUWQuestions);
        // SpecificUnderwritingQuestionsContractorsEquipment_12d34cPage.SpecificUnderwritingQuestionsContractorsEquipment_0253_aad19bAsync
        await _ui.WaitAsync(_locators.ContractorsEquipmentHeading, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswers3DA0B);
        await _ui.FillAsync(_locators.EstimatedHighestValue, _data.Resolve("{{data:estimated_highest_value_582}}"));
        await _ui.PressAsync(_locators.EstimatedHighestValue, "Tab");
        await _ui.PressAsync(_locators.EstimatedHighestValue, "CLICK");
        await _ui.PressAsync(_locators.EstimatedHighestValue, "Tab");
        await _ui.FillAsync(_locators.IfYesDescribe, _data.Resolve("{{data:if_yes_describe_583}}"));
        await _ui.PressAsync(_locators.IfYesDescribe, "Tab");
        await _ui.PressAsync(_locators.IfYesDescribe, "CLICK");
        await _ui.PressAsync(_locators.IfYesDescribe, "Tab");
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsContractorsEquipmentOK);
    }

    // Business step: I complete Motor Truck Cargo Questions \(Owner\)
    public async Task CompleteMotorTruckCargoQuestionsOwnerAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToSpecificUnderwritingQuestions_0254_aad19bAsync
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestions);
        // IMNavigationLinks_7abd8aPage.NavigateToComputerSystemsUWQuestions_0255_aad19bAsync
        await _ui.ClickAsync(_locators.MotorTruckCargoUWQuestions);
        // SpecificUnderwritingQuestionsMotorTruckCargoOwners_143ba9Page.SpecificUnderwritingQuestionsMotorTruckCargoOwners_0256_aad19bAsync
        await _ui.WaitAsync(_locators.MotorTruckCargoHeading, "Exists");
        await _ui.FillAsync(_locators.WhichFormAreYouCompleting, _data.Resolve("{{data:which_form_are_you_completing_588}}"));
        await _ui.PressAsync(_locators.WhichFormAreYouCompleting, "Tab");
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "PRE:TAB");
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "Tab");
        await _ui.FillAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, _data.Resolve("{{data:1_what_are_the_distances_the_shipments_will_travel_and_the_time_required_to_complete_the_shipment_590}}"));
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "Tab");
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "Tab");
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "CLICK");
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "CLICK");
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "Tab");
        await _ui.FillAsync(_locators.N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities, _data.Resolve("{{data:2_what_are_the_types_and_ages_of_the_vehicles_trailers_used_to_transport_your_commodities_591}}"));
        await _ui.PressAsync(_locators.N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities, "Tab");
        await _ui.PressAsync(_locators.N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities, "CLICK");
        await _ui.PressAsync(_locators.N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities, "Tab");
        await _ui.FillAsync(_locators.N3DoesTheApplicantHaulForOthers, _data.Resolve("{{data:3_does_the_applicant_haul_for_others_592}}"));
        await _ui.PressAsync(_locators.N3DoesTheApplicantHaulForOthers, "Tab");
        await _ui.PressAsync(_locators.N3DoesTheApplicantHaulForOthers, "CLICK");
        await _ui.PressAsync(_locators.N3DoesTheApplicantHaulForOthers, "Tab");
        await _ui.FillAsync(_locators.N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer, _data.Resolve("{{data:4_what_protective_devices_are_installed_on_each_vehicle_or_trailer_593}}"));
        await _ui.PressAsync(_locators.N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer, "Tab");
        await _ui.PressAsync(_locators.N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer, "CLICK");
        await _ui.PressAsync(_locators.N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer, "Tab");
        await _ui.FillAsync(_locators.N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached, _data.Resolve("{{data:5_do_any_vehicles_have_special_equipment_mounted_or_attached_594}}"));
        await _ui.PressAsync(_locators.N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached, "Tab");
        await _ui.PressAsync(_locators.N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached, "CLICK");
        await _ui.PressAsync(_locators.N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached, "Tab");
        await _ui.FillAsync(_locators.N6DoesTheApplicantPullDoubleOrTripleTrailers, _data.Resolve("{{data:6_does_the_applicant_pull_double_or_triple_trailers_595}}"));
        await _ui.PressAsync(_locators.N6DoesTheApplicantPullDoubleOrTripleTrailers, "Tab");
        await _ui.PressAsync(_locators.N6DoesTheApplicantPullDoubleOrTripleTrailers, "CLICK");
        await _ui.PressAsync(_locators.N6DoesTheApplicantPullDoubleOrTripleTrailers, "Tab");
        await _ui.FillAsync(_locators.N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended, _data.Resolve("{{data:7_does_the_applicant_leave_the_truck_windows_doors_and_compartments_closed_and_locked_when_unattended_596}}"));
        await _ui.PressAsync(_locators.N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended, "Tab");
        await _ui.PressAsync(_locators.N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended, "CLICK");
        await _ui.PressAsync(_locators.N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended, "Tab");
        await _ui.FillAsync(_locators.N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate, _data.Resolve("{{data:8_do_you_provide_scheduled_maintenance_for_the_vehicles_and_trailers_you_operate_597}}"));
        await _ui.PressAsync(_locators.N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate, "Tab");
        await _ui.PressAsync(_locators.N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate, "CLICK");
        await _ui.PressAsync(_locators.N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate, "Tab");
        await _ui.FillAsync(_locators.N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities, _data.Resolve("{{data:9_are_the_employees_that_pack_load_and_unload_trained_in_proper_handling_of_the_commodities_598}}"));
        await _ui.PressAsync(_locators.N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities, "Tab");
        await _ui.PressAsync(_locators.N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities, "CLICK");
        await _ui.PressAsync(_locators.N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities, "Tab");
        await _ui.FillAsync(_locators.N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft, _data.Resolve("{{data:10_how_are_the_goods_being_transported_protected_from_damage_and_theft_599}}"));
        await _ui.PressAsync(_locators.N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft, "Tab");
        await _ui.PressAsync(_locators.N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft, "CLICK");
        await _ui.PressAsync(_locators.N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft, "Tab");
        await _ui.FillAsync(_locators.N11AreDriversMVRsAndTripLogsMaintained, _data.Resolve("{{data:11_are_drivers_mvrs_and_trip_logs_maintained_600}}"));
        await _ui.PressAsync(_locators.N11AreDriversMVRsAndTripLogsMaintained, "Tab");
        await _ui.PressAsync(_locators.N11AreDriversMVRsAndTripLogsMaintained, "CLICK");
        await _ui.PressAsync(_locators.N11AreDriversMVRsAndTripLogsMaintained, "Tab");
        await _ui.FillAsync(_locators.N12HowOftenAreTheseLogsReviewedOrUpdated, _data.Resolve("{{data:12_how_often_are_these_logs_reviewed_or_updated_601}}"));
        await _ui.PressAsync(_locators.N12HowOftenAreTheseLogsReviewedOrUpdated, "Tab");
        await _ui.PressAsync(_locators.N12HowOftenAreTheseLogsReviewedOrUpdated, "CLICK");
        await _ui.PressAsync(_locators.N12HowOftenAreTheseLogsReviewedOrUpdated, "Tab");
        await _ui.FillAsync(_locators.N13LiveAnimalInTransitCoverage, _data.Resolve("{{data:13_live_animal_in_transit_coverage_602}}"));
        await _ui.PressAsync(_locators.N13LiveAnimalInTransitCoverage, "Tab");
        await _ui.PressAsync(_locators.N13LiveAnimalInTransitCoverage, "CLICK");
        await _ui.PressAsync(_locators.N13LiveAnimalInTransitCoverage, "Tab");
        await _ui.FillAsync(_locators.N14LegalLiabilityCoverage, _data.Resolve("{{data:14_legal_liability_coverage_603}}"));
        await _ui.PressAsync(_locators.N14LegalLiabilityCoverage, "Tab");
        await _ui.PressAsync(_locators.N14LegalLiabilityCoverage, "CLICK");
        await _ui.PressAsync(_locators.N14LegalLiabilityCoverage, "Tab");
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsMotorTruckCargoOwnersOK);
    }

    // Business step: I complete Signs Questions
    public async Task CompleteSignsQuestionsAsync()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToSpecificUnderwritingQuestions_0257_aad19bAsync
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestions);
        // IMNavigationLinks_7abd8aPage.NavigateToComputerSystemsUWQuestions_0258_aad19bAsync
        await _ui.ClickAsync(_locators.SignsUWQuestions);
        // SpecificUnderwritingQuestionsSigns_b71b54Page.SpecificUnderwritingQuestionsSigns_0259_aad19bAsync
        await _ui.WaitAsync(_locators.SignsHeading, "Exists");
        await _ui.FillAsync(_locators.AreAnySignsOffPremisesOrNotAttachedToBuilding, _data.Resolve("{{data:are_any_signs_off_premises_or_not_attached_to_building_608}}"));
        await _ui.PressAsync(_locators.AreAnySignsOffPremisesOrNotAttachedToBuilding, "Tab");
        await _ui.PressAsync(_locators.AreAnySignsOffPremisesOrNotAttachedToBuilding, "Tab");
        await _ui.FillAsync(_locators.DoesTheApplicantWishToCoverAnySignsInsideTheirPremises, _data.Resolve("{{data:does_the_applicant_wish_to_cover_any_signs_inside_their_premises_609}}"));
        await _ui.PressAsync(_locators.DoesTheApplicantWishToCoverAnySignsInsideTheirPremises, "Tab");
        await _ui.PressAsync(_locators.DoesTheApplicantWishToCoverAnySignsInsideTheirPremises, "Tab");
        await _ui.FillAsync(_locators.WhatIsTheConstructionOfEachSign, _data.Resolve("{{data:what_is_the_construction_of_each_sign_610}}"));
        await _ui.PressAsync(_locators.WhatIsTheConstructionOfEachSign, "Tab");
        await _ui.PressAsync(_locators.WhatIsTheConstructionOfEachSign, "Tab");
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsSignsOK);
    }

    // Business step: I select GL Available Classiifcation
    public async Task SelectGLAvailableClassiifcationAsync()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPricingScreen_0264_aad19bAsync
        await _ui.ClickAsync(_locators.Pricing900C9);
        // CPPPricing_4ca03bPage.CPPPricingSelectGLClass_0265_aad19bAsync
        await _ui.FillAsync(_locators.AvailableClassifications, _data.Resolve("{{data:available_classifications_617}}"));
        await _ui.PressAsync(_locators.AvailableClassifications, "Tab");
        await _ui.PressAsync(_locators.AvailableClassifications, "CLICK");
        await _ui.PressAsync(_locators.AvailableClassifications, "Tab");
        await _ui.PressAsync(_locators.AvailableClassifications, "Enter");
    }

    // Business step: I navigate to Underwriting Info Screens
    public async Task NavigateToUnderwritingInfoScreensAsync()
    {
        // CommonNavigationLinks_dba56bPage.CPPBasicNavigateToClientScreen_0266_aad19bAsync
        await _ui.ClickAsync(_locators.Client35F85);
        // CommonNavigationLinks_dba56bPage.CPPBasicNavigateToUnderwritingInfoScreen_0267_aad19bAsync
        await _ui.ClickAsync(_locators.UnderwritingInfo);
    }

    // Business step: I navigate back to CPP Main
    public async Task NavigateBackToCPPMainAsync()
    {
        // CommonNavigationLinks_dba56bPage.CommonNavigationLinks_0276_aad19bAsync
        await _ui.ClickAsync(_locators.ReturnToQuote);
    }

    // Business step: I complete required billing information for billing
    public async Task CompleteRequiredBillingInformationForBillingAsync2()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0277_aad19bAsync
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0278_aad19bAsync
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_635}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_638}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_642}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0279_aad19bAsync
        await Task.Delay(1000);
    }

    // Business step: I add notepad comment
    public async Task AddNotepadCommentAsync5()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToNotePadScreen_0280_aad19bAsync
        await _ui.ClickAsync(_locators.Notepad);
        // NotePad_055c33Page.AddNotesRemarksToNotePad_0281_aad19bAsync
        await _ui.WaitAsync(_locators.NotepadHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNotesRemarks);
        await _ui.FillAsync(_locators.TextBox, _data.Resolve("Test {B[Product (LOB)]}"));
        await _ui.ClickAsync(_locators.NotePadOK);
    }

    // Business step: I complete required submission information
    public async Task CompleteRequiredSubmissionInformationAsync5()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0282_aad19bAsync
        await _ui.WaitAsync(_locators.Submission, "Visible");
        await _ui.ClickAsync(_locators.Submission);
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutRequiredFields_0283_aad19bAsync
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_653}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "CLICK");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.OrderAudit_0284_aad19bAsync
        await _ui.VerifyAsync(_locators.OrderAudit, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutOrderAudit_0285_aad19bAsync
        await _ui.FillAsync(_locators.OrderAudit, _data.Resolve("{{data:order_audit_655}}"));
        await _ui.PressAsync(_locators.OrderAudit, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeSubmissionScreenHeaderExists_0286_aad19bAsync
        await _ui.VerifyAsync(_locators.SubmissionHeading, _data.Resolve("Absent"), "");
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0287_aad19bAsync
        await _ui.PressAsync(_locators.Submission, "PRE:TAB");
        await _ui.PressAsync(_locators.Submission, "Tab");
        await _ui.ClickAsync(_locators.Submission);
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0288_aad19bAsync
        await Task.Delay(1000);
        // SubmissionRequiredAndOptionalFields_4090a9Page.WaitOnSubmissionScreenToLoad_0289_aad19bAsync
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        // TBoxWait_7ea9e1Page.N500msWaitForSyncing_0290_aad19bAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required billing information
    public async Task CompleteRequiredBillingInformationAsync7()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0053_677267Async
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0054_677267Async
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_37}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_40}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_44}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0055_677267Async
        await Task.Delay(1000);
    }

    // Business step: I complete Underwriting Info from Client Screen
    public async Task CompleteUnderwritingInfoFromClientScreenAsync3()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToUnderwritingInfoScreen_0066_677267Async
        await _ui.ClickAsync(_locators.UnderwritingInfo);
        // UnderwritingInfoGeneralUWQuestions_3222c4Page.UnderwritingInfoGeneralUWQuestions_0067_677267Async
        await _ui.WaitAsync(_locators.GeneralUWQuestions, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswers9CB86);
        // UnderwritingInfoOtherInsuranceHistory_b78753Page.AddPriorCarriorDetailsOnLossInformationScreen_0068_677267Async
        await _ui.ClickAsync(_locators.InsuranceHistory);
        await _ui.WaitAsync(_locators.IsThereAPriorCarrier, "Exists");
        await _ui.FillAsync(_locators.IsThereAPriorCarrier, _data.Resolve("{{data:is_there_a_prior_carrier_88}}"));
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Tab");
        await _ui.WaitAsync(_locators.Carrier, "Exists");
        await _ui.FillAsync(_locators.Carrier, _data.Resolve("{{data:carrier_90}}"));
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.FillAsync(_locators.PolicyNumberBA28E, _data.Resolve("{{data:policy_number_91}}"));
        await _ui.PressAsync(_locators.PolicyNumberBA28E, "Tab");
        await _ui.FillAsync(_locators.PolicyType, _data.Resolve("{{data:policy_type_92}}"));
        await _ui.PressAsync(_locators.PolicyType, "Tab");
        await _ui.FillAsync(_locators.EffectiveDateB557F, _data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDateB557F, "Tab");
        await _ui.FillAsync(_locators.ExpirationDate34EAC, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate34EAC, "Tab");
        await _ui.FillAsync(_locators.ModificationFactor, _data.Resolve("{{data:modificationfactor_95}}"));
        await _ui.PressAsync(_locators.ModificationFactor, "Tab");
        await _ui.FillAsync(_locators.TotalPremium, _data.Resolve("{{data:total_premium_96}}"));
        await _ui.PressAsync(_locators.TotalPremium, "Tab");
        await _ui.ClickAsync(_locators.OtherInsuranceHistoryOK);
        await _ui.WaitAsync(_locators.Detail0F8C6, "Exists");
        // UnderwritingInfoLossExperience_54b758Page.IndicateNoKnownLossesOnLossExperienceScreen_0069_677267Async
        await _ui.ClickAsync(_locators.LossExperience);
        await _ui.WaitAsync(_locators.NoKnownLosses, "Exists");
        await _ui.SmartSetAsync(_locators.NoKnownLosses, _data.Resolve("{{data:no_known_losses_101}}"));
        await _ui.PressAsync(_locators.NoKnownLosses, "Tab");
        // CommonNavigationLinks_dba56bPage.ClickReturnToQuote_0070_677267Async
        await _ui.ClickAsync(_locators.ReturnToQuote);
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0071_677267Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_103}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_104}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_105}}"), "value");
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync10()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0072_677267Async
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0073_677267Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0074_677267Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0075_677267Async
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_109}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_110}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0076_677267Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0077_677267Async
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_112}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_116}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0078_677267Async
        _data.Set("StateIsKansas", _data.Resolve("Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'"));
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0080_677267Async
        _data.Set("StateIsVirginia", _data.Resolve("Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'"));
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0082_677267Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0083_677267Async
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_122}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0084_677267Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0085_677267Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AZ CP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0088_677267Async
        await Task.Delay(1000);
    }

    // Business step: I complete CP Fields
    public async Task CompleteCPFieldsAsync()
    {
        // CPNavigationLinks_d0fcc0Page.NavigateToPolicyCovgScreen_0099_677267Async
        await _ui.ClickAsync(_locators.PolicyCovgD0419);
        // PolicyCovg_0dff37Page.AnswerCPPolicyCovgPrivateWindmillsQuestion_0100_677267Async
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Exists");
        await _ui.FillAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, _data.Resolve("{{data:does_any_risk_generate_power_other_than_private_windmills_or_emergency_backup_145}}"));
        await _ui.PressAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, "CLICK");
        await _ui.PressAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, "Enter");
        await _ui.PressAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, "Tab");
    }

    // Business step: I complete CP Fields for location
    public async Task CompleteCPFieldsForLocationAsync2()
    {
        // CPNavigationLinks_d0fcc0Page.NavigateToLocationScreen_0104_677267Async
        await _ui.ClickAsync(_locators.LocationB7B1D);
        // Location_d219c6Page.FillOutCPLocationFieldsFtFromHydrant_0105_677267Async
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.FillAsync(_locators.FeetFromHydrant, _data.Resolve("{{data:feet_from_hydrant_154}}"));
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Enter");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0106_677267Async
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0107_677267Async
        await Task.Delay(1000);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0108_677267Async
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0109_677267Async
        await Task.Delay(1000);
        // Location_d219c6Page.FillOutCPLocationFieldsMilesFromFD_0110_677267Async
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.FillAsync(_locators.MilesFromFireDepartment, _data.Resolve("{{data:miles_from_fire_department_160}}"));
        await _ui.PressAsync(_locators.MilesFromFireDepartment, "Tab");
        await _ui.PressAsync(_locators.MilesFromFireDepartment, "Tab");
        await _ui.PressAsync(_locators.MilesFromFireDepartment, "Tab");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0111_677267Async
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0112_677267Async
        await Task.Delay(1000);
        // Location_d219c6Page.VerifyFtFromHydrant_0113_677267Async
        await _ui.VerifyAsync(_locators.FeetFromHydrant, _data.Resolve("{{data:expected_feet_from_hydrant_value_163}}"), "NotEqual:Value");
        // Location_d219c6Page.FillOutCPLocationFieldsFtFromHydrant_0114_677267Async
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.FillAsync(_locators.FeetFromHydrant, _data.Resolve("{{data:feet_from_hydrant_165}}"));
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Enter");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0115_677267Async
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0116_677267Async
        await Task.Delay(1000);
        // Location_d219c6Page.FillOutCPLocationFieldsCallISOAndSelectPPC_0117_677267Async
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.ClickAsync(_locators.CallISO);
        await _ui.ClickAsync(_locators.SelectPPC);
        await _ui.ClickAsync(_locators.Select);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0118_677267Async
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0119_677267Async
        await Task.Delay(1000);
        // Location_d219c6Page.VerifyFtFromHydrant_0120_677267Async
        await _ui.VerifyAsync(_locators.FeetFromHydrant, _data.Resolve("{{data:expected_feet_from_hydrant_value_174}}"), "NotEqual:Value");
        // Location_d219c6Page.FillOutCPLocationFieldsFtFromHydrant_0121_677267Async
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.FillAsync(_locators.FeetFromHydrant, _data.Resolve("{{data:feet_from_hydrant_176}}"));
        await _ui.PressAsync(_locators.FeetFromHydrant, "CLICK");
        await _ui.PressAsync(_locators.FeetFromHydrant, "CLICK");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Enter");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Enter");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        await _ui.PressAsync(_locators.FeetFromHydrant, "Tab");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0122_677267Async
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0123_677267Async
        await Task.Delay(1000);
        // Location_d219c6Page.ClickOKOnCPLocationFieldsCallISOAndSelectPPC_0124_677267Async
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.ClickAsync(_locators.LocationOK);
    }

    // Business step: I complete CP Fields for building
    public async Task CompleteCPFieldsForBuildingAsync2()
    {
        // CPNavigationLinks_d0fcc0Page.NavigateToBuildingScreen_0125_677267Async
        await _ui.ClickAsync(_locators.Building87910);
        // BuildingMain_d5e89aPage.BuildingAddBuilding_0126_677267Async
        await _ui.WaitAsync(_locators.Building8205F, "Exists");
        await _ui.ClickAsync(_locators.AddBuilding);
        // BuildingMain_d5e89aPage.BuildingSelectBuildingDetail_0127_677267Async
        await _ui.WaitAsync(_locators.Building8205F, "Exists");
        await _ui.ClickAsync(_locators.Detail10932);
        // BuildingDetail_497f3cPage.BuildingFillInBuildingDetailFields_0128_677267Async
        if (_data.Condition("Construction != NULL"))
        {
            await _ui.FillAsync(_locators.Construction39800, _data.Resolve("{{data:construction_186}}"));
            await _ui.PressAsync(_locators.Construction39800, "Tab");
            await _ui.PressAsync(_locators.Construction39800, "Tab");
        }
        if (_data.Condition("'Year Built' != NULL"))
        {
            await _ui.FillAsync(_locators.YearBuilt, _data.Resolve("{{data:year_built_187}}"));
            await _ui.PressAsync(_locators.YearBuilt, "Tab");
            await _ui.PressAsync(_locators.YearBuilt, "Tab");
        }
        if (_data.Condition("'Square Feet' != NULL"))
        {
            await _ui.FillAsync(_locators.SquareFeet, _data.Resolve("{{data:square_feet_188}}"));
            await _ui.PressAsync(_locators.SquareFeet, "Tab");
            await _ui.PressAsync(_locators.SquareFeet, "Tab");
        }
        if (_data.Condition("Stories != NULL"))
        {
            await _ui.FillAsync(_locators.Stories, _data.Resolve("{{data:stories_189}}"));
            await _ui.PressAsync(_locators.Stories, "Tab");
            await _ui.PressAsync(_locators.Stories, "Tab");
        }
        if (_data.Condition("Interest != NULL"))
        {
            await _ui.FillAsync(_locators.Interest, _data.Resolve("{{data:interest_190}}"));
            await _ui.PressAsync(_locators.Interest, "Tab");
            await _ui.PressAsync(_locators.Interest, "Tab");
        }
        if (_data.Condition("'Roof Type' != NULL"))
        {
            await _ui.FillAsync(_locators.RoofType, _data.Resolve("{{data:roof_type_191}}"));
            await _ui.PressAsync(_locators.RoofType, "Tab");
            await _ui.PressAsync(_locators.RoofType, "Tab");
        }
        if (_data.Condition("Deductible != NULL"))
        {
            await _ui.FillAsync(_locators.Deductible592D9, _data.Resolve("{{data:deductible_192}}"));
            await _ui.PressAsync(_locators.Deductible592D9, "Tab");
            await _ui.PressAsync(_locators.Deductible592D9, "Tab");
            await _ui.PressAsync(_locators.Deductible592D9, "CLICK");
            await _ui.PressAsync(_locators.Deductible592D9, "CLICK");
            await _ui.PressAsync(_locators.Deductible592D9, "Tab");
        }
        if (_data.Condition("'Deductible Increased Theft' != NULL"))
        {
            await _ui.FillAsync(_locators.DeductibleIncreasedTheft99E5F, _data.Resolve("{{data:deductible_increased_theft_193}}"));
            await _ui.PressAsync(_locators.DeductibleIncreasedTheft99E5F, "Tab");
            await _ui.PressAsync(_locators.DeductibleIncreasedTheft99E5F, "Tab");
        }
        if (_data.Condition("'Deductible Wind Hail' != NULL"))
        {
            await _ui.FillAsync(_locators.DeductibleWindHail911AF, _data.Resolve("{{data:deductible_wind_hail_194}}"));
            await _ui.PressAsync(_locators.DeductibleWindHail911AF, "Tab");
            await _ui.PressAsync(_locators.DeductibleWindHail911AF, "Tab");
        }
        if (_data.Condition("'BG2 Symbol' != NULL"))
        {
            await _ui.FillAsync(_locators.BG2Symbol, _data.Resolve("{{data:bg2_symbol_195}}"));
            await _ui.PressAsync(_locators.BG2Symbol, "Tab");
            await _ui.PressAsync(_locators.BG2Symbol, "Tab");
        }
        if (_data.Condition("'BG2 Symbol Prefix' != NULL"))
        {
            await _ui.FillAsync(_locators.BG2SymbolPrefix, _data.Resolve("{{data:bg2_symbol_prefix_196}}"));
            await _ui.PressAsync(_locators.BG2SymbolPrefix, "CLICK");
            await _ui.PressAsync(_locators.BG2SymbolPrefix, "Tab");
        }
        if (_data.Condition("'Is the building cooled?' != NULL"))
        {
            await _ui.FillAsync(_locators.IsTheBuildingCooled, _data.Resolve("{{data:is_the_building_cooled_197}}"));
            await _ui.PressAsync(_locators.IsTheBuildingCooled, "Tab");
            await _ui.PressAsync(_locators.IsTheBuildingCooled, "Tab");
        }
        if (_data.Condition("'Is the building heated with a Solid Fuel Heating Device?' != NULL"))
        {
            await _ui.FillAsync(_locators.IsTheBuildingHeatedWithASolidFuelHeatingDevice, _data.Resolve("{{data:is_the_building_heated_with_a_solid_fuel_heating_device_198}}"));
            await _ui.PressAsync(_locators.IsTheBuildingHeatedWithASolidFuelHeatingDevice, "Tab");
            await _ui.PressAsync(_locators.IsTheBuildingHeatedWithASolidFuelHeatingDevice, "CLICK");
            await _ui.PressAsync(_locators.IsTheBuildingHeatedWithASolidFuelHeatingDevice, "Tab");
        }
        if (_data.Condition("'Provide a List of Surrounding Exposure/Other Occupancies within 100 ft (Including North, East, South, and West)' != NULL"))
        {
            await _ui.FillAsync(_locators.ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest, _data.Resolve("{{data:provide_a_list_of_surrounding_exposure_other_occupancies_within_100_ft_including_north_east_south_and_west_199}}"));
            await _ui.PressAsync(_locators.ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest, "Tab");
            await _ui.PressAsync(_locators.ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest, "CLICK");
            await _ui.PressAsync(_locators.ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest, "Tab");
        }
        if (_data.Condition("'Eligible For Enhanced Wind Rating Program' != NULL"))
        {
            await _ui.FillAsync(_locators.EligibleForEnhancedWindRatingProgram, _data.Resolve("{{data:eligible_for_enhanced_wind_rating_program_200}}"));
            await _ui.PressAsync(_locators.EligibleForEnhancedWindRatingProgram, "Tab");
            await _ui.PressAsync(_locators.EligibleForEnhancedWindRatingProgram, "Tab");
        }
        await _ui.ClickAsync(_locators.BuildingDetailOK);
    }

    // Business step: I add a Rating Group
    public async Task AddARatingGroupAsync2()
    {
        // CPNavigationLinks_d0fcc0Page.NavigateToRatingGroupsScreen_0129_677267Async
        await _ui.ClickAsync(_locators.RatingGroups46191);
        // RatingGroups_62db8dPage.AddRatingGroups_0130_677267Async
        await _ui.WaitAsync(_locators.RatingGroups46DD2, "Exists");
        if (_data.Condition("Description != NULL"))
        {
            await _ui.FillAsync(_locators.Description8A08D, _data.Resolve("{{data:description_204}}"));
            await _ui.PressAsync(_locators.Description8A08D, "Tab");
            await _ui.PressAsync(_locators.Description8A08D, "Tab");
        }
        if (_data.Condition("'Risk Type' != NULL"))
        {
            await _ui.FillAsync(_locators.RiskType, _data.Resolve("{{data:risk_type_205}}"));
            await _ui.PressAsync(_locators.RiskType, "Tab");
            await _ui.PressAsync(_locators.RiskType, "Tab");
        }
        if (_data.Condition("Coinsurance != NULL"))
        {
            await _ui.FillAsync(_locators.Coinsurance6348B, _data.Resolve("{{data:coinsurance_206}}"));
            await _ui.PressAsync(_locators.Coinsurance6348B, "Tab");
            await _ui.PressAsync(_locators.Coinsurance6348B, "Tab");
        }
        if (_data.Condition("Deductible != NULL"))
        {
            await _ui.FillAsync(_locators.Deductible01AB9, _data.Resolve("{{data:deductible_207}}"));
            await _ui.PressAsync(_locators.Deductible01AB9, "Tab");
            await _ui.PressAsync(_locators.Deductible01AB9, "Tab");
        }
        if (_data.Condition("'Deductible Increased Theft' != NULL"))
        {
            await _ui.FillAsync(_locators.DeductibleIncreasedTheftF76DB, _data.Resolve("{{data:deductible_increased_theft_208}}"));
            await _ui.PressAsync(_locators.DeductibleIncreasedTheftF76DB, "Tab");
            await _ui.PressAsync(_locators.DeductibleIncreasedTheftF76DB, "Tab");
        }
        if (_data.Condition("'Deductible Wind Hail' != NULL"))
        {
            await _ui.FillAsync(_locators.DeductibleWindHailAB1C3, _data.Resolve("{{data:deductible_wind_hail_209}}"));
            await _ui.PressAsync(_locators.DeductibleWindHailAB1C3, "Tab");
            await _ui.PressAsync(_locators.DeductibleWindHailAB1C3, "Tab");
        }
        if (_data.Condition("'Cause Of Loss' != NULL"))
        {
            await _ui.FillAsync(_locators.CauseOfLoss, _data.Resolve("{{data:cause_of_loss_210}}"));
            await _ui.PressAsync(_locators.CauseOfLoss, "Tab");
            await _ui.PressAsync(_locators.CauseOfLoss, "Tab");
        }
        if (_data.Condition("Valuation != NULL"))
        {
            await _ui.FillAsync(_locators.Valuation, _data.Resolve("{{data:valuation_211}}"));
            await _ui.PressAsync(_locators.Valuation, "Tab");
            await _ui.PressAsync(_locators.Valuation, "Tab");
        }
        await _ui.ClickAsync(_locators.AddGroup);
    }

    // Business step: I complete Structure Questions
    public async Task CompleteStructureQuestionsAsync2()
    {
        // CPNavigationLinks_d0fcc0Page.NavigateToPropertyScreen_0131_677267Async
        await _ui.ClickAsync(_locators.Property);
        // PropertyMain_a49a9ePage.FillOutMainPropertyQuestions_0132_677267Async
        if (_data.Condition("'Increased Pollutant Cleanup' != NULL"))
        {
            await _ui.FillAsync(_locators.IncreasedPollutantCleanup, _data.Resolve("{{data:increased_pollutant_cleanup_214}}"));
            await _ui.PressAsync(_locators.IncreasedPollutantCleanup, "Tab");
            await _ui.PressAsync(_locators.IncreasedPollutantCleanup, "Tab");
        }
        if (_data.Condition("'Debris Removal Additional' != NULL"))
        {
            await _ui.FillAsync(_locators.DebrisRemovalAdditional, _data.Resolve("{{data:debris_removal_additional_215}}"));
            await _ui.PressAsync(_locators.DebrisRemovalAdditional, "Tab");
            await _ui.PressAsync(_locators.DebrisRemovalAdditional, "Tab");
        }
        if (_data.Condition("'Debris Removal Additional Limit' != NULL"))
        {
            await _ui.FillAsync(_locators.DebrisRemovalAdditionalLimit, _data.Resolve("{{data:debris_removal_additional_limit_216}}"));
            await _ui.PressAsync(_locators.DebrisRemovalAdditionalLimit, "Tab");
            await _ui.PressAsync(_locators.DebrisRemovalAdditionalLimit, "Tab");
        }
        if (_data.Condition("'Vacant Building' != NULL"))
        {
            await _ui.FillAsync(_locators.VacantBuilding, _data.Resolve("{{data:vacant_building_217}}"));
            await _ui.PressAsync(_locators.VacantBuilding, "Tab");
            await _ui.PressAsync(_locators.VacantBuilding, "Tab");
        }
        if (_data.Condition("'% Occupied' != NULL"))
        {
            await _ui.FillAsync(_locators.Occupied, _data.Resolve("{{data:occupied_218}}"));
            await _ui.PressAsync(_locators.Occupied, "Tab");
            await _ui.PressAsync(_locators.Occupied, "Tab");
        }
        if (_data.Condition("'Pier Or Wharf' != NULL"))
        {
            await _ui.FillAsync(_locators.PierOrWharf, _data.Resolve("{{data:pier_or_wharf_219}}"));
            await _ui.PressAsync(_locators.PierOrWharf, "Tab");
            await _ui.PressAsync(_locators.PierOrWharf, "Tab");
        }
        if (_data.Condition("'Pier Or Wharf Construction' != NULL"))
        {
            await _ui.FillAsync(_locators.PierOrWharfConstruction, _data.Resolve("{{data:pier_or_wharf_construction_220}}"));
            await _ui.PressAsync(_locators.PierOrWharfConstruction, "Tab");
            await _ui.PressAsync(_locators.PierOrWharfConstruction, "Tab");
        }
        if (_data.Condition("'Pier Or Wharf Cause Of Loss' != NULL"))
        {
            await _ui.FillAsync(_locators.PierOrWharfCauseOfLoss, _data.Resolve("{{data:pier_or_wharf_cause_of_loss_221}}"));
            await _ui.PressAsync(_locators.PierOrWharfCauseOfLoss, "Tab");
            await _ui.PressAsync(_locators.PierOrWharfCauseOfLoss, "Tab");
            await _ui.PressAsync(_locators.PierOrWharfCauseOfLoss, "Tab");
        }
        if (_data.Condition("'Pier Or Wharf COL Options' != NULL"))
        {
            await _ui.FillAsync(_locators.PierOrWharfCOLOptions, _data.Resolve("{{data:pier_or_wharf_col_options_222}}"));
            await _ui.PressAsync(_locators.PierOrWharfCOLOptions, "Tab");
            await _ui.PressAsync(_locators.PierOrWharfCOLOptions, "CLICK");
            await _ui.PressAsync(_locators.PierOrWharfCOLOptions, "Tab");
        }
        if (_data.Condition("'Vacancy Permit' != NULL"))
        {
            await _ui.FillAsync(_locators.VacancyPermit, _data.Resolve("{{data:vacancy_permit_223}}"));
            await _ui.PressAsync(_locators.VacancyPermit, "Tab");
            await _ui.PressAsync(_locators.VacancyPermit, "Tab");
        }
        if (_data.Condition("'Pier Or Wharf COL Options' != NULL"))
        {
            await _ui.WaitAsync(_locators.PierOrWharfCOLOptions, "Exists");
        }
        // PropertyAddClass_ed4d5dPage.PropertyAddClass_0133_677267Async
        await _ui.ClickAsync(_locators.AddClassDCD8F);
        if (_data.Condition("(State !=\"OR\")||(State!=\"WA\")||(State!=\"VT\")"))
        {
            await _ui.FillAsync(_locators.SearchValue54F3C, _data.Resolve("{{data:search_value_226}}"));
            await _ui.PressAsync(_locators.SearchValue54F3C, "CLICK");
            await _ui.PressAsync(_locators.SearchValue54F3C, "Tab");
            await _ui.PressAsync(_locators.SearchValue54F3C, "Tab");
        }
        if (_data.Condition("(State !=\"OR\")||(State!=\"WA\")||(State!=\"VT\")"))
        {
            await _ui.FillAsync(_locators.SearchResultsD0AA8, _data.Resolve("{{data:search_results_227}}"));
            await _ui.PressAsync(_locators.SearchResultsD0AA8, "CLICK");
            await _ui.PressAsync(_locators.SearchResultsD0AA8, "Enter");
            await _ui.PressAsync(_locators.SearchResultsD0AA8, "Tab");
            await _ui.PressAsync(_locators.SearchResultsD0AA8, "Tab");
        }
        await _ui.FillAsync(_locators.OccupancyType, _data.Resolve("{{data:occupancy_type_228}}"));
        await _ui.PressAsync(_locators.OccupancyType, "CLICK");
        await _ui.PressAsync(_locators.OccupancyType, "Tab");
        if (_data.Condition("(State ==\"OR\")||(State==\"WA\")"))
        {
            await _ui.FillAsync(_locators.SearchResultsD0AA8, _data.Resolve(""));
        }
        await _ui.ClickAsync(_locators.PropertyAddClassOK);
        await _ui.FillAsync(_locators.BuildingRatingGroup, _data.Resolve("{{data:building_rating_group_231}}"));
        await _ui.PressAsync(_locators.BuildingRatingGroup, "Tab");
        await _ui.PressAsync(_locators.BuildingRatingGroup, "CLICK");
        await _ui.PressAsync(_locators.BuildingRatingGroup, "Tab");
        await _ui.FillAsync(_locators.BuildingLimit, _data.Resolve("{{data:building_limit_232}}"));
        await _ui.PressAsync(_locators.BuildingLimit, "Tab");
        await _ui.PressAsync(_locators.BuildingLimit, "Tab");
        await _ui.FillAsync(_locators.PersonalPropertyRatingGroup, _data.Resolve("{{data:personal_property_rating_group_233}}"));
        await _ui.PressAsync(_locators.PersonalPropertyRatingGroup, "Tab");
        await _ui.PressAsync(_locators.PersonalPropertyRatingGroup, "Tab");
        await _ui.FillAsync(_locators.PersonalPropertyLimit, _data.Resolve("{{data:personal_property_limit_234}}"));
        await _ui.PressAsync(_locators.PersonalPropertyLimit, "Tab");
        await _ui.PressAsync(_locators.PersonalPropertyLimit, "Tab");
        await _ui.FillAsync(_locators.PropertyOfOthersRatingGroup, _data.Resolve("{{data:property_of_others_rating_group_235}}"));
        await _ui.PressAsync(_locators.PropertyOfOthersRatingGroup, "Tab");
        await _ui.PressAsync(_locators.PropertyOfOthersRatingGroup, "Tab");
        await _ui.PressAsync(_locators.PropertyOfOthersRatingGroup, "Tab");
        await _ui.FillAsync(_locators.PropertyOfOthersLimit, _data.Resolve("{{data:property_of_others_limit_236}}"));
        await _ui.PressAsync(_locators.PropertyOfOthersLimit, "Tab");
        await _ui.PressAsync(_locators.PropertyOfOthersLimit, "Tab");
        if (_data.Condition("(State ==\"OR\")||(State==\"WA\")"))
        {
            await _ui.FillAsync(_locators.SearchValue54F3C, _data.Resolve("{{data:search_value_237}}"));
            await _ui.PressAsync(_locators.SearchValue54F3C, "CLICK");
            await _ui.PressAsync(_locators.SearchValue54F3C, "Tab");
            await _ui.PressAsync(_locators.SearchValue54F3C, "Tab");
        }
        // PropertyEnterBuildingRCT_b0af04Page.PropertyEnterBuildingRCT_0134_677267Async
        await _ui.ClickAsync(_locators.Detail7F662);
        await _ui.FillAsync(_locators.EstimatorType, _data.Resolve("{{data:estimator_type_239}}"));
        await _ui.PressAsync(_locators.EstimatorType, "Tab");
        await _ui.PressAsync(_locators.EstimatorType, "Tab");
        await _ui.FillAsync(_locators.ValuationType, _data.Resolve("{{data:valuation_type_240}}"));
        await _ui.PressAsync(_locators.ValuationType, "Tab");
        await _ui.PressAsync(_locators.ValuationType, "Tab");
        await _ui.ClickAsync(_locators.CreateValuation);
        await _ui.ClickAsync(_locators.GetCalculatedValue);
        await _ui.ClickAsync(_locators.PropertyEnterBuildingRCTOK);
    }

    // Business step: I complete required billing information for billing
    public async Task CompleteRequiredBillingInformationForBillingAsync3()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0138_677267Async
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0139_677267Async
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_267}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_270}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_274}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0140_677267Async
        await Task.Delay(1000);
    }

    // Business step: I add notepad comment
    public async Task AddNotepadCommentAsync6()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToNotePadScreen_0141_677267Async
        await _ui.ClickAsync(_locators.Notepad);
        // NotePad_055c33Page.AddNotesRemarksToNotePad_0142_677267Async
        await _ui.WaitAsync(_locators.NotepadHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNotesRemarks);
        await _ui.FillAsync(_locators.TextBox, _data.Resolve("Test {B[Product (LOB)]}"));
        await _ui.ClickAsync(_locators.NotePadOK);
    }

    // Business step: I complete Property UW Questions
    public async Task CompletePropertyUWQuestionsAsync2()
    {
        // CPNavigationLinks_d0fcc0Page.NavigateToPropertyUWQuestions_0143_677267Async
        await _ui.ClickAsync(_locators.PropertyUWQuestions8452C);
        // PropertyUWQuestions_8f0a46Page.UpdateAnswersForPropertyUWQuestions_0144_677267Async
        await _ui.WaitAsync(_locators.PropertyUWQuestions790F2, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswers99D68);
        await _ui.PressAsync(_locators.UpdateAnswers99D68, "Tab");
        await _ui.PressAsync(_locators.UpdateAnswers99D68, "Tab");
        await _ui.PressAsync(_locators.UpdateAnswers99D68, "Tab");
        await _ui.PressAsync(_locators.UpdateAnswers99D68, "Tab");
        // CommonNavigationLinks_dba56bPage.SaveForLater_0145_677267Async
        await _ui.FillAsync(_locators.Client35F85, _data.Resolve(""));
        await _ui.ClickAsync(_locators.SaveForLater);
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0146_677267Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_287}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_288}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_289}}"), "value");
    }

    // Business step: I complete required submission information
    public async Task CompleteRequiredSubmissionInformationAsync6()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0182_677267Async
        await _ui.WaitAsync(_locators.Submission, "Visible");
        await _ui.ClickAsync(_locators.Submission);
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutRequiredFields_0183_677267Async
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_341}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "CLICK");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.OrderAudit_0184_677267Async
        await _ui.VerifyAsync(_locators.OrderAudit, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutOrderAudit_0185_677267Async
        await _ui.FillAsync(_locators.OrderAudit, _data.Resolve("{{data:order_audit_343}}"));
        await _ui.PressAsync(_locators.OrderAudit, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeSubmissionScreenHeaderExists_0186_677267Async
        await _ui.VerifyAsync(_locators.SubmissionHeading, _data.Resolve("Absent"), "");
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0187_677267Async
        await _ui.PressAsync(_locators.Submission, "PRE:TAB");
        await _ui.PressAsync(_locators.Submission, "Tab");
        await _ui.ClickAsync(_locators.Submission);
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0188_677267Async
        await Task.Delay(1000);
        // SubmissionRequiredAndOptionalFields_4090a9Page.WaitOnSubmissionScreenToLoad_0189_677267Async
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        // TBoxWait_7ea9e1Page.N500msWaitForSyncing_0190_677267Async
        await Task.Delay(1000);
    }

    // Business step: I add Third Party Designee
    public async Task AddThirdPartyDesigneeAsync()
    {
        // ClientNamedInsuredCommon_9ad77bPage.CheckIfOnClient_0051_a6f47eAsync
        await _ui.VerifyAsync(_locators.Client070F4, _data.Resolve("Absent"), "");
        // CommonNavigationLinks_dba56bPage.NavigateToClient_0052_a6f47eAsync
        await _ui.ClickAsync(_locators.Client35F85);
        // TBoxWait_7ea9e1Page.SmallWaitForRefresh_0053_a6f47eAsync
        await Task.Delay(1000);
        // CommonNavigationLinks_dba56bPage.ClickThirdPartyDesignee_0054_a6f47eAsync
        await _ui.ClickAsync(_locators.ThirdPartyDesignee);
        // ClientThirdPartyDesigneeCommon_f0cb01Page.AddThirdPartyInfo_0055_a6f47eAsync
        await _ui.WaitAsync(_locators.HeadingThirdPartyDesignee, "Exists");
        await _ui.ClickAsync(_locators.AddThirdParty);
        await _ui.WaitAsync(_locators.AdditionalOtherInterestInputFirstName, "Exists");
        await _ui.FillAsync(_locators.AdditionalOtherInterestInputFirstName, _data.Resolve("{{data:additionalotherinterestinput_firstname_52}}"));
        await _ui.PressAsync(_locators.AdditionalOtherInterestInputFirstName, "Tab");
        await _ui.PressAsync(_locators.AdditionalOtherInterestInputFirstName, "CLICK");
        await _ui.WaitAsync(_locators.AdditionalOtherInterestInputLastName, "Exists");
        // Random data AdditionalOtherInterestInputLastName_0055 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.AdditionalOtherInterestInputAddress1, _data.Resolve("{{data:additionalotherinterestinput_address1_55}}"));
        await _ui.PressAsync(_locators.AdditionalOtherInterestInputAddress1, "Tab");
        await _ui.FillAsync(_locators.ZipCodeBCEA0, _data.Resolve("{{data:zip_code_56}}"));
        await _ui.PressAsync(_locators.ZipCodeBCEA0, "Tab");
        // ClientThirdPartyDesigneeCommon_f0cb01Page.ConfirmAddition_0056_a6f47eAsync
        await _ui.ClickAsync(_locators.CommonOK);
        // ClientNamedInsuredCommon_9ad77bPage.WaitForSynchronization_0057_a6f47eAsync
        await _ui.WaitAsync(_locators.Client070F4, "Exists");
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync11()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0075_a6f47eAsync
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0076_a6f47eAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0077_a6f47eAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0078_a6f47eAsync
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_94}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_95}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0079_a6f47eAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0080_a6f47eAsync
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_97}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_101}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0081_a6f47eAsync
        _data.Set("StateIsKansas", _data.Resolve("Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0082_a6f47eAsync
        if (_data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_103}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_104}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0083_a6f47eAsync
        _data.Set("StateIsVirginia", _data.Resolve("Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0084_a6f47eAsync
        if (_data.Condition("'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_106}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_107}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0085_a6f47eAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0086_a6f47eAsync
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_111}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0087_a6f47eAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0088_a6f47eAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AL BAP StraightThrough {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I navigate to policy coverages
    public async Task NavigateToPolicyCoveragesAsync2()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToPolicyCoverage_0117_a6f47eAsync
        await _ui.WaitAsync(_locators.PolicyCovgerage, "Exists");
        await _ui.ClickAsync(_locators.PolicyCovgerage);
        // PolicyCoverageLimits_bce0bdPage.AddCoverages_0118_a6f47eAsync
        await _ui.WaitAsync(_locators.PolicyCovg26786, "Exists");
        await _ui.FillAsync(_locators.TrailerInterchangeCompDeductible, _data.Resolve("{{data:trailer_interchange_comp_deductible_166}}"));
        await _ui.PressAsync(_locators.TrailerInterchangeCompDeductible, "Click");
        await _ui.PressAsync(_locators.TrailerInterchangeCompDeductible, "Enter");
        await _ui.PressAsync(_locators.TrailerInterchangeCompDeductible, "Tab");
        await _ui.FillAsync(_locators.TrailerInterchangeCollisionDeductible, _data.Resolve("{{data:trailer_interchange_collision_deductible_167}}"));
        await _ui.PressAsync(_locators.TrailerInterchangeCollisionDeductible, "Click");
        await _ui.PressAsync(_locators.TrailerInterchangeCollisionDeductible, "Enter");
        await _ui.PressAsync(_locators.TrailerInterchangeCollisionDeductible, "Tab");
        // PolicyCoverageLimits_bce0bdPage.WaitForSynchronization_0119_a6f47eAsync
        await _ui.WaitAsync(_locators.PolicyCovg26786, "Exists");
    }

    // Business step: I add NonOwnership Liability
    public async Task AddNonOwnershipLiabilityAsync()
    {
        // PolicyCoverageLimits_bce0bdPage.CheckIfOnPolicyCovg_0121_a6f47eAsync
        await _ui.VerifyAsync(_locators.PolicyCovg26786, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToPolicyCovg_0122_a6f47eAsync
        await _ui.ClickAsync(_locators.PolicyCovgerage);
        // PolicyCoverageNonOwned_80ca70Page.EnterNonownershipSelections_0123_a6f47eAsync
        await _ui.FillAsync(_locators.NonOwnedAuto, _data.Resolve("{{data:non_owned_auto_172}}"));
        await _ui.PressAsync(_locators.NonOwnedAuto, "Click");
        await _ui.PressAsync(_locators.NonOwnedAuto, "Tab");
        await _ui.WaitAsync(_locators.OfEmployees, "Exists");
        await _ui.FillAsync(_locators.OfEmployees, _data.Resolve("{{data:of_employees_174}}"));
        await _ui.PressAsync(_locators.OfEmployees, "Tab");
        await _ui.PressAsync(_locators.OfEmployees, "Tab");
        await _ui.FillAsync(_locators.OfPartners, _data.Resolve("{{data:of_partners_175}}"));
        await _ui.PressAsync(_locators.OfPartners, "Tab");
        await _ui.PressAsync(_locators.OfPartners, "Tab");
        await _ui.FillAsync(_locators.ExtendedEmployeeCoverage, _data.Resolve("{{data:extended_employee_coverage_176}}"));
        await _ui.PressAsync(_locators.ExtendedEmployeeCoverage, "Click");
        await _ui.PressAsync(_locators.ExtendedEmployeeCoverage, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0124_a6f47eAsync
        await Task.Delay(1000);
    }

    // Business step: I add Business Interruption
    public async Task AddBusinessInterruptionAsync()
    {
        // PolicyCoverageLimits_bce0bdPage.CheckIfOnPolicyCovg_0125_a6f47eAsync
        await _ui.VerifyAsync(_locators.PolicyCovg26786, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToPolicyCovg_0126_a6f47eAsync
        await _ui.ClickAsync(_locators.PolicyCovgerage);
        // PolicyCoverageBusinessInterruption_f15acaPage.SelectBusinessInterruption_0127_a6f47eAsync
        await _ui.FillAsync(_locators.BusinessInterruptionEndorsement, _data.Resolve("{{data:business_interruption_endorsement_180}}"));
        await _ui.PressAsync(_locators.BusinessInterruptionEndorsement, "Click");
        await _ui.PressAsync(_locators.BusinessInterruptionEndorsement, "Tab");
        await _ui.WaitAsync(_locators.Detail4A746, "Exists");
        // PolicyCoverageBusinessInterruption_f15acaPage.SelectFormAndOptions_0128_a6f47eAsync
        await _ui.ClickAsync(_locators.Detail4A746);
        await _ui.WaitAsync(_locators.BusinessInterruptionDetail, "Exists");
        await _ui.PressAsync(_locators.DescriptionOfBusinessActivites, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfBusinessActivites, "Tab");
        await _ui.PressAsync(_locators.DescriptionOfBusinessActivites, "Tab");
        await _ui.ClickAsync(_locators.OptionACheckBox);
        await _ui.WaitAsync(_locators.OptionAScheduleButton, "Exists");
        await _ui.FillAsync(_locators.DescriptionOfBusinessActivites, _data.Resolve("{{data:description_of_business_activites_187}}"));
        await _ui.PressAsync(_locators.DescriptionOfBusinessActivites, "Tab");
        await _ui.PressAsync(_locators.DescriptionOfBusinessActivites, "Tab");
        // PolicyCoverageBusinessInterruption_f15acaPage.ChooseOptionA_0129_a6f47eAsync
        await _ui.ClickAsync(_locators.OptionAScheduleButton);
        // PolicyCoverageBusinessInterruptionOptionASchedule_c3eb3aPage.ListScheduleProperty_0130_a6f47eAsync
        await _ui.WaitAsync(_locators.OptionA, "Exists");
        await _ui.ClickAsync(_locators.AddOptionA);
        await _ui.WaitAsync(_locators.BusinessInterruptionLimitOfInsurance, "Exists");
        await _ui.FillAsync(_locators.BusinessInterruptionLimitOfInsurance, _data.Resolve("{{data:iframe_duck_creek_policy_business_interruption_limit_of_insurance_192}}"));
        await _ui.PressAsync(_locators.BusinessInterruptionLimitOfInsurance, "Tab");
        await _ui.PressAsync(_locators.BusinessInterruptionDescriptionOfScheduledProperty, "PRE:TAB");
        await _ui.PressAsync(_locators.BusinessInterruptionDescriptionOfScheduledProperty, "Tab");
        await _ui.FillAsync(_locators.BusinessInterruptionDescriptionOfScheduledProperty, _data.Resolve("{{data:iframe_duck_creek_policy_business_interruption_description_of_scheduledproperty_194}}"));
        await _ui.PressAsync(_locators.BusinessInterruptionDescriptionOfScheduledProperty, "Tab");
        // PolicyCoverageBusinessInterruptionOptionASchedule_c3eb3aPage.ConfirmAddition_0131_a6f47eAsync
        await _ui.ClickAsync(_locators.OK);
        // TBoxWait_7ea9e1Page.ShortStaticWaitForSynchronization_0132_a6f47eAsync
        await Task.Delay(1000);
        // PolicyCoverageBusinessInterruptionOptionASchedule_c3eb3aPage.CheckForIFRAME_0133_a6f47eAsync
        await _ui.VerifyAsync(_locators.IFRAME280B0, _data.Resolve("Exists"), "");
        // PolicyCoverageBusinessInterruptionOptionASchedule_c3eb3aPage.WaitForIFRAMEToClose_0134_a6f47eAsync
        await _ui.WaitAsync(_locators.IFRAME280B0, "Absent");
        // PolicyCoverageBusinessInterruption_f15acaPage.ReturnToPolicyCovg_0135_a6f47eAsync
        await _ui.ClickAsync(_locators.BusinessInterruptionOK);
        // PolicyCoverageLimits_bce0bdPage.WaitForSynchronization_0136_a6f47eAsync
        await _ui.WaitAsync(_locators.PolicyCovg26786, "Exists");
    }

    // Business step: I complete required location information
    public async Task CompleteRequiredLocationInformationAsync3()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToLocation_0137_a6f47eAsync
        await _ui.WaitAsync(_locators.LocationA1D91, "Exists");
        await _ui.ClickAsync(_locators.LocationA1D91);
        // Location_d219c6Page.WaitForSynchronization_0138_a6f47eAsync
        await _ui.WaitAsync(_locators.Location82D95, "Exists");
        await _ui.VerifyAsync(_locators.ZipCodeD2DBA, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
    }

    // Business step: I add UM/UIM Coverage
    public async Task AddUMUIMCoverageAsync()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToStateDetails_0139_a6f47eAsync
        await _ui.ClickAsync(_locators.StateDetails33183);
        await _ui.WaitAsync(_locators.StateDetailsDetail, "Exists");
        await _ui.ClickAsync(_locators.StateDetailsDetail);
        await _ui.WaitAsync(_locators.StateDetailsDetail, "Absent");
        // StateDetailsUMUIM_f65252Page.WaitForSynchronization_0140_a6f47eAsync
        await _ui.WaitAsync(_locators.UMUIMOK, "Visible");
        // StateDetailsUMUIM_f65252Page.EnterBasicUMInfo_0141_a6f47eAsync
        await _ui.WaitAsync(_locators.StateDetails72631, "Exists");
        if (_data.Condition("'UM Type Default' != NULL"))
        {
            await _ui.FillAsync(_locators.UMTypeDefaultSelections, _data.Resolve("{{data:um_type_default_selections_211}}"));
            await _ui.PressAsync(_locators.UMTypeDefaultSelections, "CLICK");
            await _ui.PressAsync(_locators.UMTypeDefaultSelections, "RETURN");
            await _ui.PressAsync(_locators.UMTypeDefaultSelections, "Tab");
            await _ui.PressAsync(_locators.UMTypeDefaultSelections, "Tab");
            await _ui.PressAsync(_locators.UMTypeDefaultSelections, "Tab");
        }
        if (_data.Condition("'UMBI Limit' != NULL AND 'UM Type Default' != \"UMBIPD CSL\""))
        {
            await _ui.FillAsync(_locators.UMBILimit, _data.Resolve("{{data:umbi_limit_212}}"));
            await _ui.PressAsync(_locators.UMBILimit, "CLICK");
            await _ui.PressAsync(_locators.UMBILimit, "Tab");
            await _ui.PressAsync(_locators.UMBILimit, "Tab");
            await _ui.PressAsync(_locators.UMBILimit, "Tab");
        }
        // StateDetailsUMUIM_f65252Page.EnterBasicUIMInfo_0142_a6f47eAsync
        await _ui.WaitAsync(_locators.StateDetails72631, "Exists");
        await _ui.VerifyAsync(_locators.UMUIMOK, _data.Resolve("Exists"), "");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0143_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0144_a6f47eAsync
        await Task.Delay(1000);
        // StateDetailsUMUIM_f65252Page.ConfirmChanges_0145_a6f47eAsync
        await _ui.ClickAsync(_locators.UMUIMOK);
        // BAPNavigationLinks_e0270bPage.WaitForReturnToStateDetails_0146_a6f47eAsync
        await _ui.WaitAsync(_locators.StateDetailsDetail, "Exists");
    }

    // Business step: I add Policy Level Coverages
    public async Task AddPolicyLevelCoveragesAsync()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToStateDetails_0147_a6f47eAsync
        await _ui.ClickAsync(_locators.StateDetails33183);
        await _ui.WaitAsync(_locators.StateDetailsDetail, "Exists");
        await _ui.ClickAsync(_locators.StateDetailsDetail);
        await _ui.WaitAsync(_locators.StateDetailsDetail, "Absent");
        // StateDetailsUMUIM_f65252Page.WaitForSynchronization_0148_a6f47eAsync
        await _ui.WaitAsync(_locators.UMUIMOK, "Visible");
        // StateDetailsHiredAutoLiability_ce8259Page.AddHiredAutoLiability_0149_a6f47eAsync
        await _ui.ClickAsync(_locators.HiredAutoLiability);
        await _ui.ClickAsync(_locators.PrimaryLiabilityIfAny);
        await _ui.ClickAsync(_locators.ExcessLiabilityIfAny);
        await _ui.ClickAsync(_locators.EmployeeHiredAutosCheckBox);
        await _ui.ClickAsync(_locators.VolunteerHiredAutosCheckBox);
        // TBoxWait_7ea9e1Page.TBoxWaitForSynchronization_0151_a6f47eAsync
        await Task.Delay(1000);
        // StateDetailsDriveOtherCar_c9281ePage.AddDriveOtherCar_0152_a6f47eAsync
        await _ui.ClickAsync(_locators.DriveOtherCar);
        await _ui.ClickAsync(_locators.Comprehensive);
        await _ui.WaitAsync(_locators.OTCDeductibleE0D59, "Exists");
        await _ui.ClickAsync(_locators.Collision);
        await _ui.WaitAsync(_locators.CollisionDeductible63D4C, "Exists");
        await _ui.PressAsync(_locators.FirstName5059E, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstName5059E, "Tab");
        await _ui.FillAsync(_locators.LastName5E149, _data.Resolve("{{data:last_name_236}}"));
        await _ui.PressAsync(_locators.LastName5E149, "Tab");
        await _ui.FillAsync(_locators.FirstName5059E, _data.Resolve("{{data:first_name_237}}"));
        await _ui.PressAsync(_locators.FirstName5059E, "Tab");
        // TBoxWait_7ea9e1Page.TBoxWaitForSynchronization_0153_a6f47eAsync
        await Task.Delay(1000);
        // StateDetailsHiredAutoPDWithoutDriver_0a6537Page.AddHiredAutoPDWithoutDriver_0154_a6f47eAsync
        await _ui.ClickAsync(_locators.HiredAutoPhysicalDamageWithoutDriver);
        await _ui.FillAsync(_locators.OTCDeductibleEF1DE, _data.Resolve("{{data:otc_deductible_240}}"));
        await _ui.PressAsync(_locators.OTCDeductibleEF1DE, "Click");
        await _ui.PressAsync(_locators.OTCDeductibleEF1DE, "Tab");
        await _ui.ClickAsync(_locators.OTCIfAny4EFEE);
        await _ui.FillAsync(_locators.CollisionDeductible9C100, _data.Resolve("{{data:collision_deductible_242}}"));
        await _ui.PressAsync(_locators.CollisionDeductible9C100, "Tab");
        await _ui.PressAsync(_locators.CollisionDeductible9C100, "Tab");
        await _ui.PressAsync(_locators.CollisionDeductible9C100, "Tab");
        await _ui.ClickAsync(_locators.CollisionIfAny7532D);
        // TBoxWait_7ea9e1Page.TBoxWaitForSynchronization_0156_a6f47eAsync
        await Task.Delay(1000);
        // StateDetailsHiredAutoPhysicalDamageWithDriver_cc0b49Page.AddHiredAutoPDWithDriver_0157_a6f47eAsync
        await _ui.ClickAsync(_locators.HiredAutoPhysicalDamageWithDriver);
        await _ui.FillAsync(_locators.OTCDeductible62C21, _data.Resolve("{{data:otc_deductible_246}}"));
        await _ui.PressAsync(_locators.OTCDeductible62C21, "Click");
        await _ui.PressAsync(_locators.OTCDeductible62C21, "Tab");
        await _ui.PressAsync(_locators.OTCDeductible62C21, "Tab");
        await _ui.ClickAsync(_locators.OTCIfAny6A58B);
        await _ui.FillAsync(_locators.CollisionDeductibleAEEBB, _data.Resolve("{{data:collision_deductible_248}}"));
        await _ui.PressAsync(_locators.CollisionDeductibleAEEBB, "CLICK");
        await _ui.PressAsync(_locators.CollisionDeductibleAEEBB, "Enter");
        await _ui.PressAsync(_locators.CollisionDeductibleAEEBB, "Tab");
        await _ui.PressAsync(_locators.CollisionDeductibleAEEBB, "Tab");
        await _ui.ClickAsync(_locators.CollisionIfAny8AEE8);
        await _ui.FillAsync(_locators.VehicleInformation, _data.Resolve("{{data:vehicle_information_250}}"));
        await _ui.PressAsync(_locators.VehicleInformation, "Tab");
        await _ui.PressAsync(_locators.VehicleInformation, "Tab");
        // TBoxWait_7ea9e1Page.TBoxWaitForSynchronization_0160_a6f47eAsync
        await Task.Delay(1000);
        // StateDetailsUMUIM_f65252Page.ConfirmAddition_0162_a6f47eAsync
        await _ui.ClickAsync(_locators.UMUIMOK);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingMask_0163_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Exists"), "");
        // IndicatorsAndErrors_ea9144Page.WaitForMaskToGoAway_0164_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // TBoxWait_7ea9e1Page.TBoxWait_0165_a6f47eAsync
        await Task.Delay(1000);
        // BAPNavigationLinks_e0270bPage.WaitForSynchronization_0166_a6f47eAsync
        await _ui.WaitAsync(_locators.StateDetailsDetail, "Visible");
    }

    // Business step: I add a Risk
    public async Task AddARiskAsync()
    {
        // RiskAggregate_e66594Page.CheckIfOnRisk_0167_a6f47eAsync
        await _ui.VerifyAsync(_locators.RiskDDE70, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToRisk_0168_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskSchedule, "Exists");
        await _ui.ClickAsync(_locators.RiskSchedule);
        // RiskAggregate_e66594Page.WaitForSynchronization_0169_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0170_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0171_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // RiskAggregate_e66594Page.SelectVehicleType_0172_a6f47eAsync
        await _ui.WaitAsync(_locators.ShowAllLocations, "Exists");
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_264}}"));
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.WaitAsync(_locators.VehicleType, "Exists");
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_266}}"));
        await _ui.PressAsync(_locators.VehicleType, "CLICK");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.VerifyAsync(_locators.VehicleType, _data.Resolve("{{data:expected_vehicle_type_value_267}}"), "value");
        await _ui.ClickAsync(_locators.AddRiskAtThisLocation);
        // RiskScheduleVehicleInformation_e69550Page.WaitForSynchronization_0173_a6f47eAsync
        await _ui.WaitAsync(_locators.CommercialAutoRiskDetail, "Exists");
        // RiskScheduleVehicleInformation_e69550Page.EnterVIN_0174_a6f47eAsync
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.WaitAsync(_locators.VIN, "Visible");
        }
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.Year, _data.Resolve(""));
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.Make, _data.Resolve(""));
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.Model, _data.Resolve(""));
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.PressAsync(_locators.VIN, "PRE:TAB");
            await _ui.PressAsync(_locators.VIN, "Tab");
            await _ui.PressAsync(_locators.VIN, "Tab");
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.VIN, _data.Resolve("{{data:vin_275}}"));
            await _ui.PressAsync(_locators.VIN, "Tab");
            await _ui.PressAsync(_locators.VIN, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsKY_0175_a6f47eAsync
        _data.Set("StateIsKY", _data.Resolve("'\"\"{B[State]}\"\"' == 'KY'"));
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0176_a6f47eAsync
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.VerifyAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("Exists"), "");
        }
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0177_a6f47eAsync
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_278}}"));
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Click");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Enter");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsNotUT_0178_a6f47eAsync
        _data.Set("StateIsNotUT", _data.Resolve("'\"\"{B[State]}\"\"' != 'UT'"));
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0181_a6f47eAsync
        if (_data.Condition("GCW != NULL"))
        {
            await _ui.FillAsync(_locators.GCW, _data.Resolve(""));
        }
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve(""));
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsNJ_0185_a6f47eAsync
        _data.Set("StateIsNJ", _data.Resolve("'\"\"{B[State]}\"\"' == 'NJ'"));
        // TBoxEvaluationTool_b95b5cPage.VehicleTypeIsRegistrationPlates_0186_a6f47eAsync
        _data.Set("VehicleTypeIsRegistrationPlates", _data.Resolve("'\"\"Private Passenger\"\"' == 'Registration Plates'"));
        // TBoxEvaluationTool_b95b5cPage.VINIsMobileHomeContents_0188_a6f47eAsync
        _data.Set("VINIsMobileHomeContents", _data.Resolve("'\"\"1G1AB08C0CA598143\"\"' == 'ContentsVIN1234'"));
        // RiskSchedulePhysicalDamage_c46a6aPage.CheckIfCollisionCovExists_0190_a6f47eAsync
        await _ui.VerifyAsync(_locators.CollisionCoverage, _data.Resolve("Exists"), "");
        // RiskSchedulePhysicalDamage_c46a6aPage.AnswerCollisionAsNoIfNull_0191_a6f47eAsync
        if (_data.Condition("'Collision Coverage' == NULL"))
        {
            await _ui.FillAsync(_locators.CollisionCoverage, _data.Resolve("{{data:collision_coverage_286}}"));
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
        }
        // RiskSchedulePhysicalDamage_c46a6aPage.ConfirmVehicleAddition_0192_a6f47eAsync
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0193_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0194_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // TBoxWait_7ea9e1Page.TBoxWait_0195_a6f47eAsync
        await Task.Delay(1000);
        // RiskAggregate_e66594Page.CheckIfOnRisk_0196_a6f47eAsync
        await _ui.VerifyAsync(_locators.RiskDDE70, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToRisk_0197_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskSchedule, "Exists");
        await _ui.ClickAsync(_locators.RiskSchedule);
        // RiskAggregate_e66594Page.WaitForSynchronization_0198_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0199_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0200_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // RiskAggregate_e66594Page.SelectVehicleType_0201_a6f47eAsync
        await _ui.WaitAsync(_locators.ShowAllLocations, "Exists");
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_298}}"));
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.WaitAsync(_locators.VehicleType, "Exists");
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_300}}"));
        await _ui.PressAsync(_locators.VehicleType, "CLICK");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.VerifyAsync(_locators.VehicleType, _data.Resolve("{{data:expected_vehicle_type_value_301}}"), "value");
        await _ui.ClickAsync(_locators.AddRiskAtThisLocation);
        // RiskScheduleVehicleInformation_e69550Page.WaitForSynchronization_0202_a6f47eAsync
        await _ui.WaitAsync(_locators.CommercialAutoRiskDetail, "Exists");
        // RiskScheduleVehicleInformation_e69550Page.EnterVIN_0203_a6f47eAsync
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.WaitAsync(_locators.VIN, "Visible");
        }
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.Year, _data.Resolve(""));
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.Make, _data.Resolve(""));
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.Model, _data.Resolve(""));
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.PressAsync(_locators.VIN, "PRE:TAB");
            await _ui.PressAsync(_locators.VIN, "Tab");
            await _ui.PressAsync(_locators.VIN, "Tab");
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.VIN, _data.Resolve("{{data:vin_309}}"));
            await _ui.PressAsync(_locators.VIN, "Tab");
            await _ui.PressAsync(_locators.VIN, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsKY_0204_a6f47eAsync
        _data.Set("StateIsKY", _data.Resolve("'\"\"{B[State]}\"\"' == 'KY'"));
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0205_a6f47eAsync
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.VerifyAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("Exists"), "");
        }
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0206_a6f47eAsync
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_312}}"));
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Click");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Enter");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsNotUT_0207_a6f47eAsync
        _data.Set("StateIsNotUT", _data.Resolve("'\"\"{B[State]}\"\"' != 'UT'"));
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0210_a6f47eAsync
        if (_data.Condition("GCW != NULL"))
        {
            await _ui.FillAsync(_locators.GCW, _data.Resolve(""));
        }
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_315}}"));
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Click");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Enter");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
        }
        // RiskSchedulePhysicalDamage_c46a6aPage.AddRemovePhysicalDamage_0213_a6f47eAsync
        if (_data.Condition("'OTC Causes of Loss' != NULL"))
        {
            await _ui.FillAsync(_locators.OTCCausesOfLoss, _data.Resolve("{{data:otc_causes_of_loss_316}}"));
            await _ui.PressAsync(_locators.OTCCausesOfLoss, "CLICK");
            await _ui.PressAsync(_locators.OTCCausesOfLoss, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsNJ_0214_a6f47eAsync
        _data.Set("StateIsNJ", _data.Resolve("'\"\"{B[State]}\"\"' == 'NJ'"));
        // TBoxEvaluationTool_b95b5cPage.VehicleTypeIsRegistrationPlates_0215_a6f47eAsync
        _data.Set("VehicleTypeIsRegistrationPlates", _data.Resolve("'\"\"Truck\"\"' == 'Registration Plates'"));
        // TBoxEvaluationTool_b95b5cPage.VINIsMobileHomeContents_0217_a6f47eAsync
        _data.Set("VINIsMobileHomeContents", _data.Resolve("'\"\"1FDBR10S8EU598143\"\"' == 'ContentsVIN1234'"));
        // RiskSchedulePhysicalDamage_c46a6aPage.CheckIfCollisionCovExists_0219_a6f47eAsync
        await _ui.VerifyAsync(_locators.CollisionCoverage, _data.Resolve("Exists"), "");
        // RiskSchedulePhysicalDamage_c46a6aPage.AnswerCollisionAsNoIfNull_0220_a6f47eAsync
        if (_data.Condition("'Collision Coverage' == NULL"))
        {
            await _ui.FillAsync(_locators.CollisionCoverage, _data.Resolve("{{data:collision_coverage_321}}"));
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
        }
        // RiskSchedulePhysicalDamage_c46a6aPage.ConfirmVehicleAddition_0221_a6f47eAsync
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0222_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0223_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // TBoxWait_7ea9e1Page.TBoxWait_0224_a6f47eAsync
        await Task.Delay(1000);
        // RiskAggregate_e66594Page.CheckIfOnRisk_0225_a6f47eAsync
        await _ui.VerifyAsync(_locators.RiskDDE70, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToRisk_0226_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskSchedule, "Exists");
        await _ui.ClickAsync(_locators.RiskSchedule);
        // RiskAggregate_e66594Page.WaitForSynchronization_0227_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0228_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0229_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // RiskAggregate_e66594Page.SelectVehicleType_0230_a6f47eAsync
        await _ui.WaitAsync(_locators.ShowAllLocations, "Exists");
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_333}}"));
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.WaitAsync(_locators.VehicleType, "Exists");
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_335}}"));
        await _ui.PressAsync(_locators.VehicleType, "CLICK");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.VerifyAsync(_locators.VehicleType, _data.Resolve("{{data:expected_vehicle_type_value_336}}"), "value");
        await _ui.ClickAsync(_locators.AddRiskAtThisLocation);
        // RiskScheduleVehicleInformation_e69550Page.WaitForSynchronization_0231_a6f47eAsync
        await _ui.WaitAsync(_locators.CommercialAutoRiskDetail, "Exists");
        // RiskScheduleVehicleInformation_e69550Page.EnterVIN_0232_a6f47eAsync
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.WaitAsync(_locators.VIN, "Visible");
        }
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.Year, _data.Resolve(""));
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.Make, _data.Resolve(""));
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.Model, _data.Resolve(""));
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.PressAsync(_locators.VIN, "PRE:TAB");
            await _ui.PressAsync(_locators.VIN, "Tab");
            await _ui.PressAsync(_locators.VIN, "Tab");
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.VIN, _data.Resolve("{{data:vin_344}}"));
            await _ui.PressAsync(_locators.VIN, "Tab");
            await _ui.PressAsync(_locators.VIN, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsKY_0233_a6f47eAsync
        _data.Set("StateIsKY", _data.Resolve("'\"\"{B[State]}\"\"' == 'KY'"));
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0234_a6f47eAsync
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.VerifyAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("Exists"), "");
        }
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0235_a6f47eAsync
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_347}}"));
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Click");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Enter");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsNotUT_0236_a6f47eAsync
        _data.Set("StateIsNotUT", _data.Resolve("'\"\"{B[State]}\"\"' != 'UT'"));
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0239_a6f47eAsync
        if (_data.Condition("GCW != NULL"))
        {
            await _ui.FillAsync(_locators.GCW, _data.Resolve("{{data:gcw_349}}"));
            await _ui.PressAsync(_locators.GCW, "Click");
            await _ui.PressAsync(_locators.GCW, "Enter");
            await _ui.PressAsync(_locators.GCW, "Tab");
            await _ui.PressAsync(_locators.GCW, "Tab");
        }
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve(""));
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsNJ_0243_a6f47eAsync
        _data.Set("StateIsNJ", _data.Resolve("'\"\"{B[State]}\"\"' == 'NJ'"));
        // TBoxEvaluationTool_b95b5cPage.VehicleTypeIsRegistrationPlates_0244_a6f47eAsync
        _data.Set("VehicleTypeIsRegistrationPlates", _data.Resolve("'\"\"Truck Tractor\"\"' == 'Registration Plates'"));
        // TBoxEvaluationTool_b95b5cPage.VINIsMobileHomeContents_0246_a6f47eAsync
        _data.Set("VINIsMobileHomeContents", _data.Resolve("'\"\"JHBSG1HD7P2598143\"\"' == 'ContentsVIN1234'"));
        // RiskSchedulePhysicalDamage_c46a6aPage.CheckIfCollisionCovExists_0248_a6f47eAsync
        await _ui.VerifyAsync(_locators.CollisionCoverage, _data.Resolve("Exists"), "");
        // RiskSchedulePhysicalDamage_c46a6aPage.AnswerCollisionAsNoIfNull_0249_a6f47eAsync
        if (_data.Condition("'Collision Coverage' == NULL"))
        {
            await _ui.FillAsync(_locators.CollisionCoverage, _data.Resolve("{{data:collision_coverage_355}}"));
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
        }
        // RiskSchedulePhysicalDamage_c46a6aPage.ConfirmVehicleAddition_0250_a6f47eAsync
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0251_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0252_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // TBoxWait_7ea9e1Page.TBoxWait_0253_a6f47eAsync
        await Task.Delay(1000);
        // RiskAggregate_e66594Page.CheckIfOnRisk_0254_a6f47eAsync
        await _ui.VerifyAsync(_locators.RiskDDE70, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToRisk_0255_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskSchedule, "Exists");
        await _ui.ClickAsync(_locators.RiskSchedule);
        // RiskAggregate_e66594Page.WaitForSynchronization_0256_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0257_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0258_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // RiskAggregate_e66594Page.SelectVehicleType_0259_a6f47eAsync
        await _ui.WaitAsync(_locators.ShowAllLocations, "Exists");
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_367}}"));
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.WaitAsync(_locators.VehicleType, "Exists");
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_369}}"));
        await _ui.PressAsync(_locators.VehicleType, "CLICK");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.VerifyAsync(_locators.VehicleType, _data.Resolve("{{data:expected_vehicle_type_value_370}}"), "value");
        await _ui.ClickAsync(_locators.AddRiskAtThisLocation);
        // RiskScheduleVehicleInformation_e69550Page.WaitForSynchronization_0260_a6f47eAsync
        await _ui.WaitAsync(_locators.CommercialAutoRiskDetail, "Exists");
        // RiskScheduleVehicleInformation_e69550Page.EnterVIN_0261_a6f47eAsync
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.WaitAsync(_locators.VIN, "Visible");
        }
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.Year, _data.Resolve(""));
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.Make, _data.Resolve(""));
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.Model, _data.Resolve(""));
        }
        if (_data.Condition("'Value Basis' != NULL"))
        {
            await _ui.FillAsync(_locators.ValueBasis, _data.Resolve("{{data:value_basis_377}}"));
            await _ui.PressAsync(_locators.ValueBasis, "Click");
            await _ui.PressAsync(_locators.ValueBasis, "Tab");
            await _ui.PressAsync(_locators.ValueBasis, "Tab");
        }
        if (_data.Condition("'Original Cost New' != NULL"))
        {
            await _ui.FillAsync(_locators.OriginalCostNew, _data.Resolve("{{data:original_cost_new_378}}"));
            await _ui.PressAsync(_locators.OriginalCostNew, "CLICK");
            await _ui.PressAsync(_locators.OriginalCostNew, "Tab");
            await _ui.PressAsync(_locators.OriginalCostNew, "Tab");
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.PressAsync(_locators.VIN, "PRE:TAB");
            await _ui.PressAsync(_locators.VIN, "Tab");
            await _ui.PressAsync(_locators.VIN, "Tab");
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.VIN, _data.Resolve("{{data:vin_380}}"));
            await _ui.PressAsync(_locators.VIN, "Tab");
            await _ui.PressAsync(_locators.VIN, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsKY_0262_a6f47eAsync
        _data.Set("StateIsKY", _data.Resolve("'\"\"{B[State]}\"\"' == 'KY'"));
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0263_a6f47eAsync
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.VerifyAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("Exists"), "");
        }
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0264_a6f47eAsync
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_383}}"));
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Click");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Enter");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsNotUT_0265_a6f47eAsync
        _data.Set("StateIsNotUT", _data.Resolve("'\"\"{B[State]}\"\"' != 'UT'"));
        // RiskScheduleGeneralCoverage_61d1eaPage.EnterGeneralCoverage_0266_a6f47eAsync
        if (_data.Condition("'Used as Showroom' != NULL"))
        {
            await _ui.FillAsync(_locators.UsedAsShowroom, _data.Resolve("{{data:used_as_showroom_385}}"));
            await _ui.PressAsync(_locators.UsedAsShowroom, "CLICK");
            await _ui.PressAsync(_locators.UsedAsShowroom, "Tab");
        }
        // RiskScheduleGeneralCoverage_61d1eaPage.EnterGeneralCoverage_0267_a6f47eAsync
        if (_data.Condition("'Used as Showroom' != NULL"))
        {
            await _ui.FillAsync(_locators.UsedAsShowroom, _data.Resolve("{{data:used_as_showroom_386}}"));
            await _ui.PressAsync(_locators.UsedAsShowroom, "CLICK");
            await _ui.PressAsync(_locators.UsedAsShowroom, "Tab");
        }
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0268_a6f47eAsync
        if (_data.Condition("GCW != NULL"))
        {
            await _ui.FillAsync(_locators.GCW, _data.Resolve(""));
        }
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve(""));
        }
        if (_data.Condition("'2nd Class Category' != NULL"))
        {
            await _ui.FillAsync(_locators.N2ndClassCategory, _data.Resolve("{{data:2nd_class_category_389}}"));
            await _ui.PressAsync(_locators.N2ndClassCategory, "Click");
            await _ui.PressAsync(_locators.N2ndClassCategory, "Tab");
        }
        if (_data.Condition("'2nd Class Code' != NULL"))
        {
            await _ui.FillAsync(_locators.N2ndClassCode, _data.Resolve("{{data:2nd_class_code_390}}"));
            await _ui.PressAsync(_locators.N2ndClassCode, "Click");
            await _ui.PressAsync(_locators.N2ndClassCode, "Tab");
            await _ui.PressAsync(_locators.N2ndClassCode, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsNJ_0272_a6f47eAsync
        _data.Set("StateIsNJ", _data.Resolve("'\"\"{B[State]}\"\"' == 'NJ'"));
        // TBoxEvaluationTool_b95b5cPage.VehicleTypeIsRegistrationPlates_0273_a6f47eAsync
        _data.Set("VehicleTypeIsRegistrationPlates", _data.Resolve("'\"\"Semitrailer\"\"' == 'Registration Plates'"));
        // TBoxEvaluationTool_b95b5cPage.VINIsMobileHomeContents_0275_a6f47eAsync
        _data.Set("VINIsMobileHomeContents", _data.Resolve("'\"\"1C9402026X0112143\"\"' == 'ContentsVIN1234'"));
        // RiskSchedulePhysicalDamage_c46a6aPage.CheckIfCollisionCovExists_0277_a6f47eAsync
        await _ui.VerifyAsync(_locators.CollisionCoverage, _data.Resolve("Exists"), "");
        // RiskSchedulePhysicalDamage_c46a6aPage.AnswerCollisionAsNoIfNull_0278_a6f47eAsync
        if (_data.Condition("'Collision Coverage' == NULL"))
        {
            await _ui.FillAsync(_locators.CollisionCoverage, _data.Resolve("{{data:collision_coverage_395}}"));
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
        }
        // RiskSchedulePhysicalDamage_c46a6aPage.ConfirmVehicleAddition_0279_a6f47eAsync
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0280_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0281_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // TBoxWait_7ea9e1Page.TBoxWait_0282_a6f47eAsync
        await Task.Delay(1000);
        // RiskAggregate_e66594Page.CheckIfOnRisk_0283_a6f47eAsync
        await _ui.VerifyAsync(_locators.RiskDDE70, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToRisk_0284_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskSchedule, "Exists");
        await _ui.ClickAsync(_locators.RiskSchedule);
        // RiskAggregate_e66594Page.WaitForSynchronization_0285_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0286_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0287_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // RiskAggregate_e66594Page.SelectVehicleType_0288_a6f47eAsync
        await _ui.WaitAsync(_locators.ShowAllLocations, "Exists");
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_407}}"));
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.WaitAsync(_locators.VehicleType, "Exists");
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_409}}"));
        await _ui.PressAsync(_locators.VehicleType, "CLICK");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.VerifyAsync(_locators.VehicleType, _data.Resolve("{{data:expected_vehicle_type_value_410}}"), "value");
        await _ui.ClickAsync(_locators.AddRiskAtThisLocation);
        // RiskScheduleVehicleInformation_e69550Page.WaitForSynchronization_0289_a6f47eAsync
        await _ui.WaitAsync(_locators.CommercialAutoRiskDetail, "Exists");
        // RiskScheduleVehicleInformation_e69550Page.EnterVIN_0290_a6f47eAsync
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.WaitAsync(_locators.VIN, "Visible");
        }
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.Year, _data.Resolve("{{data:year_414}}"));
            await _ui.PressAsync(_locators.Year, "Tab");
            await _ui.PressAsync(_locators.Year, "Tab");
            await _ui.PressAsync(_locators.Year, "Tab");
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.Make, _data.Resolve("{{data:make_415}}"));
            await _ui.PressAsync(_locators.Make, "Tab");
            await _ui.PressAsync(_locators.Make, "Tab");
            await _ui.PressAsync(_locators.Make, "Tab");
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.Model, _data.Resolve("{{data:model_416}}"));
            await _ui.PressAsync(_locators.Model, "Tab");
            await _ui.PressAsync(_locators.Model, "Tab");
            await _ui.PressAsync(_locators.Model, "Tab");
        }
        if (_data.Condition("'Body Style' != NULL"))
        {
            await _ui.FillAsync(_locators.BodyStyle, _data.Resolve("{{data:body_style_417}}"));
            await _ui.PressAsync(_locators.BodyStyle, "Tab");
            await _ui.PressAsync(_locators.BodyStyle, "Tab");
            await _ui.PressAsync(_locators.BodyStyle, "Tab");
        }
        if (_data.Condition("'Stated Amount' != NULL"))
        {
            await _ui.FillAsync(_locators.StatedAmount, _data.Resolve("{{data:stated_amount_418}}"));
            await _ui.PressAsync(_locators.StatedAmount, "Tab");
            await _ui.PressAsync(_locators.StatedAmount, "Tab");
            await _ui.PressAsync(_locators.StatedAmount, "Tab");
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.PressAsync(_locators.VIN, "PRE:TAB");
            await _ui.PressAsync(_locators.VIN, "Tab");
            await _ui.PressAsync(_locators.VIN, "Tab");
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.VIN, _data.Resolve("{{data:vin_420}}"));
            await _ui.PressAsync(_locators.VIN, "Tab");
            await _ui.PressAsync(_locators.VIN, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsKY_0291_a6f47eAsync
        _data.Set("StateIsKY", _data.Resolve("'\"\"{B[State]}\"\"' == 'KY'"));
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0292_a6f47eAsync
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.VerifyAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("Exists"), "");
        }
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0293_a6f47eAsync
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_423}}"));
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Click");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Enter");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsNotUT_0294_a6f47eAsync
        _data.Set("StateIsNotUT", _data.Resolve("'\"\"{B[State]}\"\"' != 'UT'"));
        // RiskScheduleGeneralCoverage_61d1eaPage.EnterGeneralCoverage_0295_a6f47eAsync
        if (_data.Condition("'Engine Size' != NULL"))
        {
            await _ui.FillAsync(_locators.EngineSizeCc, _data.Resolve("{{data:engine_size_cc_425}}"));
            await _ui.PressAsync(_locators.EngineSizeCc, "Click");
            await _ui.PressAsync(_locators.EngineSizeCc, "Tab");
            await _ui.PressAsync(_locators.EngineSizeCc, "Tab");
        }
        // RiskScheduleGeneralCoverage_61d1eaPage.EnterGeneralCoverage_0296_a6f47eAsync
        if (_data.Condition("'Engine Size' != NULL"))
        {
            await _ui.FillAsync(_locators.EngineSizeCc, _data.Resolve("{{data:engine_size_cc_426}}"));
            await _ui.PressAsync(_locators.EngineSizeCc, "Click");
            await _ui.PressAsync(_locators.EngineSizeCc, "Tab");
            await _ui.PressAsync(_locators.EngineSizeCc, "Tab");
        }
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0297_a6f47eAsync
        if (_data.Condition("GCW != NULL"))
        {
            await _ui.FillAsync(_locators.GCW, _data.Resolve(""));
        }
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve(""));
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsNJ_0301_a6f47eAsync
        _data.Set("StateIsNJ", _data.Resolve("'\"\"{B[State]}\"\"' == 'NJ'"));
        // TBoxEvaluationTool_b95b5cPage.VehicleTypeIsRegistrationPlates_0302_a6f47eAsync
        _data.Set("VehicleTypeIsRegistrationPlates", _data.Resolve("'\"\"Golf Carts/Low Speed Vehicles\"\"' == 'Registration Plates'"));
        // TBoxEvaluationTool_b95b5cPage.VINIsMobileHomeContents_0304_a6f47eAsync
        _data.Set("VINIsMobileHomeContents", _data.Resolve("'\"\"5TSTE24338G020309\"\"' == 'ContentsVIN1234'"));
        // RiskSchedulePhysicalDamage_c46a6aPage.CheckIfCollisionCovExists_0306_a6f47eAsync
        await _ui.VerifyAsync(_locators.CollisionCoverage, _data.Resolve("Exists"), "");
        // RiskSchedulePhysicalDamage_c46a6aPage.AnswerCollisionAsNoIfNull_0307_a6f47eAsync
        if (_data.Condition("'Collision Coverage' == NULL"))
        {
            await _ui.FillAsync(_locators.CollisionCoverage, _data.Resolve("{{data:collision_coverage_433}}"));
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
        }
        // RiskSchedulePhysicalDamage_c46a6aPage.ConfirmVehicleAddition_0308_a6f47eAsync
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0309_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0310_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // TBoxWait_7ea9e1Page.TBoxWait_0311_a6f47eAsync
        await Task.Delay(1000);
        // RiskAggregate_e66594Page.CheckIfOnRisk_0312_a6f47eAsync
        await _ui.VerifyAsync(_locators.RiskDDE70, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToRisk_0313_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskSchedule, "Exists");
        await _ui.ClickAsync(_locators.RiskSchedule);
        // RiskAggregate_e66594Page.WaitForSynchronization_0314_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0315_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0316_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // RiskAggregate_e66594Page.SelectVehicleType_0317_a6f47eAsync
        await _ui.WaitAsync(_locators.ShowAllLocations, "Exists");
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_445}}"));
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.WaitAsync(_locators.VehicleType, "Exists");
        await _ui.FillAsync(_locators.VehicleType, _data.Resolve("{{data:vehicle_type_447}}"));
        await _ui.PressAsync(_locators.VehicleType, "CLICK");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.PressAsync(_locators.VehicleType, "Tab");
        await _ui.VerifyAsync(_locators.VehicleType, _data.Resolve("{{data:expected_vehicle_type_value_448}}"), "value");
        await _ui.ClickAsync(_locators.AddRiskAtThisLocation);
        // RiskScheduleVehicleInformation_e69550Page.WaitForSynchronization_0318_a6f47eAsync
        await _ui.WaitAsync(_locators.CommercialAutoRiskDetail, "Exists");
        // RiskScheduleVehicleInformation_e69550Page.EnterVIN_0319_a6f47eAsync
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.WaitAsync(_locators.VIN, "Visible");
        }
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.Year, _data.Resolve("{{data:year_452}}"));
            await _ui.PressAsync(_locators.Year, "Tab");
            await _ui.PressAsync(_locators.Year, "Tab");
            await _ui.PressAsync(_locators.Year, "Tab");
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.Make, _data.Resolve("{{data:make_453}}"));
            await _ui.PressAsync(_locators.Make, "Tab");
            await _ui.PressAsync(_locators.Make, "Tab");
            await _ui.PressAsync(_locators.Make, "Tab");
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.Model, _data.Resolve("{{data:model_454}}"));
            await _ui.PressAsync(_locators.Model, "Tab");
            await _ui.PressAsync(_locators.Model, "Tab");
            await _ui.PressAsync(_locators.Model, "Tab");
        }
        if (_data.Condition("'Body Style' != NULL"))
        {
            await _ui.FillAsync(_locators.BodyStyle, _data.Resolve("{{data:body_style_455}}"));
            await _ui.PressAsync(_locators.BodyStyle, "Tab");
            await _ui.PressAsync(_locators.BodyStyle, "Tab");
            await _ui.PressAsync(_locators.BodyStyle, "Tab");
        }
        if (_data.Condition("'Stated Amount' != NULL"))
        {
            await _ui.FillAsync(_locators.StatedAmount, _data.Resolve("{{data:stated_amount_456}}"));
            await _ui.PressAsync(_locators.StatedAmount, "Tab");
            await _ui.PressAsync(_locators.StatedAmount, "Tab");
            await _ui.PressAsync(_locators.StatedAmount, "Tab");
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.PressAsync(_locators.VIN, "PRE:TAB");
            await _ui.PressAsync(_locators.VIN, "Tab");
            await _ui.PressAsync(_locators.VIN, "Tab");
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.VIN, _data.Resolve("{{data:vin_458}}"));
            await _ui.PressAsync(_locators.VIN, "Tab");
            await _ui.PressAsync(_locators.VIN, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsKY_0320_a6f47eAsync
        _data.Set("StateIsKY", _data.Resolve("'\"\"{B[State]}\"\"' == 'KY'"));
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0321_a6f47eAsync
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.VerifyAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("Exists"), "");
        }
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0322_a6f47eAsync
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve("{{data:is_this_vehicle_used_in_snow_plow_operations_461}}"));
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Click");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Enter");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
            await _ui.PressAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsNotUT_0323_a6f47eAsync
        _data.Set("StateIsNotUT", _data.Resolve("'\"\"{B[State]}\"\"' != 'UT'"));
        // RiskScheduleRiskSpecific_88fa13Page.EnterRiskSpecific_0326_a6f47eAsync
        if (_data.Condition("GCW != NULL"))
        {
            await _ui.FillAsync(_locators.GCW, _data.Resolve(""));
        }
        if (_data.Condition("Snowplow != NULL"))
        {
            await _ui.FillAsync(_locators.IsThisVehicleUsedInSnowPlowOperations, _data.Resolve(""));
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsNJ_0330_a6f47eAsync
        _data.Set("StateIsNJ", _data.Resolve("'\"\"{B[State]}\"\"' == 'NJ'"));
        // TBoxEvaluationTool_b95b5cPage.VehicleTypeIsRegistrationPlates_0331_a6f47eAsync
        _data.Set("VehicleTypeIsRegistrationPlates", _data.Resolve("'\"\"Mobile Home\"\"' == 'Registration Plates'"));
        // TBoxEvaluationTool_b95b5cPage.VINIsMobileHomeContents_0333_a6f47eAsync
        _data.Set("VINIsMobileHomeContents", _data.Resolve("'\"\"MobileHomeVIN1234\"\"' == 'ContentsVIN1234'"));
        // RiskSchedulePhysicalDamage_c46a6aPage.CheckIfCollisionCovExists_0335_a6f47eAsync
        await _ui.VerifyAsync(_locators.CollisionCoverage, _data.Resolve("Exists"), "");
        // RiskSchedulePhysicalDamage_c46a6aPage.AnswerCollisionAsNoIfNull_0336_a6f47eAsync
        if (_data.Condition("'Collision Coverage' == NULL"))
        {
            await _ui.FillAsync(_locators.CollisionCoverage, _data.Resolve("{{data:collision_coverage_469}}"));
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
            await _ui.PressAsync(_locators.CollisionCoverage, "Tab");
        }
        // RiskSchedulePhysicalDamage_c46a6aPage.ConfirmVehicleAddition_0337_a6f47eAsync
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0338_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0339_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // TBoxWait_7ea9e1Page.TBoxWait_0340_a6f47eAsync
        await Task.Delay(1000);
    }

    // Business step: I add Risk Level Interest
    public async Task AddRiskLevelInterestAsync()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToRiskAggregate_0341_a6f47eAsync
        await _ui.ClickAsync(_locators.RiskSchedule);
        // RiskAggregate_e66594Page.WaitForSynchronization_0342_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // RiskAggregate_e66594Page.NavigateToRiskDetail_0343_a6f47eAsync
        await _ui.VerifyAsync(_locators.TypeD972C, _data.Resolve("{{data:constraint_vehicle_schedule_1_type_476}}"), "InnerText");
        await _ui.VerifyAsync(_locators.VehicleSchedule1Veh, _data.Resolve("{XB[VehicleNumber]}"), "value");
        await _ui.ClickAsync(_locators.Detail1664B);
        // RiskScheduleVehicleInformation_e69550Page.WaitForSynchronization_0344_a6f47eAsync
        await _ui.WaitAsync(_locators.CommercialAutoRiskDetail, "Exists");
        // RiskScheduleHiredAuto_6eb213Page.AddCoverage_0345_a6f47eAsync
        await _ui.FillAsync(_locators.HiredAutoExtAddlInsured, _data.Resolve("{{data:hired_auto_ext_addl_insured_480}}"));
        await _ui.PressAsync(_locators.HiredAutoExtAddlInsured, "Tab");
        await _ui.PressAsync(_locators.HiredAutoExtAddlInsured, "Enter");
        await _ui.PressAsync(_locators.HiredAutoExtAddlInsured, "Tab");
        await _ui.VerifyAsync(_locators.HiredAutoExtAddlInsured, _data.Resolve("{{data:expected_hired_auto_ext_addl_insured_value_481}}"), "value");
        await _ui.WaitAsync(_locators.HiredAutoForm, "Exists");
        await _ui.FillAsync(_locators.HiredAutoForm, _data.Resolve("{{data:hired_auto_form_483}}"));
        await _ui.PressAsync(_locators.HiredAutoForm, "CLICK");
        await _ui.PressAsync(_locators.HiredAutoForm, "Enter");
        await _ui.PressAsync(_locators.HiredAutoForm, "Tab");
        await _ui.PressAsync(_locators.HiredAutoForm, "CLICK");
        await _ui.PressAsync(_locators.HiredAutoForm, "Tab");
        await _ui.WaitAsync(_locators.HiredAutoForm, "NotEqual");
        // RiskScheduleHiredAuto_6eb213Page.WaitForSynchronizationSamePage_0346_a6f47eAsync
        await _ui.WaitAsync(_locators.HiredAutoOK, "Absent");
        // RiskSchedulePhysicalDamage_c46a6aPage.ConfirmChanges_0347_a6f47eAsync
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // RiskAggregate_e66594Page.WaitForSynchronizationBackToRiskSchedule_0348_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // BAPNavigationLinks_e0270bPage.NavigateToRiskAggregate_0349_a6f47eAsync
        await _ui.ClickAsync(_locators.RiskSchedule);
        // RiskAggregate_e66594Page.WaitForSynchronization_0350_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // RiskAggregate_e66594Page.NavigateToRiskDetail_0351_a6f47eAsync
        await _ui.VerifyAsync(_locators.TypeD972C, _data.Resolve("{{data:constraint_vehicle_schedule_1_type_490}}"), "InnerText");
        await _ui.VerifyAsync(_locators.VehicleSchedule1Veh, _data.Resolve("{XB[VehicleNumber]}"), "value");
        await _ui.ClickAsync(_locators.Detail1664B);
        // RiskScheduleVehicleInformation_e69550Page.WaitForSynchronization_0352_a6f47eAsync
        await _ui.WaitAsync(_locators.CommercialAutoRiskDetail, "Exists");
        // RiskScheduleHiredAuto_6eb213Page.AddCoverage_0353_a6f47eAsync
        await _ui.FillAsync(_locators.HiredAutoExtAddlInsured, _data.Resolve("{{data:hired_auto_ext_addl_insured_494}}"));
        await _ui.PressAsync(_locators.HiredAutoExtAddlInsured, "Tab");
        await _ui.PressAsync(_locators.HiredAutoExtAddlInsured, "Enter");
        await _ui.PressAsync(_locators.HiredAutoExtAddlInsured, "Tab");
        await _ui.VerifyAsync(_locators.HiredAutoExtAddlInsured, _data.Resolve("{{data:expected_hired_auto_ext_addl_insured_value_495}}"), "value");
        await _ui.WaitAsync(_locators.HiredAutoForm, "Exists");
        await _ui.FillAsync(_locators.HiredAutoForm, _data.Resolve("{{data:hired_auto_form_497}}"));
        await _ui.PressAsync(_locators.HiredAutoForm, "CLICK");
        await _ui.PressAsync(_locators.HiredAutoForm, "Enter");
        await _ui.PressAsync(_locators.HiredAutoForm, "Tab");
        await _ui.PressAsync(_locators.HiredAutoForm, "CLICK");
        await _ui.PressAsync(_locators.HiredAutoForm, "Tab");
        await _ui.WaitAsync(_locators.HiredAutoForm, "NotEqual");
        // RiskScheduleHiredAuto_6eb213Page.WaitForSynchronizationSamePage_0354_a6f47eAsync
        await _ui.WaitAsync(_locators.HiredAutoOK, "Absent");
        // RiskSchedulePhysicalDamage_c46a6aPage.ConfirmChanges_0355_a6f47eAsync
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // RiskAggregate_e66594Page.WaitForSynchronizationBackToRiskSchedule_0356_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // BAPNavigationLinks_e0270bPage.NavigateToRiskAggregate_0357_a6f47eAsync
        await _ui.ClickAsync(_locators.RiskSchedule);
        // RiskAggregate_e66594Page.WaitForSynchronization_0358_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // RiskAggregate_e66594Page.NavigateToRiskDetail_0359_a6f47eAsync
        await _ui.VerifyAsync(_locators.TypeD972C, _data.Resolve("{{data:constraint_vehicle_schedule_1_type_504}}"), "InnerText");
        await _ui.VerifyAsync(_locators.VehicleSchedule1Veh, _data.Resolve("{XB[VehicleNumber]}"), "value");
        await _ui.ClickAsync(_locators.Detail1664B);
        // RiskScheduleVehicleInformation_e69550Page.WaitForSynchronization_0360_a6f47eAsync
        await _ui.WaitAsync(_locators.CommercialAutoRiskDetail, "Exists");
        // RiskScheduleHiredAuto_6eb213Page.AddCoverage_0361_a6f47eAsync
        await _ui.FillAsync(_locators.HiredAutoExtAddlInsured, _data.Resolve("{{data:hired_auto_ext_addl_insured_508}}"));
        await _ui.PressAsync(_locators.HiredAutoExtAddlInsured, "Tab");
        await _ui.PressAsync(_locators.HiredAutoExtAddlInsured, "Enter");
        await _ui.PressAsync(_locators.HiredAutoExtAddlInsured, "Tab");
        await _ui.VerifyAsync(_locators.HiredAutoExtAddlInsured, _data.Resolve("{{data:expected_hired_auto_ext_addl_insured_value_509}}"), "value");
        await _ui.WaitAsync(_locators.HiredAutoForm, "Exists");
        await _ui.FillAsync(_locators.HiredAutoForm, _data.Resolve("{{data:hired_auto_form_511}}"));
        await _ui.PressAsync(_locators.HiredAutoForm, "CLICK");
        await _ui.PressAsync(_locators.HiredAutoForm, "Enter");
        await _ui.PressAsync(_locators.HiredAutoForm, "Tab");
        await _ui.PressAsync(_locators.HiredAutoForm, "CLICK");
        await _ui.PressAsync(_locators.HiredAutoForm, "Tab");
        await _ui.WaitAsync(_locators.HiredAutoForm, "NotEqual");
        if (_data.Condition("'First Name' != NULL"))
        {
            await _ui.PressAsync(_locators.HiredAutoCA2001FirstName, "PRE:TAB");
            await _ui.PressAsync(_locators.HiredAutoCA2001FirstName, "Tab");
        }
        if (_data.Condition("'Last Name' != NULL"))
        {
            await _ui.FillAsync(_locators.HiredAutoCA2001LastName, _data.Resolve("{{data:hiredauto_ca2001_last_name_514}}"));
            await _ui.PressAsync(_locators.HiredAutoCA2001LastName, "Tab");
            await _ui.PressAsync(_locators.HiredAutoCA2001LastName, "Tab");
        }
        if (_data.Condition("'Address 1' != NULL"))
        {
            await _ui.PressAsync(_locators.HiredAutoCA2001Address1, "PRE:TAB");
            await _ui.PressAsync(_locators.HiredAutoCA2001Address1, "Tab");
        }
        if (_data.Condition("'Zip Code' != NULL"))
        {
            await _ui.FillAsync(_locators.HiredAutoCA2001ZipCode, _data.Resolve("{{data:hiredauto_ca2001_zipcode_516}}"));
            await _ui.PressAsync(_locators.HiredAutoCA2001ZipCode, "Tab");
            await _ui.PressAsync(_locators.HiredAutoCA2001ZipCode, "Tab");
        }
        if (_data.Condition("'First Name' != NULL"))
        {
            await _ui.ClickAsync(_locators.HiredAutoOK);
        }
        if (_data.Condition("'First Name' != NULL"))
        {
            await _ui.FillAsync(_locators.HiredAutoCA2001FirstName, _data.Resolve("{{data:hiredauto_ca2001_first_name_518}}"));
            await _ui.PressAsync(_locators.HiredAutoCA2001FirstName, "Tab");
        }
        if (_data.Condition("'Address 1' != NULL"))
        {
            await _ui.FillAsync(_locators.HiredAutoCA2001Address1, _data.Resolve("{{data:hiredauto_ca2001_address1_519}}"));
            await _ui.PressAsync(_locators.HiredAutoCA2001Address1, "Tab");
        }
        // RiskScheduleHiredAuto_6eb213Page.WaitForSynchronizationSamePage_0362_a6f47eAsync
        await _ui.WaitAsync(_locators.HiredAutoOK, "Absent");
        // RiskSchedulePhysicalDamage_c46a6aPage.ConfirmChanges_0363_a6f47eAsync
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // RiskAggregate_e66594Page.WaitForSynchronizationBackToRiskSchedule_0364_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
    }

    // Business step: I verify Risk Level Coverages
    public async Task VerifyRiskLevelCoveragesAsync()
    {
        // RiskAggregate_e66594Page.NavigateToRiskDetail_0365_a6f47eAsync
        await _ui.VerifyAsync(_locators.TypeD972C, _data.Resolve("{{data:constraint_vehicle_schedule_1_type_523}}"), "InnerText");
        await _ui.VerifyAsync(_locators.VehicleSchedule1Veh, _data.Resolve("{XB[VehicleNumber]}"), "value");
        await _ui.ClickAsync(_locators.Detail1664B);
        // RiskScheduleVehicleInformation_e69550Page.WaitForSynchronization_0366_a6f47eAsync
        await _ui.WaitAsync(_locators.CommercialAutoRiskDetail, "Exists");
        // RiskScheduleLiabilityUMMedicalPIP_5d9957Page.VerifyUMUIMPIP_0367_a6f47eAsync
        if (_data.Condition("'Accept UM' != NULL"))
        {
            await _ui.VerifyAsync(_locators.AcceptUM, _data.Resolve("{{data:expected_accept_um_innertext_527}}"), "InnerText");
        }
        // RiskSchedulePhysicalDamage_c46a6aPage.ReturnToRiskSchedule_0368_a6f47eAsync
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0369_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0370_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0371_a6f47eAsync
        await Task.Delay(1000);
    }

    // Business step: I add Risk Level Coverages
    public async Task AddRiskLevelCoveragesAsync()
    {
        // RiskAggregate_e66594Page.NavigateToRiskDetail_0372_a6f47eAsync
        await _ui.VerifyAsync(_locators.TypeD972C, _data.Resolve("{{data:constraint_vehicle_schedule_1_type_532}}"), "InnerText");
        await _ui.VerifyAsync(_locators.VehicleSchedule1Veh, _data.Resolve("{XB[VehicleNumber]}"), "value");
        await _ui.ClickAsync(_locators.Detail1664B);
        // RiskScheduleVehicleInformation_e69550Page.WaitForSynchronization_0373_a6f47eAsync
        await _ui.WaitAsync(_locators.CommercialAutoRiskDetail, "Exists");
        // RiskSchedulePhysicalDamage_c46a6aPage.AddCoverages_0375_a6f47eAsync
        if (_data.Condition("'Loan/Lease Gap' != NULL"))
        {
            await _ui.FillAsync(_locators.LoanLeaseGap, _data.Resolve("{{data:loan_lease_gap_536}}"));
            await _ui.PressAsync(_locators.LoanLeaseGap, "Click");
            await _ui.PressAsync(_locators.LoanLeaseGap, "Enter");
            await _ui.PressAsync(_locators.LoanLeaseGap, "Tab");
            await _ui.PressAsync(_locators.LoanLeaseGap, "Tab");
        }
        if (_data.Condition("'Tapes Coverage' != NULL"))
        {
            await _ui.FillAsync(_locators.TapesCoverage, _data.Resolve("{{data:tapes_coverage_537}}"));
            await _ui.PressAsync(_locators.TapesCoverage, "Tab");
        }
        if (_data.Condition("'Audio Visual' != NULL"))
        {
            await _ui.FillAsync(_locators.AudioVisual, _data.Resolve("{{data:audio_visual_538}}"));
            await _ui.PressAsync(_locators.AudioVisual, "Tab");
            await _ui.PressAsync(_locators.AudioVisual, "Tab");
        }
        if (_data.Condition("'Audio Visual' != NULL"))
        {
            await _ui.FillAsync(_locators.AVCostNew, _data.Resolve("{{data:av_cost_new_539}}"));
            await _ui.PressAsync(_locators.AVCostNew, "Tab");
            await _ui.PressAsync(_locators.AVCostNew, "Tab");
            await _ui.PressAsync(_locators.AVCostNew, "Tab");
        }
        if (_data.Condition("Towing != NULL && 'Vehicle Type' == \"Private Passenger\""))
        {
            await _ui.FillAsync(_locators.Towing, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.PhysicalDamageOK, "Exists");
        // RiskSchedulePhysicalDamage_c46a6aPage.ConfirmAddition_0376_a6f47eAsync
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0377_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0378_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // TBoxWait_7ea9e1Page.TBoxWait_0379_a6f47eAsync
        await Task.Delay(1000);
        // RiskAggregate_e66594Page.WaitForSynchronization_0380_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // RiskAggregate_e66594Page.NavigateToRiskDetail_0381_a6f47eAsync
        await _ui.VerifyAsync(_locators.TypeD972C, _data.Resolve("{{data:constraint_vehicle_schedule_1_type_547}}"), "InnerText");
        await _ui.VerifyAsync(_locators.VehicleSchedule1Veh, _data.Resolve("{XB[VehicleNumber]}"), "value");
        await _ui.ClickAsync(_locators.Detail1664B);
        // RiskScheduleVehicleInformation_e69550Page.WaitForSynchronization_0382_a6f47eAsync
        await _ui.WaitAsync(_locators.CommercialAutoRiskDetail, "Exists");
        // RiskSchedulePhysicalDamage_c46a6aPage.AddCoverages_0384_a6f47eAsync
        if (_data.Condition("'Loan/Lease Gap' != NULL"))
        {
            await _ui.FillAsync(_locators.LoanLeaseGap, _data.Resolve("{{data:loan_lease_gap_551}}"));
            await _ui.PressAsync(_locators.LoanLeaseGap, "Click");
            await _ui.PressAsync(_locators.LoanLeaseGap, "Enter");
            await _ui.PressAsync(_locators.LoanLeaseGap, "Tab");
            await _ui.PressAsync(_locators.LoanLeaseGap, "Tab");
        }
        if (_data.Condition("'Tapes Coverage' != NULL"))
        {
            await _ui.FillAsync(_locators.TapesCoverage, _data.Resolve("{{data:tapes_coverage_552}}"));
            await _ui.PressAsync(_locators.TapesCoverage, "Tab");
        }
        if (_data.Condition("'Audio Visual' != NULL"))
        {
            await _ui.FillAsync(_locators.AudioVisual, _data.Resolve("{{data:audio_visual_553}}"));
            await _ui.PressAsync(_locators.AudioVisual, "Tab");
            await _ui.PressAsync(_locators.AudioVisual, "Tab");
        }
        if (_data.Condition("'Audio Visual' != NULL"))
        {
            await _ui.FillAsync(_locators.AVCostNew, _data.Resolve("{{data:av_cost_new_554}}"));
            await _ui.PressAsync(_locators.AVCostNew, "Tab");
            await _ui.PressAsync(_locators.AVCostNew, "Tab");
            await _ui.PressAsync(_locators.AVCostNew, "Tab");
        }
        await _ui.WaitAsync(_locators.PhysicalDamageOK, "Exists");
        // RiskSchedulePhysicalDamage_c46a6aPage.ConfirmAddition_0385_a6f47eAsync
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0386_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0387_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // TBoxWait_7ea9e1Page.TBoxWait_0388_a6f47eAsync
        await Task.Delay(1000);
        // RiskAggregate_e66594Page.WaitForSynchronization_0389_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
        // RiskAggregate_e66594Page.NavigateToRiskDetail_0390_a6f47eAsync
        await _ui.VerifyAsync(_locators.TypeD972C, _data.Resolve("{{data:constraint_vehicle_schedule_1_type_561}}"), "InnerText");
        await _ui.VerifyAsync(_locators.VehicleSchedule1Veh, _data.Resolve("{XB[VehicleNumber]}"), "value");
        await _ui.ClickAsync(_locators.Detail1664B);
        // RiskScheduleVehicleInformation_e69550Page.WaitForSynchronization_0391_a6f47eAsync
        await _ui.WaitAsync(_locators.CommercialAutoRiskDetail, "Exists");
        // RiskScheduleGeneralCoverage_61d1eaPage.EnterGeneralCoverage_0392_a6f47eAsync
        await _ui.FillAsync(_locators.SeasonalProduceTrailers, _data.Resolve("{{data:seasonal_produce_trailers_565}}"));
        await _ui.PressAsync(_locators.SeasonalProduceTrailers, "CLICK");
        await _ui.PressAsync(_locators.SeasonalProduceTrailers, "Tab");
        await _ui.WaitAsync(_locators.CoverageBeginDate, "Exists");
        await _ui.FillAsync(_locators.CoverageEndDate, _data.Resolve("{DATE[09-05-2026][+6M][MM-dd-yyyy]}"));
        await _ui.PressAsync(_locators.CoverageEndDate, "CLICK");
        await _ui.PressAsync(_locators.CoverageEndDate, "Tab");
        await _ui.FillAsync(_locators.ProduceCarried, _data.Resolve("{{data:produce_carried_568}}"));
        await _ui.PressAsync(_locators.ProduceCarried, "CLICK");
        await _ui.PressAsync(_locators.ProduceCarried, "Tab");
        // RiskSchedulePhysicalDamage_c46a6aPage.AddCoverages_0393_a6f47eAsync
        await _ui.WaitAsync(_locators.PhysicalDamageOK, "Exists");
        // RiskSchedulePhysicalDamage_c46a6aPage.ConfirmAddition_0394_a6f47eAsync
        await _ui.ClickAsync(_locators.PhysicalDamageOK);
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0395_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0396_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // TBoxWait_7ea9e1Page.TBoxWait_0397_a6f47eAsync
        await Task.Delay(1000);
        // RiskAggregate_e66594Page.WaitForSynchronization_0398_a6f47eAsync
        await _ui.WaitAsync(_locators.RiskDDE70, "Exists");
    }

    // Business step: I complete driver information
    public async Task CompleteDriverInformationAsync2()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToDriverSchedule_0399_a6f47eAsync
        await _ui.ClickAsync(_locators.DriverSchedule161DF);
        // DriverSchedule_d9e336Page.ClickAddADriver_0400_a6f47eAsync
        await _ui.WaitAsync(_locators.DriverSchedule79DC6, "Exists");
        await _ui.ClickAsync(_locators.AddDriver);
        // DriverDetail_d9a072Page.EnterDriverInfo_0401_a6f47eAsync
        await _ui.WaitAsync(_locators.DriverDetail, "Exists");
        await _ui.FillAsync(_locators.FirstName813D1, _data.Resolve("{{data:iframe_duck_creek_policy_first_name_579}}"));
        await _ui.PressAsync(_locators.FirstName813D1, "Tab");
        await _ui.PressAsync(_locators.FirstName813D1, "Tab");
        await _ui.PressAsync(_locators.FirstName813D1, "Tab");
        await _ui.FillAsync(_locators.LastName34FF6, _data.Resolve("{{data:iframe_duck_creek_policy_last_name_580}}"));
        await _ui.PressAsync(_locators.LastName34FF6, "Tab");
        await _ui.PressAsync(_locators.LastName34FF6, "Tab");
        await _ui.PressAsync(_locators.LastName34FF6, "Tab");
        await _ui.FillAsync(_locators.DateOfBirth, _data.Resolve("{DATE[09-05-2026][-40y][MM-dd-yyyy]}"));
        await _ui.PressAsync(_locators.DateOfBirth, "Tab");
        await _ui.PressAsync(_locators.DateOfBirth, "Tab");
        await _ui.PressAsync(_locators.DateOfBirth, "Tab");
        await _ui.FillAsync(_locators.StateLicensed, _data.Resolve("{{data:iframe_duck_creek_policy_state_licensed_582}}"));
        await _ui.PressAsync(_locators.StateLicensed, "Tab");
        await _ui.PressAsync(_locators.StateLicensed, "Tab");
        await _ui.PressAsync(_locators.StateLicensed, "Tab");
        await _ui.VerifyAsync(_locators.DriversLicenseNumber, _data.Resolve("{{data:expected_iframe_duck_creek_policy_drivers_license_number_innertext_583}}"), "InnerText");
        await _ui.FillAsync(_locators.Sex, _data.Resolve("{{data:iframe_duck_creek_policy_sex_584}}"));
        await _ui.PressAsync(_locators.Sex, "Tab");
        await _ui.FillAsync(_locators.MaritalStatus, _data.Resolve("{{data:iframe_duck_creek_policy_marital_status_585}}"));
        await _ui.PressAsync(_locators.MaritalStatus, "Tab");
        await _ui.PressAsync(_locators.MaritalStatus, "Tab");
        await _ui.FillAsync(_locators.YearLicensed, _data.Resolve("{{data:iframe_duck_creek_policy_year_licensed_586}}"));
        await _ui.PressAsync(_locators.YearLicensed, "Tab");
        await _ui.PressAsync(_locators.YearLicensed, "Tab");
        await _ui.FillAsync(_locators.DateOfHire, _data.Resolve("{{data:iframe_duck_creek_policy_date_of_hire_587}}"));
        await _ui.PressAsync(_locators.DateOfHire, "Tab");
        await _ui.PressAsync(_locators.DateOfHire, "Tab");
        await _ui.FillAsync(_locators.DoYouHaveACDLLicense, _data.Resolve("{{data:iframe_duck_creek_policy_do_you_have_a_cdl_license_588}}"));
        await _ui.PressAsync(_locators.DoYouHaveACDLLicense, "Tab");
        await _ui.ClickAsync(_locators.OK);
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0402_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0403_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
        // DriverDetail_d9a072Page.WaitForIFRAMEToClose_0404_a6f47eAsync
        await _ui.WaitAsync(_locators.IFRAME6D695, "Absent");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0405_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // IndicatorsAndErrors_ea9144Page.IndicatorsAndErrors_0406_a6f47eAsync
        await _ui.WaitAsync(_locators.LoadingMessage, "Absent");
    }

    // Business step: I verify Mandatory Endorsements
    public async Task VerifyMandatoryEndorsementsAsync()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToEndorsements_0407_a6f47eAsync
        await _ui.ClickAsync(_locators.EndorsementsC27F0);
        // BAPEndorsementSchedule_7d25f7Page.VerifyMandatoryEndorsements_0408_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        await _ui.VerifyAsync(_locators.EndorsementScheduleRow1, _data.Resolve("__BLANK__"), "InnerText");
        if (_data.Condition("'Endorsement Type' ==\"[CA2394] Silica or Silica-Related Dust Exclusion\""))
        {
            await _ui.VerifyAsync(_locators.EndorsementScheduleRow1, _data.Resolve("{{data:expected_endorsement_schedule_row_1_innertext_598}}"), "InnerText");
        }
        await _ui.VerifyAsync(_locators.EndorsementTableRow1, _data.Resolve("__BLANK__"), "InnerText");
        if (_data.Condition("'Endorsement Type' ==\"[CA2394] Silica or Silica-Related Dust Exclusion\""))
        {
            await _ui.VerifyAsync(_locators.EndorsementTableRow2, _data.Resolve("{{data:expected_endorsement_table_row_2_innertext_600}}"), "InnerText");
        }
    }

    // Business step: I add endorsement
    public async Task AddEndorsementAsync2()
    {
        // BAPEndorsementSchedule_7d25f7Page.CheckIfOnEndorsements_0410_a6f47eAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeadingA3D50, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToEndorsements_0411_a6f47eAsync
        await _ui.ClickAsync(_locators.EndorsementsC27F0);
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0412_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsements_bdb4d0Page.EnterRequiredEndorsementInfo_0413_a6f47eAsync
        await _ui.WaitAsync(_locators.ClickAddEndorsement, "Visible");
        await _ui.ClickAsync(_locators.ClickAddEndorsement);
        await _ui.WaitAsync(_locators.EndorsementDetail, "Exists");
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Year, _data.Resolve(""));
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Make, _data.Resolve(""));
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Model, _data.Resolve(""));
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940VIN, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.WaitAsync(_locators.EndorsementType624AD, "Exists");
        await _ui.ClickAsync(_locators.EndorsementType624AD);
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_614}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_615}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Click");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Enter");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        // BAPEndorsements_bdb4d0Page.ConfirmAddition_0414_a6f47eAsync
        await _ui.ClickAsync(_locators.OK);
        // BAPEndorsements_bdb4d0Page.CheckIfIFRAMEIsOpen_0415_a6f47eAsync
        await _ui.VerifyAsync(_locators.IFRAMEF0A48, _data.Resolve("Exists"), "");
        // BAPEndorsements_bdb4d0Page.WaitForIFRAMEToClose_0416_a6f47eAsync
        await _ui.WaitAsync(_locators.IFRAMEF0A48, "Absent");
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0417_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsementSchedule_7d25f7Page.CheckIfOnEndorsements_0419_a6f47eAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeadingA3D50, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToEndorsements_0420_a6f47eAsync
        await _ui.ClickAsync(_locators.EndorsementsC27F0);
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0421_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsements_bdb4d0Page.EnterRequiredEndorsementInfo_0422_a6f47eAsync
        await _ui.WaitAsync(_locators.ClickAddEndorsement, "Visible");
        await _ui.ClickAsync(_locators.ClickAddEndorsement);
        await _ui.WaitAsync(_locators.EndorsementDetail, "Exists");
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Year, _data.Resolve(""));
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Make, _data.Resolve(""));
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Model, _data.Resolve(""));
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940VIN, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.WaitAsync(_locators.EndorsementType624AD, "Exists");
        await _ui.ClickAsync(_locators.EndorsementType624AD);
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_633}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_634}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Click");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Enter");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        // BAPEndorsements_bdb4d0Page.ConfirmAddition_0423_a6f47eAsync
        await _ui.ClickAsync(_locators.OK);
        // BAPEndorsements_bdb4d0Page.CheckIfIFRAMEIsOpen_0424_a6f47eAsync
        await _ui.VerifyAsync(_locators.IFRAMEF0A48, _data.Resolve("Exists"), "");
        // BAPEndorsements_bdb4d0Page.WaitForIFRAMEToClose_0425_a6f47eAsync
        await _ui.WaitAsync(_locators.IFRAMEF0A48, "Absent");
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0426_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsementSchedule_7d25f7Page.CheckIfOnEndorsements_0428_a6f47eAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeadingA3D50, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToEndorsements_0429_a6f47eAsync
        await _ui.ClickAsync(_locators.EndorsementsC27F0);
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0430_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsements_bdb4d0Page.EnterRequiredEndorsementInfo_0431_a6f47eAsync
        await _ui.WaitAsync(_locators.ClickAddEndorsement, "Visible");
        await _ui.ClickAsync(_locators.ClickAddEndorsement);
        await _ui.WaitAsync(_locators.EndorsementDetail, "Exists");
        if (_data.Condition("'Endorsement Type' == \"[CA2325] Leased Workers Coverage\""))
        {
            await _ui.WaitAsync(_locators.CA2325LeasedWorkersCoverage, "Exists");
        }
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Year, _data.Resolve(""));
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Make, _data.Resolve(""));
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Model, _data.Resolve(""));
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940VIN, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.WaitAsync(_locators.EndorsementType624AD, "Exists");
        await _ui.ClickAsync(_locators.EndorsementType624AD);
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_653}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_654}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Click");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Enter");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        // BAPEndorsements_bdb4d0Page.ConfirmAddition_0432_a6f47eAsync
        await _ui.ClickAsync(_locators.OK);
        // BAPEndorsements_bdb4d0Page.CheckIfIFRAMEIsOpen_0433_a6f47eAsync
        await _ui.VerifyAsync(_locators.IFRAMEF0A48, _data.Resolve("Exists"), "");
        // BAPEndorsements_bdb4d0Page.WaitForIFRAMEToClose_0434_a6f47eAsync
        await _ui.WaitAsync(_locators.IFRAMEF0A48, "Absent");
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0435_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsementSchedule_7d25f7Page.CheckIfOnEndorsements_0437_a6f47eAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeadingA3D50, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToEndorsements_0438_a6f47eAsync
        await _ui.ClickAsync(_locators.EndorsementsC27F0);
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0439_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsements_bdb4d0Page.EnterRequiredEndorsementInfo_0440_a6f47eAsync
        await _ui.WaitAsync(_locators.ClickAddEndorsement, "Visible");
        await _ui.ClickAsync(_locators.ClickAddEndorsement);
        await _ui.WaitAsync(_locators.EndorsementDetail, "Exists");
        if (_data.Condition("'Add Excluded Driver' != NULL"))
        {
            await _ui.WaitAsync(_locators.ClickAddExcludedDriver, "Exists");
        }
        if (_data.Condition("'Add Excluded Driver' != NULL"))
        {
            await _ui.ClickAsync(_locators.ClickAddExcludedDriver);
        }
        if (_data.Condition("'Driver Name' != NULL"))
        {
            await _ui.FillAsync(_locators.AddDriverName, _data.Resolve("{{data:iframe_duck_creek_policy_add_driver_name_667}}"));
            await _ui.PressAsync(_locators.AddDriverName, "Tab");
            await _ui.PressAsync(_locators.AddDriverName, "Tab");
        }
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Year, _data.Resolve(""));
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Make, _data.Resolve(""));
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Model, _data.Resolve(""));
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940VIN, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.WaitAsync(_locators.EndorsementType624AD, "Exists");
        await _ui.ClickAsync(_locators.EndorsementType624AD);
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_675}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_676}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Click");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Enter");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        // BAPEndorsements_bdb4d0Page.ConfirmAddition_0441_a6f47eAsync
        await _ui.ClickAsync(_locators.OK);
        // BAPEndorsements_bdb4d0Page.CheckIfIFRAMEIsOpen_0442_a6f47eAsync
        await _ui.VerifyAsync(_locators.IFRAMEF0A48, _data.Resolve("Exists"), "");
        // BAPEndorsements_bdb4d0Page.WaitForIFRAMEToClose_0443_a6f47eAsync
        await _ui.WaitAsync(_locators.IFRAMEF0A48, "Absent");
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0444_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsementSchedule_7d25f7Page.CheckIfOnEndorsements_0446_a6f47eAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeadingA3D50, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToEndorsements_0447_a6f47eAsync
        await _ui.ClickAsync(_locators.EndorsementsC27F0);
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0448_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsements_bdb4d0Page.EnterRequiredEndorsementInfo_0449_a6f47eAsync
        await _ui.WaitAsync(_locators.ClickAddEndorsement, "Visible");
        await _ui.ClickAsync(_locators.ClickAddEndorsement);
        await _ui.WaitAsync(_locators.EndorsementDetail, "Exists");
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Year, _data.Resolve(""));
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Make, _data.Resolve(""));
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Model, _data.Resolve(""));
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940VIN, _data.Resolve(""));
        }
        if (_data.Condition("'Commodities Transported' != NULL"))
        {
            await _ui.FillAsync(_locators.CA9948ClassesOfCommoditiesTransported, _data.Resolve("{{data:iframe_duck_creek_policy_ca9948_classes_of_commodities_transported_691}}"));
            await _ui.PressAsync(_locators.CA9948ClassesOfCommoditiesTransported, "Click");
            await _ui.PressAsync(_locators.CA9948ClassesOfCommoditiesTransported, "Enter");
            await _ui.PressAsync(_locators.CA9948ClassesOfCommoditiesTransported, "Tab");
        }
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.WaitAsync(_locators.EndorsementType624AD, "Exists");
        await _ui.ClickAsync(_locators.EndorsementType624AD);
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_695}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_696}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Click");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Enter");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        // BAPEndorsements_bdb4d0Page.ConfirmAddition_0450_a6f47eAsync
        await _ui.ClickAsync(_locators.OK);
        // BAPEndorsements_bdb4d0Page.CheckIfIFRAMEIsOpen_0451_a6f47eAsync
        await _ui.VerifyAsync(_locators.IFRAMEF0A48, _data.Resolve("Exists"), "");
        // BAPEndorsements_bdb4d0Page.WaitForIFRAMEToClose_0452_a6f47eAsync
        await _ui.WaitAsync(_locators.IFRAMEF0A48, "Absent");
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0453_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsementSchedule_7d25f7Page.CheckIfOnEndorsements_0455_a6f47eAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeadingA3D50, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToEndorsements_0456_a6f47eAsync
        await _ui.ClickAsync(_locators.EndorsementsC27F0);
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0457_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsements_bdb4d0Page.EnterRequiredEndorsementInfo_0458_a6f47eAsync
        await _ui.WaitAsync(_locators.ClickAddEndorsement, "Visible");
        await _ui.ClickAsync(_locators.ClickAddEndorsement);
        await _ui.WaitAsync(_locators.EndorsementDetail, "Exists");
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Year, _data.Resolve(""));
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Make, _data.Resolve(""));
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Model, _data.Resolve(""));
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940VIN, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.WaitAsync(_locators.EndorsementType624AD, "Exists");
        await _ui.ClickAsync(_locators.EndorsementType624AD);
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_714}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_715}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Click");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Enter");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        // BAPEndorsements_bdb4d0Page.ConfirmAddition_0459_a6f47eAsync
        await _ui.ClickAsync(_locators.OK);
        // BAPEndorsements_bdb4d0Page.CheckIfIFRAMEIsOpen_0460_a6f47eAsync
        await _ui.VerifyAsync(_locators.IFRAMEF0A48, _data.Resolve("Exists"), "");
        // BAPEndorsements_bdb4d0Page.WaitForIFRAMEToClose_0461_a6f47eAsync
        await _ui.WaitAsync(_locators.IFRAMEF0A48, "Absent");
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0462_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsementSchedule_7d25f7Page.CheckIfOnEndorsements_0464_a6f47eAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeadingA3D50, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToEndorsements_0465_a6f47eAsync
        await _ui.ClickAsync(_locators.EndorsementsC27F0);
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0466_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsements_bdb4d0Page.EnterRequiredEndorsementInfo_0467_a6f47eAsync
        await _ui.WaitAsync(_locators.ClickAddEndorsement, "Visible");
        await _ui.ClickAsync(_locators.ClickAddEndorsement);
        await _ui.WaitAsync(_locators.EndorsementDetail, "Exists");
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Year, _data.Resolve(""));
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Make, _data.Resolve(""));
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Model, _data.Resolve(""));
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940VIN, _data.Resolve(""));
        }
        if (_data.Condition("'Endorsement Type' ==\"Trailer Interchange Coverage\""))
        {
            await _ui.FillAsync(_locators.TrailerInterchangeEnterDaysInsured, _data.Resolve("{{data:iframe_duck_creek_policy_trailer_interchange_enter_days_insured_730}}"));
            await _ui.PressAsync(_locators.TrailerInterchangeEnterDaysInsured, "Tab");
            await _ui.PressAsync(_locators.TrailerInterchangeEnterDaysInsured, "Tab");
        }
        if (_data.Condition("'Endorsement Type' ==\"Trailer Interchange Coverage\""))
        {
            await _ui.FillAsync(_locators.TrailerInterchangeEnterOfTrailers, _data.Resolve("{{data:iframe_duck_creek_policy_trailer_interchange_enter_of_trailers_731}}"));
            await _ui.PressAsync(_locators.TrailerInterchangeEnterOfTrailers, "Tab");
            await _ui.PressAsync(_locators.TrailerInterchangeEnterOfTrailers, "Tab");
        }
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.WaitAsync(_locators.EndorsementType624AD, "Exists");
        await _ui.ClickAsync(_locators.EndorsementType624AD);
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_735}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_736}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Click");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Enter");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        // BAPEndorsements_bdb4d0Page.ConfirmAddition_0468_a6f47eAsync
        await _ui.ClickAsync(_locators.OK);
        // BAPEndorsements_bdb4d0Page.CheckIfIFRAMEIsOpen_0469_a6f47eAsync
        await _ui.VerifyAsync(_locators.IFRAMEF0A48, _data.Resolve("Exists"), "");
        // BAPEndorsements_bdb4d0Page.WaitForIFRAMEToClose_0470_a6f47eAsync
        await _ui.WaitAsync(_locators.IFRAMEF0A48, "Absent");
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0471_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsementSchedule_7d25f7Page.CheckIfOnEndorsements_0473_a6f47eAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeadingA3D50, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToEndorsements_0474_a6f47eAsync
        await _ui.ClickAsync(_locators.EndorsementsC27F0);
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0475_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsements_bdb4d0Page.EnterRequiredEndorsementInfo_0476_a6f47eAsync
        await _ui.WaitAsync(_locators.ClickAddEndorsement, "Visible");
        await _ui.ClickAsync(_locators.ClickAddEndorsement);
        await _ui.WaitAsync(_locators.EndorsementDetail, "Exists");
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Year, _data.Resolve("{{data:iframe_duck_creek_policy_ca9940_year_747}}"));
            await _ui.PressAsync(_locators.CA9940Year, "Tab");
            await _ui.PressAsync(_locators.CA9940Year, "Tab");
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Make, _data.Resolve("{{data:iframe_duck_creek_policy_ca9940_make_748}}"));
            await _ui.PressAsync(_locators.CA9940Make, "Tab");
            await _ui.PressAsync(_locators.CA9940Make, "Tab");
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Model, _data.Resolve("{{data:iframe_duck_creek_policy_ca9940_model_749}}"));
            await _ui.PressAsync(_locators.CA9940Model, "Tab");
            await _ui.PressAsync(_locators.CA9940Model, "Tab");
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940VIN, _data.Resolve("{{data:iframe_duck_creek_policy_ca_9940_vin_750}}"));
            await _ui.PressAsync(_locators.CA9940VIN, "Tab");
            await _ui.PressAsync(_locators.CA9940VIN, "Tab");
        }
        if (_data.Condition("'Contract Provisions' != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940ContractProvisions, _data.Resolve("{{data:iframe_duck_creek_policy_ca9940_contract_provisions_751}}"));
            await _ui.PressAsync(_locators.CA9940ContractProvisions, "CLICK");
            await _ui.PressAsync(_locators.CA9940ContractProvisions, "Enter");
            await _ui.PressAsync(_locators.CA9940ContractProvisions, "Tab");
        }
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.WaitAsync(_locators.EndorsementType624AD, "Exists");
        await _ui.ClickAsync(_locators.EndorsementType624AD);
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_755}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_756}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Click");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Enter");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        // BAPEndorsements_bdb4d0Page.ConfirmAddition_0477_a6f47eAsync
        await _ui.ClickAsync(_locators.OK);
        // BAPEndorsements_bdb4d0Page.CheckIfIFRAMEIsOpen_0478_a6f47eAsync
        await _ui.VerifyAsync(_locators.IFRAMEF0A48, _data.Resolve("Exists"), "");
        // BAPEndorsements_bdb4d0Page.WaitForIFRAMEToClose_0479_a6f47eAsync
        await _ui.WaitAsync(_locators.IFRAMEF0A48, "Absent");
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0480_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsementSchedule_7d25f7Page.CheckIfOnEndorsements_0482_a6f47eAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeadingA3D50, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToEndorsements_0483_a6f47eAsync
        await _ui.ClickAsync(_locators.EndorsementsC27F0);
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0484_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
        // BAPEndorsements_bdb4d0Page.EnterRequiredEndorsementInfo_0485_a6f47eAsync
        await _ui.WaitAsync(_locators.ClickAddEndorsement, "Visible");
        await _ui.ClickAsync(_locators.ClickAddEndorsement);
        await _ui.WaitAsync(_locators.EndorsementDetail, "Exists");
        if (_data.Condition("Year != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Year, _data.Resolve(""));
        }
        if (_data.Condition("Make != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Make, _data.Resolve(""));
        }
        if (_data.Condition("Model != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940Model, _data.Resolve(""));
        }
        if (_data.Condition("VIN != NULL"))
        {
            await _ui.FillAsync(_locators.CA9940VIN, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.WaitAsync(_locators.EndorsementType624AD, "Exists");
        await _ui.ClickAsync(_locators.EndorsementType624AD);
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_774}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.FillAsync(_locators.EndorsementType624AD, _data.Resolve("{{data:endorsement_type_775}}"));
        await _ui.PressAsync(_locators.EndorsementType624AD, "Click");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Enter");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        await _ui.PressAsync(_locators.EndorsementType624AD, "Tab");
        // BAPEndorsements_bdb4d0Page.ConfirmAddition_0486_a6f47eAsync
        await _ui.ClickAsync(_locators.OK);
        // BAPEndorsements_bdb4d0Page.CheckIfIFRAMEIsOpen_0487_a6f47eAsync
        await _ui.VerifyAsync(_locators.IFRAMEF0A48, _data.Resolve("Exists"), "");
        // BAPEndorsements_bdb4d0Page.WaitForIFRAMEToClose_0488_a6f47eAsync
        await _ui.WaitAsync(_locators.IFRAMEF0A48, "Absent");
        // BAPEndorsementSchedule_7d25f7Page.WaitForSynchronization_0489_a6f47eAsync
        await _ui.WaitAsync(_locators.EndorsementsHeadingA3D50, "Exists");
    }

    // Business step: I add Addl Interest
    public async Task AddAddlInterestAsync()
    {
        // AdditionalInterestsSchedule_145f1fPage.CheckIfOnAddlInterests_0490_a6f47eAsync
        await _ui.VerifyAsync(_locators.AddlInterests15174, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToAddlInterests_0491_a6f47eAsync
        await _ui.ClickAsync(_locators.AdditionalInterests);
        // AdditionalInterestsSchedule_145f1fPage.WaitForSynchronization_0492_a6f47eAsync
        await _ui.WaitAsync(_locators.AddlInterests15174, "Exists");
        await _ui.ClickAsync(_locators.AddOtherInterest);
        await _ui.WaitAsync(_locators.TypeOfInterest, "Exists");
        await _ui.FillAsync(_locators.TypeOfInterest, _data.Resolve("{{data:iframe_duck_creek_policy_type_of_interest_785}}"));
        await _ui.PressAsync(_locators.TypeOfInterest, "CLICK");
        await _ui.PressAsync(_locators.TypeOfInterest, "Enter");
        await _ui.PressAsync(_locators.TypeOfInterest, "Tab");
        // AdditionalInterests_0c8d43Page.EnterRequiredInfo_0493_a6f47eAsync
        await _ui.WaitAsync(_locators.FirstName813D1, "Exists");
        if (_data.Condition("'First Name' != NULL"))
        {
            await _ui.PressAsync(_locators.FirstName813D1, "PRE:TAB");
            await _ui.PressAsync(_locators.FirstName813D1, "Tab");
            await _ui.PressAsync(_locators.FirstName813D1, "Tab");
        }
        if (_data.Condition("'First Name' != NULL"))
        {
            await _ui.FillAsync(_locators.FirstName813D1, _data.Resolve("{{data:iframe_duck_creek_policy_first_name_788}}"));
            await _ui.PressAsync(_locators.FirstName813D1, "Tab");
            await _ui.PressAsync(_locators.FirstName813D1, "Tab");
        }
        if (_data.Condition("'Last Name' != NULL"))
        {
            await _ui.FillAsync(_locators.LastName34FF6, _data.Resolve("{{data:iframe_duck_creek_policy_last_name_789}}"));
            await _ui.PressAsync(_locators.LastName34FF6, "Tab");
            await _ui.PressAsync(_locators.LastName34FF6, "Tab");
            await _ui.PressAsync(_locators.LastName34FF6, "Tab");
        }
        if (_data.Condition("Address != NULL"))
        {
            await _ui.FillAsync(_locators.Address193FF8, _data.Resolve("{{data:iframe_duck_creek_policy_address_1_790}}"));
            await _ui.PressAsync(_locators.Address193FF8, "Tab");
            await _ui.PressAsync(_locators.Address193FF8, "Tab");
        }
        if (_data.Condition("ZIP != NULL"))
        {
            await _ui.FillAsync(_locators.ZipCodeB286B, _data.Resolve("{{data:iframe_duck_creek_policy_zip_code_791}}"));
            await _ui.PressAsync(_locators.ZipCodeB286B, "Tab");
            await _ui.PressAsync(_locators.ZipCodeB286B, "Tab");
        }
        await _ui.WaitAsync(_locators.State64A10, "Visible");
        await _ui.ClickAsync(_locators.OK);
        // AdditionalInterestsSchedule_145f1fPage.WaitForSynchronization_0494_a6f47eAsync
        await _ui.WaitAsync(_locators.AddlInterests15174, "Exists");
        await _ui.WaitAsync(_locators.IFRAME59D4B, "Absent");
        // AdditionalInterestsSchedule_145f1fPage.CheckIfOnAddlInterests_0495_a6f47eAsync
        await _ui.VerifyAsync(_locators.AddlInterests15174, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToAddlInterests_0496_a6f47eAsync
        await _ui.ClickAsync(_locators.AdditionalInterests);
        // AdditionalInterestsSchedule_145f1fPage.WaitForSynchronization_0497_a6f47eAsync
        await _ui.WaitAsync(_locators.AddlInterests15174, "Exists");
        await _ui.ClickAsync(_locators.AddOtherInterest);
        await _ui.WaitAsync(_locators.TypeOfInterest, "Exists");
        await _ui.FillAsync(_locators.TypeOfInterest, _data.Resolve("{{data:iframe_duck_creek_policy_type_of_interest_801}}"));
        await _ui.PressAsync(_locators.TypeOfInterest, "CLICK");
        await _ui.PressAsync(_locators.TypeOfInterest, "Enter");
        await _ui.PressAsync(_locators.TypeOfInterest, "Tab");
        // AdditionalInterests_0c8d43Page.EnterRequiredInfo_0498_a6f47eAsync
        await _ui.WaitAsync(_locators.FirstName813D1, "Exists");
        if (_data.Condition("'First Name' != NULL"))
        {
            await _ui.PressAsync(_locators.FirstName813D1, "PRE:TAB");
            await _ui.PressAsync(_locators.FirstName813D1, "Tab");
            await _ui.PressAsync(_locators.FirstName813D1, "Tab");
        }
        if (_data.Condition("'First Name' != NULL"))
        {
            await _ui.FillAsync(_locators.FirstName813D1, _data.Resolve("{{data:iframe_duck_creek_policy_first_name_804}}"));
            await _ui.PressAsync(_locators.FirstName813D1, "Tab");
            await _ui.PressAsync(_locators.FirstName813D1, "Tab");
        }
        if (_data.Condition("'Last Name' != NULL"))
        {
            await _ui.FillAsync(_locators.LastName34FF6, _data.Resolve("{{data:iframe_duck_creek_policy_last_name_805}}"));
            await _ui.PressAsync(_locators.LastName34FF6, "Tab");
            await _ui.PressAsync(_locators.LastName34FF6, "Tab");
            await _ui.PressAsync(_locators.LastName34FF6, "Tab");
        }
        if (_data.Condition("Address != NULL"))
        {
            await _ui.FillAsync(_locators.Address193FF8, _data.Resolve("{{data:iframe_duck_creek_policy_address_1_806}}"));
            await _ui.PressAsync(_locators.Address193FF8, "Tab");
            await _ui.PressAsync(_locators.Address193FF8, "Tab");
        }
        if (_data.Condition("ZIP != NULL"))
        {
            await _ui.FillAsync(_locators.ZipCodeB286B, _data.Resolve("{{data:iframe_duck_creek_policy_zip_code_807}}"));
            await _ui.PressAsync(_locators.ZipCodeB286B, "Tab");
            await _ui.PressAsync(_locators.ZipCodeB286B, "Tab");
        }
        await _ui.WaitAsync(_locators.State64A10, "Visible");
        if (_data.Condition("'Vehicle Association' != NULL"))
        {
            await _ui.ClickAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation);
        }
        if (_data.Condition("'Vehicle Association' != NULL"))
        {
            await _ui.ClickAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation);
            await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, "DOUBLECLICK");
            await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, "DOWN");
            await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, "DOWN");
            await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, "Enter");
            await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, "Tab");
        }
        if (_data.Condition("'Vehicle Association' != NULL"))
        {
            await _ui.WaitAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, "NotEqual");
        }
        await _ui.ClickAsync(_locators.OK);
        // AdditionalInterestsSchedule_145f1fPage.WaitForSynchronization_0499_a6f47eAsync
        await _ui.WaitAsync(_locators.AddlInterests15174, "Exists");
        await _ui.WaitAsync(_locators.IFRAME59D4B, "Absent");
        // AdditionalInterestsSchedule_145f1fPage.CheckIfOnAddlInterests_0500_a6f47eAsync
        await _ui.VerifyAsync(_locators.AddlInterests15174, _data.Resolve("Absent"), "");
        // BAPNavigationLinks_e0270bPage.NavigateToAddlInterests_0501_a6f47eAsync
        await _ui.ClickAsync(_locators.AdditionalInterests);
        // AdditionalInterestsSchedule_145f1fPage.WaitForSynchronization_0502_a6f47eAsync
        await _ui.WaitAsync(_locators.AddlInterests15174, "Exists");
        await _ui.ClickAsync(_locators.AddOtherInterest);
        await _ui.WaitAsync(_locators.TypeOfInterest, "Exists");
        await _ui.FillAsync(_locators.TypeOfInterest, _data.Resolve("{{data:iframe_duck_creek_policy_type_of_interest_820}}"));
        await _ui.PressAsync(_locators.TypeOfInterest, "CLICK");
        await _ui.PressAsync(_locators.TypeOfInterest, "Enter");
        await _ui.PressAsync(_locators.TypeOfInterest, "Tab");
        // AdditionalInterests_0c8d43Page.EnterRequiredInfo_0503_a6f47eAsync
        await _ui.WaitAsync(_locators.FirstName813D1, "Exists");
        if (_data.Condition("'First Name' != NULL"))
        {
            await _ui.PressAsync(_locators.FirstName813D1, "PRE:TAB");
            await _ui.PressAsync(_locators.FirstName813D1, "Tab");
            await _ui.PressAsync(_locators.FirstName813D1, "Tab");
        }
        if (_data.Condition("'First Name' != NULL"))
        {
            await _ui.FillAsync(_locators.FirstName813D1, _data.Resolve("{{data:iframe_duck_creek_policy_first_name_823}}"));
            await _ui.PressAsync(_locators.FirstName813D1, "Tab");
            await _ui.PressAsync(_locators.FirstName813D1, "Tab");
        }
        if (_data.Condition("'Last Name' != NULL"))
        {
            await _ui.FillAsync(_locators.LastName34FF6, _data.Resolve("{{data:iframe_duck_creek_policy_last_name_824}}"));
            await _ui.PressAsync(_locators.LastName34FF6, "Tab");
            await _ui.PressAsync(_locators.LastName34FF6, "Tab");
            await _ui.PressAsync(_locators.LastName34FF6, "Tab");
        }
        if (_data.Condition("Address != NULL"))
        {
            await _ui.FillAsync(_locators.Address193FF8, _data.Resolve("{{data:iframe_duck_creek_policy_address_1_825}}"));
            await _ui.PressAsync(_locators.Address193FF8, "Tab");
            await _ui.PressAsync(_locators.Address193FF8, "Tab");
        }
        if (_data.Condition("ZIP != NULL"))
        {
            await _ui.FillAsync(_locators.ZipCodeB286B, _data.Resolve("{{data:iframe_duck_creek_policy_zip_code_826}}"));
            await _ui.PressAsync(_locators.ZipCodeB286B, "Tab");
            await _ui.PressAsync(_locators.ZipCodeB286B, "Tab");
        }
        await _ui.WaitAsync(_locators.State64A10, "Visible");
        if (_data.Condition("'Vehicle Association' != NULL"))
        {
            await _ui.ClickAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation);
        }
        if (_data.Condition("'Vehicle Association' != NULL"))
        {
            await _ui.ClickAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation);
            await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, "DOUBLECLICK");
            await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, "DOWN");
            await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, "DOWN");
            await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, "Enter");
            await _ui.PressAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, "Tab");
        }
        if (_data.Condition("'Vehicle Association' != NULL"))
        {
            await _ui.WaitAsync(_locators.IFRAMEDuckCreekPolicyVehicleAssociation, "NotEqual");
        }
        await _ui.ClickAsync(_locators.OK);
        // AdditionalInterestsSchedule_145f1fPage.WaitForSynchronization_0504_a6f47eAsync
        await _ui.WaitAsync(_locators.AddlInterests15174, "Exists");
        await _ui.WaitAsync(_locators.IFRAME59D4B, "Absent");
    }

    // Business step: I complete required underwriting question information
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync3()
    {
        // BAPNavigationLinks_e0270bPage.NavigateToUWQuestions_0505_a6f47eAsync
        await _ui.ClickAsync(_locators.UWQuestions368CC);
        // UnderwritingQuestions_49c7c2Page.WaitForSynchronization_0506_a6f47eAsync
        await _ui.WaitAsync(_locators.UWQuestionsF3D9F, "Exists");
        // UnderwritingQuestions_49c7c2Page.FillOutUnderwritingQuestions_0507_a6f47eAsync
        await _ui.ClickAsync(_locators.UpdateAnswersButton);
        await _ui.PressAsync(_locators.UpdateAnswersButton, "Tab");
        await _ui.PressAsync(_locators.UpdateAnswersButton, "Tab");
        await _ui.FillAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, _data.Resolve("{{data:are_there_any_commercial_vehicles_owned_by_the_applicant_not_insured_on_the_policy_837}}"));
        await _ui.PressAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, "Tab");
        await _ui.PressAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, "Tab");
        await _ui.PressAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, "Tab");
        await _ui.WaitAsync(_locators.AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy, "Equal");
        await _ui.FillAsync(_locators.AnyPersonalAutoPolicyListingNameInsured, _data.Resolve("{{data:anypersonalautopolicylistingnameinsured_839}}"));
        await _ui.PressAsync(_locators.AnyPersonalAutoPolicyListingNameInsured, "Tab");
        await _ui.PressAsync(_locators.AnyPersonalAutoPolicyListingNameInsured, "Tab");
        await _ui.PressAsync(_locators.AnyPersonalAutoPolicyListingNameInsured, "Tab");
        await _ui.FillAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, _data.Resolve("{{data:anyvehiclecoveredregisteredinnotprimarystate_840}}"));
        await _ui.PressAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, "Tab");
        await _ui.PressAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, "Tab");
        await _ui.PressAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, "Tab");
        await _ui.FillAsync(_locators.BorrowingHiringOrLeasingWithinYear, _data.Resolve("{{data:borrowinghiringorleasingwithinyear_841}}"));
        await _ui.PressAsync(_locators.BorrowingHiringOrLeasingWithinYear, "Tab");
        await _ui.PressAsync(_locators.BorrowingHiringOrLeasingWithinYear, "Tab");
        await _ui.PressAsync(_locators.BorrowingHiringOrLeasingWithinYear, "Tab");
        await _ui.PressAsync(_locators.BorrowingHiringOrLeasingWithinYear, "Tab");
        await _ui.PressAsync(_locators.BorrowingHiringOrLeasingWithinYear, "Tab");
        await _ui.WaitAsync(_locators.BorrowingHiringOrLeasingWithinYear, "Equal");
        await _ui.WaitAsync(_locators.AnyVehicleCoveredRegisteredInNotPrimaryState, "Equal");
        // UnderwritingQuestions_49c7c2Page.CheckForAnyFeloniesQuestion_0508_a6f47eAsync
        await _ui.VerifyAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, _data.Resolve("Exists"), "");
        // UnderwritingQuestions_49c7c2Page.FillOutAnyFeloniesQuestion_0509_a6f47eAsync
        await _ui.FillAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, _data.Resolve("{{data:has_any_applicant_been_convicted_of_a_felony_or_been_involved_in_any_incidents_or_claims_relating_to_sexual_abuse_or_molestation_allegations_discrimination_arson_fraud_bribery_or_negligent_hiring_845}}"));
        await _ui.PressAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, "Tab");
        await _ui.PressAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, "Tab");
        await _ui.PressAsync(_locators.HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring, "Tab");
    }

    // Business step: I complete required billing information
    public async Task CompleteRequiredBillingInformationAsync8()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0510_a6f47eAsync
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0511_a6f47eAsync
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_848}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_851}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_855}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0512_a6f47eAsync
        await Task.Delay(1000);
    }

    // Business step: I add notepad comment
    public async Task AddNotepadCommentAsync7()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToNotePadScreen_0513_a6f47eAsync
        await _ui.ClickAsync(_locators.Notepad);
        // NotePad_055c33Page.AddNotesRemarksToNotePad_0514_a6f47eAsync
        await _ui.WaitAsync(_locators.NotepadHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNotesRemarks);
        await _ui.FillAsync(_locators.TextBox, _data.Resolve("Test {B[Product (LOB)]}"));
        await _ui.ClickAsync(_locators.NotePadOK);
    }

    // Business step: I complete required submission information
    public async Task CompleteRequiredSubmissionInformationAsync7()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0515_a6f47eAsync
        await _ui.WaitAsync(_locators.Submission, "Visible");
        await _ui.ClickAsync(_locators.Submission);
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutRequiredFields_0516_a6f47eAsync
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_866}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "CLICK");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.OrderAudit_0517_a6f47eAsync
        await _ui.VerifyAsync(_locators.OrderAudit, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutOrderAudit_0518_a6f47eAsync
        await _ui.FillAsync(_locators.OrderAudit, _data.Resolve("{{data:order_audit_868}}"));
        await _ui.PressAsync(_locators.OrderAudit, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeSubmissionScreenHeaderExists_0519_a6f47eAsync
        await _ui.VerifyAsync(_locators.SubmissionHeading, _data.Resolve("Absent"), "");
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0520_a6f47eAsync
        await _ui.PressAsync(_locators.Submission, "PRE:TAB");
        await _ui.PressAsync(_locators.Submission, "Tab");
        await _ui.ClickAsync(_locators.Submission);
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0521_a6f47eAsync
        await Task.Delay(1000);
        // SubmissionRequiredAndOptionalFields_4090a9Page.WaitOnSubmissionScreenToLoad_0522_a6f47eAsync
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        // TBoxWait_7ea9e1Page.N500msWaitForSyncing_0523_a6f47eAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required billing information
    public async Task CompleteRequiredBillingInformationAsync9()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0053_767d1bAsync
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0054_767d1bAsync
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_35}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_38}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_42}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0055_767d1bAsync
        await Task.Delay(1000);
    }

    // Business step: I navigate to Underwriting Info Screen
    public async Task NavigateToUnderwritingInfoScreenAsync2()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToUnderwritingInfoScreen_0066_767d1bAsync
        await _ui.ClickAsync(_locators.UnderwritingInfo);
        // UnderwritingInfoOtherInsuranceHistory_b78753Page.AddPriorCarriorDetailsOnLossInformationScreen_0067_767d1bAsync
        await _ui.WaitAsync(_locators.IsThereAPriorCarrier, "Exists");
        await _ui.FillAsync(_locators.IsThereAPriorCarrier, _data.Resolve("{{data:is_there_a_prior_carrier_83}}"));
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Tab");
        await _ui.ClickAsync(_locators.AddPriorCarrier);
        await _ui.WaitAsync(_locators.Carrier, "Exists");
        await _ui.FillAsync(_locators.Carrier, _data.Resolve("{{data:carrier_86}}"));
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.FillAsync(_locators.PolicyNumberBA28E, _data.Resolve("{{data:policy_number_87}}"));
        await _ui.PressAsync(_locators.PolicyNumberBA28E, "Tab");
        await _ui.FillAsync(_locators.PolicyType, _data.Resolve("{{data:policy_type_88}}"));
        await _ui.PressAsync(_locators.PolicyType, "Tab");
        await _ui.FillAsync(_locators.EffectiveDateB557F, _data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDateB557F, "Tab");
        await _ui.FillAsync(_locators.ExpirationDate34EAC, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate34EAC, "Tab");
        await _ui.FillAsync(_locators.ModificationFactor, _data.Resolve("{{data:modificationfactor_91}}"));
        await _ui.PressAsync(_locators.ModificationFactor, "Tab");
        await _ui.FillAsync(_locators.TotalPremium, _data.Resolve("{{data:total_premium_92}}"));
        await _ui.PressAsync(_locators.TotalPremium, "Tab");
        await _ui.ClickAsync(_locators.OtherInsuranceHistoryOK);
        await _ui.WaitAsync(_locators.Detail0F8C6, "Exists");
        // UnderwritingInfoLossExperience_54b758Page.IndicateNoKnownLossesOnLossExperienceScreen_0068_767d1bAsync
        await _ui.ClickAsync(_locators.LossExperience);
        await _ui.WaitAsync(_locators.NoKnownLosses, "Exists");
        await _ui.SmartSetAsync(_locators.NoKnownLosses, _data.Resolve("{{data:no_known_losses_97}}"));
        await _ui.PressAsync(_locators.NoKnownLosses, "Tab");
        // CommonNavigationLinks_dba56bPage.ClickReturnToQuote_0069_767d1bAsync
        await _ui.ClickAsync(_locators.ReturnToQuote);
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0070_767d1bAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_99}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_100}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_101}}"), "value");
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync12()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0071_767d1bAsync
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0072_767d1bAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0073_767d1bAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0074_767d1bAsync
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_105}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_106}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0075_767d1bAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0076_767d1bAsync
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_108}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_112}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0077_767d1bAsync
        _data.Set("StateIsKansas", _data.Resolve("Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0078_767d1bAsync
        if (_data.Condition("'Product (LOB)' == \"UMB\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_114}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_115}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0079_767d1bAsync
        _data.Set("StateIsVirginia", _data.Resolve("Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0080_767d1bAsync
        if (_data.Condition("'Product (LOB)' == \"UMB\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_117}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"UMB\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_118}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0081_767d1bAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0082_767d1bAsync
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_122}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0083_767d1bAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0084_767d1bAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AL UMB Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I complete required policy covg information
    public async Task CompleteRequiredPolicyCovgInformationAsync2()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToPolicyCovgScreen_0087_767d1bAsync
        await _ui.ClickAsync(_locators.PolicyCovg35BE4);
        // PolicyCovg_0dff37Page.CompleteRequiredFieldsVerificationSteps_0088_767d1bAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        if (_data.Condition("'Umb Limit' == \"$1,000,000\""))
        {
            await _ui.VerifyAsync(_locators.UmbrellaLimit, _data.Resolve("{{data:expected_umbrella_limit_value_134}}"), "Value");
        }
        if (_data.Condition("'Excluded Liability' == \"CU2186\""))
        {
            await _ui.VerifyAsync(_locators.ExcludedLiabilityConfidentialInformation, _data.Resolve("{{data:expected_excluded_liability_confidential_information_value_135}}"), "value");
        }
        if (_data.Condition("'Products - Aggregate Limit' == \"Umbrella Policy Limit\""))
        {
            await _ui.VerifyAsync(_locators.ProductsCompletedOperationsAggregateLimit, _data.Resolve("{{data:expected_products_completed_operations_aggregate_limit_value_136}}"), "value");
        }
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0089_767d1bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0090_767d1bAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required location information
    public async Task CompleteRequiredLocationInformationAsync4()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToLocationScreen_0103_767d1bAsync
        await _ui.ClickAsync(_locators.LocationE16BC);
        // Location_d219c6Page.ClickOKAndWaitForDetailButton_0104_767d1bAsync
        await _ui.WaitAsync(_locators.Location82D95, "Visible");
        await _ui.VerifyAsync(_locators.ZipCodeD2DBA, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        await _ui.ClickAsync(_locators.LocationOK);
        await _ui.WaitAsync(_locators.Detail33F0D, "Visible");
    }

    // Business step: I complete required commercial auto information
    public async Task CompleteRequiredCommercialAutoInformationAsync2()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToCommercialAutoScreen_0105_767d1bAsync
        await _ui.ClickAsync(_locators.CommercialAuto);
        // CommercialAuto_c0e96dPage.FillOutCommercialAutoFields_0106_767d1bAsync
        await _ui.WaitAsync(_locators.CommercialAutoDetail, "Visible");
        await _ui.FillAsync(_locators.PolicyNumber461C7, _data.Resolve("{{data:policy_number_163}}"));
        await _ui.PressAsync(_locators.PolicyNumber461C7, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber461C7, "Tab");
        if (_data.Condition("'BAP Policy Number' != \"BAPPOL#\""))
        {
            await _ui.ClickAsync(_locators.ImportPolicyDataButton89922);
        }
        await _ui.WaitAsync(_locators.EffectiveDate68A1B, "NotEqual");
        await _ui.WaitAsync(_locators.StoplightMessageTotalSubjectPremium, "Absent");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0108_767d1bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0109_767d1bAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required general liability information
    public async Task CompleteRequiredGeneralLiabilityInformationAsync2()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToGeneralLiabScreen_0110_767d1bAsync
        await _ui.WaitAsync(_locators.GeneralLiab, "Visible");
        await _ui.PressAsync(_locators.GeneralLiab, "PRE:TAB");
        await _ui.PressAsync(_locators.GeneralLiab, "Tab");
        await _ui.ClickAsync(_locators.GeneralLiab);
        // GeneralLiability_9f087aPage.FillOutGeneralLiabilityFields_0111_767d1bAsync
        await _ui.WaitAsync(_locators.GeneralLiability, "Visible");
        await _ui.FillAsync(_locators.PolicyNumberFDF5C, _data.Resolve("{{data:policy_number_173}}"));
        await _ui.PressAsync(_locators.PolicyNumberFDF5C, "Tab");
        await _ui.PressAsync(_locators.PolicyNumberFDF5C, "Tab");
        if (_data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
            await _ui.FillAsync(_locators.EffectiveDateB3600, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
            await _ui.PressAsync(_locators.EffectiveDateB3600, "Tab");
        }
        await _ui.WaitAsync(_locators.EffectiveDateB3600, "NotEqual");
        if (_data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
            await _ui.FillAsync(_locators.ExpirationDateB437C, _data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            await _ui.PressAsync(_locators.ExpirationDateB437C, "Tab");
        }
        if (_data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
            await _ui.FillAsync(_locators.CGLLimits, _data.Resolve("{{data:cgl_limits_177}}"));
            await _ui.PressAsync(_locators.CGLLimits, "CLICK");
            await _ui.PressAsync(_locators.CGLLimits, "Enter");
            await _ui.PressAsync(_locators.CGLLimits, "Tab");
        }
        if (_data.Condition("'GL Policy Number' == \"GLPOL#\""))
        {
            await _ui.FillAsync(_locators.TotalSubjectPremium19B44, _data.Resolve("{{data:total_subject_premium_178}}"));
            await _ui.PressAsync(_locators.TotalSubjectPremium19B44, "Tab");
        }
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0113_767d1bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0114_767d1bAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required employers liability information
    public async Task CompleteRequiredEmployersLiabilityInformationAsync2()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToEmployersLiabilityScreen_0123_767d1bAsync
        await _ui.WaitAsync(_locators.EmployersLiab, "Visible");
        await _ui.PressAsync(_locators.EmployersLiab, "PRE:TAB");
        await _ui.PressAsync(_locators.EmployersLiab, "Tab");
        await _ui.ClickAsync(_locators.EmployersLiab);
        // EmployersLiability_1f4f10Page.EmployersLiability_0124_767d1bAsync
        await _ui.FillAsync(_locators.PolicyNumber6566F, _data.Resolve("{{data:policy_number_192}}"));
        await _ui.PressAsync(_locators.PolicyNumber6566F, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber6566F, "Tab");
        if (_data.Condition("'WC Policy Number' != \"WCPOL#\""))
        {
            await _ui.ClickAsync(_locators.ImportPolicyDataButtonEF44C);
        }
        await _ui.WaitAsync(_locators.EffectiveDate6CF3D, "NotEqual");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0125_767d1bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0126_767d1bAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required cpp information
    public async Task CompleteRequiredCppInformationAsync2()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToCPPLiabilityScreen_0127_767d1bAsync
        await _ui.WaitAsync(_locators.CPPLiability, "Visible");
        await _ui.PressAsync(_locators.CPPLiability, "PRE:TAB");
        await _ui.PressAsync(_locators.CPPLiability, "Tab");
        await _ui.ClickAsync(_locators.CPPLiability);
        // CommercialPackagePolicy_827cc1Page.FillOutCPPLiabilityFields_0128_767d1bAsync
        await _ui.FillAsync(_locators.PolicyNumber6566F, _data.Resolve("{{data:policy_number_200}}"));
        await _ui.PressAsync(_locators.PolicyNumber6566F, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber6566F, "Tab");
        if (_data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
            await _ui.FillAsync(_locators.EffectiveDate6CF3D, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
            await _ui.PressAsync(_locators.EffectiveDate6CF3D, "Tab");
        }
        await _ui.WaitAsync(_locators.EffectiveDate6CF3D, "NotEqual");
        if (_data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
            await _ui.FillAsync(_locators.ExpirationDate82561, _data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
            await _ui.PressAsync(_locators.ExpirationDate82561, "Tab");
        }
        if (_data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
            await _ui.FillAsync(_locators.LiabilityLimit1AE2B, _data.Resolve("{{data:liability_limit_204}}"));
            await _ui.PressAsync(_locators.LiabilityLimit1AE2B, "CLICK");
            await _ui.PressAsync(_locators.LiabilityLimit1AE2B, "Enter");
            await _ui.PressAsync(_locators.LiabilityLimit1AE2B, "Tab");
        }
        if (_data.Condition("'CPP Policy Number' ==\"CPPPOL#\""))
        {
            await _ui.FillAsync(_locators.TotalSubjectPremiumE8AF0, _data.Resolve("{{data:total_subject_premium_205}}"));
            await _ui.PressAsync(_locators.TotalSubjectPremiumE8AF0, "Tab");
        }
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0129_767d1bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0130_767d1bAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required sfp 10 information
    public async Task CompleteRequiredSfp10InformationAsync2()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToSFP10LiabilityFarmScreen_0131_767d1bAsync
        await _ui.ClickAsync(_locators.SFP10LiabilityFarm);
        // SFP10LiabilityFarm_203e45Page.FillOutSFP10LiabilityFarmFields_0132_767d1bAsync
        await _ui.WaitAsync(_locators.SFP10LiabilityFarmHeading, "Visible");
        await _ui.FillAsync(_locators.PolicyNumber78B85, _data.Resolve("{{data:policy_number_210}}"));
        await _ui.PressAsync(_locators.PolicyNumber78B85, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber78B85, "Tab");
        await _ui.FillAsync(_locators.EffectiveDate0E335, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDate0E335, "Tab");
        await _ui.WaitAsync(_locators.EffectiveDate0E335, "NotEqual");
        await _ui.FillAsync(_locators.ExpirationDate664A1, _data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate664A1, "Tab");
        await _ui.FillAsync(_locators.LiabilityLimit56E57, _data.Resolve("{{data:liability_limit_214}}"));
        await _ui.PressAsync(_locators.LiabilityLimit56E57, "CLICK");
        await _ui.PressAsync(_locators.LiabilityLimit56E57, "Enter");
        await _ui.PressAsync(_locators.LiabilityLimit56E57, "Tab");
        await _ui.FillAsync(_locators.TotalSubjectPremiumAF452, _data.Resolve("{{data:total_subject_premium_215}}"));
        await _ui.PressAsync(_locators.TotalSubjectPremiumAF452, "Tab");
    }

    // Business step: I complete required endorsement information
    public async Task CompleteRequiredEndorsementInformationAsync3()
    {
        // EndorsementsMainScreen_540f1cPage.CheckEndorsementsHeadingAndFillOutRequiredFields_0136_767d1bAsync
        await _ui.VerifyAsync(_locators.EndorsementsHeading8FD33, _data.Resolve("Absent"), "");
        // UMBNavigationLinks_77d89fPage.NavigateToEndorsementsScreen_0137_767d1bAsync
        await _ui.WaitAsync(_locators.Endorsements9D4A5, "Visible");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "PRE:TAB");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "Tab");
        await _ui.PressAsync(_locators.Endorsements9D4A5, "END");
        await _ui.ClickAsync(_locators.Endorsements9D4A5);
        // EndorsementsMainScreen_540f1cPage.WaitOnEndorsementsHeadingAndFillOutRequiredFields_0138_767d1bAsync
        await _ui.WaitAsync(_locators.EndorsementsHeading8FD33, "Exists");
    }

    // Business step: I complete required underwriting question information
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync4()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToUWQuestionsUmbrella_0183_767d1bAsync
        await _ui.ClickAsync(_locators.UWQuestionsUmbrella9F47E);
        await _ui.PressAsync(_locators.UWQuestionsUmbrella9F47E, "LongClick");
        // UWQuestionsUmbrella_783ea2Page.WaitOnUWQuestionsHeadingAndFillOutRequiredFields_0184_767d1bAsync
        await _ui.WaitAsync(_locators.UWQuestionsUmbrellaFF014, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswersB41BE);
        await _ui.WaitAsync(_locators.HaveYouHadAnyLiabilityLossesInTheLast5YearsOnAnyPrimaryOrExcessPolicy, "Equal");
        await _ui.FillAsync(_locators.PleaseProvideWebsiteAddressEs, _data.Resolve("{{data:please_provide_website_address_es_225}}"));
    }

    // Business step: I navigate to Pricing Screen
    public async Task NavigateToPricingScreenAsync()
    {
        // UMBNavigationLinks_77d89fPage.NavigateToPricingScreen_0185_767d1bAsync
        await _ui.ClickAsync(_locators.PricingB84E6);
        // Pricing_a0d9bbPage.WaitonPricingHeadingAndFillOutRequiredFields_0186_767d1bAsync
        await _ui.VerifyAsync(_locators.WaitonPricingHeadingAndFillOutRequiredFields, _data.Resolve("Exists"), "");
        // Pricing_a0d9bbPage.VerifyPremiumAmount_0187_767d1bAsync
        await _ui.VerifyAsync(_locators.Premium, _data.Resolve("{{data:expected_premium_value_228}}"), "value");
    }

    // Business step: I complete required billing information for billing
    public async Task CompleteRequiredBillingInformationForBillingAsync4()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0188_767d1bAsync
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0189_767d1bAsync
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_231}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_234}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_238}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0190_767d1bAsync
        await Task.Delay(1000);
    }

    // Business step: I add notepad comment
    public async Task AddNotepadCommentAsync8()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToNotePadScreen_0191_767d1bAsync
        await _ui.ClickAsync(_locators.Notepad);
        // NotePad_055c33Page.AddNotesRemarksToNotePad_0192_767d1bAsync
        await _ui.WaitAsync(_locators.NotepadHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNotesRemarks);
        await _ui.FillAsync(_locators.TextBox, _data.Resolve("Test {B[Product (LOB)]}"));
        await _ui.ClickAsync(_locators.NotePadOK);
    }

    // Business step: I complete required submission information
    public async Task CompleteRequiredSubmissionInformationAsync8()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0193_767d1bAsync
        await _ui.WaitAsync(_locators.Submission, "Visible");
        await _ui.ClickAsync(_locators.Submission);
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutRequiredFields_0194_767d1bAsync
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_249}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "CLICK");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.OrderAudit_0195_767d1bAsync
        await _ui.VerifyAsync(_locators.OrderAudit, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutOrderAudit_0196_767d1bAsync
        await _ui.FillAsync(_locators.OrderAudit, _data.Resolve("{{data:order_audit_251}}"));
        await _ui.PressAsync(_locators.OrderAudit, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeSubmissionScreenHeaderExists_0197_767d1bAsync
        await _ui.VerifyAsync(_locators.SubmissionHeading, _data.Resolve("Absent"), "");
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0198_767d1bAsync
        await _ui.PressAsync(_locators.Submission, "PRE:TAB");
        await _ui.PressAsync(_locators.Submission, "Tab");
        await _ui.ClickAsync(_locators.Submission);
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0199_767d1bAsync
        await Task.Delay(1000);
        // SubmissionRequiredAndOptionalFields_4090a9Page.WaitOnSubmissionScreenToLoad_0200_767d1bAsync
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        // TBoxWait_7ea9e1Page.N500msWaitForSyncing_0201_767d1bAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required billing information
    public async Task CompleteRequiredBillingInformationAsync10()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0053_bb930cAsync
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0054_bb930cAsync
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_37}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_40}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_44}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0055_bb930cAsync
        await Task.Delay(1000);
    }

    // Business step: I navigate to Underwriting Info Screen
    public async Task NavigateToUnderwritingInfoScreenAsync3()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToUnderwritingInfoScreen_0066_bb930cAsync
        await _ui.ClickAsync(_locators.UnderwritingInfo);
        // UnderwritingInfoOtherInsuranceHistory_b78753Page.AddPriorCarriorDetailsOnLossInformationScreen_0067_bb930cAsync
        await _ui.WaitAsync(_locators.IsThereAPriorCarrier, "Exists");
        await _ui.FillAsync(_locators.IsThereAPriorCarrier, _data.Resolve("{{data:is_there_a_prior_carrier_85}}"));
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Tab");
        await _ui.WaitAsync(_locators.Carrier, "Exists");
        await _ui.FillAsync(_locators.Carrier, _data.Resolve("{{data:carrier_87}}"));
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.FillAsync(_locators.PolicyNumberBA28E, _data.Resolve("{{data:policy_number_88}}"));
        await _ui.PressAsync(_locators.PolicyNumberBA28E, "Tab");
        await _ui.FillAsync(_locators.PolicyType, _data.Resolve("{{data:policy_type_89}}"));
        await _ui.PressAsync(_locators.PolicyType, "Tab");
        await _ui.FillAsync(_locators.EffectiveDateB557F, _data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDateB557F, "Tab");
        await _ui.FillAsync(_locators.ExpirationDate34EAC, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate34EAC, "Tab");
        await _ui.FillAsync(_locators.ModificationFactor, _data.Resolve("{{data:modificationfactor_92}}"));
        await _ui.PressAsync(_locators.ModificationFactor, "Tab");
        await _ui.FillAsync(_locators.TotalPremium, _data.Resolve("{{data:total_premium_93}}"));
        await _ui.PressAsync(_locators.TotalPremium, "Tab");
        await _ui.ClickAsync(_locators.OtherInsuranceHistoryOK);
        await _ui.WaitAsync(_locators.Detail0F8C6, "Exists");
        // UnderwritingInfoLossExperience_54b758Page.IndicateNoKnownLossesOnLossExperienceScreen_0068_bb930cAsync
        await _ui.ClickAsync(_locators.LossExperience);
        await _ui.WaitAsync(_locators.NoKnownLosses, "Exists");
        await _ui.SmartSetAsync(_locators.NoKnownLosses, _data.Resolve("{{data:no_known_losses_98}}"));
        await _ui.PressAsync(_locators.NoKnownLosses, "Tab");
        // CommonNavigationLinks_dba56bPage.ClickReturnToQuote_0069_bb930cAsync
        await _ui.ClickAsync(_locators.ReturnToQuote);
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0070_bb930cAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_100}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_101}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_102}}"), "value");
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync13()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0071_bb930cAsync
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0072_bb930cAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0073_bb930cAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0074_bb930cAsync
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_106}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0075_bb930cAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0076_bb930cAsync
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_108}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_109}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0077_bb930cAsync
        _data.Set("StateIsKansas", _data.Resolve("Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"));
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0079_bb930cAsync
        _data.Set("StateIsVirginia", _data.Resolve("Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"));
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0081_bb930cAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0082_bb930cAsync
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_113}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0083_bb930cAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0084_bb930cAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AL WC Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I complete coverage Information
    public async Task CompleteCoverageInformationAsync()
    {
        // WCNavigationLinks_672cc7Page.NavigateToPolicyCovgScreen_0089_bb930cAsync
        await _ui.ClickAsync(_locators.PolicyCovgD3CEF);
        // PolicyCovg_0dff37Page.PolicyCovg_0090_bb930cAsync
        await _ui.WaitAsync(_locators.PrimaryLocationState, "Exists");
        await _ui.VerifyAsync(_locators.PrimaryLocationState, _data.Resolve("(?i)^Alabama$"), "Regex:value");
        await _ui.FillAsync(_locators.ExperienceRated, _data.Resolve("{{data:experience_rated_128}}"));
        await _ui.PressAsync(_locators.ExperienceRated, "Tab");
        await _ui.PressAsync(_locators.ExperienceRated, "CLICK");
        await _ui.PressAsync(_locators.ExperienceRated, "Tab");
        _data.Set("ExpMod", await _ui.CaptureAsync(_locators.DefaultExperienceMod, "InnerText"));
    }

    // Business step: I complete Address 1
    public async Task CompleteAddress1Async()
    {
        // WCNavigationLinks_672cc7Page.NavigateToLocationScreen_0091_bb930cAsync
        await _ui.ClickAsync(_locators.Location8DEE2);
        // Location_d219c6Page.Location_0092_bb930cAsync
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.VerifyAsync(_locators.ZipCodeD2DBA, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        await _ui.ClickAsync(_locators.LocationOK);
    }

    // Business step: I complete rating Information
    public async Task CompleteRatingInformationAsync()
    {
        // WCNavigationLinks_672cc7Page.NavigateToStateDetailsScreen_0093_bb930cAsync
        await _ui.ClickAsync(_locators.StateDetailsB407B);
        // StateDetailsMain_44b0fcPage.StateDetailsMainQuestions_0094_bb930cAsync
        await _ui.WaitAsync(_locators.IntrastateRiskID, "Exists");
    }

    // Business step: I add Class Codes
    public async Task AddClassCodesAsync()
    {
        // WCNavigationLinks_672cc7Page.NavigateToWCSchedule_0095_bb930cAsync
        await _ui.ClickAsync(_locators.WCSchedule);
        // WCScheduleMainPage_7a7413Page.AddFirstClassCode_0096_bb930cAsync
        await _ui.WaitAsync(_locators.AddClassCode, "Exists");
        await _ui.ClickAsync(_locators.AddClassCode);
        // WCScheduleMainPage_7a7413Page.LoopWhileOKButtonDoesNotExist_0097_bb930cAsync
        await _ui.VerifyAsync(_locators.OKClassCode, _data.Resolve("Absent"), "");
        // WCScheduleMainPage_7a7413Page.LoopForFirstClassCode_0098_bb930cAsync
        await _ui.WaitAsync(_locators.SearchValue53135, "Exists");
        await _ui.FillAsync(_locators.SearchValue53135, _data.Resolve("{{data:class_code_frame_class_code_window_searchvalue_141}}"));
        await _ui.PressAsync(_locators.SearchValue53135, "Tab");
        await _ui.PressAsync(_locators.SearchValue53135, "PRE:TAB");
        await _ui.PressAsync(_locators.SearchValue53135, "Tab");
        await _ui.FillAsync(_locators.SelectClassCode, _data.Resolve("{{data:class_code_frame_class_code_window_select_class_code_143}}"));
        await _ui.PressAsync(_locators.SelectClassCode, "Enter");
        await _ui.PressAsync(_locators.SelectClassCode, "Tab");
        await _ui.PressAsync(_locators.SelectClassCode, "CLICK");
        await _ui.PressAsync(_locators.SelectClassCode, "Tab");
        await _ui.PressAsync(_locators.SelectClassCode, "Tab");
        await _ui.PressAsync(_locators.SelectClassCode, "PRE:TAB");
        await _ui.PressAsync(_locators.SelectClassCode, "Tab");
        // TBoxWait_7ea9e1Page.TBoxWait_0099_bb930cAsync
        await Task.Delay(1000);
        // WCScheduleMainPage_7a7413Page.InputFirstClassCodeDetails_0100_bb930cAsync
        await _ui.VerifyAsync(_locators.SelectClassCode, _data.Resolve("{{data:expected_class_code_frame_class_code_window_select_class_code_value_146}}"), "value");
        await _ui.WaitAsync(_locators.OKClassCode, "Exists");
        await _ui.ClickAsync(_locators.OKClassCode);
        await _ui.PressAsync(_locators.TotalPayrollEstimated, "PRE:TAB");
        await _ui.PressAsync(_locators.TotalPayrollEstimated, "Tab");
        if (_data.Condition("State != \"MD\""))
        {
            await _ui.FillAsync(_locators.TotalPayrollEstimated, _data.Resolve("{{data:class_code_frame_class_code_window_total_payroll_estimated_150}}"));
            await _ui.PressAsync(_locators.TotalPayrollEstimated, "Tab");
            await _ui.PressAsync(_locators.TotalPayrollEstimated, "CLICK");
            await _ui.PressAsync(_locators.TotalPayrollEstimated, "Tab");
        }
        await _ui.FillAsync(_locators.NumberOfPartTimeEmployees, _data.Resolve("{{data:class_code_frame_class_code_window_number_of_part_time_employees_151}}"));
        await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Tab");
        await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "CLICK");
        await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Tab");
        await _ui.FillAsync(_locators.NumberOfFullTimeEmployees, _data.Resolve("{{data:class_code_frame_class_code_window_number_of_full_time_employees_152}}"));
        await _ui.PressAsync(_locators.NumberOfFullTimeEmployees, "Tab");
        await _ui.PressAsync(_locators.NumberOfFullTimeEmployees, "CLICK");
        await _ui.PressAsync(_locators.NumberOfFullTimeEmployees, "Tab");
        await _ui.ClickAsync(_locators.OKDetails);
        await _ui.WaitAsync(_locators.ClassCodeFrame, "Absent");
        // WCScheduleMainPage_7a7413Page.AddSecondClassCode_0101_bb930cAsync
        await _ui.WaitAsync(_locators.AddClassCode, "Exists");
        await _ui.ClickAsync(_locators.AddClassCode);
        // WCScheduleMainPage_7a7413Page.LoopWhileOKButtonDoesNotExist_0102_bb930cAsync
        await _ui.VerifyAsync(_locators.OKClassCode, _data.Resolve("Absent"), "");
        // WCScheduleMainPage_7a7413Page.LoopForSecondClassCode_0103_bb930cAsync
        await _ui.WaitAsync(_locators.SearchValue53135, "Exists");
        await _ui.FillAsync(_locators.SearchValue53135, _data.Resolve(""));
        await _ui.FillAsync(_locators.SearchValue53135, _data.Resolve("{{data:class_code_frame_class_code_window_searchvalue_160}}"));
        await _ui.PressAsync(_locators.SearchValue53135, "Tab");
        await _ui.FillAsync(_locators.SelectClassCode, _data.Resolve("{{data:class_code_frame_class_code_window_select_class_code_161}}"));
        await _ui.PressAsync(_locators.SelectClassCode, "Enter");
        await _ui.PressAsync(_locators.SelectClassCode, "Tab");
        await _ui.PressAsync(_locators.SelectClassCode, "CLICK");
        await _ui.PressAsync(_locators.SelectClassCode, "Tab");
        await _ui.PressAsync(_locators.SelectClassCode, "Tab");
        await _ui.PressAsync(_locators.SelectClassCode, "PRE:TAB");
        await _ui.PressAsync(_locators.SelectClassCode, "Tab");
        // TBoxWait_7ea9e1Page.TBoxWait_0104_bb930cAsync
        await Task.Delay(1000);
        // WCScheduleMainPage_7a7413Page.InputSecondClassCodeDetails_0105_bb930cAsync
        await _ui.VerifyAsync(_locators.SelectClassCode, _data.Resolve("{{data:expected_class_code_frame_class_code_window_select_class_code_value_164}}"), "value");
        await _ui.WaitAsync(_locators.OKClassCode, "Exists");
        await _ui.ClickAsync(_locators.OKClassCode);
        await _ui.PressAsync(_locators.TotalPayrollEstimated, "PRE:TAB");
        await _ui.PressAsync(_locators.TotalPayrollEstimated, "Tab");
        await _ui.FillAsync(_locators.TotalPayrollEstimated, _data.Resolve("{{data:class_code_frame_class_code_window_total_payroll_estimated_168}}"));
        await _ui.PressAsync(_locators.TotalPayrollEstimated, "CLICK");
        await _ui.PressAsync(_locators.TotalPayrollEstimated, "Tab");
        await _ui.FillAsync(_locators.NumberOfPartTimeEmployees, _data.Resolve("{{data:class_code_frame_class_code_window_number_of_part_time_employees_169}}"));
        await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Tab");
        await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "CLICK");
        await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Tab");
        await _ui.FillAsync(_locators.NumberOfFullTimeEmployees, _data.Resolve("{{data:class_code_frame_class_code_window_number_of_full_time_employees_170}}"));
        await _ui.PressAsync(_locators.NumberOfFullTimeEmployees, "Tab");
        await _ui.PressAsync(_locators.NumberOfFullTimeEmployees, "CLICK");
        await _ui.PressAsync(_locators.NumberOfFullTimeEmployees, "Tab");
        await _ui.ClickAsync(_locators.OKDetails);
        await _ui.WaitAsync(_locators.ClassCodeFrame, "Absent");
    }

    // Business step: I navigate to Entity Schedule
    public async Task NavigateToEntityScheduleAsync()
    {
        // WCNavigationLinks_672cc7Page.NavigateToEntitySchedule_0106_bb930cAsync
        await _ui.ClickAsync(_locators.EntityScheduleEA671);
        // EntityScheduleMain_f120d6Page.WaitForSync_0107_bb930cAsync
        await _ui.WaitAsync(_locators.EntityScheduleE6C9F, "Exists");
        // EntityScheduleFirstEntityInfo_409441Page.EnterFirstEntityInfo_0109_bb930cAsync
        await _ui.ClickAsync(_locators.Detail238D5);
        await _ui.WaitAsync(_locators.InsuredType, "Exists");
        // Random data EntityInfoFrameEntityInfoWindowFax_0109 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.EMail, _data.Resolve("{{data:entity_info_frame_entity_info_window_e_mail_178}}"));
        // Random data EntityInfoFrameEntityInfoWindowBureauNumber_0109 is generated in the StepDefinition before this PageMethod runs.
        // Random data EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault_0109 is generated in the StepDefinition before this PageMethod runs.
        await _ui.ClickAsync(_locators.OK);
        await _ui.WaitAsync(_locators.EntityInfoFrame, "Absent");
        // EntityScheduleLocationAssignment_077082Page.EnterLocationAssignmentUpToNAICS_0110_bb930cAsync
        await _ui.WaitAsync(_locators.AssignLocations, "Exists");
        await _ui.ClickAsync(_locators.AssignLocations);
        await _ui.WaitAsync(_locators.AssignLocation, "Exists");
        await _ui.ClickAsync(_locators.AssignLocation);
        await _ui.WaitAsync(_locators.LocationID, "Exists");
        await _ui.FillAsync(_locators.LocationID, _data.Resolve("{{data:location_assignment_entity_location_locationid_188}}"));
        await _ui.PressAsync(_locators.LocationID, "Tab");
        await _ui.PressAsync(_locators.LocationID, "Enter");
        await _ui.PressAsync(_locators.LocationID, "Tab");
        await _ui.PressAsync(_locators.LocationID, "Tab");
        await _ui.ClickAsync(_locators.LocationID);
        await _ui.FillAsync(_locators.LocationID, _data.Resolve("{{data:location_assignment_entity_location_locationid_190}}"));
        await _ui.PressAsync(_locators.LocationID, "Tab");
        await _ui.PressAsync(_locators.LocationID, "Enter");
        await _ui.PressAsync(_locators.LocationID, "Tab");
        await _ui.PressAsync(_locators.LocationID, "Tab");
        await _ui.VerifyAsync(_locators.LocationID, _data.Resolve("{{data:expected_location_assignment_entity_location_locationid_value_191}}"), "Value");
        await _ui.ClickAsync(_locators.SelectNAICSCode);
        await _ui.WaitAsync(_locators.NAICSCodeSearchValue, "Exists");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "PRE:TAB");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "Tab");
        await _ui.FillAsync(_locators.NAICSCodeSearchValue, _data.Resolve("{{data:location_assignment_entity_location_naicscodesearchvalue_195}}"));
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "CLICK");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "Tab");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "Tab");
        await _ui.ClickAsync(_locators.NAICSCodeSearchValue);
        await _ui.PressAsync(_locators.SelectAppropriateCode, "PRE:TAB");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.FillAsync(_locators.SelectAppropriateCode, _data.Resolve("{{data:location_assignment_entity_location_select_appropriate_code_198}}"));
        await _ui.PressAsync(_locators.SelectAppropriateCode, "CLICK");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Click");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        // EntityScheduleLocationAssignment_077082Page.NAICSIsSelect_0111_bb930cAsync
        await _ui.VerifyAsync(_locators.SelectAppropriateCode, _data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_199}}"), "value");
        await _ui.WaitAsync(_locators.LocationAssignment, "Absent");
        // EntityScheduleLocationAssignment_077082Page.EnterLocationAssignment_0112_bb930cAsync
        await _ui.FillAsync(_locators.SelectAppropriateCode, _data.Resolve("{{data:location_assignment_entity_location_select_appropriate_code_201}}"));
        await _ui.PressAsync(_locators.SelectAppropriateCode, "CLICK");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Click");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.VerifyAsync(_locators.SelectAppropriateCode, _data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_202}}"), "value");
        await _ui.WaitAsync(_locators.LocationAssignment, "Absent");
        // EntityScheduleLocationAssignment_077082Page.EnterLocationAssignmentAfterNAICS_0113_bb930cAsync
        await _ui.VerifyAsync(_locators.SelectAppropriateCode, _data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_204}}"), "value");
        await _ui.ClickAsync(_locators.OKFirst);
        await _ui.PressAsync(_locators.OKFirst, "Tab");
        await _ui.PressAsync(_locators.OKFirst, "Tab");
        await _ui.WaitAsync(_locators.OKSecond, "Absent");
        await _ui.ClickAsync(_locators.OK);
        await _ui.WaitAsync(_locators.LocationAssignment, "Absent");
    }

    // Business step: I complete endorsements
    public async Task CompleteEndorsementsAsync()
    {
        // WCNavigationLinks_672cc7Page.NavigateToEndorsementsScreen_0114_bb930cAsync
        await _ui.ClickAsync(_locators.EndorsementsB76E9);
        // EndorsementsWaitonAddEndorsementButton_20beaePage.EndorsementsWaitonAddEndorsementButton_0115_bb930cAsync
        await _ui.WaitAsync(_locators.AddEndorsementB6452, "Exists");
    }

    // Business step: I complete WC UW Questions
    public async Task CompleteWCUWQuestionsAsync()
    {
        // WCNavigationLinks_672cc7Page.NavigateToUWQuestionsWorkersCompScreen_0116_bb930cAsync
        await _ui.ClickAsync(_locators.UWQuestionsWorkersComp);
        // UWQuestionsWorkersComp_e0f441Page.FillOutRequiredFields_0117_bb930cAsync
        await _ui.WaitAsync(_locators.UpdateAnswers6FF76, "Exists");
        await _ui.PressAsync(_locators.UpdateAnswers6FF76, "PRE:TAB");
        await _ui.PressAsync(_locators.UpdateAnswers6FF76, "Tab");
        await _ui.ClickAsync(_locators.UpdateAnswers6FF76);
        await _ui.WaitAsync(_locators.ArePhysicalsRequiredAfterOffersOfEmploymentAreMade, "NotEqual");
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "PRE:TAB");
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "Tab");
        await _ui.FillAsync(_locators.ListAllPoliciesWithAmericanNational, _data.Resolve("{{data:list_all_policies_with_american_national_217}}"));
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "Tab");
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "CLICK");
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "CLICK");
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "Tab");
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "Tab");
    }

    // Business step: I navigate to Pricing Screen
    public async Task NavigateToPricingScreenAsync2()
    {
        // WCNavigationLinks_672cc7Page.NavigateToPricingScreen_0118_bb930cAsync
        await _ui.ClickAsync(_locators.PricingDCBD4);
        // Pricing_a0d9bbPage.WaitForPricingScreenToLoad_0119_bb930cAsync
        await _ui.WaitAsync(_locators.PricingDetail, "Exists");
        // Pricing_a0d9bbPage.GoToPricingDetailNecessaryForRefreshPremiumIssue_0120_bb930cAsync
        await _ui.ClickAsync(_locators.PricingDetail);
        await _ui.ClickAsync(_locators.PricingDetailOK);
        // Pricing_a0d9bbPage.WaitForPricingScreenToLoad_0121_bb930cAsync
        await _ui.WaitAsync(_locators.PricingDetail, "Exists");
    }

    // Business step: I complete required billing information for billing
    public async Task CompleteRequiredBillingInformationForBillingAsync5()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0124_bb930cAsync
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0125_bb930cAsync
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_227}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_230}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_234}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0126_bb930cAsync
        await Task.Delay(1000);
    }

    // Business step: I add notepad comment
    public async Task AddNotepadCommentAsync9()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToNotePadScreen_0127_bb930cAsync
        await _ui.ClickAsync(_locators.Notepad);
        // NotePad_055c33Page.AddNotesRemarksToNotePad_0128_bb930cAsync
        await _ui.WaitAsync(_locators.NotepadHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNotesRemarks);
        await _ui.FillAsync(_locators.TextBox, _data.Resolve("Test {B[Product (LOB)]}"));
        await _ui.ClickAsync(_locators.NotePadOK);
    }

    // Business step: I complete required submission information
    public async Task CompleteRequiredSubmissionInformationAsync9()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0129_bb930cAsync
        await _ui.WaitAsync(_locators.Submission, "Visible");
        await _ui.ClickAsync(_locators.Submission);
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutRequiredFields_0130_bb930cAsync
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_245}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "CLICK");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.OrderAudit_0131_bb930cAsync
        await _ui.VerifyAsync(_locators.OrderAudit, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutOrderAudit_0132_bb930cAsync
        await _ui.FillAsync(_locators.OrderAudit, _data.Resolve("{{data:order_audit_247}}"));
        await _ui.PressAsync(_locators.OrderAudit, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeSubmissionScreenHeaderExists_0133_bb930cAsync
        await _ui.VerifyAsync(_locators.SubmissionHeading, _data.Resolve("Absent"), "");
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0134_bb930cAsync
        await _ui.PressAsync(_locators.Submission, "PRE:TAB");
        await _ui.PressAsync(_locators.Submission, "Tab");
        await _ui.ClickAsync(_locators.Submission);
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0135_bb930cAsync
        await Task.Delay(1000);
        // SubmissionRequiredAndOptionalFields_4090a9Page.WaitOnSubmissionScreenToLoad_0136_bb930cAsync
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        // TBoxWait_7ea9e1Page.N500msWaitForSyncing_0137_bb930cAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required billing information
    public async Task CompleteRequiredBillingInformationAsync11()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0053_a8e5f5Async
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0054_a8e5f5Async
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_37}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_40}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_44}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0055_a8e5f5Async
        await Task.Delay(1000);
    }

    // Business step: I complete Underwring Questions from Client Screen
    public async Task CompleteUnderwringQuestionsFromClientScreenAsync()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToUWInfo_0066_a8e5f5Async
        await _ui.ClickAsync(_locators.UnderwritingInfo);
        // UnderwritingInfoGeneralUWQuestions_3222c4Page.UnderwritingInfoUpdateGeneralUWQuestions_0067_a8e5f5Async
        await _ui.WaitAsync(_locators.GeneralUWQuestions, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswers9CB86);
        // UnderwritingInfoOtherInsuranceHistory_b78753Page.UnderwritingInfoUpdateGeneralLiabilityHistory_0068_a8e5f5Async
        await _ui.ClickAsync(_locators.InsuranceHistory);
        await _ui.FillAsync(_locators.IsThereAPriorCarrier, _data.Resolve("{{data:is_there_a_prior_carrier_87}}"));
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Tab");
        // UnderwritingInfoLossExperience_54b758Page.UnderwritingInfoSelectLossExperience_0069_a8e5f5Async
        await _ui.ClickAsync(_locators.LossExperience);
        await _ui.WaitAsync(_locators.LossExperienceHeading, "Exists");
        await _ui.ClickAsync(_locators.NoKnownLosses);
        // CommonNavigationLinks_dba56bPage.NavigateBackToQuote_0070_a8e5f5Async
        await _ui.ClickAsync(_locators.ReturnToQuote);
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0071_a8e5f5Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_92}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_93}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_94}}"), "value");
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync14()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0072_a8e5f5Async
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0073_a8e5f5Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0074_a8e5f5Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0075_a8e5f5Async
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_98}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_99}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0076_a8e5f5Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0077_a8e5f5Async
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_101}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_105}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0078_a8e5f5Async
        _data.Set("StateIsKansas", _data.Resolve("Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'"));
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0080_a8e5f5Async
        _data.Set("StateIsVirginia", _data.Resolve("Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'"));
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0082_a8e5f5Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0083_a8e5f5Async
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_111}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0084_a8e5f5Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0085_a8e5f5Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AZ IM Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0088_a8e5f5Async
        await Task.Delay(1000);
    }

    // Business step: I add Bailees Customers Coverage
    public async Task AddBaileesCustomersCoverageAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToPolicyCovgScreen_0102_a8e5f5Async
        await _ui.ClickAsync(_locators.PolicyCovgED95C);
        // PolicyCovgMain_ddd7eePage.PolicyCovgMain_0103_a8e5f5Async
        await _ui.WaitAsync(_locators.PolicyCovgF9E58, "Exists");
        await _ui.FillAsync(_locators.CoverageFormToBeAdded, _data.Resolve("{{data:coverage_form_to_be_added_143}}"));
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Enter");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.ClickAsync(_locators.AddCoverageForm);
        // PolicyCovgBaileesCutomers_36b666Page.AddPolicyCovgBaileesCustomers_0104_a8e5f5Async
        await _ui.WaitAsync(_locators.CoverageFormDisplay6F446, "Exists");
        await _ui.PressAsync(_locators.Description43F2D, "PRE:TAB");
        await _ui.PressAsync(_locators.Description43F2D, "Tab");
        await _ui.FillAsync(_locators.Description43F2D, _data.Resolve("{{data:description_147}}"));
        await _ui.PressAsync(_locators.Description43F2D, "CLICK");
        await _ui.PressAsync(_locators.Description43F2D, "Enter");
        await _ui.PressAsync(_locators.Description43F2D, "Tab");
        await _ui.FillAsync(_locators.PropertyInTransit710FF, _data.Resolve("{{data:property_in_transit_148}}"));
        await _ui.PressAsync(_locators.PropertyInTransit710FF, "Tab");
        await _ui.PressAsync(_locators.PropertyInTransit710FF, "Tab");
        await _ui.ClickAsync(_locators.PropertyAwayFromYourPremisesSchedule);
        // PolicyCovgBaileesPropertyAwayFromYourPremises_15f47ePage.PolicyCovgBaileesPropertyAwayFromYourPremises_0105_a8e5f5Async
        await _ui.ClickAsync(_locators.AddPremises);
        await _ui.FillAsync(_locators.AddressStreetCityStateZip, _data.Resolve("{{data:address_street_city_state_zip_151}}"));
        await _ui.PressAsync(_locators.AddressStreetCityStateZip, "CLICK");
        await _ui.PressAsync(_locators.AddressStreetCityStateZip, "Tab");
        await _ui.FillAsync(_locators.Limit46632, _data.Resolve("{{data:limit_152}}"));
        await _ui.PressAsync(_locators.Limit46632, "Tab");
        await _ui.PressAsync(_locators.Limit46632, "Tab");
        await _ui.ClickAsync(_locators.PolicyCovgBaileesPropertyAwayFromYourPremisesOK);
        // PolicyCovgBaileesCutomers_36b666Page.PolicyCovgBaileesCutomersSelectOKToCompleteCoverage_0106_a8e5f5Async
        await _ui.WaitAsync(_locators.CoverageFormDisplay6F446, "Exists");
        await _ui.ClickAsync(_locators.PolicyCovgBaileesCutomersOK);
    }

    // Business step: I add Contractors Equipment
    public async Task AddContractorsEquipmentAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToPolicyCovgScreen_0107_a8e5f5Async
        await _ui.ClickAsync(_locators.PolicyCovgED95C);
        // PolicyCovgMain_ddd7eePage.PolicyCovgMain_0108_a8e5f5Async
        await _ui.WaitAsync(_locators.PolicyCovgF9E58, "Exists");
        await _ui.FillAsync(_locators.CoverageFormToBeAdded, _data.Resolve("{{data:coverage_form_to_be_added_158}}"));
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Enter");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.ClickAsync(_locators.AddCoverageForm);
        // PolicyCovgContractorsEquipment_9bad08Page.AddPolicyCovgContractorsEquipment_0109_a8e5f5Async
        await _ui.WaitAsync(_locators.CoverageFormDisplayD1A9B, "Exists");
        await _ui.PressAsync(_locators.Description03789, "PRE:TAB");
        await _ui.PressAsync(_locators.Description03789, "Tab");
        await _ui.FillAsync(_locators.Description03789, _data.Resolve("{{data:description_162}}"));
        await _ui.PressAsync(_locators.Description03789, "Tab");
        await _ui.PressAsync(_locators.Description03789, "CLICK");
        await _ui.PressAsync(_locators.Description03789, "Tab");
        await _ui.FillAsync(_locators.CoinsuranceC9726, _data.Resolve("{{data:coinsurance_163}}"));
        await _ui.PressAsync(_locators.CoinsuranceC9726, "Tab");
        await _ui.PressAsync(_locators.CoinsuranceC9726, "CLICK");
        await _ui.PressAsync(_locators.CoinsuranceC9726, "Tab");
        await _ui.FillAsync(_locators.DeductibleC227C, _data.Resolve("{{data:deductible_164}}"));
        await _ui.PressAsync(_locators.DeductibleC227C, "Tab");
        await _ui.PressAsync(_locators.DeductibleC227C, "CLICK");
        await _ui.PressAsync(_locators.DeductibleC227C, "Tab");
        await _ui.FillAsync(_locators.BoomDeductible, _data.Resolve("{{data:boom_deductible_165}}"));
        await _ui.PressAsync(_locators.BoomDeductible, "Tab");
        await _ui.PressAsync(_locators.BoomDeductible, "CLICK");
        await _ui.PressAsync(_locators.BoomDeductible, "Tab");
        await _ui.FillAsync(_locators.TypeOfContractor, _data.Resolve("{{data:type_of_contractor_166}}"));
        await _ui.PressAsync(_locators.TypeOfContractor, "Tab");
        await _ui.PressAsync(_locators.TypeOfContractor, "CLICK");
        await _ui.PressAsync(_locators.TypeOfContractor, "Tab");
        await _ui.FillAsync(_locators.ScheduledCoverage, _data.Resolve("{{data:scheduled_coverage_167}}"));
        await _ui.PressAsync(_locators.ScheduledCoverage, "Tab");
        await _ui.PressAsync(_locators.ScheduledCoverage, "CLICK");
        await _ui.PressAsync(_locators.ScheduledCoverage, "Tab");
        await _ui.FillAsync(_locators.RentedEquipmentExpense, _data.Resolve("{{data:rented_equipment_expense_168}}"));
        await _ui.PressAsync(_locators.RentedEquipmentExpense, "Tab");
        await _ui.PressAsync(_locators.RentedEquipmentExpense, "CLICK");
        await _ui.PressAsync(_locators.RentedEquipmentExpense, "Tab");
        await _ui.FillAsync(_locators.ToolsAndClothingBelongingToYourEmployees, _data.Resolve("{{data:tools_and_clothing_belonging_to_your_employees_169}}"));
        await _ui.PressAsync(_locators.ToolsAndClothingBelongingToYourEmployees, "Tab");
        await _ui.PressAsync(_locators.ToolsAndClothingBelongingToYourEmployees, "CLICK");
        await _ui.PressAsync(_locators.ToolsAndClothingBelongingToYourEmployees, "Tab");
        await _ui.FillAsync(_locators.MiscItemsBlanketCoverage, _data.Resolve("{{data:misc_items_blanket_coverage_170}}"));
        await _ui.PressAsync(_locators.MiscItemsBlanketCoverage, "Tab");
        await _ui.PressAsync(_locators.MiscItemsBlanketCoverage, "CLICK");
        await _ui.PressAsync(_locators.MiscItemsBlanketCoverage, "Tab");
        await _ui.FillAsync(_locators.RentalReimbursement, _data.Resolve("{{data:rental_reimbursement_171}}"));
        await _ui.PressAsync(_locators.RentalReimbursement, "Tab");
        await _ui.PressAsync(_locators.RentalReimbursement, "CLICK");
        await _ui.PressAsync(_locators.RentalReimbursement, "Tab");
        await _ui.FillAsync(_locators.HiredEquipment, _data.Resolve("{{data:hired_equipment_172}}"));
        await _ui.PressAsync(_locators.HiredEquipment, "Tab");
        await _ui.PressAsync(_locators.HiredEquipment, "CLICK");
        await _ui.PressAsync(_locators.HiredEquipment, "Tab");
        await _ui.ClickAsync(_locators.PolicyCovgContractorsEquipmentOK);
    }

    // Business step: I add Computer Systems
    public async Task AddComputerSystemsAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToPolicyCovgScreen_0110_a8e5f5Async
        await _ui.ClickAsync(_locators.PolicyCovgED95C);
        // PolicyCovgMain_ddd7eePage.PolicyCovgMain_0111_a8e5f5Async
        await _ui.WaitAsync(_locators.PolicyCovgF9E58, "Exists");
        await _ui.FillAsync(_locators.CoverageFormToBeAdded, _data.Resolve("{{data:coverage_form_to_be_added_176}}"));
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Enter");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.ClickAsync(_locators.AddCoverageForm);
        // PolicyCovgComputerSystems_963e4ePage.PolicyCovgComputerSystems_0112_a8e5f5Async
        await _ui.WaitAsync(_locators.CoverageFormDisplay2ECD4, "Exists");
        await _ui.PressAsync(_locators.Description58EC2, "PRE:TAB");
        await _ui.PressAsync(_locators.Description58EC2, "Tab");
        await _ui.FillAsync(_locators.Description58EC2, _data.Resolve("{{data:description_180}}"));
        await _ui.PressAsync(_locators.Description58EC2, "CLICK");
        await _ui.PressAsync(_locators.Description58EC2, "Enter");
        await _ui.PressAsync(_locators.Description58EC2, "Tab");
        await _ui.FillAsync(_locators.DeductibleC91E9, _data.Resolve("{{data:deductible_181}}"));
        await _ui.PressAsync(_locators.DeductibleC91E9, "Tab");
        await _ui.PressAsync(_locators.DeductibleC91E9, "Tab");
        await _ui.FillAsync(_locators.Coinsurance01AB1, _data.Resolve("{{data:coinsurance_182}}"));
        await _ui.PressAsync(_locators.Coinsurance01AB1, "Tab");
        await _ui.PressAsync(_locators.Coinsurance01AB1, "Tab");
        await _ui.FillAsync(_locators.PropertyInTransit6E905, _data.Resolve("{{data:property_in_transit_183}}"));
        await _ui.PressAsync(_locators.PropertyInTransit6E905, "Tab");
        await _ui.PressAsync(_locators.PropertyInTransit6E905, "Tab");
        await _ui.FillAsync(_locators.UnnamedPremises, _data.Resolve("{{data:unnamed_premises_184}}"));
        await _ui.PressAsync(_locators.UnnamedPremises, "Tab");
        await _ui.PressAsync(_locators.UnnamedPremises, "Tab");
        await _ui.FillAsync(_locators.PersonalPortableComputers, _data.Resolve("{{data:personal_portable_computers_185}}"));
        await _ui.PressAsync(_locators.PersonalPortableComputers, "Tab");
        await _ui.PressAsync(_locators.PersonalPortableComputers, "Tab");
        await _ui.FillAsync(_locators.ExtraExpense, _data.Resolve("{{data:extra_expense_186}}"));
        await _ui.PressAsync(_locators.ExtraExpense, "Tab");
        await _ui.PressAsync(_locators.ExtraExpense, "Tab");
        await _ui.FillAsync(_locators.VirusHarmfulCodeOrSimilarInstruction, _data.Resolve("{{data:virus_harmful_code_or_similar_instruction_187}}"));
        await _ui.PressAsync(_locators.VirusHarmfulCodeOrSimilarInstruction, "Tab");
        await _ui.PressAsync(_locators.VirusHarmfulCodeOrSimilarInstruction, "Tab");
        await _ui.ClickAsync(_locators.PolicyCovgComputerSystemsOK);
    }

    // Business step: I add Motor Truck Cargo
    public async Task AddMotorTruckCargoAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToPolicyCovgScreen_0113_a8e5f5Async
        await _ui.ClickAsync(_locators.PolicyCovgED95C);
        // PolicyCovgMain_ddd7eePage.PolicyCovgMain_0114_a8e5f5Async
        await _ui.WaitAsync(_locators.PolicyCovgF9E58, "Exists");
        await _ui.FillAsync(_locators.CoverageFormToBeAdded, _data.Resolve("{{data:coverage_form_to_be_added_191}}"));
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Enter");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.ClickAsync(_locators.AddCoverageForm);
        // PolicyCovgMotorTruckCargo_0d23c6Page.PolicyCovgMotorTruckCargo_0115_a8e5f5Async
        await _ui.WaitAsync(_locators.CoverageFormDisplayB69C2, "Exists");
        await _ui.PressAsync(_locators.DescriptionF8E60, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionF8E60, "Tab");
        await _ui.FillAsync(_locators.DescriptionF8E60, _data.Resolve("{{data:description_195}}"));
        await _ui.PressAsync(_locators.DescriptionF8E60, "Tab");
        await _ui.PressAsync(_locators.DescriptionF8E60, "CLICK");
        await _ui.PressAsync(_locators.DescriptionF8E60, "Enter");
        await _ui.PressAsync(_locators.DescriptionF8E60, "Tab");
        await _ui.FillAsync(_locators.CoverageType, _data.Resolve("{{data:coverage_type_196}}"));
        await _ui.PressAsync(_locators.CoverageType, "Tab");
        await _ui.PressAsync(_locators.CoverageType, "Tab");
        await _ui.PressAsync(_locators.CoverageType, "Tab");
        await _ui.FillAsync(_locators.CoveredPropertyConsistingPrincipallyOf, _data.Resolve("{{data:covered_property_consisting_principally_of_197}}"));
        await _ui.PressAsync(_locators.CoveredPropertyConsistingPrincipallyOf, "Tab");
        await _ui.PressAsync(_locators.CoveredPropertyConsistingPrincipallyOf, "Tab");
        await _ui.FillAsync(_locators.Deductible320C9, _data.Resolve("{{data:deductible_198}}"));
        await _ui.PressAsync(_locators.Deductible320C9, "Tab");
        await _ui.PressAsync(_locators.Deductible320C9, "Tab");
        await _ui.FillAsync(_locators.PerVehicleLimit, _data.Resolve("{{data:per_vehicle_limit_199}}"));
        await _ui.PressAsync(_locators.PerVehicleLimit, "Tab");
        await _ui.PressAsync(_locators.PerVehicleLimit, "Tab");
        await _ui.FillAsync(_locators.GroupClass, _data.Resolve("{{data:group_class_200}}"));
        await _ui.PressAsync(_locators.GroupClass, "Tab");
        await _ui.PressAsync(_locators.GroupClass, "Tab");
        await _ui.FillAsync(_locators.NumberOfVehicles, _data.Resolve("{{data:number_of_vehicles_201}}"));
        await _ui.PressAsync(_locators.NumberOfVehicles, "Tab");
        await _ui.PressAsync(_locators.NumberOfVehicles, "Tab");
        await _ui.FillAsync(_locators.UnnamedTerminalsLimit, _data.Resolve("{{data:unnamed_terminals_limit_202}}"));
        await _ui.PressAsync(_locators.UnnamedTerminalsLimit, "Tab");
        await _ui.PressAsync(_locators.UnnamedTerminalsLimit, "Tab");
        await _ui.ClickAsync(_locators.PolicyCovgMotorTruckCargoOK);
    }

    // Business step: I add Signs
    public async Task AddSignsAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToPolicyCovgScreen_0116_a8e5f5Async
        await _ui.ClickAsync(_locators.PolicyCovgED95C);
        // PolicyCovgMain_ddd7eePage.PolicyCovgMain_0117_a8e5f5Async
        await _ui.WaitAsync(_locators.PolicyCovgF9E58, "Exists");
        await _ui.FillAsync(_locators.CoverageFormToBeAdded, _data.Resolve("{{data:coverage_form_to_be_added_206}}"));
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Enter");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.ClickAsync(_locators.AddCoverageForm);
        // PolicyCovgSigns_aa9a0ePage.PolicyCovgSigns_0118_a8e5f5Async
        await _ui.WaitAsync(_locators.CoverageFormDisplayC10BA, "Exists");
        await _ui.PressAsync(_locators.DescriptionBE47E, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionBE47E, "Tab");
        await _ui.FillAsync(_locators.DescriptionBE47E, _data.Resolve("{{data:description_210}}"));
        await _ui.PressAsync(_locators.DescriptionBE47E, "Tab");
        await _ui.PressAsync(_locators.DescriptionBE47E, "CLICK");
        await _ui.PressAsync(_locators.DescriptionBE47E, "Enter");
        await _ui.PressAsync(_locators.DescriptionBE47E, "Tab");
        await _ui.VerifyAsync(_locators.CoverageFormA7F96, _data.Resolve("Exists"), "");
        await _ui.FillAsync(_locators.N5Deductible, _data.Resolve("{{data:5_deductible_212}}"));
        await _ui.PressAsync(_locators.N5Deductible, "Tab");
        await _ui.PressAsync(_locators.N5Deductible, "Tab");
        await _ui.ClickAsync(_locators.PolicyCovgSignsOK);
        // TBoxWait_7ea9e1Page.WaitForPriorScreenToUpdate_0119_a8e5f5Async
        await Task.Delay(1000);
    }

    // Business step: I add Accounts Receivable
    public async Task AddAccountsReceivableAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToRiskScreen_0120_a8e5f5Async
        await _ui.ClickAsync(_locators.Risk5D6FA);
        // RiskMain_2f5e40Page.RiskMain_0121_a8e5f5Async
        await _ui.WaitAsync(_locators.Risk873E7, "Exists");
        await _ui.FillAsync(_locators.CoverageFormCFDD1, _data.Resolve("{{data:coverage_form_217}}"));
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.ClickAsync(_locators.Add);
        // RiskAccountsReceivable_1ef8eePage.RiskAccountsReceivable_0122_a8e5f5Async
        await _ui.WaitAsync(_locators.AccountsReceivableHeading, "Exists");
        await _ui.PressAsync(_locators.SearchValue79E46, "PRE:TAB");
        await _ui.PressAsync(_locators.SearchValue79E46, "Tab");
        await _ui.FillAsync(_locators.SearchValue79E46, _data.Resolve("{{data:search_value_221}}"));
        await _ui.PressAsync(_locators.SearchValue79E46, "Tab");
        await _ui.PressAsync(_locators.SearchValue79E46, "CLICK");
        await _ui.PressAsync(_locators.SearchValue79E46, "Tab");
        await _ui.FillAsync(_locators.SearchResultEAFB8, _data.Resolve("{{data:search_result_222}}"));
        await _ui.PressAsync(_locators.SearchResultEAFB8, "Tab");
        await _ui.PressAsync(_locators.SearchResultEAFB8, "CLICK");
        await _ui.PressAsync(_locators.SearchResultEAFB8, "Enter");
        await _ui.PressAsync(_locators.SearchResultEAFB8, "Tab");
        await _ui.FillAsync(_locators.ConstructionFB8D9, _data.Resolve("{{data:construction_223}}"));
        await _ui.PressAsync(_locators.ConstructionFB8D9, "Tab");
        await _ui.PressAsync(_locators.ConstructionFB8D9, "CLICK");
        await _ui.PressAsync(_locators.ConstructionFB8D9, "Tab");
        await _ui.FillAsync(_locators.PremisesType, _data.Resolve("{{data:premises_type_224}}"));
        await _ui.PressAsync(_locators.PremisesType, "Tab");
        await _ui.PressAsync(_locators.PremisesType, "CLICK");
        await _ui.PressAsync(_locators.PremisesType, "Tab");
        await _ui.FillAsync(_locators.DuplicatedRecords, _data.Resolve("{{data:duplicated_records_225}}"));
        await _ui.PressAsync(_locators.DuplicatedRecords, "Tab");
        await _ui.PressAsync(_locators.DuplicatedRecords, "CLICK");
        await _ui.PressAsync(_locators.DuplicatedRecords, "Tab");
        await _ui.FillAsync(_locators.ClassificationOfRisk, _data.Resolve("{{data:classification_of_risk_226}}"));
        await _ui.PressAsync(_locators.ClassificationOfRisk, "Tab");
        await _ui.PressAsync(_locators.ClassificationOfRisk, "CLICK");
        await _ui.PressAsync(_locators.ClassificationOfRisk, "Tab");
        await _ui.ClickAsync(_locators.RiskAccountsReceivableOK);
    }

    // Business step: I add Bailees Customers
    public async Task AddBaileesCustomersAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToRiskScreen_0123_a8e5f5Async
        await _ui.ClickAsync(_locators.Risk5D6FA);
        // RiskMain_2f5e40Page.RiskMain_0124_a8e5f5Async
        await _ui.WaitAsync(_locators.Risk873E7, "Exists");
        await _ui.FillAsync(_locators.CoverageFormCFDD1, _data.Resolve("{{data:coverage_form_230}}"));
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.ClickAsync(_locators.Add);
        // RiskBaileesCustomers_a875f1Page.RiskBaileesCustomers_0125_a8e5f5Async
        await _ui.WaitAsync(_locators.BaileesCustomersHeading, "Exists");
        await _ui.FillAsync(_locators.Deductible59155, _data.Resolve("{{data:deductible_233}}"));
        await _ui.PressAsync(_locators.Deductible59155, "Tab");
        await _ui.PressAsync(_locators.Deductible59155, "CLICK");
        await _ui.PressAsync(_locators.Deductible59155, "Tab");
        await _ui.PressAsync(_locators.SearchValueCA6A6, "PRE:TAB");
        await _ui.PressAsync(_locators.SearchValueCA6A6, "Tab");
        await _ui.FillAsync(_locators.SearchValueCA6A6, _data.Resolve("{{data:search_value_235}}"));
        await _ui.PressAsync(_locators.SearchValueCA6A6, "CLICK");
        await _ui.PressAsync(_locators.SearchValueCA6A6, "Tab");
        await _ui.PressAsync(_locators.SearchValueCA6A6, "Tab");
        await _ui.FillAsync(_locators.SearchResultA1BFB, _data.Resolve("{{data:search_result_236}}"));
        await _ui.PressAsync(_locators.SearchResultA1BFB, "Tab");
        await _ui.PressAsync(_locators.SearchResultA1BFB, "CLICK");
        await _ui.PressAsync(_locators.SearchResultA1BFB, "Enter");
        await _ui.PressAsync(_locators.SearchResultA1BFB, "Tab");
        await _ui.FillAsync(_locators.ConstructionCD2DE, _data.Resolve("{{data:construction_237}}"));
        await _ui.PressAsync(_locators.ConstructionCD2DE, "Tab");
        await _ui.PressAsync(_locators.ConstructionCD2DE, "CLICK");
        await _ui.PressAsync(_locators.ConstructionCD2DE, "Tab");
        await _ui.FillAsync(_locators.AnnualGrossReceipts, _data.Resolve("{{data:annual_gross_receipts_238}}"));
        await _ui.PressAsync(_locators.AnnualGrossReceipts, "Tab");
        await _ui.PressAsync(_locators.AnnualGrossReceipts, "CLICK");
        await _ui.PressAsync(_locators.AnnualGrossReceipts, "Tab");
        await _ui.FillAsync(_locators.AverageNumberOfDaysService, _data.Resolve("{{data:average_number_of_days_service_239}}"));
        await _ui.PressAsync(_locators.AverageNumberOfDaysService, "Tab");
        await _ui.PressAsync(_locators.AverageNumberOfDaysService, "CLICK");
        await _ui.PressAsync(_locators.AverageNumberOfDaysService, "Tab");
        await _ui.FillAsync(_locators.AverageNumberOfWorkingDays, _data.Resolve("{{data:average_number_of_working_days_240}}"));
        await _ui.PressAsync(_locators.AverageNumberOfWorkingDays, "Tab");
        await _ui.PressAsync(_locators.AverageNumberOfWorkingDays, "CLICK");
        await _ui.PressAsync(_locators.AverageNumberOfWorkingDays, "Tab");
        await _ui.FillAsync(_locators.AverageServiceCharge, _data.Resolve("{{data:average_service_charge_241}}"));
        await _ui.PressAsync(_locators.AverageServiceCharge, "Tab");
        await _ui.PressAsync(_locators.AverageServiceCharge, "CLICK");
        await _ui.PressAsync(_locators.AverageServiceCharge, "Tab");
        await _ui.FillAsync(_locators.AverageValuePerOrder, _data.Resolve("{{data:average_value_per_order_242}}"));
        await _ui.PressAsync(_locators.AverageValuePerOrder, "Tab");
        await _ui.PressAsync(_locators.AverageValuePerOrder, "CLICK");
        await _ui.PressAsync(_locators.AverageValuePerOrder, "Tab");
        await _ui.FillAsync(_locators.LimitE32DC, _data.Resolve("{{data:limit_243}}"));
        await _ui.PressAsync(_locators.LimitE32DC, "Tab");
        await _ui.PressAsync(_locators.LimitE32DC, "CLICK");
        await _ui.PressAsync(_locators.LimitE32DC, "Tab");
        await _ui.FillAsync(_locators.Earthquake, _data.Resolve("{{data:earthquake_244}}"));
        await _ui.PressAsync(_locators.Earthquake, "Tab");
        await _ui.PressAsync(_locators.Earthquake, "CLICK");
        await _ui.PressAsync(_locators.Earthquake, "Tab");
        await _ui.FillAsync(_locators.StorageLimit, _data.Resolve("{{data:storage_limit_245}}"));
        await _ui.PressAsync(_locators.StorageLimit, "Tab");
        await _ui.PressAsync(_locators.StorageLimit, "CLICK");
        await _ui.PressAsync(_locators.StorageLimit, "Tab");
        await _ui.ClickAsync(_locators.RiskBaileesCustomersOK);
    }

    // Business step: I add Computer Systems for risk
    public async Task AddComputerSystemsForRiskAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToRiskScreen_0126_a8e5f5Async
        await _ui.ClickAsync(_locators.Risk5D6FA);
        // RiskMain_2f5e40Page.RiskMain_0127_a8e5f5Async
        await _ui.WaitAsync(_locators.Risk873E7, "Exists");
        await _ui.FillAsync(_locators.CoverageFormCFDD1, _data.Resolve("{{data:coverage_form_249}}"));
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.ClickAsync(_locators.Add);
        // RiskComputerSystems_7b4caaPage.RiskComputerEquipment_0128_a8e5f5Async
        await _ui.FillAsync(_locators.ComputerEquipment, _data.Resolve("{{data:computer_equipment_251}}"));
        await _ui.PressAsync(_locators.ComputerEquipment, "Tab");
        await _ui.PressAsync(_locators.ComputerEquipment, "CLICK");
        await _ui.PressAsync(_locators.ComputerEquipment, "Tab");
        await _ui.FillAsync(_locators.DataAndMedia, _data.Resolve("{{data:data_and_media_252}}"));
        await _ui.PressAsync(_locators.DataAndMedia, "Tab");
        await _ui.PressAsync(_locators.DataAndMedia, "CLICK");
        await _ui.PressAsync(_locators.DataAndMedia, "Tab");
        await _ui.PressAsync(_locators.SearchValue9FCD1, "PRE:TAB");
        await _ui.PressAsync(_locators.SearchValue9FCD1, "Tab");
        await _ui.FillAsync(_locators.SearchValue9FCD1, _data.Resolve("{{data:search_value_254}}"));
        await _ui.PressAsync(_locators.SearchValue9FCD1, "CLICK");
        await _ui.PressAsync(_locators.SearchValue9FCD1, "Tab");
        await _ui.PressAsync(_locators.SearchValue9FCD1, "Tab");
        await _ui.FillAsync(_locators.SearchResult4E620, _data.Resolve("{{data:search_result_255}}"));
        await _ui.PressAsync(_locators.SearchResult4E620, "Tab");
        await _ui.PressAsync(_locators.SearchResult4E620, "Click");
        await _ui.PressAsync(_locators.SearchResult4E620, "Enter");
        await _ui.PressAsync(_locators.SearchResult4E620, "Tab");
        await _ui.PressAsync(_locators.SearchResult4E620, "Tab");
        await _ui.PressAsync(_locators.SearchResult4E620, "Tab");
        await _ui.FillAsync(_locators.ConstructionCode, _data.Resolve("{{data:construction_code_256}}"));
        await _ui.PressAsync(_locators.ConstructionCode, "Tab");
        await _ui.PressAsync(_locators.ConstructionCode, "CLICK");
        await _ui.PressAsync(_locators.ConstructionCode, "Tab");
        await _ui.ClickAsync(_locators.RiskComputerSystemsOK);
    }

    // Business step: I add Signs for risk
    public async Task AddSignsForRiskAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToRiskScreen_0129_a8e5f5Async
        await _ui.ClickAsync(_locators.Risk5D6FA);
        // RiskMain_2f5e40Page.RiskMain_0130_a8e5f5Async
        await _ui.WaitAsync(_locators.Risk873E7, "Exists");
        await _ui.FillAsync(_locators.CoverageFormCFDD1, _data.Resolve("{{data:coverage_form_260}}"));
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormCFDD1, "Tab");
        await _ui.ClickAsync(_locators.Add);
        // RiskSigns_af05f3Page.RiskSigns_0131_a8e5f5Async
        await _ui.WaitAsync(_locators.SignsHeading, "Exists");
        await _ui.FillAsync(_locators.LimitOfInsurance, _data.Resolve("{{data:limit_of_insurance_263}}"));
        await _ui.PressAsync(_locators.LimitOfInsurance, "Tab");
        await _ui.PressAsync(_locators.LimitOfInsurance, "CLICK");
        await _ui.PressAsync(_locators.LimitOfInsurance, "Tab");
        await _ui.FillAsync(_locators.SignLocation, _data.Resolve("{{data:sign_location_264}}"));
        await _ui.PressAsync(_locators.SignLocation, "Tab");
        await _ui.PressAsync(_locators.SignLocation, "CLICK");
        await _ui.PressAsync(_locators.SignLocation, "Tab");
        await _ui.FillAsync(_locators.TypeB082D, _data.Resolve("{{data:type_265}}"));
        await _ui.PressAsync(_locators.TypeB082D, "Tab");
        await _ui.PressAsync(_locators.TypeB082D, "CLICK");
        await _ui.PressAsync(_locators.TypeB082D, "Tab");
        await _ui.FillAsync(_locators.Lettering, _data.Resolve("{{data:lettering_266}}"));
        await _ui.PressAsync(_locators.Lettering, "Tab");
        await _ui.PressAsync(_locators.Lettering, "CLICK");
        await _ui.PressAsync(_locators.Lettering, "Tab");
        await _ui.ClickAsync(_locators.RiskSignsOK);
    }

    // Business step: I add CM 66 01 Exclude Named Customer
    public async Task AddCM6601ExcludeNamedCustomerAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToEndorsementScreen_0132_a8e5f5Async
        await _ui.ClickAsync(_locators.Endorsement);
        // EndorsementMain_0e2165Page.EndorsementMain_0133_a8e5f5Async
        await _ui.WaitAsync(_locators.EndorsementHeading, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsement48A9E);
        await _ui.FillAsync(_locators.Type715D6, _data.Resolve("{{data:type_271}}"));
        await _ui.PressAsync(_locators.Type715D6, "CLICK");
        await _ui.PressAsync(_locators.Type715D6, "Tab");
        // EndorsementCM6601ExcludeNamedCustomer_1ccfdfPage.EndorsementCM6601ExcludeNamedCustomer_0134_a8e5f5Async
        await _ui.PressAsync(_locators.Names, "PRE:TAB");
        await _ui.PressAsync(_locators.Names, "Tab");
        await _ui.FillAsync(_locators.Names, _data.Resolve("{{data:names_273}}"));
        await _ui.PressAsync(_locators.Names, "CLICK");
        await _ui.PressAsync(_locators.Names, "Tab");
        await _ui.PressAsync(_locators.Address, "PRE:TAB");
        await _ui.PressAsync(_locators.Address, "Tab");
        await _ui.FillAsync(_locators.Address, _data.Resolve("{{data:address_275}}"));
        await _ui.PressAsync(_locators.Address, "CLICK");
        await _ui.PressAsync(_locators.Address, "Tab");
        await _ui.ClickAsync(_locators.EndorsementCM6601ExcludeNamedCustomerOK);
    }

    // Business step: I add IF 00 02 Waterborne Equipment
    public async Task AddIF0002WaterborneEquipmentAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToEndorsementScreen_0135_a8e5f5Async
        await _ui.ClickAsync(_locators.Endorsement);
        // EndorsementMain_0e2165Page.EndorsementMain_0136_a8e5f5Async
        await _ui.WaitAsync(_locators.EndorsementHeading, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsement48A9E);
        await _ui.FillAsync(_locators.Type715D6, _data.Resolve("{{data:type_280}}"));
        await _ui.PressAsync(_locators.Type715D6, "Tab");
        await _ui.PressAsync(_locators.Type715D6, "Tab");
        // EndorsementIF0002WaterborneEquipment_eac821Page.EndorsementIF0002WaterborneEquipment_0137_a8e5f5Async
        await _ui.FillAsync(_locators.Limit887C5, _data.Resolve("{{data:limit_281}}"));
        await _ui.PressAsync(_locators.Limit887C5, "Tab");
        await _ui.FillAsync(_locators.Deductible0CC0A, _data.Resolve("{{data:deductible_282}}"));
        await _ui.PressAsync(_locators.Deductible0CC0A, "Tab");
        await _ui.ClickAsync(_locators.EndorsementIF0002WaterborneEquipmentOK);
    }

    // Business step: I complete Accounts Receivable Questions
    public async Task CompleteAccountsReceivableQuestionsAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToSpecificUnderwritingQuestions_0138_a8e5f5Async
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestions);
        // IMNavigationLinks_7abd8aPage.NavigateToAccountsReceivableUWQuestions_0139_a8e5f5Async
        await _ui.ClickAsync(_locators.AccountsReceivableUWQuestions);
        // SpecificUnderwritingQuestionsAccountsReceivable_3d457ePage.SpecificUnderwritingQuestionsAccountsReceivable_0140_a8e5f5Async
        await _ui.WaitAsync(_locators.AccountsReceivableHeading, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswersD8A16);
        await _ui.FillAsync(_locators.WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored, _data.Resolve("{{data:what_is_the_construction_of_the_premises_where_the_receivables_are_stored_288}}"));
        await _ui.PressAsync(_locators.WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored, "Tab");
        await _ui.PressAsync(_locators.WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored, "CLICK");
        await _ui.PressAsync(_locators.WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored, "Tab");
        await _ui.PressAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, "PRE:TAB");
        await _ui.PressAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, "Tab");
        await _ui.FillAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, _data.Resolve("{{data:what_safeguards_are_in_place_for_receivables_to_protect_against_damage_or_theft_290}}"));
        await _ui.PressAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, "Tab");
        await _ui.PressAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, "CLICK");
        await _ui.PressAsync(_locators.WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft, "Tab");
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsAccountsReceivableOK);
    }

    // Business step: I complete Bailees Customers Questions
    public async Task CompleteBaileesCustomersQuestionsAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToSpecificUnderwritingQuestions_0141_a8e5f5Async
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestions);
        // IMNavigationLinks_7abd8aPage.NavigateToBaileesCustomersUWQuestions_0142_a8e5f5Async
        await _ui.ClickAsync(_locators.BaileesCustomerUWQuestions);
        // SpecificUnderwritingQuestionsBaileesCustomer_5a687aPage.SpecificUnderwritingQuestionsBaileesCustomer_0143_a8e5f5Async
        await _ui.WaitAsync(_locators.BaileesCustomerHeading, "Exists");
        await _ui.FillAsync(_locators.DryCleaning, _data.Resolve("{{data:dry_cleaning_295}}"));
        await _ui.PressAsync(_locators.DryCleaning, "Tab");
        await _ui.PressAsync(_locators.DryCleaning, "CLICK");
        await _ui.PressAsync(_locators.DryCleaning, "Tab");
        await _ui.FillAsync(_locators.Laundry, _data.Resolve("{{data:laundry_296}}"));
        await _ui.PressAsync(_locators.Laundry, "Tab");
        await _ui.PressAsync(_locators.Laundry, "CLICK");
        await _ui.PressAsync(_locators.Laundry, "Tab");
        await _ui.FillAsync(_locators.N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises, _data.Resolve("{{data:2_indicate_the_age_type_of_construction_and_protection_class_of_the_premises_297}}"));
        await _ui.PressAsync(_locators.N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises, "Tab");
        await _ui.PressAsync(_locators.N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises, "CLICK");
        await _ui.PressAsync(_locators.N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises, "Tab");
        await _ui.FillAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, _data.Resolve("{{data:3_what_is_the_percentage_of_annual_gross_receipts_derived_from_service_or_repair_298}}"));
        await _ui.PressAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, "Tab");
        await _ui.PressAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, "Tab");
        await _ui.PressAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, "CLICK");
        await _ui.PressAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, "CLICK");
        await _ui.PressAsync(_locators.N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair, "Tab");
        await _ui.FillAsync(_locators.N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated, _data.Resolve("{{data:4_what_method_do_you_use_for_keeping_records_of_property_in_your_care_and_how_often_are_the_records_updated_299}}"));
        await _ui.PressAsync(_locators.N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated, "Tab");
        await _ui.PressAsync(_locators.N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated, "CLICK");
        await _ui.PressAsync(_locators.N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated, "Tab");
        await _ui.FillAsync(_locators.N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained, _data.Resolve("{{data:5_are_recognized_approved_central_station_burglar_alarms_installed_and_maintained_300}}"));
        await _ui.PressAsync(_locators.N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained, "Tab");
        await _ui.PressAsync(_locators.N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained, "CLICK");
        await _ui.PressAsync(_locators.N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained, "Tab");
        await _ui.FillAsync(_locators.N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied, _data.Resolve("{{data:6_are_all_storage_areas_locked_at_all_times_when_unoccupied_301}}"));
        await _ui.PressAsync(_locators.N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied, "Tab");
        await _ui.PressAsync(_locators.N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied, "CLICK");
        await _ui.PressAsync(_locators.N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied, "Tab");
        await _ui.FillAsync(_locators.N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises, _data.Resolve("{{data:7_are_there_any_hazardous_or_flammable_materials_used_or_stored_on_the_premises_302}}"));
        await _ui.PressAsync(_locators.N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises, "Tab");
        await _ui.PressAsync(_locators.N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises, "CLICK");
        await _ui.PressAsync(_locators.N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises, "Tab");
        await _ui.FillAsync(_locators.AWhatIsThePublicProtectionClassRating, _data.Resolve("{{data:a_what_is_the_public_protection_class_rating_303}}"));
        await _ui.PressAsync(_locators.AWhatIsThePublicProtectionClassRating, "Tab");
        await _ui.PressAsync(_locators.AWhatIsThePublicProtectionClassRating, "Tab");
        await _ui.PressAsync(_locators.AWhatIsThePublicProtectionClassRating, "CLICK");
        await _ui.PressAsync(_locators.AWhatIsThePublicProtectionClassRating, "CLICK");
        await _ui.PressAsync(_locators.AWhatIsThePublicProtectionClassRating, "Tab");
        await _ui.FillAsync(_locators.BAreThereAnyPrivateProtectionImprovements, _data.Resolve("{{data:b_are_there_any_private_protection_improvements_304}}"));
        await _ui.PressAsync(_locators.BAreThereAnyPrivateProtectionImprovements, "Tab");
        await _ui.PressAsync(_locators.BAreThereAnyPrivateProtectionImprovements, "CLICK");
        await _ui.PressAsync(_locators.BAreThereAnyPrivateProtectionImprovements, "Tab");
        await _ui.FillAsync(_locators.CWhatIsTheDistanceInFeetToTheNearestHydrant, _data.Resolve("{{data:c_what_is_the_distance_in_feet_to_the_nearest_hydrant_305}}"));
        await _ui.PressAsync(_locators.CWhatIsTheDistanceInFeetToTheNearestHydrant, "Tab");
        await _ui.PressAsync(_locators.CWhatIsTheDistanceInFeetToTheNearestHydrant, "CLICK");
        await _ui.PressAsync(_locators.CWhatIsTheDistanceInFeetToTheNearestHydrant, "Tab");
        await _ui.FillAsync(_locators.DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, _data.Resolve("{{data:d_what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_306}}"));
        await _ui.PressAsync(_locators.DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "Tab");
        await _ui.PressAsync(_locators.DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "CLICK");
        await _ui.PressAsync(_locators.DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "Tab");
        await _ui.FillAsync(_locators.EAreNoSmokingRulesPostedAndEnforced, _data.Resolve("{{data:e_are_no_smoking_rules_posted_and_enforced_307}}"));
        await _ui.PressAsync(_locators.EAreNoSmokingRulesPostedAndEnforced, "Tab");
        await _ui.PressAsync(_locators.EAreNoSmokingRulesPostedAndEnforced, "CLICK");
        await _ui.PressAsync(_locators.EAreNoSmokingRulesPostedAndEnforced, "Tab");
        await _ui.FillAsync(_locators.N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem, _data.Resolve("{{data:9_are_the_premises_or_any_portion_of_the_premises_equipped_with_a_sprinkler_system_308}}"));
        await _ui.PressAsync(_locators.N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem, "Tab");
        await _ui.PressAsync(_locators.N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem, "CLICK");
        await _ui.PressAsync(_locators.N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem, "Tab");
        await _ui.FillAsync(_locators.N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms, _data.Resolve("{{data:10_are_the_premises_equipped_with_a_recognized_approved_central_station_fire_alarm_fire_extinguishers_or_smoke_alarms_309}}"));
        await _ui.PressAsync(_locators.N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms, "Tab");
        await _ui.PressAsync(_locators.N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms, "CLICK");
        await _ui.PressAsync(_locators.N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms, "Tab");
        await _ui.FillAsync(_locators.N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit, _data.Resolve("{{data:11_what_is_the_procedure_for_transporting_property_include_the_transit_methods_used_and_the_protection_class_provided_while_in_transit_310}}"));
        await _ui.PressAsync(_locators.N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit, "Tab");
        await _ui.PressAsync(_locators.N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit, "CLICK");
        await _ui.PressAsync(_locators.N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit, "Tab");
        await _ui.FillAsync(_locators.N12AreDriversMVRsReviewedOnARegularBasisAndMaintained, _data.Resolve("{{data:12_are_drivers_mvrs_reviewed_on_a_regular_basis_and_maintained_311}}"));
        await _ui.PressAsync(_locators.N12AreDriversMVRsReviewedOnARegularBasisAndMaintained, "Tab");
        await _ui.PressAsync(_locators.N12AreDriversMVRsReviewedOnARegularBasisAndMaintained, "CLICK");
        await _ui.PressAsync(_locators.N12AreDriversMVRsReviewedOnARegularBasisAndMaintained, "Tab");
        await _ui.FillAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, _data.Resolve("{{data:13_what_types_of_vehicles_do_you_operate_and_what_protective_devices_are_on_each_vehicle_312}}"));
        await _ui.PressAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, "Tab");
        await _ui.PressAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, "Tab");
        await _ui.PressAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, "CLICK");
        await _ui.PressAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, "CLICK");
        await _ui.PressAsync(_locators.N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle, "Tab");
        await _ui.FillAsync(_locators.N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage, _data.Resolve("{{data:14_what_is_your_procedure_for_protecting_small_items_from_breakage_or_disappearance_while_in_storage_313}}"));
        await _ui.PressAsync(_locators.N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage, "Tab");
        await _ui.PressAsync(_locators.N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage, "CLICK");
        await _ui.PressAsync(_locators.N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage, "Tab");
        await _ui.FillAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, _data.Resolve("{{data:15_what_measures_does_the_insured_take_to_protect_customer_s_property_against_theft_314}}"));
        await _ui.PressAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, "Tab");
        await _ui.PressAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, "Tab");
        await _ui.PressAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, "CLICK");
        await _ui.PressAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, "CLICK");
        await _ui.PressAsync(_locators.N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft, "Tab");
        await _ui.FillAsync(_locators.N16DoesTheRiskUseReleaseForms, _data.Resolve("{{data:16_does_the_risk_use_release_forms_315}}"));
        await _ui.PressAsync(_locators.N16DoesTheRiskUseReleaseForms, "Tab");
        await _ui.PressAsync(_locators.N16DoesTheRiskUseReleaseForms, "CLICK");
        await _ui.PressAsync(_locators.N16DoesTheRiskUseReleaseForms, "Tab");
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsBaileesCustomerOK);
    }

    // Business step: I complete Computer Systems Questions
    public async Task CompleteComputerSystemsQuestionsAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToSpecificUnderwritingQuestions_0144_a8e5f5Async
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestions);
        // IMNavigationLinks_7abd8aPage.NavigateToComputerSystemsUWQuestions_0145_a8e5f5Async
        await _ui.ClickAsync(_locators.ComputerSystemsUWQuestions);
        // SpecificUnderwritingQuestionsComputerSystems_61d932Page.SpecificUnderwritingQuestionsComputerSystems_0146_a8e5f5Async
        await _ui.ClickAsync(_locators.UpdateAnswers3DDA2);
        await _ui.PressAsync(_locators.UpdateAnswers3DDA2, "Tab");
        await _ui.PressAsync(_locators.UpdateAnswers3DDA2, "Click");
        await _ui.FillAsync(_locators.WhatIsTheProcedureForTransportingTheComputerEquipment, _data.Resolve("{{data:what_is_the_procedure_for_transporting_the_computer_equipment_320}}"));
        await _ui.PressAsync(_locators.WhatIsTheProcedureForTransportingTheComputerEquipment, "Tab");
        await _ui.PressAsync(_locators.WhatIsTheProcedureForTransportingTheComputerEquipment, "CLICK");
        await _ui.PressAsync(_locators.WhatIsTheProcedureForTransportingTheComputerEquipment, "Tab");
        await _ui.FillAsync(_locators.IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated, _data.Resolve("{{data:indicate_the_building_s_age_type_of_construction_and_protection_class_and_other_tenants_in_the_building_s_where_the_computer_equipment_is_located_321}}"));
        await _ui.PressAsync(_locators.IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated, "Tab");
        await _ui.PressAsync(_locators.IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated, "CLICK");
        await _ui.PressAsync(_locators.IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated, "Tab");
        await _ui.FillAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, _data.Resolve("{{data:what_are_the_procedures_and_methods_for_keeping_the_edp_areas_secured_322}}"));
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, "Tab");
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, "Tab");
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, "CLICK");
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, "CLICK");
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured, "Tab");
        await _ui.FillAsync(_locators.WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage, _data.Resolve("{{data:what_are_the_procedures_and_schedule_for_backing_up_the_media_and_data_and_their_storage_323}}"));
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage, "Tab");
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage, "CLICK");
        await _ui.PressAsync(_locators.WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage, "Tab");
        await _ui.FillAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, _data.Resolve("{{data:provide_information_regarding_antivirus_methods_and_copyright_protection_of_data_and_media_324}}"));
        await _ui.PressAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, "Tab");
        await _ui.PressAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, "Tab");
        await _ui.PressAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, "CLICK");
        await _ui.PressAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, "CLICK");
        await _ui.PressAsync(_locators.ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia, "Tab");
        await _ui.FillAsync(_locators.WhatIsThePublicProtectionClassRating, _data.Resolve("{{data:what_is_the_public_protection_class_rating_325}}"));
        await _ui.PressAsync(_locators.WhatIsThePublicProtectionClassRating, "Tab");
        await _ui.PressAsync(_locators.WhatIsThePublicProtectionClassRating, "Tab");
        await _ui.PressAsync(_locators.WhatIsThePublicProtectionClassRating, "CLICK");
        await _ui.PressAsync(_locators.WhatIsThePublicProtectionClassRating, "CLICK");
        await _ui.PressAsync(_locators.WhatIsThePublicProtectionClassRating, "CLICK");
        await _ui.PressAsync(_locators.WhatIsThePublicProtectionClassRating, "Tab");
        await _ui.FillAsync(_locators.WhatIsTheDistanceInFeetToTheNearestFireHydrant, _data.Resolve("{{data:what_is_the_distance_in_feet_to_the_nearest_fire_hydrant_326}}"));
        await _ui.PressAsync(_locators.WhatIsTheDistanceInFeetToTheNearestFireHydrant, "Tab");
        await _ui.PressAsync(_locators.WhatIsTheDistanceInFeetToTheNearestFireHydrant, "CLICK");
        await _ui.PressAsync(_locators.WhatIsTheDistanceInFeetToTheNearestFireHydrant, "CLICK");
        await _ui.PressAsync(_locators.WhatIsTheDistanceInFeetToTheNearestFireHydrant, "Tab");
        await _ui.FillAsync(_locators.WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, _data.Resolve("{{data:what_is_the_distance_in_miles_to_the_nearest_responding_fire_department_327}}"));
        await _ui.PressAsync(_locators.WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "Tab");
        await _ui.PressAsync(_locators.WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "CLICK");
        await _ui.PressAsync(_locators.WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "CLICK");
        await _ui.PressAsync(_locators.WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment, "Tab");
        await _ui.FillAsync(_locators.UninterruptiblePowerSource, _data.Resolve("{{data:uninterruptible_power_source_328}}"));
        await _ui.PressAsync(_locators.UninterruptiblePowerSource, "Tab");
        await _ui.PressAsync(_locators.UninterruptiblePowerSource, "CLICK");
        await _ui.PressAsync(_locators.UninterruptiblePowerSource, "Tab");
        await _ui.FillAsync(_locators.LineConditioner, _data.Resolve("{{data:line_conditioner_329}}"));
        await _ui.PressAsync(_locators.LineConditioner, "Tab");
        await _ui.PressAsync(_locators.LineConditioner, "CLICK");
        await _ui.PressAsync(_locators.LineConditioner, "Tab");
        await _ui.FillAsync(_locators.PowerSuppressorVoltageRegulator, _data.Resolve("{{data:power_suppressor_voltage_regulator_330}}"));
        await _ui.PressAsync(_locators.PowerSuppressorVoltageRegulator, "Tab");
        await _ui.PressAsync(_locators.PowerSuppressorVoltageRegulator, "CLICK");
        await _ui.PressAsync(_locators.PowerSuppressorVoltageRegulator, "Tab");
        await _ui.FillAsync(_locators.DedicatedLine, _data.Resolve("{{data:dedicated_line_331}}"));
        await _ui.PressAsync(_locators.DedicatedLine, "Tab");
        await _ui.PressAsync(_locators.DedicatedLine, "CLICK");
        await _ui.PressAsync(_locators.DedicatedLine, "Tab");
        await _ui.FillAsync(_locators.HowOftenIsDataBackedUp, _data.Resolve("{{data:how_often_is_data_backed_up_332}}"));
        await _ui.PressAsync(_locators.HowOftenIsDataBackedUp, "Tab");
        await _ui.PressAsync(_locators.HowOftenIsDataBackedUp, "CLICK");
        await _ui.PressAsync(_locators.HowOftenIsDataBackedUp, "Tab");
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsComputerSystemsOK);
    }

    // Business step: I complete Contractors Equipment Questions
    public async Task CompleteContractorsEquipmentQuestionsAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToSpecificUnderwritingQuestions_0147_a8e5f5Async
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestions);
        // IMNavigationLinks_7abd8aPage.NavigateToComputerSystemsUWQuestions_0148_a8e5f5Async
        await _ui.ClickAsync(_locators.ContractorsEquipmentUWQuestions);
        // SpecificUnderwritingQuestionsContractorsEquipment_12d34cPage.SpecificUnderwritingQuestionsContractorsEquipment_0149_a8e5f5Async
        await _ui.WaitAsync(_locators.ContractorsEquipmentHeading, "Exists");
        await _ui.ClickAsync(_locators.UpdateAnswers3DA0B);
        await _ui.FillAsync(_locators.EstimatedHighestValue, _data.Resolve("{{data:estimated_highest_value_338}}"));
        await _ui.PressAsync(_locators.EstimatedHighestValue, "Tab");
        await _ui.PressAsync(_locators.EstimatedHighestValue, "CLICK");
        await _ui.PressAsync(_locators.EstimatedHighestValue, "Tab");
        await _ui.FillAsync(_locators.IfYesDescribe, _data.Resolve("{{data:if_yes_describe_339}}"));
        await _ui.PressAsync(_locators.IfYesDescribe, "Tab");
        await _ui.PressAsync(_locators.IfYesDescribe, "CLICK");
        await _ui.PressAsync(_locators.IfYesDescribe, "Tab");
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsContractorsEquipmentOK);
    }

    // Business step: I complete Motor Truck Cargo Questions \(Owner\)
    public async Task CompleteMotorTruckCargoQuestionsOwnerAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToSpecificUnderwritingQuestions_0150_a8e5f5Async
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestions);
        // IMNavigationLinks_7abd8aPage.NavigateToComputerSystemsUWQuestions_0151_a8e5f5Async
        await _ui.ClickAsync(_locators.MotorTruckCargoUWQuestions);
        // SpecificUnderwritingQuestionsMotorTruckCargoOwners_143ba9Page.SpecificUnderwritingQuestionsMotorTruckCargoOwners_0152_a8e5f5Async
        await _ui.WaitAsync(_locators.MotorTruckCargoHeading, "Exists");
        await _ui.FillAsync(_locators.WhichFormAreYouCompleting, _data.Resolve("{{data:which_form_are_you_completing_344}}"));
        await _ui.PressAsync(_locators.WhichFormAreYouCompleting, "Tab");
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "PRE:TAB");
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "Tab");
        await _ui.FillAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, _data.Resolve("{{data:1_what_are_the_distances_the_shipments_will_travel_and_the_time_required_to_complete_the_shipment_346}}"));
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "Tab");
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "Tab");
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "CLICK");
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "CLICK");
        await _ui.PressAsync(_locators.N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment, "Tab");
        await _ui.FillAsync(_locators.N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities, _data.Resolve("{{data:2_what_are_the_types_and_ages_of_the_vehicles_trailers_used_to_transport_your_commodities_347}}"));
        await _ui.PressAsync(_locators.N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities, "Tab");
        await _ui.PressAsync(_locators.N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities, "CLICK");
        await _ui.PressAsync(_locators.N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities, "Tab");
        await _ui.FillAsync(_locators.N3DoesTheApplicantHaulForOthers, _data.Resolve("{{data:3_does_the_applicant_haul_for_others_348}}"));
        await _ui.PressAsync(_locators.N3DoesTheApplicantHaulForOthers, "Tab");
        await _ui.PressAsync(_locators.N3DoesTheApplicantHaulForOthers, "CLICK");
        await _ui.PressAsync(_locators.N3DoesTheApplicantHaulForOthers, "Tab");
        await _ui.FillAsync(_locators.N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer, _data.Resolve("{{data:4_what_protective_devices_are_installed_on_each_vehicle_or_trailer_349}}"));
        await _ui.PressAsync(_locators.N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer, "Tab");
        await _ui.PressAsync(_locators.N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer, "CLICK");
        await _ui.PressAsync(_locators.N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer, "Tab");
        await _ui.FillAsync(_locators.N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached, _data.Resolve("{{data:5_do_any_vehicles_have_special_equipment_mounted_or_attached_350}}"));
        await _ui.PressAsync(_locators.N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached, "Tab");
        await _ui.PressAsync(_locators.N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached, "CLICK");
        await _ui.PressAsync(_locators.N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached, "Tab");
        await _ui.FillAsync(_locators.N6DoesTheApplicantPullDoubleOrTripleTrailers, _data.Resolve("{{data:6_does_the_applicant_pull_double_or_triple_trailers_351}}"));
        await _ui.PressAsync(_locators.N6DoesTheApplicantPullDoubleOrTripleTrailers, "Tab");
        await _ui.PressAsync(_locators.N6DoesTheApplicantPullDoubleOrTripleTrailers, "CLICK");
        await _ui.PressAsync(_locators.N6DoesTheApplicantPullDoubleOrTripleTrailers, "Tab");
        await _ui.FillAsync(_locators.N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended, _data.Resolve("{{data:7_does_the_applicant_leave_the_truck_windows_doors_and_compartments_closed_and_locked_when_unattended_352}}"));
        await _ui.PressAsync(_locators.N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended, "Tab");
        await _ui.PressAsync(_locators.N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended, "CLICK");
        await _ui.PressAsync(_locators.N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended, "Tab");
        await _ui.FillAsync(_locators.N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate, _data.Resolve("{{data:8_do_you_provide_scheduled_maintenance_for_the_vehicles_and_trailers_you_operate_353}}"));
        await _ui.PressAsync(_locators.N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate, "Tab");
        await _ui.PressAsync(_locators.N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate, "CLICK");
        await _ui.PressAsync(_locators.N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate, "Tab");
        await _ui.FillAsync(_locators.N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities, _data.Resolve("{{data:9_are_the_employees_that_pack_load_and_unload_trained_in_proper_handling_of_the_commodities_354}}"));
        await _ui.PressAsync(_locators.N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities, "Tab");
        await _ui.PressAsync(_locators.N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities, "CLICK");
        await _ui.PressAsync(_locators.N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities, "Tab");
        await _ui.FillAsync(_locators.N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft, _data.Resolve("{{data:10_how_are_the_goods_being_transported_protected_from_damage_and_theft_355}}"));
        await _ui.PressAsync(_locators.N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft, "Tab");
        await _ui.PressAsync(_locators.N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft, "CLICK");
        await _ui.PressAsync(_locators.N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft, "Tab");
        await _ui.FillAsync(_locators.N11AreDriversMVRsAndTripLogsMaintained, _data.Resolve("{{data:11_are_drivers_mvrs_and_trip_logs_maintained_356}}"));
        await _ui.PressAsync(_locators.N11AreDriversMVRsAndTripLogsMaintained, "Tab");
        await _ui.PressAsync(_locators.N11AreDriversMVRsAndTripLogsMaintained, "CLICK");
        await _ui.PressAsync(_locators.N11AreDriversMVRsAndTripLogsMaintained, "Tab");
        await _ui.FillAsync(_locators.N12HowOftenAreTheseLogsReviewedOrUpdated, _data.Resolve("{{data:12_how_often_are_these_logs_reviewed_or_updated_357}}"));
        await _ui.PressAsync(_locators.N12HowOftenAreTheseLogsReviewedOrUpdated, "Tab");
        await _ui.PressAsync(_locators.N12HowOftenAreTheseLogsReviewedOrUpdated, "CLICK");
        await _ui.PressAsync(_locators.N12HowOftenAreTheseLogsReviewedOrUpdated, "Tab");
        await _ui.FillAsync(_locators.N13LiveAnimalInTransitCoverage, _data.Resolve("{{data:13_live_animal_in_transit_coverage_358}}"));
        await _ui.PressAsync(_locators.N13LiveAnimalInTransitCoverage, "Tab");
        await _ui.PressAsync(_locators.N13LiveAnimalInTransitCoverage, "CLICK");
        await _ui.PressAsync(_locators.N13LiveAnimalInTransitCoverage, "Tab");
        await _ui.FillAsync(_locators.N14LegalLiabilityCoverage, _data.Resolve("{{data:14_legal_liability_coverage_359}}"));
        await _ui.PressAsync(_locators.N14LegalLiabilityCoverage, "Tab");
        await _ui.PressAsync(_locators.N14LegalLiabilityCoverage, "CLICK");
        await _ui.PressAsync(_locators.N14LegalLiabilityCoverage, "Tab");
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsMotorTruckCargoOwnersOK);
    }

    // Business step: I complete Signs Questions
    public async Task CompleteSignsQuestionsAsync2()
    {
        // IMNavigationLinks_7abd8aPage.NavigateToSpecificUnderwritingQuestions_0153_a8e5f5Async
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestions);
        // IMNavigationLinks_7abd8aPage.NavigateToComputerSystemsUWQuestions_0154_a8e5f5Async
        await _ui.ClickAsync(_locators.SignsUWQuestions);
        // SpecificUnderwritingQuestionsSigns_b71b54Page.SpecificUnderwritingQuestionsSigns_0155_a8e5f5Async
        await _ui.WaitAsync(_locators.SignsHeading, "Exists");
        await _ui.FillAsync(_locators.AreAnySignsOffPremisesOrNotAttachedToBuilding, _data.Resolve("{{data:are_any_signs_off_premises_or_not_attached_to_building_364}}"));
        await _ui.PressAsync(_locators.AreAnySignsOffPremisesOrNotAttachedToBuilding, "Tab");
        await _ui.PressAsync(_locators.AreAnySignsOffPremisesOrNotAttachedToBuilding, "Tab");
        await _ui.FillAsync(_locators.DoesTheApplicantWishToCoverAnySignsInsideTheirPremises, _data.Resolve("{{data:does_the_applicant_wish_to_cover_any_signs_inside_their_premises_365}}"));
        await _ui.PressAsync(_locators.DoesTheApplicantWishToCoverAnySignsInsideTheirPremises, "Tab");
        await _ui.PressAsync(_locators.DoesTheApplicantWishToCoverAnySignsInsideTheirPremises, "Tab");
        await _ui.FillAsync(_locators.WhatIsTheConstructionOfEachSign, _data.Resolve("{{data:what_is_the_construction_of_each_sign_366}}"));
        await _ui.PressAsync(_locators.WhatIsTheConstructionOfEachSign, "Tab");
        await _ui.PressAsync(_locators.WhatIsTheConstructionOfEachSign, "Tab");
        await _ui.ClickAsync(_locators.SpecificUnderwritingQuestionsSignsOK);
    }

    // Business step: I complete required billing information for billing
    public async Task CompleteRequiredBillingInformationForBillingAsync6()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0182_a8e5f5Async
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0183_a8e5f5Async
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_370}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_373}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_377}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0184_a8e5f5Async
        await Task.Delay(1000);
    }

    // Business step: I add notepad comment
    public async Task AddNotepadCommentAsync10()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToNotePadScreen_0185_a8e5f5Async
        await _ui.ClickAsync(_locators.Notepad);
        // NotePad_055c33Page.AddNotesRemarksToNotePad_0186_a8e5f5Async
        await _ui.WaitAsync(_locators.NotepadHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNotesRemarks);
        await _ui.FillAsync(_locators.TextBox, _data.Resolve("Test {B[Product (LOB)]}"));
        await _ui.ClickAsync(_locators.NotePadOK);
    }

    // Business step: I complete required submission information
    public async Task CompleteRequiredSubmissionInformationAsync10()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0187_a8e5f5Async
        await _ui.WaitAsync(_locators.Submission, "Visible");
        await _ui.ClickAsync(_locators.Submission);
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutRequiredFields_0188_a8e5f5Async
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_388}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "CLICK");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.OrderAudit_0189_a8e5f5Async
        await _ui.VerifyAsync(_locators.OrderAudit, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutOrderAudit_0190_a8e5f5Async
        await _ui.FillAsync(_locators.OrderAudit, _data.Resolve("{{data:order_audit_390}}"));
        await _ui.PressAsync(_locators.OrderAudit, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeSubmissionScreenHeaderExists_0191_a8e5f5Async
        await _ui.VerifyAsync(_locators.SubmissionHeading, _data.Resolve("Absent"), "");
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0192_a8e5f5Async
        await _ui.PressAsync(_locators.Submission, "PRE:TAB");
        await _ui.PressAsync(_locators.Submission, "Tab");
        await _ui.ClickAsync(_locators.Submission);
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0193_a8e5f5Async
        await Task.Delay(1000);
        // SubmissionRequiredAndOptionalFields_4090a9Page.WaitOnSubmissionScreenToLoad_0194_a8e5f5Async
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        // TBoxWait_7ea9e1Page.N500msWaitForSyncing_0195_a8e5f5Async
        await Task.Delay(1000);
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync15()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0079_b3ff07Async
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0080_b3ff07Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0081_b3ff07Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0082_b3ff07Async
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_100}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_101}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0083_b3ff07Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0084_b3ff07Async
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_103}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_107}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0085_b3ff07Async
        _data.Set("StateIsKansas", _data.Resolve("Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'"));
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0087_b3ff07Async
        _data.Set("StateIsVirginia", _data.Resolve("Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'"));
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0089_b3ff07Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0090_b3ff07Async
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_113}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0091_b3ff07Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0092_b3ff07Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AZ IM Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I navigate to Policy Info and Verify Desc
    public async Task NavigateToPolicyInfoAndVerifyDescAsync4()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfo_0128_b3ff07Async
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.PolicyInfoVerifyDescriptionOfSpecifiedOperation_0129_b3ff07Async
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{B[QuoteDescription]}"), "value");
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync16()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0080_c7d608Async
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0081_c7d608Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0082_c7d608Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0083_c7d608Async
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_100}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_101}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0084_c7d608Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0085_c7d608Async
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_103}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_107}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0086_c7d608Async
        _data.Set("StateIsKansas", _data.Resolve("Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'"));
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0088_c7d608Async
        _data.Set("StateIsVirginia", _data.Resolve("Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'"));
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0089_c7d608Async
        if (_data.Condition("'Product (LOB)' == \"GL\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_110}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' == \"GL\""))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_111}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Down");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Enter");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0090_c7d608Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0091_c7d608Async
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_115}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0092_c7d608Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0093_c7d608Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AZ GL Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I navigate to Policy Info and Verify Desc
    public async Task NavigateToPolicyInfoAndVerifyDescAsync5()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfo_0129_c7d608Async
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.PolicyInfoVerifyDescriptionOfSpecifiedOperation_0130_c7d608Async
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{B[QuoteDescription]}"), "value");
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync17()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0079_2a8772Async
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0080_2a8772Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0081_2a8772Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0082_2a8772Async
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_100}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        if (_data.Condition("'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\""))
        {
            await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_101}}"));
            await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0083_2a8772Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0084_2a8772Async
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_103}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.ClickAsync(_locators.PrimaryRatingState);
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_107}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0085_2a8772Async
        _data.Set("StateIsKansas", _data.Resolve("Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'"));
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0087_2a8772Async
        _data.Set("StateIsVirginia", _data.Resolve("Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'"));
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0089_2a8772Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0090_2a8772Async
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.WaitAsync(_locators.PrimaryRatingState, "Exists");
        }
        if (_data.Condition("'Product (LOB)' != \"WC\""))
        {
            await _ui.PressAsync(_locators.PrimaryRatingState, "PRE:TAB");
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_113}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0091_2a8772Async
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0092_2a8772Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AZ CP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I navigate to Policy Info and Verify Desc
    public async Task NavigateToPolicyInfoAndVerifyDescAsync6()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfo_0128_2a8772Async
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.PolicyInfoVerifyDescriptionOfSpecifiedOperation_0129_2a8772Async
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{B[QuoteDescription]}"), "value");
    }

    // Business step: I complete required billing information
    public async Task CompleteRequiredBillingInformationAsync12()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0052_f2d6bdAsync
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0053_f2d6bdAsync
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_32}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_35}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_39}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0054_f2d6bdAsync
        await Task.Delay(1000);
    }

    // Business step: I navigate to Underwriting Info Screen
    public async Task NavigateToUnderwritingInfoScreenAsync4()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToUnderwritingInfoScreen_0065_f2d6bdAsync
        await _ui.ClickAsync(_locators.UnderwritingInfo);
        // UnderwritingInfoOtherInsuranceHistory_b78753Page.AddPriorCarriorDetailsOnLossInformationScreen_0066_f2d6bdAsync
        await _ui.WaitAsync(_locators.IsThereAPriorCarrier, "Exists");
        await _ui.FillAsync(_locators.IsThereAPriorCarrier, _data.Resolve("{{data:is_there_a_prior_carrier_80}}"));
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Tab");
        await _ui.WaitAsync(_locators.Carrier, "Exists");
        await _ui.FillAsync(_locators.Carrier, _data.Resolve("{{data:carrier_82}}"));
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.FillAsync(_locators.PolicyNumberBA28E, _data.Resolve("{{data:policy_number_83}}"));
        await _ui.PressAsync(_locators.PolicyNumberBA28E, "Tab");
        await _ui.FillAsync(_locators.PolicyType, _data.Resolve("{{data:policy_type_84}}"));
        await _ui.PressAsync(_locators.PolicyType, "Tab");
        await _ui.FillAsync(_locators.EffectiveDateB557F, _data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDateB557F, "Tab");
        await _ui.FillAsync(_locators.ExpirationDate34EAC, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate34EAC, "Tab");
        await _ui.FillAsync(_locators.ModificationFactor, _data.Resolve("{{data:modificationfactor_87}}"));
        await _ui.PressAsync(_locators.ModificationFactor, "Tab");
        await _ui.FillAsync(_locators.TotalPremium, _data.Resolve("{{data:total_premium_88}}"));
        await _ui.PressAsync(_locators.TotalPremium, "Tab");
        await _ui.ClickAsync(_locators.OtherInsuranceHistoryOK);
        await _ui.WaitAsync(_locators.Detail0F8C6, "Exists");
        // UnderwritingInfoLossExperience_54b758Page.IndicateNoKnownLossesOnLossExperienceScreen_0067_f2d6bdAsync
        await _ui.ClickAsync(_locators.LossExperience);
        await _ui.WaitAsync(_locators.NoKnownLosses, "Exists");
        await _ui.SmartSetAsync(_locators.NoKnownLosses, _data.Resolve("{{data:no_known_losses_93}}"));
        await _ui.PressAsync(_locators.NoKnownLosses, "Tab");
        // CommonNavigationLinks_dba56bPage.ClickReturnToQuote_0068_f2d6bdAsync
        await _ui.ClickAsync(_locators.ReturnToQuote);
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0069_f2d6bdAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_95}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_96}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_97}}"), "value");
    }

    // Business step: I complete required policy information
    public async Task CompleteRequiredPolicyInformationAsync18()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToPolicyInfoScreen_0070_f2d6bdAsync
        await _ui.ClickAsync(_locators.PolicyInfo);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.WaitForScreenToAppear_0071_f2d6bdAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Exists");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0072_f2d6bdAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterEffectiveDate_0073_f2d6bdAsync
        await _ui.FillAsync(_locators.EffectiveDate95094, _data.Resolve("{{data:effectivedate_101}}"));
        await _ui.PressAsync(_locators.EffectiveDate95094, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0074_f2d6bdAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.EnterPrimaryRatingState_0075_f2d6bdAsync
        if (_data.Condition("NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))"))
        {
            await _ui.FillAsync(_locators.PrimaryRatingState, _data.Resolve("{{data:primaryratingstate_103}}"));
            await _ui.PressAsync(_locators.PrimaryRatingState, "Tab");
        }
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_104}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        // TBoxEvaluationTool_b95b5cPage.StateIsKansas_0076_f2d6bdAsync
        _data.Set("StateIsKansas", _data.Resolve("Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"));
        // TBoxEvaluationTool_b95b5cPage.StateIsVirginia_0078_f2d6bdAsync
        _data.Set("StateIsVirginia", _data.Resolve("Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"));
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0080_f2d6bdAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.TabOutOfPrimaryRatingStateFieldForSyncronization_0081_f2d6bdAsync
        await _ui.FillAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, _data.Resolve("{{data:were_the_exposures_insured_on_this_policy_previously_insured_for_this_client_on_another_farm_family_american_national_policy_within_the_last_90_days_108}}"));
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "CLICK");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Enter");
        await _ui.PressAsync(_locators.WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days, "Tab");
        await _ui.VerifyAsync(_locators.PriorAmericanNationalPolicy, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational, _data.Resolve("Absent"), "");
        await _ui.VerifyAsync(_locators.IsThisPolicyBeingFullyCancelled, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0082_f2d6bdAsync
        await Task.Delay(1000);
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0083_f2d6bdAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AL WC ST {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I complete coverage Information
    public async Task CompleteCoverageInformationAsync2()
    {
        // WCNavigationLinks_672cc7Page.NavigateToPolicyCovgScreen_0090_f2d6bdAsync
        await _ui.ClickAsync(_locators.PolicyCovgD3CEF);
        // PolicyCovg_0dff37Page.PolicyCovg_0091_f2d6bdAsync
        await _ui.WaitAsync(_locators.PolicyCovgHeader, "Exists");
        await _ui.WaitAsync(_locators.PrimaryLocationState, "Exists");
        if (_data.Condition("'Primary Rating State' != NULL"))
        {
            await _ui.VerifyAsync(_locators.PrimaryLocationState, _data.Resolve("(?i)^Alabama$"), "Regex:value");
        }
        if (_data.Condition("('Experience Rated' != NULL)&&(State!=\"OK\")"))
        {
            await _ui.FillAsync(_locators.ExperienceRated, _data.Resolve("{{data:experience_rated_124}}"));
            await _ui.PressAsync(_locators.ExperienceRated, "Tab");
        }
        if (_data.Condition("('Default Experience Mod Type' != NULL)&&(State!=\"OK\")&&(State!=\"NY\")"))
        {
            _data.Set("ExpMod", await _ui.CaptureAsync(_locators.DefaultExperienceMod, "InnerText"));
        }
        if (_data.Condition("('Default Experience Mod Type' != NULL)&&(State!=\"OK\")&&(State!=\"NY\")"))
        {
            await _ui.FillAsync(_locators.DefaultExpModType, _data.Resolve("{{data:default_exp_mod_type_126}}"));
            await _ui.PressAsync(_locators.DefaultExpModType, "Tab");
        }
    }

    // Business step: I complete Address 1
    public async Task CompleteAddress1Async2()
    {
        // WCNavigationLinks_672cc7Page.NavigateToLocationScreen_0092_f2d6bdAsync
        await _ui.ClickAsync(_locators.Location8DEE2);
        // Location_d219c6Page.Location_0093_f2d6bdAsync
        await _ui.WaitAsync(_locators.Address1C0AF1, "Exists");
        await _ui.VerifyAsync(_locators.ZipCodeD2DBA, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        await _ui.ClickAsync(_locators.LocationOK);
    }

    // Business step: I complete rating Information
    public async Task CompleteRatingInformationAsync2()
    {
        // WCNavigationLinks_672cc7Page.NavigateToStateDetailsScreen_0094_f2d6bdAsync
        await _ui.ClickAsync(_locators.StateDetailsB407B);
        // StateDetailsMain_44b0fcPage.StateDetailsMainQuestions_0095_f2d6bdAsync
        await _ui.WaitAsync(_locators.IntrastateRiskID, "Exists");
        if (_data.Condition("'Waiver of Subrogation' != NULL"))
        {
            await _ui.FillAsync(_locators.WaiverOfSubrogation, _data.Resolve("{{data:waiver_of_subrogation_133}}"));
            await _ui.PressAsync(_locators.WaiverOfSubrogation, "Tab");
            await _ui.PressAsync(_locators.WaiverOfSubrogation, "Tab");
        }
        if (_data.Condition("'Small Deductible' != NULL"))
        {
            await _ui.FillAsync(_locators.SmallDeductible, _data.Resolve("{{data:small_deductible_134}}"));
            await _ui.PressAsync(_locators.SmallDeductible, "Tab");
            await _ui.PressAsync(_locators.SmallDeductible, "Tab");
        }
        if (_data.Condition("'Company Name' != NULL"))
        {
            await _ui.FillAsync(_locators.CompanyName, _data.Resolve("{{data:company_name_135}}"));
            await _ui.PressAsync(_locators.CompanyName, "Tab");
            await _ui.PressAsync(_locators.CompanyName, "CLICK");
            await _ui.PressAsync(_locators.CompanyName, "Tab");
            await _ui.PressAsync(_locators.CompanyName, "Tab");
        }
        if (_data.Condition("('Merit Rating' != NULL)&&(State!=\"NY\")"))
        {
            await _ui.FillAsync(_locators.MeritRating, _data.Resolve(""));
        }
        if (_data.Condition("Deductible != NULL"))
        {
            await _ui.FillAsync(_locators.Deductible5F45D, _data.Resolve(""));
        }
        if (_data.Condition("Deductible != NULL"))
        {
            await _ui.FillAsync(_locators.Deductible5F45D, _data.Resolve(""));
        }
        // StateDetailsExperienceRated_ecd96fPage.StateDetailsExperienceRated_0096_f2d6bdAsync
        if (_data.Condition("'Experience Rating Options' != NULL"))
        {
            await _ui.FillAsync(_locators.ExperienceRatingOptions, _data.Resolve("{{data:experience_rating_options_139}}"));
            await _ui.PressAsync(_locators.ExperienceRatingOptions, "Tab");
            await _ui.PressAsync(_locators.ExperienceRatingOptions, "Tab");
        }
        if (_data.Condition("'Experience Mod Type' != NULL"))
        {
            await _ui.FillAsync(_locators.ExperienceModType, _data.Resolve("{{data:experience_mod_type_140}}"));
            await _ui.PressAsync(_locators.ExperienceModType, "Tab");
            await _ui.PressAsync(_locators.ExperienceModType, "Tab");
        }
        // StateDetailsMain_44b0fcPage.StateDetailsCheckForPendingRateChange_0097_f2d6bdAsync
        if (_data.Condition("'Pending Rate Change' != NULL"))
        {
            await _ui.VerifyAsync(_locators.PendingRateChange, _data.Resolve("{{data:expected_pending_rate_change_value_141}}"), "value");
        }
    }

    // Business step: I add Class Codes
    public async Task AddClassCodesAsync2()
    {
        // WCNavigationLinks_672cc7Page.NavigateToWCSchedule_0099_f2d6bdAsync
        await _ui.ClickAsync(_locators.WCSchedule);
        // WCScheduleMainPage_7a7413Page.AddFirstClassCode_0100_f2d6bdAsync
        await _ui.WaitAsync(_locators.AddClassCode, "Exists");
        await _ui.ClickAsync(_locators.AddClassCode);
        await _ui.FillAsync(_locators.ClassCodeFrameClassCodeWindow, _data.Resolve(""));
        // WCScheduleMainPage_7a7413Page.LoopWhileOKButtonDoesNotExist_0101_f2d6bdAsync
        await _ui.VerifyAsync(_locators.OKClassCode, _data.Resolve("Absent"), "");
        // WCScheduleMainPage_7a7413Page.LoopForFirstClassCode_0102_f2d6bdAsync
        await _ui.WaitAsync(_locators.SearchValue53135, "Exists");
        if (_data.Condition("'Class Code 1' != NULL"))
        {
            await _ui.FillAsync(_locators.SearchValue53135, _data.Resolve("{{data:class_code_frame_class_code_window_searchvalue_148}}"));
            await _ui.PressAsync(_locators.SearchValue53135, "Tab");
        }
        await _ui.PressAsync(_locators.SearchValue53135, "PRE:TAB");
        await _ui.PressAsync(_locators.SearchValue53135, "Tab");
        if (_data.Condition("'Class Code 1' != NULL"))
        {
            await _ui.FillAsync(_locators.SelectClassCode, _data.Resolve("{{data:class_code_frame_class_code_window_select_class_code_150}}"));
            await _ui.PressAsync(_locators.SelectClassCode, "CLICK");
            await _ui.PressAsync(_locators.SelectClassCode, "Enter");
            await _ui.PressAsync(_locators.SelectClassCode, "Tab");
            await _ui.PressAsync(_locators.SelectClassCode, "CLICK");
            await _ui.PressAsync(_locators.SelectClassCode, "Tab");
            await _ui.PressAsync(_locators.SelectClassCode, "Tab");
        }
        await _ui.PressAsync(_locators.SelectClassCode, "PRE:TAB");
        await _ui.PressAsync(_locators.SelectClassCode, "Tab");
        // TBoxWait_7ea9e1Page.TBoxWait_0103_f2d6bdAsync
        await Task.Delay(1000);
        // WCScheduleMainPage_7a7413Page.InputFirstClassCodeDetails_0104_f2d6bdAsync
        if (_data.Condition("'Class Code 1' != NULL"))
        {
            await _ui.VerifyAsync(_locators.SelectClassCode, _data.Resolve("{{data:expected_class_code_frame_class_code_window_select_class_code_value_153}}"), "value");
        }
        await _ui.WaitAsync(_locators.OKClassCode, "Exists");
        await _ui.ClickAsync(_locators.OKClassCode);
        if (_data.Condition("State != \"MD\""))
        {
            await _ui.FillAsync(_locators.TotalPayrollEstimated, _data.Resolve("{{data:class_code_frame_class_code_window_total_payroll_estimated_156}}"));
            await _ui.PressAsync(_locators.TotalPayrollEstimated, "Tab");
            await _ui.PressAsync(_locators.TotalPayrollEstimated, "CLICK");
            await _ui.PressAsync(_locators.TotalPayrollEstimated, "Tab");
        }
        if (_data.Condition("'Waiver of Subrogation Exposure' != NULL"))
        {
            await _ui.FillAsync(_locators.WaiverOfSubrogationExposure, _data.Resolve("{{data:class_code_frame_class_code_window_waiver_of_subrogation_exposure_157}}"));
            await _ui.PressAsync(_locators.WaiverOfSubrogationExposure, "Tab");
            await _ui.PressAsync(_locators.WaiverOfSubrogationExposure, "CLICK");
            await _ui.PressAsync(_locators.WaiverOfSubrogationExposure, "Tab");
        }
        await _ui.FillAsync(_locators.NumberOfPartTimeEmployees, _data.Resolve("{{data:class_code_frame_class_code_window_number_of_part_time_employees_158}}"));
        await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Tab");
        await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "CLICK");
        await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Tab");
        await _ui.FillAsync(_locators.NumberOfFullTimeEmployees, _data.Resolve("{{data:class_code_frame_class_code_window_number_of_full_time_employees_159}}"));
        await _ui.PressAsync(_locators.NumberOfFullTimeEmployees, "Tab");
        await _ui.PressAsync(_locators.NumberOfFullTimeEmployees, "CLICK");
        await _ui.PressAsync(_locators.NumberOfFullTimeEmployees, "Tab");
        await _ui.ClickAsync(_locators.OKDetails);
        await _ui.WaitAsync(_locators.ClassCodeFrame, "Absent");
        // WCScheduleMainPage_7a7413Page.AddSecondClassCode_0105_f2d6bdAsync
        await _ui.WaitAsync(_locators.AddClassCode, "Exists");
        await _ui.ClickAsync(_locators.AddClassCode);
        // WCScheduleMainPage_7a7413Page.LoopWhileOKButtonDoesNotExist_0106_f2d6bdAsync
        await _ui.VerifyAsync(_locators.OKClassCode, _data.Resolve("Absent"), "");
        // WCScheduleMainPage_7a7413Page.LoopForSecondClassCode_0107_f2d6bdAsync
        await _ui.WaitAsync(_locators.SearchValue53135, "Exists");
        if (_data.Condition("'Class Code 2' != NULL"))
        {
            await _ui.FillAsync(_locators.SearchValue53135, _data.Resolve("{{data:class_code_frame_class_code_window_searchvalue_166}}"));
            await _ui.PressAsync(_locators.SearchValue53135, "Tab");
        }
        await _ui.PressAsync(_locators.SearchValue53135, "PRE:TAB");
        await _ui.PressAsync(_locators.SearchValue53135, "Tab");
        if (_data.Condition("'Class Code 2' != NULL"))
        {
            await _ui.FillAsync(_locators.SelectClassCode, _data.Resolve("{{data:class_code_frame_class_code_window_select_class_code_168}}"));
            await _ui.PressAsync(_locators.SelectClassCode, "CLICK");
            await _ui.PressAsync(_locators.SelectClassCode, "Enter");
            await _ui.PressAsync(_locators.SelectClassCode, "Tab");
            await _ui.PressAsync(_locators.SelectClassCode, "CLICK");
            await _ui.PressAsync(_locators.SelectClassCode, "Tab");
            await _ui.PressAsync(_locators.SelectClassCode, "Tab");
        }
        await _ui.PressAsync(_locators.SelectClassCode, "PRE:TAB");
        await _ui.PressAsync(_locators.SelectClassCode, "Tab");
        // TBoxWait_7ea9e1Page.TBoxWait_0108_f2d6bdAsync
        await Task.Delay(1000);
        // WCScheduleMainPage_7a7413Page.InputSecondClassCodeDetails_0109_f2d6bdAsync
        if (_data.Condition("'Class Code 2' != NULL"))
        {
            await _ui.VerifyAsync(_locators.SelectClassCode, _data.Resolve("{{data:expected_class_code_frame_class_code_window_select_class_code_value_171}}"), "value");
        }
        await _ui.WaitAsync(_locators.OKClassCode, "Exists");
        await _ui.ClickAsync(_locators.OKClassCode);
        await _ui.FillAsync(_locators.TotalPayrollEstimated, _data.Resolve("{{data:class_code_frame_class_code_window_total_payroll_estimated_174}}"));
        await _ui.PressAsync(_locators.TotalPayrollEstimated, "Tab");
        await _ui.PressAsync(_locators.TotalPayrollEstimated, "CLICK");
        await _ui.PressAsync(_locators.TotalPayrollEstimated, "Tab");
        if (_data.Condition("'Waiver of Subrogation Exposure' != NULL"))
        {
            await _ui.FillAsync(_locators.WaiverOfSubrogationExposure, _data.Resolve("{{data:class_code_frame_class_code_window_waiver_of_subrogation_exposure_175}}"));
            await _ui.PressAsync(_locators.WaiverOfSubrogationExposure, "Tab");
        }
        await _ui.FillAsync(_locators.NumberOfPartTimeEmployees, _data.Resolve("{{data:class_code_frame_class_code_window_number_of_part_time_employees_176}}"));
        await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Tab");
        await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "CLICK");
        await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Tab");
        await _ui.FillAsync(_locators.NumberOfFullTimeEmployees, _data.Resolve("{{data:class_code_frame_class_code_window_number_of_full_time_employees_177}}"));
        await _ui.PressAsync(_locators.NumberOfFullTimeEmployees, "Tab");
        await _ui.PressAsync(_locators.NumberOfFullTimeEmployees, "CLICK");
        await _ui.PressAsync(_locators.NumberOfFullTimeEmployees, "Tab");
        await _ui.ClickAsync(_locators.OKDetails);
        await _ui.WaitAsync(_locators.ClassCodeFrame, "Absent");
        await _ui.FillAsync(_locators.ClassCodeFrameClassCodeWindow, _data.Resolve(""));
    }

    // Business step: I navigate to Entity Schedule
    public async Task NavigateToEntityScheduleAsync2()
    {
        // WCNavigationLinks_672cc7Page.NavigateToEntitySchedule_0110_f2d6bdAsync
        await _ui.ClickAsync(_locators.EntityScheduleEA671);
        // EntityScheduleMain_f120d6Page.WaitForSync_0111_f2d6bdAsync
        await _ui.WaitAsync(_locators.EntityScheduleE6C9F, "Exists");
        // EntityScheduleFirstEntityInfo_409441Page.EnterFirstEntityInfo_0113_f2d6bdAsync
        await _ui.ClickAsync(_locators.Detail238D5);
        await _ui.WaitAsync(_locators.InsuredType, "Exists");
        // Random data EntityInfoFrameEntityInfoWindowFax_0113 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.EMail, _data.Resolve("{{data:entity_info_frame_entity_info_window_e_mail_186}}"));
        // Random data EntityInfoFrameEntityInfoWindowBureauNumber_0113 is generated in the StepDefinition before this PageMethod runs.
        // Random data EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault_0113 is generated in the StepDefinition before this PageMethod runs.
        await _ui.ClickAsync(_locators.OK);
        await _ui.WaitAsync(_locators.EntityInfoFrame, "Absent");
        // EntityScheduleLocationAssignment_077082Page.EnterLocationAssignmentUpToNAICS_0114_f2d6bdAsync
        await _ui.WaitAsync(_locators.AssignLocations, "Exists");
        await _ui.ClickAsync(_locators.AssignLocations);
        await _ui.WaitAsync(_locators.AssignLocation, "Exists");
        await _ui.ClickAsync(_locators.AssignLocation);
        await _ui.WaitAsync(_locators.LocationID, "Exists");
        await _ui.FillAsync(_locators.LocationID, _data.Resolve("{{data:location_assignment_entity_location_locationid_196}}"));
        await _ui.PressAsync(_locators.LocationID, "Tab");
        await _ui.PressAsync(_locators.LocationID, "Enter");
        await _ui.PressAsync(_locators.LocationID, "Tab");
        await _ui.PressAsync(_locators.LocationID, "Tab");
        await _ui.ClickAsync(_locators.LocationID);
        await _ui.FillAsync(_locators.LocationID, _data.Resolve("{{data:location_assignment_entity_location_locationid_198}}"));
        await _ui.PressAsync(_locators.LocationID, "Tab");
        await _ui.PressAsync(_locators.LocationID, "Enter");
        await _ui.PressAsync(_locators.LocationID, "Tab");
        await _ui.PressAsync(_locators.LocationID, "Tab");
        await _ui.VerifyAsync(_locators.LocationID, _data.Resolve("{{data:expected_location_assignment_entity_location_locationid_value_199}}"), "Value");
        await _ui.ClickAsync(_locators.SelectNAICSCode);
        await _ui.WaitAsync(_locators.NAICSCodeSearchValue, "Exists");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "PRE:TAB");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "Tab");
        await _ui.FillAsync(_locators.NAICSCodeSearchValue, _data.Resolve("{{data:location_assignment_entity_location_naicscodesearchvalue_203}}"));
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "CLICK");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "Tab");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "Tab");
        await _ui.ClickAsync(_locators.NAICSCodeSearchValue);
        await _ui.PressAsync(_locators.SelectAppropriateCode, "PRE:TAB");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.FillAsync(_locators.SelectAppropriateCode, _data.Resolve("{{data:location_assignment_entity_location_select_appropriate_code_206}}"));
        await _ui.PressAsync(_locators.SelectAppropriateCode, "CLICK");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Click");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        // EntityScheduleLocationAssignment_077082Page.NAICSIsSelect_0115_f2d6bdAsync
        await _ui.VerifyAsync(_locators.SelectAppropriateCode, _data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_207}}"), "value");
        await _ui.WaitAsync(_locators.LocationAssignment, "Absent");
        // EntityScheduleLocationAssignment_077082Page.EnterLocationAssignment_0116_f2d6bdAsync
        await _ui.FillAsync(_locators.SelectAppropriateCode, _data.Resolve("{{data:location_assignment_entity_location_select_appropriate_code_209}}"));
        await _ui.PressAsync(_locators.SelectAppropriateCode, "CLICK");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Click");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.PressAsync(_locators.SelectAppropriateCode, "Tab");
        await _ui.VerifyAsync(_locators.SelectAppropriateCode, _data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_210}}"), "value");
        await _ui.WaitAsync(_locators.LocationAssignment, "Absent");
        // EntityScheduleLocationAssignment_077082Page.EnterLocationAssignmentAfterNAICS_0117_f2d6bdAsync
        await _ui.VerifyAsync(_locators.SelectAppropriateCode, _data.Resolve("{{data:expected_location_assignment_entity_location_select_appropriate_code_value_212}}"), "value");
        await _ui.ClickAsync(_locators.OKFirst);
        await _ui.PressAsync(_locators.OKFirst, "Tab");
        await _ui.PressAsync(_locators.OKFirst, "Tab");
        await _ui.WaitAsync(_locators.OKSecond, "Absent");
        await _ui.ClickAsync(_locators.OK);
        await _ui.WaitAsync(_locators.LocationAssignment, "Absent");
    }

    // Business step: I complete endorsements
    public async Task CompleteEndorsementsAsync2()
    {
        // WCNavigationLinks_672cc7Page.NavigateToEndorsementsScreen_0118_f2d6bdAsync
        await _ui.ClickAsync(_locators.EndorsementsB76E9);
        // EndorsementsWaitonAddEndorsementButton_20beaePage.EndorsementsWaitonAddEndorsementButton_0119_f2d6bdAsync
        if (_data.Condition("State == \"NY\""))
        {
            await _ui.FillAsync(_locators.AreThereAnyOfficersThatShouldBeExcluded, _data.Resolve("{{data:are_there_any_officers_that_should_be_excluded_218}}"));
            await _ui.PressAsync(_locators.AreThereAnyOfficersThatShouldBeExcluded, "Tab");
            await _ui.PressAsync(_locators.AreThereAnyOfficersThatShouldBeExcluded, "CLICK");
            await _ui.PressAsync(_locators.AreThereAnyOfficersThatShouldBeExcluded, "Tab");
        }
        await _ui.WaitAsync(_locators.AddEndorsementB6452, "Exists");
    }

    // Business step: I add Designated Workplaces Exclusion
    public async Task AddDesignatedWorkplacesExclusionAsync()
    {
        // WCNavigationLinks_672cc7Page.NavigateToEndorsementsScreen_0120_f2d6bdAsync
        await _ui.ClickAsync(_locators.EndorsementsB76E9);
        // EndorsementsDesignatedWorkplacesExclusion_74668bPage.EndorsementsDesignatedWorkplacesExclusion_0121_f2d6bdAsync
        await _ui.WaitAsync(_locators.AddEndorsement9E5F4, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsement9E5F4);
        if (_data.Condition("'Endorsement Type' != NULL"))
        {
            await _ui.FillAsync(_locators.EndorsementType8DB33, _data.Resolve("{{data:endorsement_type_223}}"));
            await _ui.PressAsync(_locators.EndorsementType8DB33, "Tab");
            await _ui.PressAsync(_locators.EndorsementType8DB33, "Tab");
        }
        if (_data.Condition("City != NULL"))
        {
            await _ui.FillAsync(_locators.City, _data.Resolve("{{data:city_224}}"));
            await _ui.PressAsync(_locators.City, "Tab");
            await _ui.PressAsync(_locators.City, "Tab");
        }
        if (_data.Condition("State != NULL"))
        {
            await _ui.FillAsync(_locators.State89468, _data.Resolve("{{data:state_225}}"));
            await _ui.PressAsync(_locators.State89468, "Tab");
            await _ui.PressAsync(_locators.State89468, "Tab");
        }
        await _ui.ClickAsync(_locators.DesignatedWorkplacesExclusionOK);
    }

    // Business step: I add Partners, Officers And Others Exclusion
    public async Task AddPartnersOfficersAndOthersExclusionAsync()
    {
        // WCNavigationLinks_672cc7Page.NavigateToEndorsementsScreen_0122_f2d6bdAsync
        await _ui.ClickAsync(_locators.EndorsementsB76E9);
        // EndorsementsPartnersOfficersAndOthersExclusion_dc905ePage.EndorsementsPartnersOfficersAndOthersExclusion_0123_f2d6bdAsync
        await _ui.WaitAsync(_locators.AddEndorsementCE8DD, "Exists");
        if (_data.Condition("'Endorsement Type' != NULL"))
        {
            await _ui.FillAsync(_locators.EndorsementTypeF8D4A, _data.Resolve("{{data:endorsement_type_229}}"));
            await _ui.PressAsync(_locators.EndorsementTypeF8D4A, "Tab");
            await _ui.PressAsync(_locators.EndorsementTypeF8D4A, "Tab");
        }
        if (_data.Condition("(State!=\"MO\")&&(State!=\"ID\")"))
        {
            await _ui.ClickAsync(_locators.AddExcludedOfficerInformation);
        }
        if (_data.Condition("(Officers != NULL)&&(State!=\"MO\")&&(State!=\"ID\")"))
        {
            await _ui.FillAsync(_locators.Officers, _data.Resolve("{{data:officers_231}}"));
            await _ui.PressAsync(_locators.Officers, "Tab");
            await _ui.PressAsync(_locators.Officers, "Tab");
        }
        if (_data.Condition("('Position Held' != NULL)&&(State!=\"MO\")&&(State!=\"ID\")"))
        {
            await _ui.FillAsync(_locators.OfficersPositionHeld, _data.Resolve("{{data:officers_position_held_232}}"));
            await _ui.PressAsync(_locators.OfficersPositionHeld, "Tab");
            await _ui.PressAsync(_locators.OfficersPositionHeld, "Tab");
        }
        if (_data.Condition("(State != \"IA\")&&(State != \"IN\")&&(State!=\"MA\")&&(State!=\"ID\")&&(State!=\"MS\")&&(State!=\"KY\")&&(State!=\"SC\")&&(State!=\"MT\")&&(State!=\"KS\")&&(State!=\"ME\")"))
        {
            await _ui.ClickAsync(_locators.AddExcludedOthersInformation);
        }
        if (_data.Condition("(State != \"IA\")&&(State != \"IN\")&&(State!=\"MA\")&&(State!=\"ID\")&&(State!=\"MS\")&&(State!=\"KY\")&&(State!=\"SC\")&&(State!=\"MT\")&&(State!=\"KS\")&&(State!=\"ME\")"))
        {
            await _ui.FillAsync(_locators.OthersB1A1B, _data.Resolve("{{data:others_234}}"));
            await _ui.PressAsync(_locators.OthersB1A1B, "Tab");
            await _ui.PressAsync(_locators.OthersB1A1B, "Tab");
        }
        await _ui.ClickAsync(_locators.PartnersOfficersAndOthersExclusionOK);
        await _ui.ClickAsync(_locators.AddEndorsementCE8DD);
    }

    // Business step: I add Sole Proprietors, Partners, Officers And Others Coverage
    public async Task AddSoleProprietorsPartnersOfficersAndOthersCoverageAsync()
    {
        // WCNavigationLinks_672cc7Page.NavigateToEndorsementsScreen_0124_f2d6bdAsync
        await _ui.ClickAsync(_locators.EndorsementsB76E9);
        // EndorsementsSoleProprietorsPartnersOfficersAndOthersCoverage_cca819Page.EndorsementsSoleProprietorsPartnersOfficersAndOthersCoverage_0125_f2d6bdAsync
        await _ui.WaitAsync(_locators.AddEndorsement44E6A, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsement44E6A);
        if (_data.Condition("'Endorsement Type' != NULL"))
        {
            await _ui.FillAsync(_locators.EndorsementTypeAEC4F, _data.Resolve("{{data:endorsement_type_240}}"));
            await _ui.PressAsync(_locators.EndorsementTypeAEC4F, "Tab");
            await _ui.PressAsync(_locators.EndorsementTypeAEC4F, "Tab");
        }
        await _ui.ClickAsync(_locators.AddSoleProprietorInformation);
        if (_data.Condition("'Sole Proprietors' != NULL"))
        {
            await _ui.FillAsync(_locators.SoleProprietors, _data.Resolve("{{data:sole_proprietors_242}}"));
            await _ui.PressAsync(_locators.SoleProprietors, "Tab");
            await _ui.PressAsync(_locators.SoleProprietors, "Tab");
        }
        await _ui.ClickAsync(_locators.AddPartnerInformation);
        if (_data.Condition("Partners != NULL"))
        {
            await _ui.FillAsync(_locators.Partners, _data.Resolve("{{data:partners_244}}"));
            await _ui.PressAsync(_locators.Partners, "Tab");
            await _ui.PressAsync(_locators.Partners, "Tab");
        }
        if (_data.Condition("(State!=\"CO\")&&(State!=\"DE\")&&(State!=\"IA\")&&(State!=\"MN\")&&(State!=\"MO\")&&(State!=\"NH\")&&(State!=\"SD\")&&(State!=\"AL\")"))
        {
            await _ui.ClickAsync(_locators.AddOthersInformation);
        }
        if (_data.Condition("(State!=\"CO\")&&(State!=\"DE\")&&(State!=\"IA\")&&(State!=\"MN\")&&(State!=\"MO\")&&(State!=\"NH\")&&(State!=\"SD\")&&(State!=\"AL\")"))
        {
            await _ui.FillAsync(_locators.Others9E098, _data.Resolve("{{data:others_246}}"));
            await _ui.PressAsync(_locators.Others9E098, "Tab");
            await _ui.PressAsync(_locators.Others9E098, "Tab");
        }
        await _ui.ClickAsync(_locators.SoleProprietorsPartnersOfficersAndOthersCoverageOK);
    }

    // Business step: I complete WC UW Questions
    public async Task CompleteWCUWQuestionsAsync2()
    {
        // WCNavigationLinks_672cc7Page.NavigateToUWQuestionsWorkersCompScreen_0137_f2d6bdAsync
        await _ui.ClickAsync(_locators.UWQuestionsWorkersComp);
        // UWQuestionsWorkersComp_e0f441Page.FillOutRequiredFields_0138_f2d6bdAsync
        await _ui.WaitAsync(_locators.UpdateAnswers6FF76, "Exists");
        await _ui.PressAsync(_locators.UpdateAnswers6FF76, "PRE:TAB");
        await _ui.PressAsync(_locators.UpdateAnswers6FF76, "Tab");
        await _ui.ClickAsync(_locators.UpdateAnswers6FF76);
        await _ui.WaitAsync(_locators.ArePhysicalsRequiredAfterOffersOfEmploymentAreMade, "NotEqual");
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "PRE:TAB");
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "Tab");
        await _ui.FillAsync(_locators.ListAllPoliciesWithAmericanNational, _data.Resolve("{{data:list_all_policies_with_american_national_254}}"));
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "Tab");
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "CLICK");
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "CLICK");
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "Tab");
        await _ui.PressAsync(_locators.ListAllPoliciesWithAmericanNational, "Tab");
    }

    // Business step: I navigate to Pricing Screen
    public async Task NavigateToPricingScreenAsync3()
    {
        // WCNavigationLinks_672cc7Page.NavigateToPricingScreen_0139_f2d6bdAsync
        await _ui.ClickAsync(_locators.PricingDCBD4);
        // Pricing_a0d9bbPage.WaitForPricingScreenToLoad_0140_f2d6bdAsync
        await _ui.WaitAsync(_locators.PricingDetail, "Exists");
        // Pricing_a0d9bbPage.GoToPricingDetailNecessaryForRefreshPremiumIssue_0141_f2d6bdAsync
        await _ui.ClickAsync(_locators.PricingDetail);
        await _ui.ClickAsync(_locators.PricingDetailOK);
        // Pricing_a0d9bbPage.WaitForPricingScreenToLoad_0142_f2d6bdAsync
        await _ui.WaitAsync(_locators.PricingDetail, "Exists");
    }

    // Business step: I complete required billing information for billing
    public async Task CompleteRequiredBillingInformationForBillingAsync7()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToBillingScreen_0144_f2d6bdAsync
        await _ui.ClickAsync(_locators.Billing6ED79);
        // Billing_abaec4Page.FillOutRequiredFieldsOnBillingScreen_0145_f2d6bdAsync
        await _ui.WaitAsync(_locators.BillingD1518, "Exists");
        await _ui.FillAsync(_locators.BillType, _data.Resolve("{{data:bill_type_263}}"));
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.PressAsync(_locators.BillType, "PRE:TAB");
        await _ui.PressAsync(_locators.BillType, "Tab");
        await _ui.WaitAsync(_locators.BillType, "Equal");
        await _ui.FillAsync(_locators.PayPlan, _data.Resolve("{{data:pay_plan_266}}"));
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.PressAsync(_locators.PayPlan, "PRE:TAB");
        await _ui.PressAsync(_locators.PayPlan, "Tab");
        await _ui.WaitAsync(_locators.PayPlan, "Equal");
        await _ui.WaitAsync(_locators.EasyPay, "Exists");
        await _ui.FillAsync(_locators.EasyPay, _data.Resolve("{{data:easy_pay_270}}"));
        await _ui.PressAsync(_locators.EasyPay, "CLICK");
        await _ui.PressAsync(_locators.EasyPay, "Enter");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        await _ui.PressAsync(_locators.EasyPay, "PRE:TAB");
        await _ui.PressAsync(_locators.EasyPay, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0146_f2d6bdAsync
        await Task.Delay(1000);
    }

    // Business step: I add notepad comment
    public async Task AddNotepadCommentAsync11()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToNotePadScreen_0147_f2d6bdAsync
        await _ui.ClickAsync(_locators.Notepad);
        // NotePad_055c33Page.AddNotesRemarksToNotePad_0148_f2d6bdAsync
        await _ui.WaitAsync(_locators.NotepadHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNotesRemarks);
        await _ui.FillAsync(_locators.TextBox, _data.Resolve("Test {B[Product (LOB)]}"));
        await _ui.ClickAsync(_locators.NotePadOK);
    }

    // Business step: I complete required submission information
    public async Task CompleteRequiredSubmissionInformationAsync11()
    {
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0149_f2d6bdAsync
        await _ui.WaitAsync(_locators.Submission, "Visible");
        await _ui.ClickAsync(_locators.Submission);
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutRequiredFields_0150_f2d6bdAsync
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_281}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "CLICK");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.OrderAudit_0151_f2d6bdAsync
        await _ui.VerifyAsync(_locators.OrderAudit, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.FillOutOrderAudit_0152_f2d6bdAsync
        await _ui.FillAsync(_locators.OrderAudit, _data.Resolve("{{data:order_audit_283}}"));
        await _ui.PressAsync(_locators.OrderAudit, "Tab");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeSubmissionScreenHeaderExists_0153_f2d6bdAsync
        await _ui.VerifyAsync(_locators.SubmissionHeading, _data.Resolve("Absent"), "");
        // CommonNavigationLinks_dba56bPage.NavigateToSubmissionScreen_0154_f2d6bdAsync
        await _ui.PressAsync(_locators.Submission, "PRE:TAB");
        await _ui.PressAsync(_locators.Submission, "Tab");
        await _ui.ClickAsync(_locators.Submission);
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0155_f2d6bdAsync
        await Task.Delay(1000);
        // SubmissionRequiredAndOptionalFields_4090a9Page.WaitOnSubmissionScreenToLoad_0156_f2d6bdAsync
        await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        // TBoxWait_7ea9e1Page.N500msWaitForSyncing_0157_f2d6bdAsync
        await Task.Delay(1000);
    }

}
