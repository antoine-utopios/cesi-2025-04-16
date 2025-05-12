using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Strategy.Interfaces;

namespace Demo.Cesi.Strategy.Classes
{
    internal class Bird : IFlying
    {
        private int _stamina;

        public Bird()
        {
            _stamina = 100;
        }
        public void Fly(double distance)
        {
            if (_stamina < 0)
            {
                Console.WriteLine("L'oiseau est fatigué et ne peut plus voler");
                return;
            }
            _stamina -= (int)distance / 10;

            Console.WriteLine("L'oiseau vole en utilisant ses ailes");
        }
    }
}
