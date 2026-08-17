using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class CoveragesPage
{
    private readonly CoveragesLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public CoveragesPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new CoveragesLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete auto AddlCov policy coveragess
    public async Task CompleteAutoAddlCovPolicyCoveragessAsync()
    {
        // EQOtherPolicyCoveragesSectionNew_2f2bf9Page.EQOtherPolicyCoveragesSection_0136_8f9ff6Async
        await _ui.WaitAsync(_locators.H1AdditionalCoverages, "Exists");
        if (_data.Condition("'Tort Option' != NULL"))
        {
        await _ui.ClickAsync(_locators.TortOption);
        await _ui.PressAsync(_locators.TortOption, "home");
        }
        if (_data.Condition("'Income Loss Coverage' != NULL"))
        {
        await _ui.ClickAsync(_locators.IncomeLossCoverage);
        await _ui.PressAsync(_locators.IncomeLossCoverage, "Home");
        }
        if (_data.Condition("UMPD != NULL"))
        {
        await _ui.ClickAsync(_locators.UMPD);
        }
        if (_data.Condition("UIMPD != NULL"))
        {
        await _ui.ClickAsync(_locators.UIMPD);
        }
        if (_data.Condition("'AD&D Coverage' != NULL"))
        {
        await _ui.WaitAsync(_locators.ADDCoverage, "True");
        }
        if (_data.Condition("'AD&D Coverage' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDCoverage);
        await _ui.PressAsync(_locators.ADDCoverage, "Click");
        await _ui.PressAsync(_locators.ADDCoverage, "scroll[3]");
        }
        if (_data.Condition("'AD&D_Driver1' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver1);
        }
        if (_data.Condition("'AD&D_Driver2' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver2);
        }
        if (_data.Condition("'AD&D_Driver3' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver3);
        }
        if (_data.Condition("'AD&D_Driver4' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver4);
        }
        if (_data.Condition("'AD&D_Driver5' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver5);
        }
        if (_data.Condition("'Loss of Income Coverage_Driver1' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver1, _data.Resolve("{{data:loss_of_income_driver1_404}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver2' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver2, _data.Resolve("{{data:loss_of_income_driver2_405}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver3' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver3, _data.Resolve("{{data:loss_of_income_driver3_406}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver4' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver4, _data.Resolve("{{data:loss_of_income_driver4_407}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver5' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver5, _data.Resolve("{{data:loss_of_income_driver5_408}}"));
        }
        if (_data.Condition("'Total Disability Coverage_Driver1' != NULL"))
        {
        await _ui.ClickAsync(_locators.TotalDisabilityCoverageDriver1);
        }
        if (_data.Condition("'Inc Liab Claims Fam Mem' != NULL"))
        {
        await _ui.ClickAsync(_locators.IncLiabilityClaimsOfFamilyMembers);
        }
        if (_data.Condition("'Extraordinary Medical Benefit' != NULL"))
        {
        await _ui.ClickAsync(_locators.ExtraordinaryMedicalBenefit);
        }
        if (_data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
        await _ui.SelectAsync(_locators.WorkLossNo, _data.Resolve(""));
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0137_8f9ff6Async
        _data.Set("All HH Members 65 or Pension", _data.Get("All HH Members 65 or Pension"));
        _data.Set("PIP Limit", _data.Get("PIP Limit"));
        _data.Set("PIP Deductible", _data.Get("PIP Deductible"));
        _data.Set("Additional PIP", _data.Get("Additional PIP"));
        _data.Set("PIP Stacking", _data.Get("PIP Stacking"));
        _data.Set("Extra PIP Option", _data.Get("Extra PIP Option"));
        _data.Set("Auto Health Insurer", _data.Get("Auto Health Insurer"));
        _data.Set("Medical Expense Elimination", _data.Get("Medical Expense Elimination"));
        _data.Set("Work Loss Benefits", _data.Get("Work Loss Benefits"));
        _data.Set("Broadened PIP", _data.Get("Broadened PIP"));
        _data.Set("Additional Death Benefit", _data.Get("Additional Death Benefit"));
        _data.Set("Waiver of Income Loss", _data.Get("Waiver of Income Loss"));
    }

    // Business step: I complete auto AddlCov Next
    public async Task CompleteAutoAddlCovNextAsync()
    {
        // EQAdditionalCoveragesNextNew_1488c3Page.AdditionalCoveragesNext_0141_8f9ff6Async
        await _ui.ClickAsync(_locators.AdditionalCoveragesNextNewNext);
    }

    // Business step: I complete auto AddlCov policy coveragess
    public async Task CompleteAutoAddlCovPolicyCoveragessAsync2()
    {
        // EQOtherPolicyCoveragesSectionNew_2f2bf9Page.EQOtherPolicyCoveragesSection_0148_8f5301Async
        await _ui.WaitAsync(_locators.H1AdditionalCoverages, "Exists");
        if (_data.Condition("'Tort Option' != NULL"))
        {
        await _ui.ClickAsync(_locators.TortOption);
        await _ui.PressAsync(_locators.TortOption, "home");
        }
        if (_data.Condition("'Income Loss Coverage' != NULL"))
        {
        await _ui.ClickAsync(_locators.IncomeLossCoverage);
        await _ui.PressAsync(_locators.IncomeLossCoverage, "Home");
        }
        if (_data.Condition("UMPD != NULL"))
        {
        await _ui.ClickAsync(_locators.UMPD);
        }
        if (_data.Condition("UIMPD != NULL"))
        {
        await _ui.ClickAsync(_locators.UIMPD);
        }
        if (_data.Condition("'AD&D Coverage' != NULL"))
        {
        await _ui.WaitAsync(_locators.ADDCoverage, "True");
        }
        if (_data.Condition("'AD&D Coverage' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDCoverage);
        await _ui.PressAsync(_locators.ADDCoverage, "Click");
        await _ui.PressAsync(_locators.ADDCoverage, "scroll[3]");
        }
        if (_data.Condition("'AD&D_Driver1' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver1);
        }
        if (_data.Condition("'AD&D_Driver2' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver2);
        }
        if (_data.Condition("'AD&D_Driver3' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver3);
        }
        if (_data.Condition("'AD&D_Driver4' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver4);
        }
        if (_data.Condition("'AD&D_Driver5' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver5);
        }
        if (_data.Condition("'Loss of Income Coverage_Driver1' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver1, _data.Resolve("{{data:loss_of_income_driver1_455}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver2' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver2, _data.Resolve("{{data:loss_of_income_driver2_456}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver3' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver3, _data.Resolve("{{data:loss_of_income_driver3_457}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver4' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver4, _data.Resolve("{{data:loss_of_income_driver4_458}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver5' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver5, _data.Resolve("{{data:loss_of_income_driver5_459}}"));
        }
        if (_data.Condition("'Total Disability Coverage_Driver1' != NULL"))
        {
        await _ui.ClickAsync(_locators.TotalDisabilityCoverageDriver1);
        }
        if (_data.Condition("'Inc Liab Claims Fam Mem' != NULL"))
        {
        await _ui.ClickAsync(_locators.IncLiabilityClaimsOfFamilyMembers);
        }
        if (_data.Condition("'Extraordinary Medical Benefit' != NULL"))
        {
        await _ui.ClickAsync(_locators.ExtraordinaryMedicalBenefit);
        }
        if (_data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
        await _ui.SelectAsync(_locators.WorkLossNo, _data.Resolve(""));
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0149_8f5301Async
        _data.Set("All HH Members 65 or Pension", _data.Get("All HH Members 65 or Pension"));
        _data.Set("PIP Limit", _data.Get("PIP Limit"));
        _data.Set("PIP Deductible", _data.Get("PIP Deductible"));
        _data.Set("Additional PIP", _data.Get("Additional PIP"));
        _data.Set("PIP Stacking", _data.Get("PIP Stacking"));
        _data.Set("Extra PIP Option", _data.Get("Extra PIP Option"));
        _data.Set("Auto Health Insurer", _data.Get("Auto Health Insurer"));
        _data.Set("Medical Expense Elimination", _data.Get("Medical Expense Elimination"));
        _data.Set("Work Loss Benefits", _data.Get("Work Loss Benefits"));
        _data.Set("Broadened PIP", _data.Get("Broadened PIP"));
        _data.Set("Additional Death Benefit", _data.Get("Additional Death Benefit"));
        _data.Set("Waiver of Income Loss", _data.Get("Waiver of Income Loss"));
    }

    // Business step: I complete auto AddlCov Next
    public async Task CompleteAutoAddlCovNextAsync2()
    {
        // EQAdditionalCoveragesNextNew_1488c3Page.AdditionalCoveragesNext_0153_8f5301Async
        await _ui.ClickAsync(_locators.AdditionalCoveragesNextNewNext);
    }

    // Business step: I complete auto AddlCov policy coveragess
    public async Task CompleteAutoAddlCovPolicyCoveragessAsync3()
    {
        // EQOtherPolicyCoveragesSectionNew_2f2bf9Page.EQOtherPolicyCoveragesSection_0145_e2e0d7Async
        await _ui.WaitAsync(_locators.H1AdditionalCoverages, "Exists");
        if (_data.Condition("'Tort Option' != NULL"))
        {
        await _ui.ClickAsync(_locators.TortOption);
        await _ui.PressAsync(_locators.TortOption, "home");
        }
        if (_data.Condition("'Income Loss Coverage' != NULL"))
        {
        await _ui.ClickAsync(_locators.IncomeLossCoverage);
        await _ui.PressAsync(_locators.IncomeLossCoverage, "Home");
        }
        if (_data.Condition("UMPD != NULL"))
        {
        await _ui.ClickAsync(_locators.UMPD);
        }
        if (_data.Condition("UIMPD != NULL"))
        {
        await _ui.ClickAsync(_locators.UIMPD);
        }
        if (_data.Condition("'AD&D Coverage' != NULL"))
        {
        await _ui.WaitAsync(_locators.ADDCoverage, "True");
        }
        if (_data.Condition("'AD&D Coverage' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDCoverage);
        await _ui.PressAsync(_locators.ADDCoverage, "Click");
        await _ui.PressAsync(_locators.ADDCoverage, "scroll[3]");
        }
        if (_data.Condition("'AD&D_Driver1' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver1);
        }
        if (_data.Condition("'AD&D_Driver2' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver2);
        }
        if (_data.Condition("'AD&D_Driver3' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver3);
        }
        if (_data.Condition("'AD&D_Driver4' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver4);
        }
        if (_data.Condition("'AD&D_Driver5' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver5);
        }
        if (_data.Condition("'Loss of Income Coverage_Driver1' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver1, _data.Resolve("{{data:loss_of_income_driver1_438}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver2' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver2, _data.Resolve("{{data:loss_of_income_driver2_439}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver3' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver3, _data.Resolve("{{data:loss_of_income_driver3_440}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver4' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver4, _data.Resolve("{{data:loss_of_income_driver4_441}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver5' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver5, _data.Resolve("{{data:loss_of_income_driver5_442}}"));
        }
        if (_data.Condition("'Total Disability Coverage_Driver1' != NULL"))
        {
        await _ui.ClickAsync(_locators.TotalDisabilityCoverageDriver1);
        }
        if (_data.Condition("'Inc Liab Claims Fam Mem' != NULL"))
        {
        await _ui.ClickAsync(_locators.IncLiabilityClaimsOfFamilyMembers);
        }
        if (_data.Condition("'Extraordinary Medical Benefit' != NULL"))
        {
        await _ui.ClickAsync(_locators.ExtraordinaryMedicalBenefit);
        }
        if (_data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
        await _ui.SelectAsync(_locators.WorkLossNo, _data.Resolve(""));
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0146_e2e0d7Async
        _data.Set("All HH Members 65 or Pension", _data.Get("All HH Members 65 or Pension"));
        _data.Set("PIP Limit", _data.Get("PIP Limit"));
        _data.Set("PIP Deductible", _data.Get("PIP Deductible"));
        _data.Set("Additional PIP", _data.Get("Additional PIP"));
        _data.Set("PIP Stacking", _data.Get("PIP Stacking"));
        _data.Set("Extra PIP Option", _data.Get("Extra PIP Option"));
        _data.Set("Auto Health Insurer", _data.Get("Auto Health Insurer"));
        _data.Set("Medical Expense Elimination", _data.Get("Medical Expense Elimination"));
        _data.Set("Work Loss Benefits", _data.Get("Work Loss Benefits"));
        _data.Set("Broadened PIP", _data.Get("Broadened PIP"));
        _data.Set("Additional Death Benefit", _data.Get("Additional Death Benefit"));
        _data.Set("Waiver of Income Loss", _data.Get("Waiver of Income Loss"));
    }

    // Business step: I complete auto AddlCov Next
    public async Task CompleteAutoAddlCovNextAsync3()
    {
        // EQAdditionalCoveragesNextNew_1488c3Page.AdditionalCoveragesNext_0150_e2e0d7Async
        await _ui.ClickAsync(_locators.AdditionalCoveragesNextNewNext);
    }

    // Business step: I complete auto AddlCov policy coveragess
    public async Task CompleteAutoAddlCovPolicyCoveragessAsync4()
    {
        // EQOtherPolicyCoveragesSectionNew_2f2bf9Page.EQOtherPolicyCoveragesSection_0145_bafd4aAsync
        await _ui.WaitAsync(_locators.H1AdditionalCoverages, "Exists");
        if (_data.Condition("'Tort Option' != NULL"))
        {
        await _ui.ClickAsync(_locators.TortOption);
        await _ui.PressAsync(_locators.TortOption, "home");
        }
        if (_data.Condition("'Income Loss Coverage' != NULL"))
        {
        await _ui.ClickAsync(_locators.IncomeLossCoverage);
        await _ui.PressAsync(_locators.IncomeLossCoverage, "Home");
        }
        if (_data.Condition("UMPD != NULL"))
        {
        await _ui.ClickAsync(_locators.UMPD);
        }
        if (_data.Condition("UIMPD != NULL"))
        {
        await _ui.ClickAsync(_locators.UIMPD);
        }
        if (_data.Condition("'AD&D Coverage' != NULL"))
        {
        await _ui.WaitAsync(_locators.ADDCoverage, "True");
        }
        if (_data.Condition("'AD&D Coverage' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDCoverage);
        await _ui.PressAsync(_locators.ADDCoverage, "Click");
        await _ui.PressAsync(_locators.ADDCoverage, "scroll[3]");
        }
        if (_data.Condition("'AD&D_Driver1' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver1);
        }
        if (_data.Condition("'AD&D_Driver2' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver2);
        }
        if (_data.Condition("'AD&D_Driver3' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver3);
        }
        if (_data.Condition("'AD&D_Driver4' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver4);
        }
        if (_data.Condition("'AD&D_Driver5' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver5);
        }
        if (_data.Condition("'Loss of Income Coverage_Driver1' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver1, _data.Resolve("{{data:loss_of_income_driver1_438}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver2' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver2, _data.Resolve("{{data:loss_of_income_driver2_439}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver3' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver3, _data.Resolve("{{data:loss_of_income_driver3_440}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver4' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver4, _data.Resolve("{{data:loss_of_income_driver4_441}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver5' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver5, _data.Resolve("{{data:loss_of_income_driver5_442}}"));
        }
        if (_data.Condition("'Total Disability Coverage_Driver1' != NULL"))
        {
        await _ui.ClickAsync(_locators.TotalDisabilityCoverageDriver1);
        }
        if (_data.Condition("'Inc Liab Claims Fam Mem' != NULL"))
        {
        await _ui.ClickAsync(_locators.IncLiabilityClaimsOfFamilyMembers);
        }
        if (_data.Condition("'Extraordinary Medical Benefit' != NULL"))
        {
        await _ui.ClickAsync(_locators.ExtraordinaryMedicalBenefit);
        }
        if (_data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
        await _ui.SelectAsync(_locators.WorkLossNo, _data.Resolve(""));
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0146_bafd4aAsync
        _data.Set("All HH Members 65 or Pension", _data.Get("All HH Members 65 or Pension"));
        _data.Set("PIP Limit", _data.Get("PIP Limit"));
        _data.Set("PIP Deductible", _data.Get("PIP Deductible"));
        _data.Set("Additional PIP", _data.Get("Additional PIP"));
        _data.Set("PIP Stacking", _data.Get("PIP Stacking"));
        _data.Set("Extra PIP Option", _data.Get("Extra PIP Option"));
        _data.Set("Auto Health Insurer", _data.Get("Auto Health Insurer"));
        _data.Set("Medical Expense Elimination", _data.Get("Medical Expense Elimination"));
        _data.Set("Work Loss Benefits", _data.Get("Work Loss Benefits"));
        _data.Set("Broadened PIP", _data.Get("Broadened PIP"));
        _data.Set("Additional Death Benefit", _data.Get("Additional Death Benefit"));
        _data.Set("Waiver of Income Loss", _data.Get("Waiver of Income Loss"));
    }

    // Business step: I complete auto AddlCov Next
    public async Task CompleteAutoAddlCovNextAsync4()
    {
        // EQAdditionalCoveragesNextNew_1488c3Page.AdditionalCoveragesNext_0150_bafd4aAsync
        await _ui.ClickAsync(_locators.AdditionalCoveragesNextNewNext);
    }

    // Business step: I complete auto AddlCov policy coveragess
    public async Task CompleteAutoAddlCovPolicyCoveragessAsync5()
    {
        // EQOtherPolicyCoveragesSectionNew_2f2bf9Page.EQOtherPolicyCoveragesSection_0148_8f4c8fAsync
        await _ui.WaitAsync(_locators.H1AdditionalCoverages, "Exists");
        if (_data.Condition("'Tort Option' != NULL"))
        {
        await _ui.ClickAsync(_locators.TortOption);
        await _ui.PressAsync(_locators.TortOption, "home");
        }
        if (_data.Condition("'Income Loss Coverage' != NULL"))
        {
        await _ui.ClickAsync(_locators.IncomeLossCoverage);
        await _ui.PressAsync(_locators.IncomeLossCoverage, "Home");
        }
        if (_data.Condition("UMPD != NULL"))
        {
        await _ui.ClickAsync(_locators.UMPD);
        }
        if (_data.Condition("UIMPD != NULL"))
        {
        await _ui.ClickAsync(_locators.UIMPD);
        }
        if (_data.Condition("'AD&D Coverage' != NULL"))
        {
        await _ui.WaitAsync(_locators.ADDCoverage, "True");
        }
        if (_data.Condition("'AD&D Coverage' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDCoverage);
        await _ui.PressAsync(_locators.ADDCoverage, "Click");
        await _ui.PressAsync(_locators.ADDCoverage, "scroll[3]");
        }
        if (_data.Condition("'AD&D_Driver1' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver1);
        }
        if (_data.Condition("'AD&D_Driver2' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver2);
        }
        if (_data.Condition("'AD&D_Driver3' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver3);
        }
        if (_data.Condition("'AD&D_Driver4' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver4);
        }
        if (_data.Condition("'AD&D_Driver5' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver5);
        }
        if (_data.Condition("'Loss of Income Coverage_Driver1' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver1, _data.Resolve("{{data:loss_of_income_driver1_455}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver2' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver2, _data.Resolve("{{data:loss_of_income_driver2_456}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver3' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver3, _data.Resolve("{{data:loss_of_income_driver3_457}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver4' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver4, _data.Resolve("{{data:loss_of_income_driver4_458}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver5' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver5, _data.Resolve("{{data:loss_of_income_driver5_459}}"));
        }
        if (_data.Condition("'Total Disability Coverage_Driver1' != NULL"))
        {
        await _ui.ClickAsync(_locators.TotalDisabilityCoverageDriver1);
        }
        if (_data.Condition("'Inc Liab Claims Fam Mem' != NULL"))
        {
        await _ui.ClickAsync(_locators.IncLiabilityClaimsOfFamilyMembers);
        }
        if (_data.Condition("'Extraordinary Medical Benefit' != NULL"))
        {
        await _ui.ClickAsync(_locators.ExtraordinaryMedicalBenefit);
        }
        if (_data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
        await _ui.SelectAsync(_locators.WorkLossNo, _data.Resolve(""));
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0149_8f4c8fAsync
        _data.Set("All HH Members 65 or Pension", _data.Get("All HH Members 65 or Pension"));
        _data.Set("PIP Limit", _data.Get("PIP Limit"));
        _data.Set("PIP Deductible", _data.Get("PIP Deductible"));
        _data.Set("Additional PIP", _data.Get("Additional PIP"));
        _data.Set("PIP Stacking", _data.Get("PIP Stacking"));
        _data.Set("Extra PIP Option", _data.Get("Extra PIP Option"));
        _data.Set("Auto Health Insurer", _data.Get("Auto Health Insurer"));
        _data.Set("Medical Expense Elimination", _data.Get("Medical Expense Elimination"));
        _data.Set("Work Loss Benefits", _data.Get("Work Loss Benefits"));
        _data.Set("Broadened PIP", _data.Get("Broadened PIP"));
        _data.Set("Additional Death Benefit", _data.Get("Additional Death Benefit"));
        _data.Set("Waiver of Income Loss", _data.Get("Waiver of Income Loss"));
    }

    // Business step: I complete auto AddlCov Next
    public async Task CompleteAutoAddlCovNextAsync5()
    {
        // EQAdditionalCoveragesNextNew_1488c3Page.AdditionalCoveragesNext_0153_8f4c8fAsync
        await _ui.ClickAsync(_locators.AdditionalCoveragesNextNewNext);
    }

    // Business step: I complete auto AddlCov policy coveragess
    public async Task CompleteAutoAddlCovPolicyCoveragessAsync6()
    {
        // EQOtherPolicyCoveragesSectionNew_2f2bf9Page.EQOtherPolicyCoveragesSection_0148_10f911Async
        await _ui.WaitAsync(_locators.H1AdditionalCoverages, "Exists");
        if (_data.Condition("'Tort Option' != NULL"))
        {
        await _ui.ClickAsync(_locators.TortOption);
        await _ui.PressAsync(_locators.TortOption, "home");
        }
        if (_data.Condition("'Income Loss Coverage' != NULL"))
        {
        await _ui.ClickAsync(_locators.IncomeLossCoverage);
        await _ui.PressAsync(_locators.IncomeLossCoverage, "Home");
        }
        if (_data.Condition("UMPD != NULL"))
        {
        await _ui.ClickAsync(_locators.UMPD);
        }
        if (_data.Condition("UIMPD != NULL"))
        {
        await _ui.ClickAsync(_locators.UIMPD);
        }
        if (_data.Condition("'AD&D Coverage' != NULL"))
        {
        await _ui.WaitAsync(_locators.ADDCoverage, "True");
        }
        if (_data.Condition("'AD&D Coverage' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDCoverage);
        await _ui.PressAsync(_locators.ADDCoverage, "Click");
        await _ui.PressAsync(_locators.ADDCoverage, "scroll[3]");
        }
        if (_data.Condition("'AD&D_Driver1' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver1);
        }
        if (_data.Condition("'AD&D_Driver2' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver2);
        }
        if (_data.Condition("'AD&D_Driver3' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver3);
        }
        if (_data.Condition("'AD&D_Driver4' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver4);
        }
        if (_data.Condition("'AD&D_Driver5' != NULL"))
        {
        await _ui.ClickAsync(_locators.ADDDriver5);
        }
        if (_data.Condition("'Loss of Income Coverage_Driver1' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver1, _data.Resolve("{{data:loss_of_income_driver1_458}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver2' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver2, _data.Resolve("{{data:loss_of_income_driver2_459}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver3' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver3, _data.Resolve("{{data:loss_of_income_driver3_460}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver4' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver4, _data.Resolve("{{data:loss_of_income_driver4_461}}"));
        }
        if (_data.Condition("'Loss of Income Coverage_Driver5' != NULL"))
        {
        await _ui.SmartSetAsync(_locators.LossOfIncomeDriver5, _data.Resolve("{{data:loss_of_income_driver5_462}}"));
        }
        if (_data.Condition("'Total Disability Coverage_Driver1' != NULL"))
        {
        await _ui.ClickAsync(_locators.TotalDisabilityCoverageDriver1);
        }
        if (_data.Condition("'Inc Liab Claims Fam Mem' != NULL"))
        {
        await _ui.ClickAsync(_locators.IncLiabilityClaimsOfFamilyMembers);
        }
        if (_data.Condition("'Extraordinary Medical Benefit' != NULL"))
        {
        await _ui.ClickAsync(_locators.ExtraordinaryMedicalBenefit);
        }
        if (_data.Condition("'Work Loss Coordination Of Benefits' != NULL"))
        {
        await _ui.SelectAsync(_locators.WorkLossNo, _data.Resolve(""));
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0149_10f911Async
        _data.Set("All HH Members 65 or Pension", _data.Get("All HH Members 65 or Pension"));
        _data.Set("PIP Limit", _data.Get("PIP Limit"));
        _data.Set("PIP Deductible", _data.Get("PIP Deductible"));
        _data.Set("Additional PIP", _data.Get("Additional PIP"));
        _data.Set("PIP Stacking", _data.Get("PIP Stacking"));
        _data.Set("Extra PIP Option", _data.Get("Extra PIP Option"));
        _data.Set("Auto Health Insurer", _data.Get("Auto Health Insurer"));
        _data.Set("Medical Expense Elimination", _data.Get("Medical Expense Elimination"));
        _data.Set("Work Loss Benefits", _data.Get("Work Loss Benefits"));
        _data.Set("Broadened PIP", _data.Get("Broadened PIP"));
        _data.Set("Additional Death Benefit", _data.Get("Additional Death Benefit"));
        _data.Set("Waiver of Income Loss", _data.Get("Waiver of Income Loss"));
    }

    // Business step: I complete auto AddlCov Next
    public async Task CompleteAutoAddlCovNextAsync6()
    {
        // EQAdditionalCoveragesNextNew_1488c3Page.AdditionalCoveragesNext_0153_10f911Async
        await _ui.ClickAsync(_locators.AdditionalCoveragesNextNewNext);
    }

}