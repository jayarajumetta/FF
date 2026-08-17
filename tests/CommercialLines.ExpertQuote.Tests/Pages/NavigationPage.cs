using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class NavigationPage
{
    private readonly BrowserSession _browser;

    private readonly NavigationLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public NavigationPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _browser = browser;

        _locators = new NavigationLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I navigate to the required policy screen
    public async Task NavigateToTheRequiredPolicyScreenAsync()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0046_503012Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0047_503012Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0048_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0050_503012Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0051_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.TBoxSetBuffer_0052_503012Async
        _data.Set("PrimaryFarmCategory", _data.Resolve("{{data:primaryfarmcategory}}"));
        _data.Set("PrimaryFarmType", _data.Resolve("{{data:primaryfarmtype}}"));
        _data.Set("SecondaryFarmCategory", _data.Resolve(""));
        _data.Set("SecondaryFarmType", _data.Resolve(""));
    }

    // Business step: I navigate to the required policy screen for screen
    public async Task NavigateToTheRequiredPolicyScreenForScreenAsync()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0068_503012Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0069_503012Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0070_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_2}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0072_503012Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0073_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // EQCommonPreQualificationGeneralEligibilityRestrictionsVerifyNoneOfTheAbove_2820ccPage.GeneralEligibilityRestrictionsSynching_0074_503012Async
        await _ui.VerifyAsync(_locators.GeneralEligibilityRestrictionsSynching, _data.Resolve("Exists"), "");
    }

    // Business step: I navigate to the required policy screen for navigate to screen
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToScreenAsync()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0080_503012Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0081_503012Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0082_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_3}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0084_503012Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0085_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for navigate to correct screen
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToCorrectScreenAsync()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0097_503012Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0098_503012Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0099_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_4}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0101_503012Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0102_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // EQBOPClientDetailsEditClientRoles_8c90e7Page.SetBufferForIndexes_0103_503012Async
        _data.Set("InspectionContactIndex", _data.Resolve("{{data:inspectioncontactindex}}"));
    }

    // Business step: I navigate to the required policy screen for policy data entry
    public async Task NavigateToTheRequiredPolicyScreenForPolicyDataEntryAsync()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0107_503012Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0108_503012Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0109_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_5}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0111_503012Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0112_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0118
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0118Async()
    {
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.NavigateToCorrectScreen_0118_503012Async
        if (!await _ui.ExistsAsync(_locators.Screen25E91))
        {
            await _ui.ClickAsync(_locators.Screen25E91);
        }
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.EQCommonReviewRequiredPopUp_0119_503012Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.BufferScreenName_0120_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_6}}"));
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.EQLoadingIndicatorWait_0122_503012Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.WaitOnForCorrectScreen_0123_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeadingDCABF))
        {
            await _ui.WaitAsync(_locators.ScreenHeadingDCABF, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0174
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0174Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0174_503012Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0175_503012Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0176_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_7}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0178_503012Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0179_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0184
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0184Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0184_503012Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0185_503012Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0186_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_8}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0188_503012Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0189_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0198
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0198Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0198_503012Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0199_503012Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0200_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_9}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0202_503012Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0203_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I complete mortgagee/Loss Payee Information
    public async Task CompleteMortgageeLossPayeeInformationAsync()
    {
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPAddMortgagee_0204_503012Async
        await _ui.ClickAsync(_locators.ADDADDITIONALINTEREST);
        await _ui.ClickAsync(_locators.MortgageeSecuredParty);
        // CLEQSFPMortgageeLossPayeeInformationCLEQCommonWaitOnLoadingIndicator_683bbaPage.EQLoadingIndicatorWait_0205_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPSearchForFinancialInstitution_0206_503012Async
        await _ui.PressAsync(_locators.SearchName, "POST:ENTER");
        await _ui.PressAsync(_locators.SearchName, "Enter");
        await _ui.PressAsync(_locators.SearchName, "Tab");
        await _ui.PressAsync(_locators.SearchZipCode, "POST:TAB");
        await _ui.PressAsync(_locators.SearchZipCode, "Tab");
        await _ui.ClickAsync(_locators.ClientInfoSearch);
        // CLEQSFPMortgageeLossPayeeInformationCLEQCommonWaitOnLoadingIndicator_683bbaPage.EQLoadingIndicatorWait_0207_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPSelectFinancialInstitution_0208_503012Async
        await _ui.FillAsync(_locators.True, _data.Resolve("{{data:true_271}}"));
        await _ui.WaitAsync(_locators.LocationPrimaryLocation, "Visible");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPAddLocationResidenceInfo_0209_503012Async
        await _ui.FillAsync(_locators.LocationPrimaryLocation, _data.Resolve("{STRINGTOUPPER[1918 Avalon Ave]}*"));
        await _ui.FillAsync(_locators.Residence, _data.Resolve("{{data:residence_274}}"));
        await _ui.PressAsync(_locators.LocationPrimaryLocation, "POST:TAB");
        await _ui.PressAsync(_locators.LocationPrimaryLocation, "Tab");
        // CLEQSFPMortgageeLossPayeeInformationCLEQCommonWaitOnLoadingIndicator_683bbaPage.EQLoadingIndicatorWait_0210_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPNavigateDownScreen_0211_503012Async
        await _ui.PressAsync(_locators.AccountNumber, "POST:TAB");
        await _ui.PressAsync(_locators.AccountNumber, "Tab");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPChooseNoCopyOfDec_0212_503012Async
        await _ui.ClickAsync(_locators.CopyOfDecNo);
        // CLEQSFPMortgageeLossPayeeInformationCLEQCommonWaitOnLoadingIndicator_683bbaPage.EQLoadingIndicatorWait_0213_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPAddAccountAndDescription_0214_503012Async
        await _ui.PressAsync(_locators.AccountNumber, "POST:ENTER");
        await _ui.PressAsync(_locators.AccountNumber, "Enter");
        await _ui.PressAsync(_locators.AccountNumber, "Tab");
        await _ui.PressAsync(_locators.DescriptionOfInterest, "POST:ENTER");
        await _ui.PressAsync(_locators.DescriptionOfInterest, "Enter");
        await _ui.PressAsync(_locators.DescriptionOfInterest, "Tab");
        await _ui.PressAsync(_locators.DescriptionOfInterest, "POST:ENTER");
        await _ui.PressAsync(_locators.DescriptionOfInterest, "Enter");
        await _ui.PressAsync(_locators.DescriptionOfInterest, "Tab");
        // CLEQSFPMortgageeLossPayeeInformationCLEQCommonWaitOnLoadingIndicator_683bbaPage.EQLoadingIndicatorWait_0215_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPMarkEscrowBilled_0216_503012Async
        await _ui.ClickAsync(_locators.EscrowBilledYes);
        // CLEQSFPMortgageeLossPayeeInformationCLEQCommonWaitOnLoadingIndicator_683bbaPage.EQLoadingIndicatorWait_0217_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPClickSave_0218_503012Async
        await _ui.ClickAsync(_locators.Save);
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0219_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_10}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0220_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0221
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0221Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0221_503012Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0222_503012Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0223_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_10}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0225_503012Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0226_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0230
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0230Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0230_503012Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0231_503012Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0232_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_11}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0234_503012Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0235_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen
    public async Task NavigateToTheRequiredPolicyScreenAsync2()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0048_656be2Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0049_656be2Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0050_656be2Async
        _data.Set("Screen", _data.Resolve("{{data:screen}}"));
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenNameIfDifferent_0051_656be2Async
        _data.Set("Screen", _data.Resolve("{{data:screen_2}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0052_656be2Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0053_656be2Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for screen
    public async Task NavigateToTheRequiredPolicyScreenForScreenAsync2()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0062_656be2Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0063_656be2Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0064_656be2Async
        _data.Set("Screen", _data.Resolve("{{data:screen}}"));
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenNameIfDifferent_0065_656be2Async
        _data.Set("Screen", _data.Resolve("{{data:screen_2}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0066_656be2Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0067_656be2Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen
    public async Task NavigateToTheRequiredPolicyScreenAsync3()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0046_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0047_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0048_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0050_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0051_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // EQBOPPreQualificationSearchAndAddAClass_804217Page.EQLoadingIndicatorWait_0052_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPPreQualificationSearchAndAddAClass_804217Page.WaitForAddClassCodesToExistAndClickSearchAddClassCode_0053_d18a3eAsync
        await _ui.PressAsync(_locators.SearchAddClassCode, "POST:TAB");
        await _ui.PressAsync(_locators.SearchAddClassCode, "Tab");
        // EQBOPPreQualificationSearchAndAddAClass_804217Page.EQLoadingIndicatorWait_0054_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPPreQualificationSearchAndAddAClass_804217Page.WaitForFindAClassCodeWindowToExistAndAddTheClassCode_0055_d18a3eAsync
        await _ui.WaitAsync(_locators.FindAClassCode, "Exists");
        await _ui.FillAsync(_locators.ClassFilter, _data.Resolve("{{data:class_filter_64}}"));
        await _ui.ClickAsync(_locators.ClientInfoSearch);
        await _ui.WaitAsync(_locators.On, "Exists");
        await _ui.PressAsync(_locators.On, "POST:TAB");
        await _ui.PressAsync(_locators.On, "Tab");
        await _ui.WaitAsync(_locators.YouHaveSelected1ClassCodes, "Exists");
        await _ui.PressAsync(_locators.YouHaveSelected1ClassCodes, "POST:TAB");
        await _ui.PressAsync(_locators.YouHaveSelected1ClassCodes, "Tab");
        await _ui.ClickAsync(_locators.Add);
        // EQBOPPreQualificationSearchAndAddAClass_804217Page.EQLoadingIndicatorWait_0056_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I navigate to the required policy screen for screen
    public async Task NavigateToTheRequiredPolicyScreenForScreenAsync3()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0065_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0066_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0067_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_2}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0069_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0070_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for navigate to screen
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToScreenAsync2()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0086_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0087_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0088_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_3}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0090_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0091_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // EQBOPClientDetailsEditClientRoles_8c90e7Page.SetBufferForIndexes_0092_d18a3eAsync
        _data.Set("InspectionContactIndex", _data.Resolve("{{data:inspectioncontactindex}}"));
    }

    // Business step: I navigate to the required policy screen for navigate to correct screen
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToCorrectScreenAsync2()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0096_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0097_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0098_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_4}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0100_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0101_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for policy data entry
    public async Task NavigateToTheRequiredPolicyScreenForPolicyDataEntryAsync2()
    {
        // EQBOPPriorClaimsEnterRequiredEQCommonNavigateToScreen_d65742Page.NavigateToCorrectScreen_0107_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenDA408))
        {
            await _ui.ClickAsync(_locators.ScreenDA408);
        }
        // EQBOPPriorClaimsEnterRequiredEQCommonNavigateToScreen_d65742Page.EQCommonReviewRequiredPopUp_0108_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQBOPPriorClaimsEnterRequiredEQCommonNavigateToScreen_d65742Page.BufferScreenName_0109_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_5}}"));
        // EQBOPPriorClaimsEnterRequiredEQCommonNavigateToScreen_d65742Page.EQLoadingIndicatorWait_0111_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQBOPPriorClaimsEnterRequiredEQCommonNavigateToScreen_d65742Page.WaitOnForCorrectScreen_0112_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading69631))
        {
            await _ui.WaitAsync(_locators.ScreenHeading69631, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0143
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0143Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0143_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0144_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0145_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_6}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0147_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0148_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // EQBOPLocationsBuildingsEditALocation_13fc60Page.SetBufferForEditLocations_0149_d18a3eAsync
        _data.Set("Edit Location", _data.Resolve("{{data:edit_location}}"));
        _data.Set("Territory", _data.Resolve("{{data:territory}}"));
        // EQBOPLocationsBuildingsEditALocation_13fc60Page.EQCommonLoadingIndicatorWait_0150_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I select Own or rent and Building SQ Footage Basic
    public async Task SelectOwnOrRentAndBuildingSQFootageBasicAsync()
    {
        // EQBOPBuilding1SelectOwnOrRentAndBuildingSQFootageBasic_af74baPage.SetOwnershipAndWait_0170_d18a3eAsync
        await _ui.WaitAsync(_locators.SelectIfClientOwnsOrRentsTheBuilding, "Visible");
        if (_data.Condition("'Client Own or Rent' == \"OWN\""))
        {
            await _ui.PressAsync(_locators.OwnButton, "POST:TAB");
            await _ui.PressAsync(_locators.OwnButton, "Tab");
        }
        await _ui.WaitAsync(_locators.TotalBuildingSqFootage, "Visible");
        await _ui.WaitAsync(_locators.InsuredOccupancySqFtAngular, "Visible");
        // EQBOPBuilding1SelectOwnOrRentAndBuildingSQFootageBasic_af74baPage.NavigateDownscreen_0171_d18a3eAsync
        await _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, "SHIFTTAB");
        // EQBOPBuilding1SelectOwnOrRentAndBuildingSQFootageBasic_af74baPage.FillOutTotalBuildingSqFootage_0172_d18a3eAsync
        await _ui.PressAsync(_locators.TotalBuildingSqFootage, "POST:ENTER");
        await _ui.PressAsync(_locators.TotalBuildingSqFootage, "Enter");
        await _ui.PressAsync(_locators.TotalBuildingSqFootage, "Tab");
        // EQBOPBuilding1SelectOwnOrRentAndBuildingSQFootageBasic_af74baPage.EQLoadingIndicatorWait_0173_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding1SelectOwnOrRentAndBuildingSQFootageBasic_af74baPage.FillOutInsuredOccupancySqFt_0174_d18a3eAsync
        await _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, "POST:ENTER");
        await _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, "Enter");
        await _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, "Tab");
        await _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, "POST:TAB");
        await _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, "Tab");
        // EQBOPBuilding1SelectOwnOrRentAndBuildingSQFootageBasic_af74baPage.EQLoadingIndicatorWait_0175_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding2SelectAdditionalCoveragesBuildingFunctionalPersonalPropertyOrHabitational_eb7ffcPage.EQLoadingIndicatorWait_0176_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0266
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0266Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0266_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0267_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0268_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_7}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0270_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0271_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0272_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_8}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0273_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0274_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0275_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0276_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_8}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0278_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0279_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0285
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0285Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0285_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0286_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0287_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_9}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0289_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0290_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0310
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0310Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0310_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0311_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0312_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_10}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0314_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0315_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0316_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_9}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0317_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0318_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0319_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0320_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_9}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0322_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0323_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0324_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_10}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0325_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0326_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0327_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0328_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_10}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0330_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0331_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0336
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0336Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0336_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0337_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0338_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_11}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0340_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0341_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I open EQ in Browser
    public async Task OpenEQInBrowserAsync()
    {
        // EQCommonOpenEQInBrowser_5597edPage.OpenABrowser_0351_d18a3eAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // EQCommonOpenEQInBrowser_5597edPage.OpenBroswerAndNavigateToEQ_0362_d18a3eAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        // EQCommonOpenEQInBrowser_5597edPage.WaitOnEdgeBrowserToOpen_0363_d18a3eAsync
        await _ui.WaitAsync(_locators.BODY, "Exists");
        // EQCommonOpenEQInBrowser_5597edPage.EQLoadingIndicatorWait_0364_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQCommonOpenEQInBrowser_5597edPage.PolicyLoadSync_0365_d18a3eAsync
        await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
    }

    // Business step: I open EQ in Browser for body
    public async Task OpenEQInBrowserForBodyAsync()
    {
        // EQCommonOpenEQInBrowser_5597edPage.OpenABrowser_0469_d18a3eAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // EQCommonOpenEQInBrowser_5597edPage.OpenBroswerAndNavigateToEQ_0480_d18a3eAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        // EQCommonOpenEQInBrowser_5597edPage.WaitOnEdgeBrowserToOpen_0481_d18a3eAsync
        await _ui.WaitAsync(_locators.BODY, "Exists");
        // EQCommonOpenEQInBrowser_5597edPage.EQLoadingIndicatorWait_0482_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQCommonOpenEQInBrowser_5597edPage.PolicyLoadSync_0483_d18a3eAsync
        await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0502
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0502Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0502_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0503_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0504_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_11}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0506_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0507_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for refer to uw in eq
    public async Task NavigateToTheRequiredPolicyScreenForReferToUwInEqAsync()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0554_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0555_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0556_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_11}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0558_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0559_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // CLEQCommonRegressionReferToUWCLEQCommonWaitOnLoadingIndicator_d8c098Page.EQLoadingIndicatorWait_0560_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonRegressionReferToUW_8aa9b2Page.WaitForSync_0561_d18a3eAsync
        await Task.Delay(1000);
    }

    // Business step: I navigate to Submission Screen
    public async Task NavigateToSubmissionScreenAsync()
    {
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.NavigateToSubmissionScreen_0609_d18a3eAsync
        await _ui.WaitAsync(_locators.Submission48772, "Visible");
        await _ui.ClickAsync(_locators.Submission48772);
        // CommonSubmissionRunStoplightCommonSubmissionDetermineIfOnSubmissionPage_317abcPage.CheckToSeeSubmissionScreenHeaderExists_0610_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.SubmissionHeading))
        {
            await _ui.VerifyAsync(_locators.SubmissionHeading, _data.Resolve("Absent"), "");
        }
        // CommonSubmissionRunStoplightCommonSubmissionDetermineIfOnSubmissionPage_317abcPage.NavigateToSubmissionScreen_0611_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Submission7E601))
        {
            await _ui.PressAsync(_locators.Submission7E601, "POST:TAB");
            await _ui.PressAsync(_locators.Submission7E601, "Tab");
        }
        if (await _ui.ExistsAsync(_locators.Submission7E601))
        {
            await _ui.ClickAsync(_locators.Submission7E601);
        }
        // CommonSubmissionRunStoplightCommonSubmissionDetermineIfOnSubmissionPage_317abcPage.WaitForSynchronization_0612_d18a3eAsync
        if (_data.Condition("if determine if on submission page"))
        {
            await Task.Delay(1000);
        }
        // CommonSubmissionRunStoplightCommonSubmissionDetermineIfOnSubmissionPage_317abcPage.WaitOnSubmissionScreenToLoad_0613_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.SubmissionHeading))
        {
            await _ui.WaitAsync(_locators.SubmissionHeading, "Exists");
        }
        // CommonSubmissionRunStoplightCommonSubmissionDetermineIfOnSubmissionPage_317abcPage.N500msWaitForSyncing_0614_d18a3eAsync
        if (_data.Condition("if determine if on submission page"))
        {
            await Task.Delay(1000);
        }
    }

    // Business step: I complete retreive Policy Number After Referral
    public async Task CompleteRetreivePolicyNumberAfterReferralAsync()
    {
        // DCEQCommonTransACTRetreivePolicyNumberAfterReferral_beb7e6Page.NavigateToPolicyDetailsScreen_0761_d18a3eAsync
        await _ui.ClickAsync(_locators.ViewPolicyDetails848D5);
        // DCEQCommonTransACTRetreivePolicyNumberAfterReferral_beb7e6Page.NavigateToPolicyDetailsScreen_0762_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.PolicyDetailsE7F69))
        {
            await _ui.VerifyAsync(_locators.PolicyDetailsE7F69, _data.Resolve("Absent"), "");
        }
        // DCEQCommonTransACTRetreivePolicyNumberAfterReferral_beb7e6Page.Wait12SecondForAMaxOf60Seconds_0763_d18a3eAsync
        if (_data.Condition("during loop to Check if Policy Details Exists [max=120]"))
        {
            await Task.Delay(1000);
        }
        // DCEQCommonTransACTRetreivePolicyNumberAfterReferral_beb7e6Page.POLICYBUFFER_0764_d18a3eAsync
        _data.Set("Policy#", await _ui.CaptureAsync(_locators.PolicyNumber, "InnerText"));
    }

    // Business step: I open EQ in Browser for open a browser
    public async Task OpenEQInBrowserForOpenABrowserAsync()
    {
        // EQCommonOpenEQInBrowser_5597edPage.OpenABrowser_0786_d18a3eAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // EQCommonOpenEQInBrowser_5597edPage.OpenBroswerAndNavigateToEQ_0797_d18a3eAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        // EQCommonOpenEQInBrowser_5597edPage.WaitOnEdgeBrowserToOpen_0798_d18a3eAsync
        await _ui.WaitAsync(_locators.BODY, "Exists");
        // EQCommonOpenEQInBrowser_5597edPage.EQLoadingIndicatorWait_0799_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQCommonOpenEQInBrowser_5597edPage.PolicyLoadSync_0800_d18a3eAsync
        await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0827
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0827Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0827_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0828_d18a3eAsync
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0829_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_11}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0831_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0832_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // CLEQCommonWaitOnLoadingIndicator_59e7d3Page.EQLoadingIndicatorWait_0833_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I verify for Policy Packet
    public async Task VerifyForPolicyPacketAsync()
    {
        // CommonTransACTCheckForPolicyPacket_371871Page.TransACT_0886_d18a3eAsync
        await _ui.WaitAsync(_locators.TransACT, "Visible");
        // CommonTransACTCheckForPolicyPacket_371871Page.NavigateToPolicyDetailsScreen_0887_d18a3eAsync
        await _ui.ClickAsync(_locators.ViewPolicyDetailsC87C2);
        // CommonTransACTCheckForPolicyPacket_371871Page.NavigateToPolicyDetailsScreen_0888_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.PolicyDetailsABBA9))
        {
            await _ui.VerifyAsync(_locators.PolicyDetailsABBA9, _data.Resolve("Absent"), "");
        }
        // CommonTransACTCheckForPolicyPacket_371871Page.Wait12SecondForAMaxOf60Seconds_0889_d18a3eAsync
        if (_data.Condition("during loop to Check if Policy Details Exists [max=120]"))
        {
            await Task.Delay(1000);
        }
        // CommonTransACTCheckForPolicyPacket_371871Page.NavigateToPolicyDetailsDetails_0890_d18a3eAsync
        await _ui.WaitAsync(_locators.AttachmentsListGridRowCellExplicitName1, "Visible");
        // CommonTransACTCheckForPolicyPacket_371871Page.CheckForPolicyPacket_0891_d18a3eAsync
        await _ui.VerifyAsync(_locators.AttachmentsListGridRowCellExplicitName1, _data.Resolve("{{data:expected_row_834}}"), "");
        _data.Set("NBPolicyFormPacket", await _ui.CaptureAsync(_locators.AttachmentsListGridRowCellExplicitName3, "InnerText"));
        await _ui.VerifyAsync(_locators.AttachmentsListGridRowCellExplicitName1, _data.Resolve("{{data:expected_attachments_list_grid_row_cell_explicitname_1_836}}"), "");
        // CommonTransACTCheckForPolicyPacket_371871Page.NavigateBackToPolicyDetailsScreen_0892_d18a3eAsync
        await _ui.ClickAsync(_locators.ViewPolicy);
        await _ui.WaitAsync(_locators.TransactionType, "Visible");
    }

    // Business step: I navigate to the required policy screen
    public async Task NavigateToTheRequiredPolicyScreenAsync4()
    {
        // Common_7de90aPage.NavigateToTheTargetScreen_00450053_8fa692Async
        _data.Set("WaitOnTime", _data.Resolve("{{data:wait_on_time_2}}"));
        _data.Set("Screen", _data.Resolve("{{data:required_target_screen}}"));
        await _ui.FillAsync(_locators.PreQualification, _data.Resolve("{{data:prequalification_51}}"));
        if (_data.Condition("if the \"Review Required\" popup is displayed and the configured action is \"Keep Going\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        await _ui.WaitAsync(_locators.Loading, "Absent");
        await _ui.VerifyAsync(_locators.PreQualification, _data.Resolve("Exists"), "");
    }

    // Business step: I navigate to the required policy screen
    public async Task NavigateToTheRequiredPolicyScreenAsync5()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0046_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0047_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0048_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0050_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0051_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.TBoxSetBuffer_0052_08f3f1Async
        _data.Set("PrimaryFarmCategory", _data.Resolve("{{data:primaryfarmcategory}}"));
        _data.Set("PrimaryFarmType", _data.Resolve("{{data:primaryfarmtype}}"));
        _data.Set("SecondaryFarmCategory", _data.Resolve("{{data:secondaryfarmcategory}}"));
        _data.Set("SecondaryFarmType", _data.Resolve("{{data:secondaryfarmtype}}"));
    }

    // Business step: I navigate to the required policy screen for screen
    public async Task NavigateToTheRequiredPolicyScreenForScreenAsync4()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0068_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0069_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0070_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_2}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0072_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0073_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // EQCommonPreQualificationGeneralEligibilityRestrictionsVerifyNoneOfTheAbove_2820ccPage.GeneralEligibilityRestrictionsSynching_0074_08f3f1Async
        await _ui.VerifyAsync(_locators.GeneralEligibilityRestrictionsSynching, _data.Resolve("Exists"), "");
    }

    // Business step: I navigate to the required policy screen for navigate to screen
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToScreenAsync3()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0080_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0081_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0082_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_3}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0084_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0085_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for navigate to correct screen
    public async Task NavigateToTheRequiredPolicyScreenForNavigateToCorrectScreenAsync3()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0097_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0098_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0099_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_4}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0101_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0102_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
        // EQBOPClientDetailsEditClientRoles_8c90e7Page.SetBufferForIndexes_0103_08f3f1Async
        _data.Set("InspectionContactIndex", _data.Resolve("{{data:inspectioncontactindex}}"));
    }

    // Business step: I navigate to the required policy screen for policy data entry
    public async Task NavigateToTheRequiredPolicyScreenForPolicyDataEntryAsync3()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0107_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0108_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0109_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_5}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0111_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0112_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0118
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0118Async2()
    {
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.NavigateToCorrectScreen_0118_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen25E91))
        {
            await _ui.ClickAsync(_locators.Screen25E91);
        }
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.EQCommonReviewRequiredPopUp_0119_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.BufferScreenName_0120_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_6}}"));
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.EQLoadingIndicatorWait_0122_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.WaitOnForCorrectScreen_0123_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeadingDCABF))
        {
            await _ui.WaitAsync(_locators.ScreenHeadingDCABF, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0174
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0174Async2()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0174_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0175_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0176_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_7}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0178_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0179_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0184
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0184Async2()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0184_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0185_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0186_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_8}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0188_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0189_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I complete equipment Breakdown and Implements Coverage
    public async Task CompleteEquipmentBreakdownAndImplementsCoverageAsync()
    {
        // CLEQSFPEquipmentBreakdownAndImplementsCoverage_fcedabPage.EQSFPEquipmentBreakdowNavigateToTopOfScreen_0190_08f3f1Async
        await _ui.PressAsync(_locators.PowerGreaterThan250kwYes, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.PowerGreaterThan250kwYes, "SHIFTTAB");
        await _ui.PressAsync(_locators.PowerGreaterThan250kwYes, "HOME");
        // CLEQSFPEquipmentBreakdownAndImplementsCoverage_fcedabPage.EQSFPEquipmentBreakdownAnswerPowerQuestion_0191_08f3f1Async
        await _ui.PressAsync(_locators.PowerGreaterThan250kwNo, "POST:SCROLL[1]");
        await _ui.PressAsync(_locators.PowerGreaterThan250kwNo, "SCROLL[1]");
        // CLEQSFPEquipmentBreakdownAndImplementsCoverageCLEQCommonWaitOnLoadingIndicator_661801Page.EQLoadingIndicatorWait_0192_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPEquipmentBreakdownAndImplementsCoverage_fcedabPage.EQSFPEquipmentBreakdownAnswerLossesQuestion_0193_08f3f1Async
        await _ui.PressAsync(_locators.TwoOrMoreLossesNo, "POST:SCROLL[1]");
        await _ui.PressAsync(_locators.TwoOrMoreLossesNo, "SCROLL[1]");
        // CLEQSFPEquipmentBreakdownAndImplementsCoverageCLEQCommonWaitOnLoadingIndicator_661801Page.EQLoadingIndicatorWait_0194_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPEquipmentBreakdownAndImplementsCoverage_fcedabPage.EQSFPEquipmentBreakdownAnswerAmountQuestion_0195_08f3f1Async
        await _ui.ClickAsync(_locators.GreaterThan25000No);
        await _ui.PressAsync(_locators.CombinedDeductible, "POST:TAB");
        await _ui.PressAsync(_locators.CombinedDeductible, "Tab");
        // CLEQSFPEquipmentBreakdownAndImplementsCoverageCLEQCommonWaitOnLoadingIndicator_661801Page.EQLoadingIndicatorWait_0196_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPEquipmentBreakdownAndImplementsCoverage_fcedabPage.EQSFPEquipmentBreakdownAnswerFarmImplementsQuestion_0197_08f3f1Async
        await _ui.ClickAsync(_locators.FarmImplementsNo);
        // CLEQSFPEquipmentBreakdownAndImplementsCoverageCLEQCommonWaitOnLoadingIndicator_661801Page.EQLoadingIndicatorWait_0198_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0199_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_9}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0200_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0201
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0201Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0201_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0202_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0203_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_9}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0205_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0206_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0215
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0215Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0215_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0216_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0217_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_10}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0219_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0220_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0236
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0236Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0236_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0237_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0238_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_11}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0240_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0241_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0250
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0250Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0250_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0251_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0252_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_12}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0254_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0255_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I complete mortgagee/Loss Payee Information
    public async Task CompleteMortgageeLossPayeeInformationAsync2()
    {
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPAddMortgagee_0256_08f3f1Async
        await _ui.ClickAsync(_locators.ADDADDITIONALINTEREST);
        await _ui.ClickAsync(_locators.MortgageeSecuredParty);
        // CLEQSFPMortgageeLossPayeeInformationCLEQCommonWaitOnLoadingIndicator_683bbaPage.EQLoadingIndicatorWait_0257_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPSearchForFinancialInstitution_0258_08f3f1Async
        await _ui.PressAsync(_locators.SearchName, "POST:ENTER");
        await _ui.PressAsync(_locators.SearchName, "Enter");
        await _ui.PressAsync(_locators.SearchName, "Tab");
        await _ui.PressAsync(_locators.SearchZipCode, "POST:TAB");
        await _ui.PressAsync(_locators.SearchZipCode, "Tab");
        await _ui.ClickAsync(_locators.ClientInfoSearch);
        // CLEQSFPMortgageeLossPayeeInformationCLEQCommonWaitOnLoadingIndicator_683bbaPage.EQLoadingIndicatorWait_0259_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPSelectFinancialInstitution_0260_08f3f1Async
        await _ui.FillAsync(_locators.True, _data.Resolve("{{data:true_319}}"));
        await _ui.WaitAsync(_locators.LocationPrimaryLocation, "Visible");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPAddLocationResidenceInfo_0261_08f3f1Async
        await _ui.FillAsync(_locators.LocationPrimaryLocation, _data.Resolve("{STRINGTOUPPER[1918 Avalon Ave]}*"));
        await _ui.FillAsync(_locators.Residence, _data.Resolve("{{data:residence_322}}"));
        await _ui.PressAsync(_locators.LocationPrimaryLocation, "POST:TAB");
        await _ui.PressAsync(_locators.LocationPrimaryLocation, "Tab");
        // CLEQSFPMortgageeLossPayeeInformationCLEQCommonWaitOnLoadingIndicator_683bbaPage.EQLoadingIndicatorWait_0262_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPNavigateDownScreen_0263_08f3f1Async
        await _ui.PressAsync(_locators.AccountNumber, "POST:TAB");
        await _ui.PressAsync(_locators.AccountNumber, "Tab");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPChooseNoCopyOfDec_0264_08f3f1Async
        await _ui.ClickAsync(_locators.CopyOfDecNo);
        // CLEQSFPMortgageeLossPayeeInformationCLEQCommonWaitOnLoadingIndicator_683bbaPage.EQLoadingIndicatorWait_0265_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPAddAccountAndDescription_0266_08f3f1Async
        await _ui.PressAsync(_locators.AccountNumber, "POST:ENTER");
        await _ui.PressAsync(_locators.AccountNumber, "Enter");
        await _ui.PressAsync(_locators.AccountNumber, "Tab");
        await _ui.PressAsync(_locators.DescriptionOfInterest, "POST:ENTER");
        await _ui.PressAsync(_locators.DescriptionOfInterest, "Enter");
        await _ui.PressAsync(_locators.DescriptionOfInterest, "Tab");
        await _ui.PressAsync(_locators.DescriptionOfInterest, "POST:ENTER");
        await _ui.PressAsync(_locators.DescriptionOfInterest, "Enter");
        await _ui.PressAsync(_locators.DescriptionOfInterest, "Tab");
        // CLEQSFPMortgageeLossPayeeInformationCLEQCommonWaitOnLoadingIndicator_683bbaPage.EQLoadingIndicatorWait_0267_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPMarkEscrowBilled_0268_08f3f1Async
        await _ui.ClickAsync(_locators.EscrowBilledYes);
        // CLEQSFPMortgageeLossPayeeInformationCLEQCommonWaitOnLoadingIndicator_683bbaPage.EQLoadingIndicatorWait_0269_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPMortgageeLossPayeeInformation_ab43e0Page.EQSFPClickSave_0270_08f3f1Async
        await _ui.ClickAsync(_locators.Save);
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0271_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_13}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0272_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0273
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0273Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0273_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0274_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0275_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_13}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0277_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0278_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

    // Business step: I navigate to the required policy screen for subsequent screen 0282
    public async Task NavigateToTheRequiredPolicyScreenForSubsequentScreen0282Async()
    {
        // EQCommonNavigateToScreen_b3fe17Page.NavigateToCorrectScreen_0282_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Screen4475C))
        {
            await _ui.ClickAsync(_locators.Screen4475C);
        }
        // EQCommonNavigateToScreen_b3fe17Page.EQCommonReviewRequiredPopUp_0283_08f3f1Async
        if (_data.Condition("'Review Required - Keep Going' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.KeepGoing);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0284_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_14}}"));
        // EQCommonNavigateToScreen_b3fe17Page.EQLoadingIndicatorWait_0286_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.Loading))
        {
            await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // EQCommonNavigateToScreen_b3fe17Page.WaitOnForCorrectScreen_0287_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.WaitAsync(_locators.ScreenHeading9696C, "Exists");
        }
    }

}
