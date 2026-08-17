using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class PolicyWorkflowPage
{
    private readonly BrowserSession _browser;

    private readonly PolicyWorkflowLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public PolicyWorkflowPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _browser = browser;

        _locators = new PolicyWorkflowLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I select or create the policy client
    public async Task SelectOrCreateThePolicyClientAsync()
    {
        // EQClientSelection_612f8cPage.ClientSelectionEnterClientInfoOfNewOrExisitingClients_0013_d06ed6Async
        await _ui.WaitAsync(_locators.LblClientInfo, "Exists");
        await _ui.VerifyAsync(_locators.LblClientInfo, _data.Resolve("{{data:expected_lbl_client_info_5}}"), "");
        await _ui.FillAsync(_locators.TxtFirst, _data.Get("AL_ClientData.First Name"));
        await _ui.FillAsync(_locators.TxtLast, _data.Get("AL_ClientData.Last Name"));
        await _ui.WaitAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch, "Exists");
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        await _ui.WaitAsync(_locators.BtnCreateNewClient, "Exists");
        await _ui.ClickAsync(_locators.BtnCreateNewClient);
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.SetStateName_0014_d06ed6Async
        _data.Set("StateName", _data.Resolve("{{data:statename}}"));
        _data.Set("State", _data.Get("State Abbreviation"));
    }

    // Business step: I select or create the policy client
    public async Task SelectOrCreateThePolicyClientAsync2()
    {
        // EQClientSelection_612f8cPage.ClientSelectionEnterClientInfoOfNewOrExisitingClients_0013_8f9ff6Async
        await _ui.WaitAsync(_locators.LblClientInfo, "Exists");
        await _ui.VerifyAsync(_locators.LblClientInfo, _data.Resolve("{{data:expected_lbl_client_info_5}}"), "");
        await _ui.FillAsync(_locators.TxtFirst, _data.Get("AL_ClientData.First Name"));
        await _ui.FillAsync(_locators.TxtLast, _data.Get("AL_ClientData.Last Name"));
        await _ui.WaitAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch, "Exists");
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        await _ui.WaitAsync(_locators.BtnCreateNewClient, "Exists");
        await _ui.ClickAsync(_locators.BtnCreateNewClient);
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.SetStateName_0014_8f9ff6Async
        _data.Set("StateName", _data.Resolve("{{data:statename}}"));
        _data.Set("State", _data.Get("State Abbreviation"));
    }

    // Business step: I open the configured policy application
    public async Task OpenTheConfiguredPolicyApplicationAsync()
    {
        // EQOpenUrl_bc49e2Page.EQOpenUrl_0036_8f9ff6Async
        if (_data.Condition("If > Then"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I complete auto AddlCov PIP
    public async Task CompleteAutoAddlCovPIPAsync()
    {
        // EQPersonalInjuryProtectionSectionNew_834ca4Page.EQPersonalInjuryProtectionSection_0138_8f9ff6Async
        if (_data.Condition("'All HH Members 65 or Pension' != NULL"))
        {
            await _ui.ClickAsync(_locators.HouseholdMembersAge65OrReceivingPension);
        }
        if (_data.Condition("'PIP Limit' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPLimit);
        }
        if (_data.Condition("'PIP Deductible' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPDeductible);
        }
        if (_data.Condition("'Additional PIP' != NULL"))
        {
            await _ui.ClickAsync(_locators.AdditionalPIP);
        }
        if (_data.Condition("'PIP Stacking' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPStacking);
        }
        if (_data.Condition("'Extra PIP Option' != NULL"))
        {
            await _ui.SelectAsync(_locators.ExtraPIPOption, _data.Resolve(""));
        }
        if (_data.Condition("'Auto Health Insurer' != NULL"))
        {
            await _ui.ClickAsync(_locators.AutoHealthInsurer);
        }
        if (_data.Condition("'Medical Expense Elimination' != NULL"))
        {
            await _ui.ClickAsync(_locators.MedicalExpenseElimination);
        }
        if (_data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
            await _ui.SelectAsync(_locators.WorkLossNo, _data.Resolve(""));
        }
        if (_data.Condition("'Broadened PIP' != NULL"))
        {
            await _ui.ClickAsync(_locators.BroadenedPIP);
        }
        if (_data.Condition("'Additional Death Benefit' != NULL"))
        {
            await _ui.ClickAsync(_locators.AdditionalDeathBenefit);
        }
        if (_data.Condition("'Waiver of Income Loss' != NULL"))
        {
            await _ui.ClickAsync(_locators.WaiverOfIncomeLoss);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0139_8f9ff6Async
        _data.Set("UMPD/UIMPD_V1", _data.Get("UMPD/UIMPD_V1"));
        _data.Set("UMPD Coverage_V1", _data.Get("UMPD Coverage_V1"));
        _data.Set("UMPD More Options Coverages_V1", _data.Get("UMPD More Options Coverages_V1"));
        _data.Set("UIMPD Coverage_V1", _data.Get("UIMPD Coverage_V1"));
        _data.Set("Rental Reimbursement Coverage_V1", _data.Resolve("{{data:rental_reimbursement_coverage_v1}}"));
        _data.Set("Theft Deductible_V1", _data.Get("Theft Deductible_V1"));
        _data.Set("Roadside Assistance Coverage_V1", _data.Resolve("{{data:roadside_assistance_coverage_v1}}"));
        _data.Set("UMPD/UIMPD_V2", _data.Get("UMPD/UIMPD_V2"));
        _data.Set("UMPD Coverage_V2", _data.Get("UMPD Coverage_V2"));
        _data.Set("UMPD More Options Coverages_V2", _data.Get("UMPD More Options Coverages_V2"));
        _data.Set("UIMPD Coverage_V2", _data.Get("UIMPD Coverage_V2"));
        _data.Set("Rental Reimbursement Coverage_V2", _data.Resolve("{{data:rental_reimbursement_coverage_v2}}"));
        _data.Set("Theft Deductible_V2", _data.Get("Theft Deductible_V2"));
        _data.Set("Roadside Assistance Coverage_V2", _data.Resolve("{{data:roadside_assistance_coverage_v2}}"));
        _data.Set("UMPD/UIMPD_V3", _data.Get("UMPD/UIMPD_V3"));
        _data.Set("UMPD Coverage_V3", _data.Get("UMPD Coverage_V3"));
        _data.Set("UMPD More Options Coverages_V3", _data.Get("UMPD More Options Coverages_V3"));
        _data.Set("UIMPD Coverage_V3", _data.Get("UIMPD Coverage_V3"));
        _data.Set("Rental Reimbursement Coverage_V3", _data.Get("Rental Reimbursement Coverage_V3"));
        _data.Set("Theft Deductible_V3", _data.Get("Theft Deductible_V3"));
        _data.Set("Roadside Assistance Coverage_V3", _data.Get("Roadside Assistance Coverage_V3"));
        _data.Set("UMPD/UIMPD_V4", _data.Get("UMPD/UIMPD_V4"));
        _data.Set("UMPD Coverage_V4", _data.Get("UMPD Coverage_V4"));
        _data.Set("UMPD More Options Coverages_V4", _data.Get("UMPD More Options Coverages_V4"));
        _data.Set("UIMPD Coverage_V4", _data.Get("UIMPD Coverage_V4"));
        _data.Set("Rental Reimbursement Coverage_V4", _data.Get("Rental Reimbursement Coverage_V4"));
        _data.Set("Theft Deductible_V4", _data.Get("Theft Deductible_V4"));
        _data.Set("Roadside Assistance Coverage_V4", _data.Get("Roadside Assistance Coverage_V4"));
        _data.Set("Cycle Accessories_V1", _data.Get("Cycle Accessories_V1"));
        _data.Set("Original Parts_V1", _data.Get("Original Parts_V1"));
        _data.Set("Cycle Accessories_V2", _data.Get("Cycle Accessories_V2"));
        _data.Set("Original Parts_V2", _data.Get("Original Parts_V2"));
        _data.Set("Cycle Accessories_V3", _data.Get("Cycle Accessories_V3"));
        _data.Set("Original Parts_V3", _data.Get("Original Parts_V3"));
        _data.Set("Cycle Accessories_V4", _data.Get("Cycle Accessories_V4"));
        _data.Set("Original Parts_V4", _data.Get("Original Parts_V4"));
    }

    // Business step: I open the configured policy application for openurl
    public async Task OpenTheConfiguredPolicyApplicationForOpenurlAsync()
    {
        // EQOpenUrl_bc49e2Page.EQOpenUrl_0175_8f9ff6Async
        if (_data.Condition("If Referral Button > Then"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I open the configured policy application for approve in express ui
    public async Task OpenTheConfiguredPolicyApplicationForApproveInExpressUiAsync()
    {
        // OpenUrl_677fdaPage.OpenUrl_0190_8f9ff6Async
        if (_data.Condition("If Correction Needed > Then go to Express to bypass L9"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I select or create the policy client
    public async Task SelectOrCreateThePolicyClientAsync3()
    {
        // EQClientSelection_612f8cPage.ClientSelectionEnterClientInfoOfNewOrExisitingClients_0013_b91c7dAsync
        await _ui.WaitAsync(_locators.LblClientInfo, "Exists");
        await _ui.VerifyAsync(_locators.LblClientInfo, _data.Resolve("{{data:expected_lbl_client_info_5}}"), "");
        await _ui.FillAsync(_locators.TxtFirst, _data.Get("AL_ClientData.First Name"));
        await _ui.FillAsync(_locators.TxtLast, _data.Get("AL_ClientData.Last Name"));
        await _ui.WaitAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch, "Exists");
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        await _ui.WaitAsync(_locators.BtnCreateNewClient, "Exists");
        await _ui.ClickAsync(_locators.BtnCreateNewClient);
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.SetStateName_0014_b91c7dAsync
        _data.Set("StateName", _data.Resolve("{{data:statename}}"));
        _data.Set("State", _data.Get("State Abbreviation"));
    }

    // Business step: I select or create the policy client
    public async Task SelectOrCreateThePolicyClientAsync4()
    {
        // EQClientSelection_612f8cPage.ClientSelectionEnterClientInfoOfNewOrExisitingClients_0013_8f5301Async
        await _ui.WaitAsync(_locators.LblClientInfo, "Exists");
        await _ui.VerifyAsync(_locators.LblClientInfo, _data.Resolve("{{data:expected_lbl_client_info_5}}"), "");
        await _ui.FillAsync(_locators.TxtFirst, _data.Get("First Name"));
        await _ui.FillAsync(_locators.TxtLast, _data.Get("Last Name"));
        await _ui.WaitAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch, "Exists");
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        await _ui.WaitAsync(_locators.BtnCreateNewClient, "Exists");
        await _ui.ClickAsync(_locators.BtnCreateNewClient);
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.SetStateName_0014_8f5301Async
        _data.Set("StateName", _data.Resolve("{{data:statename}}"));
        _data.Set("State", _data.Get("State Abbreviation"));
    }

    // Business step: I open the configured policy application
    public async Task OpenTheConfiguredPolicyApplicationAsync2()
    {
        // EQOpenUrl_bc49e2Page.EQOpenUrl_0036_8f5301Async
        if (_data.Condition("If > Then"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I complete auto AddlCov PIP
    public async Task CompleteAutoAddlCovPIPAsync2()
    {
        // EQPersonalInjuryProtectionSectionNew_834ca4Page.EQPersonalInjuryProtectionSection_0150_8f5301Async
        if (_data.Condition("'All HH Members 65 or Pension' != NULL"))
        {
            await _ui.ClickAsync(_locators.HouseholdMembersAge65OrReceivingPension);
        }
        if (_data.Condition("'PIP Limit' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPLimit);
        }
        if (_data.Condition("'PIP Deductible' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPDeductible);
        }
        if (_data.Condition("'Additional PIP' != NULL"))
        {
            await _ui.ClickAsync(_locators.AdditionalPIP);
        }
        if (_data.Condition("'PIP Stacking' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPStacking);
        }
        if (_data.Condition("'Extra PIP Option' != NULL"))
        {
            await _ui.SelectAsync(_locators.ExtraPIPOption, _data.Resolve(""));
        }
        if (_data.Condition("'Auto Health Insurer' != NULL"))
        {
            await _ui.ClickAsync(_locators.AutoHealthInsurer);
        }
        if (_data.Condition("'Medical Expense Elimination' != NULL"))
        {
            await _ui.ClickAsync(_locators.MedicalExpenseElimination);
        }
        if (_data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
            await _ui.SelectAsync(_locators.WorkLossNo, _data.Resolve(""));
        }
        if (_data.Condition("'Broadened PIP' != NULL"))
        {
            await _ui.ClickAsync(_locators.BroadenedPIP);
        }
        if (_data.Condition("'Additional Death Benefit' != NULL"))
        {
            await _ui.ClickAsync(_locators.AdditionalDeathBenefit);
        }
        if (_data.Condition("'Waiver of Income Loss' != NULL"))
        {
            await _ui.ClickAsync(_locators.WaiverOfIncomeLoss);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0151_8f5301Async
        _data.Set("UMPD/UIMPD_V1", _data.Get("UMPD/UIMPD_V1"));
        _data.Set("UMPD Coverage_V1", _data.Get("UMPD Coverage_V1"));
        _data.Set("UMPD More Options Coverages_V1", _data.Get("UMPD More Options Coverages_V1"));
        _data.Set("UIMPD Coverage_V1", _data.Get("UIMPD Coverage_V1"));
        _data.Set("Rental Reimbursement Coverage_V1", _data.Resolve("{{data:rental_reimbursement_coverage_v1}}"));
        _data.Set("Theft Deductible_V1", _data.Get("Theft Deductible_V1"));
        _data.Set("Roadside Assistance Coverage_V1", _data.Resolve("{{data:roadside_assistance_coverage_v1}}"));
        _data.Set("UMPD/UIMPD_V2", _data.Get("UMPD/UIMPD_V2"));
        _data.Set("UMPD Coverage_V2", _data.Get("UMPD Coverage_V2"));
        _data.Set("UMPD More Options Coverages_V2", _data.Get("UMPD More Options Coverages_V2"));
        _data.Set("UIMPD Coverage_V2", _data.Get("UIMPD Coverage_V2"));
        _data.Set("Rental Reimbursement Coverage_V2", _data.Resolve("{{data:rental_reimbursement_coverage_v2}}"));
        _data.Set("Theft Deductible_V2", _data.Get("Theft Deductible_V2"));
        _data.Set("Roadside Assistance Coverage_V2", _data.Resolve("{{data:roadside_assistance_coverage_v2}}"));
        _data.Set("UMPD/UIMPD_V3", _data.Get("UMPD/UIMPD_V3"));
        _data.Set("UMPD Coverage_V3", _data.Get("UMPD Coverage_V3"));
        _data.Set("UMPD More Options Coverages_V3", _data.Get("UMPD More Options Coverages_V3"));
        _data.Set("UIMPD Coverage_V3", _data.Get("UIMPD Coverage_V3"));
        _data.Set("Rental Reimbursement Coverage_V3", _data.Get("Rental Reimbursement Coverage_V3"));
        _data.Set("Theft Deductible_V3", _data.Get("Theft Deductible_V3"));
        _data.Set("Roadside Assistance Coverage_V3", _data.Get("Roadside Assistance Coverage_V3"));
        _data.Set("UMPD/UIMPD_V4", _data.Get("UMPD/UIMPD_V4"));
        _data.Set("UMPD Coverage_V4", _data.Get("UMPD Coverage_V4"));
        _data.Set("UMPD More Options Coverages_V4", _data.Get("UMPD More Options Coverages_V4"));
        _data.Set("UIMPD Coverage_V4", _data.Get("UIMPD Coverage_V4"));
        _data.Set("Rental Reimbursement Coverage_V4", _data.Get("Rental Reimbursement Coverage_V4"));
        _data.Set("Theft Deductible_V4", _data.Get("Theft Deductible_V4"));
        _data.Set("Roadside Assistance Coverage_V4", _data.Get("Roadside Assistance Coverage_V4"));
        _data.Set("Cycle Accessories_V1", _data.Get("Cycle Accessories_V1"));
        _data.Set("Original Parts_V1", _data.Get("Original Parts_V1"));
        _data.Set("Cycle Accessories_V2", _data.Get("Cycle Accessories_V2"));
        _data.Set("Original Parts_V2", _data.Get("Original Parts_V2"));
        _data.Set("Cycle Accessories_V3", _data.Get("Cycle Accessories_V3"));
        _data.Set("Original Parts_V3", _data.Get("Original Parts_V3"));
        _data.Set("Cycle Accessories_V4", _data.Get("Cycle Accessories_V4"));
        _data.Set("Original Parts_V4", _data.Get("Original Parts_V4"));
    }

    // Business step: I open the configured policy application for openurl
    public async Task OpenTheConfiguredPolicyApplicationForOpenurlAsync2()
    {
        // EQOpenUrl_bc49e2Page.EQOpenUrl_0187_8f5301Async
        if (_data.Condition("If Referral Button > Then"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I select or create the policy client
    public async Task SelectOrCreateThePolicyClientAsync5()
    {
        // EQClientSelection_612f8cPage.ClientSelectionEnterClientInfoOfNewOrExisitingClients_0013_e2e0d7Async
        await _ui.WaitAsync(_locators.LblClientInfo, "Exists");
        await _ui.VerifyAsync(_locators.LblClientInfo, _data.Resolve("{{data:expected_lbl_client_info_5}}"), "");
        await _ui.FillAsync(_locators.TxtFirst, _data.Get("AL_ClientData.First Name"));
        await _ui.FillAsync(_locators.TxtLast, _data.Get("AL_ClientData.Last Name"));
        await _ui.WaitAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch, "Exists");
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        await _ui.WaitAsync(_locators.BtnCreateNewClient, "Exists");
        await _ui.ClickAsync(_locators.BtnCreateNewClient);
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.SetStateName_0014_e2e0d7Async
        _data.Set("StateName", _data.Resolve("{{data:statename}}"));
        _data.Set("State", _data.Resolve("{{data:state}}"));
    }

    // Business step: I open the configured policy application
    public async Task OpenTheConfiguredPolicyApplicationAsync3()
    {
        // EQOpenUrl_bc49e2Page.EQOpenUrl_0036_e2e0d7Async
        if (_data.Condition("If > Then"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I complete auto AddlCov PIP
    public async Task CompleteAutoAddlCovPIPAsync3()
    {
        // EQPersonalInjuryProtectionSectionNew_834ca4Page.EQPersonalInjuryProtectionSection_0147_e2e0d7Async
        if (_data.Condition("'All HH Members 65 or Pension' != NULL"))
        {
            await _ui.ClickAsync(_locators.HouseholdMembersAge65OrReceivingPension);
        }
        if (_data.Condition("'PIP Limit' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPLimit);
        }
        if (_data.Condition("'PIP Deductible' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPDeductible);
        }
        if (_data.Condition("'Additional PIP' != NULL"))
        {
            await _ui.ClickAsync(_locators.AdditionalPIP);
        }
        if (_data.Condition("'PIP Stacking' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPStacking);
        }
        if (_data.Condition("'Extra PIP Option' != NULL"))
        {
            await _ui.SelectAsync(_locators.ExtraPIPOption, _data.Resolve(""));
        }
        if (_data.Condition("'Auto Health Insurer' != NULL"))
        {
            await _ui.ClickAsync(_locators.AutoHealthInsurer);
        }
        if (_data.Condition("'Medical Expense Elimination' != NULL"))
        {
            await _ui.ClickAsync(_locators.MedicalExpenseElimination);
        }
        if (_data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
            await _ui.SelectAsync(_locators.WorkLossNo, _data.Resolve(""));
        }
        if (_data.Condition("'Broadened PIP' != NULL"))
        {
            await _ui.ClickAsync(_locators.BroadenedPIP);
        }
        if (_data.Condition("'Additional Death Benefit' != NULL"))
        {
            await _ui.ClickAsync(_locators.AdditionalDeathBenefit);
        }
        if (_data.Condition("'Waiver of Income Loss' != NULL"))
        {
            await _ui.ClickAsync(_locators.WaiverOfIncomeLoss);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0148_e2e0d7Async
        _data.Set("UMPD/UIMPD_V1", _data.Get("UMPD/UIMPD_V1"));
        _data.Set("UMPD Coverage_V1", _data.Get("UMPD Coverage_V1"));
        _data.Set("UMPD More Options Coverages_V1", _data.Get("UMPD More Options Coverages_V1"));
        _data.Set("UIMPD Coverage_V1", _data.Get("UIMPD Coverage_V1"));
        _data.Set("Rental Reimbursement Coverage_V1", _data.Get("Rental Reimbursement Coverage_V1"));
        _data.Set("Theft Deductible_V1", _data.Get("Theft Deductible_V1"));
        _data.Set("Roadside Assistance Coverage_V1", _data.Resolve("{{data:roadside_assistance_coverage_v1}}"));
        _data.Set("UMPD/UIMPD_V2", _data.Get("UMPD/UIMPD_V2"));
        _data.Set("UMPD Coverage_V2", _data.Get("UMPD Coverage_V2"));
        _data.Set("UMPD More Options Coverages_V2", _data.Get("UMPD More Options Coverages_V2"));
        _data.Set("UIMPD Coverage_V2", _data.Get("UIMPD Coverage_V2"));
        _data.Set("Rental Reimbursement Coverage_V2", _data.Get("Rental Reimbursement Coverage_V2"));
        _data.Set("Theft Deductible_V2", _data.Get("Theft Deductible_V2"));
        _data.Set("Roadside Assistance Coverage_V2", _data.Resolve("{{data:roadside_assistance_coverage_v2}}"));
        _data.Set("UMPD/UIMPD_V3", _data.Get("UMPD/UIMPD_V3"));
        _data.Set("UMPD Coverage_V3", _data.Get("UMPD Coverage_V3"));
        _data.Set("UMPD More Options Coverages_V3", _data.Get("UMPD More Options Coverages_V3"));
        _data.Set("UIMPD Coverage_V3", _data.Get("UIMPD Coverage_V3"));
        _data.Set("Rental Reimbursement Coverage_V3", _data.Get("Rental Reimbursement Coverage_V3"));
        _data.Set("Theft Deductible_V3", _data.Get("Theft Deductible_V3"));
        _data.Set("Roadside Assistance Coverage_V3", _data.Resolve("{{data:roadside_assistance_coverage_v3}}"));
        _data.Set("UMPD/UIMPD_V4", _data.Get("UMPD/UIMPD_V4"));
        _data.Set("UMPD Coverage_V4", _data.Get("UMPD Coverage_V4"));
        _data.Set("UMPD More Options Coverages_V4", _data.Get("UMPD More Options Coverages_V4"));
        _data.Set("UIMPD Coverage_V4", _data.Get("UIMPD Coverage_V4"));
        _data.Set("Rental Reimbursement Coverage_V4", _data.Get("Rental Reimbursement Coverage_V4"));
        _data.Set("Theft Deductible_V4", _data.Get("Theft Deductible_V4"));
        _data.Set("Roadside Assistance Coverage_V4", _data.Get("Roadside Assistance Coverage_V4"));
        _data.Set("Cycle Accessories_V1", _data.Get("Cycle Accessories_V1"));
        _data.Set("Original Parts_V1", _data.Get("Original Parts_V1"));
        _data.Set("Cycle Accessories_V2", _data.Get("Cycle Accessories_V2"));
        _data.Set("Original Parts_V2", _data.Get("Original Parts_V2"));
        _data.Set("Cycle Accessories_V3", _data.Get("Cycle Accessories_V3"));
        _data.Set("Original Parts_V3", _data.Get("Original Parts_V3"));
        _data.Set("Cycle Accessories_V4", _data.Get("Cycle Accessories_V4"));
        _data.Set("Original Parts_V4", _data.Get("Original Parts_V4"));
    }

    // Business step: I open the configured policy application for openurl
    public async Task OpenTheConfiguredPolicyApplicationForOpenurlAsync3()
    {
        // OpenUrl_677fdaPage.OpenUrl_0167_e2e0d7Async
        if (_data.Condition("If Correction Needed > Then go to Express to bypass L9"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I select or create the policy client
    public async Task SelectOrCreateThePolicyClientAsync6()
    {
        // EQClientSelection_612f8cPage.ClientSelectionEnterClientInfoOfNewOrExisitingClients_0013_bafd4aAsync
        await _ui.WaitAsync(_locators.LblClientInfo, "Exists");
        await _ui.VerifyAsync(_locators.LblClientInfo, _data.Resolve("{{data:expected_lbl_client_info_5}}"), "");
        await _ui.FillAsync(_locators.TxtFirst, _data.Get("AL_ClientData.First Name"));
        await _ui.FillAsync(_locators.TxtLast, _data.Get("AL_ClientData.Last Name"));
        await _ui.WaitAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch, "Exists");
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        await _ui.WaitAsync(_locators.BtnCreateNewClient, "Exists");
        await _ui.ClickAsync(_locators.BtnCreateNewClient);
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.SetStateName_0014_bafd4aAsync
        _data.Set("StateName", _data.Resolve("{{data:statename}}"));
        _data.Set("State", _data.Resolve("{{data:state}}"));
    }

    // Business step: I open the configured policy application
    public async Task OpenTheConfiguredPolicyApplicationAsync4()
    {
        // EQOpenUrl_bc49e2Page.EQOpenUrl_0036_bafd4aAsync
        if (_data.Condition("If > Then"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I complete auto AddlCov PIP
    public async Task CompleteAutoAddlCovPIPAsync4()
    {
        // EQPersonalInjuryProtectionSectionNew_834ca4Page.EQPersonalInjuryProtectionSection_0147_bafd4aAsync
        if (_data.Condition("'All HH Members 65 or Pension' != NULL"))
        {
            await _ui.ClickAsync(_locators.HouseholdMembersAge65OrReceivingPension);
        }
        if (_data.Condition("'PIP Limit' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPLimit);
        }
        if (_data.Condition("'PIP Deductible' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPDeductible);
        }
        if (_data.Condition("'Additional PIP' != NULL"))
        {
            await _ui.ClickAsync(_locators.AdditionalPIP);
        }
        if (_data.Condition("'PIP Stacking' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPStacking);
        }
        if (_data.Condition("'Extra PIP Option' != NULL"))
        {
            await _ui.SelectAsync(_locators.ExtraPIPOption, _data.Resolve(""));
        }
        if (_data.Condition("'Auto Health Insurer' != NULL"))
        {
            await _ui.ClickAsync(_locators.AutoHealthInsurer);
        }
        if (_data.Condition("'Medical Expense Elimination' != NULL"))
        {
            await _ui.ClickAsync(_locators.MedicalExpenseElimination);
        }
        if (_data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
            await _ui.SelectAsync(_locators.WorkLossNo, _data.Resolve(""));
        }
        if (_data.Condition("'Broadened PIP' != NULL"))
        {
            await _ui.ClickAsync(_locators.BroadenedPIP);
        }
        if (_data.Condition("'Additional Death Benefit' != NULL"))
        {
            await _ui.ClickAsync(_locators.AdditionalDeathBenefit);
        }
        if (_data.Condition("'Waiver of Income Loss' != NULL"))
        {
            await _ui.ClickAsync(_locators.WaiverOfIncomeLoss);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0148_bafd4aAsync
        _data.Set("UMPD/UIMPD_V1", _data.Get("UMPD/UIMPD_V1"));
        _data.Set("UMPD Coverage_V1", _data.Get("UMPD Coverage_V1"));
        _data.Set("UMPD More Options Coverages_V1", _data.Get("UMPD More Options Coverages_V1"));
        _data.Set("UIMPD Coverage_V1", _data.Get("UIMPD Coverage_V1"));
        _data.Set("Rental Reimbursement Coverage_V1", _data.Get("Rental Reimbursement Coverage_V1"));
        _data.Set("Theft Deductible_V1", _data.Get("Theft Deductible_V1"));
        _data.Set("Roadside Assistance Coverage_V1", _data.Resolve("{{data:roadside_assistance_coverage_v1}}"));
        _data.Set("UMPD/UIMPD_V2", _data.Get("UMPD/UIMPD_V2"));
        _data.Set("UMPD Coverage_V2", _data.Get("UMPD Coverage_V2"));
        _data.Set("UMPD More Options Coverages_V2", _data.Get("UMPD More Options Coverages_V2"));
        _data.Set("UIMPD Coverage_V2", _data.Get("UIMPD Coverage_V2"));
        _data.Set("Rental Reimbursement Coverage_V2", _data.Get("Rental Reimbursement Coverage_V2"));
        _data.Set("Theft Deductible_V2", _data.Get("Theft Deductible_V2"));
        _data.Set("Roadside Assistance Coverage_V2", _data.Resolve("{{data:roadside_assistance_coverage_v2}}"));
        _data.Set("UMPD/UIMPD_V3", _data.Get("UMPD/UIMPD_V3"));
        _data.Set("UMPD Coverage_V3", _data.Get("UMPD Coverage_V3"));
        _data.Set("UMPD More Options Coverages_V3", _data.Get("UMPD More Options Coverages_V3"));
        _data.Set("UIMPD Coverage_V3", _data.Get("UIMPD Coverage_V3"));
        _data.Set("Rental Reimbursement Coverage_V3", _data.Get("Rental Reimbursement Coverage_V3"));
        _data.Set("Theft Deductible_V3", _data.Get("Theft Deductible_V3"));
        _data.Set("Roadside Assistance Coverage_V3", _data.Resolve("{{data:roadside_assistance_coverage_v3}}"));
        _data.Set("UMPD/UIMPD_V4", _data.Get("UMPD/UIMPD_V4"));
        _data.Set("UMPD Coverage_V4", _data.Get("UMPD Coverage_V4"));
        _data.Set("UMPD More Options Coverages_V4", _data.Get("UMPD More Options Coverages_V4"));
        _data.Set("UIMPD Coverage_V4", _data.Get("UIMPD Coverage_V4"));
        _data.Set("Rental Reimbursement Coverage_V4", _data.Get("Rental Reimbursement Coverage_V4"));
        _data.Set("Theft Deductible_V4", _data.Get("Theft Deductible_V4"));
        _data.Set("Roadside Assistance Coverage_V4", _data.Get("Roadside Assistance Coverage_V4"));
        _data.Set("Cycle Accessories_V1", _data.Get("Cycle Accessories_V1"));
        _data.Set("Original Parts_V1", _data.Get("Original Parts_V1"));
        _data.Set("Cycle Accessories_V2", _data.Get("Cycle Accessories_V2"));
        _data.Set("Original Parts_V2", _data.Get("Original Parts_V2"));
        _data.Set("Cycle Accessories_V3", _data.Get("Cycle Accessories_V3"));
        _data.Set("Original Parts_V3", _data.Get("Original Parts_V3"));
        _data.Set("Cycle Accessories_V4", _data.Get("Cycle Accessories_V4"));
        _data.Set("Original Parts_V4", _data.Get("Original Parts_V4"));
    }

    // Business step: I open the configured policy application for openurl
    public async Task OpenTheConfiguredPolicyApplicationForOpenurlAsync4()
    {
        // OpenUrl_677fdaPage.OpenUrl_0167_bafd4aAsync
        if (_data.Condition("If Correction Needed > Then go to Express to bypass L9"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        }
    }

    // Business step: I select or create the policy client
    public async Task SelectOrCreateThePolicyClientAsync7()
    {
        // EQClientSelection_612f8cPage.ClientSelectionEnterClientInfoOfNewOrExisitingClients_0013_8f4c8fAsync
        await _ui.WaitAsync(_locators.LblClientInfo, "Exists");
        await _ui.VerifyAsync(_locators.LblClientInfo, _data.Resolve("{{data:expected_lbl_client_info_5}}"), "");
        await _ui.FillAsync(_locators.TxtFirst, _data.Get("AL_ClientData.First Name"));
        await _ui.FillAsync(_locators.TxtLast, _data.Get("AL_ClientData.Last Name"));
        await _ui.WaitAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch, "Exists");
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        await _ui.WaitAsync(_locators.BtnCreateNewClient, "Exists");
        await _ui.ClickAsync(_locators.BtnCreateNewClient);
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.SetStateName_0014_8f4c8fAsync
        _data.Set("StateName", _data.Resolve("{{data:statename}}"));
        _data.Set("State", _data.Get("State Abbreviation"));
    }

    // Business step: I open the configured policy application
    public async Task OpenTheConfiguredPolicyApplicationAsync5()
    {
        // EQOpenUrl_bc49e2Page.EQOpenUrl_0036_8f4c8fAsync
        if (_data.Condition("If > Then"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I complete auto AddlCov PIP
    public async Task CompleteAutoAddlCovPIPAsync5()
    {
        // EQPersonalInjuryProtectionSectionNew_834ca4Page.EQPersonalInjuryProtectionSection_0150_8f4c8fAsync
        if (_data.Condition("'All HH Members 65 or Pension' != NULL"))
        {
            await _ui.ClickAsync(_locators.HouseholdMembersAge65OrReceivingPension);
        }
        if (_data.Condition("'PIP Limit' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPLimit);
        }
        if (_data.Condition("'PIP Deductible' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPDeductible);
        }
        if (_data.Condition("'Additional PIP' != NULL"))
        {
            await _ui.ClickAsync(_locators.AdditionalPIP);
        }
        if (_data.Condition("'PIP Stacking' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPStacking);
        }
        if (_data.Condition("'Extra PIP Option' != NULL"))
        {
            await _ui.SelectAsync(_locators.ExtraPIPOption, _data.Resolve(""));
        }
        if (_data.Condition("'Auto Health Insurer' != NULL"))
        {
            await _ui.ClickAsync(_locators.AutoHealthInsurer);
        }
        if (_data.Condition("'Medical Expense Elimination' != NULL"))
        {
            await _ui.ClickAsync(_locators.MedicalExpenseElimination);
        }
        if (_data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
            await _ui.SelectAsync(_locators.WorkLossNo, _data.Resolve(""));
        }
        if (_data.Condition("'Broadened PIP' != NULL"))
        {
            await _ui.ClickAsync(_locators.BroadenedPIP);
        }
        if (_data.Condition("'Additional Death Benefit' != NULL"))
        {
            await _ui.ClickAsync(_locators.AdditionalDeathBenefit);
        }
        if (_data.Condition("'Waiver of Income Loss' != NULL"))
        {
            await _ui.ClickAsync(_locators.WaiverOfIncomeLoss);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0151_8f4c8fAsync
        _data.Set("UMPD/UIMPD_V1", _data.Get("UMPD/UIMPD_V1"));
        _data.Set("UMPD Coverage_V1", _data.Get("UMPD Coverage_V1"));
        _data.Set("UMPD More Options Coverages_V1", _data.Get("UMPD More Options Coverages_V1"));
        _data.Set("UIMPD Coverage_V1", _data.Get("UIMPD Coverage_V1"));
        _data.Set("Rental Reimbursement Coverage_V1", _data.Get("Rental Reimbursement Coverage_V1"));
        _data.Set("Theft Deductible_V1", _data.Get("Theft Deductible_V1"));
        _data.Set("Roadside Assistance Coverage_V1", _data.Resolve("{{data:roadside_assistance_coverage_v1}}"));
        _data.Set("UMPD/UIMPD_V2", _data.Get("UMPD/UIMPD_V2"));
        _data.Set("UMPD Coverage_V2", _data.Get("UMPD Coverage_V2"));
        _data.Set("UMPD More Options Coverages_V2", _data.Get("UMPD More Options Coverages_V2"));
        _data.Set("UIMPD Coverage_V2", _data.Get("UIMPD Coverage_V2"));
        _data.Set("Rental Reimbursement Coverage_V2", _data.Get("Rental Reimbursement Coverage_V2"));
        _data.Set("Theft Deductible_V2", _data.Get("Theft Deductible_V2"));
        _data.Set("Roadside Assistance Coverage_V2", _data.Resolve("{{data:roadside_assistance_coverage_v2}}"));
        _data.Set("UMPD/UIMPD_V3", _data.Get("UMPD/UIMPD_V3"));
        _data.Set("UMPD Coverage_V3", _data.Get("UMPD Coverage_V3"));
        _data.Set("UMPD More Options Coverages_V3", _data.Get("UMPD More Options Coverages_V3"));
        _data.Set("UIMPD Coverage_V3", _data.Get("UIMPD Coverage_V3"));
        _data.Set("Rental Reimbursement Coverage_V3", _data.Get("Rental Reimbursement Coverage_V3"));
        _data.Set("Theft Deductible_V3", _data.Get("Theft Deductible_V3"));
        _data.Set("Roadside Assistance Coverage_V3", _data.Resolve("{{data:roadside_assistance_coverage_v3}}"));
        _data.Set("UMPD/UIMPD_V4", _data.Get("UMPD/UIMPD_V4"));
        _data.Set("UMPD Coverage_V4", _data.Get("UMPD Coverage_V4"));
        _data.Set("UMPD More Options Coverages_V4", _data.Get("UMPD More Options Coverages_V4"));
        _data.Set("UIMPD Coverage_V4", _data.Get("UIMPD Coverage_V4"));
        _data.Set("Rental Reimbursement Coverage_V4", _data.Get("Rental Reimbursement Coverage_V4"));
        _data.Set("Theft Deductible_V4", _data.Get("Theft Deductible_V4"));
        _data.Set("Roadside Assistance Coverage_V4", _data.Get("Roadside Assistance Coverage_V4"));
        _data.Set("Cycle Accessories_V1", _data.Get("Cycle Accessories_V1"));
        _data.Set("Original Parts_V1", _data.Get("Original Parts_V1"));
        _data.Set("Cycle Accessories_V2", _data.Get("Cycle Accessories_V2"));
        _data.Set("Original Parts_V2", _data.Get("Original Parts_V2"));
        _data.Set("Cycle Accessories_V3", _data.Get("Cycle Accessories_V3"));
        _data.Set("Original Parts_V3", _data.Get("Original Parts_V3"));
        _data.Set("Cycle Accessories_V4", _data.Get("Cycle Accessories_V4"));
        _data.Set("Original Parts_V4", _data.Get("Original Parts_V4"));
    }

    // Business step: I open the configured policy application for openurl
    public async Task OpenTheConfiguredPolicyApplicationForOpenurlAsync5()
    {
        // OpenUrl_677fdaPage.OpenUrl_0170_8f4c8fAsync
        if (_data.Condition("If Correction Needed > Then go to Express to bypass L9"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I select or create the policy client
    public async Task SelectOrCreateThePolicyClientAsync8()
    {
        // EQClientSelection_612f8cPage.ClientSelectionEnterClientInfoOfNewOrExisitingClients_0013_10f911Async
        await _ui.WaitAsync(_locators.LblClientInfo, "Exists");
        await _ui.VerifyAsync(_locators.LblClientInfo, _data.Resolve("{{data:expected_lbl_client_info_5}}"), "");
        await _ui.FillAsync(_locators.TxtFirst, _data.Get("AL_ClientData.First Name"));
        await _ui.FillAsync(_locators.TxtLast, _data.Get("AL_ClientData.Last Name"));
        await _ui.WaitAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch, "Exists");
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        await _ui.WaitAsync(_locators.BtnCreateNewClient, "Exists");
        await _ui.ClickAsync(_locators.BtnCreateNewClient);
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.SetStateName_0014_10f911Async
        _data.Set("StateName", _data.Resolve("{{data:statename}}"));
        _data.Set("State", _data.Get("State Abbreviation"));
    }

    // Business step: I open the configured policy application
    public async Task OpenTheConfiguredPolicyApplicationAsync6()
    {
        // EQOpenUrl_bc49e2Page.EQOpenUrl_0036_10f911Async
        if (_data.Condition("If > Then"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I complete auto AddlCov PIP
    public async Task CompleteAutoAddlCovPIPAsync6()
    {
        // EQPersonalInjuryProtectionSectionNew_834ca4Page.EQPersonalInjuryProtectionSection_0150_10f911Async
        if (_data.Condition("'All HH Members 65 or Pension' != NULL"))
        {
            await _ui.ClickAsync(_locators.HouseholdMembersAge65OrReceivingPension);
        }
        if (_data.Condition("'PIP Limit' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPLimit);
        }
        if (_data.Condition("'PIP Deductible' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPDeductible);
        }
        if (_data.Condition("'Additional PIP' != NULL"))
        {
            await _ui.ClickAsync(_locators.AdditionalPIP);
        }
        if (_data.Condition("'PIP Stacking' != NULL"))
        {
            await _ui.ClickAsync(_locators.PIPStacking);
        }
        if (_data.Condition("'Extra PIP Option' != NULL"))
        {
            await _ui.SelectAsync(_locators.ExtraPIPOption, _data.Resolve(""));
        }
        if (_data.Condition("'Auto Health Insurer' != NULL"))
        {
            await _ui.ClickAsync(_locators.AutoHealthInsurer);
        }
        if (_data.Condition("'Medical Expense Elimination' != NULL"))
        {
            await _ui.ClickAsync(_locators.MedicalExpenseElimination);
        }
        if (_data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
            await _ui.SelectAsync(_locators.WorkLossNo, _data.Resolve(""));
        }
        if (_data.Condition("'Broadened PIP' != NULL"))
        {
            await _ui.ClickAsync(_locators.BroadenedPIP);
        }
        if (_data.Condition("'Additional Death Benefit' != NULL"))
        {
            await _ui.ClickAsync(_locators.AdditionalDeathBenefit);
        }
        if (_data.Condition("'Waiver of Income Loss' != NULL"))
        {
            await _ui.ClickAsync(_locators.WaiverOfIncomeLoss);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0151_10f911Async
        _data.Set("UMPD/UIMPD_V1", _data.Get("UMPD/UIMPD_V1"));
        _data.Set("UMPD Coverage_V1", _data.Get("UMPD Coverage_V1"));
        _data.Set("UMPD More Options Coverages_V1", _data.Get("UMPD More Options Coverages_V1"));
        _data.Set("UIMPD Coverage_V1", _data.Get("UIMPD Coverage_V1"));
        _data.Set("Rental Reimbursement Coverage_V1", _data.Resolve("{{data:rental_reimbursement_coverage_v1}}"));
        _data.Set("Theft Deductible_V1", _data.Get("Theft Deductible_V1"));
        _data.Set("Roadside Assistance Coverage_V1", _data.Resolve("{{data:roadside_assistance_coverage_v1}}"));
        _data.Set("UMPD/UIMPD_V2", _data.Get("UMPD/UIMPD_V2"));
        _data.Set("UMPD Coverage_V2", _data.Get("UMPD Coverage_V2"));
        _data.Set("UMPD More Options Coverages_V2", _data.Get("UMPD More Options Coverages_V2"));
        _data.Set("UIMPD Coverage_V2", _data.Get("UIMPD Coverage_V2"));
        _data.Set("Rental Reimbursement Coverage_V2", _data.Resolve("{{data:rental_reimbursement_coverage_v2}}"));
        _data.Set("Theft Deductible_V2", _data.Get("Theft Deductible_V2"));
        _data.Set("Roadside Assistance Coverage_V2", _data.Resolve("{{data:roadside_assistance_coverage_v2}}"));
        _data.Set("UMPD/UIMPD_V3", _data.Get("UMPD/UIMPD_V3"));
        _data.Set("UMPD Coverage_V3", _data.Get("UMPD Coverage_V3"));
        _data.Set("UMPD More Options Coverages_V3", _data.Get("UMPD More Options Coverages_V3"));
        _data.Set("UIMPD Coverage_V3", _data.Get("UIMPD Coverage_V3"));
        _data.Set("Rental Reimbursement Coverage_V3", _data.Resolve("{{data:rental_reimbursement_coverage_v3}}"));
        _data.Set("Theft Deductible_V3", _data.Get("Theft Deductible_V3"));
        _data.Set("Roadside Assistance Coverage_V3", _data.Resolve("{{data:roadside_assistance_coverage_v3}}"));
        _data.Set("UMPD/UIMPD_V4", _data.Get("UMPD/UIMPD_V4"));
        _data.Set("UMPD Coverage_V4", _data.Get("UMPD Coverage_V4"));
        _data.Set("UMPD More Options Coverages_V4", _data.Get("UMPD More Options Coverages_V4"));
        _data.Set("UIMPD Coverage_V4", _data.Get("UIMPD Coverage_V4"));
        _data.Set("Rental Reimbursement Coverage_V4", _data.Resolve("{{data:rental_reimbursement_coverage_v4}}"));
        _data.Set("Theft Deductible_V4", _data.Get("Theft Deductible_V4"));
        _data.Set("Roadside Assistance Coverage_V4", _data.Resolve("{{data:roadside_assistance_coverage_v4}}"));
        _data.Set("Cycle Accessories_V1", _data.Get("Cycle Accessories_V1"));
        _data.Set("Original Parts_V1", _data.Get("Original Parts_V1"));
        _data.Set("Cycle Accessories_V2", _data.Get("Cycle Accessories_V2"));
        _data.Set("Original Parts_V2", _data.Get("Original Parts_V2"));
        _data.Set("Cycle Accessories_V3", _data.Get("Cycle Accessories_V3"));
        _data.Set("Original Parts_V3", _data.Get("Original Parts_V3"));
        _data.Set("Cycle Accessories_V4", _data.Get("Cycle Accessories_V4"));
        _data.Set("Original Parts_V4", _data.Get("Original Parts_V4"));
    }

    // Business step: I open the configured policy application for openurl
    public async Task OpenTheConfiguredPolicyApplicationForOpenurlAsync6()
    {
        // OpenUrl_677fdaPage.OpenUrl_0170_10f911Async
        if (_data.Condition("If Correction Needed > Then go to Express to bypass L9"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I select or create the policy client
    public async Task SelectOrCreateThePolicyClientAsync9()
    {
        // EQClientSelection_612f8cPage.ClientSelectionEnterClientInfoOfNewOrExisitingClients_0013_0dc866Async
        await _ui.WaitAsync(_locators.LblClientInfo, "Exists");
        await _ui.VerifyAsync(_locators.LblClientInfo, _data.Resolve("{{data:expected_lbl_client_info_5}}"), "");
        await _ui.FillAsync(_locators.TxtFirst, _data.Get("AL_ClientData.First Name"));
        await _ui.FillAsync(_locators.TxtLast, _data.Get("AL_ClientData.Last Name"));
        await _ui.WaitAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch, "Exists");
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        await _ui.WaitAsync(_locators.BtnCreateNewClient, "Exists");
        await _ui.ClickAsync(_locators.BtnCreateNewClient);
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.SetStateName_0014_0dc866Async
        _data.Set("StateName", _data.Resolve("{{data:statename}}"));
        _data.Set("State", _data.Get("State Abbreviation"));
    }

}
