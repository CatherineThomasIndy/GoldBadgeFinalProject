using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterFourApp.Consoles
{
    public interface ICustomConsole
    {
        void Clear();
        ConsoleKeyInfo ReadKey();
        string ReadLine();
        void AnyKey();
        void Write(string text);
        void PrintMenu();
        void InvalidInput();
    }
}
