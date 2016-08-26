namespace Bunnies.Extensions
{
    using System.Text;

    public static class StringExtensions
    {
        public static string SplitToSeparateWordsByUppercaseLetter(this string sequence)
        {
            var probableStringMargin = 10;
            int probableStringSize = sequence.Length + probableStringMargin;
            StringBuilder builder = new StringBuilder(probableStringSize);

            var singleWhitespace = ' ';
            foreach (var letter in sequence)
            {
                if (char.IsUpper(letter))
                {
                    builder.Append(singleWhitespace);
                }

                builder.Append(letter);
            }

            return builder.ToString().Trim();
        }
    }
}
