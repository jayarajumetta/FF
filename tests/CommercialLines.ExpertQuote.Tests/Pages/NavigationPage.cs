using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class NavigationPage
{
    private readonly BrowserSession _browser;
    private readonly NavigationLocators _locators;
    private readonly UiActions _ui;

    public NavigationPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new NavigationLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickADDADDITIONALINTERESTAsync() =>
        _ui.ClickAsync(_locators.ADDADDITIONALINTEREST, new ControlIntent("Navigation", "ADDADDITIONALINTEREST"));

    public Task PressAccountNumberAsync(string key) =>
        _ui.PressAsync(_locators.AccountNumber, key, new ControlIntent("Navigation", "AccountNumber"));

    public Task ClickAddAsync() =>
        _ui.ClickAsync(_locators.Add, new ControlIntent("Navigation", "Add"));

    public Task WaitForAttachmentsListGridRowCellExplicitName1Async(string expected) =>
        _ui.WaitAsync(_locators.AttachmentsListGridRowCellExplicitName1, expected, new ControlIntent("Navigation", "AttachmentsListGridRowCellExplicitName1"));

    public Task VerifyAttachmentsListGridRowCellExplicitName1Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.AttachmentsListGridRowCellExplicitName1, expected, property, new ControlIntent("Navigation", "AttachmentsListGridRowCellExplicitName1"));

    public Task<string> CaptureAttachmentsListGridRowCellExplicitName3Async(string property = "") =>
        _ui.CaptureAsync(_locators.AttachmentsListGridRowCellExplicitName3, property, new ControlIntent("Navigation", "AttachmentsListGridRowCellExplicitName3"));

    public Task WaitForBODYAsync(string expected) =>
        _ui.WaitAsync(_locators.BODY, expected, new ControlIntent("Navigation", "BODY"));

    public Task EnterClassFilterAsync(string value) =>
        _ui.FillAsync(_locators.ClassFilter, value, new ControlIntent("Navigation", "ClassFilter"));

    public Task ClickClientInfoSearchAsync() =>
        _ui.ClickAsync(_locators.ClientInfoSearch, new ControlIntent("Navigation", "ClientInfoSearch"));

    public Task PressCombinedDeductibleAsync(string key) =>
        _ui.PressAsync(_locators.CombinedDeductible, key, new ControlIntent("Navigation", "CombinedDeductible"));

    public Task ClickCopyOfDecNoAsync() =>
        _ui.ClickAsync(_locators.CopyOfDecNo, new ControlIntent("Navigation", "CopyOfDecNo"));

    public Task PressDescriptionOfInterestAsync(string key) =>
        _ui.PressAsync(_locators.DescriptionOfInterest, key, new ControlIntent("Navigation", "DescriptionOfInterest"));

    public Task ClickEscrowBilledYesAsync() =>
        _ui.ClickAsync(_locators.EscrowBilledYes, new ControlIntent("Navigation", "EscrowBilledYes"));

    public Task ClickFarmImplementsNoAsync() =>
        _ui.ClickAsync(_locators.FarmImplementsNo, new ControlIntent("Navigation", "FarmImplementsNo"));

    public Task WaitForFindAClassCodeAsync(string expected) =>
        _ui.WaitAsync(_locators.FindAClassCode, expected, new ControlIntent("Navigation", "FindAClassCode"));

    public Task VerifyGeneralEligibilityRestrictionsSynchingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.GeneralEligibilityRestrictionsSynching, expected, property, new ControlIntent("Navigation", "GeneralEligibilityRestrictionsSynching"));

    public Task ClickGreaterThan25000NoAsync() =>
        _ui.ClickAsync(_locators.GreaterThan25000No, new ControlIntent("Navigation", "GreaterThan25000No"));

    public Task WaitForInsuredOccupancySqFtAngularAsync(string expected) =>
        _ui.WaitAsync(_locators.InsuredOccupancySqFtAngular, expected, new ControlIntent("Navigation", "InsuredOccupancySqFtAngular"));

    public Task PressInsuredOccupancySqFtAngularAsync(string key) =>
        _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, key, new ControlIntent("Navigation", "InsuredOccupancySqFtAngular"));

    public Task ClickKeepGoingAsync() =>
        _ui.ClickAsync(_locators.KeepGoing, new ControlIntent("Navigation", "KeepGoing"));
