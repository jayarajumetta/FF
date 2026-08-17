using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class LossHistoryPage
{
    private readonly LossHistoryLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public LossHistoryPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new LossHistoryLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I add Addl Interests
    public async Task AddAddlInterestsAsync()
    {
        // CPNavigationLinks_d0fcc0Page.CPNavigationLinks_0140_aad19bAsync
        await _ui.ClickAsync(_locators.AddlInterests);
        // AddlInterestsMain_2478ecPage.AddlInterestsMain_0141_aad19bAsync
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // AddlInterestsLossPayee_9edb58Page.AddlInterestsLossPayee_0142_aad19bAsync
        await _ui.FillAsync(_locators.Type, _data.Resolve("{{data:type_233}}"));
        await _ui.PressAsync(_locators.Type, "Tab");
        await _ui.PressAsync(_locators.Type, "CLICK");
        await _ui.PressAsync(_locators.Type, "Tab");
        await _ui.FillAsync(_locators.LoanNumber, _data.Resolve("{{data:loan_number_234}}"));
        await _ui.PressAsync(_locators.LoanNumber, "Tab");
        await _ui.PressAsync(_locators.LoanNumber, "CLICK");
        await _ui.PressAsync(_locators.LoanNumber, "Tab");
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_235}}"));
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "CLICK");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.FillAsync(_locators.FirstName, _data.Resolve("{{data:first_name_236}}"));
        await _ui.PressAsync(_locators.FirstName, "Tab");
        await _ui.PressAsync(_locators.FirstName, "CLICK");
        await _ui.PressAsync(_locators.FirstName, "Tab");
        await _ui.FillAsync(_locators.MI, _data.Resolve("{{data:mi_237}}"));
        await _ui.PressAsync(_locators.MI, "Tab");
        await _ui.PressAsync(_locators.MI, "CLICK");
        await _ui.PressAsync(_locators.MI, "Tab");
        await _ui.FillAsync(_locators.LastName, _data.Resolve("{{data:last_name_238}}"));
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.PressAsync(_locators.LastName, "CLICK");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.FillAsync(_locators.Address1, _data.Resolve("{{data:address_1_239}}"));
        await _ui.PressAsync(_locators.Address1, "Tab");
        await _ui.PressAsync(_locators.Address1, "CLICK");
        await _ui.PressAsync(_locators.Address1, "Tab");
        await _ui.FillAsync(_locators.ZipCode, _data.Resolve("{{data:zip_code_240}}"));
        await _ui.PressAsync(_locators.ZipCode, "Tab");
        await _ui.PressAsync(_locators.ZipCode, "CLICK");
        await _ui.PressAsync(_locators.ZipCode, "Tab");
        await _ui.FillAsync(_locators.ProvisionsApplicable, _data.Resolve("{{data:provisions_applicable_241}}"));
        await _ui.PressAsync(_locators.ProvisionsApplicable, "Tab");
        await _ui.PressAsync(_locators.ProvisionsApplicable, "CLICK");
        await _ui.PressAsync(_locators.ProvisionsApplicable, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfProperty, _data.Resolve("{{data:description_of_property_242}}"));
        await _ui.PressAsync(_locators.DescriptionOfProperty, "Tab");
        await _ui.PressAsync(_locators.DescriptionOfProperty, "CLICK");
        await _ui.PressAsync(_locators.DescriptionOfProperty, "Tab");
        await _ui.ClickAsync(_locators.AssignLocations);
        await _ui.WaitAsync(_locators.OtherInterestPremisesSchedule, "Exists");
        await _ui.ClickAsync(_locators.NewAssignment);
        await _ui.WaitAsync(_locators.NewAssignment, "Exists");
        await _ui.ClickAsync(_locators.OtherInterestPremisesDetailOK);
        await _ui.WaitAsync(_locators.AssignmentScheduleFor, "Exists");
        await _ui.ClickAsync(_locators.AssignmentScheduleForOK);
        await _ui.ClickAsync(_locators.OtherInterestPremisesScheduleOK);
        if (_data.Condition("State != \"OR\""))
        {
            await _ui.ClickAsync(_locators.AddlInterestsMainOK);
        }
    }

    // Business step: I add Addl Interests
    public async Task AddAddlInterestsAsync2()
    {
        // CPNavigationLinks_d0fcc0Page.CPNavigationLinks_0135_677267Async
        await _ui.ClickAsync(_locators.AddlInterests);
        // AddlInterestsMain_2478ecPage.AddlInterestsMain_0136_677267Async
        await _ui.ClickAsync(_locators.AddAddlInterest);
        // AddlInterestsLossPayee_9edb58Page.AddlInterestsLossPayee_0137_677267Async
        await _ui.FillAsync(_locators.Type, _data.Resolve("{{data:type_246}}"));
        await _ui.PressAsync(_locators.Type, "Tab");
        await _ui.PressAsync(_locators.Type, "CLICK");
        await _ui.PressAsync(_locators.Type, "Tab");
        await _ui.FillAsync(_locators.LoanNumber, _data.Resolve("{{data:loan_number_247}}"));
        await _ui.PressAsync(_locators.LoanNumber, "Tab");
        await _ui.PressAsync(_locators.LoanNumber, "CLICK");
        await _ui.PressAsync(_locators.LoanNumber, "Tab");
        await _ui.FillAsync(_locators.InsuredType, _data.Resolve("{{data:insured_type_248}}"));
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.PressAsync(_locators.InsuredType, "CLICK");
        await _ui.PressAsync(_locators.InsuredType, "Tab");
        await _ui.FillAsync(_locators.FirstName, _data.Resolve("{{data:first_name_249}}"));
        await _ui.PressAsync(_locators.FirstName, "Tab");
        await _ui.PressAsync(_locators.FirstName, "CLICK");
        await _ui.PressAsync(_locators.FirstName, "Tab");
        await _ui.FillAsync(_locators.MI, _data.Resolve("{{data:mi_250}}"));
        await _ui.PressAsync(_locators.MI, "Tab");
        await _ui.PressAsync(_locators.MI, "CLICK");
        await _ui.PressAsync(_locators.MI, "Tab");
        await _ui.FillAsync(_locators.LastName, _data.Resolve("{{data:last_name_251}}"));
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.PressAsync(_locators.LastName, "CLICK");
        await _ui.PressAsync(_locators.LastName, "Tab");
        await _ui.FillAsync(_locators.Address1, _data.Resolve("{{data:address_1_252}}"));
        await _ui.PressAsync(_locators.Address1, "Tab");
        await _ui.PressAsync(_locators.Address1, "CLICK");
        await _ui.PressAsync(_locators.Address1, "Tab");
        await _ui.FillAsync(_locators.ZipCode, _data.Resolve("{{data:zip_code_253}}"));
        await _ui.PressAsync(_locators.ZipCode, "Tab");
        await _ui.PressAsync(_locators.ZipCode, "CLICK");
        await _ui.PressAsync(_locators.ZipCode, "Tab");
        await _ui.FillAsync(_locators.ProvisionsApplicable, _data.Resolve("{{data:provisions_applicable_254}}"));
        await _ui.PressAsync(_locators.ProvisionsApplicable, "Tab");
        await _ui.PressAsync(_locators.ProvisionsApplicable, "CLICK");
        await _ui.PressAsync(_locators.ProvisionsApplicable, "Tab");
        await _ui.FillAsync(_locators.DescriptionOfProperty, _data.Resolve("{{data:description_of_property_255}}"));
        await _ui.PressAsync(_locators.DescriptionOfProperty, "Tab");
        await _ui.PressAsync(_locators.DescriptionOfProperty, "CLICK");
        await _ui.PressAsync(_locators.DescriptionOfProperty, "Tab");
        await _ui.ClickAsync(_locators.AssignLocations);
        await _ui.WaitAsync(_locators.OtherInterestPremisesSchedule, "Exists");
        await _ui.ClickAsync(_locators.NewAssignment);
        await _ui.WaitAsync(_locators.NewAssignment, "Exists");
        await _ui.ClickAsync(_locators.OtherInterestPremisesDetailOK);
        await _ui.WaitAsync(_locators.AssignmentScheduleFor, "Exists");
        await _ui.ClickAsync(_locators.AssignmentScheduleForOK);
        await _ui.ClickAsync(_locators.OtherInterestPremisesScheduleOK);
        if (_data.Condition("State != \"OR\""))
        {
            await _ui.ClickAsync(_locators.AddlInterestsMainOK);
        }
    }

}
