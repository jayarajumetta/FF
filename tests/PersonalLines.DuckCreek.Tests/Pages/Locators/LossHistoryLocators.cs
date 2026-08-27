using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class LossHistoryLocators
{
    private readonly IPage _page;
    public LossHistoryLocators(IPage page) => _page = page;

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=Medium score=83
    // v56 raw Tosca primary: EQ || ClaimsViolation (NEW) | ComboBox | Id
    public ILocator CONTINUEDoesnTApply => _page.Locator("[id=\"\"fields.violations.violation.rows[0].violationInput$internalCode.value\"\"]");

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=High score=100
    public ILocator ClaimDriverNotInHousehold => _page.GetByTestId("fields.losses.loss.rows[0].lossInput$driverID.value-chip-wrapper");

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=High score=130
    public ILocator ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational => _page.GetByTestId("fields.losses.loss.rows[0].lossInput$driverNotInHouseholdReason.value-chip-wrapper");

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || ClaimsViolation (NEW) | ComboBox | Id
    // v56 semantic alias: same physical raw-Tosca control as CONTINUEDoesnTApply
    public ILocator ClaimViolationDoesNotApply => CONTINUEDoesnTApply;

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || ClaimsViolation (NEW) | ComboBox | Id
    // v56 semantic alias: same physical raw-Tosca control as CONTINUEDoesnTApply
    public ILocator ClaimViolationSaveAndContinue => CONTINUEDoesnTApply;

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Discount(NEW) | Next | Id
    public ILocator ClaimsViolationNEWNext => _page.Locator("[id=\"fields.data.next\"]");

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=High score=97
    // v56 raw Tosca primary: EQ || ClaimsViolation (NEW) | ComboBox | Id
    // v56 semantic alias: same physical raw-Tosca control as CONTINUEDoesnTApply
    public ILocator ComboBox => CONTINUEDoesnTApply;

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=High score=100
    public ILocator EditClaim => _page.GetByTestId("fields.policy.lineLosses.losses.loss.rows[\"{B[ClaimCount]}\"].edit_Claim_Detail");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ||Claims\Violations | confidence=Medium score=114
    // v56 raw Tosca primary: EQ||Claims\Violations | Drpdwn_Edit Violation | Id
    public ILocator UWCONTINUE => _page.Locator("[id=\"mat-select-value-51\"]");

}
