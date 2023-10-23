using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int k = input.Length / 4;
            int[] array1 = new int[k];
            int[] array2 = new int[k];
            int[] array3 = new int[2 * k];
            int counter = 0;
            for (int i = k - 1; i >= 0; i--)
            {
                array1[counter] = input[i];
                counter++;
            }
            counter = 0;
            for (int i = input.Length - 1; i >= input.Length-k; i--)
            {
                array2[counter] = input[i];
                counter++;
            }
            counter = 0;
            string combinedArraysString = string.Join(' ', array1)+ " " + string.Join(' ', array2);
            for (int i = k; i < input.Length-k; i++)
            {
                array3[counter] = input[i];
                counter++;
            }
            StringBuilder output = new StringBuilder();
            int[] array4 = combinedArraysString.Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < array3.Length; i++)
            {
                int sum = array3[i] + array4[i];
                output.Append(sum + " ");
            }
            Console.WriteLine(output);
        }
    }
}
