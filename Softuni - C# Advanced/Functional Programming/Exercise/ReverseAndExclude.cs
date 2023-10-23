using System;
using System.Linq;

namespace ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());
            Predicate<double> divisible = number => number % n != 0;
            input = input.Where(x => divisible(x)).Reverse().ToArray();
            Console.WriteLine(string.Join(" ",input));
        }
    }
}
