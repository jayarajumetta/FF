using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class LossHistoryLocators
{
    private readonly IPage _page;
    public LossHistoryLocators(IPage page) => _page = page;

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=Medium score=83
    public ILocator CONTINUEDoesnTApply => _page.GetByRole(AriaRole.Link, new() { Name = "CONTINUE_Doesn'tApply", Exact = true });

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=High score=100
    public ILocator ClaimDriverNotInHousehold => _page.GetByTestId("fields.losses.loss.rows[0].lossInput$driverID.value-chip-wrapper");

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=High score=130
    public ILocator ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational => _page.GetByTestId("fields.losses.loss.rows[0].lossInput$driverNotInHouseholdReason.value-chip-wrapper");

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=Medium score=113
    public ILocator ClaimViolationDoesNotApply => _page.GetByRole(AriaRole.Button, new() { Name = "claim/violationDoes Not Apply", Exact = true });

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=Medium score=113
    public ILocator ClaimViolationSaveAndContinue => _page.GetByRole(AriaRole.Button, new() { Name = "claim/violationSave and Continue", Exact = true });

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=Medium score=113
    public ILocator ClaimsViolationNEWNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=High score=97
    public ILocator ComboBox => _page.GetByRole(AriaRole.Combobox, new() { Name = "ComboBox", Exact = true });

    // Source modules: EQ || ClaimsViolation (NEW) | confidence=High score=100
    public ILocator EditClaim => _page.GetByTestId("fields.policy.lineLosses.losses.loss.rows[\"{B[ClaimCount]}\"].edit_Claim_Detail");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ||Claims\Violations | confidence=Medium score=114
    public ILocator UWCONTINUE => _page.GetByRole(AriaRole.Link, new() { Name = "Lnk_UW_CONTINUE", Exact = true });

}