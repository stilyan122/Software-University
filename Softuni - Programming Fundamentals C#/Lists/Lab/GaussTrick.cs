using System;
using System.Collections.Generic;
using System.Linq;

namespace GaussTrick
{
    class GaussTrick
    {
        static void Main(string[] args)
        {
            List<double> nums =
                  Console.ReadLine().
                  Split().Select(double.Parse)
                  .ToList();
            int start = 0;
            int end = nums.Count;
            for (int i = start; i < end-1; i++)
            {
                nums[i] = nums[i] + nums[end-1];
                nums.RemoveAt(end-1);
                end--;
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
