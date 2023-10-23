using System;

namespace PrintNumbersInReverseOrder
{
    public class PrintNumbersInReverseOrder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                arr[i] = number;
            }
            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(arr[i]+" ");
            }
            Console.WriteLine();
        }
    }
}
