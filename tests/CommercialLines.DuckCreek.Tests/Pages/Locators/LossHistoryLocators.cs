using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class LossHistoryLocators
{
    private readonly IPage _page;
    public LossHistoryLocators(IPage page) => _page = page;

    // Source modules: Addl Interests - Main | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Main | Add Addl Interest | guid=3a13d49c-1700-b8a4-7f9c-c742240ee981 | strategy=role-link
    public ILocator AddAddlInterest => _page.GetByRole(AriaRole.Link, new() { Name = "Add Addl Interest", Exact = true });

    // Source modules: CP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: CP Navigation Links | Addl Interests | guid=3a13d49c-1700-babf-020a-77295b8a2f6c | strategy=role-link
    public ILocator AddlInterests => _page.GetByRole(AriaRole.Link, new() { Name = "Addl Interests", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=95
    // v57 raw Tosca: Addl Interests - Loss Payee | Addl Interests Main - OK | guid=3a13d49c-1700-9d53-2615-1f6716737795 | strategy=role-link
    public ILocator AddlInterestsMainOK => _page.GetByRole(AriaRole.Link, new() { Name = "Addl Interests Main - OK", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | Address 1* | guid=3a13d49c-1700-a1d3-9cd8-17212d34ed74 | strategy=retained-semantic
    public ILocator Address1 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address 1*", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | Assign Locations... | guid=3a13d49c-1700-cb2d-3bbb-c0b6b46846ea | strategy=role-link
    public ILocator AssignLocations => _page.GetByRole(AriaRole.Link, new() { Name = "Assign Locations...", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator AssignmentScheduleFor => _page.GetByText("Assignment Schedule for:", new() { Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | Assignment Schedule for - OK | guid=3a13d49c-1700-a108-cc7d-576727ec0410 | strategy=role-link
    public ILocator AssignmentScheduleForOK => _page.GetByRole(AriaRole.Link, new() { Name = "Assignment Schedule for - OK", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | Description Of Property* | guid=3a13d49c-1700-1214-59d1-8e1e6f411ed5 | strategy=retained-semantic
    public ILocator DescriptionOfProperty => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description Of Property*", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | First Name* | guid=3a13d49c-1700-b981-1151-6ad442fc8930 | strategy=retained-semantic
    public ILocator FirstName => _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name*", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | Insured Type* | guid=3a13d49c-1700-e741-e404-8d0e2049962c | strategy=retained-semantic
    public ILocator InsuredType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Insured Type*", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | Last Name* | guid=3a13d49c-1700-b8bb-2e23-91bf5da6561b | strategy=retained-semantic
    public ILocator LastName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name*", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | Loan Number | guid=3a13d49c-1700-7558-3481-d13761d62cbc | strategy=retained-semantic
    public ILocator LoanNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Loan Number", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | MI | guid=3a13d49c-1700-047f-2425-7b50077ab32b | strategy=retained-semantic
    public ILocator MI => _page.GetByRole(AriaRole.Textbox, new() { Name = "MI", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | New Assignment... | guid=3a13d49c-1700-7291-6b8e-17f61af342e8 | strategy=role-link
    public ILocator NewAssignment => _page.GetByRole(AriaRole.Link, new() { Name = "New Assignment...", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | Other Interest Premises Detail - OK | guid=3a13d49c-1700-9d45-ab3d-efcb6727235a | strategy=role-link
    public ILocator OtherInterestPremisesDetailOK => _page.GetByRole(AriaRole.Link, new() { Name = "Other Interest Premises Detail - OK", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=97
    // v57 raw Tosca: Addl Interests - Loss Payee | Other Interest Premises Schedule | guid=3a13d49c-1700-543c-f8a4-6cb6fbc62811 | strategy=id
    public ILocator OtherInterestPremisesSchedule => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | Other Interest Premises Schedule - OK | guid=3a13d49c-1700-e562-9c26-3ccc75e95261 | strategy=role-link
    public ILocator OtherInterestPremisesScheduleOK => _page.GetByRole(AriaRole.Link, new() { Name = "Other Interest Premises Schedule - OK", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | Provisions Applicable* | guid=3a13d49c-1700-ae54-bb1d-711cdcd57ae1 | strategy=retained-semantic
    public ILocator ProvisionsApplicable => _page.GetByRole(AriaRole.Textbox, new() { Name = "Provisions Applicable*", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | Type | guid=3a13d49c-1700-3b19-e335-c32f1083f283 | strategy=retained-semantic
    public ILocator Type => _page.GetByRole(AriaRole.Textbox, new() { Name = "Type", Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v57 raw Tosca: Addl Interests - Loss Payee | Zip Code* | guid=3a13d49c-1700-4191-aeac-2f22a8920c03 | strategy=retained-semantic
    public ILocator ZipCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip Code*", Exact = true });

}
