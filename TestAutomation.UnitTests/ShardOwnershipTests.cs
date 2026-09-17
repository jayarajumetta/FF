using NUnit.Framework;
using System.Text.RegularExpressions;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public partial class ShardOwnershipTests
{
    [TestCase(@"Features\SFP\SFP_BasicPolicy.feature", 1, 3)]
    [TestCase(@"Features\SFP\SFP_CE.feature", 4, 6)]
    public void EveryShardedExamplesBlockHasExactlyOneExpectedShard(
        string relativePath,
        int minimumShard,
        int maximumShard)
    {
        var path = Path.Combine(FindRepositoryRoot(), relativePath);
        var lines = File.ReadAllLines(path);
        var examplesCount = 0;

        for (var index = 0; index < lines.Length; index++)
        {
            if (!lines[index].TrimStart().StartsWith("Examples:", StringComparison.Ordinal))
                continue;

            examplesCount++;
            var tags = new List<string>();
            for (var tagIndex = index - 1; tagIndex >= 0; tagIndex--)
            {
                var candidate = lines[tagIndex].Trim();
                if (candidate.Length == 0)
                    continue;
                if (!candidate.StartsWith("@", StringComparison.Ordinal))
                    break;

                tags.AddRange(candidate.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            }

            var shardTags = tags.Where(tag => ShardTagPattern().IsMatch(tag)).ToArray();
            Assert.That(shardTags, Has.Length.EqualTo(1),
                $"{relativePath}:{index + 1} must belong to exactly one numbered shard.");

            var shard = int.Parse(ShardTagPattern().Match(shardTags[0]).Groups[1].Value);
            Assert.That(shard, Is.InRange(minimumShard, maximumShard),
                $"{relativePath}:{index + 1} belongs to the wrong product shard range.");
        }

        Assert.That(examplesCount, Is.GreaterThan(0));
    }

    private static string FindRepositoryRoot()
    {
        var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
        while (directory != null)
        {
            if (File.Exists(Path.Combine(directory.FullName, "TestAutomation.csproj")))
                return directory.FullName;
            directory = directory.Parent;
        }

        throw new DirectoryNotFoundException("Could not locate the repository root.");
    }

    [GeneratedRegex("^@Shard([1-6])$")]
    private static partial Regex ShardTagPattern();
}
