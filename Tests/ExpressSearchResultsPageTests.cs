using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Pages.ExpressPages;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class ExpressSearchResultsPageTests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;

        [OneTimeSetUp]
        public async Task StartBrowser()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new() { Headless = true });
        }

        [SetUp]
        public async Task CreatePage()
        {
            _context = await _browser.NewContextAsync();
            await _context.RouteAsync("**/*", route => route.AbortAsync());
            _page = await _context.NewPageAsync();
        }

        [TearDown]
        public async Task ClosePage() => await _context.DisposeAsync();

        [OneTimeTearDown]
        public async Task CloseBrowser()
        {
            if (_browser != null)
                await _browser.DisposeAsync();
            _playwright?.Dispose();
        }

        [Test]
        public async Task OpensExactQuoteInCurrentGridRatherThanFirstOrPartialMatch()
        {
            await _page.SetContentAsync("""
                <table>
                  <tr><td><div columnref="quoteList_policyNumber">021073970</div></td>
                      <td><a id="quoteListLoadQuoteA" href="#" data-quote="wrong"><img title="View Policy"></a></td></tr>
                  <tr><td><div columnref="quoteList_policyNumber"> 02107397 </div></td>
                      <td><a id="quoteListLoadQuoteA" href="#" data-quote="correct"><img title="View Policy"></a></td></tr>
                </table>
                <script>
                  document.querySelectorAll('a').forEach(a => a.onclick = e => {
                    e.preventDefault(); window.openedQuote = a.dataset.quote;
                  });
                </script>
                """);

            await new ExpressSearchResultsPage(_page).OpenExactQuoteAsync("02107397");
            Assert.That(await _page.EvaluateAsync<string>("window.openedQuote"), Is.EqualTo("correct"));
        }

        [Test]
        public async Task OpensExactQuoteInLegacyGrid()
        {
            await _page.SetContentAsync("""
                <table>
                  <tr><td><p fieldref="PolicyInput.PolicyNumber">02107397</p></td>
                      <td><button title="View Policy" onclick="window.openedQuote='legacy'">View</button></td></tr>
                </table>
                """);

            await new ExpressSearchResultsPage(_page).OpenExactQuoteAsync("02107397");
            Assert.That(await _page.EvaluateAsync<string>("window.openedQuote"), Is.EqualTo("legacy"));
        }

        [Test]
        public async Task OpensExactQuoteInDuckCreekHypergrid()
        {
            await _page.SetContentAsync("""
                <style>dc-hypergrid-row { display: block; }</style>
                <dc-hypergrid-row class="table-row-container">
                  <div class="table-row">
                    <dc-hypergrid-cell><p fieldref="PolicyInput.PolicyNumber">021076900</p></dc-hypergrid-cell>
                    <dc-hypergrid-cell><button title="View Policy" onclick="window.openedQuote='wrong'">View</button></dc-hypergrid-cell>
                  </div>
                </dc-hypergrid-row>
                <dc-hypergrid-row class="table-row-container">
                  <div class="table-row">
                    <dc-hypergrid-cell><p fieldref="PolicyInput.PolicyNumber">02107690</p></dc-hypergrid-cell>
                    <dc-hypergrid-cell>
                      <button title="View Policy Details" onclick="window.openedQuote='details'">Details</button>
                      <button title="View Policy" actionref="ViewPolicy" onclick="window.openedQuote='correct'">View</button>
                    </dc-hypergrid-cell>
                  </div>
                </dc-hypergrid-row>
                """);

            await new ExpressSearchResultsPage(_page).OpenExactQuoteAsync("02107690");
            Assert.That(await _page.EvaluateAsync<string>("window.openedQuote"), Is.EqualTo("correct"));
        }

        [Test]
        public async Task DuplicateDuckCreekHypergridMatchesFailWithoutOpeningEitherQuote()
        {
            await _page.SetContentAsync("""
                <style>dc-hypergrid-row { display: block; }</style>
                <dc-hypergrid-row>
                  <p fieldref="PolicyInput.PolicyNumber">02107690</p>
                  <button title="View Policy" onclick="window.openedQuote=true">View</button>
                </dc-hypergrid-row>
                <dc-hypergrid-row>
                  <p fieldref="PolicyInput.PolicyNumber">02107690</p>
                  <button title="View Policy" onclick="window.openedQuote=true">View</button>
                </dc-hypergrid-row>
                """);

            var error = Assert.ThrowsAsync<InvalidOperationException>(() =>
                new ExpressSearchResultsPage(_page).OpenExactQuoteAsync("02107690", timeoutMs: 300));
            Assert.That(error!.Message, Does.Contain("found 2"));
            Assert.That(await _page.EvaluateAsync<bool>("window.openedQuote === true"), Is.False);
        }

        [Test]
        public async Task PartialMatchDoesNotOpenAnotherQuote()
        {
            await _page.SetContentAsync("""
                <table><tr><td><div columnref="quoteList_policyNumber">021073970</div></td>
                  <td><a id="quoteListLoadQuoteA" href="#" onclick="window.openedQuote=true"><img title="View Policy"></a></td>
                </tr></table>
                """);

            Assert.ThrowsAsync<TimeoutException>(() =>
                new ExpressSearchResultsPage(_page).OpenExactQuoteAsync("02107397", timeoutMs: 300));
            Assert.That(await _page.EvaluateAsync<bool>("window.openedQuote === true"), Is.False);
        }

        [Test]
        public async Task DuplicateVisibleMatchesFailWithoutOpeningEitherQuote()
        {
            await _page.SetContentAsync("""
                <table>
                  <tr><td><div columnref="quoteList_policyNumber">02107397</div></td>
                      <td><a id="quoteListLoadQuoteA" href="#" onclick="window.openedQuote=true"><img title="View Policy"></a></td></tr>
                  <tr><td><div columnref="quoteList_policyNumber">02107397</div></td>
                      <td><a id="quoteListLoadQuoteA" href="#" onclick="window.openedQuote=true"><img title="View Policy"></a></td></tr>
                </table>
                """);

            var error = Assert.ThrowsAsync<InvalidOperationException>(() =>
                new ExpressSearchResultsPage(_page).OpenExactQuoteAsync("02107397", timeoutMs: 300));
            Assert.That(error!.Message, Does.Contain("found 2"));
            Assert.That(await _page.EvaluateAsync<bool>("window.openedQuote === true"), Is.False);
        }

        [Test]
        public async Task DoesNotOpenTheDetailsActionWhenViewPolicyIsMissing()
        {
            await _page.SetContentAsync("""
                <table><tr><td><div columnref="quoteList_policyNumber">02107397</div></td>
                  <td><a href="#" onclick="window.openedQuote=true"><img title="View Policy Details"></a></td>
                </tr></table>
                """);

            Assert.ThrowsAsync<TimeoutException>(() =>
                new ExpressSearchResultsPage(_page).OpenExactQuoteAsync("02107397", timeoutMs: 300));
            Assert.That(await _page.EvaluateAsync<bool>("window.openedQuote === true"), Is.False);
        }
    }
}
