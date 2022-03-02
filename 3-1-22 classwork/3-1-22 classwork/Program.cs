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

            /*
            DoublyLinkedList<int> myIntList = new DoublyLinkedList<int>();  // myIntList points to the newly created doubly linked list

            Console.WriteLine("Display() to show the new list is empty.");
            myIntList.Display();

            Console.Write($"IsEmpty() result: {myIntList.IsEmpty()}\n\n");

            Console.WriteLine("AddFirst() with 30, 20, 10.");
            myIntList.AddFirst(30);
            myIntList.AddFirst(20);  // will be added before 30
            myIntList.AddFirst(10);  // will be added before 20
            myIntList.Display();

            Console.Write($"IsEmpty() result: {myIntList.IsEmpty()}\n\n");

            Console.WriteLine("AddLast() with 40, 50, 60.");
            myIntList.AddLast(40);
            myIntList.AddLast(50);
            myIntList.AddLast(60);
            myIntList.Display();

            myIntList.Reverse();
            Console.WriteLine("Reversed list.");
            myIntList.Display();

            myIntList.Reverse();
            Console.WriteLine("Reversed list again.");
            myIntList.Display();

            myIntList.DeleteFirst();
            Console.WriteLine("Deleted the first node.");
            myIntList.Display();

            myIntList.DeleteLast();
            Console.WriteLine("Deleted the last node.");
            myIntList.Display();

            Console.WriteLine("Attempted to delete the value 500 from the list.");
            myIntList.DeleteValue(500);

            myIntList.DeleteValue(40);
            Console.WriteLine("Deleted 40 by value.");
            myIntList.Display();

            myIntList.DeleteNode(2);
            Console.WriteLine("Deleted the second node.");
            myIntList.Display();

            Console.WriteLine("Attempted to delete the 10th node from the list.");
            myIntList.DeleteNode(10);

            myIntList.Clear();
            Console.WriteLine("Cleared the list.");
            Console.Write($"IsEmpty() result: {myIntList.IsEmpty()}\n\n");


            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");


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

            myStrList.DeleteNode(2);
            Console.WriteLine("Deleted the second node.");
            myStrList.Display();

            Console.WriteLine("Attempted to delete the 10th node from the list.");
            myStrList.DeleteNode(10);

            myStrList.Clear();
            Console.WriteLine("Cleared the list.");
            Console.Write($"IsEmpty() result: {myStrList.IsEmpty()}\n\n");
            */


            // ---------------------------- STACK ---------------------------- //

            //MyStack<int> stack = new MyStack<int>();
            //stack.Push(10);
            //stack.Push(20);
            //stack.Push(30);
            //stack.Push(40);
            //Console.WriteLine(stack.Peek());  // displays 40

            //stack.Pop();
            //Console.WriteLine(stack.Peek());  // displays 30

            // C/P his code here


            // ---------------------------- QUEUE ---------------------------- //

            //MyQueue<string> queue = new MyQueue<string>();
            //queue.Enqueue("Saint");
            //queue.Enqueue("Martin");
            //queue.Enqueue("University");
            //Console.WriteLine(queue.Count);  // 3
            //Console.WriteLine(queue.Peek());  // what's first in line: Saint
            //Console.WriteLine(queue.Dequeue());  // Saint
            //Console.WriteLine(queue.Dequeue());  // Martin

            //queue.Enqueue("Lacey");
            //Console.WriteLine(queue.Dequeue());  // University


            // ---------------------------- STACK USING QUEUE ---------------------------- //

            //StackUsingQueue<int> stack2 = new StackUsingQueue<int>();
            //stack2.Push(10);
            //stack2.Push(20);
            //stack2.Push(30);
            //stack2.Push(40);
            //stack2.Push(50);
            //Console.WriteLine(stack2.Count2);  // 5
            //stack2.Peek();  // 50
            //stack2.Pop();  // 50
            //stack2.Pop();  // 40
            //Console.WriteLine(stack2.Count2);  // 3


            // ---------------------------- FOR EACH LOOP IN SLL ---------------------------- //
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();
            sll.AddFirst(10);
            sll.AddFirst(20);
            sll.AddFirst(30);
            sll.AddFirst(40);
            sll.AddFirst(50);

            foreach (int i in sll)
            {
                Console.WriteLine(i);
            }
        }
    }
}
