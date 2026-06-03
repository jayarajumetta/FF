// Tools/LocatorScan/LocatorFileGenerator.cs
//
// Generates C# locator files from scan results with proper naming and organization

#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PnCTestAutomation.Tools.LocatorScan
{
    /// <summary>
    /// Output format for generated locator files
    /// </summary>
    public enum LocatorOutputFormat
    {
        /// <summary>Static locator methods in Locators namespace (legacy)</summary>
        StaticLocators,
        /// <summary>SFP page object class inheriting from BasePage</summary>
        SfpPageObject
    }

    public static class LocatorFileGenerator
    {
        public static async Task GenerateLocatorFileAsync(
            List<ElementReport> reports,
            string outputDir,
            IPage page,
            CancellationToken ct = default)
        {
            // Default to SFP page object format
            await GenerateLocatorFileAsync(reports, outputDir, page, LocatorOutputFormat.SfpPageObject, ct);
        }

        public static async Task GenerateLocatorFileAsync(
            List<ElementReport> reports,
            string outputDir,
            IPage page,
            LocatorOutputFormat format,
            CancellationToken ct = default)
        {
            try
            {
                var url = page.Url;
                var pageTitle = await page.TitleAsync();
                var timestamp = DateTime.Now.ToString("ddMMMyyyy_HHmmss").ToUpper();

                // Try to get actual section name from UI elements
                var sectionName = await GetCurrentSectionNameAsync(page);

                // Extract page identifier - prefer section name from UI
                var pageIdentifier = !string.IsNullOrEmpty(sectionName)
                    ? ToPascalCase(sectionName)
                    : ExtractPageIdentifier(url, pageTitle);

                Console.WriteLine($"[LocatorFileGenerator] Page section: {pageIdentifier}");

                // Filter to best locator candidates
                var candidateElements = FilterToBestCandidates(reports);

                string fileName;
                string fileContent;

                if (format == LocatorOutputFormat.SfpPageObject)
                {
                    // Generate SFP page object: SFP_PolicyDetails_Page.cs
                    fileName = $"SFP_{pageIdentifier}Page.cs";
                    fileContent = GenerateSfpPageClass(candidateElements, pageIdentifier, url);
                }
                else
                {
                    // Generate static locators: ExpertQuote_PolicyDetails_17FEB2026_123456_Locators.cs
                    fileName = $"ExpertQuote_{pageIdentifier}_{timestamp}_Locators.cs";
                    fileContent = GenerateLocatorClasses(candidateElements, pageIdentifier, url, timestamp);
                }

                var filePath = Path.Combine(outputDir, fileName);

                // Ensure output directory exists
                Directory.CreateDirectory(outputDir);

                await File.WriteAllTextAsync(filePath, fileContent, ct);

                Console.WriteLine($"[LocatorFileGenerator] Generated: {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LocatorFileGenerator] Error generating locator file: {ex.Message}");
            }
        }

        /// <summary>
        /// Detects the current page section name from UI elements (h1 header or active nav item)
        /// </summary>
        private static async Task<string?> GetCurrentSectionNameAsync(IPage page)
        {
            try
            {
                // First try: Get h1 header text (most accurate for current section)
                var h1Text = await page.EvaluateAsync<string?>(@"() => {
                    const h1 = document.querySelector('h1');
                    return h1 ? h1.textContent.trim() : null;
                }");

                if (!string.IsNullOrWhiteSpace(h1Text) && h1Text != "ExpertQuote")
                {
                    return h1Text;
                }

                // Second try: Get active navigation item from left sidebar
                var activeNavText = await page.EvaluateAsync<string?>(@"() => {
                    // Look for active nav item with common patterns
                    const activeNav = document.querySelector('.menu-item.active, .nav-item.active, [class*=""nav""][class*=""active""], .active[data-testid*=""-nav""]');
                    return activeNav ? activeNav.textContent.trim() : null;
                }");

                if (!string.IsNullOrWhiteSpace(activeNavText))
                {
                    return activeNavText;
                }

                // Third try: Look for any element with "-nav" testid that's active
                var navTestId = await page.EvaluateAsync<string?>(@"() => {
                    const navItems = document.querySelectorAll('[data-testid$=""-nav""]');
                    for (const item of navItems) {
                        if (item.classList.contains('active')) {
                            return item.textContent.trim();
                        }
                    }
                    return null;
                }");

                return navTestId;
            }
            catch
            {
                return null;
            }
        }

        private static string ExtractPageIdentifier(string url, string pageTitle)
        {
            // Extract meaningful page identifier from URL or title
            var uri = new Uri(url);
            var pathSegments = uri.AbsolutePath.Split('/', StringSplitOptions.RemoveEmptyEntries);

            // Try to get page name from URL hash/fragment
            if (!string.IsNullOrEmpty(uri.Fragment))
            {
                var fragment = uri.Fragment.TrimStart('#').Split('/').LastOrDefault();
                if (!string.IsNullOrEmpty(fragment))
                {
                    return ToPascalCase(fragment);
                }
            }

            // Try to get from URL path
            if (pathSegments.Length > 0)
            {
                var lastSegment = pathSegments.Last();
                return ToPascalCase(lastSegment);
            }

            // Try from page title
            if (!string.IsNullOrEmpty(pageTitle) && pageTitle != "ExpertQuote")
            {
                return ToPascalCase(pageTitle);
            }

            // Default
            return "Dashboard";
        }

        private static string ToPascalCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return "Page";

            // First, insert spaces before capitals in camelCase (e.g., additionalDescription -> additional Description)
            var withSpaces = Regex.Replace(input, @"(?<=[a-z])(?=[A-Z])", " ");

            // Clean up special characters
            var cleaned = Regex.Replace(withSpaces, @"[^a-zA-Z0-9]", " ");
            var words = cleaned.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Capitalize first letter of each word, preserve rest of casing for acronyms
            return string.Join("", words.Select(w =>
                char.ToUpper(w[0]) + (w.Length > 1 ? w.Substring(1) : "")));
        }

        private static List<ElementReport> FilterToBestCandidates(List<ElementReport> reports)
        {
            // STRICT FILTER: Only include high-quality locators matching repo patterns
            // Repo pattern: STRONGLY prefer GetByTestId, then GetByRole with aria-label
            var filtered = reports
                .Where(r =>
                {
                    var topCandidate = r.Candidates.FirstOrDefault();
                    var text = (r.Text ?? "").Trim();
                    var ariaLabel = (r.AriaLabel ?? "").Trim();
                    var tagName = (r.Tag ?? "").ToLower();

                    // Must have generated code
                    if (topCandidate == null || string.IsNullOrEmpty(topCandidate.CodeSnippet)) return false;

                    // SKIP fragile/generic locators (dynamic IDs, .First patterns, generic tag selectors)
                    if (IsFragileLocator(topCandidate.CodeSnippet))
                        return false;

                    // GOLD STANDARD: Elements with testId - ALWAYS include if testId is new
                    // For elements with testId, only consider it "matched" if the GetByTestId candidate exists
                    // Ignore matches from generic candidates like GetByRole(Textbox)
                    if (!string.IsNullOrEmpty(r.TestId))
                    {
                        // Check if the specific testId exists in repo (not other candidates)
                        var testIdMatch = r.ExistingMatches?.FirstOrDefault(m =>
                            m.MatchType == "Exact" &&
                            (m.CanonicalKey?.StartsWith("getbytestid|", StringComparison.OrdinalIgnoreCase) == true));
                        return testIdMatch == null; // Include if testId is NOT in repo
                    }

                    // SKIP if already exists in repo (exact match) - for non-testId elements only
                    if (r.ExistingMatches?.Any(m => m.MatchType == "Exact") == true)
                        return false;

                    // Skip dynamic/meaningless data (only for non-testId elements)
                    if (IsDynamicData(text)) return false;

                    // SILVER STANDARD: Elements with aria-label (GetByRole is stable)
                    // Include buttons, inputs, and interactive elements with aria-label
                    if (!string.IsNullOrEmpty(ariaLabel) && ariaLabel.Length >= 3 && !IsGenericAriaLabel(ariaLabel))
                    {
                        // Button with aria-label (e.g., "Open calendar", "Next month")
                        if (r.ControlType == "Button" || r.Role == "button")
                            return true;

                        // Form inputs with aria-label
                        if (r.ControlType?.Contains("Input") == true || tagName == "input")
                            return true;
                    }

                    // Angular Material components with stable semantic classes
                    if (IsAngularMaterialComponent(r))
                        return true;

                    // Skip generic/useless buttons (table sorters, edit icons, etc.)
                    if (IsGenericButton(text))
                        return false;

                    // Form inputs with placeholder (GetByPlaceholder is stable)
                    if (!string.IsNullOrEmpty(r.Placeholder))
                        return true;

                    // Form inputs with label (GetByLabel is stable)
                    if (!string.IsNullOrEmpty(r.Label) && r.ControlType?.Contains("Input") == true)
                        return true;

                    // CLAS/DuckCreek inputs: no testId or placeholder, but have an accessible name
                    // captured via GetByRole(Name=) or GetByLabel — include these
                    if ((r.ControlType?.Contains("Input") == true || r.ControlType == "Select")
                        && topCandidate.CodeSnippet.Contains("Name ="))
                        return true;

                    // High-value unique buttons only (multi-word, specific actions)
                    if (r.ControlType == "Button" && IsHighValueButton(text))
                        return true;

                    // Non-hidden navigation links with meaningful stable text
                    if (r.ControlType == "Link" && !r.IsHidden
                        && !string.IsNullOrEmpty(r.Text)
                        && r.Text.Length >= 3 && r.Text.Length <= 60
                        && !IsDynamicData(r.Text))
                        return true;

                    // Skip everything else - if no testId, aria-label, placeholder, or label, it's not useful
                    return false;
                })
                .OrderBy(r => GetPriority(r))
                .ToList();

            // ALWAYS include all elements with testId (developer-intended test hooks) - no limit
            var withTestId = filtered.Where(e => !string.IsNullOrEmpty(e.TestId)).ToList();

            // Cap non-testId elements at 150 to balance usefulness vs noise
            var withoutTestId = filtered.Where(e => string.IsNullOrEmpty(e.TestId)).Take(150).ToList();

            return withTestId.Concat(withoutTestId).ToList();
        }

        /// <summary>
        /// Detect Angular Material components that can be reliably located
        /// </summary>
        private static bool IsAngularMaterialComponent(ElementReport element)
        {
            var tagName = (element.Tag ?? "").ToLower();
            var classList = (element.ClassList ?? "").ToLower();

            // Angular Material select (dropdown)
            if (tagName == "mat-select" || classList.Contains("mat-select"))
                return true;

            // Angular Material datepicker toggle
            if (tagName == "mat-datepicker-toggle" || classList.Contains("mat-datepicker-toggle"))
                return true;

            // Angular Material slide toggle
            if (tagName == "mat-slide-toggle" || classList.Contains("mat-slide-toggle"))
                return true;

            // Angular Material checkbox
            if (tagName == "mat-checkbox" || classList.Contains("mat-checkbox"))
                return true;

            // Angular Material radio button
            if (tagName == "mat-radio-button" || classList.Contains("mat-radio-button"))
                return true;

            // Angular Material button toggle (segmented button groups)
            if (tagName == "mat-button-toggle" || classList.Contains("mat-button-toggle"))
                return true;

            // Calendar navigation buttons
            if (classList.Contains("mat-calendar-previous-button") || classList.Contains("mat-calendar-next-button"))
                return true;

            // Angular Material datepicker INPUT (the actual date field)
            if (tagName == "input" && classList.Contains("mat-datepicker-input"))
                return true;

            return false;
        }

        /// <summary>
        /// Detect generic aria-labels that should be skipped
        /// </summary>
        private static bool IsGenericAriaLabel(string ariaLabel)
        {
            if (string.IsNullOrEmpty(ariaLabel)) return true;

            var lower = ariaLabel.ToLower().Trim();

            // Skip single-word generic aria-labels
            var genericLabels = new[] {
                "close", "expand", "collapse", "menu", "loading", "spinner"
            };

            return genericLabels.Any(g => lower == g);
        }

        /// <summary>
        /// Detect fragile locators that should be excluded (dynamic IDs, .First patterns, generic selectors)
        /// </summary>
        private static bool IsFragileLocator(string codeSnippet)
        {
            if (string.IsNullOrEmpty(codeSnippet)) return true;

            // .First patterns are fragile (depend on DOM order)
            if (codeSnippet.Contains(".First"))
                return true;

            // Dynamic CSS IDs (mat-select-value-55, cdk-overlay-123, etc.)
            if (Regex.IsMatch(codeSnippet, @"#[a-z-]+-\d+"))
                return true;

            // Generic tag-only selectors without specificity
            var genericTagPatterns = new[] {
                "Locator(\"div\")", "Locator(\"span\")", "Locator(\"button\")",
                "Locator(\"input\")", "Locator(\"a\")", "Locator(\"li\")",
                "Locator(\"mat-form-field\")", "Locator(\"mat-option\")"
            };
            if (genericTagPatterns.Any(p => codeSnippet.Contains(p)))
                return true;

            return false;
        }

        /// <summary>
        /// Detect generic buttons that should be skipped (table sorters, edit icons, etc.)
        /// </summary>
        private static bool IsGenericButton(string text)
        {
            if (string.IsNullOrEmpty(text)) return true;

            var lower = text.ToLower().Trim();

            // Single-word generic buttons (table headers, icon buttons)
            var genericWords = new[] {
                "name", "type", "date", "line", "edit", "delete", "remove", "add",
                "sort", "filter", "close", "cancel", "ok", "yes", "no",
                "expand", "collapse", "more", "less", "next", "prev", "previous",
                "up", "down", "left", "right", "open", "view"
            };

            if (genericWords.Contains(lower))
                return true;

            // Very short text is usually icon buttons
            if (text.Length <= 4)
                return true;

            return false;
        }

        /// <summary>
        /// Identify high-value buttons worth including even without testId
        /// </summary>
        private static bool IsHighValueButton(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;

            var lower = text.ToLower().Trim();

            // Multi-word action buttons are high value
            if (text.Contains(" ") && text.Length > 5)
                return true;

            // Single-word specific action verbs
            var specificVerbs = new[] { "submit", "search", "logout", "login" };
            if (specificVerbs.Contains(lower))
                return true;

            return false;
        }

        private static int GetPriority(ElementReport element)
        {
            // Lower number = higher priority
            if (!string.IsNullOrEmpty(element.TestId)) return 1;
            if (!string.IsNullOrEmpty(element.Placeholder)) return 2;
            if (!string.IsNullOrEmpty(element.Label)) return 3;
            if (!string.IsNullOrEmpty(element.Id)) return 4;
            if (element.ControlType == "Button") return 5;
            if (element.Role == "tab") return 6;
            if (element.ControlType == "Link") return 5;
            return 10;
        }

        private static string GenerateLocatorClasses(
            List<ElementReport> elements,
            string pageIdentifier,
            string url,
            string timestamp)
        {
            var sb = new StringBuilder();

            // File header
            sb.AppendLine("using Microsoft.Playwright;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine();
            sb.AppendLine("namespace PnCTestAutomation.Locators");
            sb.AppendLine("{");

            // Deduplicate elements by their locator code snippet
            var seenLocators = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var uniqueElements = new List<ElementReport>();

            foreach (var element in elements)
            {
                var topCandidate = element.Candidates.FirstOrDefault();
                if (topCandidate == null) continue;

                // Skip if we've already seen this exact locator
                if (seenLocators.Contains(topCandidate.CodeSnippet))
                    continue;

                seenLocators.Add(topCandidate.CodeSnippet);
                uniqueElements.Add(element);
            }

            sb.AppendLine($"    /// <summary>");
            sb.AppendLine($"    /// Auto-generated locators for {pageIdentifier} page");
            sb.AppendLine($"    /// Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"    /// Source URL: {url}");
            sb.AppendLine($"    /// NEW locators only (excludes duplicates already in repo)");
            sb.AppendLine($"    /// </summary>");
            sb.AppendLine($"    public static class {pageIdentifier}Locators");
            sb.AppendLine("    {");

            // Track used method names to avoid duplicates
            var usedMethodNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var element in uniqueElements)
            {
                var methodName = GenerateUniqueMethodName(element, usedMethodNames);
                usedMethodNames.Add(methodName);

                var topCandidate = element.Candidates.FirstOrDefault();
                if (topCandidate == null) continue;

                // Generate comment
                var comment = GenerateComment(element);
                if (!string.IsNullOrEmpty(comment))
                {
                    sb.AppendLine($"        /// <summary>{comment}</summary>");
                }

                sb.AppendLine($"        public static ILocator {methodName}(IPage page) => {topCandidate.CodeSnippet};");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        /// <summary>
        /// Generate SFP page object class format matching existing page patterns
        /// </summary>
        private static string GenerateSfpPageClass(
            List<ElementReport> elements,
            string pageIdentifier,
            string url)
        {
            var sb = new StringBuilder();

            // File header - minimal like existing SFP pages
            sb.AppendLine("using Microsoft.Playwright;");
            sb.AppendLine();
            sb.AppendLine("namespace PnCTestAutomation.Pages");
            sb.AppendLine("{");
            sb.AppendLine($"    public class SFP_{pageIdentifier}Page : BasePage");
            sb.AppendLine("    {");
            sb.AppendLine($"        public SFP_{pageIdentifier}Page(IPage page) : base(page) {{ }}");
            sb.AppendLine();

            // Deduplicate elements by their locator code snippet
            var seenLocators = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var uniqueElements = new List<ElementReport>();

            foreach (var element in elements)
            {
                var topCandidate = element.Candidates.FirstOrDefault();
                if (topCandidate == null) continue;

                // Skip if we've already seen this exact locator
                if (seenLocators.Contains(topCandidate.CodeSnippet))
                    continue;

                seenLocators.Add(topCandidate.CodeSnippet);
                uniqueElements.Add(element);
            }

            // Group elements by control type for organization
            var buttons = uniqueElements.Where(e => e.ControlType == "Button").ToList();
            var inputs = uniqueElements.Where(e => e.ControlType?.Contains("Input") == true || e.Tag == "input").ToList();
            var selects = uniqueElements.Where(e => e.Tag == "mat-select" || e.Tag == "select").ToList();
            var checkboxes = uniqueElements.Where(e => e.Tag == "mat-checkbox" || (e.Tag == "input" && e.Type == "checkbox")).ToList();
            var toggles = uniqueElements.Where(e => e.Tag == "mat-slide-toggle").ToList();
            var others = uniqueElements.Except(buttons).Except(inputs).Except(selects).Except(checkboxes).Except(toggles).ToList();

            // Track used property names to avoid duplicates
            var usedNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // Generate properties by category
            if (inputs.Any() || selects.Any())
            {
                sb.AppendLine("        // Form Fields");
                GenerateSfpProperties(sb, inputs.Concat(selects).ToList(), usedNames);
                sb.AppendLine();
            }

            if (buttons.Any())
            {
                sb.AppendLine("        // Buttons");
                GenerateSfpProperties(sb, buttons, usedNames);
                sb.AppendLine();
            }

            if (checkboxes.Any() || toggles.Any())
            {
                sb.AppendLine("        // Checkboxes & Toggles");
                GenerateSfpProperties(sb, checkboxes.Concat(toggles).ToList(), usedNames);
                sb.AppendLine();
            }

            if (others.Any())
            {
                sb.AppendLine("        // Other Elements");
                GenerateSfpProperties(sb, others, usedNames);
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        /// <summary>
        /// Generate SFP-style properties for a list of elements
        /// </summary>
        private static void GenerateSfpProperties(StringBuilder sb, List<ElementReport> elements, HashSet<string> usedNames)
        {
            foreach (var element in elements)
            {
                var propertyName = GenerateUniqueMethodName(element, usedNames);
                usedNames.Add(propertyName);

                var topCandidate = element.Candidates.FirstOrDefault();
                if (topCandidate == null) continue;

                // Convert page.XYZ to _page.XYZ format
                var locatorCode = topCandidate.CodeSnippet.Replace("page.", "_page.");

                sb.AppendLine($"        public ILocator {propertyName} => {locatorCode};");
            }
        }

        /// <summary>
        /// Generate a unique method name, adding numeric suffix if needed
        /// </summary>
        private static string GenerateUniqueMethodName(ElementReport element, HashSet<string> usedNames)
        {
            var baseName = GenerateMethodName(element);

            if (!usedNames.Contains(baseName))
                return baseName;

            // Add numeric suffix for duplicates
            var suffix = 2;
            while (usedNames.Contains(baseName + suffix))
            {
                suffix++;
            }
            return baseName + suffix;
        }

        private static string GenerateMethodName(ElementReport element)
        {
            var baseName = "";

            // Priority 1: Associated label (from <label> element - most readable UI name)
            if (!string.IsNullOrEmpty(element.Label) && element.Label.Length >= 3 && !IsDynamicData(element.Label))
            {
                baseName = ExtractMeaningfulName(element.Label);
            }
            // Priority 2: Aria-label (UI-visible accessible name)
            else if (!string.IsNullOrEmpty(element.AriaLabel) && element.AriaLabel.Length >= 3 && !IsDynamicData(element.AriaLabel))
            {
                baseName = ExtractMeaningfulName(element.AriaLabel);
            }
            // Priority 3: Clean, meaningful visible text
            else if (!string.IsNullOrEmpty(element.Text) && element.Text.Length >= 3 && element.Text.Length <= 50 && !IsDynamicData(element.Text))
            {
                baseName = ExtractMeaningfulName(element.Text);
            }
            // Priority 4: Placeholder text (for inputs)
            else if (!string.IsNullOrEmpty(element.Placeholder) && element.Placeholder.Length >= 3)
            {
                baseName = ExtractMeaningfulName(element.Placeholder);
            }
            // Priority 5: TestId (fallback - extract semantic part)
            else if (!string.IsNullOrEmpty(element.TestId))
            {
                baseName = ConvertTestIdToSemanticName(element.TestId);
            }
            // Priority 6: Semantic ID - extract meaningful part
            else if (!string.IsNullOrEmpty(element.Id))
            {
                var semanticName = ConvertIdToSemanticName(element.Id);
                if (semanticName.Length >= 3 && !IsDynamicData(semanticName))
                {
                    baseName = semanticName;
                }
                else
                {
                    baseName = (element.ControlType ?? "Element") + "Control";
                }
            }
            // Fallback: Use control type with context
            else
            {
                baseName = (element.ControlType ?? "Element") + "Control";
            }

            // Add appropriate suffix based on element type
            baseName = AddControlTypeSuffix(baseName, element.ControlType, element);

            // Ensure valid C# identifier
            baseName = Regex.Replace(baseName, @"[^a-zA-Z0-9]", "");
            if (string.IsNullOrEmpty(baseName) || char.IsDigit(baseName[0]))
                baseName = "Element" + baseName;

            return baseName;
        }

        /// <summary>
        /// Extract meaningful words from a label/text to create a concise method name.
        /// Removes question words, articles, prepositions, and keeps nouns/verbs.
        /// </summary>
        private static string ExtractMeaningfulName(string input)
        {
            if (string.IsNullOrEmpty(input)) return "Element";

            // If short enough, just use PascalCase
            if (input.Length <= 30)
            {
                return ToPascalCase(input);
            }

            // Stop words to remove (common filler words)
            var stopWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "a", "an", "the", "is", "are", "was", "were", "be", "been", "being",
                "do", "does", "did", "doing", "have", "has", "had", "having",
                "you", "your", "this", "that", "these", "those", "it", "its", "there",
                "to", "of", "in", "for", "on", "with", "at", "by", "from", "as",
                "and", "or", "but", "if", "then", "else", "when", "where", "why", "how",
                "all", "any", "both", "each", "few", "more", "most", "some", "such",
                "no", "not", "only", "same", "so", "than", "too", "very",
                "can", "will", "just", "should", "would", "could", "may", "might",
                "want", "like", "need"
            };

            // Split into words
            var words = Regex.Split(input, @"[^a-zA-Z0-9]+")
                .Where(w => !string.IsNullOrEmpty(w) && w.Length >= 2)
                .Where(w => !stopWords.Contains(w))
                .ToList();

            // Take up to 5 meaningful words to keep name reasonable
            var meaningfulWords = words.Take(5).ToList();

            if (meaningfulWords.Count == 0)
            {
                // Fallback: take first few words regardless
                meaningfulWords = Regex.Split(input, @"[^a-zA-Z0-9]+")
                    .Where(w => !string.IsNullOrEmpty(w) && w.Length >= 2)
                    .Take(3)
                    .ToList();
            }

            // Convert to PascalCase
            return string.Join("", meaningfulWords.Select(w =>
                char.ToUpper(w[0]) + (w.Length > 1 ? w.Substring(1) : "")));
        }
        /// <summary>
        /// Extract semantic name from an ID attribute (similar logic to TestId extraction)
        /// </summary>
        private static string ConvertIdToSemanticName(string id)
        {
            // IDs often follow similar patterns to testIds
            // e.g., "fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$dateOfOccurrence.value"
            // -> "dateOfOccurrence" -> "DateOfOccurrence"

            // Use the same extraction logic as TestId
            return ConvertTestIdToSemanticName(id);
        }

        private static string ConvertTestIdToSemanticName(string testId)
        {
            // Extract the meaningful part from testIds like:
            // "fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$amountPaid.value"
            // -> "amountPaid" -> "AmountPaid"

            // Pattern 1: Has $ - extract the part after $ and before .value
            if (testId.Contains("$"))
            {
                var afterDollar = testId.Split('$').Last();
                // Remove .value suffix
                var semanticPart = afterDollar
                    .Replace(".value", "")
                    .Split('-').First(); // Remove button index like "-0", "-1"

                if (!string.IsNullOrEmpty(semanticPart))
                {
                    return ToPascalCase(semanticPart);
                }
            }

            // Pattern 2: Has common action suffixes - extract last meaningful segment
            var segments = testId.Split('.');
            var lastSegment = segments.LastOrDefault() ?? testId;

            // Remove common suffixes/prefixes
            lastSegment = lastSegment
                .Replace("value", "")
                .Replace("Input", "")
                .Split('-').First();

            // If the last segment is meaningful, use it
            if (lastSegment.Length >= 3 && !string.IsNullOrWhiteSpace(lastSegment))
            {
                return ToPascalCase(lastSegment);
            }

            // Pattern 3: Try second-to-last segment for actions like "addClaim", "save", "cancel"
            if (segments.Length >= 2)
            {
                var secondLast = segments[segments.Length - 2];
                if (secondLast.Length >= 3)
                {
                    return ToPascalCase(secondLast);
                }
            }

            // Fallback: Clean up the full testId
            return testId
                .Replace("fields.", "")
                .Replace("data.", "")
                .Replace(".value", "")
                .Replace("rows[0].", "")
                .Replace("rows[1].", "")
                .Replace("Input$", "")
                .Replace("$", "")
                .Split('.').Last();
        }

        private static string AddControlTypeSuffix(string baseName, string? controlType, ElementReport? element = null)
        {
            if (string.IsNullOrEmpty(controlType) && element == null) return baseName;

            var tag = element?.Tag?.ToLower() ?? "";
            var type = element?.Type?.ToLower() ?? "";

            // Determine suffix based on element tag/type for more accurate naming
            string suffix;

            // Check for specific element types first
            if (tag == "mat-select" || tag == "select")
            {
                suffix = baseName.EndsWith("Select") ? "" : "Select";
            }
            else if (tag == "mat-checkbox" || (tag == "input" && type == "checkbox"))
            {
                suffix = baseName.EndsWith("Checkbox") ? "" : "Checkbox";
            }
            else if (tag == "mat-slide-toggle")
            {
                suffix = baseName.EndsWith("Toggle") ? "" : "Toggle";
            }
            else if (tag == "input" || tag == "textarea")
            {
                suffix = baseName.EndsWith("Input") ? "" : "Input";
            }
            else if (controlType == "Button" || tag == "button")
            {
                suffix = baseName.EndsWith("Button") ? "" : "Button";
            }
            else if (controlType == "Link" || tag == "a")
            {
                suffix = baseName.EndsWith("Link") ? "" : "Link";
            }
            else if (controlType == "Tab")
            {
                suffix = baseName.EndsWith("Tab") ? "" : "Tab";
            }
            else
            {
                suffix = "";
            }

            return baseName + suffix;
        }

        private static string GenerateComment(ElementReport element)
        {
            if (!string.IsNullOrEmpty(element.Text) && element.Text.Length < 100)
            {
                return $" {element.ControlType}: {element.Text} ";
            }
            else if (!string.IsNullOrEmpty(element.TestId))
            {
                return $" {element.ControlType} with testId: {element.TestId} ";
            }
            else if (!string.IsNullOrEmpty(element.Id))
            {
                return $" {element.ControlType} with ID: {element.Id} ";
            }

            return $" {element.ControlType} element ";
        }

        private static bool IsDynamicData(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;

            // Skip quote numbers, policy numbers, random IDs
            if (Regex.IsMatch(text, @"^\d{6,}$")) return true; // Pure numbers 6+ digits
            if (Regex.IsMatch(text, @"^[A-Z0-9]{6,}$")) return true; // Alphanumeric codes
            if (Regex.IsMatch(text, @"^\d{4}[A-Z]\d{4}$")) return true; // Policy patterns like 4101G4216
            if (text.Length > 50) return true; // Very long text (likely content, not UI labels)

            return false;
        }

        private static bool IsStableUIElement(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;

            var lowerText = text.ToLower();

            // Known stable UI elements
            var stablePatterns = new[]
            {
                "search", "login", "logout", "save", "submit", "continue", "cancel", "add", "edit", "delete",
                "new quote", "name", "type", "date", "line", "quote", "policy", "clear", "reset",
                "sort", "filter", "export", "print", "help", "settings", "profile", "account"
            };

            return stablePatterns.Any(pattern => lowerText.Contains(pattern));
        }

        private static bool IsNavigationLink(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;

            var lowerText = text.ToLower();

            // Known navigation patterns
            var navigationPatterns = new[]
            {
                "expertservice", "training", "library", "road map", "notifications", "help",
                "support", "contact", "home", "dashboard", "menu", "navigation", "logout"
            };

            return navigationPatterns.Any(pattern => lowerText.Contains(pattern)) && !IsDynamicData(text);
        }
    }
}
