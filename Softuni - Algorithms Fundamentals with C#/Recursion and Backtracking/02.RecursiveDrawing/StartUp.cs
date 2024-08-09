using System;

namespace _02.RecursiveDrawing
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Print(n);
        }

        public static void Print(int n)
        {
            if (n == 1)
            {
                Console.WriteLine("*");
                Console.WriteLine("#");
                return;
            }

            Console.WriteLine(new string('*', n));
            Print(n - 1);
            Console.WriteLine(new string('#', n));
        }
    }
}
