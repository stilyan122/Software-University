using System;
using System.Linq;
using System.Collections.Generic;

namespace SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int first = nums[0];
            int second = nums[1];
            HashSet<int> list1 = new HashSet<int>();
            HashSet<int> list2 = new HashSet<int>();
            List<int> result = new List<int>();
            for (int i = 0; i < first + second; i++)
            {
                int n = int.Parse(Console.ReadLine());
                if (i < first)
                {
                    list1.Add(n);
                }
                else
                {
                    list2.Add(n);
                }
            }
            foreach (var item1 in list1)
            {
                foreach (var item2 in list2)
                {
                    if (item1 == item2)
                    {
                        result.Add(item1);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
