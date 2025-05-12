using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Solid.Interfaces;

namespace Demo.Cesi.Solid.Classes
{
    internal class Garage
    {
        private readonly IVehiculeAGazoile _vehicule;

        public Garage(IVehiculeAGazoile vehicule)
        {
            _vehicule = vehicule;
        }
    }
}
