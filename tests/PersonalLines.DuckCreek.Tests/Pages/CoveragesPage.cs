using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class CoveragesPage
{
    private readonly BrowserSession _browser;
    private readonly CoveragesLocators _locators;
    private readonly UiActions _ui;

    public CoveragesPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new CoveragesLocators(browser.Page);
        _ui = ui;
    }

    public Task WaitForADDCoverageAsync(string expected) =>
        _ui.WaitAsync(_locators.ADDCoverage, expected, new ControlIntent("Coverages", "ADDCoverage"));

    public Task PressADDCoverageAsync(string key) =>
        _ui.PressAsync(_locators.ADDCoverage, key, new ControlIntent("Coverages", "ADDCoverage"));

    public Task<bool> IsADDCoverageNoCoveragePresentAsync() =>
        _ui.ExistsAsync(_locators.ADDCoverageNoCoverage);

    public Task ClickADDCoverageNoCoverageAsync() =>
        _ui.ClickAsync(_locators.ADDCoverageNoCoverage, new ControlIntent("Coverages", "ADDCoverageNoCoverage"));

    public Task<bool> IsSupplementalSpousalLimitNoPresentAsync() =>
        _ui.ExistsAsync(_locators.SupplementalSpousalLimitNo);

    public Task ClickSupplementalSpousalLimitNoAsync() =>
        _ui.ClickAsync(_locators.SupplementalSpousalLimitNo, new ControlIntent("Coverages", "SupplementalSpousalLimitNo"));

    public Task<bool> IsAdditionalCoveragesNavPresentAsync() =>
        _ui.ExistsAsync(_locators.AdditionalCoveragesNav);

    public Task ClickAdditionalCoveragesNavAsync() =>
        _ui.ClickAsync(_locators.AdditionalCoveragesNav, new ControlIntent("Coverages", "AdditionalCoveragesNav"));

    public Task<bool> IsPersonalInjuryProtectionHeaderPresentAsync() =>
        _ui.ExistsAsync(_locators.PersonalInjuryProtectionHeader);

    public Task<bool> IsUninsuredMotoristsPDHeaderPresentAsync() =>
        _ui.ExistsAsync(_locators.UninsuredMotoristsPDHeader);

    public Task ClickUninsuredMotoristsPDLimit50000Async() =>
        _ui.ClickAsync(_locators.UninsuredMotoristsPDLimit50000, new ControlIntent("Coverages", "UninsuredMotoristsPDLimit50000"));

    public Task ClickTortFullAsync() =>
        _ui.ClickAsync(_locators.TortFull, new ControlIntent("Coverages", "TortFull"));

    public Task ClickPIPLimitBasicAsync() =>
        _ui.ClickAsync(_locators.PIPLimitBasic, new ControlIntent("Coverages", "PIPLimitBasic"));

    public Task ClickPIPDeductible100Async() =>
        _ui.ClickAsync(_locators.PIPDeductible100, new ControlIntent("Coverages", "PIPDeductible100"));

    public Task<bool> IsPIPDeductible100PresentAsync() =>
        _ui.ExistsAsync(_locators.PIPDeductible100);

    public Task ClickPIPMedicalExpenseEliminationNoAsync() =>
        _ui.ClickAsync(_locators.PIPMedicalExpenseEliminationNo, new ControlIntent("Coverages", "PIPMedicalExpenseEliminationNo"));

    public Task ClickPIPWorkLossCoordinationOfBenefitsNoAsync() =>
        _ui.ClickAsync(_locators.PIPWorkLossCoordinationOfBenefitsNo, new ControlIntent("Coverages", "PIPWorkLossCoordinationOfBenefitsNo"));

    public Task ClickPIPBroadenedPIPNoAsync() =>
        _ui.ClickAsync(_locators.PIPBroadenedPIPNo, new ControlIntent("Coverages", "PIPBroadenedPIPNo"));

    public Task ClickPIPAdditionalDeathBenefitNoCoverageAsync() =>
        _ui.ClickAsync(_locators.PIPAdditionalDeathBenefitNoCoverage, new ControlIntent("Coverages", "PIPAdditionalDeathBenefitNoCoverage"));

    public Task<bool> IsAdditionalPIPOpt1PresentAsync() =>
        _ui.ExistsAsync(_locators.AdditionalPIPOpt1);

    public Task ClickAdditionalPIPOpt1Async() =>
        _ui.ClickAsync(_locators.AdditionalPIPOpt1, new ControlIntent("Coverages", "AdditionalPIPOpt1"));

    public Task<bool> IsPIPLimitHeaderPresentAsync() =>
        _ui.ExistsAsync(_locators.PIPLimitHeader);

    public Task ClickPIPLimit50000Async() =>
        _ui.ClickAsync(_locators.PIPLimit50000, new ControlIntent("Coverages", "PIPLimit50000"));

    public Task<bool> IsPIPLimit50000PresentAsync() =>
        _ui.ExistsAsync(_locators.PIPLimit50000);

    public Task<bool> IsPIPDeductibleHeaderPresentAsync() =>
        _ui.ExistsAsync(_locators.PIPDeductibleHeader);

    public Task ClickPIPDeductible500Async() =>
        _ui.ClickAsync(_locators.PIPDeductible500, new ControlIntent("Coverages", "PIPDeductible500"));

    public Task<bool> IsDeductibleAppliesToHeaderPresentAsync() =>
        _ui.ExistsAsync(_locators.DeductibleAppliesToHeader);

    public Task<bool> IsAccidentalDeathAndDismembermentLabelPresentAsync() =>
        _ui.ExistsAsync(_locators.AccidentalDeathAndDismembermentLabel);

    public Task ClickAccidentalDeathAndDismembermentLabelAsync() =>
        _ui.ClickAsync(_locators.AccidentalDeathAndDismembermentLabel, new ControlIntent("Coverages", "AccidentalDeathAndDismembermentLabel"));

    public Task ClickAccidentalDeathNoCoverageChipAsync() =>
        _ui.ClickAsync(_locators.AccidentalDeathNoCoverageChip, new ControlIntent("Coverages", "AccidentalDeathNoCoverageChip"));

    public Task ClickIncomeLossNoCoverageChipAsync() =>
        _ui.ClickAsync(_locators.IncomeLossNoCoverageChip, new ControlIntent("Coverages", "IncomeLossNoCoverageChip"));

    public Task ClickDriverIncomeLossOperatorCheckboxAsync() =>
        _ui.ClickAsync(_locators.DriverIncomeLossOperatorCheckbox, new ControlIntent("Coverages", "DriverIncomeLossOperatorCheckbox"));

    public Task ClickDeductibleAppliesToNamedInsuredAsync() =>
        _ui.ClickAsync(_locators.DeductibleAppliesToNamedInsured, new ControlIntent("Coverages", "DeductibleAppliesToNamedInsured"));

    public Task<bool> IsUMPDCoverageNoCoveragePresentAsync(int row) =>
        _ui.ExistsAsync(_locators.GetUMPDCoverageNoCoverage(row));

    public Task ClickUMPDCoverageNoCoverageAsync(int row) =>
        _ui.ClickAsync(_locators.GetUMPDCoverageNoCoverage(row), new ControlIntent("Coverages", "UMPDCoverageNoCoverage"));

    public async Task ClickUMPDCoverageNoCoverageForAllRowsAsync()
    {
        var row = 0;
        while (await IsUMPDCoverageNoCoveragePresentAsync(row))
        {
            await ClickUMPDCoverageNoCoverageAsync(row);
            row++;
        }
    }

    public Task<bool> IsPIPMedicalExpenseOnlyHeaderPresentAsync() =>
        _ui.ExistsAsync(_locators.PIPMedicalExpenseOnlyHeader);

    public Task ClickPIPMedicalExpenseOnlyNoAsync() =>
        _ui.ClickAsync(_locators.PIPMedicalExpenseOnlyNo, new ControlIntent("Coverages", "PIPMedicalExpenseOnlyNo"));

    public Task<bool> IsPIPExtendedMedicalExpenseBenefitsHeaderPresentAsync() =>
        _ui.ExistsAsync(_locators.PIPExtendedMedicalExpenseBenefitsHeader);

    public Task ClickPIPExtendedMedicalExpenseBenefits10000Async() =>
        _ui.ClickAsync(_locators.PIPExtendedMedicalExpenseBenefits10000, new ControlIntent("Coverages", "PIPExtendedMedicalExpenseBenefits10000"));

    public Task<bool> IsPIPExtraPIPOptionHeaderPresentAsync() =>
        _ui.ExistsAsync(_locators.PIPExtraPIPOptionHeader);

    public Task ClickPIPExtraPIPOptionNoAsync() =>
        _ui.ClickAsync(_locators.PIPExtraPIPOptionNo, new ControlIntent("Coverages", "PIPExtraPIPOptionNo"));

    public Task<bool> IsAutoHealthInsurerHeaderPresentAsync() =>
        _ui.ExistsAsync(_locators.AutoHealthInsurerHeader);

    public Task ClickAutoHealthInsurerHeaderAsync() =>
        _ui.ClickAsync(_locators.AutoHealthInsurerHeader, new ControlIntent("Coverages", "AutoHealthInsurerHeader"));

    public Task WaitForCoveragesHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.CoveragesHeader, expected, new ControlIntent("Coverages", "CoveragesHeader"));

    public Task<bool> IsLossOfIncomeCoveragePresentAsync() =>
        _ui.ExistsAsync(_locators.LossOfIncomeCoverage);

    public Task ClickLossOfIncomeCoverageAsync() =>
        _ui.ClickAsync(_locators.LossOfIncomeCoverage, new ControlIntent("Coverages", "LossOfIncomeCoverage"));

    public Task ClickAddedCoverageEndorsementAsync() =>
        _ui.ClickAsync(_locators.AddedCoverageEndorsement, new ControlIntent("Coverages", "AddedCoverageEndorsement"));

    public Task<bool> IsAddedCoverageEndorsementPresentAsync() =>
        _ui.ExistsAsync(_locators.AddedCoverageEndorsement);

    public Task ClickV4AddedCoverageEndorsementAsync() =>
        _ui.ClickAsync(_locators.V4AddedCoverageEndorsement, new ControlIntent("Coverages", "V4AddedCoverageEndorsement"));

    public Task ClickCoveragesNextAsync() =>
        _ui.ClickAsync(_locators.CoveragesNext, new ControlIntent("Coverages", "CoveragesNext"));

    public Task ClickV1RoadsideAssistanceNoCoverageAsync() =>
        _ui.ClickAsync(_locators.V1RoadsideAssistanceNoCoverage, new ControlIntent("Coverages", "V1RoadsideAssistanceNoCoverage"));

    public Task<bool> IsV1FullGlassCoveragePresentAsync() =>
        _ui.ExistsAsync(_locators.V1FullGlassCoverage);

    public Task ClickV1FullGlassCoverageAsync() =>
        _ui.ClickAsync(_locators.V1FullGlassCoverage, new ControlIntent("Coverages", "V1FullGlassCoverage"));

    public Task<bool> IsV1ExcessSoundProducingEquipmentCoveragePresentAsync() =>
        _ui.ExistsAsync(_locators.V1ExcessSoundProducingEquipmentCoverage);

    public Task ClickV1ExcessSoundProducingEquipmentCoverageAsync() =>
        _ui.ClickAsync(_locators.V1ExcessSoundProducingEquipmentCoverage, new ControlIntent("Coverages", "V1ExcessSoundProducingEquipmentCoverage"));

    public Task<bool> IsV2FullGlassCoveragePresentAsync() =>
        _ui.ExistsAsync(_locators.V2FullGlassCoverage);

    public Task ClickV2FullGlassCoverageAsync() =>
        _ui.ClickAsync(_locators.V2FullGlassCoverage, new ControlIntent("Coverages", "V2FullGlassCoverage"));

    public Task<bool> IsV2ExcessSoundProducingEquipmentCoveragePresentAsync() =>
        _ui.ExistsAsync(_locators.V2ExcessSoundProducingEquipmentCoverage);

    public Task ClickV2ExcessSoundProducingEquipmentCoverageAsync() =>
        _ui.ClickAsync(_locators.V2ExcessSoundProducingEquipmentCoverage, new ControlIntent("Coverages", "V2ExcessSoundProducingEquipmentCoverage"));

    public Task<bool> IsV3FullGlassCoveragePresentAsync() =>
        _ui.ExistsAsync(_locators.V3FullGlassCoverage);

    public Task ClickV3FullGlassCoverageAsync() =>
        _ui.ClickAsync(_locators.V3FullGlassCoverage, new ControlIntent("Coverages", "V3FullGlassCoverage"));

    public Task<bool> IsV3ExcessSoundProducingEquipmentCoveragePresentAsync() =>
        _ui.ExistsAsync(_locators.V3ExcessSoundProducingEquipmentCoverage);

    public Task ClickV3ExcessSoundProducingEquipmentCoverageAsync() =>
        _ui.ClickAsync(_locators.V3ExcessSoundProducingEquipmentCoverage, new ControlIntent("Coverages", "V3ExcessSoundProducingEquipmentCoverage"));

    public Task<bool> IsV4FullGlassCoveragePresentAsync() =>
        _ui.ExistsAsync(_locators.V4FullGlassCoverage);

    public Task ClickV4FullGlassCoverageAsync() =>
        _ui.ClickAsync(_locators.V4FullGlassCoverage, new ControlIntent("Coverages", "V4FullGlassCoverage"));

    public Task<bool> IsV4ExcessSoundProducingEquipmentCoveragePresentAsync() =>
        _ui.ExistsAsync(_locators.V4ExcessSoundProducingEquipmentCoverage);

    public Task ClickV4ExcessSoundProducingEquipmentCoverageAsync() =>
        _ui.ClickAsync(_locators.V4ExcessSoundProducingEquipmentCoverage, new ControlIntent("Coverages", "V4ExcessSoundProducingEquipmentCoverage"));

    public Task ClickV2RoadsideAssistanceNoCoverageAsync() =>
        _ui.ClickAsync(_locators.V2RoadsideAssistanceNoCoverage, new ControlIntent("Coverages", "V2RoadsideAssistanceNoCoverage"));

    public Task ClickV3RoadsideAssistanceNoCoverageAsync() =>
        _ui.ClickAsync(_locators.V3RoadsideAssistanceNoCoverage, new ControlIntent("Coverages", "V3RoadsideAssistanceNoCoverage"));

    public Task ClickV4RoadsideAssistanceNoCoverageAsync() =>
        _ui.ClickAsync(_locators.V4RoadsideAssistanceNoCoverage, new ControlIntent("Coverages", "V4RoadsideAssistanceNoCoverage"));

    public Task ClickV2RentalReimbursementAsync() =>
        _ui.ClickAsync(_locators.V2RentalReimbursement, new ControlIntent("Coverages", "V2RentalReimbursement"));

    public Task ClickV3RentalReimbursementAsync() =>
        _ui.ClickAsync(_locators.V3RentalReimbursement, new ControlIntent("Coverages", "V3RentalReimbursement"));

    public Task ClickV4RentalReimbursementAsync() =>
        _ui.ClickAsync(_locators.V4RentalReimbursement, new ControlIntent("Coverages", "V4RentalReimbursement"));

    public Task ClickADDCoverageAsync() =>
        _ui.ClickAsync(_locators.ADDCoverage, new ControlIntent("Coverages", "ADDCoverage"));

    public Task<bool> IsADDCoveragesAsync() =>
        _ui.ExistsAsync(_locators.ADDCoverage);

    public Task ClickADDDriver1Async() =>
        _ui.ClickAsync(_locators.ADDDriver1, new ControlIntent("Coverages", "ADDDriver1"));

    public Task ClickADDDriver2Async() =>
        _ui.ClickAsync(_locators.ADDDriver1, new ControlIntent("Coverages", "ADDDriver2"));

    public Task ClickADDDriver3Async() =>
        _ui.ClickAsync(_locators.ADDDriver1, new ControlIntent("Coverages", "ADDDriver3"));

    public Task ClickADDDriver4Async() =>
        _ui.ClickAsync(_locators.ADDDriver1, new ControlIntent("Coverages", "ADDDriver4"));

    public Task ClickADDDriver5Async() =>
        _ui.ClickAsync(_locators.ADDDriver1, new ControlIntent("Coverages", "ADDDriver5"));

    public Task ClickAdditionalCoveragesNextNewNextAsync() =>
        _ui.ClickAsync(_locators.AdditionalCoveragesNextNewNext, new ControlIntent("Coverages", "AdditionalCoveragesNextNewNext"));

    public Task WaitForAdditionalCoveragesNextNewNextAsync(string expected) =>
        _ui.WaitAsync(_locators.AdditionalCoveragesNextNewNext, expected, new ControlIntent("Coverages", "H1AdditionalCoverages"));

    public Task ClickExtraordinaryMedicalBenefitAsync() =>
        _ui.ClickAsync(_locators.ADDDriver1, new ControlIntent("Coverages", "ExtraordinaryMedicalBenefit"));

    public Task WaitForH1AdditionalCoveragesAsync(string expected) =>
        _ui.WaitAsync(_locators.H1AdditionalCoverages, expected, new ControlIntent("Coverages", "H1AdditionalCoverages"));

    public Task ClickIncLiabilityClaimsOfFamilyMembersAsync() =>
        _ui.ClickAsync(_locators.ILCFamilyMembersYes, new ControlIntent("Coverages", "IncLiabilityClaimsOfFamilyMembers"));

    public Task PressIncomeLossCoverageAsync(string key) =>
        _ui.PressAsync(_locators.IncomeLossCoverage, key, new ControlIntent("Coverages", "IncomeLossCoverage"));

    public Task ClickIncomeLossCoverageAsync() =>
        _ui.ClickAsync(_locators.IncomeLossCoverage, new ControlIntent("Coverages", "IncomeLossCoverage"));

    public Task SetLossOfIncomeDriver1Async(string value) =>
        _ui.SmartSetAsync(_locators.LossOfIncomeDriver1, value, new ControlIntent("Coverages", "LossOfIncomeDriver1"));

    public Task SetLossOfIncomeDriver2Async(string value) =>
        _ui.SmartSetAsync(_locators.LossOfIncomeDriver2, value, new ControlIntent("Coverages", "LossOfIncomeDriver2"));

    public Task SetLossOfIncomeDriver3Async(string value) =>
        _ui.SmartSetAsync(_locators.LossOfIncomeDriver3, value, new ControlIntent("Coverages", "LossOfIncomeDriver3"));

    public Task SetLossOfIncomeDriver4Async(string value) =>
        _ui.SmartSetAsync(_locators.LossOfIncomeDriver4, value, new ControlIntent("Coverages", "LossOfIncomeDriver4"));

    public Task SetLossOfIncomeDriver5Async(string value) =>
        _ui.SmartSetAsync(_locators.LossOfIncomeDriver5, value, new ControlIntent("Coverages", "LossOfIncomeDriver5"));

    public Task PressTortOptionAsync(string key) =>
        _ui.PressAsync(_locators.TortOption, key, new ControlIntent("Coverages", "TortOption"));

    public Task ClickTortOptionAsync() =>
        _ui.ClickAsync(_locators.TortOption, new ControlIntent("Coverages", "TortOption"));

    public Task<bool> IsTortOptionPresentAsync() =>
        _ui.ExistsAsync(_locators.TortOption);

    public Task ClickTotalDisabilityCoverageDriver1Async() =>
        _ui.ClickAsync(_locators.ADDDriver1, new ControlIntent("Coverages", "TotalDisabilityCoverageDriver1"));

    public Task ClickUIMPDAsync() =>
        _ui.ClickAsync(_locators.UIMPD, new ControlIntent("Coverages", "UIMPD"));

    public Task ClickUIMPD1000Async() =>
        _ui.ClickAsync(_locators.UIMPD1000, new ControlIntent("Coverages", "UIMPD"));

    public Task ClickUMPDAsync() =>
        _ui.ClickAsync(_locators.UMPD, new ControlIntent("Coverages", "UMPD"));

    public Task ClickUMPDA1000000sync() =>
        _ui.ClickAsync(_locators.UMPD1000000, new ControlIntent("Coverages", "UMPD"));

    public Task SelectWorkLossNoAsync(string value) =>
        _ui.SelectAsync(_locators.ADDDriver1, value, new ControlIntent("Coverages", "WorkLossNo"));

    public Task<bool> IsPIPHeaderPresentAsync() =>
        _ui.ExistsAsync(_locators.PIPHeader);

    public Task<bool> IsUMPDHeaderPresentAsync() =>
        _ui.ExistsAsync(_locators.UMPHeader);

    public Task<bool> IsUIMPDHeaderPresentAsync() =>
        _ui.ExistsAsync(_locators.UIMPDHeader);

    public Task ClickPIPBasic15000Async() =>
        _ui.ClickAsync(_locators.PIPBasic15000, new ControlIntent("Coverages", "PIPBasic15000"));

    public Task ClickPIPDeductableAsync() =>
        _ui.ClickAsync(_locators.PIPDeductable, new ControlIntent("Coverages", "PIPDeductable"));

    public Task<bool> IsLossOfIncomeCoverageHeaderAsync() =>
        _ui.ExistsAsync(_locators.LossOfIncomeCoverageHeader);

    public Task ClickUMPD10000Async() =>
        _ui.ClickAsync(_locators.UMPD100000, new ControlIntent("Coverages", "UMPD10000"));

    public Task ClickTheftDeductibleV1Async() =>
        _ui.ClickAsync(_locators.TheftDeductibleV1, new ControlIntent("Coverages", "TheftDeductibleV1"));

    public Task ClickTheftDeductibleNoCoverageV2Async() =>
        _ui.ClickAsync(_locators.TheftDeductibleNoCoverageV2, new ControlIntent("Coverages", "TheftDeductibleNoCoverageV2"));

    public Task ClickTheftDeductibleV3Async() =>
        _ui.ClickAsync(_locators.TheftDeductibleV3, new ControlIntent("Coverages", "TheftDeductibleV3"));
}
