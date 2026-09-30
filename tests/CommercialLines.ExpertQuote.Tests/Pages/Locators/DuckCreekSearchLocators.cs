using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class DuckCreekSearchLocators
{
    private readonly IPage _page;
    public DuckCreekSearchLocators(IPage page) => _page = page;

    public ILocator QuickSearch => _page.Locator("[name=\"name_quickSearch\"]");

    public ILocator SearchField => _page.Locator("[id=\"_keynameAdvSearch1-inputEl\"]");

    public ILocator SearchOperator => _page.Locator("[id=\"_keyopAdvSearch1-inputEl\"]");

    public ILocator SearchValue => _page.Locator("[id=\"_keyvalueTextSearch1-inputEl\"]");

    public ILocator SearchButton => _page.Locator("[name=\"searchFilterActions\"]");

    public ILocator SearchResultInsuredNameLink => _page.Locator("[id=\"clientPageLoadA\"]");

    public ILocator BusinessOwnersQuoteLink => _page.Locator("a[onclick*=\"CarrierBusinessOwners\"]");

    public ILocator SubmissionLink => _page.Locator("a[onclick*=\"SubmissionDetail\"]");

    public ILocator CompleteApplicationButton => _page.Locator("a:has(span.g-btn-text:has-text(\"Complete Application\"))");

    public ILocator ProcessingCompleteMessage => _page.Locator("#stoplightWaitingResults");

    public ILocator ProcessingCompleteCloseButton => _page.Locator("#stoplightCloseButton .x-btn");

    public ILocator ApproveButton => _page.Locator("a:has(span.g-btn-text:has-text(\"Approve\"))");

    public ILocator ApproveDialog => _page.Locator("div:has-text(\"Duck Creek Policy\"):has-text(\"Approve\")").Last;

    public IFrameLocator ApproveDialogFrame => _page.FrameLocator("[id^=\"dctPopup_dctPopupWindow\"]");

    public ILocator OkButton => ApproveDialogFrame.Locator("a:has(span.g-btn-text:has-text(\"OK\"))").First;

    public ILocator ApprovedStatus => _page.Locator("span.g-btn-text:has-text(\"Approved\")");
}
