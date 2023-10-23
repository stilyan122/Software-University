using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class JaggedArrayManipulator
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                double[] cols = Console.ReadLine().Split().Select(double.Parse).ToArray();
                matrix[row] = new double[cols.Length];
                for (int col = 0; col < cols.Length; col++)
                {
                    matrix[row][col] = cols[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int rowCurrent = row; rowCurrent <= row + 1; rowCurrent++)
                    {
                        for (int col = 0; col < matrix[rowCurrent].Length; col++)
                        {
                            matrix[rowCurrent][col] *= 2;
                        }
                    }
                }
                else
                {
                    for (int rowCurrent = row; rowCurrent <= row + 1; rowCurrent++)
                    {
                        for (int col = 0; col < matrix[rowCurrent].Length; col++)
                        {
                            matrix[rowCurrent][col] /= 2;
                        }
                    }
                }
            }
            string input = Console.ReadLine();
            while (input!= "End")
            {
                string[] info = input.Split();
                if (info[0] == "Add")
                {
                    int row = int.Parse(info[1]);
                    int col = int.Parse(info[2]);
                    int value = int.Parse(info[3]);
                    if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] += value;
                    }
                }
                else if (info[0] == "Subtract")
                {
                    int row = int.Parse(info[1]);
                    int col = int.Parse(info[2]);
                    int value = int.Parse(info[3]);
                    if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] -= value;
                    }
                }
                input = Console.ReadLine();
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
