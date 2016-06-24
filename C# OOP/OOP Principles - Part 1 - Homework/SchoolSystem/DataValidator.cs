namespace SchoolSystem
{
    using System;

    internal static class DataValidator
    {
        private const string NullOrEmptyStringErrorMessage = "{0} cannot have null or empty value.";
        private const string NullObjectErrorMessage = "{0} cannot be null.";

        public static void ValidateIfStringIsNullOrEmpty(string value, string target, string errorMessage = NullOrEmptyStringErrorMessage)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(string.Format(errorMessage, target));
            }
        }

        public static void ValidateIfObject(object obj, string target, string errorMessage = NullObjectErrorMessage)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(string.Format(errorMessage, target));
            }
        }
    }
}
