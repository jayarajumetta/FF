using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class PolicyWorkflowPage
{
    private readonly BrowserSession _browser;
    private readonly IPage _page;
    private readonly PolicyWorkflowLocators _locators;
    private readonly UiActions _ui;

    public PolicyWorkflowPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _page = browser.Page;
        _locators = new PolicyWorkflowLocators(browser.Page);
        _ui = ui;
    }

    public Task WaitForAddEditAdditionalInterestFirstMortgageeSearchAsync(string expected) =>
        _ui.WaitAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch, expected, new ControlIntent("PolicyWorkflow", "AddEditAdditionalInterestFirstMortgageeSearch"));

    public Task ClickAddEditAdditionalInterestFirstMortgageeSearchAsync() =>
        _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch, new ControlIntent("PolicyWorkflow", "AddEditAdditionalInterestFirstMortgageeSearch"));

    public Task WaitForSearchTextAsync(string expected) =>
        _ui.WaitAsync(_locators.SearchText, expected, new ControlIntent("PolicyWorkflow", "SearchText"));

    public Task EnterSearchTextAsync(string value) =>
        _ui.FillAsync(_locators.SearchText, value, new ControlIntent("PolicyWorkflow", "SearchText"));

    public Task PressSearchTextAsync(string key) =>
        _ui.PressAsync(_locators.SearchText, key, new ControlIntent("PolicyWorkflow", "SearchText"));

    public Task EnterSearchTextSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SearchText, value, new ControlIntent("PolicyWorkflow", "SearchText"), delayMs);

    public Task WaitForQuickSearchButtonAsync(string expected) =>
        _ui.WaitAsync(_locators.QuickSearchButton, expected, new ControlIntent("PolicyWorkflow", "QuickSearchButton"));

    public Task ClickQuickSearchButtonAsync() =>
        _ui.ClickAsync(_locators.QuickSearchButton, new ControlIntent("PolicyWorkflow", "QuickSearchButton"));

    public Task WaitForSearchMethodEGDescriptionPolicyAsync(string expected) =>
        _ui.WaitAsync(_locators.SearchMethodEGDescriptionPolicy, expected, new ControlIntent("PolicyWorkflow", "SearchMethodEGDescriptionPolicy"));

    public Task EnterSearchMethodEGDescriptionPolicyAsync(string value) =>
        _ui.FillAsync(_locators.SearchMethodEGDescriptionPolicy, value, new ControlIntent("PolicyWorkflow", "SearchMethodEGDescriptionPolicy"));

    public Task PressSearchMethodEGDescriptionPolicyAsync(string key) =>
        _ui.PressAsync(_locators.SearchMethodEGDescriptionPolicy, key, new ControlIntent("PolicyWorkflow", "SearchMethodEGDescriptionPolicy"));

    public Task EnterSearchMethodEGDescriptionPolicySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SearchMethodEGDescriptionPolicy, value, new ControlIntent("PolicyWorkflow", "SearchMethodEGDescriptionPolicy"), delayMs);

    public Task WaitForSearchButtonAsync(string expected) =>
        _ui.WaitAsync(_locators.SearchButton, expected, new ControlIntent("PolicyWorkflow", "SearchButton"));

    public Task ClickSearchButtonAsync() =>
        _ui.ClickAsync(_locators.SearchButton, new ControlIntent("PolicyWorkflow", "SearchButton"));

    public Task WaitForSearchResultsInsuredNameColumnHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.SearchResultsInsuredNameColumnHeader, expected, new ControlIntent("PolicyWorkflow", "SearchResultsInsuredNameColumnHeader"));

    public Task ClickSearchResultInsuredNameLinkAsync() =>
        _ui.ClickAsync(_locators.SearchResultInsuredNameLink, new ControlIntent("PolicyWorkflow", "SearchResultInsuredNameLink"));

    public Task WaitForCommercialAutoQuoteLinkAsync(string expected) =>
        _ui.WaitAsync(_locators.CommercialAutoQuoteLink, expected, new ControlIntent("PolicyWorkflow", "CommercialAutoQuoteLink"));

    public Task ClickCommercialAutoQuoteLinkAsync() =>
        _ui.ClickAsync(_locators.CommercialAutoQuoteLink, new ControlIntent("PolicyWorkflow", "CommercialAutoQuoteLink"));

    public Task ClickAdditionalDeathBenefitAsync() =>
        _ui.ClickAsync(_locators.AdditionalDeathBenefit, new ControlIntent("PolicyWorkflow", "AdditionalDeathBenefit"));

    public Task ClickAdditionalPIPAsync() =>
        _ui.ClickAsync(_locators.AdditionalPIP, new ControlIntent("PolicyWorkflow", "AdditionalPIP"));

    public Task ClickAutoHealthInsurerAsync() =>
        _ui.ClickAsync(_locators.AutoHealthInsurer, new ControlIntent("PolicyWorkflow", "AutoHealthInsurer"));

    public Task ClickBroadenedPIPAsync() =>
        _ui.ClickAsync(_locators.BroadenedPIP, new ControlIntent("PolicyWorkflow", "BroadenedPIP"));

    public Task WaitForBtnCreateNewClientAsync(string expected) =>
        _ui.WaitAsync(_locators.BtnCreateNewClient, expected, new ControlIntent("PolicyWorkflow", "BtnCreateNewClient"));

    public Task ClickBtnCreateNewClientAsync() =>
        _ui.ClickAsync(_locators.BtnCreateNewClient, new ControlIntent("PolicyWorkflow", "BtnCreateNewClient"));

    public Task SelectExtraPIPOptionAsync(string value) =>
        _ui.SelectAsync(_locators.ExtraPIPOption, value, new ControlIntent("PolicyWorkflow", "ExtraPIPOption"));

    public Task ClickHouseholdMembersAge65OrReceivingPensionAsync() =>
        _ui.ClickAsync(_locators.HouseholdMembersAge65OrReceivingPension, new ControlIntent("PolicyWorkflow", "HouseholdMembersAge65OrReceivingPension"));

    public Task WaitForLblClientInfoAsync(string expected) =>
        _ui.WaitAsync(_locators.LblClientInfo, expected, new ControlIntent("PolicyWorkflow", "LblClientInfo"));

    public Task VerifyLblClientInfoAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LblClientInfo, expected, property, new ControlIntent("PolicyWorkflow", "LblClientInfo"));

    public Task ClickMedicalExpenseEliminationAsync() =>
        _ui.ClickAsync(_locators.MedicalExpenseElimination, new ControlIntent("PolicyWorkflow", "MedicalExpenseElimination"));

    public Task ClickPIPDeductibleAsync() =>
        _ui.ClickAsync(_locators.PIPDeductible, new ControlIntent("PolicyWorkflow", "PIPDeductible"));

    public Task ClickPIPLimitAsync() =>
        _ui.ClickAsync(_locators.PIPLimit, new ControlIntent("PolicyWorkflow", "PIPLimit"));

    public Task ClickPIPStackingAsync() =>
        _ui.ClickAsync(_locators.PIPStacking, new ControlIntent("PolicyWorkflow", "PIPStacking"));

    public Task ClickPricingDetailsNextAsync() =>
        _ui.ClickAsync(_locators.PricingDetailsNext, new ControlIntent("PolicyWorkflow", "PricingDetailsNext"));

    public Task EnterTxtFirstAsync(string value) =>
        _ui.FillAsync(_locators.TxtFirst, value, new ControlIntent("PolicyWorkflow", "TxtFirst"));

    public Task EnterTxtLastAsync(string value) =>
        _ui.FillAsync(_locators.TxtLast, value, new ControlIntent("PolicyWorkflow", "TxtLast"));

    public Task ClickWaiverOfIncomeLossAsync() =>
        _ui.ClickAsync(_locators.WaiverOfIncomeLoss, new ControlIntent("PolicyWorkflow", "WaiverOfIncomeLoss"));

    public Task SelectWorkLossNoAsync(string value) =>
        _ui.SelectAsync(_locators.WorkLossNo, value, new ControlIntent("PolicyWorkflow", "WorkLossNo"));

    public Task<bool> IsHouseholdMembersAge65OrReceivingPensionPresentAsync() =>
        _ui.ExistsAsync(_locators.HouseholdMembersAge65OrReceivingPension);

    public Task<bool> IsPIPLimitPresentAsync() =>
        _ui.ExistsAsync(_locators.PIPLimit);

    public Task<bool> IsPIPDeductiblePresentAsync() =>
        _ui.ExistsAsync(_locators.PIPDeductible);

    public Task<bool> IsAdditionalPIPPresentAsync() =>
        _ui.ExistsAsync(_locators.AdditionalPIP);

    public Task<bool> IsPIPStackingPresentAsync() =>
        _ui.ExistsAsync(_locators.PIPStacking);

    public Task<bool> IsExtraPIPOptionPresentAsync() =>
        _ui.ExistsAsync(_locators.ExtraPIPOption);

    public Task<bool> IsAutoHealthInsurerPresentAsync() =>
        _ui.ExistsAsync(_locators.AutoHealthInsurer);

    public Task<bool> IsMedicalExpenseEliminationPresentAsync() =>
        _ui.ExistsAsync(_locators.MedicalExpenseElimination);

    public Task<bool> IsWorkLossNoPresentAsync() =>
        _ui.ExistsAsync(_locators.WorkLossNo);

    public Task<bool> IsBroadenedPIPPresentAsync() =>
        _ui.ExistsAsync(_locators.BroadenedPIP);

    public Task<bool> IsAdditionalDeathBenefitPresentAsync() =>
        _ui.ExistsAsync(_locators.AdditionalDeathBenefit);

    public Task<bool> IsWaiverOfIncomeLossPresentAsync() =>
        _ui.ExistsAsync(_locators.WaiverOfIncomeLoss);

    public Task NavigateAsync(string url) =>
        _page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });

}
