using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Workflows;
using Reqnroll;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding]
public sealed class CommercialRegressionSteps
{
    private readonly ScenarioContext _scenario;

    public CommercialRegressionSteps(ScenarioContext scenario)
    {
        _scenario = scenario;
    }

    private CommercialRegressionWorkflow Workflow() =>
        new(_scenario.Get<BrowserSession>(), _scenario.Get<UiActions>(), _scenario.Get<ScenarioData>(), _scenario.Get<RunLogger>());

    [Given("I issue the new business policy and capture the policy number")]
    [When("I issue the new business policy and capture the policy number")]
    [Then("I issue the new business policy and capture the policy number")]
    public Task IssueAsync() => Workflow().IssueBaselinePolicyAsync();

    [Given("I switch to production underwriting and reopen the policy")]
    [When("I switch to production underwriting and reopen the policy")]
    [Then("I switch to production underwriting and reopen the policy")]
    public Task SwitchAsync() => Workflow().SwitchToProductionAndReopenAsync();

    [Given("I login with admin and reopen the policy")]
    [When("I login with admin and reopen the policy")]
    [Then("I login with admin and reopen the policy")]
    public Task SwitchAsAdminAsync() => Workflow().SwitchToProductionAndReopenAsAdminAsync();

    [Given("I click Refer on the policy")]
    [When("I click Refer on the policy")]
    [Then("I click Refer on the policy")]
    public Task ReferAsync() => Workflow().ClickReferAsync();

    [Given("I click the Refer button")]
    [When("I click the Refer button")]
    [Then("I click the Refer button")]
    public Task ReferButtonAsync() => Workflow().ClickReferButtonAsync();

    [Given("I launch to Checklist")]
    [When("I launch to Checklist")]
    [Then("I launch to Checklist")]
    public Task LaunchToChecklistAsync() => Workflow().LaunchToChecklistAsync();

    [Given("I click OK on the Refer popup")]
    [When("I click OK on the Refer popup")]
    [Then("I click OK on the Refer popup")]
    public Task ReferPopupOkAsync() => Workflow().ClickPopupOkAsync();

    [Given("Click on Complete Application and then do Complete Issuance")]
    [When("Click on Complete Application and then do Complete Issuance")]
    [Then("Click on Complete Application and then do Complete Issuance")]
    public Task CompleteApplicationAsync() => Workflow().ClickCompleteApplicationAsync();

    [Given("I select Transaction Type as Endorse")]
    [When("I select Transaction Type as Endorse")]
    [Then("I select Transaction Type as Endorse")]
    public Task SelectTransactionTypeAsync() => Workflow().SelectTransactionTypeAsync("Endorse");

    [Given("I verify the eChecklist integration")]
    [When("I verify the eChecklist integration")]
    [Then("I verify the eChecklist integration")]
    public Task ChecklistAsync() => Workflow().VerifyChecklistAsync();

    [Given("I execute the Duplicate ID regression endorsement updating Risk Schedule for all vehicle with effective date rule {word}")]
    [When("I execute the Duplicate ID regression endorsement updating Risk Schedule for all vehicle with effective date rule {word}")]
    [Then("I execute the Duplicate ID regression endorsement updating Risk Schedule for all vehicle with effective date rule {word}")]
    public Task DuplicateAsync(string effectiveDateRule) => Workflow().DuplicateIdAsync(effectiveDateRule);

    [Given("I execute the All Other regression endorsement updating Risk Schedule for all vehicle with effective date rule {word}")]
    [When("I execute the All Other regression endorsement updating Risk Schedule for all vehicle with effective date rule {word}")]
    [Then("I execute the All Other regression endorsement updating Risk Schedule for all vehicle with effective date rule {word}")]
    public Task AllOtherAsync(string effectiveDateRule) => Workflow().AllOtherAsync(effectiveDateRule);

    [Given("I increase the policy premium by updating liability and medical limits")]
    [When("I increase the policy premium by updating liability and medical limits")]
    [Then("I increase the policy premium by updating liability and medical limits")]
    public Task IncreasePremiumAsync() => Workflow().IncreasePremiumAsync();

    [Given("I decrease the policy premium by updating liability and medical limits")]
    [When("I decrease the policy premium by updating liability and medical limits")]
    [Then("I decrease the policy premium by updating liability and medical limits")]
    public Task DecreasePremiumAsync() => Workflow().DecreasePremiumAsync();

