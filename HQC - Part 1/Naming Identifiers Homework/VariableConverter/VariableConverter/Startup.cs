namespace VariableConverter
{
    public class Startup
    {
        public static void Main()
        {
            var trueAsString = VariableConverter.ConvertBooleanToString(true);
            var falseAsString = VariableConverter.ConvertBooleanToString(false);

            System.Console.WriteLine(trueAsString);
            System.Console.WriteLine(falseAsString);
        }
    }
}
