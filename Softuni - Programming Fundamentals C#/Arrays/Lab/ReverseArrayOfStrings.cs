using System;
using System.Linq;

namespace ReverseArrayOfStrings
{
    class ReverseArrayOfStrings
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Reverse().ToArray();
            Console.WriteLine(string.Join(" ",input));
        }
    }
}
