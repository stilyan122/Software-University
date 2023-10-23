using System;
using System.Linq;

namespace AddVAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .ToArray();
            Func<double, decimal> VAT = n => (decimal)(n + (0.20 * n));
            foreach (var item in arr)
            {
                Console.WriteLine($"{VAT(item):F2}");
            }
        }
    }
}
