using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSameValuesInArray
{
    class CountSameValuesInArray
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> times = new Dictionary<double, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!times.ContainsKey(nums[i]))
                {
                    times.Add(nums[i], 1);
                }
                else
                {
                    times[nums[i]]++;
                }
            }
            foreach (var item in times)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
