using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srp.Exercice01.Classes
{
    public class Invoice
    {
        public int Id { get; set; }
        public double Amount { get; set; }

        public void SaveToFile()
        {
            // Code pour sauvegarder dans un fichier
        }

        public double CalculateTotalWithTaxes()
        {
            return Amount * 1.2;
        }

        public void PrintInvoice()
        {
            // Code pour imprimer l'Invoice
        }
    }
}
