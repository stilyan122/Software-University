using System;

namespace RecursiveFibonacci
{
    class RecursiveFibonacci
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = GetFibonacci(n);
            Console.WriteLine(result);
            int GetFibonacci(int n)
            {
                if (n == 1 || n == 2)
                {
                    return 1;
                }
                else
                {
                    return GetFibonacci(n - 1) + GetFibonacci(n - 2);
                }
            }
        }
    }
}
