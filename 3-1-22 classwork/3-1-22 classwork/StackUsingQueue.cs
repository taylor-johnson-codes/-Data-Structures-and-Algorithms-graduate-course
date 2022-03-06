using System;

namespace MyLibrary
{
    internal class StackUsingQueue<T> where T : IComparable
    {
        // DATA SECTION
        MyQueue<T> values = new MyQueue<T>();  // can use MyQueue properties and methods in this class
        public int CountSUQ { get { return values.CountQueue; } }  


        // METHOD(S) SECTION
        public void Push(T value)
        {
            values.Enqueue(value);  // adds value to the end of the queue
        }

        public T Pop()  
        // want to remove the last item in the queue, but MyQueue method to remove only allows removal from the beginning
        // solution: dequeue and enqueue values from the list until the one you want to pop is at the beginning of the queue to be able to pop it
        {
            for (int i = 0; i < CountSUQ - 1; i++)
                values.Enqueue(values.Dequeue());
            return values.Dequeue();
        }

        public T Peek()
        // dequeue and enqueue values from the list until the last item in the queue that you want to peek is at the beginning of the queue
        {
            for (int i = 0; i < CountSUQ - 1; i++)
                values.Enqueue(values.Dequeue());

            // to peek at the value and then put it back where it was originally:
            T temp = values.Dequeue();
            values.Enqueue(temp);
            return temp;
        }

        // ALTERNATIVE METHODS OF DOING THE SAME THINGS:
        //public void Push(T val) //O(n)
        //{
        //    values.Enqueue(val);
        //    for (int i = 0; i < Count2 - 1; i++)
        //        values.Enqueue(values.Dequeue());
        //}

        //public T Peek() //O(1)
        //{
        //    return values.Peek();
        //}

        //public T Pop() //O(1)
        //{
        //    return values.Dequeue();
        //}

        public void Clear()
        {
            values.Clear();
        }

        public void Display()
        {
            values.Display();
        }
    }
}
