using System;

namespace ArrayRotation
{
    class ArrayRotation
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(" ");

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string elementOne = arr[0];

                for (int j = 1; j < arr.Length; j++)
                {
                    string currentElement = arr[j];
                    arr[j - 1] = currentElement;
                }
                arr[arr.Length - 1] = elementOne;
            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
