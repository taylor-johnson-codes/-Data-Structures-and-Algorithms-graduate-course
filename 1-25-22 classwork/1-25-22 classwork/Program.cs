using System;

namespace _1_25_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 5, 7, 9, 11, 13, 15, 17 };
            Console.WriteLine(LinearSearch(numbers, 8));

            // ask the user for a number
            Console.WriteLine("Please enter an integer: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(LinearSearch(numbers, num));

            Console.WriteLine("Please enter an integer: ");
            int num2;
            if (int.TryParse(Console.ReadLine(), out num2))  // "out" is required here
            {
                Console.WriteLine(LinearSearch(numbers, num2));
            }
            else
            {
                Console.WriteLine("bad input");
            }

            string[] values = { "martin", "saint", "lacey", "wa", "university" };

            int[] randomNums = { 10, 44, 690, 32, 2, 59 };
            Console.WriteLine($"Min = {FindMin(randomNums)}");

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
            for (int i = 0; i < arr.Length - 1; i++)  // -1 because index starts at zero
            {
                //check arr[i] against someValue
                if (arr[i] == someValue)
                {
                    return i;  // someValue was found in arr
                }
            }
            return -1;  // this will only run if someValue not found in arr
        }

        static int BinarySearch(int[] arr, int someValue)  // O(log(n))
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
                if (someValue == arr[middleIndex])
                {
                    return middleIndex;  // success
                }
                else if (arr[middleIndex] > someValue)
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

        static int BinarySearch(string[] arr, string someValue)  // O(log(n))
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
                if (someValue == arr[middleIndex])  // can use == or use CompareTo for consistancy 
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
