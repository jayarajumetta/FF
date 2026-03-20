using Playwright_POC.Models;

namespace Playwright_POC.Helpers
{
    /// <summary>
    /// Scenario context data using composition with domain models.
    /// Legacy property names are preserved for backward compatibility.
    /// New code should use the domain model objects directly (Client, Address, Driver, etc.)
    /// </summary>
    public class ScenarioContextData
    {
        // ══════════════════════════════════════════════════════════════════
        // DOMAIN MODELS (New code should use these directly)
        // ══════════════════════════════════════════════════════════════════

        public ClientData Client { get; set; } = new();
        public AddressData Address { get; set; } = new();
        public DriverData Driver { get; set; } = new();
        public VehicleData VehicleInfo { get; set; } = new();
        public PolicyData Policy { get; set; } = new();
        public PaymentData Payment { get; set; } = new();
        public AdditionalInterestData AdditionalInterest { get; set; } = new();
        public PriorInsuranceData PriorInsuranceInfo { get; set; } = new();
        public BusinessData Business { get; set; } = new();
        public FarmData Farm { get; set; } = new();
        public UnderwritingData Underwriting { get; set; } = new();

        // --- Forms Validation ---
        public string FormsLob { get; set; }
        public string FormsTestCase { get; set; }

        // ══════════════════════════════════════════════════════════════════
        // LEGACY PROPERTIES (Backward compatible - delegate to domain models)
        // ══════════════════════════════════════════════════════════════════

        // --- Client Info (maps to Client) ---
        public string ClientFirstName { get => Client.FirstName; set => Client.FirstName = value; }
        public string ClientMiddleName { get => Client.MiddleName; set => Client.MiddleName = value; }
        public string ClientLastName { get => Client.LastName; set => Client.LastName = value; }
        public string ClientDOB { get => Client.DateOfBirth; set => Client.DateOfBirth = value; }
        public string ClientPhoneNumber { get => Client.Phone; set => Client.Phone = value; }
        public string ClientEmail { get => Client.Email; set => Client.Email = value; }
        public string MaritalStatus { get => Client.MaritalStatus; set => Client.MaritalStatus = value; }
        public string Gender { get => Client.Gender; set => Client.Gender = value; }
        public string SSN { get => Client.SSN; set => Client.SSN = value; }
        public string PhoneType { get => Client.PhoneType; set => Client.PhoneType = value; }
        public string EmailType { get => Client.EmailType; set => Client.EmailType = value; }

        // --- Address Info (maps to Address) ---
        public string StreetAddress { get => Address.Street; set => Address.Street = value; }
        public string AptNumber { get => Address.AptNumber; set => Address.AptNumber = value; }
        public string City { get => Address.City; set => Address.City = value; }
        public string State { get => Address.State; set => Address.State = value; }
        public string ZipCode { get => Address.ZipCode; set => Address.ZipCode = value; }
        public string RecievedMail { get => Address.ReceivesMail; set => Address.ReceivesMail = value; }
        public string WhereClientResides { get => Address.IsResidence; set => Address.IsResidence = value; }

        // --- Policy Info (maps to Policy) ---
        public string QuoteNumber { get => Policy.QuoteNumber; set => Policy.QuoteNumber = value; }
        public string EffectiveDate { get => Policy.EffectiveDate; set => Policy.EffectiveDate = value; }
        public string PolicyTerm { get => Policy.PolicyTerm; set => Policy.PolicyTerm = value; }
        public string AgentCode { get => Policy.AgentCode; set => Policy.AgentCode = value; }
        public string RatingState { get => Policy.RatingState; set => Policy.RatingState = value; }
        public string WritingCompany { get => Policy.WritingCompany; set => Policy.WritingCompany = value; }
        public string RiskAddress { get => Policy.RiskAddress; set => Policy.RiskAddress = value; }
        public string OwnershipType { get => Policy.OwnershipType; set => Policy.OwnershipType = value; }
        public string LessorRisk { get => Policy.LessorRisk; set => Policy.LessorRisk = value; }
        public string EligibilityRestrictions { get => Policy.EligibilityRestrictions; set => Policy.EligibilityRestrictions = value; }
        public string PolicyCoverage { get => Policy.PolicyCoverage; set => Policy.PolicyCoverage = value; }
        public string CompCollOnly { get => Policy.CompCollOnly; set => Policy.CompCollOnly = value; }
        public string CompDeductible { get => Policy.CompDeductible; set => Policy.CompDeductible = value; }
        public string CollDeductible { get => Policy.CollDeductible; set => Policy.CollDeductible = value; }
        public string AccidentalDeathAndDismemberment { get => Policy.AccidentalDeathAndDismemberment; set => Policy.AccidentalDeathAndDismemberment = value; }
        public string LossOfIncome { get => Policy.LossOfIncome; set => Policy.LossOfIncome = value; }
        public string RentalReimbursement { get => Policy.RentalReimbursement; set => Policy.RentalReimbursement = value; }
        public string RoadsideAssistance { get => Policy.RoadsideAssistance; set => Policy.RoadsideAssistance = value; }
        public string PolicyDiscount { get => Policy.PolicyDiscount; set => Policy.PolicyDiscount = value; }
        public string BenefitXpressDiscount { get => Policy.BenefitXpressDiscount; set => Policy.BenefitXpressDiscount = value; }
        public string AccountCompositionDiscount { get => Policy.AccountCompositionDiscount; set => Policy.AccountCompositionDiscount = value; }

