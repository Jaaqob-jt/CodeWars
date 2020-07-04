using System;
using System.Collections.Generic;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Testowanko");

            while (long.TryParse(Console.ReadLine(), out long temp)){

            Console.WriteLine("Resulted in: " + Kata.DigitalRoot(temp));
            } 
                
        }
    }
}
