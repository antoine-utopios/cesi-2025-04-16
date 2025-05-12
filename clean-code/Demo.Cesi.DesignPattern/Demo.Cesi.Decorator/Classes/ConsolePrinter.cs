using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Decorator.Interfaces;

namespace Demo.Cesi.Decorator.Classes
{
    internal class ConsolePrinter : IConsolePrinter
    {
        public void PrintToConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
