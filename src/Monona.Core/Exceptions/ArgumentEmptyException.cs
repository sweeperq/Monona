namespace System
{
    public class ArgumentEmptyException : ArgumentException
    {
        private static readonly string ERROR_MESSAGE = "Value cannot be empty (null, empty, or white-space)";

        public ArgumentEmptyException() : base(ERROR_MESSAGE)
        {
        }

        public ArgumentEmptyException(string paramName) : this(ERROR_MESSAGE, paramName)
        {
        }

        public ArgumentEmptyException(string errorMessage, string paramName) : base(errorMessage, paramName)
        {
        }
    }
}
