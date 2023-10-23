using System;
using System.Numerics;

namespace RecursiveFactorial
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BigInteger Factorial(int num,BigInteger factorial)
            {
                if (num==1)
                {
                    return factorial;
                }
                factorial *= num;
                num--;
                return Factorial(num, factorial);
            }
            BigInteger fact = Factorial(int.Parse(Console.ReadLine()),1);
            Console.WriteLine(fact);
        }
    }
}
