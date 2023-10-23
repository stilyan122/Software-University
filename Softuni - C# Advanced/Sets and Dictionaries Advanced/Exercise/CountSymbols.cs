using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> order = new SortedDictionary<char, int>();
            foreach (var item in text)
            {
                if (!order.ContainsKey(item))
                {
                    order.Add(item, 1);
                }
                else
                {
                    order[item]++;
                }
            }
            foreach (var item in order)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
