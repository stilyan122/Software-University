using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class MergingLists
    {
        static void Main(string[] args)
        {
            List<double> nums1 = Console.ReadLine().Split(" ").Select(double.Parse).ToList();
            List<double> nums2 = Console.ReadLine().Split(" ").Select(double.Parse).ToList();
            int smallerLength = 0;
            int longerList = 0;
            List<double> output = new List<double>();
            if (nums1.Count>=nums2.Count)
            {
                smallerLength = nums2.Count;
                longerList = nums1.Count;
            }
            else
            {
                smallerLength = nums1.Count;
                longerList = nums2.Count;
            }
            for (int i = 0; i < smallerLength; i++)
            {
                output.Add(nums1[i]);
                output.Add(nums2[i]);
            }
            if (longerList == nums1.Count)
            {
                for (int i = longerList - (longerList - smallerLength); i < longerList; i++)
                {
                    output.Add(nums1[i]);
                }
            }
            else
            {
                for (int i = longerList - (longerList-smallerLength); i < longerList; i++)
                {
                    output.Add(nums2[i]);
                }
            }
            Console.WriteLine(string.Join(" ",output));
        }
    }
}
