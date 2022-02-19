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
            
            //int[] values = new int [10];  // 0s are in the array by default in C# (but they're not accessible)
            // can't add an 11th element onto the standard array


            // ArrayList allows for the array size to grow and shrink
            // Built-in ArrayList and built-in .Add(): 

            ArrayList myArrList = new ArrayList();  // myArrList points to new ArrayList object

            Console.WriteLine($"Current size: {myArrList.Count}, capacity: {myArrList.Capacity}");  // 0, 0

            myArrList.Add(10);
            Console.WriteLine($"Current size: {myArrList.Count}, capacity: {myArrList.Capacity}");  // 1, 4
            // allocates memory in a chunk of 4 element spots to start, then doubles the current capacity each time it needs more space
            // empty spots contain 0s, but they're not accessible

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


            // Now using our own methods and properties from scratch (not built-ins):
            // To create my own data type/data structure, create a new class

            MyArrayList<string> myList = new MyArrayList<string>(2);  // myList points to a new MyArrayList object with a capacity of two elements; it's a generic/type-safe class so you have to specify data type with <>
            //myList.Size = 5;  // doesn't work, .Size is a read-only property outside of its class

            Console.WriteLine("STRING ARRAY");
            Console.WriteLine($"Array is empty: {myList.IsEmpty()}");

            Console.WriteLine($"Count: {myList.Size}, capacity: {myList.Capacity}");  // .Size and .Capacity properties were created in the MyArrayList class below

            myList.Add("Saint");
            Console.WriteLine($"Count: {myList.Size}, capacity: {myList.Capacity}");

            myList.Add("Martin's");
            Console.WriteLine($"Count: {myList.Size}, capacity: {myList.Capacity}");

            myList.Add("University");
            Console.WriteLine($"Count: {myList.Size}, capacity: {myList.Capacity}");


            Console.WriteLine($"Array is empty: {myList.IsEmpty()}");

            // print the values (foreach loop doesn't work without IEnumerable/GetEnumerator in MyArrayList class)
            Console.Write("Array values:  ");
            foreach (var val in myList)
                Console.Write($"{val}   ");
            Console.WriteLine();
            Console.WriteLine();


            MyArrayList<int> numbers = new MyArrayList<int>();  // will use default capacity of 4
            Console.WriteLine("INTEGER ARRAY");
            Console.WriteLine($"Array is empty: {numbers.IsEmpty()}");

            numbers.Add(30);
            Console.WriteLine($"Count: {numbers.Size}, capacity: {numbers.Capacity}");
            numbers.AddFirst(10);
            Console.WriteLine($"Count: {numbers.Size}, capacity: {numbers.Capacity}");
            numbers.Insert(20, 1);
            Console.WriteLine($"Count: {numbers.Size}, capacity: {numbers.Capacity}");
            numbers.Add(40);
            Console.WriteLine($"Count: {numbers.Size}, capacity: {numbers.Capacity}");
            numbers.AddLast(50);
            Console.WriteLine($"Count: {numbers.Size}, capacity: {numbers.Capacity}");

            Console.WriteLine($"Array is empty: {numbers.IsEmpty()}");

            // print the values
            Console.Write("Array values:  ");
            foreach (var val in numbers)
                Console.Write($"{val}   ");
            Console.WriteLine();
            Console.WriteLine();

            numbers.Clear();
            Console.WriteLine("Cleared numbers array.");
            Console.WriteLine($"Count: {numbers.Size}, capacity: {numbers.Capacity}");
        }
    }

    // this example class would only work with string arrays:
    //class ArrayListStrExample
    //{
    //    public ArrayListStrExample() 
    //    {
    //        StrArrayOnly = new string[5];  // str array with capacity of 5 elements
    //    }
    //}


    // this class will create an ArrayList from scratch
    // it can be used with different data types (e.g. string, int, double, bool)
    // "type safe"; "generic class"; "generic programming"
    class MyArrayList<T> : IEnumerable  // <T> is for any data type; IEnumerable is for our GetEnumerator() constructor
    {
        // DATA SECTION
        // prop+tab+tab shortcut for adding a property
        public int Size { get; private set; }  // Number of elements in the array
        // public: to access it in main method; "access modifier"
        // private set: the value can only be changed in this class; read-only elsewhere 

        public int Capacity { get; private set; }  // How many elements the array is able to hold

        public T[] Values;  // an array of any data type; Values points to null until a new object is created


        // METHOD(S) SECTION
        public void Add(T newValue)  //  add an element value to end of array
        {
            // check if the array is full
            if(Size == Capacity)
                DoubleTheSize();

            // put the value at the end of the array
            Values[Size] = newValue;
            
            // increase the count of the array to account for this new element
            Size++;
        }

        public void AddLast(T newValue)  //  add an element value to end of array; same as Add()
        {
            Add(newValue);
        }

        public void AddFirst(T newValue)  // add an element value to beginning of array
        {
            Insert(newValue, 0);
            // will shift all current values to the right one spot
            // will start from the END of the array so you don't override any values
        }

        public void Insert(T newValue, int position)  // add an element anywhere in the array
        {
            // check if the array is full
            if(Size == Capacity)
                DoubleTheSize();

            // this situation would leave a gap between elements; elements need to be contiguous
            if (position > Size) 
                throw new Exception($"You can't leave gaps between elements; position argument should be at most {Size}.");

            // shift all elements from the position argument to the right one spot
            // start from the END of the array so you don't override any values
            for (int i = Size-1; i >= position; i--)  // working from right to left in the array (Count-1 is the last element position in the array)
                Values[i+1] = Values[i];  // move the value to the right

            // insert newValue at position argument
            Values[position] = newValue;

            // increase the count of the array to account for this new element
            Size++;
        }

        public void DoubleTheSize()  // change to private if you don't want the main method to be able to do this
        {
            // create a new array of double the capacity
            T[] largerArr = new T[Capacity*2];

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

            return Size == 0;  // will return true or false
        }

        public void Clear()
        {
            //Count = 0;  
            // not safe because values are technically still there and accessible
            // this just resets the Count variable to 0

            // safer:
            Size = 0;
            Capacity = 4; // or whatever default number you want
            Values = new T[Capacity];  // creates a brand new empty array that Values points to
        }

        // so we can use a foreach loop on our class (needs :IEnumerable next to class name)
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                yield return Values[i];
                // yield return: to go through the whole loop and return in each iteration

        }
   

        // CONSTRUCTOR(S) SECTION
        // when new object is created, constructor is called
        public MyArrayList(int initialCapacity = 4)  // if nothing is passed, 4 will be used; "default parameter"
        {
            Size = 0;
            Capacity = initialCapacity;
            Values = new T[Capacity];  // Values now pointing to new object
        }
    }
}