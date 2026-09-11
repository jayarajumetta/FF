using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class ChecklistLocators
{
    private readonly IPage _page;
    public ChecklistLocators(IPage page) => _page = page;

    public ILocator BuildingPhoto1 => _page.Locator("a.checklist-summary-item").Filter(new LocatorFilterOptions { HasText = "Building Photo #1" }).First;

    public ILocator SignaturePage => _page.Locator("a.checklist-summary-item").Filter(new LocatorFilterOptions { HasText = "Signature Page" }).First;

    public ILocator SignaturePageItemName => _page.Locator("span.text-info#checklist-item-name").Filter(new LocatorFilterOptions { HasText = "Signature Page" });

    public ILocator Exception => _page.Locator("button#exception.js-exception");

    public ILocator RequireNote => _page.Locator("textarea.js-require-note.require-note");

    public ILocator ExceptionNoteConfirmOK => _page.Locator("button#exception-note-confirm.js-exception-note-confirm").Filter(new LocatorFilterOptions { HasText = "OK" });

    public ILocator ExceptionNoteCancel => _page.Locator("div.modal-footer button[data-dismiss=\"modal\"]").Filter(new LocatorFilterOptions { HasText = "Cancel" }).First;

    public ILocator FileUploadDropzone => _page.Locator("div#my-awesome-dropzone.dz-clickable");

    public ILocator FileUploadInput => _page.Locator("div#my-awesome-dropzone input.dz-hidden-input");

    public ILocator CurrentItemsHeading => _page.Locator("h4.pull-left").Filter(new LocatorFilterOptions { HasText = "Current Items" });
}
