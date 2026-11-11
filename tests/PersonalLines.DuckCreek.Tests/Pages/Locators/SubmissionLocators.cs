using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class SubmissionLocators
{
    private readonly IPage _page;
    public SubmissionLocators(IPage page) => _page = page;

    public ILocator AutoCycleRVApplication => _page.Locator("[id=\"Agent-Attention-Required\"]");

    public ILocator AgentCommentFields => _page.Locator("input[data-testid^='fields.data.policy.uWRuleReview.rows['][data-testid$='].uWRuleReview$agentNote.value']:visible");


    public ILocator Button => _page.GetByText("Button", new() { Exact = true });

    public ILocator Caption => _page.GetByText("Caption", new() { Exact = true });

    public ILocator LaunchToChecklist => _page.Locator("[data-testid=\"fields.data.policy.launchToChecklist-button-label\"]").Filter(new LocatorFilterOptions { HasText = "Launch To Checklist" }).First;

    public ILocator ChecklistCloseOk => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Ok", Exact = true });

    public ILocator Comments => _page.GetByTestId("fields.data.policy.uWRuleReview.rows[0].uWRuleReview$agentNote.value");

    public ILocator CorrectionNeededStep1 => _page.Locator("div[id=\"Submission.Constant_Step1-0-layout\"]");

    public ILocator DIVAgentDocumentsCount => _page.GetByText("DIV_Agent Documents Count", new() { Exact = true });


    public ILocator DIVSubmission => _page.GetByLabel("DIV_Submission", new() { Exact = true });

    public ILocator EQCommonLoadingIndicatorWait => _page.GetByText("EQ |Common|Loading Indicator Wait", new() { Exact = true });

    public ILocator FilePath => _page.GetByText("FilePath", new() { Exact = true });

    public ILocator NewQuoteSearch => _page.Locator("input[id=\"quoteSearchInput\"][name=\"quoteSearchInput\"]");

    public ILocator PolicyNumber => _page.Locator("[id=\"PolicyOutput.PolicyNumber-0-layout\"]");

    public ILocator PolicyNumberValue => PolicyNumber.Locator("span.readonly-value-no-label").Nth(1);

    public ILocator QuotePolicySearch => _page.Locator("[name=\"Txt_Quote\\\\Policy Search\"], [id=\"Txt_Quote\\\\Policy Search\"]").First;

    public ILocator ReferUW => _page.GetByTestId("fields.data.policy.referToUW");

    public ILocator SaveExit1 => _page.GetByTestId("fields.data.saveandExit");

    public ILocator Submission1 => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Submission", Exact = true });

    public ILocator Transmit => _page.GetByTestId("fields.data.policy.bindProposal").GetByText("Transmit", new() { Exact = true });

    public ILocator TransmitConfirmation => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Transmit Confirmation" });

    public ILocator Lnk_Submission => _page.GetByTestId("Submission-nav").GetByText("  Submission ");

    public ILocator ChecklistOpenedOK => _page.Locator("button#btnOk[data-testid=\"btnOk\"]");
}
