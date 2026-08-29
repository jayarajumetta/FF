using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class NavigationLocators
{
    private readonly IPage _page;
    public NavigationLocators(IPage page) => _page = page;

    public ILocator AVCostNew => _page.Locator("input[fieldref=\"CovAudioVisualInput.CostNew\"]");

    public ILocator AWhatIsThePublicProtectionClassRating => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B170_2_8-inputEl\"]");

    public ILocator AcceptUM => _page.Locator("div[fieldref=\"Accept UM\"]");

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator AccountsReceivableUWQuestions => _page.Locator("[id=\"ext-element-233\"]");

    public ILocator Add => _page.Locator("a[fieldref=\"Add\"]");

    public ILocator AddAddlInterest => _page.Locator("a[fieldref=\"Add Addl Interest\"]");

    public ILocator AddBuilding => _page.Locator("a[fieldref=\"Add Building\"]");

    public ILocator AddClass => _page.Locator("a[fieldref=\"Add Class\"]");

    public ILocator AddClassCode => _page.Locator("a[fieldref=\"Add Class Code\"]");

    public ILocator OK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator AddCoverageForm => _page.Locator("a[fieldref=\"Add Coverage Form\"]");

    public ILocator AddDriver => _page.Locator("a[fieldref=\"Add Driver\"]");

    public ILocator AddDriverName => _page.Locator("[id=\"f_eC9B5D952311D4E46BAAE946A2A0730E51034_1_1-inputEl\"]");

    public ILocator AddEndorsement => _page.Locator("a[fieldref=\"Add Endorsement\"]");


    public ILocator AddExcludedOfficerInformation => _page.Locator("a[fieldref=\"Add Excluded Officer Information\"]");

    public ILocator AddExcludedOthersInformation => _page.Locator("a[fieldref=\"Add Excluded Others' Information\"]");

    public ILocator AddGroup => _page.Locator("a[fieldref=\"Add Group\"]");

    public ILocator AddNotesRemarks => _page.Locator("a[fieldref=\"Add Notes/Remarks\"]");

    public ILocator AddOptionA => _page.Locator("a[fieldref=\"Add Option A\"]");

    public ILocator AddOtherInterest => _page.Locator("a[fieldref=\"Add Other Interest\"]");

    public ILocator AddOthersInformation => _page.Locator("a[fieldref=\"Add Others' Information\"]");

    public ILocator AddPartnerInformation => _page.Locator("a[fieldref=\"Add Partner Information\"]");

    public ILocator AddPremises => _page.Locator("a[fieldref=\"Add Premises\"]");

    public ILocator AddPriorCarrier => _page.Locator("a[fieldref=\"Add Prior Carrier\"]");

    public ILocator AddRiskAtThisLocation => _page.Locator("a[fieldref=\"Add Risk at This Location\"]");

    public ILocator AddSoleProprietorInformation => _page.Locator("a[fieldref=\"Add Sole Proprietor Information\"]");

    public ILocator AddThirdParty => _page.Locator("a[fieldref=\"Add Third Party\"]");


    public ILocator AdditionalOtherInterestAddress => _page.Locator("[name=\"AdditionalOtherInterestInput.Address1\"], [id=\"AdditionalOtherInterestInput.Address1\"]").First;

    public ILocator AdditionalOtherInterestInputFirstName => _page.Locator("[name=\"AdditionalOtherInterestInput.FirstName\"], [id=\"AdditionalOtherInterestInput.FirstName\"]").First;

    public ILocator AdditionalOtherInterestInputLastName => _page.Locator("[name=\"AdditionalOtherInterestInput.LastName\"], [id=\"AdditionalOtherInterestInput.LastName\"]").First;

    public ILocator PageTop => _page.Locator("[id=\"pageTop\"]");



    public ILocator Address => _page.Locator("[id=\"f_CCE14981F38894A679A407BA735B5959BD3_3_1-inputEl\"]");

    public ILocator CG2935AddLInsuredStateOrPoliticalPermitsAddress => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Address 1");

    public ILocator GLOCPRiskAddress => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA705E_3_1-inputEl\"]");

    public ILocator LocationAddress => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Address1");

    public ILocator AddressStreetCityStateZip => _page.Locator("[id=\"f_b7BA9D20D6B9840E99A47B1B0DFA716BF7_1_1-inputEl\"]");

    public ILocator AggregateLimit => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Aggregate Limit");

    public ILocator AnnualGrossReceipts => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF5875174088F_1_1-inputEl\"]");

    public ILocator AnyPersonalAutoPolicyListingNameInsured => _page.Locator("[id=\"f_uFE2672745CB24DB2A83158A3D6E7E97F13E_3_1-inputEl\"]");

    public ILocator AnyVehicleCoveredRegisteredInNotPrimaryState => _page.Locator("[id=\"f_uFE2672745CB24DB2A83158A3D6E7E97F187_3_1-inputEl\"]");

    public ILocator AreAnySignsOffPremisesOrNotAttachedToBuilding => _page.Locator("[id=\"f_sEDD5CE21D8434468900294193CF0200E1D_2_1-inputEl\"]");

    public ILocator ArePhysicalsRequiredAfterOffersOfEmploymentAreMade => _page.Locator("input[fieldref=\"UnderwritingQuestionsWorkersCompInput.PhysicalsRequiredAfterEmploymentOffers\"]");

    public ILocator AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy => _page.Locator("input[fieldref=\"UnderwritingQuestionsAutoInput.AnyCommercialVehiclesOwned\"]");

    public ILocator AreThereAnyOfficersThatShouldBeExcluded => _page.Locator("[id=\"f_lA2C9A848A1FC45D39BB20EBBC28014492E1_3_1-inputEl\"]");

    public ILocator AssignLocation => _page.Locator("a[fieldref=\"Assign Location\"]");

    public ILocator AssignLocations => _page.GetByRole(AriaRole.Link, new() { Name = "Assign Locations", Exact = true });

    public ILocator AudioVisual => _page.Locator("[id=\"f_c6FBE834FF11D44EEA4139F156BB928EC236C_2_1-inputEl\"]");

    public ILocator AvailableClassifications => _page.Locator("[id=\"f_cF339927B88A5461CBDBBA081531BA503602_3_1-inputEl\"]");

    public ILocator AverageNumberOfDaysService => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740890_1_1-inputEl\"]");

    public ILocator AverageNumberOfWorkingDays => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740891_1_1-inputEl\"]");

    public ILocator AverageServiceCharge => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740892_1_1-inputEl\"]");

    public ILocator AverageValuePerOrder => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740893_1_1-inputEl\"]");

    public ILocator BAreThereAnyPrivateProtectionImprovements => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B171_2_8-inputEl\"]");

    public ILocator BG2Symbol => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D026E_3_1-inputEl\"]");

    public ILocator BG2SymbolPrefix => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0270_3_1-inputEl\"]");

    public ILocator BaileesCustomerUWQuestions => _page.Locator("[id=\"ext-element-4167\"]");

    public ILocator BaileesCustomersHeading => _page.GetByText("Bailees Customers Heading", new() { Exact = true });

    public ILocator BillType => _page.Locator("input[fieldref=\"BillingDetailInput.BillType\"]");



    public ILocator BodyStyle => _page.Locator("input[fieldref=\"RiskVehicleInput.BodyStyle\"]");

    public ILocator BoomDeductible => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FC8_3_1-inputEl\"]");

    public ILocator BorrowingHiringOrLeasingWithinYear => _page.Locator("[id=\"f_uFE2672745CB24DB2A83158A3D6E7E97F142_3_1-inputEl\"]");


    public ILocator BuildingLimit => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Building Limit");

    public ILocator RiskInputRatingGroupID => _page.Locator("input[fieldref=\"RiskInput.RatingGroupID\"]");

    public ILocator BusinessInterruptionDescriptionOfScheduledProperty => _page.Locator("input[fieldref=\"BusinessInterruptionOptionAInput.DescriptionOfScheduledProperty\"]");


    public ILocator BusinessInterruptionEndorsement => _page.Locator("input[fieldref=\"LineCoveragesInput.BusinessInterruptionEndorsement\"]");

    public ILocator BusinessInterruptionLimitOfInsurance => _page.Locator("input[fieldref=\"BusinessInterruptionOptionAInput.LimitOfInsurance\"]");

    public ILocator CA2325LeasedWorkersCoverage => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "[CA2325] Leased Workers Coverage");

    public ILocator CA9940ContractProvisions => _page.Locator("input[fieldref=\"CovEndorsementsInput.ContractProvisions\"]");

    public ILocator CA9940Make => _page.Locator("input[fieldref=\"CovEndorsementsInput.Make\"]");

    public ILocator CA9940Model => _page.Locator("input[fieldref=\"CovEndorsementsInput.Model\"]");

    public ILocator CA9940VIN => _page.Locator("input[fieldref=\"CovEndorsementsInput.VIN\"]");

    public ILocator CA9940Year => _page.Locator("input[fieldref=\"CovEndorsementsInput.Year\"]");

    public ILocator CA9948ClassesOfCommoditiesTransported => _page.Locator("input[fieldref=\"CovEndorsementsInput.ClassesOfCommoditiesTransported\"]");

    public ILocator ExcludeUndergroundPropertyDamageHazard => _page.Locator("input[fieldref=\"CovEndorsementsInput.IndicatorPropertyDamageCG2142\"]");


    public ILocator CGLLimits => _page.Locator("input[fieldref=\"UmbrellaGeneralLiabilityInputLimitsNonShredded.CGLLimits\"]");


    public ILocator CWhatIsTheDistanceInFeetToTheNearestHydrant => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B175_2_8-inputEl\"]");

    public ILocator CallISO => _page.Locator("a[fieldref=\"Call ISO\"]");

    public ILocator Carrier => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Carrier");

    public ILocator CauseOfLoss => _page.Locator("input[fieldref=\"RatingGroupInput.CauseOfLossType\"]");

    public ILocator City => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "City*");

    public ILocator ClassCode => _page.Locator("[fieldref=\"CovOwnersContractorsOrPrincipalsInputNonShredded.ClassCode\"], [data-fieldref=\"CovOwnersContractorsOrPrincipalsInputNonShredded.ClassCode\"]");

    public ILocator ClassCodeFrame => _page.GetByText("Class Code Frame", new() { Exact = true });

    public ILocator ClassCodeFrameClassCodeWindow => _page.GetByText("Class Code Window", new() { Exact = true });

    public ILocator ClassificationOfRisk => _page.Locator("[id=\"f_c4FFD73A13C164B729C39A3F5C851102319_1_1-inputEl\"]");


    public ILocator ClickAddExcludedDriver => _page.Locator("a[fieldref=\"Add Excluded Driver\"]");

    public ILocator AddClient => _page.Locator("a[fieldref=\"Add Client\"]");

    public ILocator PolicyCovgComputerSystemsCoinsurance => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F83_3_4-inputEl\"]");

    public ILocator RatingGroupsCoinsurance => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Coinsurance");

    public ILocator PolicyCovgContractorsEquipmentCoinsurance => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FC2_3_1-inputEl\"]");

    public ILocator Collision => _page.Locator("[fieldref=\"CovDriveOtherCarCollisionInput.Indicator\"], [data-fieldref=\"CovDriveOtherCarCollisionInput.Indicator\"]");

    public ILocator CollisionCoverage => _page.Locator("[id=\"f_c7D7AC70D2F5B46AE89DB2111B306EB762349_2_1-inputEl\"]");

    public ILocator CollisionDeductible => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Collision Deductible");

    public ILocator HiredAutoCollisionDeductible => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Collision Deductible*");

    public ILocator StateDetailsHiredAutoPDWithoutDriverIfAny => _page.Locator("[fieldref=\"CovHiredAndBorrowedCollisionInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedCollisionInput.IfAny\"]");

    public ILocator StateDetailsHiredAutoPhysicalDamageWithDriverIfAny => _page.Locator("[fieldref=\"CovHiredAndBorrowedCollisionWithDriverInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedCollisionWithDriverInput.IfAny\"]");

    public ILocator CommercialAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Commercial Auto", Exact = true });

    public ILocator CommonNavigationLinksNext => _page.Locator("a[fieldref=\"Next\"]");

    public ILocator CompanyName => _page.Locator("input[fieldref=\"WaiverCompanyName.CompanyName\"]");

    public ILocator Comprehensive => _page.Locator("[fieldref=\"CovDriveOtherCarOTCInput.Indicator\"], [data-fieldref=\"CovDriveOtherCarOTCInput.Indicator\"]");

    public ILocator ComputerEquipment => _page.Locator("[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB1C_1_1-inputEl\"]");

    public ILocator ComputerSystemsUWQuestions => _page.Locator("[id=\"ext-element-4168\"]");

    public ILocator BuildingDetailConstruction => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D023F_3_1-inputEl\"]");

    public ILocator RiskBaileesCustomersConstruction => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF5875174088B_1_1-inputEl\"]");

    public ILocator ConstructionCode => _page.Locator("[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB114_1_1-inputEl\"]");

    public ILocator RiskAccountsReceivableConstruction => _page.Locator("[id=\"f_rFE68631942E64B1BA3A954F11A424A13D_1_1-inputEl\"]");

    public ILocator ContractorsEquipmentUWQuestions => _page.Locator("[id=\"ext-element-4169\"]");

    public ILocator CoverageBeginDate => _page.Locator("input[fieldref=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.PeriodOfOperationsFrom\"]");

    public ILocator CoverageEndDate => _page.Locator("input[fieldref=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.PeriodOfOperationsTo\"]");

    public ILocator PolicyCovgGLCoverageForm => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Coverage Form");

    public ILocator PolicyCovgSignsCoverageForm => _page.Locator("[id=\"f_cAFD1AA97819C467694F348BB5BA65F85E45_3_6-inputEl\"]");

    public ILocator RiskMainCoverageForm => _page.Locator("[id=\"f_l1A9C547373A24FF38DA9C54C82FB349824_3_1-inputEl\"]");

    public ILocator PolicyCovgComputerSystemsCoverageFormDisplay => _page.Locator("[id=\"f_iB27E9D1A7BBB4CC688DAC59E11C5C2DED60_3_4-inputEl\"]");

    public ILocator PolicyCovgBaileesCutomersCoverageFormDisplay => _page.Locator("[id=\"f_iA14B1E3D0C8544FA84D50C076D97DD44D60_3_7-inputEl\"]");

    public ILocator PolicyCovgMotorTruckCargoCoverageFormDisplay => _page.Locator("[id=\"f_i6880B67F580944108A4FCC241C2B2649D60_3_5-inputEl\"]");

    public ILocator PolicyCovgSignsCoverageFormDisplay => _page.Locator("[id=\"f_iCCB999F03E934DE9BF81315D41AE8572D60_3_6-inputEl\"]");

    public ILocator PolicyCovgContractorsEquipmentCoverageFormDisplay => _page.Locator("[id=\"f_i2B400B3B804E4D9EA12FE1D96F9ADFC6D60_3_1-inputEl\"]");

    public ILocator CoverageFormToBeAdded => _page.Locator("input[fieldref=\"LineInput.CoverageForm\"]");

    public ILocator CoverageType => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB401072_3_5-inputEl\"]");

    public ILocator CoveredPropertyConsistingPrincipallyOf => _page.Locator("[fieldref=\"MotorTruckCargoInput.Description\"], [data-fieldref=\"MotorTruckCargoInput.Description\"]");

    public ILocator CreateValuation => _page.Locator("a[fieldref=\"Create Valuation\"]");

    public ILocator DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B178_2_8-inputEl\"]");

    public ILocator DataAndMedia => _page.Locator("[id=\"f_c3EF1D09EE0E84AB189A6366AD3F277B2D_1_1-inputEl\"]");

    public ILocator DateOfBirth => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010CF_1_1-inputEl\"]");

    public ILocator DateOfHire => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D6_1_1-inputEl\"]");

    public ILocator DebrisRemovalAdditional => _page.Locator("input[fieldref=\"BuildingInput.DebrisRemoval\"]");

    public ILocator DebrisRemovalAdditionalLimit => _page.Locator("input[fieldref=\"BuildingInput.DebrisRemovalLimit\"]");

    public ILocator DedType => _page.Locator("input[fieldref=\"LineInput.DeductibleType\"]");

    public ILocator DedicatedLine => _page.Locator("[id=\"f_c7FA512A090F641B9A6BB95F4C656EE1841_2_21-inputEl\"]");

    public ILocator RatingGroupsDeductible => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Deductible");

    public ILocator EndorsementIF0002WaterborneEquipmentDeductible => _page.Locator("[id=\"f_c4CA5AF1ED9DF445F976D32FE5E1139DD11D_3_14-inputEl\"]");

    public ILocator PolicyCovgMotorTruckCargoDeductible => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB40107F_3_5-inputEl\"]");

    public ILocator RiskBaileesCustomersDeductible => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF5875174087F_1_1-inputEl\"]");

    public ILocator BuildingDetailDeductible => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0260_3_1-inputEl\"]");

    public ILocator DeductibleBasis => _page.Locator("input[fieldref=\"LineInput.DeductibleScope\"]");

    public ILocator PolicyCovgContractorsEquipmentDeductible => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FC3_3_1-inputEl\"]");

    public ILocator PolicyCovgComputerSystemsDeductible => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F7E_3_4-inputEl\"]");

    public ILocator BuildingDetailDeductibleIncreasedTheft => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0263_3_1-inputEl\"]");

    public ILocator RatingGroupsDeductibleIncreasedTheft => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Deductible Increased Theft");

    public ILocator BuildingDetailDeductibleWindHail => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0265_3_1-inputEl\"]");

    public ILocator RatingGroupsDeductibleWindHail => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Deductible Wind Hail");

    public ILocator DefaultExpModType => _page.Locator("input[fieldref=\"LineInput.ModType\"]");

    public ILocator DefaultExperienceMod => _page.Locator("input[fieldref=\"LineInput.ExperienceModifier\"]");

    public ILocator DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy => _page.Locator("[fieldref=\"GeneralLiabilityInput.Description\"], [data-fieldref=\"GeneralLiabilityInput.Description\"]");

    public ILocator PolicyCovgContractorsEquipmentDescription => _page.Locator("[id=\"f_i2B400B3B804E4D9EA12FE1D96F9ADFC6D62_3_1-inputEl\"]");

    public ILocator PolicyCovgBaileesCutomersDescription => _page.Locator("[id=\"f_iA14B1E3D0C8544FA84D50C076D97DD44D62_3_7-inputEl\"]");

    public ILocator PolicyCovgComputerSystemsDescription => _page.Locator("[id=\"f_iB27E9D1A7BBB4CC688DAC59E11C5C2DED62_3_4-inputEl\"]");

    public ILocator RatingGroupsDescription => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Description");

    public ILocator PolicyCovgSignsDescription => _page.Locator("[id=\"f_iCCB999F03E934DE9BF81315D41AE8572D62_3_6-inputEl\"]");

    public ILocator PolicyCovgMotorTruckCargoDescription => _page.Locator("[id=\"f_i6880B67F580944108A4FCC241C2B2649D62_3_5-inputEl\"]");

    public ILocator DescriptionOfBusinessActivites => _page.Locator("input[fieldref=\"BusinessInterruptionEndorsementInput.DescriptionOfBusinessActivites\"]");

    public ILocator DescriptionOfOperationS => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Description of Operation(s)");

    public ILocator DescriptionOfOperations => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Description of Operations");

    public ILocator DescriptionOfSpecifiedOperation => _page.Locator("input[fieldref=\"PolicyOutput.DescriptionOfOperations\"]");

    public ILocator DesignatedWorkplacesExclusionOK => _page.Locator("a[fieldref=\"Add Designated Workplace\"]");

    public ILocator Select => _page.Locator("[id=\"dctGridLink\"]");


    public ILocator DoYouHaveACDLLicense => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D01119_1_1-inputEl\"]");

    public ILocator DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup => _page.Locator("input[fieldref=\"PolicyInput.AnyRiskPowerUnitOtherThanWindmillOrBackup\"]");

    public ILocator DoesTheApplicantWishToCoverAnySignsInsideTheirPremises => _page.Locator("[id=\"f_s5879EFE3310C457293652ECABD56DCF11D_2_2-inputEl\"]");

    public ILocator DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionG\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionG\"]");

    public ILocator DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionH\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionH\"]");

    public ILocator DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionF\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionF\"]");

    public ILocator DriveOtherCar => _page.Locator("[fieldref=\"LineStateInput.DriveOtherCarCoverage\"], [data-fieldref=\"LineStateInput.DriveOtherCarCoverage\"]");


    public ILocator DriversLicenseNumber => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Drivers License Number");

    public ILocator DryCleaning => _page.Locator("[id=\"f_b71504B515DF24669A165EFFA75C7935615D_2_1-inputEl\"]");

    public ILocator DuplicatedRecords => _page.Locator("[id=\"f_c4FFD73A13C164B729C39A3F5C851102318_1_1-inputEl\"]");

    public ILocator EAreNoSmokingRulesPostedAndEnforced => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B17B_2_8-inputEl\"]");

    public ILocator EMail => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.Email\"]");

    public ILocator Earthquake => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF5875174089A_1_1-inputEl\"]");

    public ILocator EasyPay => _page.Locator("input[fieldref=\"BillingDetailInput.EasyPay\"]");

    public ILocator BusinessownersEffectiveDate => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Effective Date");


    public ILocator PolicyInfoRequiredAndOptionalFieldsEffectiveDate => _page.Locator("input[fieldref=\\"PolicyInput.EffectiveDate\\"]");

    public ILocator EligibleForEnhancedWindRatingProgram => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D02BE_3_1-inputEl\"]");

    public ILocator EmployeeHiredAutosCheckBox => _page.Locator("[fieldref=\"LineStateInput.EmployeeHiredAuto\"], [data-fieldref=\"LineStateInput.EmployeeHiredAuto\"]");

    public ILocator EmployersLiab => _page.GetByRole(AriaRole.Link, new() { Name = "Employers Liab", Exact = true });



    public ILocator FirstEndorsementScheduleRow => _page.GetByText("$1", new() { Exact = true });

    public ILocator FirstEndorsementTableRow => _page.GetByText("#1", new() { Exact = true });

    public ILocator SecondEndorsementTableRow => _page.GetByText("$2", new() { Exact = true });

    public ILocator CG2401NonBindingArbitrationEndorsementType => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Endorsement Type");

    public ILocator BAPEndorsementsEndorsementType => _page.Locator("[id=\"f_lCFA4B66735E24DCDA7F8290E1448DDF960_3_1-inputEl\"]");

    public ILocator EndorsementsPartnersOfficersAndOthersExclusionEndorsementType => _page.Locator("[id=\"f_c19BE39E5AC0F487CBB1049569BE6DC56236_3_6-inputEl\"]");




    public ILocator EngineSizeCc => _page.Locator("input[fieldref=\"RiskCommercialAutoRiskInput.EngineSizeCC\"]");

    public ILocator EntityInfoFrame => _page.GetByText("Entity Info Frame", new() { Exact = true });


    public ILocator EstimatedHighestValue => _page.Locator("[id=\"f_c43D7743D9BD44829A7C9322C2ACC793C55_2_1-inputEl\"]");

    public ILocator EstimatorType => _page.Locator("input[fieldref=\"BuildingValuatioinInput.EstimatorType\"]");

    public ILocator ExcessLiabilityIfAny => _page.Locator("[fieldref=\"CovHiredAndBorrowedExcessLiabilityInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedExcessLiabilityInput.IfAny\"]");

    public ILocator ExcludeCollapseHazard => _page.Locator("[fieldref=\"CovEndorsementsInput.IndicatorCollapseCG2142\"], [data-fieldref=\"CovEndorsementsInput.IndicatorCollapseCG2142\"]");

    public ILocator ExcludeExplosionHazard => _page.Locator("[fieldref=\"CovEndorsementsInput.IndicatorExplosionCG2142\"], [data-fieldref=\"CovEndorsementsInput.IndicatorExplosionCG2142\"]");

    public ILocator ExcludedLiabilityConfidentialInformation => _page.Locator("input[fieldref=\"CovConfidentialInfoLiabilityInput.FormSelection\"]");

    public ILocator ExperienceModType => _page.Locator("input[fieldref=\"ExperienceModInput.ModType\"]");

    public ILocator ExperienceRated => _page.Locator("input[fieldref=\"LineInput.ExperienceRatedIndicator\"]");

    public ILocator ExperienceRatingOptions => _page.Locator("input[fieldref=\"LineStateTermInput.ExperienceRatingOptions\"]");

    public ILocator BusinessownersExpirationDate => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Expiration Date");


    public ILocator Exposure => _page.Locator("input[fieldref=\"RiskGeneralLiabilityInput.UnitsOfExposureEstimated\"]");

    public ILocator ExtendedEmployeeCoverage => _page.Locator("[fieldref=\"RiskNonOwnedAutoInput.ExtendedEmployeeCov\"], [data-fieldref=\"RiskNonOwnedAutoInput.ExtendedEmployeeCov\"]");

    public ILocator ExtraExpense => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8C_3_4-inputEl\"]");

    public ILocator FeetFromHydrant => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Feet From Hydrant");

    public ILocator FireDamage => _page.Locator("input[fieldref=\"CovFireDamageInput.FireDamage\"]");

    public ILocator StateDetailsDriveOtherCarFirstName => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "First Name");

    public ILocator FirstName => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010C8_1_1-inputEl\"]");

    public ILocator GCW => _page.Locator("input[fieldref=\"RiskTruckInput.GCW\"]");

    public ILocator GLDetail => _page.Locator("a[fieldref=\"Detail\"]");

    public ILocator GLUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "GL UW Questions", Exact = true });

    public ILocator GeneralLiab => _page.GetByRole(AriaRole.Link, new() { Name = "General Liab", Exact = true });


    public ILocator GeneralUWQuestions => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "General UW Questions");

    public ILocator GetCalculatedValue => _page.Locator("a[fieldref=\"Get Calculated Value\"]");

    public ILocator GroupClass => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB401088_3_5-inputEl\"]");

    public ILocator HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring => _page.Locator("input[fieldref=\"UnderwritingQuestionsAutoInput.AnyFelonies\"]");

    public ILocator HaveYouHadAnyLiabilityLossesInTheLast5YearsOnAnyPrimaryOrExcessPolicy => _page.Locator("input[fieldref=\"UnderwritingQuestionsUmbrellaInput.AnyLiabilityLosses\"]");

    public ILocator HiredAutoCA2001Address => _page.Locator("input[fieldref=\"CovHiredAutoCA2001Input.Address1\"]");

    public ILocator HiredAutoCA2001FirstName => _page.Locator("input[fieldref=\"CovHiredAutoCA2001Input.FirstName\"]");

    public ILocator HiredAutoCA2001LastName => _page.Locator("input[fieldref=\"CovHiredAutoCA2001Input.LastName\"]");

    public ILocator HiredAutoCA2001ZipCode => _page.Locator("input[fieldref=\"CovHiredAutoCA2001Input.ZipCode\"]");

    public ILocator HiredAutoExtAddlInsured => _page.Locator("input[fieldref=\"CovLiabilityInput.HiredAutoExtAddlInsured\"]");

    public ILocator HiredAutoOK => _page.Locator("input[fieldref=\"CovLiabilityInput.HiredAutoExtAddlInsuredForm\"]");

    public ILocator HiredAutoLiability => _page.Locator("[fieldref=\"LineStateInput.HiredLiability\"], [data-fieldref=\"LineStateInput.HiredLiability\"]");

    public ILocator HiredAutoPhysicalDamageWithDriver => _page.Locator("[fieldref=\"LineStateInput.HiredPhysicalDamageWithDriver\"], [data-fieldref=\"LineStateInput.HiredPhysicalDamageWithDriver\"]");

    public ILocator HiredAutoPhysicalDamageWithoutDriver => _page.Locator("[fieldref=\"LineStateInput.HiredPhysicalDamage\"], [data-fieldref=\"LineStateInput.HiredPhysicalDamage\"]");

    public ILocator HiredEquipment => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FEE_3_1-inputEl\"]");

    public ILocator HowOftenIsDataBackedUp => _page.Locator("[name=\"string_2F_5\"]");

    public ILocator AdditionalInterestsScheduleIFRAME => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "IFRAME");

    public ILocator DriverDetailIFRAME => _page.Locator("[id=\"dctPopup_dctPopupWindow34CAB0C1A0A47F298A990A36C62FE6D0\"]");

    public ILocator IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationS => _page.Locator("input[fieldref=\"FarmLocationInput.FarmLocation\"]");

    public ILocator IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremises => _page.Locator("input[fieldref=\"PremisesInput.Premises\"]");

    public ILocator IFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivities => _page.GetByText("Description Of Premises Or Activities", new() { Exact = true });

    public ILocator IFRAMEDuckCreekPolicyExcludedDriver => _page.GetByText("Excluded Driver", new() { Exact = true });

    public ILocator IFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalS => _page.Locator("input[fieldref=\"AnimalsInput.Animals\"]");

    public ILocator IFRAMEDuckCreekPolicyVehicleAssociation => _page.GetByText("Vehicle Association*", new() { Exact = true });

    public ILocator BAPEndorsementsIFRAME => _page.Locator("[id=\"dctPopup_dctPopupWindow1631A82AB27744695E74FDAA3357B203\"]");

    public ILocator IfYesDescribe => _page.Locator("[fieldref=\"ContractorsEquipmentUnderwritingQuestionsInput.Description\"], [data-fieldref=\"ContractorsEquipmentUnderwritingQuestionsInput.Description\"]");

    public ILocator IfYesExplain => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionFsub\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionFsub\"]");

    public ILocator ImportPolicyData => _page.Locator("a[fieldref=\"Import Policy Data\"]");


    public ILocator IncreasedPollutantCleanup => _page.Locator("input[fieldref=\"LocationPropertyInput.IncreasedPollutantCleanup\"]");

    public ILocator IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated => _page.Locator("[name=\"string_2F_1\"]");

    public ILocator InsuranceHistory => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance History", Exact = true });

    public ILocator InsuredType => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Insured Type*");

    public ILocator Interest => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0249_3_1-inputEl\"]");

    public ILocator IntrastateRiskID => _page.Locator("input[fieldref=\"ExperienceModInput.RiskID\"]");

    public ILocator IsTheBuildingCooled => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D02AD_3_1-inputEl\"]");

    public ILocator IsTheBuildingHeatedWithASolidFuelHeatingDevice => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0296_3_1-inputEl\"]");

    public ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Is the Insured engaged in any Snow or Ice Removal Operations?*");

    public ILocator IsThereAPriorCarrier => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Is there a Prior Carrier?*");

    public ILocator IsThisCoverageBound => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Is this coverage bound?*");

    public ILocator IsThisPolicyBeingFullyCancelled => _page.Locator("input[fieldref=\"PolicyInput.FullyCancelled\"]");

    public ILocator IsThisVehicleUsedInSnowPlowOperations => _page.Locator("input[fieldref=\"RiskTruckInput.SnowPlowOperations\"]");

    public ILocator JavaScript => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "JavaScript");

    public ILocator LastName => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010CA_1_1-inputEl\"]");

    public ILocator StateDetailsDriveOtherCarLastName => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Last Name");

    public ILocator Laundry => _page.Locator("[id=\"f_bD3790336B18440B2B60CC0B7F5F4E10315D_2_2-inputEl\"]");

    public ILocator Lettering => _page.Locator("[id=\"f_r99A2986D696A457DA1C69BB16D902CEF19_1_1-inputEl\"]");

    public ILocator CommercialAutoLiabilityLimit => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Liability Limit*");


    public ILocator PolicyCovgBaileesPropertyAwayFromYourPremisesLimit => _page.Locator("[id=\"f_b7BA9D20D6B9840E99A47B1B0DFA716BF8_1_1-inputEl\"]");

    public ILocator EndorsementIF0002WaterborneEquipmentLimit => _page.Locator("[id=\"f_c4CA5AF1ED9DF445F976D32FE5E1139DD11C_3_14-inputEl\"]");

    public ILocator RiskBaileesCustomersLimit => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740895_1_1-inputEl\"]");

    public ILocator LimitOfInsurance => _page.Locator("[id=\"f_r99A2986D696A457DA1C69BB16D902CEF16_1_1-inputEl\"]");

    public ILocator LineConditioner => _page.Locator("[id=\"f_c7FA512A090F641B9A6BB95F4C656EE183F_2_21-inputEl\"]");

    public ILocator ListAllPoliciesWithAmericanNational => _page.Locator("[fieldref=\"UnderwritingQuestionsWorkersCompInput.ListAllPoliciesWithAmericanNational\"], [data-fieldref=\"UnderwritingQuestionsWorkersCompInput.ListAllPoliciesWithAmericanNational\"]");

    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    public ILocator LoanLeaseGap => _page.Locator("input[fieldref=\"RiskCommercialAutoRiskInput.LoanLease\"]");



    public ILocator LocationAssignment => _page.GetByText("Location Assignment", new() { Exact = true });

    public ILocator LocationID => _page.Locator("input[fieldref=\"AdditionalOtherInterestLocationsInput.LocationID\"]");

    public ILocator LocationOfCoveredOperations => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA7059_3_1-inputEl\"]");



    public ILocator Make => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Make*");

    public ILocator MaritalStatus => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D2_1_1-inputEl\"]");

    public ILocator Medical => _page.Locator("input[fieldref=\"CovMedicalInput.Medical\"]");

    public ILocator MeritRating => _page.GetByText("Merit Rating", new() { Exact = true });

    public ILocator MilesFromFireDepartment => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Miles From Fire Department");

    public ILocator MiscItemsBlanketCoverage => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FEC_3_1-inputEl\"]");

    public ILocator Model => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Model*");

    public ILocator ModificationFactor => _page.Locator("input[fieldref=\"LineInput.ModificationFactor\"]");



    public ILocator N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms => _page.Locator("[id=\"f_b7DEEC9594E6B4D83BD0180865919757B16B_2_10-inputEl\"]");

    public ILocator N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft => _page.Locator("[name=\"string_92_3\"]");

    public ILocator N11AreDriversMVRsAndTripLogsMaintained => _page.Locator("[id=\"f_m2B14DC917C294E2289B9F03AAECA7FDD90_2_11-inputEl\"]");

    public ILocator N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit => _page.Locator("[name=\"string_169_3\"]");

    public ILocator N12AreDriversMVRsReviewedOnARegularBasisAndMaintained => _page.Locator("[id=\"f_bB1C8725295D646D28E8F8F6AFF6DCD4A16B_2_12-inputEl\"]");

    public ILocator N12HowOftenAreTheseLogsReviewedOrUpdated => _page.Locator("[name=\"string_92_4\"]");

    public ILocator N13LiveAnimalInTransitCoverage => _page.Locator("[id=\"f_mDB9F63B542BB45E4A6ED96CA4FEB0A4D99_2_13-inputEl\"]");

    public ILocator N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle => _page.Locator("[name=\"string_169_4\"]");

    public ILocator N14LegalLiabilityCoverage => _page.Locator("[id=\"f_m1DC94D997BEB443ABFC8A1974E835E9399_2_14-inputEl\"]");

    public ILocator N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage => _page.Locator("[name=\"string_169_5\"]");

    public ILocator N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft => _page.Locator("[name=\"string_169_6\"]");

    public ILocator N16DoesTheRiskUseReleaseForms => _page.Locator("[id=\"f_b9A3E482906284343AC03033C7B31809816B_2_16-inputEl\"]");

    public ILocator N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment => _page.Locator("[name=\"string_92\"]");

    public ILocator N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises => _page.Locator("[name=\"string_169\"]");

    public ILocator N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities => _page.Locator("[name=\"string_92_1\"]");

    public ILocator N2ndClassCategory => _page.Locator("input[fieldref=\"RiskTruckInput.SecondaryClassCategory\"]");

    public ILocator N2ndClassCode => _page.Locator("input[fieldref=\"RiskTruckInput.SecondaryClassCode\"]");

    public ILocator N3DoesTheApplicantHaulForOthers => _page.Locator("[id=\"f_m18CC23D224C1479990CCE2D5EBA3ED3C90_2_3-inputEl\"]");

    public ILocator N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair => _page.Locator("[name=\"string_169_1\"]");

    public ILocator N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated => _page.Locator("[name=\"string_169_2\"]");

    public ILocator N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer => _page.Locator("[name=\"string_92_2\"]");

    public ILocator N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained => _page.Locator("[id=\"f_b7A8649BA88594F07A2EED84065C05C7116B_2_5-inputEl\"]");

    public ILocator N5Deductible => _page.Locator("[id=\"f_cAFD1AA97819C467694F348BB5BA65F85E47_3_6-inputEl\"]");

    public ILocator N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached => _page.Locator("[id=\"f_m8488653223CB4B4BA40DE31CDB6F800A90_2_5-inputEl\"]");

    public ILocator N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied => _page.Locator("[id=\"f_b1C15D4BB95924355B6C9DB3E4D486C7D16B_2_6-inputEl\"]");

    public ILocator N6DoesTheApplicantPullDoubleOrTripleTrailers => _page.Locator("[id=\"f_m73855E80098B4D51BF013C509D9F26A390_2_6-inputEl\"]");

    public ILocator N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises => _page.Locator("[id=\"f_b31C4DC1E36A54CE78682FB544E3BA0AB16B_2_7-inputEl\"]");

    public ILocator N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended => _page.Locator("[id=\"f_mC7C58EF91D2B448AB0D44299B4464B9690_2_7-inputEl\"]");

    public ILocator N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate => _page.Locator("[id=\"f_mFDAD2FC147D34702A28F7B4FB47773E190_2_8-inputEl\"]");

    public ILocator N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities => _page.Locator("[id=\"f_mBE856C8E1BC04AFE85652589CD82142890_2_9-inputEl\"]");

    public ILocator N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem => _page.Locator("[id=\"f_b8CF5D796EA6C4194B4DA603919413A5B16B_2_9-inputEl\"]");

    public ILocator NAICSCodeSearchValue => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "NAICSCodeSearchValue");

    public ILocator NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices => _page.Locator("input[fieldref=\"ActivitiesInput.Activities\"]");

    public ILocator Names => _page.Locator("[id=\"f_CCE14981F38894A679A407BA735B5959BD2_3_1-inputEl\"]");

    public ILocator NoKnownLosses => _page.GetByRole(AriaRole.Checkbox, new() { Name = "No known losses", Exact = true });

    public ILocator NonOwnedAuto => _page.Locator("[fieldref=\"LineCoveragesInput.NonOwnedAuto\"], [data-fieldref=\"LineCoveragesInput.NonOwnedAuto\"]");



    public ILocator NumberOfEmployees => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Number Of Employees");

    public ILocator NumberOfFullTimeEmployees => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Number of Full-Time Employees*");

    public ILocator NumberOfPartTimeEmployees => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Number of Part-Time Employees*");

    public ILocator NumberOfVehicles => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB40108C_3_5-inputEl\"]");

    public ILocator OCP => _page.GetByRole(AriaRole.Link, new() { Name = "OCP", Exact = true });

    public ILocator OKControl => _page.Locator("a[fieldref=\"OK\"]");




    public ILocator OTCCausesOfLoss => _page.Locator("[id=\"f_cBFB0A5467643454EAC6DC41BBBFF51C22337_2_1-inputEl\"]");

    public ILocator StateDetailsHiredAutoPDWithoutDriverOTCDeductible => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "OTC Deductible*");

    public ILocator StateDetailsDriveOtherCarOTCDeductible => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "OTC Deductible");

    public ILocator StateDetailsHiredAutoPDWithoutDriverIfAnyField => _page.Locator("[fieldref=\"CovHiredAndBorrowedOTCInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedOTCInput.IfAny\"]");

    public ILocator StateDetailsHiredAutoPhysicalDamageWithDriverIfAnyField => _page.Locator("[fieldref=\"CovHiredAndBorrowedOTCWithDriverInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedOTCWithDriverInput.IfAny\"]");

    public ILocator OccupancyType => _page.Locator("input[fieldref=\"OccupancyInput.OccupancyTypeMonoline\"]");

    public ILocator Occupied => _page.Locator("input[fieldref=\"BuildingInput.VacancyPercentageOccupied\"]");

    public ILocator OccurenceLimit => _page.Locator("input[fieldref=\"LineInput.PolicyPerOccurenceLimit\"]");

    public ILocator OfEmployees => _page.Locator("[fieldref=\"RiskNonOwnedAutoInput.NumberOfEmployeesEstimate\"], [data-fieldref=\"RiskNonOwnedAutoInput.NumberOfEmployeesEstimate\"]");

    public ILocator OfFullTimeEmployees => _page.Locator("input[fieldref=\"LineInput.NumberOfFullTimeEmployees\"]");

    public ILocator OfPartTimeEmployees => _page.Locator("input[fieldref=\"LineInput.NumberOfPartTimeEmployees\"]");

    public ILocator OfPartners => _page.Locator("[fieldref=\"RiskNonOwnedAutoInput.NumberOfPartnersEstimate\"], [data-fieldref=\"RiskNonOwnedAutoInput.NumberOfPartnersEstimate\"]");

    public ILocator OfSeasonalTemporaryEmployees => _page.Locator("input[fieldref=\"LineInput.NumberOfSeasonalTemporaryEmployees\"]");

    public ILocator Officers => _page.Locator("input[fieldref=\"EndorsementOfficers.Officers\"]");

    public ILocator OfficersPositionHeld => _page.Locator("input[fieldref=\"EndorsementOfficers.PositionHeld\"]");

    public ILocator OptionACheckBox => _page.Locator("[fieldref=\"BusinessInterruptionEndorsementInput.OptionA\"], [data-fieldref=\"BusinessInterruptionEndorsementInput.OptionA\"]");

    public ILocator OptionAScheduleButton => _page.Locator("a[fieldref=\"Option A Schedule\"]");

    public ILocator OrderAudit => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Order Audit");

    public ILocator RiskVehicleInputValueEstimate => _page.Locator("input[fieldref=\"RiskVehicleInput.ValueEstimate\"]");

    public ILocator Others => _page.Locator("input[fieldref=\"EndorsementOthers.Others\"]");

    public ILocator Partners => _page.Locator("input[fieldref=\"EndorsementPartners.Partners\"]");

    public ILocator PayPlan => _page.Locator("input[fieldref=\"BillingDetailInput.PayPlan\"]");

    public ILocator PendingRateChange => _page.Locator("[id=\"f_l43F2C8E3497A4C328FCF8D515AC746C31CB6_3_1-inputEl\"]");

    public ILocator PerVehicleLimit => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB401083_3_5-inputEl\"]");

    public ILocator PersAdvInj => _page.Locator("input[fieldref=\"CovPersonalAdvertisingInjuryInput.PersonalAdvertisingInjury\"]");

    public ILocator PersonalPortableComputers => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8B_3_4-inputEl\"]");

    public ILocator PersonalPropertyLimit => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Personal Property Limit");


    public ILocator PierOrWharf => _page.Locator("input[fieldref=\"BuildingInput.PierOrWharf\"]");

    public ILocator PierOrWharfCOLOptions => _page.Locator("input[fieldref=\"BuildingInput.PierOrWharfCOLOptions\"]");

    public ILocator PierOrWharfCauseOfLoss => _page.Locator("input[fieldref=\"BuildingInput.PierOrWharfCauseOfLoss\"]");

    public ILocator PierOrWharfConstruction => _page.Locator("input[fieldref=\"BuildingInput.PierOrWharfConstruction\"]");

    public ILocator PleaseProvideWebsiteAddressEs => _page.Locator("input[fieldref=\"UnderwritingQuestionsUmbrellaInput.WebsiteAddress\"]");

    public ILocator PolicyCovgerage => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });




    public ILocator PolicyCovg => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Covg");

    public ILocator PolicyHolderName => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA705C_3_1-inputEl\"]");



    public ILocator BusinessownersPolicyNumber => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Number");



    public ILocator PolicyType => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Type");

    public ILocator PowerSuppressorVoltageRegulator => _page.Locator("[id=\"f_c7FA512A090F641B9A6BB95F4C656EE1840_2_21-inputEl\"]");

    public ILocator PremOpDed => _page.Locator("input[fieldref=\"LineInput.Deductible\"]");

    public ILocator PremOpPDDed => _page.Locator("input[fieldref=\"LineInput.DeductiblePD\"]");

    public ILocator PremisesType => _page.Locator("[id=\"f_c4FFD73A13C164B729C39A3F5C851102317_1_1-inputEl\"]");

    public ILocator Premium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Premium");


    public ILocator PricingDetail => _page.Locator("a[fieldref=\"Pricing Detail\"]");


    public ILocator PricingHeading => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Pricing Heading");

    public ILocator PrimaryLiabilityIfAny => _page.Locator("[fieldref=\"CovHiredAndBorrowedLiabilityInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedLiabilityInput.IfAny\"]");

    public ILocator PrimaryLocationState => _page.Locator("input[fieldref=\"LineInput.PrimaryLocationState\"]");

    public ILocator PrimaryRatingState => _page.Locator("input[fieldref=\"PolicyInput.PrimaryRatingState\"]");

    public ILocator PriorAmericanNationalPolicy => _page.Locator("input[fieldref=\"PolicyInput.PriorPolicyNumberAN\"]");

    public ILocator ProdBIDed => _page.Locator("input[fieldref=\"LineInput.DeductibleProducts\"]");

    public ILocator ProdPDDed => _page.Locator("input[fieldref=\"LineInput.DeductiblePDProducts\"]");

    public ILocator ProduceCarried => _page.Locator("input[fieldref=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.ProduceCarried\"]");

    public ILocator ProductsAggLimit => _page.Locator("input[fieldref=\"LineInput.ProductsAggregateLimit\"]");

    public ILocator ProductsCompletedOperationsAggregateLimit => _page.Locator("input[fieldref=\"LineInput.ProductsCompletedOperationsAggregateLimit\"]");



    public ILocator PropertyAwayFromYourPremisesSchedule => _page.Locator("a[fieldref=\"Property Away From Your Premises Schedule\"]");

    public ILocator PolicyCovgComputerSystemsPropertyInTransit => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F86_3_4-inputEl\"]");

    public ILocator PolicyCovgBaileesCutomersPropertyInTransit => _page.Locator("[id=\"f_cC7E46B39F45D4F2C904634B55848AF77F70_3_7-inputEl\"]");

    public ILocator PropertyOfOthersLimit => _page.Locator("input[fieldref=\"RiskPropertyInput.Limit\"]");



    public ILocator ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest => _page.Locator("[fieldref=\"BuildingInput.SurroundingExposureOrOtherOccupancies\"], [data-fieldref=\"BuildingInput.SurroundingExposureOrOtherOccupancies\"]");

    public ILocator ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia => _page.Locator("[name=\"string_2F_4\"]");



    public ILocator RentalReimbursement => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FED_3_1-inputEl\"]");

    public ILocator RentedEquipmentExpense => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FE5_3_1-inputEl\"]");

    public ILocator RequestedUmbrellaLimit => _page.Locator("input[fieldref=\"LineInput.RequestedUmbrellaLimit\"]");

    public ILocator Result => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Result");

    public ILocator ReturnToQuote => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Quote", Exact = true });





    public ILocator RiskSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "Risk Schedule", Exact = true });

    public ILocator RiskType => _page.Locator("input[fieldref=\"RatingGroupInput.RiskType\"]");

    public ILocator RoofType => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0259_3_1-inputEl\"]");


    public ILocator SaveForLater => _page.Locator("a[fieldref=\"Save for Later\"]");

    public ILocator ScheduledCoverage => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E02211F0_3_1-inputEl\"]");

    public ILocator RiskComputerSystemsSearchResult => _page.Locator("[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB111_1_1-inputEl\"]");

    public ILocator RiskBaileesCustomersSearchResult => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740889_1_1-inputEl\"]");

    public ILocator RiskAccountsReceivableSearchResult => _page.Locator("[id=\"f_rFE68631942E64B1BA3A954F11A424A13A_1_1-inputEl\"]");

    public ILocator SearchResults => _page.Locator("input[fieldref=\"OccupancySearchInputNonShredded.SearchResults\"]");

    public ILocator SearchValue => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "SearchValue");

    public ILocator PropertyAddClassSearchValue => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Search Value");

    public ILocator RiskAccountsReceivableSearchValue => _page.Locator("[id=\"f_rFE68631942E64B1BA3A954F11A424A139_1_1-inputEl\"]");

    public ILocator RiskComputerSystemsSearchValue => _page.Locator("[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB110_1_1-inputEl\"]");

    public ILocator RiskBaileesCustomersSearchValue => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740887_1_1-inputEl\"]");

    public ILocator SeasonalProduceTrailers => _page.Locator("input[fieldref=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.SeasonalAgriculturalProduceTrailers\"]");


    public ILocator SelectAppropriateCode => _page.Locator("[id=\"f_aCDFD57747BFF44D9A3DDB9378170002825_2_1-inputEl\"]");

    public ILocator SelectClassCode => _page.Locator("input[fieldref=\"NCCISearchInputNonShredded.SearchResults\"]");

    public ILocator SelectEndorsement => _page.Locator("input[fieldref=\"LineOutputNonShredded.EndorsementType\"]");

    public ILocator SelectNAICSCode => _page.Locator("a[fieldref=\"Select NAICS Code\"]");

    public ILocator SelectPPC => _page.Locator("a[fieldref=\"Select PPC\"]");

    public ILocator Sex => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D1_1_1-inputEl\"]");

    public ILocator ShowAllLocations => _page.Locator("input[fieldref=\"LocationSelectInput.ShowAllLocations\"]");

    public ILocator SignLocation => _page.Locator("[id=\"f_r99A2986D696A457DA1C69BB16D902CEF17_1_1-inputEl\"]");

    public ILocator SignsUWQuestions => _page.Locator("div[fieldref=\"Signs\"]");

    public ILocator SmallDeductible => _page.Locator("input[fieldref=\"LineStateTermInput.SmallDeductibleCreditDeductible\"]");

    public ILocator SoleProprietors => _page.Locator("input[fieldref=\"EndorsementSoleProprietors.SoleProprietors\"]");

    public ILocator SpecificUnderwritingQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Specific Underwriting Questions", Exact = true });

    public ILocator SplitBIDed => _page.Locator("input[fieldref=\"LineInput.SeparateProductsDeductible\"]");

    public ILocator SplitPDDed => _page.Locator("input[fieldref=\"LineInput.SeparateProductsPDDeductible\"]");

    public ILocator SquareFeet => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0245_3_1-inputEl\"]");

    public ILocator PolicyHolderState => _page.Locator("[fieldref=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderState\"], [data-fieldref=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderState\"]");

    public ILocator State => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "State");

    public ILocator EndorsementsDesignatedWorkplacesExclusionState => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "State*");


    public ILocator StateLicensed => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D5_1_1-inputEl\"]");

    public ILocator StateOrPoliticalSubdivision => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.Name\"]");


    public ILocator StoplightMessageTotalSubjectPremium => _page.GetByText("Stoplight Message: Total Subject Premium", new() { Exact = true });

    public ILocator StorageLimit => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF587517408A3_1_1-inputEl\"]");

    public ILocator Stories => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0247_3_1-inputEl\"]");



    public ILocator TapesCoverage => _page.Locator("[id=\"f_cA3C9AC7006E9416C9517BA15BC2DCE5F2364_2_1-inputEl\"]");

    public ILocator TextBox => _page.Locator("textarea[fieldref=\"NotesInput.Remarks\"]");

    public ILocator ThirdPartyDesignee => _page.Locator("a[fieldref=\"Third Party Designee\"]");

    public ILocator Title => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Title");

    public ILocator ToolsAndClothingBelongingToYourEmployees => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FEB_3_1-inputEl\"]");

    public ILocator TotalCostOfWork => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA7041_3_1-inputEl\"]");

    public ILocator TotalPayrollEstimated => _page.Locator("input[fieldref=\"CoverageInput.UnitsOfExposureEstimated\"]");

    public ILocator TotalPremium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Total Premium");

    public ILocator BusinessownersTotalSubjectPremium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Total Subject Premium*");


    public ILocator Towing => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Towing");

    public ILocator TrailerInterchangeCollisionDeductible => _page.Locator("input[fieldref=\"RiskDefaultsInput.TrailerInterchangeCollisionDeductible\"]");

    public ILocator TrailerInterchangeCompDeductible => _page.Locator("input[fieldref=\"RiskDefaultsInput.TrailerInterchangeComprehensiveDeductible\"]");

    public ILocator TrailerInterchangeEnterDaysInsured => _page.Locator("input[fieldref=\"TrailerInterchangeInput.NumberOfDaysInsuredEstimate\"]");

    public ILocator TrailerInterchangeEnterOfTrailers => _page.Locator("input[fieldref=\"TrailerInterchangeInput.NumberOfTrailersEstimate\"]");

    public ILocator FG0013AutomaticAdditionalInsuredSpecificRelationshipType => _page.Locator("[fieldref=\"AdditionalOtherInterestInput.Type\"], [data-fieldref=\"AdditionalOtherInterestInput.Type\"]");

    public ILocator EndorsementMainType => _page.Locator("[id=\"f_c4CBF9D54B72F454488F8BD49B282C532C8_3_10-inputEl\"]");

    public ILocator GLOCPRiskType => _page.Locator("[fieldref=\"CovOwnersContractorsOrPrincipalsInput.Type\"], [data-fieldref=\"CovOwnersContractorsOrPrincipalsInput.Type\"]");

    public ILocator CG2007AddLInsuredEngineersArchitectsType => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Type");

    public ILocator RiskSignsType => _page.Locator("[id=\"f_r99A2986D696A457DA1C69BB16D902CEF18_1_1-inputEl\"]");

    public ILocator TypeOfContractor => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FCB_3_1-inputEl\"]");

    public ILocator TypeOfEquipment => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.EquipmentType\"]");

    public ILocator TypeOfInterest => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.Type\"]");

    public ILocator TypeOfLicense => _page.Locator("[fieldref=\"AdditionalOtherInterestInput.DescriptionOfCompletedOps\"], [data-fieldref=\"AdditionalOtherInterestInput.DescriptionOfCompletedOps\"]");

    public ILocator UMBILimit => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "UMBI Limit*");

    public ILocator UMTypeDefaultSelections => _page.Locator("input[fieldref=\"LineStateUMDefaultsInput.UMType\"]");



    public ILocator UWQuestionsWorkersComp => _page.GetByRole(AriaRole.Link, new() { Name = "UW Questions - Workers Comp", Exact = true });

    public ILocator UmbrellaLimit => _page.Locator("input[fieldref=\"LineInput.UmbrellaLimit\"]");

    public ILocator UnderwritingInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

    public ILocator UninterruptiblePowerSource => _page.Locator("[id=\"f_c7FA512A090F641B9A6BB95F4C656EE183E_2_21-inputEl\"]");

    public ILocator UnnamedPremises => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8A_3_4-inputEl\"]");

    public ILocator UnnamedTerminalsLimit => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB401095_3_5-inputEl\"]");

    public ILocator UpdateAnswers => _page.Locator("a[fieldref=\"Update Answers\"]");




    public ILocator UsedAsShowroom => _page.Locator("input[fieldref=\"RiskCommercialAutoRiskInput.UsedAsShowroom\"]");

    public ILocator VIN => _page.Locator("input[fieldref=\"RiskVehicleInput.VIN\"]");

    public ILocator VacancyPermit => _page.Locator("input[fieldref=\"BuildingInput.VacancyPermit\"]");

    public ILocator VacantBuilding => _page.Locator("input[fieldref=\"BuildingInput.VacantBuilding\"]");

    public ILocator Valuation => _page.Locator("input[fieldref=\"RatingGroupInput.ValuationType\"]");

    public ILocator ValuationType => _page.Locator("input[fieldref=\"BuildingValuatioinInput.ValuationType\"]");

    public ILocator ValueBasis => _page.Locator("input[fieldref=\"RiskVehicleInput.StatedAmountIndicator\"]");

    public ILocator VehicleInformation => _page.Locator("input[fieldref=\"RiskHiredAndBorrowedWithDriverVehicleIteratorInput.VehicleInformation\"]");

    public ILocator VehicleSchedule1Veh => _page.GetByText("Veh #", new() { Exact = true });

    public ILocator VehicleType => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Vehicle Type");

    public ILocator VirusHarmfulCodeOrSimilarInstruction => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8D_3_4-inputEl\"]");

    public ILocator VolunteerHiredAutosCheckBox => _page.Locator("[fieldref=\"LineStateInput.VolunteerHiredAuto\"], [data-fieldref=\"LineStateInput.VolunteerHiredAuto\"]");

    public ILocator WCSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "WC Schedule", Exact = true });

    public ILocator WaitonPricingHeadingAndFillOutRequiredFields => _page.GetByText("Waiton Pricing Heading and Fill Out Required Fields", new() { Exact = true });

    public ILocator WaiverOfSubrogation => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Waiver Of Subrogation");

    public ILocator WaiverOfSubrogationExposure => _page.Locator("input[fieldref=\"CoverageInput.WaiverOfSubrogationExposure\"]");

    public ILocator WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days => _page.Locator("input[fieldref=\"PolicyInput.ExposuresInsuredAN90Days\"]");

    public ILocator WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured => _page.Locator("[name=\"string_2F_2\"]");

    public ILocator WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage => _page.Locator("[name=\"string_2F_3\"]");

    public ILocator WhatIsTheConstructionOfEachSign => _page.Locator("[fieldref=\"SignsUnderwritingQuestionsInput.Description\"], [data-fieldref=\"SignsUnderwritingQuestionsInput.Description\"]");

    public ILocator WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored => _page.Locator("[name=\"string_1F\"]");

    public ILocator WhatIsTheDistanceInFeetToTheNearestFireHydrant => _page.Locator("[id=\"f_cD3F347C9072D47E4BDC9B2BEE6F633CD38_2_15-inputEl\"]");

    public ILocator WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment => _page.Locator("[id=\"f_cD3F347C9072D47E4BDC9B2BEE6F633CD3B_2_15-inputEl\"]");

    public ILocator WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational => _page.Locator("input[fieldref=\"PolicyInput.ReasonForNewCoverage\"]");

    public ILocator WhatIsTheProcedureForTransportingTheComputerEquipment => _page.Locator("[name=\"string_2F\"]");

    public ILocator WhatIsThePublicProtectionClassRating => _page.Locator("[id=\"f_cD3F347C9072D47E4BDC9B2BEE6F633CD35_2_15-inputEl\"]");

    public ILocator WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft => _page.Locator("[name=\"string_1F_1\"]");

    public ILocator WhichFormAreYouCompleting => _page.Locator("[id=\"f_u90F32F80C0574D33AD962F038C8FC2AF56_2_1-inputEl\"]");

    public ILocator WhyIsThisCoverageDesired => _page.Locator("textarea[fieldref=\"CovEndorsementsInput.Description\"]");

    public ILocator Year => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Year*");

    public ILocator YearBuilt => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0243_3_1-inputEl\"]");

    public ILocator YearLicensed => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D4_1_1-inputEl\"]");

    public ILocator YearsInBusiness => _page.Locator("input[fieldref=\"AccountInput.YearsInBusiness\"]");

    public ILocator LocationZipCode => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Zip Code");

    public ILocator ThirdPartyDesigneeZipCode => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Zip Code*");

    public ILocator GLOCPRiskZipCode => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA7062_3_1-inputEl\"]");

    public ILocator EntityInfoFrameEntityInfoWindowFax => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.Fax\"]");

    public ILocator EntityInfoFrameEntityInfoWindowBureauNumber => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.BureauNumber\"]");

    public ILocator EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault => _page.Locator("input[fieldref=\"AdditionalOtherInterestInput.StateUnemploymentNumber\"]");
}
