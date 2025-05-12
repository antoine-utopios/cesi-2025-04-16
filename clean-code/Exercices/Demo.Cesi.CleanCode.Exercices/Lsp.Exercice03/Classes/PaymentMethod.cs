using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsp.Exercice03.Classes
{
    public abstract class PaymentMethod
    {
        public abstract void ProcessPayment(decimal amount);
    }
}
