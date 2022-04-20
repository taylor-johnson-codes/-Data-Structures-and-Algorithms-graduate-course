using System;
using System.Collections.Generic;

namespace _4_12_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph<string> myGraph = new Graph<string>();
            myGraph.AddVertex("SEA");
            myGraph.AddVertex("LAX");
            myGraph.AddVertex("ORD");
            myGraph.AddVertex("PHX");
            myGraph.AddVertex("BAX");
            //myGraph.AddVertex("LAX");  // duplicate names allowed here
            // other options: can either not allow vertices to have the same name,
            // or add another property to give them unique ID numbers (e.g. zip code or random unique ID numbers)

            myGraph.AddEdge("LAX", "SEA");
            myGraph.AddEdge("LAX", "PHX");
            myGraph.AddEdge("SEA", "ORD");

            myGraph.Print();

            ////myGraph.RemoveEdge("LAX", "SEA");
            //myGraph.RemoveEdge("SEA", "LAX");
            //myGraph.Print();

            //myGraph.RemoveEdge("SEA", "ORD");
            //myGraph.Print();

            //myGraph.RemoveVertex("LAX");
            //myGraph.Print();

            myGraph.DepthFirstSearch();
        }
    }

    class Vertex<T>
    {
        // DATA
        public T Value { get; set; }
        public bool WasVisited { get; set; }  // needed for traversing the graph; default value for bool is false

        // CONSTRUCTOR
        public Vertex(T someValue)
        {
            Value = someValue;
        }
    }

    class Graph<T>
    {
        // Graph = (Vertex, Edge)
        // Vertex will be a list of vertices (like nodes)
        // Edge will be an adjacency list (list of linked lists)

        // DATA (initialized in constructor)
        public List<Vertex<T>> V { get; private set; }  // Vertex will be a list of vertices (like nodes) 
        public List<LinkedList<T>> E { get; private set; }  // Edge will be an adjacency list (list of linked lists)

        // CONSTRUCTOR
        public Graph()
        {
            // initialize DATA section
            V = new List<Vertex<T>>();
            E = new List<LinkedList<T>>();
        }

        // METHODS
        public void AddVertex(T newValue)
        {
            // create a new vertex
            Vertex<T> newVertex = new Vertex<T>(newValue);

            // add it to the list of vertices
            V.Add(newVertex);
        }

        public void AddEdge(T start, T end)
        {
            // validate that start and end are in the list of vertices
            if (!ContainVertex(start) || !ContainVertex(end))
                throw new Exception("Vertex not found");

            // undirected graph since edges go both ways
            AddDirectedEdge(start, end);
            AddDirectedEdge(end, start);
        }

        // used with AddEdge()
        public void AddDirectedEdge(T start, T end)  
        {
            // the vertices are valid (they exist in the list); validated in AddEdge method

            bool wasFound = false;
            for (int i = 0; i < E.Count; i++)  // can do this part in a separate method instead
            {
                // check if the linked list at position i contains start
                if (E[i].First.Value.Equals(start))  // compare start and first node in the linked list
                {
                    wasFound = true;
                    E[i].AddLast(end);
                    break;  // once found, break out of the loop
                }
            }

            if (!wasFound)
            {
                // if it doesn't, add a new linked list
                LinkedList<T> newList = new LinkedList<T>();
                newList.AddLast(start);
                newList.AddLast(end);
                E.Add(newList);
            }
        }

        // used with AddEdge()
        public bool ContainVertex(T vertexValue)  
        {
            foreach (var vertex in V)
                if (vertex.Value.Equals(vertexValue))
                    return true;  // found a match
            
            return false;  // match not found 
        }

        public void RemoveEdge(T start, T end)
        {
            RemoveEdgeDirected(start, end);
            RemoveEdgeDirected(end, start);
        }

        // used with RemoveEdge()
        public void RemoveEdgeDirected(T start, T end)
        {
            // search for the list whose head is start
            foreach (var list in E)
            {
                if (list.First.Value.Equals(start))
                {
                    list.Remove(end);
                    if (list.First.Next == null)  // or if list.Count == 1 then remove list
                        E.Remove(list);
                    break;
                }
            }
        }

        public void RemoveVertex(T start)
        {
            // remove the vertex from V - list of vertices
            for (int i = 0; i < V.Count; i++)
            {
                if (V[i].Value.Equals(start))
                {
                    V.RemoveAt(i);  // RemoveAt() removes the value at that position; Remove() removes a specific value at any position
                    break;
                }
            }

            // remove any edge that contains the vertex - remove from E
            for (int i = 0; i < E.Count; i++)
            {
                if (E[i].First.Value.Equals(start))  // remove the whole linked list that has start as list.First
                {
                    E.RemoveAt(i);  // or E.Remove(E[i]);
                    i--;  // to account for the next list moving up into the removed list's place
                }
                else  // remove start value from all other linked lists
                {
                    E[i].Remove(start);
                    if(E[i].Count == 1)
                    {
                        E.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        public void DepthFirstSearch() 
        {
            // traverse one component at a time
            foreach (var vertex in V)
                if (vertex.WasVisited == false)
                    DepthFirstSearchOneComponent(vertex);
        }

        // used with DepthFirstSearch()
        public void DepthFirstSearchOneComponent(Vertex<T> startVertex)  // one component at a time
        {
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();  // stack needed to go backwards

            Console.Write("A connected component: ");
            // visit all connected component graphs
            // visit the node
            Console.Write($"{startVertex.Value} ");
            startVertex.WasVisited = true;  // mark the node as visited
            stack.Push(startVertex);

            while (stack.Count > 0)
            {
                // look at the top of the stack
                Vertex<T> top = stack.Peek();

                // find an unvisited vertex adjacent to top
                Vertex<T> next = FindUnvisitedAdjacentVertex(top);

                if  (next != null)  // if found
                {
                    // visit the node
                    Console.Write($"{next.Value} ");
                    next.WasVisited = true;  // mark the node as visited
                    stack.Push(next);
                }
                else
                    stack.Pop();  // go backwards
            }
            Console.WriteLine();
        }

        // used with DepthFirstSearchOneComponent()
        public Vertex<T> FindUnvisitedAdjacentVertex(Vertex<T> vertex)
        {
            // search through the E adjacency list for the linked list that starts with v.Value
            foreach (var list in E)
            {
                if (list.First.Value.Equals(vertex.Value))  // this list will give you all the nodes adjacent to vertex
                {
                    // search for a node that wasn't visited
                    LinkedListNode<T> pointer = list.First.Next;  // start with the second node in the list
                    while (pointer != null)
                    {
                        Vertex<T> node = null;

                        // search the vertex that has the label pointer.Value
                        for (int i = 0; i < V.Count; i++)
                            if (V[i].Value.Equals(pointer.Value))
                                node = V[i];

                        if (node.WasVisited == false)
                            return node;  // found an unvisited vertex
                        else
                            pointer = pointer.Next;  // move to the next one
                    }
                    return null;  // don't need to go to the other lists
                }
            }
            return null;
        }

        public void Print()
        {
            // print list of vertices
            Console.Write("Vertices: ");
            foreach(var vertex in V)
                Console.Write($"{vertex.Value} ");
            Console.WriteLine();

            // print adjacency list
            Console.WriteLine("Adjacency list: ");
            foreach (var list in E)
            {
                Console.Write($"{list.First.Value} | ");
                // traverse the linked list; we need to start at the second value in the list
                LinkedListNode<T> pointer = list.First.Next;  // LinkedListNode<T> built-in library
                while (pointer != null)
                {
                    Console.Write($"{pointer.Value} ");
                    pointer = pointer.Next;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
