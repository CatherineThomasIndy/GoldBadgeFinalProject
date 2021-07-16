using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoApp.Consoles
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
            Console.WriteLine("");
        }
    }
}
