using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class CoveragesLocators
{
    private readonly IPage _page;
    public CoveragesLocators(IPage page) => _page = page;

    // Dynamically set by buffer AD&D Coverage in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator ADDCoverage => _page.GetByTestId("fields.policy.line.accidentalDeathInput$limit.value-chip-label").GetByText("No Coverage");

    public ILocator ADDCoverageNoCoverage => _page.GetByTestId("fields.policy.line.policy_AccidentalDeathInput$limit.value-chip-label").Filter(new() { HasText = "No Coverage" });

    public ILocator SupplementalSpousalLimitNo => _page.GetByTestId("fields.policy.line.supplementalSpousalInput$limit.value-chip-label").Filter(new() { HasText = "No" });

    public ILocator AdditionalCoveragesNav => _page.GetByTestId("AdditionalCoverages-nav");

    public ILocator PersonalInjuryProtectionHeader => _page.Locator("#Line_Headless\\.Constant_PersonalInjuryProtection-0-layout");

    public ILocator UninsuredMotoristsPDHeader => _page.GetByText("Uninsured Motorists PD", new() { Exact = true });

    public ILocator UninsuredMotoristsPDLimit50000 => _page.GetByTestId("fields.policy.line.uninsuredMotoristsPDInput$limit.value-chip-label").Filter(new() { HasText = "$50,000" });

    public ILocator TortFull => _page.GetByTestId("fields.policy.line.tortInput$limit.value-chip-label").Filter(new() { HasText = "Full" });

    public ILocator PIPLimitBasic => _page.GetByTestId("fields.policy.line.pIPInput$limit.value-chip-label").Filter(new() { HasText = "BASIC" });

    public ILocator PIPDeductible100 => _page.GetByTestId("fields.policy.line.pIPInput$deductible.value-chip-label").Filter(new() { HasText = "$100" });

    public ILocator PIPMedicalExpenseEliminationNo => _page.GetByTestId("fields.policy.line.pIPInput$medicalExpenseElimination.value-chip-label").Filter(new() { HasText = "No" });

    public ILocator PIPWorkLossCoordinationOfBenefitsNo => _page.GetByTestId("fields.policy.line.pIPInput$workLossCoordinationOfBenefits.value-chip-label").Filter(new() { HasText = "No" });

    public ILocator PIPBroadenedPIPNo => _page.GetByTestId("fields.policy.line.pIPInput$broadenedPIP.value-chip-label").Filter(new() { HasText = "No" });

    public ILocator PIPAdditionalDeathBenefitNoCoverage => _page.GetByTestId("fields.policy.line.pIPInput$additionalDeathBenefit.value-chip-label").Filter(new() { HasText = "No Coverage" });

    public ILocator AdditionalPIPOpt1 => _page.GetByTestId("fields.policy.line.additionalPIPInput$limit.value-chip-label").Filter(new() { HasText = "Opt 1" });

    public ILocator PIPLimitHeader => _page.GetByText("Limit", new() { Exact = true });

    public ILocator PIPLimit50000 => _page.GetByTestId("fields.policy.line.pIPInput$limit.value-chip-label").Filter(new() { HasTextRegex = new System.Text.RegularExpressions.Regex("^\\$50,000$") });

    public ILocator PIPDeductibleHeader => _page.GetByText("Deductible", new() { Exact = true });

    public ILocator PIPDeductible500 => _page.GetByTestId("fields.policy.line.pIPInput$deductible.value-chip-label").Filter(new() { HasText = "$500" });

    public ILocator DeductibleAppliesToHeader => _page.Locator("label.asterisk-after").Filter(new() { HasText = "Deductible Applies To" });

    public ILocator AccidentalDeathAndDismembermentLabel => _page.Locator("label.asterisk-after").Filter(new() { HasText = "Accidental Death & Dismemberment" });

    public ILocator AccidentalDeathNoCoverageChip => _page.GetByTestId("fields.policy.line.policy_AccidentalDeathInput$limit.value-chip-label")
        .Filter(new() { HasText = "No Coverage" })
        .Or(_page.GetByTestId("fields.policy.line.accidentalDeathInput$limit.value-chip-label").Filter(new() { HasText = "No Coverage" }));

    public ILocator IncomeLossNoCoverageChip => _page.GetByTestId("fields.policy.line.incomeLossInput$limit.value-chip-label")
        .Filter(new() { HasText = "No Coverage" });

    public ILocator DriverIncomeLossOperatorCheckbox => _page.Locator("input[id='fields.policy.line.driverIncomeLoss.rows[0].driverInput$incomeLossOperator.value-checkbox']");

    public ILocator DeductibleAppliesToNamedInsured => _page.GetByTestId("fields.policy.line.pIPInput$deductibleAppliesTo.value-chip-label").Filter(new() { HasTextRegex = new System.Text.RegularExpressions.Regex("^Named Insured$") });

    public ILocator PIPMedicalExpenseOnlyHeader => _page.GetByText("Medical Expense Only", new() { Exact = true });

    public ILocator PIPMedicalExpenseOnlyNo => _page.GetByTestId("fields.policy.line.pIPInput$medicalExpenseOnly.value-chip-label").Filter(new() { HasText = "No" });

    public ILocator GetUMPDCoverageNoCoverage(int row) =>
        _page.GetByTestId($"fields.policy.line.risk.rows[{row}].covUninsuredMotoristsPDInput$limit.value-chip-label").Filter(new() { HasTextRegex = new System.Text.RegularExpressions.Regex("^No Coverage$") });

    public ILocator PIPExtendedMedicalExpenseBenefitsHeader => _page.GetByText("Extended Medical Expense Benefits", new() { Exact = true });

    public ILocator PIPExtendedMedicalExpenseBenefits10000 => _page.GetByTestId("fields.policy.line.pIPInput$extendedMedicalExpenseBenefits.value-chip-label").Filter(new() { HasText = "$10,000" });

    public ILocator PIPExtraPIPOptionHeader => _page.GetByText("Extra PIP Option", new() { Exact = true });

    public ILocator PIPExtraPIPOptionNo => _page.GetByTestId("fields.policy.line.pIPInput$extraPIPOption.value-chip-label").Filter(new() { HasText = "No" });

    public ILocator AutoHealthInsurerHeader => _page.GetByText("Auto Health Insurer", new() { Exact = true });

    public ILocator CoveragesHeader => _page.Locator("h1").Filter(new() { HasText = "Coverages" }).First;

    // Dynamically set by buffer Driver_1
    public ILocator ADDDriver1 => _page.Locator("button[id=\"fields.policy.line.driverIncomeLoss.rows[0].driverInput$incomeLossOperator.value\"][data-testid=\"fields.policy.line.driverIncomeLoss.rows[0].driverInput$incomeLossOperator.value\"]");

    public ILocator ILCFamilyMembersYes => _page.GetByTestId("fields.policy.line.lineInput$increasedLiabilityForFamily.value-chip-wrapper").First;

    // Dynamically set by buffer Driver_2 // fields.policy.line.lineInput$increasedLiabilityForFamily.value-chip-wrapper
    public ILocator LossOfIncomeCoverage => _page.Locator("[id=\"fields.policy.line.driverIncomeLoss.rows[0].driverInput$incomeLossOperator.value-checkbox\"]");

    public ILocator AddedCoverageEndorsement => _page.Locator("[id=\"fields.policy.line.risk.rows[0].vehicleInput$addedCoverageEndorsement.value-checkbox\"]");

    public ILocator V4AddedCoverageEndorsement => _page.Locator("[id=\"fields.policy.line.risk.rows[3].vehicleInput$addedCoverageEndorsement.value-checkbox\"]");

    public ILocator V1RoadsideAssistanceNoCoverage => _page.GetByTestId("fields.policy.line.risk.rows[0].covRoadsideAssistanceInput$limit.value-chip-label").Filter(new() { HasText = "No Coverage" });

    public ILocator V1FullGlassCoverage => _page.Locator("[id=\"fields.policy.line.risk.rows[0].covComprehensiveInput$fullGlass.value-checkbox\"]");

    public ILocator V1ExcessSoundProducingEquipmentCoverage => _page.Locator("[id=\"fields.policy.line.risk.rows[0].end_ExcessSoundEquipment$end_ExcessSoundEquip_Select.value-checkbox\"]");

    public ILocator V2FullGlassCoverage => _page.Locator("[id=\"fields.policy.line.risk.rows[1].covComprehensiveInput$fullGlass.value-checkbox\"]");

    public ILocator V2ExcessSoundProducingEquipmentCoverage => _page.Locator("[id=\"fields.policy.line.risk.rows[1].end_ExcessSoundEquipment$end_ExcessSoundEquip_Select.value-checkbox\"]");

    public ILocator V3FullGlassCoverage => _page.Locator("[id=\"fields.policy.line.risk.rows[2].covComprehensiveInput$fullGlass.value-checkbox\"]");

    public ILocator V3ExcessSoundProducingEquipmentCoverage => _page.Locator("[id=\"fields.policy.line.risk.rows[2].end_ExcessSoundEquipment$end_ExcessSoundEquip_Select.value-checkbox\"]");

    public ILocator V4FullGlassCoverage => _page.Locator("[id=\"fields.policy.line.risk.rows[3].covComprehensiveInput$fullGlass.value-checkbox\"]");

    public ILocator V4ExcessSoundProducingEquipmentCoverage => _page.Locator("[id=\"fields.policy.line.risk.rows[3].end_ExcessSoundEquipment$end_ExcessSoundEquip_Select.value-checkbox\"]");

    public ILocator V2RoadsideAssistanceNoCoverage => _page.GetByTestId("fields.policy.line.risk.rows[1].covRoadsideAssistanceInput$limit.value-chip-label").Filter(new() { HasText = "No Coverage" });

    public ILocator V3RoadsideAssistanceNoCoverage => _page.GetByTestId("fields.policy.line.risk.rows[2].covRoadsideAssistanceInput$limit.value-chip-label").Filter(new() { HasText = "No Coverage" });

    public ILocator V4RoadsideAssistanceNoCoverage => _page.GetByTestId("fields.policy.line.risk.rows[3].covRoadsideAssistanceInput$limit.value-chip-label").Filter(new() { HasText = "No Coverage" });

    public ILocator V2RentalReimbursement => _page.GetByTestId("fields.policy.line.risk.rows[1].covRentalReimbursementInput$limit.value-chip-label").Nth(1);

    public ILocator V3RentalReimbursement => _page.GetByTestId("fields.policy.line.risk.rows[2].covRentalReimbursementInput$limit.value-chip-label").Nth(2);

    public ILocator CoveragesNext => _page.GetByTestId("fields.policy.next-button-label").Filter(new() { HasText = "Next" });

    public ILocator V4RentalReimbursement => _page.GetByTestId("fields.policy.line.risk.rows[3].covRentalReimbursementInput$limit.value-chip-label").Nth(3);

    // Dynamically set by buffer Driver_2

    // Dynamically set by buffer Driver_3

    // Dynamically set by buffer Driver_4

    // Dynamically set by buffer Driver_5

    public ILocator AdditionalCoveragesNextNewNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    // Dynamically set by buffer Extraordinary Medical Benefit in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages

    public ILocator H1AdditionalCoverages => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Additional Coverages" });
    // Dynamically set by buffer Inc Liab Claims Fam Mem in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages

    // Dynamically set by buffer Income Loss Coverage in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator IncomeLossCoverage => _page.GetByTestId("fields.policy.line.incomeLossInput$limit.value-chip-label").GetByText("No Coverage");

    // Dynamically set by buffer Driver_1
    public ILocator LossOfIncomeDriver1 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[0].driverInput$incomeLossOperator.value");

    // Dynamically set by buffer Driver_2
    public ILocator LossOfIncomeDriver2 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[1].driverInput$incomeLossOperator.value");

    // Dynamically set by buffer Driver_3
    public ILocator LossOfIncomeDriver3 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[2].driverInput$incomeLossOperator.value");

    // Dynamically set by buffer Driver_4
    public ILocator LossOfIncomeDriver4 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[3].driverInput$incomeLossOperator.value");

    // Dynamically set by buffer Driver_5
    public ILocator LossOfIncomeDriver5 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[4].driverInput$incomeLossOperator.value");

    // Dynamically set by buffer Tort Option in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator TortOption => _page.GetByTestId("fields.policy.line.tortInput$limit.value-chip-wrapper");

    // Dynamically set by buffer Driver_1

    // Dynamically set by buffer UIMPD in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator UIMPD => _page.GetByTestId("fields.policy.line.underinsuredMotoristsPDInput$limit.value-chip-wrapper").GetByText("No Coverage");
    public ILocator UIMPD1000 => _page.GetByTestId("fields.policy.line.uninsuredMotoristsPDInput$deductible.value-chip-wrapper").Nth(2);

    // Dynamically set by buffer UMPD in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator UMPD => _page.GetByTestId("fields.policy.line.uninsuredMotoristsPDInput$limit.value-chip-wrapper").Nth(1);
    public ILocator UMPD1000000 => _page.GetByTestId("fields.policy.line.uninsuredMotoristsPDInput$limit.value-chip-wrapper").Nth(2);


    public ILocator PIPHeader => _page.GetByText("Personal Injury Protection");

    public ILocator PIPBasic15000 => _page.GetByTestId("fields.policy.line.pIPInput$limit.value-chip-label").GetByText("Basic - $15,000 per person/$30,000 per accident");
    public ILocator PIPDeductable => _page.GetByTestId("fields.policy.line.pIPInput$deductible.value-chip-label").GetByText("No Deductible");

    public ILocator LossOfIncomeCoverageHeader => _page.GetByText("Loss of Income Coverage");

    public ILocator UMPHeader => _page.GetByText(" Uninsured Motorists PD ");
    public ILocator UIMPDHeader => _page.GetByText(" Uninsured Motorist PD Deductible ");
    public ILocator UMPD100000 => _page.GetByTestId("fields.policy.line.uninsuredMotoristsPDInput$limit.value-chip-label").GetByText("$100,000");
    public ILocator UMIPD1000 => _page.GetByTestId("fields.policy.line.uninsuredMotoristsPDInput$deductible.value-chip-label").GetByText("$1,000");

    public ILocator TheftDeductibleV1 => _page.GetByTestId("fields.policy.line.risk.rows[0].covComprehensiveInput$theftDeductible.value-chip-label").GetByText("$200");
    public ILocator TheftDeductibleNoCoverageV2 => _page.GetByTestId("fields.policy.line.risk.rows[1].covComprehensiveInput$theftDeductible.value-chip-label").GetByText("No Coverage");
    public ILocator TheftDeductibleV3 => _page.GetByTestId("fields.policy.line.risk.rows[2].covComprehensiveInput$theftDeductible.value-chip-label").GetByText("$500");
}
