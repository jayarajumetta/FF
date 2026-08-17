using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class ClientSearchPage
{
    private readonly ClientSearchLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public ClientSearchPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new ClientSearchLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I enter business client information
    public async Task EnterBusinessClientInformationAsync()
    {
        // ClientNamedInsuredCommon_9ad77bPage.DeselectQuickQuote_0037_f7819aAsync
        await _ui.WaitAsync(_locators.QuickQuote, "Exists");
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_2}}"));
        // CommonNavigationLinks_dba56bPage.WaitForNonQuickQuoteElementToAppear_0038_f7819aAsync
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectBusinessInsured_0039_f7819aAsync
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_4}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredBusiness_f0e34fPage.EnterBusinessName_0040_f7819aAsync
        await _ui.WaitAsync(_locators.BusinessName, "Visible");
        await _ui.FillAsync(_locators.BusinessName, _data.Resolve("{{data:business_name_7}}"));
        await _ui.PressAsync(_locators.BusinessName, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0041_f7819aAsync
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_8}}"));
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0041 is generated in the StepDefinition before this PageMethod runs.
        await _ui.PressAsync(_locators.Address17A1FB, "PRE:TAB");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_11}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_12}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0042_f7819aAsync
        await _ui.VerifyAsync(_locators.YearsInBusiness, _data.Resolve("Exists"), "");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0043_f7819aAsync
        await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_14}}"));
        await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        // ClientNamedInsuredBusiness_f0e34fPage.EnterFEIN_0044_f7819aAsync
        // Random data FEIN_0044 is generated in the StepDefinition before this PageMethod runs.
        // ClientOtherInsuredInfo_945242Page.EnterDetailsInOtherInformationSection_0045_f7819aAsync
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_16}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0045 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_18}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_19}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0046_f7819aAsync
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0047_f7819aAsync
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve("{{data:formonpolicydocname}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
    }

    // Business step: I complete the Associated Client Info
    public async Task CompleteTheAssociatedClientInfoAsync()
    {
        // ClientAddAssociatedClient_cb1bd9Page.CompleteTheAssociatedClientInfo_0056_f7819aAsync
        await _ui.FillAsync(_locators.IndividualType, _data.Resolve("{{data:individualtype_45}}"));
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.PressAsync(_locators.IndividualType, "CLICK");
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Exists");
        // ClientAddAssociatedClient_cb1bd9Page.EnterClientDetails_0057_f7819aAsync
        await _ui.PressAsync(_locators.FirstNameC5387, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        // Random data MiddleName_0057 is generated in the StepDefinition before this PageMethod runs.
        // Random data LastName_0057 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.DateOfBirth338D7, _data.Resolve("{{data:dateofbirth_50}}"));
        await _ui.PressAsync(_locators.DateOfBirth338D7, "Tab");
        await _ui.FillAsync(_locators.Address1D319B, _data.Resolve("{{data:address1_51}}"));
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.FillAsync(_locators.City, _data.Resolve("{{data:city_52}}"));
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.FillAsync(_locators.State, _data.Resolve("{{data:state_53}}"));
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.FillAsync(_locators.ZipCodeA088E, _data.Resolve("{{data:zipcode_54}}"));
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.FillAsync(_locators.Gender4973C, _data.Resolve("{{data:gender_55}}"));
        await _ui.PressAsync(_locators.Gender4973C, "Tab");
        await _ui.WaitAsync(_locators.ClientSearch41F28, "Exists");
        await _ui.ClickAsync(_locators.ClientSearch41F28);
        // Random data FirstName_0057 is generated in the StepDefinition before this PageMethod runs.
        // ClientSearchResults_88c18bPage.VerifyNoResultsReturnedAndClickOK_0058_f7819aAsync
        await _ui.VerifyAsync(_locators.SearchResultsDuckCreekPolicyFirstCheckbox, _data.Resolve("Absent"), "");
        await _ui.ClickAsync(_locators.OK);
        // ClientAddAssociatedClient_cb1bd9Page.OrderAndVerifySSN_0059_f7819aAsync
        await _ui.ClickAsync(_locators.OrderSSN5E031);
        await _ui.PressAsync(_locators.EnterSSNFA186, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Enter");
        await _ui.FillAsync(_locators.EnterSSNFA186, _data.Resolve("{{data:enter_ssn_63}}"));
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.ClickAsync(_locators.EnterSSNFA186);
        // ClientAddAssociatedClient_cb1bd9Page.DoesVerifyExist_0060_f7819aAsync
        await _ui.VerifyAsync(_locators.Verify7A388, _data.Resolve("Absent"), "");
        // ClientAddAssociatedClient_cb1bd9Page.ClickComplete_0061_f7819aAsync
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.ClickDetailAndVerifySSN_0062_f7819aAsync
        await _ui.ClickAsync(_locators.Detail6D228);
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.VerifySSN_0063_f7819aAsync
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientSearchResults_88c18bPage.PerformFinalClientSearch_0064_f7819aAsync
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Exists");
        await _ui.ClickAsync(_locators.ClientSearchFDC36);
        // ClientSearchResults_88c18bPage.ClickOk_0065_f7819aAsync
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Absent");
    }

    // Business step: I enter individual client information
    public async Task EnterIndividualClientInformationAsync()
    {
        // ClientNamedInsuredCommon_9ad77bPage.UncheckQuickQuote_0037_515771Async
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_1}}"));
        // CommonNavigationLinks_dba56bPage.WaitOnNonQuickQuoteElement_0038_515771Async
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualInsured_0039_515771Async
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_3}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterNameAndDOB_0040_515771Async
        await _ui.WaitAsync(_locators.FirstName55A0B, "Visible");
        await _ui.PressAsync(_locators.FirstName55A0B, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.FirstName55A0B, _data.Resolve("{{data:first_name_7}}"));
        await _ui.PressAsync(_locators.FirstName55A0B, "CLICK");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.MiddleName, _data.Resolve("{{data:middle_name_8}}"));
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.LastName, "PRE:TAB");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.FillAsync(_locators.DOB, _data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        await _ui.PressAsync(_locators.DOB, "Tab");
        await _ui.PressAsync(_locators.DOB, "Tab");
        if (_data.Condition("State!=\"CA\""))
        {
            await _ui.FillAsync(_locators.Gender1DC4A, _data.Resolve("{{data:gender_11}}"));
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
        }
        // Random data LastName_0040 is generated in the StepDefinition before this PageMethod runs.
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualSoleProprietor_0041_515771Async
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_13}}"));
        await _ui.PressAsync(_locators.EntityType, "Enter");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0041 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_15}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_16}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        // ClientNamedInsuredIndividual_4d5cb5Page.ClickClientSearch_0042_515771Async
        await _ui.ClickAsync(_locators.ClientSearchCA696);
        // ClientSearchResults_88c18bPage.ClientSearchResults_0043_515771Async
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterSSN_0044_515771Async
        await _ui.WaitAsync(_locators.OrderSSN68C87, "Exists");
        await _ui.ClickAsync(_locators.OrderSSN68C87);
        await _ui.WaitAsync(_locators.EnterSSN6B3FB, "Exists");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Enter");
        // Random data InsuredSSN is generated in the StepDefinition before this PageMethod runs.
        _data.Set("SSN", await _ui.CaptureAsync(_locators.EnterSSN6B3FB, "InnerText"));
        await _ui.ClickAsync(_locators.EnterSSN6B3FB);
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Doubleclick");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.ClickAsync(_locators.Verify8CDBE);
        await _ui.WaitAsync(_locators.Verify8CDBE, "Absent");
        // TBoxPartialBuffer_872834Page.PartialBufferTheLastFourOfSSN_0045_515771Async
        _data.Set("Last4SSN", _data.Resolve("{B[SSN]}"));
        // ClientNamedInsuredIndividual_4d5cb5Page.WaitForSSNMask_0046_515771Async
        await _ui.WaitAsync(_locators.SocialSecurity, "Equal");
        // ClientNamedInsuredIndividual_4d5cb5Page.ValidateSSN_0047_515771Async
        await _ui.VerifyAsync(_locators.SocialSecurity, _data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await _ui.WaitAsync(_locators.PleaseVerifySSN3EAB9, "Absent");
        // ClientOtherInsuredInfo_945242Page.EnterOtherInsuredInfo_0048_515771Async
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_33}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "CLICK");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0048 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_35}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0048 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_37}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_38}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0049_515771Async
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0050_515771Async
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve("{{data:formonpolicydocname}}"));
    }

    // Business step: I enter individual client information
    public async Task EnterIndividualClientInformationAsync2()
    {
        // ClientNamedInsuredCommon_9ad77bPage.UncheckQuickQuote_0037_d65717Async
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_1}}"));
        // CommonNavigationLinks_dba56bPage.WaitOnNonQuickQuoteElement_0038_d65717Async
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualInsured_0039_d65717Async
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_3}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterNameAndDOB_0040_d65717Async
        await _ui.WaitAsync(_locators.FirstName55A0B, "Visible");
        await _ui.PressAsync(_locators.FirstName55A0B, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.FirstName55A0B, _data.Resolve("{{data:first_name_7}}"));
        await _ui.PressAsync(_locators.FirstName55A0B, "CLICK");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.MiddleName, _data.Resolve("{{data:middle_name_8}}"));
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.LastName, "PRE:TAB");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.FillAsync(_locators.DOB, _data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        await _ui.PressAsync(_locators.DOB, "Tab");
        await _ui.PressAsync(_locators.DOB, "Tab");
        if (_data.Condition("State!=\"CA\""))
        {
            await _ui.FillAsync(_locators.Gender1DC4A, _data.Resolve("{{data:gender_11}}"));
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
        }
        // Random data LastName_0040 is generated in the StepDefinition before this PageMethod runs.
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualSoleProprietor_0041_d65717Async
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_13}}"));
        await _ui.PressAsync(_locators.EntityType, "Enter");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0041 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_15}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_16}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        // ClientNamedInsuredIndividual_4d5cb5Page.ClickClientSearch_0042_d65717Async
        await _ui.ClickAsync(_locators.ClientSearchCA696);
        // ClientSearchResults_88c18bPage.ClientSearchResults_0043_d65717Async
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterSSN_0044_d65717Async
        await _ui.WaitAsync(_locators.OrderSSN68C87, "Exists");
        await _ui.ClickAsync(_locators.OrderSSN68C87);
        await _ui.WaitAsync(_locators.EnterSSN6B3FB, "Exists");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Enter");
        // Random data InsuredSSN is generated in the StepDefinition before this PageMethod runs.
        _data.Set("SSN", await _ui.CaptureAsync(_locators.EnterSSN6B3FB, "InnerText"));
        await _ui.ClickAsync(_locators.EnterSSN6B3FB);
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Doubleclick");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.ClickAsync(_locators.Verify8CDBE);
        await _ui.WaitAsync(_locators.Verify8CDBE, "Absent");
        // TBoxPartialBuffer_872834Page.PartialBufferTheLastFourOfSSN_0045_d65717Async
        _data.Set("Last4SSN", _data.Resolve("{B[SSN]}"));
        // ClientNamedInsuredIndividual_4d5cb5Page.WaitForSSNMask_0046_d65717Async
        await _ui.WaitAsync(_locators.SocialSecurity, "Equal");
        // ClientNamedInsuredIndividual_4d5cb5Page.ValidateSSN_0047_d65717Async
        await _ui.VerifyAsync(_locators.SocialSecurity, _data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await _ui.WaitAsync(_locators.PleaseVerifySSN3EAB9, "Absent");
        // ClientOtherInsuredInfo_945242Page.EnterOtherInsuredInfo_0048_d65717Async
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_33}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "CLICK");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0048 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_35}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0048 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_37}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_38}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0049_d65717Async
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0050_d65717Async
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve("{{data:formonpolicydocname}}"));
    }

    // Business step: I enter individual client information
    public async Task EnterIndividualClientInformationAsync3()
    {
        // ClientNamedInsuredCommon_9ad77bPage.UncheckQuickQuote_0064_d344b2Async
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_50}}"));
        // CommonNavigationLinks_dba56bPage.WaitOnNonQuickQuoteElement_0065_d344b2Async
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualInsured_0066_d344b2Async
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_52}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterNameAndDOB_0067_d344b2Async
        await _ui.WaitAsync(_locators.FirstName55A0B, "Visible");
        await _ui.PressAsync(_locators.FirstName55A0B, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.FirstName55A0B, _data.Resolve("{{data:first_name_56}}"));
        await _ui.PressAsync(_locators.FirstName55A0B, "CLICK");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.MiddleName, _data.Resolve("{{data:middle_name_57}}"));
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.LastName, "PRE:TAB");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.FillAsync(_locators.DOB, _data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        await _ui.PressAsync(_locators.DOB, "Tab");
        await _ui.PressAsync(_locators.DOB, "Tab");
        if (_data.Condition("State!=\"CA\""))
        {
            await _ui.FillAsync(_locators.Gender1DC4A, _data.Resolve("{{data:gender_60}}"));
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
        }
        // Random data LastName_0067 is generated in the StepDefinition before this PageMethod runs.
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualSoleProprietor_0068_d344b2Async
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_62}}"));
        await _ui.PressAsync(_locators.EntityType, "Enter");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0068 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_64}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_65}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        // ClientNamedInsuredIndividual_4d5cb5Page.ClickClientSearch_0069_d344b2Async
        await _ui.ClickAsync(_locators.ClientSearchCA696);
        // ClientSearchResults_88c18bPage.ClientSearchResults_0070_d344b2Async
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterSSN_0071_d344b2Async
        await _ui.WaitAsync(_locators.OrderSSN68C87, "Exists");
        await _ui.ClickAsync(_locators.OrderSSN68C87);
        await _ui.WaitAsync(_locators.EnterSSN6B3FB, "Exists");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Enter");
        // Random data InsuredSSN is generated in the StepDefinition before this PageMethod runs.
        _data.Set("SSN", await _ui.CaptureAsync(_locators.EnterSSN6B3FB, "InnerText"));
        await _ui.ClickAsync(_locators.EnterSSN6B3FB);
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Doubleclick");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.ClickAsync(_locators.Verify8CDBE);
        await _ui.WaitAsync(_locators.Verify8CDBE, "Absent");
        // TBoxPartialBuffer_872834Page.PartialBufferTheLastFourOfSSN_0072_d344b2Async
        _data.Set("Last4SSN", _data.Resolve("{B[SSN]}"));
        // ClientNamedInsuredIndividual_4d5cb5Page.WaitForSSNMask_0073_d344b2Async
        await _ui.WaitAsync(_locators.SocialSecurity, "Equal");
        // ClientNamedInsuredIndividual_4d5cb5Page.ValidateSSN_0074_d344b2Async
        await _ui.VerifyAsync(_locators.SocialSecurity, _data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await _ui.WaitAsync(_locators.PleaseVerifySSN3EAB9, "Absent");
        // ClientOtherInsuredInfo_945242Page.EnterOtherInsuredInfo_0075_d344b2Async
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_82}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "CLICK");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0075 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_84}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0075 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_86}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_87}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0076_d344b2Async
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0077_d344b2Async
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve(""));
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0078_d344b2Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_94}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_95}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_96}}"), "value");
    }

    // Business step: I enter individual client information
    public async Task EnterIndividualClientInformationAsync4()
    {
        // ClientNamedInsuredCommon_9ad77bPage.UncheckQuickQuote_0064_a1ba9cAsync
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_50}}"));
        // CommonNavigationLinks_dba56bPage.WaitOnNonQuickQuoteElement_0065_a1ba9cAsync
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualInsured_0066_a1ba9cAsync
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_52}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterNameAndDOB_0067_a1ba9cAsync
        await _ui.WaitAsync(_locators.FirstName55A0B, "Visible");
        await _ui.PressAsync(_locators.FirstName55A0B, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.FirstName55A0B, _data.Resolve("{{data:first_name_56}}"));
        await _ui.PressAsync(_locators.FirstName55A0B, "CLICK");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.MiddleName, _data.Resolve("{{data:middle_name_57}}"));
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.LastName, "PRE:TAB");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.FillAsync(_locators.DOB, _data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        await _ui.PressAsync(_locators.DOB, "Tab");
        await _ui.PressAsync(_locators.DOB, "Tab");
        if (_data.Condition("State!=\"CA\""))
        {
            await _ui.FillAsync(_locators.Gender1DC4A, _data.Resolve("{{data:gender_60}}"));
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
        }
        // Random data LastName_0067 is generated in the StepDefinition before this PageMethod runs.
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualSoleProprietor_0068_a1ba9cAsync
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_62}}"));
        await _ui.PressAsync(_locators.EntityType, "Enter");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0068 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_64}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_65}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        // ClientNamedInsuredIndividual_4d5cb5Page.ClickClientSearch_0069_a1ba9cAsync
        await _ui.ClickAsync(_locators.ClientSearchCA696);
        // ClientSearchResults_88c18bPage.ClientSearchResults_0070_a1ba9cAsync
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterSSN_0071_a1ba9cAsync
        await _ui.WaitAsync(_locators.OrderSSN68C87, "Exists");
        await _ui.ClickAsync(_locators.OrderSSN68C87);
        await _ui.WaitAsync(_locators.EnterSSN6B3FB, "Exists");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Enter");
        // Random data InsuredSSN is generated in the StepDefinition before this PageMethod runs.
        _data.Set("SSN", await _ui.CaptureAsync(_locators.EnterSSN6B3FB, "InnerText"));
        await _ui.ClickAsync(_locators.EnterSSN6B3FB);
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Doubleclick");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.ClickAsync(_locators.Verify8CDBE);
        await _ui.WaitAsync(_locators.Verify8CDBE, "Absent");
        // TBoxPartialBuffer_872834Page.PartialBufferTheLastFourOfSSN_0072_a1ba9cAsync
        _data.Set("Last4SSN", _data.Resolve("{B[SSN]}"));
        // ClientNamedInsuredIndividual_4d5cb5Page.WaitForSSNMask_0073_a1ba9cAsync
        await _ui.WaitAsync(_locators.SocialSecurity, "Equal");
        // ClientNamedInsuredIndividual_4d5cb5Page.ValidateSSN_0074_a1ba9cAsync
        await _ui.VerifyAsync(_locators.SocialSecurity, _data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await _ui.WaitAsync(_locators.PleaseVerifySSN3EAB9, "Absent");
        // ClientOtherInsuredInfo_945242Page.EnterOtherInsuredInfo_0075_a1ba9cAsync
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_82}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "CLICK");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0075 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_84}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0075 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_86}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_87}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0076_a1ba9cAsync
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0077_a1ba9cAsync
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve(""));
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0078_a1ba9cAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_94}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_95}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_96}}"), "value");
    }

    // Business step: I enter individual client information
    public async Task EnterIndividualClientInformationAsync5()
    {
        // ClientNamedInsuredCommon_9ad77bPage.UncheckQuickQuote_0037_f90f36Async
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_1}}"));
        // CommonNavigationLinks_dba56bPage.WaitOnNonQuickQuoteElement_0038_f90f36Async
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualInsured_0039_f90f36Async
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_3}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterNameAndDOB_0040_f90f36Async
        await _ui.WaitAsync(_locators.FirstName55A0B, "Visible");
        await _ui.PressAsync(_locators.FirstName55A0B, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.FirstName55A0B, _data.Resolve("{{data:first_name_7}}"));
        await _ui.PressAsync(_locators.FirstName55A0B, "CLICK");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.MiddleName, _data.Resolve("{{data:middle_name_8}}"));
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.LastName, "PRE:TAB");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.FillAsync(_locators.DOB, _data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        await _ui.PressAsync(_locators.DOB, "Tab");
        await _ui.PressAsync(_locators.DOB, "Tab");
        if (_data.Condition("State!=\"CA\""))
        {
            await _ui.FillAsync(_locators.Gender1DC4A, _data.Resolve("{{data:gender_11}}"));
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
        }
        // Random data LastName_0040 is generated in the StepDefinition before this PageMethod runs.
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualSoleProprietor_0041_f90f36Async
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_13}}"));
        await _ui.PressAsync(_locators.EntityType, "Enter");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0041 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_15}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_16}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        // ClientNamedInsuredIndividual_4d5cb5Page.ClickClientSearch_0042_f90f36Async
        await _ui.ClickAsync(_locators.ClientSearchCA696);
        // ClientSearchResults_88c18bPage.ClientSearchResults_0043_f90f36Async
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterSSN_0044_f90f36Async
        await _ui.WaitAsync(_locators.OrderSSN68C87, "Exists");
        await _ui.ClickAsync(_locators.OrderSSN68C87);
        await _ui.WaitAsync(_locators.EnterSSN6B3FB, "Exists");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Enter");
        // Random data InsuredSSN is generated in the StepDefinition before this PageMethod runs.
        _data.Set("SSN", await _ui.CaptureAsync(_locators.EnterSSN6B3FB, "InnerText"));
        await _ui.ClickAsync(_locators.EnterSSN6B3FB);
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Doubleclick");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.ClickAsync(_locators.Verify8CDBE);
        await _ui.WaitAsync(_locators.Verify8CDBE, "Absent");
        // TBoxPartialBuffer_872834Page.PartialBufferTheLastFourOfSSN_0045_f90f36Async
        _data.Set("Last4SSN", _data.Resolve("{B[SSN]}"));
        // ClientNamedInsuredIndividual_4d5cb5Page.WaitForSSNMask_0046_f90f36Async
        await _ui.WaitAsync(_locators.SocialSecurity, "Equal");
        // ClientNamedInsuredIndividual_4d5cb5Page.ValidateSSN_0047_f90f36Async
        await _ui.VerifyAsync(_locators.SocialSecurity, _data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await _ui.WaitAsync(_locators.PleaseVerifySSN3EAB9, "Absent");
        // ClientOtherInsuredInfo_945242Page.EnterOtherInsuredInfo_0048_f90f36Async
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_33}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "CLICK");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0048 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_35}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0048 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_37}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_38}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0049_f90f36Async
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0050_f90f36Async
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve("{{data:formonpolicydocname}}"));
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0051_f90f36Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_45}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_46}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_47}}"), "value");
    }

    // Business step: I enter individual client information
    public async Task EnterIndividualClientInformationAsync6()
    {
        // ClientNamedInsuredCommon_9ad77bPage.UncheckQuickQuote_0064_85cb3fAsync
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_50}}"));
        // CommonNavigationLinks_dba56bPage.WaitOnNonQuickQuoteElement_0065_85cb3fAsync
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualInsured_0066_85cb3fAsync
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_52}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterNameAndDOB_0067_85cb3fAsync
        await _ui.WaitAsync(_locators.FirstName55A0B, "Visible");
        await _ui.PressAsync(_locators.FirstName55A0B, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.FirstName55A0B, _data.Resolve("{{data:first_name_56}}"));
        await _ui.PressAsync(_locators.FirstName55A0B, "CLICK");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.MiddleName, _data.Resolve("{{data:middle_name_57}}"));
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.LastName, "PRE:TAB");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.FillAsync(_locators.DOB, _data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        await _ui.PressAsync(_locators.DOB, "Tab");
        await _ui.PressAsync(_locators.DOB, "Tab");
        if (_data.Condition("State!=\"CA\""))
        {
            await _ui.FillAsync(_locators.Gender1DC4A, _data.Resolve("{{data:gender_60}}"));
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
        }
        // Random data LastName_0067 is generated in the StepDefinition before this PageMethod runs.
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualSoleProprietor_0068_85cb3fAsync
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_62}}"));
        await _ui.PressAsync(_locators.EntityType, "Enter");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0068 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_64}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_65}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        // ClientNamedInsuredIndividual_4d5cb5Page.ClickClientSearch_0069_85cb3fAsync
        await _ui.ClickAsync(_locators.ClientSearchCA696);
        // ClientSearchResults_88c18bPage.ClientSearchResults_0070_85cb3fAsync
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterSSN_0071_85cb3fAsync
        await _ui.WaitAsync(_locators.OrderSSN68C87, "Exists");
        await _ui.ClickAsync(_locators.OrderSSN68C87);
        await _ui.WaitAsync(_locators.EnterSSN6B3FB, "Exists");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Enter");
        // Random data InsuredSSN is generated in the StepDefinition before this PageMethod runs.
        _data.Set("SSN", await _ui.CaptureAsync(_locators.EnterSSN6B3FB, "InnerText"));
        await _ui.ClickAsync(_locators.EnterSSN6B3FB);
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Doubleclick");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.ClickAsync(_locators.Verify8CDBE);
        await _ui.WaitAsync(_locators.Verify8CDBE, "Absent");
        // TBoxPartialBuffer_872834Page.PartialBufferTheLastFourOfSSN_0072_85cb3fAsync
        _data.Set("Last4SSN", _data.Resolve("{B[SSN]}"));
        // ClientNamedInsuredIndividual_4d5cb5Page.WaitForSSNMask_0073_85cb3fAsync
        await _ui.WaitAsync(_locators.SocialSecurity, "Equal");
        // ClientNamedInsuredIndividual_4d5cb5Page.ValidateSSN_0074_85cb3fAsync
        await _ui.VerifyAsync(_locators.SocialSecurity, _data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await _ui.WaitAsync(_locators.PleaseVerifySSN3EAB9, "Absent");
        // ClientOtherInsuredInfo_945242Page.EnterOtherInsuredInfo_0075_85cb3fAsync
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_82}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0075 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_84}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_85}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0076_85cb3fAsync
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0077_85cb3fAsync
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve(""));
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0078_85cb3fAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_92}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_93}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_94}}"), "value");
    }

    // Business step: I enter business client information
    public async Task EnterBusinessClientInformationAsync2()
    {
        // ClientNamedInsuredCommon_9ad77bPage.DeselectQuickQuote_0078_c839dfAsync
        await _ui.WaitAsync(_locators.QuickQuote, "Exists");
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_51}}"));
        // CommonNavigationLinks_dba56bPage.WaitForNonQuickQuoteElementToAppear_0079_c839dfAsync
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectBusinessInsured_0080_c839dfAsync
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_53}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredBusiness_f0e34fPage.EnterBusinessName_0081_c839dfAsync
        await _ui.WaitAsync(_locators.BusinessName, "Visible");
        await _ui.FillAsync(_locators.BusinessName, _data.Resolve("{{data:business_name_56}}"));
        await _ui.PressAsync(_locators.BusinessName, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0082_c839dfAsync
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_57}}"));
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0082 is generated in the StepDefinition before this PageMethod runs.
        await _ui.PressAsync(_locators.Address17A1FB, "PRE:TAB");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_60}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_61}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0083_c839dfAsync
        await _ui.VerifyAsync(_locators.YearsInBusiness, _data.Resolve("Exists"), "");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0084_c839dfAsync
        await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_63}}"));
        await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        // ClientNamedInsuredBusiness_f0e34fPage.EnterFEIN_0085_c839dfAsync
        // Random data FEIN_0085 is generated in the StepDefinition before this PageMethod runs.
        // ClientOtherInsuredInfo_945242Page.EnterDetailsInOtherInformationSection_0086_c839dfAsync
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_65}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0086 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_67}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0086 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_69}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_70}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0087_c839dfAsync
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0088_c839dfAsync
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve(""));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
    }

    // Business step: I complete the Associated Client Info
    public async Task CompleteTheAssociatedClientInfoAsync2()
    {
        // ClientAddAssociatedClient_cb1bd9Page.CompleteTheAssociatedClientInfo_0097_c839dfAsync
        await _ui.FillAsync(_locators.IndividualType, _data.Resolve("{{data:individualtype_96}}"));
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.PressAsync(_locators.IndividualType, "CLICK");
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Exists");
        // ClientAddAssociatedClient_cb1bd9Page.EnterClientDetails_0098_c839dfAsync
        await _ui.PressAsync(_locators.FirstNameC5387, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        // Random data MiddleName_0098 is generated in the StepDefinition before this PageMethod runs.
        // Random data LastName_0098 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.DateOfBirth338D7, _data.Resolve("{{data:dateofbirth_101}}"));
        await _ui.PressAsync(_locators.DateOfBirth338D7, "Tab");
        await _ui.FillAsync(_locators.Address1D319B, _data.Resolve("{{data:address1_102}}"));
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.FillAsync(_locators.City, _data.Resolve("{{data:city_103}}"));
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.FillAsync(_locators.State, _data.Resolve("{{data:state_104}}"));
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.FillAsync(_locators.ZipCodeA088E, _data.Resolve("{{data:zipcode_105}}"));
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.FillAsync(_locators.Gender4973C, _data.Resolve("{{data:gender_106}}"));
        await _ui.PressAsync(_locators.Gender4973C, "Tab");
        await _ui.WaitAsync(_locators.ClientSearch41F28, "Exists");
        await _ui.ClickAsync(_locators.ClientSearch41F28);
        // Random data FirstName_0098 is generated in the StepDefinition before this PageMethod runs.
        // ClientSearchResults_88c18bPage.VerifyNoResultsReturnedAndClickOK_0099_c839dfAsync
        await _ui.VerifyAsync(_locators.SearchResultsDuckCreekPolicyFirstCheckbox, _data.Resolve("Absent"), "");
        await _ui.ClickAsync(_locators.OK);
        // ClientAddAssociatedClient_cb1bd9Page.OrderAndVerifySSN_0100_c839dfAsync
        await _ui.ClickAsync(_locators.OrderSSN5E031);
        await _ui.PressAsync(_locators.EnterSSNFA186, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Enter");
        await _ui.FillAsync(_locators.EnterSSNFA186, _data.Resolve("{{data:enter_ssn_114}}"));
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.ClickAsync(_locators.EnterSSNFA186);
        // ClientAddAssociatedClient_cb1bd9Page.DoesVerifyExist_0101_c839dfAsync
        await _ui.VerifyAsync(_locators.Verify7A388, _data.Resolve("Absent"), "");
        // ClientAddAssociatedClient_cb1bd9Page.ClickComplete_0102_c839dfAsync
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.ClickDetailAndVerifySSN_0103_c839dfAsync
        await _ui.ClickAsync(_locators.Detail6D228);
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.VerifySSN_0104_c839dfAsync
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientSearchResults_88c18bPage.PerformFinalClientSearch_0105_c839dfAsync
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Exists");
        await _ui.ClickAsync(_locators.ClientSearchFDC36);
        // ClientSearchResults_88c18bPage.ClickOk_0106_c839dfAsync
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Absent");
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0107_c839dfAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_132}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_133}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_134}}"), "value");
    }

    // Business step: I enter business client information
    public async Task EnterBusinessClientInformationAsync3()
    {
        // ClientNamedInsuredCommon_9ad77bPage.DeselectQuickQuote_0037_aad19bAsync
        await _ui.WaitAsync(_locators.QuickQuote, "Exists");
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_2}}"));
        // CommonNavigationLinks_dba56bPage.WaitForNonQuickQuoteElementToAppear_0038_aad19bAsync
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectBusinessInsured_0039_aad19bAsync
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_4}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredBusiness_f0e34fPage.EnterBusinessName_0040_aad19bAsync
        await _ui.WaitAsync(_locators.BusinessName, "Visible");
        await _ui.FillAsync(_locators.BusinessName, _data.Resolve("{{data:business_name_7}}"));
        await _ui.PressAsync(_locators.BusinessName, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0041_aad19bAsync
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_8}}"));
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0041 is generated in the StepDefinition before this PageMethod runs.
        await _ui.PressAsync(_locators.Address17A1FB, "PRE:TAB");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_11}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_12}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0042_aad19bAsync
        await _ui.VerifyAsync(_locators.YearsInBusiness, _data.Resolve("Exists"), "");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0043_aad19bAsync
        await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_14}}"));
        await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        // ClientNamedInsuredBusiness_f0e34fPage.EnterFEIN_0044_aad19bAsync
        // Random data FEIN_0044 is generated in the StepDefinition before this PageMethod runs.
        // ClientOtherInsuredInfo_945242Page.EnterDetailsInOtherInformationSection_0045_aad19bAsync
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_16}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0045 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_18}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0045 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_20}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_21}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0046_aad19bAsync
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0047_aad19bAsync
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve("{{data:formonpolicydocname}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
    }

    // Business step: I complete the Associated Client Info
    public async Task CompleteTheAssociatedClientInfoAsync3()
    {
        // ClientAddAssociatedClient_cb1bd9Page.CompleteTheAssociatedClientInfo_0056_aad19bAsync
        await _ui.FillAsync(_locators.IndividualType, _data.Resolve("{{data:individualtype_47}}"));
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.PressAsync(_locators.IndividualType, "CLICK");
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Exists");
        // ClientAddAssociatedClient_cb1bd9Page.EnterClientDetails_0057_aad19bAsync
        await _ui.PressAsync(_locators.FirstNameC5387, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        // Random data MiddleName_0057 is generated in the StepDefinition before this PageMethod runs.
        // Random data LastName_0057 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.DateOfBirth338D7, _data.Resolve("{{data:dateofbirth_52}}"));
        await _ui.PressAsync(_locators.DateOfBirth338D7, "Tab");
        await _ui.FillAsync(_locators.Address1D319B, _data.Resolve("{{data:address1_53}}"));
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.FillAsync(_locators.City, _data.Resolve("{{data:city_54}}"));
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.FillAsync(_locators.State, _data.Resolve("{{data:state_55}}"));
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.FillAsync(_locators.ZipCodeA088E, _data.Resolve("{{data:zipcode_56}}"));
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.FillAsync(_locators.Gender4973C, _data.Resolve("{{data:gender_57}}"));
        await _ui.PressAsync(_locators.Gender4973C, "Tab");
        await _ui.WaitAsync(_locators.ClientSearch41F28, "Exists");
        await _ui.ClickAsync(_locators.ClientSearch41F28);
        // Random data FirstName_0057 is generated in the StepDefinition before this PageMethod runs.
        // ClientSearchResults_88c18bPage.VerifyNoResultsReturnedAndClickOK_0058_aad19bAsync
        await _ui.VerifyAsync(_locators.SearchResultsDuckCreekPolicyFirstCheckbox, _data.Resolve("Absent"), "");
        await _ui.ClickAsync(_locators.OK);
        // ClientAddAssociatedClient_cb1bd9Page.OrderAndVerifySSN_0059_aad19bAsync
        await _ui.ClickAsync(_locators.OrderSSN5E031);
        await _ui.PressAsync(_locators.EnterSSNFA186, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Enter");
        await _ui.FillAsync(_locators.EnterSSNFA186, _data.Resolve("{{data:enter_ssn_65}}"));
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.ClickAsync(_locators.EnterSSNFA186);
        // ClientAddAssociatedClient_cb1bd9Page.DoesVerifyExist_0060_aad19bAsync
        await _ui.VerifyAsync(_locators.Verify7A388, _data.Resolve("Absent"), "");
        // ClientAddAssociatedClient_cb1bd9Page.ClickComplete_0061_aad19bAsync
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.ClickDetailAndVerifySSN_0062_aad19bAsync
        await _ui.ClickAsync(_locators.Detail6D228);
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.VerifySSN_0063_aad19bAsync
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientSearchResults_88c18bPage.PerformFinalClientSearch_0064_aad19bAsync
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Exists");
        await _ui.ClickAsync(_locators.ClientSearchFDC36);
        // ClientSearchResults_88c18bPage.ClickOk_0065_aad19bAsync
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Absent");
    }

    // Business step: I enter business client information
    public async Task EnterBusinessClientInformationAsync4()
    {
        // ClientNamedInsuredCommon_9ad77bPage.DeselectQuickQuote_0037_677267Async
        await _ui.WaitAsync(_locators.QuickQuote, "Exists");
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_2}}"));
        // CommonNavigationLinks_dba56bPage.WaitForNonQuickQuoteElementToAppear_0038_677267Async
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectBusinessInsured_0039_677267Async
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_4}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredBusiness_f0e34fPage.EnterBusinessName_0040_677267Async
        await _ui.WaitAsync(_locators.BusinessName, "Visible");
        await _ui.FillAsync(_locators.BusinessName, _data.Resolve("{{data:business_name_7}}"));
        await _ui.PressAsync(_locators.BusinessName, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0041_677267Async
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_8}}"));
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0041 is generated in the StepDefinition before this PageMethod runs.
        await _ui.PressAsync(_locators.Address17A1FB, "PRE:TAB");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_11}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_12}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0042_677267Async
        await _ui.VerifyAsync(_locators.YearsInBusiness, _data.Resolve("Exists"), "");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0043_677267Async
        await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_14}}"));
        await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        // ClientNamedInsuredBusiness_f0e34fPage.EnterFEIN_0044_677267Async
        // Random data FEIN_0044 is generated in the StepDefinition before this PageMethod runs.
        // ClientOtherInsuredInfo_945242Page.EnterDetailsInOtherInformationSection_0045_677267Async
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_16}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0045 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_18}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0045 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_20}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_21}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0046_677267Async
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0047_677267Async
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve("{{data:formonpolicydocname}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
    }

    // Business step: I complete the Associated Client Info
    public async Task CompleteTheAssociatedClientInfoAsync4()
    {
        // ClientAddAssociatedClient_cb1bd9Page.CompleteTheAssociatedClientInfo_0056_677267Async
        await _ui.FillAsync(_locators.IndividualType, _data.Resolve("{{data:individualtype_47}}"));
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.PressAsync(_locators.IndividualType, "CLICK");
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Exists");
        // ClientAddAssociatedClient_cb1bd9Page.EnterClientDetails_0057_677267Async
        await _ui.PressAsync(_locators.FirstNameC5387, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        // Random data MiddleName_0057 is generated in the StepDefinition before this PageMethod runs.
        // Random data LastName_0057 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.DateOfBirth338D7, _data.Resolve("{{data:dateofbirth_52}}"));
        await _ui.PressAsync(_locators.DateOfBirth338D7, "Tab");
        await _ui.FillAsync(_locators.Address1D319B, _data.Resolve("{{data:address1_53}}"));
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.FillAsync(_locators.City, _data.Resolve("{{data:city_54}}"));
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.FillAsync(_locators.State, _data.Resolve("{{data:state_55}}"));
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.FillAsync(_locators.ZipCodeA088E, _data.Resolve("{{data:zipcode_56}}"));
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.FillAsync(_locators.Gender4973C, _data.Resolve("{{data:gender_57}}"));
        await _ui.PressAsync(_locators.Gender4973C, "Tab");
        await _ui.WaitAsync(_locators.ClientSearch41F28, "Exists");
        await _ui.ClickAsync(_locators.ClientSearch41F28);
        // Random data FirstName_0057 is generated in the StepDefinition before this PageMethod runs.
        // ClientSearchResults_88c18bPage.VerifyNoResultsReturnedAndClickOK_0058_677267Async
        await _ui.VerifyAsync(_locators.SearchResultsDuckCreekPolicyFirstCheckbox, _data.Resolve("Absent"), "");
        await _ui.ClickAsync(_locators.OK);
        // ClientAddAssociatedClient_cb1bd9Page.OrderAndVerifySSN_0059_677267Async
        await _ui.ClickAsync(_locators.OrderSSN5E031);
        await _ui.PressAsync(_locators.EnterSSNFA186, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Enter");
        await _ui.FillAsync(_locators.EnterSSNFA186, _data.Resolve("{{data:enter_ssn_65}}"));
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.ClickAsync(_locators.EnterSSNFA186);
        // ClientAddAssociatedClient_cb1bd9Page.DoesVerifyExist_0060_677267Async
        await _ui.VerifyAsync(_locators.Verify7A388, _data.Resolve("Absent"), "");
        // ClientAddAssociatedClient_cb1bd9Page.ClickComplete_0061_677267Async
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.ClickDetailAndVerifySSN_0062_677267Async
        await _ui.ClickAsync(_locators.Detail6D228);
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.VerifySSN_0063_677267Async
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientSearchResults_88c18bPage.PerformFinalClientSearch_0064_677267Async
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Exists");
        await _ui.ClickAsync(_locators.ClientSearchFDC36);
        // ClientSearchResults_88c18bPage.ClickOk_0065_677267Async
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Absent");
    }

    // Business step: I enter individual client information
    public async Task EnterIndividualClientInformationAsync7()
    {
        // ClientNamedInsuredCommon_9ad77bPage.UncheckQuickQuote_0037_a6f47eAsync
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_1}}"));
        // CommonNavigationLinks_dba56bPage.WaitOnNonQuickQuoteElement_0038_a6f47eAsync
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualInsured_0039_a6f47eAsync
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_3}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterNameAndDOB_0040_a6f47eAsync
        await _ui.WaitAsync(_locators.FirstName55A0B, "Visible");
        await _ui.PressAsync(_locators.FirstName55A0B, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.FirstName55A0B, _data.Resolve("{{data:first_name_7}}"));
        await _ui.PressAsync(_locators.FirstName55A0B, "CLICK");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.MiddleName, _data.Resolve("{{data:middle_name_8}}"));
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.LastName, "PRE:TAB");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.FillAsync(_locators.DOB, _data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        await _ui.PressAsync(_locators.DOB, "Tab");
        await _ui.PressAsync(_locators.DOB, "Tab");
        if (_data.Condition("State!=\"CA\""))
        {
            await _ui.FillAsync(_locators.Gender1DC4A, _data.Resolve("{{data:gender_11}}"));
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
        }
        // Random data LastName_0040 is generated in the StepDefinition before this PageMethod runs.
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualSoleProprietor_0041_a6f47eAsync
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_13}}"));
        await _ui.PressAsync(_locators.EntityType, "Enter");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0041 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_15}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_16}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        // ClientNamedInsuredIndividual_4d5cb5Page.ClickClientSearch_0042_a6f47eAsync
        await _ui.ClickAsync(_locators.ClientSearchCA696);
        // ClientSearchResults_88c18bPage.ClientSearchResults_0043_a6f47eAsync
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterSSN_0044_a6f47eAsync
        await _ui.WaitAsync(_locators.OrderSSN68C87, "Exists");
        await _ui.ClickAsync(_locators.OrderSSN68C87);
        await _ui.WaitAsync(_locators.EnterSSN6B3FB, "Exists");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Enter");
        // Random data InsuredSSN is generated in the StepDefinition before this PageMethod runs.
        _data.Set("SSN", await _ui.CaptureAsync(_locators.EnterSSN6B3FB, "InnerText"));
        await _ui.ClickAsync(_locators.EnterSSN6B3FB);
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Doubleclick");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.ClickAsync(_locators.Verify8CDBE);
        await _ui.WaitAsync(_locators.Verify8CDBE, "Absent");
        // TBoxPartialBuffer_872834Page.PartialBufferTheLastFourOfSSN_0045_a6f47eAsync
        _data.Set("Last4SSN", _data.Resolve("{B[SSN]}"));
        // ClientNamedInsuredIndividual_4d5cb5Page.WaitForSSNMask_0046_a6f47eAsync
        await _ui.WaitAsync(_locators.SocialSecurity, "Equal");
        // ClientNamedInsuredIndividual_4d5cb5Page.ValidateSSN_0047_a6f47eAsync
        await _ui.VerifyAsync(_locators.SocialSecurity, _data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await _ui.WaitAsync(_locators.PleaseVerifySSN3EAB9, "Absent");
        // ClientOtherInsuredInfo_945242Page.EnterOtherInsuredInfo_0048_a6f47eAsync
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_33}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "CLICK");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0048 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_35}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0048 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_37}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_38}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0049_a6f47eAsync
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0050_a6f47eAsync
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve("{{data:formonpolicydocname}}"));
    }

    // Business step: I add Additional Named Insured
    public async Task AddAdditionalNamedInsuredAsync()
    {
        // ClientNamedInsuredCommon_9ad77bPage.CheckIfOnClient_0058_a6f47eAsync
        await _ui.VerifyAsync(_locators.Client070F4, _data.Resolve("Absent"), "");
        // CommonNavigationLinks_dba56bPage.NavigateToClient_0059_a6f47eAsync
        await _ui.ClickAsync(_locators.Client35F85);
        // CommonNavigationLinks_dba56bPage.ClickAdditionalNamedInsured_0060_a6f47eAsync
        await _ui.ClickAsync(_locators.AdditionalNamedInsured);
        // ClientAdditionalNamedInsuredCommon_6dd96cPage.WaitForSynchronization_0061_a6f47eAsync
        await _ui.WaitAsync(_locators.AdditionalNamedInsuredHeading, "Exists");
        // ClientAdditionalInsuredIndividual_86ed73Page.EnterIndividualInfo_0062_a6f47eAsync
        await _ui.ClickAsync(_locators.AddNamedInsuredIndividual);
        await _ui.WaitAsync(_locators.AdditionalInsuredFirstName, "Exists");
        await _ui.FillAsync(_locators.AdditionalInsuredFirstName, _data.Resolve("{{data:additional_insured_first_name_65}}"));
        await _ui.PressAsync(_locators.AdditionalInsuredFirstName, "Tab");
        await _ui.PressAsync(_locators.AdditionalInsuredFirstName, "Tab");
        await _ui.FillAsync(_locators.AdditionalInsuredMiddleName, _data.Resolve("{{data:additional_insured_middle_name_66}}"));
        await _ui.PressAsync(_locators.AdditionalInsuredMiddleName, "Tab");
        // Random data AdditionalInsuredLastName_0062 is generated in the StepDefinition before this PageMethod runs.
        await _ui.ClickAsync(_locators.Detail704E6);
        // ClientAdditionalInsuredIndividual_86ed73Page.EnterIndividualAddressInfo_0064_a6f47eAsync
        await _ui.WaitAsync(_locators.Address1CB379, "Exists");
        await _ui.FillAsync(_locators.Address1CB379, _data.Resolve("{{data:address_1_70}}"));
        await _ui.PressAsync(_locators.Address1CB379, "Tab");
        await _ui.PressAsync(_locators.Address1CB379, "Tab");
        await _ui.PressAsync(_locators.Address1CB379, "Tab");
        await _ui.FillAsync(_locators.ZipCodeD2A54, _data.Resolve("{{data:zip_code_71}}"));
        await _ui.PressAsync(_locators.ZipCodeD2A54, "Tab");
        await _ui.PressAsync(_locators.ZipCodeD2A54, "Tab");
        // ClientAdditionalInsuredIndividual_86ed73Page.EnterDOB_0066_a6f47eAsync
        await _ui.FillAsync(_locators.DateOfBirthEA1C4, _data.Resolve("{{data:date_of_birth_72}}"));
        await _ui.PressAsync(_locators.DateOfBirthEA1C4, "CLICK");
        await _ui.PressAsync(_locators.DateOfBirthEA1C4, "Tab");
        // ClientAdditionalNamedInsuredCommon_6dd96cPage.PerformClientSearch_0067_a6f47eAsync
        await _ui.ClickAsync(_locators.ClientSearch2CB16);
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        // ClientAdditionalInsuredIndividual_86ed73Page.OrderSSN_0068_a6f47eAsync
        await _ui.ClickAsync(_locators.OrderSSN710BF);
        await _ui.WaitAsync(_locators.SSNWasNotReturned, "Exists");
        // ClientAdditionalInsuredIndividual_86ed73Page.EnterSSN_0069_a6f47eAsync
        // Random data InsuredSSN is generated in the StepDefinition before this PageMethod runs.
        await _ui.WaitAsync(_locators.EnterSSNE3801, "Exists");
        await _ui.ClickAsync(_locators.EnterSSNE3801);
        await _ui.PressAsync(_locators.EnterSSNE3801, "Doubleclick");
        await _ui.PressAsync(_locators.EnterSSNE3801, "Tab");
        await _ui.PressAsync(_locators.EnterSSNE3801, "Tab");
        await _ui.ClickAsync(_locators.Verify34721);
        await _ui.WaitAsync(_locators.Verify34721, "Absent");
        // ClientAdditionalInsuredIndividual_86ed73Page.ConfirmEntries_0070_a6f47eAsync
        await _ui.WaitAsync(_locators.PleaseVerifySSN8D55B, "Absent");
        await _ui.ClickAsync(_locators.IndividualOK);
        // ClientAdditionalNamedInsuredCommon_6dd96cPage.ReturnToClient_0071_a6f47eAsync
        await _ui.WaitAsync(_locators.ReturnToClient, "Exists");
        await _ui.ClickAsync(_locators.ReturnToClient);
        // ClientNamedInsuredCommon_9ad77bPage.WaitForSynchronization_0072_a6f47eAsync
        await _ui.WaitAsync(_locators.Client070F4, "Exists");
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0074_a6f47eAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_88}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_89}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_90}}"), "value");
    }

    // Business step: I enter business client information
    public async Task EnterBusinessClientInformationAsync5()
    {
        // ClientNamedInsuredCommon_9ad77bPage.DeselectQuickQuote_0037_767d1bAsync
        await _ui.WaitAsync(_locators.QuickQuote, "Exists");
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_2}}"));
        // CommonNavigationLinks_dba56bPage.WaitForNonQuickQuoteElementToAppear_0038_767d1bAsync
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectBusinessInsured_0039_767d1bAsync
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_4}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredBusiness_f0e34fPage.EnterBusinessName_0040_767d1bAsync
        await _ui.WaitAsync(_locators.BusinessName, "Visible");
        await _ui.FillAsync(_locators.BusinessName, _data.Resolve("{{data:business_name_7}}"));
        await _ui.PressAsync(_locators.BusinessName, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0041_767d1bAsync
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_8}}"));
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0041 is generated in the StepDefinition before this PageMethod runs.
        await _ui.PressAsync(_locators.Address17A1FB, "PRE:TAB");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_11}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_12}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0042_767d1bAsync
        await _ui.VerifyAsync(_locators.YearsInBusiness, _data.Resolve("Exists"), "");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0043_767d1bAsync
        await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_14}}"));
        await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        // ClientNamedInsuredBusiness_f0e34fPage.EnterFEIN_0044_767d1bAsync
        // Random data FEIN_0044 is generated in the StepDefinition before this PageMethod runs.
        // ClientOtherInsuredInfo_945242Page.EnterDetailsInOtherInformationSection_0045_767d1bAsync
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_16}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0045 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_18}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_19}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0046_767d1bAsync
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0047_767d1bAsync
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve("{{data:formonpolicydocname}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
    }

    // Business step: I complete the Associated Client Info
    public async Task CompleteTheAssociatedClientInfoAsync5()
    {
        // ClientAddAssociatedClient_cb1bd9Page.CompleteTheAssociatedClientInfo_0056_767d1bAsync
        await _ui.FillAsync(_locators.IndividualType, _data.Resolve("{{data:individualtype_45}}"));
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.PressAsync(_locators.IndividualType, "CLICK");
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Exists");
        // ClientAddAssociatedClient_cb1bd9Page.EnterClientDetails_0057_767d1bAsync
        await _ui.PressAsync(_locators.FirstNameC5387, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        // Random data MiddleName_0057 is generated in the StepDefinition before this PageMethod runs.
        // Random data LastName_0057 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.DateOfBirth338D7, _data.Resolve("{{data:dateofbirth_50}}"));
        await _ui.PressAsync(_locators.DateOfBirth338D7, "Tab");
        await _ui.FillAsync(_locators.Address1D319B, _data.Resolve("{{data:address1_51}}"));
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.FillAsync(_locators.City, _data.Resolve("{{data:city_52}}"));
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.FillAsync(_locators.State, _data.Resolve("{{data:state_53}}"));
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.FillAsync(_locators.ZipCodeA088E, _data.Resolve("{{data:zipcode_54}}"));
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.FillAsync(_locators.Gender4973C, _data.Resolve("{{data:gender_55}}"));
        await _ui.PressAsync(_locators.Gender4973C, "Tab");
        await _ui.WaitAsync(_locators.ClientSearch41F28, "Exists");
        await _ui.ClickAsync(_locators.ClientSearch41F28);
        // Random data FirstName_0057 is generated in the StepDefinition before this PageMethod runs.
        // ClientSearchResults_88c18bPage.VerifyNoResultsReturnedAndClickOK_0058_767d1bAsync
        await _ui.VerifyAsync(_locators.SearchResultsDuckCreekPolicyFirstCheckbox, _data.Resolve("Absent"), "");
        await _ui.ClickAsync(_locators.OK);
        // ClientAddAssociatedClient_cb1bd9Page.OrderAndVerifySSN_0059_767d1bAsync
        await _ui.ClickAsync(_locators.OrderSSN5E031);
        await _ui.PressAsync(_locators.EnterSSNFA186, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Enter");
        await _ui.FillAsync(_locators.EnterSSNFA186, _data.Resolve("{{data:enter_ssn_63}}"));
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.ClickAsync(_locators.EnterSSNFA186);
        // ClientAddAssociatedClient_cb1bd9Page.DoesVerifyExist_0060_767d1bAsync
        await _ui.VerifyAsync(_locators.Verify7A388, _data.Resolve("Absent"), "");
        // ClientAddAssociatedClient_cb1bd9Page.ClickComplete_0061_767d1bAsync
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.ClickDetailAndVerifySSN_0062_767d1bAsync
        await _ui.ClickAsync(_locators.Detail6D228);
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.VerifySSN_0063_767d1bAsync
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientSearchResults_88c18bPage.PerformFinalClientSearch_0064_767d1bAsync
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Exists");
        await _ui.ClickAsync(_locators.ClientSearchFDC36);
        // ClientSearchResults_88c18bPage.ClickOk_0065_767d1bAsync
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Absent");
    }

    // Business step: I enter business client information
    public async Task EnterBusinessClientInformationAsync6()
    {
        // ClientNamedInsuredCommon_9ad77bPage.DeselectQuickQuote_0037_bb930cAsync
        await _ui.WaitAsync(_locators.QuickQuote, "Exists");
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_2}}"));
        // CommonNavigationLinks_dba56bPage.WaitForNonQuickQuoteElementToAppear_0038_bb930cAsync
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectBusinessInsured_0039_bb930cAsync
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_4}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredBusiness_f0e34fPage.EnterBusinessName_0040_bb930cAsync
        await _ui.WaitAsync(_locators.BusinessName, "Visible");
        await _ui.FillAsync(_locators.BusinessName, _data.Resolve("{{data:business_name_7}}"));
        await _ui.PressAsync(_locators.BusinessName, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0041_bb930cAsync
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_8}}"));
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0041 is generated in the StepDefinition before this PageMethod runs.
        await _ui.PressAsync(_locators.Address17A1FB, "PRE:TAB");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_11}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_12}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0042_bb930cAsync
        await _ui.VerifyAsync(_locators.YearsInBusiness, _data.Resolve("Exists"), "");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0043_bb930cAsync
        await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_14}}"));
        await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        // ClientNamedInsuredBusiness_f0e34fPage.EnterFEIN_0044_bb930cAsync
        // Random data FEIN_0044 is generated in the StepDefinition before this PageMethod runs.
        // ClientOtherInsuredInfo_945242Page.EnterDetailsInOtherInformationSection_0045_bb930cAsync
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_16}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0045 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_18}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0045 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_20}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_21}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0046_bb930cAsync
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0047_bb930cAsync
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve("{{data:formonpolicydocname}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
    }

    // Business step: I complete the Associated Client Info
    public async Task CompleteTheAssociatedClientInfoAsync6()
    {
        // ClientAddAssociatedClient_cb1bd9Page.CompleteTheAssociatedClientInfo_0056_bb930cAsync
        await _ui.FillAsync(_locators.IndividualType, _data.Resolve("{{data:individualtype_47}}"));
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.PressAsync(_locators.IndividualType, "CLICK");
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Exists");
        // ClientAddAssociatedClient_cb1bd9Page.EnterClientDetails_0057_bb930cAsync
        await _ui.PressAsync(_locators.FirstNameC5387, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        // Random data MiddleName_0057 is generated in the StepDefinition before this PageMethod runs.
        // Random data LastName_0057 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.DateOfBirth338D7, _data.Resolve("{{data:dateofbirth_52}}"));
        await _ui.PressAsync(_locators.DateOfBirth338D7, "Tab");
        await _ui.FillAsync(_locators.Address1D319B, _data.Resolve("{{data:address1_53}}"));
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.FillAsync(_locators.City, _data.Resolve("{{data:city_54}}"));
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.FillAsync(_locators.State, _data.Resolve("{{data:state_55}}"));
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.FillAsync(_locators.ZipCodeA088E, _data.Resolve("{{data:zipcode_56}}"));
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.FillAsync(_locators.Gender4973C, _data.Resolve("{{data:gender_57}}"));
        await _ui.PressAsync(_locators.Gender4973C, "Tab");
        await _ui.WaitAsync(_locators.ClientSearch41F28, "Exists");
        await _ui.ClickAsync(_locators.ClientSearch41F28);
        // Random data FirstName_0057 is generated in the StepDefinition before this PageMethod runs.
        // ClientSearchResults_88c18bPage.VerifyNoResultsReturnedAndClickOK_0058_bb930cAsync
        await _ui.VerifyAsync(_locators.SearchResultsDuckCreekPolicyFirstCheckbox, _data.Resolve("Absent"), "");
        await _ui.ClickAsync(_locators.OK);
        // ClientAddAssociatedClient_cb1bd9Page.OrderAndVerifySSN_0059_bb930cAsync
        await _ui.ClickAsync(_locators.OrderSSN5E031);
        await _ui.PressAsync(_locators.EnterSSNFA186, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Enter");
        await _ui.FillAsync(_locators.EnterSSNFA186, _data.Resolve("{{data:enter_ssn_65}}"));
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.ClickAsync(_locators.EnterSSNFA186);
        // ClientAddAssociatedClient_cb1bd9Page.DoesVerifyExist_0060_bb930cAsync
        await _ui.VerifyAsync(_locators.Verify7A388, _data.Resolve("Absent"), "");
        // ClientAddAssociatedClient_cb1bd9Page.ClickComplete_0061_bb930cAsync
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.ClickDetailAndVerifySSN_0062_bb930cAsync
        await _ui.ClickAsync(_locators.Detail6D228);
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.VerifySSN_0063_bb930cAsync
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientSearchResults_88c18bPage.PerformFinalClientSearch_0064_bb930cAsync
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Exists");
        await _ui.ClickAsync(_locators.ClientSearchFDC36);
        // ClientSearchResults_88c18bPage.ClickOk_0065_bb930cAsync
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Absent");
    }

    // Business step: I enter business client information
    public async Task EnterBusinessClientInformationAsync7()
    {
        // ClientNamedInsuredCommon_9ad77bPage.DeselectQuickQuote_0037_a8e5f5Async
        await _ui.WaitAsync(_locators.QuickQuote, "Exists");
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_2}}"));
        // CommonNavigationLinks_dba56bPage.WaitForNonQuickQuoteElementToAppear_0038_a8e5f5Async
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectBusinessInsured_0039_a8e5f5Async
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_4}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredBusiness_f0e34fPage.EnterBusinessName_0040_a8e5f5Async
        await _ui.WaitAsync(_locators.BusinessName, "Visible");
        await _ui.FillAsync(_locators.BusinessName, _data.Resolve("{{data:business_name_7}}"));
        await _ui.PressAsync(_locators.BusinessName, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0041_a8e5f5Async
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_8}}"));
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0041 is generated in the StepDefinition before this PageMethod runs.
        await _ui.PressAsync(_locators.Address17A1FB, "PRE:TAB");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_11}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_12}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0042_a8e5f5Async
        await _ui.VerifyAsync(_locators.YearsInBusiness, _data.Resolve("Exists"), "");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0043_a8e5f5Async
        await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_14}}"));
        await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        // ClientNamedInsuredBusiness_f0e34fPage.EnterFEIN_0044_a8e5f5Async
        // Random data FEIN_0044 is generated in the StepDefinition before this PageMethod runs.
        // ClientOtherInsuredInfo_945242Page.EnterDetailsInOtherInformationSection_0045_a8e5f5Async
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_16}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0045 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_18}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0045 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_20}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_21}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0046_a8e5f5Async
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0047_a8e5f5Async
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve("{{data:formonpolicydocname}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
    }

    // Business step: I complete the Associated Client Info
    public async Task CompleteTheAssociatedClientInfoAsync7()
    {
        // ClientAddAssociatedClient_cb1bd9Page.CompleteTheAssociatedClientInfo_0056_a8e5f5Async
        await _ui.FillAsync(_locators.IndividualType, _data.Resolve("{{data:individualtype_47}}"));
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.PressAsync(_locators.IndividualType, "CLICK");
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Exists");
        // ClientAddAssociatedClient_cb1bd9Page.EnterClientDetails_0057_a8e5f5Async
        await _ui.PressAsync(_locators.FirstNameC5387, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        // Random data MiddleName_0057 is generated in the StepDefinition before this PageMethod runs.
        // Random data LastName_0057 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.DateOfBirth338D7, _data.Resolve("{{data:dateofbirth_52}}"));
        await _ui.PressAsync(_locators.DateOfBirth338D7, "Tab");
        await _ui.FillAsync(_locators.Address1D319B, _data.Resolve("{{data:address1_53}}"));
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.FillAsync(_locators.City, _data.Resolve("{{data:city_54}}"));
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.FillAsync(_locators.State, _data.Resolve("{{data:state_55}}"));
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.FillAsync(_locators.ZipCodeA088E, _data.Resolve("{{data:zipcode_56}}"));
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.FillAsync(_locators.Gender4973C, _data.Resolve("{{data:gender_57}}"));
        await _ui.PressAsync(_locators.Gender4973C, "Tab");
        await _ui.WaitAsync(_locators.ClientSearch41F28, "Exists");
        await _ui.ClickAsync(_locators.ClientSearch41F28);
        // Random data FirstName_0057 is generated in the StepDefinition before this PageMethod runs.
        // ClientSearchResults_88c18bPage.VerifyNoResultsReturnedAndClickOK_0058_a8e5f5Async
        await _ui.VerifyAsync(_locators.SearchResultsDuckCreekPolicyFirstCheckbox, _data.Resolve("Absent"), "");
        await _ui.ClickAsync(_locators.OK);
        // ClientAddAssociatedClient_cb1bd9Page.OrderAndVerifySSN_0059_a8e5f5Async
        await _ui.ClickAsync(_locators.OrderSSN5E031);
        await _ui.PressAsync(_locators.EnterSSNFA186, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Enter");
        await _ui.FillAsync(_locators.EnterSSNFA186, _data.Resolve("{{data:enter_ssn_65}}"));
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.ClickAsync(_locators.EnterSSNFA186);
        // ClientAddAssociatedClient_cb1bd9Page.DoesVerifyExist_0060_a8e5f5Async
        await _ui.VerifyAsync(_locators.Verify7A388, _data.Resolve("Absent"), "");
        // ClientAddAssociatedClient_cb1bd9Page.ClickComplete_0061_a8e5f5Async
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.ClickDetailAndVerifySSN_0062_a8e5f5Async
        await _ui.ClickAsync(_locators.Detail6D228);
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.VerifySSN_0063_a8e5f5Async
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientSearchResults_88c18bPage.PerformFinalClientSearch_0064_a8e5f5Async
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Exists");
        await _ui.ClickAsync(_locators.ClientSearchFDC36);
        // ClientSearchResults_88c18bPage.ClickOk_0065_a8e5f5Async
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Absent");
    }

    // Business step: I enter individual client information
    public async Task EnterIndividualClientInformationAsync8()
    {
        // ClientNamedInsuredCommon_9ad77bPage.UncheckQuickQuote_0064_b3ff07Async
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_50}}"));
        // CommonNavigationLinks_dba56bPage.WaitOnNonQuickQuoteElement_0065_b3ff07Async
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualInsured_0066_b3ff07Async
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_52}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterNameAndDOB_0067_b3ff07Async
        await _ui.WaitAsync(_locators.FirstName55A0B, "Visible");
        await _ui.PressAsync(_locators.FirstName55A0B, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.FirstName55A0B, _data.Resolve("{{data:first_name_56}}"));
        await _ui.PressAsync(_locators.FirstName55A0B, "CLICK");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.MiddleName, _data.Resolve("{{data:middle_name_57}}"));
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.LastName, "PRE:TAB");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.FillAsync(_locators.DOB, _data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        await _ui.PressAsync(_locators.DOB, "Tab");
        await _ui.PressAsync(_locators.DOB, "Tab");
        if (_data.Condition("State!=\"CA\""))
        {
            await _ui.FillAsync(_locators.Gender1DC4A, _data.Resolve("{{data:gender_60}}"));
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
        }
        // Random data LastName_0067 is generated in the StepDefinition before this PageMethod runs.
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualSoleProprietor_0068_b3ff07Async
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_62}}"));
        await _ui.PressAsync(_locators.EntityType, "Enter");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0068 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_64}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_65}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        // ClientNamedInsuredIndividual_4d5cb5Page.ClickClientSearch_0069_b3ff07Async
        await _ui.ClickAsync(_locators.ClientSearchCA696);
        // ClientSearchResults_88c18bPage.ClientSearchResults_0070_b3ff07Async
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterSSN_0071_b3ff07Async
        await _ui.WaitAsync(_locators.OrderSSN68C87, "Exists");
        await _ui.ClickAsync(_locators.OrderSSN68C87);
        await _ui.WaitAsync(_locators.EnterSSN6B3FB, "Exists");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Enter");
        // Random data InsuredSSN is generated in the StepDefinition before this PageMethod runs.
        _data.Set("SSN", await _ui.CaptureAsync(_locators.EnterSSN6B3FB, "InnerText"));
        await _ui.ClickAsync(_locators.EnterSSN6B3FB);
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Doubleclick");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.ClickAsync(_locators.Verify8CDBE);
        await _ui.WaitAsync(_locators.Verify8CDBE, "Absent");
        // TBoxPartialBuffer_872834Page.PartialBufferTheLastFourOfSSN_0072_b3ff07Async
        _data.Set("Last4SSN", _data.Resolve("{B[SSN]}"));
        // ClientNamedInsuredIndividual_4d5cb5Page.WaitForSSNMask_0073_b3ff07Async
        await _ui.WaitAsync(_locators.SocialSecurity, "Equal");
        // ClientNamedInsuredIndividual_4d5cb5Page.ValidateSSN_0074_b3ff07Async
        await _ui.VerifyAsync(_locators.SocialSecurity, _data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await _ui.WaitAsync(_locators.PleaseVerifySSN3EAB9, "Absent");
        // ClientOtherInsuredInfo_945242Page.EnterOtherInsuredInfo_0075_b3ff07Async
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_82}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "CLICK");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0075 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_84}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0075 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_86}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_87}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0076_b3ff07Async
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0077_b3ff07Async
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve(""));
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0078_b3ff07Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_94}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_95}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_96}}"), "value");
    }

    // Business step: I enter individual client information
    public async Task EnterIndividualClientInformationAsync9()
    {
        // ClientNamedInsuredCommon_9ad77bPage.UncheckQuickQuote_0065_c7d608Async
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_50}}"));
        // CommonNavigationLinks_dba56bPage.WaitOnNonQuickQuoteElement_0066_c7d608Async
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualInsured_0067_c7d608Async
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_52}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterNameAndDOB_0068_c7d608Async
        await _ui.WaitAsync(_locators.FirstName55A0B, "Visible");
        await _ui.PressAsync(_locators.FirstName55A0B, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.FirstName55A0B, _data.Resolve("{{data:first_name_56}}"));
        await _ui.PressAsync(_locators.FirstName55A0B, "CLICK");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.MiddleName, _data.Resolve("{{data:middle_name_57}}"));
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.LastName, "PRE:TAB");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.FillAsync(_locators.DOB, _data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        await _ui.PressAsync(_locators.DOB, "Tab");
        await _ui.PressAsync(_locators.DOB, "Tab");
        if (_data.Condition("State!=\"CA\""))
        {
            await _ui.FillAsync(_locators.Gender1DC4A, _data.Resolve("{{data:gender_60}}"));
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
        }
        // Random data LastName_0068 is generated in the StepDefinition before this PageMethod runs.
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualSoleProprietor_0069_c7d608Async
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_62}}"));
        await _ui.PressAsync(_locators.EntityType, "Enter");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0069 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_64}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_65}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        // ClientNamedInsuredIndividual_4d5cb5Page.ClickClientSearch_0070_c7d608Async
        await _ui.ClickAsync(_locators.ClientSearchCA696);
        // ClientSearchResults_88c18bPage.ClientSearchResults_0071_c7d608Async
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterSSN_0072_c7d608Async
        await _ui.WaitAsync(_locators.OrderSSN68C87, "Exists");
        await _ui.ClickAsync(_locators.OrderSSN68C87);
        await _ui.WaitAsync(_locators.EnterSSN6B3FB, "Exists");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Enter");
        // Random data InsuredSSN is generated in the StepDefinition before this PageMethod runs.
        _data.Set("SSN", await _ui.CaptureAsync(_locators.EnterSSN6B3FB, "InnerText"));
        await _ui.ClickAsync(_locators.EnterSSN6B3FB);
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Doubleclick");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.ClickAsync(_locators.Verify8CDBE);
        await _ui.WaitAsync(_locators.Verify8CDBE, "Absent");
        // TBoxPartialBuffer_872834Page.PartialBufferTheLastFourOfSSN_0073_c7d608Async
        _data.Set("Last4SSN", _data.Resolve("{B[SSN]}"));
        // ClientNamedInsuredIndividual_4d5cb5Page.WaitForSSNMask_0074_c7d608Async
        await _ui.WaitAsync(_locators.SocialSecurity, "Equal");
        // ClientNamedInsuredIndividual_4d5cb5Page.ValidateSSN_0075_c7d608Async
        await _ui.VerifyAsync(_locators.SocialSecurity, _data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await _ui.WaitAsync(_locators.PleaseVerifySSN3EAB9, "Absent");
        // ClientOtherInsuredInfo_945242Page.EnterOtherInsuredInfo_0076_c7d608Async
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_82}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "CLICK");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0076 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_84}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0076 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_86}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_87}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0077_c7d608Async
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0078_c7d608Async
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve(""));
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0079_c7d608Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_94}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_95}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_96}}"), "value");
    }

    // Business step: I enter individual client information
    public async Task EnterIndividualClientInformationAsync10()
    {
        // ClientNamedInsuredCommon_9ad77bPage.UncheckQuickQuote_0064_2a8772Async
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_50}}"));
        // CommonNavigationLinks_dba56bPage.WaitOnNonQuickQuoteElement_0065_2a8772Async
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualInsured_0066_2a8772Async
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_52}}"));
        await _ui.PressAsync(_locators.InsuredType, "Enter");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.ClickAsync(_locators.EntityType);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterNameAndDOB_0067_2a8772Async
        await _ui.WaitAsync(_locators.FirstName55A0B, "Visible");
        await _ui.PressAsync(_locators.FirstName55A0B, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.FirstName55A0B, _data.Resolve("{{data:first_name_56}}"));
        await _ui.PressAsync(_locators.FirstName55A0B, "CLICK");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.PressAsync(_locators.FirstName55A0B, "Tab");
        await _ui.FillAsync(_locators.MiddleName, _data.Resolve("{{data:middle_name_57}}"));
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.MiddleName, "Tab");
        await _ui.PressAsync(_locators.LastName, "PRE:TAB");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.FillAsync(_locators.DOB, _data.Resolve("{DATE[][-40y][MM-dd-yyyy]}"));
        await _ui.PressAsync(_locators.DOB, "Tab");
        await _ui.PressAsync(_locators.DOB, "Tab");
        if (_data.Condition("State!=\"CA\""))
        {
            await _ui.FillAsync(_locators.Gender1DC4A, _data.Resolve("{{data:gender_60}}"));
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
            await _ui.PressAsync(_locators.Gender1DC4A, "Tab");
        }
        // Random data LastName_0067 is generated in the StepDefinition before this PageMethod runs.
        // ClientNamedInsuredCommon_9ad77bPage.SelectIndividualSoleProprietor_0068_2a8772Async
        await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_62}}"));
        await _ui.PressAsync(_locators.EntityType, "Enter");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        await _ui.PressAsync(_locators.EntityType, "Tab");
        // Random data PrimaryPhone_0068 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_64}}"));
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_65}}"));
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        // ClientNamedInsuredIndividual_4d5cb5Page.ClickClientSearch_0069_2a8772Async
        await _ui.ClickAsync(_locators.ClientSearchCA696);
        // ClientSearchResults_88c18bPage.ClientSearchResults_0070_2a8772Async
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        // ClientNamedInsuredIndividual_4d5cb5Page.EnterSSN_0071_2a8772Async
        await _ui.WaitAsync(_locators.OrderSSN68C87, "Exists");
        await _ui.ClickAsync(_locators.OrderSSN68C87);
        await _ui.WaitAsync(_locators.EnterSSN6B3FB, "Exists");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Enter");
        // Random data InsuredSSN is generated in the StepDefinition before this PageMethod runs.
        _data.Set("SSN", await _ui.CaptureAsync(_locators.EnterSSN6B3FB, "InnerText"));
        await _ui.ClickAsync(_locators.EnterSSN6B3FB);
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Doubleclick");
        await _ui.PressAsync(_locators.EnterSSN6B3FB, "Tab");
        await _ui.ClickAsync(_locators.Verify8CDBE);
        await _ui.WaitAsync(_locators.Verify8CDBE, "Absent");
        // TBoxPartialBuffer_872834Page.PartialBufferTheLastFourOfSSN_0072_2a8772Async
        _data.Set("Last4SSN", _data.Resolve("{B[SSN]}"));
        // ClientNamedInsuredIndividual_4d5cb5Page.WaitForSSNMask_0073_2a8772Async
        await _ui.WaitAsync(_locators.SocialSecurity, "Equal");
        // ClientNamedInsuredIndividual_4d5cb5Page.ValidateSSN_0074_2a8772Async
        await _ui.VerifyAsync(_locators.SocialSecurity, _data.Resolve("XXX-XX-{B[Last4SSN]}"), "InnerText");
        await _ui.WaitAsync(_locators.PleaseVerifySSN3EAB9, "Absent");
        // ClientOtherInsuredInfo_945242Page.EnterOtherInsuredInfo_0075_2a8772Async
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_82}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "CLICK");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0075 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_84}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0075 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_86}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_87}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // ClientNamedInsuredCommon_9ad77bPage.VerifyZipCode4_0076_2a8772Async
        await _ui.PressAsync(_locators.Address2, "PRE:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.VerifyAsync(_locators.ZipCode26D22, _data.Resolve("[0-9]{5}-[0-9]{4}"), "Regex:value");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0077_2a8772Async
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
        _data.Set("Server", _data.Resolve("{{data:server}}"));
        _data.Set("FormOnPolicyDocName", _data.Resolve(""));
        // VerifyJavaScriptResult_c744f4Page.GetQuoteIDAndBuffer_0078_2a8772Async
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_94}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_95}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{{data:expected_result_value_96}}"), "value");
    }

    // Business step: I enter business client information
    public async Task EnterBusinessClientInformationAsync8()
    {
        // ClientNamedInsuredCommon_9ad77bPage.DeselectQuickQuote_0037_f2d6bdAsync
        await _ui.WaitAsync(_locators.QuickQuote, "Exists");
        await _ui.SmartSetAsync(_locators.QuickQuote, _data.Resolve("{{data:quick_quote_2}}"));
        // CommonNavigationLinks_dba56bPage.WaitForNonQuickQuoteElementToAppear_0038_f2d6bdAsync
        await _ui.WaitAsync(_locators.UnderwritingInfo, "Exists");
        // ClientNamedInsuredCommon_9ad77bPage.SelectBusinessInsured_0039_f2d6bdAsync
        if (_data.Condition("'Insured Type' != NULL"))
        {
            await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_4}}"));
            await _ui.PressAsync(_locators.InsuredType, "Tab");
            await _ui.PressAsync(_locators.InsuredType, "CLICK");
            await _ui.PressAsync(_locators.InsuredType, "Tab");
            await _ui.PressAsync(_locators.InsuredType, "Tab");
        }
        if (_data.Condition("'Insured Type' != NULL"))
        {
            await _ui.ClickAsync(_locators.EntityType);
        }
        // ClientNamedInsuredBusiness_f0e34fPage.EnterBusinessName_0040_f2d6bdAsync
        await _ui.WaitAsync(_locators.BusinessName, "Visible");
        if (_data.Condition("'Business Name' != NULL"))
        {
            await _ui.FillAsync(_locators.BusinessName, _data.Resolve("{{data:business_name_7}}"));
            await _ui.PressAsync(_locators.BusinessName, "Tab");
            await _ui.PressAsync(_locators.BusinessName, "CLICK");
            await _ui.PressAsync(_locators.BusinessName, "Tab");
        }
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0041_f2d6bdAsync
        if (_data.Condition("'Legal Nature' != NULL"))
        {
            await _ui.FillAsync(_locators.EntityType, _data.Resolve("{{data:entity_type_8}}"));
            await _ui.PressAsync(_locators.EntityType, "Tab");
            await _ui.PressAsync(_locators.EntityType, "CLICK");
            await _ui.PressAsync(_locators.EntityType, "Tab");
        }
        // Random data PrimaryPhone_0041 is generated in the StepDefinition before this PageMethod runs.
        if (_data.Condition("'Address 1' != NULL"))
        {
            await _ui.FillAsync(_locators.Address17A1FB, _data.Resolve("{{data:address1_10}}"));
            await _ui.PressAsync(_locators.Address17A1FB, "Tab");
            await _ui.PressAsync(_locators.Address17A1FB, "CLICK");
            await _ui.PressAsync(_locators.Address17A1FB, "Tab");
        }
        if (_data.Condition("ZipCode != NULL"))
        {
            await _ui.FillAsync(_locators.ZipCode26D22, _data.Resolve("{{data:zipcode_11}}"));
            await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
            await _ui.PressAsync(_locators.ZipCode26D22, "CLICK");
            await _ui.PressAsync(_locators.ZipCode26D22, "Tab");
        }
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0042_f2d6bdAsync
        await _ui.VerifyAsync(_locators.YearsInBusiness, _data.Resolve("Exists"), "");
        // ClientNamedInsuredCommon_9ad77bPage.EnterBusinessInfo_0043_f2d6bdAsync
        await _ui.FillAsync(_locators.YearsInBusiness, _data.Resolve("{{data:years_in_business_13}}"));
        await _ui.PressAsync(_locators.YearsInBusiness, "Tab");
        // ClientNamedInsuredBusiness_f0e34fPage.EnterFEIN_0044_f2d6bdAsync
        // Random data FEIN_0044 is generated in the StepDefinition before this PageMethod runs.
        // ClientOtherInsuredInfo_945242Page.EnterDetailsInOtherInformationSection_0045_f2d6bdAsync
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            await _ui.FillAsync(_locators.NameOfAuditContact, _data.Resolve("{{data:name_of_audit_contact_15}}"));
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
            await _ui.PressAsync(_locators.NameOfAuditContact, "CLICK");
            await _ui.PressAsync(_locators.NameOfAuditContact, "Tab");
        }
        if (_data.Condition("'Product (LOB)' != \"UMB\""))
        {
            // Random data AuditTelephone_0045 is generated in the StepDefinition before this PageMethod runs.
        }
        await _ui.FillAsync(_locators.NameOfInspectionContact, _data.Resolve("{{data:name_of_inspection_contact_17}}"));
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "CLICK");
        await _ui.PressAsync(_locators.NameOfInspectionContact, "Tab");
        // Random data InspectionTelephone_0045 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.InsuredEMailAddress, _data.Resolve("{{data:insured_e_mail_address_19}}"));
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "CLICK");
        await _ui.PressAsync(_locators.InsuredEMailAddress, "Tab");
        await _ui.FillAsync(_locators.WebsiteAddress, _data.Resolve("{{data:website_address_20}}"));
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        await _ui.PressAsync(_locators.WebsiteAddress, "CLICK");
        await _ui.PressAsync(_locators.WebsiteAddress, "Tab");
        // TBoxSetBuffer_e51da1Page.SetBufferForStateAndProduct_0046_f2d6bdAsync
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Product (LOB)", _data.Resolve("{{data:product_lob}}"));
    }

    // Business step: I complete the Associated Client Info
    public async Task CompleteTheAssociatedClientInfoAsync8()
    {
        // ClientAddAssociatedClient_cb1bd9Page.CompleteTheAssociatedClientInfo_0055_f2d6bdAsync
        await _ui.FillAsync(_locators.IndividualType, _data.Resolve("{{data:individualtype_42}}"));
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.PressAsync(_locators.IndividualType, "CLICK");
        await _ui.PressAsync(_locators.IndividualType, "Tab");
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Exists");
        // ClientAddAssociatedClient_cb1bd9Page.EnterClientDetails_0056_f2d6bdAsync
        await _ui.PressAsync(_locators.FirstNameC5387, "PRE:TAB");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        await _ui.PressAsync(_locators.FirstNameC5387, "Tab");
        // Random data MiddleName_0056 is generated in the StepDefinition before this PageMethod runs.
        // Random data LastName_0056 is generated in the StepDefinition before this PageMethod runs.
        await _ui.FillAsync(_locators.DateOfBirth338D7, _data.Resolve("{{data:dateofbirth_47}}"));
        await _ui.PressAsync(_locators.DateOfBirth338D7, "Tab");
        await _ui.FillAsync(_locators.Address1D319B, _data.Resolve("{{data:address1_48}}"));
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.PressAsync(_locators.Address1D319B, "Tab");
        await _ui.FillAsync(_locators.City, _data.Resolve("{{data:city_49}}"));
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.FillAsync(_locators.State, _data.Resolve("{{data:state_50}}"));
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.FillAsync(_locators.ZipCodeA088E, _data.Resolve("{{data:zipcode_51}}"));
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.PressAsync(_locators.ZipCodeA088E, "Tab");
        await _ui.FillAsync(_locators.Gender4973C, _data.Resolve("{{data:gender_52}}"));
        await _ui.PressAsync(_locators.Gender4973C, "Tab");
        await _ui.WaitAsync(_locators.ClientSearch41F28, "Exists");
        await _ui.ClickAsync(_locators.ClientSearch41F28);
        // Random data FirstName_0056 is generated in the StepDefinition before this PageMethod runs.
        // ClientSearchResults_88c18bPage.VerifyNoResultsReturnedAndClickOK_0057_f2d6bdAsync
        await _ui.VerifyAsync(_locators.SearchResultsDuckCreekPolicyFirstCheckbox, _data.Resolve("Absent"), "");
        await _ui.ClickAsync(_locators.OK);
        // ClientAddAssociatedClient_cb1bd9Page.OrderAndVerifySSN_0058_f2d6bdAsync
        await _ui.ClickAsync(_locators.OrderSSN5E031);
        await _ui.PressAsync(_locators.EnterSSNFA186, "PRE:TAB");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Enter");
        await _ui.FillAsync(_locators.EnterSSNFA186, _data.Resolve("{{data:enter_ssn_60}}"));
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.PressAsync(_locators.EnterSSNFA186, "Tab");
        await _ui.ClickAsync(_locators.EnterSSNFA186);
        // ClientAddAssociatedClient_cb1bd9Page.DoesVerifyExist_0059_f2d6bdAsync
        await _ui.VerifyAsync(_locators.Verify7A388, _data.Resolve("Absent"), "");
        // ClientAddAssociatedClient_cb1bd9Page.ClickComplete_0060_f2d6bdAsync
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.ClickDetailAndVerifySSN_0061_f2d6bdAsync
        await _ui.ClickAsync(_locators.Detail6D228);
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientAddAssociatedClient_cb1bd9Page.VerifySSN_0062_f2d6bdAsync
        await _ui.WaitAsync(_locators.EnterSSNFA186, "Exists");
        await _ui.ClickAsync(_locators.Verify7A388);
        await _ui.WaitAsync(_locators.PleaseVerifySSNF738A, "Absent");
        await _ui.ClickAsync(_locators.Complete);
        // ClientSearchResults_88c18bPage.PerformFinalClientSearch_0063_f2d6bdAsync
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Exists");
        await _ui.ClickAsync(_locators.ClientSearchFDC36);
        // ClientSearchResults_88c18bPage.ClickOk_0064_f2d6bdAsync
        await _ui.WaitAsync(_locators.OK, "Exists");
        await _ui.ClickAsync(_locators.OK);
        await _ui.WaitAsync(_locators.ClientSearchFDC36, "Absent");
    }

}
