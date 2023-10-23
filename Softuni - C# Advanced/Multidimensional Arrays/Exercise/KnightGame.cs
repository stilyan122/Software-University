using System;

namespace KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int side = int.Parse(Console.ReadLine());
            string[,] board = new string[side, side];
            for (int row = 0; row < side; row++)
            {
                string curr = Console.ReadLine();
                for (int col = 0; col < side; col++)
                {
                    board[row, col] = curr[col].ToString();
                }
            }
            int dangered = 0;
            int removed = 0; 
            for (int maxAttackPotential = 8; maxAttackPotential > 0; maxAttackPotential--)
            {
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col].ToLower() == "k")
                        {
                            if (row - 1 >= 0)
                            {
                                if (col - 2 >= 0)
                                {
  
                                    if (board[row - 1, col - 2].ToLower() == "k")
                                    {
                                        dangered++;
                                    }
                                }
                                if (col + 2 < board.GetLength(1))
                                {
                                    if (board[row - 1, col + 2].ToLower() == "k")
                                    {
                                        dangered++;
                                    }
                                }
                            }

                            if (row + 1 < board.GetLength(0))
                            {
                                if (col - 2 >= 0)
                                { 
                                    if (board[row + 1, col - 2].ToLower() == "k")
                                    {
                                        dangered++;
                                    }
                                }

                                if (col + 2 < board.GetLength(1))
                                {
                                    if (board[row + 1, col + 2].ToLower() == "k")
                                    {
                                        dangered++;
                                    }
                                }
                            }

                            if (row - 2 >= 0)
                            {
                                if (col - 1 >= 0)
                                {
                                    if (board[row - 2, col - 1].ToLower() == "k")
                                    {
                                        dangered++;
                                    }
                                }

                                if (col + 1 < board.GetLength(1))
                                {
                                    if (board[row - 2, col + 1].ToLower() == "k")
                                    {
                                        dangered++;
                                    }
                                }
                            }

                            if (row + 2 < board.GetLength(0))
                            {
                                if (col - 1 >= 0)
                                {
                                    if (board[row + 2, col - 1].ToLower() == "k")
                                    {
                                        dangered++;
                                    }
                                }

                                if (col + 1 < board.GetLength(1))
                                {
                                    if (board[row + 2, col + 1].ToLower() == "k")
                                    {
                                        dangered++;
                                    }
                                }
                            }
                        }
                        if (dangered == maxAttackPotential)
                        {
                            board[row, col] = "0";
                            removed++;
                        }
                        dangered = 0;
                    }
                }
            }
            Console.WriteLine(removed);
        }
    }
}
