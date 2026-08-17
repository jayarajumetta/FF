using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class DiscountsPage
{
    private readonly DiscountsLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public DiscountsPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new DiscountsLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete discount 1
    public async Task CompleteDiscount1Async()
    {
        // EQDiscountRateTierQuestionsNEW_9e6904Page.EQDiscountRateTierQuestions_0107_8f9ff6Async
        if (_data.Condition("State == \"MD\" OR State == \"NJ\""))
        {
        await _ui.ClickAsync(_locators.ResidentiaProperty1);
        await _ui.PressAsync(_locators.ResidentiaProperty1, "end");
        await _ui.PressAsync(_locators.ResidentiaProperty1, "scroll[-2]");
        await _ui.PressAsync(_locators.ResidentiaProperty1, "Click");
        }
        // EQDiscountRateTierQuestionsNEW_9e6904Page.EQDiscountRateTierQuestions_0108_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.StateMD))
        {
        await _ui.ClickAsync(_locators.StateMD);
        }
        if (_data.Condition("State == \"NJ\""))
        {
        await _ui.ClickAsync(_locators.N1500030000);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0110_8f9ff6Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0111_8f9ff6Async
        _data.Set("Commercial Auto", _data.Get("Commercial Auto"));
        _data.Set("Special Farm Package", _data.Get("Special Farm Package"));
        _data.Set("Safe Cycle Discount", _data.Resolve("{{data:safe_cycle_discount}}"));
        _data.Set("Rider Group Discount", _data.Get("Rider Group Discount"));
        // EQDiscountNEW_c1eb96Page.EQDiscount_0112_8f9ff6Async
        if (_data.Condition("'Multi-Car Discount' !=NULL"))
        {
        await _ui.VerifyAsync(_locators.MultiCarDiscount, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:multi_car_discount_on_294}}"));
        if (_data.Condition("'Rider Group Discount' != NULL"))
        {
        await _ui.ClickAsync(_locators.RiderGroupDiscount);
        }
        if (_data.Condition("'Commercial Auto' != NULL"))
        {
        await _ui.VerifyAsync(_locators.CommercialAuto, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:commercial_auto_on_297}}"));
        if (_data.Condition("'Special Farm Package' != NULL"))
        {
        await _ui.VerifyAsync(_locators.SpecialFarmPackage, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:special_farm_package_on_299}}"));
        if (_data.Condition("'Safe Cycle Discount' != NULL"))
        {
        await _ui.ClickAsync(_locators.SafeCycleDiscount);
        }
        await _ui.FillAsync(_locators.SafeCycleDiscountDate, _data.Resolve("{{data:safe_cycle_discount_date_301}}"));
        if (_data.Condition("State == \"DE\""))
        {
        await _ui.SelectAsync(_locators.NoDefensiveDriverDiscount, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.DiscountNEWNext, "Visible");
        await _ui.ClickAsync(_locators.DiscountNEWNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0113_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.VerifyAsync(_locators.Loading, _data.Resolve("Exists"), "");
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0114_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.WaitAsync(_locators.Loading, "Exists");
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0115_8f9ff6Async
        _data.Set("PolicyCovOption", _data.Resolve("{{data:policycovoption}}"));
        _data.Set("V1_CompCollOnly", _data.Get("V1_CompCollOnly"));
        _data.Set("V1_CompDed", _data.Resolve("{{data:v1_compded}}"));
        _data.Set("V1_CompDedMoreOpt", _data.Get("V1_CompDedMoreOpt"));
        _data.Set("V1_CollDed", _data.Resolve("{{data:v1_collded}}"));
        _data.Set("V1_CollDedMoreOpt", _data.Get("V1_CollDedMoreOpt"));
        _data.Set("V2_CompCollOnly", _data.Get("V2_CompCollOnly"));
        _data.Set("V2_CompDed", _data.Resolve("{{data:v2_compded}}"));
        _data.Set("V2_CompDedMoreOpt", _data.Get("V2_CompDedMoreOpt"));
        _data.Set("V2_CollDed", _data.Resolve("{{data:v2_collded}}"));
        _data.Set("V2_CollDedMoreOpt", _data.Get("V2_CollDedMoreOpt"));
        _data.Set("V3_CompCollOnly", _data.Get("V3_CompCollOnly"));
        _data.Set("V3_CompDed", _data.Get("V3_CompDed"));
        _data.Set("V3_CompDedMoreOpt", _data.Get("V3_CollDedMoreOpt"));
        _data.Set("V3_CollDed", _data.Get("V3_CollDed"));
        _data.Set("V3_CollDedMoreOpt", _data.Get("V3_CollDedMoreOpt"));
        _data.Set("V4_CompCollOnly", _data.Get("V4_CompCollOnly"));
        _data.Set("V4_CompDed", _data.Get("V4_CompDed"));
        _data.Set("V4_CompDedMoreOpt", _data.Get("V4_CompDedMoreOpt"));
        _data.Set("V4_CollDed", _data.Get("V4_CollDed"));
        _data.Set("V4_CollDedMoreOpt", _data.Get("V4_CollDedMoreOpt"));
        _data.Set("CovOptUninsured", _data.Get("CovOptUninsured"));
        _data.Set("Supplemental UM/UIM Opt In", _data.Get("Supplemental UM/UIM Opt In"));
        _data.Set("Supplemental UM/UIM Cov", _data.Get("Supplemental UM/UIM Cov"));
    }

    // Business step: I complete discount 1
    public async Task CompleteDiscount1Async2()
    {
        // EQDiscountRateTierQuestionsNEW_9e6904Page.EQDiscountRateTierQuestions_0119_8f5301Async
        if (_data.Condition("State == \"MD\" OR State == \"NJ\""))
        {
        await _ui.ClickAsync(_locators.ResidentiaProperty1);
        await _ui.PressAsync(_locators.ResidentiaProperty1, "end");
        await _ui.PressAsync(_locators.ResidentiaProperty1, "scroll[-2]");
        await _ui.PressAsync(_locators.ResidentiaProperty1, "Click");
        }
        // EQDiscountRateTierQuestionsNEW_9e6904Page.EQDiscountRateTierQuestions_0120_8f5301Async
        if (await _ui.ExistsAsync(_locators.StateMD))
        {
        await _ui.ClickAsync(_locators.StateMD);
        }
        if (_data.Condition("State == \"NJ\""))
        {
        await _ui.ClickAsync(_locators.N1500030000);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0122_8f5301Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0123_8f5301Async
        _data.Set("Commercial Auto", _data.Get("Commercial Auto"));
        _data.Set("Special Farm Package", _data.Get("Special Farm Package"));
        _data.Set("Safe Cycle Discount", _data.Resolve("{{data:safe_cycle_discount}}"));
        _data.Set("Rider Group Discount", _data.Get("Rider Group Discount"));
        // EQDiscountNEW_c1eb96Page.EQDiscount_0124_8f5301Async
        if (_data.Condition("'Multi-Car Discount' !=NULL"))
        {
        await _ui.VerifyAsync(_locators.MultiCarDiscount, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:multi_car_discount_on_345}}"));
        if (_data.Condition("'Rider Group Discount' != NULL"))
        {
        await _ui.ClickAsync(_locators.RiderGroupDiscount);
        }
        if (_data.Condition("'Commercial Auto' != NULL"))
        {
        await _ui.VerifyAsync(_locators.CommercialAuto, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:commercial_auto_on_348}}"));
        if (_data.Condition("'Special Farm Package' != NULL"))
        {
        await _ui.VerifyAsync(_locators.SpecialFarmPackage, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:special_farm_package_on_350}}"));
        if (_data.Condition("'Safe Cycle Discount' != NULL"))
        {
        await _ui.ClickAsync(_locators.SafeCycleDiscount);
        }
        await _ui.FillAsync(_locators.SafeCycleDiscountDate, _data.Resolve("{{data:safe_cycle_discount_date_352}}"));
        if (_data.Condition("State == \"DE\""))
        {
        await _ui.SelectAsync(_locators.NoDefensiveDriverDiscount, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.DiscountNEWNext, "Visible");
        await _ui.ClickAsync(_locators.DiscountNEWNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0125_8f5301Async
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.VerifyAsync(_locators.Loading, _data.Resolve("Exists"), "");
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0126_8f5301Async
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.WaitAsync(_locators.Loading, "Exists");
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0127_8f5301Async
        _data.Set("PolicyCovOption", _data.Resolve("{{data:policycovoption}}"));
        _data.Set("V1_CompCollOnly", _data.Get("V1_CompCollOnly"));
        _data.Set("V1_CompDed", _data.Resolve("{{data:v1_compded}}"));
        _data.Set("V1_CompDedMoreOpt", _data.Get("V1_CompDedMoreOpt"));
        _data.Set("V1_CollDed", _data.Resolve("{{data:v1_collded}}"));
        _data.Set("V1_CollDedMoreOpt", _data.Get("V1_CollDedMoreOpt"));
        _data.Set("V2_CompCollOnly", _data.Get("V2_CompCollOnly"));
        _data.Set("V2_CompDed", _data.Resolve("{{data:v2_compded}}"));
        _data.Set("V2_CompDedMoreOpt", _data.Get("V2_CompDedMoreOpt"));
        _data.Set("V2_CollDed", _data.Resolve("{{data:v2_collded}}"));
        _data.Set("V2_CollDedMoreOpt", _data.Get("V2_CollDedMoreOpt"));
        _data.Set("V3_CompCollOnly", _data.Get("V3_CompCollOnly"));
        _data.Set("V3_CompDed", _data.Resolve("{{data:v3_compded}}"));
        _data.Set("V3_CompDedMoreOpt", _data.Get("V3_CollDedMoreOpt"));
        _data.Set("V3_CollDed", _data.Resolve("{{data:v3_collded}}"));
        _data.Set("V3_CollDedMoreOpt", _data.Get("V3_CollDedMoreOpt"));
        _data.Set("V4_CompCollOnly", _data.Get("V4_CompCollOnly"));
        _data.Set("V4_CompDed", _data.Resolve("{{data:v4_compded}}"));
        _data.Set("V4_CompDedMoreOpt", _data.Get("V4_CompDedMoreOpt"));
        _data.Set("V4_CollDed", _data.Resolve("{{data:v4_collded}}"));
        _data.Set("V4_CollDedMoreOpt", _data.Get("V4_CollDedMoreOpt"));
        _data.Set("CovOptUninsured", _data.Get("CovOptUninsured"));
        _data.Set("Supplemental UM/UIM Opt In", _data.Get("Supplemental UM/UIM Opt In"));
        _data.Set("Supplemental UM/UIM Cov", _data.Get("Supplemental UM/UIM Cov"));
    }

    // Business step: I complete discount 1
    public async Task CompleteDiscount1Async3()
    {
        // EQDiscountRateTierQuestionsNEW_9e6904Page.EQDiscountRateTierQuestions_0116_e2e0d7Async
        if (_data.Condition("State == \"MD\" OR State == \"NJ\""))
        {
        await _ui.ClickAsync(_locators.ResidentiaProperty1);
        await _ui.PressAsync(_locators.ResidentiaProperty1, "end");
        await _ui.PressAsync(_locators.ResidentiaProperty1, "scroll[-2]");
        await _ui.PressAsync(_locators.ResidentiaProperty1, "Click");
        }
        // EQDiscountRateTierQuestionsNEW_9e6904Page.EQDiscountRateTierQuestions_0117_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.StateMD))
        {
        await _ui.ClickAsync(_locators.StateMD);
        }
        if (_data.Condition("State == \"NJ\""))
        {
        await _ui.ClickAsync(_locators.N1500030000);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0119_e2e0d7Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0120_e2e0d7Async
        _data.Set("Commercial Auto", _data.Get("Commercial Auto"));
        _data.Set("Special Farm Package", _data.Get("Special Farm Package"));
        _data.Set("Safe Cycle Discount", _data.Get("Safe Cycle Discount"));
        _data.Set("Rider Group Discount", _data.Get("Rider Group Discount"));
        // EQDiscountNEW_c1eb96Page.EQDiscount_0121_e2e0d7Async
        if (_data.Condition("'Multi-Car Discount' !=NULL"))
        {
        await _ui.VerifyAsync(_locators.MultiCarDiscount, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:multi_car_discount_on_328}}"));
        if (_data.Condition("'Rider Group Discount' != NULL"))
        {
        await _ui.ClickAsync(_locators.RiderGroupDiscount);
        }
        if (_data.Condition("'Commercial Auto' != NULL"))
        {
        await _ui.VerifyAsync(_locators.CommercialAuto, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:commercial_auto_on_331}}"));
        if (_data.Condition("'Special Farm Package' != NULL"))
        {
        await _ui.VerifyAsync(_locators.SpecialFarmPackage, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:special_farm_package_on_333}}"));
        if (_data.Condition("'Safe Cycle Discount' != NULL"))
        {
        await _ui.ClickAsync(_locators.SafeCycleDiscount);
        }
        await _ui.FillAsync(_locators.SafeCycleDiscountDate, _data.Get("Safe Cycle Discount Date"));
        if (_data.Condition("State == \"DE\""))
        {
        await _ui.SelectAsync(_locators.NoDefensiveDriverDiscount, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.DiscountNEWNext, "Visible");
        await _ui.ClickAsync(_locators.DiscountNEWNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0122_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.VerifyAsync(_locators.Loading, _data.Resolve("Exists"), "");
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0123_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.WaitAsync(_locators.Loading, "Exists");
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0124_e2e0d7Async
        _data.Set("PolicyCovOption", _data.Resolve("{{data:policycovoption}}"));
        _data.Set("V1_CompCollOnly", _data.Get("V1_CompCollOnly"));
        _data.Set("V1_CompDed", _data.Resolve("{{data:v1_compded}}"));
        _data.Set("V1_CompDedMoreOpt", _data.Get("V1_CompDedMoreOpt"));
        _data.Set("V1_CollDed", _data.Resolve("{{data:v1_collded}}"));
        _data.Set("V1_CollDedMoreOpt", _data.Get("V1_CollDedMoreOpt"));
        _data.Set("V2_CompCollOnly", _data.Get("V2_CompCollOnly"));
        _data.Set("V2_CompDed", _data.Resolve("{{data:v2_compded}}"));
        _data.Set("V2_CompDedMoreOpt", _data.Get("V2_CompDedMoreOpt"));
        _data.Set("V2_CollDed", _data.Resolve("{{data:v2_collded}}"));
        _data.Set("V2_CollDedMoreOpt", _data.Get("V2_CollDedMoreOpt"));
        _data.Set("V3_CompCollOnly", _data.Get("V3_CompCollOnly"));
        _data.Set("V3_CompDed", _data.Resolve("{{data:v3_compded}}"));
        _data.Set("V3_CompDedMoreOpt", _data.Get("V3_CollDedMoreOpt"));
        _data.Set("V3_CollDed", _data.Resolve("{{data:v3_collded}}"));
        _data.Set("V3_CollDedMoreOpt", _data.Get("V3_CollDedMoreOpt"));
        _data.Set("V4_CompCollOnly", _data.Get("V4_CompCollOnly"));
        _data.Set("V4_CompDed", _data.Get("V4_CompDed"));
        _data.Set("V4_CompDedMoreOpt", _data.Get("V4_CompDedMoreOpt"));
        _data.Set("V4_CollDed", _data.Get("V4_CollDed"));
        _data.Set("V4_CollDedMoreOpt", _data.Get("V4_CollDedMoreOpt"));
        _data.Set("CovOptUninsured", _data.Get("CovOptUninsured"));
        _data.Set("Supplemental UM/UIM Opt In", _data.Get("Supplemental UM/UIM Opt In"));
        _data.Set("Supplemental UM/UIM Cov", _data.Get("Supplemental UM/UIM Cov"));
    }

    // Business step: I complete discount 1
    public async Task CompleteDiscount1Async4()
    {
        // EQDiscountRateTierQuestionsNEW_9e6904Page.EQDiscountRateTierQuestions_0116_bafd4aAsync
        if (_data.Condition("State == \"MD\" OR State == \"NJ\""))
        {
        await _ui.ClickAsync(_locators.ResidentiaProperty1);
        await _ui.PressAsync(_locators.ResidentiaProperty1, "end");
        await _ui.PressAsync(_locators.ResidentiaProperty1, "scroll[-2]");
        await _ui.PressAsync(_locators.ResidentiaProperty1, "Click");
        }
        // EQDiscountRateTierQuestionsNEW_9e6904Page.EQDiscountRateTierQuestions_0117_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.StateMD))
        {
        await _ui.ClickAsync(_locators.StateMD);
        }
        if (_data.Condition("State == \"NJ\""))
        {
        await _ui.ClickAsync(_locators.N1500030000);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0119_bafd4aAsync
        await _ui.WaitAsync(_locators.Loading, "Exists");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0120_bafd4aAsync
        _data.Set("Commercial Auto", _data.Get("Commercial Auto"));
        _data.Set("Special Farm Package", _data.Get("Special Farm Package"));
        _data.Set("Safe Cycle Discount", _data.Get("Safe Cycle Discount"));
        _data.Set("Rider Group Discount", _data.Get("Rider Group Discount"));
        // EQDiscountNEW_c1eb96Page.EQDiscount_0121_bafd4aAsync
        if (_data.Condition("'Multi-Car Discount' !=NULL"))
        {
        await _ui.VerifyAsync(_locators.MultiCarDiscount, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:multi_car_discount_on_328}}"));
        if (_data.Condition("'Rider Group Discount' != NULL"))
        {
        await _ui.ClickAsync(_locators.RiderGroupDiscount);
        }
        if (_data.Condition("'Commercial Auto' != NULL"))
        {
        await _ui.VerifyAsync(_locators.CommercialAuto, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:commercial_auto_on_331}}"));
        if (_data.Condition("'Special Farm Package' != NULL"))
        {
        await _ui.VerifyAsync(_locators.SpecialFarmPackage, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:special_farm_package_on_333}}"));
        if (_data.Condition("'Safe Cycle Discount' != NULL"))
        {
        await _ui.ClickAsync(_locators.SafeCycleDiscount);
        }
        await _ui.FillAsync(_locators.SafeCycleDiscountDate, _data.Get("Safe Cycle Discount Date"));
        if (_data.Condition("State == \"DE\""))
        {
        await _ui.SelectAsync(_locators.NoDefensiveDriverDiscount, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.DiscountNEWNext, "Visible");
        await _ui.ClickAsync(_locators.DiscountNEWNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0122_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.VerifyAsync(_locators.Loading, _data.Resolve("Exists"), "");
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0123_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.WaitAsync(_locators.Loading, "Exists");
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0124_bafd4aAsync
        _data.Set("PolicyCovOption", _data.Resolve("{{data:policycovoption}}"));
        _data.Set("V1_CompCollOnly", _data.Get("V1_CompCollOnly"));
        _data.Set("V1_CompDed", _data.Resolve("{{data:v1_compded}}"));
        _data.Set("V1_CompDedMoreOpt", _data.Get("V1_CompDedMoreOpt"));
        _data.Set("V1_CollDed", _data.Resolve("{{data:v1_collded}}"));
        _data.Set("V1_CollDedMoreOpt", _data.Get("V1_CollDedMoreOpt"));
        _data.Set("V2_CompCollOnly", _data.Get("V2_CompCollOnly"));
        _data.Set("V2_CompDed", _data.Resolve("{{data:v2_compded}}"));
        _data.Set("V2_CompDedMoreOpt", _data.Get("V2_CompDedMoreOpt"));
        _data.Set("V2_CollDed", _data.Resolve("{{data:v2_collded}}"));
        _data.Set("V2_CollDedMoreOpt", _data.Get("V2_CollDedMoreOpt"));
        _data.Set("V3_CompCollOnly", _data.Get("V3_CompCollOnly"));
        _data.Set("V3_CompDed", _data.Resolve("{{data:v3_compded}}"));
        _data.Set("V3_CompDedMoreOpt", _data.Get("V3_CollDedMoreOpt"));
        _data.Set("V3_CollDed", _data.Resolve("{{data:v3_collded}}"));
        _data.Set("V3_CollDedMoreOpt", _data.Get("V3_CollDedMoreOpt"));
        _data.Set("V4_CompCollOnly", _data.Get("V4_CompCollOnly"));
        _data.Set("V4_CompDed", _data.Get("V4_CompDed"));
        _data.Set("V4_CompDedMoreOpt", _data.Get("V4_CompDedMoreOpt"));
        _data.Set("V4_CollDed", _data.Get("V4_CollDed"));
        _data.Set("V4_CollDedMoreOpt", _data.Get("V4_CollDedMoreOpt"));
        _data.Set("CovOptUninsured", _data.Get("CovOptUninsured"));
        _data.Set("Supplemental UM/UIM Opt In", _data.Get("Supplemental UM/UIM Opt In"));
        _data.Set("Supplemental UM/UIM Cov", _data.Get("Supplemental UM/UIM Cov"));
    }

    // Business step: I complete discount 1
    public async Task CompleteDiscount1Async5()
    {
        // EQDiscountRateTierQuestionsNEW_9e6904Page.EQDiscountRateTierQuestions_0119_8f4c8fAsync
        if (_data.Condition("State == \"MD\" OR State == \"NJ\""))
        {
        await _ui.ClickAsync(_locators.ResidentiaProperty1);
        await _ui.PressAsync(_locators.ResidentiaProperty1, "end");
        await _ui.PressAsync(_locators.ResidentiaProperty1, "scroll[-2]");
        await _ui.PressAsync(_locators.ResidentiaProperty1, "Click");
        }
        // EQDiscountRateTierQuestionsNEW_9e6904Page.EQDiscountRateTierQuestions_0120_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.StateMD))
        {
        await _ui.ClickAsync(_locators.StateMD);
        }
        if (_data.Condition("State == \"NJ\""))
        {
        await _ui.ClickAsync(_locators.N1500030000);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0122_8f4c8fAsync
        await _ui.WaitAsync(_locators.Loading, "Exists");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0123_8f4c8fAsync
        _data.Set("Commercial Auto", _data.Get("Commercial Auto"));
        _data.Set("Special Farm Package", _data.Resolve("{{data:special_farm_package}}"));
        _data.Set("Safe Cycle Discount", _data.Get("Safe Cycle Discount"));
        _data.Set("Rider Group Discount", _data.Get("Rider Group Discount"));
        // EQDiscountNEW_c1eb96Page.EQDiscount_0124_8f4c8fAsync
        if (_data.Condition("'Multi-Car Discount' !=NULL"))
        {
        await _ui.VerifyAsync(_locators.MultiCarDiscount, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:multi_car_discount_on_345}}"));
        if (_data.Condition("'Rider Group Discount' != NULL"))
        {
        await _ui.ClickAsync(_locators.RiderGroupDiscount);
        }
        if (_data.Condition("'Commercial Auto' != NULL"))
        {
        await _ui.VerifyAsync(_locators.CommercialAuto, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:commercial_auto_on_348}}"));
        if (_data.Condition("'Special Farm Package' != NULL"))
        {
        await _ui.VerifyAsync(_locators.SpecialFarmPackage, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:special_farm_package_on_350}}"));
        if (_data.Condition("'Safe Cycle Discount' != NULL"))
        {
        await _ui.ClickAsync(_locators.SafeCycleDiscount);
        }
        await _ui.FillAsync(_locators.SafeCycleDiscountDate, _data.Get("Safe Cycle Discount Date"));
        if (_data.Condition("State == \"DE\""))
        {
        await _ui.SelectAsync(_locators.NoDefensiveDriverDiscount, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.DiscountNEWNext, "Visible");
        await _ui.ClickAsync(_locators.DiscountNEWNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0125_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.VerifyAsync(_locators.Loading, _data.Resolve("Exists"), "");
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0126_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.WaitAsync(_locators.Loading, "Exists");
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0127_8f4c8fAsync
        _data.Set("PolicyCovOption", _data.Resolve("{{data:policycovoption}}"));
        _data.Set("V1_CompCollOnly", _data.Get("V1_CompCollOnly"));
        _data.Set("V1_CompDed", _data.Resolve("{{data:v1_compded}}"));
        _data.Set("V1_CompDedMoreOpt", _data.Get("V1_CompDedMoreOpt"));
        _data.Set("V1_CollDed", _data.Resolve("{{data:v1_collded}}"));
        _data.Set("V1_CollDedMoreOpt", _data.Get("V1_CollDedMoreOpt"));
        _data.Set("V2_CompCollOnly", _data.Get("V2_CompCollOnly"));
        _data.Set("V2_CompDed", _data.Resolve("{{data:v2_compded}}"));
        _data.Set("V2_CompDedMoreOpt", _data.Get("V2_CompDedMoreOpt"));
        _data.Set("V2_CollDed", _data.Resolve("{{data:v2_collded}}"));
        _data.Set("V2_CollDedMoreOpt", _data.Get("V2_CollDedMoreOpt"));
        _data.Set("V3_CompCollOnly", _data.Get("V3_CompCollOnly"));
        _data.Set("V3_CompDed", _data.Resolve("{{data:v3_compded}}"));
        _data.Set("V3_CompDedMoreOpt", _data.Get("V3_CollDedMoreOpt"));
        _data.Set("V3_CollDed", _data.Resolve("{{data:v3_collded}}"));
        _data.Set("V3_CollDedMoreOpt", _data.Get("V3_CollDedMoreOpt"));
        _data.Set("V4_CompCollOnly", _data.Get("V4_CompCollOnly"));
        _data.Set("V4_CompDed", _data.Resolve("{{data:v4_compded}}"));
        _data.Set("V4_CompDedMoreOpt", _data.Get("V4_CompDedMoreOpt"));
        _data.Set("V4_CollDed", _data.Resolve("{{data:v4_collded}}"));
        _data.Set("V4_CollDedMoreOpt", _data.Get("V4_CollDedMoreOpt"));
        _data.Set("CovOptUninsured", _data.Get("CovOptUninsured"));
        _data.Set("Supplemental UM/UIM Opt In", _data.Get("Supplemental UM/UIM Opt In"));
        _data.Set("Supplemental UM/UIM Cov", _data.Get("Supplemental UM/UIM Cov"));
    }

    // Business step: I complete discount 1
    public async Task CompleteDiscount1Async6()
    {
        // EQDiscountRateTierQuestionsNEW_9e6904Page.EQDiscountRateTierQuestions_0119_10f911Async
        if (_data.Condition("State == \"MD\" OR State == \"NJ\""))
        {
        await _ui.ClickAsync(_locators.ResidentiaProperty1);
        await _ui.PressAsync(_locators.ResidentiaProperty1, "end");
        await _ui.PressAsync(_locators.ResidentiaProperty1, "scroll[-2]");
        await _ui.PressAsync(_locators.ResidentiaProperty1, "Click");
        }
        // EQDiscountRateTierQuestionsNEW_9e6904Page.EQDiscountRateTierQuestions_0120_10f911Async
        if (await _ui.ExistsAsync(_locators.StateMD))
        {
        await _ui.ClickAsync(_locators.StateMD);
        }
        if (_data.Condition("State == \"NJ\""))
        {
        await _ui.ClickAsync(_locators.N1500030000);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0122_10f911Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0123_10f911Async
        _data.Set("Commercial Auto", _data.Get("Commercial Auto"));
        _data.Set("Special Farm Package", _data.Get("Special Farm Package"));
        _data.Set("Safe Cycle Discount", _data.Get("Safe Cycle Discount"));
        _data.Set("Rider Group Discount", _data.Get("Rider Group Discount"));
        // EQDiscountNEW_c1eb96Page.EQDiscount_0124_10f911Async
        if (_data.Condition("'Multi-Car Discount' !=NULL"))
        {
        await _ui.VerifyAsync(_locators.MultiCarDiscount, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:multi_car_discount_on_348}}"));
        if (_data.Condition("'Rider Group Discount' != NULL"))
        {
        await _ui.ClickAsync(_locators.RiderGroupDiscount);
        }
        if (_data.Condition("'Commercial Auto' != NULL"))
        {
        await _ui.VerifyAsync(_locators.CommercialAuto, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:commercial_auto_on_351}}"));
        if (_data.Condition("'Special Farm Package' != NULL"))
        {
        await _ui.VerifyAsync(_locators.SpecialFarmPackage, _data.Resolve("Exists"), "");
        }
        await _ui.SmartSetAsync(_locators.On, _data.Resolve("{{data:special_farm_package_on_353}}"));
        if (_data.Condition("'Safe Cycle Discount' != NULL"))
        {
        await _ui.ClickAsync(_locators.SafeCycleDiscount);
        }
        await _ui.FillAsync(_locators.SafeCycleDiscountDate, _data.Get("Safe Cycle Discount Date"));
        if (_data.Condition("State == \"DE\""))
        {
        await _ui.SelectAsync(_locators.NoDefensiveDriverDiscount, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.DiscountNEWNext, "Visible");
        await _ui.ClickAsync(_locators.DiscountNEWNext);
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0125_10f911Async
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.VerifyAsync(_locators.Loading, _data.Resolve("Exists"), "");
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0126_10f911Async
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.WaitAsync(_locators.Loading, "Exists");
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0127_10f911Async
        _data.Set("PolicyCovOption", _data.Resolve("{{data:policycovoption}}"));
        _data.Set("V1_CompCollOnly", _data.Get("V1_CompCollOnly"));
        _data.Set("V1_CompDed", _data.Resolve("{{data:v1_compded}}"));
        _data.Set("V1_CompDedMoreOpt", _data.Get("V1_CompDedMoreOpt"));
        _data.Set("V1_CollDed", _data.Resolve("{{data:v1_collded}}"));
        _data.Set("V1_CollDedMoreOpt", _data.Get("V1_CollDedMoreOpt"));
        _data.Set("V2_CompCollOnly", _data.Get("V2_CompCollOnly"));
        _data.Set("V2_CompDed", _data.Resolve("{{data:v2_compded}}"));
        _data.Set("V2_CompDedMoreOpt", _data.Get("V2_CompDedMoreOpt"));
        _data.Set("V2_CollDed", _data.Resolve("{{data:v2_collded}}"));
        _data.Set("V2_CollDedMoreOpt", _data.Get("V2_CollDedMoreOpt"));
        _data.Set("V3_CompCollOnly", _data.Get("V3_CompCollOnly"));
        _data.Set("V3_CompDed", _data.Resolve("{{data:v3_compded}}"));
        _data.Set("V3_CompDedMoreOpt", _data.Get("V3_CollDedMoreOpt"));
        _data.Set("V3_CollDed", _data.Resolve("{{data:v3_collded}}"));
        _data.Set("V3_CollDedMoreOpt", _data.Get("V3_CollDedMoreOpt"));
        _data.Set("V4_CompCollOnly", _data.Get("V4_CompCollOnly"));
        _data.Set("V4_CompDed", _data.Resolve("{{data:v4_compded}}"));
        _data.Set("V4_CompDedMoreOpt", _data.Get("V4_CompDedMoreOpt"));
        _data.Set("V4_CollDed", _data.Resolve("{{data:v4_collded}}"));
        _data.Set("V4_CollDedMoreOpt", _data.Get("V4_CollDedMoreOpt"));
        _data.Set("CovOptUninsured", _data.Get("CovOptUninsured"));
        _data.Set("Supplemental UM/UIM Opt In", _data.Get("Supplemental UM/UIM Opt In"));
        _data.Set("Supplemental UM/UIM Cov", _data.Get("Supplemental UM/UIM Cov"));
    }

}