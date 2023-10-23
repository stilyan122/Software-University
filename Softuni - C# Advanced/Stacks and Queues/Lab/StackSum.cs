using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class StackSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> output = new Stack<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                output.Push(arr[i]);
            }
            string[] command = Console.ReadLine().Split();
            while (command[0].ToLower() != "end")
            {
                if (command[0].ToLower() == "end")
                {
                    break;
                }
                else if (command[0].ToLower() == "add")
                {
                    output.Push(int.Parse(command[1]));
                    output.Push(int.Parse(command[2]));
                }
                else if (command[0].ToLower() == "remove")
                {
                    int index = int.Parse(command[1]);
                    if (output.Count >= index)
                    {
                        for (int i = 0; i < index; i++)
                        {
                            output.Pop();
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            int sum = 0;
            foreach (var item in output)
            {
                sum += item;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
