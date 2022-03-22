using System;

namespace _3_15_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BST<int> myTree = new BST<int>();
            myTree.Add(12);
            myTree.Add(5);
            myTree.Add(22);
            myTree.Add(3);
            myTree.Add(18);
            myTree.Add(12);
            // put break point here, run, in watch window put in myTree and see how tree is structured

            Console.Write("PreOrder values: ");
            myTree.PrintPreOrder();
            Console.WriteLine();

            Console.Write("InOrder values: ");
            myTree.PrintInOrder();
            Console.WriteLine();

            Console.Write("PostOrder values: ");
            myTree.PrintPostOrder();
            Console.WriteLine();

            Console.WriteLine($"Min value: {myTree.Min()}");
            Console.WriteLine($"Max value: {myTree.Max()}");

            Console.WriteLine($"Number of leaf nodes: {myTree.CountLeafNodes()}");

        }
    }

    class Node<T>
    {
        // DATA
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        // CONSTRUCTOR
        public Node(T newValue)
        {
            Value = newValue;
        }
    }

    class BST<T> where T : IComparable  // to compare values
    {
        // DATA
        // only stores the root and everything else is based off the root
        public Node<T> root { get; private set; }
        public int Count { get; private set; }  // number of nodes in the tree

        // METHODS
        
        public bool isEmpty()
        {
            // can check if the root is empty, or check if count is 0
            return root == null;  // returns true or false
        }

        // max: go the right as much as possible with while loop until leaf is hit (the end of the branch)
        public T Max()
        {
            if (isEmpty())  // if tree is empty, pointer.Right will crash the program
                throw new Exception("No max value in an empty tree.");
            Node<T> pointer = root;  // start at the root
            while (pointer.Right != null)  // move right as long as there is a next node
                pointer = pointer.Right;
            return pointer.Value;  // return the right-most value
        }

        // min: go the left as much as possible with while loop until leaf is hit (the end of the branch)
        public T Min()
        {
            if (isEmpty())  // if tree is empty, pointer.Left will crash the program
                throw new Exception("No min value in an empty tree.");
            Node<T> pointer = root;  // start at the root
            while (pointer.Left != null)  // move left as long as there is a next node
                pointer = pointer.Left;
            return pointer.Value;  // return the left-most value
        }

        // search: return null if not found, return node reference if found
        public Node<T> Search(T valueToFind)
        {
            if (isEmpty())
                return null;  // the value is not in an empty list
            Node<T> pointer = root;  // start at the root
            while (pointer != null)  // while there are still nodes to search
            {
                // compare the value of the pointer to valueToFind
                // CompareTo results: -1 if pointer.Value is smaller, 0 if there's a match, 1 if pointer.Value is larger
                if (pointer.Value.CompareTo(valueToFind) == 0)
                    return pointer;  // value was found
                else if (valueToFind.CompareTo(pointer.Value) < 0)
                    pointer = pointer.Left;  // move left
                else
                    pointer = pointer.Right;  // move right
            }
            // you get here when pointer == null
            return null;  // couldn't find value in tree
        }

        // add new value (can return the new node instead of void)
        public void Add(T newValue)
        {
            // create a new node
            Node<T> newNode = new Node<T>(newValue);
            Count++;

            // link in the new node to the tree
            if (isEmpty())
                root = newNode;
            else
            {
                // traverse to the point where to link the new node to the tree
                Node<T> pointer = root;  // start at the root
                // while (true) works also and is more efficient because the program doesn't have to compare each time
                // (just make sure there are breaks/exceptions throughout so it's not an infinite loop)
                while (pointer != null)  // while there are still nodes in the tree
                {
                    // CompareTo results: -1 if newValue is smaller, 0 if there's a match, 1 if newValue is larger
                    if (newValue.CompareTo(pointer.Value) <= 0)  // <= move left
                    {
                        // is there a left node?
                        if (pointer.Left != null)  // if there is a left node
                            pointer = pointer.Left;  // move left
                        else // there is no left node, add newNode to left
                        {
                            pointer.Left = newNode;  // link in newNode
                            break;  // newNode is added to tree so break out of the while loop
                        }
                    }
                    else // > move right; there is no R add node to R
                    {
                        // is there a right node?
                        if (pointer.Right != null)  // if there is a right node
                            pointer = pointer.Right;  // move right
                        else // there is no right node, add newNode to right
                        {
                            pointer.Right = newNode;  // link in newNode
                            break;  // newNode is added to tree so break out of the while loop
                        }
                    }
                }
            }
        }

        // PREORDER TRAVERSAL (Node Left Right)
        // gets split into L and R method calls with recursion
        public void PreOrder(Node<T> currentNode)  
        {
            if (currentNode != null)
            {
                Console.Write($"{currentNode.Value} ");  // Node
                PreOrder(currentNode.Left);  // Left
                PreOrder(currentNode.Right);  // Right
            }
        }

        public void PrintPreOrder()
        {
            PreOrder(root);
        }

        // INORDER TRAVERSAL (Left Node Right) - prints the tree values in order from smallest to largest
        // gets split into L and R method calls with recursion
        public void InOrder(Node<T> currentNode)
        {
            if (currentNode != null)
            {
                InOrder(currentNode.Left);  // Left
                Console.Write($"{currentNode.Value} ");  // Node
                InOrder(currentNode.Right);  // Right
            }
        }

        public void PrintInOrder()
        {
            InOrder(root);
        }

        // POSTORDER TRAVERSAL (Left Right Node)
        // gets split into L and R method calls with recursion
        public void PostOrder(Node<T> currentNode)
        {
            if (currentNode != null)
            {
                PostOrder(currentNode.Left);  // Left
                PostOrder(currentNode.Right);  // Right
                Console.Write($"{currentNode.Value} ");  // Node
            }
        }

        public void PrintPostOrder()
        {
            PostOrder(root);
        }

        // find sum of leaf nodes
        public int CountLeafNodes()
        {
            return CountLeafNodesHelper(root);
        }

        public int CountLeafNodesHelper(Node<T> currentNode)
        {
            if (currentNode == null)
                return 0;  // there are no leaves in an empty tree
            else if (currentNode.Left == null && currentNode.Right == null)  // found the root with no children; only one node in tree
                return 1;
            else  // ask left side, ask right side, add them up; do recursively 
                return CountLeafNodesHelper(currentNode.Left) + CountLeafNodesHelper(currentNode.Right);
        }
    }
}
