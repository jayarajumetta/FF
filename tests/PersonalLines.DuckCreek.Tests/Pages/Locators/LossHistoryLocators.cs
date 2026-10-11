using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class LossHistoryLocators
{
    private readonly IPage _page;
    public LossHistoryLocators(IPage page) => _page = page;

    public ILocator CONTINUEDoesnTApply => _page.Locator("[id=\"fields.violations.violation.rows[0].violationInput$internalCode.value\"]");

    public ILocator ClaimDriverNotInHousehold => _page.GetByTestId("fields.losses.loss.rows[0].lossInput$driverID.value-chip-wrapper");

    public ILocator ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational => _page.GetByTestId("fields.losses.loss.rows[0].lossInput$driverNotInHouseholdReason.value-chip-wrapper");



    public ILocator ClaimsViolationNEWNext => _page.Locator("[id=\"fields.data.next\"]");


    public ILocator EditClaim => _page.GetByTestId("fields.policy.lineLosses.losses.loss.rows[\"{B[ClaimCount]}\"].edit_Claim_Detail");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator UWCONTINUE => _page.Locator("[id=\"mat-select-value-51\"]");

}
