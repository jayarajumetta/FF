using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class PolicyWorkflowPage
{
    private readonly BrowserSession _browser;
    private readonly PolicyWorkflowLocators _locators;
    private readonly UiActions _ui;

    public PolicyWorkflowPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new PolicyWorkflowLocators(browser.Page);
        _ui = ui;
    }

    public Task PressAddLiabilityYesAsync(string key) =>
        _ui.PressAsync(_locators.AddLiabilityYes, key, new ControlIntent("PolicyWorkflow", "AddLiabilityYes"));

    public Task ClickAddLiabilityYesAsync() =>
        _ui.ClickAsync(_locators.AddLiabilityYes, new ControlIntent("PolicyWorkflow", "AddLiabilityYes"));

    public Task ClickAddNarrativeAsync() =>
        _ui.ClickAsync(_locators.AddNarrative, new ControlIntent("PolicyWorkflow", "AddNarrative"));

    public Task VerifyAlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe, expected, property, new ControlIntent("PolicyWorkflow", "AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe"));

    public Task<bool> IsAlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbePresentAsync() =>
        _ui.ExistsAsync(_locators.AlertErrorMessageBoxPolicyNumberExistsForThisQuoteNumbe);

    public Task WaitForBODY4F40DAsync(string expected) =>
        _ui.WaitAsync(_locators.BODY4F40D, expected, new ControlIntent("PolicyWorkflow", "BODY4F40D"));

    public Task WaitForBODYABC33Async(string expected) =>
        _ui.WaitAsync(_locators.BODYABC33, expected, new ControlIntent("PolicyWorkflow", "BODYABC33"));

    public Task VerifyButtonAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Button, expected, property, new ControlIntent("PolicyWorkflow", "Button"));

    public Task ClickButtonAsync() =>
        _ui.ClickAsync(_locators.Button, new ControlIntent("PolicyWorkflow", "Button"));

    public Task<bool> IsButtonPresentAsync() =>
        _ui.ExistsAsync(_locators.Button);

    public Task ClickClientInfoSearchAsync() =>
        _ui.ClickAsync(_locators.ClientInfoSearch, new ControlIntent("PolicyWorkflow", "ClientInfoSearch"));

    public Task ClickCloseQuoteAsync() =>
        _ui.ClickAsync(_locators.CloseQuote, new ControlIntent("PolicyWorkflow", "CloseQuote"));

    public Task VerifyDescriptionOfOperationsAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.DescriptionOfOperations, expected, property, new ControlIntent("PolicyWorkflow", "DescriptionOfOperations"));

    public Task PressDescriptionOfOperationsAsync(string key) =>
        _ui.PressAsync(_locators.DescriptionOfOperations, key, new ControlIntent("PolicyWorkflow", "DescriptionOfOperations"));

    public Task EnterDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync(string value) =>
        _ui.FillAsync(_locators.DescriptionOfTheBusinessExposuresActivitiesAndExperience, value, new ControlIntent("PolicyWorkflow", "DescriptionOfTheBusinessExposuresActivitiesAndExperience"));

    public Task WaitForEChecklistEChecklistOKAsync(string expected) =>
        _ui.WaitAsync(_locators.EChecklistEChecklistOK, expected, new ControlIntent("PolicyWorkflow", "EChecklistEChecklistOK"));

    public Task VerifyEChecklistEChecklistOKAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EChecklistEChecklistOK, expected, property, new ControlIntent("PolicyWorkflow", "EChecklistEChecklistOK"));

    public Task ClickEChecklistEChecklistOKAsync() =>
        _ui.ClickAsync(_locators.EChecklistEChecklistOK, new ControlIntent("PolicyWorkflow", "EChecklistEChecklistOK"));

    public Task<bool> IsEChecklistEChecklistOKPresentAsync() =>
        _ui.ExistsAsync(_locators.EChecklistEChecklistOK);

    public Task ClickEQCommonPrimaryInsuredRequiredAsync() =>
        _ui.ClickAsync(_locators.EQCommonPrimaryInsuredRequired, new ControlIntent("PolicyWorkflow", "EQCommonPrimaryInsuredRequired"));

    public Task ClickEditAsync() =>
        _ui.ClickAsync(_locators.Edit, new ControlIntent("PolicyWorkflow", "Edit"));

    public Task<bool> IsEditPresentAsync() =>
        _ui.ExistsAsync(_locators.Edit);

    public Task PressExistingClientAsync(string key) =>
        _ui.PressAsync(_locators.ExistingClient, key, new ControlIntent("PolicyWorkflow", "ExistingClient"));

    public Task VerifyIFRAMEAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.IFRAME, expected, property, new ControlIntent("PolicyWorkflow", "IFRAME"));

    public Task<bool> IsIFRAMEPresentAsync() =>
        _ui.ExistsAsync(_locators.IFRAME);

    public Task VerifyIFRAMEDuckCreekPolicyAlertErrorMessageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.IFRAMEDuckCreekPolicyAlertErrorMessage, expected, property, new ControlIntent("PolicyWorkflow", "IFRAMEDuckCreekPolicyAlertErrorMessage"));

    public Task<bool> IsIFRAMEDuckCreekPolicyAlertErrorMessagePresentAsync() =>
        _ui.ExistsAsync(_locators.IFRAMEDuckCreekPolicyAlertErrorMessage);

    public Task ClickIndividualSoleProprietorAsync() =>
        _ui.ClickAsync(_locators.IndividualSoleProprietor, new ControlIntent("PolicyWorkflow", "IndividualSoleProprietor"));

    public Task PressInspectionContactAsync(string key) =>
        _ui.PressAsync(_locators.InspectionContact, key, new ControlIntent("PolicyWorkflow", "InspectionContact"));

    public Task EnterLiabilityLimitAsync(string value) =>
        _ui.FillAsync(_locators.LiabilityLimit, value, new ControlIntent("PolicyWorkflow", "LiabilityLimit"));

    public Task PressLivestockHorsesAsync(string key) =>
        _ui.PressAsync(_locators.LivestockHorses, key, new ControlIntent("PolicyWorkflow", "LivestockHorses"));

    public Task PressLivestockLargeAsync(string key) =>
        _ui.PressAsync(_locators.LivestockLarge, key, new ControlIntent("PolicyWorkflow", "LivestockLarge"));

    public Task PressLivestockSmallAsync(string key) =>
        _ui.PressAsync(_locators.LivestockSmall, key, new ControlIntent("PolicyWorkflow", "LivestockSmall"));
