using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class NavigationLocators
{
    private readonly IPage _page;
    public NavigationLocators(IPage page) => _page = page;

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Physical Damage | AV Cost New* | guid=3a13d49c-16f1-302e-fdf6-c3352fc7e075 | strategy=retained-semantic
    public ILocator AVCostNew => _page.GetByRole(AriaRole.Textbox, new() { Name = "AV Cost New*", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | a. What is the public Protection class rating? | guid=3a13d49c-172d-78a2-ff55-91bb9032814e | strategy=id
    public ILocator AWhatIsThePublicProtectionClassRating => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B170_2_8-inputEl\"]");

    // Source modules: Risk Schedule|Liability, UM, Medical & PIP | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Liability, UM, Medical & PIP | Accept UM | guid=3a13d49c-16f1-ea3d-0bc2-a7595e6c175e | strategy=associatedlabel-from-v55
    public ILocator AcceptUM => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Accept UM");

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=97
    // v57 raw Tosca: Specific Underwriting Questions - Accounts Receivable | Accounts Receivable Heading | guid=3a13d49c-172d-d12e-b14d-c5c2d366b2bb | strategy=id
    public ILocator AccountsReceivableHeading => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-d12e-b14d-c5c2d366b2bb");

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: IM Navigation Links | Accounts Receivable UW Questions | guid=3a13d49c-172d-af92-7832-f64cb836b44b | strategy=role-link
    public ILocator AccountsReceivableUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Accounts Receivable", Exact = true });

    // Source modules: Risk - Main | confidence=High score=125
    // v57 raw Tosca: Risk - Main | Add | guid=3a13d49c-172d-cc82-08dc-f8eac8bf8b09 | strategy=role-link
    public ILocator Add => _page.GetByRole(AriaRole.Link, new() { Name = "Add", Exact = true });

    // Source modules: Addl Interests|Main | confidence=High score=125
    // v57 raw Tosca: Addl Interests|Main | Add Addl Interest | guid=3a13d49c-1700-0134-c700-7d3db201a56b | strategy=role-link
    public ILocator AddAddlInterest => _page.GetByRole(AriaRole.Link, new() { Name = "Add Addl Interest", Exact = true });

    // Source modules: Building - Main | confidence=High score=125
    // v57 raw Tosca: Building - Main | Add Building | guid=3a13d49c-1700-5825-2523-0323d0909d3d | strategy=role-link
    public ILocator AddBuilding => _page.GetByRole(AriaRole.Link, new() { Name = "Add Building", Exact = true });

    // Source modules: CGL|Main Page | confidence=High score=125
    // v57 raw Tosca: CGL|Main Page | Add Class | guid=3a13d49c-1700-1564-5aa7-845da28e0feb | strategy=role-link
    public ILocator AddClassB04B6 => _page.GetByRole(AriaRole.Link, new() { Name = "Add Class", Exact = true });

    // Source modules: WC Schedule|Main Page | confidence=High score=125
    // v57 raw Tosca: WC Schedule|Main Page | Add Class Code | guid=3a13d49c-1688-a270-c0e6-67ee47df1914 | strategy=role-link
    public ILocator AddClassCode => _page.GetByRole(AriaRole.Link, new() { Name = "Add Class Code", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    // v57 raw Tosca: Property Add Class | Add Class | guid=3a13d49c-1700-edea-1b88-a7fdfd1c96a4 | strategy=role-link
    public ILocator AddClassDCD8F => _page.GetByRole(AriaRole.Link, new() { Name = "Add Class", Exact = true });

    // Source modules: CGL|Add Class | confidence=High score=125
    // v57 raw Tosca: CGL|Add Class | OK | guid=3a13d49c-1700-c05b-7bd6-d371628cdb8a | strategy=role-link
    public ILocator AddClassOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Main | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Main | Add Coverage Form | guid=3a13d49c-172d-e6d1-13bd-997e7f292085 | strategy=role-link
    public ILocator AddCoverageForm => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-e6d1-13bd-997e7f292085");

    // Source modules: Driver Schedule | confidence=High score=125
    // v57 raw Tosca: Driver Schedule | Add Driver | guid=3a13d49c-16f1-9298-0514-0b9df57d01cc | strategy=role-link
    public ILocator AddDriver => _page.GetByRole(AriaRole.Link, new() { Name = "Add Driver", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Add Driver Name | guid=3a13d49c-16f1-109e-2caa-19485156b57a | strategy=id
    public ILocator AddDriverName => _page.Locator("[id=\"f_eC9B5D952311D4E46BAAE946A2A0730E51034_1_1-inputEl\"]");

    // Source modules: [CU0206] Utah Changes - Notice of Cancellation for Private Investigator Agencies | confidence=High score=125
    // v57 raw Tosca: [CU0206] Utah Changes - Notice of Cancellation for Private Investigator Agencies | Add Endorsement | guid=3a13d49c-171e-7082-bdf4-e3a5b2da466a | strategy=role-link
    public ILocator AddEndorsement04BD0 => _page.GetByRole(AriaRole.Link, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: BOP Expanded Endorsements|Add Endorsement | confidence=High score=125
    // v57 raw Tosca: BOP Expanded Endorsements|Add Endorsement | Add Endorsement | guid=3a13d49c-1700-6e27-4314-ee8fed0e2f49 | strategy=role-link
    public ILocator AddEndorsement34EE3 => _page.GetByRole(AriaRole.Link, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    // v57 raw Tosca: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Add Endorsement | guid=3a13d49c-172d-77d5-26c0-c6685aabe4cf | strategy=role-link
    public ILocator AddEndorsement44E6A => _page.GetByRole(AriaRole.Link, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Endorsement - Main | confidence=High score=125
    // v57 raw Tosca: Endorsement - Main | Add Endorsement | guid=3a13d49c-172d-02ef-7988-aba5e6bc5280 | strategy=role-link
    public ILocator AddEndorsement48A9E => _page.GetByRole(AriaRole.Link, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    // v57 raw Tosca: Endorsements|Designated Workplaces Exclusion | Add Endorsement | guid=3a13d49c-172d-ce4a-9c93-7371f93564b8 | strategy=role-link
    public ILocator AddEndorsement9E5F4 => _page.GetByRole(AriaRole.Link, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Endorsements|Main | confidence=High score=125
    // v57 raw Tosca: Endorsements|Main | Add Endorsement | guid=3a13d49c-1700-5aa5-ccad-be01b1072c20 | strategy=role-link
    public ILocator AddEndorsementA9973 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-5aa5-ccad-be01b1072c20");

    // Source modules: Endorsements|Waiton Add Endorsement Button | confidence=High score=125
    // v57 raw Tosca: Endorsements|Waiton Add Endorsement Button | Add Endorsement | guid=3a13d49c-172d-cc07-c4b6-7c4152a76b7c | strategy=role-link
    public ILocator AddEndorsementB6452 => _page.GetByRole(AriaRole.Link, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=125
    // v57 raw Tosca: Endorsements|Partners, Officers And Others Exclusion | Add Endorsement | guid=3a13d49c-172d-fe4d-58de-9e49a96e4a0e | strategy=role-link
    public ILocator AddEndorsementCE8DD => _page.GetByRole(AriaRole.Link, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: [UC1101] Exclusion for Designated Activities or Services | confidence=High score=125
    // v57 raw Tosca: [UC1101] Exclusion for Designated Activities or Services | Add Endorsement | guid=3a13d49c-1697-e2b5-6bf1-f10d7c7a327b | strategy=role-link
    public ILocator AddEndorsementD15B0 => _page.GetByRole(AriaRole.Link, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    // v57 raw Tosca: Endorsements|Partners, Officers And Others Exclusion | Add Excluded Officer Information | guid=3a13d49c-172d-268c-4690-5b965afe5408 | strategy=role-link
    public ILocator AddExcludedOfficerInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Excluded Officer Information", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    // v57 raw Tosca: Endorsements|Partners, Officers And Others Exclusion | Add Excluded Others' Information | guid=3a13d49c-172d-5f7b-618e-a48e1e47dea1 | strategy=role-link
    public ILocator AddExcludedOthersInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Excluded Others' Information", Exact = true });

    // Source modules: Rating Groups | confidence=High score=125
    // v57 raw Tosca: Rating Groups | Add Group | guid=3a13d49c-1700-2755-0478-22aa5344e814 | strategy=role-link
    public ILocator AddGroup => _page.GetByRole(AriaRole.Link, new() { Name = "Add Group", Exact = true });

    // Source modules: NotePad | confidence=High score=125
    public ILocator AddNotesRemarks => _page.GetByRole(AriaRole.Button, new() { Name = "Add Notes/Remarks", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Add Option A | guid=3a13d49c-16f1-01df-bd22-b452e65dada7 | strategy=role-link
    public ILocator AddOptionA => _page.GetByRole(AriaRole.Link, new() { Name = "Add Option A", Exact = true });

    // Source modules: Additional Interests Schedule | confidence=High score=125
    // v57 raw Tosca: Additional Interests Schedule | Add Other Interest | guid=3a13d49c-16f1-61b2-7b37-8529dc410765 | strategy=role-link
    public ILocator AddOtherInterest => _page.GetByRole(AriaRole.Link, new() { Name = "Add Other Interest", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=95
    // v57 raw Tosca: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Add Others' Information | guid=3a13d49c-172d-6158-06dc-f9914aad9575 | strategy=role-link
    public ILocator AddOthersInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Others' Information", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    // v57 raw Tosca: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Add Partner Information | guid=3a13d49c-172d-0a8a-fa88-e76046e8c1ab | strategy=role-link
    public ILocator AddPartnerInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Partner Information", Exact = true });

    // Source modules: Policy Covg - Bailees - Property Away from Your Premises | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Bailees - Property Away from Your Premises | Add Premises | guid=3a13d49c-172d-4821-f8da-ed1286f73579 | strategy=role-link
    public ILocator AddPremises => _page.GetByRole(AriaRole.Link, new() { Name = "Add Premises", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    public ILocator AddPriorCarrier => _page.GetByRole(AriaRole.Button, new() { Name = "Add Prior Carrier", Exact = true });

    // Source modules: Risk Aggregate | confidence=High score=125
    // v57 raw Tosca: Risk Aggregate | Add Risk at This Location | guid=3a13d49c-16f1-8b84-daee-5ad77be8cfe6 | strategy=role-link
    public ILocator AddRiskAtThisLocation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Risk at This Location", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    // v57 raw Tosca: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Add Sole Proprietor Information | guid=3a13d49c-172d-b436-8433-4a12e564692c | strategy=role-link
    public ILocator AddSoleProprietorInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Add Sole Proprietor Information", Exact = true });

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    // v57 raw Tosca: Client|Third Party Designee|Common | Add Third Party | guid=3a13d49c-16f1-9cad-0493-d366b21940fc | strategy=role-link
    public ILocator AddThirdParty => _page.GetByRole(AriaRole.Link, new() { Name = "Add Third Party", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: BAP Navigation Links | Additional Interests | guid=3a13d49c-1688-c094-cab0-01ca8db25c92 | strategy=role-link
    public ILocator AdditionalInterests => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1688-c094-cab0-01ca8db25c92");

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    // v57 raw Tosca: Client|Third Party Designee|Common | AdditionalOtherInterestInput.Address1 | guid=3a13d49c-16f1-94d0-e8c9-010482348527 | strategy=retained-semantic
    public ILocator AdditionalOtherInterestInputAddress1 => _page.Locator("[name=\"AdditionalOtherInterestInput.Address1\"], [id=\"AdditionalOtherInterestInput.Address1\"]").First;

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    // v57 raw Tosca: Client|Third Party Designee|Common | AdditionalOtherInterestInput.FirstName | guid=3a13d49c-16f1-780e-94dc-8e24278e938f | strategy=retained-semantic
    public ILocator AdditionalOtherInterestInputFirstName => _page.Locator("[name=\"AdditionalOtherInterestInput.FirstName\"], [id=\"AdditionalOtherInterestInput.FirstName\"]").First;

    // Source modules: Client|Third Party Designee|Common | confidence=High score=95
    // v57 raw Tosca: Client|Third Party Designee|Common | AdditionalOtherInterestInput.LastName | guid=3a13d49c-16f1-a88d-81f0-2fe1484ac9db | strategy=retained-semantic
    public ILocator AdditionalOtherInterestInputLastName => _page.Locator("[name=\"AdditionalOtherInterestInput.LastName\"], [id=\"AdditionalOtherInterestInput.LastName\"]").First;

    // Source modules: Additional Interests Schedule | confidence=High score=127
    // v57 raw Tosca: Additional Interests Schedule | Addl Interests | guid=3a13d49c-16f1-3c8c-26cf-6ef3cb7d13c7 | strategy=id
    public ILocator AddlInterests15174 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-3c8c-26cf-6ef3cb7d13c7");

    // Source modules: Addl Interests|Main | confidence=High score=127
    // v57 raw Tosca: Addl Interests|Main | Addl Interests | guid=3a13d49c-1700-96d9-4ea5-706c8da252f1 | strategy=id
    public ILocator AddlInterestsA10A4 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: GL Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: GL Navigation Links | Addl Interests | guid=3a13d49c-16f1-3165-5afe-37c2fc7ba1c3 | strategy=role-link
    public ILocator AddlInterestsE39FC => _page.GetByRole(AriaRole.Link, new() { Name = "Addl Interests", Exact = true });

    // Source modules: Endorsement - CM 66 01 Exclude Named Customer | confidence=High score=125
    // v57 raw Tosca: Endorsement - CM 66 01 Exclude Named Customer | Address | guid=3a13d49c-172d-b5bb-ae1c-348164b75bbb | strategy=id
    public ILocator Address => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-b5bb-ae1c-348164b75bbb");

    // Source modules:  | confidence=High score=125
    // v57 raw Tosca: Endorsement - CM 66 01 Exclude Named Customer | Address | guid=3a13d49c-172d-b5bb-ae1c-348164b75bbb | strategy=canonical-alias
    public ILocator Address193FF8 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-b5bb-ae1c-348164b75bbb");

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    // v57 raw Tosca: [CG 29 35] Add'l Insured-State or Political (Permits) | Address 1 | guid=3a13d49c-172d-1302-37f7-9658557705c7 | strategy=retained-semantic
    public ILocator Address19B8B5 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address 1", Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=125
    // v57 raw Tosca: GL OCP|Risk | Address 1 | guid=3a13d49c-172d-55c3-87e4-959a69c1103b | strategy=id
    public ILocator Address1BE797 => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA705E_3_1-inputEl\"]");

    // Source modules: Location | confidence=High score=125
    public ILocator Address1C0AF1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address1", Exact = true });

    // Source modules: Policy Covg - Bailees - Property Away from Your Premises | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Bailees - Property Away from Your Premises | Address (Street, City, State, Zip) | guid=3a13d49c-172d-cf7c-992d-020e7fc46ee1 | strategy=id
    public ILocator AddressStreetCityStateZip => _page.Locator("[id=\"f_b7BA9D20D6B9840E99A47B1B0DFA716BF7_1_1-inputEl\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Aggregate Limit | guid=3a13d49c-1700-7505-61ee-35ff4430c9d2 | strategy=retained-semantic
    public ILocator AggregateLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-7505-61ee-35ff4430c9d2");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Annual Gross Receipts | guid=3a13d49c-172d-6499-2815-7ebac8f6a57f | strategy=id
    public ILocator AnnualGrossReceipts => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF5875174088F_1_1-inputEl\"]");

    // Source modules: Underwriting Questions | confidence=High score=125
    // v57 raw Tosca: Underwriting Questions | AnyPersonalAutoPolicyListingNameInsured | guid=3a13d49c-16f1-a9d5-e2f3-565fb830d711 | strategy=id
    public ILocator AnyPersonalAutoPolicyListingNameInsured => _page.Locator("[id=\"f_uFE2672745CB24DB2A83158A3D6E7E97F13E_3_1-inputEl\"]");

    // Source modules: Underwriting Questions | confidence=High score=125
    // v57 raw Tosca: Underwriting Questions | AnyVehicleCoveredRegisteredInNotPrimaryState | guid=3a13d49c-16f1-600d-ee2d-a58658593101 | strategy=id
    public ILocator AnyVehicleCoveredRegisteredInNotPrimaryState => _page.Locator("[id=\"f_uFE2672745CB24DB2A83158A3D6E7E97F187_3_1-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Signs | Are Any signs off premises or not attached to building? | guid=3a13d49c-172d-61b6-65da-12205770661c | strategy=id
    public ILocator AreAnySignsOffPremisesOrNotAttachedToBuilding => _page.Locator("[id=\"f_sEDD5CE21D8434468900294193CF0200E1D_2_1-inputEl\"]");

    // Source modules: UW Questions - Workers Comp | confidence=High score=95
    // v57 raw Tosca: UW Questions - Workers Comp | Are physicals required after offers of employment are made?* | guid=3a13d49c-171e-1a92-58e5-b16ae97564c0 | strategy=retained-semantic
    public ILocator ArePhysicalsRequiredAfterOffersOfEmploymentAreMade => _page.GetByRole(AriaRole.Textbox, new() { Name = "Are physicals required after offers of employment are made?*", Exact = true });

    // Source modules: Underwriting Questions | confidence=High score=125
    // v57 raw Tosca: Underwriting Questions | Are there any commercial vehicles owned by the applicant not insured on the policy? | guid=3a13d49c-16f1-6e1a-96fa-151dd8c1dddb | strategy=retained-semantic
    public ILocator AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy => _page.GetByRole(AriaRole.Textbox, new() { Name = "Are there any commercial vehicles owned by the applicant not insured on the policy?", Exact = true });

    // Source modules: Endorsements|Waiton Add Endorsement Button | confidence=High score=95
    // v57 raw Tosca: Endorsements|Waiton Add Endorsement Button | Are there any Officers that should be excluded?* | guid=3a13d49c-172d-2051-e8df-32446e2dbf88 | strategy=id
    public ILocator AreThereAnyOfficersThatShouldBeExcluded => _page.Locator("[id=\"f_lA2C9A848A1FC45D39BB20EBBC28014492E1_3_1-inputEl\"]");

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Assign Location | guid=3a13d49c-1688-1c52-1b5a-eba8fbd683e6 | strategy=role-link
    public ILocator AssignLocation => _page.GetByRole(AriaRole.Link, new() { Name = "Assign Location", Exact = true });

    // Source modules: Entity Schedule|Location Assignment | confidence=High score=125
    // v57 raw Tosca: Entity Schedule|Location Assignment | Assign Locations | guid=3a13d49c-1688-1d1c-d95a-78823ad68963 | strategy=role-link
    public ILocator AssignLocations => _page.GetByRole(AriaRole.Link, new() { Name = "Assign Locations", Exact = true });

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Physical Damage | Audio Visual | guid=3a13d49c-16f1-83db-ed02-ef603700d2d6 | strategy=id
    public ILocator AudioVisual => _page.Locator("[id=\"f_c6FBE834FF11D44EEA4139F156BB928EC236C_2_1-inputEl\"]");

    // Source modules: CPP|Pricing | confidence=High score=125
    // v57 raw Tosca: CPP|Pricing | Available Classifications* | guid=3a13d49c-172d-0d1d-2699-ebde09a3a621 | strategy=id
    public ILocator AvailableClassifications => _page.Locator("[id=\"f_cF339927B88A5461CBDBBA081531BA503602_3_1-inputEl\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Average Number Of Days Service | guid=3a13d49c-172d-61ac-fecd-a46874df3bc4 | strategy=id
    public ILocator AverageNumberOfDaysService => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740890_1_1-inputEl\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Average Number Of Working Days | guid=3a13d49c-172d-c9bc-6ebc-d437877d0713 | strategy=id
    public ILocator AverageNumberOfWorkingDays => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740891_1_1-inputEl\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Average Service Charge | guid=3a13d49c-172d-bea0-0f62-82c87788e49a | strategy=id
    public ILocator AverageServiceCharge => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740892_1_1-inputEl\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Average Value Per Order | guid=3a13d49c-172d-511a-964b-2e8a8eb61898 | strategy=id
    public ILocator AverageValuePerOrder => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740893_1_1-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | b. Are there any private protection improvements? | guid=3a13d49c-172d-ef1f-11de-7e0ce2791f65 | strategy=id
    public ILocator BAreThereAnyPrivateProtectionImprovements => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B171_2_8-inputEl\"]");

    // Source modules: Building - Detail | confidence=High score=95
    // v57 raw Tosca: Building - Detail | BG2 Symbol | guid=3a13d49c-1700-b4f1-2e0f-9623a011c540 | strategy=id
    public ILocator BG2Symbol => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D026E_3_1-inputEl\"]");

    // Source modules: Building - Detail | confidence=High score=95
    // v57 raw Tosca: Building - Detail | BG2 Symbol Prefix | guid=3a13d49c-1700-5167-25f2-9cee08189d8a | strategy=id
    public ILocator BG2SymbolPrefix => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0270_3_1-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=97
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | Bailees Customer Heading | guid=3a13d49c-172d-c18f-9a3a-156ae50bdc42 | strategy=id
    public ILocator BaileesCustomerHeading => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: IM Navigation Links | Bailees Customer UW Questions | guid=3a13d49c-172d-3c47-6595-d0aa7c4310a8 | strategy=role-link
    public ILocator BaileesCustomerUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Bailees Customer", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator BaileesCustomersHeading => _page.GetByText("Bailees Customers Heading", new() { Exact = true });

    // Source modules: Billing | confidence=High score=125
    public ILocator BillType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Bill Type", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator Billing6ED79 => _page.GetByRole(AriaRole.Link, new() { Name = "Billing", Exact = true });

    // Source modules: Billing | confidence=High score=127
    public ILocator BillingD1518 => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Billing");

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Vehicle Information | Body Style | guid=3a13d49c-16f1-f96d-de86-5e6ff5bca184 | strategy=retained-semantic
    public ILocator BodyStyle => _page.GetByRole(AriaRole.Textbox, new() { Name = "Body Style", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Contractors Equipment | Boom Deductible | guid=3a13d49c-172d-223a-3b77-59e4febb54e1 | strategy=id
    public ILocator BoomDeductible => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FC8_3_1-inputEl\"]");

    // Source modules: Underwriting Questions | confidence=High score=125
    // v57 raw Tosca: Underwriting Questions | BorrowingHiringOrLeasingWithinYear | guid=3a13d49c-16f1-da90-ef71-ebfdc1718688 | strategy=id
    public ILocator BorrowingHiringOrLeasingWithinYear => _page.Locator("[id=\"f_uFE2672745CB24DB2A83158A3D6E7E97F142_3_1-inputEl\"]");

    // Source modules: Building - Main | confidence=High score=127
    // v57 raw Tosca: Building - Main | Building | guid=3a13d49c-1700-e814-b631-759b08c0789c | strategy=id
    public ILocator Building8205F => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: CP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: CP Navigation Links | Building | guid=3a13d49c-1700-63d6-8780-0e2a2b2d4dde | strategy=role-link
    public ILocator Building87910 => _page.GetByRole(AriaRole.Link, new() { Name = "Building", Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    // v57 raw Tosca: Building - Detail | OK | guid=3a13d49c-1700-d34c-3e9f-31146f0d82c3 | strategy=role-link
    public ILocator BuildingDetailOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    // v57 raw Tosca: Property Add Class | Building Limit | guid=3a13d49c-1700-a35c-5d87-042b1b07e590 | strategy=retained-semantic
    public ILocator BuildingLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Building Limit", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    // v57 raw Tosca: Property Add Class | Building Rating Group | guid=3a13d49c-1700-758b-9ad8-e730679f6067 | strategy=retained-semantic
    public ILocator BuildingRatingGroup => _page.GetByRole(AriaRole.Textbox, new() { Name = "Building Rating Group", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Business Interruption Description Of ScheduledProperty | guid=3a13d49c-16f1-3cf9-8b4c-c75ac8119afc | strategy=retained-semantic
    public ILocator BusinessInterruptionDescriptionOfScheduledProperty => _page.GetByRole(AriaRole.Textbox, new() { Name = "Business Interruption Description Of ScheduledProperty", Exact = true });

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=97
    // v57 raw Tosca: Policy Coverage|Business Interruption | Business Interruption Detail | guid=3a13d49c-16f1-f65c-220f-9cfff39a7afc | strategy=id
    public ILocator BusinessInterruptionDetail => _page.Locator("[id=\"pageTop\"]");

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    // v57 raw Tosca: Policy Coverage|Business Interruption | Business Interruption Endorsement | guid=3a13d49c-16f1-56c0-58eb-e24f30fa7d43 | strategy=retained-semantic
    public ILocator BusinessInterruptionEndorsement => _page.GetByRole(AriaRole.Textbox, new() { Name = "Business Interruption Endorsement", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Business Interruption Limit Of Insurance | guid=3a13d49c-16f1-7814-b3c5-cbab76b6df04 | strategy=retained-semantic
    public ILocator BusinessInterruptionLimitOfInsurance => _page.GetByRole(AriaRole.Textbox, new() { Name = "Business Interruption Limit Of Insurance", Exact = true });

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    public ILocator BusinessInterruptionOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | [CA2325] Leased Workers Coverage | guid=3a13d49c-16f1-7b42-b81a-cc94505fe0df | strategy=associatedlabel-from-v55
    public ILocator CA2325LeasedWorkersCoverage => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "[CA2325] Leased Workers Coverage");

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | CA9940 - Contract Provisions | guid=3a13d49c-16f1-67f3-6a64-fb378be1e357 | strategy=retained-semantic
    public ILocator CA9940ContractProvisions => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9940 - Contract Provisions", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | CA9940 - Make | guid=3a13d49c-16f1-0d7c-df74-c3be8ae3c06f | strategy=retained-semantic
    public ILocator CA9940Make => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9940 - Make", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | CA9940 - Model | guid=3a13d49c-16f1-5f2d-b0bb-5b027764f4b0 | strategy=retained-semantic
    public ILocator CA9940Model => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9940 - Model", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | CA 9940 - VIN | guid=3a13d49c-16f1-66bd-444a-d2025d839176 | strategy=retained-semantic
    public ILocator CA9940VIN => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA 9940 - VIN", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | CA9940 - Year | guid=3a13d49c-16f1-b3e3-78f7-2e3f37d05630 | strategy=retained-semantic
    public ILocator CA9940Year => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9940 - Year", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | CA9948 - Classes Of Commodities Transported | guid=3a13d49c-16f1-2769-9cda-98d0819f4496 | strategy=retained-semantic
    public ILocator CA9948ClassesOfCommoditiesTransported => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9948 - Classes Of Commodities Transported", Exact = true });

    // Source modules: [CG0424] Coverage for Injury to Leased Workers | confidence=High score=125
    public ILocator CG0424CoverageForInjuryToLeasedWorkersOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: [CG0435] Employee Benefits Liability | confidence=High score=125
    public ILocator CG0435EmployeeBenefitsLiabilityOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: [CG 20 07] Add'l Insured-Engineers, Architects | confidence=High score=125
    public ILocator CG2007AddLInsuredEngineersArchitectsOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: [CG 20 20] Add'l Insured-Charitable Institution | confidence=High score=125
    public ILocator CG2020AddLInsuredCharitableInstitutionOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=125
    // v57 raw Tosca: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Exclude Underground Property Damage Hazard | guid=3a13d49c-1700-e550-22ce-3a4125c40dfb | strategy=fieldref
    public ILocator CG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-e550-22ce-3a4125c40dfb");

    // Source modules: [CG 2149] Total Pollution Exclusion Endorsement | confidence=High score=125
    public ILocator CG2149TotalPollutionExclusionEndorsementOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: [CG2401] Non-Binding Arbitration | confidence=High score=125
    public ILocator CG2401NonBindingArbitrationOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: [CG2812] Pesticide or Herbicide Applicator Coverage | confidence=High score=125
    public ILocator CG2812PesticideOrHerbicideApplicatorCoverageOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    public ILocator CG2935AddLInsuredStateOrPoliticalPermitsOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: GL Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: GL Navigation Links | CGL | guid=3a13d49c-16f1-f593-bcf1-ae618f079059 | strategy=role-link
    public ILocator CGL08901 => _page.GetByRole(AriaRole.Link, new() { Name = "CGL", Exact = true });

    // Source modules: CGL|Main Page | confidence=High score=127
    // v57 raw Tosca: CGL|Main Page | CGL | guid=3a13d49c-1700-a749-35bb-f5cab773bcd0 | strategy=id
    public ILocator CGLBA8E8 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: General Liability | confidence=High score=95
    // v57 raw Tosca: General Liability | CGL Limits* | guid=3a13d49c-171e-11ee-3790-def967b0124f | strategy=retained-semantic
    public ILocator CGLLimits => _page.GetByRole(AriaRole.Textbox, new() { Name = "CGL Limits*", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | CPP Liability | guid=3a13d49c-1697-b124-eb68-7d72e20b1cb2 | strategy=role-link
    public ILocator CPPLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-b124-eb68-7d72e20b1cb2");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | c. What is the distance in feet to the nearest hydrant? | guid=3a13d49c-172d-bad9-b867-46a8e3973928 | strategy=id
    public ILocator CWhatIsTheDistanceInFeetToTheNearestHydrant => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B175_2_8-inputEl\"]");

    // Source modules: Location | confidence=High score=125
    public ILocator CallISO => _page.GetByRole(AriaRole.Link, new() { Name = "Call ISO", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator Carrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Carrier", Exact = true });

    // Source modules: Rating Groups | confidence=High score=95
    // v57 raw Tosca: Rating Groups | Cause Of Loss | guid=3a13d49c-1700-c234-b4cd-8dabfa443bc9 | strategy=retained-semantic
    public ILocator CauseOfLoss => _page.GetByRole(AriaRole.Textbox, new() { Name = "Cause Of Loss", Exact = true });

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    // v57 raw Tosca: Endorsements|Designated Workplaces Exclusion | City* | guid=3a13d49c-172d-fbed-7d77-2e7579fb940d | strategy=retained-semantic
    public ILocator City => _page.GetByRole(AriaRole.Textbox, new() { Name = "City*", Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=124
    // v57 raw Tosca: GL OCP|Risk | Class Code | guid=3a14699b-eb39-5a39-e3b3-a7fc02e678bb | strategy=fieldref
    public ILocator ClassCode => _page.Locator("[fieldref=\"CovOwnersContractorsOrPrincipalsInputNonShredded.ClassCode\"], [data-fieldref=\"CovOwnersContractorsOrPrincipalsInputNonShredded.ClassCode\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ClassCodeFrame => _page.GetByText("Class Code Frame", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ClassCodeFrameClassCodeWindow => _page.GetByText("Class Code Window", new() { Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Risk - Accounts Receivable | Classification of Risk % | guid=3a13d49c-172d-ffbb-323f-7759508e5920 | strategy=id
    public ILocator ClassificationOfRisk => _page.Locator("[id=\"f_c4FFD73A13C164B729C39A3F5C851102319_1_1-inputEl\"]");

    // Source modules: BAP Endorsements | confidence=High score=125
    // v57 raw Tosca: BAP Endorsements | Click Add Endorsement | guid=3a13d49c-16f1-0594-73e4-5be4abb9fd7e | strategy=role-link
    public ILocator ClickAddEndorsement => _page.GetByRole(AriaRole.Link, new() { Name = "Click Add Endorsement", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Click Add Excluded Driver | guid=3a13d49c-16f1-a103-7413-4699bd712717 | strategy=role-link
    public ILocator ClickAddExcludedDriver => _page.GetByRole(AriaRole.Link, new() { Name = "Click Add Excluded Driver", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=127
    // v57 raw Tosca:  | Add Client | guid=3a13d49c-1679-21d3-307d-9ac2d420ffb8 | strategy=role-link
    public ILocator Client070F4 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-21d3-307d-9ac2d420ffb8");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    // v57 raw Tosca:  | Add Client | guid=3a13d49c-1679-21d3-307d-9ac2d420ffb8 | strategy=canonical-alias
    public ILocator Client35F85 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-21d3-307d-9ac2d420ffb8");

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Computer Systems | Coinsurance | guid=3a13d49c-172d-6546-3ca9-60b9a68bebd8 | strategy=id
    public ILocator Coinsurance01AB1 => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F83_3_4-inputEl\"]");

    // Source modules: Rating Groups | confidence=High score=125
    // v57 raw Tosca: Rating Groups | Coinsurance | guid=3a13d49c-1700-5b88-0c0b-bde84371a28d | strategy=retained-semantic
    public ILocator Coinsurance6348B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coinsurance", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Contractors Equipment | Coinsurance | guid=3a13d49c-172d-ba57-9263-fe53e40612bf | strategy=id
    public ILocator CoinsuranceC9726 => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FC2_3_1-inputEl\"]");

    // Source modules: State Details|Drive Other Car | confidence=High score=124
    // v57 raw Tosca: State Details|Drive Other Car | Collision | guid=3a13d49c-16f1-d5d3-cfec-2ff0d8100a07 | strategy=fieldref
    public ILocator Collision => _page.Locator("[fieldref=\"CovDriveOtherCarCollisionInput.Indicator\"], [data-fieldref=\"CovDriveOtherCarCollisionInput.Indicator\"]");

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=125
    // v57 raw Tosca: Risk Schedule|Physical Damage | Collision Coverage | guid=3a13d49c-16f1-a732-fd1c-48f413463f40 | strategy=id
    public ILocator CollisionCoverage => _page.Locator("[id=\"f_c7D7AC70D2F5B46AE89DB2111B306EB762349_2_1-inputEl\"]");

    // Source modules: State Details|Drive Other Car | confidence=High score=125
    // v57 raw Tosca: State Details|Drive Other Car | Collision Deductible | guid=3a13d49c-16f1-225d-99e9-4b1f10d2cee0 | strategy=retained-semantic
    public ILocator CollisionDeductible63D4C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Collision Deductible", Exact = true });

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=125
    // v57 raw Tosca: State Details|Hired Auto PD Without Driver | Collision Deductible* | guid=3a13d49c-16f1-0174-803a-23ef2f2eb378 | strategy=retained-semantic
    public ILocator CollisionDeductible9C100 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Collision Deductible*", Exact = true });

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=125
    // v57 raw Tosca: State Details|Hired Auto Physical Damage With Driver | Collision Deductible* | guid=3a13d49c-16f1-e253-7de5-f7e8e71153ad | strategy=retained-semantic
    public ILocator CollisionDeductibleAEEBB => _page.GetByRole(AriaRole.Textbox, new() { Name = "Collision Deductible*", Exact = true });

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=124
    // v57 raw Tosca: State Details|Hired Auto PD Without Driver | Collision If Any | guid=3a13d49c-16f1-5c18-e644-83bd4b6e219f | strategy=fieldref
    public ILocator CollisionIfAny7532D => _page.Locator("[fieldref=\"CovHiredAndBorrowedCollisionInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedCollisionInput.IfAny\"]");

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=124
    // v57 raw Tosca: State Details|Hired Auto Physical Damage With Driver | Collision If Any | guid=3a13d49c-16f1-d9de-e926-0b9129fdbd18 | strategy=fieldref
    public ILocator CollisionIfAny8AEE8 => _page.Locator("[fieldref=\"CovHiredAndBorrowedCollisionWithDriverInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedCollisionWithDriverInput.IfAny\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Commercial Auto | guid=3a13d49c-1697-50ef-718a-9eff146a551c | strategy=role-link
    public ILocator CommercialAuto => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-50ef-718a-9eff146a551c");

    // Source modules: Commercial Auto | confidence=High score=97
    // v57 raw Tosca: Commercial Auto | Commercial Auto Detail | guid=3a13d49c-171e-206a-714b-8399b94c21df | strategy=id
    public ILocator CommercialAutoDetail => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=97
    // v57 raw Tosca: Risk Schedule|Vehicle Information | Commercial Auto Risk Detail | guid=3a13d49c-16f1-498d-81fa-44fb54374c38 | strategy=id
    public ILocator CommercialAutoRiskDetail => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator CommonNavigationLinksNext => _page.GetByRole(AriaRole.Link, new() { Name = "Next", Exact = true });

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    // v57 raw Tosca: Client|Third Party Designee|Common | OK | guid=3a13d49c-16f1-8863-55fc-c5c090c1203d | strategy=role-link
    public ILocator CommonOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: State Details|Main | confidence=High score=95
    // v57 raw Tosca: State Details|Main | Company Name* | guid=3a13d49c-171e-0e77-5f55-abf0e2338458 | strategy=retained-semantic
    public ILocator CompanyName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Company Name*", Exact = true });

    // Source modules: State Details|Drive Other Car | confidence=High score=124
    // v57 raw Tosca: State Details|Drive Other Car | Comprehensive | guid=3a13d49c-16f1-5f93-621a-e22e7140a699 | strategy=fieldref
    public ILocator Comprehensive => _page.Locator("[fieldref=\"CovDriveOtherCarOTCInput.Indicator\"], [data-fieldref=\"CovDriveOtherCarOTCInput.Indicator\"]");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Risk - Computer Systems | Computer Equipment | guid=3a13d49c-172d-45f4-8d0f-8fd870ea77b0 | strategy=id
    public ILocator ComputerEquipment => _page.Locator("[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB1C_1_1-inputEl\"]");

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: IM Navigation Links | Computer Systems UW Questions | guid=3a13d49c-172d-ac51-306a-47440d3fcd47 | strategy=role-link
    public ILocator ComputerSystemsUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Computer Systems", Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    // v57 raw Tosca: Building - Detail | Construction | guid=3a13d49c-1700-1069-c388-9ce86228e656 | strategy=id
    public ILocator Construction39800 => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D023F_3_1-inputEl\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Construction | guid=3a13d49c-172d-9555-3f8b-92080b6ba480 | strategy=id
    public ILocator ConstructionCD2DE => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF5875174088B_1_1-inputEl\"]");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Risk - Computer Systems | Construction Code | guid=3a13d49c-172d-5818-98e9-0382ce1053fa | strategy=id
    public ILocator ConstructionCode => _page.Locator("[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB114_1_1-inputEl\"]");

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Risk - Accounts Receivable | Construction | guid=3a13d49c-172d-b947-f30a-3edb2747a9b9 | strategy=id
    public ILocator ConstructionFB8D9 => _page.Locator("[id=\"f_rFE68631942E64B1BA3A954F11A424A13D_1_1-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=97
    // v57 raw Tosca: Specific Underwriting Questions - Contractors Equipment | Contractors Equipment Heading | guid=3a13d49c-172d-422b-da96-e8d6d53ee14c | strategy=id
    public ILocator ContractorsEquipmentHeading => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: IM Navigation Links | Contractors Equipment UW Questions | guid=3a13d49c-172d-ca76-fce2-ec799cd2b2ff | strategy=role-link
    public ILocator ContractorsEquipmentUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Contractors Equipment", Exact = true });

    // Source modules: Risk Schedule|General Coverage | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|General Coverage | Coverage begin date: | guid=3a13d49c-16f1-17cb-4648-39a9b99031c4 | strategy=retained-semantic
    public ILocator CoverageBeginDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coverage begin date:", Exact = true });

    // Source modules: Risk Schedule|General Coverage | confidence=High score=125
    // v57 raw Tosca: Risk Schedule|General Coverage | Coverage end date: | guid=3a13d49c-16f1-a25e-f0f2-88f196bbf8ec | strategy=retained-semantic
    public ILocator CoverageEndDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coverage end date:", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=125
    // v57 raw Tosca: Policy Covg|GL | Coverage Form | guid=3a13d49c-1700-13c2-28c5-b4f96f3ab1d9 | strategy=retained-semantic
    public ILocator CoverageForm3B382 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coverage Form", Exact = true });

    // Source modules: Policy Covg - Signs | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Signs | Coverage Form | guid=3a13d49c-172d-ca76-656f-26dd342f39d4 | strategy=id
    public ILocator CoverageFormA7F96 => _page.Locator("[id=\"f_cAFD1AA97819C467694F348BB5BA65F85E45_3_6-inputEl\"]");

    // Source modules: Risk - Main | confidence=High score=125
    // v57 raw Tosca: Risk - Main | Coverage Form | guid=3a13d49c-172d-8cee-2276-5f90ed7399d8 | strategy=id
    public ILocator CoverageFormCFDD1 => _page.Locator("[id=\"f_l1A9C547373A24FF38DA9C54C82FB349824_3_1-inputEl\"]");

    // Source modules: Policy Covg - Computer Systems | confidence=High score=95
    // v57 raw Tosca: Policy Covg - Computer Systems | Coverage Form Display | guid=3a13d49c-172d-f8ca-f540-fa8827f6d389 | strategy=id
    public ILocator CoverageFormDisplay2ECD4 => _page.Locator("[id=\"f_iB27E9D1A7BBB4CC688DAC59E11C5C2DED60_3_4-inputEl\"]");

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=95
    // v57 raw Tosca: Policy Covg - Bailees Cutomers | Coverage Form Display | guid=3a13d49c-172d-f8dd-dcaf-c248c426576e | strategy=id
    public ILocator CoverageFormDisplay6F446 => _page.Locator("[id=\"f_iA14B1E3D0C8544FA84D50C076D97DD44D60_3_7-inputEl\"]");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=95
    // v57 raw Tosca: Policy Covg - Motor Truck Cargo | Coverage Form Display | guid=3a13d49c-172d-e69b-47ac-7709a57cbfff | strategy=id
    public ILocator CoverageFormDisplayB69C2 => _page.Locator("[id=\"f_i6880B67F580944108A4FCC241C2B2649D60_3_5-inputEl\"]");

    // Source modules: Policy Covg - Signs | confidence=High score=95
    // v57 raw Tosca: Policy Covg - Signs | Coverage Form Display | guid=3a13d49c-172d-ad8e-e828-be097affb11b | strategy=id
    public ILocator CoverageFormDisplayC10BA => _page.Locator("[id=\"f_iCCB999F03E934DE9BF81315D41AE8572D60_3_6-inputEl\"]");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=95
    // v57 raw Tosca: Policy Covg - Contractors Equipment | Coverage Form Display | guid=3a13d49c-172d-98f3-220e-b1c67ccd33ad | strategy=id
    public ILocator CoverageFormDisplayD1A9B => _page.Locator("[id=\"f_i2B400B3B804E4D9EA12FE1D96F9ADFC6D60_3_1-inputEl\"]");

    // Source modules: Policy Covg - Main | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Main | Coverage Form To Be Added | guid=3a13d49c-172d-eb63-48b6-c4fba029f2b7 | strategy=id
    public ILocator CoverageFormToBeAdded => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-eb63-48b6-c4fba029f2b7");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Motor Truck Cargo | Coverage Type | guid=3a13d49c-172d-283e-f0d4-8de1f2f3f263 | strategy=id
    public ILocator CoverageType => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB401072_3_5-inputEl\"]");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=124
    // v57 raw Tosca: Policy Covg - Motor Truck Cargo | Covered Property Consisting Principally of: | guid=3a13d49c-172d-1c31-1fa9-65e272a5d96b | strategy=fieldref
    public ILocator CoveredPropertyConsistingPrincipallyOf => _page.Locator("[fieldref=\"MotorTruckCargoInput.Description\"], [data-fieldref=\"MotorTruckCargoInput.Description\"]");

    // Source modules: Property Enter Building RCT | confidence=High score=125
    // v57 raw Tosca: Property Enter Building RCT | Create Valuation | guid=3a13d49c-1700-2124-161f-64e3a0340478 | strategy=role-link
    public ILocator CreateValuation => _page.GetByRole(AriaRole.Link, new() { Name = "Create Valuation", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | d. What is the distance in miles to the nearest responding fire department? | guid=3a13d49c-172d-489a-f6a7-e659d76ca0cc | strategy=id
    public ILocator DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B178_2_8-inputEl\"]");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Risk - Computer Systems | Data And Media | guid=3a13d49c-172d-e8e7-c880-b01adf3ce964 | strategy=id
    public ILocator DataAndMedia => _page.Locator("[id=\"f_c3EF1D09EE0E84AB189A6366AD3F277B2D_1_1-inputEl\"]");

    // Source modules:  | confidence=High score=125
    // v57 raw Tosca:  | Date Of Birth* | guid=3a13d49c-16f1-5235-6ac4-b01a5f07f090 | strategy=id
    public ILocator DateOfBirth => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-5235-6ac4-b01a5f07f090");

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Date Of Hire | guid=3a13d49c-16f1-4470-e93c-4efdc6c0232b | strategy=id
    public ILocator DateOfHire => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D6_1_1-inputEl\"]");

    // Source modules: Property - Main | confidence=High score=95
    // v57 raw Tosca: Property - Main | Debris Removal Additional | guid=3a13d49c-1700-5f53-c793-d1b34115d4d5 | strategy=retained-semantic
    public ILocator DebrisRemovalAdditional => _page.GetByRole(AriaRole.Textbox, new() { Name = "Debris Removal Additional", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    // v57 raw Tosca: Property - Main | Debris Removal Additional Limit | guid=3a13d49c-1700-ea5a-bcb5-732190b85c96 | strategy=retained-semantic
    public ILocator DebrisRemovalAdditionalLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Debris Removal Additional Limit", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Ded Type | guid=3a13d49c-1700-a97e-db29-b634782f5f0c | strategy=retained-semantic
    public ILocator DedType => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-a97e-db29-b634782f5f0c");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | Dedicated line?* | guid=3a13d49c-172d-06ab-8b49-98f96c3f0d2c | strategy=id
    public ILocator DedicatedLine => _page.Locator("[id=\"f_c7FA512A090F641B9A6BB95F4C656EE1841_2_21-inputEl\"]");

    // Source modules: Rating Groups | confidence=High score=125
    // v57 raw Tosca: Rating Groups | Deductible | guid=3a13d49c-1700-a1be-71e5-58af96cb5104 | strategy=retained-semantic
    public ILocator Deductible01AB9 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible", Exact = true });

    // Source modules: Endorsement - IF 00 02 Waterborne Equipment | confidence=High score=125
    // v57 raw Tosca: Endorsement - IF 00 02 Waterborne Equipment | Deductible | guid=3a13d49c-172d-0db1-504b-31dcb3ad8c08 | strategy=id
    public ILocator Deductible0CC0A => _page.Locator("[id=\"f_c4CA5AF1ED9DF445F976D32FE5E1139DD11D_3_14-inputEl\"]");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Motor Truck Cargo | Deductible | guid=3a13d49c-172d-4aa5-a0d1-9871e461d3a8 | strategy=id
    public ILocator Deductible320C9 => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB40107F_3_5-inputEl\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Deductible | guid=3a13d49c-172d-7e5a-82d0-982ee92666e3 | strategy=id
    public ILocator Deductible59155 => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF5875174087F_1_1-inputEl\"]");

    // Source modules: Building - Detail | confidence=High score=125
    // v57 raw Tosca: Building - Detail | Deductible | guid=3a13d49c-1700-f1e0-3ef3-1c4e31fab319 | strategy=id
    public ILocator Deductible592D9 => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0260_3_1-inputEl\"]");

    // Source modules: State Details|Main | confidence=High score=125
    // IA Only
    // v57 raw Tosca: State Details|Main | Deductible | guid=3a13d49c-171e-c39e-9393-34ed831d791c | strategy=retained-semantic
    public ILocator Deductible5F45D => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Deductible Basis | guid=3a13d49c-1700-b6ea-5343-993db0eb88bd | strategy=retained-semantic
    public ILocator DeductibleBasis => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-b6ea-5343-993db0eb88bd");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Contractors Equipment | Deductible | guid=3a13d49c-172d-8a92-3d7b-8c9435b2ac81 | strategy=id
    public ILocator DeductibleC227C => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FC3_3_1-inputEl\"]");

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Computer Systems | Deductible | guid=3a13d49c-172d-f24f-fd12-2e1d01cd14aa | strategy=id
    public ILocator DeductibleC91E9 => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F7E_3_4-inputEl\"]");

    // Source modules: Building - Detail | confidence=High score=95
    // v57 raw Tosca: Building - Detail | Deductible Increased Theft | guid=3a13d49c-1700-d0f4-5c2e-6ccb4f16326a | strategy=id
    public ILocator DeductibleIncreasedTheft99E5F => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0263_3_1-inputEl\"]");

    // Source modules: Rating Groups | confidence=High score=95
    // v57 raw Tosca: Rating Groups | Deductible Increased Theft | guid=3a13d49c-1700-ecb6-f577-3cbdbd9a8481 | strategy=retained-semantic
    public ILocator DeductibleIncreasedTheftF76DB => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible Increased Theft", Exact = true });

    // Source modules: Building - Detail | confidence=High score=95
    // v57 raw Tosca: Building - Detail | Deductible Wind Hail | guid=3a13d49c-1700-1ec6-278d-a9c3d22a27f7 | strategy=id
    public ILocator DeductibleWindHail911AF => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0265_3_1-inputEl\"]");

    // Source modules: Rating Groups | confidence=High score=95
    // v57 raw Tosca: Rating Groups | Deductible Wind Hail | guid=3a13d49c-1700-73c3-4771-efc0ab4b5f87 | strategy=retained-semantic
    public ILocator DeductibleWindHailAB1C3 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible Wind Hail", Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    // v57 raw Tosca: Policy Covg | Default Exp Mod Type | guid=3a13d49c-171e-7f26-a521-6123b118a8bc | strategy=retained-semantic
    public ILocator DefaultExpModType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Default Exp Mod Type", Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    // v57 raw Tosca: Policy Covg | Default Experience Mod | guid=3a13d49c-171e-2e65-eeb7-4bf0c49b102e | strategy=retained-semantic
    public ILocator DefaultExperienceMod => _page.GetByRole(AriaRole.Textbox, new() { Name = "Default Experience Mod", Exact = true });

    // Source modules: General Liability Information | confidence=High score=124
    // v57 raw Tosca: General Liability Information | Describe all hold harmless agreements and please provide a copy. | guid=3a13d49c-1700-76a0-467c-360e79fa5c72 | strategy=fieldref
    public ILocator DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy => _page.Locator("[fieldref=\"GeneralLiabilityInput.Description\"], [data-fieldref=\"GeneralLiabilityInput.Description\"]");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Contractors Equipment | Description* | guid=3a13d49c-172d-9743-916a-1bc64d592f51 | strategy=id
    public ILocator Description03789 => _page.Locator("[id=\"f_i2B400B3B804E4D9EA12FE1D96F9ADFC6D62_3_1-inputEl\"]");

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Bailees Cutomers | Description* | guid=3a13d49c-172d-3257-99b8-b0b4151776d5 | strategy=id
    public ILocator Description43F2D => _page.Locator("[id=\"f_iA14B1E3D0C8544FA84D50C076D97DD44D62_3_7-inputEl\"]");

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Computer Systems | Description* | guid=3a13d49c-172d-134f-9ae6-10afea4b6a2c | strategy=id
    public ILocator Description58EC2 => _page.Locator("[id=\"f_iB27E9D1A7BBB4CC688DAC59E11C5C2DED62_3_4-inputEl\"]");

    // Source modules: Rating Groups | confidence=High score=125
    // v57 raw Tosca: Rating Groups | Description | guid=3a13d49c-1700-b4d2-eba1-480cd99ca1d6 | strategy=retained-semantic
    public ILocator Description8A08D => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description", Exact = true });

    // Source modules: Policy Covg - Signs | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Signs | Description* | guid=3a13d49c-172d-aab8-b2b1-3ca37d275ea5 | strategy=id
    public ILocator DescriptionBE47E => _page.Locator("[id=\"f_iCCB999F03E934DE9BF81315D41AE8572D62_3_6-inputEl\"]");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Motor Truck Cargo | Description* | guid=3a13d49c-172d-5499-1cbc-e4d6043a869a | strategy=id
    public ILocator DescriptionF8E60 => _page.Locator("[id=\"f_i6880B67F580944108A4FCC241C2B2649D62_3_5-inputEl\"]");

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    // v57 raw Tosca: Policy Coverage|Business Interruption | Description Of Business Activites* | guid=3a13d49c-16f1-4863-0a6b-ba22863e5bcb | strategy=retained-semantic
    public ILocator DescriptionOfBusinessActivites => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description Of Business Activites*", Exact = true });

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=124
    // v57 raw Tosca: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Description of Operation(s) | guid=3a13d49c-1700-e2e3-186a-f1c3e341841c | strategy=retained-semantic
    public ILocator DescriptionOfOperationS => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Operation(s)", Exact = true });

    // Source modules: [CG2812] Pesticide or Herbicide Applicator Coverage | confidence=High score=124
    // v57 raw Tosca: [CG2812] Pesticide or Herbicide Applicator Coverage | Description of Operations | guid=3a13d49c-172d-360d-7d57-f32b06b54a5e | strategy=retained-semantic
    public ILocator DescriptionOfOperations => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Operations", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator DescriptionOfSpecifiedOperation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Specified Operation", Exact = true });

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    // v57 raw Tosca: Endorsements|Designated Workplaces Exclusion | Add Another Designated Workplace | guid=3a13d49c-172d-2159-ab76-f0e64da60ed1 | strategy=role-link
    public ILocator DesignatedWorkplacesExclusionOK => _page.GetByRole(AriaRole.Link, new() { Name = "Add Another Designated Workplace", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    // v57 raw Tosca:  | Detail | guid=3a13d49c-1700-371e-c808-c1dcd0cae17d | strategy=role-link
    public ILocator Detail0F8C6 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-371e-c808-c1dcd0cae17d");

    // Source modules: Building - Main | confidence=High score=125
    // v57 raw Tosca: Building - Main | Detail | guid=3a13d49c-1700-5e04-2ffe-320666586ecc | strategy=role-link
    public ILocator Detail10932 => _page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true });

    // Source modules: Risk Aggregate | confidence=High score=125
    // v57 raw Tosca: Risk Aggregate | Detail | guid=3a13d49c-16f1-deb8-4d75-bbc9f5822fad | strategy=role-link
    public ILocator Detail1664B => _page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true });

    // Source modules: Entity Schedule|First Entity Info | confidence=High score=125
    // v57 raw Tosca: Entity Schedule|First Entity Info | Detail | guid=3a13d49c-1688-5f3f-f9fb-eaa1efaa7beb | strategy=role-link
    public ILocator Detail238D5 => _page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true });

    // Source modules: Location | confidence=High score=125
    public ILocator Detail33F0D => _page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true });

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    // v57 raw Tosca: Policy Coverage|Business Interruption | Detail | guid=3a13d49c-16f1-99f2-9bdf-20a0cc1312f3 | strategy=role-link
    public ILocator Detail4A746 => _page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true });

    // Source modules: Property Enter Building RCT | confidence=High score=125
    // v57 raw Tosca: Property Enter Building RCT | Detail | guid=3a13d49c-1700-ad91-0570-4e9d7e5ec0f9 | strategy=role-link
    public ILocator Detail7F662 => _page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Do you have a CDL license?* | guid=3a13d49c-16f1-619a-6d51-ee09b4499af0 | strategy=id
    public ILocator DoYouHaveACDLLicense => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D01119_1_1-inputEl\"]");

    // Source modules: Policy Covg | confidence=High score=125
    // v57 raw Tosca: Policy Covg | Does any Risk generate power other than Private Windmills or Emergency Backup?* | guid=3a13d49c-1700-f4d8-335f-cea3f953bf5e | strategy=retained-semantic
    public ILocator DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-f4d8-335f-cea3f953bf5e");

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Signs | Does the applicant wish to cover any signs inside their premises? | guid=3a13d49c-172d-7973-4877-281d42cd26e2 | strategy=id
    public ILocator DoesTheApplicantWishToCoverAnySignsInsideTheirPremises => _page.Locator("[id=\"f_s5879EFE3310C457293652ECABD56DCF11D_2_2-inputEl\"]");

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    // v57 raw Tosca: [FG 00 13] Automatic Additional Insured - Specific Relationship | Does the insured/applicant request Additional Insured status without a written contract requirement? | guid=3a14cfe4-2e67-dda5-78c3-41f978d1d6d0 | strategy=fieldref
    public ILocator DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionG\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionG\"]");

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    // v57 raw Tosca: [FG 00 13] Automatic Additional Insured - Specific Relationship | Does the insured enter into contracts involving Commercial Snow Removal, including snow removal from residential roofs? | guid=3a14cfe7-4af1-d5c4-64da-17776f6b85ae | strategy=fieldref
    public ILocator DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionH\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionH\"]");

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    // v57 raw Tosca: [FG 00 13] Automatic Additional Insured - Specific Relationship | Does the insured ever enter into contracts for tasks not contemplated in the current liability classifications on the policy? | guid=3a14cfe4-2e59-302a-4cbe-a7169e94b4c9 | strategy=fieldref
    public ILocator DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionF\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionF\"]");

    // Source modules: State Details|Drive Other Car | confidence=High score=124
    // v57 raw Tosca: State Details|Drive Other Car | Drive Other Car | guid=3a13d49c-16f1-6d1a-e24d-5f901818942e | strategy=fieldref
    public ILocator DriveOtherCar => _page.Locator("[fieldref=\"LineStateInput.DriveOtherCarCoverage\"], [data-fieldref=\"LineStateInput.DriveOtherCarCoverage\"]");

    // Source modules:  | confidence=High score=97
    // v57 raw Tosca:  | Driver Detail | guid=3a13d49c-16f1-8593-fb82-d4bcd7479654 | strategy=id
    public ILocator DriverDetail => _page.Locator("[id=\"pageTop\"]");

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: BAP Navigation Links | Driver Schedule | guid=3a13d49c-1688-ec0e-f90a-286d268708f6 | strategy=role-link
    public ILocator DriverSchedule161DF => _page.GetByRole(AriaRole.Link, new() { Name = "Driver Schedule", Exact = true });

    // Source modules: Driver Schedule | confidence=High score=127
    // v57 raw Tosca: Driver Schedule | Driver Schedule | guid=3a13d49c-16f1-2fab-9482-e78cd490ae9e | strategy=id
    public ILocator DriverSchedule79DC6 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Drivers License Number* | guid=3a13d49c-16f1-a644-e984-87e7baf39242 | strategy=retained-semantic
    public ILocator DriversLicenseNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Drivers License Number", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | Dry Cleaning % | guid=3a13d49c-172d-e094-737c-cbbee0538d4e | strategy=id
    public ILocator DryCleaning => _page.Locator("[id=\"f_b71504B515DF24669A165EFFA75C7935615D_2_1-inputEl\"]");

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Risk - Accounts Receivable | % Duplicated Records | guid=3a13d49c-172d-0813-c44a-adb88db5a71a | strategy=id
    public ILocator DuplicatedRecords => _page.Locator("[id=\"f_c4FFD73A13C164B729C39A3F5C851102318_1_1-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | e. Are no smoking rules posted and enforced? | guid=3a13d49c-172d-fa17-f5d9-50a7d601a02f | strategy=id
    public ILocator EAreNoSmokingRulesPostedAndEnforced => _page.Locator("[id=\"f_b90770E4D06DC47CE875AD48619BBB71B17B_2_8-inputEl\"]");

    // Source modules:  | confidence=High score=95
    public ILocator EMail => _page.GetByRole(AriaRole.Textbox, new() { Name = "E-Mail", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Earthquake | guid=3a13d49c-172d-7747-996a-19424b47e3a4 | strategy=id
    public ILocator Earthquake => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF5875174089A_1_1-inputEl\"]");

    // Source modules: Billing | confidence=High score=125
    public ILocator EasyPay => _page.GetByRole(AriaRole.Textbox, new() { Name = "Easy Pay", Exact = true });

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    // v57 raw Tosca: SFP - 10 Liability/Farm | Effective Date | guid=3a13d49c-171e-5800-3f03-2cc8375a9a93 | strategy=retained-semantic
    public ILocator EffectiveDate0E335 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Commercial Auto | confidence=High score=125
    // v57 raw Tosca: Commercial Auto | Effective Date | guid=3a13d49c-171e-05e8-1abc-f456f9988eee | strategy=retained-semantic
    public ILocator EffectiveDate68A1B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Businessowners | confidence=High score=125
    // v57 raw Tosca: Businessowners | Effective Date | guid=3a13d49c-1697-ac3b-2048-796e25a28c0b | strategy=retained-semantic
    public ILocator EffectiveDate6CF3D => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-ac3b-2048-796e25a28c0b");

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator EffectiveDate95094 => _page.GetByRole(AriaRole.Textbox, new() { Name = "EffectiveDate", Exact = true });

    // Source modules: General Liability | confidence=High score=125
    // v57 raw Tosca: General Liability | Effective Date | guid=3a13d49c-171e-1d63-ca87-eb240193eb86 | strategy=retained-semantic
    public ILocator EffectiveDateB3600 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator EffectiveDateB557F => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Building - Detail | confidence=High score=95
    // v57 raw Tosca: Building - Detail | Eligible For Enhanced Wind Rating Program | guid=3a13d49c-1700-57ad-1952-e412f000af01 | strategy=id
    public ILocator EligibleForEnhancedWindRatingProgram => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D02BE_3_1-inputEl\"]");

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    // v57 raw Tosca: State Details|Hired Auto Liability | Employee Hired Autos CheckBox | guid=3a13d49c-16f1-d690-f542-1733a5a337d7 | strategy=fieldref
    public ILocator EmployeeHiredAutosCheckBox => _page.Locator("[fieldref=\"LineStateInput.EmployeeHiredAuto\"], [data-fieldref=\"LineStateInput.EmployeeHiredAuto\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Employers Liab | guid=3a13d49c-1697-9599-a2ea-9374855150e2 | strategy=role-link
    public ILocator EmployersLiab => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-9599-a2ea-9374855150e2");

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: IM Navigation Links | Endorsement | guid=3a13d49c-172d-f6b6-1c29-6cf511c03153 | strategy=role-link
    public ILocator Endorsement => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsement", Exact = true });

    // Source modules: Endorsement - CM 66 01 Exclude Named Customer | confidence=High score=125
    public ILocator EndorsementCM6601ExcludeNamedCustomerOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules:  | confidence=High score=97
    // v57 raw Tosca:  | Endorsement Detail | guid=3a13d49c-16f1-9c7b-acce-7c5dd155d24c | strategy=id
    public ILocator EndorsementDetail => _page.Locator("[id=\"pageTop\"]");

    // Source modules: Endorsement - Main | confidence=High score=97
    // v57 raw Tosca: Endorsement - Main |  Endorsement Heading | guid=3a13d49c-172d-9372-feda-ed7f73106a12 | strategy=id
    public ILocator EndorsementHeading => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-9372-feda-ed7f73106a12");

    // Source modules: Endorsement - IF 00 02 Waterborne Equipment | confidence=High score=125
    public ILocator EndorsementIF0002WaterborneEquipmentOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

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
    // v57 raw Tosca: [CG2401] Non-Binding Arbitration | Endorsement Type | guid=3a13d49c-172d-197f-606e-133a21664896 | strategy=retained-semantic
    public ILocator EndorsementType3503E => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: BAP Endorsements | confidence=High score=125
    // v57 raw Tosca: BAP Endorsements | Endorsement Type | guid=3a13d49c-16f1-31ca-d4bf-b8ea7c68cb32 | strategy=id
    public ILocator EndorsementType624AD => _page.Locator("[id=\"f_lCFA4B66735E24DCDA7F8290E1448DDF960_3_1-inputEl\"]");

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    // v57 raw Tosca: Endorsements|Designated Workplaces Exclusion | Endorsement Type | guid=3a13d49c-172d-23f0-5a1f-c48e26eebc26 | strategy=retained-semantic
    public ILocator EndorsementType8DB33 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: [CG0435] Employee Benefits Liability | confidence=High score=125
    // v57 raw Tosca: [CG0435] Employee Benefits Liability | Endorsement Type | guid=3a13d49c-1700-39e3-be3b-094445d33602 | strategy=retained-semantic
    public ILocator EndorsementTypeA2928 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    // v57 raw Tosca: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Endorsement Type | guid=3a13d49c-172d-127a-e512-5550d56cd1eb | strategy=retained-semantic
    public ILocator EndorsementTypeAEC4F => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=125
    // v57 raw Tosca: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Endorsement Type | guid=3a13d49c-1700-4511-1215-3d9986bec458 | strategy=retained-semantic
    public ILocator EndorsementTypeB210C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: [CG2812] Pesticide or Herbicide Applicator Coverage | confidence=High score=125
    // v57 raw Tosca: [CG2812] Pesticide or Herbicide Applicator Coverage | Endorsement Type | guid=3a13d49c-172d-05e1-6dd9-c105f866e9f3 | strategy=retained-semantic
    public ILocator EndorsementTypeC75E4 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: [CG0424] Coverage for Injury to Leased Workers | confidence=High score=125
    // v57 raw Tosca: [CG0424] Coverage for Injury to Leased Workers | Endorsement Type | guid=3a13d49c-172d-ca6b-6f6d-abb472fe717f | strategy=retained-semantic
    public ILocator EndorsementTypeCE99F => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: [CG 2149] Total Pollution Exclusion Endorsement | confidence=High score=125
    // v57 raw Tosca: [CG 2149] Total Pollution Exclusion Endorsement | Endorsement Type | guid=3a13d49c-1700-7ca8-1323-67e806e535a1 | strategy=retained-semantic
    public ILocator EndorsementTypeD83A4 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=125
    // v57 raw Tosca: Endorsements|Partners, Officers And Others Exclusion | Endorsement Type | guid=3a13d49c-172d-01ea-ecb1-1fe812e844ae | strategy=id
    public ILocator EndorsementTypeF8D4A => _page.Locator("[id=\"f_c19BE39E5AC0F487CBB1049569BE6DC56236_3_6-inputEl\"]");

    // Source modules: GL Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: GL Navigation Links | Endorsements | guid=3a13d49c-16f1-6ee5-b6f2-1ec6da80521a | strategy=role-link
    public ILocator Endorsements7572E => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-6ee5-b6f2-1ec6da80521a");

    // Source modules: Endorsements|Main | confidence=High score=127
    // v57 raw Tosca: Endorsements|Main | Endorsements | guid=3a13d49c-1700-454b-5278-9f3e549fbf37 | strategy=id
    public ILocator Endorsements9626E => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-454b-5278-9f3e549fbf37");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Endorsements | guid=3a13d49c-1697-7e30-e0a2-31e24f349a2e | strategy=role-link
    public ILocator Endorsements9D4A5 => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsements", Exact = true });

    // Source modules: WC Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: WC Navigation Links | Endorsements | guid=3a13d49c-1688-7be0-ea6d-f02435927df8 | strategy=role-link
    public ILocator EndorsementsB76E9 => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsements", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: BAP Navigation Links | Endorsements | guid=3a13d49c-1688-0928-e023-e96ae692cae4 | strategy=role-link
    public ILocator EndorsementsC27F0 => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsements", Exact = true });

    // Source modules: Endorsements - Main Screen | confidence=High score=127
    // v57 raw Tosca: Endorsements - Main Screen | Endorsements Heading | guid=3a13d49c-171e-e942-580d-9fcdbced6e3c | strategy=id
    public ILocator EndorsementsHeading8FD33 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: BAP Endorsement Schedule | confidence=High score=127
    // v57 raw Tosca: BAP Endorsement Schedule | Endorsements Heading | guid=3a13d49c-16f1-c7dd-19be-14718646e3c2 | strategy=id
    public ILocator EndorsementsHeadingA3D50 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Risk Schedule|General Coverage | confidence=High score=95
    // Only Applicable to Golf Carts
    // v57 raw Tosca: Risk Schedule|General Coverage | Engine Size (cc)* | guid=3a13d49c-16f1-7569-ec10-7de5d84b865b | strategy=retained-semantic
    public ILocator EngineSizeCc => _page.GetByRole(AriaRole.Textbox, new() { Name = "Engine Size (cc)*", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EntityInfoFrame => _page.GetByText("Entity Info Frame", new() { Exact = true });

    // Source modules: Entity Schedule|Main | confidence=High score=127
    // v57 raw Tosca: Entity Schedule|Main | Entity Schedule | guid=3a13d49c-1688-f567-df6b-d083a407de97 | strategy=id
    public ILocator EntityScheduleE6C9F => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: WC Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: WC Navigation Links | Entity Schedule | guid=3a13d49c-1688-f0cf-cf18-62f9af222c57 | strategy=role-link
    public ILocator EntityScheduleEA671 => _page.GetByRole(AriaRole.Link, new() { Name = "Entity Schedule", Exact = true });

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Contractors Equipment | Estimated Highest Value | guid=3a13d49c-172d-12de-87e2-7ce3d2b485fc | strategy=id
    public ILocator EstimatedHighestValue => _page.Locator("[id=\"f_c43D7743D9BD44829A7C9322C2ACC793C55_2_1-inputEl\"]");

    // Source modules: Property Enter Building RCT | confidence=High score=125
    // v57 raw Tosca: Property Enter Building RCT | Estimator Type* | guid=3a13d49c-1700-3945-530f-58b11f0733e1 | strategy=retained-semantic
    public ILocator EstimatorType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Estimator Type*", Exact = true });

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    // v57 raw Tosca: State Details|Hired Auto Liability | Excess Liability If Any | guid=3a13d49c-16f1-71c0-202f-92a6ba59ad02 | strategy=fieldref
    public ILocator ExcessLiabilityIfAny => _page.Locator("[fieldref=\"CovHiredAndBorrowedExcessLiabilityInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedExcessLiabilityInput.IfAny\"]");

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=124
    // v57 raw Tosca: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Exclude Collapse Hazard | guid=3a13d49c-1700-3c58-194d-5fd9d56e257e | strategy=fieldref
    public ILocator ExcludeCollapseHazard => _page.Locator("[fieldref=\"CovEndorsementsInput.IndicatorCollapseCG2142\"], [data-fieldref=\"CovEndorsementsInput.IndicatorCollapseCG2142\"]");

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=124
    // v57 raw Tosca: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Exclude Explosion Hazard | guid=3a13d49c-1700-3c17-33af-fd9679a1e171 | strategy=fieldref
    public ILocator ExcludeExplosionHazard => _page.Locator("[fieldref=\"CovEndorsementsInput.IndicatorExplosionCG2142\"], [data-fieldref=\"CovEndorsementsInput.IndicatorExplosionCG2142\"]");

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=124
    // v57 raw Tosca: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Exclude Underground Property Damage Hazard | guid=3a13d49c-1700-e550-22ce-3a4125c40dfb | strategy=canonical-alias
    public ILocator ExcludeUndergroundPropertyDamageHazard => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-e550-22ce-3a4125c40dfb");

    // Source modules: Policy Covg | confidence=High score=95
    // v57 raw Tosca: Policy Covg | Excluded Liability - Confidential Information* | guid=3a13d49c-16f1-7c85-7830-ad539ac11200 | strategy=retained-semantic
    public ILocator ExcludedLiabilityConfidentialInformation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Excluded Liability - Confidential Information*", Exact = true });

    // Source modules: State Details|Experience Rated | confidence=High score=95
    // v57 raw Tosca: State Details|Experience Rated | Experience Mod Type* | guid=3a13d49c-172d-fefe-807d-56833919b2f2 | strategy=retained-semantic
    public ILocator ExperienceModType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Experience Mod Type*", Exact = true });

    // Source modules: Policy Covg | confidence=High score=125
    // v57 raw Tosca: Policy Covg | Experience Rated | guid=3a13d49c-171e-e74c-19c4-409d791a0e8b | strategy=retained-semantic
    public ILocator ExperienceRated => _page.GetByRole(AriaRole.Textbox, new() { Name = "Experience Rated", Exact = true });

    // Source modules: State Details|Experience Rated | confidence=High score=95
    // v57 raw Tosca: State Details|Experience Rated | Experience Rating Options | guid=3a13d49c-172d-a458-10e1-90e40823fb32 | strategy=retained-semantic
    public ILocator ExperienceRatingOptions => _page.GetByRole(AriaRole.Textbox, new() { Name = "Experience Rating Options", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator ExpirationDate34EAC => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    // v57 raw Tosca: SFP - 10 Liability/Farm | Expiration Date | guid=3a13d49c-171e-a721-2bbf-00c4743abec6 | strategy=retained-semantic
    public ILocator ExpirationDate664A1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    // Source modules: Businessowners | confidence=High score=125
    // v57 raw Tosca: Businessowners | Expiration Date | guid=3a13d49c-1697-62eb-1046-d8904ca7eb14 | strategy=retained-semantic
    public ILocator ExpirationDate82561 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-62eb-1046-d8904ca7eb14");

    // Source modules: General Liability | confidence=High score=125
    // v57 raw Tosca: General Liability | Expiration Date | guid=3a13d49c-171e-cf20-a0e6-37de2122d60c | strategy=retained-semantic
    public ILocator ExpirationDateB437C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    // Source modules: CGL|Main Page | confidence=High score=125
    // v57 raw Tosca: CGL|Main Page | Exposure | guid=3a13d49c-1700-671e-5542-cf2c8f2bb322 | strategy=retained-semantic
    public ILocator Exposure => _page.GetByRole(AriaRole.Textbox, new() { Name = "Exposure", Exact = true });

    // Source modules: Policy Coverage|NonOwned | confidence=High score=124
    // v57 raw Tosca: Policy Coverage|NonOwned | Extended Employee Coverage | guid=3a13d49c-16f1-feba-d20e-faa64ee8a05a | strategy=fieldref
    public ILocator ExtendedEmployeeCoverage => _page.Locator("[fieldref=\"RiskNonOwnedAutoInput.ExtendedEmployeeCov\"], [data-fieldref=\"RiskNonOwnedAutoInput.ExtendedEmployeeCov\"]");

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Computer Systems | Extra Expense | guid=3a13d49c-172d-ade4-c7df-187674ca563b | strategy=id
    public ILocator ExtraExpense => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8C_3_4-inputEl\"]");

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=125
    public ILocator FG0013AutomaticAdditionalInsuredSpecificRelationshipOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Location | confidence=High score=125
    // v57 raw Tosca: Location | Feet From Hydrant | guid=3a13d49c-1700-4634-82df-f1bc31796d60 | strategy=retained-semantic
    public ILocator FeetFromHydrant => _page.GetByRole(AriaRole.Textbox, new() { Name = "Feet From Hydrant", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Fire Damage | guid=3a13d49c-1700-2650-8f24-19c05dba284b | strategy=retained-semantic
    public ILocator FireDamage => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-2650-8f24-19c05dba284b");

    // Source modules: State Details|Drive Other Car | confidence=High score=125
    // v57 raw Tosca: State Details|Drive Other Car | First Name | guid=3a13d49c-16f1-0695-46f0-23eeadd186fe | strategy=retained-semantic
    public ILocator FirstName5059E => _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name", Exact = true });

    // Source modules:  | confidence=High score=125
    // v57 raw Tosca:  | First Name* | guid=3a13d49c-16f1-7104-229a-892e18f1a07f | strategy=id
    public ILocator FirstName813D1 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-7104-229a-892e18f1a07f");

    // Source modules: Risk Schedule|Risk Specific | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Risk Specific | GCW* | guid=3a13d49c-16f1-58a7-3ef9-e9c03ece897a | strategy=retained-semantic
    public ILocator GCW => _page.GetByRole(AriaRole.Textbox, new() { Name = "GCW*", Exact = true });

    // Source modules: Policy Info|CPP Specific Fields | confidence=High score=95
    // CPP Only
    // v57 raw Tosca: Policy Info|CPP Specific Fields | GL Detail | guid=3a13d49c-1697-96dc-c6f3-092008556670 | strategy=role-link
    public ILocator GLDetail => _page.GetByRole(AriaRole.Link, new() { Name = "GL Detail", Exact = true });

    // Source modules: GL Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: GL Navigation Links | GL UW Questions | guid=3a13d49c-16f1-3500-6149-02fc0e13c711 | strategy=role-link
    public ILocator GLUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "GL UW Questions", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | General Liab | guid=3a13d49c-1697-0f88-b883-20bf5c0d330f | strategy=role-link
    public ILocator GeneralLiab => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-0f88-b883-20bf5c0d330f");

    // Source modules: General Liability | confidence=High score=97
    // v57 raw Tosca: General Liability | General Liability | guid=3a13d49c-171e-091c-ec37-a0755608b039 | strategy=id
    public ILocator GeneralLiability => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: General Liability Information | confidence=High score=97
    // v57 raw Tosca: General Liability Information | General Liability Information | guid=3a13d49c-1700-d017-0ba5-688c8af0bf55 | strategy=id
    public ILocator GeneralLiabilityInformation => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-d017-0ba5-688c8af0bf55");

    // Source modules: General Liability Information | confidence=High score=125
    // v57 raw Tosca: General Liability Information | General Liability Information | guid=3a13d49c-1700-d017-0ba5-688c8af0bf55 | strategy=canonical-alias
    public ILocator GeneralLiabilityInformationOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-d017-0ba5-688c8af0bf55");

    // Source modules: Underwriting Info | General UW Questions | confidence=High score=127
    public ILocator GeneralUWQuestions => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "General UW Questions");

    // Source modules: Property Enter Building RCT | confidence=High score=125
    // v57 raw Tosca: Property Enter Building RCT | Get Calculated Value | guid=3a13d49c-1700-7f6e-2aab-57ed93eb68a1 | strategy=role-link
    public ILocator GetCalculatedValue => _page.GetByRole(AriaRole.Link, new() { Name = "Get Calculated Value", Exact = true });

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Motor Truck Cargo | Group Class | guid=3a13d49c-172d-ca9b-8600-1bb964ee3855 | strategy=id
    public ILocator GroupClass => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB401088_3_5-inputEl\"]");

    // Source modules: Underwriting Questions | confidence=High score=125
    // v57 raw Tosca: Underwriting Questions | Has any applicant been convicted of a felony or been involved in any incidents or claims relating to sexual abuse or molestation allegations, discrimination, arson, fraud, bribery or negligent hiring | guid=3a13d49c-16f1-4fb9-99e3-4bbfea8e6d0d | strategy=retained-semantic
    public ILocator HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring => _page.GetByRole(AriaRole.Textbox, new() { Name = "Has any applicant been convicted of a felony or been involved in any incidents or claims relating to sexual abuse or molestation allegations, discrimination, arson, fraud, bribery or negligent hiring", Exact = true });

    // Source modules: UW Questions - Umbrella | confidence=High score=95
    // v57 raw Tosca: UW Questions - Umbrella | Have you had any liability losses in the last 5 years on any primary or excess policy?* | guid=3a13d49c-171e-e907-749e-81f71a857b5e | strategy=retained-semantic
    public ILocator HaveYouHadAnyLiabilityLossesInTheLast5YearsOnAnyPrimaryOrExcessPolicy => _page.GetByRole(AriaRole.Textbox, new() { Name = "Have you had any liability losses in the last 5 years on any primary or excess policy?*", Exact = true });

    // Source modules: Client|Third Party Designee|Common | confidence=High score=97
    // v57 raw Tosca: Client|Third Party Designee|Common | Heading Third Party Designee | guid=3a13d49c-16f1-81cd-73f3-f16a03c5dea2 | strategy=id
    public ILocator HeadingThirdPartyDesignee => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Hired Auto | HiredAuto CA2001 Address1 | guid=3a13d49c-16f1-0091-2625-0bd653523372 | strategy=retained-semantic
    public ILocator HiredAutoCA2001Address1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "HiredAuto CA2001 Address1", Exact = true });

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Hired Auto | HiredAuto CA2001 First Name | guid=3a13d49c-16f1-11f7-d1ff-47d7ae845112 | strategy=retained-semantic
    public ILocator HiredAutoCA2001FirstName => _page.GetByRole(AriaRole.Textbox, new() { Name = "HiredAuto CA2001 First Name", Exact = true });

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Hired Auto | HiredAuto CA2001 Last Name | guid=3a13d49c-16f1-e525-0c70-4b76c52a4124 | strategy=retained-semantic
    public ILocator HiredAutoCA2001LastName => _page.GetByRole(AriaRole.Textbox, new() { Name = "HiredAuto CA2001 Last Name", Exact = true });

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Hired Auto | HiredAuto CA2001 ZipCode | guid=3a13d49c-16f1-5f5b-2027-d30318ef04c5 | strategy=retained-semantic
    public ILocator HiredAutoCA2001ZipCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "HiredAuto CA2001 ZipCode", Exact = true });

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=125
    // v57 raw Tosca: Risk Schedule|Hired Auto | Hired Auto Ext Addl Insured | guid=3a13d49c-16f1-bea4-c939-691e77db64c6 | strategy=retained-semantic
    public ILocator HiredAutoExtAddlInsured => _page.GetByRole(AriaRole.Textbox, new() { Name = "Hired Auto Ext Addl Insured", Exact = true });

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=125
    // v57 raw Tosca: Risk Schedule|Hired Auto | Hired Auto Form* | guid=3a13d49c-16f1-7dec-7fe6-bf7cff13bc04 | strategy=retained-semantic
    public ILocator HiredAutoForm => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-7dec-7fe6-bf7cff13bc04");

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    // v57 raw Tosca: State Details|Hired Auto Liability | Hired Auto Liability | guid=3a13d49c-16f1-8ef0-c83b-2d4c0a6ede2a | strategy=fieldref
    public ILocator HiredAutoLiability => _page.Locator("[fieldref=\"LineStateInput.HiredLiability\"], [data-fieldref=\"LineStateInput.HiredLiability\"]");

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=125
    // v57 raw Tosca: Risk Schedule|Hired Auto | Hired Auto Form* | guid=3a13d49c-16f1-7dec-7fe6-bf7cff13bc04 | strategy=canonical-alias
    public ILocator HiredAutoOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-7dec-7fe6-bf7cff13bc04");

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=124
    // v57 raw Tosca: State Details|Hired Auto Physical Damage With Driver | Hired Auto Physical Damage With Driver | guid=3a13d49c-16f1-a17c-0533-32e5fea467e1 | strategy=fieldref
    public ILocator HiredAutoPhysicalDamageWithDriver => _page.Locator("[fieldref=\"LineStateInput.HiredPhysicalDamageWithDriver\"], [data-fieldref=\"LineStateInput.HiredPhysicalDamageWithDriver\"]");

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=124
    // v57 raw Tosca: State Details|Hired Auto PD Without Driver | Hired Auto Physical Damage Without Driver | guid=3a13d49c-16f1-7a69-edc8-f03b79682682 | strategy=fieldref
    public ILocator HiredAutoPhysicalDamageWithoutDriver => _page.Locator("[fieldref=\"LineStateInput.HiredPhysicalDamage\"], [data-fieldref=\"LineStateInput.HiredPhysicalDamage\"]");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Contractors Equipment | Hired Equipment | guid=3a13d49c-172d-09c1-9042-5ba54004d493 | strategy=id
    public ILocator HiredEquipment => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FEE_3_1-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | How often is data backed up? | guid=3a13d49c-172d-9cf2-2534-c15f55cd2d93 | strategy=name
    public ILocator HowOftenIsDataBackedUp => _page.Locator("[name=\"string_2F_5\"]");

    // Source modules: Policy Coverage|Business Interruption|Option A Schedule | confidence=Review score=97
    // v57 raw Tosca: Policy Coverage|Business Interruption|Option A Schedule | IFRAME | guid=3a13d49c-16f1-2a5b-db02-998945572181 | strategy=associatedlabel-from-v55
    public ILocator IFRAME280B0 => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "IFRAME");

    // Source modules: Additional Interests Schedule | confidence=Review score=97
    // v57 raw Tosca: Additional Interests Schedule | IFRAME | guid=3a13d49c-16f1-7cd9-60cf-208df0b54f3f | strategy=associatedlabel-from-v55
    public ILocator IFRAME59D4B => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "IFRAME");

    // Source modules: Driver Detail | confidence=Review score=97
    // v57 raw Tosca: Driver Detail | IFRAME | guid=3a13d49c-16f1-09ae-9edf-67d4cefb459b | strategy=id
    public ILocator IFRAME6D695 => _page.Locator("[id=\"dctPopup_dctPopupWindow34CAB0C1A0A47F298A990A36C62FE6D0\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedFarmLocationS => _page.GetByText("Address(es) or Description(s) of Designated Farm Location(s):", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyAddressEsOrDescriptionSOfDesignatedPremises => _page.GetByText("Address(es) or Description(s) of Designated Premises:", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyDescriptionOfPremisesOrActivities => _page.GetByText("Description Of Premises Or Activities", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyExcludedDriver => _page.GetByText("Excluded Driver", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyNameSOrDescriptionSOfDesignatedAnimalS => _page.GetByText("Name(s) or Description(s) of Designated Animal(s):", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyVehicleAssociation => _page.GetByText("Vehicle Association*", new() { Exact = true });

    // Source modules: BAP Endorsements | confidence=Review score=97
    // v57 raw Tosca: BAP Endorsements | IFRAME | guid=3a13d49c-16f1-5fb8-0a01-967fde6320c1 | strategy=id
    public ILocator IFRAMEF0A48 => _page.Locator("[id=\"dctPopup_dctPopupWindow1631A82AB27744695E74FDAA3357B203\"]");

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=124
    // v57 raw Tosca: Specific Underwriting Questions - Contractors Equipment | If Yes, describe | guid=3a13d49c-172d-628a-f3ef-5bcb44374726 | strategy=fieldref
    public ILocator IfYesDescribe => _page.Locator("[fieldref=\"ContractorsEquipmentUnderwritingQuestionsInput.Description\"], [data-fieldref=\"ContractorsEquipmentUnderwritingQuestionsInput.Description\"]");

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    // v57 raw Tosca: [FG 00 13] Automatic Additional Insured - Specific Relationship | If yes, explain. | guid=3a14cfe7-4aea-99dc-3e59-08827a756ec9 | strategy=fieldref
    public ILocator IfYesExplain => _page.Locator("[fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionFsub\"], [data-fieldref=\"AdditionalOtherInterestUnderwritingQuestionsInput.AIUWQuestionFsub\"]");

    // Source modules: Commercial Auto | confidence=High score=95
    // v57 raw Tosca: Commercial Auto | Import Policy Data Button | guid=3a13d49c-171e-f796-cb64-cd740170c89d | strategy=role-link
    public ILocator ImportPolicyDataButton89922 => _page.GetByRole(AriaRole.Link, new() { Name = "Import Policy Data", Exact = true });

    // Source modules: Businessowners | confidence=High score=95
    // v57 raw Tosca: Businessowners | Import Policy Data Button | guid=3a13d49c-1697-5b7e-1059-24533633c948 | strategy=role-link
    public ILocator ImportPolicyDataButtonEF44C => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-5b7e-1059-24533633c948");

    // Source modules: Property - Main | confidence=High score=95
    // v57 raw Tosca: Property - Main | Increased Pollutant Cleanup | guid=3a13d49c-1700-f0ae-4890-5c3ec47a1477 | strategy=retained-semantic
    public ILocator IncreasedPollutantCleanup => _page.GetByRole(AriaRole.Textbox, new() { Name = "Increased Pollutant Cleanup", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | Indicate the building(s) age, type of construction, and protection class, and other tenants in the building(s) where the computer equipment is located | guid=3a13d49c-172d-bcd8-8950-c8780d50a509 | strategy=name
    public ILocator IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated => _page.Locator("[name=\"string_2F_1\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator InsuranceHistory => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance History", Exact = true });

    // Source modules:  | confidence=High score=125
    // v57 raw Tosca:  | Insured Type* | guid=3a13d49c-1679-fa35-fde2-a6f6475ff53f | strategy=retained-semantic
    public ILocator InsuredType => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-fa35-fde2-a6f6475ff53f");

    // Source modules: Building - Detail | confidence=High score=95
    // v57 raw Tosca: Building - Detail | Interest | guid=3a13d49c-1700-6a86-9633-ca4eecb005c8 | strategy=id
    public ILocator Interest => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0249_3_1-inputEl\"]");

    // Source modules: State Details|Main | confidence=High score=95
    // v57 raw Tosca: State Details|Main | Intrastate Risk ID | guid=3a13d49c-171e-d7c3-fece-faee372aa918 | strategy=retained-semantic
    public ILocator IntrastateRiskID => _page.GetByRole(AriaRole.Textbox, new() { Name = "Intrastate Risk ID", Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    // v57 raw Tosca: Building - Detail | Is the building cooled?* | guid=3a13d49c-1700-4f0c-cbd3-854e27f54d04 | strategy=id
    public ILocator IsTheBuildingCooled => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D02AD_3_1-inputEl\"]");

    // Source modules: Building - Detail | confidence=High score=125
    // v57 raw Tosca: Building - Detail | Is the building heated with a Solid Fuel Heating Device?* | guid=3a13d49c-1700-bec6-52bd-92d76be1ccaf | strategy=id
    public ILocator IsTheBuildingHeatedWithASolidFuelHeatingDevice => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0296_3_1-inputEl\"]");

    // Source modules: Policy Covg|GL | confidence=High score=125
    // v57 raw Tosca: Policy Covg|GL | Is the Insured engaged in any Snow or Ice Removal Operations?* | guid=3a13d49c-1700-9844-6210-6e05ab67ffc8 | strategy=retained-semantic
    public ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-9844-6210-6e05ab67ffc8");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator IsThereAPriorCarrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is there a Prior Carrier?*", Exact = true });

    // Source modules: Submission|Required and Optional Fields | confidence=Medium score=113
    public ILocator IsThisCoverageBound => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is this coverage bound?*", Exact = true });

    // Source modules:  | confidence=High score=95
    // Required for Commit/ Submission when Policy Number is blank.
    public ILocator IsThisPolicyBeingFullyCancelled => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is this policy being fully cancelled?*", Exact = true });

    // Source modules: Risk Schedule|Risk Specific | confidence=High score=125
    // Only applicable to trucks
    // v57 raw Tosca: Risk Schedule|Risk Specific | Is This Vehicle Used In Snow Plow Operations?* | guid=3a13d49c-16f1-ff86-57d5-72da7c2f4d75 | strategy=retained-semantic
    public ILocator IsThisVehicleUsedInSnowPlowOperations => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is This Vehicle Used In Snow Plow Operations?*", Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The JavaScript code to execute. Use a return statement in the code to specify the return value.
    public ILocator JavaScript => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "JavaScript");

    // Source modules:  | confidence=High score=125
    // v57 raw Tosca:  | Last Name* | guid=3a13d49c-16f1-fd52-8a69-a72f6ca273e5 | strategy=id
    public ILocator LastName34FF6 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-fd52-8a69-a72f6ca273e5");

    // Source modules: State Details|Drive Other Car | confidence=High score=125
    // v57 raw Tosca: State Details|Drive Other Car | Last Name | guid=3a13d49c-16f1-3b95-8891-3a2f0675f496 | strategy=retained-semantic
    public ILocator LastName5E149 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | Laundry % | guid=3a13d49c-172d-3c94-b41b-a511e02e5bb2 | strategy=id
    public ILocator Laundry => _page.Locator("[id=\"f_bD3790336B18440B2B60CC0B7F5F4E10315D_2_2-inputEl\"]");

    // Source modules: Risk - Signs | confidence=High score=125
    // v57 raw Tosca: Risk - Signs | Lettering | guid=3a13d49c-172d-9f8f-d8b4-140c79d24862 | strategy=id
    public ILocator Lettering => _page.Locator("[id=\"f_r99A2986D696A457DA1C69BB16D902CEF19_1_1-inputEl\"]");

    // Source modules: Commercial Auto | confidence=High score=125
    // v57 raw Tosca: Commercial Auto | Liability Limit* | guid=3a13d49c-171e-4b30-555c-4b79b411c0fd | strategy=retained-semantic
    public ILocator LiabilityLimit1AE2B => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-4b30-555c-4b79b411c0fd");

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    // v57 raw Tosca: SFP - 10 Liability/Farm | Liability Limit* | guid=3a13d49c-171e-e8a5-23c7-e2af2302fc8e | strategy=retained-semantic
    public ILocator LiabilityLimit56E57 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Liability Limit*", Exact = true });

    // Source modules: Policy Covg - Bailees - Property Away from Your Premises | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Bailees - Property Away from Your Premises | Limit | guid=3a13d49c-172d-48b1-d169-abc744eaed19 | strategy=id
    public ILocator Limit46632 => _page.Locator("[id=\"f_b7BA9D20D6B9840E99A47B1B0DFA716BF8_1_1-inputEl\"]");

    // Source modules: Endorsement - IF 00 02 Waterborne Equipment | confidence=High score=125
    // v57 raw Tosca: Endorsement - IF 00 02 Waterborne Equipment | Limit | guid=3a13d49c-172d-35f5-b36a-ceacfcb7ee3a | strategy=id
    public ILocator Limit887C5 => _page.Locator("[id=\"f_c4CA5AF1ED9DF445F976D32FE5E1139DD11C_3_14-inputEl\"]");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Limit | guid=3a13d49c-172d-e216-0534-71b7b5030614 | strategy=id
    public ILocator LimitE32DC => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740895_1_1-inputEl\"]");

    // Source modules: Risk - Signs | confidence=High score=125
    // v57 raw Tosca: Risk - Signs | Limit of Insurance | guid=3a13d49c-172d-4971-b40f-efb3c799f5d5 | strategy=id
    public ILocator LimitOfInsurance => _page.Locator("[id=\"f_r99A2986D696A457DA1C69BB16D902CEF16_1_1-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | Line conditioner?* | guid=3a13d49c-172d-af85-0dd0-7aa6adf6b998 | strategy=id
    public ILocator LineConditioner => _page.Locator("[id=\"f_c7FA512A090F641B9A6BB95F4C656EE183F_2_21-inputEl\"]");

    // Source modules: UW Questions - Workers Comp | confidence=High score=124
    // v57 raw Tosca: UW Questions - Workers Comp | List all policies with American National | guid=3a13d49c-171e-6aec-172e-94d69c4c4cb1 | strategy=fieldref
    public ILocator ListAllPoliciesWithAmericanNational => _page.Locator("[fieldref=\"UnderwritingQuestionsWorkersCompInput.ListAllPoliciesWithAmericanNational\"], [data-fieldref=\"UnderwritingQuestionsWorkersCompInput.ListAllPoliciesWithAmericanNational\"]");

    // Source modules: Indicators and Errors | confidence=High score=127
    // This DIV appears during a refresh of the screen (working in the background) and can be used as a WaitOn for stability.
    public ILocator LoadingMessage => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Loading Message");

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Physical Damage | Loan/Lease Gap | guid=3a13d49c-16f1-2352-1e71-b8a9a86394a2 | strategy=retained-semantic
    public ILocator LoanLeaseGap => _page.GetByRole(AriaRole.Textbox, new() { Name = "Loan/Lease Gap", Exact = true });

    // Source modules: Location | confidence=High score=127
    public ILocator Location82D95 => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Location");

    // Source modules: WC Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: WC Navigation Links | Location | guid=3a13d49c-1688-33ca-1014-364d9317d3a5 | strategy=role-link
    public ILocator Location8DEE2 => _page.GetByRole(AriaRole.Link, new() { Name = "Location", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: BAP Navigation Links | Location | guid=3a13d49c-1688-0165-bda1-6b97fd6ce589 | strategy=role-link
    public ILocator LocationA1D91 => _page.GetByRole(AriaRole.Link, new() { Name = "Location", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LocationAssignment => _page.GetByText("Location Assignment", new() { Exact = true });

    // Source modules: CP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: CP Navigation Links | Location | guid=3a13d49c-1700-a206-f21f-b7604b8dee41 | strategy=role-link
    public ILocator LocationB7B1D => _page.GetByRole(AriaRole.Link, new() { Name = "Location", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Location | guid=3a13d49c-1697-fc28-0f0b-68b96538562a | strategy=role-link
    public ILocator LocationE16BC => _page.GetByRole(AriaRole.Link, new() { Name = "Location", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | LocationID | guid=3a13d49c-1688-6208-eaea-0fe3387c8dab | strategy=retained-semantic
    public ILocator LocationID => _page.GetByRole(AriaRole.Textbox, new() { Name = "LocationID", Exact = true });

    // Source modules: Location | confidence=High score=125
    public ILocator LocationOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=125
    // v57 raw Tosca: GL OCP|Risk | Location Of Covered Operations | guid=3a13d49c-172d-cc1e-2242-7c90fe68ce35 | strategy=id
    public ILocator LocationOfCoveredOperations => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA7059_3_1-inputEl\"]");

    // Source modules: Underwriting Info | Loss Experience | confidence=Medium score=113
    public ILocator LossExperience => _page.GetByRole(AriaRole.Link, new() { Name = "Loss Experience", Exact = true });

    // Source modules: Underwriting Info | Loss Experience | confidence=High score=97
    public ILocator LossExperienceHeading => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Loss Experience Heading");

    // Source modules: CGL|Main Page | confidence=High score=125
    // v57 raw Tosca: CGL|Main Page | OK | guid=3a13d49c-1700-c3b6-9868-af20e3c9b826 | strategy=role-link
    public ILocator MainPageOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=125
    // v57 raw Tosca: Risk Schedule|Vehicle Information | Make* | guid=3a13d49c-16f1-5dc5-478e-e59a27920fbd | strategy=retained-semantic
    public ILocator Make => _page.GetByRole(AriaRole.Textbox, new() { Name = "Make*", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Marital Status | guid=3a13d49c-16f1-c46e-6373-1acc784889f2 | strategy=id
    public ILocator MaritalStatus => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D2_1_1-inputEl\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Medical | guid=3a13d49c-1700-1b2e-8774-90d2b00bf944 | strategy=retained-semantic
    public ILocator Medical => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-1b2e-8774-90d2b00bf944");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator MeritRating => _page.GetByText("Merit Rating", new() { Exact = true });

    // Source modules: Location | confidence=High score=125
    // v57 raw Tosca: Location | Miles From Fire Department | guid=3a13d49c-1700-2d93-3880-182cc2bd482d | strategy=retained-semantic
    public ILocator MilesFromFireDepartment => _page.GetByRole(AriaRole.Textbox, new() { Name = "Miles From Fire Department", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Contractors Equipment | Misc Items Blanket Coverage | guid=3a13d49c-172d-e259-c42a-f7c694794af6 | strategy=id
    public ILocator MiscItemsBlanketCoverage => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FEC_3_1-inputEl\"]");

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=125
    // v57 raw Tosca: Risk Schedule|Vehicle Information | Model* | guid=3a13d49c-16f1-bb08-4ed7-763a5122c8c9 | strategy=retained-semantic
    public ILocator Model => _page.GetByRole(AriaRole.Textbox, new() { Name = "Model*", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    // v57 raw Tosca: Pricing | Modification Factor | guid=3a13d49c-1697-4099-cdcb-b51261d5962d | strategy=retained-semantic
    public ILocator ModificationFactor => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-4099-cdcb-b51261d5962d");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=97
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | Motor Truck Cargo Heading | guid=3a13d49c-172d-a839-9b33-e38cdfe8a68c | strategy=id
    public ILocator MotorTruckCargoHeading => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: IM Navigation Links | Motor Truck Cargo UW Questions | guid=3a13d49c-172d-6de2-8afe-806b0b3117f3 | strategy=role-link
    public ILocator MotorTruckCargoUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Motor Truck Cargo", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Motorcycle Liability | guid=3a13d49c-1697-f277-7905-08e882cb4baa | strategy=role-link
    public ILocator MotorcycleLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-f277-7905-08e882cb4baa");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 10. Are the premises equipped with a recognized approved central station fire alarm, fire extinguishers or smoke alarms? | guid=3a13d49c-172d-d8f5-a28e-c541b4358084 | strategy=id
    public ILocator N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms => _page.Locator("[id=\"f_b7DEEC9594E6B4D83BD0180865919757B16B_2_10-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 10. How are the goods being transported protected from damage and theft? | guid=3a13d49c-172d-97ca-ca70-fae8972964fc | strategy=name
    public ILocator N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft => _page.Locator("[name=\"string_92_3\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 11. Are drivers’ MVRs and trip logs maintained? | guid=3a13d49c-172d-d6b1-4cac-7224edbc69b6 | strategy=id
    public ILocator N11AreDriversMVRsAndTripLogsMaintained => _page.Locator("[id=\"f_m2B14DC917C294E2289B9F03AAECA7FDD90_2_11-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 11. What is the procedure for transporting property? Include the transit methods used and the protection class provided while in transit. | guid=3a13d49c-172d-552d-ae13-5b17d658fd89 | strategy=name
    public ILocator N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit => _page.Locator("[name=\"string_169_3\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 12. Are drivers’ MVRs reviewed on a regular basis and maintained? | guid=3a13d49c-172d-5212-8322-51a118840e73 | strategy=id
    public ILocator N12AreDriversMVRsReviewedOnARegularBasisAndMaintained => _page.Locator("[id=\"f_bB1C8725295D646D28E8F8F6AFF6DCD4A16B_2_12-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 12. How often are these logs reviewed or updated? | guid=3a13d49c-172d-5f42-9543-9e6d891e9850 | strategy=name
    public ILocator N12HowOftenAreTheseLogsReviewedOrUpdated => _page.Locator("[name=\"string_92_4\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 13. Live animal in transit coverage? | guid=3a13d49c-172d-5a66-bc50-306cff1959ec | strategy=id
    public ILocator N13LiveAnimalInTransitCoverage => _page.Locator("[id=\"f_mDB9F63B542BB45E4A6ED96CA4FEB0A4D99_2_13-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 13. What types of vehicles do you operate and what protective devices are on each vehicle? | guid=3a13d49c-172d-604a-a9b8-3fbe75e46e95 | strategy=name
    public ILocator N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle => _page.Locator("[name=\"string_169_4\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 14. Legal Liability coverage? | guid=3a13d49c-172d-f8af-c0c1-ba283f879234 | strategy=id
    public ILocator N14LegalLiabilityCoverage => _page.Locator("[id=\"f_m1DC94D997BEB443ABFC8A1974E835E9399_2_14-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 14. What is your procedure for protecting small items from breakage or disappearance while in storage? | guid=3a13d49c-172d-7a93-f237-27bca045f797 | strategy=name
    public ILocator N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage => _page.Locator("[name=\"string_169_5\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 15. What measures does the insured take to protect customer’s property against theft? | guid=3a13d49c-172d-5a86-22bc-fc123e4fd7f1 | strategy=name
    public ILocator N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft => _page.Locator("[name=\"string_169_6\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 16. Does the risk use release forms? | guid=3a13d49c-172d-470d-43ff-7b8630dcb302 | strategy=id
    public ILocator N16DoesTheRiskUseReleaseForms => _page.Locator("[id=\"f_b9A3E482906284343AC03033C7B31809816B_2_16-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 1. What are the distances the shipments will travel and the time required to complete the shipment?	 | guid=3a13d49c-172d-266c-c049-4d300d5c0ca8 | strategy=name
    public ILocator N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment => _page.Locator("[name=\"string_92\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 2. Indicate the age, type of construction and protection class of the premises. | guid=3a13d49c-172d-dcdc-b73d-08fdc1990272 | strategy=name
    public ILocator N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises => _page.Locator("[name=\"string_169\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 2. What are the types and ages of the vehicles/trailers used to transport your commodities?	 | guid=3a13d49c-172d-f955-dfa1-6bddccbfd770 | strategy=name
    public ILocator N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities => _page.Locator("[name=\"string_92_1\"]");

    // Source modules: Risk Schedule|Risk Specific | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Risk Specific | 2nd Class Category | guid=3a13d49c-16f1-da45-34fb-6d3031e99ece | strategy=retained-semantic
    public ILocator N2ndClassCategory => _page.GetByRole(AriaRole.Textbox, new() { Name = "2nd Class Category", Exact = true });

    // Source modules: Risk Schedule|Risk Specific | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Risk Specific | 2nd Class Code* | guid=3a13d49c-16f1-0f41-6dd7-9eaa7b4c0572 | strategy=retained-semantic
    public ILocator N2ndClassCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "2nd Class Code*", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 3. Does the applicant haul for others? | guid=3a13d49c-172d-e8f6-4221-fdb4b0e672cb | strategy=id
    public ILocator N3DoesTheApplicantHaulForOthers => _page.Locator("[id=\"f_m18CC23D224C1479990CCE2D5EBA3ED3C90_2_3-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 3. What is the percentage of annual gross receipts derived from service or repair? | guid=3a13d49c-172d-b53e-b7a9-a1d9cce994eb | strategy=name
    public ILocator N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair => _page.Locator("[name=\"string_169_1\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 4. What method do you use for keeping records of property in your care and how often are the records updated? | guid=3a13d49c-172d-1348-af22-2b7d34809d12 | strategy=name
    public ILocator N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated => _page.Locator("[name=\"string_169_2\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 4. What protective devices are installed on each vehicle or trailer? | guid=3a13d49c-172d-ae4c-52fc-775b895a5e99 | strategy=name
    public ILocator N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer => _page.Locator("[name=\"string_92_2\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 5. Are recognized approved central station burglar alarms installed and maintained? | guid=3a13d49c-172d-b761-eb62-41d6ad6a0eed | strategy=id
    public ILocator N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained => _page.Locator("[id=\"f_b7A8649BA88594F07A2EED84065C05C7116B_2_5-inputEl\"]");

    // Source modules: Policy Covg - Signs | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Signs | 5% Deductible | guid=3a13d49c-172d-a9e1-f5d8-a7afb81be7f9 | strategy=id
    public ILocator N5Deductible => _page.Locator("[id=\"f_cAFD1AA97819C467694F348BB5BA65F85E47_3_6-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 5. Do any vehicles have special equipment mounted or attached? | guid=3a13d49c-172d-5671-2be1-11793094c984 | strategy=id
    public ILocator N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached => _page.Locator("[id=\"f_m8488653223CB4B4BA40DE31CDB6F800A90_2_5-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 6. Are all storage areas locked at all times when unoccupied? | guid=3a13d49c-172d-6e73-927a-7d808da0be79 | strategy=id
    public ILocator N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied => _page.Locator("[id=\"f_b1C15D4BB95924355B6C9DB3E4D486C7D16B_2_6-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 6. Does the applicant pull double or triple trailers? | guid=3a13d49c-172d-f38c-b306-385ab128a0ea | strategy=id
    public ILocator N6DoesTheApplicantPullDoubleOrTripleTrailers => _page.Locator("[id=\"f_m73855E80098B4D51BF013C509D9F26A390_2_6-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 7. Are there any hazardous or flammable materials used or stored on the premises? | guid=3a13d49c-172d-27f5-71f5-8be540073c35 | strategy=id
    public ILocator N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises => _page.Locator("[id=\"f_b31C4DC1E36A54CE78682FB544E3BA0AB16B_2_7-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 7. Does the applicant leave the truck windows, doors and compartments closed and locked when unattended? | guid=3a13d49c-172d-4562-d719-e9c6630c4d4b | strategy=id
    public ILocator N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended => _page.Locator("[id=\"f_mC7C58EF91D2B448AB0D44299B4464B9690_2_7-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 8. Do you provide scheduled maintenance for the vehicles and trailers you operate? | guid=3a13d49c-172d-07b6-af2e-f1087b9b725b | strategy=id
    public ILocator N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate => _page.Locator("[id=\"f_mFDAD2FC147D34702A28F7B4FB47773E190_2_8-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | 9. Are the employees that pack, load and unload trained in proper handling of the commodities? | guid=3a13d49c-172d-c7b4-878f-b103b7f494d4 | strategy=id
    public ILocator N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities => _page.Locator("[id=\"f_mBE856C8E1BC04AFE85652589CD82142890_2_9-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Bailees Customer | 9. Are the premises or any portion of the premises equipped with a sprinkler system? | guid=3a13d49c-172d-6557-79c2-f85986a3d861 | strategy=id
    public ILocator N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem => _page.Locator("[id=\"f_b8CF5D796EA6C4194B4DA603919413A5B16B_2_9-inputEl\"]");

    // Source modules:  | confidence=High score=125
    // v57 raw Tosca:  | NAICSCodeSearchValue | guid=3a13d49c-1688-049f-ce8b-08a997c2bd86 | strategy=retained-semantic
    public ILocator NAICSCodeSearchValue => _page.GetByRole(AriaRole.Textbox, new() { Name = "NAICSCodeSearchValue", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Name(s) or Description(s) and Date(s) of Designated Activities or Services | guid=3a13d49c-1697-066f-574e-de7302f2e151 | strategy=retained-semantic
    public ILocator NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices => _page.GetByRole(AriaRole.Textbox, new() { Name = "Name(s) or Description(s) and Date(s) of Designated Activities or Services", Exact = true });

    // Source modules: Endorsement - CM 66 01 Exclude Named Customer | confidence=High score=125
    // v57 raw Tosca: Endorsement - CM 66 01 Exclude Named Customer | Names | guid=3a13d49c-172d-8dcd-8ee4-c92a4935cdbe | strategy=id
    public ILocator Names => _page.Locator("[id=\"f_CCE14981F38894A679A407BA735B5959BD2_3_1-inputEl\"]");

    // Source modules: Underwriting Info | Loss Experience | confidence=Medium score=113
    public ILocator NoKnownLosses => _page.GetByRole(AriaRole.Checkbox, new() { Name = "No known losses", Exact = true });

    // Source modules: Policy Coverage|NonOwned | confidence=High score=124
    // v57 raw Tosca: Policy Coverage|NonOwned | Non Owned Auto | guid=3a13d49c-16f1-fa70-8991-c6b3a8a1e50e | strategy=fieldref
    public ILocator NonOwnedAuto => _page.Locator("[fieldref=\"LineCoveragesInput.NonOwnedAuto\"], [data-fieldref=\"LineCoveragesInput.NonOwnedAuto\"]");

    // Source modules: NotePad | confidence=High score=125
    public ILocator NotePadOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator Notepad => _page.GetByRole(AriaRole.Link, new() { Name = "Notepad", Exact = true });

    // Source modules: NotePad | confidence=High score=97
    public ILocator NotepadHeading => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Notepad Heading");

    // Source modules: [CG0435] Employee Benefits Liability | confidence=High score=125
    // v57 raw Tosca: [CG0435] Employee Benefits Liability | Number Of Employees | guid=3a13d49c-1700-5cce-1c89-3001a9fd8c79 | strategy=retained-semantic
    public ILocator NumberOfEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "Number Of Employees", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Number of Full-Time Employees* | guid=3a13d49c-1688-3e7d-2e8d-0b5793507ecd | strategy=retained-semantic
    public ILocator NumberOfFullTimeEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "Number of Full-Time Employees*", Exact = true });

    // Source modules:  | confidence=High score=125
    // v57 raw Tosca:  | Number of Part-Time Employees* | guid=3a13d49c-1688-cab5-95e0-d2ee49cd3ed6 | strategy=retained-semantic
    public ILocator NumberOfPartTimeEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "Number of Part-Time Employees*", Exact = true });

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Motor Truck Cargo | Number Of Vehicles | guid=3a13d49c-172d-bbe9-8f2d-06974f10c1f6 | strategy=id
    public ILocator NumberOfVehicles => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB40108C_3_5-inputEl\"]");

    // Source modules: GL Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: GL Navigation Links | OCP | guid=3a13d49c-16f1-5932-8c6a-a9e2e76e584f | strategy=role-link
    public ILocator OCP => _page.GetByRole(AriaRole.Link, new() { Name = "OCP", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator OK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | OK-Class Code | guid=3a13d49c-1688-e652-656d-021f0e53252a | strategy=role-link
    public ILocator OKClassCode => _page.GetByRole(AriaRole.Link, new() { Name = "OK-Class Code", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | OK-Details | guid=3a13d49c-1688-2b09-519f-ccb5634def98 | strategy=role-link
    public ILocator OKDetails => _page.GetByRole(AriaRole.Link, new() { Name = "OK-Details", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | OK (First) | guid=3a13d49c-1688-d811-02b4-e810a21a44a5 | strategy=role-link
    public ILocator OKFirst => _page.GetByRole(AriaRole.Link, new() { Name = "OK (First)", Exact = true });

    // Source modules:  | confidence=High score=95
    // Only used as a sync point to verify that the first OK has been clicked.
    // v57 raw Tosca:  | OK (Second) | guid=3a13d49c-1688-592f-72d6-87aa1cbcd31b | strategy=role-link
    public ILocator OKSecond => _page.GetByRole(AriaRole.Link, new() { Name = "OK (Second)", Exact = true });

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Physical Damage | OTC Causes of Loss* | guid=3a13d49c-16f1-d041-2e64-6710d8d0dbae | strategy=id
    public ILocator OTCCausesOfLoss => _page.Locator("[id=\"f_cBFB0A5467643454EAC6DC41BBBFF51C22337_2_1-inputEl\"]");

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=125
    // v57 raw Tosca: State Details|Hired Auto Physical Damage With Driver | OTC Deductible* | guid=3a13d49c-16f1-7518-a6fc-6ee2c7ed1b2e | strategy=retained-semantic
    public ILocator OTCDeductible62C21 => _page.GetByRole(AriaRole.Textbox, new() { Name = "OTC Deductible*", Exact = true });

    // Source modules: State Details|Drive Other Car | confidence=High score=125
    // v57 raw Tosca: State Details|Drive Other Car | OTC Deductible | guid=3a13d49c-16f1-0701-4d9c-2eb44c584f4c | strategy=retained-semantic
    public ILocator OTCDeductibleE0D59 => _page.GetByRole(AriaRole.Textbox, new() { Name = "OTC Deductible", Exact = true });

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=125
    // v57 raw Tosca: State Details|Hired Auto PD Without Driver | OTC Deductible* | guid=3a13d49c-16f1-cf3e-fa4d-95eed0a60cea | strategy=retained-semantic
    public ILocator OTCDeductibleEF1DE => _page.GetByRole(AriaRole.Textbox, new() { Name = "OTC Deductible*", Exact = true });

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=124
    // v57 raw Tosca: State Details|Hired Auto PD Without Driver | OTC If Any | guid=3a13d49c-16f1-8b90-c299-517d62e95dbb | strategy=fieldref
    public ILocator OTCIfAny4EFEE => _page.Locator("[fieldref=\"CovHiredAndBorrowedOTCInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedOTCInput.IfAny\"]");

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=124
    // v57 raw Tosca: State Details|Hired Auto Physical Damage With Driver | OTC If Any | guid=3a13d49c-16f1-30a6-0782-ce20a3e8b0bb | strategy=fieldref
    public ILocator OTCIfAny6A58B => _page.Locator("[fieldref=\"CovHiredAndBorrowedOTCWithDriverInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedOTCWithDriverInput.IfAny\"]");

    // Source modules: Property Add Class | confidence=High score=125
    // v57 raw Tosca: Property Add Class | Occupancy Type | guid=3a13d49c-1700-b284-d3b5-fcf5816c6265 | strategy=retained-semantic
    public ILocator OccupancyType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Occupancy Type", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    // v57 raw Tosca: Property - Main | % Occupied | guid=3a13d49c-1700-6687-4cc6-d08d72254eb1 | strategy=retained-semantic
    public ILocator Occupied => _page.GetByRole(AriaRole.Textbox, new() { Name = "% Occupied", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Occurence Limit | guid=3a13d49c-1700-6910-f085-905e20437cbe | strategy=retained-semantic
    public ILocator OccurenceLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-6910-f085-905e20437cbe");

    // Source modules: Policy Coverage|NonOwned | confidence=High score=124
    // v57 raw Tosca: Policy Coverage|NonOwned | # of Employees | guid=3a13d49c-16f1-9d10-54cc-64bf1df054f0 | strategy=fieldref
    public ILocator OfEmployees => _page.Locator("[fieldref=\"RiskNonOwnedAutoInput.NumberOfEmployeesEstimate\"], [data-fieldref=\"RiskNonOwnedAutoInput.NumberOfEmployeesEstimate\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | # of Full-Time Employees* | guid=3a13d49c-1700-6b9e-7a82-759a0390c142 | strategy=id
    public ILocator OfFullTimeEmployees => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-6b9e-7a82-759a0390c142");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | # of Part-Time Employees* | guid=3a13d49c-1700-d1b3-1a9a-5519e5296a7f | strategy=id
    public ILocator OfPartTimeEmployees => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-d1b3-1a9a-5519e5296a7f");

    // Source modules: Policy Coverage|NonOwned | confidence=High score=124
    // v57 raw Tosca: Policy Coverage|NonOwned | # of Partners | guid=3a13d49c-16f1-c75c-5279-06098ebb1ce7 | strategy=fieldref
    public ILocator OfPartners => _page.Locator("[fieldref=\"RiskNonOwnedAutoInput.NumberOfPartnersEstimate\"], [data-fieldref=\"RiskNonOwnedAutoInput.NumberOfPartnersEstimate\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | # of Seasonal/Temporary Employees* | guid=3a13d49c-1700-4cec-e5f0-b402c1b9fc50 | strategy=id
    public ILocator OfSeasonalTemporaryEmployees => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-4cec-e5f0-b402c1b9fc50");

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    // v57 raw Tosca: Endorsements|Partners, Officers And Others Exclusion | Officers* | guid=3a13d49c-172d-5603-bcaf-b8665d8019ff | strategy=retained-semantic
    public ILocator Officers => _page.GetByRole(AriaRole.Textbox, new() { Name = "Officers*", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    // v57 raw Tosca: Endorsements|Partners, Officers And Others Exclusion | Officers Position Held* | guid=3a13d49c-172d-bed2-d97b-b5b9d9065e3e | strategy=retained-semantic
    public ILocator OfficersPositionHeld => _page.GetByRole(AriaRole.Textbox, new() { Name = "Officers Position Held*", Exact = true });

    // Source modules:  | confidence=High score=97
    // v57 raw Tosca:  | Option A | guid=3a13d49c-16f1-b96f-0e01-6fcc648c2748 | strategy=id
    public ILocator OptionA => _page.Locator("[id=\"pageTop\"]");

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=124
    // v57 raw Tosca: Policy Coverage|Business Interruption | Option A CheckBox  | guid=3a13d49c-16f1-2d16-22b8-bff58f528d13 | strategy=fieldref
    public ILocator OptionACheckBox => _page.Locator("[fieldref=\"BusinessInterruptionEndorsementInput.OptionA\"], [data-fieldref=\"BusinessInterruptionEndorsementInput.OptionA\"]");

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    // v57 raw Tosca: Policy Coverage|Business Interruption | Option A Schedule Button | guid=3a13d49c-16f1-62d6-0cad-e304628fbf52 | strategy=role-link
    public ILocator OptionAScheduleButton => _page.GetByRole(AriaRole.Link, new() { Name = "Option A Schedule Button", Exact = true });

    // Source modules: Submission|Required and Optional Fields | confidence=High score=125
    public ILocator OrderAudit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Order Audit", Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Vehicle Information | Original Cost New* | guid=3a13d49c-16f1-cff8-026b-e85112f069cc | strategy=retained-semantic
    public ILocator OriginalCostNew => _page.GetByRole(AriaRole.Textbox, new() { Name = "Original Cost New*", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    public ILocator OtherInsuranceHistoryOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=95
    // v57 raw Tosca: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Others* | guid=3a13d49c-172d-c91e-4546-849c129e0af2 | strategy=retained-semantic
    public ILocator Others9E098 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Others*", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    // v57 raw Tosca: Endorsements|Partners, Officers And Others Exclusion | Others* | guid=3a13d49c-172d-2638-55ec-147912c4ce64 | strategy=retained-semantic
    public ILocator OthersB1A1B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Others*", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=95
    // v57 raw Tosca: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Partners* | guid=3a13d49c-172d-b389-5352-7e2b68206ad2 | strategy=retained-semantic
    public ILocator Partners => _page.GetByRole(AriaRole.Textbox, new() { Name = "Partners*", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=125
    public ILocator PartnersOfficersAndOthersExclusionOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Billing | confidence=High score=125
    public ILocator PayPlan => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pay Plan", Exact = true });

    // Source modules: State Details|Main | confidence=High score=95
    // v57 raw Tosca: State Details|Main | Pending Rate Change | guid=3a13d49c-171e-6779-7905-aa8f55a1200b | strategy=id
    public ILocator PendingRateChange => _page.Locator("[id=\"f_l43F2C8E3497A4C328FCF8D515AC746C31CB6_3_1-inputEl\"]");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Motor Truck Cargo | Per Vehicle Limit | guid=3a13d49c-172d-6f2d-aa79-397132cb6d86 | strategy=id
    public ILocator PerVehicleLimit => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB401083_3_5-inputEl\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Pers Adv Inj | guid=3a13d49c-1700-88fd-c07c-9f9ab9138604 | strategy=retained-semantic
    public ILocator PersAdvInj => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-88fd-c07c-9f9ab9138604");

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Computer Systems | Personal Portable Computers | guid=3a13d49c-172d-88f6-c3ff-87b6fe316d3a | strategy=id
    public ILocator PersonalPortableComputers => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8B_3_4-inputEl\"]");

    // Source modules: Property Add Class | confidence=High score=125
    // v57 raw Tosca: Property Add Class | Personal Property Limit | guid=3a13d49c-1700-3f43-c02c-0f852df14890 | strategy=retained-semantic
    public ILocator PersonalPropertyLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Personal Property Limit", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    // v57 raw Tosca: Property Add Class | Personal Property Rating Group | guid=3a13d49c-1700-4a75-dd40-096b2ca28879 | strategy=retained-semantic
    public ILocator PersonalPropertyRatingGroup => _page.GetByRole(AriaRole.Textbox, new() { Name = "Personal Property Rating Group", Exact = true });

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=125
    // v57 raw Tosca: Risk Schedule|Physical Damage | OK | guid=3a13d49c-16f1-99c8-2cbc-30f590ecf679 | strategy=role-link
    public ILocator PhysicalDamageOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    // v57 raw Tosca: Property - Main | Pier Or Wharf | guid=3a13d49c-1700-1bb3-3f20-449e5a06260e | strategy=retained-semantic
    public ILocator PierOrWharf => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pier Or Wharf", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    // v57 raw Tosca: Property - Main | Pier Or Wharf COL Options | guid=3a13d49c-1700-2ef8-c76d-12f64ea32890 | strategy=retained-semantic
    public ILocator PierOrWharfCOLOptions => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pier Or Wharf COL Options", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    // v57 raw Tosca: Property - Main | Pier Or Wharf Cause Of Loss | guid=3a13d49c-1700-0496-aef7-5c57fb3fb4c9 | strategy=retained-semantic
    public ILocator PierOrWharfCauseOfLoss => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pier Or Wharf Cause Of Loss", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    // v57 raw Tosca: Property - Main | Pier Or Wharf Construction | guid=3a13d49c-1700-d5cf-a838-60cc837565d2 | strategy=retained-semantic
    public ILocator PierOrWharfConstruction => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pier Or Wharf Construction", Exact = true });

    // Source modules: UW Questions - Umbrella | confidence=High score=125
    // v57 raw Tosca: UW Questions - Umbrella | Please provide website address(es).* | guid=3a13d49c-171e-caa5-1951-622a108abacb | strategy=retained-semantic
    public ILocator PleaseProvideWebsiteAddressEs => _page.GetByRole(AriaRole.Textbox, new() { Name = "Please provide website address(es).*", Exact = true });

    // Source modules: Policy Coverage|Limits | confidence=High score=127
    // v57 raw Tosca: Policy Coverage|Limits | Policy Covg | guid=3a13d49c-1688-842b-52b2-caa09c23c76c | strategy=id
    public ILocator PolicyCovg26786 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Policy Covg | guid=3a13d49c-1697-b82a-92a7-eac462054452 | strategy=role-link
    public ILocator PolicyCovg35BE4 => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });

    // Source modules: GL Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: GL Navigation Links | Policy Covg | guid=3a13d49c-16f1-d348-9240-320343a71810 | strategy=role-link
    public ILocator PolicyCovg50C98 => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=127
    // v57 raw Tosca: Policy Covg|GL | Policy Covg | guid=3a13d49c-1700-769e-b228-7a3436bb62eb | strategy=id
    public ILocator PolicyCovg6B651 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-769e-b228-7a3436bb62eb");

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Bailees Cutomers | OK | guid=3a13d49c-172d-6694-753f-9a8364691938 | strategy=role-link
    public ILocator PolicyCovgBaileesCutomersOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Bailees - Property Away from Your Premises | confidence=High score=125
    public ILocator PolicyCovgBaileesPropertyAwayFromYourPremisesOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Computer Systems | OK | guid=3a13d49c-172d-df73-af5f-ae86ef4a92e9 | strategy=role-link
    public ILocator PolicyCovgComputerSystemsOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator PolicyCovgContractorsEquipmentOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: CP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: CP Navigation Links | Policy Covg | guid=3a13d49c-1700-3a77-f7c0-e11f6c80e8bd | strategy=role-link
    public ILocator PolicyCovgD0419 => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });

    // Source modules: WC Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: WC Navigation Links | Policy Covg | guid=3a13d49c-1688-9088-80b1-0662289fc911 | strategy=role-link
    public ILocator PolicyCovgD3CEF => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: IM Navigation Links | Policy Covg | guid=3a13d49c-172d-a4c5-1221-65f506afd5b8 | strategy=role-link
    public ILocator PolicyCovgED95C => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-a4c5-1221-65f506afd5b8");

    // Source modules: Policy Covg - Main | confidence=High score=127
    // v57 raw Tosca: Policy Covg - Main | Policy Covg | guid=3a13d49c-172d-9338-df10-a309c3e3c058 | strategy=id
    public ILocator PolicyCovgF9E58 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-9338-df10-a309c3e3c058");

    // Source modules: Policy Covg | confidence=High score=127
    public ILocator PolicyCovgFF145 => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Covg");

    // Source modules: Policy Covg | confidence=High score=97
    // v57 raw Tosca: Policy Covg | Policy Covg Header | guid=3a13d49c-171e-8032-00c0-a48ae24a56e3 | strategy=id
    public ILocator PolicyCovgHeader => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Motor Truck Cargo | OK | guid=3a13d49c-172d-0821-3168-38d53401b265 | strategy=role-link
    public ILocator PolicyCovgMotorTruckCargoOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Signs | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Signs | OK | guid=3a13d49c-172d-4019-e116-f42c8b19f094 | strategy=role-link
    public ILocator PolicyCovgSignsOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: BAP Navigation Links | Policy Covgerage | guid=3a13d49c-1688-b2ff-9013-ebd489005c1c | strategy=role-link
    public ILocator PolicyCovgerage => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=125
    // v57 raw Tosca: GL OCP|Risk | Policy Holder Name | guid=3a13d49c-172d-e5a7-e1bb-ac8a998ba9d5 | strategy=id
    public ILocator PolicyHolderName => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA705C_3_1-inputEl\"]");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator PolicyInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Info", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=97
    public ILocator PolicyInfoHeader => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Info Header");

    // Source modules: Commercial Auto | confidence=High score=125
    // v57 raw Tosca: Commercial Auto | Policy Number | guid=3a13d49c-171e-17ac-180b-20fce969d8b7 | strategy=retained-semantic
    public ILocator PolicyNumber461C7 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-17ac-180b-20fce969d8b7");

    // Source modules: Businessowners | confidence=High score=125
    // v57 raw Tosca: Businessowners | Policy Number | guid=3a13d49c-1697-2795-c091-4c635a79407e | strategy=retained-semantic
    public ILocator PolicyNumber6566F => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-2795-c091-4c635a79407e");

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    // v57 raw Tosca: SFP - 10 Liability/Farm | Policy Number | guid=3a13d49c-171e-c529-0caa-b458855e0f7e | strategy=retained-semantic
    public ILocator PolicyNumber78B85 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator PolicyNumberBA28E => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    // Source modules: General Liability | confidence=High score=125
    // v57 raw Tosca: General Liability | Policy Number | guid=3a13d49c-171e-fc82-60c4-d439bf66538d | strategy=retained-semantic
    public ILocator PolicyNumberFDF5C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator PolicyType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Type", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | Power suppressor voltage regulator?* | guid=3a13d49c-172d-6d38-fcaa-73e9290c6df0 | strategy=id
    public ILocator PowerSuppressorVoltageRegulator => _page.Locator("[id=\"f_c7FA512A090F641B9A6BB95F4C656EE1840_2_21-inputEl\"]");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | PremOp Ded | guid=3a13d49c-1700-277f-f8c3-5a7e01456e49 | strategy=retained-semantic
    public ILocator PremOpDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-277f-f8c3-5a7e01456e49");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | PremOp PD Ded | guid=3a13d49c-1700-3255-282f-15a94c7a106d | strategy=retained-semantic
    public ILocator PremOpPDDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-3255-282f-15a94c7a106d");

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Risk - Accounts Receivable | Premises Type | guid=3a13d49c-172d-c149-8908-b1db7d6ef829 | strategy=id
    public ILocator PremisesType => _page.Locator("[id=\"f_c4FFD73A13C164B729C39A3F5C851102317_1_1-inputEl\"]");

    // Source modules: Pricing | confidence=High score=125
    public ILocator Premium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Premium");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator Pricing900C9 => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Pricing | guid=3a13d49c-1697-6a8e-e833-6ffadaca0923 | strategy=role-link
    public ILocator PricingB84E6 => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing", Exact = true });

    // Source modules: WC Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: WC Navigation Links | Pricing | guid=3a13d49c-1688-00ba-b8ff-a41264b22754 | strategy=role-link
    public ILocator PricingDCBD4 => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing", Exact = true });

    // Source modules: Pricing | confidence=High score=125
    // v57 raw Tosca: Pricing | Pricing Detail | guid=3a13d49c-1688-d866-74e5-e90ba21b4e16 | strategy=role-link
    public ILocator PricingDetail => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing Detail", Exact = true });

    // Source modules: Pricing | confidence=High score=125
    // v57 raw Tosca: Pricing | Pricing Detail - OK | guid=3a13d49c-1688-4d8c-4ed4-5ea76b6dcbff | strategy=role-link
    public ILocator PricingDetailOK => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing Detail - OK", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: BAP Navigation Links | Pricing | guid=3a13d49c-1688-3af1-9713-e95e1408efc5 | strategy=role-link
    public ILocator PricingF3185 => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing", Exact = true });

    // Source modules: Pricing | confidence=High score=97
    public ILocator PricingHeading => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Pricing Heading");

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    // v57 raw Tosca: State Details|Hired Auto Liability | Primary Liability If Any | guid=3a13d49c-16f1-64c5-c06a-088d41bc56b3 | strategy=fieldref
    public ILocator PrimaryLiabilityIfAny => _page.Locator("[fieldref=\"CovHiredAndBorrowedLiabilityInput.IfAny\"], [data-fieldref=\"CovHiredAndBorrowedLiabilityInput.IfAny\"]");

    // Source modules: Policy Covg | confidence=High score=125
    // v57 raw Tosca: Policy Covg | Primary Location State* | guid=3a13d49c-171e-d07c-ab8e-5a53d055fa78 | strategy=retained-semantic
    public ILocator PrimaryLocationState => _page.GetByRole(AriaRole.Textbox, new() { Name = "Primary Location State*", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=95
    // Not Displayed for WC
    public ILocator PrimaryRatingState => _page.GetByRole(AriaRole.Textbox, new() { Name = "PrimaryRatingState", Exact = true });

    // Source modules:  | confidence=High score=95
    // Required for Commit/ Submission
    public ILocator PriorAmericanNationalPolicy => _page.GetByRole(AriaRole.Textbox, new() { Name = "Prior American National Policy #*", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Prod BI Ded | guid=3a13d49c-1700-930b-1ff7-13efbf42ac65 | strategy=retained-semantic
    public ILocator ProdBIDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-930b-1ff7-13efbf42ac65");

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Prod PD Ded | guid=3a13d49c-1700-0ca0-26e9-1f003690dc99 | strategy=retained-semantic
    public ILocator ProdPDDed => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-0ca0-26e9-1f003690dc99");

    // Source modules: Risk Schedule|General Coverage | confidence=High score=125
    // v57 raw Tosca: Risk Schedule|General Coverage | Produce Carried | guid=3a13d49c-16f1-8c10-7c8d-d5c8369c7a65 | strategy=retained-semantic
    public ILocator ProduceCarried => _page.GetByRole(AriaRole.Textbox, new() { Name = "Produce Carried", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    // v57 raw Tosca: Policy Covg|GL | Products Agg Limit | guid=3a13d49c-1700-7641-373b-5b21ae14d400 | strategy=retained-semantic
    public ILocator ProductsAggLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-7641-373b-5b21ae14d400");

    // Source modules: Policy Covg | confidence=High score=95
    // v57 raw Tosca: Policy Covg | Products - Completed Operations Aggregate Limit | guid=3a13d49c-16f1-c6a4-dfdb-4511c0c82fae | strategy=retained-semantic
    public ILocator ProductsCompletedOperationsAggregateLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Products - Completed Operations Aggregate Limit", Exact = true });

    // Source modules: Products/Completed Ops | confidence=High score=97
    // v57 raw Tosca: Products/Completed Ops | Products/Completed Ops | guid=3a13d49c-1700-4382-09cd-df5a0449dae6 | strategy=id
    public ILocator ProductsCompletedOps => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Products/Completed Ops | confidence=Medium score=113
    // v57 raw Tosca: Products/Completed Ops | Products/Completed Ops Button | guid=3a13d49c-1700-6fbc-af57-3c16fcb6b90f | strategy=role-link
    public ILocator ProductsCompletedOpsButton => _page.GetByRole(AriaRole.Link, new() { Name = "Products/Completed Ops", Exact = true });

    // Source modules: Products/Completed Ops | confidence=High score=125
    public ILocator ProductsCompletedOpsOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: CP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: CP Navigation Links | Property | guid=3a13d49c-1700-de1a-c9c5-c9ee61754235 | strategy=role-link
    public ILocator Property => _page.GetByRole(AriaRole.Link, new() { Name = "Property", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator PropertyAddClassOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Bailees Cutomers | Property Away From Your Premises Schedule | guid=3a13d49c-172d-a219-5650-6b1b2b126374 | strategy=role-link
    public ILocator PropertyAwayFromYourPremisesSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "Property Away From Your Premises Schedule", Exact = true });

    // Source modules: Property Enter Building RCT | confidence=High score=125
    // v57 raw Tosca: Property Enter Building RCT | OK | guid=3a13d49c-1700-ff86-fd7c-7d7bc2442150 | strategy=role-link
    public ILocator PropertyEnterBuildingRCTOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Computer Systems | Property In Transit | guid=3a13d49c-172d-c089-8937-f3bb00ac1824 | strategy=id
    public ILocator PropertyInTransit6E905 => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F86_3_4-inputEl\"]");

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Bailees Cutomers | Property In Transit | guid=3a13d49c-172d-f110-9947-dc9165dea764 | strategy=id
    public ILocator PropertyInTransit710FF => _page.Locator("[id=\"f_cC7E46B39F45D4F2C904634B55848AF77F70_3_7-inputEl\"]");

    // Source modules: Property Add Class | confidence=High score=125
    // v57 raw Tosca: Property Add Class | Property of Others Limit | guid=3a13d49c-1700-f748-be0f-a6852e4186c6 | strategy=retained-semantic
    public ILocator PropertyOfOthersLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Property of Others Limit", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    // v57 raw Tosca: Property Add Class | Property of Others Rating Group | guid=3a13d49c-1700-702f-ab45-977a2cd5409c | strategy=retained-semantic
    public ILocator PropertyOfOthersRatingGroup => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-702f-ab45-977a2cd5409c");

    // Source modules: Property UW Questions | confidence=High score=127
    // v57 raw Tosca: Property UW Questions | Property UW Questions | guid=3a13d49c-1700-a9f2-577d-7ecf9e2365c2 | strategy=id
    public ILocator PropertyUWQuestions790F2 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: CP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: CP Navigation Links | Property UW Questions | guid=3a13d49c-1700-06ef-5135-8e369226f7c9 | strategy=role-link
    public ILocator PropertyUWQuestions8452C => _page.GetByRole(AriaRole.Link, new() { Name = "Property UW Questions", Exact = true });

    // Source modules: Building - Detail | confidence=High score=94
    // v57 raw Tosca: Building - Detail | Provide a List of Surrounding Exposure/Other Occupancies within 100 ft (Including North, East, South, and West) | guid=3a13d49c-1700-a26e-4974-2975fc82e735 | strategy=fieldref
    public ILocator ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest => _page.Locator("[fieldref=\"BuildingInput.SurroundingExposureOrOtherOccupancies\"], [data-fieldref=\"BuildingInput.SurroundingExposureOrOtherOccupancies\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | Provide information regarding antivirus methods and copyright protection of data and media | guid=3a13d49c-172d-3099-69a7-d504d3a7abb3 | strategy=name
    public ILocator ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia => _page.Locator("[name=\"string_2F_4\"]");

    // Source modules: CP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: CP Navigation Links | Rating Groups | guid=3a13d49c-1700-204d-e9a5-4666881a8e89 | strategy=role-link
    public ILocator RatingGroups46191 => _page.GetByRole(AriaRole.Link, new() { Name = "Rating Groups", Exact = true });

    // Source modules: Rating Groups | confidence=High score=127
    // v57 raw Tosca: Rating Groups | Rating Groups | guid=3a13d49c-1700-71b2-7fd2-4712716efa21 | strategy=id
    public ILocator RatingGroups46DD2 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Rental Owners Liability | guid=3a13d49c-1697-f99b-bc35-ce694290718a | strategy=role-link
    public ILocator RentalOwnersLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-f99b-bc35-ce694290718a");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Contractors Equipment | Rental Reimbursement | guid=3a13d49c-172d-342a-b4b5-f425f528d298 | strategy=id
    public ILocator RentalReimbursement => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FED_3_1-inputEl\"]");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Contractors Equipment | Rented Equipment Expense | guid=3a13d49c-172d-2ec5-2ec3-9d8fbe49068c | strategy=id
    public ILocator RentedEquipmentExpense => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FE5_3_1-inputEl\"]");

    // Source modules: Policy Covg | confidence=High score=95
    // Available when Umbrella Limit selected is in the "Over" category (e.g. Over 15M)
    // v57 raw Tosca: Policy Covg | Requested Umbrella Limit | guid=3a13d49c-16f1-0203-9b29-cc3042af7e61 | strategy=retained-semantic
    public ILocator RequestedUmbrellaLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Requested Umbrella Limit", Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The string result to verify
    public ILocator Result => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Result");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator ReturnToQuote => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Quote", Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: IM Navigation Links | Risk | guid=3a13d49c-172d-8589-6af2-d73a567730e4 | strategy=role-link
    public ILocator Risk5D6FA => _page.GetByRole(AriaRole.Link, new() { Name = "Risk", Exact = true });

    // Source modules: Risk - Main | confidence=High score=127
    // v57 raw Tosca: Risk - Main | Risk | guid=3a13d49c-172d-592f-3d78-9173a3b1cba0 | strategy=id
    public ILocator Risk873E7 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Risk - Accounts Receivable | OK | guid=3a13d49c-172d-87fd-649f-1d8b0fc57589 | strategy=role-link
    public ILocator RiskAccountsReceivableOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-87fd-649f-1d8b0fc57589");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | OK | guid=3a13d49c-172d-73c0-91ea-b7991fa97b13 | strategy=role-link
    public ILocator RiskBaileesCustomersOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-73c0-91ea-b7991fa97b13");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Risk - Computer Systems | OK | guid=3a13d49c-172d-ecfb-0d38-ef21709415e3 | strategy=role-link
    public ILocator RiskComputerSystemsOK => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-ecfb-0d38-ef21709415e3");

    // Source modules: Risk Aggregate | confidence=High score=127
    // v57 raw Tosca: Risk Aggregate | Risk | guid=3a13d49c-16f1-0359-c917-45aa997ca9d1 | strategy=id
    public ILocator RiskDDE70 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: GL OCP|Risk | confidence=High score=97
    // v57 raw Tosca: GL OCP|Risk | Risk Heading | guid=3a13d49c-172d-0026-f827-9a9bca8a4dc9 | strategy=id
    public ILocator RiskHeading => _page.Locator("[id=\"pageTop\"]");

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: BAP Navigation Links | Risk Schedule | guid=3a13d49c-1688-dde6-a119-3d64924efc87 | strategy=role-link
    public ILocator RiskSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "Risk Schedule", Exact = true });

    // Source modules: Risk - Signs | confidence=High score=125
    // v57 raw Tosca: Risk - Signs | OK | guid=3a13d49c-172d-c348-67b0-293804c33ad7 | strategy=role-link
    public ILocator RiskSignsOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Rating Groups | confidence=High score=95
    // v57 raw Tosca: Rating Groups | Risk Type | guid=3a13d49c-1700-2df8-54cb-2b15d40a83fb | strategy=retained-semantic
    public ILocator RiskType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Risk Type", Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    // v57 raw Tosca: Building - Detail | Roof Type* | guid=3a13d49c-1700-3740-9d04-3a1b7f86385c | strategy=id
    public ILocator RoofType => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0259_3_1-inputEl\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | SFP - 10 Liability/Farm | guid=3a13d49c-1697-6bf0-f011-0c6b89932520 | strategy=role-link
    public ILocator SFP10LiabilityFarm => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-6bf0-f011-0c6b89932520");

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=97
    // v57 raw Tosca: SFP - 10 Liability/Farm | SFP - 10 Liability/Farm Heading | guid=3a13d49c-171e-f29c-d696-02f1125ef458 | strategy=id
    public ILocator SFP10LiabilityFarmHeading => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: Insurance Designee | Save for Later | guid=3a13d49c-171e-cfec-8c22-a2e5f7a16ea9 | strategy=role-link
    public ILocator SaveForLater => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-cfec-8c22-a2e5f7a16ea9");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Contractors Equipment | Scheduled Coverage | guid=3a13d49c-172d-ea27-0346-b088229f63f7 | strategy=id
    public ILocator ScheduledCoverage => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E02211F0_3_1-inputEl\"]");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Risk - Computer Systems | Search Result | guid=3a13d49c-172d-64b2-5e0b-f700919e536b | strategy=id
    public ILocator SearchResult4E620 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-64b2-5e0b-f700919e536b");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Search Result | guid=3a13d49c-172d-993e-d4b4-b6589f8b3c4f | strategy=id
    public ILocator SearchResultA1BFB => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-993e-d4b4-b6589f8b3c4f");

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Risk - Accounts Receivable | Search Result | guid=3a13d49c-172d-357f-0e66-b5c4938eeda1 | strategy=id
    public ILocator SearchResultEAFB8 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-357f-0e66-b5c4938eeda1");

    // Source modules: CGL|Add Class | confidence=High score=125
    // v57 raw Tosca: CGL|Add Class | Search Results | guid=3a13d49c-1700-e29f-2482-3a15d45434a6 | strategy=retained-semantic
    public ILocator SearchResults5209C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Results", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    // v57 raw Tosca: Property Add Class | Search Results | guid=3a13d49c-1700-b131-1646-8c42d3f3f77c | strategy=retained-semantic
    public ILocator SearchResultsD0AA8 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Results", Exact = true });

    // Source modules:  | confidence=High score=125
    // v57 raw Tosca:  | SearchValue | guid=3a13d49c-1688-9e6e-3bd3-33b0fdcf5ebc | strategy=retained-semantic
    public ILocator SearchValue53135 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1688-9e6e-3bd3-33b0fdcf5ebc");

    // Source modules: Property Add Class | confidence=High score=125
    // v57 raw Tosca: Property Add Class | Search Value | guid=3a13d49c-1700-5207-7a4a-680d00e8429d | strategy=retained-semantic
    public ILocator SearchValue54F3C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Value", Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Risk - Accounts Receivable | Search Value | guid=3a13d49c-172d-5b3b-bf4a-564b4d225f8b | strategy=id
    public ILocator SearchValue79E46 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-5b3b-bf4a-564b4d225f8b");

    // Source modules: Risk - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Risk - Computer Systems | Search Value | guid=3a13d49c-172d-ee80-e28d-fc69f13515c2 | strategy=id
    public ILocator SearchValue9FCD1 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-ee80-e28d-fc69f13515c2");

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Search Value | guid=3a13d49c-172d-481d-8ffc-b47cce97273a | strategy=id
    public ILocator SearchValueCA6A6 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-481d-8ffc-b47cce97273a");

    // Source modules: Risk Schedule|General Coverage | confidence=High score=125
    // v57 raw Tosca: Risk Schedule|General Coverage | Seasonal Produce Trailers | guid=3a13d49c-16f1-dc86-fc36-bffb4f5de562 | strategy=retained-semantic
    public ILocator SeasonalProduceTrailers => _page.GetByRole(AriaRole.Textbox, new() { Name = "Seasonal Produce Trailers", Exact = true });

    // Source modules: Location | confidence=High score=127
    // v57 raw Tosca: Location | Select | guid=3a13d49c-1700-0efa-725a-5e2f92d6eda1 | strategy=id
    public ILocator Select => _page.Locator("[id=\"dctGridLink\"]");

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Select Appropriate Code | guid=3a13d49c-172d-99b3-87c9-6a19115c75af | strategy=id
    public ILocator SelectAppropriateCode => _page.Locator("[id=\"f_aCDFD57747BFF44D9A3DDB9378170002825_2_1-inputEl\"]");

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Select Class Code* | guid=3a13d49c-1688-ee7c-494d-66f828d971e2 | strategy=retained-semantic
    public ILocator SelectClassCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Select Class Code*", Exact = true });

    // Source modules: [CU0206] Utah Changes - Notice of Cancellation for Private Investigator Agencies | confidence=High score=125
    // v57 raw Tosca: [CU0206] Utah Changes - Notice of Cancellation for Private Investigator Agencies | Select Endorsement: | guid=3a13d49c-171e-64c8-8e1e-73d1b9dc3ba7 | strategy=retained-semantic
    public ILocator SelectEndorsement0EAB0 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Select Endorsement:", Exact = true });

    // Source modules: [UC1101] Exclusion for Designated Activities or Services | confidence=High score=125
    // v57 raw Tosca: [UC1101] Exclusion for Designated Activities or Services | Select Endorsement: | guid=3a13d49c-1697-6cf6-ac79-b7a9ababffdc | strategy=retained-semantic
    public ILocator SelectEndorsement63E0E => _page.GetByRole(AriaRole.Textbox, new() { Name = "Select Endorsement:", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Select NAICS Code | guid=3a13d49c-1688-7e28-46e0-3434505d7529 | strategy=role-link
    public ILocator SelectNAICSCode => _page.GetByRole(AriaRole.Link, new() { Name = "Select NAICS Code", Exact = true });

    // Source modules: Location | confidence=High score=125
    // v57 raw Tosca: Location | Select PPC | guid=3a13d49c-1700-4e4c-991d-c79bd1a11325 | strategy=role-link
    public ILocator SelectPPC => _page.GetByRole(AriaRole.Link, new() { Name = "Select PPC", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Sex | guid=3a13d49c-16f1-13cd-f65d-15d436d60cc0 | strategy=id
    public ILocator Sex => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D1_1_1-inputEl\"]");

    // Source modules: Risk Aggregate | confidence=High score=95
    // v57 raw Tosca: Risk Aggregate | Show All Locations | guid=3a13d49c-16f1-9551-b508-305c245eeabb | strategy=retained-semantic
    public ILocator ShowAllLocations => _page.GetByRole(AriaRole.Textbox, new() { Name = "Show All Locations", Exact = true });

    // Source modules: Risk - Signs | confidence=High score=125
    // v57 raw Tosca: Risk - Signs | Sign Location | guid=3a13d49c-172d-ea76-bbb4-37d4c972aa03 | strategy=id
    public ILocator SignLocation => _page.Locator("[id=\"f_r99A2986D696A457DA1C69BB16D902CEF17_1_1-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=97
    // v57 raw Tosca: Specific Underwriting Questions - Signs | Signs Heading | guid=3a13d49c-172d-79f5-7e0f-8e8527a110ff | strategy=id
    public ILocator SignsHeading => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: IM Navigation Links | Signs UW Questions | guid=3a13d49c-172d-96f6-ebbf-9c82a7fa3f45 | strategy=role-link
    public ILocator SignsUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Signs", Exact = true });

    // Source modules: State Details|Main | confidence=High score=95
    // v57 raw Tosca: State Details|Main | Small Deductible* | guid=3a13d49c-171e-cfd7-604e-9d0b0b56ccf0 | strategy=retained-semantic
    public ILocator SmallDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Small Deductible*", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=95
    // v57 raw Tosca: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Sole Proprietors* | guid=3a13d49c-172d-a7c0-3b80-171e9e3c4ef4 | strategy=retained-semantic
    public ILocator SoleProprietors => _page.GetByRole(AriaRole.Textbox, new() { Name = "Sole Proprietors*", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    public ILocator SoleProprietorsPartnersOfficersAndOthersCoverageOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: IM Navigation Links | Specific Underwriting Questions | guid=3a13d49c-172d-2f90-d3f1-8c0bf8c77afe | strategy=role-link
    public ILocator SpecificUnderwritingQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Specific Underwriting Questions", Exact = true });

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsAccountsReceivableOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsBaileesCustomerOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsComputerSystemsOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsContractorsEquipmentOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsMotorTruckCargoOwnersOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsSignsOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SplitBIDed => _page.GetByText("Split BI Ded", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SplitPDDed => _page.GetByText("Split PD Ded", new() { Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    // v57 raw Tosca: Building - Detail | Square Feet | guid=3a13d49c-1700-737f-8219-846f8397c4f2 | strategy=id
    public ILocator SquareFeet => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0245_3_1-inputEl\"]");

    // Source modules: GL OCP|Risk | confidence=High score=124
    // v57 raw Tosca: GL OCP|Risk | State | guid=3a1469a9-9241-8c9c-34b8-a9053469e707 | strategy=fieldref
    public ILocator State16B92 => _page.Locator("[fieldref=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderState\"], [data-fieldref=\"CovOwnersContractorsOrPrincipalsInput.PolicyHolderState\"]");

    // Source modules:  | confidence=High score=125
    // v57 raw Tosca:  | State | guid=3a13d49c-16f1-a9cf-5f65-a41c6e6cd080 | strategy=retained-semantic
    public ILocator State64A10 => _page.GetByRole(AriaRole.Textbox, new() { Name = "State", Exact = true });

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    // v57 raw Tosca: Endorsements|Designated Workplaces Exclusion | State* | guid=3a13d49c-172d-f6c0-2906-943f250c9499 | strategy=retained-semantic
    public ILocator State89468 => _page.GetByRole(AriaRole.Textbox, new() { Name = "State*", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: BAP Navigation Links | State Details | guid=3a13d49c-1688-87c9-4d4a-040e8e648d66 | strategy=role-link
    public ILocator StateDetails33183 => _page.GetByRole(AriaRole.Link, new() { Name = "State Details", Exact = true });

    // Source modules: State Details|UM/UIM | confidence=High score=127
    // v57 raw Tosca: State Details|UM/UIM | State Details | guid=3a13d49c-1688-168d-e091-59c7858ae88b | strategy=id
    public ILocator StateDetails72631 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: WC Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: WC Navigation Links | State Details | guid=3a13d49c-1688-5746-fc10-2cb9f6b31325 | strategy=role-link
    public ILocator StateDetailsB407B => _page.GetByRole(AriaRole.Link, new() { Name = "State Details", Exact = true });

    // Source modules: BAP Navigation Links | confidence=High score=127
    // v57 raw Tosca: BAP Navigation Links | State Details - Detail | guid=3a13d49c-1688-878b-6a82-2fdbeceb8776 | strategy=id
    public ILocator StateDetailsDetail => _page.Locator("[id=\"dctGridLink\"]");

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | State Licensed* | guid=3a13d49c-16f1-dc15-c3b8-5d8913fc845f | strategy=id
    public ILocator StateLicensed => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D5_1_1-inputEl\"]");

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    // v57 raw Tosca: [CG 29 35] Add'l Insured-State or Political (Permits) | State or Political Subdivision* | guid=3a13d49c-172d-60d8-28a6-725576c431b3 | strategy=retained-semantic
    public ILocator StateOrPoliticalSubdivision => _page.GetByRole(AriaRole.Textbox, new() { Name = "State or Political Subdivision*", Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Vehicle Information | Stated Amount* | guid=3a13d49c-16f1-0718-6240-fc2a1007610f | strategy=retained-semantic
    public ILocator StatedAmount => _page.GetByRole(AriaRole.Textbox, new() { Name = "Stated Amount*", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator StoplightMessageTotalSubjectPremium => _page.GetByText("Stoplight Message: Total Subject Premium", new() { Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    // v57 raw Tosca: Risk - Bailees Customers | Storage Limit | guid=3a13d49c-172d-6ff3-1096-6d0b238d86cc | strategy=id
    public ILocator StorageLimit => _page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF587517408A3_1_1-inputEl\"]");

    // Source modules: Building - Detail | confidence=High score=125
    // v57 raw Tosca: Building - Detail | Stories | guid=3a13d49c-1700-9e87-4500-5db8dea62e55 | strategy=id
    public ILocator Stories => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0247_3_1-inputEl\"]");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator Submission => _page.GetByRole(AriaRole.Link, new() { Name = "Submission", Exact = true });

    // Source modules: Submission|Required and Optional Fields | confidence=High score=127
    public ILocator SubmissionHeading => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Submission Heading");

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Physical Damage | Tapes Coverage | guid=3a13d49c-16f1-c6d0-e245-0f6c0e688f94 | strategy=id
    public ILocator TapesCoverage => _page.Locator("[id=\"f_cA3C9AC7006E9416C9517BA15BC2DCE5F2364_2_1-inputEl\"]");

    // Source modules: NotePad | confidence=High score=124
    public ILocator TextBox => _page.GetByRole(AriaRole.Textbox, new() { Name = "TextBox", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator ThirdPartyDesignee => _page.GetByRole(AriaRole.Link, new() { Name = "Third Party Designee", Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // Defines the caption of the browser window that is searched for.
    public ILocator Title => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Title");

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Contractors Equipment | Tools And Clothing Belonging To Your Employees | guid=3a13d49c-172d-51c0-3283-a67a614c164b | strategy=id
    public ILocator ToolsAndClothingBelongingToYourEmployees => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FEB_3_1-inputEl\"]");

    // Source modules: GL OCP|Risk | confidence=High score=125
    // v57 raw Tosca: GL OCP|Risk | Total Cost of Work* | guid=3a13d49c-172d-4cd9-92aa-874c5a37f995 | strategy=id
    public ILocator TotalCostOfWork => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA7041_3_1-inputEl\"]");

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Total Payroll (Estimated) | guid=3a13d49c-1688-77db-9cab-a8750240aa83 | strategy=retained-semantic
    public ILocator TotalPayrollEstimated => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Payroll (Estimated)", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator TotalPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Premium", Exact = true });

    // Source modules: General Liability | confidence=High score=125
    // v57 raw Tosca: General Liability | Total Subject Premium* | guid=3a13d49c-171e-4c02-a2bf-3de0a719b46f | strategy=retained-semantic
    public ILocator TotalSubjectPremium19B44 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Subject Premium*", Exact = true });

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    // v57 raw Tosca: SFP - 10 Liability/Farm | Total Subject Premium* | guid=3a13d49c-171e-7588-faf0-c13a01870fbd | strategy=retained-semantic
    public ILocator TotalSubjectPremiumAF452 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Subject Premium*", Exact = true });

    // Source modules: Businessowners | confidence=High score=125
    // v57 raw Tosca: Businessowners | Total Subject Premium* | guid=3a13d49c-1697-68c5-7803-bcdd157945fb | strategy=retained-semantic
    public ILocator TotalSubjectPremiumE8AF0 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-68c5-7803-bcdd157945fb");

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Physical Damage | Towing | guid=3a13d49c-16f1-448c-5b28-356b60db609f | strategy=retained-semantic
    public ILocator Towing => _page.GetByRole(AriaRole.Textbox, new() { Name = "Towing", Exact = true });

    // Source modules: Policy Coverage|Limits | confidence=High score=125
    // v57 raw Tosca: Policy Coverage|Limits | Trailer Interchange Collision Deductible | guid=3a13d49c-1688-8943-75d7-762717de6bdb | strategy=retained-semantic
    public ILocator TrailerInterchangeCollisionDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Trailer Interchange Collision Deductible", Exact = true });

    // Source modules: Policy Coverage|Limits | confidence=High score=125
    // v57 raw Tosca: Policy Coverage|Limits | Trailer Interchange Comp Deductible | guid=3a13d49c-1688-2b8d-ce0e-2ea1e8b1dc63 | strategy=retained-semantic
    public ILocator TrailerInterchangeCompDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Trailer Interchange Comp Deductible", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Trailer Interchange - Enter # Days Insured | guid=3a13d49c-16f1-7772-3e7c-de344c9612ed | strategy=retained-semantic
    public ILocator TrailerInterchangeEnterDaysInsured => _page.GetByRole(AriaRole.Textbox, new() { Name = "Trailer Interchange - Enter # Days Insured", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Trailer Interchange - Enter # of Trailers | guid=3a13d49c-16f1-165a-ad9d-5a4d8b96c4b1 | strategy=retained-semantic
    public ILocator TrailerInterchangeEnterOfTrailers => _page.GetByRole(AriaRole.Textbox, new() { Name = "Trailer Interchange - Enter # of Trailers", Exact = true });

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    // v57 raw Tosca: [FG 00 13] Automatic Additional Insured - Specific Relationship | Type | guid=3a14cfdc-11c4-e2bc-910e-0c0149aed216 | strategy=fieldref
    public ILocator Type56F72 => _page.Locator("[fieldref=\"AdditionalOtherInterestInput.Type\"], [data-fieldref=\"AdditionalOtherInterestInput.Type\"]");

    // Source modules: Endorsement - Main | confidence=High score=125
    // v57 raw Tosca: Endorsement - Main | Type | guid=3a13d49c-172d-a46b-e458-0b7e2783b7d5 | strategy=id
    public ILocator Type715D6 => _page.Locator("[id=\"f_c4CBF9D54B72F454488F8BD49B282C532C8_3_10-inputEl\"]");

    // Source modules: GL OCP|Risk | confidence=High score=124
    // v57 raw Tosca: GL OCP|Risk | Type | guid=3a14699b-eb1b-fd1d-2001-40a6eb91c19c | strategy=fieldref
    public ILocator Type885AA => _page.Locator("[fieldref=\"CovOwnersContractorsOrPrincipalsInput.Type\"], [data-fieldref=\"CovOwnersContractorsOrPrincipalsInput.Type\"]");

    // Source modules: [CG 20 20] Add'l Insured-Charitable Institution | confidence=High score=125
    // v57 raw Tosca: [CG 20 20] Add'l Insured-Charitable Institution | Type | guid=3a13d49c-1700-cb30-7c8a-706588387837 | strategy=retained-semantic
    public ILocator TypeA75B5 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    // Source modules: Risk - Signs | confidence=High score=125
    // v57 raw Tosca: Risk - Signs | Type | guid=3a13d49c-172d-17ec-4ca4-ea9b1c0e856a | strategy=id
    public ILocator TypeB082D => _page.Locator("[id=\"f_r99A2986D696A457DA1C69BB16D902CEF18_1_1-inputEl\"]");

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    // v57 raw Tosca: [CG 29 35] Add'l Insured-State or Political (Permits) | Type | guid=3a13d49c-172d-6483-4a69-be4a55575066 | strategy=retained-semantic
    public ILocator TypeCDE3B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    // Source modules: [CG 20 07] Add'l Insured-Engineers, Architects | confidence=High score=125
    // v57 raw Tosca: [CG 20 07] Add'l Insured-Engineers, Architects | Type | guid=3a13d49c-1700-7a5d-d6d2-2f86ab4d2ced | strategy=retained-semantic
    public ILocator TypeD0639 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator TypeD972C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Contractors Equipment | Type Of Contractor | guid=3a13d49c-172d-840b-91e9-d4ce1a7ac9d2 | strategy=id
    public ILocator TypeOfContractor => _page.Locator("[id=\"f_c48C85AB0259E43AE8BED26305EA4E022FCB_3_1-inputEl\"]");

    // Source modules: [CG 20 34] Add'l Insured-Leased Equipment Automatic  | confidence=High score=95
    // v57 raw Tosca: [CG 20 34] Add'l Insured-Leased Equipment Automatic | Type of Equipment | guid=3a13d49c-1700-f4d1-e2df-bbffb3cf4161 | strategy=retained-semantic
    public ILocator TypeOfEquipment => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type of Equipment", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Type of Interest | guid=3a13d49c-16f1-b902-6199-2d317db973ee | strategy=retained-semantic
    public ILocator TypeOfInterest => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type of Interest", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v57 raw Tosca: [CG 20 20] Add'l Insured-Charitable Institution | Type of License | guid=3a13d49c-1700-6d7b-d0fe-fc90e333db2a | strategy=fieldref
    public ILocator TypeOfLicense => _page.Locator("[fieldref=\"AdditionalOtherInterestInput.DescriptionOfCompletedOps\"], [data-fieldref=\"AdditionalOtherInterestInput.DescriptionOfCompletedOps\"]");

    // Source modules: State Details|UM/UIM | confidence=High score=95
    // v57 raw Tosca: State Details|UM/UIM | UMBI Limit* | guid=3a13d49c-1688-5a6c-b910-ac2b946fa01a | strategy=retained-semantic
    public ILocator UMBILimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "UMBI Limit*", Exact = true });

    // Source modules: State Details|UM/UIM | confidence=High score=95
    // v57 raw Tosca: State Details|UM/UIM | UM Type Default Selections | guid=3a13d49c-1688-bc50-df0f-98685f0f77c3 | strategy=retained-semantic
    public ILocator UMTypeDefaultSelections => _page.GetByRole(AriaRole.Textbox, new() { Name = "UM Type Default Selections", Exact = true });

    // Source modules: State Details|UM/UIM | confidence=High score=125
    // v57 raw Tosca: State Details|UM/UIM | OK | guid=3a13d49c-1688-8498-a77b-114b0be4889d | strategy=role-link
    public ILocator UMUIMOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: BAP Navigation Links | UW Questions | guid=3a13d49c-1688-fda9-f905-410b86994521 | strategy=role-link
    public ILocator UWQuestions368CC => _page.GetByRole(AriaRole.Link, new() { Name = "UW Questions", Exact = true });

    // Source modules: Underwriting Questions | confidence=High score=127
    // v57 raw Tosca: Underwriting Questions | UW Questions | guid=3a13d49c-16f1-b993-0865-6430b6a330d7 | strategy=id
    public ILocator UWQuestionsF3D9F => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | UW Questions - Umbrella | guid=3a13d49c-1697-6ed5-a2b5-ee62b240fa14 | strategy=role-link
    public ILocator UWQuestionsUmbrella9F47E => _page.GetByRole(AriaRole.Link, new() { Name = "UW Questions - Umbrella", Exact = true });

    // Source modules: UW Questions - Umbrella | confidence=High score=127
    // v57 raw Tosca: UW Questions - Umbrella | UW Questions - Umbrella | guid=3a13d49c-171e-8904-cc3e-7bf40a3279a2 | strategy=id
    public ILocator UWQuestionsUmbrellaFF014 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: WC Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: WC Navigation Links | UW Questions - Workers Comp | guid=3a13d49c-1688-cdfd-90c5-bfef8c4287af | strategy=role-link
    public ILocator UWQuestionsWorkersComp => _page.GetByRole(AriaRole.Link, new() { Name = "UW Questions - Workers Comp", Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    // v57 raw Tosca: Policy Covg | Umbrella Limit | guid=3a13d49c-16f1-b28b-364c-fb76b9911820 | strategy=retained-semantic
    public ILocator UmbrellaLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Umbrella Limit", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator UnderwritingInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | Uninterruptible power source?* | guid=3a13d49c-172d-be01-c82b-e5653c49f9d0 | strategy=id
    public ILocator UninterruptiblePowerSource => _page.Locator("[id=\"f_c7FA512A090F641B9A6BB95F4C656EE183E_2_21-inputEl\"]");

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Computer Systems | Unnamed Premises | guid=3a13d49c-172d-d67d-844e-acd9d68ff5be | strategy=id
    public ILocator UnnamedPremises => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8A_3_4-inputEl\"]");

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Motor Truck Cargo | Unnamed Terminals Limit | guid=3a13d49c-172d-9faf-d7ce-a085865c3f4c | strategy=id
    public ILocator UnnamedTerminalsLimit => _page.Locator("[id=\"f_cB85F41925276456C81E1ED1306A2AB401095_3_5-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Contractors Equipment | Update Answers | guid=3a13d49c-172d-a0a4-7d37-fbe634036887 | strategy=role-link
    public ILocator UpdateAnswers3DA0B => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-a0a4-7d37-fbe634036887");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | Update Answers | guid=3a13d49c-172d-8da9-dac9-5fcec2f5b438 | strategy=role-link
    public ILocator UpdateAnswers3DDA2 => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true });

    // Source modules: Products/Completed Ops | confidence=High score=125
    // v57 raw Tosca: Products/Completed Ops | Update Answers | guid=3a13d49c-1700-fd0c-e7ac-867d7fea2041 | strategy=role-link
    public ILocator UpdateAnswers69564 => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true });

    // Source modules: UW Questions - Workers Comp | confidence=High score=125
    // v57 raw Tosca: UW Questions - Workers Comp | Update Answers | guid=3a13d49c-171e-0165-a562-8e94ab6ba3ae | strategy=role-link
    public ILocator UpdateAnswers6FF76 => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true });

    // Source modules: Property UW Questions | confidence=High score=125
    // v57 raw Tosca: Property UW Questions | Update Answers | guid=3a13d49c-1700-22cc-e9ee-5fbbaef42d8c | strategy=role-link
    public ILocator UpdateAnswers99D68 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-22cc-e9ee-5fbbaef42d8c");

    // Source modules: Underwriting Info | General UW Questions | confidence=Medium score=113
    // v57 raw Tosca: Property UW Questions | Update Answers | guid=3a13d49c-1700-22cc-e9ee-5fbbaef42d8c | strategy=canonical-alias
    public ILocator UpdateAnswers9CB86 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-22cc-e9ee-5fbbaef42d8c");

    // Source modules: UW Questions - Umbrella | confidence=High score=125
    // v57 raw Tosca: UW Questions - Umbrella | Update Answers | guid=3a13d49c-171e-ea1f-2f3a-661c5d0ad7d0 | strategy=role-link
    public ILocator UpdateAnswersB41BE => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true });

    // Source modules: Underwriting Questions | confidence=High score=125
    // v57 raw Tosca: Underwriting Questions | Update Answers Button | guid=3a13d49c-16f1-b36e-ddbb-882175b2a4bd | strategy=role-link
    public ILocator UpdateAnswersButton => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers Button", Exact = true });

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Accounts Receivable | Update Answers | guid=3a13d49c-172d-3674-1ec4-3b352fb06eb3 | strategy=role-link
    public ILocator UpdateAnswersD8A16 => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true });

    // Source modules: General Liability Information | confidence=High score=125
    // v57 raw Tosca: General Liability Information | Update Answers | guid=3a13d49c-1700-298d-84cf-785521bf4213 | strategy=role-link
    public ILocator UpdateAnswersFB765 => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true });

    // Source modules: Risk Schedule|General Coverage | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|General Coverage | Used As Showroom | guid=3a13d49c-16f1-755b-cdc0-a5f2ab289420 | strategy=retained-semantic
    public ILocator UsedAsShowroom => _page.GetByRole(AriaRole.Textbox, new() { Name = "Used As Showroom", Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=125
    // v57 raw Tosca: Risk Schedule|Vehicle Information | VIN* | guid=3a13d49c-16f1-cf02-144b-1debe2d6fdc2 | strategy=retained-semantic
    public ILocator VIN => _page.GetByRole(AriaRole.Textbox, new() { Name = "VIN*", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    // v57 raw Tosca: Property - Main | Vacancy Permit | guid=3a13d49c-1700-5fa7-dad7-71db968b5dc5 | strategy=retained-semantic
    public ILocator VacancyPermit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Vacancy Permit", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    // v57 raw Tosca: Property - Main | Vacant Building | guid=3a13d49c-1700-f939-e7f0-29e5f38ca457 | strategy=retained-semantic
    public ILocator VacantBuilding => _page.GetByRole(AriaRole.Textbox, new() { Name = "Vacant Building", Exact = true });

    // Source modules: Rating Groups | confidence=High score=95
    // v57 raw Tosca: Rating Groups | Valuation | guid=3a13d49c-1700-98b2-f5ce-8a9fe43b83a9 | strategy=retained-semantic
    public ILocator Valuation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Valuation", Exact = true });

    // Source modules: Property Enter Building RCT | confidence=High score=125
    // v57 raw Tosca: Property Enter Building RCT | Valuation Type* | guid=3a13d49c-1700-562f-6c63-89d3ef2e944a | strategy=retained-semantic
    public ILocator ValuationType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Valuation Type*", Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=95
    // v57 raw Tosca: Risk Schedule|Vehicle Information | Value Basis | guid=3a13d49c-16f1-b41b-90d1-838cf9d7a46b | strategy=retained-semantic
    public ILocator ValueBasis => _page.GetByRole(AriaRole.Textbox, new() { Name = "Value Basis", Exact = true });

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=125
    // v57 raw Tosca: State Details|Hired Auto Physical Damage With Driver | Vehicle Information | guid=3a13d49c-16f1-bd72-3c3e-69c771649a4b | strategy=retained-semantic
    public ILocator VehicleInformation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Vehicle Information", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator VehicleSchedule1Veh => _page.GetByText("Veh #", new() { Exact = true });

    // Source modules: Risk Aggregate | confidence=High score=125
    // v57 raw Tosca: Risk Aggregate | Vehicle Type | guid=3a13d49c-16f1-3fce-82af-01fd189a7738 | strategy=retained-semantic
    public ILocator VehicleType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Vehicle Type", Exact = true });

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Computer Systems | Virus, Harmful Code Or Similar Instruction | guid=3a13d49c-172d-0a00-fb16-be76ebe3cd26 | strategy=id
    public ILocator VirusHarmfulCodeOrSimilarInstruction => _page.Locator("[id=\"f_c6288916FEC0548A5901DE1B09AA88FC2F8D_3_4-inputEl\"]");

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    // v57 raw Tosca: State Details|Hired Auto Liability | Volunteer Hired Autos CheckBox | guid=3a13d49c-16f1-8737-08d3-f5497fa6cb7d | strategy=fieldref
    public ILocator VolunteerHiredAutosCheckBox => _page.Locator("[fieldref=\"LineStateInput.VolunteerHiredAuto\"], [data-fieldref=\"LineStateInput.VolunteerHiredAuto\"]");

    // Source modules: WC Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: WC Navigation Links | WC Schedule | guid=3a13d49c-1688-4f41-dc55-4459c210d7d8 | strategy=role-link
    public ILocator WCSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "WC Schedule", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator WaitonPricingHeadingAndFillOutRequiredFields => _page.GetByText("Waiton Pricing Heading and Fill Out Required Fields", new() { Exact = true });

    // Source modules: State Details|Main | confidence=High score=95
    // v57 raw Tosca: State Details|Main | Waiver Of Subrogation | guid=3a13d49c-171e-3a7c-373d-a94b83458697 | strategy=retained-semantic
    public ILocator WaiverOfSubrogation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Waiver Of Subrogation", Exact = true });

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Waiver Of Subrogation Exposure* | guid=3a13d49c-1688-c013-658b-bdb91a436576 | strategy=retained-semantic
    public ILocator WaiverOfSubrogationExposure => _page.GetByRole(AriaRole.Textbox, new() { Name = "Waiver Of Subrogation Exposure*", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days => _page.GetByRole(AriaRole.Textbox, new() { Name = "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | What are the procedures and methods for keeping the EDP areas secured? | guid=3a13d49c-172d-23da-8ba0-b792af1828ad | strategy=name
    public ILocator WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured => _page.Locator("[name=\"string_2F_2\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | What are the procedures and schedule for backing up the media and data and their storage? | guid=3a13d49c-172d-0b7c-58d8-7f21dc914422 | strategy=name
    public ILocator WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage => _page.Locator("[name=\"string_2F_3\"]");

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=124
    // v57 raw Tosca: Specific Underwriting Questions - Signs | What is the construction of each sign? | guid=3a13d49c-172d-5362-b6c6-4e797e5a6048 | strategy=fieldref
    public ILocator WhatIsTheConstructionOfEachSign => _page.Locator("[fieldref=\"SignsUnderwritingQuestionsInput.Description\"], [data-fieldref=\"SignsUnderwritingQuestionsInput.Description\"]");

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=124
    // v57 raw Tosca: Specific Underwriting Questions - Accounts Receivable | What is the construction of the premises where the receivables are stored? | guid=3a13d49c-172d-36b0-2a6c-dc8c1cdb6dd4 | strategy=name
    public ILocator WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored => _page.Locator("[name=\"string_1F\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | What is the distance in feet to the nearest fire hydrant? | guid=3a13d49c-172d-30d8-9c1d-175159b8d2b6 | strategy=id
    public ILocator WhatIsTheDistanceInFeetToTheNearestFireHydrant => _page.Locator("[id=\"f_cD3F347C9072D47E4BDC9B2BEE6F633CD38_2_15-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | What is the distance in miles to the nearest responding fire department?* | guid=3a13d49c-172d-29b7-a657-862947b8525e | strategy=id
    public ILocator WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment => _page.Locator("[id=\"f_cD3F347C9072D47E4BDC9B2BEE6F633CD3B_2_15-inputEl\"]");

    // Source modules:  | confidence=High score=95
    // Required for Commit/ Submission
    public ILocator WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational => _page.GetByRole(AriaRole.Textbox, new() { Name = "What is the primary reason this new policy is being rewritten with Farm Family/American National?*", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | What is the procedure for transporting the computer equipment? | guid=3a13d49c-172d-3acf-fe15-30c2a5fa7ee3 | strategy=name
    public ILocator WhatIsTheProcedureForTransportingTheComputerEquipment => _page.Locator("[name=\"string_2F\"]");

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Computer Systems | What is the public protection class rating?* | guid=3a13d49c-172d-67ff-f31a-9b693a7e05ac | strategy=id
    public ILocator WhatIsThePublicProtectionClassRating => _page.Locator("[id=\"f_cD3F347C9072D47E4BDC9B2BEE6F633CD35_2_15-inputEl\"]");

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=124
    // v57 raw Tosca: Specific Underwriting Questions - Accounts Receivable | What safeguards are in place for receivables to protect against damage or theft? | guid=3a13d49c-172d-393b-c098-87dacc7106fa | strategy=name
    public ILocator WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft => _page.Locator("[name=\"string_1F_1\"]");

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    // v57 raw Tosca: Specific Underwriting Questions - Motor Truck Cargo(Owners) | Which form are you completing? | guid=3a13d49c-172d-4b66-03d7-f98a80965b11 | strategy=id
    public ILocator WhichFormAreYouCompleting => _page.Locator("[id=\"f_u90F32F80C0574D33AD962F038C8FC2AF56_2_1-inputEl\"]");

    // Source modules: [CG0424] Coverage for Injury to Leased Workers | confidence=High score=124
    // v57 raw Tosca: [CG0424] Coverage for Injury to Leased Workers | Why is this coverage desired? | guid=3a13d49c-172d-265a-2d86-57031cda71ac | strategy=retained-semantic
    public ILocator WhyIsThisCoverageDesired => _page.GetByRole(AriaRole.Textbox, new() { Name = "Why is this coverage desired?", Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=125
    // v57 raw Tosca: Risk Schedule|Vehicle Information | Year* | guid=3a13d49c-16f1-102a-bcf8-8a1f6215b357 | strategy=retained-semantic
    public ILocator Year => _page.GetByRole(AriaRole.Textbox, new() { Name = "Year*", Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    // v57 raw Tosca: Building - Detail | Year Built | guid=3a13d49c-1700-ceb5-336d-879caa50eead | strategy=id
    public ILocator YearBuilt => _page.Locator("[id=\"f_b5EB0BA20634D488B8A2DC0D7A686B5D0243_3_1-inputEl\"]");

    // Source modules:  | confidence=High score=95
    // v57 raw Tosca:  | Year Licensed | guid=3a13d49c-16f1-b6f9-6719-b6f66a1f895c | strategy=id
    public ILocator YearLicensed => _page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010D4_1_1-inputEl\"]");

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    // BAP, BOP, CPP, CP, IM, CR, SUMB ONLY (JULY-20)
    public ILocator YearsInBusiness => _page.GetByRole(AriaRole.Textbox, new() { Name = "Years In Business", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator ZipCodeB286B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code", Exact = true });

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    // v57 raw Tosca: Client|Third Party Designee|Common | Zip Code* | guid=3a13d49c-16f1-c18e-6828-6d24cbbd1250 | strategy=retained-semantic
    public ILocator ZipCodeBCEA0 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code*", Exact = true });

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    // v57 raw Tosca: [CG 29 35] Add'l Insured-State or Political (Permits) | Zip Code | guid=3a13d49c-172d-dce7-884a-8466d2a89d1a | strategy=retained-semantic
    public ILocator ZipCodeC048F => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code", Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=125
    // v57 raw Tosca: GL OCP|Risk | Zip Code | guid=3a13d49c-172d-24bc-2876-b971e6e4559e | strategy=id
    public ILocator ZipCodeC7591 => _page.Locator("[id=\"f_c630D2C33C75147EEB931C5458A61AA7062_3_1-inputEl\"]");

    // Source modules: Location | confidence=High score=125
    public ILocator ZipCodeD2DBA => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code", Exact = true });
    public ILocator EntityInfoFrameEntityInfoWindowFax => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Fax");    public ILocator EntityInfoFrameEntityInfoWindowBureauNumber => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Bureau Number");    public ILocator EntityInfoFrameEntityInfoWindowStateUnemploymentNumberDefault => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "State Unemployment Number Default");

}
