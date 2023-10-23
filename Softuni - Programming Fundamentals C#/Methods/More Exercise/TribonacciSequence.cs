using System;

namespace TribonacciSequence
{
    class TribonacciSequence
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            FindNum(n);
        }
        static void FindNum(int n)
        {
            int[] array = new int[n];
            if (n > 3)
            {
                array[0] = 1;
                array[1] = 1;
                array[2] = 2;
                for (int i = 3; i < n; i++)
                {
                    array[i] = array[i - 3] + array[i - 2] + array[i - 1];
                }
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i]+" ");
                }
                Console.WriteLine();
            }
            else if(n==1)
            {
                Console.WriteLine("1");
            }
            else if(n==2)
            {
                Console.WriteLine("1 1");
            }
            else
            {
                Console.WriteLine("1 1 2");
            }
        }
    }
}
