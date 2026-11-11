using InsuranceAutomation.CLDC.Pages.Locators;
using InsuranceAutomation.CLDC.Runtime;
using InsuranceAutomation.Core;
using Microsoft.Playwright;
using System.Transactions;
namespace InsuranceAutomation.CLDC.Pages;
public sealed class RegressionTransactionPage
{
    private readonly BrowserSession _browser; private readonly UiActions _ui; private readonly RegressionTransactionLocators _locators;
    public RegressionTransactionPage(BrowserSession browser, UiActions ui) { _browser=browser; _ui=ui; _locators=new(browser.Page); }
    public async Task WaitForTransACTAsync() => await _locators.PageTitle.WaitForAsync(new() { State=WaitForSelectorState.Visible, Timeout=60000 });
    public async Task<string> CapturePolicyNumberAsync()
    {
        if (await _locators.PolicyNumber.CountAsync()==0) return string.Empty;
        return (await _locators.PolicyNumber.InputValueAsync().ConfigureAwait(false)).Trim();
    }
    public async Task SelectTransactionTypeAsync(string transactionType)
    {
        await WaitForTransACTAsync();
        await _ui.SmartSetAsync(_locators.TransactionType, transactionType, new ControlIntent("RegressionTransaction","TransactionType"));
        await _ui.PressAsync(_locators.TransactionType, "Tab", new ControlIntent("RegressionTransaction","TransactionType"));
        await _ui.ClickAsync(_locators.Go, new ControlIntent("RegressionTransaction","Go"));

    }
    public async Task ClickOkIfVisibleAsync()
    {
        if (await _locators.OK.CountAsync()>0 && await _locators.OK.IsVisibleAsync())
        {
            await _ui.ClickAsync(_locators.OK, new ControlIntent("RegressionTransaction","OK"));
        }
    }
    public async Task EnterEffectiveDateAndReasonAsync(string effectiveDate, string reason)
    {
        if (await _locators.EffectiveDate.CountAsync()>0 && !string.IsNullOrWhiteSpace(effectiveDate))
        {
            await _ui.PressSequentiallyAsync(_locators.EffectiveDate, effectiveDate, new ControlIntent("RegressionTransaction","EffectiveDate"));
            await _ui.PressAsync(_locators.EffectiveDate, "Tab", new ControlIntent("RegressionTransaction","EffectiveDate"));
        }
        if (await _locators.Reason.CountAsync()>0 && !string.IsNullOrWhiteSpace(reason))
        {
            await _ui.PressSequentiallyAsync(_locators.Reason, reason, new ControlIntent("RegressionTransaction","Reason"));
            await _ui.PressAsync(_locators.Reason, "Tab", new ControlIntent("RegressionTransaction","Reason"));
        }

        if (await _locators.LocationQuestion.CountAsync()>0 && await _locators.LocationQuestion.IsVisibleAsync())
        {
            await EnterLocationQuestionAsync("No");
        }

        if (await _locators.OK.CountAsync()>0) await _ui.ClickAsync(_locators.OK, new ControlIntent("RegressionTransaction","OK"));
        await _browser.Page.WaitForTimeoutAsync(750);
    }
    public async Task EnterLocationQuestionAsync(string value)
    {
        if (await _locators.LocationQuestion.CountAsync()>0)
        {
            await _ui.SmartSetAsync(_locators.LocationQuestion, value, new ControlIntent("RegressionTransaction","LocationQuestion"));
            await _ui.PressAsync(_locators.LocationQuestion, "Tab", new ControlIntent("RegressionTransaction","LocationQuestion"));
        }
    }
    public async Task EnterReasonAsOtherWithDetailAsync(string reasonDetail)
    {
        if (await _locators.Reason.CountAsync()>0)
        {
            await _ui.PressSequentiallyAsync(_locators.Reason, "Other", new ControlIntent("RegressionTransaction", "Reason"));
            await _ui.PressAsync(_locators.Reason, "Tab", new ControlIntent("RegressionTransaction", "Reason"));
        }
        await _browser.Page.WaitForTimeoutAsync(5000);
        if (await _locators.ReasonDetail.CountAsync()>0 && !string.IsNullOrWhiteSpace(reasonDetail))
        {
            try
            {
                await _locators.ReasonDetail.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });
            }
            catch (TimeoutException)
            {
                // Fall through to the fill call below, which will no-op if still not visible.
            }
            await _ui.FillAsync(_locators.ReasonDetail, reasonDetail, new ControlIntent("RegressionTransaction","ReasonDetail"));
            await _ui.PressAsync(_locators.ReasonDetail, "Tab", new ControlIntent("RegressionTransaction","ReasonDetail"));
        }
        if (await _locators.OK.CountAsync()>0) await _ui.ClickAsync(_locators.OK, new ControlIntent("RegressionTransaction","OK"));
        await _browser.Page.WaitForTimeoutAsync(5000);
    }
    public async Task StartAsync(RegressionTransactionProfile profile, string effectiveDate)
    {
        await WaitForTransACTAsync();
        await _ui.SmartSetAsync(_locators.TransactionType, profile.Transaction, new ControlIntent("RegressionTransaction","TransactionType"));
        await _ui.ClickAsync(_locators.Go, new ControlIntent("RegressionTransaction","Go"));
        if (await _locators.EffectiveDate.CountAsync()>0 && !string.IsNullOrWhiteSpace(profile.DateRule))
        {
            await _ui.FillAsync(_locators.EffectiveDate, RegressionDateRules.Resolve(effectiveDate, profile.DateRule), new ControlIntent("RegressionTransaction","EffectiveDate"));
            await _ui.PressAsync(_locators.EffectiveDate, "Tab", new ControlIntent("RegressionTransaction","EffectiveDate"));
        }
        if (await _locators.Reason.CountAsync()>0 && !string.IsNullOrWhiteSpace(profile.Reason))
        {
            await _ui.SmartSetAsync(_locators.Reason, profile.Reason, new ControlIntent("RegressionTransaction","Reason"));
            await _ui.PressAsync(_locators.Reason, "Tab", new ControlIntent("RegressionTransaction","Reason"));
        }
        if (await _locators.ReasonDetail.CountAsync()>0 && !string.IsNullOrWhiteSpace(profile.ReasonDetail))
            await _ui.FillAsync(_locators.ReasonDetail, profile.ReasonDetail, new ControlIntent("RegressionTransaction","ReasonDetail"));
        if (profile.RollToRenewal.HasValue && await _locators.RollToRenewal.CountAsync()>0)
            await _ui.SmartSetAsync(_locators.RollToRenewal, profile.RollToRenewal.Value ? "True" : "False", new ControlIntent("RegressionTransaction","RollToRenewal"));
        if (await _locators.OK.CountAsync()>0) await _ui.ClickAsync(_locators.OK, new ControlIntent("RegressionTransaction","OK"));
        await _browser.Page.WaitForTimeoutAsync(750);
    }
    public async Task OpenPolicyForEditAsync()
    {
        if (await _locators.EditPolicy.CountAsync()>0) await _ui.ClickAsync(_locators.EditPolicy, new ControlIntent("RegressionTransaction","EditPolicy"));
    }
    public async Task VerifyChargeAsync(string expected)
    {
        if (string.IsNullOrWhiteSpace(expected)) return;
        await Microsoft.Playwright.Assertions.Expect(_locators.TransactionGrid).ToContainTextAsync(expected, new() { Timeout=30000 });
    }
    public async Task VerifyPacketAsync(string transactionType, string packetType)
    {
        if (!string.IsNullOrWhiteSpace(transactionType)) await Microsoft.Playwright.Assertions.Expect(_locators.TransactionGrid).ToContainTextAsync(transactionType.Replace("*", string.Empty), new(){Timeout=30000});
        if (!string.IsNullOrWhiteSpace(packetType)) await Microsoft.Playwright.Assertions.Expect(_browser.Page.Locator("body")).ToContainTextAsync(packetType, new(){Timeout=30000});
    }
    public async Task VerifyRateTypeAsync(string rateType)
    {
        if (!string.IsNullOrWhiteSpace(rateType)) await Microsoft.Playwright.Assertions.Expect(_locators.TransactionGrid).ToContainTextAsync(rateType, new(){Timeout=30000});
    }
    public async Task VerifyOffsetAsync(string transactionType) => await Microsoft.Playwright.Assertions.Expect(_locators.TransactionGrid).ToContainTextAsync(transactionType, new(){Timeout=30000});
    public async Task VerifyDuplicateIdOutputAsync()
    {
        if (await _locators.ViewPolicyDetails.CountAsync()>0) await _ui.ClickAsync(_locators.ViewPolicyDetails, new ControlIntent("RegressionTransaction","ViewPolicyDetails"));
        await _locators.AttachmentsGrid.WaitForAsync(new(){State=WaitForSelectorState.Visible,Timeout=30000});
        await Microsoft.Playwright.Assertions.Expect(_locators.AttachmentsGrid).ToContainTextAsync("Duplicate", new(){Timeout=30000});
        if (await _locators.ReturnToTransACT.CountAsync()>0) await _ui.ClickAsync(_locators.ReturnToTransACT, new ControlIntent("RegressionTransaction","ReturnToTransACT"));
    }
}
