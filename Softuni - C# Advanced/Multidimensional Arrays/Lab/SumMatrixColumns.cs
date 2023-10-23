using System;
using System.Linq;

namespace SumMatrixColumns
{
    class SumMatrixColumns
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().
                Split(", ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];
            for (int row = 0; row < sizes[0]; row++)
            {
                int[] nums = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();
                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            for (int col = 0; col < sizes[1]; col++)
            {
                int sum = 0;
                for (int row = 0; row < sizes[0]; row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }

        }
    }
}
