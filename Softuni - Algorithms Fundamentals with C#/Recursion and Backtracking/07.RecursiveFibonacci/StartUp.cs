using System;

namespace _07.RecursiveFibonacci
{
    public class StartUp
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(GetNumber(number));
        }

        public static long GetNumber(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return GetNumber(n - 1) + GetNumber(n - 2);
        }
    }
}
