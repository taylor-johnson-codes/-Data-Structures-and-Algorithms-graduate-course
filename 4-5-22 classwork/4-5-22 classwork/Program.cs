using System;
using System.Collections.Generic;

namespace _4_5_22_classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Static vs non-static:
            // ClassName.StaticMembers;

            // ClassName Obj = new ClassName();
            // Obj.NonStaticMembers;

            ////UniqueList<int> myList = new UniqueList<int>();
            //SortedList<int> myList = new SortedList<int>();
            //myList.Add(5);
            //myList.Add(3);
            //myList.Add(1);
            //myList.Add(5);
            //myList.Add(2);
            //myList.Add(3);
            //myList.Add(3);
            //myList.Add(3);
            //myList.Add(3);
            //myList.Add(3);
            //myList.Add(3);
            //myList.Add(3);

            //foreach (var item in myList)
            //    Console.WriteLine($"{item} ");

            //UniqueList<Student> roster = new UniqueList<Student>();
            SortedList<Student> roster = new SortedList<Student>();

            // the first two are not equal (they are different) because they are two different objects
            roster.Add(new Student() { FirstName="Taylor", LastName="Johnson", Major="CS", GPA=4.0});
            roster.Add(new Student() { FirstName="Taylor", LastName="Johnson", Major="CS", GPA=4.0});

            roster.Add(new Student() { FirstName = "Alex", LastName = "Mezei", GPA = 2.0, Major = "CS" });
            roster.Add(new Student() { FirstName = "Xuguang", LastName = "Chen", GPA = 3.0, Major = "IT" });
            roster.Add(new Student() { FirstName = "Richard", LastName = "Beer", GPA = 3.3, Major = "Business" });
            roster.Add(new Student() { FirstName = "Bob", LastName = "Mezei", GPA = 3.9, Major = "Cybersecurity" });
            roster.Add(new Student() { FirstName = "Alex", LastName = "Mezei", GPA = 4.0, Major = "Cybersecurity" });

            foreach (var item in roster)
                Console.WriteLine($"{item} ");
        }
    }

    // create a generic class that will only add unique values to the list
    class UniqueList<T> : List<T>  // gives UniqueList all the properties/methods of List; inheriting List class
    { 
        new public void Add(T newValue)  // "new" means it's hiding Add from List class
        {
            if(!this.Contains(newValue))  // "this" is current object
                base.Add(newValue);  // "base" instead of "this" to use base class/List class; like super in Java
        }
    }

    class SortedList<T> : List<T>
    {
        new public void Add(T newValue)
        {
            base.Add(newValue);  // "base" instead of "this" to use base class/List class; like super in Java
            Sort();
        }
    }

    public class Student : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }

        // override ToString method
        public override string ToString()
        {
            return $"{FirstName} {LastName}, Major: {Major}, GPA: {GPA}";
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.object.equals?view=net-6.0
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            else
            {
                Student secondStudent = (Student)obj;
                return (FirstName == secondStudent.FirstName) && (LastName == secondStudent.LastName);
            }
        }

        public int CompareTo(object obj)
        {
            //sort by Last Name, then First Name
            Student lhs = this;
            Student rhs = (Student)obj;

            if (lhs.LastName.CompareTo(rhs.LastName) == 0)
                return lhs.FirstName.CompareTo(rhs.FirstName);

            return lhs.LastName.CompareTo(rhs.LastName);
        }
    }
}
