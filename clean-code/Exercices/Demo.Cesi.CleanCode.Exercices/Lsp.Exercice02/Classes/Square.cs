using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsp.Exercice02.Classes
{
    public class Square : Rectangle
    {
        public override int Width
        {
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public override int Height
        {
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
    }
}
