// Tools/LocatorScan/LocatorScanTool.cs
//
// ─────────────────────────────────────────────────────────────────
// USAGE (PowerShell examples)
// ─────────────────────────────────────────────────────────────────
//
// ── FAST SCAN (default, ~10-30 seconds) ──
//   # Attach to existing Chrome and scan current page quickly
//   dotnet test --filter "Category=Tools&Name~Scan" `
//     -- TestRunParameters.Parameter(name=\"CDP\",value=\"http://localhost:9222\")
//
// ── FULL SCAN (with all candidates, ~1-2 minutes) ──
//   dotnet test --filter "Category=Tools&Name~Scan" `
//     -- TestRunParameters.Parameter(name=\"CDP\",value=\"http://localhost:9222\") `
//        TestRunParameters.Parameter(name=\"FAST_MODE\",value=\"false\")
//
// ── With URL navigation ──
//   dotnet test --filter "Category=Tools&Name~Scan" `
//     -- TestRunParameters.Parameter(name=\"CDP\",value=\"http://localhost:9222\") `
//        TestRunParameters.Parameter(name=\"URL\",value=\"https://example.com/page\")
//
// ── Headless URL mode ──
//   dotnet test --filter "Category=Tools&Name~Scan" `
//     -- TestRunParameters.Parameter(name=\"URL\",value=\"https://example.com\")
//
// ── PARAMETERS ──
//   FAST_MODE     (default: true)  - Limits candidates per element for performance
//   CS_ONLY       (default: true)  - Only generate .cs locator file (no CSV/JSON)
//   SCAN_HIDDEN   (default: true)  - Include hidden/conditional elements (dropdowns, modals, etc)
//   COMPARE       (default: true)  - Compare against existing repo locators and exclude duplicates
//   NEW_ONLY      (default: false) - Only show elements not in repo (requires COMPARE=true)
//   SCENARIO      (optional)       - Name for output folder
// ─────────────────────────────────────────────────────────────────

