using System;
using System.Collections.Generic;

namespace ReverseAString
{
    class ReverseAString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> output = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                output.Push(input[i]);
            }
            foreach (var item in output)
            {
                Console.Write(item);
            }
        }
    }
}
