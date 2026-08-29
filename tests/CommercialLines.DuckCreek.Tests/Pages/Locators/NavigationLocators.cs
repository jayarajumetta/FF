using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class NavigationLocators
{
    private readonly IPage _page;
    public NavigationLocators(IPage page) => _page = page;

    public ILocator AVCostNew => _page.GetByRole(AriaRole.Textbox, new() { Name = "AV Cost New*", Exact = true });

    public ILocator AWhatIsThePublicProtectionClassRating => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B170_2_8-inputEl\"]");

    public ILocator AcceptUM => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Accept UM");

    public ILocator AccountsReceivableHeading => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-d12e-b14d-c5c2d366b2bb");

    public ILocator AccountsReceivableUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Accounts Receivable", Exact = true });

    public ILocator Add => _page.GetByRole(AriaRole.Link, new() { Name = "Add", Exact = true });

    public ILocator AddAddlInterest => _page.GetByRole(AriaRole.Link, new() { Name = "Add Addl Interest", Exact = true });

    public ILocator AddBuilding => _page.GetByRole(AriaRole.Link, new() { Name = "Add Building", Exact = true });

    public ILocator AddClass => _page.GetByRole(AriaRole.Link, new() { Name = "Add Class", Exact = true });

    public ILocator AddClassCode => _page.GetByRole(AriaRole.Link, new() { Name = "Add Class Code", Exact = true });

    public ILocator OK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator AddCoverageForm => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-e6d1-13bd-997e7f292085");

    public ILocator AddDriver => _page.GetByRole(AriaRole.Link, new() { Name = "Add Driver", Exact = true });

    public ILocator AddDriverName => _page.Locator("[id=\"f_eC9B5D952311D4E46BAAE946A2A0730E51034_1_1-inputEl\"]");

    public ILocator EndorsementMainAddEndorsement => _page.GetByRole(AriaRole.Link, new() { Name = "Add Endorsement", Exact = true });

    public ILocator EndorsementsAddEndorsement => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-5aa5-ccad-be01b1072c20");

    public ILocator AddExcludedOfficerInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Excluded Officer Information", Exact = true });

    public ILocator AddExcludedOthersInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Excluded Others' Information", Exact = true });

    public ILocator AddGroup => _page.GetByRole(AriaRole.Link, new() { Name = "Add Group", Exact = true });

    public ILocator AddNotesRemarks => _page.GetByRole(AriaRole.Button, new() { Name = "Add Notes/Remarks", Exact = true });

    public ILocator AddOptionA => _page.GetByRole(AriaRole.Link, new() { Name = "Add Option A", Exact = true });

    public ILocator AddOtherInterest => _page.GetByRole(AriaRole.Link, new() { Name = "Add Other Interest", Exact = true });

    public ILocator AddOthersInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Others' Information", Exact = true });

    public ILocator AddPartnerInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Partner Information", Exact = true });

    public ILocator AddPremises => _page.GetByRole(AriaRole.Link, new() { Name = "Add Premises", Exact = true });

    public ILocator AddPriorCarrier => _page.GetByRole(AriaRole.Button, new() { Name = "Add Prior Carrier", Exact = true });

    public ILocator AddRiskAtThisLocation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Risk at This Location", Exact = true });

    public ILocator AddSoleProprietorInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Sole Proprietor Information", Exact = true });

    public ILocator AddThirdParty => _page.GetByRole(AriaRole.Link, new() { Name = "Add Third Party", Exact = true });

    public ILocator AdditionalInterests => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1688-c094-cab0-01ca8db25c92");

    public ILocator AdditionalOtherInterestAddress => _page.Locator("[name=\"AdditionalOtherInterestInput.Address1\"], [id=\"AdditionalOtherInterestInput.Address1\"]").First;

    public ILocator AdditionalOtherInterestInputFirstName => _page.Locator("[name=\"AdditionalOtherInterestInput.FirstName\"], [id=\"AdditionalOtherInterestInput.FirstName\"]").First;

    public ILocator AdditionalOtherInterestInputLastName => _page.Locator("[name=\"AdditionalOtherInterestInput.LastName\"], [id=\"AdditionalOtherInterestInput.LastName\"]").First;

    public ILocator AdditionalInterestsScheduleAddlInterests => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-3c8c-26cf-6ef3cb7d13c7");

    public ILocator SignsHeading => _page.Locator("[id=\"pageTitle\"]");

    public ILocator GLNavigationLinksAddlInterests => _page.GetByRole(AriaRole.Link, new() { Name = "Addl Interests", Exact = true });

    public ILocator Address => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-b5bb-ae1c-348164b75bbb");

    public ILocator CG2935AddLInsuredStateOrPoliticalPermitsAddress => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address 1", Exact = true });

    public ILocator GLOCPRiskAddress => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA705E_3_1-inputEl\"]");

    public ILocator LocationAddress => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address1", Exact = true });

    public ILocator AddressStreetCityStateZip => _page.Locator("[id=\"f_b7BA9D20D6B9840E99A47B1B0DFA716BF7_1_1-inputEl\"]");

    public ILocator AggregateLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-7505-61ee-35ff4430c9d2");

    public ILocator AnnualGrossReceipts => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF5875174088F_1_1-inputEl\"]");

    public ILocator AnyPersonalAutoPolicyListingNameInsured => _page.Locator("[id=\"f_uFE2672745CB24DB2A83158A3D6E7E97F13E_3_1-inputEl\"]");

    public ILocator AnyVehicleCoveredRegisteredInNotPrimaryState => _page.Locator("[id=\"f_uFE2672745CB24DB2A83158A3D6E7E97F187_3_1-inputEl\"]");

    public ILocator AreAnySignsOffPremisesOrNotAttachedToBuilding => _page.Locator("[id=\"f_sEDD5CE21D8434468900294193CF0200E1D_2_1-inputEl\"]");

    public ILocator ArePhysicalsRequiredAfterOffersOfEmploymentAreMade => _page.GetByRole(AriaRole.Textbox, new() { Name = "Are physicals required after offers of employment are made?*", Exact = true });

    public ILocator AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy => _page.GetByRole(AriaRole.Textbox, new() { Name = "Are there any commercial vehicles owned by the applicant not insured on the policy?", Exact = true });

    public ILocator AreThereAnyOfficersThatShouldBeExcluded => _page.Locator("[id=\"f_lA2C9A848A1FC45D39BB20EBBC28014492E1_3_1-inputEl\"]");

    public ILocator AssignLocation => _page.GetByRole(AriaRole.Link, new() { Name = "Assign Location", Exact = true });

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

    public ILocator BaileesCustomerUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Bailees Customer", Exact = true });

    public ILocator BaileesCustomersHeading => _page.GetByText("Bailees Customers Heading", new() { Exact = true });

    public ILocator BillType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Bill Type", Exact = true });

    public ILocator NavigationBilling => _page.GetByRole(AriaRole.Link, new() { Name = "Billing", Exact = true });

    public ILocator Billing => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Billing");

    public ILocator BodyStyle => _page.GetByRole(AriaRole.Textbox, new() { Name = "Body Style", Exact = true });

    public ILocator BoomDeductible => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FC8_3_1-inputEl\"]");

    public ILocator BorrowingHiringOrLeasingWithinYear => _page.Locator("[id=\"f_uFE2672745CB24DB2A83158A3D6E7E97F142_3_1-inputEl\"]");

    public ILocator Building => _page.GetByRole(AriaRole.Link, new() { Name = "Building", Exact = true });

    public ILocator BuildingLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Building Limit", Exact = true });

    public ILocator BuildingRatingGroup => _page.GetByRole(AriaRole.Textbox, new() { Name = "Building Rating Group", Exact = true });

    public ILocator BusinessInterruptionDescriptionOfScheduledProperty => _page.GetByRole(AriaRole.Textbox, new() { Name = "Business Interruption Description Of ScheduledProperty", Exact = true });

    public ILocator OptionA => _page.Locator("[id=\"pageTop\"]");

    public ILocator BusinessInterruptionEndorsement => _page.GetByRole(AriaRole.Textbox, new() { Name = "Business Interruption Endorsement", Exact = true });

    public ILocator BusinessInterruptionLimitOfInsurance => _page.GetByRole(AriaRole.Textbox, new() { Name = "Business Interruption Limit Of Insurance", Exact = true });

    public ILocator CA2325LeasedWorkersCoverage => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "[CA2325] Leased Workers Coverage");

    public ILocator CA9940ContractProvisions => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9940 - Contract Provisions", Exact = true });

    public ILocator CA9940Make => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9940 - Make", Exact = true });

    public ILocator CA9940Model => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9940 - Model", Exact = true });

    public ILocator CA9940VIN => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA 9940 - VIN", Exact = true });

    public ILocator CA9940Year => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9940 - Year", Exact = true });

    public ILocator CA9948ClassesOfCommoditiesTransported => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9948 - Classes Of Commodities Transported", Exact = true });

    public ILocator ExcludeUndergroundPropertyDamageHazard => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-e550-22ce-3a4125c40dfb");

    public ILocator CGL => _page.GetByRole(AriaRole.Link, new() { Name = "CGL", Exact = true });

    public ILocator CGLLimits => _page.GetByRole(AriaRole.Textbox, new() { Name = "CGL Limits*", Exact = true });

    public ILocator CPPLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-b124-eb68-7d72e20b1cb2");

    public ILocator CWhatIsTheDistanceInFeetToTheNearestHydrant => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B175_2_8-inputEl\"]");

    public ILocator CallISO => _page.GetByRole(AriaRole.Link, new() { Name = "Call ISO", Exact = true });

    public ILocator Carrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Carrier", Exact = true });

    public ILocator CauseOfLoss => _page.GetByRole(AriaRole.Textbox, new() { Name = "Cause Of Loss", Exact = true });

    public ILocator City => _page.GetByRole(AriaRole.Textbox, new() { Name = "City*", Exact = true });

    public ILocator ClassCode => _page.Locator("[fieldref=\"CovOwnersContractorsOrPrincipalsInputNonShredded.ClassCode\"], [data-fieldref=\"CovOwnersContractorsOrPrincipalsInputNonShredded.ClassCode\"]");

    public ILocator ClassCodeFrame => _page.GetByText("Class Code Frame", new() { Exact = true });

    public ILocator ClassCodeFrameClassCodeWindow => _page.GetByText("Class Code Window", new() { Exact = true });

    public ILocator ClassificationOfRisk => _page.Locator("[id=\"f_c4FFD73A13C164B729C39A3F5C851102319_1_1-inputEl\"]");

    public ILocator ClickAddEndorsement => _page.GetByRole(AriaRole.Link, new() { Name = "Click Add Endorsement", Exact = true });

    public ILocator ClickAddExcludedDriver => _page.GetByRole(AriaRole.Link, new() { Name = "Click Add Excluded Driver", Exact = true });

    public ILocator AddClient => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-21d3-307d-9ac2d420ffb8");

    public ILocator PolicyCovgComputerSystemsCoinsurance => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F83_3_4-inputEl\"]");

    public ILocator RatingGroupsCoinsurance => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coinsurance", Exact = true });

    public ILocator PolicyCovgContractorsEquipmentCoinsurance => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FC2_3_1-inputEl\"]");

    public ILocator Collision => _page.Locator("[fieldref=\"CovDriveOtherCarCollisionInput.Indicator\"], [data-fieldref=\"CovDriveOtherCarCollisionInput.Indicator\"]");

    public ILocator CollisionCoverage => _page.Locator("[id=\"f_c7D7AC70D2F5B46AE89DB2111B306EB762349_2_1-inputEl\"]");

    public ILocator CollisionDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Collision Deductible", Exact = true });

    public ILocator HiredAutoCollisionDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Collision Deductible*", Exact = true });

    public ILocator StateDetailsHiredAutoPDWithoutDriverIfAny => _page.Locator("[fieldref=\"CovHiredAndBorrowedCollisionInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedCollisionInput.IfAny\"]");

    public ILocator StateDetailsHiredAutoPhysicalDamageWithDriverIfAny => _page.Locator("[fieldref=\"CovHiredAndBorrowedCollisionWithDriverInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedCollisionWithDriverInput.IfAny\"]");

    public ILocator CommercialAuto => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-50ef-718a-9eff146a551c");

    public ILocator CommonNavigationLinksNext => _page.GetByRole(AriaRole.Link, new() { Name = "Next", Exact = true });

    public ILocator CompanyName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Company Name*", Exact = true });

    public ILocator Comprehensive => _page.Locator("[fieldref=\"CovDriveOtherCarOTCInput.Indicator\"], [data-fieldref=\"CovDriveOtherCarOTCInput.Indicator\"]");

    public ILocator ComputerEquipment => _page.Locator("[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB1C_1_1-inputEl\"]");

    public ILocator ComputerSystemsUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Computer Systems", Exact = true });

    public ILocator BuildingDetailConstruction => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D023F_3_1-inputEl\"]");

    public ILocator RiskBaileesCustomersConstruction => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF5875174088B_1_1-inputEl\"]");

    public ILocator ConstructionCode => _page.Locator("[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB114_1_1-inputEl\"]");

    public ILocator RiskAccountsReceivableConstruction => _page.Locator("[id=\"f_rFE68631942E64B1BA3A954F11A424A13D_1_1-inputEl\"]");

    public ILocator ContractorsEquipmentUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Contractors Equipment", Exact = true });

    public ILocator CoverageBeginDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coverage begin date:", Exact = true });

    public ILocator CoverageEndDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coverage end date:", Exact = true });

    public ILocator PolicyCovgGLCoverageForm => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coverage Form", Exact = true });

    public ILocator PolicyCovgSignsCoverageForm => _page.Locator("[id=\"f_cAFD1AA97819C467694F348BB5BA65F85E45_3_6-inputEl\"]");

    public ILocator RiskMainCoverageForm => _page.Locator("[id=\"f_l1A9C547373A24FF38DA9C54C82FB349824_3_1-inputEl\"]");

    public ILocator PolicyCovgComputerSystemsCoverageFormDisplay => _page.Locator("[id=\"f_iB27E9D1A7BBB4CC688DAC59E11C5C2DED60_3_4-inputEl\"]");

    public ILocator PolicyCovgBaileesCutomersCoverageFormDisplay => _page.Locator("[id=\"f_iA14B1E3D0C8544FA84D50C076D97DD44D60_3_7-inputEl\"]");

    public ILocator PolicyCovgMotorTruckCargoCoverageFormDisplay => _page.Locator("[id=\"f_i6880B67F580944108A4FCC241C2B2649D60_3_5-inputEl\"]");

    public ILocator PolicyCovgSignsCoverageFormDisplay => _page.Locator("[id=\"f_iCCB999F03E934DE9BF81315D41AE8572D60_3_6-inputEl\"]");

    public ILocator PolicyCovgContractorsEquipmentCoverageFormDisplay => _page.Locator("[id=\"f_i2B400B3B804E4D9EA12FE1D96F9ADFC6D60_3_1-inputEl\"]");

    public ILocator CoverageFormToBeAdded => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-eb63-48b6-c4fba029f2b7");

    public ILocator CoverageType => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB401072_3_5-inputEl\"]");

    public ILocator CoveredPropertyConsistingPrincipallyOf => _page.Locator("[fieldref=\"MotorTruckCargoInput.Description\"], [data-fieldref=\"MotorTruckCargoInput.Description\"]");

    public ILocator CreateValuation => _page.GetByRole(AriaRole.Link, new() { Name = "Create Valuation", Exact = true });

    public ILocator DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B178_2_8-inputEl\"]");

    public ILocator DataAndMedia => _page.Locator("[id=\"f_c3EF1D09EE0E84AB189A6366AD3F277B2D_1_1-inputEl\"]");

    public ILocator DateOfBirth => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-5235-6ac4-b01a5f07f090");

    public ILocator DateOfHire => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D6_1_1-inputEl\"]");

    public ILocator DebrisRemovalAdditional => _page.GetByRole(AriaRole.Textbox, new() { Name = "Debris Removal Additional", Exact = true });

    public ILocator DebrisRemovalAdditionalLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Debris Removal Additional Limit", Exact = true });

    public ILocator DedType => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-a97e-db29-b634782f5f0c");

    public ILocator DedicatedLine => _page.Locator("[id=\"f_c7FA512A090F641B9A6BB95F4C656EE1841_2_21-inputEl\"]");

    public ILocator RatingGroupsDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible", Exact = true });

    public ILocator EndorsementIF0002WaterborneEquipmentDeductible => _page.Locator("[id=\"f_c4CA5AF1ED9DF445F976D32FE5E1139DD11D_3_14-inputEl\"]");

    public ILocator PolicyCovgMotorTruckCargoDeductible => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB40107F_3_5-inputEl\"]");

    public ILocator RiskBaileesCustomersDeductible => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF5875174087F_1_1-inputEl\"]");

    public ILocator BuildingDetailDeductible => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0260_3_1-inputEl\"]");

    public ILocator DeductibleBasis => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-b6ea-5343-993db0eb88bd");

    public ILocator PolicyCovgContractorsEquipmentDeductible => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FC3_3_1-inputEl\"]");

    public ILocator PolicyCovgComputerSystemsDeductible => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F7E_3_4-inputEl\"]");

    public ILocator BuildingDetailDeductibleIncreasedTheft => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0263_3_1-inputEl\"]");

    public ILocator RatingGroupsDeductibleIncreasedTheft => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible Increased Theft", Exact = true });

    public ILocator BuildingDetailDeductibleWindHail => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0265_3_1-inputEl\"]");

    public ILocator RatingGroupsDeductibleWindHail => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible Wind Hail", Exact = true });

    public ILocator DefaultExpModType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Default Exp Mod Type", Exact = true });

    public ILocator DefaultExperienceMod => _page.GetByRole(AriaRole.Textbox, new() { Name = "Default Experience Mod", Exact = true });

    public ILocator DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy => _page.Locator("[fieldref=\"GeneralLiabilityInput.Description\"], [data-fieldref=\"GeneralLiabilityInput.Description\"]");

    public ILocator PolicyCovgContractorsEquipmentDescription => _page.Locator("[id=\"f_i2B400B3B804E4D9EA12FE1D96F9ADFC6D62_3_1-inputEl\"]");

    public ILocator PolicyCovgBaileesCutomersDescription => _page.Locator("[id=\"f_iA14B1E3D0C8544FA84D50C076D97DD44D62_3_7-inputEl\"]");

    public ILocator PolicyCovgComputerSystemsDescription => _page.Locator("[id=\"f_iB27E9D1A7BBB4CC688DAC59E11C5C2DED62_3_4-inputEl\"]");

    public ILocator RatingGroupsDescription => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description", Exact = true });

    public ILocator PolicyCovgSignsDescription => _page.Locator("[id=\"f_iCCB999F03E934DE9BF81315D41AE8572D62_3_6-inputEl\"]");

    public ILocator PolicyCovgMotorTruckCargoDescription => _page.Locator("[id=\"f_i6880B67F580944108A4FCC241C2B2649D62_3_5-inputEl\"]");

    public ILocator DescriptionOfBusinessActivites => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description Of Business Activites*", Exact = true });

    public ILocator DescriptionOfOperationS => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Operation(s)", Exact = true });

    public ILocator DescriptionOfOperations => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Operations", Exact = true });

    public ILocator DescriptionOfSpecifiedOperation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Specified Operation", Exact = true });

    public ILocator DesignatedWorkplacesExclusionOK => _page.GetByRole(AriaRole.Link, new() { Name = "Add Another Designated Workplace", Exact = true });

    public ILocator UnderwritingInfoOtherInsuranceHistoryDetail => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-371e-c808-c1dcd0cae17d");

    public ILocator LocationDetail => _page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true });

    public ILocator DoYouHaveACDLLicense => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D01119_1_1-inputEl\"]");

    public ILocator DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-f4d8-335f-cea3f953bf5e");

    public ILocator DoesTheApplicantWishToCoverAnySignsInsideTheirPremises => _page.Locator("[id=\"f_s5879EFE3310C457293652ECABD56DCF11D_2_2-inputEl\"]");

    public ILocator DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionG\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionG\"]");

    public ILocator DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionH\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionH\"]");

    public ILocator DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionF\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionF\"]");

    public ILocator DriveOtherCar => _page.Locator("[fieldref=\"LineStateInput.DriveOtherCarCoverage\"], [data-fieldref=\"LineStateInput.DriveOtherCarCoverage\"]");

    public ILocator DriverSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "Driver Schedule", Exact = true });

    public ILocator DriversLicenseNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Drivers License Number", Exact = true });

    public ILocator DryCleaning => _page.Locator("[id=\"f_b71504B515DF24669A165EFFA75C7935615D_2_1-inputEl\"]");

    public ILocator DuplicatedRecords => _page.Locator("[id=\"f_c4FFD73A13C164B729C39A3F5C851102318_1_1-inputEl\"]");

    public ILocator EAreNoSmokingRulesPostedAndEnforced => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B17B_2_8-inputEl\"]");

    public ILocator EMail => _page.GetByRole(AriaRole.Textbox, new() { Name = "E-Mail", Exact = true });

    public ILocator Earthquake => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF5875174089A_1_1-inputEl\"]");

    public ILocator EasyPay => _page.GetByRole(AriaRole.Textbox, new() { Name = "Easy Pay", Exact = true });

    public ILocator CommercialAutoEffectiveDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    public ILocator BusinessownersEffectiveDate => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-ac3b-2048-796e25a28c0b");

    public ILocator PolicyInfoRequiredAndOptionalFieldsEffectiveDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "EffectiveDate", Exact = true });

    public ILocator EligibleForEnhancedWindRatingProgram => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D02BE_3_1-inputEl\"]");

    public ILocator EmployeeHiredAutosCheckBox => _page.Locator("[fieldref=\"LineStateInput.EmployeeHiredAuto\"], [data-fieldref=\"LineStateInput.EmployeeHiredAuto\"]");

    public ILocator EmployersLiab => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-9599-a2ea-9374855150e2");

    public ILocator Endorsement => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsement", Exact = true });

    public ILocator EndorsementHeading => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-9372-feda-ed7f73106a12");

    public ILocator FirstEndorsementScheduleRow => _page.GetByText("$1", new() { Exact = true });

    public ILocator FirstEndorsementTableRow => _page.GetByText("#1", new() { Exact = true });

    public ILocator SecondEndorsementTableRow => _page.GetByText("$2", new() { Exact = true });

    public ILocator CG2401NonBindingArbitrationEndorsementType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    public ILocator BAPEndorsementsEndorsementType => _page.Locator("[id=\"f_lCFA4B66735E24DCDA7F8290E1448DDF960_3_1-inputEl\"]");

    public ILocator EndorsementsPartnersOfficersAndOthersExclusionEndorsementType => _page.Locator("[id=\"f_c19BE39E5AC0F487CBB1049569BE6DC56236_3_6-inputEl\"]");

    public ILocator GLNavigationLinksEndorsements => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-6ee5-b6f2-1ec6da80521a");

    public ILocator Endorsements => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-454b-5278-9f3e549fbf37");

    public ILocator WCNavigationLinksEndorsements => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsements", Exact = true });

    public ILocator EngineSizeCc => _page.GetByRole(AriaRole.Textbox, new() { Name = "Engine Size (cc)*", Exact = true });

    public ILocator EntityInfoFrame => _page.GetByText("Entity Info Frame", new() { Exact = true });

    public ILocator EntitySchedule => _page.GetByRole(AriaRole.Link, new() { Name = "Entity Schedule", Exact = true });

    public ILocator EstimatedHighestValue => _page.Locator("[id=\"f_c43D7743D9BD44829A7C9322C2ACC793C55_2_1-inputEl\"]");

    public ILocator EstimatorType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Estimator Type*", Exact = true });

    public ILocator ExcessLiabilityIfAny => _page.Locator("[fieldref=\"CovHiredAndBorrowedExcessLiabilityInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedExcessLiabilityInput.IfAny\"]");

    public ILocator ExcludeCollapseHazard => _page.Locator("[fieldref=\"CovEndorsementsInput.IndicatorCollapseCG2142\"], [data-fieldref=\"CovEndorsementsInput.IndicatorCollapseCG2142\"]");

    public ILocator ExcludeExplosionHazard => _page.Locator("[fieldref=\"CovEndorsementsInput.IndicatorExplosionCG2142\"], [data-fieldref=\"CovEndorsementsInput.IndicatorExplosionCG2142\"]");

    public ILocator ExcludedLiabilityConfidentialInformation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Excluded Liability - Confidential Information*", Exact = true });

    public ILocator ExperienceModType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Experience Mod Type*", Exact = true });

    public ILocator ExperienceRated => _page.GetByRole(AriaRole.Textbox, new() { Name = "Experience Rated", Exact = true });

    public ILocator ExperienceRatingOptions => _page.GetByRole(AriaRole.Textbox, new() { Name = "Experience Rating Options", Exact = true });

    public ILocator GeneralLiabilityExpirationDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    public ILocator BusinessownersExpirationDate => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-62eb-1046-d8904ca7eb14");

    public ILocator Exposure => _page.GetByRole(AriaRole.Textbox, new() { Name = "Exposure", Exact = true });

    public ILocator ExtendedEmployeeCoverage => _page.Locator("[fieldref=\"RiskNonOwnedAutoInput.ExtendedEmployeeCov\"], [data-fieldref=\"RiskNonOwnedAutoInput.ExtendedEmployeeCov\"]");

    public ILocator ExtraExpense => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8C_3_4-inputEl\"]");

    public ILocator FeetFromHydrant => _page.GetByRole(AriaRole.Textbox, new() { Name = "Feet From Hydrant", Exact = true });

    public ILocator FireDamage => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-2650-8f24-19c05dba284b");

    public ILocator StateDetailsDriveOtherCarFirstName => _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name", Exact = true });

    public ILocator FirstName => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-7104-229a-892e18f1a07f");

    public ILocator GCW => _page.GetByRole(AriaRole.Textbox, new() { Name = "GCW*", Exact = true });

    public ILocator GLDetail => _page.GetByRole(AriaRole.Link, new() { Name = "GL Detail", Exact = true });

    public ILocator GLUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "GL UW Questions", Exact = true });

    public ILocator GeneralLiab => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-0f88-b883-20bf5c0d330f");

    public ILocator GeneralLiabilityInformation => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-d017-0ba5-688c8af0bf55");

    public ILocator GeneralUWQuestions => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "General UW Questions");

    public ILocator GetCalculatedValue => _page.GetByRole(AriaRole.Link, new() { Name = "Get Calculated Value", Exact = true });

    public ILocator GroupClass => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB401088_3_5-inputEl\"]");

    public ILocator HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring => _page.GetByRole(AriaRole.Textbox, new() { Name = "Has any applicant been convicted of a felony or been involved in any incidents or claims relating to sexual abuse or molestation allegations, discrimination, arson, fraud, bribery or negligent hiring", Exact = true });

    public ILocator HaveYouHadAnyLiabilityLossesInTheLast5YearsOnAnyPrimaryOrExcessPolicy => _page.GetByRole(AriaRole.Textbox, new() { Name = "Have you had any liability losses in the last 5 years on any primary or excess policy?*", Exact = true });

    public ILocator HiredAutoCA2001Address => _page.GetByRole(AriaRole.Textbox, new() { Name = "HiredAuto CA2001 Address1", Exact = true });

    public ILocator HiredAutoCA2001FirstName => _page.GetByRole(AriaRole.Textbox, new() { Name = "HiredAuto CA2001 First Name", Exact = true });

    public ILocator HiredAutoCA2001LastName => _page.GetByRole(AriaRole.Textbox, new() { Name = "HiredAuto CA2001 Last Name", Exact = true });

    public ILocator HiredAutoCA2001ZipCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "HiredAuto CA2001 ZipCode", Exact = true });

    public ILocator HiredAutoExtAddlInsured => _page.GetByRole(AriaRole.Textbox, new() { Name = "Hired Auto Ext Addl Insured", Exact = true });

    public ILocator HiredAutoOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-7dec-7fe6-bf7cff13bc04");

    public ILocator HiredAutoLiability => _page.Locator("[fieldref=\"LineStateInput.HiredLiability\"], [data-fieldref=\"LineStateInput.HiredLiability\"]");

    public ILocator HiredAutoPhysicalDamageWithDriver => _page.Locator("[fieldref=\"LineStateInput.HiredPhysicalDamageWithDriver\"], [data-fieldref=\"LineStateInput.HiredPhysicalDamageWithDriver\"]");

    public ILocator HiredAutoPhysicalDamageWithoutDriver => _page.Locator("[fieldref=\"LineStateInput.HiredPhysicalDamage\"], [data-fieldref=\"LineStateInput.HiredPhysicalDamage\"]");

    public ILocator HiredEquipment => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FEE_3_1-inputEl\"]");

    public ILocator HowOftenIsDataBackedUp => _page.Locator("[name=\"string_2F_5\"]");

    public ILocator AdditionalInterestsScheduleIFRAME => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "IFRAME");

    public ILocator DriverDetailIFRAME => _page.Locator("[id=\"dctPopup_dctPopupWindow34CAB0C1A0A47F298A990A36C62FE6D0\"]");

    public ILocator IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationS => _page.GetByText("Address(es) or Description(s) of Designated Farm Location(s):", new() { Exact = true });

    public ILocator IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremises => _page.GetByText("Address(es) or Description(s) of Designated Premises:", new() { Exact = true });

    public ILocator IFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivities => _page.GetByText("Description Of Premises Or Activities", new() { Exact = true });

    public ILocator IFRAMEDuckCreekPolicyExcludedDriver => _page.GetByText("Excluded Driver", new() { Exact = true });

    public ILocator IFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalS => _page.GetByText("Name(s) or Description(s) of Designated Animal(s):", new() { Exact = true });

    public ILocator IFRAMEDuckCreekPolicyVehicleAssociation => _page.GetByText("Vehicle Association*", new() { Exact = true });

    public ILocator BAPEndorsementsIFRAME => _page.Locator("[id=\"dctPopup_dctPopupWindow1631A82AB27744695E74FDAA3357B203\"]");

    public ILocator IfYesDescribe => _page.Locator("[fieldref=\"ContractorsEquipmentUnderwritingQuestionsInput.Description\"], [data-fieldref=\"ContractorsEquipmentUnderwritingQuestionsInput.Description\"]");

    public ILocator IfYesExplain => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionFsub\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionFsub\"]");

    public ILocator ImportPolicyData => _page.GetByRole(AriaRole.Link, new() { Name = "Import Policy Data", Exact = true });

    public ILocator ImportPolicyDataButton => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-5b7e-1059-24533633c948");

    public ILocator IncreasedPollutantCleanup => _page.GetByRole(AriaRole.Textbox, new() { Name = "Increased Pollutant Cleanup", Exact = true });

    public ILocator IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated => _page.Locator("[name=\"string_2F_1\"]");

    public ILocator InsuranceHistory => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance History", Exact = true });

    public ILocator InsuredType => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-fa35-fde2-a6f6475ff53f");

    public ILocator Interest => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0249_3_1-inputEl\"]");

    public ILocator IntrastateRiskID => _page.GetByRole(AriaRole.Textbox, new() { Name = "Intrastate Risk ID", Exact = true });

    public ILocator IsTheBuildingCooled => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D02AD_3_1-inputEl\"]");

    public ILocator IsTheBuildingHeatedWithASolidFuelHeatingDevice => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0296_3_1-inputEl\"]");

    public ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-9844-6210-6e05ab67ffc8");

    public ILocator IsThereAPriorCarrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is there a Prior Carrier?*", Exact = true });

    public ILocator IsThisCoverageBound => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is this coverage bound?*", Exact = true });

    public ILocator IsThisPolicyBeingFullyCancelled => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is this policy being fully cancelled?*", Exact = true });

    public ILocator IsThisVehicleUsedInSnowPlowOperations => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is This Vehicle Used In Snow Plow Operations?*", Exact = true });

    public ILocator JavaScript => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "JavaScript");

    public ILocator LastName => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-fd52-8a69-a72f6ca273e5");

    public ILocator StateDetailsDriveOtherCarLastName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name", Exact = true });

    public ILocator Laundry => _page.Locator("[id=\"f_bD3790336B18440B2B60CC0B7F5F4E10315D_2_2-inputEl\"]");

    public ILocator Lettering => _page.Locator("[id=\"f_r99A2986D696A457DA1C69BB16D902CEF19_1_1-inputEl\"]");

    public ILocator CommercialAutoLiabilityLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-4b30-555c-4b79b411c0fd");

    public ILocator SFP10LiabilityFarmLiabilityLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Liability Limit*", Exact = true });

    public ILocator PolicyCovgBaileesPropertyAwayFromYourPremisesLimit => _page.Locator("[id=\"f_b7BA9D20D6B9840E99A47B1B0DFA716BF8_1_1-inputEl\"]");

    public ILocator EndorsementIF0002WaterborneEquipmentLimit => _page.Locator("[id=\"f_c4CA5AF1ED9DF445F976D32FE5E1139DD11C_3_14-inputEl\"]");

    public ILocator RiskBaileesCustomersLimit => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740895_1_1-inputEl\"]");

    public ILocator LimitOfInsurance => _page.Locator("[id=\"f_r99A2986D696A457DA1C69BB16D902CEF16_1_1-inputEl\"]");

    public ILocator LineConditioner => _page.Locator("[id=\"f_c7FA512A090F641B9A6BB95F4C656EE183F_2_21-inputEl\"]");

    public ILocator ListAllPoliciesWithAmericanNational => _page.Locator("[fieldref=\"UnderwritingQuestionsWorkersCompInput.ListAllPoliciesWithAmericanNational\"], [data-fieldref=\"UnderwritingQuestionsWorkersCompInput.ListAllPoliciesWithAmericanNational\"]");

    public ILocator LoadingMessage => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Loading Message");

    public ILocator LoanLeaseGap => _page.GetByRole(AriaRole.Textbox, new() { Name = "Loan/Lease Gap", Exact = true });

    public ILocator Location => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Location");

    public ILocator WCNavigationLinksLocation => _page.GetByRole(AriaRole.Link, new() { Name = "Location", Exact = true });

    public ILocator LocationAssignment => _page.GetByText("Location Assignment", new() { Exact = true });

    public ILocator LocationID => _page.GetByRole(AriaRole.Textbox, new() { Name = "LocationID", Exact = true });

    public ILocator LocationOfCoveredOperations => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA7059_3_1-inputEl\"]");

    public ILocator LossExperience => _page.GetByRole(AriaRole.Link, new() { Name = "Loss Experience", Exact = true });

    public ILocator LossExperienceHeading => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Loss Experience Heading");

    public ILocator Make => _page.GetByRole(AriaRole.Textbox, new() { Name = "Make*", Exact = true });

    public ILocator MaritalStatus => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D2_1_1-inputEl\"]");

    public ILocator Medical => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-1b2e-8774-90d2b00bf944");

    public ILocator MeritRating => _page.GetByText("Merit Rating", new() { Exact = true });

    public ILocator MilesFromFireDepartment => _page.GetByRole(AriaRole.Textbox, new() { Name = "Miles From Fire Department", Exact = true });

    public ILocator MiscItemsBlanketCoverage => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FEC_3_1-inputEl\"]");

    public ILocator Model => _page.GetByRole(AriaRole.Textbox, new() { Name = "Model*", Exact = true });

    public ILocator ModificationFactor => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-4099-cdcb-b51261d5962d");

    public ILocator MotorTruckCargoUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Motor Truck Cargo", Exact = true });

    public ILocator MotorcycleLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-f277-7905-08e882cb4baa");

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

    public ILocator N2ndClassCategory => _page.GetByRole(AriaRole.Textbox, new() { Name = "2nd Class Category", Exact = true });

    public ILocator N2ndClassCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "2nd Class Code*", Exact = true });

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

    public ILocator NAICSCodeSearchValue => _page.GetByRole(AriaRole.Textbox, new() { Name = "NAICSCodeSearchValue", Exact = true });

    public ILocator NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices => _page.GetByRole(AriaRole.Textbox, new() { Name = "Name(s) or Description(s) and Date(s) of Designated Activities or Services", Exact = true });

    public ILocator Names => _page.Locator("[id=\"f_CCE14981F38894A679A407BA735B5959BD2_3_1-inputEl\"]");

    public ILocator NoKnownLosses => _page.GetByRole(AriaRole.Checkbox, new() { Name = "No known losses", Exact = true });

    public ILocator NonOwnedAuto => _page.Locator("[fieldref=\"LineCoveragesInput.NonOwnedAuto\"], [data-fieldref=\"LineCoveragesInput.NonOwnedAuto\"]");

    public ILocator Notepad => _page.GetByRole(AriaRole.Link, new() { Name = "Notepad", Exact = true });

    public ILocator NotepadHeading => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Notepad Heading");

    public ILocator NumberOfEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "Number Of Employees", Exact = true });

    public ILocator NumberOfFullTimeEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "Number of Full-Time Employees*", Exact = true });

    public ILocator NumberOfPartTimeEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "Number of Part-Time Employees*", Exact = true });

    public ILocator NumberOfVehicles => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB40108C_3_5-inputEl\"]");

    public ILocator OCP => _page.GetByRole(AriaRole.Link, new() { Name = "OCP", Exact = true });

    public ILocator OKClassCode => _page.GetByRole(AriaRole.Link, new() { Name = "OK-Class Code", Exact = true });

    public ILocator OKDetails => _page.GetByRole(AriaRole.Link, new() { Name = "OK-Details", Exact = true });

    public ILocator OKFirst => _page.GetByRole(AriaRole.Link, new() { Name = "OK (First)", Exact = true });

    public ILocator OKSecond => _page.GetByRole(AriaRole.Link, new() { Name = "OK (Second)", Exact = true });

    public ILocator OTCCausesOfLoss => _page.Locator("[id=\"f_cBFB0A5467643454EAC6DC41BBBFF51C22337_2_1-inputEl\"]");

    public ILocator StateDetailsHiredAutoPDWithoutDriverOTCDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "OTC Deductible*", Exact = true });

    public ILocator StateDetailsDriveOtherCarOTCDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "OTC Deductible", Exact = true });

    public ILocator StateDetailsHiredAutoPDWithoutDriverIfAnyField => _page.Locator("[fieldref=\"CovHiredAndBorrowedOTCInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedOTCInput.IfAny\"]");

    public ILocator StateDetailsHiredAutoPhysicalDamageWithDriverIfAnyField => _page.Locator("[fieldref=\"CovHiredAndBorrowedOTCWithDriverInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedOTCWithDriverInput.IfAny\"]");

    public ILocator OccupancyType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Occupancy Type", Exact = true });

    public ILocator Occupied => _page.GetByRole(AriaRole.Textbox, new() { Name = "% Occupied", Exact = true });

    public ILocator OccurenceLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-6910-f085-905e20437cbe");

    public ILocator OfEmployees => _page.Locator("[fieldref=\"RiskNonOwnedAutoInput.NumberOfEmployeesEstimate\"], [data-fieldref=\"RiskNonOwnedAutoInput.NumberOfEmployeesEstimate\"]");

    public ILocator OfFullTimeEmployees => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-6b9e-7a82-759a0390c142");

    public ILocator OfPartTimeEmployees => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-d1b3-1a9a-5519e5296a7f");

    public ILocator OfPartners => _page.Locator("[fieldref=\"RiskNonOwnedAutoInput.NumberOfPartnersEstimate\"], [data-fieldref=\"RiskNonOwnedAutoInput.NumberOfPartnersEstimate\"]");

    public ILocator OfSeasonalTemporaryEmployees => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-4cec-e5f0-b402c1b9fc50");

    public ILocator Officers => _page.GetByRole(AriaRole.Textbox, new() { Name = "Officers*", Exact = true });

    public ILocator OfficersPositionHeld => _page.GetByRole(AriaRole.Textbox, new() { Name = "Officers Position Held*", Exact = true });

    public ILocator OptionACheckBox => _page.Locator("[fieldref=\"BusinessInterruptionEndorsementInput.OptionA\"], [data-fieldref=\"BusinessInterruptionEndorsementInput.OptionA\"]");

    public ILocator OptionAScheduleButton => _page.GetByRole(AriaRole.Link, new() { Name = "Option A Schedule Button", Exact = true });

    public ILocator OrderAudit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Order Audit", Exact = true });

    public ILocator OriginalCostNew => _page.GetByRole(AriaRole.Textbox, new() { Name = "Original Cost New*", Exact = true });

    public ILocator Others => _page.GetByRole(AriaRole.Textbox, new() { Name = "Others*", Exact = true });

    public ILocator Partners => _page.GetByRole(AriaRole.Textbox, new() { Name = "Partners*", Exact = true });

    public ILocator PayPlan => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pay Plan", Exact = true });

    public ILocator PendingRateChange => _page.Locator("[id=\"f_l43F2C8E3497A4C328FCF8D515AC746C31CB6_3_1-inputEl\"]");

    public ILocator PerVehicleLimit => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB401083_3_5-inputEl\"]");

    public ILocator PersAdvInj => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-88fd-c07c-9f9ab9138604");

    public ILocator PersonalPortableComputers => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8B_3_4-inputEl\"]");

    public ILocator PersonalPropertyLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Personal Property Limit", Exact = true });

    public ILocator PersonalPropertyRatingGroup => _page.GetByRole(AriaRole.Textbox, new() { Name = "Personal Property Rating Group", Exact = true });

    public ILocator PierOrWharf => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pier Or Wharf", Exact = true });

    public ILocator PierOrWharfCOLOptions => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pier Or Wharf COL Options", Exact = true });

    public ILocator PierOrWharfCauseOfLoss => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pier Or Wharf Cause Of Loss", Exact = true });

    public ILocator PierOrWharfConstruction => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pier Or Wharf Construction", Exact = true });

    public ILocator PleaseProvideWebsiteAddressEs => _page.GetByRole(AriaRole.Textbox, new() { Name = "Please provide website address(es).*", Exact = true });

    public ILocator PolicyCovgerage => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });

    public ILocator PolicyCovgGLPolicyCovg => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-769e-b228-7a3436bb62eb");

    public ILocator IMNavigationLinksPolicyCovg => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-a4c5-1221-65f506afd5b8");

    public ILocator PolicyCovgMainPolicyCovg => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-9338-df10-a309c3e3c058");

    public ILocator PolicyCovg => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Covg");

    public ILocator PolicyHolderName => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA705C_3_1-inputEl\"]");

    public ILocator PolicyInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Info", Exact = true });

    public ILocator PolicyInfoHeader => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Info Header");

    public ILocator CommercialAutoPolicyNumber => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-17ac-180b-20fce969d8b7");

    public ILocator BusinessownersPolicyNumber => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-2795-c091-4c635a79407e");

    public ILocator GeneralLiabilityPolicyNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    public ILocator PolicyType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Type", Exact = true });

    public ILocator PowerSuppressorVoltageRegulator => _page.Locator("[id=\"f_c7FA512A090F641B9A6BB95F4C656EE1840_2_21-inputEl\"]");

    public ILocator PremOpDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-277f-f8c3-5a7e01456e49");

    public ILocator PremOpPDDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-3255-282f-15a94c7a106d");

    public ILocator PremisesType => _page.Locator("[id=\"f_c4FFD73A13C164B729C39A3F5C851102317_1_1-inputEl\"]");

    public ILocator Premium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Premium");

    public ILocator Pricing => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing", Exact = true });

    public ILocator PricingDetail => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing Detail", Exact = true });

    public ILocator PricingDetailOK => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing Detail - OK", Exact = true });

    public ILocator PricingHeading => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Pricing Heading");

    public ILocator PrimaryLiabilityIfAny => _page.Locator("[fieldref=\"CovHiredAndBorrowedLiabilityInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedLiabilityInput.IfAny\"]");

    public ILocator PrimaryLocationState => _page.GetByRole(AriaRole.Textbox, new() { Name = "Primary Location State*", Exact = true });

    public ILocator PrimaryRatingState => _page.GetByRole(AriaRole.Textbox, new() { Name = "PrimaryRatingState", Exact = true });

    public ILocator PriorAmericanNationalPolicy => _page.GetByRole(AriaRole.Textbox, new() { Name = "Prior American National Policy #*", Exact = true });

    public ILocator ProdBIDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-930b-1ff7-13efbf42ac65");

    public ILocator ProdPDDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-0ca0-26e9-1f003690dc99");

    public ILocator ProduceCarried => _page.GetByRole(AriaRole.Textbox, new() { Name = "Produce Carried", Exact = true });

    public ILocator ProductsAggLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-7641-373b-5b21ae14d400");

    public ILocator ProductsCompletedOperationsAggregateLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Products - Completed Operations Aggregate Limit", Exact = true });

    public ILocator ProductsCompletedOpsButton => _page.GetByRole(AriaRole.Link, new() { Name = "Products/Completed Ops", Exact = true });

    public ILocator Property => _page.GetByRole(AriaRole.Link, new() { Name = "Property", Exact = true });

    public ILocator PropertyAwayFromYourPremisesSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "Property Away From Your Premises Schedule", Exact = true });

    public ILocator PolicyCovgComputerSystemsPropertyInTransit => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F86_3_4-inputEl\"]");

    public ILocator PolicyCovgBaileesCutomersPropertyInTransit => _page.Locator("[id=\"f_cC7E46B39F45D4F2C904634B55848AF77F70_3_7-inputEl\"]");

    public ILocator PropertyOfOthersLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Property of Others Limit", Exact = true });

    public ILocator PropertyOfOthersRatingGroup => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-702f-ab45-977a2cd5409c");

    public ILocator PropertyUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Property UW Questions", Exact = true });

    public ILocator ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest => _page.Locator("[fieldref=\"BuildingInput.SurroundingExposureOrOtherOccupancies\"], [data-fieldref=\"BuildingInput.SurroundingExposureOrOtherOccupancies\"]");

    public ILocator ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia => _page.Locator("[name=\"string_2F_4\"]");

    public ILocator RatingGroups => _page.GetByRole(AriaRole.Link, new() { Name = "Rating Groups", Exact = true });

    public ILocator RentalOwnersLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-f99b-bc35-ce694290718a");

    public ILocator RentalReimbursement => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FED_3_1-inputEl\"]");

    public ILocator RentedEquipmentExpense => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FE5_3_1-inputEl\"]");

    public ILocator RequestedUmbrellaLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Requested Umbrella Limit", Exact = true });

    public ILocator Result => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Result");

    public ILocator ReturnToQuote => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Quote", Exact = true });

    public ILocator Risk => _page.GetByRole(AriaRole.Link, new() { Name = "Risk", Exact = true });

    public ILocator RiskAccountsReceivableOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-87fd-649f-1d8b0fc57589");

    public ILocator RiskBaileesCustomersOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-73c0-91ea-b7991fa97b13");

    public ILocator RiskComputerSystemsOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-ecfb-0d38-ef21709415e3");

    public ILocator RiskSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "Risk Schedule", Exact = true });

    public ILocator RiskType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Risk Type", Exact = true });

    public ILocator RoofType => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0259_3_1-inputEl\"]");

    public ILocator SFP10LiabilityFarm => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-6bf0-f011-0c6b89932520");

    public ILocator SaveForLater => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-cfec-8c22-a2e5f7a16ea9");

    public ILocator ScheduledCoverage => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E02211F0_3_1-inputEl\"]");

    public ILocator RiskComputerSystemsSearchResult => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-64b2-5e0b-f700919e536b");

    public ILocator RiskBaileesCustomersSearchResult => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-993e-d4b4-b6589f8b3c4f");

    public ILocator RiskAccountsReceivableSearchResult => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-357f-0e66-b5c4938eeda1");

    public ILocator SearchResults => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Results", Exact = true });

    public ILocator SearchValue => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1688-9e6e-3bd3-33b0fdcf5ebc");

    public ILocator PropertyAddClassSearchValue => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Value", Exact = true });

    public ILocator RiskAccountsReceivableSearchValue => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-5b3b-bf4a-564b4d225f8b");

    public ILocator RiskComputerSystemsSearchValue => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-ee80-e28d-fc69f13515c2");

    public ILocator RiskBaileesCustomersSearchValue => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-481d-8ffc-b47cce97273a");

    public ILocator SeasonalProduceTrailers => _page.GetByRole(AriaRole.Textbox, new() { Name = "Seasonal Produce Trailers", Exact = true });

    public ILocator Select => _page.Locator("[id=\"dctGridLink\"]");

    public ILocator SelectAppropriateCode => _page.Locator("[id=\"f_aCDFD57747BFF44D9A3DDB9378170002825_2_1-inputEl\"]");

    public ILocator SelectClassCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Select Class Code*", Exact = true });

    public ILocator SelectEndorsement => _page.GetByRole(AriaRole.Textbox, new() { Name = "Select Endorsement:", Exact = true });

    public ILocator SelectNAICSCode => _page.GetByRole(AriaRole.Link, new() { Name = "Select NAICS Code", Exact = true });

    public ILocator SelectPPC => _page.GetByRole(AriaRole.Link, new() { Name = "Select PPC", Exact = true });

    public ILocator Sex => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D1_1_1-inputEl\"]");

    public ILocator ShowAllLocations => _page.GetByRole(AriaRole.Textbox, new() { Name = "Show All Locations", Exact = true });

    public ILocator SignLocation => _page.Locator("[id=\"f_r99A2986D696A457DA1C69BB16D902CEF17_1_1-inputEl\"]");

    public ILocator SignsUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Signs", Exact = true });

    public ILocator SmallDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Small Deductible*", Exact = true });

    public ILocator SoleProprietors => _page.GetByRole(AriaRole.Textbox, new() { Name = "Sole Proprietors*", Exact = true });

    public ILocator SpecificUnderwritingQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Specific Underwriting Questions", Exact = true });

    public ILocator SplitBIDed => _page.GetByText("Split BI Ded", new() { Exact = true });

    public ILocator SplitPDDed => _page.GetByText("Split PD Ded", new() { Exact = true });

    public ILocator SquareFeet => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0245_3_1-inputEl\"]");

    public ILocator PolicyHolderState => _page.Locator("[fieldref=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderState\"], [data-fieldref=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderState\"]");

    public ILocator State => _page.GetByRole(AriaRole.Textbox, new() { Name = "State", Exact = true });

    public ILocator EndorsementsDesignatedWorkplacesExclusionState => _page.GetByRole(AriaRole.Textbox, new() { Name = "State*", Exact = true });

    public ILocator StateDetails => _page.GetByRole(AriaRole.Link, new() { Name = "State Details", Exact = true });

    public ILocator StateLicensed => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D5_1_1-inputEl\"]");

    public ILocator StateOrPoliticalSubdivision => _page.GetByRole(AriaRole.Textbox, new() { Name = "State or Political Subdivision*", Exact = true });

    public ILocator StatedAmount => _page.GetByRole(AriaRole.Textbox, new() { Name = "Stated Amount*", Exact = true });

    public ILocator StoplightMessageTotalSubjectPremium => _page.GetByText("Stoplight Message: Total Subject Premium", new() { Exact = true });

    public ILocator StorageLimit => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF587517408A3_1_1-inputEl\"]");

    public ILocator Stories => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0247_3_1-inputEl\"]");

    public ILocator Submission => _page.GetByRole(AriaRole.Link, new() { Name = "Submission", Exact = true });

    public ILocator SubmissionHeading => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Submission Heading");

    public ILocator TapesCoverage => _page.Locator("[id=\"f_cA3C9AC7006E9416C9517BA15BC2DCE5F2364_2_1-inputEl\"]");

    public ILocator TextBox => _page.GetByRole(AriaRole.Textbox, new() { Name = "TextBox", Exact = true });

    public ILocator ThirdPartyDesignee => _page.GetByRole(AriaRole.Link, new() { Name = "Third Party Designee", Exact = true });

    public ILocator Title => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Title");

    public ILocator ToolsAndClothingBelongingToYourEmployees => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FEB_3_1-inputEl\"]");

    public ILocator TotalCostOfWork => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA7041_3_1-inputEl\"]");

    public ILocator TotalPayrollEstimated => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Payroll (Estimated)", Exact = true });

    public ILocator TotalPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Premium", Exact = true });

    public ILocator GeneralLiabilityTotalSubjectPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Subject Premium*", Exact = true });

    public ILocator BusinessownersTotalSubjectPremium => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-68c5-7803-bcdd157945fb");

    public ILocator Towing => _page.GetByRole(AriaRole.Textbox, new() { Name = "Towing", Exact = true });

    public ILocator TrailerInterchangeCollisionDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Trailer Interchange Collision Deductible", Exact = true });

    public ILocator TrailerInterchangeCompDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Trailer Interchange Comp Deductible", Exact = true });

    public ILocator TrailerInterchangeEnterDaysInsured => _page.GetByRole(AriaRole.Textbox, new() { Name = "Trailer Interchange - Enter # Days Insured", Exact = true });

    public ILocator TrailerInterchangeEnterOfTrailers => _page.GetByRole(AriaRole.Textbox, new() { Name = "Trailer Interchange - Enter # of Trailers", Exact = true });

    public ILocator FG0013AutomaticAdditionalInsuredSpecificRelationshipType => _page.Locator("[fieldref=\"AdditionalOtherInterestInput.Type\"], [data-fieldref=\"AdditionalOtherInterestInput.Type\"]");

    public ILocator EndorsementMainType => _page.Locator("[id=\"f_c4CBF9D54B72F454488F8BD49B282C532C8_3_10-inputEl\"]");

    public ILocator GLOCPRiskType => _page.Locator("[fieldref=\"CovOwnersContractorsOrPrincipalsInput.Type\"], [data-fieldref=\"CovOwnersContractorsOrPrincipalsInput.Type\"]");

    public ILocator CG2007AddLInsuredEngineersArchitectsType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    public ILocator RiskSignsType => _page.Locator("[id=\"f_r99A2986D696A457DA1C69BB16D902CEF18_1_1-inputEl\"]");

    public ILocator TypeOfContractor => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FCB_3_1-inputEl\"]");

    public ILocator TypeOfEquipment => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type of Equipment", Exact = true });

    public ILocator TypeOfInterest => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type of Interest", Exact = true });

    public ILocator TypeOfLicense => _page.Locator("[fieldref=\"AdditionalOtherInterestInput.DescriptionOfCompletedOps\"], [data-fieldref=\"AdditionalOtherInterestInput.DescriptionOfCompletedOps\"]");

    public ILocator UMBILimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "UMBI Limit*", Exact = true });

    public ILocator UMTypeDefaultSelections => _page.GetByRole(AriaRole.Textbox, new() { Name = "UM Type Default Selections", Exact = true });

    public ILocator UWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "UW Questions", Exact = true });

    public ILocator UWQuestionsUmbrella => _page.GetByRole(AriaRole.Link, new() { Name = "UW Questions - Umbrella", Exact = true });

    public ILocator UWQuestionsWorkersComp => _page.GetByRole(AriaRole.Link, new() { Name = "UW Questions - Workers Comp", Exact = true });

    public ILocator UmbrellaLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Umbrella Limit", Exact = true });

    public ILocator UnderwritingInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

    public ILocator UninterruptiblePowerSource => _page.Locator("[id=\"f_c7FA512A090F641B9A6BB95F4C656EE183E_2_21-inputEl\"]");

    public ILocator UnnamedPremises => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8A_3_4-inputEl\"]");

    public ILocator UnnamedTerminalsLimit => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB401095_3_5-inputEl\"]");

    public ILocator SpecificUnderwritingQuestionsContractorsEquipmentUpdateAnswers => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-a0a4-7d37-fbe634036887");

    public ILocator UWQuestionsUmbrellaUpdateAnswers => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true });

    public ILocator PropertyUWQuestionsUpdateAnswers => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-22cc-e9ee-5fbbaef42d8c");

    public ILocator UpdateAnswersButton => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers Button", Exact = true });

    public ILocator UsedAsShowroom => _page.GetByRole(AriaRole.Textbox, new() { Name = "Used As Showroom", Exact = true });

    public ILocator VIN => _page.GetByRole(AriaRole.Textbox, new() { Name = "VIN*", Exact = true });

    public ILocator VacancyPermit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Vacancy Permit", Exact = true });

    public ILocator VacantBuilding => _page.GetByRole(AriaRole.Textbox, new() { Name = "Vacant Building", Exact = true });

    public ILocator Valuation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Valuation", Exact = true });

    public ILocator ValuationType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Valuation Type*", Exact = true });

    public ILocator ValueBasis => _page.GetByRole(AriaRole.Textbox, new() { Name = "Value Basis", Exact = true });

    public ILocator VehicleInformation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Vehicle Information", Exact = true });

    public ILocator VehicleSchedule1Veh => _page.GetByText("Veh #", new() { Exact = true });

    public ILocator VehicleType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Vehicle Type", Exact = true });

    public ILocator VirusHarmfulCodeOrSimilarInstruction => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8D_3_4-inputEl\"]");

    public ILocator VolunteerHiredAutosCheckBox => _page.Locator("[fieldref=\"LineStateInput.VolunteerHiredAuto\"], [data-fieldref=\"LineStateInput.VolunteerHiredAuto\"]");

    public ILocator WCSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "WC Schedule", Exact = true });

    public ILocator WaitonPricingHeadingAndFillOutRequiredFields => _page.GetByText("Waiton Pricing Heading and Fill Out Required Fields", new() { Exact = true });

    public ILocator WaiverOfSubrogation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Waiver Of Subrogation", Exact = true });

    public ILocator WaiverOfSubrogationExposure => _page.GetByRole(AriaRole.Textbox, new() { Name = "Waiver Of Subrogation Exposure*", Exact = true });

    public ILocator WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days => _page.GetByRole(AriaRole.Textbox, new() { Name = "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?", Exact = true });

    public ILocator WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured => _page.Locator("[name=\"string_2F_2\"]");

    public ILocator WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage => _page.Locator("[name=\"string_2F_3\"]");

    public ILocator WhatIsTheConstructionOfEachSign => _page.Locator("[fieldref=\"SignsUnderwritingQuestionsInput.Description\"], [data-fieldref=\"SignsUnderwritingQuestionsInput.Description\"]");

    public ILocator WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored => _page.Locator("[name=\"string_1F\"]");

    public ILocator WhatIsTheDistanceInFeetToTheNearestFireHydrant => _page.Locator("[id=\"f_cD3F347C9072D47E4BDC9B2BEE6F633CD38_2_15-inputEl\"]");

    public ILocator WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment => _page.Locator("[id=\"f_cD3F347C9072D47E4BDC9B2BEE6F633CD3B_2_15-inputEl\"]");

    public ILocator WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational => _page.GetByRole(AriaRole.Textbox, new() { Name = "What is the primary reason this new policy is being rewritten with Farm Family/American National?*", Exact = true });

    public ILocator WhatIsTheProcedureForTransportingTheComputerEquipment => _page.Locator("[name=\"string_2F\"]");

    public ILocator WhatIsThePublicProtectionClassRating => _page.Locator("[id=\"f_cD3F347C9072D47E4BDC9B2BEE6F633CD35_2_15-inputEl\"]");

    public ILocator WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft => _page.Locator("[name=\"string_1F_1\"]");

    public ILocator WhichFormAreYouCompleting => _page.Locator("[id=\"f_u90F32F80C0574D33AD962F038C8FC2AF56_2_1-inputEl\"]");

    public ILocator WhyIsThisCoverageDesired => _page.GetByRole(AriaRole.Textbox, new() { Name = "Why is this coverage desired?", Exact = true });

    public ILocator Year => _page.GetByRole(AriaRole.Textbox, new() { Name = "Year*", Exact = true });

    public ILocator YearBuilt => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0243_3_1-inputEl\"]");

    public ILocator YearLicensed => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D4_1_1-inputEl\"]");

    public ILocator YearsInBusiness => _page.GetByRole(AriaRole.Textbox, new() { Name = "Years In Business", Exact = true });

    public ILocator LocationZipCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code", Exact = true });

    public ILocator ThirdPartyDesigneeZipCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code*", Exact = true });

    public ILocator GLOCPRiskZipCode => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA7062_3_1-inputEl\"]");

    public ILocator EntityInfoFrameEntityInfoWindowFax => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Fax");

    public ILocator EntityInfoFrameEntityInfoWindowBureauNumber => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Bureau Number");

    public ILocator EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "State Unemployment Number Default");
}
