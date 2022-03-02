using System;

namespace MyLibrary
{
    internal class MyQueue<T> where T : IComparable
    {
        // DATA SECTION
        private DoublyLinkedList<T> values = new DoublyLinkedList<T>();
        public int Count { get; private set; }

        // METHOD(S) SECTION
        public void Enqueue(T value)
        {
            values.AddFirst(value);  // can choose to add to beginning or end of DLL, just be consistent through the code with the decision
            Count++;
        }

        public T Dequeue()
        {
            T temp = values.Tail.Value;  // SEE HIS CODE, THIS BREAKS FOR ME
            values.DeleteLast();
            Count--;
            return temp;
        }

        public T Peek()
        {
            if (values.IsEmpty())
            {
                throw new Exception("Queue is empty, so there's nothing to peek.");
            }
            return values.Tail.Value;  // LOOK AT HIS CODE. THIS CRASHED FOR ME.
        }
    }
}
