using System;
using MyLibrary;

namespace _3_1_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ---------------------------- Singly Linked List ---------------------------- //

            //Node<int> myNode = new Node<int>();  // new node with an empty value if the constructor doesn't require a parameter

            //Node<int> nodeNET5example = new(1);  // this works in .NET 5.x but not in older versions like .NET 3.x

            /*
            // node values can be any data type
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

            /*
            SinglyLinkedList<int> myList = new SinglyLinkedList<int>();
            myList.Display();
            myList.AddFirst(10);
            myList.AddFirst(20);  // will be added before 10
            myList.AddFirst(30);  // will be added before 20

            myList.AddLast(500);
            myList.AddLast(600);
            myList.AddLast(700);
            myList.Display();

            myList.DeleteValue(500);
            myList.Display();
            */


            // ---------------------------- Doubly Linked List ---------------------------- //

            
            DoublyLinkedList<string> myStrList = new DoublyLinkedList<string>();  // myStrList points to the newly created doubly linked list

            Console.WriteLine("Display() to show the new list is empty.");
            myStrList.Display();

            Console.Write($"IsEmpty() result: {myStrList.IsEmpty()}\n\n");

            Console.WriteLine("AddFirst() with Y, A, T.");
            myStrList.AddFirst("Y");
            myStrList.AddFirst("A");  // will be added before Y
            myStrList.AddFirst("T");  // will be added before A
            myStrList.Display();

            Console.Write($"IsEmpty() result: {myStrList.IsEmpty()}\n\n");

            Console.WriteLine("AddLast() with L, O, R.");
            myStrList.AddLast("L");
            myStrList.AddLast("O");
            myStrList.AddLast("R");
            myStrList.Display();

            myStrList.Reverse();
            Console.WriteLine("Reversed list.");
            myStrList.Display();

            myStrList.Reverse();
            Console.WriteLine("Reversed list again.");
            myStrList.Display();

            myStrList.DeleteFirst();
            Console.WriteLine("Deleted the first node.");
            myStrList.Display();

            myStrList.DeleteLast();
            Console.WriteLine("Deleted the last node.");
            myStrList.Display();

            Console.WriteLine("Attempted to delete the value Z from the list.");
            myStrList.DeleteValue("Z");

            myStrList.DeleteValue("L");
            Console.WriteLine("Deleted L by value.");
            myStrList.Display();

            //myStrList.DeleteNode(2);
            //Console.WriteLine("Deleted the second node.");
            //myStrList.Display();

            //Console.WriteLine("Attempted to delete the 10th node from the list.");
            //myStrList.DeleteNode(10);

            myStrList.Clear();
            Console.WriteLine("Cleared the list.");
            Console.Write($"IsEmpty() result: {myStrList.IsEmpty()}\n\n");


            // ---------------------------- STACK ---------------------------- //

            // A stack is FILO or LIFO; like a stack of plates or the browser's back button

            //MyStack<int> stack = new MyStack<int>();
            //stack.Push(10);
            //stack.Push(20);
            //stack.Push(30);
            //stack.Push(40);
            //stack.Display();
            //Console.Write($"Peek: {stack.Peek()}\n");  // 40
            //stack.Pop();
            //Console.Write("Popped last value; ");
            //stack.Display();
            //Console.Write($"Peek: {stack.Peek()}\n");  // 30
            //Console.WriteLine($"Count is: {stack.CountStack}");  // 3
            ////Console.WriteLine(stack.Pop());  // 30
            ////Console.WriteLine(stack.Pop());  // 20
            ////Console.WriteLine(stack.Pop());  // 10
            ////Console.WriteLine(stack.Pop());  // throws exception
            //stack.Clear();
            //Console.WriteLine("Cleared the list.");
            //stack.Display();


            // ---------------------------- QUEUE ---------------------------- //

            // A queue is FIFO or LILO; like standing in line or printing documents

            //MyQueue<string> queue = new MyQueue<string>();
            //queue.Enqueue("Saint");
            //queue.Enqueue("Martin");
            //queue.Enqueue("University");
            //queue.Display();
            //Console.WriteLine($"Count is: {queue.CountQueue}");  // 3
            //Console.WriteLine($"Peek: {queue.Peek()}\n");  // what's first in line: Saint
            //Console.WriteLine(queue.Dequeue());  // Saint
            //Console.WriteLine(queue.Dequeue());  // Martin
            //Console.WriteLine("Dequeued twice.");
            //queue.Display();
            //queue.Enqueue("Lacey");
            //Console.WriteLine("Enqueued Lacey.");
            //queue.Display();
            //Console.WriteLine(queue.Dequeue());  // University
            //Console.WriteLine("Dequeued once.");
            //queue.Display();
            //queue.Clear();
            //Console.WriteLine("Cleared the list.");
            //queue.Display();


            // ---------------------------- STACK USING QUEUE ---------------------------- //

            //StackUsingQueue<int> stack2 = new StackUsingQueue<int>();
            //stack2.Push(10);
            //stack2.Push(20);
            //stack2.Push(30);
            //stack2.Push(40);
            //stack2.Push(50);
            //stack2.Display();
            //Console.WriteLine($"Count is: {stack2.CountSUQ}");  // 5
            //Console.WriteLine($"Peek: {stack2.Peek()}\n");  // 50
            //stack2.Pop();  // 50
            //stack2.Pop();  // 40
            //Console.WriteLine("Popped twice.");
            //stack2.Display();
            //Console.WriteLine($"Count is: {stack2.CountSUQ}");  // 3
            //stack2.Clear();
            //Console.WriteLine("Cleared the list.");
            //stack2.Display();


            // ---------------------------- FOR EACH LOOP IN SLL ---------------------------- //

            //SinglyLinkedList<int> sll = new SinglyLinkedList<int>();
            //sll.AddFirst(10);
            //sll.AddFirst(20);
            //sll.AddFirst(30);
            //sll.AddFirst(40);
            //sll.AddFirst(50);

            //// the last two IEnumerator methods in the SLL class allow for the foreach loop to work
            //foreach (int value in sll)
            //    Console.Write($"{value}  ");
        }
    }
}
