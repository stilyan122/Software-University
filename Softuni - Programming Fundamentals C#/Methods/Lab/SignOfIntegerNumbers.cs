using System;

namespace SignOfIntegerNumbers
{
    class SignOfIntegerNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            void CheckNum(int number)
            {
                if (number<0)
                {
                    Console.WriteLine($"The number {number} is negative.");
                }
                else if (number>0)
                {
                    Console.WriteLine($"The number {number} is positive.");
                }
                else
                {
                    Console.WriteLine($"The number {number} is zero. ");
                }
            }
            CheckNum(n);
        }
    }
}