public Task VerifyLoadingMessage4DE37Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.LoadingMessage4DE37, expected, property, new ControlIntent("PolicyWorkflow", "LoadingMessage4DE37"));

    public Task<bool> IsLoadingMessage4DE37PresentAsync() =>
        _ui.ExistsAsync(_locators.LoadingMessage4DE37);

    public Task VerifyLoadingMessageC7A0DAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LoadingMessageC7A0D, expected, property, new ControlIntent("PolicyWorkflow", "LoadingMessageC7A0D"));

    public Task<bool> IsLoadingMessageC7A0DPresentAsync() =>
        _ui.ExistsAsync(_locators.LoadingMessageC7A0D);

    public Task VerifyLockedThisQuoteHasBeenSubmittedAndYouCanNoLongerMakeChangesToThisTextAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LockedThisQuoteHasBeenSubmittedAndYouCanNoLongerMakeChangesToThisText, expected, property, new ControlIntent("PolicyWorkflow", "LockedThisQuoteHasBeenSubmittedAndYouCanNoLongerMakeChangesToThisText"));

    public Task ClickLoggedInUser5A005Async() =>
        _ui.ClickAsync(_locators.LoggedInUser5A005, new ControlIntent("PolicyWorkflow", "LoggedInUser5A005"));

    public Task<bool> IsLoggedInUser5A005PresentAsync() =>
        _ui.ExistsAsync(_locators.LoggedInUser5A005);

    public Task ClickLoggedInUser6AD12Async() =>
        _ui.ClickAsync(_locators.LoggedInUser6AD12, new ControlIntent("PolicyWorkflow", "LoggedInUser6AD12"));

    public Task<bool> IsLoggedInUser6AD12PresentAsync() =>
        _ui.ExistsAsync(_locators.LoggedInUser6AD12);

    public Task ClickLoggedInUser8A0DDAsync() =>
        _ui.ClickAsync(_locators.LoggedInUser8A0DD, new ControlIntent("PolicyWorkflow", "LoggedInUser8A0DD"));

    public Task<bool> IsLoggedInUser8A0DDPresentAsync() =>
        _ui.ExistsAsync(_locators.LoggedInUser8A0DD);

    public Task VerifyLogoutAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Logout, expected, property, new ControlIntent("PolicyWorkflow", "Logout"));

    public Task ClickLogoutAsync() =>
        _ui.ClickAsync(_locators.Logout, new ControlIntent("PolicyWorkflow", "Logout"));

    public Task<bool> IsLogoutPresentAsync() =>
        _ui.ExistsAsync(_locators.Logout);

    public Task ClickLogoutLogOutAsync() =>
        _ui.ClickAsync(_locators.LogoutLogOut, new ControlIntent("PolicyWorkflow", "LogoutLogOut"));

    public Task<bool> IsLogoutLogOutPresentAsync() =>
        _ui.ExistsAsync(_locators.LogoutLogOut);

    public Task VerifyNameAndQuoteAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.NameAndQuote, expected, property, new ControlIntent("PolicyWorkflow", "NameAndQuote"));

    public Task<string> CaptureNameAndQuoteAsync(string property = "") =>
        _ui.CaptureAsync(_locators.NameAndQuote, property, new ControlIntent("PolicyWorkflow", "NameAndQuote"));

    public Task<string> CaptureNameAndQuoteNum8EB77Async(string property = "") =>
        _ui.CaptureAsync(_locators.NameAndQuoteNum8EB77, property, new ControlIntent("PolicyWorkflow", "NameAndQuoteNum8EB77"));

    public Task WaitForNameAndQuoteNumCA893Async(string expected) =>
        _ui.WaitAsync(_locators.NameAndQuoteNumCA893, expected, new ControlIntent("PolicyWorkflow", "NameAndQuoteNumCA893"));

    public Task VerifyNameAndQuoteNumCA893Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.NameAndQuoteNumCA893, expected, property, new ControlIntent("PolicyWorkflow", "NameAndQuoteNumCA893"));

    public Task<bool> IsNameAndQuoteNumCA893PresentAsync() =>
        _ui.ExistsAsync(_locators.NameAndQuoteNumCA893);

    public Task WaitForNarrativeScreenHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.NarrativeScreenHeading, expected, new ControlIntent("PolicyWorkflow", "NarrativeScreenHeading"));

    public Task ClickNextBOPAsync() =>
        _ui.ClickAsync(_locators.NextBOP, new ControlIntent("PolicyWorkflow", "NextBOP"));

    public Task ClickNextSFPAsync() =>
        _ui.ClickAsync(_locators.NextSFP, new ControlIntent("PolicyWorkflow", "NextSFP"));

    public Task PressNoneOfTheAboveCheckboxAsync(string key) =>
        _ui.PressAsync(_locators.NoneOfTheAboveCheckbox, key, new ControlIntent("PolicyWorkflow", "NoneOfTheAboveCheckbox"));

    public Task PressNumberOfFulltimeEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.NumberOfFulltimeEmployees, key, new ControlIntent("PolicyWorkflow", "NumberOfFulltimeEmployees"));

    public Task PressNumberOfPartTimeEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.NumberOfPartTimeEmployees, key, new ControlIntent("PolicyWorkflow", "NumberOfPartTimeEmployees"));

    public Task PressNumberOfSeasonalEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.NumberOfSeasonalEmployees, key, new ControlIntent("PolicyWorkflow", "NumberOfSeasonalEmployees"));

    public Task ClickOkToUpdateFromChecklistAsync() =>
        _ui.ClickAsync(_locators.OkToUpdateFromChecklist, new ControlIntent("PolicyWorkflow", "OkToUpdateFromChecklist"));

    public Task ClickQuickSearchButtonAsync() =>
        _ui.ClickAsync(_locators.QuickSearchButton, new ControlIntent("PolicyWorkflow", "QuickSearchButton"));

    public Task EnterQuoteSearchInputAsync(string value) =>
        _ui.FillAsync(_locators.QuoteSearchInput, value, new ControlIntent("PolicyWorkflow", "QuoteSearchInput"));

    public Task PressQuoteSearchInputAsync(string key) =>
        _ui.PressAsync(_locators.QuoteSearchInput, key, new ControlIntent("PolicyWorkflow", "QuoteSearchInput"));

    public Task WaitForResponseRequiredToContinueAsync(string expected) =>
        _ui.WaitAsync(_locators.ResponseRequiredToContinue, expected, new ControlIntent("PolicyWorkflow", "ResponseRequiredToContinue"));

    public Task<bool> IsResponseRequiredToContinuePresentAsync() =>
        _ui.ExistsAsync(_locators.ResponseRequiredToContinue);

    public Task VerifyResultsTABLEAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ResultsTABLE, expected, property, new ControlIntent("PolicyWorkflow", "ResultsTABLE"));

    public Task<bool> IsResultsTABLEPresentAsync() =>
        _ui.ExistsAsync(_locators.ResultsTABLE);

    public Task VerifyResultsTABLERowCellExplicitNameNameAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ResultsTABLERowCellExplicitNameName, expected, property, new ControlIntent("PolicyWorkflow", "ResultsTABLERowCellExplicitNameName"));

    public Task<bool> IsResultsTABLERowCellExplicitNameNamePresentAsync() =>
        _ui.ExistsAsync(_locators.ResultsTABLERowCellExplicitNameName);

    public Task WaitForReturnToAdminAsync(string expected) =>
        _ui.WaitAsync(_locators.ReturnToAdmin, expected, new ControlIntent("PolicyWorkflow", "ReturnToAdmin"));

    public Task VerifyReturnToAdminAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ReturnToAdmin, expected, property, new ControlIntent("PolicyWorkflow", "ReturnToAdmin"));

    public Task ClickReturnToAdminAsync() =>
        _ui.ClickAsync(_locators.ReturnToAdmin, new ControlIntent("PolicyWorkflow", "ReturnToAdmin"));

    public Task<bool> IsReturnToAdminPresentAsync() =>
        _ui.ExistsAsync(_locators.ReturnToAdmin);

    public Task PressSaveAsync(string key) =>
        _ui.PressAsync(_locators.Save, key, new ControlIntent("PolicyWorkflow", "Save"));

    public Task ClickSaveAsync() =>
        _ui.ClickAsync(_locators.Save, new ControlIntent("PolicyWorkflow", "Save"));

    public Task VerifySaveForLaterAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.SaveForLater, expected, property, new ControlIntent("PolicyWorkflow", "SaveForLater"));

    public Task ClickSaveForLaterAsync() =>
        _ui.ClickAsync(_locators.SaveForLater, new ControlIntent("PolicyWorkflow", "SaveForLater"));

    public Task<bool> IsSaveForLaterPresentAsync() =>
        _ui.ExistsAsync(_locators.SaveForLater);

    public Task WaitForSaveForLaterOKAsync(string expected) =>
        _ui.WaitAsync(_locators.SaveForLaterOK, expected, new ControlIntent("PolicyWorkflow", "SaveForLaterOK"));

    public Task ClickSaveForLaterOKAsync() =>
        _ui.ClickAsync(_locators.SaveForLaterOK, new ControlIntent("PolicyWorkflow", "SaveForLaterOK"));

    public Task<bool> IsSaveForLaterOKPresentAsync() =>
        _ui.ExistsAsync(_locators.SaveForLaterOK);

    public Task VerifyScreenHeading69631Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.ScreenHeading69631, expected, property, new ControlIntent("PolicyWorkflow", "ScreenHeading69631"));

    public Task<bool> IsScreenHeading69631PresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading69631);

    public Task VerifyScreenHeading9696CAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ScreenHeading9696C, expected, property, new ControlIntent("PolicyWorkflow", "ScreenHeading9696C"));

    public Task<bool> IsScreenHeading9696CPresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading9696C);

    public Task VerifyScreenHeadingDCABFAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ScreenHeadingDCABF, expected, property, new ControlIntent("PolicyWorkflow", "ScreenHeadingDCABF"));

    public Task<bool> IsScreenHeadingDCABFPresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeadingDCABF);

    public Task WaitForSearchButtonAsync(string expected) =>
        _ui.WaitAsync(_locators.SearchButton, expected, new ControlIntent("PolicyWorkflow", "SearchButton"));

    public Task PressSearchButtonAsync(string key) =>
        _ui.PressAsync(_locators.SearchButton, key, new ControlIntent("PolicyWorkflow", "SearchButton"));

    public Task ClickSearchButtonAsync() =>
        _ui.ClickAsync(_locators.SearchButton, new ControlIntent("PolicyWorkflow", "SearchButton"));

    public Task PressSearchMethodEGDescriptionPolicyAsync(string key) =>
        _ui.PressAsync(_locators.SearchMethodEGDescriptionPolicy, key, new ControlIntent("PolicyWorkflow", "SearchMethodEGDescriptionPolicy"));

    public Task EnterSearchTextAsync(string value) =>
        _ui.FillAsync(_locators.SearchText, value, new ControlIntent("PolicyWorkflow", "SearchText"));

    public Task PressSearchTextAsync(string key) =>
        _ui.PressAsync(_locators.SearchText, key, new ControlIntent("PolicyWorkflow", "SearchText"));

    public Task VerifyTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36BAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36B, expected, property, new ControlIntent("PolicyWorkflow", "TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36B"));

    public Task<bool> IsTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36BPresentAsync() =>
        _ui.ExistsAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus01C36B);

    public Task VerifyTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740, expected, property, new ControlIntent("PolicyWorkflow", "TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740"));

    public Task<bool> IsTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740PresentAsync() =>
        _ui.ExistsAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus06F740);

    public Task VerifyTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0B8256Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0B8256, expected, property, new ControlIntent("PolicyWorkflow", "TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0B8256"));

    public Task<bool> IsTheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0B8256PresentAsync() =>
        _ui.ExistsAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0B8256);

    public Task WaitForTransactionTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.TransactionType, expected, new ControlIntent("PolicyWorkflow", "TransactionType"));

    public Task VerifyUncheckedNoneOfTheAboveAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.UncheckedNoneOfTheAbove, expected, property, new ControlIntent("PolicyWorkflow", "UncheckedNoneOfTheAbove"));

    public Task PressUncheckedNoneOfTheAboveAsync(string key) =>
        _ui.PressAsync(_locators.UncheckedNoneOfTheAbove, key, new ControlIntent("PolicyWorkflow", "UncheckedNoneOfTheAbove"));

    public Task<bool> IsUncheckedNoneOfTheAbovePresentAsync() =>
        _ui.ExistsAsync(_locators.UncheckedNoneOfTheAbove);

    public Task PressUnlistedAcreageAsync(string key) =>
        _ui.PressAsync(_locators.UnlistedAcreage, key, new ControlIntent("PolicyWorkflow", "UnlistedAcreage"));

    public Task WaitForUserDateAndTimestampAsync(string expected) =>
        _ui.WaitAsync(_locators.UserDateAndTimestamp, expected, new ControlIntent("PolicyWorkflow", "UserDateAndTimestamp"));

    public Task VerifyUserDateAndTimestampAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.UserDateAndTimestamp, expected, property, new ControlIntent("PolicyWorkflow", "UserDateAndTimestamp"));

    public Task VerifyUserNameE0ACDAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.UserNameE0ACD, expected, property, new ControlIntent("PolicyWorkflow", "UserNameE0ACD"));

    public Task<bool> IsUserNameE0ACDPresentAsync() =>
        _ui.ExistsAsync(_locators.UserNameE0ACD);

    public Task VerifyUserNameE65A8Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.UserNameE65A8, expected, property, new ControlIntent("PolicyWorkflow", "UserNameE65A8"));

    public Task<bool> IsUserNameE65A8PresentAsync() =>
        _ui.ExistsAsync(_locators.UserNameE65A8);

    public Task WaitForViewPolicy0AC0BAsync(string expected) =>
        _ui.WaitAsync(_locators.ViewPolicy0AC0B, expected, new ControlIntent("PolicyWorkflow", "ViewPolicy0AC0B"));

    public Task ClickViewPolicy0AC0BAsync() =>
        _ui.ClickAsync(_locators.ViewPolicy0AC0B, new ControlIntent("PolicyWorkflow", "ViewPolicy0AC0B"));

    public Task WaitForViewPolicy56E09Async(string expected) =>
        _ui.WaitAsync(_locators.ViewPolicy56E09, expected, new ControlIntent("PolicyWorkflow", "ViewPolicy56E09"));

    public Task PressViewPolicy56E09Async(string key) =>
        _ui.PressAsync(_locators.ViewPolicy56E09, key, new ControlIntent("PolicyWorkflow", "ViewPolicy56E09"));

    public Task NavigateAsync(string url) =>
        _browser.Page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);

    public Task NoteAsync(string note) =>
        _ui.ReviewRequiredAsync(note);

}
