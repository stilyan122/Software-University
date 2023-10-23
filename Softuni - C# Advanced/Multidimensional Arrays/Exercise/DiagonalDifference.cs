using System;
using System.Linq;

namespace DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int sum1 = 0;
            int sum2 = 0;
            for (int row = 0; row < n; row++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }
            for (int i = 0; i < n; i++)
            {
                sum1 += matrix[i, i];
            }
            int column = n - 1;
            for (int row = 0; row < n; row++)
            {
                sum2 += matrix[row, column];
                column--;
            }
            int sum = Math.Abs(sum1 - sum2);
            Console.WriteLine(sum);
        }
    }
}
