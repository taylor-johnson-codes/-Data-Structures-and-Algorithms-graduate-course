using System;

namespace _2_1_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 8, 7, 3, 5, 9, 2, 4, 6 };
            // arrays are passed by reference, so if we pass an array from main method and change it in a different method, the array will be changed in main method as well

            Console.WriteLine("Original array:");
            DisplayArray(numbers);
            //BubbleSort(numbers);
            //BubbleSort2(numbers);
            //SelectionSort(numbers);
            MergeSort(numbers);
            Console.WriteLine("Sorted array:");
            DisplayArray(numbers);

            // initializing an array with random numbers
            //Random randGener = new Random();

            //int size = 10;  // how many elements you want in the array
            //int[] numbers1 = new int[size];  // create 3 empty arrays
            //int[] numbers2 = new int[size];
            //int[] numbers3 = new int[size];

            //for (int i = 0; i < size; i++)
            //{
            //    //numbers1[i] = i;  // to populate the array with numbers in order from 0 to the number of the length of the array minus 1
            //    numbers1[i] = randGener.Next(1,4000000);  // to populate the array with random numbers that range from 1 to 4,000,000
            //    numbers2[i] = numbers1[i];  // to populate the 2nd and 3rd arrays with the exact same numbers
            //    numbers3[i] = numbers1[i];
            //}

            // use with an array of a large number of elements like 100,000 or more to compare how long the three sorting methods take
            //Console.WriteLine("start merge");
            //MergeSort(numbers3);
            //Console.WriteLine("end merge");

            //Console.WriteLine("start select");
            //SelectionSort(numbers2);
            //Console.WriteLine("end select");

            //Console.WriteLine("start bubble");
            //BubbleSort2(numbers1);
            //Console.WriteLine("end bubble");
        }

        static void DisplayArray(int[] arr)  // time complexity O(n)
        {
            foreach (int value in arr)  // can use var instead of int; can use any variable instead of "value"
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }

        static void BubbleSort(int[] arr)  // this one doesn't check if the passed array is already sorted, BubbleSort2() below does
        // one traversal guarentees the largest value is moved to the last position in the array
        // each traversal builds on getting the end/larger numbers sorted
        // void return type because arrays are passed by reference; if we pass an array from main method and change it here, the array will be changed in main method
        // time complexity O(n^2) - nested for loop; space complexity O(1) - we need to use an int temp variable
        {
            for (int j = 0; j < arr.Length; j++)
            {
                for (int i = 0; i < arr.Length-1-j; i++)  // -1-j because we only need to go one step less further from the end in each run
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

        static void BubbleSort2(int[] arr)  // builds upon BubbleSort() to check if the passed array is already sorted when passed
        // If passed array is already sorted, don't need to do all of the first BubbleSort() code on it, just need to go through the first run to check
        // If passed array is already sorted, then bubble sort is faster than selection sort even though they're both O(n^2)
        // see notes in BubbleSort() for more info about bubble sort
        {
            for (int j = 0; j < arr.Length; j++)
            {
            bool didSwap = false;  // before making each run, reset to false
                // a run
                for (int i = 0; i < arr.Length-1-j; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        // swap
                        didSwap = true;  // flag that we swapped
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

        static void SelectionSort(int[] arr)
        // start at beginning, traverses for the smallest value and put it at beginning, goes back to the start of what hasn't been searched and repeats until all sorted
        // sorts the from the beginning of the array in order to the end of the array
        // can't know if passed array is sorted with the first run like in BubbleSort2() because we're not comparing values side-by-side like BubbleSort2() does
        // time complexity O(n^2) - searching one less of n in each search; space complexity O(1) - we need to use an int temp variable
        {
            for (int j = 0; j < arr.Length-1; j++)  // brings the smallest value to position j
            {
                // find the position of the smallest value in the array
                int minPosition = j;  // keeps track of the position of the smallest value
                for (int i = j+1; i < arr.Length; i++)  // i=j+1 because j already set in minPosition
                {
                    if (arr[i] < arr[minPosition])  // if value that's smaller is found...
                        minPosition = i;  // update minPosition
                }
                // when you get here, minPosition has the position of the smallest value in the run
                // swap value at position minPosition and j
                int temp = arr[j];
                arr[j] = arr[minPosition];
                arr[minPosition] = temp;
            }
        }

        static void MergeSort(int[] arr)  // requires MergeSortHelper() and Merge() below to work
        // divide the array down into subarrays of one element each and then merge the subarrays together in order to make a full sorted array
        // time complexity O(n log n); breakdown: O(log n) split and sort each half individually and keep repeating * O(n) to merge = O(n log n)
        // space complexity O(n) because a temp array of n length is needed
        {
            int[] tempArr = new int[arr.Length];  // allocating a temporary buffer (piece of memory to use temporarily)
            MergeSortHelper(arr, 0, arr.Length - 1, tempArr);
            // passes along the original array, the index positions of the original array, and the temp array
        }

        static void MergeSortHelper(int[] arr, int startIndex, int endIndex, int[] passedtempArr)  // for dividing into subarrays ("slices" of the original array)
        {
            if (startIndex < endIndex)  // if we have at least 2 elements in the current subarray, then divide and conquer
            {
                // divide (and keep dividing with recursion)
                int middleIndex = (startIndex + endIndex) / 2;
                MergeSortHelper(arr, startIndex, middleIndex, passedtempArr);  // divides into first "half"; sorting of this "half" is done in the next conquer portion
                MergeSortHelper(arr, middleIndex + 1, endIndex, passedtempArr);  // divides into second "half"; sorting of this "half" is done in the next conquer portion

                // conquer - merge the two halves
                Merge(arr, startIndex, middleIndex, endIndex, passedtempArr);
            }
            // else statement not needed because there's nothing else to do because the array/subarray contains 0 or 1 element and that makes it a sorted array
        }
        static void Merge(int[] arr, int startIndex, int middleIndex, int endIndex, int[] passedtempArr)  // merge the subarrays
        {
            //int[] tempArr = new int[arr.Length];  
            // temporary array - moved this to MergeSort() and kept passing it down to all merge functions instead
            // moving it up (so the memory is allocated once) instead of keeping it here helps processing time so it's not constantly allocating and deallocating and reallocating memory for this temp array if the code for it were to be kept here
            
            int i = startIndex;  // to run through the first half of the slice/subarray
            int j = middleIndex + 1;  // to run through the second half of the slice/subarray
            int k = startIndex;  // starting index of the temp array

            while (i <= middleIndex && j <= endIndex)  
            // as long as there are values in both subarrays to compare
            {
                if(arr[i] <= arr[j])  // seeing if the first element of the first subarray is smaller than the first element of the second subarray
                {
                    passedtempArr[k] = arr[i];
                    i++;
                    k++;
                }
                else  // if it's not, do the opposite 
                {
                    passedtempArr[k] = arr[j];
                    j++;
                    k++;    
                }
            }

            // copy the remaining values (if any) into the temp array because there's no longer values in both subarrays to compare
            while (i <= middleIndex)  
            {
                passedtempArr[k] = arr[i];  // for any values left in the first subarray
                i++;
                k++;
            }

            while (j <= endIndex)  // for any values left in the second subarray
            {
                passedtempArr[k] = arr[j];
                j++;
                k++;
            }
            // everything is merged in order in the temp array now

            for (int d = startIndex; d <= endIndex; d++)  // "d" can be any variable name
            {
                arr[d] = passedtempArr[d];  // updating the original array to match the temp array
            }
        }
    }
}