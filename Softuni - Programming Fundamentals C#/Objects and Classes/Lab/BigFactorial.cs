using System;
using System.Numerics;

namespace BigFactorial
{
    class BigFactorial
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger big = 1;
            for (int i = 2; i <= n; i++)
            {
                big *= i;
            }
            Console.WriteLine(big);
        }
    }
}
