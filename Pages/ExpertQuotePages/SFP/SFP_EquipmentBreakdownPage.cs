using Microsoft.Playwright;

namespace Playwright_POC.Pages
{
    public class SFP_EquipmentBreakdownPage : BasePage
    {
        public SFP_EquipmentBreakdownPage(IPage page) : base(page) { }

        // Power Generation Questions
        public ILocator PowerGenerationYesButton =>
            _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$powerGeneration.value-chip-item-wrapper")
                 .Filter(new() { HasText = "Yes" }).First;
        public ILocator PowerGenerationNoButton =>
            _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$powerGeneration.value-chip-item-wrapper")
                 .Filter(new() { HasText = "No" }).First;

        public ILocator TwoOrMoreLossIn24MonthYesButton =>
            _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$twoOrMoreLossIn24Month.value-chip-item-wrapper")
                 .Filter(new() { HasText = "Yes" }).First;
        public ILocator TwoOrMoreLossIn24MonthNoButton =>
            _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$twoOrMoreLossIn24Month.value-chip-item-wrapper")
                 .Filter(new() { HasText = "No" }).First;

        public ILocator LossGreaterThan24KEverYesButton =>
            _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$lossGreaterThan24KEver.value-chip-item-wrapper")
                 .Filter(new() { HasText = "Yes" }).First;
        public ILocator LossGreaterThan24KEverNoButton =>
            _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$lossGreaterThan24KEver.value-chip-item-wrapper")
                 .Filter(new() { HasText = "No" }).First;

        // Coverage Limit Selects
        public ILocator DataRestorationSelect => _page.GetByTestId("fields.line.covEquipmentBreakdown.covEquipmentBreakdownInput$dataRestoration.value");
        public ILocator ExpeditingExpenseSelect => _page.GetByTestId("fields.line.covEquipmentBreakdown.covEquipmentBreakdownInput$expeditingExpense.value");
        public ILocator HazardousSubstancesSelect => _page.GetByTestId("fields.line.covEquipmentBreakdown.covEquipmentBreakdownInput$hazardousSubstances.value");
        public ILocator NurseryGreenhouseSelect => _page.GetByTestId("fields.line.covEquipmentBreakdown.covEquipmentBreakdownInput$nurseryGreenhouse.value");
        public ILocator SpoilageSelect => _page.GetByTestId("fields.line.covEquipmentBreakdown.covEquipmentBreakdownInput$spoilage.value");
        public ILocator CombinedDeductibleSelect => _page.GetByTestId("fields.line.covEquipmentBreakdown.covEquipmentBreakdownInput$combinedDed.value");

        // Farm Implement Coverage
        public ILocator FarmImplementYesButton =>
            _page.GetByTestId("fields.line.covEquipmentBreakdownContent.covEquipmentBreakdownInput$farmImplement.value-chip-item-wrapper")
                 .Filter(new() { HasText = "Yes" }).First;
        public ILocator FarmImplementNoButton =>
            _page.GetByTestId("fields.line.covEquipmentBreakdownContent.covEquipmentBreakdownInput$farmImplement.value-chip-item-wrapper")
                 .Filter(new() { HasText = "No" }).First;
    }
}
