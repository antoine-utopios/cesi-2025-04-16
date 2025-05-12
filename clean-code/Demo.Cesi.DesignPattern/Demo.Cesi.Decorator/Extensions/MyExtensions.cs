using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Cesi.Decorator.Interfaces;

namespace Demo.Cesi.Decorator.Extensions
{
    internal static class MyExtensions
    {
        public static void SendEmail(this IConsolePrinter printer, string message)
        {
            Console.WriteLine($"Envoi d'un email: {message}");
        }
    }
}
