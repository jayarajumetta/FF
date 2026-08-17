using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class PolicyWorkflowPage
{
    private readonly PolicyWorkflowLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public PolicyWorkflowPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new PolicyWorkflowLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I add a new Associated Client \- Business Owner Type \- Click Add Client
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync()
    {
        // ClientAddAssociatedClient_cb1bd9Page.AddANewAssociatedClientBusinessOwnerTypeClickAddClient_0048_f7819aAsync
        await _ui.WaitAsync(_locators.AddClient, "Exists");
        await _ui.PressAsync(_locators.AddClient, "PRE:TAB");
        await _ui.PressAsync(_locators.AddClient, "Tab");
        await _ui.ClickAsync(_locators.AddClient);
        // ClientAddAssociatedClient_cb1bd9Page.CheckIfIndividualTypeExists_0049_f7819aAsync
        await _ui.VerifyAsync(_locators.IndividualType, _data.Resolve("Absent"), "");
    }

    // Business step: I complete aJAX Error Check
    public async Task CompleteAJAXErrorCheckAsync()
    {
        // AJAXError_19aa70Page.AJAXErrorCheck_0050_f7819aAsync
        await _ui.VerifyAsync(_locators.AJAXErrorCheck, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetBufferForError_0051_f7819aAsync
        _data.Set("AJAX Error", _data.Resolve("The scripts experienced an AJAX error with the following information: {B[AJAX]}"));
        // TBoxEvaluationTool_b95b5cPage.ForceAFail_0052_f7819aAsync
        _data.Set("ForceAFail", _data.Resolve("'FALSE' == 'TRUE'"));
    }

    // Business step: I add Commercial Auto Underlying LOB
    public async Task AddCommercialAutoUnderlyingLOBAsync()
    {
        // PolicyCovg_0dff37Page.SelectCommercialAutoUnderlyingLOB_0091_f7819aAsync
        await _ui.ClickAsync(_locators.IncludeCommercialAuto);
        // UMBNavigationLinks_77d89fPage.WaitForCommercialAutoTabToAppear_0092_f7819aAsync
        await _ui.WaitAsync(_locators.CommercialAuto, "Visible");
    }

    // Business step: I add General Liability Underlying LOB
    public async Task AddGeneralLiabilityUnderlyingLOBAsync()
    {
        // PolicyCovg_0dff37Page.SelectGeneralLiabilityUnderlyingLOB_0093_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludeGeneralLiability);
        // UMBNavigationLinks_77d89fPage.WaitForGeneralLiabilityTabToAppear_0094_f7819aAsync
        await _ui.WaitAsync(_locators.GeneralLiab, "Visible");
    }

    // Business step: I add Businessowners Underlying LOB
    public async Task AddBusinessownersUnderlyingLOBAsync()
    {
        // PolicyCovg_0dff37Page.SelectGeneralLiabilityUnderlyingLOB_0095_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludeBusinessowners);
        // UMBNavigationLinks_77d89fPage.WaitForBusinessownersTabToAppear_0096_f7819aAsync
        await _ui.WaitAsync(_locators.Businessowners, "Visible");
    }

    // Business step: I add SFP \- 10 Liability Farm Underlying LOB
    public async Task AddSFP10LiabilityFarmUnderlyingLOBAsync()
    {
        // PolicyCovg_0dff37Page.SelectSFP10UnderlyingLOB_0097_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludeSFP10LiabilityFarm);
        // UMBNavigationLinks_77d89fPage.WaitForSFP10LiabilityFarmTabToAppear_0098_f7819aAsync
        await _ui.WaitAsync(_locators.SFP10LiabilityFarm, "Visible");
    }

    // Business step: I add Commercial Package Policy Liability Underlying LOB
    public async Task AddCommercialPackagePolicyLiabilityUnderlyingLOBAsync()
    {
        // PolicyCovg_0dff37Page.SelectCommercialPackagePolicyLiabilityUnderlyingLOB_0099_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludeCommercialPackagePolicyLiability);
        // UMBNavigationLinks_77d89fPage.WaitForCommercialPackagePolicyLiabilityTabToAppear_0100_f7819aAsync
        await _ui.WaitAsync(_locators.CPPLiability, "Visible");
    }

    // Business step: I add Employers Liability Underlying LOB
    public async Task AddEmployersLiabilityUnderlyingLOBAsync()
    {
        // PolicyCovg_0dff37Page.SelectEmployersLiabilityUnderlyingLOB_0101_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludeEmployersLiability);
        // UMBNavigationLinks_77d89fPage.WaitForEmployersLiabilityTabToAppear_0102_f7819aAsync
        await _ui.WaitAsync(_locators.EmployersLiab, "Visible");
    }

    // Business step: I add Homeowner's Liability Underlying LOB
    public async Task AddHomeownerSLiabilityUnderlyingLOBAsync()
    {
        // PolicyCovg_0dff37Page.SelectHomeownerSLiabilityUnderlyingLOB_0103_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludeHomeownerSLiability);
        // UMBNavigationLinks_77d89fPage.WaitForHomeownerSLiabilityTabToAppear_0104_f7819aAsync
        await _ui.WaitAsync(_locators.HomeownerSLiability, "Visible");
    }

    // Business step: I add Personal Auto Liability Underlying LOB
    public async Task AddPersonalAutoLiabilityUnderlyingLOBAsync()
    {
        // PolicyCovg_0dff37Page.SelectPersonalAutoLiabilityUnderlyingLOB_0107_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludePersonalAutoLiability);
        // UMBNavigationLinks_77d89fPage.WaitForPersonalAutoLiabilityTabToAppear_0108_f7819aAsync
        await _ui.WaitAsync(_locators.PersonalAuto, "Visible");
    }

    // Business step: I add Rental Owner's Liability Underlying LOB
    public async Task AddRentalOwnerSLiabilityUnderlyingLOBAsync()
    {
        // PolicyCovg_0dff37Page.SelectRentalOwnerSLiabilityUnderlyingLOB_0111_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludeRentalOwnerSLiability);
        // UMBNavigationLinks_77d89fPage.WaitForRentalOwnerSLiabilityTabToAppear_0112_f7819aAsync
        await _ui.WaitAsync(_locators.RentalOwnersLiability, "Visible");
    }

    // Business step: I add Watercraft Liability Underlying LOB
    public async Task AddWatercraftLiabilityUnderlyingLOBAsync()
    {
        // PolicyCovg_0dff37Page.SelectWatercraftLiabilityUnderlyingLOB_0113_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludeWatercraftLiability);
        // UMBNavigationLinks_77d89fPage.WaitForWatercraftLiabilityTabToAppear_0114_f7819aAsync
        await _ui.WaitAsync(_locators.WatercraftLiability, "Visible");
    }

    // Business step: I complete fill in CU2103 if it exists
    public async Task CompleteFillInCU2103IfItExistsAsync()
    {
        // UnresolvedModule_b8894dPage.CU2103DetailButton_1054_f7819aAsync
        await _ui.VerifyAsync(_locators.Value, _data.Resolve("Exists"), "");
        // UnresolvedModule_b8894dPage.CU2103DetailButton_1055_f7819aAsync
        await _ui.ClickAsync(_locators.Value);
        // CU2103ExclusionDesignatedWork_cce866Page.CU2103ExclusionDesignatedWorkSelectCheckboxAndDescription_1056_f7819aAsync
        await _ui.WaitAsync(_locators.EndorsementHeading, "Equal");
        await _ui.ClickAsync(_locators.IFRAMEDuckCreekPolicyOtherCheckBox);
        await _ui.FillAsync(_locators.IFRAMEDuckCreekPolicyDescriptionOfOther, _data.Resolve("{{data:iframe_duck_creek_policy_description_of_other_517}}"));
        await _ui.ClickAsync(_locators.OK);
        await _ui.PressAsync(_locators.OK, "CLICK");
        await _ui.PressAsync(_locators.OK, "Tab");
        await _ui.PressAsync(_locators.OK, "Tab");
        await _ui.PressAsync(_locators.OK, "Tab");
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_1057_f7819aAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_1058_f7819aAsync
        await Task.Delay(1000);
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync()
    {
        // Logout_e43d61Page.Logout_1232_f7819aAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_1233_f7819aAsync
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_1234_f7819aAsync
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_1235_f7819aAsync
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_1236_f7819aAsync
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_1237_f7819aAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync2()
    {
        // Logout_e43d61Page.Logout_0275_515771Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0276_515771Async
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0277_515771Async
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0278_515771Async
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0279_515771Async
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0280_515771Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync3()
    {
        // Logout_e43d61Page.Logout_0275_d65717Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0276_d65717Async
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0277_d65717Async
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0278_d65717Async
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0279_d65717Async
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0280_d65717Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I complete restart Edge Popup
    public async Task CompleteRestartEdgePopupAsync()
    {
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageExists_0044_d344b2Async
        await _ui.VerifyAsync(_locators.RestartMicrosoftEdgeMessageOK, _data.Resolve("Exists"), "");
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageClickOK_0045_d344b2Async
        await _ui.ClickAsync(_locators.RestartMicrosoftEdgeMessageOK);
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync4()
    {
        // Logout_e43d61Page.Logout_0048_d344b2Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0049_d344b2Async
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0050_d344b2Async
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0051_d344b2Async
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0052_d344b2Async
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0053_d344b2Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I sign out of the application for logged in user
    public async Task SignOutOfTheApplicationForLoggedInUserAsync()
    {
        // Logout_e43d61Page.Logout_0132_d344b2Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0133_d344b2Async
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0134_d344b2Async
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0135_d344b2Async
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0136_d344b2Async
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0137_d344b2Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I complete restart Edge Popup
    public async Task CompleteRestartEdgePopupAsync2()
    {
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageExists_0044_a1ba9cAsync
        await _ui.VerifyAsync(_locators.RestartMicrosoftEdgeMessageOK, _data.Resolve("Exists"), "");
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageClickOK_0045_a1ba9cAsync
        await _ui.ClickAsync(_locators.RestartMicrosoftEdgeMessageOK);
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync5()
    {
        // Logout_e43d61Page.Logout_0048_a1ba9cAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0049_a1ba9cAsync
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0050_a1ba9cAsync
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0051_a1ba9cAsync
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0052_a1ba9cAsync
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0053_a1ba9cAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I sign out of the application for logged in user
    public async Task SignOutOfTheApplicationForLoggedInUserAsync2()
    {
        // Logout_e43d61Page.Logout_0149_a1ba9cAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0150_a1ba9cAsync
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0151_a1ba9cAsync
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0152_a1ba9cAsync
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0153_a1ba9cAsync
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0154_a1ba9cAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I complete restart Edge Popup
    public async Task CompleteRestartEdgePopupAsync3()
    {
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageExists_0044_85cb3fAsync
        await _ui.VerifyAsync(_locators.RestartMicrosoftEdgeMessageOK, _data.Resolve("Exists"), "");
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageClickOK_0045_85cb3fAsync
        await _ui.ClickAsync(_locators.RestartMicrosoftEdgeMessageOK);
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync6()
    {
        // Logout_e43d61Page.Logout_0048_85cb3fAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0049_85cb3fAsync
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0050_85cb3fAsync
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0051_85cb3fAsync
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0052_85cb3fAsync
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0053_85cb3fAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I sign out of the application for logged in user
    public async Task SignOutOfTheApplicationForLoggedInUserAsync3()
    {
        // Logout_e43d61Page.Logout_0128_85cb3fAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0129_85cb3fAsync
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0130_85cb3fAsync
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0131_85cb3fAsync
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0132_85cb3fAsync
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0133_85cb3fAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I complete restart Edge Popup
    public async Task CompleteRestartEdgePopupAsync4()
    {
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageExists_0044_c839dfAsync
        await _ui.VerifyAsync(_locators.RestartMicrosoftEdgeMessageOK, _data.Resolve("Exists"), "");
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageClickOK_0045_c839dfAsync
        await _ui.ClickAsync(_locators.RestartMicrosoftEdgeMessageOK);
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync7()
    {
        // Logout_e43d61Page.Logout_0048_c839dfAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0049_c839dfAsync
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0050_c839dfAsync
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0051_c839dfAsync
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0052_c839dfAsync
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0053_c839dfAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I add a new Associated Client \- Business Owner Type \- Click Add Client
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync2()
    {
        // ClientAddAssociatedClient_cb1bd9Page.AddANewAssociatedClientBusinessOwnerTypeClickAddClient_0089_c839dfAsync
        await _ui.WaitAsync(_locators.AddClient, "Exists");
        await _ui.PressAsync(_locators.AddClient, "PRE:TAB");
        await _ui.PressAsync(_locators.AddClient, "Tab");
        await _ui.ClickAsync(_locators.AddClient);
        // ClientAddAssociatedClient_cb1bd9Page.CheckIfIndividualTypeExists_0090_c839dfAsync
        await _ui.VerifyAsync(_locators.IndividualType, _data.Resolve("Absent"), "");
    }

    // Business step: I complete aJAX Error Check
    public async Task CompleteAJAXErrorCheckAsync2()
    {
        // AJAXError_19aa70Page.AJAXErrorCheck_0091_c839dfAsync
        await _ui.VerifyAsync(_locators.AJAXErrorCheck, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetBufferForError_0092_c839dfAsync
        _data.Set("AJAX Error", _data.Resolve("The scripts experienced an AJAX error with the following information: {B[AJAX]}"));
        // TBoxEvaluationTool_b95b5cPage.ForceAFail_0093_c839dfAsync
        _data.Set("ForceAFail", _data.Resolve("'FALSE' == 'TRUE'"));
    }

    // Business step: I complete WC Specific Fields
    public async Task CompleteWCSpecificFieldsAsync()
    {
        // PolicyInfoWCSpecificFields_35da7aPage.PolicyInfoWCSpecificFields_0121_c839dfAsync
        await _ui.FillAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, _data.Resolve("{{data:has_the_applicant_been_in_business_for_at_least_3_years_with_continuous_workers_compensation_coverage_150}}"));
        await _ui.PressAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, "CLICK");
        await _ui.PressAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, "Enter");
        await _ui.PressAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, "Tab");
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.DESCRIPTIONBUFFER_0122_c839dfAsync
        await _ui.WaitAsync(_locators.PolicyInfoHeader, "Visible");
        await _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, "Visible");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "PRE:TAB");
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("AL WC Basic {NMONTH}.{NDAY}.{NYEAR} {Time}"));
        await _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, "Tab");
        await _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, _data.Resolve("{XB[QuoteDescription]}"), "value");
    }

    // Business step: I sign out of the application for logged in user
    public async Task SignOutOfTheApplicationForLoggedInUserAsync4()
    {
        // Logout_e43d61Page.Logout_0160_c839dfAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0161_c839dfAsync
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0162_c839dfAsync
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0163_c839dfAsync
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0164_c839dfAsync
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0165_c839dfAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I add a new Associated Client \- Business Owner Type \- Click Add Client
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync3()
    {
        // ClientAddAssociatedClient_cb1bd9Page.AddANewAssociatedClientBusinessOwnerTypeClickAddClient_0048_aad19bAsync
        await _ui.WaitAsync(_locators.AddClient, "Exists");
        await _ui.PressAsync(_locators.AddClient, "PRE:TAB");
        await _ui.PressAsync(_locators.AddClient, "Tab");
        await _ui.ClickAsync(_locators.AddClient);
        // ClientAddAssociatedClient_cb1bd9Page.CheckIfIndividualTypeExists_0049_aad19bAsync
        await _ui.VerifyAsync(_locators.IndividualType, _data.Resolve("Absent"), "");
    }

    // Business step: I complete aJAX Error Check
    public async Task CompleteAJAXErrorCheckAsync3()
    {
        // AJAXError_19aa70Page.AJAXErrorCheck_0050_aad19bAsync
        await _ui.VerifyAsync(_locators.AJAXErrorCheck, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetBufferForError_0051_aad19bAsync
        _data.Set("AJAX Error", _data.Resolve("The scripts experienced an AJAX error with the following information: {B[AJAX]}"));
        // TBoxEvaluationTool_b95b5cPage.ForceAFail_0052_aad19bAsync
        _data.Set("ForceAFail", _data.Resolve("'FALSE' == 'TRUE'"));
    }

    // Business step: I select CP Detail
    public async Task SelectCPDetailAsync()
    {
        // PolicyInfoCPPSpecificFields_d2689aPage.PolicyInfoCPPSpecificFields_0099_aad19bAsync
        if (_data.Condition("'CPP LOB' == \"CP\""))
        {
        await _ui.ClickAsync(_locators.CPDetail);
        }
    }

    // Business step: I complete CP Fields
    public async Task CompleteCPFieldsAsync()
    {
        // PolicyCovg_0dff37Page.AnswerCPPolicyCovgPrivateWindmillsQuestion_0101_aad19bAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Exists");
        await _ui.FillAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, _data.Resolve("{{data:does_any_risk_generate_power_other_than_private_windmills_or_emergency_backup_129}}"));
        await _ui.PressAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, "CLICK");
        await _ui.PressAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, "Enter");
        await _ui.PressAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, "Tab");
    }

    // Business step: I complete mask Error Recovery
    public async Task CompleteMaskErrorRecoveryAsync()
    {
        // TaskbarStartButton_d5f6cePage.TaskbarStartButtonClickOnce_0102_aad19bAsync
        await _ui.ClickAsync(_locators.Start);
        // TaskbarStartButton_d5f6cePage.TaskbarStartButtonClickOnce_0103_aad19bAsync
        await _ui.ClickAsync(_locators.Start);
    }

    // Business step: I complete ensure Property of Others Rating Group has been entered
    public async Task CompleteEnsurePropertyOfOthersRatingGroupHasBeenEnteredAsync()
    {
        // PropertyAddClass_ed4d5dPage.PropertyAddClass_0137_aad19bAsync
        await _ui.VerifyAsync(_locators.PropertyOfOthersRatingGroup, _data.Resolve("{{data:expected_property_of_others_rating_group_value_228}}"), "NotEqual:Value");
        // PropertyAddClass_ed4d5dPage.PropertyAddClass_0138_aad19bAsync
        await _ui.VerifyAsync(_locators.PropertyOfOthersRatingGroup, _data.Resolve("{{data:expected_property_of_others_rating_group_value_229}}"), "NotEqual:Value");
        // PropertyAddClass_ed4d5dPage.PropertyAddClass_0139_aad19bAsync
        await _ui.FillAsync(_locators.PropertyOfOthersRatingGroup, _data.Resolve("{{data:property_of_others_rating_group_230}}"));
        await _ui.PressAsync(_locators.PropertyOfOthersRatingGroup, "Tab");
        await _ui.PressAsync(_locators.PropertyOfOthersRatingGroup, "Tab");
    }

    // Business step: I return to CPP Navigation
    public async Task ReturnToCPPNavigationAsync()
    {
        // CommonNavigationLinks_dba56bPage.CommonNavigationLinks_0146_aad19bAsync
        await _ui.ClickAsync(_locators.ReturnToCPP);
    }

    // Business step: I complete CGL Fields
    public async Task CompleteCGLFieldsAsync()
    {
        // PolicyCovgGL_e538c3Page.PolicyCovgGL_0150_aad19bAsync
        await _ui.WaitAsync(_locators.PolicyCovg6B651, "Exists");
        if (_data.Condition("'Occurence Limit' != NULL"))
        {
        await _ui.FillAsync(_locators.OccurenceLimit, _data.Resolve("{{data:occurence_limit_259}}"));
        await _ui.PressAsync(_locators.OccurenceLimit, "CLICK");
        await _ui.PressAsync(_locators.OccurenceLimit, "Enter");
        await _ui.PressAsync(_locators.OccurenceLimit, "Tab");
        }
        if (_data.Condition("'Aggregate Limit' != NULL"))
        {
        await _ui.FillAsync(_locators.AggregateLimit, _data.Resolve("{{data:aggregate_limit_260}}"));
        await _ui.PressAsync(_locators.AggregateLimit, "CLICK");
        await _ui.PressAsync(_locators.AggregateLimit, "Enter");
        await _ui.PressAsync(_locators.AggregateLimit, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.ProductsAggLimit, _data.Resolve(""));
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.DedType, _data.Resolve("{{data:ded_type_262}}"));
        await _ui.PressAsync(_locators.DedType, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.DeductibleBasis, _data.Resolve("{{data:deductible_basis_263}}"));
        await _ui.PressAsync(_locators.DeductibleBasis, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.PremOpDed, _data.Resolve("{{data:premop_ded_264}}"));
        await _ui.PressAsync(_locators.PremOpDed, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.PremOpPDDed, _data.Resolve(""));
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
        await _ui.SmartSetAsync(_locators.SplitBIDed, _data.Resolve("{{data:split_bi_ded_266}}"));
        await _ui.PressAsync(_locators.SplitBIDed, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.SplitPDDed, _data.Resolve(""));
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.ProdBIDed, _data.Resolve("{{data:prod_bi_ded_268}}"));
        await _ui.PressAsync(_locators.ProdBIDed, "CLICK");
        await _ui.PressAsync(_locators.ProdBIDed, "Tab");
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.ProdPDDed, _data.Resolve(""));
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.FireDamage, _data.Resolve(""));
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.Medical, _data.Resolve(""));
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.PersAdvInj, _data.Resolve(""));
        }
        if (_data.Condition("'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, _data.Resolve("{{data:is_the_insured_engaged_in_any_snow_or_ice_removal_operations_273}}"));
        await _ui.PressAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, "CLICK");
        await _ui.PressAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, "Enter");
        await _ui.PressAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, "Tab");
        }
        if (_data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.OfFullTimeEmployees, _data.Resolve("{{data:of_full_time_employees_274}}"));
        await _ui.PressAsync(_locators.OfFullTimeEmployees, "Tab");
        }
        if (_data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\") ||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.OfPartTimeEmployees, _data.Resolve("{{data:of_part_time_employees_275}}"));
        await _ui.PressAsync(_locators.OfPartTimeEmployees, "Tab");
        }
        if (_data.Condition("(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\") ||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\""))
        {
        await _ui.FillAsync(_locators.OfSeasonalTemporaryEmployees, _data.Resolve("{{data:of_seasonal_temporary_employees_276}}"));
        await _ui.PressAsync(_locators.OfSeasonalTemporaryEmployees, "Tab");
        }
    }

    // Business step: I return to CPP Navigation for return to cpp
    public async Task ReturnToCPPNavigationForReturnToCppAsync()
    {
        // CommonNavigationLinks_dba56bPage.CommonNavigationLinks_0186_aad19bAsync
        await _ui.ClickAsync(_locators.ReturnToCPP);
    }

    // Business step: I select IM Detail
    public async Task SelectIMDetailAsync()
    {
        // PolicyInfoCPPSpecificFields_d2689aPage.PolicyInfoCPPSpecificFields_0187_aad19bAsync
        if (_data.Condition("'CPP LOB' == \"IM\""))
        {
        await _ui.ClickAsync(_locators.IMDetail);
        }
    }

    // Business step: I complete if search result Alert exists
    public async Task CompleteIfSearchResultAlertExistsAsync()
    {
        // DuckCreekPolicy_59f415Page.IfSearchResultAlertExists_0212_aad19bAsync
        await _ui.VerifyAsync(_locators.ShowMe, _data.Resolve("Exists"), "");
        // DuckCreekPolicy_59f415Page.SelectShowMeButton_0213_aad19bAsync
        await _ui.ClickAsync(_locators.ShowMe);
    }

    // Business step: I complete ensure Class has been entered for Accounts Receivable
    public async Task CompleteEnsureClassHasBeenEnteredForAccountsReceivableAsync()
    {
        // RiskAccountsReceivable_1ef8eePage.RiskAccountsReceivable_0214_aad19bAsync
        await _ui.VerifyAsync(_locators.SearchResultEAFB8, _data.Resolve("{{data:expected_search_result_value_452}}"), "Value");
        // RiskAccountsReceivable_1ef8eePage.RiskAccountsReceivable_0215_aad19bAsync
        await _ui.VerifyAsync(_locators.SearchResultEAFB8, _data.Resolve("{{data:expected_search_result_value_453}}"), "Value");
        // RiskAccountsReceivable_1ef8eePage.RiskAccountsReceivable_0216_aad19bAsync
        await _ui.WaitAsync(_locators.AccountsReceivableHeading, "Exists");
        await _ui.FillAsync(_locators.SearchValue79E46, _data.Resolve("{{data:search_value_455}}"));
        await _ui.PressAsync(_locators.SearchValue79E46, "Tab");
        await _ui.PressAsync(_locators.SearchValue79E46, "CLICK");
        await _ui.PressAsync(_locators.SearchValue79E46, "Tab");
        await _ui.FillAsync(_locators.SearchResultEAFB8, _data.Resolve("{{data:search_result_456}}"));
        await _ui.PressAsync(_locators.SearchResultEAFB8, "Tab");
        await _ui.PressAsync(_locators.SearchResultEAFB8, "CLICK");
        await _ui.PressAsync(_locators.SearchResultEAFB8, "Enter");
        await _ui.PressAsync(_locators.SearchResultEAFB8, "Tab");
        await _ui.ClickAsync(_locators.RiskAccountsReceivableOK);
    }

    // Business step: I complete if search result Alert exists for show me
    public async Task CompleteIfSearchResultAlertExistsForShowMeAsync()
    {
        // DuckCreekPolicy_59f415Page.IfSearchResultAlertExists_0220_aad19bAsync
        await _ui.VerifyAsync(_locators.ShowMe, _data.Resolve("Exists"), "");
        // DuckCreekPolicy_59f415Page.SelectShowMeButton_0221_aad19bAsync
        await _ui.ClickAsync(_locators.ShowMe);
    }

    // Business step: I complete ensure Class has been entered for Bailees Customers
    public async Task CompleteEnsureClassHasBeenEnteredForBaileesCustomersAsync()
    {
        // RiskBaileesCustomers_a875f1Page.RiskBaileesCustomers_0222_aad19bAsync
        await _ui.VerifyAsync(_locators.SearchResultA1BFB, _data.Resolve("{{data:expected_search_result_value_479}}"), "Value");
        // RiskBaileesCustomers_a875f1Page.RiskBaileesCustomers_0223_aad19bAsync
        await _ui.VerifyAsync(_locators.SearchResultA1BFB, _data.Resolve("{{data:expected_search_result_value_480}}"), "Value");
        // RiskBaileesCustomers_a875f1Page.RiskBaileesCustomers_0224_aad19bAsync
        await _ui.FillAsync(_locators.SearchValueCA6A6, _data.Resolve("{{data:search_value_481}}"));
        await _ui.PressAsync(_locators.SearchValueCA6A6, "Tab");
        await _ui.PressAsync(_locators.SearchValueCA6A6, "CLICK");
        await _ui.PressAsync(_locators.SearchValueCA6A6, "Tab");
        await _ui.FillAsync(_locators.SearchResultA1BFB, _data.Resolve("{{data:search_result_482}}"));
        await _ui.PressAsync(_locators.SearchResultA1BFB, "Tab");
        await _ui.PressAsync(_locators.SearchResultA1BFB, "CLICK");
        await _ui.PressAsync(_locators.SearchResultA1BFB, "Enter");
        await _ui.PressAsync(_locators.SearchResultA1BFB, "Tab");
        await _ui.ClickAsync(_locators.RiskBaileesCustomersOK);
    }

    // Business step: I complete if search result Alert exists for duck creek policy
    public async Task CompleteIfSearchResultAlertExistsForDuckCreekPolicyAsync()
    {
        // DuckCreekPolicy_59f415Page.IfSearchResultAlertExists_0228_aad19bAsync
        await _ui.VerifyAsync(_locators.ShowMe, _data.Resolve("Exists"), "");
        // DuckCreekPolicy_59f415Page.SelectShowMeButton_0229_aad19bAsync
        await _ui.ClickAsync(_locators.ShowMe);
    }

    // Business step: I complete ensure Class has been entered for Computer Systems
    public async Task CompleteEnsureClassHasBeenEnteredForComputerSystemsAsync()
    {
        // RiskComputerSystems_7b4caaPage.RiskComputerSystems_0230_aad19bAsync
        await _ui.VerifyAsync(_locators.SearchResult4E620, _data.Resolve("{{data:expected_search_result_value_497}}"), "Value");
        // RiskComputerSystems_7b4caaPage.RiskComputerSystems_0231_aad19bAsync
        await _ui.VerifyAsync(_locators.SearchResult4E620, _data.Resolve("{{data:expected_search_result_value_498}}"), "Value");
        // RiskComputerSystems_7b4caaPage.RiskComputerSystems_0232_aad19bAsync
        await _ui.FillAsync(_locators.SearchValue9FCD1, _data.Resolve("{{data:search_value_499}}"));
        await _ui.PressAsync(_locators.SearchValue9FCD1, "Tab");
        await _ui.PressAsync(_locators.SearchValue9FCD1, "CLICK");
        await _ui.PressAsync(_locators.SearchValue9FCD1, "Tab");
        await _ui.FillAsync(_locators.SearchResult4E620, _data.Resolve("{{data:search_result_500}}"));
        await _ui.PressAsync(_locators.SearchResult4E620, "Tab");
        await _ui.PressAsync(_locators.SearchResult4E620, "CLICK");
        await _ui.PressAsync(_locators.SearchResult4E620, "Enter");
        await _ui.PressAsync(_locators.SearchResult4E620, "Tab");
        await _ui.PressAsync(_locators.SearchResult4E620, "Tab");
        await _ui.ClickAsync(_locators.RiskComputerSystemsOK);
    }

    // Business step: I return to CPP policy navigation
    public async Task ReturnToCPPPolicyNavigationAsync()
    {
        // CommonNavigationLinks_dba56bPage.CommonNavigationLinks_0260_aad19bAsync
        await _ui.ClickAsync(_locators.ReturnToCPP);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0261_aad19bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0262_aad19bAsync
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.WaitForScreenToFullyRefresh_0263_aad19bAsync
        await Task.Delay(1000);
    }

    // Business step: I add a new Associated Client \- Business Owner Type \- Click Add Client
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync4()
    {
        // ClientAddAssociatedClient_cb1bd9Page.AddANewAssociatedClientBusinessOwnerTypeClickAddClient_0048_677267Async
        await _ui.WaitAsync(_locators.AddClient, "Exists");
        await _ui.PressAsync(_locators.AddClient, "PRE:TAB");
        await _ui.PressAsync(_locators.AddClient, "Tab");
        await _ui.ClickAsync(_locators.AddClient);
        // ClientAddAssociatedClient_cb1bd9Page.CheckIfIndividualTypeExists_0049_677267Async
        await _ui.VerifyAsync(_locators.IndividualType, _data.Resolve("Absent"), "");
    }

    // Business step: I complete aJAX Error Check
    public async Task CompleteAJAXErrorCheckAsync4()
    {
        // AJAXError_19aa70Page.AJAXErrorCheck_0050_677267Async
        await _ui.VerifyAsync(_locators.AJAXErrorCheck, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetBufferForError_0051_677267Async
        _data.Set("AJAX Error", _data.Resolve("The scripts experienced an AJAX error with the following information: {B[AJAX]}"));
        // TBoxEvaluationTool_b95b5cPage.ForceAFail_0052_677267Async
        _data.Set("ForceAFail", _data.Resolve("'FALSE' == 'TRUE'"));
    }

    // Business step: I complete mask Error Recovery
    public async Task CompleteMaskErrorRecoveryAsync2()
    {
        // TaskbarStartButton_d5f6cePage.TaskbarStartButtonClickOnce_0101_677267Async
        await _ui.ClickAsync(_locators.Start);
        // TaskbarStartButton_d5f6cePage.TaskbarStartButtonClickOnce_0102_677267Async
        await _ui.ClickAsync(_locators.Start);
    }

    // Business step: I complete restart Edge Popup
    public async Task CompleteRestartEdgePopupAsync5()
    {
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageExists_0163_677267Async
        await _ui.VerifyAsync(_locators.RestartMicrosoftEdgeMessageOK, _data.Resolve("Exists"), "");
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageClickOK_0164_677267Async
        await _ui.ClickAsync(_locators.RestartMicrosoftEdgeMessageOK);
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync8()
    {
        // Logout_e43d61Page.Logout_0167_677267Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0168_677267Async
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0169_677267Async
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0170_677267Async
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0171_677267Async
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0172_677267Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I search by Desc
    public async Task SearchByDescAsync()
    {
        // DashboardQuickSearch_8fcc82Page.EnterDescInQuickSearch_0180_677267Async
        await _ui.FillAsync(_locators.SearchText, _data.Resolve("{B[QuoteDescription]}"));
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.ClickAsync(_locators.QuickSearchButton);
        // DashboardSearchForPoliciesQuotes_824a16Page.EnterInfoToSearchByDesc_0181_677267Async
        await _ui.FillAsync(_locators.SearchMethodEGDescriptionPolicy, _data.Resolve("{{data:search_method_e_g_description_policy_333}}"));
        await _ui.PressAsync(_locators.SearchMethodEGDescriptionPolicy, "Tab");
        await _ui.ClickAsync(_locators.SearchButton);
        await _ui.WaitAsync(_locators.ViewPolicy, "Exists");
        await _ui.PressAsync(_locators.ViewPolicy, "PRE:TAB");
        await _ui.PressAsync(_locators.ViewPolicy, "Tab");
        await _ui.ClickAsync(_locators.ViewPolicy);
    }

    // Business step: I complete cT StraightThrough Liability Limit to 1M
    public async Task CompleteCTStraightThroughLiabilityLimitTo1MAsync()
    {
        // PolicyCoverageLimits_bce0bdPage.CTStraightThroughLiabilityLimitTo1M_0120_a6f47eAsync
        await _ui.VerifyAsync(_locators.CTStraightThroughLiabilityLimitTo1M, _data.Resolve("Exists"), "");
    }

    // Business step: I complete save for Later/Return to Admin
    public async Task CompleteSaveForLaterReturnToAdminAsync()
    {
        // CommonNavigationLinks_dba56bPage.CheckForSaveForLaterButton_0664_a6f47eAsync
        await _ui.VerifyAsync(_locators.SaveForLater, _data.Resolve("Exists"), "");
        // CommonNavigationLinks_dba56bPage.SaveForLater_0665_a6f47eAsync
        await _ui.ClickAsync(_locators.SaveForLater);
        await _ui.WaitAsync(_locators.SaveForLaterOK, "Exists");
        await _ui.ClickAsync(_locators.SaveForLaterOK);
        // CommonNavigationLinks_dba56bPage.CheckForReturnToAdminButton_0666_a6f47eAsync
        await _ui.VerifyAsync(_locators.ReturnToAdmin, _data.Resolve("Exists"), "");
        // CommonNavigationLinks_dba56bPage.ReturnToAdmin_0667_a6f47eAsync
        await _ui.ClickAsync(_locators.ReturnToAdmin);
        await _ui.WaitAsync(_locators.ReturnToAdmin, "Absent");
    }

    // Business step: I add a new Associated Client \- Business Owner Type \- Click Add Client
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync5()
    {
        // ClientAddAssociatedClient_cb1bd9Page.AddANewAssociatedClientBusinessOwnerTypeClickAddClient_0048_767d1bAsync
        await _ui.WaitAsync(_locators.AddClient, "Exists");
        await _ui.PressAsync(_locators.AddClient, "PRE:TAB");
        await _ui.PressAsync(_locators.AddClient, "Tab");
        await _ui.ClickAsync(_locators.AddClient);
        // ClientAddAssociatedClient_cb1bd9Page.CheckIfIndividualTypeExists_0049_767d1bAsync
        await _ui.VerifyAsync(_locators.IndividualType, _data.Resolve("Absent"), "");
    }

    // Business step: I complete aJAX Error Check
    public async Task CompleteAJAXErrorCheckAsync5()
    {
        // AJAXError_19aa70Page.AJAXErrorCheck_0050_767d1bAsync
        await _ui.VerifyAsync(_locators.AJAXErrorCheck, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetBufferForError_0051_767d1bAsync
        _data.Set("AJAX Error", _data.Resolve("The scripts experienced an AJAX error with the following information: {B[AJAX]}"));
        // TBoxEvaluationTool_b95b5cPage.ForceAFail_0052_767d1bAsync
        _data.Set("ForceAFail", _data.Resolve("'FALSE' == 'TRUE'"));
    }

    // Business step: I add Commercial Auto Underlying LOB
    public async Task AddCommercialAutoUnderlyingLOBAsync2()
    {
        // PolicyCovg_0dff37Page.SelectCommercialAutoUnderlyingLOB_0091_767d1bAsync
        await _ui.ClickAsync(_locators.IncludeCommercialAuto);
        // UMBNavigationLinks_77d89fPage.WaitForCommercialAutoTabToAppear_0092_767d1bAsync
        await _ui.WaitAsync(_locators.CommercialAuto, "Visible");
    }

    // Business step: I add General Liability Underlying LOB
    public async Task AddGeneralLiabilityUnderlyingLOBAsync2()
    {
        // PolicyCovg_0dff37Page.SelectGeneralLiabilityUnderlyingLOB_0093_767d1bAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludeGeneralLiability);
        // UMBNavigationLinks_77d89fPage.WaitForGeneralLiabilityTabToAppear_0094_767d1bAsync
        await _ui.WaitAsync(_locators.GeneralLiab, "Visible");
    }

    // Business step: I add Businessowners Underlying LOB
    public async Task AddBusinessownersUnderlyingLOBAsync2()
    {
        // PolicyCovg_0dff37Page.SelectGeneralLiabilityUnderlyingLOB_0095_767d1bAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludeBusinessowners);
        // UMBNavigationLinks_77d89fPage.WaitForBusinessownersTabToAppear_0096_767d1bAsync
        await _ui.WaitAsync(_locators.Businessowners, "Visible");
    }

    // Business step: I add SFP \- 10 Liability Farm Underlying LOB
    public async Task AddSFP10LiabilityFarmUnderlyingLOBAsync2()
    {
        // PolicyCovg_0dff37Page.SelectSFP10UnderlyingLOB_0097_767d1bAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludeSFP10LiabilityFarm);
        // UMBNavigationLinks_77d89fPage.WaitForSFP10LiabilityFarmTabToAppear_0098_767d1bAsync
        await _ui.WaitAsync(_locators.SFP10LiabilityFarm, "Visible");
    }

    // Business step: I add Commercial Package Policy Liability Underlying LOB
    public async Task AddCommercialPackagePolicyLiabilityUnderlyingLOBAsync2()
    {
        // PolicyCovg_0dff37Page.SelectCommercialPackagePolicyLiabilityUnderlyingLOB_0099_767d1bAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludeCommercialPackagePolicyLiability);
        // UMBNavigationLinks_77d89fPage.WaitForCommercialPackagePolicyLiabilityTabToAppear_0100_767d1bAsync
        await _ui.WaitAsync(_locators.CPPLiability, "Visible");
    }

    // Business step: I add Employers Liability Underlying LOB
    public async Task AddEmployersLiabilityUnderlyingLOBAsync2()
    {
        // PolicyCovg_0dff37Page.SelectEmployersLiabilityUnderlyingLOB_0101_767d1bAsync
        await _ui.WaitAsync(_locators.PolicyCovgFF145, "Visible");
        await _ui.ClickAsync(_locators.IncludeEmployersLiability);
        // UMBNavigationLinks_77d89fPage.WaitForEmployersLiabilityTabToAppear_0102_767d1bAsync
        await _ui.WaitAsync(_locators.EmployersLiab, "Visible");
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync9()
    {
        // Logout_e43d61Page.Logout_0363_767d1bAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0364_767d1bAsync
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0365_767d1bAsync
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0366_767d1bAsync
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0367_767d1bAsync
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0368_767d1bAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I add a new Associated Client \- Business Owner Type \- Click Add Client
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync6()
    {
        // ClientAddAssociatedClient_cb1bd9Page.AddANewAssociatedClientBusinessOwnerTypeClickAddClient_0048_bb930cAsync
        await _ui.WaitAsync(_locators.AddClient, "Exists");
        await _ui.PressAsync(_locators.AddClient, "PRE:TAB");
        await _ui.PressAsync(_locators.AddClient, "Tab");
        await _ui.ClickAsync(_locators.AddClient);
        // ClientAddAssociatedClient_cb1bd9Page.CheckIfIndividualTypeExists_0049_bb930cAsync
        await _ui.VerifyAsync(_locators.IndividualType, _data.Resolve("Absent"), "");
    }

    // Business step: I complete aJAX Error Check
    public async Task CompleteAJAXErrorCheckAsync6()
    {
        // AJAXError_19aa70Page.AJAXErrorCheck_0050_bb930cAsync
        await _ui.VerifyAsync(_locators.AJAXErrorCheck, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetBufferForError_0051_bb930cAsync
        _data.Set("AJAX Error", _data.Resolve("The scripts experienced an AJAX error with the following information: {B[AJAX]}"));
        // TBoxEvaluationTool_b95b5cPage.ForceAFail_0052_bb930cAsync
        _data.Set("ForceAFail", _data.Resolve("'FALSE' == 'TRUE'"));
    }

    // Business step: I complete WC Specific Fields
    public async Task CompleteWCSpecificFieldsAsync2()
    {
        // PolicyInfoWCSpecificFields_35da7aPage.PolicyInfoWCSpecificFields_0087_bb930cAsync
        await _ui.FillAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, _data.Resolve("{{data:has_the_applicant_been_in_business_for_at_least_3_years_with_continuous_workers_compensation_coverage_123}}"));
        await _ui.PressAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, "CLICK");
        await _ui.PressAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, "Enter");
        await _ui.PressAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, "Tab");
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync10()
    {
        // Logout_e43d61Page.Logout_0289_bb930cAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0290_bb930cAsync
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0291_bb930cAsync
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0292_bb930cAsync
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0293_bb930cAsync
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0294_bb930cAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I add a new Associated Client \- Business Owner Type \- Click Add Client
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync7()
    {
        // ClientAddAssociatedClient_cb1bd9Page.AddANewAssociatedClientBusinessOwnerTypeClickAddClient_0048_a8e5f5Async
        await _ui.WaitAsync(_locators.AddClient, "Exists");
        await _ui.PressAsync(_locators.AddClient, "PRE:TAB");
        await _ui.PressAsync(_locators.AddClient, "Tab");
        await _ui.ClickAsync(_locators.AddClient);
        // ClientAddAssociatedClient_cb1bd9Page.CheckIfIndividualTypeExists_0049_a8e5f5Async
        await _ui.VerifyAsync(_locators.IndividualType, _data.Resolve("Absent"), "");
    }

    // Business step: I complete aJAX Error Check
    public async Task CompleteAJAXErrorCheckAsync7()
    {
        // AJAXError_19aa70Page.AJAXErrorCheck_0050_a8e5f5Async
        await _ui.VerifyAsync(_locators.AJAXErrorCheck, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetBufferForError_0051_a8e5f5Async
        _data.Set("AJAX Error", _data.Resolve("The scripts experienced an AJAX error with the following information: {B[AJAX]}"));
        // TBoxEvaluationTool_b95b5cPage.ForceAFail_0052_a8e5f5Async
        _data.Set("ForceAFail", _data.Resolve("'FALSE' == 'TRUE'"));
    }

    // Business step: I complete restart Edge Popup
    public async Task CompleteRestartEdgePopupAsync6()
    {
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageExists_0044_b3ff07Async
        await _ui.VerifyAsync(_locators.RestartMicrosoftEdgeMessageOK, _data.Resolve("Exists"), "");
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageClickOK_0045_b3ff07Async
        await _ui.ClickAsync(_locators.RestartMicrosoftEdgeMessageOK);
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync11()
    {
        // Logout_e43d61Page.Logout_0048_b3ff07Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0049_b3ff07Async
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0050_b3ff07Async
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0051_b3ff07Async
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0052_b3ff07Async
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0053_b3ff07Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I sign out of the application for logged in user
    public async Task SignOutOfTheApplicationForLoggedInUserAsync5()
    {
        // Logout_e43d61Page.Logout_0130_b3ff07Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0131_b3ff07Async
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0132_b3ff07Async
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0133_b3ff07Async
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0134_b3ff07Async
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0135_b3ff07Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I complete restart Edge Popup
    public async Task CompleteRestartEdgePopupAsync7()
    {
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageExists_0045_c7d608Async
        await _ui.VerifyAsync(_locators.RestartMicrosoftEdgeMessageOK, _data.Resolve("Exists"), "");
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageClickOK_0046_c7d608Async
        await _ui.ClickAsync(_locators.RestartMicrosoftEdgeMessageOK);
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync12()
    {
        // Logout_e43d61Page.Logout_0049_c7d608Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0050_c7d608Async
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0051_c7d608Async
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0052_c7d608Async
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0053_c7d608Async
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0054_c7d608Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I sign out of the application for logged in user
    public async Task SignOutOfTheApplicationForLoggedInUserAsync6()
    {
        // Logout_e43d61Page.Logout_0131_c7d608Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0132_c7d608Async
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0133_c7d608Async
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0134_c7d608Async
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0135_c7d608Async
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0136_c7d608Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I complete restart Edge Popup
    public async Task CompleteRestartEdgePopupAsync8()
    {
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageExists_0044_2a8772Async
        await _ui.VerifyAsync(_locators.RestartMicrosoftEdgeMessageOK, _data.Resolve("Exists"), "");
        // RestartMicrosoftEdgeMessage_4c4f32Page.RestartMicrosoftEdgeMessageClickOK_0045_2a8772Async
        await _ui.ClickAsync(_locators.RestartMicrosoftEdgeMessageOK);
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync13()
    {
        // Logout_e43d61Page.Logout_0048_2a8772Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0049_2a8772Async
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0050_2a8772Async
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0051_2a8772Async
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0052_2a8772Async
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0053_2a8772Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I sign out of the application for logged in user
    public async Task SignOutOfTheApplicationForLoggedInUserAsync7()
    {
        // Logout_e43d61Page.Logout_0130_2a8772Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0131_2a8772Async
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0132_2a8772Async
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0133_2a8772Async
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0134_2a8772Async
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0135_2a8772Async
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

    // Business step: I add a new Associated Client \- Business Owner Type \- Click Add Client
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync8()
    {
        // ClientAddAssociatedClient_cb1bd9Page.AddANewAssociatedClientBusinessOwnerTypeClickAddClient_0047_f2d6bdAsync
        await _ui.WaitAsync(_locators.AddClient, "Exists");
        await _ui.PressAsync(_locators.AddClient, "PRE:TAB");
        await _ui.PressAsync(_locators.AddClient, "Tab");
        await _ui.ClickAsync(_locators.AddClient);
        // ClientAddAssociatedClient_cb1bd9Page.CheckIfIndividualTypeExists_0048_f2d6bdAsync
        await _ui.VerifyAsync(_locators.IndividualType, _data.Resolve("Absent"), "");
    }

    // Business step: I complete aJAX Error Check
    public async Task CompleteAJAXErrorCheckAsync8()
    {
        // AJAXError_19aa70Page.AJAXErrorCheck_0049_f2d6bdAsync
        await _ui.VerifyAsync(_locators.AJAXErrorCheck, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetBufferForError_0050_f2d6bdAsync
        _data.Set("AJAX Error", _data.Resolve("The scripts experienced an AJAX error with the following information: {B[AJAX]}"));
        // TBoxEvaluationTool_b95b5cPage.ForceAFail_0051_f2d6bdAsync
        _data.Set("ForceAFail", _data.Resolve("'FALSE' == 'TRUE'"));
    }

    // Business step: I complete WC Specific Fields
    public async Task CompleteWCSpecificFieldsAsync3()
    {
        // PolicyInfoWCSpecificFields_35da7aPage.PolicyInfoWCSpecificFields_0086_f2d6bdAsync
        await _ui.FillAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, _data.Resolve("{{data:has_the_applicant_been_in_business_for_at_least_3_years_with_continuous_workers_compensation_coverage_118}}"));
        await _ui.PressAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, "CLICK");
        await _ui.PressAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, "Enter");
        await _ui.PressAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, "Tab");
    }

    // Business step: I sign out of the application
    public async Task SignOutOfTheApplicationAsync14()
    {
        // Logout_e43d61Page.Logout_0309_f2d6bdAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
        // TBoxWait_7ea9e1Page.SyncForLogOut_0310_f2d6bdAsync
        await Task.Delay(1000);
        // HttpErrorMsg_7f0d01Page.CheckForHttpErrorMsg_0311_f2d6bdAsync
        await _ui.VerifyAsync(_locators.TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0, _data.Resolve("Exists"), "");
        // HttpErrorMsg_7f0d01Page.ClickOKOnHttpErrorMsg_0312_f2d6bdAsync
        await _ui.ClickAsync(_locators.HttpErrorMsgOK);
        // HttpErrorMsg_7f0d01Page.CheckHttpErrorMsgDoesNotExist_0313_f2d6bdAsync
        await _ui.WaitAsync(_locators.HttpErrorMsgOK, "Absent");
        // Logout_e43d61Page.Logout_0314_f2d6bdAsync
        await _ui.ClickAsync(_locators.LoggedInUser);
        await _ui.ClickAsync(_locators.Logout);
    }

}