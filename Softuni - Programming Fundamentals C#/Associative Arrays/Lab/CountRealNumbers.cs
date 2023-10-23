using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Dictionary<double, int> output = new Dictionary<double, int>();
            foreach (var item in input)
            {
                if (!output.ContainsKey(item))
                {
                    output.Add(item, 1);
                }
                else
                {
                    output[item]++;
                }
            }
            List<KeyValuePair<double, int>> list = output.OrderBy(x => x.Key).ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item.Key+" -> "+item.Value);
            }
        }
    }
}
