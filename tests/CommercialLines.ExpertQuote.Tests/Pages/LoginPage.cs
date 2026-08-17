using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class LoginPage
{
    private readonly BrowserSession _browser;
    private readonly ApplicationLogin _auth;

    private readonly LoginLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public LoginPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _browser = browser;
        _auth = new ApplicationLogin(browser, data, ui);

        _locators = new LoginLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1
    public async Task OpenACLASBrowserAndSearchForEQByDescription1ForOpenAClasBrowserAndSearchForEqByDescription1Async()
    {
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.OpenUrl_0260_503012Async
        if (_data.Condition("if an existing CLAS session is still logged in"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.Login_0261_503012Async
        await _ui.WaitAsync(_locators.UserName, "Exists");
        await _auth.SignInAsync("CL_DC");
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.WaitForLoginScreenToGoAway_0262_503012Async
        await _ui.WaitAsync(_locators.Login0D21A, "Absent");
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.EnterQuoteInQuickSearch_0263_503012Async
        await _ui.FillAsync(_locators.SearchMode, _data.Resolve("{{data:search_mode_331}}"));
        await _ui.FillAsync(_locators.SearchText, _data.Resolve("{B[LastName]}, {B[FirstName]}"));
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.ClickAsync(_locators.QuickSearchButton);
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.VerifyViewPolicyExists_0264_503012Async
        await _ui.WaitAsync(_locators.ViewPolicy, "Exists");
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1DCEQCommonGeneralWaitOnLoadingIndicator_b4e5d2Page.CheckForLoadingIndicator_0265_503012Async
        if (await _ui.ExistsAsync(_locators.LoadingMessage))
        {
            await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1DCEQCommonGeneralWaitOnLoadingIndicator_b4e5d2Page.Wait2Secs_0266_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.ClickViewPolicy_0267_503012Async
        await _ui.ClickAsync(_locators.ViewPolicy);
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1DCEQCommonGeneralWaitOnLoadingIndicator_b4e5d2Page.CheckForLoadingIndicator_0268_503012Async
        if (await _ui.ExistsAsync(_locators.LoadingMessage))
        {
            await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1DCEQCommonGeneralWaitOnLoadingIndicator_b4e5d2Page.Wait2Secs_0269_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1DCEQCommonGeneralWaitOnLoadingIndicator_b4e5d2Page.PolicyLoadSync_0270_503012Async
        await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
        // CLEQCommonGeneralFormsVerificationForEQInCLAS_4a1c59Page.GetSessionIDBuffer_0272_503012Async
        await _ui.FillAsync(_locators.GetSessionIDBuffer, _data.Resolve("{{data:get_session_id_buffer_342}}"));
        await _ui.FillAsync(_locators.GetSessionIDBuffer, _data.Resolve("{{data:get_session_id_buffer_343}}"));
        await _ui.FillAsync(_locators.GetSessionIDBuffer, _data.Resolve("{{runtime:SessionId}}"));
        // CLEQCommonGeneralFormsVerificationForEQInCLAS_4a1c59Page.BufferServerAddress_0273_503012Async
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
    }

    // Business step: I sign in to ExpertQuote
    public async Task SignInToExpertQuoteAsync()
    {
        // EQCommonLoginToEQSSO_af2135Page.Login_0373_d18a3eAsync
        await _ui.WaitAsync(_locators.Username, "Exists");
        await _auth.SignInAsync("CL_EQ");
        // EQCommonLoginToEQSSO_af2135Page.RetrieveDexAgentName_0374_d18a3eAsync
        _data.Set("GetHostname", _data.Resolve("{{env:COMPUTERNAME}}"));
        _data.Set("AgentName", _data.Resolve("{{runtime:GetHostname}}"));
        // CLEQCommonSearchByQuoteNumCLEQCommonWaitOnLoadingIndicator_1394d4Page.EQLoadingIndicatorWait_0375_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I open a CLAS Browser and Search for EQ by Description for cl dc
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForClDcAsync()
    {
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.OpenUrl_0406_d18a3eAsync
        if (_data.Condition("if an existing CLAS session is still logged in"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_3}}"));
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.Login_0407_d18a3eAsync
        await _auth.SignInAsync("CL_DC");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.WaitForLoginScreenToGoAway_0408_d18a3eAsync
        await _ui.WaitAsync(_locators.LoginC45A2, "Absent");
    }

    // Business step: I sign in to ExpertQuote for username
    public async Task SignInToExpertQuoteForUsernameAsync()
    {
        // EQCommonLoginToEQSSO_af2135Page.Login_0491_d18a3eAsync
        await _ui.WaitAsync(_locators.Username, "Exists");
        await _auth.SignInAsync("CL_EQ");
        // EQCommonLoginToEQSSO_af2135Page.RetrieveDexAgentName_0492_d18a3eAsync
        _data.Set("GetHostname", _data.Resolve("{{env:COMPUTERNAME}}"));
        _data.Set("AgentName", _data.Resolve("{{runtime:GetHostname}}"));
        // CLEQCommonSearchByQuoteNumCLEQCommonWaitOnLoadingIndicator_1394d4Page.EQLoadingIndicatorWait_0493_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I open a CLAS Browser and Search for EQ by Description for open a clas browser and search for eq by description
    public async Task OpenACLASBrowserAndSearchForEQByDescriptionForOpenAClasBrowserAndSearchForEqByDescriptionAsync()
    {
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.OpenUrl_0587_d18a3eAsync
        if (_data.Condition("if an existing CLAS session is still logged in"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_3}}"));
        }
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.Login_0588_d18a3eAsync
        await _auth.SignInAsync("CL_DC");
        // CLEQCommonOpenACLASBrowserAndSearchForEQByDescription_f027fePage.WaitForLoginScreenToGoAway_0589_d18a3eAsync
        await _ui.WaitAsync(_locators.LoginC45A2, "Absent");
    }

    // Business step: I sign in to ExpertQuote for login to eq sso
    public async Task SignInToExpertQuoteForLoginToEqSsoAsync()
    {
        // EQCommonLoginToEQSSO_af2135Page.Login_0808_d18a3eAsync
        await _ui.WaitAsync(_locators.Username, "Exists");
        await _auth.SignInAsync("CL_EQ");
        // EQCommonLoginToEQSSO_af2135Page.RetrieveDexAgentName_0809_d18a3eAsync
        _data.Set("GetHostname", _data.Resolve("{{env:COMPUTERNAME}}"));
        _data.Set("AgentName", _data.Resolve("{{runtime:GetHostname}}"));
        // CLEQCommonSearchByQuoteNumCLEQCommonWaitOnLoadingIndicator_1394d4Page.EQLoadingIndicatorWait_0818_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I sign in to Duck Creek
    public async Task SignInToDuckCreekAsync()
    {
        // CommonGeneralLogInToDuckCreek_bd7c3ePage.OpenUrl_0838_d18a3eAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // CommonGeneralLogInToDuckCreek_bd7c3ePage.CheckTheLoopLogin_0839_d18a3eAsync
        if (_data.Condition("during loop for the Login [max=30]"))
        {
            _data.Set("CheckTheLoopLogin", _data.Resolve("{\"Expression\": \"{B[Loop Login]} = 0\"}"));
        }
        // CommonGeneralLogInToDuckCreek_bd7c3ePage.SetLoopBuffer_0840_d18a3eAsync
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login}}"));
        _data.Set("URL", _data.Resolve("{{data:url}}"));
        _data.Set("UserName", _data.Resolve("{{env:CL_DC_USERNAME}}"));
        _data.Set("Password", _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        // CommonGeneralLogInToDuckCreek_bd7c3ePage.OpenUrl_0851_d18a3eAsync
        if (_data.Condition("during loop for the Login [max=30]"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_4}}"));
        }
        // CommonGeneralLogInToDuckCreek_bd7c3ePage.WaitOnEdgeBrowserToOpen_0852_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.BODY))
        {
            await _ui.WaitAsync(_locators.BODY, "Exists");
        }
        // CommonGeneralLogInToDuckCreek_bd7c3ePage.PolicyLoadSync_0853_d18a3eAsync
        if (_data.Condition("during loop for the Login [max=30]"))
        {
            await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
        }
    }

    // Business step: I sign in to Duck Creek for logged in user
    public async Task SignInToDuckCreekForLoggedInUserAsync()
    {
        // CommonGeneralLogInToDuckCreek_bd7c3ePage.CheckForLogIn_0857_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoggedInUser))
        {
            await _ui.VerifyAsync(_locators.LoggedInUser, _data.Resolve("Exists"), "");
        }
    }

    // Business step: I sign in to Duck Creek for cl dc
    public async Task SignInToDuckCreekForClDcAsync()
    {
        // CommonGeneralLogInToDuckCreek_bd7c3ePage.Login_0865_d18a3eAsync
        await _auth.SignInAsync("CL_DC");
        // CommonGeneralLogInToDuckCreek_bd7c3ePage.WaitForLoginScreenToGoAway_0866_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Login07237))
        {
            await _ui.WaitAsync(_locators.Login07237, "Absent");
        }
        // CommonGeneralLogInToDuckCreek_bd7c3ePage.SetLoopBufferToExitLoop_0867_d18a3eAsync
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login_2}}"));
        // CommonGeneralLogInToDuckCreek_bd7c3ePage.SetDocPathBuffer_0869_d18a3eAsync
        _data.Set("DocPath", _data.Resolve(""));
        // CommonGeneralLogInToDuckCreek_bd7c3ePage.RetrieveDexAgentName_0870_d18a3eAsync
        _data.Set("GetHostname", _data.Resolve("{{env:COMPUTERNAME}}"));
        _data.Set("AgentName", _data.Resolve("{{runtime:GetHostname}}"));
        // CommonDashboardPerformQuickSearchAndOpenPolicy_3431c5Page.SmallStaticWaitForSyncronization_0871_d18a3eAsync
        await Task.Delay(1000);
    }

    // Business step: I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1
    public async Task OpenACLASBrowserAndSearchForEQByDescription1ForOpenAClasBrowserAndSearchForEqByDescription1Async2()
    {
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.OpenUrl_0312_08f3f1Async
        if (_data.Condition("if an existing CLAS session is still logged in"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.Login_0313_08f3f1Async
        await _ui.WaitAsync(_locators.UserName, "Exists");
        await _auth.SignInAsync("CL_DC");
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.WaitForLoginScreenToGoAway_0314_08f3f1Async
        await _ui.WaitAsync(_locators.Login0D21A, "Absent");
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.EnterQuoteInQuickSearch_0315_08f3f1Async
        await _ui.FillAsync(_locators.SearchMode, _data.Resolve("{{data:search_mode_379}}"));
        await _ui.FillAsync(_locators.SearchText, _data.Resolve("{B[LastName]}, {B[FirstName]}"));
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.ClickAsync(_locators.QuickSearchButton);
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.VerifyViewPolicyExists_0316_08f3f1Async
        await _ui.WaitAsync(_locators.ViewPolicy, "Exists");
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1DCEQCommonGeneralWaitOnLoadingIndicator_b4e5d2Page.CheckForLoadingIndicator_0317_08f3f1Async
        if (await _ui.ExistsAsync(_locators.LoadingMessage))
        {
            await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1DCEQCommonGeneralWaitOnLoadingIndicator_b4e5d2Page.Wait2Secs_0318_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1_d98ea2Page.ClickViewPolicy_0319_08f3f1Async
        await _ui.ClickAsync(_locators.ViewPolicy);
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1DCEQCommonGeneralWaitOnLoadingIndicator_b4e5d2Page.CheckForLoadingIndicator_0320_08f3f1Async
        if (await _ui.ExistsAsync(_locators.LoadingMessage))
        {
            await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        }
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1DCEQCommonGeneralWaitOnLoadingIndicator_b4e5d2Page.Wait2Secs_0321_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPOpenACLASBrowserAndSearchForEQByDescription1DCEQCommonGeneralWaitOnLoadingIndicator_b4e5d2Page.PolicyLoadSync_0322_08f3f1Async
        await _ui.ReviewRequiredAsync("Source operation requires environment-specific implementation.");
    }

}
