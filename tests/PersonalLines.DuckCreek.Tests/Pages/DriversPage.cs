using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class DriversPage
{
    private readonly DriversLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public DriversPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new DriversLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete driver information
    public async Task CompleteDriverInformationAsync()
    {
        // EQDriverInformation_5c96e7Page.DriverInformationEnterDriverDetails_0035_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.IneligibleQuote))
        {
        await _ui.VerifyAsync(_locators.IneligibleQuote, _data.Resolve("Visible"), "");
        }
        await _ui.ClickAsync(_locators.CLOSEQUOTE);
    }

    // Business step: I complete driver information for existing client 1
    public async Task CompleteDriverInformationForExistingClient1Async()
    {
        // EQDriverInformation_5c96e7Page.DriverInformationEnterDriverDetails_0048_8f9ff6Async
        await _ui.ClickAsync(_locators.ExistingClient1);
        await _ui.ClickAsync(_locators.DriverInformationNext);
        await _ui.PressAsync(_locators.DriverInformationNext, "Click");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0049_8f9ff6Async
        _data.Set("MT National Guard", _data.Get("MT National Guard"));
    }

    // Business step: I complete driver Assignment
    public async Task CompleteDriverAssignmentAsync()
    {
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment1_0090_8f9ff6Async
        if (_data.Condition("'Driver 1 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver1Vehicle);
        }
        if (_data.Condition("'Driver 1 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver1PrincipalOccasional);
        }
        if (_data.Condition("'Driver 2 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver2Vehicle);
        await _ui.PressAsync(_locators.Driver2Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver2Vehicle, "Click");
        }
        if (_data.Condition("'Driver 2 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver2PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver2PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver2PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 3 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver3Vehicle);
        await _ui.PressAsync(_locators.Driver3Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver3Vehicle, "Click");
        }
        if (_data.Condition("'Driver 3 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver3PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver3PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver3PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 4 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver4Vehicle);
        await _ui.PressAsync(_locators.Driver4Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver4Vehicle, "Click");
        }
        if (_data.Condition("'Driver 4 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver4PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver4PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver4PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 5 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver5Vehicle);
        await _ui.PressAsync(_locators.Driver5Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver5Vehicle, "Click");
        }
        if (_data.Condition("'Driver 5 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver5PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver5PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver5PrincipalOccasional, "Click");
        }
        await _ui.ClickAsync(_locators.MultipleDriverAssignmentNext);
    }

    // Business step: I complete multiple Driver Assignment
    public async Task CompleteMultipleDriverAssignmentAsync()
    {
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment_0091_8f9ff6Async
        if (_data.Condition("EQ || Driver Assignment Continue > Condition"))
        {
        await _ui.WaitAsync(_locators.CONTINUE, "Exists");
        }
        await _ui.VerifyAsync(_locators.CONTINUE, _data.Resolve("Exists"), "");
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment_0092_8f9ff6Async
        if (_data.Condition("EQ || Driver Assignment Continue > Then"))
        {
        await _ui.ClickAsync(_locators.CONTINUE);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0093_8f9ff6Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete driver information
    public async Task CompleteDriverInformationAsync2()
    {
        // EQDriverInformation_5c96e7Page.DriverInformationEnterDriverDetails_0035_8f5301Async
        if (await _ui.ExistsAsync(_locators.IneligibleQuote))
        {
        await _ui.VerifyAsync(_locators.IneligibleQuote, _data.Resolve("Visible"), "");
        }
        await _ui.ClickAsync(_locators.CLOSEQUOTE);
    }

    // Business step: I complete driver information for existing client 1
    public async Task CompleteDriverInformationForExistingClient1Async2()
    {
        // EQDriverInformation_5c96e7Page.DriverInformationEnterDriverDetails_0048_8f5301Async
        await _ui.ClickAsync(_locators.ExistingClient1);
        await _ui.ClickAsync(_locators.DriverInformationNext);
        await _ui.PressAsync(_locators.DriverInformationNext, "Click");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0049_8f5301Async
        _data.Set("MT National Guard", _data.Get("MT National Guard"));
    }

    // Business step: I complete driver Assignment
    public async Task CompleteDriverAssignmentAsync2()
    {
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment1_0102_8f5301Async
        if (_data.Condition("'Driver 1 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver1Vehicle);
        }
        if (_data.Condition("'Driver 1 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver1PrincipalOccasional);
        }
        if (_data.Condition("'Driver 2 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver2Vehicle);
        await _ui.PressAsync(_locators.Driver2Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver2Vehicle, "Click");
        }
        if (_data.Condition("'Driver 2 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver2PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver2PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver2PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 3 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver3Vehicle);
        await _ui.PressAsync(_locators.Driver3Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver3Vehicle, "Click");
        }
        if (_data.Condition("'Driver 3 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver3PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver3PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver3PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 4 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver4Vehicle);
        await _ui.PressAsync(_locators.Driver4Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver4Vehicle, "Click");
        }
        if (_data.Condition("'Driver 4 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver4PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver4PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver4PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 5 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver5Vehicle);
        await _ui.PressAsync(_locators.Driver5Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver5Vehicle, "Click");
        }
        if (_data.Condition("'Driver 5 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver5PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver5PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver5PrincipalOccasional, "Click");
        }
        await _ui.ClickAsync(_locators.MultipleDriverAssignmentNext);
    }

    // Business step: I complete multiple Driver Assignment
    public async Task CompleteMultipleDriverAssignmentAsync2()
    {
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment_0103_8f5301Async
        if (_data.Condition("EQ || Driver Assignment Continue > Condition"))
        {
        await _ui.WaitAsync(_locators.CONTINUE, "Exists");
        }
        await _ui.VerifyAsync(_locators.CONTINUE, _data.Resolve("Exists"), "");
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment_0104_8f5301Async
        if (_data.Condition("EQ || Driver Assignment Continue > Then"))
        {
        await _ui.ClickAsync(_locators.CONTINUE);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0105_8f5301Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete driver information
    public async Task CompleteDriverInformationAsync3()
    {
        // EQDriverInformation_5c96e7Page.DriverInformationEnterDriverDetails_0035_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.IneligibleQuote))
        {
        await _ui.VerifyAsync(_locators.IneligibleQuote, _data.Resolve("Visible"), "");
        }
        await _ui.ClickAsync(_locators.CLOSEQUOTE);
    }

    // Business step: I complete driver information for existing client 1
    public async Task CompleteDriverInformationForExistingClient1Async3()
    {
        // EQDriverInformation_5c96e7Page.DriverInformationEnterDriverDetails_0048_e2e0d7Async
        await _ui.ClickAsync(_locators.ExistingClient1);
        await _ui.ClickAsync(_locators.DriverInformationNext);
        await _ui.PressAsync(_locators.DriverInformationNext, "Click");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0049_e2e0d7Async
        _data.Set("MT National Guard", _data.Get("MT National Guard"));
    }

    // Business step: I complete driver Assignment
    public async Task CompleteDriverAssignmentAsync3()
    {
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment1_0099_e2e0d7Async
        if (_data.Condition("'Driver 1 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver1Vehicle);
        }
        if (_data.Condition("'Driver 1 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver1PrincipalOccasional);
        }
        if (_data.Condition("'Driver 2 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver2Vehicle);
        await _ui.PressAsync(_locators.Driver2Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver2Vehicle, "Click");
        }
        if (_data.Condition("'Driver 2 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver2PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver2PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver2PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 3 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver3Vehicle);
        await _ui.PressAsync(_locators.Driver3Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver3Vehicle, "Click");
        }
        if (_data.Condition("'Driver 3 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver3PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver3PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver3PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 4 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver4Vehicle);
        await _ui.PressAsync(_locators.Driver4Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver4Vehicle, "Click");
        }
        if (_data.Condition("'Driver 4 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver4PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver4PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver4PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 5 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver5Vehicle);
        await _ui.PressAsync(_locators.Driver5Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver5Vehicle, "Click");
        }
        if (_data.Condition("'Driver 5 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver5PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver5PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver5PrincipalOccasional, "Click");
        }
        await _ui.ClickAsync(_locators.MultipleDriverAssignmentNext);
    }

    // Business step: I complete multiple Driver Assignment
    public async Task CompleteMultipleDriverAssignmentAsync3()
    {
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment_0100_e2e0d7Async
        if (_data.Condition("EQ || Driver Assignment Continue > Condition"))
        {
        await _ui.WaitAsync(_locators.CONTINUE, "Exists");
        }
        await _ui.VerifyAsync(_locators.CONTINUE, _data.Resolve("Exists"), "");
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment_0101_e2e0d7Async
        if (_data.Condition("EQ || Driver Assignment Continue > Then"))
        {
        await _ui.ClickAsync(_locators.CONTINUE);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0102_e2e0d7Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete driver information
    public async Task CompleteDriverInformationAsync4()
    {
        // EQDriverInformation_5c96e7Page.DriverInformationEnterDriverDetails_0035_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.IneligibleQuote))
        {
        await _ui.VerifyAsync(_locators.IneligibleQuote, _data.Resolve("Visible"), "");
        }
        await _ui.ClickAsync(_locators.CLOSEQUOTE);
    }

    // Business step: I complete driver information for existing client 1
    public async Task CompleteDriverInformationForExistingClient1Async4()
    {
        // EQDriverInformation_5c96e7Page.DriverInformationEnterDriverDetails_0048_bafd4aAsync
        await _ui.ClickAsync(_locators.ExistingClient1);
        await _ui.ClickAsync(_locators.DriverInformationNext);
        await _ui.PressAsync(_locators.DriverInformationNext, "Click");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0049_bafd4aAsync
        _data.Set("MT National Guard", _data.Get("MT National Guard"));
    }

    // Business step: I complete driver Assignment
    public async Task CompleteDriverAssignmentAsync4()
    {
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment1_0099_bafd4aAsync
        if (_data.Condition("'Driver 1 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver1Vehicle);
        }
        if (_data.Condition("'Driver 1 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver1PrincipalOccasional);
        }
        if (_data.Condition("'Driver 2 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver2Vehicle);
        await _ui.PressAsync(_locators.Driver2Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver2Vehicle, "Click");
        }
        if (_data.Condition("'Driver 2 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver2PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver2PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver2PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 3 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver3Vehicle);
        await _ui.PressAsync(_locators.Driver3Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver3Vehicle, "Click");
        }
        if (_data.Condition("'Driver 3 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver3PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver3PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver3PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 4 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver4Vehicle);
        await _ui.PressAsync(_locators.Driver4Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver4Vehicle, "Click");
        }
        if (_data.Condition("'Driver 4 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver4PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver4PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver4PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 5 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver5Vehicle);
        await _ui.PressAsync(_locators.Driver5Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver5Vehicle, "Click");
        }
        if (_data.Condition("'Driver 5 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver5PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver5PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver5PrincipalOccasional, "Click");
        }
        await _ui.ClickAsync(_locators.MultipleDriverAssignmentNext);
    }

    // Business step: I complete multiple Driver Assignment
    public async Task CompleteMultipleDriverAssignmentAsync4()
    {
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment_0100_bafd4aAsync
        if (_data.Condition("EQ || Driver Assignment Continue > Condition"))
        {
        await _ui.WaitAsync(_locators.CONTINUE, "Exists");
        }
        await _ui.VerifyAsync(_locators.CONTINUE, _data.Resolve("Exists"), "");
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment_0101_bafd4aAsync
        if (_data.Condition("EQ || Driver Assignment Continue > Then"))
        {
        await _ui.ClickAsync(_locators.CONTINUE);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0102_bafd4aAsync
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete driver information
    public async Task CompleteDriverInformationAsync5()
    {
        // EQDriverInformation_5c96e7Page.DriverInformationEnterDriverDetails_0035_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.IneligibleQuote))
        {
        await _ui.VerifyAsync(_locators.IneligibleQuote, _data.Resolve("Visible"), "");
        }
        await _ui.ClickAsync(_locators.CLOSEQUOTE);
    }

    // Business step: I complete driver information for existing client 1
    public async Task CompleteDriverInformationForExistingClient1Async5()
    {
        // EQDriverInformation_5c96e7Page.DriverInformationEnterDriverDetails_0048_8f4c8fAsync
        await _ui.ClickAsync(_locators.ExistingClient1);
        await _ui.ClickAsync(_locators.DriverInformationNext);
        await _ui.PressAsync(_locators.DriverInformationNext, "Click");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0049_8f4c8fAsync
        _data.Set("MT National Guard", _data.Get("MT National Guard"));
    }

    // Business step: I complete driver Assignment
    public async Task CompleteDriverAssignmentAsync5()
    {
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment1_0102_8f4c8fAsync
        if (_data.Condition("'Driver 1 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver1Vehicle);
        }
        if (_data.Condition("'Driver 1 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver1PrincipalOccasional);
        }
        if (_data.Condition("'Driver 2 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver2Vehicle);
        await _ui.PressAsync(_locators.Driver2Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver2Vehicle, "Click");
        }
        if (_data.Condition("'Driver 2 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver2PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver2PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver2PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 3 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver3Vehicle);
        await _ui.PressAsync(_locators.Driver3Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver3Vehicle, "Click");
        }
        if (_data.Condition("'Driver 3 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver3PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver3PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver3PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 4 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver4Vehicle);
        await _ui.PressAsync(_locators.Driver4Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver4Vehicle, "Click");
        }
        if (_data.Condition("'Driver 4 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver4PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver4PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver4PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 5 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver5Vehicle);
        await _ui.PressAsync(_locators.Driver5Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver5Vehicle, "Click");
        }
        if (_data.Condition("'Driver 5 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver5PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver5PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver5PrincipalOccasional, "Click");
        }
        await _ui.ClickAsync(_locators.MultipleDriverAssignmentNext);
    }

    // Business step: I complete multiple Driver Assignment
    public async Task CompleteMultipleDriverAssignmentAsync5()
    {
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment_0103_8f4c8fAsync
        if (_data.Condition("EQ || Driver Assignment Continue > Condition"))
        {
        await _ui.WaitAsync(_locators.CONTINUE, "Exists");
        }
        await _ui.VerifyAsync(_locators.CONTINUE, _data.Resolve("Exists"), "");
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment_0104_8f4c8fAsync
        if (_data.Condition("EQ || Driver Assignment Continue > Then"))
        {
        await _ui.ClickAsync(_locators.CONTINUE);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0105_8f4c8fAsync
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

    // Business step: I complete driver information
    public async Task CompleteDriverInformationAsync6()
    {
        // EQDriverInformation_5c96e7Page.DriverInformationEnterDriverDetails_0035_10f911Async
        if (await _ui.ExistsAsync(_locators.IneligibleQuote))
        {
        await _ui.VerifyAsync(_locators.IneligibleQuote, _data.Resolve("Visible"), "");
        }
        await _ui.ClickAsync(_locators.CLOSEQUOTE);
    }

    // Business step: I complete driver information for existing client 1
    public async Task CompleteDriverInformationForExistingClient1Async6()
    {
        // EQDriverInformation_5c96e7Page.DriverInformationEnterDriverDetails_0048_10f911Async
        await _ui.ClickAsync(_locators.ExistingClient1);
        await _ui.ClickAsync(_locators.DriverInformationNext);
        await _ui.PressAsync(_locators.DriverInformationNext, "Click");
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0049_10f911Async
        _data.Set("MT National Guard", _data.Get("MT National Guard"));
    }

    // Business step: I complete driver Assignment
    public async Task CompleteDriverAssignmentAsync6()
    {
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment1_0102_10f911Async
        if (_data.Condition("'Driver 1 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver1Vehicle);
        }
        if (_data.Condition("'Driver 1 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver1PrincipalOccasional);
        }
        if (_data.Condition("'Driver 2 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver2Vehicle);
        await _ui.PressAsync(_locators.Driver2Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver2Vehicle, "Click");
        }
        if (_data.Condition("'Driver 2 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver2PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver2PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver2PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 3 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver3Vehicle);
        await _ui.PressAsync(_locators.Driver3Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver3Vehicle, "Click");
        }
        if (_data.Condition("'Driver 3 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver3PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver3PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver3PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 4 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver4Vehicle);
        await _ui.PressAsync(_locators.Driver4Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver4Vehicle, "Click");
        }
        if (_data.Condition("'Driver 4 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver4PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver4PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver4PrincipalOccasional, "Click");
        }
        if (_data.Condition("'Driver 5 Vehicle' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver5Vehicle);
        await _ui.PressAsync(_locators.Driver5Vehicle, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver5Vehicle, "Click");
        }
        if (_data.Condition("'Driver 5 Principal Occasional' != NULL"))
        {
        await _ui.ClickAsync(_locators.Driver5PrincipalOccasional);
        await _ui.PressAsync(_locators.Driver5PrincipalOccasional, "Scroll[1]");
        await _ui.PressAsync(_locators.Driver5PrincipalOccasional, "Click");
        }
        await _ui.ClickAsync(_locators.MultipleDriverAssignmentNext);
    }

    // Business step: I complete multiple Driver Assignment
    public async Task CompleteMultipleDriverAssignmentAsync6()
    {
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment_0103_10f911Async
        if (_data.Condition("EQ || Driver Assignment Continue > Condition"))
        {
        await _ui.WaitAsync(_locators.CONTINUE, "Exists");
        }
        await _ui.VerifyAsync(_locators.CONTINUE, _data.Resolve("Exists"), "");
        // NewEQMultipleDriverAssignment_9e3f3cPage.NewEQMultipleDriverAssignment_0104_10f911Async
        if (_data.Condition("EQ || Driver Assignment Continue > Then"))
        {
        await _ui.ClickAsync(_locators.CONTINUE);
        }
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0105_10f911Async
        await _ui.WaitAsync(_locators.Loading, "Exists");
    }

}