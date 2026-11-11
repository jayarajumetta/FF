using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;
using InsuranceAutomation.CLDC.Runtime;
using Microsoft.Playwright;
namespace InsuranceAutomation.CLDC.Pages;
public sealed class RegressionPolicyChangePage
{
    private readonly BrowserSession _browser; private readonly UiActions _ui; private readonly RegressionPolicyChangeLocators _locators;
    public RegressionPolicyChangePage(BrowserSession browser, UiActions ui) { _browser=browser; _ui=ui; _locators=new(browser.Page); }
    private Task FillAsync(ILocator locator,string value,string name)=>_ui.SmartSetAsync(locator,value,new ControlIntent("RegressionPolicyChange",name));
    public async Task ApplyAsync(string lob, RegressionTransactionProfile profile, ScenarioData data)
    {
        switch(profile.ChangeType)
        {
            case "none": return;
            case "bapLiability":
                await _locators.PolicyCoverage.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 20000 });
                await _ui.ClickAsync(_locators.PolicyCoverage,new ControlIntent("RegressionPolicyChange","PolicyCoverage"));
                await FillAsync(_locators.BapLiabilityLimit,profile.PrimaryValue,"LiabilityLimit");
                await FillAsync(_locators.BapMedicalLimit,profile.SecondaryValue,"MedicalLimit"); return;
            case "glLimits":
                await _locators.PolicyCoverage.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 20000 });
                await _ui.ClickAsync(_locators.PolicyCoverage,new ControlIntent("RegressionPolicyChange","PolicyCoverage"));
                await FillAsync(_locators.GlOccurrenceLimit,profile.PrimaryValue,"OccurrenceLimit");
                await FillAsync(_locators.GlProductsAggregateLimit,profile.SecondaryValue,"ProductsAggregateLimit"); return;
            case "propertyPollutantLimit":
                await _ui.ClickAsync(_locators.Property,new ControlIntent("RegressionPolicyChange","Property"));
                await FillAsync(_locators.PollutantCleanupLimit,profile.PrimaryValue,"PollutantCleanupLimit"); return;
            case "inlandMarineSignsLimit":
                await _ui.ClickAsync(_locators.Risk,new ControlIntent("RegressionPolicyChange","Risk"));
                await _ui.ClickAsync(_locators.Detail.Nth(3),new ControlIntent("RegressionPolicyChange","FourthDetail"));
                await FillAsync(_locators.InlandMarineSignsLimit,profile.PrimaryValue,"SignsLimit");
                if(await _locators.OK.CountAsync()>0) await _ui.ClickAsync(_locators.OK,new ControlIntent("RegressionPolicyChange","OK")); return;
            case "umbrellaLimit":
                await _locators.PolicyCoverage.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 20000 });
                await _ui.ClickAsync(_locators.PolicyCoverage,new ControlIntent("RegressionPolicyChange","PolicyCoverage"));
                await FillAsync(_locators.UmbrellaLimit,profile.PrimaryValue,"UmbrellaLimit"); return;
            case "workersCompPayroll":
                await _ui.ClickAsync(_locators.Schedule,new ControlIntent("RegressionPolicyChange","Schedule"));
                await _ui.ClickAsync(_locators.Detail.First,new ControlIntent("RegressionPolicyChange","FirstDetail"));
                await FillAsync(_locators.WorkersCompPayroll,profile.PrimaryValue,"EstimatedPayroll");
                if(await _locators.PopupOK.CountAsync()>0) await _ui.ClickAsync(_locators.PopupOK,new ControlIntent("RegressionPolicyChange","PopupOK")); return;
            case "websiteAddress":
                var suffix=data.GenerateRandom("RegressionWebsiteSuffix","^[a-z]{2}$");
                await FillAsync(_locators.WebsiteAddress,profile.PrimaryValue.Replace("{random}",suffix,StringComparison.OrdinalIgnoreCase),"WebsiteAddress"); return;
            case "mailingAddress":
                var current=data.Get("address1_15",data.Get("address1_12","101 Regression Avenue"));
                var zip=data.Get("zipcode_16",data.Get("zipcode_11","85003"));
                await FillAsync(_locators.MailingAddress,current+" Suite R","MailingAddress");
                await FillAsync(_locators.MailingZip,zip,"MailingZip"); return;
            case "umbrellaContractorExposure":
                await _locators.PolicyCoverage.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 20000 });
                await _ui.ClickAsync(_locators.PolicyCoverage,new ControlIntent("RegressionPolicyChange","PolicyCoverage"));
                await FillAsync(_locators.ContractorExposure,profile.PrimaryValue,"ContractorExposure"); return;
            default: throw new InvalidOperationException($"Unsupported regression change type '{profile.ChangeType}' for {lob}.");
        }
    }
    public async Task SelectDuplicateIdRisksAsync()
    {
        await _locators.RiskSchedule.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 20000 });
        await _ui.ClickAsync(_locators.RiskSchedule,new ControlIntent("RegressionPolicyChange","RiskSchedule"));
        await _ui.ClickAsync(_locators.SelectAllRisks,new ControlIntent("RegressionPolicyChange","SelectAllRisks"));
    }
    public async Task IncreasePremiumAsync(string liabilityLimit = "300000", string medicalLimit = "10000")
    {
        await _locators.PolicyCoverage.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 20000 });
        await _ui.ClickAsync(_locators.PolicyCoverage,new ControlIntent("RegressionPolicyChange","PolicyCoverage"));
        await FillAsync(_locators.BapLiabilityLimit,liabilityLimit,"LiabilityLimit");
        await FillAsync(_locators.BapMedicalLimit,medicalLimit,"MedicalLimit");
    }
    public async Task DecreasePremiumAsync(string liabilityLimit = "100000", string medicalLimit = "5000")
    {
        await _locators.PolicyCoverage.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 20000 });
        await _ui.ClickAsync(_locators.PolicyCoverage,new ControlIntent("RegressionPolicyChange","PolicyCoverage"));
        await FillAsync(_locators.BapLiabilityLimit,liabilityLimit,"LiabilityLimit");
        await FillAsync(_locators.BapMedicalLimit,medicalLimit,"MedicalLimit");
    }
    public async Task SetPolicyCoverageLimitsAsync(string liabilityLimit = "500000", string medicalLimit = "10000")
    {
        await _locators.PolicyCoverage.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 20000 });
        await _ui.ClickAsync(_locators.PolicyCoverage,new ControlIntent("RegressionPolicyChange","PolicyCoverage"));
        await FillAsync(_locators.BapLiabilityLimit,liabilityLimit,"LiabilityLimit");
        await FillAsync(_locators.BapMedicalLimit,medicalLimit,"MedicalLimit");
    }
}
