using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages;
using InsuranceAutomation.CLDC.Runtime;
namespace InsuranceAutomation.CLDC.Workflows;
public sealed class CommercialRegressionWorkflow
{
    private readonly ScenarioData _data; private readonly RunLogger _logger; private readonly BrowserSession _browser; private readonly UiActions _ui;
    private readonly RegressionDashboardPage _dashboard; private readonly RegressionTransactionPage _transactions;
    private readonly RegressionIssuancePage _issuance; private readonly RegressionPolicyChangePage _changes;
    public CommercialRegressionWorkflow(BrowserSession browser, UiActions ui, ScenarioData data, RunLogger logger)
    { _browser=browser; _ui=ui; _data=data; _logger=logger; _dashboard=new(browser,ui); _transactions=new(browser,ui); _issuance=new(browser,ui); _changes=new(browser,ui); }
    public RegressionLobProfile Profile => RegressionProfileCatalog.For(_data.Get("product_lob",_data.Get("productCode")));
    private string PolicyNumber => _data.Get("RegressionPolicyNumber",_data.Get("Policy#"));
    private string EffectiveDate => _data.Get("effective_date_43",_data.Get("effectivedate_51",_data.Get("effectivedate_86",_data.Get("effectivedate_109",_data.Get("effectivedate_71",_data.Get("effectivedate_98",_data.Get("effectivedate_105",_data.Get("effectivedate_106"))))))));
    public async Task IssueBaselinePolicyAsync()
    {
        var policy=await _issuance.CompleteIssuanceAndCapturePolicyNumberAsync();
        if(string.IsNullOrWhiteSpace(policy)) policy=await _transactions.CapturePolicyNumberAsync();
        if(string.IsNullOrWhiteSpace(policy)) throw new InvalidOperationException("New-business issuance completed but the policy number was not available.");
        _data.Set("RegressionPolicyNumber",policy); _data.Set("Policy#",policy); _logger.Info($"Regression baseline policy captured: {policy}");
    }
    public async Task SwitchToProductionAndReopenAsync()
    {
        //var application=new ApplicationPage(_browser,_ui);
        //await application.NavigateAsync(_data.GetRequired("url"));
        var login=new LoginPage(_browser,_ui);
        const string username="FFQA009";
        const string password="test";
        await login.EnterUserNameAsync(username); await login.EnterPasswordAsync(password); await login.ClickLoginAsync(); await login.WaitForLoginAsync("Absent");
        _logger.Info("Production underwriting role credentials were applied.");
    }
    public async Task SwitchToProductionAndReopenAsAdminAsync()
    {
        //var application=new ApplicationPage(_browser,_ui);
        //await application.NavigateAsync(_data.GetRequired("url"));
        var login=new LoginPage(_browser,_ui);
        const string username="admin";
        const string password="Sw1mUpTheCr33K";
        await login.EnterUserNameAsync(username); await login.EnterPasswordAsync(password); await login.ClickLoginAsync(); await login.WaitForLoginAsync("Absent");
        _logger.Info("Admin credentials were applied.");
        //await _dashboard.SearchAndOpenPolicyAsync(PolicyNumber);
    }
    public Task ClickReferAsync()=>_issuance.ClickReferAsync();
    public Task ClickReferButtonAsync()=>_issuance.ClickReferButtonAsync();
    public Task LaunchToChecklistAsync()=>_issuance.LaunchToChecklistAsync();
    public Task ClickPopupOkAsync()=>_issuance.ClickPopupOkAsync();
    public Task ClickOkIfVisibleAsync()=>_transactions.ClickOkIfVisibleAsync();
    public async Task CaptureEffectiveDateAsync()
    {
        await _issuance.NavigateToPolicyInfoAsync();
        var effectiveDate = await _issuance.CaptureEffectiveDateAsync();
        if (!string.IsNullOrWhiteSpace(effectiveDate))
        {
            _data.Set("RegressionEffectiveDate", effectiveDate);
            _logger.Info($"Regression effective date captured: {effectiveDate}");
        }
    }
    public Task ClickApproveAsync()=>_issuance.ClickApproveAsync();
    public async Task ClickViewPolicyAsync()
    {
        var policy = await _issuance.ClickViewPolicyAsync();
        if (!string.IsNullOrWhiteSpace(policy))
        {
            _data.Set("RegressionPolicyNumber",policy); _data.Set("Policy#",policy);
            _logger.Info($"Regression active policy captured: {policy}");
        }
    }
    public Task ClickCompleteIssuanceAsync()=>_issuance.ClickCompleteIssuanceAsync();
    public Task ClickCompleteApplicationAsync()=>_issuance.ClickCompleteApplicationAsync();
    public Task ClickLaunchInspireAsync()=>_issuance.ClickLaunchInspireAsync();
    public Task SignInToInspireAsync()=>_issuance.SignInToInspireAsync("underal", "qateam1");
    public Task<bool> IsConfirmBusinessOwnersHeaderVisibleAsync()=>_issuance.IsConfirmBusinessOwnersHeaderVisibleAsync();
    public Task SelectTransactionTypeAsync(string transactionType)=>_transactions.SelectTransactionTypeAsync(transactionType);
    public Task EnterReasonAsOtherWithDetailAsync(string reasonDetail)=>_transactions.EnterReasonAsOtherWithDetailAsync(reasonDetail);
    public Task VerifyChecklistAsync()=>_issuance.VerifyChecklistAsync(PolicyNumber);
    public async Task DuplicateIdAsync(string effectiveDateRule)
    {
        //if (!Profile.HasDuplicateId)
        //{
        //    _logger.Info("Duplicate ID is not applicable to this LOB.");
        //    return;
        //}

        var capturedEffectiveDate = _data.Get("RegressionEffectiveDate");
        var effectiveDate = !string.IsNullOrWhiteSpace(capturedEffectiveDate)
            ? RegressionDateRules.Resolve(capturedEffectiveDate, "+14d")
            : effectiveDateRule;

        await _transactions.EnterEffectiveDateAndReasonAsync(effectiveDate, "Duplicate ID");
        //await _transactions.OpenPolicyForEditAsync();
        await _changes.SelectDuplicateIdRisksAsync();

        //await _issuance.CompleteIssuanceAndCapturePolicyNumberAsync();
        //await _dashboard.SearchAndOpenPolicyAsync(PolicyNumber);
        //await _transactions.VerifyDuplicateIdOutputAsync();
    }
    public async Task AllOtherAsync(string effectiveDateRule)
    {
        if (!Profile.HasDuplicateId)
        {
            _logger.Info("All Other endorsement is not applicable to this LOB.");
            return;
        }

        // var today = DateTime.Now.ToString("M/d/yyyy");
        // effectiveDateRule now carries the full effective date directly from the Examples section.

        await _transactions.EnterEffectiveDateAndReasonAsync(effectiveDateRule, "All Other");
        await _changes.SelectDuplicateIdRisksAsync();
    }
    public Task IncreasePremiumAsync() => _changes.IncreasePremiumAsync();
    public Task DecreasePremiumAsync() => _changes.DecreasePremiumAsync();
    public Task AllOtherPremiumIncreaseAsync(string effectiveDateRule)
    {
        var capturedEffectiveDate = _data.Get("RegressionEffectiveDate");
        var effectiveDate = !string.IsNullOrWhiteSpace(capturedEffectiveDate)
            ? RegressionDateRules.Resolve(capturedEffectiveDate, "+1M")
            : effectiveDateRule;

        return _transactions.EnterEffectiveDateAndReasonAsync(effectiveDate, "All Other");

    }
    public Task AllOtherPremiumDecreaseAsync(string effectiveDateRule)
    {
        var capturedEffectiveDate = _data.Get("RegressionEffectiveDate");
        var effectiveDate = !string.IsNullOrWhiteSpace(capturedEffectiveDate)
            ? RegressionDateRules.Resolve(capturedEffectiveDate, "+2M")
            : effectiveDateRule;

        return _transactions.EnterEffectiveDateAndReasonAsync(effectiveDate, "All Other");
    }
    public Task EnterAdjustRenewalReasonAsFormsCorrectionAsync() =>
        _transactions.EnterEffectiveDateAndReasonAsync(string.Empty, "Forms Correction");
    public Task AllOtherPremiumDecreaseEndorseWithInformationAsync(string effectiveDateRule)
    {
        var capturedEffectiveDate = _data.Get("RegressionEffectiveDate");
        var effectiveDate = !string.IsNullOrWhiteSpace(capturedEffectiveDate)
            ? RegressionDateRules.Resolve(capturedEffectiveDate, "+3M")
            : effectiveDateRule;

        return _transactions.EnterEffectiveDateAndReasonAsync(effectiveDate, "Information");
    }
    public Task SelectEndorsementReasonAsAllOtherAsync(string effectiveDateRule)
    {
        var capturedEffectiveDate = _data.Get("RegressionEffectiveDate");
        var effectiveDate = !string.IsNullOrWhiteSpace(capturedEffectiveDate)
            ? RegressionDateRules.Resolve(capturedEffectiveDate, "+4M-1d")
            : effectiveDateRule;

        return _transactions.EnterEffectiveDateAndReasonAsync(effectiveDate, "All Other");
    }
    public Task NavigateToPolicyCoverageAndSetLimitsAsync() =>
        _changes.SetPolicyCoverageLimitsAsync("500000", "10000");
    public Task SelectCancelReasonAsInsuredsRequestAsync(string effectiveDateRule)
    {
        var capturedEffectiveDate = _data.Get("RegressionEffectiveDate");
        var effectiveDate = !string.IsNullOrWhiteSpace(capturedEffectiveDate)
            ? RegressionDateRules.Resolve(capturedEffectiveDate, "+7M")
            : effectiveDateRule;

        return _transactions.EnterEffectiveDateAndReasonAsync(effectiveDate, "Insured's request [No Insurable Interest]");
    }
    public Task EnterReinstateReasonAsync() =>
        _transactions.EnterReasonAsOtherWithDetailAsync("SmokeTest Reinstate");
    public Task SelectCancelReasonAsInsuredsRequestAllOtherAsync(string effectiveDateRule)
    {
        var capturedEffectiveDate = _data.Get("RegressionEffectiveDate");
        var effectiveDate = !string.IsNullOrWhiteSpace(capturedEffectiveDate)
            ? RegressionDateRules.Resolve(capturedEffectiveDate, "+7M+1d")
            : effectiveDateRule;

        return _transactions.EnterEffectiveDateAndReasonAsync(effectiveDate, "Insured's request [All Other]");
    }
    public Task SelectCancelReasonAsInsuredsRequestOOOAsync(string effectiveDateRule)
    {
        var capturedEffectiveDate = _data.Get("RegressionEffectiveDate");
        var effectiveDate = !string.IsNullOrWhiteSpace(capturedEffectiveDate)
            ? RegressionDateRules.Resolve(capturedEffectiveDate, "+6M")
            : effectiveDateRule;

        return _transactions.EnterEffectiveDateAndReasonAsync(effectiveDate, "Insured's request [No Insurable Interest]");
    }
    public Task SelectCancelReasonAsInsuredsRequestForPolicyExpirationAsync(string effectiveDateRule)
    {
        var capturedEffectiveDate = _data.Get("RegressionEffectiveDate");
        var effectiveDate = !string.IsNullOrWhiteSpace(capturedEffectiveDate)
            ? RegressionDateRules.Resolve(capturedEffectiveDate, "+2y")
            : effectiveDateRule;

        return _transactions.EnterEffectiveDateAndReasonAsync(effectiveDate, "Insured's request [No Insurable Interest]");
    }
    public async Task AllOtherMailingAddressChangeOnlyAsync(string effectiveDateRule)
    {
        var capturedEffectiveDate = _data.Get("RegressionEffectiveDate");
        var effectiveDate = !string.IsNullOrWhiteSpace(capturedEffectiveDate)
            ? RegressionDateRules.Resolve(capturedEffectiveDate, "+4M")
            : effectiveDateRule;

        await _transactions.EnterEffectiveDateAndReasonAsync(effectiveDate, "Mailing Address Change Only");

    }
    public async Task EnterMailingAddressAsync()
    {
        var page = new ClientSearchPage(_browser, _ui);
        await page.WaitForAddressAsync("Visible");
        await page.EnterAddressAsync("119 Broadway");
        await page.CheckIsClientDataCurrentAsync();
    }
    public async Task AdjustNewBusinessAndVerifyInspireAsync()
    { await ExecutePolicyTransactionAsync(Profile.AdjustNewBusiness); await _issuance.VerifyInspireAsync(PolicyNumber); }
    public Task PremiumIncreaseAsync()=>ExecutePolicyTransactionAsync(Profile.PremiumIncrease);
    public Task PremiumDecreaseAsync()=>ExecutePolicyTransactionAsync(Profile.PremiumDecrease);
    public Task InformationChangeAsync()=>ExecutePolicyTransactionAsync(Profile.InformationChange);
    public async Task MailingAddressChangeAsync()
    {
        var page = new ClientSearchPage(_browser, _ui);
        await page.WaitForWebsiteAddressAsync("Visible");
        await page.EnterWebsiteAddressAsync("HTTPS://WWW.INSUREDSITE");
    }
    public async Task RenewAsync(){await ExecutePolicyTransactionAsync(Profile.RenewManual);await _transactions.VerifyPacketAsync(Profile.RenewManual.PacketTransaction,Profile.RenewManual.PacketType);}
    public async Task AdjustRenewalAsync(){await ExecutePolicyTransactionAsync(Profile.AdjustRenewal);await _transactions.VerifyPacketAsync(Profile.AdjustRenewal.PacketTransaction,Profile.AdjustRenewal.PacketType);}
    public async Task OutOfSequenceEndorsementAsync(){await ExecutePolicyTransactionAsync(Profile.OutOfSequenceEndorsement);await _transactions.VerifyOffsetAsync("Renew");}
    public async Task CancelAndReinstateAsync(RegressionTransactionProfile cancel, RegressionTransactionProfile reinstate)
    { await ExecutePolicyTransactionAsync(cancel); await _transactions.VerifyRateTypeAsync(cancel.RateType); await ExecutePolicyTransactionAsync(reinstate); await _transactions.VerifyRateTypeAsync(reinstate.RateType); }
    public async Task LogoutIfRequiredAsync()
    {
        if(!Profile.LogoutAtEnd) return;
        var page=new PolicyWorkflowPage(_browser,_ui);
        await page.ClickLoggedInUserAsync(); await page.ClickLogoutAsync();
    }
    private async Task ExecutePolicyTransactionAsync(RegressionTransactionProfile profile)
    {
        await _transactions.StartAsync(profile,EffectiveDate); await _transactions.OpenPolicyForEditAsync(); await _changes.ApplyAsync(Profile.Lob,profile,_data);
        await _issuance.CompleteIssuanceAndCapturePolicyNumberAsync(); await _dashboard.SearchAndOpenPolicyAsync(PolicyNumber);
        await _transactions.VerifyChargeAsync(profile.ExpectedCharge);


    }
}
