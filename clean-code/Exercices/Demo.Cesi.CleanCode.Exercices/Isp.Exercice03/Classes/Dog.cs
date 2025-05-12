using Isp.Exercice03.Interfaces;

namespace Isp.Exercice03.Classes
{
    public class Dog : IAnimal
    {
        public void Eat() { Console.WriteLine("Dog is eating"); }
        public void Fly() { throw new NotImplementedException(); }
    }

}
