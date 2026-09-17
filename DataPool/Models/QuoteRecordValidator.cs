using DataPool.Services;

namespace DataPool.Models
{
    public static class QuoteRecordValidator
    {
        public const int MaximumIdentifierLength = 128;
        public const int MaximumNotesLength = 1000;

        public static void ValidateForAdd(QuoteRecord record)
        {
            if (record == null)
                throw new DataPoolValidationException("A quote record is required.");

            ValidateIdentifier(record.Id, "Quote ID");
            ValidateTransaction(record.Transaction);

            if (!string.Equals(record.Status, "available", StringComparison.OrdinalIgnoreCase))
            {
                throw new DataPoolValidationException(
                    "New quote records must have status 'available'.");
            }

            if (record.ClaimedAt != null ||
                !string.IsNullOrWhiteSpace(record.ClaimedBy) ||
                !string.IsNullOrWhiteSpace(record.ConsumedBy))
            {
                throw new DataPoolValidationException(
                    "New quote records cannot contain claim or consumption state.");
            }

            ValidateFields(record);
        }

        public static void ValidateStored(QuoteRecord record)
        {
            if (record == null)
                throw new DataPoolStorageException("DataPool contains a null quote record.");

            try
            {
                ValidateIdentifier(record.Id, "Quote ID");
                ValidateTransaction(record.Transaction);
                ValidateFields(record);
                if (!string.IsNullOrWhiteSpace(record.ClaimedBy))
                    ValidateActor(record.ClaimedBy, "Stored claim");
                if (!string.IsNullOrWhiteSpace(record.ConsumedBy))
                    ValidateActor(record.ConsumedBy, "Stored consumption");
            }
            catch (DataPoolValidationException exception)
            {
                throw new DataPoolStorageException(
                    "DataPool contains a quote with an invalid identifier.",
                    exception);
            }

            if (record.Status is not ("available" or "claimed" or "consumed"))
            {
                throw new DataPoolStorageException(
                    "DataPool contains a quote with an invalid status.");
            }

            if (record.Status == "available" &&
                (record.ClaimedAt != null ||
                 !string.IsNullOrWhiteSpace(record.ClaimedBy) ||
                 !string.IsNullOrWhiteSpace(record.ConsumedBy)))
            {
                throw new DataPoolStorageException(
                    "DataPool contains an invalid available quote transition state.");
            }

            if (record.Status == "claimed" &&
                (record.ClaimedAt == null || string.IsNullOrWhiteSpace(record.ClaimedBy)))
            {
                throw new DataPoolStorageException(
                    "DataPool contains an invalid claimed quote transition state.");
            }

            if (record.Status == "consumed" &&
                (record.ClaimedAt == null ||
                 string.IsNullOrWhiteSpace(record.ClaimedBy) ||
                 string.IsNullOrWhiteSpace(record.ConsumedBy)))
            {
                throw new DataPoolStorageException(
                    "DataPool contains an invalid consumed quote transition state.");
            }

            if (record.CreatedAt == default)
            {
                throw new DataPoolStorageException(
                    "DataPool contains a quote without a creation timestamp.");
            }
        }

        public static void ValidateActor(string actor, string operation)
        {
            if (string.IsNullOrWhiteSpace(actor) ||
                actor.Length > MaximumIdentifierLength ||
                actor.Any(char.IsControl))
            {
                throw new DataPoolValidationException(
                    $"{operation} requires a valid actor identifier.");
            }
        }

        public static void ValidateFilters(
            string? status,
            string? transaction,
            string? lob,
            string? sfpVariant)
        {
            if (status != null &&
                !status.Equals("available", StringComparison.OrdinalIgnoreCase) &&
                !status.Equals("claimed", StringComparison.OrdinalIgnoreCase) &&
                !status.Equals("consumed", StringComparison.OrdinalIgnoreCase))
            {
                throw new DataPoolValidationException(
                    "Status filter must be available, claimed, or consumed.");
            }

            if (transaction != null &&
                !transaction.Equals("Quote", StringComparison.OrdinalIgnoreCase) &&
                !transaction.Equals("Policy", StringComparison.OrdinalIgnoreCase))
            {
                throw new DataPoolValidationException(
                    "Transaction filter must be Quote or Policy.");
            }

            ValidateOptionalLength(lob, 64, "LOB filter");
            ValidateOptionalLength(sfpVariant, 64, "SFP variant filter");
        }

        public static void ValidateIdentifier(string value, string field)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > MaximumIdentifierLength ||
                value.Any(char.IsControl))
            {
                throw new DataPoolValidationException(
                    $"{field} must contain between 1 and {MaximumIdentifierLength} characters.");
            }
        }

        private static void ValidateFields(QuoteRecord record)
        {
            ValidateOptionalLength(record.Lob, 32, "LOB");
            ValidateOptionalLength(record.SfpVariant, 64, "SFP variant");
            ValidateOptionalLength(record.Environment, 32, "Environment");
            ValidateOptionalLength(record.Notes, MaximumNotesLength, "Notes");
            ValidateOptionalLength(record.EffectiveDate, 32, "Effective date");

            if (!string.IsNullOrWhiteSpace(record.State) &&
                (record.State.Length != 2 || !record.State.All(char.IsLetter)))
            {
                throw new DataPoolValidationException(
                    "State must be a two-letter abbreviation.");
            }
        }

        private static void ValidateTransaction(string transaction)
        {
            if (transaction is not ("Quote" or "Policy"))
            {
                throw new DataPoolValidationException(
                    "Transaction must be 'Quote' or 'Policy'.");
            }
        }

        private static void ValidateOptionalLength(
            string? value,
            int maximumLength,
            string field)
        {
            if (value?.Length > maximumLength)
            {
                throw new DataPoolValidationException(
                    $"{field} must not exceed {maximumLength} characters.");
            }
        }
    }
}
