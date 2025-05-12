using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Adapter.Interfaces;

namespace Demo.Cesi.Adapter.Classes
{
    internal class VieilleImprimante : IVieilleImprimante
    {
        public void EnvoyerFax(string numeroTelephone, string message)
        {
            Console.WriteLine($"Envoi d'un fax à {numeroTelephone}: {message}");
        }

        public void Imprimer(string message)
        {
            Console.WriteLine($"Impression: {message}");
        }
    }
}
