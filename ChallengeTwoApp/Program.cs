using ChallengeTwoApp.Consoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomConsole _con = new CustomConsole();
            ProgramUI program = new ProgramUI(_con);
            program.Run();
        }
    }
}
