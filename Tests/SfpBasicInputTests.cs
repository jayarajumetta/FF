using System;
using System.Globalization;
using NUnit.Framework;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages.ExpertQuotePages.SFP;
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
            TableMappingHelpers.ResidenceFields(TableOf(("WiringYear", "2026")), data);
            TableMappingHelpers.ResidenceCoverageFields(TableOf(
                ("InsuranceAmount", "550000"), ("SquareFeet", "1800"), ("Perils", "5"),
                ("ThermostatQuestion", "Yes"), ("ActualCashValue", "Replacement Cost"),
                ("RCTOption", "Standard"), ("UseDefaults", "Yes")), data);
            TableMappingHelpers.FarmPersonalPropertyFields(TableOf(
                ("Code", "464"), ("Description", "Bose Sound Bars"),
                ("Limit", "101500"), ("Deductible", "$1,000")), data);

            Assert.Multiple(() =>
            {
                Assert.That(data.Farm.ResidenceElectricalYear, Is.EqualTo("2026"));
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

        [Test]
        public void LimitedFarmPollutionInputs_ReachExistingDomainModel()
        {
            var data = new ScenarioContextData();
            TableMappingHelpers.LimitedFarmPollutionFields(TableOf(
                ("CoverageName", "Limited Farm Pollution"),
                ("OccurrenceAggregate", "50000/300000"),
                ("TotalOnsiteCapacity", "8000000"),
                ("FurthestLocationMiles", "23"),
                ("WasteTripsPerYear", "550"),
                ("AboveGroundTanks", "Yes"),
                ("TankCapacity", "500000"),
                ("TankConstructionDate", "2024-03-31")), data);

            Assert.Multiple(() =>
            {
                Assert.That(data.Farm.LimitedFarmPollutionCoverageName, Is.EqualTo("Limited Farm Pollution"));
                Assert.That(data.Farm.LimitedFarmPollutionOccurrenceAggregate, Is.EqualTo("50000/300000"));
                Assert.That(data.Farm.LimitedFarmPollutionTotalOnsiteCapacity, Is.EqualTo("8000000"));
                Assert.That(data.Farm.LimitedFarmPollutionFurthestLocationMiles, Is.EqualTo("23"));
                Assert.That(data.Farm.LimitedFarmPollutionWasteTripsPerYear, Is.EqualTo("550"));
                Assert.That(data.Farm.LimitedFarmPollutionAboveGroundTanks, Is.EqualTo("Yes"));
                Assert.That(data.Farm.LimitedFarmPollutionTankCapacity, Is.EqualTo("500000"));
                Assert.That(data.Farm.LimitedFarmPollutionTankConstructionDate, Is.EqualTo("2024-03-31"));
            });
        }

        [Test]
        public void SourceBackedLocationInputs_MapWithoutLosingLeadingZerosOrOptionalSemantics()
        {
            var data = new ScenarioContextData();
            TableMappingHelpers.LocationInformationFields(TableOf(
                ("Territory", "007"),
                ("AllPerilDeductible", "$1,000"),
                ("WindHailDeductible", "2%"),
                ("HurricaneDeductible", "2%"),
                ("HurricaneOptional", "Yes")), data);

            Assert.Multiple(() =>
            {
                Assert.That(data.Farm.Territory, Is.EqualTo("007"));
                Assert.That(data.Farm.AllPerilDeductible, Is.EqualTo("$1,000"));
                Assert.That(data.Farm.WindHailDeductible, Is.EqualTo("2%"));
                Assert.That(data.Farm.HurricaneDeductible, Is.EqualTo("2%"));
                Assert.That(data.Farm.HurricaneDeductibleOptional, Is.True);
            });
        }

        [TestCase("Main House", new string[] { "Main House" }, 0)]
        [TestCase("Main House", new string[] { "Residence #1" }, 0)]
        [TestCase("Main House", new string[] { "Residence #1", "Residence #2" }, -1)]
        public void MortgageeResidence_UsesSoleGenericOptionButRejectsAmbiguousFallback(
            string requestedResidence,
            string[] availableResidences,
            int expectedIndex)
        {
            Assert.That(
                SFP_MortgageeLossPayeePage.ResolveResidenceOptionIndex(
                    requestedResidence,
                    availableResidences),
                Is.EqualTo(expectedIndex));
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
