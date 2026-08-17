using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class BillingPage
{
    private readonly BillingLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public BillingPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new BillingLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete billing Account Setup
    public async Task CompleteBillingAccountSetupAsync()
    {
        // CLEQCommonBillingBillingAccountSetup_b58a65Page.EQCommonBilling_0291_d18a3eAsync
        await _ui.WaitAsync(_locators.BillingInformationHeading, "Exists");
        await _ui.ClickAsync(_locators.CreateNewBillingAccount);
        // CLEQCommonBillingBillingAccountSetupCLEQCommonWaitOnLoadingIndicator_9e4805Page.EQLoadingIndicatorWait_0292_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonBillingBillingAccountSetup_b58a65Page.EQCommonBillingEnterOtherInfo_0293_d18a3eAsync
        await _ui.WaitAsync(_locators.BillingInformationHeading, "Exists");
        await _ui.ClickAsync(_locators.OTHERButton);
        await _ui.PressAsync(_locators.FirstName, "POST:ENTER");
        await _ui.PressAsync(_locators.FirstName, "Enter");
        await _ui.PressAsync(_locators.FirstName, "Tab");
        await _ui.PressAsync(_locators.LastName, "POST:ENTER");
        await _ui.PressAsync(_locators.LastName, "Enter");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.PressAsync(_locators.BusinessName, "POST:ENTER");
        await _ui.PressAsync(_locators.BusinessName, "Enter");
        await _ui.PressAsync(_locators.BusinessName, "Tab");
        await _ui.PressAsync(_locators.Address1, "POST:ENTER");
        await _ui.PressAsync(_locators.Address1, "Enter");
        await _ui.PressAsync(_locators.Address1, "Tab");
        await _ui.PressAsync(_locators.City, "POST:ENTER");
        await _ui.PressAsync(_locators.City, "Enter");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.PressAsync(_locators.State, "POST:ENTER");
        await _ui.PressAsync(_locators.State, "Enter");
        await _ui.PressAsync(_locators.State, "Tab");
        await _ui.PressAsync(_locators.ZipCode, "POST:ENTER");
        await _ui.PressAsync(_locators.ZipCode, "Enter");
        await _ui.PressAsync(_locators.ZipCode, "Tab");
        // CLEQCommonBillingFuturePaymentPlan1_6951eaPage.EQLoadingIndicatorWait_0294_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I complete future Payment Plan 1
    public async Task CompleteFuturePaymentPlan1Async()
    {
        // CLEQCommonBillingFuturePaymentPlan1_6951eaPage.EQCommonPBillingSelectDirectBillAndPaymentPlan_0295_d18a3eAsync
        await _ui.PressAsync(_locators.DirectBillButton, "POST:TAB");
        await _ui.PressAsync(_locators.DirectBillButton, "Tab");
        await _ui.PressAsync(_locators.N1PaymentButton, "POST:TAB");
        await _ui.PressAsync(_locators.N1PaymentButton, "Tab");
        // CLEQCommonBillingFuturePaymentPlan1_6951eaPage.WaitOnScreenToUpdate_0296_d18a3eAsync
        await Task.Delay(1000);
        // CLEQCommonBillingFuturePaymentPlan1_6951eaPage.EQCommonBillingSelectPaymentDueDate_0297_d18a3eAsync
        await _ui.PressAsync(_locators.ChoosePaymentDueDate, "POST:ENTER");
        await _ui.PressAsync(_locators.ChoosePaymentDueDate, "Enter");
        await _ui.PressAsync(_locators.ChoosePaymentDueDate, "Tab");
        // CLEQCommonBillingFuturePaymentPlan1_6951eaPage.EQLoadingIndicatorWait_0298_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I complete initial Payment
    public async Task CompleteInitialPaymentAsync()
    {
        // CLEQCommonBillingInitialPayment_1b850ePage.EQCommonBillingSelectInitialPaymentMethod_0299_d18a3eAsync
        if (_data.Condition("'Payment Type' ==\"Check\""))
        {
        await _ui.PressAsync(_locators.CheckButton, "POST:TAB");
        await _ui.PressAsync(_locators.CheckButton, "Tab");
        }
        if (_data.Condition("'Payment Type' ==\"Credit Card\""))
        {
        await _ui.PressAsync(_locators.CreditCardButton, "POST:TAB");
        await _ui.PressAsync(_locators.CreditCardButton, "Tab");
        }
        // CLEQCommonBillingInitialPayment_1b850ePage.EQCommonLoadingIndicatorWait_0300_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonBillingInitialPayment_1b850ePage.EQCommonBillingFillInCheckNumber_0301_d18a3eAsync
        if (_data.Condition("'Payment Type' == \"Check\""))
        {
        await _ui.VerifyAsync(_locators.CheckNumber, _data.Resolve("Absent"), "");
        }
        // CLEQCommonBillingInitialPayment_1b850ePage.EQCommonBillingSelectInitialPaymentMethod_0302_d18a3eAsync
        if (_data.Condition("'Payment Type' == \"Check\""))
        {
        await _ui.PressAsync(_locators.CheckButton, "POST:TAB");
        await _ui.PressAsync(_locators.CheckButton, "Tab");
        }
        if (_data.Condition("'Payment Type' == \"Check\""))
        {
        await _ui.PressAsync(_locators.CreditCardButton, "POST:TAB");
        await _ui.PressAsync(_locators.CreditCardButton, "Tab");
        }
        // CLEQCommonBillingInitialPayment_1b850ePage.EQCommonLoadingIndicatorWait_0303_d18a3eAsync
        if (_data.Condition("'Payment Type' == \"Check\""))
        {
        await _ui.WaitAsync(_locators.Loading, "Absent");
        }
        // CLEQCommonBillingInitialPayment_1b850ePage.EQCommonBillingFillInCheckNumber_0304_d18a3eAsync
        if (_data.Condition("'Payment Type' == \"Check\""))
        {
        await _ui.WaitAsync(_locators.CheckNumber, "Exists");
        }
        // CLEQCommonBillingInitialPayment_1b850ePage.EQCommonBillingFillInCheckNumber_0305_d18a3eAsync
        if (_data.Condition("'Payment Type' == \"Check\""))
        {
        await _ui.PressAsync(_locators.CheckNumber, "POST:ENTER");
        await _ui.PressAsync(_locators.CheckNumber, "Enter");
        await _ui.PressAsync(_locators.CheckNumber, "Tab");
        }
        // CLEQCommonBillingInitialPayment_1b850ePage.EQCommonLoadingIndicatorWait_0306_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQCommonBillingInitialPayment_1b850ePage.EQCommonBillingSelectInitialPaymentAmount_0307_d18a3eAsync
        await _ui.ClickAsync(_locators.InitialPaymentFullBalance);
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0308_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_10}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0309_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I refer Application/Policy for table row cell link
    public async Task ReferApplicationPolicyForTableRowCellLinkAsync()
    {
        // DCEQCommonSubmissionReferApplicationPolicy_13acc3Page.OpenTheReferredPolicy_0755_d18a3eAsync
        await _ui.VerifyAsync(_locators.TableRowCellLink, _data.Resolve("Exists"), "");
        // DCEQCommonSubmissionReferApplicationPolicy_13acc3Page.WaitForBillingLinkToAppear_0756_d18a3eAsync
        await _ui.WaitAsync(_locators.Billing, "Exists");
    }

}