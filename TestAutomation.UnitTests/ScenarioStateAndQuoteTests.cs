using NUnit.Framework;
using PnCTestAutomation.DataPool;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class ScenarioStateAndQuoteTests
{
    [Test]
    public void LegacyPropertiesAndDomainModelsShareTheSameScenarioState()
    {
        var state = new ScenarioContextData
        {
            ClientFirstName = "Ada",
            QuoteNumber = "01234567",
            RatingState = "Alabama"
        };

        Assert.Multiple(() =>
        {
            Assert.That(ScenarioContextData.ContextKey, Is.EqualTo("ContextData"));
            Assert.That(state.Client.FirstName, Is.EqualTo("Ada"));
            Assert.That(state.Policy.QuoteNumber, Is.EqualTo("01234567"));
            Assert.That(state.Policy.RatingState, Is.EqualTo("Alabama"));
        });
    }

    [TestCase("CE", "SFP", "CE")]
    [TestCase("Country Estate", "SFP", "CE")]
    [TestCase("Special Farm Package", "SFP", "BasicPolicy")]
    [TestCase("Personal Auto", "PA", null)]
    [TestCase("BOP", "BOP", null)]
    public void QuoteClassificationPreservesProductIdentity(
        string productSelection,
        string expectedLob,
        string? expectedVariant)
    {
        var state = new ScenarioContextData
        {
            QuoteNumber = "01234567",
            ProductSelection = productSelection,
            RatingState = "Alabama"
        };

        var record = QuoteRecordFactory.FromScenarioContext(state, "qa");

        Assert.Multiple(() =>
        {
            Assert.That(record, Is.Not.Null);
            Assert.That(record!.Lob, Is.EqualTo(expectedLob));
            Assert.That(record.SfpVariant, Is.EqualTo(expectedVariant));
            Assert.That(record.State, Is.EqualTo("AL"));
            Assert.That(record.Environment, Is.EqualTo("qa"));
        });
    }

    [Test]
    public void QuoteClassificationRequiresAQuoteIdentity()
    {
        var state = new ScenarioContextData
        {
            ProductSelection = "Special Farm Package",
            RatingState = "Alabama"
        };

        Assert.That(
            () => QuoteRecordFactory.FromScenarioContext(state),
            Throws.InvalidOperationException.With.Message.Contains(
                "must be captured in ScenarioContextData"));
    }
}
