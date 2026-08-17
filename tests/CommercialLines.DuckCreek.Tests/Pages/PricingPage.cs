using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class PricingPage
{
    private readonly PricingLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public PricingPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new PricingLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I verify values in premium fields
    public async Task VerifyValuesInPremiumFieldsAsync()
    {
        // SubmissionPremiums_e6f985Page.VerifyPremiums_0257_515771Async
        await _ui.VerifyAsync(_locators.FullTermPremium, _data.Resolve("{{data:expected_full_term_premium_value_256}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumWritten, _data.Resolve("{{data:expected_premium_written_value_257}}"), "value");
        await _ui.VerifyAsync(_locators.PriorPremium, _data.Resolve("{{data:expected_prior_premium_value_258}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumChange, _data.Resolve("{{data:expected_premium_change_value_259}}"), "value");
        // VerifyJavaScriptResult_c744f4Page.GetSessionIDBuffer_0259_515771Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_261}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_262}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{XB[SessionId]}"), "value");
        // TBoxSetBuffer_e51da1Page.BufferServerAddress_0260_515771Async
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
    }

    // Business step: I verify values in premium fields
    public async Task VerifyValuesInPremiumFieldsAsync2()
    {
        // SubmissionPremiums_e6f985Page.VerifyPremiums_0257_d65717Async
        await _ui.VerifyAsync(_locators.FullTermPremium, _data.Resolve("{{data:expected_full_term_premium_value_256}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumWritten, _data.Resolve("{{data:expected_premium_written_value_257}}"), "value");
        await _ui.VerifyAsync(_locators.PriorPremium, _data.Resolve("{{data:expected_prior_premium_value_258}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumChange, _data.Resolve("{{data:expected_premium_change_value_259}}"), "value");
        // VerifyJavaScriptResult_c744f4Page.GetSessionIDBuffer_0259_d65717Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_261}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_262}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{XB[SessionId]}"), "value");
        // TBoxSetBuffer_e51da1Page.BufferServerAddress_0260_d65717Async
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
    }

    // Business step: I verify values in premium fields
    public async Task VerifyValuesInPremiumFieldsAsync3()
    {
        // SubmissionPremiums_e6f985Page.VerifyPremiums_0285_f90f36Async
        await _ui.VerifyAsync(_locators.FullTermPremium, _data.Resolve("{{data:expected_full_term_premium_value_280}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumWritten, _data.Resolve("{{data:expected_premium_written_value_281}}"), "value");
        await _ui.VerifyAsync(_locators.PriorPremium, _data.Resolve("{{data:expected_prior_premium_value_282}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumChange, _data.Resolve("{{data:expected_premium_change_value_283}}"), "value");
        // VerifyJavaScriptResult_c744f4Page.GetSessionIDBuffer_0287_f90f36Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_285}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_286}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{XB[SessionId]}"), "value");
        // TBoxSetBuffer_e51da1Page.BufferServerAddress_0288_f90f36Async
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
    }

    // Business step: I verify values in premium fields
    public async Task VerifyValuesInPremiumFieldsAsync4()
    {
        // SubmissionPremiums_e6f985Page.VerifyPremiums_0424_aad19bAsync
        await _ui.VerifyAsync(_locators.FullTermPremium, _data.Resolve("{{data:expected_full_term_premium_value_696}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumWritten, _data.Resolve("{{data:expected_premium_written_value_697}}"), "value");
        await _ui.VerifyAsync(_locators.PriorPremium, _data.Resolve("{{data:expected_prior_premium_value_698}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumChange, _data.Resolve("{{data:expected_premium_change_value_699}}"), "value");
        // VerifyJavaScriptResult_c744f4Page.GetSessionIDBuffer_0426_aad19bAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_701}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_702}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{XB[SessionId]}"), "value");
        // TBoxSetBuffer_e51da1Page.BufferServerAddress_0427_aad19bAsync
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
    }

    // Business step: I verify values in premium fields
    public async Task VerifyValuesInPremiumFieldsAsync5()
    {
        // SubmissionPremiums_e6f985Page.VerifyPremiums_0324_677267Async
        await _ui.VerifyAsync(_locators.FullTermPremium, _data.Resolve("{{data:expected_full_term_premium_value_384}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumWritten, _data.Resolve("{{data:expected_premium_written_value_385}}"), "value");
        await _ui.VerifyAsync(_locators.PriorPremium, _data.Resolve("{{data:expected_prior_premium_value_386}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumChange, _data.Resolve("{{data:expected_premium_change_value_387}}"), "value");
        // VerifyJavaScriptResult_c744f4Page.GetSessionIDBuffer_0326_677267Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_389}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_390}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{XB[SessionId]}"), "value");
        // TBoxSetBuffer_e51da1Page.BufferServerAddress_0327_677267Async
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
    }

    // Business step: I verify values in premium fields
    public async Task VerifyValuesInPremiumFieldsAsync6()
    {
        // SubmissionPremiums_e6f985Page.VerifyPremiums_0326_767d1bAsync
        await _ui.VerifyAsync(_locators.FullTermPremium, _data.Resolve("{{data:expected_full_term_premium_value_292}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumWritten, _data.Resolve("{{data:expected_premium_written_value_293}}"), "value");
        await _ui.VerifyAsync(_locators.PriorPremium, _data.Resolve("{{data:expected_prior_premium_value_294}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumChange, _data.Resolve("{{data:expected_premium_change_value_295}}"), "value");
        // VerifyJavaScriptResult_c744f4Page.GetSessionIDBuffer_0345_767d1bAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_297}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_298}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{XB[SessionId]}"), "value");
        // TBoxSetBuffer_e51da1Page.BufferServerAddress_0346_767d1bAsync
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
    }

    // Business step: I complete Estimated premium
    public async Task CompleteEstimatedPremiumAsync()
    {
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.PolicyInfoEstimatedPremium_0088_bb930cAsync
        if (_data.Condition("'Estimated Premium' == NULL"))
        {
        await _ui.VerifyAsync(_locators.EstimatedPremium, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I verify premium
    public async Task VerifyPremiumAsync()
    {
        // Pricing_a0d9bbPage.VerifyPremium_0123_bb930cAsync
        await _ui.VerifyAsync(_locators.Premium, _data.Resolve("{{data:expected_premium_value_224}}"), "value");
    }

    // Business step: I verify values in premium fields
    public async Task VerifyValuesInPremiumFieldsAsync7()
    {
        // SubmissionPremiums_e6f985Page.VerifyPremiums_0271_bb930cAsync
        await _ui.VerifyAsync(_locators.FullTermPremium, _data.Resolve("{{data:expected_full_term_premium_value_288}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumWritten, _data.Resolve("{{data:expected_premium_written_value_289}}"), "value");
        await _ui.VerifyAsync(_locators.PriorPremium, _data.Resolve("{{data:expected_prior_premium_value_290}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumChange, _data.Resolve("{{data:expected_premium_change_value_291}}"), "value");
        // VerifyJavaScriptResult_c744f4Page.GetSessionIDBuffer_0273_bb930cAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_293}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_294}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{XB[SessionId]}"), "value");
        // TBoxSetBuffer_e51da1Page.BufferServerAddress_0274_bb930cAsync
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
    }

    // Business step: I verify values in premium fields
    public async Task VerifyValuesInPremiumFieldsAsync8()
    {
        // SubmissionPremiums_e6f985Page.VerifyPremiums_0339_a8e5f5Async
        await _ui.VerifyAsync(_locators.FullTermPremium, _data.Resolve("{{data:expected_full_term_premium_value_431}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumWritten, _data.Resolve("{{data:expected_premium_written_value_432}}"), "value");
        await _ui.VerifyAsync(_locators.PriorPremium, _data.Resolve("{{data:expected_prior_premium_value_433}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumChange, _data.Resolve("{{data:expected_premium_change_value_434}}"), "value");
        // VerifyJavaScriptResult_c744f4Page.GetSessionIDBuffer_0341_a8e5f5Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_436}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_437}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{XB[SessionId]}"), "value");
        // TBoxSetBuffer_e51da1Page.BufferServerAddress_0342_a8e5f5Async
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
    }

    // Business step: I complete Estimated premium
    public async Task CompleteEstimatedPremiumAsync2()
    {
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.PolicyInfoEstimatedPremium_0087_f2d6bdAsync
        if (_data.Condition("'Estimated Premium' == NULL"))
        {
        await _ui.VerifyAsync(_locators.EstimatedPremium, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I verify values in premium fields
    public async Task VerifyValuesInPremiumFieldsAsync9()
    {
        // SubmissionPremiums_e6f985Page.VerifyPremiums_0291_f2d6bdAsync
        await _ui.VerifyAsync(_locators.FullTermPremium, _data.Resolve("{{data:expected_full_term_premium_value_324}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumWritten, _data.Resolve("{{data:expected_premium_written_value_325}}"), "value");
        await _ui.VerifyAsync(_locators.PriorPremium, _data.Resolve("{{data:expected_prior_premium_value_326}}"), "value");
        await _ui.VerifyAsync(_locators.PremiumChange, _data.Resolve("{{data:expected_premium_change_value_327}}"), "value");
        // VerifyJavaScriptResult_c744f4Page.GetSessionIDBuffer_0293_f2d6bdAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_329}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_330}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{XB[SessionId]}"), "value");
        // TBoxSetBuffer_e51da1Page.BufferServerAddress_0294_f2d6bdAsync
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
    }

}