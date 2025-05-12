using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Strategy.Interfaces;

namespace Demo.Cesi.Strategy.Classes
{
    internal class Plane : IFlying
    {
        public void Fly(double distance)
        {
            Console.WriteLine("L'avion vole en utilisant un moteur");
        }
    }
}
