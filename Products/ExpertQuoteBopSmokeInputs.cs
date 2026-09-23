#nullable enable
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.Products;

public static class ExpertQuoteBopSmokeInputs
{
    public const string AutomationFamily = "SGS-CLEQ-03-EQ-BOP-SMOKE-TEST";
    public const string AlabamaIdentity = AutomationFamily + ":AL-3B2D76491867";
    public const string Profile = "TestData/Scenarios/Smoke/03_eq_bop_smoke_test_al.json";
    public const string ExternalProfile = "TestData/ExternalDataOverrides.json";
    public const string MainScope = "cleq-main";

    public static void Load(ISgsScenarioData data, ScenarioContextData state, string profile, string externalProfile)
    {
        if (profile.Replace('\\', '/') != Profile || externalProfile.Replace('\\', '/') != ExternalProfile)
            throw new SgsScenarioDataException("Only the reviewed ExpertQuote BOP Alabama input selection is authorized.");
        data.Load(new SgsScenarioDataRequest("CLEQ", profile, "AL", externalProfile,
            new Dictionary<string, string?>
            {
                ["values.effective_date"] = "{DATE[][][MM/dd/yyyy]}"
            }));
        data.ValidateRequiredInputs(
        [
            "values.customer_dateofbirth", "values.street_address_18", "values.city_20",
            "values.state_21", "values.zip_22", "values.individual_31", "values.individual_dba",
            "values.effective_date", "values.new_account_address", "values.agentpc",
            "values.line_of_business", "values.prequalification_51", "values.prequalification_64"
        ]);
        if (data.GetRequired("values.state") != "AL" ||
            data.GetRequired("values.individual_31") != "Individual" ||
            data.GetRequired("values.line_of_business") != "BOP" ||
            !bool.TryParse(data.GetRequired("values.new_account_address"), out var accountAddress) || !accountAddress ||
            data.GetRequired("values.prequalification_51") != "PreQualification" ||
            data.GetRequired("values.prequalification_64") != "PreQualification")
            throw new SgsScenarioDataException("The selected inputs do not match the reviewed BOP smoke business contract.");

        state.Client.FirstName = data.GenerateRandom("FirstName");
        state.Client.LastName = data.GenerateRandom("LastName");
        state.Client.MiddleName = "";
        state.Client.DateOfBirth = data.GetRequired("values.customer_dateofbirth");
        var phone = data.GenerateRandom("OwnerPhone");
        if (!Regex.IsMatch(phone, @"^3[0-9]{9}$", RegexOptions.CultureInvariant))
            throw new SgsScenarioDataException("The owner phone does not satisfy the reviewed source data pattern.");
        state.Client.Phone = $"({phone[..3]}) {phone[3..6]}-{phone[6..]}";
        state.Client.Email = data.GenerateRandom("OwnerEmail");
        state.Client.SSN = data.GenerateRandom("InsuredSSN");
        state.Client.MaritalStatus = "Married";
        state.Address.Street = data.GetRequired("values.street_address_18");
        state.Address.AptNumber = "";
        state.Address.City = data.GetRequired("values.city_20");
        state.Address.State = data.GetRequired("values.state_21");
        state.Address.ZipCode = data.GetRequired("values.zip_22");
        state.Address.ReceivesMail = "Yes";
        state.Address.IsResidence = "Yes";
        state.Policy.EffectiveDate = data.GetRequired("values.effective_date");
        state.Policy.AgentCode = data.GetRequired("values.agentpc");
        state.Policy.RatingState = data.GetRequired("values.state_21");
        state.Business.EntityType = "Individually Owned";
        state.Business.DBAName = data.GetRequired("values.individual_dba");
        state.Business.LessorRiskExposure = "No";
    }
}
