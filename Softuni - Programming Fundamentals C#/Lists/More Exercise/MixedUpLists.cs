using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpLists
{
    class MixedUpLists
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> numbers = new List<int>();
            int range1 = 0;
            int range2 = 0;
            if (nums1.Count>nums2.Count)
            {
                range1 = nums1[nums1.Count - 2];
                range2 = nums1[nums1.Count - 1];
                nums1.RemoveAt(nums1.Count - 2);
                nums1.RemoveAt(nums1.Count - 1);
            }
            else
            {
                range1 = nums2[0];
                range2 = nums2[1];
                nums2.RemoveAt(0);
                nums2.RemoveAt(1);
            }
            int counter1 = 0;
            int counter2 = nums2.Count-1;
            while (nums1.Count>0&&nums2.Count>0)
            {
                int num1 = nums1[counter1];
                nums1.RemoveAt(counter1);
                numbers.Add(num1);
                int num2 = nums2[counter2];
                nums2.RemoveAt(counter2);
                numbers.Add(num2);
                counter2--;
            }
            int start = 0;
            int end = 0;
            if (range1>=range2)
            {
                start = range2;
                end = range1;
            }
            else
            {
                start = range1;
                end = range2;
            }
            List<int> output = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                int current = numbers[i];
                if (current>start&&current<end)
                {
                    output.Add(current);
                }
            }
            output = output.OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(" ",output));
        }
    }
}
