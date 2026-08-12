using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQNamedInsOperatorStatus
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQNamedInsOperatorStatus(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator FirstNameDriver1 => EQNamedInsOperatorStatusLocators.FirstNameDriver1(_page);

    public Task PressFirstNameDriver1Async(string key) => FirstNameDriver1.PressAsync(key);

    public Task DoubleClickFirstNameDriver1Async() => FirstNameDriver1.DblClickAsync();

    public Task SetFirstNameDriver1Async(string value) =>
        UiActions.ApplyInputAsync(_page, FirstNameDriver1, _data.Resolve(value));

    public Task TypeFirstNameDriver1Async(string value, float delayMs = 40) =>
        FirstNameDriver1.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator LastNameDriver1 => EQNamedInsOperatorStatusLocators.LastNameDriver1(_page);

    public Task PressLastNameDriver1Async(string key) => LastNameDriver1.PressAsync(key);

    public Task DoubleClickLastNameDriver1Async() => LastNameDriver1.DblClickAsync();

    public Task SetLastNameDriver1Async(string value) =>
        UiActions.ApplyInputAsync(_page, LastNameDriver1, _data.Resolve(value));

    public Task TypeLastNameDriver1Async(string value, float delayMs = 40) =>
        LastNameDriver1.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator DOBDriver1 => EQNamedInsOperatorStatusLocators.DOBDriver1(_page);

    public Task PressDOBDriver1Async(string key) => DOBDriver1.PressAsync(key);

    public Task DoubleClickDOBDriver1Async() => DOBDriver1.DblClickAsync();

    public Task SetDOBDriver1Async(string value) =>
        UiActions.ApplyInputAsync(_page, DOBDriver1, _data.Resolve(value));

    public Task TypeDOBDriver1Async(string value, float delayMs = 40) =>
        DOBDriver1.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator MoreOptionsRelationToAccountOwner => EQNamedInsOperatorStatusLocators.MoreOptionsRelationToAccountOwner(_page);

    public Task PressMoreOptionsRelationToAccountOwnerAsync(string key) => MoreOptionsRelationToAccountOwner.PressAsync(key);

    public Task DoubleClickMoreOptionsRelationToAccountOwnerAsync() => MoreOptionsRelationToAccountOwner.DblClickAsync();

    public Task ClickMoreOptionsRelationToAccountOwnerAsync() => MoreOptionsRelationToAccountOwner.ClickAsync();

    public Task WaitForMoreOptionsRelationToAccountOwnerAsync() =>
        MoreOptionsRelationToAccountOwner.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator AccountOwner => EQNamedInsOperatorStatusLocators.AccountOwner(_page);

    public Task PressAccountOwnerAsync(string key) => AccountOwner.PressAsync(key);

    public Task DoubleClickAccountOwnerAsync() => AccountOwner.DblClickAsync();

    public Task SetAccountOwnerAsync(string value) =>
        UiActions.ApplyInputAsync(_page, AccountOwner, _data.Resolve(value));

    public Task TypeAccountOwnerAsync(string value, float delayMs = 40) =>
        AccountOwner.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForAccountOwnerAsync() =>
        AccountOwner.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator SSN => EQNamedInsOperatorStatusLocators.SSN(_page);

    public Task PressSSNAsync(string key) => SSN.PressAsync(key);

    public Task DoubleClickSSNAsync() => SSN.DblClickAsync();

    public Task SetSSNAsync(string value) =>
        UiActions.ApplyInputAsync(_page, SSN, _data.Resolve(value));

    public Task TypeSSNAsync(string value, float delayMs = 40) =>
        SSN.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator MTNationalGuard => EQNamedInsOperatorStatusLocators.MTNationalGuard(_page);

    public Task PressMTNationalGuardAsync(string key) => MTNationalGuard.PressAsync(key);

    public Task DoubleClickMTNationalGuardAsync() => MTNationalGuard.DblClickAsync();

    public Task ClickMTNationalGuardAsync() => MTNationalGuard.ClickAsync();

    private ILocator Gender => EQNamedInsOperatorStatusLocators.Gender(_page);

    public Task PressGenderAsync(string key) => Gender.PressAsync(key);

    public Task DoubleClickGenderAsync() => Gender.DblClickAsync();

    public Task SelectGenderAsync(string value) =>
        Gender.SelectOptionAsync(_data.Resolve(value));

    public Task VerifyGenderAsync(string expected) =>
        Expect(Gender).ToContainTextAsync(_data.Resolve(expected));

    private ILocator Male => EQNamedInsOperatorStatusLocators.Male(_page);

    public Task PressMaleAsync(string key) => Male.PressAsync(key);

    public Task DoubleClickMaleAsync() => Male.DblClickAsync();

    public Task ClickMaleAsync() => Male.ClickAsync();

    private ILocator Female => EQNamedInsOperatorStatusLocators.Female(_page);

    public Task PressFemaleAsync(string key) => Female.PressAsync(key);

    public Task DoubleClickFemaleAsync() => Female.DblClickAsync();

    public Task ClickFemaleAsync() => Female.ClickAsync();

    private ILocator Single => EQNamedInsOperatorStatusLocators.Single(_page);

    public Task PressSingleAsync(string key) => Single.PressAsync(key);

    public Task DoubleClickSingleAsync() => Single.DblClickAsync();

    public Task ClickSingleAsync() => Single.ClickAsync();

    public Task VerifySingleAsync(string expected) =>
        Expect(Single).ToContainTextAsync(_data.Resolve(expected));

    private ILocator Married => EQNamedInsOperatorStatusLocators.Married(_page);

    public Task PressMarriedAsync(string key) => Married.PressAsync(key);

    public Task DoubleClickMarriedAsync() => Married.DblClickAsync();

    public Task ClickMarriedAsync() => Married.ClickAsync();

    private ILocator Divorced => EQNamedInsOperatorStatusLocators.Divorced(_page);

    public Task PressDivorcedAsync(string key) => Divorced.PressAsync(key);

    public Task DoubleClickDivorcedAsync() => Divorced.DblClickAsync();

    public Task ClickDivorcedAsync() => Divorced.ClickAsync();

    private ILocator Spouse => EQNamedInsOperatorStatusLocators.Spouse(_page);

    public Task PressSpouseAsync(string key) => Spouse.PressAsync(key);

    public Task DoubleClickSpouseAsync() => Spouse.DblClickAsync();

    public Task VerifySpouseAsync(string expected) =>
        Expect(Spouse).ToContainTextAsync(_data.Resolve(expected));

    private ILocator AccountOwnerReadOnly => EQNamedInsOperatorStatusLocators.AccountOwnerReadOnly(_page);

    public Task PressAccountOwnerReadOnlyAsync(string key) => AccountOwnerReadOnly.PressAsync(key);

    public Task DoubleClickAccountOwnerReadOnlyAsync() => AccountOwnerReadOnly.DblClickAsync();

    public Task VerifyAccountOwnerReadOnlyAsync(string expected) =>
        Expect(AccountOwnerReadOnly).ToContainTextAsync(_data.Resolve(expected));

    private ILocator IsThisDriverANamedInsured => EQNamedInsOperatorStatusLocators.IsThisDriverANamedInsured(_page);

    public Task PressIsThisDriverANamedInsuredAsync(string key) => IsThisDriverANamedInsured.PressAsync(key);

    public Task DoubleClickIsThisDriverANamedInsuredAsync() => IsThisDriverANamedInsured.DblClickAsync();

    public Task WaitForIsThisDriverANamedInsuredAsync() =>
        IsThisDriverANamedInsured.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator PrimaryNamedInsured => EQNamedInsOperatorStatusLocators.PrimaryNamedInsured(_page);

    public Task PressPrimaryNamedInsuredAsync(string key) => PrimaryNamedInsured.PressAsync(key);

    public Task DoubleClickPrimaryNamedInsuredAsync() => PrimaryNamedInsured.DblClickAsync();

    public Task SetPrimaryNamedInsuredAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PrimaryNamedInsured, _data.Resolve(value));

    public Task TypePrimaryNamedInsuredAsync(string value, float delayMs = 40) =>
        PrimaryNamedInsured.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NamedInsured => EQNamedInsOperatorStatusLocators.NamedInsured(_page);

    public Task PressNamedInsuredAsync(string key) => NamedInsured.PressAsync(key);

    public Task DoubleClickNamedInsuredAsync() => NamedInsured.DblClickAsync();

    public Task SetNamedInsuredAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NamedInsured, _data.Resolve(value));

    public Task TypeNamedInsuredAsync(string value, float delayMs = 40) =>
        NamedInsured.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NotANamedInsured => EQNamedInsOperatorStatusLocators.NotANamedInsured(_page);

    public Task PressNotANamedInsuredAsync(string key) => NotANamedInsured.PressAsync(key);

    public Task DoubleClickNotANamedInsuredAsync() => NotANamedInsured.DblClickAsync();

    public Task SetNotANamedInsuredAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NotANamedInsured, _data.Resolve(value));

    public Task TypeNotANamedInsuredAsync(string value, float delayMs = 40) =>
        NotANamedInsured.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Related => EQNamedInsOperatorStatusLocators.Related(_page);

    public Task PressRelatedAsync(string key) => Related.PressAsync(key);

    public Task DoubleClickRelatedAsync() => Related.DblClickAsync();

    public Task SetRelatedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Related, _data.Resolve(value));

    public Task TypeRelatedAsync(string value, float delayMs = 40) =>
        Related.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Assigned => EQNamedInsOperatorStatusLocators.Assigned(_page);

    public Task PressAssignedAsync(string key) => Assigned.PressAsync(key);

    public Task DoubleClickAssignedAsync() => Assigned.DblClickAsync();

    public Task SetAssignedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Assigned, _data.Resolve(value));

    public Task TypeAssignedAsync(string value, float delayMs = 40) =>
        Assigned.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NoCycleLicense => EQNamedInsOperatorStatusLocators.NoCycleLicense(_page);

    public Task PressNoCycleLicenseAsync(string key) => NoCycleLicense.PressAsync(key);

    public Task DoubleClickNoCycleLicenseAsync() => NoCycleLicense.DblClickAsync();

    public Task ClickNoCycleLicenseAsync() => NoCycleLicense.ClickAsync();

    private ILocator MoreOptionsOperatorStatus => EQNamedInsOperatorStatusLocators.MoreOptionsOperatorStatus(_page);

    public Task PressMoreOptionsOperatorStatusAsync(string key) => MoreOptionsOperatorStatus.PressAsync(key);

    public Task DoubleClickMoreOptionsOperatorStatusAsync() => MoreOptionsOperatorStatus.DblClickAsync();

    public Task ClickMoreOptionsOperatorStatusAsync() => MoreOptionsOperatorStatus.ClickAsync();

    private ILocator Military => EQNamedInsOperatorStatusLocators.Military(_page);

    public Task PressMilitaryAsync(string key) => Military.PressAsync(key);

    public Task DoubleClickMilitaryAsync() => Military.DblClickAsync();

    public Task SetMilitaryAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Military, _data.Resolve(value));

    public Task TypeMilitaryAsync(string value, float delayMs = 40) =>
        Military.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Missionary => EQNamedInsOperatorStatusLocators.Missionary(_page);

    public Task PressMissionaryAsync(string key) => Missionary.PressAsync(key);

    public Task DoubleClickMissionaryAsync() => Missionary.DblClickAsync();

    public Task SetMissionaryAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Missionary, _data.Resolve(value));

    public Task TypeMissionaryAsync(string value, float delayMs = 40) =>
        Missionary.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NonDriver => EQNamedInsOperatorStatusLocators.NonDriver(_page);

    public Task PressNonDriverAsync(string key) => NonDriver.PressAsync(key);

    public Task DoubleClickNonDriverAsync() => NonDriver.DblClickAsync();

    public Task SetNonDriverAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NonDriver, _data.Resolve(value));

    public Task TypeNonDriverAsync(string value, float delayMs = 40) =>
        NonDriver.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator OtherInsurance => EQNamedInsOperatorStatusLocators.OtherInsurance(_page);

    public Task PressOtherInsuranceAsync(string key) => OtherInsurance.PressAsync(key);

    public Task DoubleClickOtherInsuranceAsync() => OtherInsurance.DblClickAsync();

    public Task SetOtherInsuranceAsync(string value) =>
        UiActions.ApplyInputAsync(_page, OtherInsurance, _data.Resolve(value));

    public Task TypeOtherInsuranceAsync(string value, float delayMs = 40) =>
        OtherInsurance.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NonDriverReason => EQNamedInsOperatorStatusLocators.NonDriverReason(_page);

    public Task PressNonDriverReasonAsync(string key) => NonDriverReason.PressAsync(key);

    public Task DoubleClickNonDriverReasonAsync() => NonDriverReason.DblClickAsync();

    public Task WaitForNonDriverReasonAsync() =>
        NonDriverReason.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator CycleNonDriverComboBox => EQNamedInsOperatorStatusLocators.CycleNonDriverComboBox(_page);

    public Task PressCycleNonDriverComboBoxAsync(string key) => CycleNonDriverComboBox.PressAsync(key);

    public Task DoubleClickCycleNonDriverComboBoxAsync() => CycleNonDriverComboBox.DblClickAsync();

    public Task SetCycleNonDriverComboBoxAsync(string value) =>
        CycleNonDriverComboBox.SelectOptionAsync(_data.Resolve(value));

    private ILocator Roommate => EQNamedInsOperatorStatusLocators.Roommate(_page);

    public Task PressRoommateAsync(string key) => Roommate.PressAsync(key);

    public Task DoubleClickRoommateAsync() => Roommate.DblClickAsync();

    public Task SetRoommateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Roommate, _data.Resolve(value));

    public Task TypeRoommateAsync(string value, float delayMs = 40) =>
        Roommate.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NeverLicensed => EQNamedInsOperatorStatusLocators.NeverLicensed(_page);

    public Task PressNeverLicensedAsync(string key) => NeverLicensed.PressAsync(key);

    public Task DoubleClickNeverLicensedAsync() => NeverLicensed.DblClickAsync();

    public Task ClickNeverLicensedAsync() => NeverLicensed.ClickAsync();

    private ILocator Underage => EQNamedInsOperatorStatusLocators.Underage(_page);

    public Task PressUnderageAsync(string key) => Underage.PressAsync(key);

    public Task DoubleClickUnderageAsync() => Underage.DblClickAsync();

    public Task ClickUnderageAsync() => Underage.ClickAsync();

    private ILocator MedicalCondition => EQNamedInsOperatorStatusLocators.MedicalCondition(_page);

    public Task PressMedicalConditionAsync(string key) => MedicalCondition.PressAsync(key);

    public Task DoubleClickMedicalConditionAsync() => MedicalCondition.DblClickAsync();

    public Task ClickMedicalConditionAsync() => MedicalCondition.ClickAsync();

    private ILocator MoreOptionsNonDriver => EQNamedInsOperatorStatusLocators.MoreOptionsNonDriver(_page);

    public Task PressMoreOptionsNonDriverAsync(string key) => MoreOptionsNonDriver.PressAsync(key);

    public Task DoubleClickMoreOptionsNonDriverAsync() => MoreOptionsNonDriver.DblClickAsync();

    public Task ClickMoreOptionsNonDriverAsync() => MoreOptionsNonDriver.ClickAsync();

    private ILocator Surrendered => EQNamedInsOperatorStatusLocators.Surrendered(_page);

    public Task PressSurrenderedAsync(string key) => Surrendered.PressAsync(key);

    public Task DoubleClickSurrenderedAsync() => Surrendered.DblClickAsync();

    public Task ClickSurrenderedAsync() => Surrendered.ClickAsync();

    private ILocator PermitDriver => EQNamedInsOperatorStatusLocators.PermitDriver(_page);

    public Task PressPermitDriverAsync(string key) => PermitDriver.PressAsync(key);

    public Task DoubleClickPermitDriverAsync() => PermitDriver.DblClickAsync();

    public Task ClickPermitDriverAsync() => PermitDriver.ClickAsync();

    private ILocator NoPreviouslyInsured => EQNamedInsOperatorStatusLocators.NoPreviouslyInsured(_page);

    public Task PressNoPreviouslyInsuredAsync(string key) => NoPreviouslyInsured.PressAsync(key);

    public Task DoubleClickNoPreviouslyInsuredAsync() => NoPreviouslyInsured.DblClickAsync();

    public Task SetNoPreviouslyInsuredAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NoPreviouslyInsured, _data.Resolve(value));

    public Task TypeNoPreviouslyInsuredAsync(string value, float delayMs = 40) =>
        NoPreviouslyInsured.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickAccountOwnerAsync() => AccountOwner.ClickAsync();
}
