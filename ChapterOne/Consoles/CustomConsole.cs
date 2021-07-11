using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterOne.Consoles
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
            Console.WriteLine("Welcome to the Komodo Cafe Menu database. This is the Main Menu.\n" +
                "Select what you would like to do by entering the number that corresponds to the desired option:\n" +
                "1. See the full list of menu items.\n" +
                "2. Add a new meal to the menu.\n" +
                "3. Remove a meal from the menu.\n" +
                "4. Exit program.\n" +
                "");
        }

        public void InvalidSelection()
        {
            Console.WriteLine("Input was invalid.\n");
        }
    }
}
