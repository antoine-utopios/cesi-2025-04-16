 : using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Solid.Interfaces;

namespace Demo.Cesi.Solid.Classes
{
    internal class Voiture : IVehiculeAGazoile
    {
        public void Demarrer()
        {
            Console.WriteLine("La voiture démarre");
        }

        public void FaireLePleinAvecGazoile(double liters)
        {
            Console.WriteLine($"La voiture a été remplie avec {liters} litres de gazoile");
        }
    }
}
