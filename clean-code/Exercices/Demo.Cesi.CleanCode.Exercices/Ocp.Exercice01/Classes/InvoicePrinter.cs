using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocp.Exercice01.Classes
{
    public class InvoicePrinter
    {
        public void PrintInvoice(string type)
        {
            if (type == "PDF")
            {
                Console.WriteLine("Printing PDF Invoice...");
            }
            else if (type == "Excel")
            {
                Console.WriteLine("Printing Excel Invoice...");
            }
            else
            {
                Console.WriteLine("Unknown invoice type");
            }
        }
    }

}
