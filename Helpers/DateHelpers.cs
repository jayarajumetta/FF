using System;
using System.Text.RegularExpressions;

namespace Playwright_POC.Helpers
{
    /// <summary>
    /// Provides helper methods for date-related operations in test automation.
    /// </summary>
    /// <remarks>
    /// Default date format is "M/d/yyyy" (US format). For internationalization, consider making this configurable.
    /// 
    /// Supported tokens:
    /// - {{today}} - Today's date
    /// - {{tomorrow}} - Tomorrow's date
    /// - {{futureDate:+Xd}} - X days in the future (e.g., {{futureDate:+30d}})
    /// - {{pastDate:-Xd}} - X days in the past (e.g., {{pastDate:-30d}})
    /// - {{days+N}} - Legacy: N days from today (deprecated, use futureDate instead)
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
        /// Gets today's date in default format (M/d/yyyy).
        /// </summary>
        /// <returns>Today's date as a string.</returns>
        public static string GetTodayDate() => GetFutureDate(0);

        /// <summary>
        /// Gets a future date by adding days to today.
        /// </summary>
        /// <param name="daysFromToday">Number of days to add to today.</param>
        /// <param name="format">Date format string (optional).</param>
        /// <returns>Future date as a string.</returns>
        public static string GetFutureDate(int daysFromToday, string format = DefaultFormat)
            => DateTime.Now.AddDays(daysFromToday).ToString(format);

        /// <summary>
        /// Gets a past date by subtracting days from today.
        /// </summary>
        /// <param name="daysBeforeToday">Number of days to subtract from today (positive number).</param>
        /// <param name="format">Date format string (optional).</param>
        /// <returns>Past date as a string.</returns>
        public static string GetPastDate(int daysBeforeToday, string format = DefaultFormat)
            => DateTime.Now.AddDays(-Math.Abs(daysBeforeToday)).ToString(format);

        /// <summary>
        /// Resolves date tokens or returns literal value.
        /// </summary>
        /// <param name="value">Token or literal date string.</param>
        /// <returns>Resolved date string.</returns>
        /// <remarks>
        /// Supported tokens:
        /// - {{today}} - Today's date
        /// - {{tomorrow}} - Tomorrow's date
        /// - {{futureDate:+Xd}} - X days in the future
        /// - {{pastDate:-Xd}} - X days in the past
        /// - {{days+N}} - Legacy: N days from today
        /// </remarks>
        public static string ResolveDateToken(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return GetTomorrowDate();

            var trimmed = value.Trim();
            var lowerTrimmed = trimmed.ToLower();

            // Exact match tokens
            return lowerTrimmed switch
            {
                "{{tomorrow}}" => GetFutureDate(1),
                "{{today}}" => GetFutureDate(0),
                _ when TryParseFutureDateToken(trimmed, out int futureDays) => GetFutureDate(futureDays),
                _ when TryParsePastDateToken(trimmed, out int pastDays) => GetPastDate(pastDays),
                _ when TryParseDaysToken(lowerTrimmed, out int days) => GetFutureDate(days),
                _ => value
            };
        }

        /// <summary>
        /// Tries to parse a {{futureDate:+Xd}} token.
        /// Example: {{futureDate:+30d}} returns 30
        /// </summary>
        private static bool TryParseFutureDateToken(string token, out int days)
        {
            days = 0;
            var match = Regex.Match(token, @"\{\{futureDate:\+(\d+)d\}\}", RegexOptions.IgnoreCase);
            return match.Success && int.TryParse(match.Groups[1].Value, out days);
        }

        /// <summary>
        /// Tries to parse a {{pastDate:-Xd}} token.
        /// Example: {{pastDate:-30d}} returns 30
        /// </summary>
        private static bool TryParsePastDateToken(string token, out int days)
        {
            days = 0;
            var match = Regex.Match(token, @"\{\{pastDate:-(\d+)d\}\}", RegexOptions.IgnoreCase);
            return match.Success && int.TryParse(match.Groups[1].Value, out days);
        }

        /// <summary>
        /// Tries to parse a {{days+N}} token (legacy format).
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

