namespace DataPool.Services
{
    public sealed class DataPoolValidationException : Exception
    {
        public DataPoolValidationException(string message)
            : base(message)
        {
        }
    }

    public sealed class DataPoolConflictException : Exception
    {
        public DataPoolConflictException(string message)
            : base(message)
        {
        }
    }

    public sealed class DataPoolStorageException : Exception
    {
        public DataPoolStorageException(string message, Exception? innerException = null)
            : base(message, innerException)
        {
        }
    }
}
