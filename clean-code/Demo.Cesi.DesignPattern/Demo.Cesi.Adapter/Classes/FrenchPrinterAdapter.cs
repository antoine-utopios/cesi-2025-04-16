using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Adapter.Interfaces;

namespace Demo.Cesi.Adapter.Classes
{
    internal class FrenchPrinterAdapter : IOldPrinter
    {
        private readonly IVieilleImprimante _vieilleImprimante;

        public FrenchPrinterAdapter(IVieilleImprimante vieilleImprimante)
        {
            _vieilleImprimante = vieilleImprimante;
        }
        public void Print(string message)
        {
            //_vieilleImprimante.Imprimer(message);
            var phoneNumber = message.Substring(0, 10);
            var messageToSend = message.Substring(10);

            _vieilleImprimante.EnvoyerFax(phoneNumber, messageToSend);
        }
    }
}
