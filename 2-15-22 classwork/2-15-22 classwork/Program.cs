using System;
using System.Collections;  // for built-in ArrayList
using System.Collections.Generic;

namespace _2_15_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //int size = 0;
            // add code to ask user for size (skipped)
            //int[] values = new int [size];
            
            //int[] values = new int [10];  // 0s are in the array by default in C#
            // can't add an 11th element onto the standard array

            // ArrayList allows for the array size to grow and shrink

            ArrayList myArrList = new ArrayList();  // myArrList points to new ArrayList object

            Console.WriteLine($"Current size: {myArrList.Count}, capacity: {myArrList.Capacity}");  // 0, 0

            myArrList.Add(10);
            Console.WriteLine($"Current size: {myArrList.Count}, capacity: {myArrList.Capacity}");  // 1, 4
            // allocates memory in a chunk of 4 element spots to start, then doubles the current capacity each time it needs more space
            // empty spots contain 0s but they're not accessible

            myArrList.Add(20);
            myArrList.Add(30);
            myArrList.Add(40);
            Console.WriteLine($"Current size: {myArrList.Count}, capacity: {myArrList.Capacity}");  // 4, 4

            myArrList.Add(50);
            Console.WriteLine($"Current size: {myArrList.Count}, capacity: {myArrList.Capacity}");  // 5, 8

            //myArrList.Capacity = 100;
            //Console.WriteLine($"Current size: {myArrList.Count}, capacity: {myArrList.Capacity}");
            // This works, but can't add an element value outside of a contiguous line of element values
            */


            // to create my own data type/structure, create a new class
            MyArrayList myList = new MyArrayList(2);
            Console.WriteLine($"Current size: {myList.Size}, capacity: {myList.Capacity}");

            // see his code for how do do foreach loop on the class I created; can't do by default; have to add : I... to class and another method
            // yield return: to keep returning in a loop for each iteration

            //MyArrayList<string> testList = new MyArrayList<string>;  // says to replace T in class with string
            //MyArrayList<int> testList2 = new MyArrayList<int>;  // says to replace T in class with string

        }
    }

    // this class is only built to work with string arrays
    class MyArrayList
    {
        // DATA
        // prop+tab+tab
        public int Size { get; private set; }
        // public: to access it in main method; "access modifier"
        // private set: so the value can only be changed in this class; read-only elsewhere 

        public int Capacity { get; private set; }

        public string[] Values;  // points to null until a new object is created

        // METHOD(S)
        public void Add(string newValue)  //  add value to end of array
        {
            // check if the array is full
            if(Size == Capacity)
                DoubleTheSize();

            // put the value at the end of the array
            Values[Size] = newValue;
            
            // increase the size of the array to account for this new value
            Size++;
        }

        public void AddLast(string newValue)  //  add value to end of array; same as Add()
        {
            Add(newValue);
        }

        public void AddFirst(string newValue)  //  add value to beginning of array
        {
            // shift all current values to the right 
            // start from the END of the array to do this so you don't override any values
            Insert(newValue, 0);
        }

        public void Insert(string newValue, int position)
        {
            // check if the array is full
            if(Size == Capacity)
            {
                DoubleTheSize();
            }

            // 
            if (position > Size)  // this would leave a gap
                throw new Exception($"You can't leave gaps; position should be at most {Size}");

            // shift to the right all the elements from position and on; shift them one position to the right
            for (int i = Size-1; i >= position; i--)  // right to left (Size-1 is the last element in the array)
                Values[i+1] = Values[i];  // move the value to the right

            // insert newValue at position
            Values[position] = newValue;

            // increase Size
            Size++;
        }

        public void DoubleTheSize()  // change to private if you don't want the main method to be able to do this
        {
            // create a new array of double the capacity
            string[] largerArr = new string[Capacity*2];

            // copy all elements from the old array to the new array
            for (int i = 0; i < Size; i++)
                largerArr[i] = Values[i];

            // redirect Values to point to the new array
            Values = largerArr;

            // update Capacity to double the value
            Capacity *= 2;
        }

        public bool IsEmpty()
        {
            //if (Size == 0)
            //    return true;
            //else
            //    return false;

            return Size == 0;
        }

        public void Clear()
        {
            //Size = 0;  // not safe because values are technically still there; just moves size pointer back to beginning of array

            // safer:
            Size = 0;
            Capacity = 4; // or whatever default you want
            Values = new string[Capacity];  // creates brand new array
        }

        // CONSTRUCTOR(S)
        // when new object is created, constructor is called
        public MyArrayList(int initialCapacity = 4)  // if nothing is passed, 4 will be used; "default parameter"
        {
            Size = 0;
            Capacity = initialCapacity;
            Values = new string[Capacity];  // Values now pointing to new object
        }
    }

    // Generic class "type safe"
    //class MyArrayList<T>
    //{
    //    // and where ever string is replaced it with T
    //}

}
