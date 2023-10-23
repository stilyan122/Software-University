using System;
using System.Collections.Generic;

namespace _05.ReverseNumbersWithAStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            Stack<string> stack = new Stack<string>();
            foreach (var num in input)
            {
                stack.Push(num);
            }
            int count = input.Length;
            for (int i = 0; i < count; i++)
            {
                Console.Write(stack.Pop() + ' ');
            }
            Console.WriteLine();
        }
    }
}
