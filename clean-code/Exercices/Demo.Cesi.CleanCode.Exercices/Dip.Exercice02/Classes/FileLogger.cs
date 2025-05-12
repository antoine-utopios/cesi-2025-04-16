using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip.Exercice02.Classes
{
    public class FileLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Fichier : {message}");
        }
    }

}
