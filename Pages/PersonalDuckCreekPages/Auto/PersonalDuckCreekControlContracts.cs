#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using PnCTestAutomation.Controls;

namespace PnCTestAutomation.Pages.PersonalDuckCreekPages.Auto
{
    public sealed record PersonalDuckCreekSelectionContract(
        string Operation,
        string TargetControl,
        string ReadinessControl,
        ControlAssertion ReadinessAssertion,
        ControlAssertion Postcondition);

    public static class PersonalDuckCreekControlContracts
    {
        public const string AccountDetailsNext = "account-details-next";
        public const string DivorcedMaritalOption =
            "marital-status-divorced";

        public static PersonalDuckCreekSelectionContract PolicyState { get; } =
            Selected("policy-state");

        public static PersonalDuckCreekSelectionContract WritingCompany
            { get; } = Selected("writing-company");

        public static PersonalDuckCreekSelectionContract AccountState { get; } =
            Selected("account-state");

        public static PersonalDuckCreekSelectionContract Married { get; } =
            Selected("marital-status-married");

        public static PersonalDuckCreekSelectionContract ConditionalProposal
            { get; } = new(
                "conditional-proposal",
                "conditional-proposal-control",
                "conditional-proposal-control",
                ControlAssertion.Enabled,
                ControlAssertion.Value);

        public static IReadOnlyList<PersonalDuckCreekSelectionContract> All
            { get; } =
        [
            PolicyState,
            WritingCompany,
            AccountState,
            Married,
            ConditionalProposal
        ];

        public static void Validate()
        {
            var duplicate = All
                .GroupBy(contract => contract.Operation, StringComparer.Ordinal)
                .FirstOrDefault(group => group.Count() > 1);
            if (duplicate != null)
            {
                throw new PersonalDuckCreekControlConfigurationException(
                    $"Duplicate Personal DuckCreek operation '{duplicate.Key}'.");
            }
            foreach (var contract in All)
            {
                if (string.IsNullOrWhiteSpace(contract.TargetControl) ||
                    !contract.TargetControl.Equals(
                        contract.ReadinessControl,
                        StringComparison.Ordinal))
                {
                    throw new PersonalDuckCreekControlConfigurationException(
                        $"Operation '{contract.Operation}' must wait on its actual control.");
                }
            }
            if (AccountState.TargetControl.Equals(
                    AccountDetailsNext,
                    StringComparison.Ordinal) ||
                Married.TargetControl.Equals(
                    DivorcedMaritalOption,
                    StringComparison.Ordinal))
            {
                throw new PersonalDuckCreekControlConfigurationException(
                    "Personal DuckCreek state or marital target is incorrect.");
            }
        }

        private static PersonalDuckCreekSelectionContract Selected(
            string target) =>
            new(
                target,
                target,
                target,
                ControlAssertion.Enabled,
                ControlAssertion.SelectedValue);
    }

    public sealed class PersonalDuckCreekControlConfigurationException :
        Exception
    {
        public PersonalDuckCreekControlConfigurationException(string message)
            : base(message)
        {
        }
    }
}
