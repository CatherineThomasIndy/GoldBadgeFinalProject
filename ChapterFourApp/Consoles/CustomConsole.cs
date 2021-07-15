using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterFourApp.Consoles
{
    public class CustomConsole : ICustomConsole
    {
        public void AnyKey()
        {
            Console.WriteLine("Press any key to return to the main menu.");
        }

        public void Clear()
        {
            Console.Clear();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string text)
        {
            Console.WriteLine(text);
        }

        public void PrintMenu()
        {
            Console.WriteLine("Welcome to the Komodo Outings screen.\n" +
                "Select a menu item by entering the number of the menu item you wish to open.\n" +
                "1. Display a list of all outings\n" +
                "2. Add an individual outing\n" +
                "3. Display the total cost of all outings by type\n" +
                "4. Display the cost of all outings\n" +
                "5. Exit the app\n");
        }

        public void InvalidInput()
        {
            Console.WriteLine("Input was invalid.");
        }
    }
}
