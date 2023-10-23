using System;

namespace SmallestOfThreeNumbers
{
    class SmallestOfThreeNumbers
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int smallest = GetSmallest(num1, num2, num3);
            Console.WriteLine(smallest);
        }
        public static int GetSmallest(int num1, int num2, int num3)
        {
            int smallest = num1;

            if (num2 < smallest)
            {
                smallest = num2;
            }

            if (num3 < smallest)
            {
                smallest = num3;
            }

            return smallest;
        }
    }
}