        // --- Driver Info (maps to Driver) ---
        public string DriverFirstName { get => Driver.FirstName; set => Driver.FirstName = value; }
        public string DriverLastName { get => Driver.LastName; set => Driver.LastName = value; }
        public string DriverDOB { get => Driver.DateOfBirth; set => Driver.DateOfBirth = value; }
        public string DriverPhoneNumber { get => Driver.Phone; set => Driver.Phone = value; }
        public string DriverEmail { get => Driver.Email; set => Driver.Email = value; }
        public string DriverState { get => Driver.LicenseState; set => Driver.LicenseState = value; }
        public string NamedInsured { get => Driver.IsNamedInsured; set => Driver.IsNamedInsured = value; }
        public string OperatorStatus { get => Driver.OperatorStatus; set => Driver.OperatorStatus = value; }
        public string DLState { get => Driver.LicenseState; set => Driver.LicenseState = value; }
        public string DLNumber { get => Driver.LicenseNumber; set => Driver.LicenseNumber = value; }
        public string YearsLicensed { get => Driver.YearsLicensed; set => Driver.YearsLicensed = value; }
        public string MonthsLicensed { get => Driver.MonthsLicensed; set => Driver.MonthsLicensed = value; }
        public string FinancialResponsibility { get => Driver.FinancialResponsibility; set => Driver.FinancialResponsibility = value; }
        public string DriverStatus { get => Driver.DriverStatus; set => Driver.DriverStatus = value; }
        public string RelationshipToAccountOwner { get => Driver.RelationshipToAccountOwner; set => Driver.RelationshipToAccountOwner = value; }

        // --- Vehicle Info (maps to VehicleInfo) ---
        public string VINNumber { get => VehicleInfo.VIN; set => VehicleInfo.VIN = value; }
        public string VehicleType { get => VehicleInfo.VehicleType; set => VehicleInfo.VehicleType = value; }
        public string VehicleYear { get => VehicleInfo.Year; set => VehicleInfo.Year = value; }
        public string VehicleMake { get => VehicleInfo.Make; set => VehicleInfo.Make = value; }
        public string VehicleModel { get => VehicleInfo.Model; set => VehicleInfo.Model = value; }
        public string VehicleTrim { get => VehicleInfo.Trim; set => VehicleInfo.Trim = value; }
        public string VehicleOwnership { get => VehicleInfo.Ownership; set => VehicleInfo.Ownership = value; }
        public string VehicleUsage { get => VehicleInfo.Usage; set => VehicleInfo.Usage = value; }
        public string CustomizedEquipment { get => VehicleInfo.CustomizedEquipment; set => VehicleInfo.CustomizedEquipment = value; }
        public string PurchaseDate { get => VehicleInfo.PurchaseDate; set => VehicleInfo.PurchaseDate = value; }
        public string OdometerReading { get => VehicleInfo.OdometerReading; set => VehicleInfo.OdometerReading = value; }
        public string AnnualMileage { get => VehicleInfo.AnnualMileage; set => VehicleInfo.AnnualMileage = value; }
        public string Vehicle { get; set; }  // Legacy standalone property

