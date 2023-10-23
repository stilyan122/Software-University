using System;

namespace TopNumber
{
    class TopNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static bool IsTopNumber(int number)
        {
            int numForBool = number;
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            if (sum % 8 != 0)
            {
                return false;
            }
            while (numForBool > 0)
            {
                int digit = numForBool % 10;
                if (digit % 2 != 0)
                {
                    return true;
                }
                numForBool /= 10;
            }
            return false;
        }
    }
}
