using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class SocialSecurityLocators
{
    private readonly IPage _page;
    public SocialSecurityLocators(IPage page) => _page = page;

    public ILocator DriverInformation => _page.GetByLabel("Driver Information", new() { Exact = true });

    public ILocator MATFORMFIELD => _page.GetByText("MAT-FORM-FIELD", new() { Exact = true });

    public ILocator NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS => _page.GetByRole(AriaRole.Listitem, new() { Name = "Never resided in the household and doesn't regularly use or have access to policy vehicle(s)", Exact = true });

    public ILocator PrefilledDrivers => _page.GetByText("PrefilledDrivers", new() { Exact = true });

    public ILocator SaveAndContinue => _page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

    public ILocator State => _page.Locator("[id=\"proposal.ratingState\"]");

    public ILocator UnselectedClientSuggestions => _page.GetByText("Unselected Client Suggestions", new() { Exact = true });

}
