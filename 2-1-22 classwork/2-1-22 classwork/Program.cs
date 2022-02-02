using System;

namespace _2_1_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 8, 7, 3, 5, 9, 2, 4, 6 };
            DisplayArray(numbers);
            BubbleSort(numbers);
            DisplayArray(numbers);
        }
        static void BubbleSort(int[] arr)  // O(n^2)
        // arrays are passed by reference, so if we pass an array from main method and change it, the array will be changed in main method
        {
            for (int j = 0; j < arr.Length; j++)
            {
                for (int i = 0; i < arr.Length-1; i++)
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

        // If passed array is already sorted, don't need to do all of the first Bubblesort() on it, just need to go through the first run to check
        static void BubbleSort2(int[] arr)  // O(n^2)
        // arrays are passed by reference, so if we pass an array from main method and change it, the array will be changed in main method
        {
            for (int j = 0; j < arr.Length; j++)
            {
            bool didSwap = false;  // before making each run, reset to false
                // one run
                for (int i = 0; i < arr.Length - 1; i++)
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
        static void DisplayArray(int[] arr)
        {
            foreach(int value in arr)  // can use var instead of int; can use any variable instead of "value"
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }
    }
}
