using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class LoginPage
{
    private readonly BrowserSession _browser;

    private readonly LoginLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public LoginPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _browser = browser;

        _locators = new LoginLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I sign in to Duck Creek
    public async Task SignInToDuckCreekAsync()
    {
        // OpenUrl_677fdaPage.OpenUrl_0028_d344b2Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // TBoxEvaluationTool_b95b5cPage.CheckTheLoopLogin_0029_d344b2Async
        _data.Set("CheckTheLoopLogin", _data.Resolve("{B[Loop Login]} = 0"));
        // TBoxSetBuffer_e51da1Page.SetLoopBuffer_0030_d344b2Async
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login}}"));
        _data.Set("URL", _data.Resolve("{{data:url}}"));
        _data.Set("UserName", _data.Resolve("{{env:CL_DC_USERNAME}}"));
        _data.Set("Password", _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        // OpenUrl_677fdaPage.OpenUrl_0041_d344b2Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        // EdgeBrowser_7d22bfPage.WaitOnEdgeBrowserToOpen_0042_d344b2Async
        await _ui.WaitAsync(_locators.BODY, "Exists");
        // TBoxWait_7ea9e1Page.PolicyLoadSync_0043_d344b2Async
        await Task.Delay(1000);
    }

    // Business step: I sign in to Duck Creek for logged in user
    public async Task SignInToDuckCreekForLoggedInUserAsync()
    {
        // Logout_e43d61Page.CheckForLogIn_0047_d344b2Async
        await _ui.VerifyAsync(_locators.LoggedInUser, _data.Resolve("Exists"), "");
    }

    // Business step: I sign in to Duck Creek for username
    public async Task SignInToDuckCreekForUsernameAsync()
    {
        // Login_4e5a28Page.Login_0055_d344b2Async
        await _ui.FillAsync(_locators.UserName, _data.Resolve("{{env:CL_DC_USERNAME}}"));
        await _ui.PressAsync(_locators.UserName, "Tab");
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.Login);
        // Login_4e5a28Page.WaitForLoginScreenToGoAway_0056_d344b2Async
        await _ui.WaitAsync(_locators.Login, "Absent");
        // TBoxSetBuffer_e51da1Page.SetLoopBufferToExitLoop_0057_d344b2Async
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login_2}}"));
        // TBoxSetBuffer_e51da1Page.SetDocPathBuffer_0059_d344b2Async
        _data.Set("DocPath", _data.Resolve(""));
        // TBoxSetBuffer_e51da1Page.RetrieveDexAgentName_0060_d344b2Async
        _data.Set("GetHostname", _data.Resolve("\"\"\"${COMPUTERNAME}\"\"\""));
        _data.Set("AgentName", _data.Resolve("{B[GetHostname]}"));
    }

    // Business step: I sign in to Duck Creek
    public async Task SignInToDuckCreekAsync2()
    {
        // OpenUrl_677fdaPage.OpenUrl_0028_a1ba9cAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // TBoxEvaluationTool_b95b5cPage.CheckTheLoopLogin_0029_a1ba9cAsync
        _data.Set("CheckTheLoopLogin", _data.Resolve("{B[Loop Login]} = 0"));
        // TBoxSetBuffer_e51da1Page.SetLoopBuffer_0030_a1ba9cAsync
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login}}"));
        _data.Set("URL", _data.Resolve("{{data:url}}"));
        _data.Set("UserName", _data.Resolve("{{env:CL_DC_USERNAME}}"));
        _data.Set("Password", _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        // OpenUrl_677fdaPage.OpenUrl_0041_a1ba9cAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        // EdgeBrowser_7d22bfPage.WaitOnEdgeBrowserToOpen_0042_a1ba9cAsync
        await _ui.WaitAsync(_locators.BODY, "Exists");
        // TBoxWait_7ea9e1Page.PolicyLoadSync_0043_a1ba9cAsync
        await Task.Delay(1000);
    }

    // Business step: I sign in to Duck Creek for logged in user
    public async Task SignInToDuckCreekForLoggedInUserAsync2()
    {
        // Logout_e43d61Page.CheckForLogIn_0047_a1ba9cAsync
        await _ui.VerifyAsync(_locators.LoggedInUser, _data.Resolve("Exists"), "");
    }

    // Business step: I sign in to Duck Creek for username
    public async Task SignInToDuckCreekForUsernameAsync2()
    {
        // Login_4e5a28Page.Login_0055_a1ba9cAsync
        await _ui.FillAsync(_locators.UserName, _data.Resolve("{{env:CL_DC_USERNAME}}"));
        await _ui.PressAsync(_locators.UserName, "Tab");
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.Login);
        // Login_4e5a28Page.WaitForLoginScreenToGoAway_0056_a1ba9cAsync
        await _ui.WaitAsync(_locators.Login, "Absent");
        // TBoxSetBuffer_e51da1Page.SetLoopBufferToExitLoop_0057_a1ba9cAsync
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login_2}}"));
        // TBoxSetBuffer_e51da1Page.SetDocPathBuffer_0059_a1ba9cAsync
        _data.Set("DocPath", _data.Resolve(""));
        // TBoxSetBuffer_e51da1Page.RetrieveDexAgentName_0060_a1ba9cAsync
        _data.Set("GetHostname", _data.Resolve("\"\"\"${COMPUTERNAME}\"\"\""));
        _data.Set("AgentName", _data.Resolve("{B[GetHostname]}"));
    }

    // Business step: I sign in to Duck Creek
    public async Task SignInToDuckCreekAsync3()
    {
        // OpenUrl_677fdaPage.OpenUrl_0028_85cb3fAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // TBoxEvaluationTool_b95b5cPage.CheckTheLoopLogin_0029_85cb3fAsync
        _data.Set("CheckTheLoopLogin", _data.Resolve("{B[Loop Login]} = 0"));
        // TBoxSetBuffer_e51da1Page.SetLoopBuffer_0030_85cb3fAsync
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login}}"));
        _data.Set("URL", _data.Resolve("{{data:url}}"));
        _data.Set("UserName", _data.Resolve("{{env:CL_DC_USERNAME}}"));
        _data.Set("Password", _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        // OpenUrl_677fdaPage.OpenUrl_0041_85cb3fAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        // EdgeBrowser_7d22bfPage.WaitOnEdgeBrowserToOpen_0042_85cb3fAsync
        await _ui.WaitAsync(_locators.BODY, "Exists");
        // TBoxWait_7ea9e1Page.PolicyLoadSync_0043_85cb3fAsync
        await Task.Delay(1000);
    }

    // Business step: I sign in to Duck Creek for logged in user
    public async Task SignInToDuckCreekForLoggedInUserAsync3()
    {
        // Logout_e43d61Page.CheckForLogIn_0047_85cb3fAsync
        await _ui.VerifyAsync(_locators.LoggedInUser, _data.Resolve("Exists"), "");
    }

    // Business step: I sign in to Duck Creek for username
    public async Task SignInToDuckCreekForUsernameAsync3()
    {
        // Login_4e5a28Page.Login_0055_85cb3fAsync
        await _ui.FillAsync(_locators.UserName, _data.Resolve("{{env:CL_DC_USERNAME}}"));
        await _ui.PressAsync(_locators.UserName, "Tab");
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.Login);
        // Login_4e5a28Page.WaitForLoginScreenToGoAway_0056_85cb3fAsync
        await _ui.WaitAsync(_locators.Login, "Absent");
        // TBoxSetBuffer_e51da1Page.SetLoopBufferToExitLoop_0057_85cb3fAsync
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login_2}}"));
        // TBoxSetBuffer_e51da1Page.SetDocPathBuffer_0059_85cb3fAsync
        _data.Set("DocPath", _data.Resolve(""));
        // TBoxSetBuffer_e51da1Page.RetrieveDexAgentName_0060_85cb3fAsync
        _data.Set("GetHostname", _data.Resolve("\"\"\"${COMPUTERNAME}\"\"\""));
        _data.Set("AgentName", _data.Resolve("{B[GetHostname]}"));
    }

    // Business step: I sign in to Duck Creek
    public async Task SignInToDuckCreekAsync4()
    {
        // OpenUrl_677fdaPage.OpenUrl_0028_c839dfAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // TBoxEvaluationTool_b95b5cPage.CheckTheLoopLogin_0029_c839dfAsync
        _data.Set("CheckTheLoopLogin", _data.Resolve("{B[Loop Login]} = 0"));
        // TBoxSetBuffer_e51da1Page.SetLoopBuffer_0030_c839dfAsync
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login}}"));
        _data.Set("URL", _data.Resolve("{{data:url}}"));
        _data.Set("UserName", _data.Resolve("{{env:CL_DC_USERNAME}}"));
        _data.Set("Password", _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        // OpenUrl_677fdaPage.OpenUrl_0041_c839dfAsync
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        // EdgeBrowser_7d22bfPage.WaitOnEdgeBrowserToOpen_0042_c839dfAsync
        await _ui.WaitAsync(_locators.BODY, "Exists");
        // TBoxWait_7ea9e1Page.PolicyLoadSync_0043_c839dfAsync
        await Task.Delay(1000);
    }

    // Business step: I sign in to Duck Creek for logged in user
    public async Task SignInToDuckCreekForLoggedInUserAsync4()
    {
        // Logout_e43d61Page.CheckForLogIn_0047_c839dfAsync
        await _ui.VerifyAsync(_locators.LoggedInUser, _data.Resolve("Exists"), "");
    }

    // Business step: I sign in to Duck Creek for username
    public async Task SignInToDuckCreekForUsernameAsync4()
    {
        // Login_4e5a28Page.Login_0055_c839dfAsync
        await _ui.FillAsync(_locators.UserName, _data.Resolve("{{env:CL_DC_USERNAME}}"));
        await _ui.PressAsync(_locators.UserName, "Tab");
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.Login);
        // Login_4e5a28Page.WaitForLoginScreenToGoAway_0056_c839dfAsync
        await _ui.WaitAsync(_locators.Login, "Absent");
        // TBoxSetBuffer_e51da1Page.SetLoopBufferToExitLoop_0057_c839dfAsync
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login_2}}"));
        // TBoxSetBuffer_e51da1Page.SetDocPathBuffer_0059_c839dfAsync
        _data.Set("DocPath", _data.Resolve(""));
        // TBoxSetBuffer_e51da1Page.RetrieveDexAgentName_0060_c839dfAsync
        _data.Set("GetHostname", _data.Resolve("\"\"\"${COMPUTERNAME}\"\"\""));
        _data.Set("AgentName", _data.Resolve("{B[GetHostname]}"));
    }

    // Business step: I sign in to Duck Creek
    public async Task SignInToDuckCreekAsync5()
    {
        // OpenUrl_677fdaPage.OpenUrl_0147_677267Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // TBoxEvaluationTool_b95b5cPage.CheckTheLoopLogin_0148_677267Async
        _data.Set("CheckTheLoopLogin", _data.Resolve("{B[Loop Login]} = 0"));
        // TBoxSetBuffer_e51da1Page.SetLoopBuffer_0149_677267Async
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login}}"));
        _data.Set("URL", _data.Resolve("{{data:url}}"));
        _data.Set("UserName", _data.Resolve("{{env:CL_DC_USERNAME}}"));
        _data.Set("Password", _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        // OpenUrl_677fdaPage.OpenUrl_0160_677267Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        // EdgeBrowser_7d22bfPage.WaitOnEdgeBrowserToOpen_0161_677267Async
        await _ui.WaitAsync(_locators.BODY, "Exists");
        // TBoxWait_7ea9e1Page.PolicyLoadSync_0162_677267Async
        await Task.Delay(1000);
    }

    // Business step: I sign in to Duck Creek for logged in user
    public async Task SignInToDuckCreekForLoggedInUserAsync5()
    {
        // Logout_e43d61Page.CheckForLogIn_0166_677267Async
        await _ui.VerifyAsync(_locators.LoggedInUser, _data.Resolve("Exists"), "");
    }

    // Business step: I sign in to Duck Creek for username
    public async Task SignInToDuckCreekForUsernameAsync5()
    {
        // Login_4e5a28Page.Login_0174_677267Async
        await _ui.FillAsync(_locators.UserName, _data.Resolve("{{env:CL_DC_USERNAME}}"));
        await _ui.PressAsync(_locators.UserName, "Tab");
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.Login);
        // Login_4e5a28Page.WaitForLoginScreenToGoAway_0175_677267Async
        await _ui.WaitAsync(_locators.Login, "Absent");
        // TBoxSetBuffer_e51da1Page.SetLoopBufferToExitLoop_0176_677267Async
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login_2}}"));
        // TBoxSetBuffer_e51da1Page.SetDocPathBuffer_0178_677267Async
        _data.Set("DocPath", _data.Resolve("{{data:docpath}}"));
        // TBoxSetBuffer_e51da1Page.RetrieveDexAgentName_0179_677267Async
        _data.Set("GetHostname", _data.Resolve("\"\"\"${COMPUTERNAME}\"\"\""));
        _data.Set("AgentName", _data.Resolve("{B[GetHostname]}"));
    }

    // Business step: I sign in to Duck Creek
    public async Task SignInToDuckCreekAsync6()
    {
        // OpenUrl_677fdaPage.OpenUrl_0028_b3ff07Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // TBoxEvaluationTool_b95b5cPage.CheckTheLoopLogin_0029_b3ff07Async
        _data.Set("CheckTheLoopLogin", _data.Resolve("{B[Loop Login]} = 0"));
        // TBoxSetBuffer_e51da1Page.SetLoopBuffer_0030_b3ff07Async
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login}}"));
        _data.Set("URL", _data.Resolve("{{data:url}}"));
        _data.Set("UserName", _data.Resolve("{{env:CL_DC_USERNAME}}"));
        _data.Set("Password", _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        // OpenUrl_677fdaPage.OpenUrl_0041_b3ff07Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        // EdgeBrowser_7d22bfPage.WaitOnEdgeBrowserToOpen_0042_b3ff07Async
        await _ui.WaitAsync(_locators.BODY, "Exists");
        // TBoxWait_7ea9e1Page.PolicyLoadSync_0043_b3ff07Async
        await Task.Delay(1000);
    }

    // Business step: I sign in to Duck Creek for logged in user
    public async Task SignInToDuckCreekForLoggedInUserAsync6()
    {
        // Logout_e43d61Page.CheckForLogIn_0047_b3ff07Async
        await _ui.VerifyAsync(_locators.LoggedInUser, _data.Resolve("Exists"), "");
    }

    // Business step: I sign in to Duck Creek for username
    public async Task SignInToDuckCreekForUsernameAsync6()
    {
        // Login_4e5a28Page.Login_0055_b3ff07Async
        await _ui.FillAsync(_locators.UserName, _data.Resolve("{{env:CL_DC_USERNAME}}"));
        await _ui.PressAsync(_locators.UserName, "Tab");
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.Login);
        // Login_4e5a28Page.WaitForLoginScreenToGoAway_0056_b3ff07Async
        await _ui.WaitAsync(_locators.Login, "Absent");
        // TBoxSetBuffer_e51da1Page.SetLoopBufferToExitLoop_0057_b3ff07Async
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login_2}}"));
        // TBoxSetBuffer_e51da1Page.SetDocPathBuffer_0059_b3ff07Async
        _data.Set("DocPath", _data.Resolve(""));
        // TBoxSetBuffer_e51da1Page.RetrieveDexAgentName_0060_b3ff07Async
        _data.Set("GetHostname", _data.Resolve("\"\"\"${COMPUTERNAME}\"\"\""));
        _data.Set("AgentName", _data.Resolve("{B[GetHostname]}"));
    }

    // Business step: I sign in to Duck Creek
    public async Task SignInToDuckCreekAsync7()
    {
        // OpenUrl_677fdaPage.OpenUrl_0029_c7d608Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // TBoxEvaluationTool_b95b5cPage.CheckTheLoopLogin_0030_c7d608Async
        _data.Set("CheckTheLoopLogin", _data.Resolve("{B[Loop Login]} = 0"));
        // TBoxSetBuffer_e51da1Page.SetLoopBuffer_0031_c7d608Async
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login}}"));
        _data.Set("URL", _data.Resolve("{{data:url}}"));
        _data.Set("UserName", _data.Resolve("{{env:CL_DC_USERNAME}}"));
        _data.Set("Password", _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        // OpenUrl_677fdaPage.OpenUrl_0042_c7d608Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        // EdgeBrowser_7d22bfPage.WaitOnEdgeBrowserToOpen_0043_c7d608Async
        await _ui.WaitAsync(_locators.BODY, "Exists");
        // TBoxWait_7ea9e1Page.PolicyLoadSync_0044_c7d608Async
        await Task.Delay(1000);
    }

    // Business step: I sign in to Duck Creek for logged in user
    public async Task SignInToDuckCreekForLoggedInUserAsync7()
    {
        // Logout_e43d61Page.CheckForLogIn_0048_c7d608Async
        await _ui.VerifyAsync(_locators.LoggedInUser, _data.Resolve("Exists"), "");
    }

    // Business step: I sign in to Duck Creek for username
    public async Task SignInToDuckCreekForUsernameAsync7()
    {
        // Login_4e5a28Page.Login_0056_c7d608Async
        await _ui.FillAsync(_locators.UserName, _data.Resolve("{{env:CL_DC_USERNAME}}"));
        await _ui.PressAsync(_locators.UserName, "Tab");
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.Login);
        // Login_4e5a28Page.WaitForLoginScreenToGoAway_0057_c7d608Async
        await _ui.WaitAsync(_locators.Login, "Absent");
        // TBoxSetBuffer_e51da1Page.SetLoopBufferToExitLoop_0058_c7d608Async
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login_2}}"));
        // TBoxSetBuffer_e51da1Page.SetDocPathBuffer_0060_c7d608Async
        _data.Set("DocPath", _data.Resolve(""));
        // TBoxSetBuffer_e51da1Page.RetrieveDexAgentName_0061_c7d608Async
        _data.Set("GetHostname", _data.Resolve("\"\"\"${COMPUTERNAME}\"\"\""));
        _data.Set("AgentName", _data.Resolve("{B[GetHostname]}"));
    }

    // Business step: I sign in to Duck Creek
    public async Task SignInToDuckCreekAsync8()
    {
        // OpenUrl_677fdaPage.OpenUrl_0028_2a8772Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        // TBoxEvaluationTool_b95b5cPage.CheckTheLoopLogin_0029_2a8772Async
        _data.Set("CheckTheLoopLogin", _data.Resolve("{B[Loop Login]} = 0"));
        // TBoxSetBuffer_e51da1Page.SetLoopBuffer_0030_2a8772Async
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login}}"));
        _data.Set("URL", _data.Resolve("{{data:url}}"));
        _data.Set("UserName", _data.Resolve("{{env:CL_DC_USERNAME}}"));
        _data.Set("Password", _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        // OpenUrl_677fdaPage.OpenUrl_0041_2a8772Async
        await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url_2}}"));
        // EdgeBrowser_7d22bfPage.WaitOnEdgeBrowserToOpen_0042_2a8772Async
        await _ui.WaitAsync(_locators.BODY, "Exists");
        // TBoxWait_7ea9e1Page.PolicyLoadSync_0043_2a8772Async
        await Task.Delay(1000);
    }

    // Business step: I sign in to Duck Creek for logged in user
    public async Task SignInToDuckCreekForLoggedInUserAsync8()
    {
        // Logout_e43d61Page.CheckForLogIn_0047_2a8772Async
        await _ui.VerifyAsync(_locators.LoggedInUser, _data.Resolve("Exists"), "");
    }

    // Business step: I sign in to Duck Creek for username
    public async Task SignInToDuckCreekForUsernameAsync8()
    {
        // Login_4e5a28Page.Login_0055_2a8772Async
        await _ui.FillAsync(_locators.UserName, _data.Resolve("{{env:CL_DC_USERNAME}}"));
        await _ui.PressAsync(_locators.UserName, "Tab");
        await _ui.FillAsync(_locators.Password, _data.Resolve("{{env:CL_DC_PASSWORD}}"));
        await _ui.ClickAsync(_locators.Login);
        // Login_4e5a28Page.WaitForLoginScreenToGoAway_0056_2a8772Async
        await _ui.WaitAsync(_locators.Login, "Absent");
        // TBoxSetBuffer_e51da1Page.SetLoopBufferToExitLoop_0057_2a8772Async
        _data.Set("Loop Login", _data.Resolve("{{data:loop_login_2}}"));
        // TBoxSetBuffer_e51da1Page.SetDocPathBuffer_0059_2a8772Async
        _data.Set("DocPath", _data.Resolve(""));
        // TBoxSetBuffer_e51da1Page.RetrieveDexAgentName_0060_2a8772Async
        _data.Set("GetHostname", _data.Resolve("\"\"\"${COMPUTERNAME}\"\"\""));
        _data.Set("AgentName", _data.Resolve("{B[GetHostname]}"));
    }

}
