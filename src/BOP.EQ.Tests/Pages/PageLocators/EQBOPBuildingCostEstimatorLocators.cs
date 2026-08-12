using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPBuildingCostEstimatorLocators
{
        public static ILocator CommercialButton(IPage page) =>
        page.GetByTestId("\"fields.data.account.building.rows[0].buildingValuatioinInput$structureType.value-chip-wrapper\"");

        public static ILocator BVSButton(IPage page) =>
        page.GetByTestId("\"fields.data.account.building.rows[0].buildingValuatioinInput$estimatorType.value-chip-wrapper\"");

        public static ILocator Frame(IPage page) =>
        page.GetByTestId("\"fields.data.account.building.rows[0].buildingInput$constructionCodeValuation.value-chip-wrapper\"");

        public static ILocator BVSGroupCombobox(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingValuatioinInput$bVSOccupancyGroup.value\"");

        // REVIEW: no stronger source locator.
    public static ILocator BVSGroup(IPage page) =>
        page.GetByText("{{buffer:BVS Group}}", new() { Exact = true });

        public static ILocator BVSResultsCombobox(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingValuatioinInput$bVSSearchResult.value\"");

        // REVIEW: no stronger source locator.
    public static ILocator BVSResult(IPage page) =>
        page.GetByText("{{buffer:BVS Result}}", new() { Exact = true });

        public static ILocator YearBuilt(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingInput$yearBuiltValuation.value\"");

    // REVIEW: preserved original selector.
        // REVIEW: no stronger source locator.
    public static ILocator RoofTypeMain(IPage page) =>
        page.Locator("xpath=\"id('BuildingInput.RoofTypeValuation-0-layout')/mat-form-field[1]\"");

        // REVIEW: no stronger source locator.
    public static ILocator RoofTypeSelection(IPage page) =>
        page.GetByText("{{buffer:Roof Type}}", new() { Exact = true });

        public static ILocator GetValuation(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Get Valuation", Exact = true });

        public static ILocator NumberOfStories(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingInput$numberOfStoriesValuation.value\"");

}
