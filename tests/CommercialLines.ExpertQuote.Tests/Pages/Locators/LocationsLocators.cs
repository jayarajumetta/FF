using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class LocationsLocators
{
    private readonly IPage _page;
    public LocationsLocators(IPage page) => _page = page;

    public ILocator EditLocationButtonLatestAngular => _page.Locator("[id=\"fields.data.accountDetail.locationDetail.rows[0].editLocation\"]");

    public ILocator EditLocationHeading => _page.GetByText("Edit Location Heading", new() { Exact = true });

    public ILocator FeetFromHydrant => _page.Locator("[id=\"fields.data.account.location.rows[0].locationInput$feetFromHydrant.value\"]");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator LocationDescription => _page.Locator("input[id=\"fields.data.account.location.rows[0].locationInput$additionalDescription.value\"][name=\"fields.data.account.location.rows[0].locationInput$additionalDescription.value\"]");

    // Client Selection, Account Details, Proposal Start, Account, PreQualification, Primary Insured Details, Claims/Prior Insurance, Client Details, Narrative, Locations/Buildings, Policy Coverages, Additional Coverages, Addit

    public ILocator MilesFromFD => _page.Locator("input[id=\"fields.data.account.location.rows[0].locationInput$milesFromFireDepartment.value\"][name=\"fields.data.account.location.rows[0].locationInput$milesFromFireDepartment.value\"]");

    public ILocator MilesFromFireDept => _page.Locator("input[id=\"fields.data.account.location.locationBusinessOwnersInput$milesFromFireDepartment.value\"][name=\"fields.data.account.location.locationBusinessOwnersInput$milesFromFireDepartment.value\"]");

    public ILocator OrderWildfireRiskScore => _page.GetByText("Order Wildfire Risk Score", new() { Exact = true });

    public ILocator Save => _page.Locator("button[id=\"fields.data.saveLocation\"], button:has-text(\"Save\"), a:has-text(\"Save\")").First;

    public ILocator Territory => _page.Locator("mat-select[id=\"fields.data.account.location.locationBusinessOwnersInput$territory.value\"][data-testid=\"fields.data.account.location.locationBusinessOwnersInput$territory.value\"]");

    public ILocator TotalFarmingAcreage => _page.Locator("input[id=\"fields.data.account.location2.rows[0].locationInput$acreage.value\"][name=\"fields.data.account.location2.rows[0].locationInput$acreage.value\"]");

    public ILocator WindHail1 => _page.GetByTestId("fields.data.account.location3.rows[0].locationInput$windHailDeductible.value-chip-wrapper");



}
