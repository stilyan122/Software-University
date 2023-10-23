using System;

namespace MultiplyEvensByOdds
{
    class MultiplyEvensByOdds
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int result = GetMultipleOfEvenAndOdds(number);
            Console.WriteLine(result);
        }

        static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;
            number = Math.Abs(number);
            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                {
                    sum += digit;
                }
                number /= 10;
            }
            return sum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int sum = 0;
            number = Math.Abs(number);
            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 != 0)
                {
                    sum += digit;
                }
                number /= 10;
            }
            return sum;
        }

        static int GetMultipleOfEvenAndOdds(int number)
        {
            int evenSum = GetSumOfEvenDigits(number);
            int oddSum = GetSumOfOddDigits(number);
            return evenSum * oddSum;
        }
    }
}
