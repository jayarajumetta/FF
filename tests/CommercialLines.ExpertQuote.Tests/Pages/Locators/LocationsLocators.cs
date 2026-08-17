using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class LocationsLocators
{
    private readonly IPage _page;
    public LocationsLocators(IPage page) => _page = page;

    // Source modules: EQ|BOP|Locations|Edit Location | confidence=Medium score=113
    public ILocator EditLocationButtonLatestAngular => _page.GetByRole(AriaRole.Button, new() { Name = "Edit Location Button - Latest Angular***", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EditLocationHeading => _page.GetByText("Edit Location Heading", new() { Exact = true });

    // Source modules: EQ|SFP|Location | confidence=High score=127
    public ILocator FeetFromHydrant => _page.GetByRole(AriaRole.Combobox, new() { Name = "Feet from Hydrant", Exact = true });

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|SFP|Location | confidence=High score=127
    public ILocator LocationDescription => _page.GetByRole(AriaRole.Textbox, new() { Name = "Location Description", Exact = true });

    // Source modules: EQ|SFP|Location | confidence=Review score=97
    // Client Selection, Account Details, Proposal Start, Account, PreQualification, Primary Insured Details, Claims/Prior Insurance, Client Details, Narrative, Locations/Buildings, Policy Coverages, Additional Coverages, Addit
    public ILocator LocationLink => _page.GetByLabel("Location Link", new() { Exact = true });

    // Source modules: EQ|SFP|Location | confidence=High score=127
    public ILocator MilesFromFD => _page.GetByRole(AriaRole.Textbox, new() { Name = "Miles from FD", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator MilesFromFireDept => _page.GetByText("Miles From Fire Dept", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator OrderWildfireRiskScore => _page.GetByText("Order Wildfire Risk Score", new() { Exact = true });

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    public ILocator Save => _page.GetByTestId("fields.line.save");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Territory => _page.GetByText("Territory", new() { Exact = true });

    // Source modules: EQ|SFP|Location | confidence=High score=127
    public ILocator TotalFarmingAcreage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Farming Acreage", Exact = true });

    // Source modules: EQ|SFP|Location | confidence=High score=100
    public ILocator WindHail1 => _page.GetByTestId("fields.data.account.location3.rows[0].locationInput$windHailDeductible.value-chip-wrapper");

    // Source modules: EQ|SFP|Location | confidence=High score=100
    public ILocator WindHail2 => _page.GetByTestId("fields.data.account.location3.rows[0].locationInput$windHailDeductible.value-chip-wrapper");

    // Source modules: EQ|SFP|Location | confidence=High score=100
    public ILocator WindHail5 => _page.GetByTestId("fields.data.account.location3.rows[0].locationInput$windHailDeductible.value-chip-wrapper");

}
