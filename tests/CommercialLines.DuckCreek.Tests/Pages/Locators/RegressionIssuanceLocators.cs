using Microsoft.Playwright;
using System.Text.RegularExpressions;
namespace InsuranceAutomation.CLDC.Pages.Locators;
public sealed class RegressionIssuanceLocators
{
    private readonly IPage _page;
    public RegressionIssuanceLocators(IPage page) => _page = page;
    public ILocator Submission => _page.GetByText("Submission", new() { Exact = true }).First;
    public ILocator SubmissionNavigation => _page.Locator("a[onclick*='SubmissionDetail']").First;
    public ILocator Refer => _page.Locator("a:has(span.g-btn-text:has-text(\"Refer\"))")
        .Filter(new LocatorFilterOptions { Visible = true }).First;
    public ILocator ReferButton => _page.Locator("span.g-btn-text", new() { HasTextString = "Refer" }).First;
    public ILocator PopupOK => _page.FrameLocator("iframe[id^='dctPopup_dctPopupWindow']:visible >> nth=-1")
        .Locator("span.g-btn-text").Filter(new LocatorFilterOptions { HasTextRegex = new Regex(@"^\s*OK\s*$") }).First;
    public ILocator ReferOrRequestIssuance => _page.GetByText(new Regex("Refer|Request Issuance", RegexOptions.IgnoreCase)).First;
    public ILocator Approve => _page.GetByText("Approve", new() { Exact = true }).First;
    public ILocator CompleteIssuance => _page.GetByText("Complete Issuance", new() { Exact = false }).First;
    public ILocator CompleteApplication => _page.GetByText("Complete Application", new() { Exact = false }).First;
    public ILocator BackToAgent => _page.GetByText("Back to Agent", new() { Exact = false }).First;
    public ILocator RunStoplight => _page.GetByText(new Regex("Run Stoplight|Stoplight", RegexOptions.IgnoreCase)).First;
    public ILocator StoplightWindow => _page.Locator("#stoplightWaitingWindow");
    public ILocator PolicyNumber => _page.Locator("[fieldref='PolicyOutput.PolicyNumber'], [duckcreekid='Policy #:']").First;
    public ILocator Checklist => _page.GetByText("Checklist", new() { Exact = true }).First;
    public ILocator LaunchInspire => _page.GetByText("Launch Inspire", new() { Exact = false }).First;
    public ILocator ChecklistSummary => _page.GetByText("Checklist Summary", new() { Exact = false }).First;
    public ILocator LaunchToChecklist =>
        _page.Locator("[data-testid=\"fields.data.policy.launchToChecklist-button-label\"], a[href*='echecklist/launch']")
            .Filter(new LocatorFilterOptions { HasTextRegex = new Regex("Launch To Checklist|Checklist", RegexOptions.IgnoreCase) }).First;
    public ILocator ChecklistOpenedOK => _page.Locator("button#btnOk[data-testid=\"btnOk\"]");
    public ILocator ChecklistCurrentItemsHeading => _page.Locator("h4.pull-left").Filter(new LocatorFilterOptions { HasTextString = "Current Items" });
    public ILocator FirstChecklistItem => _page.Locator("table#summary-table tbody tr").First.Locator("a.checklist-summary-item").First;
    public ILocator ChecklistAddNote => _page.Locator("button#add-note.js-add-note");
    public ILocator ChecklistNoteTextArea => _page.Locator("textarea#note.js-note");
    public ILocator ChecklistValidFileTypesText => _page.Locator("p.text-info").Filter(new LocatorFilterOptions { HasTextString = "Valid File Types:" });
    public ILocator ChecklistDocumentDropzoneContainer => _page.Locator("div.js-document-content div#my-awesome-dropzone.dz-clickable");
    public ILocator ChecklistDocumentDropzoneMessage => _page.Locator("div.js-document-content div#my-awesome-dropzone.dz-clickable div.dz-message");
    public ILocator Exception => _page.Locator("button#exception.js-exception");
    public ILocator RequireNote => _page.Locator("textarea.js-require-note.require-note");
    public ILocator ExceptionNoteConfirmOK => _page.Locator("button#exception-note-confirm.js-exception-note-confirm").Filter(new LocatorFilterOptions { HasTextString = "OK" });
    public ILocator InspireHeader => _page.Locator("#ctl00_MainContent_pageHeader");
    public ILocator ConfirmBusinessOwnersHeader => _page.Locator("#ctl00_MainContent_pageHeader", new() { HasTextString = "Confirm Business Owners for Policy" });
    public ILocator ESubmitChecklistQuestion => _page.GetByText("Are you ready to submit items to eChecklist?", new() { Exact = false }).First;
    public ILocator ESubmitChecklistOK => _page.GetByText("OK", new() { Exact = true }).First;
    public ILocator ReturnToDashboard => _page.Locator("#_returnToDashboardButton-btnInnerEl");
    public ILocator ViewPolicy => _page.Locator("a#returnToActiveSessionA, a[id^='returnToActiveSession']").First;
    public ILocator ActivePolicyNumber => _page.Locator("[fieldref='PolicySummary.PolicyNumber']").First;
    public ILocator PolicyNumberLabel => _page.GetByText("Policy #:", new() { Exact = true }).First;
    public ILocator PolicyEffectiveDate => _page.Locator("[fieldref='PolicyInput.EffectiveDate']").First;
    public ILocator EffectiveDateLabel => _page.Locator("label", new() { HasTextString = "Effective Date" }).First;
    public ILocator PolicyInfo => _page.Locator("a[onclick*='MainInterview_PolicyDetail']", new() { HasTextString = "Policy Info" }).First;
    public ILocator InspireUsername => _page.GetByRole(AriaRole.Textbox, new PageGetByRoleOptions { NameRegex = new Regex("User ?Name|Username", RegexOptions.IgnoreCase) });
    public ILocator InspirePassword => _page.GetByRole(AriaRole.Textbox, new PageGetByRoleOptions { NameRegex = new Regex("Password", RegexOptions.IgnoreCase) });
    public ILocator InspireSignIn => _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { NameRegex = new Regex("Sign On|Sign In|Login", RegexOptions.IgnoreCase) });
}
