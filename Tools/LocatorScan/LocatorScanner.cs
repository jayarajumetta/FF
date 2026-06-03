// Tools/LocatorScan/LocatorScanner.cs
#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PnCTestAutomation.Tools.LocatorScan
{
    // ──────────────────────────────────────────────────────────────────────
    // Options
    // ──────────────────────────────────────────────────────────────────────
    public sealed class LocatorScanOptions
    {
        public string TestIdAttribute { get; set; } = "data-testid";
        public bool VisibleOnly { get; set; } = true;           // Only scan visible elements
        public bool IncludeAllElements { get; set; } = false;   // Include non-interactable elements
        public int MaxCandidates { get; set; } = 3;             // Limit candidates per element for performance
    }

    // ──────────────────────────────────────────────────────────────────────
    // Models
    // ──────────────────────────────────────────────────────────────────────
    public sealed class LocatorCandidate
    {
        public string Strategy { get; set; } = string.Empty;
        public string CodeSnippet { get; set; } = string.Empty;
        public int Score { get; set; }
    }

    public sealed class ExistingMatch
    {
        public string MatchType { get; set; } = "None";       // Exact | Near | None
        public string Strategy { get; set; } = string.Empty;
        public string CanonicalKey { get; set; } = string.Empty;
        public string ExistingFile { get; set; } = string.Empty;
        public string ExistingClass { get; set; } = string.Empty;
        public string ExistingMember { get; set; } = string.Empty;
        public string ExistingCode { get; set; } = string.Empty;
    }

    public sealed class ElementReport
    {
        // Raw attributes
        public string Tag { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string AccessibleName { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string ClassList { get; set; } = string.Empty;
        public string TestId { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string Placeholder { get; set; } = string.Empty;
        public string AriaLabel { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string DebugXPath { get; set; } = string.Empty;

        // UI intent
        public string ControlType { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Group { get; set; } = string.Empty;
        public string Help { get; set; } = string.Empty;
        public bool Required { get; set; }
        public bool Disabled { get; set; }
        public string Target { get; set; } = string.Empty;
        public bool IsHidden { get; set; }
        public string HiddenReasons { get; set; } = string.Empty;

        // Candidates (ranked)
        public List<LocatorCandidate> Candidates { get; set; } = new();

        // Repo matches (populated by LocatorMatchEngine)
        public List<ExistingMatch> ExistingMatches { get; set; } = new();
    }

    // ──────────────────────────────────────────────────────────────────────
    // Scanner
    // ──────────────────────────────────────────────────────────────────────
    public sealed class LocatorScanner
    {
        // ────── JavaScript executed in-page to gather element data ──────
        private const string ScanScript = @"
(options) => {
    const visibleOnly = options?.visibleOnly ?? true;
    const includeAllElements = options?.includeAllElements ?? false;
    // Include standard HTML interactables AND Angular Material custom elements
    const interactableTags = new Set([
        'button','a','input','select','textarea','summary','option',
        'mat-checkbox','mat-select','mat-slide-toggle','mat-radio-button','mat-radio-group',
        'mat-button-toggle','mat-datepicker-toggle','mat-expansion-panel','mat-expansion-panel-header'
    ]);
    const results = [];

    function truncate(s, max) { return s && s.length > max ? s.substring(0, max) : (s || ''); }
    function norm(s) { return (s || '').replace(/\s+/g, ' ').trim(); }

    function labelFor(el) {
        // explicit <label for>
        if (el.id) {
            const lbl = document.querySelector('label[for=""' + CSS.escape(el.id) + '""]');
            if (lbl) return norm(lbl.textContent);
        }
        // nested
        const parent = el.closest('label');
        if (parent) return norm(parent.textContent);
        // aria-labelledby
        const ids = (el.getAttribute('aria-labelledby') || '').split(/\s+/).filter(Boolean);
        if (ids.length) {
            return ids.map(id => { const e = document.getElementById(id); return e ? norm(e.textContent) : ''; }).join(' ').trim();
        }
        return '';
    }

    function regionOf(el) {
        const landmarks = ['main','nav','form','dialog','banner','contentinfo','region','header','footer','aside','section'];
        let cur = el.parentElement;
        while (cur) {
            const r = (cur.getAttribute('role') || '').toLowerCase();
            if (landmarks.includes(r)) {
                const n = cur.getAttribute('aria-label') || cur.getAttribute('aria-labelledby') || '';
                return r + (n ? ': ' + norm(n) : '');
            }
            const tag = cur.tagName.toLowerCase();
            if (['main','nav','header','footer','aside','section','form','dialog'].includes(tag)) {
                const n = cur.getAttribute('aria-label') || '';
                return tag + (n ? ': ' + norm(n) : '');
            }
            cur = cur.parentElement;
        }
        // fallback: nearest heading
        cur = el.parentElement;
        while (cur) {
            const h = cur.querySelector('h1,h2,h3,h4,h5,h6');
            if (h) return 'heading: ' + truncate(norm(h.textContent), 80);
            cur = cur.parentElement;
        }
        return '';
    }

    function groupOf(el) {
        const fs = el.closest('fieldset');
        if (fs) { const lg = fs.querySelector('legend'); if (lg) return norm(lg.textContent); }
        const rg = el.closest('[role=""radiogroup""]');
        if (rg) return rg.getAttribute('aria-label') || '';
        return '';
    }

    function helpOf(el) {
        const descId = el.getAttribute('aria-describedby');
        if (descId) {
            const d = document.getElementById(descId);
            if (d) return truncate(norm(d.textContent), 120);
        }
        const t = el.getAttribute('title');
        if (t) return truncate(t, 120);
        return '';
    }

    function simpleXPath(el) {
        const parts = [];
        let cur = el;
        while (cur && cur.nodeType === 1) {
            let tag = cur.tagName.toLowerCase();
            let idx = 1;
            let sib = cur.previousElementSibling;
            while (sib) { if (sib.tagName.toLowerCase() === tag) idx++; sib = sib.previousElementSibling; }
            parts.unshift(tag + '[' + idx + ']');
            cur = cur.parentElement;
        }
        return '/' + parts.join('/');
    }

    function getHiddenStatus(el) {
        const computed = window.getComputedStyle(el);
        const reasons = [];
        let isHidden = false;

        // CSS visibility checks
        if (computed.display === 'none') {
            isHidden = true;
            reasons.push('display:none');
        }
        if (computed.visibility === 'hidden') {
            isHidden = true;
            reasons.push('visibility:hidden');
        }
        if (computed.opacity === '0') {
            isHidden = true;
            reasons.push('opacity:0');
        }

        // HTML hidden attribute
        if (el.hidden) {
            isHidden = true;
            reasons.push('hidden-attr');
        }

        // ARIA hidden
        if (el.getAttribute('aria-hidden') === 'true') {
            isHidden = true;
            reasons.push('aria-hidden');
        }

        // Off-screen positioning
        const rect = el.getBoundingClientRect();
        if (rect.width === 0 && rect.height === 0) {
            isHidden = true;
            reasons.push('zero-dimensions');
        }
        
        if (rect.left < -1000 || rect.top < -1000) {
            isHidden = true;
            reasons.push('off-screen');
        }

        // No offsetParent (except for position:fixed)
        if (!el.offsetParent && computed.position !== 'fixed' && el.tagName.toLowerCase() !== 'body') {
            isHidden = true;
            reasons.push('no-offset-parent');
        }

        // Parent container hidden
        let parent = el.parentElement;
        while (parent && parent !== document.body) {
            const parentComputed = window.getComputedStyle(parent);
            if (parentComputed.display === 'none' || parentComputed.visibility === 'hidden') {
                isHidden = true;
                reasons.push('parent-hidden');
                break;
            }
            parent = parent.parentElement;
        }

        return {
            isHidden: isHidden,
            hiddenReasons: reasons.join(',')
        };
    }

    const all = document.querySelectorAll('*');
    for (const el of all) {
        const tag = el.tagName.toLowerCase();
        const role = el.getAttribute('role') || '';
        const tabindex = el.getAttribute('tabindex');
        const onclick = el.hasAttribute('onclick');
        const classListLower = [...el.classList].join(' ').toLowerCase();
        
        // Check for Angular Material components by class (they may use attribute selectors on regular elements)
        const isAngularMaterial = classListLower.includes('mat-checkbox') || classListLower.includes('mat-select') ||
            classListLower.includes('mat-slide-toggle') || classListLower.includes('mat-radio-button') ||
            classListLower.includes('mat-button-toggle') || classListLower.includes('mat-expansion-panel');
        
        const isInteractable = interactableTags.has(tag) || !!role || (tabindex !== null && parseInt(tabindex, 10) >= 0) || onclick || isAngularMaterial;
        
        // Check for testId early - elements with testIds should ALWAYS be included
        const testIdAttrs = ['data-testid','data-test','data-qa'];
        let testId = '';
        for (const a of testIdAttrs) { testId = el.getAttribute(a) || testId; if (testId) break; }
        const hasTestId = !!testId;
        
        // Skip non-interactable elements unless includeAllElements is true OR has testId
        if (!isInteractable && !includeAllElements && !hasTestId) continue;

        const hiddenStatus = getHiddenStatus(el);
        
        // Skip hidden elements if visibleOnly is true, UNLESS element has a testId
        // (testIds are explicitly for automation and should always be included)
        if (visibleOnly && hiddenStatus.isHidden && !hasTestId) continue;

        const type = (el.getAttribute('type') || '').toLowerCase();
        const id = el.id || '';
        const classList = [...el.classList].join(' ');
        const text = truncate(norm(el.textContent), 120);
        const placeholder = el.getAttribute('placeholder') || '';
        const ariaLabel = el.getAttribute('aria-label') || '';
        const label = labelFor(el);
        const accessibleName = ariaLabel || label || placeholder || text;
        const required = el.hasAttribute('required') || el.getAttribute('aria-required') === 'true';
        const disabled = el.hasAttribute('disabled') || el.getAttribute('aria-disabled') === 'true';

        let target = '';
        if (tag === 'a') {
            const href = el.getAttribute('href') || '';
            const tgt = el.getAttribute('target') || '';
            target = (tgt === '_blank' ? 'new-tab: ' : 'same-tab: ') + href;
        }

        results.push({
            Tag: tag, 
            Type: type, 
            Role: role, 
            AccessibleName: accessibleName, 
            Id: id, 
            ClassList: classList, 
            TestId: testId,
            Text: text, 
            Placeholder: placeholder, 
            AriaLabel: ariaLabel, 
            Label: label,
            Region: regionOf(el),
            Group: groupOf(el),
            Help: helpOf(el),
            Required: required, 
            Disabled: disabled, 
            Target: target,
            IsHidden: hiddenStatus.isHidden,
            HiddenReasons: hiddenStatus.hiddenReasons,
            DebugXPath: simpleXPath(el)
        });
    }
    return JSON.stringify(results);
}";

        // ────── Public API ──────

        public async Task<List<ElementReport>> ScanAsync(
            IPage page,
            LocatorScanOptions options,
            CancellationToken ct = default)
        {
            options ??= new LocatorScanOptions();

            // Evaluate in-page script to collect raw element data
            List<RawElement>? rawElements = null;

            Console.WriteLine($"[LocatorScanner] Scanning page for interactable elements...");
            try
            {
                // Pass options to the ScanScript
                var scriptOptions = new
                {
                    visibleOnly = options.VisibleOnly,
                    includeAllElements = options.IncludeAllElements
                };

                // Use JSON workaround with the full ScanScript
                var jsonResult = await page.EvaluateAsync<string>(
                    $"({ScanScript})({{visibleOnly: {scriptOptions.visibleOnly.ToString().ToLower()}, includeAllElements: {scriptOptions.includeAllElements.ToString().ToLower()}}})"
                );

                Console.WriteLine($"[LocatorScanner] Got JSON result, length: {jsonResult?.Length ?? 0}");

                if (!string.IsNullOrEmpty(jsonResult))
                {
                    var jsonOptions = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    rawElements = JsonSerializer.Deserialize<List<RawElement>>(jsonResult, jsonOptions);
                    Console.WriteLine($"[LocatorScanner] JSON deserialization succeeded: {rawElements?.Count ?? 0} elements");
                }
                else
                {
                    Console.WriteLine("[LocatorScanner] Empty JSON result");
                    rawElements = new List<RawElement>();
                }
            }
            catch (Exception jsonEx)
            {
                Console.WriteLine($"[LocatorScanner] JSON workaround failed: {jsonEx.Message}");
                rawElements = new List<RawElement>();
            }
            if (rawElements is null || rawElements.Count == 0)
            {
                Console.WriteLine("[LocatorScanner] No elements found or JS returned null/empty.");
                return new List<ElementReport>();
            }

            var reports = new List<ElementReport>(rawElements.Count);
            foreach (var raw in rawElements)
            {
                ct.ThrowIfCancellationRequested();
                var report = MapToReport(raw, options);
                reports.Add(report);
            }

            return reports;
        }

        public async Task WriteJsonAsync(
            IEnumerable<ElementReport> reports,
            string path,
            CancellationToken ct = default)
        {
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            var jsonOpts = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = JsonSerializer.Serialize(reports, jsonOpts);
            await File.WriteAllTextAsync(path, json, Encoding.UTF8, ct);
        }

        public async Task WriteCsvAsync(
            IEnumerable<ElementReport> reports,
            string path,
            CancellationToken ct = default)
        {
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            WriteCsvCore(reports, path, includeRepoColumns: false);
            await Task.CompletedTask; // sync write wrapped
        }

        /// <summary>
        /// Write CSV with optional repo comparison columns.
        /// </summary>
        public void WriteCsvWithRepoColumns(
            IEnumerable<ElementReport> reports,
            string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            WriteCsvCore(reports, path, includeRepoColumns: true);
        }

        public async Task ScanAndWriteAsync(
            IPage page,
            string outputDir,
            bool csvToo,
            LocatorScanOptions options,
            CancellationToken ct = default)
        {
            var reports = await ScanAsync(page, options, ct);

            Directory.CreateDirectory(outputDir);

            var jsonPath = Path.Combine(outputDir, "locator-scan.json");
            await WriteJsonAsync(reports, jsonPath, ct);

            if (csvToo)
            {
                var csvPath = Path.Combine(outputDir, "locator-scan.csv");
                await WriteCsvAsync(reports, csvPath, ct);
            }
        }

        // ────── Internal mapping ──────

        private static ElementReport MapToReport(RawElement raw, LocatorScanOptions options)
        {
            var controlType = InferControlType(raw.Tag, raw.Type, raw.Role, raw.ClassList);
            var bestName = FirstNonEmpty(raw.AriaLabel, raw.Label, raw.Placeholder, raw.AccessibleName, raw.Text);
            var action = InferAction(controlType, raw.Role, bestName);
            var purpose = InferPurpose(controlType, bestName, raw.Required);

            var report = new ElementReport
            {
                Tag = raw.Tag ?? string.Empty,
                Type = raw.Type ?? string.Empty,
                Role = raw.Role ?? string.Empty,
                AccessibleName = raw.AccessibleName ?? string.Empty,
                Id = raw.Id ?? string.Empty,
                ClassList = raw.ClassList ?? string.Empty,
                TestId = raw.TestId ?? string.Empty,
                Text = raw.Text ?? string.Empty,
                Placeholder = raw.Placeholder ?? string.Empty,
                AriaLabel = raw.AriaLabel ?? string.Empty,
                Label = raw.Label ?? string.Empty,
                DebugXPath = raw.DebugXPath ?? string.Empty,
                ControlType = controlType,
                Action = action,
                Purpose = purpose,
                Region = raw.Region ?? string.Empty,
                Group = raw.Group ?? string.Empty,
                Help = raw.Help ?? string.Empty,
                Required = raw.Required,
                Disabled = raw.Disabled,
                Target = raw.Target ?? string.Empty,
                IsHidden = raw.IsHidden,
                HiddenReasons = raw.HiddenReasons ?? string.Empty
            };

            // Build ranked candidates
            report.Candidates = BuildCandidates(raw, options);

            // Limit candidates for performance
            if (options.MaxCandidates > 0 && report.Candidates.Count > options.MaxCandidates)
            {
                report.Candidates = report.Candidates.Take(options.MaxCandidates).ToList();
            }

            return report;
        }

        // ────── Candidate builders ──────

        private static List<LocatorCandidate> BuildCandidates(RawElement raw, LocatorScanOptions opts)
        {
            var list = new List<LocatorCandidate>();

            // 1) GetByTestId
            if (!string.IsNullOrWhiteSpace(raw.TestId))
            {
                list.Add(new LocatorCandidate
                {
                    Strategy = "GetByTestId",
                    CodeSnippet = $"page.GetByTestId(\"{Escape(raw.TestId)}\")",
                    Score = 1
                });
            }

            // 2) GetByRole
            var ariaRole = MapAriaRole(raw.Tag, raw.Type, raw.Role);
            if (!string.IsNullOrEmpty(ariaRole))
            {
                var name = FirstNonEmpty(raw.AccessibleName, raw.AriaLabel, raw.Label, raw.Text);
                if (!string.IsNullOrWhiteSpace(name) && name.Length <= 80)
                {
                    list.Add(new LocatorCandidate
                    {
                        Strategy = "GetByRole",
                        CodeSnippet = $"page.GetByRole(AriaRole.{ariaRole}, new() {{ Name = \"{Escape(name)}\" }})",
                        Score = 2
                    });
                }
                else
                {
                    list.Add(new LocatorCandidate
                    {
                        Strategy = "GetByRole",
                        CodeSnippet = $"page.GetByRole(AriaRole.{ariaRole})",
                        Score = 5
                    });
                }
            }

            // 3) GetByLabel
            var label = FirstNonEmpty(raw.Label, raw.AriaLabel);
            if (!string.IsNullOrWhiteSpace(label))
            {
                list.Add(new LocatorCandidate
                {
                    Strategy = "GetByLabel",
                    CodeSnippet = $"page.GetByLabel(\"{Escape(label)}\")",
                    Score = 3
                });
            }

            // 4) GetByPlaceholder
            if (!string.IsNullOrWhiteSpace(raw.Placeholder))
            {
                list.Add(new LocatorCandidate
                {
                    Strategy = "GetByPlaceholder",
                    CodeSnippet = $"page.GetByPlaceholder(\"{Escape(raw.Placeholder)}\")",
                    Score = 4
                });
            }

            // 5) GetByText – only for <button> or <a> with clear short text
            if ((raw.Tag == "button" || raw.Tag == "a") &&
                !string.IsNullOrWhiteSpace(raw.Text) &&
                raw.Text.Length <= 40)
            {
                list.Add(new LocatorCandidate
                {
                    Strategy = "GetByText",
                    CodeSnippet = $"page.GetByText(\"{Escape(raw.Text)}\")",
                    Score = 6
                });
            }

            // 5b) GetByText fallback for any element with label or accessible name
            // This helps Angular Material inputs that lack testId/aria-label
            var labelText = FirstNonEmpty(raw.Label, raw.AccessibleName);
            if (!string.IsNullOrWhiteSpace(labelText) && labelText.Length <= 60 && labelText.Length >= 3)
            {
                list.Add(new LocatorCandidate
                {
                    Strategy = "GetByLabel",
                    CodeSnippet = $"page.GetByLabel(\"{Escape(labelText)}\")",
                    Score = 7
                });
            }

            // 6) Locator("#id")
            if (!string.IsNullOrWhiteSpace(raw.Id))
            {
                list.Add(new LocatorCandidate
                {
                    Strategy = "CssId",
                    CodeSnippet = $"page.Locator(\"#{Escape(CssEscape(raw.Id))}\")",
                    Score = 8
                });
            }

            // Fallback
            if (list.Count == 0)
            {
                list.Add(new LocatorCandidate
                {
                    Strategy = "Fallback",
                    CodeSnippet = $"page.Locator(\"{raw.Tag}\").First",
                    Score = 15
                });
            }

            return list.OrderBy(c => c.Score).ToList();
        }

        // ────── Inference helpers ──────

        public static string InferControlType(string tag, string type, string role, string classes)
        {
            if (!string.IsNullOrEmpty(role))
            {
                return role.ToLowerInvariant() switch
                {
                    "button" => "Button",
                    "link" => "Link",
                    "textbox" => "TextInput",
                    "checkbox" => "Checkbox",
                    "radio" => "Radio",
                    "switch" => "Switch",
                    "tab" => "Tab",
                    "menuitem" => "MenuItem",
                    "combobox" => "Select",
                    "listbox" => "Select",
                    "option" => "Option",
                    "dialog" => "DialogButton",
                    "heading" => "Heading",
                    "navigation" => "Navigation",
                    "search" => "SearchInput",
                    "slider" => "Slider",
                    "spinbutton" => "NumberInput",
                    _ => "Interactive"
                };
            }

            return tag?.ToLowerInvariant() switch
            {
                "button" => "Button",
                "a" => "Link",
                "select" => "Select",
                "textarea" => "Textarea",
                "summary" => "Summary",
                "option" => "Option",
                "input" => type?.ToLowerInvariant() switch
                {
                    "password" => "PasswordInput",
                    "number" => "NumberInput",
                    "date" => "DateInput",
                    "checkbox" => "Checkbox",
                    "radio" => "Radio",
                    "email" => "TextInput",
                    "tel" => "TextInput",
                    "search" => "SearchInput",
                    "file" => "FileInput",
                    "submit" => "Button",
                    "reset" => "Button",
                    "hidden" => "Hidden",
                    _ => "TextInput"
                },
                _ => "Interactive"
            };
        }

        public static string InferAction(string controlType, string role, string nameOrLabel)
        {
            var name = string.IsNullOrWhiteSpace(nameOrLabel) ? "" : nameOrLabel.Trim();
            return controlType switch
            {
                "Button" or "DialogButton" => $"Click to {(string.IsNullOrEmpty(name) ? "perform action" : name)}",
                "Link" => $"Navigate to {(string.IsNullOrEmpty(name) ? "page" : name)}",
                "TextInput" or "SearchInput" => $"Enter {(string.IsNullOrEmpty(name) ? "text" : name)}",
                "PasswordInput" => "Enter password",
                "NumberInput" => $"Enter {(string.IsNullOrEmpty(name) ? "number" : name)}",
                "DateInput" => $"Select {(string.IsNullOrEmpty(name) ? "date" : name)}",
                "Select" => $"Choose {(string.IsNullOrEmpty(name) ? "option" : name)}",
                "Textarea" => $"Enter {(string.IsNullOrEmpty(name) ? "text" : name)}",
                "Checkbox" => $"Toggle {(string.IsNullOrEmpty(name) ? "checkbox" : name)}",
                "Radio" => $"Select {(string.IsNullOrEmpty(name) ? "option" : name)}",
                "Switch" => $"Toggle {(string.IsNullOrEmpty(name) ? "switch" : name)}",
                "Tab" => $"Switch to {(string.IsNullOrEmpty(name) ? "tab" : name)}",
                "MenuItem" => $"Select {(string.IsNullOrEmpty(name) ? "menu item" : name)}",
                "Slider" => $"Adjust {(string.IsNullOrEmpty(name) ? "slider" : name)}",
                _ => $"Interact with {(string.IsNullOrEmpty(name) ? "element" : name)}"
            };
        }

        private static string InferPurpose(string controlType, string name, bool required)
        {
            var req = required ? " (required)" : "";
            if (string.IsNullOrWhiteSpace(name))
                return $"{controlType}{req}";
            return $"{controlType}: {name}{req}";
        }

        // ────── String helpers ──────

        public static string CssEscape(string id)
        {
            if (string.IsNullOrEmpty(id)) return id;
            // Escape characters that are special in CSS selectors
            return Regex.Replace(id, @"([!""#$%&'()*+,./:;<=>?@\[\]\\^`{|}~])", @"\$1");
        }

        private static string Escape(string s) =>
            s?.Replace("\\", "\\\\").Replace("\"", "\\\"") ?? string.Empty;

        private static string FirstNonEmpty(params string?[] values)
        {
            foreach (var v in values)
                if (!string.IsNullOrWhiteSpace(v))
                    return v!;
            return string.Empty;
        }

        /// <summary>Map tag/type/role to an AriaRole enum name (PascalCase).</summary>
        private static string? MapAriaRole(string tag, string type, string explicitRole)
        {
            if (!string.IsNullOrEmpty(explicitRole))
            {
                // Capitalize first letter to match AriaRole enum
                var rolePascal = char.ToUpperInvariant(explicitRole[0]) + explicitRole.Substring(1).ToLowerInvariant();
                // Validate it's a real AriaRole
                if (Enum.TryParse<AriaRole>(rolePascal, true, out _))
                    return rolePascal;
            }

            return tag?.ToLowerInvariant() switch
            {
                "button" => "Button",
                "a" => "Link",
                "input" when type == "checkbox" => "Checkbox",
                "input" when type == "radio" => "Radio",
                "input" when type == "submit" || type == "reset" || type == "button" => "Button",
                "input" => "Textbox",
                "select" => "Combobox",
                "textarea" => "Textbox",
                "summary" => null,
                "option" => "Option",
                _ => null
            };
        }

        // ────── CSV writer ──────

        private static void WriteCsvCore(IEnumerable<ElementReport> reports, string path, bool includeRepoColumns)
        {
            var sb = new StringBuilder();

            // Header
            sb.Append("tag,type,role,controlType,action,purpose,region,group,required,disabled,isHidden,hiddenReasons,help,id,testId,text,placeholder,target,topStrategy,topCode,debugXPath");
            if (includeRepoColumns)
                sb.Append(",matchType,matchStrategy,matchCanonicalKey,matchFile,matchMember,matchCode");
            sb.AppendLine();

            foreach (var r in reports)
            {
                var top = r.Candidates.FirstOrDefault();
                sb.Append(CsvField(r.Tag)).Append(',');
                sb.Append(CsvField(r.Type)).Append(',');
                sb.Append(CsvField(r.Role)).Append(',');
                sb.Append(CsvField(r.ControlType)).Append(',');
                sb.Append(CsvField(r.Action)).Append(',');
                sb.Append(CsvField(r.Purpose)).Append(',');
                sb.Append(CsvField(r.Region)).Append(',');
                sb.Append(CsvField(r.Group)).Append(',');
                sb.Append(r.Required ? "true" : "false").Append(',');
                sb.Append(r.Disabled ? "true" : "false").Append(',');
                sb.Append(r.IsHidden ? "true" : "false").Append(',');
                sb.Append(CsvField(r.HiddenReasons)).Append(',');
                sb.Append(CsvField(r.Help)).Append(',');
                sb.Append(CsvField(r.Id)).Append(',');
                sb.Append(CsvField(r.TestId)).Append(',');
                sb.Append(CsvField(r.Text)).Append(',');
                sb.Append(CsvField(r.Placeholder)).Append(',');
                sb.Append(CsvField(r.Target)).Append(',');
                sb.Append(CsvField(top?.Strategy ?? "")).Append(',');
                sb.Append(CsvField(top?.CodeSnippet ?? "")).Append(',');
                sb.Append(CsvField(r.DebugXPath));

                if (includeRepoColumns)
                {
                    var match = r.ExistingMatches.FirstOrDefault();
                    sb.Append(',').Append(CsvField(match?.MatchType ?? "None"));
                    sb.Append(',').Append(CsvField(match?.Strategy ?? ""));
                    sb.Append(',').Append(CsvField(match?.CanonicalKey ?? ""));
                    sb.Append(',').Append(CsvField(match?.ExistingFile ?? ""));
                    sb.Append(',').Append(CsvField(match?.ExistingMember ?? ""));
                    sb.Append(',').Append(CsvField(match?.ExistingCode ?? ""));
                }

                sb.AppendLine();
            }

            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        private static string CsvField(string? value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            if (value.Contains(',') || value.Contains('"') || value.Contains('\n') || value.Contains('\r'))
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            return value;
        }

        // ────── Raw element (JS interop model) ──────

        private sealed class RawElement
        {
            public string Tag { get; set; } = "";
            public string Type { get; set; } = "";
            public string Role { get; set; } = "";
            public string AccessibleName { get; set; } = "";
            public string Id { get; set; } = "";
            public string ClassList { get; set; } = "";
            public string TestId { get; set; } = "";
            public string Text { get; set; } = "";
            public string Placeholder { get; set; } = "";
            public string AriaLabel { get; set; } = "";
            public string Label { get; set; } = "";
            public string Region { get; set; } = "";
            public string Group { get; set; } = "";
            public string Help { get; set; } = "";
            public bool Required { get; set; }
            public bool Disabled { get; set; }
            public string Target { get; set; } = "";
            public bool IsHidden { get; set; }
            public string HiddenReasons { get; set; } = "";
            public string DebugXPath { get; set; } = "";
        }
    }
}
