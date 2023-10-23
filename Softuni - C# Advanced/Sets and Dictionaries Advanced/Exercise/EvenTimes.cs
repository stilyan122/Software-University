using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<double> arr = new HashSet<double>();
            Dictionary<double, int> counts = new Dictionary<double, int>();
            for (int i = 0; i < n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (arr.Contains(num))
                {
                    counts[num]++;
                }
                else
                {
                    arr.Add(num);
                    counts.Add(num, 1);
                }
            }
            foreach (var item in counts)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
