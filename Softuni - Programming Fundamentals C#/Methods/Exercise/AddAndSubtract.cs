using System;

namespace AddAndSubtract
{
    class AddAndSubtract
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int sum = SumTwoIntegers(a, b);
            int result = SubtractFromSum(sum, c);
            Console.WriteLine(result);
        }
        public static int SumTwoIntegers(int a, int b)
        {
            return a + b;
        }

        public static int SubtractFromSum(int sumResult, int c)
        { 
            return sumResult - c;
        }
    }
}
