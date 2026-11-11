using Microsoft.Playwright;
namespace InsuranceAutomation.CLDC.Pages.Locators;
public sealed class RegressionTransactionLocators
{
    private readonly IPage _page;
    public RegressionTransactionLocators(IPage page) => _page = page;
    public ILocator PageTitle => _page.Locator("#pageTitle");
    public ILocator PolicyNumber => _page.Locator("[fieldref='PolicyOutput.PolicyNumber'], [duckcreekid='Policy #:'], [fieldref='Policy #:']").First;
    public ILocator PolicyStatus => _page.Locator("[duckcreekid='Policy Status:'], [fieldref='Policy Status:']").First;
    public ILocator TransactionType => _page.Locator("input[fieldref='TransACTInput.TransactionTypeList']");
    public ILocator Go => _page.Locator("[duckcreekid='Go'], a:text-is('Go'), button:text-is('Go'), a:has(span.g-btn-text:text-is('Go'))").First;
    public ILocator QuickFilter => _page.Locator("input[fieldref='TransACTInput.QuickFilterList']");
    public ILocator ViewPolicy => _page.Locator("[data-tip='View Policy']").First;
    public ILocator EditPolicy => _page.Locator("[data-tip='Edit Policy']").First;
    public ILocator TransactionGrid => _page.Locator("#transACTGrid, table").First;
    public ILocator ReturnToTransACT => _page.GetByText("Return to TransACT", new() { Exact = false }).First;
    public ILocator ViewPolicyDetails => _page.GetByText("View Policy Details", new() { Exact = false }).First;
    public ILocator AttachmentsGrid => _page.Locator("#attachmentsListGrid");
    public IFrameLocator Popup => _page.FrameLocator("iframe[id^='dctPopup_dctPopupWindow']");
    public ILocator EffectiveDate => Popup.Locator("input[fieldref^='TransACTInput.NewTransactionEffectiveDate']");
    public ILocator Reason => Popup.Locator("input[fieldref='NewTransactionReason.NewTransactionReasonCodes']");
    public ILocator ReasonDetail => Popup.Locator("input[fieldref='NewTransactionReason.NewTransactionReasonDescription'], textarea[fieldref='NewTransactionReason.NewTransactionReasonDescription']").First;
    public ILocator LocationQuestion => Popup.Locator("input[fieldref='NewTransactionReason.NewTransactionLocationQuestion']");
    public ILocator RollToRenewal => Popup.Locator("input[fieldref='TransACTInput.RollChangesIntoRenewalTerm']");
    public ILocator OK => Popup.GetByText("OK", new() { Exact = false }).First;
}
