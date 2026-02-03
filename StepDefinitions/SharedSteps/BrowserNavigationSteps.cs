using Playwright_POC.Services;
using Reqnroll;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace TestAutomation.StepDefinitions.SharedSteps
{
    [Binding]
    public class NavigationSteps
    {
        private readonly NavigationService _nav;

        public NavigationSteps(NavigationService nav)
        {
            _nav = nav;
        }

        [StepDefinition(@"I navigate to the Expert Quote login page")]
        public async Task NavigateToExpertQuoteLogin() => await _nav.GoToExpertQuoteAsync();

        [StepDefinition(@"user switches to QAExpress")]
        public async Task SwitchToQAExpress() => await _nav.GoToQAExpressAsync();

        [StepDefinition(@"I return to ExpertQuote")]
        public async Task ReturnToExpertQuote() => await _nav.GoToExpertQuoteAsync();

        // --- Assertions (Playwright Expect) ---

        [StepDefinition(@"I should be on ExpertQuote")]
        public async Task VerifyOnExpertQuote()
        {
            // Validate by URL using Playwright Expect
            await Expect(_nav.Page).ToHaveURLAsync(new Regex("expertquote-qa"));

            // Optional: element-based readiness check (replace with a stable EQ selector if you have one)
            // await _nav.Page.Locator("#main, [data-app='ExpertQuote']").WaitForAsync(new() { Timeout = 30000 });
        }

        [StepDefinition(@"I should be on QAExpress")]
        public async Task VerifyOnQAExpress()
        {
            // Confirm final route after possible SSO redirects
            await _nav.Page.WaitForURLAsync(
                new Regex(@"express/defaultViewmodel", RegexOptions.IgnoreCase),
                new() { Timeout = 30000 });

            // Optional: element-based readiness check (replace with a stable Express selector)
            // await _nav.Page.Locator("[data-viewmodel], #express-root").WaitForAsync(new() { Timeout = 30000 });
        }
    }
}
