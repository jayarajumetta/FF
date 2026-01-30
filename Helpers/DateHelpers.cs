using System;
using System.Text.RegularExpressions;

namespace Playwright_POC.Helpers
{
    /// <summary>
    /// Provides helper methods for date-related operations in test automation.
    /// </summary>
    /// <remarks>
    /// Default date format is "M/d/yyyy" (US format). For internationalization, consider making this configurable.
    /// </remarks>
    public static class DateHelpers
    {
        private const string DefaultFormat = "M/d/yyyy";

        /// <summary>
        /// Gets tomorrow's date in default format (M/d/yyyy).
        /// </summary>
        /// <returns>Tomorrow's date as a string.</returns>
        public static string GetTomorrowDate() => GetFutureDate(1);

        /// <summary>
        /// Gets a future date by adding days to today.
        /// </summary>
        /// <param name="daysFromToday">Number of days to add to today.</param>
        /// <param name="format">Date format string (optional).</param>
        /// <returns>Future date as a string.</returns>
        public static string GetFutureDate(int daysFromToday, string format = DefaultFormat)
            => DateTime.Now.AddDays(daysFromToday).ToString(format);

        /// <summary>
        /// Resolves date tokens: {{tomorrow}}, {{today}}, {{days+N}}, or returns literal value.
        /// </summary>
        /// <param name="value">Token or literal date string.</param>
        /// <returns>Resolved date string.</returns>
        public static string ResolveDateToken(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return GetTomorrowDate();

            var trimmed = value.Trim().ToLower();
            return trimmed switch
            {
                "{{tomorrow}}" => GetFutureDate(1),
                "{{today}}" => GetFutureDate(0),
                _ when TryParseDaysToken(trimmed, out int days) => GetFutureDate(days),
                _ => value
            };
        }

        /// <summary>
        /// Tries to parse a {{days+N}} token.
        /// </summary>
        /// <param name="token">Token string.</param>
        /// <param name="days">Parsed number of days.</param>
        /// <returns>True if parsing succeeded, otherwise false.</returns>
        private static bool TryParseDaysToken(string token, out int days)
        {
            days = 0;
            var match = Regex.Match(token, @"\{\{days\+(\d+)\}\}", RegexOptions.IgnoreCase);
            return match.Success && int.TryParse(match.Groups[1].Value, out days);
        }
    }
}