        // --- Prior Insurance (maps to PriorInsuranceInfo) ---
        public string PriorInsurance { get => PriorInsuranceInfo.HasPriorInsurance; set => PriorInsuranceInfo.HasPriorInsurance = value; }
        public string PriorCarrier { get => PriorInsuranceInfo.CarrierName; set => PriorInsuranceInfo.CarrierName = value; }
        public string PriorPolicyNumber { get => PriorInsuranceInfo.PolicyNumber; set => PriorInsuranceInfo.PolicyNumber = value; }
        public string PriorInsuranceYears { get => PriorInsuranceInfo.YearsWithCarrier; set => PriorInsuranceInfo.YearsWithCarrier = value; }
        public string PriorInsuranceMonths { get => PriorInsuranceInfo.MonthsWithCarrier; set => PriorInsuranceInfo.MonthsWithCarrier = value; }
        public string NoPriorInsuranceReason { get => PriorInsuranceInfo.NoPriorInsuranceReason; set => PriorInsuranceInfo.NoPriorInsuranceReason = value; }
        public bool PriorFFANPolicy { get => PriorInsuranceInfo.PriorFFANPolicy; set => PriorInsuranceInfo.PriorFFANPolicy = value; }
        public string YearsInBusiness { get => PriorInsuranceInfo.YearsInBusiness; set => PriorInsuranceInfo.YearsInBusiness = value; }
        public string YearsContinuousCoverage { get => PriorInsuranceInfo.YearsContinuousCoverage; set => PriorInsuranceInfo.YearsContinuousCoverage = value; }
        public string PriorInsuranceExpDate { get => PriorInsuranceInfo.PriorInsuranceExpDate; set => PriorInsuranceInfo.PriorInsuranceExpDate = value; }
        public string PriorInsuranceCarrier { get => PriorInsuranceInfo.PriorInsuranceCarrier; set => PriorInsuranceInfo.PriorInsuranceCarrier = value; }

        // --- Additional Interest (maps to AdditionalInterest) ---
        public string AdditionalInterestType { get => AdditionalInterest.Type; set => AdditionalInterest.Type = value; }
        public string AdditionalInterestName { get => AdditionalInterest.Name; set => AdditionalInterest.Name = value; }
        public string AdditionalInterestAddress { get => AdditionalInterest.Address; set => AdditionalInterest.Address = value; }
        public string AdditionalInterestCity { get => AdditionalInterest.City; set => AdditionalInterest.City = value; }
        public string AdditionalInterestState { get => AdditionalInterest.State; set => AdditionalInterest.State = value; }
        public string AdditionalInterestZipCode { get => AdditionalInterest.ZipCode; set => AdditionalInterest.ZipCode = value; }
        public string AdditionalInterestPhone { get => AdditionalInterest.Phone; set => AdditionalInterest.Phone = value; }
        public string JointOwnerDrive { get => AdditionalInterest.JointOwnerDrive; set => AdditionalInterest.JointOwnerDrive = value; }
        public string AdditionalInterestDOB { get => AdditionalInterest.DateOfBirth; set => AdditionalInterest.DateOfBirth = value; }
        public string AdditionalInterestDLNumber { get => AdditionalInterest.LicenseNumber; set => AdditionalInterest.LicenseNumber = value; }
        public string AdditionalInterestLicenseState { get => AdditionalInterest.LicenseState; set => AdditionalInterest.LicenseState = value; }

        // --- Payment (maps to Payment) ---
        public string PrimaryPayer { get => Payment.PrimaryPayer; set => Payment.PrimaryPayer = value; }
        public string PaymentType { get => Payment.PaymentType; set => Payment.PaymentType = value; }
        public string PaymentPlan { get => Payment.PaymentPlan; set => Payment.PaymentPlan = value; }
        public string PaymentDueDate { get => Payment.PaymentDueDate; set => Payment.PaymentDueDate = value; }
        public string PaymentAmount { get => Payment.PaymentAmount; set => Payment.PaymentAmount = value; }
        public string PaymentMethod { get => Payment.PaymentMethod; set => Payment.PaymentMethod = value; }
        public string CheckNumber { get => Payment.CheckNumber; set => Payment.CheckNumber = value; }
        public string Paperless { get => Payment.Paperless; set => Payment.Paperless = value; }
        public string RoutingNumber { get => Payment.RoutingNumber; set => Payment.RoutingNumber = value; }
        public string AccountNumber { get => Payment.AccountNumber; set => Payment.AccountNumber = value; }
        public string BankName { get => Payment.BankName; set => Payment.BankName = value; }

        // --- Business (BOP - maps to Business) ---
        public string BusinessEntity { get => Business.EntityType; set => Business.EntityType = value; }
        public string DBAName { get => Business.DBAName; set => Business.DBAName = value; }
        public string LessorRiskExposure { get => Business.LessorRiskExposure; set => Business.LessorRiskExposure = value; }
        public string ClassCodeNumber { get => Business.ClassCodeNumber; set => Business.ClassCodeNumber = value; }
        public string ClassDescription { get => Business.ClassDescription; set => Business.ClassDescription = value; }
        public string ClassCodeRestriction { get => Business.ClassCodeRestriction; set => Business.ClassCodeRestriction = value; }

