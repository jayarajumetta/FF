using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class LossHistoryPage
{
    private readonly BrowserSession _browser;
    private readonly LossHistoryLocators _locators;
    private readonly UiActions _ui;

    public LossHistoryPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new LossHistoryLocators(browser.Page);
        _ui = ui;
    }

    public Task VerifyCONTINUEDoesnTApplyAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CONTINUEDoesnTApply, expected, property, new ControlIntent("LossHistory", "CONTINUEDoesnTApply"));

    public Task ClickCONTINUEDoesnTApplyAsync() =>
        _ui.ClickAsync(_locators.CONTINUEDoesnTApply, new ControlIntent("LossHistory", "CONTINUEDoesnTApply"));

    public Task<bool> IsCONTINUEDoesnTApplyPresentAsync() =>
        _ui.ExistsAsync(_locators.CONTINUEDoesnTApply);

    public Task VerifyClaimDriverNotInHouseholdAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ClaimDriverNotInHousehold, expected, property, new ControlIntent("LossHistory", "ClaimDriverNotInHousehold"));

    public Task PressClaimDriverNotInHouseholdAsync(string key) =>
        _ui.PressAsync(_locators.ClaimDriverNotInHousehold, key, new ControlIntent("LossHistory", "ClaimDriverNotInHousehold"));

    public Task ClickClaimDriverNotInHouseholdAsync() =>
        _ui.ClickAsync(_locators.ClaimDriverNotInHousehold, new ControlIntent("LossHistory", "ClaimDriverNotInHousehold"));

    public Task<bool> IsClaimDriverNotInHouseholdPresentAsync() =>
        _ui.ExistsAsync(_locators.ClaimDriverNotInHousehold);

    public Task<bool> IsClaimDriverNotInHouseholdPresentAsync(int row) =>
        _ui.ExistsAsync(_locators.GetClaimDriverNotInHousehold(row));

    public Task ClickClaimDriverNotInHouseholdAsync(int row) =>
        _ui.ClickAsync(_locators.GetClaimDriverNotInHousehold(row), new ControlIntent("LossHistory", "ClaimDriverNotInHousehold"));

    public Task SelectClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNationalAsync(string value) =>
        _ui.SelectAsync(_locators.ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational, value, new ControlIntent("LossHistory", "ClaimVehicleLoanedToDriverThatDoesNotDidNotResideInHouseholdAndHasNoAccessToVehicleSInsuredByAmericanNational"));

    public Task<bool> IsNeverLivedInHouseholdOrInsuredHasNoKnowledgeOfThisPersonPresentAsync() =>
        _ui.ExistsAsync(_locators.NeverLivedInHouseholdOrInsuredHasNoKnowledgeOfThisPerson);

    public Task ClickNeverLivedInHouseholdOrInsuredHasNoKnowledgeOfThisPersonAsync() =>
        _ui.ClickAsync(_locators.NeverLivedInHouseholdOrInsuredHasNoKnowledgeOfThisPerson, new ControlIntent("LossHistory", "NeverLivedInHouseholdOrInsuredHasNoKnowledgeOfThisPerson"));

    public Task<bool> IsNeverLivedInHouseholdOrInsuredHasNoKnowledgeOfThisPersonPresentAsync(int row) =>
        _ui.ExistsAsync(_locators.GetNeverLivedInHouseholdOrInsuredHasNoKnowledgeOfThisPerson(row));

    public Task ClickNeverLivedInHouseholdOrInsuredHasNoKnowledgeOfThisPersonAsync(int row) =>
        _ui.ClickAsync(_locators.GetNeverLivedInHouseholdOrInsuredHasNoKnowledgeOfThisPerson(row), new ControlIntent("LossHistory", "NeverLivedInHouseholdOrInsuredHasNoKnowledgeOfThisPerson"));

    public Task SelectClaimViolationDoesNotApplyAsync(string value) =>
        _ui.SelectAsync(_locators.CONTINUEDoesnTApply, value, new ControlIntent("LossHistory", "ClaimViolationDoesNotApply"));

    public Task ClickClaimViolationSaveAndContinueAsync() =>
        _ui.ClickAsync(_locators.CONTINUEDoesnTApply, new ControlIntent("LossHistory", "ClaimViolationSaveAndContinue"));

    public Task ClickClaimsViolationNEWNextAsync() =>
        _ui.ClickAsync(_locators.ClaimsViolationNEWNext, new ControlIntent("LossHistory", "ClaimsViolationNEWNext"));

    public Task EnterComboBoxAsync(string value) =>
        _ui.FillAsync(_locators.CONTINUEDoesnTApply, value, new ControlIntent("LossHistory", "ComboBox"));

    public Task<bool> IsComboBoxPresentAsync() =>
        _ui.ExistsAsync(_locators.CONTINUEDoesnTApply);

    public Task WaitForEditClaimAsync(string expected) =>
        _ui.WaitAsync(_locators.EditClaim, expected, new ControlIntent("LossHistory", "EditClaim"));

    public Task ClickEditClaimAsync() =>
        _ui.ClickAsync(_locators.EditClaim, new ControlIntent("LossHistory", "EditClaim"));

    public Task ClickEditClaimAsync(int row) =>
        _ui.ClickAsync(_locators.GetEditClaim(row), new ControlIntent("LossHistory", "EditClaim"));

    public Task<bool> IsEditClaimPresentAsync() =>
        _ui.ExistsAsync(_locators.EditClaim);

    public async Task<IReadOnlyList<string>> GetRequiredClaimEditIdsAsync()
    {
        await Assertions.Expect(_locators.ClaimsViolationNEWNext).ToBeVisibleAsync();
        var buttons = _locators.RequiredClaimEditButtons;
        var count = await buttons.CountAsync();
        var ids = new List<string>();
        for (var index = 0; index < count; index++)
        {
            var id = await buttons.Nth(index).GetAttributeAsync("data-testid");
            if (string.IsNullOrWhiteSpace(id))
                throw new InvalidOperationException("A claim requiring edits has no edit-button test ID.");
            ids.Add(id);
        }
        return ids;
    }

    public async Task CompleteRequiredClaimEditAsync(string editButtonTestId)
    {
        var button = _locators.ClaimEditButton(editButtonTestId);
        var invalidRow = _locators.ClaimsRequiringEdit.Filter(new() { Has = button });
        await Assertions.Expect(invalidRow).ToHaveCountAsync(1);
        await _ui.ClickAsync(button, new ControlIntent("LossHistory", $"EditClaim:{editButtonTestId}"));
        await Assertions.Expect(_locators.ClaimDetail).ToBeVisibleAsync();
        await _ui.ClickAsync(_locators.ClaimDriverOutsideHousehold,
            new ControlIntent("LossHistory", $"ClaimDriverOutsideHousehold:{editButtonTestId}"));
        if (await _locators.ClaimLoanedVehicleReason.IsVisibleAsync())
        {
            await _ui.ClickAsync(_locators.ClaimLoanedVehicleReason,
                new ControlIntent("LossHistory", $"ClaimLoanedVehicleReason:{editButtonTestId}"));
        }
        await _ui.ClickAsync(_locators.ClaimSaveAndContinue,
            new ControlIntent("LossHistory", $"ClaimSaveAndContinue:{editButtonTestId}"));
        await Assertions.Expect(_locators.ClaimDetail).ToBeHiddenAsync();
        await Assertions.Expect(invalidRow).ToHaveCountAsync(0);
    }

    public Task VerifyNoClaimsRequireEditAsync() =>
        Assertions.Expect(_locators.ClaimsRequiringEdit).ToHaveCountAsync(0);
    public Task<bool> IsEditClaimPresentAsync(int row) =>
        _ui.ExistsAsync(_locators.GetEditClaim(row));
