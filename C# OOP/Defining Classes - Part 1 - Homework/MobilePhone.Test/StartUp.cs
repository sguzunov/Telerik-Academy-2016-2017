namespace MobilePhone.Test
{
    using System;
    using System.Linq;

    using MobilePhone.Models;
    using MobilePhone.Models.Common;

    public class StartUp
    {
        private static void Main()
        {
            // GSM test
            Console.WriteLine(new string('-', 20) + "Tests for GMS class" + new string('-', 20));
            Console.WriteLine();

            GSM[] gsms = new GSM[]
            {
                new GSM("Lenovo", "Lenovo Corp.", 220M, "Dimitre", new Battery("LLH", 300, 15, BatteryType.NiMH), new Display(4.5, 16000000)),
                new GSM("Sony", "Sony Corp.", 720M, "John", new Battery("LLL", 400, 25, BatteryType.LiIon), new Display(5.2, 16000000)),
                new GSM("Samsung", "Samsung Corp.", 650M, "Jane", new Battery("LLL", 350, 18, BatteryType.LiIon), new Display(5.0, 16000000)),
                new GSM("ZTE", "ZTE Corp.", 220M, "Dimitre"),
                new GSM("Lenovo", "Lenovo Corp.")
            };
            foreach (var item in gsms)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine(GSM.IPhone4S);

            // Calls test
            Console.WriteLine(new string('-', 20) + "Tests for Call class" + new string('-', 20));
            Console.WriteLine();

            var gsm = new GSM("Lenovo", "Lenovo Corp.");
            gsm.AddCall(new Call("359888999666", 190));
            gsm.AddCall(new Call("359888999555", 90));
            gsm.AddCall(new Call(new DateTime(2016, 05, 05, 10, 00, 01), "359888999544", 350));
            gsm.AddCall(new Call(new DateTime(2015, 01, 01, 14, 02, 01), "359888999533", 300));
            gsm.AddCall(new Call(new DateTime(2015, 11, 10, 12, 30, 33), "359888999522", 370));

            foreach (var call in gsm.CallHistory)
            {
                Console.WriteLine(call);
            }

            decimal callsTotalPriceBefore = GSM.CalculateCallsPrice(Constants.CallPricePerMinute, gsm.CallHistory);
            Console.WriteLine("Calls total price before removing longest call: {0}", callsTotalPriceBefore);

            ushort longestCallDuration = gsm.CallHistory.Max(x => x.Duration);
            Call longestCall = gsm.CallHistory.First(c => c.Duration == longestCallDuration);
            gsm.CallHistory.Remove(longestCall);
            decimal callsTotalPriceAfter = GSM.CalculateCallsPrice(Constants.CallPricePerMinute, gsm.CallHistory);
            Console.WriteLine("Calls total price after removing longest call: {0}", callsTotalPriceAfter);
        }
    }
}