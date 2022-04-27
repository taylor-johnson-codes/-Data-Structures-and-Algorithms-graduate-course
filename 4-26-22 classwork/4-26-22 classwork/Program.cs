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

            Console.WriteLine("hi");
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
        private const int NegativeInfinity = int.MinValue;
        private const int PositiveInfinity = int.MaxValue;

        // highest level:
        private int HeightOfSkipList = 0;

        // random outcome generator: true is considered "heads"; false is considered "tails"
        // if true, increase height of skip list
        public Random random = new Random();

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
        public Node Search(int searchValue)
        {
            // start the search at the head node (top left node)
            Node pointer = Head;

            // search path: across, below, across, below, repeat until searchValue is found,
            // or until the search gets to level 0 and finds the greatest value closest to searchValue, but not greater than searchValue
            while (pointer.Below != null)  // while not on level 0
            {
                // go down a level
                pointer = pointer.Below;  

                // search across the level
                while (searchValue >= pointer.Next.Value)  // while the searchValue is >= to the pointer's value, keep searching across (move right)
                    pointer = pointer.Next; 
            }

            return pointer;  // returns either node storing searchValue, or the greatest value closest to searchValue, but not greater than searchValue
        }

        public Node Insert(int insertValue)
        {
            Node position = Search(insertValue);  // where to insert the new node
            Node arbitraryNode;  // used in do-while loop 

            int level = -1;  // will get set to 0 in do-while loop
            int numberOfHeads = -1;  // will get set to 0 in do-while loop

            // if searchValue already exists in the skip list, you can't insert it
            if (position.Value == insertValue)
                return position;

            // random.nextBoolean() in Java doesn't have a direct C# translation
            // used the info here to make the translation: https://www.loekvandenouweland.com/content/random-boolean-in-csharp.html
            bool randomBool = random.Next(2) == 1;  // 0 = false, 1 = true

            // if searchValue doesn't exist in the skip list
            do  // always done at least once
            {
                // for the initial "do", these two variables get set to 0
                numberOfHeads++;
                level++;

                CanIncreaseLevel(level);

                arbitraryNode = position;

                // ready to insert newNode
                while (position.Above == null)
                    position = position.Previous;

                position = position.Above;

                arbitraryNode = InsertAfterAbove(position, arbitraryNode, insertValue);

            } while (randomBool == true);

            return arbitraryNode;
        }

        // used with Insert()
        private void CanIncreaseLevel(int incomingLevel)
        {
            if (incomingLevel >= HeightOfSkipList)
            {
                HeightOfSkipList++;
                AddEmptyLevel();
            }
        }

        // used with CanIncreaseLevel()
        private void AddEmptyLevel()
        {
            // new level contains head and tail nodes
            Node newHeadNode = new Node(NegativeInfinity);
            Node newTailNode = new Node(PositiveInfinity);

            // * refers to updating existing head node to newHeadNode and existing tail node to newTailNode 
            newHeadNode.Next = newTailNode;
            newHeadNode.Below = Head;  // *
            newTailNode.Previous = newHeadNode;
            newTailNode.Below = Tail;  // *

            Head.Above = newHeadNode;  // *
            Tail.Above = newTailNode;  // *

            Head = newHeadNode;  // *
            Tail = newTailNode;  // *
        }

        // used with Insert()
        private Node InsertAfterAbove(Node position, Node arbitraryNode, int insertValue)
        {
            Node newNode = new Node(insertValue);
            Node nodeBeforeNewNode = position.Below.Below;

            // update references
            PreviousAndNextReferences(arbitraryNode, newNode);
            AboveAndBelowReferences(position, insertValue, newNode, nodeBeforeNewNode);

            return newNode;
        }

        // used with InsertAfterAbove()
        private void PreviousAndNextReferences(Node arbitraryNode, Node newNode) 
        {
            newNode.Next = arbitraryNode.Next;
            newNode.Previous = arbitraryNode;
            arbitraryNode.Next.Previous = newNode;
            arbitraryNode.Next = newNode;
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
                        nodeBeforeNewNode = nodeBeforeNewNode.Next;  // keep moving right
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
            // need to find the node to be able to remove the node
            Node nodeToBeRemoved = Search(valueToRemove);

            // node not found
            if (nodeToBeRemoved.Value != valueToRemove)
            {
                Console.WriteLine($"No node containing the value {valueToRemove} was found, so no node was removed.");
                return null;
            }

            RemoveReferences(nodeToBeRemoved);

            // node found
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
            // obtain Next and Previous references to the node that will be removed
            Node afterNodeToBeRemoved = nodeToBeRemoved.Next;
            Node beforeNodeToBeRemoved = nodeToBeRemoved.Previous;

            // update references
            beforeNodeToBeRemoved.Next = afterNodeToBeRemoved;
            afterNodeToBeRemoved.Previous = beforeNodeToBeRemoved;
        }

        public void PrintSkipList()
        {
            StringBuilder mySkipList = new StringBuilder();
            mySkipList.Append("\nSkip List starting with top-left node:\n");

            Node starting = Head;

            Node highestLevel = starting;
            int level = HeightOfSkipList;

            while (highestLevel != null)
            {
                mySkipList.Append($"\nLevel: {level}\n");

                while (starting != null)
                {
                    mySkipList.Append(starting.Value);

                    if (starting.Next != null)
                        mySkipList.Append(" : ");

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
