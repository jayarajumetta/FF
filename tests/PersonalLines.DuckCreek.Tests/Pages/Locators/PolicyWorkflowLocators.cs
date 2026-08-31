using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class PolicyWorkflowLocators
{
    private readonly IPage _page;
    public PolicyWorkflowLocators(IPage page) => _page = page;

    public ILocator AddEditAdditionalInterestFirstMortgageeSearch => _page.Locator("input[id=\"temp.searchName\"][name=\"temp.searchName\"]");

    // Dynamically set by buffer Additional Death Benefit in RTB Auto | 10.2 EQ | Auto_AddlCov PIP
    public ILocator AdditionalDeathBenefit => _page.GetByRole(AriaRole.Button, new() { Name = "Additional Death Benefit", Exact = true });

    // Dynamically set by buffer Additional PIP in RTB Auto | 10.2 EQ | Auto_AddlCov PIP
    public ILocator AdditionalPIP => _page.GetByRole(AriaRole.Button, new() { Name = "Additional PIP", Exact = true });

    // Dynamically set by buffer Auto Health Insurer in RTB Auto | 10.2 EQ | Auto_AddlCov PIP
    public ILocator AutoHealthInsurer => _page.GetByTestId("fields.policy.line.pIPInput$autoHealthInsurer.value-chip-wrapper");

    // Dynamically set by buffer Broadened PIP in RTB Auto | 10.2 EQ | Auto_AddlCov PIP
    public ILocator BroadenedPIP => _page.GetByRole(AriaRole.Button, new() { Name = "Broadened PIP", Exact = true });

    public ILocator BtnCreateNewClient => _page.GetByText("Btn_Create New Client", new() { Exact = true });

    // Dynamically set by buffer Extra PIP Option in RTB Auto | 10.2 EQ | Auto_AddlCov PIP
    public ILocator ExtraPIPOption => _page.GetByTestId("fields.policy.line.pIPInput$extraPIPOption.value-chip-wrapper");

    // Dynamically set by buffer All HH Members 65 or Pension in RTB Auto | 10.2 EQ | Auto_AddlCov PIP
    public ILocator HouseholdMembersAge65OrReceivingPension => _page.GetByRole(AriaRole.Button, new() { Name = "Household members age 65 or receiving pension", Exact = true });

    public ILocator LblClientInfo => _page.GetByText("Lbl_Client Info", new() { Exact = true });

    // Dynamically set by buffer Medical Expense Elimination in RTB Auto | 10.2 EQ | Auto_AddlCov PIP
    public ILocator MedicalExpenseElimination => _page.GetByRole(AriaRole.Button, new() { Name = "Medical Expense Elimination", Exact = true });

    // Dynamically set by buffer PIP Deductible in RTB Auto | 10.2 EQ | Auto_AddlCov PIP
    public ILocator PIPDeductible => _page.GetByTestId("fields.policy.line.pIPInput$deductible.value-chip-wrapper");

    // Dynamically set by buffer PIP Limit in RTB Auto | 10.2 EQ | Auto_AddlCov PIP
    public ILocator PIPLimit => _page.GetByTestId("fields.policy.line.pIPInput$limit.value-chip-wrapper");

    // Dynamically set by buffer PIP Stacking in RTB Auto | 10.2 EQ | Auto_AddlCov PIP
    public ILocator PIPStacking => _page.GetByRole(AriaRole.Button, new() { Name = "PIP Stacking", Exact = true });

    public ILocator PricingDetailsNext => _page.Locator("[id=\"Policy_Headless.Constant_ResidenceSummary-0-layout\"]");

    public ILocator TxtFirst => _page.Locator("[id='customer.name.first']");

    public ILocator TxtLast => _page.Locator("[id='customer.name.last']");

    // Dynamically set by buffer Waiver of Income Loss in RTB Auto | 10.2 EQ | Auto_AddlCov PIP
    public ILocator WaiverOfIncomeLoss => _page.GetByRole(AriaRole.Button, new() { Name = "Waiver of Income Loss", Exact = true });

    public ILocator WorkLossNo => _page.GetByRole(AriaRole.Button, new() { Name = "Work_Loss_No", Exact = true });

}
