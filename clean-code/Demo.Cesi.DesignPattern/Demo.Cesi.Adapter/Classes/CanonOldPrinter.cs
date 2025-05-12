using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Adapter.Interfaces;

namespace Demo.Cesi.Adapter.Classes
{
    internal class CanonOldPrinter : IOldPrinter
    {
        public void Print(string message)
        {
            Console.WriteLine($"Canon printer: {message}");
        }
    }
}
