using System;
using System.Linq;
using System.Text;

namespace MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();
            int[,] matrix = new int[size[0], size[1]];
            int startRow = 0;
            int startCol = 0;
            int max = 0;
            for (int i = 0; i < size[0]; i++)
            {
                var cols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < size[1]; j++)
                {
                    matrix[i, j] = cols[j];
                }
            }
            for (var i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (var j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    var sum = 0;
                    for (var x = i; x < i + 3; x++)
                    {
                        for (var y = j; y < j + 3; y++)
                        {
                            sum += matrix[x, y];
                        }
                    }
                    if (sum > max)
                    {
                        max = sum;
                        startRow = i; 
                        startCol = j;
                    }
                }
            }
            StringBuilder output = new StringBuilder();
            Console.WriteLine($"Sum = {max}");
            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int y = startCol; y < startCol + 3; y++)
                {
                    output.Append(matrix[i, y] + " ");
                }
                output.AppendLine();
            }
            Console.WriteLine(output.ToString().Trim());
        }
    }
}
