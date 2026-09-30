using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class NavigationPage
{
    private readonly BrowserSession _browser;
    private readonly IPage _page;
    private readonly NavigationLocators _locators;
    private readonly UiActions _ui;
    private readonly QuoteSearchLocators _quoteSearchLocators;

    public NavigationPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _page = browser.Page;
        _locators = new NavigationLocators(browser.Page);
        _ui = ui;
        _quoteSearchLocators = new QuoteSearchLocators(browser.Page);
    }

    public Task ClickADDADDITIONALINTERESTAsync() =>
        _ui.ClickAsync(_locators.ADDADDITIONALINTEREST, new ControlIntent("Navigation", "ADDADDITIONALINTEREST"));

    public Task PressAccountNumberAsync(string key) =>
        _ui.PressAsync(_locators.AccountNumber, key, new ControlIntent("Navigation", "AccountNumber"));

    public async Task ClickAddAsync()
    {
        await _locators.FindClassCodeDialog.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 20000 });
        await _locators.Add.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 20000 });
        await _locators.Add.ScrollIntoViewIfNeededAsync();

        var retries = 0;
        while (retries < 10)
        {
            if (await _locators.Add.IsEnabledAsync()) break;
            await Task.Delay(500);
            retries++;
        }

        try
        {
            await _locators.Add.ClickAsync();
        }
        catch
        {
            await _locators.Add.ClickAsync(new() { Force = true });
        }

        await _locators.FindClassCodeDialog.WaitForAsync(new() { State = WaitForSelectorState.Hidden, Timeout = 10000 });
    }

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

    public Task ClickClassFilterSearchButtonAsync() =>
        _ui.ClickAsync(_locators.ClassFilterSearchButton, new ControlIntent("Navigation", "ClassFilterSearchButton"));

    public Task ClickClientInfoSearchAsync() =>
        _ui.ClickAsync(_quoteSearchLocators.QuoteSearchButton, new ControlIntent("Navigation", "ClientInfoSearch"));

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
        _ui.WaitAsync(_locators.ClassFilter, expected, new ControlIntent("Navigation", "FindAClassCode"));

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

    public Task ClickNextPrimaryInsuredDetailsAsync() =>
        _ui.ClickAsync(_locators.NextPrimaryInsuredDetails, new ControlIntent("Navigation", "NextPrimaryInsuredDetails"));

    public Task ClickNextClientDetailsAsync() =>
        _ui.ClickAsync(_locators.NextClientDetails, new ControlIntent("Navigation", "NextClientDetails"));

    public async Task ClickNextNarrativeFromClaimsAsync()
    {
        await _locators.NextNarrativeFromClaims.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 20000 });
        await _locators.NextNarrativeFromClaims.ScrollIntoViewIfNeededAsync();

        var retries = 0;
        while (retries < 10)
        {
            if (await _locators.NextNarrativeFromClaims.IsEnabledAsync()) break;
            await Task.Delay(500);
            retries++;
        }

        try
        {
            await _locators.NextNarrativeFromClaims.ClickAsync();
        }
        catch
        {
            await _locators.NextNarrativeFromClaims.ClickAsync(new() { Force = true });
        }
    }

    public Task ClickNextLocationsBuildingsAsync() =>
        _ui.ClickAsync(_locators.NextLocationsBuildings, new ControlIntent("Navigation", "NextLocationsBuildings"));

    public async Task ClickInspectionContactCheckBoxAsync()
    {
        var checkboxInput = _locators.InspectionContactCheckBox.Locator("input[type='checkbox']");
        await checkboxInput.WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = 20000 });
        await checkboxInput.ScrollIntoViewIfNeededAsync();

        try
        {
            await checkboxInput.CheckAsync();
        }
        catch
        {
            try
            {
                await checkboxInput.CheckAsync(new() { Force = true });
            }
            catch
            {
                await checkboxInput.ClickAsync(new() { Force = true });
            }
        }
    }
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

    public async Task ClickAddToPolicyCheckboxAsync()
    {
        await _locators.AddToPolicyCheckbox.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });
        await _locators.AddToPolicyCheckbox.SetCheckedAsync(true);
        await Task.Delay(800);
    }

    public Task PressOnAsync(string key) =>
        _ui.PressAsync(_locators.On, key, new ControlIntent("Navigation", "On"));

    public Task PressOwnButtonAsync(string key) =>
        _ui.PressAsync(_locators.OwnButton, key, new ControlIntent("Navigation", "OwnButton"));

    public Task ClickOwnButtonAsync() =>
        _ui.ClickAsync(_locators.OwnButton, new ControlIntent("Navigation", "OwnButton"));

    public Task VerifyPolicyDetailsABBA9Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.PolicyDetailsABBA9, expected, property, new ControlIntent("Navigation", "PolicyDetailsABBA9"));

    public Task<bool> IsPolicyDetailsABBA9PresentAsync() =>
        _ui.ExistsAsync(_locators.PolicyDetailsABBA9);

    public Task VerifyPolicyDetailsE7F69Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.PolicyDetailsABBA9, expected, property, new ControlIntent("Navigation", "PolicyDetailsE7F69"));

    public Task<bool> IsPolicyDetailsE7F69PresentAsync() =>
        _ui.ExistsAsync(_locators.PolicyDetailsABBA9);

    public Task<string> CapturePolicyNumberAsync(string property = "") =>
        _ui.CaptureAsync(_locators.PolicyNumber, property, new ControlIntent("Navigation", "PolicyNumber"));

    public Task PressPowerGreaterThan250kwNoAsync(string key) =>
        _ui.PressAsync(_locators.PowerGreaterThan250kwNo, key, new ControlIntent("Navigation", "PowerGreaterThan250kwNo"));

    public Task PressPowerGreaterThan250kwYesAsync(string key) =>
        _ui.PressAsync(_locators.PowerGreaterThan250kwNo, key, new ControlIntent("Navigation", "PowerGreaterThan250kwYes"));

    public Task VerifyPreQualificationAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PreQualification, expected, property, new ControlIntent("Navigation", "PreQualification"));

    public async Task NavigateToScreenAsync(string screen)
    {
        var link = _locators.GetNavigationLink(screen);
        await link.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 20000 });
        await link.ScrollIntoViewIfNeededAsync();

        var heading = _locators.GetScreenHeading(screen);
        var retries = 0;
        while (retries < 5)
        {
            try
            {
                await link.ClickAsync(new() { Timeout = 5000 });
            }
            catch (Exception ex) when (ex is TimeoutException or PlaywrightException)
            {
                try
                {
                    await link.ClickAsync(new() { Force = true, Timeout = 5000 });
                }
                catch (Exception ex2) when (ex2 is TimeoutException or PlaywrightException)
                {
                    await link.EvaluateAsync("el => el.click()");
                }
            }

            try
            {
                await heading.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 3000 });
                return;
            }
            catch (Exception ex) when (ex is TimeoutException or PlaywrightException)
            {
                retries++;
                await Task.Delay(500);
            }
        }
    }

    public Task VerifyScreenAsync(string screen) =>
        _ui.VerifyAsync(_locators.GetScreenHeading(screen), "Visible", "", new ControlIntent("Navigation", $"ScreenHeading:{screen}"));

    public Task EnterPreQualificationAsync(string value) => NavigateToScreenAsync(value);

    public Task EnterResidenceAsync(string value) =>
        _ui.FillAsync(_locators.Residence, value, new ControlIntent("Navigation", "Residence"));

    public Task ClickSaveAsync() =>
        _ui.ClickAsync(_locators.Save, new ControlIntent("Navigation", "Save"));

    public Task ClickSaveBuildingAsync() =>
        _ui.ClickAsync(_locators.SaveBuilding, new ControlIntent("Navigation", "SaveBuilding"));

    public Task ClickLaunchToChecklistAsync() =>
        _ui.ClickAsync(_locators.LaunchToChecklist, new ControlIntent("Navigation", "LaunchToChecklist"));

    public Task ClickChecklistOpenedOKAsync() =>
        _ui.ClickAsync(_locators.ChecklistOpenedOK, new ControlIntent("Navigation", "ChecklistOpenedOK"));

    public Task ClickNextPricingAsync() =>
        _ui.ClickAsync(_locators.NextPricing, new ControlIntent("Navigation", "NextPricing"));

    public Task ClickNextBillingAsync() =>
        _ui.ClickAsync(_locators.NextBilling, new ControlIntent("Navigation", "NextBilling"));

    public async Task<bool> IsCatastrophePotentialVisibleAndEditableAsync()
    {
        try
        {
            await _locators.CatastrophePotential.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 3000 });
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
        {
            return false;
        }
        return await _locators.CatastrophePotential.IsVisibleAsync() && await _locators.CatastrophePotential.IsEditableAsync();
    }

    public Task SelectCatastrophePotentialAsync(string value) =>
        _ui.FillAsync(_locators.CatastrophePotential, value, new ControlIntent("Navigation", "CatastrophePotential"));

    public async Task<bool> IsLossRatioVisibleAndEditableAsync()
    {
        try
        {
            await _locators.LossRatio.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 3000 });
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
        {
            return false;
        }
        return await _locators.LossRatio.IsVisibleAsync() && await _locators.LossRatio.IsEditableAsync();
    }

    public Task SelectLossRatioAsync(string value) =>
        _ui.FillAsync(_locators.LossRatio, value, new ControlIntent("Navigation", "LossRatio"));

    public async Task<bool> IsLengthOfEmploymentVisibleAndEditableAsync()
    {
        try
        {
            await _locators.LengthOfEmployment.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 3000 });
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
        {
            return false;
        }
        return await _locators.LengthOfEmployment.IsVisibleAsync() && await _locators.LengthOfEmployment.IsEditableAsync();
    }

    public Task SelectLengthOfEmploymentAsync(string value) =>
        _ui.FillAsync(_locators.LengthOfEmployment, value, new ControlIntent("Navigation", "LengthOfEmployment"));

    public async Task<bool> IsMemberOfTradeAssociationVisibleAndEditableAsync()
    {
        try
        {
            await _locators.MemberOfTradeAssociation.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 3000 });
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
        {
            return false;
        }
        return await _locators.MemberOfTradeAssociation.IsVisibleAsync() && await _locators.MemberOfTradeAssociation.IsEditableAsync();
    }

    public Task SelectMemberOfTradeAssociationAsync(string value) =>
        _ui.FillAsync(_locators.MemberOfTradeAssociation, value, new ControlIntent("Navigation", "MemberOfTradeAssociation"));

    public async Task<bool> IsRiskManagementProgramVisibleAndEditableAsync()
    {
        try
        {
            await _locators.RiskManagementProgram.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 3000 });
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
        {
            return false;
        }
        return await _locators.RiskManagementProgram.IsVisibleAsync() && await _locators.RiskManagementProgram.IsEditableAsync();
    }

    public Task SelectRiskManagementProgramAsync(string value) =>
        _ui.FillAsync(_locators.RiskManagementProgram, value, new ControlIntent("Navigation", "RiskManagementProgram"));

    public async Task<bool> IsYearsInBusinessVisibleAndEditableAsync()
    {
        try
        {
            await _locators.YearsInBusiness.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 3000 });
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
        {
            return false;
        }
        return await _locators.YearsInBusiness.IsVisibleAsync() && await _locators.YearsInBusiness.IsEditableAsync();
    }

    public Task SelectYearsInBusinessAsync(string value) =>
        _ui.FillAsync(_locators.YearsInBusiness, value, new ControlIntent("Navigation", "YearsInBusiness"));

    public Task ClickNextClaimsPriorInsuranceAsync() =>
        _ui.ClickAsync(_locators.NextClaimsPriorInsurance, new ControlIntent("Navigation", "NextClaimsPriorInsurance"));

    public Task ClickScreen25E91Async() =>
        _ui.ClickAsync(_locators.Screen25E91, new ControlIntent("Navigation", "Screen25E91"));

    public Task<bool> IsScreen25E91PresentAsync() =>
        _ui.ExistsAsync(_locators.Screen25E91);

    public Task ClickScreen4475CAsync() =>
        _ui.ClickAsync(_locators.Screen25E91, new ControlIntent("Navigation", "Screen4475C"));

    public Task<bool> IsScreen4475CPresentAsync() =>
        _ui.ExistsAsync(_locators.Screen25E91);

    public Task ClickScreenDA408Async() =>
        _ui.ClickAsync(_locators.Screen25E91, new ControlIntent("Navigation", "ScreenDA408"));

    public Task<bool> IsScreenDA408PresentAsync() =>
        _ui.ExistsAsync(_locators.Screen25E91);

    public Task WaitForScreenHeading69631Async(string expected) =>
        _ui.WaitAsync(_locators.ScreenHeading69631, expected, new ControlIntent("Navigation", "ScreenHeading69631"));

    public Task<bool> IsScreenHeading69631PresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading69631);

    public Task WaitForScreenHeading9696CAsync(string expected) =>
        _ui.WaitAsync(_locators.ScreenHeading69631, expected, new ControlIntent("Navigation", "ScreenHeading9696C"));

    public Task VerifyScreenHeading9696CAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ScreenHeading69631, expected, property, new ControlIntent("Navigation", "ScreenHeading9696C"));

    public Task<bool> IsScreenHeading9696CPresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading69631);

    public Task WaitForScreenHeadingDCABFAsync(string expected) =>
        _ui.WaitAsync(_locators.ScreenHeading69631, expected, new ControlIntent("Navigation", "ScreenHeadingDCABF"));

    public Task<bool> IsScreenHeadingDCABFPresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading69631);

    public Task ClickSearchAddClassCodeAsync() =>
        _ui.ClickAsync(_locators.SearchAddClassCode, new ControlIntent("Navigation", "SearchAddClassCode"));

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
        _ui.PressAsync(_locators.Submission48772, key, new ControlIntent("Navigation", "Submission7E601"));

    public Task ClickSubmission7E601Async() =>
        _ui.ClickAsync(_locators.Submission48772, new ControlIntent("Navigation", "Submission7E601"));

    public Task<bool> IsSubmission7E601PresentAsync() =>
        _ui.ExistsAsync(_locators.Submission48772);

    public Task WaitForSubmissionHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.SubmissionHeading, expected, new ControlIntent("Navigation", "SubmissionHeading"));

    public Task VerifySubmissionHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.SubmissionHeading, expected, property, new ControlIntent("Navigation", "SubmissionHeading"));

    public Task<bool> IsSubmissionHeadingPresentAsync() =>
        _ui.ExistsAsync(_locators.SubmissionHeading);

    public Task WaitForTotalBuildingSqFootageAsync(string expected) =>
        _ui.WaitAsync(_locators.SelectIfClientOwnsOrRentsTheBuilding, expected, new ControlIntent("Navigation", "TotalBuildingSqFootage"));

    public Task PressTotalBuildingSqFootageAsync(string key) =>
        _ui.PressAsync(_locators.SelectIfClientOwnsOrRentsTheBuilding, key, new ControlIntent("Navigation", "TotalBuildingSqFootage"));

    public Task WaitForTransACTAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyDetailsABBA9, expected, new ControlIntent("Navigation", "TransACT"));

    public Task WaitForTransactionTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.TransactionType, expected, new ControlIntent("Navigation", "TransactionType"));

    public Task EnterTrueAsync(string value) =>
        _ui.ClickAsync(_locators.ADDADDITIONALINTEREST, new ControlIntent("Navigation", "MortgageSearchResult"));

    public Task PressTwoOrMoreLossesNoAsync(string key) =>
        _ui.PressAsync(_locators.TwoOrMoreLossesNo, key, new ControlIntent("Navigation", "TwoOrMoreLossesNo"));

    public Task ClickViewPolicyAsync() =>
        _ui.ClickAsync(_locators.ViewPolicy, new ControlIntent("Navigation", "ViewPolicy"));

    public Task ClickViewPolicyDetails848D5Async() =>
        _ui.ClickAsync(_locators.ViewPolicyDetails848D5, new ControlIntent("Navigation", "ViewPolicyDetails848D5"));

    public Task ClickViewPolicyDetailsC87C2Async() =>
        _ui.ClickAsync(_locators.ViewPolicyDetails848D5, new ControlIntent("Navigation", "ViewPolicyDetailsC87C2"));

    public Task WaitForYouHaveSelected1ClassCodesAsync(string expected) =>
        _ui.WaitAsync(_locators.ClassFilter, expected, new ControlIntent("Navigation", "YouHaveSelected1ClassCodes"));

    public Task PressYouHaveSelected1ClassCodesAsync(string key) =>
        _ui.PressAsync(_locators.ClassFilter, key, new ControlIntent("Navigation", "YouHaveSelected1ClassCodes"));

    public Task NavigateAsync(string url) =>
        _page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);

    public Task NoteAsync(string note) =>
        _ui.ReviewRequiredAsync(note);


    public Task<bool> IsKeepGoingPresentAsync() => _ui.ExistsAsync(_locators.KeepGoing);

}
