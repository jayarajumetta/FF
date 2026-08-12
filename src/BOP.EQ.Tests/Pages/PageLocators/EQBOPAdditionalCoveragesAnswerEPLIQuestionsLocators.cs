using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPAdditionalCoveragesAnswerEPLIQuestionsLocators
{
        public static ILocator HaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwner(IPage page) =>
        page.Locator("id=fields.line.endLineEmploymentRelatedPracticesLiability.endLineEmploymentRelatedPracticesLiabilityInput$ePLPriorClaim.value");

        public static ILocator DoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint(IPage page) =>
        page.Locator("id=fields.line.endLineEmploymentRelatedPracticesLiability.endLineEmploymentRelatedPracticesLiabilityInput$ePLPriorKnowledge.value");

}
