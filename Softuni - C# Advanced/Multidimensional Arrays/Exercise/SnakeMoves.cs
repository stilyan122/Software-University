using System;
using System.Linq;
using System.Collections.Generic;

namespace SnakeMoves
{
    class SnakeMoves
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = nums[0];
            int cols = nums[1];
            char[,] matrix = new char[rows, cols];
            string snake = Console.ReadLine();
            int counter = 0;
            Queue<char> queue = new Queue<char>();
            int capacity = rows * cols;

            for (int i = 0; i < snake.Length; i++)
            {
                queue.Enqueue(snake[i]);
                counter++;

                if (counter == capacity)
                {
                    break;
                }
                if (i == snake.Length - 1)
                {
                    i = -1;
                }
            }

            for (int j = 0; j < rows; j++)
            {
                if (j % 2 == 0)
                {
                    for (int i = 0; i < cols; i++)
                    {
                        matrix[j, i] = queue.Dequeue();
                    }
                }
                else if (j % 2 != 0)
                {
                    for (int k = cols - 1; k >= 0; k--)
                    {
                        matrix[j, k] = queue.Dequeue();
                    }
                }

            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
