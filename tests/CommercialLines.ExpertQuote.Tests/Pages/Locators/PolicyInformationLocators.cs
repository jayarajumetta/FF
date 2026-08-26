using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class PolicyInformationLocators
{
    private readonly IPage _page;
    public PolicyInformationLocators(IPage page) => _page = page;

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=High score=130
    public ILocator AddSecondaryFarmTypeToggle => _page.GetByTestId("toggles-toggle-text");

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=High score=130
    public ILocator GrossFarmIncome => _page.GetByTestId("fields.account.policyInput$grossFarmIncome.value");

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=High score=100
    public ILocator IndustrialHempNo => _page.GetByTestId("fields.account.policyInput$industrialHemp.value-chip-wrapper");

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=High score=100
    public ILocator IndustrialHempYes => IndustrialHempNo; // semantic alias; locator defined once

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=High score=130
    public ILocator PrimaryFarmCategory => _page.GetByTestId("fields.account.policyInput$farmTypeCategory.value-chip-wrapper");

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=Medium score=108
    // v56 raw Tosca primary: EQ|SFP|Policy Details (Optimized) | Gross Farm Income | Id+Name+attributes_data-testid
    public ILocator PrimaryFarmType => _page.Locator("input[id=\"fields.account.policyInput$grossFarmIncome.value\"][name=\"fields.account.policyInput$grossFarmIncome.value\"][data-testid=\"fields.account.policyInput$grossFarmIncome.value\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=High score=130
    public ILocator SecondaryFarmCategory => _page.GetByTestId("fields.account.policyInput$farmTypeSecondaryCategory.value-chip-wrapper");

    // Source modules: EQ|SFP|Policy Details (Optimized) | confidence=Medium score=108
    // v56 raw Tosca primary: Policy Info|Required and Optional Fields | Secondary Farm Type | DuckCreekId
    public ILocator SecondaryFarmType => _page.Locator("[duckcreekid=\"PolicyInput.FarmTypeSecondary\"], [data-duckcreekid=\"PolicyInput.FarmTypeSecondary\"]");

}
