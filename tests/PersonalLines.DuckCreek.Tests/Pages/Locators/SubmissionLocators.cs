using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class SubmissionLocators
{
    private readonly IPage _page;
    public SubmissionLocators(IPage page) => _page = page;

    // Source modules: EQ||ECheckList | confidence=Medium score=113
    public ILocator AutoCycleRVApplication => _page.GetByRole(AriaRole.Link, new() { Name = "Lnk_Auto/Cycle/RV Application", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Button => _page.GetByText("Button", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Caption => _page.GetByText("Caption", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Checklist1 => _page.GetByText("Checklist_1", new() { Exact = true });

    // Source modules: EQ|| Checklist Close | confidence=Medium score=113
    public ILocator ChecklistCloseOk => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Ok", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Comments => _page.GetByText("Comments", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator CorrectionNeededStep1 => _page.GetByText("Correction Needed Step 1", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator DIVAgentDocumentsCount => _page.GetByText("DIV_Agent Documents Count", new() { Exact = true });

    // Source modules: EQ||ECheckList | confidence=Medium score=114
    public ILocator DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer => _page.GetByLabel("Drag and Drop files here to upload (or click here to open a file explorer)", new() { Exact = true });

    // Source modules: EQ||Auto Tabs | confidence=Medium score=108
    public ILocator DIVSubmission => _page.GetByLabel("DIV_Submission", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EQCommonLoadingIndicatorWait => _page.GetByText("EQ |Common|Loading Indicator Wait", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator FilePath => _page.GetByText("FilePath", new() { Exact = true });

    // Source modules: EQ||New Quote | confidence=Medium score=113
    public ILocator NewQuoteSearch => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Search", Exact = true });

    // Source modules: EQ || Transmit Confirmation | confidence=High score=97
    public ILocator PolicyNumber => _page.GetByLabel("Policy Number", new() { Exact = true });

    // Source modules: EQ||New Quote | confidence=High score=127
    public ILocator QuotePolicySearch => _page.Locator("[name=\"Txt_Quote\\\\Policy Search\"], [id=\"Txt_Quote\\\\Policy Search\"]").First;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ReferUW => _page.GetByText("ReferUW", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SaveExit1 => _page.GetByText("SaveExit_1", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Submission1 => _page.GetByText("Submission_1", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Transmit => _page.GetByText("Transmit", new() { Exact = true });

    // Source modules: EQH||Side Menu and Quote Actions | confidence=Medium score=108
    public ILocator TransmitConfirmation => _page.GetByLabel("Transmit Confirmation", new() { Exact = true });

}
