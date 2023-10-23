using System;
using System.Linq;

namespace SumEvenNumbers
{
    class SumEvenNumbers
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).Where(x => x % 2 == 0).ToArray();
            Console.WriteLine(input.Sum());
        }
    }
}
