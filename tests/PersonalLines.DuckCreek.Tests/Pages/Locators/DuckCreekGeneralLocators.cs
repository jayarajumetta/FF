using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class DuckCreekGeneralLocators
{
    private readonly IPage _page;
    public DuckCreekGeneralLocators(IPage page) => _page = page;

    public ILocator BODY => _page.GetByText("BODY", new() { Exact = true });

    public ILocator Login => _page.GetByRole(AriaRole.Link, new() { Name = "Login", Exact = true });

    public ILocator Password => _page.Locator("[id=\"password-inputEl\"]");

    public ILocator UserName => _page.Locator("[id=\"username-inputEl\"]");

    public ILocator QuickSearch => _page.Locator("[name=\"name_quickSearch\"]");

    public ILocator SearchField => _page.Locator("[id=\"_keynameAdvSearch1-inputEl\"]");

    public ILocator SearchOperator => _page.Locator("[id=\"_keyopAdvSearch1-inputEl\"]");

    public ILocator SearchValue => _page.Locator("[id=\"_keyvalueTextSearch1-inputEl\"]");

    public ILocator SearchButton => _page.Locator("[name=\"searchFilterActions\"]");

    public ILocator SearchResultInsuredNameLink => _page.Locator("[id=\"clientPageLoadA\"]");

    public ILocator SubmissionLink => _page.Locator("a[onclick*=\"SubmissionDetail\"]");

    public ILocator CompleteApplicationButton => _page.Locator("a:has(span.g-btn-text:has-text(\"Complete Application\"))");

    public ILocator ProcessingCompleteMessage => _page.Locator("#stoplightWaitingResults");

    public ILocator ProcessingCompleteCloseButton => _page.Locator("#stoplightCloseButton .x-btn");

    public ILocator ApproveButton => _page.Locator("a:has(span.g-btn-text:has-text(\"Approve\"))");

    public IFrameLocator ApproveDialogFrame => _page.FrameLocator("[id^=\"dctPopup_dctPopupWindow\"]");

    public ILocator OkButton => ApproveDialogFrame.Locator("a:has(span.g-btn-text:has-text(\"OK\"))").First;

    public ILocator ApprovedStatus => _page.Locator("span.g-btn-text:has-text(\"Approved\")");
}
