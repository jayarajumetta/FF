using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using System;
using System.Net.NetworkInformation;

namespace Playwright_POC.Locators
{
    public static class ExpertQuoteLocatorFactory
    {

        internal class SearchRecentlyAccessedListLocators(string value)
        {
            public static string SelectRecentlyAccessedClient(string value) =>
                $"xpath=.//table//tr[td[contains(text(), '{value}')]]//button";
        }
        internal class AccountInformationPageLocators
        {



            public static ILocator GetReceivedMailButton(IPage page, string yesOrNo) =>
                page
                    .Locator("[data-testid^='owner.address.resided90days-']") 
                    .Filter(new() { HasTextString = yesOrNo });


            public static ILocator GetClientResidesButton(IPage page, string yesOrNo) =>
                page
                    .Locator("button[data-testid^='owner.address.useAsResidence']")
                    .Filter(new() { HasTextString = yesOrNo });


            public static string SelectLessorsRiskExposureButton(string yesOrNo) =>
                $"xpath=.//button[contains(@id, 'LessorsRiskExposure')]//div[contains(text(), '{yesOrNo}')]";
            public static ILocator SelectPolicyTermFromDropdown(IPage page, string value) =>
                page
                    .GetByRole(AriaRole.Listbox)
                    .GetByRole(AriaRole.Option, new() { Name = value });

            public static ILocator GetStateDropdownSelectionLocator(IPage page, string stateCode) =>
                page
                    .GetByRole(AriaRole.Listbox)
                    .GetByRole(AriaRole.Option, new() { Name = stateCode.ToUpper() });
        }




        //SFP Policy Details
        // Choose Farm Type
        internal class SFPPolicyDetailsPageLocators
        {
            public static ILocator SelectFarmTypeButton(IPage page, string value) =>
                page.GetByRole(AriaRole.Button, new() { Name = value });

            public static ILocator SelectLivestockTypeRadioButton(IPage page, string value) =>
                page.Locator("mat-radio-button[data-testid*='farmType']").Filter(new() {Has = page.Locator($"span[style*='pointer-events: none']:text-is(\"{value}\")")});



            public static ILocator GrowIndustrialHemp(IPage page, string yesOrNo) =>
                page.Locator("button[data-testid*='industrialHemp']").Filter(new() { HasTextString = yesOrNo });
        }

        internal class PreQualificationPageLocators
        {

            public static ILocator GetQualificationSelection(IPage page, string value) =>
                page
                .GetByRole(AriaRole.Button, new() { Name = value });
                

            //Add Class Code Section of Prequalifications Page
            public static string PrimaryClassCodeToggle(string classCode) =>
                $"xpath=.//tr[td[contains(normalize-space(text(),'{classCode}')]//mat-slide-toggle";

            public static string ClassCodeDeleteButton(string classCode) =>
                $"xpath=.//tr[td[contains(normalize-space(text()),'{classCode}')]//button[contains(@data-testid, 'removeClassFromPolicy')]";

            // Add Class Codes
            public static string CheckboxByClassCode(string classCode) =>
                $"css=tr:has(td:has-text('{classCode}')) label.mat-checkbox-layout";

            public static string CheckboxByDescription(string description) =>
                $"css=tr:has(td:has-text('{description}')) label.mat-checkbox-layout";

            public static string VerifyClassCodeSelected(string classCode) =>
                $"xpath=.//div[contains(@ng-reflect-message, '{classCode}')]";

            public static string RemoveClassCodeFromSelection(string classCode) =>
                $"xpath=.//div[contains(@ng-reflect-message, '{classCode}')]//button";

            // Industry / Class Code Restrictions Section
            // Do and of these industry or class code specific restrictions apply?
            public static string SelectClassCodeRestrictionCheckbox(string restriction) =>
                $"xpath=.//button//span[contains(text(), '{restriction}')]";
        }

        internal class PrimaryInsuredPageLocators
        {


            public static string SelectEntityTypeButton(string value) =>
                $"xpath=.//button[contains(@data-testid, 'fields.data.account.accountInput$entityType.value-0')]//div[contains(text(), '{value}')]";

            public static string GeneralUWQuestions(string value) =>
                $"xpath=.//button[contains(@data-testid, 'underwritingQuestionsGeneralUWQuestions')]//span[contains(text(), '{value}')]";

            public static string IndustryClassCodeQuestions(string value) =>
                $"xpath=.//button[contains(@data-testid, 'underwritingQuestionsIndustryClassCodeQuestions')]//span[contains(text(), '{value}')]";
        }

