namespace PnCTestAutomation.Models
{
    /// <summary>
    /// Farm information for SFP (Special Farm Package)
    /// </summary>
    public class FarmData
    {
        public string PrimaryFarmType { get; set; }
        public string SecondaryFarmType { get; set; }
        public string SecondaryFarmSubType { get; set; }
        public string LivestockType { get; set; }
        public string GrossFarmIncome { get; set; }
        public string GrowIndustrialHemp { get; set; }

        // Location Properties
        public string LocationNickname { get; set; }
        public string LocationType { get; set; }
        public string MilesFromFireDepartment { get; set; }
        public string FeetFromHydrant { get; set; }
        public string PPC { get; set; }
        public string TotalAcreage { get; set; }

        // Coverage Properties
        public string Territory { get; set; }
        public string AllPerilDeductible { get; set; }
        public string WindHailDeductible { get; set; }
        public string HurricaneDeductible { get; set; }
        public bool HurricaneDeductibleOptional { get; set; }
        public string Narrative { get; set; }

        // Residence Properties
        public string ResidenceAdditionalDesc { get; set; }
        public string ResidenceYearBuilt { get; set; }
        public string ResidenceRateType { get; set; }
        public string ResidenceNumberOfFamilies { get; set; }
        public string ResidenceConditionRating { get; set; }
        public string ResidenceRoofYear { get; set; }
        public string ResidenceHeatingYear { get; set; }
        public string ResidencePlumbingYear { get; set; }
        public string ResidenceElectricalYear { get; set; }
        public string ResidenceRoofType { get; set; }
        public string ResidenceRoofImpact { get; set; }
        public string ResidenceSeasonalOrVacant { get; set; }
        public string ResidenceSolidFuelQuestion { get; set; }

        // Residence Coverage Properties
        public string ResidenceInsuranceAmount { get; set; }
        public string ResidenceSquareFeet { get; set; }
        public string ResidencePerils { get; set; }
        public string ResidenceThermostatQuestion { get; set; }
        public string ResidenceActualCashValue { get; set; }
        public string ResidenceRCTOption { get; set; }
        public string ResidenceUseDefaults { get; set; }
        public string CountryEstateHouseholdContentsAmount { get; set; }

        // Farm Personal Property
        public string FarmPropertyCode { get; set; }
        public string FarmPropertyDescription { get; set; }
        public string FarmPropertyLimit { get; set; }
        public string FarmPropertyDeductible { get; set; }

        // Scheduled Personal Property (Division IV)
        public string SPPCategory { get; set; }
        public string SPPItemType { get; set; }
        public string SPPDescription { get; set; }
        public string SPPLimit { get; set; }
        public string SPPValue { get; set; }
        public string SPPYearOfAppraisal { get; set; }

        // Liability
        public string LiabilityLimit { get; set; }
        public string LivestockHorses { get; set; }
        public string LivestockSmall { get; set; }
        public string LivestockLarge { get; set; }
        public string UnlistedAcreage { get; set; }
        public string NumberOfEmployees { get; set; }

        // Limited Farm Pollution
        public string LimitedFarmPollutionCoverageCode { get; set; }
        public string LimitedFarmPollutionCoverageName { get; set; }
        public string LimitedFarmPollutionRequiredBaseLiabilityLimit { get; set; }
        public string LimitedFarmPollutionOccurrenceAggregate { get; set; }
        public string LimitedFarmPollutionTotalOnsiteCapacity { get; set; }
        public string LimitedFarmPollutionFurthestLocationMiles { get; set; }
        public string LimitedFarmPollutionWasteTripsPerYear { get; set; }
        public string LimitedFarmPollutionAboveGroundTanks { get; set; }
        public string LimitedFarmPollutionTankCapacity { get; set; }
        public string LimitedFarmPollutionTankConstructionDate { get; set; }
        public string LimitedFarmPollutionEligibilityQuestions { get; set; }
        public string LimitedFarmPollutionExpectedReferralRule { get; set; }

        // Workers' Compensation - Residence Employees optional coverage (NH and similar states)
        public string WorkersCompFullTimeInServants { get; set; }
        public string WorkersCompPartTimeInServants { get; set; }
        public string WorkersCompFullTimeOutServants { get; set; }
        public string WorkersCompPartTimeOutServants { get; set; }

        // Insurance Score
        public string InsuranceScoreEntityType { get; set; }
        public string InsuranceScoreDesignee { get; set; }
        public string InsuranceScoreConsent { get; set; }

        // Mortgagee
        public string MortgageeName { get; set; }
        public string MortgageeAddress { get; set; }
        public string MortgageeSearchName { get; set; }
        public string MortgageeLocation { get; set; }
        public string MortgageeResidence { get; set; }
        public string MortgageeCopyOfDEC { get; set; }
        public string MortgageeAccountNumber { get; set; }
        public string MortgageeDescriptionOfInterest { get; set; }
        public string MortgageeEscrowBilled { get; set; }

        // Checklist
        public string ChecklistItemName { get; set; }
        public string ChecklistAction { get; set; }
        public string ChecklistExceptionNote { get; set; }
        public string ChecklistNote { get; set; }
    }
}
