using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.BusinessOutcomes;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Models;
using PnCTestAutomation.Pages;
using PnCTestAutomation.Pages.ExpertQuotePages;
using PnCTestAutomation.Pages.ExpertQuotePages.SFP;
using PnCTestAutomation.Services;
using PnCTestAutomation.QuoteHandoffs;
using Reqnroll;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PnCTestAutomation.StepDefinitions.SFPSteps
{
    /// <summary>
    /// Steps for SFP Finalization - Insurance Score, Mortgagee, Pricing, Submission, Checklist
    /// </summary>
    [Binding]
    public class SFP_FinalizationSteps
    {
        private readonly PlaywrightContext _context;
        private readonly ScenarioContextData _contextData;
        private readonly ScenarioContext _scenarioContext;
        private readonly IFormsOrchestrationService _formsOrchestrator;
        private readonly IConfiguration _configuration;
        private readonly IQuoteHandoff _quoteHandoff;
        private readonly IBusinessOutcomeContext _businessOutcomeContext;
        private readonly IBusinessOutcomeVerifier _businessOutcomes;

        public SFP_FinalizationSteps(
            PlaywrightContext context,
            ScenarioContext scenarioContext,
            IFormsOrchestrationService formsOrchestrator,
            IConfiguration configuration,
            IQuoteHandoff quoteHandoff,
            IBusinessOutcomeContext businessOutcomeContext,
            IBusinessOutcomeVerifier businessOutcomes)
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _contextData = _scenarioContext[ScenarioContextData.ContextKey] as ScenarioContextData
                ?? throw new InvalidOperationException("ScenarioContextData not found. Ensure TestHooks.BeforeTestRun registered it.");
            _formsOrchestrator = formsOrchestrator;
            _configuration = configuration;
            _quoteHandoff = quoteHandoff;
            _businessOutcomeContext = businessOutcomeContext;
            _businessOutcomes = businessOutcomes;
        }

        [When("user runs Insurance Score")]
        public async Task UserRunsInsuranceScore(Table table)
        {
            TableMappingHelpers.InsuranceScoreFields(table, _contextData);

            var insuranceScorePage = new SFP_InsuranceScorePage(_context.Page);
            await insuranceScorePage.WaitForSpinnerAsync();

            // ── Page detection via side nav ────────────────────────────────
            // Business rules governing Insurance Designee screen visibility:
            //
            //   DOES appear:
            //     • Policies with Original Inception date 11/14/2014 or LATER.
            //     • SD (South Dakota) and WI (Wisconsin) renewal conversions
            //       always show the Insurance Designee screen.
            //
            //   DOES NOT appear:
            //     • Policies with Original Inception date BEFORE 11/14/2014.
            //       Rules 10301 & 11055 (Insurance Designee) are suppressed.
            //
            // The app only renders the "InsuranceDesignee-nav" side nav item when
            // the step is required. Checking the nav is the single source of truth —
            // faster and more reliable than probing page content.
            var sideNav = new SideMenuNavigation(_context.Page);
            if (!await sideNav.IsInsuranceScoreNavPresentAsync())
            {
                Console.WriteLine("[InsuranceScore] 'Insurance Designee' not present in side nav - step not required for this state/transaction, skipping.");
                return;
            }

            // Ensure we are on the Insurance Score page before interacting with controls.
            await sideNav.GoToInsuranceScoreAsync();
            await insuranceScorePage.WaitForSpinnerAsync();

            // ── Insurance Score flow ──────────────────────────────────────────
            // Click entity type dropdown only when visible (not present in all states).
            if (!string.IsNullOrEmpty(_contextData.InsuranceScoreEntityType) &&
                await insuranceScorePage.EntityTypeSelect.CountAsync() > 0 &&
                await insuranceScorePage.EntityTypeSelect.IsVisibleAsync())
            {
                await insuranceScorePage.EntityTypeSelect.ClickAsync();
                await _context.Page.GetByRole(AriaRole.Option, new() { Name = _contextData.InsuranceScoreEntityType }).ClickAsync();
                await insuranceScorePage.WaitForSpinnerAsync();
            }

            // Click Primary Insured or Individual Not Listed designee button if present.
            if (_contextData.InsuranceScoreDesignee?.ToLower() == "primary insured")
            {
                try
                {
                    await insuranceScorePage.PrimaryInsuredButton.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
                    await insuranceScorePage.PrimaryInsuredButton.ClickAsync();
                    await insuranceScorePage.WaitForSpinnerAsync();
                }
                catch (TimeoutException)
                {
                    Console.WriteLine("[InsuranceScore] PrimaryInsured button not present for this state - skipping designee selection");
                }
            }
            else if (_contextData.InsuranceScoreDesignee?.ToLower() == "individual not listed")
            {
                try
                {
                    await insuranceScorePage.IndividualNotListedButton.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
                    await insuranceScorePage.IndividualNotListedButton.ClickAsync();
                    await insuranceScorePage.WaitForSpinnerAsync();
                }
                catch (TimeoutException)
                {
                    Console.WriteLine("[InsuranceScore] IndividualNotListed button not present for this state - skipping designee selection");
                }
            }

            await insuranceScorePage.ApplyConsentDecisionAsync(
                _contextData.InsuranceScoreConsent);

            await insuranceScorePage.ClickNextAsync();
        }

        [When("user adds Additional Interest Mortgagee")]
        public async Task UserAddsAdditionalInterestMortgagee(Table table)
        {
            TableMappingHelpers.MortgageeFields(table, _contextData);

            // Navigate explicitly to Mortgagee/Loss Payee so this step does not depend
            // on implicit page progression from prior steps.
            var sideNav = new SideMenuNavigation(_context.Page);
            await sideNav.GoToMortgageeLossPayeeAsync();

            var mortgageePage = new SFP_MortgageeLossPayeePage(_context.Page);
            await mortgageePage.AddMortgageeAsync(_contextData);

            Console.WriteLine($"Added Mortgagee: SearchName={_contextData.MortgageeSearchName}, Location={_contextData.MortgageeLocation}");
        }

        [Then("user verifies Premium on Pricing screen")]
        public async Task UserVerifiesPremiumOnPricingScreen()
        {
            var sideNav = new SideMenuNavigation(_context.Page);
            await sideNav.GoToPricingAsync();

            var pricingPage = new SFP_PricingPage(_context.Page);
            await pricingPage.WaitForSpinnerAsync();

            // Capture quote number if SSN step didn't get it
            if (string.IsNullOrWhiteSpace(_contextData.QuoteNumber))
            {
                _contextData.QuoteNumber = await SFPSteps.ExtractQuoteNumberFromPageAsync(_context.Page);
                _quoteHandoff.Publish(_contextData.QuoteNumber);
            }

            ConfirmOutcomeProfileApplicability();
            var authoritativeQuote = _quoteHandoff
                .Require(nameof(UserVerifiesPremiumOnPricingScreen))
                .QuoteNumber;
            var displayedQuote =
                await SFPSteps.ExtractQuoteNumberFromPageAsync(_context.Page);
            await _businessOutcomes.VerifyQuoteIdentityAsync(
                authoritativeQuote,
                displayedQuote,
                "pricing");

            var rawPremium = await pricingPage.GetAnnualPremiumTextAsync();
            await _businessOutcomes.VerifyPremiumAsync(rawPremium);
            Console.WriteLine(
                "[BusinessOutcome] Quote identity and premium matched the approved profile.");
        }

        /// <summary>
        /// Derives the forms test case key ("CE" or "BASIC") from the scenario context.
        /// Checks (in order): explicit FormsTestCase on context, ProductSelection, scenario tags, scenario title.
        /// </summary>
        private string DeriveFormsTestCase()
        {
            // Explicit override from feature table takes highest priority.
            if (!string.IsNullOrWhiteSpace(_contextData?.FormsTestCase))
                return _contextData.FormsTestCase;

            var productSelection = (_contextData?.ProductSelection ?? string.Empty).Trim();
            if (productSelection.Equals("CE", StringComparison.OrdinalIgnoreCase)
                || productSelection.Equals("Country Estate", StringComparison.OrdinalIgnoreCase))
                return "CE";

            var tags = _scenarioContext?.ScenarioInfo?.Tags ?? Array.Empty<string>();
            if (tags.Any(t => t.Equals("CE", StringComparison.OrdinalIgnoreCase)))
                return "CE";

            var scenarioTitle = _scenarioContext?.ScenarioInfo?.Title ?? string.Empty;
            if (scenarioTitle.IndexOf("Country Estate", StringComparison.OrdinalIgnoreCase) >= 0
                || scenarioTitle.IndexOf("CE", StringComparison.OrdinalIgnoreCase) >= 0)
                return "CE";

            return "BASIC";
        }

        [When("user completes Billing Information")]
        public async Task UserCompletesBillingInformation(Table table)
        {
            TableMappingHelpers.BillingAccountFields(table, _contextData);

            var billingPage = new SFP_BillingInformationPage(_context.Page);
            await billingPage.WaitForSpinnerAsync();

            // ── Step 1: Billing Account Setup ────────────────────────────────
            // When escrow is billed to the mortgagee the full billing form is not shown —
            // the page only shows a pre-selected "MORTGAGEE" chip and Next: Submission.
            // Guard the entire form with a short visibility check.
            var hasBillingForm = await billingPage.CreateNewBillingAccountButton.IsVisibleAsync();

            if (hasBillingForm)
            {
                if (_contextData.PrimaryPayer?.ToLower() == "primary insured")
                {
                    await billingPage.CreateNewBillingAccountButton.ClickAsync();
                    await billingPage.WaitForSpinnerAsync();
                    await billingPage.PrimaryPayerPrimaryInsuredButton.ClickAsync();
                }
                else
                {
                    await billingPage.CreateNewBillingAccountButton.ClickAsync();
                    await billingPage.WaitForSpinnerAsync();
                    await billingPage.PrimaryPayerOtherButton.ClickAsync();
                }
                await billingPage.WaitForSpinnerAsync();

                // ── Step 2: Future Payment Plan – Payment Type ────────────────────
                var isEasyPay = string.Equals(
                    (_contextData.PaymentType ?? "").Replace(" ", ""), "easypay",
                    StringComparison.OrdinalIgnoreCase);

                if (isEasyPay)
                    await billingPage.PaymentTypeEasyPayButton.ClickAsync();
                else
                    await billingPage.PaymentTypeDirectBillButton.ClickAsync();
                await billingPage.WaitForSpinnerAsync();

                // ── Step 3: EasyPay bank account details ──────────────────────────
                if (isEasyPay)
                {
                    // New Account
                    await billingPage.FutureBankAccountCreateNewButton.ClickAsync();
                    await billingPage.WaitForSpinnerAsync();

                    // Personal use
                    await billingPage.FutureBankAccountUsePersonalButton.ClickAsync();
                    await billingPage.WaitForSpinnerAsync();

                    // Checking type
                    await billingPage.FutureBankAccountTypeCheckingButton.ClickAsync();
                    await billingPage.WaitForSpinnerAsync();

                    // Bank Account Owner = Policy Owner (first chip)
                    await billingPage.FutureBankAccountOwnerPrimaryButton.ClickAsync();
                    await billingPage.WaitForSpinnerAsync();

                    // Bank details
                    var routing = !string.IsNullOrWhiteSpace(_contextData.RoutingNumber)
                        ? _contextData.RoutingNumber
                        : "021000021";
                    var account = !string.IsNullOrWhiteSpace(_contextData.AccountNumber)
                        ? _contextData.AccountNumber
                        : Random.Shared.Next(100000000, 999999999).ToString();
                    var bankName = !string.IsNullOrWhiteSpace(_contextData.BankName)
                        ? _contextData.BankName
                        : "Test Bank";

                    await billingPage.FutureBankRoutingNumberInput.FillAsync(routing);
                    await billingPage.FutureBankAccountNumberInput.FillAsync(account);
                    await billingPage.FutureNameOfBankInput.FillAsync(bankName);
                    await billingPage.WaitForSpinnerAsync();
                }

                // ── Step 4: Payment Plan ──────────────────────────────────────────
                switch (_contextData.PaymentPlan?.ToLower())
                {
                    case "1 payment":
                        await billingPage.PaymentPlan1PaymentButton.ClickAsync();
                        break;
                    case "2 payments":
                        await billingPage.PaymentPlan2PaymentsButton.ClickAsync();
                        break;
                    case "4 payments":
                        await billingPage.PaymentPlan4PaymentsButton.ClickAsync();
                        break;
                    case "12 payments":
                        await billingPage.PaymentPlan12PaymentsButton.ClickAsync();
                        break;
                    default:
                        await billingPage.PaymentPlan1PaymentButton.ClickAsync();
                        break;
                }
                await billingPage.WaitForSpinnerAsync();

                // ── Step 5: Payment Due Date ──────────────────────────────────────
                if (!string.IsNullOrWhiteSpace(_contextData.PaymentDueDate))
                {
                    await billingPage.PaymentDueDateInput.FillAsync(_contextData.PaymentDueDate);
                    await billingPage.WaitForSpinnerAsync();
                }

                // ── Step 6: Initial Payment – Amount ──────────────────────────────
                switch (_contextData.PaymentAmount?.ToLower())
                {
                    case "minimum due":
                    case "minimum":
                        await billingPage.PaymentAmountMinimumButton.ClickAsync();
                        break;
                    case "full balance":
                    case "full":
                        await billingPage.PaymentAmountFullBalanceButton.ClickAsync();
                        break;
                    case "custom":
                        await billingPage.PaymentAmountCustomButton.ClickAsync();
                        break;
                    default:
                        await billingPage.PaymentAmountMinimumButton.ClickAsync();
                        break;
                }
                await billingPage.WaitForSpinnerAsync();

                // ── Step 7: Initial Payment – Payment Method ──────────────────────
                switch (_contextData.PaymentMethod?.ToLower())
                {
                    case "quickpay":
                    case "quick pay":
                        await billingPage.InitialPaymentMethodQuickPayButton.ClickAsync();
                        break;
                    case "check":
                        await billingPage.InitialPaymentMethodCheckButton.ClickAsync();
                        await billingPage.WaitForSpinnerAsync();
                        var checkNum = !string.IsNullOrWhiteSpace(_contextData.CheckNumber)
                            ? _contextData.CheckNumber
                            : Random.Shared.Next(1000, 99999).ToString();
                        await billingPage.InitialCheckNumberInput.FillAsync(checkNum);
                        break;
                    case "credit card":
                        await billingPage.InitialPaymentMethodCreditCardButton.ClickAsync();
                        break;
                    default:
                        await billingPage.InitialPaymentMethodCheckButton.ClickAsync();
                        break;
                }
                await billingPage.WaitForSpinnerAsync();
            } // end if (hasBillingForm)
            else
            {
                Console.WriteLine("[Billing] Full billing form not present (mortgagee-escrow policy) — skipping billing form.");
            }

            // Escrow billing navigation can be slower than usual — allow up to 2 minutes.
            await billingPage.ClickNextAsync(spinnerTimeoutMs: 120000);
            Console.WriteLine($"Billing completed: PaymentType={_contextData.PaymentType}, " +
                              $"Plan={_contextData.PaymentPlan}, Method={_contextData.PaymentMethod}");
        }

        [When("user validates Forms via Duckcreek for state {string}")]
        public async Task UserValidatesFormsViaDuckcreek(string state)
        {
            var quoteId = _quoteHandoff
                .Require(nameof(UserValidatesFormsViaDuckcreek))
                .QuoteNumber;
            var lob = _contextData.FormsLob ?? "SFP";
            var result = await _formsOrchestrator.ValidateAsync(
                new FormsValidationRequest(
                    quoteId,
                    state,
                    lob,
                    DeriveFormsTestCase()));
            var report = result.Evidence.Single(
                artifact => artifact.Kind == ArtifactKind.FormsHtml);
            Console.WriteLine(
                $"[FormsValidation] Validation passed. Report: {report.RelativePath}");
        }

        [When("user clicks Save for Later")]
        public async Task UserClicksSaveForLater()
        {
            var page = _context.Page;
            var quoteActions = page.GetByRole(
                AriaRole.Button,
                new() { Name = "QUOTE ACTIONS", Exact = true });
            if (await quoteActions.CountAsync() == 1)
            {
                await quoteActions.ClickAsync();
                var saveItem = page.GetByRole(
                    AriaRole.Menuitem,
                    new()
                    {
                        NameRegex = new System.Text.RegularExpressions.Regex(
                            @"save\s*for\s*later|suspend",
                            System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    });
                if (await saveItem.CountAsync() == 1)
                {
                    await saveItem.ClickAsync();
                    await page.WaitForLoadStateAsync(
                        LoadState.NetworkIdle,
                        new() { Timeout = 30000 });
                    Console.WriteLine(
                        "[SaveForLater] The scenario quote was saved.");
                    return;
                }
            }

            throw new BusinessOutcomeException(
                "quote handoff",
                "The Save for Later action was missing or ambiguous.");
        }

        [When("user navigates to Expert Quote and searches by Quote Number")]
        public async Task UserNavigatesToExpertQuoteAndSearchesByQuoteNumber()
        {
            var page = _context.Page;
            var clientSearchPage = new ClientSearchPage(page);

            var quoteNumber = _quoteHandoff
                .Require(nameof(UserNavigatesToExpertQuoteAndSearchesByQuoteNumber))
                .QuoteNumber;

            // If the dashboard search input isn't visible (e.g. still inside the quote after a fallback
            // "Save for Later"), navigate to the EQ home page first.
            var searchInput = page.GetByTestId("quoteSearchInput");
            if (await searchInput.CountAsync() == 0 || !await searchInput.IsVisibleAsync())
            {
                var eqBase = _configuration["Playwright:ExpertQuoteBase"]
                             ?? "https://expertquote-qa.americannational.com";
                var homeUrl = eqBase.TrimEnd('/') + "/expertquote/";
                Console.WriteLine($"[SearchByQuote] quoteSearchInput not visible — navigating to {homeUrl}");
                await page.GotoAsync(homeUrl, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle, Timeout = 60000 });
                await searchInput.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
            }

            await clientSearchPage.SearchForClientAsync(quoteNumber);
            var displayedQuote =
                await clientSearchPage.GetExactQuoteIdentityAsync(quoteNumber);
            await _businessOutcomes.VerifyQuoteIdentityAsync(
                quoteNumber,
                displayedQuote,
                "save-search-result");
            await clientSearchPage.OpenExactQuoteAsync(quoteNumber);
            var reopenedQuote =
                await SFPSteps.ExtractQuoteNumberFromPageAsync(_context.Page);
            await _businessOutcomes.VerifyQuoteIdentityAsync(
                quoteNumber,
                reopenedQuote,
                "save-reopen");
            Console.WriteLine(
                "[BusinessOutcome] Reopened quote identity matched the scenario.");
        }

        [When("user navigates to Submission page")]
        public async Task UserNavigatesToSubmissionPage()
        {
            var sideMenu = new SideMenuNavigation(_context.Page);
            await sideMenu.GoToSubmissionAsync();
        }

        [When(@"user navigates to the ""(.*)"" page via the left menu")]
        public async Task UserNavigatesToPageViaLeftMenu(string menuItem)
        {
            var sideMenu = new SideMenuNavigation(_context.Page);
            await sideMenu.GoToByNameAsync(menuItem);
            Console.WriteLine($"Navigated to '{menuItem}' via left menu");
        }

        [When("user navigates to Submission and opens Checklist")]
        public async Task UserNavigatesToSubmissionAndOpensChecklist()
        {
            var sideMenu = new SideMenuNavigation(_context.Page);
            await sideMenu.GoToSubmissionAsync();

            // Checklist opens in a new popup window — capture it and store in context
            _context.ChecklistPage = await SFP_ChecklistPage.OpenChecklistAsync(_context.Page);

            Console.WriteLine("Navigated to Submission and opened Checklist popup");
        }

        [Then("user verifies no referrals are needed")]
        public async Task UserVerifiesNoReferralsAreNeeded()
        {
            var submissionPage = new SubmissionPage(_context.Page);
            await submissionPage.WaitForSpinnerAsync();

            await submissionPage.NoReferralsText.WaitForAsync(new() { Timeout = 15000 });
            Assert.That(await submissionPage.NoReferralsText.CountAsync(), Is.GreaterThan(0),
                "Expected 'STATUS: NO REFERRAL NEEDED -- CONTINUE TO STEP 3' message on Submission page");

            Console.WriteLine("Verified: STATUS: NO REFERRAL NEEDED -- CONTINUE TO STEP 3");
        }

        [When("user completes Checklist item")]
        public async Task UserCompletesChecklistItem(Table table)
        {
            TableMappingHelpers.ChecklistItemFields(table, _contextData);

            var optional = table.Rows.Any(r => r["Question"].Equals("Optional", StringComparison.OrdinalIgnoreCase)
                                               && r["Answer"].Equals("Yes", StringComparison.OrdinalIgnoreCase));

            var checklistPage = new SFP_ChecklistPage(_context.ChecklistPage);
            await checklistPage.CompleteChecklistItemAsync(
                _contextData.ChecklistItemName,
                _contextData.ChecklistAction,
                _contextData.ChecklistExceptionNote,
                _contextData.ChecklistNote,
                skipIfNotFound: optional);

            Console.WriteLine($"Completed checklist item: {_contextData.ChecklistItemName}, Action: {_contextData.ChecklistAction}");
        }

        [When("user closes Checklist and confirms Update")]
        public async Task UserClosesChecklistAndConfirmsUpdate()
        {
            // 1. Close the checklist popup tab
            var checklistPage = new SFP_ChecklistPage(_context.ChecklistPage);
            await checklistPage.CloseAsync();

            // 2. Bring EQ tab back to the foreground
            await _context.Page.BringToFrontAsync();

            var submissionPage = new SubmissionPage(_context.Page);
            await submissionPage.WaitForSpinnerAsync();

            // 3. Dismiss the "Checklist Opened" modal. It's an Angular Material CDK overlay.
            //    Target the button inside .cdk-overlay-container — works regardless of button text.
            var overlayContainer = _context.Page.Locator(".cdk-overlay-container");
            var overlayButton = overlayContainer.Locator("button");
            try
            {
                await overlayButton.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 8000 });
                await overlayButton.First.ClickAsync();
                Console.WriteLine("Clicked Ok dialog on EQ Submission page");

                // Wait for modal container to clear instead of relying on network idle in SPA.
                await overlayContainer.WaitForAsync(new() { State = WaitForSelectorState.Hidden, Timeout = 10000 });
            }
            catch (TimeoutException)
            {
                Console.WriteLine("No overlay dialog appeared — continuing");
            }

            await submissionPage.WaitForSpinnerAsync();
            await submissionPage.NoReferralsText.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });
            Console.WriteLine("Checklist tab closed and EQ Submission page is ready");
        }

        [Then("user verifies Transmit action is available on Submission page")]
        public async Task UserVerifiesTransmitActionIsAvailable()
        {
            // Navigate to Submission explicitly — EQ may have moved after the Ok dialog
            var sideMenu = new SideMenuNavigation(_context.Page);
            await sideMenu.GoToSubmissionAsync();

            var submissionPage = new SubmissionPage(_context.Page);
            await submissionPage.WaitForSpinnerAsync();

            var availability =
                await submissionPage.GetTransmitAvailabilityAsync();
            await _businessOutcomes.VerifyTransmissionAvailabilityAsync(
                availability);
            Console.WriteLine(
                "[BusinessOutcome] Transmit action is available; no transmission was performed.");
        }

        private void ConfirmOutcomeProfileApplicability()
        {
            var environment =
                Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")
                ?? _configuration["Environment"]
                ?? "qa";
            var state =
                StateAbbreviations.ToAbbreviation(_contextData.RatingState);
            _businessOutcomeContext.ConfirmApplicability(
                environment,
                state,
                _contextData.WritingCompany);
        }

    }
}
