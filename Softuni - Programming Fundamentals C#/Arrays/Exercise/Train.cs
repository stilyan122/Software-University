using System;

namespace Train
{
    class Train
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] wagon = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int passengers = int.Parse(Console.ReadLine());
                wagon[i] = passengers;
                sum += passengers;
            }
            Console.WriteLine(string.Join(" ", wagon));
            Console.WriteLine(sum);
        }
    }
}
