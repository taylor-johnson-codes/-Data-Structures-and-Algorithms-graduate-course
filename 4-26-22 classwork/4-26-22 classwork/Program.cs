using System;
using System.Text;  // for StringBuilder in print method

namespace _4_26_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // SKIP LIST
            // translated Java code to C# while following this video: https://www.youtube.com/watch?v=Fsw6J8I6X7o

            SkipList skipList = new SkipList(); 
            Console.WriteLine("New skip list created.");

            skipList.Insert(10);
            skipList.Insert(20);
            skipList.Insert(30);
            skipList.Insert(40);
            skipList.Insert(50);
            skipList.Insert(10);

            skipList.PrintSkipList();
            Console.WriteLine();

            skipList.Remove(123);
            Console.WriteLine();

            skipList.Remove(30);
            Console.WriteLine("Removed 30.");

            skipList.PrintSkipList();
        }
    }

    public class Node  // built to store integer values
    {
        // DATA SECTION
        public Node Above { get; set; }
        public Node Below { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public int Value { get; set; }

        // CONSTRUCTOR SECTION
        public Node(int incomingValue)
        {
            Value = incomingValue;
            this.Above = null;
            this.Below = null;
            this.Next = null;
            this.Previous = null;
        }
    }

    public class SkipList
    {
        // DATA SECTION 
        // sentinel nodes: head is positive infinity; tail is negative infinity
        public Node Head { get; set; }
        public Node Tail { get; set; }

        private const int NegativeInfinity = int.MinValue;  // for the head node
        private const int PositiveInfinity = int.MaxValue;  // for the tail node

        private int HeightOfSkipList = 0;

        public Random random = new Random();  // used in Insert() as a coin flip

        // CONSTRUCTOR SECTION
        public SkipList()
        {
            // create a brand new skip list by creating the first level (level 0) with a head and tail
            Head = new Node(NegativeInfinity);
            Tail = new Node(PositiveInfinity);
            Head.Next = Tail;
            Tail.Previous = Head;
        }

        // METHODS SECTION

        /* Big-Oh time complexity for Search(), Insert(), and Remove(): 
         * Expected performance: O(log n)
         * Worst case: O(n)
         * 
         * Skip Lists allow intermediate nodes in the list to be "skipped" during a traversal resulting in an expected performance of O(log n) per operation. 
         * It is possible for the time to be substantially larger if the configuration of node levels is unfavorable for a particular operation. 
         * Since the node sizes are generated randomly, it is possible to get a "bad" run of sizes. 
         * For example, it is possible that each node will be generated at the same size, producing the equivalent of an ordinary sorted list. 
         * A bad run of sizes will result in longer-than expected search (and therefore insert or remove) times; the SkipList will simply not be as efficient as expected. 
         * Reference: https://www.csee.umbc.edu/courses/undergraduate/341/fall01/Lectures/SkipLists/skip_lists/skip_lists.html
        */

        public Node Search(int searchValue)
        {
            // start the search at the head node (top left node)
            Node pointer = Head;

            // search path: across, below, across, below, repeat until searchValue is found, or
            // until the search gets to level 0 and finds the greatest value closest to searchValue, but not greater than searchValue
            while (pointer.Below != null)
            {
                // go down a level (top level is just the head and the tail nodes)
                pointer = pointer.Below;  

                // search across the level
                while (searchValue >= pointer.Next.Value)
                    pointer = pointer.Next; 
            }

            return pointer;  
            // returns either the node storing searchValue, or
            // the node storing the greatest value closest to searchValue, but not greater than searchValue
        }

        public Node Insert(int insertValue)
        {
            Node position = Search(insertValue);  // where to insert the new node

            // if searchValue already exists in the skip list
            if (position.Value == insertValue)
            {
                Console.WriteLine($"{insertValue} is already in the skip list; it can't be added again.");
                return position;
            }

            // if searchValue doesn't exist in the skip list, add it and keep increasing its tower (numberOfHeads) until the coin flip is false

            // these variables will get set to 0 in the do-while loop
            int level = -1;  
            int numberOfHeads = -1; 
            int coinFlipCount = -1; 

            Node tempNode;  // used in the do-while loop 

            do  // always done at least once
            {
                // for the initial "do", these two variables get set to 0
                level++;
                numberOfHeads++;
                coinFlipCount++;

                IncreaseLevelCheck(level);

                tempNode = position;

                while (position.Above == null)
                    position = position.Previous;

                position = position.Above;

                tempNode = InsertAfterAbove(position, tempNode, insertValue);

            } while (random.Next(2) == 1);  // 0 = false, 1 = true, 2 is excluded
            // random.nextBoolean() in Java doesn't have a direct C# translation
            // used the info here to make the random.Next(2) translation: https://www.loekvandenouweland.com/content/random-boolean-in-csharp.html

            Console.WriteLine($"The value {insertValue} is at level {level}. Coin was flipped {coinFlipCount} time(s).");
            return tempNode;
        }

        // used with Insert()
        private void IncreaseLevelCheck(int incomingLevel)
        {
            if (incomingLevel >= HeightOfSkipList)
            {
                HeightOfSkipList++;
                AddEmptyLevel();
            }
        }

        // used with IncreaseLevelCheck()
        private void AddEmptyLevel()
        {
            // new level contains head and tail nodes
            Node newHeadNode = new Node(NegativeInfinity);
            Node newTailNode = new Node(PositiveInfinity);

            // update references
            newHeadNode.Next = newTailNode;
            newHeadNode.Below = Head;  
            newTailNode.Previous = newHeadNode;
            newTailNode.Below = Tail;  

            Head.Above = newHeadNode;  
            Tail.Above = newTailNode;  

            Head = newHeadNode; 
            Tail = newTailNode; 
        }

        // used with Insert()
        private Node InsertAfterAbove(Node position, Node tempNode, int insertValue)
        {
            Node newNode = new Node(insertValue);
            Node nodeBeforeNewNode = position.Below.Below;

            // update references
            PreviousAndNextReferences(tempNode, newNode);
            AboveAndBelowReferences(position, insertValue, newNode, nodeBeforeNewNode);

            return newNode;
        }

        // used with InsertAfterAbove()
        private void PreviousAndNextReferences(Node tempNode, Node newNode) 
        {
            newNode.Next = tempNode.Next;
            newNode.Previous = tempNode;
            tempNode.Next.Previous = newNode;
            tempNode.Next = newNode;
        }

        // used with InsertAfterAbove()
        private void AboveAndBelowReferences(Node position, int insertValue, Node newNode, Node nodeBeforeNewNode)
        {
            // position is the level above the new node we're inserting
            // nodeBeforeNewNode is the level below the new node we're inserting

            if (nodeBeforeNewNode != null)
            {
                while (true)
                {
                    if (nodeBeforeNewNode.Next.Value != insertValue)
                        nodeBeforeNewNode = nodeBeforeNewNode.Next;
                    else
                        break;
                }

                newNode.Below = nodeBeforeNewNode.Next;
                nodeBeforeNewNode.Next.Above = newNode;
            }

            if (position != null)
                if (position.Next.Value == insertValue) 
                    newNode.Above = position.Next;
        }

        public Node Remove(int valueToRemove)
        {
            // to be able to remove the node, we need to find it first
            Node nodeToBeRemoved = Search(valueToRemove);

            // node not found
            if (nodeToBeRemoved.Value != valueToRemove)
            {
                Console.WriteLine($"No node containing the value {valueToRemove} was found, so no node was removed.");
                return null;
            }

            // node found
            RemoveReferences(nodeToBeRemoved);

            while (nodeToBeRemoved != null)
            {
                RemoveReferences(nodeToBeRemoved);

                if (nodeToBeRemoved.Above != null)
                    nodeToBeRemoved = nodeToBeRemoved.Above;
                else
                    break;
            }

            return nodeToBeRemoved;
        }

        // used with Remove()
        private void RemoveReferences(Node nodeToBeRemoved)
        {
            // obtain Next and Previous references to nodeToBeRemoved
            Node afterNodeToBeRemoved = nodeToBeRemoved.Next;
            Node beforeNodeToBeRemoved = nodeToBeRemoved.Previous;

            // update references
            beforeNodeToBeRemoved.Next = afterNodeToBeRemoved;
            afterNodeToBeRemoved.Previous = beforeNodeToBeRemoved;
        }

        public void PrintSkipList()
        {
            StringBuilder mySkipList = new StringBuilder();
            mySkipList.Append("\nSkip list starting with top-left node:");

            Node starting = Head;

            Node highestLevel = starting;
            int level = HeightOfSkipList;

            while (highestLevel != null)
            {
                mySkipList.Append($"\nLevel {level} contains ");

                while (starting != null)
                {
                    mySkipList.Append(starting.Value);

                    if (starting.Next != null)
                        mySkipList.Append(" | ");

                    starting = starting.Next;
                }

                highestLevel = highestLevel.Below;
                starting = highestLevel;
                level--;
            }

            Console.WriteLine(mySkipList.ToString());
        }
    }
}
