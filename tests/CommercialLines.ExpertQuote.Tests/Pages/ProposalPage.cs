using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class ProposalPage
{
    private readonly ProposalLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public ProposalPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new ProposalLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I start the policy proposal
    public async Task StartThePolicyProposalAsync()
    {
        // EQCommonProposalStart_9a6df5Page.ProposalStart_0039_503012Async
        await _ui.WaitAsync(_locators.ProposalDetailsHeader, "Visible");
        await _ui.SelectAsync(_locators.SpecialFarmPackage, _data.Resolve(""));
        await _ui.ClickAsync(_locators.SelectSFPCE);
        await _ui.PressAsync(_locators.EffectiveDate78F67, "POST:ENTER");
        await _ui.PressAsync(_locators.EffectiveDate78F67, "Enter");
        await _ui.PressAsync(_locators.EffectiveDate78F67, "Tab");
        await _ui.FillAsync(_locators.True, _data.Resolve("{{data:true_35}}"));
        await _ui.PressAsync(_locators.PolicyTerm, "POST:TAB");
        await _ui.PressAsync(_locators.PolicyTerm, "Tab");
        await _ui.FillAsync(_locators.PolicyTerm, _data.Resolve("{{data:policyterm_37}}"));
        await _ui.PressAsync(_locators.PolicyTerm, "POST:TAB");
        await _ui.PressAsync(_locators.PolicyTerm, "Tab");
        await _ui.PressAsync(_locators.StateDropdown, "POST:TAB");
        await _ui.PressAsync(_locators.StateDropdown, "Tab");
        await _ui.SelectAsync(_locators.State, _data.Resolve("{{runtime:StateName}}"));
        await _ui.PressAsync(_locators.AgentPC, "POST:ENTER");
        await _ui.PressAsync(_locators.AgentPC, "Enter");
        await _ui.PressAsync(_locators.AgentPC, "Tab");
        _data.Set("EffDate", await _ui.CaptureAsync(_locators.EffectiveDate78F67, "InnerText"));
        await _ui.ClickAsync(_locators.StateDropdown);
        await _ui.ClickAsync(_locators.StartQuote);
        // EQCommonProposalStart_9a6df5Page.SetBufferForLOB_0040_503012Async
        _data.Set("LOB", _data.Resolve("{{data:lob}}"));
    }

    // Business step: I start the policy proposal
    public async Task StartThePolicyProposalAsync2()
    {
        // EQCommonProposalStart_9a6df5Page.ProposalStart_0039_656be2Async
        await _ui.WaitAsync(_locators.ProposalDetailsHeader, "Visible");
        await _ui.SelectAsync(_locators.SpecialFarmPackage, _data.Resolve(""));
        await _ui.PressAsync(_locators.EffectiveDate78F67, "POST:ENTER");
        await _ui.PressAsync(_locators.EffectiveDate78F67, "Enter");
        await _ui.PressAsync(_locators.EffectiveDate78F67, "Tab");
        await _ui.FillAsync(_locators.True, _data.Resolve("{{data:true_34}}"));
        await _ui.PressAsync(_locators.PolicyTerm, "POST:TAB");
        await _ui.PressAsync(_locators.PolicyTerm, "Tab");
        await _ui.FillAsync(_locators.PolicyTerm, _data.Resolve("{{data:policyterm_36}}"));
        await _ui.PressAsync(_locators.PolicyTerm, "POST:TAB");
        await _ui.PressAsync(_locators.PolicyTerm, "Tab");
        await _ui.PressAsync(_locators.StateDropdown, "POST:TAB");
        await _ui.PressAsync(_locators.StateDropdown, "Tab");
        await _ui.SelectAsync(_locators.State, _data.Resolve("{{runtime:StateName}}"));
        await _ui.PressAsync(_locators.AgentPC, "POST:ENTER");
        await _ui.PressAsync(_locators.AgentPC, "Enter");
        await _ui.PressAsync(_locators.AgentPC, "Tab");
        _data.Set("EffDate", await _ui.CaptureAsync(_locators.EffectiveDate78F67, "InnerText"));
        await _ui.ClickAsync(_locators.StateDropdown);
        await _ui.ClickAsync(_locators.StartQuote);
        // EQCommonProposalStart_9a6df5Page.SetBufferForLOB_0040_656be2Async
        _data.Set("LOB", _data.Resolve("{{data:lob}}"));
        // EQCommonProposalStart_9a6df5Page.SetBufferForWaitOnTime_0041_656be2Async
        _data.Set("WaitOnTime", _data.Resolve("{{data:waitontime}}"));
    }

    // Business step: I start the policy proposal
    public async Task StartThePolicyProposalAsync3()
    {
        // EQCommonProposalStart_9a6df5Page.ProposalStart_0039_d18a3eAsync
        await _ui.WaitAsync(_locators.ProposalDetailsHeader, "Visible");
        await _ui.SelectAsync(_locators.BusinessOwners, _data.Resolve(""));
        await _ui.PressAsync(_locators.SearchBusinessName, "POST:TAB");
        await _ui.PressAsync(_locators.SearchBusinessName, "Tab");
        await _ui.ClickAsync(_locators.IndividuallyOwnedDBAOrTA);
        await _ui.FillAsync(_locators.IndividualDBA, _data.Resolve("{{data:individual_dba_35}}"));
        await _ui.PressAsync(_locators.EffectiveDate78F67, "POST:ENTER");
        await _ui.PressAsync(_locators.EffectiveDate78F67, "Enter");
        await _ui.PressAsync(_locators.EffectiveDate78F67, "Tab");
        await _ui.FillAsync(_locators.True, _data.Resolve("{{data:true_37}}"));
        await _ui.SelectAsync(_locators.LessorsRiskNo, _data.Resolve(""));
        await _ui.PressAsync(_locators.StateDropdown, "POST:TAB");
        await _ui.PressAsync(_locators.StateDropdown, "Tab");
        await _ui.SelectAsync(_locators.State, _data.Resolve("{{runtime:StateName}}"));
        await _ui.PressAsync(_locators.AgentPC, "POST:ENTER");
        await _ui.PressAsync(_locators.AgentPC, "Enter");
        await _ui.PressAsync(_locators.AgentPC, "Tab");
        _data.Set("EffDate", await _ui.CaptureAsync(_locators.EffectiveDate78F67, "InnerText"));
        await _ui.ClickAsync(_locators.StateDropdown);
        await _ui.ClickAsync(_locators.StartQuote);
        // EQCommonProposalStart_9a6df5Page.SetBufferForLOB_0040_d18a3eAsync
        _data.Set("LOB", _data.Resolve("{{data:lob}}"));
    }

    // Business step: I start the configured policy proposal
    public async Task StartTheConfiguredPolicyProposalAsync()
    {
        // Common_7de90aPage.ProposalCreationData_00390040_8fa692Async
        await _ui.VerifyAsync(_locators.ProposalDetails, _data.Resolve("Visible"), "");
        await _ui.ClickAsync(_locators.BusinessOwners);
        await _ui.PressAsync(_locators.SearchBusinessName, "POST:ENTER");
        await _ui.PressAsync(_locators.SearchBusinessName, "Enter");
        await _ui.FillAsync(_locators.Individual, _data.Resolve("{{data:individual_31}}"));
        await _ui.ClickAsync(_locators.IndividuallyOwnedDBAOrTA);
        await _ui.FillAsync(_locators.IndividualDBA, _data.Resolve("{{data:individual_dba}}"));
        await _ui.FillAsync(_locators.EffectiveDate6F16B, _data.Resolve("{{data:effective_date}}"));
        await _ui.SmartSetAsync(_locators.NewAccountAddress, _data.Resolve("{{data:new_account_address}}"));
        await _ui.ClickAsync(_locators.No);
        await _ui.SelectAsync(_locators.Missouri, _data.Resolve(""));
        await _ui.FillAsync(_locators.AgentPC, _data.Resolve("{{data:agentpc}}"));
        _data.Set("EffDate", await _ui.CaptureAsync(_locators.EffectiveDate6F16B, "Value"));
        await _ui.ClickAsync(_locators.StartQuote);
        _data.Set("LOB", _data.Resolve("{{data:line_of_business}}"));
    }

    // Business step: I start the policy proposal
    public async Task StartThePolicyProposalAsync4()
    {
        // EQCommonProposalStart_9a6df5Page.ProposalStart_0039_08f3f1Async
        await _ui.WaitAsync(_locators.ProposalDetailsHeader, "Visible");
        await _ui.SelectAsync(_locators.SpecialFarmPackage, _data.Resolve(""));
        await _ui.PressAsync(_locators.EffectiveDate78F67, "POST:ENTER");
        await _ui.PressAsync(_locators.EffectiveDate78F67, "Enter");
        await _ui.PressAsync(_locators.EffectiveDate78F67, "Tab");
        await _ui.FillAsync(_locators.True, _data.Resolve("{{data:true_34}}"));
        await _ui.PressAsync(_locators.PolicyTerm, "POST:TAB");
        await _ui.PressAsync(_locators.PolicyTerm, "Tab");
        await _ui.FillAsync(_locators.PolicyTerm, _data.Resolve("{{data:policyterm_36}}"));
        await _ui.PressAsync(_locators.PolicyTerm, "POST:TAB");
        await _ui.PressAsync(_locators.PolicyTerm, "Tab");
        await _ui.PressAsync(_locators.StateDropdown, "POST:TAB");
        await _ui.PressAsync(_locators.StateDropdown, "Tab");
        await _ui.SelectAsync(_locators.State, _data.Resolve("{{runtime:StateName}}"));
        await _ui.PressAsync(_locators.AgentPC, "POST:ENTER");
        await _ui.PressAsync(_locators.AgentPC, "Enter");
        await _ui.PressAsync(_locators.AgentPC, "Tab");
        _data.Set("EffDate", await _ui.CaptureAsync(_locators.EffectiveDate78F67, "InnerText"));
        await _ui.ClickAsync(_locators.StateDropdown);
        await _ui.ClickAsync(_locators.StartQuote);
        // EQCommonProposalStart_9a6df5Page.SetBufferForLOB_0040_08f3f1Async
        _data.Set("LOB", _data.Resolve("{{data:lob}}"));
    }

}
