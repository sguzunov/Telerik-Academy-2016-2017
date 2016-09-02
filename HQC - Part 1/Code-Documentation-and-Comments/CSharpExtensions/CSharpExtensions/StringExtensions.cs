namespace CSharpExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides methods for commonly used algorithms in <see cref="string"/> type.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Computes a md5 hash value for a string.
        /// </summary>
        /// <param name="input">String to be computed hash value for.</param>
        /// <returns>Computed hash value.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            var bytesArray = Encoding.UTF8.GetBytes(input);
            var hashData = md5Hash.ComputeHash(bytesArray);

            var builder = new StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                builder.Append(hashData[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Converts a string to a boolean value.
        /// </summary>
        /// <param name="input">String to be converted to true or false.</param>
        /// <returns>The converted boolean value.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts a string to a 16-bits signed number.
        /// </summary>
        /// <param name="input">String containing a number.</param>
        /// <returns>The converted string as number.</returns>
        /// <remarks>If the parameter cannot be parsed a default value is returned for the corresponding type.</remarks>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts a string to a 32-bits signed number.
        /// </summary>
        /// <param name="input">String containing a number.</param>
        /// <returns>The converted string as number.</returns>
        /// <remarks>If the parameter cannot be parsed a default value is returned for the corresponding type.</remarks>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts a string to a 64-bits signed number.
        /// </summary>
        /// <param name="input">String containing a number.</param>
        /// <returns>The converted string as number.</returns>
        /// <remarks>If the parameter cannot be parsed a default value is returned for the corresponding type.</remarks>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts a string with date and time to object of type <see cref="DateTime"/>.
        /// </summary>
        /// <param name="input">String containing date and time.</param>
        /// <returns>A <see cref="DateTime"/> object that contains date and time represented in 'input'.</returns>
        /// <remarks>If the parameter cannot be converted a default value is returned for the corresponding type.</remarks>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Converts only the first letter of a string to upper case.
        /// </summary>
        /// <param name="input">A string containing at least one letter.</param>
        /// <returns>Equivalent to the current string but having first letter in upper case.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Get a substring that starts from a specific string and ends to a specific string.
        /// </summary>
        /// <param name="input">A string to be extracted value from.</param>
        /// <param name="startString">A substring from where the result starts.</param>
        /// <param name="endString">A substring to where the result ends.</param>
        /// <param name="startFrom">A zero-based position from where the result starts.</param>
        /// <returns>The extracted substring.</returns>
        /// <remarks>If invalid parameter is passed an empty string is returned.</remarks>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Transforms a string containing cyrillic letters to their latin representation.
        /// </summary>
        /// <param name="input">A string containing cyrillic letters.</param>
        /// <returns>Transformed string that does not contain any cyrillic letters.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Transforms a string containing latin letters to their cyrillic representation.
        /// </summary>
        /// <param name="input">A string containing latin letters.</param>
        /// <returns>Transformed string that does not contain any latin letters.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Validate that a string contains only allowed characters for a username.
        /// </summary>
        /// <param name="input">String to be validated.</param>
        /// <returns>Valid username.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Validate that a string contains only valid characters for a file name.
        /// </summary>
        /// <param name="input">String to be validated.</param>
        /// <returns>Valid file name.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Retrieves first 'n' characters from a string. 
        /// </summary>
        /// <param name="input">The source string.</param>
        /// <param name="charsCount">The number of characters to be returned.</param>
        /// <returns>Extracted characters sequence.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Extract the extension of a file if the current string is a valid file name.
        /// </summary>
        /// <param name="fileName">A string containing a valid file name.</param>
        /// <returns>Extracted file extension.</returns>
        /// <remarks>If invalid file name is provided an empty string is returned.</remarks>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Provides a file content type depending on a file extension.
        /// </summary>
        /// <param name="fileExtension">String representing a file extension.</param>
        /// <returns>Content type corresponding to the file extension.</returns>
        /// <remarks>If unknown file extension is provided, 'application/octet-stream' is returned as a default value.</remarks>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a string to a sequence of bytes.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>A bytes array containing the encoded characters.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}