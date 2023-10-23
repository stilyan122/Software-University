using System;
using System.Linq;
using System.Collections.Generic;

namespace Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            if (size == 0)
            {
                Console.WriteLine($"Alive cells: 0");
                Console.WriteLine($"Sum: 0");
                Console.WriteLine(0);
                return;
            }
            int[,] matrix = new int[size, size];
            int counter = 0;
            int sum = 0;
            for (int row = 0; row < size; row++)
            {
                int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string[] coords = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            foreach (var coord in coords)
            {
                string[] splitted = coord.Split(",",StringSplitOptions.RemoveEmptyEntries);
                int x = int.Parse(splitted[0]);
                int y = int.Parse(splitted[1]);
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (row==x&&col==y)
                        {
                            int value = matrix[x, y];
                            if (value > 0)
                            {
                                if (x - 1 >= 0 && y - 1 >= 0)
                                {
                                    if(matrix[x-1,y-1]>0)
                                    matrix[x - 1, y - 1] -= value;
                                }
                                if (x - 1 >= 0)
                                {
                                    if (matrix[x - 1, y] > 0)
                                        matrix[x - 1, y] -= value;
                                }
                                if (x - 1 >= 0 && y + 1 < size)
                                {
                                    if (matrix[x - 1, y + 1] > 0)
                                        matrix[x - 1, y + 1] -= value;
                                }
                                if (y - 1 >= 0)
                                {
                                    if (matrix[x, y - 1] > 0)
                                        matrix[x, y - 1] -= value;
                                }
                                if (y + 1 < size)
                                {
                                    if (matrix[x, y + 1] > 0)
                                        matrix[x, y + 1] -= value;
                                }
                                if (x + 1 < size && y - 1 >= 0)
                                {
                                    if (matrix[x + 1, y - 1] > 0)
                                        matrix[x + 1, y - 1] -= value;
                                }
                                if (x + 1 < size)
                                {
                                    if (matrix[x + 1, y] > 0)
                                        matrix[x + 1, y] -= value;
                                }
                                if (x + 1 < size && y + 1 < size)
                                {
                                    if (matrix[x + 1, y + 1] > 0)
                                        matrix[x + 1, y + 1] -= value;
                                }
                            }
                            matrix[x,y] = 0;
                            break;
                        }
                    }
                }
            }
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row,col] > 0)
                    {
                        counter++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (col < size - 1)
                        Console.Write(matrix[row, col] + " ");
                    else
                        Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