public Task<bool> IsLoadingPresentAsync() =>
        _ui.ExistsAsync(_locators.Loading);

    public Task WaitForLocationPrimaryLocationAsync(string expected) =>
        _ui.WaitAsync(_locators.LocationPrimaryLocation, expected, new ControlIntent("Navigation", "LocationPrimaryLocation"));

    public Task EnterLocationPrimaryLocationAsync(string value) =>
        _ui.FillAsync(_locators.LocationPrimaryLocation, value, new ControlIntent("Navigation", "LocationPrimaryLocation"));

    public Task PressLocationPrimaryLocationAsync(string key) =>
        _ui.PressAsync(_locators.LocationPrimaryLocation, key, new ControlIntent("Navigation", "LocationPrimaryLocation"));

    public Task ClickMortgageeSecuredPartyAsync() =>
        _ui.ClickAsync(_locators.MortgageeSecuredParty, new ControlIntent("Navigation", "MortgageeSecuredParty"));

    public Task WaitForOnAsync(string expected) =>
        _ui.WaitAsync(_locators.On, expected, new ControlIntent("Navigation", "On"));

    public Task PressOnAsync(string key) =>
        _ui.PressAsync(_locators.On, key, new ControlIntent("Navigation", "On"));

    public Task PressOwnButtonAsync(string key) =>
        _ui.PressAsync(_locators.OwnButton, key, new ControlIntent("Navigation", "OwnButton"));

    public Task VerifyPolicyDetailsABBA9Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.PolicyDetailsABBA9, expected, property, new ControlIntent("Navigation", "PolicyDetailsABBA9"));

    public Task<bool> IsPolicyDetailsABBA9PresentAsync() =>
        _ui.ExistsAsync(_locators.PolicyDetailsABBA9);

    public Task VerifyPolicyDetailsE7F69Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.PolicyDetailsE7F69, expected, property, new ControlIntent("Navigation", "PolicyDetailsE7F69"));

    public Task<bool> IsPolicyDetailsE7F69PresentAsync() =>
        _ui.ExistsAsync(_locators.PolicyDetailsE7F69);

    public Task<string> CapturePolicyNumberAsync(string property = "") =>
        _ui.CaptureAsync(_locators.PolicyNumber, property, new ControlIntent("Navigation", "PolicyNumber"));

    public Task PressPowerGreaterThan250kwNoAsync(string key) =>
        _ui.PressAsync(_locators.PowerGreaterThan250kwNo, key, new ControlIntent("Navigation", "PowerGreaterThan250kwNo"));

    public Task PressPowerGreaterThan250kwYesAsync(string key) =>
        _ui.PressAsync(_locators.PowerGreaterThan250kwYes, key, new ControlIntent("Navigation", "PowerGreaterThan250kwYes"));

    public Task VerifyPreQualificationAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PreQualification, expected, property, new ControlIntent("Navigation", "PreQualification"));

    public Task EnterPreQualificationAsync(string value) =>
        _ui.FillAsync(_locators.PreQualification, value, new ControlIntent("Navigation", "PreQualification"));

    public Task EnterResidenceAsync(string value) =>
        _ui.FillAsync(_locators.Residence, value, new ControlIntent("Navigation", "Residence"));

    public Task ClickSaveAsync() =>
        _ui.ClickAsync(_locators.Save, new ControlIntent("Navigation", "Save"));

    public Task ClickScreen25E91Async() =>
        _ui.ClickAsync(_locators.Screen25E91, new ControlIntent("Navigation", "Screen25E91"));

    public Task<bool> IsScreen25E91PresentAsync() =>
        _ui.ExistsAsync(_locators.Screen25E91);

    public Task ClickScreen4475CAsync() =>
        _ui.ClickAsync(_locators.Screen4475C, new ControlIntent("Navigation", "Screen4475C"));

    public Task<bool> IsScreen4475CPresentAsync() =>
        _ui.ExistsAsync(_locators.Screen4475C);

    public Task ClickScreenDA408Async() =>
        _ui.ClickAsync(_locators.ScreenDA408, new ControlIntent("Navigation", "ScreenDA408"));

    public Task<bool> IsScreenDA408PresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenDA408);

    public Task WaitForScreenHeading69631Async(string expected) =>
        _ui.WaitAsync(_locators.ScreenHeading69631, expected, new ControlIntent("Navigation", "ScreenHeading69631"));

    public Task<bool> IsScreenHeading69631PresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading69631);

    public Task WaitForScreenHeading9696CAsync(string expected) =>
        _ui.WaitAsync(_locators.ScreenHeading9696C, expected, new ControlIntent("Navigation", "ScreenHeading9696C"));

    public Task VerifyScreenHeading9696CAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ScreenHeading9696C, expected, property, new ControlIntent("Navigation", "ScreenHeading9696C"));

    public Task<bool> IsScreenHeading9696CPresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading9696C);

    public Task WaitForScreenHeadingDCABFAsync(string expected) =>
        _ui.WaitAsync(_locators.ScreenHeadingDCABF, expected, new ControlIntent("Navigation", "ScreenHeadingDCABF"));

    public Task<bool> IsScreenHeadingDCABFPresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeadingDCABF);

    public Task PressSearchAddClassCodeAsync(string key) =>
        _ui.PressAsync(_locators.SearchAddClassCode, key, new ControlIntent("Navigation", "SearchAddClassCode"));

    public Task PressSearchNameAsync(string key) =>
        _ui.PressAsync(_locators.SearchName, key, new ControlIntent("Navigation", "SearchName"));

    public Task PressSearchZipCodeAsync(string key) =>
        _ui.PressAsync(_locators.SearchZipCode, key, new ControlIntent("Navigation", "SearchZipCode"));

    public Task WaitForSelectIfClientOwnsOrRentsTheBuildingAsync(string expected) =>
        _ui.WaitAsync(_locators.SelectIfClientOwnsOrRentsTheBuilding, expected, new ControlIntent("Navigation", "SelectIfClientOwnsOrRentsTheBuilding"));

    public Task WaitForSubmission48772Async(string expected) =>
        _ui.WaitAsync(_locators.Submission48772, expected, new ControlIntent("Navigation", "Submission48772"));

    public Task ClickSubmission48772Async() =>
        _ui.ClickAsync(_locators.Submission48772, new ControlIntent("Navigation", "Submission48772"));

    public Task PressSubmission7E601Async(string key) =>
        _ui.PressAsync(_locators.Submission7E601, key, new ControlIntent("Navigation", "Submission7E601"));

    public Task ClickSubmission7E601Async() =>
        _ui.ClickAsync(_locators.Submission7E601, new ControlIntent("Navigation", "Submission7E601"));

    public Task<bool> IsSubmission7E601PresentAsync() =>
        _ui.ExistsAsync(_locators.Submission7E601);

    public Task WaitForSubmissionHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.SubmissionHeading, expected, new ControlIntent("Navigation", "SubmissionHeading"));

    public Task VerifySubmissionHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.SubmissionHeading, expected, property, new ControlIntent("Navigation", "SubmissionHeading"));

    public Task<bool> IsSubmissionHeadingPresentAsync() =>
        _ui.ExistsAsync(_locators.SubmissionHeading);

    public Task WaitForTotalBuildingSqFootageAsync(string expected) =>
        _ui.WaitAsync(_locators.TotalBuildingSqFootage, expected, new ControlIntent("Navigation", "TotalBuildingSqFootage"));

    public Task PressTotalBuildingSqFootageAsync(string key) =>
        _ui.PressAsync(_locators.TotalBuildingSqFootage, key, new ControlIntent("Navigation", "TotalBuildingSqFootage"));

    public Task WaitForTransACTAsync(string expected) =>
        _ui.WaitAsync(_locators.TransACT, expected, new ControlIntent("Navigation", "TransACT"));

    public Task WaitForTransactionTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.TransactionType, expected, new ControlIntent("Navigation", "TransactionType"));

    public Task EnterTrueAsync(string value) =>
        _ui.FillAsync(_locators.True, value, new ControlIntent("Navigation", "True"));

    public Task PressTwoOrMoreLossesNoAsync(string key) =>
        _ui.PressAsync(_locators.TwoOrMoreLossesNo, key, new ControlIntent("Navigation", "TwoOrMoreLossesNo"));

    public Task ClickViewPolicyAsync() =>
        _ui.ClickAsync(_locators.ViewPolicy, new ControlIntent("Navigation", "ViewPolicy"));

    public Task ClickViewPolicyDetails848D5Async() =>
        _ui.ClickAsync(_locators.ViewPolicyDetails848D5, new ControlIntent("Navigation", "ViewPolicyDetails848D5"));

    public Task ClickViewPolicyDetailsC87C2Async() =>
        _ui.ClickAsync(_locators.ViewPolicyDetailsC87C2, new ControlIntent("Navigation", "ViewPolicyDetailsC87C2"));

    public Task WaitForYouHaveSelected1ClassCodesAsync(string expected) =>
        _ui.WaitAsync(_locators.YouHaveSelected1ClassCodes, expected, new ControlIntent("Navigation", "YouHaveSelected1ClassCodes"));

    public Task PressYouHaveSelected1ClassCodesAsync(string key) =>
        _ui.PressAsync(_locators.YouHaveSelected1ClassCodes, key, new ControlIntent("Navigation", "YouHaveSelected1ClassCodes"));

    public Task NavigateAsync(string url) =>
        _browser.Page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);

    public Task NoteAsync(string note) =>
        _ui.ReviewRequiredAsync(note);


    public Task<bool> IsKeepGoingPresentAsync() => _ui.ExistsAsync(_locators.KeepGoing);

}
