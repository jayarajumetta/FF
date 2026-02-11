using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;

namespace Playwright_POC.Helpers
{
    internal class TableMappingHelpers
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
                    default:
                        throw new ArgumentException($"Unknown question: {question}");
                }
            }
        }

    }

}
