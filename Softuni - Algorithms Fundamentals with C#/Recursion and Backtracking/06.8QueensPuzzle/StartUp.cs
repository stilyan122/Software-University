using System;
using System.Collections.Generic;

namespace _06._8QueensPuzzle
{
    public class StartUp
    {
        static void Main()
        {
            var board = new char[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = '-';
                }
            }

            var attackedRows = new HashSet<int>();
            var attackedCols = new HashSet<int>();
            var attackedLeftD = new HashSet<int>();
            var attackedRightD = new HashSet<int>();

            PutQueens(board, 0, attackedRows, attackedCols, attackedLeftD, attackedRightD);
        }

        public static void PutQueens(char[,] board, int row, HashSet<int> attackedRows,
            HashSet<int> attackedCols, HashSet<int> attackedLeftD, HashSet<int> attackedRightD)
        {
            if (row >= board.GetLength(0))
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (board[i, j] == 'Q')
                        {
                            Console.Write("* ");
                        }
                        else
                        {
                            Console.Write("- ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                return;
            }

            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (CanPlace(row, i, attackedRows, attackedCols, attackedLeftD, attackedRightD))
                {
                    attackedRows.Add(row);
                    attackedCols.Add(i);
                    attackedLeftD.Add(row - i);
                    attackedRightD.Add(row + i);

                    board[row, i] = 'Q';

                    PutQueens(board, row + 1, attackedRows, attackedCols, attackedLeftD, attackedRightD);

                    attackedRows.Remove(row);
                    attackedCols.Remove(i);
                    attackedLeftD.Remove(row - i);
                    attackedRightD.Remove(row + i);

                    board[row, i] = '-';
                }
            }
        }

        public static bool CanPlace(int row, int col, HashSet<int> attackedRows,
            HashSet<int> attackedCols, HashSet<int> attackedLeftD, HashSet<int> attackedRightD)
        {
            if (attackedCols.Contains(col) || 
                attackedRows.Contains(row) || 
                attackedLeftD.Contains(row - col) ||
                attackedRightD.Contains(row + col))
            {
                return false;
            }

            return true;
        }
    }
}
