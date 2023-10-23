using System;
using System.Linq;
using System.Collections.Generic;

namespace Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Lake lake = new Lake(input);
            lake.Print();
        }
    }
}
