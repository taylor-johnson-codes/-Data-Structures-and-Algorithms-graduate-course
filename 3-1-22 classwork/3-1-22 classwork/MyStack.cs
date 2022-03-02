using System;

namespace MyLibrary
{
    internal class MyStack<T> where T : IComparable
    {
        // DATA SECTION
        private DoublyLinkedList<T> values = new DoublyLinkedList<T>();
        public int Count { get; private set; }  // main method can read but not wrote

        // METHOD(S) SECTION
        public void Push(T value)
        {
            values.AddLast(value);  // can choose to add to beginning or end of DLL, just be consistent through the code with the decision
            Count++;
        }

        public T Pop()
        {
            T temp = values.Tail.Value;
            values.DeleteLast();
            Count--;
            return temp; 
        }

        public T Peek()
        {
            if (values.IsEmpty())
            {
                throw new Exception("Your stack is empty, there's nothing to peek.");  // program crashes
            }
            return values.Tail.Value;  // if list is empty .Value will crash it
        }

        public void Clear()
        {
            values.Clear();
        }


        // CONSTRUCTOR(S) SECTION


    }
}
