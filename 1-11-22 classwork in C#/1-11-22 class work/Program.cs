using System;
using System.IO;  // to work with external files

namespace _1_11_22_class_work
{
    class Program
    {
        static void Main(string[] args)
        {
            // -------------- READ/WRITE TO CONSOLE: --------------

            Console.WriteLine("(Writing to console) Please enter a string: ");
            string userInputConsole = Console.ReadLine();
            Console.WriteLine($"You entered: {userInputConsole}");

            Console.WriteLine("Printing every other letter:");
            for (int i = 0; i < userInputConsole.Length; i += 2)  // traverse every other character of the string
            {
                Console.WriteLine(userInputConsole[i]);
            }

            Console.WriteLine("Count every 'S' and 's':");
            int count = 0;
            for (int i = 0; i < userInputConsole.Length; i++)  // traverse every character of the string
            {
                if (userInputConsole[i] == 'S' || userInputConsole[i] == 's')  // check if the current character is an "S" or an "s"
                {
                    count++;  // if it is, increase the count
                }
            }
            Console.WriteLine($"Final count is {count}");  // write to console


            // -------------- READ/WRITE TO EXTERNAL FILES: --------------

            StreamReader inputFile = new StreamReader("HelloWorld.txt");  // in the same folder as the .exe file (bin --> debug --> keep going until .exe is there)
            StreamWriter outputFile = new StreamWriter("GoodbyeWorld.txt");

            string userInputFromFile = inputFile.ReadLine();

            Console.WriteLine("Printing every other letter from external file:");
            for (int i = 0; i < userInputFromFile.Length; i += 2)  // traverse every other character of the string
            {
                Console.WriteLine(userInputFromFile[i]);
            }

            Console.WriteLine("Count every 'S' and 's' from external file:");
            int countFile = 0;
            for (int i = 0; i < userInputFromFile.Length; i++)  // traverse every character of the string
            {
                if (userInputFromFile[i] == 'S' || userInputFromFile[i] == 's')  // check if the current character is an "S" or an "s"
                {
                    countFile++;  // if it is, increase the count
                }
            }
            Console.WriteLine($"Final count from external file is {countFile}");  // write to console
            outputFile.WriteLine($"Final count from external file is {countFile}");  // write to external file

            inputFile.Close();
            outputFile.Close();


            // -------------- CALLING METHOD TO DISPLAY ASTERIKS: --------------

            Console.WriteLine("(Testing method) Display 5 stars:");
            DisplayAsterisks(5); Console.WriteLine();

            Console.Write("Enter today's sales for store 1: ");
            int store1 = int.Parse(Console.ReadLine()); // read user's input; convert str to int

            Console.Write("Enter today's sales for store 2: ");
            int store2 = int.Parse(Console.ReadLine()); // read user's input; convert str to int

            Console.WriteLine("SALES BAR CHART\n(Each * = $100)");
            Console.WriteLine("Store 1: "); DisplayAsterisks(store1 / 100); Console.WriteLine();
            Console.WriteLine("Store 2: "); DisplayAsterisks(store2 / 100); Console.WriteLine();
        }

        /*
        THE 3 FORWARD SLASH SHORTCUT IS FOR ADDING XML COMMENTS
        WHEN HOVERING OVER THE OBJECT, THE COMMENTS WILL APPEAR
        */

        /// <summary>
        /// Display num many stars
        /// </summary>
        /// <param name="num">The number of stars to display</param>
        public static void DisplayAsterisks(int num)  // method
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write("*");
            }
        }
    }
}
