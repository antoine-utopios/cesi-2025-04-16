using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsp.Exercice04.Classes
{
    public class Delivery
    {
        public virtual void ShipOrder(string destination)
        {
            Console.WriteLine($"Shipping order to {destination}");
        }
    }

}
