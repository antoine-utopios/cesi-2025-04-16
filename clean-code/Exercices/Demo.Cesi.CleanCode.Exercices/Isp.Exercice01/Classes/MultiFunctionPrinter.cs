using Isp.Exercice01.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isp.Exercice01.Classes
{
    public class MultiFunctionPrinter : IMachine
    {
        public void Print() { Console.WriteLine("Printing..."); }
        public void Scan() { Console.WriteLine("Scanning..."); }
        public void Fax() { Console.WriteLine("Faxing..."); }
    }

}
