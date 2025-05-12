using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Solid.Interfaces;

namespace Demo.Cesi.Solid.Classes
{
    internal class OperationClassique : IOperationBancaire
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public decimal FinalAmount
        {
            get
            {
                return Amount;
            }
        }
    }
}
