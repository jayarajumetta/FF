using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPPricingCAMARiskCategories
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPPricingCAMARiskCategories(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator CatastrophePotential => EQBOPPricingCAMARiskCategoriesLocators.CatastrophePotential(_page);

    public Task PressCatastrophePotentialAsync(string key) => CatastrophePotential.PressAsync(key);

    public Task DoubleClickCatastrophePotentialAsync() => CatastrophePotential.DblClickAsync();

    public Task SetCatastrophePotentialAsync(string value) =>
        CatastrophePotential.SelectOptionAsync(_data.Resolve(value));

    private ILocator LossRatio => EQBOPPricingCAMARiskCategoriesLocators.LossRatio(_page);

    public Task PressLossRatioAsync(string key) => LossRatio.PressAsync(key);

    public Task DoubleClickLossRatioAsync() => LossRatio.DblClickAsync();

    public Task SetLossRatioAsync(string value) =>
        LossRatio.SelectOptionAsync(_data.Resolve(value));

    private ILocator LengthOfEmployment => EQBOPPricingCAMARiskCategoriesLocators.LengthOfEmployment(_page);

    public Task PressLengthOfEmploymentAsync(string key) => LengthOfEmployment.PressAsync(key);

    public Task DoubleClickLengthOfEmploymentAsync() => LengthOfEmployment.DblClickAsync();

    public Task SetLengthOfEmploymentAsync(string value) =>
        LengthOfEmployment.SelectOptionAsync(_data.Resolve(value));

    private ILocator MemberOfATradeAssociation => EQBOPPricingCAMARiskCategoriesLocators.MemberOfATradeAssociation(_page);

    public Task PressMemberOfATradeAssociationAsync(string key) => MemberOfATradeAssociation.PressAsync(key);

    public Task DoubleClickMemberOfATradeAssociationAsync() => MemberOfATradeAssociation.DblClickAsync();

    public Task SetMemberOfATradeAssociationAsync(string value) =>
        MemberOfATradeAssociation.SelectOptionAsync(_data.Resolve(value));

    private ILocator RiskManagementProgram => EQBOPPricingCAMARiskCategoriesLocators.RiskManagementProgram(_page);

    public Task PressRiskManagementProgramAsync(string key) => RiskManagementProgram.PressAsync(key);

    public Task DoubleClickRiskManagementProgramAsync() => RiskManagementProgram.DblClickAsync();

    public Task SetRiskManagementProgramAsync(string value) =>
        RiskManagementProgram.SelectOptionAsync(_data.Resolve(value));

    private ILocator YearsInBusiness => EQBOPPricingCAMARiskCategoriesLocators.YearsInBusiness(_page);

    public Task PressYearsInBusinessAsync(string key) => YearsInBusiness.PressAsync(key);

    public Task DoubleClickYearsInBusinessAsync() => YearsInBusiness.DblClickAsync();

    public Task SetYearsInBusinessAsync(string value) =>
        YearsInBusiness.SelectOptionAsync(_data.Resolve(value));

    private ILocator UseOfSubcontractors => EQBOPPricingCAMARiskCategoriesLocators.UseOfSubcontractors(_page);

    public Task PressUseOfSubcontractorsAsync(string key) => UseOfSubcontractors.PressAsync(key);

    public Task DoubleClickUseOfSubcontractorsAsync() => UseOfSubcontractors.DblClickAsync();

    public Task SetUseOfSubcontractorsAsync(string value) =>
        UseOfSubcontractors.SelectOptionAsync(_data.Resolve(value));

}