        // --- Farm (SFP - maps to Farm) ---
        public string PrimaryFarmType { get => Farm.PrimaryFarmType; set => Farm.PrimaryFarmType = value; }
        public string SecondaryFarmType { get => Farm.SecondaryFarmType; set => Farm.SecondaryFarmType = value; }
        public string SecondaryFarmSubType { get => Farm.SecondaryFarmSubType; set => Farm.SecondaryFarmSubType = value; }
        public string LivestockType { get => Farm.LivestockType; set => Farm.LivestockType = value; }
        public string GrossFarmIncome { get => Farm.GrossFarmIncome; set => Farm.GrossFarmIncome = value; }
        public string GrowIndustrialHemp { get => Farm.GrowIndustrialHemp; set => Farm.GrowIndustrialHemp = value; }
        public string LocationNickname { get => Farm.LocationNickname; set => Farm.LocationNickname = value; }
        public string LocationType { get => Farm.LocationType; set => Farm.LocationType = value; }
        public string MilesFromFireDepartment { get => Farm.MilesFromFireDepartment; set => Farm.MilesFromFireDepartment = value; }
        public string FeetFromHydrant { get => Farm.FeetFromHydrant; set => Farm.FeetFromHydrant = value; }
        public string PPC { get => Farm.PPC; set => Farm.PPC = value; }
        public string TotalAcreage { get => Farm.TotalAcreage; set => Farm.TotalAcreage = value; }
        public string WindHailDeductible { get => Farm.WindHailDeductible; set => Farm.WindHailDeductible = value; }
        public string Narrative { get => Farm.Narrative; set => Farm.Narrative = value; }

        // --- Residence (SFP - maps to Farm) ---
        public string ResidenceAdditionalDesc { get => Farm.ResidenceAdditionalDesc; set => Farm.ResidenceAdditionalDesc = value; }
        public string ResidenceYearBuilt { get => Farm.ResidenceYearBuilt; set => Farm.ResidenceYearBuilt = value; }
        public string ResidenceRateType { get => Farm.ResidenceRateType; set => Farm.ResidenceRateType = value; }
        public string ResidenceNumberOfFamilies { get => Farm.ResidenceNumberOfFamilies; set => Farm.ResidenceNumberOfFamilies = value; }
        public string ResidenceConditionRating { get => Farm.ResidenceConditionRating; set => Farm.ResidenceConditionRating = value; }
        public string ResidenceRoofYear { get => Farm.ResidenceRoofYear; set => Farm.ResidenceRoofYear = value; }
        public string ResidenceRoofType { get => Farm.ResidenceRoofType; set => Farm.ResidenceRoofType = value; }
        public string ResidenceRoofImpact { get => Farm.ResidenceRoofImpact; set => Farm.ResidenceRoofImpact = value; }
        public string ResidenceSeasonalOrVacant { get => Farm.ResidenceSeasonalOrVacant; set => Farm.ResidenceSeasonalOrVacant = value; }
        public string ResidenceSolidFuelQuestion { get => Farm.ResidenceSolidFuelQuestion; set => Farm.ResidenceSolidFuelQuestion = value; }

        // --- Residence Coverage (SFP - maps to Farm) ---
        public string ResidenceInsuranceAmount { get => Farm.ResidenceInsuranceAmount; set => Farm.ResidenceInsuranceAmount = value; }
        public string ResidenceSquareFeet { get => Farm.ResidenceSquareFeet; set => Farm.ResidenceSquareFeet = value; }
        public string ResidencePerils { get => Farm.ResidencePerils; set => Farm.ResidencePerils = value; }
        public string ResidenceThermostatQuestion { get => Farm.ResidenceThermostatQuestion; set => Farm.ResidenceThermostatQuestion = value; }
        public string ResidenceActualCashValue { get => Farm.ResidenceActualCashValue; set => Farm.ResidenceActualCashValue = value; }
        public string ResidenceRCTOption { get => Farm.ResidenceRCTOption; set => Farm.ResidenceRCTOption = value; }
        public string ResidenceUseDefaults { get => Farm.ResidenceUseDefaults; set => Farm.ResidenceUseDefaults = value; }

