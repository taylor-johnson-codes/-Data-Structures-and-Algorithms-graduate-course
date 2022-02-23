using System;

namespace _2_22_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Singly Linked List

            //Node<int> myNode = new Node<int>();  // new node with an empty value if constructor doesn't require a parameter

            //Node<int> nodeNET5example = new(1);  // this works in .NET 5.x but not in older versions like .NET 3.x

            /*
            Node<int> node1 = new Node<int>(10);
            Node<int> node2 = new Node<int>(20);
            Node<int> node3 = new Node<int>(30);
            Node<string> node4 = new Node<string>("WA");
            node4.Value = "SMU";

            node1.Next = node2;  // node1 now points to node2; without this line node1 would point to null
            node2.Next = node3;

            // display node3 value
            Console.WriteLine(node3.Value);  
            Console.WriteLine(node2.Next.Value);
            Console.WriteLine(node1.Next.Next.Value);
            */

            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.Display();  // IN HOMEWORK ADD A MESSAGE IF LIST IS EMPTY use isEmpty(); change display to print
            list.AddFirst(10);
            list.AddFirst(20);  // will be added before 10
            list.AddFirst(30);  // will be added before 20

            list.AddLast(500);
            list.AddLast(600);
            list.AddLast(700);
            list.Display();


        }
    }

    // new data type called Node; generic/type-safe class
    class Node<T>  
    {
        // DATA SECTION
        // prop+tab+tab shortcut; property names are capitalized
        public T Value { get; set; }
        public Node <T> Next { get; set; }

        // METHOD(S) SECTION


        // CONSTRUCTOR(S) SECTION
        public Node(T newValue)
        {
            Value = newValue;
        }
    }

    class SinglyLinkedList<T> where T : IComparable  // for .CompareTo()
    {
        // DATA SECTION
        Node<T> Head { get; set; }

        // METHOD(S) SECTION
        public bool IsEmpty()  // running time O(1)
        {
            return Head == null;  // if false (head is null) the list is empty
        }

        public void AddFirst(T newValue)  // running time O(1)
        {
            // create a new node
            Node<T> newNode = new Node<T>(newValue);
            
            // link in the new node
            newNode.Next = Head;  // newNode's pointer is now pointing to the first node in the linked list; could also do newNode.Next

            // move the head pointer
            Head = newNode;  // now head points to newNode
        }

        public void AddLast(T newValue)  // running time O(n); SHOULD BE O(1) IN DOUBLY LINKED LIST - it'll be similar to addFirst in DLL
        {
            if (IsEmpty())
                AddFirst(newValue);
            else
            {
                // create a new node
                Node<T> newNode = new Node<T>(newValue);

                // find the last node
                Node<T> pointer = Head;  // have to start at Head; if list is empty head=null which is fine

                // while loop will crash if list is empty
                while (pointer.Next != null)  // stops with pointer on the last node
                    pointer = pointer.Next;  // move pointer to the right

                // link in the new node
                pointer.Next = newNode;
            }
        }
        
        public void DeleteFirst()  // running time O(1)
        {
            if (IsEmpty())
                //return;  // this just ignores the request and the code moves on
                throw new Exception("You can't delete from an empty list.");  // this crashes and lets the user know what's wrong
            else
                Head = Head.Next;  // if head is null, head.next will crash the code so that's why this is in if/else block
        }

        public void DeleteLast()  // running time O(n)
        {
            // make previous node point to null
            // will crash if list is empty or has only one element because of pointer.Next.Next
            if (IsEmpty())
                throw new Exception("You can't delete from an empty list.");  // this crashes and lets the user know what's wrong
            else if(Head.Next == null)  // list has one node
            {
                DeleteFirst();
            }
            else
            {
                // traverse to the next to last node
                Node<T> pointer = Head;

                // look two steps ahead; if it's not null move the pointer; if it is null this is where to stop
                while (pointer.Next.Next != null)  // will crash if list is empty or has only one element because of pointer.Next.Next
                    pointer = pointer.Next;

                // link the last node out (pointer points to the next to last element)
                pointer.Next = null;  // HAVE TO TAKE CARE OF BACKWARDS LINK IN DOUBLY LINKED
            }
        }

        public void DeleteValue(T valueToDelete)  // deletes the first value it finds that matches, not all if the value repeats
        {
            if (IsEmpty())
                throw new Exception("You can't delete from an empty list.");  // this crashes and lets the user know what's wrong
            // if it's the first value use DeleteFirst()
            else if(Head.Value.CompareTo(valueToDelete) == 0)   // == doesn't work here because it's a generic/type-safe class; need this: class SinglyLinkedList<T> where T : IComparable 
            {
                DeleteFirst();
            }
            // traverse and look ahead for value, if it's not move pointer, when yes it is, break the link and link past it
            // DDL HAVE TO CONSIDER BOTH POINTERS
            else
            {
                Node<T> pointer = Head;
                // leave loop either when list ends or when you found the node to delete
                while ((pointer.Next != null) && (pointer.Next.Value.CompareTo(valueToDelete) == 0))  // keep doing this until value is found
                {
                    pointer = pointer.Next;  // move right
                }

                if (pointer.Next == null)
                    Console.WriteLine($"{valueToDelete} wasn't found in the list so nothing was deleted.");
                else  // there was a match
                    pointer.Next = pointer.Next.Next;  // will crash if we got here because loop ended because it got to end of list
            }
        }

        // this Clear() works for singly, but not doubly b/c every node has .Next and .Previous (pointers pointing back and forth)
        //   so when stuff points to a node it's still accessible so garbage collector will leave it alone
        public void Clear()  // running time O(1) - // running time O(n) FOR DLL!!! 
        {
            Head = null;  // now Head not pointing to anything so the rest of the nodes are dangling out here and garbage collector will take care of them
        }

        public void Display()  // running time O(n)
        {

            // CHECK IF LIST IS EMPTY, IF IT IS DISPLAY CW MESSAGE


            Node<T> pointer = Head;  // point to the first node
            while (pointer != null)  // looping will stop when pointer points to null
            { 
                Console.Write($"{pointer.Value}  ");  // display value
                pointer = pointer.Next;  // move pointer to the right
                // pointer.Next will crash if pointer is null
            }
        }

        // ctor shortcut i think

        // CONSTRUCTOR(S) SECTION

        // this is automatically here in the background:
        //public SinglyLinkedList()
        //{
        //    Head = null;
        //}
    }
}
