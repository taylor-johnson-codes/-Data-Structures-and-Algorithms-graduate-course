using System;

namespace _1_25_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 5, 7, 9, 11, 13, 15, 17 };
            Console.WriteLine("Linear search result/position of value:");
            Console.WriteLine(LinearSearch(numbers, 7));
            Console.WriteLine("Binary search result in int arr/position of value:");
            Console.WriteLine(BinarySearchIntArr(numbers, 7));

            // ask the user for a number
            //Console.WriteLine("Enter an integer to search for: ");
            //int num = int.Parse(Console.ReadLine());  // if the user enters a non-integer, the program will crash; see below to fix this issue with TryParse
            //Console.WriteLine(LinearSearch(numbers, num));

            // ask the user for a number
            Console.WriteLine("Enter an integer to search for: ");
            int num;
            if (int.TryParse(Console.ReadLine(), out num))  // int.TryParse(valueToCheck, out intVersionOfValueToCheck); "out" is required; returns bool
            // if the string was able to be converted to int, assign the int version to num
            {
                Console.WriteLine(LinearSearch(numbers, num));
            }
            else  // if the string was NOT able to be converted to int
            {
                Console.WriteLine("Bad input; you must enter an integer.");
            }

            string[] values = { "martin", "saint", "lacey", "wa", "university" };
            Console.WriteLine("Binary search result in str arr:");
            Console.WriteLine(BinarySearchStrArr(values, "university"));

            //int[] randomNums = { 10, 44, 690, 32, 2, 59 };
            //Console.WriteLine($"Min in randomNums = {FindMin(randomNums)}");
            //Console.WriteLine($"Max in randomNums = {FindMax(randomNums)}");
        }

        /// <summary>
        /// Linear Search - will search for "someValue" in the array "arr"
        /// Running time: O(n) - linear
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="someValue"></param>
        /// <returns>the index of someValue in arr if found; -1 otherwise</returns>
        static int LinearSearch(int[] arr, int someValue)  // O(n)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                //check arr[i] against someValue
                if (arr[i] == someValue)
                    return i;  // someValue was found in arr
            }
            return -1;  // this will only run if someValue not found in arr
        }

        static int BinarySearchIntArr(int[] arr, int someValue)  // O(log(n))
        {
            // verify the array is sorted first!

            // the subarray being searched [leftIndex, rightIndex]
            int leftIndex = 0;
            int rightIndex = arr.Length - 1;

            while (leftIndex <= rightIndex)  // to determine if you have at least one number in the array 
            // while(true) doesn't work in all cases: if someValue isn't in the array, both rightIndex and leftIndex will end up going in the wrong direction from each other
            {
                // find the middle
                int middleIndex = (leftIndex + rightIndex) / 2;  // reminder: there are no fractions when dividing ints

                if (someValue == arr[middleIndex])
                    return middleIndex;  // success!
                else if (arr[middleIndex] > someValue)  // search to the left; discard the right half; update rightIndex
                    rightIndex = middleIndex - 1;
                else  // search to the right; discard the left half; update leftIndex
                    leftIndex = middleIndex + 1;
            }
            return -1;  // this will only run if someValue not found in arr
        }

        static int BinarySearchStrArr(string[] arr, string someValue)  // O(log(n))
        {
            // verify the array is sorted first!

            // the subarray being searched
            int leftIndex = 0;
            int rightIndex = arr.Length - 1;

            while (leftIndex <= rightIndex)   // to determine if you have at least one number in the array 
            // while(true) doesn't work in all cases: if someValue isn't in the array, both rightIndex and leftIndex will end up going in the wrong direction from each other
            {
                // find the middle
                int middleIndex = (leftIndex + rightIndex) / 2;  // reminder: there are no fractions when dividing ints

                // CompareTo returns -1, 0, or 1 (smaller, equal, larger)
                if (someValue.CompareTo(arr[middleIndex]) == 0)  // == 0 means is equal to
                    return middleIndex;  // success!
                else if (arr[middleIndex].CompareTo(someValue) > 0)  // > 0 means is larger than; can't use < or > on strings so we're using CompareTo
                    rightIndex = middleIndex - 1;  // search to the left; discard the right half; update rightIndex
                else
                    leftIndex = middleIndex + 1;  // search to the right; discard the left half; update leftIndex
            }
            return -1;  // this will only run if someValue not found in arr
        }

        // "generic method"; T is a placeholder
        static int GenericBinarySearch<T>(T[] arr, T someValue) where T : IComparable
        {
            // verify the array is sorted first!

            // the subarray being searched
            int leftIndex = 0;
            int rightIndex = arr.Length - 1;

            while (leftIndex <= rightIndex)  
            // while(true) doesn't work in all cases: if someValue isn't in the array, both rightIndex and leftIndex will end up going in the wrong direction from each other
            {
                // find the middle
                int middleIndex = (leftIndex + rightIndex) / 2;  // reminder: there are no fractions when dividing ints
                if (someValue.CompareTo(arr[middleIndex]) == 0)  // can't use == with <T> 
                {
                    return middleIndex;  // success
                }
                //else if (arr[middleIndex] > someValue)  // can't do < or > on strings
                else if (arr[middleIndex].CompareTo(someValue) > 0)  // CompareTo returns 0 if LOOK UP
                {
                    // search to the left; discard the right half; update rightIndex
                    rightIndex = middleIndex - 1;
                }
                else
                {
                    // search to the right; discard the left half; update leftIndex
                    leftIndex = middleIndex + 1;
                }
            }
            return -1;
        }

        static int FindMax(int[] arr)
        {
            // save the first element value of the array
            int maxValue = arr[0];

            // traverse the remaining array values
            for (int i = 1; i < arr.Length; i++)  // start at 1 because we've already looked at 0
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];  // update maxValue
                }
            }
            return maxValue;
        }

        static int FindMin(int[] arr)
        {
            // verify array is not an empty array
            if (arr.Length == 0)
            {
                throw new Exception("Error: empty arrays don't have min values");  // program still crashes, but now this specific error message is displayed
            }

            // save the first element value of the array
            int minValue = arr[0];

            // traverse the remaining array values
            for (int i = 1; i < arr.Length; i++)  // start at 1 because we've already looked at 0
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];  // update maxValue
                }
            }
            return minValue;
        }
    }
}
