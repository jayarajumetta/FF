using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace InsuranceAutomation.CLDC.Runtime;

public static class RegressionProfileCatalog
{
    private static readonly Lazy<RegressionProfileRoot> Profiles = new(Load);

    public static RegressionLobProfile For(string lob)
    {
        if (Profiles.Value.Profiles.TryGetValue(lob, out var profile)) return profile;
        throw new InvalidOperationException($"No regression profile is defined for LOB '{lob}'.");
    }

    private static RegressionProfileRoot Load()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "TestData", "Regression", "RegressionProfiles.json");
        if (!File.Exists(path)) throw new FileNotFoundException("Regression profile catalog was not copied to the test output.", path);
        return JsonSerializer.Deserialize<RegressionProfileRoot>(File.ReadAllText(path), new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new InvalidOperationException("RegressionProfiles.json is empty or invalid.");
    }
}

public static class RegressionDateRules
{
    private static readonly Regex Token = new(@"([+-])(\d+)([dMy])", RegexOptions.Compiled);

    public static string Resolve(string effectiveDate, string rule)
    {
        if (!DateTime.TryParse(effectiveDate, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out var result) &&
            !DateTime.TryParse(effectiveDate, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out result))
            throw new InvalidOperationException($"Unable to parse policy effective date '{effectiveDate}'.");

        foreach (Match match in Token.Matches(rule ?? string.Empty))
        {
            var amount = int.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
            if (match.Groups[1].Value == "-") amount *= -1;
            result = match.Groups[3].Value switch
            {
                "d" => result.AddDays(amount),
                "M" => result.AddMonths(amount),
                "y" => result.AddYears(amount),
                _ => result
            };
        }
        return result.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
    }
}
