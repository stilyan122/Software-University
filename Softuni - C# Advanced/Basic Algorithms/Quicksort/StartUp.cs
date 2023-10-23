using System;
using System.Linq;

namespace Quicksort
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            QuickSort(numbers, 0, numbers.Length - 1);
            Console.WriteLine(string.Join(" ", numbers));
        }
        private static void QuickSort(int[] numbers, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            return;
            int start = startIndex;
            int leftIndex = start + 1;
            int rightIndex = endIndex;
            while (leftIndex <= rightIndex)
            {
                if (numbers[leftIndex] > numbers[start] && numbers[rightIndex] < numbers[start])
                {
                    Swap(numbers, leftIndex, rightIndex);
                }
                if (numbers[leftIndex] <= numbers[start])
                    leftIndex++;
                if (numbers[rightIndex] >= numbers[start])
                    rightIndex--;
            }
            Swap(numbers, start, rightIndex);
            if (rightIndex - 1 - startIndex < endIndex - (rightIndex + 1))
            {
                QuickSort(numbers, startIndex, rightIndex - 1);
                QuickSort(numbers, rightIndex + 1, endIndex);
            }
            else
            {
                QuickSort(numbers, rightIndex + 1, endIndex);
                QuickSort(numbers, startIndex, rightIndex - 1);
            }
        }
        private static void Swap(int[] arr, int index1, int index2)
        {
            var help = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = help;
        }
    }
}
