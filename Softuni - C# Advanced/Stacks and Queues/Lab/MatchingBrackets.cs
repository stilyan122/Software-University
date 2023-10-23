using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            string exercise = Console.ReadLine();
            Stack<int> arr = new Stack<int>();

            for (int i = 0; i < exercise.Length; i++)
            {
                if (exercise[i] == '(')
                {
                    arr.Push(i);
                }
                else if (exercise[i] == ')')
                {
                    int end = i;
                    int start = arr.Pop();
                    string sub = exercise.Substring(start, end - start + 1);
                    Console.WriteLine(sub);
                }
            }
        }
    }
}
