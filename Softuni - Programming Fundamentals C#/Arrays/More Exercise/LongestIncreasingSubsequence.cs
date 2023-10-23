using System;
using System.Linq;
using System.Collections.Generic;

namespace LongestIncreasingSubsequence
{
    class LongestIncreasingSubsequence
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] lis;
            int[] len = new int[input.Length];
            int[] prev = new int[input.Length];
            int maxLength = 0;
            int lastIndex = -1;
            for (int i = 0; i < input.Length; i++)
            {
                len[i] = 1;
                prev[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (input[j] < input[i] && len[j] >= len[i])
                    {
                        len[i] = 1 + len[j];
                        prev[i] = j;
                    }
                }
                if (len[i] > maxLength)
                {
                    maxLength = len[i];
                    lastIndex = i;
                }
            }
            lis = new int[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                lis[i] = input[lastIndex];
                lastIndex = prev[lastIndex];
            }
            Array.Reverse(lis);
            Console.WriteLine(string.Join(" ", lis));
        }
    }
}
