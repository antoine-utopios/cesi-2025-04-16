using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Cesi.Factory.Classes
{
    public class Hamburger
    {
        public int Id { get; set; }
        public string TypeOfBeef { get; set; }
        public string TypeOfBun { get; set; }
    }

    public class Cheeseburger : Hamburger
    {
        public string TypeOfCheese { get; set; }
    }

    public class  BigMacBurger : Hamburger
    {
        public int NbOfSteaks { get; set; }

        public BigMacBurger()
        {
            NbOfSteaks = 2;
        }

        public BigMacBurger(int nbOfSteaks)
        {
            NbOfSteaks = nbOfSteaks;
        }

    }

    internal class BurgerFactory
    {
        public static Hamburger CreateHamburger(string type)
        {
            //switch (type)
            //{
            //    case "Classic": 
            //        return new Hamburger();
            //    case "Cheeseburger":
            //        return new Cheeseburger();
            //    case "BigMac":
            //        return new BigMacBurger();
            //}

            return type switch
            {
                "Classic" => new Hamburger(),
                "Cheeseburger" => new Cheeseburger(),
                "BigMac" => new BigMacBurger(),
                "BigMac avec 50 steaks" => new BigMacBurger(50)
            };
        }
    }
}
