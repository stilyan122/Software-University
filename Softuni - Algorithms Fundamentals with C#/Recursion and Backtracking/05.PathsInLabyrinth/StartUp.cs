using System;
using System.Collections.Generic;

namespace _05.PathsInLabyrinth
{
    public class StartUp
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            PrintAllPaths(matrix, 0, 0, new List<string>(), string.Empty);
        }

        public static void PrintAllPaths(char[,] matrix, int row, int col, List<string> directions, 
            string direction)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == '*' || matrix[row, col] == 'v')
            {
                return;
            }

            directions.Add(direction);

            if (matrix[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            matrix[row, col] = 'v';

            PrintAllPaths(matrix, row + 1, col, directions, "D");
            PrintAllPaths(matrix, row - 1, col, directions, "U");
            PrintAllPaths(matrix, row, col + 1, directions, "R");
            PrintAllPaths(matrix, row, col - 1, directions, "L");

            matrix[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }
    }
}
