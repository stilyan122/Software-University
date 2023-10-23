using System;

namespace Miner
{
    class Miner
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];
            string[] commands = Console.ReadLine().Split();
            int x = -1;
            int y = -1;
            bool output = true;
            int coal = 0;
            int allCoal = 0;
            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine().Split();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row,col]=="s")
                    {
                        x = row;
                        y = col;
                    }
                    if (matrix[row,col]=="c")
                    {
                        allCoal++;
                    }
                }
            }
            foreach (var way in commands)
            {
                string curr = "";
                if (way == "left" && y - 1 >= 0)
                {
                    y--;
                    curr = matrix[x, y];
                }
                else if (way == "right" && y + 1 < n)
                {
                    y++;
                    curr = matrix[x, y];
                }
                else if (way == "up" && x - 1 >= 0)
                {
                    x--;
                    curr = matrix[x, y];
                }
                else if (way == "down" && x + 1 < n)
                {
                    x++;
                    curr = matrix[x, y];
                }
                if (curr == "c")
                {
                    coal++;
                    matrix[x, y] = "*";
                }
                else if (curr == "e")
                {
                    Console.WriteLine($"Game over! ({x}, {y})");
                    output = false;
                }
            }
            if (coal==allCoal&&output==true)
            {
                output = false;
                Console.WriteLine($"You collected all coals! ({x}, {y})");
            }
            else if (output==true)
            {
                Console.WriteLine($"{allCoal-coal} coals left. ({x}, {y})");
            }
        }
    }
}
