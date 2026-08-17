using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class AccountInformationPage
{
    private readonly AccountInformationLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public AccountInformationPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new AccountInformationLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I enter account details
    public async Task EnterAccountDetailsAsync()
    {
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0015_d06ed6Async
        await _ui.WaitAsync(_locators.AccountInformation, "Exists");
        await _ui.VerifyAsync(_locators.FirstNameAccountOwner, _data.Resolve("Exists"), "");
        await _ui.FillAsync(_locators.DOB, _data.Get("AL_ClientData.DOB"));
        await _ui.FillAsync(_locators.BestPhoneAccountOwner, _data.Resolve("{{data:txt_best_phone_account_owner_18}}"));
        await _ui.FillAsync(_locators.EmailAccountOwner, _data.Resolve("{{data:txt_email_account_owner_19}}"));
        await _ui.WaitAsync(_locators.MaritalStatus, "Exists");
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
        await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
        await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
        await _ui.ClickAsync(_locators.Divorced);
        }
        await _ui.FillAsync(_locators.EnterALocation, _data.Get("AL_ClientData.Street Address"));
        await _ui.FillAsync(_locators.OwnerAddressLine2, _data.Get("Apartment"));
        await _ui.FillAsync(_locators.OwnerAddressCityNew, _data.Get("AL_ClientData.City"));
        await _ui.SelectAsync(_locators.DrpdwnState, _data.Resolve(""));
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        await _ui.FillAsync(_locators.OwnerAddressZip, _data.Get("AL_ClientData.ZIP"));
        await _ui.WaitAsync(_locators.Satellite, "Visible");
        // EQAccountDetails_467358Page.AccountDetailsMoveDownTheScreen_0016_d06ed6Async
        await _ui.PressAsync(_locators.AccountDetailsNext, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.AccountDetailsNext, "SHIFTTAB");
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0017_d06ed6Async
        await _ui.SelectAsync(_locators.YesAtLeast90Days, _data.Resolve(""));
        await _ui.WaitAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResides, "Exists");
        await _ui.SelectAsync(_locators.YesClientResides, _data.Resolve(""));
        await _ui.ClickAsync(_locators.AccountDetailsNext);
    }

    // Business step: I enter account details
    public async Task EnterAccountDetailsAsync2()
    {
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0015_8f9ff6Async
        await _ui.WaitAsync(_locators.AccountInformation, "Exists");
        await _ui.VerifyAsync(_locators.FirstNameAccountOwner, _data.Resolve("Exists"), "");
        await _ui.FillAsync(_locators.DOB, _data.Get("AL_ClientData.DOB"));
        await _ui.FillAsync(_locators.BestPhoneAccountOwner, _data.Resolve("{{data:txt_best_phone_account_owner_18}}"));
        await _ui.FillAsync(_locators.EmailAccountOwner, _data.Resolve("{{data:txt_email_account_owner_19}}"));
        await _ui.WaitAsync(_locators.MaritalStatus, "Exists");
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
        await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
        await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
        await _ui.ClickAsync(_locators.Divorced);
        }
        await _ui.FillAsync(_locators.EnterALocation, _data.Get("AL_ClientData.Street Address"));
        await _ui.FillAsync(_locators.OwnerAddressLine2, _data.Get("AL_ClientData.Apartment"));
        await _ui.FillAsync(_locators.OwnerAddressCityNew, _data.Get("AL_ClientData.City"));
        await _ui.SelectAsync(_locators.DrpdwnState, _data.Resolve(""));
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        await _ui.FillAsync(_locators.OwnerAddressZip, _data.Get("AL_ClientData.ZIP"));
        await _ui.WaitAsync(_locators.Satellite, "Visible");
        // EQAccountDetails_467358Page.AccountDetailsMoveDownTheScreen_0016_8f9ff6Async
        await _ui.PressAsync(_locators.AccountDetailsNext, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.AccountDetailsNext, "SHIFTTAB");
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0017_8f9ff6Async
        await _ui.SelectAsync(_locators.YesAtLeast90Days, _data.Resolve(""));
        await _ui.WaitAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResides, "Exists");
        await _ui.SelectAsync(_locators.YesClientResides, _data.Resolve(""));
        await _ui.ClickAsync(_locators.AccountDetailsNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetEffectiveDateBuffer_0018_8f9ff6Async
        _data.Set("EffectiveDate", _data.Resolve("{Date[{DATE}][][MM/dd/yyyy]}"));
    }

    // Business step: I enter account details
    public async Task EnterAccountDetailsAsync3()
    {
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0015_b91c7dAsync
        await _ui.WaitAsync(_locators.AccountInformation, "Exists");
        await _ui.VerifyAsync(_locators.FirstNameAccountOwner, _data.Resolve("Exists"), "");
        await _ui.FillAsync(_locators.DOB, _data.Get("AL_ClientData.DOB"));
        await _ui.FillAsync(_locators.BestPhoneAccountOwner, _data.Resolve("{{data:txt_best_phone_account_owner_18}}"));
        await _ui.FillAsync(_locators.EmailAccountOwner, _data.Resolve("{{data:txt_email_account_owner_19}}"));
        await _ui.WaitAsync(_locators.MaritalStatus, "Exists");
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
        await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
        await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
        await _ui.ClickAsync(_locators.Divorced);
        }
        await _ui.FillAsync(_locators.EnterALocation, _data.Get("AL_ClientData.Street Address"));
        await _ui.FillAsync(_locators.OwnerAddressLine2, _data.Get("Apartment"));
        await _ui.FillAsync(_locators.OwnerAddressCityNew, _data.Get("AL_ClientData.City"));
        await _ui.SelectAsync(_locators.DrpdwnState, _data.Resolve(""));
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        await _ui.FillAsync(_locators.OwnerAddressZip, _data.Get("AL_ClientData.ZIP"));
        await _ui.WaitAsync(_locators.Satellite, "Visible");
        // EQAccountDetails_467358Page.AccountDetailsMoveDownTheScreen_0016_b91c7dAsync
        await _ui.PressAsync(_locators.AccountDetailsNext, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.AccountDetailsNext, "SHIFTTAB");
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0017_b91c7dAsync
        await _ui.SelectAsync(_locators.YesAtLeast90Days, _data.Resolve(""));
        await _ui.WaitAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResides, "Exists");
        await _ui.SelectAsync(_locators.YesClientResides, _data.Resolve(""));
        await _ui.ClickAsync(_locators.AccountDetailsNext);
    }

    // Business step: I enter account details
    public async Task EnterAccountDetailsAsync4()
    {
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0015_8f5301Async
        await _ui.WaitAsync(_locators.AccountInformation, "Exists");
        await _ui.VerifyAsync(_locators.FirstNameAccountOwner, _data.Resolve("Exists"), "");
        await _ui.FillAsync(_locators.DOB, _data.Get("DOB"));
        await _ui.FillAsync(_locators.BestPhoneAccountOwner, _data.Resolve("{{data:txt_best_phone_account_owner_18}}"));
        await _ui.FillAsync(_locators.EmailAccountOwner, _data.Resolve("{{data:txt_email_account_owner_19}}"));
        await _ui.WaitAsync(_locators.MaritalStatus, "Exists");
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
        await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
        await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
        await _ui.ClickAsync(_locators.Divorced);
        }
        await _ui.FillAsync(_locators.EnterALocation, _data.Get("AL_ClientData.Street Address"));
        await _ui.FillAsync(_locators.OwnerAddressLine2, _data.Get("AL_ClientData.Apartment"));
        await _ui.FillAsync(_locators.OwnerAddressCityNew, _data.Get("AL_ClientData.City"));
        await _ui.SelectAsync(_locators.DrpdwnState, _data.Resolve(""));
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        await _ui.FillAsync(_locators.OwnerAddressZip, _data.Get("AL_ClientData.ZIP"));
        await _ui.WaitAsync(_locators.Satellite, "Visible");
        // EQAccountDetails_467358Page.AccountDetailsMoveDownTheScreen_0016_8f5301Async
        await _ui.PressAsync(_locators.AccountDetailsNext, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.AccountDetailsNext, "SHIFTTAB");
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0017_8f5301Async
        await _ui.SelectAsync(_locators.YesAtLeast90Days, _data.Resolve(""));
        await _ui.WaitAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResides, "Exists");
        await _ui.SelectAsync(_locators.YesClientResides, _data.Resolve(""));
        await _ui.ClickAsync(_locators.AccountDetailsNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetEffectiveDateBuffer_0018_8f5301Async
        _data.Set("EffectiveDate", _data.Resolve("{Date[08.08.2024][][MM/dd/yyyy]}"));
    }

    // Business step: I enter account details
    public async Task EnterAccountDetailsAsync5()
    {
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0015_e2e0d7Async
        await _ui.WaitAsync(_locators.AccountInformation, "Exists");
        await _ui.VerifyAsync(_locators.FirstNameAccountOwner, _data.Resolve("Exists"), "");
        await _ui.FillAsync(_locators.DOB, _data.Get("AL_ClientData.DOB"));
        await _ui.FillAsync(_locators.BestPhoneAccountOwner, _data.Resolve("{{data:txt_best_phone_account_owner_18}}"));
        await _ui.FillAsync(_locators.EmailAccountOwner, _data.Resolve("{{data:txt_email_account_owner_19}}"));
        await _ui.WaitAsync(_locators.MaritalStatus, "Exists");
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
        await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
        await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
        await _ui.ClickAsync(_locators.Divorced);
        }
        await _ui.FillAsync(_locators.EnterALocation, _data.Get("AL_ClientData.Street Address"));
        await _ui.FillAsync(_locators.OwnerAddressLine2, _data.Get("AL_ClientData.Apartment"));
        await _ui.FillAsync(_locators.OwnerAddressCityNew, _data.Get("AL_ClientData.City"));
        await _ui.SelectAsync(_locators.DrpdwnState, _data.Resolve(""));
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        await _ui.FillAsync(_locators.OwnerAddressZip, _data.Get("AL_ClientData.ZIP"));
        await _ui.WaitAsync(_locators.Satellite, "Visible");
        // EQAccountDetails_467358Page.AccountDetailsMoveDownTheScreen_0016_e2e0d7Async
        await _ui.PressAsync(_locators.AccountDetailsNext, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.AccountDetailsNext, "SHIFTTAB");
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0017_e2e0d7Async
        await _ui.SelectAsync(_locators.YesAtLeast90Days, _data.Resolve(""));
        await _ui.WaitAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResides, "Exists");
        await _ui.SelectAsync(_locators.YesClientResides, _data.Resolve(""));
        await _ui.ClickAsync(_locators.AccountDetailsNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetEffectiveDateBuffer_0018_e2e0d7Async
        _data.Set("EffectiveDate", _data.Resolve("{Date[{DATE}][][MM/dd/yyyy]}"));
    }

    // Business step: I enter account details
    public async Task EnterAccountDetailsAsync6()
    {
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0015_bafd4aAsync
        await _ui.WaitAsync(_locators.AccountInformation, "Exists");
        await _ui.VerifyAsync(_locators.FirstNameAccountOwner, _data.Resolve("Exists"), "");
        await _ui.FillAsync(_locators.DOB, _data.Get("AL_ClientData.DOB"));
        await _ui.FillAsync(_locators.BestPhoneAccountOwner, _data.Resolve("{{data:txt_best_phone_account_owner_18}}"));
        await _ui.FillAsync(_locators.EmailAccountOwner, _data.Resolve("{{data:txt_email_account_owner_19}}"));
        await _ui.WaitAsync(_locators.MaritalStatus, "Exists");
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
        await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
        await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
        await _ui.ClickAsync(_locators.Divorced);
        }
        await _ui.FillAsync(_locators.EnterALocation, _data.Get("AL_ClientData.Street Address"));
        await _ui.FillAsync(_locators.OwnerAddressLine2, _data.Get("AL_ClientData.Apartment"));
        await _ui.FillAsync(_locators.OwnerAddressCityNew, _data.Get("AL_ClientData.City"));
        await _ui.SelectAsync(_locators.DrpdwnState, _data.Resolve(""));
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        await _ui.FillAsync(_locators.OwnerAddressZip, _data.Get("AL_ClientData.ZIP"));
        await _ui.WaitAsync(_locators.Satellite, "Visible");
        // EQAccountDetails_467358Page.AccountDetailsMoveDownTheScreen_0016_bafd4aAsync
        await _ui.PressAsync(_locators.AccountDetailsNext, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.AccountDetailsNext, "SHIFTTAB");
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0017_bafd4aAsync
        await _ui.SelectAsync(_locators.YesAtLeast90Days, _data.Resolve(""));
        await _ui.WaitAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResides, "Exists");
        await _ui.SelectAsync(_locators.YesClientResides, _data.Resolve(""));
        await _ui.ClickAsync(_locators.AccountDetailsNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetEffectiveDateBuffer_0018_bafd4aAsync
        _data.Set("EffectiveDate", _data.Resolve("{Date[08.08.2024][][MM/dd/yyyy]}"));
    }

    // Business step: I enter account details
    public async Task EnterAccountDetailsAsync7()
    {
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0015_8f4c8fAsync
        await _ui.WaitAsync(_locators.AccountInformation, "Exists");
        await _ui.VerifyAsync(_locators.FirstNameAccountOwner, _data.Resolve("Exists"), "");
        await _ui.FillAsync(_locators.DOB, _data.Get("AL_ClientData.DOB"));
        await _ui.FillAsync(_locators.BestPhoneAccountOwner, _data.Resolve("{{data:txt_best_phone_account_owner_18}}"));
        await _ui.FillAsync(_locators.EmailAccountOwner, _data.Resolve("{{data:txt_email_account_owner_19}}"));
        await _ui.WaitAsync(_locators.MaritalStatus, "Exists");
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
        await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
        await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
        await _ui.ClickAsync(_locators.Divorced);
        }
        await _ui.FillAsync(_locators.EnterALocation, _data.Get("AL_ClientData.Street Address"));
        await _ui.FillAsync(_locators.OwnerAddressLine2, _data.Get("AL_ClientData.Apartment"));
        await _ui.FillAsync(_locators.OwnerAddressCityNew, _data.Get("AL_ClientData.City"));
        await _ui.SelectAsync(_locators.DrpdwnState, _data.Resolve(""));
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        await _ui.FillAsync(_locators.OwnerAddressZip, _data.Get("AL_ClientData.ZIP"));
        await _ui.WaitAsync(_locators.Satellite, "Visible");
        // EQAccountDetails_467358Page.AccountDetailsMoveDownTheScreen_0016_8f4c8fAsync
        await _ui.PressAsync(_locators.AccountDetailsNext, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.AccountDetailsNext, "SHIFTTAB");
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0017_8f4c8fAsync
        await _ui.SelectAsync(_locators.YesAtLeast90Days, _data.Resolve(""));
        await _ui.WaitAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResides, "Exists");
        await _ui.SelectAsync(_locators.YesClientResides, _data.Resolve(""));
        await _ui.ClickAsync(_locators.AccountDetailsNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetEffectiveDateBuffer_0018_8f4c8fAsync
        _data.Set("EffectiveDate", _data.Resolve("{Date[08.08.2025][][MM/dd/yyyy]}"));
    }

    // Business step: I enter account details
    public async Task EnterAccountDetailsAsync8()
    {
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0015_10f911Async
        await _ui.WaitAsync(_locators.AccountInformation, "Exists");
        await _ui.VerifyAsync(_locators.FirstNameAccountOwner, _data.Resolve("Exists"), "");
        await _ui.FillAsync(_locators.DOB, _data.Get("AL_ClientData.DOB"));
        await _ui.FillAsync(_locators.BestPhoneAccountOwner, _data.Resolve("{{data:txt_best_phone_account_owner_18}}"));
        await _ui.FillAsync(_locators.EmailAccountOwner, _data.Resolve("{{data:txt_email_account_owner_19}}"));
        await _ui.WaitAsync(_locators.MaritalStatus, "Exists");
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
        await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
        await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
        await _ui.ClickAsync(_locators.Divorced);
        }
        await _ui.FillAsync(_locators.EnterALocation, _data.Get("AL_ClientData.Street Address"));
        await _ui.FillAsync(_locators.OwnerAddressLine2, _data.Get("AL_ClientData.Apartment"));
        await _ui.FillAsync(_locators.OwnerAddressCityNew, _data.Get("AL_ClientData.City"));
        await _ui.SelectAsync(_locators.DrpdwnState, _data.Resolve(""));
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        await _ui.FillAsync(_locators.OwnerAddressZip, _data.Get("AL_ClientData.ZIP"));
        await _ui.WaitAsync(_locators.Satellite, "Visible");
        // EQAccountDetails_467358Page.AccountDetailsMoveDownTheScreen_0016_10f911Async
        await _ui.PressAsync(_locators.AccountDetailsNext, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.AccountDetailsNext, "SHIFTTAB");
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0017_10f911Async
        await _ui.SelectAsync(_locators.YesAtLeast90Days, _data.Resolve(""));
        await _ui.WaitAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResides, "Exists");
        await _ui.SelectAsync(_locators.YesClientResides, _data.Resolve(""));
        await _ui.ClickAsync(_locators.AccountDetailsNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetEffectiveDateBuffer_0018_10f911Async
        _data.Set("EffectiveDate", _data.Resolve("{Date[{DATE}][][MM/dd/yyyy]}"));
    }

    // Business step: I enter account details
    public async Task EnterAccountDetailsAsync9()
    {
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0015_0dc866Async
        await _ui.WaitAsync(_locators.AccountInformation, "Exists");
        await _ui.VerifyAsync(_locators.FirstNameAccountOwner, _data.Resolve("Exists"), "");
        await _ui.FillAsync(_locators.DOB, _data.Get("AL_ClientData.DOB"));
        await _ui.FillAsync(_locators.BestPhoneAccountOwner, _data.Resolve("{{data:txt_best_phone_account_owner_18}}"));
        await _ui.FillAsync(_locators.EmailAccountOwner, _data.Resolve("{{data:txt_email_account_owner_19}}"));
        await _ui.WaitAsync(_locators.MaritalStatus, "Exists");
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
        await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
        await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
        await _ui.ClickAsync(_locators.Divorced);
        }
        await _ui.FillAsync(_locators.EnterALocation, _data.Get("AL_ClientData.Street Address"));
        await _ui.FillAsync(_locators.OwnerAddressLine2, _data.Get("Apartment"));
        await _ui.FillAsync(_locators.OwnerAddressCityNew, _data.Get("AL_ClientData.City"));
        await _ui.SelectAsync(_locators.DrpdwnState, _data.Resolve(""));
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        await _ui.FillAsync(_locators.OwnerAddressZip, _data.Get("AL_ClientData.ZIP"));
        await _ui.WaitAsync(_locators.Satellite, "Visible");
        // EQAccountDetails_467358Page.AccountDetailsMoveDownTheScreen_0016_0dc866Async
        await _ui.PressAsync(_locators.AccountDetailsNext, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.AccountDetailsNext, "SHIFTTAB");
        // EQAccountDetails_467358Page.AccountDetailsEnterNewAccountInformation_0017_0dc866Async
        await _ui.SelectAsync(_locators.YesAtLeast90Days, _data.Resolve(""));
        await _ui.WaitAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResides, "Exists");
        await _ui.SelectAsync(_locators.YesClientResides, _data.Resolve(""));
        await _ui.ClickAsync(_locators.AccountDetailsNext);
    }

}