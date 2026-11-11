using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class LossHistoryLocators
{
    private readonly IPage _page;
    public LossHistoryLocators(IPage page) => _page = page;

    public ILocator CONTINUEDoesnTApply => _page.Locator("[id=\"fields.violations.violation.rows[0].violationInput$internalCode.value\"]");

    public ILocator ClaimDriverNotInHousehold => _page.GetByTestId("fields.losses.loss.rows[0].lossInput$driverID.value-chip-label").Filter(new() { HasText = "Driver Not In Household" });

    public ILocator GetClaimDriverNotInHousehold(int row) =>
        _page.GetByTestId($"fields.losses.loss.rows[{row}].lossInput$driverID.value-chip-label").Filter(new() { HasText = "Driver Not In Household" });

    public ILocator ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational => _page.GetByTestId("fields.losses.loss.rows[0].lossInput$driverNotInHouseholdReason.value-chip-wrapper");

    public ILocator NeverLivedInHouseholdOrInsuredHasNoKnowledgeOfThisPerson => _page.GetByTestId("fields.losses.loss.rows[0].lossInput$driverNotInHouseholdReason.value-chip-label").Filter(new() { HasText = "Never lived in household or insured has no knowledge of this person" });

    public ILocator GetNeverLivedInHouseholdOrInsuredHasNoKnowledgeOfThisPerson(int row) =>
        _page.GetByTestId($"fields.losses.loss.rows[{row}].lossInput$driverNotInHouseholdReason.value-chip-label").Filter(new() { HasText = "Never lived in household or insured has no knowledge of this person" });

    public ILocator ClaimsViolationNEWNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });
    public ILocator EditClaim => _page.Locator("button[data-testid=\"fields.policy.lineLosses.losses.loss.rows[0].edit_Claim_Detail\"]");

    public ILocator GetEditClaim(int row) =>
        _page.Locator($"button[data-testid=\"fields.policy.lineLosses.losses.loss.rows[{row}].edit_Claim_Detail\"]");

    //public ILocator ClaimsRequiringEdit => _page.Locator("tr.anico-data-table-row-invalid")
        //.Filter(new() { Has = _page.Locator("button[data-testid^='fields.policy.lineLosses.losses.loss.rows['][data-testid$='].edit_Claim_Detail']") });

    public ILocator RequiredClaimEditButtons => ClaimsRequiringEdit.Locator("button[data-testid$='].edit_Claim_Detail']");

    public ILocator ClaimEditButton(string testId) => _page.Locator("button").And(_page.GetByTestId(testId));

    public ILocator ClaimDetail => _page.Locator("#page-Claim_Detail");

    public ILocator ClaimDriverOutsideHousehold => ClaimDetail.Locator("[data-testid$='.lossInput$driverID.value-chip-wrapper']")
        .Filter(new() { HasTextRegex = new System.Text.RegularExpressions.Regex(@"^\s*Driver Not In Household\s*$") });

    public ILocator ClaimLoanedVehicleReason => ClaimDetail.Locator("[data-testid$='.lossInput$driverNotInHouseholdReason.value-chip-wrapper']")
        .Filter(new() { HasTextRegex = new System.Text.RegularExpressions.Regex(@"(?i)vehicle loaned to driver that does not") });

    public ILocator ClaimSaveAndContinue => ClaimDetail.GetByTestId("fields.losses.loss.claim_Detail_Done");

    public ILocator ViolationsRequiringEdit => _page.Locator("tr.anico-data-table-row-invalid")
        .Filter(new() { Has = _page.Locator("button[data-testid^='fields.policy.lineViolations.violations.violation.rows['][data-testid$='].edit_Violation_Detail']") });


    public ILocator ViolationEditButton(string testId) => _page.Locator("button").And(_page.GetByTestId(testId));

    public ILocator ViolationCode => _page.Locator("mat-select[data-testid^='fields.violations.violation.rows['][data-testid$='].violationInput$internalCode.value']:visible");

    public ILocator ViolationSaveAndContinue => _page.GetByTestId("fields.violations.violation.violation_Detail_Done");

    public ILocator ClaimsRequiringEdit => _page.Locator("tr.anico-data-table-row-invalid")
        .Filter(new() { Has = _page.Locator("button[data-testid^='fields.policy.lineLosses.losses.loss.rows['][data-testid$='].edit_Claim_Detail']") });


    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator UWCONTINUE => _page.Locator("[data-testid='fields.policy.next-button-label']").Filter(new() { HasText = "Next" });

    public ILocator ClaimsViolationsHeader => _page.Locator("h1").Filter(new() { HasText = "Claims/Violations" });

    public ILocator VerifyAndUpdateClaimsInstruction => _page.Locator("div.text-instruction").Filter(new() { HasText = "Verify and update claims as requested" });

    public ILocator ClaimDetailDone => _page.GetByTestId("fields.losses.loss.claim_Detail_Done-button-label").Filter(new() { HasText = "Save and Continue" });

    public ILocator ClaimDateLabel => _page.Locator("div").Filter(new() { HasText = "Claim Date" }).First;

    public ILocator GetClaimDateLabel(int row) =>
        _page.Locator("div").Filter(new() { HasText = "Claim Date" }).Nth(row);

    public ILocator ClaimsViolationsNav => _page.GetByTestId("Claims_Violations-nav");

    public ILocator RequiredViolationEditButtons => ViolationsRequiringEdit.Locator("button[data-testid$='].edit_Violation_Detail']");
}
