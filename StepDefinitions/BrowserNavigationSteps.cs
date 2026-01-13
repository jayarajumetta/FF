
using NUnit.Framework;
using Playwright_POC.Services;
using Reqnroll;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Playwright_POC.StepDefinitions
{
    [Binding]
    public class NavigationSteps
    {
        private readonly NavigationService _nav;

        public NavigationSteps(NavigationService nav)
        {
            _nav = nav;
        }

        [Given(@"I navigate to the Expert Quote login page")]
        public async Task GivenIStartInExpertQuote() => await _nav.GoToExpertQuoteAsync();

        [Then(@"user switches to QAExpress")]
        public async Task WhenISwitchToQAExpress() => await _nav.GoToQAExpressAsync();

        [When(@"I return to ExpertQuote")]
        public async Task WhenIReturnToExpertQuote() => await _nav.GoToExpertQuoteAsync();

        // --- Assertions (NUnit) ---

        [Then(@"I should be on ExpertQuote")]
        public async Task ThenIShouldBeOnExpertQuote()
        {
            // Validate by URL
            var url = await _nav.Page.EvaluateAsync<string>("() => window.location.href");

            // Option A: StringAssert
            Assert.That(url, Does.Contain("expertquote-qa"));

            // Option B: Assert.That with constraint syntax (pick one style)
            // Assert.That(url, Does.Contain("expertquote-qa"));

            // Optional: element-based readiness check (replace with a stable EQ selector if you have one)
            // await _nav.Page.Locator("#main, [data-app='ExpertQuote']").WaitForAsync(new() { Timeout = 30000 });
        }

        [Then(@"I should be on QAExpress")]
        public async Task ThenIShouldBeOnQAExpress()
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
