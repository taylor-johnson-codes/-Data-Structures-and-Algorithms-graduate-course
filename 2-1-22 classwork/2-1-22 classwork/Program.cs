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
            SelectionSort(numbers);
            Console.WriteLine("Sorted array:");
            DisplayArray(numbers);
            
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


    }
}
