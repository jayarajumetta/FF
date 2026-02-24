using Microsoft.Playwright;

namespace Playwright_POC.Pages
{
    public class SFP_FarmPersonalPropertyPage : BasePage
    {
        public SFP_FarmPersonalPropertyPage(IPage page) : base(page) { }

        // Search/Filter
        public ILocator FilterInput => _page.GetByTestId("temp.filter");
        public ILocator CoverageTable => _page.GetByTestId("coverageTable");

        // Coverage Checkboxes (by row index for flexibility)
        public ILocator CoverageCheckbox(int row) =>
            _page.GetByTestId($"fields.page.covCatEntry.rows[{row}].covCatEntryInput$selected.value");

        // Named Coverage Checkboxes
        public ILocator RentalReimbursementCheckbox => CoverageCheckbox(0);
        public ILocator AudioVisualDataElectronicEquipmentCheckbox => CoverageCheckbox(1);
        public ILocator SpecialSiloUnloaderCoverageCheckbox => CoverageCheckbox(2);
        public ILocator BorrowedRentedFarmMachineryBlanketCheckbox => CoverageCheckbox(3);
        public ILocator MultiFunctionalEquipmentCheckbox => CoverageCheckbox(4);
        public ILocator LivestockSpecificCheckbox => CoverageCheckbox(5);
        public ILocator LivestockBlanketCheckbox => CoverageCheckbox(6);
        public ILocator FarmMachinerySpecificCheckbox => CoverageCheckbox(7);
        public ILocator FarmMachineryBlanketCheckbox => CoverageCheckbox(8);
        public ILocator FarmProductsSuppliesToolsSpecificCheckbox => CoverageCheckbox(9);
        public ILocator FarmProductsSuppliesToolsBlanketCheckbox => CoverageCheckbox(10);
        public ILocator NurseryGreenhousePlantsCheckbox => CoverageCheckbox(11);
        public ILocator PACCropsFeedSuppliesCheckbox => CoverageCheckbox(12);
        public ILocator PACHayGrainStrawFodderCheckbox => CoverageCheckbox(13);
        public ILocator LivestockFreezingCheckbox => CoverageCheckbox(14);
        public ILocator TrellisGrowersCheckbox => CoverageCheckbox(15);

        // Navigation
        public ILocator NextButton => _page.GetByTestId("fields.data_Rules.nextEB");
    }
}
