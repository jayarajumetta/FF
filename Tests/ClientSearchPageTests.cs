using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Pages.ExpertQuotePages;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class ClientSearchPageTests
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
        public async Task SearchForQuote_WaitsForLoadingStateAndExactResult()
        {
            await _page.SetContentAsync("""
                <input data-testid="quoteSearchInput">
                <button>Search</button>
                <div id="loading" style="display:none">Loading Quote</div>
                <table><tbody id="results"></tbody></table>
                <script>
                  document.querySelector('button').addEventListener('click', () => {
                    document.querySelector('#loading').style.display = 'block';
                    setTimeout(() => {
                      document.querySelector('#loading').style.display = 'none';
                      document.querySelector('#results').innerHTML =
                        '<tr><td><a>01106426</a></td></tr>';
                    }, 300);
                  });
                </script>
                """);

            await new ClientSearchPage(_page).SearchForQuoteAsync("01106426", 5000);

            Assert.That(
                await _page.GetByText("01106426", new() { Exact = true }).IsVisibleAsync(),
                Is.True);
        }
    }
}
