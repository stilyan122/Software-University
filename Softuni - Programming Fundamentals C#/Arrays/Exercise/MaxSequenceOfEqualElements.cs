using System;

namespace MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            int bestCount = 0;
            int bestIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                string currentElement = arr[i];
                int currentCounter = 1;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (currentElement == arr[j])
                    {
                        currentCounter++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentCounter > bestCount)
                {
                    bestCount = currentCounter;
                    bestIndex = i;
                }
            }
            for (int i = 0; i < bestCount; i++)
            {
                Console.Write(arr[bestIndex] + " ");
            }
        }
    }
}
