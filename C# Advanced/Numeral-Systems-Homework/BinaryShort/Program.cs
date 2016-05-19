using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryShort
{
    class Program
    {
        static void Main(string[] args)
        {
            short a = short.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(a, 2).PadLeft(16, '0'));
        }
    }
}
