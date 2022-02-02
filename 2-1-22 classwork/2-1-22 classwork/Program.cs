using System;

namespace _2_1_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 8, 7, 3, 5, 9, 2, 4, 6 };
            Console.WriteLine("Original array:");
            DisplayArray(numbers);
            //BubbleSort(numbers);
            //SelectionSort(numbers);
            MergeSort(numbers);
            Console.WriteLine("Sorted array:");
            DisplayArray(numbers);

            // see his code for initializing an array with a lot of random numbers
            
        }

        static void DisplayArray(int[] arr)  // O(n)
        {
            foreach (int value in arr)  // can use var instead of int; can use any variable instead of "value"
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }

        static void BubbleSort(int[] arr)  // O(n^2); this one doesn't check if the passed array is already sorted, BubbleSort2() below does
        // arrays are passed by reference, so if we pass an array from main method and change it, the array will be changed in main method
        {
            for (int j = 0; j < arr.Length; j++)
            {
                for (int i = 0; i < arr.Length-1-j; i++)  // -j because we only need to go one step fewer each run
                {
                    if (arr[i] > arr[i+1])
                    {
                        // swap
                        int temp;  // need this to temporarily hold a value during the swap process
                        temp = arr[i];  // can put in i+1 to start with, either works
                        arr[i] = arr[i+1];
                        arr[i+1] = temp;
                    }
                }
            }
        }

        // If passed array is already sorted, don't need to do all of the first BubbleSort() on it, just need to go through the first run to check
        static void BubbleSort2(int[] arr)  // O(n^2)
        // arrays are passed by reference, so if we pass an array from main method and change it, the array will be changed in main method
        {
            for (int j = 0; j < arr.Length; j++)
            {
            bool didSwap = false;  // before making each run, reset to false
                // one run
                for (int i = 0; i < arr.Length-1-j; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        // swap
                        didSwap = true;  
                        int temp;  // need this to temporarily hold a value during the swap process
                        temp = arr[i];  // can put in i+1 to start with, either works
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }
                if (didSwap == false)  // or !didSwap; if no swaps done, then the array is sorted, so quit the outer loop
                    break;
            }
        }

        static void SelectionSort(int[] arr)  // O(n^2)
        // can't know if passed arr is sorted with the first run like BubbleSort2() because you're not comparing values side-by-side
        {
            for (int j = 0; j < arr.Length-1; j++)  // brings the smallest value to position j
            {
                // find the position of the smallest value in the array
                int minPosition = j;  // position of the min/smallest value
                for (int i = j+1; i < arr.Length; i++)  // i=1 because arr[0] already set in minPosition
                {
                    if (arr[i] < arr[minPosition])  // if found value that's smaller
                        minPosition = i;
                }
                // when you get here, minPosition has the position of smallest value in the run
                // swap value at position minPosition and 0
                int temp = arr[j];
                arr[j] = arr[minPosition];
                arr[minPosition] = temp;
            }
        }

        static void MergeSort(int[] arr)  // O(n log n) faster than the others here
        {
            MergeSortHelper(arr, 0, arr.Length - 1);
        }

        static void MergeSortHelper(int[] arr, int startIndex, int endIndex)  // for dividing into subarrays (slices of the original array)
        {
            if (startIndex<endIndex)  // if we have at least 2 elements, divide and conquer
            {
                // divide
                int middleIndex = (startIndex + endIndex) / 2;
                MergeSortHelper(arr, startIndex, middleIndex);  // sort the first half
                MergeSortHelper(arr, middleIndex + 1, endIndex);  // sort the second half

                // conquer - merge the two halves
                Merge(arr, startIndex, middleIndex, endIndex);
            }
        }
        static void Merge(int[] arr, int startIndex, int middleIndex, int endIndex)
        {
            int[] tempArr = new int[arr.Length];  // temporary array - MOVED THIS TO THE FIRST MERGESORT() and kept passing it down to all merge functions; see his code
            int i = startIndex;  // will help run through the first half of the slice/subarray
            int j = middleIndex+1;  // will help run through the second half of the slice/subarray
            int k = startIndex;  // start index of the temp array

            while (i <= middleIndex && j <= endIndex)  // as long as I can compare values
            {
                if(arr[i] <= arr[j])
                {
                    tempArr[k] = arr[i];
                    i++;
                    k++;
                }
                else
                {
                    tempArr[k] = arr[j];
                    j++;
                    k++;    
                }
            }

            while (i <= middleIndex)  // copy the remaining values (if any) into the temp array
            {
                tempArr[k] = arr[i];
                i++;
                k++;
            }

            while (j <= endIndex)  // copy the remaining values (if any) into the temp array
            {
                tempArr[k] = arr[j];
                j++;
                k++;
            }
            // everything is merged in the temp array now

            for (int d = startIndex; d <= endIndex; d++)
            {
                arr[d] = tempArr[d];
            }
        }
    }
}
