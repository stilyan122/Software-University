using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    class CarRace
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int finish = nums.Count / 2;
            double sum1 = 0;
            double sum2 = 0;
            for (int i = 0; i < finish; i++)
            {
                if (nums[i]==0)
                {
                    sum1 -= 0.20 * sum1;
                }
                else
                {
                    sum1 += nums[i];
                }
            }
            for (int i = nums.Count - 1; i > finish; i--)
            {
                if (nums[i] == 0)
                {
                    sum2 -= 0.20 * sum2;
                }
                else
                {
                    sum2 += nums[i];
                }
            }
            if (sum2 <= sum1)
            {
                Console.WriteLine($"The winner is right with total time: {sum2}");
            }
            else
            {
                Console.WriteLine($"The winner is left with total time: {sum1}");
            }
        }
    }
}