    [Given("I execute the All Other regression endorsement for premium increase with effective date rule {word}")]
    [When("I execute the All Other regression endorsement for premium increase with effective date rule {word}")]
    [Then("I execute the All Other regression endorsement for premium increase with effective date rule {word}")]
    public Task AllOtherPremiumIncreaseAsync(string effectiveDateRule) => Workflow().AllOtherPremiumIncreaseAsync(effectiveDateRule);

    [Given("I execute the All Other regression endorsement for premium decrease with effective date rule {word}")]
    [When("I execute the All Other regression endorsement for premium decrease with effective date rule {word}")]
    [Then("I execute the All Other regression endorsement for premium decrease with effective date rule {word}")]
    public Task AllOtherPremiumDecreaseAsync(string effectiveDateRule) => Workflow().AllOtherPremiumDecreaseAsync(effectiveDateRule);

    [Given("I execute the All Other regression endorsement for premium decrease with reason as Information and effective date rule {word}")]
    [When("I execute the All Other regression endorsement for premium decrease with reason as Information and effective date rule {word}")]
    [Then("I execute the All Other regression endorsement for premium decrease with reason as Information and effective date rule {word}")]
    public Task AllOtherPremiumDecreaseEndorseWithInformationAsync(string effectiveDateRule) => Workflow().AllOtherPremiumDecreaseEndorseWithInformationAsync(effectiveDateRule);

    [Given("I select endorsement reason as All Other with effective date rule {word}")]
    [When("I select endorsement reason as All Other with effective date rule {word}")]
    [Then("I select endorsement reason as All Other with effective date rule {word}")]
    public Task SelectEndorsementReasonAsAllOtherAsync(string effectiveDateRule) => Workflow().SelectEndorsementReasonAsAllOtherAsync(effectiveDateRule);

    [Given("I navigate to Policy Coverage and set liability limit as 500,000 and medical limit as 10,000")]
    [When("I navigate to Policy Coverage and set liability limit as 500,000 and medical limit as 10,000")]
    [Then("I navigate to Policy Coverage and set liability limit as 500,000 and medical limit as 10,000")]
    public Task NavigateToPolicyCoverageAndSetLimitsAsync() => Workflow().NavigateToPolicyCoverageAndSetLimitsAsync();

    [Given("I execute the All Other regression endorsement for Mailing Address Change Only with effective date rule {word}")]
    [When("I execute the All Other regression endorsement for Mailing Address Change Only with effective date rule {word}")]
    [Then("I execute the All Other regression endorsement for Mailing Address Change Only with effective date rule {word}")]
    public Task AllOtherMailingAddressChangeOnlyAsync(string effectiveDateRule) => Workflow().AllOtherMailingAddressChangeOnlyAsync(effectiveDateRule);

    [Given("I enter the mailing address as 119 Broadway")]
    [When("I enter the mailing address as 119 Broadway")]
    [Then("I enter the mailing address as 119 Broadway")]
    public Task EnterMailingAddressAsync() => Workflow().EnterMailingAddressAsync();

    [Given("I click Complete Issuance")]
    [When("I click Complete Issuance")]
    [Then("I click Complete Issuance")]
    public Task CompleteIssuanceAsync() => Workflow().ClickCompleteIssuanceAsync();

    [Given("I click the Approve button")]
    [When("I click the Approve button")]
    [Then("I click the Approve button")]
    public Task ClickApproveButtonAsync() => Workflow().ClickApproveAsync();

    [Given("I click the View Policy link and store policy number")]
    [When("I click the View Policy link and store policy number")]
    [Then("I click the View Policy link and store policy number")]
    public Task ClickViewPolicyAsync() => Workflow().ClickViewPolicyAsync();

    [Given("I select Transaction Type as Adjust New Business")]
    [When("I select Transaction Type as Adjust New Business")]
    [Then("I select Transaction Type as Adjust New Business")]
    public Task SelectAdjustNewBusinessTransactionTypeAsync() => Workflow().SelectTransactionTypeAsync("Adjust New Business");

    [Given("I select Transaction Type as Renew")]
    [When("I select Transaction Type as Renew")]
    [Then("I select Transaction Type as Renew")]
    public Task SelectRenewTransactionTypeAsync() => Workflow().SelectTransactionTypeAsync("Renew");

    [Given("I click OK if visible")]
    [When("I click OK if visible")]
    [Then("I click OK if visible")]
    public Task ClickOkIfVisibleAsync() => Workflow().ClickOkIfVisibleAsync();

