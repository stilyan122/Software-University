using System;
using System.Linq;

namespace SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                 .Split(", ")
                 .Select(int.Parse)
                 .ToArray();
            Console.WriteLine(arr.Length);
            Console.WriteLine(arr.Sum());
        }
    }
}
