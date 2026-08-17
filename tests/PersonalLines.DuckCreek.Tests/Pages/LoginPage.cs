using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class LoginPage
{
    private readonly LoginLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public LoginPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new LoginLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I approve Level 9B
    public async Task ApproveLevel9BAsync()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0037_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0038_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_76}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0039_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0040_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        // EUApplicant_093167Page.EUApplicant_0041_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.BypassLevel9BRules))
        {
        await _ui.SmartSetAsync(_locators.BypassLevel9BRules, _data.Resolve("{{data:bypass_level_9b_rules_83}}"));
        }
        await _ui.FillAsync(_locators.BypassLevel9BRulesComments, _data.Resolve("{{data:bypass_level_9b_rules_comments_84}}"));
        await _ui.PressAsync(_locators.BypassLevel9BRulesComments, "Click");
        await _ui.ClickAsync(_locators.Home);
    }

    // Business step: I complete the Express underwriting review
    public async Task CompleteTheExpressUnderwritingReviewAsync()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0176_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0177_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_537}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0178_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0179_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        // EUApplicant_093167Page.EUApplicant_0180_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.LnkPricing))
        {
        await _ui.ClickAsync(_locators.LnkPricing);
        }
        // EUPricing_3ae83cPage.EUPricing_0181_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.TxtUnderwritingNotes))
        {
        await _ui.WaitAsync(_locators.TxtUnderwritingNotes, "True");
        }
        await _ui.FillAsync(_locators.TxtUnderwritingNotes, _data.Resolve("{{data:txt_underwriting_notes_546}}"));
        await _ui.PressAsync(_locators.TxtUnderwritingNotes, "Click");
        await _ui.WaitAsync(_locators.BtnApprove, "Visible");
        await _ui.ClickAsync(_locators.BtnApprove);
        await _ui.ClickAsync(_locators.LnkHome);
    }

    // Business step: I approve the underwriting referral in Express
    public async Task ApproveTheUnderwritingReferralInExpressAsync()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0194_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0195_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_560}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0196_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0197_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        if (_data.Condition("MotorCycle != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkMotorcycle);
        }
        if (_data.Condition("PersonalAuto != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkPersonalAuto);
        }
        if (_data.Condition("RV != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkRV);
        }
        // EUApplicant_093167Page.EUApplicant_0198_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.LnkPricing))
        {
        await _ui.ClickAsync(_locators.LnkPricing);
        }
        // EUPricing_3ae83cPage.EUPricing_0199_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.SmartSetAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("{{data:chkbox_bypass_level_9_rules_571}}"));
        }
        await _ui.ClickAsync(_locators.BypassLevel9Comments1);
        await _ui.FillAsync(_locators.BypassLevel9Comments1, _data.Resolve("{{data:bypass_level_9_comments_1_573}}"));
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "POST:TAB");
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "Tab");
        await _ui.ClickAsync(_locators.LnkHome);
        // EUPricing_3ae83cPage.EUPricing_0200_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.VerifyAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("True"), "Enabled");
        }
        // EUPricing_3ae83cPage.EUPricing_0201_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.SmartSetAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("{{data:chkbox_bypass_level_9_rules_577}}"));
        }
        await _ui.ClickAsync(_locators.BypassLevel9Comments1);
        await _ui.FillAsync(_locators.BypassLevel9Comments1, _data.Resolve("{{data:bypass_level_9_comments_1_579}}"));
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "POST:TAB");
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "Tab");
        await _ui.ClickAsync(_locators.LnkHome);
    }

    // Business step: I approve Level 9B
    public async Task ApproveLevel9BAsync2()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0037_8f5301Async
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0038_8f5301Async
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_76}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0039_8f5301Async
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0040_8f5301Async
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        // EUApplicant_093167Page.EUApplicant_0041_8f5301Async
        if (await _ui.ExistsAsync(_locators.BypassLevel9BRules))
        {
        await _ui.SmartSetAsync(_locators.BypassLevel9BRules, _data.Resolve("{{data:bypass_level_9b_rules_83}}"));
        }
        await _ui.FillAsync(_locators.BypassLevel9BRulesComments, _data.Resolve("{{data:bypass_level_9b_rules_comments_84}}"));
        await _ui.PressAsync(_locators.BypassLevel9BRulesComments, "Click");
        await _ui.ClickAsync(_locators.Home);
    }

    // Business step: I complete the Express underwriting review
    public async Task CompleteTheExpressUnderwritingReviewAsync2()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0188_8f5301Async
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0189_8f5301Async
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_588}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0190_8f5301Async
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0191_8f5301Async
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        // EUApplicant_093167Page.EUApplicant_0192_8f5301Async
        if (await _ui.ExistsAsync(_locators.LnkPricing))
        {
        await _ui.ClickAsync(_locators.LnkPricing);
        }
        // EUPricing_3ae83cPage.EUPricing_0193_8f5301Async
        if (await _ui.ExistsAsync(_locators.TxtUnderwritingNotes))
        {
        await _ui.WaitAsync(_locators.TxtUnderwritingNotes, "True");
        }
        await _ui.FillAsync(_locators.TxtUnderwritingNotes, _data.Resolve("{{data:txt_underwriting_notes_597}}"));
        await _ui.PressAsync(_locators.TxtUnderwritingNotes, "Click");
        await _ui.WaitAsync(_locators.BtnApprove, "Visible");
        await _ui.ClickAsync(_locators.BtnApprove);
        await _ui.ClickAsync(_locators.LnkHome);
    }

    // Business step: I approve Level 9B
    public async Task ApproveLevel9BAsync3()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0037_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0038_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_76}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0039_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0040_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        // EUApplicant_093167Page.EUApplicant_0041_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.BypassLevel9BRules))
        {
        await _ui.SmartSetAsync(_locators.BypassLevel9BRules, _data.Resolve("{{data:bypass_level_9b_rules_83}}"));
        }
        await _ui.FillAsync(_locators.BypassLevel9BRulesComments, _data.Resolve("{{data:bypass_level_9b_rules_comments_84}}"));
        await _ui.PressAsync(_locators.BypassLevel9BRulesComments, "Click");
        await _ui.ClickAsync(_locators.Home);
    }

    // Business step: I approve the underwriting referral in Express
    public async Task ApproveTheUnderwritingReferralInExpressAsync2()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0171_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0172_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_568}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0173_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0174_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        if (_data.Condition("MotorCycle != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkMotorcycle);
        }
        if (_data.Condition("PersonalAuto != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkPersonalAuto);
        }
        if (_data.Condition("RV != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkRV);
        }
        // EUApplicant_093167Page.EUApplicant_0175_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.LnkPricing))
        {
        await _ui.ClickAsync(_locators.LnkPricing);
        }
        // EUPricing_3ae83cPage.EUPricing_0176_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.SmartSetAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("{{data:chkbox_bypass_level_9_rules_579}}"));
        }
        await _ui.ClickAsync(_locators.BypassLevel9Comments1);
        await _ui.FillAsync(_locators.BypassLevel9Comments1, _data.Resolve("{{data:bypass_level_9_comments_1_581}}"));
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "POST:TAB");
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "Tab");
        await _ui.ClickAsync(_locators.LnkHome);
        // EUPricing_3ae83cPage.EUPricing_0177_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.VerifyAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("True"), "Enabled");
        }
        // EUPricing_3ae83cPage.EUPricing_0178_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.SmartSetAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("{{data:chkbox_bypass_level_9_rules_585}}"));
        }
        await _ui.ClickAsync(_locators.BypassLevel9Comments1);
        await _ui.FillAsync(_locators.BypassLevel9Comments1, _data.Resolve("{{data:bypass_level_9_comments_1_587}}"));
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "POST:TAB");
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "Tab");
        await _ui.ClickAsync(_locators.LnkHome);
    }

    // Business step: I complete the Express underwriting review
    public async Task CompleteTheExpressUnderwritingReviewAsync3()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0244_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0245_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_605}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0246_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0247_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        // EUApplicant_093167Page.EUApplicant_0248_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.LnkPricing))
        {
        await _ui.ClickAsync(_locators.LnkPricing);
        }
        // EUPricing_3ae83cPage.EUPricing_0249_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.TxtUnderwritingNotes))
        {
        await _ui.WaitAsync(_locators.TxtUnderwritingNotes, "True");
        }
        await _ui.FillAsync(_locators.TxtUnderwritingNotes, _data.Resolve("{{data:txt_underwriting_notes_614}}"));
        await _ui.PressAsync(_locators.TxtUnderwritingNotes, "Click");
        await _ui.WaitAsync(_locators.BtnApprove, "Visible");
        await _ui.ClickAsync(_locators.BtnApprove);
        await _ui.ClickAsync(_locators.LnkHome);
    }

    // Business step: I approve Level 9B
    public async Task ApproveLevel9BAsync4()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0037_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0038_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_76}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0039_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0040_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        // EUApplicant_093167Page.EUApplicant_0041_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.BypassLevel9BRules))
        {
        await _ui.SmartSetAsync(_locators.BypassLevel9BRules, _data.Resolve("{{data:bypass_level_9b_rules_83}}"));
        }
        await _ui.FillAsync(_locators.BypassLevel9BRulesComments, _data.Resolve("{{data:bypass_level_9b_rules_comments_84}}"));
        await _ui.PressAsync(_locators.BypassLevel9BRulesComments, "Click");
        await _ui.ClickAsync(_locators.Home);
    }

    // Business step: I approve the underwriting referral in Express
    public async Task ApproveTheUnderwritingReferralInExpressAsync3()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0171_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0172_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_568}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0173_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0174_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        if (_data.Condition("MotorCycle != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkMotorcycle);
        }
        if (_data.Condition("PersonalAuto != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkPersonalAuto);
        }
        if (_data.Condition("RV != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkRV);
        }
        // EUApplicant_093167Page.EUApplicant_0175_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.LnkPricing))
        {
        await _ui.ClickAsync(_locators.LnkPricing);
        }
        // EUPricing_3ae83cPage.EUPricing_0176_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.SmartSetAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("{{data:chkbox_bypass_level_9_rules_579}}"));
        }
        await _ui.ClickAsync(_locators.BypassLevel9Comments1);
        await _ui.FillAsync(_locators.BypassLevel9Comments1, _data.Resolve("{{data:bypass_level_9_comments_1_581}}"));
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "POST:TAB");
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "Tab");
        await _ui.ClickAsync(_locators.LnkHome);
        // EUPricing_3ae83cPage.EUPricing_0177_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.VerifyAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("True"), "Enabled");
        }
        // EUPricing_3ae83cPage.EUPricing_0178_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.SmartSetAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("{{data:chkbox_bypass_level_9_rules_585}}"));
        }
        await _ui.ClickAsync(_locators.BypassLevel9Comments1);
        await _ui.FillAsync(_locators.BypassLevel9Comments1, _data.Resolve("{{data:bypass_level_9_comments_1_587}}"));
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "POST:TAB");
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "Tab");
        await _ui.ClickAsync(_locators.LnkHome);
    }

    // Business step: I complete the Express underwriting review
    public async Task CompleteTheExpressUnderwritingReviewAsync4()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0244_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0245_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_605}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0246_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0247_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        // EUApplicant_093167Page.EUApplicant_0248_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.LnkPricing))
        {
        await _ui.ClickAsync(_locators.LnkPricing);
        }
        // EUPricing_3ae83cPage.EUPricing_0249_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.TxtUnderwritingNotes))
        {
        await _ui.WaitAsync(_locators.TxtUnderwritingNotes, "True");
        }
        await _ui.FillAsync(_locators.TxtUnderwritingNotes, _data.Resolve("{{data:txt_underwriting_notes_614}}"));
        await _ui.PressAsync(_locators.TxtUnderwritingNotes, "Click");
        await _ui.WaitAsync(_locators.BtnApprove, "Visible");
        await _ui.ClickAsync(_locators.BtnApprove);
        await _ui.ClickAsync(_locators.LnkHome);
    }

    // Business step: I approve Level 9B
    public async Task ApproveLevel9BAsync5()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0037_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0038_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_76}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0039_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0040_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        // EUApplicant_093167Page.EUApplicant_0041_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.BypassLevel9BRules))
        {
        await _ui.SmartSetAsync(_locators.BypassLevel9BRules, _data.Resolve("{{data:bypass_level_9b_rules_83}}"));
        }
        await _ui.FillAsync(_locators.BypassLevel9BRulesComments, _data.Resolve("{{data:bypass_level_9b_rules_comments_84}}"));
        await _ui.PressAsync(_locators.BypassLevel9BRulesComments, "Click");
        await _ui.ClickAsync(_locators.Home);
    }

    // Business step: I approve the underwriting referral in Express
    public async Task ApproveTheUnderwritingReferralInExpressAsync4()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0174_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0175_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_585}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0176_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0177_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        if (_data.Condition("MotorCycle != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkMotorcycle);
        }
        if (_data.Condition("PersonalAuto != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkPersonalAuto);
        }
        if (_data.Condition("RV != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkRV);
        }
        // EUApplicant_093167Page.EUApplicant_0178_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.LnkPricing))
        {
        await _ui.ClickAsync(_locators.LnkPricing);
        }
        // EUPricing_3ae83cPage.EUPricing_0179_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.SmartSetAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("{{data:chkbox_bypass_level_9_rules_596}}"));
        }
        await _ui.ClickAsync(_locators.BypassLevel9Comments1);
        await _ui.FillAsync(_locators.BypassLevel9Comments1, _data.Resolve("{{data:bypass_level_9_comments_1_598}}"));
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "POST:TAB");
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "Tab");
        await _ui.ClickAsync(_locators.LnkHome);
        // EUPricing_3ae83cPage.EUPricing_0180_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.VerifyAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("True"), "Enabled");
        }
        // EUPricing_3ae83cPage.EUPricing_0181_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.SmartSetAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("{{data:chkbox_bypass_level_9_rules_602}}"));
        }
        await _ui.ClickAsync(_locators.BypassLevel9Comments1);
        await _ui.FillAsync(_locators.BypassLevel9Comments1, _data.Resolve("{{data:bypass_level_9_comments_1_604}}"));
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "POST:TAB");
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "Tab");
        await _ui.ClickAsync(_locators.LnkHome);
    }

    // Business step: I complete the Express underwriting review
    public async Task CompleteTheExpressUnderwritingReviewAsync5()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0247_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0248_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_622}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0249_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0250_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        // EUApplicant_093167Page.EUApplicant_0251_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.LnkPricing))
        {
        await _ui.ClickAsync(_locators.LnkPricing);
        }
        // EUPricing_3ae83cPage.EUPricing_0252_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.TxtUnderwritingNotes))
        {
        await _ui.WaitAsync(_locators.TxtUnderwritingNotes, "True");
        }
        await _ui.FillAsync(_locators.TxtUnderwritingNotes, _data.Resolve("{{data:txt_underwriting_notes_631}}"));
        await _ui.PressAsync(_locators.TxtUnderwritingNotes, "Click");
        await _ui.WaitAsync(_locators.BtnApprove, "Visible");
        await _ui.ClickAsync(_locators.BtnApprove);
        await _ui.ClickAsync(_locators.LnkHome);
    }

    // Business step: I approve Level 9B
    public async Task ApproveLevel9BAsync6()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0037_10f911Async
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0038_10f911Async
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_76}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0039_10f911Async
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0040_10f911Async
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        // EUApplicant_093167Page.EUApplicant_0041_10f911Async
        if (await _ui.ExistsAsync(_locators.BypassLevel9BRules))
        {
        await _ui.SmartSetAsync(_locators.BypassLevel9BRules, _data.Resolve("{{data:bypass_level_9b_rules_83}}"));
        }
        await _ui.FillAsync(_locators.BypassLevel9BRulesComments, _data.Resolve("{{data:bypass_level_9b_rules_comments_84}}"));
        await _ui.PressAsync(_locators.BypassLevel9BRulesComments, "Click");
        await _ui.ClickAsync(_locators.Home);
    }

    // Business step: I approve the underwriting referral in Express
    public async Task ApproveTheUnderwritingReferralInExpressAsync5()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0174_10f911Async
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0175_10f911Async
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_588}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0176_10f911Async
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0177_10f911Async
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        if (_data.Condition("MotorCycle != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkMotorcycle);
        }
        if (_data.Condition("PersonalAuto != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkPersonalAuto);
        }
        if (_data.Condition("RV != NULL"))
        {
        await _ui.ClickAsync(_locators.LnkRV);
        }
        // EUApplicant_093167Page.EUApplicant_0178_10f911Async
        if (await _ui.ExistsAsync(_locators.LnkPricing))
        {
        await _ui.ClickAsync(_locators.LnkPricing);
        }
        // EUPricing_3ae83cPage.EUPricing_0179_10f911Async
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.SmartSetAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("{{data:chkbox_bypass_level_9_rules_599}}"));
        }
        await _ui.ClickAsync(_locators.BypassLevel9Comments1);
        await _ui.FillAsync(_locators.BypassLevel9Comments1, _data.Resolve("{{data:bypass_level_9_comments_1_601}}"));
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "POST:TAB");
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "Tab");
        await _ui.ClickAsync(_locators.LnkHome);
        // EUPricing_3ae83cPage.EUPricing_0180_10f911Async
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.VerifyAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("True"), "Enabled");
        }
        // EUPricing_3ae83cPage.EUPricing_0181_10f911Async
        if (await _ui.ExistsAsync(_locators.ChkBoxBypassLevel9Rules))
        {
        await _ui.SmartSetAsync(_locators.ChkBoxBypassLevel9Rules, _data.Resolve("{{data:chkbox_bypass_level_9_rules_605}}"));
        }
        await _ui.ClickAsync(_locators.BypassLevel9Comments1);
        await _ui.FillAsync(_locators.BypassLevel9Comments1, _data.Resolve("{{data:bypass_level_9_comments_1_607}}"));
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "POST:TAB");
        await _ui.PressAsync(_locators.BypassLevel9Comments1, "Tab");
        await _ui.ClickAsync(_locators.LnkHome);
    }

    // Business step: I complete the Express underwriting review
    public async Task CompleteTheExpressUnderwritingReviewAsync6()
    {
        // EULogin_5d641bPage.VerifyIfExpressUILoginPageIsShown_0247_10f911Async
        if (await _ui.ExistsAsync(_locators.LblLoginID))
        {
        await _ui.VerifyAsync(_locators.LblLoginID, _data.Resolve("Visible"), "");
        }
        // EULogin_5d641bPage.ProvideExpressUILoginCredentials_0248_10f911Async
        if (await _ui.ExistsAsync(_locators.TxtLoginID1))
        {
        await _ui.WaitAsync(_locators.TxtLoginID1, "Exists");
        }
        await _ui.FillAsync(_locators.TxtLoginID1, _data.Resolve("{{data:txt_login_id_1_625}}"));
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:PL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.LnkLOGIN);
        // EUHome_1407c2Page.EUHome_0249_10f911Async
        if (await _ui.ExistsAsync(_locators.TxtSearchType))
        {
        await _ui.WaitAsync(_locators.TxtSearchType, "Visible");
        }
        await _ui.FillAsync(_locators.TxtSearchText, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.AddEditAdditionalInterestFirstMortgageeSearch);
        // EUHomeMotorcyclePersonalAuto_ee44ebPage.EUHome_0250_10f911Async
        if (await _ui.ExistsAsync(_locators.PolicyQuote))
        {
        await _ui.ClickAsync(_locators.PolicyQuote);
        }
        // EUApplicant_093167Page.EUApplicant_0251_10f911Async
        if (await _ui.ExistsAsync(_locators.LnkPricing))
        {
        await _ui.ClickAsync(_locators.LnkPricing);
        }
        // EUPricing_3ae83cPage.EUPricing_0252_10f911Async
        if (await _ui.ExistsAsync(_locators.TxtUnderwritingNotes))
        {
        await _ui.WaitAsync(_locators.TxtUnderwritingNotes, "True");
        }
        await _ui.FillAsync(_locators.TxtUnderwritingNotes, _data.Resolve("{{data:txt_underwriting_notes_634}}"));
        await _ui.PressAsync(_locators.TxtUnderwritingNotes, "Click");
        await _ui.WaitAsync(_locators.BtnApprove, "Visible");
        await _ui.ClickAsync(_locators.BtnApprove);
        await _ui.ClickAsync(_locators.LnkHome);
    }

}