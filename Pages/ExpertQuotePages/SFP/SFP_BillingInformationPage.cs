using Microsoft.Playwright;

namespace Playwright_POC.Pages
{
    public class SFP_BillingInformationPage : BasePage
    {
        public SFP_BillingInformationPage(IPage page) : base(page) { }

        // ===== Billing Account Setup =====
        // Select from existing Billing Accounts or Create New
        public ILocator CreateNewBillingAccountButton => _page.GetByTestId("fields._PolicyPaymentInputDoc._PolicyPaymentInputDoc$billingCenterAccount.value-0");

        // Select the Primary Payer for the new account
        public ILocator PrimaryPayerPrimaryInsuredButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-0");
        public ILocator PrimaryPayerOtherButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$payerID.value-1");

        // ===== Future Payment Plan Setup =====
        // Select Payment Type
        public ILocator PaymentTypeEasyPayButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentMethod.value-0");
        public ILocator PaymentTypeDirectBillButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentMethod.value-1");

        // Select from existing Bank Accounts or Create New
        public ILocator FutureBankAccountCreateNewButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentBankData$existingDraftAccount.value-0");

        // Select the Bank Account use
        public ILocator FutureBankAccountUsePersonalButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentBankData$accountUse.value-0");
        public ILocator FutureBankAccountUseBusinessButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentBankData$accountUse.value-1");

        // Select the Bank Account type
        public ILocator FutureBankAccountTypeCheckingButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentBankData$accountType.value-0");
        public ILocator FutureBankAccountTypeSavingsButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentBankData$accountType.value-1");

        // Select the Bank Account Owner
        public ILocator FutureBankAccountOwnerPrimaryButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentBankData$accountOwnerSelect.value-0");
        public ILocator FutureBankAccountOwnerOtherButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentBankData$accountOwnerSelect.value-1");

        // Bank Details
        public ILocator FutureBankRoutingNumberInput => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentBankData$routingNumber.value");
        public ILocator FutureBankAccountNumberInput => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentBankData$accountNumber.value");
        public ILocator FutureNameOfBankInput => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentBankData$name.value");

        // ===== Select Payment Plan =====
        public ILocator PaymentPlan1PaymentButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentPlan.value-0");
        public ILocator PaymentPlan2PaymentsButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentPlan.value-1");
        public ILocator PaymentPlan4PaymentsButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentPlan.value-2");
        public ILocator PaymentPlan12PaymentsButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentPlan.value-3");

        // Choose payment due date
        public ILocator PaymentDueDateSelect => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$paymentDueDate.value");

        // ===== Initial Payment =====
        // Select a payment amount
        public ILocator PaymentAmountMinimumButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$amountSelection.value-0");
        public ILocator PaymentAmountFullBalanceButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$amountSelection.value-1");
        public ILocator PaymentAmountCustomButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$amountSelection.value-2");

        // Select Payment Method
        public ILocator InitialPaymentMethodQuickPayButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$paymentMethod.value-0");
        public ILocator InitialPaymentMethodCheckButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$paymentMethod.value-1");
        public ILocator InitialPaymentMethodCreditCardButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$paymentMethod.value-2");

        // Select Create New to input Quick Pay details
        public ILocator InitialBankAccountCreateNewButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.bankData$existingDraftAccount.value-0");

        // Select the Bank Account use
        public ILocator InitialBankAccountUsePersonalButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.bankData$accountUse.value-0");
        public ILocator InitialBankAccountUseBusinessButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.bankData$accountUse.value-1");

        // Select the Bank Account type
        public ILocator InitialBankAccountTypeCheckingButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.bankData$accountType.value-0");
        public ILocator InitialBankAccountTypeSavingsButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.bankData$accountType.value-1");

        // Select the Account Owner
        public ILocator InitialBankAccountOwnerPrimaryButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.bankData$accountOwnerSelect.value-0");
        public ILocator InitialBankAccountOwnerOtherButton => _page.GetByTestId("fields._PolicyPaymentInputDoc.bankData$accountOwnerSelect.value-1");

        // Bank Details
        public ILocator InitialBankRoutingNumberInput => _page.GetByTestId("fields._PolicyPaymentInputDoc.bankData$routingNumber.value");
        public ILocator InitialBankAccountNumberInput => _page.GetByTestId("fields._PolicyPaymentInputDoc.bankData$accountNumber.value");
        public ILocator InitialNameOfBankInput => _page.GetByTestId("fields._PolicyPaymentInputDoc.bankData$name.value");
    }
}
