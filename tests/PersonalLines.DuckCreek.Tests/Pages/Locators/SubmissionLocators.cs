using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class SubmissionLocators
{
    private readonly IPage _page;
    public SubmissionLocators(IPage page) => _page = page;

    // Source modules: EQ||ECheckList | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||ECheckList | Agent-Attention-Required | Id
    public ILocator AutoCycleRVApplication => _page.Locator("[id=\"Agent-Attention-Required\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator Button => _page.GetByText("Button", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator Caption => _page.GetByText("Caption", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator Checklist1 => _page.GetByText("Checklist_1", new() { Exact = true });

    // Source modules: EQ|| Checklist Close | confidence=Medium score=113
    public ILocator ChecklistCloseOk => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Ok", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator Comments => _page.GetByText("Comments", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: EQ||Submission (NEW) | Correction Needed Step 1 | Id
    public ILocator CorrectionNeededStep1 => _page.Locator("[id=\"undefined\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator DIVAgentDocumentsCount => _page.GetByText("DIV_Agent Documents Count", new() { Exact = true });

    // Source modules: EQ||ECheckList | confidence=Medium score=114
    // v56 raw Tosca primary: EQ||ECheckList | Agent-Attention-Required | Id
    // v56 semantic alias: same physical raw-Tosca control as AutoCycleRVApplication
    public ILocator DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer => AutoCycleRVApplication;

    // Source modules: EQ||Auto Tabs | confidence=Medium score=108
    public ILocator DIVSubmission => _page.GetByLabel("DIV_Submission", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator EQCommonLoadingIndicatorWait => _page.GetByText("EQ |Common|Loading Indicator Wait", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator FilePath => _page.GetByText("FilePath", new() { Exact = true });

    // Source modules: EQ||New Quote | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||New Quote | Txt_Quote\Policy Search | Id+Name
    public ILocator NewQuoteSearch => _page.Locator("input[id=\"quoteSearchInput\"][name=\"quoteSearchInput\"]");

    // Source modules: EQ || Transmit Confirmation | confidence=High score=97
    // v56 raw Tosca primary: EQ || Transmit Confirmation | Policy Number | Id
    public ILocator PolicyNumber => _page.Locator("[id=\"PolicyOutput.PolicyNumber-0-layout\"]");

    // Source modules: EQ||New Quote | confidence=High score=127
    public ILocator QuotePolicySearch => _page.Locator("[name=\"Txt_Quote\\\\Policy Search\"], [id=\"Txt_Quote\\\\Policy Search\"]").First;

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ReferUW => _page.GetByText("ReferUW", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator SaveExit1 => _page.GetByText("SaveExit_1", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator Submission1 => _page.GetByText("Submission_1", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator Transmit => _page.GetByText("Transmit", new() { Exact = true });

    // Source modules: EQH||Side Menu and Quote Actions | confidence=Medium score=108
    public ILocator TransmitConfirmation => _page.GetByLabel("Transmit Confirmation", new() { Exact = true });

}