#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PnCTestAutomation.Tools.LocatorScan
{
    [TestFixture]
    public class LocatorScanTool
    {
        [Test]
        [Category("Tools")]
        [Description("Scan a page by URL or attach to an existing browser; rank locators, describe intent, and compare with repo to avoid duplicates.")]
        public async Task Scan()
        {
            // ── Read parameters ──
            var url = TestContext.Parameters.Get("URL", "");
            var cdp = TestContext.Parameters.Get("CDP", "");
            var headed = string.Equals(
                TestContext.Parameters.Get("HEADED", "false"), "true", StringComparison.OrdinalIgnoreCase);
            var scenario = TestContext.Parameters.Get("SCENARIO", "");

            // PERFORMANCE: FAST_MODE (default: true) - limits candidates per element
            var fastMode = string.Equals(
                TestContext.Parameters.Get("FAST_MODE", "true"), "true", StringComparison.OrdinalIgnoreCase);

            // Individual overrides
            var compare = string.Equals(
                TestContext.Parameters.Get("COMPARE", "true"), "true", StringComparison.OrdinalIgnoreCase);
            var newOnly = string.Equals(
                TestContext.Parameters.Get("NEW_ONLY", "false"), "true", StringComparison.OrdinalIgnoreCase);

            // Output control - CS_ONLY=true (default) generates only .cs file, no CSV/JSON
            var skipCsv = string.Equals(
                TestContext.Parameters.Get("CS_ONLY", "true"), "true", StringComparison.OrdinalIgnoreCase);
            var skipJson = true;  // JSON output disabled

            // Hidden element scanning - includes elements hidden via CSS (modals, dropdowns, conditional fields)
            var scanHidden = string.Equals(
                TestContext.Parameters.Get("SCAN_HIDDEN", "true"), "true", StringComparison.OrdinalIgnoreCase);

            // Derive scenario name from URL if not provided
            if (string.IsNullOrWhiteSpace(scenario))
            {
                scenario = "LocatorScan";
                if (!string.IsNullOrWhiteSpace(url))
                {
                    try
                    {
                        var uri = new Uri(url);
                        scenario = (uri.Host + uri.AbsolutePath)
                            .Replace("/", "_").Replace(".", "_").Trim('_');
                    }
                    catch { /* keep default */ }
                }
            }

            // Validate
            if (string.IsNullOrWhiteSpace(url) && string.IsNullOrWhiteSpace(cdp))
            {
                Assert.Fail(
                    "Provide at least URL or CDP parameter.\n" +
                    "Example: -- TestRunParameters.Parameter(name=\"URL\",value=\"https://example.com\")");
            }

            // ── Prepare output directory ──
            var timestamp = DateTime.Now.ToString("ddMMMyyyy").ToUpper();
            var repoRoot = FindRepoRoot();
            var outputDir = Path.Combine(repoRoot, "TestResults", timestamp, scenario);
            Directory.CreateDirectory(outputDir);

            TestContext.Progress.WriteLine($"[LocatorScanTool] Output dir: {outputDir}");
            TestContext.Progress.WriteLine($"[LocatorScanTool] URL={url}  CDP={cdp}  FAST_MODE={fastMode}  COMPARE={compare}");

            // ── Set up Playwright ──
            IPlaywright? pw = null;
            IBrowser? browser = null;
            IBrowserContext? context = null;
            IPage? page = null;
            var ownsBrowser = false;

            try
            {
                pw = await Playwright.CreateAsync();

                if (!string.IsNullOrWhiteSpace(cdp))
                {
                    // ── Attach via CDP ──
                    TestContext.Progress.WriteLine($"[LocatorScanTool] Attaching via CDP: {cdp}");
                    browser = await pw.Chromium.ConnectOverCDPAsync(cdp);
                    context = browser.Contexts.FirstOrDefault() ?? await browser.NewContextAsync();

                    // Get all pages and filter to actual content pages (not chrome://, extensions, etc.)
                    var allPages = context.Pages.ToList();
                    var contentPages = allPages
                        .Where(p => !string.IsNullOrEmpty(p.Url)
                            && !p.Url.StartsWith("chrome://")
                            && !p.Url.StartsWith("chrome-extension://")
                            && !p.Url.StartsWith("about:"))
                        .ToList();

                    TestContext.Progress.WriteLine($"[LocatorScanTool] Found {allPages.Count} total pages, {contentPages.Count} content pages");

                    // Use LAST content page (most recently opened/active) instead of first
                    page = contentPages.LastOrDefault() ?? allPages.FirstOrDefault();

                    if (page is null)
                    {
                        page = await context.NewPageAsync();
                    }

                    // Bring this page to front and force DOM refresh
                    await page.BringToFrontAsync();
                    await page.WaitForTimeoutAsync(200); // Brief wait for focus

                    // Debug: Show current page info
                    var currentUrl = page.Url;
                    var pageTitle = await page.TitleAsync();
                    TestContext.Progress.WriteLine($"[LocatorScanTool] Current page URL: {currentUrl}");
                    TestContext.Progress.WriteLine($"[LocatorScanTool] Page title: '{pageTitle}'");

                    // If URL also provided, navigate
                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        TestContext.Progress.WriteLine($"[LocatorScanTool] Navigating to: {url}");
                        await page.GotoAsync(url, new PageGotoOptions
                        {
                            WaitUntil = WaitUntilState.DOMContentLoaded,
                            Timeout = 30_000
                        });
                    }
                    else if (string.IsNullOrEmpty(currentUrl) || currentUrl == "about:blank" || currentUrl.StartsWith("chrome://") || currentUrl.StartsWith("chrome-extension://"))
                    {
                        // Navigate to ExpertQuote if no specific URL and current page is blank/chrome/extension
                        var defaultUrl = "https://expertquote-qa.americannational.com/expertquote/#/quote";
                        TestContext.Progress.WriteLine($"[LocatorScanTool] Page is blank/chrome/extension, navigating to: {defaultUrl}");
                        await page.GotoAsync(defaultUrl, new PageGotoOptions
                        {
                            WaitUntil = WaitUntilState.DOMContentLoaded,
                            Timeout = 30_000
                        });
                    }
                }
                else
                {
                    // ── URL mode ──
                    ownsBrowser = true;
                    browser = await pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = !headed
                    });
                    context = await browser.NewContextAsync(new BrowserNewContextOptions
                    {
                        ViewportSize = new ViewportSize { Width = 1920, Height = 1080 }
                    });
                    page = await context.NewPageAsync();
                    TestContext.Progress.WriteLine($"[LocatorScanTool] Navigating to: {url}");
                    await page.GotoAsync(url!, new PageGotoOptions
                    {
                        WaitUntil = WaitUntilState.DOMContentLoaded,
                        Timeout = 30_000
                    });
                }

                // Wait for the page to fully render before scanning
                TestContext.Progress.WriteLine("[LocatorScanTool] Waiting for page to fully render...");

                try
                {
                    // Wait for Angular to be ready (if present) - reduced timeout since page is already loaded
                    await page.WaitForFunctionAsync(
                        "() => window.getAllAngularTestabilities && window.getAllAngularTestabilities().findIndex(x=>!x.isStable()) === -1",
                        new PageWaitForFunctionOptions { Timeout = 2000 });
                    TestContext.Progress.WriteLine("[LocatorScanTool] Angular stability confirmed.");
                }
                catch
                {
                    // Angular 17+ / zoneless apps may not expose getAllAngularTestabilities.
                    // Wait for input elements to appear in the DOM instead.
                    TestContext.Progress.WriteLine("[LocatorScanTool] Angular stability API not available, waiting for DOM readiness...");
                    try
                    {
                        await page.WaitForFunctionAsync(
                            "() => document.querySelectorAll('input').length > 0",
                            new PageWaitForFunctionOptions { Timeout = 5000 });
                        await page.WaitForTimeoutAsync(500);
                        TestContext.Progress.WriteLine("[LocatorScanTool] DOM readiness confirmed.");
                    }
                    catch
                    {
                        TestContext.Progress.WriteLine("[LocatorScanTool] DOM readiness timeout, using fallback delay.");
                        await page.WaitForTimeoutAsync(2000);
                    }
                }

                // Detect current section from UI
                var sectionName = await page.EvaluateAsync<string?>(@"() => {
                    // Try h1 first
                    const h1 = document.querySelector('h1');
                    if (h1 && h1.textContent.trim() && h1.textContent.trim() !== 'ExpertQuote') {
                        return h1.textContent.trim();
                    }
                    // Try active nav item
                    const activeNav = document.querySelector('.menu-item.active, .nav-item.active, [class*=""nav""][class*=""active""]');
                    return activeNav ? activeNav.textContent.trim() : null;
                }");
                if (!string.IsNullOrEmpty(sectionName))
                {
                    TestContext.Progress.WriteLine($"[LocatorScanTool] Page section: '{sectionName}'");
                }

                // Final check: count DOM elements to see if page has content
                var elementCount = await page.EvaluateAsync<int>("() => document.querySelectorAll('*').length");
                TestContext.Progress.WriteLine($"[LocatorScanTool] Page has {elementCount} total DOM elements.");
                var interactableCount = await page.EvaluateAsync<int>("() => document.querySelectorAll('input, button, select, textarea, [onclick], [role=\"button\"]').length");
                TestContext.Progress.WriteLine($"[LocatorScanTool] Found {interactableCount} potentially interactable elements in DOM.");

                // DEBUG: Check for iframes
                var iframeCount = await page.EvaluateAsync<int>("() => document.querySelectorAll('iframe').length");
                TestContext.Progress.WriteLine($"[LocatorScanTool] Iframes on page: {iframeCount}");

                // DEBUG: Check for Angular Material components directly
                var matCheckboxCount = await page.EvaluateAsync<int>("() => document.querySelectorAll('mat-checkbox, .mat-checkbox').length");
                var matSelectCount = await page.EvaluateAsync<int>("() => document.querySelectorAll('mat-select, .mat-select').length");
                var matRadioCount = await page.EvaluateAsync<int>("() => document.querySelectorAll('mat-radio-button, .mat-radio-button').length");
                TestContext.Progress.WriteLine($"[LocatorScanTool] Angular Material components: mat-checkbox={matCheckboxCount}, mat-select={matSelectCount}, mat-radio={matRadioCount}");

                // DEBUG: Check for any input with coverage/policy in id
                var coverageInputs = await page.EvaluateAsync<int>("() => document.querySelectorAll('input[id*=\"policy\"], input[id*=\"Coverage\"], input[id*=\"coverage\"]').length");
                TestContext.Progress.WriteLine($"[LocatorScanTool] Coverage/policy inputs: {coverageInputs}");

                // ── Scan ──
                var scanOptions = new LocatorScanOptions
                {
                    MaxCandidates = fastMode ? 2 : 5,  // Limit candidates per element
                    VisibleOnly = !scanHidden  // Scan hidden elements if SCAN_HIDDEN=true
                };

                var scanner = new LocatorScanner();
                TestContext.Progress.WriteLine("[LocatorScanTool] Scanning page for interactable elements...");
                var reports = await scanner.ScanAsync(page, scanOptions);
                TestContext.Progress.WriteLine($"[LocatorScanTool] Found {reports.Count} interactable elements.");

                // ── Repo comparison ──
                List<ExistingLocator>? inventory = null;
                if (compare)
                {
                    TestContext.Progress.WriteLine("[LocatorScanTool] Building repo locator inventory...");
                    var inventoryBuilder = new RepoLocatorInventory();
                    inventory = await inventoryBuilder.BuildAsync(repoRoot);
                    TestContext.Progress.WriteLine($"[LocatorScanTool] Inventory: {inventory.Count} existing locators found.");

                    // Annotate
                    var matchEngine = new LocatorMatchEngine();
                    await matchEngine.AnnotateWithRepoMatchesAsync(reports, inventory);

                    var exactCount = reports.Count(r => r.ExistingMatches.Any(m => m.MatchType == "Exact"));
                    var nearCount = reports.Count(r =>
                        !r.ExistingMatches.Any(m => m.MatchType == "Exact") &&
                        r.ExistingMatches.Any(m => m.MatchType == "Near"));
                    var newCount = reports.Count - exactCount - nearCount;

                    TestContext.Progress.WriteLine($"[LocatorScanTool] Matches: {exactCount} exact, {nearCount} near, {newCount} new.");

                    // Filter if NEW_ONLY
                    if (newOnly)
                    {
                        reports = matchEngine.OnlyWithoutExactMatch(reports);
                        TestContext.Progress.WriteLine($"[LocatorScanTool] After NEW_ONLY filter: {reports.Count} elements remain.");
                    }
                }

                // ── Write artifacts ──
                if (!skipJson)
                {
                    var jsonPath = Path.Combine(outputDir, "locator-scan.json");
                    await scanner.WriteJsonAsync(reports, jsonPath);
                    TestContext.Progress.WriteLine($"[LocatorScanTool] JSON written: {jsonPath}");
                }

                if (!skipCsv)
                {
                    var csvPath = Path.Combine(outputDir, "locator-scan.csv");
                    if (compare)
                        scanner.WriteCsvWithRepoColumns(reports, csvPath);
                    else
                        await scanner.WriteCsvAsync(reports, csvPath);
                    TestContext.Progress.WriteLine($"[LocatorScanTool] CSV written:  {csvPath}");
                }

                // ── Generate Locator File ──
                // Generated .cs goes to Pages/_Staged/ so it appears immediately in VS Solution Explorer.
                // Raw artifacts (CSV/JSON) stay in the timestamped TestResults folder.
                var stagedDir = Path.Combine(repoRoot, "Pages", "_Staged");
                Directory.CreateDirectory(stagedDir);
                await LocatorFileGenerator.GenerateLocatorFileAsync(reports, stagedDir, page);

                // ── Summary ──
                TestContext.Progress.WriteLine("─────────────────────────────────────────");
                TestContext.Progress.WriteLine("[LocatorScanTool] ✅ Scan complete.");
                TestContext.Progress.WriteLine($"  Artifacts: {outputDir}");
                TestContext.Progress.WriteLine($"  Generated .cs: {stagedDir}");
                TestContext.Progress.WriteLine("─────────────────────────────────────────");
            }
            finally
            {
                if (ownsBrowser)
                {
                    if (context is not null)
                        await context.CloseAsync();
                    if (browser is not null)
                        await browser.CloseAsync();
                }
                pw?.Dispose();
            }
        }

        // ── Helpers ──

        /// <summary>
        /// Walk up from the current directory to find the repo root
        /// (contains TestAutomation.csproj or .git).
        /// </summary>
        private static string FindRepoRoot()
        {
            var dir = TestContext.CurrentContext.TestDirectory
                ?? AppContext.BaseDirectory;

            while (!string.IsNullOrEmpty(dir))
            {
                if (File.Exists(Path.Combine(dir, "TestAutomation.csproj")) ||
                    Directory.Exists(Path.Combine(dir, ".git")))
                {
                    return dir;
                }
                dir = Path.GetDirectoryName(dir);
            }

            // Fallback: use working directory
            return Directory.GetCurrentDirectory();
        }
    }
}
