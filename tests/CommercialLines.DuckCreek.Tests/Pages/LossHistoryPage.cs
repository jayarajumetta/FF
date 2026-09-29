using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class LossHistoryPage
{
    private readonly BrowserSession _browser;
    private readonly LossHistoryLocators _locators;
    private readonly UiActions _ui;

    public LossHistoryPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new LossHistoryLocators(browser.Page);
        _ui = ui;
    }

    public Task WaitForAddAddlInterestAsync(string expected) =>
        _ui.WaitAsync(_locators.AddAddlInterest, expected, new ControlIntent("LossHistory", "AddAddlInterest"));

    public Task ClickAddAddlInterestAsync() =>
        _ui.ClickAsync(_locators.AddAddlInterest, new ControlIntent("LossHistory", "AddAddlInterest"));

    public Task WaitForAddlInterestsAsync(string expected) =>
        _ui.WaitAsync(_locators.AddlInterests, expected, new ControlIntent("LossHistory", "AddlInterests"));

    public Task ClickAddlInterestsAsync() =>
        _ui.ClickAsync(_locators.AddlInterests, new ControlIntent("LossHistory", "AddlInterests"));

    public Task WaitForAddlInterestsMainOKAsync(string expected) =>
        _ui.WaitAsync(_locators.OK, expected, new ControlIntent("LossHistory", "AddlInterestsMainOK"));

    public Task ClickAddlInterestsMainOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("LossHistory", "AddlInterestsMainOK"));

    public Task WaitForLossAddressAsync(string expected) =>
        _ui.WaitAsync(_locators.LossAddress, expected, new ControlIntent("LossHistory", "LossAddress"));

    public Task EnterLossAddressAsync(string value) =>
        _ui.FillAsync(_locators.LossAddress, value, new ControlIntent("LossHistory", "LossAddress"));

    public Task PressLossAddressAsync(string key) =>
        _ui.PressAsync(_locators.LossAddress, key, new ControlIntent("LossHistory", "LossAddress"));

    public Task WaitForAssignLocationsAsync(string expected) =>
        _ui.WaitAsync(_locators.AssignLocations, expected, new ControlIntent("LossHistory", "AssignLocations"));

    public Task ClickAssignLocationsAsync() =>
        _ui.ClickAsync(_locators.AssignLocations, new ControlIntent("LossHistory", "AssignLocations"));

    public Task WaitForAssignmentScheduleForAsync(string expected) =>
        _ui.WaitAsync(_locators.OtherInterestPremisesSchedule, expected, new ControlIntent("LossHistory", "AssignmentScheduleFor"));

    public Task WaitForAssignmentScheduleForOKAsync(string expected) =>
        _ui.WaitAsync(_locators.OK, expected, new ControlIntent("LossHistory", "AssignmentScheduleForOK"));

    public Task ClickAssignmentScheduleForOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("LossHistory", "AssignmentScheduleForOK"));

    public Task WaitForDescriptionOfPropertyAsync(string expected) =>
        _ui.WaitAsync(_locators.DescriptionOfProperty, expected, new ControlIntent("LossHistory", "DescriptionOfProperty"));

    public Task EnterDescriptionOfPropertyAsync(string value) =>
        _ui.FillAsync(_locators.DescriptionOfProperty, value, new ControlIntent("LossHistory", "DescriptionOfProperty"));

    public Task PressDescriptionOfPropertyAsync(string key) =>
        _ui.PressAsync(_locators.DescriptionOfProperty, key, new ControlIntent("LossHistory", "DescriptionOfProperty"));

    public Task WaitForFirstNameAsync(string expected) =>
        _ui.WaitAsync(_locators.FirstName, expected, new ControlIntent("LossHistory", "FirstName"));

    public Task EnterFirstNameAsync(string value) =>
        _ui.FillAsync(_locators.FirstName, value, new ControlIntent("LossHistory", "FirstName"));

    public Task PressFirstNameAsync(string key) =>
        _ui.PressAsync(_locators.FirstName, key, new ControlIntent("LossHistory", "FirstName"));

    public Task WaitForInsuredTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.InsuredType, expected, new ControlIntent("LossHistory", "InsuredType"));

    public Task EnterInsuredTypeAsync(string value) =>
        _ui.FillAsync(_locators.InsuredType, value, new ControlIntent("LossHistory", "InsuredType"));

    public Task PressInsuredTypeAsync(string key) =>
        _ui.PressAsync(_locators.InsuredType, key, new ControlIntent("LossHistory", "InsuredType"));

    public Task WaitForLastNameAsync(string expected) =>
        _ui.WaitAsync(_locators.LastName, expected, new ControlIntent("LossHistory", "LastName"));

    public Task EnterLastNameAsync(string value) =>
        _ui.FillAsync(_locators.LastName, value, new ControlIntent("LossHistory", "LastName"));

    public Task PressLastNameAsync(string key) =>
        _ui.PressAsync(_locators.LastName, key, new ControlIntent("LossHistory", "LastName"));

    public Task WaitForLoanNumberAsync(string expected) =>
        _ui.WaitAsync(_locators.LoanNumber, expected, new ControlIntent("LossHistory", "LoanNumber"));

    public Task EnterLoanNumberAsync(string value) =>
        _ui.FillAsync(_locators.LoanNumber, value, new ControlIntent("LossHistory", "LoanNumber"));

    public Task PressLoanNumberAsync(string key) =>
        _ui.PressAsync(_locators.LoanNumber, key, new ControlIntent("LossHistory", "LoanNumber"));

    public Task WaitForMIAsync(string expected) =>
        _ui.WaitAsync(_locators.MI, expected, new ControlIntent("LossHistory", "MI"));

    public Task EnterMIAsync(string value) =>
        _ui.FillAsync(_locators.MI, value, new ControlIntent("LossHistory", "MI"));

    public Task PressMIAsync(string key) =>
        _ui.PressAsync(_locators.MI, key, new ControlIntent("LossHistory", "MI"));

    public Task WaitForNewAssignmentAsync(string expected) =>
        _ui.WaitAsync(_locators.NewAssignmentHeading, expected, new ControlIntent("LossHistory", "NewAssignment"));

    public Task ClickNewAssignmentAsync() =>
        _ui.ClickAsync(_locators.NewAssignment, new ControlIntent("LossHistory", "NewAssignment"));

    public Task WaitForOtherInterestPremisesDetailOKAsync(string expected) =>
        _ui.WaitAsync(_locators.OK, expected, new ControlIntent("LossHistory", "OtherInterestPremisesDetailOK"));

    public Task ClickOtherInterestPremisesDetailOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("LossHistory", "OtherInterestPremisesDetailOK"));

    public Task WaitForOtherInterestPremisesScheduleAsync(string expected) =>
        _ui.WaitAsync(_locators.OtherInterestPremisesSchedule, expected, new ControlIntent("LossHistory", "OtherInterestPremisesSchedule"));

    public Task ClickOtherInterestPremisesScheduleOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("LossHistory", "OtherInterestPremisesScheduleOK"));

    public Task WaitForProvisionsApplicableAsync(string expected) =>
        _ui.WaitAsync(_locators.ProvisionsApplicable, expected, new ControlIntent("LossHistory", "ProvisionsApplicable"));

    public Task EnterProvisionsApplicableAsync(string value) =>
        _ui.FillAsync(_locators.ProvisionsApplicable, value, new ControlIntent("LossHistory", "ProvisionsApplicable"));

    public Task PressProvisionsApplicableAsync(string key) =>
        _ui.PressAsync(_locators.ProvisionsApplicable, key, new ControlIntent("LossHistory", "ProvisionsApplicable"));

    public Task WaitForTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.Type, expected, new ControlIntent("LossHistory", "Type"));

    public Task EnterTypeAsync(string value) =>
        _ui.FillAsync(_locators.Type, value, new ControlIntent("LossHistory", "Type"));

    public Task PressTypeAsync(string key) =>
        _ui.PressAsync(_locators.Type, key, new ControlIntent("LossHistory", "Type"));

    public Task WaitForZipCodeAsync(string expected) =>
        _ui.WaitAsync(_locators.ZipCode, expected, new ControlIntent("LossHistory", "ZipCode"));

    public Task EnterZipCodeAsync(string value) =>
        _ui.FillAsync(_locators.ZipCode, value, new ControlIntent("LossHistory", "ZipCode"));

    public Task PressZipCodeAsync(string key) =>
        _ui.PressAsync(_locators.ZipCode, key, new ControlIntent("LossHistory", "ZipCode"));


    public Task EnterLossAddressSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.LossAddress, value, new ControlIntent("LossHistory", "LossAddress"), delayMs);

    public Task EnterDescriptionOfPropertySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DescriptionOfProperty, value, new ControlIntent("LossHistory", "DescriptionOfProperty"), delayMs);

    public Task EnterFirstNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.FirstName, value, new ControlIntent("LossHistory", "FirstName"), delayMs);

    public Task EnterInsuredTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.InsuredType, value, new ControlIntent("LossHistory", "InsuredType"), delayMs);

    public Task EnterLastNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.LastName, value, new ControlIntent("LossHistory", "LastName"), delayMs);

    public Task EnterLoanNumberSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.LoanNumber, value, new ControlIntent("LossHistory", "LoanNumber"), delayMs);

    public Task EnterMISequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.MI, value, new ControlIntent("LossHistory", "MI"), delayMs);

    public Task EnterProvisionsApplicableSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ProvisionsApplicable, value, new ControlIntent("LossHistory", "ProvisionsApplicable"), delayMs);

    public Task EnterTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Type, value, new ControlIntent("LossHistory", "Type"), delayMs);

    public Task EnterZipCodeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ZipCode, value, new ControlIntent("LossHistory", "ZipCode"), delayMs);
}
