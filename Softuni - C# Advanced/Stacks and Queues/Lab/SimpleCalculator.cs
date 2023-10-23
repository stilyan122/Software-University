using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string[] exercise = Console.ReadLine().Split(" ");
            Stack<string> arr = new Stack<string>();
            for (int i = exercise.Length - 1; i >= 0; i--)
            {
                arr.Push(exercise[i]);
            }
            while (arr.Count > 1)
            {
                int first = int.Parse(arr.Pop());
                char symbol = char.Parse(arr.Pop());
                int second = int.Parse(arr.Pop());
                if (symbol == '+')
                {
                    arr.Push((first + second).ToString());
                }
                else if (symbol == '-')
                {
                    arr.Push((first - second).ToString());
                }
            }
            Console.WriteLine(arr.Pop());
        }
    }
}
