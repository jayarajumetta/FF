using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;

namespace PnCTestAutomation.Helpers
{
    internal static class TableMappingHelpers
    {
        public static void ClientSearchFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];

                switch (question)
                {
                    case "FirstName":
                        _contextData.ClientFirstName = answer;
                        break;
                    case "LastName":
                        _contextData.ClientLastName = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void NewExistingClientFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "DOB":
                        _contextData.ClientDOB = answer;
                        break;
                    case "BestPhone":
                        _contextData.ClientPhoneNumber = answer;
                        break;
                    case "EmailAddress":
                        _contextData.ClientEmail = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void AccountOwnerFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "MiddleName":
                        _contextData.ClientMiddleName = answer;
                        break;
                    case "MaritalStatus":
                        _contextData.MaritalStatus = answer;
                        break;
                    case "StreetAddress":
                        _contextData.StreetAddress = answer;
                        break;
                    case "AptNumber":
                        _contextData.AptNumber = answer;
                        break;
                    case "City":
                        _contextData.City = answer;
                        break;
                    case "State":
                        _contextData.State = answer;
                        break;
                    case "ZipCode":
                        _contextData.ZipCode = answer;
                        break;
                    case "ReceivedMail":
                        _contextData.RecievedMail = answer;
                        break;
                    case "WhereClientResides":
                        _contextData.WhereClientResides = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void PAQuoteDetailsFields(Table table, ScenarioContextData _contextData)
        {
            // Set default EffectiveDate to tomorrow if not provided in the table
            _contextData.EffectiveDate = DateHelpers.GetTomorrowDate();

            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "EffectiveDate":
                        _contextData.EffectiveDate = answer;
                        break;
                    case "PolicyTerm":
                        _contextData.PolicyTerm = answer;
                        break;
                    case "AgentCode":
                        _contextData.AgentCode = answer;
                        break;
                    case "RatingState":
                        _contextData.RatingState = answer;
                        break;
                    case "SSN":
                        _contextData.SSN = answer;
                        break;
                    case "WritingCompany":
                        _contextData.WritingCompany = answer;
                        break;
                    case "RiskAddress":
                        _contextData.RiskAddress = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void BOPQuoteDetailsFields(Table table, ScenarioContextData _contextData)
        {
            // Set default EffectiveDate to tomorrow if not provided in the table
            _contextData.EffectiveDate = DateHelpers.GetTomorrowDate();

            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "ProductSelection":
                        // Used by table-driven product selector in SFPSteps; no context mapping needed.
                        break;
                    case "EffectiveDate":
                        _contextData.EffectiveDate = DateHelpers.ResolveDateToken(answer);
                        break;
                    case "PolicyTerm":
                        _contextData.PolicyTerm = answer;
                        break;
                    case "AgentCode":
                        _contextData.AgentCode = answer;
                        break;
                    case "RatingState":
                        _contextData.RatingState = answer;
                        break;
                    case "SSN":
                        _contextData.SSN = answer;
                        break;
                    case "WritingCompany":
                        _contextData.WritingCompany = answer;
                        break;
                    case "LessorRiskExposure":
                        _contextData.LessorRiskExposure = answer;
                        break;
                    case "BusinessEntity":
                        _contextData.BusinessEntity = answer;
                        break;
                    case "DBAName":
                        _contextData.DBAName = answer;
                        break;
                    case "RiskAddress":
                        _contextData.RiskAddress = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void SFPQuoteDetailsFields(Table table, ScenarioContextData _contextData)
        {
            // Set default EffectiveDate to tomorrow if not provided
            _contextData.EffectiveDate = DateHelpers.GetTomorrowDate();

            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "ProductSelection":
                    case "Product Selection":
                        // Consumed by step definition for product selection (SFP vs CE).
                        // No direct ScenarioContext mapping needed here.
                        break;
                    case "EffectiveDate":
                        _contextData.EffectiveDate = DateHelpers.ResolveDateToken(answer);
                        break;
                    case "PolicyTerm":
                        _contextData.PolicyTerm = answer;
                        break;
                    case "AgentCode":
                        _contextData.AgentCode = answer;
                        break;
                    case "RatingState":
                        _contextData.RatingState = answer;
                        break;
                    case "SSN":
                        _contextData.SSN = answer;
                        break;
                    case "OwnershipType":
                        _contextData.OwnershipType = answer;
                        break;
                    case "WritingCompany":
                        _contextData.WritingCompany = answer;
                        break;
                    case "RiskAddress":
                        _contextData.RiskAddress = answer;
                        break;
                    case "LessorRisk":
                        _contextData.LessorRisk = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void PreQualificationFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "EligibilityRestrictions":
                        _contextData.EligibilityRestrictions = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void BOPPreQualificationFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "ClassCodeNumber":
                        _contextData.ClassCodeNumber = answer;
                        break;
                    case "ClassDescription":
                        _contextData.ClassDescription = answer;
                        break;
                    case "Restrictions":
                        _contextData.ClassCodeRestriction = answer;
                        break;
                    case "ReceivedMail":
                        _contextData.RecievedMail = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }


        public static Dictionary<string, bool> MapYesNoTableToBool(Table table)
        {
            var result = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

            foreach (var row in table.Rows)
            {
                var question = row["Question"].Trim();
                var answer = row["Answer"].Trim();

                var state =
                    answer.Equals("Yes", StringComparison.OrdinalIgnoreCase) ||
                    answer.Equals("Y", StringComparison.OrdinalIgnoreCase) ||
                    answer.Equals("True", StringComparison.OrdinalIgnoreCase) ||
                    answer.Equals("1", StringComparison.OrdinalIgnoreCase);

                result[question] = state;
            }

            return result;
        }

        public static void DriverInfoFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "PhoneType":
                        _contextData.PhoneType = answer;
                        break;
                    case "Gender":
                        _contextData.Gender = answer;
                        break;
                    case "EmailType":
                        _contextData.EmailType = answer;
                        break;
                    case "NamedInsured":
                        _contextData.NamedInsured = answer;
                        break;
                    case "OperatorStatus":
                        _contextData.OperatorStatus = answer;
                        break;
                    case "DLNumber":
                        _contextData.DLNumber = answer;
                        break;
                    case "DLState":
                        _contextData.DLState = answer;
                        break;
                    case "YearsLicensed":
                        _contextData.YearsLicensed = answer;
                        break;
                    case "MonthsLicensed":
                        _contextData.MonthsLicensed = answer;
                        break;
                    case "RequireFinancialResponsibility":
                        _contextData.FinancialResponsibility = answer;
                        break;
                    case "PriorInsurance":
                        _contextData.PriorInsurance = answer;
                        break;
                    case "PriorCarrier":
                        _contextData.PriorCarrier = answer;
                        break;
                    case "PriorPolicyNumber":
                        _contextData.PriorPolicyNumber = answer;
                        break;
                    case "YearsWithPriorCarrier":
                        _contextData.PriorInsuranceYears = answer;
                        break;
                    case "MonthsWithPriorCarrier":
                        _contextData.PriorInsuranceMonths = answer;
                        break;
                    case "NoPriorInsuranceReason":
                        _contextData.NoPriorInsuranceReason = answer;
                        break;

                }
            }
        }

