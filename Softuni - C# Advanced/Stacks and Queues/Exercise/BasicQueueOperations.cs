using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            int[] info = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int toEnqueue = info[0];
            int toDequeue = info[1];
            int toFind = info[2];
            Queue<int> output = new Queue<int>();
            for (int i = 0; i < toEnqueue; i++)
            {
                output.Enqueue(nums[i]);
            }
            for (int i = 0; i < toDequeue; i++)
            {
                output.Dequeue();
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
