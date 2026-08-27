using System.Text.RegularExpressions;

namespace InsuranceAutomation.Core;

/// <summary>
/// Utility class for formatting policy description strings with state, LOB, and timestamp placeholders.
/// </summary>
public static class DescriptionFormatter
{
    /// <summary>
    /// Formats a description string by replacing placeholders with actual values.
    /// Placeholders: {NMONTH}, {NDAY}, {NYEAR}, {Time}
    /// </summary>
    /// <param name="state">State abbreviation (e.g., "AL", "AZ")</param>
    /// <param name="lob">Line of Business (e.g., "UMB", "BAP", "GL")</param>
    /// <param name="descriptionType">Description type (e.g., "Basic", "StraightThrough", "Expanded")</param>
    /// <returns>Formatted description string with timestamp</returns>
    public static string FormatPolicyDescription(string state, string lob, string descriptionType = "Basic")
    {
        var now = DateTime.Now;
        return $"{state} {lob} {descriptionType} {now.Month}.{now.Day}.{now.Year} {now:HH:mm:ss}";
    }

    /// <summary>
    /// Replaces timestamp placeholders in a template string with actual date/time values.
    /// Supports: {NMONTH}, {NDAY}, {NYEAR}, {Time}
    /// </summary>
    /// <param name="template">Template string with placeholders</param>
    /// <returns>String with placeholders replaced</returns>
    public static string ReplaceDateTimePlaceholders(string template)
    {
        if (string.IsNullOrEmpty(template))
            return string.Empty;

        var now = DateTime.Now;
        var result = template;

        result = Regex.Replace(result, @"\{NMONTH\}", now.Month.ToString(), RegexOptions.IgnoreCase);
        result = Regex.Replace(result, @"\{NDAY\}", now.Day.ToString(), RegexOptions.IgnoreCase);
        result = Regex.Replace(result, @"\{NYEAR\}", now.Year.ToString(), RegexOptions.IgnoreCase);
        result = Regex.Replace(result, @"\{Time\}", now.ToString("HH:mm:ss"), RegexOptions.IgnoreCase);

        return result;
    }

    /// <summary>
    /// Builds a policy description from state and LOB data, with optional custom template.
    /// If template is provided, it will be used; otherwise, a default format is applied.
    /// </summary>
    /// <param name="state">State abbreviation</param>
    /// <param name="lob">Line of Business</param>
    /// <param name="descriptionType">Description type (default: "Basic")</param>
    /// <param name="customTemplate">Optional custom template (e.g., "{state} {lob} Custom {NMONTH}.{NDAY}.{NYEAR} {Time}")</param>
    /// <returns>Formatted description</returns>
    public static string BuildDescription(string state, string lob, string descriptionType = "Basic", string? customTemplate = null)
    {
        if (!string.IsNullOrEmpty(customTemplate))
        {
            var template = customTemplate
                .Replace("{state}", state, StringComparison.OrdinalIgnoreCase)
                .Replace("{lob}", lob, StringComparison.OrdinalIgnoreCase)
                .Replace("{type}", descriptionType, StringComparison.OrdinalIgnoreCase);

            return ReplaceDateTimePlaceholders(template);
        }

        return FormatPolicyDescription(state, lob, descriptionType);
    }
}
