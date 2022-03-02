using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLibrary
{
    internal class SinglyLinkedList<T>: IEnumerable<T> where T : IComparable  // IE part is for using a foreach loop; IC part is for generic/type safe class
    {
        // DATA SECTION
        Node<T> Head { get; set; }

        // METHOD(S) SECTION
        public bool IsEmpty()
        {
            return Head == null;  // if false (head is null) the list is empty; returns true or false
        }

        public void AddFirst(T newValue)
        {
            // create a new node
            Node<T> newNode = new Node<T>(newValue);

            // link in the new node
            newNode.Next = Head;  // newNode's pointer is now pointing to the first node in the linked list

            // move the head pointer
            Head = newNode;  // now head points to newNode
        }

        public void AddLast(T newValue)
        {
            if (IsEmpty())
                AddFirst(newValue);  // if the list is empty, the AddLast() code in the else block won't work; AddFirst() will work
            else
            {
                // create a new node
                Node<T> newNode = new Node<T>(newValue);

                // find the last node
                Node<T> pointer = Head;  // have to start at Head; if the list is empty head will point to null which is fine

                // while loop will crash if the list is empty because pointer.Next will be invalid
                while (pointer.Next != null)  // stops with pointer on the last node
                    pointer = pointer.Next;  // move pointer to the right

                // link in the new node
                pointer.Next = newNode;
            }
        }

        public void DeleteFirst()
        {
            if (IsEmpty())
                //return;  // this just ignores the request and the code moves on
                throw new Exception("You can't delete from an empty list.");  // this crashes and lets the user know what's wrong
            else
                Head = Head.Next;  // if head points to null (the list is empty), Head.Next will crash the code so that's why this is in if/else statement
        }

        public void DeleteLast()
        {
            // make second to last node point to null
            // will crash if the list is empty or has only one element because pointer.Next.Next will be invalid in those two cases
            if (IsEmpty())
                throw new Exception("You can't delete from an empty list.");  // this crashes and lets the user know what's wrong
            else if (Head.Next == null)  // list has one node
                DeleteFirst();
            else
            {
                // traverse to the second to last node
                Node<T> pointer = Head;

                // look two steps ahead; if it's not null move the pointer; if it is null this is where to stop
                while (pointer.Next.Next != null)
                    pointer = pointer.Next;

                // link the last node out (pointer points to the next to last element)
                pointer.Next = null;
            }
        }

        public void DeleteValue(T valueToDelete) // deletes the first value it finds that matches; won't delete all if the value appears more than once in the list
        {
            if (IsEmpty())
                throw new Exception("You can't delete from an empty list.");  // this crashes and lets the user know what's wrong
            else if (Head.Value.CompareTo(valueToDelete) == 0)   // need this at the beginning of the class for CompareTo() to work: class SinglyLinkedList<T> where T : IComparable 
                DeleteFirst();  // if it's the first value in the list use DeleteFirst()
            else  // traverse and look ahead for value; if it's not what we're looking for, move pointer; if it is, break the link and link past it
            {
                Node<T> pointer = Head;

                while ((pointer.Next != null) && (pointer.Next.Value.CompareTo(valueToDelete) != 0))  // leave loop either when the list ends or when you find the node to delete
                    pointer = pointer.Next;

                if (pointer.Next == null)  // there wasn't a match and the end of the list was reached
                    Console.WriteLine($"{valueToDelete} wasn't found in the list so nothing was deleted.");
                else  // there was a match
                    pointer.Next = pointer.Next.Next;  // links out the node containing valueToDelete
                // OR JUST:
                //if (pointer.Next != null && (pointer.Next.Value).CompareTo(value) == 0)
                //    pointer.Next = pointer.Next.Next;

            }
        }

        public void Clear()
        {
            Head = null;  // now Head isn't pointing to anything so the rest of the nodes are dangling out here and the garbage collector will take care of them
        }

        public void Display()
        {
            if (IsEmpty())
                Console.WriteLine("The list is empty so there are no values to display.");
            else
            {
                Node<T> pointer = Head;  // point to the first node

                while (pointer != null)  // looping will stop when pointer points to null; pointer.Next will crash the program if pointer points to null
                {
                    Console.Write($"{pointer.Value}  ");  // display value
                    pointer = pointer.Next;  // move pointer to the right
                }
                Console.WriteLine();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> pointer = Head;
            while (pointer != null)
            {
                yield return pointer.Value;
                pointer = pointer.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        // CONSTRUCTOR(S) SECTION
        // ctor+tab+tab shortcut

        // this is automatically here in the background:
        //public SinglyLinkedList()
        //{
        //    Head = null;
        //}
    }
}
