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
            // put break point here, run, in watch window put in myTree and can see how tree is structured

            myTree.PrintInOrder();

            Console.WriteLine($"Number of leaf nodes: {myTree.CountLeafNodes()}");

        }
    }

    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        //ctor
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
        // isempty; check the root, or if count is 0
        public bool isEmpty()
        {
            return root == null;
        }

        // max; go the right as much as possible with while loop until hit leaf (the end)
        public T Max()
        {
            if (isEmpty())
                throw new Exception("No values in an empty tree.");
            Node<T> pointer = root;  // start at the root
            while (pointer.Right != null)  // move right as long as there is one; if tree is empty, .Right will crash
                pointer = pointer.Right;
            return pointer.Value;  // return the right-most value
        }

        // min; go the left as much as possible with while loop until hit leaf (the end)


        // search; return null if not found, node reference if found
        public Node<T> Search(T valueToFind)
        {
            if (isEmpty())
                return null;  // the value is not in an empty list
            
            Node<T> pointer = root;
            
            while (pointer != null)
            {
                // compare
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

        // add new value; can return the new node instead of void
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
                Node<T> pointer = root;
                while (pointer != null)  //  while (true) works also and is more efficient b/c doesn't have to compare each time
                {
                    if (newValue.CompareTo(pointer.Value) <= 0)  // <= move left
                    {
                        // is there a left?
                        if (pointer.Left != null)  // if there is left
                            pointer = pointer.Left;  // move left
                        else // there is no left, add new node to left
                        {
                            pointer.Left = newNode;  // link the new node to the left
                            break;  // newNode is added to tree so break out of the while loop
                        }
                    }
                    else // > move right; there is no R add node to R
                    {
                        // is there a right?
                        if (pointer.Right != null)  // if there is right
                            pointer = pointer.Right;
                        else // there is no right add new node to R
                        {
                            pointer.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }


        // traversals
        // PREORDER (NLR)
        public void PreOrder(Node<T> currentNode)  // gets split into L and R method calls with recursion
        {
            if (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);  // N
                PreOrder(currentNode.Left);  // L
                PreOrder(currentNode.Right);  // R
            }
        }

        public void PrintPreOrder()
        {
            PreOrder(root);
        }

        // INORDER (LNR) - prints the tree values in order
        public void InOrder(Node<T> currentNode)  // gets split into L and R method calls with recursion
        {
            if (currentNode != null)
            {
                InOrder(currentNode.Left);  // L
                Console.WriteLine(currentNode.Value);  // N
                InOrder(currentNode.Right);  // R
            }
        }

        public void PrintInOrder()
        {
            InOrder(root);
        }

        // POSTORDER (LRN)
        public void PostOrder(Node<T> currentNode)  // gets split into L and R method calls with recursion
        {
            if (currentNode != null)
            {
                PostOrder(currentNode.Left);  // L
                PostOrder(currentNode.Right);  // R
                Console.WriteLine(currentNode.Value);  // N
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
            else if (currentNode.Left != null && currentNode.Right == null)  // found the root with no children
                return 1;
            else  // ask left side, ask right side, then add them up; do recursively 
                return CountLeafNodesHelper(currentNode.Left) + CountLeafNodesHelper(currentNode.Right);
        }

        // CONSTRUCTOR
    }
}
