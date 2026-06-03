using Microsoft.Playwright;

namespace PnCTestAutomation.Pages
{
    public class SFP_OptionalCoveragesPage : BasePage
    {
        public SFP_OptionalCoveragesPage(IPage page) : base(page) { }

        // Farm and Business Income Coverage
        public ILocator FarmBusinessIncomeCoverageCheckbox =>
            _page.GetByTestId("fields.line.lineCoverages$isAnyFarmAndBusinessIncome.value");

        public ILocator LimitInput =>
            _page.GetByTestId("fields.line.covFarmBusinessIncome.covFarmBusinessIncomeInput$limit.value");

        public ILocator BusinessDescriptionInput =>
            _page.GetByTestId("fields.line.covFarmBusinessIncome.covFarmBusinessIncomeInput$businessDescription.value");

        public ILocator LeasedBuildingsNoButton =>
            _page.GetByTestId("fields.line.covFarmBusinessIncome.lineCoverages$isAnyFBILeasedBuildings.value-0");

        public ILocator LeasedBuildingsYesButton =>
            _page.GetByTestId("fields.line.covFarmBusinessIncome.lineCoverages$isAnyFBILeasedBuildings.value-1");

        // Unscheduled Buildings (row-based)
        public ILocator LocationSelect(int row = 0) =>
            _page.GetByTestId($"fields.line.covFarmBusinessIncome.farmBusinessUnschedBuildings.rows[{row}].farmBusinessUnschedBuildingsInput$locationID.value");

        public ILocator ConstructionCodeSelect(int row = 0) =>
            _page.GetByTestId($"fields.line.covFarmBusinessIncome.farmBusinessUnschedBuildings.rows[{row}].farmBusinessUnschedBuildingsInput$constructionCode.value");

        public ILocator YearBuiltInput(int row = 0) =>
            _page.GetByTestId($"fields.line.covFarmBusinessIncome.farmBusinessUnschedBuildings.rows[{row}].farmBusinessUnschedBuildingsInput$yearBuilt.value");

        public ILocator RoofTypeSelect(int row = 0) =>
            _page.GetByTestId($"fields.line.covFarmBusinessIncome.farmBusinessUnschedBuildings.rows[{row}].farmBusinessUnschedBuildingsInput$roofType.value");

        public ILocator RateTypeButton(int row = 0, int option = 0) =>
            _page.GetByTestId($"fields.line.covFarmBusinessIncome.farmBusinessUnschedBuildings.rows[{row}].farmBusinessUnschedBuildingsInput$rateType.value-{option}");

        public ILocator RateTypeMoreOptionsButton(int row = 0) =>
            _page.GetByTestId($"fields.line.covFarmBusinessIncome.farmBusinessUnschedBuildings.rows[{row}].farmBusinessUnschedBuildingsInput$rateType.value-other");

        public ILocator UnschedBuildingLimitInput(int row = 0) =>
            _page.GetByTestId($"fields.line.covFarmBusinessIncome.farmBusinessUnschedBuildings.rows[{row}].farmBusinessUnschedBuildingsInput$unschedBldLimit.value");

        public ILocator CoverageTypeSelect(int row = 0) =>
            _page.GetByTestId($"fields.line.covFarmBusinessIncome.farmBusinessUnschedBuildings.rows[{row}].farmBusinessUnschedBuildingsInput$coverageType.value");

        public ILocator DescriptionCodeSelect(int row = 0) =>
            _page.GetByTestId($"fields.line.covFarmBusinessIncome.farmBusinessUnschedBuildings.rows[{row}].farmBusinessUnschedBuildingsInput$descriptionCode.value");

        public ILocator AddLeasedBuildingButton =>
            _page.GetByTestId("fields.line.covFarmBusinessIncome.farmBusinessUnschedBuildings.addLeasedBuilding");

        // Navigation
        public ILocator NextButton => _page.GetByTestId("fields.data_RulesReview.next");
    }
}
