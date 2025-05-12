using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsp.Exercice01.Classes
{
    public class Ostrich : Bird
    {
        public override void Fly()
        {
            throw new NotImplementedException("Ostriches can't fly!");
        }
    }
}
