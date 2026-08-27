using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class LocationsLocators
{
    private readonly IPage _page;
    public LocationsLocators(IPage page) => _page = page;

    // Source modules: EQ|BOP|Locations|Edit Location | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|BOP|Locations|Edit Location | Edit Location | Id
    public ILocator EditLocationButtonLatestAngular => _page.Locator("[id=\"\"fields.data.accountDetail.locationDetail.rows[0].editLocation\"\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EditLocationHeading => _page.GetByText("Edit Location Heading", new() { Exact = true });

    // Source modules: EQ|SFP|Location | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Location | Feet from Hydrant | Id
    public ILocator FeetFromHydrant => _page.Locator("[id=\"\"fields.data.account.location.rows[0].locationInput$feetFromHydrant.value\"\"]");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|SFP|Location | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Location | Location Description | Id+Name
    public ILocator LocationDescription => _page.Locator("input[id=\"\\\"fields.data.account.location.rows[0].locationInput$additionalDescription.value\\\"\"][name=\"\\\"fields.data.account.location.rows[0].locationInput$additionalDescription.value\\\"\"]");

    // Source modules: EQ|SFP|Location | confidence=Review score=97
    // Client Selection, Account Details, Proposal Start, Account, PreQualification, Primary Insured Details, Claims/Prior Insurance, Client Details, Narrative, Locations/Buildings, Policy Coverages, Additional Coverages, Addit
    // v56 raw Tosca primary: EQ|SFP|Location | Location Description | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as LocationDescription
    public ILocator LocationLink => LocationDescription;

    // Source modules: EQ|SFP|Location | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Location | Miles from FD | Id+Name
    public ILocator MilesFromFD => _page.Locator("input[id=\"\\\"fields.data.account.location.rows[0].locationInput$milesFromFireDepartment.value\\\"\"][name=\"\\\"fields.data.account.location.rows[0].locationInput$milesFromFireDepartment.value\\\"\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: Territory and FD | Miles From Fire Dept | Id+Name
    public ILocator MilesFromFireDept => _page.Locator("input[id=\"fields.data.account.location.locationBusinessOwnersInput$milesFromFireDepartment.value\"][name=\"fields.data.account.location.locationBusinessOwnersInput$milesFromFireDepartment.value\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator OrderWildfireRiskScore => _page.GetByText("Order Wildfire Risk Score", new() { Exact = true });

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    // v56 raw Tosca primary:  | Save | DuckCreekId | frame=iframe
    public ILocator Save => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Save\"], [data-duckcreekid=\"Save\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: EQ|BOP|Locations|Add/Edit Location | Territory | Id+attributes_data-testid
    public ILocator Territory => _page.Locator("mat-select[id=\"fields.data.account.location.locationBusinessOwnersInput$territory.value\"][data-testid=\"fields.data.account.location.locationBusinessOwnersInput$territory.value\"]");

    // Source modules: EQ|SFP|Location | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Location | Total Farming Acreage | Id+Name
    public ILocator TotalFarmingAcreage => _page.Locator("input[id=\"\\\"fields.data.account.location2.rows[0].locationInput$acreage.value\\\"\"][name=\"\\\"fields.data.account.location2.rows[0].locationInput$acreage.value\\\"\"]");

    // Source modules: EQ|SFP|Location | confidence=High score=100
    public ILocator WindHail1 => _page.GetByTestId("fields.data.account.location3.rows[0].locationInput$windHailDeductible.value-chip-wrapper");

    // Source modules: EQ|SFP|Location | confidence=High score=100
    public ILocator WindHail2 => WindHail1; // semantic alias; locator defined once

    // Source modules: EQ|SFP|Location | confidence=High score=100
    public ILocator WindHail5 => WindHail1; // semantic alias; locator defined once

}
