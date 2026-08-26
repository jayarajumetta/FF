using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class LossHistoryLocators
{
    private readonly IPage _page;
    public LossHistoryLocators(IPage page) => _page = page;

    // Source modules: Addl Interests - Main | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Main | Add Addl Interest | DuckCreekId
    public ILocator AddAddlInterest => _page.Locator("[duckcreekid=\"Add Addl Interest\"], [data-duckcreekid=\"Add Addl Interest\"]");

    // Source modules: CP Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Addl Interests - Main | Addl Interests | Id
    public ILocator AddlInterests => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Addl Interests - Loss Payee | confidence=High score=95
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Addl Interests Main - OK | DuckCreekId
    public ILocator AddlInterestsMainOK => _page.Locator("[duckcreekid=\"OK\"], [data-duckcreekid=\"OK\"]");

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Address 1* | DuckCreekId | frame=iframe
    public ILocator Address1 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.Address1\"], [data-duckcreekid=\"AdditionalOtherInterestInput.Address1\"]");

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Assign Locations... | DuckCreekId
    public ILocator AssignLocations => _page.Locator("[duckcreekid=\"Assign Locations...\"], [data-duckcreekid=\"Assign Locations...\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator AssignmentScheduleFor => _page.GetByText("Assignment Schedule for:", new() { Exact = true });

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Assignment Schedule for - OK | DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as AddlInterestsMainOK
    public ILocator AssignmentScheduleForOK => AddlInterestsMainOK;

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Description Of Property* | DuckCreekId
    public ILocator DescriptionOfProperty => _page.Locator("[duckcreekid=\"AdditionalOtherInterestInput.PropertyDescription\"], [data-duckcreekid=\"AdditionalOtherInterestInput.PropertyDescription\"]");

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | First Name* | DuckCreekId | frame=iframe
    public ILocator FirstName => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.FirstName\"], [data-duckcreekid=\"AdditionalOtherInterestInput.FirstName\"]");

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Insured Type* | DuckCreekId | frame=iframe
    public ILocator InsuredType => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.InsuredType\"], [data-duckcreekid=\"AdditionalOtherInterestInput.InsuredType\"]");

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Last Name* | DuckCreekId | frame=iframe
    public ILocator LastName => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.LastName\"], [data-duckcreekid=\"AdditionalOtherInterestInput.LastName\"]");

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Loan Number | DuckCreekId
    public ILocator LoanNumber => _page.Locator("[duckcreekid=\"AdditionalOtherInterestInput.LoanNumber\"], [data-duckcreekid=\"AdditionalOtherInterestInput.LoanNumber\"]");

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | MI | DuckCreekId
    public ILocator MI => _page.Locator("[duckcreekid=\"AdditionalOtherInterestInput.MiddleInitial\"], [data-duckcreekid=\"AdditionalOtherInterestInput.MiddleInitial\"]");

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | New Assignment... | DuckCreekId
    public ILocator NewAssignment => _page.Locator("[duckcreekid=\"New Assignment...\"], [data-duckcreekid=\"New Assignment...\"]");

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Other Interest Premises Detail - OK | DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as AddlInterestsMainOK
    public ILocator OtherInterestPremisesDetailOK => AddlInterestsMainOK;

    // Source modules: Addl Interests - Loss Payee | confidence=High score=97
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Other Interest Premises Schedule | Id
    // v56 semantic alias: same physical raw-Tosca control as AddlInterests
    public ILocator OtherInterestPremisesSchedule => AddlInterests;

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Other Interest Premises Schedule - OK | DuckCreekId
    // v56 semantic alias: same physical raw-Tosca control as AddlInterestsMainOK
    public ILocator OtherInterestPremisesScheduleOK => AddlInterestsMainOK;

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Provisions Applicable* | DuckCreekId
    public ILocator ProvisionsApplicable => _page.Locator("[duckcreekid=\"AdditionalOtherInterestInput.ProvisionsApplicable\"], [data-duckcreekid=\"AdditionalOtherInterestInput.ProvisionsApplicable\"]");

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Type | DuckCreekId | frame=iframe
    public ILocator Type => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.Type\"], [data-duckcreekid=\"AdditionalOtherInterestInput.Type\"]");

    // Source modules: Addl Interests - Loss Payee | confidence=High score=125
    // v56 raw Tosca primary: Addl Interests - Loss Payee | Zip Code* | DuckCreekId | frame=iframe
    public ILocator ZipCode => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.ZipCode\"], [data-duckcreekid=\"AdditionalOtherInterestInput.ZipCode\"]");

}
