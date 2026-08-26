using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class NavigationLocators
{
    private readonly IPage _page;
    public NavigationLocators(IPage page) => _page = page;

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Physical Damage | AV Cost New* | DuckCreekId
    public ILocator AVCostNew => _page.Locator("[duckcreekid=\"CovAudioVisualInput.CostNew\"], [data-duckcreekid=\"CovAudioVisualInput.CostNew\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | a. What is the public Protection class rating? | Id+Name+DuckCreekId
    public ILocator AWhatIsThePublicProtectionClassRating => _page.Locator("input[id=\"f_b90770E4D06DC47CE875AD48619BBB71B170_2_8-inputEl\"][name=\"string_170|\"][duckcreekid=\"BaileesCustomerUnderwritingQuestionsInput.PublicProtectionClass\"]");

    // Source modules: Risk Schedule|Liability, UM, Medical & PIP | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Liability, UM, Medical & PIP | Accept UM | DuckCreekId
    public ILocator AcceptUM => _page.Locator("[duckcreekid=\"Accept UM\"], [data-duckcreekid=\"Accept UM\"]");

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=97
    // v56 raw Tosca primary: Specific Underwriting Questions - Accounts Receivable | Accounts Receivable Heading | Id
    public ILocator AccountsReceivableHeading => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: IM Navigation Links | Accounts Receivable UW Questions | Id
    public ILocator AccountsReceivableUWQuestions => _page.Locator("[id=\"ext-element-233\"]");

    // Source modules: Risk - Main | confidence=High score=125
    // v56 raw Tosca primary: Risk - Main | Add | DuckCreekId
    public ILocator Add => _page.Locator("[duckcreekid=\"Add\"], [data-duckcreekid=\"Add\"]");

    // Source modules: Addl Interests|Main | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Main | Add Addl Interest | DuckCreekId
    public ILocator AddAddlInterest => _page.Locator("[duckcreekid=\"Add Addl Interest\"], [data-duckcreekid=\"Add Addl Interest\"]");

    // Source modules: Building - Main | confidence=High score=125
    // v56 raw Tosca primary: Building - Main | Add Building | DuckCreekId
    public ILocator AddBuilding => _page.Locator("[duckcreekid=\"Add Building\"], [data-duckcreekid=\"Add Building\"]");

    // Source modules: CGL|Main Page | confidence=High score=125
    // v56 raw Tosca primary: CGL|Main Page | Add Class | DuckCreekId
    public ILocator AddClassB04B6 => _page.Locator("[duckcreekid=\"Add Class\"], [data-duckcreekid=\"Add Class\"]");

    // Source modules: WC Schedule|Main Page | confidence=High score=125
    // v56 raw Tosca primary: WC Schedule|Main Page | Add Class Code | DuckCreekId
    public ILocator AddClassCode => _page.Locator("[duckcreekid=\"Add Class Code\"], [data-duckcreekid=\"Add Class Code\"]");

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator AddClassDCD8F => AddClassB04B6; // semantic alias; locator defined once

    // Source modules: CGL|Add Class | confidence=High score=125
    // v56 raw Tosca primary: CGL|Add Class | OK | DuckCreekId | frame=iframe
    public ILocator AddClassOK => _page.FrameLocator("iframe").Locator("[duckcreekid=\"OK\"], [data-duckcreekid=\"OK\"]");

    // Source modules: Policy Covg - Main | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Main | Add Coverage Form | DuckCreekId
    public ILocator AddCoverageForm => _page.Locator("[duckcreekid=\"Add Coverage Form\"], [data-duckcreekid=\"Add Coverage Form\"]");

    // Source modules: Driver Schedule | confidence=High score=125
    // v56 raw Tosca primary: Driver Schedule | Add Driver | DuckCreekId
    public ILocator AddDriver => _page.Locator("[duckcreekid=\"Add Driver\"], [data-duckcreekid=\"Add Driver\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Add Driver Name | Id+Name+DuckCreekId | frame=iframe
    public ILocator AddDriverName => _page.FrameLocator("iframe").Locator("input[id=\"f_eC9B5D952311D4E46BAAE946A2A0730E51034_1_1-inputEl\"][name=\"string_1034|\"][duckcreekid=\"ExcludeDriver.ExcludedDriver\"]");

    // Source modules: [CU0206] Utah Changes - Notice of Cancellation for Private Investigator Agencies | confidence=High score=125
    // v56 raw Tosca primary: [CU0206] Utah Changes - Notice of Cancellation for Private Investigator Agencies | Add Endorsement | DuckCreekId
    public ILocator AddEndorsement04BD0 => _page.Locator("[duckcreekid=\"Add Endorsement\"], [data-duckcreekid=\"Add Endorsement\"]");

    // Source modules: BOP Expanded Endorsements|Add Endorsement | confidence=High score=125
    public ILocator AddEndorsement34EE3 => AddEndorsement04BD0; // semantic alias; locator defined once

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    public ILocator AddEndorsement44E6A => AddEndorsement04BD0; // semantic alias; locator defined once

    // Source modules: Endorsement - Main | confidence=High score=125
    public ILocator AddEndorsement48A9E => AddEndorsement04BD0; // semantic alias; locator defined once

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    public ILocator AddEndorsement9E5F4 => AddEndorsement04BD0; // semantic alias; locator defined once

    // Source modules: Endorsements|Main | confidence=High score=125
    public ILocator AddEndorsementA9973 => AddEndorsement04BD0; // semantic alias; locator defined once

    // Source modules: Endorsements|Waiton Add Endorsement Button | confidence=High score=125
    public ILocator AddEndorsementB6452 => AddEndorsement04BD0; // semantic alias; locator defined once

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=125
    public ILocator AddEndorsementCE8DD => AddEndorsement04BD0; // semantic alias; locator defined once

    // Source modules: [UC1101] Exclusion for Designated Activities or Services | confidence=High score=125
    public ILocator AddEndorsementD15B0 => AddEndorsement04BD0; // semantic alias; locator defined once

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    // v56 raw Tosca primary: Endorsements|Partners, Officers And Others Exclusion | Add Excluded Officer Information | DuckCreekId
    public ILocator AddExcludedOfficerInformation => _page.Locator("[duckcreekid=\"Add Excluded Officer Information\"], [data-duckcreekid=\"Add Excluded Officer Information\"]");

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    // v56 raw Tosca primary: Endorsements|Partners, Officers And Others Exclusion | Add Excluded Others' Information | DuckCreekId
    public ILocator AddExcludedOthersInformation => _page.Locator("[duckcreekid=\"Add Excluded Others' Information\"], [data-duckcreekid=\"Add Excluded Others' Information\"]");

    // Source modules: Rating Groups | confidence=High score=125
    // v56 raw Tosca primary: Rating Groups | Add Group | DuckCreekId
    public ILocator AddGroup => _page.Locator("[duckcreekid=\"Add Group\"], [data-duckcreekid=\"Add Group\"]");

    // Source modules: NotePad | confidence=High score=125
    public ILocator AddNotesRemarks => _page.GetByRole(AriaRole.Button, new() { Name = "Add Notes/Remarks", Exact = true });

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Add Option A | DuckCreekId | frame=iframe
    public ILocator AddOptionA => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Add Option A\"], [data-duckcreekid=\"Add Option A\"]");

    // Source modules: Additional Interests Schedule | confidence=High score=125
    // v56 raw Tosca primary: Additional Interests Schedule | Add Other Interest | DuckCreekId
    public ILocator AddOtherInterest => _page.Locator("[duckcreekid=\"Add Other Interest\"], [data-duckcreekid=\"Add Other Interest\"]");

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=95
    // v56 raw Tosca primary: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Add Others' Information | DuckCreekId
    public ILocator AddOthersInformation => _page.Locator("[duckcreekid=\"Add Others' Information\"], [data-duckcreekid=\"Add Others' Information\"]");

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    // v56 raw Tosca primary: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Add Partner Information | DuckCreekId
    public ILocator AddPartnerInformation => _page.Locator("[duckcreekid=\"Add Partner Information\"], [data-duckcreekid=\"Add Partner Information\"]");

    // Source modules: Policy Covg - Bailees - Property Away from Your Premises | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Bailees - Property Away from Your Premises | Add Premises | DuckCreekId
    public ILocator AddPremises => _page.Locator("[duckcreekid=\"Add Premises\"], [data-duckcreekid=\"Add Premises\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    public ILocator AddPriorCarrier => _page.GetByRole(AriaRole.Button, new() { Name = "Add Prior Carrier", Exact = true });

    // Source modules: Risk Aggregate | confidence=High score=125
    // v56 raw Tosca primary: Risk Aggregate | Add Risk at This Location | DuckCreekId
    public ILocator AddRiskAtThisLocation => _page.Locator("[duckcreekid=\"Add Risk at This Location\"], [data-duckcreekid=\"Add Risk at This Location\"]");

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    // v56 raw Tosca primary: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Add Sole Proprietor Information | DuckCreekId
    public ILocator AddSoleProprietorInformation => _page.Locator("[duckcreekid=\"Add Sole Proprietor Information\"], [data-duckcreekid=\"Add Sole Proprietor Information\"]");

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    // v56 raw Tosca primary: Client|Third Party Designee|Common | Add Third Party | DuckCreekId
    public ILocator AddThirdParty => _page.Locator("[duckcreekid=\"Add Third Party\"], [data-duckcreekid=\"Add Third Party\"]");

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: BAP Navigation Links | State Details - Detail | Id
    public ILocator AdditionalInterests => _page.Locator("[id=\"dctGridLink\"]");

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    public ILocator AdditionalOtherInterestInputAddress1 => _page.Locator("[name=\"AdditionalOtherInterestInput.Address1\"], [id=\"AdditionalOtherInterestInput.Address1\"]").First;

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    public ILocator AdditionalOtherInterestInputFirstName => _page.Locator("[name=\"AdditionalOtherInterestInput.FirstName\"], [id=\"AdditionalOtherInterestInput.FirstName\"]").First;

    // Source modules: Client|Third Party Designee|Common | confidence=High score=95
    public ILocator AdditionalOtherInterestInputLastName => _page.Locator("[name=\"AdditionalOtherInterestInput.LastName\"], [id=\"AdditionalOtherInterestInput.LastName\"]").First;

    // Source modules: Additional Interests Schedule | confidence=High score=127
    // v56 raw Tosca primary: Additional Interests Schedule | Addl Interests | Id
    public ILocator AddlInterests15174 => _page.Locator("[id=\"pageTop\"]");

    // Source modules: Addl Interests|Main | confidence=High score=127
    public ILocator AddlInterestsA10A4 => AddlInterests15174; // semantic alias; locator defined once

    // Source modules: GL Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Addl Interests - Main | Addl Interests | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator AddlInterestsE39FC => AccountsReceivableHeading;

    // Source modules: Endorsement - CM 66 01 Exclude Named Customer | confidence=High score=125
    // v56 raw Tosca primary: Endorsement - CM 66 01 Exclude Named Customer | Address | Id+Name+DuckCreekId
    public ILocator Address => _page.Locator("input[id=\"f_CCE14981F38894A679A407BA735B5959BD3_3_1-inputEl\"][name=\"string_D3|\"][duckcreekid=\"CovEndorsmentIteratorNonShreddedInput.Address\"]");

    // Source modules:  | confidence=High score=125
    // v56 raw Tosca primary: Endorsement - CM 66 01 Exclude Named Customer | Address | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as Address
    public ILocator Address193FF8 => Address;

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    // v56 raw Tosca primary: [CG 29 35] Add'l Insured-State or Political (Permits) | Address 1 | DuckCreekId | frame=iframe
    public ILocator Address19B8B5 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.Address1\"], [data-duckcreekid=\"AdditionalOtherInterestInput.Address1\"]");

    // Source modules: GL OCP|Risk | confidence=High score=125
    public ILocator Address1BE797 => Address19B8B5; // semantic alias; locator defined once

    // Source modules: Location | confidence=High score=125
    // v56 raw Tosca primary: Location | Address1 | DuckCreekId | frame=iframe
    public ILocator Address1C0AF1 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"LocationInput.Address1\"], [data-duckcreekid=\"LocationInput.Address1\"]");

    // Source modules: Policy Covg - Bailees - Property Away from Your Premises | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Bailees - Property Away from Your Premises | Address (Street, City, State, Zip) | Id+Name+DuckCreekId
    public ILocator AddressStreetCityStateZip => _page.Locator("input[id=\"f_b7BA9D20D6B9840E99A47B1B0DFA716BF7_1_1-inputEl\"][name=\"string_7|\"][duckcreekid=\"BaileesCustomersPropertyAwayFromYourPremises.Address\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Aggregate Limit | DuckCreekId
    public ILocator AggregateLimit => _page.Locator("[duckcreekid=\"LineInput.PolicyAggregateLimit\"], [data-duckcreekid=\"LineInput.PolicyAggregateLimit\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v56 raw Tosca primary: Risk - Bailees Customers | Annual Gross Receipts | Id+Name+DuckCreekId
    public ILocator AnnualGrossReceipts => _page.Locator("input[id=\"f_c1130867FA0E9485FBAA81AF5875174088F_1_1-inputEl\"][name=\"int_8F\"][duckcreekid=\"CovBaileesCustomersInput.AnnualGrossReceipts\"]");

    // Source modules: Underwriting Questions | confidence=High score=125
    // v56 raw Tosca primary: Underwriting Questions | AnyPersonalAutoPolicyListingNameInsured | Id+Name+DuckCreekId
    public ILocator AnyPersonalAutoPolicyListingNameInsured => _page.Locator("input[id=\"f_uFE2672745CB24DB2A83158A3D6E7E97F13E_3_1-inputEl\"][name=\"f_uFE2672745CB24DB2A83158A3D6E7E97F13E_3_1-inputEl\"][duckcreekid=\"UnderwritingQuestionsAutoInput.AnyPersonalAutoPolicyListingNameInsured\"]");

    // Source modules: Underwriting Questions | confidence=High score=125
    // v56 raw Tosca primary: Underwriting Questions | AnyVehicleCoveredRegisteredInNotPrimaryState | Id+Name+DuckCreekId
    public ILocator AnyVehicleCoveredRegisteredInNotPrimaryState => _page.Locator("input[id=\"f_uFE2672745CB24DB2A83158A3D6E7E97F187_3_1-inputEl\"][name=\"f_uFE2672745CB24DB2A83158A3D6E7E97F187_3_1-inputEl\"][duckcreekid=\"UnderwritingQuestionsAutoInput.AnyVehicleCoveredRegisteredInNotPrimaryState\"]");

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Signs | Are Any signs off premises or not attached to building? | Id+Name+DuckCreekId
    public ILocator AreAnySignsOffPremisesOrNotAttachedToBuilding => _page.Locator("input[id=\"f_sEDD5CE21D8434468900294193CF0200E1D_2_1-inputEl\"][name=\"f_sEDD5CE21D8434468900294193CF0200E1D_2_1-inputEl\"][duckcreekid=\"SignsUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: UW Questions - Workers Comp | confidence=High score=95
    // v56 raw Tosca primary: UW Questions - Workers Comp | Are physicals required after offers of employment are made?* | DuckCreekId
    public ILocator ArePhysicalsRequiredAfterOffersOfEmploymentAreMade => _page.Locator("[duckcreekid=\"UnderwritingQuestionsWorkersCompInput.PhysicalsRequiredAfterEmploymentOffers\"], [data-duckcreekid=\"UnderwritingQuestionsWorkersCompInput.PhysicalsRequiredAfterEmploymentOffers\"]");

    // Source modules: Underwriting Questions | confidence=High score=125
    // v56 raw Tosca primary: Underwriting Questions | Are there any commercial vehicles owned by the applicant not insured on the policy? | DuckCreekId
    public ILocator AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy => _page.Locator("[duckcreekid=\"UnderwritingQuestionsAutoInput.AnyCommercialVehiclesOwned\"], [data-duckcreekid=\"UnderwritingQuestionsAutoInput.AnyCommercialVehiclesOwned\"]");

    // Source modules: Endorsements|Waiton Add Endorsement Button | confidence=High score=95
    // v56 raw Tosca primary: Endorsements|Waiton Add Endorsement Button | Are there any Officers that should be excluded?* | Id+Name+DuckCreekId
    public ILocator AreThereAnyOfficersThatShouldBeExcluded => _page.Locator("input[id=\"f_lA2C9A848A1FC45D39BB20EBBC28014492E1_3_1-inputEl\"][name=\"f_lA2C9A848A1FC45D39BB20EBBC28014492E1_3_1-inputEl\"][duckcreekid=\"LineInput.EntityOfficersExclusion\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Assign Location | DuckCreekId | frame=iframe
    public ILocator AssignLocation => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Assign Location\"], [data-duckcreekid=\"Assign Location\"]");

    // Source modules: Entity Schedule|Location Assignment | confidence=High score=125
    // v56 raw Tosca primary: Entity Schedule|Location Assignment | Assign Locations | DuckCreekId
    public ILocator AssignLocations => _page.Locator("[duckcreekid=\"Assign Locations\"], [data-duckcreekid=\"Assign Locations\"]");

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Physical Damage | Audio Visual | Id+Name+DuckCreekId
    public ILocator AudioVisual => _page.Locator("input[id=\"f_c6FBE834FF11D44EEA4139F156BB928EC236C_2_1-inputEl\"][name=\"f_c6FBE834FF11D44EEA4139F156BB928EC236C_2_1-inputEl\"][duckcreekid=\"CovAudioVisualInput.AudioVisual\"]");

    // Source modules: CPP|Pricing | confidence=High score=125
    // v56 raw Tosca primary: CPP|Pricing | Available Classifications* | Id+Name+DuckCreekId
    public ILocator AvailableClassifications => _page.Locator("input[id=\"f_cF339927B88A5461CBDBBA081531BA503602_3_1-inputEl\"][name=\"f_cF339927B88A5461CBDBBA081531BA503602_3_1-inputEl\"][duckcreekid=\"CPPPackagePMAOutputNonshredded.AvailablePMAOccupancyTypes\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v56 raw Tosca primary: Risk - Bailees Customers | Average Number Of Days Service | Id+Name+DuckCreekId
    public ILocator AverageNumberOfDaysService => _page.Locator("input[id=\"f_c1130867FA0E9485FBAA81AF58751740890_1_1-inputEl\"][name=\"int_90\"][duckcreekid=\"CovBaileesCustomersInput.AverageNumberOfDaysService\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v56 raw Tosca primary: Risk - Bailees Customers | Average Number Of Working Days | Id+Name+DuckCreekId
    public ILocator AverageNumberOfWorkingDays => _page.Locator("input[id=\"f_c1130867FA0E9485FBAA81AF58751740891_1_1-inputEl\"][name=\"int_91\"][duckcreekid=\"CovBaileesCustomersInput.AverageNumberOfWorkingDays\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v56 raw Tosca primary: Risk - Bailees Customers | Average Service Charge | Id+Name+DuckCreekId
    public ILocator AverageServiceCharge => _page.Locator("input[id=\"f_c1130867FA0E9485FBAA81AF58751740892_1_1-inputEl\"][name=\"int_92\"][duckcreekid=\"CovBaileesCustomersInput.AverageServiceCharge\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v56 raw Tosca primary: Risk - Bailees Customers | Average Value Per Order | Id+Name+DuckCreekId
    public ILocator AverageValuePerOrder => _page.Locator("input[id=\"f_c1130867FA0E9485FBAA81AF58751740893_1_1-inputEl\"][name=\"int_93\"][duckcreekid=\"CovBaileesCustomersInput.AverageValuePerOrder\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | b. Are there any private protection improvements? | Id+Name+DuckCreekId
    public ILocator BAreThereAnyPrivateProtectionImprovements => _page.Locator("input[id=\"f_b90770E4D06DC47CE875AD48619BBB71B171_2_8-inputEl\"][name=\"f_b90770E4D06DC47CE875AD48619BBB71B171_2_8-inputEl\"][duckcreekid=\"BaileesCustomerUnderwritingQuestionsInput.PrivateProtectionIndicator\"]");

    // Source modules: Building - Detail | confidence=High score=95
    // v56 raw Tosca primary: Building - Detail | BG2 Symbol | Id+Name+DuckCreekId
    public ILocator BG2Symbol => _page.Locator("input[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D026E_3_1-inputEl\"][name=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D026E_3_1-inputEl\"][duckcreekid=\"BuildingInput.BG2Symbol\"]");

    // Source modules: Building - Detail | confidence=High score=95
    // v56 raw Tosca primary: Building - Detail | BG2 Symbol Prefix | Id+Name+DuckCreekId
    public ILocator BG2SymbolPrefix => _page.Locator("input[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0270_3_1-inputEl\"][name=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0270_3_1-inputEl\"][duckcreekid=\"BuildingInput.BG2SymbolPrefix\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=97
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | Bailees Customer Heading | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator BaileesCustomerHeading => AccountsReceivableHeading;

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: IM Navigation Links | Bailees Customer UW Questions | Id
    public ILocator BaileesCustomerUWQuestions => _page.Locator("[id=\"ext-element-4167\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator BaileesCustomersHeading => _page.GetByText("Bailees Customers Heading", new() { Exact = true });

    // Source modules: Billing | confidence=High score=125
    public ILocator BillType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Bill Type", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator Billing6ED79 => _page.GetByRole(AriaRole.Link, new() { Name = "Billing", Exact = true });

    // Source modules: Billing | confidence=High score=127
    public ILocator BillingD1518 => _page.GetByLabel("Billing", new() { Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Vehicle Information | Body Style | DuckCreekId
    public ILocator BodyStyle => _page.Locator("[duckcreekid=\"RiskVehicleInput.BodyStyle\"], [data-duckcreekid=\"RiskVehicleInput.BodyStyle\"]");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Contractors Equipment | Boom Deductible | Id+Name+DuckCreekId
    public ILocator BoomDeductible => _page.Locator("input[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FC8_3_1-inputEl\"][name=\"f_c48C85AB0259E43AE8BED26305EA4E022FC8_3_1-inputEl\"][duckcreekid=\"ContractorsEquipmentInput.BoomDeductible\"]");

    // Source modules: Underwriting Questions | confidence=High score=125
    // v56 raw Tosca primary: Underwriting Questions | BorrowingHiringOrLeasingWithinYear | Id+Name+DuckCreekId
    public ILocator BorrowingHiringOrLeasingWithinYear => _page.Locator("input[id=\"f_uFE2672745CB24DB2A83158A3D6E7E97F142_3_1-inputEl\"][name=\"f_uFE2672745CB24DB2A83158A3D6E7E97F142_3_1-inputEl\"][duckcreekid=\"UnderwritingQuestionsAutoInput.BorrowingHiringOrLeasingWithinYear\"]");

    // Source modules: Building - Main | confidence=High score=127
    // v56 raw Tosca primary: Building - Main | Building | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator Building8205F => AccountsReceivableHeading;

    // Source modules: CP Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Building - Main | Building | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator Building87910 => AccountsReceivableHeading;

    // Source modules: Building - Detail | confidence=High score=125
    public ILocator BuildingDetailOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Property Add Class | confidence=High score=125
    // v56 raw Tosca primary: Property Add Class | Building Limit | DuckCreekId
    public ILocator BuildingLimit => _page.Locator("[duckcreekid=\"RiskPropertyInput.Limit\"], [data-duckcreekid=\"RiskPropertyInput.Limit\"]");

    // Source modules: Property Add Class | confidence=High score=125
    // v56 raw Tosca primary: Property Add Class | Building Rating Group | DuckCreekId
    public ILocator BuildingRatingGroup => _page.Locator("[duckcreekid=\"RiskInput.RatingGroupID\"], [data-duckcreekid=\"RiskInput.RatingGroupID\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Business Interruption Description Of ScheduledProperty | DuckCreekId | frame=iframe
    public ILocator BusinessInterruptionDescriptionOfScheduledProperty => _page.FrameLocator("iframe").Locator("[duckcreekid=\"BusinessInterruptionOptionAInput.DescriptionOfScheduledProperty\"], [data-duckcreekid=\"BusinessInterruptionOptionAInput.DescriptionOfScheduledProperty\"]");

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=97
    // v56 raw Tosca primary: Policy Coverage|Business Interruption | Business Interruption Detail | Id
    // v56 semantic alias: same physical raw-Tosca control as AddlInterests15174
    public ILocator BusinessInterruptionDetail => AddlInterests15174;

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    // v56 raw Tosca primary: Policy Coverage|Business Interruption | Business Interruption Endorsement | DuckCreekId
    public ILocator BusinessInterruptionEndorsement => _page.Locator("[duckcreekid=\"LineCoveragesInput.BusinessInterruptionEndorsement\"], [data-duckcreekid=\"LineCoveragesInput.BusinessInterruptionEndorsement\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Business Interruption Limit Of Insurance | DuckCreekId | frame=iframe
    public ILocator BusinessInterruptionLimitOfInsurance => _page.FrameLocator("iframe").Locator("[duckcreekid=\"BusinessInterruptionOptionAInput.LimitOfInsurance\"], [data-duckcreekid=\"BusinessInterruptionOptionAInput.LimitOfInsurance\"]");

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    public ILocator BusinessInterruptionOK => AddClassOK; // semantic alias; locator defined once

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | [CA2325] Leased Workers Coverage | DuckCreekId | frame=iframe
    public ILocator CA2325LeasedWorkersCoverage => _page.FrameLocator("iframe").Locator("[duckcreekid=\"\"[CA2325] Leased Workers Coverage\"\"], [data-duckcreekid=\"\"[CA2325] Leased Workers Coverage\"\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | CA9940 - Contract Provisions | DuckCreekId | frame=iframe
    public ILocator CA9940ContractProvisions => _page.FrameLocator("iframe").Locator("[duckcreekid=\"CovEndorsementsInput.ContractProvisions\"], [data-duckcreekid=\"CovEndorsementsInput.ContractProvisions\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | CA9940 - Make | DuckCreekId | frame=iframe
    public ILocator CA9940Make => _page.FrameLocator("iframe").Locator("[duckcreekid=\"CovEndorsementsInput.Make\"], [data-duckcreekid=\"CovEndorsementsInput.Make\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | CA9940 - Model | DuckCreekId | frame=iframe
    public ILocator CA9940Model => _page.FrameLocator("iframe").Locator("[duckcreekid=\"CovEndorsementsInput.Model\"], [data-duckcreekid=\"CovEndorsementsInput.Model\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | CA 9940 - VIN | DuckCreekId | frame=iframe
    public ILocator CA9940VIN => _page.FrameLocator("iframe").Locator("[duckcreekid=\"CovEndorsementsInput.VIN\"], [data-duckcreekid=\"CovEndorsementsInput.VIN\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | CA9940 - Year | DuckCreekId | frame=iframe
    public ILocator CA9940Year => _page.FrameLocator("iframe").Locator("[duckcreekid=\"CovEndorsementsInput.Year\"], [data-duckcreekid=\"CovEndorsementsInput.Year\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | CA9948 - Classes Of Commodities Transported | DuckCreekId | frame=iframe
    public ILocator CA9948ClassesOfCommoditiesTransported => _page.FrameLocator("iframe").Locator("[duckcreekid=\"CovEndorsementsInput.ClassesOfCommoditiesTransported\"], [data-duckcreekid=\"CovEndorsementsInput.ClassesOfCommoditiesTransported\"]");

    // Source modules: [CG0424] Coverage for Injury to Leased Workers | confidence=High score=125
    public ILocator CG0424CoverageForInjuryToLeasedWorkersOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: [CG0435] Employee Benefits Liability | confidence=High score=125
    public ILocator CG0435EmployeeBenefitsLiabilityOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: [CG 20 07] Add'l Insured-Engineers, Architects | confidence=High score=125
    public ILocator CG2007AddLInsuredEngineersArchitectsOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: [CG 20 20] Add'l Insured-Charitable Institution | confidence=High score=125
    public ILocator CG2020AddLInsuredCharitableInstitutionOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=125
    public ILocator CG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: [CG 2149] Total Pollution Exclusion Endorsement | confidence=High score=125
    public ILocator CG2149TotalPollutionExclusionEndorsementOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: [CG2401] Non-Binding Arbitration | confidence=High score=125
    public ILocator CG2401NonBindingArbitrationOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: [CG2812] Pesticide or Herbicide Applicator Coverage | confidence=High score=125
    public ILocator CG2812PesticideOrHerbicideApplicatorCoverageOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    public ILocator CG2935AddLInsuredStateOrPoliticalPermitsOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: GL Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: CGL|Main Page | CGL | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator CGL08901 => AccountsReceivableHeading;

    // Source modules: CGL|Main Page | confidence=High score=127
    // v56 raw Tosca primary: CGL|Main Page | CGL | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator CGLBA8E8 => AccountsReceivableHeading;

    // Source modules: General Liability | confidence=High score=95
    // v56 raw Tosca primary: General Liability | CGL Limits* | DuckCreekId
    public ILocator CGLLimits => _page.Locator("[duckcreekid=\"UmbrellaGeneralLiabilityInputLimitsNonShredded.CGLLimits\"], [data-duckcreekid=\"UmbrellaGeneralLiabilityInputLimitsNonShredded.CGLLimits\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator CPPLiability => _page.GetByRole(AriaRole.Link, new() { Name = "CPP Liability", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | c. What is the distance in feet to the nearest hydrant? | Id+Name+DuckCreekId
    public ILocator CWhatIsTheDistanceInFeetToTheNearestHydrant => _page.Locator("input[id=\"f_b90770E4D06DC47CE875AD48619BBB71B175_2_8-inputEl\"][name=\"string_175|????.00\"][duckcreekid=\"BaileesCustomerUnderwritingQuestionsInput.HydrantDistance\"]");

    // Source modules: Location | confidence=High score=125
    // v56 raw Tosca primary: Location | Call ISO | DuckCreekId
    public ILocator CallISO => _page.Locator("[duckcreekid=\"Call ISO\"], [data-duckcreekid=\"Call ISO\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator Carrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Carrier", Exact = true });

    // Source modules: Rating Groups | confidence=High score=95
    // v56 raw Tosca primary: Rating Groups | Cause Of Loss | DuckCreekId
    public ILocator CauseOfLoss => _page.Locator("[duckcreekid=\"RatingGroupInput.CauseOfLossType\"], [data-duckcreekid=\"RatingGroupInput.CauseOfLossType\"]");

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    // v56 raw Tosca primary: Endorsements|Designated Workplaces Exclusion | City* | DuckCreekId | frame=iframe
    public ILocator City => _page.FrameLocator("iframe").Locator("[duckcreekid=\"DesignatedWorkplace.City\"], [data-duckcreekid=\"DesignatedWorkplace.City\"]");

    // Source modules: GL OCP|Risk | confidence=High score=124
    // v56 raw Tosca primary: GL OCP|Risk | Class Code | attributes_fieldref
    public ILocator ClassCode => _page.Locator("[fieldref=\"CovOwnersContractorsOrPrincipalsInputNonShredded.ClassCode\"], [data-fieldref=\"CovOwnersContractorsOrPrincipalsInputNonShredded.ClassCode\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ClassCodeFrame => _page.GetByText("Class Code Frame", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ClassCodeFrameClassCodeWindow => _page.GetByText("Class Code Window", new() { Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v56 raw Tosca primary: Risk - Accounts Receivable | Classification of Risk % | Id+Name+DuckCreekId
    public ILocator ClassificationOfRisk => _page.Locator("input[id=\"f_c4FFD73A13C164B729C39A3F5C851102319_1_1-inputEl\"][name=\"int_19\"][duckcreekid=\"CovAccountsReceivableInput.ClassificationOfRisk\"]");

    // Source modules: BAP Endorsements | confidence=High score=125
    // v56 raw Tosca primary: BAP Endorsements | Click Add Endorsement | DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as AddEndorsement04BD0
    public ILocator ClickAddEndorsement => AddEndorsement04BD0;

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Click Add Excluded Driver | Id+DuckCreekId | frame=iframe
    public ILocator ClickAddExcludedDriver => _page.FrameLocator("iframe").Locator("a[id=\"ext-element-14\"][duckcreekid=\"Add Excluded Driver\"]");

    // Source modules: Client|Named Insured|Common | confidence=High score=127
    // v56 raw Tosca primary:  | Add Client | DuckCreekId | frame=iframe
    public ILocator Client070F4 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Add Client\"], [data-duckcreekid=\"Add Client\"]");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary:  | Add Client | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as Client070F4
    public ILocator Client35F85 => Client070F4;

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Computer Systems | Coinsurance | Id+Name+DuckCreekId
    public ILocator Coinsurance01AB1 => _page.Locator("input[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F83_3_4-inputEl\"][name=\"f_c6288916FEC0548A5901DE1B09AA88FC2F83_3_4-inputEl\"][duckcreekid=\"ComputerSystemsInput.Coinsurance\"]");

    // Source modules: Rating Groups | confidence=High score=125
    public ILocator Coinsurance6348B => Coinsurance01AB1; // semantic alias; locator defined once

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator CoinsuranceC9726 => Coinsurance01AB1; // semantic alias; locator defined once

    // Source modules: State Details|Drive Other Car | confidence=High score=124
    // v56 raw Tosca primary: State Details|Drive Other Car | Collision | attributes_fieldref
    public ILocator Collision => _page.Locator("[fieldref=\"CovDriveOtherCarCollisionInput.Indicator\"], [data-fieldref=\"CovDriveOtherCarCollisionInput.Indicator\"]");

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=125
    // v56 raw Tosca primary: Risk Schedule|Physical Damage | Collision Coverage | Id+Name+DuckCreekId
    public ILocator CollisionCoverage => _page.Locator("input[id=\"f_c7D7AC70D2F5B46AE89DB2111B306EB762349_2_1-inputEl\"][name=\"f_c7D7AC70D2F5B46AE89DB2111B306EB762349_2_1-inputEl\"][duckcreekid=\"CovCollisionInput.AcceptCollisionCoverage\"]");

    // Source modules: State Details|Drive Other Car | confidence=High score=125
    // v56 raw Tosca primary: State Details|Drive Other Car | Collision Deductible | DuckCreekId
    public ILocator CollisionDeductible63D4C => _page.Locator("[duckcreekid=\"CovDriveOtherCarCollisionInput.Deductible\"], [data-duckcreekid=\"CovDriveOtherCarCollisionInput.Deductible\"]");

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=125
    // v56 raw Tosca primary: State Details|Hired Auto PD Without Driver | Collision Deductible* | DuckCreekId
    public ILocator CollisionDeductible9C100 => _page.Locator("[duckcreekid=\"CovHiredAndBorrowedCollisionInput.Deductible\"], [data-duckcreekid=\"CovHiredAndBorrowedCollisionInput.Deductible\"]");

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=125
    public ILocator CollisionDeductibleAEEBB => CollisionDeductible9C100; // semantic alias; locator defined once

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=124
    // v56 raw Tosca primary: State Details|Hired Auto PD Without Driver | Collision If Any | attributes_fieldref
    public ILocator CollisionIfAny7532D => _page.Locator("[fieldref=\"CovHiredAndBorrowedCollisionInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedCollisionInput.IfAny\"]");

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=124
    public ILocator CollisionIfAny8AEE8 => CollisionIfAny7532D; // semantic alias; locator defined once

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator CommercialAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Commercial Auto", Exact = true });

    // Source modules: Commercial Auto | confidence=High score=97
    // v56 raw Tosca primary: Commercial Auto | Commercial Auto Detail | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator CommercialAutoDetail => AccountsReceivableHeading;

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=97
    // v56 raw Tosca primary: Risk Schedule|Vehicle Information | Commercial Auto Risk Detail | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator CommercialAutoRiskDetail => AccountsReceivableHeading;

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator CommonNavigationLinksNext => _page.GetByRole(AriaRole.Link, new() { Name = "Next", Exact = true });

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    public ILocator CommonOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: State Details|Main | confidence=High score=95
    // v56 raw Tosca primary: State Details|Main | Company Name* | DuckCreekId
    public ILocator CompanyName => _page.Locator("[duckcreekid=\"WaiverCompanyName.CompanyName\"], [data-duckcreekid=\"WaiverCompanyName.CompanyName\"]");

    // Source modules: State Details|Drive Other Car | confidence=High score=124
    // v56 raw Tosca primary: State Details|Drive Other Car | Comprehensive | attributes_fieldref
    public ILocator Comprehensive => _page.Locator("[fieldref=\"CovDriveOtherCarOTCInput.Indicator\"], [data-fieldref=\"CovDriveOtherCarOTCInput.Indicator\"]");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Risk - Computer Systems | Computer Equipment | Id+Name+DuckCreekId
    public ILocator ComputerEquipment => _page.Locator("input[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB1C_1_1-inputEl\"][name=\"int_C\"][duckcreekid=\"CovComputerSystemsInput.ComputerEquipment\"]");

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: IM Navigation Links | Computer Systems UW Questions | Id
    public ILocator ComputerSystemsUWQuestions => _page.Locator("[id=\"ext-element-4168\"]");

    // Source modules: Building - Detail | confidence=High score=125
    // v56 raw Tosca primary: Building - Detail | Construction | Id+Name+DuckCreekId
    public ILocator Construction39800 => _page.Locator("input[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D023F_3_1-inputEl\"][name=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D023F_3_1-inputEl\"][duckcreekid=\"BuildingInput.ConstructionCode\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator ConstructionCD2DE => Construction39800; // semantic alias; locator defined once

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Risk - Computer Systems | Construction Code | Id+Name+DuckCreekId
    public ILocator ConstructionCode => _page.Locator("input[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB114_1_1-inputEl\"][name=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB114_1_1-inputEl\"][duckcreekid=\"CovComputerSystemsInput.ConstructionCode\"]");

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator ConstructionFB8D9 => Construction39800; // semantic alias; locator defined once

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=97
    // v56 raw Tosca primary: Specific Underwriting Questions - Contractors Equipment | Contractors Equipment Heading | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator ContractorsEquipmentHeading => AccountsReceivableHeading;

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: IM Navigation Links | Contractors Equipment UW Questions | Id
    public ILocator ContractorsEquipmentUWQuestions => _page.Locator("[id=\"ext-element-4169\"]");

    // Source modules: Risk Schedule|General Coverage | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|General Coverage | Coverage begin date: | DuckCreekId
    public ILocator CoverageBeginDate => _page.Locator("[duckcreekid=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.PeriodOfOperationsFrom\"], [data-duckcreekid=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.PeriodOfOperationsFrom\"]");

    // Source modules: Risk Schedule|General Coverage | confidence=High score=125
    // v56 raw Tosca primary: Risk Schedule|General Coverage | Coverage end date: | DuckCreekId
    public ILocator CoverageEndDate => _page.Locator("[duckcreekid=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.PeriodOfOperationsTo\"], [data-duckcreekid=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.PeriodOfOperationsTo\"]");

    // Source modules: Policy Covg|GL | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg|GL | Coverage Form | DuckCreekId
    public ILocator CoverageForm3B382 => _page.Locator("[duckcreekid=\"LineInput.PolicyType\"], [data-duckcreekid=\"LineInput.PolicyType\"]");

    // Source modules: Policy Covg - Signs | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Signs | Coverage Form | Id+DuckCreekId
    public ILocator CoverageFormA7F96 => _page.Locator("div[id=\"f_cAFD1AA97819C467694F348BB5BA65F85E45_3_6-inputEl\"][duckcreekid=\"Coverage Form\"]");

    // Source modules: Risk - Main | confidence=High score=125
    public ILocator CoverageFormCFDD1 => CoverageForm3B382; // semantic alias; locator defined once

    // Source modules: Policy Covg - Computer Systems | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg - Computer Systems | Coverage Form Display | Id+DuckCreekId
    public ILocator CoverageFormDisplay2ECD4 => _page.Locator("div[id=\"f_iB27E9D1A7BBB4CC688DAC59E11C5C2DED60_3_4-inputEl\"][duckcreekid=\"Coverage Form Display\"]");

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=95
    public ILocator CoverageFormDisplay6F446 => CoverageFormDisplay2ECD4; // semantic alias; locator defined once

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=95
    public ILocator CoverageFormDisplayB69C2 => CoverageFormDisplay2ECD4; // semantic alias; locator defined once

    // Source modules: Policy Covg - Signs | confidence=High score=95
    public ILocator CoverageFormDisplayC10BA => CoverageFormDisplay2ECD4; // semantic alias; locator defined once

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=95
    public ILocator CoverageFormDisplayD1A9B => CoverageFormDisplay2ECD4; // semantic alias; locator defined once

    // Source modules: Policy Covg - Main | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Main | Coverage Form To Be Added | Id+Name+DuckCreekId
    public ILocator CoverageFormToBeAdded => _page.Locator("input[id=\"f_l1A9C547373A24FF38DA9C54C82FB349811CE_3_1-inputEl\"][name=\"f_l1A9C547373A24FF38DA9C54C82FB349811CE_3_1-inputEl\"][duckcreekid=\"LineInput.CoverageForm\"]");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Motor Truck Cargo | Coverage Type | Id+Name+DuckCreekId
    public ILocator CoverageType => _page.Locator("input[id=\"f_cB85F41925276456C81E1ED1306A2AB401072_3_5-inputEl\"][name=\"f_cB85F41925276456C81E1ED1306A2AB401072_3_5-inputEl\"][duckcreekid=\"MotorTruckCargoInput.CoverageForm\"]");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg - Motor Truck Cargo | Covered Property Consisting Principally of: | attributes_fieldref
    public ILocator CoveredPropertyConsistingPrincipallyOf => _page.Locator("[fieldref=\"MotorTruckCargoInput.Description\"], [data-fieldref=\"MotorTruckCargoInput.Description\"]");

    // Source modules: Property Enter Building RCT | confidence=High score=125
    // v56 raw Tosca primary: Property Enter Building RCT | Create Valuation | DuckCreekId
    public ILocator CreateValuation => _page.Locator("[duckcreekid=\"Create Valuation\"], [data-duckcreekid=\"Create Valuation\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | d. What is the distance in miles to the nearest responding fire department? | Id+Name+DuckCreekId
    public ILocator DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment => _page.Locator("input[id=\"f_b90770E4D06DC47CE875AD48619BBB71B178_2_8-inputEl\"][name=\"string_178|????.00\"][duckcreekid=\"BaileesCustomerUnderwritingQuestionsInput.FireDeptDistance\"]");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Risk - Computer Systems | Data And Media | Id+Name+DuckCreekId
    public ILocator DataAndMedia => _page.Locator("input[id=\"f_c3EF1D09EE0E84AB189A6366AD3F277B2D_1_1-inputEl\"][name=\"int_D\"][duckcreekid=\"CovComputerSystemsInput.DataAndMedia\"]");

    // Source modules:  | confidence=High score=125
    // v56 raw Tosca primary:  | Date Of Birth* | Id+Name+DuckCreekId | frame=iframe
    public ILocator DateOfBirth => _page.FrameLocator("iframe").Locator("input[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010CF_1_1-inputEl\"][name=\"date_10CF|mm-dd-yyyy\"][duckcreekid=\"DriverUnderwritingInformationInput.DateOfBirth\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Date Of Hire | Id+Name+DuckCreekId | frame=iframe
    public ILocator DateOfHire => _page.FrameLocator("iframe").Locator("input[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D6_1_1-inputEl\"][name=\"date_10D6|mm-dd-yyyy\"][duckcreekid=\"DriverUnderwritingInformationInput.DateOfHire\"]");

    // Source modules: Property - Main | confidence=High score=95
    // v56 raw Tosca primary: Property - Main | Debris Removal Additional | DuckCreekId
    public ILocator DebrisRemovalAdditional => _page.Locator("[duckcreekid=\"BuildingInput.DebrisRemoval\"], [data-duckcreekid=\"BuildingInput.DebrisRemoval\"]");

    // Source modules: Property - Main | confidence=High score=95
    // v56 raw Tosca primary: Property - Main | Debris Removal Additional Limit | DuckCreekId
    public ILocator DebrisRemovalAdditionalLimit => _page.Locator("[duckcreekid=\"BuildingInput.DebrisRemovalLimit\"], [data-duckcreekid=\"BuildingInput.DebrisRemovalLimit\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Ded Type | DuckCreekId
    public ILocator DedType => _page.Locator("[duckcreekid=\"LineInput.DeductibleType\"], [data-duckcreekid=\"LineInput.DeductibleType\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Computer Systems | Dedicated line?* | Id+Name+DuckCreekId
    public ILocator DedicatedLine => _page.Locator("input[id=\"f_c7FA512A090F641B9A6BB95F4C656EE1841_2_21-inputEl\"][name=\"f_c7FA512A090F641B9A6BB95F4C656EE1841_2_21-inputEl\"][duckcreekid=\"ComputerSystemsUnderwritingQuestionsInput.DedicatedLineIndicator\"]");

    // Source modules: Rating Groups | confidence=High score=125
    // v56 raw Tosca primary: Rating Groups | Deductible | DuckCreekId
    public ILocator Deductible01AB9 => _page.Locator("[duckcreekid=\"RatingGroupInput.Deductible\"], [data-duckcreekid=\"RatingGroupInput.Deductible\"]");

    // Source modules: Endorsement - IF 00 02 Waterborne Equipment | confidence=High score=125
    public ILocator Deductible0CC0A => Deductible01AB9; // semantic alias; locator defined once

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    public ILocator Deductible320C9 => Deductible01AB9; // semantic alias; locator defined once

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator Deductible59155 => Deductible01AB9; // semantic alias; locator defined once

    // Source modules: Building - Detail | confidence=High score=125
    public ILocator Deductible592D9 => Deductible01AB9; // semantic alias; locator defined once

    // Source modules: State Details|Main | confidence=High score=125
    // IA Only
    public ILocator Deductible5F45D => Deductible01AB9; // semantic alias; locator defined once

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Deductible Basis | DuckCreekId
    public ILocator DeductibleBasis => _page.Locator("[duckcreekid=\"LineInput.DeductibleScope\"], [data-duckcreekid=\"LineInput.DeductibleScope\"]");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator DeductibleC227C => Deductible01AB9; // semantic alias; locator defined once

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    public ILocator DeductibleC91E9 => Deductible01AB9; // semantic alias; locator defined once

    // Source modules: Building - Detail | confidence=High score=95
    // v56 raw Tosca primary: Building - Detail | Deductible Increased Theft | Id+Name+DuckCreekId
    public ILocator DeductibleIncreasedTheft99E5F => _page.Locator("input[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0263_3_1-inputEl\"][name=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0263_3_1-inputEl\"][duckcreekid=\"BuildingInput.DeductibleIncreasedTheft\"]");

    // Source modules: Rating Groups | confidence=High score=95
    public ILocator DeductibleIncreasedTheftF76DB => DeductibleIncreasedTheft99E5F; // semantic alias; locator defined once

    // Source modules: Building - Detail | confidence=High score=95
    // v56 raw Tosca primary: Building - Detail | Deductible Wind Hail | Id+Name+DuckCreekId
    public ILocator DeductibleWindHail911AF => _page.Locator("input[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0265_3_1-inputEl\"][name=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0265_3_1-inputEl\"][duckcreekid=\"BuildingInput.DeductibleWindHail\"]");

    // Source modules: Rating Groups | confidence=High score=95
    public ILocator DeductibleWindHailAB1C3 => DeductibleWindHail911AF; // semantic alias; locator defined once

    // Source modules: Policy Covg | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg | Default Exp Mod Type | DuckCreekId
    public ILocator DefaultExpModType => _page.Locator("[duckcreekid=\"LineInput.ModType\"], [data-duckcreekid=\"LineInput.ModType\"]");

    // Source modules: Policy Covg | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg | Default Experience Mod | DuckCreekId
    public ILocator DefaultExperienceMod => _page.Locator("[duckcreekid=\"LineInput.ExperienceModifier\"], [data-duckcreekid=\"LineInput.ExperienceModifier\"]");

    // Source modules: General Liability Information | confidence=High score=124
    // v56 raw Tosca primary: General Liability Information | Describe all hold harmless agreements and please provide a copy. | attributes_fieldref
    public ILocator DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy => _page.Locator("[fieldref=\"GeneralLiabilityInput.Description\"], [data-fieldref=\"GeneralLiabilityInput.Description\"]");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Contractors Equipment | Description* | Id+Name+DuckCreekId
    public ILocator Description03789 => _page.Locator("input[id=\"f_i2B400B3B804E4D9EA12FE1D96F9ADFC6D62_3_1-inputEl\"][name=\"string_D62|\"][duckcreekid=\"CoverageFormsInput.Description\"]");

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=125
    public ILocator Description43F2D => Description03789; // semantic alias; locator defined once

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    public ILocator Description58EC2 => Description03789; // semantic alias; locator defined once

    // Source modules: Rating Groups | confidence=High score=125
    // v56 raw Tosca primary: Rating Groups | Description | DuckCreekId
    public ILocator Description8A08D => _page.Locator("[duckcreekid=\"RatingGroupInput.Description\"], [data-duckcreekid=\"RatingGroupInput.Description\"]");

    // Source modules: Policy Covg - Signs | confidence=High score=125
    public ILocator DescriptionBE47E => Description03789; // semantic alias; locator defined once

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    public ILocator DescriptionF8E60 => Description03789; // semantic alias; locator defined once

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    // v56 raw Tosca primary: Policy Coverage|Business Interruption | Description Of Business Activites* | DuckCreekId
    public ILocator DescriptionOfBusinessActivites => _page.Locator("[duckcreekid=\"BusinessInterruptionEndorsementInput.DescriptionOfBusinessActivites\"], [data-duckcreekid=\"BusinessInterruptionEndorsementInput.DescriptionOfBusinessActivites\"]");

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=124
    // v56 raw Tosca primary: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Description of Operation(s) | attributes_fieldref
    public ILocator DescriptionOfOperationS => _page.Locator("[fieldref=\"CovEndorsementsInput.Description\"], [data-fieldref=\"CovEndorsementsInput.Description\"]");

    // Source modules: [CG2812] Pesticide or Herbicide Applicator Coverage | confidence=High score=124
    // v56 raw Tosca primary: [CG2812] Pesticide or Herbicide Applicator Coverage | Description of Operations | attributes_fieldref
    // v56 semantic alias: same physical raw-Tosca control as DescriptionOfOperationS
    public ILocator DescriptionOfOperations => DescriptionOfOperationS;

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator DescriptionOfSpecifiedOperation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Specified Operation", Exact = true });

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    public ILocator DesignatedWorkplacesExclusionOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    // v56 raw Tosca primary:  | Detail | DuckCreekId | frame=iframe
    public ILocator Detail0F8C6 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Detail\"], [data-duckcreekid=\"Detail\"]");

    // Source modules: Building - Main | confidence=High score=125
    public ILocator Detail10932 => Detail0F8C6; // semantic alias; locator defined once

    // Source modules: Risk Aggregate | confidence=High score=125
    public ILocator Detail1664B => Detail0F8C6; // semantic alias; locator defined once

    // Source modules: Entity Schedule|First Entity Info | confidence=High score=125
    public ILocator Detail238D5 => Detail0F8C6; // semantic alias; locator defined once

    // Source modules: Location | confidence=High score=125
    public ILocator Detail33F0D => Detail0F8C6; // semantic alias; locator defined once

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    public ILocator Detail4A746 => Detail0F8C6; // semantic alias; locator defined once

    // Source modules: Property Enter Building RCT | confidence=High score=125
    public ILocator Detail7F662 => Detail0F8C6; // semantic alias; locator defined once

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Do you have a CDL license?* | Id+Name+DuckCreekId | frame=iframe
    public ILocator DoYouHaveACDLLicense => _page.FrameLocator("iframe").Locator("input[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D01119_1_1-inputEl\"][name=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D01119_1_1-inputEl\"][duckcreekid=\"DriverUnderwritingInformationInput.HaveCDLLicense\"]");

    // Source modules: Policy Covg | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg | Does any Risk generate power other than Private Windmills or Emergency Backup?* | DuckCreekId
    public ILocator DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup => _page.Locator("[duckcreekid=\"PolicyInput.AnyRiskPowerUnitOtherThanWindmillOrBackup\"], [data-duckcreekid=\"PolicyInput.AnyRiskPowerUnitOtherThanWindmillOrBackup\"]");

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Signs | Does the applicant wish to cover any signs inside their premises? | Id+Name+DuckCreekId
    public ILocator DoesTheApplicantWishToCoverAnySignsInsideTheirPremises => _page.Locator("input[id=\"f_s5879EFE3310C457293652ECABD56DCF11D_2_2-inputEl\"][name=\"f_s5879EFE3310C457293652ECABD56DCF11D_2_2-inputEl\"][duckcreekid=\"SignsUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    // v56 raw Tosca primary: [FG 00 13] Automatic Additional Insured - Specific Relationship | Does the insured/applicant request Additional Insured status without a written contract requirement? | attributes_fieldref
    public ILocator DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionG\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionG\"]");

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    // v56 raw Tosca primary: [FG 00 13] Automatic Additional Insured - Specific Relationship | Does the insured enter into contracts involving Commercial Snow Removal, including snow removal from residential roofs? | attributes_fieldref
    public ILocator DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionH\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionH\"]");

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    // v56 raw Tosca primary: [FG 00 13] Automatic Additional Insured - Specific Relationship | Does the insured ever enter into contracts for tasks not contemplated in the current liability classifications on the policy? | attributes_fieldref
    public ILocator DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionF\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionF\"]");

    // Source modules: State Details|Drive Other Car | confidence=High score=124
    // v56 raw Tosca primary: State Details|Drive Other Car | Drive Other Car | attributes_fieldref
    public ILocator DriveOtherCar => _page.Locator("[fieldref=\"LineStateInput.DriveOtherCarCoverage\"], [data-fieldref=\"LineStateInput.DriveOtherCarCoverage\"]");

    // Source modules:  | confidence=High score=97
    // v56 raw Tosca primary:  | Driver Detail | Id | frame=iframe
    public ILocator DriverDetail => _page.FrameLocator("iframe").Locator("[id=\"pageTop\"]");

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Driver Schedule | Driver Schedule | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator DriverSchedule161DF => AccountsReceivableHeading;

    // Source modules: Driver Schedule | confidence=High score=127
    // v56 raw Tosca primary: Driver Schedule | Driver Schedule | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator DriverSchedule79DC6 => AccountsReceivableHeading;

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Drivers License Number* | DuckCreekId | frame=iframe
    public ILocator DriversLicenseNumber => _page.FrameLocator("iframe").Locator("[duckcreekid=\"DriverUnderwritingInformationInput.DriversLicenseNumber\"], [data-duckcreekid=\"DriverUnderwritingInformationInput.DriversLicenseNumber\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | Dry Cleaning % | Id+Name+DuckCreekId
    public ILocator DryCleaning => _page.Locator("input[id=\"f_b71504B515DF24669A165EFFA75C7935615D_2_1-inputEl\"][name=\"int_15D\"][duckcreekid=\"BaileesCustomerPrincipalWorkUnderwritingQuestionsInput.Percent\"]");

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v56 raw Tosca primary: Risk - Accounts Receivable | % Duplicated Records | Id+Name+DuckCreekId
    public ILocator DuplicatedRecords => _page.Locator("input[id=\"f_c4FFD73A13C164B729C39A3F5C851102318_1_1-inputEl\"][name=\"int_18\"][duckcreekid=\"CovAccountsReceivableInput.DuplicateRecords\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | e. Are no smoking rules posted and enforced? | Id+Name+DuckCreekId
    public ILocator EAreNoSmokingRulesPostedAndEnforced => _page.Locator("input[id=\"f_b90770E4D06DC47CE875AD48619BBB71B17B_2_8-inputEl\"][name=\"f_b90770E4D06DC47CE875AD48619BBB71B17B_2_8-inputEl\"][duckcreekid=\"BaileesCustomerUnderwritingQuestionsInput.SmokingRulesIndicator\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | E-Mail | DuckCreekId | frame=iframe
    public ILocator EMail => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.Email\"], [data-duckcreekid=\"AdditionalOtherInterestInput.Email\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v56 raw Tosca primary: Risk - Bailees Customers | Earthquake | Id+Name+DuckCreekId
    public ILocator Earthquake => _page.Locator("input[id=\"f_c1130867FA0E9485FBAA81AF5875174089A_1_1-inputEl\"][name=\"f_c1130867FA0E9485FBAA81AF5875174089A_1_1-inputEl\"][duckcreekid=\"CovBaileesCustomersInput.Earthquake\"]");

    // Source modules: Billing | confidence=High score=125
    public ILocator EasyPay => _page.GetByRole(AriaRole.Textbox, new() { Name = "Easy Pay", Exact = true });

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    // v56 raw Tosca primary: SFP - 10 Liability/Farm | Effective Date | DuckCreekId | frame=iframe
    public ILocator EffectiveDate0E335 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"UmbrellaSFP10LiabilityInput.EffectiveDate\"], [data-duckcreekid=\"UmbrellaSFP10LiabilityInput.EffectiveDate\"]");

    // Source modules: Commercial Auto | confidence=High score=125
    public ILocator EffectiveDate68A1B => EffectiveDate0E335; // semantic alias; locator defined once

    // Source modules: Businessowners | confidence=High score=125
    public ILocator EffectiveDate6CF3D => EffectiveDate0E335; // semantic alias; locator defined once

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    // v56 raw Tosca primary: Employers Liability | Effective Date | DuckCreekId | frame=iframe
    public ILocator EffectiveDate95094 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"UmbrellaEmployersLiabilityInput.EffectiveDate\"], [data-duckcreekid=\"UmbrellaEmployersLiabilityInput.EffectiveDate\"]");

    // Source modules: General Liability | confidence=High score=125
    public ILocator EffectiveDateB3600 => EffectiveDate0E335; // semantic alias; locator defined once

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator EffectiveDateB557F => EffectiveDate0E335; // semantic alias; locator defined once

    // Source modules: Building - Detail | confidence=High score=95
    // v56 raw Tosca primary: Building - Detail | Eligible For Enhanced Wind Rating Program | Id+Name+DuckCreekId
    public ILocator EligibleForEnhancedWindRatingProgram => _page.Locator("input[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D02BE_3_1-inputEl\"][name=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D02BE_3_1-inputEl\"][duckcreekid=\"BuildingInput.EligibleForEnhancedWindRatingProgram\"]");

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    // v56 raw Tosca primary: State Details|Hired Auto Liability | Employee Hired Autos CheckBox | attributes_fieldref
    public ILocator EmployeeHiredAutosCheckBox => _page.Locator("[fieldref=\"LineStateInput.EmployeeHiredAuto\"], [data-fieldref=\"LineStateInput.EmployeeHiredAuto\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator EmployersLiab => _page.GetByRole(AriaRole.Link, new() { Name = "Employers Liab", Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: IM Navigation Links | Accounts Receivable UW Questions | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableUWQuestions
    public ILocator Endorsement => AccountsReceivableUWQuestions;

    // Source modules: Endorsement - CM 66 01 Exclude Named Customer | confidence=High score=125
    public ILocator EndorsementCM6601ExcludeNamedCustomerOK => AddClassOK; // semantic alias; locator defined once

    // Source modules:  | confidence=High score=97
    // v56 raw Tosca primary:  | Endorsement Detail | Id | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as DriverDetail
    public ILocator EndorsementDetail => DriverDetail;

    // Source modules: Endorsement - Main | confidence=High score=97
    // v56 raw Tosca primary: Endorsement - Main |  Endorsement Heading | Id | frame=iframe
    public ILocator EndorsementHeading => _page.FrameLocator("iframe").Locator("[id=\"pageTitle\"]");

    // Source modules: Endorsement - IF 00 02 Waterborne Equipment | confidence=High score=125
    public ILocator EndorsementIF0002WaterborneEquipmentOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EndorsementScheduleRow1 => _page.GetByText("$1", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EndorsementTableRow1 => _page.GetByText("#1", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EndorsementTableRow2 => _page.GetByText("$2", new() { Exact = true });

    // Source modules: [CG2401] Non-Binding Arbitration | confidence=High score=125
    // v56 raw Tosca primary: [CG2401] Non-Binding Arbitration | Endorsement Type | DuckCreekId
    public ILocator EndorsementType3503E => _page.Locator("[duckcreekid=\"CovEndorsementsInput.Type\"], [data-duckcreekid=\"CovEndorsementsInput.Type\"]");

    // Source modules: BAP Endorsements | confidence=High score=125
    public ILocator EndorsementType624AD => EndorsementType3503E; // semantic alias; locator defined once

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    public ILocator EndorsementType8DB33 => EndorsementType3503E; // semantic alias; locator defined once

    // Source modules: [CG0435] Employee Benefits Liability | confidence=High score=125
    public ILocator EndorsementTypeA2928 => EndorsementType3503E; // semantic alias; locator defined once

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    public ILocator EndorsementTypeAEC4F => EndorsementType3503E; // semantic alias; locator defined once

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=125
    public ILocator EndorsementTypeB210C => EndorsementType3503E; // semantic alias; locator defined once

    // Source modules: [CG2812] Pesticide or Herbicide Applicator Coverage | confidence=High score=125
    public ILocator EndorsementTypeC75E4 => EndorsementType3503E; // semantic alias; locator defined once

    // Source modules: [CG0424] Coverage for Injury to Leased Workers | confidence=High score=125
    public ILocator EndorsementTypeCE99F => EndorsementType3503E; // semantic alias; locator defined once

    // Source modules: [CG 2149] Total Pollution Exclusion Endorsement | confidence=High score=125
    public ILocator EndorsementTypeD83A4 => EndorsementType3503E; // semantic alias; locator defined once

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=125
    public ILocator EndorsementTypeF8D4A => EndorsementType3503E; // semantic alias; locator defined once

    // Source modules: GL Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Endorsements|Main | Endorsements | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator Endorsements7572E => AccountsReceivableHeading;

    // Source modules: Endorsements|Main | confidence=High score=127
    // v56 raw Tosca primary: Endorsements|Main | Endorsements | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator Endorsements9626E => AccountsReceivableHeading;

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator Endorsements9D4A5 => Endorsements7572E; // semantic alias; locator defined once

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator EndorsementsB76E9 => Endorsements7572E; // semantic alias; locator defined once

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    public ILocator EndorsementsC27F0 => Endorsements7572E; // semantic alias; locator defined once

    // Source modules: Endorsements - Main Screen | confidence=High score=127
    // v56 raw Tosca primary: Endorsements - Main Screen | Endorsements Heading | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator EndorsementsHeading8FD33 => AccountsReceivableHeading;

    // Source modules: BAP Endorsement Schedule | confidence=High score=127
    public ILocator EndorsementsHeadingA3D50 => EndorsementsHeading8FD33; // semantic alias; locator defined once

    // Source modules: Risk Schedule|General Coverage | confidence=High score=95
    // Only Applicable to Golf Carts
    // v56 raw Tosca primary: Risk Schedule|General Coverage | Engine Size (cc)* | DuckCreekId
    public ILocator EngineSizeCc => _page.Locator("[duckcreekid=\"RiskCommercialAutoRiskInput.EngineSizeCC\"], [data-duckcreekid=\"RiskCommercialAutoRiskInput.EngineSizeCC\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EntityInfoFrame => _page.GetByText("Entity Info Frame", new() { Exact = true });

    // Source modules: Entity Schedule|Main | confidence=High score=127
    // v56 raw Tosca primary: Entity Schedule|Main | Entity Schedule | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator EntityScheduleE6C9F => AccountsReceivableHeading;

    // Source modules: WC Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Entity Schedule|Main | Entity Schedule | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator EntityScheduleEA671 => AccountsReceivableHeading;

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Contractors Equipment | Estimated Highest Value | Id+Name+DuckCreekId
    public ILocator EstimatedHighestValue => _page.Locator("input[id=\"f_c43D7743D9BD44829A7C9322C2ACC793C55_2_1-inputEl\"][name=\"int_55\"][duckcreekid=\"ContractorsEquipmentUnderwritingQuestionsInput.HighestValue\"]");

    // Source modules: Property Enter Building RCT | confidence=High score=125
    // v56 raw Tosca primary: Property Enter Building RCT | Estimator Type* | DuckCreekId
    public ILocator EstimatorType => _page.Locator("[duckcreekid=\"BuildingValuatioinInput.EstimatorType\"], [data-duckcreekid=\"BuildingValuatioinInput.EstimatorType\"]");

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    // v56 raw Tosca primary: State Details|Hired Auto Liability | Excess Liability If Any | Id+Name
    public ILocator ExcessLiabilityIfAny => _page.Locator("input[id=\"f_cFD7A5C8A01734A08BFE216326E23EB102246_1_1-inputEl\"][name=\"boolean_2246\"]");

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=124
    // v56 raw Tosca primary: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Exclude Collapse Hazard | attributes_fieldref
    public ILocator ExcludeCollapseHazard => _page.Locator("[fieldref=\"CovEndorsementsInput.IndicatorCollapseCG2142\"], [data-fieldref=\"CovEndorsementsInput.IndicatorCollapseCG2142\"]");

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=124
    // v56 raw Tosca primary: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Exclude Explosion Hazard | attributes_fieldref
    public ILocator ExcludeExplosionHazard => _page.Locator("[fieldref=\"CovEndorsementsInput.IndicatorExplosionCG2142\"], [data-fieldref=\"CovEndorsementsInput.IndicatorExplosionCG2142\"]");

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=124
    // v56 raw Tosca primary: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Exclude Underground Property Damage Hazard | attributes_fieldref
    public ILocator ExcludeUndergroundPropertyDamageHazard => _page.Locator("[fieldref=\"CovEndorsementsInput.IndicatorPropertyDamageCG2142\"], [data-fieldref=\"CovEndorsementsInput.IndicatorPropertyDamageCG2142\"]");

    // Source modules: Policy Covg | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg | Excluded Liability - Confidential Information* | DuckCreekId
    public ILocator ExcludedLiabilityConfidentialInformation => _page.Locator("[duckcreekid=\"CovConfidentialInfoLiabilityInput.FormSelection\"], [data-duckcreekid=\"CovConfidentialInfoLiabilityInput.FormSelection\"]");

    // Source modules: State Details|Experience Rated | confidence=High score=95
    // v56 raw Tosca primary: State Details|Experience Rated | Experience Mod Type* | DuckCreekId
    public ILocator ExperienceModType => _page.Locator("[duckcreekid=\"ExperienceModInput.ModType\"], [data-duckcreekid=\"ExperienceModInput.ModType\"]");

    // Source modules: Policy Covg | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg | Experience Rated | DuckCreekId
    public ILocator ExperienceRated => _page.Locator("[duckcreekid=\"LineInput.ExperienceRatedIndicator\"], [data-duckcreekid=\"LineInput.ExperienceRatedIndicator\"]");

    // Source modules: State Details|Experience Rated | confidence=High score=95
    // v56 raw Tosca primary: State Details|Experience Rated | Experience Rating Options | DuckCreekId
    public ILocator ExperienceRatingOptions => _page.Locator("[duckcreekid=\"LineStateTermInput.ExperienceRatingOptions\"], [data-duckcreekid=\"LineStateTermInput.ExperienceRatingOptions\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    // v56 raw Tosca primary: Employers Liability | Expiration Date | DuckCreekId
    public ILocator ExpirationDate34EAC => _page.Locator("[duckcreekid=\"UmbrellaEmployersLiabilityInput.ExpirationDate\"], [data-duckcreekid=\"UmbrellaEmployersLiabilityInput.ExpirationDate\"]");

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    public ILocator ExpirationDate664A1 => ExpirationDate34EAC; // semantic alias; locator defined once

    // Source modules: Businessowners | confidence=High score=125
    public ILocator ExpirationDate82561 => ExpirationDate34EAC; // semantic alias; locator defined once

    // Source modules: General Liability | confidence=High score=125
    public ILocator ExpirationDateB437C => ExpirationDate34EAC; // semantic alias; locator defined once

    // Source modules: CGL|Main Page | confidence=High score=125
    // v56 raw Tosca primary: CGL|Main Page | Exposure | DuckCreekId
    public ILocator Exposure => _page.Locator("[duckcreekid=\"RiskGeneralLiabilityInput.UnitsOfExposureEstimated\"], [data-duckcreekid=\"RiskGeneralLiabilityInput.UnitsOfExposureEstimated\"]");

    // Source modules: Policy Coverage|NonOwned | confidence=High score=124
    // v56 raw Tosca primary: Policy Coverage|NonOwned | Extended Employee Coverage | Id+Name
    public ILocator ExtendedEmployeeCoverage => _page.Locator("input[id=\"f_r833047D99DE246ABBC46A28BC930EF1919E_3_1-inputEl\"][name=\"f_r833047D99DE246ABBC46A28BC930EF1919E_3_1-inputEl\"]");

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Computer Systems | Extra Expense | Id+Name+DuckCreekId
    public ILocator ExtraExpense => _page.Locator("input[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8C_3_4-inputEl\"][name=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8C_3_4-inputEl\"][duckcreekid=\"ComputerSystemsInput.ExtraExpenseIndicator\"]");

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=125
    public ILocator FG0013AutomaticAdditionalInsuredSpecificRelationshipOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Location | confidence=High score=125
    // v56 raw Tosca primary: Location | Feet From Hydrant | DuckCreekId
    public ILocator FeetFromHydrant => _page.Locator("[duckcreekid=\"LocationInput.FeetFromHydrant\"], [data-duckcreekid=\"LocationInput.FeetFromHydrant\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Fire Damage | DuckCreekId
    public ILocator FireDamage => _page.Locator("[duckcreekid=\"CovFireDamageInput.FireDamage\"], [data-duckcreekid=\"CovFireDamageInput.FireDamage\"]");

    // Source modules: State Details|Drive Other Car | confidence=High score=125
    // v56 raw Tosca primary: State Details|Drive Other Car | First Name | DuckCreekId | frame=iframe
    public ILocator FirstName5059E => _page.FrameLocator("iframe").Locator("[duckcreekid=\"RiskDriveOtherCarIteratorInput.FirstName\"], [data-duckcreekid=\"RiskDriveOtherCarIteratorInput.FirstName\"]");

    // Source modules:  | confidence=High score=125
    // v56 raw Tosca primary:  | First Name* | Id+Name+DuckCreekId | frame=iframe
    public ILocator FirstName813D1 => _page.FrameLocator("iframe").Locator("input[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010C8_1_1-inputEl\"][name=\"string_10C8|\"][duckcreekid=\"DriverUnderwritingInformationInput.Name\"]");

    // Source modules: Risk Schedule|Risk Specific | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Risk Specific | GCW* | DuckCreekId
    public ILocator GCW => _page.Locator("[duckcreekid=\"RiskTruckInput.GCW\"], [data-duckcreekid=\"RiskTruckInput.GCW\"]");

    // Source modules: Policy Info|CPP Specific Fields | confidence=High score=95
    // CPP Only
    // v56 raw Tosca primary: Policy Info|CPP Specific Fields | GL Detail | DuckCreekId
    public ILocator GLDetail => _page.Locator("[duckcreekid=\"Detail\"], [data-duckcreekid=\"Detail\"]");

    // Source modules: GL Navigation Links | confidence=Medium score=113
    public ILocator GLUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "GL UW Questions", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator GeneralLiab => _page.GetByRole(AriaRole.Link, new() { Name = "General Liab", Exact = true });

    // Source modules: General Liability | confidence=High score=97
    // v56 raw Tosca primary: General Liability | General Liability | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator GeneralLiability => AccountsReceivableHeading;

    // Source modules: General Liability Information | confidence=High score=97
    // v56 raw Tosca primary: General Liability Information | General Liability Information | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator GeneralLiabilityInformation => AccountsReceivableHeading;

    // Source modules: General Liability Information | confidence=High score=125
    public ILocator GeneralLiabilityInformationOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Underwriting Info | General UW Questions | confidence=High score=127
    public ILocator GeneralUWQuestions => _page.GetByLabel("General UW Questions", new() { Exact = true });

    // Source modules: Property Enter Building RCT | confidence=High score=125
    // v56 raw Tosca primary: Property Enter Building RCT | Get Calculated Value | DuckCreekId
    public ILocator GetCalculatedValue => _page.Locator("[duckcreekid=\"Get Calculated Value\"], [data-duckcreekid=\"Get Calculated Value\"]");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Motor Truck Cargo | Group Class | Id+Name+DuckCreekId
    public ILocator GroupClass => _page.Locator("input[id=\"f_cB85F41925276456C81E1ED1306A2AB401088_3_5-inputEl\"][name=\"f_cB85F41925276456C81E1ED1306A2AB401088_3_5-inputEl\"][duckcreekid=\"MotorTruckCargoInput.CarriersGroupClass\"]");

    // Source modules: Underwriting Questions | confidence=High score=125
    // v56 raw Tosca primary: Underwriting Questions | Has any applicant been convicted of a felony or been involved in any incidents or claims relating to sexual abuse or molestation allegations, discrimination, arson, fraud, bribery or negligent hiring | DuckCreekId
    public ILocator HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring => _page.Locator("[duckcreekid=\"UnderwritingQuestionsAutoInput.AnyFelonies\"], [data-duckcreekid=\"UnderwritingQuestionsAutoInput.AnyFelonies\"]");

    // Source modules: UW Questions - Umbrella | confidence=High score=95
    // v56 raw Tosca primary: UW Questions - Umbrella | Have you had any liability losses in the last 5 years on any primary or excess policy?* | DuckCreekId
    public ILocator HaveYouHadAnyLiabilityLossesInTheLast5YearsOnAnyPrimaryOrExcessPolicy => _page.Locator("[duckcreekid=\"UnderwritingQuestionsUmbrellaInput.AnyLiabilityLosses\"], [data-duckcreekid=\"UnderwritingQuestionsUmbrellaInput.AnyLiabilityLosses\"]");

    // Source modules: Client|Third Party Designee|Common | confidence=High score=97
    // v56 raw Tosca primary: Client|Third Party Designee|Common | Heading Third Party Designee | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator HeadingThirdPartyDesignee => AccountsReceivableHeading;

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Hired Auto | HiredAuto CA2001 Address1 | DuckCreekId
    public ILocator HiredAutoCA2001Address1 => _page.Locator("[duckcreekid=\"CovHiredAutoCA2001Input.Address1\"], [data-duckcreekid=\"CovHiredAutoCA2001Input.Address1\"]");

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Hired Auto | HiredAuto CA2001 First Name | DuckCreekId
    public ILocator HiredAutoCA2001FirstName => _page.Locator("[duckcreekid=\"CovHiredAutoCA2001Input.FirstName\"], [data-duckcreekid=\"CovHiredAutoCA2001Input.FirstName\"]");

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Hired Auto | HiredAuto CA2001 Last Name | DuckCreekId
    public ILocator HiredAutoCA2001LastName => _page.Locator("[duckcreekid=\"CovHiredAutoCA2001Input.LastName\"], [data-duckcreekid=\"CovHiredAutoCA2001Input.LastName\"]");

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Hired Auto | HiredAuto CA2001 ZipCode | DuckCreekId
    public ILocator HiredAutoCA2001ZipCode => _page.Locator("[duckcreekid=\"CovHiredAutoCA2001Input.ZipCode\"], [data-duckcreekid=\"CovHiredAutoCA2001Input.ZipCode\"]");

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=125
    // v56 raw Tosca primary: Risk Schedule|Hired Auto | Hired Auto Ext Addl Insured | DuckCreekId
    public ILocator HiredAutoExtAddlInsured => _page.Locator("[duckcreekid=\"CovLiabilityInput.HiredAutoExtAddlInsured\"], [data-duckcreekid=\"CovLiabilityInput.HiredAutoExtAddlInsured\"]");

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=125
    // v56 raw Tosca primary: Risk Schedule|Hired Auto | Hired Auto Form* | DuckCreekId
    public ILocator HiredAutoForm => _page.Locator("[duckcreekid=\"CovLiabilityInput.HiredAutoExtAddlInsuredForm\"], [data-duckcreekid=\"CovLiabilityInput.HiredAutoExtAddlInsuredForm\"]");

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    // v56 raw Tosca primary: State Details|Hired Auto Liability | Hired Auto Liability | Id+Name
    public ILocator HiredAutoLiability => _page.Locator("input[id=\"f_l1C943EEC18974B529C9A830C0627B0862240_1_1-inputEl\"][name=\"boolean_2240\"]");

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=125
    public ILocator HiredAutoOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=124
    // v56 raw Tosca primary: State Details|Hired Auto Physical Damage With Driver | Hired Auto Physical Damage With Driver | attributes_fieldref
    public ILocator HiredAutoPhysicalDamageWithDriver => _page.Locator("[fieldref=\"LineStateInput.HiredPhysicalDamageWithDriver\"], [data-fieldref=\"LineStateInput.HiredPhysicalDamageWithDriver\"]");

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=124
    // v56 raw Tosca primary: State Details|Hired Auto PD Without Driver | Hired Auto Physical Damage Without Driver | attributes_fieldref
    public ILocator HiredAutoPhysicalDamageWithoutDriver => _page.Locator("[fieldref=\"LineStateInput.HiredPhysicalDamage\"], [data-fieldref=\"LineStateInput.HiredPhysicalDamage\"]");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Contractors Equipment | Hired Equipment | Id+Name+DuckCreekId
    public ILocator HiredEquipment => _page.Locator("input[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FEE_3_1-inputEl\"][name=\"f_c48C85AB0259E43AE8BED26305EA4E022FEE_3_1-inputEl\"][duckcreekid=\"ContractorsEquipmentInput.HiredEquipmentIndicator\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    // v56 raw Tosca primary: Specific Underwriting Questions - Computer Systems | How often is data backed up? | attributes_fieldref
    public ILocator HowOftenIsDataBackedUp => _page.Locator("[fieldref=\"ComputerSystemsUnderwritingQuestionsInput.Description\"], [data-fieldref=\"ComputerSystemsUnderwritingQuestionsInput.Description\"]");

    // Source modules: Policy Coverage|Business Interruption|Option A Schedule | confidence=Review score=97
    public ILocator IFRAME280B0 => _page.GetByLabel("IFRAME", new() { Exact = true });

    // Source modules: Additional Interests Schedule | confidence=Review score=97
    public ILocator IFRAME59D4B => IFRAME280B0; // semantic alias; locator defined once

    // Source modules: Driver Detail | confidence=Review score=97
    public ILocator IFRAME6D695 => IFRAME280B0; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Address(es) or Description(s) of Designated Farm Location(s): | DuckCreekId | frame=iframe
    public ILocator IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationS => _page.FrameLocator("iframe").Locator("[duckcreekid=\"FarmLocationInput.FarmLocation\"], [data-duckcreekid=\"FarmLocationInput.FarmLocation\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Address(es) or Description(s) of Designated Premises: | DuckCreekId | frame=iframe
    public ILocator IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremises => _page.FrameLocator("iframe").Locator("[duckcreekid=\"PremisesInput.Premises\"], [data-duckcreekid=\"PremisesInput.Premises\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Description Of Premises Or Activities | attributes_fieldref | frame=iframe
    public ILocator IFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivities => _page.FrameLocator("iframe").Locator("[fieldref=\"CovAmendmentoOfLiquorLiabilityExclusionInputForWA.DescriptionOfPremisesOrActivities\"], [data-fieldref=\"CovAmendmentoOfLiquorLiabilityExclusionInputForWA.DescriptionOfPremisesOrActivities\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Excluded Driver | DuckCreekId | frame=iframe
    public ILocator IFRAMEDuckCreekPolicyExcludedDriver => _page.FrameLocator("iframe").Locator("[duckcreekid=\"ExcludedDriverInput.ExcludedDriver\"], [data-duckcreekid=\"ExcludedDriverInput.ExcludedDriver\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Name(s) or Description(s) of Designated Animal(s): | DuckCreekId | frame=iframe
    public ILocator IFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalS => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AnimalsInput.Animals\"], [data-duckcreekid=\"AnimalsInput.Animals\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyVehicleAssociation => _page.GetByText("Vehicle Association*", new() { Exact = true });

    // Source modules: BAP Endorsements | confidence=Review score=97
    public ILocator IFRAMEF0A48 => IFRAME280B0; // semantic alias; locator defined once

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=124
    // v56 raw Tosca primary: Specific Underwriting Questions - Contractors Equipment | If Yes, describe | attributes_fieldref
    public ILocator IfYesDescribe => _page.Locator("[fieldref=\"ContractorsEquipmentUnderwritingQuestionsInput.Description\"], [data-fieldref=\"ContractorsEquipmentUnderwritingQuestionsInput.Description\"]");

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    // v56 raw Tosca primary: [FG 00 13] Automatic Additional Insured - Specific Relationship | If yes, explain. | attributes_fieldref
    public ILocator IfYesExplain => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionFsub\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionFsub\"]");

    // Source modules: Commercial Auto | confidence=High score=95
    // v56 raw Tosca primary: Commercial Auto | Import Policy Data Button | DuckCreekId
    public ILocator ImportPolicyDataButton89922 => _page.Locator("[duckcreekid=\"Import Policy Data\"], [data-duckcreekid=\"Import Policy Data\"]");

    // Source modules: Businessowners | confidence=High score=95
    public ILocator ImportPolicyDataButtonEF44C => ImportPolicyDataButton89922; // semantic alias; locator defined once

    // Source modules: Property - Main | confidence=High score=95
    // v56 raw Tosca primary: Property - Main | Increased Pollutant Cleanup | DuckCreekId
    public ILocator IncreasedPollutantCleanup => _page.Locator("[duckcreekid=\"LocationPropertyInput.IncreasedPollutantCleanup\"], [data-duckcreekid=\"LocationPropertyInput.IncreasedPollutantCleanup\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    // v56 raw Tosca primary: Specific Underwriting Questions - Computer Systems | Indicate the building(s) age, type of construction, and protection class, and other tenants in the building(s) where the computer equipment is located | attributes_fieldref
    // v56 semantic alias: same physical raw-Tosca control as HowOftenIsDataBackedUp
    public ILocator IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated => HowOftenIsDataBackedUp;

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator InsuranceHistory => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance History", Exact = true });

    // Source modules:  | confidence=High score=125
    // v56 raw Tosca primary:  | Insured Type* | DuckCreekId | frame=iframe
    public ILocator InsuredType => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.InsuredType\"], [data-duckcreekid=\"AdditionalOtherInterestInput.InsuredType\"]");

    // Source modules: Building - Detail | confidence=High score=95
    // v56 raw Tosca primary: Building - Detail | Interest | Id+Name+DuckCreekId
    public ILocator Interest => _page.Locator("input[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0249_3_1-inputEl\"][name=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0249_3_1-inputEl\"][duckcreekid=\"BuildingInput.Interest\"]");

    // Source modules: State Details|Main | confidence=High score=95
    // v56 raw Tosca primary: State Details|Main | Intrastate Risk ID | DuckCreekId
    public ILocator IntrastateRiskID => _page.Locator("[duckcreekid=\"ExperienceModInput.RiskID\"], [data-duckcreekid=\"ExperienceModInput.RiskID\"]");

    // Source modules: Building - Detail | confidence=High score=125
    // v56 raw Tosca primary: Building - Detail | Is the building cooled?* | Id+Name+DuckCreekId
    public ILocator IsTheBuildingCooled => _page.Locator("input[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D02AD_3_1-inputEl\"][name=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D02AD_3_1-inputEl\"][duckcreekid=\"BuildingInput.BuildingCooled\"]");

    // Source modules: Building - Detail | confidence=High score=125
    // v56 raw Tosca primary: Building - Detail | Is the building heated with a Solid Fuel Heating Device?* | Id+Name+DuckCreekId
    public ILocator IsTheBuildingHeatedWithASolidFuelHeatingDevice => _page.Locator("input[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0296_3_1-inputEl\"][name=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0296_3_1-inputEl\"][duckcreekid=\"BuildingInput.SolidFuelHeatingDevices\"]");

    // Source modules: Policy Covg|GL | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg|GL | Is the Insured engaged in any Snow or Ice Removal Operations?* | DuckCreekId
    public ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations => _page.Locator("[duckcreekid=\"LineInput.InsuredEngaged\"], [data-duckcreekid=\"LineInput.InsuredEngaged\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    // v56 raw Tosca primary: CPP|Client|Underwriting Info|Commercial General Liability History | Is there a Prior Carrier? | Id+Name+DuckCreekId
    public ILocator IsThereAPriorCarrier => _page.Locator("input[id=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB6_1_1-inputEl\"][name=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB6_1_1-inputEl\"][duckcreekid=\"PolicyUnderwritingInput.CommercialGeneralLiabilityNoPriorCarrier\"]");

    // Source modules: Submission|Required and Optional Fields | confidence=Medium score=113
    public ILocator IsThisCoverageBound => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is this coverage bound?*", Exact = true });

    // Source modules:  | confidence=High score=95
    // Required for Commit/ Submission when Policy Number is blank.
    public ILocator IsThisPolicyBeingFullyCancelled => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is this policy being fully cancelled?*", Exact = true });

    // Source modules: Risk Schedule|Risk Specific | confidence=High score=125
    // Only applicable to trucks
    // v56 raw Tosca primary: Risk Schedule|Risk Specific | Is This Vehicle Used In Snow Plow Operations?* | DuckCreekId
    public ILocator IsThisVehicleUsedInSnowPlowOperations => _page.Locator("[duckcreekid=\"RiskTruckInput.SnowPlowOperations\"], [data-duckcreekid=\"RiskTruckInput.SnowPlowOperations\"]");

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The JavaScript code to execute. Use a return statement in the code to specify the return value.
    public ILocator JavaScript => _page.GetByLabel("JavaScript", new() { Exact = true });

    // Source modules:  | confidence=High score=125
    // v56 raw Tosca primary:  | Last Name* | Id+Name+DuckCreekId | frame=iframe
    public ILocator LastName34FF6 => _page.FrameLocator("iframe").Locator("input[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010CA_1_1-inputEl\"][name=\"string_10CA|\"][duckcreekid=\"DriverUnderwritingInformationInput.LastName\"]");

    // Source modules: State Details|Drive Other Car | confidence=High score=125
    // v56 raw Tosca primary: State Details|Drive Other Car | Last Name | DuckCreekId | frame=iframe
    public ILocator LastName5E149 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"RiskDriveOtherCarIteratorInput.LastName\"], [data-duckcreekid=\"RiskDriveOtherCarIteratorInput.LastName\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | Laundry % | Id+Name+DuckCreekId
    public ILocator Laundry => _page.Locator("input[id=\"f_bD3790336B18440B2B60CC0B7F5F4E10315D_2_2-inputEl\"][name=\"int_15D_1\"][duckcreekid=\"BaileesCustomerPrincipalWorkUnderwritingQuestionsInput.Percent\"]");

    // Source modules: Risk - Signs | confidence=High score=125
    // v56 raw Tosca primary: Risk - Signs | Lettering | Id+Name+DuckCreekId
    public ILocator Lettering => _page.Locator("input[id=\"f_r99A2986D696A457DA1C69BB16D902CEF19_1_1-inputEl\"][name=\"string_19|\"][duckcreekid=\"CoverageSignsIteratorInput.SignLettering\"]");

    // Source modules: Commercial Auto | confidence=High score=125
    // v56 raw Tosca primary: Commercial Auto | Liability Limit* | DuckCreekId
    public ILocator LiabilityLimit1AE2B => _page.Locator("[duckcreekid=\"UmbrellaCommercialAutoInput.LiabilityLimit\"], [data-duckcreekid=\"UmbrellaCommercialAutoInput.LiabilityLimit\"]");

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    public ILocator LiabilityLimit56E57 => LiabilityLimit1AE2B; // semantic alias; locator defined once

    // Source modules: Policy Covg - Bailees - Property Away from Your Premises | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Bailees - Property Away from Your Premises | Limit | Id+Name+DuckCreekId
    public ILocator Limit46632 => _page.Locator("input[id=\"f_b7BA9D20D6B9840E99A47B1B0DFA716BF8_1_1-inputEl\"][name=\"int_8\"][duckcreekid=\"BaileesCustomersPropertyAwayFromYourPremises.Limit\"]");

    // Source modules: Endorsement - IF 00 02 Waterborne Equipment | confidence=High score=125
    public ILocator Limit887C5 => Limit46632; // semantic alias; locator defined once

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator LimitE32DC => Limit46632; // semantic alias; locator defined once

    // Source modules: Risk - Signs | confidence=High score=125
    // v56 raw Tosca primary: Risk - Signs | Limit of Insurance | Id+Name+DuckCreekId
    public ILocator LimitOfInsurance => _page.Locator("input[id=\"f_r99A2986D696A457DA1C69BB16D902CEF16_1_1-inputEl\"][name=\"int_16\"][duckcreekid=\"CoverageSignsIteratorInput.PremiumBase\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Computer Systems | Line conditioner?* | Id+Name+DuckCreekId
    public ILocator LineConditioner => _page.Locator("input[id=\"f_c7FA512A090F641B9A6BB95F4C656EE183F_2_21-inputEl\"][name=\"f_c7FA512A090F641B9A6BB95F4C656EE183F_2_21-inputEl\"][duckcreekid=\"ComputerSystemsUnderwritingQuestionsInput.LineconditionerIndicator\"]");

    // Source modules: UW Questions - Workers Comp | confidence=High score=124
    // v56 raw Tosca primary: UW Questions - Workers Comp | List all policies with American National | attributes_fieldref
    public ILocator ListAllPoliciesWithAmericanNational => _page.Locator("[fieldref=\"UnderwritingQuestionsWorkersCompInput.ListAllPoliciesWithAmericanNational\"], [data-fieldref=\"UnderwritingQuestionsWorkersCompInput.ListAllPoliciesWithAmericanNational\"]");

    // Source modules: Indicators and Errors | confidence=High score=127
    // This DIV appears during a refresh of the screen (working in the background) and can be used as a WaitOn for stability.
    public ILocator LoadingMessage => _page.GetByLabel("Loading Message", new() { Exact = true });

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Physical Damage | Loan/Lease Gap | DuckCreekId
    public ILocator LoanLeaseGap => _page.Locator("[duckcreekid=\"RiskCommercialAutoRiskInput.LoanLease\"], [data-duckcreekid=\"RiskCommercialAutoRiskInput.LoanLease\"]");

    // Source modules: Location | confidence=High score=127
    // v56 raw Tosca primary: Location | Location | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator Location82D95 => AccountsReceivableHeading;

    // Source modules: WC Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Location | Location | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator Location8DEE2 => AccountsReceivableHeading;

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    public ILocator LocationA1D91 => Location8DEE2; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LocationAssignment => _page.GetByText("Location Assignment", new() { Exact = true });

    // Source modules: CP Navigation Links | confidence=Medium score=113
    public ILocator LocationB7B1D => Location8DEE2; // semantic alias; locator defined once

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator LocationE16BC => Location8DEE2; // semantic alias; locator defined once

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | LocationID | DuckCreekId | frame=iframe
    public ILocator LocationID => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestLocationsInput.LocationID\"], [data-duckcreekid=\"AdditionalOtherInterestLocationsInput.LocationID\"]");

    // Source modules: Location | confidence=High score=125
    public ILocator LocationOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: GL OCP|Risk | confidence=High score=125
    // v56 raw Tosca primary: GL OCP|Risk | Location Of Covered Operations | Id+Name+DuckCreekId
    public ILocator LocationOfCoveredOperations => _page.Locator("input[id=\"f_c630D2C33C75147EEB931C5458A61AA7059_3_1-inputEl\"][name=\"string_59|\"][duckcreekid=\"CovOwnersContractorsOrPrincipalsInput.LocationOfCoveredOperations\"]");

    // Source modules: Underwriting Info | Loss Experience | confidence=Medium score=113
    public ILocator LossExperience => _page.GetByRole(AriaRole.Link, new() { Name = "Loss Experience", Exact = true });

    // Source modules: Underwriting Info | Loss Experience | confidence=High score=97
    public ILocator LossExperienceHeading => _page.GetByLabel("Loss Experience Heading", new() { Exact = true });

    // Source modules: CGL|Main Page | confidence=High score=125
    public ILocator MainPageOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=125
    // v56 raw Tosca primary: Risk Schedule|Vehicle Information | Make* | DuckCreekId
    public ILocator Make => _page.Locator("[duckcreekid=\"RiskVehicleInput.Make\"], [data-duckcreekid=\"RiskVehicleInput.Make\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Marital Status | Id+Name+DuckCreekId | frame=iframe
    public ILocator MaritalStatus => _page.FrameLocator("iframe").Locator("input[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D2_1_1-inputEl\"][name=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D2_1_1-inputEl\"][duckcreekid=\"DriverUnderwritingInformationInput.MaritalStatus\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Medical | DuckCreekId
    public ILocator Medical => _page.Locator("[duckcreekid=\"CovMedicalInput.Medical\"], [data-duckcreekid=\"CovMedicalInput.Medical\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator MeritRating => _page.GetByText("Merit Rating", new() { Exact = true });

    // Source modules: Location | confidence=High score=125
    // v56 raw Tosca primary: Location | Miles From Fire Department | DuckCreekId
    public ILocator MilesFromFireDepartment => _page.Locator("[duckcreekid=\"LocationInput.MilesFromFireDepartment\"], [data-duckcreekid=\"LocationInput.MilesFromFireDepartment\"]");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Contractors Equipment | Misc Items Blanket Coverage | Id+Name+DuckCreekId
    public ILocator MiscItemsBlanketCoverage => _page.Locator("input[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FEC_3_1-inputEl\"][name=\"f_c48C85AB0259E43AE8BED26305EA4E022FEC_3_1-inputEl\"][duckcreekid=\"ContractorsEquipmentInput.BlanketIndicator\"]");

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=125
    // v56 raw Tosca primary: Risk Schedule|Vehicle Information | Model* | DuckCreekId
    public ILocator Model => _page.Locator("[duckcreekid=\"RiskVehicleInput.Model\"], [data-duckcreekid=\"RiskVehicleInput.Model\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    // v56 raw Tosca primary: Pricing | Modification Factor | DuckCreekId
    public ILocator ModificationFactor => _page.Locator("[duckcreekid=\"LineInput.ModificationFactor\"], [data-duckcreekid=\"LineInput.ModificationFactor\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=97
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | Motor Truck Cargo Heading | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator MotorTruckCargoHeading => AccountsReceivableHeading;

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: IM Navigation Links | Accounts Receivable UW Questions | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableUWQuestions
    public ILocator MotorTruckCargoUWQuestions => AccountsReceivableUWQuestions;

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator MotorcycleLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Motorcycle Liability", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | 10. Are the premises equipped with a recognized approved central station fire alarm, fire extinguishers or smoke alarms? | Id+Name+DuckCreekId
    public ILocator N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms => _page.Locator("input[id=\"f_b7DEEC9594E6B4D83BD0180865919757B16B_2_10-inputEl\"][name=\"f_b7DEEC9594E6B4D83BD0180865919757B16B_2_10-inputEl\"][duckcreekid=\"BaileesCustomerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 3. Does the applicant haul for others? | Id+Name+DuckCreekId
    public ILocator N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft => _page.Locator("input[id=\"f_m18CC23D224C1479990CCE2D5EBA3ED3C90_2_3-inputEl\"][name=\"f_m18CC23D224C1479990CCE2D5EBA3ED3C90_2_3-inputEl\"][duckcreekid=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 11. Are drivers’ MVRs and trip logs maintained? | Id+Name+DuckCreekId
    public ILocator N11AreDriversMVRsAndTripLogsMaintained => _page.Locator("input[id=\"f_m2B14DC917C294E2289B9F03AAECA7FDD90_2_11-inputEl\"][name=\"f_m2B14DC917C294E2289B9F03AAECA7FDD90_2_11-inputEl\"][duckcreekid=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | Dry Cleaning % | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as DryCleaning
    public ILocator N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit => DryCleaning;

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | 12. Are drivers’ MVRs reviewed on a regular basis and maintained? | Id+Name+DuckCreekId
    public ILocator N12AreDriversMVRsReviewedOnARegularBasisAndMaintained => _page.Locator("input[id=\"f_bB1C8725295D646D28E8F8F6AFF6DCD4A16B_2_12-inputEl\"][name=\"f_bB1C8725295D646D28E8F8F6AFF6DCD4A16B_2_12-inputEl\"][duckcreekid=\"BaileesCustomerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 3. Does the applicant haul for others? | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft
    public ILocator N12HowOftenAreTheseLogsReviewedOrUpdated => N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft;

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 13. Live animal in transit coverage? | Id+Name+DuckCreekId
    public ILocator N13LiveAnimalInTransitCoverage => _page.Locator("input[id=\"f_mDB9F63B542BB45E4A6ED96CA4FEB0A4D99_2_13-inputEl\"][name=\"f_mDB9F63B542BB45E4A6ED96CA4FEB0A4D99_2_13-inputEl\"][duckcreekid=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | Dry Cleaning % | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as DryCleaning
    public ILocator N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle => DryCleaning;

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 14. Legal Liability coverage? | Id+Name+DuckCreekId
    public ILocator N14LegalLiabilityCoverage => _page.Locator("input[id=\"f_m1DC94D997BEB443ABFC8A1974E835E9399_2_14-inputEl\"][name=\"f_m1DC94D997BEB443ABFC8A1974E835E9399_2_14-inputEl\"][duckcreekid=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | Dry Cleaning % | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as DryCleaning
    public ILocator N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage => DryCleaning;

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | Dry Cleaning % | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as DryCleaning
    public ILocator N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft => DryCleaning;

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | 16. Does the risk use release forms? | Id+Name+DuckCreekId
    public ILocator N16DoesTheRiskUseReleaseForms => _page.Locator("input[id=\"f_b9A3E482906284343AC03033C7B31809816B_2_16-inputEl\"][name=\"f_b9A3E482906284343AC03033C7B31809816B_2_16-inputEl\"][duckcreekid=\"BaileesCustomerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 3. Does the applicant haul for others? | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft
    public ILocator N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment => N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft;

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | Dry Cleaning % | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as DryCleaning
    public ILocator N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises => DryCleaning;

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 3. Does the applicant haul for others? | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft
    public ILocator N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities => N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft;

    // Source modules: Risk Schedule|Risk Specific | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Risk Specific | 2nd Class Category | DuckCreekId
    public ILocator N2ndClassCategory => _page.Locator("[duckcreekid=\"RiskTruckInput.SecondaryClassCategory\"], [data-duckcreekid=\"RiskTruckInput.SecondaryClassCategory\"]");

    // Source modules: Risk Schedule|Risk Specific | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Risk Specific | 2nd Class Code* | DuckCreekId
    public ILocator N2ndClassCode => _page.Locator("[duckcreekid=\"RiskTruckInput.SecondaryClassCode\"], [data-duckcreekid=\"RiskTruckInput.SecondaryClassCode\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 3. Does the applicant haul for others? | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft
    public ILocator N3DoesTheApplicantHaulForOthers => N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft;

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | Dry Cleaning % | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as DryCleaning
    public ILocator N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair => DryCleaning;

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | Dry Cleaning % | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as DryCleaning
    public ILocator N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated => DryCleaning;

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 3. Does the applicant haul for others? | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft
    public ILocator N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer => N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft;

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | 5. Are recognized approved central station burglar alarms installed and maintained? | Id+Name+DuckCreekId
    public ILocator N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained => _page.Locator("input[id=\"f_b7A8649BA88594F07A2EED84065C05C7116B_2_5-inputEl\"][name=\"f_b7A8649BA88594F07A2EED84065C05C7116B_2_5-inputEl\"][duckcreekid=\"BaileesCustomerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Policy Covg - Signs | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Signs | 5% Deductible | Id+Name+DuckCreekId
    public ILocator N5Deductible => _page.Locator("input[id=\"f_cAFD1AA97819C467694F348BB5BA65F85E47_3_6-inputEl\"][name=\"f_cAFD1AA97819C467694F348BB5BA65F85E47_3_6-inputEl\"][duckcreekid=\"SignsInput.Deductible\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 5. Do any vehicles have special equipment mounted or attached? | Id+Name+DuckCreekId
    public ILocator N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached => _page.Locator("input[id=\"f_m8488653223CB4B4BA40DE31CDB6F800A90_2_5-inputEl\"][name=\"f_m8488653223CB4B4BA40DE31CDB6F800A90_2_5-inputEl\"][duckcreekid=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | 6. Are all storage areas locked at all times when unoccupied? | Id+Name+DuckCreekId
    public ILocator N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied => _page.Locator("input[id=\"f_b1C15D4BB95924355B6C9DB3E4D486C7D16B_2_6-inputEl\"][name=\"f_b1C15D4BB95924355B6C9DB3E4D486C7D16B_2_6-inputEl\"][duckcreekid=\"BaileesCustomerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 6. Does the applicant pull double or triple trailers? | Id+Name+DuckCreekId
    public ILocator N6DoesTheApplicantPullDoubleOrTripleTrailers => _page.Locator("input[id=\"f_m73855E80098B4D51BF013C509D9F26A390_2_6-inputEl\"][name=\"f_m73855E80098B4D51BF013C509D9F26A390_2_6-inputEl\"][duckcreekid=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | 7. Are there any hazardous or flammable materials used or stored on the premises? | Id+Name+DuckCreekId
    public ILocator N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises => _page.Locator("input[id=\"f_b31C4DC1E36A54CE78682FB544E3BA0AB16B_2_7-inputEl\"][name=\"f_b31C4DC1E36A54CE78682FB544E3BA0AB16B_2_7-inputEl\"][duckcreekid=\"BaileesCustomerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 7. Does the applicant leave the truck windows, doors and compartments closed and locked when unattended? | Id+Name+DuckCreekId
    public ILocator N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended => _page.Locator("input[id=\"f_mC7C58EF91D2B448AB0D44299B4464B9690_2_7-inputEl\"][name=\"f_mC7C58EF91D2B448AB0D44299B4464B9690_2_7-inputEl\"][duckcreekid=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 8. Do you provide scheduled maintenance for the vehicles and trailers you operate? | Id+Name+DuckCreekId
    public ILocator N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate => _page.Locator("input[id=\"f_mFDAD2FC147D34702A28F7B4FB47773E190_2_8-inputEl\"][name=\"f_mFDAD2FC147D34702A28F7B4FB47773E190_2_8-inputEl\"][duckcreekid=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 9. Are the employees that pack, load and unload trained in proper handling of the commodities? | Id+Name+DuckCreekId
    public ILocator N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities => _page.Locator("input[id=\"f_mBE856C8E1BC04AFE85652589CD82142890_2_9-inputEl\"][name=\"f_mBE856C8E1BC04AFE85652589CD82142890_2_9-inputEl\"][duckcreekid=\"MotorTruckOwnerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Bailees Customer | 9. Are the premises or any portion of the premises equipped with a sprinkler system? | Id+Name+DuckCreekId
    public ILocator N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem => _page.Locator("input[id=\"f_b8CF5D796EA6C4194B4DA603919413A5B16B_2_9-inputEl\"][name=\"f_b8CF5D796EA6C4194B4DA603919413A5B16B_2_9-inputEl\"][duckcreekid=\"BaileesCustomerUnderwritingQuestionsInput.Indicator\"]");

    // Source modules:  | confidence=High score=125
    // v56 raw Tosca primary:  | NAICSCodeSearchValue | DuckCreekId | frame=iframe
    public ILocator NAICSCodeSearchValue => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestLocationsOutputNonShredded.NAICSCodeSearchValue\"], [data-duckcreekid=\"AdditionalOtherInterestLocationsOutputNonShredded.NAICSCodeSearchValue\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Name(s) or Description(s) and Date(s) of Designated Activities or Services | DuckCreekId | frame=iframe
    public ILocator NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices => _page.FrameLocator("iframe").Locator("[duckcreekid=\"ActivitiesInput.Activities\"], [data-duckcreekid=\"ActivitiesInput.Activities\"]");

    // Source modules: Endorsement - CM 66 01 Exclude Named Customer | confidence=High score=125
    // v56 raw Tosca primary: Endorsement - CM 66 01 Exclude Named Customer | Names | Id+Name+DuckCreekId
    public ILocator Names => _page.Locator("input[id=\"f_CCE14981F38894A679A407BA735B5959BD2_3_1-inputEl\"][name=\"string_D2|\"][duckcreekid=\"CovEndorsmentIteratorNonShreddedInput.Name\"]");

    // Source modules: Underwriting Info | Loss Experience | confidence=Medium score=113
    public ILocator NoKnownLosses => _page.GetByRole(AriaRole.Checkbox, new() { Name = "No known losses", Exact = true });

    // Source modules: Policy Coverage|NonOwned | confidence=High score=124
    // v56 raw Tosca primary: Policy Coverage|NonOwned | Non Owned Auto | Id+Name
    public ILocator NonOwnedAuto => _page.Locator("input[id=\"f_l933E247C4F174276A26F1D9E9D7C481318A_3_1-inputEl\"][name=\"f_l933E247C4F174276A26F1D9E9D7C481318A_3_1-inputEl\"]");

    // Source modules: NotePad | confidence=High score=125
    public ILocator NotePadOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator Notepad => _page.GetByRole(AriaRole.Link, new() { Name = "Notepad", Exact = true });

    // Source modules: NotePad | confidence=High score=97
    public ILocator NotepadHeading => _page.GetByLabel("Notepad Heading", new() { Exact = true });

    // Source modules: [CG0435] Employee Benefits Liability | confidence=High score=125
    // v56 raw Tosca primary: [CG0435] Employee Benefits Liability | Number Of Employees | DuckCreekId
    public ILocator NumberOfEmployees => _page.Locator("[duckcreekid=\"CovEmployeeBenefitsLiabInput.NumberOfEmployees\"], [data-duckcreekid=\"CovEmployeeBenefitsLiabInput.NumberOfEmployees\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Number of Full-Time Employees* | DuckCreekId | frame=iframe
    public ILocator NumberOfFullTimeEmployees => _page.FrameLocator("iframe").Locator("[duckcreekid=\"CoverageInput.NumberOfFullTimeEmployees\"], [data-duckcreekid=\"CoverageInput.NumberOfFullTimeEmployees\"]");

    // Source modules:  | confidence=High score=125
    // v56 raw Tosca primary:  | Number of Part-Time Employees* | DuckCreekId | frame=iframe
    public ILocator NumberOfPartTimeEmployees => _page.FrameLocator("iframe").Locator("[duckcreekid=\"CoverageInput.NumberOfPartTimeEmployees\"], [data-duckcreekid=\"CoverageInput.NumberOfPartTimeEmployees\"]");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Motor Truck Cargo | Number Of Vehicles | Id+Name+DuckCreekId
    public ILocator NumberOfVehicles => _page.Locator("input[id=\"f_cB85F41925276456C81E1ED1306A2AB40108C_3_5-inputEl\"][name=\"int_108C\"][duckcreekid=\"MotorTruckCargoInput.CarriersNumberOfVehicles\"]");

    // Source modules: GL Navigation Links | confidence=Medium score=113
    public ILocator OCP => _page.GetByRole(AriaRole.Link, new() { Name = "OCP", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator OK => AddClassOK; // semantic alias; locator defined once

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | OK-Class Code | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as AddClassOK
    public ILocator OKClassCode => AddClassOK;

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | OK-Details | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as AddClassOK
    public ILocator OKDetails => AddClassOK;

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | OK (First) | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as AddClassOK
    public ILocator OKFirst => AddClassOK;

    // Source modules:  | confidence=High score=95
    // Only used as a sync point to verify that the first OK has been clicked.
    // v56 raw Tosca primary:  | OK (Second) | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as AddClassOK
    public ILocator OKSecond => AddClassOK;

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Physical Damage | OTC Causes of Loss* | Id+Name+DuckCreekId
    public ILocator OTCCausesOfLoss => _page.Locator("input[id=\"f_cBFB0A5467643454EAC6DC41BBBFF51C22337_2_1-inputEl\"][name=\"f_cBFB0A5467643454EAC6DC41BBBFF51C22337_2_1-inputEl\"][duckcreekid=\"CovOTCInput.CoverageForm\"]");

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=125
    // v56 raw Tosca primary: State Details|Hired Auto Physical Damage With Driver | OTC Deductible* | DuckCreekId
    public ILocator OTCDeductible62C21 => _page.Locator("[duckcreekid=\"CovHiredAndBorrowedOTCWithDriverInput.Deductible\"], [data-duckcreekid=\"CovHiredAndBorrowedOTCWithDriverInput.Deductible\"]");

    // Source modules: State Details|Drive Other Car | confidence=High score=125
    // v56 raw Tosca primary: State Details|Drive Other Car | OTC Deductible | DuckCreekId
    public ILocator OTCDeductibleE0D59 => _page.Locator("[duckcreekid=\"CovDriveOtherCarOTCInput.Deductible\"], [data-duckcreekid=\"CovDriveOtherCarOTCInput.Deductible\"]");

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=125
    public ILocator OTCDeductibleEF1DE => OTCDeductible62C21; // semantic alias; locator defined once

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=124
    // v56 raw Tosca primary: State Details|Hired Auto PD Without Driver | OTC If Any | attributes_fieldref
    public ILocator OTCIfAny4EFEE => _page.Locator("[fieldref=\"CovHiredAndBorrowedOTCInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedOTCInput.IfAny\"]");

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=124
    public ILocator OTCIfAny6A58B => OTCIfAny4EFEE; // semantic alias; locator defined once

    // Source modules: Property Add Class | confidence=High score=125
    // v56 raw Tosca primary: Property Add Class | Occupancy Type | DuckCreekId
    public ILocator OccupancyType => _page.Locator("[duckcreekid=\"OccupancyInput.OccupancyTypeMonoline\"], [data-duckcreekid=\"OccupancyInput.OccupancyTypeMonoline\"]");

    // Source modules: Property - Main | confidence=High score=95
    // v56 raw Tosca primary: Property - Main | % Occupied | DuckCreekId
    public ILocator Occupied => _page.Locator("[duckcreekid=\"BuildingInput.VacancyPercentageOccupied\"], [data-duckcreekid=\"BuildingInput.VacancyPercentageOccupied\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Occurence Limit | DuckCreekId
    public ILocator OccurenceLimit => _page.Locator("[duckcreekid=\"LineInput.PolicyPerOccurenceLimit\"], [data-duckcreekid=\"LineInput.PolicyPerOccurenceLimit\"]");

    // Source modules: Policy Coverage|NonOwned | confidence=High score=124
    // v56 raw Tosca primary: Policy Coverage|NonOwned | # of Employees | Id+Name
    public ILocator OfEmployees => _page.Locator("input[id=\"f_r833047D99DE246ABBC46A28BC930EF19192_3_1-inputEl\"][name=\"int_192\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | # of Full-Time Employees* | Id+Name+DuckCreekId
    public ILocator OfFullTimeEmployees => _page.Locator("input[id=\"f_l5E228A3F9AC041EBB7129353068D3F69165_3_1-inputEl\"][name=\"int_165\"][duckcreekid=\"LineInput.NumberOfFullTimeEmployees\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | # of Part-Time Employees* | Id+Name+DuckCreekId
    public ILocator OfPartTimeEmployees => _page.Locator("input[id=\"f_l5E228A3F9AC041EBB7129353068D3F69166_3_1-inputEl\"][name=\"int_166\"][duckcreekid=\"LineInput.NumberOfPartTimeEmployees\"]");

    // Source modules: Policy Coverage|NonOwned | confidence=High score=124
    // v56 raw Tosca primary: Policy Coverage|NonOwned | # of Partners | attributes_fieldref
    public ILocator OfPartners => _page.Locator("[fieldref=\"RiskNonOwnedAutoInput.NumberOfPartnersEstimate\"], [data-fieldref=\"RiskNonOwnedAutoInput.NumberOfPartnersEstimate\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | # of Seasonal/Temporary Employees* | Id+Name+DuckCreekId
    public ILocator OfSeasonalTemporaryEmployees => _page.Locator("input[id=\"f_l5E228A3F9AC041EBB7129353068D3F69167_3_1-inputEl\"][name=\"int_167\"][duckcreekid=\"LineInput.NumberOfSeasonalTemporaryEmployees\"]");

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    // v56 raw Tosca primary: Endorsements|Partners, Officers And Others Exclusion | Officers* | DuckCreekId
    public ILocator Officers => _page.Locator("[duckcreekid=\"EndorsementOfficers.Officers\"], [data-duckcreekid=\"EndorsementOfficers.Officers\"]");

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    // v56 raw Tosca primary: Endorsements|Partners, Officers And Others Exclusion | Officers Position Held* | DuckCreekId
    public ILocator OfficersPositionHeld => _page.Locator("[duckcreekid=\"EndorsementOfficers.PositionHeld\"], [data-duckcreekid=\"EndorsementOfficers.PositionHeld\"]");

    // Source modules:  | confidence=High score=97
    // v56 raw Tosca primary:  | Option A | Id | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as DriverDetail
    public ILocator OptionA => DriverDetail;

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=124
    // v56 raw Tosca primary: Policy Coverage|Business Interruption | Option A CheckBox  | attributes_fieldref
    public ILocator OptionACheckBox => _page.Locator("[fieldref=\"BusinessInterruptionEndorsementInput.OptionA\"], [data-fieldref=\"BusinessInterruptionEndorsementInput.OptionA\"]");

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    // v56 raw Tosca primary: Policy Coverage|Business Interruption | Option A Schedule Button | DuckCreekId
    public ILocator OptionAScheduleButton => _page.Locator("[duckcreekid=\"Option A Schedule\"], [data-duckcreekid=\"Option A Schedule\"]");

    // Source modules: Submission|Required and Optional Fields | confidence=High score=125
    // v56 raw Tosca primary: Submission|Cancel - Order - Do Not Order Audit | Order Audit | DuckCreekId
    public ILocator OrderAudit => _page.Locator("[duckcreekid=\"Order Audit\"], [data-duckcreekid=\"Order Audit\"]");

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Vehicle Information | Original Cost New* | DuckCreekId
    public ILocator OriginalCostNew => _page.Locator("[duckcreekid=\"RiskVehicleInput.ValueEstimate\"], [data-duckcreekid=\"RiskVehicleInput.ValueEstimate\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    public ILocator OtherInsuranceHistoryOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=95
    // v56 raw Tosca primary: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Others* | DuckCreekId
    public ILocator Others9E098 => _page.Locator("[duckcreekid=\"EndorsementOthers.Others\"], [data-duckcreekid=\"EndorsementOthers.Others\"]");

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    public ILocator OthersB1A1B => Others9E098; // semantic alias; locator defined once

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=95
    // v56 raw Tosca primary: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Partners* | DuckCreekId
    public ILocator Partners => _page.Locator("[duckcreekid=\"EndorsementPartners.Partners\"], [data-duckcreekid=\"EndorsementPartners.Partners\"]");

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=125
    public ILocator PartnersOfficersAndOthersExclusionOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Billing | confidence=High score=125
    public ILocator PayPlan => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pay Plan", Exact = true });

    // Source modules: State Details|Main | confidence=High score=95
    // v56 raw Tosca primary: State Details|Main | Pending Rate Change | Id+DuckCreekId
    public ILocator PendingRateChange => _page.Locator("div[id=\"f_l43F2C8E3497A4C328FCF8D515AC746C31CB6_3_1-inputEl\"][duckcreekid=\"Pending Rate Change\"]");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Motor Truck Cargo | Per Vehicle Limit | Id+Name+DuckCreekId
    public ILocator PerVehicleLimit => _page.Locator("input[id=\"f_cB85F41925276456C81E1ED1306A2AB401083_3_5-inputEl\"][name=\"int_1083\"][duckcreekid=\"MotorTruckCargoInput.PerVehicleLimit\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Pers Adv Inj | DuckCreekId
    public ILocator PersAdvInj => _page.Locator("[duckcreekid=\"CovPersonalAdvertisingInjuryInput.PersonalAdvertisingInjury\"], [data-duckcreekid=\"CovPersonalAdvertisingInjuryInput.PersonalAdvertisingInjury\"]");

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Computer Systems | Personal Portable Computers | Id+Name+DuckCreekId
    public ILocator PersonalPortableComputers => _page.Locator("input[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8B_3_4-inputEl\"][name=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8B_3_4-inputEl\"][duckcreekid=\"ComputerSystemsInput.PersonalPortableComputersIndicator\"]");

    // Source modules: Property Add Class | confidence=High score=125
    // v56 raw Tosca primary: Property Add Class | Personal Property Limit | DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as BuildingLimit
    public ILocator PersonalPropertyLimit => BuildingLimit;

    // Source modules: Property Add Class | confidence=High score=125
    // v56 raw Tosca primary: Property Add Class | Personal Property Rating Group | DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as BuildingRatingGroup
    public ILocator PersonalPropertyRatingGroup => BuildingRatingGroup;

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=125
    public ILocator PhysicalDamageOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Property - Main | confidence=High score=95
    // v56 raw Tosca primary: Property - Main | Pier Or Wharf | DuckCreekId
    public ILocator PierOrWharf => _page.Locator("[duckcreekid=\"BuildingInput.PierOrWharf\"], [data-duckcreekid=\"BuildingInput.PierOrWharf\"]");

    // Source modules: Property - Main | confidence=High score=95
    // v56 raw Tosca primary: Property - Main | Pier Or Wharf COL Options | DuckCreekId
    public ILocator PierOrWharfCOLOptions => _page.Locator("[duckcreekid=\"BuildingInput.PierOrWharfCOLOptions\"], [data-duckcreekid=\"BuildingInput.PierOrWharfCOLOptions\"]");

    // Source modules: Property - Main | confidence=High score=95
    // v56 raw Tosca primary: Property - Main | Pier Or Wharf Cause Of Loss | DuckCreekId
    public ILocator PierOrWharfCauseOfLoss => _page.Locator("[duckcreekid=\"BuildingInput.PierOrWharfCauseOfLoss\"], [data-duckcreekid=\"BuildingInput.PierOrWharfCauseOfLoss\"]");

    // Source modules: Property - Main | confidence=High score=95
    // v56 raw Tosca primary: Property - Main | Pier Or Wharf Construction | DuckCreekId
    public ILocator PierOrWharfConstruction => _page.Locator("[duckcreekid=\"BuildingInput.PierOrWharfConstruction\"], [data-duckcreekid=\"BuildingInput.PierOrWharfConstruction\"]");

    // Source modules: UW Questions - Umbrella | confidence=High score=125
    // v56 raw Tosca primary: UW Questions - Umbrella | Please provide website address(es).* | DuckCreekId
    public ILocator PleaseProvideWebsiteAddressEs => _page.Locator("[duckcreekid=\"UnderwritingQuestionsUmbrellaInput.WebsiteAddress\"], [data-duckcreekid=\"UnderwritingQuestionsUmbrellaInput.WebsiteAddress\"]");

    // Source modules: Policy Coverage|Limits | confidence=High score=127
    // v56 raw Tosca primary: Policy Coverage|Limits | Policy Covg | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator PolicyCovg26786 => AccountsReceivableHeading;

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Policy Covg | Policy Covg | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator PolicyCovg35BE4 => AccountsReceivableHeading;

    // Source modules: GL Navigation Links | confidence=Medium score=113
    public ILocator PolicyCovg50C98 => PolicyCovg35BE4; // semantic alias; locator defined once

    // Source modules: Policy Covg|GL | confidence=High score=127
    public ILocator PolicyCovg6B651 => PolicyCovg26786; // semantic alias; locator defined once

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=125
    public ILocator PolicyCovgBaileesCutomersOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Policy Covg - Bailees - Property Away from Your Premises | confidence=High score=125
    public ILocator PolicyCovgBaileesPropertyAwayFromYourPremisesOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    public ILocator PolicyCovgComputerSystemsOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator PolicyCovgContractorsEquipmentOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: CP Navigation Links | confidence=Medium score=113
    public ILocator PolicyCovgD0419 => PolicyCovg35BE4; // semantic alias; locator defined once

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator PolicyCovgD3CEF => PolicyCovg35BE4; // semantic alias; locator defined once

    // Source modules: IM Navigation Links | confidence=Medium score=113
    public ILocator PolicyCovgED95C => PolicyCovg35BE4; // semantic alias; locator defined once

    // Source modules: Policy Covg - Main | confidence=High score=127
    public ILocator PolicyCovgF9E58 => PolicyCovg26786; // semantic alias; locator defined once

    // Source modules: Policy Covg | confidence=High score=127
    public ILocator PolicyCovgFF145 => PolicyCovg26786; // semantic alias; locator defined once

    // Source modules: Policy Covg | confidence=High score=97
    // v56 raw Tosca primary: Policy Covg | Policy Covg Header | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator PolicyCovgHeader => AccountsReceivableHeading;

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    public ILocator PolicyCovgMotorTruckCargoOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Policy Covg - Signs | confidence=High score=125
    public ILocator PolicyCovgSignsOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: BAP Navigation Links | State Details - Detail | Id
    // v56 semantic alias: same physical raw-Tosca control as AdditionalInterests
    public ILocator PolicyCovgerage => AdditionalInterests;

    // Source modules: GL OCP|Risk | confidence=High score=125
    // v56 raw Tosca primary: GL OCP|Risk | Policy Holder Name | Id+Name+DuckCreekId
    public ILocator PolicyHolderName => _page.Locator("input[id=\"f_c630D2C33C75147EEB931C5458A61AA705C_3_1-inputEl\"][name=\"string_5C|\"][duckcreekid=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderName\"]");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator PolicyInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Info", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=97
    public ILocator PolicyInfoHeader => _page.GetByLabel("Policy Info Header", new() { Exact = true });

    // Source modules: Commercial Auto | confidence=High score=125
    // v56 raw Tosca primary: Commercial Auto | Policy Number | DuckCreekId
    public ILocator PolicyNumber461C7 => _page.Locator("[duckcreekid=\"UmbrellaCommercialAutoInput.PolicyNumber\"], [data-duckcreekid=\"UmbrellaCommercialAutoInput.PolicyNumber\"]");

    // Source modules: Businessowners | confidence=High score=125
    public ILocator PolicyNumber6566F => PolicyNumber461C7; // semantic alias; locator defined once

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    public ILocator PolicyNumber78B85 => PolicyNumber461C7; // semantic alias; locator defined once

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator PolicyNumberBA28E => PolicyNumber461C7; // semantic alias; locator defined once

    // Source modules: General Liability | confidence=High score=125
    public ILocator PolicyNumberFDF5C => PolicyNumber461C7; // semantic alias; locator defined once

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator PolicyType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Type", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Computer Systems | Power suppressor voltage regulator?* | Id+Name+DuckCreekId
    public ILocator PowerSuppressorVoltageRegulator => _page.Locator("input[id=\"f_c7FA512A090F641B9A6BB95F4C656EE1840_2_21-inputEl\"][name=\"f_c7FA512A090F641B9A6BB95F4C656EE1840_2_21-inputEl\"][duckcreekid=\"ComputerSystemsUnderwritingQuestionsInput.PowerShortageIndicator\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | PremOp Ded | DuckCreekId
    public ILocator PremOpDed => _page.Locator("[duckcreekid=\"LineInput.Deductible\"], [data-duckcreekid=\"LineInput.Deductible\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | PremOp PD Ded | DuckCreekId
    public ILocator PremOpPDDed => _page.Locator("[duckcreekid=\"LineInput.DeductiblePD\"], [data-duckcreekid=\"LineInput.DeductiblePD\"]");

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v56 raw Tosca primary: Risk - Accounts Receivable | Premises Type | Id+Name+DuckCreekId
    public ILocator PremisesType => _page.Locator("input[id=\"f_c4FFD73A13C164B729C39A3F5C851102317_1_1-inputEl\"][name=\"f_c4FFD73A13C164B729C39A3F5C851102317_1_1-inputEl\"][duckcreekid=\"CovAccountsReceivableInput.PremisesType\"]");

    // Source modules: Pricing | confidence=High score=125
    // v56 raw Tosca primary: Pricing | Premium | DuckCreekId
    public ILocator Premium => _page.Locator("[duckcreekid=\"Premium\"], [data-duckcreekid=\"Premium\"]");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: CPP|Pricing | Pricing | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator Pricing900C9 => AccountsReceivableHeading;

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator PricingB84E6 => Pricing900C9; // semantic alias; locator defined once

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator PricingDCBD4 => Pricing900C9; // semantic alias; locator defined once

    // Source modules: Pricing | confidence=High score=125
    // v56 raw Tosca primary: Pricing | Pricing Detail | DuckCreekId
    public ILocator PricingDetail => _page.Locator("[duckcreekid=\"Pricing Detail\"], [data-duckcreekid=\"Pricing Detail\"]");

    // Source modules: Pricing | confidence=High score=125
    // v56 raw Tosca primary: Pricing | Pricing Detail - OK | DuckCreekId
    public ILocator PricingDetailOK => _page.Locator("[duckcreekid=\"OK\"], [data-duckcreekid=\"OK\"]");

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    public ILocator PricingF3185 => Pricing900C9; // semantic alias; locator defined once

    // Source modules: Pricing | confidence=High score=97
    // v56 raw Tosca primary: Pricing | Pricing Heading | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator PricingHeading => AccountsReceivableHeading;

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    // v56 raw Tosca primary: State Details|Hired Auto Liability | Primary Liability If Any | Id+Name
    public ILocator PrimaryLiabilityIfAny => _page.Locator("input[id=\"f_c4AA801084C144D5ABAE2476592EAF1CD2245_1_1-inputEl\"][name=\"boolean_2245\"]");

    // Source modules: Policy Covg | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg | Primary Location State* | DuckCreekId
    public ILocator PrimaryLocationState => _page.Locator("[duckcreekid=\"LineInput.PrimaryLocationState\"], [data-duckcreekid=\"LineInput.PrimaryLocationState\"]");

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=95
    // Not Displayed for WC
    // v56 raw Tosca primary:  | State | DuckCreekId | frame=iframe
    public ILocator PrimaryRatingState => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.State\"], [data-duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.State\"]");

    // Source modules:  | confidence=High score=95
    // Required for Commit/ Submission
    public ILocator PriorAmericanNationalPolicy => _page.GetByRole(AriaRole.Textbox, new() { Name = "Prior American National Policy #*", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Prod BI Ded | DuckCreekId
    public ILocator ProdBIDed => _page.Locator("[duckcreekid=\"LineInput.DeductibleProducts\"], [data-duckcreekid=\"LineInput.DeductibleProducts\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Prod PD Ded | DuckCreekId
    public ILocator ProdPDDed => _page.Locator("[duckcreekid=\"LineInput.DeductiblePDProducts\"], [data-duckcreekid=\"LineInput.DeductiblePDProducts\"]");

    // Source modules: Risk Schedule|General Coverage | confidence=High score=125
    // v56 raw Tosca primary: Risk Schedule|General Coverage | Produce Carried | DuckCreekId
    public ILocator ProduceCarried => _page.Locator("[duckcreekid=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.ProduceCarried\"], [data-duckcreekid=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.ProduceCarried\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg|GL | Products Agg Limit | DuckCreekId
    public ILocator ProductsAggLimit => _page.Locator("[duckcreekid=\"LineInput.ProductsAggregateLimit\"], [data-duckcreekid=\"LineInput.ProductsAggregateLimit\"]");

    // Source modules: Policy Covg | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg | Products - Completed Operations Aggregate Limit | DuckCreekId
    public ILocator ProductsCompletedOperationsAggregateLimit => _page.Locator("[duckcreekid=\"LineInput.ProductsCompletedOperationsAggregateLimit\"], [data-duckcreekid=\"LineInput.ProductsCompletedOperationsAggregateLimit\"]");

    // Source modules: Products/Completed Ops | confidence=High score=97
    // v56 raw Tosca primary: Products/Completed Ops | Products/Completed Ops | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator ProductsCompletedOps => AccountsReceivableHeading;

    // Source modules: Products/Completed Ops | confidence=Medium score=113
    // v56 raw Tosca primary: Products/Completed Ops | Products/Completed Ops | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator ProductsCompletedOpsButton => AccountsReceivableHeading;

    // Source modules: Products/Completed Ops | confidence=High score=125
    public ILocator ProductsCompletedOpsOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: CP Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Property - Main | Property | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator Property => AccountsReceivableHeading;

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator PropertyAddClassOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Bailees Cutomers | Property Away From Your Premises Schedule | DuckCreekId
    public ILocator PropertyAwayFromYourPremisesSchedule => _page.Locator("[duckcreekid=\"Property Away From Your Premises Schedule\"], [data-duckcreekid=\"Property Away From Your Premises Schedule\"]");

    // Source modules: Property Enter Building RCT | confidence=High score=125
    public ILocator PropertyEnterBuildingRCTOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Computer Systems | Property In Transit | Id+Name+DuckCreekId
    public ILocator PropertyInTransit6E905 => _page.Locator("input[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F86_3_4-inputEl\"][name=\"int_F86\"][duckcreekid=\"ComputerSystemsInput.PropertyInTransit\"]");

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=125
    public ILocator PropertyInTransit710FF => PropertyInTransit6E905; // semantic alias; locator defined once

    // Source modules: Property Add Class | confidence=High score=125
    // v56 raw Tosca primary: Property Add Class | Property of Others Limit | DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as BuildingLimit
    public ILocator PropertyOfOthersLimit => BuildingLimit;

    // Source modules: Property Add Class | confidence=High score=125
    // v56 raw Tosca primary: Property Add Class | Property of Others Rating Group | DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as BuildingRatingGroup
    public ILocator PropertyOfOthersRatingGroup => BuildingRatingGroup;

    // Source modules: Property UW Questions | confidence=High score=127
    // v56 raw Tosca primary: Property UW Questions | Property UW Questions | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator PropertyUWQuestions790F2 => AccountsReceivableHeading;

    // Source modules: CP Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Property UW Questions | Property UW Questions | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator PropertyUWQuestions8452C => AccountsReceivableHeading;

    // Source modules: Building - Detail | confidence=High score=94
    // v56 raw Tosca primary: Building - Detail | Provide a List of Surrounding Exposure/Other Occupancies within 100 ft (Including North, East, South, and West) | Id+Name
    public ILocator ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest => _page.Locator("textarea[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D02AF_3_1-inputEl\"][name=\"string_2AF\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    // v56 raw Tosca primary: Specific Underwriting Questions - Computer Systems | Provide information regarding antivirus methods and copyright protection of data and media | attributes_fieldref
    // v56 semantic alias: same physical raw-Tosca control as HowOftenIsDataBackedUp
    public ILocator ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia => HowOftenIsDataBackedUp;

    // Source modules: CP Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Rating Groups | Rating Groups | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator RatingGroups46191 => AccountsReceivableHeading;

    // Source modules: Rating Groups | confidence=High score=127
    // v56 raw Tosca primary: Rating Groups | Rating Groups | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator RatingGroups46DD2 => AccountsReceivableHeading;

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator RentalOwnersLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Rental Owners Liability", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Contractors Equipment | Rental Reimbursement | Id+Name+DuckCreekId
    public ILocator RentalReimbursement => _page.Locator("input[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FED_3_1-inputEl\"][name=\"f_c48C85AB0259E43AE8BED26305EA4E022FED_3_1-inputEl\"][duckcreekid=\"ContractorsEquipmentInput.RentalReimbursementIndicator\"]");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Contractors Equipment | Rented Equipment Expense | Id+Name+DuckCreekId
    public ILocator RentedEquipmentExpense => _page.Locator("input[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FE5_3_1-inputEl\"][name=\"int_FE5\"][duckcreekid=\"ContractorsEquipmentInput.RentedEquipmentExpense\"]");

    // Source modules: Policy Covg | confidence=High score=95
    // Available when Umbrella Limit selected is in the "Over" category (e.g. Over 15M)
    // v56 raw Tosca primary: Policy Covg | Requested Umbrella Limit | DuckCreekId
    public ILocator RequestedUmbrellaLimit => _page.Locator("[duckcreekid=\"LineInput.RequestedUmbrellaLimit\"], [data-duckcreekid=\"LineInput.RequestedUmbrellaLimit\"]");

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The string result to verify
    public ILocator Result => _page.GetByLabel("Result", new() { Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator ReturnToQuote => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Quote", Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Risk - Main | Risk | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator Risk5D6FA => AccountsReceivableHeading;

    // Source modules: Risk - Main | confidence=High score=127
    // v56 raw Tosca primary: Risk - Main | Risk | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator Risk873E7 => AccountsReceivableHeading;

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator RiskAccountsReceivableOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator RiskBaileesCustomersOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Risk - Computer Systems | confidence=High score=125
    public ILocator RiskComputerSystemsOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Risk Aggregate | confidence=High score=127
    public ILocator RiskDDE70 => Risk873E7; // semantic alias; locator defined once

    // Source modules: GL OCP|Risk | confidence=High score=97
    // v56 raw Tosca primary: GL OCP|Risk | Risk Heading | Id
    // v56 semantic alias: same physical raw-Tosca control as AddlInterests15174
    public ILocator RiskHeading => AddlInterests15174;

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: BAP Navigation Links | State Details - Detail | Id
    // v56 semantic alias: same physical raw-Tosca control as AdditionalInterests
    public ILocator RiskSchedule => AdditionalInterests;

    // Source modules: Risk - Signs | confidence=High score=125
    public ILocator RiskSignsOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Rating Groups | confidence=High score=95
    // v56 raw Tosca primary: Rating Groups | Risk Type | DuckCreekId
    public ILocator RiskType => _page.Locator("[duckcreekid=\"RatingGroupInput.RiskType\"], [data-duckcreekid=\"RatingGroupInput.RiskType\"]");

    // Source modules: Building - Detail | confidence=High score=125
    // v56 raw Tosca primary: Building - Detail | Roof Type* | Id+Name+DuckCreekId
    public ILocator RoofType => _page.Locator("input[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0259_3_1-inputEl\"][name=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0259_3_1-inputEl\"][duckcreekid=\"BuildingInput.RoofType\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator SFP10LiabilityFarm => _page.GetByRole(AriaRole.Link, new() { Name = "SFP - 10 Liability/Farm", Exact = true });

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=97
    // v56 raw Tosca primary: SFP - 10 Liability/Farm | SFP - 10 Liability/Farm Heading | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator SFP10LiabilityFarmHeading => AccountsReceivableHeading;

    // Source modules: Common Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Insurance Designee | Save for Later | DuckCreekId
    public ILocator SaveForLater => _page.Locator("[duckcreekid=\"Save for Later\"], [data-duckcreekid=\"Save for Later\"]");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Contractors Equipment | Scheduled Coverage | Id+Name+DuckCreekId
    public ILocator ScheduledCoverage => _page.Locator("input[id=\"f_c48C85AB0259E43AE8BED26305EA4E02211F0_3_1-inputEl\"][name=\"f_c48C85AB0259E43AE8BED26305EA4E02211F0_3_1-inputEl\"][duckcreekid=\"ContractorsEquipmentInput.ScheduledCoverage\"]");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Risk - Computer Systems | Search Result | Id+Name+DuckCreekId
    public ILocator SearchResult4E620 => _page.Locator("input[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB111_1_1-inputEl\"][name=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB111_1_1-inputEl\"][duckcreekid=\"CovComputerSystemsInput.SearchResult\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator SearchResultA1BFB => SearchResult4E620; // semantic alias; locator defined once

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator SearchResultEAFB8 => SearchResult4E620; // semantic alias; locator defined once

    // Source modules: CGL|Add Class | confidence=High score=125
    // v56 raw Tosca primary: CGL|Add Class | Search Results | DuckCreekId
    public ILocator SearchResults5209C => _page.Locator("[duckcreekid=\"OccupancySearchInputNonShredded.SearchResults\"], [data-duckcreekid=\"OccupancySearchInputNonShredded.SearchResults\"]");

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator SearchResultsD0AA8 => SearchResults5209C; // semantic alias; locator defined once

    // Source modules:  | confidence=High score=125
    // v56 raw Tosca primary: Risk - Accounts Receivable | Search Value | Id+Name+DuckCreekId | frame=iframe
    public ILocator SearchValue53135 => _page.FrameLocator("iframe").Locator("input[id=\"f_rFE68631942E64B1BA3A954F11A424A139_1_1-inputEl\"][name=\"string_9|\"][duckcreekid=\"RiskInlandMarineInput.SearchValue\"]");

    // Source modules: Property Add Class | confidence=High score=125
    // v56 raw Tosca primary: Property Add Class | Search Value | DuckCreekId | frame=iframe
    public ILocator SearchValue54F3C => _page.FrameLocator("iframe").Locator("[duckcreekid=\"OccupancySearchInputNonShredded.SearchValue\"], [data-duckcreekid=\"OccupancySearchInputNonShredded.SearchValue\"]");

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator SearchValue79E46 => SearchValue54F3C; // semantic alias; locator defined once

    // Source modules: Risk - Computer Systems | confidence=High score=125
    public ILocator SearchValue9FCD1 => SearchValue54F3C; // semantic alias; locator defined once

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator SearchValueCA6A6 => SearchValue54F3C; // semantic alias; locator defined once

    // Source modules: Risk Schedule|General Coverage | confidence=High score=125
    // v56 raw Tosca primary: Risk Schedule|General Coverage | Seasonal Produce Trailers | DuckCreekId
    public ILocator SeasonalProduceTrailers => _page.Locator("[duckcreekid=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.SeasonalAgriculturalProduceTrailers\"], [data-duckcreekid=\"CovLiabilitySeasonalAgriculturalProduceTrailersInput.SeasonalAgriculturalProduceTrailers\"]");

    // Source modules: Location | confidence=High score=127
    // v56 raw Tosca primary: Location | Select | Id
    // v56 semantic alias: same physical raw-Tosca control as AdditionalInterests
    public ILocator Select => AdditionalInterests;

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Select Appropriate Code | Id+Name+DuckCreekId | frame=iframe
    public ILocator SelectAppropriateCode => _page.FrameLocator("iframe").Locator("input[id=\"f_aCDFD57747BFF44D9A3DDB9378170002825_2_1-inputEl\"][name=\"f_aCDFD57747BFF44D9A3DDB9378170002825_2_1-inputEl\"][duckcreekid=\"AdditionalOtherInterestLocationsInput.SICCodeDesc\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Select Class Code* | DuckCreekId | frame=iframe
    public ILocator SelectClassCode => _page.FrameLocator("iframe").Locator("[duckcreekid=\"NCCISearchInputNonShredded.SearchResults\"], [data-duckcreekid=\"NCCISearchInputNonShredded.SearchResults\"]");

    // Source modules: [CU0206] Utah Changes - Notice of Cancellation for Private Investigator Agencies | confidence=High score=125
    // v56 raw Tosca primary: [CU0206] Utah Changes - Notice of Cancellation for Private Investigator Agencies | Select Endorsement: | DuckCreekId
    public ILocator SelectEndorsement0EAB0 => _page.Locator("[duckcreekid=\"LineOutputNonShredded.EndorsementType\"], [data-duckcreekid=\"LineOutputNonShredded.EndorsementType\"]");

    // Source modules: [UC1101] Exclusion for Designated Activities or Services | confidence=High score=125
    public ILocator SelectEndorsement63E0E => SelectEndorsement0EAB0; // semantic alias; locator defined once

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Select NAICS Code | DuckCreekId | frame=iframe
    public ILocator SelectNAICSCode => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Select NAICS Code\"], [data-duckcreekid=\"Select NAICS Code\"]");

    // Source modules: Location | confidence=High score=125
    // v56 raw Tosca primary: Location | Select PPC | DuckCreekId
    public ILocator SelectPPC => _page.Locator("[duckcreekid=\"Select PPC\"], [data-duckcreekid=\"Select PPC\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Sex | Id+Name+DuckCreekId | frame=iframe
    public ILocator Sex => _page.FrameLocator("iframe").Locator("input[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D1_1_1-inputEl\"][name=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D1_1_1-inputEl\"][duckcreekid=\"DriverUnderwritingInformationInput.Gender\"]");

    // Source modules: Risk Aggregate | confidence=High score=95
    // v56 raw Tosca primary: Risk Aggregate | Show All Locations | DuckCreekId
    public ILocator ShowAllLocations => _page.Locator("[duckcreekid=\"LocationSelectInput.ShowAllLocations\"], [data-duckcreekid=\"LocationSelectInput.ShowAllLocations\"]");

    // Source modules: Risk - Signs | confidence=High score=125
    // v56 raw Tosca primary: Risk - Signs | Sign Location | Id+Name+DuckCreekId
    public ILocator SignLocation => _page.Locator("input[id=\"f_r99A2986D696A457DA1C69BB16D902CEF17_1_1-inputEl\"][name=\"f_r99A2986D696A457DA1C69BB16D902CEF17_1_1-inputEl\"][duckcreekid=\"CoverageSignsIteratorInput.SignLocation\"]");

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=97
    // v56 raw Tosca primary: Specific Underwriting Questions - Signs | Signs Heading | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator SignsHeading => AccountsReceivableHeading;

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: IM Navigation Links | Signs UW Questions | Id
    public ILocator SignsUWQuestions => _page.Locator("[id=\"ext-element-4171\"]");

    // Source modules: State Details|Main | confidence=High score=95
    // v56 raw Tosca primary: State Details|Main | Small Deductible* | DuckCreekId
    public ILocator SmallDeductible => _page.Locator("[duckcreekid=\"LineStateTermInput.SmallDeductibleCreditDeductible\"], [data-duckcreekid=\"LineStateTermInput.SmallDeductibleCreditDeductible\"]");

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=95
    // v56 raw Tosca primary: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Sole Proprietors* | DuckCreekId
    public ILocator SoleProprietors => _page.Locator("[duckcreekid=\"EndorsementSoleProprietors.SoleProprietors\"], [data-duckcreekid=\"EndorsementSoleProprietors.SoleProprietors\"]");

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    public ILocator SoleProprietorsPartnersOfficersAndOthersCoverageOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: IM Navigation Links | Accounts Receivable UW Questions | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableUWQuestions
    public ILocator SpecificUnderwritingQuestions => AccountsReceivableUWQuestions;

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsAccountsReceivableOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsBaileesCustomerOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsComputerSystemsOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsContractorsEquipmentOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsMotorTruckCargoOwnersOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsSignsOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: Policy Covg|GL | Split BI Ded | attributes_fieldref
    public ILocator SplitBIDed => _page.Locator("[fieldref=\"LineInput.SeparateProductsDeductible\"], [data-fieldref=\"LineInput.SeparateProductsDeductible\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: Policy Covg|GL | Split PD Ded | attributes_fieldref
    public ILocator SplitPDDed => _page.Locator("[fieldref=\"LineInput.SeparateProductsPDDeductible\"], [data-fieldref=\"LineInput.SeparateProductsPDDeductible\"]");

    // Source modules: Building - Detail | confidence=High score=125
    // v56 raw Tosca primary: Building - Detail | Square Feet | Id+Name+DuckCreekId
    public ILocator SquareFeet => _page.Locator("input[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0245_3_1-inputEl\"][name=\"int_245\"][duckcreekid=\"BuildingInput.SquareFt\"]");

    // Source modules: GL OCP|Risk | confidence=High score=124
    // v56 raw Tosca primary: GL OCP|Risk | State | attributes_fieldref | frame=iframe
    public ILocator State16B92 => _page.FrameLocator("iframe").Locator("[fieldref=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderState\"], [data-fieldref=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderState\"]");

    // Source modules:  | confidence=High score=125
    // v56 raw Tosca primary: Designated Construction Projects(s) General Aggregate Limit | -- State | DuckCreekId | frame=iframe
    public ILocator State64A10 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"EndAmendmentAggregateLimitsOfInsuranceInput.State\"], [data-duckcreekid=\"EndAmendmentAggregateLimitsOfInsuranceInput.State\"]");

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    // v56 raw Tosca primary: Endorsements|Designated Workplaces Exclusion | State* | DuckCreekId | frame=iframe
    public ILocator State89468 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"DesignatedWorkplace.State\"], [data-duckcreekid=\"DesignatedWorkplace.State\"]");

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: State Details|UM/UIM | State Details | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator StateDetails33183 => AccountsReceivableHeading;

    // Source modules: State Details|UM/UIM | confidence=High score=127
    // v56 raw Tosca primary: State Details|UM/UIM | State Details | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator StateDetails72631 => AccountsReceivableHeading;

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator StateDetailsB407B => StateDetails33183; // semantic alias; locator defined once

    // Source modules: BAP Navigation Links | confidence=High score=127
    // v56 raw Tosca primary: BAP Navigation Links | State Details - Detail | Id
    // v56 semantic alias: same physical raw-Tosca control as AdditionalInterests
    public ILocator StateDetailsDetail => AdditionalInterests;

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | State Licensed* | Id+Name+DuckCreekId | frame=iframe
    public ILocator StateLicensed => _page.FrameLocator("iframe").Locator("input[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D5_1_1-inputEl\"][name=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D5_1_1-inputEl\"][duckcreekid=\"DriverUnderwritingInformationInput.StateLicensed\"]");

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    // v56 raw Tosca primary: [CG 29 35] Add'l Insured-State or Political (Permits) | State or Political Subdivision* | DuckCreekId
    public ILocator StateOrPoliticalSubdivision => _page.Locator("[duckcreekid=\"AdditionalOtherInterestInput.Name\"], [data-duckcreekid=\"AdditionalOtherInterestInput.Name\"]");

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Vehicle Information | Stated Amount* | DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as OriginalCostNew
    public ILocator StatedAmount => OriginalCostNew;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator StoplightMessageTotalSubjectPremium => _page.GetByText("Stoplight Message: Total Subject Premium", new() { Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v56 raw Tosca primary: Risk - Bailees Customers | Storage Limit | Id+Name+DuckCreekId
    public ILocator StorageLimit => _page.Locator("input[id=\"f_c1130867FA0E9485FBAA81AF587517408A3_1_1-inputEl\"][name=\"int_A3\"][duckcreekid=\"CovBaileesCustomersInput.StorageLimit\"]");

    // Source modules: Building - Detail | confidence=High score=125
    // v56 raw Tosca primary: Building - Detail | Stories | Id+Name+DuckCreekId
    public ILocator Stories => _page.Locator("input[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0247_3_1-inputEl\"][name=\"int_247\"][duckcreekid=\"BuildingInput.NumberOfStories\"]");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator Submission => _page.GetByRole(AriaRole.Link, new() { Name = "Submission", Exact = true });

    // Source modules: Submission|Required and Optional Fields | confidence=High score=127
    public ILocator SubmissionHeading => _page.GetByLabel("Submission Heading", new() { Exact = true });

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Physical Damage | Tapes Coverage | Id+Name+DuckCreekId
    public ILocator TapesCoverage => _page.Locator("input[id=\"f_cA3C9AC7006E9416C9517BA15BC2DCE5F2364_2_1-inputEl\"][name=\"f_cA3C9AC7006E9416C9517BA15BC2DCE5F2364_2_1-inputEl\"][duckcreekid=\"CovTapesInput.Tapes\"]");

    // Source modules: NotePad | confidence=High score=124
    public ILocator TextBox => _page.GetByRole(AriaRole.Textbox, new() { Name = "TextBox", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Client|Third Party Designee|Common | Third Party Designee | DuckCreekId
    public ILocator ThirdPartyDesignee => _page.Locator("[duckcreekid=\"Third Party Designee\"], [data-duckcreekid=\"Third Party Designee\"]");

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // Defines the caption of the browser window that is searched for.
    public ILocator Title => _page.GetByLabel("Title", new() { Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Contractors Equipment | Tools And Clothing Belonging To Your Employees | Id+Name+DuckCreekId
    public ILocator ToolsAndClothingBelongingToYourEmployees => _page.Locator("input[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FEB_3_1-inputEl\"][name=\"f_c48C85AB0259E43AE8BED26305EA4E022FEB_3_1-inputEl\"][duckcreekid=\"ContractorsEquipmentInput.EmployeesToolsAndClothingIndicator\"]");

    // Source modules: GL OCP|Risk | confidence=High score=125
    // v56 raw Tosca primary: GL OCP|Risk | Total Cost of Work* | Id+Name+DuckCreekId
    public ILocator TotalCostOfWork => _page.Locator("input[id=\"f_c630D2C33C75147EEB931C5458A61AA7041_3_1-inputEl\"][name=\"int_41\"][duckcreekid=\"CovOwnersContractorsOrPrincipalsInput.UnitsOfExposureEstimated\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Total Payroll (Estimated) | DuckCreekId | frame=iframe
    public ILocator TotalPayrollEstimated => _page.FrameLocator("iframe").Locator("[duckcreekid=\"CoverageInput.UnitsOfExposureEstimated\"], [data-duckcreekid=\"CoverageInput.UnitsOfExposureEstimated\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator TotalPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Premium", Exact = true });

    // Source modules: General Liability | confidence=High score=125
    // v56 raw Tosca primary: General Liability | Total Subject Premium* | DuckCreekId
    public ILocator TotalSubjectPremium19B44 => _page.Locator("[duckcreekid=\"UmbrellaGeneralLiabilityInputPremiums.TotalSubjectPremium\"], [data-duckcreekid=\"UmbrellaGeneralLiabilityInputPremiums.TotalSubjectPremium\"]");

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    public ILocator TotalSubjectPremiumAF452 => TotalSubjectPremium19B44; // semantic alias; locator defined once

    // Source modules: Businessowners | confidence=High score=125
    public ILocator TotalSubjectPremiumE8AF0 => TotalSubjectPremium19B44; // semantic alias; locator defined once

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Physical Damage | Towing | DuckCreekId
    public ILocator Towing => _page.Locator("[duckcreekid=\"CovTowingInput.Towing\"], [data-duckcreekid=\"CovTowingInput.Towing\"]");

    // Source modules: Policy Coverage|Limits | confidence=High score=125
    // v56 raw Tosca primary: Policy Coverage|Limits | Trailer Interchange Collision Deductible | DuckCreekId
    public ILocator TrailerInterchangeCollisionDeductible => _page.Locator("[duckcreekid=\"RiskDefaultsInput.TrailerInterchangeCollisionDeductible\"], [data-duckcreekid=\"RiskDefaultsInput.TrailerInterchangeCollisionDeductible\"]");

    // Source modules: Policy Coverage|Limits | confidence=High score=125
    // v56 raw Tosca primary: Policy Coverage|Limits | Trailer Interchange Comp Deductible | DuckCreekId
    public ILocator TrailerInterchangeCompDeductible => _page.Locator("[duckcreekid=\"RiskDefaultsInput.TrailerInterchangeComprehensiveDeductible\"], [data-duckcreekid=\"RiskDefaultsInput.TrailerInterchangeComprehensiveDeductible\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Trailer Interchange - Enter # Days Insured | DuckCreekId | frame=iframe
    public ILocator TrailerInterchangeEnterDaysInsured => _page.FrameLocator("iframe").Locator("[duckcreekid=\"TrailerInterchangeInput.NumberOfDaysInsuredEstimate\"], [data-duckcreekid=\"TrailerInterchangeInput.NumberOfDaysInsuredEstimate\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Trailer Interchange - Enter # of Trailers | DuckCreekId | frame=iframe
    public ILocator TrailerInterchangeEnterOfTrailers => _page.FrameLocator("iframe").Locator("[duckcreekid=\"TrailerInterchangeInput.NumberOfTrailersEstimate\"], [data-duckcreekid=\"TrailerInterchangeInput.NumberOfTrailersEstimate\"]");

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    // v56 raw Tosca primary: [FG 00 13] Automatic Additional Insured - Specific Relationship | Type | attributes_fieldref | frame=iframe
    public ILocator Type56F72 => _page.FrameLocator("iframe").Locator("[fieldref=\"AdditionalOtherInterestInput.Type\"], [data-fieldref=\"AdditionalOtherInterestInput.Type\"]");

    // Source modules: Endorsement - Main | confidence=High score=125
    // v56 raw Tosca primary: Endorsement - Main | Type | Id+Name+DuckCreekId | frame=iframe
    public ILocator Type715D6 => _page.FrameLocator("iframe").Locator("input[id=\"f_c4CBF9D54B72F454488F8BD49B282C532C8_3_10-inputEl\"][name=\"f_c4CBF9D54B72F454488F8BD49B282C532C8_3_10-inputEl\"][duckcreekid=\"CovEndorsementInput.Type\"]");

    // Source modules: GL OCP|Risk | confidence=High score=124
    public ILocator Type885AA => Type56F72; // semantic alias; locator defined once

    // Source modules: [CG 20 20] Add'l Insured-Charitable Institution | confidence=High score=125
    public ILocator TypeA75B5 => Type715D6; // semantic alias; locator defined once

    // Source modules: Risk - Signs | confidence=High score=125
    public ILocator TypeB082D => Type715D6; // semantic alias; locator defined once

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    public ILocator TypeCDE3B => Type715D6; // semantic alias; locator defined once

    // Source modules: [CG 20 07] Add'l Insured-Engineers, Architects | confidence=High score=125
    public ILocator TypeD0639 => Type715D6; // semantic alias; locator defined once

    // Source modules:  | confidence=High score=125
    public ILocator TypeD972C => Type715D6; // semantic alias; locator defined once

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Contractors Equipment | Type Of Contractor | Id+Name+DuckCreekId
    public ILocator TypeOfContractor => _page.Locator("input[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FCB_3_1-inputEl\"][name=\"f_c48C85AB0259E43AE8BED26305EA4E022FCB_3_1-inputEl\"][duckcreekid=\"ContractorsEquipmentInput.TypeOfContractor\"]");

    // Source modules: [CG 20 34] Add'l Insured-Leased Equipment Automatic  | confidence=High score=95
    // v56 raw Tosca primary: [CG 20 34] Add'l Insured-Leased Equipment Automatic | Type of Equipment | DuckCreekId
    public ILocator TypeOfEquipment => _page.Locator("[duckcreekid=\"AdditionalOtherInterestInput.EquipmentType\"], [data-duckcreekid=\"AdditionalOtherInterestInput.EquipmentType\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Type of Interest | DuckCreekId | frame=iframe
    public ILocator TypeOfInterest => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.Type\"], [data-duckcreekid=\"AdditionalOtherInterestInput.Type\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: [CG 20 20] Add'l Insured-Charitable Institution | Type of License | attributes_fieldref
    public ILocator TypeOfLicense => _page.Locator("[fieldref=\"AdditionalOtherInterestInput.DescriptionOfCompletedOps\"], [data-fieldref=\"AdditionalOtherInterestInput.DescriptionOfCompletedOps\"]");

    // Source modules: State Details|UM/UIM | confidence=High score=95
    // v56 raw Tosca primary: State Details|UM/UIM | UMBI Limit* | DuckCreekId
    public ILocator UMBILimit => _page.Locator("[duckcreekid=\"{REGEX[\"LineStateUMDefaultsInput.UMBIPDLimit|LineStateUMDefaultsInput.UMBILimit\"]}\"], [data-duckcreekid=\"{REGEX[\"LineStateUMDefaultsInput.UMBIPDLimit|LineStateUMDefaultsInput.UMBILimit\"]}\"]");

    // Source modules: State Details|UM/UIM | confidence=High score=95
    // v56 raw Tosca primary: State Details|UM/UIM | UM Type Default Selections | DuckCreekId
    public ILocator UMTypeDefaultSelections => _page.Locator("[duckcreekid=\"LineStateUMDefaultsInput.UMType\"], [data-duckcreekid=\"LineStateUMDefaultsInput.UMType\"]");

    // Source modules: State Details|UM/UIM | confidence=High score=125
    public ILocator UMUIMOK => AddClassOK; // semantic alias; locator defined once

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Underwriting Questions | UW Questions | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator UWQuestions368CC => AccountsReceivableHeading;

    // Source modules: Underwriting Questions | confidence=High score=127
    // v56 raw Tosca primary: Underwriting Questions | UW Questions | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator UWQuestionsF3D9F => AccountsReceivableHeading;

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: UW Questions - Umbrella | UW Questions - Umbrella | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator UWQuestionsUmbrella9F47E => AccountsReceivableHeading;

    // Source modules: UW Questions - Umbrella | confidence=High score=127
    // v56 raw Tosca primary: UW Questions - Umbrella | UW Questions - Umbrella | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountsReceivableHeading
    public ILocator UWQuestionsUmbrellaFF014 => AccountsReceivableHeading;

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator UWQuestionsWorkersComp => _page.GetByRole(AriaRole.Link, new() { Name = "UW Questions - Workers Comp", Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg | Umbrella Limit | DuckCreekId
    public ILocator UmbrellaLimit => _page.Locator("[duckcreekid=\"LineInput.UmbrellaLimit\"], [data-duckcreekid=\"LineInput.UmbrellaLimit\"]");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator UnderwritingInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Computer Systems | Uninterruptible power source?* | Id+Name+DuckCreekId
    public ILocator UninterruptiblePowerSource => _page.Locator("input[id=\"f_c7FA512A090F641B9A6BB95F4C656EE183E_2_21-inputEl\"][name=\"f_c7FA512A090F641B9A6BB95F4C656EE183E_2_21-inputEl\"][duckcreekid=\"ComputerSystemsUnderwritingQuestionsInput.UPSIndicator\"]");

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Computer Systems | Unnamed Premises | Id+Name+DuckCreekId
    public ILocator UnnamedPremises => _page.Locator("input[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8A_3_4-inputEl\"][name=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8A_3_4-inputEl\"][duckcreekid=\"ComputerSystemsInput.UnnamedPremisesIndicator\"]");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Motor Truck Cargo | Unnamed Terminals Limit | Id+Name+DuckCreekId
    public ILocator UnnamedTerminalsLimit => _page.Locator("input[id=\"f_cB85F41925276456C81E1ED1306A2AB401095_3_5-inputEl\"][name=\"int_1095\"][duckcreekid=\"MotorTruckCargoInput.UnnamedTerminalsLimit\"]");

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Contractors Equipment | Update Answers | DuckCreekId
    public ILocator UpdateAnswers3DA0B => _page.Locator("[duckcreekid=\"Update Answers\"], [data-duckcreekid=\"Update Answers\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    public ILocator UpdateAnswers3DDA2 => UpdateAnswers3DA0B; // semantic alias; locator defined once

    // Source modules: Products/Completed Ops | confidence=High score=125
    public ILocator UpdateAnswers69564 => UpdateAnswers3DA0B; // semantic alias; locator defined once

    // Source modules: UW Questions - Workers Comp | confidence=High score=125
    public ILocator UpdateAnswers6FF76 => UpdateAnswers3DA0B; // semantic alias; locator defined once

    // Source modules: Property UW Questions | confidence=High score=125
    public ILocator UpdateAnswers99D68 => UpdateAnswers3DA0B; // semantic alias; locator defined once

    // Source modules: Underwriting Info | General UW Questions | confidence=Medium score=113
    // v56 raw Tosca primary: Property UW Questions | Update Answers | DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as UpdateAnswers3DA0B
    public ILocator UpdateAnswers9CB86 => UpdateAnswers3DA0B;

    // Source modules: UW Questions - Umbrella | confidence=High score=125
    public ILocator UpdateAnswersB41BE => UpdateAnswers3DA0B; // semantic alias; locator defined once

    // Source modules: Underwriting Questions | confidence=High score=125
    // v56 raw Tosca primary: Underwriting Questions | Update Answers Button | DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as UpdateAnswers3DA0B
    public ILocator UpdateAnswersButton => UpdateAnswers3DA0B;

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=125
    public ILocator UpdateAnswersD8A16 => UpdateAnswers3DA0B; // semantic alias; locator defined once

    // Source modules: General Liability Information | confidence=High score=125
    public ILocator UpdateAnswersFB765 => UpdateAnswers3DA0B; // semantic alias; locator defined once

    // Source modules: Risk Schedule|General Coverage | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|General Coverage | Used As Showroom | DuckCreekId
    public ILocator UsedAsShowroom => _page.Locator("[duckcreekid=\"RiskCommercialAutoRiskInput.UsedAsShowroom\"], [data-duckcreekid=\"RiskCommercialAutoRiskInput.UsedAsShowroom\"]");

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=125
    // v56 raw Tosca primary: Risk Schedule|Vehicle Information | VIN* | DuckCreekId
    public ILocator VIN => _page.Locator("[duckcreekid=\"RiskVehicleInput.VIN\"], [data-duckcreekid=\"RiskVehicleInput.VIN\"]");

    // Source modules: Property - Main | confidence=High score=95
    // v56 raw Tosca primary: Property - Main | Vacancy Permit | DuckCreekId
    public ILocator VacancyPermit => _page.Locator("[duckcreekid=\"BuildingInput.VacancyPermit\"], [data-duckcreekid=\"BuildingInput.VacancyPermit\"]");

    // Source modules: Property - Main | confidence=High score=95
    // v56 raw Tosca primary: Property - Main | Vacant Building | DuckCreekId
    public ILocator VacantBuilding => _page.Locator("[duckcreekid=\"BuildingInput.VacantBuilding\"], [data-duckcreekid=\"BuildingInput.VacantBuilding\"]");

    // Source modules: Rating Groups | confidence=High score=95
    // v56 raw Tosca primary: Rating Groups | Valuation | DuckCreekId
    public ILocator Valuation => _page.Locator("[duckcreekid=\"RatingGroupInput.ValuationType\"], [data-duckcreekid=\"RatingGroupInput.ValuationType\"]");

    // Source modules: Property Enter Building RCT | confidence=High score=125
    // v56 raw Tosca primary: Property Enter Building RCT | Valuation Type* | DuckCreekId
    public ILocator ValuationType => _page.Locator("[duckcreekid=\"BuildingValuatioinInput.ValuationType\"], [data-duckcreekid=\"BuildingValuatioinInput.ValuationType\"]");

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=95
    // v56 raw Tosca primary: Risk Schedule|Vehicle Information | Value Basis | DuckCreekId
    public ILocator ValueBasis => _page.Locator("[duckcreekid=\"RiskVehicleInput.StatedAmountIndicator\"], [data-duckcreekid=\"RiskVehicleInput.StatedAmountIndicator\"]");

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=125
    // v56 raw Tosca primary: State Details|Hired Auto Physical Damage With Driver | Vehicle Information | DuckCreekId
    public ILocator VehicleInformation => _page.Locator("[duckcreekid=\"RiskHiredAndBorrowedWithDriverVehicleIteratorInput.VehicleInformation\"], [data-duckcreekid=\"RiskHiredAndBorrowedWithDriverVehicleIteratorInput.VehicleInformation\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator VehicleSchedule1Veh => _page.GetByText("Veh #", new() { Exact = true });

    // Source modules: Risk Aggregate | confidence=High score=125
    // v56 raw Tosca primary: Risk Aggregate | Vehicle Type | DuckCreekId
    public ILocator VehicleType => _page.Locator("[duckcreekid=\"LineInputNonShredded.VehicleType\"], [data-duckcreekid=\"LineInputNonShredded.VehicleType\"]");

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Computer Systems | Virus, Harmful Code Or Similar Instruction | Id+Name+DuckCreekId
    public ILocator VirusHarmfulCodeOrSimilarInstruction => _page.Locator("input[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8D_3_4-inputEl\"][name=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8D_3_4-inputEl\"][duckcreekid=\"ComputerSystemsInput.VirusIndicator\"]");

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    // v56 raw Tosca primary: State Details|Hired Auto Liability | Volunteer Hired Autos CheckBox | attributes_fieldref
    public ILocator VolunteerHiredAutosCheckBox => _page.Locator("[fieldref=\"LineStateInput.VolunteerHiredAuto\"], [data-fieldref=\"LineStateInput.VolunteerHiredAuto\"]");

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator WCSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "WC Schedule", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator WaitonPricingHeadingAndFillOutRequiredFields => _page.GetByText("Waiton Pricing Heading and Fill Out Required Fields", new() { Exact = true });

    // Source modules: State Details|Main | confidence=High score=95
    // v56 raw Tosca primary: State Details|Main | Waiver Of Subrogation | DuckCreekId
    public ILocator WaiverOfSubrogation => _page.Locator("[duckcreekid=\"LineStateTermInput.WaiverOfSubrogation\"], [data-duckcreekid=\"LineStateTermInput.WaiverOfSubrogation\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Waiver Of Subrogation Exposure* | DuckCreekId | frame=iframe
    public ILocator WaiverOfSubrogationExposure => _page.FrameLocator("iframe").Locator("[duckcreekid=\"CoverageInput.WaiverOfSubrogationExposure\"], [data-duckcreekid=\"CoverageInput.WaiverOfSubrogationExposure\"]");

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days => _page.GetByRole(AriaRole.Textbox, new() { Name = "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    // v56 raw Tosca primary: Specific Underwriting Questions - Computer Systems | What are the procedures and methods for keeping the EDP areas secured? | attributes_fieldref
    // v56 semantic alias: same physical raw-Tosca control as HowOftenIsDataBackedUp
    public ILocator WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured => HowOftenIsDataBackedUp;

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    // v56 raw Tosca primary: Specific Underwriting Questions - Computer Systems | What are the procedures and schedule for backing up the media and data and their storage? | attributes_fieldref
    // v56 semantic alias: same physical raw-Tosca control as HowOftenIsDataBackedUp
    public ILocator WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage => HowOftenIsDataBackedUp;

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=124
    // v56 raw Tosca primary: Specific Underwriting Questions - Signs | What is the construction of each sign? | attributes_fieldref
    public ILocator WhatIsTheConstructionOfEachSign => _page.Locator("[fieldref=\"SignsUnderwritingQuestionsInput.Description\"], [data-fieldref=\"SignsUnderwritingQuestionsInput.Description\"]");

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=124
    // v56 raw Tosca primary: Specific Underwriting Questions - Accounts Receivable | What is the construction of the premises where the receivables are stored? | attributes_fieldref
    public ILocator WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored => _page.Locator("[fieldref=\"AccountsReceivableUnderwritingQuestionsInput.Description\"], [data-fieldref=\"AccountsReceivableUnderwritingQuestionsInput.Description\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Computer Systems | What is the distance in feet to the nearest fire hydrant? | Id+Name+DuckCreekId
    public ILocator WhatIsTheDistanceInFeetToTheNearestFireHydrant => _page.Locator("input[id=\"f_cD3F347C9072D47E4BDC9B2BEE6F633CD38_2_15-inputEl\"][name=\"float_38|????.00\"][duckcreekid=\"ComputerSystemsUnderwritingQuestionsInput.HydrantDistance\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Computer Systems | What is the distance in miles to the nearest responding fire department?* | Id+Name+DuckCreekId
    public ILocator WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment => _page.Locator("input[id=\"f_cD3F347C9072D47E4BDC9B2BEE6F633CD3B_2_15-inputEl\"][name=\"float_3B|????.00\"][duckcreekid=\"ComputerSystemsUnderwritingQuestionsInput.FireDeptDistance\"]");

    // Source modules:  | confidence=High score=95
    // Required for Commit/ Submission
    public ILocator WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational => _page.GetByRole(AriaRole.Textbox, new() { Name = "What is the primary reason this new policy is being rewritten with Farm Family/American National?*", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Computer Systems | Line conditioner?* | Id+Name+DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as LineConditioner
    public ILocator WhatIsTheProcedureForTransportingTheComputerEquipment => LineConditioner;

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Computer Systems | What is the public protection class rating?* | Id+Name+DuckCreekId
    public ILocator WhatIsThePublicProtectionClassRating => _page.Locator("input[id=\"f_cD3F347C9072D47E4BDC9B2BEE6F633CD35_2_15-inputEl\"][name=\"string_35|\"][duckcreekid=\"ComputerSystemsUnderwritingQuestionsInput.PublicProtectionClass\"]");

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=124
    // v56 raw Tosca primary: Specific Underwriting Questions - Accounts Receivable | What safeguards are in place for receivables to protect against damage or theft? | attributes_fieldref
    // v56 semantic alias: same physical raw-Tosca control as WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored
    public ILocator WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft => WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored;

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v56 raw Tosca primary: Specific Underwriting Questions - Motor Truck Cargo(Owners) | Which form are you completing? | Id+Name+DuckCreekId
    public ILocator WhichFormAreYouCompleting => _page.Locator("input[id=\"f_u90F32F80C0574D33AD962F038C8FC2AF56_2_1-inputEl\"][name=\"f_u90F32F80C0574D33AD962F038C8FC2AF56_2_1-inputEl\"][duckcreekid=\"UnderwritingQuestionsInput.MotorTruckFormSelection\"]");

    // Source modules: [CG0424] Coverage for Injury to Leased Workers | confidence=High score=124
    // v56 raw Tosca primary: [CG0424] Coverage for Injury to Leased Workers | Why is this coverage desired? | attributes_fieldref
    // v56 semantic alias: same physical raw-Tosca control as DescriptionOfOperationS
    public ILocator WhyIsThisCoverageDesired => DescriptionOfOperationS;

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=125
    // v56 raw Tosca primary: Risk Schedule|Vehicle Information | Year* | DuckCreekId
    public ILocator Year => _page.Locator("[duckcreekid=\"RiskVehicleInput.Year\"], [data-duckcreekid=\"RiskVehicleInput.Year\"]");

    // Source modules: Building - Detail | confidence=High score=125
    // v56 raw Tosca primary: Building - Detail | Year Built | Id+Name+DuckCreekId
    public ILocator YearBuilt => _page.Locator("input[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0243_3_1-inputEl\"][name=\"int_243\"][duckcreekid=\"BuildingInput.YearBuilt\"]");

    // Source modules:  | confidence=High score=95
    // v56 raw Tosca primary:  | Year Licensed | Id+Name+DuckCreekId | frame=iframe
    public ILocator YearLicensed => _page.FrameLocator("iframe").Locator("input[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D4_1_1-inputEl\"][name=\"int_10D4\"][duckcreekid=\"DriverUnderwritingInformationInput.YearLicensed\"]");

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    // BAP, BOP, CPP, CP, IM, CR, SUMB ONLY (JULY-20)
    public ILocator YearsInBusiness => _page.GetByRole(AriaRole.Textbox, new() { Name = "Years In Business", Exact = true });

    // Source modules:  | confidence=High score=125
    // v56 raw Tosca primary: GL OCP|Risk | Zip Code | Id+Name+DuckCreekId | frame=iframe
    public ILocator ZipCodeB286B => _page.FrameLocator("iframe").Locator("input[id=\"f_c630D2C33C75147EEB931C5458A61AA7062_3_1-inputEl\"][name=\"string_62|zipcode\"][duckcreekid=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderZipCode\"]");

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    // v56 raw Tosca primary: Client|Third Party Designee|Common | Zip Code* | DuckCreekId | frame=iframe
    public ILocator ZipCodeBCEA0 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.ZipCode\"], [data-duckcreekid=\"AdditionalOtherInterestInput.ZipCode\"]");

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    public ILocator ZipCodeC048F => ZipCodeB286B; // semantic alias; locator defined once

    // Source modules: GL OCP|Risk | confidence=High score=125
    public ILocator ZipCodeC7591 => ZipCodeB286B; // semantic alias; locator defined once

    // Source modules: Location | confidence=High score=125
    public ILocator ZipCodeD2DBA => ZipCodeB286B; // semantic alias; locator defined once


    public ILocator EntityInfoFrameEntityInfoWindowFax => _page.Locator("[id=\"AdditionalOtherInterestInput.Fax\"], [name=\"AdditionalOtherInterestInput.Fax\"], [data-testid=\"AdditionalOtherInterestInput.Fax\"], [data-duckcreekid=\"AdditionalOtherInterestInput.Fax\"]").First;


    public ILocator EntityInfoFrameEntityInfoWindowBureauNumber => _page.Locator("[id=\"AdditionalOtherInterestInput.BureauNumber\"], [name=\"AdditionalOtherInterestInput.BureauNumber\"], [data-testid=\"AdditionalOtherInterestInput.BureauNumber\"], [data-duckcreekid=\"AdditionalOtherInterestInput.BureauNumber\"]").First;


    public ILocator EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault => _page.Locator("[id=\"AdditionalOtherInterestInput.StateUnemploymentNumber\"], [name=\"AdditionalOtherInterestInput.StateUnemploymentNumber\"], [data-testid=\"AdditionalOtherInterestInput.StateUnemploymentNumber\"], [data-duckcreekid=\"AdditionalOtherInterestInput.StateUnemploymentNumber\"]").First;

}