    [Given("I capture the policy effective date")]
    [When("I capture the policy effective date")]
    [Then("I capture the policy effective date")]
    public Task CaptureEffectiveDateAsync() => Workflow().CaptureEffectiveDateAsync();

    [Given("I select Transaction Type as Adjust Renewal")]
    [When("I select Transaction Type as Adjust Renewal")]
    [Then("I select Transaction Type as Adjust Renewal")]
    public Task SelectAdjustRenewalTransactionTypeAsync() => Workflow().SelectTransactionTypeAsync("Adjust Renewal");

    [Given("I select Transaction Type as Cancel")]
    [When("I select Transaction Type as Cancel")]
    [Then("I select Transaction Type as Cancel")]
    public Task SelectCancelTransactionTypeAsync() => Workflow().SelectTransactionTypeAsync("Cancel");

    [Given("I select Transaction Type as Reinstate")]
    [When("I select Transaction Type as Reinstate")]
    [Then("I select Transaction Type as Reinstate")]
    public Task SelectReinstateTransactionTypeAsync() => Workflow().SelectTransactionTypeAsync("Reinstate");

    [Given("I enter reason for reinstatement as SmokeTest Reinstate")]
    [When("I enter reason for reinstatement as SmokeTest Reinstate")]
    [Then("I enter reason for reinstatement as SmokeTest Reinstate")]
    public Task EnterReinstateReasonAsync() => Workflow().EnterReinstateReasonAsync();

    [Given("I select Cancel reason as Insured's request All Other with effective date rule {word}")]
    [When("I select Cancel reason as Insured's request All Other with effective date rule {word}")]
    [Then("I select Cancel reason as Insured's request All Other with effective date rule {word}")]
    public Task SelectCancelReasonAsInsuredsRequestAllOtherAsync(string effectiveDateRule) => Workflow().SelectCancelReasonAsInsuredsRequestAllOtherAsync(effectiveDateRule);

    [Given("I select Cancel reason as Insured's request OOO with effective date rule {word}")]
    [When("I select Cancel reason as Insured's request OOO with effective date rule {word}")]
    [Then("I select Cancel reason as Insured's request OOO with effective date rule {word}")]
    public Task SelectCancelReasonAsInsuredsRequestOOOAsync(string effectiveDateRule) => Workflow().SelectCancelReasonAsInsuredsRequestOOOAsync(effectiveDateRule);

    [Given("I select Cancel reason as Insured's request for policy expiration with effective date {word}")]
    [When("I select Cancel reason as Insured's request for policy expiration with effective date {word}")]
    [Then("I select Cancel reason as Insured's request for policy expiration with effective date {word}")]
    public Task SelectCancelReasonAsInsuredsRequestForPolicyExpirationAsync(string effectiveDate) => Workflow().SelectCancelReasonAsInsuredsRequestForPolicyExpirationAsync(effectiveDate);

    [Given("I select Cancel reason as Insured's request with effective date rule {word}")]
    [When("I select Cancel reason as Insured's request with effective date rule {word}")]
    [Then("I select Cancel reason as Insured's request with effective date rule {word}")]
    public Task SelectCancelReasonAsInsuredsRequestAsync(string effectiveDateRule) => Workflow().SelectCancelReasonAsInsuredsRequestAsync(effectiveDateRule);

    [Given("I enter reason as Forms Correction for Adjust Renewal")]
    [When("I enter reason as Forms Correction for Adjust Renewal")]
    [Then("I enter reason as Forms Correction for Adjust Renewal")]
    public Task EnterAdjustRenewalReasonAsFormsCorrectionAsync() => Workflow().EnterAdjustRenewalReasonAsFormsCorrectionAsync();

    [Given("I select reason as Other and enter details as Test")]
    [When("I select reason as Other and enter details as Test")]
    [Then("I select reason as Other and enter details as Test")]
    public Task SelectReasonAsOtherAsync() => Workflow().EnterReasonAsOtherWithDetailAsync("Test");

    [Given("I click Launch Inspire")]
    [When("I click Launch Inspire")]
    [Then("I click Launch Inspire")]
    public Task ClickLaunchInspireAsync() => Workflow().ClickLaunchInspireAsync();

    [Given("I sign in to Inspire using configured credentials")]
    [When("I sign in to Inspire using configured credentials")]
    [Then("I sign in to Inspire using configured credentials")]
    public Task SignInToInspireAsync() => Workflow().SignInToInspireAsync();

