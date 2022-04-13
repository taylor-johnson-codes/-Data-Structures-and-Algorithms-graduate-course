using System;
using System.Collections.Generic;

namespace _4_12_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // GRAPHS

            Graph<string> myGraph = new Graph<string>();
            myGraph.AddVertex("SEA");
            myGraph.AddVertex("LAX");
            myGraph.AddVertex("ORD");
            myGraph.AddVertex("PHX");
            myGraph.AddVertex("LAX");  // duplicate names allowed here
            // other options: can either not allow vertices to have the same name,
            // or add another property to give them unique ID numbers (e.g. zip code or random unique ID numbers)

            myGraph.AddEdge("LAX", "SEA");
            myGraph.AddEdge("LAX", "PHX");



        }
    }

    class Vertex<T>
    {
        public T Value { get; set; }

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

            AddDirectedEdge(start, end);
            AddDirectedEdge(end, start);
        }

        public void AddDirectedEdge(T start, T end)  // for AddEdge method
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

        public bool ContainVertex(T vertexValue)  // for AddEdge method
        {
            foreach (var vertex in V)
                if (vertex.Value.Equals(vertexValue))
                    return true;  // found a match
            
            return false;  // match not found 
        }

        // RemoveEdge



        // RemoveVertex


        // CONSTRUCTOR
        public Graph()
        {
            // initialize DATA section
            V = new List<Vertex<T>>();
            E = new List<LinkedList<T>>();
        }
    }
}
