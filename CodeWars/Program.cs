using System;
using System.Collections.Generic;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Kata.Snail(new[]{
                            new[] { 1, 2, 3 },
                            new[] { 4, 5, 6 },
                            new[] { 7, 8, 9 }
                            });
            Console.WriteLine("\n---------------- Kolejny Test ---------------");
            Kata.Snail(new[]{
                            new[] { 1, 2, 3, 4},
                            new[] { 5, 6, 7, 8 },
                            new[] { 9, 10, 11, 12},
                            new[] { 13, 14, 15, 16}
                            });

        }
    }
}
