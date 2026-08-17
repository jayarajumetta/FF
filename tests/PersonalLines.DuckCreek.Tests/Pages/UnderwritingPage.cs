using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class UnderwritingPage
{
    private readonly UnderwritingLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public UnderwritingPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new UnderwritingLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete prequalification
    public async Task CompletePrequalificationAsync()
    {
        // EQPreQualification_44547dPage.EnterPreQualification_0032_8f9ff6Async
        await _ui.ClickAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove);
        await _ui.PressAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove, "CLICK");
        await _ui.ClickAsync(_locators.PreQualificationNext);
        await _ui.PressAsync(_locators.PreQualificationNext, "CLICK");
    }

    // Business step: I complete driver information for txt quote policy search
    public async Task CompleteDriverInformationForTxtQuotePolicySearchAsync()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0044_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_87}}"));
        await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQPreQualification_44547dPage.EnterPreQualification_0045_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.PreQualificationNext))
        {
        await _ui.ClickAsync(_locators.PreQualificationNext);
        }
    }

    // Business step: I complete underwriting Page Cycle
    public async Task CompleteUnderwritingPageCycleAsync()
    {
        // EQCycleUnderwriting_8cc77fPage.EQCycleUnderwriting_0144_8f9ff6Async
        await _ui.WaitAsync(_locators.HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony, "Exists");
        await _ui.SelectAsync(_locators.No43938, _data.Resolve(""));
        await _ui.WaitAsync(_locators.IsAnyVintageCycleGaragedInADifferentLocation, "Exists");
        await _ui.SelectAsync(_locators.No1, _data.Resolve(""));
        await _ui.ClickAsync(_locators.CycleUnderwritingNext);
    }

    // Business step: I complete prequalification
    public async Task CompletePrequalificationAsync2()
    {
        // EQPreQualification_44547dPage.EnterPreQualification_0032_8f5301Async
        await _ui.ClickAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove);
        await _ui.PressAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove, "CLICK");
        await _ui.ClickAsync(_locators.PreQualificationNext);
        await _ui.PressAsync(_locators.PreQualificationNext, "CLICK");
    }

    // Business step: I complete driver information for txt quote policy search
    public async Task CompleteDriverInformationForTxtQuotePolicySearchAsync2()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0044_8f5301Async
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_87}}"));
        await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQPreQualification_44547dPage.EnterPreQualification_0045_8f5301Async
        if (await _ui.ExistsAsync(_locators.PreQualificationNext))
        {
        await _ui.ClickAsync(_locators.PreQualificationNext);
        }
    }

    // Business step: I complete underwriting Page Cycle
    public async Task CompleteUnderwritingPageCycleAsync2()
    {
        // EQCycleUnderwriting_8cc77fPage.EQCycleUnderwriting_0156_8f5301Async
        await _ui.WaitAsync(_locators.HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony, "Exists");
        await _ui.SelectAsync(_locators.No43938, _data.Resolve(""));
        await _ui.WaitAsync(_locators.IsAnyVintageCycleGaragedInADifferentLocation, "Exists");
        await _ui.SelectAsync(_locators.No1, _data.Resolve(""));
        await _ui.ClickAsync(_locators.CycleUnderwritingNext);
    }

    // Business step: I complete prequalification
    public async Task CompletePrequalificationAsync3()
    {
        // EQPreQualification_44547dPage.EnterPreQualification_0032_e2e0d7Async
        await _ui.ClickAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove);
        await _ui.PressAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove, "CLICK");
        await _ui.ClickAsync(_locators.PreQualificationNext);
        await _ui.PressAsync(_locators.PreQualificationNext, "CLICK");
    }

    // Business step: I complete driver information for txt quote policy search
    public async Task CompleteDriverInformationForTxtQuotePolicySearchAsync3()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0044_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_87}}"));
        await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQPreQualification_44547dPage.EnterPreQualification_0045_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.PreQualificationNext))
        {
        await _ui.ClickAsync(_locators.PreQualificationNext);
        }
    }

    // Business step: I complete underwriting Page Auto
    public async Task CompleteUnderwritingPageAutoAsync()
    {
        // EQUnderwritingEligibilityRestrictions_f7b4c9Page.EQUnderwritingEligibilityRestrictions_0153_e2e0d7Async
        await _ui.WaitAsync(_locators.HeaderUnderwriting, "Exists");
        await _ui.SelectAsync(_locators.Yes707BB, _data.Resolve(""));
        await _ui.ClickAsync(_locators.No77DAE);
        await _ui.PressAsync(_locators.No77DAE, "Click");
        await _ui.PressAsync(_locators.No77DAE, "end");
        // EQUnderwritingCollectorAndVintageInformation_2936bfPage.EQUnderwritingCollectorAndVintageInformation_0154_e2e0d7Async
        if (_data.Condition("EQ | Underwriting Collector And Vintage Information > Condition"))
        {
        await _ui.WaitAsync(_locators.AreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructure, "Visible");
        }
        // EQUnderwritingCollectorAndVintageInformation_2936bfPage.EQUnderwritingCollectorAndVintageInformation_0155_e2e0d7Async
        if (_data.Condition("EQ | Underwriting Collector And Vintage Information > Then"))
        {
        await _ui.SelectAsync(_locators.Yes71588, _data.Resolve(""));
        }
        // EQUnderwritingUnderwritingNext_00dbdfPage.EQUnderwritingUnderwritingNext_0156_e2e0d7Async
        await _ui.ClickAsync(_locators.UnderwritingUnderwritingNextNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0157_e2e0d7Async
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
    }

    // Business step: I complete prequalification
    public async Task CompletePrequalificationAsync4()
    {
        // EQPreQualification_44547dPage.EnterPreQualification_0032_bafd4aAsync
        await _ui.ClickAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove);
        await _ui.PressAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove, "CLICK");
        await _ui.ClickAsync(_locators.PreQualificationNext);
        await _ui.PressAsync(_locators.PreQualificationNext, "CLICK");
    }

    // Business step: I complete driver information for txt quote policy search
    public async Task CompleteDriverInformationForTxtQuotePolicySearchAsync4()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0044_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_87}}"));
        await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQPreQualification_44547dPage.EnterPreQualification_0045_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.PreQualificationNext))
        {
        await _ui.ClickAsync(_locators.PreQualificationNext);
        }
    }

    // Business step: I complete underwriting Page Auto
    public async Task CompleteUnderwritingPageAutoAsync2()
    {
        // EQUnderwritingEligibilityRestrictions_f7b4c9Page.EQUnderwritingEligibilityRestrictions_0153_bafd4aAsync
        await _ui.WaitAsync(_locators.HeaderUnderwriting, "Exists");
        await _ui.SelectAsync(_locators.Yes707BB, _data.Resolve(""));
        await _ui.ClickAsync(_locators.No77DAE);
        await _ui.PressAsync(_locators.No77DAE, "Click");
        await _ui.PressAsync(_locators.No77DAE, "end");
        // EQUnderwritingCollectorAndVintageInformation_2936bfPage.EQUnderwritingCollectorAndVintageInformation_0154_bafd4aAsync
        if (_data.Condition("EQ | Underwriting Collector And Vintage Information > Condition"))
        {
        await _ui.WaitAsync(_locators.AreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructure, "Visible");
        }
        // EQUnderwritingCollectorAndVintageInformation_2936bfPage.EQUnderwritingCollectorAndVintageInformation_0155_bafd4aAsync
        if (_data.Condition("EQ | Underwriting Collector And Vintage Information > Then"))
        {
        await _ui.SelectAsync(_locators.Yes71588, _data.Resolve(""));
        }
        // EQUnderwritingUnderwritingNext_00dbdfPage.EQUnderwritingUnderwritingNext_0156_bafd4aAsync
        await _ui.ClickAsync(_locators.UnderwritingUnderwritingNextNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0157_bafd4aAsync
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
    }

    // Business step: I complete prequalification
    public async Task CompletePrequalificationAsync5()
    {
        // EQPreQualification_44547dPage.EnterPreQualification_0032_8f4c8fAsync
        await _ui.ClickAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove);
        await _ui.PressAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove, "CLICK");
        await _ui.ClickAsync(_locators.PreQualificationNext);
        await _ui.PressAsync(_locators.PreQualificationNext, "CLICK");
    }

    // Business step: I complete driver information for txt quote policy search
    public async Task CompleteDriverInformationForTxtQuotePolicySearchAsync5()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0044_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_87}}"));
        await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQPreQualification_44547dPage.EnterPreQualification_0045_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.PreQualificationNext))
        {
        await _ui.ClickAsync(_locators.PreQualificationNext);
        }
    }

    // Business step: I complete underwriting Page Auto
    public async Task CompleteUnderwritingPageAutoAsync3()
    {
        // EQUnderwritingEligibilityRestrictions_f7b4c9Page.EQUnderwritingEligibilityRestrictions_0156_8f4c8fAsync
        await _ui.WaitAsync(_locators.HeaderUnderwriting, "Exists");
        await _ui.SelectAsync(_locators.Yes707BB, _data.Resolve(""));
        await _ui.ClickAsync(_locators.No77DAE);
        await _ui.PressAsync(_locators.No77DAE, "Click");
        await _ui.PressAsync(_locators.No77DAE, "end");
        // EQUnderwritingCollectorAndVintageInformation_2936bfPage.EQUnderwritingCollectorAndVintageInformation_0157_8f4c8fAsync
        if (_data.Condition("EQ | Underwriting Collector And Vintage Information > Condition"))
        {
        await _ui.WaitAsync(_locators.AreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructure, "Visible");
        }
        // EQUnderwritingCollectorAndVintageInformation_2936bfPage.EQUnderwritingCollectorAndVintageInformation_0158_8f4c8fAsync
        if (_data.Condition("EQ | Underwriting Collector And Vintage Information > Then"))
        {
        await _ui.SelectAsync(_locators.Yes71588, _data.Resolve(""));
        }
        // EQUnderwritingUnderwritingNext_00dbdfPage.EQUnderwritingUnderwritingNext_0159_8f4c8fAsync
        await _ui.ClickAsync(_locators.UnderwritingUnderwritingNextNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0160_8f4c8fAsync
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
    }

    // Business step: I complete prequalification
    public async Task CompletePrequalificationAsync6()
    {
        // EQPreQualification_44547dPage.EnterPreQualification_0032_10f911Async
        await _ui.ClickAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove);
        await _ui.PressAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove, "CLICK");
        await _ui.ClickAsync(_locators.PreQualificationNext);
        await _ui.PressAsync(_locators.PreQualificationNext, "CLICK");
    }

    // Business step: I complete driver information for txt quote policy search
    public async Task CompleteDriverInformationForTxtQuotePolicySearchAsync6()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0044_10f911Async
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_87}}"));
        await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQPreQualification_44547dPage.EnterPreQualification_0045_10f911Async
        if (await _ui.ExistsAsync(_locators.PreQualificationNext))
        {
        await _ui.ClickAsync(_locators.PreQualificationNext);
        }
    }

    // Business step: I complete underwriting Page Auto
    public async Task CompleteUnderwritingPageAutoAsync4()
    {
        // EQUnderwritingEligibilityRestrictions_f7b4c9Page.EQUnderwritingEligibilityRestrictions_0156_10f911Async
        await _ui.WaitAsync(_locators.HeaderUnderwriting, "Exists");
        await _ui.SelectAsync(_locators.Yes707BB, _data.Resolve(""));
        await _ui.ClickAsync(_locators.No77DAE);
        await _ui.PressAsync(_locators.No77DAE, "Click");
        await _ui.PressAsync(_locators.No77DAE, "end");
        // EQUnderwritingCollectorAndVintageInformation_2936bfPage.EQUnderwritingCollectorAndVintageInformation_0157_10f911Async
        if (_data.Condition("EQ | Underwriting Collector And Vintage Information > Condition"))
        {
        await _ui.WaitAsync(_locators.AreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructure, "Visible");
        }
        // EQUnderwritingCollectorAndVintageInformation_2936bfPage.EQUnderwritingCollectorAndVintageInformation_0158_10f911Async
        if (_data.Condition("EQ | Underwriting Collector And Vintage Information > Then"))
        {
        await _ui.SelectAsync(_locators.Yes71588, _data.Resolve(""));
        }
        // EQUnderwritingUnderwritingNext_00dbdfPage.EQUnderwritingUnderwritingNext_0159_10f911Async
        await _ui.ClickAsync(_locators.UnderwritingUnderwritingNextNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0160_10f911Async
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
    }

}