using System;

namespace MyLibrary
{
    internal class MyQueue<T> where T : IComparable
    {
        // A queue is FIFO or LILO; like standing in line or printing documents

        // DATA SECTION
        private DoublyLinkedList<T> values = new DoublyLinkedList<T>();  // can use other data structures for a stack, e.g. an array
        public int CountQueue { get; private set; }  // main method can read but not write

        // METHOD(S) SECTION
        public void Enqueue(T value)  // add a value to the end of the queue
        {
            values.AddFirst(value);  // can choose to add to the beginning or end of the list, just be consistent through the code with the decision
            CountQueue++;
        }

        public T Dequeue()  // remove the first value from the queue
        {
            T temp = values.Tail.Value;  // need to save the value to be able to return the value after it's deleted
            values.DeleteLast();
            CountQueue--;
            return temp;  // to show the user what value was deleted
        }

        public T Peek()  // look at the first value in the queue
        {
            if (values.IsEmpty())
                throw new Exception("Queue is empty, so there's nothing to peek.");
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
    }
}
