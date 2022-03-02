using System;

namespace MyLibrary
{
    internal class StackUsingQueue<T> where T : IComparable
    {
        // DATA SECTION
        MyQueue<T> values = new MyQueue<T>();
        public int Count2 { get { return values.Count; } }  // uses Count property from MyQueue class


        // METHOD(S) SECTION
        public void Push(T value)
        {
            values.Enqueue(value);  // adds value to the end of the queue
        }

        public T Pop()  
        // want to remove last item in queue, but queue properties only allow add to end or remove from beginning
        // dequeue and enqueue values until the one you want to pop is at the beginning of the queue
        {
            for (int i = 0; i < Count2 - 1; i++)
            {
                values.Enqueue(values.Dequeue());
            }
            return values.Dequeue();
        }

        public T Peek()
        {
            for (int i = 0; i < Count2 - 1; i++)
            {
                values.Enqueue(values.Dequeue());
            }

            T temp = values.Dequeue();
            values.Enqueue(temp);
            return temp;
        }

        // SEE HIS CODE FOR ALTERNATIVE METHODS OF DOING THE SAME THING


    }
}
