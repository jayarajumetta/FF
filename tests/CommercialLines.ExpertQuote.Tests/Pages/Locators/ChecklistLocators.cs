using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class ChecklistLocators
{
    private readonly IPage _page;
    public ChecklistLocators(IPage page) => _page = page;

    public ILocator BuildingPhoto1 => _page.Locator("a.checklist-summary-item").Filter(new LocatorFilterOptions { HasText = "Building Photo #1" }).First;

    public ILocator Exception => _page.Locator("button#exception.js-exception");

    public ILocator RequireNote => _page.Locator("textarea.js-require-note.require-note");

    public ILocator ExceptionNoteConfirmOK => _page.Locator("button#exception-note-confirm.js-exception-note-confirm").Filter(new LocatorFilterOptions { HasText = "OK" });

    public ILocator ExceptionNoteCancel => _page.Locator("div.modal-footer button[data-dismiss=\"modal\"]").Filter(new LocatorFilterOptions { HasText = "Cancel" }).First;
}
