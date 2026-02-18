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

namespace Playwright_POC.Tools.LocatorScan
{
    public class LocatorFileGenerator
    {
        public static async Task GenerateLocatorFileAsync(
            List<ElementReport> reports, 
            string outputDir, 
            IPage page,
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
                
                // Generate filename: ExpertQuote_PolicyDetails_17FEB2026_123456_Locators.cs
                var fileName = $"ExpertQuote_{pageIdentifier}_{timestamp}_Locators.cs";
                var filePath = Path.Combine(outputDir, fileName);
                
                // Filter to best locator candidates
                var candidateElements = FilterToBestCandidates(reports);
                
                // Generate organized locator classes
                var locatorContent = GenerateLocatorClasses(candidateElements, pageIdentifier, url, timestamp);
                
                await File.WriteAllTextAsync(filePath, locatorContent, ct);
                
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
            
            // Clean up the input - remove special characters, convert to PascalCase
            var cleaned = Regex.Replace(input, @"[^a-zA-Z0-9]", " ");
            var words = cleaned.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            return string.Join("", words.Select(w => 
                char.ToUpper(w[0]) + w.Substring(1).ToLower()));
        }

        private static List<ElementReport> FilterToBestCandidates(List<ElementReport> reports)
        {
            // STRICT FILTER: Only include high-quality locators matching repo patterns
            // Repo pattern: STRONGLY prefer GetByTestId, skip generic buttons
            return reports
                .Where(r => 
                {
                    var topCandidate = r.Candidates.FirstOrDefault();
                    var text = (r.Text ?? "").Trim();
                    
                    // Must have generated code
                    if (topCandidate == null || string.IsNullOrEmpty(topCandidate.CodeSnippet)) return false;
                    
                    // SKIP if already exists in repo (exact match)
                    if (r.ExistingMatches?.Any(m => m.MatchType == "Exact") == true)
                        return false;
                    
                    // Skip dynamic/meaningless data
                    if (IsDynamicData(text)) return false;
                    
                    // GOLD STANDARD: Elements with testId - ALWAYS include
                    if (!string.IsNullOrEmpty(r.TestId))
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
                    
                    // High-value unique buttons only (multi-word, specific actions)
                    if (r.ControlType == "Button" && IsHighValueButton(text))
                        return true;
                    
                    // Skip everything else - if no testId, placeholder, or label, it's not useful
                    return false;
                })
                .OrderBy(r => GetPriority(r))
                .Take(50)
                .ToList();
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
            
            // Multi-word action buttons are usually high value
            if (text.Contains(" ") && text.Length > 8)
            {
                // Specific high-value patterns
                var highValuePatterns = new[] {
                    "new quote", "create new", "save and continue", "submit", 
                    "sign on", "sign in", "log in", "log out", "sign out"
                };
                
                return highValuePatterns.Any(p => lower.Contains(p));
            }
            
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
            sb.AppendLine("namespace Playwright_POC.Locators");
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
            
            // Priority 1: TestId (convert to semantic name)
            if (!string.IsNullOrEmpty(element.TestId))
            {
                baseName = ConvertTestIdToSemanticName(element.TestId);
            }
            // Priority 2: Clean, meaningful text
            else if (!string.IsNullOrEmpty(element.Text) && IsStableUIElement(element.Text))
            {
                baseName = ToPascalCase(element.Text.Length > 25 ? element.Text.Substring(0, 25) : element.Text);
            }
            // Priority 3: Semantic ID (not random)
            else if (!string.IsNullOrEmpty(element.Id) && !IsDynamicData(element.Id))
            {
                baseName = ToPascalCase(element.Id);
            }
            // Fallback: Use control type with context
            else
            {
                baseName = (element.ControlType ?? "Element") + "Control";
            }

            // Add appropriate suffix
            baseName = AddControlTypeSuffix(baseName, element.ControlType);

            // Ensure valid C# identifier
            baseName = Regex.Replace(baseName, @"[^a-zA-Z0-9]", "");
            if (string.IsNullOrEmpty(baseName) || char.IsDigit(baseName[0]))
                baseName = "Element" + baseName;

            return baseName;
        }
        
        private static string ConvertTestIdToSemanticName(string testId)
        {
            // Convert common testId patterns to semantic names
            return testId
                .Replace("quoteSearchInput", "QuoteSearchInput")
                .Replace("businessNameInput", "BusinessNameInput")
                .Replace("owner.maritalStatus-other", "MaritalStatusMoreOptions")
                .Replace("btnConfirmYes", "ConfirmButton")
                .Replace("btnConfirmNo", "CancelButton")
                .Replace(".save_and_Continue", "SaveAndContinueButton")
                .Replace(".save", "SaveButton")
                .Replace("Button", "")
                .Replace("Input", "");
        }
        
        private static string AddControlTypeSuffix(string baseName, string? controlType)
        {
            if (string.IsNullOrEmpty(controlType)) return baseName;
            
            var suffix = controlType switch
            {
                "Button" when !baseName.EndsWith("Button") => "Button",
                "Link" when !baseName.EndsWith("Link") => "Link", 
                "SearchInput" when !baseName.EndsWith("Input") => "Input",
                "Tab" when !baseName.EndsWith("Tab") => "Tab",
                _ => ""
            };
            
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