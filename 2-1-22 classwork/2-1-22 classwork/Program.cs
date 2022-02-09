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

        static void BubbleSort(int[] arr)  // time complexity O(n^2); this one doesn't check if the passed array is already sorted, BubbleSort2() below does
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
        // space complexity O(1) because we need to use an int temp var
        // If passed array is already sorted, don't need to do all of the first BubbleSort() on it, just need to go through the first run to check
        // If passed array is already sorted, then bubble sort is faster than selection sort even though they're both O(n^2)
        static void BubbleSort2(int[] arr)  // time complexity O(n^2)
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

        static void SelectionSort(int[] arr)  // time complexity O(n^2)  // searching one less of n in each search
        // start at beginning, traverse for smallest, beginning +1 repeat
        // space complexity O(1) because we need to use an int temp var

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

        static void MergeSort(int[] arr)  // time complexity O(n log n) is faster than the other sorts here
        // O(log n) split and sort each half individually and keep repeating; O(n) to merge
        // space complexity o(n) because temp array of n length is needed
        {
            int[] tempArr = new int[arr.Length];  // allocating a temporary buffer (piece of memory to use temporarily)
            MergeSortHelper(arr, 0, arr.Length - 1, tempArr);
        }

        static void MergeSortHelper(int[] arr, int startIndex, int endIndex, int[] passedtempArr)  // for dividing into subarrays ("slices" of the original array)
        {
            if (startIndex<endIndex)  // if we have at least 2 elements in the current subarray, then divide and conquer
            {
                // divide (and keep dividing with recursion)
                int middleIndex = (startIndex + endIndex) / 2;
                MergeSortHelper(arr, startIndex, middleIndex, passedtempArr);  // divides it into first "half"; sorting of this "half" is done in the next conquer portion
                MergeSortHelper(arr, middleIndex + 1, endIndex, passedtempArr);  // // divides it into second "half"; sorting of this "half" is done in the next conquer portion

                // conquer - merge the two halves
                Merge(arr, startIndex, middleIndex, endIndex, passedtempArr);
            }
            // else statement not needed because there's nothing to do because array has 0 or 1 element and that makes it a sorted array
        }
        static void Merge(int[] arr, int startIndex, int middleIndex, int endIndex, int[] passedtempArr)  // merge the subarrays
        {
            //int[] tempArr = new int[arr.Length];  // temporary array - MOVED THIS TO THE FIRST MERGESORT() and kept passing it down to all merge functions; see his code
            // can keep it and use it here instead of passing from beginning, but Merge() is going to called a lot so don't want to allocate this temp arr a lot, just once
            // moving it up helps processing time so it's not constantly allocating and deallocating and reallocating memory for this temp array 
            
            int i = startIndex;  // will help run through the first half of the slice/subarray
            int j = middleIndex + 1;  // will help run through the second half of the slice/subarray
            int k = startIndex;  // start index of the temp array

            while (i <= middleIndex && j <= endIndex)  
            // as long as I can compare values from two subarrays/two "halves"; as long as there are values in both subarrays to compare
            {
                if(arr[i] <= arr[j])  // seeing if the first element of the first "half" is smaller than the first element of the second "half"
                {
                    passedtempArr[k] = arr[i];
                    i++;
                    k++;
                }
                else  // if not, do the opposite 
                {
                    passedtempArr[k] = arr[j];
                    j++;
                    k++;    
                }
            }

            // copy the remaining values (if any) into the temp array because there's no longer values in both subarrays to compare
            while (i <= middleIndex)  
            {
                passedtempArr[k] = arr[i];  // for any values left in the first subarray/first "half"
                i++;
                k++;
            }

            while (j <= endIndex)  // for any values left in the second subarray/second "half"
            {
                passedtempArr[k] = arr[j];
                j++;
                k++;
            }
            // everything is merged in the temp array now

            for (int d = startIndex; d <= endIndex; d++)  // "d" can be any variable name
            {
                arr[d] = passedtempArr[d];
            }
        }
    }
}