        // --- Farm Personal Property (SFP - maps to Farm) ---
        public string FarmPropertyCode { get => Farm.FarmPropertyCode; set => Farm.FarmPropertyCode = value; }
        public string FarmPropertyDescription { get => Farm.FarmPropertyDescription; set => Farm.FarmPropertyDescription = value; }
        public string FarmPropertyLimit { get => Farm.FarmPropertyLimit; set => Farm.FarmPropertyLimit = value; }
        public string FarmPropertyDeductible { get => Farm.FarmPropertyDeductible; set => Farm.FarmPropertyDeductible = value; }

        // --- Scheduled Personal Property (SFP - maps to Farm) ---
        public string SPPCategory { get => Farm.SPPCategory; set => Farm.SPPCategory = value; }
        public string SPPItemType { get => Farm.SPPItemType; set => Farm.SPPItemType = value; }
        public string SPPDescription { get => Farm.SPPDescription; set => Farm.SPPDescription = value; }
        public string SPPLimit { get => Farm.SPPLimit; set => Farm.SPPLimit = value; }
        public string SPPValue { get => Farm.SPPValue; set => Farm.SPPValue = value; }
        public string SPPYearOfAppraisal { get => Farm.SPPYearOfAppraisal; set => Farm.SPPYearOfAppraisal = value; }

        // --- Liability (SFP - maps to Farm) ---
        public string LiabilityLimit { get => Farm.LiabilityLimit; set => Farm.LiabilityLimit = value; }
        public string LivestockHorses { get => Farm.LivestockHorses; set => Farm.LivestockHorses = value; }
        public string LivestockSmall { get => Farm.LivestockSmall; set => Farm.LivestockSmall = value; }
        public string LivestockLarge { get => Farm.LivestockLarge; set => Farm.LivestockLarge = value; }
        public string UnlistedAcreage { get => Farm.UnlistedAcreage; set => Farm.UnlistedAcreage = value; }
        public string NumberOfEmployees { get => Farm.NumberOfEmployees; set => Farm.NumberOfEmployees = value; }

        // --- Insurance Score (SFP - maps to Farm) ---
        public string InsuranceScoreEntityType { get => Farm.InsuranceScoreEntityType; set => Farm.InsuranceScoreEntityType = value; }
        public string InsuranceScoreDesignee { get => Farm.InsuranceScoreDesignee; set => Farm.InsuranceScoreDesignee = value; }
        public string InsuranceScoreConsent { get => Farm.InsuranceScoreConsent; set => Farm.InsuranceScoreConsent = value; }

        // --- Mortgagee (SFP - maps to Farm) ---
        public string MortgageeName { get => Farm.MortgageeName; set => Farm.MortgageeName = value; }
        public string MortgageeAddress { get => Farm.MortgageeAddress; set => Farm.MortgageeAddress = value; }
        public string MortgageeSearchName { get => Farm.MortgageeSearchName; set => Farm.MortgageeSearchName = value; }
        public string MortgageeLocation { get => Farm.MortgageeLocation; set => Farm.MortgageeLocation = value; }
        public string MortgageeResidence { get => Farm.MortgageeResidence; set => Farm.MortgageeResidence = value; }
        public string MortgageeCopyOfDEC { get => Farm.MortgageeCopyOfDEC; set => Farm.MortgageeCopyOfDEC = value; }
        public string MortgageeAccountNumber { get => Farm.MortgageeAccountNumber; set => Farm.MortgageeAccountNumber = value; }
        public string MortgageeDescriptionOfInterest { get => Farm.MortgageeDescriptionOfInterest; set => Farm.MortgageeDescriptionOfInterest = value; }
        public string MortgageeEscrowBilled { get => Farm.MortgageeEscrowBilled; set => Farm.MortgageeEscrowBilled = value; }

        // --- Checklist (SFP - maps to Farm) ---
        public string ChecklistItemName { get => Farm.ChecklistItemName; set => Farm.ChecklistItemName = value; }
        public string ChecklistAction { get => Farm.ChecklistAction; set => Farm.ChecklistAction = value; }
        public string ChecklistExceptionNote { get => Farm.ChecklistExceptionNote; set => Farm.ChecklistExceptionNote = value; }
        public string ChecklistNote { get => Farm.ChecklistNote; set => Farm.ChecklistNote = value; }

        // --- Underwriting (maps to Underwriting) ---
        public string GeneralUWQuestionAnswer { get => Underwriting.GeneralAnswer; set => Underwriting.GeneralAnswer = value; }

        // --- Misc (no domain model) ---
        public string SearchType { get; set; }
        public string LookingFor { get; set; }
    }
}
