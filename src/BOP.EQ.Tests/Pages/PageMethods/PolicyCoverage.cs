using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class PolicyCoverage
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public PolicyCoverage(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator RootElement => PolicyCoverageLocators.PolicyCoverage(_page);

    public Task PressPolicyCoverageAsync(string key) => RootElement.PressAsync(key);

    public Task DoubleClickPolicyCoverageAsync() => RootElement.DblClickAsync();

    public Task WaitForPolicyCoverageAsync() =>
        RootElement.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator LiabilityPerOccurenceLimit => PolicyCoverageLocators.LiabilityPerOccurenceLimit(_page);

    public Task PressLiabilityPerOccurenceLimitAsync(string key) => LiabilityPerOccurenceLimit.PressAsync(key);

    public Task DoubleClickLiabilityPerOccurenceLimitAsync() => LiabilityPerOccurenceLimit.DblClickAsync();

    public Task SetLiabilityPerOccurenceLimitAsync(string value) =>
        UiActions.ApplyInputAsync(_page, LiabilityPerOccurenceLimit, _data.Resolve(value));

    public Task TypeLiabilityPerOccurenceLimitAsync(string value, float delayMs = 40) =>
        LiabilityPerOccurenceLimit.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator ProductsCompletedAggregateLimit => PolicyCoverageLocators.ProductsCompletedAggregateLimit(_page);

    public Task PressProductsCompletedAggregateLimitAsync(string key) => ProductsCompletedAggregateLimit.PressAsync(key);

    public Task DoubleClickProductsCompletedAggregateLimitAsync() => ProductsCompletedAggregateLimit.DblClickAsync();

    public Task WaitForProductsCompletedAggregateLimitAsync() =>
        ProductsCompletedAggregateLimit.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator GeneralAggregateLimit => PolicyCoverageLocators.GeneralAggregateLimit(_page);

    public Task PressGeneralAggregateLimitAsync(string key) => GeneralAggregateLimit.PressAsync(key);

    public Task DoubleClickGeneralAggregateLimitAsync() => GeneralAggregateLimit.DblClickAsync();

    public Task WaitForGeneralAggregateLimitAsync() =>
        GeneralAggregateLimit.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator NumberOfEmployees => PolicyCoverageLocators.NumberOfEmployees(_page);

    public Task PressNumberOfEmployeesAsync(string key) => NumberOfEmployees.PressAsync(key);

    public Task DoubleClickNumberOfEmployeesAsync() => NumberOfEmployees.DblClickAsync();

    public Task SetNumberOfEmployeesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NumberOfEmployees, _data.Resolve(value));

    public Task TypeNumberOfEmployeesAsync(string value, float delayMs = 40) =>
        NumberOfEmployees.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyNumberOfEmployeesAsync(string expected) =>
        Expect(NumberOfEmployees).ToContainTextAsync(_data.Resolve(expected));

    private ILocator NumberOfPartTimeEmployees => PolicyCoverageLocators.NumberOfPartTimeEmployees(_page);

    public Task PressNumberOfPartTimeEmployeesAsync(string key) => NumberOfPartTimeEmployees.PressAsync(key);

    public Task DoubleClickNumberOfPartTimeEmployeesAsync() => NumberOfPartTimeEmployees.DblClickAsync();

    public Task SetNumberOfPartTimeEmployeesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NumberOfPartTimeEmployees, _data.Resolve(value));

    public Task TypeNumberOfPartTimeEmployeesAsync(string value, float delayMs = 40) =>
        NumberOfPartTimeEmployees.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyNumberOfPartTimeEmployeesAsync(string expected) =>
        Expect(NumberOfPartTimeEmployees).ToContainTextAsync(_data.Resolve(expected));

    private ILocator NumberOfSeasonalEmployees => PolicyCoverageLocators.NumberOfSeasonalEmployees(_page);

    public Task PressNumberOfSeasonalEmployeesAsync(string key) => NumberOfSeasonalEmployees.PressAsync(key);

    public Task DoubleClickNumberOfSeasonalEmployeesAsync() => NumberOfSeasonalEmployees.DblClickAsync();

    public Task SetNumberOfSeasonalEmployeesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NumberOfSeasonalEmployees, _data.Resolve(value));

    public Task TypeNumberOfSeasonalEmployeesAsync(string value, float delayMs = 40) =>
        NumberOfSeasonalEmployees.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyNumberOfSeasonalEmployeesAsync(string expected) =>
        Expect(NumberOfSeasonalEmployees).ToContainTextAsync(_data.Resolve(expected));

    private ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations => PolicyCoverageLocators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations(_page);

    public Task PressIsTheInsuredEngagedInAnySnowOrIceRemovalOperationsAsync(string key) => IsTheInsuredEngagedInAnySnowOrIceRemovalOperations.PressAsync(key);

    public Task DoubleClickIsTheInsuredEngagedInAnySnowOrIceRemovalOperationsAsync() => IsTheInsuredEngagedInAnySnowOrIceRemovalOperations.DblClickAsync();

    public Task SetIsTheInsuredEngagedInAnySnowOrIceRemovalOperationsAsync(string value) =>
        UiActions.ApplyInputAsync(_page, IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, _data.Resolve(value));

    public Task TypeIsTheInsuredEngagedInAnySnowOrIceRemovalOperationsAsync(string value, float delayMs = 40) =>
        IsTheInsuredEngagedInAnySnowOrIceRemovalOperations.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator DoesBuildingSInMarylandContain1OrMoreResidentialRentalUnits => PolicyCoverageLocators.DoesBuildingSInMarylandContain1OrMoreResidentialRentalUnits(_page);

    public Task PressDoesBuildingSInMarylandContain1OrMoreResidentialRentalUnitsAsync(string key) => DoesBuildingSInMarylandContain1OrMoreResidentialRentalUnits.PressAsync(key);

    public Task DoubleClickDoesBuildingSInMarylandContain1OrMoreResidentialRentalUnitsAsync() => DoesBuildingSInMarylandContain1OrMoreResidentialRentalUnits.DblClickAsync();

    public Task SetDoesBuildingSInMarylandContain1OrMoreResidentialRentalUnitsAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DoesBuildingSInMarylandContain1OrMoreResidentialRentalUnits, _data.Resolve(value));

    public Task TypeDoesBuildingSInMarylandContain1OrMoreResidentialRentalUnitsAsync(string value, float delayMs = 40) =>
        DoesBuildingSInMarylandContain1OrMoreResidentialRentalUnits.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyDoesBuildingSInMarylandContain1OrMoreResidentialRentalUnitsAsync(string expected) =>
        Expect(DoesBuildingSInMarylandContain1OrMoreResidentialRentalUnits).ToContainTextAsync(_data.Resolve(expected));

    private ILocator LPGTransportQuestion => PolicyCoverageLocators.LPGTransportQuestion(_page);

    public Task PressLPGTransportQuestionAsync(string key) => LPGTransportQuestion.PressAsync(key);

    public Task DoubleClickLPGTransportQuestionAsync() => LPGTransportQuestion.DblClickAsync();

    public Task SetLPGTransportQuestionAsync(string value) =>
        UiActions.ApplyInputAsync(_page, LPGTransportQuestion, _data.Resolve(value));

    public Task TypeLPGTransportQuestionAsync(string value, float delayMs = 40) =>
        LPGTransportQuestion.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyLPGTransportQuestionAsync(string expected) =>
        Expect(LPGTransportQuestion).ToContainTextAsync(_data.Resolve(expected));

}
