using System;
using System.Numerics;

namespace FactorialDivision
{
    class FactorialDivision
    {
        static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            long factorielOne = GetFactorielFirstNumber(firstNum);
            long factorielTwo = GetFactorielFirstNumber(secondNum);

            double result = (factorielOne * 1.0 / factorielTwo);
            Console.WriteLine($"{result:F2}");

            static long GetFactorielFirstNumber(int firstNum)
            {
                long factorialOne = 1;

                for (int i = 1; i <= firstNum; i++)
                {
                    factorialOne = factorialOne * i;
                }
                return factorialOne;
            }
        }
    }
}
