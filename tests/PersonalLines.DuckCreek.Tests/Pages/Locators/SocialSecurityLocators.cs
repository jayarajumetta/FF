using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class SocialSecurityLocators
{
    private readonly IPage _page;
    public SocialSecurityLocators(IPage page) => _page = page;

    // Source modules: EQ | Side Menu | confidence=Medium score=108
    public ILocator DriverInformation => _page.GetByLabel("Driver Information", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator MATFORMFIELD => _page.GetByText("MAT-FORM-FIELD", new() { Exact = true });

    // Source modules: EQ || Prefil Household Drivers | confidence=Medium score=113
    public ILocator NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS => _page.GetByRole(AriaRole.Listitem, new() { Name = "Never resided in the household and doesn't regularly use or have access to policy vehicle(s)", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator PrefilledDrivers => _page.GetByText("PrefilledDrivers", new() { Exact = true });

    // Source modules: EQ || Prefil Household Drivers | confidence=Medium score=113
    public ILocator SaveAndContinue => _page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=High score=97
    // v56 raw Tosca primary: EQ || Proposal Details/Start | State | Id
    public ILocator State => _page.Locator("[id=\"proposal.ratingState\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator UnselectedClientSuggestions => _page.GetByText("Unselected Client Suggestions", new() { Exact = true });

}
