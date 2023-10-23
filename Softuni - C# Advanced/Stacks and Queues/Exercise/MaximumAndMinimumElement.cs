using System;
using System.Linq;
using System.Collections.Generic;

namespace MaximumAndMinimumElement
{
    class MaximumAndMinimumElement
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> output = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                switch (nums[0])
                {
                    case 1:
                        output.Push(nums[1]);
                        break;
                    case 2:
                        output.Pop();
                        break;
                    case 3:
                        if (output.Count > 0)
                            Console.WriteLine(output.Max());
                        break;
                    case 4:
                        if (output.Count > 0)
                            Console.WriteLine(output.Min());
                        break;
                    default:
                        break;
                }
            }
            int counter = 0;
            foreach (var item in output)
            {
                counter++;
                if (counter < output.Count)
                    Console.Write(item + ", ");
                else
                    Console.Write(item);
            }
        }
    }
}
