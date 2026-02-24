using Microsoft.Playwright;

namespace Playwright_POC.Pages
{
    public class SFP_ScheduledPersonalPropertyPage : BasePage
    {
        public SFP_ScheduledPersonalPropertyPage(IPage page) : base(page) { }

        // Search/Filter
        public ILocator FilterInput => _page.GetByTestId("temp.filter");
        public ILocator CoverageTable => _page.GetByTestId("coverageTableSPP");

        // Coverage Checkboxes (by row index for flexibility)
        public ILocator CoverageCheckbox(int row) =>
            _page.GetByTestId($"fields.page.covCatEntry.rows[{row}].covCatEntryInput$selected.value");

        // Named Coverage Checkboxes - Division IV
        public ILocator AutoTrailerHomePersonalEffectsCheckbox => CoverageCheckbox(0);
        public ILocator BicyclesCheckbox => CoverageCheckbox(1);
        public ILocator CoinCollectionsCheckbox => CoverageCheckbox(2);
        public ILocator FineArtsCheckbox => CoverageCheckbox(3);
        public ILocator FursCheckbox => CoverageCheckbox(4);
        public ILocator GolfEquipmentCheckbox => CoverageCheckbox(5);
        public ILocator GunsCheckbox => CoverageCheckbox(6);
        public ILocator JewelryCheckbox => CoverageCheckbox(7);
        public ILocator MusicalInstrumentsNonProfessionalCheckbox => CoverageCheckbox(8);
        public ILocator MusicalInstrumentsProfessionalCheckbox => CoverageCheckbox(9);
        public ILocator PhotographyEquipmentCheckbox => CoverageCheckbox(10);
        public ILocator SignsCheckbox => CoverageCheckbox(11);
        public ILocator SilverwareCheckbox => CoverageCheckbox(12);
        public ILocator StampCollectionsCheckbox => CoverageCheckbox(13);
        public ILocator TouristsTravelersPersonalEffectsCheckbox => CoverageCheckbox(14);
        public ILocator WatercraftCheckbox => CoverageCheckbox(15);

        // Navigation
        public ILocator NextLiabilityButton => _page.GetByTestId("fields.data-Next.next");
    }
}
