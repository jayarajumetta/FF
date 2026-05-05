using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playwright_POC.Helpers
{
    /// <summary>
    /// Lightweight on-failure locator rescue. When a locator can't find an element,
    /// this service runs a targeted DOM scan to find candidates by:
    ///   1. Partial / fuzzy data-testid match
    ///   2. Visible text match
    ///   3. aria-label match
    ///   4. Role + accessible name match
    ///
    /// Results are logged to test output. If <see cref="LocatorRescueOptions.AutoHeal"/>
    /// is enabled, the best candidate is returned for the test to continue.
    /// </summary>
    public static class LocatorRescueService
    {
        // ── JS injected into the page — lightweight, targeted scan ─────
        private const string RescueScanScript = @"
(failedSelector) => {
    const results = [];
    const norm = s => (s || '').replace(/\s+/g, ' ').trim();

    // Extract the test-id value from common selector patterns
    function extractTestId(sel) {
        // GetByTestId('x') resolves to [data-testid='x']
        let m = sel.match(/data-testid[=~|^$*]*[""']([^""']+)[""']/i);
        if (m) return m[1];
        // Fallback: the selector itself might be the bare test-id
        if (!sel.includes('[') && !sel.includes('#') && !sel.includes('.'))
            return sel;
        return null;
    }

    const failedTestId = extractTestId(failedSelector);

    // Gather all visible interactable elements on the page
    const tags = 'button,a,input,select,textarea,mat-checkbox,mat-select,mat-slide-toggle,mat-radio-button,mat-button-toggle,[role=""button""],[role=""link""],[role=""checkbox""],[role=""radio""],[role=""combobox""],[role=""textbox""],[role=""tab""]';
    const allEls = Array.from(document.querySelectorAll(tags));

    for (const el of allEls) {
        if (el.offsetParent === null && el.tagName !== 'INPUT') continue; // skip hidden

        const testId  = el.getAttribute('data-testid') || '';
        const text    = norm(el.textContent).substring(0, 120);
        const ariaLbl = el.getAttribute('aria-label') || '';
        const role    = el.getAttribute('role') || el.tagName.toLowerCase();
        const name    = el.getAttribute('name') || '';
        const id      = el.id || '';
        const tag     = el.tagName.toLowerCase();
        const type    = el.getAttribute('type') || '';

        // Compute relevance score
        let score = 0;
        let matchReason = '';

        if (failedTestId && testId) {
            // Exact match would mean locator didn't fail — shouldn't happen
            if (testId === failedTestId) { score += 100; matchReason = 'exact-testid'; }
            // Segment overlap: compare dot-separated segments
            else {
                const failedParts = failedTestId.split(/[.$]/);
                const candidateParts = testId.split(/[.$]/);
                const shared = failedParts.filter(p => candidateParts.includes(p)).length;
                const overlap = shared / Math.max(failedParts.length, 1);
                if (overlap >= 0.5) {
                    score += Math.round(overlap * 60);
                    matchReason = 'partial-testid(' + Math.round(overlap * 100) + '%)';
                }
                // Substring containment
                else if (testId.includes(failedTestId) || failedTestId.includes(testId)) {
                    score += 40;
                    matchReason = 'substring-testid';
                }
            }
        }

        // Boost if the visible text matches any part of the failed selector
        if (failedTestId && text) {
            const keyword = failedTestId.split(/[.$]/).pop();
            if (keyword && text.toLowerCase().includes(keyword.toLowerCase())) {
                score += 20;
                matchReason += (matchReason ? '+' : '') + 'text-keyword';
            }
        }

        // Only include elements with some relevance
        if (score > 0) {
            results.push({ testId, text, ariaLbl, role, name, id, tag, type, score, matchReason });
        }
    }

    // Sort descending by score, return top 5
    results.sort((a, b) => b.score - a.score);
    return results.slice(0, 5);
}";

        /// <summary>
        /// Attempt to rescue a failed locator by scanning the current DOM for candidates.
        /// </summary>
        /// <param name="page">The Playwright page to scan.</param>
        /// <param name="failedSelector">The original selector string that failed.</param>
        /// <param name="options">Rescue behavior options.</param>
        /// <returns>
        /// A <see cref="RescueResult"/> containing candidates found and, if auto-heal is on,
        /// a usable <see cref="ILocator"/> for the best match.
        /// </returns>
        public static async Task<RescueResult> TryRescueAsync(
            IPage page,
            string failedSelector,
            LocatorRescueOptions options = null)
        {
            options ??= LocatorRescueOptions.Default;
            var result = new RescueResult { OriginalSelector = failedSelector };

            try
            {
                var candidates = await page.EvaluateAsync<List<RescueCandidate>>(
                    RescueScanScript, failedSelector);

                if (candidates == null || candidates.Count == 0)
                {
                    LogRescue(options, $"[LocatorRescue] FAILED — no candidates found for: {failedSelector}");
                    return result;
                }

                result.Candidates = candidates;

                // Log all candidates
                LogRescue(options, $"[LocatorRescue] Original selector failed: {failedSelector}");
                LogRescue(options, $"[LocatorRescue] Found {candidates.Count} candidate(s):");
                for (int i = 0; i < candidates.Count; i++)
                {
                    var c = candidates[i];
                    var locatorHint = !string.IsNullOrEmpty(c.TestId)
                        ? $"GetByTestId(\"{c.TestId}\")"
                        : !string.IsNullOrEmpty(c.Id)
                            ? $"Locator(\"#{c.Id}\")"
                            : !string.IsNullOrEmpty(c.AriaLbl)
                                ? $"GetByLabel(\"{c.AriaLbl}\")"
                                : $"GetByRole({c.Role}, \"{c.Text}\")";

                    LogRescue(options,
                        $"  [{i + 1}] score={c.Score} reason={c.MatchReason} → {locatorHint}");
                }

                // Build healed locator from best candidate
                var best = candidates[0];
                result.BestCandidate = best;
                result.HealedLocator = BuildLocator(page, best);
                result.WasHealed = options.AutoHeal;

                if (options.AutoHeal)
                {
                    LogRescue(options,
                        $"[LocatorRescue] AUTO-HEAL ON — using candidate #1 (score={best.Score})");
                }
                else
                {
                    LogRescue(options,
                        $"[LocatorRescue] AUTO-HEAL OFF — candidates logged but test will fail as normal.");
                }
            }
            catch (Exception ex)
            {
                LogRescue(options,
                    $"[LocatorRescue] Rescue scan itself failed: {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// Wraps a Playwright action with locator rescue. If the action throws because the
        /// element wasn't found, runs rescue and optionally retries with the healed locator.
        /// </summary>
        public static async Task<ILocator> ResolveLocatorAsync(
            IPage page,
            ILocator original,
            string selectorHint,
            LocatorRescueOptions options = null)
        {
            options ??= LocatorRescueOptions.Default;

            // If rescue is disabled, skip entirely
            if (!options.Enabled)
                return original;

            // Fast path: element exists — no rescue needed
            try
            {
                var count = await original.CountAsync();
                if (count > 0)
                    return original;
            }
            catch
            {
                // Locator evaluation itself failed — proceed to rescue
            }

            // Element not found — run rescue
            var result = await TryRescueAsync(page, selectorHint, options);

            if (result.WasHealed && result.HealedLocator != null)
            {
                // Verify the healed locator actually finds something
                var healedCount = await result.HealedLocator.CountAsync();
                if (healedCount > 0)
                    return result.HealedLocator;

                LogRescue(options,
                    "[LocatorRescue] Healed locator found 0 elements — falling back to original.");
            }

            // Return original so the caller gets Playwright's normal error
            return original;
        }

        private static ILocator BuildLocator(IPage page, RescueCandidate candidate)
        {
            if (!string.IsNullOrEmpty(candidate.TestId))
                return page.GetByTestId(candidate.TestId);
            if (!string.IsNullOrEmpty(candidate.Id))
                return page.Locator($"#{candidate.Id}");
            if (!string.IsNullOrEmpty(candidate.AriaLbl))
                return page.GetByLabel(candidate.AriaLbl);
            if (!string.IsNullOrEmpty(candidate.Name))
                return page.Locator($"[name='{candidate.Name}']");
            // Last resort: role + text
            return page.GetByRole(
                MapRole(candidate.Role),
                new() { Name = candidate.Text });
        }

        private static AriaRole MapRole(string role)
        {
            return (role ?? "").ToLowerInvariant() switch
            {
                "button" => AriaRole.Button,
                "link" or "a" => AriaRole.Link,
                "checkbox" or "mat-checkbox" => AriaRole.Checkbox,
                "radio" or "mat-radio-button" => AriaRole.Radio,
                "combobox" or "select" or "mat-select" => AriaRole.Combobox,
                "textbox" or "input" or "textarea" => AriaRole.Textbox,
                "tab" => AriaRole.Tab,
                _ => AriaRole.Generic
            };
        }

        private static void LogRescue(LocatorRescueOptions options, string message)
        {
            options.LogAction?.Invoke(message);
            Console.WriteLine(message);
        }
    }

    // ── Configuration ──────────────────────────────────────────────────
    public class LocatorRescueOptions
    {
        /// <summary>
        /// When true, the best candidate locator is used automatically so the test
        /// can continue. When false, candidates are logged but the test fails normally.
        /// Default: false (log-only mode).
        /// </summary>
        public bool AutoHeal { get; set; }

        /// <summary>
        /// When false, rescue is completely skipped (no DOM scan, no logging).
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Optional logging callback (e.g. TestContext.WriteLine or ILogger).
        /// Messages are always written to Console.WriteLine as well.
        /// </summary>
        public Action<string> LogAction { get; set; }

        public static LocatorRescueOptions Default => new() { AutoHeal = false, Enabled = true };
        public static LocatorRescueOptions Disabled => new() { AutoHeal = false, Enabled = false };
    }

    // ── Result model ───────────────────────────────────────────────────
    public class RescueResult
    {
        public string OriginalSelector { get; set; }
        public List<RescueCandidate> Candidates { get; set; } = new();
        public RescueCandidate BestCandidate { get; set; }
        public ILocator HealedLocator { get; set; }
        public bool WasHealed { get; set; }
    }

    public class RescueCandidate
    {
        public string TestId { get; set; }
        public string Text { get; set; }
        public string AriaLbl { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Tag { get; set; }
        public string Type { get; set; }
        public int Score { get; set; }
        public string MatchReason { get; set; }
    }
}