        public static void MapVehicleFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "VIN":
                        _contextData.VINNumber = answer;
                        break;
                    case "ModelYear":
                        _contextData.VehicleYear = answer;
                        break;
                    case "Make":
                        _contextData.VehicleMake = answer;
                        break;
                    case "Model":
                        _contextData.VehicleModel = answer;
                        break;
                    case "Trim":
                        _contextData.VehicleTrim = answer;
                        break;
                    case "VehicleType":
                        _contextData.VehicleType = answer;
                        break;
                    case "OwnedFinanced":
                        _contextData.VehicleOwnership = answer;
                        break;
                    case "CustomizedEquipment":
                        _contextData.CustomizedEquipment = answer;
                        break;
                    case "VehicleUse":
                        _contextData.VehicleUsage = answer;
                        break;
                    case "PurchaseDate":
                        _contextData.PurchaseDate = answer;
                        break;
                    case "OdometerReading":
                        _contextData.OdometerReading = answer;
                        break;
                    case "AnnualMileage":
                        _contextData.AnnualMileage = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void VehicleAssignmentFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "Vehicle":
                        _contextData.Vehicle = answer;
                        break;
                    case "DriverStatus":
                        _contextData.DriverStatus = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void PolicyCoverageFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "PolicyCoverage":
                        _contextData.PolicyCoverage = answer;
                        break;
                    case "CompCollOnly":
                        _contextData.CompCollOnly = answer;
                        break;
                    case "CompDeductible":
                        _contextData.CompDeductible = answer;
                        break;
                    case "CollDeductible":
                        _contextData.CollDeductible = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void AdditionalCoverageFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "AccidentalDeathAndDismemberment":
                        _contextData.AccidentalDeathAndDismemberment = answer;
                        break;
                    case "LossOfIncomeCoverage":
                        _contextData.LossOfIncome = answer;
                        break;
                    case "RentalReimbursement":
                        _contextData.RentalReimbursement = answer;
                        break;
                    case "RoadsideAssistance":
                        _contextData.RoadsideAssistance = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void AdditionalInterestFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "AddInterestType":
                        _contextData.AdditionalInterestType = answer;
                        break;
                    case "DoesJointOwnerDrive":
                        _contextData.JointOwnerDrive = answer;
                        break;
                    case "RelationshipToAccountOwner":
                        _contextData.RelationshipToAccountOwner = answer;
                        break;
                    case "AddInterestName":
                        _contextData.AdditionalInterestName = answer;
                        break;
                    case "AddInterestAddress":
                        _contextData.AdditionalInterestAddress = answer;
                        break;
                    case "AddInterestCity":
                        _contextData.AdditionalInterestCity = answer;
                        break;
                    case "AddInterestState":
                        _contextData.AdditionalInterestState = answer;
                        break;
                    case "AddInterestZip":
                        _contextData.AdditionalInterestZipCode = answer;
                        break;
                    case "AddInterestPhone":
                        _contextData.AdditionalInterestPhone = answer;
                        break;
                    case "AddInterestDOB":
                        _contextData.AdditionalInterestDOB = answer;
                        break;
                    case "AddInterestDLNumber":
                        _contextData.AdditionalInterestDLNumber = answer;
                        break;
                    case "AddInterestLicenseState":
                        _contextData.AdditionalInterestLicenseState = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }


        public static void BillingAccountFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "BillingAccount":
                        // Tosca: Select existing or Create New billing account
                        // Value stored for step logic ("Create New" vs existing)
                        break;
                    case "PrimaryPayer":
                        _contextData.PrimaryPayer = answer;
                        break;
                    case "PaymentType":
                        _contextData.PaymentType = answer;
                        break;
                    case "PaymentPlan":
                        _contextData.PaymentPlan = answer;
                        break;
                    case "PaymentDueDate":
                        _contextData.PaymentDueDate = answer;
                        break;
                    case "PaymentAmount":
                        _contextData.PaymentAmount = answer;
                        break;
                    case "PaymentMethod":
                        _contextData.PaymentMethod = answer;
                        break;
                    case "CheckNumber":
                        _contextData.CheckNumber = answer;
                        break;
                    case "Paperless":
                        _contextData.Paperless = answer;
                        break;
                    case "RoutingNumber":
                        _contextData.RoutingNumber = answer;
                        break;
                    case "AccountNumber":
                        _contextData.AccountNumber = answer;
                        break;
                    case "BankName":
                        _contextData.BankName = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void SearchExpress(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "SearchType":
                        _contextData.SearchType = answer;
                        break;

                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void SFPPolicyDataFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "PrimaryFarmType":
                        _contextData.PrimaryFarmType = answer;
                        break;
                    case "SecondaryFarmType":
                        _contextData.SecondaryFarmType = answer;
                        break;
                    case "SecondaryFarmSubType":
                        _contextData.SecondaryFarmSubType = answer;
                        break;
                    case "LivestockType":
                        _contextData.LivestockType = answer;
                        break;
                    case "GrossFarmIncome":
                        _contextData.GrossFarmIncome = answer;
                        break;
                    case "GrowIndustrialHemp":
                        _contextData.GrowIndustrialHemp = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }

        }

        public static void ClaimsAndPriorInsuranceFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "PriorFFANPolicy":
                        _contextData.PriorFFANPolicy =
                            answer.Equals("Yes", StringComparison.OrdinalIgnoreCase) ||
                            answer.Equals("Y", StringComparison.OrdinalIgnoreCase) ||
                            answer.Equals("True", StringComparison.OrdinalIgnoreCase) ||
                            answer.Equals("1", StringComparison.OrdinalIgnoreCase);
                        break;
                    case "YearsInBusiness":
                        _contextData.YearsInBusiness = answer;
                        break;
                    case "YearsContinuousCoverage":
                        _contextData.YearsContinuousCoverage = answer;
                        break;
                    case "PriorInsuranceExpDate":
                        _contextData.PriorInsuranceExpDate = DateHelpers.ResolveDateToken(answer);
                        break;
                    case "PriorInsuranceCarrier":
                        _contextData.PriorInsuranceCarrier = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void NarrativeFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];
                switch (question)
                {
                    case "Narrative":
                        _contextData.Narrative = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }

        }


        public static void LocationInformationFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];

                switch (question)
                {
                    case "LocationNickname":
                        _contextData.LocationNickname = answer;
                        break;

                    case "LocationType":
                        _contextData.LocationType = answer;
                        break;

                    case "MilesFromFireDepartment":
                        _contextData.MilesFromFireDepartment = answer;
                        break;

                    case "FeetFromHydrant":
                        _contextData.FeetFromHydrant = answer;
                        break;

                    case "PPC":
                        _contextData.PPC = answer;
                        break;

                    case "TotalAcreage":
                        _contextData.TotalAcreage = answer;
                        break;

                    case "WindHailDeductible":
                        _contextData.WindHailDeductible = answer;
                        break;

                    default:
                        throw new ArgumentException($"Unknown question: {question}");

                }
            }
        }

        // ══════════════════════════════════════════════════════════════════
        // SFP BASIC POLICY MAPPINGS
        // ══════════════════════════════════════════════════════════════════

        public static void SSNFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];

                switch (question)
                {
                    case "SSN":
                        _contextData.SSN = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

        public static void ResidenceFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];

                switch (question)
                {
                    case "AdditionalDesc":
                        _contextData.ResidenceAdditionalDesc = answer;
                        break;
                    case "YearBuilt":
                        _contextData.ResidenceYearBuilt = answer;
                        break;
                    case "RateType":
                        _contextData.ResidenceRateType = answer;
                        break;
                    case "NumberOfFamilies":
                        _contextData.ResidenceNumberOfFamilies = answer;
                        break;
                    case "ConditionRating":
                        _contextData.ResidenceConditionRating = answer;
                        break;
                    case "RoofYear":
                        _contextData.ResidenceRoofYear = answer;
                        break;
                    case "RoofType":
                        _contextData.ResidenceRoofType = answer;
                        break;
                    case "RoofImpact":
                        _contextData.ResidenceRoofImpact = answer;
                        break;
                    case "SeasonalOrVacant":
                        _contextData.ResidenceSeasonalOrVacant = answer;
                        break;
                    case "SolidFuelQuestion":
                        _contextData.ResidenceSolidFuelQuestion = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown Residence question: {question}");
                }
            }
        }

        public static void ResidenceCoverageFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];

                switch (question)
                {
                    case "InsuranceAmount":
                        _contextData.ResidenceInsuranceAmount = answer;
                        break;
                    case "SquareFeet":
                        _contextData.ResidenceSquareFeet = answer;
                        break;
                    case "Perils":
                        _contextData.ResidencePerils = answer;
                        break;
                    case "ThermostatQuestion":
                        _contextData.ResidenceThermostatQuestion = answer;
                        break;
                    case "ActualCashValue":
                        _contextData.ResidenceActualCashValue = answer;
                        break;
                    case "RCTOption":
                        _contextData.ResidenceRCTOption = answer;
                        break;
                    case "UseDefaults":
                        _contextData.ResidenceUseDefaults = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown Residence Coverage question: {question}");
                }
            }
        }

        public static void FarmPersonalPropertyFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];

                switch (question)
                {
                    case "Code":
                        _contextData.FarmPropertyCode = answer;
                        break;
                    case "Description":
                        _contextData.FarmPropertyDescription = answer;
                        break;
                    case "Limit":
                        _contextData.FarmPropertyLimit = answer;
                        break;
                    case "Deductible":
                        _contextData.FarmPropertyDeductible = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown Farm Personal Property question: {question}");
                }
            }
        }

        public static void ScheduledPersonalPropertyFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];

                switch (question)
                {
                    case "Category":
                        _contextData.SPPCategory = answer;
                        break;
                    case "ItemType":
                        _contextData.SPPItemType = answer;
                        break;
                    case "Description":
                        _contextData.SPPDescription = answer;
                        break;
                    case "Limit":
                        _contextData.SPPLimit = answer;
                        break;
                    case "YearOfAppraisal":
                        _contextData.SPPYearOfAppraisal = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown Scheduled Personal Property question: {question}");
                }
            }
        }

        public static void LiabilityFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];

                switch (question)
                {
                    case "LiabilityLimit":
                        _contextData.LiabilityLimit = answer;
                        break;
                    case "LivestockHorses":
                        _contextData.LivestockHorses = answer;
                        break;
                    case "LivestockSmall":
                        _contextData.LivestockSmall = answer;
                        break;
                    case "LivestockLarge":
                        _contextData.LivestockLarge = answer;
                        break;
                    case "NumberOfEmployees":
                        _contextData.NumberOfEmployees = answer;
                        break;
                    case "UnlistedAcreage":
                        _contextData.UnlistedAcreage = answer;
                        break;
                    case "WorkersCompFullTimeIn":
                        _contextData.WorkersCompFullTimeInServants = answer;
                        break;
                    case "WorkersCompPartTimeIn":
                        _contextData.WorkersCompPartTimeInServants = answer;
                        break;
                    case "WorkersCompFullTimeOut":
                        _contextData.WorkersCompFullTimeOutServants = answer;
                        break;
                    case "WorkersCompPartTimeOut":
                        _contextData.WorkersCompPartTimeOutServants = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown Liability question: {question}");
                }
            }
        }

        public static void InsuranceScoreFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];

                switch (question)
                {
                    case "EntityType":
                        _contextData.InsuranceScoreEntityType = answer;
                        break;
                    case "InsuranceScoreConsent":
                        _contextData.InsuranceScoreConsent = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown Insurance Score question: {question}");
                }
            }
        }

        public static void MortgageeFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];

                switch (question)
                {
                    case "SearchName":
                        _contextData.MortgageeSearchName = answer;
                        break;
                    case "Location":
                        _contextData.MortgageeLocation = answer;
                        break;
                    case "Residence":
                        _contextData.MortgageeResidence = answer;
                        break;
                    case "CopyOfDEC":
                        _contextData.MortgageeCopyOfDEC = answer;
                        break;
                    case "AccountNumber":
                        _contextData.MortgageeAccountNumber = answer;
                        break;
                    case "DescriptionOfInterest":
                        _contextData.MortgageeDescriptionOfInterest = answer;
                        break;
                    case "EscrowBilled":
                        _contextData.MortgageeEscrowBilled = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown Mortgagee question: {question}");
                }
            }
        }

        public static void ChecklistItemFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];

                switch (question)
                {
                    case "ItemName":
                        _contextData.ChecklistItemName = answer;
                        break;
                    case "Action":
                        _contextData.ChecklistAction = answer;
                        break;
                    case "ExceptionNote":
                        _contextData.ChecklistExceptionNote = answer;
                        break;
                    case "Note":
                        _contextData.ChecklistNote = answer;
                        break;
                    case "Optional":
                        // Handled directly by the step definition — not stored in context
                        break;
                    default:
                        throw new ArgumentException($"Unknown Checklist question: {question}");
                }
            }
        }

        public static void DuckcreekFormsFields(Table table, ScenarioContextData _contextData)
        {
            foreach (var row in table.Rows)
            {
                var question = row["Question"];
                var answer = row["Answer"];

                switch (question)
                {
                    case "ClientName":
                        // Parse {{fullName}} or use as-is
                        if (answer.Contains("{{fullName}}"))
                            answer = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";
                        break;
                    case "State":
                        _contextData.Address.State = answer;
                        break;
                    case "LOB":
                        _contextData.FormsLob = answer;
                        break;
                    case "TestCase":
                        _contextData.FormsTestCase = answer;
                        break;
                    default:
                        throw new ArgumentException($"Unknown Duckcreek Forms question: {question}");
                }
            }
        }
    }
}
