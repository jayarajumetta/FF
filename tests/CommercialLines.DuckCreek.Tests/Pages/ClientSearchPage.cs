using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class ClientSearchPage
{
    private readonly BrowserSession _browser;
    private readonly ClientSearchLocators _locators;
    private readonly UiActions _ui;

    public ClientSearchPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new ClientSearchLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickAddNamedInsuredIndividualAsync() =>
        _ui.ClickAsync(_locators.AddNamedInsuredIndividual, new ControlIntent("ClientSearch", "AddNamedInsuredIndividual"));

    public Task WaitForAdditionalInsuredFirstNameAsync(string expected) =>
        _ui.WaitAsync(_locators.AdditionalInsuredFirstName, expected, new ControlIntent("ClientSearch", "AdditionalInsuredFirstName"));

    public Task EnterAdditionalInsuredFirstNameAsync(string value) =>
        _ui.FillAsync(_locators.AdditionalInsuredFirstName, value, new ControlIntent("ClientSearch", "AdditionalInsuredFirstName"));

    public Task PressAdditionalInsuredFirstNameAsync(string key) =>
        _ui.PressAsync(_locators.AdditionalInsuredFirstName, key, new ControlIntent("ClientSearch", "AdditionalInsuredFirstName"));

    public Task EnterAdditionalInsuredMiddleNameAsync(string value) =>
        _ui.FillAsync(_locators.AdditionalInsuredMiddleName, value, new ControlIntent("ClientSearch", "AdditionalInsuredMiddleName"));

    public Task PressAdditionalInsuredMiddleNameAsync(string key) =>
        _ui.PressAsync(_locators.AdditionalInsuredMiddleName, key, new ControlIntent("ClientSearch", "AdditionalInsuredMiddleName"));

    public Task ClickAdditionalNamedInsuredAsync() =>
        _ui.ClickAsync(_locators.AdditionalNamedInsured, new ControlIntent("ClientSearch", "AdditionalNamedInsured"));

    public Task WaitForAdditionalNamedInsuredHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.AdditionalNamedInsuredHeading, expected, new ControlIntent("ClientSearch", "AdditionalNamedInsuredHeading"));

    public Task EnterAddressAsync(string value) =>
        _ui.FillAsync(_locators.Address, value, new ControlIntent("ClientSearch", "Address"));

    public Task PressAddressAsync(string key) =>
        _ui.PressAsync(_locators.Address, key, new ControlIntent("ClientSearch", "Address"));

    public Task WaitForAdditionalInsuredIndividualAddressAsync(string expected) =>
        _ui.WaitAsync(_locators.AdditionalInsuredIndividualAddress, expected, new ControlIntent("ClientSearch", "AdditionalInsuredIndividualAddress"));

    public Task EnterAdditionalInsuredIndividualAddressAsync(string value) =>
        _ui.FillAsync(_locators.AdditionalInsuredIndividualAddress, value, new ControlIntent("ClientSearch", "AdditionalInsuredIndividualAddress"));

    public Task PressAdditionalInsuredIndividualAddressAsync(string key) =>
        _ui.PressAsync(_locators.AdditionalInsuredIndividualAddress, key, new ControlIntent("ClientSearch", "AdditionalInsuredIndividualAddress"));

    public Task PressAddressLineTwoAsync(string key) =>
        _ui.PressAsync(_locators.AddressLineTwo, key, new ControlIntent("ClientSearch", "AddressLineTwo"));

    public Task WaitForBusinessNameAsync(string expected) =>
        _ui.WaitAsync(_locators.BusinessName, expected, new ControlIntent("ClientSearch", "BusinessName"));

    public Task EnterBusinessNameAsync(string value) =>
        _ui.FillAsync(_locators.BusinessName, value, new ControlIntent("ClientSearch", "BusinessName"));

    public Task PressBusinessNameAsync(string key) =>
        _ui.PressAsync(_locators.BusinessName, key, new ControlIntent("ClientSearch", "BusinessName"));

    public Task EnterCityAsync(string value) =>
        _ui.FillAsync(_locators.City, value, new ControlIntent("ClientSearch", "City"));

    public Task PressCityAsync(string key) =>
        _ui.PressAsync(_locators.City, key, new ControlIntent("ClientSearch", "City"));

    public Task WaitForAddClientAsync(string expected) =>
        _ui.WaitAsync(_locators.AddClient, expected, new ControlIntent("ClientSearch", "AddClient"));

    public Task VerifyAddClientAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.AddClient, expected, property, new ControlIntent("ClientSearch", "AddClient"));

    public Task ClickAddClientAsync() =>
        _ui.ClickAsync(_locators.AddClient, new ControlIntent("ClientSearch", "AddClient"));

    public Task ClickClientSearchAsync() =>
        _ui.ClickAsync(_locators.ClientSearch, new ControlIntent("ClientSearch", "ClientSearch"));

    public Task WaitForClientSearchAsync(string expected) =>
        _ui.WaitAsync(_locators.ClientSearch, expected, new ControlIntent("ClientSearch", "ClientSearch"));

    public Task ClickCompleteAsync() =>
        _ui.ClickAsync(_locators.Complete, new ControlIntent("ClientSearch", "Complete"));

    public Task EnterDOBAsync(string value) =>
        _ui.FillAsync(_locators.DOB, value, new ControlIntent("ClientSearch", "DOB"));

    public Task PressDOBAsync(string key) =>
        _ui.PressAsync(_locators.DOB, key, new ControlIntent("ClientSearch", "DOB"));

    public Task EnterAddAssociatedClientDateOfBirthAsync(string value) =>
        _ui.FillAsync(_locators.AddAssociatedClientDateOfBirth, value, new ControlIntent("ClientSearch", "AddAssociatedClientDateOfBirth"));

    public Task PressAddAssociatedClientDateOfBirthAsync(string key) =>
        _ui.PressAsync(_locators.AddAssociatedClientDateOfBirth, key, new ControlIntent("ClientSearch", "AddAssociatedClientDateOfBirth"));

    public Task EnterAdditionalInsuredIndividualDateOfBirthAsync(string value) =>
        _ui.FillAsync(_locators.AdditionalInsuredIndividualDateOfBirth, value, new ControlIntent("ClientSearch", "AdditionalInsuredIndividualDateOfBirth"));

    public Task PressAdditionalInsuredIndividualDateOfBirthAsync(string key) =>
        _ui.PressAsync(_locators.AdditionalInsuredIndividualDateOfBirth, key, new ControlIntent("ClientSearch", "AdditionalInsuredIndividualDateOfBirth"));

    public Task ClickAddAssociatedClientDetailAsync() =>
        _ui.ClickAsync(_locators.AddAssociatedClientDetail, new ControlIntent("ClientSearch", "AddAssociatedClientDetail"));

    public Task ClickAdditionalInsuredIndividualDetailAsync() =>
        _ui.ClickAsync(_locators.AddAssociatedClientDetail, new ControlIntent("ClientSearch", "AdditionalInsuredIndividualDetail"));

    public Task WaitForNamedInsuredIndividualEnterSSNAsync(string expected) =>
        _ui.WaitAsync(_locators.NamedInsuredIndividualEnterSSN, expected, new ControlIntent("ClientSearch", "NamedInsuredIndividualEnterSSN"));

    public Task PressNamedInsuredIndividualEnterSSNAsync(string key) =>
        _ui.PressAsync(_locators.NamedInsuredIndividualEnterSSN, key, new ControlIntent("ClientSearch", "NamedInsuredIndividualEnterSSN"));

    public Task ClickNamedInsuredIndividualEnterSSNAsync() =>
        _ui.ClickAsync(_locators.NamedInsuredIndividualEnterSSN, new ControlIntent("ClientSearch", "NamedInsuredIndividualEnterSSN"));

    public Task<string> CaptureNamedInsuredIndividualEnterSSNAsync(string property = "") =>
        _ui.CaptureAsync(_locators.NamedInsuredIndividualEnterSSN, property, new ControlIntent("ClientSearch", "NamedInsuredIndividualEnterSSN"));

    public Task WaitForAddAssociatedClientEnterSSNAsync(string expected) =>
        _ui.WaitAsync(_locators.AddAssociatedClientEnterSSN, expected, new ControlIntent("ClientSearch", "AddAssociatedClientEnterSSN"));

    public Task PressAddAssociatedClientEnterSSNAsync(string key) =>
        _ui.PressAsync(_locators.AddAssociatedClientEnterSSN, key, new ControlIntent("ClientSearch", "AddAssociatedClientEnterSSN"));

    public Task ClickAddAssociatedClientEnterSSNAsync() =>
        _ui.ClickAsync(_locators.AddAssociatedClientEnterSSN, new ControlIntent("ClientSearch", "AddAssociatedClientEnterSSN"));

    public Task EnterAddAssociatedClientEnterSSNAsync(string value) =>
        _ui.FillAsync(_locators.AddAssociatedClientEnterSSN, value, new ControlIntent("ClientSearch", "AddAssociatedClientEnterSSN"));

    public Task EnterEntityTypeAsync(string value) =>
        _ui.FillAsync(_locators.EntityType, value, new ControlIntent("ClientSearch", "EntityType"));

    public Task PressEntityTypeAsync(string key) =>
        _ui.PressAsync(_locators.EntityType, key, new ControlIntent("ClientSearch", "EntityType"));

    public Task WaitForFirstNameAsync(string expected) =>
        _ui.WaitAsync(_locators.FirstName, expected, new ControlIntent("ClientSearch", "FirstName"));

    public Task EnterFirstNameAsync(string value) =>
        _ui.FillAsync(_locators.FirstName, value, new ControlIntent("ClientSearch", "FirstName"));

    public Task PressFirstNameAsync(string key) =>
        _ui.PressAsync(_locators.FirstName, key, new ControlIntent("ClientSearch", "FirstName"));

    public Task EnterGenderAsync(string value) =>
        _ui.FillAsync(_locators.Gender, value, new ControlIntent("ClientSearch", "Gender"));

    public Task PressGenderAsync(string key) =>
        _ui.PressAsync(_locators.Gender, key, new ControlIntent("ClientSearch", "Gender"));

    public Task ClickOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("ClientSearch", "OK"));

    public Task EnterIndividualTypeAsync(string value) =>
        _ui.FillAsync(_locators.IndividualType, value, new ControlIntent("ClientSearch", "IndividualType"));

    public Task PressIndividualTypeAsync(string key) =>
        _ui.PressAsync(_locators.IndividualType, key, new ControlIntent("ClientSearch", "IndividualType"));

    public Task EnterInsuredEMailAddressAsync(string value) =>
        _ui.FillAsync(_locators.InsuredEMailAddress, value, new ControlIntent("ClientSearch", "InsuredEMailAddress"));

    public Task PressInsuredEMailAddressAsync(string key) =>
        _ui.PressAsync(_locators.InsuredEMailAddress, key, new ControlIntent("ClientSearch", "InsuredEMailAddress"));

    public Task EnterInsuredTypeAsync(string value) =>
        _ui.FillAsync(_locators.InsuredType, value, new ControlIntent("ClientSearch", "InsuredType"));

    public Task PressInsuredTypeAsync(string key) =>
        _ui.PressAsync(_locators.InsuredType, key, new ControlIntent("ClientSearch", "InsuredType"));

    public Task EnterJavaScriptAsync(string value) =>
        _ui.FillAsync(_locators.JavaScript, value, new ControlIntent("ClientSearch", "JavaScript"));

    public Task PressLastNameAsync(string key) =>
        _ui.PressAsync(_locators.LastName, key, new ControlIntent("ClientSearch", "LastName"));

    public Task EnterMiddleNameAsync(string value) =>
        _ui.FillAsync(_locators.MiddleName, value, new ControlIntent("ClientSearch", "MiddleName"));

    public Task PressMiddleNameAsync(string key) =>
        _ui.PressAsync(_locators.MiddleName, key, new ControlIntent("ClientSearch", "MiddleName"));

    public Task EnterNameOfAuditContactAsync(string value) =>
        _ui.FillAsync(_locators.NameOfAuditContact, value, new ControlIntent("ClientSearch", "NameOfAuditContact"));

    public Task PressNameOfAuditContactAsync(string key) =>
        _ui.PressAsync(_locators.NameOfAuditContact, key, new ControlIntent("ClientSearch", "NameOfAuditContact"));

    public Task ClickNameOfAuditContactAsync() =>
        _ui.ClickAsync(_locators.NameOfAuditContact, new ControlIntent("ClientSearch", "NameOfAuditContact"));

    public Task EnterNameOfInspectionContactAsync(string value) =>
        _ui.FillAsync(_locators.NameOfInspectionContact, value, new ControlIntent("ClientSearch", "NameOfInspectionContact"));

    public Task PressNameOfInspectionContactAsync(string key) =>
        _ui.PressAsync(_locators.NameOfInspectionContact, key, new ControlIntent("ClientSearch", "NameOfInspectionContact"));

    public Task ClickNameOfInspectionContactAsync() =>
        _ui.ClickAsync(_locators.NameOfInspectionContact, new ControlIntent("ClientSearch", "NameOfInspectionContact"));

    public Task WaitForOKAsync(string expected) =>
        _ui.WaitAsync(_locators.OK, expected, new ControlIntent("ClientSearch", "OK"));

    public Task ClickOrderSSNAsync() =>
        _ui.ClickAsync(_locators.OrderSSN, new ControlIntent("ClientSearch", "OrderSSN"));

    public Task WaitForOrderSSNAsync(string expected) =>
        _ui.WaitAsync(_locators.OrderSSN, expected, new ControlIntent("ClientSearch", "OrderSSN"));

    public Task WaitForPleaseVerifySSNAsync(string expected) =>
        _ui.WaitAsync(_locators.PleaseVerifySSN, expected, new ControlIntent("ClientSearch", "PleaseVerifySSN"));

    public Task WaitForQuickQuoteAsync(string expected) =>
        _ui.WaitAsync(_locators.QuickQuote, expected, new ControlIntent("ClientSearch", "QuickQuote"));

    public Task SetQuickQuoteAsync(string value) =>
        _ui.SmartSetAsync(_locators.QuickQuote, value, new ControlIntent("ClientSearch", "QuickQuote"));

    public Task VerifyResultAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Result, expected, property, new ControlIntent("ClientSearch", "Result"));

    public Task WaitForReturnToClientAsync(string expected) =>
        _ui.WaitAsync(_locators.ReturnToClient, expected, new ControlIntent("ClientSearch", "ReturnToClient"));

    public Task ClickReturnToClientAsync() =>
        _ui.ClickAsync(_locators.ReturnToClient, new ControlIntent("ClientSearch", "ReturnToClient"));

    public Task WaitForSSNWasNotReturnedAsync(string expected) =>
        _ui.WaitAsync(_locators.SSNWasNotReturned, expected, new ControlIntent("ClientSearch", "SSNWasNotReturned"));

    public Task VerifySearchResultsDuckCreekPolicyFirstCheckboxAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.SearchResultsDuckCreekPolicyFirstCheckbox, expected, property, new ControlIntent("ClientSearch", "SearchResultsDuckCreekPolicyFirstCheckbox"));

    public Task WaitForSocialSecurityAsync(string expected) =>
        _ui.WaitAsync(_locators.SocialSecurity, expected, new ControlIntent("ClientSearch", "SocialSecurity"));

    public Task VerifySocialSecurityAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.SocialSecurity, expected, property, new ControlIntent("ClientSearch", "SocialSecurity"));

    public Task EnterStateAsync(string value) =>
        _ui.FillAsync(_locators.State, value, new ControlIntent("ClientSearch", "State"));

    public Task PressStateAsync(string key) =>
        _ui.PressAsync(_locators.State, key, new ControlIntent("ClientSearch", "State"));

    public Task EnterTitleAsync(string value) =>
        _ui.FillAsync(_locators.Title, value, new ControlIntent("ClientSearch", "Title"));

    public Task WaitForUnderwritingInfoAsync(string expected) =>
        _ui.WaitAsync(_locators.UnderwritingInfo, expected, new ControlIntent("ClientSearch", "UnderwritingInfo"));

    public Task WaitForVerifyAsync(string expected) =>
        _ui.WaitAsync(_locators.Verify, expected, new ControlIntent("ClientSearch", "Verify"));

    public Task ClickVerifyAsync() =>
        _ui.ClickAsync(_locators.Verify, new ControlIntent("ClientSearch", "Verify"));

    public Task VerifyVerifyAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Verify, expected, property, new ControlIntent("ClientSearch", "Verify"));

    public Task EnterWebsiteAddressAsync(string value) =>
        _ui.FillAsync(_locators.WebsiteAddress, value, new ControlIntent("ClientSearch", "WebsiteAddress"));

    public Task PressWebsiteAddressAsync(string key) =>
        _ui.PressAsync(_locators.WebsiteAddress, key, new ControlIntent("ClientSearch", "WebsiteAddress"));

    public Task VerifyYearsInBusinessAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.YearsInBusiness, expected, property, new ControlIntent("ClientSearch", "YearsInBusiness"));

    public Task EnterYearsInBusinessAsync(string value) =>
        _ui.FillAsync(_locators.YearsInBusiness, value, new ControlIntent("ClientSearch", "YearsInBusiness"));

    public Task PressYearsInBusinessAsync(string key) =>
        _ui.PressAsync(_locators.YearsInBusiness, key, new ControlIntent("ClientSearch", "YearsInBusiness"));

    public Task VerifyNamedInsuredZipCodeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.NamedInsuredZipCode, expected, property, new ControlIntent("ClientSearch", "NamedInsuredZipCode"));

    public Task EnterNamedInsuredZipCodeAsync(string value) =>
        _ui.FillAsync(_locators.NamedInsuredZipCode, value, new ControlIntent("ClientSearch", "NamedInsuredZipCode"));

    public Task PressNamedInsuredZipCodeAsync(string key) =>
        _ui.PressAsync(_locators.NamedInsuredZipCode, key, new ControlIntent("ClientSearch", "NamedInsuredZipCode"));

    public Task EnterAdditionalInsuredIndividualZipCodeAsync(string value) =>
        _ui.FillAsync(_locators.AdditionalInsuredIndividualZipCode, value, new ControlIntent("ClientSearch", "AdditionalInsuredIndividualZipCode"));

    public Task PressAdditionalInsuredIndividualZipCodeAsync(string key) =>
        _ui.PressAsync(_locators.AdditionalInsuredIndividualZipCode, key, new ControlIntent("ClientSearch", "AdditionalInsuredIndividualZipCode"));

    public Task EnterLastNameAsync(string value) =>
        _ui.FillAsync(_locators.LastName, value, new ControlIntent("ClientSearch", "LastName"));

    public Task EnterNamedInsuredIndividualEnterSSNAsync(string value) =>
        _ui.FillAsync(_locators.NamedInsuredIndividualEnterSSN, value, new ControlIntent("ClientSearch", "NamedInsuredIndividualEnterSSN"));

    public Task EnterPrimaryPhoneAsync(string value) =>
        _ui.FillAsync(_locators.PrimaryPhone, value, new ControlIntent("ClientSearch", "PrimaryPhone"));

    public Task EnterFEINAsync(string value) =>
        _ui.FillAsync(_locators.FEIN, value, new ControlIntent("ClientSearch", "FEIN"));

    public Task EnterAuditTelephoneAsync(string value) =>
        _ui.FillAsync(_locators.AuditTelephone, value, new ControlIntent("ClientSearch", "AuditTelephone"));

    public Task EnterInspectionTelephoneAsync(string value) =>
        _ui.FillAsync(_locators.InspectionTelephone, value, new ControlIntent("ClientSearch", "InspectionTelephone"));


    public Task EnterAdditionalInsuredFirstNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AdditionalInsuredFirstName, value, new ControlIntent("ClientSearch", "AdditionalInsuredFirstName"), delayMs);

    public Task EnterAdditionalInsuredMiddleNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AdditionalInsuredMiddleName, value, new ControlIntent("ClientSearch", "AdditionalInsuredMiddleName"), delayMs);

    public Task EnterAddressSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Address, value, new ControlIntent("ClientSearch", "Address"), delayMs);

    public Task EnterAdditionalInsuredIndividualAddressSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AdditionalInsuredIndividualAddress, value, new ControlIntent("ClientSearch", "AdditionalInsuredIndividualAddress"), delayMs);

    public Task EnterBusinessNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.BusinessName, value, new ControlIntent("ClientSearch", "BusinessName"), delayMs);

    public Task EnterCitySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.City, value, new ControlIntent("ClientSearch", "City"), delayMs);

    public Task EnterDOBSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DOB, value, new ControlIntent("ClientSearch", "DOB"), delayMs);

    public Task EnterAddAssociatedClientDateOfBirthSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AddAssociatedClientDateOfBirth, value, new ControlIntent("ClientSearch", "AddAssociatedClientDateOfBirth"), delayMs);

    public Task EnterAdditionalInsuredIndividualDateOfBirthSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AdditionalInsuredIndividualDateOfBirth, value, new ControlIntent("ClientSearch", "AdditionalInsuredIndividualDateOfBirth"), delayMs);

    public Task EnterAddAssociatedClientEnterSSNSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AddAssociatedClientEnterSSN, value, new ControlIntent("ClientSearch", "AddAssociatedClientEnterSSN"), delayMs);

    public Task EnterEntityTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.EntityType, value, new ControlIntent("ClientSearch", "EntityType"), delayMs);

    public Task EnterFirstNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.FirstName, value, new ControlIntent("ClientSearch", "FirstName"), delayMs);

    public Task EnterGenderSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Gender, value, new ControlIntent("ClientSearch", "Gender"), delayMs);

    public Task EnterIndividualTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IndividualType, value, new ControlIntent("ClientSearch", "IndividualType"), delayMs);

    public Task EnterInsuredEMailAddressSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.InsuredEMailAddress, value, new ControlIntent("ClientSearch", "InsuredEMailAddress"), delayMs);

    public Task EnterInsuredTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.InsuredType, value, new ControlIntent("ClientSearch", "InsuredType"), delayMs);

    public Task EnterJavaScriptSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.JavaScript, value, new ControlIntent("ClientSearch", "JavaScript"), delayMs);

    public Task EnterMiddleNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.MiddleName, value, new ControlIntent("ClientSearch", "MiddleName"), delayMs);

    public Task EnterNameOfAuditContactSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.NameOfAuditContact, value, new ControlIntent("ClientSearch", "NameOfAuditContact"), delayMs);

    public Task EnterNameOfInspectionContactSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.NameOfInspectionContact, value, new ControlIntent("ClientSearch", "NameOfInspectionContact"), delayMs);

    public Task EnterStateSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.State, value, new ControlIntent("ClientSearch", "State"), delayMs);

    public Task EnterTitleSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Title, value, new ControlIntent("ClientSearch", "Title"), delayMs);

    public Task EnterWebsiteAddressSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.WebsiteAddress, value, new ControlIntent("ClientSearch", "WebsiteAddress"), delayMs);

    public Task EnterYearsInBusinessSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.YearsInBusiness, value, new ControlIntent("ClientSearch", "YearsInBusiness"), delayMs);

    public Task EnterNamedInsuredZipCodeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.NamedInsuredZipCode, value, new ControlIntent("ClientSearch", "NamedInsuredZipCode"), delayMs);

    public Task EnterAdditionalInsuredIndividualZipCodeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AdditionalInsuredIndividualZipCode, value, new ControlIntent("ClientSearch", "AdditionalInsuredIndividualZipCode"), delayMs);

    public Task EnterLastNameSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.LastName, value, new ControlIntent("ClientSearch", "LastName"), delayMs);

    public Task EnterNamedInsuredIndividualEnterSSNSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.NamedInsuredIndividualEnterSSN, value, new ControlIntent("ClientSearch", "NamedInsuredIndividualEnterSSN"), delayMs);

    public Task EnterPrimaryPhoneSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PrimaryPhone, value, new ControlIntent("ClientSearch", "PrimaryPhone"), delayMs);

    public Task EnterFEINSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.FEIN, value, new ControlIntent("ClientSearch", "FEIN"), delayMs);

    public Task EnterAuditTelephoneSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AuditTelephone, value, new ControlIntent("ClientSearch", "AuditTelephone"), delayMs);

    public Task EnterInspectionTelephoneSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.InspectionTelephone, value, new ControlIntent("ClientSearch", "InspectionTelephone"), delayMs);

    public async Task EnterInsuredAndEntityTypeAsync(string insuredType, string entityType)
    {
        await _ui.FillAsync(_locators.InsuredType, insuredType, new ControlIntent("ClientSearch", "InsuredType"));
        await _ui.WaitReadyBestEffortAsync(_locators.EntityType, new ControlIntent("ClientSearch", "EntityType"), 2500);
        await _ui.FillAsync(_locators.EntityType, entityType, new ControlIntent("ClientSearch", "EntityType"));
    }

}
