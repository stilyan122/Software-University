using System;
using System.Collections.Generic;
using System.Linq;

namespace RoundingNumbers
{
    public class RoundingNumbers
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                int roundedNumber = (int)Math.Round(arr[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{Convert.ToDecimal(arr[i])} => {Convert.ToDecimal(roundedNumber)}");
            }
        }
    }
}
