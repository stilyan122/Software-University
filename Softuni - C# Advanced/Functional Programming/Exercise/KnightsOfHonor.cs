using System;

namespace KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string> print = name => Console.WriteLine("Sir "+name);
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in input)
            {
                print(name);
            }
        }
    }
}
