using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class NavigationLocators
{
    private readonly IPage _page;
    public NavigationLocators(IPage page) => _page = page;

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    public ILocator AVCostNew => _page.GetByRole(AriaRole.Textbox, new() { Name = "AV Cost New*", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator AWhatIsThePublicProtectionClassRating => _page.GetByRole(AriaRole.Textbox, new() { Name = "a. What is the public Protection class rating?", Exact = true });

    // Source modules: Risk Schedule|Liability, UM, Medical & PIP | confidence=High score=95
    public ILocator AcceptUM => _page.GetByLabel("Accept UM", new() { Exact = true });

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=97
    public ILocator AccountsReceivableHeading => _page.GetByLabel("Accounts Receivable Heading", new() { Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    public ILocator AccountsReceivableUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Accounts Receivable UW Questions", Exact = true });

    // Source modules: Risk - Main | confidence=High score=125
    public ILocator Add => _page.GetByRole(AriaRole.Button, new() { Name = "Add", Exact = true });

    // Source modules: Addl Interests|Main | confidence=High score=125
    public ILocator AddAddlInterest => _page.GetByRole(AriaRole.Button, new() { Name = "Add Addl Interest", Exact = true });

    // Source modules: Building - Main | confidence=High score=125
    public ILocator AddBuilding => _page.GetByRole(AriaRole.Button, new() { Name = "Add Building", Exact = true });

    // Source modules: CGL|Main Page | confidence=High score=125
    public ILocator AddClassB04B6 => _page.GetByRole(AriaRole.Button, new() { Name = "Add Class", Exact = true });

    // Source modules: WC Schedule|Main Page | confidence=High score=125
    public ILocator AddClassCode => _page.GetByRole(AriaRole.Button, new() { Name = "Add Class Code", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator AddClassDCD8F => _page.GetByRole(AriaRole.Button, new() { Name = "Add Class", Exact = true });

    // Source modules: CGL|Add Class | confidence=High score=125
    public ILocator AddClassOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Main | confidence=High score=125
    public ILocator AddCoverageForm => _page.GetByRole(AriaRole.Button, new() { Name = "Add Coverage Form", Exact = true });

    // Source modules: Driver Schedule | confidence=High score=125
    public ILocator AddDriver => _page.GetByRole(AriaRole.Button, new() { Name = "Add Driver", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator AddDriverName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Add Driver Name", Exact = true });

    // Source modules: [CU0206] Utah Changes - Notice of Cancellation for Private Investigator Agencies | confidence=High score=125
    public ILocator AddEndorsement04BD0 => _page.GetByRole(AriaRole.Button, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: BOP Expanded Endorsements|Add Endorsement | confidence=High score=125
    public ILocator AddEndorsement34EE3 => _page.GetByRole(AriaRole.Button, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    public ILocator AddEndorsement44E6A => _page.GetByRole(AriaRole.Button, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Endorsement - Main | confidence=High score=125
    public ILocator AddEndorsement48A9E => _page.GetByRole(AriaRole.Button, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    public ILocator AddEndorsement9E5F4 => _page.GetByRole(AriaRole.Button, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Endorsements|Main | confidence=High score=125
    public ILocator AddEndorsementA9973 => _page.GetByRole(AriaRole.Button, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Endorsements|Waiton Add Endorsement Button | confidence=High score=125
    public ILocator AddEndorsementB6452 => _page.GetByRole(AriaRole.Button, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=125
    public ILocator AddEndorsementCE8DD => _page.GetByRole(AriaRole.Button, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: [UC1101] Exclusion for Designated Activities or Services | confidence=High score=125
    public ILocator AddEndorsementD15B0 => _page.GetByRole(AriaRole.Button, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    public ILocator AddExcludedOfficerInformation => _page.GetByRole(AriaRole.Button, new() { Name = "Add Excluded Officer Information", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    public ILocator AddExcludedOthersInformation => _page.GetByRole(AriaRole.Button, new() { Name = "Add Excluded Others' Information", Exact = true });

    // Source modules: Rating Groups | confidence=High score=125
    public ILocator AddGroup => _page.GetByRole(AriaRole.Button, new() { Name = "Add Group", Exact = true });

    // Source modules: NotePad | confidence=High score=125
    public ILocator AddNotesRemarks => _page.GetByRole(AriaRole.Button, new() { Name = "Add Notes/Remarks", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator AddOptionA => _page.GetByRole(AriaRole.Button, new() { Name = "Add Option A", Exact = true });

    // Source modules: Additional Interests Schedule | confidence=High score=125
    public ILocator AddOtherInterest => _page.GetByRole(AriaRole.Button, new() { Name = "Add Other Interest", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=95
    public ILocator AddOthersInformation => _page.GetByRole(AriaRole.Button, new() { Name = "Add Others' Information", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    public ILocator AddPartnerInformation => _page.GetByRole(AriaRole.Button, new() { Name = "Add Partner Information", Exact = true });

    // Source modules: Policy Covg - Bailees - Property Away from Your Premises | confidence=High score=125
    public ILocator AddPremises => _page.GetByRole(AriaRole.Button, new() { Name = "Add Premises", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    public ILocator AddPriorCarrier => _page.GetByRole(AriaRole.Button, new() { Name = "Add Prior Carrier", Exact = true });

    // Source modules: Risk Aggregate | confidence=High score=125
    public ILocator AddRiskAtThisLocation => _page.GetByRole(AriaRole.Button, new() { Name = "Add Risk at This Location", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    public ILocator AddSoleProprietorInformation => _page.GetByRole(AriaRole.Button, new() { Name = "Add Sole Proprietor Information", Exact = true });

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    public ILocator AddThirdParty => _page.GetByRole(AriaRole.Button, new() { Name = "Add Third Party", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    public ILocator AdditionalInterests => _page.GetByRole(AriaRole.Link, new() { Name = "Additional Interests", Exact = true });

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    public ILocator AdditionalOtherInterestInputAddress1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "AdditionalOtherInterestInput.Address1", Exact = true });

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    public ILocator AdditionalOtherInterestInputFirstName => _page.GetByRole(AriaRole.Textbox, new() { Name = "AdditionalOtherInterestInput.FirstName", Exact = true });

    // Source modules: Client|Third Party Designee|Common | confidence=High score=95
    public ILocator AdditionalOtherInterestInputLastName => _page.GetByRole(AriaRole.Textbox, new() { Name = "AdditionalOtherInterestInput.LastName", Exact = true });

    // Source modules: Additional Interests Schedule | confidence=High score=127
    public ILocator AddlInterests15174 => _page.GetByLabel("Addl Interests", new() { Exact = true });

    // Source modules: Addl Interests|Main | confidence=High score=127
    public ILocator AddlInterestsA10A4 => _page.GetByLabel("Addl Interests", new() { Exact = true });

    // Source modules: GL Navigation Links | confidence=Medium score=113
    public ILocator AddlInterestsE39FC => _page.GetByRole(AriaRole.Link, new() { Name = "Addl Interests", Exact = true });

    // Source modules: Endorsement - CM 66 01 Exclude Named Customer | confidence=High score=125
    public ILocator Address => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator Address193FF8 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address 1*", Exact = true });

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    public ILocator Address19B8B5 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address 1", Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=125
    public ILocator Address1BE797 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address 1", Exact = true });

    // Source modules: Location | confidence=High score=125
    public ILocator Address1C0AF1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address1", Exact = true });

    // Source modules: Policy Covg - Bailees - Property Away from Your Premises | confidence=High score=125
    public ILocator AddressStreetCityStateZip => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address (Street, City, State, Zip)", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator AggregateLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Aggregate Limit", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator AnnualGrossReceipts => _page.GetByRole(AriaRole.Textbox, new() { Name = "Annual Gross Receipts", Exact = true });

    // Source modules: Underwriting Questions | confidence=High score=125
    public ILocator AnyPersonalAutoPolicyListingNameInsured => _page.GetByRole(AriaRole.Textbox, new() { Name = "AnyPersonalAutoPolicyListingNameInsured", Exact = true });

    // Source modules: Underwriting Questions | confidence=High score=125
    public ILocator AnyVehicleCoveredRegisteredInNotPrimaryState => _page.GetByRole(AriaRole.Textbox, new() { Name = "AnyVehicleCoveredRegisteredInNotPrimaryState", Exact = true });

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=125
    public ILocator AreAnySignsOffPremisesOrNotAttachedToBuilding => _page.GetByRole(AriaRole.Textbox, new() { Name = "Are Any signs off premises or not attached to building?", Exact = true });

    // Source modules: UW Questions - Workers Comp | confidence=High score=95
    public ILocator ArePhysicalsRequiredAfterOffersOfEmploymentAreMade => _page.GetByRole(AriaRole.Textbox, new() { Name = "Are physicals required after offers of employment are made?*", Exact = true });

    // Source modules: Underwriting Questions | confidence=High score=125
    public ILocator AreThereAnyCommercialVehiclesOwnedByTheApplicantNotInsuredOnThePolicy => _page.GetByRole(AriaRole.Textbox, new() { Name = "Are there any commercial vehicles owned by the applicant not insured on the policy?", Exact = true });

    // Source modules: Endorsements|Waiton Add Endorsement Button | confidence=High score=95
    public ILocator AreThereAnyOfficersThatShouldBeExcluded => _page.GetByRole(AriaRole.Textbox, new() { Name = "Are there any Officers that should be excluded?*", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator AssignLocation => _page.GetByRole(AriaRole.Button, new() { Name = "Assign Location", Exact = true });

    // Source modules: Entity Schedule|Location Assignment | confidence=High score=125
    public ILocator AssignLocations => _page.GetByRole(AriaRole.Button, new() { Name = "Assign Locations", Exact = true });

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    public ILocator AudioVisual => _page.GetByRole(AriaRole.Textbox, new() { Name = "Audio Visual", Exact = true });

    // Source modules: CPP|Pricing | confidence=High score=125
    public ILocator AvailableClassifications => _page.GetByRole(AriaRole.Textbox, new() { Name = "Available Classifications*", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator AverageNumberOfDaysService => _page.GetByRole(AriaRole.Textbox, new() { Name = "Average Number Of Days Service", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator AverageNumberOfWorkingDays => _page.GetByRole(AriaRole.Textbox, new() { Name = "Average Number Of Working Days", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator AverageServiceCharge => _page.GetByRole(AriaRole.Textbox, new() { Name = "Average Service Charge", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator AverageValuePerOrder => _page.GetByRole(AriaRole.Textbox, new() { Name = "Average Value Per Order", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator BAreThereAnyPrivateProtectionImprovements => _page.GetByRole(AriaRole.Textbox, new() { Name = "b. Are there any private protection improvements?", Exact = true });

    // Source modules: Building - Detail | confidence=High score=95
    public ILocator BG2Symbol => _page.GetByRole(AriaRole.Textbox, new() { Name = "BG2 Symbol", Exact = true });

    // Source modules: Building - Detail | confidence=High score=95
    public ILocator BG2SymbolPrefix => _page.GetByRole(AriaRole.Textbox, new() { Name = "BG2 Symbol Prefix", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=97
    public ILocator BaileesCustomerHeading => _page.GetByLabel("Bailees Customer Heading", new() { Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    public ILocator BaileesCustomerUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Bailees Customer UW Questions", Exact = true });

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
    public ILocator BodyStyle => _page.GetByRole(AriaRole.Textbox, new() { Name = "Body Style", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator BoomDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Boom Deductible", Exact = true });

    // Source modules: Underwriting Questions | confidence=High score=125
    public ILocator BorrowingHiringOrLeasingWithinYear => _page.GetByRole(AriaRole.Textbox, new() { Name = "BorrowingHiringOrLeasingWithinYear", Exact = true });

    // Source modules: Building - Main | confidence=High score=127
    public ILocator Building8205F => _page.GetByLabel("Building", new() { Exact = true });

    // Source modules: CP Navigation Links | confidence=Medium score=113
    public ILocator Building87910 => _page.GetByRole(AriaRole.Link, new() { Name = "Building", Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    public ILocator BuildingDetailOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator BuildingLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Building Limit", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator BuildingRatingGroup => _page.GetByRole(AriaRole.Textbox, new() { Name = "Building Rating Group", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator BusinessInterruptionDescriptionOfScheduledProperty => _page.GetByRole(AriaRole.Textbox, new() { Name = "Business Interruption Description Of ScheduledProperty", Exact = true });

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=97
    public ILocator BusinessInterruptionDetail => _page.GetByLabel("Business Interruption Detail", new() { Exact = true });

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    public ILocator BusinessInterruptionEndorsement => _page.GetByRole(AriaRole.Textbox, new() { Name = "Business Interruption Endorsement", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator BusinessInterruptionLimitOfInsurance => _page.GetByRole(AriaRole.Textbox, new() { Name = "Business Interruption Limit Of Insurance", Exact = true });

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    public ILocator BusinessInterruptionOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator CA2325LeasedWorkersCoverage => _page.GetByLabel("[CA2325] Leased Workers Coverage", new() { Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator CA9940ContractProvisions => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9940 - Contract Provisions", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator CA9940Make => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9940 - Make", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator CA9940Model => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9940 - Model", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator CA9940VIN => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA 9940 - VIN", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator CA9940Year => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9940 - Year", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator CA9948ClassesOfCommoditiesTransported => _page.GetByRole(AriaRole.Textbox, new() { Name = "CA9948 - Classes Of Commodities Transported", Exact = true });

    // Source modules: [CG0424] Coverage for Injury to Leased Workers | confidence=High score=125
    public ILocator CG0424CoverageForInjuryToLeasedWorkersOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: [CG0435] Employee Benefits Liability | confidence=High score=125
    public ILocator CG0435EmployeeBenefitsLiabilityOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: [CG 20 07] Add'l Insured-Engineers, Architects | confidence=High score=125
    public ILocator CG2007AddLInsuredEngineersArchitectsOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: [CG 20 20] Add'l Insured-Charitable Institution | confidence=High score=125
    public ILocator CG2020AddLInsuredCharitableInstitutionOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=125
    public ILocator CG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: [CG 2149] Total Pollution Exclusion Endorsement | confidence=High score=125
    public ILocator CG2149TotalPollutionExclusionEndorsementOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: [CG2401] Non-Binding Arbitration | confidence=High score=125
    public ILocator CG2401NonBindingArbitrationOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: [CG2812] Pesticide or Herbicide Applicator Coverage | confidence=High score=125
    public ILocator CG2812PesticideOrHerbicideApplicatorCoverageOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    public ILocator CG2935AddLInsuredStateOrPoliticalPermitsOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: GL Navigation Links | confidence=Medium score=113
    public ILocator CGL08901 => _page.GetByRole(AriaRole.Link, new() { Name = "CGL", Exact = true });

    // Source modules: CGL|Main Page | confidence=High score=127
    public ILocator CGLBA8E8 => _page.GetByLabel("CGL", new() { Exact = true });

    // Source modules: General Liability | confidence=High score=95
    public ILocator CGLLimits => _page.GetByRole(AriaRole.Textbox, new() { Name = "CGL Limits*", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator CPPLiability => _page.GetByRole(AriaRole.Link, new() { Name = "CPP Liability", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator CWhatIsTheDistanceInFeetToTheNearestHydrant => _page.GetByRole(AriaRole.Textbox, new() { Name = "c. What is the distance in feet to the nearest hydrant?", Exact = true });

    // Source modules: Location | confidence=High score=125
    public ILocator CallISO => _page.GetByRole(AriaRole.Button, new() { Name = "Call ISO", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator Carrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Carrier", Exact = true });

    // Source modules: Rating Groups | confidence=High score=95
    public ILocator CauseOfLoss => _page.GetByRole(AriaRole.Textbox, new() { Name = "Cause Of Loss", Exact = true });

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    public ILocator City => _page.GetByRole(AriaRole.Textbox, new() { Name = "City*", Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=124
    public ILocator ClassCode => _page.GetByRole(AriaRole.Combobox, new() { Name = "Class Code", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ClassCodeFrame => _page.GetByText("Class Code Frame", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ClassCodeFrameClassCodeWindow => _page.GetByText("Class Code Window", new() { Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator ClassificationOfRisk => _page.GetByRole(AriaRole.Textbox, new() { Name = "Classification of Risk %", Exact = true });

    // Source modules: BAP Endorsements | confidence=High score=125
    public ILocator ClickAddEndorsement => _page.GetByRole(AriaRole.Button, new() { Name = "Click Add Endorsement", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator ClickAddExcludedDriver => _page.GetByRole(AriaRole.Button, new() { Name = "Click Add Excluded Driver", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=127
    public ILocator Client070F4 => _page.GetByLabel("Client", new() { Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator Client35F85 => _page.GetByRole(AriaRole.Link, new() { Name = "Client", Exact = true });

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    public ILocator Coinsurance01AB1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coinsurance", Exact = true });

    // Source modules: Rating Groups | confidence=High score=125
    public ILocator Coinsurance6348B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coinsurance", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator CoinsuranceC9726 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coinsurance", Exact = true });

    // Source modules: State Details|Drive Other Car | confidence=High score=124
    public ILocator Collision => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Collision", Exact = true });

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=125
    public ILocator CollisionCoverage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Collision Coverage", Exact = true });

    // Source modules: State Details|Drive Other Car | confidence=High score=125
    public ILocator CollisionDeductible63D4C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Collision Deductible", Exact = true });

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=125
    public ILocator CollisionDeductible9C100 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Collision Deductible*", Exact = true });

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=125
    public ILocator CollisionDeductibleAEEBB => _page.GetByRole(AriaRole.Textbox, new() { Name = "Collision Deductible*", Exact = true });

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=124
    public ILocator CollisionIfAny7532D => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Collision If Any", Exact = true });

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=124
    public ILocator CollisionIfAny8AEE8 => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Collision If Any", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator CommercialAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Commercial Auto", Exact = true });

    // Source modules: Commercial Auto | confidence=High score=97
    public ILocator CommercialAutoDetail => _page.GetByLabel("Commercial Auto Detail", new() { Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=97
    public ILocator CommercialAutoRiskDetail => _page.GetByLabel("Commercial Auto Risk Detail", new() { Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator CommonNavigationLinksNext => _page.GetByRole(AriaRole.Link, new() { Name = "Next", Exact = true });

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    public ILocator CommonOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: State Details|Main | confidence=High score=95
    public ILocator CompanyName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Company Name*", Exact = true });

    // Source modules: State Details|Drive Other Car | confidence=High score=124
    public ILocator Comprehensive => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Comprehensive", Exact = true });

    // Source modules: Risk - Computer Systems | confidence=High score=125
    public ILocator ComputerEquipment => _page.GetByRole(AriaRole.Textbox, new() { Name = "Computer Equipment", Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    public ILocator ComputerSystemsUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Computer Systems UW Questions", Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    public ILocator Construction39800 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Construction", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator ConstructionCD2DE => _page.GetByRole(AriaRole.Textbox, new() { Name = "Construction", Exact = true });

    // Source modules: Risk - Computer Systems | confidence=High score=125
    public ILocator ConstructionCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Construction Code", Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator ConstructionFB8D9 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Construction", Exact = true });

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=97
    public ILocator ContractorsEquipmentHeading => _page.GetByLabel("Contractors Equipment Heading", new() { Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    public ILocator ContractorsEquipmentUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Contractors Equipment UW Questions", Exact = true });

    // Source modules: Risk Schedule|General Coverage | confidence=High score=95
    public ILocator CoverageBeginDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coverage begin date:", Exact = true });

    // Source modules: Risk Schedule|General Coverage | confidence=High score=125
    public ILocator CoverageEndDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coverage end date:", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=125
    public ILocator CoverageForm3B382 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coverage Form", Exact = true });

    // Source modules: Policy Covg - Signs | confidence=High score=125
    public ILocator CoverageFormA7F96 => _page.GetByLabel("Coverage Form", new() { Exact = true });

    // Source modules: Risk - Main | confidence=High score=125
    public ILocator CoverageFormCFDD1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coverage Form", Exact = true });

    // Source modules: Policy Covg - Computer Systems | confidence=High score=95
    public ILocator CoverageFormDisplay2ECD4 => _page.GetByLabel("Coverage Form Display", new() { Exact = true });

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=95
    public ILocator CoverageFormDisplay6F446 => _page.GetByLabel("Coverage Form Display", new() { Exact = true });

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=95
    public ILocator CoverageFormDisplayB69C2 => _page.GetByLabel("Coverage Form Display", new() { Exact = true });

    // Source modules: Policy Covg - Signs | confidence=High score=95
    public ILocator CoverageFormDisplayC10BA => _page.GetByLabel("Coverage Form Display", new() { Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=95
    public ILocator CoverageFormDisplayD1A9B => _page.GetByLabel("Coverage Form Display", new() { Exact = true });

    // Source modules: Policy Covg - Main | confidence=High score=125
    public ILocator CoverageFormToBeAdded => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coverage Form To Be Added", Exact = true });

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    public ILocator CoverageType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coverage Type", Exact = true });

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=124
    public ILocator CoveredPropertyConsistingPrincipallyOf => _page.GetByRole(AriaRole.Textbox, new() { Name = "Covered Property Consisting Principally of:", Exact = true });

    // Source modules: Property Enter Building RCT | confidence=High score=125
    public ILocator CreateValuation => _page.GetByRole(AriaRole.Button, new() { Name = "Create Valuation", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator DWhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment => _page.GetByRole(AriaRole.Textbox, new() { Name = "d. What is the distance in miles to the nearest responding fire department?", Exact = true });

    // Source modules: Risk - Computer Systems | confidence=High score=125
    public ILocator DataAndMedia => _page.GetByRole(AriaRole.Textbox, new() { Name = "Data And Media", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator DateOfBirth => _page.GetByRole(AriaRole.Textbox, new() { Name = "Date Of Birth", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator DateOfHire => _page.GetByRole(AriaRole.Textbox, new() { Name = "Date Of Hire", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    public ILocator DebrisRemovalAdditional => _page.GetByRole(AriaRole.Textbox, new() { Name = "Debris Removal Additional", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    public ILocator DebrisRemovalAdditionalLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Debris Removal Additional Limit", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator DedType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Ded Type", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    public ILocator DedicatedLine => _page.GetByRole(AriaRole.Textbox, new() { Name = "Dedicated line?*", Exact = true });

    // Source modules: Rating Groups | confidence=High score=125
    public ILocator Deductible01AB9 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible", Exact = true });

    // Source modules: Endorsement - IF 00 02 Waterborne Equipment | confidence=High score=125
    public ILocator Deductible0CC0A => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible", Exact = true });

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    public ILocator Deductible320C9 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator Deductible59155 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible", Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    public ILocator Deductible592D9 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible", Exact = true });

    // Source modules: State Details|Main | confidence=High score=125
    // IA Only
    public ILocator Deductible5F45D => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator DeductibleBasis => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible Basis", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator DeductibleC227C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible", Exact = true });

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    public ILocator DeductibleC91E9 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible", Exact = true });

    // Source modules: Building - Detail | confidence=High score=95
    public ILocator DeductibleIncreasedTheft99E5F => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible Increased Theft", Exact = true });

    // Source modules: Rating Groups | confidence=High score=95
    public ILocator DeductibleIncreasedTheftF76DB => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible Increased Theft", Exact = true });

    // Source modules: Building - Detail | confidence=High score=95
    public ILocator DeductibleWindHail911AF => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible Wind Hail", Exact = true });

    // Source modules: Rating Groups | confidence=High score=95
    public ILocator DeductibleWindHailAB1C3 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible Wind Hail", Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    public ILocator DefaultExpModType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Default Exp Mod Type", Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    public ILocator DefaultExperienceMod => _page.GetByRole(AriaRole.Textbox, new() { Name = "Default Experience Mod", Exact = true });

    // Source modules: General Liability Information | confidence=High score=124
    public ILocator DescribeAllHoldHarmlessAgreementsAndPleaseProvideACopy => _page.GetByRole(AriaRole.Textbox, new() { Name = "Describe all hold harmless agreements and please provide a copy.", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator Description03789 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description*", Exact = true });

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=125
    public ILocator Description43F2D => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description*", Exact = true });

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    public ILocator Description58EC2 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description*", Exact = true });

    // Source modules: Rating Groups | confidence=High score=125
    public ILocator Description8A08D => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description", Exact = true });

    // Source modules: Policy Covg - Signs | confidence=High score=125
    public ILocator DescriptionBE47E => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description*", Exact = true });

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    public ILocator DescriptionF8E60 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description*", Exact = true });

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    public ILocator DescriptionOfBusinessActivites => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description Of Business Activites*", Exact = true });

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=124
    public ILocator DescriptionOfOperationS => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Operation(s)", Exact = true });

    // Source modules: [CG2812] Pesticide or Herbicide Applicator Coverage | confidence=High score=124
    public ILocator DescriptionOfOperations => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Operations", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator DescriptionOfSpecifiedOperation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Specified Operation", Exact = true });

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    public ILocator DesignatedWorkplacesExclusionOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    public ILocator Detail0F8C6 => _page.GetByRole(AriaRole.Button, new() { Name = "Detail", Exact = true });

    // Source modules: Building - Main | confidence=High score=125
    public ILocator Detail10932 => _page.GetByRole(AriaRole.Button, new() { Name = "Detail", Exact = true });

    // Source modules: Risk Aggregate | confidence=High score=125
    public ILocator Detail1664B => _page.GetByRole(AriaRole.Button, new() { Name = "Detail", Exact = true });

    // Source modules: Entity Schedule|First Entity Info | confidence=High score=125
    public ILocator Detail238D5 => _page.GetByRole(AriaRole.Button, new() { Name = "Detail", Exact = true });

    // Source modules: Location | confidence=High score=125
    public ILocator Detail33F0D => _page.GetByRole(AriaRole.Button, new() { Name = "Detail", Exact = true });

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    public ILocator Detail4A746 => _page.GetByRole(AriaRole.Button, new() { Name = "Detail", Exact = true });

    // Source modules: Property Enter Building RCT | confidence=High score=125
    public ILocator Detail7F662 => _page.GetByRole(AriaRole.Button, new() { Name = "Detail", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator DoYouHaveACDLLicense => _page.GetByRole(AriaRole.Textbox, new() { Name = "Do you have a CDL license?*", Exact = true });

    // Source modules: Policy Covg | confidence=High score=125
    public ILocator DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup => _page.GetByRole(AriaRole.Textbox, new() { Name = "Does any Risk generate power other than Private Windmills or Emergency Backup?*", Exact = true });

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=125
    public ILocator DoesTheApplicantWishToCoverAnySignsInsideTheirPremises => _page.GetByRole(AriaRole.Textbox, new() { Name = "Does the applicant wish to cover any signs inside their premises?", Exact = true });

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    public ILocator DoesTheInsuredApplicantRequestAdditionalInsuredStatusWithoutAWrittenContractRequirement => _page.GetByRole(AriaRole.Combobox, new() { Name = "Does the insured/applicant request Additional Insured status without a written contract requirement?", Exact = true });

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    public ILocator DoesTheInsuredEnterIntoContractsInvolvingCommercialSnowRemovalIncludingSnowRemovalFromResidentialRoofs => _page.GetByRole(AriaRole.Combobox, new() { Name = "Does the insured enter into contracts involving Commercial Snow Removal, including snow removal from residential roofs?", Exact = true });

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    public ILocator DoesTheInsuredEverEnterIntoContractsForTasksNotContemplatedInTheCurrentLiabilityClassificationsOnThePolicy => _page.GetByRole(AriaRole.Combobox, new() { Name = "Does the insured ever enter into contracts for tasks not contemplated in the current liability classifications on the policy?", Exact = true });

    // Source modules: State Details|Drive Other Car | confidence=High score=124
    public ILocator DriveOtherCar => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Drive Other Car", Exact = true });

    // Source modules:  | confidence=High score=97
    public ILocator DriverDetail => _page.GetByLabel("Driver Detail", new() { Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    public ILocator DriverSchedule161DF => _page.GetByRole(AriaRole.Link, new() { Name = "Driver Schedule", Exact = true });

    // Source modules: Driver Schedule | confidence=High score=127
    public ILocator DriverSchedule79DC6 => _page.GetByLabel("Driver Schedule", new() { Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator DriversLicenseNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Drivers License Number", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator DryCleaning => _page.GetByRole(AriaRole.Textbox, new() { Name = "Dry Cleaning %", Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator DuplicatedRecords => _page.GetByRole(AriaRole.Textbox, new() { Name = "% Duplicated Records", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator EAreNoSmokingRulesPostedAndEnforced => _page.GetByRole(AriaRole.Textbox, new() { Name = "e. Are no smoking rules posted and enforced?", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator EMail => _page.GetByRole(AriaRole.Textbox, new() { Name = "E-Mail", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator Earthquake => _page.GetByRole(AriaRole.Textbox, new() { Name = "Earthquake", Exact = true });

    // Source modules: Billing | confidence=High score=125
    public ILocator EasyPay => _page.GetByRole(AriaRole.Textbox, new() { Name = "Easy Pay", Exact = true });

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    public ILocator EffectiveDate0E335 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Commercial Auto | confidence=High score=125
    public ILocator EffectiveDate68A1B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Businessowners | confidence=High score=125
    public ILocator EffectiveDate6CF3D => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator EffectiveDate95094 => _page.GetByRole(AriaRole.Textbox, new() { Name = "EffectiveDate", Exact = true });

    // Source modules: General Liability | confidence=High score=125
    public ILocator EffectiveDateB3600 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator EffectiveDateB557F => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Building - Detail | confidence=High score=95
    public ILocator EligibleForEnhancedWindRatingProgram => _page.GetByRole(AriaRole.Textbox, new() { Name = "Eligible For Enhanced Wind Rating Program", Exact = true });

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    public ILocator EmployeeHiredAutosCheckBox => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Employee Hired Autos CheckBox", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator EmployersLiab => _page.GetByRole(AriaRole.Link, new() { Name = "Employers Liab", Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    public ILocator Endorsement => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsement", Exact = true });

    // Source modules: Endorsement - CM 66 01 Exclude Named Customer | confidence=High score=125
    public ILocator EndorsementCM6601ExcludeNamedCustomerOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules:  | confidence=High score=97
    public ILocator EndorsementDetail => _page.GetByLabel("Endorsement Detail", new() { Exact = true });

    // Source modules: Endorsement - Main | confidence=High score=97
    public ILocator EndorsementHeading => _page.GetByLabel("Endorsement Heading", new() { Exact = true });

    // Source modules: Endorsement - IF 00 02 Waterborne Equipment | confidence=High score=125
    public ILocator EndorsementIF0002WaterborneEquipmentOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

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
    public ILocator EndorsementType3503E => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: BAP Endorsements | confidence=High score=125
    public ILocator EndorsementType624AD => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    public ILocator EndorsementType8DB33 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: [CG0435] Employee Benefits Liability | confidence=High score=125
    public ILocator EndorsementTypeA2928 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    public ILocator EndorsementTypeAEC4F => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=125
    public ILocator EndorsementTypeB210C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: [CG2812] Pesticide or Herbicide Applicator Coverage | confidence=High score=125
    public ILocator EndorsementTypeC75E4 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: [CG0424] Coverage for Injury to Leased Workers | confidence=High score=125
    public ILocator EndorsementTypeCE99F => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: [CG 2149] Total Pollution Exclusion Endorsement | confidence=High score=125
    public ILocator EndorsementTypeD83A4 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=125
    public ILocator EndorsementTypeF8D4A => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: GL Navigation Links | confidence=Medium score=113
    public ILocator Endorsements7572E => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsements", Exact = true });

    // Source modules: Endorsements|Main | confidence=High score=127
    public ILocator Endorsements9626E => _page.GetByLabel("Endorsements", new() { Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator Endorsements9D4A5 => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsements", Exact = true });

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator EndorsementsB76E9 => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsements", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    public ILocator EndorsementsC27F0 => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsements", Exact = true });

    // Source modules: Endorsements - Main Screen | confidence=High score=127
    public ILocator EndorsementsHeading8FD33 => _page.GetByLabel("Endorsements Heading", new() { Exact = true });

    // Source modules: BAP Endorsement Schedule | confidence=High score=127
    public ILocator EndorsementsHeadingA3D50 => _page.GetByLabel("Endorsements Heading", new() { Exact = true });

    // Source modules: Risk Schedule|General Coverage | confidence=High score=95
    // Only Applicable to Golf Carts
    public ILocator EngineSizeCc => _page.GetByRole(AriaRole.Textbox, new() { Name = "Engine Size (cc)*", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EntityInfoFrame => _page.GetByText("Entity Info Frame", new() { Exact = true });

    // Source modules: Entity Schedule|Main | confidence=High score=127
    public ILocator EntityScheduleE6C9F => _page.GetByLabel("Entity Schedule", new() { Exact = true });

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator EntityScheduleEA671 => _page.GetByRole(AriaRole.Link, new() { Name = "Entity Schedule", Exact = true });

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=125
    public ILocator EstimatedHighestValue => _page.GetByRole(AriaRole.Textbox, new() { Name = "Estimated Highest Value", Exact = true });

    // Source modules: Property Enter Building RCT | confidence=High score=125
    public ILocator EstimatorType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Estimator Type*", Exact = true });

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    public ILocator ExcessLiabilityIfAny => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Excess Liability If Any", Exact = true });

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=124
    public ILocator ExcludeCollapseHazard => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Exclude Collapse Hazard", Exact = true });

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=124
    public ILocator ExcludeExplosionHazard => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Exclude Explosion Hazard", Exact = true });

    // Source modules: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | confidence=High score=124
    public ILocator ExcludeUndergroundPropertyDamageHazard => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Exclude Underground Property Damage Hazard", Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    public ILocator ExcludedLiabilityConfidentialInformation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Excluded Liability - Confidential Information*", Exact = true });

    // Source modules: State Details|Experience Rated | confidence=High score=95
    public ILocator ExperienceModType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Experience Mod Type*", Exact = true });

    // Source modules: Policy Covg | confidence=High score=125
    public ILocator ExperienceRated => _page.GetByRole(AriaRole.Textbox, new() { Name = "Experience Rated", Exact = true });

    // Source modules: State Details|Experience Rated | confidence=High score=95
    public ILocator ExperienceRatingOptions => _page.GetByRole(AriaRole.Textbox, new() { Name = "Experience Rating Options", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator ExpirationDate34EAC => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    public ILocator ExpirationDate664A1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    // Source modules: Businessowners | confidence=High score=125
    public ILocator ExpirationDate82561 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    // Source modules: General Liability | confidence=High score=125
    public ILocator ExpirationDateB437C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    // Source modules: CGL|Main Page | confidence=High score=125
    public ILocator Exposure => _page.GetByRole(AriaRole.Textbox, new() { Name = "Exposure", Exact = true });

    // Source modules: Policy Coverage|NonOwned | confidence=High score=124
    public ILocator ExtendedEmployeeCoverage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Extended Employee Coverage", Exact = true });

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    public ILocator ExtraExpense => _page.GetByRole(AriaRole.Textbox, new() { Name = "Extra Expense", Exact = true });

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=125
    public ILocator FG0013AutomaticAdditionalInsuredSpecificRelationshipOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Location | confidence=High score=125
    public ILocator FeetFromHydrant => _page.GetByRole(AriaRole.Textbox, new() { Name = "Feet From Hydrant", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator FireDamage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Fire Damage", Exact = true });

    // Source modules: State Details|Drive Other Car | confidence=High score=125
    public ILocator FirstName5059E => _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator FirstName813D1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name*", Exact = true });

    // Source modules: Risk Schedule|Risk Specific | confidence=High score=95
    public ILocator GCW => _page.GetByRole(AriaRole.Textbox, new() { Name = "GCW*", Exact = true });

    // Source modules: Policy Info|CPP Specific Fields | confidence=High score=95
    // CPP Only
    public ILocator GLDetail => _page.GetByRole(AriaRole.Button, new() { Name = "GL Detail", Exact = true });

    // Source modules: GL Navigation Links | confidence=Medium score=113
    public ILocator GLUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "GL UW Questions", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator GeneralLiab => _page.GetByRole(AriaRole.Link, new() { Name = "General Liab", Exact = true });

    // Source modules: General Liability | confidence=High score=97
    public ILocator GeneralLiability => _page.GetByLabel("General Liability", new() { Exact = true });

    // Source modules: General Liability Information | confidence=High score=97
    public ILocator GeneralLiabilityInformation => _page.GetByLabel("General Liability Information", new() { Exact = true });

    // Source modules: General Liability Information | confidence=High score=125
    public ILocator GeneralLiabilityInformationOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Underwriting Info | General UW Questions | confidence=High score=127
    public ILocator GeneralUWQuestions => _page.GetByLabel("General UW Questions", new() { Exact = true });

    // Source modules: Property Enter Building RCT | confidence=High score=125
    public ILocator GetCalculatedValue => _page.GetByRole(AriaRole.Button, new() { Name = "Get Calculated Value", Exact = true });

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    public ILocator GroupClass => _page.GetByRole(AriaRole.Textbox, new() { Name = "Group Class", Exact = true });

    // Source modules: Underwriting Questions | confidence=High score=125
    public ILocator HasAnyApplicantBeenConvictedOfAFelonyOrBeenInvolvedInAnyIncidentsOrClaimsRelatingToSexualAbuseOrMolestationAllegationsDiscriminationArsonFraudBriberyOrNegligentHiring => _page.GetByRole(AriaRole.Textbox, new() { Name = "Has any applicant been convicted of a felony or been involved in any incidents or claims relating to sexual abuse or molestation allegations, discrimination, arson, fraud, bribery or negligent hiring", Exact = true });

    // Source modules: UW Questions - Umbrella | confidence=High score=95
    public ILocator HaveYouHadAnyLiabilityLossesInTheLast5YearsOnAnyPrimaryOrExcessPolicy => _page.GetByRole(AriaRole.Textbox, new() { Name = "Have you had any liability losses in the last 5 years on any primary or excess policy?*", Exact = true });

    // Source modules: Client|Third Party Designee|Common | confidence=High score=97
    public ILocator HeadingThirdPartyDesignee => _page.GetByLabel("Heading Third Party Designee", new() { Exact = true });

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=95
    public ILocator HiredAutoCA2001Address1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "HiredAuto CA2001 Address1", Exact = true });

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=95
    public ILocator HiredAutoCA2001FirstName => _page.GetByRole(AriaRole.Textbox, new() { Name = "HiredAuto CA2001 First Name", Exact = true });

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=95
    public ILocator HiredAutoCA2001LastName => _page.GetByRole(AriaRole.Textbox, new() { Name = "HiredAuto CA2001 Last Name", Exact = true });

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=95
    public ILocator HiredAutoCA2001ZipCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "HiredAuto CA2001 ZipCode", Exact = true });

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=125
    public ILocator HiredAutoExtAddlInsured => _page.GetByRole(AriaRole.Textbox, new() { Name = "Hired Auto Ext Addl Insured", Exact = true });

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=125
    public ILocator HiredAutoForm => _page.GetByRole(AriaRole.Textbox, new() { Name = "Hired Auto Form*", Exact = true });

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    public ILocator HiredAutoLiability => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Hired Auto Liability", Exact = true });

    // Source modules: Risk Schedule|Hired Auto | confidence=High score=125
    public ILocator HiredAutoOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=124
    public ILocator HiredAutoPhysicalDamageWithDriver => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Hired Auto Physical Damage With Driver", Exact = true });

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=124
    public ILocator HiredAutoPhysicalDamageWithoutDriver => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Hired Auto Physical Damage Without Driver", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator HiredEquipment => _page.GetByRole(AriaRole.Textbox, new() { Name = "Hired Equipment", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    public ILocator HowOftenIsDataBackedUp => _page.GetByRole(AriaRole.Textbox, new() { Name = "How often is data backed up?", Exact = true });

    // Source modules: Policy Coverage|Business Interruption|Option A Schedule | confidence=Review score=97
    public ILocator IFRAME280B0 => _page.GetByLabel("IFRAME", new() { Exact = true });

    // Source modules: Additional Interests Schedule | confidence=Review score=97
    public ILocator IFRAME59D4B => _page.GetByLabel("IFRAME", new() { Exact = true });

    // Source modules: Driver Detail | confidence=Review score=97
    public ILocator IFRAME6D695 => _page.GetByLabel("IFRAME", new() { Exact = true });

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
    public ILocator IFRAMEF0A48 => _page.GetByLabel("IFRAME", new() { Exact = true });

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=124
    public ILocator IfYesDescribe => _page.GetByRole(AriaRole.Textbox, new() { Name = "If Yes, describe", Exact = true });

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    public ILocator IfYesExplain => _page.GetByRole(AriaRole.Textbox, new() { Name = "If yes, explain.", Exact = true });

    // Source modules: Commercial Auto | confidence=High score=95
    public ILocator ImportPolicyDataButton89922 => _page.GetByRole(AriaRole.Button, new() { Name = "Import Policy Data Button", Exact = true });

    // Source modules: Businessowners | confidence=High score=95
    public ILocator ImportPolicyDataButtonEF44C => _page.GetByRole(AriaRole.Button, new() { Name = "Import Policy Data Button", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    public ILocator IncreasedPollutantCleanup => _page.GetByRole(AriaRole.Textbox, new() { Name = "Increased Pollutant Cleanup", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    public ILocator IndicateTheBuildingSAgeTypeOfConstructionAndProtectionClassAndOtherTenantsInTheBuildingSWhereTheComputerEquipmentIsLocated => _page.GetByRole(AriaRole.Textbox, new() { Name = "Indicate the building(s) age, type of construction, and protection class, and other tenants in the building(s) where the computer equipment is located", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator InsuranceHistory => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance History", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator InsuredType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Insured Type", Exact = true });

    // Source modules: Building - Detail | confidence=High score=95
    public ILocator Interest => _page.GetByRole(AriaRole.Textbox, new() { Name = "Interest", Exact = true });

    // Source modules: State Details|Main | confidence=High score=95
    public ILocator IntrastateRiskID => _page.GetByRole(AriaRole.Textbox, new() { Name = "Intrastate Risk ID", Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    public ILocator IsTheBuildingCooled => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is the building cooled?*", Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    public ILocator IsTheBuildingHeatedWithASolidFuelHeatingDevice => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is the building heated with a Solid Fuel Heating Device?*", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=125
    public ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is the Insured engaged in any Snow or Ice Removal Operations?*", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator IsThereAPriorCarrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is there a Prior Carrier?*", Exact = true });

    // Source modules: Submission|Required and Optional Fields | confidence=Medium score=113
    public ILocator IsThisCoverageBound => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is this coverage bound?*", Exact = true });

    // Source modules:  | confidence=High score=95
    // Required for Commit/ Submission when Policy Number is blank.
    public ILocator IsThisPolicyBeingFullyCancelled => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is this policy being fully cancelled?*", Exact = true });

    // Source modules: Risk Schedule|Risk Specific | confidence=High score=125
    // Only applicable to trucks
    public ILocator IsThisVehicleUsedInSnowPlowOperations => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is This Vehicle Used In Snow Plow Operations?*", Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The JavaScript code to execute. Use a return statement in the code to specify the return value.
    public ILocator JavaScript => _page.GetByLabel("JavaScript", new() { Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator LastName34FF6 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name*", Exact = true });

    // Source modules: State Details|Drive Other Car | confidence=High score=125
    public ILocator LastName5E149 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator Laundry => _page.GetByRole(AriaRole.Textbox, new() { Name = "Laundry %", Exact = true });

    // Source modules: Risk - Signs | confidence=High score=125
    public ILocator Lettering => _page.GetByRole(AriaRole.Textbox, new() { Name = "Lettering", Exact = true });

    // Source modules: Commercial Auto | confidence=High score=125
    public ILocator LiabilityLimit1AE2B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Liability Limit*", Exact = true });

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    public ILocator LiabilityLimit56E57 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Liability Limit*", Exact = true });

    // Source modules: Policy Covg - Bailees - Property Away from Your Premises | confidence=High score=125
    public ILocator Limit46632 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Limit", Exact = true });

    // Source modules: Endorsement - IF 00 02 Waterborne Equipment | confidence=High score=125
    public ILocator Limit887C5 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Limit", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator LimitE32DC => _page.GetByRole(AriaRole.Textbox, new() { Name = "Limit", Exact = true });

    // Source modules: Risk - Signs | confidence=High score=125
    public ILocator LimitOfInsurance => _page.GetByRole(AriaRole.Textbox, new() { Name = "Limit of Insurance", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    public ILocator LineConditioner => _page.GetByRole(AriaRole.Textbox, new() { Name = "Line conditioner?*", Exact = true });

    // Source modules: UW Questions - Workers Comp | confidence=High score=124
    public ILocator ListAllPoliciesWithAmericanNational => _page.GetByRole(AriaRole.Textbox, new() { Name = "List all policies with American National", Exact = true });

    // Source modules: Indicators and Errors | confidence=High score=127
    // This DIV appears during a refresh of the screen (working in the background) and can be used as a WaitOn for stability.
    public ILocator LoadingMessage => _page.GetByLabel("Loading Message", new() { Exact = true });

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    public ILocator LoanLeaseGap => _page.GetByRole(AriaRole.Textbox, new() { Name = "Loan/Lease Gap", Exact = true });

    // Source modules: Location | confidence=High score=127
    public ILocator Location82D95 => _page.GetByLabel("Location", new() { Exact = true });

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator Location8DEE2 => _page.GetByRole(AriaRole.Link, new() { Name = "Location", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    public ILocator LocationA1D91 => _page.GetByRole(AriaRole.Link, new() { Name = "Location", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LocationAssignment => _page.GetByText("Location Assignment", new() { Exact = true });

    // Source modules: CP Navigation Links | confidence=Medium score=113
    public ILocator LocationB7B1D => _page.GetByRole(AriaRole.Link, new() { Name = "Location", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator LocationE16BC => _page.GetByRole(AriaRole.Link, new() { Name = "Location", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator LocationID => _page.GetByRole(AriaRole.Textbox, new() { Name = "LocationID", Exact = true });

    // Source modules: Location | confidence=High score=125
    public ILocator LocationOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=125
    public ILocator LocationOfCoveredOperations => _page.GetByRole(AriaRole.Textbox, new() { Name = "Location Of Covered Operations", Exact = true });

    // Source modules: Underwriting Info | Loss Experience | confidence=Medium score=113
    public ILocator LossExperience => _page.GetByRole(AriaRole.Link, new() { Name = "Loss Experience", Exact = true });

    // Source modules: Underwriting Info | Loss Experience | confidence=High score=97
    public ILocator LossExperienceHeading => _page.GetByLabel("Loss Experience Heading", new() { Exact = true });

    // Source modules: CGL|Main Page | confidence=High score=125
    public ILocator MainPageOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=125
    public ILocator Make => _page.GetByRole(AriaRole.Textbox, new() { Name = "Make*", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator MaritalStatus => _page.GetByRole(AriaRole.Textbox, new() { Name = "Marital Status", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator Medical => _page.GetByRole(AriaRole.Textbox, new() { Name = "Medical", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator MeritRating => _page.GetByText("Merit Rating", new() { Exact = true });

    // Source modules: Location | confidence=High score=125
    public ILocator MilesFromFireDepartment => _page.GetByRole(AriaRole.Textbox, new() { Name = "Miles From Fire Department", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator MiscItemsBlanketCoverage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Misc Items Blanket Coverage", Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=125
    public ILocator Model => _page.GetByRole(AriaRole.Textbox, new() { Name = "Model*", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator ModificationFactor => _page.GetByRole(AriaRole.Textbox, new() { Name = "ModificationFactor", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=97
    public ILocator MotorTruckCargoHeading => _page.GetByLabel("Motor Truck Cargo Heading", new() { Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    public ILocator MotorTruckCargoUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Motor Truck Cargo UW Questions", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator MotorcycleLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Motorcycle Liability", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator N10AreThePremisesEquippedWithARecognizedApprovedCentralStationFireAlarmFireExtinguishersOrSmokeAlarms => _page.GetByRole(AriaRole.Textbox, new() { Name = "10. Are the premises equipped with a recognized approved central station fire alarm, fire extinguishers or smoke alarms?", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    public ILocator N10HowAreTheGoodsBeingTransportedProtectedFromDamageAndTheft => _page.GetByRole(AriaRole.Textbox, new() { Name = "10. How are the goods being transported protected from damage and theft?", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    public ILocator N11AreDriversMVRsAndTripLogsMaintained => _page.GetByRole(AriaRole.Textbox, new() { Name = "11. Are drivers’ MVRs and trip logs maintained?", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    public ILocator N11WhatIsTheProcedureForTransportingPropertyIncludeTheTransitMethodsUsedAndTheProtectionClassProvidedWhileInTransit => _page.GetByRole(AriaRole.Textbox, new() { Name = "11. What is the procedure for transporting property? Include the transit methods used and the protection class provided while in transit.", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator N12AreDriversMVRsReviewedOnARegularBasisAndMaintained => _page.GetByRole(AriaRole.Textbox, new() { Name = "12. Are drivers’ MVRs reviewed on a regular basis and maintained?", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    public ILocator N12HowOftenAreTheseLogsReviewedOrUpdated => _page.GetByRole(AriaRole.Textbox, new() { Name = "12. How often are these logs reviewed or updated?", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    public ILocator N13LiveAnimalInTransitCoverage => _page.GetByRole(AriaRole.Textbox, new() { Name = "13. Live animal in transit coverage?", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    public ILocator N13WhatTypesOfVehiclesDoYouOperateAndWhatProtectiveDevicesAreOnEachVehicle => _page.GetByRole(AriaRole.Textbox, new() { Name = "13. What types of vehicles do you operate and what protective devices are on each vehicle?", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    public ILocator N14LegalLiabilityCoverage => _page.GetByRole(AriaRole.Textbox, new() { Name = "14. Legal Liability coverage?", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    public ILocator N14WhatIsYourProcedureForProtectingSmallItemsFromBreakageOrDisappearanceWhileInStorage => _page.GetByRole(AriaRole.Textbox, new() { Name = "14. What is your procedure for protecting small items from breakage or disappearance while in storage?", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    public ILocator N15WhatMeasuresDoesTheInsuredTakeToProtectCustomerSPropertyAgainstTheft => _page.GetByRole(AriaRole.Textbox, new() { Name = "15. What measures does the insured take to protect customer’s property against theft?", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator N16DoesTheRiskUseReleaseForms => _page.GetByRole(AriaRole.Textbox, new() { Name = "16. Does the risk use release forms?", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    public ILocator N1WhatAreTheDistancesTheShipmentsWillTravelAndTheTimeRequiredToCompleteTheShipment => _page.GetByRole(AriaRole.Textbox, new() { Name = "1. What are the distances the shipments will travel and the time required to complete the shipment?", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    public ILocator N2IndicateTheAgeTypeOfConstructionAndProtectionClassOfThePremises => _page.GetByRole(AriaRole.Textbox, new() { Name = "2. Indicate the age, type of construction and protection class of the premises.", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    public ILocator N2WhatAreTheTypesAndAgesOfTheVehiclesTrailersUsedToTransportYourCommodities => _page.GetByRole(AriaRole.Textbox, new() { Name = "2. What are the types and ages of the vehicles/trailers used to transport your commodities?", Exact = true });

    // Source modules: Risk Schedule|Risk Specific | confidence=High score=95
    public ILocator N2ndClassCategory => _page.GetByRole(AriaRole.Textbox, new() { Name = "2nd Class Category", Exact = true });

    // Source modules: Risk Schedule|Risk Specific | confidence=High score=95
    public ILocator N2ndClassCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "2nd Class Code*", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    public ILocator N3DoesTheApplicantHaulForOthers => _page.GetByRole(AriaRole.Textbox, new() { Name = "3. Does the applicant haul for others?", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    public ILocator N3WhatIsThePercentageOfAnnualGrossReceiptsDerivedFromServiceOrRepair => _page.GetByRole(AriaRole.Textbox, new() { Name = "3. What is the percentage of annual gross receipts derived from service or repair?", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=Medium score=113
    public ILocator N4WhatMethodDoYouUseForKeepingRecordsOfPropertyInYourCareAndHowOftenAreTheRecordsUpdated => _page.GetByRole(AriaRole.Textbox, new() { Name = "4. What method do you use for keeping records of property in your care and how often are the records updated?", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=Medium score=113
    public ILocator N4WhatProtectiveDevicesAreInstalledOnEachVehicleOrTrailer => _page.GetByRole(AriaRole.Textbox, new() { Name = "4. What protective devices are installed on each vehicle or trailer?", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator N5AreRecognizedApprovedCentralStationBurglarAlarmsInstalledAndMaintained => _page.GetByRole(AriaRole.Textbox, new() { Name = "5. Are recognized approved central station burglar alarms installed and maintained?", Exact = true });

    // Source modules: Policy Covg - Signs | confidence=High score=125
    public ILocator N5Deductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "5% Deductible", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    public ILocator N5DoAnyVehiclesHaveSpecialEquipmentMountedOrAttached => _page.GetByRole(AriaRole.Textbox, new() { Name = "5. Do any vehicles have special equipment mounted or attached?", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator N6AreAllStorageAreasLockedAtAllTimesWhenUnoccupied => _page.GetByRole(AriaRole.Textbox, new() { Name = "6. Are all storage areas locked at all times when unoccupied?", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    public ILocator N6DoesTheApplicantPullDoubleOrTripleTrailers => _page.GetByRole(AriaRole.Textbox, new() { Name = "6. Does the applicant pull double or triple trailers?", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator N7AreThereAnyHazardousOrFlammableMaterialsUsedOrStoredOnThePremises => _page.GetByRole(AriaRole.Textbox, new() { Name = "7. Are there any hazardous or flammable materials used or stored on the premises?", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    public ILocator N7DoesTheApplicantLeaveTheTruckWindowsDoorsAndCompartmentsClosedAndLockedWhenUnattended => _page.GetByRole(AriaRole.Textbox, new() { Name = "7. Does the applicant leave the truck windows, doors and compartments closed and locked when unattended?", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    public ILocator N8DoYouProvideScheduledMaintenanceForTheVehiclesAndTrailersYouOperate => _page.GetByRole(AriaRole.Textbox, new() { Name = "8. Do you provide scheduled maintenance for the vehicles and trailers you operate?", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    public ILocator N9AreTheEmployeesThatPackLoadAndUnloadTrainedInProperHandlingOfTheCommodities => _page.GetByRole(AriaRole.Textbox, new() { Name = "9. Are the employees that pack, load and unload trained in proper handling of the commodities?", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator N9AreThePremisesOrAnyPortionOfThePremisesEquippedWithASprinklerSystem => _page.GetByRole(AriaRole.Textbox, new() { Name = "9. Are the premises or any portion of the premises equipped with a sprinkler system?", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator NAICSCodeSearchValue => _page.GetByRole(AriaRole.Textbox, new() { Name = "NAICSCodeSearchValue", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator NameSOrDescriptionSAndDateSOfDesignatedActivitiesOrServices => _page.GetByRole(AriaRole.Textbox, new() { Name = "Name(s) or Description(s) and Date(s) of Designated Activities or Services", Exact = true });

    // Source modules: Endorsement - CM 66 01 Exclude Named Customer | confidence=High score=125
    public ILocator Names => _page.GetByRole(AriaRole.Textbox, new() { Name = "Names", Exact = true });

    // Source modules: Underwriting Info | Loss Experience | confidence=Medium score=113
    public ILocator NoKnownLosses => _page.GetByRole(AriaRole.Checkbox, new() { Name = "No known losses", Exact = true });

    // Source modules: Policy Coverage|NonOwned | confidence=High score=124
    public ILocator NonOwnedAuto => _page.GetByRole(AriaRole.Textbox, new() { Name = "Non Owned Auto", Exact = true });

    // Source modules: NotePad | confidence=High score=125
    public ILocator NotePadOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator Notepad => _page.GetByRole(AriaRole.Link, new() { Name = "Notepad", Exact = true });

    // Source modules: NotePad | confidence=High score=97
    public ILocator NotepadHeading => _page.GetByLabel("Notepad Heading", new() { Exact = true });

    // Source modules: [CG0435] Employee Benefits Liability | confidence=High score=125
    public ILocator NumberOfEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "Number Of Employees", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator NumberOfFullTimeEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "Number of Full-Time Employees*", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator NumberOfPartTimeEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "Number of Part-Time Employees*", Exact = true });

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    public ILocator NumberOfVehicles => _page.GetByRole(AriaRole.Textbox, new() { Name = "Number Of Vehicles", Exact = true });

    // Source modules: GL Navigation Links | confidence=Medium score=113
    public ILocator OCP => _page.GetByRole(AriaRole.Link, new() { Name = "OCP", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator OK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator OKClassCode => _page.GetByRole(AriaRole.Button, new() { Name = "OK-Class Code", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator OKDetails => _page.GetByRole(AriaRole.Button, new() { Name = "OK-Details", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator OKFirst => _page.GetByRole(AriaRole.Button, new() { Name = "OK (First)", Exact = true });

    // Source modules:  | confidence=High score=95
    // Only used as a sync point to verify that the first OK has been clicked.
    public ILocator OKSecond => _page.GetByRole(AriaRole.Button, new() { Name = "OK (Second)", Exact = true });

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    public ILocator OTCCausesOfLoss => _page.GetByRole(AriaRole.Textbox, new() { Name = "OTC Causes of Loss*", Exact = true });

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=125
    public ILocator OTCDeductible62C21 => _page.GetByRole(AriaRole.Textbox, new() { Name = "OTC Deductible*", Exact = true });

    // Source modules: State Details|Drive Other Car | confidence=High score=125
    public ILocator OTCDeductibleE0D59 => _page.GetByRole(AriaRole.Textbox, new() { Name = "OTC Deductible", Exact = true });

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=125
    public ILocator OTCDeductibleEF1DE => _page.GetByRole(AriaRole.Textbox, new() { Name = "OTC Deductible*", Exact = true });

    // Source modules: State Details|Hired Auto PD Without Driver | confidence=High score=124
    public ILocator OTCIfAny4EFEE => _page.GetByRole(AriaRole.Checkbox, new() { Name = "OTC If Any", Exact = true });

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=124
    public ILocator OTCIfAny6A58B => _page.GetByRole(AriaRole.Checkbox, new() { Name = "OTC If Any", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator OccupancyType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Occupancy Type", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    public ILocator Occupied => _page.GetByRole(AriaRole.Textbox, new() { Name = "% Occupied", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator OccurenceLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Occurence Limit", Exact = true });

    // Source modules: Policy Coverage|NonOwned | confidence=High score=124
    public ILocator OfEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "# of Employees", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator OfFullTimeEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "# of Full-Time Employees*", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator OfPartTimeEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "# of Part-Time Employees*", Exact = true });

    // Source modules: Policy Coverage|NonOwned | confidence=High score=124
    public ILocator OfPartners => _page.GetByRole(AriaRole.Textbox, new() { Name = "# of Partners", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator OfSeasonalTemporaryEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "# of Seasonal/Temporary Employees*", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    public ILocator Officers => _page.GetByRole(AriaRole.Textbox, new() { Name = "Officers*", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    public ILocator OfficersPositionHeld => _page.GetByRole(AriaRole.Textbox, new() { Name = "Officers Position Held*", Exact = true });

    // Source modules:  | confidence=High score=97
    public ILocator OptionA => _page.GetByLabel("Option A", new() { Exact = true });

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=124
    public ILocator OptionACheckBox => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Option A CheckBox", Exact = true });

    // Source modules: Policy Coverage|Business Interruption | confidence=High score=125
    public ILocator OptionAScheduleButton => _page.GetByRole(AriaRole.Button, new() { Name = "Option A Schedule Button", Exact = true });

    // Source modules: Submission|Required and Optional Fields | confidence=High score=125
    public ILocator OrderAudit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Order Audit", Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=95
    public ILocator OriginalCostNew => _page.GetByRole(AriaRole.Textbox, new() { Name = "Original Cost New*", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    public ILocator OtherInsuranceHistoryOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=95
    public ILocator Others9E098 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Others*", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=95
    public ILocator OthersB1A1B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Others*", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=95
    public ILocator Partners => _page.GetByRole(AriaRole.Textbox, new() { Name = "Partners*", Exact = true });

    // Source modules: Endorsements|Partners, Officers And Others Exclusion | confidence=High score=125
    public ILocator PartnersOfficersAndOthersExclusionOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Billing | confidence=High score=125
    public ILocator PayPlan => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pay Plan", Exact = true });

    // Source modules: State Details|Main | confidence=High score=95
    public ILocator PendingRateChange => _page.GetByLabel("Pending Rate Change", new() { Exact = true });

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    public ILocator PerVehicleLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Per Vehicle Limit", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator PersAdvInj => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pers Adv Inj", Exact = true });

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    public ILocator PersonalPortableComputers => _page.GetByRole(AriaRole.Textbox, new() { Name = "Personal Portable Computers", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator PersonalPropertyLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Personal Property Limit", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator PersonalPropertyRatingGroup => _page.GetByRole(AriaRole.Textbox, new() { Name = "Personal Property Rating Group", Exact = true });

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=125
    public ILocator PhysicalDamageOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    public ILocator PierOrWharf => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pier Or Wharf", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    public ILocator PierOrWharfCOLOptions => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pier Or Wharf COL Options", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    public ILocator PierOrWharfCauseOfLoss => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pier Or Wharf Cause Of Loss", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    public ILocator PierOrWharfConstruction => _page.GetByRole(AriaRole.Textbox, new() { Name = "Pier Or Wharf Construction", Exact = true });

    // Source modules: UW Questions - Umbrella | confidence=High score=125
    public ILocator PleaseProvideWebsiteAddressEs => _page.GetByRole(AriaRole.Textbox, new() { Name = "Please provide website address(es).*", Exact = true });

    // Source modules: Policy Coverage|Limits | confidence=High score=127
    public ILocator PolicyCovg26786 => _page.GetByLabel("Policy Covg", new() { Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator PolicyCovg35BE4 => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });

    // Source modules: GL Navigation Links | confidence=Medium score=113
    public ILocator PolicyCovg50C98 => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=127
    public ILocator PolicyCovg6B651 => _page.GetByLabel("Policy Covg", new() { Exact = true });

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=125
    public ILocator PolicyCovgBaileesCutomersOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Bailees - Property Away from Your Premises | confidence=High score=125
    public ILocator PolicyCovgBaileesPropertyAwayFromYourPremisesOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    public ILocator PolicyCovgComputerSystemsOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator PolicyCovgContractorsEquipmentOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: CP Navigation Links | confidence=Medium score=113
    public ILocator PolicyCovgD0419 => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator PolicyCovgD3CEF => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    public ILocator PolicyCovgED95C => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });

    // Source modules: Policy Covg - Main | confidence=High score=127
    public ILocator PolicyCovgF9E58 => _page.GetByLabel("Policy Covg", new() { Exact = true });

    // Source modules: Policy Covg | confidence=High score=127
    public ILocator PolicyCovgFF145 => _page.GetByLabel("Policy Covg", new() { Exact = true });

    // Source modules: Policy Covg | confidence=High score=97
    public ILocator PolicyCovgHeader => _page.GetByLabel("Policy Covg Header", new() { Exact = true });

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    public ILocator PolicyCovgMotorTruckCargoOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Signs | confidence=High score=125
    public ILocator PolicyCovgSignsOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    public ILocator PolicyCovgerage => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covgerage", Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=125
    public ILocator PolicyHolderName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Holder Name", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator PolicyInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Info", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=97
    public ILocator PolicyInfoHeader => _page.GetByLabel("Policy Info Header", new() { Exact = true });

    // Source modules: Commercial Auto | confidence=High score=125
    public ILocator PolicyNumber461C7 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    // Source modules: Businessowners | confidence=High score=125
    public ILocator PolicyNumber6566F => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    public ILocator PolicyNumber78B85 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator PolicyNumberBA28E => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    // Source modules: General Liability | confidence=High score=125
    public ILocator PolicyNumberFDF5C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator PolicyType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Type", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    public ILocator PowerSuppressorVoltageRegulator => _page.GetByRole(AriaRole.Textbox, new() { Name = "Power suppressor voltage regulator?*", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator PremOpDed => _page.GetByRole(AriaRole.Textbox, new() { Name = "PremOp Ded", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator PremOpPDDed => _page.GetByRole(AriaRole.Textbox, new() { Name = "PremOp PD Ded", Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator PremisesType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Premises Type", Exact = true });

    // Source modules: Pricing | confidence=High score=125
    public ILocator Premium => _page.GetByLabel("Premium", new() { Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator Pricing900C9 => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator PricingB84E6 => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing", Exact = true });

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator PricingDCBD4 => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing", Exact = true });

    // Source modules: Pricing | confidence=High score=125
    public ILocator PricingDetail => _page.GetByRole(AriaRole.Button, new() { Name = "Pricing Detail", Exact = true });

    // Source modules: Pricing | confidence=High score=125
    public ILocator PricingDetailOK => _page.GetByRole(AriaRole.Button, new() { Name = "Pricing Detail - OK", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    public ILocator PricingF3185 => _page.GetByRole(AriaRole.Link, new() { Name = "Pricing", Exact = true });

    // Source modules: Pricing | confidence=High score=97
    public ILocator PricingHeading => _page.GetByLabel("Pricing Heading", new() { Exact = true });

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    public ILocator PrimaryLiabilityIfAny => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Primary Liability If Any", Exact = true });

    // Source modules: Policy Covg | confidence=High score=125
    public ILocator PrimaryLocationState => _page.GetByRole(AriaRole.Textbox, new() { Name = "Primary Location State*", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=95
    // Not Displayed for WC
    public ILocator PrimaryRatingState => _page.GetByRole(AriaRole.Textbox, new() { Name = "PrimaryRatingState", Exact = true });

    // Source modules:  | confidence=High score=95
    // Required for Commit/ Submission
    public ILocator PriorAmericanNationalPolicy => _page.GetByRole(AriaRole.Textbox, new() { Name = "Prior American National Policy #*", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator ProdBIDed => _page.GetByRole(AriaRole.Textbox, new() { Name = "Prod BI Ded", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator ProdPDDed => _page.GetByRole(AriaRole.Textbox, new() { Name = "Prod PD Ded", Exact = true });

    // Source modules: Risk Schedule|General Coverage | confidence=High score=125
    public ILocator ProduceCarried => _page.GetByRole(AriaRole.Textbox, new() { Name = "Produce Carried", Exact = true });

    // Source modules: Policy Covg|GL | confidence=High score=95
    public ILocator ProductsAggLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Products Agg Limit", Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    public ILocator ProductsCompletedOperationsAggregateLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Products - Completed Operations Aggregate Limit", Exact = true });

    // Source modules: Products/Completed Ops | confidence=High score=97
    public ILocator ProductsCompletedOps => _page.GetByLabel("Products/Completed Ops", new() { Exact = true });

    // Source modules: Products/Completed Ops | confidence=Medium score=113
    public ILocator ProductsCompletedOpsButton => _page.GetByRole(AriaRole.Link, new() { Name = "Products/Completed Ops Button", Exact = true });

    // Source modules: Products/Completed Ops | confidence=High score=125
    public ILocator ProductsCompletedOpsOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: CP Navigation Links | confidence=Medium score=113
    public ILocator Property => _page.GetByRole(AriaRole.Link, new() { Name = "Property", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator PropertyAddClassOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=125
    public ILocator PropertyAwayFromYourPremisesSchedule => _page.GetByRole(AriaRole.Button, new() { Name = "Property Away From Your Premises Schedule", Exact = true });

    // Source modules: Property Enter Building RCT | confidence=High score=125
    public ILocator PropertyEnterBuildingRCTOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    public ILocator PropertyInTransit6E905 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Property In Transit", Exact = true });

    // Source modules: Policy Covg - Bailees Cutomers | confidence=High score=125
    public ILocator PropertyInTransit710FF => _page.GetByRole(AriaRole.Textbox, new() { Name = "Property In Transit", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator PropertyOfOthersLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Property of Others Limit", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator PropertyOfOthersRatingGroup => _page.GetByRole(AriaRole.Textbox, new() { Name = "Property of Others Rating Group", Exact = true });

    // Source modules: Property UW Questions | confidence=High score=127
    public ILocator PropertyUWQuestions790F2 => _page.GetByLabel("Property UW Questions", new() { Exact = true });

    // Source modules: CP Navigation Links | confidence=Medium score=113
    public ILocator PropertyUWQuestions8452C => _page.GetByRole(AriaRole.Link, new() { Name = "Property UW Questions", Exact = true });

    // Source modules: Building - Detail | confidence=High score=94
    public ILocator ProvideAListOfSurroundingExposureOtherOccupanciesWithin100FtIncludingNorthEastSouthAndWest => _page.GetByRole(AriaRole.Textbox, new() { Name = "Provide a List of Surrounding Exposure/Other Occupancies within 100 ft (Including North, East, South, and West)", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    public ILocator ProvideInformationRegardingAntivirusMethodsAndCopyrightProtectionOfDataAndMedia => _page.GetByRole(AriaRole.Textbox, new() { Name = "Provide information regarding antivirus methods and copyright protection of data and media", Exact = true });

    // Source modules: CP Navigation Links | confidence=Medium score=113
    public ILocator RatingGroups46191 => _page.GetByRole(AriaRole.Link, new() { Name = "Rating Groups", Exact = true });

    // Source modules: Rating Groups | confidence=High score=127
    public ILocator RatingGroups46DD2 => _page.GetByLabel("Rating Groups", new() { Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator RentalOwnersLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Rental Owners Liability", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator RentalReimbursement => _page.GetByRole(AriaRole.Textbox, new() { Name = "Rental Reimbursement", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator RentedEquipmentExpense => _page.GetByRole(AriaRole.Textbox, new() { Name = "Rented Equipment Expense", Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    // Available when Umbrella Limit selected is in the "Over" category (e.g. Over 15M)
    public ILocator RequestedUmbrellaLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Requested Umbrella Limit", Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The string result to verify
    public ILocator Result => _page.GetByLabel("Result", new() { Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator ReturnToQuote => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Quote", Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    public ILocator Risk5D6FA => _page.GetByRole(AriaRole.Link, new() { Name = "Risk", Exact = true });

    // Source modules: Risk - Main | confidence=High score=127
    public ILocator Risk873E7 => _page.GetByLabel("Risk", new() { Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator RiskAccountsReceivableOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator RiskBaileesCustomersOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Risk - Computer Systems | confidence=High score=125
    public ILocator RiskComputerSystemsOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Risk Aggregate | confidence=High score=127
    public ILocator RiskDDE70 => _page.GetByLabel("Risk", new() { Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=97
    public ILocator RiskHeading => _page.GetByLabel("Risk Heading", new() { Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    public ILocator RiskSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "Risk Schedule", Exact = true });

    // Source modules: Risk - Signs | confidence=High score=125
    public ILocator RiskSignsOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Rating Groups | confidence=High score=95
    public ILocator RiskType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Risk Type", Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    public ILocator RoofType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Roof Type*", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator SFP10LiabilityFarm => _page.GetByRole(AriaRole.Link, new() { Name = "SFP - 10 Liability/Farm", Exact = true });

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=97
    public ILocator SFP10LiabilityFarmHeading => _page.GetByLabel("SFP - 10 Liability/Farm Heading", new() { Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator SaveForLater => _page.GetByRole(AriaRole.Link, new() { Name = "Save for Later", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator ScheduledCoverage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Scheduled Coverage", Exact = true });

    // Source modules: Risk - Computer Systems | confidence=High score=125
    public ILocator SearchResult4E620 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Result", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator SearchResultA1BFB => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Result", Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator SearchResultEAFB8 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Result", Exact = true });

    // Source modules: CGL|Add Class | confidence=High score=125
    public ILocator SearchResults5209C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Results", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator SearchResultsD0AA8 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Results", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator SearchValue53135 => _page.GetByRole(AriaRole.Textbox, new() { Name = "SearchValue", Exact = true });

    // Source modules: Property Add Class | confidence=High score=125
    public ILocator SearchValue54F3C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Value", Exact = true });

    // Source modules: Risk - Accounts Receivable | confidence=High score=125
    public ILocator SearchValue79E46 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Value", Exact = true });

    // Source modules: Risk - Computer Systems | confidence=High score=125
    public ILocator SearchValue9FCD1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Value", Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator SearchValueCA6A6 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Value", Exact = true });

    // Source modules: Risk Schedule|General Coverage | confidence=High score=125
    public ILocator SeasonalProduceTrailers => _page.GetByRole(AriaRole.Textbox, new() { Name = "Seasonal Produce Trailers", Exact = true });

    // Source modules: Location | confidence=High score=127
    public ILocator Select => _page.GetByRole(AriaRole.Link, new() { Name = "Select", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator SelectAppropriateCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Select Appropriate Code", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator SelectClassCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Select Class Code*", Exact = true });

    // Source modules: [CU0206] Utah Changes - Notice of Cancellation for Private Investigator Agencies | confidence=High score=125
    public ILocator SelectEndorsement0EAB0 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Select Endorsement:", Exact = true });

    // Source modules: [UC1101] Exclusion for Designated Activities or Services | confidence=High score=125
    public ILocator SelectEndorsement63E0E => _page.GetByRole(AriaRole.Textbox, new() { Name = "Select Endorsement:", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator SelectNAICSCode => _page.GetByRole(AriaRole.Button, new() { Name = "Select NAICS Code", Exact = true });

    // Source modules: Location | confidence=High score=125
    public ILocator SelectPPC => _page.GetByRole(AriaRole.Button, new() { Name = "Select PPC", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator Sex => _page.GetByRole(AriaRole.Textbox, new() { Name = "Sex", Exact = true });

    // Source modules: Risk Aggregate | confidence=High score=95
    public ILocator ShowAllLocations => _page.GetByRole(AriaRole.Textbox, new() { Name = "Show All Locations", Exact = true });

    // Source modules: Risk - Signs | confidence=High score=125
    public ILocator SignLocation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Sign Location", Exact = true });

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=97
    public ILocator SignsHeading => _page.GetByLabel("Signs Heading", new() { Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    public ILocator SignsUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Signs UW Questions", Exact = true });

    // Source modules: State Details|Main | confidence=High score=95
    public ILocator SmallDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Small Deductible*", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=95
    public ILocator SoleProprietors => _page.GetByRole(AriaRole.Textbox, new() { Name = "Sole Proprietors*", Exact = true });

    // Source modules: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | confidence=High score=125
    public ILocator SoleProprietorsPartnersOfficersAndOthersCoverageOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    public ILocator SpecificUnderwritingQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "Specific Underwriting Questions", Exact = true });

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsAccountsReceivableOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Specific Underwriting Questions - Bailees Customer | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsBaileesCustomerOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsComputerSystemsOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsContractorsEquipmentOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsMotorTruckCargoOwnersOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=125
    public ILocator SpecificUnderwritingQuestionsSignsOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SplitBIDed => _page.GetByText("Split BI Ded", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SplitPDDed => _page.GetByText("Split PD Ded", new() { Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    public ILocator SquareFeet => _page.GetByRole(AriaRole.Textbox, new() { Name = "Square Feet", Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=124
    public ILocator State16B92 => _page.GetByRole(AriaRole.Combobox, new() { Name = "State", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator State64A10 => _page.GetByRole(AriaRole.Textbox, new() { Name = "State", Exact = true });

    // Source modules: Endorsements|Designated Workplaces Exclusion | confidence=High score=125
    public ILocator State89468 => _page.GetByRole(AriaRole.Textbox, new() { Name = "State*", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    public ILocator StateDetails33183 => _page.GetByRole(AriaRole.Link, new() { Name = "State Details", Exact = true });

    // Source modules: State Details|UM/UIM | confidence=High score=127
    public ILocator StateDetails72631 => _page.GetByLabel("State Details", new() { Exact = true });

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator StateDetailsB407B => _page.GetByRole(AriaRole.Link, new() { Name = "State Details", Exact = true });

    // Source modules: BAP Navigation Links | confidence=High score=127
    public ILocator StateDetailsDetail => _page.GetByRole(AriaRole.Link, new() { Name = "State Details - Detail", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator StateLicensed => _page.GetByRole(AriaRole.Textbox, new() { Name = "State Licensed", Exact = true });

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    public ILocator StateOrPoliticalSubdivision => _page.GetByRole(AriaRole.Textbox, new() { Name = "State or Political Subdivision*", Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=95
    public ILocator StatedAmount => _page.GetByRole(AriaRole.Textbox, new() { Name = "Stated Amount*", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator StoplightMessageTotalSubjectPremium => _page.GetByText("Stoplight Message: Total Subject Premium", new() { Exact = true });

    // Source modules: Risk - Bailees Customers | confidence=High score=125
    public ILocator StorageLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Storage Limit", Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    public ILocator Stories => _page.GetByRole(AriaRole.Textbox, new() { Name = "Stories", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator Submission => _page.GetByRole(AriaRole.Link, new() { Name = "Submission", Exact = true });

    // Source modules: Submission|Required and Optional Fields | confidence=High score=127
    public ILocator SubmissionHeading => _page.GetByLabel("Submission Heading", new() { Exact = true });

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    public ILocator TapesCoverage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Tapes Coverage", Exact = true });

    // Source modules: NotePad | confidence=High score=124
    public ILocator TextBox => _page.GetByRole(AriaRole.Textbox, new() { Name = "TextBox", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator ThirdPartyDesignee => _page.GetByRole(AriaRole.Link, new() { Name = "Third Party Designee", Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // Defines the caption of the browser window that is searched for.
    public ILocator Title => _page.GetByLabel("Title", new() { Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator ToolsAndClothingBelongingToYourEmployees => _page.GetByRole(AriaRole.Textbox, new() { Name = "Tools And Clothing Belonging To Your Employees", Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=125
    public ILocator TotalCostOfWork => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Cost of Work*", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator TotalPayrollEstimated => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Payroll (Estimated)", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator TotalPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Premium", Exact = true });

    // Source modules: General Liability | confidence=High score=125
    public ILocator TotalSubjectPremium19B44 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Subject Premium*", Exact = true });

    // Source modules: SFP - 10 Liability/Farm | confidence=High score=125
    public ILocator TotalSubjectPremiumAF452 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Subject Premium*", Exact = true });

    // Source modules: Businessowners | confidence=High score=125
    public ILocator TotalSubjectPremiumE8AF0 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Subject Premium*", Exact = true });

    // Source modules: Risk Schedule|Physical Damage | confidence=High score=95
    public ILocator Towing => _page.GetByRole(AriaRole.Textbox, new() { Name = "Towing", Exact = true });

    // Source modules: Policy Coverage|Limits | confidence=High score=125
    public ILocator TrailerInterchangeCollisionDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Trailer Interchange Collision Deductible", Exact = true });

    // Source modules: Policy Coverage|Limits | confidence=High score=125
    public ILocator TrailerInterchangeCompDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Trailer Interchange Comp Deductible", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator TrailerInterchangeEnterDaysInsured => _page.GetByRole(AriaRole.Textbox, new() { Name = "Trailer Interchange - Enter # Days Insured", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator TrailerInterchangeEnterOfTrailers => _page.GetByRole(AriaRole.Textbox, new() { Name = "Trailer Interchange - Enter # of Trailers", Exact = true });

    // Source modules: [FG 00 13] Automatic Additional Insured - Specific Relationship | confidence=High score=124
    public ILocator Type56F72 => _page.GetByRole(AriaRole.Combobox, new() { Name = "Type", Exact = true });

    // Source modules: Endorsement - Main | confidence=High score=125
    public ILocator Type715D6 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=124
    public ILocator Type885AA => _page.GetByRole(AriaRole.Combobox, new() { Name = "Type", Exact = true });

    // Source modules: [CG 20 20] Add'l Insured-Charitable Institution | confidence=High score=125
    public ILocator TypeA75B5 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    // Source modules: Risk - Signs | confidence=High score=125
    public ILocator TypeB082D => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    public ILocator TypeCDE3B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    // Source modules: [CG 20 07] Add'l Insured-Engineers, Architects | confidence=High score=125
    public ILocator TypeD0639 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator TypeD972C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    // Source modules: Policy Covg - Contractors Equipment | confidence=High score=125
    public ILocator TypeOfContractor => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type Of Contractor", Exact = true });

    // Source modules: [CG 20 34] Add'l Insured-Leased Equipment Automatic  | confidence=High score=95
    public ILocator TypeOfEquipment => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type of Equipment", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator TypeOfInterest => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type of Interest", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TypeOfLicense => _page.GetByText("Type of License", new() { Exact = true });

    // Source modules: State Details|UM/UIM | confidence=High score=95
    public ILocator UMBILimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "UMBI Limit*", Exact = true });

    // Source modules: State Details|UM/UIM | confidence=High score=95
    public ILocator UMTypeDefaultSelections => _page.GetByRole(AriaRole.Textbox, new() { Name = "UM Type Default Selections", Exact = true });

    // Source modules: State Details|UM/UIM | confidence=High score=125
    public ILocator UMUIMOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    public ILocator UWQuestions368CC => _page.GetByRole(AriaRole.Link, new() { Name = "UW Questions", Exact = true });

    // Source modules: Underwriting Questions | confidence=High score=127
    public ILocator UWQuestionsF3D9F => _page.GetByLabel("UW Questions", new() { Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator UWQuestionsUmbrella9F47E => _page.GetByRole(AriaRole.Link, new() { Name = "UW Questions - Umbrella", Exact = true });

    // Source modules: UW Questions - Umbrella | confidence=High score=127
    public ILocator UWQuestionsUmbrellaFF014 => _page.GetByLabel("UW Questions - Umbrella", new() { Exact = true });

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator UWQuestionsWorkersComp => _page.GetByRole(AriaRole.Link, new() { Name = "UW Questions - Workers Comp", Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    public ILocator UmbrellaLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Umbrella Limit", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator UnderwritingInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    public ILocator UninterruptiblePowerSource => _page.GetByRole(AriaRole.Textbox, new() { Name = "Uninterruptible power source?*", Exact = true });

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    public ILocator UnnamedPremises => _page.GetByRole(AriaRole.Textbox, new() { Name = "Unnamed Premises", Exact = true });

    // Source modules: Policy Covg - Motor Truck Cargo | confidence=High score=125
    public ILocator UnnamedTerminalsLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Unnamed Terminals Limit", Exact = true });

    // Source modules: Specific Underwriting Questions - Contractors Equipment | confidence=High score=125
    public ILocator UpdateAnswers3DA0B => _page.GetByRole(AriaRole.Button, new() { Name = "Update Answers", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    public ILocator UpdateAnswers3DDA2 => _page.GetByRole(AriaRole.Button, new() { Name = "Update Answers", Exact = true });

    // Source modules: Products/Completed Ops | confidence=High score=125
    public ILocator UpdateAnswers69564 => _page.GetByRole(AriaRole.Button, new() { Name = "Update Answers", Exact = true });

    // Source modules: UW Questions - Workers Comp | confidence=High score=125
    public ILocator UpdateAnswers6FF76 => _page.GetByRole(AriaRole.Button, new() { Name = "Update Answers", Exact = true });

    // Source modules: Property UW Questions | confidence=High score=125
    public ILocator UpdateAnswers99D68 => _page.GetByRole(AriaRole.Button, new() { Name = "Update Answers", Exact = true });

    // Source modules: Underwriting Info | General UW Questions | confidence=Medium score=113
    public ILocator UpdateAnswers9CB86 => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true });

    // Source modules: UW Questions - Umbrella | confidence=High score=125
    public ILocator UpdateAnswersB41BE => _page.GetByRole(AriaRole.Button, new() { Name = "Update Answers", Exact = true });

    // Source modules: Underwriting Questions | confidence=High score=125
    public ILocator UpdateAnswersButton => _page.GetByRole(AriaRole.Button, new() { Name = "Update Answers Button", Exact = true });

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=125
    public ILocator UpdateAnswersD8A16 => _page.GetByRole(AriaRole.Button, new() { Name = "Update Answers", Exact = true });

    // Source modules: General Liability Information | confidence=High score=125
    public ILocator UpdateAnswersFB765 => _page.GetByRole(AriaRole.Button, new() { Name = "Update Answers", Exact = true });

    // Source modules: Risk Schedule|General Coverage | confidence=High score=95
    public ILocator UsedAsShowroom => _page.GetByRole(AriaRole.Textbox, new() { Name = "Used As Showroom", Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=125
    public ILocator VIN => _page.GetByRole(AriaRole.Textbox, new() { Name = "VIN*", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    public ILocator VacancyPermit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Vacancy Permit", Exact = true });

    // Source modules: Property - Main | confidence=High score=95
    public ILocator VacantBuilding => _page.GetByRole(AriaRole.Textbox, new() { Name = "Vacant Building", Exact = true });

    // Source modules: Rating Groups | confidence=High score=95
    public ILocator Valuation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Valuation", Exact = true });

    // Source modules: Property Enter Building RCT | confidence=High score=125
    public ILocator ValuationType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Valuation Type*", Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=95
    public ILocator ValueBasis => _page.GetByRole(AriaRole.Textbox, new() { Name = "Value Basis", Exact = true });

    // Source modules: State Details|Hired Auto Physical Damage With Driver | confidence=High score=125
    public ILocator VehicleInformation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Vehicle Information", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator VehicleSchedule1Veh => _page.GetByText("Veh #", new() { Exact = true });

    // Source modules: Risk Aggregate | confidence=High score=125
    public ILocator VehicleType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Vehicle Type", Exact = true });

    // Source modules: Policy Covg - Computer Systems | confidence=High score=125
    public ILocator VirusHarmfulCodeOrSimilarInstruction => _page.GetByRole(AriaRole.Textbox, new() { Name = "Virus, Harmful Code Or Similar Instruction", Exact = true });

    // Source modules: State Details|Hired Auto Liability | confidence=High score=124
    public ILocator VolunteerHiredAutosCheckBox => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Volunteer Hired Autos CheckBox", Exact = true });

    // Source modules: WC Navigation Links | confidence=Medium score=113
    public ILocator WCSchedule => _page.GetByRole(AriaRole.Link, new() { Name = "WC Schedule", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator WaitonPricingHeadingAndFillOutRequiredFields => _page.GetByText("Waiton Pricing Heading and Fill Out Required Fields", new() { Exact = true });

    // Source modules: State Details|Main | confidence=High score=95
    public ILocator WaiverOfSubrogation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Waiver Of Subrogation", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator WaiverOfSubrogationExposure => _page.GetByRole(AriaRole.Textbox, new() { Name = "Waiver Of Subrogation Exposure*", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator WereTheExposuresInsuredOnThisPolicyPreviouslyInsuredForThisClientOnAnotherFarmFamilyAmericanNationalPolicyWithinTheLast90Days => _page.GetByRole(AriaRole.Textbox, new() { Name = "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    public ILocator WhatAreTheProceduresAndMethodsForKeepingTheEDPAreasSecured => _page.GetByRole(AriaRole.Textbox, new() { Name = "What are the procedures and methods for keeping the EDP areas secured?", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=124
    public ILocator WhatAreTheProceduresAndScheduleForBackingUpTheMediaAndDataAndTheirStorage => _page.GetByRole(AriaRole.Textbox, new() { Name = "What are the procedures and schedule for backing up the media and data and their storage?", Exact = true });

    // Source modules: Specific Underwriting Questions - Signs | confidence=High score=124
    public ILocator WhatIsTheConstructionOfEachSign => _page.GetByRole(AriaRole.Textbox, new() { Name = "What is the construction of each sign?", Exact = true });

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=124
    public ILocator WhatIsTheConstructionOfThePremisesWhereTheReceivablesAreStored => _page.GetByRole(AriaRole.Textbox, new() { Name = "What is the construction of the premises where the receivables are stored?", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    public ILocator WhatIsTheDistanceInFeetToTheNearestFireHydrant => _page.GetByRole(AriaRole.Textbox, new() { Name = "What is the distance in feet to the nearest fire hydrant?", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    public ILocator WhatIsTheDistanceInMilesToTheNearestRespondingFireDepartment => _page.GetByRole(AriaRole.Textbox, new() { Name = "What is the distance in miles to the nearest responding fire department?*", Exact = true });

    // Source modules:  | confidence=High score=95
    // Required for Commit/ Submission
    public ILocator WhatIsThePrimaryReasonThisNewPolicyIsBeingRewrittenWithFarmFamilyAmericanNational => _page.GetByRole(AriaRole.Textbox, new() { Name = "What is the primary reason this new policy is being rewritten with Farm Family/American National?*", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=Medium score=113
    public ILocator WhatIsTheProcedureForTransportingTheComputerEquipment => _page.GetByRole(AriaRole.Textbox, new() { Name = "What is the procedure for transporting the computer equipment?", Exact = true });

    // Source modules: Specific Underwriting Questions - Computer Systems | confidence=High score=125
    public ILocator WhatIsThePublicProtectionClassRating => _page.GetByRole(AriaRole.Textbox, new() { Name = "What is the public protection class rating?*", Exact = true });

    // Source modules: Specific Underwriting Questions - Accounts Receivable | confidence=High score=124
    public ILocator WhatSafeguardsAreInPlaceForReceivablesToProtectAgainstDamageOrTheft => _page.GetByRole(AriaRole.Textbox, new() { Name = "What safeguards are in place for receivables to protect against damage or theft?", Exact = true });

    // Source modules: Specific Underwriting Questions - Motor Truck Cargo(Owners) | confidence=High score=125
    public ILocator WhichFormAreYouCompleting => _page.GetByRole(AriaRole.Textbox, new() { Name = "Which form are you completing?", Exact = true });

    // Source modules: [CG0424] Coverage for Injury to Leased Workers | confidence=High score=124
    public ILocator WhyIsThisCoverageDesired => _page.GetByRole(AriaRole.Textbox, new() { Name = "Why is this coverage desired?", Exact = true });

    // Source modules: Risk Schedule|Vehicle Information | confidence=High score=125
    public ILocator Year => _page.GetByRole(AriaRole.Textbox, new() { Name = "Year*", Exact = true });

    // Source modules: Building - Detail | confidence=High score=125
    public ILocator YearBuilt => _page.GetByRole(AriaRole.Textbox, new() { Name = "Year Built", Exact = true });

    // Source modules:  | confidence=High score=95
    public ILocator YearLicensed => _page.GetByRole(AriaRole.Textbox, new() { Name = "Year Licensed", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    // BAP, BOP, CPP, CP, IM, CR, SUMB ONLY (JULY-20)
    public ILocator YearsInBusiness => _page.GetByRole(AriaRole.Textbox, new() { Name = "Years In Business", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator ZipCodeB286B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code", Exact = true });

    // Source modules: Client|Third Party Designee|Common | confidence=High score=125
    public ILocator ZipCodeBCEA0 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code*", Exact = true });

    // Source modules: [CG 29 35] Add'l Insured-State or Political (Permits) | confidence=High score=125
    public ILocator ZipCodeC048F => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code", Exact = true });

    // Source modules: GL OCP|Risk | confidence=High score=125
    public ILocator ZipCodeC7591 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code", Exact = true });

    // Source modules: Location | confidence=High score=125
    public ILocator ZipCodeD2DBA => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code", Exact = true });

}
