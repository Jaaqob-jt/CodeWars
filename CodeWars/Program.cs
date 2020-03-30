using System;
using System.Collections.Generic;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            User steve = new User("Steve");
            Console.WriteLine(steve.ToString());
            User.incProgres(steve, 123);

            Console.WriteLine(steve.ToString());

        }
    }
}
