using System;

namespace MyLibrary
{
    internal class MyStack<T> where T : IComparable
    {
        // A stack is FILO or LIFO; like a stack of plates or the browser's back button

        // DATA SECTION
        private DoublyLinkedList<T> values = new DoublyLinkedList<T>();  // can use other data structures for a stack, e.g. an array
        public int CountStack { get; private set; }  // main method can read but not write

        // METHOD(S) SECTION
        public void Push(T value)  // add a value to the list
        {
            values.AddLast(value);  // can choose to add to the beginning or end of the list, just be consistent through the code with the decision
            CountStack++;
        }

        public T Pop()  // remove a value from the list
        {
            T temp = values.Tail.Value;  // need to save the value to be able to return the value after it's deleted
            values.DeleteLast();
            CountStack--;
            return temp;  // to show the user what value was deleted
        }

        public T Peek()  // look at the last value that was added to the list
        {
            if (values.IsEmpty())  // if the list is empty, .Value below will crash it
                throw new Exception("The stack is empty, so there's nothing to peek.");  // program crashes
            return values.Tail.Value;  
        }

        public void Clear()  // clear the list
        {
            values.Clear();
        }

        public void Display()  // display the values in the list
        {
            values.Display();
        }

        // CONSTRUCTOR(S) SECTION
    }
}
