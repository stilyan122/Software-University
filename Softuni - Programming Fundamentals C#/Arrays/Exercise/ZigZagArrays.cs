using System;
using System.Linq;
namespace ZigZagArrays
{
    class ZigZagArrays
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arrOne = new string[n];
            string[] arrTwo = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] currentArray = Console.ReadLine().Split(" ").ToArray();

                string elementZero = currentArray[0];
                string elementOne = currentArray[1];

                if (i % 2 == 0)
                {
                    arrOne[i] = elementZero;
                    arrTwo[i] = elementOne;
                }
                else if (i % 2 == 1)
                {
                    arrOne[i] = elementOne;
                    arrTwo[i] = elementZero;
                }
            }
            Console.WriteLine(string.Join(" ", arrOne));
            Console.WriteLine(string.Join(" ", arrTwo));
        }
    }
}
