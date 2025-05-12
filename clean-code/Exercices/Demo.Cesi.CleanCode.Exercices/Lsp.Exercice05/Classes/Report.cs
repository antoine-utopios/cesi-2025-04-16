using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsp.Exercice05.Classes
{
    public abstract class Report
    {
        public abstract void Export(string path);
        public abstract string Preview();
    }

}
