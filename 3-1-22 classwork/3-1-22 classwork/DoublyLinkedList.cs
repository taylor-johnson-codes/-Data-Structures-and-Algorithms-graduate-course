using System;

namespace MyLibrary
{
    internal class DoublyLinkedList<T> where T : IComparable  // for .CompareTo()
    {
        // DATA SECTION
        // initialized to point to null by default, so explicit constructor not needed for this
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        // METHOD(S) SECTION
        public void AddFirst(T newValue)  // works on empty list or populated list; running time O(1)
        {
            // create a new node
            Node<T> newNode = new Node<T>(newValue);

            if (IsEmpty())  // if the list is empty, the newNode will be the only node in the list
            {
                Head = newNode;
                Tail = newNode;
            }
            else  // if the list is NOT empty
            {
                // link in the new node as the first node
                newNode.Next = Head;  // newNode's forward pointer is now pointing to the first node in the linked list
                Head.Previous = newNode;  // Head is now second in the list so Head.Previous points to newNode because that's the first in the list

                // update the head
                Head = newNode;  // now Head points to the first node in the list
            }
        }

        public void AddLast(T newValue)  // running time O(1)
        {
            // create a new node
            Node<T> newNode = new Node<T>(newValue);

            if (IsEmpty())  // if the list is empty, the newNode will be the only node in the list
            {
                Head = newNode;
                Tail = newNode;
            }
            else  // if the list is NOT empty
            {
                // link in the new node as the last node
                newNode.Previous = Tail;  // newNode's backward pointer is now pointing to the last node in the linked list
                Tail.Next = newNode;  // Tail is now second to last in the list so Tail.Next points to newNode because that's the last in the list

                // update the tail
                Tail = newNode;  // now Tail points to the last node in the list
            }
        }

        public void DeleteFirst()  // running time O(1)
        {
            if (IsEmpty())
                throw new Exception("You can't delete from an empty list.");
                // this crashes and lets the user know what's wrong; if head points to null (list is empty), Head.Next will crash the code
            else if (Head.Next == null)  // the list only has one node, the head node
            {
                Tail = null;
                Head = null;
            }
            else  // there are two or more nodes in the list
            {
                // move the head
                Head = Head.Next;

                // delete the links to the previous head
                Head.Previous.Next = null;
                Head.Previous = null;
            }
        }

        public void DeleteLast()  // running time O(1)
        {
            if (IsEmpty())
                throw new Exception("You can't delete from an empty list");
            else if (Head.Next == null)  // the list only has one node, the head node
            {
                Tail = null;
                Head = null;
            }
            else  // there are two or more nodes in the list
            {
                // move the Tail
                Tail = Tail.Previous;

                // delete the links to the previous tail
                Tail.Next.Previous = null;
                Tail.Next = null;
            }
        }

        public void DeleteValue(T valueToDelete)  // running time O(n)  
        // deletes the first value it finds that matches; won't delete all if the value appears more than once in the list
        {
            if (IsEmpty())
                throw new Exception("You can't delete from an empty list.");  // this crashes and lets the user know what's wrong
            else if (Head.Value.CompareTo(valueToDelete) == 0)   // need this at the beginning of the class for CompareTo() to work: class SinglyLinkedList<T> where T : IComparable 
                DeleteFirst();  // if it's the first value in the list use DeleteFirst()
            else
            {
                Node<T> pointer = Head;  // used for traversing the list
                // traverse and look ahead for valueToDelete; if it's not what we're looking for, move pointer; if it is, break the link and link past it
                // leave the loop either when the list ends or when you find the node to delete (if found, pointer will be pointing to the node before the one to delete)
                while ((pointer.Next != null) && (pointer.Next.Value.CompareTo(valueToDelete) != 0))
                    pointer = pointer.Next;

                if (pointer.Next == null)  // there wasn't a match and the end of the list was reached
                    Console.WriteLine($"{valueToDelete} wasn't found in the list so nothing was deleted.\n");
                else  // there was a match; link out the node containing valueToDelete (pointer is pointing to the node before the node contains valueToDelete)
                {
                    if (pointer.Next.Next == null)  // if the match is the last node in the list
                        pointer.Next = null;  // cut out the last node; could call DeleteLast() here but that gives the processor more work to do than the work in this line does
                    else
                    {
                        pointer.Next = pointer.Next.Next;
                        pointer.Next.Previous = pointer;
                    }
                }
            }
        }

        public void DeleteNode(Node<T> node)  // running time O(1)  
        {
            if (IsEmpty())
                throw new Exception("You can't delete from an empty list.");
            else if (node == Head)
                DeleteFirst();
            else if (node == Tail)
                DeleteLast();
            else
            {
                Node<T> n1 = node.Previous;
                Node<T> n2 = node.Next;

                n1.Next = n2;
                n2.Previous = n1;

                node.Previous = node.Next = null;
            }
        }

        public void Reverse()  // running time O(n)  
        {
            if (IsEmpty())
                throw new Exception("You can't reverse an empty list.");  // this crashes and lets the user know what's wrong
            else if (Head.Next == null)
                Console.WriteLine("The list only contains one node so there are no other nodes to reverse it with.");  // doesn't crash the program; displays this message to console instead
            else
            {
                Node<T> temp = null;  // temporary holder
                Node<T> pointer = Head;  // used for traversing the list

                // swap Next and Previous for all nodes
                while (pointer != null)  
                {
                    temp = pointer.Previous;
                    pointer.Previous = pointer.Next;
                    pointer.Next = temp;
                    pointer = pointer.Previous;
                }

                Head = temp.Previous;
            }
        }

        public bool IsEmpty()  // running time O(1)
        {
            return Head == null;  // if false (head points to null) the list is empty; returns true or false
        }

        public void Clear()  // running time O(n)
        {
            if (!IsEmpty())  // if the list is NOT empty
            {
                Node<T> pointer = Head.Next;  // start at the second node in the list

                // delete all previous links
                while (pointer != null)
                {
                    pointer.Previous = null;  // delete previous
                    pointer = pointer.Next;  // move right
                }

                Head = null;
                Tail = null;
            }
            else  // if the list is empty
                Console.WriteLine("The list is empty so there are no nodes to clear.");
        }

        public void Display()  // running time O(n)
        {
            if (IsEmpty())
                Console.WriteLine("The list is empty so there are no values to display.\n");
            else
            {
                Node<T> pointer = Head;  // point to the first node

                Console.Write("List contains: ");
                while (pointer != null)  // looping will stop when pointer points to null; pointer.Next will crash the program if pointer points to null
                {
                    Console.Write($"{pointer.Value}  ");  // display value
                    pointer = pointer.Next;  // move pointer to the right
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}