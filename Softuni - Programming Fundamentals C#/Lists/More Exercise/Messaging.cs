using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Messaging
{
    class Messaging
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string str = Console.ReadLine();
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < nums.Count; i++)
            {
                string curr = nums[i].ToString();
                int sum = 0;
                for (int j = 0; j < curr.Length; j++)
                {
                    int currNum = (int)(curr[j])-48;
                    sum += currNum;
                }
                if (sum>=str.Length)
                {
                    while (sum>=str.Length)
                    {
                        sum -= str.Length;
                    }
                }
                string currentChar = str[sum].ToString();
                str = str.Remove(sum, 1);
                output.Append(currentChar);
            }
            Console.WriteLine(output);
        }
    }
}
