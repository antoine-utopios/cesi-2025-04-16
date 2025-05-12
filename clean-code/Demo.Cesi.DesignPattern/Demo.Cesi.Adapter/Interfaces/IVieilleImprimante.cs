using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Cesi.Adapter.Interfaces
{
    internal interface IVieilleImprimante
    {
        void Imprimer(string message);
        void EnvoyerFax(string numeroTelephone, string message);
    }
}
