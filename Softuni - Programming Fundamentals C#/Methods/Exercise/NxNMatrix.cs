using System;

namespace NxNMatrix
{
    class NxNMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            static void PrintMatrix(int n)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write("{0} ", n);
                    }
                    Console.WriteLine();
                }
            }
            PrintMatrix(n);
        }
    }
}
