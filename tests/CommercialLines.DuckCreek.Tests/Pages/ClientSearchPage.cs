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

    public Task EnterAddress17A1FBAsync(string value) =>
        _ui.FillAsync(_locators.Address17A1FB, value, new ControlIntent("ClientSearch", "Address17A1FB"));

    public Task PressAddress17A1FBAsync(string key) =>
        _ui.PressAsync(_locators.Address17A1FB, key, new ControlIntent("ClientSearch", "Address17A1FB"));

    public Task WaitForAddress1CB379Async(string expected) =>
        _ui.WaitAsync(_locators.Address1CB379, expected, new ControlIntent("ClientSearch", "Address1CB379"));

    public Task EnterAddress1CB379Async(string value) =>
        _ui.FillAsync(_locators.Address1CB379, value, new ControlIntent("ClientSearch", "Address1CB379"));

    public Task PressAddress1CB379Async(string key) =>
        _ui.PressAsync(_locators.Address1CB379, key, new ControlIntent("ClientSearch", "Address1CB379"));

    public Task EnterAddress1D319BAsync(string value) =>
        _ui.FillAsync(_locators.Address1D319B, value, new ControlIntent("ClientSearch", "Address1D319B"));

    public Task PressAddress1D319BAsync(string key) =>
        _ui.PressAsync(_locators.Address1D319B, key, new ControlIntent("ClientSearch", "Address1D319B"));

    public Task PressAddress2Async(string key) =>
        _ui.PressAsync(_locators.Address2, key, new ControlIntent("ClientSearch", "Address2"));

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

    public Task WaitForClient070F4Async(string expected) =>
        _ui.WaitAsync(_locators.Client070F4, expected, new ControlIntent("ClientSearch", "Client070F4"));

    public Task VerifyClient070F4Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.Client070F4, expected, property, new ControlIntent("ClientSearch", "Client070F4"));

    public Task ClickClient35F85Async() =>
        _ui.ClickAsync(_locators.Client35F85, new ControlIntent("ClientSearch", "Client35F85"));

    public Task ClickClientSearch2CB16Async() =>
        _ui.ClickAsync(_locators.ClientSearch2CB16, new ControlIntent("ClientSearch", "ClientSearch2CB16"));

    public Task WaitForClientSearch41F28Async(string expected) =>
        _ui.WaitAsync(_locators.ClientSearch41F28, expected, new ControlIntent("ClientSearch", "ClientSearch41F28"));

    public Task ClickClientSearch41F28Async() =>
        _ui.ClickAsync(_locators.ClientSearch41F28, new ControlIntent("ClientSearch", "ClientSearch41F28"));

    public Task ClickClientSearchCA696Async() =>
        _ui.ClickAsync(_locators.ClientSearchCA696, new ControlIntent("ClientSearch", "ClientSearchCA696"));

    public Task WaitForClientSearchFDC36Async(string expected) =>
        _ui.WaitAsync(_locators.ClientSearchFDC36, expected, new ControlIntent("ClientSearch", "ClientSearchFDC36"));

    public Task ClickClientSearchFDC36Async() =>
        _ui.ClickAsync(_locators.ClientSearchFDC36, new ControlIntent("ClientSearch", "ClientSearchFDC36"));

    public Task ClickCompleteAsync() =>
        _ui.ClickAsync(_locators.Complete, new ControlIntent("ClientSearch", "Complete"));

    public Task EnterDOBAsync(string value) =>
        _ui.FillAsync(_locators.DOB, value, new ControlIntent("ClientSearch", "DOB"));

    public Task PressDOBAsync(string key) =>
        _ui.PressAsync(_locators.DOB, key, new ControlIntent("ClientSearch", "DOB"));

    public Task EnterDateOfBirth338D7Async(string value) =>
        _ui.FillAsync(_locators.DateOfBirth338D7, value, new ControlIntent("ClientSearch", "DateOfBirth338D7"));

    public Task PressDateOfBirth338D7Async(string key) =>
        _ui.PressAsync(_locators.DateOfBirth338D7, key, new ControlIntent("ClientSearch", "DateOfBirth338D7"));

    public Task EnterDateOfBirthEA1C4Async(string value) =>
        _ui.FillAsync(_locators.DateOfBirthEA1C4, value, new ControlIntent("ClientSearch", "DateOfBirthEA1C4"));

    public Task PressDateOfBirthEA1C4Async(string key) =>
        _ui.PressAsync(_locators.DateOfBirthEA1C4, key, new ControlIntent("ClientSearch", "DateOfBirthEA1C4"));

    public Task ClickDetail6D228Async() =>
        _ui.ClickAsync(_locators.Detail6D228, new ControlIntent("ClientSearch", "Detail6D228"));

    public Task ClickDetail704E6Async() =>
        _ui.ClickAsync(_locators.Detail704E6, new ControlIntent("ClientSearch", "Detail704E6"));

    public Task WaitForEnterSSN6B3FBAsync(string expected) =>
        _ui.WaitAsync(_locators.EnterSSN6B3FB, expected, new ControlIntent("ClientSearch", "EnterSSN6B3FB"));

    public Task PressEnterSSN6B3FBAsync(string key) =>
        _ui.PressAsync(_locators.EnterSSN6B3FB, key, new ControlIntent("ClientSearch", "EnterSSN6B3FB"));

    public Task ClickEnterSSN6B3FBAsync() =>
        _ui.ClickAsync(_locators.EnterSSN6B3FB, new ControlIntent("ClientSearch", "EnterSSN6B3FB"));

    public Task<string> CaptureEnterSSN6B3FBAsync(string property = "") =>
        _ui.CaptureAsync(_locators.EnterSSN6B3FB, property, new ControlIntent("ClientSearch", "EnterSSN6B3FB"));

    public Task WaitForEnterSSNE3801Async(string expected) =>
        _ui.WaitAsync(_locators.EnterSSNE3801, expected, new ControlIntent("ClientSearch", "EnterSSNE3801"));

    public Task PressEnterSSNE3801Async(string key) =>
        _ui.PressAsync(_locators.EnterSSNE3801, key, new ControlIntent("ClientSearch", "EnterSSNE3801"));

    public Task ClickEnterSSNE3801Async() =>
        _ui.ClickAsync(_locators.EnterSSNE3801, new ControlIntent("ClientSearch", "EnterSSNE3801"));

    public Task WaitForEnterSSNFA186Async(string expected) =>
        _ui.WaitAsync(_locators.EnterSSNFA186, expected, new ControlIntent("ClientSearch", "EnterSSNFA186"));

    public Task EnterEnterSSNFA186Async(string value) =>
        _ui.FillAsync(_locators.EnterSSNFA186, value, new ControlIntent("ClientSearch", "EnterSSNFA186"));

    public Task PressEnterSSNFA186Async(string key) =>
        _ui.PressAsync(_locators.EnterSSNFA186, key, new ControlIntent("ClientSearch", "EnterSSNFA186"));

    public Task ClickEnterSSNFA186Async() =>
        _ui.ClickAsync(_locators.EnterSSNFA186, new ControlIntent("ClientSearch", "EnterSSNFA186"));

    public Task EnterEntityTypeAsync(string value) =>
        _ui.FillAsync(_locators.EntityType, value, new ControlIntent("ClientSearch", "EntityType"));

    public Task PressEntityTypeAsync(string key) =>
        _ui.PressAsync(_locators.EntityType, key, new ControlIntent("ClientSearch", "EntityType"));

    public Task ClickEntityTypeAsync() =>
        _ui.ClickAsync(_locators.EntityType, new ControlIntent("ClientSearch", "EntityType"));

    public Task WaitForFirstName55A0BAsync(string expected) =>
        _ui.WaitAsync(_locators.FirstName55A0B, expected, new ControlIntent("ClientSearch", "FirstName55A0B"));

    public Task EnterFirstName55A0BAsync(string value) =>
        _ui.FillAsync(_locators.FirstName55A0B, value, new ControlIntent("ClientSearch", "FirstName55A0B"));

    public Task PressFirstName55A0BAsync(string key) =>
        _ui.PressAsync(_locators.FirstName55A0B, key, new ControlIntent("ClientSearch", "FirstName55A0B"));

    public Task PressFirstNameC5387Async(string key) =>
        _ui.PressAsync(_locators.FirstNameC5387, key, new ControlIntent("ClientSearch", "FirstNameC5387"));

    public Task EnterGender1DC4AAsync(string value) =>
        _ui.FillAsync(_locators.Gender1DC4A, value, new ControlIntent("ClientSearch", "Gender1DC4A"));

    public Task PressGender1DC4AAsync(string key) =>
        _ui.PressAsync(_locators.Gender1DC4A, key, new ControlIntent("ClientSearch", "Gender1DC4A"));

    public Task EnterGender4973CAsync(string value) =>
        _ui.FillAsync(_locators.Gender4973C, value, new ControlIntent("ClientSearch", "Gender4973C"));

    public Task PressGender4973CAsync(string key) =>
        _ui.PressAsync(_locators.Gender4973C, key, new ControlIntent("ClientSearch", "Gender4973C"));

    public Task ClickIndividualOKAsync() =>
        _ui.ClickAsync(_locators.IndividualOK, new ControlIntent("ClientSearch", "IndividualOK"));

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

    public Task EnterNameOfInspectionContactAsync(string value) =>
        _ui.FillAsync(_locators.NameOfInspectionContact, value, new ControlIntent("ClientSearch", "NameOfInspectionContact"));

    public Task PressNameOfInspectionContactAsync(string key) =>
        _ui.PressAsync(_locators.NameOfInspectionContact, key, new ControlIntent("ClientSearch", "NameOfInspectionContact"));

    public Task WaitForOKAsync(string expected) =>
        _ui.WaitAsync(_locators.OK, expected, new ControlIntent("ClientSearch", "OK"));

    public Task ClickOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("ClientSearch", "OK"));

    public Task ClickOrderSSN5E031Async() =>
        _ui.ClickAsync(_locators.OrderSSN5E031, new ControlIntent("ClientSearch", "OrderSSN5E031"));

    public Task WaitForOrderSSN68C87Async(string expected) =>
        _ui.WaitAsync(_locators.OrderSSN68C87, expected, new ControlIntent("ClientSearch", "OrderSSN68C87"));

    public Task ClickOrderSSN68C87Async() =>
        _ui.ClickAsync(_locators.OrderSSN68C87, new ControlIntent("ClientSearch", "OrderSSN68C87"));

    public Task ClickOrderSSN710BFAsync() =>
        _ui.ClickAsync(_locators.OrderSSN710BF, new ControlIntent("ClientSearch", "OrderSSN710BF"));

    public Task WaitForPleaseVerifySSN3EAB9Async(string expected) =>
        _ui.WaitAsync(_locators.PleaseVerifySSN3EAB9, expected, new ControlIntent("ClientSearch", "PleaseVerifySSN3EAB9"));

    public Task WaitForPleaseVerifySSN8D55BAsync(string expected) =>
        _ui.WaitAsync(_locators.PleaseVerifySSN8D55B, expected, new ControlIntent("ClientSearch", "PleaseVerifySSN8D55B"));

    public Task WaitForPleaseVerifySSNF738AAsync(string expected) =>
        _ui.WaitAsync(_locators.PleaseVerifySSNF738A, expected, new ControlIntent("ClientSearch", "PleaseVerifySSNF738A"));

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

    public Task WaitForVerify34721Async(string expected) =>
        _ui.WaitAsync(_locators.Verify34721, expected, new ControlIntent("ClientSearch", "Verify34721"));

    public Task ClickVerify34721Async() =>
        _ui.ClickAsync(_locators.Verify34721, new ControlIntent("ClientSearch", "Verify34721"));

    public Task VerifyVerify7A388Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.Verify7A388, expected, property, new ControlIntent("ClientSearch", "Verify7A388"));

    public Task ClickVerify7A388Async() =>
        _ui.ClickAsync(_locators.Verify7A388, new ControlIntent("ClientSearch", "Verify7A388"));

    public Task WaitForVerify8CDBEAsync(string expected) =>
        _ui.WaitAsync(_locators.Verify8CDBE, expected, new ControlIntent("ClientSearch", "Verify8CDBE"));

    public Task ClickVerify8CDBEAsync() =>
        _ui.ClickAsync(_locators.Verify8CDBE, new ControlIntent("ClientSearch", "Verify8CDBE"));

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

    public Task VerifyZipCode26D22Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.ZipCode26D22, expected, property, new ControlIntent("ClientSearch", "ZipCode26D22"));

    public Task EnterZipCode26D22Async(string value) =>
        _ui.FillAsync(_locators.ZipCode26D22, value, new ControlIntent("ClientSearch", "ZipCode26D22"));

    public Task PressZipCode26D22Async(string key) =>
        _ui.PressAsync(_locators.ZipCode26D22, key, new ControlIntent("ClientSearch", "ZipCode26D22"));

    public Task EnterZipCodeA088EAsync(string value) =>
        _ui.FillAsync(_locators.ZipCodeA088E, value, new ControlIntent("ClientSearch", "ZipCodeA088E"));

    public Task PressZipCodeA088EAsync(string key) =>
        _ui.PressAsync(_locators.ZipCodeA088E, key, new ControlIntent("ClientSearch", "ZipCodeA088E"));

    public Task EnterZipCodeD2A54Async(string value) =>
        _ui.FillAsync(_locators.ZipCodeD2A54, value, new ControlIntent("ClientSearch", "ZipCodeD2A54"));

    public Task PressZipCodeD2A54Async(string key) =>
        _ui.PressAsync(_locators.ZipCodeD2A54, key, new ControlIntent("ClientSearch", "ZipCodeD2A54"));

}
