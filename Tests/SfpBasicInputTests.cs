using System;
using System.Globalization;
using NUnit.Framework;
using PnCTestAutomation.Helpers;
using Reqnroll;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class SfpBasicInputTests
    {
        [TestCase("CURRENT YEAR")]
        [TestCase(" current year ")]
        [TestCase("{{currentYear}}")]
        public void RoofYear_ResolvesAtRuntime(string value)
        {
            var table = TableOf(("RoofYear", value), ("YearBuilt", "2024"),
                ("HeatingYear", "2026"), ("PlumbingYear", "2025"), ("ElectricalYear", "2026"));
            var data = new ScenarioContextData();
            var before = DateTime.Today.Year.ToString(CultureInfo.InvariantCulture);
            TableMappingHelpers.ResidenceFields(table, data);
            var after = DateTime.Today.Year.ToString(CultureInfo.InvariantCulture);

            Assert.That(data.ResidenceRoofYear, Is.EqualTo(before).Or.EqualTo(after));
            Assert.That(data.ResidenceYearBuilt, Is.EqualTo("2024"));
            Assert.That(data.Farm.ResidenceHeatingYear, Is.EqualTo("2026"));
            Assert.That(data.Farm.ResidencePlumbingYear, Is.EqualTo("2025"));
            Assert.That(data.Farm.ResidenceElectricalYear, Is.EqualTo("2026"));
        }

        [Test]
        public void LiteralRoofYearAndExistingDateTokens_AreUnchanged()
        {
            var data = new ScenarioContextData();
            TableMappingHelpers.ResidenceFields(TableOf(("RoofYear", "2022")), data);
            Assert.That(data.ResidenceRoofYear, Is.EqualTo("2022"));
            Assert.That(data.Farm.ResidenceHeatingYear, Is.Null);
            Assert.That(DateHelpers.ResolveDateToken("03/31/2024"), Is.EqualTo("03/31/2024"));
            Assert.That(DateHelpers.ResolveDateToken("{{tomorrow}}"), Is.EqualTo(DateHelpers.GetTomorrowDate()));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("202")]
        [TestCase("{{unknownYear}}")]
        [TestCase("03/31/2024")]
        public void InvalidYear_FailsExplicitly(string value)
        {
            Assert.Throws<ArgumentException>(() => DateHelpers.ResolveYearToken(value));
        }

        [Test]
        public void UnknownResidenceField_FailsExplicitly()
        {
            Assert.Throws<ArgumentException>(() =>
                TableMappingHelpers.ResidenceFields(TableOf(("ElecticalYear", "2026")), new ScenarioContextData()));
        }

        [Test]
        public void ProposedCoverageInputs_ReachExistingDomainModel()
        {
            var data = new ScenarioContextData();
            TableMappingHelpers.ResidenceCoverageFields(TableOf(
                ("InsuranceAmount", "550000"), ("SquareFeet", "1800"), ("Perils", "5"),
                ("ThermostatQuestion", "Yes"), ("ActualCashValue", "Replacement Cost"),
                ("RCTOption", "Standard"), ("UseDefaults", "Yes")), data);
            TableMappingHelpers.FarmPersonalPropertyFields(TableOf(
                ("Code", "464"), ("Description", "Bose Sound Bars"),
                ("Limit", "101500"), ("Deductible", "$1,000")), data);

            Assert.Multiple(() =>
            {
                Assert.That(data.Farm.ResidenceInsuranceAmount, Is.EqualTo("550000"));
                Assert.That(data.Farm.ResidenceSquareFeet, Is.EqualTo("1800"));
                Assert.That(data.Farm.ResidencePerils, Is.EqualTo("5"));
                Assert.That(data.Farm.ResidenceThermostatQuestion, Is.EqualTo("Yes"));
                Assert.That(data.Farm.ResidenceActualCashValue, Is.EqualTo("Replacement Cost"));
                Assert.That(data.Farm.ResidenceRCTOption, Is.EqualTo("Standard"));
                Assert.That(data.Farm.ResidenceUseDefaults, Is.EqualTo("Yes"));
                Assert.That(data.Farm.FarmPropertyCode, Is.EqualTo("464"));
                Assert.That(data.Farm.FarmPropertyDescription, Is.EqualTo("Bose Sound Bars"));
                Assert.That(data.Farm.FarmPropertyLimit, Is.EqualTo("101500"));
                Assert.That(data.Farm.FarmPropertyDeductible, Is.EqualTo("$1,000"));
            });
        }

        internal static Table TableOf(params (string Question, string Answer)[] rows)
        {
            var table = new Table("Question", "Answer");
            foreach (var row in rows)
                table.AddRow(row.Question, row.Answer);
            return table;
        }
    }
}
