using System;

namespace SymbolInMatrix
{
    class SymbolInMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string symbols = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }
            char symbolToFind = char.Parse(Console.ReadLine());
            int x = 0;
            int y = 0;
            bool isFound = false;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == symbolToFind)
                    {
                        x = row;
                        y = col;
                        isFound = true;
                        break;
                    }
                }
                if (isFound == true)
                {
                    break;
                }
            }
            if (isFound == true)
            {
                Console.WriteLine($"({x}, {y})");
            }
            else
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
        }
    }
}