    [Given("I verify the Confirm Business Owners header is visible")]
    [When("I verify the Confirm Business Owners header is visible")]
    [Then("I verify the Confirm Business Owners header is visible")]
    public async Task VerifyConfirmBusinessOwnersHeaderVisibleAsync()
    {
        var isVisible = await Workflow().IsConfirmBusinessOwnersHeaderVisibleAsync();
        if (!isVisible)
            throw new InvalidOperationException("Confirm Business Owners for Policy header was not visible.");
    }

    [Given("I adjust the new business policy and verify INSPIRE")]
    [When("I adjust the new business policy and verify INSPIRE")]
    [Then("I adjust the new business policy and verify INSPIRE")]
    public Task AdjustNewBusinessAsync() => Workflow().AdjustNewBusinessAndVerifyInspireAsync();

    [Given("I endorse the policy for a premium increase")]
    [When("I endorse the policy for a premium increase")]
    [Then("I endorse the policy for a premium increase")]
    public Task IncreaseAsync() => Workflow().PremiumIncreaseAsync();

    [Given("I endorse the policy for a premium decrease")]
    [When("I endorse the policy for a premium decrease")]
    [Then("I endorse the policy for a premium decrease")]
    public Task DecreaseAsync() => Workflow().PremiumDecreaseAsync();

    [Given("I endorse the policy for an information-only change")]
    [When("I endorse the policy for an information-only change")]
    [Then("I endorse the policy for an information-only change")]
    public Task InformationAsync() => Workflow().InformationChangeAsync();

    [Given("I endorse the policy for a mailing-address-only change")]
    [When("I endorse the policy for a mailing-address-only change")]
    [Then("I endorse the policy for a mailing-address-only change")]
    public Task MailingAsync() => Workflow().MailingAddressChangeAsync();

    [Given("I manually renew the policy")]
    [When("I manually renew the policy")]
    [Then("I manually renew the policy")]
    public Task RenewAsync() => Workflow().RenewAsync();

    [Given("I adjust the renewal")]
    [When("I adjust the renewal")]
    [Then("I adjust the renewal")]
    public Task AdjustRenewalAsync() => Workflow().AdjustRenewalAsync();

    [Given("I create an out-of-sequence endorsement")]
    [When("I create an out-of-sequence endorsement")]
    [Then("I create an out-of-sequence endorsement")]
    public Task OosEndorsementAsync() => Workflow().OutOfSequenceEndorsementAsync();

    [Given("I cancel and reinstate using prorate")]
    [When("I cancel and reinstate using prorate")]
    [Then("I cancel and reinstate using prorate")]
    public Task ProrateAsync()
    {
        var workflow = Workflow();
        return workflow.CancelAndReinstateAsync(workflow.Profile.CancelProrate, workflow.Profile.ReinstateProrate);
    }

    [Given("I cancel and reinstate using short rate")]
    [When("I cancel and reinstate using short rate")]
    [Then("I cancel and reinstate using short rate")]
    public Task ShortRateAsync()
    {
        var workflow = Workflow();
        return workflow.CancelAndReinstateAsync(workflow.Profile.CancelShortRate, workflow.Profile.ReinstateShortRate);
    }

    [Given("I cancel and reinstate out of sequence")]
    [When("I cancel and reinstate out of sequence")]
    [Then("I cancel and reinstate out of sequence")]
    public Task OosAsync()
    {
        var workflow = Workflow();
        return workflow.CancelAndReinstateAsync(workflow.Profile.CancelOutOfSequence, workflow.Profile.ReinstateOutOfSequence);
    }

    [Given("I cancel and reinstate at policy expiration")]
    [When("I cancel and reinstate at policy expiration")]
    [Then("I cancel and reinstate at policy expiration")]
    public Task PolicyExpirationAsync()
    {
        var workflow = Workflow();
        return workflow.CancelAndReinstateAsync(workflow.Profile.CancelPolicyExpiration, workflow.Profile.ReinstatePolicyExpiration);
    }

    [Given("I sign out when required by the traced regression flow")]
    [When("I sign out when required by the traced regression flow")]
    [Then("I sign out when required by the traced regression flow")]
    public Task LogoutAsync() => Workflow().LogoutIfRequiredAsync();

    [Given("the traced regression lifecycle is complete")]
    [When("the traced regression lifecycle is complete")]
    [Then("the traced regression lifecycle is complete")]
    public void Complete() => _scenario.Get<RunLogger>().Info("All raw-source regression lifecycle transactions completed.");
}