        internal class ClaimsPriorInsurancePageLocators
        {
            // Wer the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?
            public static string PriorFFANPolicies(string yesOrNo) =>
                $"xpath=.//button[contains(@data-testid, 'fields.data.policy.policyInput$exposuresInsuredAN90Days')]//div[contains(text(), '{yesOrNo}')]";

            // How many years have you maintained continuous insurance coverage?
            public static string YearsOfContinuousCoverage(string value) =>
                $"xpath=.//button[contains(@data-testid, 'fields.data.policy.policyUnderwriting.policyUnderwritingInput$yearsMaintainedContinuousInsuranceCoverage')]//div[contains(text(), '{value}')]";
        }

        internal class AddBuildingPageLocators
        {
            public static string SelectLocationFromDropdown(string value) =>
                $"xpath=.//mat-option[contains(@data-testid, 'buildingLocationID')]//span[contains(text(), '{value}')]";

            public static string SelectOwnershipButton(string value) =>
                $"xpath=.//button[contains(@data-testid, 'buildingOccupiedEQ')]//div[contains(text(), '{value}')]";

            public static string SelectClassCodeFromClassCodesSection(string value) =>
                $"xpath=.//mat-option[contains(@data-testid, 'buildingClassCodeID')]//span[contains(text(), '{value}')]";

            public static string CheckboxByClassCode(string classCode) =>
                $"xpath=.//tr[td[contains(normalize-space(text())='{classCode}']]//input[@type='checkbox]";

            public static string CheckboxByDescription(string description) =>
                $"xpath=.//tr[td[contains(normalize-space(.),'{description}')]//input[@type='checkbox']";

            public static string OccupancySqFtInputByClassCode(string classCode) =>
                $"xpath=.//tr[td[contains(normalize-space(.),'{classCode}')]//input[contains(@name, 'bOP_SquareFootage.value')]";

            public static string PersonalPropertyLimitInput(string description) =>
                $"xpath=.//tr[td[contains(normalize-space(.),'{description}')]//input[contains(@data-testid, 'occupancyOutputNonShredded$bPPNotSelectedZeroLimitForDisplay.value')]";

            public static string GrossSalesReceiptsInput(string description) =>
                $"xpath=.//tr[td[contains(normalize-space(.),'{description}')]//input[contains(@data-testid, 'covRiskLiabilityInput$grossSalesReceipts.value')]";

            public static string SelectPersonalPropertyRatingBasisButton(string value) =>
                $"xpath=.//button[contains(@data-testid, 'riskInput$ratingBasisPersonalProperty')]//div[contains(text(), '{value}')]";

            // Building Details
            public static string SelectConstructionTypeButton(string value) =>
                $"xpath=.//button[contains(@data-testid, 'buildingInput$constructionCode.value')]//div[contains(text(), '{value}')]";

            public static string SelectFromMoreOptionsDropdown(string value) =>
                $"xpath=.//button[contains(@data-testid, 'constructionCode')]//div[contains(text(), '{value}')]";

            public static string SelectSprinklerButton(string yesOrNo) =>
                $"xpath=.//button[contains(@data-testid, 'buildingInput$sprinkler')]//div[contains(text(), '{yesOrNo}')]";

            public static string SelectFireBurglarAlarmFromDropdown(string value) =>
                $"xpath=.//mat-option[contains(@data-testid, 'buildingInput$fireBurglarAlarm')]//span[contains(text(), '{value}')]";

            public static string SelectProtectiveSafeguardsButton(string yesOrNo) =>
                $"xpath=.//button[contains(@data-testid, 'buildingInput$protectiveSafeguards')]//div[contains(text(), '{yesOrNo}')]";



        }
        internal class EditLocationPageLocators
        {
            public static string SelectFeetFromHydrantFromDropdown(string value) =>
                $"xpath=.//mat-option[contains(@data-testid, 'feetFromHydrant')]//span[contains(text(), '{value}')]";

            public static string SelectDistanceToCoastFromDropdown(string value) =>
                $"xpath=.//mat-option[contains(@data-testid, 'coastDistanceCode')]//span[contains(text(), '{value}')]";

            public static string SelectDistanceToBodyOfWaterFromDropdown(string value) =>
                $"xpath=.//mat-option[contains(@data-testid, 'waterDistanceCode')]//span[contains(text(), '{value}')]";
        }

