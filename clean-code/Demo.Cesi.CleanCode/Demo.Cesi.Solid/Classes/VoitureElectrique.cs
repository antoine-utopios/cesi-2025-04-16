 : using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Solid.Interfaces;

namespace Demo.Cesi.Solid.Classes
{
    internal class VoitureElectrique : IDemarrable
    {
        public void Demarrer()
        {
            Console.WriteLine("La voiture électrique démarre");
        }
    }
}
