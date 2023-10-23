using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class SquareWithMaximumSum
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
                Split(", ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();
                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }
            int x = 0;
            int y = 0;
            int maxSum = int.MinValue;
            for (int row = 0; row < sizes[0] - 1; row++)
            {
                for (int col = 0; col < sizes[1] - 1; col++)
                {
                    if (matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1] > maxSum)
                    {
                        maxSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                        x = row;
                        y = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[x, y]} {matrix[x, y + 1]}");
            Console.WriteLine($"{matrix[x + 1, y]} {matrix[x + 1, y + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
