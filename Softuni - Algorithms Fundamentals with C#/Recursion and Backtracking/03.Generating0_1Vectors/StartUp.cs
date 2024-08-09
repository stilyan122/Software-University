using System;

namespace _03.Generating0_1Vectors
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Print(new int[n], 0);
        }

        public static void Print(int[] array, int index)
        {
            if (index >= array.Length)
            {
                Console.WriteLine(string.Join("", array));
                return;
            }
            for (int i = 0; i <= 1; i++)
            {
                array[index] = i;
                Print(array, index + 1);
            }
        }
    }
}
