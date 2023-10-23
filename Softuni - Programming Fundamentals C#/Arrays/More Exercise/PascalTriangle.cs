using System;

namespace PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int c = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || i == 0)
                        c = 1;
                    else
                        c = c * (i - j + 1) / j;
                    Console.Write("{0} ", c);
                }
                Console.Write("\n");
            }
        }
    }
}
