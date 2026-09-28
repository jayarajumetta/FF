using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class VehiclesLocators
{
    private readonly IPage _page;
    public VehiclesLocators(IPage page) => _page = page;

    public ILocator AddCoverage => _page.GetByTestId("*ddBicycles*");

    public ILocator ClientInfoSearch => _page.Locator("input[id=\"customer.name.first\"][name=\"customer.name.first\"]");

    public ILocator Description => _page.Locator("input[id=\"fields.risk.rows[0].businessPersonalPropertyInventorySheet.businessPersonalPropertyInventorySheetScheduled.rows[0].businessPersonalPropertyInventorySheetScheduledInput$description.value\"][name=\"fields.risk.rows[0].businessPersonalPropertyInventorySheet.businessPersonalPropertyInventorySheetScheduled.rows[0].businessPersonalPropertyInventorySheetScheduledInput$description.value\"]");

    public ILocator Limit => _page.Locator("input[id=\"fields.covEndorsements.rows[0].covEndorsementsInput$limit.value\"][name=\"fields.covEndorsements.rows[0].covEndorsementsInput$limit.value\"]");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator Save => _page.Locator("button[id=\"fields.data.save\"], button[data-testid=\"fields.line.save\"], button:has-text(\"Save\"), a:has-text(\"Save\")").First;

    public ILocator ScheduledPersonalPropertyHeader => _page.Locator("input[id=\"fields.page.covCatEntry.rows[1].covCatEntryInput$selected.value-input\"][name=\"fields.page.covCatEntry.rows[1].covCatEntryInput$selected.value\"]");

    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    public ILocator SearchByNameOrCode => _page.Locator("input[id=\"temp.filter\"][name=\"temp.filter\"]");

    public ILocator True => _page.GetByText("True", new() { Exact = true });

    public ILocator YearOfLastAppraisal => _page.Locator("input[id=\"fields.covEndorsements.rows[0].covEndorsementsInput$yearOfLastAppraisal.value\"][name=\"fields.covEndorsements.rows[0].covEndorsementsInput$yearOfLastAppraisal.value\"]");

}
