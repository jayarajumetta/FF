using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class CoveragesPage
{
    private readonly CoveragesLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public CoveragesPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new CoveragesLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I verify and Fill out \[FG0055\] Employment Practices Liability Insurance Coverage Endorsement
    public async Task VerifyAndFillOutFG0055EmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync()
    {
        // FG0055EPLITable_4c4b09Page.FG0055EPLITable_0088_515771Async
        await _ui.WaitAsync(_locators.FG0055TableRowFG0055, "Exists");
        await _ui.VerifyAsync(_locators.FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement, _data.Resolve("Exists"), "");
        await _ui.ClickAsync(_locators.Detail);
        // FG0055FG0062FG0063FG0069FG0071FG0072FG0074FG0077FG0078EmploymentPracticesLiabilityInsuranceCoverageEndorsement_bb7080Page.FG0055EmploymentPracticesLiabilityInsuranceCoverageEndorsement_0089_515771Async
        await _ui.FillAsync(_locators.LimitDeductible, _data.Resolve("{{data:limit_deductible_148}}"));
        await _ui.PressAsync(_locators.LimitDeductible, "Tab");
        await _ui.FillAsync(_locators.HasTheInsuredEverHadAClaimForEmploymentPractices, _data.Resolve("{{data:has_the_insured_ever_had_a_claim_for_employment_practices_149}}"));
        await _ui.PressAsync(_locators.HasTheInsuredEverHadAClaimForEmploymentPractices, "Tab");
        await _ui.FillAsync(_locators.TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint, _data.Resolve("{{data:the_insured_and_any_executive_officer_or_owner_has_knowledge_or_information_of_any_act_error_or_omission_which_might_give_rise_to_an_epl_claim_suit_or_complaint_150}}"));
        await _ui.PressAsync(_locators.TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint, "Tab");
        await _ui.FillAsync(_locators.ThirdParty, _data.Resolve("{{data:third_party_151}}"));
        await _ui.PressAsync(_locators.ThirdParty, "Tab");
        await _ui.ClickAsync(_locators.FG0055FG0062FG0063FG0069FG0071FG0072FG0074FG0077FG0078EmploymentPracticesLiabilityInsuranceCoverageEndorsementOK);
    }

    // Business step: I complete \[CG3132\] Limited Fungi or Bacteria Coverage
    public async Task CompleteCG3132LimitedFungiOrBacteriaCoverageAsync()
    {
        // GLNavigationLinks_6f2588Page.GLNavigationLinks_0093_d65717Async
        await _ui.ClickAsync(_locators.Endorsements7572E);
        // EndorsementsMain_a2a05aPage.EndorsementsMain_0094_d65717Async
        await _ui.WaitAsync(_locators.Endorsements9626E, "Exists");
        await _ui.ClickAsync(_locators.AddEndorsement);
        // CG3132LimitedFungiOrBacteriaCoverage_262060Page.CG3132LimitedFungiOrBacteriaCoverage_0095_d65717Async
        if (_data.Condition("'Endorsement Type' != NULL"))
        {
            await _ui.FillAsync(_locators.EndorsementType, _data.Resolve("{{data:endorsement_type_158}}"));
            await _ui.PressAsync(_locators.EndorsementType, "Tab");
            await _ui.PressAsync(_locators.EndorsementType, "Tab");
        }
        await _ui.ClickAsync(_locators.CG3132LimitedFungiOrBacteriaCoverageOK);
    }

    // Business step: I select CPP Coverage \- GL
    public async Task SelectCPPCoverageGLAsync()
    {
        // PolicyInfoCPPSpecificFields_d2689aPage.PolicyInfoCPPSpecificFieldsSelectIMCheckbox_0092_d344b2Async
        if (_data.Condition("(State == \"MD\")||(State == \"NJ\")||(State == \"NY\")||(State == \"VT\")"))
        {
            await _ui.FillAsync(_locators.EstimatedPremium, _data.Resolve(""));
        }
        if (_data.Condition("'CPP LOB' == \"GL\""))
        {
            await _ui.ClickAsync(_locators.GL);
        }
    }

    // Business step: I select CPP Coverage \- CP
    public async Task SelectCPPCoverageCPAsync()
    {
        // PolicyInfoCPPSpecificFields_d2689aPage.PolicyInfoCPPSpecificFieldsSelectCPCheckbox_0093_d344b2Async
        if (_data.Condition("'CPP LOB' == \"CP\""))
        {
            await _ui.ClickAsync(_locators.CP);
        }
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0094_d344b2Async
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AZ CPP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I select CPP Coverage \- GL
    public async Task SelectCPPCoverageGLAsync2()
    {
        // PolicyInfoCPPSpecificFields_d2689aPage.PolicyInfoCPPSpecificFieldsSelectIMCheckbox_0096_aad19bAsync
        if (_data.Condition("(State == \"MD\")||(State == \"NJ\")||(State == \"NY\")||(State == \"VT\")"))
        {
            await _ui.FillAsync(_locators.EstimatedPremium, _data.Resolve(""));
        }
        if (_data.Condition("'CPP LOB' == \"GL\""))
        {
            await _ui.ClickAsync(_locators.GL);
        }
    }

    // Business step: I select CPP Coverage \- CP
    public async Task SelectCPPCoverageCPAsync2()
    {
        // PolicyInfoCPPSpecificFields_d2689aPage.PolicyInfoCPPSpecificFieldsSelectCPCheckbox_0097_aad19bAsync
        if (_data.Condition("'CPP LOB' == \"CP\""))
        {
            await _ui.ClickAsync(_locators.CP);
        }
    }

    // Business step: I select CPP Coverage \- IM
    public async Task SelectCPPCoverageIMAsync()
    {
        // PolicyInfoCPPSpecificFields_d2689aPage.PolicyInfoCPPSpecificFieldsSelectIMCheckbox_0098_aad19bAsync
        if (_data.Condition("'CPP LOB' == \"IM\""))
        {
            await _ui.ClickAsync(_locators.IM);
        }
    }

    // Business step: I complete CP Fields for policy coverage
    public async Task CompleteCPFieldsForPolicyCoverageAsync()
    {
        // PolicyCovg_0dff37Page.FillOutCPPolicyCovgFields_0104_aad19bAsync
        await _ui.FillAsync(_locators.PolicyCoverage, _data.Resolve("{{data:policy_coverage_132}}"));
        await _ui.PressAsync(_locators.PolicyCoverage, "Tab");
        if (_data.Condition("'Property Extension Endorsements' != NULL"))
        {
            await _ui.FillAsync(_locators.PropertyExtensionEndorsements, _data.Resolve("{{data:property_extension_endorsements_133}}"));
            await _ui.PressAsync(_locators.PropertyExtensionEndorsements, "CLICK");
            await _ui.PressAsync(_locators.PropertyExtensionEndorsements, "Enter");
            await _ui.PressAsync(_locators.PropertyExtensionEndorsements, "Tab");
        }
        if (_data.Condition("'Utility Services' != NULL"))
        {
            await _ui.FillAsync(_locators.UtilityServices, _data.Resolve("{{data:utility_services_134}}"));
            await _ui.PressAsync(_locators.UtilityServices, "Tab");
        }
        if (_data.Condition("Fungus != NULL"))
        {
            await _ui.FillAsync(_locators.Fungus, _data.Resolve("{{data:fungus_135}}"));
            await _ui.PressAsync(_locators.Fungus, "Tab");
        }
    }

    // Business step: I verify and Fill out \[FG0055\] Employment Practices Liability Insurance Coverage Endorsement
    public async Task VerifyAndFillOutFG0055EmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync2()
    {
        // FG0055EPLITable_4c4b09Page.FG0055EPLITable_0164_aad19bAsync
        await _ui.WaitAsync(_locators.FG0055TableRowFG0055, "Exists");
        await _ui.VerifyAsync(_locators.FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement, _data.Resolve("Exists"), "");
        await _ui.ClickAsync(_locators.Detail);
        // FG0055FG0062FG0063FG0069FG0071FG0072FG0074FG0077FG0078EmploymentPracticesLiabilityInsuranceCoverageEndorsement_bb7080Page.FG0055EmploymentPracticesLiabilityInsuranceCoverageEndorsement_0165_aad19bAsync
        await _ui.FillAsync(_locators.LimitDeductible, _data.Resolve("{{data:limit_deductible_308}}"));
        await _ui.PressAsync(_locators.LimitDeductible, "Tab");
        await _ui.FillAsync(_locators.HasTheInsuredEverHadAClaimForEmploymentPractices, _data.Resolve("{{data:has_the_insured_ever_had_a_claim_for_employment_practices_309}}"));
        await _ui.PressAsync(_locators.HasTheInsuredEverHadAClaimForEmploymentPractices, "Tab");
        await _ui.FillAsync(_locators.TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint, _data.Resolve("{{data:the_insured_and_any_executive_officer_or_owner_has_knowledge_or_information_of_any_act_error_or_omission_which_might_give_rise_to_an_epl_claim_suit_or_complaint_310}}"));
        await _ui.PressAsync(_locators.TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint, "Tab");
        await _ui.FillAsync(_locators.ThirdParty, _data.Resolve("{{data:third_party_311}}"));
        await _ui.PressAsync(_locators.ThirdParty, "Tab");
        await _ui.ClickAsync(_locators.FG0055FG0062FG0063FG0069FG0071FG0072FG0074FG0077FG0078EmploymentPracticesLiabilityInsuranceCoverageEndorsementOK);
    }

    // Business step: I add Accounts Receivable Coverage
    public async Task AddAccountsReceivableCoverageAsync()
    {
        // PolicyCovgMain_ddd7eePage.PolicyCovgMain_0189_aad19bAsync
        await _ui.WaitAsync(_locators.PolicyCovgF9E58, "Exists");
        await _ui.FillAsync(_locators.CoverageFormToBeAdded, _data.Resolve("{{data:coverage_form_to_be_added_356}}"));
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Enter");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.ClickAsync(_locators.AddCoverageForm);
        // PolicyCovgAccountsReceivable_0eadcePage.PolicyCovgAccountsReceivable_0190_aad19bAsync
        await _ui.FillAsync(_locators.Description, _data.Resolve("{{data:description_358}}"));
        await _ui.PressAsync(_locators.Description, "Tab");
        await _ui.PressAsync(_locators.Description, "CLICK");
        await _ui.PressAsync(_locators.Description, "Enter");
        await _ui.FillAsync(_locators.Coinsurance, _data.Resolve("{{data:coinsurance_359}}"));
        await _ui.PressAsync(_locators.Coinsurance, "Tab");
        await _ui.PressAsync(_locators.Coinsurance, "CLICK");
        await _ui.FillAsync(_locators.AwayFromPremisesLmt, _data.Resolve("{{data:away_from_premises_lmt_360}}"));
        await _ui.PressAsync(_locators.AwayFromPremisesLmt, "Tab");
        await _ui.PressAsync(_locators.AwayFromPremisesLmt, "CLICK");
        await _ui.FillAsync(_locators.AwayFromPremisesDesc, _data.Resolve("{{data:away_from_premises_desc_361}}"));
        await _ui.PressAsync(_locators.AwayFromPremisesDesc, "Tab");
        await _ui.PressAsync(_locators.AwayFromPremisesDesc, "CLICK");
        await _ui.ClickAsync(_locators.PolicyCovgAccountsReceivableOK);
    }

    // Business step: I complete CP Fields for policy coverage
    public async Task CompleteCPFieldsForPolicyCoverageAsync2()
    {
        // PolicyCovg_0dff37Page.FillOutCPPolicyCovgFields_0103_677267Async
        await _ui.FillAsync(_locators.PolicyCoverage, _data.Resolve("{{data:policy_coverage_148}}"));
        await _ui.PressAsync(_locators.PolicyCoverage, "Tab");
        if (_data.Condition("'Property Extension Endorsements' != NULL"))
        {
            await _ui.FillAsync(_locators.PropertyExtensionEndorsements, _data.Resolve("{{data:property_extension_endorsements_149}}"));
            await _ui.PressAsync(_locators.PropertyExtensionEndorsements, "CLICK");
            await _ui.PressAsync(_locators.PropertyExtensionEndorsements, "Enter");
            await _ui.PressAsync(_locators.PropertyExtensionEndorsements, "Tab");
        }
        if (_data.Condition("'Utility Services' != NULL"))
        {
            await _ui.FillAsync(_locators.UtilityServices, _data.Resolve("{{data:utility_services_150}}"));
            await _ui.PressAsync(_locators.UtilityServices, "Tab");
        }
        if (_data.Condition("Fungus != NULL"))
        {
            await _ui.FillAsync(_locators.Fungus, _data.Resolve(""));
        }
    }

    // Business step: I add Accounts Receivable Coverage
    public async Task AddAccountsReceivableCoverageAsync2()
    {
        // IMNavigationLinks_7abd8aPage.IMNavigationLinks_0099_a8e5f5Async
        await _ui.ClickAsync(_locators.PolicyCovgED95C);
        // PolicyCovgMain_ddd7eePage.PolicyCovgMain_0100_a8e5f5Async
        await _ui.WaitAsync(_locators.PolicyCovgF9E58, "Exists");
        await _ui.FillAsync(_locators.CoverageFormToBeAdded, _data.Resolve("{{data:coverage_form_to_be_added_134}}"));
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "CLICK");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Enter");
        await _ui.PressAsync(_locators.CoverageFormToBeAdded, "Tab");
        await _ui.ClickAsync(_locators.AddCoverageForm);
        // PolicyCovgAccountsReceivable_0eadcePage.PolicyCovgAccountsReceivable_0101_a8e5f5Async
        await _ui.FillAsync(_locators.Description, _data.Resolve("{{data:description_136}}"));
        await _ui.PressAsync(_locators.Description, "Tab");
        await _ui.PressAsync(_locators.Description, "CLICK");
        await _ui.PressAsync(_locators.Description, "Enter");
        await _ui.FillAsync(_locators.Coinsurance, _data.Resolve("{{data:coinsurance_137}}"));
        await _ui.PressAsync(_locators.Coinsurance, "Tab");
        await _ui.PressAsync(_locators.Coinsurance, "CLICK");
        await _ui.FillAsync(_locators.AwayFromPremisesLmt, _data.Resolve("{{data:away_from_premises_lmt_138}}"));
        await _ui.PressAsync(_locators.AwayFromPremisesLmt, "Tab");
        await _ui.PressAsync(_locators.AwayFromPremisesLmt, "CLICK");
        await _ui.FillAsync(_locators.AwayFromPremisesDesc, _data.Resolve("{{data:away_from_premises_desc_139}}"));
        await _ui.PressAsync(_locators.AwayFromPremisesDesc, "Tab");
        await _ui.PressAsync(_locators.AwayFromPremisesDesc, "CLICK");
        await _ui.ClickAsync(_locators.PolicyCovgAccountsReceivableOK);
    }

}
