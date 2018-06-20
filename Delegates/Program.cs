using System;
using System.Collections.Generic;

namespace Delegates
{
    public delegate void Notify(string message);
    class Program
    {
        static void Main(string[] args)
        {
            Example1.Start(DisplayOnComplete);
            Example2.Start(DisplayOnComplete);
            Console.ReadKey();
        }

        static void DisplayOnComplete(string message)
        {
            Console.WriteLine(message);
        }
    }
    
}
