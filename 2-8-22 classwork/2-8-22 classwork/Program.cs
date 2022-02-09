using System;

namespace _2_8_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 8, 7, 3, 5, 9, 2, 4, 6 };
            Console.WriteLine("Original array:");
            DisplayArray(numbers);
            QuickSort(numbers);
            Console.WriteLine("Sorted array:");
            DisplayArray(numbers);

            // see his code for random # generator for array and for stopwatch
        }

        static void DisplayArray(int[] arr)  // O(n)
        {
            foreach (int value in arr)  // can use var instead of int; can use any variable instead of "value"
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }

        static void QuickSort(int[] arr)
        // Time complexity worse case scenario O(n^2) if last elements happens to be the smallest or largest value in array - very unbalanced subarrays: one with one element the other with all the rest of the elements
        // on average it's O(n log n) - more balanced subarrays
        {
            QuickSortHelper(arr, 0, arr.Length - 1);
        }

        static void QuickSortHelper(int[] arr, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)  // need at least 2 elements to sort; or 0 or 1 element is in array and that's sorted
            {
                // UPDATE q name to pivot
                int q = Partition(arr, leftIndex, rightIndex);  // q is the position for pivot after partition
                QuickSortHelper(arr, leftIndex, q - 1);  // recursively sort each side/each subarray
                QuickSortHelper(arr, q + 1, rightIndex);  // recursively sort each side/each subarray
            }
        }

        static int Partition(int[] arr, int leftIndex, int rightIndex)  // Time complexity O(n)
        {
            // UPDATE i name to explain better
            int i = leftIndex - 1;  // i points right before left, outside of array to start, then it keeps track of the position before the pivot
            // 1 less than the pivot found so far
            int pivot = arr[rightIndex];  // last value is the pivot
            // the for loop does the partition;
            // CHANGE j name to i for more standard var in for loop
            for (int j = leftIndex; j < rightIndex; j++)  // right - 1 b/c don't need to include the last element in the array
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    // exchange arr[i] and arr[j]
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            i++;  // moves i to where we want to put pivot/partition and swap the partition and what's at i
            // exchange values at position i and rightIndex
            int temp2 = arr[i];
            arr[i] = arr[rightIndex];
            arr[rightIndex] = temp2;
            return i;  // return the new position of the pivot
        }
    }
}
