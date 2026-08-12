using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class NewEQMultipleDriverAssignment
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public NewEQMultipleDriverAssignment(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator CONTINUE => NewEQMultipleDriverAssignmentLocators.CONTINUE(_page);

    public Task PressCONTINUEAsync(string key) => CONTINUE.PressAsync(key);

    public Task DoubleClickCONTINUEAsync() => CONTINUE.DblClickAsync();

    public Task ClickCONTINUEAsync() => CONTINUE.ClickAsync();

    public Task VerifyCONTINUEAsync(string expected) =>
        Expect(CONTINUE).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForCONTINUEAsync() =>
        CONTINUE.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Driver1Vehicle => NewEQMultipleDriverAssignmentLocators.Driver1Vehicle(_page);

    public Task PressDriver1VehicleAsync(string key) => Driver1Vehicle.PressAsync(key);

    public Task DoubleClickDriver1VehicleAsync() => Driver1Vehicle.DblClickAsync();

    public Task SetDriver1VehicleAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Driver1Vehicle, _data.Resolve(value));

    public Task TypeDriver1VehicleAsync(string value, float delayMs = 40) =>
        Driver1Vehicle.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Driver1PrincipalOccasional => NewEQMultipleDriverAssignmentLocators.Driver1PrincipalOccasional(_page);

    public Task PressDriver1PrincipalOccasionalAsync(string key) => Driver1PrincipalOccasional.PressAsync(key);

    public Task DoubleClickDriver1PrincipalOccasionalAsync() => Driver1PrincipalOccasional.DblClickAsync();

    public Task SetDriver1PrincipalOccasionalAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Driver1PrincipalOccasional, _data.Resolve(value));

    public Task TypeDriver1PrincipalOccasionalAsync(string value, float delayMs = 40) =>
        Driver1PrincipalOccasional.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Driver2Vehicle => NewEQMultipleDriverAssignmentLocators.Driver2Vehicle(_page);

    public Task PressDriver2VehicleAsync(string key) => Driver2Vehicle.PressAsync(key);

    public Task DoubleClickDriver2VehicleAsync() => Driver2Vehicle.DblClickAsync();

    public Task SetDriver2VehicleAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Driver2Vehicle, _data.Resolve(value));

    public Task TypeDriver2VehicleAsync(string value, float delayMs = 40) =>
        Driver2Vehicle.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Driver2PrincipalOccasional => NewEQMultipleDriverAssignmentLocators.Driver2PrincipalOccasional(_page);

    public Task PressDriver2PrincipalOccasionalAsync(string key) => Driver2PrincipalOccasional.PressAsync(key);

    public Task DoubleClickDriver2PrincipalOccasionalAsync() => Driver2PrincipalOccasional.DblClickAsync();

    public Task SetDriver2PrincipalOccasionalAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Driver2PrincipalOccasional, _data.Resolve(value));

    public Task TypeDriver2PrincipalOccasionalAsync(string value, float delayMs = 40) =>
        Driver2PrincipalOccasional.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Driver3Vehicle => NewEQMultipleDriverAssignmentLocators.Driver3Vehicle(_page);

    public Task PressDriver3VehicleAsync(string key) => Driver3Vehicle.PressAsync(key);

    public Task DoubleClickDriver3VehicleAsync() => Driver3Vehicle.DblClickAsync();

    public Task SetDriver3VehicleAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Driver3Vehicle, _data.Resolve(value));

    public Task TypeDriver3VehicleAsync(string value, float delayMs = 40) =>
        Driver3Vehicle.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Driver3PrincipalOccasional => NewEQMultipleDriverAssignmentLocators.Driver3PrincipalOccasional(_page);

    public Task PressDriver3PrincipalOccasionalAsync(string key) => Driver3PrincipalOccasional.PressAsync(key);

    public Task DoubleClickDriver3PrincipalOccasionalAsync() => Driver3PrincipalOccasional.DblClickAsync();

    public Task SetDriver3PrincipalOccasionalAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Driver3PrincipalOccasional, _data.Resolve(value));

    public Task TypeDriver3PrincipalOccasionalAsync(string value, float delayMs = 40) =>
        Driver3PrincipalOccasional.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Driver4Vehicle => NewEQMultipleDriverAssignmentLocators.Driver4Vehicle(_page);

    public Task PressDriver4VehicleAsync(string key) => Driver4Vehicle.PressAsync(key);

    public Task DoubleClickDriver4VehicleAsync() => Driver4Vehicle.DblClickAsync();

    public Task SetDriver4VehicleAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Driver4Vehicle, _data.Resolve(value));

    public Task TypeDriver4VehicleAsync(string value, float delayMs = 40) =>
        Driver4Vehicle.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Driver4PrincipalOccasional => NewEQMultipleDriverAssignmentLocators.Driver4PrincipalOccasional(_page);

    public Task PressDriver4PrincipalOccasionalAsync(string key) => Driver4PrincipalOccasional.PressAsync(key);

    public Task DoubleClickDriver4PrincipalOccasionalAsync() => Driver4PrincipalOccasional.DblClickAsync();

    public Task SetDriver4PrincipalOccasionalAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Driver4PrincipalOccasional, _data.Resolve(value));

    public Task TypeDriver4PrincipalOccasionalAsync(string value, float delayMs = 40) =>
        Driver4PrincipalOccasional.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Driver5Vehicle => NewEQMultipleDriverAssignmentLocators.Driver5Vehicle(_page);

    public Task PressDriver5VehicleAsync(string key) => Driver5Vehicle.PressAsync(key);

    public Task DoubleClickDriver5VehicleAsync() => Driver5Vehicle.DblClickAsync();

    public Task SetDriver5VehicleAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Driver5Vehicle, _data.Resolve(value));

    public Task TypeDriver5VehicleAsync(string value, float delayMs = 40) =>
        Driver5Vehicle.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Driver5PrincipalOccasional => NewEQMultipleDriverAssignmentLocators.Driver5PrincipalOccasional(_page);

    public Task PressDriver5PrincipalOccasionalAsync(string key) => Driver5PrincipalOccasional.PressAsync(key);

    public Task DoubleClickDriver5PrincipalOccasionalAsync() => Driver5PrincipalOccasional.DblClickAsync();

    public Task SetDriver5PrincipalOccasionalAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Driver5PrincipalOccasional, _data.Resolve(value));

    public Task TypeDriver5PrincipalOccasionalAsync(string value, float delayMs = 40) =>
        Driver5PrincipalOccasional.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Next => NewEQMultipleDriverAssignmentLocators.Next(_page);

    public Task PressNextAsync(string key) => Next.PressAsync(key);

    public Task DoubleClickNextAsync() => Next.DblClickAsync();

    public Task ClickNextAsync() => Next.ClickAsync();

    public Task ClickDriver1PrincipalOccasionalAsync() => Driver1PrincipalOccasional.ClickAsync();

    public Task ClickDriver1VehicleAsync() => Driver1Vehicle.ClickAsync();
}
