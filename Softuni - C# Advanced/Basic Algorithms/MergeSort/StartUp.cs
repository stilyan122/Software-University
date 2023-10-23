using System;
using System.Linq;

namespace MergeSort
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            numbers = MergeSort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }
        private static int[] MergeSort(int[] array)
        {
            if (array.Length == 1)
                return array;
            int middle = array.Length / 2;
            int[] left = array.Take(middle).ToArray();
            int[] right = array.Skip(middle).ToArray();
            return MergeArrays(MergeSort(left), MergeSort(right));
        }
        private static int[] MergeArrays(int[] leftArray, int[] rightArray)
        {
            int[] sorted = new int[leftArray.Length + rightArray.Length];
            int sortedIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;
            while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                if (leftArray[leftIndex] < rightArray[rightIndex])
                {
                    sorted[sortedIndex++] = leftArray[leftIndex++];
                }
                else
                {
                    sorted[sortedIndex++] = rightArray[rightIndex++];
                }
            }
            for (int i = leftIndex; i < leftArray.Length; i++)
            {
                sorted[sortedIndex++] = leftArray[i];
            }
            for (int i = rightIndex; i < rightArray.Length; i++)
            {
                sorted[sortedIndex++] = rightArray[i];
            }
            return sorted;
        }
    }
}
