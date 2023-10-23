using System;
using System.Linq;
using System.Collections.Generic;

namespace BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            int[] info = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int toPush = info[0];
            int toPop = info[1];
            int toFind = info[2];
            Stack<int> output = new Stack<int>();
            for (int i = 0; i < toPush; i++)
            {
                output.Push(nums[i]);
            }
            for (int i = 0; i < toPop; i++)
            {
                output.Pop();
            }
            if (output.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                bool isFound = false;
                foreach (var item in output)
                {
                    if (item == toFind)
                    {
                        Console.WriteLine("true");
                        isFound = true;
                        break;
                    }
                }
                if (isFound == false)
                {
                    Console.WriteLine(output.Min());
                }
            }
        }
    }
}
