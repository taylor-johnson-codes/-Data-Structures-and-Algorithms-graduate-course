using System;

namespace MyLibrary
{
    internal class DoublyLinkedList<T> where T : IComparable  // for .CompareTo()
    {
        // DATA SECTION
        // initialized to point to null by default  
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        // METHOD(S) SECTION
        public void AddFirst(T newValue)  // works on empty list or populated list
        {
            ////my code:
            //// create a new node
            //Node<T> newNode = new Node<T>(newValue);

            //// link in the new node
            //newNode.Next = Head;  // newNode's forward pointer is now pointing to the first node in the linked list
            //newNode.Previous = null; // newNode's backward pointer points to null because the first node doesn't have an nodes before it

            //// move the Previous pointer
            //if (!IsEmpty())  // Head.Previous would crash the program if the list was empty
            //    Head.Previous = newNode;  // Head is now second in the list so Head.Previous points to newNode because that's the first in the list

            //// move the Head pointer
            //Head = newNode;  // now Head points to the first in the list

            //his codeL
            Node<T> newNode = new Node<T>(newValue);

            if (IsEmpty())
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                //link it in - as a first node
                newNode.Next = Head;
                Head.Previous = newNode;

                //change the head
                Head = newNode;
            }
        }

        public void AddLast(T newValue)
        {
            ////my code:
            //if (IsEmpty())
            //    AddFirst(newValue);  // if the list is empty, the AddLast() code in the else block won't work; AddFirst() will work
            //else
            //{
            //    Node<T> newNode = new Node<T>(newValue);  // create a new node contains newValue

            //    Node<T> lastNode = Head;  // used in the while loop to find the last node in the list
            //    while (lastNode.Next != null)  // stops at the last node to assign lastNode to the last node in the list
            //        lastNode = lastNode.Next;

            //    lastNode.Next = newNode;  // adding newNode to the end of the list; now lastNode represents the second to last node
            //    newNode.Next = null;  // there is nothing after the last node to point to
            //    newNode.Previous = lastNode;  // updates newNode's pointer to point to the second to last node
            //    Tail = newNode;  // updated Tail to point to the last node in the list
            //}

            //his code:
            Node<T> newNode = new Node<T>(newValue);

            if (IsEmpty())
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                //link it in - as a first node
                newNode.Previous = Tail;
                Tail.Next = newNode;

                //change the head
                Tail = newNode;
            }
        }

        public void DeleteFirst()  // this works in a list with only one element
        {
            ////mine:
            //if (IsEmpty())
            //    throw new Exception("You can't delete from an empty list.");  // this crashes and lets the user know what's wrong; if head points to null (list is empty), Head.Next will crash the code
            //else
            //    Head = Head.Next;  // moving Head to point to the second node in the list to cut off the first node
            //Head.Previous = null;  // there is nothing before the first node to point to

            //his:
            if (IsEmpty())
            {
                throw new Exception("You can't delete from an empty list");
            }
            else if (Head.Next == null)//you only have one node
            {
                Tail = null;
                Head = null;
            }
            else //you have at least two nodes
            {
                //move the head
                Head = Head.Next;

                //delete the links to the previous head
                Head.Previous.Next = null;
                Head.Previous = null;
            }
        }

        public void DeleteLast()
        {
            ////my code:
            //if (IsEmpty())
            //    throw new Exception("You can't delete from an empty list.");  // this crashes and lets the user know what's wrong; pointer.Next.Next will be invalid causing the crash
            //else if (Head.Next == null)  // list has one node
            //    DeleteFirst();  // if the list only has one node, the code in the else block won't work, but DeleteFirst() will work
            //else  // make second to last node point to null
            //{
            //    // traverse to the second to last node with pointer
            //    Node<T> pointer = Head;

            //    // look two steps ahead; if it's not null move the pointer; if it's null this is where to stop so pointer points to second to last node
            //    while (pointer.Next.Next != null)
            //        pointer = pointer.Next;

            //    // link the last node out (pointer points to second to last node here)
            //    pointer.Next = null;  // now the last node is cut off from the list
            //    Tail = pointer;  // now Tail points to the last node in the list
            //}

            //his code:
            if (IsEmpty())
            {
                throw new Exception("You can't delete from an empty list");
            }
            else if (Head.Next == null)//you only have one node
            {
                Tail = null;
                Head = null;
            }
            else //you have at least two nodes
            {
                //move the Tail
                Tail = Tail.Previous;

                //delete the links to the previous tail
                Tail.Next.Previous = null;
                Tail.Next = null;
            }
        }

        public void DeleteValue(T valueToDelete)  // deletes the first value it finds that matches; won't delete all if the value appears more than once in the list
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

        ////my method:
        //public void DeleteNode(int nodePlaceNumber)  // e.g. DeleteNode(2) deletes the second node in the list
        //{
        //    if (nodePlaceNumber < 1)
        //        throw new Exception("You must enter a positive integer for the node number.");
        //    else if (IsEmpty())
        //        throw new Exception("The list is empty; you can't delete from an empty list.");
        //    else if (Head.Next == null && nodePlaceNumber > 1)
        //        throw new Exception($"The list only contains one node, so {nodePlaceNumber} isn't a valid node number to delete.");
        //    else if (Head.Next == null && nodePlaceNumber == 1)
        //        DeleteFirst();
        //    else
        //    {
        //        Node<T> pointer = Head;  // used for traversing the list

        //        for (int i = 1; i < nodePlaceNumber; i++)  // start at the first node and stop so pointer points to nodePlaceNumber to delete
        //        {
        //            pointer = pointer.Next;
        //            if (pointer == null)
        //            {
        //                Console.WriteLine($"The list is less than {nodePlaceNumber} nodes long, so node {nodePlaceNumber} doesn't exist and cannot be deleted.\n");
        //                break;
        //            }
        //            DeleteValue(pointer.Value);  // deletes the node
        //        }
        //    }
        //}

        //his method:
        public void DeleteNode(Node<T> node)
        {
            if (IsEmpty())
                throw new Exception("You can't delete from an empty list");
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

        public void Reverse()
        {
            if (IsEmpty())
                throw new Exception("You can't reverse an empty list.");  // this crashes and lets the user know what's wrong
            else if (Head.Next == null)
                Console.WriteLine("The list only contains one node so there are no other nodes to reverse it with.");  // doesn't crash the program; displays this message to console instead
            else
            {
                Node<T> temp = null;  // temporary holder
                Node<T> pointer = Head;  // used for traversing the list

                while (pointer != null)  // swap Next and Previous for all nodes
                // I got the while block code and the next line after it online; it produces the correct result, but I'm having a hard time trying to explain how it works
                {
                    temp = pointer.Previous;
                    pointer.Previous = pointer.Next;
                    pointer.Next = temp;
                    pointer = pointer.Previous;
                }

                Head = temp.Previous;
            }
        }

        public bool IsEmpty()
        {
            return Head == null;  // if false (head points to null) the list is empty; returns true or false
        }

        public void Clear()
        {
            //my code:
            //if (IsEmpty())
            //    Console.WriteLine("The list is already empty so there are no nodes to clear.");  // doesn't crash the program; displays this message to console instead
            //else
            //{
            //    Node<T> temp = null;  // temporary holder
            //    while (Head != null)  // deletes nodes one-by-one; results in nothing pointing to the nodes so the garbage collector will delete the nodes from memory
            //    {
            //        temp = Head;
            //        Head = Head.Next;
            //        temp = null;
            //    }
            //}

            //his code:
            if (!IsEmpty())
            {
                Node<T> finger = Head.Next;

                //"delete" all PREV links
                while (finger != null)
                {
                    //delete prev
                    finger.Previous = null;

                    //move right
                    finger = finger.Next;
                }

                //head -> null
                Head = null;
                Tail = null;
            }
        }

        public void Display()
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