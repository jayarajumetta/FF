using Microsoft.Playwright;

namespace Playwright_POC.Pages
{
    public class SFP_InsuranceScorePage : BasePage
    {
        public SFP_InsuranceScorePage(IPage page) : base(page) { }

        // Form Fields
        public ILocator PriorAddressInput => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$priorAddress.value");
        public ILocator PriorCityInput => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$priorCity.value");
        public ILocator PriorZipCodeInput => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$priorZipCode.value");
        public ILocator EntityTypeSelect => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$entityType.value");
        public ILocator PriorStateSelect => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$priorState.value");

        // Buttons
        public ILocator TradeAssocButton => _page.GetByTestId("fields.data.accountInput$tradeAssoc.value");
        public ILocator PrimaryInsuredButton => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$headlessSelectionOption.value-0");
        public ILocator IndividualNotListedButton => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$headlessSelectionOption.value-1");
        public ILocator InsuranceScoreConsentButton => _page.GetByTestId("fields.data.insuranceScoreConsen_1");
        public ILocator PreviousButton => _page.GetByTestId("fields.data-Next.previous");
        public ILocator DeclineButton => _page.GetByTestId("fields.policy.decline_1");
        public ILocator AcceptButton => _page.GetByTestId("fields.policy.accept_1");

        // Other Elements
        public ILocator Feature => _page.GetByTestId("feature-flag-editor-button");
    }
}