        internal class DriverSummaryPageLocators
        {

            public static ILocator GetGenderButton(IPage page, string value) =>
                page
                .GetByRole(AriaRole.Button, new() { Name = value });

            // Is this driver a named insured?
            public static ILocator GetNamedInsuredButton(IPage page, string value) =>
                page
                .GetByRole(AriaRole.Button, new() { Name = value });


            // Operator Status
            public static ILocator GetOperatorStatus(IPage page, string value) =>
                page
                .GetByRole(AriaRole.Button, new() { Name = value });

            // More Options Dropdown Values
            public static ILocator GetMoreOptionsValues(IPage page, string value) =>
                page
                .GetByRole(AriaRole.Button, new() { Name = value });

            // Phone Type Button Options
            public static ILocator GetPhoneTypeButton(IPage page, string value) =>
                page
                .GetByRole(AriaRole.Button, new() { Name = value });

            // Email Type Button Options
            public static ILocator GetEmailTypeButton(IPage page, string value) =>
                page
                .GetByRole(AriaRole.Button, new() { Name = value });

            // Account Owner Information

            public static ILocator GetMaritalStatusSelection(IPage page, string maritalStatus) =>
                page.Locator("button[data-testid^='owner.maritalStatus-']")
                    .Filter(new() { HasTextString = maritalStatus.Trim() });



            // Suffix Dropdown Values
            public static ILocator GetSuffixValueButton(IPage page, string value) =>
               page
                    .GetByRole(AriaRole.Listbox)
                    .GetByRole(AriaRole.Option, new() { Name = value });


            // Does driver require evidence of financial responsibility?
            public static string GetFinancialResponsibilityButton(string yesOrNo) =>
                $"xpath=.//button[contains(@id, 'sR22Indicator') and .//div[text()='{yesOrNo}']]";



            //Prior Insurance
            public static string GetPriorInsuranceButton(string yesOrNo) =>
                $"xpath=.//button[contains(@id, 'priorInsurance') and .//div[text()= '{yesOrNo}']]";



            //Reason For No Prior Insurance
            public static string GetReasonForNoPriorInsurance(string value) =>
                $"xpath=.//button[contains(text(), '{value}')]";

        }

        internal class VehicleSummaryPageLocators
        {
            //Vehicle Selection Button
            public static ILocator GetVehicleSelectButton(IPage page, string value, StringComparison comparison) =>
                page.Locator("[id*='vehicle']")
                    .GetByRole(AriaRole.Button, new() { Name = value });

            // Vehicle Type Options
            public static ILocator GetVehicleTypeButton(IPage page, string value) =>
                page.
                GetByRole(AriaRole.Button, new() { Name = value });
               


            // More Options Dropdown Values
            public static ILocator GetMoreOptionsValues(IPage page, string value) =>
                page
                .GetByRole(AriaRole.Button, new() { Name = value });


            //Is this vehicle owned or financed?
            public static ILocator GetVehicleOwnershipButton(IPage page, string value) =>
                page
                .GetByRole(AriaRole.Button, new() { Name = value });


            // Does this vehicle have any customized equipment?
            public static ILocator GetCustomizedEquipmentButton(IPage page, string yesOrNo) =>
                page
                .GetByRole(AriaRole.Button, new() { Name = yesOrNo });
                


            // How is this vehicle used?
            public static ILocator GetVehicleUsageButton(IPage page, string usageType) =>
                page
                .GetByRole(AriaRole.Button, new() { Name = usageType });


        }

        internal class VehicleDriverAssignmentPageLocators
        {
            public static ILocator DriverStatusButton(IPage page, string value) =>
                page.Locator("[id*='assignmentType']")
                    .GetByRole (AriaRole.Button, new() {Name = value});
        }

        internal class DiscountsPageLocators
        {
            public static ILocator GetPolicyDiscountCheckbox(IPage page, string value) =>
                page.GetByRole(AriaRole.Button, new() { Name = value });

            public static string GetBenefitXpressDiscountButton(string value) =>
                $"xpath=.//div[contains(@id, 'IsMemberOfBenefitesExpressGroup')]//button[contains(text(), '{value}')]";

            public static ILocator GetAccountCompositionCheckbox(IPage page, string yesOrNo) =>
                page.Locator("div[id*='AccountCompositionOverride']")
                    .GetByRole(AriaRole.Button, new() { Name = yesOrNo })
;
            public static ILocator GetUpdateButton(IPage page, string yesOrNo) =>
                page.Locator("div[id*='DriverInput.IsMemberOfBenefitsExpressGroup']")
                    .GetByRole(AriaRole.Button, new() { Name = yesOrNo })
;
        }

