using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class SocialSecurityLocators
{
    private readonly IPage _page;
    public SocialSecurityLocators(IPage page) => _page = page;

    public ILocator DriverInformation => _page.GetByLabel("Driver Information", new() { Exact = true });

    public ILocator PrefillDriverSNav => _page.GetByTestId("PrefillDriver_NotAdded-nav");

    public ILocator MATFORMFIELD => _page.GetByText("MAT-FORM-FIELD", new() { Exact = true });

    public ILocator PrefillReasonDropdowns => _page.Locator("mat-select[data-testid^='fields.line.prefillDriver.rows['][data-testid$='.prefillDriverInput$reasonForNotAdding.value']:visible");

    public ILocator PrefillReasonFirstOption => _page.Locator("[role='listbox']:visible [role='option']:not([aria-disabled='true'])").First;

    public ILocator NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS => _page.GetByRole(AriaRole.Listitem, new() { Name = "Never resided in the household and doesn't regularly use or have access to policy vehicle(s)", Exact = true });

    public ILocator PrefilledDrivers => _page.GetByText("Prefill Driver(s)", new() { Exact = true }).First;

    public ILocator PreFilledDriversRequired => _page.GetByText("Please provide the following information for each driver");
    // "Reason for not including this individual on the policy." mat-select dropdown.
    public ILocator ReasonForNotIncludingThisIndividualLabel => _page.Locator("mat-label.asterisk-after.dynamicLabelClass").Filter(new() { HasText = "Reason for not including this individual on the policy." });

    public ILocator GetReasonForNotIncludingThisIndividual(int row) =>
        _page.Locator($"[data-testid='fields.line.prefillDriver.rows[{row}].prefillDriverInput$reasonForNotAdding.value']");


    public ILocator SaveAndContinue => _page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true })
        .Or(_page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true }))
        .Or(_page.GetByTestId("fields.policy.next"));


    public ILocator State => _page.Locator("[id=\"proposal.ratingState\"]");


    public ILocator ReasonForNOnLivingResidencyRaymond => _page.Locator("//div[@id ='mat-select-value-8']");

    public ILocator ReasonForIndividualPropery => _page.Locator("//*[@id='mat-select-value-25']");

    public ILocator ReasonForNotIncludingProperty => _page.Locator("//*[@id=\"mat-select-value-16\"]");


    public ILocator UnselectedClientSuggestions => _page.GetByText("Unselected Client Suggestions", new() { Exact = true });

    public ILocator UnderWriterRulesHeader => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Underwriting Rules" });

    public ILocator CONTINUED555D => _page.Locator("[id=\"btnConfirmYes\"]");

}
