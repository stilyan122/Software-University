using System;

namespace CommonElements
{
    class CommonElements
    {
        static void Main(string[] args)
        {
            string[] arrFirst = Console.ReadLine().Split(" ");
            string[] arrSecond = Console.ReadLine().Split(" ");

            foreach (string elementTwo in arrSecond)
            {
                for (int i = 0; i < arrFirst.Length; i++)
                {
                    if (elementTwo == arrFirst[i])
                    {
                        Console.Write(elementTwo + " ");
                        break;
                    }
                }
            }
        }
    }
}
