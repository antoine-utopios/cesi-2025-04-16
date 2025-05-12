using Isp.Exercice01.Interfaces;

namespace Isp.Exercice01.Classes
{
    public class OldPrinter : IMachine
    {
        public void Print() { Console.WriteLine("Printing..."); }
        public void Scan() { throw new NotImplementedException(); }
        public void Fax() { throw new NotImplementedException(); }
    }

}
