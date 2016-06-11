namespace MobilePhone.Models.Common
{
    using System;

    public class DataValidator
    {
        public static void CheckIfNegativeOrZeroValue(double value, string target, string errorMessage = Constants.NegativeValueErrorMessage)
        {
            if (value <= 0.0)
            {
                throw new ArgumentException(string.Format(errorMessage, target));
            }
        }

        public static void CheckIfNegativeOrZeroValue(decimal value, string target, string errorMessage = Constants.NegativeValueErrorMessage)
        {
            if (value <= 0.0M)
            {
                throw new ArgumentException(string.Format(errorMessage, target));
            }
        }

        public static void CheckIfNegativeOrZeroValue(long value, string target, string errorMessage = Constants.NegativeValueErrorMessage)
        {
            if (value <= 0L)
            {
                throw new ArgumentException(string.Format(errorMessage, target));
            }
        }

        public static void CheckIfNullOrEmptyValue(string value, string target, string errorMessage = Constants.NullValueErrorMessage)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(string.Format(errorMessage, target));
            }
        }
    }
}
