using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter as number to check if its even or odd");
            var a = Console.Read();
            var result = a.IsEven();
            if (result)
                Console.WriteLine("Even number.");
            else
                Console.WriteLine("Not an even number.");
            Console.ReadLine();
        }
    }
}
