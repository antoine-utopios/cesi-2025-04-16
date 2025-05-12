using Isp.Exercice03.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isp.Exercice03.Classes
{
    public class Bird : IAnimal
    {
        public void Eat() { Console.WriteLine("Bird is eating"); }
        public void Fly() { Console.WriteLine("Bird is flying"); }
    }

}
