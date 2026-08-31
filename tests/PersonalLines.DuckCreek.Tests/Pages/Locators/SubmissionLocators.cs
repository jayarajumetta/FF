using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class SubmissionLocators
{
    private readonly IPage _page;
    public SubmissionLocators(IPage page) => _page = page;

    public ILocator AutoCycleRVApplication => _page.Locator("[id=\"Agent-Attention-Required\"]");

    public ILocator Button => _page.GetByText("Button", new() { Exact = true });

    public ILocator Caption => _page.GetByText("Caption", new() { Exact = true });

    public ILocator Checklist1 => _page.GetByText("Checklist_1", new() { Exact = true });

    public ILocator ChecklistCloseOk => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Ok", Exact = true });

    public ILocator Comments => _page.GetByText("Comments", new() { Exact = true });

    public ILocator CorrectionNeededStep1 => _page.Locator("div[id=\"Submission.Constant_Step1-0-layout\"]");

    public ILocator DIVAgentDocumentsCount => _page.GetByText("DIV_Agent Documents Count", new() { Exact = true });


    public ILocator DIVSubmission => _page.GetByLabel("DIV_Submission", new() { Exact = true });

    public ILocator EQCommonLoadingIndicatorWait => _page.GetByText("EQ |Common|Loading Indicator Wait", new() { Exact = true });

    public ILocator FilePath => _page.GetByText("FilePath", new() { Exact = true });

    public ILocator NewQuoteSearch => _page.Locator("input[id=\"quoteSearchInput\"][name=\"quoteSearchInput\"]");

    public ILocator PolicyNumber => _page.Locator("[id=\"PolicyOutput.PolicyNumber-0-layout\"]");

    public ILocator QuotePolicySearch => _page.Locator("[name=\"Txt_Quote\\\\Policy Search\"], [id=\"Txt_Quote\\\\Policy Search\"]").First;

    public ILocator ReferUW => _page.GetByText("ReferUW", new() { Exact = true });

    public ILocator SaveExit1 => _page.GetByText("SaveExit_1", new() { Exact = true });

    public ILocator Submission1 => _page.GetByText("Submission_1", new() { Exact = true });

    public ILocator Transmit => _page.GetByText("Transmit", new() { Exact = true });

    public ILocator TransmitConfirmation => _page.GetByLabel("Transmit Confirmation", new() { Exact = true });

}
