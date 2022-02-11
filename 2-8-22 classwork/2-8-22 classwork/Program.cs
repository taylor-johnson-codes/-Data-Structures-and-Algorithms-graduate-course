using System;
using System.Diagnostics;  // to use stopwatch

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

            // populate an array with random numbers
            Random randGener = new Random();
            int size = 10;  // size of array
            int[] numbers1 = new int[size];  // new empty array

            for (int i = 0; i < size; i++)
                numbers1[i] = randGener.Next(1, 100);  // populate the array with numbers between 1 and 100

            Console.WriteLine("Original array:");
            DisplayArray(numbers1);
            QuickSort(numbers1);
            Console.WriteLine("Sorted array:");
            DisplayArray(numbers1);


            // random number generator and stopwatch (use with a solution that contains all the sorting methods from 2-1-22 and 2-8-22)
            //Random randGener = new Random();
            //var stopWatch = new Stopwatch();

            //int size = 100000;
            //int[] numbers1 = new int[size];
            //int[] numbers2 = new int[size];
            //int[] numbers3 = new int[size];
            //int[] numbers4 = new int[size];

            //for (int i = 0; i < size; i++)
            //{
            //    numbers1[i] = randGener.Next(1, 4000000);
            //    numbers2[i] = numbers1[i];
            //    numbers3[i] = numbers1[i];
            //    numbers4[i] = numbers1[i];

            //}

            //Console.WriteLine("start quick");
            //stopWatch.Start();
            //QuickSort(numbers4);
            //stopWatch.Stop();
            //Console.WriteLine($"end quick: {stopWatch.ElapsedMilliseconds} ms");

            //Console.WriteLine("start merge");
            //stopWatch.Restart();
            //MergeSort2(numbers3);
            //stopWatch.Stop();
            //Console.WriteLine($"end merge:  {stopWatch.ElapsedMilliseconds} ms");

            //Console.WriteLine("start select");
            //stopWatch.Restart();
            //SelectionSort(numbers2);
            //stopWatch.Stop();
            //Console.WriteLine($"end select:  {stopWatch.ElapsedMilliseconds} ms");

            //Console.WriteLine("start bubble");
            //stopWatch.Restart();
            //BubbleSort2(numbers1);
            //stopWatch.Stop();
            //Console.WriteLine($"end bubble:  {stopWatch.ElapsedMilliseconds} ms");
        }

        static void DisplayArray(int[] arr)  //  time complexity O(n)
        {
            foreach (int value in arr)  // can use var instead of int; can use any variable instead of "value"
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }

        static void QuickSort(int[] arr)  // needs QuickSortHelper() and Partition() to work
        // time complexity worse case scenario is O(n^2); if the last element happens to be the smallest or largest value in the array, this results in very unbalanced subarrays - one with no elements and the other with all the rest of the elements
        // time complexity on average is O(n log n) - more balanced subarrays
        {
            QuickSortHelper(arr, 0, arr.Length - 1);
            // passing along the original array, and its starting index and ending index
        }

        static void QuickSortHelper(int[] arr, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)  // need at least 2 elements to sort; or 0 or 1 element is in the array and that's sorted
            {
                int pivotPosition = Partition(arr, leftIndex, rightIndex);  // the position for the pivot after the partition
                QuickSortHelper(arr, leftIndex, pivotPosition - 1);  // recursively sort each subarray
                QuickSortHelper(arr, pivotPosition + 1, rightIndex);  // recursively sort each subarray
            }
        }

        static int Partition(int[] arr, int leftIndex, int rightIndex)  // Time complexity O(n)
        {
            int posBeforePivot = leftIndex - 1;  // keeps track of the position before the pivot position (points to position outside of the array to start)
            int pivot = arr[rightIndex];  // last element value is the pivot
            // the for loop does the partition
            for (int i = leftIndex; i <= rightIndex - 1; i++)  // doesn't include rightIndex because that the pivot assigned to the pivot variable
            {
                if (arr[i] <= pivot)  // if the value is less than or equal to the value of pivot...
                {
                    posBeforePivot++;  // move this tracker up one
                    // swap arr[posBeforePivot] and arr[i]
                    int temp = arr[posBeforePivot];
                    arr[posBeforePivot] = arr[i];
                    arr[i] = temp;
                }
            }

            //posBeforePivot++;  // moves the tracker to where we want to place the pivot/partition, so now the variable name is inaccurate because it's now the position of the pivot
            //// exchange values at posBeforePivot and rightIndex/the pivot value
            //int temp2 = arr[posBeforePivot];
            //arr[posBeforePivot] = arr[rightIndex];
            //arr[rightIndex] = temp2;
            //return posBeforePivot;  // return the position of the pivot; variable name became inaccurate when posBeforePivot++ was run a few lines ago

            int pivotPosition = posBeforePivot+1;  // updating variable name to be more descriptive to help me out; +1 moves the tracker to where we want to place the pivot/partition
            // exchange values at pivotPosition and rightIndex/the pivot value
            int temp2 = arr[pivotPosition];
            arr[pivotPosition] = arr[rightIndex];
            arr[rightIndex] = temp2;
            return pivotPosition;  // return the position of the pivot
        }
    }
}
