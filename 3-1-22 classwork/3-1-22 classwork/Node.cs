using System;

namespace MyLibrary
{
    internal class Node<T>
    {
        // DATA SECTION
        // prop+tab+tab shortcut; property names are capitalized
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        // METHOD(S) SECTION

        // CONSTRUCTOR(S) SECTION
        public Node(T newValue)
        {
            Value = newValue;
        }
    }
}
