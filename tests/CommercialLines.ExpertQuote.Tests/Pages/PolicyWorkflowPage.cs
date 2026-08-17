using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class PolicyWorkflowPage
{
    private readonly BrowserSession _browser;

    private readonly PolicyWorkflowLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public PolicyWorkflowPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _browser = browser;

        _locators = new PolicyWorkflowLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I verify None of the Above
    public async Task VerifyNoneOfTheAboveAsync()
    {
        // EQCommonPreQualificationGeneralEligibilityRestrictionsVerifyNoneOfTheAbove_2820ccPage.VerifyNoneOfTheAboveStatus_0075_503012Async
        if (await _ui.ExistsAsync(_locators.UncheckedNoneOfTheAbove))
        {
            await _ui.VerifyAsync(_locators.UncheckedNoneOfTheAbove, _data.Resolve("Exists"), "");
        }
        // EQCommonPreQualificationGeneralEligibilityRestrictionsVerifyNoneOfTheAbove_2820ccPage.CheckNoneOfTheAbove_0076_503012Async
        if (await _ui.ExistsAsync(_locators.UncheckedNoneOfTheAbove))
        {
            await _ui.PressAsync(_locators.UncheckedNoneOfTheAbove, "POST:TAB");
            await _ui.PressAsync(_locators.UncheckedNoneOfTheAbove, "Tab");
        }
        if (await _ui.ExistsAsync(_locators.ResponseRequiredToContinue))
        {
            await _ui.WaitAsync(_locators.ResponseRequiredToContinue, "Exists");
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0078_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_3}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0079_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I enter Required Info
    public async Task EnterRequiredInfoAsync()
    {
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQPrimaryInsuredEnterRequiredInfoTypeSFP_0087_503012Async
        await _ui.PressAsync(_locators.ExistingClient, "POST:TAB");
        await _ui.PressAsync(_locators.ExistingClient, "Tab");
        await _ui.ClickAsync(_locators.NextSFP);
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQLoadingIndicatorWait_0088_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQPrimaryInsuredEnterRequiredInfoOther_0089_503012Async
        await _ui.PressAsync(_locators.Save, "POST:TAB");
        await _ui.PressAsync(_locators.Save, "Tab");
        await _ui.ClickAsync(_locators.Save);
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQPrimaryInsuredClickEditGeneralInfo_0090_503012Async
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.ClickAsync(_locators.EQCommonPrimaryInsuredRequired);
        }
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQLoadingIndicatorWait_0091_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQPrimaryInsuredGeneralInfoQuoteDescription_0092_503012Async
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.PressAsync(_locators.DescriptionOfOperations, "POST:TAB");
            await _ui.PressAsync(_locators.DescriptionOfOperations, "Tab");
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.PressAsync(_locators.NumberOfFulltimeEmployees, "POST:ENTER");
            await _ui.PressAsync(_locators.NumberOfFulltimeEmployees, "Enter");
            await _ui.PressAsync(_locators.NumberOfFulltimeEmployees, "Tab");
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "POST:ENTER");
            await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Enter");
            await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Tab");
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.PressAsync(_locators.NumberOfSeasonalEmployees, "POST:ENTER");
            await _ui.PressAsync(_locators.NumberOfSeasonalEmployees, "Enter");
            await _ui.PressAsync(_locators.NumberOfSeasonalEmployees, "Tab");
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.ClickAsync(_locators.Save);
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.VerifyAsync(_locators.DescriptionOfOperations, _data.Resolve("{{runtime:QuoteDescription}}"), "");
        }
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQLoadingIndicatorWait_0093_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQBOPPrimaryInsuredDetailsAnswerNoneOfTheAbove_0094_503012Async
        await _ui.PressAsync(_locators.NoneOfTheAboveCheckbox, "POST:TAB");
        await _ui.PressAsync(_locators.NoneOfTheAboveCheckbox, "Tab");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0095_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_4}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0096_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I complete edit Client Roles
    public async Task CompleteEditClientRolesAsync()
    {
        // EQBOPClientDetailsEditClientRoles_8c90e7Page.EQBOPClientDetailsClickClientRoleOnRolodex_0104_503012Async
        await _ui.PressAsync(_locators.InspectionContact, "POST:TAB");
        await _ui.PressAsync(_locators.InspectionContact, "Tab");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0105_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_5}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0106_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I add/Edit a Narrative and Verify Timestamp
    public async Task AddEditANarrativeAndVerifyTimestampAsync()
    {
        // EQCommonNarrativeAddEditANarrativeAndVerifyTimestamp_c610cbPage.EQCommonVerifyThatEditIsNotDisplayedAndTextIsLocked_0113_503012Async
        await _ui.WaitAsync(_locators.NarrativeScreenHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNarrative);
        await _ui.FillAsync(_locators.DescriptionOfTheBusinessExposuresActivitiesAndExperience, _data.Resolve("{{data:description_of_the_business_exposures_activities_and_experience_130}}"));
        if (_data.Condition("'Referred and Locked' != \"Yes\""))
        {
            await _ui.ClickAsync(_locators.Save);
        }
        await _ui.WaitAsync(_locators.UserDateAndTimestamp, "Visible");
        await _ui.VerifyAsync(_locators.UserDateAndTimestamp, _data.Resolve("{{data:expected_user_date_and_timestamp_innertext_133}}"), "NotEqual:InnerText");
        if (_data.Condition("'Referred and Locked' == \"Yes\""))
        {
            await _ui.VerifyAsync(_locators.LockedThisQuoteHasBeenSubmittedAndYouCanNoLongerMakeChangesToThisText, _data.Resolve("Exists"), "");
        }
        await _ui.FillAsync(_locators.DescriptionOfTheBusinessExposuresActivitiesAndExperience, _data.Resolve(""));
        _data.Set("NameQuoteNum", await _ui.CaptureAsync(_locators.NameAndQuoteNum8EB77, "InnerText"));
        // EQCommonNarrativeAddEditANarrativeAndVerifyTimestamp_c610cbPage.SetQuoteNum_0114_503012Async
        _data.Set("Quote_Num", _data.Resolve("{B[NameQuoteNum]}"));
        // EQCommonNarrativeAddEditANarrativeAndVerifyTimestamp_c610cbPage.SetQuoteIDBuffer_0115_503012Async
        _data.Set("QuoteID", _data.Resolve("{{runtime:Quote_Num}}"));
        _data.Set("Policy#", _data.Resolve("{{data:policy}}"));
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.BufferScreenName_0116_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_6}}"));
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.CheckIfOnCorrectScreen_0117_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeadingDCABF))
        {
            await _ui.VerifyAsync(_locators.ScreenHeadingDCABF, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I open a CLAS Browser and Search for EQ by Description 1
    public async Task OpenACLASBrowserAndSearchForEQByDescription1Async()
    {
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.OpenABrowser_0236_503012Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.OpenUrl_0247_503012Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.WaitOnEdgeBrowserToOpen_0248_503012Async
        await _ui.WaitAsync(_locators.BODY4F40D, "Exists");
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.PolicyLoadSync_0249_503012Async
        await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
    }

    // Business step: I complete restart Edge Popup
    public async Task CompleteRestartEdgePopupAsync()
    {
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CLEQCommonGeneralRestartEdgePopup_a88089Page.RestartMicrosoftEdgeMessageExists_0250_503012Async
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.VerifyAsync(_locators.EChecklistEChecklistOK, _data.Resolve("Exists"), "");
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CLEQCommonGeneralRestartEdgePopup_a88089Page.RestartMicrosoftEdgeMessageClickOK_0251_503012Async
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        }
    }

    // Business step: I open a CLAS Browser and Search for EQ by Description 1 for username
    public async Task OpenACLASBrowserAndSearchForEQByDescription1ForUsernameAsync()
    {
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.VerifyUsernameExists_0252_503012Async
        if (await _ui.ExistsAsync(_locators.UserNameE0ACD))
        {
            await _ui.VerifyAsync(_locators.UserNameE0ACD, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync()
    {
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CommonGeneralLogout_20b896Page.Logout_0253_503012Async
        if (await _ui.ExistsAsync(_locators.LoggedInUser8A0DD))
        {
            await _ui.ClickAsync(_locators.LoggedInUser8A0DD);
        }
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.ClickAsync(_locators.Logout);
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CommonGeneralLogout_20b896Page.SyncForLogOut_0254_503012Async
        if (_data.Condition("if an existing CLAS session is still logged in"))
        {
            await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CommonGeneralLogout_20b896Page.CheckForHttpErrorMsg_0255_503012Async
        if (await _ui.ExistsAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0B8256))
        {
            await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0B8256, _data.Resolve("Exists"), "");
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CommonGeneralLogout_20b896Page.ClickOKOnHttpErrorMsg_0256_503012Async
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CommonGeneralLogout_20b896Page.CheckHttpErrorMsgDoesNotExist_0257_503012Async
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.WaitAsync(_locators.EChecklistEChecklistOK, "Absent");
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CommonGeneralLogout_20b896Page.Logout_0258_503012Async
        if (await _ui.ExistsAsync(_locators.LoggedInUser8A0DD))
        {
            await _ui.ClickAsync(_locators.LoggedInUser8A0DD);
        }
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.ClickAsync(_locators.Logout);
        }
    }

    // Business step: I complete save for Later/Return to Admin
    public async Task CompleteSaveForLaterReturnToAdminAsync()
    {
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.CheckForSaveForLaterButton_0292_503012Async
        if (await _ui.ExistsAsync(_locators.SaveForLater))
        {
            await _ui.VerifyAsync(_locators.SaveForLater, _data.Resolve("Exists"), "");
        }
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.SaveForLater_0293_503012Async
        if (await _ui.ExistsAsync(_locators.SaveForLater))
        {
            await _ui.ClickAsync(_locators.SaveForLater);
        }
        if (await _ui.ExistsAsync(_locators.SaveForLaterOK))
        {
            await _ui.WaitAsync(_locators.SaveForLaterOK, "Exists");
        }
        if (await _ui.ExistsAsync(_locators.SaveForLaterOK))
        {
            await _ui.ClickAsync(_locators.SaveForLaterOK);
        }
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.CheckForReturnToAdminButton_0294_503012Async
        if (await _ui.ExistsAsync(_locators.ReturnToAdmin))
        {
            await _ui.VerifyAsync(_locators.ReturnToAdmin, _data.Resolve("Exists"), "");
        }
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.ReturnToAdmin_0295_503012Async
        if (await _ui.ExistsAsync(_locators.ReturnToAdmin))
        {
            await _ui.ClickAsync(_locators.ReturnToAdmin);
        }
        if (await _ui.ExistsAsync(_locators.ReturnToAdmin))
        {
            await _ui.WaitAsync(_locators.ReturnToAdmin, "Absent");
        }
    }

    // Business step: I complete quote Identifying and Close Quote
    public async Task CompleteQuoteIdentifyingAndCloseQuoteAsync()
    {
        // CLEQCommonQuoteIdentifyingAndCloseQuote_dc9b37Page.QuoteIdentifying_0054_656be2Async
        _data.Set("Quote_NameNum", await _ui.CaptureAsync(_locators.NameAndQuote, "InnerText"));
        // CLEQCommonQuoteIdentifyingAndCloseQuote_dc9b37Page.SetBufferForQuoteNumId_0055_656be2Async
        _data.Set("Quote_Num", _data.Resolve("{STRINGREPLACE[{B[Quote_NameNum]}][{B[LastName]}][]}"));
        _data.Set("QuoteID", _data.Resolve("{{runtime:Quote_Num}}"));
        // CLEQCommonQuoteIdentifyingAndCloseQuote_dc9b37Page.CloseQuote_0056_656be2Async
        await _ui.ClickAsync(_locators.CloseQuote);
        // CLEQCommonSearchByQuoteNumCLEQCommonWaitOnLoadingIndicator_1394d4Page.EQLoadingIndicatorWait_0057_656be2Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I search by QuoteNum
    public async Task SearchByQuoteNumAsync()
    {
        // CLEQCommonSearchByQuoteNum_882b64Page.SearchByQuoteNum_0058_656be2Async
        await _ui.FillAsync(_locators.QuoteSearchInput, _data.Resolve("{B[Quote_Num]}"));
        await _ui.PressAsync(_locators.QuoteSearchInput, "Tab");
        await _ui.PressAsync(_locators.QuoteSearchInput, "Tab");
        await _ui.ClickAsync(_locators.ClientInfoSearch);
        // CLEQCommonSearchByQuoteNumCLEQCommonWaitOnLoadingIndicator_1394d4Page.EQLoadingIndicatorWait_0059_656be2Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0060_656be2Async
        _data.Set("Screen", _data.Resolve("{{data:screen}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0061_656be2Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I complete verifying Quote
    public async Task CompleteVerifyingQuoteAsync()
    {
        // CLEQCommonVerifyingQuote_2234c0Page.QuoteIdentifying_0068_656be2Async
        await _ui.VerifyAsync(_locators.NameAndQuote, _data.Resolve("{{data:expected_name_and_quote_innertext_78}}"), "InnerText");
    }

    // Business step: I enter Required Info
    public async Task EnterRequiredInfoAsync2()
    {
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQPrimaryInsuredEnterRequiredInfoTypeBOP_0071_d18a3eAsync
        await _ui.PressAsync(_locators.ExistingClient, "POST:TAB");
        await _ui.PressAsync(_locators.ExistingClient, "Tab");
        await _ui.ClickAsync(_locators.NextBOP);
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQLoadingIndicatorWait_0073_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQPrimaryInsuredEnterRequiredInfoOther_0074_d18a3eAsync
        await _ui.ClickAsync(_locators.IndividualSoleProprietor);
        await _ui.PressAsync(_locators.Save, "POST:TAB");
        await _ui.PressAsync(_locators.Save, "Tab");
        await _ui.ClickAsync(_locators.Save);
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQPrimaryInsuredClickEditGeneralInfo_0075_d18a3eAsync
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.ClickAsync(_locators.EQCommonPrimaryInsuredRequired);
        }
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQLoadingIndicatorWait_0076_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQPrimaryInsuredGeneralInfoQuoteDescription_0077_d18a3eAsync
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.PressAsync(_locators.DescriptionOfOperations, "POST:ENTER");
            await _ui.PressAsync(_locators.DescriptionOfOperations, "Enter");
            await _ui.PressAsync(_locators.DescriptionOfOperations, "Tab");
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.PressAsync(_locators.NumberOfFulltimeEmployees, "POST:ENTER");
            await _ui.PressAsync(_locators.NumberOfFulltimeEmployees, "Enter");
            await _ui.PressAsync(_locators.NumberOfFulltimeEmployees, "Tab");
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "POST:ENTER");
            await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Enter");
            await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Tab");
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.PressAsync(_locators.NumberOfSeasonalEmployees, "POST:ENTER");
            await _ui.PressAsync(_locators.NumberOfSeasonalEmployees, "Enter");
            await _ui.PressAsync(_locators.NumberOfSeasonalEmployees, "Tab");
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.ClickAsync(_locators.Save);
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.VerifyAsync(_locators.DescriptionOfOperations, _data.Resolve("{{runtime:QuoteDescription}}"), "");
        }
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQLoadingIndicatorWait_0078_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPPrimaryInsuredDetailsGeneralUWQuestions_e3bc3bPage.EQLoadingIndicatorWait_0080_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I complete edit Client Roles
    public async Task CompleteEditClientRolesAsync2()
    {
        // EQBOPClientDetailsEditClientRoles_8c90e7Page.EQBOPClientDetailsClickClientRoleOnRolodex_0093_d18a3eAsync
        await _ui.PressAsync(_locators.InspectionContact, "POST:TAB");
        await _ui.PressAsync(_locators.InspectionContact, "Tab");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0094_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_4}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0095_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I add/Edit a Narrative and Verify Timestamp
    public async Task AddEditANarrativeAndVerifyTimestampAsync2()
    {
        // EQCommonNarrativeAddEditANarrativeAndVerifyTimestamp_c610cbPage.EQCommonVerifyThatEditIsNotDisplayedAndTextIsLocked_0102_d18a3eAsync
        await _ui.WaitAsync(_locators.NarrativeScreenHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNarrative);
        await _ui.FillAsync(_locators.DescriptionOfTheBusinessExposuresActivitiesAndExperience, _data.Resolve("{{data:description_of_the_business_exposures_activities_and_experience_118}}"));
        if (_data.Condition("'Referred and Locked' != \"Yes\""))
        {
            await _ui.ClickAsync(_locators.Save);
        }
        await _ui.WaitAsync(_locators.UserDateAndTimestamp, "Visible");
        await _ui.VerifyAsync(_locators.UserDateAndTimestamp, _data.Resolve("{{data:expected_user_date_and_timestamp_innertext_121}}"), "NotEqual:InnerText");
        if (_data.Condition("'Referred and Locked' == \"Yes\""))
        {
            await _ui.VerifyAsync(_locators.LockedThisQuoteHasBeenSubmittedAndYouCanNoLongerMakeChangesToThisText, _data.Resolve("Exists"), "");
        }
        await _ui.FillAsync(_locators.DescriptionOfTheBusinessExposuresActivitiesAndExperience, _data.Resolve(""));
        _data.Set("NameQuoteNum", await _ui.CaptureAsync(_locators.NameAndQuoteNum8EB77, "InnerText"));
        // EQCommonNarrativeAddEditANarrativeAndVerifyTimestamp_c610cbPage.SetQuoteNum_0103_d18a3eAsync
        _data.Set("Quote_Num", _data.Resolve("{B[NameQuoteNum]}"));
        // EQCommonNarrativeAddEditANarrativeAndVerifyTimestamp_c610cbPage.SetQuoteIDBuffer_0104_d18a3eAsync
        _data.Set("QuoteID", _data.Resolve("{{runtime:Quote_Num}}"));
        _data.Set("Policy#", _data.Resolve("{{data:policy}}"));
        // EQBOPPriorClaimsEnterRequiredEQCommonNavigateToScreen_d65742Page.BufferScreenName_0105_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_5}}"));
        // EQBOPPriorClaimsEnterRequiredEQCommonNavigateToScreen_d65742Page.CheckIfOnCorrectScreen_0106_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading69631))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading69631, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I complete restart Edge Popup
    public async Task CompleteRestartEdgePopupAsync2()
    {
        // EQCommonOpenEQInBrowserCLEQCommonGeneralRestartEdgePopup_d7303fPage.RestartMicrosoftEdgeMessageExists_0366_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.VerifyAsync(_locators.EChecklistEChecklistOK, _data.Resolve("Exists"), "");
        }
        // EQCommonOpenEQInBrowserCLEQCommonGeneralRestartEdgePopup_d7303fPage.RestartMicrosoftEdgeMessageClickOK_0367_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        }
        // EQCommonOpenEQInBrowser_5597edPage.EQLoadingIndicatorWait_0370_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I open EQ in Browser for logout
    public async Task OpenEQInBrowserForLogoutAsync()
    {
        // EQCommonOpenEQInBrowser_5597edPage.EQCommonCheckIfLogoutExists_0371_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.VerifyAsync(_locators.Logout, _data.Resolve("Exists"), "");
        }
        // EQCommonOpenEQInBrowser_5597edPage.EQCommonClickLogoutOfEQ_0372_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.ClickAsync(_locators.Logout);
        }
        if (await _ui.ExistsAsync(_locators.LogoutLogOut))
        {
            await _ui.ClickAsync(_locators.LogoutLogOut);
        }
    }

    // Business step: I search by QuoteNum
    public async Task SearchByQuoteNumAsync2()
    {
        // CLEQCommonSearchByQuoteNum_882b64Page.SearchByQuoteNum_0376_d18a3eAsync
        await _ui.FillAsync(_locators.QuoteSearchInput, _data.Resolve("{B[Quote_Num]}"));
        await _ui.PressAsync(_locators.QuoteSearchInput, "Tab");
        await _ui.PressAsync(_locators.QuoteSearchInput, "Tab");
        await _ui.ClickAsync(_locators.ClientInfoSearch);
        // CLEQCommonSearchByQuoteNumCLEQCommonWaitOnLoadingIndicator_1394d4Page.EQLoadingIndicatorWait_0377_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I search Results Table
    public async Task SearchResultsTableAsync()
    {
        // CLEQCommonSearchResultsTable_9c0390Page.CLEQCommonSearchPolicyResultsTable_0378_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.ResultsTABLE))
        {
            await _ui.VerifyAsync(_locators.ResultsTABLE, _data.Resolve("Exists"), "");
        }
        // CLEQCommonSearchResultsTable_9c0390Page.CLEQCommonSearchPolicyResultsTable_0379_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.ResultsTABLERowCellExplicitNameName))
        {
            await _ui.VerifyAsync(_locators.ResultsTABLERowCellExplicitNameName, _data.Resolve("{STRINGTOUPPER[{B[LastName]}, {B[FirstName]}]}"), "");
        }
        if (await _ui.ExistsAsync(_locators.Edit))
        {
            await _ui.ClickAsync(_locators.Edit);
        }
        // CLEQCommonSearchResultsTable_9c0390Page.WaitonNameAndQuoteNum_0380_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.NameAndQuoteNumCA893))
        {
            await _ui.WaitAsync(_locators.NameAndQuoteNumCA893, "NotEqual");
        }
        // CLEQCommonSearchResultsTable_9c0390Page.VerifyQuoteNum_0381_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.NameAndQuoteNumCA893))
        {
            await _ui.VerifyAsync(_locators.NameAndQuoteNumCA893, _data.Resolve("{B[NameQuoteNum]}|{B[Quote_Num]}|{B[Policy#]}"), "Regex:InnerText");
        }
    }

    // Business step: I open a CLAS Browser and Search for EQ by Description
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionAsync()
    {
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.OpenABrowser_0382_d18a3eAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.OpenUrl_0393_d18a3eAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_3}}"));
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.WaitOnEdgeBrowserToOpen_0394_d18a3eAsync
        await _ui.WaitAsync(_locators.BODYABC33, "Exists");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.PolicyLoadSync_0395_d18a3eAsync
        await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.EdgePopupMessageImageBased_0396_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Button))
        {
            await _ui.VerifyAsync(_locators.Button, _data.Resolve("Exists"), "");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.EdgePopupMessageImageBased_0397_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Button))
        {
            await _ui.ClickAsync(_locators.Button);
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.VerifyUsernameExists_0398_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.UserNameE65A8))
        {
            await _ui.VerifyAsync(_locators.UserNameE65A8, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync2()
    {
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCommonGeneralLogout_708864Page.Logout_0399_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoggedInUser5A005))
        {
            await _ui.ClickAsync(_locators.LoggedInUser5A005);
        }
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.ClickAsync(_locators.Logout);
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCommonGeneralLogout_708864Page.SyncForLogOut_0400_d18a3eAsync
        if (_data.Condition("if an existing CLAS session is still logged in"))
        {
            await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCommonGeneralLogout_708864Page.CheckForHttpErrorMsg_0401_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740))
        {
            await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740, _data.Resolve("Exists"), "");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCommonGeneralLogout_708864Page.ClickOKOnHttpErrorMsg_0402_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCommonGeneralLogout_708864Page.CheckHttpErrorMsgDoesNotExist_0403_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.WaitAsync(_locators.EChecklistEChecklistOK, "Absent");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCommonGeneralLogout_708864Page.Logout_0404_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoggedInUser5A005))
        {
            await _ui.ClickAsync(_locators.LoggedInUser5A005);
        }
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.ClickAsync(_locators.Logout);
        }
    }

    // Business step: I search by Desc in DC
    public async Task SearchByDescInDCAsync()
    {
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDC_ab1b36Page.EnterDescInQuickSearch_0409_d18a3eAsync
        await _ui.FillAsync(_locators.SearchText, _data.Resolve("{B[QuoteDescription]}"));
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.ClickAsync(_locators.QuickSearchButton);
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDC_ab1b36Page.EnterInfoToSearchByDesc_0410_d18a3eAsync
        await _ui.PressAsync(_locators.SearchMethodEGDescriptionPolicy, "POST:TAB");
        await _ui.PressAsync(_locators.SearchMethodEGDescriptionPolicy, "Tab");
        await _ui.WaitAsync(_locators.SearchButton, "Equal");
        await _ui.PressAsync(_locators.SearchButton, "POST:TAB");
        await _ui.PressAsync(_locators.SearchButton, "Tab");
        await _ui.ClickAsync(_locators.SearchButton);
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDCDCEQCommonGeneralWaitOnLoadingI_428cf1Page.CheckForLoadingIndicator_0411_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoadingMessageC7A0D))
        {
            await _ui.VerifyAsync(_locators.LoadingMessageC7A0D, _data.Resolve("Visible"), "");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDCDCEQCommonGeneralWaitOnLoadingI_428cf1Page.Wait2Secs_0412_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDC_ab1b36Page.ClickSearchByDesc_0413_d18a3eAsync
        await _ui.WaitAsync(_locators.ViewPolicy56E09, "Exists");
        await _ui.PressAsync(_locators.ViewPolicy56E09, "POST:TAB");
        await _ui.PressAsync(_locators.ViewPolicy56E09, "Tab");
        await _ui.PressAsync(_locators.SearchButton, "POST:TAB");
        await _ui.PressAsync(_locators.SearchButton, "Tab");
        await _ui.ClickAsync(_locators.SearchButton);
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDCDCEQCommonGeneralWaitOnLoadingI_428cf1Page.CheckForLoadingIndicator_0414_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoadingMessageC7A0D))
        {
            await _ui.VerifyAsync(_locators.LoadingMessageC7A0D, _data.Resolve("Visible"), "");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDCDCEQCommonGeneralWaitOnLoadingI_428cf1Page.Wait2Secs_0415_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I open a CLAS Browser and Search for EQ by Description for view policy
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForViewPolicyAsync()
    {
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.VerifyViewPolicy_0416_d18a3eAsync
        await _ui.WaitAsync(_locators.ViewPolicy0AC0B, "Exists");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionDCEQCommonGeneralWaitOnLoadingIndicator_3822baPage.CheckForLoadingIndicator_0417_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoadingMessage4DE37))
        {
            await _ui.VerifyAsync(_locators.LoadingMessage4DE37, _data.Resolve("Visible"), "");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionDCEQCommonGeneralWaitOnLoadingIndicator_3822baPage.Wait2Secs_0418_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.ClickViewPolicy_0419_d18a3eAsync
        await _ui.ClickAsync(_locators.ViewPolicy0AC0B);
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionDCEQCommonGeneralWaitOnLoadingIndicator_3822baPage.CheckForLoadingIndicator_0420_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoadingMessage4DE37))
        {
            await _ui.VerifyAsync(_locators.LoadingMessage4DE37, _data.Resolve("Visible"), "");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionDCEQCommonGeneralWaitOnLoadingIndicator_3822baPage.Wait2Secs_0421_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.WaitUntilViewPolicyDoesNotExist_0422_d18a3eAsync
        await _ui.WaitAsync(_locators.ViewPolicy0AC0B, "Absent");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.PolicyLoadSync_0423_d18a3eAsync
        await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
    }

    // Business step: I complete save for Later/Return to Admin
    public async Task CompleteSaveForLaterReturnToAdminAsync2()
    {
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.CheckForSaveForLaterButton_0465_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.SaveForLater))
        {
            await _ui.VerifyAsync(_locators.SaveForLater, _data.Resolve("Exists"), "");
        }
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.SaveForLater_0466_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.SaveForLater))
        {
            await _ui.ClickAsync(_locators.SaveForLater);
        }
        if (await _ui.ExistsAsync(_locators.SaveForLaterOK))
        {
            await _ui.WaitAsync(_locators.SaveForLaterOK, "Exists");
        }
        if (await _ui.ExistsAsync(_locators.SaveForLaterOK))
        {
            await _ui.ClickAsync(_locators.SaveForLaterOK);
        }
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.CheckForReturnToAdminButton_0467_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.ReturnToAdmin))
        {
            await _ui.VerifyAsync(_locators.ReturnToAdmin, _data.Resolve("Exists"), "");
        }
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.ReturnToAdmin_0468_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.ReturnToAdmin))
        {
            await _ui.ClickAsync(_locators.ReturnToAdmin);
        }
        if (await _ui.ExistsAsync(_locators.ReturnToAdmin))
        {
            await _ui.WaitAsync(_locators.ReturnToAdmin, "Absent");
        }
    }

    // Business step: I complete restart Edge Popup for ok
    public async Task CompleteRestartEdgePopupForOkAsync()
    {
        // EQCommonOpenEQInBrowserCLEQCommonGeneralRestartEdgePopup_d7303fPage.RestartMicrosoftEdgeMessageExists_0484_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.VerifyAsync(_locators.EChecklistEChecklistOK, _data.Resolve("Exists"), "");
        }
        // EQCommonOpenEQInBrowserCLEQCommonGeneralRestartEdgePopup_d7303fPage.RestartMicrosoftEdgeMessageClickOK_0485_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        }
        // EQCommonOpenEQInBrowser_5597edPage.EQLoadingIndicatorWait_0488_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I open EQ in Browser for open eq in browser
    public async Task OpenEQInBrowserForOpenEqInBrowserAsync()
    {
        // EQCommonOpenEQInBrowser_5597edPage.EQCommonCheckIfLogoutExists_0489_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.VerifyAsync(_locators.Logout, _data.Resolve("Exists"), "");
        }
        // EQCommonOpenEQInBrowser_5597edPage.EQCommonClickLogoutOfEQ_0490_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.ClickAsync(_locators.Logout);
        }
        if (await _ui.ExistsAsync(_locators.LogoutLogOut))
        {
            await _ui.ClickAsync(_locators.LogoutLogOut);
        }
    }

    // Business step: I search by QuoteNum for quotesearchinput
    public async Task SearchByQuoteNumForQuotesearchinputAsync()
    {
        // CLEQCommonSearchByQuoteNum_882b64Page.SearchByQuoteNum_0494_d18a3eAsync
        await _ui.FillAsync(_locators.QuoteSearchInput, _data.Resolve("{B[Quote_Num]}"));
        await _ui.PressAsync(_locators.QuoteSearchInput, "Tab");
        await _ui.PressAsync(_locators.QuoteSearchInput, "Tab");
        await _ui.ClickAsync(_locators.ClientInfoSearch);
        // CLEQCommonSearchByQuoteNumCLEQCommonWaitOnLoadingIndicator_1394d4Page.EQLoadingIndicatorWait_0495_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I search Results Table for results table
    public async Task SearchResultsTableForResultsTableAsync()
    {
        // CLEQCommonSearchResultsTable_9c0390Page.CLEQCommonSearchPolicyResultsTable_0496_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.ResultsTABLE))
        {
            await _ui.VerifyAsync(_locators.ResultsTABLE, _data.Resolve("Exists"), "");
        }
        // CLEQCommonSearchResultsTable_9c0390Page.CLEQCommonSearchPolicyResultsTable_0497_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.ResultsTABLERowCellExplicitNameName))
        {
            await _ui.VerifyAsync(_locators.ResultsTABLERowCellExplicitNameName, _data.Resolve("{STRINGTOUPPER[{B[LastName]}, {B[FirstName]}]}"), "");
        }
        if (await _ui.ExistsAsync(_locators.Edit))
        {
            await _ui.ClickAsync(_locators.Edit);
        }
        // CLEQCommonSearchResultsTable_9c0390Page.WaitonNameAndQuoteNum_0498_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.NameAndQuoteNumCA893))
        {
            await _ui.WaitAsync(_locators.NameAndQuoteNumCA893, "NotEqual");
        }
        // CLEQCommonSearchResultsTable_9c0390Page.VerifyQuoteNum_0499_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.NameAndQuoteNumCA893))
        {
            await _ui.VerifyAsync(_locators.NameAndQuoteNumCA893, _data.Resolve("{B[NameQuoteNum]}|{B[Quote_Num]}|{B[Policy#]}"), "Regex:InnerText");
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0500_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_11}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0501_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I select OK
    public async Task SelectOKAsync()
    {
        // CLEQCommonEsignatureClickOK_cae8f6Page.CLEQEsignatureClickOK_0520_d18a3eAsync
        await _ui.ClickAsync(_locators.OkToUpdateFromChecklist);
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0552_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_11}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0553_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I open a CLAS Browser and Search for EQ by Description for body
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForBodyAsync()
    {
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.OpenABrowser_0563_d18a3eAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.OpenUrl_0574_d18a3eAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_3}}"));
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.WaitOnEdgeBrowserToOpen_0575_d18a3eAsync
        await _ui.WaitAsync(_locators.BODYABC33, "Exists");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.PolicyLoadSync_0576_d18a3eAsync
        await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.EdgePopupMessageImageBased_0577_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Button))
        {
            await _ui.VerifyAsync(_locators.Button, _data.Resolve("Exists"), "");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.EdgePopupMessageImageBased_0578_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Button))
        {
            await _ui.ClickAsync(_locators.Button);
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.VerifyUsernameExists_0579_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.UserNameE65A8))
        {
            await _ui.VerifyAsync(_locators.UserNameE65A8, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I sign out of the application for logged in user
    public async Task SignOutOfTheApplicationForLoggedInUserAsync()
    {
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCommonGeneralLogout_708864Page.Logout_0580_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoggedInUser5A005))
        {
            await _ui.ClickAsync(_locators.LoggedInUser5A005);
        }
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.ClickAsync(_locators.Logout);
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCommonGeneralLogout_708864Page.SyncForLogOut_0581_d18a3eAsync
        if (_data.Condition("if an existing CLAS session is still logged in"))
        {
            await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCommonGeneralLogout_708864Page.CheckForHttpErrorMsg_0582_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740))
        {
            await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740, _data.Resolve("Exists"), "");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCommonGeneralLogout_708864Page.ClickOKOnHttpErrorMsg_0583_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCommonGeneralLogout_708864Page.CheckHttpErrorMsgDoesNotExist_0584_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.WaitAsync(_locators.EChecklistEChecklistOK, "Absent");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCommonGeneralLogout_708864Page.Logout_0585_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoggedInUser5A005))
        {
            await _ui.ClickAsync(_locators.LoggedInUser5A005);
        }
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.ClickAsync(_locators.Logout);
        }
    }

    // Business step: I search by Desc in DC for search text
    public async Task SearchByDescInDCForSearchTextAsync()
    {
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDC_ab1b36Page.EnterDescInQuickSearch_0590_d18a3eAsync
        await _ui.FillAsync(_locators.SearchText, _data.Resolve("{B[QuoteDescription]}"));
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.ClickAsync(_locators.QuickSearchButton);
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDC_ab1b36Page.EnterInfoToSearchByDesc_0591_d18a3eAsync
        await _ui.PressAsync(_locators.SearchMethodEGDescriptionPolicy, "POST:TAB");
        await _ui.PressAsync(_locators.SearchMethodEGDescriptionPolicy, "Tab");
        await _ui.WaitAsync(_locators.SearchButton, "Equal");
        await _ui.PressAsync(_locators.SearchButton, "POST:TAB");
        await _ui.PressAsync(_locators.SearchButton, "Tab");
        await _ui.ClickAsync(_locators.SearchButton);
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDCDCEQCommonGeneralWaitOnLoadingI_428cf1Page.CheckForLoadingIndicator_0592_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoadingMessageC7A0D))
        {
            await _ui.VerifyAsync(_locators.LoadingMessageC7A0D, _data.Resolve("Visible"), "");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDCDCEQCommonGeneralWaitOnLoadingI_428cf1Page.Wait2Secs_0593_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDC_ab1b36Page.ClickSearchByDesc_0594_d18a3eAsync
        await _ui.WaitAsync(_locators.ViewPolicy56E09, "Exists");
        await _ui.PressAsync(_locators.ViewPolicy56E09, "POST:TAB");
        await _ui.PressAsync(_locators.ViewPolicy56E09, "Tab");
        await _ui.PressAsync(_locators.SearchButton, "POST:TAB");
        await _ui.PressAsync(_locators.SearchButton, "Tab");
        await _ui.ClickAsync(_locators.SearchButton);
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDCDCEQCommonGeneralWaitOnLoadingI_428cf1Page.CheckForLoadingIndicator_0595_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoadingMessageC7A0D))
        {
            await _ui.VerifyAsync(_locators.LoadingMessageC7A0D, _data.Resolve("Visible"), "");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionCLEQCommonSearchByDescInDCDCEQCommonGeneralWaitOnLoadingI_428cf1Page.Wait2Secs_0596_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I open a CLAS Browser and Search for EQ by Description for verify view policy
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForVerifyViewPolicyAsync()
    {
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.VerifyViewPolicy_0597_d18a3eAsync
        await _ui.WaitAsync(_locators.ViewPolicy0AC0B, "Exists");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionDCEQCommonGeneralWaitOnLoadingIndicator_3822baPage.CheckForLoadingIndicator_0598_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoadingMessage4DE37))
        {
            await _ui.VerifyAsync(_locators.LoadingMessage4DE37, _data.Resolve("Visible"), "");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionDCEQCommonGeneralWaitOnLoadingIndicator_3822baPage.Wait2Secs_0599_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.ClickViewPolicy_0600_d18a3eAsync
        await _ui.ClickAsync(_locators.ViewPolicy0AC0B);
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionDCEQCommonGeneralWaitOnLoadingIndicator_3822baPage.CheckForLoadingIndicator_0601_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoadingMessage4DE37))
        {
            await _ui.VerifyAsync(_locators.LoadingMessage4DE37, _data.Resolve("Visible"), "");
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescriptionDCEQCommonGeneralWaitOnLoadingIndicator_3822baPage.Wait2Secs_0602_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.WaitUntilViewPolicyDoesNotExist_0603_d18a3eAsync
        await _ui.WaitAsync(_locators.ViewPolicy0AC0B, "Absent");
    }

    // Business step: I complete alert Error Check
    public async Task CompleteAlertErrorCheckAsync()
    {
        // DCEQCommonSubmissionReferApplicationPolicyCommonGeneralAlertErrorCheck_c6c7f3Page.AlertError_0746_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe))
        {
            await _ui.VerifyAsync(_locators.AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe, _data.Resolve("Exists"), "");
        }
        // DCEQCommonSubmissionReferApplicationPolicyCommonGeneralAlertErrorCheck_c6c7f3Page.SetBufferForError_0747_d18a3eAsync
        _data.Set("Alert Error", _data.Resolve("{{data:alert_error}}"));
        // DCEQCommonSubmissionReferApplicationPolicyCommonGeneralAlertErrorCheck_c6c7f3Page.ForceAFail_0748_d18a3eAsync
        if (_data.Condition("while check for IFRAME"))
        {
            _data.Set("ForceAFail", _data.Resolve("{\"Expression\": \"{B[Alert Error]} == 'TRUE'\"}"));
        }
        // DCEQCommonSubmissionReferApplicationPolicyCommonGeneralAlertErrorCheck_c6c7f3Page.IFrame_0749_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.IFRAME))
        {
            await _ui.VerifyAsync(_locators.IFRAME, _data.Resolve("Exists"), "");
        }
        // DCEQCommonSubmissionReferApplicationPolicyCommonGeneralAlertErrorCheck_c6c7f3Page.AlertError_0750_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.IFRAMEDuckCreekPolicyAlertErrorMessage))
        {
            await _ui.VerifyAsync(_locators.IFRAMEDuckCreekPolicyAlertErrorMessage, _data.Resolve("Exists"), "");
        }
        // DCEQCommonSubmissionReferApplicationPolicyCommonGeneralAlertErrorCheck_c6c7f3Page.SetBufferForError_0751_d18a3eAsync
        _data.Set("Alert Error", _data.Resolve("{{data:alert_error}}"));
        // DCEQCommonSubmissionReferApplicationPolicyCommonGeneralAlertErrorCheck_c6c7f3Page.ForceAFail_0752_d18a3eAsync
        if (_data.Condition("while check for IFRAME"))
        {
            _data.Set("ForceAFail", _data.Resolve("{\"Expression\": \"{B[Alert Error]} == 'TRUE'\"}"));
        }
        // DCEQCommonSubmissionReferApplicationPolicy_13acc3Page.WaitForSyncronization_0753_d18a3eAsync
        await Task.Delay(1000);
        // DCEQCommonSubmissionReferApplicationPolicy_13acc3Page.WaitOnTransACTScreenToAppear_0754_d18a3eAsync
        await _ui.WaitAsync(_locators.TransactionType, "Exists");
    }

    // Business step: I complete save for Later/Return to Admin for save for later
    public async Task CompleteSaveForLaterReturnToAdminForSaveForLaterAsync()
    {
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.CheckForSaveForLaterButton_0757_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.SaveForLater))
        {
            await _ui.VerifyAsync(_locators.SaveForLater, _data.Resolve("Exists"), "");
        }
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.SaveForLater_0758_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.SaveForLater))
        {
            await _ui.ClickAsync(_locators.SaveForLater);
        }
        if (await _ui.ExistsAsync(_locators.SaveForLaterOK))
        {
            await _ui.WaitAsync(_locators.SaveForLaterOK, "Exists");
        }
        if (await _ui.ExistsAsync(_locators.SaveForLaterOK))
        {
            await _ui.ClickAsync(_locators.SaveForLaterOK);
        }
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.CheckForReturnToAdminButton_0759_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.ReturnToAdmin))
        {
            await _ui.VerifyAsync(_locators.ReturnToAdmin, _data.Resolve("Exists"), "");
        }
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.ReturnToAdmin_0760_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.ReturnToAdmin))
        {
            await _ui.ClickAsync(_locators.ReturnToAdmin);
        }
        if (await _ui.ExistsAsync(_locators.ReturnToAdmin))
        {
            await _ui.WaitAsync(_locators.ReturnToAdmin, "Absent");
        }
    }

    // Business step: I complete restart Edge Popup for restart edge popup
    public async Task CompleteRestartEdgePopupForRestartEdgePopupAsync()
    {
        // EQCommonOpenEQInBrowserCLEQCommonGeneralRestartEdgePopup_d7303fPage.RestartMicrosoftEdgeMessageExists_0801_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.VerifyAsync(_locators.EChecklistEChecklistOK, _data.Resolve("Exists"), "");
        }
        // EQCommonOpenEQInBrowserCLEQCommonGeneralRestartEdgePopup_d7303fPage.RestartMicrosoftEdgeMessageClickOK_0802_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        }
        // EQCommonOpenEQInBrowser_5597edPage.EQLoadingIndicatorWait_0805_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I open EQ in Browser for check if logout exists
    public async Task OpenEQInBrowserForCheckIfLogoutExistsAsync()
    {
        // EQCommonOpenEQInBrowser_5597edPage.EQCommonCheckIfLogoutExists_0806_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.VerifyAsync(_locators.Logout, _data.Resolve("Exists"), "");
        }
        // EQCommonOpenEQInBrowser_5597edPage.EQCommonClickLogoutOfEQ_0807_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.ClickAsync(_locators.Logout);
        }
        if (await _ui.ExistsAsync(_locators.LogoutLogOut))
        {
            await _ui.ClickAsync(_locators.LogoutLogOut);
        }
    }

    // Business step: I search by QuoteNum for search by quotenum
    public async Task SearchByQuoteNumForSearchByQuotenumAsync()
    {
        // CLEQCommonSearchByQuoteNum_882b64Page.SearchByQuoteNum_0819_d18a3eAsync
        await _ui.FillAsync(_locators.QuoteSearchInput, _data.Resolve("{B[Quote_Num]}"));
        await _ui.PressAsync(_locators.QuoteSearchInput, "Tab");
        await _ui.PressAsync(_locators.QuoteSearchInput, "Tab");
        await _ui.ClickAsync(_locators.ClientInfoSearch);
        // CLEQCommonSearchByQuoteNumCLEQCommonWaitOnLoadingIndicator_1394d4Page.EQLoadingIndicatorWait_0820_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0825_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_11}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0826_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I complete restart Edge Popup for restart microsoft edge message exists
    public async Task CompleteRestartEdgePopupForRestartMicrosoftEdgeMessageExistsAsync()
    {
        // CommonGeneralLogInToDuckCreekCLEQCommonGeneralRestartEdgePopup_6c649cPage.RestartMicrosoftEdgeMessageExists_0854_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.VerifyAsync(_locators.EChecklistEChecklistOK, _data.Resolve("Exists"), "");
        }
        // CommonGeneralLogInToDuckCreekCLEQCommonGeneralRestartEdgePopup_6c649cPage.RestartMicrosoftEdgeMessageClickOK_0855_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        }
    }

    // Business step: I sign out of the application for logout
    public async Task SignOutOfTheApplicationForLogoutAsync()
    {
        // CommonGeneralLogInToDuckCreekCommonGeneralLogout_d9eb6bPage.Logout_0858_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoggedInUser6AD12))
        {
            await _ui.ClickAsync(_locators.LoggedInUser6AD12);
        }
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.ClickAsync(_locators.Logout);
        }
        // CommonGeneralLogInToDuckCreekCommonGeneralLogout_d9eb6bPage.SyncForLogOut_0859_d18a3eAsync
        if (_data.Condition("during loop for the Login [max=30]"))
        {
            await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
        }
        // CommonGeneralLogInToDuckCreekCommonGeneralLogout_d9eb6bPage.CheckForHttpErrorMsg_0860_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36B))
        {
            await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36B, _data.Resolve("Exists"), "");
        }
        // CommonGeneralLogInToDuckCreekCommonGeneralLogout_d9eb6bPage.ClickOKOnHttpErrorMsg_0861_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        }
        // CommonGeneralLogInToDuckCreekCommonGeneralLogout_d9eb6bPage.CheckHttpErrorMsgDoesNotExist_0862_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.WaitAsync(_locators.EChecklistEChecklistOK, "Absent");
        }
        // CommonGeneralLogInToDuckCreekCommonGeneralLogout_d9eb6bPage.Logout_0863_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoggedInUser6AD12))
        {
            await _ui.ClickAsync(_locators.LoggedInUser6AD12);
        }
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.ClickAsync(_locators.Logout);
        }
    }

    // Business step: I verify None of the Above
    public async Task VerifyNoneOfTheAboveAsync2()
    {
        // EQCommonPreQualificationGeneralEligibilityRestrictionsVerifyNoneOfTheAbove_2820ccPage.VerifyNoneOfTheAboveStatus_0075_08f3f1Async
        if (await _ui.ExistsAsync(_locators.UncheckedNoneOfTheAbove))
        {
            await _ui.VerifyAsync(_locators.UncheckedNoneOfTheAbove, _data.Resolve("Exists"), "");
        }
        // EQCommonPreQualificationGeneralEligibilityRestrictionsVerifyNoneOfTheAbove_2820ccPage.CheckNoneOfTheAbove_0076_08f3f1Async
        if (await _ui.ExistsAsync(_locators.UncheckedNoneOfTheAbove))
        {
            await _ui.PressAsync(_locators.UncheckedNoneOfTheAbove, "POST:TAB");
            await _ui.PressAsync(_locators.UncheckedNoneOfTheAbove, "Tab");
        }
        if (await _ui.ExistsAsync(_locators.ResponseRequiredToContinue))
        {
            await _ui.WaitAsync(_locators.ResponseRequiredToContinue, "Exists");
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0078_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_3}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0079_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I enter Required Info
    public async Task EnterRequiredInfoAsync3()
    {
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQPrimaryInsuredEnterRequiredInfoTypeSFP_0087_08f3f1Async
        await _ui.PressAsync(_locators.ExistingClient, "POST:TAB");
        await _ui.PressAsync(_locators.ExistingClient, "Tab");
        await _ui.ClickAsync(_locators.NextSFP);
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQLoadingIndicatorWait_0088_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQPrimaryInsuredEnterRequiredInfoOther_0089_08f3f1Async
        await _ui.PressAsync(_locators.Save, "POST:TAB");
        await _ui.PressAsync(_locators.Save, "Tab");
        await _ui.ClickAsync(_locators.Save);
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQPrimaryInsuredClickEditGeneralInfo_0090_08f3f1Async
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.ClickAsync(_locators.EQCommonPrimaryInsuredRequired);
        }
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQLoadingIndicatorWait_0091_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQPrimaryInsuredGeneralInfoQuoteDescription_0092_08f3f1Async
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.PressAsync(_locators.DescriptionOfOperations, "POST:TAB");
            await _ui.PressAsync(_locators.DescriptionOfOperations, "Tab");
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.PressAsync(_locators.NumberOfFulltimeEmployees, "POST:ENTER");
            await _ui.PressAsync(_locators.NumberOfFulltimeEmployees, "Enter");
            await _ui.PressAsync(_locators.NumberOfFulltimeEmployees, "Tab");
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "POST:ENTER");
            await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Enter");
            await _ui.PressAsync(_locators.NumberOfPartTimeEmployees, "Tab");
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.PressAsync(_locators.NumberOfSeasonalEmployees, "POST:ENTER");
            await _ui.PressAsync(_locators.NumberOfSeasonalEmployees, "Enter");
            await _ui.PressAsync(_locators.NumberOfSeasonalEmployees, "Tab");
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.ClickAsync(_locators.Save);
        }
        if (_data.Condition("ReadOnly == NULL"))
        {
            await _ui.VerifyAsync(_locators.DescriptionOfOperations, _data.Resolve("{{runtime:QuoteDescription}}"), "");
        }
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQLoadingIndicatorWait_0093_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonPrimaryInsuredEnterRequiredInfo_3aad61Page.EQBOPPrimaryInsuredDetailsAnswerNoneOfTheAbove_0094_08f3f1Async
        await _ui.PressAsync(_locators.NoneOfTheAboveCheckbox, "POST:TAB");
        await _ui.PressAsync(_locators.NoneOfTheAboveCheckbox, "Tab");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0095_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_4}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0096_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I complete edit Client Roles
    public async Task CompleteEditClientRolesAsync3()
    {
        // EQBOPClientDetailsEditClientRoles_8c90e7Page.EQBOPClientDetailsClickClientRoleOnRolodex_0104_08f3f1Async
        await _ui.PressAsync(_locators.InspectionContact, "POST:TAB");
        await _ui.PressAsync(_locators.InspectionContact, "Tab");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0105_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_5}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0106_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I add/Edit a Narrative and Verify Timestamp
    public async Task AddEditANarrativeAndVerifyTimestampAsync3()
    {
        // EQCommonNarrativeAddEditANarrativeAndVerifyTimestamp_c610cbPage.EQCommonVerifyThatEditIsNotDisplayedAndTextIsLocked_0113_08f3f1Async
        await _ui.WaitAsync(_locators.NarrativeScreenHeading, "Exists");
        await _ui.ClickAsync(_locators.AddNarrative);
        await _ui.FillAsync(_locators.DescriptionOfTheBusinessExposuresActivitiesAndExperience, _data.Resolve("{{data:description_of_the_business_exposures_activities_and_experience_129}}"));
        if (_data.Condition("'Referred and Locked' != \"Yes\""))
        {
            await _ui.ClickAsync(_locators.Save);
        }
        await _ui.WaitAsync(_locators.UserDateAndTimestamp, "Visible");
        await _ui.VerifyAsync(_locators.UserDateAndTimestamp, _data.Resolve("{{data:expected_user_date_and_timestamp_innertext_132}}"), "NotEqual:InnerText");
        if (_data.Condition("'Referred and Locked' == \"Yes\""))
        {
            await _ui.VerifyAsync(_locators.LockedThisQuoteHasBeenSubmittedAndYouCanNoLongerMakeChangesToThisText, _data.Resolve("Exists"), "");
        }
        await _ui.FillAsync(_locators.DescriptionOfTheBusinessExposuresActivitiesAndExperience, _data.Resolve(""));
        _data.Set("NameQuoteNum", await _ui.CaptureAsync(_locators.NameAndQuoteNum8EB77, "InnerText"));
        // EQCommonNarrativeAddEditANarrativeAndVerifyTimestamp_c610cbPage.SetQuoteNum_0114_08f3f1Async
        _data.Set("Quote_Num", _data.Resolve("{B[NameQuoteNum]}"));
        // EQCommonNarrativeAddEditANarrativeAndVerifyTimestamp_c610cbPage.SetQuoteIDBuffer_0115_08f3f1Async
        _data.Set("QuoteID", _data.Resolve("{{runtime:Quote_Num}}"));
        _data.Set("Policy#", _data.Resolve("{{data:policy}}"));
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.BufferScreenName_0116_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_6}}"));
        // CLEQSFPPriorClaimsEnterRequiredEQCommonNavigateToScreen_ffe85bPage.CheckIfOnCorrectScreen_0117_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeadingDCABF))
        {
            await _ui.VerifyAsync(_locators.ScreenHeadingDCABF, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I complete nOT CE
    public async Task CompleteNOTCEAsync()
    {
        // CLEQSFPLIABILITYAddLiabilityNOTCE_c09df4Page.CLEQSFPDivVLiabilityAddLiability_0221_08f3f1Async
        await _ui.PressAsync(_locators.AddLiabilityYes, "POST:SCROLL[-2]");
        await _ui.PressAsync(_locators.AddLiabilityYes, "SCROLL[-2]");
        // CLEQSFPLIABILITYAddLiabilityNOTCE_c09df4Page.CLEQSFPDivVLiabilityAddLiability_0222_08f3f1Async
        await _ui.ClickAsync(_locators.AddLiabilityYes);
        // CLEQSFPLIABILITYAddLiabilityNOTCECLEQCommonWaitOnLoadingIndicator_6a6532Page.EQLoadingIndicatorWait_0223_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLIABILITYAddLiabilityNOTCE_c09df4Page.CLEQSFPDivVLiabilityAddLiability_0224_08f3f1Async
        await _ui.FillAsync(_locators.LiabilityLimit, _data.Resolve("{{data:liability_limit_279}}"));
        // CLEQSFPLIABILITYAddLiabilityNOTCECLEQCommonWaitOnLoadingIndicator_6a6532Page.EQLoadingIndicatorWait_0225_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLIABILITYAddLiabilityNOTCE_c09df4Page.CLEQSFPDivVLiabilityAddLiability_0226_08f3f1Async
        await _ui.PressAsync(_locators.LivestockHorses, "POST:ENTER");
        await _ui.PressAsync(_locators.LivestockHorses, "Enter");
        await _ui.PressAsync(_locators.LivestockHorses, "Tab");
        // CLEQSFPLIABILITYAddLiabilityNOTCECLEQCommonWaitOnLoadingIndicator_6a6532Page.EQLoadingIndicatorWait_0227_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLIABILITYAddLiabilityNOTCE_c09df4Page.CLEQSFPDivVLiabilityAddLiability_0228_08f3f1Async
        await _ui.PressAsync(_locators.LivestockSmall, "POST:ENTER");
        await _ui.PressAsync(_locators.LivestockSmall, "Enter");
        await _ui.PressAsync(_locators.LivestockSmall, "Tab");
        // CLEQSFPLIABILITYAddLiabilityNOTCECLEQCommonWaitOnLoadingIndicator_6a6532Page.EQLoadingIndicatorWait_0229_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLIABILITYAddLiabilityNOTCE_c09df4Page.CLEQSFPDivVLiabilityAddLiability_0230_08f3f1Async
        await _ui.PressAsync(_locators.LivestockLarge, "POST:ENTER");
        await _ui.PressAsync(_locators.LivestockLarge, "Enter");
        await _ui.PressAsync(_locators.LivestockLarge, "Tab");
        // CLEQSFPLIABILITYAddLiabilityNOTCECLEQCommonWaitOnLoadingIndicator_6a6532Page.EQLoadingIndicatorWait_0231_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLIABILITYAddLiabilityNOTCE_c09df4Page.CLEQSFPDivVLiabilityAddLiability_0232_08f3f1Async
        await _ui.PressAsync(_locators.UnlistedAcreage, "POST:ENTER");
        await _ui.PressAsync(_locators.UnlistedAcreage, "Enter");
        await _ui.PressAsync(_locators.UnlistedAcreage, "Tab");
        // CLEQSFPLIABILITYAddLiabilityNOTCECLEQCommonWaitOnLoadingIndicator_6a6532Page.EQLoadingIndicatorWait_0233_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0234_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_11}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0235_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading9696C))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading9696C, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I open a CLAS Browser and Search for EQ by Description 1
    public async Task OpenACLASBrowserAndSearchForEQByDescription1Async2()
    {
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.OpenABrowser_0288_08f3f1Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.OpenUrl_0299_08f3f1Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.WaitOnEdgeBrowserToOpen_0300_08f3f1Async
        await _ui.WaitAsync(_locators.BODY4F40D, "Exists");
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.PolicyLoadSync_0301_08f3f1Async
        await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
    }

    // Business step: I complete restart Edge Popup
    public async Task CompleteRestartEdgePopupAsync3()
    {
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CLEQCommonGeneralRestartEdgePopup_a88089Page.RestartMicrosoftEdgeMessageExists_0302_08f3f1Async
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.VerifyAsync(_locators.EChecklistEChecklistOK, _data.Resolve("Exists"), "");
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CLEQCommonGeneralRestartEdgePopup_a88089Page.RestartMicrosoftEdgeMessageClickOK_0303_08f3f1Async
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        }
    }

    // Business step: I open a CLAS Browser and Search for EQ by Description 1 for username
    public async Task OpenACLASBrowserAndSearchForEQByDescription1ForUsernameAsync2()
    {
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.VerifyUsernameExists_0304_08f3f1Async
        if (await _ui.ExistsAsync(_locators.UserNameE0ACD))
        {
            await _ui.VerifyAsync(_locators.UserNameE0ACD, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync3()
    {
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CommonGeneralLogout_20b896Page.Logout_0305_08f3f1Async
        if (await _ui.ExistsAsync(_locators.LoggedInUser8A0DD))
        {
            await _ui.ClickAsync(_locators.LoggedInUser8A0DD);
        }
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.ClickAsync(_locators.Logout);
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CommonGeneralLogout_20b896Page.SyncForLogOut_0306_08f3f1Async
        if (_data.Condition("if an existing CLAS session is still logged in"))
        {
            await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CommonGeneralLogout_20b896Page.CheckForHttpErrorMsg_0307_08f3f1Async
        if (await _ui.ExistsAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0B8256))
        {
            await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0B8256, _data.Resolve("Exists"), "");
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CommonGeneralLogout_20b896Page.ClickOKOnHttpErrorMsg_0308_08f3f1Async
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CommonGeneralLogout_20b896Page.CheckHttpErrorMsgDoesNotExist_0309_08f3f1Async
        if (await _ui.ExistsAsync(_locators.EChecklistEChecklistOK))
        {
            await _ui.WaitAsync(_locators.EChecklistEChecklistOK, "Absent");
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1CommonGeneralLogout_20b896Page.Logout_0310_08f3f1Async
        if (await _ui.ExistsAsync(_locators.LoggedInUser8A0DD))
        {
            await _ui.ClickAsync(_locators.LoggedInUser8A0DD);
        }
        if (await _ui.ExistsAsync(_locators.Logout))
        {
            await _ui.ClickAsync(_locators.Logout);
        }
    }

    // Business step: I complete save for Later/Return to Admin
    public async Task CompleteSaveForLaterReturnToAdminAsync3()
    {
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.CheckForSaveForLaterButton_0364_08f3f1Async
        if (await _ui.ExistsAsync(_locators.SaveForLater))
        {
            await _ui.VerifyAsync(_locators.SaveForLater, _data.Resolve("Exists"), "");
        }
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.SaveForLater_0365_08f3f1Async
        if (await _ui.ExistsAsync(_locators.SaveForLater))
        {
            await _ui.ClickAsync(_locators.SaveForLater);
        }
        if (await _ui.ExistsAsync(_locators.SaveForLaterOK))
        {
            await _ui.WaitAsync(_locators.SaveForLaterOK, "Exists");
        }
        if (await _ui.ExistsAsync(_locators.SaveForLaterOK))
        {
            await _ui.ClickAsync(_locators.SaveForLaterOK);
        }
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.CheckForReturnToAdminButton_0366_08f3f1Async
        if (await _ui.ExistsAsync(_locators.ReturnToAdmin))
        {
            await _ui.VerifyAsync(_locators.ReturnToAdmin, _data.Resolve("Exists"), "");
        }
        // CommonGeneralSaveForLaterReturnToAdmin_e67622Page.ReturnToAdmin_0367_08f3f1Async
        if (await _ui.ExistsAsync(_locators.ReturnToAdmin))
        {
            await _ui.ClickAsync(_locators.ReturnToAdmin);
        }
        if (await _ui.ExistsAsync(_locators.ReturnToAdmin))
        {
            await _ui.WaitAsync(_locators.ReturnToAdmin, "Absent");
        }
    }

}
