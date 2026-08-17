using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class NavigationPage
{
    private readonly NavigationLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public NavigationPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new NavigationLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete tabs
    public async Task CompleteTabsAsync()
    {
        // EQTabs_8481b3Page.EQTabs_0030_d06ed6Async
        await _ui.ClickAsync(_locators.CloseTab);
        await _ui.FillAsync(_locators.QuoteSearchInput, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.TabsSearch);
        // EQTabs_8481b3Page.EQTabs_0031_d06ed6Async
        _data.Set("QuoteNumber6", await _ui.CaptureAsync(_locators.QNum, "Text"));
        await _ui.VerifyAsync(_locators.QNum, _data.Resolve("{{runtime:QuoteNumber2}}"), "");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0032_d06ed6Async
        _data.Set("QuoteNumber7", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber6]}][\"PERSONAL AUTO \"][\"\"]}"));
        _data.Set("QuoteNumber8", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber7]}][\"\\(\"][\"\"]}"));
        _data.Set("QuoteNumber9", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber8]}][\"\\)\"][\"\"]}"));
    }

    // Business step: I complete coverages
    public async Task CompleteCoveragesAsync()
    {
        // CoveragesNew_4d5fe6Page.SelectPolicyCoverageOption_0116_8f9ff6Async
        if (_data.Condition("PolicyCovOption == \"OPTION 1\""))
        {
            await _ui.SmartSetAsync(_locators.Option1, _data.Resolve("{{data:option_1_331}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 2\""))
        {
            await _ui.SmartSetAsync(_locators.Option2, _data.Resolve("{{data:option_2_332}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 3\""))
        {
            await _ui.SmartSetAsync(_locators.Option3, _data.Resolve("{{data:option_3_333}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 1\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt1);
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 2\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt2);
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 3\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt3);
        }
        // EditCoverageOptionNew_4ccaffPage.EditCoverageOption_0117_8f9ff6Async
        if (_data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.WaitAsync(_locators.SupplementalUMUIMOptIn, "Exists");
        }
        if (_data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.ClickAsync(_locators.SupplementalUMUIMOptIn);
        }
        if (_data.Condition("'Supplemental UM/UIM Opt In' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.SupplementalUMUIMCov);
        }
        if (_data.Condition("CovOptUninsured != NULL"))
        {
            await _ui.WaitAsync(_locators.UMCoverage, "Exists");
        }
        if (_data.Condition("CovOptUninsured != NULL"))
        {
            await _ui.ClickAsync(_locators.UMCoverage);
        }
        if (_data.Condition("CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0118_8f9ff6Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV1_0119_8f9ff6Async
        await _ui.PressAsync(_locators.Option3, "PRE:scroll[5]");
        await _ui.PressAsync(_locators.Option3, "scroll[5]");
        // CoveragesNew_4d5fe6Page.SelectV1Coverages_0120_8f9ff6Async
        if (_data.Condition("V1_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V1CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V1_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V1ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V1_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V1ComprehensiveOnly, _data.Resolve("{{data:v1_comprehensive_only_347}}"));
        }
        if (_data.Condition("'V1_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V1ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V1_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V1ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V1_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CompDed);
        }
        if (_data.Condition("V1_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CompDedMoreOpt);
        }
        if (_data.Condition("V1_CollDed != NULL AND V1_CompDed != NoCoverage"))
        {
            await _ui.ClickAsync(_locators.V1CollDed);
        }
        if (_data.Condition("V1_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV2_0121_8f9ff6Async
        await _ui.PressAsync(_locators.Option3, "PRE:scroll[8]");
        await _ui.PressAsync(_locators.Option3, "scroll[8]");
        // CoveragesNew_4d5fe6Page.SelectV2Coverages_0122_8f9ff6Async
        if (_data.Condition("V2_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V2CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V2_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V2ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V2_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V2ComprehensiveOnly, _data.Resolve("{{data:v2_comprehensive_only_357}}"));
        }
        if (_data.Condition("'V2_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V2ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V2_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V2ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V2_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CompDed);
        }
        if (_data.Condition("V2_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CompDedMoreOpt);
        }
        if (_data.Condition("V2_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CollDed);
        }
        if (_data.Condition("V2_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV3_0123_8f9ff6Async
        await _ui.PressAsync(_locators.CoveragesNewNext, "PRE:end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "scroll[-4]");
        // CoveragesNew_4d5fe6Page.SelectV3Coverages_0124_8f9ff6Async
        if (_data.Condition("V3_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V3CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V3_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V3ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V3_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V3ComprehensiveOnly, _data.Resolve("{{data:v3_comprehensive_only_367}}"));
        }
        if (_data.Condition("'V3_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V3ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V3_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V3ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V3_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CompDed);
        }
        if (_data.Condition("V3_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CompDedMoreOpt);
        }
        if (_data.Condition("V3_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CollDed);
        }
        if (_data.Condition("V3_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV4_0125_8f9ff6Async
        await _ui.PressAsync(_locators.CoveragesNewNext, "PRE:end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "end");
        // CoveragesNew_4d5fe6Page.SelectV4Coverages_0126_8f9ff6Async
        if (_data.Condition("V4_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V4CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V4_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V4ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V4_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V4ComprehensiveOnly, _data.Resolve("{{data:v4_comprehensive_only_377}}"));
        }
        if (_data.Condition("'V4_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V4ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V4_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V4ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V4_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CompDed);
        }
        if (_data.Condition("V4_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CompDedMoreOpt);
        }
        if (_data.Condition("V4_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CollDed);
        }
        if (_data.Condition("V4_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CollDedMoreOpt);
        }
        await _ui.ClickAsync(_locators.CoveragesNewNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0135_8f9ff6Async
        _data.Set("Tort Option", _data.Get("Tort Option"));
        _data.Set("Income Loss Coverage", _data.Get("Income Loss Coverage"));
        _data.Set("UMPD", _data.Get("UMPD"));
        _data.Set("UIMPD", _data.Get("UIMPD"));
        _data.Set("AD&D Coverage", _data.Resolve("{{data:ad_d_coverage}}"));
        _data.Set("Inc Liab Claims Fam Mem", _data.Get("Inc Liab Claims Fam Mem"));
        _data.Set("Extraordinary Medical Benefit", _data.Get("Extraordinary Medical Benefit"));
    }

    // Business step: I complete tabs
    public async Task CompleteTabsAsync2()
    {
        // EQTabs_8481b3Page.EQTabs_0030_b91c7dAsync
        await _ui.ClickAsync(_locators.CloseTab);
        await _ui.FillAsync(_locators.QuoteSearchInput, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.TabsSearch);
        // EQTabs_8481b3Page.EQTabs_0031_b91c7dAsync
        _data.Set("QuoteNumber6", await _ui.CaptureAsync(_locators.QNum, "Text"));
        await _ui.VerifyAsync(_locators.QNum, _data.Resolve("{{runtime:QuoteNumber2}}"), "");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0032_b91c7dAsync
        _data.Set("QuoteNumber7", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber6]}][\"PERSONAL AUTO \"][\"\"]}"));
        _data.Set("QuoteNumber8", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber7]}][\"\\(\"][\"\"]}"));
        _data.Set("QuoteNumber9", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber8]}][\"\\)\"][\"\"]}"));
    }

    // Business step: I complete coverages
    public async Task CompleteCoveragesAsync2()
    {
        // CoveragesNew_4d5fe6Page.SelectPolicyCoverageOption_0128_8f5301Async
        if (_data.Condition("PolicyCovOption == \"OPTION 1\""))
        {
            await _ui.SmartSetAsync(_locators.Option1, _data.Resolve("{{data:option_1_382}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 2\""))
        {
            await _ui.SmartSetAsync(_locators.Option2, _data.Resolve("{{data:option_2_383}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 3\""))
        {
            await _ui.SmartSetAsync(_locators.Option3, _data.Resolve("{{data:option_3_384}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 1\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt1);
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 2\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt2);
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 3\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt3);
        }
        // EditCoverageOptionNew_4ccaffPage.EditCoverageOption_0129_8f5301Async
        if (_data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.WaitAsync(_locators.SupplementalUMUIMOptIn, "Exists");
        }
        if (_data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.ClickAsync(_locators.SupplementalUMUIMOptIn);
        }
        if (_data.Condition("'Supplemental UM/UIM Opt In' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.SupplementalUMUIMCov);
        }
        if (_data.Condition("CovOptUninsured != NULL"))
        {
            await _ui.WaitAsync(_locators.UMCoverage, "Exists");
        }
        if (_data.Condition("CovOptUninsured != NULL"))
        {
            await _ui.ClickAsync(_locators.UMCoverage);
        }
        if (_data.Condition("CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0130_8f5301Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV1_0131_8f5301Async
        await _ui.PressAsync(_locators.Option3, "PRE:scroll[5]");
        await _ui.PressAsync(_locators.Option3, "scroll[5]");
        // CoveragesNew_4d5fe6Page.SelectV1Coverages_0132_8f5301Async
        if (_data.Condition("V1_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V1CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V1_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V1ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V1_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V1ComprehensiveOnly, _data.Resolve("{{data:v1_comprehensive_only_398}}"));
        }
        if (_data.Condition("'V1_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V1ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V1_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V1ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V1_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CompDed);
        }
        if (_data.Condition("V1_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CompDedMoreOpt);
        }
        if (_data.Condition("V1_CollDed != NULL AND V1_CompDed != NoCoverage"))
        {
            await _ui.ClickAsync(_locators.V1CollDed);
        }
        if (_data.Condition("V1_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV2_0133_8f5301Async
        await _ui.PressAsync(_locators.Option3, "PRE:scroll[8]");
        await _ui.PressAsync(_locators.Option3, "scroll[8]");
        // CoveragesNew_4d5fe6Page.SelectV2Coverages_0134_8f5301Async
        if (_data.Condition("V2_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V2CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V2_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V2ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V2_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V2ComprehensiveOnly, _data.Resolve("{{data:v2_comprehensive_only_408}}"));
        }
        if (_data.Condition("'V2_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V2ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V2_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V2ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V2_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CompDed);
        }
        if (_data.Condition("V2_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CompDedMoreOpt);
        }
        if (_data.Condition("V2_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CollDed);
        }
        if (_data.Condition("V2_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV3_0135_8f5301Async
        await _ui.PressAsync(_locators.CoveragesNewNext, "PRE:end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "scroll[-4]");
        // CoveragesNew_4d5fe6Page.SelectV3Coverages_0136_8f5301Async
        if (_data.Condition("V3_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V3CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V3_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V3ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V3_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V3ComprehensiveOnly, _data.Resolve("{{data:v3_comprehensive_only_418}}"));
        }
        if (_data.Condition("'V3_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V3ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V3_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V3ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V3_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CompDed);
        }
        if (_data.Condition("V3_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CompDedMoreOpt);
        }
        if (_data.Condition("V3_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CollDed);
        }
        if (_data.Condition("V3_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV4_0137_8f5301Async
        await _ui.PressAsync(_locators.CoveragesNewNext, "PRE:end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "end");
        // CoveragesNew_4d5fe6Page.SelectV4Coverages_0138_8f5301Async
        if (_data.Condition("V4_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V4CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V4_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V4ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V4_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V4ComprehensiveOnly, _data.Resolve("{{data:v4_comprehensive_only_428}}"));
        }
        if (_data.Condition("'V4_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V4ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V4_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V4ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V4_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CompDed);
        }
        if (_data.Condition("V4_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CompDedMoreOpt);
        }
        if (_data.Condition("V4_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CollDed);
        }
        if (_data.Condition("V4_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CollDedMoreOpt);
        }
        await _ui.ClickAsync(_locators.CoveragesNewNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0147_8f5301Async
        _data.Set("Tort Option", _data.Get("Tort Option"));
        _data.Set("Income Loss Coverage", _data.Get("Income Loss Coverage"));
        _data.Set("UMPD", _data.Get("UMPD"));
        _data.Set("UIMPD", _data.Get("UIMPD"));
        _data.Set("AD&D Coverage", _data.Get("AD&D Coverage"));
        _data.Set("Inc Liab Claims Fam Mem", _data.Get("Inc Liab Claims Fam Mem"));
        _data.Set("Extraordinary Medical Benefit", _data.Get("Extraordinary Medical Benefit"));
    }

    // Business step: I complete coverages
    public async Task CompleteCoveragesAsync3()
    {
        // CoveragesNew_4d5fe6Page.SelectPolicyCoverageOption_0125_e2e0d7Async
        if (_data.Condition("PolicyCovOption == \"OPTION 1\""))
        {
            await _ui.SmartSetAsync(_locators.Option1, _data.Resolve("{{data:option_1_365}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 2\""))
        {
            await _ui.SmartSetAsync(_locators.Option2, _data.Resolve("{{data:option_2_366}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 3\""))
        {
            await _ui.SmartSetAsync(_locators.Option3, _data.Resolve("{{data:option_3_367}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 1\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt1);
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 2\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt2);
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 3\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt3);
        }
        // EditCoverageOptionNew_4ccaffPage.EditCoverageOption_0126_e2e0d7Async
        if (_data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.WaitAsync(_locators.SupplementalUMUIMOptIn, "Exists");
        }
        if (_data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.ClickAsync(_locators.SupplementalUMUIMOptIn);
        }
        if (_data.Condition("'Supplemental UM/UIM Opt In' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.SupplementalUMUIMCov);
        }
        if (_data.Condition("CovOptUninsured != NULL"))
        {
            await _ui.WaitAsync(_locators.UMCoverage, "Exists");
        }
        if (_data.Condition("CovOptUninsured != NULL"))
        {
            await _ui.ClickAsync(_locators.UMCoverage);
        }
        if (_data.Condition("CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0127_e2e0d7Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV1_0128_e2e0d7Async
        await _ui.PressAsync(_locators.Option3, "PRE:scroll[5]");
        await _ui.PressAsync(_locators.Option3, "scroll[5]");
        // CoveragesNew_4d5fe6Page.SelectV1Coverages_0129_e2e0d7Async
        if (_data.Condition("V1_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V1CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V1_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V1ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V1_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V1ComprehensiveOnly, _data.Resolve("{{data:v1_comprehensive_only_381}}"));
        }
        if (_data.Condition("'V1_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V1ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V1_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V1ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V1_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CompDed);
        }
        if (_data.Condition("V1_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CompDedMoreOpt);
        }
        if (_data.Condition("V1_CollDed != NULL AND V1_CompDed != NoCoverage"))
        {
            await _ui.ClickAsync(_locators.V1CollDed);
        }
        if (_data.Condition("V1_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV2_0130_e2e0d7Async
        await _ui.PressAsync(_locators.Option3, "PRE:scroll[8]");
        await _ui.PressAsync(_locators.Option3, "scroll[8]");
        // CoveragesNew_4d5fe6Page.SelectV2Coverages_0131_e2e0d7Async
        if (_data.Condition("V2_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V2CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V2_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V2ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V2_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V2ComprehensiveOnly, _data.Resolve("{{data:v2_comprehensive_only_391}}"));
        }
        if (_data.Condition("'V2_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V2ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V2_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V2ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V2_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CompDed);
        }
        if (_data.Condition("V2_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CompDedMoreOpt);
        }
        if (_data.Condition("V2_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CollDed);
        }
        if (_data.Condition("V2_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV3_0132_e2e0d7Async
        await _ui.PressAsync(_locators.CoveragesNewNext, "PRE:end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "scroll[-4]");
        // CoveragesNew_4d5fe6Page.SelectV3Coverages_0133_e2e0d7Async
        if (_data.Condition("V3_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V3CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V3_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V3ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V3_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V3ComprehensiveOnly, _data.Resolve("{{data:v3_comprehensive_only_401}}"));
        }
        if (_data.Condition("'V3_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V3ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V3_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V3ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V3_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CompDed);
        }
        if (_data.Condition("V3_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CompDedMoreOpt);
        }
        if (_data.Condition("V3_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CollDed);
        }
        if (_data.Condition("V3_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV4_0134_e2e0d7Async
        await _ui.PressAsync(_locators.CoveragesNewNext, "PRE:end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "end");
        // CoveragesNew_4d5fe6Page.SelectV4Coverages_0135_e2e0d7Async
        if (_data.Condition("V4_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V4CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V4_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V4ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V4_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V4ComprehensiveOnly, _data.Resolve("{{data:v4_comprehensive_only_411}}"));
        }
        if (_data.Condition("'V4_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V4ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V4_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V4ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V4_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CompDed);
        }
        if (_data.Condition("V4_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CompDedMoreOpt);
        }
        if (_data.Condition("V4_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CollDed);
        }
        if (_data.Condition("V4_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CollDedMoreOpt);
        }
        await _ui.ClickAsync(_locators.CoveragesNewNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0144_e2e0d7Async
        _data.Set("Tort Option", _data.Get("Tort Option"));
        _data.Set("Income Loss Coverage", _data.Get("Income Loss Coverage"));
        _data.Set("UMPD", _data.Get("UMPD"));
        _data.Set("UIMPD", _data.Get("UIMPD"));
        _data.Set("AD&D Coverage", _data.Resolve("{{data:ad_d_coverage}}"));
        _data.Set("Inc Liab Claims Fam Mem", _data.Get("Inc Liab Claims Fam Mem"));
        _data.Set("Extraordinary Medical Benefit", _data.Get("Extraordinary Medical Benefit"));
    }

    // Business step: I complete coverages
    public async Task CompleteCoveragesAsync4()
    {
        // CoveragesNew_4d5fe6Page.SelectPolicyCoverageOption_0125_bafd4aAsync
        if (_data.Condition("PolicyCovOption == \"OPTION 1\""))
        {
            await _ui.SmartSetAsync(_locators.Option1, _data.Resolve("{{data:option_1_365}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 2\""))
        {
            await _ui.SmartSetAsync(_locators.Option2, _data.Resolve("{{data:option_2_366}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 3\""))
        {
            await _ui.SmartSetAsync(_locators.Option3, _data.Resolve("{{data:option_3_367}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 1\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt1);
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 2\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt2);
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 3\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt3);
        }
        // EditCoverageOptionNew_4ccaffPage.EditCoverageOption_0126_bafd4aAsync
        if (_data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.WaitAsync(_locators.SupplementalUMUIMOptIn, "Exists");
        }
        if (_data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.ClickAsync(_locators.SupplementalUMUIMOptIn);
        }
        if (_data.Condition("'Supplemental UM/UIM Opt In' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.SupplementalUMUIMCov);
        }
        if (_data.Condition("CovOptUninsured != NULL"))
        {
            await _ui.WaitAsync(_locators.UMCoverage, "Exists");
        }
        if (_data.Condition("CovOptUninsured != NULL"))
        {
            await _ui.ClickAsync(_locators.UMCoverage);
        }
        if (_data.Condition("CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0127_bafd4aAsync
        await _ui.WaitAsync(_locators.Loading, "Exists");
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV1_0128_bafd4aAsync
        await _ui.PressAsync(_locators.Option3, "PRE:scroll[5]");
        await _ui.PressAsync(_locators.Option3, "scroll[5]");
        // CoveragesNew_4d5fe6Page.SelectV1Coverages_0129_bafd4aAsync
        if (_data.Condition("V1_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V1CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V1_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V1ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V1_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V1ComprehensiveOnly, _data.Resolve("{{data:v1_comprehensive_only_381}}"));
        }
        if (_data.Condition("'V1_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V1ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V1_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V1ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V1_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CompDed);
        }
        if (_data.Condition("V1_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CompDedMoreOpt);
        }
        if (_data.Condition("V1_CollDed != NULL AND V1_CompDed != NoCoverage"))
        {
            await _ui.ClickAsync(_locators.V1CollDed);
        }
        if (_data.Condition("V1_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV2_0130_bafd4aAsync
        await _ui.PressAsync(_locators.Option3, "PRE:scroll[8]");
        await _ui.PressAsync(_locators.Option3, "scroll[8]");
        // CoveragesNew_4d5fe6Page.SelectV2Coverages_0131_bafd4aAsync
        if (_data.Condition("V2_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V2CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V2_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V2ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V2_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V2ComprehensiveOnly, _data.Resolve("{{data:v2_comprehensive_only_391}}"));
        }
        if (_data.Condition("'V2_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V2ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V2_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V2ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V2_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CompDed);
        }
        if (_data.Condition("V2_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CompDedMoreOpt);
        }
        if (_data.Condition("V2_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CollDed);
        }
        if (_data.Condition("V2_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV3_0132_bafd4aAsync
        await _ui.PressAsync(_locators.CoveragesNewNext, "PRE:end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "scroll[-4]");
        // CoveragesNew_4d5fe6Page.SelectV3Coverages_0133_bafd4aAsync
        if (_data.Condition("V3_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V3CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V3_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V3ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V3_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V3ComprehensiveOnly, _data.Resolve("{{data:v3_comprehensive_only_401}}"));
        }
        if (_data.Condition("'V3_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V3ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V3_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V3ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V3_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CompDed);
        }
        if (_data.Condition("V3_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CompDedMoreOpt);
        }
        if (_data.Condition("V3_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CollDed);
        }
        if (_data.Condition("V3_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV4_0134_bafd4aAsync
        await _ui.PressAsync(_locators.CoveragesNewNext, "PRE:end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "end");
        // CoveragesNew_4d5fe6Page.SelectV4Coverages_0135_bafd4aAsync
        if (_data.Condition("V4_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V4CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V4_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V4ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V4_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V4ComprehensiveOnly, _data.Resolve("{{data:v4_comprehensive_only_411}}"));
        }
        if (_data.Condition("'V4_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V4ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V4_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V4ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V4_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CompDed);
        }
        if (_data.Condition("V4_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CompDedMoreOpt);
        }
        if (_data.Condition("V4_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CollDed);
        }
        if (_data.Condition("V4_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CollDedMoreOpt);
        }
        await _ui.ClickAsync(_locators.CoveragesNewNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0144_bafd4aAsync
        _data.Set("Tort Option", _data.Get("Tort Option"));
        _data.Set("Income Loss Coverage", _data.Get("Income Loss Coverage"));
        _data.Set("UMPD", _data.Get("UMPD"));
        _data.Set("UIMPD", _data.Get("UIMPD"));
        _data.Set("AD&D Coverage", _data.Resolve("{{data:ad_d_coverage}}"));
        _data.Set("Inc Liab Claims Fam Mem", _data.Get("Inc Liab Claims Fam Mem"));
        _data.Set("Extraordinary Medical Benefit", _data.Get("Extraordinary Medical Benefit"));
    }

    // Business step: I complete coverages
    public async Task CompleteCoveragesAsync5()
    {
        // CoveragesNew_4d5fe6Page.SelectPolicyCoverageOption_0128_8f4c8fAsync
        if (_data.Condition("PolicyCovOption == \"OPTION 1\""))
        {
            await _ui.SmartSetAsync(_locators.Option1, _data.Resolve("{{data:option_1_382}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 2\""))
        {
            await _ui.SmartSetAsync(_locators.Option2, _data.Resolve("{{data:option_2_383}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 3\""))
        {
            await _ui.SmartSetAsync(_locators.Option3, _data.Resolve("{{data:option_3_384}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 1\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt1);
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 2\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt2);
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 3\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt3);
        }
        // EditCoverageOptionNew_4ccaffPage.EditCoverageOption_0129_8f4c8fAsync
        if (_data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.WaitAsync(_locators.SupplementalUMUIMOptIn, "Exists");
        }
        if (_data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.ClickAsync(_locators.SupplementalUMUIMOptIn);
        }
        if (_data.Condition("'Supplemental UM/UIM Opt In' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.SupplementalUMUIMCov);
        }
        if (_data.Condition("CovOptUninsured != NULL"))
        {
            await _ui.WaitAsync(_locators.UMCoverage, "Exists");
        }
        if (_data.Condition("CovOptUninsured != NULL"))
        {
            await _ui.ClickAsync(_locators.UMCoverage);
        }
        if (_data.Condition("CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0130_8f4c8fAsync
        await _ui.WaitAsync(_locators.Loading, "Exists");
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV1_0131_8f4c8fAsync
        await _ui.PressAsync(_locators.Option3, "PRE:scroll[5]");
        await _ui.PressAsync(_locators.Option3, "scroll[5]");
        // CoveragesNew_4d5fe6Page.SelectV1Coverages_0132_8f4c8fAsync
        if (_data.Condition("V1_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V1CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V1_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V1ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V1_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V1ComprehensiveOnly, _data.Resolve("{{data:v1_comprehensive_only_398}}"));
        }
        if (_data.Condition("'V1_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V1ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V1_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V1ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V1_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CompDed);
        }
        if (_data.Condition("V1_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CompDedMoreOpt);
        }
        if (_data.Condition("V1_CollDed != NULL AND V1_CompDed != NoCoverage"))
        {
            await _ui.ClickAsync(_locators.V1CollDed);
        }
        if (_data.Condition("V1_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV2_0133_8f4c8fAsync
        await _ui.PressAsync(_locators.Option3, "PRE:scroll[8]");
        await _ui.PressAsync(_locators.Option3, "scroll[8]");
        // CoveragesNew_4d5fe6Page.SelectV2Coverages_0134_8f4c8fAsync
        if (_data.Condition("V2_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V2CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V2_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V2ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V2_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V2ComprehensiveOnly, _data.Resolve("{{data:v2_comprehensive_only_408}}"));
        }
        if (_data.Condition("'V2_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V2ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V2_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V2ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V2_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CompDed);
        }
        if (_data.Condition("V2_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CompDedMoreOpt);
        }
        if (_data.Condition("V2_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CollDed);
        }
        if (_data.Condition("V2_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV3_0135_8f4c8fAsync
        await _ui.PressAsync(_locators.CoveragesNewNext, "PRE:end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "scroll[-4]");
        // CoveragesNew_4d5fe6Page.SelectV3Coverages_0136_8f4c8fAsync
        if (_data.Condition("V3_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V3CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V3_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V3ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V3_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V3ComprehensiveOnly, _data.Resolve("{{data:v3_comprehensive_only_418}}"));
        }
        if (_data.Condition("'V3_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V3ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V3_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V3ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V3_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CompDed);
        }
        if (_data.Condition("V3_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CompDedMoreOpt);
        }
        if (_data.Condition("V3_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CollDed);
        }
        if (_data.Condition("V3_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV4_0137_8f4c8fAsync
        await _ui.PressAsync(_locators.CoveragesNewNext, "PRE:end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "end");
        // CoveragesNew_4d5fe6Page.SelectV4Coverages_0138_8f4c8fAsync
        if (_data.Condition("V4_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V4CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V4_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V4ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V4_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V4ComprehensiveOnly, _data.Resolve("{{data:v4_comprehensive_only_428}}"));
        }
        if (_data.Condition("'V4_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V4ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V4_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V4ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V4_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CompDed);
        }
        if (_data.Condition("V4_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CompDedMoreOpt);
        }
        if (_data.Condition("V4_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CollDed);
        }
        if (_data.Condition("V4_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CollDedMoreOpt);
        }
        await _ui.ClickAsync(_locators.CoveragesNewNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0147_8f4c8fAsync
        _data.Set("Tort Option", _data.Get("Tort Option"));
        _data.Set("Income Loss Coverage", _data.Get("Income Loss Coverage"));
        _data.Set("UMPD", _data.Get("UMPD"));
        _data.Set("UIMPD", _data.Get("UIMPD"));
        _data.Set("AD&D Coverage", _data.Resolve("{{data:ad_d_coverage}}"));
        _data.Set("Inc Liab Claims Fam Mem", _data.Get("Inc Liab Claims Fam Mem"));
        _data.Set("Extraordinary Medical Benefit", _data.Get("Extraordinary Medical Benefit"));
    }

    // Business step: I navigate using the policy side menu
    public async Task NavigateUsingThePolicySideMenuAsync()
    {
        // EQSideMenu_e12e67Page.EQSideMenu_0081_10f911Async
        await _ui.ClickAsync(_locators.DriverInformation);
        // EQAddAdditionalDriver1_22ae72Page.EQAddAdditionalDriver1_0082_10f911Async
        _data.Set("Driver_1", await _ui.CaptureAsync(_locators.Driver1, "InnerText"));
        // EQSideMenu_e12e67Page.EQSideMenu_0083_10f911Async
        await _ui.ClickAsync(_locators.VehicleSummary);
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0084_10f911Async
        _data.Set("Farm/Use", _data.Get("Farm/Use"));
        _data.Set("PickUp", _data.Get("PickUp"));
        await _ui.FillAsync(_locators.State, _data.Get("AL_ClientData.State"));
        _data.Set("Company", _data.Resolve("{{data:company}}"));
        _data.Set("Loan", _data.Get("Loan"));
        _data.Set("Lease", _data.Get("Lease"));
        _data.Set("AntiTheft", _data.Get("AntiTheft"));
        _data.Set("Business/Use", _data.Get("Business/Use"));
    }

    // Business step: I complete coverages
    public async Task CompleteCoveragesAsync6()
    {
        // CoveragesNew_4d5fe6Page.SelectPolicyCoverageOption_0128_10f911Async
        if (_data.Condition("PolicyCovOption == \"OPTION 1\""))
        {
            await _ui.SmartSetAsync(_locators.Option1, _data.Resolve("{{data:option_1_385}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 2\""))
        {
            await _ui.SmartSetAsync(_locators.Option2, _data.Resolve("{{data:option_2_386}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 3\""))
        {
            await _ui.SmartSetAsync(_locators.Option3, _data.Resolve("{{data:option_3_387}}"));
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 1\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt1);
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 2\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt2);
        }
        if (_data.Condition("PolicyCovOption == \"OPTION 3\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)"))
        {
            await _ui.ClickAsync(_locators.EDITCOVERAGEOpt3);
        }
        // EditCoverageOptionNew_4ccaffPage.EditCoverageOption_0129_10f911Async
        if (_data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.WaitAsync(_locators.SupplementalUMUIMOptIn, "Exists");
        }
        if (_data.Condition("'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.ClickAsync(_locators.SupplementalUMUIMOptIn);
        }
        if (_data.Condition("'Supplemental UM/UIM Opt In' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.SupplementalUMUIMCov);
        }
        if (_data.Condition("CovOptUninsured != NULL"))
        {
            await _ui.WaitAsync(_locators.UMCoverage, "Exists");
        }
        if (_data.Condition("CovOptUninsured != NULL"))
        {
            await _ui.ClickAsync(_locators.UMCoverage);
        }
        if (_data.Condition("CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL"))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0130_10f911Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV1_0131_10f911Async
        await _ui.PressAsync(_locators.Option3, "PRE:scroll[5]");
        await _ui.PressAsync(_locators.Option3, "scroll[5]");
        // CoveragesNew_4d5fe6Page.SelectV1Coverages_0132_10f911Async
        if (_data.Condition("V1_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V1CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V1_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V1ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V1_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V1ComprehensiveOnly, _data.Resolve("{{data:v1_comprehensive_only_401}}"));
        }
        if (_data.Condition("'V1_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V1ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V1_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V1ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V1_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CompDed);
        }
        if (_data.Condition("V1_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CompDedMoreOpt);
        }
        if (_data.Condition("V1_CollDed != NULL AND V1_CompDed != NoCoverage"))
        {
            await _ui.ClickAsync(_locators.V1CollDed);
        }
        if (_data.Condition("V1_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V1CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV2_0133_10f911Async
        await _ui.PressAsync(_locators.Option3, "PRE:scroll[8]");
        await _ui.PressAsync(_locators.Option3, "scroll[8]");
        // CoveragesNew_4d5fe6Page.SelectV2Coverages_0134_10f911Async
        if (_data.Condition("V2_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V2CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V2_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V2ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V2_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V2ComprehensiveOnly, _data.Resolve("{{data:v2_comprehensive_only_411}}"));
        }
        if (_data.Condition("'V2_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V2ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V2_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V2ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V2_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CompDed);
        }
        if (_data.Condition("V2_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CompDedMoreOpt);
        }
        if (_data.Condition("V2_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CollDed);
        }
        if (_data.Condition("V2_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V2CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV3_0135_10f911Async
        await _ui.PressAsync(_locators.CoveragesNewNext, "PRE:end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "scroll[-4]");
        // CoveragesNew_4d5fe6Page.SelectV3Coverages_0136_10f911Async
        if (_data.Condition("V3_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V3CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V3_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V3ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V3_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V3ComprehensiveOnly, _data.Resolve("{{data:v3_comprehensive_only_421}}"));
        }
        if (_data.Condition("'V3_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V3ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V3_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V3ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V3_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CompDed);
        }
        if (_data.Condition("V3_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CompDedMoreOpt);
        }
        if (_data.Condition("V3_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CollDed);
        }
        if (_data.Condition("V3_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V3CollDedMoreOpt);
        }
        // CoveragesNew_4d5fe6Page.NavigateDownScreenToV4_0137_10f911Async
        await _ui.PressAsync(_locators.CoveragesNewNext, "PRE:end");
        await _ui.PressAsync(_locators.CoveragesNewNext, "end");
        // CoveragesNew_4d5fe6Page.SelectV4Coverages_0138_10f911Async
        if (_data.Condition("V4_CompCollOnly == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.V4CompCollOnlyYES, _data.Resolve(""));
        }
        if (_data.Condition("'V4_Comprehensive Only' != NULL"))
        {
            await _ui.WaitAsync(_locators.V4ComprehensiveOnly, "Visible");
        }
        if (_data.Condition("'V4_Comprehensive Only' != NULL"))
        {
            await _ui.SmartSetAsync(_locators.V4ComprehensiveOnly, _data.Resolve("{{data:v4_comprehensive_only_431}}"));
        }
        if (_data.Condition("'V4_ Comprehensive And Collision Only' != NULL"))
        {
            await _ui.ClickAsync(_locators.V4ComprehensiveAndCollisionOnly);
        }
        if (_data.Condition("V4_CompDed != NULL"))
        {
            await _ui.VerifyAsync(_locators.V4ComprehensiveDeductible, _data.Resolve("Visible"), "");
        }
        if (_data.Condition("V4_CompDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CompDed);
        }
        if (_data.Condition("V4_CompDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CompDedMoreOpt);
        }
        if (_data.Condition("V4_CollDed != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CollDed);
        }
        if (_data.Condition("V4_CollDedMoreOpt != NULL"))
        {
            await _ui.ClickAsync(_locators.V4CollDedMoreOpt);
        }
        await _ui.ClickAsync(_locators.CoveragesNewNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0147_10f911Async
        _data.Set("Tort Option", _data.Get("Tort Option"));
        _data.Set("Income Loss Coverage", _data.Get("Income Loss Coverage"));
        _data.Set("UMPD", _data.Get("UMPD"));
        _data.Set("UIMPD", _data.Get("UIMPD"));
        _data.Set("AD&D Coverage", _data.Resolve("{{data:ad_d_coverage}}"));
        _data.Set("Inc Liab Claims Fam Mem", _data.Get("Inc Liab Claims Fam Mem"));
        _data.Set("Extraordinary Medical Benefit", _data.Get("Extraordinary Medical Benefit"));
    }

    // Business step: I complete tabs
    public async Task CompleteTabsAsync3()
    {
        // EQTabs_8481b3Page.EQTabs_0030_0dc866Async
        await _ui.ClickAsync(_locators.CloseTab);
        await _ui.FillAsync(_locators.QuoteSearchInput, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.TabsSearch);
        // EQTabs_8481b3Page.EQTabs_0031_0dc866Async
        _data.Set("QuoteNumber6", await _ui.CaptureAsync(_locators.QNum, "Text"));
        await _ui.VerifyAsync(_locators.QNum, _data.Resolve("{{runtime:QuoteNumber2}}"), "");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0032_0dc866Async
        _data.Set("QuoteNumber7", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber6]}][\"PERSONAL AUTO \"][\"\"]}"));
        _data.Set("QuoteNumber8", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber7]}][\"\\(\"][\"\"]}"));
        _data.Set("QuoteNumber9", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber8]}][\"\\)\"][\"\"]}"));
    }

}
