using System;
using System.Collections.Generic;

namespace _4_5_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //UniqueList<int> list = new UniqueList<int>();
            //list.Add(1);
            //list.Add(1);
            //list.Add(2);
            //list.Add(2);
            //list.Add(3);
            //list.Add(3);

            //foreach (var item in list)
            //    Console.WriteLine($"{item }");

            UniqueList<Student> roster = new UniqueList<Student>();

            // these are not equal/unique because they are two different objects
            roster.Add(new Student() { FirstName="Taylor", LastName="Johnson", Major="CS", GPA=4.0});
            roster.Add(new Student() { FirstName="Taylor", LastName="Johnson", Major="CS", GPA=4.0});

            foreach (var item in roster)
                Console.WriteLine($"{item }");

        }
    }

    // create a generic class that will only add unique values to the list
    class UniqueList<T> : List<T>  // gives UniqueList all the properties/methods of List; inheriting List class
    { 
        new public void Add(T newValue)  // new means it's hiding Add from List class
        {
            if(!this.Contains(newValue))  // this is current object
                base.Add(newValue);  // base instead of this to use base class/List class; like super in Java
        }
    }

    class SortedList<T> : List<T>
    {
        new public void Add(T newValue)
        {
            base.Add(newValue);  // base instead of this to use base class/List class; like super in Java
            Sort();
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }

        // override tostring method
        public override string ToString()
        {
            return $"{FirstName} {LastName} {Major} {GPA}";  // see his code
        }
    }
}
