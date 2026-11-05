using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Hooks;
using PnCTestAutomation.Pages.ExpertQuotePages.SFP;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class RetryDiagnosticsTests
    {
        [TestCase("https://eq.example/expertquote/api/duckcreek/product?secret=123", "clas.example", "eq-product")]
        [TestCase("https://clas.example/express/search?quote=123", "clas.example", "clas")]
        [TestCase("https://other.example/express/search?quote=123", "clas.example", null)]
        [TestCase("not a url", "clas.example", null)]
        public void ClassifiesRequestsWithoutReturningUrls(string url, string clasHost, string expected) =>
            Assert.That(RetryDiagnostics.ClassifyUrl(url, clasHost), Is.EqualTo(expected));

        [TestCase("net::ERR_CONNECTION_RESET https://example.test/?secret=123", "net::ERR_CONNECTION_RESET")]
        [TestCase("failure with sensitive text", "unavailable")]
        [TestCase(null, "unavailable")]
        public void KeepsOnlySafeFailureCodes(string failure, string expected) =>
            Assert.That(RetryDiagnostics.FailureCode(failure), Is.EqualTo(expected));

        [TestCase(true, false, false, true)]
        [TestCase(false, true, true, true)]
        [TestCase(false, true, false, false)]
        [TestCase(false, false, true, false)]
        public void TraceRetentionIsExplicit(bool failed, bool completed, bool saveSuccess, bool expected) =>
            Assert.That(TestHooks.ShouldSaveTrace(failed, completed, saveSuccess), Is.EqualTo(expected));

        [Test]
        public async Task RecordsRequestOutcomesWithoutUrlsOrPayloads()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });
            await using var context = await browser.NewContextAsync();
            await context.RouteAsync("**/*", async route =>
            {
                if (route.Request.Url.Contains("abort", StringComparison.Ordinal))
                    await route.AbortAsync();
                else
                    await route.FulfillAsync(new() { Status = 200, Body = "ok" });
            });
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://example.test/");
            var events = new List<string>();
            using (RetryDiagnostics.Start(page, "https://clas.example/", events.Add))
            {
                var popup = await context.NewPageAsync();
                Assert.That(RetryDiagnostics.For(popup), Is.SameAs(RetryDiagnostics.For(page)));
                await page.EvaluateAsync("""
                    async () => {
                      await (await fetch('/api/duckcreek/product?secret=private')).text();
                      await fetch('/api/duckcreek/product?abort=private').catch(() => {});
                    }
                    """);
            }

            Assert.That(events.Any(line => line.Contains("target=eq-product")), Is.True);
            Assert.That(events.Any(line => line.Contains("status=200")), Is.True);
            Assert.That(events.Any(line => line.Contains("request-failed")), Is.True);
            Assert.That(string.Join("\n", events), Does.Not.Contain("private"));
            Assert.That(string.Join("\n", events), Does.Not.Contain("example.test"));
            Assert.That(RetryDiagnostics.For(page), Is.Null);
        }

        [Test]
        public async Task RecordsOptionalChecklistWaitsInPopupWithoutChangingSkipBehavior()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });
            await using var context = await browser.NewContextAsync();
            await context.RouteAsync("**/*", route => route.FulfillAsync(new() { Status = 200, Body = "<html></html>" }));
            var mainPage = await context.NewPageAsync();
            var checklistPage = await context.NewPageAsync();
            await checklistPage.GotoAsync("https://example.test/EChecklist/Viewing/offline");
            var events = new List<string>();
            using var diagnostics = RetryDiagnostics.Start(mainPage, "https://clas.example/", events.Add);
            var elapsed = Stopwatch.StartNew();

            await new SFP_ChecklistPage(checklistPage).CompleteChecklistItemAsync(
                "Easy Pay", "Exception", "not available", "", skipIfNotFound: true);

            Assert.That(elapsed.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(19500));
            Assert.That(events, Has.Some.Contains("item=easy-pay action=first-wait-timeout"));
            Assert.That(events, Has.Some.Contains("item=easy-pay action=retry-ready-start ssoAtStart=False"));
            Assert.That(events, Has.Some.Contains("item=easy-pay action=retry-wait-timeout-skipped"));
        }
    }
}