        internal class CoverageSelectionPageLocators
        {
            public static ILocator GetPolicyCoverageSelectionButton(IPage page, string value) =>
                page.GetByRole(AriaRole.Button, new() { Name = value });

            public static ILocator GetCompCollOnlyButton(IPage page, string yesOrNo) =>
                page.GetByRole(AriaRole.Button, new() { Name = yesOrNo })
                    .Filter(new() { Has = page.Locator("[id*='COMPCOLLBothOnly']") });


            public static ILocator GetCompDeductibleButton(IPage page, string value) =>
                page.Locator("[id*='comp_Option']")
                    .GetByRole(AriaRole.Button, new() { Name = value });

            public static ILocator GetCollDeductibleButton(IPage page, string value) =>
                page.Locator("[id*='coll_Option']")
                    .GetByRole(AriaRole.Button, new() { Name = value });
        }

        internal class AdditionalCoveragesPageLocators
        {
            public static ILocator GetAccidentalDeathAndDismembermentButton(IPage page, string value) =>
                page.Locator("[id*='AccidentalDeath']")
                    .GetByRole(AriaRole.Button, new() { Name = value});

            public static ILocator GetLossOfIncomeCheckbox(IPage page, string value) =>
                page.Locator("[id*='driverIncomeLoss']")
                    .GetByRole(AriaRole.Button, new() { Name = value});

            public static ILocator GetRentalReimbursementButton(IPage page, string value) =>
                page.Locator("[id*='RentalReimbursement']")
                    .GetByRole(AriaRole.Button, new() { Name = value});

            public static string GetRoadsideAssistanceButton(string value) =>
                $"xpath=.//button[contains(@id, 'RoadsideAssistance')]//div[contains(., '{value}')]";

            public static ILocator GetADDDriverCheckbox(IPage page, string value) =>
                page.Locator("[id*='aDDOperator']")
                    .GetByRole(AriaRole.Button, new());


        }

        internal class PricingDetailsPageLocators
        {
            public static string AdditionalRatingDetailsButton(string yesOrNo) =>
           $"xpath=.//button[contains(@data-testid, 'AdditionalRatinginformation')]//div[contains(text(), '{yesOrNo}')]";
        }

        internal class UnderwritingQuestionsPageLocators
        {
            public static ILocator ConvictedOfFelonyQuestion(IPage page, string yesOrNo) =>
                page.Locator("[id*='felonyConviction']")
                    .GetByRole(AriaRole.Button, new() { Name = yesOrNo});
        }
        internal class AdditionalInterestPageLocators
        {
            public static string OtherRegistrationQuestion(string yesOrNo) =>
                $"xpath=.//div[contains(@id, 'AnyVehicleRegisteredToSomeone')]//div[contains(text(), '{yesOrNo}')]";

            public static ILocator SelectVehicleRegisteredToOther(IPage page, string vehicleMake) =>
                page.GetByRole(AriaRole.Button, new() { Name = vehicleMake, Exact = true });
            public static ILocator GetAdditionalInterestType(IPage page, string value) =>
                page.GetByRole(AriaRole.Button, new() { Name = value });

            public static ILocator GetJointOwnerDrivesLocator(IPage page, string yesOrNo) =>
                page.GetByRole(AriaRole.Button, new() { Name = yesOrNo});
        }

        internal class BillingInformationsPageLocators
        {
            public static ILocator GetPrimaryPayerButton(IPage page, string value) =>
                page.GetByRole(AriaRole.Button, new() { Name = value });

            public static ILocator GetPaymentTypeButton(IPage page, string value) =>
                page.GetByRole(AriaRole.Button, new() { Name = value});

            public static ILocator GetPaymentPlanButton(IPage page, string value) =>
                page.GetByRole(AriaRole.Button, new() { Name = value});

            public static ILocator GetPaymentAmountRadioButton(IPage page, string value) =>
                page.GetByRole(AriaRole.Radio, new() { Name = value});

            public static ILocator GetPaymentMethodButton(IPage page, string value) =>
                page.GetByRole(AriaRole.Button, new() { Name = value});

            public static ILocator GetPaperlessCommunicationButton(IPage page, string yesOrNo) =>
                page.GetByRole(AriaRole.Button, new() { Name = yesOrNo});
        }


    }

    
}