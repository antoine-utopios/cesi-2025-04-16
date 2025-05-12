using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Adapter.Interfaces;

namespace Demo.Cesi.Adapter.Classes
{
    internal class PrintingService
    {
        List<IOldPrinter> _printers = new List<IOldPrinter>();

        void PrintWithAllPrinters(string message)
        {
            for (var printer in _printers)
            {
                printer.Print(message);
            }
        }
    }
}
