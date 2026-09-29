using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class NavigationLocators
{
    private readonly IPage _page;
    public NavigationLocators(IPage page) => _page = page;

    public ILocator StateDetailsDriveOtherCarFirstName => _page.Locator("input[fieldref=\"RiskDriveOtherCarIteratorInput.FirstName\"]");
    public ILocator StateDetailsDriveOtherCarLastName => _page.Locator("input[fieldref=\"RiskDriveOtherCarIteratorInput.LastName\"]");
    public ILocator CommercialAutoEffectiveDate => _page.Locator("input[fieldref='OtherInsuranceHistoryInput.EffectiveDate'], input[fieldref='UmbrellaGeneralLiabilityInput.EffectiveDate'], input[fieldref=\"UmbrellaSFP10LiabilityInput.EffectiveDate\"], input[fieldref=\"UmbrellaEmployersLiabilityInput.EffectiveDate\"], input[fieldref=\"UmbrellaCommercialAutoInput.EffectiveDate\"]");
    public ILocator CommercialAutoExpiryDateDate => _page.Locator("input[fieldref=\"UmbrellaCommercialAutoInput.ExpirationDate\"]");
    public ILocator LiquifiedGas => _page.Locator("input[fieldref=\"UmbrellaBusinessOwnersInput.PetroleumGasExposure\"]");
    public ILocator GeneralLiabilityExpirationDate => _page.Locator("input[fieldref='OtherInsuranceHistoryInput.ExpirationDate'], input[fieldref='UmbrellaGeneralLiabilityInput.ExpirationDate'], input[fieldref=\"UmbrellaSFP10LiabilityInput.ExpirationDate\"], input[fieldref=\"UmbrellaEmployersLiabilityInput.ExpirationDate\"], input[fieldref=\"UmbrellaCommercialAutoInput.ExpirationDate\"]");
    public ILocator CommercialAutoPolicyNumber => _page.Locator("input[fieldref=\"UmbrellaCommercialAutoInput.PolicyNumber\"]");
    public ILocator GeneralLiabilityPolicyNumber => _page.Locator("input[fieldref='OtherInsuranceHistoryInput.PolicyNumber'], input[fieldref='UmbrellaGeneralLiabilityInput.PolicyNumber'], input[fieldref=\"UmbrellaSFP10LiabilityInput.PolicyNumber\"]");
    public ILocator CPPLiabilityPolicyNumber => _page.Locator("input[fieldref='UmbrellaCPPLiabilityInput.PolicyNumber']");
    public ILocator UMBLimit => _page.Locator("input[fieldref=\"UmbrellaCommercialAutoInput.UMLimit\"]");
    public ILocator OtherInsuranceHistoryLimit => _page.Locator("input[fieldref='OtherInsuranceHistoryInput.Limit']");
    public ILocator GeneralLiabilityTotalSubjectPremium => _page.Locator("input[fieldref=\"UmbrellaGeneralLiabilityInputPremiums.TotalSubjectPremium\"], input[fieldref=\"UmbrellaSFP10LiabilityInput.TotalSubjectPremium\"], input[fieldref=\"UmbrellaEmployersLiabilityInput.TotalSubjectPremium\"], input[fieldref=\"UmbrellaCommercialAutoInput.TotalSubjectPremium\"]");

    public ILocator SFP10LiabilityFarmLiabilityLimit => _page.Locator("input[fieldref=\"UmbrellaSFP10LiabilityInput.LiabilityLimit\"]");
    public ILocator DescriptionOfActivities => _page.Locator("[fieldref='CovEndorsementsInput.Description']");
    public ILocator CoverageFormDescription => _page.Locator("input[fieldref=\"CoverageFormsInput.Description\"]");
    public ILocator CoverageEndorsementType => _page.Locator("input[fieldref=\"CovEndorsementsInput.Type\"]");
    public ILocator LineEndorsementType => _page.Locator("input[fieldref=\"LineOutputNonShredded.EndorsementType\"]");
    public ILocator AdditionalOtherInterestType => _page.Locator("input[fieldref='AdditionalOtherInterestInput.Type']");

    public ILocator AVCostNew => _page.Locator("input[fieldref=\"CovAudioVisualInput.CostNew\"]");

    public ILocator AWhatIsThePublicProtectionClassRating => _page.Locator("input[fieldref=\"BaileesCustomerUnderwritingQuestionsInput.PublicProtectionClass\"]");
    public ILocator farmliabilityCoverageof1000000 => _page.Locator("input[fieldref=\"UmbrellaSFP10LiabilityInput.SFP10FarmEmployeeCoverage\"]");
    public ILocator AcceptUM => _page.GetByText("Accept UM", new() { Exact = true });

    //public ILocator PageTitle => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Loss Experience" });

    public ILocator Billing => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Billing" });

    public ILocator Notepad => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Notepad" });

    public ILocator LossExperience => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Loss Experience" });

    public ILocator MotorTruckCargo => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Motor Truck Cargo" });
    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator GeneralLiabilityHeader => _page.GetByText("General Liability", new() { Exact = true });


    public ILocator Pricing => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing", Exact = true });


    public ILocator SFP10LiabilityFarm => _page.GetByRole(AriaRole.Link, new() { Name = "SFP - 10 Liability/Farm", Exact = true });

    public ILocator Endorsement => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsements", Exact = true }).Or(_page.GetByRole(AriaRole.Link, new() { Name = "Endorsement", Exact = true }));

    public ILocator UMQuestionsUmbrella => _page.GetByRole(AriaRole.Link, new() { Name = "UW Questions - Umbrella", Exact = true });

    public ILocator AddInterests => _page.GetByRole(AriaRole.Link, new() { Name = "Addl Interests", Exact = true });
    public ILocator ProductsOrCompletedOps => _page.GetByText("Products/Completed Ops");
    public ILocator Endorsements => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsements", Exact = true });
    public ILocator CGL => _page.GetByRole(AriaRole.Link, new() { Name = "CGL", Exact = true });


    public ILocator PolicyInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Info", Exact = true });

    public ILocator CPPLiability => _page.GetByRole(AriaRole.Link, new() { Name = "CPP Liability", Exact = true });

    public ILocator Location => _page.GetByRole(AriaRole.Link, new() { Name = "Location", Exact = true });

    public ILocator LossOfExperience => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Loss Experience" });
    public ILocator AccountsReceivableUWQuestions => _page.GetByText("Accounts Receivable UW Questions", new() { Exact = true });

    public ILocator Add => _page.GetByRole(AriaRole.Link, new() { Name = "Add", Exact = true });

    public ILocator Risk => _page.GetByRole(AriaRole.Link, new() { Name = "Risk", Exact = true });

    public ILocator AddAddlInterest => _page.GetByRole(AriaRole.Link, new() { Name = "Add Addl Interest", Exact = true }).First;

    public ILocator AddBuilding => _page.GetByRole(AriaRole.Link, new() { Name = "Add Building", Exact = true });

    public ILocator AddClass => _page.GetByRole(AriaRole.Link, new() { Name = "Add Class", Exact = true });


    public ILocator CG0078Detail => _page.Locator("//tr[.//*[contains(text(),'Employment Practices Liability Insurance Coverage Endorsement (VT)')]]//span[.='Detail']");

    public ILocator AddClassCode => _page.GetByRole(AriaRole.Link, new() { Name = "Add Class Code", Exact = true });

    public ILocator OK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator AddCoverageForm => _page.GetByRole(AriaRole.Link, new() { Name = "Add Coverage Form", Exact = true });

    public ILocator AddDriver => _page.GetByRole(AriaRole.Link, new() { Name = "Add Driver", Exact = true });

    public ILocator AddDriverName => _page.Locator("input[fieldref=\"ExcludeDriver.ExcludedDriver\"]");

    public ILocator AddEndorsement => _page.GetByRole(AriaRole.Link, new() { Name = "Add Endorsement", Exact = true });


    public ILocator AddExcludedOfficerInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Excluded Officer Information", Exact = true });

    public ILocator AddExcludedOthersInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Excluded Others' Information", Exact = true });

    public ILocator AddGroup => _page.GetByRole(AriaRole.Link, new() { Name = "Add Group", Exact = true });

    public ILocator AddNotesRemarks => _page.GetByRole(AriaRole.Link, new() { Name = "Add Notes/Remarks", Exact = true });

    public ILocator AddOptionA => _page.GetByRole(AriaRole.Link, new() { Name = "Add Option A", Exact = true });

    public ILocator AddOtherInterest => _page.GetByRole(AriaRole.Link, new() { Name = "Add Other Interest", Exact = true });

    public ILocator AddOthersInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Others' Information", Exact = true });

    public ILocator AddPartnerInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Partner Information", Exact = true });

    public ILocator AddPremises => _page.GetByRole(AriaRole.Link, new() { Name = "Add Premises", Exact = true });

    public ILocator AddPriorCarrier => _page.GetByRole(AriaRole.Link, new() { Name = "Add Prior Carrier", Exact = true });

    public ILocator AddRiskAtThisLocation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Risk at This Location", Exact = true });

    public ILocator AddSoleProprietorInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Sole Proprietor Information", Exact = true });

    public ILocator AddThirdParty => _page.GetByRole(AriaRole.Link, new() { Name = "Add Third Party", Exact = true });


    public ILocator AdditionalOtherInterestAddress => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.Address1\"]");

    public ILocator AdditionalOtherInterestInputFirstName => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.FirstName\"]");

    public ILocator AdditionalOtherInterestInputLastName => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.LastName\"]");

    public ILocator PageTop => _page.Locator("[id=\"pageTop\"]");

    public ILocator Submission => _page.GetByRole(AriaRole.Link, new() { Name = "Submission", Exact = true });


    public ILocator completeApplication => _page.GetByText("Complete Application");

    public ILocator Address => _page.Locator("input[fieldref=\"CovEndorsmentIteratorNonShreddedInput.Address\"]:visible, input[fieldref=\"AdditionalOtherInterestInput.Address1\"]:visible");

    public ILocator GLOCPRiskAddress => _page.Locator("input[fieldref=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderAddress1\"]");

    public ILocator LocationAddress => _page.Locator("input[fieldref=\"LocationInput.Address1\"]");

    public ILocator AddressStreetCityStateZip => _page.Locator("input[fieldref=\"BaileesCustomersPropertyAwayFromYourPremises.Address\"]");

    public ILocator AggregateLimit => _page.Locator("input[fieldref=\"LineInput.PolicyAggregateLimit\"]");

    public ILocator AnnualGrossReceipts => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.AnnualGrossReceipts\"]");

    public ILocator AnyPersonalAutoPolicyListingNameInsured => _page.Locator("input[fieldref=\"UnderwritingQuestionsAutoInput.AnyPersonalAutoPolicyListingNameInsured\"]");

    public ILocator AnyVehicleCoveredRegisteredInNotPrimaryState => _page.Locator("input[fieldref=\"UnderwritingQuestionsAutoInput.AnyVehicleCoveredRegisteredInNotPrimaryState\"]");

    public ILocator AreAnySignsOffPremisesOrNotAttachedToBuilding => _page.Locator("input[fieldref=\"SignsUnderwritingQuestionsInput.Indicator\"]:visible").Nth(0);

    public ILocator ArePhysicalsRequiredAfterOffersOfEmploymentAreMade => _page.Locator("input[fieldref=\"UnderwritingQuestionsWorkersCompInput.PhysicalsRequiredAfterEmploymentOffers\"]");

    public ILocator AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy => _page.Locator("input[fieldref=\"UnderwritingQuestionsAutoInput.AnyCommercialVehiclesOwned\"]");

    public ILocator AreThereAnyOfficersThatShouldBeExcluded => _page.Locator("input[fieldref=\"LineInput.EntityOfficersExclusion\"]");

    public ILocator AssignLocation => _page.GetByRole(AriaRole.Link, new() { Name = "Assign Location", Exact = true });

    public ILocator AssignLocations => _page.GetByRole(AriaRole.Link, new() { Name = "Assign Locations", Exact = true });

    public ILocator AudioVisual => _page.Locator("input[fieldref=\"CovAudioVisualInput.AudioVisual\"]");

    public ILocator AvailableClassifications => _page.Locator("input[fieldref=\"CPPPackagePMAOutputNonshredded.AvailablePMAOccupancyTypes\"]");

    public ILocator AverageNumberOfDaysService => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.AverageNumberOfDaysService\"]");

    public ILocator AverageNumberOfWorkingDays => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.AverageNumberOfWorkingDays\"]");

    public ILocator AverageServiceCharge => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.AverageServiceCharge\"]");

    public ILocator AverageValuePerOrder => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.AverageValuePerOrder\"]");

    public ILocator BAreThereAnyPrivateProtectionImprovements => _page.Locator("input[fieldref=\"BaileesCustomerUnderwritingQuestionsInput.PrivateProtectionIndicator\"]");

    public ILocator BG2Symbol => _page.Locator("input[fieldref=\"BuildingInput.BG2Symbol\"]");

    public ILocator BG2SymbolPrefix => _page.Locator("input[fieldref=\"BuildingInput.BG2SymbolPrefix\"]");

    public ILocator BaileesCustomerUWQuestions => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Bailees Customer" });

    public ILocator BaileesCustomersHeading => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Bailees Customers", Exact = true });

    public ILocator BillType => _page.Locator("input[fieldref=\"BillingDetailInput.BillType\"]");



    public ILocator BodyStyle => _page.Locator("input[fieldref=\"RiskVehicleInput.BodyStyle\"]");

    public ILocator BoomDeductible => _page.Locator("input[fieldref=\"ContractorsEquipmentInput.BoomDeductible\"]");

    public ILocator BorrowingHiringOrLeasingWithinYear => _page.Locator("input[fieldref=\"UnderwritingQuestionsAutoInput.BorrowingHiringOrLeasingWithinYear\"]");


    public ILocator BuildingLimit => _page.Locator("xpath=(//*[self::input or self::textarea or self::select][@fieldref='RiskPropertyInput.Limit'][@aria-label='Building Limit' or @placeholder='Building Limit'] | //*[(self::label or self::span or self::div or self::td) and normalize-space(string(.))='Building Limit']/following::*[self::input or self::textarea or self::select][@fieldref='RiskPropertyInput.Limit'][1])");

    public ILocator RiskInputRatingGroupID => _page.Locator("input[fieldref=\"RiskInput.RatingGroupID\"]");

    public ILocator BusinessInterruptionDescriptionOfScheduledProperty => _page.Locator("input[fieldref=\"BusinessInterruptionOptionAInput.DescriptionOfScheduledProperty\"]");


    public ILocator BusinessInterruptionEndorsement => _page.Locator("input[fieldref=\"LineCoveragesInput.BusinessInterruptionEndorsement\"]");

    public ILocator BusinessInterruptionLimitOfInsurance => _page.Locator("input[fieldref=\"BusinessInterruptionOptionAInput.LimitOfInsurance\"]");

    public ILocator CA2325LeasedWorkersCoverage => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='[CA2325] Leased Workers Coverage']/@for] | //label[normalize-space(string(.))='[CA2325] Leased Workers Coverage']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='[CA2325] Leased Workers Coverage']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator CA9940ContractProvisions => _page.Locator("input[fieldref=\"CovEndorsementsInput.ContractProvisions\"]");

    public ILocator CA9940Make => _page.Locator("input[fieldref=\"CovEndorsementsInput.Make\"]");

    public ILocator CA9940Model => _page.Locator("input[fieldref=\"CovEndorsementsInput.Model\"]");

    public ILocator CA9940VIN => _page.Locator("input[fieldref=\"CovEndorsementsInput.VIN\"]");

    public ILocator CA9940Year => _page.Locator("input[fieldref=\"CovEndorsementsInput.Year\"]");

    public ILocator CA9948ClassesOfCommoditiesTransported => _page.Locator("input[fieldref=\"CovEndorsementsInput.ClassesOfCommoditiesTransported\"]");

    public ILocator ExcludeUndergroundPropertyDamageHazard => _page.Locator("input[fieldref=\"CovEndorsementsInput.IndicatorPropertyDamageCG2142\"]");


    public ILocator CGLLimits => _page.Locator("input[fieldref=\"UmbrellaGeneralLiabilityInputLimitsNonShredded.CGLLimits\"], input[fieldref=\"UmbrellaEmployersLiabilityInput.LiabilityLimit\"], input[fieldref=\"UmbrellaCommercialAutoInput.LiabilityLimit\"]");


    public ILocator CWhatIsTheDistanceInFeetToTheNearestHydrant => _page.Locator("input[fieldref=\"BaileesCustomerUnderwritingQuestionsInput.HydrantDistance\"]");

    public ILocator CallISO => _page.GetByRole(AriaRole.Link, new() { Name = "Call ISO", Exact = true });

    public ILocator Carrier => _page.Locator("input[fieldref='OtherInsuranceHistoryInput.CarrierName'],input[fieldref='CommercialGeneralLiabilityHistoryInput.CarrierName']");

    public ILocator CauseOfLoss => _page.Locator("input[fieldref=\"RatingGroupInput.CauseOfLossType\"]");

    public ILocator City => _page.Locator("input[fieldref=\"DesignatedWorkplace.City\"]");

    public ILocator ClassCode => _page.Locator("input[fieldref=\"CovOwnersContractorsOrPrincipalsInputNonShredded.ClassCode\"]");

    public ILocator ClassCodeFrame => _page.GetByText("Class Code Frame", new() { Exact = true });

    public ILocator ClassCodeFrameClassCodeWindow => _page.GetByText("Class Code Window", new() { Exact = true });

    public ILocator ClassificationOfRisk => _page.Locator("input[fieldref=\"CovAccountsReceivableInput.ClassificationOfRisk\"]");


    public ILocator ClickAddExcludedDriver => _page.GetByRole(AriaRole.Link, new() { Name = "Add Excluded Driver", Exact = true });

    public ILocator AddClient => _page.GetByRole(AriaRole.Link, new() { Name = "Add Client", Exact = true });

    public ILocator PolicyCovgComputerSystemsCoinsurance => _page.Locator("input[fieldref=\"ComputerSystemsInput.Coinsurance\"]");

    public ILocator RatingGroupsCoinsurance => _page.Locator("input[fieldref=\"RatingGroupInput.Coinsurance\"]");

    public ILocator PolicyCovgContractorsEquipmentCoinsurance => _page.Locator("input[fieldref=\"ContractorsEquipmentInput.Coinsurance\"]");

    public ILocator Collision => _page.Locator("input[fieldref=\"CovDriveOtherCarCollisionInput.Indicator\"]");

    public ILocator CollisionCoverage => _page.Locator("input[fieldref=\"CovCollisionInput.AcceptCollisionCoverage\"]");

    public ILocator CollisionDeductible => _page.Locator("input[fieldref=\"CovDriveOtherCarCollisionInput.Deductible\"]");

    public ILocator CommericialAutoDetailHeading => _page.GetByText("Commercial Auto Detail", new() { Exact = true });

    public ILocator HiredAutoCollisionDeductible => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Collision Deductible*']/@for] | //label[normalize-space(string(.))='Collision Deductible*']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Collision Deductible*']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator StateDetailsHiredAutoPDWithoutDriverIfAny => _page.Locator("input[fieldref=\"CovHiredAndBorrowedCollisionInput.IfAny\"]");

    public ILocator StateDetailsHiredAutoPhysicalDamageWithDriverIfAny => _page.Locator("input[fieldref=\"CovHiredAndBorrowedCollisionWithDriverInput.IfAny\"]");

    public ILocator CommercialAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Commercial Auto", Exact = true });

    public ILocator CommonNavigationLinksNext => _page.GetByRole(AriaRole.Link, new() { Name = "Next", Exact = true });

    public ILocator CompanyName => _page.Locator("input[fieldref=\"WaiverCompanyName.CompanyName\"]");

    public ILocator Comprehensive => _page.Locator("input[fieldref=\"CovDriveOtherCarOTCInput.Indicator\"]");

    public ILocator ComputerEquipment => _page.Locator("input[fieldref=\"CovComputerSystemsInput.ComputerEquipment\"]");

    public ILocator ComputerSystemsUWQuestions => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Computer  Systems" });

    public ILocator BuildingDetailConstruction => _page.Locator("input[fieldref=\"BuildingInput.ConstructionCode\"]");

    public ILocator RiskBaileesCustomersConstruction => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.ConstructionCode\"]");

    public ILocator ConstructionCode => _page.Locator("input[fieldref=\"CovComputerSystemsInput.ConstructionCode\"]");

    public ILocator RiskAccountsReceivableConstruction => _page.Locator("input[fieldref=\"RiskInlandMarineInput.ConstructionCode\"]");

    public ILocator ContractorsEquipmentUWQuestions => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Contractors Equipment" });

    public ILocator CoverageBeginDate => _page.Locator("input[fieldref=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.PeriodOfOperationsFrom\"]");

    public ILocator CoverageEndDate => _page.Locator("input[fieldref=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.PeriodOfOperationsTo\"]");

    public ILocator PolicyCovgGLCoverageForm => _page.Locator("input[fieldref=\"LineInput.PolicyType\"]");

    public ILocator PolicyCovgSignsCoverageForm => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Policy Covg Signs Coverage Form']/@for] | //label[normalize-space(string(.))='Policy Covg Signs Coverage Form']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Policy Covg Signs Coverage Form']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator RiskMainCoverageForm => _page.Locator("input[fieldref=\"LineInput.RiskType\"]");

    public ILocator PolicyCovgComputerSystemsCoverageFormDisplay => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Computer Systems", Exact = true });

    public ILocator PolicyCovgBaileesCutomersCoverageFormDisplay => _page.GetByText("Coverage Form Display");

    public ILocator PolicyCovgMotorTruckCargoCoverageFormDisplay => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Motor Truck Cargo", Exact = true });


    public ILocator PolicyCovgSignsCoverageFormDisplay => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Signs", Exact = true });

    public ILocator PolicyCovgContractorsEquipmentCoverageFormDisplay => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Contractors Equipment", Exact = true });

    public ILocator CoverageFormToBeAdded => _page.Locator("input[fieldref=\"LineInput.CoverageForm\"]");

    public ILocator CoverageType => _page.Locator("input[fieldref=\"MotorTruckCargoInput.CoverageForm\"]");

    public ILocator CoveredPropertyConsistingPrincipallyOf => _page.Locator("textarea[fieldref=\"MotorTruckCargoInput.Description\"]");

    public ILocator CreateValuation => _page.GetByRole(AriaRole.Link, new() { Name = "Create Valuation", Exact = true });

    public ILocator DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment => _page.Locator("input[fieldref=\"BaileesCustomerUnderwritingQuestionsInput.FireDeptDistance\"]");

    public ILocator DataAndMedia => _page.Locator("input[fieldref=\"CovComputerSystemsInput.DataAndMedia\"]");

    public ILocator DateOfBirth => _page.Locator("input[fieldref=\"DriverUnderwritingInformationInput.DateOfBirth\"]");

    public ILocator DateOfHire => _page.Locator("input[fieldref=\"DriverUnderwritingInformationInput.DateOfHire\"]");

    public ILocator DebrisRemovalAdditional => _page.Locator("input[fieldref=\"BuildingInput.DebrisRemoval\"]");

    public ILocator DebrisRemovalAdditionalLimit => _page.Locator("input[fieldref=\"BuildingInput.DebrisRemovalLimit\"]");

    public ILocator DedType => _page.Locator("input[fieldref=\"LineInput.DeductibleType\"]");

    public ILocator DedicatedLine => _page.Locator("input[fieldref=\"ComputerSystemsUnderwritingQuestionsInput.DedicatedLineIndicator\"]");

    public ILocator RatingGroupsDeductible => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Deductible']/@for] | //label[normalize-space(string(.))='Deductible']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Deductible']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator EndorsementIF0002WaterborneEquipmentDeductible => _page.Locator("input[fieldref=\"CovEndorsementInput.WaterborneEquipmentDeductible\"]");

    public ILocator PolicyCovgMotorTruckCargoDeductible => _page.Locator("input[fieldref=\"MotorTruckCargoInput.Deductible\"]");

    public ILocator RiskBaileesCustomersDeductible => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.Deductible\"]");

    public ILocator BuildingDetailDeductible => _page.Locator("input[fieldref=\"BuildingInput.Deductible\"]");

    public ILocator DeductibleBasis => _page.Locator("input[fieldref=\"LineInput.DeductibleScope\"]");

    public ILocator PolicyCovgContractorsEquipmentDeductible => _page.Locator("input[fieldref=\"ContractorsEquipmentInput.Deductible\"]");

    public ILocator PolicyCovgComputerSystemsDeductible => _page.Locator("input[fieldref=\"ComputerSystemsInput.Deductible\"]");

    public ILocator BuildingDetailDeductibleIncreasedTheft => _page.Locator("input[fieldref=\"BuildingInput.DeductibleIncreasedTheft\"]");

    public ILocator RatingGroupsDeductibleIncreasedTheft => _page.Locator("input[fieldref=\"RatingGroupInput.DeductibleIncreasedTheft\"]");

    public ILocator BuildingDetailDeductibleWindHail => _page.Locator("input[fieldref=\"BuildingInput.DeductibleWindHail\"]");

    public ILocator RatingGroupsDeductibleWindHail => _page.Locator("input[fieldref=\"RatingGroupInput.DeductibleWindHail\"]");

    public ILocator DefaultExpModType => _page.Locator("input[fieldref=\"LineInput.ModType\"]");

    public ILocator DefaultExperienceMod => _page.Locator("input[fieldref=\"LineInput.ExperienceModifier\"]");

    public ILocator DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy => _page.Locator("//label[contains(normalize-space(.),'Describe all hold harmless agreements and please provide a copy.')]/ancestor::div[contains(@class,'downFieldGroup')]//textarea[@fieldref='GeneralLiabilityInput.Description']");

    public ILocator RatingGroupsDescription => _page.Locator("input[fieldref=\"RatingGroupInput.Description\"]");

    public ILocator DescriptionOfBusinessActivites => _page.Locator("input[fieldref=\"BusinessInterruptionEndorsementInput.DescriptionOfBusinessActivites\"]");

    public ILocator DescriptionOfOperationS => _page.Locator("textarea[fieldref='CovEndorsementsInput.Description']");

    public ILocator DescriptionOfOperations => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Description of Operations']/@for] | //label[normalize-space(string(.))='Description of Operations']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Description of Operations']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator DescriptionOfSpecifiedOperation => _page.Locator("input[fieldref=\"PolicyOutput.DescriptionOfOperations\"], textarea[fieldref=\"PolicyInput.DescriptionOfOperations\"]");

    public ILocator EstimatedPremium => _page.Locator("input[fieldref=\"PolicyInput.EstimatedPremium\"]");

    public ILocator DesignatedWorkplacesExclusionOK => _page.GetByRole(AriaRole.Link, new() { Name = "Add Designated Workplace", Exact = true });

    public ILocator Select => _page.Locator("[id=\"dctGridLink\"]");
    public ILocator InsuranceScoreConsent => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance Score", Exact = true });

    public ILocator DoYouHaveACDLLicense => _page.Locator("input[fieldref=\"DriverUnderwritingInformationInput.HaveCDLLicense\"]");

    public ILocator DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup => _page.Locator("input[fieldref=\"PolicyInput.AnyRiskPowerUnitOtherThanWindmillOrBackup\"]");

    public ILocator DoesTheApplicantWishToCoverAnySignsInsideTheirPremises => _page.Locator("input[fieldref=\"SignsUnderwritingQuestionsInput.Indicator\"]:visible").Nth(1);

    public ILocator DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement => _page.Locator("input[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionG\"]");

    public ILocator DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs => _page.Locator("input[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionH\"]");

    public ILocator DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy => _page.Locator("input[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionF\"]");

    public ILocator DriveOtherCar => _page.Locator("input[fieldref=\"LineStateInput.DriveOtherCarCoverage\"]");


    public ILocator DriversLicenseNumber => _page.Locator("input[fieldref=\"DriverUnderwritingInformationInput.DriversLicenseNumber\"]");

    public ILocator DryCleaning => _page.Locator("input[fieldref='BaileesCustomerPrincipalWorkUnderwritingQuestionsInput.Percent']:visible").Nth(0);

    public ILocator DuplicatedRecords => _page.Locator("input[fieldref=\"CovAccountsReceivableInput.DuplicateRecords\"]");

    public ILocator EAreNoSmokingRulesPostedAndEnforced => _page.Locator("input[fieldref=\"BaileesCustomerUnderwritingQuestionsInput.SmokingRulesIndicator\"]");

    public ILocator EMail => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.Email\"]");

    public ILocator Earthquake => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.Earthquake\"]");

    public ILocator EasyPay => _page.Locator("input[fieldref=\"BillingDetailInput.EasyPay\"]");

    public ILocator BusinessownersEffectiveDate => _page.Locator("input[fieldref=\"UmbrellaBusinessOwnersInput.EffectiveDate\"], input[fieldref='UmbrellaCPPLiabilityInput.EffectiveDate']");


    public ILocator PolicyInfoRequiredAndOptionalFieldsEffectiveDate => _page.Locator(@"input[fieldref=""PolicyInput.EffectiveDate""]");

    public ILocator EligibleForEnhancedWindRatingProgram => _page.Locator("input[fieldref=\"BuildingInput.EligibleForEnhancedWindRatingProgram\"]");

    public ILocator EmployeeHiredAutosCheckBox => _page.Locator("input[fieldref=\"LineStateInput.EmployeeHiredAuto\"]");

    public ILocator EmployersLiab => _page.GetByRole(AriaRole.Link, new() { Name = "Employers Liab", Exact = true });



    public ILocator FirstEndorsementScheduleRow => _page.GetByText("$1", new() { Exact = true });

    public ILocator FirstEndorsementTableRow => _page.GetByText("#1", new() { Exact = true });

    public ILocator SecondEndorsementTableRow => _page.GetByText("$2", new() { Exact = true });




    public ILocator EngineSizeCc => _page.Locator("input[fieldref=\"RiskCommercialAutoRiskInput.EngineSizeCC\"]");

    public ILocator EntityInfoFrame => _page.GetByText("Entity Info Frame", new() { Exact = true });


    public ILocator EstimatedHighestValue => _page.Locator("input[fieldref=\"ContractorsEquipmentUnderwritingQuestionsInput.HighestValue\"]");

    public ILocator EstimatorType => _page.Locator("input[fieldref=\"BuildingValuatioinInput.EstimatorType\"]");

    public ILocator ExcessLiabilityIfAny => _page.Locator("input[fieldref=\"CovHiredAndBorrowedExcessLiabilityInput.IfAny\"]");

    public ILocator ExcludeCollapseHazard => _page.Locator("input[fieldref=\"CovEndorsementsInput.IndicatorCollapseCG2142\"]");

    public ILocator ExcludeExplosionHazard => _page.Locator("input[fieldref=\"CovEndorsementsInput.IndicatorExplosionCG2142\"]");

    public ILocator ExcludedLiabilityConfidentialInformation => _page.Locator("input[fieldref=\"CovConfidentialInfoLiabilityInput.FormSelection\"]");

    public ILocator ExperienceModType => _page.Locator("input[fieldref=\"ExperienceModInput.ModType\"]");

    public ILocator ExperienceRated => _page.Locator("input[fieldref=\"LineInput.ExperienceRatedIndicator\"]");

    public ILocator ExperienceRatingOptions => _page.Locator("input[fieldref=\"LineStateTermInput.ExperienceRatingOptions\"]");

    public ILocator BusinessownersExpirationDate => _page.Locator("input[fieldref=\"UmbrellaBusinessOwnersInput.ExpirationDate\"], input[fieldref='UmbrellaCPPLiabilityInput.ExpirationDate']");


    public ILocator Exposure => _page.Locator("input[fieldref=\"RiskGeneralLiabilityInput.UnitsOfExposureEstimated\"]");

    public ILocator ExtendedEmployeeCoverage => _page.Locator("input[fieldref=\"RiskNonOwnedAutoInput.ExtendedEmployeeCov\"]");

    public ILocator ExtraExpense => _page.Locator("input[fieldref=\"ComputerSystemsInput.ExtraExpenseIndicator\"]");

    public ILocator FeetFromHydrant => _page.Locator("input[fieldref=\"LocationInput.FeetFromHydrant\"]");

    public ILocator FireDamage => _page.Locator("input[fieldref=\"CovFireDamageInput.FireDamage\"]");


    public ILocator FirstName => _page.Locator("input[fieldref=\"DriverUnderwritingInformationInput.Name\"]:visible, input[fieldref=\"AdditionalOtherInterestInput.FirstName\"]:visible");

    public ILocator GCW => _page.Locator("input[fieldref=\"RiskTruckInput.GCW\"]");

    public ILocator GLDetail => _page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true });

    public ILocator GLUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "GL UW Questions", Exact = true });

    public ILocator GeneralLiab => _page.GetByRole(AriaRole.Link, new() { Name = "General Liab", Exact = true });
    public ILocator Businessowners => _page.GetByRole(AriaRole.Link, new() { Name = "Businessowners", Exact = true });

    public ILocator GeneralUWQuestions => _page.GetByText("Update Answers");

    public ILocator GetCalculatedValue => _page.GetByRole(AriaRole.Link, new() { Name = "Get Calculated Value", Exact = true });

    public ILocator GroupClass => _page.Locator("input[fieldref='MotorTruckCargoInput.Owners200MilesAndUnderGroupClass'], input[fieldref=\"MotorTruckCargoInput.CarriersGroupClass\"]");

    public ILocator HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring => _page.Locator("input[fieldref=\"UnderwritingQuestionsAutoInput.AnyFelonies\"]");

    public ILocator HaveYouHadAnyLiabilityLossesInTheLast5YearsOnAnyPrimaryOrExcessPolicy => _page.Locator("input[fieldref=\"UnderwritingQuestionsUmbrellaInput.AnyLiabilityLosses\"]");

    public ILocator HiredAutoCA2001Address => _page.Locator("input[fieldref=\"CovHiredAutoCA2001Input.Address1\"]");

    public ILocator HiredAutoCA2001FirstName => _page.Locator("input[fieldref=\"CovHiredAutoCA2001Input.FirstName\"]");

    public ILocator HiredAutoCA2001LastName => _page.Locator("input[fieldref=\"CovHiredAutoCA2001Input.LastName\"]");

    public ILocator HiredAutoCA2001ZipCode => _page.Locator("input[fieldref=\"CovHiredAutoCA2001Input.ZipCode\"]");

    public ILocator HiredAutoExtAddlInsured => _page.Locator("input[fieldref=\"CovLiabilityInput.HiredAutoExtAddlInsured\"]");

    public ILocator HiredAutoOK => _page.Locator("input[fieldref=\"CovLiabilityInput.HiredAutoExtAddlInsuredForm\"]");

    public ILocator HiredAutoLiability => _page.Locator("input[fieldref=\"LineStateInput.HiredLiability\"]");

    public ILocator HiredAutoPhysicalDamageWithDriver => _page.Locator("input[fieldref=\"LineStateInput.HiredPhysicalDamageWithDriver\"]");

    public ILocator HiredAutoPhysicalDamageWithoutDriver => _page.Locator("input[fieldref=\"LineStateInput.HiredPhysicalDamage\"]");

    public ILocator HiredEquipment => _page.Locator("input[fieldref=\"ContractorsEquipmentInput.HiredEquipmentIndicator\"]");

    public ILocator HowOftenIsDataBackedUp => _page.Locator("[name=\"string_2F_5\"]");

    public ILocator AdditionalInterestsScheduleIFRAME => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='IFRAME']/@for] | //label[normalize-space(string(.))='IFRAME']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='IFRAME']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator DriverDetailIFRAME => _page.Locator("[id=\"dctPopup_dctPopupWindow34CAB0C1A0A47F298A990A36C62FE6D0\"]");

    public ILocator IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationS => _page.Locator("input[fieldref=\"FarmLocationInput.FarmLocation\"]");

    public ILocator IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremises => _page.Locator("input[fieldref=\"PremisesInput.Premises\"]");

    public ILocator IFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivities => _page.Locator("textarea[fieldref=\"CovAmendmentoOfLiquorLiabilityExclusionInput.DescriptionOfPremisesOrActivities\"]:visible, textarea[fieldref=\"CovAmendmentoOfLiquorLiabilityExclusionInputForWA.DescriptionOfPremisesOrActivities\"]:visible");

    public ILocator IFRAMEDuckCreekPolicyExcludedDriver => _page.Locator("input[fieldref=\"ExcludedDriverInput.ExcludedDriver\"]:visible, input[fieldref=\"ExcludedDriver_SDInput.ExcludedDriver\"]:visible");

    public ILocator IFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalS => _page.Locator("input[fieldref=\"AnimalsInput.Animals\"]");

    public ILocator IFRAMEDuckCreekPolicyVehicleAssociation => _page.GetByText("Vehicle Association*", new() { Exact = true });

    public ILocator BAPEndorsementsIFRAME => _page.Locator("[id=\"dctPopup_dctPopupWindow1631A82AB27744695E74FDAA3357B203\"]");

    public ILocator IfYesDescribe => _page.Locator("textarea[fieldref=\"ContractorsEquipmentUnderwritingQuestionsInput.Description\"]");

    public ILocator IfYesExplain => _page.Locator("textarea[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionFsub\"]");

    public ILocator ImportPolicyData => _page.GetByRole(AriaRole.Link, new() { Name = "Import Policy Data", Exact = true });


    public ILocator IncreasedPollutantCleanup => _page.Locator("input[fieldref=\"LocationPropertyInput.IncreasedPollutantCleanup\"]");

    public ILocator IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated => _page.Locator("[name=\"string_2F_1\"]");

    public ILocator InsuranceHistory => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance History", Exact = true }).Or(_page.GetByText("Commercial General Liability History")).Or(_page.GetByRole(AriaRole.Link, new() { Name = "Other Insurance History", Exact = true }));

    public ILocator InsuredType => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.InsuredType\"]");

    public ILocator Interest => _page.Locator("input[fieldref=\"BuildingInput.Interest\"]");

    public ILocator IntrastateRiskID => _page.Locator("input[fieldref=\"ExperienceModInput.RiskID\"]");

    public ILocator IsTheBuildingCooled => _page.Locator("input[fieldref=\"BuildingInput.BuildingCooled\"]");

    public ILocator IsTheBuildingHeatedWithASolidFuelHeatingDevice => _page.Locator("input[fieldref=\"BuildingInput.SolidFuelHeatingDevices\"]");

    public ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations => _page.Locator("input[fieldref=\"LineInput.InsuredEngaged\"]");

    public ILocator IsThereAPriorCarrier => _page.GetByPlaceholder("(select)").First;

    public ILocator IsThisCoverageBound => _page.Locator("input[fieldref='PolicyWorkflowDataInput.IsCoverageBound']");

    public ILocator IsThisPolicyBeingFullyCancelled => _page.Locator("input[fieldref=\"PolicyInput.FullyCancelled\"]");

    public ILocator IsThisVehicleUsedInSnowPlowOperations => _page.Locator("input[fieldref=\"RiskTruckInput.SnowPlowOperations\"]");

    public ILocator JavaScript => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='JavaScript']/@for] | //label[normalize-space(string(.))='JavaScript']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='JavaScript']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator LastName => _page.Locator("input[fieldref=\"DriverUnderwritingInformationInput.LastName\"]:visible, input[fieldref=\"AdditionalOtherInterestInput.LastName\"]:visible");


    public ILocator Laundry => _page.Locator("input[fieldref='BaileesCustomerPrincipalWorkUnderwritingQuestionsInput.Percent']:visible").Nth(1);

    public ILocator Lettering => _page.Locator("input[fieldref=\"CoverageSignsIteratorInput.SignLettering\"]");

    public ILocator CommercialAutoLiabilityLimit => _page.Locator("input[fieldref=\"UmbrellaCommercialAutoInput.LiabilityLimit\"], input[fieldref='UmbrellaCPPLiabilityInput.LiabilityLimit']");


    public ILocator PolicyCovgBaileesPropertyAwayFromYourPremisesLimit => _page.Locator("input[fieldref=\"BaileesCustomersPropertyAwayFromYourPremises.Limit\"]");

    public ILocator EndorsementIF0002WaterborneEquipmentLimit => _page.Locator("input[fieldref=\"CovEndorsementInput.WaterborneEquipment\"]");

    public ILocator RiskBaileesCustomersLimit => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.Limit\"]");

    public ILocator LimitOfInsurance => _page.Locator("input[fieldref=\"CoverageSignsIteratorInput.PremiumBase\"]");

    public ILocator LineConditioner => _page.Locator("input[fieldref=\"ComputerSystemsUnderwritingQuestionsInput.LineconditionerIndicator\"]");

    public ILocator ListAllPoliciesWithAmericanNational => _page.Locator("textarea[fieldref=\"UnderwritingQuestionsWorkersCompInput.ListAllPoliciesWithAmericanNational\"]");

    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    public ILocator LoanLeaseGap => _page.Locator("input[fieldref=\"RiskCommercialAutoRiskInput.LoanLease\"]");



    public ILocator LocationAssignment => _page.GetByText("Location Assignment", new() { Exact = true });

    public ILocator LocationID => _page.Locator("input[fieldref=\"AdditionalOtherInterestLocationsInput.LocationID\"]");

    public ILocator LocationOfCoveredOperations => _page.Locator("input[fieldref=\"CovOwnersContractorsOrPrincipalsInput.LocationOfCoveredOperations\"]");



    public ILocator Make => _page.Locator("input[fieldref=\"RiskVehicleInput.Make\"]");

    public ILocator MaritalStatus => _page.Locator("input[fieldref=\"DriverUnderwritingInformationInput.MaritalStatus\"]");

    public ILocator Medical => _page.Locator("input[fieldref=\"CovMedicalInput.Medical\"]");

    public ILocator MeritRating => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Merit Rating']/@for] | //label[normalize-space(string(.))='Merit Rating']//*[self::input or self::select or self::textarea or @role='combobox'][1] | //label[normalize-space(string(.))='Merit Rating']/following::*[self::input or self::select or self::textarea or @role='combobox'][1])");

    public ILocator MilesFromFireDepartment => _page.Locator("input[fieldref=\"LocationInput.MilesFromFireDepartment\"]");

    public ILocator MiscItemsBlanketCoverage => _page.Locator("input[fieldref=\"ContractorsEquipmentInput.BlanketIndicator\"]");

    public ILocator Model => _page.Locator("input[fieldref=\"RiskVehicleInput.Model\"]");

    public ILocator ModificationFactor => _page.Locator("input[fieldref='CommercialGeneralLiabilityHistoryInput.ModificationFactor'],input[fieldref='OtherInsuranceHistoryInput.ModificationFactor']");

    public ILocator N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms => _page.Locator("input[fieldref=\"BaileesCustomerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(4);

    public ILocator N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft => _page.Locator("[name=\"string_92_3\"]");

    public ILocator N11AreDriversMVRsAndTripLogsMaintained => _page.Locator("input[fieldref=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(6);

    public ILocator N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit => _page.Locator("[name=\"string_169_3\"]");

    public ILocator N12AreDriversMVRsReviewedOnARegularBasisAndMaintained => _page.Locator("input[fieldref=\"BaileesCustomerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(5);

    public ILocator N12HowOftenAreTheseLogsReviewedOrUpdated => _page.Locator("[name=\"string_92_4\"]");

    public ILocator N13LiveAnimalInTransitCoverage => _page.Locator("input[fieldref=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(7);

    public ILocator N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle => _page.Locator("[name=\"string_169_4\"]");

    public ILocator N14LegalLiabilityCoverage => _page.Locator("input[fieldref=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(8);

    public ILocator N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage => _page.Locator("[name=\"string_169_5\"]");

    public ILocator N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft => _page.Locator("[name=\"string_169_6\"]");

    public ILocator N16DoesTheRiskUseReleaseForms => _page.Locator("input[fieldref=\"BaileesCustomerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(6);

    public ILocator N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment => _page.Locator("[name=\"string_92\"]");

    public ILocator N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises => _page.Locator("[name=\"string_169\"]");

    public ILocator N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities => _page.Locator("[name=\"string_92_1\"]");

    public ILocator N2ndClassCategory => _page.Locator("input[fieldref=\"RiskTruckInput.SecondaryClassCategory\"]");

    public ILocator N2ndClassCode => _page.Locator("input[fieldref=\"RiskTruckInput.SecondaryClassCode\"]");

    public ILocator N3DoesTheApplicantHaulForOthers => _page.Locator("input[fieldref='MotorTruckOwnerUnderwritingQuestionsInput.Indicator']:visible").Nth(0);

    public ILocator N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair => _page.Locator("[name=\"string_169_1\"]");

    public ILocator N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated => _page.Locator("[name=\"string_169_2\"]");

    public ILocator N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer => _page.Locator("[name=\"string_92_2\"]");

    public ILocator N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained => _page.Locator("input[fieldref='BaileesCustomerUnderwritingQuestionsInput.Indicator']:visible").Nth(0);

    public ILocator N5Deductible => _page.Locator("input[fieldref=\"SignsInput.Deductible\"]");

    public ILocator N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached => _page.Locator("input[fieldref=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(1);

    public ILocator N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied => _page.Locator("input[fieldref=\"BaileesCustomerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(1);

    public ILocator N6DoesTheApplicantPullDoubleOrTripleTrailers => _page.Locator("input[fieldref=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(2);

    public ILocator N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises => _page.Locator("input[fieldref=\"BaileesCustomerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(2);

    public ILocator N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended => _page.Locator("input[fieldref=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(3);

    public ILocator N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate => _page.Locator("input[fieldref=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(4);

    public ILocator N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities => _page.Locator("input[fieldref=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(5);

    public ILocator N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem => _page.Locator("input[fieldref=\"BaileesCustomerUnderwritingQuestionsInput.Indicator\"]:visible").Nth(3);

    public ILocator NAICSCodeSearchValue => _page.Locator("input[fieldref=\"AdditionalOtherInterestLocationsOutputNonShredded.NAICSCodeSearchValue\"]");

    public ILocator NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices => _page.Locator("input[fieldref=\"ActivitiesInput.Activities\"]");

    public ILocator Names => _page.Locator("input[fieldref=\"CovEndorsmentIteratorNonShreddedInput.Name\"]");


    public ILocator NoKnownLosses => _page.Locator("input[fieldref='PolicyUnderwritingInput.NoKnownLosses']:visible").First;

    public ILocator NonOwnedAuto => _page.Locator("input[fieldref=\"LineCoveragesInput.NonOwnedAuto\"]");


    public ILocator NumberOfEmployees => _page.Locator("input[fieldref=\"CovEmployeeBenefitsLiabInput.NumberOfEmployees\"]");

    public ILocator NumberOfFullTimeEmployees => _page.Locator("input[fieldref=\"CoverageInput.NumberOfFullTimeEmployees\"]");

    public ILocator NumberOfPartTimeEmployees => _page.Locator("input[fieldref=\"CoverageInput.NumberOfPartTimeEmployees\"]");

    public ILocator NumberOfVehicles => _page.Locator("input[fieldref='MotorTruckCargoInput.Owners200MilesAndUnderNumberOfVehicles'], input[fieldref=\"MotorTruckCargoInput.CarriersNumberOfVehicles\"]");

    public ILocator OCP => _page.GetByRole(AriaRole.Link, new() { Name = "OCP", Exact = true });

    public ILocator OTCCausesOfLoss => _page.Locator("input[fieldref=\"CovOTCInput.CoverageForm\"]");

    public ILocator StateDetailsHiredAutoPDWithoutDriverOTCDeductible => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='OTC Deductible*']/@for] | //label[normalize-space(string(.))='OTC Deductible*']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='OTC Deductible*']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator StateDetailsDriveOtherCarOTCDeductible => _page.Locator("input[fieldref=\"CovDriveOtherCarOTCInput.Deductible\"]");

    public ILocator StateDetailsHiredAutoPDWithoutDriverIfAnyField => _page.Locator("input[fieldref=\"CovHiredAndBorrowedOTCInput.IfAny\"]");

    public ILocator StateDetailsHiredAutoPhysicalDamageWithDriverIfAnyField => _page.Locator("input[fieldref=\"CovHiredAndBorrowedOTCWithDriverInput.IfAny\"]");

    public ILocator OccupancyType => _page.Locator("input[fieldref=\"OccupancyInput.OccupancyTypeMonoline\"]");

    public ILocator Occupied => _page.Locator("input[fieldref=\"BuildingInput.VacancyPercentageOccupied\"]");

    public ILocator OccurenceLimit => _page.Locator("input[fieldref=\"LineInput.PolicyPerOccurenceLimit\"]");

    public ILocator OfEmployees => _page.Locator("input[fieldref=\"RiskNonOwnedAutoInput.NumberOfEmployeesEstimate\"]");

    public ILocator OfFullTimeEmployees => _page.Locator("input[fieldref=\"LineInput.NumberOfFullTimeEmployees\"]");

    public ILocator OfPartTimeEmployees => _page.Locator("input[fieldref=\"LineInput.NumberOfPartTimeEmployees\"]");

    public ILocator OfPartners => _page.Locator("input[fieldref=\"RiskNonOwnedAutoInput.NumberOfPartnersEstimate\"]");

    public ILocator OfSeasonalTemporaryEmployees => _page.Locator("input[fieldref=\"LineInput.NumberOfSeasonalTemporaryEmployees\"]");

    public ILocator Officers => _page.Locator("input[fieldref=\"EndorsementOfficers.Officers\"]");

    public ILocator OfficersPositionHeld => _page.Locator("input[fieldref=\"EndorsementOfficers.PositionHeld\"]");

    public ILocator OptionACheckBox => _page.Locator("input[fieldref=\"BusinessInterruptionEndorsementInput.OptionA\"]");

    public ILocator OptionAScheduleButton => _page.GetByRole(AriaRole.Link, new() { Name = "Option A Schedule", Exact = true });

    public ILocator OrderAudit => _page.Locator("input[fieldref=\"PolicyInput.OrderAudit\"]");

    public ILocator RiskVehicleInputValueEstimate => _page.Locator("input[fieldref=\"RiskVehicleInput.ValueEstimate\"]");

    public ILocator Others => _page.Locator("input[fieldref=\"EndorsementOthers.Others\"]");

    public ILocator Partners => _page.Locator("input[fieldref=\"EndorsementPartners.Partners\"]");

    public ILocator PayPlan => _page.Locator("input[fieldref=\"BillingDetailInput.PayPlan\"]");

    public ILocator PendingRateChange => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Pending Rate Change']/@for] | //label[normalize-space(string(.))='Pending Rate Change']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Pending Rate Change']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator PerVehicleLimit => _page.Locator("input[fieldref=\"MotorTruckCargoInput.PerVehicleLimit\"]");

    public ILocator PersAdvInj => _page.Locator("input[fieldref=\"CovPersonalAdvertisingInjuryInput.PersonalAdvertisingInjury\"]");

    public ILocator PersonalPortableComputers => _page.Locator("input[fieldref=\"ComputerSystemsInput.PersonalPortableComputersIndicator\"]");

    public ILocator PersonalPropertyLimit => _page.Locator("xpath=(//*[self::input or self::textarea or self::select][@fieldref='RiskPropertyInput.Limit'][@aria-label='Personal Property Limit' or @placeholder='Personal Property Limit'] | //*[(self::label or self::span or self::div or self::td) and normalize-space(string(.))='Personal Property Limit']/following::*[self::input or self::textarea or self::select][@fieldref='RiskPropertyInput.Limit'][1])");


    public ILocator PierOrWharf => _page.Locator("input[fieldref=\"BuildingInput.PierOrWharf\"]");

    public ILocator PierOrWharfCOLOptions => _page.Locator("input[fieldref=\"BuildingInput.PierOrWharfCOLOptions\"]");

    public ILocator PierOrWharfCauseOfLoss => _page.Locator("input[fieldref=\"BuildingInput.PierOrWharfCauseOfLoss\"]");

    public ILocator PierOrWharfConstruction => _page.Locator("input[fieldref=\"BuildingInput.PierOrWharfConstruction\"]");

    public ILocator PleaseProvideWebsiteAddressEs => _page.Locator("input[fieldref=\"UnderwritingQuestionsUmbrellaInput.WebsiteAddress\"]");

    public ILocator PolicyCovgerage => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });

    public ILocator PolicyCovg => _page.Locator("div[id='pageTitle']").Filter(new LocatorFilterOptions { HasText = "Policy Covg" });

    public ILocator PolicyHolderName => _page.Locator("input[fieldref=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderName\"]");

    public ILocator BusinessownersPolicyNumber => _page.Locator("input[fieldref=\"UmbrellaBusinessOwnersInput.PolicyNumber\"], input[fieldref='UmbrellaEmployersLiabilityInput.PolicyNumber']");


    public ILocator PolicyType => _page.Locator("[fieldref='CommercialGeneralLiabilityHistoryInput.PolicyType'],input[fieldref='OtherInsuranceHistoryInput.PolicyType']");

    public ILocator PowerSuppressorVoltageRegulator => _page.Locator("input[fieldref=\"ComputerSystemsUnderwritingQuestionsInput.PowerShortageIndicator\"]");

    public ILocator PremOpDed => _page.Locator("input[fieldref=\"LineInput.Deductible\"]");

    public ILocator PremOpPDDed => _page.Locator("input[fieldref=\"LineInput.DeductiblePD\"]");

    public ILocator PremisesType => _page.Locator("input[fieldref=\"CovAccountsReceivableInput.PremisesType\"]");

    public ILocator Premium => _page.Locator("div[fieldref=\"LineOutput.Premium\"]");

    public ILocator PricingDetail => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing Detail", Exact = true });

    public ILocator PricingHeading => _page.Locator("//div[@id='pageTitle' and text()='Pricing']");

    public ILocator PrimaryLiabilityIfAny => _page.Locator("input[fieldref=\"CovHiredAndBorrowedLiabilityInput.IfAny\"]");

    public ILocator PrimaryLocationState => _page.Locator("input[fieldref=\"LineInput.PrimaryLocationState\"]");

    public ILocator PrimaryRatingState => _page.Locator("input[fieldref=\"PolicyInput.PrimaryRatingState\"]");

    public ILocator PrimaryRatingStateDropDown => _page.Locator("xpath=//input[@fieldref='PolicyInput.PrimaryRatingState']/ancestor::div[contains(@id,'-triggerWrap')]/div[contains(@id,'-trigger-picker')]");

    public ILocator PrimaryRatingStateKansas => _page.Locator("xpath=(//li[contains(@class,'x-boundlist-item') and normalize-space()='Kansas' and not(contains(@style,'display: none'))] | //div[contains(@class,'x-boundlist-item') and normalize-space()='Kansas' and not(contains(@style,'display: none'))])[1]");


    public ILocator PriorAmericanNationalPolicy => _page.Locator("input[fieldref=\"PolicyInput.PriorPolicyNumberAN\"]");

    public ILocator ProdBIDed => _page.Locator("input[fieldref=\"LineInput.DeductibleProducts\"]");

    public ILocator ProdPDDed => _page.Locator("input[fieldref=\"LineInput.DeductiblePDProducts\"]");

    public ILocator ProduceCarried => _page.Locator("input[fieldref=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.ProduceCarried\"]");

    public ILocator ProductsAggLimit => _page.Locator("input[fieldref=\"LineInput.ProductsAggregateLimit\"]");

    public ILocator ProductsCompletedOperationsAggregateLimit => _page.Locator("input[fieldref=\"LineInput.ProductsCompletedOperationsAggregateLimit\"]");



    public ILocator PropertyAwayFromYourPremisesSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "Property Away From Your Premises Schedule", Exact = true });

    public ILocator PolicyCovgComputerSystemsPropertyInTransit => _page.Locator("input[fieldref=\"ComputerSystemsInput.PropertyInTransit\"]");

    public ILocator PolicyCovgBaileesCutomersPropertyInTransit => _page.Locator("input[fieldref=\"BaileesCustomersInput.PropertyInTransit\"]");

    public ILocator PropertyOfOthersLimit => _page.Locator("xpath=(//*[self::input or self::textarea or self::select][@fieldref='RiskPropertyInput.Limit'][@aria-label='Property of Others Limit' or @placeholder='Property of Others Limit'] | //*[(self::label or self::span or self::div or self::td) and normalize-space(string(.))='Property of Others Limit']/following::*[self::input or self::textarea or self::select][@fieldref='RiskPropertyInput.Limit'][1])");

    public ILocator ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest => _page.Locator("textarea[fieldref=\"BuildingInput.SurroundingExposureOrOtherOccupancies\"]");

    public ILocator ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia => _page.Locator("[name=\"string_2F_4\"]");

    public ILocator RentalReimbursement => _page.Locator("input[fieldref=\"ContractorsEquipmentInput.RentalReimbursementIndicator\"]");

    public ILocator RentedEquipmentExpense => _page.Locator("input[fieldref=\"ContractorsEquipmentInput.RentedEquipmentExpense\"]");

    public ILocator RequestedUmbrellaLimit => _page.Locator("input[fieldref=\"LineInput.RequestedUmbrellaLimit\"]");

    public ILocator Result => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Result']/@for] | //label[normalize-space(string(.))='Result']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Result']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator ReturnToQuote => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Quote", Exact = true }).Nth(1);

    public ILocator IndustryCode => _page.Locator("input[fieldref=\"LineInput.IndustryCode\"]");

    public ILocator YearBuilt1980 => _page.Locator("div[fieldref=\"UmbrellaGeneralLiabilityInput.BuiltPrior1980\"], input[fieldref=\"UmbrellaSFP10LiabilityInput.BuiltPrior1980\"], div[fieldref=\"UmbrellaCPPLiabilityInput.BuiltPrior1980\"]");

    public ILocator LiveStockMeat => _page.Locator("input[fieldref=\"UmbrellaSFP10LiabilityInput.InsuredInvolvedInLivestockOrMeat\"]");


    public ILocator RiskSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "Risk Schedule", Exact = true });

    public ILocator RiskType => _page.Locator("input[fieldref=\"RatingGroupInput.RiskType\"]");

    public ILocator RoofType => _page.Locator("input[fieldref=\"BuildingInput.RoofType\"]");


    public ILocator SaveForLater => _page.GetByRole(AriaRole.Link, new() { Name = "Save for Later", Exact = true });

    public ILocator ScheduledCoverage => _page.Locator("input[fieldref=\"ContractorsEquipmentInput.ScheduledCoverage\"]");

    public ILocator RiskComputerSystemsSearchResult => _page.Locator("input[fieldref=\"CovComputerSystemsInput.SearchResult\"]");

    public ILocator RiskBaileesCustomersSearchResult => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.SearchResult\"]");

    public ILocator RiskAccountsReceivableSearchResult => _page.Locator("input[fieldref=\"RiskInlandMarineInput.SearchResult\"]");

    public ILocator SearchResults => _page.Locator("input[fieldref=\"OccupancySearchInputNonShredded.SearchResults\"]");

    public ILocator SearchValue => _page.Locator("input[fieldref=\"NCCISearchInputNonShredded.SearchValue\"]");

    public ILocator PropertyAddClassSearchValue => _page.Locator("input[fieldref=\"OccupancySearchInputNonShredded.SearchValue\"]");

    public ILocator RiskAccountsReceivableSearchValue => _page.Locator("input[fieldref=\"RiskInlandMarineInput.SearchValue\"]");

    public ILocator RiskComputerSystemsSearchValue => _page.Locator("input[fieldref=\"CovComputerSystemsInput.SearchValue\"]");

    public ILocator RiskBaileesCustomersSearchValue => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.SearchValue\"]");

    public ILocator SeasonalProduceTrailers => _page.Locator("input[fieldref=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.SeasonalAgriculturalProduceTrailers\"]");


    public ILocator SelectAppropriateCode => _page.Locator("input[fieldref=\"AdditionalOtherInterestLocationsInput.NAICSCodeDesc\"]");

    public ILocator SelectClassCode => _page.Locator("input[fieldref=\"NCCISearchInputNonShredded.SearchResults\"]");

    public ILocator SelectNAICSCode => _page.GetByRole(AriaRole.Link, new() { Name = "Select NAICS Code", Exact = true });

    public ILocator SelectPPC => _page.GetByRole(AriaRole.Link, new() { Name = "Select PPC", Exact = true });

    public ILocator Sex => _page.Locator("input[fieldref=\"DriverUnderwritingInformationInput.Gender\"]");

    public ILocator ShowAllLocations => _page.Locator("input[fieldref=\"LocationSelectInput.ShowAllLocations\"]");

    public ILocator SignLocation => _page.Locator("input[fieldref=\"CoverageSignsIteratorInput.SignLocation\"]");

    public ILocator SignsUWQuestions => _page.GetByText("Signs", new() { Exact = true });

    public ILocator SmallDeductible => _page.Locator("input[fieldref=\"LineStateTermInput.SmallDeductibleCreditDeductible\"]");

    public ILocator SoleProprietors => _page.Locator("input[fieldref=\"EndorsementSoleProprietors.SoleProprietors\"]");

    public ILocator SpecificUnderwritingQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Specific Underwriting Questions", Exact = true });

    public ILocator SplitBIDed => _page.Locator("input[type='checkbox'][fieldref='LineInput.SeparateProductsDeductible']");

    public ILocator SplitPDDed => _page.Locator("input[fieldref=\"LineInput.SeparateProductsPDDeductible\"]");

    public ILocator SquareFeet => _page.Locator("input[fieldref=\"BuildingInput.SquareFt\"]");

    public ILocator PolicyHolderState => _page.Locator("input[fieldref=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderState\"]");

    public ILocator State => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.State\"]");

    public ILocator EndorsementsDesignatedWorkplacesExclusionState => _page.Locator("input[fieldref=\"DesignatedWorkplace.State\"]");


    public ILocator StateLicensed => _page.Locator("input[fieldref=\"DriverUnderwritingInformationInput.StateLicensed\"]");

    public ILocator StateOrPoliticalSubdivision => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.Name\"]");


    public ILocator StoplightMessageTotalSubjectPremium => _page.GetByText("Stoplight Message: Total Subject Premium", new() { Exact = true });

    public ILocator StorageLimit => _page.Locator("input[fieldref=\"CovBaileesCustomersInput.StorageLimit\"]");

    public ILocator Stories => _page.Locator("input[fieldref=\"BuildingInput.NumberOfStories\"]");



    public ILocator TapesCoverage => _page.Locator("input[fieldref=\"CovTapesInput.Tapes\"]");

    public ILocator TextBox => _page.Locator("textarea[fieldref=\"NotesInput.Remarks\"]");

    public ILocator ThirdPartyDesignee => _page.GetByRole(AriaRole.Link, new() { Name = "Third Party Designee", Exact = true });

    public ILocator Title => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Title']/@for] | //label[normalize-space(string(.))='Title']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Title']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator ToolsAndClothingBelongingToYourEmployees => _page.Locator("input[fieldref=\"ContractorsEquipmentInput.EmployeesToolsAndClothingIndicator\"]");

    public ILocator TotalCostOfWork => _page.Locator("input[fieldref=\"CovOwnersContractorsOrPrincipalsInput.UnitsOfExposureEstimated\"]");

    public ILocator TotalPayrollEstimated => _page.Locator("input[fieldref=\"CoverageInput.UnitsOfExposureEstimated\"]");

    public ILocator TotalPremium => _page.Locator("input[fieldref='CommercialGeneralLiabilityHistoryInput.TotalPremium'],input[fieldref='OtherInsuranceHistoryInput.TotalPremium']");

    public ILocator TotalSubjectivePremium => _page.Locator("input[fieldref=\"UmbrellaCommercialAutoInput.TotalSubjectPremiumCombined\"]");

    public ILocator BusinessownersTotalSubjectPremium => _page.Locator("input[fieldref=\"UmbrellaBusinessOwnersInputPremiums.TotalSubjectPremium\"], input[fieldref=\"UmbrellaCPPLiabilityInput.TotalSubjectPremium\"]");


    public ILocator Towing => _page.Locator("input[fieldref=\"CovTowingInput.Towing\"]");

    public ILocator TrailerInterchangeCollisionDeductible => _page.Locator("input[fieldref=\"RiskDefaultsInput.TrailerInterchangeCollisionDeductible\"]");

    public ILocator TrailerInterchangeCompDeductible => _page.Locator("input[fieldref=\"RiskDefaultsInput.TrailerInterchangeComprehensiveDeductible\"]");

    public ILocator TrailerInterchangeEnterDaysInsured => _page.Locator("input[fieldref=\"TrailerInterchangeInput.NumberOfDaysInsuredEstimate\"]");

    public ILocator TrailerInterchangeEnterOfTrailers => _page.Locator("input[fieldref=\"TrailerInterchangeInput.NumberOfTrailersEstimate\"]");

    public ILocator EndorsementMainType => _page.Locator("input[fieldref=\"CovEndorsementInput.Type\"]");

    public ILocator GLOCPRiskType => _page.Locator("input[fieldref=\"CovOwnersContractorsOrPrincipalsInput.Type\"]");

    public ILocator RiskSignsType => _page.Locator("input[fieldref=\"CoverageSignsIteratorInput.SignType\"]");

    public ILocator TypeOfContractor => _page.Locator("input[fieldref=\"ContractorsEquipmentInput.TypeOfContractor\"]");

    public ILocator TypeOfEquipment => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.EquipmentType\"]");

    public ILocator TypeOfLicense => _page.Locator("textarea[fieldref=\"AdditionalOtherInterestInput.DescriptionOfCompletedOps\"]");

    public ILocator UMBILimit => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='UMBI Limit*']/@for] | //label[normalize-space(string(.))='UMBI Limit*']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='UMBI Limit*']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator UMTypeDefaultSelections => _page.Locator("input[fieldref=\"LineStateUMDefaultsInput.UMType\"]");



    public ILocator UWQuestionsWorkersComp => _page.GetByRole(AriaRole.Link, new() { Name = "UW Questions - Workers Comp", Exact = true });

    public ILocator UmbrellaLimit => _page.Locator("input[fieldref=\"LineInput.UmbrellaLimit\"]");

    public ILocator UnderwritingInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

    public ILocator UninterruptiblePowerSource => _page.Locator("input[fieldref=\"ComputerSystemsUnderwritingQuestionsInput.UPSIndicator\"]");

    public ILocator UnnamedPremises => _page.Locator("input[fieldref=\"ComputerSystemsInput.UnnamedPremisesIndicator\"]");

    public ILocator UnnamedTerminalsLimit => _page.Locator("input[fieldref=\"MotorTruckCargoInput.UnnamedTerminalsLimit\"]");

    public ILocator UpdateAnswers => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true });

    public ILocator UWVHeader => _page.Locator("//div[@id='pageTitle' and text()='UW Questions - Umbrella']");

    public ILocator UsedAsShowroom => _page.Locator("input[fieldref=\"RiskCommercialAutoRiskInput.UsedAsShowroom\"]");

    public ILocator VIN => _page.Locator("input[fieldref=\"RiskVehicleInput.VIN\"]");

    public ILocator VacancyPermit => _page.Locator("input[fieldref=\"BuildingInput.VacancyPermit\"]");

    public ILocator VacantBuilding => _page.Locator("input[fieldref=\"BuildingInput.VacantBuilding\"]");

    public ILocator Valuation => _page.Locator("input[fieldref=\"RatingGroupInput.ValuationType\"]");

    public ILocator ValuationType => _page.Locator("input[fieldref=\"BuildingValuatioinInput.ValuationType\"]");

    public ILocator ValueBasis => _page.Locator("input[fieldref=\"RiskVehicleInput.StatedAmountIndicator\"]");

    public ILocator VehicleInformation => _page.Locator("input[fieldref=\"RiskHiredAndBorrowedWithDriverVehicleIteratorInput.VehicleInformation\"]");

    public ILocator VehicleSchedule1Veh => _page.GetByText("Veh #", new() { Exact = true });

    public ILocator VehicleType => _page.Locator("input[fieldref=\"LineInputNonShredded.VehicleType\"]");

    public ILocator VirusHarmfulCodeOrSimilarInstruction => _page.Locator("input[fieldref=\"ComputerSystemsInput.VirusIndicator\"]");

    public ILocator VolunteerHiredAutosCheckBox => _page.Locator("input[fieldref=\"LineStateInput.VolunteerHiredAuto\"]");

    public ILocator WCSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "WC Schedule", Exact = true });

    public ILocator WaitonPricingHeadingAndFillOutRequiredFields => _page.GetByText("Waiton Pricing Heading and Fill Out Required Fields", new() { Exact = true });

    public ILocator WaiverOfSubrogation => _page.Locator("input[fieldref=\"LineStateTermInput.WaiverOfSubrogation\"]");

    public ILocator WaiverOfSubrogationExposure => _page.Locator("input[fieldref=\"CoverageInput.WaiverOfSubrogationExposure\"]");

    public ILocator WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days => _page.Locator("input[fieldref=\"PolicyInput.ExposuresInsuredAN90Days\"]");

    public ILocator WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured => _page.Locator("[name=\"string_2F_2\"]");

    public ILocator WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage => _page.Locator("[name=\"string_2F_3\"]");

    public ILocator WhatIsTheConstructionOfEachSign => _page.Locator("textarea[fieldref=\"SignsUnderwritingQuestionsInput.Description\"]");

    public ILocator WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored => _page.Locator("[name=\"string_1F\"]");

    public ILocator WhatIsTheDistanceInFeetToTheNearestFireHydrant => _page.Locator("input[fieldref=\"ComputerSystemsUnderwritingQuestionsInput.HydrantDistance\"]");

    public ILocator WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment => _page.Locator("input[fieldref=\"ComputerSystemsUnderwritingQuestionsInput.FireDeptDistance\"]");

    public ILocator WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational => _page.Locator("input[fieldref=\"PolicyInput.ReasonForNewCoverage\"]");

    public ILocator WhatIsTheProcedureForTransportingTheComputerEquipment => _page.Locator("[name=\"string_2F\"]");

    public ILocator WhatIsThePublicProtectionClassRating => _page.Locator("input[fieldref=\"ComputerSystemsUnderwritingQuestionsInput.PublicProtectionClass\"]");

    public ILocator WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft => _page.Locator("[name=\"string_1F_1\"]");

    public ILocator WhichFormAreYouCompleting => _page.Locator("input[fieldref=\"UnderwritingQuestionsInput.MotorTruckFormSelection\"]");

    public ILocator WhyIsThisCoverageDesired => _page.Locator("textarea[fieldref=\"CovEndorsementsInput.Description\"]");

    public ILocator Year => _page.Locator("input[fieldref=\"RiskVehicleInput.Year\"]");

    public ILocator YearBuilt => _page.Locator("input[fieldref=\"BuildingInput.YearBuilt\"]");

    public ILocator YearLicensed => _page.Locator("input[fieldref=\"DriverUnderwritingInformationInput.YearLicensed\"]");

    public ILocator YearsInBusiness => _page.Locator("input[fieldref=\"AccountInput.YearsInBusiness\"]");

    public ILocator LocationZipCode => _page.Locator("input[fieldref=\"LocationInput.ZipCode\"]:visible, input[fieldref=\"AdditionalOtherInterestInput.ZipCode\"]:visible");

    public ILocator ThirdPartyDesigneeZipCode => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.ZipCode\"]");

    public ILocator GLOCPRiskZipCode => _page.Locator("input[fieldref=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderZipCode\"]");

    public ILocator EntityInfoFrameEntityInfoWindowFax => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.Fax\"]");

    public ILocator EntityInfoFrameEntityInfoWindowBureauNumber => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.BureauNumber\"]");

    public ILocator EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.StateUnemploymentNumber\"]");
}
