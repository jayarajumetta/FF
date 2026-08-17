using InsuranceAutomation.Core;
using Microsoft.Playwright;
namespace InsuranceAutomation.CLEQ.Pages;
public sealed class ApplicationPage
{
    private readonly BrowserSession _browser;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;
    public ApplicationPage(BrowserSession browser, ScenarioData data, PageUiActions ui) { _browser=browser; _data=data; _ui=ui; }
    private ILocator UserName => _browser.Page.GetByRole(AriaRole.Textbox, new() { Name = "Username", Exact = true });
    private ILocator Password => _browser.Page.GetByRole(AriaRole.Textbox, new() { Name = "Password", Exact = true });
    private ILocator SignOn => _browser.Page.GetByRole(AriaRole.Button, new() { Name = "Sign On", Exact = true });
    public async Task OpenAsync() { var url=_data.Get("url",_data.Get("Url")); if(string.IsNullOrWhiteSpace(url)) throw new InvalidOperationException("Application URL is missing from scenario data."); await _browser.Page.GotoAsync(url); }
    public async Task SignInAsync() { var user=_data.Get("username"); var password=_data.Get("password"); if(string.IsNullOrWhiteSpace(user)||string.IsNullOrWhiteSpace(password)||password=="SYNTHETIC_REPLACE_ME") throw new InvalidOperationException("Application credentials are missing from scenario data."); await _ui.FillAsync(UserName,user); await _ui.FillAsync(Password,password); await _ui.ClickAsync(SignOn); }
}
