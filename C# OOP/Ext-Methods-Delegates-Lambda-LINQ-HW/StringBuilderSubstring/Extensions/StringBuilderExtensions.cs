namespace StringBuilderSubstring.Extensions
{
    using System;
    using System.Text;

    internal static class StringBuilderExtensions
    {
        internal static StringBuilder Substring(this StringBuilder builder, int index, int lenght)
        {
            if (index < 0 || index >= builder.Length)
            {
                throw new IndexOutOfRangeException($"Start index must be in range [0, {builder.Length - 1}]!");
            }

            if (index + lenght > builder.Length)
            {
                throw new ArgumentException("Desired substring length is too long!");
            }

            StringBuilder substringBuilder = new StringBuilder();
            for (int i = index; i < index + lenght; i++)
            {
                substringBuilder.Append(builder[i]);
            }

            return substringBuilder;
        }
    }
}
