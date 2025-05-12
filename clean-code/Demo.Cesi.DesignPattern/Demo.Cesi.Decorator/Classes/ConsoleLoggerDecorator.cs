using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Decorator.Interfaces;

namespace Demo.Cesi.Decorator.Classes
{
    internal class ConsoleLoggerDecorator : IConsolePrinter
    {
        private readonly IConsolePrinter _consolePrinter;

        public ConsoleLoggerDecorator(IConsolePrinter consolePrinter)
        {
            _consolePrinter = consolePrinter;
        }

        public void PrintToConsole(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: PrintToConsole() has been called!");
            _consolePrinter.PrintToConsole(message);
        }
    }
}
