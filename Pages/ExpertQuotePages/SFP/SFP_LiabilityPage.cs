using Microsoft.Playwright;

namespace Playwright_POC.Pages
{
    public class SFP_LiabilityPage : BasePage
    {
        public SFP_LiabilityPage(IPage page) : base(page) { }

        // Form Fields
        public ILocator LivestockHorsesInput => _page.GetByTestId("fields.policy.line.liability.liabilityInput$livestockHorses.value");
        public ILocator LivestockSmallInput => _page.GetByTestId("fields.policy.line.liability.liabilityInput$livestockSmall.value");
        public ILocator LivestockLargeInput => _page.GetByTestId("fields.policy.line.liability.liabilityInput$livestockLarge.value");
        public ILocator NumberOfEmployeesInput => _page.GetByTestId("fields.policy.line.liability.liabilityInput$numberOfEmployees.value");
        public ILocator UnlistedAcreageInput => _page.GetByTestId("fields.policy.line.liability.lineInput$unlistedAcreage.value");
        public ILocator LimitSelect => _page.GetByTestId("fields.policy.line.liability.liabilityInput$limit.value");

        // Limit Dropdown Options
        public ILocator LimitOption(int index) => _page.GetByTestId($"fields.policy.line.liability.liabilityInput$limit.value-{index}");
        public ILocator Limit100K_100K => LimitOption(0);   // $100,000/$100,000
        public ILocator Limit100K_200K => LimitOption(1);   // $100,000/$200,000
        public ILocator Limit100K_300K => LimitOption(2);   // $100,000/$300,000
        public ILocator Limit200K_200K => LimitOption(3);   // $200,000/$200,000
        public ILocator Limit200K_500K => LimitOption(4);   // $200,000/$500,000
        public ILocator Limit200K_600K => LimitOption(5);   // $200,000/$600,000
        public ILocator Limit300K_300K => LimitOption(6);   // $300,000/$300,000
        public ILocator Limit300K_600K => LimitOption(7);   // $300,000/$600,000
        public ILocator Limit300K_1M => LimitOption(8);     // $300,000/$1,000,000
        public ILocator Limit500K_500K => LimitOption(9);   // $500,000/$500,000
        public ILocator Limit500K_1M => LimitOption(10);    // $500,000/$1,000,000
        public ILocator Limit500K_1_5M => LimitOption(11);  // $500,000/$1,500,000
        public ILocator Limit1M_1M => LimitOption(12);      // $1,000,000/$1,000,000
        public ILocator Limit1M_2M => LimitOption(13);      // $1,000,000/$2,000,000
        public ILocator Limit1M_3M => LimitOption(14);      // $1,000,000/$3,000,000

        // Search/Filter
        public ILocator FilterInput => _page.GetByTestId("temp.filter");
        public ILocator CoverageTable => _page.GetByTestId("coverageTableLiability");

        // Base Liability Toggle
        public ILocator BaseLiabilityYesButton => _page.GetByTestId("fields.policy.line.lineCoverages$isBaseLiability.value-0");
        public ILocator BaseLiabilityNoButton => _page.GetByTestId("fields.policy.line.lineCoverages$isBaseLiability.value-1");

        // Coverage Checkboxes (by row index for flexibility)
        public ILocator CoverageCheckbox(int row) =>
            _page.GetByTestId($"fields.policy.line.liabilityCovCat.liabilityCovCatEntry.rows[{row}].liabilityCovCatEntryInput$selected.value");

        // Business Liability Coverages
        public ILocator AgriculturalProductsProcessingCheckbox => CoverageCheckbox(0);
        public ILocator RetailSalesFarmStandsCheckbox => CoverageCheckbox(1);
        public ILocator EquineOperationsCheckbox => CoverageCheckbox(2);
        public ILocator AnimalCareServicesForOthersCheckbox => CoverageCheckbox(3);
        public ILocator LivestockServicesCheckbox => CoverageCheckbox(4);
        public ILocator LessorsRiskCheckbox => CoverageCheckbox(5);
        public ILocator FarmingAndRanchSupplyCheckbox => CoverageCheckbox(6);
        public ILocator LimitedCustomFarmingCheckbox => CoverageCheckbox(7);
        public ILocator IncidentalBusinessPursuitsCheckbox => CoverageCheckbox(8);
        public ILocator AgritainmentCheckbox => CoverageCheckbox(9);
        public ILocator HarvestYourOwnCheckbox => CoverageCheckbox(10);
        public ILocator StorageBoatsCarsCampersCheckbox => CoverageCheckbox(11);
        public ILocator OilGasWellsOperatedByOthersCheckbox => CoverageCheckbox(12);

        // Optional Liability Coverages
        public ILocator NamedInsuredMedicalExpensesCheckbox => CoverageCheckbox(13);
        public ILocator AdditionalResidenceOwnerOccupiedCheckbox => CoverageCheckbox(14);
        public ILocator ExcessMedicalExpensesCheckbox => CoverageCheckbox(15);
        public ILocator FarmEmployeeCoverageCheckbox => CoverageCheckbox(16);
        public ILocator SnowmobileATVGolfCartOffPremiseCheckbox => CoverageCheckbox(17);
        public ILocator WatercraftCheckbox => CoverageCheckbox(18);
        public ILocator SeasonalLaborHousingCheckbox => CoverageCheckbox(19);
        public ILocator ExcessFireLegalLiabilityCheckbox => CoverageCheckbox(20);
        public ILocator ImplementsDrawnCheckbox => CoverageCheckbox(21);
        public ILocator CareCustodyControlCheckbox => CoverageCheckbox(22);
        public ILocator AdditionalInsuredsCheckbox => CoverageCheckbox(23);
        public ILocator EmployeeBenefitsLiabilityCheckbox => CoverageCheckbox(24);
        public ILocator EmploymentPracticesLiabilityCheckbox => CoverageCheckbox(25);

        // Exclusion Coverages
        public ILocator DesignatedServicesActivitiesExclusionCheckbox => CoverageCheckbox(26);
        public ILocator DesignatedAnimalsExclusionCheckbox => CoverageCheckbox(27);
        public ILocator DesignatedPremiseExclusionCheckbox => CoverageCheckbox(28);
        public ILocator DesignatedWorkExclusionCheckbox => CoverageCheckbox(29);
        public ILocator HazardsDesignatedFarmTypesExclusionCheckbox => CoverageCheckbox(30);
        public ILocator PersonalAdvertisingInjuryExclusionCheckbox => CoverageCheckbox(31);

        // Limitation Coverages
        public ILocator ContractualLiabilityLimitationCheckbox => CoverageCheckbox(32);
        public ILocator SpecificProductsExclusionCheckbox => CoverageCheckbox(33);
        public ILocator SpecificProductsPropertyDamageExclusionCheckbox => CoverageCheckbox(34);
        public ILocator DamageForMilkSpecialDeductibleCheckbox => CoverageCheckbox(35);
        public ILocator FailureToSupplyExclusionCheckbox => CoverageCheckbox(36);

        // Navigation
        public ILocator BackButton => _page.GetByTestId("fields.data.back");
        public ILocator NextMortgageeLossPayeeButton => _page.GetByTestId("fields.data.next");
    }
}