public Task WaitForUWCONTINUEAsync(string expected) =>
        _ui.WaitAsync(_locators.UWCONTINUE, expected, new ControlIntent("LossHistory", "UWCONTINUE"));

    public Task VerifyUWCONTINUEAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.UWCONTINUE, expected, property, new ControlIntent("LossHistory", "UWCONTINUE"));

    public Task ClickUWCONTINUEAsync() =>
        _ui.ClickAsync(_locators.UWCONTINUE, new ControlIntent("LossHistory", "UWCONTINUE"));

    public Task<bool> IsUWCONTINUEPresentAsync() =>
        _ui.ExistsAsync(_locators.UWCONTINUE);

    public Task WaitForClaimsViolationsHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.ClaimsViolationsHeader, expected, new ControlIntent("LossHistory", "ClaimsViolationsHeader"));
    public Task ClickClaimsViolationsNavAsync() =>
        _ui.ClickAsync(_locators.ClaimsViolationsNav, new ControlIntent("LossHistory", "ClaimsViolationsNav"));

    public Task<bool> IsClaimsViolationsNavPresentAsync() =>
        _ui.ExistsAsync(_locators.ClaimsViolationsNav);

    public Task<bool> IsVerifyAndUpdateClaimsInstructionPresentAsync() =>
        _ui.ExistsAsync(_locators.VerifyAndUpdateClaimsInstruction);

    public Task<bool> IsClaimDetailDonePresentAsync() =>
        _ui.ExistsAsync(_locators.ClaimDetailDone);

    public Task ClickClaimDetailDoneAsync() =>
        _ui.ClickAsync(_locators.ClaimDetailDone, new ControlIntent("LossHistory", "ClaimDetailDone"));

    public Task<bool> IsClaimDatePresentAsync() =>
        _ui.ExistsAsync(_locators.ClaimDateLabel);

    public Task<bool> IsClaimDatePresentAsync(int row) =>
        _ui.ExistsAsync(_locators.GetClaimDateLabel(row));

    public async Task<IReadOnlyList<string>> GetRequiredViolationEditIdsAsync()
    {
        await Assertions.Expect(_locators.ClaimsViolationNEWNext).ToBeVisibleAsync(new() { Timeout = 30_000 });
        var buttons = _locators.RequiredViolationEditButtons;
        var count = await buttons.CountAsync();
        var ids = new List<string>();
        for (var index = 0; index < count; index++)
        {
            var id = await buttons.Nth(index).GetAttributeAsync("data-testid");
            if (string.IsNullOrWhiteSpace(id))
                throw new InvalidOperationException("A violation requiring edits has no edit-button test ID.");
            ids.Add(id);
        }
        return ids;
    }

    public async Task CompleteRequiredViolationEditAsync(string editButtonTestId, string violationCode)
    {
        var button = _locators.ViolationEditButton(editButtonTestId);
        var invalidRow = _locators.ViolationsRequiringEdit.Filter(new() { Has = button });
        await Assertions.Expect(invalidRow).ToHaveCountAsync(1, new() { Timeout = 30_000 });
        await _ui.ClickAsync(button, new ControlIntent("LossHistory", $"EditViolation:{editButtonTestId}"));
        await Assertions.Expect(_locators.ViolationCode).ToBeVisibleAsync(new() { Timeout = 30_000 });
        await _ui.SelectAsync(_locators.ViolationCode, violationCode,
            new ControlIntent("LossHistory", $"ViolationCode:{editButtonTestId}"));
        await Assertions.Expect(_locators.ViolationCode).ToHaveTextAsync(violationCode, new() { Timeout = 30_000 });
        await _ui.ClickAsync(_locators.ViolationSaveAndContinue,
            new ControlIntent("LossHistory", $"ViolationSaveAndContinue:{editButtonTestId}"));
        await Assertions.Expect(_locators.ViolationSaveAndContinue).ToBeHiddenAsync(new() { Timeout = 30_000 });
        await Assertions.Expect(_locators.ClaimsViolationsHeader).ToBeVisibleAsync(new() { Timeout = 30_000 });
        await Assertions.Expect(invalidRow).ToHaveCountAsync(0, new() { Timeout = 30_000 });
    }

    public Task VerifyNoViolationsRequireEditAsync() =>
        Assertions.Expect(_locators.ViolationsRequiringEdit).ToHaveCountAsync(0, new() { Timeout = 30_000 });

}
