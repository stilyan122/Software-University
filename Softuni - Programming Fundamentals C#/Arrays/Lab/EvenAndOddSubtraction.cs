using System;
using System.Linq;

namespace EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] even = input.Where(x => x % 2 == 0).ToArray();
            int[] odd = input.Where(x => x % 2 == 1).ToArray();
            Console.WriteLine(even.Sum() - odd.Sum());
        }
    }
}
